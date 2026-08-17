using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace Data
{
    public class DBSetting
    {
        // Connection Strings
        private static string _localCon = @"Server=.;Database=EtmamDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private static string _cloudCon = @"Server=CLOUD_SERVER_IP;Database=EtmamDB;User Id=CLOUD_USER;Password=CLOUD_PASSWORD;TrustServerCertificate=True;";

        // Toggle between Local and Cloud
        public static bool IsLocal { get; set; } = true;

        public static string GetConString()
        {
            return IsLocal ? _localCon : _cloudCon;
        }

        // Method to update connection strings if needed
        public static void SetChainStrings(string local, string cloud)
        {
            _localCon = local;
            _cloudCon = cloud;
        }

        public static async Task<bool> CanConnectAsync()
        {
            try
            {
                using (var con = new SqlConnection(GetConString()))
                {
                    await con.OpenAsync();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
