using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class PurchaseRequestDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(PurchaseRequest))]
        public int? PRId { get; set; }
        public PurchaseRequestList? PurchaseRequest { get; set; }

        public int? PrjId { get; set; }

        [ForeignKey(nameof(Item))]
        public int? ItemId { get; set; }
        public ItemsList? Item { get; set; }

        public string? Description { get; set; }
        public decimal? Qty { get; set; }

        [ForeignKey(nameof(Unit))]
        public int? UnitId { get; set; }
        public Units? Unit { get; set; }

        [ForeignKey(nameof(CostCenter))]
        public int? CCId { get; set; }
        public CostCenterList? CostCenter { get; set; }

        [ForeignKey(nameof(Budget))]
        public int? BdgId { get; set; }
        public BudgetList? Budget { get; set; }

        public string? Note { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))]
        public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }

        [ForeignKey(nameof(Update))]
        public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }

        [ForeignKey(nameof(Deletion))]
        public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }
    }
}
