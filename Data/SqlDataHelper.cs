using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core;

namespace Data
{
    /// <summary>
    /// A professional, lightweight SQL-based data access helper for CRUD operations.
    /// The Async methods hold the real implementation; the sync methods are thin blocking
    /// wrappers over them so the SQL-building/mapping logic only exists once.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public class SqlDataHelper<T> : IDataHelper<T> where T : class, new()
    {
        private readonly string _tableName;
        private readonly PropertyInfo[] _properties;

        public SqlDataHelper()
        {
            _tableName = typeof(T).Name;
            _properties = typeof(T).GetProperties()
                .Where(p => IsSimpleType(p.PropertyType))
                .Where(p => !Attribute.IsDefined(p, typeof(NotMappedAttribute)))
                .ToArray();
        }

        private static bool IsSimpleType(Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type) ?? type;
            return underlyingType.IsPrimitive ||
                   underlyingType.IsEnum ||
                   underlyingType == typeof(string) ||
                   underlyingType == typeof(decimal) ||
                   underlyingType == typeof(DateTime) ||
                   underlyingType == typeof(Guid) ||
                   underlyingType == typeof(byte[]);
        }

        #region Internal Helpers

        private string BuildSafeQuery(string baseQuery, bool hasWhere = false)
        {
            var hasIsDelete = _properties.Any(p => p.Name.Equals("IsDelete", StringComparison.OrdinalIgnoreCase));
            if (!hasIsDelete) return baseQuery;

            if (baseQuery.Contains("IsDelete", StringComparison.OrdinalIgnoreCase)) return baseQuery;

            var condition = hasWhere ? " AND IsDelete = 0" : " WHERE IsDelete = 0";
            int orderByIndex = baseQuery.IndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase);

            if (orderByIndex >= 0)
                return baseQuery.Insert(orderByIndex, condition + " ");

