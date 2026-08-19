using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>One amount band within an ApprovalMatrixList — [MinAmount, MaxAmount) routes to
    /// WorkflowDefinitionId, optionally bounded by an effective date range. MaxAmount null means "no
    /// upper bound" (the top band). See Data.ApprovalMatrixService for how these are resolved.</summary>
    public class ApprovalLimitList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(Matrix))]
        public int? MatrixId { get; set; }
        public ApprovalMatrixList? Matrix { get; set; }

        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }

        [ForeignKey(nameof(WorkflowDefinition))]
        public int? WorkflowDefinitionId { get; set; }
        public WorkflowDefinitionList? WorkflowDefinition { get; set; }

        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
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
