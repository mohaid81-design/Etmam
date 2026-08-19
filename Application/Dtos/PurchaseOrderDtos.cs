namespace Application.Dtos
{
    public sealed class PurchaseOrderDto
    {
        public int Id { get; set; }
        public int? Num { get; set; }
        public string? FormattedNum { get; set; }

        public int? PrjId { get; set; }
        public string? ProjectName { get; set; }
        public int? StoreId { get; set; }
        public string? StoreName { get; set; }
        public int? StakeholderId { get; set; }
        public string? SupplierName { get; set; }
        public int? PRId { get; set; }
        public string? PRNumber { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public string? OverallStatus { get; set; }
        /// <summary>Human-facing status text - while PendingApproval, names the step actually being
        /// waited on instead of the generic label. Mirrors PurchaseRequestDto.StatusDisplay.</summary>
        public string? StatusDisplay { get; set; }

        public int? ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? RejectReason { get; set; }

        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public string? PurchaseMethod { get; set; }
        public string? PriorityLevel { get; set; }

        /// <summary>True if the current signed-in user is the assignee of the active workflow
        /// step and may Approve/Reject it right now - computed server-side. Mirrors
        /// PurchaseRequestDto.CanCurrentUserAct.</summary>
        public bool CanCurrentUserAct { get; set; }

        public List<PurchaseOrderLineDto> Lines { get; set; } = [];
    }

    public sealed class PurchaseOrderLineDto
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }
        public string? Description { get; set; }
        public decimal? Qty { get; set; }
        public int? UnitId { get; set; }
        public string? UnitName { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? TotalWithTax { get; set; }
        public string? Note { get; set; }
        public string? SupplierManufacturer { get; set; }
    }
}