            return baseQuery + condition;
        }

        // AddWithValue(name, DBNull.Value) can't infer a SqlDbType from a null value, so it
        // defaults to NVarChar — which SQL Server then refuses to implicitly convert into a
        // varbinary(max) column (e.g. Signature). Byte-array properties need an explicit type.
        private static void AddParameter(SqlCommand cmd, PropertyInfo prop, object? val)
        {
            if (val == null && prop.PropertyType == typeof(byte[]))
            {
                var p = cmd.Parameters.Add($"@{prop.Name}", SqlDbType.VarBinary);
                p.Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.AddWithValue($"@{prop.Name}", val ?? DBNull.Value);
            }
        }

        private static void AddParameters(SqlCommand cmd, object? parameters)
        {
            if (parameters == null) return;
            foreach (var prop in parameters.GetType().GetProperties())
            {
                var value = prop.GetValue(parameters) ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@" + prop.Name, value);
            }
        }

        private static object? ConvertToPropertyType(object value, Type targetType)
        {
            if (value == null || value == DBNull.Value) return null;

            var nonNullableType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (nonNullableType.IsAssignableFrom(value.GetType()))
                return value;

            if (nonNullableType == typeof(Guid))
            {
                if (value is Guid g) return g;
                if (Guid.TryParse(value.ToString(), out var guid)) return guid;
                throw new ArgumentException($"Value '{value}' cannot be converted to Guid.");
            }

            if (nonNullableType == typeof(decimal))
            {
                if (value is decimal d) return d;
                var s = value.ToString();
                if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var decInv)) return decInv;
                if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out var decCur)) return decCur;
                throw new ArgumentException($"Value '{value}' cannot be converted to decimal.");
            }

            if (nonNullableType == typeof(DateTime))
            {
                if (value is DateTime dt) return dt;
                if (DateTime.TryParse(value.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out var dtInv)) return dtInv;
                if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out var dtCur)) return dtCur;
                throw new ArgumentException($"Value '{value}' cannot be converted to DateTime.");
            }

            if (nonNullableType.IsEnum)
            {
                if (value is string enumString)
                    return Enum.Parse(nonNullableType, enumString, ignoreCase: true);
                return Enum.ToObject(nonNullableType, value);
            }

            return Convert.ChangeType(value, nonNullableType, CultureInfo.InvariantCulture);
        }

        private T MapToEntity(SqlDataReader reader)
        {
            var entity = new T();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var colName = reader.GetName(i);
                var prop = _properties.FirstOrDefault(p => p.Name.Equals(colName, StringComparison.OrdinalIgnoreCase));
                if (prop != null && !reader.IsDBNull(i))
                {
                    var rawValue = reader.GetValue(i);
                    var converted = ConvertToPropertyType(rawValue, prop.PropertyType);
                    prop.SetValue(entity, converted);
                }
            }
            return entity;
        }

        #endregion

        #region Queries (Async)

        public async Task<List<T>> GetAllAsync() => await GetByAsync().ConfigureAwait(false);

        public async Task<List<T>> GetByAsync(string? where = null, object? parameters = null)
        {
            var list = new List<T>();
            using (var con = new SqlConnection(DBSetting.GetConString()))
            {
                var sql = $"SELECT * FROM [{_tableName}]";
                if (!string.IsNullOrEmpty(where))
                    sql += " WHERE " + where;

                sql = BuildSafeQuery(sql, !string.IsNullOrEmpty(where));

                using (var cmd = new SqlCommand(sql, con))
                {
                    AddParameters(cmd, parameters);
                    await con.OpenAsync().ConfigureAwait(false);
                    using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false))
                            list.Add(MapToEntity(reader));
                    }
                }
            }
            return list;
        }

        public async Task<T?> FindAsync(int id)
        {
            using (var con = new SqlConnection(DBSetting.GetConString()))
            {
                var sql = BuildSafeQuery($"SELECT * FROM [{_tableName}] WHERE Id = @id", true);
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    await con.OpenAsync().ConfigureAwait(false);
                    using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync().ConfigureAwait(false))
                            return MapToEntity(reader);
                    }
                }
            }
            return null;
        }

        public async Task<List<T>> SearchAsync(string searchItem)
        {
            var where = "(Name LIKE @search OR CreatedMachine LIKE @search)";
            return await GetByAsync(where, new { search = $"%{searchItem}%" }).ConfigureAwait(false);
        }

        public async Task<List<T>> GetBySqlAsync(string sql, object? parameters = null)
        {
            var list = new List<T>();
            using (var con = new SqlConnection(DBSetting.GetConString()))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    AddParameters(cmd, parameters);
                    await con.OpenAsync().ConfigureAwait(false);
                    using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false))
                            list.Add(MapToEntity(reader));
                    }
                }
            }
            return list;
        }

        public async Task<int> CountAsync(string? where = null, object? parameters = null)
        {
            using (var con = new SqlConnection(DBSetting.GetConString()))
            {
                var sql = $"SELECT COUNT(*) FROM [{_tableName}]";
                if (!string.IsNullOrEmpty(where))
                    sql += " WHERE " + where;

                sql = BuildSafeQuery(sql, !string.IsNullOrEmpty(where));

                using (var cmd = new SqlCommand(sql, con))
                {
                    AddParameters(cmd, parameters);
                    await con.OpenAsync().ConfigureAwait(false);
                    return (int)await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task<bool> ExistsAsync(string where, object? parameters = null)
        {
            return await CountAsync(where, parameters).ConfigureAwait(false) > 0;
        }

        #endregion

        #region CRUD (Async)

        public async Task<int> AddAsync(T entity)
        {
            using (var con = new SqlConnection(DBSetting.GetConString()))
            {
                var props = _properties.Where(p => p.Name != "Id").ToList();
                var columns = string.Join(", ", props.Select(p => $"[{p.Name}]"));
                var values = string.Join(", ", props.Select(p => $"@{p.Name}"));
                var sql = $"INSERT INTO [{_tableName}] ({columns}) VALUES ({values}); SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(sql, con))
                {
                    foreach (var prop in props)
                    {
                        var val = prop.GetValue(entity);
                        if (val is DateTime dateVal && dateVal == DateTime.MinValue)
                            val = prop.PropertyType == typeof(DateTime?) ? DBNull.Value : new System.Data.SqlTypes.SqlDateTime(1753, 1, 1).Value;

                        AddParameter(cmd, prop, val);
                    }

                    await con.OpenAsync().ConfigureAwait(false);
                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    int newId = result != null ? Convert.ToInt32(result) : 0;

                    var idProp = typeof(T).GetProperty("Id");
                    if (idProp != null && idProp.CanWrite) idProp.SetValue(entity, newId);

                    return newId;
                }
            }
        }

        public async Task<int> EditAsync(int id, T entity)
        {
            using (var con = new SqlConnection(DBSetting.GetConString()))
            {
                var props = _properties.Where(p => p.Name != "Id").ToList();
                var sets = string.Join(", ", props.Select(p => $"[{p.Name}] = @{p.Name}"));
                var sql = $"UPDATE [{_tableName}] SET {sets} WHERE Id = @id";

                using (var cmd = new SqlCommand(sql, con))
                {
                    foreach (var prop in props)
                    {
                        var val = prop.GetValue(entity);
                        if (val is DateTime dateVal && dateVal == DateTime.MinValue)
                            val = prop.PropertyType == typeof(DateTime?) ? DBNull.Value : new System.Data.SqlTypes.SqlDateTime(1753, 1, 1).Value;

                        AddParameter(cmd, prop, val);
                    }
                    cmd.Parameters.AddWithValue("@id", id);

                    await con.OpenAsync().ConfigureAwait(false);
                    return await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task<int> DeleteAsync(int id, SqlTransaction? transaction = null) =>
            await DeleteByAsync("Id = @id", new { id }, transaction).ConfigureAwait(false);

        public async Task<int> DeleteByAsync(string where, object? parameters, SqlTransaction? transaction = null)
        {
            var ownsConnection = transaction == null;
            var con = transaction?.Connection ?? new SqlConnection(DBSetting.GetConString());
            try
            {
                var hasIsDelete = _properties.Any(p => p.Name.Equals("IsDelete", StringComparison.OrdinalIgnoreCase));
                var sql = hasIsDelete
                    ? $"UPDATE [{_tableName}] SET IsDelete = 1 WHERE " + where
                    : $"DELETE FROM [{_tableName}] WHERE " + where;

                using (var cmd = new SqlCommand(sql, con, transaction))
                {
                    AddParameters(cmd, parameters);
                    if (ownsConnection) await con.OpenAsync().ConfigureAwait(false);
                    return await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                if (ownsConnection) con.Dispose();
            }
        }

        #endregion

        #region Queries (Sync)
        // Thin blocking wrappers over the Async methods above — kept for the many call sites
        // written before async/await was introduced. No SQL-building logic is duplicated here.

        public List<T> GetAll() => GetAllAsync().GetAwaiter().GetResult();

        public List<T> GetBy(string? where = null, object? parameters = null) =>
            GetByAsync(where, parameters).GetAwaiter().GetResult();

        public T? Find(int id) => FindAsync(id).GetAwaiter().GetResult();

        public List<T> Search(string searchItem) => SearchAsync(searchItem).GetAwaiter().GetResult();

        public List<T> GetBySql(string sql, object? parameters = null) =>
            GetBySqlAsync(sql, parameters).GetAwaiter().GetResult();

        public int Count(string? where = null, object? parameters = null) =>
            CountAsync(where, parameters).GetAwaiter().GetResult();

        public bool Exists(string where, object? parameters = null) =>
            ExistsAsync(where, parameters).GetAwaiter().GetResult();

        #endregion

        #region CRUD (Sync)

        public int Add(T entity) => AddAsync(entity).GetAwaiter().GetResult();

        public int Edit(int id, T entity) => EditAsync(id, entity).GetAwaiter().GetResult();

        public int Delete(int id, SqlTransaction? transaction = null) =>
            DeleteAsync(id, transaction).GetAwaiter().GetResult();

        public int DeleteBy(string where, object? parameters, SqlTransaction? transaction = null) =>
            DeleteByAsync(where, parameters, transaction).GetAwaiter().GetResult();

        #endregion
    }
}
