using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;

namespace Etmam
{
    public partial class ucSecondaryDisciplinesList : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _canManage;
        private System.Collections.Generic.Dictionary<int, string> _disciplineNames = new();

        public ucSecondaryDisciplinesList()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = Data.PermissionService.HasPermission(PermNames.SecondaryDisciplines);
            bbiNew.Enabled = _canManage;
            bbiEdit.Enabled = _canManage;
            bbiDelete.Enabled = _canManage;

            DesignSystem.ApplyCairoFont(this);

            this.Load += async (s, e) => await LoadDataAsync();

            bbiNew.ItemClick += async (s, e) => await OpenAddEditAsync(0);
            bbiEdit.ItemClick += async (s, e) => await EditSelectedAsync();
            bbiDelete.ItemClick += async (s, e) => await DeleteSelectedAsync();
            bbiRefresh.ItemClick += async (s, e) => await LoadDataAsync();

            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;

            gridView1.DoubleClick += async (s, e) =>
            {
                if (gridView1.GetFocusedRow() is SecondaryDisciplinesList row)
                    await OpenAddEditAsync(row.Id);
            };
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "DisciplineId") return;
            if (e.Value is int disciplineId && _disciplineNames.TryGetValue(disciplineId, out var name))
                e.DisplayText = name;
        }

        public async Task LoadDataAsync()
        {
            var handle = ShowOverlay();
            try
            {
                var disciplines = await ApiClient.GetDisciplinesAsync();
                _disciplineNames = disciplines.ToDictionary(d => d.Id, d => d.Name ?? "");

                gridControl1.DataSource = await ApiClient.GetSecondaryDisciplinesAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل التخصصات الثانوية:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private async Task OpenAddEditAsync(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة التخصصات الثانوية.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openHandle = ShowOverlay();
            frmSecondaryDisciplineAddEdit frm;
            try { frm = new frmSecondaryDisciplineAddEdit(id); }
            finally { CloseOverlay(openHandle); }

            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    await LoadDataAsync();
                }
            }
        }

        private async Task EditSelectedAsync()
        {
            var row = gridView1.GetFocusedRow() as SecondaryDisciplinesList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد تخصص ثانوي لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await OpenAddEditAsync(row.Id);
        }

        private async Task DeleteSelectedAsync()
        {
            var row = gridView1.GetFocusedRow() as SecondaryDisciplinesList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد تخصص ثانوي لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا التخصص الثانوي؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    await ApiClient.DeleteSecondaryDisciplineAsync(row.Id);
                    XtraMessageBox.Show("تم حذف التخصص الثانوي بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            }
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
