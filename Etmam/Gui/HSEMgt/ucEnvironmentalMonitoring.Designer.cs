namespace Etmam.Gui.HSEMgt
{
    partial class ucEnvironmentalMonitoring
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
            this.bbiNewReading = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblNoise = new DevExpress.XtraEditors.LabelControl();
            this.lblDust = new DevExpress.XtraEditors.LabelControl();
            this.lblWaste = new DevExpress.XtraEditors.LabelControl();
            this.lblWater = new DevExpress.XtraEditors.LabelControl();
            this.lblAirQuality = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdEnv = new DevExpress.XtraGrid.GridControl();
            this.gvEnv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colParameter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartDailyReadings = new DevExpress.XtraCharts.ChartControl();
            this.chartMonthlyTrend = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEnv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyReadings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyTrend)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewReading, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewReading),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل وقراءات الرصد البيئي";

            this.bbiNewReading.Caption = "إدخال قراءة بيئية جديدة";
            this.bbiExport.Caption = "تصدير تقرير الرصد البيئي";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblNoise);
            this.pnlCards.Controls.Add(this.lblDust);
            this.pnlCards.Controls.Add(this.lblWaste);
            this.pnlCards.Controls.Add(this.lblWater);
            this.pnlCards.Controls.Add(this.lblAirQuality);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblNoise.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNoise.Location = new System.Drawing.Point(1000, 15);
            this.lblNoise.Text = "الضوضاء: 68 dB";

            this.lblDust.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDust.Location = new System.Drawing.Point(800, 15);
            this.lblDust.Text = "الأغبرة (Dust): Normal";

            this.lblWaste.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblWaste.Location = new System.Drawing.Point(580, 15);
            this.lblWaste.Text = "إدارة المخلفات: 45 Ton";

            this.lblWater.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblWater.Location = new System.Drawing.Point(380, 15);
            this.lblWater.Text = "المياه الصرف: Compliant";

            this.lblAirQuality.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAirQuality.Location = new System.Drawing.Point(120, 15);
            this.lblAirQuality.Text = "جودة الهواء: AQI 42 (Good)";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdEnv);
            this.splitContainerControlMain.Panel1.Text = "جدول قياسات الرصد البيئي";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerCharts);
            this.splitContainerControlMain.Panel2.Text = "مخططات القراءات اليومية والاتجاهات الشهرية";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdEnv
            this.grdEnv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEnv.Location = new System.Drawing.Point(0, 0);
            this.grdEnv.MainView = this.gvEnv;
            this.grdEnv.Name = "grdEnv";
            this.grdEnv.Size = new System.Drawing.Size(1200, 380);
            this.grdEnv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvEnv });

            // gvEnv
            this.gvEnv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colParameter, this.colReading, this.colLimit, this.colStatus
            });
            this.gvEnv.GridControl = this.grdEnv;
            this.gvEnv.Name = "gvEnv";
            this.gvEnv.OptionsView.ShowAutoFilterRow = true;
            this.gvEnv.OptionsView.ShowFooter = true;

            this.colParameter.Caption = "المعيار البيئي الرصد (Parameter)";
            this.colParameter.FieldName = "Parameter";
            this.colParameter.Visible = true;
            this.colParameter.VisibleIndex = 0;

            this.colReading.Caption = "القراءة الميدانية المسجلة";
            this.colReading.FieldName = "Reading";
            this.colReading.Visible = true;
            this.colReading.VisibleIndex = 1;

            this.colLimit.Caption = "الحد الأقصى المسموح (OSHA/ISO Limit)";
            this.colLimit.FieldName = "Limit";
            this.colLimit.Visible = true;
            this.colLimit.VisibleIndex = 2;

            this.colStatus.Caption = "حالة المطابقة والامتثال";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;

            // splitContainerCharts
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartDailyReadings);
            this.splitContainerCharts.Panel1.Text = "قراءات اليوم";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartMonthlyTrend);
            this.splitContainerCharts.Panel2.Text = "اتجاهات الشهر";
            this.splitContainerCharts.Size = new System.Drawing.Size(1200, 280);
            this.splitContainerCharts.SplitterPosition = 600;

            this.chartDailyReadings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDailyReadings.Location = new System.Drawing.Point(0, 0);
            this.chartDailyReadings.Name = "chartDailyReadings";
            this.chartDailyReadings.Size = new System.Drawing.Size(600, 280);

            this.chartMonthlyTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMonthlyTrend.Location = new System.Drawing.Point(0, 0);
            this.chartMonthlyTrend.Name = "chartMonthlyTrend";
            this.chartMonthlyTrend.Size = new System.Drawing.Size(590, 280);

            // ucEnvironmentalMonitoring
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucEnvironmentalMonitoring";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEnv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyReadings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyTrend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewReading;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblNoise;
        private DevExpress.XtraEditors.LabelControl lblDust;
        private DevExpress.XtraEditors.LabelControl lblWaste;
        private DevExpress.XtraEditors.LabelControl lblWater;
        private DevExpress.XtraEditors.LabelControl lblAirQuality;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdEnv;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEnv;
        private DevExpress.XtraGrid.Columns.GridColumn colParameter;
        private DevExpress.XtraGrid.Columns.GridColumn colReading;
        private DevExpress.XtraGrid.Columns.GridColumn colLimit;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartDailyReadings;
        private DevExpress.XtraCharts.ChartControl chartMonthlyTrend;
    }
}
