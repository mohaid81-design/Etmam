using Microsoft.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core;

namespace Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            try
            {
                // 1. Ensure Database exists
                EnsureDatabaseExists();

                using (var con = new SqlConnection(DBSetting.GetConString()))
                {
                    con.Open();

                    // 2. Always apply structural fixups (safe IF NOT EXISTS guards)
                    ApplyFixups(con);

                    // 3. Fast Check: If SchemaHash matches, skip the (expensive) full column sync —
                    // tables/columns are already in place either way.
                    string currentHash = GetSchemaHash();
                    if (!IsSchemaUpToDate(con, currentHash))
                    {
                        // 4. Sync all tables from Core models
                        SyncAllTables(con);

                        // 4b. One-time backfill: ConstructionInspectionRequestList.FloorId (single int
                        // FK) was replaced by FloorIds (comma-separated string, supports multiple
                        // floors per request — see frmCIRAddEdit's lueFloor CheckedComboBoxEdit). The
                        // old FloorId column is never dropped by SyncColumns (additive-only), so copy
                        // its value into the new column once, right after SyncAllTables above just
                        // created FloorIds. Guarded by both columns existing and only fills rows not
                        // already migrated — safe to run every time this branch executes.
                        MigrateCIRFloorIds(con);

                        // 5. Update the schema hash for next startup
                        UpdateSchemaHash(con, currentHash);
                    }

                    // 6. Always (re-)seed master data — cheap, IF-NOT-EXISTS-guarded, and must run
                    // even when the schema hash hasn't changed, otherwise a fix to seed data alone
                    // (no entity shape change) would never reach the database. Runs after the sync
                    // step above so the tables it inserts into are guaranteed to exist.
                    SeedData(con);
                }

                // 7. Re-number the ItemCategory tree (Code/LvlId/SortId) on every startup — cheap,
                // no-op once codes already match (ItemCategoryCodeService only saves rows that
                // actually changed). Must run here, not only inside frmItemCategoryAddEdit, otherwise
                // a coding-scheme change (e.g. the M/C/S/E/R letter-prefix migration) only reaches
                // whichever admin happens to open "تصنيفات الأصناف" themselves — every other client
                // sharing this database would keep seeing the old codes on every other screen
                // (frmItemAddEdit's category picker, item code generation, reports, ...) until then.
                // Runs after SeedData (opens its own separate connection via DataContext.Shared) so
                // the 5 fixed roots already have their correct Code/ParentId to number from.
                ItemCategoryCodeService.RecalculateAndSave();

                // 8. Re-number ItemsList.Code (category's current Code + a 3-digit sequence) on every
                // startup, same reasoning and same cheap-no-op-when-unchanged behavior as step 7 above.
                // Must run after ItemCategoryCodeService.RecalculateAndSave() — item codes are built
                // from each item's category's *current* Code, so categories must already be correct.
                // Without this, item codes generated under the old (pre-M/C/S/E/R) category coding
                // scheme would stay stale/mismatched with their category's new Code indefinitely.
                ItemCodeService.RecalculateAndSave();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Database Initialization Error: {ex.Message}");
            }
        }

        /// <summary>
        /// One-time structural fixes: adds columns that were missing due to earlier type-mapping gaps.
        /// Safe to run every startup (uses IF NOT EXISTS).
        /// </summary>
        private static void ApplyFixups(SqlConnection con)
        {
            // DrawingAttachment.FileSizeKB was skipped because 'long' wasn't mapped → add it if missing.
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingAttachment')
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM sys.columns
                        WHERE object_id = OBJECT_ID('DrawingAttachment')
                          AND name = 'FileSizeKB')
                    BEGIN
                        ALTER TABLE [DrawingAttachment] ADD [FileSizeKB] INT NOT NULL DEFAULT 0
                    END
                END");

            // A few legacy ProjectsList rows predate IsDelete getting a NOT-NULL/default constraint, so
            // they still hold NULL instead of 0. Every "IsDelete = 0" filter in the app (GetBy calls,
            // the UserProjectAccess backfill below, etc.) silently excludes NULL rows — SQL's `NULL = 0`
            // is never true — so these projects were invisible to that filter even though they're not
            // actually deleted. Normalize once; safe to run every startup.
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ProjectsList')
                BEGIN
                    UPDATE ProjectsList SET IsDelete = 0 WHERE IsDelete IS NULL
                END");

            // PurchaseRequestStatus.Draft / PurchaseOrderStatus.Draft were renamed from "تحرير" to
            // "مسودة" — rows saved before this change still carry the old raw value, which would no
            // longer match the constant (falling through ToDisplay's default case, showing "—" instead
            // of the status). One-time data fixup so old and new drafts read the same going forward.
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PurchaseRequestList')
                BEGIN
                    UPDATE PurchaseRequestList SET OverallStatus = N'مسودة' WHERE OverallStatus = N'تحرير'
                END");
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PurchaseOrderList')
                BEGIN
                    UPDATE PurchaseOrderList SET OverallStatus = N'مسودة' WHERE OverallStatus = N'تحرير'
                END");

            // Every decimal column used to be created as DECIMAL(18,2) (see GetSqlType) — too coarse for
            // per-unit prices/fractional quantities on high-value lines. Widens any column still at the
            // old precision to DECIMAL(19,4) — a pure widening (more scale, one more digit of precision),
            // so existing values are preserved exactly (1234.56 becomes 1234.5600), never truncated or
            // rounded. Self-limiting: once every column has been widened, the WHERE clause matches
            // nothing and this becomes a no-op, so it's safe to run on every startup without a separate
            // "already applied" guard.
            ExecuteScript(con, @"
                DECLARE @sql NVARCHAR(MAX) = N'';

                SELECT @sql = @sql + N'ALTER TABLE [' + t.name + N'] ALTER COLUMN [' + c.name + N'] DECIMAL(19,4) NULL;' + CHAR(13)
                FROM sys.columns c
                JOIN sys.tables t ON c.object_id = t.object_id
                JOIN sys.types ty ON c.user_type_id = ty.user_type_id
                WHERE ty.name = 'decimal' AND c.precision = 18 AND c.scale = 2;

                IF LEN(@sql) > 0 EXEC sp_executesql @sql;");

            // مزامنة عداد الترقيم (NumberSeriesCounter) مع MAX(Num) الفعلي في PurchaseRequestList في
            // كلا الاتجاهين (زيادةً أو نقصاناً):
            // • إذا كان العداد أقل من MAX(Num): يحدث عندما حُسبت البداية بناءً على IsDelete=0 فأُهملت
            //   سجلات محذوفة تحمل أرقاماً أعلى → العداد متأخر → يُعيد إصدار أرقام مكررة.
            // • إذا كان العداد أكبر من MAX(Num): يحدث عندما تم حذف سجلات أُعطيت أرقاماً عالية بعد حفظها
            //   → العداد متقدم → يُصدر أرقاماً تتجاوز الترتيب الفعلي (مثلاً 70 بعد 67).
            // الإصلاح يعمل في كل بدء تشغيل ويصبح no-op حين يكون العداد صحيحاً.
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'NumberSeriesCounter')
                   AND EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PurchaseRequestList')
                BEGIN
                    UPDATE nsc
                    SET nsc.CurrentValue = mx.MaxNum
                    FROM NumberSeriesCounter nsc
                    CROSS APPLY (
                        SELECT MAX(ISNULL(prl.Num, 0)) AS MaxNum
                        FROM PurchaseRequestList prl
                        WHERE prl.RequestDate IS NOT NULL
                          AND YEAR(prl.RequestDate) = CAST(SUBSTRING(nsc.SeriesKey, LEN('PurchaseRequestList:') + 1, 4) AS INT)
                    ) mx
                    WHERE nsc.SeriesKey LIKE 'PurchaseRequestList:%'
                      AND mx.MaxNum <> nsc.CurrentValue
                END");
        }

        #region Core Steps
        private static void SyncAllTables(SqlConnection con)
        {
            // Scan Core assembly for model types
            var modelTypes = typeof(DailyReport).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && (t.Namespace == "Core" || t.Namespace == "Core.Tables"))
                .ToList();

            foreach (var type in modelTypes)
            {
                SyncTable(con, type);
            }
        }

        private static void MigrateCIRFloorIds(SqlConnection con)
        {
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('ConstructionInspectionRequestList') AND name = 'FloorId')
                   AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('ConstructionInspectionRequestList') AND name = 'FloorIds')
                BEGIN
                    UPDATE ConstructionInspectionRequestList
                    SET FloorIds = CAST(FloorId AS NVARCHAR(20))
                    WHERE FloorId IS NOT NULL AND (FloorIds IS NULL OR FloorIds = N'')
                END");
        }

        private static void SyncTable(SqlConnection con, Type type)
        {
            string tableName = type.Name;
            var properties = type.GetProperties()
                .Where(p => !Attribute.IsDefined(p, typeof(NotMappedAttribute)))
                .Where(p => GetSqlType(p) != null)
                .ToList();

            if (!properties.Any()) return;

            // 1. Ensure Table Exists
            if (!TableExists(con, tableName))
            {
                CreateTable(con, tableName, properties);
            }
            else
            {
                // 2. Self-healing: Ensure Columns Exist
                SyncColumns(con, tableName, properties);
            }
        }

        private static bool TableExists(SqlConnection con, string tableName)
        {
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM sys.tables WHERE name = @name", con))
            {
                cmd.Parameters.AddWithValue("@name", tableName);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private static void CreateTable(SqlConnection con, string tableName, List<PropertyInfo> properties)
        {
            var columnDefs = new List<string>();
            foreach (var prop in properties)
            {
                var sqlType = GetSqlType(prop);
                var isKey = Attribute.IsDefined(prop, typeof(KeyAttribute)) || prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase);

                var def = $"[{prop.Name}] {sqlType}";
                if (isKey)
                {
                    def += " PRIMARY KEY IDENTITY(1,1)";
                }
                columnDefs.Add(def);
            }

            var query = $"CREATE TABLE [{tableName}] ({string.Join(", ", columnDefs)})";
            ExecuteScript(con, query);
        }

        /// <summary>
        /// Adds any properties missing as columns on an existing table. Fetches the table's current
        /// column set in a single round-trip (was previously one ColumnExists() round-trip PER
        /// property PER table — with 100+ entity classes and 15+ properties each, that's 1000+
        /// sequential queries every time the schema hash changes, all running on the UI thread before
        /// any window is shown (see Program.cs), which reads as the app "freezing on startup".
        /// </summary>
        private static void SyncColumns(SqlConnection con, string tableName, List<PropertyInfo> properties)
        {
            var existingColumns = GetExistingColumns(con, tableName);

            foreach (var prop in properties)
            {
                if (!existingColumns.Contains(prop.Name))
                {
                    var sqlType = GetSqlType(prop);
                    var query = $"ALTER TABLE [{tableName}] ADD [{prop.Name}] {sqlType}";
                    ExecuteScript(con, query);
                }
            }
        }

        private static HashSet<string> GetExistingColumns(SqlConnection con, string tableName)
        {
            var columns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var query = "SELECT name FROM sys.columns WHERE object_id = OBJECT_ID(@table)";
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@table", $"[dbo].[{tableName}]");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        columns.Add(reader.GetString(0));
                }
            }
            return columns;
        }

        private static string? GetSqlType(PropertyInfo prop)
        {
            var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

            // A property literally named "RowVersion" of type byte[] is SqlDataHelper<T>'s convention
            // for opt-in optimistic-concurrency support (see its Add/EditAsync) — it needs SQL Server's
            // native auto-incrementing ROWVERSION type, not a plain VARBINARY(MAX), so every other
            // byte[] column (Signature, file blobs, ...) must keep going through the generic mapping below.
            if (type == typeof(byte[]) && prop.Name.Equals("RowVersion", StringComparison.OrdinalIgnoreCase))
                return "ROWVERSION";

            if (type == typeof(int)) return "INT";
            if (type == typeof(long)) return "INT";   // store as INT — KB values never exceed 2 billion
            if (type == typeof(string)) return "NVARCHAR(MAX)";
            if (type == typeof(DateTime)) return "DATETIME";
            // DECIMAL(19,4) — money and quantities both need 4 decimal places (a per-unit price or a
            // fractional quantity rounded to 2 places loses real precision on multi-thousand-unit lines).
            // See ApplyFixups for the one-time widening of columns already created as the old (18,2).
            if (type == typeof(decimal)) return "DECIMAL(19,4)";
            if (type == typeof(bool)) return "BIT";
            if (type == typeof(byte[])) return "VARBINARY(MAX)";
            if (type == typeof(Guid)) return "UNIQUEIDENTIFIER";
            if (type.IsEnum) return "INT";
            return null;
        }

        private static string GetSchemaHash()
        {
            var modelTypes = typeof(DailyReport).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && (t.Namespace == "Core" || t.Namespace == "Core.Tables"))
                .OrderBy(t => t.Name);

            var sb = new System.Text.StringBuilder();
            foreach (var type in modelTypes)
            {
                sb.Append(type.Name);
                var props = type.GetProperties()
                    .Where(p => !Attribute.IsDefined(p, typeof(NotMappedAttribute)))
                    .OrderBy(p => p.Name);

                foreach (var prop in props)
                {
                    sb.Append(prop.Name);
                    sb.Append(GetSqlType(prop));
                }
            }

            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
                return Convert.ToBase64String(bytes);
            }
        }

        private static bool IsSchemaUpToDate(SqlConnection con, string hash)
        {
            try
            {
                if (!TableExists(con, "SystemSettings")) return false;

                var query = "SELECT SettingValue FROM SystemSettings WHERE SettingKey = 'SchemaHash'";
                using (var cmd = new SqlCommand(query, con))
                {
                    var result = cmd.ExecuteScalar();
                    return result != null && result.ToString() == hash;
                }
            }
            catch
            {
                return false;
            }
        }

        private static void UpdateSchemaHash(SqlConnection con, string hash)
        {
            try
            {
                // Ensure SystemSettings exists (though it should have been created by SyncAllTables)
                // UPSERT logic for SchemaHash
                var query = @"
                    IF EXISTS (SELECT 1 FROM SystemSettings WHERE SettingKey = 'SchemaHash')
                        UPDATE SystemSettings SET SettingValue = @hash WHERE SettingKey = 'SchemaHash'
                    ELSE
                        INSERT INTO SystemSettings (SettingKey, SettingValue, Description) VALUES ('SchemaHash', @hash, 'Used for fast database initialization check')"
                ;
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@hash", hash);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
        #endregion

        private static void EnsureDatabaseExists()
        {
            var masterCon = GetMasterConnectionString();
            using (var con = new SqlConnection(masterCon))
            {
                con.Open();
                var cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'EtmamDB') CREATE DATABASE [EtmamDB]", con);
                cmd.ExecuteNonQuery();
            }
        }

        private static void SeedData(SqlConnection con)
        {
            // Seed Admin User
            var checkAdmin = "SELECT COUNT(*) FROM UsersList WHERE UserName = 'admin'";
            using (var cmd = new SqlCommand(checkAdmin, con))
            {
                if ((int)cmd.ExecuteScalar() == 0)
                {
                    using (var insertCmd = new SqlCommand(
                        "INSERT INTO UsersList (UserName, Password, Role, IsActive, IsFirstLogin) VALUES (@UserName, @Password, @Role, 1, 1)", con))
                    {
                        insertCmd.Parameters.AddWithValue("@UserName", "admin");
                        insertCmd.Parameters.AddWithValue("@Password", Core.Security.PasswordHasher.Hash("admin"));
                        insertCmd.Parameters.AddWithValue("@Role", "Admin");
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }

            // Seed Permissions
            // Column names must match the actual PermissionsList entity (Id/Name/ParentID/SortID) —
            // earlier versions of this script used IdParent/Description, which don't exist on the
            // table, so every INSERT below silently failed (swallowed by Initialize()'s outer catch)
            // and CanApprove() checks threw for any non-admin user. Fixed to use ParentID/Name.
            //
            // The full ribbon/menu permission tree (mirrors every section+item captioned in
            // frmMainPage.Designer.cs, referenced from code via Etmam.PermNames — see
            // Data/PermissionService.cs) used to exist only as live data created by hand through
            // frmPermissionsAddEdit, so a fresh database never got it and frmMainPage.SetButtonEnabled
            // had nothing to check against for a new user. Seeded here instead, idempotent by Name
            // (never by a hard-coded Id — a live-database check found earlier hard-coded Ids had
            // already drifted from the real rows), so it's purely additive and safe to run against a
            // database that already has real, admin-configured permission data.
            ExecuteScript(con, @"
                -- Pass 1: top-level ribbon sections (ParentID IS NULL)
                INSERT INTO PermissionsList (ParentID, Name, SortID)
                SELECT NULL, v.Name, v.SortID
                FROM (VALUES
                    (N'الرئيسية', 1),
                    (N'إدارة المشروعات', 2),
                    (N'إدارة جداول الكميات (المقايسة)', 18),
                    (N'إدارة الموازنة والتقدير', 19),
                    (N'إدارة المستندات', 3),
                    (N'إداره التكاليف', 4),
                    (N'إدارة مقاولي الباطن', 5),
                    (N'إدارة المطالبات', 6),
                    (N'إدارة المشتريات', 7),
                    (N'إدارة المخزون', 8),
                    (N'إدارة الإجراءات', 9),
                    (N'إدارة التخطيط والجدول الزمني', 10),
                    (N'إدارة العقود', 11),
                    (N'إدارة المستندات والوثائق EDMS', 12),
                    (N'إدارة المراسلات والبريد المؤسسي', 13),
                    (N'إدارة الجودة QMS', 14),
                    (N'إدارة السلامة والصحة والبيئة HSE', 15),
                    (N'إدارة وضبط التكاليف Cost Control', 16),
                    (N'الإعدادات', 17)
                ) AS v(Name, SortID)
                WHERE NOT EXISTS (
                    SELECT 1 FROM PermissionsList p
                    WHERE p.Name = v.Name AND (p.ParentID IS NULL OR p.ParentID = 0)
                )

                -- Pass 2: leaf items nested under a top-level section
                INSERT INTO PermissionsList (ParentID, Name, SortID)
                SELECT parent.Id, v.ChildName, v.SortID
                FROM (VALUES
                    (N'الرئيسية', N'شاشة التحكم الرئيسية', 1),

                    (N'إدارة المشروعات', N'نوع المشروع', 1),
                    (N'إدارة المشروعات', N'حالة العقد', 2),
                    (N'إدارة المشروعات', N'موقف المشروع', 3),
                    (N'إدارة المشروعات', N'بيانات المشروع', 4),
                    (N'إدارة المشروعات', N'جدول الكميات والمواصفات', 5),
                    (N'إدارة المشروعات', N'هيل تجزئة المشروع', 6),
                    (N'إدارة المشروعات', N'المباني', 7),
                    (N'إدارة المشروعات', N'الطوابق', 8),
                    (N'إدارة المشروعات', N'قائمة المشاريع', 9),
                    (N'إدارة المشروعات', N'فريق العمل', 10),
                    (N'إدارة المشروعات', N'الجدول الزمني', 11),
                    (N'إدارة المشروعات', N'ملخص الموازنة', 12),
                    (N'إدارة المشروعات', N'مستندات المشروع', 13),
                    (N'إدارة المشروعات', N'المخاطر', 14),
                    (N'إدارة المشروعات', N'المشكلات', 15),
                    (N'إدارة المشروعات', N'المراسلات', 16),
                    (N'إدارة المشروعات', N'الاجتماعات', 17),
                    (N'إدارة المشروعات', N'التقدم', 18),
                    (N'إدارة المشروعات', N'ضبط التكلفة', 19),
                    (N'إدارة المشروعات', N'لوحة معلومات المشروع', 20),
                    (N'إدارة المشروعات', N'إغلاق المشروع', 21),

                    (N'إدارة جداول الكميات (المقايسة)', N'مستكشف جدول الكميات', 1),
                    (N'إدارة جداول الكميات (المقايسة)', N'تحرير جدول الكميات', 2),
                    (N'إدارة جداول الكميات (المقايسة)', N'مقارنة جداول الكميات', 3),
                    (N'إدارة جداول الكميات (المقايسة)', N'إدارة إصدارات جدول الكميات', 4),
                    (N'إدارة جداول الكميات (المقايسة)', N'تحليل جدول الكميات', 5),
                    (N'إدارة جداول الكميات (المقايسة)', N'اعتماد جدول الكميات', 6),
                    (N'إدارة جداول الكميات (المقايسة)', N'تقارير جدول الكميات', 7),

                    (N'إدارة الموازنة والتقدير', N'لوحة الموازنة', 1),
                    (N'إدارة الموازنة والتقدير', N'قائمة الموازنات', 2),
                    (N'إدارة الموازنة والتقدير', N'محرر الموازنة', 3),
                    (N'إدارة الموازنة والتقدير', N'هيكل تجزئة التكلفة (CBS)', 4),
                    (N'إدارة الموازنة والتقدير', N'معالج استيراد الموازنة', 5),
                    (N'إدارة الموازنة والتقدير', N'مراجعات الموازنة', 6),
                    (N'إدارة الموازنة والتقدير', N'توقعات التدفق النقدي', 7),
                    (N'إدارة الموازنة والتقدير', N'الموازنة مقابل الفعلي', 8),
                    (N'إدارة الموازنة والتقدير', N'توقع التكلفة (EVM)', 9),
                    (N'إدارة الموازنة والتقدير', N'مسار اعتماد الموازنة', 10),
                    (N'إدارة الموازنة والتقدير', N'تقارير الموازنة', 11),

                    (N'إدارة المستندات', N'طلب فحص اعمال (CIR)', 1),
                    (N'إدارة المستندات', N'طلب فحص مواد (MIR)', 2),
                    (N'إدارة المستندات', N'طلب اعتماد مواد (MAR)', 3),
                    (N'إدارة المستندات', N'طلب اعتماد مخططات', 4),
                    (N'إدارة المستندات', N'نموذج تقديم مستند (DSF)', 5),
                    (N'إدارة المستندات', N'التقرير اليومي (DR)', 6),
                    (N'إدارة المستندات', N'طلبات صب الخرسانة', 7),
                    (N'إدارة المستندات', N'نتائج إختبارات الخرسانة', 8),

                    (N'إداره التكاليف', N'مراكز التكلفة', 1),
                    (N'إداره التكاليف', N'دليل الحسابات', 2),
                    (N'إداره التكاليف', N'بنود الأعمال', 3),
                    (N'إداره التكاليف', N'وحدات القياس', 4),
                    (N'إداره التكاليف', N'هيكل تجزئه التكلفة', 5),
                    (N'إداره التكاليف', N'الموازنة التقديرية', 6),
                    (N'إداره التكاليف', N'مستخلص المالك', 7),
                    (N'إداره التكاليف', N'تقرير التباين', 8),

                    (N'إدارة مقاولي الباطن', N'قائمة مقاولي الباطن', 1),
                    (N'إدارة مقاولي الباطن', N'عقد مقاول باطن', 2),
                    (N'إدارة مقاولي الباطن', N'مستخلص مقاول باطن', 3),
                    (N'إدارة مقاولي الباطن', N'تقارير مقاولي الباطن', 4),

                    (N'إدارة المطالبات', N'طلب تصديق مالي', 1),
                    (N'إدارة المطالبات', N'تصفية عهدة', 2),
                    (N'إدارة المطالبات', N'طلب عمالة مؤقتة', 3),
                    (N'إدارة المطالبات', N'طلب معدات واليات', 4),
                    (N'إدارة المطالبات', N'مطالبة ايجار معدات', 5),
                    (N'إدارة المطالبات', N'مطالبة عماله مؤقتة', 6),

                    (N'إدارة المشتريات', N'الموردين', 1),
                    (N'إدارة المشتريات', N'طلبات عروض الأسعار (RFQ)', 7),
                    (N'إدارة المشتريات', N'عروض الموردين', 2),
                    (N'إدارة المشتريات', N'طلبات الشراء', 3),
                    (N'إدارة المشتريات', N'اوامر الشراء', 4),
                    (N'إدارة المشتريات', N'تعديلات أوامر الشراء', 8),
                    (N'إدارة المشتريات', N'تقارير المشتريات', 5),
                    (N'إدارة المشتريات', N'الإدارات الطالبة', 6),
                    (N'إدارة المشتريات', N'التخصصات', 9),
                    (N'إدارة المشتريات', N'التخصصات الثانوية', 10),
                    (N'إدارة المشتريات', N'أنشطة الفحص', 11),
                    (N'إدارة المشتريات', N'لوحة التحكم', 12),
                    (N'إدارة المشتريات', N'دليل المشتريات', 13),
                    (N'إدارة المشتريات', N'منصة عمل المشتريات', 14),
                    (N'إدارة المشتريات', N'التقييم الفني', 15),
                    (N'إدارة المشتريات', N'مقارنة العروض', 16),
                    (N'إدارة المشتريات', N'التفاوض', 17),
                    (N'إدارة المشتريات', N'توصيات الترسية', 18),
                    (N'إدارة المشتريات', N'صندوق الإعتمادات', 19),

                    (N'إدارة المخزون', N'المخازن', 1),
                    (N'إدارة المخزون', N'الأصناف', 2),
                    (N'إدارة المخزون', N'إذن إستلام', 3),
                    (N'إدارة المخزون', N'إذن صرف', 4),
                    (N'إدارة المخزون', N'التحويل بين المخازن', 5),
                    (N'إدارة المخزون', N'مرتجع مشتريات', 6),
                    (N'إدارة المخزون', N'مرتجع صرف', 7),
                    (N'إدارة المخزون', N'رصيد افتتاحي', 8),
                    (N'إدارة المخزون', N'جرد المخزون', 9),
                    (N'إدارة المخزون', N'تقارير المخزون', 10),

                    (N'إدارة الإجراءات', N'مهامي', 1),
                    (N'إدارة الإجراءات', N'تعريف الإجراءات', 2),
                    (N'إدارة الإجراءات', N'مصفوفة الاعتماد', 3),

                    (N'إدارة التخطيط والجدول الزمني', N'لوحة تحكم التخطيط', 1),
                    (N'إدارة التخطيط والجدول الزمني', N'الجداول الزمنية', 2),
                    (N'إدارة التخطيط والجدول الزمني', N'مستكشف الجدول الزمني', 3),
                    (N'إدارة التخطيط والجدول الزمني', N'محرر الأنشطة', 4),
                    (N'إدارة التخطيط والجدول الزمني', N'إدارة الخطوط المرجعية', 5),
                    (N'إدارة التخطيط والجدول الزمني', N'تحديث نسب الإنجاز', 6),
                    (N'إدارة التخطيط والجدول الزمني', N'التخطيط المستقبلي (Look-Ahead)', 7),
                    (N'إدارة التخطيط والجدول الزمني', N'المراحل الرئيسية (Milestones)', 8),
                    (N'إدارة التخطيط والجدول الزمني', N'تخطيط الموارد', 9),
                    (N'إدارة التخطيط والجدول الزمني', N'تحليل التأخيرات والمطالبات', 10),
                    (N'إدارة التخطيط والجدول الزمني', N'مقارنة الجداول الزمنية', 11),
                    (N'إدارة التخطيط والجدول الزمني', N'معالج استيراد وتصدير الجداول', 12),
                    (N'إدارة التخطيط والجدول الزمني', N'تقارير التخطيط', 13),

                    (N'إدارة العقود', N'لوحة تحكم العقود', 1),
                    (N'إدارة العقود', N'سجل العقود', 2),
                    (N'إدارة العقود', N'تفاصيل العقد', 3),
                    (N'إدارة العقود', N'سجل الالتزامات التعاقدية', 4),
                    (N'إدارة العقود', N'المراسلات والخطابات التعاقدية', 5),
                    (N'إدارة العقود', N'أوامر التغيير (VO)', 6),
                    (N'إدارة العقود', N'المطالبات والنزاعات', 7),
                    (N'إدارة العقود', N'طلبات تمديد الوقت (EOT)', 8),
                    (N'إدارة العقود', N'الخطابات والضمانات البنكية', 9),
                    (N'إدارة العقود', N'المستخلصات التعاقدية', 10),
                    (N'إدارة العقود', N'إدارة المحتجزات النقدية', 11),
                    (N'إدارة العقود', N'تعديلات وملحقات العقود', 12),
                    (N'إدارة العقود', N'سجل مخاطر العقود', 13),
                    (N'إدارة العقود', N'إغلاق العقود النهائي', 14),
                    (N'إدارة العقود', N'تقارير العقود', 15),

                    (N'إدارة المستندات والوثائق EDMS', N'لوحة تحكم الوثائق EDMS', 1),
                    (N'إدارة المستندات والوثائق EDMS', N'سجل المستندات والوثائق', 2),
                    (N'إدارة المستندات والوثائق EDMS', N'تفاصيل المستند والخصائص', 3),
                    (N'إدارة المستندات والوثائق EDMS', N'سجل الرسومات الهندسية', 4),
                    (N'إدارة المستندات والوثائق EDMS', N'طلبات اعتماد المواد (MSR)', 5),
                    (N'إدارة المستندات والوثائق EDMS', N'طلب المعلومات والطلبات الفنية (RFI)', 6),
                    (N'إدارة المستندات والوثائق EDMS', N'الاستفسارات الفنية (TQ)', 7),
                    (N'إدارة المستندات والوثائق EDMS', N'خطابات التسليم والارسال (Transmittals)', 8),
                    (N'إدارة المستندات والوثائق EDMS', N'المراسلات والخطابات الواردة', 9),
                    (N'إدارة المستندات والوثائق EDMS', N'المراسلات والخطابات الصادرة', 10),
                    (N'إدارة المستندات والوثائق EDMS', N'اعتمادات ومراجعات المستندات', 11),
                    (N'إدارة المستندات والوثائق EDMS', N'سجل وتتبع الإصدارات (Version Control)', 12),
                    (N'إدارة المستندات والوثائق EDMS', N'مصفوفة التوزيع والارسال', 13),
                    (N'إدارة المستندات والوثائق EDMS', N'أرشيف الوثائق والمستندات', 14),
                    (N'إدارة المستندات والوثائق EDMS', N'تقارير نظام الوثائق', 15),

                    (N'إدارة المراسلات والبريد المؤسسي', N'لوحة تحكم المراسلات', 1),
                    (N'إدارة المراسلات والبريد المؤسسي', N'صندوق المراسلات الواردة (Inbox)', 2),
                    (N'إدارة المراسلات والبريد المؤسسي', N'صندوق المراسلات الصادرة (Outbox)', 3),
                    (N'إدارة المراسلات والبريد المؤسسي', N'سجل المذكرات الداخلية (Internal Memos)', 4),
                    (N'إدارة المراسلات والبريد المؤسسي', N'إدارة التعاميم والنشرات (Circulars)', 5),
                    (N'إدارة المراسلات والبريد المؤسسي', N'محاضر الاجتماعات (Meeting Minutes)', 6),
                    (N'إدارة المراسلات والبريد المؤسسي', N'تفاصيل المراسلة والخصائص', 7),
                    (N'إدارة المراسلات والبريد المؤسسي', N'مركز تكامل البريد الإلكتروني Outlook', 8),
                    (N'إدارة المراسلات والبريد المؤسسي', N'قوائم التوزيع والارسال', 9),
                    (N'إدارة المراسلات والبريد المؤسسي', N'تتبع الإجراءات والتكليفات', 10),
                    (N'إدارة المراسلات والبريد المؤسسي', N'تتبع الإقرارات والإشطارات', 11),
                    (N'إدارة المراسلات والبريد المؤسسي', N'سير اعتماد المراسلات', 12),
                    (N'إدارة المراسلات والبريد المؤسسي', N'أرشيف وبحث المراسلات', 13),
                    (N'إدارة المراسلات والبريد المؤسسي', N'تقارير المراسلات والبريد', 14),
                    (N'إدارة المراسلات والبريد المؤسسي', N'مراقب مزامنة صناديق البريد', 15),

                    (N'إدارة الجودة QMS', N'لوحة تحكم الجودة', 1),
                    (N'إدارة الجودة QMS', N'سجل طلبات الفحص (IR)', 2),
                    (N'إدارة الجودة QMS', N'نموذج وفحوصات الموقع (IR Form)', 3),
                    (N'إدارة الجودة QMS', N'خطة الفحص والاختبار (ITP)', 4),
                    (N'إدارة الجودة QMS', N'مكتبة القوائم المرجعية (Checklists)', 5),
                    (N'إدارة الجودة QMS', N'سجل فحص المواد والموردات', 6),
                    (N'إدارة الجودة QMS', N'فحوصات الجودة الميدانية', 7),
                    (N'إدارة الجودة QMS', N'سجل تقارير عدم المطابقة (NCR)', 8),
                    (N'إدارة الجودة QMS', N'تفاصيل ومراحل تقرير عدم المطابقة', 9),
                    (N'إدارة الجودة QMS', N'الإجراءات التصحيحية والوقائية (CAPA)', 10),
                    (N'إدارة الجودة QMS', N'إدارة نواقص النواحي والـ Punch List', 11),
                    (N'إدارة الجودة QMS', N'سجل الملاحظات العاجلة (Snag List)', 12),
                    (N'إدارة الجودة QMS', N'معالج وفحوصات الاستلام النهائي (Handover)', 13),
                    (N'إدارة الجودة QMS', N'إدارة الصيانة وفترة الضمان (Defect Liability)', 14),
                    (N'إدارة الجودة QMS', N'تقارير ومؤشرات الجودة QMS', 15),

                    (N'إدارة السلامة والصحة والبيئة HSE', N'لوحة تحكم السلامة والبيئة', 1),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'سجل الحوادث والإصابات (Incidents)', 2),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'تحقيق ودراسة أسباب الحوادث', 3),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'سجل الحوادث الوشيكة (Near Miss)', 4),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'سجل المخاطر والمكاره (Hazard Register)', 5),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'تقييم المخاطر وتحليل السلامة (JSA/JHA)', 6),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'سجل تصاريح العمل (Permit To Work - PTW)', 7),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'جولات وفحوصات السلامة الميدانية', 8),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'اجتماعات ومحادثات السلامة (Toolbox Talks)', 9),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'سجل ودورات التدريب وتراخيص السلامة', 10),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'إدارة وسجل أدوات الوقاية الشخصية (PPE)', 11),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'فحص واختبار معدات السلامة والآلات', 12),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'سجل وقراءات الرصد البيئي', 13),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'مخطط وفرضيات خطط الطوارئ', 14),
                    (N'إدارة السلامة والصحة والبيئة HSE', N'تقارير ومؤشرات السلامة والبيئة HSE', 15),

                    (N'إدارة وضبط التكاليف Cost Control', N'لوحة تحكم ضبط التكاليف (Cost Dashboard)', 1),
                    (N'إدارة وضبط التكاليف Cost Control', N'هيكل تجزئة التكاليف (CBS)', 2),
                    (N'إدارة وضبط التكاليف Cost Control', N'التزامات التكاليف (Cost Commitments)', 3),
                    (N'إدارة وضبط التكاليف Cost Control', N'الموازنة مقابل الالتزامات (Budget vs Commitment)', 4),
                    (N'إدارة وضبط التكاليف Cost Control', N'الموازنة مقابل التكلفة الفعلية (Budget vs Actual)', 5),
                    (N'إدارة وضبط التكاليف Cost Control', N'إدارة القيمة المكتسبة (EVM)', 6),
                    (N'إدارة وضبط التكاليف Cost Control', N'توقعات التكلفة النهائية (EAC / ETC)', 7),
                    (N'إدارة وضبط التكاليف Cost Control', N'تحليل التدفقات النقدية (Cash Flow)', 8),
                    (N'إدارة وضبط التكاليف Cost Control', N'مستخلصات المالك (Owner IPC)', 9),
                    (N'إدارة وضبط التكاليف Cost Control', N'مستخلصات مقاولي الباطن (Subcontractor IPC)', 10),
                    (N'إدارة وضبط التكاليف Cost Control', N'تحليل انحرافات التكاليف (Cost Variance)', 11),
                    (N'إدارة وضبط التكاليف Cost Control', N'تحليل اتجاهات التكاليف (Cost Trends)', 12),
                    (N'إدارة وضبط التكاليف Cost Control', N'سيناريوهات توقعات التكلفة (Forecast Scenarios)', 13),
                    (N'إدارة وضبط التكاليف Cost Control', N'المراجعة التنفيذية للتكاليف (Executive Review)', 14),
                    (N'إدارة وضبط التكاليف Cost Control', N'تقارير ومؤشرات التكاليف (Cost Reports)', 15),

                    (N'الإعدادات', N'إدارة المستخدمين', 1),
                    (N'الإعدادات', N'إدارة الصلاحيات', 2),
                    (N'الإعدادات', N'اتصال بالشبكة', 3),
                    (N'الإعدادات', N'إنشاء نسخة احتياطيه', 4),
                    (N'الإعدادات', N'إستعادة نسخة احتياطية', 5)
                ) AS v(ParentName, ChildName, SortID)
                JOIN PermissionsList parent ON parent.Name = v.ParentName AND (parent.ParentID IS NULL OR parent.ParentID = 0)
                WHERE NOT EXISTS (
                    SELECT 1 FROM PermissionsList c WHERE c.Name = v.ChildName AND c.ParentID = parent.Id
                )");

            // One-time cleanup: the procurement section's name flip-flopped — originally seeded as
            // N'إدارة المشتريات', briefly renamed to N'إدارة المشتريات و العقود' and back again (see
            // PermNames.PurchaseMgtSection) — and because the seed above is idempotent BY NAME, any
            // database that had already run a differently-named seed got a brand new row under the new
            // name instead of a rename, leaving the other name behind as an orphaned top-level permission
            // with no children. Visible as a confusing duplicate in frmUsersMgt's permissions tree, and a
            // trap for an admin who grants the wrong (unchecked-by-code) row by mistake. This merges
            // whichever of the two names is NOT the current N'إدارة المشتريات' into it — reassigning
            // children (defensive; the seed above always attaches to the current name so there normally
            // are none), migrating user grants (fixing exactly that "granted but doesn't show" trap
            // retroactively), then removing the other row. No-op once already merged (@OtherId comes back
            // NULL, or only one of the two names exists at all).
            ExecuteScript(con, @"
                DECLARE @CorrectId INT, @OtherId INT
                SELECT @CorrectId = Id FROM PermissionsList WHERE Name = N'إدارة المشتريات' AND (ParentID IS NULL OR ParentID = 0)
                SELECT @OtherId = Id FROM PermissionsList WHERE Name = N'إدارة المشتريات و العقود' AND (ParentID IS NULL OR ParentID = 0)

                IF @CorrectId IS NULL AND @OtherId IS NOT NULL
                BEGIN
                    -- Only the other-named row exists (e.g. a prior run already renamed it away from
                    -- N'إدارة المشتريات') — no duplicate to merge, just rename it back.
                    UPDATE PermissionsList SET Name = N'إدارة المشتريات' WHERE Id = @OtherId
                END
                ELSE IF @CorrectId IS NOT NULL AND @OtherId IS NOT NULL AND @CorrectId <> @OtherId
                BEGIN
                    UPDATE PermissionsList SET ParentID = @CorrectId WHERE ParentID = @OtherId

                    UPDATE ups SET ups.PermsID = @CorrectId
                    FROM UserPermissionStatus ups
                    WHERE ups.PermsID = @OtherId
                      AND NOT EXISTS (SELECT 1 FROM UserPermissionStatus x WHERE x.UserID = ups.UserID AND x.PermsID = @CorrectId)

                    DELETE FROM UserPermissionStatus WHERE PermsID = @OtherId

                    DELETE FROM PermissionsList WHERE Id = @OtherId
                END");

            // Three call sites below all seed a handful of "toolbar action" leaves nested two levels
            // deep under an existing (section, leaf) pair — frmUsersMgt's own buttons under Settings >
            // إدارة المستخدمين, frmCIRAddEdit's under إدارة المستندات > طلب فحص اعمال (CIR), and
            // frmPurchaseRequestAddEdit's under إدارة المشتريات > طلبات الشراء. All three used
            // to be copy-pasted INSERT/CROSS JOIN/WHERE NOT EXISTS scripts identical but for the
            // (section, leaf) pair and the (name, sortId) list — consolidated into SeedNestedLeafPermissions
            // below (same idempotent-by-Name guard, same generated SQL shape).
            SeedNestedLeafPermissions(con, "الإعدادات", "إدارة المستخدمين", new (string Name, int SortId)[]
            {
                ("إضافة مستخدم", 1),
                ("تعديل مستخدم", 2),
                ("تعديل كلمة السر", 3),
                ("تفعيل/تعطيل مستخدم", 4),
                ("التوقيع الإلكتروني", 5),
                ("الصلاحيات", 6),
                ("حذف مستخدم", 7)
            });

            // Gates frmCIRAddEdit's own toolbar actions (Add/Save/Print/Send/Reissue/Delete) plus the
            // CST review fields on its Log tab (CIRConsultantAction — see frmCIRAddEdit.
            // ApplyConsultantActionReadOnly), nested under إدارة المستندات > طلب فحص اعمال (CIR) —
            // distinct from that leaf itself (PermNames.InspectionRequest, which only gates whether the
            // module/list is reachable at all). See PermNames.CIRAdd etc.
            SeedNestedLeafPermissions(con, "إدارة المستندات", "طلب فحص اعمال (CIR)", new (string Name, int SortId)[]
            {
                ("إضافة طلب فحص", 1),
                ("حفظ طلب فحص", 2),
                ("طباعة طلب فحص", 3),
                ("إرسال طلب فحص", 4),
                ("إعادة إصدار طلب فحص", 5),
                ("حذف طلب فحص", 6),
                ("إجراء الاستشاري/المالك", 7),
                ("اعتماد طلب فحص", 8)
            });

            // Gates frmPurchaseRequestAddEdit's own toolbar actions (Add/Save/Print/Send/Delete/Return-
            // for-edit/Close), nested under إدارة المشتريات > طلبات الشراء — distinct from that
            // leaf itself (PermNames.PurchaseRequest, which only gates whether the module/list is
            // reachable at all). اعتماد/رفض/إعادة أثناء الاعتماد ليست هنا عمداً — تبقى محكومة فقط بمن
            // أُسندت إليه خطوة الإجراء الحالية (WorkflowEngine.CanUserAct). See PermNames.PRAdd etc.
            // "تصدير طلبات الشراء" (PRExport) هي الاستثناء الوحيد هنا بلا مقابل في
            // frmPurchaseRequestAddEdit — تخص فقط تصدير Excel من ucPurchaseRequests.
            SeedNestedLeafPermissions(con, "إدارة المشتريات", "طلبات الشراء", new (string Name, int SortId)[]
            {
                ("إضافة طلب شراء", 1),
                ("حفظ طلب شراء", 2),
                ("طباعة طلب شراء", 3),
                ("إرسال طلب شراء للاعتماد", 4),
                ("حذف طلب شراء", 5),
                ("إعادة طلب شراء لمسودة", 6),
                ("إغلاق طلب شراء", 7),
                ("تصدير طلبات الشراء", 8)
            });

            // Gates frmPurchaseOrderAddEdit/ucPurchaseOrder's own toolbar actions (Add/Save/Print/Send/
            // Delete/Return-for-edit), nested under إدارة المشتريات > اوامر الشراء — distinct from that
            // leaf itself (PermNames.PurchaseOrder, which only gates whether the module/list is reachable
            // at all). Same pattern as طلبات الشراء above — see PermNames.POAdd etc. اعتماد/رفض أمر الشراء
            // ليست هنا عمداً — تبقى محكومة فقط بمن أُسندت إليه خطوة الإجراء الحالية (WorkflowEngine.CanUserAct).
            SeedNestedLeafPermissions(con, "إدارة المشتريات", "اوامر الشراء", new (string Name, int SortId)[]
            {
                ("إضافة أمر شراء", 1),
                ("حفظ أمر شراء", 2),
                ("طباعة أمر شراء", 3),
                ("إرسال أمر شراء للاعتماد", 4),
                ("حذف أمر شراء", 5),
                ("إعادة أمر شراء لمسودة", 6)
            });

            // Legacy: used to gate the flat اعتماد/رفض actions on Purchase Orders before PO approval moved
            // to the generic workflow engine (per-step assignees now gate this — see PurchaseOrderWorkflowSync).
            // Left seeded (not deleted) so any user already granted it isn't silently affected.
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT 1 FROM PermissionsList WHERE Name = N'اعتماد أوامر الشراء')
                BEGIN
                    INSERT INTO PermissionsList (ParentID, Name) VALUES (NULL, N'اعتماد أوامر الشراء')
                END");

            // Gates إضافة/تعديل/حذف on Stores (see StorePermissions).
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT 1 FROM PermissionsList WHERE Name = N'إدارة المخازن')
                BEGIN
                    INSERT INTO PermissionsList (ParentID, Name) VALUES (NULL, N'إدارة المخازن')
                END");

            // Gates access to SettingsForm's Approvals section (see SystemSettingsPermissions) —
            // includes the separation-of-duties approval toggle (SeparationOfDutiesHelper).
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT 1 FROM PermissionsList WHERE Name = N'إدارة إعدادات النظام')
                BEGIN
                    INSERT INTO PermissionsList (ParentID, Name) VALUES (NULL, N'إدارة إعدادات النظام')
                END");

            // Gates seeing commercial figures during Technical Evaluation (see PermNames.ViewCommercialPrices
            // and frmTechnicalEvaluationAddEdit) — nested under the existing "عروض الموردين" leaf so it reads
            // as a sub-permission of the quotation module rather than a new top-level item.
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT 1 FROM PermissionsList WHERE Name = N'رؤية الأسعار التجارية')
                BEGIN
                    INSERT INTO PermissionsList (ParentID, Name)
                    SELECT p.Id, N'رؤية الأسعار التجارية'
                    FROM PermissionsList p
                    WHERE p.Name = N'عروض الموردين' AND (p.ParentID IS NOT NULL AND p.ParentID <> 0)
                END");

            // One-time cleanup for the same kind of drift as the section-name merge above: acePriceQuotation's
            // ribbon caption is N'عروض الموردين' (frmMainPage.Designer.cs) but this leaf used to be
            // seeded/checked as N'عروض الأسعار' (PermNames.PriceQuotation) — any database that already ran the
            // old-named seed has an orphaned N'عروض الأسعار' row (and possibly grants/ViewCommercialPrices
            // children on it) sitting alongside the correctly-named one. Same merge-by-Id approach as above.
            ExecuteScript(con, @"
                DECLARE @CorrectId INT, @OtherId INT
                SELECT @CorrectId = Id FROM PermissionsList WHERE Name = N'عروض الموردين' AND ParentID IS NOT NULL AND ParentID <> 0
                SELECT @OtherId = Id FROM PermissionsList WHERE Name = N'عروض الأسعار' AND ParentID IS NOT NULL AND ParentID <> 0

                IF @CorrectId IS NULL AND @OtherId IS NOT NULL
                BEGIN
                    UPDATE PermissionsList SET Name = N'عروض الموردين' WHERE Id = @OtherId
                END
                ELSE IF @CorrectId IS NOT NULL AND @OtherId IS NOT NULL AND @CorrectId <> @OtherId
                BEGIN
                    UPDATE PermissionsList SET ParentID = @CorrectId WHERE ParentID = @OtherId

                    UPDATE ups SET ups.PermsID = @CorrectId
                    FROM UserPermissionStatus ups
                    WHERE ups.PermsID = @OtherId
                      AND NOT EXISTS (SELECT 1 FROM UserPermissionStatus x WHERE x.UserID = ups.UserID AND x.PermsID = @CorrectId)

                    DELETE FROM UserPermissionStatus WHERE PermsID = @OtherId

                    DELETE FROM PermissionsList WHERE Id = @OtherId
                END");

            // Seeds the "طلب الشراء" procedure (definition + its 5 ordered steps) into the generic
            // workflow engine (see Data/WorkflowEngine.cs). Name-guarded/idempotent like the blocks
            // above. Deliberately does NOT seed WorkflowStepAssigneeList — there's no way to know which
            // real users should be assigned to each step from here; an admin must assign them via the
            // "إدارة الإجراءات" screen after this seeds.
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT 1 FROM WorkflowDefinitionList WHERE Name = N'طلب الشراء')
                BEGIN
                    DECLARE @WfDefId INT
                    INSERT INTO WorkflowDefinitionList (Name, Description, IsActive, CreatedDate, CreatedMachine, CreatedBy, UpdateDate, UpdateMachine, UpdateBy, IsDelete)
                    VALUES (N'طلب الشراء', N'إجراء اعتماد طلبات الشراء', 1, GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0)
                    SET @WfDefId = SCOPE_IDENTITY()

                    INSERT INTO WorkflowStepList (WorkflowDefinitionId, StepOrder, Name, CreatedDate, CreatedMachine, CreatedBy, UpdateDate, UpdateMachine, UpdateBy, IsDelete)
                    VALUES
                        (@WfDefId, 1, N'مراجعة مسؤول المخازن', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0),
                        (@WfDefId, 2, N'مراجعة مهندس التخصص', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0),
                        (@WfDefId, 3, N'اعتماد مدير المشروع', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0),
                        (@WfDefId, 4, N'مراجعة مهندس التقديرات وضبط التكلفة', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0),
                        (@WfDefId, 5, N'اعتماد مدير المشروع', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0)
                END");

            // Seeds the "أمر الشراء" procedure (definition + its 4 ordered steps) into the generic
            // workflow engine — same idempotent/name-guarded pattern as "طلب الشراء" above, and likewise
            // deliberately does NOT seed WorkflowStepAssigneeList (admin assigns real users per step via
            // "إدارة الإجراءات" after this seeds). Replaces the old single-step PurchaseOrderService-based
            // approval (see PurchaseOrderWorkflowSync).
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT 1 FROM WorkflowDefinitionList WHERE Name = N'أمر الشراء')
                BEGIN
                    DECLARE @PoWfDefId INT
                    INSERT INTO WorkflowDefinitionList (Name, Description, IsActive, CreatedDate, CreatedMachine, CreatedBy, UpdateDate, UpdateMachine, UpdateBy, IsDelete)
                    VALUES (N'أمر الشراء', N'إجراء اعتماد أوامر الشراء', 1, GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0)
                    SET @PoWfDefId = SCOPE_IDENTITY()

                    INSERT INTO WorkflowStepList (WorkflowDefinitionId, StepOrder, Name, CreatedDate, CreatedMachine, CreatedBy, UpdateDate, UpdateMachine, UpdateBy, IsDelete)
                    VALUES
                        (@PoWfDefId, 1, N'اعتماد مدير المشتريات', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0),
                        (@PoWfDefId, 2, N'مراجعة مهندس التقديرات والتكلفة', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0),
                        (@PoWfDefId, 3, N'اعتماد مدير المشروعات', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0),
                        (@PoWfDefId, 4, N'اعتماد الرئيس التنفيذي للعمليات', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0)
                END");

            // Seeds the "اعتماد طلب فحص الأعمال (CIR)" procedure — a single-step gate (مدير المشروع)
            // that frmCIRAddEdit.btnApproved starts/acts on before "إرسال" (email to the consultant)
            // is allowed — see CIRWorkflowSync. Category is set explicitly (unlike طلب الشراء/أمر الشراء
            // above, which predate that column and rely on the legacy Category-IS-NULL fallback) since
            // this procedure is brand new and CIRWorkflowSync.GetAvailableProcedures matches purely by
            // Category. Same idempotent/name-guarded pattern; deliberately does NOT seed
            // WorkflowStepAssigneeList (admin assigns مدير المشروع via "إدارة الإجراءات" after this seeds).
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT 1 FROM WorkflowDefinitionList WHERE Name = N'اعتماد طلب فحص الأعمال (CIR)')
                BEGIN
                    DECLARE @CirWfDefId INT
                    INSERT INTO WorkflowDefinitionList (Name, Description, IsActive, Category, CreatedDate, CreatedMachine, CreatedBy, UpdateDate, UpdateMachine, UpdateBy, IsDelete)
                    VALUES (N'اعتماد طلب فحص الأعمال (CIR)', N'اعتماد مدير المشروع لطلب فحص الأعمال قبل إرساله للاستشاري', 1, N'ConstructionInspectionRequestList', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0)
                    SET @CirWfDefId = SCOPE_IDENTITY()

                    INSERT INTO WorkflowStepList (WorkflowDefinitionId, StepOrder, Name, CreatedDate, CreatedMachine, CreatedBy, UpdateDate, UpdateMachine, UpdateBy, IsDelete)
                    VALUES (@CirWfDefId, 1, N'اعتماد مدير المشروع', GETDATE(), 'System', 1, GETDATE(), 'System', 1, 0)
                END");

            // Seeds the Drawings module lookup tables (frmDrawingsAddEdit). DrawingsType/DrawingsStatus
            // IDs are load-bearing — PrintHelper.MapDrawingType and frmDrawingsAddEdit's OverallStatus
            // transitions hardcode these exact IDs — hence SET IDENTITY_INSERT rather than the
            // idempotent-by-Name style used elsewhere. No admin screen exists yet to manage these four
            // tables (same gap as SubmittalCategory/SubmittalSubCategory used by MAR); rows can be
            // edited directly in the DB. DrawingsSubCategory gets one generic "عام" placeholder row per
            // type so the Type→Category→SubCategory cascade isn't empty out of the box.
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingsType')
                BEGIN
                    SET IDENTITY_INSERT DrawingsType ON
                    INSERT INTO DrawingsType (Id, Name)
                    SELECT v.Id, v.Name FROM (VALUES
                        (1, N'إنشائي'), (2, N'معماري'), (3, N'ميكانيكا'), (4, N'كهرباء'), (5, N'أخرى')
                    ) AS v(Id, Name)
                    WHERE NOT EXISTS (SELECT 1 FROM DrawingsType d WHERE d.Id = v.Id)
                    SET IDENTITY_INSERT DrawingsType OFF
                END

                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingsStatus')
                BEGIN
                    SET IDENTITY_INSERT DrawingsStatus ON
                    INSERT INTO DrawingsStatus (Id, Name)
                    SELECT v.Id, v.Name FROM (VALUES
                        (1, N'مسودة'), (2, N'مُرسل للاعتماد'), (3, N'معاد إصداره'), (4, N'مغلق')
                    ) AS v(Id, Name)
                    WHERE NOT EXISTS (SELECT 1 FROM DrawingsStatus d WHERE d.Id = v.Id)
                    SET IDENTITY_INSERT DrawingsStatus OFF
                END

                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingsIssuerList')
                BEGIN
                    INSERT INTO DrawingsIssuerList (Name, CreatedBy, CreatedDate, CreatedMachine)
                    SELECT v.Name, 'System', GETDATE(), 'System' FROM (VALUES
                        (N'الاستشاري'), (N'المقاول'), (N'المالك'), (N'المصمم')
                    ) AS v(Name)
                    WHERE NOT EXISTS (SELECT 1 FROM DrawingsIssuerList i WHERE i.Name = v.Name)
                END

                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingsSubCategory')
                   AND EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingsType')
                BEGIN
                    INSERT INTO DrawingsSubCategory (Type, Category, CategoryAbb, Name)
                    SELECT t.Name, N'عام',
                        CASE t.Name
                            WHEN N'إنشائي' THEN 'STR'
                            WHEN N'معماري' THEN 'ARC'
                            WHEN N'ميكانيكا' THEN 'MEC'
                            WHEN N'كهرباء' THEN 'ELE'
                            ELSE 'OTH'
                        END,
                        N'عام'
                    FROM DrawingsType t
                    WHERE NOT EXISTS (
                        SELECT 1 FROM DrawingsSubCategory s WHERE s.Type = t.Name AND s.Category = N'عام'
                    )
                END");

            // One-time (idempotent, re-runs harmlessly every startup) migration of the old free-text
            // DrawingsSubCategory.Category / DrawingsRegisterList.Category strings into the now-proper
            // DrawingsCategory lookup table + CategoryId FK columns (frmDrawingsAddEdit's lueCategory
            // used to be an unbacked distinct-string picker — see DrawingsCategory.cs). Seeds DrawingsCategory
            // from whatever category text already exists, then backfills CategoryId wherever it's still
            // null. The old Category/CategoryAbb columns are no longer written by the app (removed from
            // the POCOs) but are left in place in the DB — schema sync never drops columns — so this stays
            // safe to leave running indefinitely and never touches a row whose CategoryId is already set.
            //
            // Fixed 2026-07-28: both INSERTs below used to pass the literal string 'System' for
            // DrawingsCategory.CreatedBy, but that column is `int` (unlike DrawingsIssuerList.CreatedBy,
            // which is deliberately `string?` — see its comment). SQL Server evaluates that implicit
            // varchar->int conversion at compile time regardless of row count, so this threw
            // "Conversion failed when converting the varchar value 'System' to data type int" on every
            // single app startup (confirmed directly against a live DB), silently aborting the rest of
            // SeedData() via Initialize()'s outer catch — including every ExecuteScript call after this
            // one in the method. Changed to `1` (same int convention as CreatedBy=1 used by the
            // WorkflowDefinitionList/WorkflowStepList seeds above). If SeedData ever again "stops partway
            // through" on a fresh DB, suspect a string literal landing in an `int` IBaseEntity audit
            // column exactly like this.
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingsCategory')
                   AND EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingsSubCategory')
                   AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('DrawingsSubCategory') AND name = 'Category')
                   AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('DrawingsSubCategory') AND name = 'CategoryId')
                BEGIN
                    INSERT INTO DrawingsCategory (Name, Abb, CreatedBy, CreatedDate, CreatedMachine, IsDelete, DeletionBy, UpdateBy)
                    SELECT s.Category, MAX(s.CategoryAbb), 1, GETDATE(), 'System', 0, 0, 0
                    FROM DrawingsSubCategory s
                    WHERE s.Category IS NOT NULL AND s.Category <> N''
                      AND NOT EXISTS (SELECT 1 FROM DrawingsCategory c WHERE c.Name = s.Category)
                    GROUP BY s.Category

                    UPDATE s SET s.CategoryId = c.Id
                    FROM DrawingsSubCategory s
                    JOIN DrawingsCategory c ON c.Name = s.Category
                    WHERE s.CategoryId IS NULL AND s.Category IS NOT NULL AND s.Category <> N''
                END

                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingsCategory')
                   AND EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DrawingsRegisterList')
                   AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('DrawingsRegisterList') AND name = 'Category')
                   AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('DrawingsRegisterList') AND name = 'CategoryId')
                BEGIN
                    INSERT INTO DrawingsCategory (Name, CreatedBy, CreatedDate, CreatedMachine, IsDelete, DeletionBy, UpdateBy)
                    SELECT DISTINCT r.Category, 1, GETDATE(), 'System', 0, 0, 0
                    FROM DrawingsRegisterList r
                    WHERE r.Category IS NOT NULL AND r.Category <> N''
                      AND NOT EXISTS (SELECT 1 FROM DrawingsCategory c WHERE c.Name = r.Category)

                    UPDATE r SET r.CategoryId = c.Id
                    FROM DrawingsRegisterList r
                    JOIN DrawingsCategory c ON c.Name = r.Category
                    WHERE r.CategoryId IS NULL AND r.Category IS NOT NULL AND r.Category <> N''
                END");

            // UserProjectAccess's IDENTITY seed can drift behind its actual MAX(Id) (seen in production
            // as "Violation of PRIMARY KEY constraint ... Cannot insert duplicate key" on save) — this
            // aborts whatever per-row insert hit the collision, including mid-loop in the backfill below
            // or in frmProjectAddEdit/frmUsersMgt's per-user/per-project provisioning, leaving gaps.
            // Reseeding to the true max is a no-op when already in sync, so safe to run every startup.
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'UserProjectAccess')
                BEGIN
                    DECLARE @UPAMaxId INT = (SELECT ISNULL(MAX(Id), 0) FROM UserProjectAccess)
                    DBCC CHECKIDENT ('UserProjectAccess', RESEED, @UPAMaxId)
                END");

            // Backfills UserProjectAccess for any (user, project) pair created before frmUsersMgt /
            // frmProjectAddEdit started writing an explicit row on insert (or for rows that failed to
            // write for any other reason) — every active user must have a status row for every active
            // project, defaulting to granted (1) for the system admin and denied (0) for everyone else,
            // same rule as new-user/new-project creation. NOT EXISTS-guarded so it only fills gaps and
            // never touches rows an admin already toggled.
            ExecuteScript(con, @"
                INSERT INTO UserProjectAccess (UserID, PrjId, PermsStatus, UpdateDate, UpdateMachine, UpdateBy)
                SELECT u.Id, p.Id, CASE WHEN u.Id = 1 THEN 1 ELSE 0 END, GETDATE(), 'System', 1
                FROM UsersList u
                CROSS JOIN ProjectsList p
                WHERE u.IsDelete = 0 AND p.IsDelete = 0
                  AND NOT EXISTS (
                      SELECT 1 FROM UserProjectAccess a WHERE a.UserID = u.Id AND a.PrjId = p.Id
                  )");

            // تصنيفات الأصناف: مستوى رئيسي ثابت غير قابل للحذف فوق الشجرة الحالية — خمسة عناصر ثابتة
            // (ItemCategory.IsFixed) لكل منها كود بحرف واحد يصبح بادئة كل كود تحته (انظر BuildCode في
            // frmItemCategoryAddEdit — Walk(root.Id, 1, root.Code) بدل Walk(root.Id, 1, null) سابقاً):
            // المواد=M، المقاولين=C، الخدمات=S، المعدات=E، الايجارات=R. يُزرع مرة واحدة (idempotent
            // بالاسم + IsFixed=1)، ثم UPDATE ثانٍ يُصحِّح Code/SortId لأي تصنيف ثابت موجود مسبقاً بقيم
            // قديمة أو ناقصة (مثل تصنيفات أُنشئت من نسخة تشغيل أخرى على نفس القاعدة قبل إضافة الحروف)،
            // فيبقى متزامناً مع القيم أعلاه في كل تشغيل بلا حاجة لأي تدخل يدوي على قاعدة البيانات. أخيراً
            // تُعاد كل تصنيفات الأصناف التي كانت جذرية (ParentId IS NULL) قبل هذا التعديل لتصبح تحت
            // "المواد" تحديداً (الشاشة كانت تُستخدم حصراً لتصنيف المواد سابقاً) — يُغيَّر ParentId فقط،
            // وRecalculateAndSave هو من يعيد بناء Code لاحقاً بالبادئة الجديدة.
            ExecuteScript(con, @"
                IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('ItemCategory') AND name = 'IsFixed')
                BEGIN
                    INSERT INTO ItemCategory (Name, Code, ParentId, LvlId, SortId, IsFixed, CreatedDate, CreatedMachine, CreatedBy, UpdateBy, IsDelete, DeletionBy)
                    SELECT v.Name, v.Code, NULL, 0, v.SortId, 1, GETDATE(), 'System', 1, 1, 0, 0
                    FROM (VALUES (N'المواد', N'M', 1), (N'المقاولين', N'C', 2), (N'الخدمات', N'S', 3),
                                  (N'المعدات', N'E', 4), (N'الايجارات', N'R', 5)) AS v(Name, Code, SortId)
                    WHERE NOT EXISTS (SELECT 1 FROM ItemCategory c WHERE c.Name = v.Name AND c.IsFixed = 1)

                    UPDATE c SET c.Code = v.Code, c.SortId = v.SortId
                    FROM ItemCategory c
                    JOIN (VALUES (N'المواد', N'M', 1), (N'المقاولين', N'C', 2), (N'الخدمات', N'S', 3),
                                  (N'المعدات', N'E', 4), (N'الايجارات', N'R', 5)) AS v(Name, Code, SortId)
                      ON v.Name = c.Name
                    WHERE c.IsFixed = 1
                      AND (c.Code IS NULL OR c.Code <> v.Code OR c.SortId IS NULL OR c.SortId <> v.SortId)

                    -- (IsFixed = 0 OR IsFixed IS NULL): ALTER TABLE ADD COLUMN leaves existing rows NULL
                    -- for a newly-added BIT column (no DEFAULT specified — see SyncColumns), not 0, so a
                    -- plain 'IsFixed = 0' silently matches zero legacy rows under SQL's NULL semantics.
                    UPDATE c SET c.ParentId = m.Id
                    FROM ItemCategory c
                    CROSS JOIN (SELECT TOP 1 Id FROM ItemCategory WHERE Name = N'المواد' AND IsFixed = 1) m
                    WHERE c.ParentId IS NULL AND (c.IsFixed = 0 OR c.IsFixed IS NULL) AND c.IsDelete = 0
                END");
        }

        #region Helpers
        public static void ExecuteNonQuery(string script)
        {
            using (var con = new SqlConnection(DBSetting.GetConString()))
            {
                con.Open();
                ExecuteScript(con, script);
            }
        }

        private static void ExecuteScript(SqlConnection con, string script)
        {
            using (var cmd = new SqlCommand(script, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // Seeds a set of leaf permissions nested two levels deep under an existing (sectionName, leafName)
        // pair — e.g. a screen's own toolbar-action permissions under its module's list leaf (see
        // PermNames.CIRAdd/PRAdd/UserAdd for examples of what these gate). Idempotent by Name like every
        // other seed here: only inserts rows that don't already exist under that same parent. sectionName/
        // leafName/item names are always literal constants passed from this file, never external input.
        private static void SeedNestedLeafPermissions(SqlConnection con, string sectionName, string leafName, (string Name, int SortId)[] items)
        {
            string EscapeSqlLiteral(string s) => s.Replace("'", "''");

            var values = string.Join(",\n                    ",
                items.Select(i => $"(N'{EscapeSqlLiteral(i.Name)}', {i.SortId})"));

            ExecuteScript(con, $@"
                INSERT INTO PermissionsList (ParentID, Name, SortID)
                SELECT grandparent.Id, v.Name, v.SortID
                FROM (VALUES
                    {values}
                ) AS v(Name, SortID)
                CROSS JOIN (
                    SELECT c.Id
                    FROM PermissionsList c
                    JOIN PermissionsList p ON c.ParentID = p.Id
                    WHERE c.Name = N'{EscapeSqlLiteral(leafName)}' AND p.Name = N'{EscapeSqlLiteral(sectionName)}' AND (p.ParentID IS NULL OR p.ParentID = 0)
                ) AS grandparent(Id)
                WHERE NOT EXISTS (
                    SELECT 1 FROM PermissionsList g WHERE g.Name = v.Name AND g.ParentID = grandparent.Id
                )");
        }

        private static string GetMasterConnectionString()
        {
            var builder = new SqlConnectionStringBuilder(DBSetting.GetConString());
            builder.InitialCatalog = "master";
            return builder.ConnectionString;
        }
        #endregion
    }
}
