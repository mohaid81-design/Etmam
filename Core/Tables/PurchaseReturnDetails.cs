using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class PurchaseReturnDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to PurchaseReturnList.Id
        public int? RVDetailId { get; set; } // MaterialReceiveDetails.Id — البند الأصلي بإذن الاستلام
        public int? ItemId { get; set; }
        public string? Description { get; set; }
        public int? UnitId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Note { get; set; }

        // حقل عرض غير مخزَّن — الكمية الأصلية المستلمة لهذا البند بإذن الاستلام (ثابتة، للمقارنة فقط،
        // انظر MaterialReceiveReturnProgress في frmPurchaseReturnAddEdit)
        [NotMapped] public decimal? ReceivedQty { get; set; }

        // حقول عرض غير مخزَّنة — تُملأ عند الطباعة فقط (انظر PurchaseReturnPrinter)
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
