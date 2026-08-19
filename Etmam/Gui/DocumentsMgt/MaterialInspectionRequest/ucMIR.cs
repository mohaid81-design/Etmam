using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using Core;
using Data;

namespace Etmam
{
    public partial class ucMIR : BaseUserControl
    {
        private bool _canManage;

        protected System.ComponentModel.BindingList<DrawingsSubmittalList> DataSource { get; set; } = new System.ComponentModel.BindingList<DrawingsSubmittalList>();
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
            var row = gridView1.GetFocusedRow() as DrawingsSubmittalList;
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

        public ucMIR()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = PermissionService.HasPermission(PermNames.MaterialInspectionRequest);
            bbiNew.Enabled = _canManage;
            bbiEdit.Enabled = _canManage;
            bbiDelete.Enabled = _canManage;
            bbiPrint.Enabled = _canManage;

            InitializeBaseGrid();
            SetupAconexStyle();
            this.Load += (s, e) => LoadData();
        }

        private void SetupAconexStyle()
        {
            if (gridView1 == null) return;

            DesignSystem.ApplyStatusColoring(gridView1, "CSTReviewStatus");
            gridView1.OptionsView.ShowAutoFilterRow = true;

            SetCaption("Num",            "رقم طلب الفحص");
            SetCaption("Rev",            "الإصدار",          centered: true);
            SetCaption("Description",    "وصف المواد الموردة");
            SetCaption("Category",       "التخصص",           centered: true);
            SetCaption("IssuedBy",       "مقدم الطلب");
            SetCaption("CSTReviewStatus","نتيجة الفحص",      centered: true);
            SetCaption("PreparedDate",   "تاريخ التوريد / الفحص");

            gridView1.DoubleClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is DrawingsSubmittalList rec)
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

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                int prjId = Core.Session.SelectedProjectId ?? 1;
                var data = DC.DrawingsSubmittalList.GetBy("PrjId = @PrjId AND IsDelete = 0 AND Type = @Type", new { PrjId = prjId, Type = "MIR" });
                DataSource.Clear();
                foreach (var item in data)
                    DataSource.Add(item);
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

        // نقطة الدخول الموحّدة (bbiNew والنقر المزدوج) — الفحص هنا يمنع تجاوز الصلاحية عبر
        // النقر المزدوج الذي لا يمر بحالة تفعيل الأزرار.
        private void OpenForm(int id = 0)
        {
            if (!_canManage)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("ليس لديك صلاحية إدارة طلبات فحص المواد (MIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmMARAddEdit frm;
            try { frm = new frmMARAddEdit(); }
            finally { CloseOverlay(handle); }

            var result = frm.ShowDialog(this.FindForm());
            if (result == DialogResult.OK || result == DialogResult.Abort)
                LoadData();
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => OpenForm(0);

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => LoadData();

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => PrintHelper.PrintMIR(DataSource);

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
