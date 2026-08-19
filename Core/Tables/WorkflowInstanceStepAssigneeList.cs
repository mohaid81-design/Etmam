using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>Frozen copy of one WorkflowStepAssigneeList row, taken alongside its
    /// WorkflowInstanceStepList row at StartWorkflow time — who could act on that snapshotted step,
    /// regardless of assignment changes made to the live WorkflowStepAssigneeList afterward. See
    /// WorkflowInstanceStepList's own summary for the full reasoning.</summary>
    public class WorkflowInstanceStepAssigneeList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(WorkflowInstanceStep))]
        public int WorkflowInstanceStepId { get; set; }
        public WorkflowInstanceStepList? WorkflowInstanceStep { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UsersList? User { get; set; }

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
