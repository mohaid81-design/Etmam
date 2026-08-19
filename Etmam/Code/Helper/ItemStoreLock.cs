using System.Linq;
using Data;

namespace Etmam
{
    /// <summary>Determines whether an item or a store already appears in at least one saved (non-deleted)
    /// transactional document — across every module that can reference either. Once true, the corresponding
    /// AddEdit form locks the fields whose meaning is baked into historical documents (an item's unit of
    /// measure changes what past quantities mean; a store's code/name are printed on past vouchers), while
    /// leaving the rest of the record (name/description/category for items, active flag for stores) freely
    /// editable. Same query-on-demand style as PurchaseRequestLock — no caching, always live.</summary>
    public static class ItemStoreLock
    {
        public static bool IsItemUsed(DataContext dc, int itemId)
        {
            var id = itemId;
            return dc.StockingDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any()
                || dc.OpeningBalanceDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any()
                || dc.MaterialReceiveDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any()
                || dc.PurchaseReturnDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any()
                || dc.MaterialTransferDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any()
                || dc.MaterialIssueReturnDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any()
                || dc.MaterialIssuedDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any()
                || dc.PurchaseOrderDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any()
                || dc.PriceQuotationRequestDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any()
                || dc.PurchaseRequestDetails.GetBy("ItemId = @id AND IsDelete = 0", new { id }).Any();
        }

        public static bool IsStoreUsed(DataContext dc, int storeId)
        {
            var id = storeId;
            return dc.StockingList.GetBy("StoreId = @id AND IsDelete = 0", new { id }).Any()
                || dc.OpeningBalanceList.GetBy("StoreId = @id AND IsDelete = 0", new { id }).Any()
                || dc.MaterialTransferList.GetBy("(FromStoreId = @id OR ToStoreId = @id) AND IsDelete = 0", new { id }).Any()
                || dc.MaterialIssueReturnList.GetBy("StoreId = @id AND IsDelete = 0", new { id }).Any()
                || dc.PurchaseReturnList.GetBy("StoreId = @id AND IsDelete = 0", new { id }).Any()
                || dc.MaterialIssuedList.GetBy("StoreId = @id AND IsDelete = 0", new { id }).Any()
                || dc.MaterialReceiveList.GetBy("StoreId = @id AND IsDelete = 0", new { id }).Any()
                || dc.PurchaseOrderList.GetBy("StoreId = @id AND IsDelete = 0", new { id }).Any()
                || dc.PurchaseRequestList.GetBy("StoreId = @id AND IsDelete = 0", new { id }).Any()
                || dc.PriceQuotationRequestList.GetBy("StoreId = @id AND IsDelete = 0", new { id }).Any();
        }
    }
}
