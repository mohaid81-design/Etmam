using System.Data;
using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Services
{
    /// <summary>
    /// EF Core port of Data/NumberingService.cs. Takes the concrete ApplicationDbContext (not
    /// IApplicationDbContext) because sp_getapplock needs the raw SqlConnection/SqlTransaction
    /// underneath it - DI resolves both this and IApplicationDbContext to the SAME scoped
    /// ApplicationDbContext instance for one request, so they share the same connection/ambient
    /// transaction automatically.
    /// </summary>
    public sealed class NumberingService : INumberingService
    {
        private readonly ApplicationDbContext _context;

        public NumberingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetNextNumberAsync(string entityName, int? period, Func<Task<int>> computeExistingMaxAsync, CancellationToken ct = default)
        {
            string seriesKey = period.HasValue ? $"{entityName}:{period.Value}" : entityName;
            var (connection, transaction) = GetAmbientConnectionAndTransaction();

            await using (var lockCmd = new SqlCommand("sp_getapplock", connection, transaction) { CommandType = CommandType.StoredProcedure })
            {
                lockCmd.Parameters.AddWithValue("@Resource", seriesKey);
                lockCmd.Parameters.AddWithValue("@LockMode", "Exclusive");
                lockCmd.Parameters.AddWithValue("@LockOwner", "Transaction");
                lockCmd.Parameters.AddWithValue("@LockTimeout", 15000);
                var returnValue = lockCmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                await lockCmd.ExecuteNonQueryAsync(ct);
                if ((int)returnValue.Value < 0)
                    throw new InvalidOperationException($"تعذر الحصول على قفل الترقيم للسلسلة \"{seriesKey}\".");
            }

            int? id = null;
            await using (var selectCmd = new SqlCommand(
                "SELECT Id, CurrentValue FROM NumberSeriesCounter WHERE SeriesKey = @key", connection, transaction))
            {
                selectCmd.Parameters.AddWithValue("@key", seriesKey);
                await using var reader = await selectCmd.ExecuteReaderAsync(ct);
                if (await reader.ReadAsync(ct))
                    id = reader.GetInt32(0);
            }

            // Always derive the next number from the real MAX(Num), not the stored counter alone -
            // self-corrects both a lagging counter (rows numbered outside this service) and a
            // counter that ran ahead of reality (rows deleted after being numbered).
            int dbMax = await computeExistingMaxAsync();
            int next = dbMax + 1;

            if (id.HasValue)
            {
                await using var updateCmd = new SqlCommand(
                    "UPDATE NumberSeriesCounter SET CurrentValue = @next WHERE Id = @id", connection, transaction);
                updateCmd.Parameters.AddWithValue("@next", next);
                updateCmd.Parameters.AddWithValue("@id", id.Value);
                await updateCmd.ExecuteNonQueryAsync(ct);
            }
            else
            {
                await using var insertCmd = new SqlCommand(
                    "INSERT INTO NumberSeriesCounter (SeriesKey, CurrentValue) VALUES (@key, @next)", connection, transaction);
                insertCmd.Parameters.AddWithValue("@key", seriesKey);
                insertCmd.Parameters.AddWithValue("@next", next);
                await insertCmd.ExecuteNonQueryAsync(ct);
            }

            return next;
        }

        public async Task ReleaseIfLastAsync(string entityName, int? period, int number, CancellationToken ct = default)
        {
            string seriesKey = period.HasValue ? $"{entityName}:{period.Value}" : entityName;
            var (connection, transaction) = GetAmbientConnectionAndTransaction();

            await using (var lockCmd = new SqlCommand("sp_getapplock", connection, transaction) { CommandType = CommandType.StoredProcedure })
            {
                lockCmd.Parameters.AddWithValue("@Resource", seriesKey);
                lockCmd.Parameters.AddWithValue("@LockMode", "Exclusive");
                lockCmd.Parameters.AddWithValue("@LockOwner", "Transaction");
                lockCmd.Parameters.AddWithValue("@LockTimeout", 15000);
                var returnValue = lockCmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                await lockCmd.ExecuteNonQueryAsync(ct);
                if ((int)returnValue.Value < 0)
                    throw new InvalidOperationException($"تعذر الحصول على قفل الترقيم للسلسلة \"{seriesKey}\".");
            }

            await using var updateCmd = new SqlCommand(
                "UPDATE NumberSeriesCounter SET CurrentValue = @prev WHERE SeriesKey = @key AND CurrentValue = @num",
                connection, transaction);
            updateCmd.Parameters.AddWithValue("@prev", number - 1);
            updateCmd.Parameters.AddWithValue("@key", seriesKey);
            updateCmd.Parameters.AddWithValue("@num", number);
            await updateCmd.ExecuteNonQueryAsync(ct);
        }

        private (SqlConnection connection, SqlTransaction transaction) GetAmbientConnectionAndTransaction()
        {
            var connection = (SqlConnection)_context.Database.GetDbConnection();
            var transaction = (SqlTransaction?)_context.Database.CurrentTransaction?.GetDbTransaction()
                ?? throw new InvalidOperationException(
                    "NumberingService must run inside a transaction started via IApplicationDbContext.BeginTransactionAsync.");
            return (connection, transaction);
        }
    }
}
