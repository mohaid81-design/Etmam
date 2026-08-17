namespace Etmam
{
    partial class ucAttachmentAddEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAttachmentAddEdit));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiOpen = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiDownload = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            colFileType = new DevExpress.XtraGrid.Columns.GridColumn();
            colFileSizeKB = new DevExpress.XtraGrid.Columns.GridColumn();
            colUploadDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUploadedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiOpen, bbiEdit, bbiDelete, bbiDownload, barStaticItem1 });
            barManager1.MaxItemId = 11;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            bar1.BarAppearance.Normal.Font = new Font("Cairo", 8.5F);
            bar1.BarAppearance.Normal.Options.UseFont = true;
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Right;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiOpen, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDownload, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiAdd
            // 
            bbiAdd.Caption = "إضافة مرفق";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.ImageIndex = 0;
            bbiAdd.Name = "bbiAdd";
            // 
            // bbiOpen
            // 
            bbiOpen.Caption = "فتح";
            bbiOpen.Id = 1;
            bbiOpen.ImageOptions.ImageIndex = 1;
            bbiOpen.Name = "bbiOpen";
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 3;
            bbiDelete.ImageOptions.ImageIndex = 2;
            bbiDelete.Name = "bbiDelete";
            // 
            // bbiDownload
            // 
            bbiDownload.Caption = "تنزيل";
            bbiDownload.Id = 4;
            bbiDownload.ImageOptions.ImageIndex = 3;
            bbiDownload.Name = "bbiDownload";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1055, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 696);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1055, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 696);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1024, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(31, 696);
            // 
            // imageCollection1
            // 
            imageCollection1.ImageSize = new Size(20, 20);
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.InsertImage(Properties.Resources.add_32x323, "add_32x323", typeof(Properties.Resources), 0);
            imageCollection1.Images.SetKeyName(0, "add_32x323");
            imageCollection1.InsertImage(Properties.Resources.open_32x32, "open_32x32", typeof(Properties.Resources), 1);
            imageCollection1.Images.SetKeyName(1, "open_32x32");
            imageCollection1.InsertImage(Properties.Resources.cancel_32x323, "cancel_32x323", typeof(Properties.Resources), 2);
            imageCollection1.Images.SetKeyName(2, "cancel_32x323");
            imageCollection1.InsertImage(Properties.Resources.download_32x32, "download_32x32", typeof(Properties.Resources), 3);
            imageCollection1.Images.SetKeyName(3, "download_32x32");
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل التعليق";
            bbiEdit.Id = 2;
            bbiEdit.ImageOptions.ImageIndex = 9;
            bbiEdit.Name = "bbiEdit";
            // 
            // barStaticItem1
            // 
            barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barStaticItem1.Caption = "المرفقات: 0";
            barStaticItem1.Id = 5;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 0);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1024, 696);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new Font("Cairo", 9F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFileName, colFileType, colFileSizeKB, colUploadDate, colUploadedBy, colComment });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.RowHeight = 30;
            // 
            // colFileName
            // 
            colFileName.Caption = "اسم الملف";
            colFileName.FieldName = "FileName";
            colFileName.Name = "colFileName";
            colFileName.OptionsColumn.AllowEdit = false;
            colFileName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            colFileName.Visible = true;
            colFileName.VisibleIndex = 0;
            colFileName.Width = 280;
            // 
            // colFileType
            // 
            colFileType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colFileType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colFileType.Caption = "النوع";
            colFileType.FieldName = "FileExtension";
            colFileType.Name = "colFileType";
            colFileType.Visible = true;
            colFileType.VisibleIndex = 1;
            colFileType.Width = 100;
            // 
            // colFileSizeKB
            // 
            colFileSizeKB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colFileSizeKB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colFileSizeKB.Caption = "الحجم (KB)";
            colFileSizeKB.FieldName = "FileSizeKB";
            colFileSizeKB.Name = "colFileSizeKB";
            colFileSizeKB.Visible = true;
            colFileSizeKB.VisibleIndex = 2;
            colFileSizeKB.Width = 90;
            // 
            // colUploadDate
            // 
            colUploadDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colUploadDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colUploadDate.Caption = "تاريخ الرفع";
            colUploadDate.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm";
            colUploadDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colUploadDate.FieldName = "UploadDate";
            colUploadDate.Name = "colUploadDate";
            colUploadDate.Visible = true;
            colUploadDate.VisibleIndex = 3;
            colUploadDate.Width = 130;
            // 
            // colUploadedBy
            // 
            colUploadedBy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colUploadedBy.Caption = "رُفع بواسطة";
            colUploadedBy.FieldName = "UploadedBy";
            colUploadedBy.Name = "colUploadedBy";
            colUploadedBy.Visible = true;
            colUploadedBy.VisibleIndex = 4;
            colUploadedBy.Width = 130;
            // 
            // colComment
            // 
            colComment.Caption = "تعليق";
            colComment.FieldName = "Comment";
            colComment.Name = "colComment";
            colComment.Visible = true;
            colComment.VisibleIndex = 5;
            colComment.Width = 200;
            // 
            // ucAttachmentAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucAttachmentAddEdit";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1055, 696);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiOpen;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiDownload;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        internal DevExpress.XtraGrid.GridControl gridControl1;
        internal DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colFileType;
        private DevExpress.XtraGrid.Columns.GridColumn colFileSizeKB;
        private DevExpress.XtraGrid.Columns.GridColumn colUploadDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUploadedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
    }
}
