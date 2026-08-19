namespace Etmam
{
    partial class frmUpdatePassword
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

        private void InitializeComponent()
        {
            txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            txtFullName = new DevExpress.XtraEditors.TextEdit();
            txtJobTitle = new DevExpress.XtraEditors.TextEdit();
            txtCompany = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)txtNewPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtConfirmPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtJobTitle.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCompany.Properties).BeginInit();
            SuspendLayout();
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(50, 235);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Properties.Appearance.Font = new Font("Cairo", 8F);
            txtNewPassword.Properties.Appearance.Options.UseFont = true;
            txtNewPassword.Properties.PasswordChar = '*';
            txtNewPassword.Size = new Size(250, 26);
            txtNewPassword.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(50, 290);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Properties.Appearance.Font = new Font("Cairo", 8F);
            txtConfirmPassword.Properties.Appearance.Options.UseFont = true;
            txtConfirmPassword.Properties.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(250, 26);
            txtConfirmPassword.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Location = new Point(180, 356);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 32);
            btnSave.TabIndex = 9;
            btnSave.Text = "حفظ البيانات";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Location = new Point(50, 356);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 32);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "إلغاء";
            btnCancel.Click += btnCancel_Click;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(93, 15);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(207, 23);
            labelControl1.TabIndex = 7;
            labelControl1.Text = "يرجى استكمال بياناتك عند الدخول الأول";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(192, 212);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(97, 20);
            labelControl2.TabIndex = 6;
            labelControl2.Text = "كلمة المرور الجديدة:";
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new Point(205, 267);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(87, 20);
            labelControl3.TabIndex = 5;
            labelControl3.Text = "تأكيد كلمة المرور:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(50, 70);
            txtFullName.Name = "txtFullName";
            txtFullName.Properties.Appearance.Font = new Font("Cairo", 8F);
            txtFullName.Properties.Appearance.Options.UseFont = true;
            txtFullName.Size = new Size(250, 26);
            txtFullName.TabIndex = 0;
            // 
            // txtJobTitle
            // 
            txtJobTitle.Location = new Point(50, 125);
            txtJobTitle.Name = "txtJobTitle";
            txtJobTitle.Properties.Appearance.Font = new Font("Cairo", 8F);
            txtJobTitle.Properties.Appearance.Options.UseFont = true;
            txtJobTitle.Size = new Size(250, 26);
            txtJobTitle.TabIndex = 1;
            // 
            // txtCompany
            // 
            txtCompany.Location = new Point(50, 180);
            txtCompany.Name = "txtCompany";
            txtCompany.Properties.Appearance.Font = new Font("Cairo", 8F);
            txtCompany.Properties.Appearance.Options.UseFont = true;
            txtCompany.Size = new Size(250, 26);
            txtCompany.TabIndex = 2;
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new Point(226, 47);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(67, 20);
            labelControl4.TabIndex = 4;
            labelControl4.Text = "الاسم الكامل:";
            // 
            // labelControl5
            // 
            labelControl5.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Location = new Point(208, 102);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(83, 20);
            labelControl5.TabIndex = 3;
            labelControl5.Text = "الوصف الوظيفي:";
            // 
            // labelControl6
            // 
            labelControl6.Appearance.Font = new Font("Cairo", 8F, FontStyle.Bold);
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Location = new Point(233, 157);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new Size(60, 20);
            labelControl6.TabIndex = 0;
            labelControl6.Text = "اسم الشركة:";
            // 
            // frmUpdatePassword
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 410);
            Controls.Add(labelControl6);
            Controls.Add(txtCompany);
            Controls.Add(labelControl5);
            Controls.Add(txtJobTitle);
            Controls.Add(labelControl4);
            Controls.Add(txtFullName);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Font = new Font("Cairo", 8.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUpdatePassword";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "استكمال بيانات المستخدم";
            ((System.ComponentModel.ISupportInitialize)txtNewPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtConfirmPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtJobTitle.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCompany.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.TextEdit txtJobTitle;
        private DevExpress.XtraEditors.TextEdit txtCompany;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
