using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    // Non-Conformance Report — consolidates ERP's separate quality.NCR* / qms.NCRs into one shape.
    public class QualityNCRList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? NCRNo { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        [ForeignKey(nameof(Raiser))]
        public int? RaisedBy { get; set; }
        public UsersList? Raiser { get; set; }

        public DateTime? RaisedDate { get; set; }

        [ForeignKey(nameof(Discipline))]
        public int? DisciplineId { get; set; }
        public DisciplinesList? Discipline { get; set; }

        public string? Severity { get; set; }
        public string? RootCause { get; set; }
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

    public class QualityNCRActionDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to QualityNCRList.Id
        public string? ActionDescription { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? OwnerId { get; set; }
        public UsersList? Owner { get; set; }

        public DateTime? DueDate { get; set; }
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

    // Inspection & Test Plan template.
    public class QualityITPList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? ITPNo { get; set; }

        [ForeignKey(nameof(Discipline))]
        public int? DisciplineId { get; set; }
        public DisciplinesList? Discipline { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
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
    }

    public class QualityITPStepDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to QualityITPList.Id
        public int? SeqNo { get; set; }
        public string? ActivityDescription { get; set; }
        public string? InspectionType { get; set; } // Hold / Witness / Review / Random
        public string? AcceptanceCriteria { get; set; }
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

    // Consolidates ERP's InspectionRequests / MaterialInspectionRequests / WorkInspectionRequests.
    public class QualityInspectionRequestList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? RequestNo { get; set; }

        [ForeignKey(nameof(Discipline))]
        public int? DisciplineId { get; set; }
        public DisciplinesList? Discipline { get; set; }

        [ForeignKey(nameof(ITPStep))]
        public int? ITPStepId { get; set; }
        public QualityITPStepDetails? ITPStep { get; set; }

        public DateTime? RequestDate { get; set; }

        [ForeignKey(nameof(Requester))]
        public int? RequestedBy { get; set; }
        public UsersList? Requester { get; set; }

        public DateTime? InspectionDate { get; set; }

        [ForeignKey(nameof(Inspector))]
        public int? InspectorId { get; set; }
        public UsersList? Inspector { get; set; }

        public string? Result { get; set; } // Pass / Fail / Conditional
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

    public class QualityPunchListList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? PunchListNo { get; set; }
        public string? Area { get; set; }
        public DateTime? InspectionDate { get; set; }
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

    public class QualityPunchItemDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to QualityPunchListList.Id
        public string? ItemDescription { get; set; }
        public string? Discipline { get; set; }
        public int? ResponsibleStakeholderId { get; set; }
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
    }
}
