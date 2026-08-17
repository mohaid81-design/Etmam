using Microsoft.Data.SqlClient;
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

                    // 3. Fast Check: If SchemaHash matches, skip full sync
                    string currentHash = GetSchemaHash();
                    if (IsSchemaUpToDate(con, currentHash))
                    {
                        return; // Database is up to date
                    }

                    // 4. Sync all tables from Core models
                    SyncAllTables(con);

                    // 5. Update the schema hash for next startup
                    UpdateSchemaHash(con, currentHash);

                    // 6. Seed Master Data
                    SeedData(con);
                }
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

        private static void SyncColumns(SqlConnection con, string tableName, List<PropertyInfo> properties)
        {
            foreach (var prop in properties)
            {
                if (!ColumnExists(con, tableName, prop.Name))
                {
                    var sqlType = GetSqlType(prop);
                    var query = $"ALTER TABLE [{tableName}] ADD [{prop.Name}] {sqlType}";
                    ExecuteScript(con, query);
                }
            }
        }

        private static bool ColumnExists(SqlConnection con, string tableName, string columnName)
        {
            var query = $@"IF EXISTS (SELECT * FROM sys.columns 
                                     WHERE object_id = OBJECT_ID('[dbo].[{tableName}]') AND name = @col)
                           SELECT 1 ELSE SELECT 0";
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@col", columnName);
                return (int)cmd.ExecuteScalar() == 1;
            }
        }

        private static string? GetSqlType(PropertyInfo prop)
        {
            var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            if (type == typeof(int))     return "INT";
            if (type == typeof(long))    return "INT";   // store as INT — KB values never exceed 2 billion
            if (type == typeof(string))  return "NVARCHAR(MAX)";
            if (type == typeof(DateTime)) return "DATETIME";
            if (type == typeof(decimal)) return "DECIMAL(18,2)";
            if (type == typeof(bool))    return "BIT";
            if (type == typeof(byte[]))  return "VARBINARY(MAX)";
            if (type == typeof(Guid))    return "UNIQUEIDENTIFIER";
            if (type.IsEnum)             return "INT";
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
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT * FROM PermissionsList)
                BEGIN
                    SET IDENTITY_INSERT PermissionsList ON
                    INSERT INTO PermissionsList (Id, IdParent, Description) VALUES (1, NULL, N'إدارة المستخدمين')
                    INSERT INTO PermissionsList (Id, IdParent, Description) VALUES (2, 1, N'إضافة مستخدم')
                    INSERT INTO PermissionsList (Id, IdParent, Description) VALUES (3, 1, N'تعديل مستخدم')
                    INSERT INTO PermissionsList (Id, IdParent, Description) VALUES (4, 1, N'تعديل كلمة السر')
                    INSERT INTO PermissionsList (Id, IdParent, Description) VALUES (5, 1, N'تفعيل/تعطيل مستخدم')
                    INSERT INTO PermissionsList (Id, IdParent, Description) VALUES (6, 1, N'الصلاحيات')
                    SET IDENTITY_INSERT PermissionsList OFF
                END");

            // Seeded independently of the block above (idempotent by Description) so it also
            // reaches databases that were already seeded before the Workflow module existed.
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT 1 FROM PermissionsList WHERE Description = N'إدارة الإجراءات')
                BEGIN
                    INSERT INTO PermissionsList (IdParent, Description) VALUES (NULL, N'إدارة الإجراءات')
                END");

            // Gates the اعتماد/رفض actions on Purchase Requests (see PurchaseRequestPermissions).
            ExecuteScript(con, @"
                IF NOT EXISTS (SELECT 1 FROM PermissionsList WHERE Description = N'اعتماد طلبات الشراء')
                BEGIN
                    INSERT INTO PermissionsList (IdParent, Description) VALUES (NULL, N'اعتماد طلبات الشراء')
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

        private static string GetMasterConnectionString()
        {
            var builder = new SqlConnectionStringBuilder(DBSetting.GetConString());
            builder.InitialCatalog = "master";
            return builder.ConnectionString;
        }
        #endregion
    }
}
