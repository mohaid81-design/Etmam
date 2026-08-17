namespace Etmam
{
    partial class frmManpowerAddEdit
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
            if (disposing && (
                components != null))
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
            txtName = new DevExpress.XtraEditors.TextEdit();
            txtCategory = new DevExpress.XtraEditors.TextEdit();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnSaveAndClose = new DevExpress.XtraEditors.SimpleButton();
            btnSaveAndNew = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory.Properties).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtName.Location = new Point(21, 44);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.Font = new Font("Cairo", 8.999999F);
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Properties.AutoHeight = false;
            txtName.Size = new Size(294, 28);
            txtName.TabIndex = 0;
            // 
            // txtCategory
            // 
            txtCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCategory.Enabled = false;
            txtCategory.Location = new Point(21, 106);
            txtCategory.Margin = new Padding(3, 4, 3, 4);
            txtCategory.Name = "txtCategory";
            txtCategory.Properties.Appearance.BackColor = SystemColors.ControlLight;
            txtCategory.Properties.Appearance.Font = new Font("Cairo", 8.999999F);
            txtCategory.Properties.Appearance.Options.UseBackColor = true;
            txtCategory.Properties.Appearance.Options.UseFont = true;
            txtCategory.Properties.AutoHeight = false;
            txtCategory.Size = new Size(294, 28);
            txtCategory.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Appearance.Font = new Font("Cairo", 8.999999F);
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.ImageOptions.Image = Properties.Resources.cancel_16x16;
            btnCancel.Location = new Point(21, 150);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 28);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "إلغاء";
            // 
            // btnSaveAndClose
            // 
            btnSaveAndClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveAndClose.Appearance.Font = new Font("Cairo", 8.999999F);
            btnSaveAndClose.Appearance.Options.UseFont = true;
            btnSaveAndClose.ImageOptions.Image = Properties.Resources.saveandclose_16x16;
            btnSaveAndClose.Location = new Point(120, 150);
            btnSaveAndClose.Margin = new Padding(3, 4, 3, 4);
            btnSaveAndClose.Name = "btnSaveAndClose";
            btnSaveAndClose.Size = new Size(95, 28);
            btnSaveAndClose.TabIndex = 3;
            btnSaveAndClose.Text = "حفظ و اغلاق";
            btnSaveAndClose.Click += BtnSaveAndClose_Click;
            // 
            // btnSaveAndNew
            // 
            btnSaveAndNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveAndNew.Appearance.Font = new Font("Cairo", 8.999999F);
            btnSaveAndNew.Appearance.Options.UseFont = true;
            btnSaveAndNew.ImageOptions.Image = Properties.Resources.saveas_16x16;
            btnSaveAndNew.Location = new Point(219, 150);
            btnSaveAndNew.Margin = new Padding(3, 4, 3, 4);
            btnSaveAndNew.Name = "btnSaveAndNew";
            btnSaveAndNew.Size = new Size(95, 28);
            btnSaveAndNew.TabIndex = 4;
            btnSaveAndNew.Text = "حفظ و جديد";
            btnSaveAndNew.Click += BtnSaveAndNew_Click;
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new Font("Cairo", 8.999999F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(255, 17);
            labelControl1.Margin = new Padding(3, 4, 3, 4);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(60, 23);
            labelControl1.TabIndex = 5;
            labelControl1.Text = "إسم المهنة:";
            // 
            // labelControl2
            // 
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 8.999999F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(271, 77);
            labelControl2.Margin = new Padding(3, 4, 3, 4);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(44, 23);
            labelControl2.TabIndex = 6;
            labelControl2.Text = "التصنيف:";
            // 
            // frmManpowerAddEdit
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 207);
            ControlBox = false;
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(btnSaveAndNew);
            Controls.Add(btnSaveAndClose);
            Controls.Add(btnCancel);
            Controls.Add(txtCategory);
            Controls.Add(txtName);
            Font = new Font("Cairo", 9F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmManpowerAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إضافة/ تعديل مهنة";
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCategory;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndNew;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}