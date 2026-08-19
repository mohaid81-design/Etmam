namespace Etmam
{
    partial class frmBudgetImportWizard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudgetImportWizard));
            wizardMain = new DevExpress.XtraWizard.WizardControl();
            pagSelectSource = new DevExpress.XtraWizard.WizardPage();
            lblSelectSourceTitle = new DevExpress.XtraEditors.LabelControl();
            lblSelectSourceDesc = new DevExpress.XtraEditors.LabelControl();
            grpSourceType = new DevExpress.XtraEditors.GroupControl();
            rgSourceType = new DevExpress.XtraEditors.RadioGroup();
            pnlFilePicker = new DevExpress.XtraEditors.PanelControl();
            lblFilePath = new DevExpress.XtraEditors.LabelControl();
            txtFilePath = new DevExpress.XtraEditors.TextEdit();
            btnBrowseFile = new DevExpress.XtraEditors.SimpleButton();
            pagMapping = new DevExpress.XtraWizard.WizardPage();
            lblMappingTitle = new DevExpress.XtraEditors.LabelControl();
            lblMappingDesc = new DevExpress.XtraEditors.LabelControl();
            grdMapping = new DevExpress.XtraGrid.GridControl();
            gvMapping = new DevExpress.XtraGrid.Views.Grid.GridView();
            colMappingSourceField = new DevExpress.XtraGrid.Columns.GridColumn();
            colMappingTargetField = new DevExpress.XtraGrid.Columns.GridColumn();
            colMappingRequired = new DevExpress.XtraGrid.Columns.GridColumn();
            colMappingMapped = new DevExpress.XtraGrid.Columns.GridColumn();
            pagValidation = new DevExpress.XtraWizard.WizardPage();
            lblValidationTitle = new DevExpress.XtraEditors.LabelControl();
            grdValidation = new DevExpress.XtraGrid.GridControl();
            gvValidation = new DevExpress.XtraGrid.Views.Grid.GridView();
            colValRow = new DevExpress.XtraGrid.Columns.GridColumn();
            colValField = new DevExpress.XtraGrid.Columns.GridColumn();
            colValMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            colValType = new DevExpress.XtraGrid.Columns.GridColumn();
            pagPreview = new DevExpress.XtraWizard.WizardPage();
            lblPreviewTitle = new DevExpress.XtraEditors.LabelControl();
            grdPreview = new DevExpress.XtraGrid.GridControl();
            gvPreview = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPreviewCostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewTotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            pagResult = new DevExpress.XtraWizard.WizardPage();
            lblResultTitle = new DevExpress.XtraEditors.LabelControl();
            pnlResultSummary = new DevExpress.XtraEditors.PanelControl();
            lblResultTotal = new DevExpress.XtraEditors.LabelControl();
            lblResultSuccess = new DevExpress.XtraEditors.LabelControl();
            lblResultErrors = new DevExpress.XtraEditors.LabelControl();
            svgResultIcon = new DevExpress.XtraEditors.SvgImageBox();
            progressImport = new DevExpress.XtraEditors.ProgressBarControl();

            ((System.ComponentModel.ISupportInitialize)wizardMain).BeginInit();
            wizardMain.SuspendLayout();
            pagSelectSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpSourceType).BeginInit(); grpSourceType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rgSourceType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFilePicker).BeginInit(); pnlFilePicker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFilePath.Properties).BeginInit();
            pagMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdMapping).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvMapping).BeginInit();
            pagValidation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdValidation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvValidation).BeginInit();
            pagPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvPreview).BeginInit();
            pagResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlResultSummary).BeginInit(); pnlResultSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgResultIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)progressImport.Properties).BeginInit();
            SuspendLayout();

            // wizardMain
            wizardMain.Controls.Add(pagSelectSource);
            wizardMain.Controls.Add(pagMapping);
            wizardMain.Controls.Add(pagValidation);
            wizardMain.Controls.Add(pagPreview);
            wizardMain.Controls.Add(pagResult);
            wizardMain.Dock = System.Windows.Forms.DockStyle.Fill;
            wizardMain.Name = "wizardMain";
            wizardMain.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] { pagSelectSource, pagMapping, pagValidation, pagPreview, pagResult });
            wizardMain.Size = new System.Drawing.Size(780, 560);
            wizardMain.Text = "معالج استيراد الموازنة";
            wizardMain.NextClick += wizardMain_NextClick;
            wizardMain.FinishClick += wizardMain_FinishClick;
            wizardMain.CancelClick += wizardMain_CancelClick;

            // Page 1 — Select Source
            pagSelectSource.Controls.Add(grpSourceType);
            pagSelectSource.Controls.Add(pnlFilePicker);
            pagSelectSource.Controls.Add(lblSelectSourceDesc);
            pagSelectSource.Controls.Add(lblSelectSourceTitle);
            pagSelectSource.Name = "pagSelectSource";
            pagSelectSource.Size = new System.Drawing.Size(754, 467);
            pagSelectSource.Text = "الخطوة 1 — اختيار المصدر";
            lblSelectSourceTitle.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblSelectSourceTitle.Appearance.Options.UseFont = true;
            lblSelectSourceTitle.Location = new System.Drawing.Point(12, 12); lblSelectSourceTitle.Name = "lblSelectSourceTitle"; lblSelectSourceTitle.Text = "اختيار مصدر البيانات";
            lblSelectSourceDesc.Appearance.Font = new System.Drawing.Font("Cairo", 9F); lblSelectSourceDesc.Appearance.Options.UseFont = true;
            lblSelectSourceDesc.Location = new System.Drawing.Point(12, 44); lblSelectSourceDesc.Name = "lblSelectSourceDesc"; lblSelectSourceDesc.Text = "اختر المصدر الذي تريد استيراد الموازنة منه";
            grpSourceType.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpSourceType.AppearanceCaption.Options.UseFont = true;
            grpSourceType.Controls.Add(rgSourceType); grpSourceType.Location = new System.Drawing.Point(12, 70); grpSourceType.Name = "grpSourceType"; grpSourceType.Size = new System.Drawing.Size(720, 100); grpSourceType.Text = "نوع المصدر";
            rgSourceType.Location = new System.Drawing.Point(10, 28); rgSourceType.Name = "rgSourceType"; rgSourceType.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); rgSourceType.Properties.Appearance.Options.UseFont = true;
            rgSourceType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Excel"), new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "جدول الكميات (BOQ)"), new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "موازنة سابقة") });
            rgSourceType.Size = new System.Drawing.Size(700, 55);
            pnlFilePicker.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFilePicker.Controls.Add(lblFilePath); pnlFilePicker.Controls.Add(txtFilePath); pnlFilePicker.Controls.Add(btnBrowseFile);
            pnlFilePicker.Location = new System.Drawing.Point(12, 180); pnlFilePicker.Name = "pnlFilePicker"; pnlFilePicker.Size = new System.Drawing.Size(720, 50);
            lblFilePath.Appearance.Font = new System.Drawing.Font("Cairo", 9F); lblFilePath.Appearance.Options.UseFont = true; lblFilePath.Location = new System.Drawing.Point(680, 12); lblFilePath.Name = "lblFilePath"; lblFilePath.Text = "مسار الملف:";
            txtFilePath.Location = new System.Drawing.Point(90, 8); txtFilePath.Name = "txtFilePath"; txtFilePath.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); txtFilePath.Properties.Appearance.Options.UseFont = true; txtFilePath.Size = new System.Drawing.Size(580, 30);
            btnBrowseFile.Appearance.Font = new System.Drawing.Font("Cairo", 9F); btnBrowseFile.Appearance.Options.UseFont = true; btnBrowseFile.Location = new System.Drawing.Point(8, 8); btnBrowseFile.Name = "btnBrowseFile"; btnBrowseFile.Size = new System.Drawing.Size(78, 30); btnBrowseFile.Text = "استعراض"; btnBrowseFile.Click += btnBrowseFile_Click;

            // Page 2 — Mapping
            pagMapping.Controls.Add(grdMapping); pagMapping.Controls.Add(lblMappingDesc); pagMapping.Controls.Add(lblMappingTitle);
            pagMapping.Name = "pagMapping"; pagMapping.Size = new System.Drawing.Size(754, 467); pagMapping.Text = "الخطوة 2 — تعيين الأعمدة";
            lblMappingTitle.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblMappingTitle.Appearance.Options.UseFont = true;
            lblMappingTitle.Location = new System.Drawing.Point(12, 12); lblMappingTitle.Name = "lblMappingTitle"; lblMappingTitle.Text = "تعيين الأعمدة";
            lblMappingDesc.Appearance.Font = new System.Drawing.Font("Cairo", 9F); lblMappingDesc.Appearance.Options.UseFont = true;
            lblMappingDesc.Location = new System.Drawing.Point(12, 44); lblMappingDesc.Name = "lblMappingDesc"; lblMappingDesc.Text = "قم بتعيين أعمدة الملف مع حقول الموازنة";
            grdMapping.Location = new System.Drawing.Point(12, 70); grdMapping.MainView = gvMapping; grdMapping.Name = "grdMapping"; grdMapping.Size = new System.Drawing.Size(720, 385); grdMapping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvMapping });
            gvMapping.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F); gvMapping.Appearance.Row.Options.UseFont = true;
            gvMapping.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colMappingSourceField, colMappingTargetField, colMappingRequired, colMappingMapped });
            gvMapping.GridControl = grdMapping; gvMapping.Name = "gvMapping"; gvMapping.OptionsView.ShowFooter = false;
            colMappingSourceField.Caption = "حقل المصدر"; colMappingSourceField.FieldName = "SourceField"; colMappingSourceField.Name = "colMappingSourceField"; colMappingSourceField.Visible = true; colMappingSourceField.Width = 200;
            colMappingTargetField.Caption = "حقل الموازنة"; colMappingTargetField.FieldName = "TargetField"; colMappingTargetField.Name = "colMappingTargetField"; colMappingTargetField.Visible = true; colMappingTargetField.Width = 200;
            colMappingRequired.Caption = "مطلوب"; colMappingRequired.FieldName = "Required"; colMappingRequired.Name = "colMappingRequired"; colMappingRequired.Visible = true; colMappingRequired.Width = 80;
            colMappingMapped.Caption = "تم التعيين"; colMappingMapped.FieldName = "Mapped"; colMappingMapped.Name = "colMappingMapped"; colMappingMapped.Visible = true; colMappingMapped.Width = 80;

            // Page 3 — Validation
            pagValidation.Controls.Add(grdValidation); pagValidation.Controls.Add(lblValidationTitle);
            pagValidation.Name = "pagValidation"; pagValidation.Size = new System.Drawing.Size(754, 467); pagValidation.Text = "الخطوة 3 — التحقق";
            lblValidationTitle.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblValidationTitle.Appearance.Options.UseFont = true;
            lblValidationTitle.Location = new System.Drawing.Point(12, 12); lblValidationTitle.Name = "lblValidationTitle"; lblValidationTitle.Text = "نتائج التحقق";
            grdValidation.Location = new System.Drawing.Point(12, 48); grdValidation.MainView = gvValidation; grdValidation.Name = "grdValidation"; grdValidation.Size = new System.Drawing.Size(720, 407); grdValidation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvValidation });
            gvValidation.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F); gvValidation.Appearance.Row.Options.UseFont = true;
            gvValidation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colValRow, colValField, colValMessage, colValType });
            gvValidation.GridControl = grdValidation; gvValidation.Name = "gvValidation"; gvValidation.OptionsBehavior.Editable = false;
            colValRow.Caption = "السطر"; colValRow.FieldName = "Row"; colValRow.Name = "colValRow"; colValRow.Visible = true; colValRow.Width = 80;
            colValField.Caption = "الحقل"; colValField.FieldName = "Field"; colValField.Name = "colValField"; colValField.Visible = true; colValField.Width = 140;
            colValMessage.Caption = "الرسالة"; colValMessage.FieldName = "Message"; colValMessage.Name = "colValMessage"; colValMessage.Visible = true; colValMessage.Width = 360;
            colValType.Caption = "النوع"; colValType.FieldName = "Type"; colValType.Name = "colValType"; colValType.Visible = true; colValType.Width = 100;

            // Page 4 — Preview
            pagPreview.Controls.Add(grdPreview); pagPreview.Controls.Add(lblPreviewTitle);
            pagPreview.Name = "pagPreview"; pagPreview.Size = new System.Drawing.Size(754, 467); pagPreview.Text = "الخطوة 4 — معاينة";
            lblPreviewTitle.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblPreviewTitle.Appearance.Options.UseFont = true;
            lblPreviewTitle.Location = new System.Drawing.Point(12, 12); lblPreviewTitle.Name = "lblPreviewTitle"; lblPreviewTitle.Text = "معاينة البيانات";
            grdPreview.Location = new System.Drawing.Point(12, 48); grdPreview.MainView = gvPreview; grdPreview.Name = "grdPreview"; grdPreview.Size = new System.Drawing.Size(720, 407); grdPreview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvPreview });
            gvPreview.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F); gvPreview.Appearance.Row.Options.UseFont = true;
            gvPreview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPreviewCostCode, colPreviewDescription, colPreviewUnit, colPreviewQty, colPreviewUnitCost, colPreviewTotalCost });
            gvPreview.GridControl = grdPreview; gvPreview.Name = "gvPreview"; gvPreview.OptionsBehavior.Editable = false;
            colPreviewCostCode.Caption = "كود التكلفة"; colPreviewCostCode.FieldName = "CostCode"; colPreviewCostCode.Name = "colPreviewCostCode"; colPreviewCostCode.Visible = true; colPreviewCostCode.Width = 120;
            colPreviewDescription.Caption = "الوصف"; colPreviewDescription.FieldName = "Description"; colPreviewDescription.Name = "colPreviewDescription"; colPreviewDescription.Visible = true; colPreviewDescription.Width = 240;
            colPreviewUnit.Caption = "الوحدة"; colPreviewUnit.FieldName = "Unit"; colPreviewUnit.Name = "colPreviewUnit"; colPreviewUnit.Visible = true; colPreviewUnit.Width = 70;
            colPreviewQty.Caption = "الكمية"; colPreviewQty.FieldName = "Qty"; colPreviewQty.Name = "colPreviewQty"; colPreviewQty.Visible = true; colPreviewQty.Width = 90; colPreviewQty.DisplayFormat.FormatString = "N2"; colPreviewQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPreviewUnitCost.Caption = "سعر الوحدة"; colPreviewUnitCost.FieldName = "UnitCost"; colPreviewUnitCost.Name = "colPreviewUnitCost"; colPreviewUnitCost.Visible = true; colPreviewUnitCost.Width = 110; colPreviewUnitCost.DisplayFormat.FormatString = "N2"; colPreviewUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPreviewTotalCost.Caption = "الإجمالي"; colPreviewTotalCost.FieldName = "TotalCost"; colPreviewTotalCost.Name = "colPreviewTotalCost"; colPreviewTotalCost.Visible = true; colPreviewTotalCost.Width = 110; colPreviewTotalCost.DisplayFormat.FormatString = "N2"; colPreviewTotalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            // Page 5 — Result
            pagResult.Controls.Add(pnlResultSummary); pagResult.Controls.Add(progressImport); pagResult.Controls.Add(lblResultTitle);
            pagResult.Name = "pagResult"; pagResult.Size = new System.Drawing.Size(754, 467); pagResult.Text = "الخطوة 5 — نتيجة الاستيراد";
            lblResultTitle.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblResultTitle.Appearance.Options.UseFont = true;
            lblResultTitle.Location = new System.Drawing.Point(12, 12); lblResultTitle.Name = "lblResultTitle"; lblResultTitle.Text = "نتيجة الاستيراد";
            progressImport.Location = new System.Drawing.Point(12, 50); progressImport.Name = "progressImport"; progressImport.Size = new System.Drawing.Size(720, 24);
            progressImport.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 8F); progressImport.Properties.Appearance.Options.UseFont = true;
            pnlResultSummary.Controls.Add(svgResultIcon); pnlResultSummary.Controls.Add(lblResultTotal); pnlResultSummary.Controls.Add(lblResultSuccess); pnlResultSummary.Controls.Add(lblResultErrors);
            pnlResultSummary.Location = new System.Drawing.Point(12, 90); pnlResultSummary.Name = "pnlResultSummary"; pnlResultSummary.Size = new System.Drawing.Size(720, 300);
            svgResultIcon.Location = new System.Drawing.Point(310, 50); svgResultIcon.Name = "svgResultIcon"; svgResultIcon.Size = new System.Drawing.Size(80, 80); svgResultIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiApprove.ImageOptions.SvgImage");
            lblResultTotal.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold); lblResultTotal.Appearance.Options.UseFont = true;
            lblResultTotal.Location = new System.Drawing.Point(240, 150); lblResultTotal.Name = "lblResultTotal"; lblResultTotal.Text = "إجمالي الصفوف: 0";
            lblResultSuccess.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblResultSuccess.Appearance.Options.UseFont = true;
            lblResultSuccess.Location = new System.Drawing.Point(265, 185); lblResultSuccess.Name = "lblResultSuccess"; lblResultSuccess.Text = "تم الاستيراد: 0";
            lblResultErrors.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblResultErrors.Appearance.ForeColor = System.Drawing.Color.FromArgb(192, 80, 77); lblResultErrors.Appearance.Options.UseFont = true; lblResultErrors.Appearance.Options.UseForeColor = true;
            lblResultErrors.Location = new System.Drawing.Point(265, 215); lblResultErrors.Name = "lblResultErrors"; lblResultErrors.Text = "أخطاء: 0";

            // frmBudgetImportWizard
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F); AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(780, 560);
            Controls.Add(wizardMain);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            Name = "frmBudgetImportWizard";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "معالج استيراد الموازنة";

            ((System.ComponentModel.ISupportInitialize)wizardMain).EndInit();
            wizardMain.ResumeLayout(false);
            pagSelectSource.ResumeLayout(false); pagSelectSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grpSourceType).EndInit(); grpSourceType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rgSourceType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFilePicker).EndInit(); pnlFilePicker.ResumeLayout(false); pnlFilePicker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFilePath.Properties).EndInit();
            pagMapping.ResumeLayout(false); pagMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdMapping).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvMapping).EndInit();
            pagValidation.ResumeLayout(false); pagValidation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdValidation).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvValidation).EndInit();
            pagPreview.ResumeLayout(false); pagPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvPreview).EndInit();
            pagResult.ResumeLayout(false); pagResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlResultSummary).EndInit(); pnlResultSummary.ResumeLayout(false); pnlResultSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgResultIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)progressImport.Properties).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private DevExpress.XtraWizard.WizardControl wizardMain;
        private DevExpress.XtraWizard.WizardPage pagSelectSource;
        private DevExpress.XtraEditors.LabelControl lblSelectSourceTitle;
        private DevExpress.XtraEditors.LabelControl lblSelectSourceDesc;
        private DevExpress.XtraEditors.GroupControl grpSourceType;
        private DevExpress.XtraEditors.RadioGroup rgSourceType;
        private DevExpress.XtraEditors.PanelControl pnlFilePicker;
        private DevExpress.XtraEditors.LabelControl lblFilePath;
        private DevExpress.XtraEditors.TextEdit txtFilePath;
        private DevExpress.XtraEditors.SimpleButton btnBrowseFile;
        private DevExpress.XtraWizard.WizardPage pagMapping;
        private DevExpress.XtraEditors.LabelControl lblMappingTitle;
        private DevExpress.XtraEditors.LabelControl lblMappingDesc;
        private DevExpress.XtraGrid.GridControl grdMapping;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMapping;
        private DevExpress.XtraGrid.Columns.GridColumn colMappingSourceField;
        private DevExpress.XtraGrid.Columns.GridColumn colMappingTargetField;
        private DevExpress.XtraGrid.Columns.GridColumn colMappingRequired;
        private DevExpress.XtraGrid.Columns.GridColumn colMappingMapped;
        private DevExpress.XtraWizard.WizardPage pagValidation;
        private DevExpress.XtraEditors.LabelControl lblValidationTitle;
        private DevExpress.XtraGrid.GridControl grdValidation;
        private DevExpress.XtraGrid.Views.Grid.GridView gvValidation;
        private DevExpress.XtraGrid.Columns.GridColumn colValRow;
        private DevExpress.XtraGrid.Columns.GridColumn colValField;
        private DevExpress.XtraGrid.Columns.GridColumn colValMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colValType;
        private DevExpress.XtraWizard.WizardPage pagPreview;
        private DevExpress.XtraEditors.LabelControl lblPreviewTitle;
        private DevExpress.XtraGrid.GridControl grdPreview;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPreview;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewCostCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewTotalCost;
        private DevExpress.XtraWizard.WizardPage pagResult;
        private DevExpress.XtraEditors.LabelControl lblResultTitle;
        private DevExpress.XtraEditors.PanelControl pnlResultSummary;
        private DevExpress.XtraEditors.LabelControl lblResultTotal;
        private DevExpress.XtraEditors.LabelControl lblResultSuccess;
        private DevExpress.XtraEditors.LabelControl lblResultErrors;
        private DevExpress.XtraEditors.SvgImageBox svgResultIcon;
        private DevExpress.XtraEditors.ProgressBarControl progressImport;
    }
}

