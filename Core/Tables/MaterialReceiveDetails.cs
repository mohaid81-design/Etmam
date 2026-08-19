using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class MaterialReceiveDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to MaterialReceiveList.Id
        public int? PODetailId { get; set; } // PurchaseOrderDetails.Id — set when this line is imported from a Purchase Order (see frmMaterialReceiveAddEdit.btnImportFromPO_Click)
        public int? ItemId { get; set; }
        public string? Description { get; set; }
        public int? UnitId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Note { get; set; }

        // حقل عرض غير مخزَّن — الكمية المتبقية (غير المستلمة بعد) في بند أمر الشراء المرتبط (PODetailId)،
        // يُعبَّأ يدوياً عند التحميل/الاستيراد (انظر frmMaterialReceiveAddEdit.PopulatePOQtyDisplay) وليس
        // محسوباً من خصائص هذا الكيان — نفس نمط PurchaseOrderDetails.PRQty.
        [NotMapped]
        public decimal? POQty { get; set; }

        // حقول عرض غير مخزَّنة — تُملأ عند الطباعة فقط (انظر MaterialReceivePrinter)
        [NotMapped] public int? ItemNo { get; set; }
        [NotMapped] public string? UnitAbbreviation { get; set; }

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
