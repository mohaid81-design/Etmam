using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>Many-to-many link between a Purchase Request line and an RFQ ask line, carrying the
    /// quantity of that PR line committed to this particular RFQ. A single PR line can be split across
    /// several RFQs (partial RFQ quantity), and a single RFQ line can aggregate several PR lines
    /// (combined RFQ). The sum of LinkedQuantity for a given PRLineId, across all non-cancelled RFQs,
    /// must never exceed that PR line's own available quantity (Qty minus what's already ordered via
    /// PurchaseOrderDetails minus what's already linked to other active RFQs) — enforcement belongs to
    /// the CreateRFQFromPRLines use case, not this entity.</summary>
    public class PRRFQLineLink : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(PRLine))]
        public int? PRLineId { get; set; }
        public PurchaseRequestDetails? PRLine { get; set; }

        [ForeignKey(nameof(RFQDetail))]
        public int? RFQDetailId { get; set; }
        public RFQDetails? RFQDetail { get; set; }

        public decimal? LinkedQuantity { get; set; }

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
