
namespace Etmam
{
    partial class ucDailyPhoto
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDailyPhoto));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiCopy = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            gridPhoto = new DevExpress.XtraGrid.GridControl();
            gvPhoto = new DevExpress.XtraGrid.Views.Grid.GridView();
            tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colPhoto = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            colDailyReportId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colDailyReport = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tileView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemPictureEdit1).BeginInit();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = imageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiCopy, bbiDelete, barStaticItem1 });
            barManager1.MaxItemId = 4;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCopy, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiAdd
            // 
            bbiAdd.Caption = "إضافة صورة";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.ImageIndex = 0;
            bbiAdd.Name = "bbiAdd";
            // 
            // bbiCopy
            // 
            bbiCopy.Caption = "نسخ من السابق";
            bbiCopy.Id = 2;
            bbiCopy.ImageOptions.ImageIndex = 9;
            bbiCopy.Name = "bbiCopy";
            bbiCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 1;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.Name = "bbiDelete";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(1280, 28);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 517);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(1280, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 489);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1280, 28);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 489);
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
            // 
            // barStaticItem1
            // 
            barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barStaticItem1.Caption = "عدد السجلات : 0";
            barStaticItem1.Id = 3;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(30, 70, 130);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseForeColor = true;
            groupControl1.Controls.Add(gridPhoto);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(0, 28);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1280, 489);
            groupControl1.TabIndex = 11;
            groupControl1.Text = "صور تقدم الأنشطة";
            // 
            // gridPhoto
            // 
            gridPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            gridPhoto.Location = new System.Drawing.Point(2, 27);
            gridPhoto.MainView = tileView1;
            gridPhoto.MenuManager = barManager1;
            gridPhoto.Name = "gridPhoto";
            gridPhoto.Size = new System.Drawing.Size(1276, 460);
            gridPhoto.TabIndex = 4;
            gridPhoto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvPhoto, tileView1 });
            // 
            // gvPhoto
            // 
            gvPhoto.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            gvPhoto.Appearance.EvenRow.Options.UseBackColor = true;
            gvPhoto.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            gvPhoto.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(30, 70, 130);
            gvPhoto.Appearance.HeaderPanel.Options.UseFont = true;
            gvPhoto.Appearance.HeaderPanel.Options.UseForeColor = true;
            gvPhoto.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvPhoto.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvPhoto.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8.5F);
            gvPhoto.Appearance.Row.Options.UseFont = true;
            gvPhoto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colDescription, colPhoto, colDailyReportId, colCreatedBy, colCreatedDate, colCreatedMachine, colUpdateBy, colUpdateDate, colUpdateMachine, colIsDelete, colDeletionBy, colDeletionDate, colDeletionMachine, colDailyReport });
            gvPhoto.GridControl = gridPhoto;
            gvPhoto.Name = "gvPhoto";
            gvPhoto.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvPhoto.OptionsView.ColumnAutoWidth = false;
            gvPhoto.OptionsView.EnableAppearanceEvenRow = true;
            gvPhoto.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gvPhoto.OptionsView.ShowFooter = true;
            gvPhoto.OptionsView.ShowGroupPanel = false;
            gvPhoto.ViewCaption = "الصور";
            // 
            // tileView1
            // 
            tileView1.GridControl = gridPhoto;
            tileView1.Name = "tileView1";
            tileView1.OptionsTiles.ItemSize = new Size(350, 300);
            tileView1.OptionsTiles.Orientation = Orientation.Horizontal;
            tileView1.OptionsTiles.RowCount = 0;
            tileView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileViewItemElement1.Text = "";
            tileViewItemElement1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.None;

            tileViewItemElement2.Appearance.Normal.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            tileViewItemElement2.Appearance.Normal.ForeColor = Color.DimGray;
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement2.Column = colDescription;
            tileViewItemElement2.Text = "colDescription";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            
            tileView1.TileTemplate.Add(tileViewItemElement1);
            tileView1.TileTemplate.Add(tileViewItemElement2);
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colDescription
            // 
            colDescription.Caption = "الوصف";
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 1;
            colDescription.Width = 300;
            // 
            // colPhoto
            // 
            colPhoto.Caption = "الصورة";
            colPhoto.ColumnEdit = repositoryItemPictureEdit1;
            colPhoto.FieldName = "Photo";
            colPhoto.Name = "colPhoto";
            colPhoto.Visible = true;
            colPhoto.VisibleIndex = 0;
            colPhoto.Width = 150;
            // 
            // repositoryItemPictureEdit1
            // 
            repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            // 
            // colDailyReportId
            // 
            colDailyReportId.FieldName = "DailyReportId";
            colDailyReportId.Name = "colDailyReportId";
            // 
            // colCreatedBy
            // 
            colCreatedBy.FieldName = "CreatedBy";
            colCreatedBy.Name = "colCreatedBy";
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colCreatedMachine
            // 
            colCreatedMachine.FieldName = "CreatedMachine";
            colCreatedMachine.Name = "colCreatedMachine";
            // 
            // colUpdateBy
            // 
            colUpdateBy.FieldName = "UpdateBy";
            colUpdateBy.Name = "colUpdateBy";
            // 
            // colUpdateDate
            // 
            colUpdateDate.FieldName = "UpdateDate";
            colUpdateDate.Name = "colUpdateDate";
            // 
            // colUpdateMachine
            // 
            colUpdateMachine.FieldName = "UpdateMachine";
            colUpdateMachine.Name = "colUpdateMachine";
            // 
            // colIsDelete
            // 
            colIsDelete.FieldName = "IsDelete";
            colIsDelete.Name = "colIsDelete";
            // 
            // colDeletionBy
            // 
            colDeletionBy.FieldName = "DeletionBy";
            colDeletionBy.Name = "colDeletionBy";
            // 
            // colDeletionDate
            // 
            colDeletionDate.FieldName = "DeletionDate";
            colDeletionDate.Name = "colDeletionDate";
            // 
            // colDeletionMachine
            // 
            colDeletionMachine.FieldName = "DeletionMachine";
            colDeletionMachine.Name = "colDeletionMachine";
            // 
            // colDailyReport
            // 
            colDailyReport.FieldName = "DailyReport";
            colDailyReport.Name = "colDailyReport";
            // 
            // ucDailyPhoto
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucDailyPhoto";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1280, 517);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)tileView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemPictureEdit1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        public DevExpress.XtraBars.BarButtonItem bbiCopy;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraGrid.GridControl gridPhoto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPhoto;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoto;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyReportId;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyReport;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
    }
}