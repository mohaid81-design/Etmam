using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Whether a Purchase Request's header/items are locked from further editing — once at least one
    /// Purchase Order has been created from it (via frmPurchaseRequestAddEdit.ConvertToPO or by manually
    /// picking the request in frmPurchaseOrderAddEdit), its lines are the source of truth for procurement
    /// and must not be silently changed underneath the PO. Shared by frmPurchaseRequestAddEdit (header/grid
    /// lock) and ucPurchaseRequests (bbiEdit/bbiDelete enablement) so both use the exact same rule.
    /// </summary>
    public static class PurchaseRequestLock
    {
        public static bool IsLocked(DataContext dc, PurchaseRequestList pr) =>
            dc.PurchaseOrderList.GetBy("PRId = @id AND IsDelete = 0", new { id = pr.Id }).Any();
    }
}
