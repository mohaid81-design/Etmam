namespace Etmam
{
    partial class frmWorkDoneAddEdit
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
            this.txtActivityItem = new DevExpress.XtraEditors.TextEdit();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtQty = new DevExpress.XtraEditors.SpinEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtActivityItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtActivityItem
            // 
            this.txtActivityItem.Location = new System.Drawing.Point(12, 35);
            this.txtActivityItem.Name = "txtActivityItem";
            this.txtActivityItem.Properties.ReadOnly = true;
            this.txtActivityItem.Size = new System.Drawing.Size(360, 28);
            this.txtActivityItem.TabIndex = 0;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(12, 95);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(360, 28);
            this.txtLocation.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 155);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(360, 80);
            this.txtDescription.TabIndex = 2;
            // 
            // txtQty
            // 
            this.txtQty.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.txtQty.Location = new System.Drawing.Point(12, 265);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtQty.Properties.Mask.EditMask = "n2";
            this.txtQty.Size = new System.Drawing.Size(360, 28);
            this.txtQty.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(217, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "حفظ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "إلغاء";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(336, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "إسم البند";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(341, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "الموقع";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(308, 136);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "وصف الأعمال";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(301, 246);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(71, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "الكمية / النسبة";
            // 
            // frmWorkDoneAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtActivityItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWorkDoneAddEdit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تعديل بيانات العمل";
            ((System.ComponentModel.ISupportInitialize)(this.txtActivityItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DevExpress.XtraEditors.TextEdit txtActivityItem;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.SpinEdit txtQty;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
