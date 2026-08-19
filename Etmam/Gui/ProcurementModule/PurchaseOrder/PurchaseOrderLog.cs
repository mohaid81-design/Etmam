using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Builds the read-only approval-history text for a Purchase Order from its own header/audit fields.
    /// Now that PO approval routes through the generic workflow engine (see PurchaseOrderWorkflowSync),
    /// the full step-by-step history actually lives in WorkflowInstanceHistoryList — this class doesn't
    /// render that yet (kept minimal, matching its pre-migration scope); a future pass could enrich it the
    /// way frmPurchaseRequestLog does for Purchase Requests. Shared by frmPurchaseOrderAddEdit's
    /// "سجل الموافقات" tab and ucPurchaseOrder's colLog quick-view button so both show the same text.
    /// </summary>
    public static class PurchaseOrderLog
    {
        public static string BuildLogText(DataContext dc, PurchaseOrderList po)
        {
            var lines = new List<string>
            {
                $"• أُنشئ بواسطة: {dc.UsersList.Find(po.CreatedBy)?.FullName ?? "—"} بتاريخ {po.CreatedDate:yyyy-MM-dd HH:mm}"
            };

            if (po.UpdateDate.HasValue)
                lines.Add($"• آخر تعديل بواسطة: {dc.UsersList.Find(po.UpdateBy)?.FullName ?? "—"} بتاريخ {po.UpdateDate:yyyy-MM-dd HH:mm}");

            if (po.OverallStatus == PurchaseOrderStatus.PendingApproval)
                lines.Add("• الحالة الحالية: قيد الاعتماد");

            if (po.ApprovedDate.HasValue)
                lines.Add($"• تم الاعتماد بواسطة: {dc.UsersList.Find(po.ApprovedBy ?? 0)?.FullName ?? "—"} بتاريخ {po.ApprovedDate:yyyy-MM-dd HH:mm}");

            if (po.OverallStatus == PurchaseOrderStatus.Rejected)
                lines.Add($"• تم الرفض. السبب: {po.RejectReason}");

            return string.Join(Environment.NewLine, lines);
        }
    }
}
