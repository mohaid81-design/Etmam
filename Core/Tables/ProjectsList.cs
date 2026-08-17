using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class ProjectsList : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Num { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? Type { get; set; }
        public int? Situation { get; set; }
        public string? ProjectStartDate { get; set; }
        public string? InitialHandover { get; set; }
        public string? FinalHandover { get; set; }
        public DateTime? ContractDate { get; set; }
        public decimal? ContractAmount { get; set; }
        public decimal? AdvancePaymentAmount { get; set; }
        public decimal? AdvancePaymentPercent { get; set; }
        public decimal? RetentionPercent { get; set; }
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

        [ForeignKey(nameof(Client))]
        public int? CLId { get; set; }
        public StakeholdersList? Client { get; set; }

        [ForeignKey(nameof(Consultant))]
        public int? CSTId { get; set; }
        public StakeholdersList? Consultant { get; set; }

    }
}
