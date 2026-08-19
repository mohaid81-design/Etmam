using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    // Connection-profile manager: lets the user maintain any number of named SQL Server
    // connections (not just a fixed Local/Cloud pair) and switch the active one at runtime.
    // Backed by Data\DBSetting.cs, which persists the list centrally (encrypted) so it survives
    // Application.Restart().
    public partial class frmConnecting : XtraForm
    {
        private List<ConnectionProfile> _profiles = new();
        private string _activeProfileName = "";
        private string? _editingOriginalName;

        public frmConnecting()
        {
            InitializeComponent();
            LoadProfiles();
        }

        private void LoadProfiles()
        {
            _profiles = DBSetting.Profiles.Select(p => new ConnectionProfile
            {
                Name = p.Name,
                Server = p.Server,
                Database = p.Database,
                IntegratedSecurity = p.IntegratedSecurity,
                UserId = p.UserId,
                Password = p.Password,
                Encrypt = p.Encrypt,
            }).ToList();
            _activeProfileName = DBSetting.ActiveProfileName;

            RefreshGrid();
            SelectProfileInGrid(_activeProfileName);
            UpdateActiveLabel();
        }

        private void RefreshGrid()
        {
            profilesBindingSource.DataSource = null;
            profilesBindingSource.DataSource = _profiles;
            gridView1.RefreshData();
        }

        private void SelectProfileInGrid(string name)
        {
            var idx = _profiles.FindIndex(p => p.Name == name);
            if (idx >= 0)
                gridView1.FocusedRowHandle = idx;
            else
                LoadFields(null);
        }

        private void UpdateActiveLabel()
        {
            labelActive.Text = $"الاتصال النشط الحالي: {_activeProfileName}";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadFields(gridView1.GetFocusedRow() as ConnectionProfile);
        }

        private void LoadFields(ConnectionProfile? profile)
        {
            _editingOriginalName = profile?.Name;

            txtName.Text = profile?.Name ?? "";
            txtServer.Text = profile?.Server ?? "";
            txtDataBase.Text = profile?.Database ?? "";
            chkWindowsAuth.Checked = profile?.IntegratedSecurity ?? true;
            txtUser.Text = profile?.UserId ?? "";
            txtUserPassword.Text = profile?.Password ?? "";
            chkEncrypt.Checked = profile?.Encrypt ?? true;

            UpdateAuthFieldsEnabled();
        }

        private void chkWindowsAuth_CheckedChanged(object sender, EventArgs e) => UpdateAuthFieldsEnabled();

        private void UpdateAuthFieldsEnabled()
        {
            bool enabled = !chkWindowsAuth.Checked;
            txtUser.Enabled = enabled;
            txtUserPassword.Enabled = enabled;
        }

        private ConnectionProfile? BuildProfileFromFields(out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtServer.Text) || string.IsNullOrWhiteSpace(txtDataBase.Text))
            {
                error = "الرجاء إدخال اسم الاتصال وإسم المخدم وإسم قاعدة البيانات";
                return null;
            }

            return new ConnectionProfile
            {
                Name = txtName.Text.Trim(),
                Server = txtServer.Text.Trim(),
                Database = txtDataBase.Text.Trim(),
                IntegratedSecurity = chkWindowsAuth.Checked,
                UserId = txtUser.Text.Trim(),
                Password = txtUserPassword.Text,
                Encrypt = chkEncrypt.Checked,
            };
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            gridView1.ClearSelection();
            LoadFields(null);
            txtName.Focus();
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            var profile = BuildProfileFromFields(out var error);
            if (profile == null)
            {
                XtraMessageBox.Show(error, "تنبيه");
                return;
            }

            if (_profiles.Any(p => p.Name == profile.Name && p.Name != _editingOriginalName))
            {
                XtraMessageBox.Show("يوجد اتصال آخر بنفس الاسم", "تنبيه");
                return;
            }

            var handle = ShowOverlay();
            try
            {
                if (_editingOriginalName != null)
                {
                    var existingIndex = _profiles.FindIndex(p => p.Name == _editingOriginalName);
                    bool wasActive = _profiles[existingIndex].Name == _activeProfileName;
                    _profiles[existingIndex] = profile;
                    if (wasActive) _activeProfileName = profile.Name;
                }
                else
                {
                    _profiles.Add(profile);
                }

                DBSetting.SaveProfiles(_profiles, _activeProfileName);
                RefreshGrid();
                SelectProfileInGrid(profile.Name);
                UpdateActiveLabel();
            }
            finally
            {
                CloseOverlay(handle);
            }

            XtraMessageBox.Show("تم حفظ الاتصال", "حفظ");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() is not ConnectionProfile profile)
                return;

            if (_profiles.Count <= 1)
            {
                XtraMessageBox.Show("لا يمكن حذف آخر اتصال متبقي", "تنبيه");
                return;
            }

            if (XtraMessageBox.Show($"هل تريد حذف الاتصال '{profile.Name}'؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var handle = ShowOverlay();
            try
            {
                _profiles.RemoveAll(p => p.Name == profile.Name);
                if (_activeProfileName == profile.Name)
                    _activeProfileName = _profiles[0].Name;

                DBSetting.SaveProfiles(_profiles, _activeProfileName);
                RefreshGrid();
                SelectProfileInGrid(_activeProfileName);
                UpdateActiveLabel();
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            var profile = BuildProfileFromFields(out var error);
            if (profile == null)
            {
                XtraMessageBox.Show(error, "تنبيه");
                return;
            }

            btnTest.Enabled = false;
            var handle = ShowOverlay();
            try
            {
                bool ok = await DBSetting.CanConnectAsync(profile.BuildConnectionString());
                XtraMessageBox.Show(ok ? "تم الاتصال بنجاح" : "فشل الاتصال، تحقق من البيانات المدخلة",
                    ok ? "نجاح" : "خطأ", MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            finally
            {
                btnTest.Enabled = true;
                CloseOverlay(handle);
            }
        }

        private void btnSetActive_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() is not ConnectionProfile profile)
                return;

            if (XtraMessageBox.Show($"سيتم استخدام الاتصال '{profile.Name}' وإعادة تشغيل البرنامج، هل تريد المتابعة؟",
                "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var handle = ShowOverlay();
            try
            {
                _activeProfileName = profile.Name;
                DBSetting.SaveProfiles(_profiles, _activeProfileName);
            }
            finally
            {
                CloseOverlay(handle);
            }
            Application.Restart();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
