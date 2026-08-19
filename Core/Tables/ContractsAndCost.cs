using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    // Main/consultancy/supply contract with a project party (client / consultant) — consolidates ERP's
    // contracts.Contracts + contractadmin.Contracts/ContractProfiles. Subcontract agreements have their
    // own SubcontractList instead (see Subcontracts.cs) since their lifecycle (BOQ, IPCs) differs.
    public class ContractList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? ContractNo { get; set; }
        public string? ContractType { get; set; } // Main / Consultancy / Supply

        [ForeignKey(nameof(Stakeholder))]
        public int? StakeholderId { get; set; } // Client / Consultant — see StakeholdersList
        public StakeholdersList? Stakeholder { get; set; }

        public decimal? ContractValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }

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

    public class ContractMilestoneDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to ContractList.Id
        public string? MilestoneName { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? WeightPercent { get; set; }
        public string? Status { get; set; }
        public DateTime? CompletionDate { get; set; }

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

    // Variation to either a main ContractList or a SubcontractList — exactly one of ContractId /
    // SubcontractId is set.
    public class ContractVariationList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? VariationNo { get; set; }

        [ForeignKey(nameof(Contract))]
        public int? ContractId { get; set; }
        public ContractList? Contract { get; set; }

        [ForeignKey(nameof(Subcontract))]
        public int? SubcontractId { get; set; }
        public SubcontractList? Subcontract { get; set; }

        public string? Description { get; set; }
        public decimal? OriginalAmount { get; set; }
        public decimal? VariationAmount { get; set; }
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

    // Consolidates ERP's contractadmin.Claims/Disputes — a Dispute is just an unresolved claim, tracked
    // via ClaimType + Status here instead of a separate table.
    public class ContractClaimList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? ClaimNo { get; set; }

        [ForeignKey(nameof(Contract))]
        public int? ContractId { get; set; }
        public ContractList? Contract { get; set; }

        [ForeignKey(nameof(Subcontract))]
        public int? SubcontractId { get; set; }
        public SubcontractList? Subcontract { get; set; }

        public string? ClaimType { get; set; } // EOT / Cost / Dispute
        public string? Description { get; set; }
        public decimal? ClaimedAmount { get; set; }
        public int? ClaimedDays { get; set; }
        public string? Status { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }

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

    // Consolidates ERP's contractadmin.Correspondence/Notices/Instructions via the Type column.
    public class ContractCorrespondenceList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? RefNo { get; set; }

        [ForeignKey(nameof(Contract))]
        public int? ContractId { get; set; }
        public ContractList? Contract { get; set; }

        [ForeignKey(nameof(Subcontract))]
        public int? SubcontractId { get; set; }
        public SubcontractList? Subcontract { get; set; }

        public string? Type { get; set; } // Notice / Letter / Instruction
        public string? Subject { get; set; }
        public string? Direction { get; set; } // In / Out
        public DateTime? CorrespondenceDate { get; set; }
        public string? FromParty { get; set; }
        public string? ToParty { get; set; }
        public string? Status { get; set; }

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

    // Periodic forecast-vs-actual snapshot per CostCenterList (the existing BudgetList already holds
    // the allocated amount per period; this tracks the rolling forecast/actual against it).
    public class CostForecastList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }

        [ForeignKey(nameof(CostCenter))]
        public int? CostCenterId { get; set; }
        public CostCenterList? CostCenter { get; set; }

        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public decimal? ForecastAmount { get; set; }
        public decimal? ActualAmount { get; set; }
        public string? Notes { get; set; }

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

    // Individual cost postings against a CostCenterList, sourced from a PO/subcontract/invoice or
    // entered manually — the ledger CostForecastList.ActualAmount is rolled up from.
    public class CostTransactionList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }

        [ForeignKey(nameof(CostCenter))]
        public int? CostCenterId { get; set; }
        public CostCenterList? CostCenter { get; set; }

        public DateTime? TransactionDate { get; set; }
        public string? SourceType { get; set; } // PO / Subcontract / Invoice / Manual
        public int? SourceId { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }

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
