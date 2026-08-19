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
    public partial class ucMaterialIssueReturn : DevExpress.XtraEditors.XtraUserControl
    {
        private HashSet<int> _grantedStoreIds = new();
        private bool _canManage;

        public ucMaterialIssueReturn()
        {
            InitializeComponent();
            if (DesignMode) return;

            var dcInit = Data.DataContext.Shared;
            _canManage = PermissionService.HasPermission(PermNames.MaterialIssueReturn);
            bool canAddAny = _canManage && PermissionService.CanAccessAnyStore(dcInit, StoreAction.Issue);
            bbiNew.Enabled = canAddAny;
            bbiEdit.Enabled = _canManage;
            btnOpen.Enabled = _canManage; // يفتح للعرض فقط بلا تعديل (btnOpen_ItemClick) — نفس صلاحية bbiEdit لتفادي تجاوزها
            bbiDelete.Enabled = _canManage;
            bbiPrint.Enabled = _canManage;

            DesignSystem.ApplyCairoFont(this);
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);

            // الديزاينر يضبط View بأكمله على Editable=false، وهو يمنع أي عمود من الاستجابة للنقر —
            // بما فيها أعمدة الأزرار مثل colPrint — بغض النظر عن AllowEdit الخاص بالعمود نفسه (نفس
            // ملاحظة ucPurchaseRequests). لذا الـ View يصبح قابلاً للتحرير عموماً، وكل عمود بيانات
            // يُمنع تحريره فردياً، فيما يبقى colPrint وحده AllowEdit=true ليعمل زرّه.
            gridView1.OptionsBehavior.Editable = true;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
                col.OptionsColumn.AllowEdit = col == colPrint;

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

            // عمود colPrint → طباعة مستند مرتجع الصرف المُركَّز عليه مباشرة بدون فتح النموذج
            repositoryItemButtonEditPrint.ButtonClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is MaterialIssueReturnList row)
                {
                    var handle = ShowOverlay();
                    try { MaterialIssueReturnPrinter.Print(row.Id); }
                    finally { CloseOverlay(handle); }
                }
            };

            // Wire Store Lookup change
            lookUpEditStore.EditValueChanged += (s, e) => LoadData();

            // يُعاد تقييم قابلية الفتح/التعديل/الحذف لكل صف عند تركيزه — بلا صف مركَّز، تُعطَّل الأزرار
            // المعنية (نفس تنظيم ucItems/ucStores).
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();

            // Double click grid row to edit
            gridView1.DoubleClick += (s, e) =>
            {
                var row = gridView1.GetFocusedRow() as MaterialIssueReturnList;
                if (row != null)
                {
                    OpenAddEdit(row.Id);
                }
            };
        }

        private void UpdateButtonStates()
        {
            var row = gridView1.GetFocusedRow() as MaterialIssueReturnList;
            btnOpen.Enabled = _canManage && row != null;
            bbiEdit.Enabled = _canManage && row != null;
            bbiDelete.Enabled = _canManage && row != null;
        }

        private void LoadLookups()
        {
            var dc = Data.DataContext.Shared;
            var stores = dc.StoreList.GetBy("IsDelete = 0").ToList();

            // فلتر المخزن يعرض فقط المخازن المصرَّح للمستخدم فيها بالصرف (UserStoreAccess.CanIssue) — مرتجع
            // الصرف عكس عملية الصرف نفسها، فيتبع نفس الصلاحية.
            _grantedStoreIds = InventoryStorePermissions.GrantedStoreIds(dc, a => a.CanIssue);
            var accessibleStores = stores.Where(s => _grantedStoreIds.Contains(s.Id)).ToList();

            lookUpEditStore.Properties.DataSource = accessibleStores;
            lookUpEditStore.Properties.ValueMember = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText = "-- الكل --";

            // عمود عرض المخزن في الشبكة يبقى بكل المخازن (لعرض اسم المخزن الصحيح لأي سطر بغض النظر عن صلاحية المستخدم الحالي)
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
                var storeVal = lookUpEditStore.EditValue;

                string filter = "IsDelete = 0";
                if (prjId > 0 && !Session.IsSingleProjectUser)
                {
                    filter += " AND PrjId = @PrjId";
                }
                if (storeVal != null && storeVal != DBNull.Value)
                {
                    filter += " AND StoreId = @StoreId";
                }
                else
                {
                    var ids = _grantedStoreIds.Count > 0 ? string.Join(",", _grantedStoreIds) : "-1";
                    filter += $" AND StoreId IN ({ids})";
                }

                var data = dc.MaterialIssueReturnList.GetBy(filter, new { PrjId = prjId, StoreId = storeVal }).ToList();
                foreach (var r in data)
                    r.FormattedNum = MaterialIssueReturnPrinter.FormatReturnNumber(r.Num, r.ReturnDate);

                gridControl1.DataSource = data;
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل مستندات مرتجع الصرف:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show("ليس لديك صلاحية إدارة مستندات مرتجع الصرف.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmMaterialIssueReturnAddEdit frm;
            try { frm = new frmMaterialIssueReturnAddEdit(id); }
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
            var row = gridView1.GetFocusedRow() as MaterialIssueReturnList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مستند مرتجع صرف لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        // فتح للعرض فقط (بلا حفظ أو إضافة/حذف أصناف) — بخلاف bbiEdit الذي يفتح للتعديل الكامل.
        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as MaterialIssueReturnList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مستند مرتجع صرف لفتحه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmMaterialIssueReturnAddEdit frm;
            try
            {
                frm = new frmMaterialIssueReturnAddEdit();
                frm.OpenReadOnly(row.Id);
            }
            finally { CloseOverlay(handle); }

            using (frm) frm.ShowDialog(this.FindForm());
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as MaterialIssueReturnList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مستند مرتجع صرف لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف مستند مرتجع الصرف هذا؟\nسيتم حذف جميع السطور المرتبطة به وتعديل الأرصدة تلقائياً.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    Data.DataContext.Shared.DeleteMaterialIssueReturn(row.Id);
                    XtraMessageBox.Show("تم حذف مستند مرتجع الصرف بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
