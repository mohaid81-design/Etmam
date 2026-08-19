namespace Core
{
    // صف عرض غير مخزَّن — سطر واحد في "كارت الصنف" (كشف حركة صنف بمخزن محدد، انظر
    // InventoryReportsHelper.GetItemStockCard)، ليس جدولاً فعلياً في القاعدة.
    public class ItemStockCardRow
    {
        public DateTime? MovementDate { get; set; }

        // نص عربي: "رصيد افتتاحي" / "إذن استلام" / "إذن صرف" / "تحويل وارد" / "تحويل صادر" /
        // "مرتجع صرف" / "مرتجع مشتريات"
        public string? MovementType { get; set; }

        public int DocumentId { get; set; } // = رقم السند الرأسي (ParentId) لهذا السطر
        public string? DocumentNum { get; set; }

        // يُعبَّأ فقط لسطور التحويل — اسم المخزن الآخر (المصدر أو الوجهة حسب اتجاه الحركة)
        public string? CounterpartyStoreName { get; set; }

        public decimal QtyIn { get; set; }
        public decimal QtyOut { get; set; }
        public decimal RunningBalance { get; set; }
        public string? Note { get; set; }
    }
}
