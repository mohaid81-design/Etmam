using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
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

        // SQL Server caps a single RPC at 2100 parameters. Batch methods pack N rows' worth of
        // parameters into one command text, so this bounds how many rows go in one round trip;
        // wider entities (more columns) get smaller chunks. Kept well under the hard limit as
        // margin for the extra @id/@__rv parameters EditRangeAsync adds per row.
        private const int MaxBatchParameters = 2000;

        // Opt-in optimistic-concurrency convention: a property literally named "RowVersion" of type
        // byte[] maps to SQL Server's native auto-incrementing ROWVERSION column (see
        // DatabaseInitializer.GetSqlType). When present, Add/EditAsync read its server-assigned value
        // back via OUTPUT INSERTED, and EditAsync adds it to the WHERE clause so a stale save (the row
        // changed since this entity was loaded) throws ConcurrencyConflictException instead of silently
        // overwriting. Entities that don't declare this property behave exactly as before.
        private readonly PropertyInfo? _rowVersionProp;

        public SqlDataHelper()
        {
            _tableName = typeof(T).Name;
            _properties = typeof(T).GetProperties()
                .Where(p => IsSimpleType(p.PropertyType))
                .Where(p => !Attribute.IsDefined(p, typeof(NotMappedAttribute)))
                .ToArray();

            _rowVersionProp = _properties.FirstOrDefault(p =>
                p.Name.Equals("RowVersion", StringComparison.OrdinalIgnoreCase) && p.PropertyType == typeof(byte[]));
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
        // `suffix` disambiguates parameter names when multiple rows' statements share one command
        // text (see the Range batch methods below) — e.g. "@Qty_3" for the 4th row in a batch.
        private static void AddParameter(SqlCommand cmd, PropertyInfo prop, object? val, string? suffix = null)
        {
            var name = $"@{prop.Name}{suffix}";
            if (val == null && prop.PropertyType == typeof(byte[]))
            {
                var p = cmd.Parameters.Add(name, SqlDbType.VarBinary);
                p.Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.AddWithValue(name, val ?? DBNull.Value);
            }
        }

        // MinValue DateTimes can't round-trip to SQL Server's datetime range; nullable columns
        // get NULL instead, non-nullable columns get SQL's own minimum. Shared by the single-row
        // and batch Add/Edit paths so this coercion only lives in one place.
        private static object? CoerceDateTimeMin(PropertyInfo prop, object? val) =>
            val is DateTime dateVal && dateVal == DateTime.MinValue
                ? (prop.PropertyType == typeof(DateTime?) ? DBNull.Value : new System.Data.SqlTypes.SqlDateTime(1753, 1, 1).Value)
                : val;

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
                    return Convert.ToInt32(await cmd.ExecuteScalarAsync().ConfigureAwait(false));
                }
            }
        }

        public async Task<bool> ExistsAsync(string where, object? parameters = null)
        {
            return await CountAsync(where, parameters).ConfigureAwait(false) > 0;
        }

        #endregion

        #region CRUD (Async)

        public async Task<int> AddAsync(T entity, SqlTransaction? transaction = null)
        {
            var ownsConnection = transaction == null;
            var con = transaction?.Connection ?? new SqlConnection(DBSetting.GetConString());
            try
            {
                // RowVersion (when present) is server-generated by SQL Server on insert — it can never
                // be part of the INSERT column list.
                var props = _properties.Where(p => p.Name != "Id" && p != _rowVersionProp).ToList();
                var columns = string.Join(", ", props.Select(p => $"[{p.Name}]"));
                var values = string.Join(", ", props.Select(p => $"@{p.Name}"));
                var sql = _rowVersionProp != null
                    ? $"INSERT INTO [{_tableName}] ({columns}) OUTPUT INSERTED.[Id], INSERTED.[RowVersion] VALUES ({values});"
                    : $"INSERT INTO [{_tableName}] ({columns}) VALUES ({values}); SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(sql, con, transaction))
                {
                    foreach (var prop in props)
                    {
                        var val = CoerceDateTimeMin(prop, prop.GetValue(entity));
                        AddParameter(cmd, prop, val);
                    }

                    if (ownsConnection) await con.OpenAsync().ConfigureAwait(false);

                    int newId;
                    if (_rowVersionProp != null)
                    {
                        using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            await reader.ReadAsync().ConfigureAwait(false);
                            newId = Convert.ToInt32(reader.GetValue(0));
                            _rowVersionProp.SetValue(entity, reader.IsDBNull(1) ? null : (byte[])reader.GetValue(1));
                        }
                    }
                    else
                    {
                        var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                        newId = result != null ? Convert.ToInt32(result) : 0;
                    }

                    var idProp = typeof(T).GetProperty("Id");
                    if (idProp != null && idProp.CanWrite) idProp.SetValue(entity, newId);

                    return newId;
                }
            }
            finally
            {
                if (ownsConnection) con.Dispose();
            }
        }

        public async Task<int> EditAsync(int id, T entity, SqlTransaction? transaction = null)
        {
            var ownsConnection = transaction == null;
            var con = transaction?.Connection ?? new SqlConnection(DBSetting.GetConString());
            try
            {
                var props = _properties.Where(p => p.Name != "Id" && p != _rowVersionProp).ToList();
                var sets = string.Join(", ", props.Select(p => $"[{p.Name}] = @{p.Name}"));

                // If the caller's entity carries a RowVersion it loaded earlier, add it to the WHERE
                // clause so a save against a row someone else has since modified affects zero rows
                // instead of silently overwriting their change. A null RowVersion (entity type doesn't
                // use this convention, or a caller that never populated it) falls back to the previous
                // blind-update behavior — this is opt-in, not a requirement on every call site.
                var expectedRowVersion = _rowVersionProp?.GetValue(entity) as byte[];
                var checkConcurrency = _rowVersionProp != null && expectedRowVersion != null;

                var sql = $"UPDATE [{_tableName}] SET {sets}" +
                    (_rowVersionProp != null ? " OUTPUT INSERTED.[RowVersion]" : "") +
                    " WHERE Id = @id" +
                    (checkConcurrency ? " AND [RowVersion] = @__ExpectedRowVersion" : "");

                using (var cmd = new SqlCommand(sql, con, transaction))
                {
                    foreach (var prop in props)
                    {
                        var val = CoerceDateTimeMin(prop, prop.GetValue(entity));
                        AddParameter(cmd, prop, val);
                    }
                    cmd.Parameters.AddWithValue("@id", id);
                    if (checkConcurrency) cmd.Parameters.AddWithValue("@__ExpectedRowVersion", expectedRowVersion!);

                    if (ownsConnection) await con.OpenAsync().ConfigureAwait(false);

                    if (_rowVersionProp != null)
                    {
                        using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                _rowVersionProp.SetValue(entity, reader.IsDBNull(0) ? null : (byte[])reader.GetValue(0));
                                return 1;
                            }
                        }

                        if (checkConcurrency)
                            throw new ConcurrencyConflictException(
                                $"تعذّر حفظ السجل رقم {id} في جدول {_tableName}: تم تعديله من قبل مستخدم آخر منذ فتحه. يرجى إعادة تحميله والمحاولة مرة أخرى.");

                        return 0;
                    }

                    return await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                if (ownsConnection) con.Dispose();
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

        public async Task<int> HardDeleteByAsync(string where, object? parameters, SqlTransaction? transaction = null)
        {
            var ownsConnection = transaction == null;
            var con = transaction?.Connection ?? new SqlConnection(DBSetting.GetConString());
            try
            {
                var sql = $"DELETE FROM [{_tableName}] WHERE " + where;

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

        #region Batch CRUD (Async)
        // These exist to replace the "loop and call Add/Edit/Delete per row" pattern used by
        // every detail-grid save (manpower, materials, PO/PR lines, ...): each row there was its
        // own network round trip to Azure SQL, so a document with dozens of detail rows meant
        // dozens of round trips per save. These pack all rows into one multi-statement SQL batch
        // (chunked to stay under SQL Server's ~2100-parameter-per-RPC limit — see
        // MaxBatchParameters) so a whole detail grid saves in one or two round trips instead.

        public async Task<List<int>> AddRangeAsync(IEnumerable<T> entities, SqlTransaction? transaction = null)
        {
            var all = entities as IList<T> ?? entities.ToList();
            var newIds = new List<int>(all.Count);
            if (all.Count == 0) return newIds;

            var props = _properties.Where(p => p.Name != "Id" && p != _rowVersionProp).ToList();
            var columns = string.Join(", ", props.Select(p => $"[{p.Name}]"));
            var chunkSize = Math.Max(1, MaxBatchParameters / Math.Max(1, props.Count));
            var idProp = typeof(T).GetProperty("Id");

            var ownsConnection = transaction == null;
            var con = transaction?.Connection ?? new SqlConnection(DBSetting.GetConString());
            try
            {
                if (ownsConnection) await con.OpenAsync().ConfigureAwait(false);

                for (var offset = 0; offset < all.Count; offset += chunkSize)
                {
                    var chunk = all.Skip(offset).Take(chunkSize).ToList();
                    var sb = new StringBuilder();

                    using (var cmd = new SqlCommand(string.Empty, con, transaction))
                    {
                        for (var i = 0; i < chunk.Count; i++)
                        {
                            var suffix = $"_{i}";
                            var values = string.Join(", ", props.Select(p => $"@{p.Name}{suffix}"));
                            sb.Append(_rowVersionProp != null
                                ? $"INSERT INTO [{_tableName}] ({columns}) OUTPUT INSERTED.[Id], INSERTED.[RowVersion] VALUES ({values});"
                                : $"INSERT INTO [{_tableName}] ({columns}) VALUES ({values}); SELECT CAST(SCOPE_IDENTITY() AS int);");

                            foreach (var prop in props)
                                AddParameter(cmd, prop, CoerceDateTimeMin(prop, prop.GetValue(chunk[i])), suffix);
                        }
                        cmd.CommandText = sb.ToString();

                        using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            var i = 0;
                            do
                            {
                                if (!await reader.ReadAsync().ConfigureAwait(false)) break;
                                var newId = Convert.ToInt32(reader.GetValue(0));
                                if (_rowVersionProp != null)
                                    _rowVersionProp.SetValue(chunk[i], reader.IsDBNull(1) ? null : (byte[])reader.GetValue(1));
                                if (idProp != null && idProp.CanWrite) idProp.SetValue(chunk[i], newId);
                                newIds.Add(newId);
                                i++;
                            } while (await reader.NextResultAsync().ConfigureAwait(false));
                        }
                    }
                }
                return newIds;
            }
            finally
            {
                if (ownsConnection) con.Dispose();
            }
        }

        public async Task<int> EditRangeAsync(IEnumerable<T> entities, SqlTransaction? transaction = null)
        {
            var all = entities as IList<T> ?? entities.ToList();
            if (all.Count == 0) return 0;

            var props = _properties.Where(p => p.Name != "Id" && p != _rowVersionProp).ToList();
            // +2 headroom per row for @id_i and (when applicable) @__rv_i.
            var chunkSize = Math.Max(1, MaxBatchParameters / Math.Max(1, props.Count + 2));
            var idProp = typeof(T).GetProperty("Id")!;
            var affected = 0;

            var ownsConnection = transaction == null;
            var con = transaction?.Connection ?? new SqlConnection(DBSetting.GetConString());
            try
            {
                if (ownsConnection) await con.OpenAsync().ConfigureAwait(false);

                for (var offset = 0; offset < all.Count; offset += chunkSize)
                {
                    var chunk = all.Skip(offset).Take(chunkSize).ToList();
                    var sb = new StringBuilder();

                    using (var cmd = new SqlCommand(string.Empty, con, transaction))
                    {
                        for (var i = 0; i < chunk.Count; i++)
                        {
                            var entity = chunk[i];
                            var suffix = $"_{i}";
                            var sets = string.Join(", ", props.Select(p => $"[{p.Name}] = @{p.Name}{suffix}"));
                            var expectedRowVersion = _rowVersionProp?.GetValue(entity) as byte[];
                            var checkConcurrency = _rowVersionProp != null && expectedRowVersion != null;

                            sb.Append($"UPDATE [{_tableName}] SET {sets}" +
                                (_rowVersionProp != null ? " OUTPUT INSERTED.[RowVersion]" : "") +
                                $" WHERE Id = @id{suffix}" +
                                (checkConcurrency ? $" AND [RowVersion] = @__rv{suffix}" : "") + ";");

                            foreach (var prop in props)
                                AddParameter(cmd, prop, CoerceDateTimeMin(prop, prop.GetValue(entity)), suffix);

                            cmd.Parameters.AddWithValue($"@id{suffix}", (int)idProp.GetValue(entity)!);
                            if (checkConcurrency) cmd.Parameters.AddWithValue($"@__rv{suffix}", expectedRowVersion!);
                        }
                        cmd.CommandText = sb.ToString();

                        if (_rowVersionProp != null)
                        {
                            using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                            {
                                var i = 0;
                                do
                                {
                                    var entity = chunk[i];
                                    if (await reader.ReadAsync().ConfigureAwait(false))
                                    {
                                        _rowVersionProp.SetValue(entity, reader.IsDBNull(0) ? null : (byte[])reader.GetValue(0));
                                        affected++;
                                    }
                                    else if (_rowVersionProp.GetValue(entity) is byte[])
                                    {
                                        var id = idProp.GetValue(entity);
                                        throw new ConcurrencyConflictException(
                                            $"تعذّر حفظ السجل رقم {id} في جدول {_tableName}: تم تعديله من قبل مستخدم آخر منذ فتحه. يرجى إعادة تحميله والمحاولة مرة أخرى.");
                                    }
                                    i++;
                                } while (await reader.NextResultAsync().ConfigureAwait(false));
                            }
                        }
                        else
                        {
                            affected += await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                        }
                    }
                }
                return affected;
            }
            finally
            {
                if (ownsConnection) con.Dispose();
            }
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<int> ids, SqlTransaction? transaction = null)
        {
            var idList = ids as IList<int> ?? ids.ToList();
            if (idList.Count == 0) return 0;

            var hasIsDelete = _properties.Any(p => p.Name.Equals("IsDelete", StringComparison.OrdinalIgnoreCase));
            const int chunkSize = MaxBatchParameters;
            var affected = 0;

            var ownsConnection = transaction == null;
            var con = transaction?.Connection ?? new SqlConnection(DBSetting.GetConString());
            try
            {
                if (ownsConnection) await con.OpenAsync().ConfigureAwait(false);

                for (var offset = 0; offset < idList.Count; offset += chunkSize)
                {
                    var chunk = idList.Skip(offset).Take(chunkSize).ToList();
                    var paramNames = chunk.Select((_, i) => $"@id{i}").ToList();
                    var sql = hasIsDelete
                        ? $"UPDATE [{_tableName}] SET IsDelete = 1 WHERE Id IN ({string.Join(",", paramNames)})"
                        : $"DELETE FROM [{_tableName}] WHERE Id IN ({string.Join(",", paramNames)})";

                    using (var cmd = new SqlCommand(sql, con, transaction))
                    {
                        for (var i = 0; i < chunk.Count; i++)
                            cmd.Parameters.AddWithValue($"@id{i}", chunk[i]);
                        affected += await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                    }
                }
                return affected;
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

        public int Add(T entity, SqlTransaction? transaction = null) => AddAsync(entity, transaction).GetAwaiter().GetResult();

        public int Edit(int id, T entity, SqlTransaction? transaction = null) => EditAsync(id, entity, transaction).GetAwaiter().GetResult();

        public int Delete(int id, SqlTransaction? transaction = null) =>
            DeleteAsync(id, transaction).GetAwaiter().GetResult();

        public int DeleteBy(string where, object? parameters, SqlTransaction? transaction = null) =>
            DeleteByAsync(where, parameters, transaction).GetAwaiter().GetResult();

        public int HardDeleteBy(string where, object? parameters, SqlTransaction? transaction = null) =>
            HardDeleteByAsync(where, parameters, transaction).GetAwaiter().GetResult();

        #endregion

        #region Batch CRUD (Sync)

        public List<int> AddRange(IEnumerable<T> entities, SqlTransaction? transaction = null) =>
            AddRangeAsync(entities, transaction).GetAwaiter().GetResult();

        public int EditRange(IEnumerable<T> entities, SqlTransaction? transaction = null) =>
            EditRangeAsync(entities, transaction).GetAwaiter().GetResult();

        public int DeleteRange(IEnumerable<int> ids, SqlTransaction? transaction = null) =>
            DeleteRangeAsync(ids, transaction).GetAwaiter().GetResult();

        #endregion
    }
}
