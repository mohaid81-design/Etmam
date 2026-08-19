using System;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Bridges Purchase Orders to the generic workflow engine (Data/WorkflowEngine.cs) — same role for
    /// PurchaseOrderList that PurchaseRequestWorkflowSync plays for PurchaseRequestList (mirror it exactly
    /// when touching this class). Replaces the old single-step PurchaseOrderService-based approval.
    ///
    /// Status sync is pull-based, not push-based: WorkflowEngine.Act() does not know Purchase Orders
    /// exist, so Reconcile() must be called wherever a PO's status is actually displayed
    /// (frmPurchaseOrderAddEdit.LoadRecord, ucPurchaseOrder.LoadData) rather than relying on a callback
    /// fired the instant the workflow instance finishes.
    /// </summary>
    public static class PurchaseOrderWorkflowSync
    {
        // internal (not private): Program.cs's WhatsApp "purchase request fully approved" notification
        // reuses this same name to find the PO procedure's first step's assignees — see
        // RegisterOnFullyApproved("PurchaseRequestList", ...).
        internal const string ProcedureName = "أمر الشراء";
        private const string EntityName = "PurchaseOrderList";

        /// <summary>
        /// Starts the approval procedure for this PO. The procedure to use is resolved first from any
        /// configured Approval Matrix (see ApprovalMatrixService — routes by project + PO amount +
        /// today's date, so different amount bands can go through different procedures instead of one
        /// hard-coded name for every PO regardless of value); if no matrix rule matches (the default,
        /// until an admin configures one), falls back to the single named "أمر الشراء" procedure exactly
        /// as before. Throws (with an Arabic message safe to show directly to the user) if neither
        /// resolves to a real procedure, or if this PO already has an active instance (guards against a
        /// double-click/retry creating a duplicate InProgress row).
        /// </summary>
        public static void SendForApproval(DataContext dc, PurchaseOrderList po)
        {
            var resolvedId = ApprovalMatrixService.ResolveWorkflowDefinitionId(
                dc, EntityName, po.PrjId, po.Amount ?? 0, DateTime.Today);

            var def = resolvedId.HasValue
                ? dc.WorkflowDefinitionList.Find(resolvedId.Value)
                : dc.WorkflowDefinitionList.GetBy("Name = @n AND IsDelete = 0", new { n = ProcedureName }).FirstOrDefault();

            if (def == null)
                throw new InvalidOperationException(
                    $"لم يتم تعريف إجراء الاعتماد \"{ProcedureName}\" بعد. يرجى تعريفه من شاشة \"إدارة الإجراءات\" أولاً.");

            if (GetActiveInstance(dc, po.Id) != null)
                throw new InvalidOperationException("يوجد بالفعل إجراء اعتماد جارٍ لهذا الأمر.");

            WorkflowEngine.StartWorkflow(def.Id, EntityName, po.Id, Session.CurrentUser?.Id ?? 1);
        }

        /// <summary>The PO's currently running (InProgress) workflow instance, if any.</summary>
        public static WorkflowInstanceList? GetActiveInstance(DataContext dc, int poId) =>
            dc.WorkflowInstanceList
              .GetBy("EntityName = @n AND EntityRecordId = @id AND Status = 'InProgress'",
                     new { n = EntityName, id = poId })
              .FirstOrDefault();

        /// <summary>Display name of the step a running instance is currently sitting at.</summary>
        public static string? GetCurrentStepName(DataContext dc, WorkflowInstanceList instance) =>
            dc.WorkflowStepList
              .GetBy("WorkflowDefinitionId = @id AND StepOrder = @order",
                     new { id = instance.WorkflowDefinitionId, order = instance.CurrentStepOrder })
              .FirstOrDefault()?.Name;

        /// <summary>Status text for grids: while a PO is mid-approval, names the step it's actually
        /// waiting on instead of the generic "قيد الاعتماد", so the reader can tell who's holding it up
        /// without opening the order.</summary>
        public static string GetStatusDisplay(DataContext dc, PurchaseOrderList po)
        {
            if (po.OverallStatus == PurchaseOrderStatus.PendingApproval)
            {
                var instance = GetActiveInstance(dc, po.Id);
                var stepName = instance != null ? GetCurrentStepName(dc, instance) : null;
                if (!string.IsNullOrWhiteSpace(stepName))
                    return $"تحت إجراء {stepName}";
            }

            return PurchaseOrderStatus.ToDisplay(po.OverallStatus);
        }

        /// <summary>
        /// Keeps PurchaseOrderList.OverallStatus honest against the workflow engine's own tables in both
        /// directions — safe to call unconditionally every time a PO is loaded/displayed:
        /// 1) If there's actually an active (InProgress) instance for this PO but the stored status
        ///    disagrees, corrects it forward to PendingApproval.
        /// 2) Otherwise, if this PO is PendingApproval and its most recent instance has actually finished
        ///    (Approved/Rejected), writes that outcome back onto the PO row.
        /// </summary>
        public static void Reconcile(DataContext dc, PurchaseOrderList po)
        {
            var activeInstance = GetActiveInstance(dc, po.Id);
            if (activeInstance != null)
            {
                if (po.OverallStatus != PurchaseOrderStatus.PendingApproval)
                {
                    po.OverallStatus = PurchaseOrderStatus.PendingApproval;
                    po.UpdateDate = DateTime.Now;
                    po.UpdateMachine = Session.Machine;
                    po.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.PurchaseOrderList.Edit(po.Id, po);
                }
                return;
            }

            if (po.OverallStatus != PurchaseOrderStatus.PendingApproval) return;

            var instance = dc.WorkflowInstanceList
                .GetBy("EntityName = @n AND EntityRecordId = @id", new { n = EntityName, id = po.Id })
                .OrderByDescending(i => i.Id)
                .FirstOrDefault();

            if (instance == null || instance.Status == "InProgress") return;

            if (instance.Status == "Approved")
            {
                po.OverallStatus = PurchaseOrderStatus.Approved;
                po.ApprovedBy = instance.UpdateBy;
                po.ApprovedDate = instance.CompletedDate;

                // Captured once, on first approval only — see PurchaseOrderList.OriginalValue's own
                // summary. A later re-approval (after Return/Resubmit) must never touch it again.
                if (po.OriginalValue is null) po.OriginalValue = po.Amount;
            }
            else if (instance.Status == "Rejected")
            {
                po.OverallStatus = PurchaseOrderStatus.Rejected;
                po.RejectReason = dc.WorkflowInstanceHistoryList
                    .GetBy("WorkflowInstanceId = @id", new { id = instance.Id })
                    .OrderByDescending(h => h.Id)
                    .FirstOrDefault()?.Comment;
            }
            else
            {
                return; // unknown/unexpected status — leave the PO untouched rather than guess
            }

            po.UpdateDate = DateTime.Now;
            po.UpdateMachine = Session.Machine;
            po.UpdateBy = Session.CurrentUser?.Id ?? 1;
            dc.PurchaseOrderList.Edit(po.Id, po);
        }
    }
}
