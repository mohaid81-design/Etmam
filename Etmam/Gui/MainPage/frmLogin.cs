using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;
using Core;

using Etmam.Properties;

namespace Etmam
{
    public partial class frmLogin : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;

        #region Constructor
        public frmLogin()
        {
            InitializeComponent();
            DesignSystem.ApplyFormBranding(this);
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show("من فضلك أدخل اسم المستخدم وكلمة المرور", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = DC.UsersList.GetBy("UserName = @UserName AND IsActive = 1 AND IsDelete = 0", new { UserName = userName }).FirstOrDefault();

                if (user != null && Core.Security.PasswordHasher.Verify(password, user.Password))
                {
                    // Transparently upgrade legacy plaintext passwords to a hash now that we know it's correct.
                    // "0000" is left untouched: it's a sentinel meaning "force password change", checked below.
                    if (!Core.Security.PasswordHasher.IsHashed(user.Password) && user.Password != "0000")
                    {
                        user.Password = Core.Security.PasswordHasher.Hash(password);
                        DC.UsersList.Edit(user.Id, user);
                    }

                    HandleSuccessfulLogin(user);
                }
                else
                {
                    XtraMessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء الاتصال بقاعدة البيانات:\n{ex.Message}", "خطأ في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Logic Methods
        private void HandleSuccessfulLogin(Core.UsersList user)
        {
            // Set session data
            Session.CurrentUser = user;
            Session.Machine = Environment.MachineName;

            SaveLoginSettings();
            LogAction(user.Id, user.UserName, "دخول", "شاشة الدخول");

            // Mandatory Password Update and Profile Completion
            if (user.IsFirstLogin || 
                user.Password == "0000" ||
                string.IsNullOrWhiteSpace(user.FullName) || 
                string.IsNullOrWhiteSpace(user.JobTitle) || 
                string.IsNullOrWhiteSpace(user.Company))
            {
                using (var updateFrm = new frmUpdatePassword(user.Id))
                {
                    if (updateFrm.ShowDialog() != DialogResult.OK) return;
                }
                
                // Refresh session data after mandatory update
                Session.CurrentUser = DC.UsersList.GetBy("Id = @Id", new { Id = user.Id }).First();
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

        private void LogAction(int userId, string? userName, string type, string location)
        {
            try
            {
                DC.ActionLogs.Add(new Core.ActionLogs
                {
                    UserID = userId,
                    UserName = userName ?? "Unknown",
                    ActionType = type,
                    ActionLocation = location,
                    ActionDate = DateTime.Now,
                    MachineName = Environment.MachineName
                });
            }
            catch { /* Silent log failure to avoid blocking login */ }
        }
        #endregion
    }
}
