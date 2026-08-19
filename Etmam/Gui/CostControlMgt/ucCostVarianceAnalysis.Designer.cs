namespace Etmam.Gui.CostControlMgt
{
    partial class ucCostVarianceAnalysis
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
            this.lblPosVariance = new DevExpress.XtraEditors.LabelControl();
            this.lblNegVariance = new DevExpress.XtraEditors.LabelControl();
            this.lblHighRisk = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdVariance = new DevExpress.XtraGrid.GridControl();
            this.gvVariance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForecast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRootCause = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartVarianceTrend = new DevExpress.XtraCharts.ChartControl();
            this.chartVarianceByCostCode = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVariance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVariance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVarianceTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVarianceByCostCode)).BeginInit();
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
            this.barMain.Text = "أدوات تحليل انحرافات التكاليف Cost Variance Analysis";

            this.bbiRefresh.Caption = "تحديث انحرافات رموز التكلفة";
            this.bbiExport.Caption = "تصدير سجل الانحرافات والـ Root Cause";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblPosVariance);
            this.pnlCards.Controls.Add(this.lblNegVariance);
            this.pnlCards.Controls.Add(this.lblHighRisk);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblPosVariance.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPosVariance.Location = new System.Drawing.Point(950, 15);
            this.lblPosVariance.Text = "انحراف إيجابي (وفر في التكلفة): +4.2M SAR";

            this.lblNegVariance.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNegVariance.Location = new System.Drawing.Point(580, 15);
            this.lblNegVariance.Text = "انحراف سلبي (تجاوز بالموازنة): -1.3M SAR";

            this.lblHighRisk.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHighRisk.Location = new System.Drawing.Point(220, 15);
            this.lblHighRisk.Text = "بنود عالية الانحراف والتأثير: 3 Cost Codes";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdVariance);
            this.splitContainerControlMain.Panel1.Text = "جدول تحليل انحراف رموز التكلفة وأسباب الوقوع Root Cause";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerCharts);
            this.splitContainerControlMain.Panel2.Text = "مخططات اتجاهات وتوزيع الانحرافات المالي";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdVariance
            this.grdVariance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVariance.Location = new System.Drawing.Point(0, 0);
            this.grdVariance.MainView = this.gvVariance;
            this.grdVariance.Name = "grdVariance";
            this.grdVariance.Size = new System.Drawing.Size(1200, 380);
            this.grdVariance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvVariance });

            // gvVariance
            this.gvVariance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCostCode, this.colBudget, this.colActual,
                this.colForecast, this.colVariance, this.colRootCause
            });
            this.gvVariance.GridControl = this.grdVariance;
            this.gvVariance.Name = "gvVariance";
            this.gvVariance.OptionsView.ShowAutoFilterRow = true;
            this.gvVariance.OptionsView.ShowFooter = true;

            this.colCostCode.Caption = "رمز التكلفة والوصف (Cost Code)";
            this.colCostCode.FieldName = "CostCode";
            this.colCostCode.Visible = true;
            this.colCostCode.VisibleIndex = 0;

            this.colBudget.Caption = "الموازنة الأصلية (Budget)";
            this.colBudget.FieldName = "Budget";
            this.colBudget.Visible = true;
            this.colBudget.VisibleIndex = 1;

            this.colActual.Caption = "التكلفة المصروفة (Actual)";
            this.colActual.FieldName = "Actual";
            this.colActual.Visible = true;
            this.colActual.VisibleIndex = 2;

            this.colForecast.Caption = "التوقعات الختامية (Forecast EAC)";
            this.colForecast.FieldName = "Forecast";
            this.colForecast.Visible = true;
            this.colForecast.VisibleIndex = 3;

            this.colVariance.Caption = "مبلغ الانحراف (Variance)";
            this.colVariance.FieldName = "Variance";
            this.colVariance.Visible = true;
            this.colVariance.VisibleIndex = 4;

            this.colRootCause.Caption = "تحليل السبب الرئيسي للانحراف (Root Cause)";
            this.colRootCause.FieldName = "RootCause";
            this.colRootCause.Visible = true;
            this.colRootCause.VisibleIndex = 5;

            // splitContainerCharts
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartVarianceTrend);
            this.splitContainerCharts.Panel1.Text = "اتجاه الانحراف المالي";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartVarianceByCostCode);
            this.splitContainerCharts.Panel2.Text = "توزيع الانحراف حسب الرموز";
            this.splitContainerCharts.Size = new System.Drawing.Size(1200, 280);
            this.splitContainerCharts.SplitterPosition = 600;

            this.chartVarianceTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVarianceTrend.Location = new System.Drawing.Point(0, 0);
            this.chartVarianceTrend.Name = "chartVarianceTrend";
            this.chartVarianceTrend.Size = new System.Drawing.Size(600, 280);

            this.chartVarianceByCostCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVarianceByCostCode.Location = new System.Drawing.Point(0, 0);
            this.chartVarianceByCostCode.Name = "chartVarianceByCostCode";
            this.chartVarianceByCostCode.Size = new System.Drawing.Size(590, 280);

            // ucCostVarianceAnalysis
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCostVarianceAnalysis";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVariance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVariance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVarianceTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVarianceByCostCode)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblPosVariance;
        private DevExpress.XtraEditors.LabelControl lblNegVariance;
        private DevExpress.XtraEditors.LabelControl lblHighRisk;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdVariance;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVariance;
        private DevExpress.XtraGrid.Columns.GridColumn colCostCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colActual;
        private DevExpress.XtraGrid.Columns.GridColumn colForecast;
        private DevExpress.XtraGrid.Columns.GridColumn colVariance;
        private DevExpress.XtraGrid.Columns.GridColumn colRootCause;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartVarianceTrend;
        private DevExpress.XtraCharts.ChartControl chartVarianceByCostCode;
    }
}
