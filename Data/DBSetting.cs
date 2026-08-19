using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Data.Properties;

namespace Data
{
    // Central, user-editable connection store: an arbitrary list of named ConnectionProfiles
    // (server/database/credentials), one of them marked active. Persisted as DPAPI-encrypted
    // JSON in the user-scoped Properties.Settings store (Data\Properties\Settings.settings),
    // so it survives Application.Restart() without a hand-rolled config file, and the saved
    // credentials aren't sitting in plain text in user.config.
    public static class DBSetting
    {
        private static List<ConnectionProfile>? _profiles;
        private static string? _activeProfileName;

        private static void EnsureLoaded()
        {
            if (_profiles != null) return;

            var raw = Settings.Default.ProfilesData;
            if (!string.IsNullOrWhiteSpace(raw))
            {
                try
                {
#pragma warning disable CA1416 // app is net10.0-windows only; see ConnectionCrypto's SupportedOSPlatform note
                    var json = ConnectionCrypto.Unprotect(raw);
#pragma warning restore CA1416
                    _profiles = JsonSerializer.Deserialize<List<ConnectionProfile>>(json);
                }
                catch
                {
                    _profiles = null;
                }
            }

            if (_profiles == null || _profiles.Count == 0)
            {
                // First run on this machine, or an upgrade from the old two-field Local/Cloud
                // format: seed named profiles from whatever was already there (the user's own
                // saved values if any, otherwise the shipped defaults), then persist as-is.
                _profiles = new List<ConnectionProfile>
                {
                    ConnectionProfile.FromConnectionString("محلي", Settings.Default.LocalConnectionString),
                    ConnectionProfile.FromConnectionString("سحابي", Settings.Default.CloudConnectionString),
                };
                _activeProfileName = Settings.Default.IsLocal ? "محلي" : "سحابي";
                Persist();
            }
            else
            {
                _activeProfileName = Settings.Default.ActiveProfile;
                if (string.IsNullOrWhiteSpace(_activeProfileName) || _profiles.All(p => p.Name != _activeProfileName))
                    _activeProfileName = _profiles[0].Name;
            }
        }

        public static List<ConnectionProfile> Profiles
        {
            get { EnsureLoaded(); return _profiles!; }
        }

        public static string ActiveProfileName
        {
            get { EnsureLoaded(); return _activeProfileName!; }
        }

        public static ConnectionProfile? ActiveProfile
        {
            get
            {
                EnsureLoaded();
                return _profiles!.FirstOrDefault(p => p.Name == _activeProfileName);
            }
        }

        public static string GetConString() => ActiveProfile?.BuildConnectionString() ?? "";

        // Replaces the whole profile list and active selection, then persists. Used by the
        // connection-settings screen (frmConnecting) after the user adds/edits/deletes profiles
        // or switches which one is active.
        public static void SaveProfiles(List<ConnectionProfile> profiles, string activeProfileName)
        {
            if (profiles == null || profiles.Count == 0)
                throw new ArgumentException("At least one connection profile is required.", nameof(profiles));

            _profiles = profiles;
            _activeProfileName = profiles.Any(p => p.Name == activeProfileName) ? activeProfileName : profiles[0].Name;
            Persist();
        }

        private static void Persist()
        {
            var json = JsonSerializer.Serialize(_profiles);
#pragma warning disable CA1416 // app is net10.0-windows only; see ConnectionCrypto's SupportedOSPlatform note
            Settings.Default.ProfilesData = ConnectionCrypto.Protect(json);
#pragma warning restore CA1416
            Settings.Default.ActiveProfile = _activeProfileName ?? "";
            Settings.Default.Save();
        }

        public static async Task<bool> CanConnectAsync() => await CanConnectAsync(GetConString());

        /// <summary>Diagnostic-only: the full exception from the most recent failed
        /// CanConnectAsync call. frmStart's "فشل الاتصال" gate has no path to show error detail
        /// to the user, so this exists purely to be read from a debugger/log during
        /// troubleshooting - never shown in the UI.</summary>
        public static Exception? LastConnectError { get; private set; }

        public static async Task<bool> CanConnectAsync(string connectionString)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    LastConnectError = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LastConnectError = ex;
                try
                {
                    var logPath = System.IO.Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "Etmam", "db-connect-error.log");
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(logPath)!);
                    System.IO.File.WriteAllText(logPath, $"{DateTime.Now:O}\n{ex}\n");
                }
                catch { /* best effort */ }
                return false;
            }
        }
    }
}
