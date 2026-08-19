using System;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class ucMAR : BaseUserControl
    {
        private bool _canManage;

        // ── Constructor ───────────────────────────────────────────────────────
        public ucMAR()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = PermissionService.HasPermission(PermNames.MaterialApprovalRequest);
            bbiInspection.Enabled = _canManage;
            bbiEditInspection.Enabled = _canManage;
            bbiDeleteInspection.Enabled = _canManage;
            bbiPrint.Enabled = _canManage;

            DesignSystem.ApplyCairoFont(this);
            SetupGridStyle();
            WireEvents();
            this.Load += (s, e) => LoadData();
        }

        // ── Grid Setup ────────────────────────────────────────────────────────
        private void SetupGridStyle()
        {
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);
            gridView1.OptionsView.ShowAutoFilterRow = true;

            // Column captions (Arabic)
            SetCaption("Num",           "رقم الطلب",       centered: true);
            SetCaption("Rev",           "الإصدار",         centered: true);
            SetCaption("Description",   "اسم المادة / المورد");
            SetCaption("Category",      "التصنيف",         centered: true);
            SetCaption("SubCategory",   "التصنيف الثانوي", centered: true);
            SetCaption("OverallStatus", "حالة الاعتماد",   centered: true);
            SetCaption("PreparedDate",  "تاريخ التقديم",   centered: true);

            // Open edit form on double-click
            gridView1.DoubleClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is MaterialApprovalRequestList rec)
                    OpenForm(rec.Id);
            };
        }

        private void SetCaption(string field, string caption, bool centered = false)
        {
            var col = gridView1.Columns[field];
            if (col == null) return;
            col.Caption = caption;
            if (centered) DesignSystem.SetColumnCentered(col);
        }

        private void WireEvents()
        {
            bbiInspection.ItemClick    += (s, e) => OpenForm(0);
            bbiEditInspection.ItemClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is MaterialApprovalRequestList rec)
                    OpenForm(rec.Id);
            };
            bbiRefresh.ItemClick += (s, e) => LoadData();

            // Live search using the search bar
            barEditItem1.EditValueChanged += (s, e) =>
            {
                string filter = barEditItem1.EditValue?.ToString() ?? "";
                gridView1.ActiveFilterString = string.IsNullOrWhiteSpace(filter)
                    ? ""
                    : $"[Description] Like '%{filter}%' OR [Num] Like '%{filter}%'";
            };
        }

        // ── Data ──────────────────────────────────────────────────────────────
        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                int prjId = Session.SelectedProjectId ?? 0;
                var data = (prjId > 0 && !Session.IsSingleProjectUser)
                    ? DC.MaterialApprovalRequestList.GetBy("PrjId = @PrjId AND IsDelete = 0", new { PrjId = prjId })
                    : DC.MaterialApprovalRequestList.GetBy("IsDelete = 0");

                gridControl1.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"خطأ في تحميل قائمة طلبات اعتماد المواد:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        public override void OnProjectChanged()
        {
            base.OnProjectChanged();
            LoadData();
        }

        // ── Commands ──────────────────────────────────────────────────────────
        // نقطة الدخول الموحّدة (bbiInspection/bbiEditInspection والنقر المزدوج) — الفحص هنا يمنع
        // تجاوز الصلاحية عبر النقر المزدوج الذي لا يمر بحالة تفعيل الأزرار.
        private void OpenForm(int id = 0)
        {
            if (!_canManage)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("ليس لديك صلاحية إدارة طلبات اعتماد المواد (MAR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmMARAddEdit frm;
            try { frm = new frmMARAddEdit(id); }
            finally { CloseOverlay(handle); }

            var result = frm.ShowDialog(this.FindForm());
            if (result == DialogResult.OK || result == DialogResult.Abort)
                LoadData();
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => OpenForm(0);

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
