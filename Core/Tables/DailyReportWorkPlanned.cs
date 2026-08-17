using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Represents planned work entry in a daily report.
    /// </summary>
    public class DailyReportWorkPlanned : IDailyReportEntity
    {
        [Key]
        public int Id { get; set; }

        public string? Item { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
        public decimal? Qty { get; set; }

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
