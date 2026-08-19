namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucCorrespondenceInbox
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
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReply = new DevExpress.XtraBars.BarButtonItem();
            this.bbiForward = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAssign = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLinkProject = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLinkContract = new DevExpress.XtraBars.BarButtonItem();
            this.bbiArchive = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlContextBar = new DevExpress.XtraEditors.PanelControl();
            this.lblContextInfo = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlFilters = new DevExpress.XtraEditors.PanelControl();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboSender = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboPriority = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboDocType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grdInbox = new DevExpress.XtraGrid.GridControl();
            this.gvInbox = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkflowStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignedTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlPreview = new DevExpress.XtraEditors.PanelControl();
            this.lblPreviewHeader = new DevExpress.XtraEditors.LabelControl();
            this.tabPreview = new DevExpress.XtraTab.XtraTabControl();
            this.tpText = new DevExpress.XtraTab.XtraTabPage();
            this.richEditPreview = new DevExpress.XtraRichEdit.RichEditControl();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.pdfViewerInbox = new DevExpress.XtraPdfViewer.PdfViewer();
            this.tpNotes = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContextBar)).BeginInit();
            this.pnlContextBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilters)).BeginInit();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPriority.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreview)).BeginInit();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPreview)).BeginInit();
            this.tabPreview.SuspendLayout();
            this.tpText.SuspendLayout();
            this.tpAttachments.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNew, this.bbiReply, this.bbiForward, this.bbiAssign,
                this.bbiLinkProject, this.bbiLinkContract, this.bbiArchive,
                this.bbiPrint, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNew),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiReply),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiForward),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiAssign),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiLinkProject),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiLinkContract),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiArchive),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات صندوق المراسلات الواردة";

            this.bbiNew.Caption = "مراسلة جديدة";
            this.bbiReply.Caption = "رد (Reply)";
            this.bbiForward.Caption = "إعادة توجيه (Forward)";
            this.bbiAssign.Caption = "تنسيب تكليف (Assign)";
            this.bbiLinkProject.Caption = "ربط بمشروع";
            this.bbiLinkContract.Caption = "ربط بعقد";
            this.bbiArchive.Caption = "أرشفة المراسلة";
            this.bbiPrint.Caption = "طباعة";
            this.bbiExport.Caption = "تصدير إلى Excel/PDF";

            // pnlContextBar
            this.pnlContextBar.Controls.Add(this.lblContextInfo);
            this.pnlContextBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContextBar.Location = new System.Drawing.Point(0, 30);
            this.pnlContextBar.Name = "pnlContextBar";
            this.pnlContextBar.Size = new System.Drawing.Size(1200, 35);

            this.lblContextInfo.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblContextInfo.Location = new System.Drawing.Point(10, 8);
            this.lblContextInfo.Text = "المرجع المحدد: INC-2026-0941 | المشروع: برج المملكة | الأولوية: عاجل جداً | الحالة: قيد المعالجة | المكلف: Eng. Majed";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 65);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdInbox);
            this.splitContainerControlMain.Panel1.Controls.Add(this.pnlFilters);
            this.splitContainerControlMain.Panel1.Text = "جدول المراسلات الواردة";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabPreview);
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlPreview);
            this.splitContainerControlMain.Panel2.Text = "لوحة المعاينة والمرفقات (Preview Pane)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 685);
            this.splitContainerControlMain.SplitterPosition = 800;

            // pnlFilters
            this.pnlFilters.Controls.Add(this.cboProject);
            this.pnlFilters.Controls.Add(this.cboSender);
            this.pnlFilters.Controls.Add(this.cboStatus);
            this.pnlFilters.Controls.Add(this.cboPriority);
            this.pnlFilters.Controls.Add(this.cboDocType);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(800, 45);

            // grdInbox
            this.grdInbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInbox.Location = new System.Drawing.Point(0, 45);
            this.grdInbox.MainView = this.gvInbox;
            this.grdInbox.Name = "grdInbox";
            this.grdInbox.Size = new System.Drawing.Size(800, 640);
            this.grdInbox.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvInbox });

            // gvInbox
            this.gvInbox.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colRefNo, this.colSubject, this.colSender,
                this.colDateReceived, this.colProject, this.colPriority,
                this.colWorkflowStatus, this.colAssignedTo
            });
            this.gvInbox.GridControl = this.grdInbox;
            this.gvInbox.Name = "gvInbox";
            this.gvInbox.OptionsView.ShowAutoFilterRow = true;
            this.gvInbox.OptionsView.ShowFooter = true;

            this.colRefNo.Caption = "رقم المرجع (Reference No)";
            this.colRefNo.FieldName = "RefNo";
            this.colRefNo.Visible = true;
            this.colRefNo.VisibleIndex = 0;

            this.colSubject.Caption = "موضوع الخطاب / المراسلة";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;

            this.colSender.Caption = "الجهة المرسِلة (Sender)";
            this.colSender.FieldName = "Sender";
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 2;

            this.colDateReceived.Caption = "تاريخ الاستلام";
            this.colDateReceived.FieldName = "DateReceived";
            this.colDateReceived.Visible = true;
            this.colDateReceived.VisibleIndex = 3;

            this.colProject.Caption = "المشروع التابع";
            this.colProject.FieldName = "Project";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 4;

            this.colPriority.Caption = "الأولوية (Priority)";
            this.colPriority.FieldName = "Priority";
            this.colPriority.Visible = true;
            this.colPriority.VisibleIndex = 5;

            this.colWorkflowStatus.Caption = "حالة سير المعاملة";
            this.colWorkflowStatus.FieldName = "WorkflowStatus";
            this.colWorkflowStatus.Visible = true;
            this.colWorkflowStatus.VisibleIndex = 6;

            this.colAssignedTo.Caption = "المكلف بالحفظ/المعالجة";
            this.colAssignedTo.FieldName = "AssignedTo";
            this.colAssignedTo.Visible = true;
            this.colAssignedTo.VisibleIndex = 7;

            // pnlPreview
            this.pnlPreview.Controls.Add(this.lblPreviewHeader);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPreview.Location = new System.Drawing.Point(0, 0);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(390, 35);

            this.lblPreviewHeader.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblPreviewHeader.Location = new System.Drawing.Point(10, 8);
            this.lblPreviewHeader.Text = "معاينة نص الخطاب والمرفقات (Preview Pane)";

            // tabPreview
            this.tabPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPreview.Location = new System.Drawing.Point(0, 35);
            this.tabPreview.Name = "tabPreview";
            this.tabPreview.SelectedTabPage = this.tpText;
            this.tabPreview.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpText,
                this.tpAttachments,
                this.tpNotes
            });
            this.tabPreview.Size = new System.Drawing.Size(390, 650);

            this.tpText.Controls.Add(this.richEditPreview);
            this.tpText.Text = "نص الخطاب";
            this.richEditPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditPreview.Location = new System.Drawing.Point(0, 0);
            this.richEditPreview.Name = "richEditPreview";
            this.richEditPreview.Size = new System.Drawing.Size(388, 615);

            this.tpAttachments.Controls.Add(this.pdfViewerInbox);
            this.tpAttachments.Text = "المرفقات (Pdf)";
            this.pdfViewerInbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewerInbox.Location = new System.Drawing.Point(0, 0);
            this.pdfViewerInbox.Name = "pdfViewerInbox";
            this.pdfViewerInbox.Size = new System.Drawing.Size(388, 615);

            this.tpNotes.Text = "الملاحظات والتوجيهات";

            // ucCorrespondenceInbox
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlContextBar);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCorrespondenceInbox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContextBar)).EndInit();
            this.pnlContextBar.ResumeLayout(false);
            this.pnlContextBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilters)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPriority.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreview)).EndInit();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPreview)).EndInit();
            this.tabPreview.SuspendLayout();
            this.tpText.ResumeLayout(false);
            this.tpAttachments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiReply;
        private DevExpress.XtraBars.BarButtonItem bbiForward;
        private DevExpress.XtraBars.BarButtonItem bbiAssign;
        private DevExpress.XtraBars.BarButtonItem bbiLinkProject;
        private DevExpress.XtraBars.BarButtonItem bbiLinkContract;
        private DevExpress.XtraBars.BarButtonItem bbiArchive;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlContextBar;
        private DevExpress.XtraEditors.LabelControl lblContextInfo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraEditors.PanelControl pnlFilters;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.ComboBoxEdit cboSender;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraEditors.ComboBoxEdit cboPriority;
        private DevExpress.XtraEditors.ComboBoxEdit cboDocType;
        private DevExpress.XtraGrid.GridControl grdInbox;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInbox;
        private DevExpress.XtraGrid.Columns.GridColumn colRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private DevExpress.XtraGrid.Columns.GridColumn colDateReceived;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkflowStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignedTo;
        private DevExpress.XtraEditors.PanelControl pnlPreview;
        private DevExpress.XtraEditors.LabelControl lblPreviewHeader;
        private DevExpress.XtraTab.XtraTabControl tabPreview;
        private DevExpress.XtraTab.XtraTabPage tpText;
        private DevExpress.XtraRichEdit.RichEditControl richEditPreview;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewerInbox;
        private DevExpress.XtraTab.XtraTabPage tpNotes;
    }
}
