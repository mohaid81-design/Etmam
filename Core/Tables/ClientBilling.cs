using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    // Owner-side progress certificate (mirrors SubcontractIPCList, but certifying the main contractor's
    // own progress to the client rather than a subcontractor's progress to the main contractor).
    public class ClientCertificateList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? CertificateNo { get; set; }

        [ForeignKey(nameof(Contract))]
        public int? ContractId { get; set; }
        public ContractList? Contract { get; set; }

        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public decimal? GrossWorkAmount { get; set; }
        public decimal? VariationAmount { get; set; }
        public decimal? RetentionAmount { get; set; }
        public decimal? CumulativeAmount { get; set; }
        public decimal? PreviousAmount { get; set; }
        public decimal? CurrentAmount { get; set; }
        public string? Status { get; set; }
        public DateTime? SubmittedDate { get; set; }

        [ForeignKey(nameof(Certifier))]
        public int? CertifiedBy { get; set; }
        public UsersList? Certifier { get; set; }

        public DateTime? CertifiedDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }

        public byte[]? RowVersion { get; set; }
    }

    public class ClientCertificateDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to ClientCertificateList.Id
        public string? Description { get; set; }
        public decimal? QtyThisPeriod { get; set; }
        public decimal? QtyCumulative { get; set; }
        public decimal? Amount { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }
    }

    // Client-facing tax invoice (mirrors SupplierInvoiceList, but issued TO the client rather than
    // received FROM a supplier).
    public class ClientInvoiceList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? InvoiceNo { get; set; }

        [ForeignKey(nameof(Contract))]
        public int? ContractId { get; set; }
        public ContractList? Contract { get; set; }

        [ForeignKey(nameof(Certificate))]
        public int? CertificateId { get; set; }
        public ClientCertificateList? Certificate { get; set; }

        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? AmountBeforeTax { get; set; }
        public decimal? VATAmount { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? CollectedAmount { get; set; }
        public decimal? OutstandingAmount { get; set; }
        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }

        public byte[]? RowVersion { get; set; }
    }

    public class ClientCollectionList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? CollectionNo { get; set; }

        [ForeignKey(nameof(Invoice))]
        public int? InvoiceId { get; set; }
        public ClientInvoiceList? Invoice { get; set; }

        public DateTime? CollectionDate { get; set; }
        public decimal? Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? BankReference { get; set; }
        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }
    }
}
