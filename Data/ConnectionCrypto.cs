using System;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;

namespace Data
{
    // Encrypts saved connection data (server/user/password) at rest via Windows DPAPI so it
    // isn't sitting as plain text in the user's Properties.Settings (user.config) file.
    // CurrentUser scope: only decryptable by the same Windows account on the same machine,
    // matching the fact that these settings are already stored per-Windows-user.
    // Data.csproj targets plain net10.0, but the app (Etmam.csproj) is net10.0-windows only,
    // so DPAPI is always actually available at runtime - this attribute just tells the
    // platform-compatibility analyzer that.
    [SupportedOSPlatform("windows")]
    internal static class ConnectionCrypto
    {
        private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("Etmam.DBSetting.v1");

        public static string Protect(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return "";

            var bytes = Encoding.UTF8.GetBytes(plainText);
            var protectedBytes = ProtectedData.Protect(bytes, Entropy, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(protectedBytes);
        }

        public static string Unprotect(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return "";

            try
            {
                var bytes = Convert.FromBase64String(cipherText);
                var plainBytes = ProtectedData.Unprotect(bytes, Entropy, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(plainBytes);
            }
            catch
            {
                // Corrupt/foreign blob (e.g. copied user.config from another machine/user) - treat as empty.
                return "";
            }
        }
    }
}
