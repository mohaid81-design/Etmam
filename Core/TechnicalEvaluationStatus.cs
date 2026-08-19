namespace Core
{
    /// <summary>
    /// Canonical Status values for TechnicalEvaluationList, in Arabic — matches the methodology doc's
    /// Technical Evaluation section exactly (Approved / ApprovedWithComments / ClarificationRequired /
    /// Rejected). Mirrors PurchaseOrderStatus/RFQStatus so status vocabularies stay recognizable across
    /// the Procurement module.
    /// </summary>
    public static class TechnicalEvaluationStatus
    {
        public const string Approved              = "معتمد فنياً";
        public const string ApprovedWithComments  = "معتمد فنياً مع ملاحظات";
        public const string ClarificationRequired = "يتطلب توضيح من المورد";
        public const string Rejected              = "مرفوض فنياً";

        public static string ToDisplay(string? status) => status switch
        {
            Approved              => $"{Approved} ✓",
            ApprovedWithComments  => ApprovedWithComments,
            ClarificationRequired => ClarificationRequired,
            Rejected              => $"{Rejected} ✗",
            _                     => status ?? "—"
        };
    }
}
