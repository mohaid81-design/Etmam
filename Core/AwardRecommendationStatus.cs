namespace Core
{
    /// <summary>
    /// Canonical Status values for AwardRecommendationList, in Arabic. Mirrors PurchaseOrderStatus so
    /// status vocabularies stay recognizable across the Procurement module. No workflow-engine
    /// integration yet (see AwardRecommendationList.WorkflowInstanceId) — Status is a flat field for now,
    /// same as PriceQuotationRequestList/RFQList before any procedure exists to drive them.
    /// </summary>
    public static class AwardRecommendationStatus
    {
        public const string Draft           = "مسودة";
        public const string PendingApproval = "قيد الاعتماد";
        public const string Approved        = "معتمد";
        public const string Rejected        = "مرفوض";

        public static string ToDisplay(string? status) => status switch
        {
            Draft           => Draft,
            PendingApproval => PendingApproval,
            Approved        => $"{Approved} ✓",
            Rejected        => $"{Rejected} ✗",
            _               => status ?? "—"
        };
    }
}
