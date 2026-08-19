using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;
using Data;

namespace Etmam
{
    public partial class ucProjectsMgt : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _canManage;

        public ucProjectsMgt()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = PermissionService.HasPermission(PermNames.ProjectDetails);
            bbiNew.Enabled = _canManage;
            bbiEdit.Enabled = _canManage;
            bbiDelete.Enabled = _canManage;
            bbiPrint.Enabled = _canManage;

            this.Load += async (s, e) => await LoadDataAsync();

            gridView1.DoubleClick += async (s, e) =>
            {
                var row = gridView1.GetFocusedRow() as ProjectsList;
                if (row != null)
                {
                    await OpenAddEditAsync(row.Id);
                }
            };
        }

        public async Task LoadDataAsync()
        {
            var handle = ShowOverlay();
            try
            {
                var data = await ApiClient.GetProjectsAsync();
                gridControl1.DataSource = data.OrderBy(p => p.Name).ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل المشاريع:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // نقطة الدخول الموحّدة (bbiNew/bbiEdit والنقر المزدوج) — الفحص هنا يمنع تجاوز الصلاحية عبر
        // النقر المزدوج الذي لا يمر بحالة تفعيل الأزرار.
        private async Task OpenAddEditAsync(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة المشروعات.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openHandle = ShowOverlay();
            frmProjectAddEdit frm;
            try { frm = new frmProjectAddEdit(id); }
            finally { CloseOverlay(openHandle); }

            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    await LoadDataAsync();
                }
            }
        }

        private async void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await OpenAddEditAsync(0);
        }

        private async void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as ProjectsList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مشروع لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await OpenAddEditAsync(row.Id);
        }

        private async void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as ProjectsList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مشروع لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ProjectValidationHelper.HasTransactions(row.Id))
            {
                XtraMessageBox.Show("لا يمكن حذف هذا المشروع لأنه مستخدم في عمليات مرتبطة به.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا المشروع؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    // الحذف الناعم وتنظيف UserProjectAccess المرتبط ينفذهما ProjectsService.DeleteAsync
                    // على الخادم داخل معاملة واحدة بدلاً من خطوتين منفصلتين غير متزامنتين هنا.
                    await ApiClient.DeleteProjectAsync(row.Id);

                    XtraMessageBox.Show("تم حذف المشروع بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridControl1.ShowPrintPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await LoadDataAsync();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
