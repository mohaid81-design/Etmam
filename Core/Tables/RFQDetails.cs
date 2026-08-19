using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>Ask line within an RFQList envelope — item + quantity requested, no pricing (see
    /// RFQList's summary). Linked back to its originating PurchaseRequestDetails rows via
    /// PRRFQLineLink, and referenced by each vendor's priced response via
    /// PriceQuotationRequestDetails.RFQDetailId.</summary>
    public class RFQDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(RFQ))]
        public int? RFQId { get; set; }
        public RFQList? RFQ { get; set; }

        [ForeignKey(nameof(Item))]
        public int? ItemId { get; set; }
        public ItemsList? Item { get; set; }

        public string? Description { get; set; }
        public decimal? Qty { get; set; }

        [ForeignKey(nameof(Unit))]
        public int? UnitId { get; set; }
        public Units? Unit { get; set; }

        public string? Note { get; set; }
        public int? SortId { get; set; }
        public int? Num { get; set; }

        [NotMapped] public string? UnitAbbreviation { get; set; }

        // Populated at load/import time from the corresponding PRRFQLineLink row (the join table is
        // authoritative, not this field) — which Purchase Request line this ask line originated from,
        // and the ceiling (RFQAllocationService.GetAvailableQuantity) the user may set Qty to. Null for
        // a manually-added line with no PR source.
        [NotMapped] public int? SourcePRLineId { get; set; }
        [NotMapped] public decimal? AvailableAtImport { get; set; }

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
