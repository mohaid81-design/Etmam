using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmActivitySelect : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool IsSelectionMode { get; set; } = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<int> ExcludedIds { get; set; } = new List<int>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<ActivityList> SelectedItems { get; private set; } = new List<ActivityList>();

        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilterCategory { get; set; }

        private class ActivityProgressViewModel
        {
            public ActivityList Activity { get; set; }
            public decimal TotalQty { get; set; }
            public int Id => Activity?.Id ?? 0;
            public string Item => Activity?.Item;
            public string Description => Activity?.Description;
            public string Location => Activity?.Location;
            public string Category => Activity?.Category;
        }

        public frmActivitySelect()
        {
            InitializeComponent();
            DesignSystem.ApplyFormBranding(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupGrid();
        }

        private void LoadData()
        {
            try
            {
                var workDoneList = DC.DailyReportWorkDone
                    .GetBy("IsDelete = 0", null)
                    .Where(w => !w.IsDelete)
                    .GroupBy(w => w.ActivityId)
                    .Select(g => new { ActivityId = g.Key, TotalQty = g.Sum(x => x.Qty ?? 0) })
                    .ToList();

                // 2. Fetch all Activities
                var activities = DC.ActivityList
                    .GetAll()
                    .Where(a => !a.IsDelete)
                    .ToList();

                // 3. Join and Filter (only show those with cumulative < 100)
                var data = (from a in activities
                            join w in workDoneList on a.Id equals w.ActivityId into workItems
                            from wi in workItems.DefaultIfEmpty()
                            let total = wi?.TotalQty ?? 0
                            where total < 100
                            select new ActivityProgressViewModel
                            {
                                Activity = a,
                                TotalQty = total
                            }).ToList();

                if (ExcludedIds != null && ExcludedIds.Any())
                    data = data.Where(p => !ExcludedIds.Contains(p.Id)).ToList();
                
                if (!string.IsNullOrEmpty(FilterCategory))
                    data = data.Where(p => p.Category == FilterCategory).ToList();

                gridControl1.DataSource = new BindingList<ActivityProgressViewModel>(data);
                gridView1.ExpandAllGroups();
                barStaticItem1.Caption = $"عدد السجلات : {gridView1.RowCount}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGrid()
        {
            // --- Basic Grid Options ---
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            
            // Event to prevent group row background from changing when its children are selected
            gridView1.RowStyle += (s, e) =>
            {
                if (e.RowHandle < 0) // Group rows have negative row handles
                {
                    e.HighPriority = true; // This forces the style even if the row is selected
                }
            };

            //// --- Typography & Appearance ---
            Font cairo85Bold = new Font("Cairo", 8.25F, FontStyle.Bold);
            Font cairo85Reg = new Font("Cairo", 8.25F, FontStyle.Regular);

            gridView1.Appearance.HeaderPanel.Font = cairo85Bold;
            gridView1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            gridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(230, 240, 250);
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridView1.Appearance.Row.Font = cairo85Reg;
            gridView1.Appearance.Row.Options.UseFont = true;

            gridView1.Appearance.FocusedRow.BackColor = SystemColors.Info;
            gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView1.Appearance.FocusedRow.Options.UseForeColor = true;

            gridView1.Appearance.HideSelectionRow.BackColor = SystemColors.Info;
            gridView1.Appearance.HideSelectionRow.ForeColor = Color.Black;
            gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;

            gridView1.Appearance.GroupRow.Font = new Font("Cairo", 9F, FontStyle.Bold);
            gridView1.Appearance.GroupRow.ForeColor = Color.FromArgb(30, 70, 130);
            gridView1.Appearance.GroupRow.Options.UseFont = true;
            gridView1.Appearance.GroupRow.Options.UseForeColor = true;

            gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(245, 248, 253);
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;

            // Toolbar items font
            foreach (DevExpress.XtraBars.BarItem item in barManager1.Items)
            {
                item.Appearance.Font = cairo85Bold;
                item.Appearance.Options.UseFont = true;
            }

            barStaticItem1.Appearance.Font = new Font("Cairo", 8F);
            barStaticItem1.Appearance.Options.UseFont = true;

            // --- Load Data ---
            LoadData();

            // --- Toolbar Configuration ---
            bbiAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;

            if (IsSelectionMode)
            {
                bbiAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                bbiEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                bbiEdit.Caption = "اختيار";
                
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
                gridView1.DoubleClick += (s, e) => ConfirmSelection();
            }
            else
            {
                bbiAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                bbiEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                bbiEdit.Caption = "تعديل";
                gridView1.DoubleClick += (s, e) => BbiEdit_ItemClick(null, null);
            }

            // Wire toolbar buttons
            bbiAdd.ItemClick    += BbiAdd_ItemClick;
            bbiEdit.ItemClick   += BbiEdit_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void ConfirmSelection()
        {
            SelectedItems.Clear();
            var selectedRows = gridView1.GetSelectedRows();
            foreach (var rowIndex in selectedRows)
            {
                if (gridView1.GetRow(rowIndex) is ActivityProgressViewModel vm && vm.Activity != null)
                    SelectedItems.Add(vm.Activity);
            }

            if (SelectedItems.Count > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                XtraMessageBox.Show("يرجى اختيار نشاط واحد على الأقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ── Toolbar handlers ─────────────────────────────────────────────

        private void BbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var dlg = new frmActivityAddEdit(FilterCategory))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsSelectionMode)
            {
                ConfirmSelection();
                return;
            }

            if (gridView1.GetFocusedRow() is ActivityProgressViewModel vm && vm.Activity != null)
            {
                using (var dlg = new frmActivityAddEdit(vm.Activity))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                        LoadData();
                }
            }
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vm = gridView1.GetFocusedRow() as ActivityProgressViewModel;
            if (vm == null || vm.Activity == null) return;
            var row = vm.Activity;
 
            if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا النشاط؟", "تأكيد الحذف",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    row.IsDelete        = true;
                    row.DeletionBy      = Session.CurrentUser?.Id ?? 0;
                    row.DeletionDate    = DateTime.Now;
                    row.DeletionMachine = Environment.MachineName;
                    DC.ActivityList.Edit(row.Id, row);
                    LoadData();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ في الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}