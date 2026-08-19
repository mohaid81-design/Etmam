using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>General-purpose "discipline" master list (e.g. إنشائي/معماري، ميكانيكا، كهرباء) —
    /// reusable by any module, not tied to a single one. Used first by WorkflowDefinitionList (which
    /// disciplines a procedure applies to, via WorkflowDefinitionDisciplineList) and PurchaseRequestList
    /// (which discipline a request belongs to), to route a request to the matching procedure
    /// automatically.</summary>
    public class DisciplinesList : IBaseEntity
    {
        [Key] public int Id { get; set; }
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
