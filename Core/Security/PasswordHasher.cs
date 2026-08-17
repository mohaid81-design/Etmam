using System;
using System.Security.Cryptography;

namespace Core.Security
{
    /// <summary>
    /// PBKDF2-based password hashing. Stored format: "PBKDF2$&lt;iterations&gt;$&lt;saltBase64&gt;$&lt;hashBase64&gt;".
    /// Values that don't match this format are treated as legacy plaintext so existing accounts keep working
    /// until their next successful login, at which point the caller should re-hash and persist the new value.
    /// </summary>
    public static class PasswordHasher
    {
        private const string Prefix = "PBKDF2";
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100_000;

        public static string Hash(string password)
        {
            ArgumentNullException.ThrowIfNull(password);

            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);

            return $"{Prefix}${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
        }

        public static bool IsHashed(string? storedValue) =>
            !string.IsNullOrEmpty(storedValue) && storedValue.StartsWith(Prefix + "$", StringComparison.Ordinal);

        public static bool Verify(string password, string? storedValue)
        {
            if (string.IsNullOrEmpty(storedValue)) return false;

            if (!IsHashed(storedValue))
                return password == storedValue; // legacy plaintext account, not upgraded yet

            var parts = storedValue.Split('$');
            if (parts.Length != 4 || !int.TryParse(parts[1], out var iterations)) return false;

            byte[] salt, expectedHash;
            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expectedHash = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            var actualHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expectedHash.Length);
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
    }
}
