using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Core;
using Microsoft.Data.SqlClient;

namespace Data
{
    /// <summary>
    /// Generic entity-level audit trail. Call LogCreate/LogUpdate/LogDelete from inside the same save
    /// transaction as the record change so the audit row commits or rolls back with it — mirrors how
    /// NumberingService is threaded through the same transaction as the header Add.
    ///
    /// Serializes only the same "simple, mapped" properties SqlDataHelper&lt;T&gt; persists (same
    /// IsSimpleType filter, [NotMapped] excluded) — navigation properties and computed display-only
    /// fields are skipped, both to keep entries small and to avoid serializing circular object graphs
    /// (e.g. PurchaseRequestList.Created -> UsersList).
    /// </summary>
    public static class AuditService
    {
        public static void LogCreate(SqlTransaction tx, string entityName, int entityId, object newEntity, string? correlationId = null) =>
            Log(tx, entityName, entityId, "Create", null, newEntity, correlationId);

        public static void LogUpdate(SqlTransaction tx, string entityName, int entityId, object? oldEntity, object newEntity, string? correlationId = null) =>
            Log(tx, entityName, entityId, "Update", oldEntity, newEntity, correlationId);

        public static void LogDelete(SqlTransaction tx, string entityName, int entityId, object? oldEntity, string? correlationId = null) =>
            Log(tx, entityName, entityId, "Delete", oldEntity, null, correlationId);

        private static void Log(SqlTransaction tx, string entityName, int entityId, string action,
            object? oldEntity, object? newEntity, string? correlationId)
        {
            var con = tx.Connection ?? throw new InvalidOperationException("لا يوجد اتصال نشط مرتبط بهذه المعاملة.");

            using var cmd = new SqlCommand(
                @"INSERT INTO AuditLog (EntityName, EntityId, Action, UserId, Timestamp, OldValuesJson, NewValuesJson, CorrelationId, MachineName)
                  VALUES (@entityName, @entityId, @action, @userId, @timestamp, @oldValues, @newValues, @correlationId, @machine)", con, tx);

            cmd.Parameters.AddWithValue("@entityName", entityName);
            cmd.Parameters.AddWithValue("@entityId", entityId);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@userId", Session.CurrentUser?.Id ?? 0);
            cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
            cmd.Parameters.AddWithValue("@oldValues", (object?)Serialize(oldEntity) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@newValues", (object?)Serialize(newEntity) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@correlationId", (object?)correlationId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@machine", Session.Machine);

            cmd.ExecuteNonQuery();
        }

        private static string? Serialize(object? entity)
        {
            if (entity == null) return null;

            var values = entity.GetType().GetProperties()
                .Where(p => IsSimpleType(p.PropertyType))
                .Where(p => !Attribute.IsDefined(p, typeof(NotMappedAttribute)))
                .OrderBy(p => p.Name)
                .ToDictionary(p => p.Name, p => p.GetValue(entity));

            return JsonSerializer.Serialize(values);
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
    }
}
