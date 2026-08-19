using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Web-side port of Etmam/Gui/ProcurementModule/PurchaseRequest/frmPurchaseRequestAddEdit.cs +
    /// PurchaseRequestWorkflowSync.cs. Every status transition and guard below mirrors that pair
    /// exactly (see the class-level notes on each method for which desktop method it replicates) -
    /// nothing here is new business logic.
    ///
    /// Known simplifications versus the desktop client (documented, not silent):
    /// - Self-approval is blocked by a direct CreatedBy == currentUserId check rather than the
    ///   desktop's SeparationOfDutiesHelper.BlocksSelfApproval (whose exact rule wasn't pulled for
    ///   this port) - same practical effect for the common case.
    /// - No WhatsApp notifications (see IWorkflowService's own note) and no AuditService log rows.
    /// - HasIssuedPurchaseOrder is not checked when reopening an Approved request via return-to-step,
    ///   since Purchase Orders don't exist in this API yet (a later batch) - always false today, so
    ///   behavior is identical; revisit once POs are wired up.
    /// - Fine-grained per-action permissions (PermNames.PRSend/PRDelete/...) have no web equivalent
    ///   yet - every action is gated purely on the request's workflow state, not on the caller's role.
    /// - ApproveAsync/RejectAsync deliberately have no project-access check of their own (only
    ///   GetAllAsync/GetByIdAsync do, via ProjectAccessService) - this matches desktop exactly, where
    ///   WorkflowEngine.CanUserAct/Act is purely assignee-based with no project join (see
    ///   ucPurchaseRequests.cs's own comment on this split: project access controls what you can
    ///   *see*, being the assigned step's approver is by itself sufficient to *act*).
    /// </summary>
    public sealed class PurchaseRequestsService
    {
        private const string EntityName = "PurchaseRequestList";
        private const string LegacyProcedureName = "طلب الشراء";

        private readonly IApplicationDbContext _db;
        private readonly IWorkflowService _workflow;
        private readonly INumberingService _numbering;
        private readonly ProjectAccessService _projectAccess;

        public PurchaseRequestsService(IApplicationDbContext db, IWorkflowService workflow, INumberingService numbering, ProjectAccessService projectAccess)
        {
            _db = db;
            _workflow = workflow;
            _numbering = numbering;
            _projectAccess = projectAccess;
        }

        /// <summary>Mirrors GetByIdAsync's per-record ReconcileAsync/ToDtoAsync in effect, but computes
        /// every row's workflow state from a handful of batched queries (see LoadWorkflowBatchAsync)
        /// instead of ReconcileAsync/ToDtoAsync's own ~5-8 sequential round-trips PER row - which,
        /// against a remote SQL Server with real (non-trivial) row counts, turns into minutes of wall
        /// time and client-side timeouts. GetByIdAsync deliberately keeps using the simple per-record
        /// path below since it only ever runs that cost once.
        ///
        /// Also mirrors ucPurchaseRequests.cs's own grid filter: only requests whose project the
        /// caller has been granted access to (ProjectAccessService, i.e. UserProjectAccess) are
        /// returned - filtered in SQL, not in-memory, so a restricted user's query is cheaper too, not
        /// just narrower.</summary>
        public async Task<List<PurchaseRequestDto>> GetAllAsync(int currentUserId, CancellationToken ct = default)
        {
            var grantedProjectIds = await _projectAccess.GetGrantedProjectIdsAsync(currentUserId, ct);

            var query = _db.PurchaseRequestList.AsQueryable();
            if (grantedProjectIds != null)
                query = query.Where(p => p.PrjId.HasValue && grantedProjectIds.Contains(p.PrjId.Value));

            var prs = await query.OrderByDescending(p => p.RequestDate).ToListAsync(ct);
            var lookups = await BuildLookupsAsync(ct);
            var batch = await LoadWorkflowBatchAsync(prs.Select(p => p.Id).ToList(), currentUserId, ct);

            var dirty = false;
            var result = new List<PurchaseRequestDto>(prs.Count);
            foreach (var pr in prs)
            {
                var entry = batch.GetValueOrDefault(pr.Id);
                dirty |= await ReconcileFromBatchAsync(pr, entry, currentUserId, ct);
                result.Add(ToDtoFromBatch(pr, lookups, entry, currentUserId));
            }
            if (dirty) await _db.SaveChangesAsync(ct);
            return result;
        }

        /// <summary>Unlike the desktop grid (whose project filter is the only path to a record - there's
        /// no "open PR #123 directly" without it appearing in the filtered grid first), a mobile API
        /// caller could request any id directly. Returning null (same as "doesn't exist") for a project
        /// the caller isn't granted recreates that same reachability constraint server-side rather than
        /// relying on the client having gone through the (also filtered) list first.</summary>
        public async Task<PurchaseRequestDto?> GetByIdAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var pr = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == id, ct);
            if (pr is null) return null;

            var grantedProjectIds = await _projectAccess.GetGrantedProjectIdsAsync(currentUserId, ct);
            if (!ProjectAccessService.CanAccess(grantedProjectIds, pr.PrjId)) return null;

            await ReconcileAsync(pr, currentUserId, ct);
            var lookups = await BuildLookupsAsync(ct);
            return await ToDtoAsync(pr, lookups, currentUserId, includeLines: true, ct);
        }

        /// <summary>Mirrors BuildHeaderEntity + SaveRecord's "new PR" branch.</summary>
        public async Task<int> CreateAsync(PurchaseRequestCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var requestDate = request.RequestDate ?? DateTime.Today;

            await using var tx = await _db.BeginTransactionAsync(ct);

            var entity = new PurchaseRequestList
            {
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId,
                IsDelete = false,
                OverallStatus = PurchaseRequestStatus.Draft
            };
            Apply(request, entity);
            entity.RequestDate = requestDate;

            entity.Num = await _numbering.GetNextNumberAsync(EntityName, requestDate.Year, async () =>
                await _db.PurchaseRequestList
                    .Where(r => r.RequestDate != null && r.RequestDate.Value.Year == requestDate.Year)
                    .Select(r => (int?)(r.Num ?? 0))
                    .MaxAsync(ct) ?? 0,
                ct);

            _db.PurchaseRequestList.Add(entity);
            await _db.SaveChangesAsync(ct);

            await SaveLinesAsync(entity.Id, request.Lines, currentUserId, ct);
            await tx.CommitAsync(ct);

            return entity.Id;
        }

        /// <summary>Mirrors SaveRecord's "edit PR" branch - Num/OverallStatus/ApprovedBy/ApprovedDate/
        /// RejectReason are owned by CreateAsync/the workflow actions below and must survive an
        /// unrelated header edit untouched, so they're deliberately not part of Apply().</summary>
        public async Task UpdateAsync(int id, PurchaseRequestUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Purchase request {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
            await SaveLinesAsync(id, request.Lines, currentUserId, ct);
        }

        /// <summary>Mirrors DeleteCurrentRecord's status guard (Draft/Rejected only) and the
        /// NumberingService.ReleaseIfLast call for a deleted, never-submitted number.</summary>
        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var pr = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Purchase request {id} not found.");

            if (pr.OverallStatus != PurchaseRequestStatus.Draft && pr.OverallStatus != PurchaseRequestStatus.Rejected)
                throw new InvalidOperationException("لا يمكن حذف الطلب إلا من حالة مسودة أو مرفوض.");

            await using var tx = await _db.BeginTransactionAsync(ct);

            var lines = await _db.PurchaseRequestDetails.Where(d => d.PRId == id).ToListAsync(ct);
            foreach (var line in lines)
            {
                line.IsDelete = true;
                line.DeletionDate = DateTime.Now;
                line.DeletionMachine = Environment.MachineName;
                line.DeletionBy = currentUserId;
            }

            pr.IsDelete = true;
            pr.DeletionDate = DateTime.Now;
            pr.DeletionMachine = Environment.MachineName;
            pr.DeletionBy = currentUserId;
            await _db.SaveChangesAsync(ct);

            if (pr.Num.HasValue && pr.RequestDate.HasValue)
                await _numbering.ReleaseIfLastAsync(EntityName, pr.RequestDate.Value.Year, pr.Num.Value, ct);

            await tx.CommitAsync(ct);
        }

        /// <summary>Mirrors PurchaseRequestWorkflowSync.GetAvailableProcedures.</summary>
        public async Task<List<WorkflowDefinitionDto>> GetAvailableProceduresAsync(int id, CancellationToken ct = default)
        {
            var pr = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Purchase request {id} not found.");

            var candidates = await _db.WorkflowDefinitionList
                .Where(d => !d.IsDelete && d.IsActive
                    && (d.Category == EntityName || (d.Category == null && d.Name == LegacyProcedureName)))
                .Where(d => d.ProjectId == null || d.ProjectId == pr.PrjId)
                .ToListAsync(ct);

            if (candidates.Count == 0) return [];

            var defIds = candidates.Select(d => d.Id).ToList();
            var disciplinesByDef = (await _db.WorkflowDefinitionDisciplineList
                    .Where(l => defIds.Contains(l.WorkflowDefinitionId))
                    .ToListAsync(ct))
                .GroupBy(l => l.WorkflowDefinitionId)
                .ToDictionary(g => g.Key, g => g.Select(l => l.DisciplineId).ToHashSet());

            return candidates
                .Where(d => !disciplinesByDef.TryGetValue(d.Id, out var set) || set.Count == 0 // "عام" - every discipline
                            || (pr.DisciplineId.HasValue && set.Contains(pr.DisciplineId.Value)))
                .Select(d => new WorkflowDefinitionDto { Id = d.Id, Name = d.Name })
                .ToList();
        }

        /// <summary>Mirrors SendForApproval - the caller has already resolved workflowDefinitionId
        /// (directly if GetAvailableProceduresAsync returned exactly one, or via a picker if more).</summary>
        public async Task SendForApprovalAsync(int id, int workflowDefinitionId, int currentUserId, CancellationToken ct = default)
        {
            var pr = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Purchase request {id} not found.");

            if (pr.OverallStatus != PurchaseRequestStatus.Draft)
                throw new InvalidOperationException("لا يمكن إرسال الطلب للاعتماد إلا من حالة المسودة.");

            if (await _workflow.GetActiveInstanceAsync(EntityName, id, ct) != null)
                throw new InvalidOperationException("يوجد بالفعل إجراء اعتماد جارٍ لهذا الطلب.");

            await _workflow.StartWorkflowAsync(workflowDefinitionId, EntityName, id, currentUserId, ct);

            pr.OverallStatus = PurchaseRequestStatus.PendingApproval;
            pr.UpdateDate = DateTime.Now;
            pr.UpdateMachine = Environment.MachineName;
            pr.UpdateBy = currentUserId;
            await _db.SaveChangesAsync(ct);
        }

        /// <summary>Mirrors ActOnWorkflowStep("Approved").</summary>
        public Task ApproveAsync(int id, string? comment, int currentUserId, CancellationToken ct = default) =>
            ActOnCurrentStepAsync(id, "Approved", comment, currentUserId, ct);

        /// <summary>Mirrors ActOnWorkflowStep("Rejected").</summary>
        public Task RejectAsync(int id, string? comment, int currentUserId, CancellationToken ct = default) =>
            ActOnCurrentStepAsync(id, "Rejected", comment, currentUserId, ct);

        private async Task ActOnCurrentStepAsync(int id, string action, string? comment, int currentUserId, CancellationToken ct)
        {
            var pr = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Purchase request {id} not found.");

            if (pr.CreatedBy == currentUserId)
                throw new InvalidOperationException("لا يمكنك اعتماد أو رفض طلب أنشأته بنفسك.");

            var instance = await _workflow.GetActiveInstanceAsync(EntityName, id, ct)
                ?? throw new InvalidOperationException("لا يوجد إجراء اعتماد جارٍ لهذا الطلب.");

            await _workflow.ActAsync(instance.Id, currentUserId, action, comment, ct);
            await ReconcileAsync(pr, currentUserId, ct);
        }

        /// <summary>Mirrors DoReturnToStep's step-picker source (still the live WorkflowStepList, same
        /// as the desktop - not the instance's own snapshot, matching that method exactly).</summary>
        public async Task<List<WorkflowStepOptionDto>> GetReturnToStepOptionsAsync(int id, CancellationToken ct = default)
        {
            var (instance, requireCurrentStepAssignee) = await ResolveReturnableInstanceAsync(id, ct);

            var steps = await _db.WorkflowStepList
                .Where(s => s.WorkflowDefinitionId == instance.WorkflowDefinitionId && s.StepOrder <= instance.CurrentStepOrder)
                .ToListAsync(ct);

            if (requireCurrentStepAssignee)
                steps = steps.Where(s => s.StepOrder < instance.CurrentStepOrder).ToList();

            return steps.OrderBy(s => s.StepOrder)
                .Select(s => new WorkflowStepOptionDto { StepOrder = s.StepOrder, Name = s.Name })
                .ToList();
        }

        /// <summary>Mirrors ReturnToStep/DoReturnToStep + PurchaseRequestWorkflowSync.ReturnToStep.</summary>
        public async Task ReturnToStepAsync(int id, int targetStepOrder, string comment, int currentUserId, CancellationToken ct = default)
        {
            var pr = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Purchase request {id} not found.");

            var (instance, requireCurrentStepAssignee) = await ResolveReturnableInstanceAsync(id, ct);

            await _workflow.ReturnToStepAsync(instance.Id, currentUserId, targetStepOrder, comment, requireCurrentStepAssignee, ct);

            pr.OverallStatus = PurchaseRequestStatus.PendingApproval;
            pr.ApprovedBy = null;
            pr.ApprovedDate = null;
            pr.UpdateDate = DateTime.Now;
            pr.UpdateMachine = Environment.MachineName;
            pr.UpdateBy = currentUserId;
            await _db.SaveChangesAsync(ct);
        }

        private async Task<(WorkflowInstanceList Instance, bool RequireCurrentStepAssignee)> ResolveReturnableInstanceAsync(int id, CancellationToken ct)
        {
            var pr = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Purchase request {id} not found.");

            WorkflowInstanceList? instance;
            bool requireCurrentStepAssignee;

            if (pr.OverallStatus == PurchaseRequestStatus.PendingApproval)
            {
                instance = await _workflow.GetActiveInstanceAsync(EntityName, id, ct);
                requireCurrentStepAssignee = true;
            }
            else if (pr.OverallStatus == PurchaseRequestStatus.Approved)
            {
                instance = await _workflow.GetLatestInstanceAsync(EntityName, id, ct);
                requireCurrentStepAssignee = false;
            }
            else
            {
                throw new InvalidOperationException("لا يمكن إعادة هذا الطلب في حالته الحالية.");
            }

            if (instance is null)
                throw new InvalidOperationException("تعذّر تحديد إجراء الاعتماد لهذا الطلب.");

            return (instance, requireCurrentStepAssignee);
        }

        /// <summary>Mirrors ChangeStatus(Closed). Re-validates the state-machine transition server-side
        /// since the desktop only enforces this via button enablement, which a direct API call bypasses.</summary>
        public Task CloseAsync(int id, int currentUserId, CancellationToken ct = default) =>
            ChangeStatusAsync(id, PurchaseRequestStatus.Closed, PurchaseRequestStatus.Approved, "لا يمكن إغلاق الطلب إلا من حالة معتمد.", currentUserId, ct);

        /// <summary>Mirrors ChangeStatus(Draft) ("إرجاع للتعديل").</summary>
        public Task ReturnForEditAsync(int id, int currentUserId, CancellationToken ct = default) =>
            ChangeStatusAsync(id, PurchaseRequestStatus.Draft, PurchaseRequestStatus.Rejected, "لا يمكن إعادة الطلب للمسودة إلا من حالة مرفوض.", currentUserId, ct);

        private async Task ChangeStatusAsync(int id, string newStatus, string requiredCurrentStatus, string guardMessage, int currentUserId, CancellationToken ct)
        {
            var pr = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Purchase request {id} not found.");

            if (pr.OverallStatus != requiredCurrentStatus)
                throw new InvalidOperationException(guardMessage);

            pr.OverallStatus = newStatus;
            pr.UpdateDate = DateTime.Now;
            pr.UpdateMachine = Environment.MachineName;
            pr.UpdateBy = currentUserId;
            await _db.SaveChangesAsync(ct);
        }

        /// <summary>Mirrors PurchaseRequestWorkflowSync.Reconcile - pull-based sync between
        /// PurchaseRequestList.OverallStatus and the workflow engine's own tables, safe to call
        /// unconditionally on every load/list.</summary>
        private async Task ReconcileAsync(PurchaseRequestList pr, int currentUserId, CancellationToken ct)
        {
            var activeInstance = await _workflow.GetActiveInstanceAsync(EntityName, pr.Id, ct);
            if (activeInstance != null)
            {
                if (pr.OverallStatus != PurchaseRequestStatus.PendingApproval)
                {
                    pr.OverallStatus = PurchaseRequestStatus.PendingApproval;
                    pr.UpdateDate = DateTime.Now;
                    pr.UpdateMachine = Environment.MachineName;
                    pr.UpdateBy = currentUserId;
                    await _db.SaveChangesAsync(ct);
                }
                return;
            }

            if (pr.OverallStatus != PurchaseRequestStatus.PendingApproval) return;

            var instance = await _workflow.GetLatestInstanceAsync(EntityName, pr.Id, ct);
            if (instance is null || instance.Status == "InProgress") return;

            if (instance.Status == "Approved")
            {
                pr.OverallStatus = PurchaseRequestStatus.Approved;
                pr.ApprovedBy = instance.UpdateBy;
                pr.ApprovedDate = instance.CompletedDate;
            }
            else if (instance.Status == "Rejected")
            {
                pr.OverallStatus = PurchaseRequestStatus.Rejected;
                pr.RejectReason = (await _db.WorkflowInstanceHistoryList
                    .Where(h => h.WorkflowInstanceId == instance.Id)
                    .OrderByDescending(h => h.Id)
                    .FirstOrDefaultAsync(ct))?.Comment;
            }
            else
            {
                return; // unknown/unexpected status - leave the PR untouched rather than guess
            }

            pr.UpdateDate = DateTime.Now;
            pr.UpdateMachine = Environment.MachineName;
            pr.UpdateBy = currentUserId;
            await _db.SaveChangesAsync(ct);
        }

        /// <summary>One entry per PR id that has ever had a workflow instance - everything GetAllAsync
        /// needs to reconcile status and compute CanCurrentUserAct/StatusDisplay for that row without
        /// any further DB round-trip (the rare "just transitioned to Rejected" case in
        /// ReconcileFromBatchAsync is the sole exception, since it's bounded to actual transitions,
        /// not every row).</summary>
        private sealed record WorkflowBatchEntry(WorkflowInstanceList? Active, WorkflowInstanceList? Latest, string? CurrentStepName, bool CanAct);

        /// <summary>Batches what ReconcileAsync/ToDtoAsync otherwise fetch per-record (active instance,
        /// its current step, whether the current user is that step's assignee) into ~3 queries total
        /// regardless of row count. See GetAllAsync's own summary for why this exists.</summary>
        private async Task<Dictionary<int, WorkflowBatchEntry>> LoadWorkflowBatchAsync(List<int> recordIds, int currentUserId, CancellationToken ct)
        {
            if (recordIds.Count == 0) return [];

            var instances = await _db.WorkflowInstanceList
                .Where(i => i.EntityName == EntityName && recordIds.Contains(i.EntityRecordId))
                .ToListAsync(ct);
            if (instances.Count == 0) return [];

            var activeInstances = instances.Where(i => i.Status == "InProgress").ToList();
            var activeIds = activeInstances.Select(i => i.Id).ToList();

            var stepSnapshots = activeIds.Count == 0
                ? []
                : await _db.WorkflowInstanceStepList
                    .Where(s => activeIds.Contains(s.WorkflowInstanceId) && !s.IsDelete)
                    .ToListAsync(ct);

            var currentStepByInstanceId = new Dictionary<int, WorkflowInstanceStepList>();
            foreach (var instance in activeInstances)
            {
                var step = stepSnapshots.FirstOrDefault(s => s.WorkflowInstanceId == instance.Id && s.StepOrder == instance.CurrentStepOrder);
                // No matching snapshot only happens for a legacy instance started before step-snapshotting
                // existed - falling back to a live-step lookup here would reintroduce the very N+1 this
                // batch exists to avoid, so such rows just show the generic "قيد الاعتماد" label instead
                // of the step name (GetByIdAsync's single-record path still resolves this correctly).
                if (step != null) currentStepByInstanceId[instance.Id] = step;
            }

            var stepIds = currentStepByInstanceId.Values.Select(s => s.Id).Distinct().ToList();
            var assignedStepIds = stepIds.Count == 0
                ? []
                : (await _db.WorkflowInstanceStepAssigneeList
                    .Where(a => stepIds.Contains(a.WorkflowInstanceStepId) && a.UserId == currentUserId)
                    .Select(a => a.WorkflowInstanceStepId)
                    .ToListAsync(ct)).ToHashSet();

            var result = new Dictionary<int, WorkflowBatchEntry>();
            foreach (var group in instances.GroupBy(i => i.EntityRecordId))
            {
                var active = group.Where(i => i.Status == "InProgress").OrderByDescending(i => i.Id).FirstOrDefault();
                var latest = group.OrderByDescending(i => i.Id).First();

                string? stepName = null;
                var canAct = false;
                if (active != null && currentStepByInstanceId.TryGetValue(active.Id, out var step))
                {
                    stepName = step.Name;
                    canAct = assignedStepIds.Contains(step.Id);
                }

                result[group.Key] = new WorkflowBatchEntry(active, latest, stepName, canAct);
            }
            return result;
        }

        /// <summary>Batch-driven equivalent of ReconcileAsync. Returns true if pr was modified (caller
        /// batches the SaveChangesAsync call once for the whole list rather than once per row).</summary>
        private async Task<bool> ReconcileFromBatchAsync(PurchaseRequestList pr, WorkflowBatchEntry? entry, int currentUserId, CancellationToken ct)
        {
            if (entry?.Active != null)
            {
                if (pr.OverallStatus != PurchaseRequestStatus.PendingApproval)
                {
                    pr.OverallStatus = PurchaseRequestStatus.PendingApproval;
                    pr.UpdateDate = DateTime.Now;
                    pr.UpdateMachine = Environment.MachineName;
                    pr.UpdateBy = currentUserId;
                    return true;
                }
                return false;
            }

            if (pr.OverallStatus != PurchaseRequestStatus.PendingApproval) return false;

            var instance = entry?.Latest;
            if (instance is null || instance.Status == "InProgress") return false;

            if (instance.Status == "Approved")
            {
                pr.OverallStatus = PurchaseRequestStatus.Approved;
                pr.ApprovedBy = instance.UpdateBy;
                pr.ApprovedDate = instance.CompletedDate;
            }
            else if (instance.Status == "Rejected")
            {
                pr.OverallStatus = PurchaseRequestStatus.Rejected;
                // Only reached once per record, right at the moment its status actually flips - not a
                // per-row cost for every already-settled record, so a direct query here is fine.
                pr.RejectReason = (await _db.WorkflowInstanceHistoryList
                    .Where(h => h.WorkflowInstanceId == instance.Id)
                    .OrderByDescending(h => h.Id)
                    .FirstOrDefaultAsync(ct))?.Comment;
            }
            else
            {
                return false; // unknown/unexpected status - leave the PR untouched rather than guess
            }

            pr.UpdateDate = DateTime.Now;
            pr.UpdateMachine = Environment.MachineName;
            pr.UpdateBy = currentUserId;
            return true;
        }

        /// <summary>Batch-driven equivalent of ToDtoAsync(includeLines: false) - used only by
        /// GetAllAsync, which never needs line items in the list view (GetByIdAsync still uses
        /// ToDtoAsync below for the detail view).</summary>
        private PurchaseRequestDto ToDtoFromBatch(PurchaseRequestList pr, Lookups lookups, WorkflowBatchEntry? entry, int currentUserId)
        {
            var canAct = pr.OverallStatus == PurchaseRequestStatus.PendingApproval && pr.CreatedBy != currentUserId && (entry?.CanAct ?? false);

            var statusDisplay = pr.OverallStatus == PurchaseRequestStatus.PendingApproval && !string.IsNullOrWhiteSpace(entry?.CurrentStepName)
                ? $"تحت إجراء {entry!.CurrentStepName}"
                : PurchaseRequestStatus.ToDisplay(pr.OverallStatus);

            return new PurchaseRequestDto
            {
                Id = pr.Id,
                Num = pr.Num,
                FormattedNum = pr.Num is int n ? $"{n}/{pr.RequestDate?.Year}" : null,
                PrjId = pr.PrjId,
                ProjectName = pr.PrjId is int prjId ? lookups.Projects.GetValueOrDefault(prjId) : null,
                DeptId = pr.DeptId,
                DepartmentName = pr.DeptId is int deptId ? lookups.Departments.GetValueOrDefault(deptId) : null,
                StoreId = pr.StoreId,
                StoreName = pr.StoreId is int storeId ? lookups.Stores.GetValueOrDefault(storeId) : null,
                DisciplineId = pr.DisciplineId,
                DisciplineName = pr.DisciplineId is int discId ? lookups.Disciplines.GetValueOrDefault(discId) : null,
                RequestDate = pr.RequestDate,
                RequiredDate = pr.RequiredDate,
                Purpose = pr.Purpose,
                Priority = pr.Priority,
                Type = pr.Type,
                OverallStatus = pr.OverallStatus,
                StatusDisplay = statusDisplay,
                DeliveryStatus = pr.DeliveryStatus,
                ApprovedBy = pr.ApprovedBy,
                ApprovedByName = pr.ApprovedBy is int apId ? lookups.Users.GetValueOrDefault(apId) : null,
                ApprovedDate = pr.ApprovedDate,
                RejectReason = pr.RejectReason,
                CanCurrentUserAct = canAct,
                Lines = []
            };
        }

        private async Task<string> GetStatusDisplayAsync(PurchaseRequestList pr, CancellationToken ct)
        {
            if (pr.OverallStatus == PurchaseRequestStatus.PendingApproval)
            {
                var instance = await _workflow.GetActiveInstanceAsync(EntityName, pr.Id, ct);
                var stepName = instance != null ? await _workflow.GetCurrentStepNameAsync(instance, ct) : null;
                if (!string.IsNullOrWhiteSpace(stepName))
                    return $"تحت إجراء {stepName}";
            }
            return PurchaseRequestStatus.ToDisplay(pr.OverallStatus);
        }

        private async Task SaveLinesAsync(int prId, List<PurchaseRequestLineSaveRequest> lines, int currentUserId, CancellationToken ct)
        {
            var existingLines = await _db.PurchaseRequestDetails.Where(d => d.PRId == prId).ToListAsync(ct);
            var submittedIds = lines.Where(l => l.Id > 0).Select(l => l.Id).ToHashSet();

            foreach (var removed in existingLines.Where(e => !submittedIds.Contains(e.Id)))
            {
                removed.IsDelete = true;
                removed.DeletionDate = DateTime.Now;
                removed.DeletionMachine = Environment.MachineName;
                removed.DeletionBy = currentUserId;
            }

            int sort = 1;
            foreach (var line in lines)
            {
                var existing = line.Id > 0 ? existingLines.FirstOrDefault(e => e.Id == line.Id) : null;
                if (existing != null)
                {
                    ApplyLine(line, existing);
                    existing.SortId = sort;
                    existing.Num = sort;
                    existing.UpdateDate = DateTime.Now;
                    existing.UpdateMachine = Environment.MachineName;
                    existing.UpdateBy = currentUserId;
                }
                else
                {
                    var entity = new PurchaseRequestDetails { PRId = prId, IsDelete = false };
                    ApplyLine(line, entity);
                    entity.SortId = sort;
                    entity.Num = sort;
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedMachine = Environment.MachineName;
                    entity.CreatedBy = currentUserId;
                    _db.PurchaseRequestDetails.Add(entity);
                }
                sort++;
            }

            await _db.SaveChangesAsync(ct);
        }

        private static void ApplyLine(PurchaseRequestLineSaveRequest request, PurchaseRequestDetails entity)
        {
            entity.ItemId = request.ItemId;
            entity.Description = request.Description;
            entity.Qty = request.Qty;
            entity.UnitId = request.UnitId;
            entity.CCId = request.CCId;
            entity.BdgId = request.BdgId;
            entity.Note = request.Note;
            entity.SupplierManufacturer = request.SupplierManufacturer;
        }

        private static void Apply(PurchaseRequestSaveRequest request, PurchaseRequestList entity)
        {
            entity.PrjId = request.PrjId;
            entity.DeptId = request.DeptId;
            entity.StoreId = request.StoreId;
            entity.DisciplineId = request.DisciplineId;
            entity.RequestDate = request.RequestDate;
            entity.RequiredDate = request.RequiredDate;
            entity.Purpose = request.Purpose;
            entity.Priority = request.Priority ?? "عادي";
            entity.Type = request.Type ?? "المواد";
        }

        private sealed record Lookups(
            Dictionary<int, string?> Projects,
            Dictionary<int, string?> Departments,
            Dictionary<int, string?> Stores,
            Dictionary<int, string?> Disciplines,
            Dictionary<int, string?> Users);

        private async Task<Lookups> BuildLookupsAsync(CancellationToken ct) => new(
            await _db.ProjectsList.ToDictionaryAsync(p => p.Id, p => p.Name, ct),
            await _db.DepartmentsList.ToDictionaryAsync(d => d.Id, d => d.Name, ct),
            await _db.StoreList.ToDictionaryAsync(s => s.Id, s => s.Name, ct),
            await _db.DisciplinesList.ToDictionaryAsync(d => d.Id, d => d.Name, ct),
            await _db.UsersList.ToDictionaryAsync(u => u.Id, u => u.FullName, ct));

        private async Task<PurchaseRequestDto> ToDtoAsync(PurchaseRequestList pr, Lookups lookups, int currentUserId, bool includeLines, CancellationToken ct)
        {
            var canAct = false;
            if (pr.OverallStatus == PurchaseRequestStatus.PendingApproval && pr.CreatedBy != currentUserId)
            {
                var instance = await _workflow.GetActiveInstanceAsync(EntityName, pr.Id, ct);
                if (instance != null)
                    canAct = await _workflow.CanUserActAsync(instance.Id, currentUserId, ct);
            }

            var lines = new List<PurchaseRequestLineDto>();
            if (includeLines)
            {
                var details = await _db.PurchaseRequestDetails
                    .Include(d => d.Item)
                    .Include(d => d.Unit)
                    .Include(d => d.CostCenter)
                    .Include(d => d.Budget)
                    .Where(d => d.PRId == pr.Id)
                    .OrderBy(d => d.SortId)
                    .ToListAsync(ct);

                lines = details.Select(l => new PurchaseRequestLineDto
                {
                    Id = l.Id,
                    ItemId = l.ItemId,
                    ItemName = l.Item?.Name,
                    ItemCode = l.Item?.Code,
                    Description = l.Description,
                    Qty = l.Qty,
                    UnitId = l.UnitId,
                    UnitName = l.Unit?.Description,
                    CCId = l.CCId,
                    CostCenterName = l.CostCenter?.Name,
                    BdgId = l.BdgId,
                    BudgetName = l.Budget?.Description,
                    Note = l.Note,
                    SupplierManufacturer = l.SupplierManufacturer
                }).ToList();
            }

            return new PurchaseRequestDto
            {
                Id = pr.Id,
                Num = pr.Num,
                // Simple "number/year" display - the desktop's exact PurchaseRequestPrinter.FormatPRNumber
                // format wasn't ported, this is a reasonable equivalent, not a pixel-match.
                FormattedNum = pr.Num is int n ? $"{n}/{pr.RequestDate?.Year}" : null,
                PrjId = pr.PrjId,
                ProjectName = pr.PrjId is int prjId ? lookups.Projects.GetValueOrDefault(prjId) : null,
                DeptId = pr.DeptId,
                DepartmentName = pr.DeptId is int deptId ? lookups.Departments.GetValueOrDefault(deptId) : null,
                StoreId = pr.StoreId,
                StoreName = pr.StoreId is int storeId ? lookups.Stores.GetValueOrDefault(storeId) : null,
                DisciplineId = pr.DisciplineId,
                DisciplineName = pr.DisciplineId is int discId ? lookups.Disciplines.GetValueOrDefault(discId) : null,
                RequestDate = pr.RequestDate,
                RequiredDate = pr.RequiredDate,
                Purpose = pr.Purpose,
                Priority = pr.Priority,
                Type = pr.Type,
                OverallStatus = pr.OverallStatus,
                StatusDisplay = await GetStatusDisplayAsync(pr, ct),
                DeliveryStatus = pr.DeliveryStatus,
                ApprovedBy = pr.ApprovedBy,
                ApprovedByName = pr.ApprovedBy is int apId ? lookups.Users.GetValueOrDefault(apId) : null,
                ApprovedDate = pr.ApprovedDate,
                RejectReason = pr.RejectReason,
                CanCurrentUserAct = canAct,
                Lines = lines
            };
        }
    }
}
