using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;

namespace Etmam
{
    public partial class ucFloorsList : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _canManage;
        private System.Collections.Generic.Dictionary<int, string> _buildingNames = new();

        public ucFloorsList()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = Data.PermissionService.HasPermission(PermNames.Floors);
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
                if (gridView1.GetFocusedRow() is FloorsList row)
                    await OpenAddEditAsync(row.Id);
            };
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "BuildingId") return;
            if (e.Value is int buildingId && _buildingNames.TryGetValue(buildingId, out var name))
                e.DisplayText = name;
        }

        public async Task LoadDataAsync()
        {
            var handle = ShowOverlay();
            try
            {
                var buildings = await ApiClient.GetBuildingsAsync();
                _buildingNames = buildings.ToDictionary(b => b.Id, b => b.Name ?? "");

                gridControl1.DataSource = await ApiClient.GetFloorsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل الطوابق:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show("ليس لديك صلاحية إدارة الطوابق.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openHandle = ShowOverlay();
            frmFloorAddEdit frm;
            try { frm = new frmFloorAddEdit(id); }
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
            var row = gridView1.GetFocusedRow() as FloorsList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد طابق لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await OpenAddEditAsync(row.Id);
        }

        private async Task DeleteSelectedAsync()
        {
            var row = gridView1.GetFocusedRow() as FloorsList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد طابق لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا الطابق؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    await ApiClient.DeleteFloorAsync(row.Id);
                    XtraMessageBox.Show("تم حذف الطابق بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
