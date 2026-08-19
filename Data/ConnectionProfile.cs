using Microsoft.Data.SqlClient;

namespace Data
{
    // A single named SQL Server connection the user can switch to at runtime (Data\DBSetting.cs
    // holds the list). Replaces the old hardcoded Local/Cloud binary with an arbitrary,
    // user-editable set of connections.
    public class ConnectionProfile
    {
        public string Name { get; set; } = "";
        public string Server { get; set; } = "";
        public string Database { get; set; } = "";
        public bool IntegratedSecurity { get; set; } = true;
        public string UserId { get; set; } = "";
        public string Password { get; set; } = "";
        public bool Encrypt { get; set; } = true;

        public string BuildConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = Server,
                InitialCatalog = Database,
                TrustServerCertificate = true,
                Encrypt = Encrypt,
                // Every SqlDataHelper<T> call opens (and disposes) its own SqlConnection, relying on
                // ADO.NET's connection pool to avoid re-handshaking with Azure SQL each time. Without a
                // MinPoolSize, the pool can drain to zero during idle stretches (the app left open
                // overnight, a lunch break) — the pooler doesn't proactively keep connections warm below
                // this floor — so the next save/load pays a full TCP+TLS+login round trip to Azure
                // before the query itself even starts. Keeping a handful warm removes that latency
                // spike from the user's next click. ConnectTimeout is bumped from the 15s default for
                // the same reason: Azure SQL's public endpoint can take longer than that to accept a
                // fresh connection after being idle, and a save shouldn't fail just because the pool
                // happened to be empty.
                MinPoolSize = 5,
                ConnectTimeout = 30,
            };

            if (IntegratedSecurity || string.IsNullOrWhiteSpace(UserId))
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = UserId;
                builder.Password = Password;
            }

            return builder.ConnectionString;
        }

        public static ConnectionProfile FromConnectionString(string name, string connectionString)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(connectionString);
                return new ConnectionProfile
                {
                    Name = name,
                    Server = builder.DataSource,
                    Database = builder.InitialCatalog,
                    IntegratedSecurity = builder.IntegratedSecurity,
                    UserId = builder.IntegratedSecurity ? "" : builder.UserID,
                    Password = builder.IntegratedSecurity ? "" : builder.Password,
                    Encrypt = builder.Encrypt,
                };
            }
            catch
            {
                return new ConnectionProfile { Name = name };
            }
        }
    }
}
