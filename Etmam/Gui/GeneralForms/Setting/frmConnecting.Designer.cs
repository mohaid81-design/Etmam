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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnecting));
            radioButtonNetwork = new RadioButton();
            radioButtonLocal = new RadioButton();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            txtUserPassword = new DevExpress.XtraEditors.TextEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            txtUser = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            txtDataBase = new DevExpress.XtraEditors.TextEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            lookUpServer = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)txtUserPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUser.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDataBase.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpServer.Properties).BeginInit();
            SuspendLayout();
            // 
            // radioButtonNetwork
            // 
            radioButtonNetwork.AutoSize = true;
            radioButtonNetwork.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            radioButtonNetwork.Location = new Point(190, 23);
            radioButtonNetwork.Margin = new Padding(2, 4, 2, 4);
            radioButtonNetwork.Name = "radioButtonNetwork";
            radioButtonNetwork.Size = new Size(61, 27);
            radioButtonNetwork.TabIndex = 19;
            radioButtonNetwork.Text = "شبكي";
            radioButtonNetwork.UseVisualStyleBackColor = true;
            radioButtonNetwork.CheckedChanged += radioButtonNetwork_CheckedChanged;
            // 
            // radioButtonLocal
            // 
            radioButtonLocal.AutoSize = true;
            radioButtonLocal.Checked = true;
            radioButtonLocal.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            radioButtonLocal.Location = new Point(274, 23);
            radioButtonLocal.Margin = new Padding(2, 4, 2, 4);
            radioButtonLocal.Name = "radioButtonLocal";
            radioButtonLocal.Size = new Size(56, 27);
            radioButtonLocal.TabIndex = 0;
            radioButtonLocal.TabStop = true;
            radioButtonLocal.Text = "محلي";
            radioButtonLocal.UseVisualStyleBackColor = true;
            radioButtonLocal.CheckedChanged += radioButtonLocal_CheckedChanged;
            // 
            // labelControl4
            // 
            labelControl4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl4.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new Point(267, 244);
            labelControl4.Margin = new Padding(2, 4, 2, 4);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(60, 23);
            labelControl4.TabIndex = 17;
            labelControl4.Text = "كلمة المرور:";
            // 
            // txtUserPassword
            // 
            txtUserPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUserPassword.EditValue = "";
            txtUserPassword.Location = new Point(13, 272);
            txtUserPassword.Margin = new Padding(2, 4, 2, 4);
            txtUserPassword.Name = "txtUserPassword";
            txtUserPassword.Properties.Appearance.BackColor = Color.White;
            txtUserPassword.Properties.Appearance.Options.UseBackColor = true;
            txtUserPassword.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 8.5F);
            txtUserPassword.Properties.Appearance.Options.UseFont = true;
            txtUserPassword.Properties.PasswordChar = '*';
            txtUserPassword.RightToLeft = RightToLeft.No;
            txtUserPassword.Size = new Size(314, 30);
            txtUserPassword.TabIndex = 16;
            // 
            // labelControl3
            // 
            labelControl3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl3.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new Point(251, 184);
            labelControl3.Margin = new Padding(2, 4, 2, 4);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(76, 23);
            labelControl3.TabIndex = 15;
            labelControl3.Text = "إسم المستخدم:";
            // 
            // txtUser
            // 
            txtUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUser.EditValue = "";
            txtUser.Location = new Point(13, 211);
            txtUser.Margin = new Padding(2, 4, 2, 4);
            txtUser.Name = "txtUser";
            txtUser.Properties.Appearance.BackColor = Color.White;
            txtUser.Properties.Appearance.Options.UseBackColor = true;
            txtUser.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 8.5F);
            txtUser.Properties.Appearance.Options.UseFont = true;
            txtUser.RightToLeft = RightToLeft.No;
            txtUser.Size = new Size(314, 30);
            txtUser.TabIndex = 14;
            // 
            // labelControl2
            // 
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(232, 124);
            labelControl2.Margin = new Padding(2, 4, 2, 4);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(95, 23);
            labelControl2.TabIndex = 13;
            labelControl2.Text = "إسم قاعدة البيانات:";
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(265, 62);
            labelControl1.Margin = new Padding(2, 4, 2, 4);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(62, 23);
            labelControl1.TabIndex = 12;
            labelControl1.Text = "إسم المخدم:";
            // 
            // txtDataBase
            // 
            txtDataBase.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDataBase.EditValue = "";
            txtDataBase.Location = new Point(13, 150);
            txtDataBase.Margin = new Padding(2, 4, 2, 4);
            txtDataBase.Name = "txtDataBase";
            txtDataBase.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 8.5F);
            txtDataBase.Properties.Appearance.Options.UseFont = true;
            txtDataBase.RightToLeft = RightToLeft.No;
            txtDataBase.Size = new Size(314, 30);
            txtDataBase.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Appearance.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Location = new Point(13, 327);
            btnSave.Margin = new Padding(2, 4, 2, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(314, 35);
            btnSave.TabIndex = 0;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // lookUpServer
            // 
            lookUpServer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpServer.EditValue = "";
            lookUpServer.Location = new Point(13, 88);
            lookUpServer.Margin = new Padding(2, 4, 2, 4);
            lookUpServer.Name = "lookUpServer";
            lookUpServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpServer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerName", "") });
            lookUpServer.Properties.NullText = "";
            lookUpServer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lookUpServer.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 8.5F);
            lookUpServer.Properties.Appearance.Options.UseFont = true;
            lookUpServer.RightToLeft = RightToLeft.No;
            lookUpServer.Size = new Size(314, 30);
            lookUpServer.TabIndex = 10;
            // 
            // frmConnecting
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 380);
            Controls.Add(btnSave);
            Controls.Add(radioButtonNetwork);
            Controls.Add(radioButtonLocal);
            Controls.Add(labelControl4);
            Controls.Add(txtUserPassword);
            Controls.Add(labelControl3);
            Controls.Add(txtUser);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(txtDataBase);
            Controls.Add(lookUpServer);
            Font = new System.Drawing.Font("Cairo", 8.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            //IconOptions.Image = (Image)resources.GetObject("frmConnecting.IconOptions.Image");
            Margin = new Padding(2, 4, 2, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConnecting";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إعدادات الإتصال";
            ((System.ComponentModel.ISupportInitialize)txtUserPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUser.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDataBase.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpServer.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButtonNetwork;
        private RadioButton radioButtonLocal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtUserPassword;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDataBase;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit lookUpServer;
    }
}