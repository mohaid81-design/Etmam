using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using Core;

namespace Etmam
{
    public partial class ucDwgMgt : BaseUserControl
    {
        protected System.ComponentModel.BindingList<DrawingsRegisterList> DataSource { get; set; } = new System.ComponentModel.BindingList<DrawingsRegisterList>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        protected void InitializeBaseGrid()
        {
            if (gridView1 == null || gridControl1 == null) return;
            DesignSystem.ApplyProfessionalStyle(gridView1);
            DesignSystem.HideAuditColumns(gridView1);
            gridControl1.DataSource = DataSource;
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            gridView1.KeyDown += StandardGridView_KeyDown;
        }

        protected void UpdateRecordCount()
        {
        }

        protected void StandardGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                ConfirmAndDeleteFocusedRow();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.V && e.Control)
            {
                HandleManualPaste();
                e.Handled = true;
            }
        }

        public virtual void ConfirmAndDeleteFocusedRow()
        {
            if (gridView1 == null) return;
            var row = gridView1.GetFocusedRow() as DrawingsRegisterList;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                gridView1.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (gridView1 == null) return;
                gridView1.CloseEditor();
                gridView1.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gridView1.BeginUpdate();
                int startRowHandle       = gridView1.FocusedRowHandle;
                bool startAtNewRow       = gridView1.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gridView1.FocusedColumn != null ? gridView1.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gridView1.DataRowCount || 
                        currentRowHandle < 0 || gridView1.IsNewItemRow(currentRowHandle))
                    {
                        gridView1.AddNewRow();
                        currentRowHandle = gridView1.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < gridView1.VisibleColumns.Count)
                        {
                            var col = gridView1.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                gridView1.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                gridView1.EndUpdate();
                OnDataChanged();
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("خطأ أثناء اللصق: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ucDwgMgt()
        {
            InitializeComponent();
            InitializeBaseGrid();
            SetupAconexStyle();

            this.Load += (s, e) => LoadData();
        }

        // ── Aconex-style grid setup ───────────────────────────────────────────

        private void SetupAconexStyle()
        {
            if (gridView1 == null) return;

            DesignSystem.ApplyStatusColoring(gridView1, "CSTReviewStatus");
            gridView1.OptionsView.ShowAutoFilterRow = true;

            SetCaption("DocName",        "اسم المخطط / الوثيقة");
            SetCaption("Num",            "رقم المخطط");
            SetCaption("Rev",            "الإصدار",       centered: true);
            SetCaption("Category",       "التخصص",        centered: true);
            SetCaption("Type",           "النوع",         centered: true);
            SetCaption("CSTReviewStatus","حالة الاعتماد", centered: true);
            SetCaption("PreparedDate",   "تاريخ الإصدار");
            SetCaption("Floor",          "الغرض");

            // Double-click → open edit form
            gridView1.DoubleClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is DrawingsRegisterList rec)
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

        // ── Data ──────────────────────────────────────────────────────────────

        public void LoadData()
        {
            // Aconex style: show only the LATEST revision for each document number
            int prjId = Core.Session.SelectedProjectId ?? 1;
            var all = DC.DrawingsRegisterList.GetBy("PrjId = @PrjId AND IsDelete = 0", new { PrjId = prjId });

            var latest = all
                .GroupBy(x => x.Num)
                .Select(g => g.OrderByDescending(x => x.Rev).First())
                .ToList();

            DataSource.Clear();
            foreach (var item in latest)
                DataSource.Add(item);
        }

        public override void OnProjectChanged()
        {
            base.OnProjectChanged();
            LoadData();
        }

        // ── CRUD ──────────────────────────────────────────────────────────────

        private void OpenForm(int id = 0)
        {
            var frm    = new frmDrawingsAddEdit(id);
            var result = frm.ShowDialog(this.FindForm());
            if (result == DialogResult.OK || result == DialogResult.Abort)
                LoadData();
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => OpenForm(0);

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => LoadData();

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => PrintHelper.PrintDrawings(DataSource);
    }
}
