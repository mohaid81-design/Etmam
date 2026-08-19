using System.Security.Cryptography;
using Data.Properties;

namespace Data
{
    // Persists a per-machine, per-Windows-user JWT signing key for the locally-launched Api
    // process (see Etmam/Code/Api/ApiProcessManager.cs) - generated once on first use, then
    // reused on every later run so tokens issued before an Api restart aren't invalidated by a
    // fresh key. Stored the same way DBSetting stores connection profiles: DPAPI-encrypted
    // (CurrentUser scope, via ConnectionCrypto) inside the user-scoped Properties.Settings
    // store, never in plain text or in source control.
    public static class ApiJwtKeySetting
    {
        public static string GetOrCreateKey()
        {
            var stored = Settings.Default.ApiJwtKeyProtected;
            if (!string.IsNullOrEmpty(stored))
            {
                var existing = ConnectionCrypto.Unprotect(stored);
                if (!string.IsNullOrEmpty(existing)) return existing;
            }

            // 512-bit random key - comfortably above HMAC-SHA256's minimum recommended size.
            var key = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            Settings.Default.ApiJwtKeyProtected = ConnectionCrypto.Protect(key);
            Settings.Default.Save();
            return key;
        }
    }
}
