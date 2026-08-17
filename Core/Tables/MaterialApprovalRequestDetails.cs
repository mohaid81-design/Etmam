using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class MaterialApprovalRequestDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? MARId { get; set; }
        public string? Description { get; set; }
        public string? Purpose { get; set; }
        public string? Manufacture { get; set; }
        public string? BOQRef { get; set; }
        public string? DrawingRef { get; set; }
        public string? SpecRef { get; set; }
        public int? PrjId { get; set; }
        public string? ReviewComment { get; set; }
        public string? ReviewStatus { get; set; }
        public bool? IsRejectedItemRequiredResubmitt { get; set; }
        public bool? IsRejectedItemResubmitted { get; set; }
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
