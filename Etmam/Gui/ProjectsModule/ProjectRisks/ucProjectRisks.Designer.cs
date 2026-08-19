namespace Etmam
{
    partial class ucProjectRisks
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            barManagerRisks = new DevExpress.XtraBars.BarManager(components);
            barRisks = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiRecordCount = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();

            pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            pnlKpiOpenRisks = new DevExpress.XtraEditors.PanelControl();
            lblKpiOpenRisksTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiOpenRisksValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiHigh = new DevExpress.XtraEditors.PanelControl();
            lblKpiHighTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiHighValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiMedium = new DevExpress.XtraEditors.PanelControl();
            lblKpiMediumTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiMediumValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiLow = new DevExpress.XtraEditors.PanelControl();
            lblKpiLowTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiLowValue = new DevExpress.XtraEditors.LabelControl();

            grdRisks = new DevExpress.XtraGrid.GridControl();
            gvRisks = new DevExpress.XtraGrid.Views.Grid.GridView();
            colRiskId = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colProbability = new DevExpress.XtraGrid.Columns.GridColumn();
            colImpact = new DevExpress.XtraGrid.Columns.GridColumn();
            colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            colMitigation = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            gridFormatRuleImpactHigh = new DevExpress.XtraGrid.GridFormatRule();
            formatConditionRuleValueImpactHigh = new DevExpress.XtraEditors.FormatConditionRuleValue();
            gridFormatRuleImpactMedium = new DevExpress.XtraGrid.GridFormatRule();
            formatConditionRuleValueImpactMedium = new DevExpress.XtraEditors.FormatConditionRuleValue();
            gridFormatRuleImpactLow = new DevExpress.XtraGrid.GridFormatRule();
            formatConditionRuleValueImpactLow = new DevExpress.XtraEditors.FormatConditionRuleValue();

            pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            lblLoadingText = new DevExpress.XtraEditors.LabelControl();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            lblEmptyText = new DevExpress.XtraEditors.LabelControl();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl();
            svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();
            lblErrorText = new DevExpress.XtraEditors.LabelControl();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)barManagerRisks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit();
            pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiOpenRisks).BeginInit();
            pnlKpiOpenRisks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiHigh).BeginInit();
            pnlKpiHigh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiMedium).BeginInit();
            pnlKpiMedium.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiLow).BeginInit();
            pnlKpiLow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdRisks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvRisks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            SuspendLayout();
            //
            // barManagerRisks
            //
            barManagerRisks.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barRisks, barStatus });
            barManagerRisks.DockControls.Add(barDockControlTop);
            barManagerRisks.DockControls.Add(barDockControlBottom);
            barManagerRisks.DockControls.Add(barDockControlLeft);
            barManagerRisks.DockControls.Add(barDockControlRight);
            barManagerRisks.Form = this;
            barManagerRisks.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiEdit, bbiDelete, bbiPrint, bbiExportExcel, sbiRecordCount });
            barManagerRisks.MainMenu = barRisks;
            barManagerRisks.MaxItemId = 6;
            barManagerRisks.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerRisks.StatusBar = barStatus;
            //
            // barRisks
            //
            barRisks.BarName = "شريط أدوات المخاطر";
            barRisks.DockCol = 0;
            barRisks.DockRow = 0;
            barRisks.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barRisks.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barRisks.OptionsBar.AllowQuickCustomization = false;
            barRisks.OptionsBar.DrawDragBorder = false;
            barRisks.OptionsBar.MinHeight = 34;
            barRisks.OptionsBar.UseWholeRow = true;
            barRisks.Text = "شريط أدوات المخاطر";
            //
            // bbiAdd
            //
            bbiAdd.Caption = "إضافة";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.SvgImage = Etmam.IconLoader.Get("add.svg");
            bbiAdd.Name = "bbiAdd";
            bbiAdd.ItemClick += bbiAdd_ItemClick;
            //
            // bbiEdit
            //
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 1;
            bbiEdit.ImageOptions.SvgImage = Etmam.IconLoader.Get("edit.svg");
            bbiEdit.Name = "bbiEdit";
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            //
            // bbiDelete
            //
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 2;
            bbiDelete.ImageOptions.SvgImage = Etmam.IconLoader.Get("delete.svg");
            bbiDelete.Name = "bbiDelete";
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            //
            // bbiPrint
            //
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 3;
            bbiPrint.ImageOptions.SvgImage = Etmam.IconLoader.Get("print.svg");
            bbiPrint.Name = "bbiPrint";
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            //
            // bbiExportExcel
            //
            bbiExportExcel.Caption = "تصدير Excel";
            bbiExportExcel.Id = 4;
            bbiExportExcel.ImageOptions.SvgImage = Etmam.IconLoader.Get("export_excel.svg");
            bbiExportExcel.Name = "bbiExportExcel";
            bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            //
            // barStatus
            //
            barStatus.BarName = "شريط الحالة";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(sbiRecordCount) });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "شريط الحالة";
            //
            // sbiRecordCount
            //
            sbiRecordCount.Caption = "عدد المخاطر: 0";
            sbiRecordCount.Id = 5;
            sbiRecordCount.Name = "sbiRecordCount";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerRisks;
            barDockControlTop.Size = new Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 796);
            barDockControlBottom.Manager = barManagerRisks;
            barDockControlBottom.Size = new Size(1366, 24);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerRisks;
            barDockControlLeft.Size = new Size(0, 762);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerRisks;
            barDockControlRight.Size = new Size(0, 762);
            //
            // pnlKpiCards
            //
            pnlKpiCards.Controls.Add(pnlKpiLow);
            pnlKpiCards.Controls.Add(pnlKpiMedium);
            pnlKpiCards.Controls.Add(pnlKpiHigh);
            pnlKpiCards.Controls.Add(pnlKpiOpenRisks);
            pnlKpiCards.Dock = DockStyle.Top;
            pnlKpiCards.Location = new Point(0, 34);
            pnlKpiCards.Name = "pnlKpiCards";
            pnlKpiCards.Size = new Size(1366, 106);
            pnlKpiCards.TabIndex = 0;
            //
            // pnlKpiOpenRisks
            //
            pnlKpiOpenRisks.Appearance.BackColor = Color.FromArgb(234, 243, 252);
            pnlKpiOpenRisks.Appearance.Options.UseBackColor = true;
            pnlKpiOpenRisks.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiOpenRisks.Controls.Add(lblKpiOpenRisksValue);
            pnlKpiOpenRisks.Controls.Add(lblKpiOpenRisksTitle);
            pnlKpiOpenRisks.Location = new Point(20, 10);
            pnlKpiOpenRisks.Name = "pnlKpiOpenRisks";
            pnlKpiOpenRisks.Size = new Size(310, 86);
            pnlKpiOpenRisks.TabIndex = 0;
            //
            // lblKpiOpenRisksTitle
            //
            lblKpiOpenRisksTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiOpenRisksTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiOpenRisksTitle.Appearance.Options.UseFont = true;
            lblKpiOpenRisksTitle.Appearance.Options.UseForeColor = true;
            lblKpiOpenRisksTitle.Location = new Point(12, 10);
            lblKpiOpenRisksTitle.Name = "lblKpiOpenRisksTitle";
            lblKpiOpenRisksTitle.Size = new Size(75, 17);
            lblKpiOpenRisksTitle.TabIndex = 0;
            lblKpiOpenRisksTitle.Text = "المخاطر المفتوحة";
            //
            // lblKpiOpenRisksValue
            //
            lblKpiOpenRisksValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiOpenRisksValue.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblKpiOpenRisksValue.Appearance.Options.UseFont = true;
            lblKpiOpenRisksValue.Appearance.Options.UseForeColor = true;
            lblKpiOpenRisksValue.Location = new Point(12, 34);
            lblKpiOpenRisksValue.Name = "lblKpiOpenRisksValue";
            lblKpiOpenRisksValue.Size = new Size(20, 25);
            lblKpiOpenRisksValue.TabIndex = 1;
            lblKpiOpenRisksValue.Text = "—";
            //
            // pnlKpiHigh
            //
            pnlKpiHigh.Appearance.BackColor = Color.FromArgb(253, 237, 236);
            pnlKpiHigh.Appearance.Options.UseBackColor = true;
            pnlKpiHigh.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiHigh.Controls.Add(lblKpiHighValue);
            pnlKpiHigh.Controls.Add(lblKpiHighTitle);
            pnlKpiHigh.Location = new Point(350, 10);
            pnlKpiHigh.Name = "pnlKpiHigh";
            pnlKpiHigh.Size = new Size(310, 86);
            pnlKpiHigh.TabIndex = 1;
            //
            // lblKpiHighTitle
            //
            lblKpiHighTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiHighTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiHighTitle.Appearance.Options.UseFont = true;
            lblKpiHighTitle.Appearance.Options.UseForeColor = true;
            lblKpiHighTitle.Location = new Point(12, 10);
            lblKpiHighTitle.Name = "lblKpiHighTitle";
            lblKpiHighTitle.Size = new Size(43, 17);
            lblKpiHighTitle.TabIndex = 0;
            lblKpiHighTitle.Text = "مرتفعة";
            //
            // lblKpiHighValue
            //
            lblKpiHighValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiHighValue.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblKpiHighValue.Appearance.Options.UseFont = true;
            lblKpiHighValue.Appearance.Options.UseForeColor = true;
            lblKpiHighValue.Location = new Point(12, 34);
            lblKpiHighValue.Name = "lblKpiHighValue";
            lblKpiHighValue.Size = new Size(20, 25);
            lblKpiHighValue.TabIndex = 1;
            lblKpiHighValue.Text = "—";
            //
            // pnlKpiMedium
            //
            pnlKpiMedium.Appearance.BackColor = Color.FromArgb(255, 246, 229);
            pnlKpiMedium.Appearance.Options.UseBackColor = true;
            pnlKpiMedium.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiMedium.Controls.Add(lblKpiMediumValue);
            pnlKpiMedium.Controls.Add(lblKpiMediumTitle);
            pnlKpiMedium.Location = new Point(680, 10);
            pnlKpiMedium.Name = "pnlKpiMedium";
            pnlKpiMedium.Size = new Size(310, 86);
            pnlKpiMedium.TabIndex = 2;
            //
            // lblKpiMediumTitle
            //
            lblKpiMediumTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiMediumTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiMediumTitle.Appearance.Options.UseFont = true;
            lblKpiMediumTitle.Appearance.Options.UseForeColor = true;
            lblKpiMediumTitle.Location = new Point(12, 10);
            lblKpiMediumTitle.Name = "lblKpiMediumTitle";
            lblKpiMediumTitle.Size = new Size(50, 17);
            lblKpiMediumTitle.TabIndex = 0;
            lblKpiMediumTitle.Text = "متوسطة";
            //
            // lblKpiMediumValue
            //
            lblKpiMediumValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiMediumValue.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblKpiMediumValue.Appearance.Options.UseFont = true;
            lblKpiMediumValue.Appearance.Options.UseForeColor = true;
            lblKpiMediumValue.Location = new Point(12, 34);
            lblKpiMediumValue.Name = "lblKpiMediumValue";
            lblKpiMediumValue.Size = new Size(20, 25);
            lblKpiMediumValue.TabIndex = 1;
            lblKpiMediumValue.Text = "—";
            //
            // pnlKpiLow
            //
            pnlKpiLow.Appearance.BackColor = Color.FromArgb(234, 247, 239);
            pnlKpiLow.Appearance.Options.UseBackColor = true;
            pnlKpiLow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiLow.Controls.Add(lblKpiLowValue);
            pnlKpiLow.Controls.Add(lblKpiLowTitle);
            pnlKpiLow.Location = new Point(1010, 10);
            pnlKpiLow.Name = "pnlKpiLow";
            pnlKpiLow.Size = new Size(310, 86);
            pnlKpiLow.TabIndex = 3;
            //
            // lblKpiLowTitle
            //
            lblKpiLowTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiLowTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiLowTitle.Appearance.Options.UseFont = true;
            lblKpiLowTitle.Appearance.Options.UseForeColor = true;
            lblKpiLowTitle.Location = new Point(12, 10);
            lblKpiLowTitle.Name = "lblKpiLowTitle";
            lblKpiLowTitle.Size = new Size(37, 17);
            lblKpiLowTitle.TabIndex = 0;
            lblKpiLowTitle.Text = "منخفضة";
            //
            // lblKpiLowValue
            //
            lblKpiLowValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiLowValue.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblKpiLowValue.Appearance.Options.UseFont = true;
            lblKpiLowValue.Appearance.Options.UseForeColor = true;
            lblKpiLowValue.Location = new Point(12, 34);
            lblKpiLowValue.Name = "lblKpiLowValue";
            lblKpiLowValue.Size = new Size(20, 25);
            lblKpiLowValue.TabIndex = 1;
            lblKpiLowValue.Text = "—";
            //
            // grdRisks
            //
            grdRisks.Dock = DockStyle.Fill;
            grdRisks.Location = new Point(0, 140);
            grdRisks.MainView = gvRisks;
            grdRisks.MenuManager = barManagerRisks;
            grdRisks.Name = "grdRisks";
            grdRisks.Size = new Size(1366, 656);
            grdRisks.TabIndex = 1;
            grdRisks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvRisks });
            //
            // gvRisks
            //
            gvRisks.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvRisks.Appearance.HeaderPanel.Options.UseFont = true;
            gvRisks.Appearance.Row.Font = new Font("Cairo", 8F);
            gvRisks.Appearance.Row.Options.UseFont = true;
            gvRisks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colRiskId, colDescription, colProbability, colImpact, colOwner, colMitigation, colStatus });
            gvRisks.FormatRules.AddRange(new DevExpress.XtraGrid.GridFormatRule[] { gridFormatRuleImpactHigh, gridFormatRuleImpactMedium, gridFormatRuleImpactLow });
            gvRisks.GridControl = grdRisks;
            gvRisks.Name = "gvRisks";
            gvRisks.OptionsView.ColumnAutoWidth = false;
            gvRisks.OptionsView.ShowAutoFilterRow = true;
            gvRisks.OptionsView.ShowFooter = true;
            //
            // colRiskId
            //
            colRiskId.Caption = "معرف الخطر";
            colRiskId.FieldName = "RiskId";
            colRiskId.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colRiskId.Name = "colRiskId";
            colRiskId.OptionsColumn.AllowEdit = false;
            colRiskId.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RiskId", "العدد: {0}") });
            colRiskId.Visible = true;
            colRiskId.VisibleIndex = 0;
            colRiskId.Width = 110;
            //
            // colDescription
            //
            colDescription.Caption = "الوصف";
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.OptionsColumn.AllowEdit = false;
            colDescription.Visible = true;
            colDescription.VisibleIndex = 1;
            colDescription.Width = 340;
            //
            // colProbability
            //
            colProbability.Caption = "الاحتمالية";
            colProbability.FieldName = "Probability";
            colProbability.Name = "colProbability";
            colProbability.OptionsColumn.AllowEdit = false;
            colProbability.Visible = true;
            colProbability.VisibleIndex = 2;
            colProbability.Width = 110;
            //
            // colImpact
            //
            colImpact.Caption = "التأثير";
            colImpact.FieldName = "Impact";
            colImpact.Name = "colImpact";
            colImpact.OptionsColumn.AllowEdit = false;
            colImpact.Visible = true;
            colImpact.VisibleIndex = 3;
            colImpact.Width = 110;
            //
            // colOwner
            //
            colOwner.Caption = "المسؤول";
            colOwner.FieldName = "Owner";
            colOwner.Name = "colOwner";
            colOwner.OptionsColumn.AllowEdit = false;
            colOwner.Visible = true;
            colOwner.VisibleIndex = 4;
            colOwner.Width = 160;
            //
            // colMitigation
            //
            colMitigation.Caption = "إجراء التخفيف";
            colMitigation.FieldName = "Mitigation";
            colMitigation.Name = "colMitigation";
            colMitigation.OptionsColumn.AllowEdit = false;
            colMitigation.Visible = true;
            colMitigation.VisibleIndex = 5;
            colMitigation.Width = 300;
            //
            // colStatus
            //
            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.OptionsColumn.AllowEdit = false;
            colStatus.Visible = true;
            colStatus.VisibleIndex = 6;
            colStatus.Width = 120;
            //
            // gridFormatRuleImpactHigh
            //
            gridFormatRuleImpactHigh.Column = colImpact;
            gridFormatRuleImpactHigh.Name = "gridFormatRuleImpactHigh";
            gridFormatRuleImpactHigh.Rule = formatConditionRuleValueImpactHigh;
            //
            // formatConditionRuleValueImpactHigh
            //
            formatConditionRuleValueImpactHigh.Appearance.BackColor = Color.FromArgb(253, 237, 236);
            formatConditionRuleValueImpactHigh.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            formatConditionRuleValueImpactHigh.Appearance.Options.UseBackColor = true;
            formatConditionRuleValueImpactHigh.Appearance.Options.UseForeColor = true;
            formatConditionRuleValueImpactHigh.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValueImpactHigh.Value1 = "مرتفع";
            //
            // gridFormatRuleImpactMedium
            //
            gridFormatRuleImpactMedium.Column = colImpact;
            gridFormatRuleImpactMedium.Name = "gridFormatRuleImpactMedium";
            gridFormatRuleImpactMedium.Rule = formatConditionRuleValueImpactMedium;
            //
            // formatConditionRuleValueImpactMedium
            //
            formatConditionRuleValueImpactMedium.Appearance.BackColor = Color.FromArgb(255, 246, 229);
            formatConditionRuleValueImpactMedium.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            formatConditionRuleValueImpactMedium.Appearance.Options.UseBackColor = true;
            formatConditionRuleValueImpactMedium.Appearance.Options.UseForeColor = true;
            formatConditionRuleValueImpactMedium.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValueImpactMedium.Value1 = "متوسط";
            //
            // gridFormatRuleImpactLow
            //
            gridFormatRuleImpactLow.Column = colImpact;
            gridFormatRuleImpactLow.Name = "gridFormatRuleImpactLow";
            gridFormatRuleImpactLow.Rule = formatConditionRuleValueImpactLow;
            //
            // formatConditionRuleValueImpactLow
            //
            formatConditionRuleValueImpactLow.Appearance.BackColor = Color.FromArgb(234, 247, 239);
            formatConditionRuleValueImpactLow.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            formatConditionRuleValueImpactLow.Appearance.Options.UseBackColor = true;
            formatConditionRuleValueImpactLow.Appearance.Options.UseForeColor = true;
            formatConditionRuleValueImpactLow.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValueImpactLow.Value1 = "منخفض";
            //
            // pnlLoadingState
            //
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 140);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 656);
            pnlLoadingState.TabIndex = 2;
            pnlLoadingState.Visible = false;
            //
            // svgLoadingIcon
            //
            svgLoadingIcon.Location = new Point(651, 280);
            svgLoadingIcon.Name = "svgLoadingIcon";
            svgLoadingIcon.Size = new Size(64, 64);
            svgLoadingIcon.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            svgLoadingIcon.TabIndex = 0;
            //
            // lblLoadingText
            //
            lblLoadingText.Appearance.Font = new Font("Cairo", 10F);
            lblLoadingText.Appearance.Options.UseFont = true;
            lblLoadingText.Appearance.Options.UseTextOptions = true;
            lblLoadingText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblLoadingText.Location = new Point(583, 354);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(200, 20);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل المخاطر...";
            //
            // pnlEmptyState
            //
            pnlEmptyState.Controls.Add(lblEmptyText);
            pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Dock = DockStyle.Fill;
            pnlEmptyState.Location = new Point(0, 140);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 656);
            pnlEmptyState.TabIndex = 3;
            pnlEmptyState.Visible = false;
            //
            // svgEmptyIcon
            //
            svgEmptyIcon.Location = new Point(651, 280);
            svgEmptyIcon.Name = "svgEmptyIcon";
            svgEmptyIcon.Size = new Size(64, 64);
            svgEmptyIcon.SvgImage = Etmam.IconLoader.Get("empty.svg");
            svgEmptyIcon.TabIndex = 0;
            //
            // lblEmptyText
            //
            lblEmptyText.Appearance.Font = new Font("Cairo", 10F);
            lblEmptyText.Appearance.Options.UseFont = true;
            lblEmptyText.Appearance.Options.UseTextOptions = true;
            lblEmptyText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyText.Location = new Point(583, 354);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(200, 20);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا توجد مخاطر مسجلة";
            //
            // pnlErrorState
            //
            pnlErrorState.Controls.Add(btnRetry);
            pnlErrorState.Controls.Add(lblErrorText);
            pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Dock = DockStyle.Fill;
            pnlErrorState.Location = new Point(0, 140);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 656);
            pnlErrorState.TabIndex = 4;
            pnlErrorState.Visible = false;
            //
            // svgErrorIcon
            //
            svgErrorIcon.Location = new Point(651, 260);
            svgErrorIcon.Name = "svgErrorIcon";
            svgErrorIcon.Size = new Size(64, 64);
            svgErrorIcon.SvgImage = Etmam.IconLoader.Get("error.svg");
            svgErrorIcon.TabIndex = 0;
            //
            // lblErrorText
            //
            lblErrorText.Appearance.Font = new Font("Cairo", 10F);
            lblErrorText.Appearance.Options.UseFont = true;
            lblErrorText.Appearance.Options.UseTextOptions = true;
            lblErrorText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblErrorText.Location = new Point(583, 334);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(200, 20);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل المخاطر";
            //
            // btnRetry
            //
            btnRetry.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            btnRetry.Location = new Point(633, 364);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(100, 28);
            btnRetry.TabIndex = 2;
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;
            //
            // ucProjectRisks
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grdRisks);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlKpiCards);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucProjectRisks";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 820);
            ((System.ComponentModel.ISupportInitialize)barManagerRisks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit();
            pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiOpenRisks).EndInit();
            pnlKpiOpenRisks.ResumeLayout(false);
            pnlKpiOpenRisks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiHigh).EndInit();
            pnlKpiHigh.ResumeLayout(false);
            pnlKpiHigh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiMedium).EndInit();
            pnlKpiMedium.ResumeLayout(false);
            pnlKpiMedium.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiLow).EndInit();
            pnlKpiLow.ResumeLayout(false);
            pnlKpiLow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdRisks).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvRisks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit();
            pnlLoadingState.ResumeLayout(false);
            pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit();
            pnlEmptyState.ResumeLayout(false);
            pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit();
            pnlErrorState.ResumeLayout(false);
            pnlErrorState.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerRisks;
        private DevExpress.XtraBars.Bar barRisks;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExportExcel;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.PanelControl pnlKpiOpenRisks;
        private DevExpress.XtraEditors.LabelControl lblKpiOpenRisksTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiOpenRisksValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiHigh;
        private DevExpress.XtraEditors.LabelControl lblKpiHighTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiHighValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiMedium;
        private DevExpress.XtraEditors.LabelControl lblKpiMediumTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiMediumValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiLow;
        private DevExpress.XtraEditors.LabelControl lblKpiLowTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiLowValue;

        private DevExpress.XtraGrid.GridControl grdRisks;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRisks;
        private DevExpress.XtraGrid.Columns.GridColumn colRiskId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colProbability;
        private DevExpress.XtraGrid.Columns.GridColumn colImpact;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colMitigation;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.GridFormatRule gridFormatRuleImpactHigh;
        private DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValueImpactHigh;
        private DevExpress.XtraGrid.GridFormatRule gridFormatRuleImpactMedium;
        private DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValueImpactMedium;
        private DevExpress.XtraGrid.GridFormatRule gridFormatRuleImpactLow;
        private DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValueImpactLow;

        private DevExpress.XtraEditors.PanelControl pnlLoadingState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText;
        private DevExpress.XtraEditors.PanelControl pnlEmptyState;
        private DevExpress.XtraEditors.SvgImageBox svgEmptyIcon;
        private DevExpress.XtraEditors.LabelControl lblEmptyText;
        private DevExpress.XtraEditors.PanelControl pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}
