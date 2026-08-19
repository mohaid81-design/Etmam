namespace Etmam
{
    partial class frmBuildingSelect
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiSelect = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            bar3 = new DevExpress.XtraBars.Bar();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colName = new DevExpress.XtraGrid.Columns.GridColumn();
            btnAdd = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            //
            // svgImageCollection1
            //
            svgImageCollection1.Add("apply", "image://svgimages/icon builder/actions_check.svg");
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("actions_add", "image://svgimages/icon builder/actions_add.svg");
            //
            // barManager1
            //
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiSelect, bbiRefresh, barEditItem1, barStaticItem1, btnAdd });
            barManager1.MaxItemId = 5;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemSearchControl1 });
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            //
            // bar1
            //
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSelect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(barEditItem1) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            //
            // bbiSelect
            //
            bbiSelect.Caption = "اختيار";
            bbiSelect.Id = 0;
            bbiSelect.ImageOptions.ImageIndex = 0;
            bbiSelect.Name = "bbiSelect";
            //
            // bbiRefresh
            //
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 1;
            bbiRefresh.ImageOptions.ImageIndex = 1;
            bbiRefresh.Name = "bbiRefresh";
            //
            // barEditItem1
            //
            barEditItem1.Caption = "بحث";
            barEditItem1.Edit = repositoryItemSearchControl1;
            barEditItem1.EditHeight = 20;
            barEditItem1.EditWidth = 220;
            barEditItem1.Id = 2;
            barEditItem1.Name = "barEditItem1";
            //
            // repositoryItemSearchControl1
            //
            repositoryItemSearchControl1.AutoHeight = false;
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
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
            bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barStaticItem1) });
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            //
            // barStaticItem1
            //
            barStaticItem1.Caption = "عدد السجلات : 0";
            barStaticItem1.Id = 3;
            barStaticItem1.Name = "barStaticItem1";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(560, 31);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 421);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(560, 29);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 31);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 390);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(560, 31);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 390);
            //
            // gridControl1
            //
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 31);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(560, 390);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            //
            // gridView1
            //
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new Font("Cairo", 8.5F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colName });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            //
            // colName
            //
            colName.Caption = "اسم المبنى";
            colName.FieldName = "Name";
            colName.MinWidth = 25;
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 0;
            colName.Width = 300;
            //
            // btnAdd
            //
            btnAdd.Caption = "إضافة";
            btnAdd.Id = 4;
            btnAdd.ImageOptions.ImageIndex = 2;
            btnAdd.Name = "btnAdd";
            //
            // frmBuildingSelect
            //
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 450);
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new Font("Cairo", 8.5F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBuildingSelect";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اختيار مبنى";
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiSelect;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
    }
}
