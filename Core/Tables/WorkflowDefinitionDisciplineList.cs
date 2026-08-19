using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>Which disciplines a WorkflowDefinitionList procedure applies to — no rows for a given
    /// WorkflowDefinitionId means "عام" (applies to every discipline), mirroring how a null ProjectId on
    /// WorkflowDefinitionList itself means "every project". See
    /// PurchaseRequestWorkflowSync.GetAvailableProcedures for how this is consumed.</summary>
    public class WorkflowDefinitionDisciplineList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(WorkflowDefinition))]
        public int WorkflowDefinitionId { get; set; }
        public WorkflowDefinitionList? WorkflowDefinition { get; set; }

        [ForeignKey(nameof(Discipline))]
        public int DisciplineId { get; set; }
        public DisciplinesList? Discipline { get; set; }

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
