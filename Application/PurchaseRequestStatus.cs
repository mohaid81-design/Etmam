namespace Application
{
    /// <summary>Web-side port of Etmam.PurchaseRequestStatus - same Arabic vocabulary, so a request
    /// saved from the web reads identically in the desktop client and vice versa.</summary>
    public static class PurchaseRequestStatus
    {
        public const string Draft = "مسودة";
        public const string PendingApproval = "قيد الاعتماد";
        public const string Approved = "معتمد";
        public const string Rejected = "مرفوض";
        public const string Closed = "مغلق";

        public static string ToDisplay(string? status) => status switch
        {
            Draft => Draft,
            PendingApproval => PendingApproval,
            Approved => $"{Approved} ✓",
            Rejected => $"{Rejected} ✗",
            Closed => Closed,
            _ => status ?? "—"
        };
    }
}
