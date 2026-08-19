namespace Etmam.Gui.CostControlMgt
{
    partial class ucCostTrendAnalysis
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
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutChartsGroup = new DevExpress.XtraLayout.LayoutControl();
            this.chartMonthlyCost = new DevExpress.XtraCharts.ChartControl();
            this.chartLaborTrend = new DevExpress.XtraCharts.ChartControl();
            this.chartMaterialTrend = new DevExpress.XtraCharts.ChartControl();
            this.chartEquipTrend = new DevExpress.XtraCharts.ChartControl();
            this.chartSubcontractTrend = new DevExpress.XtraCharts.ChartControl();
            this.RootCharts = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutMonthlyCost = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutLaborTrend = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutMaterialTrend = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutEquipTrend = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutSubcontractTrend = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdMonthlyBreakdown = new DevExpress.XtraGrid.GridControl();
            this.gvMonthlyBreakdown = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaborCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEquipCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubcontractCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalMonthlyCost = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChartsGroup)).BeginInit();
            this.layoutChartsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterialTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEquipTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSubcontractTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootCharts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMonthlyCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutLaborTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMaterialTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutEquipTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSubcontractTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonthlyBreakdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMonthlyBreakdown)).BeginInit();
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
            this.barMain.Text = "أدوات تحليل اتجاهات التكاليف Cost Trend Analysis";

            this.bbiRefresh.Caption = "تحديث اتجاهات العناصر الخمسة";
            this.bbiExport.Caption = "تصدير تحليل الاتجاهات التراكمية";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.layoutChartsGroup);
            this.splitContainerControlMain.Panel1.Text = "مخططات اتجاهات عناصر التكلفة (Labor, Material, Equipment, Subcontract)";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdMonthlyBreakdown);
            this.splitContainerControlMain.Panel2.Text = "جدول التفصيل الشهري لعناصر التكلفة (Monthly Breakdown Grid)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 450;

            // layoutChartsGroup
            this.layoutChartsGroup.Controls.Add(this.chartMonthlyCost);
            this.layoutChartsGroup.Controls.Add(this.chartLaborTrend);
            this.layoutChartsGroup.Controls.Add(this.chartMaterialTrend);
            this.layoutChartsGroup.Controls.Add(this.chartEquipTrend);
            this.layoutChartsGroup.Controls.Add(this.chartSubcontractTrend);
            this.layoutChartsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutChartsGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutChartsGroup.Name = "layoutChartsGroup";
            this.layoutChartsGroup.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutChartsGroup.Root = this.RootCharts;
            this.layoutChartsGroup.Size = new System.Drawing.Size(1200, 450);

            // RootCharts
            this.RootCharts.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootCharts.GroupBordersVisible = false;
            this.RootCharts.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutMonthlyCost,
                this.layoutLaborTrend,
                this.layoutMaterialTrend,
                this.layoutEquipTrend,
                this.layoutSubcontractTrend
            });
            this.RootCharts.Name = "RootCharts";
            this.RootCharts.Size = new System.Drawing.Size(1200, 450);

            this.layoutMonthlyCost.Control = this.chartMonthlyCost;
            this.layoutMonthlyCost.Name = "layoutMonthlyCost";
            this.layoutMonthlyCost.Size = new System.Drawing.Size(236, 430);
            this.layoutMonthlyCost.Text = "التكلفة الشهرية الكلية";

            this.layoutLaborTrend.Control = this.chartLaborTrend;
            this.layoutLaborTrend.Name = "layoutLaborTrend";
            this.layoutLaborTrend.Size = new System.Drawing.Size(236, 430);
            this.layoutLaborTrend.Text = "اتجاه تكلفة العمالة (Labor)";

            this.layoutMaterialTrend.Control = this.chartMaterialTrend;
            this.layoutMaterialTrend.Name = "layoutMaterialTrend";
            this.layoutMaterialTrend.Size = new System.Drawing.Size(236, 430);
            this.layoutMaterialTrend.Text = "اتجاه تكلفة المواد (Material)";

            this.layoutEquipTrend.Control = this.chartEquipTrend;
            this.layoutEquipTrend.Name = "layoutEquipTrend";
            this.layoutEquipTrend.Size = new System.Drawing.Size(236, 430);
            this.layoutEquipTrend.Text = "اتجاه تكلفة المعدات (Equipment)";

            this.layoutSubcontractTrend.Control = this.chartSubcontractTrend;
            this.layoutSubcontractTrend.Name = "layoutSubcontractTrend";
            this.layoutSubcontractTrend.Size = new System.Drawing.Size(236, 430);
            this.layoutSubcontractTrend.Text = "اتجاه مقاولي الباطن (Subcontract)";

            // grdMonthlyBreakdown
            this.grdMonthlyBreakdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMonthlyBreakdown.Location = new System.Drawing.Point(0, 0);
            this.grdMonthlyBreakdown.MainView = this.gvMonthlyBreakdown;
            this.grdMonthlyBreakdown.Name = "grdMonthlyBreakdown";
            this.grdMonthlyBreakdown.Size = new System.Drawing.Size(1200, 260);
            this.grdMonthlyBreakdown.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvMonthlyBreakdown });

            // gvMonthlyBreakdown
            this.gvMonthlyBreakdown.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colMonth, this.colLaborCost, this.colMaterialCost,
                this.colEquipCost, this.colSubcontractCost, this.colTotalMonthlyCost
            });
            this.gvMonthlyBreakdown.GridControl = this.grdMonthlyBreakdown;
            this.gvMonthlyBreakdown.Name = "gvMonthlyBreakdown";
            this.gvMonthlyBreakdown.OptionsView.ShowAutoFilterRow = true;
            this.gvMonthlyBreakdown.OptionsView.ShowFooter = true;

            this.colMonth.Caption = "الشهر والفترة التقريرية";
            this.colMonth.FieldName = "Month";
            this.colMonth.Visible = true;
            this.colMonth.VisibleIndex = 0;

            this.colLaborCost.Caption = "تكلفة العمالة المباشرة (Labor)";
            this.colLaborCost.FieldName = "LaborCost";
            this.colLaborCost.Visible = true;
            this.colLaborCost.VisibleIndex = 1;

            this.colMaterialCost.Caption = "تكلفة التوريدات والمواد (Material)";
            this.colMaterialCost.FieldName = "MaterialCost";
            this.colMaterialCost.Visible = true;
            this.colMaterialCost.VisibleIndex = 2;

            this.colEquipCost.Caption = "تكلفة تشغيل وتأجير المعدات (Equipment)";
            this.colEquipCost.FieldName = "EquipCost";
            this.colEquipCost.Visible = true;
            this.colEquipCost.VisibleIndex = 3;

            this.colSubcontractCost.Caption = "مستخلصات مقاولي الباطن (Subcontract)";
            this.colSubcontractCost.FieldName = "SubcontractCost";
            this.colSubcontractCost.Visible = true;
            this.colSubcontractCost.VisibleIndex = 4;

            this.colTotalMonthlyCost.Caption = "إجمالي التكلفة الشهري الصافية";
            this.colTotalMonthlyCost.FieldName = "TotalMonthlyCost";
            this.colTotalMonthlyCost.Visible = true;
            this.colTotalMonthlyCost.VisibleIndex = 5;

            // ucCostTrendAnalysis
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCostTrendAnalysis";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutChartsGroup)).EndInit();
            this.layoutChartsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterialTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEquipTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSubcontractTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootCharts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMonthlyCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutLaborTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMaterialTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutEquipTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSubcontractTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonthlyBreakdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMonthlyBreakdown)).EndInit();
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
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraLayout.LayoutControl layoutChartsGroup;
        private DevExpress.XtraCharts.ChartControl chartMonthlyCost;
        private DevExpress.XtraCharts.ChartControl chartLaborTrend;
        private DevExpress.XtraCharts.ChartControl chartMaterialTrend;
        private DevExpress.XtraCharts.ChartControl chartEquipTrend;
        private DevExpress.XtraCharts.ChartControl chartSubcontractTrend;
        private DevExpress.XtraLayout.LayoutControlGroup RootCharts;
        private DevExpress.XtraLayout.LayoutControlItem layoutMonthlyCost;
        private DevExpress.XtraLayout.LayoutControlItem layoutLaborTrend;
        private DevExpress.XtraLayout.LayoutControlItem layoutMaterialTrend;
        private DevExpress.XtraLayout.LayoutControlItem layoutEquipTrend;
        private DevExpress.XtraLayout.LayoutControlItem layoutSubcontractTrend;
        private DevExpress.XtraGrid.GridControl grdMonthlyBreakdown;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMonthlyBreakdown;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colLaborCost;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialCost;
        private DevExpress.XtraGrid.Columns.GridColumn colEquipCost;
        private DevExpress.XtraGrid.Columns.GridColumn colSubcontractCost;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalMonthlyCost;
    }
}
