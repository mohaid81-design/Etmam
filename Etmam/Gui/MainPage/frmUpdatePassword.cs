using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmUpdatePassword : XtraForm
    {
        // Prefilled directly from frmLogin's already-fetched ApiLoginResult instead of a separate
        // "get user" round trip - the login response already carries everything this form needs.
        public string? SavedFullName { get; private set; }
        public string? SavedJobTitle { get; private set; }
        public string? SavedCompany { get; private set; }

        public frmUpdatePassword(string? fullName, string? jobTitle, string? company)
        {
            InitializeComponent();
            //DesignSystem.ApplyFormBranding(this);
            this.Icon = AppIcon.Default;
            txtFullName.Text = fullName;
            txtJobTitle.Text = jobTitle;
            txtCompany.Text = company;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string jobTitle = txtJobTitle.Text.Trim();
            string company = txtCompany.Text.Trim();
            string newPass = txtNewPassword.Text;
            string confPass = txtConfirmPassword.Text;

            // Validate mandatory fields
            if (string.IsNullOrEmpty(fullName))
            {
                XtraMessageBox.Show("يرجى إدخال الاسم الكامل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(jobTitle))
            {
                XtraMessageBox.Show("يرجى إدخال الوصف الوظيفي", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJobTitle.Focus();
                return;
            }

            if (string.IsNullOrEmpty(company))
            {
                XtraMessageBox.Show("يرجى إدخال اسم الشركة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompany.Focus();
                return;
            }

            if (string.IsNullOrEmpty(newPass) || newPass.Length < 4 || newPass == "0000")
            {
                string msg = newPass == "0000" ? "لا يمكن استخدام '0000' ككلمة سر جديدة" : "كلمة المرور يجب أن تكون 4 أحرف على الأقل";
                XtraMessageBox.Show(msg, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPass != confPass)
            {
                XtraMessageBox.Show("كلمات المرور غير متطابقة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            var handle = ShowOverlay();
            try
            {
                await ApiClient.CompleteProfileAsync(fullName, jobTitle, company, newPass);

                SavedFullName = fullName;
                SavedJobTitle = jobTitle;
                SavedCompany = company;

                XtraMessageBox.Show("تم تحديث البيانات بنجاح. يرجى تسجيل الدخول مرة أخرى.", "تم بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء حفظ البيانات:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
