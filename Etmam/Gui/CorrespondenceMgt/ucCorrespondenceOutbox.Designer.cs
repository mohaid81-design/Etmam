namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucCorrespondenceOutbox
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
            this.bbiNewOutbox = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditOutbox = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdOutbox = new DevExpress.XtraGrid.GridControl();
            this.gvOutbox = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLetterNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecipient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkflow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabOutboxDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tpDeliveryConfirmation = new DevExpress.XtraTab.XtraTabPage();
            this.tpReadReceipt = new DevExpress.XtraTab.XtraTabPage();
            this.tpAudit = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabOutboxDetails)).BeginInit();
            this.tabOutboxDetails.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewOutbox, this.bbiEditOutbox, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewOutbox),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditOutbox),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات صندوق المراسلات الصادرة";

            this.bbiNewOutbox.Caption = "إعداد خطاب صادر جديد";
            this.bbiEditOutbox.Caption = "تعديل المسودة";
            this.bbiPrint.Caption = "طباعة سجل الصادر";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdOutbox);
            this.splitContainerControlMain.Panel1.Text = "سجل المراسلات الصادرة";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabOutboxDetails);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل التسليم والتأكيد";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 420;

            // grdOutbox
            this.grdOutbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOutbox.Location = new System.Drawing.Point(0, 0);
            this.grdOutbox.MainView = this.gvOutbox;
            this.grdOutbox.Name = "grdOutbox";
            this.grdOutbox.Size = new System.Drawing.Size(1200, 420);
            this.grdOutbox.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvOutbox });

            // gvOutbox
            this.gvOutbox.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colLetterNo, this.colSubject, this.colRecipient,
                this.colSentDate, this.colDeliveryStatus, this.colWorkflow, this.colProject
            });
            this.gvOutbox.GridControl = this.grdOutbox;
            this.gvOutbox.Name = "gvOutbox";
            this.gvOutbox.OptionsView.ShowAutoFilterRow = true;
            this.gvOutbox.OptionsView.ShowFooter = true;

            this.colLetterNo.Caption = "رقم الخطاب (Letter No)";
            this.colLetterNo.FieldName = "LetterNo";
            this.colLetterNo.Visible = true;
            this.colLetterNo.VisibleIndex = 0;

            this.colSubject.Caption = "موضوع الخطاب الصادر";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;

            this.colRecipient.Caption = "الجهة المُستقبِلة (Recipient)";
            this.colRecipient.FieldName = "Recipient";
            this.colRecipient.Visible = true;
            this.colRecipient.VisibleIndex = 2;

            this.colSentDate.Caption = "تاريخ الإرسال الصادر";
            this.colSentDate.FieldName = "SentDate";
            this.colSentDate.Visible = true;
            this.colSentDate.VisibleIndex = 3;

            this.colDeliveryStatus.Caption = "حالة التسليم والوصول";
            this.colDeliveryStatus.FieldName = "DeliveryStatus";
            this.colDeliveryStatus.Visible = true;
            this.colDeliveryStatus.VisibleIndex = 4;

            this.colWorkflow.Caption = "سير الاعتماد والتدقيق";
            this.colWorkflow.FieldName = "Workflow";
            this.colWorkflow.Visible = true;
            this.colWorkflow.VisibleIndex = 5;

            this.colProject.Caption = "المشروع التابع";
            this.colProject.FieldName = "Project";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 6;

            // tabOutboxDetails
            this.tabOutboxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOutboxDetails.Location = new System.Drawing.Point(0, 0);
            this.tabOutboxDetails.Name = "tabOutboxDetails";
            this.tabOutboxDetails.SelectedTabPage = this.tpDeliveryConfirmation;
            this.tabOutboxDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpAttachments,
                this.tpDeliveryConfirmation,
                this.tpReadReceipt,
                this.tpAudit
            });
            this.tabOutboxDetails.Size = new System.Drawing.Size(1200, 290);

            this.tpAttachments.Text = "المرفقات المنسوخة (Attachments)";
            this.tpDeliveryConfirmation.Text = "تأكيدات الاستلام (Delivery Confirmation)";
            this.tpReadReceipt.Text = "إشعار فتح وقراءة المعاملة (Read Receipt)";
            this.tpAudit.Text = "سجل التدقيق والتاريخ (Audit Trail)";

            // ucCorrespondenceOutbox
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCorrespondenceOutbox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabOutboxDetails)).EndInit();
            this.tabOutboxDetails.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewOutbox;
        private DevExpress.XtraBars.BarButtonItem bbiEditOutbox;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdOutbox;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutbox;
        private DevExpress.XtraGrid.Columns.GridColumn colLetterNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipient;
        private DevExpress.XtraGrid.Columns.GridColumn colSentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkflow;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraTab.XtraTabControl tabOutboxDetails;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraTab.XtraTabPage tpDeliveryConfirmation;
        private DevExpress.XtraTab.XtraTabPage tpReadReceipt;
        private DevExpress.XtraTab.XtraTabPage tpAudit;
    }
}
