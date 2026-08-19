namespace Etmam
{
    partial class ucProjectDashboard
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
            pnlHeader = new DevExpress.XtraEditors.PanelControl();
            lblDashboardTitle = new DevExpress.XtraEditors.LabelControl();
            lblProjectNameSubtitle = new DevExpress.XtraEditors.LabelControl();
            btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            btnPrint = new DevExpress.XtraEditors.SimpleButton();
            btnExportPdf = new DevExpress.XtraEditors.SimpleButton();

            pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            pnlKpiOverallProgress = new DevExpress.XtraEditors.PanelControl();
            lblKpiOverallProgressTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiOverallProgressValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiBudgetUtilization = new DevExpress.XtraEditors.PanelControl();
            lblKpiBudgetUtilizationTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiBudgetUtilizationValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiOpenRisks = new DevExpress.XtraEditors.PanelControl();
            lblKpiOpenRisksTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiOpenRisksValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiOpenIssues = new DevExpress.XtraEditors.PanelControl();
            lblKpiOpenIssuesTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiOpenIssuesValue = new DevExpress.XtraEditors.LabelControl();

            pnlCharts = new DevExpress.XtraEditors.PanelControl();
            lblSCurveCaption = new DevExpress.XtraEditors.LabelControl();
            chartSCurve = new DevExpress.XtraCharts.ChartControl();
            seriesSCurvePlanned = new DevExpress.XtraCharts.Series("المخطط", DevExpress.XtraCharts.ViewType.Spline);
            seriesSCurveActual = new DevExpress.XtraCharts.Series("الفعلي", DevExpress.XtraCharts.ViewType.Spline);
            xyDiagramSCurve = new DevExpress.XtraCharts.XYDiagram();
            lblBudgetVsActualCaption = new DevExpress.XtraEditors.LabelControl();
            chartBudgetVsActual = new DevExpress.XtraCharts.ChartControl();
            seriesBudget = new DevExpress.XtraCharts.Series("الموازنة", DevExpress.XtraCharts.ViewType.Bar);
            seriesActualCost = new DevExpress.XtraCharts.Series("الفعلي", DevExpress.XtraCharts.ViewType.Bar);
            xyDiagramBudgetVsActual = new DevExpress.XtraCharts.XYDiagram();

            grdNotifications = new DevExpress.XtraGrid.GridControl();
            gvNotifications = new DevExpress.XtraGrid.Views.Grid.GridView();
            colType = new DevExpress.XtraGrid.Columns.GridColumn();
            colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

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

            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit();
            pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiOverallProgress).BeginInit();
            pnlKpiOverallProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiBudgetUtilization).BeginInit();
            pnlKpiBudgetUtilization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiOpenRisks).BeginInit();
            pnlKpiOpenRisks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiOpenIssues).BeginInit();
            pnlKpiOpenIssues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).BeginInit();
            pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartSCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesSCurvePlanned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesSCurveActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramSCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartBudgetVsActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramBudgetVsActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdNotifications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvNotifications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.Appearance.BackColor = Color.FromArgb(240, 244, 244);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(btnExportPdf);
            pnlHeader.Controls.Add(btnPrint);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(lblProjectNameSubtitle);
            pnlHeader.Controls.Add(lblDashboardTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1366, 64);
            pnlHeader.TabIndex = 0;
            //
            // lblDashboardTitle
            //
            lblDashboardTitle.Appearance.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblDashboardTitle.Appearance.ForeColor = Color.FromArgb(13, 131, 135);
            lblDashboardTitle.Appearance.Options.UseFont = true;
            lblDashboardTitle.Appearance.Options.UseForeColor = true;
            lblDashboardTitle.Location = new Point(20, 12);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(160, 25);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "لوحة معلومات المشروع";
            //
            // lblProjectNameSubtitle
            //
            lblProjectNameSubtitle.Appearance.Font = new Font("Cairo", 9F);
            lblProjectNameSubtitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblProjectNameSubtitle.Appearance.Options.UseFont = true;
            lblProjectNameSubtitle.Appearance.Options.UseForeColor = true;
            lblProjectNameSubtitle.Location = new Point(20, 39);
            lblProjectNameSubtitle.Name = "lblProjectNameSubtitle";
            lblProjectNameSubtitle.Size = new Size(11, 20);
            lblProjectNameSubtitle.TabIndex = 1;
            lblProjectNameSubtitle.Text = "—";
            //
            // btnRefresh
            //
            btnRefresh.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            btnRefresh.Location = new Point(980, 16);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 32);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "تحديث";
            btnRefresh.Click += btnRefresh_Click;
            //
            // btnPrint
            //
            btnPrint.ImageOptions.SvgImage = Etmam.IconLoader.Get("print.svg");
            btnPrint.Location = new Point(1090, 16);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(100, 32);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "طباعة";
            btnPrint.Click += btnPrint_Click;
            //
            // btnExportPdf
            //
            btnExportPdf.ImageOptions.SvgImage = Etmam.IconLoader.Get("export_pdf.svg");
            btnExportPdf.Location = new Point(1200, 16);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(100, 32);
            btnExportPdf.TabIndex = 4;
            btnExportPdf.Text = "تصدير PDF";
            btnExportPdf.Click += btnExportPdf_Click;
            //
            // pnlKpiCards
            //
            pnlKpiCards.Controls.Add(pnlKpiOpenIssues);
            pnlKpiCards.Controls.Add(pnlKpiOpenRisks);
            pnlKpiCards.Controls.Add(pnlKpiBudgetUtilization);
            pnlKpiCards.Controls.Add(pnlKpiOverallProgress);
            pnlKpiCards.Dock = DockStyle.Top;
            pnlKpiCards.Location = new Point(0, 64);
            pnlKpiCards.Name = "pnlKpiCards";
            pnlKpiCards.Size = new Size(1366, 106);
            pnlKpiCards.TabIndex = 1;
            //
            // pnlKpiOverallProgress
            //
            pnlKpiOverallProgress.Appearance.BackColor = Color.FromArgb(234, 243, 252);
            pnlKpiOverallProgress.Appearance.Options.UseBackColor = true;
            pnlKpiOverallProgress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiOverallProgress.Controls.Add(lblKpiOverallProgressValue);
            pnlKpiOverallProgress.Controls.Add(lblKpiOverallProgressTitle);
            pnlKpiOverallProgress.Location = new Point(20, 10);
            pnlKpiOverallProgress.Name = "pnlKpiOverallProgress";
            pnlKpiOverallProgress.Size = new Size(310, 86);
            pnlKpiOverallProgress.TabIndex = 0;
            //
            // lblKpiOverallProgressTitle
            //
            lblKpiOverallProgressTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiOverallProgressTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiOverallProgressTitle.Appearance.Options.UseFont = true;
            lblKpiOverallProgressTitle.Appearance.Options.UseForeColor = true;
            lblKpiOverallProgressTitle.Location = new Point(12, 10);
            lblKpiOverallProgressTitle.Name = "lblKpiOverallProgressTitle";
            lblKpiOverallProgressTitle.Size = new Size(78, 17);
            lblKpiOverallProgressTitle.TabIndex = 0;
            lblKpiOverallProgressTitle.Text = "نسبة الإنجاز الكلي";
            //
            // lblKpiOverallProgressValue
            //
            lblKpiOverallProgressValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiOverallProgressValue.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblKpiOverallProgressValue.Appearance.Options.UseFont = true;
            lblKpiOverallProgressValue.Appearance.Options.UseForeColor = true;
            lblKpiOverallProgressValue.Location = new Point(12, 34);
            lblKpiOverallProgressValue.Name = "lblKpiOverallProgressValue";
            lblKpiOverallProgressValue.Size = new Size(20, 25);
            lblKpiOverallProgressValue.TabIndex = 1;
            lblKpiOverallProgressValue.Text = "—";
            //
            // pnlKpiBudgetUtilization
            //
            pnlKpiBudgetUtilization.Appearance.BackColor = Color.FromArgb(232, 246, 246);
            pnlKpiBudgetUtilization.Appearance.Options.UseBackColor = true;
            pnlKpiBudgetUtilization.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiBudgetUtilization.Controls.Add(lblKpiBudgetUtilizationValue);
            pnlKpiBudgetUtilization.Controls.Add(lblKpiBudgetUtilizationTitle);
            pnlKpiBudgetUtilization.Location = new Point(350, 10);
            pnlKpiBudgetUtilization.Name = "pnlKpiBudgetUtilization";
            pnlKpiBudgetUtilization.Size = new Size(310, 86);
            pnlKpiBudgetUtilization.TabIndex = 1;
            //
            // lblKpiBudgetUtilizationTitle
            //
            lblKpiBudgetUtilizationTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiBudgetUtilizationTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiBudgetUtilizationTitle.Appearance.Options.UseFont = true;
            lblKpiBudgetUtilizationTitle.Appearance.Options.UseForeColor = true;
            lblKpiBudgetUtilizationTitle.Location = new Point(12, 10);
            lblKpiBudgetUtilizationTitle.Name = "lblKpiBudgetUtilizationTitle";
            lblKpiBudgetUtilizationTitle.Size = new Size(85, 17);
            lblKpiBudgetUtilizationTitle.TabIndex = 0;
            lblKpiBudgetUtilizationTitle.Text = "نسبة استغلال الموازنة";
            //
            // lblKpiBudgetUtilizationValue
            //
            lblKpiBudgetUtilizationValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiBudgetUtilizationValue.Appearance.ForeColor = Color.FromArgb(28, 140, 140);
            lblKpiBudgetUtilizationValue.Appearance.Options.UseFont = true;
            lblKpiBudgetUtilizationValue.Appearance.Options.UseForeColor = true;
            lblKpiBudgetUtilizationValue.Location = new Point(12, 34);
            lblKpiBudgetUtilizationValue.Name = "lblKpiBudgetUtilizationValue";
            lblKpiBudgetUtilizationValue.Size = new Size(20, 25);
            lblKpiBudgetUtilizationValue.TabIndex = 1;
            lblKpiBudgetUtilizationValue.Text = "—";
            //
            // pnlKpiOpenRisks
            //
            pnlKpiOpenRisks.Appearance.BackColor = Color.FromArgb(253, 237, 236);
            pnlKpiOpenRisks.Appearance.Options.UseBackColor = true;
            pnlKpiOpenRisks.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiOpenRisks.Controls.Add(lblKpiOpenRisksValue);
            pnlKpiOpenRisks.Controls.Add(lblKpiOpenRisksTitle);
            pnlKpiOpenRisks.Location = new Point(680, 10);
            pnlKpiOpenRisks.Name = "pnlKpiOpenRisks";
            pnlKpiOpenRisks.Size = new Size(310, 86);
            pnlKpiOpenRisks.TabIndex = 2;
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
            lblKpiOpenRisksValue.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblKpiOpenRisksValue.Appearance.Options.UseFont = true;
            lblKpiOpenRisksValue.Appearance.Options.UseForeColor = true;
            lblKpiOpenRisksValue.Location = new Point(12, 34);
            lblKpiOpenRisksValue.Name = "lblKpiOpenRisksValue";
            lblKpiOpenRisksValue.Size = new Size(20, 25);
            lblKpiOpenRisksValue.TabIndex = 1;
            lblKpiOpenRisksValue.Text = "—";
            //
            // pnlKpiOpenIssues
            //
            pnlKpiOpenIssues.Appearance.BackColor = Color.FromArgb(255, 246, 229);
            pnlKpiOpenIssues.Appearance.Options.UseBackColor = true;
            pnlKpiOpenIssues.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiOpenIssues.Controls.Add(lblKpiOpenIssuesValue);
            pnlKpiOpenIssues.Controls.Add(lblKpiOpenIssuesTitle);
            pnlKpiOpenIssues.Location = new Point(1010, 10);
            pnlKpiOpenIssues.Name = "pnlKpiOpenIssues";
            pnlKpiOpenIssues.Size = new Size(310, 86);
            pnlKpiOpenIssues.TabIndex = 3;
            //
            // lblKpiOpenIssuesTitle
            //
            lblKpiOpenIssuesTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiOpenIssuesTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiOpenIssuesTitle.Appearance.Options.UseFont = true;
            lblKpiOpenIssuesTitle.Appearance.Options.UseForeColor = true;
            lblKpiOpenIssuesTitle.Location = new Point(12, 10);
            lblKpiOpenIssuesTitle.Name = "lblKpiOpenIssuesTitle";
            lblKpiOpenIssuesTitle.Size = new Size(70, 17);
            lblKpiOpenIssuesTitle.TabIndex = 0;
            lblKpiOpenIssuesTitle.Text = "المشكلات المفتوحة";
            //
            // lblKpiOpenIssuesValue
            //
            lblKpiOpenIssuesValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiOpenIssuesValue.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblKpiOpenIssuesValue.Appearance.Options.UseFont = true;
            lblKpiOpenIssuesValue.Appearance.Options.UseForeColor = true;
            lblKpiOpenIssuesValue.Location = new Point(12, 34);
            lblKpiOpenIssuesValue.Name = "lblKpiOpenIssuesValue";
            lblKpiOpenIssuesValue.Size = new Size(20, 25);
            lblKpiOpenIssuesValue.TabIndex = 1;
            lblKpiOpenIssuesValue.Text = "—";
            //
            // pnlCharts
            //
            pnlCharts.Controls.Add(chartBudgetVsActual);
            pnlCharts.Controls.Add(lblBudgetVsActualCaption);
            pnlCharts.Controls.Add(chartSCurve);
            pnlCharts.Controls.Add(lblSCurveCaption);
            pnlCharts.Dock = DockStyle.Top;
            pnlCharts.Location = new Point(0, 170);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Size = new Size(1366, 340);
            pnlCharts.TabIndex = 2;
            //
            // lblSCurveCaption
            //
            lblSCurveCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblSCurveCaption.Appearance.Options.UseFont = true;
            lblSCurveCaption.Location = new Point(12, 12);
            lblSCurveCaption.Name = "lblSCurveCaption";
            lblSCurveCaption.Size = new Size(110, 20);
            lblSCurveCaption.TabIndex = 0;
            lblSCurveCaption.Text = "منحنى الإنجاز (S Curve)";
            //
            // chartSCurve
            //
            chartSCurve.Diagram = xyDiagramSCurve;
            chartSCurve.Location = new Point(12, 36);
            chartSCurve.Name = "chartSCurve";
            chartSCurve.SeriesTemplate.View = new DevExpress.XtraCharts.SplineSeriesView();
            chartSCurve.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesSCurvePlanned, seriesSCurveActual });
            chartSCurve.Size = new Size(660, 296);
            chartSCurve.TabIndex = 1;
            //
            // seriesSCurvePlanned
            //
            seriesSCurvePlanned.Name = "المخطط";
            seriesSCurvePlanned.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // seriesSCurveActual
            //
            seriesSCurveActual.Name = "الفعلي";
            seriesSCurveActual.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // xyDiagramSCurve
            //
            //
            // lblBudgetVsActualCaption
            //
            lblBudgetVsActualCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblBudgetVsActualCaption.Appearance.Options.UseFont = true;
            lblBudgetVsActualCaption.Location = new Point(684, 12);
            lblBudgetVsActualCaption.Name = "lblBudgetVsActualCaption";
            lblBudgetVsActualCaption.Size = new Size(100, 20);
            lblBudgetVsActualCaption.TabIndex = 2;
            lblBudgetVsActualCaption.Text = "الموازنة مقابل الفعلي";
            //
            // chartBudgetVsActual
            //
            chartBudgetVsActual.Diagram = xyDiagramBudgetVsActual;
            chartBudgetVsActual.Location = new Point(684, 36);
            chartBudgetVsActual.Name = "chartBudgetVsActual";
            chartBudgetVsActual.SeriesTemplate.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            chartBudgetVsActual.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesBudget, seriesActualCost });
            chartBudgetVsActual.Size = new Size(660, 296);
            chartBudgetVsActual.TabIndex = 3;
            //
            // seriesBudget
            //
            seriesBudget.Name = "الموازنة";
            seriesBudget.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            //
            // seriesActualCost
            //
            seriesActualCost.Name = "الفعلي";
            seriesActualCost.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            //
            // xyDiagramBudgetVsActual
            //
            //
            // grdNotifications
            //
            grdNotifications.Dock = DockStyle.Fill;
            grdNotifications.Location = new Point(0, 510);
            grdNotifications.MainView = gvNotifications;
            grdNotifications.Name = "grdNotifications";
            grdNotifications.Size = new Size(1366, 310);
            grdNotifications.TabIndex = 3;
            grdNotifications.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvNotifications });
            //
            // gvNotifications
            //
            gvNotifications.Appearance.HeaderPanel.BackColor = Color.FromArgb(30, 70, 130);
            gvNotifications.Appearance.HeaderPanel.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            gvNotifications.Appearance.HeaderPanel.ForeColor = Color.White;
            gvNotifications.Appearance.HeaderPanel.Options.UseBackColor = true;
            gvNotifications.Appearance.HeaderPanel.Options.UseFont = true;
            gvNotifications.Appearance.HeaderPanel.Options.UseForeColor = true;
            gvNotifications.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvNotifications.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvNotifications.Appearance.Row.Font = new Font("Cairo", 8.5F);
            gvNotifications.Appearance.Row.Options.UseFont = true;
            gvNotifications.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colType, colSubject, colDate, colStatus });
            gvNotifications.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gvNotifications.GridControl = grdNotifications;
            gvNotifications.Name = "gvNotifications";
            gvNotifications.OptionsBehavior.Editable = false;
            gvNotifications.OptionsView.ShowGroupPanel = false;
            gvNotifications.OptionsView.ShowIndicator = false;
            gvNotifications.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            //
            // colType
            //
            colType.Caption = "النوع";
            colType.FieldName = "Type";
            colType.Name = "colType";
            colType.Visible = true;
            colType.VisibleIndex = 0;
            colType.Width = 130;
            //
            // colSubject
            //
            colSubject.Caption = "الموضوع";
            colSubject.FieldName = "Subject";
            colSubject.Name = "colSubject";
            colSubject.Visible = true;
            colSubject.VisibleIndex = 1;
            colSubject.Width = 600;
            //
            // colDate
            //
            colDate.Caption = "التاريخ";
            colDate.DisplayFormat.FormatString = "g";
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDate.FieldName = "Date";
            colDate.Name = "colDate";
            colDate.Visible = true;
            colDate.VisibleIndex = 2;
            colDate.Width = 160;
            //
            // colStatus
            //
            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 3;
            colStatus.Width = 130;
            //
            // pnlLoadingState
            //
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 510);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 310);
            pnlLoadingState.TabIndex = 4;
            pnlLoadingState.Visible = false;
            //
            // svgLoadingIcon
            //
            svgLoadingIcon.Location = new Point(651, 100);
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
            lblLoadingText.Location = new Point(583, 174);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(200, 20);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل لوحة المعلومات...";
            //
            // pnlEmptyState
            //
            pnlEmptyState.Controls.Add(lblEmptyText);
            pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Dock = DockStyle.Fill;
            pnlEmptyState.Location = new Point(0, 510);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 310);
            pnlEmptyState.TabIndex = 5;
            pnlEmptyState.Visible = false;
            //
            // svgEmptyIcon
            //
            svgEmptyIcon.Location = new Point(651, 100);
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
            lblEmptyText.Location = new Point(583, 174);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(200, 20);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا توجد إشعارات لعرضها";
            //
            // pnlErrorState
            //
            pnlErrorState.Controls.Add(btnRetry);
            pnlErrorState.Controls.Add(lblErrorText);
            pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Dock = DockStyle.Fill;
            pnlErrorState.Location = new Point(0, 510);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 310);
            pnlErrorState.TabIndex = 6;
            pnlErrorState.Visible = false;
            //
            // svgErrorIcon
            //
            svgErrorIcon.Location = new Point(651, 80);
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
            lblErrorText.Location = new Point(583, 154);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(200, 20);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل لوحة المعلومات";
            //
            // btnRetry
            //
            btnRetry.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            btnRetry.Location = new Point(633, 184);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(100, 28);
            btnRetry.TabIndex = 2;
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;
            //
            // ucProjectDashboard
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grdNotifications);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlCharts);
            Controls.Add(pnlKpiCards);
            Controls.Add(pnlHeader);
            Name = "ucProjectDashboard";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 820);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit();
            pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiOverallProgress).EndInit();
            pnlKpiOverallProgress.ResumeLayout(false);
            pnlKpiOverallProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiBudgetUtilization).EndInit();
            pnlKpiBudgetUtilization.ResumeLayout(false);
            pnlKpiBudgetUtilization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiOpenRisks).EndInit();
            pnlKpiOpenRisks.ResumeLayout(false);
            pnlKpiOpenRisks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiOpenIssues).EndInit();
            pnlKpiOpenIssues.ResumeLayout(false);
            pnlKpiOpenIssues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)xyDiagramSCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesSCurvePlanned).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesSCurveActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartSCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramBudgetVsActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartBudgetVsActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).EndInit();
            pnlCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdNotifications).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvNotifications).EndInit();
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

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblDashboardTitle;
        private DevExpress.XtraEditors.LabelControl lblProjectNameSubtitle;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnExportPdf;

        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.PanelControl pnlKpiOverallProgress;
        private DevExpress.XtraEditors.LabelControl lblKpiOverallProgressTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiOverallProgressValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiBudgetUtilization;
        private DevExpress.XtraEditors.LabelControl lblKpiBudgetUtilizationTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiBudgetUtilizationValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiOpenRisks;
        private DevExpress.XtraEditors.LabelControl lblKpiOpenRisksTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiOpenRisksValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiOpenIssues;
        private DevExpress.XtraEditors.LabelControl lblKpiOpenIssuesTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiOpenIssuesValue;

        private DevExpress.XtraEditors.PanelControl pnlCharts;
        private DevExpress.XtraEditors.LabelControl lblSCurveCaption;
        private DevExpress.XtraCharts.ChartControl chartSCurve;
        private DevExpress.XtraCharts.Series seriesSCurvePlanned;
        private DevExpress.XtraCharts.Series seriesSCurveActual;
        private DevExpress.XtraCharts.XYDiagram xyDiagramSCurve;
        private DevExpress.XtraEditors.LabelControl lblBudgetVsActualCaption;
        private DevExpress.XtraCharts.ChartControl chartBudgetVsActual;
        private DevExpress.XtraCharts.Series seriesBudget;
        private DevExpress.XtraCharts.Series seriesActualCost;
        private DevExpress.XtraCharts.XYDiagram xyDiagramBudgetVsActual;

        private DevExpress.XtraGrid.GridControl grdNotifications;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNotifications;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;

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
