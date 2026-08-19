using System;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Bridges Purchase Requests to the generic workflow engine (Data/WorkflowEngine.cs). The engine
    /// itself only knows about entity name + record id (it must not depend upward on Etmam-namespace
    /// business logic), so this class holds every piece of PurchaseRequestList-specific knowledge:
    /// which procedure to start, and how to fold a finished workflow instance's outcome back onto the
    /// PR's own OverallStatus/ApprovedBy/ApprovedDate/RejectReason columns.
    ///
    /// Status sync is pull-based, not push-based: WorkflowEngine.Act() does not know Purchase Requests
    /// exist, so Reconcile() must be called wherever a PR's status is actually displayed
    /// (frmPurchaseRequestAddEdit.LoadRecord, ucPurchaseRequests.LoadData) rather than relying on a
    /// callback fired the instant the workflow instance finishes.
    /// </summary>
    public static class PurchaseRequestWorkflowSync
    {
        private const string ProcedureName = "طلب الشراء";
        private const string EntityName = "PurchaseRequestList";

        /// <summary>Active, non-deleted procedures usable for this specific Purchase Request — matched by
        /// Category = EntityName ("PurchaseRequestList"), with a legacy fallback (Category IS NULL AND
        /// Name = the original hardcoded ProcedureName) so any install that hasn't categorized its
        /// existing procedure yet keeps seeing exactly the one it already had — then narrowed by the PR's
        /// own project/discipline against each candidate's WorkflowDefinitionList.ProjectId (null = every
        /// project) and WorkflowDefinitionDisciplineList rows (none = "عام", every discipline). The caller
        /// (see frmPurchaseRequestAddEdit.SendForApproval) uses this to decide whether to prompt: one
        /// result starts directly, more than one shows a picker. See frmWorkflowDefinitionAddEdit's
        /// CheckForConflict for how two candidates are kept from ever both matching the same PR.</summary>
        public static List<WorkflowDefinitionList> GetAvailableProcedures(DataContext dc, PurchaseRequestList pr)
        {
            var candidates = dc.WorkflowDefinitionList
                .GetBy("IsDelete = 0 AND IsActive = 1 AND (Category = @cat OR (Category IS NULL AND Name = @legacyName))",
                       new { cat = EntityName, legacyName = ProcedureName })
                .Where(d => d.ProjectId == null || d.ProjectId == pr.PrjId)
                .ToList();

            if (candidates.Count == 0) return candidates;

            var defIds = candidates.Select(d => d.Id).ToList();
            var disciplinesByDef = dc.WorkflowDefinitionDisciplineList
                .GetBy($"WorkflowDefinitionId IN ({string.Join(",", defIds)})")
                .GroupBy(l => l.WorkflowDefinitionId)
                .ToDictionary(g => g.Key, g => g.Select(l => l.DisciplineId).ToHashSet());

            return candidates.Where(d =>
                !disciplinesByDef.TryGetValue(d.Id, out var set) || set.Count == 0   // "عام"
                || (pr.DisciplineId.HasValue && set.Contains(pr.DisciplineId.Value))
            ).ToList();
        }

        /// <summary>
        /// Starts the given procedure for this PR (the caller has already resolved which one — see
        /// GetAvailableProcedures). Throws (with an Arabic message safe to show directly to the user) if
        /// this PR already has an active instance (guards against a double-click/retry creating a
        /// duplicate InProgress row).
        /// </summary>
        public static void SendForApproval(DataContext dc, PurchaseRequestList pr, int workflowDefinitionId)
        {
            if (GetActiveInstance(dc, pr.Id) != null)
                throw new InvalidOperationException("يوجد بالفعل إجراء اعتماد جارٍ لهذا الطلب.");

            WorkflowEngine.StartWorkflow(workflowDefinitionId, EntityName, pr.Id, Session.CurrentUser?.Id ?? 1);
        }

        /// <summary>The PR's currently running (InProgress) workflow instance, if any.</summary>
        public static WorkflowInstanceList? GetActiveInstance(DataContext dc, int prId) =>
            dc.WorkflowInstanceList
              .GetBy("EntityName = @n AND EntityRecordId = @id AND Status = 'InProgress'",
                     new { n = EntityName, id = prId })
              .FirstOrDefault();

        /// <summary>The PR's most recent workflow instance regardless of status (InProgress/Approved/
        /// Rejected) — unlike GetActiveInstance, this also finds a terminal (finished) instance, needed
        /// to re-open an already-Approved PR via ReturnToStep since there's no "active" instance left
        /// for it once approval completed.</summary>
        public static WorkflowInstanceList? GetLatestInstance(DataContext dc, int prId) =>
            dc.WorkflowInstanceList
              .GetBy("EntityName = @n AND EntityRecordId = @id", new { n = EntityName, id = prId })
              .OrderByDescending(i => i.Id)
              .FirstOrDefault();

        /// <summary>True if at least one (non-deleted) Purchase Order has already been raised against
        /// this PR — used to block re-opening an Approved PR back into the workflow once procurement
        /// has already acted on it.</summary>
        public static bool HasIssuedPurchaseOrder(DataContext dc, int prId) =>
            dc.PurchaseOrderList.GetBy("PRId = @id AND IsDelete = 0", new { id = prId }).Any();

        /// <summary>Sends this PR's workflow instance back to an earlier step (see
        /// WorkflowEngine.ReturnToStep for the two scenarios this covers) and folds the result back onto
        /// the PR row: it always ends up PendingApproval again — even if it was fully Approved before the
        /// call — with any prior ApprovedBy/ApprovedDate cleared since that approval no longer holds.</summary>
        public static void ReturnToStep(DataContext dc, PurchaseRequestList pr, WorkflowInstanceList instance,
            int targetStepOrder, string comment, bool requireCurrentStepAssignee)
        {
            WorkflowEngine.ReturnToStep(instance.Id, Session.CurrentUser?.Id ?? 1, targetStepOrder, comment, requireCurrentStepAssignee);

            pr.OverallStatus = PurchaseRequestStatus.PendingApproval;
            pr.ApprovedBy = null;
            pr.ApprovedDate = null;
            pr.UpdateDate = DateTime.Now;
            pr.UpdateMachine = Session.Machine;
            pr.UpdateBy = Session.CurrentUser?.Id ?? 1;
            dc.PurchaseRequestList.Edit(pr.Id, pr);
        }

        /// <summary>Display name of the step a running instance is currently sitting at.</summary>
        public static string? GetCurrentStepName(DataContext dc, WorkflowInstanceList instance) =>
            dc.WorkflowStepList
              .GetBy("WorkflowDefinitionId = @id AND StepOrder = @order",
                     new { id = instance.WorkflowDefinitionId, order = instance.CurrentStepOrder })
              .FirstOrDefault()?.Name;

        /// <summary>Status text for grids: while a PR is mid-approval, names the step it's actually
        /// waiting on (e.g. "تحت إجراء مراجعة مسئول المخزن") instead of the generic "قيد الاعتماد",
        /// so the reader can tell who's holding it up without opening the request.</summary>
        public static string GetStatusDisplay(DataContext dc, PurchaseRequestList pr)
        {
            if (pr.OverallStatus == PurchaseRequestStatus.PendingApproval)
            {
                var instance = GetActiveInstance(dc, pr.Id);
                var stepName = instance != null ? GetCurrentStepName(dc, instance) : null;
                if (!string.IsNullOrWhiteSpace(stepName))
                    return $"تحت إجراء {stepName}";
            }

            return PurchaseRequestStatus.ToDisplay(pr.OverallStatus);
        }

        /// <summary>
        /// Keeps PurchaseRequestList.OverallStatus honest against the workflow engine's own tables in
        /// both directions — safe to call unconditionally every time a PR is loaded/displayed:
        /// 1) If there's actually an active (InProgress) instance for this PR but the stored status
        ///    disagrees (e.g. a direct header edit clobbered it back to Draft — see the fixed bug in
        ///    frmPurchaseRequestAddEdit.SaveRecord that used to do exactly this), corrects it forward to
        ///    PendingApproval so the PR list and "مهامي" can't show two different stories for the same
        ///    request again.
        /// 2) Otherwise, if this PR is PendingApproval and its most recent instance has actually finished
        ///    (Approved/Rejected), writes that outcome back onto the PR row (original behavior).
        /// </summary>
        public static void Reconcile(DataContext dc, PurchaseRequestList pr)
        {
            var activeInstance = GetActiveInstance(dc, pr.Id);
            if (activeInstance != null)
            {
                if (pr.OverallStatus != PurchaseRequestStatus.PendingApproval)
                {
                    pr.OverallStatus = PurchaseRequestStatus.PendingApproval;
                    pr.UpdateDate = DateTime.Now;
                    pr.UpdateMachine = Session.Machine;
                    pr.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.PurchaseRequestList.Edit(pr.Id, pr);
                }
                return;
            }

            if (pr.OverallStatus != PurchaseRequestStatus.PendingApproval) return;

            var instance = dc.WorkflowInstanceList
                .GetBy("EntityName = @n AND EntityRecordId = @id", new { n = EntityName, id = pr.Id })
                .OrderByDescending(i => i.Id)
                .FirstOrDefault();

            if (instance == null || instance.Status == "InProgress") return;

            if (instance.Status == "Approved")
            {
                pr.OverallStatus = PurchaseRequestStatus.Approved;
                pr.ApprovedBy = instance.UpdateBy;
                pr.ApprovedDate = instance.CompletedDate;
            }
            else if (instance.Status == "Rejected")
            {
                pr.OverallStatus = PurchaseRequestStatus.Rejected;
                pr.RejectReason = dc.WorkflowInstanceHistoryList
                    .GetBy("WorkflowInstanceId = @id", new { id = instance.Id })
                    .OrderByDescending(h => h.Id)
                    .FirstOrDefault()?.Comment;
            }
            else
            {
                return; // unknown/unexpected status — leave the PR untouched rather than guess
            }

            pr.UpdateDate = DateTime.Now;
            pr.UpdateMachine = Session.Machine;
            pr.UpdateBy = Session.CurrentUser?.Id ?? 1;
            dc.PurchaseRequestList.Edit(pr.Id, pr);
        }

        /// <summary>
        /// Grid-load version of Reconcile()+GetStatusDisplay() combined: the per-row versions each issue
        /// their own WorkflowInstanceList/WorkflowStepList queries, so a list of N PRs costs 2-3*N round
        /// trips. This does the same reconciliation and status-text logic but against a handful of
        /// IN(...) queries fetched once for the whole batch (see ucPurchaseRequests.LoadData). Writes
        /// (dc.PurchaseRequestList.Edit) still happen per-PR, but only for the rare rows whose stored
        /// status is actually out of sync — not on every load. Returns each PR's status display text,
        /// keyed by Id.
        /// </summary>
        public static Dictionary<int, string> ReconcileAndGetStatusDisplayBulk(DataContext dc, List<PurchaseRequestList> prs)
        {
            var result = new Dictionary<int, string>();
            if (prs.Count == 0) return result;

            var ids = string.Join(",", prs.Select(p => p.Id));
            var instances = dc.WorkflowInstanceList
                .GetBy($"EntityName = @n AND EntityRecordId IN ({ids})", new { n = EntityName });

            var activeByPrId = instances.Where(i => i.Status == "InProgress")
                .GroupBy(i => i.EntityRecordId)
                .ToDictionary(g => g.Key, g => g.First());

            var latestByPrId = instances
                .GroupBy(i => i.EntityRecordId)
                .ToDictionary(g => g.Key, g => g.OrderByDescending(i => i.Id).First());

            var defIds = instances.Select(i => i.WorkflowDefinitionId).Distinct().ToList();
            var stepNameByDefAndOrder = defIds.Count > 0
                ? dc.WorkflowStepList
                    .GetBy($"WorkflowDefinitionId IN ({string.Join(",", defIds)})")
                    .ToDictionary(s => (s.WorkflowDefinitionId, s.StepOrder), s => s.Name ?? "")
                : new Dictionary<(int, int), string>();

            foreach (var pr in prs)
            {
                if (activeByPrId.TryGetValue(pr.Id, out var active))
                {
                    if (pr.OverallStatus != PurchaseRequestStatus.PendingApproval)
                    {
                        pr.OverallStatus = PurchaseRequestStatus.PendingApproval;
                        pr.UpdateDate = DateTime.Now;
                        pr.UpdateMachine = Session.Machine;
                        pr.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        dc.PurchaseRequestList.Edit(pr.Id, pr);
                    }

                    var stepName = stepNameByDefAndOrder.GetValueOrDefault((active.WorkflowDefinitionId, active.CurrentStepOrder));
                    result[pr.Id] = !string.IsNullOrWhiteSpace(stepName)
                        ? $"تحت إجراء {stepName}"
                        : PurchaseRequestStatus.ToDisplay(pr.OverallStatus);
                    continue;
                }

                if (pr.OverallStatus == PurchaseRequestStatus.PendingApproval &&
                    latestByPrId.TryGetValue(pr.Id, out var latest) && latest.Status != "InProgress")
                {
                    if (latest.Status == "Approved")
                    {
                        pr.OverallStatus = PurchaseRequestStatus.Approved;
                        pr.ApprovedBy = latest.UpdateBy;
                        pr.ApprovedDate = latest.CompletedDate;
                        pr.UpdateDate = DateTime.Now;
                        pr.UpdateMachine = Session.Machine;
                        pr.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        dc.PurchaseRequestList.Edit(pr.Id, pr);
                    }
                    else if (latest.Status == "Rejected")
                    {
                        pr.OverallStatus = PurchaseRequestStatus.Rejected;
                        pr.RejectReason = dc.WorkflowInstanceHistoryList
                            .GetBy("WorkflowInstanceId = @id", new { id = latest.Id })
                            .OrderByDescending(h => h.Id)
                            .FirstOrDefault()?.Comment;
                        pr.UpdateDate = DateTime.Now;
                        pr.UpdateMachine = Session.Machine;
                        pr.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        dc.PurchaseRequestList.Edit(pr.Id, pr);
                    }
                }

                result[pr.Id] = PurchaseRequestStatus.ToDisplay(pr.OverallStatus);
            }

            return result;
        }
    }
}
