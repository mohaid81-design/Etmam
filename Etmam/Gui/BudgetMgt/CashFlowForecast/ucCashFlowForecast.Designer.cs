namespace Etmam
{
    partial class ucCashFlowForecast
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCashFlowForecast));
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            pnlKpiPlanned = new DevExpress.XtraEditors.PanelControl();
            lblKpiPlannedValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiPlannedTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiActual = new DevExpress.XtraEditors.PanelControl();
            lblKpiActualValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiActualTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiForecast = new DevExpress.XtraEditors.PanelControl();
            lblKpiForecastValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiForecastTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiRemaining = new DevExpress.XtraEditors.PanelControl();
            lblKpiRemainingValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiRemainingTitle = new DevExpress.XtraEditors.LabelControl();
            pnlCharts = new DevExpress.XtraEditors.PanelControl();
            tblCharts = new System.Windows.Forms.TableLayoutPanel();
            grpSCurve = new DevExpress.XtraEditors.GroupControl();
            chartSCurve = new DevExpress.XtraCharts.ChartControl();
            seriesPlannedCurve = new DevExpress.XtraCharts.Series("التدفق المخطط التراكمي", DevExpress.XtraCharts.ViewType.Area);
            seriesActualCurve = new DevExpress.XtraCharts.Series("التدفق الفعلي التراكمي", DevExpress.XtraCharts.ViewType.Area);
            grpMonthlyCF = new DevExpress.XtraEditors.GroupControl();
            chartMonthlyCF = new DevExpress.XtraCharts.ChartControl();
            seriesMonthlyCFPlanned = new DevExpress.XtraCharts.Series("التدفق الشهري المخطط", DevExpress.XtraCharts.ViewType.Bar);
            seriesMonthlyCFActual = new DevExpress.XtraCharts.Series("التدفق الشهري الفعلي", DevExpress.XtraCharts.ViewType.Bar);
            grpPlannedVsActual = new DevExpress.XtraEditors.GroupControl();
            chartPlannedVsActual = new DevExpress.XtraCharts.ChartControl();
            seriesPlanned = new DevExpress.XtraCharts.Series("مخطط", DevExpress.XtraCharts.ViewType.Line);
            seriesActualLine = new DevExpress.XtraCharts.Series("فعلي", DevExpress.XtraCharts.ViewType.Line);
            grpForecastChart = new DevExpress.XtraEditors.GroupControl();
            chartForecast = new DevExpress.XtraCharts.ChartControl();
            seriesForecastSpline = new DevExpress.XtraCharts.Series("التوقع", DevExpress.XtraCharts.ViewType.Spline);
            grdCashFlow = new DevExpress.XtraGrid.GridControl();
            gvCashFlow = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCFMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            colCFIncome = new DevExpress.XtraGrid.Columns.GridColumn();
            colCFExpense = new DevExpress.XtraGrid.Columns.GridColumn();
            colCFNet = new DevExpress.XtraGrid.Columns.GridColumn();
            colCFForecast = new DevExpress.XtraGrid.Columns.GridColumn();
            colCFVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            colCFCumulative = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            lblLoadingText = new DevExpress.XtraEditors.LabelControl();
            svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            lblEmptyText = new DevExpress.XtraEditors.LabelControl();
            svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();
            lblErrorText = new DevExpress.XtraEditors.LabelControl();
            svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)barManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit(); pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiPlanned).BeginInit(); pnlKpiPlanned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActual).BeginInit(); pnlKpiActual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).BeginInit(); pnlKpiForecast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiRemaining).BeginInit(); pnlKpiRemaining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).BeginInit(); pnlCharts.SuspendLayout();
            tblCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpSCurve).BeginInit(); grpSCurve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpMonthlyCF).BeginInit(); grpMonthlyCF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpPlannedVsActual).BeginInit(); grpPlannedVsActual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpForecastChart).BeginInit(); grpForecastChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartSCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartMonthlyCF).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartPlannedVsActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesPlannedCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesMonthlyCFPlanned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesMonthlyCFActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesPlanned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesForecastSpline).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdCashFlow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCashFlow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit(); pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit(); pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit(); pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();

            // barManagerMain
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain });
            
            barManagerMain.Form = this; barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiRefresh, bbiExportExcel, bbiPrint });
            barManagerMain.MainMenu = barMain; barManagerMain.MaxItemId = 3; barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barMain.BarName = "شريط أدوات التدفق النقدي"; barMain.DockCol = 0; barMain.DockRow = 0; barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
            });
            barMain.OptionsBar.AllowQuickCustomization = false; barMain.OptionsBar.DrawDragBorder = false; barMain.OptionsBar.MinHeight = 34; barMain.OptionsBar.UseWholeRow = true; barMain.Text = "شريط أدوات التدفق النقدي";
            bbiRefresh.Caption = "تحديث"; bbiRefresh.Id = 0; bbiRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiRefresh.ImageOptions.SvgImage"); bbiRefresh.Name = "bbiRefresh"; bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            bbiExportExcel.Caption = "تصدير Excel"; bbiExportExcel.Id = 1; bbiExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExportExcel.ImageOptions.SvgImage"); bbiExportExcel.Name = "bbiExportExcel"; bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            bbiPrint.Caption = "طباعة"; bbiPrint.Id = 2; bbiPrint.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiPrint.ImageOptions.SvgImage"); bbiPrint.Name = "bbiPrint"; bbiPrint.ItemClick += bbiPrint_ItemClick;
            barDockControlTop.CausesValidation = false; barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top; barDockControlTop.Location = new System.Drawing.Point(0, 0); barDockControlTop.Manager = barManagerMain; barDockControlTop.Size = new System.Drawing.Size(1366, 34);
            barDockControlBottom.CausesValidation = false; barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom; barDockControlBottom.Location = new System.Drawing.Point(0, 902); barDockControlBottom.Manager = barManagerMain; barDockControlBottom.Size = new System.Drawing.Size(1366, 0);
            barDockControlLeft.CausesValidation = false; barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left; barDockControlLeft.Location = new System.Drawing.Point(0, 34); barDockControlLeft.Manager = barManagerMain; barDockControlLeft.Size = new System.Drawing.Size(0, 868);
            barDockControlRight.CausesValidation = false; barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right; barDockControlRight.Location = new System.Drawing.Point(1366, 34); barDockControlRight.Manager = barManagerMain; barDockControlRight.Size = new System.Drawing.Size(0, 868);

            // KPI cards
            pnlKpiCards.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCards.Controls.AddRange(new System.Windows.Forms.Control[] { pnlKpiPlanned, pnlKpiActual, pnlKpiForecast, pnlKpiRemaining });
            pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top; pnlKpiCards.Location = new System.Drawing.Point(0, 34); pnlKpiCards.Name = "pnlKpiCards"; pnlKpiCards.Size = new System.Drawing.Size(1366, 100);
            pnlKpiPlanned.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiPlanned.Controls.Add(lblKpiPlannedTitle); pnlKpiPlanned.Controls.Add(lblKpiPlannedValue);
            pnlKpiPlanned.Location = new System.Drawing.Point(1028, 8); pnlKpiPlanned.Name = "pnlKpiPlanned"; pnlKpiPlanned.Size = new System.Drawing.Size(328, 84);
            lblKpiPlannedTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblKpiPlannedTitle.Appearance.Options.UseFont = true;
            lblKpiPlannedTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblKpiPlannedTitle.Appearance.Options.UseForeColor = true;
            lblKpiPlannedTitle.Location = new System.Drawing.Point(10, 12); lblKpiPlannedTitle.Name = "lblKpiPlannedTitle"; lblKpiPlannedTitle.Text = "التدفق المخطط";
            lblKpiPlannedValue.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblKpiPlannedValue.Appearance.Options.UseFont = true;
            lblKpiPlannedValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 117, 182); lblKpiPlannedValue.Appearance.Options.UseForeColor = true;
            lblKpiPlannedValue.Location = new System.Drawing.Point(10, 38); lblKpiPlannedValue.Name = "lblKpiPlannedValue"; lblKpiPlannedValue.Text = "—";

            pnlKpiActual.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiActual.Controls.Add(lblKpiActualTitle); pnlKpiActual.Controls.Add(lblKpiActualValue);
            pnlKpiActual.Location = new System.Drawing.Point(688, 8); pnlKpiActual.Name = "pnlKpiActual"; pnlKpiActual.Size = new System.Drawing.Size(328, 84);
            lblKpiActualTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblKpiActualTitle.Appearance.Options.UseFont = true;
            lblKpiActualTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblKpiActualTitle.Appearance.Options.UseForeColor = true;
            lblKpiActualTitle.Location = new System.Drawing.Point(10, 12); lblKpiActualTitle.Name = "lblKpiActualTitle"; lblKpiActualTitle.Text = "التدفق الفعلي";
            lblKpiActualValue.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblKpiActualValue.Appearance.Options.UseFont = true;
            lblKpiActualValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(192, 80, 77); lblKpiActualValue.Appearance.Options.UseForeColor = true;
            lblKpiActualValue.Location = new System.Drawing.Point(10, 38); lblKpiActualValue.Name = "lblKpiActualValue"; lblKpiActualValue.Text = "—";

            pnlKpiForecast.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiForecast.Controls.Add(lblKpiForecastTitle); pnlKpiForecast.Controls.Add(lblKpiForecastValue);
            pnlKpiForecast.Location = new System.Drawing.Point(348, 8); pnlKpiForecast.Name = "pnlKpiForecast"; pnlKpiForecast.Size = new System.Drawing.Size(328, 84);
            lblKpiForecastTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblKpiForecastTitle.Appearance.Options.UseFont = true;
            lblKpiForecastTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblKpiForecastTitle.Appearance.Options.UseForeColor = true;
            lblKpiForecastTitle.Location = new System.Drawing.Point(10, 12); lblKpiForecastTitle.Name = "lblKpiForecastTitle"; lblKpiForecastTitle.Text = "التوقع";
            lblKpiForecastValue.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblKpiForecastValue.Appearance.Options.UseFont = true;
            lblKpiForecastValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(148, 103, 189); lblKpiForecastValue.Appearance.Options.UseForeColor = true;
            lblKpiForecastValue.Location = new System.Drawing.Point(10, 38); lblKpiForecastValue.Name = "lblKpiForecastValue"; lblKpiForecastValue.Text = "—";

            pnlKpiRemaining.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiRemaining.Controls.Add(lblKpiRemainingTitle); pnlKpiRemaining.Controls.Add(lblKpiRemainingValue);
            pnlKpiRemaining.Location = new System.Drawing.Point(8, 8); pnlKpiRemaining.Name = "pnlKpiRemaining"; pnlKpiRemaining.Size = new System.Drawing.Size(328, 84);
            lblKpiRemainingTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblKpiRemainingTitle.Appearance.Options.UseFont = true;
            lblKpiRemainingTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblKpiRemainingTitle.Appearance.Options.UseForeColor = true;
            lblKpiRemainingTitle.Location = new System.Drawing.Point(10, 12); lblKpiRemainingTitle.Name = "lblKpiRemainingTitle"; lblKpiRemainingTitle.Text = "المتبقي";
            lblKpiRemainingValue.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblKpiRemainingValue.Appearance.Options.UseFont = true;
            lblKpiRemainingValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 158, 91); lblKpiRemainingValue.Appearance.Options.UseForeColor = true;
            lblKpiRemainingValue.Location = new System.Drawing.Point(10, 38); lblKpiRemainingValue.Name = "lblKpiRemainingValue"; lblKpiRemainingValue.Text = "—";

            // Charts
            pnlCharts.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCharts.Controls.Add(tblCharts); pnlCharts.Dock = System.Windows.Forms.DockStyle.Top; pnlCharts.Location = new System.Drawing.Point(0, 134); pnlCharts.Name = "pnlCharts"; pnlCharts.Size = new System.Drawing.Size(1366, 360);
            tblCharts.ColumnCount = 2; tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F)); tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tblCharts.Controls.Add(grpSCurve, 0, 0); tblCharts.Controls.Add(grpMonthlyCF, 1, 0); tblCharts.Controls.Add(grpPlannedVsActual, 0, 1); tblCharts.Controls.Add(grpForecastChart, 1, 1);
            tblCharts.Dock = System.Windows.Forms.DockStyle.Fill; tblCharts.Name = "tblCharts"; tblCharts.RowCount = 2;
            tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F)); tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

            grpSCurve.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpSCurve.AppearanceCaption.Options.UseFont = true;
            grpSCurve.Controls.Add(chartSCurve); grpSCurve.Dock = System.Windows.Forms.DockStyle.Fill; grpSCurve.Margin = new System.Windows.Forms.Padding(3); grpSCurve.Name = "grpSCurve"; grpSCurve.Text = "منحنى S للتدفق النقدي";
            chartSCurve.Dock = System.Windows.Forms.DockStyle.Fill; chartSCurve.Name = "chartSCurve"; chartSCurve.SeriesSerializable = new DevExpress.XtraCharts.Series[] { seriesPlannedCurve, seriesActualCurve };

            grpMonthlyCF.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpMonthlyCF.AppearanceCaption.Options.UseFont = true;
            grpMonthlyCF.Controls.Add(chartMonthlyCF); grpMonthlyCF.Dock = System.Windows.Forms.DockStyle.Fill; grpMonthlyCF.Margin = new System.Windows.Forms.Padding(3); grpMonthlyCF.Name = "grpMonthlyCF"; grpMonthlyCF.Text = "التدفق النقدي الشهري";
            chartMonthlyCF.Dock = System.Windows.Forms.DockStyle.Fill; chartMonthlyCF.Name = "chartMonthlyCF"; chartMonthlyCF.SeriesSerializable = new DevExpress.XtraCharts.Series[] { seriesMonthlyCFPlanned, seriesMonthlyCFActual };

            grpPlannedVsActual.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpPlannedVsActual.AppearanceCaption.Options.UseFont = true;
            grpPlannedVsActual.Controls.Add(chartPlannedVsActual); grpPlannedVsActual.Dock = System.Windows.Forms.DockStyle.Fill; grpPlannedVsActual.Margin = new System.Windows.Forms.Padding(3); grpPlannedVsActual.Name = "grpPlannedVsActual"; grpPlannedVsActual.Text = "المخطط مقابل الفعلي";
            chartPlannedVsActual.Dock = System.Windows.Forms.DockStyle.Fill; chartPlannedVsActual.Name = "chartPlannedVsActual"; chartPlannedVsActual.SeriesSerializable = new DevExpress.XtraCharts.Series[] { seriesPlanned, seriesActualLine };

            grpForecastChart.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpForecastChart.AppearanceCaption.Options.UseFont = true;
            grpForecastChart.Controls.Add(chartForecast); grpForecastChart.Dock = System.Windows.Forms.DockStyle.Fill; grpForecastChart.Margin = new System.Windows.Forms.Padding(3); grpForecastChart.Name = "grpForecastChart"; grpForecastChart.Text = "توقعات التدفق";
            chartForecast.Dock = System.Windows.Forms.DockStyle.Fill; chartForecast.Name = "chartForecast"; chartForecast.SeriesSerializable = new DevExpress.XtraCharts.Series[] { seriesForecastSpline };

            // Grid
            grdCashFlow.Dock = System.Windows.Forms.DockStyle.Fill; grdCashFlow.MainView = gvCashFlow; grdCashFlow.Name = "grdCashFlow"; grdCashFlow.MenuManager = barManagerMain;
            grdCashFlow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCashFlow });
            gvCashFlow.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F); gvCashFlow.Appearance.Row.Options.UseFont = true;
            gvCashFlow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCFMonth, colCFIncome, colCFExpense, colCFNet, colCFForecast, colCFVariance, colCFCumulative });
            gvCashFlow.GridControl = grdCashFlow; gvCashFlow.Name = "gvCashFlow"; gvCashFlow.OptionsBehavior.Editable = false;
            gvCashFlow.OptionsView.ShowAutoFilterRow = true; gvCashFlow.OptionsView.ShowFooter = true;
            colCFMonth.Caption = "الشهر"; colCFMonth.FieldName = "Month"; colCFMonth.Name = "colCFMonth"; colCFMonth.Visible = true; colCFMonth.Width = 130;
            colCFIncome.Caption = "الإيرادات"; colCFIncome.FieldName = "Income"; colCFIncome.Name = "colCFIncome"; colCFIncome.Visible = true; colCFIncome.Width = 150; colCFIncome.DisplayFormat.FormatString = "N2"; colCFIncome.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFExpense.Caption = "المصروفات"; colCFExpense.FieldName = "Expense"; colCFExpense.Name = "colCFExpense"; colCFExpense.Visible = true; colCFExpense.Width = 150; colCFExpense.DisplayFormat.FormatString = "N2"; colCFExpense.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFNet.Caption = "الصافي"; colCFNet.FieldName = "Net"; colCFNet.Name = "colCFNet"; colCFNet.Visible = true; colCFNet.Width = 140; colCFNet.DisplayFormat.FormatString = "N2"; colCFNet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFForecast.Caption = "التوقع"; colCFForecast.FieldName = "Forecast"; colCFForecast.Name = "colCFForecast"; colCFForecast.Visible = true; colCFForecast.Width = 140; colCFForecast.DisplayFormat.FormatString = "N2"; colCFForecast.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFVariance.Caption = "الانحراف"; colCFVariance.FieldName = "Variance"; colCFVariance.Name = "colCFVariance"; colCFVariance.Visible = true; colCFVariance.Width = 140; colCFVariance.DisplayFormat.FormatString = "N2"; colCFVariance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFCumulative.Caption = "التراكمي"; colCFCumulative.FieldName = "Cumulative"; colCFCumulative.Name = "colCFCumulative"; colCFCumulative.Visible = true; colCFCumulative.Width = 140; colCFCumulative.DisplayFormat.FormatString = "N2"; colCFCumulative.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            // States
            pnlLoadingState.Controls.Add(lblLoadingText); pnlLoadingState.Controls.Add(svgLoadingIcon); pnlLoadingState.Dock = System.Windows.Forms.DockStyle.Fill; pnlLoadingState.Name = "pnlLoadingState"; pnlLoadingState.Visible = false;
            lblLoadingText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblLoadingText.Appearance.Options.UseFont = true; lblLoadingText.Location = new System.Drawing.Point(543, 310); lblLoadingText.Name = "lblLoadingText"; lblLoadingText.Text = "جاري تحميل بيانات التدفق النقدي...";
            svgLoadingIcon.Location = new System.Drawing.Point(651, 210); svgLoadingIcon.Name = "svgLoadingIcon"; svgLoadingIcon.Size = new System.Drawing.Size(64, 64); svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            pnlEmptyState.Controls.Add(lblEmptyText); pnlEmptyState.Controls.Add(svgEmptyIcon); pnlEmptyState.Dock = System.Windows.Forms.DockStyle.Fill; pnlEmptyState.Name = "pnlEmptyState"; pnlEmptyState.Visible = false;
            lblEmptyText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblEmptyText.Appearance.Options.UseFont = true; lblEmptyText.Location = new System.Drawing.Point(543, 310); lblEmptyText.Name = "lblEmptyText"; lblEmptyText.Text = "لا توجد بيانات تدفق نقدي";
            svgEmptyIcon.Location = new System.Drawing.Point(651, 210); svgEmptyIcon.Name = "svgEmptyIcon"; svgEmptyIcon.Size = new System.Drawing.Size(64, 64); svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            pnlErrorState.Controls.Add(btnRetry); pnlErrorState.Controls.Add(lblErrorText); pnlErrorState.Controls.Add(svgErrorIcon); pnlErrorState.Dock = System.Windows.Forms.DockStyle.Fill; pnlErrorState.Name = "pnlErrorState"; pnlErrorState.Visible = false;
            lblErrorText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblErrorText.Appearance.Options.UseFont = true; lblErrorText.Location = new System.Drawing.Point(543, 290); lblErrorText.Name = "lblErrorText"; lblErrorText.Text = "حدث خطأ أثناء تحميل بيانات التدفق النقدي";
            svgErrorIcon.Location = new System.Drawing.Point(651, 190); svgErrorIcon.Name = "svgErrorIcon"; svgErrorIcon.Size = new System.Drawing.Size(64, 64); svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            btnRetry.Appearance.Font = new System.Drawing.Font("Cairo", 9F); btnRetry.Appearance.Options.UseFont = true; btnRetry.Location = new System.Drawing.Point(633, 330); btnRetry.Name = "btnRetry"; btnRetry.Size = new System.Drawing.Size(100, 34); btnRetry.Text = "إعادة المحاولة"; btnRetry.Click += btnRetry_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F); AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(grdCashFlow); Controls.Add(pnlCharts); Controls.Add(pnlLoadingState); Controls.Add(pnlEmptyState); Controls.Add(pnlErrorState);
            Controls.Add(pnlKpiCards); Controls.Add(barDockControlLeft); Controls.Add(barDockControlRight); Controls.Add(barDockControlBottom); Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5); Name = "ucCashFlowForecast"; RightToLeft = System.Windows.Forms.RightToLeft.Yes; Size = new System.Drawing.Size(1366, 902);

            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit(); pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiPlanned).EndInit(); pnlKpiPlanned.ResumeLayout(false); pnlKpiPlanned.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActual).EndInit(); pnlKpiActual.ResumeLayout(false); pnlKpiActual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).EndInit(); pnlKpiForecast.ResumeLayout(false); pnlKpiForecast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiRemaining).EndInit(); pnlKpiRemaining.ResumeLayout(false); pnlKpiRemaining.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).EndInit(); pnlCharts.ResumeLayout(false);
            tblCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpSCurve).EndInit(); grpSCurve.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpMonthlyCF).EndInit(); grpMonthlyCF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpPlannedVsActual).EndInit(); grpPlannedVsActual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpForecastChart).EndInit(); grpForecastChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartSCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartMonthlyCF).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartPlannedVsActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesPlannedCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesMonthlyCFPlanned).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesMonthlyCFActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesPlanned).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesForecastSpline).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdCashFlow).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCashFlow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit(); pnlLoadingState.ResumeLayout(false); pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit(); pnlEmptyState.ResumeLayout(false); pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit(); pnlErrorState.ResumeLayout(false); pnlErrorState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarDockControl barDockControlTop, barDockControlBottom, barDockControlLeft, barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh, bbiExportExcel, bbiPrint;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.PanelControl pnlKpiPlanned, pnlKpiActual, pnlKpiForecast, pnlKpiRemaining;
        private DevExpress.XtraEditors.LabelControl lblKpiPlannedValue, lblKpiPlannedTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiActualValue, lblKpiActualTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiForecastValue, lblKpiForecastTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiRemainingValue, lblKpiRemainingTitle;
        private DevExpress.XtraEditors.PanelControl pnlCharts;
        private System.Windows.Forms.TableLayoutPanel tblCharts;
        private DevExpress.XtraEditors.GroupControl grpSCurve, grpMonthlyCF, grpPlannedVsActual, grpForecastChart;
        private DevExpress.XtraCharts.ChartControl chartSCurve, chartMonthlyCF, chartPlannedVsActual, chartForecast;
        private DevExpress.XtraCharts.Series seriesPlannedCurve, seriesActualCurve, seriesMonthlyCFPlanned, seriesMonthlyCFActual, seriesPlanned, seriesActualLine, seriesForecastSpline;
        private DevExpress.XtraGrid.GridControl grdCashFlow;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCashFlow;
        private DevExpress.XtraGrid.Columns.GridColumn colCFMonth, colCFIncome, colCFExpense, colCFNet, colCFForecast, colCFVariance, colCFCumulative;
        private DevExpress.XtraEditors.PanelControl pnlLoadingState, pnlEmptyState, pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon, svgEmptyIcon, svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText, lblEmptyText, lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}

