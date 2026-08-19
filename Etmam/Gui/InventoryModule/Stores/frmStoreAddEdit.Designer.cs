namespace Etmam
{
    partial class frmStoreAddEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlButtons = new DevExpress.XtraEditors.PanelControl();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            layoutControl = new DevExpress.XtraLayout.LayoutControl();
            txtCode = new DevExpress.XtraEditors.TextEdit();
            txtName = new DevExpress.XtraEditors.TextEdit();
            checkActive = new DevExpress.XtraEditors.CheckEdit();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            lcgCode = new DevExpress.XtraLayout.LayoutControlItem();
            lcgName = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            lcgActive = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)pnlButtons).BeginInit();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgActive).BeginInit();
            SuspendLayout();
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 155);
            pnlButtons.Margin = new Padding(3, 5, 3, 5);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(464, 55);
            pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.Font = new Font("Cairo", 8.5F);
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Location = new Point(132, 13);
            btnCancel.Margin = new Padding(3, 5, 3, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "إلغاء";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Appearance.Font = new Font("Cairo", 8.5F);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Location = new Point(12, 13);
            btnSave.Margin = new Padding(3, 5, 3, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(txtCode);
            layoutControl.Controls.Add(txtName);
            layoutControl.Controls.Add(checkActive);
            layoutControl.Dock = DockStyle.Fill;
            layoutControl.Location = new Point(0, 0);
            layoutControl.Margin = new Padding(3, 5, 3, 5);
            layoutControl.Name = "layoutControl";
            layoutControl.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl.Root = layoutControlGroup1;
            layoutControl.Size = new Size(464, 155);
            layoutControl.TabIndex = 0;
            // 
            // txtCode
            // 
            txtCode.Enabled = false;
            txtCode.Location = new Point(12, 43);
            txtCode.Margin = new Padding(3, 5, 3, 5);
            txtCode.Name = "txtCode";
            txtCode.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtCode.Properties.Appearance.Options.UseFont = true;
            txtCode.Size = new Size(368, 26);
            txtCode.StyleController = layoutControl;
            txtCode.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 73);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Size = new Size(368, 26);
            txtName.StyleController = layoutControl;
            txtName.TabIndex = 1;
            // 
            // checkActive
            // 
            checkActive.Location = new Point(12, 12);
            checkActive.Margin = new Padding(3, 5, 3, 5);
            checkActive.Name = "checkActive";
            checkActive.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            checkActive.Properties.Appearance.Options.UseFont = true;
            checkActive.Properties.Caption = "نشط";
            checkActive.Size = new Size(368, 27);
            checkActive.StyleController = layoutControl;
            checkActive.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lcgCode, lcgName, emptySpaceItem1, lcgActive });
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new Size(464, 155);
            layoutControlGroup1.TextVisible = false;
            // 
            // lcgCode
            // 
            lcgCode.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgCode.AppearanceItemCaption.Options.UseFont = true;
            lcgCode.Control = txtCode;
            lcgCode.Location = new Point(0, 31);
            lcgCode.Name = "lcgCode";
            lcgCode.Size = new Size(444, 30);
            lcgCode.Text = "الرمز:";
            lcgCode.TextSize = new Size(60, 23);
            // 
            // lcgName
            // 
            lcgName.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgName.AppearanceItemCaption.Options.UseFont = true;
            lcgName.Control = txtName;
            lcgName.Location = new Point(0, 61);
            lcgName.Name = "lcgName";
            lcgName.Size = new Size(444, 30);
            lcgName.Text = "اسم المخزن:";
            lcgName.TextSize = new Size(60, 23);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 91);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(444, 44);
            // 
            // lcgActive
            // 
            lcgActive.Control = checkActive;
            lcgActive.Location = new Point(0, 0);
            lcgActive.Name = "lcgActive";
            lcgActive.Size = new Size(444, 31);
            lcgActive.Text = " ";
            lcgActive.TextSize = new Size(60, 20);
            // 
            // frmStoreAddEdit
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 210);
            Controls.Add(layoutControl);
            Controls.Add(pnlButtons);
            Font = new Font("Cairo", 8.249999F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 5, 3, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmStoreAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "مخزن";
            ((System.ComponentModel.ISupportInitialize)pnlButtons).EndInit();
            pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgName).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgActive).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.CheckEdit checkActive;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lcgCode;
        private DevExpress.XtraLayout.LayoutControlItem lcgName;
        private DevExpress.XtraLayout.LayoutControlItem lcgActive;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
