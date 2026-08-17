using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class ItemCategory : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public int? LvlId { get; set; }
        public int? SortId { get; set; }
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

        [NotMapped]
        public string DisplayText => string.IsNullOrEmpty(Code) ? (Name ?? "") : $"{Code} {Name}";
    }
}
