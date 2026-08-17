namespace Etmam
{
    partial class frmBackup
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
            btnCreate = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            btnOpenFileDialog = new DevExpress.XtraEditors.SimpleButton();
            txtFileName = new DevExpress.XtraEditors.TextEdit();
            xtraFolderBrowserDialog1 = new DevExpress.XtraEditors.XtraFolderBrowserDialog(components);
            ((System.ComponentModel.ISupportInitialize)txtFileName.Properties).BeginInit();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreate.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnCreate.Appearance.Options.UseFont = true;
            btnCreate.ImageOptions.ImageIndex = 8;
            btnCreate.Location = new Point(21, 134);
            btnCreate.Margin = new Padding(3, 2, 3, 2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(202, 35);
            btnCreate.TabIndex = 20;
            btnCreate.Text = "إنشاء النسخة الإحتياطية";
            btnCreate.Click += btnCreate_Click;
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(374, 16);
            labelControl1.Margin = new Padding(3, 4, 3, 4);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(233, 29);
            labelControl1.TabIndex = 19;
            labelControl1.Text = "قم بتحديد مسار حفظ النسخة الإحتياطية";
            // 
            // btnOpenFileDialog
            // 
            btnOpenFileDialog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenFileDialog.Appearance.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            btnOpenFileDialog.Appearance.Options.UseFont = true;
            btnOpenFileDialog.Location = new Point(21, 64);
            btnOpenFileDialog.Margin = new Padding(3, 4, 3, 4);
            btnOpenFileDialog.Name = "btnOpenFileDialog";
            btnOpenFileDialog.Size = new Size(105, 30);
            btnOpenFileDialog.TabIndex = 18;
            btnOpenFileDialog.Text = "...";
            btnOpenFileDialog.Click += btnOpenFileDialog_Click;
            // 
            // txtFileName
            // 
            txtFileName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtFileName.EditValue = "\\\\hadfserver\\HADF_SERVER\\Backup";
            txtFileName.Location = new Point(132, 64);
            txtFileName.Margin = new Padding(3, 4, 3, 4);
            txtFileName.Name = "txtFileName";
            txtFileName.RightToLeft = RightToLeft.No;
            txtFileName.Size = new Size(475, 30);
            txtFileName.TabIndex = 17;
            // 
            // xtraFolderBrowserDialog1
            // 
            xtraFolderBrowserDialog1.SelectedPath = "xtraFolderBrowserDialog1";
            // 
            // frmBackup
            // 
            Appearance.BackColor = Color.FromArgb(188, 199, 216);
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 189);
            Controls.Add(btnCreate);
            Controls.Add(labelControl1);
            Controls.Add(btnOpenFileDialog);
            Controls.Add(txtFileName);
            Font = new System.Drawing.Font("Cairo", 8.5F);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBackup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إنشاء نسخة إحتياطية";
            ((System.ComponentModel.ISupportInitialize)txtFileName.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCreate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOpenFileDialog;
        private DevExpress.XtraEditors.TextEdit txtFileName;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog xtraFolderBrowserDialog1;
    }
}