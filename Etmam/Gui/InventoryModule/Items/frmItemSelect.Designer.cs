namespace Etmam
{
    partial class frmItemSelect
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
            btnAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colUnit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colBalance = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            bar3 = new DevExpress.XtraBars.Bar();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
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
            // btnAdd
            // 
            btnAdd.Caption = "إضافة";
            btnAdd.Id = 4;
            btnAdd.ImageOptions.ImageIndex = 2;
            btnAdd.Name = "btnAdd";
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
            repositoryItemSearchControl1.Client = treeList1;
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            repositoryItemSearchControl1.NullValuePrompt = " ";
            // 
            // treeList1
            // 
            treeList1.Appearance.HeaderPanel.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            treeList1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            treeList1.Appearance.HeaderPanel.Options.UseForeColor = true;
            treeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeList1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeList1.Appearance.Row.Font = new Font("Cairo", 9F);
            treeList1.Appearance.Row.Options.UseFont = true;
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colName, colCode, colUnit, colDescription, colBalance });
            treeList1.Dock = DockStyle.Fill;
            treeList1.Location = new Point(0, 31);
            treeList1.MenuManager = barManager1;
            treeList1.Name = "treeList1";
            treeList1.OptionsView.AutoWidth = false;
            treeList1.OptionsView.ShowIndicator = false;
            treeList1.Size = new Size(749, 685);
            treeList1.TabIndex = 4;
            // 
            // colName
            // 
            colName.Caption = "الصنف / التصنيف";
            colName.FieldName = "Name";
            colName.MinWidth = 25;
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 1;
            colName.Width = 350;
            // 
            // colCode
            // 
            colCode.AppearanceCell.Options.UseTextOptions = true;
            colCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCode.Caption = "كود الصنف";
            colCode.FieldName = "Code";
            colCode.MinWidth = 25;
            colCode.Name = "colCode";
            colCode.SortOrder = SortOrder.Ascending;
            colCode.Visible = true;
            colCode.VisibleIndex = 0;
            colCode.Width = 200;
            // 
            // colUnit
            // 
            colUnit.AppearanceCell.Options.UseTextOptions = true;
            colUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colUnit.Caption = "الوحدة";
            colUnit.FieldName = "Unit";
            colUnit.MinWidth = 25;
            colUnit.Name = "colUnit";
            colUnit.Visible = true;
            colUnit.VisibleIndex = 2;
            colUnit.Width = 80;
            // 
            // colDescription
            // 
            colDescription.Caption = "الوصف";
            colDescription.FieldName = "Description";
            colDescription.MinWidth = 25;
            colDescription.Name = "colDescription";
            colDescription.Width = 260;
            // 
            // colBalance
            // 
            colBalance.AppearanceCell.Options.UseTextOptions = true;
            colBalance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colBalance.Caption = "الرصيد";
            colBalance.FieldName = "Balance";
            colBalance.MinWidth = 25;
            colBalance.Name = "colBalance";
            colBalance.Visible = true;
            colBalance.VisibleIndex = 3;
            colBalance.Width = 100;
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
            barDockControlTop.Size = new Size(749, 31);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 716);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(749, 29);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 31);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 685);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(749, 31);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 685);
            // 
            // frmItemSelect
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 745);
            Controls.Add(treeList1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new Font("Cairo", 8.5F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmItemSelect";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اختيار الأصناف";
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
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
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUnit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBalance;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
    }
}
