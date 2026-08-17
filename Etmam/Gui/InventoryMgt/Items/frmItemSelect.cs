using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmItemSelect : XtraForm
    {
        protected DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<ItemsList> SelectedItems { get; private set; } = new List<ItemsList>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<int> ExcludedIds { get; set; } = new List<int>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int? CategoryId { get; set; }

        public frmItemSelect()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

            gridView1.DoubleClick += (s, e) => ConfirmSelection();

            bbiSelect.ItemClick += (s, e) => ConfirmSelection();
            bbiRefresh.ItemClick += (s, e) => LoadData();
        }

        private void LoadData()
        {
            try
            {
                var categories = DC.ItemCategory.GetBy("IsDelete = 0").ToDictionary(c => c.Id);
                lookUpUnit.DataSource = DC.Units.GetBy("IsDelete = 0");

                var items = DC.ItemsList.GetBy("IsDelete = 0").ToList();

                if (CategoryId is > 0)
                    items = items.Where(i => i.CategoryId == CategoryId).ToList();

                if (ExcludedIds != null && ExcludedIds.Any())
                    items = items.Where(i => !ExcludedIds.Contains(i.Id)).ToList();

                foreach (var item in items)
                    item.CategoryCode = categories.TryGetValue(item.CategoryId ?? 0, out var cat) ? cat.Code : null;

                gridControl1.DataSource = new BindingList<ItemsList>(items);
                barStaticItem1.Caption = $"عدد السجلات : {items.Count}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الأصناف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfirmSelection()
        {
            SelectedItems.Clear();
            var selectedRows = gridView1.GetSelectedRows();
            foreach (var rowIndex in selectedRows)
            {
                if (gridView1.GetRow(rowIndex) is ItemsList item)
                    SelectedItems.Add(item);
            }

            if (SelectedItems.Count > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                XtraMessageBox.Show("يرجى اختيار صنف واحد على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
