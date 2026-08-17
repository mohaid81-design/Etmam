namespace Etmam
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            picUserLogging = new DevExpress.XtraEditors.PictureEdit();
            btnLogin = new DevExpress.XtraEditors.SimpleButton();
            imageCollection_24 = new DevExpress.Utils.ImageCollection(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            btnClose = new DevExpress.XtraEditors.SimpleButton();
            toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            txtUserName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)picUserLogging.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection_24).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toggleSwitch1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserName.Properties).BeginInit();
            SuspendLayout();
            // 
            // picUserLogging
            // 
            picUserLogging.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picUserLogging.EditValue = Properties.Resources.Etmam_Logo_2;
            picUserLogging.Location = new Point(25, 58);
            picUserLogging.Margin = new Padding(3, 4, 3, 4);
            picUserLogging.Name = "picUserLogging";
            picUserLogging.Properties.AllowFocused = false;
            picUserLogging.Properties.Appearance.BackColor = Color.Transparent;
            picUserLogging.Properties.Appearance.Options.UseBackColor = true;
            picUserLogging.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            picUserLogging.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            picUserLogging.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            picUserLogging.Size = new Size(200, 62);
            picUserLogging.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnLogin.Appearance.Options.UseFont = true;
            btnLogin.Location = new Point(12, 365);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(287, 40);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "دخول";
            btnLogin.Click += btnLogin_Click;
            // 
            // imageCollection_24
            // 
            imageCollection_24.ImageSize = new Size(24, 24);
            imageCollection_24.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection_24.ImageStream");
            imageCollection_24.InsertImage(Properties.Resources.bouser_32x32, "bouser_32x32", typeof(Properties.Resources), 0);
            imageCollection_24.Images.SetKeyName(0, "bouser_32x32");
            imageCollection_24.InsertImage(Properties.Resources.bopermission_32x32, "bopermission_32x32", typeof(Properties.Resources), 1);
            imageCollection_24.Images.SetKeyName(1, "bopermission_32x32");
            imageCollection_24.InsertImage(Properties.Resources.close_32x32, "close_32x32", typeof(Properties.Resources), 2);
            imageCollection_24.Images.SetKeyName(2, "close_32x32");
            // 
            // barManager1
            // 
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(308, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 428);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(308, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 428);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(308, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 428);
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.EditValue = "";
            txtPassword.Location = new Point(10, 189);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.AutoHeight = false;
            txtPassword.Properties.ContextImageOptions.Image = Properties.Resources.bopermission_16x16;
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.RightToLeft = RightToLeft.No;
            txtPassword.Size = new Size(287, 40);
            txtPassword.TabIndex = 9;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.ImageOptions.ImageIndex = 2;
            btnClose.ImageOptions.ImageList = imageCollection_24;
            btnClose.Location = new Point(264, 12);
            btnClose.Name = "btnClose";
            btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            btnClose.Size = new Size(30, 28);
            btnClose.TabIndex = 14;
            btnClose.Click += btnClose_Click;
            // 
            // toggleSwitch1
            // 
            toggleSwitch1.Location = new Point(10, 235);
            toggleSwitch1.MenuManager = barManager1;
            toggleSwitch1.Name = "toggleSwitch1";
            toggleSwitch1.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            toggleSwitch1.Properties.Appearance.Options.UseFont = true;
            toggleSwitch1.Properties.OffText = "تذكرني";
            toggleSwitch1.Properties.OnText = "تذكرني";
            toggleSwitch1.RightToLeft = RightToLeft.Yes;
            toggleSwitch1.Size = new Size(284, 28);
            toggleSwitch1.TabIndex = 16;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserName.EditValue = "";
            txtUserName.Location = new Point(9, 143);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtUserName.Properties.Appearance.Options.UseFont = true;
            txtUserName.Properties.AutoHeight = false;
            txtUserName.Properties.ContextImageOptions.Image = Properties.Resources.mail_16x16;
            txtUserName.Properties.Name = "lookUpUserName";
            txtUserName.RightToLeft = RightToLeft.No;
            txtUserName.Size = new Size(287, 40);
            txtUserName.TabIndex = 8;
            // 
            // frmLogin
            // 
            AcceptButton = btnLogin;
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 428);
            ControlBox = false;
            Controls.Add(toggleSwitch1);
            Controls.Add(btnClose);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(picUserLogging);
            Controls.Add(txtUserName);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new Font("Cairo", 8.5F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogin";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "دخول";
            ((System.ComponentModel.ISupportInitialize)picUserLogging.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection_24).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)toggleSwitch1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserName.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraEditors.PictureEdit picUserLogging;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.Utils.ImageCollection imageCollection_24;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraEditors.TextEdit txtUserName;
    }
}