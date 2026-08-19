using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class SubcontractList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? SubcontractNo { get; set; }

        [ForeignKey(nameof(Stakeholder))]
        public int? StakeholderId { get; set; } // Subcontractor — see StakeholdersList
        public StakeholdersList? Stakeholder { get; set; }

        public string? ScopeDescription { get; set; }
        public decimal? ContractValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }

        [ForeignKey(nameof(Approver))]
        public int? ApprovedBy { get; set; }
        public UsersList? Approver { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }

        public byte[]? RowVersion { get; set; }
    }

    public class SubcontractBOQDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to SubcontractList.Id

        [ForeignKey(nameof(Item))]
        public int? ItemId { get; set; }
        public ItemsList? Item { get; set; }

        public string? Description { get; set; }

        [ForeignKey(nameof(Unit))]
        public int? UnitId { get; set; }
        public Units? Unit { get; set; }

        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }
    }

    // Interim Payment Certificate against a subcontract.
    public class SubcontractIPCList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? IPCNo { get; set; }

        [ForeignKey(nameof(Subcontract))]
        public int? SubcontractId { get; set; }
        public SubcontractList? Subcontract { get; set; }

        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public decimal? CumulativeAmount { get; set; }
        public decimal? PreviousAmount { get; set; }
        public decimal? CurrentAmount { get; set; }
        public decimal? RetentionPercent { get; set; }
        public string? Status { get; set; }

        [ForeignKey(nameof(Approver))]
        public int? ApprovedBy { get; set; }
        public UsersList? Approver { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }

        public byte[]? RowVersion { get; set; }
    }

    public class SubcontractIPCDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to SubcontractIPCList.Id

        [ForeignKey(nameof(BOQItem))]
        public int? BOQItemId { get; set; }
        public SubcontractBOQDetails? BOQItem { get; set; }

        public decimal? QtyThisPeriod { get; set; }
        public decimal? QtyCumulative { get; set; }
        public decimal? Amount { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }
    }
}
