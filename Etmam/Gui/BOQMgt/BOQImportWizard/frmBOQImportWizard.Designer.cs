namespace Etmam
{
    partial class frmBOQImportWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBOQImportWizard));
            wizImport = new DevExpress.XtraWizard.WizardControl();

            wizPageFile = new DevExpress.XtraWizard.WizardPage();
            lblFilePath = new DevExpress.XtraEditors.LabelControl();
            txtFilePath = new DevExpress.XtraEditors.TextEdit();
            btnBrowseFile = new DevExpress.XtraEditors.SimpleButton();
            lblSheetName = new DevExpress.XtraEditors.LabelControl();
            cboSheetName = new DevExpress.XtraEditors.ComboBoxEdit();
            chkFirstRowHeaders = new DevExpress.XtraEditors.CheckEdit();

            wizPageMapping = new DevExpress.XtraWizard.WizardPage();
            lblColumnMapping = new DevExpress.XtraEditors.LabelControl();
            grdColumnMapping = new DevExpress.XtraGrid.GridControl();
            gvColumnMapping = new DevExpress.XtraGrid.Views.Grid.GridView();
            colExcelColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            colMapsTo = new DevExpress.XtraGrid.Columns.GridColumn();
            colDataType = new DevExpress.XtraGrid.Columns.GridColumn();

            wizPageValidation = new DevExpress.XtraWizard.WizardPage();
            lblTotalRowsTitle = new DevExpress.XtraEditors.LabelControl();
            lblTotalRowsValue = new DevExpress.XtraEditors.LabelControl();
            lblErrorsTitle = new DevExpress.XtraEditors.LabelControl();
            lblErrorsValue = new DevExpress.XtraEditors.LabelControl();
            lblWarningsTitle = new DevExpress.XtraEditors.LabelControl();
            lblWarningsValue = new DevExpress.XtraEditors.LabelControl();
            grdValidation = new DevExpress.XtraGrid.GridControl();
            gvValidation = new DevExpress.XtraGrid.Views.Grid.GridView();
            colValidationRow = new DevExpress.XtraGrid.Columns.GridColumn();
            colValidationField = new DevExpress.XtraGrid.Columns.GridColumn();
            colValidationIssue = new DevExpress.XtraGrid.Columns.GridColumn();
            colValidationSeverity = new DevExpress.XtraGrid.Columns.GridColumn();

            wizPagePreview = new DevExpress.XtraWizard.WizardPage();
            lblPreviewTitle = new DevExpress.XtraEditors.LabelControl();
            grdPreview = new DevExpress.XtraGrid.GridControl();
            gvPreview = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPreviewItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewDescriptionAr = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewUnitRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviewTotal = new DevExpress.XtraGrid.Columns.GridColumn();

            wizPageSummary = new DevExpress.XtraWizard.WizardPage();
            lblSummaryTitle = new DevExpress.XtraEditors.LabelControl();
            lblImportedRowsTitle = new DevExpress.XtraEditors.LabelControl();
            lblImportedRowsValue = new DevExpress.XtraEditors.LabelControl();
            lblSkippedRowsTitle = new DevExpress.XtraEditors.LabelControl();
            lblSkippedRowsValue = new DevExpress.XtraEditors.LabelControl();
            lblImportErrorsTitle = new DevExpress.XtraEditors.LabelControl();
            lblImportErrorsValue = new DevExpress.XtraEditors.LabelControl();
            btnViewLog = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)wizImport).BeginInit();
            wizImport.SuspendLayout();

            wizPageFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFilePath.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboSheetName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkFirstRowHeaders.Properties).BeginInit();

            wizPageMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdColumnMapping).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvColumnMapping).BeginInit();

            wizPageValidation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdValidation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvValidation).BeginInit();

            wizPagePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvPreview).BeginInit();

            wizPageSummary.SuspendLayout();

            SuspendLayout();
            //
            // wizPageFile
            //
            wizPageFile.Controls.Add(chkFirstRowHeaders);
            wizPageFile.Controls.Add(cboSheetName);
            wizPageFile.Controls.Add(lblSheetName);
            wizPageFile.Controls.Add(btnBrowseFile);
            wizPageFile.Controls.Add(txtFilePath);
            wizPageFile.Controls.Add(lblFilePath);
            wizPageFile.DescriptionText = "اختر ملف الإكسل المصدر وورقة العمل المطلوب استيرادها";
            wizPageFile.Name = "wizPageFile";
            wizPageFile.Size = new Size(860, 380);
            wizPageFile.Text = "اختيار الملف";
            //
            // lblFilePath
            //
            lblFilePath.Appearance.Font = new Font("Cairo", 8F);
            lblFilePath.Appearance.Options.UseFont = true;
            lblFilePath.Location = new Point(20, 20);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(48, 17);
            lblFilePath.TabIndex = 0;
            lblFilePath.Text = "مسار الملف";
            //
            // txtFilePath
            //
            txtFilePath.Location = new Point(160, 38);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtFilePath.Properties.Appearance.Options.UseFont = true;
            txtFilePath.Properties.ReadOnly = true;
            txtFilePath.Size = new Size(520, 28);
            txtFilePath.TabIndex = 1;
            //
            // btnBrowseFile
            //
            btnBrowseFile.Location = new Point(20, 38);
            btnBrowseFile.Name = "btnBrowseFile";
            btnBrowseFile.Size = new Size(130, 30);
            btnBrowseFile.TabIndex = 2;
            btnBrowseFile.Text = "استعراض...";
            btnBrowseFile.Click += btnBrowseFile_Click;
            //
            // lblSheetName
            //
            lblSheetName.Appearance.Font = new Font("Cairo", 8F);
            lblSheetName.Appearance.Options.UseFont = true;
            lblSheetName.Location = new Point(20, 92);
            lblSheetName.Name = "lblSheetName";
            lblSheetName.Size = new Size(63, 17);
            lblSheetName.TabIndex = 3;
            lblSheetName.Text = "اسم الورقة (Sheet)";
            //
            // cboSheetName
            //
            cboSheetName.Location = new Point(20, 110);
            cboSheetName.Name = "cboSheetName";
            cboSheetName.Properties.Appearance.Font = new Font("Cairo", 9F);
            cboSheetName.Properties.Appearance.Options.UseFont = true;
            cboSheetName.Properties.NullText = "-- اختر الورقة --";
            cboSheetName.Size = new Size(380, 28);
            cboSheetName.TabIndex = 4;
            //
            // chkFirstRowHeaders
            //
            chkFirstRowHeaders.Location = new Point(20, 158);
            chkFirstRowHeaders.Name = "chkFirstRowHeaders";
            chkFirstRowHeaders.Properties.Appearance.Font = new Font("Cairo", 9F);
            chkFirstRowHeaders.Properties.Appearance.Options.UseFont = true;
            chkFirstRowHeaders.Properties.Caption = "الصف الأول يحتوي على عناوين الأعمدة";
            chkFirstRowHeaders.Size = new Size(320, 24);
            chkFirstRowHeaders.TabIndex = 5;
            //
            // wizPageMapping
            //
            wizPageMapping.Controls.Add(grdColumnMapping);
            wizPageMapping.Controls.Add(lblColumnMapping);
            wizPageMapping.DescriptionText = "طابق أعمدة ملف الإكسل مع حقول جدول الكميات";
            wizPageMapping.Name = "wizPageMapping";
            wizPageMapping.Size = new Size(860, 380);
            wizPageMapping.Text = "تخطيط الأعمدة";
            //
            // lblColumnMapping
            //
            lblColumnMapping.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblColumnMapping.Appearance.Options.UseFont = true;
            lblColumnMapping.Location = new Point(20, 20);
            lblColumnMapping.Name = "lblColumnMapping";
            lblColumnMapping.Size = new Size(93, 20);
            lblColumnMapping.TabIndex = 0;
            lblColumnMapping.Text = "تخطيط الأعمدة";
            //
            // grdColumnMapping
            //
            grdColumnMapping.Location = new Point(20, 46);
            grdColumnMapping.MainView = gvColumnMapping;
            grdColumnMapping.Name = "grdColumnMapping";
            grdColumnMapping.Size = new Size(820, 314);
            grdColumnMapping.TabIndex = 1;
            grdColumnMapping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvColumnMapping });
            //
            // gvColumnMapping
            //
            gvColumnMapping.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvColumnMapping.Appearance.HeaderPanel.Options.UseFont = true;
            gvColumnMapping.Appearance.Row.Font = new Font("Cairo", 8F);
            gvColumnMapping.Appearance.Row.Options.UseFont = true;
            gvColumnMapping.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colExcelColumn, colMapsTo, colDataType });
            gvColumnMapping.GridControl = grdColumnMapping;
            gvColumnMapping.Name = "gvColumnMapping";
            gvColumnMapping.OptionsView.ShowGroupPanel = false;
            //
            // colExcelColumn
            //
            colExcelColumn.Caption = "عمود الإكسل";
            colExcelColumn.FieldName = "ExcelColumn";
            colExcelColumn.Name = "colExcelColumn";
            colExcelColumn.Visible = true;
            colExcelColumn.VisibleIndex = 0;
            colExcelColumn.Width = 250;
            //
            // colMapsTo
            //
            colMapsTo.Caption = "الحقل المقابل (بند الكميات)";
            colMapsTo.FieldName = "MapsTo";
            colMapsTo.Name = "colMapsTo";
            colMapsTo.Visible = true;
            colMapsTo.VisibleIndex = 1;
            colMapsTo.Width = 320;
            //
            // colDataType
            //
            colDataType.Caption = "نوع البيانات";
            colDataType.FieldName = "DataType";
            colDataType.Name = "colDataType";
            colDataType.Visible = true;
            colDataType.VisibleIndex = 2;
            colDataType.Width = 250;
            //
            // wizPageValidation
            //
            wizPageValidation.Controls.Add(grdValidation);
            wizPageValidation.Controls.Add(lblWarningsValue);
            wizPageValidation.Controls.Add(lblWarningsTitle);
            wizPageValidation.Controls.Add(lblErrorsValue);
            wizPageValidation.Controls.Add(lblErrorsTitle);
            wizPageValidation.Controls.Add(lblTotalRowsValue);
            wizPageValidation.Controls.Add(lblTotalRowsTitle);
            wizPageValidation.DescriptionText = "نتائج التحقق من صحة البيانات قبل الاستيراد";
            wizPageValidation.Name = "wizPageValidation";
            wizPageValidation.Size = new Size(860, 380);
            wizPageValidation.Text = "التحقق من الصحة";
            //
            // lblTotalRowsTitle
            //
            lblTotalRowsTitle.Appearance.Font = new Font("Cairo", 8F);
            lblTotalRowsTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalRowsTitle.Appearance.Options.UseFont = true;
            lblTotalRowsTitle.Appearance.Options.UseForeColor = true;
            lblTotalRowsTitle.Location = new Point(20, 20);
            lblTotalRowsTitle.Name = "lblTotalRowsTitle";
            lblTotalRowsTitle.Size = new Size(64, 17);
            lblTotalRowsTitle.TabIndex = 0;
            lblTotalRowsTitle.Text = "إجمالي الصفوف";
            //
            // lblTotalRowsValue
            //
            lblTotalRowsValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblTotalRowsValue.Appearance.Options.UseFont = true;
            lblTotalRowsValue.Location = new Point(20, 40);
            lblTotalRowsValue.Name = "lblTotalRowsValue";
            lblTotalRowsValue.Size = new Size(16, 27);
            lblTotalRowsValue.TabIndex = 1;
            lblTotalRowsValue.Text = "—";
            //
            // lblErrorsTitle
            //
            lblErrorsTitle.Appearance.Font = new Font("Cairo", 8F);
            lblErrorsTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblErrorsTitle.Appearance.Options.UseFont = true;
            lblErrorsTitle.Appearance.Options.UseForeColor = true;
            lblErrorsTitle.Location = new Point(220, 20);
            lblErrorsTitle.Name = "lblErrorsTitle";
            lblErrorsTitle.Size = new Size(33, 17);
            lblErrorsTitle.TabIndex = 2;
            lblErrorsTitle.Text = "الأخطاء";
            //
            // lblErrorsValue
            //
            lblErrorsValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblErrorsValue.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblErrorsValue.Appearance.Options.UseFont = true;
            lblErrorsValue.Appearance.Options.UseForeColor = true;
            lblErrorsValue.Location = new Point(220, 40);
            lblErrorsValue.Name = "lblErrorsValue";
            lblErrorsValue.Size = new Size(16, 27);
            lblErrorsValue.TabIndex = 3;
            lblErrorsValue.Text = "—";
            //
            // lblWarningsTitle
            //
            lblWarningsTitle.Appearance.Font = new Font("Cairo", 8F);
            lblWarningsTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblWarningsTitle.Appearance.Options.UseFont = true;
            lblWarningsTitle.Appearance.Options.UseForeColor = true;
            lblWarningsTitle.Location = new Point(420, 20);
            lblWarningsTitle.Name = "lblWarningsTitle";
            lblWarningsTitle.Size = new Size(52, 17);
            lblWarningsTitle.TabIndex = 4;
            lblWarningsTitle.Text = "التحذيرات";
            //
            // lblWarningsValue
            //
            lblWarningsValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblWarningsValue.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblWarningsValue.Appearance.Options.UseFont = true;
            lblWarningsValue.Appearance.Options.UseForeColor = true;
            lblWarningsValue.Location = new Point(420, 40);
            lblWarningsValue.Name = "lblWarningsValue";
            lblWarningsValue.Size = new Size(16, 27);
            lblWarningsValue.TabIndex = 5;
            lblWarningsValue.Text = "—";
            //
            // grdValidation
            //
            grdValidation.Location = new Point(20, 84);
            grdValidation.MainView = gvValidation;
            grdValidation.Name = "grdValidation";
            grdValidation.Size = new Size(820, 276);
            grdValidation.TabIndex = 6;
            grdValidation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvValidation });
            //
            // gvValidation
            //
            gvValidation.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvValidation.Appearance.HeaderPanel.Options.UseFont = true;
            gvValidation.Appearance.Row.Font = new Font("Cairo", 8F);
            gvValidation.Appearance.Row.Options.UseFont = true;
            gvValidation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colValidationRow, colValidationField, colValidationIssue, colValidationSeverity });
            gvValidation.GridControl = grdValidation;
            gvValidation.Name = "gvValidation";
            gvValidation.OptionsView.ShowGroupPanel = false;
            //
            // colValidationRow
            //
            colValidationRow.Caption = "الصف";
            colValidationRow.FieldName = "RowNumber";
            colValidationRow.Name = "colValidationRow";
            colValidationRow.Visible = true;
            colValidationRow.VisibleIndex = 0;
            colValidationRow.Width = 100;
            //
            // colValidationField
            //
            colValidationField.Caption = "الحقل";
            colValidationField.FieldName = "FieldName";
            colValidationField.Name = "colValidationField";
            colValidationField.Visible = true;
            colValidationField.VisibleIndex = 1;
            colValidationField.Width = 200;
            //
            // colValidationIssue
            //
            colValidationIssue.Caption = "المشكلة";
            colValidationIssue.FieldName = "Issue";
            colValidationIssue.Name = "colValidationIssue";
            colValidationIssue.Visible = true;
            colValidationIssue.VisibleIndex = 2;
            colValidationIssue.Width = 340;
            //
            // colValidationSeverity
            //
            colValidationSeverity.Caption = "الخطورة";
            colValidationSeverity.FieldName = "Severity";
            colValidationSeverity.Name = "colValidationSeverity";
            colValidationSeverity.Visible = true;
            colValidationSeverity.VisibleIndex = 3;
            colValidationSeverity.Width = 130;
            //
            // wizPagePreview
            //
            wizPagePreview.Controls.Add(grdPreview);
            wizPagePreview.Controls.Add(lblPreviewTitle);
            wizPagePreview.DescriptionText = "معاينة البيانات قبل تنفيذ الاستيراد النهائي";
            wizPagePreview.Name = "wizPagePreview";
            wizPagePreview.Size = new Size(860, 380);
            wizPagePreview.Text = "المعاينة";
            //
            // lblPreviewTitle
            //
            lblPreviewTitle.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblPreviewTitle.Appearance.Options.UseFont = true;
            lblPreviewTitle.Location = new Point(20, 20);
            lblPreviewTitle.Name = "lblPreviewTitle";
            lblPreviewTitle.Size = new Size(154, 20);
            lblPreviewTitle.TabIndex = 0;
            lblPreviewTitle.Text = "معاينة بيانات الاستيراد";
            //
            // grdPreview
            //
            grdPreview.Location = new Point(20, 46);
            grdPreview.MainView = gvPreview;
            grdPreview.Name = "grdPreview";
            grdPreview.Size = new Size(820, 314);
            grdPreview.TabIndex = 1;
            grdPreview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvPreview });
            //
            // gvPreview
            //
            gvPreview.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvPreview.Appearance.HeaderPanel.Options.UseFont = true;
            gvPreview.Appearance.Row.Font = new Font("Cairo", 8F);
            gvPreview.Appearance.Row.Options.UseFont = true;
            gvPreview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPreviewItemNo, colPreviewDescriptionAr, colPreviewUnit, colPreviewQuantity, colPreviewUnitRate, colPreviewTotal });
            gvPreview.GridControl = grdPreview;
            gvPreview.Name = "gvPreview";
            gvPreview.OptionsView.ShowFooter = true;
            gvPreview.OptionsView.ShowGroupPanel = false;
            //
            // colPreviewItemNo
            //
            colPreviewItemNo.Caption = "رقم البند";
            colPreviewItemNo.FieldName = "ItemNo";
            colPreviewItemNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colPreviewItemNo.Name = "colPreviewItemNo";
            colPreviewItemNo.Visible = true;
            colPreviewItemNo.VisibleIndex = 0;
            colPreviewItemNo.Width = 100;
            //
            // colPreviewDescriptionAr
            //
            colPreviewDescriptionAr.Caption = "الوصف (عربي)";
            colPreviewDescriptionAr.FieldName = "DescriptionAr";
            colPreviewDescriptionAr.Name = "colPreviewDescriptionAr";
            colPreviewDescriptionAr.Visible = true;
            colPreviewDescriptionAr.VisibleIndex = 1;
            colPreviewDescriptionAr.Width = 260;
            //
            // colPreviewUnit
            //
            colPreviewUnit.Caption = "الوحدة";
            colPreviewUnit.FieldName = "Unit";
            colPreviewUnit.Name = "colPreviewUnit";
            colPreviewUnit.Visible = true;
            colPreviewUnit.VisibleIndex = 2;
            colPreviewUnit.Width = 90;
            //
            // colPreviewQuantity
            //
            colPreviewQuantity.Caption = "الكمية";
            colPreviewQuantity.DisplayFormat.FormatString = "N2";
            colPreviewQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPreviewQuantity.FieldName = "Quantity";
            colPreviewQuantity.Name = "colPreviewQuantity";
            colPreviewQuantity.Visible = true;
            colPreviewQuantity.VisibleIndex = 3;
            colPreviewQuantity.Width = 110;
            //
            // colPreviewUnitRate
            //
            colPreviewUnitRate.Caption = "سعر الوحدة";
            colPreviewUnitRate.DisplayFormat.FormatString = "N2";
            colPreviewUnitRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPreviewUnitRate.FieldName = "UnitRate";
            colPreviewUnitRate.Name = "colPreviewUnitRate";
            colPreviewUnitRate.Visible = true;
            colPreviewUnitRate.VisibleIndex = 4;
            colPreviewUnitRate.Width = 110;
            //
            // colPreviewTotal
            //
            colPreviewTotal.Caption = "الإجمالي";
            colPreviewTotal.DisplayFormat.FormatString = "N2";
            colPreviewTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPreviewTotal.FieldName = "Total";
            colPreviewTotal.Name = "colPreviewTotal";
            colPreviewTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "الإجمالي: {0:N2}") });
            colPreviewTotal.Visible = true;
            colPreviewTotal.VisibleIndex = 5;
            colPreviewTotal.Width = 130;
            //
            // wizPageSummary
            //
            wizPageSummary.AllowFinish = true;
            wizPageSummary.Controls.Add(btnViewLog);
            wizPageSummary.Controls.Add(lblImportErrorsValue);
            wizPageSummary.Controls.Add(lblImportErrorsTitle);
            wizPageSummary.Controls.Add(lblSkippedRowsValue);
            wizPageSummary.Controls.Add(lblSkippedRowsTitle);
            wizPageSummary.Controls.Add(lblImportedRowsValue);
            wizPageSummary.Controls.Add(lblImportedRowsTitle);
            wizPageSummary.Controls.Add(lblSummaryTitle);
            wizPageSummary.DescriptionText = "نتيجة عملية الاستيراد النهائية";
            wizPageSummary.Name = "wizPageSummary";
            wizPageSummary.Size = new Size(860, 380);
            wizPageSummary.Text = "ملخص الاستيراد";
            //
            // lblSummaryTitle
            //
            lblSummaryTitle.Appearance.Font = new Font("Cairo", 10F, FontStyle.Bold);
            lblSummaryTitle.Appearance.Options.UseFont = true;
            lblSummaryTitle.Location = new Point(20, 20);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(96, 21);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "ملخص الاستيراد";
            //
            // lblImportedRowsTitle
            //
            lblImportedRowsTitle.Appearance.Font = new Font("Cairo", 8F);
            lblImportedRowsTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblImportedRowsTitle.Appearance.Options.UseFont = true;
            lblImportedRowsTitle.Appearance.Options.UseForeColor = true;
            lblImportedRowsTitle.Location = new Point(20, 70);
            lblImportedRowsTitle.Name = "lblImportedRowsTitle";
            lblImportedRowsTitle.Size = new Size(74, 17);
            lblImportedRowsTitle.TabIndex = 1;
            lblImportedRowsTitle.Text = "الصفوف المستوردة";
            //
            // lblImportedRowsValue
            //
            lblImportedRowsValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblImportedRowsValue.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblImportedRowsValue.Appearance.Options.UseFont = true;
            lblImportedRowsValue.Appearance.Options.UseForeColor = true;
            lblImportedRowsValue.Location = new Point(20, 90);
            lblImportedRowsValue.Name = "lblImportedRowsValue";
            lblImportedRowsValue.Size = new Size(19, 32);
            lblImportedRowsValue.TabIndex = 2;
            lblImportedRowsValue.Text = "—";
            //
            // lblSkippedRowsTitle
            //
            lblSkippedRowsTitle.Appearance.Font = new Font("Cairo", 8F);
            lblSkippedRowsTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblSkippedRowsTitle.Appearance.Options.UseFont = true;
            lblSkippedRowsTitle.Appearance.Options.UseForeColor = true;
            lblSkippedRowsTitle.Location = new Point(240, 70);
            lblSkippedRowsTitle.Name = "lblSkippedRowsTitle";
            lblSkippedRowsTitle.Size = new Size(72, 17);
            lblSkippedRowsTitle.TabIndex = 3;
            lblSkippedRowsTitle.Text = "الصفوف المتجاهلة";
            //
            // lblSkippedRowsValue
            //
            lblSkippedRowsValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblSkippedRowsValue.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblSkippedRowsValue.Appearance.Options.UseFont = true;
            lblSkippedRowsValue.Appearance.Options.UseForeColor = true;
            lblSkippedRowsValue.Location = new Point(240, 90);
            lblSkippedRowsValue.Name = "lblSkippedRowsValue";
            lblSkippedRowsValue.Size = new Size(19, 32);
            lblSkippedRowsValue.TabIndex = 4;
            lblSkippedRowsValue.Text = "—";
            //
            // lblImportErrorsTitle
            //
            lblImportErrorsTitle.Appearance.Font = new Font("Cairo", 8F);
            lblImportErrorsTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblImportErrorsTitle.Appearance.Options.UseFont = true;
            lblImportErrorsTitle.Appearance.Options.UseForeColor = true;
            lblImportErrorsTitle.Location = new Point(460, 70);
            lblImportErrorsTitle.Name = "lblImportErrorsTitle";
            lblImportErrorsTitle.Size = new Size(33, 17);
            lblImportErrorsTitle.TabIndex = 5;
            lblImportErrorsTitle.Text = "الأخطاء";
            //
            // lblImportErrorsValue
            //
            lblImportErrorsValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblImportErrorsValue.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblImportErrorsValue.Appearance.Options.UseFont = true;
            lblImportErrorsValue.Appearance.Options.UseForeColor = true;
            lblImportErrorsValue.Location = new Point(460, 90);
            lblImportErrorsValue.Name = "lblImportErrorsValue";
            lblImportErrorsValue.Size = new Size(19, 32);
            lblImportErrorsValue.TabIndex = 6;
            lblImportErrorsValue.Text = "—";
            //
            // btnViewLog
            //
            btnViewLog.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnViewLog.ImageOptions.SvgImage");
            btnViewLog.Location = new Point(20, 150);
            btnViewLog.Name = "btnViewLog";
            btnViewLog.Size = new Size(140, 36);
            btnViewLog.TabIndex = 7;
            btnViewLog.Text = "عرض السجل";
            btnViewLog.Click += btnViewLog_Click;
            //
            // wizImport
            //
            wizImport.Dock = DockStyle.Fill;
            wizImport.Location = new Point(0, 0);
            wizImport.Name = "wizImport";
            wizImport.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] { wizPageFile, wizPageMapping, wizPageValidation, wizPagePreview, wizPageSummary });
            wizImport.Size = new Size(900, 640);
            wizImport.TabIndex = 0;
            wizImport.Text = "معالج استيراد جدول الكميات";
            wizImport.FinishClick += wizImport_FinishClick;
            wizImport.CancelClick += wizImport_CancelClick;
            //
            // frmBOQImportWizard
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 640);
            Controls.Add(wizImport);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBOQImportWizard";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "معالج استيراد جدول الكميات";

            wizPageFile.ResumeLayout(false);
            wizPageFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFilePath.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboSheetName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkFirstRowHeaders.Properties).EndInit();

            wizPageMapping.ResumeLayout(false);
            wizPageMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdColumnMapping).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvColumnMapping).EndInit();

            wizPageValidation.ResumeLayout(false);
            wizPageValidation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdValidation).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvValidation).EndInit();

            wizPagePreview.ResumeLayout(false);
            wizPagePreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvPreview).EndInit();

            wizPageSummary.ResumeLayout(false);
            wizPageSummary.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)wizImport).EndInit();
            wizImport.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizImport;

        private DevExpress.XtraWizard.WizardPage wizPageFile;
        private DevExpress.XtraEditors.LabelControl lblFilePath;
        private DevExpress.XtraEditors.TextEdit txtFilePath;
        private DevExpress.XtraEditors.SimpleButton btnBrowseFile;
        private DevExpress.XtraEditors.LabelControl lblSheetName;
        private DevExpress.XtraEditors.ComboBoxEdit cboSheetName;
        private DevExpress.XtraEditors.CheckEdit chkFirstRowHeaders;

        private DevExpress.XtraWizard.WizardPage wizPageMapping;
        private DevExpress.XtraEditors.LabelControl lblColumnMapping;
        private DevExpress.XtraGrid.GridControl grdColumnMapping;
        private DevExpress.XtraGrid.Views.Grid.GridView gvColumnMapping;
        private DevExpress.XtraGrid.Columns.GridColumn colExcelColumn;
        private DevExpress.XtraGrid.Columns.GridColumn colMapsTo;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;

        private DevExpress.XtraWizard.WizardPage wizPageValidation;
        private DevExpress.XtraEditors.LabelControl lblTotalRowsTitle;
        private DevExpress.XtraEditors.LabelControl lblTotalRowsValue;
        private DevExpress.XtraEditors.LabelControl lblErrorsTitle;
        private DevExpress.XtraEditors.LabelControl lblErrorsValue;
        private DevExpress.XtraEditors.LabelControl lblWarningsTitle;
        private DevExpress.XtraEditors.LabelControl lblWarningsValue;
        private DevExpress.XtraGrid.GridControl grdValidation;
        private DevExpress.XtraGrid.Views.Grid.GridView gvValidation;
        private DevExpress.XtraGrid.Columns.GridColumn colValidationRow;
        private DevExpress.XtraGrid.Columns.GridColumn colValidationField;
        private DevExpress.XtraGrid.Columns.GridColumn colValidationIssue;
        private DevExpress.XtraGrid.Columns.GridColumn colValidationSeverity;

        private DevExpress.XtraWizard.WizardPage wizPagePreview;
        private DevExpress.XtraEditors.LabelControl lblPreviewTitle;
        private DevExpress.XtraGrid.GridControl grdPreview;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPreview;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewDescriptionAr;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewUnitRate;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviewTotal;

        private DevExpress.XtraWizard.WizardPage wizPageSummary;
        private DevExpress.XtraEditors.LabelControl lblSummaryTitle;
        private DevExpress.XtraEditors.LabelControl lblImportedRowsTitle;
        private DevExpress.XtraEditors.LabelControl lblImportedRowsValue;
        private DevExpress.XtraEditors.LabelControl lblSkippedRowsTitle;
        private DevExpress.XtraEditors.LabelControl lblSkippedRowsValue;
        private DevExpress.XtraEditors.LabelControl lblImportErrorsTitle;
        private DevExpress.XtraEditors.LabelControl lblImportErrorsValue;
        private DevExpress.XtraEditors.SimpleButton btnViewLog;
    }
}
