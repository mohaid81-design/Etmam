using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Technical evaluation of one vendor's quotation (PriceQuotationRequestList) — independent of, and
    /// evaluated before, its commercial ranking (see PriceQuotationCompareList for that). A rejected
    /// technical evaluation blocks that quotation from being awarded (see the methodology doc's Bid
    /// Comparison/Award sections) unless an explicit, archived override policy exists — no such policy
    /// is implemented yet, so Rejected is currently an absolute block, enforced by whatever screen builds
    /// the Award Recommendation later, not here.
    /// </summary>
    public class TechnicalEvaluationList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        // Convenience/traceability back to the RFQ envelope (see Core.RFQList) — not itself load-bearing;
        // PriceQuotationRequestId below is the actual subject of the evaluation.
        public int? RFQId { get; set; }

        [ForeignKey(nameof(PriceQuotationRequest))]
        public int? PriceQuotationRequestId { get; set; }
        public PriceQuotationRequestList? PriceQuotationRequest { get; set; }

        public DateTime? EvaluationDate { get; set; }

        [ForeignKey(nameof(EvaluatedByUser))]
        public int? EvaluatedBy { get; set; }
        public UsersList? EvaluatedByUser { get; set; }

        /// Approved / ApprovedWithComments / ClarificationRequired / Rejected — see TechnicalEvaluationStatus.
        public string? Status { get; set; }
        public string? OverallComment { get; set; }

        [NotMapped] public string? StatusDisplay { get; set; }

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

        // Optimistic-concurrency token (SQL Server ROWVERSION) — see SqlDataHelper<T> and
        // DatabaseInitializer.GetSqlType.
        public byte[]? RowVersion { get; set; }
    }
}
