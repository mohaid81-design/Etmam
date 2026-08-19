namespace Etmam
{
    partial class ucStocking
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
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            btnOpen = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colStockingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colStoreId = new DevExpress.XtraGrid.Columns.GridColumn();
            riLookUpStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)riLookUpStore).BeginInit();
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
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiEdit, bbiDelete, bbiPrint, bbiRefresh, barEditItem1, btnOpen });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 7;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemSearchControl1 });
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            // 
            // bar2
            // 
            bar2.BarAppearance.Disabled.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Disabled.Options.UseFont = true;
            bar2.BarAppearance.Hovered.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Hovered.Options.UseFont = true;
            bar2.BarAppearance.Normal.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Normal.Options.UseFont = true;
            bar2.BarAppearance.Pressed.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Pressed.Options.UseFont = true;
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, btnOpen, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(barEditItem1) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MinHeight = 35;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // bbiNew
            // 
            bbiNew.Caption = "جديد";
            bbiNew.Id = 0;
            bbiNew.ImageOptions.ImageIndex = 0;
            bbiNew.Name = "bbiNew";
            // 
            // btnOpen
            // 
            btnOpen.Caption = "فتح";
            btnOpen.Id = 6;
            btnOpen.ImageOptions.ImageIndex = 6;
            btnOpen.Name = "btnOpen";
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 1;
            bbiEdit.ImageOptions.ImageIndex = 1;
            bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 2;
            bbiDelete.ImageOptions.ImageIndex = 2;
            bbiDelete.Name = "bbiDelete";
            // 
            // bbiPrint
            // 
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 3;
            bbiPrint.ImageOptions.ImageIndex = 3;
            bbiPrint.Name = "bbiPrint";
            // 
            // bbiRefresh
            // 
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 4;
            bbiRefresh.ImageOptions.ImageIndex = 4;
            bbiRefresh.Name = "bbiRefresh";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "barEditItem1";
            barEditItem1.Edit = repositoryItemSearchControl1;
            barEditItem1.EditHeight = 20;
            barEditItem1.EditWidth = 200;
            barEditItem1.Id = 5;
            barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemSearchControl1
            // 
            repositoryItemSearchControl1.AutoHeight = false;
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            repositoryItemSearchControl1.Client = gridControl1;
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            repositoryItemSearchControl1.NullValuePrompt = " ";
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
            barDockControlTop.Size = new Size(1340, 35);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 722);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(1340, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 35);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 687);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1340, 35);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 687);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("new", "image://svgimages/actions/new.svg");
            svgImageCollection1.Add("actions_edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("actions_delete", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("print", "image://svgimages/print/print.svg");
            svgImageCollection1.Add("actions_refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("task_1", "image://svgimages/outlook inspired/task.svg");
            svgImageCollection1.Add("open", "image://svgimages/actions/open.svg");
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 35);
            gridControl1.MainView = gridView1;
            gridControl1.Margin = new Padding(3, 5, 3, 5);
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { riLookUpStore });
            gridControl1.Size = new Size(1340, 687);
            gridControl1.TabIndex = 6;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new Font("Cairo", 8.5F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colNum, colStockingDate, colStoreId });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            colId.Caption = "م";
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colNum
            // 
            colNum.AppearanceCell.Options.UseTextOptions = true;
            colNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colNum.Caption = "رقم الجرد";
            colNum.FieldName = "Num";
            colNum.MinWidth = 25;
            colNum.Name = "colNum";
            colNum.Visible = true;
            colNum.VisibleIndex = 0;
            colNum.Width = 100;
            // 
            // colStockingDate
            // 
            colStockingDate.AppearanceCell.Options.UseTextOptions = true;
            colStockingDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colStockingDate.Caption = "تاريخ الجرد";
            colStockingDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            colStockingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colStockingDate.FieldName = "StockingDate";
            colStockingDate.MinWidth = 25;
            colStockingDate.Name = "colStockingDate";
            colStockingDate.Visible = true;
            colStockingDate.VisibleIndex = 1;
            colStockingDate.Width = 120;
            // 
            // colStoreId
            // 
            colStoreId.Caption = "إسم المخزن";
            colStoreId.ColumnEdit = riLookUpStore;
            colStoreId.FieldName = "StoreId";
            colStoreId.MinWidth = 25;
            colStoreId.Name = "colStoreId";
            colStoreId.Visible = true;
            colStoreId.VisibleIndex = 2;
            colStoreId.Width = 200;
            // 
            // riLookUpStore
            // 
            riLookUpStore.AutoHeight = false;
            riLookUpStore.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            riLookUpStore.Name = "riLookUpStore";
            // 
            // ucStocking
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucStocking";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1340, 740);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)riLookUpStore).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNum;
        private DevExpress.XtraGrid.Columns.GridColumn colStockingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLookUpStore;
    }
}
