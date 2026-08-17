using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class WorkflowInstanceList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(WorkflowDefinition))]
        public int WorkflowDefinitionId { get; set; }
        public WorkflowDefinitionList? WorkflowDefinition { get; set; }

        /// <summary>Name of the Core.Tables entity/table this instance is tracking approval for (e.g. "PurchaseRequestList").</summary>
        public string? EntityName { get; set; }
        public int EntityRecordId { get; set; }

        public int CurrentStepOrder { get; set; }

        /// InProgress / Approved / Rejected
        public string? Status { get; set; }

        [ForeignKey(nameof(StartedByUser))]
        public int StartedBy { get; set; }
        public UsersList? StartedByUser { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

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
