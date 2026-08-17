using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Core;
using DevExpress.XtraTreeList;
using Data;

namespace Etmam
{
    public partial class ucSchedule : Etmam.BaseScheduleTreeControl
    {
        public event EventHandler OnLinkCreated;

        protected override TreeList MainTree => treeList1;
        protected override DevExpress.XtraBars.BarStaticItem? StatusItem => barStaticItem1;

        public ucSchedule()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            
            treeList1.AllowDrop = true;
            treeList1.DragOver += treeList1_DragOver;
            treeList1.DragDrop += treeList1_DragDrop;

            InitializeBaseTree();
            DesignSystem.ApplyTreeListStyle(treeList1);
            DesignSystem.HideTreeListAuditColumns(treeList1);
            
            treeList1.NodeCellStyle += TreeList1_NodeCellStyle;

            // Wire toolbar buttons
            bbiAdd.ItemClick += BbiAdd_ItemClick;
            bbiAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            
            treeList1.KeyDown += StandardTreeList_KeyDown;
        }

        public override void Initialize(int dailyReportId, int projectId, DateTime reportDate)
        {
            base.Initialize(dailyReportId, projectId, reportDate);
            LoadData(projectId);
        }

        private void TreeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            var item = treeList1.GetRow(e.Node.Id) as ScheduleDetails;
            if (item == null) return;

            if (item.IdCategory == "wbs")
            {
                e.Appearance.Font = DesignSystem.Fonts.Bold(9f);
                e.Appearance.BackColor = Color.FromArgb(235, 245, 255); // Keep light blue for WBS
                e.Appearance.ForeColor = DesignSystem.Colors.Primary;
            }
            else
            {
                e.Appearance.Font = DesignSystem.Fonts.Regular(8.5f);
                e.Appearance.ForeColor = DesignSystem.Colors.TextPrimary;
            }
        }

        private void BbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int prjId = CurrentProjectId > 0 ? CurrentProjectId : (Session.SelectedProjectId ?? 1);
            
            using (var frm = new frmImportSchedule(prjId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(CurrentProjectId);
                }
            }
        }

        public void LoadData(int projectId = 0)
        {
            if (projectId == 0) projectId = CurrentProjectId;
            
            DataSource.Clear();
            List<ScheduleDetails> data;
            
            if (projectId > 0)
                data = DC.ScheduleDetails.GetBy("PrjId = @projectId", new { projectId });
            else
                data = DC.ScheduleDetails.GetAll();

            foreach (var item in data) DataSource.Add(item);

            treeList1.ExpandAll();
            treeList1.BestFitColumns();
            UpdateRecordCount();
        }

        public override void OnProjectChanged()
        {
            base.OnProjectChanged();
            if (CurrentProjectId > 0) return; // If loaded inside a specific daily report context, do not change
            LoadData(Core.Session.SelectedProjectId ?? 1);
        }

        private void treeList1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ActivityList)))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            if (!(sender is TreeList tree)) return;
            
            Point p = tree.PointToClient(new Point(e.X, e.Y));
            TreeListHitInfo hitInfo = tree.CalcHitInfo(p);

            if (hitInfo.Node != null)
            {
                var activity = e.Data.GetData(typeof(ActivityList)) as ActivityList;
                var scheduleItem = tree.GetRow(hitInfo.Node.Id) as ScheduleDetails;

                if (activity != null && scheduleItem != null)
                {
                    activity.ScheduleActivityId = scheduleItem.Id;
                    DC.ActivityList.Edit(activity.Id, activity);
                    
                    OnLinkCreated?.Invoke(this, EventArgs.Empty);
                    
                    XtraMessageBox.Show("تم ربط النشاط بالجدول الزمني بنجاح", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    /// <summary>
    /// Intermediate non-generic base class to support Visual Studio Designer.
    /// </summary>
    [System.ComponentModel.ToolboxItem(false)]
    public class BaseScheduleTreeControl : BaseTreeListUserControl<ScheduleDetails> 
    {
        protected override DevExpress.XtraTreeList.TreeList MainTree => null;
    }
}
