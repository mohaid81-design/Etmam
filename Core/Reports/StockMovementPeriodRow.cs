namespace Core
{
    // صف عرض غير مخزَّن — نتيجة محسوبة لتقرير "حركة المخزون خلال فترة" (انظر
    // InventoryReportsHelper.GetStockMovementForPeriod)، ليس جدولاً فعلياً في القاعدة.
    public class StockMovementPeriodRow
    {
        public int ItemId { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? UnitAbbr { get; set; }

        // فارغ عندما يُطلب التقرير مجمَّعاً على مستوى الصنف فقط (perStore = false)
        public int? StoreId { get; set; }
        public string? StoreName { get; set; }

        public decimal OpeningQty { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal IssuedQty { get; set; }
        public decimal TransferInQty { get; set; }
        public decimal TransferOutQty { get; set; }
        public decimal PurchaseReturnQty { get; set; }
        public decimal IssueReturnQty { get; set; }
        public decimal ClosingQty { get; set; }
    }
}
