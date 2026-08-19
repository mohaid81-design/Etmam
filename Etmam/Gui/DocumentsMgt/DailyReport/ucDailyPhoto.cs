using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.IO;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;
using Core;

namespace Etmam
{
    public partial class ucDailyPhoto : BaseUserControl
    {
        protected System.ComponentModel.BindingList<Core.DailyReportPhoto> DataSource { get; set; } = new System.ComponentModel.BindingList<Core.DailyReportPhoto>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        protected void InitializeBaseGrid()
        {
            if (tileView1 == null || gridPhoto == null) return;
            gridPhoto.DataSource = DataSource;
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            tileView1.KeyDown += StandardGridView_KeyDown;
        }

        protected void UpdateRecordCount()
        {
            if (barStaticItem1 != null)
                barStaticItem1.Caption = $"عدد السجلات : {DataSource.Count}";
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
            if (tileView1 == null) return;
            var row = tileView1.GetFocusedRow() as Core.DailyReportPhoto;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                tileView1.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (tileView1 == null) return;
                tileView1.CloseEditor();
                tileView1.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                tileView1.BeginUpdate();
                int startRowHandle       = tileView1.FocusedRowHandle;
                bool startAtNewRow       = tileView1.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = tileView1.FocusedColumn != null ? tileView1.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= tileView1.DataRowCount || 
                        currentRowHandle < 0 || tileView1.IsNewItemRow(currentRowHandle))
                    {
                        tileView1.AddNewRow();
                        currentRowHandle = tileView1.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < tileView1.VisibleColumns.Count)
                        {
                            var col = tileView1.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                tileView1.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                tileView1.EndUpdate();
                OnDataChanged();
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("خطأ أثناء اللصق: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearDeletedIds() => DeletedIds.Clear();
        public System.Collections.Generic.List<int> GetDeletedIds() => DeletedIds;

        public virtual void HandleToolbarCopy()
        {
            if (CurrentProjectId == 0) return;

            var handle = ShowOverlay();
            try
            {
                var lastReport = DC.DailyReport.GetBy(
                    "PrjId = @pId AND ReportDate < @rDate AND IsDelete = 0 ORDER BY ReportDate DESC",
                    new { pId = CurrentProjectId, rDate = CurrentReportDate }).FirstOrDefault();

                if (lastReport == null)
                {
                    XtraMessageBox.Show("لا يوجد تقرير سابق لنسخ البيانات منه لهذا المشروع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int count = CopyFromPrevious(lastReport.Id);
                if (count > 0)
                {
                    XtraMessageBox.Show($"تم نسخ {count} سجلات بنجاح من تقرير يوم {lastReport.ReportDate:yyyy/MM/dd}.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("تم نسخ كافة البيانات المتاحة مسبقاً أو لا توجد بيانات جديدة للنسخ.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        public override int CopyFromPrevious(int lastReportId)
        {
            if (lastReportId == 0) return 0;
            var previousItems = DC.GetHelper<Core.DailyReportPhoto>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = lastReportId });
            int count = 0;
            var duplicatePredicate = GetDuplicatePredicate();

            foreach (var prevItem in previousItems)
            {
                if (DataSource.Any(curr => duplicatePredicate(curr, prevItem))) continue;
                if (!CopyFilter(prevItem)) continue;

                var newItem = new Core.DailyReportPhoto();
                MapForCopy(prevItem, newItem);
                newItem.DailyReportId = CurrentDailyReportId;
                newItem.Id = 0;
                newItem.CreatedDate = DateTime.Now;
                newItem.CreatedMachine = Session.Machine;
                newItem.CreatedBy = Session.CurrentUser?.Id ?? 0;
                DataSource.Add(newItem);
                count++;
            }

            if (count > 0)
            {
                UpdateRecordCount();
                OnDataChanged();
            }
            return count;
        }

        protected virtual void MapForCopy(Core.DailyReportPhoto source, Core.DailyReportPhoto destination)
        {
            var props = typeof(Core.DailyReportPhoto).GetProperties().Where(p => p.CanWrite && p.CanRead);
            var skipList = new[] { "Id", "DailyReportId", "CreatedDate", "CreatedMachine", "CreatedBy", "UpdateDate", "UpdateMachine", "UpdateBy", "IsDelete", "DeletionDate", "DeletionMachine", "DeletionBy", "Created", "Update", "Deletion", "DailyReport" };
            foreach (var prop in props)
            {
                if (skipList.Contains(prop.Name)) continue;
                prop.SetValue(destination, prop.GetValue(source));
            }
        }

        public override void SaveData(int dailyReportId, SqlTransaction? transaction = null)
        {
            var helper = DC.GetHelper<Core.DailyReportPhoto>();
            var deletedIds = GetDeletedIds();
            if (deletedIds.Count > 0) helper.DeleteRange(deletedIds, transaction);
            ClearDeletedIds();

            var toAdd = new List<Core.DailyReportPhoto>();
            var toEdit = new List<Core.DailyReportPhoto>();
            foreach (var item in DataSource)
            {
                item.DailyReportId = dailyReportId;
                if (item.Id == 0)
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedMachine = Session.Machine;
                    item.CreatedBy = Session.CurrentUser?.Id ?? 0;
                    toAdd.Add(item);
                }
                else
                {
                    item.UpdateDate = DateTime.Now;
                    item.UpdateMachine = Session.Machine;
                    item.UpdateBy = Session.CurrentUser?.Id ?? 0;
                    toEdit.Add(item);
                }
            }
            if (toAdd.Count > 0) helper.AddRange(toAdd, transaction);
            if (toEdit.Count > 0) helper.EditRange(toEdit, transaction);
        }

        private readonly Dictionary<Core.DailyReportPhoto, Image> _imageCache = new Dictionary<Core.DailyReportPhoto, Image>();

        public ucDailyPhoto()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            this.Disposed += UcDailyPhoto_Disposed;
        }

        private void UcDailyPhoto_Disposed(object? sender, EventArgs e)
        {
            foreach (var img in _imageCache.Values)
            {
                img?.Dispose();
            }
            _imageCache.Clear();
        }

        public override void Initialize(int dailyReportId, int projectId, DateTime reportDate)
        {
            base.Initialize(dailyReportId, projectId, reportDate);
            
            if (!_isInitialized)
            {
                SetupGrid();
                SetupEvents();
                DesignSystem.ApplyCairoFont(this); // Ensure fonts are applied to dynamic items
                InitializeBaseGrid();
                _isInitialized = true;
            }
            
            LoadData();
        }

        private void SetupGrid()
        {
            tileView1.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Far;
            tileView1.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            tileView1.OptionsTiles.Padding = new Padding(20);
            tileView1.OptionsTiles.ItemPadding = new Padding(10);

            // Context Buttons
            var cbEdit = new DevExpress.Utils.ContextButton { Name = "cbEdit", Caption = "تعديل الوصف" };
            cbEdit.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Bottom;
            cbEdit.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            cbEdit.Visibility = DevExpress.Utils.ContextItemVisibility.Visible;
            tileView1.ContextButtons.Add(cbEdit);

            gridPhoto.AllowDrop = true;
        }

        private void SetupEvents()
        {
            tileView1.ContextButtonClick += (s, e) => {
                if (e.Item.Name == "cbEdit" && e.DataItem is Core.DailyReportPhoto row)
                {
                    string newDesc = XtraInputBox.Show("أدخل وصف الصورة الجديد:", "تعديل الوصف", row.Description);
                    if (newDesc != null)
                    {
                        row.Description = newDesc;
                        tileView1.RefreshRow(tileView1.FindRow(row));
                        OnDataChanged();
                    }
                }
            };

            tileView1.ItemCustomize += (s, e) => {
                if (tileView1.GetRow(e.RowHandle) is Core.DailyReportPhoto row && row.Photo?.Length > 0)
                {
                    if (_imageCache.TryGetValue(row, out Image cached))
                    {
                        e.Item.Image = cached;
                    }
                    else
                    {
                        try {
                            using var ms = new MemoryStream(row.Photo);
                            var img = new Bitmap(ms);
                            _imageCache[row] = img;
                            e.Item.Image = img;
                        } catch { e.Item.Image = null; }
                    }
                }
            };

            tileView1.ItemClick += (s, e) => {
                if (tileView1.GetFocusedRow() is Core.DailyReportPhoto row && row.Photo != null)
                {
                    using var frm = new XtraForm { Text = row.Description, StartPosition = FormStartPosition.CenterScreen, Size = new Size(1100, 900) };
                    var pe = new PictureEdit { Dock = DockStyle.Fill };
                    pe.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                    pe.EditValue = row.Photo;
                    frm.Controls.Add(pe);
                    frm.ShowDialog();
                }
            };

            gridPhoto.DragEnter += (s, e) => { if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy; };
            gridPhoto.DragDrop += (s, e) => {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                var images = files.Where(f => {
                    string ex = Path.GetExtension(f).ToLower();
                    return ex == ".jpg" || ex == ".jpeg" || ex == ".png" || ex == ".bmp";
                }).ToArray();
                if (images.Length > 0) AddFiles(images);
            };

            bbiAdd.ItemClick    += (s, e) => {
                using var open = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp", Multiselect = true };
                if (open.ShowDialog() == DialogResult.OK) AddFiles(open.FileNames);
            };
            
            bbiDelete.ItemClick += (s, e) => ConfirmAndDeleteFocusedRow();
            bbiCopy.ItemClick   += (s, e) => HandleToolbarCopy();
        }

        public override void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                foreach (var img in _imageCache.Values)
                {
                    img?.Dispose();
                }
                _imageCache.Clear();

                if (CurrentDailyReportId == 0) return;
                var list = DC.GetHelper<Core.DailyReportPhoto>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = CurrentDailyReportId });
                DataSource = new System.ComponentModel.BindingList<Core.DailyReportPhoto>(list);
                InitializeBaseGrid();
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void AddFiles(string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                try {
                    DataSource.Add(new Core.DailyReportPhoto {
                        DailyReportId = CurrentDailyReportId,
                        Photo = File.ReadAllBytes(fileName),
                        Description = Path.GetFileName(fileName)
                    });
                } catch (Exception ex) {
                    XtraMessageBox.Show($"خطأ في تحميل الصورة {fileName}: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            OnDataChanged();
            UpdateRecordCount();
        }

        protected bool CopyFilter(Core.DailyReportPhoto item) => true;
        protected Func<Core.DailyReportPhoto, Core.DailyReportPhoto, bool> GetDuplicatePredicate() => (a, b) => false; // Photos are unique by nature

        // ─── مؤشر الانتظار ──────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
