namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucMailboxSyncMonitor
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
            this.bbiSyncNow = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRetryFailed = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSettings = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblLastSync = new DevExpress.XtraEditors.LabelControl();
            this.lblSuccessfulSync = new DevExpress.XtraEditors.LabelControl();
            this.lblFailedSync = new DevExpress.XtraEditors.LabelControl();
            this.lblPendingItems = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdSync = new DevExpress.XtraGrid.GridControl();
            this.gvSync = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMailbox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFolder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastSync = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControlCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartSyncTrend = new DevExpress.XtraCharts.ChartControl();
            this.chartSyncDuration = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlCharts)).BeginInit();
            this.splitContainerControlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSyncTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSyncDuration)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiSyncNow, this.bbiRetryFailed, this.bbiSettings
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSyncNow),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRetryFailed),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSettings)
            });
            this.barMain.Text = "أدوات مراقب مزامنة صناديق البريد";

            this.bbiSyncNow.Caption = "مزامنة فورية الآن (Sync Now)";
            this.bbiRetryFailed.Caption = "إعادة محاولة الفاشلة (Retry)";
            this.bbiSettings.Caption = "إعدادات الاتصال والـ OAuth";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblLastSync);
            this.pnlCards.Controls.Add(this.lblSuccessfulSync);
            this.pnlCards.Controls.Add(this.lblFailedSync);
            this.pnlCards.Controls.Add(this.lblPendingItems);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblLastSync.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLastSync.Location = new System.Drawing.Point(950, 15);
            this.lblLastSync.Text = "آخر مزامنة ناجحة: 2026-08-06 21:40";

            this.lblSuccessfulSync.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSuccessfulSync.Location = new System.Drawing.Point(680, 15);
            this.lblSuccessfulSync.Text = "عمليات ناجحة: 1,420";

            this.lblFailedSync.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFailedSync.Location = new System.Drawing.Point(440, 15);
            this.lblFailedSync.Text = "عمليات فاشلة: 0";

            this.lblPendingItems.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPendingItems.Location = new System.Drawing.Point(180, 15);
            this.lblPendingItems.Text = "عناصر بالانتظار: 2";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdSync);
            this.splitContainerControlMain.Panel1.Text = "سجل مراقبة مزامنة صناديق البريد";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerControlCharts);
            this.splitContainerControlMain.Panel2.Text = "تحليلات الأداء وزمن المزامنة";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 400;

            // grdSync
            this.grdSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSync.Location = new System.Drawing.Point(0, 0);
            this.grdSync.MainView = this.gvSync;
            this.grdSync.Name = "grdSync";
            this.grdSync.Size = new System.Drawing.Size(1200, 400);
            this.grdSync.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvSync });

            // gvSync
            this.gvSync.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colMailbox, this.colFolder, this.colLastSync,
                this.colStatus, this.colErrorMessage
            });
            this.gvSync.GridControl = this.grdSync;
            this.gvSync.Name = "gvSync";
            this.gvSync.OptionsView.ShowAutoFilterRow = true;
            this.gvSync.OptionsView.ShowFooter = true;

            this.colMailbox.Caption = "صندوق البريد (Mailbox)";
            this.colMailbox.FieldName = "Mailbox";
            this.colMailbox.Visible = true;
            this.colMailbox.VisibleIndex = 0;

            this.colFolder.Caption = "المجلد (Folder)";
            this.colFolder.FieldName = "Folder";
            this.colFolder.Visible = true;
            this.colFolder.VisibleIndex = 1;

            this.colLastSync.Caption = "تاريخ وتوقيت المزامنة";
            this.colLastSync.FieldName = "LastSync";
            this.colLastSync.Visible = true;
            this.colLastSync.VisibleIndex = 2;

            this.colStatus.Caption = "حالة الاتصال والعملية";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;

            this.colErrorMessage.Caption = "رسائل وتفاصيل الأخطاء (Error Message)";
            this.colErrorMessage.FieldName = "ErrorMessage";
            this.colErrorMessage.Visible = true;
            this.colErrorMessage.VisibleIndex = 4;

            // splitContainerControlCharts
            this.splitContainerControlCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlCharts.Name = "splitContainerControlCharts";
            this.splitContainerControlCharts.Panel1.Controls.Add(this.chartSyncTrend);
            this.splitContainerControlCharts.Panel1.Text = "اتجاه وسرعة المزامنة";
            this.splitContainerControlCharts.Panel2.Controls.Add(this.chartSyncDuration);
            this.splitContainerControlCharts.Panel2.Text = "زمن استغراق المزامنة";
            this.splitContainerControlCharts.Size = new System.Drawing.Size(1200, 260);
            this.splitContainerControlCharts.SplitterPosition = 600;

            // chartSyncTrend
            this.chartSyncTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSyncTrend.Location = new System.Drawing.Point(0, 0);
            this.chartSyncTrend.Name = "chartSyncTrend";
            this.chartSyncTrend.Size = new System.Drawing.Size(600, 260);

            // chartSyncDuration
            this.chartSyncDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSyncDuration.Location = new System.Drawing.Point(0, 0);
            this.chartSyncDuration.Name = "chartSyncDuration";
            this.chartSyncDuration.Size = new System.Drawing.Size(590, 260);

            // ucMailboxSyncMonitor
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucMailboxSyncMonitor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlCharts)).EndInit();
            this.splitContainerControlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSyncTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSyncDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiSyncNow;
        private DevExpress.XtraBars.BarButtonItem bbiRetryFailed;
        private DevExpress.XtraBars.BarButtonItem bbiSettings;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblLastSync;
        private DevExpress.XtraEditors.LabelControl lblSuccessfulSync;
        private DevExpress.XtraEditors.LabelControl lblFailedSync;
        private DevExpress.XtraEditors.LabelControl lblPendingItems;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdSync;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSync;
        private DevExpress.XtraGrid.Columns.GridColumn colMailbox;
        private DevExpress.XtraGrid.Columns.GridColumn colFolder;
        private DevExpress.XtraGrid.Columns.GridColumn colLastSync;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorMessage;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlCharts;
        private DevExpress.XtraCharts.ChartControl chartSyncTrend;
        private DevExpress.XtraCharts.ChartControl chartSyncDuration;
    }
}
