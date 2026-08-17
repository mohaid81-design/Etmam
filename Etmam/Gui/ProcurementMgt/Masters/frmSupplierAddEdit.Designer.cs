namespace Etmam
{
    partial class frmSupplierAddEdit
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
            txtName = new DevExpress.XtraEditors.TextEdit();
            txtPhone = new DevExpress.XtraEditors.TextEdit();
            txtEmail = new DevExpress.XtraEditors.TextEdit();
            txtContactName = new DevExpress.XtraEditors.TextEdit();
            txtContactPhone = new DevExpress.XtraEditors.TextEdit();
            txtCommercialNumber = new DevExpress.XtraEditors.TextEdit();
            txtTaxNumber = new DevExpress.XtraEditors.TextEdit();
            txtVatNumber = new DevExpress.XtraEditors.TextEdit();
            spinPaymentTerms = new DevExpress.XtraEditors.SpinEdit();
            spinCreditLimit = new DevExpress.XtraEditors.SpinEdit();
            spinRating = new DevExpress.XtraEditors.SpinEdit();
            checkActive = new DevExpress.XtraEditors.CheckEdit();
            radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            lcgName = new DevExpress.XtraLayout.LayoutControlItem();
            lcgPhone = new DevExpress.XtraLayout.LayoutControlItem();
            lcgEmail = new DevExpress.XtraLayout.LayoutControlItem();
            lcgContactName = new DevExpress.XtraLayout.LayoutControlItem();
            lcgContactPhone = new DevExpress.XtraLayout.LayoutControlItem();
            lcgCommercialNumber = new DevExpress.XtraLayout.LayoutControlItem();
            lcgTaxNumber = new DevExpress.XtraLayout.LayoutControlItem();
            lcgVatNumber = new DevExpress.XtraLayout.LayoutControlItem();
            lcgPaymentTerms = new DevExpress.XtraLayout.LayoutControlItem();
            lcgCreditLimit = new DevExpress.XtraLayout.LayoutControlItem();
            lcgRating = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            lcgActive = new DevExpress.XtraLayout.LayoutControlItem();
            lcgCategory = new DevExpress.XtraLayout.LayoutControlItem();
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)pnlButtons).BeginInit();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl).BeginInit();
            layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtContactName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtContactPhone.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCommercialNumber.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTaxNumber.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVatNumber.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinPaymentTerms.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinCreditLimit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinRating.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radioGroup1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgContactName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgContactPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgCommercialNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgTaxNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgVatNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgPaymentTerms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgCreditLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgRating).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            xtraTabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 536);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(539, 55);
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
            layoutControl.Controls.Add(txtName);
            layoutControl.Controls.Add(txtPhone);
            layoutControl.Controls.Add(txtEmail);
            layoutControl.Controls.Add(txtContactName);
            layoutControl.Controls.Add(txtContactPhone);
            layoutControl.Controls.Add(txtCommercialNumber);
            layoutControl.Controls.Add(txtTaxNumber);
            layoutControl.Controls.Add(txtVatNumber);
            layoutControl.Controls.Add(spinPaymentTerms);
            layoutControl.Controls.Add(spinCreditLimit);
            layoutControl.Controls.Add(spinRating);
            layoutControl.Controls.Add(checkActive);
            layoutControl.Controls.Add(radioGroup1);
            layoutControl.Dock = DockStyle.Fill;
            layoutControl.Location = new Point(0, 0);
            layoutControl.Name = "layoutControl";
            layoutControl.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl.Root = layoutControlGroup1;
            layoutControl.Size = new Size(537, 511);
            layoutControl.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 50);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Size = new Size(407, 26);
            txtName.StyleController = layoutControl;
            txtName.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(12, 80);
            txtPhone.Name = "txtPhone";
            txtPhone.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtPhone.Properties.Appearance.Options.UseFont = true;
            txtPhone.Size = new Size(407, 26);
            txtPhone.StyleController = layoutControl;
            txtPhone.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtEmail.Properties.Appearance.Options.UseFont = true;
            txtEmail.Size = new Size(407, 26);
            txtEmail.StyleController = layoutControl;
            txtEmail.TabIndex = 5;
            // 
            // txtContactName
            // 
            txtContactName.Location = new Point(12, 140);
            txtContactName.Name = "txtContactName";
            txtContactName.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtContactName.Properties.Appearance.Options.UseFont = true;
            txtContactName.Size = new Size(407, 26);
            txtContactName.StyleController = layoutControl;
            txtContactName.TabIndex = 6;
            // 
            // txtContactPhone
            // 
            txtContactPhone.Location = new Point(12, 170);
            txtContactPhone.Name = "txtContactPhone";
            txtContactPhone.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtContactPhone.Properties.Appearance.Options.UseFont = true;
            txtContactPhone.Size = new Size(407, 26);
            txtContactPhone.StyleController = layoutControl;
            txtContactPhone.TabIndex = 7;
            // 
            // txtCommercialNumber
            // 
            txtCommercialNumber.Location = new Point(12, 200);
            txtCommercialNumber.Name = "txtCommercialNumber";
            txtCommercialNumber.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtCommercialNumber.Properties.Appearance.Options.UseFont = true;
            txtCommercialNumber.Size = new Size(407, 26);
            txtCommercialNumber.StyleController = layoutControl;
            txtCommercialNumber.TabIndex = 8;
            // 
            // txtTaxNumber
            // 
            txtTaxNumber.Location = new Point(12, 230);
            txtTaxNumber.Name = "txtTaxNumber";
            txtTaxNumber.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtTaxNumber.Properties.Appearance.Options.UseFont = true;
            txtTaxNumber.Size = new Size(407, 26);
            txtTaxNumber.StyleController = layoutControl;
            txtTaxNumber.TabIndex = 9;
            // 
            // txtVatNumber
            // 
            txtVatNumber.Location = new Point(12, 260);
            txtVatNumber.Name = "txtVatNumber";
            txtVatNumber.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            txtVatNumber.Properties.Appearance.Options.UseFont = true;
            txtVatNumber.Size = new Size(407, 26);
            txtVatNumber.StyleController = layoutControl;
            txtVatNumber.TabIndex = 10;
            // 
            // spinPaymentTerms
            // 
            spinPaymentTerms.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            spinPaymentTerms.Location = new Point(12, 290);
            spinPaymentTerms.Name = "spinPaymentTerms";
            spinPaymentTerms.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            spinPaymentTerms.Properties.Appearance.Options.UseFont = true;
            spinPaymentTerms.Properties.IsFloatValue = false;
            spinPaymentTerms.Properties.MaxValue = new decimal(new int[] { 365, 0, 0, 0 });
            spinPaymentTerms.Size = new Size(407, 26);
            spinPaymentTerms.StyleController = layoutControl;
            spinPaymentTerms.TabIndex = 11;
            // 
            // spinCreditLimit
            // 
            spinCreditLimit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            spinCreditLimit.Location = new Point(12, 320);
            spinCreditLimit.Name = "spinCreditLimit";
            spinCreditLimit.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            spinCreditLimit.Properties.Appearance.Options.UseFont = true;
            spinCreditLimit.Properties.MaxValue = new decimal(new int[] { 100000000, 0, 0, 0 });
            spinCreditLimit.Size = new Size(407, 26);
            spinCreditLimit.StyleController = layoutControl;
            spinCreditLimit.TabIndex = 12;
            // 
            // spinRating
            // 
            spinRating.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            spinRating.Location = new Point(12, 350);
            spinRating.Name = "spinRating";
            spinRating.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            spinRating.Properties.Appearance.Options.UseFont = true;
            spinRating.Properties.IsFloatValue = false;
            spinRating.Properties.MaxValue = new decimal(new int[] { 5, 0, 0, 0 });
            spinRating.Size = new Size(407, 26);
            spinRating.StyleController = layoutControl;
            spinRating.TabIndex = 13;
            // 
            // checkActive
            // 
            checkActive.EditValue = true;
            checkActive.Location = new Point(118, 12);
            checkActive.Name = "checkActive";
            checkActive.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            checkActive.Properties.Appearance.Options.UseFont = true;
            checkActive.Properties.Caption = "نشط";
            checkActive.Size = new Size(46, 27);
            checkActive.StyleController = layoutControl;
            checkActive.TabIndex = 2;
            // 
            // radioGroup1
            // 
            radioGroup1.Location = new Point(168, 12);
            radioGroup1.Name = "radioGroup1";
            radioGroup1.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            radioGroup1.Properties.Appearance.Options.UseFont = true;
            radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "فرد"), new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "شركة/ مؤسسة") });
            radioGroup1.Size = new Size(251, 34);
            radioGroup1.StyleController = layoutControl;
            radioGroup1.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lcgName, lcgPhone, lcgEmail, lcgContactName, lcgContactPhone, lcgCommercialNumber, lcgTaxNumber, lcgVatNumber, lcgPaymentTerms, lcgCreditLimit, lcgRating, emptySpaceItem1, lcgActive, lcgCategory });
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new Size(537, 511);
            layoutControlGroup1.TextVisible = false;
            // 
            // lcgName
            // 
            lcgName.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgName.AppearanceItemCaption.Options.UseFont = true;
            lcgName.Control = txtName;
            lcgName.Location = new Point(0, 38);
            lcgName.Name = "lcgName";
            lcgName.Size = new Size(517, 30);
            lcgName.Text = "اسم المورد:";
            lcgName.TextSize = new Size(94, 23);
            // 
            // lcgPhone
            // 
            lcgPhone.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgPhone.AppearanceItemCaption.Options.UseFont = true;
            lcgPhone.Control = txtPhone;
            lcgPhone.Location = new Point(0, 68);
            lcgPhone.Name = "lcgPhone";
            lcgPhone.Size = new Size(517, 30);
            lcgPhone.Text = "الجوال:";
            lcgPhone.TextSize = new Size(94, 23);
            // 
            // lcgEmail
            // 
            lcgEmail.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgEmail.AppearanceItemCaption.Options.UseFont = true;
            lcgEmail.Control = txtEmail;
            lcgEmail.Location = new Point(0, 98);
            lcgEmail.Name = "lcgEmail";
            lcgEmail.Size = new Size(517, 30);
            lcgEmail.Text = "البريد الإلكتروني:";
            lcgEmail.TextSize = new Size(94, 23);
            // 
            // lcgContactName
            // 
            lcgContactName.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgContactName.AppearanceItemCaption.Options.UseFont = true;
            lcgContactName.Control = txtContactName;
            lcgContactName.Location = new Point(0, 128);
            lcgContactName.Name = "lcgContactName";
            lcgContactName.Size = new Size(517, 30);
            lcgContactName.Text = "اسم جهة الاتصال:";
            lcgContactName.TextSize = new Size(94, 23);
            // 
            // lcgContactPhone
            // 
            lcgContactPhone.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgContactPhone.AppearanceItemCaption.Options.UseFont = true;
            lcgContactPhone.Control = txtContactPhone;
            lcgContactPhone.Location = new Point(0, 158);
            lcgContactPhone.Name = "lcgContactPhone";
            lcgContactPhone.Size = new Size(517, 30);
            lcgContactPhone.Text = "جوال جهة الاتصال:";
            lcgContactPhone.TextSize = new Size(94, 23);
            // 
            // lcgCommercialNumber
            // 
            lcgCommercialNumber.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgCommercialNumber.AppearanceItemCaption.Options.UseFont = true;
            lcgCommercialNumber.Control = txtCommercialNumber;
            lcgCommercialNumber.Location = new Point(0, 188);
            lcgCommercialNumber.Name = "lcgCommercialNumber";
            lcgCommercialNumber.Size = new Size(517, 30);
            lcgCommercialNumber.Text = "السجل التجاري:";
            lcgCommercialNumber.TextSize = new Size(94, 23);
            // 
            // lcgTaxNumber
            // 
            lcgTaxNumber.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgTaxNumber.AppearanceItemCaption.Options.UseFont = true;
            lcgTaxNumber.Control = txtTaxNumber;
            lcgTaxNumber.Location = new Point(0, 218);
            lcgTaxNumber.Name = "lcgTaxNumber";
            lcgTaxNumber.Size = new Size(517, 30);
            lcgTaxNumber.Text = "الرقم الضريبي:";
            lcgTaxNumber.TextSize = new Size(94, 23);
            // 
            // lcgVatNumber
            // 
            lcgVatNumber.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgVatNumber.AppearanceItemCaption.Options.UseFont = true;
            lcgVatNumber.Control = txtVatNumber;
            lcgVatNumber.Location = new Point(0, 248);
            lcgVatNumber.Name = "lcgVatNumber";
            lcgVatNumber.Size = new Size(517, 30);
            lcgVatNumber.Text = "الرقم الضريبي (VAT):";
            lcgVatNumber.TextSize = new Size(94, 23);
            // 
            // lcgPaymentTerms
            // 
            lcgPaymentTerms.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgPaymentTerms.AppearanceItemCaption.Options.UseFont = true;
            lcgPaymentTerms.Control = spinPaymentTerms;
            lcgPaymentTerms.Location = new Point(0, 278);
            lcgPaymentTerms.Name = "lcgPaymentTerms";
            lcgPaymentTerms.Size = new Size(517, 30);
            lcgPaymentTerms.Text = "مدة السداد (يوم):";
            lcgPaymentTerms.TextSize = new Size(94, 23);
            // 
            // lcgCreditLimit
            // 
            lcgCreditLimit.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgCreditLimit.AppearanceItemCaption.Options.UseFont = true;
            lcgCreditLimit.Control = spinCreditLimit;
            lcgCreditLimit.Location = new Point(0, 308);
            lcgCreditLimit.Name = "lcgCreditLimit";
            lcgCreditLimit.Size = new Size(517, 30);
            lcgCreditLimit.Text = "سقف الائتمان:";
            lcgCreditLimit.TextSize = new Size(94, 23);
            // 
            // lcgRating
            // 
            lcgRating.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgRating.AppearanceItemCaption.Options.UseFont = true;
            lcgRating.Control = spinRating;
            lcgRating.Location = new Point(0, 338);
            lcgRating.Name = "lcgRating";
            lcgRating.Size = new Size(517, 30);
            lcgRating.Text = "التقييم (0-5):";
            lcgRating.TextSize = new Size(94, 23);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 368);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(517, 123);
            // 
            // lcgActive
            // 
            lcgActive.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgActive.AppearanceItemCaption.Options.UseFont = true;
            lcgActive.Control = checkActive;
            lcgActive.Location = new Point(0, 0);
            lcgActive.Name = "lcgActive";
            lcgActive.Size = new Size(156, 38);
            lcgActive.Text = " ";
            lcgActive.TextLocation = DevExpress.Utils.Locations.Left;
            lcgActive.TextSize = new Size(94, 20);
            // 
            // lcgCategory
            // 
            lcgCategory.AppearanceItemCaption.Font = new Font("Cairo", 8.5F);
            lcgCategory.AppearanceItemCaption.Options.UseFont = true;
            lcgCategory.Control = radioGroup1;
            lcgCategory.Location = new Point(156, 0);
            lcgCategory.Name = "lcgCategory";
            lcgCategory.Size = new Size(361, 38);
            lcgCategory.Text = "تصنيف المورد";
            lcgCategory.TextSize = new Size(94, 23);
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.Dock = DockStyle.Fill;
            xtraTabControl1.Location = new Point(0, 0);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabControl1.Size = new Size(539, 536);
            xtraTabControl1.TabIndex = 2;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage5 });
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(layoutControl);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new Size(537, 511);
            xtraTabPage1.Text = "البيانات الأساسية";
            // 
            // xtraTabPage5
            // 
            xtraTabPage5.Name = "xtraTabPage5";
            xtraTabPage5.Size = new Size(690, 423);
            xtraTabPage5.Text = "شعار الشركة";
            // 
            // frmSupplierAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 591);
            Controls.Add(xtraTabControl1);
            Controls.Add(pnlButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSupplierAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "مورد";
            ((System.ComponentModel.ISupportInitialize)pnlButtons).EndInit();
            pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl).EndInit();
            layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtContactName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtContactPhone.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCommercialNumber.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTaxNumber.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVatNumber.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinPaymentTerms.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinCreditLimit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinRating.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)radioGroup1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgName).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgPhone).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgContactName).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgContactPhone).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgCommercialNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgTaxNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgVatNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgPaymentTerms).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgCreditLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgRating).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);
            xtraTabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtContactName;
        private DevExpress.XtraEditors.TextEdit txtContactPhone;
        private DevExpress.XtraEditors.TextEdit txtCommercialNumber;
        private DevExpress.XtraEditors.TextEdit txtTaxNumber;
        private DevExpress.XtraEditors.TextEdit txtVatNumber;
        private DevExpress.XtraEditors.SpinEdit spinPaymentTerms;
        private DevExpress.XtraEditors.SpinEdit spinCreditLimit;
        private DevExpress.XtraEditors.SpinEdit spinRating;
        private DevExpress.XtraEditors.CheckEdit checkActive;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lcgName;
        private DevExpress.XtraLayout.LayoutControlItem lcgPhone;
        private DevExpress.XtraLayout.LayoutControlItem lcgEmail;
        private DevExpress.XtraLayout.LayoutControlItem lcgContactName;
        private DevExpress.XtraLayout.LayoutControlItem lcgContactPhone;
        private DevExpress.XtraLayout.LayoutControlItem lcgCommercialNumber;
        private DevExpress.XtraLayout.LayoutControlItem lcgTaxNumber;
        private DevExpress.XtraLayout.LayoutControlItem lcgVatNumber;
        private DevExpress.XtraLayout.LayoutControlItem lcgPaymentTerms;
        private DevExpress.XtraLayout.LayoutControlItem lcgCreditLimit;
        private DevExpress.XtraLayout.LayoutControlItem lcgRating;
        private DevExpress.XtraLayout.LayoutControlItem lcgActive;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lcgCategory;
    }
}
