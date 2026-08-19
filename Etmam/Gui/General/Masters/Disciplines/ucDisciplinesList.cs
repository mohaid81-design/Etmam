using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;

namespace Etmam
{
    public partial class ucDisciplinesList : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _canManage;

        public ucDisciplinesList()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = Data.PermissionService.HasPermission(PermNames.Disciplines);
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
                if (gridView1.GetFocusedRow() is DisciplinesList row)
                    OpenAddEdit(row.Id);
            };
        }

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var data = Data.DataContext.Shared.DisciplinesList.GetBy("IsDelete = 0");
                gridControl1.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل التخصصات:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show("ليس لديك صلاحية إدارة التخصصات.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openHandle = ShowOverlay();
            frmDisciplineAddEdit frm;
            try { frm = new frmDisciplineAddEdit(id); }
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
            var row = gridView1.GetFocusedRow() as DisciplinesList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد تخصص لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void DeleteSelected()
        {
            var row = gridView1.GetFocusedRow() as DisciplinesList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد تخصص لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا التخصص؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    row.IsDelete = true;
                    row.DeletionDate = DateTime.Now;
                    row.DeletionMachine = Session.Machine;
                    row.DeletionBy = Session.CurrentUser?.Id ?? 1;

                    Data.DataContext.Shared.DisciplinesList.Edit(row.Id, row);
                    XtraMessageBox.Show("تم حذف التخصص بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
