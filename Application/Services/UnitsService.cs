using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public sealed class UnitsService
    {
        private readonly IApplicationDbContext _db;

        public UnitsService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<UnitDto>> GetAllAsync(CancellationToken ct = default)
        {
            var units = await _db.Units.OrderBy(u => u.Description).ToListAsync(ct);
            return units.Select(ToDto).ToList();
        }

        public async Task<UnitDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.Units.FirstOrDefaultAsync(u => u.Id == id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<int> CreateAsync(UnitCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new Units
            {
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.Units.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, UnitUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.Units.FirstOrDefaultAsync(u => u.Id == id, ct)
                ?? throw new KeyNotFoundException($"Unit {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.Units.FirstOrDefaultAsync(u => u.Id == id, ct)
                ?? throw new KeyNotFoundException($"Unit {id} not found.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        private static void Apply(UnitSaveRequest request, Units entity)
        {
            entity.Description = request.Description;
            entity.Abbreviation = request.Abbreviation;
            entity.Category = request.Category;
        }

        private static UnitDto ToDto(Units u) => new()
        {
            Id = u.Id,
            Description = u.Description,
            Abbreviation = u.Abbreviation,
            Category = u.Category
        };
    }
}
