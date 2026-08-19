namespace Application.Dtos
{
    /// <summary>
    /// Property names intentionally mirror Core.ProjectsList so the WinForms client can
    /// deserialize API responses straight into the existing entity type (its DevExpress grid
    /// bindings and edit-form field mapping already target ProjectsList) without a separate
    /// client-side DTO layer.
    /// </summary>
    public sealed class ProjectDto
    {
        public int Id { get; set; }
        public string? Num { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? Type { get; set; }
        public int? Situation { get; set; }
        public string? ProjectStartDate { get; set; }
        public string? InitialHandover { get; set; }
        public string? FinalHandover { get; set; }
        public DateTime? ContractDate { get; set; }
        public decimal? ContractAmount { get; set; }
        public decimal? AdvancePaymentAmount { get; set; }
        public decimal? AdvancePaymentPercent { get; set; }
        public decimal? RetentionPercent { get; set; }
        public int? CLId { get; set; }
        public int? CSTId { get; set; }
        public string? ClientName { get; set; }
        public string? ConsultantName { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

    public class ProjectSaveRequest
    {
        public string? Num { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CLId { get; set; }
        public int? CSTId { get; set; }
        public DateTime? ContractDate { get; set; }
        public decimal? ContractAmount { get; set; }
        public decimal? AdvancePaymentAmount { get; set; }
        public decimal? AdvancePaymentPercent { get; set; }
        public decimal? RetentionPercent { get; set; }
    }

    public sealed class ProjectCreateRequest : ProjectSaveRequest
    {
    }

    public sealed class ProjectUpdateRequest : ProjectSaveRequest
    {
    }
}
