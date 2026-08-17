namespace Etmam
{
    partial class ucWorkPlannedTowmorrow
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucWorkPlannedTowmorrow));
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
            gridWorkPlanned = new DevExpress.XtraGrid.GridControl();
            gvWorkPlanned = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colDailyReportId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridWorkPlanned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvWorkPlanned).BeginInit();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiDelete, bbiCopy, barStaticItem1 });
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
            bbiAdd.Caption = "إضافة";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.ImageIndex = 0;
            bbiAdd.Name = "bbiAdd";
            // 
            // bbiCopy
            // 
            bbiCopy.Caption = "نسخ من اليوم السابق";
            bbiCopy.Id = 2;
            bbiCopy.ImageOptions.ImageIndex = 9;
            bbiCopy.Name = "bbiCopy";
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
            imageCollection1.InsertImage(Properties.Resources.edit_16x16, "edit_16x16", typeof(Properties.Resources), 7);
            imageCollection1.Images.SetKeyName(7, "edit_16x16");
            imageCollection1.Images.SetKeyName(8, "6_Search.png");
            imageCollection1.InsertImage(Properties.Resources.sortbyinvoice_16x16, "sortbyinvoice_16x16", typeof(Properties.Resources), 9);
            imageCollection1.Images.SetKeyName(9, "sortbyinvoice_16x16");
            // 
            // barStaticItem1
            // 
            barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barStaticItem1.Caption = "العدد: 0";
            barStaticItem1.Id = 3;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(30, 70, 130);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseForeColor = true;
            groupControl1.Controls.Add(gridWorkPlanned);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(0, 28);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1280, 489);
            groupControl1.TabIndex = 11;
            groupControl1.Text = "وصف الأعمال المستهدفة لليوم التالي";
            // 
            // gridWorkPlanned
            // 
            gridWorkPlanned.Dock = System.Windows.Forms.DockStyle.Fill;
            gridWorkPlanned.Location = new System.Drawing.Point(2, 27);
            gridWorkPlanned.MainView = gvWorkPlanned;
            gridWorkPlanned.MenuManager = barManager1;
            gridWorkPlanned.Name = "gridWorkPlanned";
            gridWorkPlanned.Size = new System.Drawing.Size(1276, 460);
            gridWorkPlanned.TabIndex = 4;
            gridWorkPlanned.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvWorkPlanned });
            // 
            // gvWorkPlanned
            // 
            gvWorkPlanned.Appearance.EvenRow.Options.UseBackColor = true;
            gvWorkPlanned.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            gvWorkPlanned.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(30, 70, 130);
            gvWorkPlanned.Appearance.HeaderPanel.Options.UseFont = true;
            gvWorkPlanned.Appearance.HeaderPanel.Options.UseForeColor = true;
            gvWorkPlanned.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvWorkPlanned.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvWorkPlanned.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8.5F);
            gvWorkPlanned.Appearance.Row.Options.UseFont = true;
            gvWorkPlanned.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colItem, colLocation, colDescription, colCategory, colQty, colDailyReportId, colCreatedDate, colCreatedMachine, colUpdateDate, colUpdateMachine });
            gvWorkPlanned.GridControl = gridWorkPlanned;
            gvWorkPlanned.Name = "gvWorkPlanned";
            gvWorkPlanned.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvWorkPlanned.OptionsView.ColumnAutoWidth = false;
            gvWorkPlanned.OptionsView.EnableAppearanceEvenRow = true;
            gvWorkPlanned.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gvWorkPlanned.OptionsView.ShowGroupPanel = false;
            gvWorkPlanned.ViewCaption = "الأعمال المخطط لها غداً";
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colItem
            // 
            colItem.Caption = "البند";
            colItem.FieldName = "Item";
            colItem.Name = "colItem";
            colItem.Visible = true;
            colItem.VisibleIndex = 0;
            colItem.Width = 120;
            // 
            // colLocation
            // 
            colLocation.Caption = "موقع العمل";
            colLocation.FieldName = "Location";
            colLocation.Name = "colLocation";
            colLocation.Visible = true;
            colLocation.VisibleIndex = 1;
            colLocation.Width = 150;
            // 
            // colDescription
            // 
            colDescription.Caption = "وصف العمل";
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 2;
            colDescription.Width = 300;
            // 
            // colCategory
            // 
            colCategory.Caption = "نوع العمل";
            colCategory.FieldName = "Category";
            colCategory.Name = "colCategory";
            colCategory.Visible = true;
            colCategory.VisibleIndex = 3;
            colCategory.Width = 120;
            // 
            // colQty
            // 
            colQty.AppearanceCell.Options.UseTextOptions = true;
            colQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colQty.Caption = "%";
            colQty.FieldName = "Qty";
            colQty.Name = "colQty";
            colQty.Visible = true;
            colQty.VisibleIndex = 4;
            colQty.Width = 80;
            // 
            // colDailyReportId
            // 
            colDailyReportId.FieldName = "DailyReportId";
            colDailyReportId.Name = "colDailyReportId";
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
            // ucWorkPlannedTomorrow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new System.Drawing.Font("Cairo", 8.5F);
            Name = "ucWorkPlannedTomorrow";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1280, 517);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridWorkPlanned).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvWorkPlanned).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        public DevExpress.XtraBars.BarButtonItem bbiCopy;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridWorkPlanned;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWorkPlanned;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyReportId;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateMachine;
    }
}
