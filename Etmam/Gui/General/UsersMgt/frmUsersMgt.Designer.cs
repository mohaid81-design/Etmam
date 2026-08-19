namespace Etmam
{
    partial class frmUsersMgt
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
            nfData = new DevExpress.XtraBars.Navigation.NavigationFrame();
            npMain = new DevExpress.XtraBars.Navigation.NavigationPage();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            usersListBindingSource = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            colJobTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            colPhoneNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            npUsersDataEntry = new DevExpress.XtraBars.Navigation.NavigationPage();
            labelControl7 = new DevExpress.XtraEditors.LabelControl();
            txtCompany = new DevExpress.XtraEditors.TextEdit();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            txtUserName = new DevExpress.XtraEditors.TextEdit();
            labelControl8 = new DevExpress.XtraEditors.LabelControl();
            txtPhoneNumber = new DevExpress.XtraEditors.TextEdit();
            txtJobTitel = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            txtName = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            txtRePassword = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            npPermissions = new DevExpress.XtraBars.Navigation.NavigationPage();
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            colUserIDProcess = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPermsID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPermsDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPermsStatusProcess = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colIDParentProcess = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            treeList2 = new DevExpress.XtraTreeList.TreeList();
            colUserIDPrj = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPrjId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPrjName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPermsStatusPrj = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colIDParentPrj = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            treeList3 = new DevExpress.XtraTreeList.TreeList();
            colUserIDStore = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colStoreId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colStoreName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPermsStatusStore = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colCanReceiveStore = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCanIssueStore = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCanTransferStore = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colIdParentStore = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            treeList4 = new DevExpress.XtraTreeList.TreeList();
            colUserIDWorkflow = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colWorkflowId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colWorkflowName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPermsStatusWorkflow = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colIDParentWorkflow = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            lookUpUser = new DevExpress.XtraEditors.LookUpEdit();
            npSign = new DevExpress.XtraBars.Navigation.NavigationPage();
            btnDeleteSign = new DevExpress.XtraEditors.SimpleButton();
            pboxSignature = new PictureBox();
            nfButton = new DevExpress.XtraBars.Navigation.NavigationFrame();
            navigationPage3 = new DevExpress.XtraBars.Navigation.NavigationPage();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            btnDeleteUser = new DevExpress.XtraEditors.SimpleButton();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            btnSign = new DevExpress.XtraEditors.SimpleButton();
            btnPermissions = new DevExpress.XtraEditors.SimpleButton();
            btnNewUser = new DevExpress.XtraEditors.SimpleButton();
            btnUserStatus = new DevExpress.XtraEditors.SimpleButton();
            btnEditPassword = new DevExpress.XtraEditors.SimpleButton();
            btnEditUser = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            navigationPage4 = new DevExpress.XtraBars.Navigation.NavigationPage();
            layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            btnExpandedCollapse = new DevExpress.XtraEditors.SimpleButton();
            btnReturn = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            lookUpEditCountryCode = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)nfData).BeginInit();
            nfData.SuspendLayout();
            npMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usersListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).BeginInit();
            npUsersDataEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCompany.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhoneNumber.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtJobTitel.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRePassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            npPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).BeginInit();
            xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeList2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit2).BeginInit();
            xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeList3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit3).BeginInit();
            xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeList4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpUser.Properties).BeginInit();
            npSign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pboxSignature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nfButton).BeginInit();
            nfButton.SuspendLayout();
            navigationPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            navigationPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl2).BeginInit();
            layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lookUpEditCountryCode.Properties).BeginInit();
            SuspendLayout();
            // 
            // nfData
            // 
            nfData.Controls.Add(npMain);
            nfData.Controls.Add(npUsersDataEntry);
            nfData.Controls.Add(npPermissions);
            nfData.Controls.Add(npSign);
            nfData.Dock = DockStyle.Fill;
            nfData.Font = new Font("Cairo", 8.5F);
            nfData.Location = new Point(0, 0);
            nfData.Margin = new Padding(3, 2, 3, 2);
            nfData.Name = "nfData";
            nfData.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { npMain, npUsersDataEntry, npPermissions, npSign });
            nfData.SelectedPage = npMain;
            nfData.Size = new Size(931, 625);
            nfData.TabIndex = 0;
            nfData.Text = "nfData";
            nfData.TransitionAnimationProperties.FrameCount = 100;
            nfData.TransitionAnimationProperties.FrameInterval = 1000;
            nfData.TransitionType = DevExpress.Utils.Animation.Transitions.Fade;
            // 
            // npMain
            // 
            npMain.Caption = "npMain";
            npMain.Controls.Add(gridControl1);
            npMain.Margin = new Padding(3, 2, 3, 2);
            npMain.Name = "npMain";
            npMain.Size = new Size(931, 625);
            // 
            // gridControl1
            // 
            gridControl1.DataSource = usersListBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.EmbeddedNavigator.Margin = new Padding(2, 1, 2, 1);
            gridControl1.Location = new Point(0, 0);
            gridControl1.MainView = gridView1;
            gridControl1.Margin = new Padding(2);
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemComboBox1 });
            gridControl1.Size = new Size(931, 625);
            gridControl1.TabIndex = 6;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // usersListBindingSource
            // 
            usersListBindingSource.DataSource = typeof(Core.UsersList);
            // 
            // gridView1
            // 
            gridView1.Appearance.ColumnFilterButton.Options.UseTextOptions = true;
            gridView1.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.ColumnFilterButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new Font("Cairo", 9F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colUserName, colFullName, colJobTitle, colCompany, colPhoneNumber, colPassword, colRole, colIsActive, colIsDelete, colCreatedBy, colCreatedDate, colCreatedMachine });
            gridView1.DetailHeight = 131;
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.OptionsEditForm.PopupEditFormWidth = 441;
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.MinWidth = 17;
            colId.Name = "colId";
            colId.Width = 64;
            // 
            // colUserName
            // 
            colUserName.AppearanceCell.Options.UseTextOptions = true;
            colUserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            colUserName.Caption = "حساب الدخول";
            colUserName.FieldName = "UserName";
            colUserName.MinWidth = 17;
            colUserName.Name = "colUserName";
            colUserName.OptionsColumn.AllowEdit = false;
            colUserName.OptionsColumn.AllowFocus = false;
            colUserName.Visible = true;
            colUserName.VisibleIndex = 0;
            colUserName.Width = 202;
            // 
            // colFullName
            // 
            colFullName.Caption = "إسم المستخدم";
            colFullName.FieldName = "FullName";
            colFullName.MinWidth = 17;
            colFullName.Name = "colFullName";
            colFullName.OptionsColumn.AllowEdit = false;
            colFullName.OptionsColumn.AllowFocus = false;
            colFullName.Visible = true;
            colFullName.VisibleIndex = 1;
            colFullName.Width = 150;
            // 
            // colJobTitle
            // 
            colJobTitle.Caption = "الوصف الوظيفي";
            colJobTitle.FieldName = "JobTitle";
            colJobTitle.MinWidth = 17;
            colJobTitle.Name = "colJobTitle";
            colJobTitle.OptionsColumn.AllowEdit = false;
            colJobTitle.OptionsColumn.AllowFocus = false;
            colJobTitle.Visible = true;
            colJobTitle.VisibleIndex = 2;
            colJobTitle.Width = 145;
            // 
            // colCompany
            // 
            colCompany.Caption = "إسم الشركة";
            colCompany.FieldName = "Company";
            colCompany.MinWidth = 17;
            colCompany.Name = "colCompany";
            colCompany.OptionsColumn.AllowEdit = false;
            colCompany.OptionsColumn.AllowFocus = false;
            colCompany.Visible = true;
            colCompany.VisibleIndex = 3;
            colCompany.Width = 135;
            // 
            // colPhoneNumber
            // 
            colPhoneNumber.Caption = "رقم الهاتف";
            colPhoneNumber.FieldName = "PhoneNumber";
            colPhoneNumber.MinWidth = 17;
            colPhoneNumber.Name = "colPhoneNumber";
            colPhoneNumber.OptionsColumn.AllowEdit = false;
            colPhoneNumber.OptionsColumn.AllowFocus = false;
            colPhoneNumber.Width = 120;
            // 
            // colPassword
            // 
            colPassword.FieldName = "Password";
            colPassword.MinWidth = 17;
            colPassword.Name = "colPassword";
            colPassword.Width = 64;
            // 
            // colRole
            // 
            colRole.Caption = "التصنيف";
            colRole.ColumnEdit = repositoryItemComboBox1;
            colRole.FieldName = "Role";
            colRole.MinWidth = 17;
            colRole.Name = "colRole";
            colRole.OptionsColumn.AllowEdit = false;
            colRole.OptionsColumn.AllowFocus = false;
            colRole.Visible = true;
            colRole.VisibleIndex = 4;
            colRole.Width = 80;
            // 
            // repositoryItemComboBox1
            // 
            repositoryItemComboBox1.AutoHeight = false;
            repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox1.Items.AddRange(new object[] { "Admin", "User", "Guest" });
            repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // colIsActive
            // 
            colIsActive.Caption = "هل الحساب نشط";
            colIsActive.FieldName = "IsActive";
            colIsActive.MinWidth = 17;
            colIsActive.Name = "colIsActive";
            colIsActive.OptionsColumn.AllowEdit = false;
            colIsActive.OptionsColumn.AllowFocus = false;
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 5;
            colIsActive.Width = 100;
            // 
            // colIsDelete
            // 
            colIsDelete.FieldName = "IsDelete";
            colIsDelete.MinWidth = 17;
            colIsDelete.Name = "colIsDelete";
            colIsDelete.Width = 64;
            // 
            // colCreatedBy
            // 
            colCreatedBy.FieldName = "CreatedBy";
            colCreatedBy.MinWidth = 17;
            colCreatedBy.Name = "colCreatedBy";
            colCreatedBy.Width = 64;
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.MinWidth = 17;
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.Width = 64;
            // 
            // colCreatedMachine
            // 
            colCreatedMachine.FieldName = "CreatedMachine";
            colCreatedMachine.MinWidth = 17;
            colCreatedMachine.Name = "colCreatedMachine";
            colCreatedMachine.Width = 64;
            // 
            // npUsersDataEntry
            // 
            npUsersDataEntry.Caption = "npUserDataEntery";
            npUsersDataEntry.Controls.Add(lookUpEditCountryCode);
            npUsersDataEntry.Controls.Add(labelControl7);
            npUsersDataEntry.Controls.Add(txtCompany);
            npUsersDataEntry.Controls.Add(labelControl6);
            npUsersDataEntry.Controls.Add(txtUserName);
            npUsersDataEntry.Controls.Add(labelControl8);
            npUsersDataEntry.Controls.Add(txtPhoneNumber);
            npUsersDataEntry.Controls.Add(txtJobTitel);
            npUsersDataEntry.Controls.Add(labelControl4);
            npUsersDataEntry.Controls.Add(txtName);
            npUsersDataEntry.Controls.Add(labelControl1);
            npUsersDataEntry.Controls.Add(txtRePassword);
            npUsersDataEntry.Controls.Add(labelControl2);
            npUsersDataEntry.Controls.Add(labelControl3);
            npUsersDataEntry.Controls.Add(txtPassword);
            npUsersDataEntry.Margin = new Padding(3, 2, 3, 2);
            npUsersDataEntry.Name = "npUsersDataEntry";
            npUsersDataEntry.Size = new Size(931, 625);
            // 
            // labelControl7
            // 
            labelControl7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl7.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl7.Appearance.Options.UseFont = true;
            labelControl7.Location = new Point(804, 173);
            labelControl7.Margin = new Padding(2, 1, 2, 1);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new Size(61, 23);
            labelControl7.TabIndex = 62;
            labelControl7.Text = "إسم الشركة:";
            // 
            // txtCompany
            // 
            txtCompany.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCompany.DataBindings.Add(new Binding("EditValue", usersListBindingSource, "Company", true));
            txtCompany.Location = new Point(548, 169);
            txtCompany.Margin = new Padding(2, 1, 2, 1);
            txtCompany.Name = "txtCompany";
            txtCompany.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtCompany.Properties.Appearance.Options.UseFont = true;
            txtCompany.Properties.AutoHeight = false;
            txtCompany.Size = new Size(248, 30);
            txtCompany.TabIndex = 61;
            // 
            // labelControl6
            // 
            labelControl6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl6.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Location = new Point(804, 208);
            labelControl6.Margin = new Padding(2, 1, 2, 1);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new Size(94, 23);
            labelControl6.TabIndex = 60;
            labelControl6.Text = "إسم حساب الدخول:";
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUserName.DataBindings.Add(new Binding("EditValue", usersListBindingSource, "UserName", true));
            txtUserName.Location = new Point(548, 204);
            txtUserName.Margin = new Padding(2, 1, 2, 1);
            txtUserName.Name = "txtUserName";
            txtUserName.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtUserName.Properties.Appearance.Options.UseFont = true;
            txtUserName.Properties.AutoHeight = false;
            txtUserName.Size = new Size(248, 30);
            txtUserName.TabIndex = 59;
            // 
            // labelControl8
            // 
            labelControl8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl8.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl8.Appearance.Options.UseFont = true;
            labelControl8.Location = new Point(804, 243);
            labelControl8.Margin = new Padding(2, 1, 2, 1);
            labelControl8.Name = "labelControl8";
            labelControl8.Size = new Size(58, 23);
            labelControl8.TabIndex = 63;
            labelControl8.Text = "رقم الهاتف:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPhoneNumber.Location = new Point(630, 239);
            txtPhoneNumber.Margin = new Padding(2, 1, 2, 1);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtPhoneNumber.Properties.Appearance.Options.UseFont = true;
            txtPhoneNumber.Properties.AutoHeight = false;
            txtPhoneNumber.Size = new Size(166, 30);
            txtPhoneNumber.TabIndex = 64;
            // 
            // txtJobTitel
            // 
            txtJobTitel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtJobTitel.DataBindings.Add(new Binding("EditValue", usersListBindingSource, "JobTitle", true));
            txtJobTitel.Location = new Point(548, 62);
            txtJobTitel.Margin = new Padding(2, 1, 2, 1);
            txtJobTitel.Name = "txtJobTitel";
            txtJobTitel.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtJobTitel.Properties.Appearance.Options.UseFont = true;
            txtJobTitel.Properties.AutoHeight = false;
            txtJobTitel.Size = new Size(248, 30);
            txtJobTitel.TabIndex = 58;
            // 
            // labelControl4
            // 
            labelControl4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl4.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new Point(804, 138);
            labelControl4.Margin = new Padding(2, 1, 2, 1);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(110, 23);
            labelControl4.TabIndex = 57;
            labelControl4.Text = "إعادة كتابه كلمة السر:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtName.DataBindings.Add(new Binding("EditValue", usersListBindingSource, "FullName", true));
            txtName.EditValue = "";
            txtName.Location = new Point(548, 26);
            txtName.Margin = new Padding(2, 1, 2, 1);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.BackColor = Color.White;
            txtName.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtName.Properties.Appearance.Options.UseBackColor = true;
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Properties.AutoHeight = false;
            txtName.Size = new Size(248, 30);
            txtName.TabIndex = 52;
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(804, 30);
            labelControl1.Margin = new Padding(2, 1, 2, 1);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(76, 23);
            labelControl1.TabIndex = 51;
            labelControl1.Text = "إسم المستخدم:";
            // 
            // txtRePassword
            // 
            txtRePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRePassword.Location = new Point(548, 134);
            txtRePassword.Margin = new Padding(2, 1, 2, 1);
            txtRePassword.Name = "txtRePassword";
            txtRePassword.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtRePassword.Properties.Appearance.Options.UseFont = true;
            txtRePassword.Properties.AutoHeight = false;
            txtRePassword.Properties.PasswordChar = '*';
            txtRePassword.Size = new Size(248, 30);
            txtRePassword.TabIndex = 56;
            // 
            // labelControl2
            // 
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(804, 66);
            labelControl2.Margin = new Padding(2, 1, 2, 1);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(85, 23);
            labelControl2.TabIndex = 53;
            labelControl2.Text = "وصف المستخدم:";
            // 
            // labelControl3
            // 
            labelControl3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl3.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new Point(804, 102);
            labelControl3.Margin = new Padding(2, 1, 2, 1);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(52, 23);
            labelControl3.TabIndex = 55;
            labelControl3.Text = "كلمة السر:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPassword.DataBindings.Add(new Binding("EditValue", usersListBindingSource, "Password", true));
            txtPassword.Location = new Point(548, 98);
            txtPassword.Margin = new Padding(2, 1, 2, 1);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.AutoHeight = false;
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Size = new Size(248, 30);
            txtPassword.TabIndex = 54;
            // 
            // npPermissions
            // 
            npPermissions.Caption = "npPermissions";
            npPermissions.Controls.Add(xtraTabControl1);
            npPermissions.Controls.Add(labelControl5);
            npPermissions.Controls.Add(lookUpUser);
            npPermissions.Margin = new Padding(3, 2, 3, 2);
            npPermissions.Name = "npPermissions";
            npPermissions.Size = new Size(931, 625);
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.Appearance.Font = new Font("Cairo", 8.5F);
            xtraTabControl1.Appearance.Options.UseFont = true;
            xtraTabControl1.AppearancePage.Header.Font = new Font("Cairo", 8.5F);
            xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            xtraTabControl1.AppearancePage.HeaderActive.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
            xtraTabControl1.Dock = DockStyle.Bottom;
            xtraTabControl1.Location = new Point(0, 95);
            xtraTabControl1.Margin = new Padding(3, 2, 3, 2);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabControl1.Size = new Size(931, 530);
            xtraTabControl1.TabIndex = 46;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2, xtraTabPage3, xtraTabPage4 });
            xtraTabControl1.TabPageWidth = 100;
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(treeList1);
            xtraTabPage1.Margin = new Padding(3, 2, 3, 2);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new Size(929, 491);
            xtraTabPage1.Text = "الإجراءات";
            // 
            // treeList1
            // 
            treeList1.Appearance.HeaderPanel.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            treeList1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            treeList1.Appearance.HeaderPanel.Options.UseForeColor = true;
            treeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeList1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeList1.Appearance.Row.Font = new Font("Cairo", 8.5F);
            treeList1.Appearance.Row.Options.UseFont = true;
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colUserIDProcess, colPermsID, colPermsDescription, colPermsStatusProcess, colIDParentProcess });
            treeList1.Dock = DockStyle.Fill;
            treeList1.FixedLineWidth = 1;
            treeList1.Font = new Font("Cairo", 8.5F);
            treeList1.HorzScrollStep = 2;
            treeList1.IndicatorWidth = 15;
            treeList1.KeyFieldName = "";
            treeList1.Location = new Point(0, 0);
            treeList1.Margin = new Padding(2);
            treeList1.MinWidth = 16;
            treeList1.Name = "treeList1";
            treeList1.OptionsView.AutoWidth = false;
            treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            treeList1.OptionsView.ShowIndicator = false;
            treeList1.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            treeList1.ParentFieldName = "";
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit1 });
            treeList1.RowHeight = 14;
            treeList1.Size = new Size(929, 491);
            treeList1.TabIndex = 42;
            treeList1.TreeLevelWidth = 12;
            // 
            // colUserIDProcess
            // 
            colUserIDProcess.Caption = "UserID";
            colUserIDProcess.FieldName = "UserID";
            colUserIDProcess.MinWidth = 16;
            colUserIDProcess.Name = "colUserIDProcess";
            colUserIDProcess.Width = 41;
            // 
            // colPermsID
            // 
            colPermsID.Caption = "PermsID";
            colPermsID.FieldName = "Id";
            colPermsID.MinWidth = 16;
            colPermsID.Name = "colPermsID";
            colPermsID.Width = 41;
            // 
            // colPermsDescription
            // 
            colPermsDescription.Caption = "وصف الإجراء";
            colPermsDescription.FieldName = "Description";
            colPermsDescription.MinWidth = 16;
            colPermsDescription.Name = "colPermsDescription";
            colPermsDescription.OptionsColumn.AllowEdit = false;
            colPermsDescription.OptionsColumn.AllowFocus = false;
            colPermsDescription.Visible = true;
            colPermsDescription.VisibleIndex = 1;
            colPermsDescription.Width = 300;
            // 
            // colPermsStatusProcess
            // 
            colPermsStatusProcess.Caption = "الحالة";
            colPermsStatusProcess.ColumnEdit = repositoryItemCheckEdit1;
            colPermsStatusProcess.FieldName = "PermsStatus";
            colPermsStatusProcess.MinWidth = 16;
            colPermsStatusProcess.Name = "colPermsStatusProcess";
            colPermsStatusProcess.Visible = true;
            colPermsStatusProcess.VisibleIndex = 0;
            colPermsStatusProcess.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colIDParentProcess
            // 
            colIDParentProcess.Caption = "IDParent";
            colIDParentProcess.FieldName = "IdParent";
            colIDParentProcess.MinWidth = 16;
            colIDParentProcess.Name = "colIDParentProcess";
            colIDParentProcess.Width = 41;
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Controls.Add(treeList2);
            xtraTabPage2.Margin = new Padding(3, 2, 3, 2);
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new Size(927, 495);
            xtraTabPage2.Text = "المشروعات";
            // 
            // treeList2
            // 
            treeList2.Appearance.HeaderPanel.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            treeList2.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            treeList2.Appearance.HeaderPanel.Options.UseFont = true;
            treeList2.Appearance.HeaderPanel.Options.UseForeColor = true;
            treeList2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeList2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeList2.Appearance.Row.Font = new Font("Cairo", 8.5F);
            treeList2.Appearance.Row.Options.UseFont = true;
            treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colUserIDPrj, colPrjId, colPrjName, colPermsStatusPrj, colIDParentPrj });
            treeList2.Dock = DockStyle.Fill;
            treeList2.FixedLineWidth = 1;
            treeList2.Font = new Font("Cairo", 8.5F);
            treeList2.HorzScrollStep = 2;
            treeList2.IndicatorWidth = 15;
            treeList2.KeyFieldName = "";
            treeList2.Location = new Point(0, 0);
            treeList2.Margin = new Padding(2);
            treeList2.MinWidth = 16;
            treeList2.Name = "treeList2";
            treeList2.OptionsView.AutoWidth = false;
            treeList2.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            treeList2.OptionsView.ShowIndicator = false;
            treeList2.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            treeList2.ParentFieldName = "";
            treeList2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit2 });
            treeList2.RowHeight = 14;
            treeList2.Size = new Size(927, 495);
            treeList2.TabIndex = 43;
            treeList2.TreeLevelWidth = 12;
            // 
            // colUserIDPrj
            // 
            colUserIDPrj.Caption = "UserID";
            colUserIDPrj.FieldName = "UserID";
            colUserIDPrj.MinWidth = 16;
            colUserIDPrj.Name = "colUserIDPrj";
            colUserIDPrj.Width = 41;
            // 
            // colPrjId
            // 
            colPrjId.Caption = "PermsID";
            colPrjId.FieldName = "Id";
            colPrjId.MinWidth = 16;
            colPrjId.Name = "colPrjId";
            colPrjId.Width = 41;
            // 
            // colPrjName
            // 
            colPrjName.Caption = "إسم المشروع";
            colPrjName.FieldName = "Name";
            colPrjName.MinWidth = 16;
            colPrjName.Name = "colPrjName";
            colPrjName.OptionsColumn.AllowEdit = false;
            colPrjName.OptionsColumn.AllowFocus = false;
            colPrjName.Visible = true;
            colPrjName.VisibleIndex = 1;
            colPrjName.Width = 300;
            // 
            // colPermsStatusPrj
            // 
            colPermsStatusPrj.Caption = "الحالة";
            colPermsStatusPrj.ColumnEdit = repositoryItemCheckEdit2;
            colPermsStatusPrj.FieldName = "PermsStatus";
            colPermsStatusPrj.MinWidth = 16;
            colPermsStatusPrj.Name = "colPermsStatusPrj";
            colPermsStatusPrj.Visible = true;
            colPermsStatusPrj.VisibleIndex = 0;
            colPermsStatusPrj.Width = 80;
            // 
            // repositoryItemCheckEdit2
            // 
            repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colIDParentPrj
            // 
            colIDParentPrj.Caption = "IDParent";
            colIDParentPrj.FieldName = "IdParent";
            colIDParentPrj.MinWidth = 16;
            colIDParentPrj.Name = "colIDParentPrj";
            colIDParentPrj.Width = 41;
            // 
            // xtraTabPage3
            // 
            xtraTabPage3.Controls.Add(treeList3);
            xtraTabPage3.Margin = new Padding(3, 2, 3, 2);
            xtraTabPage3.Name = "xtraTabPage3";
            xtraTabPage3.Size = new Size(927, 495);
            xtraTabPage3.Text = "المخازن";
            // 
            // treeList3
            // 
            treeList3.Appearance.HeaderPanel.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            treeList3.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            treeList3.Appearance.HeaderPanel.Options.UseFont = true;
            treeList3.Appearance.HeaderPanel.Options.UseForeColor = true;
            treeList3.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeList3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeList3.Appearance.Row.Font = new Font("Cairo", 8.5F);
            treeList3.Appearance.Row.Options.UseFont = true;
            treeList3.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colUserIDStore, colStoreId, colStoreName, colPermsStatusStore, colCanReceiveStore, colCanIssueStore, colCanTransferStore, colIdParentStore });
            treeList3.Dock = DockStyle.Fill;
            treeList3.FixedLineWidth = 1;
            treeList3.Font = new Font("Cairo", 8.5F);
            treeList3.HorzScrollStep = 2;
            treeList3.IndicatorWidth = 15;
            treeList3.KeyFieldName = "";
            treeList3.Location = new Point(0, 0);
            treeList3.Margin = new Padding(2);
            treeList3.MinWidth = 16;
            treeList3.Name = "treeList3";
            treeList3.OptionsView.AutoWidth = false;
            treeList3.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            treeList3.OptionsView.ShowIndicator = false;
            treeList3.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            treeList3.ParentFieldName = "";
            treeList3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit3 });
            treeList3.RowHeight = 14;
            treeList3.Size = new Size(927, 495);
            treeList3.TabIndex = 43;
            treeList3.TreeLevelWidth = 12;
            // 
            // colUserIDStore
            // 
            colUserIDStore.Caption = "UserID";
            colUserIDStore.FieldName = "UserID";
            colUserIDStore.MinWidth = 16;
            colUserIDStore.Name = "colUserIDStore";
            colUserIDStore.Width = 41;
            // 
            // colStoreId
            // 
            colStoreId.Caption = "PermsID";
            colStoreId.FieldName = "Id";
            colStoreId.MinWidth = 16;
            colStoreId.Name = "colStoreId";
            colStoreId.Width = 41;
            // 
            // colStoreName
            // 
            colStoreName.Caption = "إسم المخزن";
            colStoreName.FieldName = "Name";
            colStoreName.MinWidth = 16;
            colStoreName.Name = "colStoreName";
            colStoreName.OptionsColumn.AllowEdit = false;
            colStoreName.OptionsColumn.AllowFocus = false;
            colStoreName.Visible = true;
            colStoreName.VisibleIndex = 1;
            colStoreName.Width = 300;
            // 
            // colPermsStatusStore
            // 
            colPermsStatusStore.Caption = "عرض";
            colPermsStatusStore.ColumnEdit = repositoryItemCheckEdit3;
            colPermsStatusStore.FieldName = "PermsStatus";
            colPermsStatusStore.MinWidth = 16;
            colPermsStatusStore.Name = "colPermsStatusStore";
            colPermsStatusStore.Visible = true;
            colPermsStatusStore.VisibleIndex = 0;
            colPermsStatusStore.Width = 80;
            // 
            // repositoryItemCheckEdit3
            // 
            repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // colCanReceiveStore
            // 
            colCanReceiveStore.Caption = "استلام";
            colCanReceiveStore.ColumnEdit = repositoryItemCheckEdit3;
            colCanReceiveStore.FieldName = "CanReceive";
            colCanReceiveStore.MinWidth = 16;
            colCanReceiveStore.Name = "colCanReceiveStore";
            colCanReceiveStore.Visible = true;
            colCanReceiveStore.VisibleIndex = 2;
            colCanReceiveStore.Width = 55;
            // 
            // colCanIssueStore
            // 
            colCanIssueStore.Caption = "صرف";
            colCanIssueStore.ColumnEdit = repositoryItemCheckEdit3;
            colCanIssueStore.FieldName = "CanIssue";
            colCanIssueStore.MinWidth = 16;
            colCanIssueStore.Name = "colCanIssueStore";
            colCanIssueStore.Visible = true;
            colCanIssueStore.VisibleIndex = 3;
            colCanIssueStore.Width = 55;
            // 
            // colCanTransferStore
            // 
            colCanTransferStore.Caption = "تحويل";
            colCanTransferStore.ColumnEdit = repositoryItemCheckEdit3;
            colCanTransferStore.FieldName = "CanTransfer";
            colCanTransferStore.MinWidth = 16;
            colCanTransferStore.Name = "colCanTransferStore";
            colCanTransferStore.Visible = true;
            colCanTransferStore.VisibleIndex = 4;
            colCanTransferStore.Width = 55;
            // 
            // colIdParentStore
            // 
            colIdParentStore.Caption = "IDParent";
            colIdParentStore.FieldName = "IdParent";
            colIdParentStore.MinWidth = 16;
            colIdParentStore.Name = "colIdParentStore";
            colIdParentStore.Width = 41;
            // 
            // xtraTabPage4
            // 
            xtraTabPage4.Controls.Add(treeList4);
            xtraTabPage4.Margin = new Padding(3, 2, 3, 2);
            xtraTabPage4.Name = "xtraTabPage4";
            xtraTabPage4.Size = new Size(927, 495);
            xtraTabPage4.Text = "إجراءات سير العمل";
            // 
            // treeList4
            // 
            treeList4.Appearance.HeaderPanel.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            treeList4.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            treeList4.Appearance.HeaderPanel.Options.UseFont = true;
            treeList4.Appearance.HeaderPanel.Options.UseForeColor = true;
            treeList4.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeList4.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeList4.Appearance.Row.Font = new Font("Cairo", 8.5F);
            treeList4.Appearance.Row.Options.UseFont = true;
            treeList4.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colUserIDWorkflow, colWorkflowId, colWorkflowName, colPermsStatusWorkflow, colIDParentWorkflow });
            treeList4.Dock = DockStyle.Fill;
            treeList4.FixedLineWidth = 1;
            treeList4.Font = new Font("Cairo", 8.5F);
            treeList4.HorzScrollStep = 2;
            treeList4.IndicatorWidth = 15;
            treeList4.KeyFieldName = "";
            treeList4.Location = new Point(0, 0);
            treeList4.Margin = new Padding(2);
            treeList4.MinWidth = 16;
            treeList4.Name = "treeList4";
            treeList4.OptionsView.AutoWidth = false;
            treeList4.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            treeList4.OptionsView.ShowIndicator = false;
            treeList4.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            treeList4.ParentFieldName = "";
            treeList4.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit4 });
            treeList4.RowHeight = 14;
            treeList4.Size = new Size(927, 495);
            treeList4.TabIndex = 44;
            treeList4.TreeLevelWidth = 12;
            // 
            // colUserIDWorkflow
            // 
            colUserIDWorkflow.Caption = "UserID";
            colUserIDWorkflow.FieldName = "UserID";
            colUserIDWorkflow.MinWidth = 16;
            colUserIDWorkflow.Name = "colUserIDWorkflow";
            colUserIDWorkflow.Width = 41;
            // 
            // colWorkflowId
            // 
            colWorkflowId.Caption = "PermsID";
            colWorkflowId.FieldName = "Id";
            colWorkflowId.MinWidth = 16;
            colWorkflowId.Name = "colWorkflowId";
            colWorkflowId.Width = 41;
            // 
            // colWorkflowName
            // 
            colWorkflowName.Caption = "اسم الإجراء";
            colWorkflowName.FieldName = "Name";
            colWorkflowName.MinWidth = 16;
            colWorkflowName.Name = "colWorkflowName";
            colWorkflowName.OptionsColumn.AllowEdit = false;
            colWorkflowName.OptionsColumn.AllowFocus = false;
            colWorkflowName.Visible = true;
            colWorkflowName.VisibleIndex = 1;
            colWorkflowName.Width = 300;
            // 
            // colPermsStatusWorkflow
            // 
            colPermsStatusWorkflow.Caption = "الحالة";
            colPermsStatusWorkflow.ColumnEdit = repositoryItemCheckEdit4;
            colPermsStatusWorkflow.FieldName = "PermsStatus";
            colPermsStatusWorkflow.MinWidth = 16;
            colPermsStatusWorkflow.Name = "colPermsStatusWorkflow";
            colPermsStatusWorkflow.Visible = true;
            colPermsStatusWorkflow.VisibleIndex = 0;
            colPermsStatusWorkflow.Width = 80;
            // 
            // repositoryItemCheckEdit4
            // 
            repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // colIDParentWorkflow
            // 
            colIDParentWorkflow.Caption = "IDParent";
            colIDParentWorkflow.FieldName = "IdParent";
            colIDParentWorkflow.MinWidth = 16;
            colIDParentWorkflow.Name = "colIDParentWorkflow";
            colIDParentWorkflow.Width = 41;
            // 
            // labelControl5
            // 
            labelControl5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl5.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Location = new Point(843, 18);
            labelControl5.Margin = new Padding(2);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(76, 23);
            labelControl5.TabIndex = 45;
            labelControl5.Text = "إسم المستخدم:";
            // 
            // lookUpUser
            // 
            lookUpUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpUser.Location = new Point(549, 15);
            lookUpUser.Margin = new Padding(2, 1, 2, 1);
            lookUpUser.Name = "lookUpUser";
            lookUpUser.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            lookUpUser.Properties.Appearance.Options.UseFont = true;
            lookUpUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpUser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "إسم المستخدم", 11, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default) });
            lookUpUser.Properties.DisplayMember = "FullName";
            lookUpUser.Properties.NullText = "";
            lookUpUser.Properties.ValueMember = "Id";
            lookUpUser.Size = new Size(288, 26);
            lookUpUser.TabIndex = 44;
            lookUpUser.EditValueChanged += lookUpUser_EditValueChanged;
            // 
            // npSign
            // 
            npSign.Caption = "التوقيع الإلكتروني";
            npSign.Controls.Add(btnDeleteSign);
            npSign.Controls.Add(pboxSignature);
            npSign.Margin = new Padding(3, 2, 3, 2);
            npSign.Name = "npSign";
            npSign.Size = new Size(931, 625);
            // 
            // btnDeleteSign
            // 
            btnDeleteSign.Anchor = AnchorStyles.None;
            btnDeleteSign.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnDeleteSign.Appearance.ForeColor = Color.IndianRed;
            btnDeleteSign.Appearance.Options.UseFont = true;
            btnDeleteSign.Appearance.Options.UseForeColor = true;
            btnDeleteSign.Location = new Point(274, 252);
            btnDeleteSign.Margin = new Padding(2);
            btnDeleteSign.Name = "btnDeleteSign";
            btnDeleteSign.Size = new Size(382, 35);
            btnDeleteSign.TabIndex = 49;
            btnDeleteSign.Text = "إلغاء التوقيع";
            btnDeleteSign.Click += btnDeleteSign_Click;
            // 
            // pboxSignature
            // 
            pboxSignature.Anchor = AnchorStyles.None;
            pboxSignature.BackColor = Color.White;
            pboxSignature.Cursor = Cursors.Hand;
            pboxSignature.Location = new Point(274, 125);
            pboxSignature.Name = "pboxSignature";
            pboxSignature.Size = new Size(382, 113);
            pboxSignature.SizeMode = PictureBoxSizeMode.Zoom;
            pboxSignature.TabIndex = 0;
            pboxSignature.TabStop = false;
            pboxSignature.Click += pboxSignature_Click;
            // 
            // nfButton
            // 
            nfButton.Controls.Add(navigationPage3);
            nfButton.Controls.Add(navigationPage4);
            nfButton.Dock = DockStyle.Fill;
            nfButton.Font = new Font("Cairo", 8.5F);
            nfButton.Location = new Point(0, 0);
            nfButton.Margin = new Padding(3, 2, 3, 2);
            nfButton.Name = "nfButton";
            nfButton.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { navigationPage3, navigationPage4 });
            nfButton.SelectedPage = navigationPage3;
            nfButton.Size = new Size(157, 625);
            nfButton.TabIndex = 1;
            nfButton.Text = "nfButton";
            nfButton.TransitionAnimationProperties.FrameCount = 100;
            nfButton.TransitionAnimationProperties.FrameInterval = 1000;
            nfButton.TransitionType = DevExpress.Utils.Animation.Transitions.Fade;
            // 
            // navigationPage3
            // 
            navigationPage3.Caption = "navigationPage3";
            navigationPage3.Controls.Add(layoutControl1);
            navigationPage3.Margin = new Padding(3, 2, 3, 2);
            navigationPage3.Name = "navigationPage3";
            navigationPage3.Size = new Size(157, 625);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btnDeleteUser);
            layoutControl1.Controls.Add(btnRefresh);
            layoutControl1.Controls.Add(btnSign);
            layoutControl1.Controls.Add(btnPermissions);
            layoutControl1.Controls.Add(btnNewUser);
            layoutControl1.Controls.Add(btnUserStatus);
            layoutControl1.Controls.Add(btnEditPassword);
            layoutControl1.Controls.Add(btnEditUser);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(157, 625);
            layoutControl1.TabIndex = 50;
            layoutControl1.Text = "layoutControl1";
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteUser.Appearance.Font = new Font("Cairo", 9F);
            btnDeleteUser.Appearance.Options.UseFont = true;
            btnDeleteUser.Appearance.Options.UseTextOptions = true;
            btnDeleteUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnDeleteUser.ImageOptions.ImageIndex = 10;
            btnDeleteUser.ImageOptions.ImageList = svgImageCollection1;
            btnDeleteUser.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnDeleteUser.Location = new Point(12, 236);
            btnDeleteUser.Margin = new Padding(2);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(133, 28);
            btnDeleteUser.StyleController = layoutControl1;
            btnDeleteUser.TabIndex = 49;
            btnDeleteUser.Text = "حذف";
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.ImageSize = new Size(20, 20);
            svgImageCollection1.Add("save", "image://svgimages/diagramicons/save.svg");
            svgImageCollection1.Add("reset", "image://svgimages/outlook inspired/reset.svg");
            svgImageCollection1.Add("inserttreeview", "image://svgimages/dashboards/inserttreeview.svg");
            svgImageCollection1.Add("actions_addcircled", "image://svgimages/icon builder/actions_addcircled.svg");
            svgImageCollection1.Add("actions_edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("security_key", "image://svgimages/icon builder/security_key.svg");
            svgImageCollection1.Add("bo_mydetails", "image://svgimages/business objects/bo_mydetails.svg");
            svgImageCollection1.Add("bo_fileattachment", "image://svgimages/business objects/bo_fileattachment.svg");
            svgImageCollection1.Add("bo_user", "image://svgimages/business objects/bo_user.svg");
            svgImageCollection1.Add("changeview", "image://svgimages/outlook inspired/changeview.svg");
            svgImageCollection1.Add("del", "image://svgimages/diagramicons/del.svg");
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Appearance.Font = new Font("Cairo", 9F);
            btnRefresh.Appearance.Options.UseFont = true;
            btnRefresh.Appearance.Options.UseTextOptions = true;
            btnRefresh.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnRefresh.ImageOptions.ImageIndex = 9;
            btnRefresh.ImageOptions.ImageList = svgImageCollection1;
            btnRefresh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnRefresh.Location = new Point(12, 204);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(133, 28);
            btnRefresh.StyleController = layoutControl1;
            btnRefresh.TabIndex = 47;
            btnRefresh.Text = "تحديث";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSign
            // 
            btnSign.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSign.Appearance.Font = new Font("Cairo", 9F);
            btnSign.Appearance.Options.UseFont = true;
            btnSign.Appearance.Options.UseTextOptions = true;
            btnSign.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnSign.ImageOptions.ImageIndex = 7;
            btnSign.ImageOptions.ImageList = svgImageCollection1;
            btnSign.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnSign.Location = new Point(12, 140);
            btnSign.Margin = new Padding(2);
            btnSign.Name = "btnSign";
            btnSign.Size = new Size(133, 28);
            btnSign.StyleController = layoutControl1;
            btnSign.TabIndex = 48;
            btnSign.Text = "التوقيع الإلكتروني";
            btnSign.Click += btnSign_Click_1;
            // 
            // btnPermissions
            // 
            btnPermissions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPermissions.Appearance.Font = new Font("Cairo", 9F);
            btnPermissions.Appearance.Options.UseFont = true;
            btnPermissions.Appearance.Options.UseTextOptions = true;
            btnPermissions.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnPermissions.AppearanceDisabled.ForeColor = Color.Gray;
            btnPermissions.AppearanceDisabled.Options.UseForeColor = true;
            btnPermissions.ImageOptions.ImageIndex = 8;
            btnPermissions.ImageOptions.ImageList = svgImageCollection1;
            btnPermissions.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnPermissions.Location = new Point(12, 172);
            btnPermissions.Margin = new Padding(2);
            btnPermissions.Name = "btnPermissions";
            btnPermissions.Size = new Size(133, 28);
            btnPermissions.StyleController = layoutControl1;
            btnPermissions.TabIndex = 46;
            btnPermissions.Text = "إداره الصلاحيات";
            btnPermissions.Click += btnPermissions_Click;
            // 
            // btnNewUser
            // 
            btnNewUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewUser.Appearance.Font = new Font("Cairo", 9F);
            btnNewUser.Appearance.Options.UseFont = true;
            btnNewUser.Appearance.Options.UseTextOptions = true;
            btnNewUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnNewUser.AppearanceDisabled.ForeColor = Color.Gray;
            btnNewUser.AppearanceDisabled.Options.UseForeColor = true;
            btnNewUser.ImageOptions.ImageIndex = 3;
            btnNewUser.ImageOptions.ImageList = svgImageCollection1;
            btnNewUser.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnNewUser.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            btnNewUser.Location = new Point(12, 12);
            btnNewUser.Margin = new Padding(2);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new Size(133, 28);
            btnNewUser.StyleController = layoutControl1;
            btnNewUser.TabIndex = 42;
            btnNewUser.Text = "مستخدم جديد";
            btnNewUser.Click += btnNewUser_Click;
            // 
            // btnUserStatus
            // 
            btnUserStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUserStatus.Appearance.Font = new Font("Cairo", 9F);
            btnUserStatus.Appearance.Options.UseFont = true;
            btnUserStatus.Appearance.Options.UseTextOptions = true;
            btnUserStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnUserStatus.AppearanceDisabled.ForeColor = Color.Gray;
            btnUserStatus.AppearanceDisabled.Options.UseForeColor = true;
            btnUserStatus.ImageOptions.ImageIndex = 6;
            btnUserStatus.ImageOptions.ImageList = svgImageCollection1;
            btnUserStatus.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnUserStatus.Location = new Point(12, 108);
            btnUserStatus.Margin = new Padding(2);
            btnUserStatus.Name = "btnUserStatus";
            btnUserStatus.Size = new Size(133, 28);
            btnUserStatus.StyleController = layoutControl1;
            btnUserStatus.TabIndex = 44;
            btnUserStatus.Text = "إيقاف";
            btnUserStatus.Click += btnUserStatus_Click;
            // 
            // btnEditPassword
            // 
            btnEditPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditPassword.Appearance.Font = new Font("Cairo", 9F);
            btnEditPassword.Appearance.Options.UseFont = true;
            btnEditPassword.Appearance.Options.UseTextOptions = true;
            btnEditPassword.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnEditPassword.AppearanceDisabled.ForeColor = Color.Gray;
            btnEditPassword.AppearanceDisabled.Options.UseForeColor = true;
            btnEditPassword.ImageOptions.ImageIndex = 5;
            btnEditPassword.ImageOptions.ImageList = svgImageCollection1;
            btnEditPassword.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnEditPassword.Location = new Point(12, 76);
            btnEditPassword.Margin = new Padding(2);
            btnEditPassword.Name = "btnEditPassword";
            btnEditPassword.Size = new Size(133, 28);
            btnEditPassword.StyleController = layoutControl1;
            btnEditPassword.TabIndex = 45;
            btnEditPassword.Text = "تعديل كلمه المرور";
            btnEditPassword.Click += btnEditPassword_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditUser.Appearance.Font = new Font("Cairo", 9F);
            btnEditUser.Appearance.Options.UseFont = true;
            btnEditUser.Appearance.Options.UseTextOptions = true;
            btnEditUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnEditUser.AppearanceDisabled.ForeColor = Color.Gray;
            btnEditUser.AppearanceDisabled.Options.UseForeColor = true;
            btnEditUser.ImageOptions.ImageIndex = 4;
            btnEditUser.ImageOptions.ImageList = svgImageCollection1;
            btnEditUser.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnEditUser.Location = new Point(12, 44);
            btnEditUser.Margin = new Padding(2);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(133, 28);
            btnEditUser.StyleController = layoutControl1;
            btnEditUser.TabIndex = 43;
            btnEditUser.Text = "تعديل";
            btnEditUser.Click += btnEditUser_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, emptySpaceItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem7, layoutControlItem8 });
            Root.Name = "Root";
            Root.Size = new Size(157, 625);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnNewUser;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(137, 32);
            layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 256);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(137, 349);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btnEditUser;
            layoutControlItem2.Location = new Point(0, 32);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(137, 32);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btnEditPassword;
            layoutControlItem3.Location = new Point(0, 64);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(137, 32);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = btnUserStatus;
            layoutControlItem4.Location = new Point(0, 96);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(137, 32);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = btnSign;
            layoutControlItem5.Location = new Point(0, 128);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(137, 32);
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = btnPermissions;
            layoutControlItem6.Location = new Point(0, 160);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(137, 32);
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = btnRefresh;
            layoutControlItem7.Location = new Point(0, 192);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new Size(137, 32);
            layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = btnDeleteUser;
            layoutControlItem8.Location = new Point(0, 224);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new Size(137, 32);
            layoutControlItem8.TextVisible = false;
            // 
            // navigationPage4
            // 
            navigationPage4.Caption = "navigationPage4";
            navigationPage4.Controls.Add(layoutControl2);
            navigationPage4.Margin = new Padding(3, 2, 3, 2);
            navigationPage4.Name = "navigationPage4";
            navigationPage4.Size = new Size(157, 625);
            // 
            // layoutControl2
            // 
            layoutControl2.Controls.Add(btnExpandedCollapse);
            layoutControl2.Controls.Add(btnReturn);
            layoutControl2.Controls.Add(btnSave);
            layoutControl2.Dock = DockStyle.Fill;
            layoutControl2.Location = new Point(0, 0);
            layoutControl2.Name = "layoutControl2";
            layoutControl2.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl2.Root = layoutControlGroup1;
            layoutControl2.Size = new Size(157, 625);
            layoutControl2.TabIndex = 46;
            layoutControl2.Text = "layoutControl2";
            // 
            // btnExpandedCollapse
            // 
            btnExpandedCollapse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExpandedCollapse.Appearance.Font = new Font("Cairo", 9F);
            btnExpandedCollapse.Appearance.Options.UseFont = true;
            btnExpandedCollapse.Appearance.Options.UseTextOptions = true;
            btnExpandedCollapse.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnExpandedCollapse.ImageOptions.ImageIndex = 2;
            btnExpandedCollapse.ImageOptions.ImageList = svgImageCollection1;
            btnExpandedCollapse.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnExpandedCollapse.Location = new Point(12, 76);
            btnExpandedCollapse.Margin = new Padding(2);
            btnExpandedCollapse.Name = "btnExpandedCollapse";
            btnExpandedCollapse.Size = new Size(133, 28);
            btnExpandedCollapse.StyleController = layoutControl2;
            btnExpandedCollapse.TabIndex = 45;
            btnExpandedCollapse.Text = "توسيع/طي";
            btnExpandedCollapse.Click += btnExpandedCollapse_Click;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReturn.Appearance.Font = new Font("Cairo", 9F);
            btnReturn.Appearance.Options.UseFont = true;
            btnReturn.Appearance.Options.UseTextOptions = true;
            btnReturn.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnReturn.ImageOptions.ImageIndex = 1;
            btnReturn.ImageOptions.ImageList = svgImageCollection1;
            btnReturn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnReturn.Location = new Point(12, 44);
            btnReturn.Margin = new Padding(2);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(133, 28);
            btnReturn.StyleController = layoutControl2;
            btnReturn.TabIndex = 44;
            btnReturn.Text = "عودة";
            btnReturn.Click += btnReturn_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Appearance.Font = new Font("Cairo", 9F);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Appearance.Options.UseTextOptions = true;
            btnSave.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            btnSave.ImageOptions.ImageIndex = 0;
            btnSave.ImageOptions.ImageList = svgImageCollection1;
            btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnSave.Location = new Point(12, 12);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 28);
            btnSave.StyleController = layoutControl2;
            btnSave.TabIndex = 43;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem9, emptySpaceItem2, layoutControlItem10, layoutControlItem11 });
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new Size(157, 625);
            layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = btnSave;
            layoutControlItem9.Location = new Point(0, 0);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.Size = new Size(137, 32);
            layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new Point(0, 96);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(137, 509);
            // 
            // layoutControlItem10
            // 
            layoutControlItem10.Control = btnReturn;
            layoutControlItem10.Location = new Point(0, 32);
            layoutControlItem10.Name = "layoutControlItem10";
            layoutControlItem10.Size = new Size(137, 32);
            layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            layoutControlItem11.Control = btnExpandedCollapse;
            layoutControlItem11.Location = new Point(0, 64);
            layoutControlItem11.Name = "layoutControlItem11";
            layoutControlItem11.Size = new Size(137, 32);
            layoutControlItem11.TextVisible = false;
            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = DockStyle.Fill;
            splitContainerControl1.Location = new Point(0, 0);
            splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            splitContainerControl1.Panel1.Controls.Add(nfButton);
            splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            splitContainerControl1.Panel2.Controls.Add(nfData);
            splitContainerControl1.Panel2.Text = "Panel2";
            splitContainerControl1.Size = new Size(1098, 625);
            splitContainerControl1.SplitterPosition = 157;
            splitContainerControl1.TabIndex = 2;
            // 
            // lookUpEditCountryCode
            // 
            lookUpEditCountryCode.Location = new Point(548, 239);
            lookUpEditCountryCode.Name = "lookUpEditCountryCode";
            lookUpEditCountryCode.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditCountryCode.Properties.Appearance.Options.UseFont = true;
            lookUpEditCountryCode.Properties.AutoHeight = false;
            lookUpEditCountryCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEditCountryCode.Size = new Size(77, 30);
            lookUpEditCountryCode.TabIndex = 65;
            // 
            // frmUsersMgt
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 625);
            Controls.Add(splitContainerControl1);
            Font = new Font("Cairo", 8.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUsersMgt";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إدارة المستخدمين";
            Load += frmUsersMgt_Load;
            ((System.ComponentModel.ISupportInitialize)nfData).EndInit();
            nfData.ResumeLayout(false);
            npMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)usersListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).EndInit();
            npUsersDataEntry.ResumeLayout(false);
            npUsersDataEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtCompany.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPhoneNumber.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtJobTitel.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRePassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            npPermissions.ResumeLayout(false);
            npPermissions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);
            xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).EndInit();
            xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeList2).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit2).EndInit();
            xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeList3).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit3).EndInit();
            xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeList4).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit4).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpUser.Properties).EndInit();
            npSign.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pboxSignature).EndInit();
            ((System.ComponentModel.ISupportInitialize)nfButton).EndInit();
            nfButton.ResumeLayout(false);
            navigationPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            navigationPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl2).EndInit();
            layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lookUpEditCountryCode.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame nfData;
        private DevExpress.XtraBars.Navigation.NavigationPage npMain;
        private DevExpress.XtraBars.Navigation.NavigationPage npUsersDataEntry;
        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Navigation.NavigationFrame nfButton;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage3;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage4;
        private DevExpress.XtraEditors.SimpleButton btnSign;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnPermissions;
        private DevExpress.XtraEditors.SimpleButton btnEditPassword;
        private DevExpress.XtraEditors.SimpleButton btnUserStatus;
        private DevExpress.XtraEditors.SimpleButton btnEditUser;
        private DevExpress.XtraEditors.SimpleButton btnNewUser;
        public DevExpress.XtraEditors.TextEdit txtJobTitel;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtRePassword;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraBars.Navigation.NavigationPage npPermissions;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUserIDProcess;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPermsID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPermsDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPermsStatusProcess;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDParentProcess;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUserIDPrj;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPrjId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPrjName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPermsStatusPrj;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDParentPrj;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTreeList.TreeList treeList3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUserIDStore;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStoreId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStoreName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPermsStatusStore;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCanReceiveStore;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCanIssueStore;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCanTransferStore;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIdParentStore;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTreeList.TreeList treeList4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUserIDWorkflow;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colWorkflowId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colWorkflowName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPermsStatusWorkflow;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDParentWorkflow;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lookUpUser;
        private DevExpress.XtraBars.Navigation.NavigationPage npSign;
        private BindingSource usersListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colJobTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedMachine;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtCompany;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        public DevExpress.XtraEditors.TextEdit txtPhoneNumber;
        private System.Windows.Forms.PictureBox pboxSignature;
        private DevExpress.XtraEditors.SimpleButton btnDeleteSign;
        private DevExpress.XtraEditors.SimpleButton btnDeleteUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.SimpleButton btnExpandedCollapse;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCountryCode;
    }
}