using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class ItemsList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public ItemCategory? Category { get; set; }

        [ForeignKey(nameof(Unit))]
        public int? UnitId { get; set; }
        public Units? Unit { get; set; }

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

        // ─── Not Mapped Stock Summary Fields ─────────────────────────
        [NotMapped] public string? CategoryCode { get; set; }
        [NotMapped] public decimal? LastPrice { get; set; }
        [NotMapped] public decimal? BeginningQty { get; set; }
        [NotMapped] public decimal? PurchasedQty { get; set; }
        [NotMapped] public decimal? PurchaseReturnsQty { get; set; }
        [NotMapped] public decimal? TransfareFromOtherStoreQty { get; set; }
        [NotMapped] public decimal? TransfareToOtherStoreQty { get; set; }
        [NotMapped] public decimal? AddQty { get; set; }
        [NotMapped] public decimal? DeficitSettlementQty { get; set; }
        [NotMapped] public decimal? IssuedQty { get; set; }
        [NotMapped] public decimal? IssuedReturnsQty { get; set; }

        [NotMapped] public decimal? BalanceQty => (BeginningQty ?? 0) + (PurchasedQty ?? 0) - (PurchaseReturnsQty ?? 0) + (TransfareFromOtherStoreQty ?? 0) - (TransfareToOtherStoreQty ?? 0) - (IssuedQty ?? 0) + (IssuedReturnsQty ?? 0) + (AddQty ?? 0) - (DeficitSettlementQty ?? 0);

        [NotMapped] public decimal? PurchasedAmount { get; set; }
        [NotMapped] public decimal? TotalReceivedAmount { get; set; }
        [NotMapped] public decimal? IssuedAmount { get; set; }

        [NotMapped] public decimal? BalanceAmount => (TotalReceivedAmount ?? 0) - (IssuedAmount ?? 0);

        [NotMapped] public decimal? AddSettlementAmount { get; set; }
        [NotMapped] public decimal? AddSettlementQty { get; set; }
        [NotMapped] public decimal? DeficitSettlementAmount { get; set; }
        [NotMapped] public decimal? TotalIssuedQty => (IssuedQty ?? 0) + (TransfareToOtherStoreQty ?? 0);
        [NotMapped] public decimal? TotalReceivedQty => (BeginningQty ?? 0) + (PurchasedQty ?? 0) + (TransfareFromOtherStoreQty ?? 0) + (IssuedReturnsQty ?? 0);
        [NotMapped] public decimal? TransfareFromOtherStoreAmount { get; set; }
        [NotMapped] public decimal? TransfareToOtherStoreAmount { get; set; }
        [NotMapped] public decimal? TotalIssuedAmount => (IssuedAmount ?? 0) + (TransfareToOtherStoreAmount ?? 0);

        // Sorting field used by the grid view (computed/assigned dynamically)
        [NotMapped] public int IdSort { get; set; }
    }
}
