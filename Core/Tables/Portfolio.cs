using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    // Groups multiple ProjectsList entries for executive-level, cross-project reporting.
    public class PortfolioList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public string? PortfolioNo { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
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

    public class PortfolioProjectDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to PortfolioList.Id

        [ForeignKey(nameof(Project))]
        public int? PrjId { get; set; }
        public ProjectsList? Project { get; set; }

        public decimal? WeightPercent { get; set; }
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

    // Periodic RAG (Red/Amber/Green) health snapshot per project, for portfolio-level dashboards.
    public class ProjectHealthSnapshotList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public DateTime? SnapshotDate { get; set; }
        public string? ScheduleHealth { get; set; } // Green / Amber / Red
        public string? CostHealth { get; set; }
        public string? QualityHealth { get; set; }
        public string? SafetyHealth { get; set; }
        public string? OverallHealth { get; set; }
        public string? Notes { get; set; }

        [ForeignKey(nameof(Recorder))]
        public int? RecordedBy { get; set; }
        public UsersList? Recorder { get; set; }

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
