using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>One vendor invited to quote against an RFQList envelope. A vendor's actual priced
    /// response is a separate PriceQuotationRequestList row (with RFQId set to the same envelope) —
    /// this row only records the invitation itself, independent of whether/when that vendor responds.</summary>
    public class RFQVendorList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(RFQ))]
        public int? RFQId { get; set; }
        public RFQList? RFQ { get; set; }

        [ForeignKey(nameof(Stakeholder))]
        public int? StakeholderId { get; set; }
        public StakeholdersList? Stakeholder { get; set; }

        public DateTime? InvitedDate { get; set; }

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
