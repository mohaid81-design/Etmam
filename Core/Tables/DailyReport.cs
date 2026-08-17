using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Represents a daily report for a project.
    /// </summary>
    public class DailyReport : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "رقم التقرير")]
        public string? ReportNumber { get; set; }

        [Display(Name = "التاريخ")]
        public DateTime? ReportDate { get; set; }

        [Display(Name = "الطقس")]
        public string? Weather { get; set; }

        [Display(Name = "درجة الحرارة")]
        public int? Temperature { get; set; }

        [Display(Name = "الوردية")]
        public string? Shift { get; set; }

        [Display(Name = "الحالة")]
        public string? Status { get; set; }

        // Audit fields inherited from IBaseEntity
        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public int UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
        public int DeletionBy { get; set; }

        // Navigation properties
        public virtual UsersList? Created { get; set; }
        public virtual UsersList? Update { get; set; }
        public virtual UsersList? Deletion { get; set; }

        [ForeignKey(nameof(Project))]
        public int PrjId { get; set; }
        public virtual ProjectsList? Project { get; set; }

        public virtual ICollection<DailyReportManpower>? Manpowers { get; set; }
        public virtual ICollection<DailyReportEquipment>? Equipments { get; set; }
        public virtual ICollection<DailyReportWorkDone>? WorkDones { get; set; }
        public virtual ICollection<DailyReportWorkPlanned>? WorkPlanneds { get; set; }
        public virtual ICollection<DailyReportMaterial>? Materials { get; set; }
        public virtual ICollection<DailyReportIssue>? Issues { get; set; }
        public virtual ICollection<DailyReportDisruptedActivity>? DisruptedActivities { get; set; }
        public virtual ICollection<DailyReportInspection>? Inspections { get; set; }
    }
}
