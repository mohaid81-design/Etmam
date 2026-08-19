using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Recommends awarding an RFQ to one vendor's quotation — header-level decision, no line items of
    /// its own (see the methodology doc's Award Recommendation section, whose field list is entirely
    /// header-level). IsLowestBid/TechnicalStatus are snapshots computed at save time
    /// (AwardRecommendationService), not user-entered claims — see that service for exactly how.
    /// </summary>
    public class AwardRecommendationList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }

        [ForeignKey(nameof(RFQ))]
        public int? RFQId { get; set; }
        public RFQList? RFQ { get; set; }

        [ForeignKey(nameof(PriceQuotationRequest))]
        public int? PriceQuotationRequestId { get; set; }
        public PriceQuotationRequestList? PriceQuotationRequest { get; set; }

        public decimal? RecommendedAmount { get; set; }
        public string? RecommendationReason { get; set; }

        // Computed (not user-entered) — see AwardRecommendationService.ComputeIsLowestBid: true iff no
        // other active quotation for the same RFQ has a lower Amount.
        public bool IsLowestBid { get; set; }

        // Mandatory whenever IsLowestBid is false — enforced in frmAwardRecommendationAddEdit.ValidateHeader,
        // not just documented here (see the doc: "IsLowestBid = false → DeviationJustification إلزامي").
        public string? DeviationJustification { get; set; }

        // Snapshot of the recommended quotation's latest TechnicalEvaluationList.Status at the moment
        // this recommendation was saved — copied, not live-joined, so a later re-evaluation can't
        // silently change what this recommendation said it was based on.
        public string? TechnicalStatus { get; set; }

        // Free-text for now ("ضمن الموازنة" / "يتجاوز الموازنة" / ...) — no automated budget-consumption
        // check exists yet in this codebase (BudgetList has no consumption-tracking mechanism), so this
        // is entered by the recommender rather than computed. See Core.BudgetComparisonStatus.
        public string? BudgetStatus { get; set; }

        // Reserved for a future WorkflowEngine.StartWorkflow integration (see AwardRecommendationStatus'
        // own summary) — not populated yet.
        public int? WorkflowInstanceId { get; set; }

        /// Draft / PendingApproval / Approved / Rejected — see AwardRecommendationStatus.
        public string? Status { get; set; }

        [NotMapped] public string? FormattedNum { get; set; }
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
