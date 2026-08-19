namespace Etmam
{
    partial class frmImportExportWizard
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
            wizardControlMain = new DevExpress.XtraWizard.WizardControl();
            
            wpSourceSelection = new DevExpress.XtraWizard.WizardPage();
            pnlSourceLayout = new DevExpress.XtraLayout.LayoutControl();
            rgFileType = new DevExpress.XtraEditors.RadioGroup();
            txtFilePath = new DevExpress.XtraEditors.ButtonEdit();
            cboTargetProject = new DevExpress.XtraEditors.LookUpEdit();
            
            wpMapping = new DevExpress.XtraWizard.WizardPage();
            grdFieldMapping = new DevExpress.XtraGrid.GridControl();
            gvFieldMapping = new DevExpress.XtraGrid.Views.Grid.GridView();
            colSourceField = new DevExpress.XtraGrid.Columns.GridColumn();
            colTargetField = new DevExpress.XtraGrid.Columns.GridColumn();
            colMappingStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            wpValidation = new DevExpress.XtraWizard.WizardPage();
            grdValidationErrors = new DevExpress.XtraGrid.GridControl();
            gvValidationErrors = new DevExpress.XtraGrid.Views.Grid.GridView();
            colErrLine = new DevExpress.XtraGrid.Columns.GridColumn();
            colErrField = new DevExpress.XtraGrid.Columns.GridColumn();
            colErrMsg = new DevExpress.XtraGrid.Columns.GridColumn();
            colErrSeverity = new DevExpress.XtraGrid.Columns.GridColumn();

            wpPreview = new DevExpress.XtraWizard.WizardPage();
            grdPreviewData = new DevExpress.XtraGrid.GridControl();
            gvPreviewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPrevCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrevName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrevStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrevFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrevDuration = new DevExpress.XtraGrid.Columns.GridColumn();

            wpImportResult = new DevExpress.XtraWizard.CompletionWizardPage();
            lblResultSummary = new DevExpress.XtraEditors.LabelControl();
            svgResultIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)(wizardControlMain)).BeginInit();
            wizardControlMain.SuspendLayout();
            wpSourceSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pnlSourceLayout)).BeginInit();
            pnlSourceLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(rgFileType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(txtFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cboTargetProject.Properties)).BeginInit();
            wpMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdFieldMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvFieldMapping)).BeginInit();
            wpValidation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdValidationErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvValidationErrors)).BeginInit();
            wpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdPreviewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvPreviewData)).BeginInit();
            wpImportResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgResultIcon)).BeginInit();
            SuspendLayout();

            // WizardControl
            wizardControlMain.Controls.Add(wpSourceSelection);
            wizardControlMain.Controls.Add(wpMapping);
            wizardControlMain.Controls.Add(wpValidation);
            wizardControlMain.Controls.Add(wpPreview);
            wizardControlMain.Controls.Add(wpImportResult);
            wizardControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            wizardControlMain.Name = "wizardControlMain";
            wizardControlMain.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
                wpSourceSelection, wpMapping, wpValidation, wpPreview, wpImportResult
            });
            wizardControlMain.Text = "معالج استيراد / تصدير الجداول الزمنية (Primavera XER/XML & MS Project)";
            wizardControlMain.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            wizardControlMain.FinishClick += wizardControlMain_FinishClick;
            wizardControlMain.NextClick += wizardControlMain_NextClick;
            wizardControlMain.CancelClick += wizardControlMain_CancelClick;

            // Step 1: Source Selection
            wpSourceSelection.Controls.Add(pnlSourceLayout);
            wpSourceSelection.Name = "wpSourceSelection";
            wpSourceSelection.Size = new System.Drawing.Size(800, 480);
            wpSourceSelection.Text = "الخطوة 1: اختيار مصدر وتنسيق الملف";

            rgFileType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
                new DevExpress.XtraEditors.Controls.RadioGroupItem("XER", "Primavera P6 XER File (*.xer)"),
                new DevExpress.XtraEditors.Controls.RadioGroupItem("XML_P6", "Primavera P6 XML File (*.xml)"),
                new DevExpress.XtraEditors.Controls.RadioGroupItem("XML_MSP", "Microsoft Project XML File (*.xml)"),
                new DevExpress.XtraEditors.Controls.RadioGroupItem("EXCEL", "Excel Workbook (*.xlsx, *.xls)")
            });
            txtFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            });
            txtFilePath.ButtonClick += btnBrowseFile_Click;
            cboTargetProject.Properties.NullText = "اختر المشروع الهدف الاستيراد إليه...";

            pnlSourceLayout.Controls.Add(rgFileType);
            pnlSourceLayout.Controls.Add(txtFilePath);
            pnlSourceLayout.Controls.Add(cboTargetProject);
            pnlSourceLayout.Dock = System.Windows.Forms.DockStyle.Fill;

            // Step 2: Mapping
            wpMapping.Controls.Add(grdFieldMapping);
            wpMapping.Name = "wpMapping";
            wpMapping.Size = new System.Drawing.Size(800, 480);
            wpMapping.Text = "الخطوة 2: مطابقة الحقول (Field Mapping)";

            grdFieldMapping.MainView = gvFieldMapping;
            grdFieldMapping.Name = "grdFieldMapping";
            grdFieldMapping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvFieldMapping });
            grdFieldMapping.Dock = System.Windows.Forms.DockStyle.Fill;

            gvFieldMapping.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colSourceField, colTargetField, colMappingStatus
            });
            gvFieldMapping.GridControl = grdFieldMapping;

            colSourceField.Caption = "حقل الملف المصدر";
            colSourceField.FieldName = "SourceField";
            colSourceField.Visible = true;
            colSourceField.VisibleIndex = 0;

            colTargetField.Caption = "حقل النظام المقابل";
            colTargetField.FieldName = "TargetField";
            colTargetField.Visible = true;
            colTargetField.VisibleIndex = 1;

            colMappingStatus.Caption = "حالة المطابقة";
            colMappingStatus.FieldName = "MappingStatus";
            colMappingStatus.Visible = true;
            colMappingStatus.VisibleIndex = 2;

            // Step 3: Validation
            wpValidation.Controls.Add(grdValidationErrors);
            wpValidation.Name = "wpValidation";
            wpValidation.Size = new System.Drawing.Size(800, 480);
            wpValidation.Text = "الخطوة 3: التحقق من التوافق والصحة (Validation)";

            grdValidationErrors.MainView = gvValidationErrors;
            grdValidationErrors.Name = "grdValidationErrors";
            grdValidationErrors.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvValidationErrors });
            grdValidationErrors.Dock = System.Windows.Forms.DockStyle.Fill;

            gvValidationErrors.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colErrLine, colErrField, colErrMsg, colErrSeverity
            });
            gvValidationErrors.GridControl = grdValidationErrors;

            colErrLine.Caption = "رقم السطر / المعرف";
            colErrLine.FieldName = "LineNo";
            colErrLine.Visible = true;
            colErrLine.VisibleIndex = 0;

            colErrField.Caption = "الحقل التأثيري";
            colErrField.FieldName = "Field";
            colErrField.Visible = true;
            colErrField.VisibleIndex = 1;

            colErrMsg.Caption = "رسالة التنبيه / الخطأ";
            colErrMsg.FieldName = "Message";
            colErrMsg.Visible = true;
            colErrMsg.VisibleIndex = 2;

            colErrSeverity.Caption = "مستوى الخطورة";
            colErrSeverity.FieldName = "Severity";
            colErrSeverity.Visible = true;
            colErrSeverity.VisibleIndex = 3;

            // Step 4: Preview
            wpPreview.Controls.Add(grdPreviewData);
            wpPreview.Name = "wpPreview";
            wpPreview.Size = new System.Drawing.Size(800, 480);
            wpPreview.Text = "الخطوة 4: معاينة البيانات قبل الاستيراد (Preview)";

            grdPreviewData.MainView = gvPreviewData;
            grdPreviewData.Name = "grdPreviewData";
            grdPreviewData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvPreviewData });
            grdPreviewData.Dock = System.Windows.Forms.DockStyle.Fill;

            gvPreviewData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colPrevCode, colPrevName, colPrevStart, colPrevFinish, colPrevDuration
            });
            gvPreviewData.GridControl = grdPreviewData;

            colPrevCode.Caption = "كود النشاط";
            colPrevCode.FieldName = "Code";
            colPrevCode.Visible = true;
            colPrevCode.VisibleIndex = 0;

            colPrevName.Caption = "اسم النشاط";
            colPrevName.FieldName = "Name";
            colPrevName.Visible = true;
            colPrevName.VisibleIndex = 1;

            colPrevStart.Caption = "تاريخ البداية";
            colPrevStart.FieldName = "Start";
            colPrevStart.Visible = true;
            colPrevStart.VisibleIndex = 2;

            colPrevFinish.Caption = "تاريخ النهاية";
            colPrevFinish.FieldName = "Finish";
            colPrevFinish.Visible = true;
            colPrevFinish.VisibleIndex = 3;

            colPrevDuration.Caption = "المدة";
            colPrevDuration.FieldName = "Duration";
            colPrevDuration.Visible = true;
            colPrevDuration.VisibleIndex = 4;

            // Step 5: Import Result
            wpImportResult.Controls.Add(lblResultSummary);
            wpImportResult.Controls.Add(svgResultIcon);
            wpImportResult.Name = "wpImportResult";
            wpImportResult.Size = new System.Drawing.Size(800, 480);
            wpImportResult.Text = "الخطوة 5: نتيجة المعالجة والتحديث النهائي";

            lblResultSummary.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblResultSummary.Location = new System.Drawing.Point(80, 80);
            lblResultSummary.Text = "تمت عملية المعالجة والاستيراد بنجاح! تم حفظ 1,240 نشاطاً وهيكل WBS بالكامل.";

            svgResultIcon.Location = new System.Drawing.Point(20, 70);
            svgResultIcon.Size = new System.Drawing.Size(48, 48);

            // Form Properties
            Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(850, 560);
            Controls.Add(wizardControlMain);
            Name = "frmImportExportWizard";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "معالج استيراد / تصدير الجدول الزمني";

            ((System.ComponentModel.ISupportInitialize)(wizardControlMain)).EndInit();
            wizardControlMain.ResumeLayout(false);
            wpSourceSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pnlSourceLayout)).EndInit();
            pnlSourceLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(rgFileType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(txtFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cboTargetProject.Properties)).EndInit();
            wpMapping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdFieldMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvFieldMapping)).EndInit();
            wpValidation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdValidationErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvValidationErrors)).EndInit();
            wpPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdPreviewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvPreviewData)).EndInit();
            wpImportResult.ResumeLayout(false);
            wpImportResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(svgResultIcon)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControlMain;
        private DevExpress.XtraWizard.WizardPage wpSourceSelection;
        private DevExpress.XtraWizard.WizardPage wpMapping;
        private DevExpress.XtraWizard.WizardPage wpValidation;
        private DevExpress.XtraWizard.WizardPage wpPreview;
        private DevExpress.XtraWizard.CompletionWizardPage wpImportResult;

        private DevExpress.XtraLayout.LayoutControl pnlSourceLayout;
        private DevExpress.XtraEditors.RadioGroup rgFileType;
        private DevExpress.XtraEditors.ButtonEdit txtFilePath;
        private DevExpress.XtraEditors.LookUpEdit cboTargetProject;

        private DevExpress.XtraGrid.GridControl grdFieldMapping;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFieldMapping;
        private DevExpress.XtraGrid.Columns.GridColumn colSourceField;
        private DevExpress.XtraGrid.Columns.GridColumn colTargetField;
        private DevExpress.XtraGrid.Columns.GridColumn colMappingStatus;

        private DevExpress.XtraGrid.GridControl grdValidationErrors;
        private DevExpress.XtraGrid.Views.Grid.GridView gvValidationErrors;
        private DevExpress.XtraGrid.Columns.GridColumn colErrLine;
        private DevExpress.XtraGrid.Columns.GridColumn colErrField;
        private DevExpress.XtraGrid.Columns.GridColumn colErrMsg;
        private DevExpress.XtraGrid.Columns.GridColumn colErrSeverity;

        private DevExpress.XtraGrid.GridControl grdPreviewData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPreviewData;
        private DevExpress.XtraGrid.Columns.GridColumn colPrevCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPrevName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrevStart;
        private DevExpress.XtraGrid.Columns.GridColumn colPrevFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colPrevDuration;

        private DevExpress.XtraEditors.LabelControl lblResultSummary;
        private DevExpress.XtraEditors.SvgImageBox svgResultIcon;
    }
}
