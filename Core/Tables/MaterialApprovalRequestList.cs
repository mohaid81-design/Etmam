using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class MaterialApprovalRequestList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }
        public int? Rev { get; set; }
        public DateTime? PreparedDate { get; set; }
        public int? Category { get; set; }
          public int? SubCategory { get; set; }
        public string? Description { get; set; }
        public int? PrjId { get; set; }
        public int? OverallStatus { get; set; }
        public string? IssuedBy { get; set; }
        public bool? IsSubmitted { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public string? ReviewDate { get; set; }
        public bool? AttachCalculations { get; set; }
        public bool? AttachCatalogues { get; set; }
        public bool? AttachCertificates { get; set; }
        public bool? AttachDrawings { get; set; }
        public bool? AttachTest { get; set; }
        public bool? AttachSpecifications { get; set; }
        public bool? AttachSample { get; set; }
        public bool? AttachOther { get; set; }
        public string? AttachOtherText { get; set; }
        public bool? IsSubmittedFormSigned { get; set; }
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
