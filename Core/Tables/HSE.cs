using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class HSEIncidentList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? IncidentNo { get; set; }
        public string? IncidentType { get; set; }
        public string? Severity { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? IncidentDate { get; set; }
        public string? Location { get; set; }
        public string? InjuredPersonName { get; set; }
        public int? LostTimeDays { get; set; }
        public bool? MedicalTreatment { get; set; }
        public bool? Fatality { get; set; }
        public bool? Recordable { get; set; }
        public string? Status { get; set; }

        [ForeignKey(nameof(Reporter))]
        public int? ReportedBy { get; set; }
        public UsersList? Reporter { get; set; }

        public DateTime? ClosedDate { get; set; }

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

    public class HSEInspectionList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? InspectionNo { get; set; }
        public string? InspectionType { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string? Location { get; set; }

        [ForeignKey(nameof(Inspector))]
        public int? InspectorId { get; set; }
        public UsersList? Inspector { get; set; }

        public string? Status { get; set; }
        public decimal? ScorePct { get; set; }

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

    public class HSEInspectionFindingDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to HSEInspectionList.Id
        public string? FindingDescription { get; set; }
        public string? Severity { get; set; }
        public bool? CorrectiveActionRequired { get; set; }
        public DateTime? DueDate { get; set; }
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

    public class HSEPermitToWorkList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? PermitNo { get; set; }
        public string? PermitType { get; set; }
        public string? LocationDescription { get; set; }
        public string? WorkDescription { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        [ForeignKey(nameof(Issuer))]
        public int? IssuerId { get; set; }
        public UsersList? Issuer { get; set; }

        [ForeignKey(nameof(Receiver))]
        public int? ReceiverId { get; set; }
        public UsersList? Receiver { get; set; }

        public string? Status { get; set; }
        public DateTime? ClosedDate { get; set; }

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

    public class HSERiskAssessmentList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? AssessmentNo { get; set; }
        public string? ActivityDescription { get; set; }
        public string? LocationDescription { get; set; }
        public DateTime? AssessmentDate { get; set; }

        [ForeignKey(nameof(Preparer))]
        public int? PreparedBy { get; set; }
        public UsersList? Preparer { get; set; }

        [ForeignKey(nameof(Approver))]
        public int? ApprovedBy { get; set; }
        public UsersList? Approver { get; set; }

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

    public class HSEToolboxTalkList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? TalkNo { get; set; }
        public string? Topic { get; set; }
        public DateTime? TalkDate { get; set; }
        public string? Location { get; set; }

        [ForeignKey(nameof(Conductor))]
        public int? ConductedBy { get; set; }
        public UsersList? Conductor { get; set; }

        public int? AttendeeCount { get; set; }
        public string? Remarks { get; set; }

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

    public class HSEToolboxTalkAttendeeDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to HSEToolboxTalkList.Id
        public string? AttendeeName { get; set; }
        public int? StakeholderId { get; set; } // Set when attendee belongs to a subcontractor (see StakeholdersList)

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

    public class HSETrainingRecordList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? PersonName { get; set; }
        public int? StakeholderId { get; set; } // Set when the trainee belongs to a subcontractor
        public string? TrainingName { get; set; }
        public DateTime? TrainingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? ProviderName { get; set; }
        public string? CertificateReference { get; set; }
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

    // Shared corrective-action tracker for any HSE source (incident / inspection finding / observation).
    // Quality's own NCR corrective actions live separately in QualityNCRActionDetails since they're
    // scoped to a single NCR rather than any HSE source.
    public class HSECorrectiveActionList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? SourceType { get; set; } // Incident / Inspection / Observation
        public int? SourceId { get; set; }
        public string? ActionDescription { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? OwnerId { get; set; }
        public UsersList? Owner { get; set; }

        public DateTime? DueDate { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public DateTime? CompletionDate { get; set; }

        [ForeignKey(nameof(Verifier))]
        public int? VerifiedBy { get; set; }
        public UsersList? Verifier { get; set; }

        public DateTime? VerifiedDate { get; set; }

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
