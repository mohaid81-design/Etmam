using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmWorkDoneSelection : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<ActivityList> SelectedItems { get; private set; } = new List<ActivityList>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string FilterCategory { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<int> ExcludedIds { get; set; } = new List<int>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int ProjectId { get; set; }

        public frmWorkDoneSelection(int prjId = 0)
        {
            InitializeComponent();
            DesignSystem.ApplyFormBranding(this);
            ProjectId = prjId;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupGridView();
            LoadData();
        }

        private void SetupGridView()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            
            // Cairo font and centered headers
            var headerFont = new Font("Cairo", 8.5F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.Font = headerFont;
            gridView1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.Row.Font = new Font("Cairo", 8.5F);
            gridView1.Appearance.Row.Options.UseFont = true;
            
            gridView1.DoubleClick += (s, e) => ConfirmSelection();

            // Setup columns (we'll see what we get from data)
        }

        private void LoadData()
        {
            try
            {
                // Logic: Find Activities that were previously reported as < 100% Qty.
                // Or activities that were never reported.
                // For now, let's show all activities in the category, but we'll try to find the "Incomplete" ones.
                
                var actHelper = DC.ActivityList;
                var activities = actHelper.GetBy("IsDelete = 0", null);

                if (!string.IsNullOrEmpty(FilterCategory))
                {
                    activities = activities.Where(a => a.Category == FilterCategory).ToList();
                }

                if (ExcludedIds != null && ExcludedIds.Any())
                {
                    activities = activities.Where(a => !ExcludedIds.Contains(a.Id)).ToList();
                }

                // Filter for "Incomplete" Work Done
                // We'll fetch all Work Done records for reports in this project and find those with Qty < 100.
                var doneHelper = DC.DailyReportWorkDone;
                string filter = "IsDelete = 0";
                object param = null;
                
                if (ProjectId > 0)
                {
                    filter = "IsDelete = 0 AND DailyReportId IN (SELECT Id FROM DailyReport WHERE PrjId = @pId AND IsDelete = 0)";
                    param = new { pId = ProjectId };
                }

                var allWorkDone = doneHelper.GetBy(filter, param);

                // Find the latest Qty per ActivityId
                var latestQtys = allWorkDone
                    .GroupBy(d => d.ActivityId)
                    .Where(g => g.Key.HasValue)
                    .ToDictionary(g => g.Key.Value, g => g.OrderByDescending(d => d.Id).First().Qty);

                // Filter activities: 
                // Either never reported, or latest reported Qty < 100.
                var data = activities.Where(a => {
                    if (latestQtys.TryGetValue(a.Id, out decimal? qty))
                        return qty < 100;
                    return true; // Never reported = incomplete
                }).ToList();

                gridControl1.DataSource = new BindingList<ActivityList>(data);
                
                // Set Column Captions
                if (gridView1.Columns["Item"] != null) gridView1.Columns["Item"].Caption = "البند / النشاط";
                if (gridView1.Columns["Location"] != null) gridView1.Columns["Location"].Caption = "الموقع";
                if (gridView1.Columns["Description"] != null) gridView1.Columns["Description"].Caption = "وصف الأعمال";
                if (gridView1.Columns["Category"] != null) gridView1.Columns["Category"].Caption = "التصنيف";

                // Hide system columns
                string[] hiddenCols = { "Id", "CreatedDate", "CreatedMachine", "CreatedBy", "Created",
                                        "UpdateDate", "UpdateMachine", "UpdateBy", "Update",
                                        "IsDelete", "DeletionDate", "DeletionMachine", "DeletionBy", "Deletion",
                                        "DailyReportId", "DailyReport", "ActivityId" };
                foreach (var col in hiddenCols)
                    if (gridView1.Columns[col] != null) gridView1.Columns[col].Visible = false;

                barStaticItem1.Caption = $"عدد السجلات : {data.Count}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfirmSelection()
        {
            var selectedRows = gridView1.GetSelectedRows();
            SelectedItems.Clear();
            foreach (var rowIndex in selectedRows)
            {
                if (gridView1.GetRow(rowIndex) is ActivityList item)
                    SelectedItems.Add(item);
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

        private void BbiSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConfirmSelection();
        }

        private void BbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var dlg = new frmActivityAddEdit())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
    }
}
