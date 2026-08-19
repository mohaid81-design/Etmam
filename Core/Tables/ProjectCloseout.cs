using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class CommissioningChecklistList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? ChecklistNo { get; set; }
        public string? SystemName { get; set; }
        public string? ChecklistType { get; set; }
        public DateTime? PlannedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? Result { get; set; }
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

    public class CommissioningChecklistItemDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to CommissioningChecklistList.Id
        public int? SeqNo { get; set; }
        public string? ItemDescription { get; set; }
        public string? AcceptanceCriteria { get; set; }
        public string? Result { get; set; }
        public string? ActualValue { get; set; }
        public bool? WitnessRequired { get; set; }
        public string? WitnessedBy { get; set; }
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

    public class HandoverPackageList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? PackageNo { get; set; }
        public string? SystemName { get; set; }
        public string? PackageType { get; set; }
        public DateTime? PlannedSubmissionDate { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public string? SubmittedTo { get; set; }
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

    public class HandoverPackageItemDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to HandoverPackageList.Id
        public string? DocumentType { get; set; } // AsBuilt / OMManual / Warranty / TestCertificate ...
        public string? Description { get; set; }
        public string? AttachmentPath { get; set; }
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

    public class ProjectCloseoutChecklistList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? ChecklistNo { get; set; }
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

    public class ProjectCloseoutItemDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to ProjectCloseoutChecklistList.Id
        public string? ItemDescription { get; set; }

        [ForeignKey(nameof(Responsible))]
        public int? ResponsibleId { get; set; }
        public UsersList? Responsible { get; set; }

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

    // Defects reported during the Defects Liability Period (warranty) after handover — tracked against
    // the responsible subcontractor (see StakeholdersList) rather than QualityPunchItemDetails, whose
    // scope is pre-handover inspection punches.
    public class DefectsLiabilityList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? DefectNo { get; set; }
        public string? SystemName { get; set; }
        public string? Description { get; set; }
        public DateTime? ReportedDate { get; set; }

        [ForeignKey(nameof(ResponsibleStakeholder))]
        public int? ResponsibleStakeholderId { get; set; }
        public StakeholdersList? ResponsibleStakeholder { get; set; }

        public string? Status { get; set; }
        public DateTime? RectifiedDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }

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
