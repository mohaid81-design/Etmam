using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;
using Data;

namespace Etmam
{
    public partial class ucStores : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _allowed;

        public ucStores()
        {
            InitializeComponent();
            if (DesignMode) return;

            // Apply styling
            //DesignSystem.ApplyCairoFont(this);
            //DesignSystem.ApplyGridStyle(gridControl1, gridView1);

            _allowed = StorePermissions.CanManage(Data.DataContext.Shared);
            bbiNew.Enabled = _allowed;
            btnOpen.Enabled = _allowed;
            bbiEdit.Enabled = _allowed;
            bbiDelete.Enabled = _allowed;
            bbiPrint.Enabled = _allowed;

            this.Load += (s, e) => LoadData();

            btnOpen.ItemClick += btnOpen_ItemClick;

            // يُعاد تقييم قابلية التعديل/الحذف لكل صف عند تركيزه — بلا صف مركَّز أصلاً، أو صف مستخدم في
            // مستندات محفوظة (يُمنع حذفه دوماً بصرف النظر عن الصلاحية، انظر ItemStoreLock).
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();

            // Double click grid row to edit
            gridView1.DoubleClick += (s, e) =>
            {
                if (!_allowed) return;

                var row = gridView1.GetFocusedRow() as StoreList;
                if (row != null)
                {
                    OpenAddEdit(row.Id);
                }
            };
        }

        // يُحدِّث تفعيل أزرار فتح/تعديل/حذف حسب الصف المركَّز حالياً — بلا صف مركَّز، أو صف بلا صلاحية،
        // تُعطَّل الأزرار المعنية؛ الحذف يُعطَّل أيضاً إذا كان المخزن مستخدماً فعلاً في مستند محفوظ حتى
        // ولو توفرت الصلاحية (لا فائدة من تفعيل زر سيرفضه bbiDelete_ItemClick على أي حال).
        private void UpdateButtonStates()
        {
            var row = gridView1.GetFocusedRow() as StoreList;

            btnOpen.Enabled = _allowed && row != null;
            bbiEdit.Enabled = _allowed && row != null;

            bool canDelete = _allowed && row != null
                && (PermissionService.IsSuperUser || !ItemStoreLock.IsStoreUsed(Data.DataContext.Shared, row.Id));
            bbiDelete.Enabled = canDelete;
        }

        // فتح للعرض فقط (بلا حفظ) — بخلاف bbiEdit الذي يفتح للتعديل الكامل.
        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as StoreList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مخزن لفتحه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openHandle = ShowOverlay();
            frmStoreAddEdit openFrm;
            try { openFrm = new frmStoreAddEdit(row.Id, readOnly: true); }
            finally { CloseOverlay(openHandle); }

            using (openFrm)
            {
                openFrm.ShowDialog(this.FindForm());
            }
        }

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var dc = Data.DataContext.Shared;
                int prjId = Session.SelectedProjectId ?? 0;
                var data = (prjId > 0 && !Session.IsSingleProjectUser)
                    ? dc.StoreList.GetBy("(PrjId = @PrjId OR PrjId IS NULL) AND IsDelete = 0", new { PrjId = prjId })
                    : dc.StoreList.GetBy("IsDelete = 0");

                gridControl1.DataSource = data.ToList();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل مخازن:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void OpenAddEdit(int id)
        {
            var handle = ShowOverlay();
            frmStoreAddEdit frm;
            try { frm = new frmStoreAddEdit(id); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenAddEdit(0);
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as StoreList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مخزن لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as StoreList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مخزن لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // نفس فحص ItemStoreLock المستخدم لتعطيل الزر أصلاً (انظر UpdateButtonStates) — يبقى هنا
            // كخط دفاع ثانٍ لا كمصدر وحيد للتحقق.
            if (!PermissionService.IsSuperUser && ItemStoreLock.IsStoreUsed(Data.DataContext.Shared, row.Id))
            {
                XtraMessageBox.Show("لا يمكن حذف هذا المخزن لأنه مستخدم في مستندات محفوظة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا المخزن؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    row.IsDelete = true;
                    row.DeletionDate = DateTime.Now;
                    row.DeletionMachine = Session.Machine;
                    row.DeletionBy = Session.CurrentUser?.Id ?? 1;

                    Data.DataContext.Shared.StoreList.Edit(row.Id, row);
                    XtraMessageBox.Show("تم حذف المخزن بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        public void OnProjectChanged()
        {
            LoadData();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
