using System.Data;
using Microsoft.Data.SqlClient;

namespace Data
{
    /// <summary>
    /// Centralized, concurrency-safe "next document number" generator — replaces the
    /// MAX(Num)+1-in-the-form pattern previously duplicated across each procurement Add/Edit form's
    /// private GetNextNumber method (a real race: two users saving in the same instant both read the
    /// same MAX and collide on the same number).
    ///
    /// Must be called from inside the caller's save transaction (the same one used for the header
    /// Add), passing that SqlTransaction. sp_getapplock with @LockOwner='Transaction' serializes
    /// concurrent callers for the same seriesKey and releases automatically at COMMIT/ROLLBACK — this
    /// also protects the very first call for a brand-new series (no unique index is needed on
    /// SeriesKey to prevent a duplicate-insert race, since DatabaseInitializer's schema-as-code has no
    /// way to declare one).
    /// </summary>
    public static class NumberingService
    {
        /// <param name="tx">The caller's in-progress save transaction.</param>
        /// <param name="entityName">Table/series name, e.g. "PurchaseRequestList".</param>
        /// <param name="period">Optional period key (e.g. calendar year) for series that reset
        /// periodically; null for a series with a single running sequence.</param>
        /// <param name="computeExistingMax">Computes the current MAX(Num) present in the target table.
        /// Called on every save and compared with the stored counter — whichever is higher wins.
        /// This corrects a counter that ran ahead of reality (e.g. records were deleted after being
        /// numbered, leaving gaps) without requiring a separate startup fixup.</param>
        public static int GetNextNumber(SqlTransaction tx, string entityName, int? period, Func<int> computeExistingMax)
        {
            string seriesKey = period.HasValue ? $"{entityName}:{period.Value}" : entityName;
            var con = tx.Connection ?? throw new InvalidOperationException("لا يوجد اتصال نشط مرتبط بهذه المعاملة.");

            using (var lockCmd = new SqlCommand("sp_getapplock", con, tx) { CommandType = CommandType.StoredProcedure })
            {
                lockCmd.Parameters.AddWithValue("@Resource", seriesKey);
                lockCmd.Parameters.AddWithValue("@LockMode", "Exclusive");
                lockCmd.Parameters.AddWithValue("@LockOwner", "Transaction");
                lockCmd.Parameters.AddWithValue("@LockTimeout", 15000);
                var returnValue = lockCmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                lockCmd.ExecuteNonQuery();
                if ((int)returnValue.Value < 0)
                    throw new InvalidOperationException($"تعذر الحصول على قفل الترقيم للسلسلة \"{seriesKey}\".");
            }

            int? id = null;
            int storedCurrent = 0;
            using (var selectCmd = new SqlCommand(
                "SELECT Id, CurrentValue FROM NumberSeriesCounter WHERE SeriesKey = @key", con, tx))
            {
                selectCmd.Parameters.AddWithValue("@key", seriesKey);
                using var reader = selectCmd.ExecuteReader();
                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                    storedCurrent = reader.GetInt32(1);
                }
            }

            // دائماً نحسب الرقم التالي بناءً على MAX(Num) الفعلي من قاعدة البيانات — هذا يصحح العداد
            // تلقائياً في كلا الحالتين:
            // • عداد متأخر (storedCurrent < dbMax): سجلات أُضيفت قبل هذه الخدمة أو بأرقام خارجها.
            // • عداد متقدم (storedCurrent > dbMax): سجلات حُذفت بعد أن حُجزت لها أرقام → العداد يسبق
            //   الواقع فيُصدر أرقاماً تتجاوز الترتيب الفعلي (مثلاً 70 بعد 67 بدلاً من 68).
            // الحل: نستخدم dbMax مباشرة كأساس، بغض النظر عن storedCurrent.
            int dbMax = computeExistingMax();
            int current = dbMax;

            int next = current + 1;


            if (id.HasValue)
            {
                using var updateCmd = new SqlCommand(
                    "UPDATE NumberSeriesCounter SET CurrentValue = @next WHERE Id = @id", con, tx);
                updateCmd.Parameters.AddWithValue("@next", next);
                updateCmd.Parameters.AddWithValue("@id", id.Value);
                updateCmd.ExecuteNonQuery();
            }
            else
            {
                using var insertCmd = new SqlCommand(
                    "INSERT INTO NumberSeriesCounter (SeriesKey, CurrentValue) VALUES (@key, @next)", con, tx);
                insertCmd.Parameters.AddWithValue("@key", seriesKey);
                insertCmd.Parameters.AddWithValue("@next", next);
                insertCmd.ExecuteNonQuery();
            }

            return next;
        }

        /// <summary>Rolls a series' counter back by one, but ONLY if <paramref name="number"/> is still
        /// the most recently issued number for that series (CurrentValue == number) — i.e. nothing has
        /// been numbered after it yet. Call this when hard-deleting a record that had reserved a
        /// number but never got submitted, so the very next GetNextNumber call reissues the same
        /// number instead of leaving a permanent gap. A no-op (by design) if anything newer has
        /// already been numbered in this series — rolling back then would either resurrect a number
        /// stuck behind ones already in use, or (if repeated) walk the counter backward past numbers
        /// still in use, producing duplicates. Must run inside the same transaction as the delete, for
        /// the same reason GetNextNumber must run inside the same transaction as the insert it numbers.</summary>
        public static void ReleaseIfLast(SqlTransaction tx, string entityName, int? period, int number)
        {
            string seriesKey = period.HasValue ? $"{entityName}:{period.Value}" : entityName;
            var con = tx.Connection ?? throw new InvalidOperationException("لا يوجد اتصال نشط مرتبط بهذه المعاملة.");

            using (var lockCmd = new SqlCommand("sp_getapplock", con, tx) { CommandType = CommandType.StoredProcedure })
            {
                lockCmd.Parameters.AddWithValue("@Resource", seriesKey);
                lockCmd.Parameters.AddWithValue("@LockMode", "Exclusive");
                lockCmd.Parameters.AddWithValue("@LockOwner", "Transaction");
                lockCmd.Parameters.AddWithValue("@LockTimeout", 15000);
                var returnValue = lockCmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                lockCmd.ExecuteNonQuery();
                if ((int)returnValue.Value < 0)
                    throw new InvalidOperationException($"تعذر الحصول على قفل الترقيم للسلسلة \"{seriesKey}\".");
            }

            using var updateCmd = new SqlCommand(
                "UPDATE NumberSeriesCounter SET CurrentValue = @prev WHERE SeriesKey = @key AND CurrentValue = @num",
                con, tx);
            updateCmd.Parameters.AddWithValue("@prev", number - 1);
            updateCmd.Parameters.AddWithValue("@key", seriesKey);
            updateCmd.Parameters.AddWithValue("@num", number);
            updateCmd.ExecuteNonQuery();
        }
    }
}
