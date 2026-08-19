using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Etmam
{
    /// <summary>Headless one-time setup path: running `Etmam.exe --provision-connection
    /// &lt;path-to-json&gt;` seeds this machine's DPAPI-encrypted connection profiles
    /// (Data.DBSetting) from a local JSON file, then exits without showing the normal UI - so a
    /// freshly-installed machine can be pointed at the real database without anyone typing
    /// credentials into frmConnecting by hand.
    ///
    /// The JSON file is filled in by whoever is deploying (never by an AI assistant - see
    /// installer/connection-template.json's header comment) and must never be committed to
    /// source control or bundled into the installer/distributed build; it only ever needs to
    /// exist on the machine being provisioned, and only for as long as it takes to run this once.
    /// </summary>
    internal static class ConnectionProvisioning
    {
        private const string SwitchName = "--provision-connection";
        private const string SilentSwitchName = "--silent";

        /// <summary>Returns true if this run was a provisioning request (handled here, caller
        /// should exit immediately) - false means "not a provisioning run, continue normal startup".</summary>
        public static bool TryHandle(string[] args)
        {
            var index = Array.FindIndex(args, a => a.Equals(SwitchName, StringComparison.OrdinalIgnoreCase));
            if (index < 0) return false;

            // --silent: used by the installer's own [Run] step (see EtmamSetup.iss) when a
            // connection.local.json was bundled in - runs unattended with no dialogs, success or
            // failure. Interactive/manual runs (the documented normal usage) still get feedback.
            bool silent = Array.Exists(args, a => a.Equals(SilentSwitchName, StringComparison.OrdinalIgnoreCase));

            if (index + 1 >= args.Length)
            {
                if (!silent)
                    MessageBox.Show($"الاستخدام: Etmam.exe {SwitchName} <مسار ملف JSON>", "إعداد الاتصال",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            string path = args[index + 1];
            try
            {
                var json = File.ReadAllText(path);
                var file = JsonSerializer.Deserialize<ProvisionFile>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (file?.Profiles is null || file.Profiles.Count == 0)
                    throw new InvalidOperationException("الملف لا يحتوي على أي ملف اتصال (profiles).");

                Data.DBSetting.SaveProfiles(file.Profiles, file.ActiveProfile ?? file.Profiles[0].Name);

                if (!silent)
                    MessageBox.Show(
                        $"تم حفظ {file.Profiles.Count} ملف اتصال بنجاح على هذا الجهاز.\nالملف النشط: {file.ActiveProfile ?? file.Profiles[0].Name}\n\n" +
                        "يمكنك الآن حذف ملف JSON هذا بأمان وتشغيل البرنامج عادةً.",
                        "تم الإعداد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (!silent)
                    MessageBox.Show($"فشل إعداد الاتصال:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        private sealed class ProvisionFile
        {
            public string? ActiveProfile { get; set; }
            public List<Data.ConnectionProfile> Profiles { get; set; } = new();
        }
    }
}
