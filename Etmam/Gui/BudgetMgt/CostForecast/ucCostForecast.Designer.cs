namespace Etmam
{
    partial class ucCostForecast
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCostForecast));
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            // EVM KPI cards
            pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            pnlBudgetAtCompletion = new DevExpress.XtraEditors.PanelControl(); lblBACValue = new DevExpress.XtraEditors.LabelControl(); lblBACTitle = new DevExpress.XtraEditors.LabelControl();
            pnlEstimateAtCompletion = new DevExpress.XtraEditors.PanelControl(); lblEACValue = new DevExpress.XtraEditors.LabelControl(); lblEACTitle = new DevExpress.XtraEditors.LabelControl();
            pnlEstimateToComplete = new DevExpress.XtraEditors.PanelControl(); lblETCValue = new DevExpress.XtraEditors.LabelControl(); lblETCTitle = new DevExpress.XtraEditors.LabelControl();
            pnlVarianceAtCompletion = new DevExpress.XtraEditors.PanelControl(); lblVACValue = new DevExpress.XtraEditors.LabelControl(); lblVACTitle = new DevExpress.XtraEditors.LabelControl();
            pnlCostPerformanceIndex = new DevExpress.XtraEditors.PanelControl(); lblCPIValue = new DevExpress.XtraEditors.LabelControl(); lblCPITitle = new DevExpress.XtraEditors.LabelControl();
            pnlSchedulePerformanceIndex = new DevExpress.XtraEditors.PanelControl(); lblSPIValue = new DevExpress.XtraEditors.LabelControl(); lblSPITitle = new DevExpress.XtraEditors.LabelControl();
            // Charts
            pnlCharts = new DevExpress.XtraEditors.PanelControl();
            tblCharts = new System.Windows.Forms.TableLayoutPanel();
            grpEVMChart = new DevExpress.XtraEditors.GroupControl(); chartEVM = new DevExpress.XtraCharts.ChartControl();
            seriesPV = new DevExpress.XtraCharts.Series("القيمة المخططة (PV)", DevExpress.XtraCharts.ViewType.Line);
            seriesEV = new DevExpress.XtraCharts.Series("القيمة المكتسبة (EV)", DevExpress.XtraCharts.ViewType.Line);
            seriesAC = new DevExpress.XtraCharts.Series("التكلفة الفعلية (AC)", DevExpress.XtraCharts.ViewType.Line);
            seriesEAC = new DevExpress.XtraCharts.Series("التوقع عند الاكتمال (EAC)", DevExpress.XtraCharts.ViewType.Spline);
            grpCPIChart = new DevExpress.XtraEditors.GroupControl(); chartCPI = new DevExpress.XtraCharts.ChartControl();
            seriesCPILine = new DevExpress.XtraCharts.Series("مؤشر أداء التكلفة (CPI)", DevExpress.XtraCharts.ViewType.Line);
            seriesSPILine = new DevExpress.XtraCharts.Series("مؤشر أداء الجدول (SPI)", DevExpress.XtraCharts.ViewType.Line);
            // Grid (BandedGridView)
            grdCostForecast = new DevExpress.XtraGrid.GridControl();
            gvCostForecast = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            bandID = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            bandEVM = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            bandForecast = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            colCFCostCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCFDesc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCFBAC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCFEV = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCFAC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCFCPI = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCFEAC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCFETC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCFVAC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            // States
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl(); lblLoadingText = new DevExpress.XtraEditors.LabelControl(); svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl(); lblEmptyText = new DevExpress.XtraEditors.LabelControl(); svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl(); btnRetry = new DevExpress.XtraEditors.SimpleButton(); lblErrorText = new DevExpress.XtraEditors.LabelControl(); svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)barManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit(); pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlBudgetAtCompletion).BeginInit(); pnlBudgetAtCompletion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEstimateAtCompletion).BeginInit(); pnlEstimateAtCompletion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEstimateToComplete).BeginInit(); pnlEstimateToComplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlVarianceAtCompletion).BeginInit(); pnlVarianceAtCompletion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCostPerformanceIndex).BeginInit(); pnlCostPerformanceIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSchedulePerformanceIndex).BeginInit(); pnlSchedulePerformanceIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).BeginInit(); pnlCharts.SuspendLayout();
            tblCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpEVMChart).BeginInit(); grpEVMChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpCPIChart).BeginInit(); grpCPIChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartEVM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCPI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesPV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesEV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesAC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesEAC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesCPILine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesSPILine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdCostForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCostForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit(); pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit(); pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit(); pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain });
            
            barManagerMain.Form = this; barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiRefresh, bbiExportExcel, bbiPrint });
            barManagerMain.MainMenu = barMain; barManagerMain.MaxItemId = 3; barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barMain.BarName = "شريط أدوات توقع التكلفة"; barMain.DockCol = 0; barMain.DockRow = 0; barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
            });
            barMain.OptionsBar.AllowQuickCustomization = false; barMain.OptionsBar.DrawDragBorder = false; barMain.OptionsBar.MinHeight = 34; barMain.OptionsBar.UseWholeRow = true; barMain.Text = "شريط أدوات توقع التكلفة";
            bbiRefresh.Caption = "تحديث"; bbiRefresh.Id = 0; bbiRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiRefresh.ImageOptions.SvgImage"); bbiRefresh.Name = "bbiRefresh"; bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            bbiExportExcel.Caption = "تصدير Excel"; bbiExportExcel.Id = 1; bbiExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExportExcel.ImageOptions.SvgImage"); bbiExportExcel.Name = "bbiExportExcel"; bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            bbiPrint.Caption = "طباعة"; bbiPrint.Id = 2; bbiPrint.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiPrint.ImageOptions.SvgImage"); bbiPrint.Name = "bbiPrint"; bbiPrint.ItemClick += bbiPrint_ItemClick;
            barDockControlTop.CausesValidation = false; barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top; barDockControlTop.Location = new System.Drawing.Point(0, 0); barDockControlTop.Manager = barManagerMain; barDockControlTop.Size = new System.Drawing.Size(1366, 34);
            barDockControlBottom.CausesValidation = false; barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom; barDockControlBottom.Location = new System.Drawing.Point(0, 902); barDockControlBottom.Manager = barManagerMain; barDockControlBottom.Size = new System.Drawing.Size(1366, 0);
            barDockControlLeft.CausesValidation = false; barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left; barDockControlLeft.Location = new System.Drawing.Point(0, 34); barDockControlLeft.Manager = barManagerMain; barDockControlLeft.Size = new System.Drawing.Size(0, 868);
            barDockControlRight.CausesValidation = false; barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right; barDockControlRight.Location = new System.Drawing.Point(1366, 34); barDockControlRight.Manager = barManagerMain; barDockControlRight.Size = new System.Drawing.Size(0, 868);

            // KPI Cards — EVM Metrics
            pnlKpiCards.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCards.Controls.AddRange(new System.Windows.Forms.Control[] { pnlBudgetAtCompletion, pnlEstimateAtCompletion, pnlEstimateToComplete, pnlVarianceAtCompletion, pnlCostPerformanceIndex, pnlSchedulePerformanceIndex });
            pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top; pnlKpiCards.Location = new System.Drawing.Point(0, 34); pnlKpiCards.Name = "pnlKpiCards"; pnlKpiCards.Size = new System.Drawing.Size(1366, 100);
            pnlBudgetAtCompletion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlBudgetAtCompletion.Controls.Add(lblBACTitle); pnlBudgetAtCompletion.Controls.Add(lblBACValue);
            pnlBudgetAtCompletion.Location = new System.Drawing.Point(1133, 8); pnlBudgetAtCompletion.Name = "pnlBudgetAtCompletion"; pnlBudgetAtCompletion.Size = new System.Drawing.Size(215, 84);
            lblBACTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F); lblBACTitle.Appearance.Options.UseFont = true;
            lblBACTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblBACTitle.Appearance.Options.UseForeColor = true;
            lblBACTitle.Location = new System.Drawing.Point(8, 10); lblBACTitle.Name = "lblBACTitle"; lblBACTitle.Text = "الموازنة عند الاكتمال (BAC)";
            lblBACValue.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold); lblBACValue.Appearance.Options.UseFont = true;
            lblBACValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 117, 182); lblBACValue.Appearance.Options.UseForeColor = true;
            lblBACValue.Location = new System.Drawing.Point(8, 38); lblBACValue.Name = "lblBACValue"; lblBACValue.Text = "—";

            pnlEstimateAtCompletion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlEstimateAtCompletion.Controls.Add(lblEACTitle); pnlEstimateAtCompletion.Controls.Add(lblEACValue);
            pnlEstimateAtCompletion.Location = new System.Drawing.Point(908, 8); pnlEstimateAtCompletion.Name = "pnlEstimateAtCompletion"; pnlEstimateAtCompletion.Size = new System.Drawing.Size(215, 84);
            lblEACTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F); lblEACTitle.Appearance.Options.UseFont = true;
            lblEACTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblEACTitle.Appearance.Options.UseForeColor = true;
            lblEACTitle.Location = new System.Drawing.Point(8, 10); lblEACTitle.Name = "lblEACTitle"; lblEACTitle.Text = "التكلفة المتوقعة (EAC)";
            lblEACValue.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold); lblEACValue.Appearance.Options.UseFont = true;
            lblEACValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(255, 127, 14); lblEACValue.Appearance.Options.UseForeColor = true;
            lblEACValue.Location = new System.Drawing.Point(8, 38); lblEACValue.Name = "lblEACValue"; lblEACValue.Text = "—";

            pnlEstimateToComplete.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlEstimateToComplete.Controls.Add(lblETCTitle); pnlEstimateToComplete.Controls.Add(lblETCValue);
            pnlEstimateToComplete.Location = new System.Drawing.Point(683, 8); pnlEstimateToComplete.Name = "pnlEstimateToComplete"; pnlEstimateToComplete.Size = new System.Drawing.Size(215, 84);
            lblETCTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F); lblETCTitle.Appearance.Options.UseFont = true;
            lblETCTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblETCTitle.Appearance.Options.UseForeColor = true;
            lblETCTitle.Location = new System.Drawing.Point(8, 10); lblETCTitle.Name = "lblETCTitle"; lblETCTitle.Text = "الباقي للإتمام (ETC)";
            lblETCValue.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold); lblETCValue.Appearance.Options.UseFont = true;
            lblETCValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 158, 91); lblETCValue.Appearance.Options.UseForeColor = true;
            lblETCValue.Location = new System.Drawing.Point(8, 38); lblETCValue.Name = "lblETCValue"; lblETCValue.Text = "—";

            pnlVarianceAtCompletion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlVarianceAtCompletion.Controls.Add(lblVACTitle); pnlVarianceAtCompletion.Controls.Add(lblVACValue);
            pnlVarianceAtCompletion.Location = new System.Drawing.Point(458, 8); pnlVarianceAtCompletion.Name = "pnlVarianceAtCompletion"; pnlVarianceAtCompletion.Size = new System.Drawing.Size(215, 84);
            lblVACTitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F); lblVACTitle.Appearance.Options.UseFont = true;
            lblVACTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblVACTitle.Appearance.Options.UseForeColor = true;
            lblVACTitle.Location = new System.Drawing.Point(8, 10); lblVACTitle.Name = "lblVACTitle"; lblVACTitle.Text = "الانحراف عند الاكتمال (VAC)";
            lblVACValue.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold); lblVACValue.Appearance.Options.UseFont = true;
            lblVACValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(192, 80, 77); lblVACValue.Appearance.Options.UseForeColor = true;
            lblVACValue.Location = new System.Drawing.Point(8, 38); lblVACValue.Name = "lblVACValue"; lblVACValue.Text = "—";

            pnlCostPerformanceIndex.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlCostPerformanceIndex.Controls.Add(lblCPITitle); pnlCostPerformanceIndex.Controls.Add(lblCPIValue);
            pnlCostPerformanceIndex.Location = new System.Drawing.Point(233, 8); pnlCostPerformanceIndex.Name = "pnlCostPerformanceIndex"; pnlCostPerformanceIndex.Size = new System.Drawing.Size(215, 84);
            lblCPITitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F); lblCPITitle.Appearance.Options.UseFont = true;
            lblCPITitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblCPITitle.Appearance.Options.UseForeColor = true;
            lblCPITitle.Location = new System.Drawing.Point(8, 10); lblCPITitle.Name = "lblCPITitle"; lblCPITitle.Text = "مؤشر أداء التكلفة (CPI)";
            lblCPIValue.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold); lblCPIValue.Appearance.Options.UseFont = true;
            lblCPIValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(148, 103, 189); lblCPIValue.Appearance.Options.UseForeColor = true;
            lblCPIValue.Location = new System.Drawing.Point(8, 38); lblCPIValue.Name = "lblCPIValue"; lblCPIValue.Text = "—";

            pnlSchedulePerformanceIndex.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlSchedulePerformanceIndex.Controls.Add(lblSPITitle); pnlSchedulePerformanceIndex.Controls.Add(lblSPIValue);
            pnlSchedulePerformanceIndex.Location = new System.Drawing.Point(8, 8); pnlSchedulePerformanceIndex.Name = "pnlSchedulePerformanceIndex"; pnlSchedulePerformanceIndex.Size = new System.Drawing.Size(215, 84);
            lblSPITitle.Appearance.Font = new System.Drawing.Font("Cairo", 7.5F); lblSPITitle.Appearance.Options.UseFont = true;
            lblSPITitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblSPITitle.Appearance.Options.UseForeColor = true;
            lblSPITitle.Location = new System.Drawing.Point(8, 10); lblSPITitle.Name = "lblSPITitle"; lblSPITitle.Text = "مؤشر أداء الجدول (SPI)";
            lblSPIValue.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold); lblSPIValue.Appearance.Options.UseFont = true;
            lblSPIValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(28, 140, 140); lblSPIValue.Appearance.Options.UseForeColor = true;
            lblSPIValue.Location = new System.Drawing.Point(8, 38); lblSPIValue.Name = "lblSPIValue"; lblSPIValue.Text = "—";

            // Charts
            pnlCharts.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCharts.Controls.Add(tblCharts); pnlCharts.Dock = System.Windows.Forms.DockStyle.Top; pnlCharts.Location = new System.Drawing.Point(0, 134); pnlCharts.Name = "pnlCharts"; pnlCharts.Size = new System.Drawing.Size(1366, 280);
            tblCharts.ColumnCount = 2; tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F)); tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            tblCharts.Controls.Add(grpEVMChart, 0, 0); tblCharts.Controls.Add(grpCPIChart, 1, 0);
            tblCharts.Dock = System.Windows.Forms.DockStyle.Fill; tblCharts.Name = "tblCharts"; tblCharts.RowCount = 1; tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            grpEVMChart.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpEVMChart.AppearanceCaption.Options.UseFont = true;
            grpEVMChart.Controls.Add(chartEVM); grpEVMChart.Dock = System.Windows.Forms.DockStyle.Fill; grpEVMChart.Margin = new System.Windows.Forms.Padding(3); grpEVMChart.Name = "grpEVMChart"; grpEVMChart.Text = "تحليل القيمة المكتسبة (EVM)";
            chartEVM.Dock = System.Windows.Forms.DockStyle.Fill; chartEVM.Name = "chartEVM"; chartEVM.SeriesSerializable = new DevExpress.XtraCharts.Series[] { seriesPV, seriesEV, seriesAC, seriesEAC };
            grpCPIChart.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpCPIChart.AppearanceCaption.Options.UseFont = true;
            grpCPIChart.Controls.Add(chartCPI); grpCPIChart.Dock = System.Windows.Forms.DockStyle.Fill; grpCPIChart.Margin = new System.Windows.Forms.Padding(3); grpCPIChart.Name = "grpCPIChart"; grpCPIChart.Text = "مؤشرات الأداء (CPI & SPI)";
            chartCPI.Dock = System.Windows.Forms.DockStyle.Fill; chartCPI.Name = "chartCPI"; chartCPI.SeriesSerializable = new DevExpress.XtraCharts.Series[] { seriesCPILine, seriesSPILine };

            // BandedGrid
            grdCostForecast.Dock = System.Windows.Forms.DockStyle.Fill; grdCostForecast.MainView = gvCostForecast; grdCostForecast.Name = "grdCostForecast"; grdCostForecast.MenuManager = barManagerMain;
            grdCostForecast.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCostForecast });
            gvCostForecast.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F); gvCostForecast.Appearance.Row.Options.UseFont = true;
            gvCostForecast.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { bandID, bandEVM, bandForecast });
            gvCostForecast.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCFCostCode, colCFDesc, colCFBAC, colCFEV, colCFAC, colCFCPI, colCFEAC, colCFETC, colCFVAC });
            gvCostForecast.GridControl = grdCostForecast; gvCostForecast.Name = "gvCostForecast"; gvCostForecast.OptionsBehavior.Editable = false;
            gvCostForecast.OptionsView.ShowAutoFilterRow = true; gvCostForecast.OptionsView.ShowFooter = true;
            bandID.Caption = "التعريف"; bandID.Columns.Add(colCFCostCode); bandID.Columns.Add(colCFDesc); bandID.Name = "bandID"; bandID.VisibleIndex = 0; bandID.Width = 330;
            bandEVM.Caption = "مقاييس القيمة المكتسبة"; bandEVM.Columns.Add(colCFBAC); bandEVM.Columns.Add(colCFEV); bandEVM.Columns.Add(colCFAC); bandEVM.Columns.Add(colCFCPI); bandEVM.Name = "bandEVM"; bandEVM.VisibleIndex = 1; bandEVM.Width = 510;
            bandForecast.Caption = "التوقعات"; bandForecast.Columns.Add(colCFEAC); bandForecast.Columns.Add(colCFETC); bandForecast.Columns.Add(colCFVAC); bandForecast.Name = "bandForecast"; bandForecast.VisibleIndex = 2; bandForecast.Width = 390;
            colCFCostCode.Caption = "الكود"; colCFCostCode.FieldName = "CostCode"; colCFCostCode.Name = "colCFCostCode"; colCFCostCode.Visible = true; colCFCostCode.Width = 110; colCFCostCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colCFDesc.Caption = "الوصف"; colCFDesc.FieldName = "Description"; colCFDesc.Name = "colCFDesc"; colCFDesc.Visible = true; colCFDesc.Width = 220;
            colCFBAC.Caption = "BAC"; colCFBAC.FieldName = "BAC"; colCFBAC.Name = "colCFBAC"; colCFBAC.Visible = true; colCFBAC.Width = 120; colCFBAC.DisplayFormat.FormatString = "N2"; colCFBAC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFEV.Caption = "EV"; colCFEV.FieldName = "EV"; colCFEV.Name = "colCFEV"; colCFEV.Visible = true; colCFEV.Width = 120; colCFEV.DisplayFormat.FormatString = "N2"; colCFEV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFAC.Caption = "AC"; colCFAC.FieldName = "AC"; colCFAC.Name = "colCFAC"; colCFAC.Visible = true; colCFAC.Width = 120; colCFAC.DisplayFormat.FormatString = "N2"; colCFAC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFEAC.Caption = "EAC"; colCFEAC.FieldName = "EAC"; colCFEAC.Name = "colCFEAC"; colCFEAC.Visible = true; colCFEAC.Width = 130; colCFEAC.DisplayFormat.FormatString = "N2"; colCFEAC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFETC.Caption = "ETC"; colCFETC.FieldName = "ETC"; colCFETC.Name = "colCFETC"; colCFETC.Visible = true; colCFETC.Width = 130; colCFETC.DisplayFormat.FormatString = "N2"; colCFETC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFVAC.Caption = "VAC"; colCFVAC.FieldName = "VAC"; colCFVAC.Name = "colCFVAC"; colCFVAC.Visible = true; colCFVAC.Width = 130; colCFVAC.DisplayFormat.FormatString = "N2"; colCFVAC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCFCPI.Caption = "CPI"; colCFCPI.FieldName = "CPI"; colCFCPI.Name = "colCFCPI"; colCFCPI.Visible = true; colCFCPI.Width = 80; colCFCPI.DisplayFormat.FormatString = "F2"; colCFCPI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            // States
            pnlLoadingState.Controls.Add(lblLoadingText); pnlLoadingState.Controls.Add(svgLoadingIcon); pnlLoadingState.Dock = System.Windows.Forms.DockStyle.Fill; pnlLoadingState.Name = "pnlLoadingState"; pnlLoadingState.Visible = false;
            lblLoadingText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblLoadingText.Appearance.Options.UseFont = true; lblLoadingText.Location = new System.Drawing.Point(543, 310); lblLoadingText.Name = "lblLoadingText"; lblLoadingText.Text = "جاري تحميل بيانات توقع التكلفة...";
            svgLoadingIcon.Location = new System.Drawing.Point(651, 210); svgLoadingIcon.Name = "svgLoadingIcon"; svgLoadingIcon.Size = new System.Drawing.Size(64, 64); svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            pnlEmptyState.Controls.Add(lblEmptyText); pnlEmptyState.Controls.Add(svgEmptyIcon); pnlEmptyState.Dock = System.Windows.Forms.DockStyle.Fill; pnlEmptyState.Name = "pnlEmptyState"; pnlEmptyState.Visible = false;
            lblEmptyText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblEmptyText.Appearance.Options.UseFont = true; lblEmptyText.Location = new System.Drawing.Point(543, 310); lblEmptyText.Name = "lblEmptyText"; lblEmptyText.Text = "لا توجد بيانات توقع تكلفة";
            svgEmptyIcon.Location = new System.Drawing.Point(651, 210); svgEmptyIcon.Name = "svgEmptyIcon"; svgEmptyIcon.Size = new System.Drawing.Size(64, 64); svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            pnlErrorState.Controls.Add(btnRetry); pnlErrorState.Controls.Add(lblErrorText); pnlErrorState.Controls.Add(svgErrorIcon); pnlErrorState.Dock = System.Windows.Forms.DockStyle.Fill; pnlErrorState.Name = "pnlErrorState"; pnlErrorState.Visible = false;
            lblErrorText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblErrorText.Appearance.Options.UseFont = true; lblErrorText.Location = new System.Drawing.Point(543, 290); lblErrorText.Name = "lblErrorText"; lblErrorText.Text = "حدث خطأ أثناء تحميل بيانات EVM";
            svgErrorIcon.Location = new System.Drawing.Point(651, 190); svgErrorIcon.Name = "svgErrorIcon"; svgErrorIcon.Size = new System.Drawing.Size(64, 64); svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            btnRetry.Appearance.Font = new System.Drawing.Font("Cairo", 9F); btnRetry.Appearance.Options.UseFont = true; btnRetry.Location = new System.Drawing.Point(633, 330); btnRetry.Name = "btnRetry"; btnRetry.Size = new System.Drawing.Size(100, 34); btnRetry.Text = "إعادة المحاولة"; btnRetry.Click += btnRetry_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F); AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(grdCostForecast); Controls.Add(pnlCharts); Controls.Add(pnlLoadingState); Controls.Add(pnlEmptyState); Controls.Add(pnlErrorState);
            Controls.Add(pnlKpiCards); Controls.Add(barDockControlLeft); Controls.Add(barDockControlRight); Controls.Add(barDockControlBottom); Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5); Name = "ucCostForecast"; RightToLeft = System.Windows.Forms.RightToLeft.Yes; Size = new System.Drawing.Size(1366, 902);

            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit(); pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlBudgetAtCompletion).EndInit(); pnlBudgetAtCompletion.ResumeLayout(false); pnlBudgetAtCompletion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEstimateAtCompletion).EndInit(); pnlEstimateAtCompletion.ResumeLayout(false); pnlEstimateAtCompletion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEstimateToComplete).EndInit(); pnlEstimateToComplete.ResumeLayout(false); pnlEstimateToComplete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlVarianceAtCompletion).EndInit(); pnlVarianceAtCompletion.ResumeLayout(false); pnlVarianceAtCompletion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCostPerformanceIndex).EndInit(); pnlCostPerformanceIndex.ResumeLayout(false); pnlCostPerformanceIndex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSchedulePerformanceIndex).EndInit(); pnlSchedulePerformanceIndex.ResumeLayout(false); pnlSchedulePerformanceIndex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).EndInit(); pnlCharts.ResumeLayout(false);
            tblCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpEVMChart).EndInit(); grpEVMChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpCPIChart).EndInit(); grpCPIChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartEVM).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCPI).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesPV).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesEV).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesAC).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesEAC).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesCPILine).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesSPILine).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdCostForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCostForecast).EndInit();
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
        private DevExpress.XtraEditors.PanelControl pnlBudgetAtCompletion, pnlEstimateAtCompletion, pnlEstimateToComplete, pnlVarianceAtCompletion, pnlCostPerformanceIndex, pnlSchedulePerformanceIndex;
        private DevExpress.XtraEditors.LabelControl lblBACValue, lblBACTitle, lblEACValue, lblEACTitle, lblETCValue, lblETCTitle;
        private DevExpress.XtraEditors.LabelControl lblVACValue, lblVACTitle, lblCPIValue, lblCPITitle, lblSPIValue, lblSPITitle;
        private DevExpress.XtraEditors.PanelControl pnlCharts;
        private System.Windows.Forms.TableLayoutPanel tblCharts;
        private DevExpress.XtraEditors.GroupControl grpEVMChart, grpCPIChart;
        private DevExpress.XtraCharts.ChartControl chartEVM, chartCPI;
        private DevExpress.XtraCharts.Series seriesPV, seriesEV, seriesAC, seriesEAC, seriesCPILine, seriesSPILine;
        private DevExpress.XtraGrid.GridControl grdCostForecast;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvCostForecast;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandID, bandEVM, bandForecast;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCFCostCode, colCFDesc, colCFBAC, colCFEV, colCFAC, colCFCPI, colCFEAC, colCFETC, colCFVAC;
        private DevExpress.XtraEditors.PanelControl pnlLoadingState, pnlEmptyState, pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon, svgEmptyIcon, svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText, lblEmptyText, lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}

