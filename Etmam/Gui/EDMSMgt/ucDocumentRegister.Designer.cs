namespace Etmam.Gui.EDMSMgt
{
    partial class ucDocumentRegister
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
            this.bbiNewDoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditDoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiViewDoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUpload = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDownload = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCheckOut = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCheckIn = new DevExpress.XtraBars.BarButtonItem();
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
            this.cboCompany = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboDiscipline = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboDocType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grdDocuments = new DevExpress.XtraGrid.GridControl();
            this.gvDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkflowStep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastModified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlPreview = new DevExpress.XtraEditors.PanelControl();
            this.lblPreviewTitle = new DevExpress.XtraEditors.LabelControl();
            this.pdfViewerDoc = new DevExpress.XtraPdfViewer.PdfViewer();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContextBar)).BeginInit();
            this.pnlContextBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilters)).BeginInit();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDiscipline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreview)).BeginInit();
            this.pnlPreview.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewDoc, this.bbiEditDoc, this.bbiViewDoc, this.bbiUpload,
                this.bbiDownload, this.bbiCheckOut, this.bbiCheckIn, this.bbiArchive,
                this.bbiPrint, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewDoc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditDoc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiViewDoc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiUpload),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiDownload),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCheckOut),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCheckIn),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiArchive),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل الوثائق";

            this.bbiNewDoc.Caption = "وثيقة جديدة";
            this.bbiEditDoc.Caption = "تعديل";
            this.bbiViewDoc.Caption = "عرض التفاصيل";
            this.bbiUpload.Caption = "رفع ملف";
            this.bbiDownload.Caption = "تحميل";
            this.bbiCheckOut.Caption = "حجز للحرير (Check-Out)";
            this.bbiCheckIn.Caption = "إرجاع الاعتماد (Check-In)";
            this.bbiArchive.Caption = "أرشفة الوثيقة";
            this.bbiPrint.Caption = "طباعة السجل";
            this.bbiExport.Caption = "تصدير إلى Excel/PDF";

            // pnlContextBar
            this.pnlContextBar.Controls.Add(this.lblContextInfo);
            this.pnlContextBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContextBar.Location = new System.Drawing.Point(0, 30);
            this.pnlContextBar.Name = "pnlContextBar";
            this.pnlContextBar.Size = new System.Drawing.Size(1200, 35);

            this.lblContextInfo.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblContextInfo.Location = new System.Drawing.Point(10, 8);
            this.lblContextInfo.Text = "رقم الوثيقة المحددة: DOC-2026-0881 | الإصدار: Rev-03 | الحالة: Approved | المستخدم الحالي: Eng. Ahmed";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 65);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdDocuments);
            this.splitContainerControlMain.Panel1.Controls.Add(this.pnlFilters);
            this.splitContainerControlMain.Panel1.Text = "سجل الوثائق والمستندات";
            this.splitContainerControlMain.Panel2.Controls.Add(this.pdfViewerDoc);
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlPreview);
            this.splitContainerControlMain.Panel2.Text = "لوحة المعايرة المباشرة";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 685);
            this.splitContainerControlMain.SplitterPosition = 850;

            // pnlFilters
            this.pnlFilters.Controls.Add(this.cboCompany);
            this.pnlFilters.Controls.Add(this.cboProject);
            this.pnlFilters.Controls.Add(this.cboDiscipline);
            this.pnlFilters.Controls.Add(this.cboDocType);
            this.pnlFilters.Controls.Add(this.cboStatus);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(850, 45);

            // grdDocuments
            this.grdDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDocuments.Location = new System.Drawing.Point(0, 45);
            this.grdDocuments.MainView = this.gvDocuments;
            this.grdDocuments.Name = "grdDocuments";
            this.grdDocuments.Size = new System.Drawing.Size(850, 640);
            this.grdDocuments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvDocuments });

            // gvDocuments
            this.gvDocuments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colDocNo, this.colTitle, this.colDiscipline, this.colCategory,
                this.colRevision, this.colStatus, this.colWorkflowStep, this.colOwner,
                this.colIssueDate, this.colLastModified
            });
            this.gvDocuments.GridControl = this.grdDocuments;
            this.gvDocuments.Name = "gvDocuments";
            this.gvDocuments.OptionsView.ShowAutoFilterRow = true;
            this.gvDocuments.OptionsView.ShowFooter = true;

            this.colDocNo.Caption = "رقم الوثيقة";
            this.colDocNo.FieldName = "DocumentNo";
            this.colDocNo.Visible = true;
            this.colDocNo.VisibleIndex = 0;

            this.colTitle.Caption = "عنوان الوثيقة والوصف";
            this.colTitle.FieldName = "Title";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 1;

            this.colDiscipline.Caption = "التخصص الهندسِي";
            this.colDiscipline.FieldName = "Discipline";
            this.colDiscipline.Visible = true;
            this.colDiscipline.VisibleIndex = 2;

            this.colCategory.Caption = "التصنيف / الفئة";
            this.colCategory.FieldName = "Category";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 3;

            this.colRevision.Caption = "الإصدار (Rev)";
            this.colRevision.FieldName = "Revision";
            this.colRevision.Visible = true;
            this.colRevision.VisibleIndex = 4;

            this.colStatus.Caption = "الحالة التشغيلية";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            this.colWorkflowStep.Caption = "مرحلة سير العمل";
            this.colWorkflowStep.FieldName = "CurrentWorkflowStep";
            this.colWorkflowStep.Visible = true;
            this.colWorkflowStep.VisibleIndex = 6;

            this.colOwner.Caption = "مالك الوثيقة";
            this.colOwner.FieldName = "Owner";
            this.colOwner.Visible = true;
            this.colOwner.VisibleIndex = 7;

            this.colIssueDate.Caption = "تاريخ الإصدار";
            this.colIssueDate.FieldName = "IssueDate";
            this.colIssueDate.Visible = true;
            this.colIssueDate.VisibleIndex = 8;

            this.colLastModified.Caption = "آخر تعديل";
            this.colLastModified.FieldName = "LastModified";
            this.colLastModified.Visible = true;
            this.colLastModified.VisibleIndex = 9;

            // pnlPreview
            this.pnlPreview.Controls.Add(this.lblPreviewTitle);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPreview.Location = new System.Drawing.Point(0, 0);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(340, 35);

            this.lblPreviewTitle.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblPreviewTitle.Location = new System.Drawing.Point(10, 8);
            this.lblPreviewTitle.Text = "معاينة الوثيقة المحددة (Preview Panel)";

            // pdfViewerDoc
            this.pdfViewerDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewerDoc.Location = new System.Drawing.Point(0, 35);
            this.pdfViewerDoc.Name = "pdfViewerDoc";
            this.pdfViewerDoc.Size = new System.Drawing.Size(340, 650);

            // ucDocumentRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlContextBar);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucDocumentRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContextBar)).EndInit();
            this.pnlContextBar.ResumeLayout(false);
            this.pnlContextBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilters)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDiscipline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreview)).EndInit();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewDoc;
        private DevExpress.XtraBars.BarButtonItem bbiEditDoc;
        private DevExpress.XtraBars.BarButtonItem bbiViewDoc;
        private DevExpress.XtraBars.BarButtonItem bbiUpload;
        private DevExpress.XtraBars.BarButtonItem bbiDownload;
        private DevExpress.XtraBars.BarButtonItem bbiCheckOut;
        private DevExpress.XtraBars.BarButtonItem bbiCheckIn;
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
        private DevExpress.XtraEditors.ComboBoxEdit cboCompany;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.ComboBoxEdit cboDiscipline;
        private DevExpress.XtraEditors.ComboBoxEdit cboDocType;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraGrid.GridControl grdDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocuments;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkflowStep;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModified;
        private DevExpress.XtraEditors.PanelControl pnlPreview;
        private DevExpress.XtraEditors.LabelControl lblPreviewTitle;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewerDoc;
    }
}
