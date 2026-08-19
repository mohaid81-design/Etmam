using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class WorkflowDefinitionList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        /// Which module this procedure applies to — matches the EntityName constant that
        /// module's WorkflowXSync class uses to start/track instances (e.g. "PurchaseRequestList",
        /// "PurchaseOrderList"). Null on procedures created before this field existed; see
        /// PurchaseRequestWorkflowSync.GetAvailableProcedures for the legacy fallback.
        public string? Category { get; set; }

        /// <summary>Restricts this procedure to a single project; null means it applies to every
        /// project. Same convention as ApprovalMatrixList.ProjectId. Only consumed by
        /// PurchaseRequestWorkflowSync.GetAvailableProcedures today (Category="PurchaseRequestList").</summary>
        public int? ProjectId { get; set; }

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
