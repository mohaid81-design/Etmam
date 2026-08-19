using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Suppliers are StakeholdersList rows with IsVendor = true. Mirrors the field set actually
    /// edited by Etmam/Gui/ProcurementModule/Suppliers/frmSupplierAddEdit.cs.
    /// </summary>
    public sealed class SuppliersService
    {
        private readonly IApplicationDbContext _db;

        public SuppliersService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<SupplierCategoryDto>> GetCategoriesAsync(CancellationToken ct = default)
        {
            var categories = await _db.StakeholdersCategory.OrderBy(c => c.MainCategory).ToListAsync(ct);
            return categories.Select(c => new SupplierCategoryDto
            {
                Id = c.Id ?? 0,
                MainCategory = c.MainCategory,
                SubCategory = c.SubCategory
            }).ToList();
        }

        public async Task<List<SupplierDto>> GetAllAsync(CancellationToken ct = default)
        {
            var suppliers = await _db.StakeholdersList
                .Include(s => s.Category)
                .Where(s => s.IsVendor == true)
                .OrderBy(s => s.Name)
                .ToListAsync(ct);

            return suppliers.Select(ToDto).ToList();
        }

        public async Task<SupplierDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.StakeholdersList
                .Include(s => s.Category)
                .FirstOrDefaultAsync(s => s.Id == id && s.IsVendor == true, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<int> CreateAsync(SupplierCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new StakeholdersList
            {
                IsVendor = true,
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.StakeholdersList.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, SupplierUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.StakeholdersList.FirstOrDefaultAsync(s => s.Id == id && s.IsVendor == true, ct)
                ?? throw new KeyNotFoundException($"Supplier {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.StakeholdersList.FirstOrDefaultAsync(s => s.Id == id && s.IsVendor == true, ct)
                ?? throw new KeyNotFoundException($"Supplier {id} not found.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        private static void Apply(SupplierSaveRequest request, StakeholdersList entity)
        {
            entity.Name = request.Name;
            entity.Type = request.Type;
            entity.CategoryId = request.CategoryId;
            entity.Rating = request.Rating;
            entity.Address = request.Address;
            entity.Nationality = request.Nationality;
            entity.IdNumber = request.IdNumber;
            entity.IdDate = request.IdDate;
            entity.DOB = request.DOB;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Email = request.Email;
            entity.CommercialNumber = request.CommercialNumber;
            entity.CommercialIssuedDate = request.CommercialIssuedDate;
            entity.CommercialEndDate = request.CommercialEndDate;
            entity.CommercialManager = request.CommercialManager;
            entity.CommercialAddress = request.CommercialAddress;
            entity.TaxNumber = request.TaxNumber;
            entity.VATNumber = request.VATNumber;
            entity.VATIssuedDate = request.VATIssuedDate;
            entity.ContactName1 = request.ContactName1;
            entity.ContactPhone1 = request.ContactPhone1;
            entity.ContactName2 = request.ContactName2;
            entity.ContactPhone2 = request.ContactPhone2;
            entity.IsActive = request.IsActive;
        }

        private static SupplierDto ToDto(StakeholdersList s) => new()
        {
            Id = s.Id,
            Name = s.Name,
            Type = s.Type,
            CategoryId = s.CategoryId,
            CategoryName = s.Category is null ? null :
                string.IsNullOrEmpty(s.Category.SubCategory) ? s.Category.MainCategory : $"{s.Category.MainCategory} / {s.Category.SubCategory}",
            Rating = s.Rating,
            Address = s.Address,
            Nationality = s.Nationality,
            IdNumber = s.IdNumber,
            IdDate = s.IdDate,
            DOB = s.DOB,
            PhoneNumber = s.PhoneNumber,
            Email = s.Email,
            CommercialNumber = s.CommercialNumber,
            CommercialIssuedDate = s.CommercialIssuedDate,
            CommercialEndDate = s.CommercialEndDate,
            CommercialManager = s.CommercialManager,
            CommercialAddress = s.CommercialAddress,
            TaxNumber = s.TaxNumber,
            VATNumber = s.VATNumber,
            VATIssuedDate = s.VATIssuedDate,
            ContactName1 = s.ContactName1,
            ContactPhone1 = s.ContactPhone1,
            ContactName2 = s.ContactName2,
            ContactPhone2 = s.ContactPhone2,
            IsActive = s.IsActive,
            UpdateDate = s.UpdateDate
        };
    }
}
