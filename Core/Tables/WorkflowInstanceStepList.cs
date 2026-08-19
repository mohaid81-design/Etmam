using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Frozen copy of one WorkflowStepList row, taken the moment a WorkflowInstanceList starts (see
    /// WorkflowEngine.StartWorkflow) — per the methodology doc: "عند Submit يجب إنشاء Workflow Instance
    /// وInstance Steps كـSnapshot. تغيير Workflow Definition مستقبلًا لا يغير المستندات الجاري اعتمادها."
    /// Once written, never updated even if the live WorkflowStepList row is later renamed, reordered, or
    /// deleted by an admin — the instance keeps resolving its own steps from here, not from
    /// WorkflowStepList, for as long as it runs. Instances started before this table existed have no
    /// rows here at all; WorkflowEngine falls back to resolving those live, exactly as it always did, so
    /// nothing already in progress breaks when this ships.
    /// </summary>
    public class WorkflowInstanceStepList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(WorkflowInstance))]
        public int WorkflowInstanceId { get; set; }
        public WorkflowInstanceList? WorkflowInstance { get; set; }

        public int StepOrder { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

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
