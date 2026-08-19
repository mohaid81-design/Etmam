namespace Etmam.Gui.CostControlMgt
{
    partial class ucCashFlowAnalysis
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
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblPlannedCash = new DevExpress.XtraEditors.LabelControl();
            this.lblActualCash = new DevExpress.XtraEditors.LabelControl();
            this.lblForecastCash = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdCashFlow = new DevExpress.XtraGrid.GridControl();
            this.gvCashFlow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpense = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForecastCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartCashFlow = new DevExpress.XtraCharts.ChartControl();
            this.chartCumulativeCash = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCashFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCashFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCashFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCumulativeCash)).BeginInit();
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
            this.barMain.Text = "أدوات تحليل التدفقات النقدية Cash Flow Analysis";

            this.bbiRefresh.Caption = "تحديث التدفقات المباشرة والمتوقعة";
            this.bbiExport.Caption = "تصدير جدول Cash Flow";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblPlannedCash);
            this.pnlCards.Controls.Add(this.lblActualCash);
            this.pnlCards.Controls.Add(this.lblForecastCash);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblPlannedCash.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPlannedCash.Location = new System.Drawing.Point(950, 15);
            this.lblPlannedCash.Text = "التدفق النقدي المخطط (Planned Cash): +12.4M SAR";

            this.lblActualCash.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblActualCash.Location = new System.Drawing.Point(580, 15);
            this.lblActualCash.Text = "التدفق النقدي الفعلي الصافي (Actual Cash): +8.4M SAR";

            this.lblForecastCash.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblForecastCash.Location = new System.Drawing.Point(180, 15);
            this.lblForecastCash.Text = "التدفق التقديري لنهاية العام (Forecast Cash): +15.2M SAR";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdCashFlow);
            this.splitContainerControlMain.Panel1.Text = "جدول التدفقات النقدية الشهرية المقارنة";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerCharts);
            this.splitContainerControlMain.Panel2.Text = "مخططات التدفق الشهري والمراكم التراكمي";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdCashFlow
            this.grdCashFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCashFlow.Location = new System.Drawing.Point(0, 0);
            this.grdCashFlow.MainView = this.gvCashFlow;
            this.grdCashFlow.Name = "grdCashFlow";
            this.grdCashFlow.Size = new System.Drawing.Size(1200, 380);
            this.grdCashFlow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvCashFlow });

            // gvCashFlow
            this.gvCashFlow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colMonth, this.colIncome, this.colExpense,
                this.colForecastCash, this.colNetVariance
            });
            this.gvCashFlow.GridControl = this.grdCashFlow;
            this.gvCashFlow.Name = "gvCashFlow";
            this.gvCashFlow.OptionsView.ShowAutoFilterRow = true;
            this.gvCashFlow.OptionsView.ShowFooter = true;

            this.colMonth.Caption = "الشهر والفترة التقريرية (Month)";
            this.colMonth.FieldName = "Month";
            this.colMonth.Visible = true;
            this.colMonth.VisibleIndex = 0;

            this.colIncome.Caption = "القبوضات والدفعات الملموسة (Income)";
            this.colIncome.FieldName = "Income";
            this.colIncome.Visible = true;
            this.colIncome.VisibleIndex = 1;

            this.colExpense.Caption = "المصروفات والتكاليف المسددة (Expense)";
            this.colExpense.FieldName = "Expense";
            this.colExpense.Visible = true;
            this.colExpense.VisibleIndex = 2;

            this.colForecastCash.Caption = "التدفق النقدي المتوقع للشهور القادمة (Forecast)";
            this.colForecastCash.FieldName = "ForecastCash";
            this.colForecastCash.Visible = true;
            this.colForecastCash.VisibleIndex = 3;

            this.colNetVariance.Caption = "صافي الفائض / العجز النقدي (Variance)";
            this.colNetVariance.FieldName = "NetVariance";
            this.colNetVariance.Visible = true;
            this.colNetVariance.VisibleIndex = 4;

            // splitContainerCharts
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartCashFlow);
            this.splitContainerCharts.Panel1.Text = "مخطط التدفق الشهري";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartCumulativeCash);
            this.splitContainerCharts.Panel2.Text = "منحنى التدفق التراكمي";
            this.splitContainerCharts.Size = new System.Drawing.Size(1200, 280);
            this.splitContainerCharts.SplitterPosition = 600;

            this.chartCashFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCashFlow.Location = new System.Drawing.Point(0, 0);
            this.chartCashFlow.Name = "chartCashFlow";
            this.chartCashFlow.Size = new System.Drawing.Size(600, 280);

            this.chartCumulativeCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCumulativeCash.Location = new System.Drawing.Point(0, 0);
            this.chartCumulativeCash.Name = "chartCumulativeCash";
            this.chartCumulativeCash.Size = new System.Drawing.Size(590, 280);

            // ucCashFlowAnalysis
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCashFlowAnalysis";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCashFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCashFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCashFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCumulativeCash)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblPlannedCash;
        private DevExpress.XtraEditors.LabelControl lblActualCash;
        private DevExpress.XtraEditors.LabelControl lblForecastCash;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdCashFlow;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCashFlow;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colIncome;
        private DevExpress.XtraGrid.Columns.GridColumn colExpense;
        private DevExpress.XtraGrid.Columns.GridColumn colForecastCash;
        private DevExpress.XtraGrid.Columns.GridColumn colNetVariance;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartCashFlow;
        private DevExpress.XtraCharts.ChartControl chartCumulativeCash;
    }
}
