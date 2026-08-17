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
        Task<int> AddAsync(T entity);
        Task<int> EditAsync(int id, T entity);
        Task<int> DeleteAsync(int id, SqlTransaction? transaction = null);
        Task<int> DeleteByAsync(string where, object? parameters, SqlTransaction? transaction = null);

        // ─── Queries (Sync) ─────────────────────────────────────────────────
        List<T> GetAll();
        List<T> GetBy(string? where = null, object? parameters = null);
        List<T> Search(string searchItem);
        T? Find(int id);
        List<T> GetBySql(string sql, object? parameters = null);
        int Count(string? where = null, object? parameters = null);
        bool Exists(string where, object? parameters = null);

        // ─── CRUD (Sync) ────────────────────────────────────────────────────
        int Add(T entity);
        int Edit(int id, T entity);
        // A transaction can be passed so multi-step operations (e.g. cascading deletes across
        // header/detail tables) commit or roll back atomically instead of leaving partial writes.
        int Delete(int id, SqlTransaction? transaction = null);
        int DeleteBy(string where, object? parameters, SqlTransaction? transaction = null);
    }
}
