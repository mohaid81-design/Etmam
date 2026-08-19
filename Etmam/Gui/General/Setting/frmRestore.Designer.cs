namespace Etmam
{
    partial class frmRestore
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
            btnRestore = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            btnOpenFileDialog = new DevExpress.XtraEditors.SimpleButton();
            txtFileName = new DevExpress.XtraEditors.TextEdit();
            xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(components);
            ((System.ComponentModel.ISupportInitialize)txtFileName.Properties).BeginInit();
            SuspendLayout();
            // 
            // btnRestore
            // 
            btnRestore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestore.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            btnRestore.Appearance.Options.UseFont = true;
            btnRestore.ImageOptions.ImageIndex = 8;
            btnRestore.Location = new Point(29, 135);
            btnRestore.Margin = new Padding(3, 2, 3, 2);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(202, 36);
            btnRestore.TabIndex = 24;
            btnRestore.Text = "إستعادة النسخة الإحتياطية";
            btnRestore.Click += btnRestore_Click;
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(382, 16);
            labelControl1.Margin = new Padding(3, 4, 3, 4);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(233, 29);
            labelControl1.TabIndex = 23;
            labelControl1.Text = "قم بتحديد مسار حفظ النسخة الإحتياطية";
            // 
            // btnOpenFileDialog
            // 
            btnOpenFileDialog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenFileDialog.Appearance.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            btnOpenFileDialog.Appearance.Options.UseFont = true;
            btnOpenFileDialog.Location = new Point(29, 63);
            btnOpenFileDialog.Margin = new Padding(3, 4, 3, 4);
            btnOpenFileDialog.Name = "btnOpenFileDialog";
            btnOpenFileDialog.Size = new Size(105, 30);
            btnOpenFileDialog.TabIndex = 22;
            btnOpenFileDialog.Text = "...";
            btnOpenFileDialog.Click += btnOpenFileDialog_Click;
            // 
            // txtFileName
            // 
            txtFileName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtFileName.Location = new Point(140, 63);
            txtFileName.Margin = new Padding(3, 4, 3, 4);
            txtFileName.Name = "txtFileName";
            txtFileName.RightToLeft = RightToLeft.No;
            txtFileName.Size = new Size(475, 30);
            txtFileName.TabIndex = 21;
            // 
            // xtraOpenFileDialog1
            // 
            xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // frmRestore
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new Size(627, 197);
            Controls.Add(btnRestore);
            Controls.Add(labelControl1);
            Controls.Add(btnOpenFileDialog);
            Controls.Add(txtFileName);
            Font = new System.Drawing.Font("Cairo", 8.5F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRestore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إستعادة نسخة إحتياطية";
            ((System.ComponentModel.ISupportInitialize)txtFileName.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOpenFileDialog;
        private DevExpress.XtraEditors.TextEdit txtFileName;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
    }
}