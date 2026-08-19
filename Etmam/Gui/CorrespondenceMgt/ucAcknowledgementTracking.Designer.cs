namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucAcknowledgementTracking
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
            this.bbiSendReminder = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdAck = new DevExpress.XtraGrid.GridControl();
            this.gvAck = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCorrespondence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecipient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcknowledged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcknowledgementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControlCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartAckRate = new DevExpress.XtraCharts.ChartControl();
            this.chartOutstandingAck = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlCharts)).BeginInit();
            this.splitContainerControlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAckRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOutstandingAck)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiSendReminder, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSendReminder),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات تتبع الإقرارات الإشعارات";

            this.bbiSendReminder.Caption = "إرسال تذكير بالإقرار (Send Reminder)";
            this.bbiExport.Caption = "تصدير التقرير";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdAck);
            this.splitContainerControlMain.Panel1.Text = "سجل تتبع الإقرارات والإشطارات";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerControlCharts);
            this.splitContainerControlMain.Panel2.Text = "مخططات الإقرارات والاستجابة";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 450;

            // grdAck
            this.grdAck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAck.Location = new System.Drawing.Point(0, 0);
            this.grdAck.MainView = this.gvAck;
            this.grdAck.Name = "grdAck";
            this.grdAck.Size = new System.Drawing.Size(1200, 450);
            this.grdAck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvAck });

            // gvAck
            this.gvAck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCorrespondence, this.colRecipient, this.colSentDate,
                this.colAcknowledged, this.colAcknowledgementDate, this.colStatus
            });
            this.gvAck.GridControl = this.grdAck;
            this.gvAck.Name = "gvAck";
            this.gvAck.OptionsView.ShowAutoFilterRow = true;
            this.gvAck.OptionsView.ShowFooter = true;

            this.colCorrespondence.Caption = "رقم المراسلة الموضوع";
            this.colCorrespondence.FieldName = "Correspondence";
            this.colCorrespondence.Visible = true;
            this.colCorrespondence.VisibleIndex = 0;

            this.colRecipient.Caption = "المستلم (Recipient)";
            this.colRecipient.FieldName = "Recipient";
            this.colRecipient.Visible = true;
            this.colRecipient.VisibleIndex = 1;

            this.colSentDate.Caption = "تاريخ الإرسال";
            this.colSentDate.FieldName = "SentDate";
            this.colSentDate.Visible = true;
            this.colSentDate.VisibleIndex = 2;

            this.colAcknowledged.Caption = "هل تم الإقرار والاستلام؟";
            this.colAcknowledged.FieldName = "Acknowledged";
            this.colAcknowledged.Visible = true;
            this.colAcknowledged.VisibleIndex = 3;

            this.colAcknowledgementDate.Caption = "تاريخ وتوقيت الإقرار";
            this.colAcknowledgementDate.FieldName = "AcknowledgementDate";
            this.colAcknowledgementDate.Visible = true;
            this.colAcknowledgementDate.VisibleIndex = 4;

            this.colStatus.Caption = "حالة الإشعار";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // splitContainerControlCharts
            this.splitContainerControlCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlCharts.Name = "splitContainerControlCharts";
            this.splitContainerControlCharts.Panel1.Controls.Add(this.chartAckRate);
            this.splitContainerControlCharts.Panel1.Text = "نسبة الإقرارات المكتملة";
            this.splitContainerControlCharts.Panel2.Controls.Add(this.chartOutstandingAck);
            this.splitContainerControlCharts.Panel2.Text = "الإقرارات المعلقة حسب الإدارة";
            this.splitContainerControlCharts.Size = new System.Drawing.Size(1200, 260);
            this.splitContainerControlCharts.SplitterPosition = 600;

            // chartAckRate
            this.chartAckRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartAckRate.Location = new System.Drawing.Point(0, 0);
            this.chartAckRate.Name = "chartAckRate";
            this.chartAckRate.Size = new System.Drawing.Size(600, 260);

            // chartOutstandingAck
            this.chartOutstandingAck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartOutstandingAck.Location = new System.Drawing.Point(0, 0);
            this.chartOutstandingAck.Name = "chartOutstandingAck";
            this.chartOutstandingAck.Size = new System.Drawing.Size(590, 260);

            // ucAcknowledgementTracking
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucAcknowledgementTracking";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlCharts)).EndInit();
            this.splitContainerControlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAckRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOutstandingAck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiSendReminder;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdAck;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAck;
        private DevExpress.XtraGrid.Columns.GridColumn colCorrespondence;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipient;
        private DevExpress.XtraGrid.Columns.GridColumn colSentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAcknowledged;
        private DevExpress.XtraGrid.Columns.GridColumn colAcknowledgementDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlCharts;
        private DevExpress.XtraCharts.ChartControl chartAckRate;
        private DevExpress.XtraCharts.ChartControl chartOutstandingAck;
    }
}
