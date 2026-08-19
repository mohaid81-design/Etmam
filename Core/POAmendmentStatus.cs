namespace Core
{
    /// <summary>
    /// Canonical Status values for POAmendmentList, in Arabic. Mirrors PurchaseOrderStatus. An amendment
    /// becomes read-only once Approved (see POAmendmentService.IsEditable) — same "approved = locked"
    /// principle the doc applies to the Purchase Order itself.
    /// </summary>
    public static class POAmendmentStatus
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
