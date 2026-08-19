using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;

using Etmam.Properties;

namespace Etmam
{
    public partial class frmLogin : XtraForm
    {
        #region Constructor
        public frmLogin()
        {
            InitializeComponent();
            //DesignSystem.ApplyFormBranding(this);
            this.Icon = AppIcon.Default;
            ConfigureKeyboardNavigation();
            LoadSettings();
        }
        #endregion

        #region Initialization
        private void ConfigureKeyboardNavigation()
        {
            this.ActiveControl = txtUserName;
            txtUserName.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) txtPassword.Focus(); };
            txtPassword.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) btnLogin.PerformClick(); };
        }

        private void LoadSettings()
        {
            txtUserName.Text = Settings.Default.SavedUserName;
            toggleSwitch1.IsOn = Settings.Default.RememberMe;

            if (toggleSwitch1.IsOn && !string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                this.ActiveControl = txtPassword;
            }
        }
        #endregion

        #region Event Handlers
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show("من فضلك أدخل اسم المستخدم وكلمة المرور", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            var handle = ShowOverlay();
            try
            {
                var result = await ApiClient.LoginAsync(userName, password);

                if (result != null)
                {
                    await HandleSuccessfulLoginAsync(result);
                }
                else
                {
                    XtraMessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء الاتصال بخادم النظام:\n{ex.Message}", "خطأ في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
                btnLogin.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Logic Methods
        private async Task HandleSuccessfulLoginAsync(ApiLoginResult result)
        {
            // Set session data. Only the fields actually read via Session.CurrentUser elsewhere
            // (Id/UserName/FullName/Role/Company) are populated from the API response — the rest
            // of the entity now lives server-side.
            Session.CurrentUser = new Core.UsersList
            {
                Id = result.UserId,
                UserName = result.UserName,
                FullName = result.FullName,
                Role = result.Role,
                Company = result.Company,
                IsActive = true
            };
            Session.Machine = Environment.MachineName;

            SaveLoginSettings();
            // Login is audited server-side now (AuthService.LoginAsync writes ActionLogs itself),
            // so every successful login is logged regardless of which client authenticated.

            // Mandatory Password Update and Profile Completion — AuthService.LoginAsync computes
            // this identically to the condition that used to live here.
            if (result.MustChangePassword)
            {
                using var updateFrm = new frmUpdatePassword(result.FullName, result.JobTitle, result.Company);
                if (updateFrm.ShowDialog() != DialogResult.OK) return;

                // frmUpdatePassword exposes what it just saved directly - no need to re-fetch it.
                Session.CurrentUser.FullName = updateFrm.SavedFullName;
                Session.CurrentUser.JobTitle = updateFrm.SavedJobTitle;
                Session.CurrentUser.Company = updateFrm.SavedCompany;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveLoginSettings()
        {
            if (toggleSwitch1.IsOn)
            {
                Settings.Default.SavedUserName = txtUserName.Text.Trim();
                Settings.Default.RememberMe = true;
            }
            else
            {
                Settings.Default.SavedUserName = "";
                Settings.Default.RememberMe = false;
            }
            Settings.Default.Save();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
        #endregion
    }
}
