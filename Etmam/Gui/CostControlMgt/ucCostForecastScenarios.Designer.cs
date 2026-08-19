namespace Etmam.Gui.CostControlMgt
{
    partial class ucCostForecastScenarios
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
            this.bbiNewScenario = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSimulate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblBestCase = new DevExpress.XtraEditors.LabelControl();
            this.lblExpected = new DevExpress.XtraEditors.LabelControl();
            this.lblWorstCase = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdScenarios = new DevExpress.XtraGrid.GridControl();
            this.gvScenarios = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAssumption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProbability = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeightedValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartScenarioComparison = new DevExpress.XtraCharts.ChartControl();
            this.chartForecastRange = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScenarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScenarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartScenarioComparison)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartForecastRange)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewScenario, this.bbiSimulate, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewScenario),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSimulate),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات محاكة وسيناريوهات توقعات التكلفة Cost Forecast Scenarios";

            this.bbiNewScenario.Caption = "إضافة سيناريو مالي جديد";
            this.bbiSimulate.Caption = "تشغيل المحاكاة المالية (Simulation)";
            this.bbiExport.Caption = "تصدير تحليل السيناريوهات المقارنة";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblBestCase);
            this.pnlCards.Controls.Add(this.lblExpected);
            this.pnlCards.Controls.Add(this.lblWorstCase);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblBestCase.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBestCase.Location = new System.Drawing.Point(950, 15);
            this.lblBestCase.Text = "أفضل حالة (Best Case EAC): 96.5M SAR";

            this.lblExpected.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpected.Location = new System.Drawing.Point(580, 15);
            this.lblExpected.Text = "الحالة المتوقعة (Expected EAC): 101.8M SAR";

            this.lblWorstCase.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblWorstCase.Location = new System.Drawing.Point(180, 15);
            this.lblWorstCase.Text = "أسوأ حالة (Worst Case EAC): 109.2M SAR";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdScenarios);
            this.splitContainerControlMain.Panel1.Text = "جدول الافتراضات المالية والاحتماليات وتأثير كل سيناريو";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerCharts);
            this.splitContainerControlMain.Panel2.Text = "مخططات المقارنة ومدى التوقعات النقدية";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdScenarios
            this.grdScenarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdScenarios.Location = new System.Drawing.Point(0, 0);
            this.grdScenarios.MainView = this.gvScenarios;
            this.grdScenarios.Name = "grdScenarios";
            this.grdScenarios.Size = new System.Drawing.Size(1200, 380);
            this.grdScenarios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvScenarios });

            // gvScenarios
            this.gvScenarios.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colAssumption, this.colImpact, this.colProbability, this.colWeightedValue
            });
            this.gvScenarios.GridControl = this.grdScenarios;
            this.gvScenarios.Name = "gvScenarios";
            this.gvScenarios.OptionsView.ShowAutoFilterRow = true;
            this.gvScenarios.OptionsView.ShowFooter = true;

            this.colAssumption.Caption = "الافتراض المالي / تغير الأسعار / التضخم (Assumption)";
            this.colAssumption.FieldName = "Assumption";
            this.colAssumption.Visible = true;
            this.colAssumption.VisibleIndex = 0;

            this.colImpact.Caption = "الأثر المالي المتوقع (Impact SAR)";
            this.colImpact.FieldName = "Impact";
            this.colImpact.Visible = true;
            this.colImpact.VisibleIndex = 1;

            this.colProbability.Caption = "احتمالية الوقوع % (Probability)";
            this.colProbability.FieldName = "Probability";
            this.colProbability.Visible = true;
            this.colProbability.VisibleIndex = 2;

            this.colWeightedValue.Caption = "القيمة المرجحة المخاطر (Weighted Risk Value)";
            this.colWeightedValue.FieldName = "WeightedValue";
            this.colWeightedValue.Visible = true;
            this.colWeightedValue.VisibleIndex = 3;

            // splitContainerCharts
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartScenarioComparison);
            this.splitContainerCharts.Panel1.Text = "مقارنة السيناريوهات الثلاثة";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartForecastRange);
            this.splitContainerCharts.Panel2.Text = "نطاق التوقعات Range";
            this.splitContainerCharts.Size = new System.Drawing.Size(1200, 280);
            this.splitContainerCharts.SplitterPosition = 600;

            this.chartScenarioComparison.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartScenarioComparison.Location = new System.Drawing.Point(0, 0);
            this.chartScenarioComparison.Name = "chartScenarioComparison";
            this.chartScenarioComparison.Size = new System.Drawing.Size(600, 280);

            this.chartForecastRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartForecastRange.Location = new System.Drawing.Point(0, 0);
            this.chartForecastRange.Name = "chartForecastRange";
            this.chartForecastRange.Size = new System.Drawing.Size(590, 280);

            // ucCostForecastScenarios
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCostForecastScenarios";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScenarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScenarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartScenarioComparison)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartForecastRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewScenario;
        private DevExpress.XtraBars.BarButtonItem bbiSimulate;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblBestCase;
        private DevExpress.XtraEditors.LabelControl lblExpected;
        private DevExpress.XtraEditors.LabelControl lblWorstCase;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdScenarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gvScenarios;
        private DevExpress.XtraGrid.Columns.GridColumn colAssumption;
        private DevExpress.XtraGrid.Columns.GridColumn colImpact;
        private DevExpress.XtraGrid.Columns.GridColumn colProbability;
        private DevExpress.XtraGrid.Columns.GridColumn colWeightedValue;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartScenarioComparison;
        private DevExpress.XtraCharts.ChartControl chartForecastRange;
    }
}
