using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace Etmam
{
    /// <summary>Mandatory update gate shown from frmStart when the running Etmam.exe's
    /// Application.ProductVersion is older than the resolved latest version (GitHub release, or
    /// the DB-shared LatestAppVersion fallback). Every button closes this dialog and ControlBox
    /// is off - there is no "continue anyway" path; frmStart always cancels and exits the app
    /// once this returns.</summary>
    public partial class frmUpdateRequired : XtraForm
    {
        private LabelControl? _lblStatus;
        private SimpleButton? _btnUpdateNow;

        public frmUpdateRequired(string currentVersion, string latestVersion, string? installerDownloadUrl, string? updateLocation)
        {
            InitializeComponent();
            this.Icon = AppIcon.Default;
            BuildUI(currentVersion, latestVersion, installerDownloadUrl, updateLocation);
        }

        private void InitializeComponent()
        {
        }

        private void BuildUI(string currentVersion, string latestVersion, string? installerDownloadUrl, string? updateLocation)
        {
            // Prefer the fully-automated path (download + run the installer ourselves) whenever
            // a GitHub release asset is available - only fall back to making the user open the
            // location themselves (old DB-configured UNC/URL) when it isn't, e.g. GitHub was
            // unreachable and this is running off the DB fallback version instead.
            bool canAutoUpdate = !string.IsNullOrWhiteSpace(installerDownloadUrl);
            bool hasLocation = !canAutoUpdate && !string.IsNullOrWhiteSpace(updateLocation);

            Text = "يتوفر تحديث جديد — Etmam";
            ClientSize = new Size(420, (canAutoUpdate || hasLocation) ? 292 : 216);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            BackColor = Color.White;

            var lblTitle = new LabelControl
            {
                Text = "🔄  يتوفر إصدار أحدث من البرنامج",
                Font = DesignSystem.Fonts.Bold(12),
                ForeColor = DesignSystem.Colors.TextPrimary,
                Location = new Point(20, 20),
                AutoSize = true,
            };

            var lblBody = new LabelControl
            {
                Text = $"إصدارك الحالي: {currentVersion}\nالإصدار المتاح: {latestVersion}\n\n" +
                       "لا يمكن المتابعة باستخدام هذا الإصدار. يرجى تحديث البرنامج ثم إعادة المحاولة.",
                Location = new Point(20, 56),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(380, 90),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var controls = new System.Collections.Generic.List<Control> { lblTitle, lblBody };
            int y = 156;

            if (canAutoUpdate)
            {
                _btnUpdateNow = new SimpleButton
                {
                    Text = "تحديث الآن",
                    Location = new Point(20, y),
                    Width = 180,
                    Height = 32,
                };
                DesignSystem.StylePrimaryButton(_btnUpdateNow);
                _btnUpdateNow.Click += (s, e) => UpdateNowAsync(installerDownloadUrl!);
                controls.Add(_btnUpdateNow);
                y += 44;

                _lblStatus = new LabelControl
                {
                    Text = "",
                    Location = new Point(20, y),
                    AutoSizeMode = LabelAutoSizeMode.None,
                    Size = new Size(380, 20),
                    ForeColor = DesignSystem.Colors.TextSecondary,
                };
                controls.Add(_lblStatus);
                y += 32;
            }
            else if (hasLocation)
            {
                var btnOpenLocation = new SimpleButton
                {
                    Text = "فتح مكان التحديث",
                    Location = new Point(20, y),
                    Width = 180,
                    Height = 32,
                };
                DesignSystem.StylePrimaryButton(btnOpenLocation);
                btnOpenLocation.Click += (s, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(updateLocation!) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"تعذّر فتح المسار:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                controls.Add(btnOpenLocation);
                y += 44;
            }

            var btnClose = new SimpleButton
            {
                Text = "إغلاق البرنامج",
                Location = new Point(20, y),
                Width = 180,
                Height = 32,
            };
            DesignSystem.StyleOutlineButton(btnClose);
            btnClose.Click += (s, e) => Close();
            controls.Add(btnClose);

            Controls.AddRange(controls.ToArray());
        }

        /// <summary>Downloads the installer asset from the GitHub release and launches it, then
        /// exits this process immediately - the new installer's [Code] section (EtmamSetup.iss)
        /// already detects the previous install via its AppId and silently uninstalls it before
        /// copying the new files, so from the user's side this is just "Update Now", not a
        /// separate uninstall-then-reinstall they have to do by hand. Etmam.exe has to stop
        /// running first though: Windows won't let the installer overwrite/delete an EXE that's
        /// still the current process. The installer's own [Run] section relaunches the app once
        /// the new install finishes.</summary>
        private async void UpdateNowAsync(string installerDownloadUrl)
        {
            _btnUpdateNow!.Enabled = false;
            _lblStatus!.Text = "جاري تنزيل التحديث...";

            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "EtmamSetup.exe");

                using var http = new HttpClient();
                using (var response = await http.GetAsync(installerDownloadUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    await using var target = File.Create(tempPath);
                    await response.Content.CopyToAsync(target);
                }

                _lblStatus.Text = "جاري تشغيل التحديث...";
                Process.Start(new ProcessStartInfo(tempPath) { UseShellExecute = true });
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"تعذّر تنزيل التحديث تلقائياً:\n{ex.Message}\n\nيمكنك تنزيل الإصدار الأخير يدوياً من صفحة إصدارات المشروع على GitHub.",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _btnUpdateNow.Enabled = true;
                _lblStatus.Text = "";
            }
        }
    }
}
