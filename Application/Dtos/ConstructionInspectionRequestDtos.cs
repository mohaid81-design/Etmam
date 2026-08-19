namespace Application.Dtos
{
    public sealed class ConstructionInspectionRequestDto
    {
        public int Id { get; set; }
        public int? Num { get; set; }
        public string? RegisterNo { get; set; }
        public int? Rev { get; set; }
        public string? FormattedNum { get; set; }

        public int? PrjId { get; set; }
        public string? ProjectName { get; set; }
        public int? DisciplineId { get; set; }
        public string? DisciplineName { get; set; }

        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? BOQRef { get; set; }
        public string? DWGRef { get; set; }
        public string? MSRef { get; set; }
        public string? SpecRef { get; set; }

        public DateTime? RequestedDate { get; set; }

        /// <summary>Derived purely from the workflow engine's own instance state - CIR has no stored
        /// column for the PM-approval gate (its own OverallStatus int field is an unrelated document
        /// lifecycle concept: Draft/Submitted/Reissued/Closed). Reuses PurchaseRequestStatus's Arabic
        /// vocabulary (مسودة/قيد الاعتماد/معتمد/مرفوض) purely so the mobile StatusChip widget colors
        /// it consistently with Purchase Requests/Orders - "مسودة" here means "not yet sent for PM
        /// approval", not a real draft state of the CIR itself.</summary>
        public string? ApprovalStatus { get; set; }
        public string? StatusDisplay { get; set; }

        public string? ApprovedByName { get; set; }
        public DateTime? ApprovedDate { get; set; }

        /// <summary>True if the current signed-in user is the assignee of the active workflow step
        /// and may approve it right now. Mirrors PurchaseRequestDto.CanCurrentUserAct.</summary>
        public bool CanCurrentUserAct { get; set; }
    }
}
