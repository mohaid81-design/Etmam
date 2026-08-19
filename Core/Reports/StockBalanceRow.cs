namespace Core
{
    // صف عرض غير مخزَّن — نتيجة محسوبة لتقرير "رصيد المخزون الحالي" (انظر
    // InventoryReportsHelper.GetCurrentStockBalance)، ليست جدولاً فعلياً في القاعدة.
    public class StockBalanceRow
    {
        public int ItemId { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? UnitId { get; set; }
        public string? UnitAbbr { get; set; }
        public int StoreId { get; set; }
        public string? StoreName { get; set; }
        public decimal Balance { get; set; }
    }
}
