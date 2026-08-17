using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmManpower : XtraForm
    {
        // ─── Shared Services ──────────────────────────────────────────────────
        protected Data.DataContext DC => Data.DataContext.Shared;

        // ─── Data State ───────────────────────────────────────────────────────
        protected BindingList<ManpowerList> DataSource { get; set; } = new BindingList<ManpowerList>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string? FilterCategory { get; set; }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool IsSelectionMode { get; set; } = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<ManpowerList> SelectedItems { get; private set; } = new List<ManpowerList>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<int> ExcludedIds { get; set; } = new List<int>();

        public frmManpower()
        {
            InitializeComponent();
        }

        public frmManpower(string filterCategory) : this()
        {
            FilterCategory = filterCategory;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeBaseGrid();
            LoadData();
        }

        protected DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle ShowOverlay()
        {
            return DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(this);
        }

        protected void CloseOverlay(DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(handle);
        }

        protected void InitializeBaseGrid()
        {
            DesignSystem.ApplyProfessionalStyle(gridView1);
            DesignSystem.HideAuditColumns(gridView1);
            
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

            if (IsSelectionMode)
            {
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                if (bbiSelect != null) bbiSelect.Visibility = BarItemVisibility.Always;
            }

            gridControl1.DataSource = DataSource;
            gridView1.DoubleClick += (s, e) => { if (!IsSelectionMode) OnEdit(); };

            // Custom Column Captions
            if (gridView1.Columns["Name"] != null) gridView1.Columns["Name"].Caption = "المهنة"; 
            if (gridView1.Columns["Category"] != null) gridView1.Columns["Category"].Caption = "التصنيف";

            gridView1.OptionsView.ColumnAutoWidth = true;

            // Event Hooks for specific toolbar buttons defined in Designer
            bbiAdd.ItemClick += (s, e) => OnAdd();
            bbiEdit.ItemClick += (s, e) => OnEdit();
            bbiDelete.ItemClick += (s, e) => ConfirmAndDeleteFocusedRow();
            bbiSelect.ItemClick += (s, e) => HandleSelection();
        }

        public void UpdateRecordCount()
        {
            if (barStaticItem1 != null)
                barStaticItem1.Caption = $"عدد السجلات : {DataSource.Count}";
        }

        public async void LoadData()
        {
            var overlay = ShowOverlay();
            try
            {
                var helper = DC.GetHelper<ManpowerList>();
                var data = await System.Threading.Tasks.Task.Run(() => 
                    helper.GetBy("IsDelete = 0")
                );

                // Apply ExcludedIds filter
                if (ExcludedIds != null && ExcludedIds.Any())
                {
                    data = data.Where(x => !ExcludedIds.Contains(x.Id)).ToList();
                }

                DataSource.Clear();
                foreach (var item in ApplyDataFilters(data))
                {
                    DataSource.Add(item);
                }
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(overlay);
            }
        }

        protected IEnumerable<ManpowerList> ApplyDataFilters(IEnumerable<ManpowerList> data)
        {
            if (!string.IsNullOrEmpty(FilterCategory))
            {
                data = data.Where(m => m.Category == FilterCategory);
            }

            if (ExcludedIds != null && ExcludedIds.Any())
            {
                data = data.Where(m => !ExcludedIds.Contains(m.Id));
            }

            return data;
        }

        protected void OnAdd()
        {
            using (var frm = new frmManpowerAddEdit(FilterCategory))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        protected void OnEdit()
        {
            if (gridView1.GetFocusedRow() is ManpowerList row)
            {
                using (var frm = new frmManpowerAddEdit(row))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        public void ConfirmAndDeleteFocusedRow()
        {
            if (gridView1.GetFocusedRow() is ManpowerList row)
            {
                if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        var helper = DC.GetHelper<ManpowerList>();
                        row.IsDelete = true;
                        row.DeletionBy = Session.CurrentUser?.Id ?? 1;
                        row.DeletionDate = DateTime.Now;
                        row.DeletionMachine = Environment.MachineName;

                        helper.Edit(row.Id, row);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ في الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void HandleSelection()
        {
            if (!IsSelectionMode) return;

            var selectedRows = gridView1.GetSelectedRows();
            SelectedItems.Clear();
            foreach (var rowIndex in selectedRows)
            {
                if (gridView1.GetRow(rowIndex) is ManpowerList item)
                {
                    SelectedItems.Add(item);
                }
            }

            if (SelectedItems.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("يرجى اختيار سجل واحد على الأقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
