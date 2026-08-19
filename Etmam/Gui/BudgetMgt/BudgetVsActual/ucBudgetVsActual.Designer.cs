namespace Etmam
{
    partial class ucBudgetVsActual
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBudgetVsActual));
            DevExpress.XtraGrid.GridFormatRule ruleOver = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue fcrOver = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule ruleUnder = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue fcrUnder = new DevExpress.XtraEditors.FormatConditionRuleValue();
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiFilter = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            pnlKpiBudget = new DevExpress.XtraEditors.PanelControl(); lblKpiBudgetValue = new DevExpress.XtraEditors.LabelControl(); lblKpiBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiActual = new DevExpress.XtraEditors.PanelControl(); lblKpiActualValue = new DevExpress.XtraEditors.LabelControl(); lblKpiActualTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiCommitment = new DevExpress.XtraEditors.PanelControl(); lblKpiCommitmentValue = new DevExpress.XtraEditors.LabelControl(); lblKpiCommitmentTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiForecast = new DevExpress.XtraEditors.PanelControl(); lblKpiForecastValue = new DevExpress.XtraEditors.LabelControl(); lblKpiForecastTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiVariance = new DevExpress.XtraEditors.PanelControl(); lblKpiVarianceValue = new DevExpress.XtraEditors.LabelControl(); lblKpiVarianceTitle = new DevExpress.XtraEditors.LabelControl();
            pnlCharts = new DevExpress.XtraEditors.PanelControl();
            tblCharts = new System.Windows.Forms.TableLayoutPanel();
            grpVarianceChart = new DevExpress.XtraEditors.GroupControl(); chartVariance = new DevExpress.XtraCharts.ChartControl();
            seriesVariance = new DevExpress.XtraCharts.Series("الانحراف", DevExpress.XtraCharts.ViewType.Bar);
            grpTrendChart = new DevExpress.XtraEditors.GroupControl(); chartTrend = new DevExpress.XtraCharts.ChartControl();
            seriesTrendBudget = new DevExpress.XtraCharts.Series("الموازنة", DevExpress.XtraCharts.ViewType.Spline);
            seriesTrendActual = new DevExpress.XtraCharts.Series("الفعلي", DevExpress.XtraCharts.ViewType.Spline);
            grpDistChart = new DevExpress.XtraEditors.GroupControl(); chartDistribution = new DevExpress.XtraCharts.ChartControl();
            seriesDistribution = new DevExpress.XtraCharts.Series("توزيع التكلفة", DevExpress.XtraCharts.ViewType.Pie);
            grdBudgetVsActual = new DevExpress.XtraGrid.GridControl();
            gvBudgetVsActual = new DevExpress.XtraGrid.Views.Grid.GridView();
            colBVACostCode = new DevExpress.XtraGrid.Columns.GridColumn(); colBVADescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colBVABudget = new DevExpress.XtraGrid.Columns.GridColumn(); colBVACommitted = new DevExpress.XtraGrid.Columns.GridColumn();
            colBVAActual = new DevExpress.XtraGrid.Columns.GridColumn(); colBVAForecast = new DevExpress.XtraGrid.Columns.GridColumn();
            colBVAVariance = new DevExpress.XtraGrid.Columns.GridColumn(); colBVAVariancePct = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl(); lblLoadingText = new DevExpress.XtraEditors.LabelControl(); svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl(); lblEmptyText = new DevExpress.XtraEditors.LabelControl(); svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl(); btnRetry = new DevExpress.XtraEditors.SimpleButton(); lblErrorText = new DevExpress.XtraEditors.LabelControl(); svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)barManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit(); pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiBudget).BeginInit(); pnlKpiBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActual).BeginInit(); pnlKpiActual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCommitment).BeginInit(); pnlKpiCommitment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).BeginInit(); pnlKpiForecast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiVariance).BeginInit(); pnlKpiVariance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).BeginInit(); pnlCharts.SuspendLayout();
            tblCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpVarianceChart).BeginInit(); grpVarianceChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpTrendChart).BeginInit(); grpTrendChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpDistChart).BeginInit(); grpDistChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartVariance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartDistribution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesVariance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesTrendBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesTrendActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesDistribution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdBudgetVsActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvBudgetVsActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit(); pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit(); pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit(); pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain });
            
            barManagerMain.Form = this; barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiFilter, bbiExportExcel, bbiPrint, bbiRefresh });
            barManagerMain.MainMenu = barMain; barManagerMain.MaxItemId = 4; barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barMain.BarName = "شريط أدوات الموازنة مقابل الفعلي"; barMain.DockCol = 0; barMain.DockRow = 0; barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiFilter, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
            });
            barMain.OptionsBar.AllowQuickCustomization = false; barMain.OptionsBar.DrawDragBorder = false; barMain.OptionsBar.MinHeight = 34; barMain.OptionsBar.UseWholeRow = true; barMain.Text = "شريط أدوات الموازنة مقابل الفعلي";
            bbiFilter.Caption = "تصفية"; bbiFilter.Id = 0; bbiFilter.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSaveFilter.ImageOptions.SvgImage"); bbiFilter.Name = "bbiFilter"; bbiFilter.ItemClick += bbiFilter_ItemClick;
            bbiExportExcel.Caption = "تصدير Excel"; bbiExportExcel.Id = 1; bbiExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExportExcel.ImageOptions.SvgImage"); bbiExportExcel.Name = "bbiExportExcel"; bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            bbiPrint.Caption = "طباعة"; bbiPrint.Id = 2; bbiPrint.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiPrint.ImageOptions.SvgImage"); bbiPrint.Name = "bbiPrint"; bbiPrint.ItemClick += bbiPrint_ItemClick;
            bbiRefresh.Caption = "تحديث"; bbiRefresh.Id = 3; bbiRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiRefresh.ImageOptions.SvgImage"); bbiRefresh.Name = "bbiRefresh"; bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            barDockControlTop.CausesValidation = false; barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top; barDockControlTop.Location = new System.Drawing.Point(0, 0); barDockControlTop.Manager = barManagerMain; barDockControlTop.Size = new System.Drawing.Size(1366, 34);
            barDockControlBottom.CausesValidation = false; barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom; barDockControlBottom.Location = new System.Drawing.Point(0, 902); barDockControlBottom.Manager = barManagerMain; barDockControlBottom.Size = new System.Drawing.Size(1366, 0);
            barDockControlLeft.CausesValidation = false; barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left; barDockControlLeft.Location = new System.Drawing.Point(0, 34); barDockControlLeft.Manager = barManagerMain; barDockControlLeft.Size = new System.Drawing.Size(0, 868);
            barDockControlRight.CausesValidation = false; barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right; barDockControlRight.Location = new System.Drawing.Point(1366, 34); barDockControlRight.Manager = barManagerMain; barDockControlRight.Size = new System.Drawing.Size(0, 868);

            // KPI Cards
            pnlKpiCards.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCards.Controls.AddRange(new System.Windows.Forms.Control[] { pnlKpiBudget, pnlKpiActual, pnlKpiCommitment, pnlKpiForecast, pnlKpiVariance });
            pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top; pnlKpiCards.Location = new System.Drawing.Point(0, 34); pnlKpiCards.Name = "pnlKpiCards"; pnlKpiCards.Size = new System.Drawing.Size(1366, 100);
            pnlKpiBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiBudget.Controls.Add(lblKpiBudgetTitle); pnlKpiBudget.Controls.Add(lblKpiBudgetValue);
            pnlKpiBudget.Location = new System.Drawing.Point(1092, 8); pnlKpiBudget.Name = "pnlKpiBudget"; pnlKpiBudget.Size = new System.Drawing.Size(261, 84);
            lblKpiBudgetTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblKpiBudgetTitle.Appearance.Options.UseFont = true;
            lblKpiBudgetTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblKpiBudgetTitle.Appearance.Options.UseForeColor = true;
            lblKpiBudgetTitle.Location = new System.Drawing.Point(10, 12); lblKpiBudgetTitle.Name = "lblKpiBudgetTitle"; lblKpiBudgetTitle.Text = "الموازنة";
            lblKpiBudgetValue.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblKpiBudgetValue.Appearance.Options.UseFont = true;
            lblKpiBudgetValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 117, 182); lblKpiBudgetValue.Appearance.Options.UseForeColor = true;
            lblKpiBudgetValue.Location = new System.Drawing.Point(10, 38); lblKpiBudgetValue.Name = "lblKpiBudgetValue"; lblKpiBudgetValue.Text = "—";

            pnlKpiActual.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiActual.Controls.Add(lblKpiActualTitle); pnlKpiActual.Controls.Add(lblKpiActualValue);
            pnlKpiActual.Location = new System.Drawing.Point(821, 8); pnlKpiActual.Name = "pnlKpiActual"; pnlKpiActual.Size = new System.Drawing.Size(261, 84);
            lblKpiActualTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblKpiActualTitle.Appearance.Options.UseFont = true;
            lblKpiActualTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblKpiActualTitle.Appearance.Options.UseForeColor = true;
            lblKpiActualTitle.Location = new System.Drawing.Point(10, 12); lblKpiActualTitle.Name = "lblKpiActualTitle"; lblKpiActualTitle.Text = "الفعلي";
            lblKpiActualValue.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblKpiActualValue.Appearance.Options.UseFont = true;
            lblKpiActualValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(192, 80, 77); lblKpiActualValue.Appearance.Options.UseForeColor = true;
            lblKpiActualValue.Location = new System.Drawing.Point(10, 38); lblKpiActualValue.Name = "lblKpiActualValue"; lblKpiActualValue.Text = "—";

            pnlKpiCommitment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiCommitment.Controls.Add(lblKpiCommitmentTitle); pnlKpiCommitment.Controls.Add(lblKpiCommitmentValue);
            pnlKpiCommitment.Location = new System.Drawing.Point(550, 8); pnlKpiCommitment.Name = "pnlKpiCommitment"; pnlKpiCommitment.Size = new System.Drawing.Size(261, 84);
            lblKpiCommitmentTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblKpiCommitmentTitle.Appearance.Options.UseFont = true;
            lblKpiCommitmentTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblKpiCommitmentTitle.Appearance.Options.UseForeColor = true;
            lblKpiCommitmentTitle.Location = new System.Drawing.Point(10, 12); lblKpiCommitmentTitle.Name = "lblKpiCommitmentTitle"; lblKpiCommitmentTitle.Text = "الالتزامات";
            lblKpiCommitmentValue.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblKpiCommitmentValue.Appearance.Options.UseFont = true;
            lblKpiCommitmentValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(255, 127, 14); lblKpiCommitmentValue.Appearance.Options.UseForeColor = true;
            lblKpiCommitmentValue.Location = new System.Drawing.Point(10, 38); lblKpiCommitmentValue.Name = "lblKpiCommitmentValue"; lblKpiCommitmentValue.Text = "—";

            pnlKpiForecast.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiForecast.Controls.Add(lblKpiForecastTitle); pnlKpiForecast.Controls.Add(lblKpiForecastValue);
            pnlKpiForecast.Location = new System.Drawing.Point(279, 8); pnlKpiForecast.Name = "pnlKpiForecast"; pnlKpiForecast.Size = new System.Drawing.Size(261, 84);
            lblKpiForecastTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblKpiForecastTitle.Appearance.Options.UseFont = true;
            lblKpiForecastTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblKpiForecastTitle.Appearance.Options.UseForeColor = true;
            lblKpiForecastTitle.Location = new System.Drawing.Point(10, 12); lblKpiForecastTitle.Name = "lblKpiForecastTitle"; lblKpiForecastTitle.Text = "التوقع";
            lblKpiForecastValue.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblKpiForecastValue.Appearance.Options.UseFont = true;
            lblKpiForecastValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(148, 103, 189); lblKpiForecastValue.Appearance.Options.UseForeColor = true;
            lblKpiForecastValue.Location = new System.Drawing.Point(10, 38); lblKpiForecastValue.Name = "lblKpiForecastValue"; lblKpiForecastValue.Text = "—";

            pnlKpiVariance.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKpiVariance.Controls.Add(lblKpiVarianceTitle); pnlKpiVariance.Controls.Add(lblKpiVarianceValue);
            pnlKpiVariance.Location = new System.Drawing.Point(8, 8); pnlKpiVariance.Name = "pnlKpiVariance"; pnlKpiVariance.Size = new System.Drawing.Size(261, 84);
            lblKpiVarianceTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblKpiVarianceTitle.Appearance.Options.UseFont = true;
            lblKpiVarianceTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblKpiVarianceTitle.Appearance.Options.UseForeColor = true;
            lblKpiVarianceTitle.Location = new System.Drawing.Point(10, 12); lblKpiVarianceTitle.Name = "lblKpiVarianceTitle"; lblKpiVarianceTitle.Text = "انحراف الموازنة";
            lblKpiVarianceValue.Appearance.Font = new System.Drawing.Font("Cairo", 13F, System.Drawing.FontStyle.Bold); lblKpiVarianceValue.Appearance.Options.UseFont = true;
            lblKpiVarianceValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(192, 80, 77); lblKpiVarianceValue.Appearance.Options.UseForeColor = true;
            lblKpiVarianceValue.Location = new System.Drawing.Point(10, 38); lblKpiVarianceValue.Name = "lblKpiVarianceValue"; lblKpiVarianceValue.Text = "—";

            // Charts
            pnlCharts.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCharts.Controls.Add(tblCharts); pnlCharts.Dock = System.Windows.Forms.DockStyle.Top; pnlCharts.Location = new System.Drawing.Point(0, 134); pnlCharts.Name = "pnlCharts"; pnlCharts.Size = new System.Drawing.Size(1366, 280);
            tblCharts.ColumnCount = 3; tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F)); tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F)); tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tblCharts.Controls.Add(grpVarianceChart, 0, 0); tblCharts.Controls.Add(grpTrendChart, 1, 0); tblCharts.Controls.Add(grpDistChart, 2, 0);
            tblCharts.Dock = System.Windows.Forms.DockStyle.Fill; tblCharts.Name = "tblCharts"; tblCharts.RowCount = 1; tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            grpVarianceChart.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpVarianceChart.AppearanceCaption.Options.UseFont = true;
            grpVarianceChart.Controls.Add(chartVariance); grpVarianceChart.Dock = System.Windows.Forms.DockStyle.Fill; grpVarianceChart.Margin = new System.Windows.Forms.Padding(3); grpVarianceChart.Name = "grpVarianceChart"; grpVarianceChart.Text = "الانحراف عن الموازنة";
            chartVariance.Dock = System.Windows.Forms.DockStyle.Fill; chartVariance.Name = "chartVariance"; chartVariance.SeriesSerializable = new DevExpress.XtraCharts.Series[] { seriesVariance };

            grpTrendChart.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpTrendChart.AppearanceCaption.Options.UseFont = true;
            grpTrendChart.Controls.Add(chartTrend); grpTrendChart.Dock = System.Windows.Forms.DockStyle.Fill; grpTrendChart.Margin = new System.Windows.Forms.Padding(3); grpTrendChart.Name = "grpTrendChart"; grpTrendChart.Text = "اتجاه التكلفة";
            chartTrend.Dock = System.Windows.Forms.DockStyle.Fill; chartTrend.Name = "chartTrend"; chartTrend.SeriesSerializable = new DevExpress.XtraCharts.Series[] { seriesTrendBudget, seriesTrendActual };

            grpDistChart.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpDistChart.AppearanceCaption.Options.UseFont = true;
            grpDistChart.Controls.Add(chartDistribution); grpDistChart.Dock = System.Windows.Forms.DockStyle.Fill; grpDistChart.Margin = new System.Windows.Forms.Padding(3); grpDistChart.Name = "grpDistChart"; grpDistChart.Text = "توزيع التكلفة";
            chartDistribution.Dock = System.Windows.Forms.DockStyle.Fill; chartDistribution.Name = "chartDistribution"; chartDistribution.SeriesSerializable = new DevExpress.XtraCharts.Series[] { seriesDistribution };

            // Grid
            grdBudgetVsActual.Dock = System.Windows.Forms.DockStyle.Fill; grdBudgetVsActual.MainView = gvBudgetVsActual; grdBudgetVsActual.Name = "grdBudgetVsActual"; grdBudgetVsActual.MenuManager = barManagerMain;
            grdBudgetVsActual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvBudgetVsActual });
            gvBudgetVsActual.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F); gvBudgetVsActual.Appearance.Row.Options.UseFont = true;
            gvBudgetVsActual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colBVACostCode, colBVADescription, colBVABudget, colBVACommitted, colBVAActual, colBVAForecast, colBVAVariance, colBVAVariancePct });
            gvBudgetVsActual.GridControl = grdBudgetVsActual; gvBudgetVsActual.Name = "gvBudgetVsActual"; gvBudgetVsActual.OptionsBehavior.Editable = false;
            gvBudgetVsActual.OptionsView.ShowAutoFilterRow = true; gvBudgetVsActual.OptionsView.ShowFooter = true;
            colBVACostCode.Caption = "كود التكلفة"; colBVACostCode.FieldName = "CostCode"; colBVACostCode.Name = "colBVACostCode"; colBVACostCode.Visible = true; colBVACostCode.Width = 120; colBVACostCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colBVADescription.Caption = "الوصف"; colBVADescription.FieldName = "Description"; colBVADescription.Name = "colBVADescription"; colBVADescription.Visible = true; colBVADescription.Width = 220;
            colBVABudget.Caption = "الموازنة"; colBVABudget.FieldName = "Budget"; colBVABudget.Name = "colBVABudget"; colBVABudget.Visible = true; colBVABudget.Width = 140; colBVABudget.DisplayFormat.FormatString = "N2"; colBVABudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric; colBVABudget.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Budget", "{0:N2}") });
            colBVACommitted.Caption = "الملتزمات"; colBVACommitted.FieldName = "Committed"; colBVACommitted.Name = "colBVACommitted"; colBVACommitted.Visible = true; colBVACommitted.Width = 140; colBVACommitted.DisplayFormat.FormatString = "N2"; colBVACommitted.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric; colBVACommitted.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Committed", "{0:N2}") });
            colBVAActual.Caption = "الفعلي"; colBVAActual.FieldName = "Actual"; colBVAActual.Name = "colBVAActual"; colBVAActual.Visible = true; colBVAActual.Width = 140; colBVAActual.DisplayFormat.FormatString = "N2"; colBVAActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric; colBVAActual.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Actual", "{0:N2}") });
            colBVAForecast.Caption = "التوقع"; colBVAForecast.FieldName = "Forecast"; colBVAForecast.Name = "colBVAForecast"; colBVAForecast.Visible = true; colBVAForecast.Width = 140; colBVAForecast.DisplayFormat.FormatString = "N2"; colBVAForecast.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric; colBVAForecast.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Forecast", "{0:N2}") });
            colBVAVariance.Caption = "الانحراف"; colBVAVariance.FieldName = "Variance"; colBVAVariance.Name = "colBVAVariance"; colBVAVariance.Visible = true; colBVAVariance.Width = 140; colBVAVariance.DisplayFormat.FormatString = "N2"; colBVAVariance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric; colBVAVariance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Variance", "{0:N2}") });
            colBVAVariancePct.Caption = "% الانحراف"; colBVAVariancePct.FieldName = "VariancePct"; colBVAVariancePct.Name = "colBVAVariancePct"; colBVAVariancePct.Visible = true; colBVAVariancePct.Width = 100; colBVAVariancePct.DisplayFormat.FormatString = "P1"; colBVAVariancePct.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // Conditional formatting
            ruleOver.Column = colBVAVariance; ruleOver.Name = "ruleOverBudget";
            fcrOver.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 220, 220); fcrOver.Appearance.Options.UseBackColor = true;
            fcrOver.Condition = DevExpress.XtraEditors.FormatCondition.Less; fcrOver.Value1 = 0; ruleOver.Rule = fcrOver;
            ruleUnder.Column = colBVAVariance; ruleUnder.Name = "ruleUnderBudget";
            fcrUnder.Appearance.BackColor = System.Drawing.Color.FromArgb(210, 245, 220); fcrUnder.Appearance.Options.UseBackColor = true;
            fcrUnder.Condition = DevExpress.XtraEditors.FormatCondition.Greater; fcrUnder.Value1 = 0; ruleUnder.Rule = fcrUnder;
            gvBudgetVsActual.FormatRules.AddRange(new DevExpress.XtraGrid.GridFormatRule[] { ruleOver, ruleUnder });

            // States
            pnlLoadingState.Controls.Add(lblLoadingText); pnlLoadingState.Controls.Add(svgLoadingIcon); pnlLoadingState.Dock = System.Windows.Forms.DockStyle.Fill; pnlLoadingState.Name = "pnlLoadingState"; pnlLoadingState.Visible = false;
            lblLoadingText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblLoadingText.Appearance.Options.UseFont = true; lblLoadingText.Location = new System.Drawing.Point(543, 310); lblLoadingText.Name = "lblLoadingText"; lblLoadingText.Text = "جاري تحميل بيانات المقارنة...";
            svgLoadingIcon.Location = new System.Drawing.Point(651, 210); svgLoadingIcon.Name = "svgLoadingIcon"; svgLoadingIcon.Size = new System.Drawing.Size(64, 64); svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            pnlEmptyState.Controls.Add(lblEmptyText); pnlEmptyState.Controls.Add(svgEmptyIcon); pnlEmptyState.Dock = System.Windows.Forms.DockStyle.Fill; pnlEmptyState.Name = "pnlEmptyState"; pnlEmptyState.Visible = false;
            lblEmptyText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblEmptyText.Appearance.Options.UseFont = true; lblEmptyText.Location = new System.Drawing.Point(543, 310); lblEmptyText.Name = "lblEmptyText"; lblEmptyText.Text = "لا توجد بيانات مقارنة";
            svgEmptyIcon.Location = new System.Drawing.Point(651, 210); svgEmptyIcon.Name = "svgEmptyIcon"; svgEmptyIcon.Size = new System.Drawing.Size(64, 64); svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            pnlErrorState.Controls.Add(btnRetry); pnlErrorState.Controls.Add(lblErrorText); pnlErrorState.Controls.Add(svgErrorIcon); pnlErrorState.Dock = System.Windows.Forms.DockStyle.Fill; pnlErrorState.Name = "pnlErrorState"; pnlErrorState.Visible = false;
            lblErrorText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblErrorText.Appearance.Options.UseFont = true; lblErrorText.Location = new System.Drawing.Point(543, 290); lblErrorText.Name = "lblErrorText"; lblErrorText.Text = "حدث خطأ أثناء تحميل البيانات";
            svgErrorIcon.Location = new System.Drawing.Point(651, 190); svgErrorIcon.Name = "svgErrorIcon"; svgErrorIcon.Size = new System.Drawing.Size(64, 64); svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            btnRetry.Appearance.Font = new System.Drawing.Font("Cairo", 9F); btnRetry.Appearance.Options.UseFont = true; btnRetry.Location = new System.Drawing.Point(633, 330); btnRetry.Name = "btnRetry"; btnRetry.Size = new System.Drawing.Size(100, 34); btnRetry.Text = "إعادة المحاولة"; btnRetry.Click += btnRetry_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F); AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(grdBudgetVsActual); Controls.Add(pnlCharts); Controls.Add(pnlLoadingState); Controls.Add(pnlEmptyState); Controls.Add(pnlErrorState);
            Controls.Add(pnlKpiCards); Controls.Add(barDockControlLeft); Controls.Add(barDockControlRight); Controls.Add(barDockControlBottom); Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5); Name = "ucBudgetVsActual"; RightToLeft = System.Windows.Forms.RightToLeft.Yes; Size = new System.Drawing.Size(1366, 902);

            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit(); pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiBudget).EndInit(); pnlKpiBudget.ResumeLayout(false); pnlKpiBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActual).EndInit(); pnlKpiActual.ResumeLayout(false); pnlKpiActual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCommitment).EndInit(); pnlKpiCommitment.ResumeLayout(false); pnlKpiCommitment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).EndInit(); pnlKpiForecast.ResumeLayout(false); pnlKpiForecast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiVariance).EndInit(); pnlKpiVariance.ResumeLayout(false); pnlKpiVariance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).EndInit(); pnlCharts.ResumeLayout(false);
            tblCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpVarianceChart).EndInit(); grpVarianceChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpTrendChart).EndInit(); grpTrendChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpDistChart).EndInit(); grpDistChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartVariance).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartDistribution).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesVariance).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesTrendBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesTrendActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesDistribution).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdBudgetVsActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvBudgetVsActual).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiFilter, bbiExportExcel, bbiPrint, bbiRefresh;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.PanelControl pnlKpiBudget, pnlKpiActual, pnlKpiCommitment, pnlKpiForecast, pnlKpiVariance;
        private DevExpress.XtraEditors.LabelControl lblKpiBudgetValue, lblKpiBudgetTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiActualValue, lblKpiActualTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiCommitmentValue, lblKpiCommitmentTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiForecastValue, lblKpiForecastTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiVarianceValue, lblKpiVarianceTitle;
        private DevExpress.XtraEditors.PanelControl pnlCharts;
        private System.Windows.Forms.TableLayoutPanel tblCharts;
        private DevExpress.XtraEditors.GroupControl grpVarianceChart, grpTrendChart, grpDistChart;
        private DevExpress.XtraCharts.ChartControl chartVariance, chartTrend, chartDistribution;
        private DevExpress.XtraCharts.Series seriesVariance, seriesTrendBudget, seriesTrendActual, seriesDistribution;
        private DevExpress.XtraGrid.GridControl grdBudgetVsActual;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBudgetVsActual;
        private DevExpress.XtraGrid.Columns.GridColumn colBVACostCode, colBVADescription, colBVABudget, colBVACommitted, colBVAActual, colBVAForecast, colBVAVariance, colBVAVariancePct;
        private DevExpress.XtraEditors.PanelControl pnlLoadingState, pnlEmptyState, pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon, svgEmptyIcon, svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText, lblEmptyText, lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}

