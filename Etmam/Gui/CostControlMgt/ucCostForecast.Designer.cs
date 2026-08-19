namespace Etmam.Gui.CostControlMgt
{
    partial class ucCostForecast
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
            this.bbiUpdateForecast = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblEAC = new DevExpress.XtraEditors.LabelControl();
            this.lblETC = new DevExpress.XtraEditors.LabelControl();
            this.lblVAC = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdForecast = new DevExpress.XtraGrid.GridControl();
            this.gvForecast = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colScenario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForecastEac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfidence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartForecastTrend = new DevExpress.XtraCharts.ChartControl();
            this.chartCompletionForecast = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartForecastTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCompletionForecast)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiUpdateForecast, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiUpdateForecast),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات توقعات التكلفة عند الإكمال (EAC / ETC)";

            this.bbiUpdateForecast.Caption = "تحديث افتراضات وتوقعات EAC";
            this.bbiExport.Caption = "تصدير تقرير التوقعات";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblEAC);
            this.pnlCards.Controls.Add(this.lblETC);
            this.pnlCards.Controls.Add(this.lblVAC);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblEAC.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEAC.Location = new System.Drawing.Point(950, 15);
            this.lblEAC.Text = "التكلفة التقديرية عند الإكمال (EAC): 101.8M SAR";

            this.lblETC.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblETC.Location = new System.Drawing.Point(580, 15);
            this.lblETC.Text = "التكلفة المتبقية للإكمال (ETC): 59.7M SAR";

            this.lblVAC.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVAC.Location = new System.Drawing.Point(220, 15);
            this.lblVAC.Text = "انحراف الإكمال المستهدف (VAC): +3.2M SAR";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdForecast);
            this.splitContainerControlMain.Panel1.Text = "جدول سيناريوهات وتوقعات التكلفة الختامية";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerCharts);
            this.splitContainerControlMain.Panel2.Text = "مخطط الاتجاهات وتاريخ الإكمال المتوقع";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdForecast
            this.grdForecast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdForecast.Location = new System.Drawing.Point(0, 0);
            this.grdForecast.MainView = this.gvForecast;
            this.grdForecast.Name = "grdForecast";
            this.grdForecast.Size = new System.Drawing.Size(1200, 380);
            this.grdForecast.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvForecast });

            // gvForecast
            this.gvForecast.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colScenario, this.colForecastEac, this.colConfidence, this.colVariance
            });
            this.gvForecast.GridControl = this.grdForecast;
            this.gvForecast.Name = "gvForecast";
            this.gvForecast.OptionsView.ShowAutoFilterRow = true;
            this.gvForecast.OptionsView.ShowFooter = true;

            this.colScenario.Caption = "سيناريو التوقعات (Best Case / Likely / Worst Case)";
            this.colScenario.FieldName = "Scenario";
            this.colScenario.Visible = true;
            this.colScenario.VisibleIndex = 0;

            this.colForecastEac.Caption = "التكلفة التقديرية (Forecast EAC)";
            this.colForecastEac.FieldName = "ForecastEac";
            this.colForecastEac.Visible = true;
            this.colForecastEac.VisibleIndex = 1;

            this.colConfidence.Caption = "مستوى الثقة % (Confidence Level)";
            this.colConfidence.FieldName = "Confidence";
            this.colConfidence.Visible = true;
            this.colConfidence.VisibleIndex = 2;

            this.colVariance.Caption = "الانحراف عن الموازنة الأصلية (Variance)";
            this.colVariance.FieldName = "Variance";
            this.colVariance.Visible = true;
            this.colVariance.VisibleIndex = 3;

            // splitContainerCharts
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartForecastTrend);
            this.splitContainerCharts.Panel1.Text = "اتجاه التوقعات";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartCompletionForecast);
            this.splitContainerCharts.Panel2.Text = "توقع تاريخ الإكمال";
            this.splitContainerCharts.Size = new System.Drawing.Size(1200, 280);
            this.splitContainerCharts.SplitterPosition = 600;

            this.chartForecastTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartForecastTrend.Location = new System.Drawing.Point(0, 0);
            this.chartForecastTrend.Name = "chartForecastTrend";
            this.chartForecastTrend.Size = new System.Drawing.Size(600, 280);

            this.chartCompletionForecast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCompletionForecast.Location = new System.Drawing.Point(0, 0);
            this.chartCompletionForecast.Name = "chartCompletionForecast";
            this.chartCompletionForecast.Size = new System.Drawing.Size(590, 280);

            // ucCostForecast
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCostForecast";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartForecastTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCompletionForecast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiUpdateForecast;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblEAC;
        private DevExpress.XtraEditors.LabelControl lblETC;
        private DevExpress.XtraEditors.LabelControl lblVAC;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdForecast;
        private DevExpress.XtraGrid.Views.Grid.GridView gvForecast;
        private DevExpress.XtraGrid.Columns.GridColumn colScenario;
        private DevExpress.XtraGrid.Columns.GridColumn colForecastEac;
        private DevExpress.XtraGrid.Columns.GridColumn colConfidence;
        private DevExpress.XtraGrid.Columns.GridColumn colVariance;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartForecastTrend;
        private DevExpress.XtraCharts.ChartControl chartCompletionForecast;
    }
}
