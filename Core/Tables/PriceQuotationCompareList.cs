using System.ComponentModel.DataAnnotations;

namespace Core
{
    /// <summary>Header for a saved price-quotation comparison ("مقارنة عروض أسعار") for one Purchase
    /// Request: which quotations (PriceQuotationRequestList rows sharing the same PRId) were selected for
    /// side-by-side comparison, so the comparison can be reopened later without re-selecting. The
    /// comparison grid itself is rebuilt at runtime from PurchaseRequestDetails + PriceQuotationRequestDetails —
    /// only the selection is persisted (see PriceQuotationCompareDetails).</summary>
    public class PriceQuotationCompareList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }
        public int? PrjId { get; set; }
        public int? PRId { get; set; }

        // Set automatically at save time when every currently-selected quotation shares the same RFQ
        // envelope (see Core.RFQList) — null when comparing quotations from mixed/no RFQ origin. Purely
        // for traceability/record-keeping; the actual comparison selection is unaffected either way.
        public int? RFQId { get; set; }
        public string? RequestType { get; set; }
        public string? Purpose { get; set; }
        public string? Note { get; set; }

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
        // DatabaseInitializer.GetSqlType. A save against a stale copy throws ConcurrencyConflictException
        // instead of silently overwriting another user's edit.
        public byte[]? RowVersion { get; set; }
    }
}
