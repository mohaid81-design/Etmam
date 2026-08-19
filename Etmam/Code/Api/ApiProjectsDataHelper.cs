using Core;
using Data;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>
    /// Bridges the API-backed Projects CRUD onto IDataHelper&lt;ProjectsList&gt; so
    /// frmProjectAddEdit.cs (via SimpleEditFormBase&lt;T&gt;) can keep its existing
    /// BuildFields/PopulateFields/CollectFields/ValidateFields logic unchanged — only its
    /// `Helper` property switches from `dc.ProjectsList` to this class. Only Find/Add/Edit are
    /// implemented, since those are the only members SimpleEditFormBase&lt;T&gt; actually calls;
    /// everything else throws because nothing in this vertical slice needs it yet.
    /// </summary>
    public sealed class ApiProjectsDataHelper : IDataHelper<ProjectsList>
    {
        public ProjectsList? Find(int id) => ApiClient.GetProjectAsync(id).GetAwaiter().GetResult();
        public Task<ProjectsList?> FindAsync(int id) => ApiClient.GetProjectAsync(id);

        public int Add(ProjectsList entity, SqlTransaction? transaction = null) =>
            AddAsync(entity, transaction).GetAwaiter().GetResult();
        public async Task<int> AddAsync(ProjectsList entity, SqlTransaction? transaction = null) =>
            await ApiClient.CreateProjectAsync(entity).ConfigureAwait(false);

        public int Edit(int id, ProjectsList entity, SqlTransaction? transaction = null) =>
            EditAsync(id, entity, transaction).GetAwaiter().GetResult();
        public async Task<int> EditAsync(int id, ProjectsList entity, SqlTransaction? transaction = null)
        {
            await ApiClient.UpdateProjectAsync(id, entity).ConfigureAwait(false);
            return 1;
        }

        public List<ProjectsList> GetAll() => throw NotSupported();
        public Task<List<ProjectsList>> GetAllAsync() => throw NotSupported();
        public List<ProjectsList> GetBy(string? where = null, object? parameters = null) => throw NotSupported();
        public Task<List<ProjectsList>> GetByAsync(string? where = null, object? parameters = null) => throw NotSupported();
        public List<ProjectsList> Search(string searchItem) => throw NotSupported();
        public Task<List<ProjectsList>> SearchAsync(string searchItem) => throw NotSupported();
        public List<ProjectsList> GetBySql(string sql, object? parameters = null) => throw NotSupported();
        public Task<List<ProjectsList>> GetBySqlAsync(string sql, object? parameters = null) => throw NotSupported();
        public int Count(string? where = null, object? parameters = null) => throw NotSupported();
        public Task<int> CountAsync(string? where = null, object? parameters = null) => throw NotSupported();
        public bool Exists(string where, object? parameters = null) => throw NotSupported();
        public Task<bool> ExistsAsync(string where, object? parameters = null) => throw NotSupported();

        public int Delete(int id, SqlTransaction? transaction = null) => throw NotSupported();
        public Task<int> DeleteAsync(int id, SqlTransaction? transaction = null) => throw NotSupported();
        public int DeleteBy(string where, object? parameters, SqlTransaction? transaction = null) => throw NotSupported();
        public Task<int> DeleteByAsync(string where, object? parameters, SqlTransaction? transaction = null) => throw NotSupported();
        public int HardDeleteBy(string where, object? parameters, SqlTransaction? transaction = null) => throw NotSupported();
        public Task<int> HardDeleteByAsync(string where, object? parameters, SqlTransaction? transaction = null) => throw NotSupported();

        public List<int> AddRange(IEnumerable<ProjectsList> entities, SqlTransaction? transaction = null) => throw NotSupported();
        public Task<List<int>> AddRangeAsync(IEnumerable<ProjectsList> entities, SqlTransaction? transaction = null) => throw NotSupported();
        public int EditRange(IEnumerable<ProjectsList> entities, SqlTransaction? transaction = null) => throw NotSupported();
        public Task<int> EditRangeAsync(IEnumerable<ProjectsList> entities, SqlTransaction? transaction = null) => throw NotSupported();
        public int DeleteRange(IEnumerable<int> ids, SqlTransaction? transaction = null) => throw NotSupported();
        public Task<int> DeleteRangeAsync(IEnumerable<int> ids, SqlTransaction? transaction = null) => throw NotSupported();

        private static NotSupportedException NotSupported([System.Runtime.CompilerServices.CallerMemberName] string member = "") =>
            new($"ApiProjectsDataHelper.{member} is not implemented — this vertical slice only supports Find/Add/Edit.");
    }
}
