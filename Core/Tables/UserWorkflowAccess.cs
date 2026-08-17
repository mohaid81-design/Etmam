using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class UserWorkflowAccess
    {
        [Key] public int Id { get; set; }
        public int UserID { get; set; }
        public int WorkflowId { get; set; }
        public bool PermsStatus { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }

        [ForeignKey(nameof(Update))]
        public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
    }
}
