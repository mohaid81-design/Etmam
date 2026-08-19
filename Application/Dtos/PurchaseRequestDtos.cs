namespace Application.Dtos
{
    public sealed class PurchaseRequestDto
    {
        public int Id { get; set; }
        public int? Num { get; set; }
        public string? FormattedNum { get; set; }

        public int? PrjId { get; set; }
        public string? ProjectName { get; set; }
        public int? DeptId { get; set; }
        public string? DepartmentName { get; set; }
        public int? StoreId { get; set; }
        public string? StoreName { get; set; }
        public int? DisciplineId { get; set; }
        public string? DisciplineName { get; set; }

        public DateTime? RequestDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string? Purpose { get; set; }
        public string? Priority { get; set; }
        public string? Type { get; set; }

        public string? OverallStatus { get; set; }
        /// <summary>Human-facing status text - while PendingApproval, names the step actually being
        /// waited on (e.g. "تحت إجراء مراجعة مسئول المخزن") instead of the generic label.</summary>
        public string? StatusDisplay { get; set; }
        public string? DeliveryStatus { get; set; }

        public int? ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? RejectReason { get; set; }

        /// <summary>True if the current signed-in user is the assignee of the active workflow
        /// step and may Approve/Reject/Return it right now - computed server-side so the Web layer
        /// never has to re-derive workflow eligibility itself.</summary>
        public bool CanCurrentUserAct { get; set; }

        public List<PurchaseRequestLineDto> Lines { get; set; } = [];
    }

    public sealed class PurchaseRequestLineDto
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }
        public string? Description { get; set; }
        public decimal? Qty { get; set; }
        public int? UnitId { get; set; }
        public string? UnitName { get; set; }
        public int? CCId { get; set; }
        public string? CostCenterName { get; set; }
        public int? BdgId { get; set; }
        public string? BudgetName { get; set; }
        public string? Note { get; set; }
        public string? SupplierManufacturer { get; set; }
    }

    public class PurchaseRequestSaveRequest
    {
        public int? PrjId { get; set; }
        public int? DeptId { get; set; }
        public int? StoreId { get; set; }
        public int? DisciplineId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string? Purpose { get; set; }
        public string? Priority { get; set; }
        public string? Type { get; set; }
        public List<PurchaseRequestLineSaveRequest> Lines { get; set; } = [];
    }

    public sealed class PurchaseRequestLineSaveRequest
    {
        /// <summary>0 (or omitted) for a new line; an existing line's Id to update it. Any existing
        /// line not present in the submitted list is deleted - the Web form always sends the whole
        /// current set of lines, matching the desktop grid's "diff on save" behavior.</summary>
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string? Description { get; set; }
        public decimal? Qty { get; set; }
        public int? UnitId { get; set; }
        public int? CCId { get; set; }
        public int? BdgId { get; set; }
        public string? Note { get; set; }
        public string? SupplierManufacturer { get; set; }
    }

    public sealed class PurchaseRequestCreateRequest : PurchaseRequestSaveRequest
    {
    }

    public sealed class PurchaseRequestUpdateRequest : PurchaseRequestSaveRequest
    {
    }

    public sealed class SendForApprovalRequest
    {
        public int WorkflowDefinitionId { get; set; }
    }

    public sealed class WorkflowActionRequest
    {
        public string? Comment { get; set; }
    }

    public sealed class ReturnToStepRequest
    {
        public int TargetStepOrder { get; set; }
        public string Comment { get; set; } = "";
    }

    public sealed class WorkflowDefinitionDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    /// <summary>One step of a workflow instance's own snapshot, for the "return to step" picker -
    /// every step up to (optionally excluding) the current one.</summary>
    public sealed class WorkflowStepOptionDto
    {
        public int StepOrder { get; set; }
        public string? Name { get; set; }
    }
}
