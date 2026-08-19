using System.ComponentModel.DataAnnotations;

namespace Core
{
    /// <summary>
    /// Backing store for NumberingService's concurrency-safe "next number" sequences — one row per
    /// series (e.g. "PurchaseRequestList:2026" for a per-year series, or "PriceQuotationRequestList"
    /// for a series with no period). Never read/written directly; always go through
    /// NumberingService.GetNextNumber, which serializes concurrent callers for the same SeriesKey via
    /// sp_getapplock before touching this table, so two users saving at the same instant can never be
    /// handed the same number (the MAX(Num)+1 race this replaces).
    /// </summary>
    public class NumberSeriesCounter
    {
        [Key] public int Id { get; set; }
        public string SeriesKey { get; set; } = string.Empty;
        public int CurrentValue { get; set; }
    }
}
