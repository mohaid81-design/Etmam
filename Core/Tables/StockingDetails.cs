using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class StockingDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to StockingList.Id
        public int? ItemId { get; set; }
        public string? Description { get; set; }
        public int? UnitId { get; set; }

        // رصيد النظام (الدفتري) للصنف بالمخزن وقت الجرد — يُلقَط ويُحفظ عند إضافة السطر، ولا يُعاد
        // حسابه لاحقاً عند إعادة فتح السجل، كي يبقى سجل الجرد شاهداً تاريخياً ثابتاً حتى لو تغيّر
        // رصيد المخزون بعد ذلك بحركات جديدة.
        public decimal? SystemQty { get; set; }

        // الكمية الفعلية المجرودة (العدّ اليدوي الحقيقي بالمخزن)
        public decimal? Qty { get; set; }

        // سعر الوحدة وقت الجرد (آخر سعر استلام مسجَّل لهذا الصنف) — يُلقَط ويُحفظ لنفس سبب SystemQty
        public decimal? UnitPrice { get; set; }

        public string? Note { get; set; }

        // حقول عرض غير مخزَّنة — تُحسَب من الحقول أعلاه عند كل تعديل (انظر RecalculateRow)
        [NotMapped] public decimal? Difference { get; set; }
        [NotMapped] public decimal? DifferenceValue { get; set; }

        // حقول عرض غير مخزَّنة — تُعبَّأ عند التحميل فقط لتقرير الجرد وفروقاته (انظر
        // InventoryReportsHelper.GetStockingVariance)، وليست جزءاً من الكيان الفعلي.
        [NotMapped] public string? StoreName { get; set; }
        [NotMapped] public string? StockingNum { get; set; }
        [NotMapped] public DateTime? StockingDate { get; set; }
        [NotMapped] public string? ItemCode { get; set; }
        [NotMapped] public string? ItemName { get; set; }
        [NotMapped] public string? UnitAbbr { get; set; }

        // حقل عرض غير مخزَّن — يُملأ عند الطباعة فقط لمستند الجرد الفردي (انظر StockingPrinter؛
        // لا يُخلط مع الحقول أعلاه المخصَّصة لتقرير فروقات الجرد الإجمالي)
        [NotMapped] public int? ItemNo { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public int UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
        public int DeletionBy { get; set; }
    }
}
