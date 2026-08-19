using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    // Accounts-payable invoice — the one gap left in the existing PR -> RFQ -> PriceQuotation -> PO ->
    // MaterialReceive procurement chain (receiving itself is already covered by
    // MaterialReceiveList/Details, which link back to PurchaseOrderList/Details).
    public class SupplierInvoiceList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? InvoiceNo { get; set; }

        [ForeignKey(nameof(Stakeholder))]
        public int? StakeholderId { get; set; } // Supplier — see StakeholdersList
        public StakeholdersList? Stakeholder { get; set; }

        [ForeignKey(nameof(PO))]
        public int? POId { get; set; }
        public PurchaseOrderList? PO { get; set; }

        [ForeignKey(nameof(MaterialReceive))]
        public int? MRId { get; set; }
        public MaterialReceiveList? MaterialReceive { get; set; }

        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; } // Pending / Approved / Paid / Rejected

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

    public class SupplierInvoiceDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int ParentId { get; set; } // Maps to SupplierInvoiceList.Id

        [ForeignKey(nameof(PODetail))]
        public int? PODetailId { get; set; }
        public PurchaseOrderDetails? PODetail { get; set; }

        public string? Description { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }

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

    public class SupplierPaymentList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? PaymentNo { get; set; }

        [ForeignKey(nameof(Invoice))]
        public int? InvoiceId { get; set; }
        public SupplierInvoiceList? Invoice { get; set; }

        [ForeignKey(nameof(Stakeholder))]
        public int? StakeholderId { get; set; }
        public StakeholdersList? Stakeholder { get; set; }

        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? ReferenceNo { get; set; }
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
}
