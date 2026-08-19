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
    public partial class ucStocking : DevExpress.XtraEditors.XtraUserControl
    {
        private HashSet<int> _grantedStoreIds = new();
        private bool _canManage;

        public ucStocking()
        {
            InitializeComponent();
            if (DesignMode) return;

            var dcInit = Data.DataContext.Shared;
            _canManage = PermissionService.HasPermission(PermNames.MaterialStocking);
            bool canAddAny = _canManage && PermissionService.CanAccessAnyStore(dcInit, StoreAction.View);
            bbiNew.Enabled = canAddAny;
            bbiEdit.Enabled = _canManage;
            btnOpen.Enabled = _canManage; // يفتح للعرض فقط بلا تعديل (btnOpen_ItemClick) — نفس صلاحية bbiEdit لتفادي تجاوزها
            bbiDelete.Enabled = _canManage;
            bbiPrint.Enabled = _canManage;

            DesignSystem.ApplyCairoFont(this);
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);

            this.Load += (s, e) => {
                LoadLookups();
                LoadData();
            };

            // Wire Toolbar Events
            bbiNew.ItemClick += bbiNew_ItemClick;
            btnOpen.ItemClick += btnOpen_ItemClick;
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            bbiPrint.ItemClick += bbiPrint_ItemClick;

            // يُعاد تقييم قابلية الفتح/التعديل/الحذف لكل صف عند تركيزه — بلا صف مركَّز، تُعطَّل الأزرار
            // المعنية (نفس تنظيم ucItems/ucStores).
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();

            // Double click grid row to edit
            gridView1.DoubleClick += (s, e) =>
            {
                var row = gridView1.GetFocusedRow() as StockingList;
                if (row != null)
                {
                    OpenAddEdit(row.Id);
                }
            };
        }

        private void UpdateButtonStates()
        {
            var row = gridView1.GetFocusedRow() as StockingList;
            btnOpen.Enabled = _canManage && row != null;
            bbiEdit.Enabled = _canManage && row != null;
            bbiDelete.Enabled = _canManage && row != null;
        }

        private void LoadLookups()
        {
            var dc = Data.DataContext.Shared;
            var stores = dc.StoreList.GetBy("IsDelete = 0").ToList();

            // لا يوجد فلتر مخزن مستقل بهذه الشاشة — نُقيِّد المعروض مباشرة على المخازن المصرَّح
            // للمستخدم بالاطلاع عليها (UserStoreAccess.PermsStatus) — الجرد لا يغيّر الرصيد (تسوية فقط)
            // فيكتفى بصلاحية العرض، بخلاف الاستلام/الصرف/التحويل التي تتطلب أعلاماً أدق.
            _grantedStoreIds = InventoryStorePermissions.GrantedStoreIds(dc, a => a.PermsStatus);

            // عمود عرض المخزن في الشبكة يبقى بكل المخازن (لعرض اسم المخزن الصحيح لأي سطر)
            riLookUpStore.DataSource = stores;
            riLookUpStore.ValueMember = "Id";
            riLookUpStore.DisplayMember = "Name";
            riLookUpStore.NullText = "";
        }

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var dc = Data.DataContext.Shared;
                int prjId = Session.SelectedProjectId ?? 0;

                string filter = "IsDelete = 0";
                if (prjId > 0 && !Session.IsSingleProjectUser)
                {
                    filter += " AND PrjId = @PrjId";
                }

                var ids = _grantedStoreIds.Count > 0 ? string.Join(",", _grantedStoreIds) : "-1";
                filter += $" AND StoreId IN ({ids})";

                var data = dc.StockingList.GetBy(filter, new { PrjId = prjId })
                    .OrderByDescending(r => r.StockingDate)
                    .ThenByDescending(r => r.Id);
                gridControl1.DataSource = data.ToList();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل مستندات الجرد:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // نقطة الدخول الموحّدة (bbiNew/btnOpen/bbiEdit والنقر المزدوج) — الفحص هنا يمنع تجاوز الصلاحية
        // عبر أي من هذه المسارات التي لا تمر جميعها بحالة تفعيل الأزرار.
        private void OpenAddEdit(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة مستندات الجرد.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmStockingAddEdit frm;
            try { frm = new frmStockingAddEdit(id); }
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
            var row = gridView1.GetFocusedRow() as StockingList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مستند جرد لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        // فتح للعرض فقط (بلا حفظ أو إضافة/حذف أصناف) — بخلاف bbiEdit الذي يفتح للتعديل الكامل.
        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as StockingList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مستند جرد لفتحه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmStockingAddEdit frm;
            try
            {
                frm = new frmStockingAddEdit();
                frm.OpenReadOnly(row.Id);
            }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                frm.ShowDialog(this.FindForm());
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as StockingList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مستند جرد لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف مستند الجرد هذا؟\nسيتم حذف جميع السطور المرتبطة به.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    Data.DataContext.Shared.DeleteStocking(row.Id);
                    XtraMessageBox.Show("تم حذف مستند الجرد بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
