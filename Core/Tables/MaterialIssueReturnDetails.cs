using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class MaterialIssueReturnDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to MaterialIssueReturnList.Id
        public int? ItemId { get; set; }
        public string? Description { get; set; }
        public int? UnitId { get; set; }
        public decimal? Qty { get; set; }
        public int? CCId { get; set; } // مركز التكلفة — CostCenterList.Id
        public int? BdgId { get; set; } // بند الموازنة التقديرية — BudgetList.Id
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Note { get; set; }

        // حقل عرض غير مخزَّن — كمية هذا الصنف الصادرة من المخزن ولم تُرتجَع بعد (انظر
        // StoreBalanceHelper.ComputeIssuedNotReturnedBalances في frmMaterialIssueReturnAddEdit)
        [NotMapped] public decimal? IssuedQty { get; set; }

        // حقول عرض غير مخزَّنة — تُملأ عند الطباعة فقط (انظر MaterialIssueReturnPrinter)
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
