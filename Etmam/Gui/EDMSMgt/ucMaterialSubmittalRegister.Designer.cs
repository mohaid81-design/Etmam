namespace Etmam.Gui.EDMSMgt
{
    partial class ucMaterialSubmittalRegister
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
            this.bbiNewMsr = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditMsr = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblPending = new DevExpress.XtraEditors.LabelControl();
            this.lblApproved = new DevExpress.XtraEditors.LabelControl();
            this.lblRejected = new DevExpress.XtraEditors.LabelControl();
            this.lblReturnedComments = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdMsr = new DevExpress.XtraGrid.GridControl();
            this.gvMsr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMsrNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConsultant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysPending = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabSubmittalDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tpLinkedBOQ = new DevExpress.XtraTab.XtraTabPage();
            this.tpLinkedPO = new DevExpress.XtraTab.XtraTabPage();
            this.tpHistory = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMsr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMsr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSubmittalDetails)).BeginInit();
            this.tabSubmittalDetails.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewMsr, this.bbiEditMsr, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewMsr),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditMsr),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات سجل اعتماد المواد";

            this.bbiNewMsr.Caption = "طلب اعتماد موارِد (MSR جديد)";
            this.bbiEditMsr.Caption = "تعديل الطلب";
            this.bbiPrint.Caption = "طباعة سجل الاعتمادات";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblPending);
            this.pnlCards.Controls.Add(this.lblApproved);
            this.pnlCards.Controls.Add(this.lblRejected);
            this.pnlCards.Controls.Add(this.lblReturnedComments);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblPending.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPending.Location = new System.Drawing.Point(1000, 15);
            this.lblPending.Text = "طلبات معلقة (Pending): 8";

            this.lblApproved.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApproved.Location = new System.Drawing.Point(720, 15);
            this.lblApproved.Text = "معتمدة (Approved): 45";

            this.lblRejected.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRejected.Location = new System.Drawing.Point(450, 15);
            this.lblRejected.Text = "مرفوضة (Rejected): 3";

            this.lblReturnedComments.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReturnedComments.Location = new System.Drawing.Point(150, 15);
            this.lblReturnedComments.Text = "معادة بملاحظات (Comments): 6";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdMsr);
            this.splitContainerControlMain.Panel1.Text = "جدول طلبات اعتماد المواد MSR";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabSubmittalDetails);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل الاعتماد والمرفقات";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 400;

            // grdMsr
            this.grdMsr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMsr.Location = new System.Drawing.Point(0, 0);
            this.grdMsr.MainView = this.gvMsr;
            this.grdMsr.Name = "grdMsr";
            this.grdMsr.Size = new System.Drawing.Size(1200, 400);
            this.grdMsr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvMsr });

            // gvMsr
            this.gvMsr.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colMsrNo, this.colMaterial, this.colSpecification,
                this.colSupplier, this.colConsultant, this.colStatus, this.colDaysPending
            });
            this.gvMsr.GridControl = this.grdMsr;
            this.gvMsr.Name = "gvMsr";
            this.gvMsr.OptionsView.ShowAutoFilterRow = true;
            this.gvMsr.OptionsView.ShowFooter = true;

            this.colMsrNo.Caption = "رقم طلب الاعتماد (MSR No)";
            this.colMsrNo.FieldName = "MsrNo";
            this.colMsrNo.Visible = true;
            this.colMsrNo.VisibleIndex = 0;

            this.colMaterial.Caption = "اسم المادة / الخامة";
            this.colMaterial.FieldName = "Material";
            this.colMaterial.Visible = true;
            this.colMaterial.VisibleIndex = 1;

            this.colSpecification.Caption = "المواصفة الفنية المرجعية";
            this.colSpecification.FieldName = "Specification";
            this.colSpecification.Visible = true;
            this.colSpecification.VisibleIndex = 2;

            this.colSupplier.Caption = "المورد / المصنع";
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 3;

            this.colConsultant.Caption = "الاستشاري المراجع";
            this.colConsultant.FieldName = "Consultant";
            this.colConsultant.Visible = true;
            this.colConsultant.VisibleIndex = 4;

            this.colStatus.Caption = "حالة الاعتماد";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            this.colDaysPending.Caption = "أيام الانتظار";
            this.colDaysPending.FieldName = "DaysPending";
            this.colDaysPending.Visible = true;
            this.colDaysPending.VisibleIndex = 6;

            // tabSubmittalDetails
            this.tabSubmittalDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSubmittalDetails.Location = new System.Drawing.Point(0, 0);
            this.tabSubmittalDetails.Name = "tabSubmittalDetails";
            this.tabSubmittalDetails.SelectedTabPage = this.tpAttachments;
            this.tabSubmittalDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpAttachments,
                this.tpWorkflow,
                this.tpLinkedBOQ,
                this.tpLinkedPO,
                this.tpHistory
            });
            this.tabSubmittalDetails.Size = new System.Drawing.Size(1200, 260);

            this.tpAttachments.Text = "المرفقات والعينات (Attachments)";
            this.tpWorkflow.Text = "سير الاعتماد والملاحظات (Workflow)";
            this.tpLinkedBOQ.Text = "جدول الكميات المرتبط (Linked BOQ)";
            this.tpLinkedPO.Text = "أمر الشراء المرتبط (Linked Purchase Order)";
            this.tpHistory.Text = "سجل التعديلات والردود (History)";

            // ucMaterialSubmittalRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucMaterialSubmittalRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMsr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMsr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSubmittalDetails)).EndInit();
            this.tabSubmittalDetails.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewMsr;
        private DevExpress.XtraBars.BarButtonItem bbiEditMsr;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblPending;
        private DevExpress.XtraEditors.LabelControl lblApproved;
        private DevExpress.XtraEditors.LabelControl lblRejected;
        private DevExpress.XtraEditors.LabelControl lblReturnedComments;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdMsr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMsr;
        private DevExpress.XtraGrid.Columns.GridColumn colMsrNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecification;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colConsultant;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysPending;
        private DevExpress.XtraTab.XtraTabControl tabSubmittalDetails;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraTab.XtraTabPage tpLinkedBOQ;
        private DevExpress.XtraTab.XtraTabPage tpLinkedPO;
        private DevExpress.XtraTab.XtraTabPage tpHistory;
    }
}
