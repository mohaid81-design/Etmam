using System.ComponentModel.DataAnnotations;

namespace Core
{
    /// <summary>
    /// One approval-routing rule set for a document type (see the methodology doc's Approval Matrix
    /// section) — which WorkflowDefinitionList procedure applies is resolved from this + its
    /// ApprovalLimitList rows by (EntityName, Project, Amount, EffectiveDate) at Send-For-Approval time
    /// (see Data.ApprovalMatrixService), instead of a single hard-coded procedure name or a manual
    /// admin picker. ProjectId null means "applies to every project" — a project-specific matrix (see
    /// ApprovalMatrixService's resolution order) takes precedence over the general one when both exist
    /// for the same EntityName.
    /// </summary>
    public class ApprovalMatrixList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        /// Matches Core.Tables entity class names already used as WorkflowInstanceList.EntityName —
        /// e.g. "PurchaseOrderList".
        public string? EntityName { get; set; }

        public int? ProjectId { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public int UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public int DeletionBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
    }
}
