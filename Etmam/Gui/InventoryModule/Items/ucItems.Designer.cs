namespace Etmam
{
    partial class ucItems
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
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            btnOpen = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiExpandCollapse = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            colCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            colUnit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            lookUpUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colCategoryCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colIsActive = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colIdSort = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colItemId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpUnit).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("new", "image://svgimages/actions/new.svg");
            svgImageCollection1.Add("actions_edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("actions_delete", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("print", "image://svgimages/print/print.svg");
            svgImageCollection1.Add("actions_refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("task_1", "image://svgimages/outlook inspired/task.svg");
            svgImageCollection1.Add("autoexpand", "image://svgimages/dashboards/autoexpand.svg");
            svgImageCollection1.Add("open", "image://svgimages/actions/open.svg");
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiEdit, bbiDelete, bbiPrint, bbiRefresh, barEditItem1, bbiExpandCollapse, btnOpen });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 8;
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
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, btnOpen, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExpandCollapse, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(barEditItem1) });
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
            btnOpen.Id = 7;
            btnOpen.ImageOptions.ImageIndex = 7;
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
            // bbiExpandCollapse
            // 
            bbiExpandCollapse.Caption = "فرز/تجميع";
            bbiExpandCollapse.Id = 6;
            bbiExpandCollapse.ImageOptions.ImageIndex = 6;
            bbiExpandCollapse.Name = "bbiExpandCollapse";
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
            repositoryItemSearchControl1.Client = treeList1;
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            repositoryItemSearchControl1.NullValuePrompt = " ";
            // 
            // treeList1
            // 
            treeList1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            treeList1.Appearance.HeaderPanel.ForeColor = Color.Navy;
            treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            treeList1.Appearance.HeaderPanel.Options.UseForeColor = true;
            treeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeList1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeList1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            treeList1.Appearance.Row.Font = new Font("Cairo", 8.5F);
            treeList1.Appearance.Row.Options.UseFont = true;
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colCode, colName, colUnit, colCategoryCode, colDescription, colIsActive, colIdSort, colItemId });
            treeList1.Dock = DockStyle.Fill;
            treeList1.KeyFieldName = "NodeKey";
            treeList1.Location = new Point(0, 35);
            treeList1.MenuManager = barManager1;
            treeList1.Name = "treeList1";
            treeList1.OptionsBehavior.Editable = false;
            treeList1.OptionsBehavior.ReadOnly = true;
            treeList1.OptionsView.AutoWidth = false;
            treeList1.OptionsView.ShowIndicator = false;
            treeList1.ParentFieldName = "ParentNodeKey";
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { lookUpUnit, repositoryItemMemoEdit1 });
            treeList1.Size = new Size(1300, 647);
            treeList1.TabIndex = 5;
            // 
            // colCode
            // 
            colCode.AppearanceCell.Options.UseTextOptions = true;
            colCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCode.Caption = "كود الصنف";
            colCode.FieldName = "Code";
            colCode.MinWidth = 25;
            colCode.Name = "colCode";
            colCode.OptionsColumn.AllowEdit = false;
            colCode.OptionsColumn.AllowFocus = false;
            colCode.Visible = true;
            colCode.VisibleIndex = 0;
            colCode.Width = 200;
            // 
            // colName
            // 
            colName.Caption = "إسم الصنف / التصنيف";
            colName.ColumnEdit = repositoryItemMemoEdit1;
            colName.FieldName = "Name";
            colName.MinWidth = 25;
            colName.Name = "colName";
            colName.OptionsColumn.AllowEdit = false;
            colName.OptionsColumn.AllowFocus = false;
            colName.Visible = true;
            colName.VisibleIndex = 1;
            colName.Width = 262;
            // 
            // repositoryItemMemoEdit1
            // 
            repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colUnit
            // 
            colUnit.AppearanceCell.Options.UseTextOptions = true;
            colUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colUnit.Caption = "الوحده";
            colUnit.ColumnEdit = lookUpUnit;
            colUnit.FieldName = "UnitId";
            colUnit.MinWidth = 25;
            colUnit.Name = "colUnit";
            colUnit.OptionsColumn.AllowEdit = false;
            colUnit.OptionsColumn.AllowFocus = false;
            colUnit.Visible = true;
            colUnit.VisibleIndex = 2;
            colUnit.Width = 100;
            // 
            // lookUpUnit
            // 
            lookUpUnit.AutoHeight = false;
            lookUpUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpUnit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbreviation", "Name1") });
            lookUpUnit.DisplayMember = "Abbreviation";
            lookUpUnit.Name = "lookUpUnit";
            lookUpUnit.NullText = "";
            lookUpUnit.ValueMember = "Id";
            // 
            // colCategoryCode
            // 
            colCategoryCode.AppearanceCell.Options.UseTextOptions = true;
            colCategoryCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCategoryCode.Caption = "كود التصنيف";
            colCategoryCode.FieldName = "CategoryCode";
            colCategoryCode.MinWidth = 25;
            colCategoryCode.Name = "colCategoryCode";
            colCategoryCode.OptionsColumn.AllowEdit = false;
            colCategoryCode.OptionsColumn.AllowFocus = false;
            colCategoryCode.Width = 110;
            // 
            // colDescription
            // 
            colDescription.Caption = "الوصف";
            colDescription.ColumnEdit = repositoryItemMemoEdit1;
            colDescription.FieldName = "Description";
            colDescription.MinWidth = 25;
            colDescription.Name = "colDescription";
            colDescription.OptionsColumn.AllowEdit = false;
            colDescription.OptionsColumn.AllowFocus = false;
            colDescription.Width = 344;
            // 
            // colIsActive
            // 
            colIsActive.Caption = "نشط";
            colIsActive.FieldName = "IsActive";
            colIsActive.Name = "colIsActive";
            colIsActive.OptionsColumn.AllowEdit = false;
            colIsActive.OptionsColumn.AllowFocus = false;
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 3;
            // 
            // colIdSort
            // 
            colIdSort.Caption = "IdSub";
            colIdSort.FieldName = "IdSort";
            colIdSort.MinWidth = 25;
            colIdSort.Name = "colIdSort";
            colIdSort.OptionsColumn.AllowEdit = false;
            colIdSort.OptionsColumn.AllowFocus = false;
            colIdSort.Width = 94;
            // 
            // colItemId
            // 
            colItemId.Caption = "Id";
            colItemId.FieldName = "ItemId";
            colItemId.MinWidth = 25;
            colItemId.Name = "colItemId";
            colItemId.OptionsColumn.AllowEdit = false;
            colItemId.OptionsColumn.AllowFocus = false;
            colItemId.Width = 94;
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
            barDockControlTop.Size = new Size(1300, 35);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 682);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(1300, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 35);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 647);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1300, 35);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 647);
            // 
            // ucItems
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(treeList1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucItems";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpUnit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
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
        public DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUnit;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpUnit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCategoryCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colItemId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIdSort;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsActive;
        private DevExpress.XtraBars.BarButtonItem bbiExpandCollapse;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
    }
}
