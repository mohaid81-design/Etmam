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
            DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule1 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule2 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule3 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule4 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
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
            colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            colRole = new DevExpress.XtraGrid.Columns.GridColumn();
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
            btnDeleteUser = new DevExpress.XtraEditors.SimpleButton();
            btnSign = new DevExpress.XtraEditors.SimpleButton();
            btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            btnPermissions = new DevExpress.XtraEditors.SimpleButton();
            btnEditPassword = new DevExpress.XtraEditors.SimpleButton();
            btnUserStatus = new DevExpress.XtraEditors.SimpleButton();
            btnEditUser = new DevExpress.XtraEditors.SimpleButton();
            btnNewUser = new DevExpress.XtraEditors.SimpleButton();
            navigationPage4 = new DevExpress.XtraBars.Navigation.NavigationPage();
            btnReturn = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)nfData).BeginInit();
            nfData.SuspendLayout();
            npMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usersListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            npUsersDataEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCompany.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserName.Properties).BeginInit();
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
            navigationPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
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
            nfData.Size = new Size(835, 579);
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
            npMain.Size = new Size(835, 579);
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
            gridControl1.Size = new Size(835, 579);
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
            gridView1.Appearance.Row.Font = new Font("Cairo", 8.5F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colUserName, colFullName, colJobTitle, colCompany, colPassword, colRole, colIsActive, colIsDelete, colCreatedBy, colCreatedDate, colCreatedMachine });
            gridView1.DetailHeight = 131;
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.OptionsEditForm.PopupEditFormWidth = 441;
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
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
            colCompany.Visible = true;
            colCompany.VisibleIndex = 3;
            colCompany.Width = 135;
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
            colRole.FieldName = "Role";
            colRole.MinWidth = 17;
            colRole.Name = "colRole";
            colRole.Visible = true;
            colRole.VisibleIndex = 4;
            colRole.Width = 80;
            // 
            // colIsActive
            // 
            colIsActive.Caption = "هل الحساب نشط";
            colIsActive.FieldName = "IsActive";
            colIsActive.MinWidth = 17;
            colIsActive.Name = "colIsActive";
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 5;
            colIsActive.Width = 73;
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
            npUsersDataEntry.Controls.Add(labelControl7);
            npUsersDataEntry.Controls.Add(txtCompany);
            npUsersDataEntry.Controls.Add(labelControl6);
            npUsersDataEntry.Controls.Add(txtUserName);
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
            npUsersDataEntry.Size = new Size(835, 579);
            // 
            // labelControl7
            // 
            labelControl7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl7.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl7.Appearance.Options.UseFont = true;
            labelControl7.Location = new Point(717, 134);
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
            txtCompany.Location = new Point(461, 129);
            txtCompany.Margin = new Padding(2, 1, 2, 1);
            txtCompany.Name = "txtCompany";
            txtCompany.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtCompany.Properties.Appearance.Options.UseFont = true;
            txtCompany.Properties.AutoHeight = false;
            txtCompany.Size = new Size(248, 25);
            txtCompany.TabIndex = 61;
            // 
            // labelControl6
            // 
            labelControl6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl6.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Location = new Point(717, 161);
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
            txtUserName.Location = new Point(461, 156);
            txtUserName.Margin = new Padding(2, 1, 2, 1);
            txtUserName.Name = "txtUserName";
            txtUserName.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtUserName.Properties.Appearance.Options.UseFont = true;
            txtUserName.Properties.AutoHeight = false;
            txtUserName.Size = new Size(248, 25);
            txtUserName.TabIndex = 59;
            // 
            // txtJobTitel
            // 
            txtJobTitel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtJobTitel.DataBindings.Add(new Binding("EditValue", usersListBindingSource, "JobTitle", true));
            txtJobTitel.Location = new Point(461, 46);
            txtJobTitel.Margin = new Padding(2, 1, 2, 1);
            txtJobTitel.Name = "txtJobTitel";
            txtJobTitel.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtJobTitel.Properties.Appearance.Options.UseFont = true;
            txtJobTitel.Properties.AutoHeight = false;
            txtJobTitel.Size = new Size(248, 25);
            txtJobTitel.TabIndex = 58;
            // 
            // labelControl4
            // 
            labelControl4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl4.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new Point(717, 107);
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
            txtName.Location = new Point(461, 18);
            txtName.Margin = new Padding(2, 1, 2, 1);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.BackColor = Color.White;
            txtName.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtName.Properties.Appearance.Options.UseBackColor = true;
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Properties.AutoHeight = false;
            txtName.Size = new Size(248, 25);
            txtName.TabIndex = 52;
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(717, 23);
            labelControl1.Margin = new Padding(2, 1, 2, 1);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(76, 23);
            labelControl1.TabIndex = 51;
            labelControl1.Text = "إسم المستخدم:";
            // 
            // txtRePassword
            // 
            txtRePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRePassword.Location = new Point(461, 102);
            txtRePassword.Margin = new Padding(2, 1, 2, 1);
            txtRePassword.Name = "txtRePassword";
            txtRePassword.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtRePassword.Properties.Appearance.Options.UseFont = true;
            txtRePassword.Properties.AutoHeight = false;
            txtRePassword.Properties.PasswordChar = '*';
            txtRePassword.Size = new Size(248, 25);
            txtRePassword.TabIndex = 56;
            // 
            // labelControl2
            // 
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 8.5F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(717, 51);
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
            labelControl3.Location = new Point(717, 79);
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
            txtPassword.Location = new Point(461, 74);
            txtPassword.Margin = new Padding(2, 1, 2, 1);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.AutoHeight = false;
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Size = new Size(248, 25);
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
            npPermissions.Size = new Size(835, 579);
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
            xtraTabControl1.Location = new Point(0, 80);
            xtraTabControl1.Margin = new Padding(3, 2, 3, 2);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabControl1.Size = new Size(835, 499);
            xtraTabControl1.TabIndex = 46;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2, xtraTabPage3, xtraTabPage4 });
            xtraTabControl1.TabPageWidth = 100;
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(treeList1);
            xtraTabPage1.Margin = new Padding(3, 2, 3, 2);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new Size(833, 464);
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
            treeList1.CheckBoxFieldName = "PermsStatus";
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colUserIDProcess, colPermsID, colPermsDescription, colPermsStatusProcess, colIDParentProcess });
            treeList1.Dock = DockStyle.Fill;
            treeList1.FixedLineWidth = 1;
            treeList1.Font = new Font("Cairo", 8.5F);
            treeListFormatRule1.ApplyToRow = true;
            treeListFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = Color.Gray;
            formatConditionRuleValue1.Appearance.ForeColor = Color.White;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            treeListFormatRule1.Rule = formatConditionRuleValue1;
            treeList1.FormatRules.Add(treeListFormatRule1);
            treeList1.HorzScrollStep = 2;
            treeList1.IndicatorWidth = 15;
            treeList1.KeyFieldName = "";
            treeList1.Location = new Point(0, 0);
            treeList1.Margin = new Padding(2);
            treeList1.MinWidth = 16;
            treeList1.Name = "treeList1";
            treeList1.OptionsView.AutoWidth = false;
            treeList1.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            treeList1.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            treeList1.ParentFieldName = "";
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit1 });
            treeList1.RowHeight = 14;
            treeList1.Size = new Size(833, 464);
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
            colPermsDescription.VisibleIndex = 0;
            colPermsDescription.Width = 469;
            // 
            // colPermsStatusProcess
            // 
            colPermsStatusProcess.Caption = "الحالة";
            colPermsStatusProcess.ColumnEdit = repositoryItemCheckEdit1;
            colPermsStatusProcess.FieldName = "PermsStatus";
            colPermsStatusProcess.MinWidth = 16;
            colPermsStatusProcess.Name = "colPermsStatusProcess";
            colPermsStatusProcess.Width = 27;
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
            xtraTabPage2.Size = new Size(833, 464);
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
            treeList2.CheckBoxFieldName = "PermsStatus";
            treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colUserIDPrj, colPrjId, colPrjName, colPermsStatusPrj, colIDParentPrj });
            treeList2.Dock = DockStyle.Fill;
            treeList2.FixedLineWidth = 1;
            treeList2.Font = new Font("Cairo", 8.5F);
            treeListFormatRule2.ApplyToRow = true;
            treeListFormatRule2.Name = "Format0";
            formatConditionRuleValue2.Appearance.BackColor = Color.Gray;
            formatConditionRuleValue2.Appearance.ForeColor = Color.White;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            treeListFormatRule2.Rule = formatConditionRuleValue2;
            treeList2.FormatRules.Add(treeListFormatRule2);
            treeList2.HorzScrollStep = 2;
            treeList2.IndicatorWidth = 15;
            treeList2.KeyFieldName = "";
            treeList2.Location = new Point(0, 0);
            treeList2.Margin = new Padding(2);
            treeList2.MinWidth = 16;
            treeList2.Name = "treeList2";
            treeList2.OptionsView.AutoWidth = false;
            treeList2.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            treeList2.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            treeList2.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            treeList2.ParentFieldName = "";
            treeList2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit2 });
            treeList2.RowHeight = 14;
            treeList2.Size = new Size(833, 464);
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
            colPrjName.VisibleIndex = 0;
            colPrjName.Width = 469;
            // 
            // colPermsStatusPrj
            // 
            colPermsStatusPrj.Caption = "الحالة";
            colPermsStatusPrj.ColumnEdit = repositoryItemCheckEdit2;
            colPermsStatusPrj.FieldName = "PermsStatus";
            colPermsStatusPrj.MinWidth = 16;
            colPermsStatusPrj.Name = "colPermsStatusPrj";
            colPermsStatusPrj.Width = 27;
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
            xtraTabPage3.Size = new Size(833, 464);
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
            treeList3.CheckBoxFieldName = "PermsStatus";
            treeList3.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colUserIDStore, colStoreId, colStoreName, colPermsStatusStore, colIdParentStore });
            treeList3.Dock = DockStyle.Fill;
            treeList3.FixedLineWidth = 1;
            treeList3.Font = new Font("Cairo", 8.5F);
            treeListFormatRule3.ApplyToRow = true;
            treeListFormatRule3.Name = "Format0";
            formatConditionRuleValue3.Appearance.BackColor = Color.Gray;
            formatConditionRuleValue3.Appearance.ForeColor = Color.White;
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            treeListFormatRule3.Rule = formatConditionRuleValue3;
            treeList3.FormatRules.Add(treeListFormatRule3);
            treeList3.HorzScrollStep = 2;
            treeList3.IndicatorWidth = 15;
            treeList3.KeyFieldName = "";
            treeList3.Location = new Point(0, 0);
            treeList3.Margin = new Padding(2);
            treeList3.MinWidth = 16;
            treeList3.Name = "treeList3";
            treeList3.OptionsView.AutoWidth = false;
            treeList3.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            treeList3.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            treeList3.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            treeList3.ParentFieldName = "";
            treeList3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit3 });
            treeList3.RowHeight = 14;
            treeList3.Size = new Size(833, 464);
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
            colStoreName.VisibleIndex = 0;
            colStoreName.Width = 469;
            // 
            // colPermsStatusStore
            // 
            colPermsStatusStore.Caption = "الحالة";
            colPermsStatusStore.ColumnEdit = repositoryItemCheckEdit3;
            colPermsStatusStore.FieldName = "PermsStatus";
            colPermsStatusStore.MinWidth = 16;
            colPermsStatusStore.Name = "colPermsStatusStore";
            colPermsStatusStore.Width = 27;
            // 
            // repositoryItemCheckEdit3
            // 
            repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
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
            xtraTabPage4.Size = new Size(833, 464);
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
            treeList4.CheckBoxFieldName = "PermsStatus";
            treeList4.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colUserIDWorkflow, colWorkflowId, colWorkflowName, colPermsStatusWorkflow, colIDParentWorkflow });
            treeList4.Dock = DockStyle.Fill;
            treeList4.FixedLineWidth = 1;
            treeList4.Font = new Font("Cairo", 8.5F);
            treeListFormatRule4.ApplyToRow = true;
            treeListFormatRule4.Name = "Format0";
            formatConditionRuleValue4.Appearance.BackColor = Color.Gray;
            formatConditionRuleValue4.Appearance.ForeColor = Color.White;
            formatConditionRuleValue4.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            treeListFormatRule4.Rule = formatConditionRuleValue4;
            treeList4.FormatRules.Add(treeListFormatRule4);
            treeList4.HorzScrollStep = 2;
            treeList4.IndicatorWidth = 15;
            treeList4.KeyFieldName = "";
            treeList4.Location = new Point(0, 0);
            treeList4.Margin = new Padding(2);
            treeList4.MinWidth = 16;
            treeList4.Name = "treeList4";
            treeList4.OptionsView.AutoWidth = false;
            treeList4.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            treeList4.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            treeList4.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            treeList4.ParentFieldName = "";
            treeList4.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit4 });
            treeList4.RowHeight = 14;
            treeList4.Size = new Size(833, 464);
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
            colWorkflowName.VisibleIndex = 0;
            colWorkflowName.Width = 469;
            //
            // colPermsStatusWorkflow
            //
            colPermsStatusWorkflow.Caption = "الحالة";
            colPermsStatusWorkflow.ColumnEdit = repositoryItemCheckEdit4;
            colPermsStatusWorkflow.FieldName = "PermsStatus";
            colPermsStatusWorkflow.MinWidth = 16;
            colPermsStatusWorkflow.Name = "colPermsStatusWorkflow";
            colPermsStatusWorkflow.Width = 27;
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
            labelControl5.Location = new Point(761, 18);
            labelControl5.Margin = new Padding(2);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(76, 23);
            labelControl5.TabIndex = 45;
            labelControl5.Text = "إسم المستخدم:";
            // 
            // lookUpUser
            // 
            lookUpUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpUser.Location = new Point(509, 15);
            lookUpUser.Margin = new Padding(2, 1, 2, 1);
            lookUpUser.Name = "lookUpUser";
            lookUpUser.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            lookUpUser.Properties.Appearance.Options.UseFont = true;
            lookUpUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpUser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 11, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "إسم المستخدم", 11, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default) });
            lookUpUser.Properties.DisplayMember = "Name";
            lookUpUser.Properties.NullText = "";
            lookUpUser.Properties.ValueMember = "Id";
            lookUpUser.Size = new Size(246, 26);
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
            npSign.Size = new Size(835, 579);
            // 
            // btnDeleteSign
            // 
            btnDeleteSign.Anchor = AnchorStyles.None;
            btnDeleteSign.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnDeleteSign.Appearance.ForeColor = Color.IndianRed;
            btnDeleteSign.Appearance.Options.UseFont = true;
            btnDeleteSign.Appearance.Options.UseForeColor = true;
            btnDeleteSign.Location = new Point(226, 229);
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
            pboxSignature.Location = new Point(226, 102);
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
            nfButton.Size = new Size(152, 579);
            nfButton.TabIndex = 1;
            nfButton.Text = "nfButton";
            nfButton.TransitionAnimationProperties.FrameCount = 100;
            nfButton.TransitionAnimationProperties.FrameInterval = 1000;
            nfButton.TransitionType = DevExpress.Utils.Animation.Transitions.Fade;
            // 
            // navigationPage3
            // 
            navigationPage3.Caption = "navigationPage3";
            navigationPage3.Controls.Add(btnDeleteUser);
            navigationPage3.Controls.Add(btnSign);
            navigationPage3.Controls.Add(btnRefresh);
            navigationPage3.Controls.Add(btnPermissions);
            navigationPage3.Controls.Add(btnEditPassword);
            navigationPage3.Controls.Add(btnUserStatus);
            navigationPage3.Controls.Add(btnEditUser);
            navigationPage3.Controls.Add(btnNewUser);
            navigationPage3.Margin = new Padding(3, 2, 3, 2);
            navigationPage3.Name = "navigationPage3";
            navigationPage3.Size = new Size(152, 579);
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteUser.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            btnDeleteUser.Appearance.ForeColor = Color.IndianRed;
            btnDeleteUser.Appearance.Options.UseFont = true;
            btnDeleteUser.Appearance.Options.UseForeColor = true;
            btnDeleteUser.Location = new Point(21, 258);
            btnDeleteUser.Margin = new Padding(2);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(111, 28);
            btnDeleteUser.TabIndex = 49;
            btnDeleteUser.Text = "حذف";
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnSign
            // 
            btnSign.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSign.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            btnSign.Appearance.Options.UseFont = true;
            btnSign.Location = new Point(21, 153);
            btnSign.Margin = new Padding(2);
            btnSign.Name = "btnSign";
            btnSign.Size = new Size(111, 28);
            btnSign.TabIndex = 48;
            btnSign.Text = "التوقيع الإلكتروني";
            btnSign.Click += btnSign_Click_1;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            btnRefresh.Appearance.FontStyleDelta = FontStyle.Bold;
            btnRefresh.Appearance.Options.UseFont = true;
            btnRefresh.Location = new Point(21, 223);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(111, 28);
            btnRefresh.TabIndex = 47;
            btnRefresh.Text = "تحديث";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnPermissions
            // 
            btnPermissions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPermissions.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            btnPermissions.Appearance.Options.UseFont = true;
            btnPermissions.Location = new Point(21, 188);
            btnPermissions.Margin = new Padding(2);
            btnPermissions.Name = "btnPermissions";
            btnPermissions.Size = new Size(111, 28);
            btnPermissions.TabIndex = 46;
            btnPermissions.Text = "إداره الصلاحيات";
            btnPermissions.Click += btnPermissions_Click;
            // 
            // btnEditPassword
            // 
            btnEditPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditPassword.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            btnEditPassword.Appearance.Options.UseFont = true;
            btnEditPassword.Location = new Point(21, 84);
            btnEditPassword.Margin = new Padding(2);
            btnEditPassword.Name = "btnEditPassword";
            btnEditPassword.Size = new Size(111, 28);
            btnEditPassword.TabIndex = 45;
            btnEditPassword.Text = "تعديل كلمه المرور";
            btnEditPassword.Click += btnEditPassword_Click;
            // 
            // btnUserStatus
            // 
            btnUserStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUserStatus.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            btnUserStatus.Appearance.Options.UseFont = true;
            btnUserStatus.Location = new Point(21, 119);
            btnUserStatus.Margin = new Padding(2);
            btnUserStatus.Name = "btnUserStatus";
            btnUserStatus.Size = new Size(111, 28);
            btnUserStatus.TabIndex = 44;
            btnUserStatus.Text = "إيقاف";
            btnUserStatus.Click += btnUserStatus_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditUser.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            btnEditUser.Appearance.Options.UseFont = true;
            btnEditUser.Location = new Point(21, 49);
            btnEditUser.Margin = new Padding(2);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(111, 28);
            btnEditUser.TabIndex = 43;
            btnEditUser.Text = "تعديل";
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnNewUser
            // 
            btnNewUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewUser.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            btnNewUser.Appearance.Options.UseFont = true;
            btnNewUser.Location = new Point(21, 15);
            btnNewUser.Margin = new Padding(2);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new Size(111, 28);
            btnNewUser.TabIndex = 42;
            btnNewUser.Text = "مستخدم جديد";
            btnNewUser.Click += btnNewUser_Click;
            // 
            // navigationPage4
            // 
            navigationPage4.Caption = "navigationPage4";
            navigationPage4.Controls.Add(btnReturn);
            navigationPage4.Controls.Add(btnSave);
            navigationPage4.Margin = new Padding(3, 2, 3, 2);
            navigationPage4.Name = "navigationPage4";
            navigationPage4.Size = new Size(152, 579);
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReturn.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnReturn.Appearance.Options.UseFont = true;
            btnReturn.Location = new Point(21, 49);
            btnReturn.Margin = new Padding(2);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(111, 28);
            btnReturn.TabIndex = 44;
            btnReturn.Text = "عودة";
            btnReturn.Click += btnReturn_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Location = new Point(21, 15);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 28);
            btnSave.TabIndex = 43;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
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
            splitContainerControl1.Size = new Size(997, 579);
            splitContainerControl1.SplitterPosition = 152;
            splitContainerControl1.TabIndex = 2;
            // 
            // frmUsersMgt
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 579);
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
            npUsersDataEntry.ResumeLayout(false);
            npUsersDataEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtCompany.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserName.Properties).EndInit();
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
            navigationPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedMachine;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtCompany;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtUserName;
        private System.Windows.Forms.PictureBox pboxSignature;
        private DevExpress.XtraEditors.SimpleButton btnDeleteSign;
        private DevExpress.XtraEditors.SimpleButton btnDeleteUser;
    }
}