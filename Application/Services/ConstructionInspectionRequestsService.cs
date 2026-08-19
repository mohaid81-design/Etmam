using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Web-side port of Etmam/Gui/DocumentsMgt/ConstructionInspectionRequest/CIRWorkflowSync.cs +
    /// frmCIRAddEdit.BtnApproved_ItemClick, scoped to what the mobile approvals app needs: list,
    /// detail, approve. This deliberately covers only the مدير المشروع (Project Manager) approval
    /// gate that CIRWorkflowSync bridges to the generic workflow engine - not the separate CST/
    /// consultant review (frmCIRAction), which never goes through the workflow engine at all and is
    /// out of scope here.
    ///
    /// Two deliberate differences from PurchaseRequestsService/PurchaseOrdersService, both mirroring
    /// desktop exactly rather than introducing new behavior:
    /// - No RejectAsync: frmCIRAddEdit's PM-approval button has no reject action in the desktop client
    ///   (only "اعتماد"), so none is exposed here.
    /// - No self-approval guard: frmCIRAddEdit.BtnApproved_ItemClick does not check
    ///   CreatedBy == currentUser before acting, unlike PurchaseRequestsService/PurchaseOrdersService -
    ///   ported as-is, not a deliberate new security decision.
    ///
    /// ApproveAsync deliberately has no project-access check of its own (only GetAllAsync/GetByIdAsync
    /// do, via ProjectAccessService) - see PurchaseRequestsService's own note on this same split, it
    /// applies identically here.
    /// </summary>
    public sealed class ConstructionInspectionRequestsService
    {
        private const string EntityName = "ConstructionInspectionRequestList";

        private readonly IApplicationDbContext _db;
        private readonly IWorkflowService _workflow;
        private readonly ProjectAccessService _projectAccess;

        public ConstructionInspectionRequestsService(IApplicationDbContext db, IWorkflowService workflow, ProjectAccessService projectAccess)
        {
            _db = db;
            _workflow = workflow;
            _projectAccess = projectAccess;
        }

        /// <summary>Batches workflow-instance/step/assignee lookups into a handful of queries instead
        /// of ResolveApprovalAsync's own ~4-6 sequential round-trips PER row - see
        /// PurchaseRequestsService.GetAllAsync's own summary for why (identical rationale, same fix).
        /// GetByIdAsync keeps the simple per-record path since it only pays that cost once. Also
        /// mirrors ucCIR.cs's own grid filter: only requests in a project the caller has
        /// UserProjectAccess to are returned.</summary>
        public async Task<List<ConstructionInspectionRequestDto>> GetAllAsync(int currentUserId, CancellationToken ct = default)
        {
            var grantedProjectIds = await _projectAccess.GetGrantedProjectIdsAsync(currentUserId, ct);

            var query = _db.ConstructionInspectionRequestList.AsQueryable();
            if (grantedProjectIds != null)
                query = query.Where(c => c.PrjId.HasValue && grantedProjectIds.Contains(c.PrjId.Value));

            var cirs = await query.OrderByDescending(c => c.RequestedDate).ToListAsync(ct);
            var lookups = await BuildLookupsAsync(ct);
            var batch = await LoadWorkflowBatchAsync(cirs.Select(c => c.Id).ToList(), currentUserId, ct);

            var result = new List<ConstructionInspectionRequestDto>(cirs.Count);
            foreach (var cir in cirs)
                result.Add(ToDtoFromBatch(cir, lookups, batch.GetValueOrDefault(cir.Id)));
            return result;
        }

        /// <summary>See PurchaseRequestsService.GetByIdAsync's own note on why this check exists here
        /// even though desktop has no equivalent (there, the filtered grid is the only path to a
        /// record; a direct API call needs the same constraint re-created server-side).</summary>
        public async Task<ConstructionInspectionRequestDto?> GetByIdAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var cir = await _db.ConstructionInspectionRequestList.FirstOrDefaultAsync(c => c.Id == id, ct);
            if (cir is null) return null;

            var grantedProjectIds = await _projectAccess.GetGrantedProjectIdsAsync(currentUserId, ct);
            if (!ProjectAccessService.CanAccess(grantedProjectIds, cir.PrjId)) return null;

            var lookups = await BuildLookupsAsync(ct);
            return await ToDtoAsync(cir, lookups, currentUserId, ct);
        }

        /// <summary>Mirrors the "act on the current step" branch of
        /// frmCIRAddEdit.BtnApproved_ItemClick - only reachable once an active instance already
        /// exists (started from desktop), matching how mobile only acts on CIRs already in flight.</summary>
        public async Task ApproveAsync(int id, string? comment, int currentUserId, CancellationToken ct = default)
        {
            var cir = await _db.ConstructionInspectionRequestList.FirstOrDefaultAsync(c => c.Id == id, ct)
                ?? throw new KeyNotFoundException($"Construction inspection request {id} not found.");

            var instance = await _workflow.GetActiveInstanceAsync(EntityName, id, ct)
                ?? throw new InvalidOperationException("لا يوجد إجراء اعتماد جارٍ لهذا الطلب.");

            await _workflow.ActAsync(instance.Id, currentUserId, "Approved", comment, ct);
        }

        // Status tokens deliberately reuse PurchaseRequestStatus/PurchaseOrderStatus's Arabic
        // vocabulary (rather than English "PendingApproval"/"Approved"/... tokens) purely so the
        // mobile app's shared StatusChip widget - which colors a chip by matching these exact Arabic
        // strings - renders CIR chips consistently with Purchase Requests/Orders. "لم يُرسل للاعتماد
        // بعد" maps to Draft's grey as the closest conceptual match (CIR has no real "draft" concept
        // of its own here, just "not yet sent for PM approval").
        private async Task<(string Status, string Display, string? ApprovedByName, DateTime? ApprovedDate, bool CanAct)> ResolveApprovalAsync(
            ConstructionInspectionRequestList cir, Dictionary<int, string?> users, int currentUserId, CancellationToken ct)
        {
            var activeInstance = await _workflow.GetActiveInstanceAsync(EntityName, cir.Id, ct);
            if (activeInstance != null)
            {
                var stepName = await _workflow.GetCurrentStepNameAsync(activeInstance, ct);
                var display = !string.IsNullOrWhiteSpace(stepName) ? $"تحت إجراء {stepName}" : PurchaseRequestStatus.PendingApproval;
                var canAct = await _workflow.CanUserActAsync(activeInstance.Id, currentUserId, ct);
                return (PurchaseRequestStatus.PendingApproval, display, null, null, canAct);
            }

            var latest = await _workflow.GetLatestInstanceAsync(EntityName, cir.Id, ct);
            if (latest is null)
                return (PurchaseRequestStatus.Draft, "لم يُرسل للاعتماد بعد", null, null, false);

            if (latest.Status == "Approved")
                return (PurchaseRequestStatus.Approved, PurchaseRequestStatus.ToDisplay(PurchaseRequestStatus.Approved),
                    latest.UpdateBy is int uid ? users.GetValueOrDefault(uid) : null, latest.CompletedDate, false);

            if (latest.Status == "Rejected")
                return (PurchaseRequestStatus.Rejected, PurchaseRequestStatus.ToDisplay(PurchaseRequestStatus.Rejected), null, null, false);

            return (PurchaseRequestStatus.Draft, "لم يُرسل للاعتماد بعد", null, null, false); // unknown/unexpected - don't guess
        }

        private sealed record WorkflowBatchEntry(WorkflowInstanceList? Active, WorkflowInstanceList? Latest, string? CurrentStepName, bool CanAct);

        /// <summary>See PurchaseRequestsService.LoadWorkflowBatchAsync - identical batching, ported
        /// verbatim.</summary>
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

        /// <summary>Batch-driven equivalent of ToDtoAsync/ResolveApprovalAsync - read-only (CIR has no
        /// status column to reconcile/write back, unlike PurchaseRequestsService/PurchaseOrdersService;
        /// see ResolveApprovalAsync's own summary).</summary>
        private ConstructionInspectionRequestDto ToDtoFromBatch(ConstructionInspectionRequestList cir, Lookups lookups, WorkflowBatchEntry? entry)
        {
            string status, display;
            string? approvedByName = null;
            DateTime? approvedDate = null;
            var canAct = false;

            if (entry?.Active != null)
            {
                status = PurchaseRequestStatus.PendingApproval;
                display = !string.IsNullOrWhiteSpace(entry.CurrentStepName) ? $"تحت إجراء {entry.CurrentStepName}" : PurchaseRequestStatus.PendingApproval;
                canAct = entry.CanAct;
            }
            else if (entry?.Latest is { Status: "Approved" } latestApproved)
            {
                status = PurchaseRequestStatus.Approved;
                display = PurchaseRequestStatus.ToDisplay(PurchaseRequestStatus.Approved);
                approvedByName = latestApproved.UpdateBy is int uid ? lookups.Users.GetValueOrDefault(uid) : null;
                approvedDate = latestApproved.CompletedDate;
            }
            else if (entry?.Latest is { Status: "Rejected" })
            {
                status = PurchaseRequestStatus.Rejected;
                display = PurchaseRequestStatus.ToDisplay(PurchaseRequestStatus.Rejected);
            }
            else
            {
                status = PurchaseRequestStatus.Draft;
                display = "لم يُرسل للاعتماد بعد";
            }

            return new ConstructionInspectionRequestDto
            {
                Id = cir.Id,
                Num = cir.Num,
                RegisterNo = cir.RegisterNo,
                Rev = cir.Rev,
                FormattedNum = !string.IsNullOrWhiteSpace(cir.RegisterNo) ? cir.RegisterNo : (cir.Num is int n ? $"CIR-{n:D3}-R{cir.Rev ?? 0}" : null),
                PrjId = cir.PrjId,
                ProjectName = cir.PrjId is int prjId ? lookups.Projects.GetValueOrDefault(prjId) : null,
                DisciplineId = cir.DisciplineId,
                DisciplineName = cir.DisciplineId is int discId ? lookups.Disciplines.GetValueOrDefault(discId) : null,
                Description = cir.Description,
                Location = cir.Location,
                BOQRef = cir.BOQRef,
                DWGRef = cir.DWGRef,
                MSRef = cir.MSRef,
                SpecRef = cir.SpecRef,
                RequestedDate = cir.RequestedDate,
                ApprovalStatus = status,
                StatusDisplay = display,
                ApprovedByName = approvedByName,
                ApprovedDate = approvedDate,
                CanCurrentUserAct = canAct
            };
        }

        private sealed record Lookups(
            Dictionary<int, string?> Projects,
            Dictionary<int, string?> Disciplines,
            Dictionary<int, string?> Users);

        private async Task<Lookups> BuildLookupsAsync(CancellationToken ct) => new(
            await _db.ProjectsList.ToDictionaryAsync(p => p.Id, p => p.Name, ct),
            await _db.DisciplinesList.ToDictionaryAsync(d => d.Id, d => d.Name, ct),
            await _db.UsersList.ToDictionaryAsync(u => u.Id, u => u.FullName, ct));

        private async Task<ConstructionInspectionRequestDto> ToDtoAsync(ConstructionInspectionRequestList cir, Lookups lookups, int currentUserId, CancellationToken ct)
        {
            var (status, display, approvedByName, approvedDate, canAct) = await ResolveApprovalAsync(cir, lookups.Users, currentUserId, ct);

            return new ConstructionInspectionRequestDto
            {
                Id = cir.Id,
                Num = cir.Num,
                RegisterNo = cir.RegisterNo,
                Rev = cir.Rev,
                // Simple fallback display - the desktop's exact CIRNumberFormatter format
                // ("CIR-{DisciplineCode}-{Num:D3}-R{Rev}") depends on discipline codes not loaded
                // here; this is a reasonable equivalent, not a pixel-match.
                FormattedNum = !string.IsNullOrWhiteSpace(cir.RegisterNo) ? cir.RegisterNo : (cir.Num is int n ? $"CIR-{n:D3}-R{cir.Rev ?? 0}" : null),
                PrjId = cir.PrjId,
                ProjectName = cir.PrjId is int prjId ? lookups.Projects.GetValueOrDefault(prjId) : null,
                DisciplineId = cir.DisciplineId,
                DisciplineName = cir.DisciplineId is int discId ? lookups.Disciplines.GetValueOrDefault(discId) : null,
                Description = cir.Description,
                Location = cir.Location,
                BOQRef = cir.BOQRef,
                DWGRef = cir.DWGRef,
                MSRef = cir.MSRef,
                SpecRef = cir.SpecRef,
                RequestedDate = cir.RequestedDate,
                ApprovalStatus = status,
                StatusDisplay = display,
                ApprovedByName = approvedByName,
                ApprovedDate = approvedDate,
                CanCurrentUserAct = canAct
            };
        }
    }
}
