namespace Etmam.Gui.CostControlMgt
{
    partial class ucEarnedValueManagement
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
            this.bbiRecalculateEvm = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            this.lblPV = new DevExpress.XtraEditors.LabelControl();
            this.lblEV = new DevExpress.XtraEditors.LabelControl();
            this.lblAC = new DevExpress.XtraEditors.LabelControl();
            this.cardCPI = new DevExpress.XtraEditors.LabelControl();
            this.cardSPI = new DevExpress.XtraEditors.LabelControl();
            this.lblBAC = new DevExpress.XtraEditors.LabelControl();
            this.lblEAC = new DevExpress.XtraEditors.LabelControl();
            this.lblETC = new DevExpress.XtraEditors.LabelControl();
            this.lblVAC = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdEVM = new DevExpress.XtraGrid.GridControl();
            this.gvEVM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWBS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartSCurve = new DevExpress.XtraCharts.ChartControl();
            this.chartCpiSpiTrend = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).BeginInit();
            this.pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEVM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEVM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCpiSpiTrend)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiRecalculateEvm, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRecalculateEvm),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات إدارة القيمة المكتسبة Earned Value Management (EVM)";

            this.bbiRecalculateEvm.Caption = "إعادة حساب مؤشرات EVM";
            this.bbiExport.Caption = "تصدير تقرير EVM التفصيلي";

            // pnlKpiCards
            this.pnlKpiCards.Controls.Add(this.lblPV);
            this.pnlKpiCards.Controls.Add(this.lblEV);
            this.pnlKpiCards.Controls.Add(this.lblAC);
            this.pnlKpiCards.Controls.Add(this.cardCPI);
            this.pnlKpiCards.Controls.Add(this.cardSPI);
            this.pnlKpiCards.Controls.Add(this.lblBAC);
            this.pnlKpiCards.Controls.Add(this.lblEAC);
            this.pnlKpiCards.Controls.Add(this.lblETC);
            this.pnlKpiCards.Controls.Add(this.lblVAC);
            this.pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiCards.Location = new System.Drawing.Point(0, 30);
            this.pnlKpiCards.Name = "pnlKpiCards";
            this.pnlKpiCards.Size = new System.Drawing.Size(1200, 70);

            this.lblPV.Text = "PV: 46.2M";
            this.lblPV.Location = new System.Drawing.Point(1080, 15);
            this.lblPV.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);

            this.lblEV.Text = "EV: 45.0M";
            this.lblEV.Location = new System.Drawing.Point(970, 15);
            this.lblEV.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);

            this.lblAC.Text = "AC: 42.1M";
            this.lblAC.Location = new System.Drawing.Point(860, 15);
            this.lblAC.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);

            this.cardCPI.Text = "CPI Index: 1.07 (Good)";
            this.cardCPI.Location = new System.Drawing.Point(710, 15);
            this.cardCPI.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);

            this.cardSPI.Text = "SPI Index: 0.97 (Minor Lag)";
            this.cardSPI.Location = new System.Drawing.Point(520, 15);
            this.cardSPI.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);

            this.lblBAC.Text = "BAC: 105.0M";
            this.lblBAC.Location = new System.Drawing.Point(400, 15);
            this.lblBAC.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);

            this.lblEAC.Text = "EAC: 98.1M";
            this.lblEAC.Location = new System.Drawing.Point(280, 15);
            this.lblEAC.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);

            this.lblETC.Text = "ETC: 56.0M";
            this.lblETC.Location = new System.Drawing.Point(170, 15);
            this.lblETC.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);

            this.lblVAC.Text = "VAC: +6.9M";
            this.lblVAC.Location = new System.Drawing.Point(60, 15);
            this.lblVAC.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 100);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdEVM);
            this.splitContainerControlMain.Panel1.Text = "جدول EVM حسب مستويات الـ WBS ورموز التكلفة";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerCharts);
            this.splitContainerControlMain.Panel2.Text = "مخططات S-Curve واتجاهات CPI & SPI";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 650);
            this.splitContainerControlMain.SplitterPosition = 360;

            // grdEVM
            this.grdEVM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEVM.Location = new System.Drawing.Point(0, 0);
            this.grdEVM.MainView = this.gvEVM;
            this.grdEVM.Name = "grdEVM";
            this.grdEVM.Size = new System.Drawing.Size(1200, 360);
            this.grdEVM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvEVM });

            // gvEVM
            this.gvEVM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colWBS, this.colPV, this.colEV,
                this.colAC, this.colCPI, this.colSPI
            });
            this.gvEVM.GridControl = this.grdEVM;
            this.gvEVM.Name = "gvEVM";
            this.gvEVM.OptionsView.ShowAutoFilterRow = true;
            this.gvEVM.OptionsView.ShowFooter = true;

            this.colWBS.Caption = "حزمة العمل (WBS / Cost Code)";
            this.colWBS.FieldName = "WBS";
            this.colWBS.Visible = true;
            this.colWBS.VisibleIndex = 0;

            this.colPV.Caption = "القيمة المخططة (Planned Value - PV)";
            this.colPV.FieldName = "PV";
            this.colPV.Visible = true;
            this.colPV.VisibleIndex = 1;

            this.colEV.Caption = "القيمة المكتسبة (Earned Value - EV)";
            this.colEV.FieldName = "EV";
            this.colEV.Visible = true;
            this.colEV.VisibleIndex = 2;

            this.colAC.Caption = "التكلفة الفعلية (Actual Cost - AC)";
            this.colAC.FieldName = "AC";
            this.colAC.Visible = true;
            this.colAC.VisibleIndex = 3;

            this.colCPI.Caption = "مؤشر أداء التكلفة (CPI)";
            this.colCPI.FieldName = "CPI";
            this.colCPI.Visible = true;
            this.colCPI.VisibleIndex = 4;

            this.colSPI.Caption = "مؤشر أداء الجدول (SPI)";
            this.colSPI.FieldName = "SPI";
            this.colSPI.Visible = true;
            this.colSPI.VisibleIndex = 5;

            // splitContainerCharts
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartSCurve);
            this.splitContainerCharts.Panel1.Text = "منحنى الـ S-Curve";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartCpiSpiTrend);
            this.splitContainerCharts.Panel2.Text = "اتجاهات CPI و SPI";
            this.splitContainerCharts.Size = new System.Drawing.Size(1200, 280);
            this.splitContainerCharts.SplitterPosition = 650;

            this.chartSCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSCurve.Location = new System.Drawing.Point(0, 0);
            this.chartSCurve.Name = "chartSCurve";
            this.chartSCurve.Size = new System.Drawing.Size(650, 280);

            this.chartCpiSpiTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCpiSpiTrend.Location = new System.Drawing.Point(0, 0);
            this.chartCpiSpiTrend.Name = "chartCpiSpiTrend";
            this.chartCpiSpiTrend.Size = new System.Drawing.Size(540, 280);

            // ucEarnedValueManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlKpiCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucEarnedValueManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).EndInit();
            this.pnlKpiCards.ResumeLayout(false);
            this.pnlKpiCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEVM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEVM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCpiSpiTrend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiRecalculateEvm;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.LabelControl lblPV;
        private DevExpress.XtraEditors.LabelControl lblEV;
        private DevExpress.XtraEditors.LabelControl lblAC;
        private DevExpress.XtraEditors.LabelControl cardCPI;
        private DevExpress.XtraEditors.LabelControl cardSPI;
        private DevExpress.XtraEditors.LabelControl lblBAC;
        private DevExpress.XtraEditors.LabelControl lblEAC;
        private DevExpress.XtraEditors.LabelControl lblETC;
        private DevExpress.XtraEditors.LabelControl lblVAC;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdEVM;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEVM;
        private DevExpress.XtraGrid.Columns.GridColumn colWBS;
        private DevExpress.XtraGrid.Columns.GridColumn colPV;
        private DevExpress.XtraGrid.Columns.GridColumn colEV;
        private DevExpress.XtraGrid.Columns.GridColumn colAC;
        private DevExpress.XtraGrid.Columns.GridColumn colCPI;
        private DevExpress.XtraGrid.Columns.GridColumn colSPI;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartSCurve;
        private DevExpress.XtraCharts.ChartControl chartCpiSpiTrend;
    }
}
