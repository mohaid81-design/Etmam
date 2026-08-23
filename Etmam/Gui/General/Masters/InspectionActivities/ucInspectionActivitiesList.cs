using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;

namespace Etmam
{
    public partial class ucInspectionActivitiesList : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _canManage;
        private System.Collections.Generic.Dictionary<int, string> _secondaryDisciplineNames = new();
        private System.Collections.Generic.Dictionary<int, string> _disciplineNamesBySecondaryId = new();

        public ucInspectionActivitiesList()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = Data.PermissionService.HasPermission(PermNames.InspectionActivities);
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
                if (gridView1.GetFocusedRow() is InspectionActivityList row)
                    await OpenAddEditAsync(row.Id);
            };
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value is not int secondaryDisciplineId) return;

            if (e.Column.Name == "colSecondaryDiscipline" && _secondaryDisciplineNames.TryGetValue(secondaryDisciplineId, out var subName))
                e.DisplayText = subName;
            else if (e.Column.Name == "colDiscipline" && _disciplineNamesBySecondaryId.TryGetValue(secondaryDisciplineId, out var name))
                e.DisplayText = name;
        }

        public async Task LoadDataAsync()
        {
            var handle = ShowOverlay();
            try
            {
                var disciplineNames = (await ApiClient.GetDisciplinesAsync()).ToDictionary(d => d.Id, d => d.Name ?? "");

                var secondaryDisciplines = await ApiClient.GetSecondaryDisciplinesAsync();
                _secondaryDisciplineNames = secondaryDisciplines.ToDictionary(s => s.Id, s => s.Name ?? "");
                _disciplineNamesBySecondaryId = secondaryDisciplines
                    .Where(s => s.DisciplineId != null && disciplineNames.ContainsKey(s.DisciplineId.Value))
                    .ToDictionary(s => s.Id, s => disciplineNames[s.DisciplineId!.Value]);

                gridControl1.DataSource = await ApiClient.GetInspectionActivitiesAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل أنشطة الفحص:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show("ليس لديك صلاحية إدارة أنشطة الفحص.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openHandle = ShowOverlay();
            frmInspectionActivityAddEdit frm;
            try { frm = new frmInspectionActivityAddEdit(id); }
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
            var row = gridView1.GetFocusedRow() as InspectionActivityList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد نشاط فحص لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await OpenAddEditAsync(row.Id);
        }

        private async Task DeleteSelectedAsync()
        {
            var row = gridView1.GetFocusedRow() as InspectionActivityList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد نشاط فحص لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف نشاط الفحص هذا؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    await ApiClient.DeleteInspectionActivityAsync(row.Id);
                    XtraMessageBox.Show("تم حذف نشاط الفحص بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
