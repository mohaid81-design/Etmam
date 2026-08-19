namespace Etmam
{
    /// <summary>Fixed OverallStatus vocabulary for Construction Inspection Requests (mirrors Drawings'
    /// convention). Shared by frmCIRAddEdit's status badge and ucCIR's grid display so both use the
    /// exact same codes/labels.</summary>
    public static class CIRStatus
    {
        public const int Draft = 1;
        public const int Submitted = 2;
        public const int Reissued = 3;
        public const int Closed = 4;
        public const int Rejected = 5;
        public const int NeedsRevision = 6;

        // CST (Consultant/Owner) review vocabulary — matches DesignSystem.ApplyStatusColoring's
        // keyword sets and the A/B/C/D checkboxes on rptConstructionInspectionRequest.
        public const string ReviewPending = "قيد المراجعة";
        public const string ReviewApproved = "معتمد";
        public const string ReviewApprovedWithComments = "معتمد مع ملاحظات";
        public const string ReviewRejected = "مرفوض";
        public const string ReviewReviseResubmit = "يتطلب تعديل وإعادة تقديم";

        public static string GetName(int? overallStatus) => overallStatus switch
        {
            Draft => "مسودة",
            Submitted => "مُرسل للمراجعة",
            Reissued => "أُعيد إصداره",
            Closed => "مُغلق",
            Rejected => "مرفوض",
            NeedsRevision => "يتطلب تعديل وإعادة تقديم",
            _ => "مسودة",
        };

        /// <summary>Derives OverallStatus from the CST review decision. Approved/ApprovedWithComments
        /// close the request; Rejected/ReviseResubmit now surface that reply on OverallStatus itself
        /// instead of collapsing back to Submitted (the previous bug — a consultant rejection was
        /// recorded correctly on CSTReviewStatus but the grid's main "حالة طلب الفحص" column kept
        /// showing "مُرسل للمراجعة" because this mapping only special-cased the approved outcome).
        /// Shared by frmCIRAddEdit.SaveRecord and frmCIRAction.ApplyReview so the two save paths can't
        /// drift apart again.</summary>
        public static int MapReviewToOverallStatus(string? reviewStatus) => reviewStatus switch
        {
            ReviewApproved or ReviewApprovedWithComments => Closed,
            ReviewRejected => Rejected,
            ReviewReviseResubmit => NeedsRevision,
            _ => Submitted,
        };
    }
}
