using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Data
{
    public interface IDataHelper<T>
    {
        // ─── Queries (Async) ────────────────────────────────────────────────
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByAsync(string? where = null, object? parameters = null);
        Task<List<T>> SearchAsync(string searchItem);
        Task<T?> FindAsync(int id);
        Task<List<T>> GetBySqlAsync(string sql, object? parameters = null);
        Task<int> CountAsync(string? where = null, object? parameters = null);
        Task<bool> ExistsAsync(string where, object? parameters = null);

        // ─── CRUD (Async) ───────────────────────────────────────────────────
        // A transaction can be passed so a header + its detail rows commit or roll back
        // atomically instead of leaving a partially-saved document (see Delete's own comment).
        Task<int> AddAsync(T entity, SqlTransaction? transaction = null);
        Task<int> EditAsync(int id, T entity, SqlTransaction? transaction = null);
        Task<int> DeleteAsync(int id, SqlTransaction? transaction = null);
        Task<int> DeleteByAsync(string where, object? parameters, SqlTransaction? transaction = null);

        // Bypasses the IsDelete soft-delete convention and always issues a real DELETE FROM,
        // even on a table that has an IsDelete column — for the rare case a record must be purged
        // outright (e.g. a never-submitted draft) rather than just hidden. Use DeleteBy for
        // everything else.
        Task<int> HardDeleteByAsync(string where, object? parameters, SqlTransaction? transaction = null);

        // ─── Batch CRUD (Async) ─────────────────────────────────────────────
        // Sends every row's statement as one multi-statement SQL batch (one network round trip
        // per chunk instead of one per row) — for detail-grid saves (manpower, materials, PO
        // lines, ...) where a document can carry dozens of rows. See [[project_architecture]].
        Task<List<int>> AddRangeAsync(IEnumerable<T> entities, SqlTransaction? transaction = null);
        Task<int> EditRangeAsync(IEnumerable<T> entities, SqlTransaction? transaction = null);
        Task<int> DeleteRangeAsync(IEnumerable<int> ids, SqlTransaction? transaction = null);

        // ─── Queries (Sync) ─────────────────────────────────────────────────
        List<T> GetAll();
        List<T> GetBy(string? where = null, object? parameters = null);
        List<T> Search(string searchItem);
        T? Find(int id);
        List<T> GetBySql(string sql, object? parameters = null);
        int Count(string? where = null, object? parameters = null);
        bool Exists(string where, object? parameters = null);

        // ─── CRUD (Sync) ────────────────────────────────────────────────────
        int Add(T entity, SqlTransaction? transaction = null);
        int Edit(int id, T entity, SqlTransaction? transaction = null);
        // A transaction can be passed so multi-step operations (e.g. cascading deletes across
        // header/detail tables) commit or roll back atomically instead of leaving partial writes.
        int Delete(int id, SqlTransaction? transaction = null);
        int DeleteBy(string where, object? parameters, SqlTransaction? transaction = null);
        int HardDeleteBy(string where, object? parameters, SqlTransaction? transaction = null);

        // ─── Batch CRUD (Sync) ──────────────────────────────────────────────
        List<int> AddRange(IEnumerable<T> entities, SqlTransaction? transaction = null);
        int EditRange(IEnumerable<T> entities, SqlTransaction? transaction = null);
        int DeleteRange(IEnumerable<int> ids, SqlTransaction? transaction = null);
    }
}
