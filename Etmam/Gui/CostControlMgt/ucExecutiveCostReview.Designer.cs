namespace Etmam.Gui.CostControlMgt
{
    partial class ucExecutiveCostReview
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManagerMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barMain = new DevExpress.XtraBars.Bar();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            this.lblMargin = new DevExpress.XtraEditors.LabelControl();
            this.lblProfit = new DevExpress.XtraEditors.LabelControl();
            this.lblCash = new DevExpress.XtraEditors.LabelControl();
            this.lblForecast = new DevExpress.XtraEditors.LabelControl();
            this.lblRisk = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.pnlHeatMap = new DevExpress.XtraEditors.PanelControl();
            this.lblHeatMapTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnlWaterfallChart = new DevExpress.XtraEditors.PanelControl();
            this.lblWaterfallTitle = new DevExpress.XtraEditors.LabelControl();
            this.chartPortfolioCost = new DevExpress.XtraCharts.ChartControl();
            this.chartTopCostRisks = new DevExpress.XtraCharts.ChartControl();
            this.chartBudgetDistribution = new DevExpress.XtraCharts.ChartControl();
            this.pnlExecutiveAlerts = new DevExpress.XtraEditors.PanelControl();
            this.lblAlerts = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutHeatMap = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutWaterfall = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutChartPortfolioCost = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutChartTopCostRisks = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutChartBudgetDist = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutExecutiveAlerts = new DevExpress.XtraLayout.LayoutControlItem();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).BeginInit();
            this.pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeatMap)).BeginInit();
            this.pnlHeatMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWaterfallChart)).BeginInit();
            this.pnlWaterfallChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPortfolioCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopCostRisks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBudgetDistribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlExecutiveAlerts)).BeginInit();
            this.pnlExecutiveAlerts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutHeatMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutWaterfall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChartPortfolioCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChartTopCostRisks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChartBudgetDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutExecutiveAlerts)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiRefresh, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات المراجعة التنفيذية للتكاليف Executive Cost Review";

            this.bbiRefresh.Caption = "تحديث محفظة التكاليف Executive Portfolio";
            this.bbiExport.Caption = "تصدير التقرير التنفيذي لغرفة الإدارة";

            // pnlKpiCards
            this.pnlKpiCards.Controls.Add(this.lblMargin);
            this.pnlKpiCards.Controls.Add(this.lblProfit);
            this.pnlKpiCards.Controls.Add(this.lblCash);
            this.pnlKpiCards.Controls.Add(this.lblForecast);
            this.pnlKpiCards.Controls.Add(this.lblRisk);
            this.pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiCards.Location = new System.Drawing.Point(0, 30);
            this.pnlKpiCards.Name = "pnlKpiCards";
            this.pnlKpiCards.Size = new System.Drawing.Size(1200, 50);

            this.lblMargin.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMargin.Location = new System.Drawing.Point(1000, 15);
            this.lblMargin.Text = "Gross Margin: 18.2%";

            this.lblProfit.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProfit.Location = new System.Drawing.Point(780, 15);
            this.lblProfit.Text = "Net Profit: 21.8M SAR";

            this.lblCash.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCash.Location = new System.Drawing.Point(550, 15);
            this.lblCash.Text = "Cash Position: +8.4M SAR";

            this.lblForecast.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblForecast.Location = new System.Drawing.Point(300, 15);
            this.lblForecast.Text = "Portfolio EAC: 101.8M SAR";

            this.lblRisk.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRisk.Location = new System.Drawing.Point(80, 15);
            this.lblRisk.Text = "Overall Risk: Low (Score 2.1)";

            // layoutControlMain
            this.layoutControlMain.Controls.Add(this.pnlHeatMap);
            this.layoutControlMain.Controls.Add(this.pnlWaterfallChart);
            this.layoutControlMain.Controls.Add(this.chartPortfolioCost);
            this.layoutControlMain.Controls.Add(this.chartTopCostRisks);
            this.layoutControlMain.Controls.Add(this.chartBudgetDistribution);
            this.layoutControlMain.Controls.Add(this.pnlExecutiveAlerts);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(0, 80);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControlMain.Root = this.Root;
            this.layoutControlMain.Size = new System.Drawing.Size(1200, 670);

            // pnlHeatMap
            this.pnlHeatMap.Controls.Add(this.lblHeatMapTitle);
            this.pnlHeatMap.Location = new System.Drawing.Point(12, 12);
            this.pnlHeatMap.Name = "pnlHeatMap";
            this.pnlHeatMap.Size = new System.Drawing.Size(582, 200);

            this.lblHeatMapTitle.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeatMapTitle.Location = new System.Drawing.Point(10, 10);
            this.lblHeatMapTitle.Text = "الخريطة الحرارية للمخاطر وتجاوز الموازنات (Executive Heat Map Matrix)";

            // pnlWaterfallChart
            this.pnlWaterfallChart.Controls.Add(this.lblWaterfallTitle);
            this.pnlWaterfallChart.Location = new System.Drawing.Point(598, 12);
            this.pnlWaterfallChart.Name = "pnlWaterfallChart";
            this.pnlWaterfallChart.Size = new System.Drawing.Size(590, 200);

            this.lblWaterfallTitle.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblWaterfallTitle.Location = new System.Drawing.Point(10, 10);
            this.lblWaterfallTitle.Text = "مخطط شلال أثر المتغيرات والمطالبات على الربح (Cost Waterfall Analysis)";

            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutHeatMap,
                this.layoutWaterfall,
                this.layoutChartPortfolioCost,
                this.layoutChartTopCostRisks,
                this.layoutChartBudgetDist,
                this.layoutExecutiveAlerts
            });
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1200, 670);

            this.layoutHeatMap.Control = this.pnlHeatMap;
            this.layoutHeatMap.Name = "layoutHeatMap";
            this.layoutHeatMap.Size = new System.Drawing.Size(586, 204);
            this.layoutHeatMap.TextVisible = false;

            this.layoutWaterfall.Control = this.pnlWaterfallChart;
            this.layoutWaterfall.Name = "layoutWaterfall";
            this.layoutWaterfall.Size = new System.Drawing.Size(594, 204);
            this.layoutWaterfall.TextVisible = false;

            this.layoutChartPortfolioCost.Control = this.chartPortfolioCost;
            this.layoutChartPortfolioCost.Name = "layoutChartPortfolioCost";
            this.layoutChartPortfolioCost.Size = new System.Drawing.Size(390, 230);
            this.layoutChartPortfolioCost.Text = "تكاليف محفظة المشاريع";

            this.layoutChartTopCostRisks.Control = this.chartTopCostRisks;
            this.layoutChartTopCostRisks.Name = "layoutChartTopCostRisks";
            this.layoutChartTopCostRisks.Size = new System.Drawing.Size(390, 230);
            this.layoutChartTopCostRisks.Text = "أعلى مخاطر التكلفة بالمنشأة";

            this.layoutChartBudgetDist.Control = this.chartBudgetDistribution;
            this.layoutChartBudgetDist.Name = "layoutChartBudgetDist";
            this.layoutChartBudgetDist.Size = new System.Drawing.Size(400, 230);
            this.layoutChartBudgetDist.Text = "توزيع ميزانيات المشاريع";

            this.layoutExecutiveAlerts.Control = this.pnlExecutiveAlerts;
            this.layoutExecutiveAlerts.Name = "layoutExecutiveAlerts";
            this.layoutExecutiveAlerts.Size = new System.Drawing.Size(1180, 216);
            this.layoutExecutiveAlerts.Text = "التنبيهات الإدارية للتجاوز المالي والتدفق النقدي";

            // pnlExecutiveAlerts
            this.pnlExecutiveAlerts.Controls.Add(this.lblAlerts);
            this.pnlExecutiveAlerts.Location = new System.Drawing.Point(12, 446);
            this.pnlExecutiveAlerts.Name = "pnlExecutiveAlerts";
            this.pnlExecutiveAlerts.Size = new System.Drawing.Size(1176, 212);

            this.lblAlerts.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAlerts.Location = new System.Drawing.Point(10, 10);
            this.lblAlerts.Text = "مشاريع قريبة من تجاوز الموازنة: 1 | عجز سيولة متوقع للشهر القادم: لا يوجد | نسبة الأمان المالي: 98.4%";

            // ucExecutiveCostReview
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.layoutControlMain);
            this.Controls.Add(this.pnlKpiCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucExecutiveCostReview";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).EndInit();
            this.pnlKpiCards.ResumeLayout(false);
            this.pnlKpiCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeatMap)).EndInit();
            this.pnlHeatMap.ResumeLayout(false);
            this.pnlHeatMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWaterfallChart)).EndInit();
            this.pnlWaterfallChart.ResumeLayout(false);
            this.pnlWaterfallChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPortfolioCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopCostRisks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBudgetDistribution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlExecutiveAlerts)).EndInit();
            this.pnlExecutiveAlerts.ResumeLayout(false);
            this.pnlExecutiveAlerts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutHeatMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutWaterfall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChartPortfolioCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChartTopCostRisks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChartBudgetDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutExecutiveAlerts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.LabelControl lblMargin;
        private DevExpress.XtraEditors.LabelControl lblProfit;
        private DevExpress.XtraEditors.LabelControl lblCash;
        private DevExpress.XtraEditors.LabelControl lblForecast;
        private DevExpress.XtraEditors.LabelControl lblRisk;
        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.PanelControl pnlHeatMap;
        private DevExpress.XtraEditors.LabelControl lblHeatMapTitle;
        private DevExpress.XtraEditors.PanelControl pnlWaterfallChart;
        private DevExpress.XtraEditors.LabelControl lblWaterfallTitle;
        private DevExpress.XtraCharts.ChartControl chartPortfolioCost;
        private DevExpress.XtraCharts.ChartControl chartTopCostRisks;
        private DevExpress.XtraCharts.ChartControl chartBudgetDistribution;
        private DevExpress.XtraEditors.PanelControl pnlExecutiveAlerts;
        private DevExpress.XtraEditors.LabelControl lblAlerts;
        private DevExpress.XtraLayout.LayoutControlItem layoutHeatMap;
        private DevExpress.XtraLayout.LayoutControlItem layoutWaterfall;
        private DevExpress.XtraLayout.LayoutControlItem layoutChartPortfolioCost;
        private DevExpress.XtraLayout.LayoutControlItem layoutChartTopCostRisks;
        private DevExpress.XtraLayout.LayoutControlItem layoutChartBudgetDist;
        private DevExpress.XtraLayout.LayoutControlItem layoutExecutiveAlerts;
    }
}
