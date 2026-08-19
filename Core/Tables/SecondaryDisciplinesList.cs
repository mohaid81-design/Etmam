using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>"التخصص الثانوي" — a sub-discipline nested under a DisciplinesList row (e.g. تخصص
    /// "إنشائي" قد يضم تخصصات ثانوية "خرسانة"/"حديد"...). Currently consumed by
    /// ConstructionInspectionRequestList.SecondaryDisciplineId, filtered by DisciplineId in the UI.</summary>
    public class SecondaryDisciplinesList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        [ForeignKey(nameof(Discipline))]
        public int? DisciplineId { get; set; }
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

        public DisciplinesList? Discipline { get; set; }

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
