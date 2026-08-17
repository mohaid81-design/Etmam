using System.Drawing;
using System.Windows.Forms;

namespace Etmam
{
    partial class ucDailyReports
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDailyReports));
            roundedSkinPanel1 = new DevExpress.XtraEditors.RoundedSkinPanel();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colReportNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colReportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colWeather = new DevExpress.XtraGrid.Columns.GridColumn();
            colTemperature = new DevExpress.XtraGrid.Columns.GridColumn();
            colShift = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletion = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrjId = new DevExpress.XtraGrid.Columns.GridColumn();
            colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiSearch = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            bar2 = new DevExpress.XtraBars.Bar();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            bbiReIssue = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).BeginInit();
            roundedSkinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            // 
            // roundedSkinPanel1
            // 
            roundedSkinPanel1.Controls.Add(gridControl1);
            roundedSkinPanel1.Dock = DockStyle.Fill;
            roundedSkinPanel1.Location = new Point(0, 48);
            roundedSkinPanel1.Margin = new Padding(3, 2, 3, 2);
            roundedSkinPanel1.Name = "roundedSkinPanel1";
            roundedSkinPanel1.Size = new Size(1122, 368);
            roundedSkinPanel1.TabIndex = 4;
            roundedSkinPanel1.Text = "roundedSkinPanel1";
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.EmbeddedNavigator.Margin = new Padding(3, 2, 3, 2);
            gridControl1.Location = new Point(0, 0);
            gridControl1.MainView = gridView1;
            gridControl1.Margin = new Padding(3, 2, 3, 2);
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1122, 368);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new Font("Cairo", 8.5F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colReportNumber, colReportDate, colWeather, colTemperature, colShift, colStatus, colCreatedDate, colCreatedMachine, colUpdateDate, colUpdateMachine, colIsDelete, colDeletionDate, colDeletionMachine, colCreatedBy, colCreated, colUpdateBy, colUpdate, colDeletionBy, colDeletion, colPrjId, colProject });
            gridView1.DetailHeight = 227;
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsEditForm.PopupEditFormWidth = 686;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.MinWidth = 17;
            colId.Name = "colId";
            colId.Width = 64;
            // 
            // colReportNumber
            // 
            colReportNumber.AppearanceCell.Options.UseTextOptions = true;
            colReportNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colReportNumber.Caption = "رقم التقرير";
            colReportNumber.FieldName = "ReportNumber";
            colReportNumber.MinWidth = 17;
            colReportNumber.Name = "colReportNumber";
            colReportNumber.OptionsColumn.AllowEdit = false;
            colReportNumber.Visible = true;
            colReportNumber.VisibleIndex = 0;
            colReportNumber.Width = 129;
            // 
            // colReportDate
            // 
            colReportDate.AppearanceCell.Options.UseTextOptions = true;
            colReportDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colReportDate.Caption = "تاريخ التقرير";
            colReportDate.FieldName = "ReportDate";
            colReportDate.MinWidth = 17;
            colReportDate.Name = "colReportDate";
            colReportDate.OptionsColumn.AllowEdit = false;
            colReportDate.Visible = true;
            colReportDate.VisibleIndex = 1;
            colReportDate.Width = 129;
            // 
            // colWeather
            // 
            colWeather.AppearanceCell.Options.UseTextOptions = true;
            colWeather.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colWeather.Caption = "حالة الطقس";
            colWeather.FieldName = "Weather";
            colWeather.MinWidth = 17;
            colWeather.Name = "colWeather";
            colWeather.OptionsColumn.AllowEdit = false;
            colWeather.Visible = true;
            colWeather.VisibleIndex = 2;
            colWeather.Width = 103;
            // 
            // colTemperature
            // 
            colTemperature.AppearanceCell.Options.UseTextOptions = true;
            colTemperature.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colTemperature.Caption = "درجة الحرارة";
            colTemperature.FieldName = "Temperature";
            colTemperature.MinWidth = 17;
            colTemperature.Name = "colTemperature";
            colTemperature.OptionsColumn.AllowEdit = false;
            colTemperature.Visible = true;
            colTemperature.VisibleIndex = 3;
            colTemperature.Width = 86;
            // 
            // colShift
            // 
            colShift.AppearanceCell.Options.UseTextOptions = true;
            colShift.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colShift.Caption = "المناوبة";
            colShift.FieldName = "Shift";
            colShift.MinWidth = 17;
            colShift.Name = "colShift";
            colShift.OptionsColumn.AllowEdit = false;
            colShift.Visible = true;
            colShift.VisibleIndex = 4;
            colShift.Width = 86;
            // 
            // colStatus
            // 
            colStatus.FieldName = "Status";
            colStatus.MinWidth = 17;
            colStatus.Name = "colStatus";
            colStatus.Width = 64;
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.MinWidth = 17;
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.Width = 64;
            // 
            // colCreatedMachine
            // 
            colCreatedMachine.FieldName = "CreatedMachine";
            colCreatedMachine.MinWidth = 17;
            colCreatedMachine.Name = "colCreatedMachine";
            colCreatedMachine.Width = 64;
            // 
            // colUpdateDate
            // 
            colUpdateDate.FieldName = "UpdateDate";
            colUpdateDate.MinWidth = 17;
            colUpdateDate.Name = "colUpdateDate";
            colUpdateDate.Width = 64;
            // 
            // colUpdateMachine
            // 
            colUpdateMachine.FieldName = "UpdateMachine";
            colUpdateMachine.MinWidth = 17;
            colUpdateMachine.Name = "colUpdateMachine";
            colUpdateMachine.Width = 64;
            // 
            // colIsDelete
            // 
            colIsDelete.FieldName = "IsDelete";
            colIsDelete.MinWidth = 17;
            colIsDelete.Name = "colIsDelete";
            colIsDelete.Width = 64;
            // 
            // colDeletionDate
            // 
            colDeletionDate.FieldName = "DeletionDate";
            colDeletionDate.MinWidth = 17;
            colDeletionDate.Name = "colDeletionDate";
            colDeletionDate.Width = 64;
            // 
            // colDeletionMachine
            // 
            colDeletionMachine.FieldName = "DeletionMachine";
            colDeletionMachine.MinWidth = 17;
            colDeletionMachine.Name = "colDeletionMachine";
            colDeletionMachine.Width = 64;
            // 
            // colCreatedBy
            // 
            colCreatedBy.FieldName = "CreatedBy";
            colCreatedBy.MinWidth = 17;
            colCreatedBy.Name = "colCreatedBy";
            colCreatedBy.Width = 64;
            // 
            // colCreated
            // 
            colCreated.FieldName = "Created";
            colCreated.MinWidth = 17;
            colCreated.Name = "colCreated";
            colCreated.Width = 64;
            // 
            // colUpdateBy
            // 
            colUpdateBy.FieldName = "UpdateBy";
            colUpdateBy.MinWidth = 17;
            colUpdateBy.Name = "colUpdateBy";
            colUpdateBy.Width = 64;
            // 
            // colUpdate
            // 
            colUpdate.FieldName = "Update";
            colUpdate.MinWidth = 17;
            colUpdate.Name = "colUpdate";
            colUpdate.Width = 64;
            // 
            // colDeletionBy
            // 
            colDeletionBy.FieldName = "DeletionBy";
            colDeletionBy.MinWidth = 17;
            colDeletionBy.Name = "colDeletionBy";
            colDeletionBy.Width = 64;
            // 
            // colDeletion
            // 
            colDeletion.FieldName = "Deletion";
            colDeletion.MinWidth = 17;
            colDeletion.Name = "colDeletion";
            colDeletion.Width = 64;
            // 
            // colPrjId
            // 
            colPrjId.FieldName = "PrjId";
            colPrjId.MinWidth = 17;
            colPrjId.Name = "colPrjId";
            colPrjId.Width = 64;
            // 
            // colProject
            // 
            colProject.FieldName = "Project";
            colProject.MinWidth = 17;
            colProject.Name = "colProject";
            colProject.Width = 64;
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiReIssue, bbiEdit, bbiDelete, bbiRefresh, bbiPrint, barEditItem1, bbiSearch });
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
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(bbiEdit), new DevExpress.XtraBars.LinkPersistInfo(bbiDelete), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSearch, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barEditItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiNew
            // 
            bbiNew.Caption = "جديد";
            bbiNew.Id = 0;
            bbiNew.ImageOptions.ImageIndex = 0;
            bbiNew.Name = "bbiNew";
            bbiNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiNew.ItemClick += bbiNew_ItemClick;
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 2;
            bbiEdit.ImageOptions.ImageIndex = 7;
            bbiEdit.Name = "bbiEdit";
            bbiEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 3;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.Name = "bbiDelete";
            bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            // 
            // bbiRefresh
            // 
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 4;
            bbiRefresh.ImageOptions.ImageIndex = 6;
            bbiRefresh.Name = "bbiRefresh";
            bbiRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            // 
            // bbiPrint
            // 
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 5;
            bbiPrint.ImageOptions.ImageIndex = 4;
            bbiPrint.Name = "bbiPrint";
            bbiPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            // 
            // bbiSearch
            // 
            bbiSearch.Caption = "بحث";
            bbiSearch.Id = 22;
            bbiSearch.ImageOptions.ImageIndex = 8;
            bbiSearch.Name = "bbiSearch";
            //bbiSearch.ItemClick += bbiSearch_ItemClick;
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
            repositoryItemSearchControl1.Client = gridControl1;
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
            barDockControlTop.Margin = new Padding(3, 2, 3, 2);
            barDockControlTop.Size = new Size(1122, 48);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 416);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 2, 3, 2);
            barDockControlBottom.Size = new Size(1122, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 48);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 2, 3, 2);
            barDockControlLeft.Size = new Size(0, 368);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1122, 48);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 2, 3, 2);
            barDockControlRight.Size = new Size(0, 368);
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
            // bbiReIssue
            // 
            bbiReIssue.Caption = "إعادة إصدار";
            bbiReIssue.Id = 1;
            bbiReIssue.ImageOptions.ImageIndex = 1;
            bbiReIssue.Name = "bbiReIssue";
            bbiReIssue.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // ucDailyReport
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundedSkinPanel1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucDailyReport";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1122, 434);
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiReIssue;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
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
        private DevExpress.XtraBars.BarButtonItem bbiSearch;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colReportNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colReportDate;
        private DevExpress.XtraGrid.Columns.GridColumn colWeather;
        private DevExpress.XtraGrid.Columns.GridColumn colTemperature;
        private DevExpress.XtraGrid.Columns.GridColumn colShift;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreated;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletion;
        private DevExpress.XtraGrid.Columns.GridColumn colPrjId;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
    }
}
