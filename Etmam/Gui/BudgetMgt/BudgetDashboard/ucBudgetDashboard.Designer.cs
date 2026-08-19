namespace Etmam
{
    partial class ucBudgetDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBudgetDashboard));

            // ── Toolbar ──────────────────────────────────────────────────
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiStatus = new DevExpress.XtraBars.BarStaticItem();
            sbiLastRefresh = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();

            // ── State Banner ─────────────────────────────────────────────
            pnlStateBanner = new DevExpress.XtraEditors.PanelControl();
            lblStateBanner = new DevExpress.XtraEditors.LabelControl();
            svgStateBannerIcon = new DevExpress.XtraEditors.SvgImageBox();

            // ── KPI Cards ────────────────────────────────────────────────
            pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            pnlKpiOriginalBudget = new DevExpress.XtraEditors.PanelControl();
            lblKpiOriginalBudgetValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiOriginalBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiOriginalBudget = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiApprovedBudget = new DevExpress.XtraEditors.PanelControl();
            lblKpiApprovedBudgetValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiApprovedBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiApprovedBudget = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiCurrentBudget = new DevExpress.XtraEditors.PanelControl();
            lblKpiCurrentBudgetValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiCurrentBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiCurrentBudget = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiCommitments = new DevExpress.XtraEditors.PanelControl();
            lblKpiCommitmentsValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiCommitmentsTitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiCommitments = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiActualCost = new DevExpress.XtraEditors.PanelControl();
            lblKpiActualCostValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiActualCostTitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiActualCost = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiForecast = new DevExpress.XtraEditors.PanelControl();
            lblKpiForecastValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiForecastTitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiForecast = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiVariance = new DevExpress.XtraEditors.PanelControl();
            lblKpiVarianceValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiVarianceTitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiVariance = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiCPI = new DevExpress.XtraEditors.PanelControl();
            lblKpiCPIValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiCPITitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiCPI = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiSPI = new DevExpress.XtraEditors.PanelControl();
            lblKpiSPIValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiSPITitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiSPI = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiCashFlow = new DevExpress.XtraEditors.PanelControl();
            lblKpiCashFlowValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiCashFlowTitle = new DevExpress.XtraEditors.LabelControl();
            svgKpiCashFlow = new DevExpress.XtraEditors.SvgImageBox();

            // ── Filter Bar ───────────────────────────────────────────────
            pnlFilters = new DevExpress.XtraEditors.PanelControl();
            cboCompany = new DevExpress.XtraEditors.ComboBoxEdit();
            lblCompany = new DevExpress.XtraEditors.LabelControl();
            cboBranch = new DevExpress.XtraEditors.ComboBoxEdit();
            lblBranch = new DevExpress.XtraEditors.LabelControl();
            lueProject = new DevExpress.XtraEditors.LookUpEdit();
            lblProject = new DevExpress.XtraEditors.LabelControl();
            cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            dtDateFrom = new DevExpress.XtraEditors.DateEdit();
            dtDateTo = new DevExpress.XtraEditors.DateEdit();
            lblDateRange = new DevExpress.XtraEditors.LabelControl();
            lblDateRangeSeparator = new DevExpress.XtraEditors.LabelControl();
            btnSearch = new DevExpress.XtraEditors.SimpleButton();
            btnClearFilters = new DevExpress.XtraEditors.SimpleButton();

            // ── Charts ───────────────────────────────────────────────────
            pnlCharts = new DevExpress.XtraEditors.PanelControl();
            tblCharts = new System.Windows.Forms.TableLayoutPanel();
            grpBudgetVsActual = new DevExpress.XtraEditors.GroupControl();
            chartBudgetVsActual = new DevExpress.XtraCharts.ChartControl();
            seriesBudget = new DevExpress.XtraCharts.Series("الموازنة", DevExpress.XtraCharts.ViewType.Bar);
            seriesActual = new DevExpress.XtraCharts.Series("الفعلي", DevExpress.XtraCharts.ViewType.Bar);
            grpBudgetDistribution = new DevExpress.XtraEditors.GroupControl();
            chartBudgetDistribution = new DevExpress.XtraCharts.ChartControl();
            seriesBudgetDistribution = new DevExpress.XtraCharts.Series("توزيع الموازنة", DevExpress.XtraCharts.ViewType.Pie);
            grpCostBreakdown = new DevExpress.XtraEditors.GroupControl();
            chartCostBreakdown = new DevExpress.XtraCharts.ChartControl();
            seriesCostBreakdown = new DevExpress.XtraCharts.Series("توزيع التكلفة", DevExpress.XtraCharts.ViewType.Pie);
            grpForecastTrend = new DevExpress.XtraEditors.GroupControl();
            chartForecastTrend = new DevExpress.XtraCharts.ChartControl();
            seriesForecastTrend = new DevExpress.XtraCharts.Series("اتجاه التوقع", DevExpress.XtraCharts.ViewType.Spline);
            grpCashFlowCurve = new DevExpress.XtraEditors.GroupControl();
            chartCashFlowCurve = new DevExpress.XtraCharts.ChartControl();
            seriesCashFlowPlanned = new DevExpress.XtraCharts.Series("التدفق المخطط", DevExpress.XtraCharts.ViewType.Area);
            seriesCashFlowActual = new DevExpress.XtraCharts.Series("التدفق الفعلي", DevExpress.XtraCharts.ViewType.Area);

            // ── Operational Grids (XtraTab) ───────────────────────────────
            tabOperational = new DevExpress.XtraTab.XtraTabControl();
            tabPagePendingRevisions = new DevExpress.XtraTab.XtraTabPage();
            grdPendingRevisions = new DevExpress.XtraGrid.GridControl();
            gvPendingRevisions = new DevExpress.XtraGrid.Views.Grid.GridView();
            colRevCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevBudgetName = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            tabPagePendingApprovals = new DevExpress.XtraTab.XtraTabPage();
            grdPendingApprovals = new DevExpress.XtraGrid.GridControl();
            gvPendingApprovals = new DevExpress.XtraGrid.Views.Grid.GridView();
            colAppCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colAppBudgetName = new DevExpress.XtraGrid.Columns.GridColumn();
            colAppStep = new DevExpress.XtraGrid.Columns.GridColumn();
            colAppUser = new DevExpress.XtraGrid.Columns.GridColumn();
            colAppDate = new DevExpress.XtraGrid.Columns.GridColumn();
            tabPageBudgetAlerts = new DevExpress.XtraTab.XtraTabPage();
            grdBudgetAlerts = new DevExpress.XtraGrid.GridControl();
            gvBudgetAlerts = new DevExpress.XtraGrid.Views.Grid.GridView();
            colAlertType = new DevExpress.XtraGrid.Columns.GridColumn();
            colAlertDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colAlertProject = new DevExpress.XtraGrid.Columns.GridColumn();
            colAlertDate = new DevExpress.XtraGrid.Columns.GridColumn();
            tabPageTopOverBudget = new DevExpress.XtraTab.XtraTabPage();
            grdTopOverBudget = new DevExpress.XtraGrid.GridControl();
            gvTopOverBudget = new DevExpress.XtraGrid.Views.Grid.GridView();
            colOBCostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colOBDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colOBBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            colOBActual = new DevExpress.XtraGrid.Columns.GridColumn();
            colOBVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            colOBVariancePct = new DevExpress.XtraGrid.Columns.GridColumn();
            tabPageCostTrend = new DevExpress.XtraTab.XtraTabPage();
            grdCostTrend = new DevExpress.XtraGrid.GridControl();
            gvCostTrend = new DevExpress.XtraGrid.Views.Grid.GridView();
            colTrendPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrendBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrendActual = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrendForecast = new DevExpress.XtraGrid.Columns.GridColumn();

            // ── State Panels ─────────────────────────────────────────────
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            lblLoadingText = new DevExpress.XtraEditors.LabelControl();
            svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            lblEmptyText = new DevExpress.XtraEditors.LabelControl();
            svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlLockedState = new DevExpress.XtraEditors.PanelControl(); lblLockedText = new DevExpress.XtraEditors.LabelControl(); svgLockedIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();
            lblErrorText = new DevExpress.XtraEditors.LabelControl();
            svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();

            // ── Begin Init ────────────────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)barManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlStateBanner).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgStateBannerIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit();
            pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiOriginalBudget).BeginInit();
            pnlKpiOriginalBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiApprovedBudget).BeginInit();
            pnlKpiApprovedBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCurrentBudget).BeginInit();
            pnlKpiCurrentBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCommitments).BeginInit();
            pnlKpiCommitments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActualCost).BeginInit();
            pnlKpiActualCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).BeginInit();
            pnlKpiForecast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiVariance).BeginInit();
            pnlKpiVariance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCPI).BeginInit();
            pnlKpiCPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiSPI).BeginInit();
            pnlKpiSPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCashFlow).BeginInit();
            pnlKpiCashFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgKpiOriginalBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiApprovedBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiCurrentBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiCommitments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiActualCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiVariance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiCPI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiSPI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiCashFlow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFilters).BeginInit();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboCompany.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboBranch.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).BeginInit();
            pnlCharts.SuspendLayout();
            tblCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpBudgetVsActual).BeginInit();
            grpBudgetVsActual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartBudgetVsActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpBudgetDistribution).BeginInit();
            grpBudgetDistribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartBudgetDistribution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesBudgetDistribution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpCostBreakdown).BeginInit();
            grpCostBreakdown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCostBreakdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesCostBreakdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpForecastTrend).BeginInit();
            grpForecastTrend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartForecastTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesForecastTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpCashFlowCurve).BeginInit();
            grpCashFlowCurve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCashFlowCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesCashFlowPlanned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesCashFlowActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabOperational).BeginInit();
            tabOperational.SuspendLayout();
            tabPagePendingRevisions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdPendingRevisions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvPendingRevisions).BeginInit();
            tabPagePendingApprovals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdPendingApprovals).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvPendingApprovals).BeginInit();
            tabPageBudgetAlerts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdBudgetAlerts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvBudgetAlerts).BeginInit();
            tabPageTopOverBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdTopOverBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvTopOverBudget).BeginInit();
            tabPageCostTrend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdCostTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCostTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLockedState).BeginInit();
            pnlLockedState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLockedIcon).BeginInit();
            SuspendLayout();

            // ── barManagerMain ────────────────────────────────────────────
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiRefresh, bbiExportExcel, bbiPrint, sbiStatus, sbiLastRefresh });
            barManagerMain.MainMenu = barMain;
            barManagerMain.MaxItemId = 5;
            barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerMain.StatusBar = barStatus;
            //
            // barMain
            //
            barMain.BarName = "شريط أدوات لوحة الموازنة";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[]
            {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
            });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.MinHeight = 34;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "شريط أدوات لوحة الموازنة";
            //
            // bbiRefresh
            //
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 0;
            bbiRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiRefresh.ImageOptions.SvgImage");
            bbiRefresh.Name = "bbiRefresh";
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            //
            // bbiExportExcel
            //
            bbiExportExcel.Caption = "تصدير Excel";
            bbiExportExcel.Id = 1;
            bbiExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExportExcel.ImageOptions.SvgImage");
            bbiExportExcel.Name = "bbiExportExcel";
            bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            //
            // bbiPrint
            //
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 2;
            bbiPrint.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiPrint.ImageOptions.SvgImage");
            bbiPrint.Name = "bbiPrint";
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            //
            // barStatus
            //
            barStatus.BarName = "شريط الحالة";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(sbiStatus), new DevExpress.XtraBars.LinkPersistInfo(sbiLastRefresh) });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "شريط الحالة";
            //
            // sbiStatus
            //
            sbiStatus.Caption = "لوحة الموازنة";
            sbiStatus.Id = 3;
            sbiStatus.Name = "sbiStatus";
            //
            // sbiLastRefresh
            //
            sbiLastRefresh.Caption = "آخر تحديث: —";
            sbiLastRefresh.Id = 4;
            sbiLastRefresh.Name = "sbiLastRefresh";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManagerMain;
            barDockControlTop.Size = new System.Drawing.Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 873);
            barDockControlBottom.Manager = barManagerMain;
            barDockControlBottom.Size = new System.Drawing.Size(1366, 29);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            barDockControlLeft.Manager = barManagerMain;
            barDockControlLeft.Size = new System.Drawing.Size(0, 839);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1366, 34);
            barDockControlRight.Manager = barManagerMain;
            barDockControlRight.Size = new System.Drawing.Size(0, 839);

            // ── pnlStateBanner ────────────────────────────────────────────
            pnlStateBanner.Appearance.BackColor = System.Drawing.Color.FromArgb(235, 236, 240);
            pnlStateBanner.Appearance.Options.UseBackColor = true;
            pnlStateBanner.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlStateBanner.Controls.Add(lblStateBanner);
            pnlStateBanner.Controls.Add(svgStateBannerIcon);
            pnlStateBanner.Dock = System.Windows.Forms.DockStyle.Top;
            pnlStateBanner.Location = new System.Drawing.Point(0, 34);
            pnlStateBanner.Name = "pnlStateBanner";
            pnlStateBanner.Size = new System.Drawing.Size(1366, 36);
            pnlStateBanner.TabIndex = 0;
            pnlStateBanner.Visible = false;
            //
            // lblStateBanner
            //
            lblStateBanner.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            lblStateBanner.Appearance.ForeColor = System.Drawing.Color.FromArgb(90, 100, 115);
            lblStateBanner.Appearance.Options.UseFont = true;
            lblStateBanner.Appearance.Options.UseForeColor = true;
            lblStateBanner.Location = new System.Drawing.Point(1150, 8);
            lblStateBanner.Name = "lblStateBanner";
            lblStateBanner.Size = new System.Drawing.Size(155, 20);
            lblStateBanner.TabIndex = 1;
            lblStateBanner.Text = "لوحة الموازنة — للقراءة فقط";
            //
            // svgStateBannerIcon
            //
            svgStateBannerIcon.Location = new System.Drawing.Point(1320, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);
            svgStateBannerIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgStateBannerIcon.SvgImage");
            svgStateBannerIcon.TabIndex = 0;

            // ── KPI Cards Row ─────────────────────────────────────────────
            pnlKpiCards.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCards.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                pnlKpiOriginalBudget, pnlKpiApprovedBudget, pnlKpiCurrentBudget, pnlKpiCommitments, pnlKpiActualCost,
                pnlKpiForecast, pnlKpiVariance, pnlKpiCPI, pnlKpiSPI, pnlKpiCashFlow
            });
            pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            pnlKpiCards.Location = new System.Drawing.Point(0, 70);
            pnlKpiCards.Name = "pnlKpiCards";
            pnlKpiCards.Size = new System.Drawing.Size(1366, 100);
            pnlKpiCards.TabIndex = 1;

            // Build 10 KPI cards (index 0..9, width 134 each, gap 2; RTL: leftmost = 8, spread right)
            // ── KPI 0: الموازنة الأصلية ──
            svgKpiOriginalBudget.Location = new System.Drawing.Point(100, 12);
            svgKpiOriginalBudget.Name = "svgKpiOriginalBudget";
            svgKpiOriginalBudget.Size = new System.Drawing.Size(24, 24);
            svgKpiOriginalBudget.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiOriginalBudget.TabIndex = 2;
            lblKpiOriginalBudgetTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiOriginalBudgetTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiOriginalBudgetTitle.Appearance.Options.UseFont = true;
            lblKpiOriginalBudgetTitle.Appearance.Options.UseForeColor = true;
            lblKpiOriginalBudgetTitle.Location = new System.Drawing.Point(6, 12);
            lblKpiOriginalBudgetTitle.Name = "lblKpiOriginalBudgetTitle";
            lblKpiOriginalBudgetTitle.Size = new System.Drawing.Size(90, 18);
            lblKpiOriginalBudgetTitle.TabIndex = 0;
            lblKpiOriginalBudgetTitle.Text = "الموازنة الأصلية";
            lblKpiOriginalBudgetValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiOriginalBudgetValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 117, 182);
            lblKpiOriginalBudgetValue.Appearance.Options.UseFont = true;
            lblKpiOriginalBudgetValue.Appearance.Options.UseForeColor = true;
            lblKpiOriginalBudgetValue.Location = new System.Drawing.Point(6, 38);
            lblKpiOriginalBudgetValue.Name = "lblKpiOriginalBudgetValue";
            lblKpiOriginalBudgetValue.Size = new System.Drawing.Size(90, 28);
            lblKpiOriginalBudgetValue.TabIndex = 1;
            lblKpiOriginalBudgetValue.Text = "— ";
            pnlKpiOriginalBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiOriginalBudget.Controls.Add(lblKpiOriginalBudgetTitle);
            pnlKpiOriginalBudget.Controls.Add(lblKpiOriginalBudgetValue);
            pnlKpiOriginalBudget.Controls.Add(svgKpiOriginalBudget);
            pnlKpiOriginalBudget.Location = new System.Drawing.Point(1232, 8);
            pnlKpiOriginalBudget.Name = "pnlKpiOriginalBudget";
            pnlKpiOriginalBudget.Size = new System.Drawing.Size(130, 84);
            pnlKpiOriginalBudget.TabIndex = 0;

            // ── KPI 1: الموازنة المعتمدة ──
            svgKpiApprovedBudget.Location = new System.Drawing.Point(100, 12);
            svgKpiApprovedBudget.Name = "svgKpiApprovedBudget";
            svgKpiApprovedBudget.Size = new System.Drawing.Size(24, 24);
            svgKpiApprovedBudget.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiApprovedBudget.TabIndex = 2;
            lblKpiApprovedBudgetTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiApprovedBudgetTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiApprovedBudgetTitle.Appearance.Options.UseFont = true;
            lblKpiApprovedBudgetTitle.Appearance.Options.UseForeColor = true;
            lblKpiApprovedBudgetTitle.Location = new System.Drawing.Point(6, 12);
            lblKpiApprovedBudgetTitle.Name = "lblKpiApprovedBudgetTitle";
            lblKpiApprovedBudgetTitle.Size = new System.Drawing.Size(90, 18);
            lblKpiApprovedBudgetTitle.TabIndex = 0;
            lblKpiApprovedBudgetTitle.Text = "الموازنة المعتمدة";
            lblKpiApprovedBudgetValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiApprovedBudgetValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(68, 114, 196);
            lblKpiApprovedBudgetValue.Appearance.Options.UseFont = true;
            lblKpiApprovedBudgetValue.Appearance.Options.UseForeColor = true;
            lblKpiApprovedBudgetValue.Location = new System.Drawing.Point(6, 38);
            lblKpiApprovedBudgetValue.Name = "lblKpiApprovedBudgetValue";
            lblKpiApprovedBudgetValue.Size = new System.Drawing.Size(90, 28);
            lblKpiApprovedBudgetValue.TabIndex = 1;
            lblKpiApprovedBudgetValue.Text = "— ";
            pnlKpiApprovedBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiApprovedBudget.Controls.Add(lblKpiApprovedBudgetTitle);
            pnlKpiApprovedBudget.Controls.Add(lblKpiApprovedBudgetValue);
            pnlKpiApprovedBudget.Controls.Add(svgKpiApprovedBudget);
            pnlKpiApprovedBudget.Location = new System.Drawing.Point(1096, 8);
            pnlKpiApprovedBudget.Name = "pnlKpiApprovedBudget";
            pnlKpiApprovedBudget.Size = new System.Drawing.Size(130, 84);
            pnlKpiApprovedBudget.TabIndex = 1;

            // ── KPI 2: الموازنة الحالية ──
            svgKpiCurrentBudget.Location = new System.Drawing.Point(100, 12);
            svgKpiCurrentBudget.Name = "svgKpiCurrentBudget";
            svgKpiCurrentBudget.Size = new System.Drawing.Size(24, 24);
            svgKpiCurrentBudget.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiCurrentBudget.TabIndex = 2;
            lblKpiCurrentBudgetTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiCurrentBudgetTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiCurrentBudgetTitle.Appearance.Options.UseFont = true;
            lblKpiCurrentBudgetTitle.Appearance.Options.UseForeColor = true;
            lblKpiCurrentBudgetTitle.Location = new System.Drawing.Point(6, 12);
            lblKpiCurrentBudgetTitle.Name = "lblKpiCurrentBudgetTitle";
            lblKpiCurrentBudgetTitle.Size = new System.Drawing.Size(90, 18);
            lblKpiCurrentBudgetTitle.TabIndex = 0;
            lblKpiCurrentBudgetTitle.Text = "الموازنة الحالية";
            lblKpiCurrentBudgetValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiCurrentBudgetValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(31, 119, 180);
            lblKpiCurrentBudgetValue.Appearance.Options.UseFont = true;
            lblKpiCurrentBudgetValue.Appearance.Options.UseForeColor = true;
            lblKpiCurrentBudgetValue.Location = new System.Drawing.Point(6, 38);
            lblKpiCurrentBudgetValue.Name = "lblKpiCurrentBudgetValue";
            lblKpiCurrentBudgetValue.Size = new System.Drawing.Size(90, 28);
            lblKpiCurrentBudgetValue.TabIndex = 1;
            lblKpiCurrentBudgetValue.Text = "— ";
            pnlKpiCurrentBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiCurrentBudget.Controls.Add(lblKpiCurrentBudgetTitle);
            pnlKpiCurrentBudget.Controls.Add(lblKpiCurrentBudgetValue);
            pnlKpiCurrentBudget.Controls.Add(svgKpiCurrentBudget);
            pnlKpiCurrentBudget.Location = new System.Drawing.Point(960, 8);
            pnlKpiCurrentBudget.Name = "pnlKpiCurrentBudget";
            pnlKpiCurrentBudget.Size = new System.Drawing.Size(130, 84);
            pnlKpiCurrentBudget.TabIndex = 2;

            // ── KPI 3: الالتزامات ──
            svgKpiCommitments.Location = new System.Drawing.Point(100, 12);
            svgKpiCommitments.Name = "svgKpiCommitments";
            svgKpiCommitments.Size = new System.Drawing.Size(24, 24);
            svgKpiCommitments.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiCommitments.TabIndex = 2;
            lblKpiCommitmentsTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiCommitmentsTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiCommitmentsTitle.Appearance.Options.UseFont = true;
            lblKpiCommitmentsTitle.Appearance.Options.UseForeColor = true;
            lblKpiCommitmentsTitle.Location = new System.Drawing.Point(6, 12);
            lblKpiCommitmentsTitle.Name = "lblKpiCommitmentsTitle";
            lblKpiCommitmentsTitle.Size = new System.Drawing.Size(90, 18);
            lblKpiCommitmentsTitle.TabIndex = 0;
            lblKpiCommitmentsTitle.Text = "الالتزامات";
            lblKpiCommitmentsValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiCommitmentsValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(255, 127, 14);
            lblKpiCommitmentsValue.Appearance.Options.UseFont = true;
            lblKpiCommitmentsValue.Appearance.Options.UseForeColor = true;
            lblKpiCommitmentsValue.Location = new System.Drawing.Point(6, 38);
            lblKpiCommitmentsValue.Name = "lblKpiCommitmentsValue";
            lblKpiCommitmentsValue.Size = new System.Drawing.Size(90, 28);
            lblKpiCommitmentsValue.TabIndex = 1;
            lblKpiCommitmentsValue.Text = "— ";
            pnlKpiCommitments.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiCommitments.Controls.Add(lblKpiCommitmentsTitle);
            pnlKpiCommitments.Controls.Add(lblKpiCommitmentsValue);
            pnlKpiCommitments.Controls.Add(svgKpiCommitments);
            pnlKpiCommitments.Location = new System.Drawing.Point(824, 8);
            pnlKpiCommitments.Name = "pnlKpiCommitments";
            pnlKpiCommitments.Size = new System.Drawing.Size(130, 84);
            pnlKpiCommitments.TabIndex = 3;

            // ── KPI 4: التكلفة الفعلية ──
            svgKpiActualCost.Location = new System.Drawing.Point(100, 12);
            svgKpiActualCost.Name = "svgKpiActualCost";
            svgKpiActualCost.Size = new System.Drawing.Size(24, 24);
            svgKpiActualCost.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiActualCost.TabIndex = 2;
            lblKpiActualCostTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiActualCostTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiActualCostTitle.Appearance.Options.UseFont = true;
            lblKpiActualCostTitle.Appearance.Options.UseForeColor = true;
            lblKpiActualCostTitle.Location = new System.Drawing.Point(6, 12);
            lblKpiActualCostTitle.Name = "lblKpiActualCostTitle";
            lblKpiActualCostTitle.Size = new System.Drawing.Size(90, 18);
            lblKpiActualCostTitle.TabIndex = 0;
            lblKpiActualCostTitle.Text = "التكلفة الفعلية";
            lblKpiActualCostValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiActualCostValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(192, 80, 77);
            lblKpiActualCostValue.Appearance.Options.UseFont = true;
            lblKpiActualCostValue.Appearance.Options.UseForeColor = true;
            lblKpiActualCostValue.Location = new System.Drawing.Point(6, 38);
            lblKpiActualCostValue.Name = "lblKpiActualCostValue";
            lblKpiActualCostValue.Size = new System.Drawing.Size(90, 28);
            lblKpiActualCostValue.TabIndex = 1;
            lblKpiActualCostValue.Text = "— ";
            pnlKpiActualCost.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiActualCost.Controls.Add(lblKpiActualCostTitle);
            pnlKpiActualCost.Controls.Add(lblKpiActualCostValue);
            pnlKpiActualCost.Controls.Add(svgKpiActualCost);
            pnlKpiActualCost.Location = new System.Drawing.Point(688, 8);
            pnlKpiActualCost.Name = "pnlKpiActualCost";
            pnlKpiActualCost.Size = new System.Drawing.Size(130, 84);
            pnlKpiActualCost.TabIndex = 4;

            // ── KPI 5: التوقعات ──
            svgKpiForecast.Location = new System.Drawing.Point(100, 12);
            svgKpiForecast.Name = "svgKpiForecast";
            svgKpiForecast.Size = new System.Drawing.Size(24, 24);
            svgKpiForecast.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiForecast.TabIndex = 2;
            lblKpiForecastTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiForecastTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiForecastTitle.Appearance.Options.UseFont = true;
            lblKpiForecastTitle.Appearance.Options.UseForeColor = true;
            lblKpiForecastTitle.Location = new System.Drawing.Point(6, 12);
            lblKpiForecastTitle.Name = "lblKpiForecastTitle";
            lblKpiForecastTitle.Size = new System.Drawing.Size(90, 18);
            lblKpiForecastTitle.TabIndex = 0;
            lblKpiForecastTitle.Text = "التوقعات";
            lblKpiForecastValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiForecastValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(148, 103, 189);
            lblKpiForecastValue.Appearance.Options.UseFont = true;
            lblKpiForecastValue.Appearance.Options.UseForeColor = true;
            lblKpiForecastValue.Location = new System.Drawing.Point(6, 38);
            lblKpiForecastValue.Name = "lblKpiForecastValue";
            lblKpiForecastValue.Size = new System.Drawing.Size(90, 28);
            lblKpiForecastValue.TabIndex = 1;
            lblKpiForecastValue.Text = "— ";
            pnlKpiForecast.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiForecast.Controls.Add(lblKpiForecastTitle);
            pnlKpiForecast.Controls.Add(lblKpiForecastValue);
            pnlKpiForecast.Controls.Add(svgKpiForecast);
            pnlKpiForecast.Location = new System.Drawing.Point(552, 8);
            pnlKpiForecast.Name = "pnlKpiForecast";
            pnlKpiForecast.Size = new System.Drawing.Size(130, 84);
            pnlKpiForecast.TabIndex = 5;

            // ── KPI 6: انحراف الموازنة ──
            svgKpiVariance.Location = new System.Drawing.Point(100, 12);
            svgKpiVariance.Name = "svgKpiVariance";
            svgKpiVariance.Size = new System.Drawing.Size(24, 24);
            svgKpiVariance.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiVariance.TabIndex = 2;
            lblKpiVarianceTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiVarianceTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiVarianceTitle.Appearance.Options.UseFont = true;
            lblKpiVarianceTitle.Appearance.Options.UseForeColor = true;
            lblKpiVarianceTitle.Location = new System.Drawing.Point(6, 12);
            lblKpiVarianceTitle.Name = "lblKpiVarianceTitle";
            lblKpiVarianceTitle.Size = new System.Drawing.Size(90, 18);
            lblKpiVarianceTitle.TabIndex = 0;
            lblKpiVarianceTitle.Text = "انحراف الموازنة";
            lblKpiVarianceValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiVarianceValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(192, 80, 77);
            lblKpiVarianceValue.Appearance.Options.UseFont = true;
            lblKpiVarianceValue.Appearance.Options.UseForeColor = true;
            lblKpiVarianceValue.Location = new System.Drawing.Point(6, 38);
            lblKpiVarianceValue.Name = "lblKpiVarianceValue";
            lblKpiVarianceValue.Size = new System.Drawing.Size(90, 28);
            lblKpiVarianceValue.TabIndex = 1;
            lblKpiVarianceValue.Text = "— ";
            pnlKpiVariance.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiVariance.Controls.Add(lblKpiVarianceTitle);
            pnlKpiVariance.Controls.Add(lblKpiVarianceValue);
            pnlKpiVariance.Controls.Add(svgKpiVariance);
            pnlKpiVariance.Location = new System.Drawing.Point(416, 8);
            pnlKpiVariance.Name = "pnlKpiVariance";
            pnlKpiVariance.Size = new System.Drawing.Size(130, 84);
            pnlKpiVariance.TabIndex = 6;

            // ── KPI 7: مؤشر التكلفة CPI ──
            svgKpiCPI.Location = new System.Drawing.Point(100, 12);
            svgKpiCPI.Name = "svgKpiCPI";
            svgKpiCPI.Size = new System.Drawing.Size(24, 24);
            svgKpiCPI.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiCPI.TabIndex = 2;
            lblKpiCPITitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiCPITitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiCPITitle.Appearance.Options.UseFont = true;
            lblKpiCPITitle.Appearance.Options.UseForeColor = true;
            lblKpiCPITitle.Location = new System.Drawing.Point(6, 12);
            lblKpiCPITitle.Name = "lblKpiCPITitle";
            lblKpiCPITitle.Size = new System.Drawing.Size(90, 18);
            lblKpiCPITitle.TabIndex = 0;
            lblKpiCPITitle.Text = "مؤشر التكلفة CPI";
            lblKpiCPIValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiCPIValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 158, 91);
            lblKpiCPIValue.Appearance.Options.UseFont = true;
            lblKpiCPIValue.Appearance.Options.UseForeColor = true;
            lblKpiCPIValue.Location = new System.Drawing.Point(6, 38);
            lblKpiCPIValue.Name = "lblKpiCPIValue";
            lblKpiCPIValue.Size = new System.Drawing.Size(90, 28);
            lblKpiCPIValue.TabIndex = 1;
            lblKpiCPIValue.Text = "— ";
            pnlKpiCPI.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiCPI.Controls.Add(lblKpiCPITitle);
            pnlKpiCPI.Controls.Add(lblKpiCPIValue);
            pnlKpiCPI.Controls.Add(svgKpiCPI);
            pnlKpiCPI.Location = new System.Drawing.Point(280, 8);
            pnlKpiCPI.Name = "pnlKpiCPI";
            pnlKpiCPI.Size = new System.Drawing.Size(130, 84);
            pnlKpiCPI.TabIndex = 7;

            // ── KPI 8: مؤشر الجدول SPI ──
            svgKpiSPI.Location = new System.Drawing.Point(100, 12);
            svgKpiSPI.Name = "svgKpiSPI";
            svgKpiSPI.Size = new System.Drawing.Size(24, 24);
            svgKpiSPI.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiSPI.TabIndex = 2;
            lblKpiSPITitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiSPITitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiSPITitle.Appearance.Options.UseFont = true;
            lblKpiSPITitle.Appearance.Options.UseForeColor = true;
            lblKpiSPITitle.Location = new System.Drawing.Point(6, 12);
            lblKpiSPITitle.Name = "lblKpiSPITitle";
            lblKpiSPITitle.Size = new System.Drawing.Size(90, 18);
            lblKpiSPITitle.TabIndex = 0;
            lblKpiSPITitle.Text = "مؤشر الجدول SPI";
            lblKpiSPIValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiSPIValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(28, 140, 140);
            lblKpiSPIValue.Appearance.Options.UseFont = true;
            lblKpiSPIValue.Appearance.Options.UseForeColor = true;
            lblKpiSPIValue.Location = new System.Drawing.Point(6, 38);
            lblKpiSPIValue.Name = "lblKpiSPIValue";
            lblKpiSPIValue.Size = new System.Drawing.Size(90, 28);
            lblKpiSPIValue.TabIndex = 1;
            lblKpiSPIValue.Text = "— ";
            pnlKpiSPI.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiSPI.Controls.Add(lblKpiSPITitle);
            pnlKpiSPI.Controls.Add(lblKpiSPIValue);
            pnlKpiSPI.Controls.Add(svgKpiSPI);
            pnlKpiSPI.Location = new System.Drawing.Point(144, 8);
            pnlKpiSPI.Name = "pnlKpiSPI";
            pnlKpiSPI.Size = new System.Drawing.Size(130, 84);
            pnlKpiSPI.TabIndex = 8;

            // ── KPI 9: التدفق النقدي ──
            svgKpiCashFlow.Location = new System.Drawing.Point(100, 12);
            svgKpiCashFlow.Name = "svgKpiCashFlow";
            svgKpiCashFlow.Size = new System.Drawing.Size(24, 24);
            svgKpiCashFlow.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgKpiBudget.SvgImage");
            svgKpiCashFlow.TabIndex = 2;
            lblKpiCashFlowTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F);
            lblKpiCashFlowTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKpiCashFlowTitle.Appearance.Options.UseFont = true;
            lblKpiCashFlowTitle.Appearance.Options.UseForeColor = true;
            lblKpiCashFlowTitle.Location = new System.Drawing.Point(6, 12);
            lblKpiCashFlowTitle.Name = "lblKpiCashFlowTitle";
            lblKpiCashFlowTitle.Size = new System.Drawing.Size(90, 18);
            lblKpiCashFlowTitle.TabIndex = 0;
            lblKpiCashFlowTitle.Text = "التدفق النقدي";
            lblKpiCashFlowValue.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            lblKpiCashFlowValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 117, 182);
            lblKpiCashFlowValue.Appearance.Options.UseFont = true;
            lblKpiCashFlowValue.Appearance.Options.UseForeColor = true;
            lblKpiCashFlowValue.Location = new System.Drawing.Point(6, 38);
            lblKpiCashFlowValue.Name = "lblKpiCashFlowValue";
            lblKpiCashFlowValue.Size = new System.Drawing.Size(90, 28);
            lblKpiCashFlowValue.TabIndex = 1;
            lblKpiCashFlowValue.Text = "— ";
            pnlKpiCashFlow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiCashFlow.Controls.Add(lblKpiCashFlowTitle);
            pnlKpiCashFlow.Controls.Add(lblKpiCashFlowValue);
            pnlKpiCashFlow.Controls.Add(svgKpiCashFlow);
            pnlKpiCashFlow.Location = new System.Drawing.Point(8, 8);
            pnlKpiCashFlow.Name = "pnlKpiCashFlow";
            pnlKpiCashFlow.Size = new System.Drawing.Size(130, 84);
            pnlKpiCashFlow.TabIndex = 9;

            // ── pnlFilters ────────────────────────────────────────────────
            pnlFilters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFilters.Appearance.BackColor = System.Drawing.Color.FromArgb(248, 248, 250);
            pnlFilters.Appearance.Options.UseBackColor = true;
            pnlFilters.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblCompany, cboCompany, lblBranch, cboBranch, lblProject, lueProject,
                lblStatus, cboStatus, lblDateRange, dtDateFrom, lblDateRangeSeparator, dtDateTo,
                btnSearch, btnClearFilters
            });
            pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilters.Location = new System.Drawing.Point(0, 170);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new System.Drawing.Size(1366, 52);
            pnlFilters.TabIndex = 2;

            // Filter controls (RTL layout — right to left)
            SetupFilterControl(lblCompany, "lblCompany", "الشركة:", new System.Drawing.Point(1270, 8), new System.Drawing.Size(45, 20));
            SetupComboFilter(cboCompany, "cboCompany", new System.Drawing.Point(1140, 10), new System.Drawing.Size(125, 30));
            SetupFilterControl(lblBranch, "lblBranch", "الفرع:", new System.Drawing.Point(1080, 8), new System.Drawing.Size(50, 20));
            SetupComboFilter(cboBranch, "cboBranch", new System.Drawing.Point(950, 10), new System.Drawing.Size(125, 30));
            SetupFilterControl(lblProject, "lblProject", "المشروع:", new System.Drawing.Point(886, 8), new System.Drawing.Size(55, 20));
            lueProject.Location = new System.Drawing.Point(750, 10);
            lueProject.Name = "lueProject";
            lueProject.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            lueProject.Properties.Appearance.Options.UseFont = true;
            lueProject.Size = new System.Drawing.Size(130, 30);
            lueProject.TabIndex = 5;
            SetupFilterControl(lblStatus, "lblStatus", "الحالة:", new System.Drawing.Point(688, 8), new System.Drawing.Size(52, 20));
            SetupComboFilter(cboStatus, "cboStatus", new System.Drawing.Point(560, 10), new System.Drawing.Size(123, 30));
            SetupFilterControl(lblDateRange, "lblDateRange", "التاريخ:", new System.Drawing.Point(498, 8), new System.Drawing.Size(54, 20));
            dtDateFrom.Location = new System.Drawing.Point(375, 10);
            dtDateFrom.Name = "dtDateFrom";
            dtDateFrom.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            dtDateFrom.Properties.Appearance.Options.UseFont = true;
            dtDateFrom.Size = new System.Drawing.Size(118, 30);
            dtDateFrom.TabIndex = 9;
            lblDateRangeSeparator.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            lblDateRangeSeparator.Appearance.Options.UseFont = true;
            lblDateRangeSeparator.Location = new System.Drawing.Point(361, 14);
            lblDateRangeSeparator.Name = "lblDateRangeSeparator";
            lblDateRangeSeparator.Size = new System.Drawing.Size(10, 20);
            lblDateRangeSeparator.TabIndex = 10;
            lblDateRangeSeparator.Text = "—";
            dtDateTo.Location = new System.Drawing.Point(238, 10);
            dtDateTo.Name = "dtDateTo";
            dtDateTo.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            dtDateTo.Properties.Appearance.Options.UseFont = true;
            dtDateTo.Size = new System.Drawing.Size(118, 30);
            dtDateTo.TabIndex = 11;
            btnSearch.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            btnSearch.Appearance.Options.UseFont = true;
            btnSearch.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSearch.ImageOptions.SvgImage");
            btnSearch.Location = new System.Drawing.Point(130, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(100, 30);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "بحث";
            btnSearch.Click += btnSearch_Click;
            btnClearFilters.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            btnClearFilters.Appearance.Options.UseFont = true;
            btnClearFilters.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnClearFilters.ImageOptions.SvgImage");
            btnClearFilters.Location = new System.Drawing.Point(14, 10);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new System.Drawing.Size(110, 30);
            btnClearFilters.TabIndex = 13;
            btnClearFilters.Text = "مسح الفلاتر";
            btnClearFilters.Click += btnClearFilters_Click;

            // ── Charts Panel ──────────────────────────────────────────────
            pnlCharts.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCharts.Controls.Add(tblCharts);
            pnlCharts.Dock = System.Windows.Forms.DockStyle.Top;
            pnlCharts.Location = new System.Drawing.Point(0, 222);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Size = new System.Drawing.Size(1366, 320);
            pnlCharts.TabIndex = 3;
            //
            // tblCharts
            //
            tblCharts.ColumnCount = 3;
            tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            tblCharts.Controls.Add(grpBudgetVsActual, 0, 0);
            tblCharts.Controls.Add(grpBudgetDistribution, 1, 0);
            tblCharts.Controls.Add(grpCostBreakdown, 2, 0);
            tblCharts.Controls.Add(grpForecastTrend, 0, 1);
            tblCharts.Controls.Add(grpCashFlowCurve, 1, 1);
            tblCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            tblCharts.Name = "tblCharts";
            tblCharts.RowCount = 2;
            tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tblCharts.Size = new System.Drawing.Size(1366, 320);

            // Setup each chart group
            SetupChartGroup(grpBudgetVsActual, "grpBudgetVsActual", "الموازنة مقابل الفعلي",
                chartBudgetVsActual, new DevExpress.XtraCharts.Series[] { seriesBudget, seriesActual });
            SetupChartGroup(grpBudgetDistribution, "grpBudgetDistribution", "توزيع الموازنة",
                chartBudgetDistribution, new DevExpress.XtraCharts.Series[] { seriesBudgetDistribution });
            SetupChartGroup(grpCostBreakdown, "grpCostBreakdown", "توزيع التكلفة",
                chartCostBreakdown, new DevExpress.XtraCharts.Series[] { seriesCostBreakdown });
            SetupChartGroup(grpForecastTrend, "grpForecastTrend", "اتجاه التوقع",
                chartForecastTrend, new DevExpress.XtraCharts.Series[] { seriesForecastTrend });
            SetupChartGroup(grpCashFlowCurve, "grpCashFlowCurve", "منحنى التدفق النقدي",
                chartCashFlowCurve, new DevExpress.XtraCharts.Series[] { seriesCashFlowPlanned, seriesCashFlowActual });

            // ── Operational Grids Tab ─────────────────────────────────────
            tabOperational.Dock = System.Windows.Forms.DockStyle.Fill;
            tabOperational.Location = new System.Drawing.Point(0, 542);
            tabOperational.Name = "tabOperational";
            tabOperational.SelectedTabPage = tabPagePendingRevisions;
            tabOperational.Size = new System.Drawing.Size(1366, 302);
            tabOperational.TabIndex = 4;
            tabOperational.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[]
            {
                tabPagePendingRevisions, tabPagePendingApprovals, tabPageBudgetAlerts, tabPageTopOverBudget, tabPageCostTrend
            });

            // Pending Revisions tab
            SetupOperationalTab(tabPagePendingRevisions, "tabPagePendingRevisions", "مراجعات معلقة", grdPendingRevisions, gvPendingRevisions);
            gvPendingRevisions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colRevCode, colRevBudgetName, colRevDate, colRevAmount, colRevStatus });
            SetupGridColumn(colRevCode, "colRevCode", "كود المراجعة", "RevisionCode", 100);
            SetupGridColumn(colRevBudgetName, "colRevBudgetName", "اسم الموازنة", "BudgetName", 200);
            SetupGridColumn(colRevDate, "colRevDate", "التاريخ", "RevisionDate", 100);
            SetupGridColumn(colRevAmount, "colRevAmount", "المبلغ", "Amount", 120, "N2");
            SetupGridColumn(colRevStatus, "colRevStatus", "الحالة", "Status", 100);

            // Pending Approvals tab
            SetupOperationalTab(tabPagePendingApprovals, "tabPagePendingApprovals", "موافقات معلقة", grdPendingApprovals, gvPendingApprovals);
            gvPendingApprovals.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colAppCode, colAppBudgetName, colAppStep, colAppUser, colAppDate });
            SetupGridColumn(colAppCode, "colAppCode", "الكود", "Code", 100);
            SetupGridColumn(colAppBudgetName, "colAppBudgetName", "اسم الموازنة", "BudgetName", 220);
            SetupGridColumn(colAppStep, "colAppStep", "خطوة الاعتماد", "ApprovalStep", 140);
            SetupGridColumn(colAppUser, "colAppUser", "المستخدم", "User", 140);
            SetupGridColumn(colAppDate, "colAppDate", "التاريخ", "Date", 100);

            // Budget Alerts tab
            SetupOperationalTab(tabPageBudgetAlerts, "tabPageBudgetAlerts", "تنبيهات الموازنة", grdBudgetAlerts, gvBudgetAlerts);
            gvBudgetAlerts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colAlertType, colAlertDescription, colAlertProject, colAlertDate });
            SetupGridColumn(colAlertType, "colAlertType", "نوع التنبيه", "AlertType", 140);
            SetupGridColumn(colAlertDescription, "colAlertDescription", "الوصف", "Description", 320);
            SetupGridColumn(colAlertProject, "colAlertProject", "المشروع", "Project", 160);
            SetupGridColumn(colAlertDate, "colAlertDate", "التاريخ", "Date", 110);

            // Top Over Budget tab
            SetupOperationalTab(tabPageTopOverBudget, "tabPageTopOverBudget", "أعلى تجاوزات الموازنة", grdTopOverBudget, gvTopOverBudget);
            gvTopOverBudget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colOBCostCode, colOBDescription, colOBBudget, colOBActual, colOBVariance, colOBVariancePct });
            SetupGridColumn(colOBCostCode, "colOBCostCode", "كود التكلفة", "CostCode", 120);
            SetupGridColumn(colOBDescription, "colOBDescription", "الوصف", "Description", 260);
            SetupGridColumn(colOBBudget, "colOBBudget", "الموازنة", "Budget", 130, "N2");
            SetupGridColumn(colOBActual, "colOBActual", "الفعلي", "Actual", 130, "N2");
            SetupGridColumn(colOBVariance, "colOBVariance", "الانحراف", "Variance", 130, "N2");
            SetupGridColumn(colOBVariancePct, "colOBVariancePct", "% الانحراف", "VariancePct", 100, "P1");

            // Cost Trend tab
            SetupOperationalTab(tabPageCostTrend, "tabPageCostTrend", "اتجاه التكلفة", grdCostTrend, gvCostTrend);
            gvCostTrend.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colTrendPeriod, colTrendBudget, colTrendActual, colTrendForecast });
            SetupGridColumn(colTrendPeriod, "colTrendPeriod", "الفترة", "Period", 140);
            SetupGridColumn(colTrendBudget, "colTrendBudget", "الموازنة", "Budget", 160, "N2");
            SetupGridColumn(colTrendActual, "colTrendActual", "الفعلي", "Actual", 160, "N2");
            SetupGridColumn(colTrendForecast, "colTrendForecast", "التوقع", "Forecast", 160, "N2");

            // ── State Panels ──────────────────────────────────────────────
            SetupStatePanel(pnlLoadingState, "pnlLoadingState", lblLoadingText, "lblLoadingText", "جاري تحميل لوحة الموازنة...", svgLoadingIcon, "svgLoadingIcon", resources, "svgLoadingIcon.SvgImage");
            SetupStatePanel(pnlEmptyState, "pnlEmptyState", lblEmptyText, "lblEmptyText", "لا توجد بيانات موازنة متاحة", svgEmptyIcon, "svgEmptyIcon", resources, "svgEmptyIcon.SvgImage");
            SetupErrorPanel(pnlErrorState, "pnlErrorState", lblErrorText, "lblErrorText", "حدث خطأ أثناء تحميل لوحة الموازنة", svgErrorIcon, "svgErrorIcon", btnRetry, resources);

            // ── Locked state (blocking) ─────────────────────────────────────
            pnlLockedState.Controls.Add(lblLockedText); pnlLockedState.Controls.Add(svgLockedIcon);
            pnlLockedState.Dock = System.Windows.Forms.DockStyle.Fill; pnlLockedState.Name = "pnlLockedState"; pnlLockedState.Visible = false;
            lblLockedText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblLockedText.Appearance.Options.UseFont = true;
            lblLockedText.Location = new System.Drawing.Point(543, 310); lblLockedText.Name = "lblLockedText"; lblLockedText.Text = "لوحة الموازنة مقفلة حاليًا";
            svgLockedIcon.Location = new System.Drawing.Point(651, 210); svgLockedIcon.Name = "svgLockedIcon"; svgLockedIcon.Size = new System.Drawing.Size(64, 64);
            svgLockedIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");

            // ── ucBudgetDashboard ─────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tabOperational);
            Controls.Add(pnlCharts);
            Controls.Add(pnlFilters);
            Controls.Add(pnlKpiCards);
            Controls.Add(pnlStateBanner);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlLockedState);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            Name = "ucBudgetDashboard";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1366, 902);

            // ── End Init ──────────────────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlStateBanner).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgStateBannerIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit();
            pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiOriginalBudget).EndInit();
            pnlKpiOriginalBudget.ResumeLayout(false);
            pnlKpiOriginalBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiApprovedBudget).EndInit();
            pnlKpiApprovedBudget.ResumeLayout(false);
            pnlKpiApprovedBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCurrentBudget).EndInit();
            pnlKpiCurrentBudget.ResumeLayout(false);
            pnlKpiCurrentBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCommitments).EndInit();
            pnlKpiCommitments.ResumeLayout(false);
            pnlKpiCommitments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActualCost).EndInit();
            pnlKpiActualCost.ResumeLayout(false);
            pnlKpiActualCost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).EndInit();
            pnlKpiForecast.ResumeLayout(false);
            pnlKpiForecast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiVariance).EndInit();
            pnlKpiVariance.ResumeLayout(false);
            pnlKpiVariance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCPI).EndInit();
            pnlKpiCPI.ResumeLayout(false);
            pnlKpiCPI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiSPI).EndInit();
            pnlKpiSPI.ResumeLayout(false);
            pnlKpiSPI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCashFlow).EndInit();
            pnlKpiCashFlow.ResumeLayout(false);
            pnlKpiCashFlow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgKpiOriginalBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiApprovedBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiCurrentBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiCommitments).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiActualCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiVariance).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiCPI).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiSPI).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgKpiCashFlow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFilters).EndInit();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cboCompany.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboBranch.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).EndInit();
            pnlCharts.ResumeLayout(false);
            tblCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpBudgetVsActual).EndInit();
            grpBudgetVsActual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartBudgetVsActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpBudgetDistribution).EndInit();
            grpBudgetDistribution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartBudgetDistribution).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesBudgetDistribution).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpCostBreakdown).EndInit();
            grpCostBreakdown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartCostBreakdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesCostBreakdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpForecastTrend).EndInit();
            grpForecastTrend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartForecastTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesForecastTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpCashFlowCurve).EndInit();
            grpCashFlowCurve.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartCashFlowCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesCashFlowPlanned).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesCashFlowActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabOperational).EndInit();
            tabOperational.ResumeLayout(false);
            tabPagePendingRevisions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdPendingRevisions).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvPendingRevisions).EndInit();
            tabPagePendingApprovals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdPendingApprovals).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvPendingApprovals).EndInit();
            tabPageBudgetAlerts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdBudgetAlerts).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvBudgetAlerts).EndInit();
            tabPageTopOverBudget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdTopOverBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvTopOverBudget).EndInit();
            tabPageCostTrend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdCostTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCostTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit();
            pnlLoadingState.ResumeLayout(false);
            pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit();
            pnlEmptyState.ResumeLayout(false);
            pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit();
            pnlErrorState.ResumeLayout(false);
            pnlErrorState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLockedState).EndInit();
            pnlLockedState.ResumeLayout(false);
            pnlLockedState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgLockedIcon).EndInit();
            ResumeLayout(false);
        }

        // ── Private helper methods ─────────────────────────────────────────
        private static void SetupFilterControl(DevExpress.XtraEditors.LabelControl lbl, string name, string text, System.Drawing.Point loc, System.Drawing.Size size)
        {
            lbl.Appearance.Font = new System.Drawing.Font("Cairo", 8F);
            lbl.Appearance.Options.UseFont = true;
            lbl.Location = loc;
            lbl.Name = name;
            lbl.Size = size;
            lbl.Text = text;
        }

        private static void SetupComboFilter(DevExpress.XtraEditors.ComboBoxEdit cbo, string name, System.Drawing.Point loc, System.Drawing.Size size)
        {
            cbo.Location = loc;
            cbo.Name = name;
            cbo.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            cbo.Properties.Appearance.Options.UseFont = true;
            cbo.Size = size;
        }

        private static void SetupChartGroup(DevExpress.XtraEditors.GroupControl grp, string name, string text,
            DevExpress.XtraCharts.ChartControl chart, DevExpress.XtraCharts.Series[] series)
        {
            grp.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            grp.AppearanceCaption.Options.UseFont = true;
            grp.Controls.Add(chart);
            grp.Dock = System.Windows.Forms.DockStyle.Fill;
            grp.Margin = new System.Windows.Forms.Padding(3);
            grp.Name = name;
            grp.Text = text;
            chart.Dock = System.Windows.Forms.DockStyle.Fill;
            chart.Name = name.Replace("grp", "chart");
            chart.SeriesSerializable = series;
        }

        private static void SetupOperationalTab(DevExpress.XtraTab.XtraTabPage page, string name, string text,
            DevExpress.XtraGrid.GridControl grid, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            page.Appearance.Header.Font = new System.Drawing.Font("Cairo", 9F);
            page.Appearance.Header.Options.UseFont = true;
            page.Controls.Add(grid);
            page.Name = name;
            page.Text = text;

            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.MainView = view;
            grid.Name = name.Replace("tabPage", "grd");
            grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { view });

            view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 8F, System.Drawing.FontStyle.Bold);
            view.Appearance.HeaderPanel.Options.UseFont = true;
            view.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F);
            view.Appearance.Row.Options.UseFont = true;
            view.GridControl = grid;
            view.Name = name.Replace("tabPage", "gv");
            view.OptionsBehavior.Editable = false;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowFooter = true;
        }

        private static void SetupGridColumn(DevExpress.XtraGrid.Columns.GridColumn col, string name, string caption,
            string fieldName, int width, string format = "")
        {
            col.Caption = caption;
            col.FieldName = fieldName;
            col.Name = name;
            col.Visible = true;
            col.Width = width;
            if (!string.IsNullOrEmpty(format))
            {
                col.DisplayFormat.FormatString = format;
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            }
        }

        private static void SetupStatePanel(DevExpress.XtraEditors.PanelControl pnl, string pnlName,
            DevExpress.XtraEditors.LabelControl lbl, string lblName, string lblText,
            DevExpress.XtraEditors.SvgImageBox svg, string svgName,
            System.ComponentModel.ComponentResourceManager res, string resKey)
        {
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(svg);
            pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl.Name = pnlName;
            pnl.Size = new System.Drawing.Size(1366, 540);
            pnl.TabIndex = 99;
            pnl.Visible = false;

            lbl.Appearance.Font = new System.Drawing.Font("Cairo", 10F);
            lbl.Appearance.Options.UseFont = true;
            lbl.Appearance.Options.UseTextOptions = true;
            lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lbl.Location = new System.Drawing.Point(543, 310);
            lbl.Name = lblName;
            lbl.Size = new System.Drawing.Size(280, 26);
            lbl.Text = lblText;

            svg.Location = new System.Drawing.Point(651, 210);
            svg.Name = svgName;
            svg.Size = new System.Drawing.Size(64, 64);
            svg.SvgImage = (DevExpress.Utils.Svg.SvgImage)res.GetObject(resKey);
        }

        private static void SetupErrorPanel(DevExpress.XtraEditors.PanelControl pnl, string pnlName,
            DevExpress.XtraEditors.LabelControl lbl, string lblName, string lblText,
            DevExpress.XtraEditors.SvgImageBox svg, string svgName,
            DevExpress.XtraEditors.SimpleButton btn,
            System.ComponentModel.ComponentResourceManager res)
        {
            pnl.Controls.Add(btn);
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(svg);
            pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl.Name = pnlName;
            pnl.Size = new System.Drawing.Size(1366, 540);
            pnl.TabIndex = 99;
            pnl.Visible = false;

            btn.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            btn.Appearance.Options.UseFont = true;
            btn.Location = new System.Drawing.Point(633, 335);
            btn.Name = "btnRetry";
            btn.Size = new System.Drawing.Size(100, 34);
            btn.Text = "إعادة المحاولة";
            btn.Click += (s, e) => { };

            lbl.Appearance.Font = new System.Drawing.Font("Cairo", 10F);
            lbl.Appearance.Options.UseFont = true;
            lbl.Appearance.Options.UseTextOptions = true;
            lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lbl.Location = new System.Drawing.Point(533, 290);
            lbl.Name = lblName;
            lbl.Size = new System.Drawing.Size(300, 26);
            lbl.Text = lblText;

            svg.Location = new System.Drawing.Point(651, 200);
            svg.Name = svgName;
            svg.Size = new System.Drawing.Size(64, 64);
            svg.SvgImage = (DevExpress.Utils.Svg.SvgImage)res.GetObject("svgErrorIcon.SvgImage");
        }

        #endregion

        // ── Toolbar ──────────────────────────────────────────────────────
        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiExportExcel;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarStaticItem sbiStatus;
        private DevExpress.XtraBars.BarStaticItem sbiLastRefresh;

        // ── State Banner ─────────────────────────────────────────────────
        private DevExpress.XtraEditors.PanelControl pnlStateBanner;
        private DevExpress.XtraEditors.LabelControl lblStateBanner;
        private DevExpress.XtraEditors.SvgImageBox svgStateBannerIcon;

        // ── KPI Cards ────────────────────────────────────────────────────
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.PanelControl pnlKpiOriginalBudget;
        private DevExpress.XtraEditors.LabelControl lblKpiOriginalBudgetValue;
        private DevExpress.XtraEditors.LabelControl lblKpiOriginalBudgetTitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiOriginalBudget;
        private DevExpress.XtraEditors.PanelControl pnlKpiApprovedBudget;
        private DevExpress.XtraEditors.LabelControl lblKpiApprovedBudgetValue;
        private DevExpress.XtraEditors.LabelControl lblKpiApprovedBudgetTitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiApprovedBudget;
        private DevExpress.XtraEditors.PanelControl pnlKpiCurrentBudget;
        private DevExpress.XtraEditors.LabelControl lblKpiCurrentBudgetValue;
        private DevExpress.XtraEditors.LabelControl lblKpiCurrentBudgetTitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiCurrentBudget;
        private DevExpress.XtraEditors.PanelControl pnlKpiCommitments;
        private DevExpress.XtraEditors.LabelControl lblKpiCommitmentsValue;
        private DevExpress.XtraEditors.LabelControl lblKpiCommitmentsTitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiCommitments;
        private DevExpress.XtraEditors.PanelControl pnlKpiActualCost;
        private DevExpress.XtraEditors.LabelControl lblKpiActualCostValue;
        private DevExpress.XtraEditors.LabelControl lblKpiActualCostTitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiActualCost;
        private DevExpress.XtraEditors.PanelControl pnlKpiForecast;
        private DevExpress.XtraEditors.LabelControl lblKpiForecastValue;
        private DevExpress.XtraEditors.LabelControl lblKpiForecastTitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiForecast;
        private DevExpress.XtraEditors.PanelControl pnlKpiVariance;
        private DevExpress.XtraEditors.LabelControl lblKpiVarianceValue;
        private DevExpress.XtraEditors.LabelControl lblKpiVarianceTitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiVariance;
        private DevExpress.XtraEditors.PanelControl pnlKpiCPI;
        private DevExpress.XtraEditors.LabelControl lblKpiCPIValue;
        private DevExpress.XtraEditors.LabelControl lblKpiCPITitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiCPI;
        private DevExpress.XtraEditors.PanelControl pnlKpiSPI;
        private DevExpress.XtraEditors.LabelControl lblKpiSPIValue;
        private DevExpress.XtraEditors.LabelControl lblKpiSPITitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiSPI;
        private DevExpress.XtraEditors.PanelControl pnlKpiCashFlow;
        private DevExpress.XtraEditors.LabelControl lblKpiCashFlowValue;
        private DevExpress.XtraEditors.LabelControl lblKpiCashFlowTitle;
        private DevExpress.XtraEditors.SvgImageBox svgKpiCashFlow;

        // ── Filters ──────────────────────────────────────────────────────
        private DevExpress.XtraEditors.PanelControl pnlFilters;
        private DevExpress.XtraEditors.LabelControl lblCompany;
        private DevExpress.XtraEditors.ComboBoxEdit cboCompany;
        private DevExpress.XtraEditors.LabelControl lblBranch;
        private DevExpress.XtraEditors.ComboBoxEdit cboBranch;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.LookUpEdit lueProject;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraEditors.LabelControl lblDateRange;
        private DevExpress.XtraEditors.DateEdit dtDateFrom;
        private DevExpress.XtraEditors.LabelControl lblDateRangeSeparator;
        private DevExpress.XtraEditors.DateEdit dtDateTo;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnClearFilters;

        // ── Charts ───────────────────────────────────────────────────────
        private DevExpress.XtraEditors.PanelControl pnlCharts;
        private System.Windows.Forms.TableLayoutPanel tblCharts;
        private DevExpress.XtraEditors.GroupControl grpBudgetVsActual;
        private DevExpress.XtraCharts.ChartControl chartBudgetVsActual;
        private DevExpress.XtraCharts.Series seriesBudget;
        private DevExpress.XtraCharts.Series seriesActual;
        private DevExpress.XtraEditors.GroupControl grpBudgetDistribution;
        private DevExpress.XtraCharts.ChartControl chartBudgetDistribution;
        private DevExpress.XtraCharts.Series seriesBudgetDistribution;
        private DevExpress.XtraEditors.GroupControl grpCostBreakdown;
        private DevExpress.XtraCharts.ChartControl chartCostBreakdown;
        private DevExpress.XtraCharts.Series seriesCostBreakdown;
        private DevExpress.XtraEditors.GroupControl grpForecastTrend;
        private DevExpress.XtraCharts.ChartControl chartForecastTrend;
        private DevExpress.XtraCharts.Series seriesForecastTrend;
        private DevExpress.XtraEditors.GroupControl grpCashFlowCurve;
        private DevExpress.XtraCharts.ChartControl chartCashFlowCurve;
        private DevExpress.XtraCharts.Series seriesCashFlowPlanned;
        private DevExpress.XtraCharts.Series seriesCashFlowActual;

        // ── Operational Grids ────────────────────────────────────────────
        private DevExpress.XtraTab.XtraTabControl tabOperational;
        private DevExpress.XtraTab.XtraTabPage tabPagePendingRevisions;
        private DevExpress.XtraGrid.GridControl grdPendingRevisions;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPendingRevisions;
        private DevExpress.XtraGrid.Columns.GridColumn colRevCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRevBudgetName;
        private DevExpress.XtraGrid.Columns.GridColumn colRevDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRevAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRevStatus;
        private DevExpress.XtraTab.XtraTabPage tabPagePendingApprovals;
        private DevExpress.XtraGrid.GridControl grdPendingApprovals;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPendingApprovals;
        private DevExpress.XtraGrid.Columns.GridColumn colAppCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAppBudgetName;
        private DevExpress.XtraGrid.Columns.GridColumn colAppStep;
        private DevExpress.XtraGrid.Columns.GridColumn colAppUser;
        private DevExpress.XtraGrid.Columns.GridColumn colAppDate;
        private DevExpress.XtraTab.XtraTabPage tabPageBudgetAlerts;
        private DevExpress.XtraGrid.GridControl grdBudgetAlerts;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBudgetAlerts;
        private DevExpress.XtraGrid.Columns.GridColumn colAlertType;
        private DevExpress.XtraGrid.Columns.GridColumn colAlertDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAlertProject;
        private DevExpress.XtraGrid.Columns.GridColumn colAlertDate;
        private DevExpress.XtraTab.XtraTabPage tabPageTopOverBudget;
        private DevExpress.XtraGrid.GridControl grdTopOverBudget;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTopOverBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colOBCostCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOBDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOBBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colOBActual;
        private DevExpress.XtraGrid.Columns.GridColumn colOBVariance;
        private DevExpress.XtraGrid.Columns.GridColumn colOBVariancePct;
        private DevExpress.XtraTab.XtraTabPage tabPageCostTrend;
        private DevExpress.XtraGrid.GridControl grdCostTrend;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCostTrend;
        private DevExpress.XtraGrid.Columns.GridColumn colTrendPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colTrendBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colTrendActual;
        private DevExpress.XtraGrid.Columns.GridColumn colTrendForecast;

        // ── States ───────────────────────────────────────────────────────
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
        private DevExpress.XtraEditors.PanelControl pnlLockedState;
        private DevExpress.XtraEditors.SvgImageBox svgLockedIcon;
        private DevExpress.XtraEditors.LabelControl lblLockedText;
    }
}


