namespace Etmam
{
    partial class frmBOQNew
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblProject = new DevExpress.XtraEditors.LabelControl();
            lueProject = new DevExpress.XtraEditors.LookUpEdit();
            lblBOQName = new DevExpress.XtraEditors.LabelControl();
            txtBOQName = new DevExpress.XtraEditors.TextEdit();
            lblDiscipline = new DevExpress.XtraEditors.LabelControl();
            txtDiscipline = new DevExpress.XtraEditors.TextEdit();
            lblRevision = new DevExpress.XtraEditors.LabelControl();
            txtRevision = new DevExpress.XtraEditors.TextEdit();
            btnOk = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBOQName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDiscipline.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRevision.Properties).BeginInit();
            SuspendLayout();
            //
            // lblProject
            //
            lblProject.Location = new System.Drawing.Point(300, 20);
            lblProject.Name = "lblProject";
            lblProject.Size = new System.Drawing.Size(50, 17);
            lblProject.TabIndex = 0;
            lblProject.Text = "المشروع:*";
            //
            // lueProject
            //
            lueProject.Location = new System.Drawing.Point(20, 40);
            lueProject.Name = "lueProject";
            lueProject.Properties.NullText = "-- اختر المشروع --";
            lueProject.Size = new System.Drawing.Size(360, 28);
            lueProject.TabIndex = 1;
            //
            // lblBOQName
            //
            lblBOQName.Location = new System.Drawing.Point(300, 82);
            lblBOQName.Name = "lblBOQName";
            lblBOQName.Size = new System.Drawing.Size(80, 17);
            lblBOQName.TabIndex = 2;
            lblBOQName.Text = "اسم جدول الكميات:*";
            //
            // txtBOQName
            //
            txtBOQName.Location = new System.Drawing.Point(20, 102);
            txtBOQName.Name = "txtBOQName";
            txtBOQName.Size = new System.Drawing.Size(360, 28);
            txtBOQName.TabIndex = 3;
            //
            // lblDiscipline
            //
            lblDiscipline.Location = new System.Drawing.Point(300, 144);
            lblDiscipline.Name = "lblDiscipline";
            lblDiscipline.Size = new System.Drawing.Size(45, 17);
            lblDiscipline.TabIndex = 4;
            lblDiscipline.Text = "التخصص:";
            //
            // txtDiscipline
            //
            txtDiscipline.Location = new System.Drawing.Point(20, 164);
            txtDiscipline.Name = "txtDiscipline";
            txtDiscipline.Size = new System.Drawing.Size(360, 28);
            txtDiscipline.TabIndex = 5;
            //
            // lblRevision
            //
            lblRevision.Location = new System.Drawing.Point(300, 206);
            lblRevision.Name = "lblRevision";
            lblRevision.Size = new System.Drawing.Size(52, 17);
            lblRevision.TabIndex = 6;
            lblRevision.Text = "المراجعة:";
            //
            // txtRevision
            //
            txtRevision.EditValue = "R0";
            txtRevision.Location = new System.Drawing.Point(20, 226);
            txtRevision.Name = "txtRevision";
            txtRevision.Size = new System.Drawing.Size(360, 28);
            txtRevision.TabIndex = 7;
            //
            // btnOk
            //
            btnOk.Location = new System.Drawing.Point(220, 274);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(160, 36);
            btnOk.TabIndex = 8;
            btnOk.Text = "إنشاء";
            btnOk.Click += btnOk_Click;
            //
            // btnCancel
            //
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(20, 274);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(160, 36);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "إلغاء";
            //
            // frmBOQNew
            //
            AcceptButton = btnOk;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(400, 330);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtRevision);
            Controls.Add(lblRevision);
            Controls.Add(txtDiscipline);
            Controls.Add(lblDiscipline);
            Controls.Add(txtBOQName);
            Controls.Add(lblBOQName);
            Controls.Add(lueProject);
            Controls.Add(lblProject);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBOQNew";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "جدول كميات جديد";

            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBOQName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDiscipline.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRevision.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.LookUpEdit lueProject;
        private DevExpress.XtraEditors.LabelControl lblBOQName;
        private DevExpress.XtraEditors.TextEdit txtBOQName;
        private DevExpress.XtraEditors.LabelControl lblDiscipline;
        private DevExpress.XtraEditors.TextEdit txtDiscipline;
        private DevExpress.XtraEditors.LabelControl lblRevision;
        private DevExpress.XtraEditors.TextEdit txtRevision;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
