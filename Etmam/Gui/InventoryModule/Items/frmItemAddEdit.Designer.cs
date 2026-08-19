namespace Etmam
{
    partial class frmItemAddEdit
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
            txtCode = new DevExpress.XtraEditors.TextEdit();
            txtName = new DevExpress.XtraEditors.TextEdit();
            memDescription = new DevExpress.XtraEditors.MemoEdit();
            lookUpUnit = new DevExpress.XtraEditors.LookUpEdit();
            btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            btnSaveNew = new DevExpress.XtraEditors.SimpleButton();
            btnCategory = new DevExpress.XtraEditors.SimpleButton();
            btnUnit = new DevExpress.XtraEditors.SimpleButton();
            checkActive = new DevExpress.XtraEditors.CheckEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            lookUpCategory = new DevExpress.XtraEditors.TreeListLookUpEdit();
            itemCategoryBindingSource = new BindingSource(components);
            treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            colCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colLvlId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
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
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiImport = new DevExpress.XtraBars.BarButtonItem();
            bbiExport = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            bar3 = new DevExpress.XtraBars.Bar();
            bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpUnit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpCategory.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemCategoryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeListLookUpEdit1TreeList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            SuspendLayout();
            // 
            // txtCode
            // 
            txtCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCode.EditValue = "جديد";
            txtCode.Enabled = false;
            txtCode.Location = new Point(51, 130);
            txtCode.Margin = new Padding(3, 5, 3, 5);
            txtCode.Name = "txtCode";
            txtCode.Properties.Appearance.BackColor = SystemColors.Control;
            txtCode.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtCode.Properties.Appearance.ForeColor = Color.FromArgb(192, 0, 0);
            txtCode.Properties.Appearance.Options.UseBackColor = true;
            txtCode.Properties.Appearance.Options.UseFont = true;
            txtCode.Properties.Appearance.Options.UseForeColor = true;
            txtCode.Properties.Appearance.Options.UseTextOptions = true;
            txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtCode.Size = new Size(337, 30);
            txtCode.TabIndex = 9;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtName.Location = new Point(51, 169);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.BackColor = Color.LightGreen;
            txtName.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtName.Properties.Appearance.Options.UseBackColor = true;
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Size = new Size(337, 30);
            txtName.TabIndex = 10;
            // 
            // memDescription
            // 
            memDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memDescription.Location = new Point(51, 247);
            memDescription.Margin = new Padding(3, 5, 3, 5);
            memDescription.Name = "memDescription";
            memDescription.Properties.Appearance.Font = new Font("Cairo", 9F);
            memDescription.Properties.Appearance.Options.UseFont = true;
            memDescription.Size = new Size(337, 151);
            memDescription.TabIndex = 12;
            // 
            // lookUpUnit
            // 
            lookUpUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpUnit.Location = new Point(51, 208);
            lookUpUnit.Margin = new Padding(3, 5, 3, 5);
            lookUpUnit.Name = "lookUpUnit";
            lookUpUnit.Properties.Appearance.BackColor = Color.LightGreen;
            lookUpUnit.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpUnit.Properties.Appearance.Options.UseBackColor = true;
            lookUpUnit.Properties.Appearance.Options.UseFont = true;
            lookUpUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpUnit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbreviation", "الوحدة") });
            lookUpUnit.Properties.DisplayMember = "Abbreviation";
            lookUpUnit.Properties.NullText = "";
            lookUpUnit.Properties.ShowHeader = false;
            lookUpUnit.Properties.ValueMember = "Id";
            lookUpUnit.Size = new Size(337, 30);
            lookUpUnit.TabIndex = 11;
            // 
            // btnSaveClose
            // 
            btnSaveClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveClose.Appearance.Font = new Font("Cairo", 9F);
            btnSaveClose.Appearance.Options.UseFont = true;
            btnSaveClose.ImageOptions.ImageIndex = 4;
            btnSaveClose.ImageOptions.ImageList = svgImageCollection1;
            btnSaveClose.Location = new Point(50, 433);
            btnSaveClose.Margin = new Padding(3, 5, 3, 5);
            btnSaveClose.Name = "btnSaveClose";
            btnSaveClose.Size = new Size(139, 35);
            btnSaveClose.TabIndex = 13;
            btnSaveClose.Text = "حفظ وإغلاق";
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.ImageSize = new Size(20, 20);
            svgImageCollection1.Add("exporttoxls", "image://svgimages/export/exporttoxls.svg");
            svgImageCollection1.Add("action_export", "image://fluentimages/xaf/action_export.svg");
            svgImageCollection1.Add("next", "image://svgimages/pdf viewer/next.svg");
            svgImageCollection1.Add("saveas", "image://svgimages/save/saveas.svg");
            svgImageCollection1.Add("saveandclose2", "image://svgimages/save/saveandclose2.svg");
            svgImageCollection1.Add("loadchart", "image://svgimages/reports/loadchart.svg");
            svgImageCollection1.Add("open2", "image://svgimages/scheduling/open2.svg");
            svgImageCollection1.Add("up", "image://svgimages/actions/up.svg");
            svgImageCollection1.Add("addfile", "image://svgimages/outlook inspired/addfile.svg");
            // 
            // btnSaveNew
            // 
            btnSaveNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveNew.Appearance.Font = new Font("Cairo", 9F);
            btnSaveNew.Appearance.Options.UseFont = true;
            btnSaveNew.ImageOptions.ImageIndex = 3;
            btnSaveNew.ImageOptions.ImageList = svgImageCollection1;
            btnSaveNew.Location = new Point(195, 433);
            btnSaveNew.Margin = new Padding(3, 5, 3, 5);
            btnSaveNew.Name = "btnSaveNew";
            btnSaveNew.Size = new Size(139, 35);
            btnSaveNew.TabIndex = 14;
            btnSaveNew.Text = "حفظ وجديد";
            // 
            // btnCategory
            // 
            btnCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCategory.ImageOptions.ImageIndex = 2;
            btnCategory.ImageOptions.ImageList = svgImageCollection1;
            btnCategory.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btnCategory.Location = new Point(14, 91);
            btnCategory.Margin = new Padding(3, 5, 3, 5);
            btnCategory.Name = "btnCategory";
            btnCategory.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            btnCategory.Size = new Size(30, 30);
            btnCategory.TabIndex = 15;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnUnit
            // 
            btnUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUnit.ImageOptions.ImageIndex = 2;
            btnUnit.ImageOptions.ImageList = svgImageCollection1;
            btnUnit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btnUnit.Location = new Point(14, 208);
            btnUnit.Margin = new Padding(3, 5, 3, 5);
            btnUnit.Name = "btnUnit";
            btnUnit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            btnUnit.Size = new Size(30, 30);
            btnUnit.TabIndex = 16;
            btnUnit.Click += btnUnit_Click;
            // 
            // checkActive
            // 
            checkActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkActive.Enabled = false;
            checkActive.Location = new Point(294, 57);
            checkActive.Margin = new Padding(3, 5, 3, 5);
            checkActive.Name = "checkActive";
            checkActive.Properties.Appearance.Font = new Font("Cairo", 9F);
            checkActive.Properties.Appearance.Options.UseFont = true;
            checkActive.Properties.Caption = "ترميز تلقائي";
            checkActive.Size = new Size(94, 27);
            checkActive.TabIndex = 17;
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new Font("Cairo", 9F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(403, 95);
            labelControl1.Margin = new Padding(3, 5, 3, 5);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(44, 23);
            labelControl1.TabIndex = 18;
            labelControl1.Text = "التصنيف:";
            // 
            // labelControl2
            // 
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 9F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(403, 134);
            labelControl2.Margin = new Padding(3, 5, 3, 5);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(25, 23);
            labelControl2.TabIndex = 19;
            labelControl2.Text = "الرمز:";
            // 
            // labelControl3
            // 
            labelControl3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl3.Appearance.Font = new Font("Cairo", 9F);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new Point(403, 173);
            labelControl3.Margin = new Padding(3, 5, 3, 5);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(60, 23);
            labelControl3.TabIndex = 20;
            labelControl3.Text = "إسم الصنف:";
            // 
            // labelControl4
            // 
            labelControl4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl4.Appearance.Font = new Font("Cairo", 9F);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new Point(403, 212);
            labelControl4.Margin = new Padding(3, 5, 3, 5);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(36, 23);
            labelControl4.TabIndex = 21;
            labelControl4.Text = "الوحدة:";
            // 
            // labelControl5
            // 
            labelControl5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl5.Appearance.Font = new Font("Cairo", 9F);
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Location = new Point(403, 253);
            labelControl5.Margin = new Padding(3, 5, 3, 5);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(39, 23);
            labelControl5.TabIndex = 22;
            labelControl5.Text = "الوصف:";
            // 
            // lookUpCategory
            // 
            lookUpCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpCategory.Location = new Point(51, 91);
            lookUpCategory.Margin = new Padding(3, 5, 3, 5);
            lookUpCategory.Name = "lookUpCategory";
            lookUpCategory.Properties.Appearance.BackColor = Color.LightGreen;
            lookUpCategory.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpCategory.Properties.Appearance.Options.UseBackColor = true;
            lookUpCategory.Properties.Appearance.Options.UseFont = true;
            lookUpCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpCategory.Properties.DataSource = itemCategoryBindingSource;
            lookUpCategory.Properties.DisplayMember = "Name";
            lookUpCategory.Properties.NullText = "";
            lookUpCategory.Properties.TreeList = treeListLookUpEdit1TreeList;
            lookUpCategory.Properties.ValueMember = "Id";
            lookUpCategory.Size = new Size(337, 30);
            lookUpCategory.TabIndex = 8;
            // 
            // itemCategoryBindingSource
            // 
            itemCategoryBindingSource.DataSource = typeof(Core.ItemCategory);
            // 
            // treeListLookUpEdit1TreeList
            // 
            treeListLookUpEdit1TreeList.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            treeListLookUpEdit1TreeList.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            treeListLookUpEdit1TreeList.Appearance.HeaderPanel.ForeColor = Color.Navy;
            treeListLookUpEdit1TreeList.Appearance.HeaderPanel.Options.UseFont = true;
            treeListLookUpEdit1TreeList.Appearance.HeaderPanel.Options.UseForeColor = true;
            treeListLookUpEdit1TreeList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeListLookUpEdit1TreeList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeListLookUpEdit1TreeList.Appearance.Row.Font = new Font("Cairo", 9F);
            treeListLookUpEdit1TreeList.Appearance.Row.Options.UseFont = true;
            treeListLookUpEdit1TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colCode, colName, colLvlId, colSortId, colCreatedDate, colCreatedMachine, colUpdateDate, colUpdateMachine, colIsDelete, colDeletionDate, colDeletionMachine, colCreatedBy, colCreated, colUpdateBy, colUpdate, colDeletionBy, colDeletion });
            treeListLookUpEdit1TreeList.KeyFieldName = "Id";
            treeListLookUpEdit1TreeList.Location = new Point(0, 0);
            treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            treeListLookUpEdit1TreeList.OptionsFind.AlwaysVisible = true;
            treeListLookUpEdit1TreeList.OptionsFind.FindFilterColumns = "Code;Name";
            treeListLookUpEdit1TreeList.OptionsFind.FindNullPrompt = "بحث...";
            treeListLookUpEdit1TreeList.OptionsFind.HighlightFindResults = true;
            treeListLookUpEdit1TreeList.OptionsView.ShowButtons = true;
            treeListLookUpEdit1TreeList.OptionsView.ShowIndicator = false;
            treeListLookUpEdit1TreeList.OptionsView.ShowRoot = false;
            treeListLookUpEdit1TreeList.ParentFieldName = "ParentId";
            treeListLookUpEdit1TreeList.Size = new Size(480, 260);
            treeListLookUpEdit1TreeList.TabIndex = 0;
            //
            // colCode
            //
            colCode.Caption = "الرمز";
            colCode.FieldName = "Code";
            colCode.Name = "colCode";
            colCode.Visible = true;
            colCode.VisibleIndex = 1;
            colCode.Width = 150;
            //
            // colName
            //
            colName.Caption = "إسم المجموعه";
            colName.FieldName = "Name";
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 0;
            colName.Width = 280;
            // 
            // colLvlId
            // 
            colLvlId.FieldName = "LvlId";
            colLvlId.Name = "colLvlId";
            // 
            // colSortId
            //
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
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiImport, bbiExport });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 11;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemSearchControl1 });
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
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
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiImport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MinHeight = 30;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // bbiImport
            // 
            bbiImport.Caption = "إستيراد";
            bbiImport.Id = 0;
            bbiImport.ImageOptions.ImageIndex = 0;
            bbiImport.Name = "bbiImport";
            bbiImport.ItemClick += bbiImport_ItemClick;
            // 
            // bbiExport
            // 
            bbiExport.Caption = "تصدير";
            bbiExport.Id = 1;
            bbiExport.ImageOptions.ImageIndex = 1;
            bbiExport.Name = "bbiExport";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Margin = new Padding(3, 5, 3, 5);
            barDockControlTop.Size = new Size(478, 32);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 498);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(478, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 32);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 466);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(478, 32);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 466);
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
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // bar1
            // 
            bar1.BarName = "Custom 4";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Right;
            bar1.OptionsBar.AllowCollapse = true;
            bar1.OptionsBar.AllowDelete = true;
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Custom 4";
            // 
            // frmItemAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 498);
            Controls.Add(labelControl5);
            Controls.Add(labelControl4);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(checkActive);
            Controls.Add(btnUnit);
            Controls.Add(btnCategory);
            Controls.Add(btnSaveNew);
            Controls.Add(btnSaveClose);
            Controls.Add(txtCode);
            Controls.Add(txtName);
            Controls.Add(memDescription);
            Controls.Add(lookUpUnit);
            Controls.Add(lookUpCategory);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 5, 3, 5);
            MaximizeBox = false;
            Name = "frmItemAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة/ تعديل صنف";
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpUnit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpCategory.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemCategoryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeListLookUpEdit1TreeList).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.MemoEdit memDescription;
        private DevExpress.XtraEditors.LookUpEdit lookUpUnit;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveNew;
        private DevExpress.XtraEditors.SimpleButton btnCategory;
        private DevExpress.XtraEditors.SimpleButton btnUnit;
        private DevExpress.XtraEditors.CheckEdit checkActive;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.TreeListLookUpEdit lookUpCategory;
        private BindingSource itemCategoryBindingSource;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLvlId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSortId;
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
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiImport;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar1;
    }
}