namespace Etmam
{
    /// <summary>
    /// Canonical Status values for PurchaseRequestList, in Arabic. Shared by the list grid
    /// (ucPurchaseRequests) and the Add/Edit form (frmPurchaseRequestAddEdit) so both read, write,
    /// and compare the exact same vocabulary — previously each had its own copy (one Arabic, one
    /// English) that silently drifted apart, breaking status guards and coloring.
    /// </summary>
    public static class PurchaseRequestStatus
    {
        public const string Draft           = "تحرير";
        public const string PendingApproval = "قيد الاعتماد";
        public const string Approved        = "معتمد";
        public const string Rejected        = "مرفوض";
        public const string Closed          = "مغلق";
        public const string ConvertedToPO   = "تحوّل لأمر شراء";

        /// <summary>Decorated label for display in grids/menus (e.g. adds a checkmark for Approved).</summary>
        public static string ToDisplay(string? status) => status switch
        {
            Draft           => Draft,
            PendingApproval => PendingApproval,
            Approved        => $"{Approved} ✓",
            Rejected        => $"{Rejected} ✗",
            Closed          => Closed,
            ConvertedToPO   => ConvertedToPO,
            _               => status ?? "—"
        };
    }
}
