using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class WorkflowInstanceHistoryList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(WorkflowInstance))]
        public int WorkflowInstanceId { get; set; }
        public WorkflowInstanceList? WorkflowInstance { get; set; }

        [ForeignKey(nameof(WorkflowStep))]
        public int WorkflowStepId { get; set; }
        public WorkflowStepList? WorkflowStep { get; set; }

        [ForeignKey(nameof(ActionByUser))]
        public int ActionBy { get; set; }
        public UsersList? ActionByUser { get; set; }

        /// Approved / Rejected / ReturnedToStep
        public string? Action { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? Comment { get; set; }

        /// Only set when Action == "ReturnedToStep": the StepOrder the instance was sent back to. Lets
        /// report/print code (see PurchaseRequestPrinter.BuildReport) tell which prior "Approved" rows
        /// were invalidated by this return versus ones still standing.
        public int? TargetStepOrder { get; set; }

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
