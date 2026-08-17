using System.Drawing;
using System.Windows.Forms;

namespace Etmam
{
    partial class ucMIR
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMIR));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            roundedSkinPanel1 = new DevExpress.XtraEditors.RoundedSkinPanel();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarSubItem();
            bbiInspection = new DevExpress.XtraBars.BarButtonItem();
            bbiInspectionJob = new DevExpress.XtraBars.BarButtonItem();
            bbiInspectionEquipment = new DevExpress.XtraBars.BarButtonItem();
            bbiInspectionActivity = new DevExpress.XtraBars.BarButtonItem();
            bbiReIssue = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarSubItem();
            bbiEditInspection = new DevExpress.XtraBars.BarButtonItem();
            bbiEditActivity = new DevExpress.XtraBars.BarButtonItem();
            bbiEditJob = new DevExpress.XtraBars.BarButtonItem();
            bbiEditEquipment = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarSubItem();
            bbiDeleteInspection = new DevExpress.XtraBars.BarButtonItem();
            bbiDeleteEquipment = new DevExpress.XtraBars.BarButtonItem();
            bbiDeleteJob = new DevExpress.XtraBars.BarButtonItem();
            bbiDeleteActivity = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            bar2 = new DevExpress.XtraBars.Bar();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            roundedSkinPanel1.Dock = DockStyle.Fill;
            roundedSkinPanel1.Location = new Point(0, 48);
            roundedSkinPanel1.Name = "roundedSkinPanel1";
            roundedSkinPanel1.Size = new Size(1309, 601);
            roundedSkinPanel1.TabIndex = 4;
            roundedSkinPanel1.Text = "roundedSkinPanel1";
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(2, 2);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1305, 597);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowGroupPanel = false;
            
            roundedSkinPanel1.Controls.Add(gridControl1);
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar2, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = imageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiInspection, bbiReIssue, bbiEditInspection, bbiDeleteInspection, bbiRefresh, bbiPrint, barEditItem1, bbiNew, bbiInspectionJob, bbiInspectionEquipment, bbiInspectionActivity, bbiEdit, bbiEditActivity, bbiEditJob, bbiEditEquipment, bbiDelete, bbiDeleteEquipment, bbiDeleteJob, bbiDeleteActivity, barButtonItem1 });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 23;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemSearchControl1 });
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 1;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiReIssue, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barEditItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiNew
            // 
            bbiNew.Caption = "جديد";
            bbiNew.Id = 10;
            bbiNew.ImageOptions.ImageIndex = 0;
            bbiNew.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbiInspection), new DevExpress.XtraBars.LinkPersistInfo(bbiInspectionJob), new DevExpress.XtraBars.LinkPersistInfo(bbiInspectionEquipment), new DevExpress.XtraBars.LinkPersistInfo(bbiInspectionActivity) });
            bbiNew.Name = "bbiNew";
            // 
            // bbiInspection
            // 
            bbiInspection.Caption = "تقرير يومي جديد";
            bbiInspection.Id = 0;
            bbiInspection.ImageOptions.ImageIndex = 0;
            bbiInspection.Name = "bbiInspection";
            bbiInspection.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiInspectionJob
            // 
            bbiInspectionJob.Caption = "إضافة وظيفة";
            bbiInspectionJob.Id = 11;
            bbiInspectionJob.ImageOptions.ImageIndex = 0;
            bbiInspectionJob.Name = "bbiInspectionJob";
            // 
            // bbiInspectionEquipment
            // 
            bbiInspectionEquipment.Caption = "إضافة معدات/اليات";
            bbiInspectionEquipment.Id = 12;
            bbiInspectionEquipment.ImageOptions.ImageIndex = 0;
            bbiInspectionEquipment.Name = "bbiInspectionEquipment";
            // 
            // bbiInspectionActivity
            // 
            bbiInspectionActivity.Caption = "إضافة نشاط";
            bbiInspectionActivity.Id = 13;
            bbiInspectionActivity.ImageOptions.ImageIndex = 0;
            bbiInspectionActivity.Name = "bbiInspectionActivity";
            // 
            // bbiReIssue
            // 
            bbiReIssue.Caption = "إعادة إصدار تقرير يومي";
            bbiReIssue.Id = 1;
            bbiReIssue.ImageOptions.ImageIndex = 1;
            bbiReIssue.Name = "bbiReIssue";
            bbiReIssue.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 14;
            bbiEdit.ImageOptions.ImageIndex = 7;
            bbiEdit.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEditInspection, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(bbiEditActivity), new DevExpress.XtraBars.LinkPersistInfo(bbiEditJob), new DevExpress.XtraBars.LinkPersistInfo(bbiEditEquipment) });
            bbiEdit.Name = "bbiEdit";
            // 
            // bbiEditInspection
            // 
            bbiEditInspection.Caption = "تعديل تقرير يومي";
            bbiEditInspection.Id = 2;
            bbiEditInspection.ImageOptions.ImageIndex = 7;
            bbiEditInspection.Name = "bbiEditInspection";
            bbiEditInspection.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // bbiEditActivity
            // 
            bbiEditActivity.Caption = "تعديل وظيفة";
            bbiEditActivity.Id = 15;
            bbiEditActivity.ImageOptions.ImageIndex = 7;
            bbiEditActivity.Name = "bbiEditActivity";
            // 
            // bbiEditJob
            // 
            bbiEditJob.Caption = "تعديل معدات/اليات";
            bbiEditJob.Id = 16;
            bbiEditJob.ImageOptions.ImageIndex = 7;
            bbiEditJob.Name = "bbiEditJob";
            // 
            // bbiEditEquipment
            // 
            bbiEditEquipment.Caption = "تعديل نشاط";
            bbiEditEquipment.Id = 17;
            bbiEditEquipment.ImageOptions.ImageIndex = 7;
            bbiEditEquipment.Name = "bbiEditEquipment";
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 18;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDeleteInspection, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(bbiDeleteEquipment), new DevExpress.XtraBars.LinkPersistInfo(bbiDeleteJob), new DevExpress.XtraBars.LinkPersistInfo(bbiDeleteActivity) });
            bbiDelete.Name = "bbiDelete";
            // 
            // bbiDeleteInspection
            // 
            bbiDeleteInspection.Caption = "حذف تقرير يومي";
            bbiDeleteInspection.Id = 3;
            bbiDeleteInspection.ImageOptions.ImageIndex = 3;
            bbiDeleteInspection.Name = "bbiDeleteInspection";
            bbiDeleteInspection.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // bbiDeleteEquipment
            // 
            bbiDeleteEquipment.Caption = "حذف معدات/اليات";
            bbiDeleteEquipment.Id = 19;
            bbiDeleteEquipment.ImageOptions.ImageIndex = 3;
            bbiDeleteEquipment.Name = "bbiDeleteEquipment";
            // 
            // bbiDeleteJob
            // 
            bbiDeleteJob.Caption = "حذف وظيفة";
            bbiDeleteJob.Id = 20;
            bbiDeleteJob.ImageOptions.ImageIndex = 3;
            bbiDeleteJob.Name = "bbiDeleteJob";
            // 
            // bbiDeleteActivity
            // 
            bbiDeleteActivity.Caption = "حذف نشاط";
            bbiDeleteActivity.Id = 21;
            bbiDeleteActivity.ImageOptions.ImageIndex = 3;
            bbiDeleteActivity.Name = "bbiDeleteActivity";
            // 
            // bbiRefresh
            // 
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 4;
            bbiRefresh.ImageOptions.ImageIndex = 6;
            bbiRefresh.Name = "bbiRefresh";
            bbiRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // bbiPrint
            // 
            bbiPrint.Caption = "طباعة تقرير يومي";
            bbiPrint.Id = 5;
            bbiPrint.ImageOptions.ImageIndex = 4;
            bbiPrint.Name = "bbiPrint";
            bbiPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "بحث";
            barEditItem1.Edit = repositoryItemSearchControl1;
            barEditItem1.EditHeight = 25;
            barEditItem1.EditWidth = 250;
            barEditItem1.Id = 6;
            barEditItem1.Name = "barEditItem1";
            barEditItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemSearchControl1
            // 
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            bar2.Visible = false;
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1309, 48);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 649);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1309, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 48);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 601);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1309, 48);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 601);
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "1_New.png");
            imageCollection1.Images.SetKeyName(1, "2_ReIssue.png");
            imageCollection1.Images.SetKeyName(2, "3_Save.png");
            imageCollection1.Images.SetKeyName(3, "4_Delete.png");
            imageCollection1.Images.SetKeyName(4, "5_Print.png");
            imageCollection1.Images.SetKeyName(5, "6_Search.png");
            imageCollection1.Images.SetKeyName(6, "refresh.png");
            imageCollection1.InsertImage(Properties.Resources.edit_16x16, "edit_16x16", typeof(Properties.Resources), 7);
            imageCollection1.Images.SetKeyName(7, "edit_16x16");
            imageCollection1.Images.SetKeyName(8, "6_Search.png");
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "بحث عن تقرير يومي";
            barButtonItem1.Id = 22;
            barButtonItem1.ImageOptions.ImageIndex = 8;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // ucMIR
            // 
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundedSkinPanel1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new Font("Cairo", 8.5F);
            Name = "ucMIR";
            Size = new Size(1309, 667);
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).EndInit();
            roundedSkinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DevExpress.XtraEditors.RoundedSkinPanel roundedSkinPanel1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiInspection;
        private DevExpress.XtraBars.BarButtonItem bbiReIssue;
        private DevExpress.XtraBars.BarButtonItem bbiEditInspection;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteInspection;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarSubItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiInspectionJob;
        private DevExpress.XtraBars.BarButtonItem bbiInspectionEquipment;
        private DevExpress.XtraBars.BarButtonItem bbiInspectionActivity;
        private DevExpress.XtraBars.BarSubItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiEditActivity;
        private DevExpress.XtraBars.BarButtonItem bbiEditJob;
        private DevExpress.XtraBars.BarButtonItem bbiEditEquipment;
        private DevExpress.XtraBars.BarSubItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteEquipment;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteJob;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteActivity;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}

