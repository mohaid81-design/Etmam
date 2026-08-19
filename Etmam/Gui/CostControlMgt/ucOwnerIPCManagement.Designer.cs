namespace Etmam.Gui.CostControlMgt
{
    partial class ucOwnerIPCManagement
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
            this.bbiNewIpc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGenerateIpc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSubmitIpc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApproveIpc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrintIpc = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblHeaderInfo = new DevExpress.XtraEditors.LabelControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblGross = new DevExpress.XtraEditors.LabelControl();
            this.lblRetention = new DevExpress.XtraEditors.LabelControl();
            this.lblVAT = new DevExpress.XtraEditors.LabelControl();
            this.lblNet = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdOwnerIPC = new DevExpress.XtraGrid.GridControl();
            this.gvOwnerIPC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBOQItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPreviousQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabDetailTabs = new DevExpress.XtraTab.XtraTabControl();
            this.tpRetention = new DevExpress.XtraTab.XtraTabPage();
            this.tpVAT = new DevExpress.XtraTab.XtraTabPage();
            this.tpVariations = new DevExpress.XtraTab.XtraTabPage();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tpAudit = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOwnerIPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOwnerIPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabDetailTabs)).BeginInit();
            this.tabDetailTabs.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewIpc, this.bbiGenerateIpc, this.bbiSubmitIpc,
                this.bbiApproveIpc, this.bbiPrintIpc
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewIpc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiGenerateIpc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSubmitIpc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiApproveIpc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrintIpc)
            });
            this.barMain.Text = "أدوات مستخلصات المالك Owner IPC Management";

            this.bbiNewIpc.Caption = "مستخلص جديد (New IPC)";
            this.bbiGenerateIpc.Caption = "توليد من الكميات المنجزة (Generate)";
            this.bbiSubmitIpc.Caption = "تقديم للاستشاري (Submit)";
            this.bbiApproveIpc.Caption = "اعتماد الشهادة المالية (Approve)";
            this.bbiPrintIpc.Caption = "طباعة مستخلص المالك الشهري";

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblHeaderInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 35);

            this.lblHeaderInfo.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderInfo.Location = new System.Drawing.Point(10, 8);
            this.lblHeaderInfo.Text = "المشروع: برج الرياض السكني | المالك: وزارة الإسكان | الفترة: أغسطس 2026 | رقم شهادة المستخلص: IPC-OWN-2026-08";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblGross);
            this.pnlCards.Controls.Add(this.lblRetention);
            this.pnlCards.Controls.Add(this.lblVAT);
            this.pnlCards.Controls.Add(this.lblNet);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 65);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblGross.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGross.Location = new System.Drawing.Point(1000, 15);
            this.lblGross.Text = "Gross Amount: 4,500,000 SAR";

            this.lblRetention.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRetention.Location = new System.Drawing.Point(720, 15);
            this.lblRetention.Text = "Retention 10%: -450,000 SAR";

            this.lblVAT.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVAT.Location = new System.Drawing.Point(460, 15);
            this.lblVAT.Text = "VAT 15%: +607,500 SAR";

            this.lblNet.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNet.Location = new System.Drawing.Point(150, 15);
            this.lblNet.Text = "Net Payable: 4,657,500 SAR";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 115);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdOwnerIPC);
            this.splitContainerControlMain.Panel1.Text = "بنود جدول الكميات والمبالغ الجارية بالمستخلص";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabDetailTabs);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل الاستقطاعات والضريبة والأوامر التغييرية ومسار الاعتماد";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 635);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdOwnerIPC
            this.grdOwnerIPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOwnerIPC.Location = new System.Drawing.Point(0, 0);
            this.grdOwnerIPC.MainView = this.gvOwnerIPC;
            this.grdOwnerIPC.Name = "grdOwnerIPC";
            this.grdOwnerIPC.Size = new System.Drawing.Size(1200, 380);
            this.grdOwnerIPC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvOwnerIPC });

            // gvOwnerIPC
            this.gvOwnerIPC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colBOQItem, this.colPreviousQty, this.colCurrentQty,
                this.colTotalQty, this.colUnitRate, this.colCurrentAmount
            });
            this.gvOwnerIPC.GridControl = this.grdOwnerIPC;
            this.gvOwnerIPC.Name = "gvOwnerIPC";
            this.gvOwnerIPC.OptionsView.ShowAutoFilterRow = true;
            this.gvOwnerIPC.OptionsView.ShowFooter = true;

            this.colBOQItem.Caption = "بند جدول الكميات (BOQ Item)";
            this.colBOQItem.FieldName = "BOQItem";
            this.colBOQItem.Visible = true;
            this.colBOQItem.VisibleIndex = 0;

            this.colPreviousQty.Caption = "الكمية السابقة المنفذة";
            this.colPreviousQty.FieldName = "PreviousQty";
            this.colPreviousQty.Visible = true;
            this.colPreviousQty.VisibleIndex = 1;

            this.colCurrentQty.Caption = "الكمية الجارية للفترة";
            this.colCurrentQty.FieldName = "CurrentQty";
            this.colCurrentQty.Visible = true;
            this.colCurrentQty.VisibleIndex = 2;

            this.colTotalQty.Caption = "إجمالي الكمية التراكمية";
            this.colTotalQty.FieldName = "TotalQty";
            this.colTotalQty.Visible = true;
            this.colTotalQty.VisibleIndex = 3;

            this.colUnitRate.Caption = "فئة السعر التعاقدية (Unit Rate)";
            this.colUnitRate.FieldName = "UnitRate";
            this.colUnitRate.Visible = true;
            this.colUnitRate.VisibleIndex = 4;

            this.colCurrentAmount.Caption = "المبلغ الجاري المستحق (Current Amount)";
            this.colCurrentAmount.FieldName = "CurrentAmount";
            this.colCurrentAmount.Visible = true;
            this.colCurrentAmount.VisibleIndex = 5;

            // tabDetailTabs
            this.tabDetailTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetailTabs.Location = new System.Drawing.Point(0, 0);
            this.tabDetailTabs.Name = "tabDetailTabs";
            this.tabDetailTabs.SelectedTabPage = this.tpRetention;
            this.tabDetailTabs.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpRetention,
                this.tpVAT,
                this.tpVariations,
                this.tpAttachments,
                this.tpWorkflow,
                this.tpAudit
            });
            this.tabDetailTabs.Size = new System.Drawing.Size(1200, 245);

            this.tpRetention.Text = "الاستقطاعات والاحتجازات (Retention)";
            this.tpVAT.Text = "ضريبة القيمة المضافة (VAT 15%)";
            this.tpVariations.Text = "الأوامر التغييرية المضافة (Variations)";
            this.tpAttachments.Text = "حصر الكميات ومستندات الإثبات (Attachments)";
            this.tpWorkflow.Text = "دورة الاعتماد والتواقيع الرسمية (Workflow)";
            this.tpAudit.Text = "سجل التدقيق والتعديلات (Audit Trail)";

            // ucOwnerIPCManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucOwnerIPCManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOwnerIPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOwnerIPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabDetailTabs)).EndInit();
            this.tabDetailTabs.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewIpc;
        private DevExpress.XtraBars.BarButtonItem bbiGenerateIpc;
        private DevExpress.XtraBars.BarButtonItem bbiSubmitIpc;
        private DevExpress.XtraBars.BarButtonItem bbiApproveIpc;
        private DevExpress.XtraBars.BarButtonItem bbiPrintIpc;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblHeaderInfo;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblGross;
        private DevExpress.XtraEditors.LabelControl lblRetention;
        private DevExpress.XtraEditors.LabelControl lblVAT;
        private DevExpress.XtraEditors.LabelControl lblNet;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdOwnerIPC;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOwnerIPC;
        private DevExpress.XtraGrid.Columns.GridColumn colBOQItem;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviousQty;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentQty;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalQty;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitRate;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentAmount;
        private DevExpress.XtraTab.XtraTabControl tabDetailTabs;
        private DevExpress.XtraTab.XtraTabPage tpRetention;
        private DevExpress.XtraTab.XtraTabPage tpVAT;
        private DevExpress.XtraTab.XtraTabPage tpVariations;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraTab.XtraTabPage tpAudit;
    }
}
