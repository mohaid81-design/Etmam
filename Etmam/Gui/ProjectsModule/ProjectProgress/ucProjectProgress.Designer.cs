namespace Etmam
{
    partial class ucProjectProgress
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
            barManagerProgress = new DevExpress.XtraBars.BarManager(components);
            barProgress = new DevExpress.XtraBars.Bar();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();

            pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            pnlKpiOverall = new DevExpress.XtraEditors.PanelControl();
            lblKpiOverallTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiOverallValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiPhysical = new DevExpress.XtraEditors.PanelControl();
            lblKpiPhysicalTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiPhysicalValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiFinancial = new DevExpress.XtraEditors.PanelControl();
            lblKpiFinancialTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiFinancialValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiSchedule = new DevExpress.XtraEditors.PanelControl();
            lblKpiScheduleTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiScheduleValue = new DevExpress.XtraEditors.LabelControl();

            pnlCharts = new DevExpress.XtraEditors.PanelControl();
            lblSCurveCaption = new DevExpress.XtraEditors.LabelControl();
            chartSCurve = new DevExpress.XtraCharts.ChartControl();
            seriesSCurvePlanned = new DevExpress.XtraCharts.Series("المخطط", DevExpress.XtraCharts.ViewType.Spline);
            seriesSCurveActual = new DevExpress.XtraCharts.Series("الفعلي", DevExpress.XtraCharts.ViewType.Spline);
            xyDiagramSCurve = new DevExpress.XtraCharts.XYDiagram();
            lblWeeklyProgressCaption = new DevExpress.XtraEditors.LabelControl();
            chartWeeklyProgress = new DevExpress.XtraCharts.ChartControl();
            seriesWeeklyProgress = new DevExpress.XtraCharts.Series("الإنجاز الأسبوعي", DevExpress.XtraCharts.ViewType.Bar);
            xyDiagramWeeklyProgress = new DevExpress.XtraCharts.XYDiagram();
            lblMonthlyProgressCaption = new DevExpress.XtraEditors.LabelControl();
            chartMonthlyProgress = new DevExpress.XtraCharts.ChartControl();
            seriesMonthlyProgress = new DevExpress.XtraCharts.Series("الإنجاز الشهري", DevExpress.XtraCharts.ViewType.Bar);
            xyDiagramMonthlyProgress = new DevExpress.XtraCharts.XYDiagram();

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

            ((System.ComponentModel.ISupportInitialize)barManagerProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit();
            pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiOverall).BeginInit();
            pnlKpiOverall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiPhysical).BeginInit();
            pnlKpiPhysical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiFinancial).BeginInit();
            pnlKpiFinancial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiSchedule).BeginInit();
            pnlKpiSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).BeginInit();
            pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartSCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesSCurvePlanned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesSCurveActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramSCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartWeeklyProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesWeeklyProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramWeeklyProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartMonthlyProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesMonthlyProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramMonthlyProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            SuspendLayout();
            //
            // barManagerProgress
            //
            barManagerProgress.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barProgress });
            barManagerProgress.DockControls.Add(barDockControlTop);
            barManagerProgress.DockControls.Add(barDockControlBottom);
            barManagerProgress.DockControls.Add(barDockControlLeft);
            barManagerProgress.DockControls.Add(barDockControlRight);
            barManagerProgress.Form = this;
            barManagerProgress.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiRefresh, bbiPrint, bbiExportPdf });
            barManagerProgress.MainMenu = barProgress;
            barManagerProgress.MaxItemId = 3;
            barManagerProgress.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            //
            // barProgress
            //
            barProgress.BarName = "شريط أدوات التقدم";
            barProgress.DockCol = 0;
            barProgress.DockRow = 0;
            barProgress.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barProgress.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportPdf, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barProgress.OptionsBar.AllowQuickCustomization = false;
            barProgress.OptionsBar.DrawDragBorder = false;
            barProgress.OptionsBar.MinHeight = 34;
            barProgress.OptionsBar.UseWholeRow = true;
            barProgress.Text = "شريط أدوات التقدم";
            //
            // bbiRefresh
            //
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 0;
            bbiRefresh.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            bbiRefresh.Name = "bbiRefresh";
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            //
            // bbiPrint
            //
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 1;
            bbiPrint.ImageOptions.SvgImage = Etmam.IconLoader.Get("print.svg");
            bbiPrint.Name = "bbiPrint";
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            //
            // bbiExportPdf
            //
            bbiExportPdf.Caption = "تصدير PDF";
            bbiExportPdf.Id = 2;
            bbiExportPdf.ImageOptions.SvgImage = Etmam.IconLoader.Get("export_pdf.svg");
            bbiExportPdf.Name = "bbiExportPdf";
            bbiExportPdf.ItemClick += bbiExportPdf_ItemClick;
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerProgress;
            barDockControlTop.Size = new Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 796);
            barDockControlBottom.Manager = barManagerProgress;
            barDockControlBottom.Size = new Size(1366, 24);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerProgress;
            barDockControlLeft.Size = new Size(0, 762);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerProgress;
            barDockControlRight.Size = new Size(0, 762);
            //
            // pnlKpiCards
            //
            pnlKpiCards.Controls.Add(pnlKpiSchedule);
            pnlKpiCards.Controls.Add(pnlKpiFinancial);
            pnlKpiCards.Controls.Add(pnlKpiPhysical);
            pnlKpiCards.Controls.Add(pnlKpiOverall);
            pnlKpiCards.Dock = DockStyle.Top;
            pnlKpiCards.Location = new Point(0, 34);
            pnlKpiCards.Name = "pnlKpiCards";
            pnlKpiCards.Size = new Size(1366, 106);
            pnlKpiCards.TabIndex = 0;
            //
            // pnlKpiOverall
            //
            pnlKpiOverall.Appearance.BackColor = Color.FromArgb(234, 243, 252);
            pnlKpiOverall.Appearance.Options.UseBackColor = true;
            pnlKpiOverall.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiOverall.Controls.Add(lblKpiOverallValue);
            pnlKpiOverall.Controls.Add(lblKpiOverallTitle);
            pnlKpiOverall.Location = new Point(20, 10);
            pnlKpiOverall.Name = "pnlKpiOverall";
            pnlKpiOverall.Size = new Size(310, 86);
            pnlKpiOverall.TabIndex = 0;
            //
            // lblKpiOverallTitle
            //
            lblKpiOverallTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiOverallTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiOverallTitle.Appearance.Options.UseFont = true;
            lblKpiOverallTitle.Appearance.Options.UseForeColor = true;
            lblKpiOverallTitle.Location = new Point(12, 10);
            lblKpiOverallTitle.Name = "lblKpiOverallTitle";
            lblKpiOverallTitle.Size = new Size(78, 17);
            lblKpiOverallTitle.TabIndex = 0;
            lblKpiOverallTitle.Text = "نسبة الإنجاز الكلي";
            //
            // lblKpiOverallValue
            //
            lblKpiOverallValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiOverallValue.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblKpiOverallValue.Appearance.Options.UseFont = true;
            lblKpiOverallValue.Appearance.Options.UseForeColor = true;
            lblKpiOverallValue.Location = new Point(12, 34);
            lblKpiOverallValue.Name = "lblKpiOverallValue";
            lblKpiOverallValue.Size = new Size(20, 25);
            lblKpiOverallValue.TabIndex = 1;
            lblKpiOverallValue.Text = "—";
            //
            // pnlKpiPhysical
            //
            pnlKpiPhysical.Appearance.BackColor = Color.FromArgb(234, 247, 239);
            pnlKpiPhysical.Appearance.Options.UseBackColor = true;
            pnlKpiPhysical.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiPhysical.Controls.Add(lblKpiPhysicalValue);
            pnlKpiPhysical.Controls.Add(lblKpiPhysicalTitle);
            pnlKpiPhysical.Location = new Point(350, 10);
            pnlKpiPhysical.Name = "pnlKpiPhysical";
            pnlKpiPhysical.Size = new Size(310, 86);
            pnlKpiPhysical.TabIndex = 1;
            //
            // lblKpiPhysicalTitle
            //
            lblKpiPhysicalTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiPhysicalTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiPhysicalTitle.Appearance.Options.UseFont = true;
            lblKpiPhysicalTitle.Appearance.Options.UseForeColor = true;
            lblKpiPhysicalTitle.Location = new Point(12, 10);
            lblKpiPhysicalTitle.Name = "lblKpiPhysicalTitle";
            lblKpiPhysicalTitle.Size = new Size(66, 17);
            lblKpiPhysicalTitle.TabIndex = 0;
            lblKpiPhysicalTitle.Text = "الإنجاز الفعلي (العيني)";
            //
            // lblKpiPhysicalValue
            //
            lblKpiPhysicalValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiPhysicalValue.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblKpiPhysicalValue.Appearance.Options.UseFont = true;
            lblKpiPhysicalValue.Appearance.Options.UseForeColor = true;
            lblKpiPhysicalValue.Location = new Point(12, 34);
            lblKpiPhysicalValue.Name = "lblKpiPhysicalValue";
            lblKpiPhysicalValue.Size = new Size(20, 25);
            lblKpiPhysicalValue.TabIndex = 1;
            lblKpiPhysicalValue.Text = "—";
            //
            // pnlKpiFinancial
            //
            pnlKpiFinancial.Appearance.BackColor = Color.FromArgb(243, 236, 251);
            pnlKpiFinancial.Appearance.Options.UseBackColor = true;
            pnlKpiFinancial.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiFinancial.Controls.Add(lblKpiFinancialValue);
            pnlKpiFinancial.Controls.Add(lblKpiFinancialTitle);
            pnlKpiFinancial.Location = new Point(680, 10);
            pnlKpiFinancial.Name = "pnlKpiFinancial";
            pnlKpiFinancial.Size = new Size(310, 86);
            pnlKpiFinancial.TabIndex = 2;
            //
            // lblKpiFinancialTitle
            //
            lblKpiFinancialTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiFinancialTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiFinancialTitle.Appearance.Options.UseFont = true;
            lblKpiFinancialTitle.Appearance.Options.UseForeColor = true;
            lblKpiFinancialTitle.Location = new Point(12, 10);
            lblKpiFinancialTitle.Name = "lblKpiFinancialTitle";
            lblKpiFinancialTitle.Size = new Size(70, 17);
            lblKpiFinancialTitle.TabIndex = 0;
            lblKpiFinancialTitle.Text = "الإنجاز المالي";
            //
            // lblKpiFinancialValue
            //
            lblKpiFinancialValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiFinancialValue.Appearance.ForeColor = Color.FromArgb(123, 79, 166);
            lblKpiFinancialValue.Appearance.Options.UseFont = true;
            lblKpiFinancialValue.Appearance.Options.UseForeColor = true;
            lblKpiFinancialValue.Location = new Point(12, 34);
            lblKpiFinancialValue.Name = "lblKpiFinancialValue";
            lblKpiFinancialValue.Size = new Size(20, 25);
            lblKpiFinancialValue.TabIndex = 1;
            lblKpiFinancialValue.Text = "—";
            //
            // pnlKpiSchedule
            //
            pnlKpiSchedule.Appearance.BackColor = Color.FromArgb(232, 246, 246);
            pnlKpiSchedule.Appearance.Options.UseBackColor = true;
            pnlKpiSchedule.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiSchedule.Controls.Add(lblKpiScheduleValue);
            pnlKpiSchedule.Controls.Add(lblKpiScheduleTitle);
            pnlKpiSchedule.Location = new Point(1010, 10);
            pnlKpiSchedule.Name = "pnlKpiSchedule";
            pnlKpiSchedule.Size = new Size(310, 86);
            pnlKpiSchedule.TabIndex = 3;
            //
            // lblKpiScheduleTitle
            //
            lblKpiScheduleTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiScheduleTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiScheduleTitle.Appearance.Options.UseFont = true;
            lblKpiScheduleTitle.Appearance.Options.UseForeColor = true;
            lblKpiScheduleTitle.Location = new Point(12, 10);
            lblKpiScheduleTitle.Name = "lblKpiScheduleTitle";
            lblKpiScheduleTitle.Size = new Size(69, 17);
            lblKpiScheduleTitle.TabIndex = 0;
            lblKpiScheduleTitle.Text = "الإنجاز الزمني";
            //
            // lblKpiScheduleValue
            //
            lblKpiScheduleValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiScheduleValue.Appearance.ForeColor = Color.FromArgb(28, 140, 140);
            lblKpiScheduleValue.Appearance.Options.UseFont = true;
            lblKpiScheduleValue.Appearance.Options.UseForeColor = true;
            lblKpiScheduleValue.Location = new Point(12, 34);
            lblKpiScheduleValue.Name = "lblKpiScheduleValue";
            lblKpiScheduleValue.Size = new Size(20, 25);
            lblKpiScheduleValue.TabIndex = 1;
            lblKpiScheduleValue.Text = "—";
            //
            // pnlCharts
            //
            pnlCharts.Controls.Add(chartMonthlyProgress);
            pnlCharts.Controls.Add(lblMonthlyProgressCaption);
            pnlCharts.Controls.Add(chartWeeklyProgress);
            pnlCharts.Controls.Add(lblWeeklyProgressCaption);
            pnlCharts.Controls.Add(chartSCurve);
            pnlCharts.Controls.Add(lblSCurveCaption);
            pnlCharts.Dock = DockStyle.Fill;
            pnlCharts.Location = new Point(0, 140);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Size = new Size(1366, 656);
            pnlCharts.TabIndex = 1;
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
            chartSCurve.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            chartSCurve.Diagram = xyDiagramSCurve;
            chartSCurve.Location = new Point(12, 36);
            chartSCurve.Name = "chartSCurve";
            chartSCurve.SeriesTemplate.View = new DevExpress.XtraCharts.SplineSeriesView();
            chartSCurve.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesSCurvePlanned, seriesSCurveActual });
            chartSCurve.Size = new Size(436, 600);
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
            // lblWeeklyProgressCaption
            //
            lblWeeklyProgressCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblWeeklyProgressCaption.Appearance.Options.UseFont = true;
            lblWeeklyProgressCaption.Location = new Point(460, 12);
            lblWeeklyProgressCaption.Name = "lblWeeklyProgressCaption";
            lblWeeklyProgressCaption.Size = new Size(90, 20);
            lblWeeklyProgressCaption.TabIndex = 2;
            lblWeeklyProgressCaption.Text = "الإنجاز الأسبوعي";
            //
            // chartWeeklyProgress
            //
            chartWeeklyProgress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            chartWeeklyProgress.Diagram = xyDiagramWeeklyProgress;
            chartWeeklyProgress.Location = new Point(460, 36);
            chartWeeklyProgress.Name = "chartWeeklyProgress";
            chartWeeklyProgress.SeriesTemplate.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            chartWeeklyProgress.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesWeeklyProgress });
            chartWeeklyProgress.Size = new Size(436, 600);
            chartWeeklyProgress.TabIndex = 3;
            //
            // seriesWeeklyProgress
            //
            seriesWeeklyProgress.Name = "الإنجاز الأسبوعي";
            seriesWeeklyProgress.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            //
            // xyDiagramWeeklyProgress
            //
            //
            // lblMonthlyProgressCaption
            //
            lblMonthlyProgressCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblMonthlyProgressCaption.Appearance.Options.UseFont = true;
            lblMonthlyProgressCaption.Location = new Point(908, 12);
            lblMonthlyProgressCaption.Name = "lblMonthlyProgressCaption";
            lblMonthlyProgressCaption.Size = new Size(85, 20);
            lblMonthlyProgressCaption.TabIndex = 4;
            lblMonthlyProgressCaption.Text = "الإنجاز الشهري";
            //
            // chartMonthlyProgress
            //
            chartMonthlyProgress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            chartMonthlyProgress.Diagram = xyDiagramMonthlyProgress;
            chartMonthlyProgress.Location = new Point(908, 36);
            chartMonthlyProgress.Name = "chartMonthlyProgress";
            chartMonthlyProgress.SeriesTemplate.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            chartMonthlyProgress.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesMonthlyProgress });
            chartMonthlyProgress.Size = new Size(436, 600);
            chartMonthlyProgress.TabIndex = 5;
            //
            // seriesMonthlyProgress
            //
            seriesMonthlyProgress.Name = "الإنجاز الشهري";
            seriesMonthlyProgress.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            //
            // xyDiagramMonthlyProgress
            //
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
            svgLoadingIcon.Location = new Point(651, 296);
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
            lblLoadingText.Location = new Point(583, 370);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(200, 20);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل بيانات الإنجاز...";
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
            svgEmptyIcon.Location = new Point(651, 296);
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
            lblEmptyText.Location = new Point(583, 370);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(200, 20);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا توجد بيانات إنجاز لعرضها";
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
            svgErrorIcon.Location = new Point(651, 276);
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
            lblErrorText.Location = new Point(583, 350);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(200, 20);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل بيانات الإنجاز";
            //
            // btnRetry
            //
            btnRetry.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            btnRetry.Location = new Point(633, 380);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(100, 28);
            btnRetry.TabIndex = 2;
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;
            //
            // ucProjectProgress
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlCharts);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlKpiCards);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucProjectProgress";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 820);
            ((System.ComponentModel.ISupportInitialize)barManagerProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit();
            pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiOverall).EndInit();
            pnlKpiOverall.ResumeLayout(false);
            pnlKpiOverall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiPhysical).EndInit();
            pnlKpiPhysical.ResumeLayout(false);
            pnlKpiPhysical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiFinancial).EndInit();
            pnlKpiFinancial.ResumeLayout(false);
            pnlKpiFinancial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiSchedule).EndInit();
            pnlKpiSchedule.ResumeLayout(false);
            pnlKpiSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)xyDiagramSCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesSCurvePlanned).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesSCurveActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartSCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramWeeklyProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesWeeklyProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartWeeklyProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramMonthlyProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesMonthlyProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartMonthlyProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).EndInit();
            pnlCharts.ResumeLayout(false);
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

        private DevExpress.XtraBars.BarManager barManagerProgress;
        private DevExpress.XtraBars.Bar barProgress;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExportPdf;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.PanelControl pnlKpiOverall;
        private DevExpress.XtraEditors.LabelControl lblKpiOverallTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiOverallValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiPhysical;
        private DevExpress.XtraEditors.LabelControl lblKpiPhysicalTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiPhysicalValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiFinancial;
        private DevExpress.XtraEditors.LabelControl lblKpiFinancialTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiFinancialValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiSchedule;
        private DevExpress.XtraEditors.LabelControl lblKpiScheduleTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiScheduleValue;

        private DevExpress.XtraEditors.PanelControl pnlCharts;
        private DevExpress.XtraEditors.LabelControl lblSCurveCaption;
        private DevExpress.XtraCharts.ChartControl chartSCurve;
        private DevExpress.XtraCharts.Series seriesSCurvePlanned;
        private DevExpress.XtraCharts.Series seriesSCurveActual;
        private DevExpress.XtraCharts.XYDiagram xyDiagramSCurve;
        private DevExpress.XtraEditors.LabelControl lblWeeklyProgressCaption;
        private DevExpress.XtraCharts.ChartControl chartWeeklyProgress;
        private DevExpress.XtraCharts.Series seriesWeeklyProgress;
        private DevExpress.XtraCharts.XYDiagram xyDiagramWeeklyProgress;
        private DevExpress.XtraEditors.LabelControl lblMonthlyProgressCaption;
        private DevExpress.XtraCharts.ChartControl chartMonthlyProgress;
        private DevExpress.XtraCharts.Series seriesMonthlyProgress;
        private DevExpress.XtraCharts.XYDiagram xyDiagramMonthlyProgress;

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
