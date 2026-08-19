using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// The outbound RFQ "envelope" — item asks (RFQDetails) + invited vendors (RFQVendorList), with NO
    /// pricing (pricing belongs to each vendor's own response). Distinct from
    /// PriceQuotationRequestList, which historically conflated "the ask" and "one vendor's priced
    /// reply" into a single row (StakeholderId + priced details together) — a real RFQ envelope can go
    /// to several vendors, none of whom have quoted yet. New RFQs create this envelope first, then one
    /// PriceQuotationRequestList row per invited vendor once they respond, all sharing this RFQId (see
    /// PriceQuotationRequestList.RFQId).
    /// </summary>
    public class RFQList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }
        public int? PrjId { get; set; }
        public int? PRId { get; set; } // Source Purchase Request (optional — mirrors PriceQuotationRequestList.PRId)
        public DateTime? IssueDate { get; set; }
        public DateTime? RequiredDate { get; set; }  // آخر موعد لتقديم العروض
        public string? Purpose { get; set; }
        public string? Priority { get; set; }
        public string? RequestType { get; set; }      // سلعة / خدمة / مقاولات

        // ─── Contract Terms (الشروط العامة المطلوبة من كل الموردين المدعوين) ───────
        public string? PaymentTerms { get; set; }
        public decimal? ExecutionDuration { get; set; }
        public string? ExecutionDurationUnit { get; set; }
        public decimal? WarrantyDuration { get; set; }
        public string? WarrantyDurationUnit { get; set; }
        public decimal? QuotationValidityPeriod { get; set; }
        public string? QuotationValidityUnit { get; set; }
        public decimal? DailyPenaltyRate { get; set; }
        public decimal? DailyPenaltyMaxPercent { get; set; }
        public decimal? PerformanceBondPercent { get; set; }
        public string? OtherConditions { get; set; }

        public string? Note { get; set; }

        /// Draft / Issued / AwaitingQuotes / QuotesReceived / UnderEvaluation / Completed / Closed / Cancelled — see RFQStatus.
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
