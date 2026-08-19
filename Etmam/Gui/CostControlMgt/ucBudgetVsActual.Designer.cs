namespace Etmam.Gui.CostControlMgt
{
    partial class ucBudgetVsActual
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
            this.lblBudget = new DevExpress.XtraEditors.LabelControl();
            this.lblActual = new DevExpress.XtraEditors.LabelControl();
            this.lblVariance = new DevExpress.XtraEditors.LabelControl();
            this.lblForecast = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdBudgetVsActual = new DevExpress.XtraGrid.GridControl();
            this.gvBudgetVsActual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariancePct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartMonthlyCost = new DevExpress.XtraCharts.ChartControl();
            this.chartActualTrend = new DevExpress.XtraCharts.ChartControl();
            this.chartCostBreakdown = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBudgetVsActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBudgetVsActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartActualTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCostBreakdown)).BeginInit();
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
            this.barMain.Text = "أدوات الموازنة مقابل التكلفة الفعلية (Budget vs Actual)";

            this.bbiRefresh.Caption = "تحديث الفعليات والموازنات";
            this.bbiExport.Caption = "تصدير تحليل Budget vs Actual";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblBudget);
            this.pnlCards.Controls.Add(this.lblActual);
            this.pnlCards.Controls.Add(this.lblVariance);
            this.pnlCards.Controls.Add(this.lblForecast);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblBudget.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBudget.Location = new System.Drawing.Point(1000, 15);
            this.lblBudget.Text = "الموازنة (Budget): 105,000,000 SAR";

            this.lblActual.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblActual.Location = new System.Drawing.Point(700, 15);
            this.lblActual.Text = "الفكلي (Actual): 42,100,000 SAR";

            this.lblVariance.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVariance.Location = new System.Drawing.Point(400, 15);
            this.lblVariance.Text = "الانحراف (Variance): +2,900,000 SAR";

            this.lblForecast.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblForecast.Location = new System.Drawing.Point(100, 15);
            this.lblForecast.Text = "التوقعات (Forecast EAC): 101,800,000 SAR";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdBudgetVsActual);
            this.splitContainerControlMain.Panel1.Text = "جدول رموز التكلفة والفرق بين الموازنة والفعلي";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerCharts);
            this.splitContainerControlMain.Panel2.Text = "مخططات التكلفة الشهرية والاتجاه والتوزيع الفعلي";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdBudgetVsActual
            this.grdBudgetVsActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBudgetVsActual.Location = new System.Drawing.Point(0, 0);
            this.grdBudgetVsActual.MainView = this.gvBudgetVsActual;
            this.grdBudgetVsActual.Name = "grdBudgetVsActual";
            this.grdBudgetVsActual.Size = new System.Drawing.Size(1200, 380);
            this.grdBudgetVsActual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvBudgetVsActual });

            // gvBudgetVsActual
            this.gvBudgetVsActual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCostCode, this.colBudget, this.colActual,
                this.colVariance, this.colVariancePct
            });
            this.gvBudgetVsActual.GridControl = this.grdBudgetVsActual;
            this.gvBudgetVsActual.Name = "gvBudgetVsActual";
            this.gvBudgetVsActual.OptionsView.ShowAutoFilterRow = true;
            this.gvBudgetVsActual.OptionsView.ShowFooter = true;

            this.colCostCode.Caption = "رمز البند والتكلفة (Cost Code)";
            this.colCostCode.FieldName = "CostCode";
            this.colCostCode.Visible = true;
            this.colCostCode.VisibleIndex = 0;

            this.colBudget.Caption = "الموازنة المخصصة (Budget)";
            this.colBudget.FieldName = "Budget";
            this.colBudget.Visible = true;
            this.colBudget.VisibleIndex = 1;

            this.colActual.Caption = "التكلفة المصروفة الفعلية (Actual)";
            this.colActual.FieldName = "Actual";
            this.colActual.Visible = true;
            this.colActual.VisibleIndex = 2;

            this.colVariance.Caption = "مقدار الانحراف المالي (Variance)";
            this.colVariance.FieldName = "Variance";
            this.colVariance.Visible = true;
            this.colVariance.VisibleIndex = 3;

            this.colVariancePct.Caption = "نسبة الانحراف %";
            this.colVariancePct.FieldName = "VariancePct";
            this.colVariancePct.Visible = true;
            this.colVariancePct.VisibleIndex = 4;

            // splitContainerCharts
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartMonthlyCost);
            this.splitContainerCharts.Panel1.Text = "التكلفة الشهري";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartActualTrend);
            this.splitContainerCharts.Panel2.Controls.Add(this.chartCostBreakdown);
            this.splitContainerCharts.Panel2.Text = "الاتجاهات والتوزيع";
            this.splitContainerCharts.Size = new System.Drawing.Size(1200, 280);
            this.splitContainerCharts.SplitterPosition = 600;

            this.chartMonthlyCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMonthlyCost.Location = new System.Drawing.Point(0, 0);
            this.chartMonthlyCost.Name = "chartMonthlyCost";
            this.chartMonthlyCost.Size = new System.Drawing.Size(600, 280);

            this.chartActualTrend.Dock = System.Windows.Forms.DockStyle.Top;
            this.chartActualTrend.Location = new System.Drawing.Point(0, 0);
            this.chartActualTrend.Name = "chartActualTrend";
            this.chartActualTrend.Size = new System.Drawing.Size(590, 140);

            this.chartCostBreakdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCostBreakdown.Location = new System.Drawing.Point(0, 140);
            this.chartCostBreakdown.Name = "chartCostBreakdown";
            this.chartCostBreakdown.Size = new System.Drawing.Size(590, 140);

            // ucBudgetVsActual
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucBudgetVsActual";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBudgetVsActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBudgetVsActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartActualTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCostBreakdown)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblBudget;
        private DevExpress.XtraEditors.LabelControl lblActual;
        private DevExpress.XtraEditors.LabelControl lblVariance;
        private DevExpress.XtraEditors.LabelControl lblForecast;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdBudgetVsActual;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBudgetVsActual;
        private DevExpress.XtraGrid.Columns.GridColumn colCostCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colActual;
        private DevExpress.XtraGrid.Columns.GridColumn colVariance;
        private DevExpress.XtraGrid.Columns.GridColumn colVariancePct;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartMonthlyCost;
        private DevExpress.XtraCharts.ChartControl chartActualTrend;
        private DevExpress.XtraCharts.ChartControl chartCostBreakdown;
    }
}
