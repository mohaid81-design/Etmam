namespace Etmam.Gui.ContractMgt
{
    partial class ucExtensionOfTime
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
            this.bbiNewEOT = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApproveEOT = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            this.lblPendingEOT = new DevExpress.XtraEditors.LabelControl();
            this.lblApprovedDays = new DevExpress.XtraEditors.LabelControl();
            this.lblRejectedDays = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdEOT = new DevExpress.XtraGrid.GridControl();
            this.gvEOT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEOTNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCause = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestedDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApprovedDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartDelayCategories = new DevExpress.XtraCharts.ChartControl();
            this.chartDelayTimeline = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).BeginInit();
            this.pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDelayCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDelayTimeline)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewEOT, this.bbiApproveEOT, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewEOT),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiApproveEOT),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات تمديد الوقت EOT";

            this.bbiNewEOT.Caption = "طلب تمديد جديد";
            this.bbiApproveEOT.Caption = "اعتماد الأيام المصرح بها";
            this.bbiPrint.Caption = "طباعة التقرير";

            // pnlKpiCards
            this.pnlKpiCards.Controls.Add(this.lblPendingEOT);
            this.pnlKpiCards.Controls.Add(this.lblApprovedDays);
            this.pnlKpiCards.Controls.Add(this.lblRejectedDays);
            this.pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiCards.Location = new System.Drawing.Point(0, 30);
            this.pnlKpiCards.Name = "pnlKpiCards";
            this.pnlKpiCards.Size = new System.Drawing.Size(1200, 50);

            this.lblPendingEOT.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPendingEOT.Location = new System.Drawing.Point(1000, 15);
            this.lblPendingEOT.Text = "الطلبات قيد الدراسة: 2";

            this.lblApprovedDays.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApprovedDays.Location = new System.Drawing.Point(700, 15);
            this.lblApprovedDays.Text = "إجمالي الأيام المعتمدة: 45 يوماً";

            this.lblRejectedDays.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRejectedDays.Location = new System.Drawing.Point(400, 15);
            this.lblRejectedDays.Text = "الأيام المرفوضة: 15 يوماً";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdEOT);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerCharts);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 400;

            // grdEOT
            this.grdEOT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEOT.Location = new System.Drawing.Point(0, 0);
            this.grdEOT.MainView = this.gvEOT;
            this.grdEOT.Name = "grdEOT";
            this.grdEOT.Size = new System.Drawing.Size(1200, 400);
            this.grdEOT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvEOT });

            // gvEOT
            this.gvEOT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colEOTNo, this.colCause, this.colRequestedDays,
                this.colApprovedDays, this.colStatus
            });
            this.gvEOT.GridControl = this.grdEOT;
            this.gvEOT.Name = "gvEOT";

            this.colEOTNo.Caption = "رقم طلب EOT";
            this.colEOTNo.FieldName = "EOTNo";
            this.colEOTNo.Visible = true;
            this.colEOTNo.VisibleIndex = 0;

            this.colCause.Caption = "سبب التأخير والحدث المباشر";
            this.colCause.FieldName = "Cause";
            this.colCause.Visible = true;
            this.colCause.VisibleIndex = 1;

            this.colRequestedDays.Caption = "الأيام المطلوبة";
            this.colRequestedDays.FieldName = "RequestedDays";
            this.colRequestedDays.Visible = true;
            this.colRequestedDays.VisibleIndex = 2;

            this.colApprovedDays.Caption = "الأيام المعتمدة رسمياً";
            this.colApprovedDays.FieldName = "ApprovedDays";
            this.colApprovedDays.Visible = true;
            this.colApprovedDays.VisibleIndex = 3;

            this.colStatus.Caption = "الحالة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            // splitContainerCharts
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartDelayCategories);
            this.splitContainerCharts.Panel1.Text = "Panel1";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartDelayTimeline);
            this.splitContainerCharts.Panel2.Text = "Panel2";
            this.splitContainerCharts.Size = new System.Drawing.Size(1200, 260);
            this.splitContainerCharts.SplitterPosition = 600;

            this.chartDelayCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDelayCategories.Location = new System.Drawing.Point(0, 0);
            this.chartDelayCategories.Name = "chartDelayCategories";
            this.chartDelayCategories.Size = new System.Drawing.Size(600, 260);

            this.chartDelayTimeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDelayTimeline.Location = new System.Drawing.Point(0, 0);
            this.chartDelayTimeline.Name = "chartDelayTimeline";
            this.chartDelayTimeline.Size = new System.Drawing.Size(590, 260);

            // ucExtensionOfTime
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlKpiCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucExtensionOfTime";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).EndInit();
            this.pnlKpiCards.ResumeLayout(false);
            this.pnlKpiCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDelayCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDelayTimeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewEOT;
        private DevExpress.XtraBars.BarButtonItem bbiApproveEOT;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.LabelControl lblPendingEOT;
        private DevExpress.XtraEditors.LabelControl lblApprovedDays;
        private DevExpress.XtraEditors.LabelControl lblRejectedDays;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdEOT;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEOT;
        private DevExpress.XtraGrid.Columns.GridColumn colEOTNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCause;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestedDays;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovedDays;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartDelayCategories;
        private DevExpress.XtraCharts.ChartControl chartDelayTimeline;
    }
}
