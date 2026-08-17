using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Data;

namespace Etmam
{
    public partial class frmUpdatePassword : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private readonly int _userId;
        private Core.UsersList? _user;

        public frmUpdatePassword(int userId)
        {
            InitializeComponent();
            DesignSystem.ApplyFormBranding(this);
            _userId = userId;
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                _user = DC.UsersList.GetBy("Id = @Id", new { Id = _userId }).FirstOrDefault();
                if (_user != null)
                {
                    txtFullName.Text = _user.FullName;
                    txtJobTitle.Text = _user.JobTitle;
                    txtCompany.Text = _user.Company;
                }
            }
            catch { /* Silent failure for loading */ }
        }

        private void btnSave_Click(object sender, EventArgs e)
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

            if (_user == null)
            {
                XtraMessageBox.Show("تعذر تحميل بيانات المستخدم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Update user details, hash the new password, and clear IsFirstLogin flag
                _user.FullName = fullName;
                _user.JobTitle = jobTitle;
                _user.Company = company;
                _user.Password = Core.Security.PasswordHasher.Hash(newPass);
                _user.IsFirstLogin = false;

                DC.UsersList.Edit(_user.Id, _user);

                XtraMessageBox.Show("تم تحديث البيانات بنجاح. يرجى تسجيل الدخول مرة أخرى.", "تم بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء حفظ البيانات:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
