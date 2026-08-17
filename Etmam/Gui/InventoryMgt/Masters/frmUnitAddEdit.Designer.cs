namespace Etmam
{
    partial class frmUnitAddEdit
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
            txtDescription = new DevExpress.XtraEditors.TextEdit();
            txtAbbreviation = new DevExpress.XtraEditors.TextEdit();
            txtCategory = new DevExpress.XtraEditors.TextEdit();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            lcgDescription = new DevExpress.XtraLayout.LayoutControlItem();
            lcgAbbreviation = new DevExpress.XtraLayout.LayoutControlItem();
            lcgCategory = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)pnlButtons).BeginInit();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAbbreviation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgAbbreviation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 250);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(460, 55);
            pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.Font = new Font("Cairo", 8.5F);
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Location = new Point(132, 12);
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
            btnSave.Location = new Point(12, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // layoutControl
            // 
            layoutControl.Controls.Add(txtDescription);
            layoutControl.Controls.Add(txtAbbreviation);
            layoutControl.Controls.Add(txtCategory);
            layoutControl.Dock = DockStyle.Fill;
            layoutControl.Location = new Point(0, 0);
            layoutControl.Name = "layoutControl";
            layoutControl.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl.Root = layoutControlGroup1;
            layoutControl.Size = new Size(460, 250);
            layoutControl.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 12);
            txtDescription.Name = "txtDescription";
            txtDescription.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtDescription.Properties.Appearance.Options.UseFont = true;
            txtDescription.Size = new Size(367, 26);
            txtDescription.StyleController = layoutControl;
            txtDescription.TabIndex = 0;
            // 
            // txtAbbreviation
            // 
            txtAbbreviation.Location = new Point(12, 42);
            txtAbbreviation.Name = "txtAbbreviation";
            txtAbbreviation.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtAbbreviation.Properties.Appearance.Options.UseFont = true;
            txtAbbreviation.Size = new Size(367, 26);
            txtAbbreviation.StyleController = layoutControl;
            txtAbbreviation.TabIndex = 1;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(12, 72);
            txtCategory.Name = "txtCategory";
            txtCategory.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtCategory.Properties.Appearance.Options.UseFont = true;
            txtCategory.Size = new Size(367, 26);
            txtCategory.StyleController = layoutControl;
            txtCategory.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lcgDescription, lcgAbbreviation, lcgCategory, emptySpaceItem1 });
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new Size(460, 250);
            layoutControlGroup1.TextVisible = false;
            // 
            // lcgDescription
            // 
            lcgDescription.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgDescription.AppearanceItemCaption.Options.UseFont = true;
            lcgDescription.Control = txtDescription;
            lcgDescription.Location = new Point(0, 0);
            lcgDescription.Name = "lcgDescription";
            lcgDescription.Size = new Size(440, 30);
            lcgDescription.Text = "الوصف:";
            lcgDescription.TextSize = new Size(57, 23);
            // 
            // lcgAbbreviation
            // 
            lcgAbbreviation.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgAbbreviation.AppearanceItemCaption.Options.UseFont = true;
            lcgAbbreviation.Control = txtAbbreviation;
            lcgAbbreviation.Location = new Point(0, 30);
            lcgAbbreviation.Name = "lcgAbbreviation";
            lcgAbbreviation.Size = new Size(440, 30);
            lcgAbbreviation.Text = "الاختصار:";
            lcgAbbreviation.TextSize = new Size(57, 23);
            // 
            // lcgCategory
            // 
            lcgCategory.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgCategory.AppearanceItemCaption.Options.UseFont = true;
            lcgCategory.Control = txtCategory;
            lcgCategory.Location = new Point(0, 60);
            lcgCategory.Name = "lcgCategory";
            lcgCategory.Size = new Size(440, 30);
            lcgCategory.Text = "فئة الوحدة:";
            lcgCategory.TextSize = new Size(57, 23);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 90);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(440, 140);
            // 
            // frmUnitAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 305);
            Controls.Add(layoutControl);
            Controls.Add(pnlButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUnitAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "وحدة قياس";
            ((System.ComponentModel.ISupportInitialize)pnlButtons).EndInit();
            pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAbbreviation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgAbbreviation).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtAbbreviation;
        private DevExpress.XtraEditors.TextEdit txtCategory;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lcgDescription;
        private DevExpress.XtraLayout.LayoutControlItem lcgAbbreviation;
        private DevExpress.XtraLayout.LayoutControlItem lcgCategory;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
