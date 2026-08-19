using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>"الطابق" — a floor master item nested under a BuildingsList row (which is itself
    /// scoped to a project), the same cascading relationship as SecondaryDisciplinesList under
    /// DisciplinesList. Consumed by ConstructionInspectionRequestList.FloorIds (a request may span
    /// more than one floor), filtered by BuildingId in the UI.</summary>
    public class FloorsList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        [ForeignKey(nameof(Building))]
        public int? BuildingId { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        public BuildingsList? Building { get; set; }

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
