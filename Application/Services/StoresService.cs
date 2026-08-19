using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// StoreList.PrjId has no navigation property on the entity (see Core/Tables/StoreList.cs),
    /// so ProjectName is resolved via a manual lookup instead of Include().
    /// </summary>
    public sealed class StoresService
    {
        private readonly IApplicationDbContext _db;

        public StoresService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<StoreDto>> GetAllAsync(CancellationToken ct = default)
        {
            var stores = await _db.StoreList.OrderBy(s => s.Name).ToListAsync(ct);
            var projectNamesById = await _db.ProjectsList.ToDictionaryAsync(p => p.Id, p => p.Name, ct);
            return stores.Select(s => ToDto(s, projectNamesById)).ToList();
        }

        public async Task<StoreDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.StoreList.FirstOrDefaultAsync(s => s.Id == id, ct);
            if (entity is null) return null;

            var projectNamesById = await _db.ProjectsList.ToDictionaryAsync(p => p.Id, p => p.Name, ct);
            return ToDto(entity, projectNamesById);
        }

        public async Task<int> CreateAsync(StoreCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new StoreList
            {
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.StoreList.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, StoreUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.StoreList.FirstOrDefaultAsync(s => s.Id == id, ct)
                ?? throw new KeyNotFoundException($"Store {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.StoreList.FirstOrDefaultAsync(s => s.Id == id, ct)
                ?? throw new KeyNotFoundException($"Store {id} not found.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        private static void Apply(StoreSaveRequest request, StoreList entity)
        {
            entity.Code = request.Code;
            entity.Name = request.Name;
            entity.IsActive = request.IsActive;
            entity.PrjId = request.PrjId;
        }

        private static StoreDto ToDto(StoreList s, IReadOnlyDictionary<int, string?> projectNamesById) => new()
        {
            Id = s.Id,
            Code = s.Code,
            Name = s.Name,
            IsActive = s.IsActive,
            PrjId = s.PrjId,
            ProjectName = s.PrjId is int pid && projectNamesById.TryGetValue(pid, out var pname) ? pname : null
        };
    }
}
