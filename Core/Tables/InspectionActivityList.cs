using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>"نشاط الفحص" — an inspection activity nested under a SecondaryDisciplinesList row,
    /// the same way a secondary discipline is nested under a DisciplinesList row (see
    /// SecondaryDisciplinesList). Consumed by ConstructionInspectionRequestList.InspectionActivityId,
    /// filtered by SecondaryDisciplineId in frmCIRAddEdit's lueInspectionActivity.</summary>
    public class InspectionActivityList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        [ForeignKey(nameof(SecondaryDiscipline))]
        public int? SecondaryDisciplineId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        public SecondaryDisciplinesList? SecondaryDiscipline { get; set; }

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
