using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class StakeholdersList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Nationality { get; set; }
        public string? IdNumber { get; set; }
        public string? IdDate { get; set; }
        public string? DOB { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ContactName1 { get; set; }
        public string? ContactPhone1 { get; set; }
        public string? ContactName2 { get; set; }
        public string? ContactPhone2 { get; set; }
        public string? CommercialNumber { get; set; }
        public string? TaxNumber { get; set; }
        public string? VATNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVendor { get; set; }

        // Procurement additive fields
        public int? PaymentTermsDays { get; set; }
        public decimal? CreditLimit { get; set; }
        public int? Rating { get; set; }
        public bool? IsSponsor { get; set; }
        public bool? IsClient { get; set; }
        public bool? IsConsultant { get; set; }
        public bool? IsSubcontractor { get; set; }
        public bool? IsOther { get; set; }
        public string? CommercialIssuedDate { get; set; }
        public string? CommercialEndDate { get; set; }
        public string? CommercialManager { get; set; }
        public string? CommercialAddress { get; set; }
        public string? VATIssuedDate { get; set; }
        public byte[]? Logo { get; set; }

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

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public StakeholdersCategory? Category { get; set; }


    }
}
