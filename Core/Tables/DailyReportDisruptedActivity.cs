using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Represents disrupted activity entry in a daily report.
    /// </summary>
    public class DailyReportDisruptedActivity : IDailyReportEntity
    {
        [Key]
        public int Id { get; set; }

        public string? ActivityName { get; set; }
        public string? DisruptionReason { get; set; }
        public string? Impact { get; set; }

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

        public int? DailyReportId { get; set; }
        public virtual DailyReport? DailyReport { get; set; }
    }
}
