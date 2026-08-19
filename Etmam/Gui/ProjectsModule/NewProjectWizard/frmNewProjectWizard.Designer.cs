namespace Etmam
{
    partial class frmNewProjectWizard
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
            wizProject = new DevExpress.XtraWizard.WizardControl();

            wizPageGeneral = new DevExpress.XtraWizard.WizardPage();
            lblProjectCode = new DevExpress.XtraEditors.LabelControl();
            txtProjectCode = new DevExpress.XtraEditors.TextEdit();
            lblProjectNameAr = new DevExpress.XtraEditors.LabelControl();
            txtProjectNameAr = new DevExpress.XtraEditors.TextEdit();

            wizPageOwnerConsultant = new DevExpress.XtraWizard.WizardPage();
            lblOwner = new DevExpress.XtraEditors.LabelControl();
            lueOwner = new DevExpress.XtraEditors.LookUpEdit();
            lblConsultant = new DevExpress.XtraEditors.LabelControl();
            lueConsultant = new DevExpress.XtraEditors.LookUpEdit();

            wizPageDates = new DevExpress.XtraWizard.WizardPage();
            lblStartDate = new DevExpress.XtraEditors.LabelControl();
            dtStart = new DevExpress.XtraEditors.DateEdit();

            wizPageFinancial = new DevExpress.XtraWizard.WizardPage();
            lblContractValue = new DevExpress.XtraEditors.LabelControl();
            calcContractValue = new DevExpress.XtraEditors.CalcEdit();

            wizPageReview = new DevExpress.XtraWizard.WizardPage();
            lblReviewTitle = new DevExpress.XtraEditors.LabelControl();
            grdReviewSummary = new DevExpress.XtraGrid.GridControl();
            gvReviewSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            colReviewField = new DevExpress.XtraGrid.Columns.GridColumn();
            colReviewValue = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)wizProject).BeginInit();
            wizProject.SuspendLayout();

            wizPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtProjectCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProjectNameAr.Properties).BeginInit();

            wizPageOwnerConsultant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lueOwner.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueConsultant.Properties).BeginInit();

            wizPageDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtStart.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtStart.Properties.CalendarTimeProperties).BeginInit();

            wizPageFinancial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)calcContractValue.Properties).BeginInit();

            wizPageReview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdReviewSummary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvReviewSummary).BeginInit();

            SuspendLayout();
            //
            // wizPageGeneral
            //
            wizPageGeneral.Controls.Add(txtProjectNameAr);
            wizPageGeneral.Controls.Add(lblProjectNameAr);
            wizPageGeneral.Controls.Add(txtProjectCode);
            wizPageGeneral.Controls.Add(lblProjectCode);
            wizPageGeneral.DescriptionText = "بيانات التعريف الأساسية للمشروع";
            wizPageGeneral.Name = "wizPageGeneral";
            wizPageGeneral.Size = new Size(860, 380);
            wizPageGeneral.Text = "معلومات عامة";
            //
            // lblProjectCode
            //
            lblProjectCode.Appearance.Font = new Font("Cairo", 8F);
            lblProjectCode.Appearance.Options.UseFont = true;
            lblProjectCode.Location = new Point(20, 20);
            lblProjectCode.Name = "lblProjectCode";
            lblProjectCode.Size = new Size(60, 17);
            lblProjectCode.TabIndex = 0;
            lblProjectCode.Text = "رمز المشروع";
            //
            // txtProjectCode
            //
            txtProjectCode.Location = new Point(20, 38);
            txtProjectCode.Name = "txtProjectCode";
            txtProjectCode.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtProjectCode.Properties.Appearance.Options.UseFont = true;
            txtProjectCode.Size = new Size(380, 28);
            txtProjectCode.TabIndex = 1;
            //
            // lblProjectNameAr
            //
            lblProjectNameAr.Appearance.Font = new Font("Cairo", 8F);
            lblProjectNameAr.Appearance.Options.UseFont = true;
            lblProjectNameAr.Location = new Point(20, 74);
            lblProjectNameAr.Name = "lblProjectNameAr";
            lblProjectNameAr.Size = new Size(97, 17);
            lblProjectNameAr.TabIndex = 2;
            lblProjectNameAr.Text = "اسم المشروع";
            //
            // txtProjectNameAr
            //
            txtProjectNameAr.Location = new Point(20, 92);
            txtProjectNameAr.Name = "txtProjectNameAr";
            txtProjectNameAr.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtProjectNameAr.Properties.Appearance.Options.UseFont = true;
            txtProjectNameAr.Size = new Size(380, 28);
            txtProjectNameAr.TabIndex = 3;
            //
            // wizPageOwnerConsultant
            //
            wizPageOwnerConsultant.Controls.Add(lueConsultant);
            wizPageOwnerConsultant.Controls.Add(lblConsultant);
            wizPageOwnerConsultant.Controls.Add(lueOwner);
            wizPageOwnerConsultant.Controls.Add(lblOwner);
            wizPageOwnerConsultant.DescriptionText = "أطراف المشروع";
            wizPageOwnerConsultant.Name = "wizPageOwnerConsultant";
            wizPageOwnerConsultant.Size = new Size(860, 380);
            wizPageOwnerConsultant.Text = "المالك والاستشاري";
            //
            // lblOwner
            //
            lblOwner.Appearance.Font = new Font("Cairo", 8F);
            lblOwner.Appearance.Options.UseFont = true;
            lblOwner.Location = new Point(20, 20);
            lblOwner.Name = "lblOwner";
            lblOwner.Size = new Size(80, 17);
            lblOwner.TabIndex = 0;
            lblOwner.Text = "المالك/العميل";
            //
            // lueOwner
            //
            lueOwner.Location = new Point(20, 38);
            lueOwner.Name = "lueOwner";
            lueOwner.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueOwner.Properties.Appearance.Options.UseFont = true;
            lueOwner.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "الاسم") });
            lueOwner.Properties.NullText = "-- اختر المالك --";
            lueOwner.Size = new Size(800, 28);
            lueOwner.TabIndex = 1;
            //
            // lblConsultant
            //
            lblConsultant.Appearance.Font = new Font("Cairo", 8F);
            lblConsultant.Appearance.Options.UseFont = true;
            lblConsultant.Location = new Point(20, 74);
            lblConsultant.Name = "lblConsultant";
            lblConsultant.Size = new Size(51, 17);
            lblConsultant.TabIndex = 2;
            lblConsultant.Text = "الاستشاري";
            //
            // lueConsultant
            //
            lueConsultant.Location = new Point(20, 92);
            lueConsultant.Name = "lueConsultant";
            lueConsultant.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueConsultant.Properties.Appearance.Options.UseFont = true;
            lueConsultant.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "الاسم") });
            lueConsultant.Properties.NullText = "-- اختر الاستشاري --";
            lueConsultant.Size = new Size(800, 28);
            lueConsultant.TabIndex = 3;
            //
            // wizPageDates
            //
            wizPageDates.Controls.Add(dtStart);
            wizPageDates.Controls.Add(lblStartDate);
            wizPageDates.DescriptionText = "تاريخ العقد";
            wizPageDates.Name = "wizPageDates";
            wizPageDates.Size = new Size(860, 380);
            wizPageDates.Text = "التواريخ";
            //
            // lblStartDate
            //
            lblStartDate.Appearance.Font = new Font("Cairo", 8F);
            lblStartDate.Appearance.Options.UseFont = true;
            lblStartDate.Location = new Point(20, 20);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(56, 17);
            lblStartDate.TabIndex = 0;
            lblStartDate.Text = "تاريخ العقد";
            //
            // dtStart
            //
            dtStart.EditValue = null;
            dtStart.Location = new Point(20, 38);
            dtStart.Name = "dtStart";
            dtStart.Properties.Appearance.Font = new Font("Cairo", 9F);
            dtStart.Properties.Appearance.Options.UseFont = true;
            dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtStart.Size = new Size(380, 28);
            dtStart.TabIndex = 1;
            //
            // wizPageFinancial
            //
            wizPageFinancial.Controls.Add(calcContractValue);
            wizPageFinancial.Controls.Add(lblContractValue);
            wizPageFinancial.DescriptionText = "القيمة المالية للتعاقد";
            wizPageFinancial.Name = "wizPageFinancial";
            wizPageFinancial.Size = new Size(860, 380);
            wizPageFinancial.Text = "البيانات المالية";
            //
            // lblContractValue
            //
            lblContractValue.Appearance.Font = new Font("Cairo", 8F);
            lblContractValue.Appearance.Options.UseFont = true;
            lblContractValue.Location = new Point(20, 20);
            lblContractValue.Name = "lblContractValue";
            lblContractValue.Size = new Size(56, 17);
            lblContractValue.TabIndex = 0;
            lblContractValue.Text = "قيمة العقد";
            //
            // calcContractValue
            //
            calcContractValue.EditValue = null;
            calcContractValue.Location = new Point(20, 38);
            calcContractValue.Name = "calcContractValue";
            calcContractValue.Properties.Appearance.Font = new Font("Cairo", 9F);
            calcContractValue.Properties.Appearance.Options.UseFont = true;
            calcContractValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            calcContractValue.Properties.Appearance.Options.UseTextOptions = true;
            calcContractValue.Properties.DisplayFormat.FormatString = "N2";
            calcContractValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcContractValue.Properties.EditFormat.FormatString = "N2";
            calcContractValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcContractValue.Size = new Size(380, 28);
            calcContractValue.TabIndex = 1;
            //
            // wizPageReview
            //
            wizPageReview.AllowFinish = true;
            wizPageReview.Controls.Add(grdReviewSummary);
            wizPageReview.Controls.Add(lblReviewTitle);
            wizPageReview.DescriptionText = "مراجعة البيانات المدخلة قبل إنشاء المشروع";
            wizPageReview.Name = "wizPageReview";
            wizPageReview.Size = new Size(860, 380);
            wizPageReview.Text = "المراجعة والإنهاء";
            //
            // lblReviewTitle
            //
            lblReviewTitle.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblReviewTitle.Appearance.Options.UseFont = true;
            lblReviewTitle.Location = new Point(20, 20);
            lblReviewTitle.Name = "lblReviewTitle";
            lblReviewTitle.Size = new Size(150, 20);
            lblReviewTitle.TabIndex = 0;
            lblReviewTitle.Text = "ملخص بيانات المشروع";
            //
            // grdReviewSummary
            //
            grdReviewSummary.Location = new Point(20, 46);
            grdReviewSummary.MainView = gvReviewSummary;
            grdReviewSummary.Name = "grdReviewSummary";
            grdReviewSummary.Size = new Size(800, 314);
            grdReviewSummary.TabIndex = 1;
            grdReviewSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvReviewSummary });
            //
            // gvReviewSummary
            //
            gvReviewSummary.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvReviewSummary.Appearance.HeaderPanel.Options.UseFont = true;
            gvReviewSummary.Appearance.Row.Font = new Font("Cairo", 8F);
            gvReviewSummary.Appearance.Row.Options.UseFont = true;
            gvReviewSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colReviewField, colReviewValue });
            gvReviewSummary.GridControl = grdReviewSummary;
            gvReviewSummary.Name = "gvReviewSummary";
            gvReviewSummary.OptionsView.ShowGroupPanel = false;
            //
            // colReviewField
            //
            colReviewField.Caption = "البند";
            colReviewField.FieldName = "FieldName";
            colReviewField.Name = "colReviewField";
            colReviewField.OptionsColumn.AllowEdit = false;
            colReviewField.Visible = true;
            colReviewField.VisibleIndex = 0;
            colReviewField.Width = 280;
            //
            // colReviewValue
            //
            colReviewValue.Caption = "القيمة";
            colReviewValue.FieldName = "FieldValue";
            colReviewValue.Name = "colReviewValue";
            colReviewValue.OptionsColumn.AllowEdit = false;
            colReviewValue.Visible = true;
            colReviewValue.VisibleIndex = 1;
            colReviewValue.Width = 500;
            //
            // wizProject
            //
            wizProject.Dock = DockStyle.Fill;
            wizProject.Location = new Point(0, 0);
            wizProject.Name = "wizProject";
            wizProject.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] { wizPageGeneral, wizPageOwnerConsultant, wizPageDates, wizPageFinancial, wizPageReview });
            wizProject.Size = new Size(900, 640);
            wizProject.TabIndex = 0;
            wizProject.Text = "معالج إنشاء مشروع جديد";
            wizProject.FinishClick += wizProject_FinishClick;
            wizProject.CancelClick += wizProject_CancelClick;
            //
            // frmNewProjectWizard
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 640);
            Controls.Add(wizProject);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNewProjectWizard";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "معالج إنشاء مشروع جديد";

            wizPageGeneral.ResumeLayout(false);
            wizPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtProjectCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProjectNameAr.Properties).EndInit();

            wizPageOwnerConsultant.ResumeLayout(false);
            wizPageOwnerConsultant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lueOwner.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueConsultant.Properties).EndInit();

            wizPageDates.ResumeLayout(false);
            wizPageDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtStart.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtStart.Properties).EndInit();

            wizPageFinancial.ResumeLayout(false);
            wizPageFinancial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)calcContractValue.Properties).EndInit();

            wizPageReview.ResumeLayout(false);
            wizPageReview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdReviewSummary).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvReviewSummary).EndInit();

            ((System.ComponentModel.ISupportInitialize)wizProject).EndInit();
            wizProject.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizProject;

        private DevExpress.XtraWizard.WizardPage wizPageGeneral;
        private DevExpress.XtraEditors.LabelControl lblProjectCode;
        private DevExpress.XtraEditors.TextEdit txtProjectCode;
        private DevExpress.XtraEditors.LabelControl lblProjectNameAr;
        private DevExpress.XtraEditors.TextEdit txtProjectNameAr;

        private DevExpress.XtraWizard.WizardPage wizPageOwnerConsultant;
        private DevExpress.XtraEditors.LabelControl lblOwner;
        private DevExpress.XtraEditors.LookUpEdit lueOwner;
        private DevExpress.XtraEditors.LabelControl lblConsultant;
        private DevExpress.XtraEditors.LookUpEdit lueConsultant;

        private DevExpress.XtraWizard.WizardPage wizPageDates;
        private DevExpress.XtraEditors.LabelControl lblStartDate;
        private DevExpress.XtraEditors.DateEdit dtStart;

        private DevExpress.XtraWizard.WizardPage wizPageFinancial;
        private DevExpress.XtraEditors.LabelControl lblContractValue;
        private DevExpress.XtraEditors.CalcEdit calcContractValue;

        private DevExpress.XtraWizard.WizardPage wizPageReview;
        private DevExpress.XtraEditors.LabelControl lblReviewTitle;
        private DevExpress.XtraGrid.GridControl grdReviewSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReviewSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colReviewField;
        private DevExpress.XtraGrid.Columns.GridColumn colReviewValue;
    }
}
