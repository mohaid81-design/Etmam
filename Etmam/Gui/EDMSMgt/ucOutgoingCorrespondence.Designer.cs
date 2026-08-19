namespace Etmam.Gui.EDMSMgt
{
    partial class ucOutgoingCorrespondence
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
            this.bbiNewOutgoing = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditOutgoing = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdOutgoing = new DevExpress.XtraGrid.GridControl();
            this.gvOutgoing = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLetterNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabOutgoingDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tpDeliveryConfirmation = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutgoing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutgoing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabOutgoingDetails)).BeginInit();
            this.tabOutgoingDetails.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewOutgoing, this.bbiEditOutgoing, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewOutgoing),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditOutgoing),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات المراسلات الصادرة";

            this.bbiNewOutgoing.Caption = "إصدار خطاب صادر جديد";
            this.bbiEditOutgoing.Caption = "تعديل المعاملة";
            this.bbiPrint.Caption = "طباعة سجل الصادر";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdOutgoing);
            this.splitContainerControlMain.Panel1.Text = "سجل الخطابات والمراسلات الصادرة";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabOutgoingDetails);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل وتأكيدات التسليم";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 420;

            // grdOutgoing
            this.grdOutgoing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOutgoing.Location = new System.Drawing.Point(0, 0);
            this.grdOutgoing.MainView = this.gvOutgoing;
            this.grdOutgoing.Name = "grdOutgoing";
            this.grdOutgoing.Size = new System.Drawing.Size(1200, 420);
            this.grdOutgoing.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvOutgoing });

            // gvOutgoing
            this.gvOutgoing.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colLetterNo, this.colSubject, this.colTo,
                this.colSentDate, this.colProject, this.colStatus
            });
            this.gvOutgoing.GridControl = this.grdOutgoing;
            this.gvOutgoing.Name = "gvOutgoing";
            this.gvOutgoing.OptionsView.ShowAutoFilterRow = true;
            this.gvOutgoing.OptionsView.ShowFooter = true;

            this.colLetterNo.Caption = "رقم الخطاب الصادر";
            this.colLetterNo.FieldName = "LetterNo";
            this.colLetterNo.Visible = true;
            this.colLetterNo.VisibleIndex = 0;

            this.colSubject.Caption = "موضوع الخطاب الصادر";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;

            this.colTo.Caption = "الجهة المُستقبِلة (To)";
            this.colTo.FieldName = "To";
            this.colTo.Visible = true;
            this.colTo.VisibleIndex = 2;

            this.colSentDate.Caption = "تاريخ الإرسال الصادر";
            this.colSentDate.FieldName = "SentDate";
            this.colSentDate.Visible = true;
            this.colSentDate.VisibleIndex = 3;

            this.colProject.Caption = "المشروع التابع";
            this.colProject.FieldName = "Project";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 4;

            this.colStatus.Caption = "حالة التسليم والاستلام";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // tabOutgoingDetails
            this.tabOutgoingDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOutgoingDetails.Location = new System.Drawing.Point(0, 0);
            this.tabOutgoingDetails.Name = "tabOutgoingDetails";
            this.tabOutgoingDetails.SelectedTabPage = this.tpAttachments;
            this.tabOutgoingDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpAttachments,
                this.tpWorkflow,
                this.tpDeliveryConfirmation
            });
            this.tabOutgoingDetails.Size = new System.Drawing.Size(1200, 290);

            this.tpAttachments.Text = "المرفقات والنسخ (Attachments)";
            this.tpWorkflow.Text = "مسار الاعتماد والتدقيق (Workflow)";
            this.tpDeliveryConfirmation.Text = "تأكيدات وتواقيع التسليم (Delivery Confirmation)";

            // ucOutgoingCorrespondence
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucOutgoingCorrespondence";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutgoing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutgoing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabOutgoingDetails)).EndInit();
            this.tabOutgoingDetails.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewOutgoing;
        private DevExpress.XtraBars.BarButtonItem bbiEditOutgoing;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdOutgoing;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutgoing;
        private DevExpress.XtraGrid.Columns.GridColumn colLetterNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colTo;
        private DevExpress.XtraGrid.Columns.GridColumn colSentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraTab.XtraTabControl tabOutgoingDetails;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraTab.XtraTabPage tpDeliveryConfirmation;
    }
}
