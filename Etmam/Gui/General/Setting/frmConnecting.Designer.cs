namespace Etmam
{
    partial class frmConnecting
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
            profilesBindingSource = new BindingSource(components);
            labelActive = new DevExpress.XtraEditors.LabelControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colName = new DevExpress.XtraGrid.Columns.GridColumn();
            colServer = new DevExpress.XtraGrid.Columns.GridColumn();
            colDatabase = new DevExpress.XtraGrid.Columns.GridColumn();
            btnNew = new DevExpress.XtraEditors.SimpleButton();
            btnDelete = new DevExpress.XtraEditors.SimpleButton();
            btnSetActive = new DevExpress.XtraEditors.SimpleButton();
            labelName = new DevExpress.XtraEditors.LabelControl();
            txtName = new DevExpress.XtraEditors.TextEdit();
            labelServer = new DevExpress.XtraEditors.LabelControl();
            txtServer = new DevExpress.XtraEditors.TextEdit();
            labelDataBase = new DevExpress.XtraEditors.LabelControl();
            txtDataBase = new DevExpress.XtraEditors.TextEdit();
            chkWindowsAuth = new DevExpress.XtraEditors.CheckEdit();
            labelUser = new DevExpress.XtraEditors.LabelControl();
            txtUser = new DevExpress.XtraEditors.TextEdit();
            labelUserPassword = new DevExpress.XtraEditors.LabelControl();
            txtUserPassword = new DevExpress.XtraEditors.TextEdit();
            chkEncrypt = new DevExpress.XtraEditors.CheckEdit();
            btnSaveProfile = new DevExpress.XtraEditors.SimpleButton();
            btnTest = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)profilesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtServer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDataBase.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkWindowsAuth.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUser.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkEncrypt.Properties).BeginInit();
            SuspendLayout();
            // 
            // labelActive
            // 
            labelActive.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelActive.Appearance.Options.UseFont = true;
            labelActive.Location = new Point(15, 15);
            labelActive.Name = "labelActive";
            labelActive.Size = new Size(113, 23);
            labelActive.TabIndex = 0;
            labelActive.Text = "الاتصال النشط الحالي:";
            // 
            // gridControl1
            // 
            gridControl1.DataSource = profilesBindingSource;
            gridControl1.Location = new Point(15, 44);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(670, 160);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colName, colServer, colDatabase });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            // 
            // colName
            // 
            colName.Caption = "اسم الاتصال";
            colName.FieldName = "Name";
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 0;
            // 
            // colServer
            // 
            colServer.Caption = "المخدم";
            colServer.FieldName = "Server";
            colServer.Name = "colServer";
            colServer.Visible = true;
            colServer.VisibleIndex = 1;
            // 
            // colDatabase
            // 
            colDatabase.Caption = "قاعدة البيانات";
            colDatabase.FieldName = "Database";
            colDatabase.Name = "colDatabase";
            colDatabase.Visible = true;
            colDatabase.VisibleIndex = 2;
            // 
            // btnNew
            // 
            btnNew.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnNew.Appearance.Options.UseFont = true;
            btnNew.Location = new Point(15, 210);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(150, 32);
            btnNew.TabIndex = 2;
            btnNew.Text = "جديد";
            btnNew.Click += btnNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnDelete.Appearance.Options.UseFont = true;
            btnDelete.Location = new Point(180, 210);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 32);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "حذف";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSetActive
            // 
            btnSetActive.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnSetActive.Appearance.Options.UseFont = true;
            btnSetActive.Location = new Point(345, 210);
            btnSetActive.Name = "btnSetActive";
            btnSetActive.Size = new Size(340, 32);
            btnSetActive.TabIndex = 4;
            btnSetActive.Text = "تعيين كنشط وإعادة التشغيل";
            btnSetActive.Click += btnSetActive_Click;
            // 
            // labelName
            // 
            labelName.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelName.Appearance.Options.UseFont = true;
            labelName.Location = new Point(15, 254);
            labelName.Name = "labelName";
            labelName.Size = new Size(68, 23);
            labelName.TabIndex = 5;
            labelName.Text = "اسم الاتصال:";
            // 
            // txtName
            // 
            txtName.Location = new Point(15, 278);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.BackColor = Color.White;
            txtName.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtName.Properties.Appearance.Options.UseBackColor = true;
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.RightToLeft = RightToLeft.No;
            txtName.Size = new Size(670, 26);
            txtName.TabIndex = 6;
            // 
            // labelServer
            // 
            labelServer.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelServer.Appearance.Options.UseFont = true;
            labelServer.Location = new Point(15, 312);
            labelServer.Name = "labelServer";
            labelServer.Size = new Size(67, 23);
            labelServer.TabIndex = 7;
            labelServer.Text = "إسم المخدم:";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(15, 336);
            txtServer.Name = "txtServer";
            txtServer.Properties.Appearance.BackColor = Color.White;
            txtServer.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtServer.Properties.Appearance.Options.UseBackColor = true;
            txtServer.Properties.Appearance.Options.UseFont = true;
            txtServer.RightToLeft = RightToLeft.No;
            txtServer.Size = new Size(670, 26);
            txtServer.TabIndex = 8;
            // 
            // labelDataBase
            // 
            labelDataBase.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelDataBase.Appearance.Options.UseFont = true;
            labelDataBase.Location = new Point(15, 370);
            labelDataBase.Name = "labelDataBase";
            labelDataBase.Size = new Size(105, 23);
            labelDataBase.TabIndex = 9;
            labelDataBase.Text = "إسم قاعدة البيانات:";
            // 
            // txtDataBase
            // 
            txtDataBase.Location = new Point(15, 394);
            txtDataBase.Name = "txtDataBase";
            txtDataBase.Properties.Appearance.BackColor = Color.White;
            txtDataBase.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtDataBase.Properties.Appearance.Options.UseBackColor = true;
            txtDataBase.Properties.Appearance.Options.UseFont = true;
            txtDataBase.RightToLeft = RightToLeft.No;
            txtDataBase.Size = new Size(670, 26);
            txtDataBase.TabIndex = 10;
            // 
            // chkWindowsAuth
            // 
            chkWindowsAuth.Location = new Point(15, 428);
            chkWindowsAuth.Name = "chkWindowsAuth";
            chkWindowsAuth.Properties.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            chkWindowsAuth.Properties.Appearance.Options.UseFont = true;
            chkWindowsAuth.Properties.Caption = "مصادقة ويندوز (Windows Authentication)";
            chkWindowsAuth.Size = new Size(400, 27);
            chkWindowsAuth.TabIndex = 11;
            chkWindowsAuth.CheckedChanged += chkWindowsAuth_CheckedChanged;
            // 
            // labelUser
            // 
            labelUser.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelUser.Appearance.Options.UseFont = true;
            labelUser.Location = new Point(15, 458);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(83, 23);
            labelUser.TabIndex = 12;
            labelUser.Text = "إسم المستخدم:";
            // 
            // txtUser
            // 
            txtUser.EditValue = "";
            txtUser.Location = new Point(15, 482);
            txtUser.Name = "txtUser";
            txtUser.Properties.Appearance.BackColor = Color.White;
            txtUser.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtUser.Properties.Appearance.Options.UseBackColor = true;
            txtUser.Properties.Appearance.Options.UseFont = true;
            txtUser.RightToLeft = RightToLeft.No;
            txtUser.Size = new Size(670, 26);
            txtUser.TabIndex = 13;
            // 
            // labelUserPassword
            // 
            labelUserPassword.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelUserPassword.Appearance.Options.UseFont = true;
            labelUserPassword.Location = new Point(15, 516);
            labelUserPassword.Name = "labelUserPassword";
            labelUserPassword.Size = new Size(64, 23);
            labelUserPassword.TabIndex = 14;
            labelUserPassword.Text = "كلمة المرور:";
            // 
            // txtUserPassword
            // 
            txtUserPassword.EditValue = "";
            txtUserPassword.Location = new Point(15, 540);
            txtUserPassword.Name = "txtUserPassword";
            txtUserPassword.Properties.Appearance.BackColor = Color.White;
            txtUserPassword.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtUserPassword.Properties.Appearance.Options.UseBackColor = true;
            txtUserPassword.Properties.Appearance.Options.UseFont = true;
            txtUserPassword.Properties.PasswordChar = '*';
            txtUserPassword.RightToLeft = RightToLeft.No;
            txtUserPassword.Size = new Size(670, 26);
            txtUserPassword.TabIndex = 15;
            // 
            // chkEncrypt
            // 
            chkEncrypt.Location = new Point(15, 574);
            chkEncrypt.Name = "chkEncrypt";
            chkEncrypt.Properties.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            chkEncrypt.Properties.Appearance.Options.UseFont = true;
            chkEncrypt.Properties.Caption = "تشفير الاتصال (Encrypt)";
            chkEncrypt.Size = new Size(400, 27);
            chkEncrypt.TabIndex = 16;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnSaveProfile.Appearance.Options.UseFont = true;
            btnSaveProfile.Location = new Point(15, 610);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(325, 36);
            btnSaveProfile.TabIndex = 17;
            btnSaveProfile.Text = "حفظ الاتصال";
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // btnTest
            // 
            btnTest.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnTest.Appearance.Options.UseFont = true;
            btnTest.Location = new Point(360, 610);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(325, 36);
            btnTest.TabIndex = 18;
            btnTest.Text = "اختبار الاتصال";
            btnTest.Click += btnTest_Click;
            // 
            // frmConnecting
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 666);
            Controls.Add(gridControl1);
            Controls.Add(labelActive);
            Controls.Add(btnNew);
            Controls.Add(btnDelete);
            Controls.Add(btnSetActive);
            Controls.Add(labelName);
            Controls.Add(txtName);
            Controls.Add(labelServer);
            Controls.Add(txtServer);
            Controls.Add(labelDataBase);
            Controls.Add(txtDataBase);
            Controls.Add(chkWindowsAuth);
            Controls.Add(labelUser);
            Controls.Add(txtUser);
            Controls.Add(labelUserPassword);
            Controls.Add(txtUserPassword);
            Controls.Add(chkEncrypt);
            Controls.Add(btnSaveProfile);
            Controls.Add(btnTest);
            Font = new Font("Cairo", 8.25F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConnecting";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إعدادات الإتصال";
            ((System.ComponentModel.ISupportInitialize)profilesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtServer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDataBase.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkWindowsAuth.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUser.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkEncrypt.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BindingSource profilesBindingSource;
        private DevExpress.XtraEditors.LabelControl labelActive;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colServer;
        private DevExpress.XtraGrid.Columns.GridColumn colDatabase;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSetActive;
        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelServer;
        private DevExpress.XtraEditors.TextEdit txtServer;
        private DevExpress.XtraEditors.LabelControl labelDataBase;
        private DevExpress.XtraEditors.TextEdit txtDataBase;
        private DevExpress.XtraEditors.CheckEdit chkWindowsAuth;
        private DevExpress.XtraEditors.LabelControl labelUser;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.LabelControl labelUserPassword;
        private DevExpress.XtraEditors.TextEdit txtUserPassword;
        private DevExpress.XtraEditors.CheckEdit chkEncrypt;
        private DevExpress.XtraEditors.SimpleButton btnSaveProfile;
        private DevExpress.XtraEditors.SimpleButton btnTest;
    }
}
