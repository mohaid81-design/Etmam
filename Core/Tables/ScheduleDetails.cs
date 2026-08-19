using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core
{
    public class ScheduleDetails : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdParent { get; set; }
        public string? IdCategory { get; set; }
        public string? ActivityId { get; set; }
        public string? ActivityCode { get; set; }
        public string? ActivityName { get; set; }
        public int Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ActuaStart { get; set; }
        public DateTime? ActualEnd { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))]
        public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }

        [ForeignKey(nameof(Update))]
        public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }

        [ForeignKey(nameof(Deletion))]
        public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }

        [ForeignKey(nameof(Schedule))]
        public int ScheduleId { get; set; }
        public ScheduleList? Schedule { get; set; }

        [ForeignKey(nameof(Project))]
        public int PrjId { get; set; }
        public ProjectsList? Project { get; set; }


    }
}
