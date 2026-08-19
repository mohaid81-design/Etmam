namespace Etmam
{
    partial class frmPurchaseRequestLog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseRequestLog));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            colStepName = new DevExpress.XtraGrid.Columns.GridColumn();
            colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            colActionByName = new DevExpress.XtraGrid.Columns.GridColumn();
            colActionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).BeginInit();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = imageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiPrint });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 23;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemSearchControl1 });
            barManager1.StatusBar = bar3;
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MinHeight = 35;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // bbiPrint
            // 
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 2;
            bbiPrint.ImageOptions.ImageIndex = 6;
            bbiPrint.Name = "bbiPrint";
            bbiPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            barDockControlTop.Margin = new Padding(3, 5, 3, 5);
            barDockControlTop.Size = new Size(990, 35);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 499);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(990, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 35);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 464);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(990, 35);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 464);
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.InsertImage(Properties.Resources.add_16x161, "Add", typeof(Properties.Resources), 0, "add_16x161");
            imageCollection1.Images.SetKeyName(0, "Add");
            imageCollection1.InsertImage(Properties.Resources.last_16x162, "First", typeof(Properties.Resources), 1, "last_16x162");
            imageCollection1.Images.SetKeyName(1, "First");
            imageCollection1.InsertImage(Properties.Resources.next_16x162, "Prev", typeof(Properties.Resources), 2, "next_16x162");
            imageCollection1.Images.SetKeyName(2, "Prev");
            imageCollection1.InsertImage(Properties.Resources.prev_16x162, "Next", typeof(Properties.Resources), 3, "prev_16x162");
            imageCollection1.Images.SetKeyName(3, "Next");
            imageCollection1.InsertImage(Properties.Resources.first_16x162, "Last", typeof(Properties.Resources), 4, "first_16x162");
            imageCollection1.Images.SetKeyName(4, "Last");
            imageCollection1.InsertImage(Properties.Resources.save_16x161, "save", typeof(Properties.Resources), 5, "save_16x161");
            imageCollection1.Images.SetKeyName(5, "save");
            imageCollection1.InsertImage(Properties.Resources.print_16x16, "print", typeof(Properties.Resources), 6, "print_16x16");
            imageCollection1.Images.SetKeyName(6, "print");
            imageCollection1.InsertImage(Properties.Resources.showtestreport_16x16, "Action", typeof(Properties.Resources), 7, "showtestreport_16x16");
            imageCollection1.Images.SetKeyName(7, "Action");
            imageCollection1.InsertImage(Properties.Resources.sortbyinvoice_16x166, "AddItems", typeof(Properties.Resources), 8, "sortbyinvoice_16x166");
            imageCollection1.Images.SetKeyName(8, "AddItems");
            imageCollection1.InsertImage(Properties.Resources.edit_16x166, "Edit", typeof(Properties.Resources), 9, "edit_16x166");
            imageCollection1.Images.SetKeyName(9, "Edit");
            imageCollection1.InsertImage(Properties.Resources.delete_16x16, "Delete", typeof(Properties.Resources), 10, "delete_16x16");
            imageCollection1.Images.SetKeyName(10, "Delete");
            imageCollection1.InsertImage(Properties.Resources.open_16x162, "open_16x162", typeof(Properties.Resources), 11);
            imageCollection1.Images.SetKeyName(11, "open_16x162");
            imageCollection1.InsertImage(Properties.Resources.apply_32x32, "apply_32x32", typeof(Properties.Resources), 12);
            imageCollection1.Images.SetKeyName(12, "apply_32x32");
            imageCollection1.InsertImage(Properties.Resources.cancel_32x324, "cancel_32x324", typeof(Properties.Resources), 13);
            imageCollection1.Images.SetKeyName(13, "cancel_32x324");
            imageCollection1.InsertImage(Properties.Resources.borules_32x32, "borules_32x32", typeof(Properties.Resources), 14);
            imageCollection1.Images.SetKeyName(14, "borules_32x32");
            // 
            // repositoryItemSearchControl1
            // 
            repositoryItemSearchControl1.AutoHeight = false;
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            repositoryItemSearchControl1.NullValuePrompt = " ";
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 35);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemMemoEdit1 });
            gridControl1.Size = new Size(990, 464);
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
            gridView1.Appearance.Row.Font = new Font("Cairo", 8F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colSource, colStepName, colAction, colActionByName, colActionDate, colComment });
            gridView1.DetailHeight = 349;
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.RowHeight = 30;
            // 
            // colSource
            // 
            colSource.AppearanceCell.Options.UseTextOptions = true;
            colSource.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            colSource.Caption = "المستند";
            colSource.FieldName = "Source";
            colSource.Name = "colSource";
            colSource.OptionsColumn.AllowEdit = false;
            colSource.OptionsColumn.AllowFocus = false;
            colSource.Visible = true;
            colSource.VisibleIndex = 0;
            colSource.Width = 220;
            // 
            // colStepName
            // 
            colStepName.AppearanceCell.Options.UseTextOptions = true;
            colStepName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            colStepName.Caption = "الخطوة";
            colStepName.FieldName = "StepName";
            colStepName.Name = "colStepName";
            colStepName.OptionsColumn.AllowEdit = false;
            colStepName.OptionsColumn.AllowFocus = false;
            colStepName.Visible = true;
            colStepName.VisibleIndex = 1;
            colStepName.Width = 200;
            // 
            // colAction
            // 
            colAction.AppearanceCell.Options.UseTextOptions = true;
            colAction.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            colAction.Caption = "الإجراء";
            colAction.FieldName = "Action";
            colAction.Name = "colAction";
            colAction.OptionsColumn.AllowEdit = false;
            colAction.OptionsColumn.AllowFocus = false;
            colAction.Visible = true;
            colAction.VisibleIndex = 2;
            colAction.Width = 120;
            // 
            // colActionByName
            // 
            colActionByName.AppearanceCell.Options.UseTextOptions = true;
            colActionByName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            colActionByName.Caption = "بواسطة";
            colActionByName.FieldName = "ActionByName";
            colActionByName.Name = "colActionByName";
            colActionByName.OptionsColumn.AllowEdit = false;
            colActionByName.OptionsColumn.AllowFocus = false;
            colActionByName.Visible = true;
            colActionByName.VisibleIndex = 3;
            colActionByName.Width = 150;
            // 
            // colActionDate
            // 
            colActionDate.Caption = "التاريخ والوقت";
            colActionDate.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm";
            colActionDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colActionDate.FieldName = "ActionDate";
            colActionDate.Name = "colActionDate";
            colActionDate.OptionsColumn.AllowEdit = false;
            colActionDate.OptionsColumn.AllowFocus = false;
            colActionDate.Visible = true;
            colActionDate.VisibleIndex = 4;
            colActionDate.Width = 150;
            // 
            // colComment
            // 
            colComment.AppearanceCell.Options.UseTextOptions = true;
            colComment.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            colComment.Caption = "ملاحظة";
            colComment.ColumnEdit = repositoryItemMemoEdit1;
            colComment.FieldName = "Comment";
            colComment.Name = "colComment";
            colComment.OptionsColumn.AllowEdit = false;
            colComment.OptionsColumn.AllowFocus = false;
            colComment.Visible = true;
            colComment.VisibleIndex = 5;
            colComment.Width = 220;
            // 
            // repositoryItemMemoEdit1
            // 
            repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // frmPurchaseRequestLog
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 517);
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "frmPurchaseRequestLog";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "سجل إجراءات طلب الشراء";
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colStepName;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraGrid.Columns.GridColumn colActionByName;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}