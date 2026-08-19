namespace Core
{
    /// <summary>
    /// Canonical Status values for RFQList, in Arabic. Mirrors PurchaseOrderStatus/PurchaseRequestStatus
    /// so status vocabularies stay recognizable across the Procurement module.
    /// </summary>
    public static class RFQStatus
    {
        public const string Draft            = "مسودة";
        public const string Issued           = "صادر";
        public const string AwaitingQuotes    = "بانتظار العروض";
        public const string QuotesReceived   = "تم استلام العروض";
        public const string UnderEvaluation  = "قيد التقييم";
        public const string Completed        = "مكتمل";
        public const string Closed           = "مغلق";
        public const string Cancelled        = "ملغى";

        public static string ToDisplay(string? status) => status switch
        {
            Draft            => Draft,
            Issued           => Issued,
            AwaitingQuotes   => AwaitingQuotes,
            QuotesReceived   => QuotesReceived,
            UnderEvaluation  => UnderEvaluation,
            Completed        => $"{Completed} ✓",
            Closed           => Closed,
            Cancelled        => $"{Cancelled} ✗",
            _                => status ?? "—"
        };
    }
}
