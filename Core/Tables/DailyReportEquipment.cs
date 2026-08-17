using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Represents equipment entry in a daily report.
    /// </summary>
    public class DailyReportEquipment : IDailyReportEntity
    {
        [Key]
        public int Id { get; set; }

        public int? Qty { get; set; }
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

        public int? DailyReportId { get; set; }
        public virtual DailyReport? DailyReport { get; set; }

        public int EquipmentListId { get; set; }
        public virtual EquipmentList? Equipment { get; set; }
    }
}
