using System;
using System.Windows.Forms;
using Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    public partial class ucMAR : BaseUserControl
    {
        // ── Constructor ───────────────────────────────────────────────────────
        public ucMAR()
        {
            InitializeComponent();
            if (DesignMode) return;

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
            try
            {
                int prjId = Session.SelectedProjectId ?? 0;
                var data = prjId > 0
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
        }

        public override void OnProjectChanged()
        {
            base.OnProjectChanged();
            LoadData();
        }

        // ── Commands ──────────────────────────────────────────────────────────
        private void OpenForm(int id = 0)
        {
            var frm = new frmMARAddEdit(id);
            var result = frm.ShowDialog(this.FindForm());
            if (result == DialogResult.OK || result == DialogResult.Abort)
                LoadData();
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => OpenForm(0);
    }
}
