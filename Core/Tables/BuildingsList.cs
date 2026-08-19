using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>"المبنى" — a building master item scoped to a single project. Consumed by
    /// ConstructionInspectionRequestList.BuildingId, filtered by PrjId in the UI.</summary>
    public class BuildingsList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        [ForeignKey(nameof(Project))]
        public int? PrjId { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        public ProjectsList? Project { get; set; }

        [ForeignKey(nameof(Created))]
        public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }

        [ForeignKey(nameof(Update))]
        public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }

        [ForeignKey(nameof(Deletion))]
        public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }
    }
}
