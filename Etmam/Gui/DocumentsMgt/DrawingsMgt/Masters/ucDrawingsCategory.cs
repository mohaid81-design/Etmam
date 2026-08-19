using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;

namespace Etmam
{
    public partial class ucDrawingsCategory : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _canManage;

        public ucDrawingsCategory()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = Data.PermissionService.HasPermission(PermNames.DrawingsApprovalRequest);
            bbiNew.Enabled = _canManage;
            bbiEdit.Enabled = _canManage;
            bbiDelete.Enabled = _canManage;

            DesignSystem.ApplyCairoFont(this);

            this.Load += (s, e) => LoadData();

            bbiNew.ItemClick += (s, e) => OpenAddEdit(0);
            bbiEdit.ItemClick += (s, e) => EditSelected();
            bbiDelete.ItemClick += (s, e) => DeleteSelected();
            bbiRefresh.ItemClick += (s, e) => LoadData();

            gridView1.DoubleClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is DrawingsCategory row)
                    OpenAddEdit(row.Id);
            };
        }

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var data = Data.DataContext.Shared.DrawingsCategory.GetBy("IsDelete = 0");
                gridControl1.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل تصنيفات المخططات:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show("ليس لديك صلاحية إدارة تصنيفات المخططات.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmDrawingsCategoryAddEdit frm;
            try { frm = new frmDrawingsCategoryAddEdit(id); }
            finally { CloseOverlay(handle); }

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
            var row = gridView1.GetFocusedRow() as DrawingsCategory;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد تصنيف لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void DeleteSelected()
        {
            var row = gridView1.GetFocusedRow() as DrawingsCategory;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد تصنيف لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا التصنيف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    row.IsDelete = true;
                    row.DeletionDate = DateTime.Now;
                    row.DeletionMachine = Session.Machine;
                    row.DeletionBy = Session.CurrentUser?.Id ?? 1;

                    Data.DataContext.Shared.DrawingsCategory.Edit(row.Id, row);
                    XtraMessageBox.Show("تم حذف التصنيف بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
