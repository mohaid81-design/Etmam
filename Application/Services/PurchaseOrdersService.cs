using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Web-side port of Etmam/Gui/ProcurementModule/PurchaseOrder/PurchaseOrderWorkflowSync.cs, scoped
    /// to what the mobile approvals app needs: list, detail, approve, reject. Unlike
    /// PurchaseRequestsService this deliberately has no Create/Update/Delete/Send - Purchase Orders are
    /// still created and sent for approval from the desktop client only; mobile only acts on ones
    /// already in flight. Every status transition below mirrors PurchaseOrderWorkflowSync exactly -
    /// nothing here is new business logic.
    ///
    /// ApproveAsync/RejectAsync deliberately have no project-access check of their own (only
    /// GetAllAsync/GetByIdAsync do, via ProjectAccessService) - see PurchaseRequestsService's own note
    /// on this same split, it applies identically here.
    /// </summary>
    public sealed class PurchaseOrdersService
    {
        private const string EntityName = "PurchaseOrderList";

        private readonly IApplicationDbContext _db;
        private readonly IWorkflowService _workflow;
        private readonly ProjectAccessService _projectAccess;

        public PurchaseOrdersService(IApplicationDbContext db, IWorkflowService workflow, ProjectAccessService projectAccess)
        {
            _db = db;
            _workflow = workflow;
            _projectAccess = projectAccess;
        }

        /// <summary>Batches workflow-instance/step/assignee lookups into a handful of queries instead
        /// of ReconcileAsync/ToDtoAsync's own ~5-8 sequential round-trips PER row - see
        /// PurchaseRequestsService.GetAllAsync's own summary for why (identical rationale, same fix).
        /// GetByIdAsync keeps the simple per-record path since it only pays that cost once. Also
        /// mirrors ucPurchaseOrder.cs's own grid filter: only orders in a project the caller has
        /// UserProjectAccess to are returned.</summary>
        public async Task<List<PurchaseOrderDto>> GetAllAsync(int currentUserId, CancellationToken ct = default)
        {
            var grantedProjectIds = await _projectAccess.GetGrantedProjectIdsAsync(currentUserId, ct);

            var query = _db.PurchaseOrderList.AsQueryable();
            if (grantedProjectIds != null)
                query = query.Where(p => p.PrjId.HasValue && grantedProjectIds.Contains(p.PrjId.Value));

            var pos = await query.OrderByDescending(p => p.OrderDate).ToListAsync(ct);
            var lookups = await BuildLookupsAsync(ct);
            var batch = await LoadWorkflowBatchAsync(pos.Select(p => p.Id).ToList(), currentUserId, ct);

            var dirty = false;
            var result = new List<PurchaseOrderDto>(pos.Count);
            foreach (var po in pos)
            {
                var entry = batch.GetValueOrDefault(po.Id);
                dirty |= await ReconcileFromBatchAsync(po, entry, currentUserId, ct);
                result.Add(ToDtoFromBatch(po, lookups, entry, currentUserId));
            }
            if (dirty) await _db.SaveChangesAsync(ct);
            return result;
        }

        /// <summary>See PurchaseRequestsService.GetByIdAsync's own note on why this check exists here
        /// even though desktop has no equivalent (there, the filtered grid is the only path to a
        /// record; a direct API call needs the same constraint re-created server-side).</summary>
        public async Task<PurchaseOrderDto?> GetByIdAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var po = await _db.PurchaseOrderList.FirstOrDefaultAsync(p => p.Id == id, ct);
            if (po is null) return null;

            var grantedProjectIds = await _projectAccess.GetGrantedProjectIdsAsync(currentUserId, ct);
            if (!ProjectAccessService.CanAccess(grantedProjectIds, po.PrjId)) return null;

            await ReconcileAsync(po, currentUserId, ct);
            var lookups = await BuildLookupsAsync(ct);
            return await ToDtoAsync(po, lookups, currentUserId, includeLines: true, ct);
        }

        /// <summary>Mirrors ActOnWorkflowStep("Approved") equivalent in frmPurchaseOrderAddEdit.</summary>
        public Task ApproveAsync(int id, string? comment, int currentUserId, CancellationToken ct = default) =>
            ActOnCurrentStepAsync(id, "Approved", comment, currentUserId, ct);

        public Task RejectAsync(int id, string? comment, int currentUserId, CancellationToken ct = default) =>
            ActOnCurrentStepAsync(id, "Rejected", comment, currentUserId, ct);

        private async Task ActOnCurrentStepAsync(int id, string action, string? comment, int currentUserId, CancellationToken ct)
        {
            var po = await _db.PurchaseOrderList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Purchase order {id} not found.");

            if (po.CreatedBy == currentUserId)
                throw new InvalidOperationException("لا يمكنك اعتماد أو رفض أمر شراء أنشأته بنفسك.");

            var instance = await _workflow.GetActiveInstanceAsync(EntityName, id, ct)
                ?? throw new InvalidOperationException("لا يوجد إجراء اعتماد جارٍ لهذا الأمر.");

            await _workflow.ActAsync(instance.Id, currentUserId, action, comment, ct);
            await ReconcileAsync(po, currentUserId, ct);
        }

        /// <summary>Mirrors PurchaseOrderWorkflowSync.Reconcile - pull-based sync between
        /// PurchaseOrderList.OverallStatus and the workflow engine's own tables, including the
        /// one-time OriginalValue capture on first approval.</summary>
        private async Task ReconcileAsync(PurchaseOrderList po, int currentUserId, CancellationToken ct)
        {
            var activeInstance = await _workflow.GetActiveInstanceAsync(EntityName, po.Id, ct);
            if (activeInstance != null)
            {
                if (po.OverallStatus != PurchaseOrderStatus.PendingApproval)
                {
                    po.OverallStatus = PurchaseOrderStatus.PendingApproval;
                    po.UpdateDate = DateTime.Now;
                    po.UpdateMachine = Environment.MachineName;
                    po.UpdateBy = currentUserId;
                    await _db.SaveChangesAsync(ct);
                }
                return;
            }

            if (po.OverallStatus != PurchaseOrderStatus.PendingApproval) return;

            var instance = await _workflow.GetLatestInstanceAsync(EntityName, po.Id, ct);
            if (instance is null || instance.Status == "InProgress") return;

            if (instance.Status == "Approved")
            {
                po.OverallStatus = PurchaseOrderStatus.Approved;
                po.ApprovedBy = instance.UpdateBy;
                po.ApprovedDate = instance.CompletedDate;

                // Captured once, on first approval only - see PurchaseOrderList.OriginalValue's own
                // summary. A later re-approval must never touch it again.
                if (po.OriginalValue is null) po.OriginalValue = po.Amount;
            }
            else if (instance.Status == "Rejected")
            {
                po.OverallStatus = PurchaseOrderStatus.Rejected;
                po.RejectReason = (await _db.WorkflowInstanceHistoryList
                    .Where(h => h.WorkflowInstanceId == instance.Id)
                    .OrderByDescending(h => h.Id)
                    .FirstOrDefaultAsync(ct))?.Comment;
            }
            else
            {
                return; // unknown/unexpected status - leave the PO untouched rather than guess
            }

            po.UpdateDate = DateTime.Now;
            po.UpdateMachine = Environment.MachineName;
            po.UpdateBy = currentUserId;
            await _db.SaveChangesAsync(ct);
        }

        private sealed record WorkflowBatchEntry(WorkflowInstanceList? Active, WorkflowInstanceList? Latest, string? CurrentStepName, bool CanAct);

        /// <summary>See PurchaseRequestsService.LoadWorkflowBatchAsync - identical batching, ported
        /// verbatim (there's no shared base class between these services, matching the codebase's
        /// existing per-module-service style).</summary>
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

        /// <summary>Batch-driven equivalent of ReconcileAsync, including the one-time OriginalValue
        /// capture. Returns true if po was modified (caller batches SaveChangesAsync once for the
        /// whole list).</summary>
        private async Task<bool> ReconcileFromBatchAsync(PurchaseOrderList po, WorkflowBatchEntry? entry, int currentUserId, CancellationToken ct)
        {
            if (entry?.Active != null)
            {
                if (po.OverallStatus != PurchaseOrderStatus.PendingApproval)
                {
                    po.OverallStatus = PurchaseOrderStatus.PendingApproval;
                    po.UpdateDate = DateTime.Now;
                    po.UpdateMachine = Environment.MachineName;
                    po.UpdateBy = currentUserId;
                    return true;
                }
                return false;
            }

            if (po.OverallStatus != PurchaseOrderStatus.PendingApproval) return false;

            var instance = entry?.Latest;
            if (instance is null || instance.Status == "InProgress") return false;

            if (instance.Status == "Approved")
            {
                po.OverallStatus = PurchaseOrderStatus.Approved;
                po.ApprovedBy = instance.UpdateBy;
                po.ApprovedDate = instance.CompletedDate;
                if (po.OriginalValue is null) po.OriginalValue = po.Amount;
            }
            else if (instance.Status == "Rejected")
            {
                po.OverallStatus = PurchaseOrderStatus.Rejected;
                po.RejectReason = (await _db.WorkflowInstanceHistoryList
                    .Where(h => h.WorkflowInstanceId == instance.Id)
                    .OrderByDescending(h => h.Id)
                    .FirstOrDefaultAsync(ct))?.Comment;
            }
            else
            {
                return false;
            }

            po.UpdateDate = DateTime.Now;
            po.UpdateMachine = Environment.MachineName;
            po.UpdateBy = currentUserId;
            return true;
        }

        /// <summary>Batch-driven equivalent of ToDtoAsync(includeLines: false).</summary>
        private PurchaseOrderDto ToDtoFromBatch(PurchaseOrderList po, Lookups lookups, WorkflowBatchEntry? entry, int currentUserId)
        {
            var canAct = po.OverallStatus == PurchaseOrderStatus.PendingApproval && po.CreatedBy != currentUserId && (entry?.CanAct ?? false);

            var statusDisplay = po.OverallStatus == PurchaseOrderStatus.PendingApproval && !string.IsNullOrWhiteSpace(entry?.CurrentStepName)
                ? $"تحت إجراء {entry!.CurrentStepName}"
                : PurchaseOrderStatus.ToDisplay(po.OverallStatus);

            return new PurchaseOrderDto
            {
                Id = po.Id,
                Num = po.Num,
                FormattedNum = po.Num is int n ? $"{n}/{po.OrderDate?.Year}" : null,
                PrjId = po.PrjId,
                ProjectName = po.PrjId is int prjId ? lookups.Projects.GetValueOrDefault(prjId) : null,
                StoreId = po.StoreId,
                StoreName = po.StoreId is int storeId ? lookups.Stores.GetValueOrDefault(storeId) : null,
                StakeholderId = po.StakeholderId,
                SupplierName = po.StakeholderId is int stkId ? lookups.Suppliers.GetValueOrDefault(stkId) : null,
                PRId = po.PRId,
                OrderDate = po.OrderDate,
                DeliveryDate = po.DeliveryDate,
                OverallStatus = po.OverallStatus,
                StatusDisplay = statusDisplay,
                ApprovedBy = po.ApprovedBy,
                ApprovedByName = po.ApprovedBy is int apId ? lookups.Users.GetValueOrDefault(apId) : null,
                ApprovedDate = po.ApprovedDate,
                RejectReason = po.RejectReason,
                Amount = po.Amount,
                Description = po.Description,
                PurchaseMethod = po.PurchaseMethod,
                PriorityLevel = po.PriorityLevel,
                CanCurrentUserAct = canAct,
                Lines = []
            };
        }

        private async Task<string> GetStatusDisplayAsync(PurchaseOrderList po, CancellationToken ct)
        {
            if (po.OverallStatus == PurchaseOrderStatus.PendingApproval)
            {
                var instance = await _workflow.GetActiveInstanceAsync(EntityName, po.Id, ct);
                var stepName = instance != null ? await _workflow.GetCurrentStepNameAsync(instance, ct) : null;
                if (!string.IsNullOrWhiteSpace(stepName))
                    return $"تحت إجراء {stepName}";
            }
            return PurchaseOrderStatus.ToDisplay(po.OverallStatus);
        }

        private sealed record Lookups(
            Dictionary<int, string?> Projects,
            Dictionary<int, string?> Stores,
            Dictionary<int, string?> Suppliers,
            Dictionary<int, string?> Users,
            Dictionary<int, (string? Name, string? Code)> Items,
            Dictionary<int, string?> Units);

        private async Task<Lookups> BuildLookupsAsync(CancellationToken ct) => new(
            await _db.ProjectsList.ToDictionaryAsync(p => p.Id, p => p.Name, ct),
            await _db.StoreList.ToDictionaryAsync(s => s.Id, s => s.Name, ct),
            await _db.StakeholdersList.ToDictionaryAsync(s => s.Id, s => s.Name, ct),
            await _db.UsersList.ToDictionaryAsync(u => u.Id, u => u.FullName, ct),
            await _db.ItemsList.ToDictionaryAsync(i => i.Id, i => (i.Name, i.Code), ct),
            await _db.Units.ToDictionaryAsync(u => u.Id, u => u.Description, ct));

        private async Task<PurchaseOrderDto> ToDtoAsync(PurchaseOrderList po, Lookups lookups, int currentUserId, bool includeLines, CancellationToken ct)
        {
            var canAct = false;
            if (po.OverallStatus == PurchaseOrderStatus.PendingApproval && po.CreatedBy != currentUserId)
            {
                var instance = await _workflow.GetActiveInstanceAsync(EntityName, po.Id, ct);
                if (instance != null)
                    canAct = await _workflow.CanUserActAsync(instance.Id, currentUserId, ct);
            }

            var lines = new List<PurchaseOrderLineDto>();
            if (includeLines)
            {
                var details = await _db.PurchaseOrderDetails
                    .Where(d => d.ParentId == po.Id)
                    .ToListAsync(ct);

                lines = details.Select(l => new PurchaseOrderLineDto
                {
                    Id = l.Id,
                    ItemId = l.ItemId,
                    ItemName = l.ItemId is int liId ? lookups.Items.GetValueOrDefault(liId).Name : null,
                    ItemCode = l.ItemId is int liId2 ? lookups.Items.GetValueOrDefault(liId2).Code : null,
                    Description = l.Description,
                    Qty = l.Qty,
                    UnitId = l.UnitId,
                    UnitName = l.UnitId is int luId ? lookups.Units.GetValueOrDefault(luId) : null,
                    UnitPrice = l.UnitPrice,
                    DiscountPercent = l.DiscountPercent,
                    TaxPercent = l.TaxPercent,
                    TotalPrice = l.TotalPrice,
                    TotalWithTax = l.TotalWithTax,
                    Note = l.Note,
                    SupplierManufacturer = l.SupplierManufacturer
                }).ToList();
            }

            return new PurchaseOrderDto
            {
                Id = po.Id,
                Num = po.Num,
                FormattedNum = po.Num is int n ? $"{n}/{po.OrderDate?.Year}" : null,
                PrjId = po.PrjId,
                ProjectName = po.PrjId is int prjId ? lookups.Projects.GetValueOrDefault(prjId) : null,
                StoreId = po.StoreId,
                StoreName = po.StoreId is int storeId ? lookups.Stores.GetValueOrDefault(storeId) : null,
                StakeholderId = po.StakeholderId,
                SupplierName = po.StakeholderId is int stkId ? lookups.Suppliers.GetValueOrDefault(stkId) : null,
                PRId = po.PRId,
                OrderDate = po.OrderDate,
                DeliveryDate = po.DeliveryDate,
                OverallStatus = po.OverallStatus,
                StatusDisplay = await GetStatusDisplayAsync(po, ct),
                ApprovedBy = po.ApprovedBy,
                ApprovedByName = po.ApprovedBy is int apId ? lookups.Users.GetValueOrDefault(apId) : null,
                ApprovedDate = po.ApprovedDate,
                RejectReason = po.RejectReason,
                Amount = po.Amount,
                Description = po.Description,
                PurchaseMethod = po.PurchaseMethod,
                PriorityLevel = po.PriorityLevel,
                CanCurrentUserAct = canAct,
                Lines = lines
            };
        }
    }
}
