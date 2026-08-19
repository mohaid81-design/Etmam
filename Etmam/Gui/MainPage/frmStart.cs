using Data;
using System;
using System.Drawing;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using Etmam.Code.Update;

namespace Etmam
{
    public partial class frmStart : XtraForm
    {
        // Counts consecutive "Api not listening yet" ticks so a genuinely stuck startup (Api.exe
        // crashed - see ApiProcessManager's api-startup.log) surfaces an error instead of leaving
        // the user staring at "جاري تشغيل خادم النظام.." forever with no explanation.
        private int _apiWaitTicks;
        private bool _apiTimeoutShown;

        public frmStart()
        {
            InitializeComponent();
            //DesignSystem.ApplyFormBranding(this);
            this.Icon = AppIcon.Default;
            // نفس مصدر رقم الإصدارة المعتمد في المشروع (Etmam.csproj's <Version>، بلا لاحقة +githash
            // بفضل IncludeSourceRevisionInInformationalVersion=false) — يطابق ما يعرضه SettingsForm
            // في لوحة "عن البرنامج" وما تقارنه IsRunningLatestVersion أدناه، بدل النص الثابت القديم.
            label2.Text = $"v.{Application.ProductVersion}";
        }

        private void linkLabelSetServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Show Settings Form
            frmConnecting frm = new frmConnecting();
            frm.Show();
        }

        private void linkLabelExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void timerStart_Tick(object sender, EventArgs e)
        {
            // Check the connection
            labelState.Text = "جاري الاتصال..";
            if (!await DBSetting.CanConnectAsync())
            {
                panelSettings.Visible = true;
                labelState.Text = "فشل الاتصال ... جاري إعاده الإتصال";
                return;
            }

            // Login and every migrated screen call through the Api project - wait for it to
            // finish starting (ApiProcessManager.EnsureStarted was fired once from Program.Main)
            // before letting the user reach frmLogin, same retry pattern as the DB check above.
            if (!await ApiProcessManager.IsApiListeningAsync())
            {
                labelState.Text = "جاري تشغيل خادم النظام..";

                // timerStart.Interval is 5000ms, so 6 ticks ≈ 30s - long enough to allow for a
                // slow machine's normal startup, short enough that the user isn't left guessing
                // indefinitely if Api.exe actually crashed on launch.
                _apiWaitTicks++;
                if (_apiWaitTicks >= 6 && !_apiTimeoutShown)
                {
                    _apiTimeoutShown = true;
                    XtraMessageBox.Show(
                        "تعذّر تشغيل خادم النظام (Api) بعد عدة محاولات.\n\n" +
                        "التفاصيل الفنية لسبب الفشل مسجّلة في:\n" +
                        ApiProcessManager.GetStartupLogPath() + "\n\n" +
                        "سيستمر البرنامج بالمحاولة تلقائياً في الخلفية.",
                        "تعذّر الاتصال بخادم النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            timerStart.Enabled = false;

            // Ensure Database is initialized (schema + seeding)
            DatabaseInitializer.Initialize();

            // Primary source of truth is the GitHub repo's latest Release tag - falls back to
            // the DB-shared LatestAppVersion (set via SettingsForm) when GitHub is unreachable,
            // so a manual override still works offline/without a repo. Either failing entirely
            // is treated as "don't block" (see IsOlderThan), never as a reason to lock everyone out.
            var release = await GitHubUpdateChecker.GetLatestReleaseAsync();
            string latest = release?.Version ?? UpdateSettings.GetLatestVersion(Data.DataContext.Shared) ?? "";

            if (IsOlderThan(latest, out string current))
            {
                string? updateLocation = UpdateSettings.GetUpdateLocation(Data.DataContext.Shared);
                using var frmUpdate = new frmUpdateRequired(current, latest, release?.InstallerDownloadUrl, updateLocation);
                frmUpdate.ShowDialog(this);

                // Mandatory gate - frmUpdateRequired has no "continue anyway" path, so this
                // always cancels frmStart, which skips frmLogin and lets Program.Main fall
                // through and exit (see Program.cs's `if (start.ShowDialog() == DialogResult.OK)`).
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>Compares this build's Application.ProductVersion against the resolved latest
        /// version (GitHub release tag, or the DB fallback). Fails open (returns false, i.e.
        /// "don't block") when nothing resolved or either version string doesn't parse - a
        /// misconfigured/unreachable gate should never be able to lock every user out.</summary>
        private static bool IsOlderThan(string latest, out string current)
        {
            current = Application.ProductVersion;

            if (string.IsNullOrWhiteSpace(latest)) return false;
            if (!Version.TryParse(VersionCore(current), out var currentVersion)) return false;
            if (!Version.TryParse(VersionCore(latest), out var latestVersion)) return false;

            return currentVersion < latestVersion;
        }

        /// <summary>Strips SemVer-style "+build" / "-prerelease" suffixes (e.g. the SDK's
        /// auto-appended "+&lt;git-hash&gt;", should IncludeSourceRevisionInInformationalVersion
        /// ever get re-enabled) before handing the string to System.Version.TryParse, which
        /// rejects anything past the numeric major.minor.build.revision parts.</summary>
        private static string VersionCore(string version)
        {
            int cut = version.IndexOfAny(new[] { '+', '-' });
            return cut < 0 ? version : version[..cut];
        }
    }
}