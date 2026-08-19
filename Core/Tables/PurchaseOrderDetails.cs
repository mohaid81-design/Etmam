using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class PurchaseOrderDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? ParentId { get; set; } // PurchaseOrderList.Id
        public int? PRDetailId { get; set; } // PurchaseRequestDetails.Id — set when this line is imported from a Purchase Request (see frmPurchaseOrderAddEdit.ImportFromPR)
        public int? ItemId { get; set; }
        public string? Description { get; set; }
        public decimal? Qty { get; set; }
        public int? UnitId { get; set; }
        public int? BdgId { get; set; } // بند الموازنة التقديرية — BudgetList.Id
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? TotalPrice { get; set; } // الإجمالي قبل الضريبة = Qty * UnitPrice بعد الخصم
        public string? Note { get; set; }

        // اقتراح حر (نص، بلا ربط بجدول الموردين) لاسم المورد/المصنع المفضّل لهذا البند تحديداً — منفصل عن
        // المورد الفعلي للأمر ككل (PurchaseOrderList.StakeholderId)، إذ قد يختلف مصنع الصنف عن المورد
        // المتعاقد معه لتوريده. انظر أيضاً PurchaseRequestDetails.SupplierManufacturer لنفس الفكرة.
        public string? SupplierManufacturer { get; set; }

        // حقل عرض محسوب غير مخزَّن (الإجمالي شامل الضريبة)، يُعاد حسابه من TotalPrice/TaxPercent عند كل عرض
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public decimal? TotalWithTax => TotalPrice.HasValue
            ? Math.Round(TotalPrice.Value * (1 + (TaxPercent ?? 0) / 100m), 2)
            : null;

        // حقل عرض غير مخزَّن — الكمية المتبقية (غير المطلوبة بعد) في بند طلب الشراء المرتبط (PRDetailId)،
        // يُعبَّأ يدوياً عند التحميل/الاستيراد (انظر frmPurchaseOrderAddEdit.PopulatePRQtyDisplay) وليس محسوباً
        // من خصائص هذا الكيان.
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public decimal? PRQty { get; set; }

        // حقل عرض غير مخزَّن، يُملأ عند الطباعة فقط (انظر PurchaseOrderPrinter.BuildReport) — مرتبط بتقرير
        // rptPurchaseOrderSubReport عبر ExpressionBinding باسم [UnitAbbreviation]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string? UnitAbbreviation { get; set; }

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
