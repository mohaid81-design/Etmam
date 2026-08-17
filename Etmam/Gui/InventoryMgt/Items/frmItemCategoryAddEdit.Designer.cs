namespace Etmam
{
    partial class frmItemCategoryAddEdit
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
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            bar1 = new DevExpress.XtraBars.Bar();
            btnMoveUp = new DevExpress.XtraBars.BarButtonItem();
            btnMoveDown = new DevExpress.XtraBars.BarButtonItem();
            btnMoveRight = new DevExpress.XtraBars.BarButtonItem();
            btnMoveLeft = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            colCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colSortId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCreatedDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCreatedMachine = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colUpdateDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colUpdateMachine = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colIsDelete = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colDeletionDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colDeletionMachine = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCreatedBy = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCreated = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colUpdateBy = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colUpdate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colDeletionBy = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colDeletion = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colLvlId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            itemCategoryBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemCategoryBindingSource).BeginInit();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2, bar3, bar1 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiEdit, bbiDelete, bbiPrint, bbiRefresh, barStaticItem1, btnMoveUp, btnMoveDown, btnMoveRight, btnMoveLeft });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 11;
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
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbiNew), new DevExpress.XtraBars.LinkPersistInfo(bbiEdit), new DevExpress.XtraBars.LinkPersistInfo(bbiDelete), new DevExpress.XtraBars.LinkPersistInfo(bbiPrint, true), new DevExpress.XtraBars.LinkPersistInfo(bbiRefresh) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MinHeight = 30;
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
            barStaticItem1.Caption = "عدد السجلات: 0";
            barStaticItem1.Id = 6;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // bar1
            // 
            bar1.BarName = "Custom 4";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Right;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(btnMoveUp), new DevExpress.XtraBars.LinkPersistInfo(btnMoveDown), new DevExpress.XtraBars.LinkPersistInfo(btnMoveRight), new DevExpress.XtraBars.LinkPersistInfo(btnMoveLeft) });
            bar1.OptionsBar.AllowCollapse = true;
            bar1.OptionsBar.AllowDelete = true;
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Custom 4";
            // 
            // btnMoveUp
            // 
            btnMoveUp.Caption = "نقل لأعلى";
            btnMoveUp.Hint = "نقل لأعلى";
            btnMoveUp.Id = 7;
            btnMoveUp.ImageOptions.ImageIndex = 6;
            btnMoveUp.Name = "btnMoveUp";
            // 
            // btnMoveDown
            // 
            btnMoveDown.Caption = "نقل لأسفل";
            btnMoveDown.Hint = "نقل لأسفل";
            btnMoveDown.Id = 8;
            btnMoveDown.ImageOptions.ImageIndex = 7;
            btnMoveDown.Name = "btnMoveDown";
            // 
            // btnMoveRight
            // 
            btnMoveRight.Caption = "خفض المستوى (فرعي)";
            btnMoveRight.Hint = "خفض المستوى (فرعي)";
            btnMoveRight.Id = 9;
            btnMoveRight.ImageOptions.ImageIndex = 9;
            btnMoveRight.Name = "btnMoveRight";
            // 
            // btnMoveLeft
            // 
            btnMoveLeft.Caption = "رفع المستوى (رئيسي)";
            btnMoveLeft.Hint = "رفع المستوى (رئيسي)";
            btnMoveLeft.Id = 10;
            btnMoveLeft.ImageOptions.ImageIndex = 8;
            btnMoveLeft.Name = "btnMoveLeft";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(485, 30);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 653);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(485, 24);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 30);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 623);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(459, 30);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(26, 623);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("actions_add", "image://svgimages/icon builder/actions_add.svg");
            svgImageCollection1.Add("actions_edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("actions_delete", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("print", "image://svgimages/print/print.svg");
            svgImageCollection1.Add("actions_refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("task_1", "image://svgimages/outlook inspired/task.svg");
            svgImageCollection1.Add("actions_arrow1up", "image://svgimages/icon builder/actions_arrow1up.svg");
            svgImageCollection1.Add("actions_arrow1down", "image://svgimages/icon builder/actions_arrow1down.svg");
            svgImageCollection1.Add("actions_arrow1right", "image://svgimages/icon builder/actions_arrow1right.svg");
            svgImageCollection1.Add("actions_arrow1left", "image://svgimages/icon builder/actions_arrow1left.svg");
            svgImageCollection1.Add("new", "image://svgimages/actions/new.svg");
            // 
            // repositoryItemSearchControl1
            // 
            repositoryItemSearchControl1.AutoHeight = false;
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            repositoryItemSearchControl1.NullValuePrompt = " ";
            // 
            // treeList1
            // 
            treeList1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            treeList1.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            treeList1.Appearance.HeaderPanel.ForeColor = Color.Navy;
            treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            treeList1.Appearance.HeaderPanel.Options.UseForeColor = true;
            treeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeList1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeList1.Appearance.Row.Font = new Font("Cairo", 9F);
            treeList1.Appearance.Row.Options.UseFont = true;
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colCode, colName, colSortId, colCreatedDate, colCreatedMachine, colUpdateDate, colUpdateMachine, colIsDelete, colDeletionDate, colDeletionMachine, colCreatedBy, colCreated, colUpdateBy, colUpdate, colDeletionBy, colDeletion, colLvlId });
            treeList1.DataSource = itemCategoryBindingSource;
            treeList1.Dock = DockStyle.Fill;
            treeList1.KeyFieldName = "Id";
            treeList1.Location = new Point(0, 30);
            treeList1.MenuManager = barManager1;
            treeList1.Name = "treeList1";
            treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            treeList1.OptionsView.ShowIndicator = false;
            treeList1.OptionsView.ShowRoot = false;
            treeList1.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            treeList1.ParentFieldName = "ParentId";
            treeList1.Size = new Size(459, 623);
            treeList1.TabIndex = 4;
            // 
            // colCode
            // 
            colCode.AppearanceCell.Options.UseTextOptions = true;
            colCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCode.Caption = "الرمز";
            colCode.FieldName = "Code";
            colCode.Name = "colCode";
            colCode.OptionsColumn.AllowEdit = false;
            colCode.OptionsColumn.AllowFocus = false;
            colCode.OptionsColumn.AllowMove = false;
            colCode.OptionsColumn.AllowSize = false;
            colCode.OptionsColumn.FixedWidth = true;
            colCode.Visible = true;
            colCode.VisibleIndex = 0;
            colCode.Width = 104;
            // 
            // colName
            // 
            colName.Caption = "التصنيف";
            colName.FieldName = "Name";
            colName.Name = "colName";
            colName.OptionsColumn.AllowEdit = false;
            colName.OptionsColumn.AllowFocus = false;
            colName.OptionsColumn.AllowMove = false;
            colName.OptionsColumn.FixedWidth = true;
            colName.Visible = true;
            colName.VisibleIndex = 1;
            colName.Width = 338;
            // 
            // colSortId
            // 
            colSortId.Caption = "colSortId";
            colSortId.FieldName = "SortId";
            colSortId.Name = "colSortId";
            colSortId.SortOrder = SortOrder.Ascending;
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
            // colIsDelete
            // 
            colIsDelete.FieldName = "IsDelete";
            colIsDelete.Name = "colIsDelete";
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
            // colCreatedBy
            // 
            colCreatedBy.FieldName = "CreatedBy";
            colCreatedBy.Name = "colCreatedBy";
            // 
            // colCreated
            // 
            colCreated.FieldName = "Created";
            colCreated.Name = "colCreated";
            // 
            // colUpdateBy
            // 
            colUpdateBy.FieldName = "UpdateBy";
            colUpdateBy.Name = "colUpdateBy";
            // 
            // colUpdate
            // 
            colUpdate.FieldName = "Update";
            colUpdate.Name = "colUpdate";
            // 
            // colDeletionBy
            // 
            colDeletionBy.FieldName = "DeletionBy";
            colDeletionBy.Name = "colDeletionBy";
            // 
            // colDeletion
            // 
            colDeletion.FieldName = "Deletion";
            colDeletion.Name = "colDeletion";
            // 
            // colLvlId
            // 
            colLvlId.Caption = "colLvlId";
            colLvlId.FieldName = "LvlId";
            colLvlId.Name = "colLvlId";
            // 
            // itemCategoryBindingSource
            // 
            itemCategoryBindingSource.DataSource = typeof(Core.ItemCategory);
            // 
            // frmItemCategoryAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 677);
            Controls.Add(treeList1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "frmItemCategoryAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "مجموعة الأصناف";
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemCategoryBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraBars.BarButtonItem btnMoveUp;
        private DevExpress.XtraBars.BarButtonItem btnMoveDown;
        private DevExpress.XtraBars.BarButtonItem btnMoveRight;
        private DevExpress.XtraBars.BarButtonItem btnMoveLeft;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCreatedDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCreatedMachine;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUpdateDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUpdateMachine;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDeletionDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDeletionMachine;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCreatedBy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCreated;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUpdateBy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUpdate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDeletionBy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDeletion;
        private BindingSource itemCategoryBindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSortId;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLvlId;
    }
}