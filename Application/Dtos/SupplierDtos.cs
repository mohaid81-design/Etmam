namespace Application.Dtos
{
    /// <summary>
    /// Suppliers are StakeholdersList rows with IsVendor = true (the same table backs
    /// Client/Consultant/Subcontractor/Sponsor too). Logo (byte[]) and the non-supplier role
    /// flags (IsClient/IsConsultant/...) are intentionally left out of this slice.
    /// </summary>
    public sealed class SupplierDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Rating { get; set; }
        public string? Address { get; set; }
        public string? Nationality { get; set; }
        public string? IdNumber { get; set; }
        public string? IdDate { get; set; }
        public string? DOB { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? CommercialNumber { get; set; }
        public string? CommercialIssuedDate { get; set; }
        public string? CommercialEndDate { get; set; }
        public string? CommercialManager { get; set; }
        public string? CommercialAddress { get; set; }
        public string? TaxNumber { get; set; }
        public string? VATNumber { get; set; }
        public string? VATIssuedDate { get; set; }
        public string? ContactName1 { get; set; }
        public string? ContactPhone1 { get; set; }
        public string? ContactName2 { get; set; }
        public string? ContactPhone2 { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

    public class SupplierSaveRequest
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? CategoryId { get; set; }
        public int? Rating { get; set; }
        public string? Address { get; set; }
        public string? Nationality { get; set; }
        public string? IdNumber { get; set; }
        public string? IdDate { get; set; }
        public string? DOB { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? CommercialNumber { get; set; }
        public string? CommercialIssuedDate { get; set; }
        public string? CommercialEndDate { get; set; }
        public string? CommercialManager { get; set; }
        public string? CommercialAddress { get; set; }
        public string? TaxNumber { get; set; }
        public string? VATNumber { get; set; }
        public string? VATIssuedDate { get; set; }
        public string? ContactName1 { get; set; }
        public string? ContactPhone1 { get; set; }
        public string? ContactName2 { get; set; }
        public string? ContactPhone2 { get; set; }
        public bool? IsActive { get; set; }
    }

    public sealed class SupplierCreateRequest : SupplierSaveRequest
    {
    }

    public sealed class SupplierUpdateRequest : SupplierSaveRequest
    {
    }

    /// <summary>Read-only lookup for SupplierSaveRequest.CategoryId - StakeholdersCategory has no
    /// CRUD of its own in this slice, just a list endpoint to populate the picker.</summary>
    public sealed class SupplierCategoryDto
    {
        public int Id { get; set; }
        public string? MainCategory { get; set; }
        public string? SubCategory { get; set; }
    }
}
