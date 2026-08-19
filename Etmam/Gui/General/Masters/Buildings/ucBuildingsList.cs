using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;

namespace Etmam
{
    public partial class ucBuildingsList : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _canManage;
        private System.Collections.Generic.Dictionary<int, string> _projectNames = new();

        public ucBuildingsList()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = Data.PermissionService.HasPermission(PermNames.Buildings);
            bbiNew.Enabled = _canManage;
            bbiEdit.Enabled = _canManage;
            bbiDelete.Enabled = _canManage;

            DesignSystem.ApplyCairoFont(this);

            this.Load += (s, e) => LoadData();

            bbiNew.ItemClick += (s, e) => OpenAddEdit(0);
            bbiEdit.ItemClick += (s, e) => EditSelected();
            bbiDelete.ItemClick += (s, e) => DeleteSelected();
            bbiRefresh.ItemClick += (s, e) => LoadData();

            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;

            gridView1.DoubleClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is BuildingsList row)
                    OpenAddEdit(row.Id);
            };
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "PrjId") return;
            if (e.Value is int prjId && _projectNames.TryGetValue(prjId, out var name))
                e.DisplayText = name;
        }

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                _projectNames = Data.DataContext.Shared.ProjectsList.GetBy("IsDelete = 0")
                    .ToDictionary(p => p.Id, p => p.Name ?? "");

                var data = Data.DataContext.Shared.BuildingsList.GetBy("IsDelete = 0");
                gridControl1.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل المباني:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void OpenAddEdit(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة المباني.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openHandle = ShowOverlay();
            frmBuildingAddEdit frm;
            try { frm = new frmBuildingAddEdit(id); }
            finally { CloseOverlay(openHandle); }

            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void EditSelected()
        {
            var row = gridView1.GetFocusedRow() as BuildingsList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مبنى لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void DeleteSelected()
        {
            var row = gridView1.GetFocusedRow() as BuildingsList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مبنى لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا المبنى؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    row.IsDelete = true;
                    row.DeletionDate = DateTime.Now;
                    row.DeletionMachine = Session.Machine;
                    row.DeletionBy = Session.CurrentUser?.Id ?? 1;

                    Data.DataContext.Shared.BuildingsList.Edit(row.Id, row);
                    XtraMessageBox.Show("تم حذف المبنى بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
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
