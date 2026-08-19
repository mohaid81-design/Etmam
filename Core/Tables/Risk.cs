using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    // Consolidates ERP's risk.Risks + riskmgmt.Risks — a single operational risk register.
    public class RiskRegisterList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? RiskNo { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public byte? Probability { get; set; }
        public byte? ImpactScore { get; set; }
        public byte? RiskScore { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? OwnerId { get; set; }
        public UsersList? Owner { get; set; }

        public string? Status { get; set; }
        public DateTime? IdentifiedDate { get; set; }
        public DateTime? TargetClosureDate { get; set; }
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

    public class RiskResponseDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to RiskRegisterList.Id
        public string? ResponseStrategy { get; set; } // Avoid / Mitigate / Transfer / Accept
        public string? ActionDescription { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? OwnerId { get; set; }
        public UsersList? Owner { get; set; }

        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }
        public decimal? CompletionPct { get; set; }

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

    // General project issue log (materialized problems), distinct from RiskRegisterList (forward-looking
    // uncertainty) — optionally traced back to the risk that predicted it via LinkedRiskId.
    public class ProjectIssueList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? IssueNo { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CategoryCode { get; set; }

        [ForeignKey(nameof(Raiser))]
        public int? RaisedBy { get; set; }
        public UsersList? Raiser { get; set; }

        public DateTime? RaisedDate { get; set; }
        public string? Severity { get; set; }

        [ForeignKey(nameof(LinkedRisk))]
        public int? LinkedRiskId { get; set; }
        public RiskRegisterList? LinkedRisk { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? OwnerId { get; set; }
        public UsersList? Owner { get; set; }

        public DateTime? TargetResolutionDate { get; set; }
        public string? ResolutionNote { get; set; }
        public DateTime? ResolvedDate { get; set; }
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
}
