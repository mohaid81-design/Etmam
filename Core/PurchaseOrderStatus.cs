namespace Core
{
    /// <summary>
    /// Canonical Status values for PurchaseOrderList, in Arabic. Mirrors PurchaseRequestStatus so
    /// both status vocabularies stay recognizable across the Procurement module.
    /// </summary>
    public static class PurchaseOrderStatus
    {
        public const string Draft           = "مسودة";
        public const string PendingApproval = "قيد الاعتماد";
        public const string Approved        = "معتمد";
        public const string Rejected        = "مرفوض";
        public const string Closed          = "مغلق";

        public static string ToDisplay(string? status) => status switch
        {
            Draft           => Draft,
            PendingApproval => PendingApproval,
            Approved        => $"{Approved} ✓",
            Rejected        => $"{Rejected} ✗",
            Closed          => Closed,
            _               => status ?? "—"
        };
    }
}
