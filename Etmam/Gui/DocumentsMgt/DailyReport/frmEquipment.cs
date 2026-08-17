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
    public partial class frmEquipment : XtraForm
    {
        // ─── Shared Services ──────────────────────────────────────────────────
        protected Data.DataContext DC => Data.DataContext.Shared;

        // ─── Data State ───────────────────────────────────────────────────────
        protected BindingList<EquipmentList> DataSource { get; set; } = new BindingList<EquipmentList>();
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool IsSelectionMode { get; set; } = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<EquipmentList> SelectedItems { get; private set; } = new List<EquipmentList>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<int> ExcludedIds { get; set; } = new List<int>();

        public frmEquipment()
        {
            InitializeComponent();
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
            gridView1.OptionsView.ColumnAutoWidth = true;

            if (IsSelectionMode)
            {
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
                bbiSelect.Visibility = BarItemVisibility.Always;
            }

            gridControl1.DataSource = DataSource;
            gridView1.DoubleClick += (s, e) => { if (!IsSelectionMode) OnEdit(); };

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
                var helper = DC.GetHelper<EquipmentList>();
                var data = await System.Threading.Tasks.Task.Run(() => 
                    helper.GetBy("IsDelete = 0")
                );

                // Apply ExcludedIds filter
                if (ExcludedIds != null && ExcludedIds.Any())
                {
                    data = data.Where(x => !ExcludedIds.Contains(x.Id)).ToList();
                }

                DataSource.Clear();
                foreach (var item in data)
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

        protected void OnAdd()
        {
            using (var frm = new frmEquipmentAddEdit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        protected void OnEdit()
        {
            if (gridView1.GetFocusedRow() is EquipmentList row)
            {
                using (var frm = new frmEquipmentAddEdit(row))
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
            if (gridView1.GetFocusedRow() is EquipmentList row)
            {
                if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        var helper = DC.GetHelper<EquipmentList>();
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
                if (gridView1.GetRow(rowIndex) is EquipmentList item)
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