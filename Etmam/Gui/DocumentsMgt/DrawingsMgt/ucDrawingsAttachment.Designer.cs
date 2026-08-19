namespace Etmam
{
    partial class ucDrawingsAttachment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDrawingsAttachment));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiOpen = new DevExpress.XtraBars.BarButtonItem();
            bbiDownload = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            colFileExtension = new DevExpress.XtraGrid.Columns.GridColumn();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiDelete, bbiOpen, bbiDownload, barStaticItem1 });
            barManager1.MaxItemId = 5;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiOpen, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDownload, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(barStaticItem1, true) });
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
            bbiAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiOpen
            // 
            bbiOpen.Caption = "فتح";
            bbiOpen.Id = 2;
            bbiOpen.ImageOptions.ImageIndex = 7;
            bbiOpen.Name = "bbiOpen";
            bbiOpen.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiDownload
            // 
            bbiDownload.Caption = "تنزيل";
            bbiDownload.Id = 4;
            bbiDownload.ImageOptions.ImageIndex = 8;
            bbiDownload.Name = "bbiDownload";
            bbiDownload.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 1;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.Name = "bbiDelete";
            bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem1
            // 
            barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barStaticItem1.Caption = "المرفقات: 0";
            barStaticItem1.Id = 3;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1304, 31);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 572);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1304, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 31);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 541);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1304, 31);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 541);
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
            imageCollection1.InsertImage(Properties.Resources.article_32x32, "article_32x32", typeof(Properties.Resources), 7);
            imageCollection1.Images.SetKeyName(7, "article_32x32");
            imageCollection1.InsertImage(Properties.Resources.download_32x322, "download_32x322", typeof(Properties.Resources), 8);
            imageCollection1.Images.SetKeyName(8, "download_32x322");
            imageCollection1.InsertImage(Properties.Resources.download_32x321, "download_32x321", typeof(Properties.Resources), 10);
            imageCollection1.Images.SetKeyName(10, "download_32x321");
            imageCollection1.InsertImage(Properties.Resources.open_16x162, "open_16x162", typeof(Properties.Resources), 11);
            imageCollection1.Images.SetKeyName(11, "open_16x162");
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 31);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1304, 541);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(248, 249, 250);
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new Font("Cairo", 9F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFileName, colFileExtension, colFileSizeKB, colUploadDate, colUploadedBy, colComment });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.AutoPopulateColumns = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.ViewCaption = "المرفقات";
            // 
            // colFileName
            // 
            colFileName.Caption = "اسم الملف";
            colFileName.FieldName = "FileName";
            colFileName.Name = "colFileName";
            colFileName.Visible = true;
            colFileName.VisibleIndex = 0;
            colFileName.Width = 260;
            // 
            // colFileExtension
            // 
            colFileExtension.AppearanceCell.Options.UseTextOptions = true;
            colFileExtension.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colFileExtension.Caption = "النوع";
            colFileExtension.FieldName = "FileExtension";
            colFileExtension.Name = "colFileExtension";
            colFileExtension.Visible = true;
            colFileExtension.VisibleIndex = 1;
            colFileExtension.Width = 80;
            // 
            // colFileSizeKB
            // 
            colFileSizeKB.AppearanceCell.Options.UseTextOptions = true;
            colFileSizeKB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colFileSizeKB.Caption = "الحجم (KB)";
            colFileSizeKB.FieldName = "FileSizeKB";
            colFileSizeKB.Name = "colFileSizeKB";
            colFileSizeKB.Visible = true;
            colFileSizeKB.VisibleIndex = 2;
            colFileSizeKB.Width = 100;
            // 
            // colUploadDate
            // 
            colUploadDate.Caption = "تاريخ الرفع";
            colUploadDate.FieldName = "UploadDate";
            colUploadDate.Name = "colUploadDate";
            colUploadDate.Visible = true;
            colUploadDate.VisibleIndex = 3;
            colUploadDate.Width = 140;
            // 
            // colUploadedBy
            // 
            colUploadedBy.Caption = "بواسطة";
            colUploadedBy.FieldName = "UploadedBy";
            colUploadedBy.Name = "colUploadedBy";
            colUploadedBy.Visible = true;
            colUploadedBy.VisibleIndex = 4;
            colUploadedBy.Width = 140;
            // 
            // colComment
            // 
            colComment.Caption = "ملاحظات";
            colComment.FieldName = "Comment";
            colComment.Name = "colComment";
            colComment.Visible = true;
            colComment.VisibleIndex = 5;
            colComment.Width = 200;
            // 
            // ucDrawingsAttachment
            // 
            Appearance.Font = new Font("Cairo", 9F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucDrawingsAttachment";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1304, 572);
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
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiOpen;
        private DevExpress.XtraBars.BarButtonItem bbiDownload;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colFileExtension;
        private DevExpress.XtraGrid.Columns.GridColumn colFileSizeKB;
        private DevExpress.XtraGrid.Columns.GridColumn colUploadDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUploadedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
    }
}
