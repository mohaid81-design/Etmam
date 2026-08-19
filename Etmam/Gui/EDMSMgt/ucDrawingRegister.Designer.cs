namespace Etmam.Gui.EDMSMgt
{
    partial class ucDrawingRegister
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
            this.bbiNewDrawing = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditDrawing = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdDrawings = new DevExpress.XtraGrid.GridControl();
            this.gvDrawings = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDrawingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIfcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLatestRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApprovalStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlDrawingPreview = new DevExpress.XtraEditors.PanelControl();
            this.lblPreviewHeader = new DevExpress.XtraEditors.LabelControl();
            this.pdfViewerDrawing = new DevExpress.XtraPdfViewer.PdfViewer();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrawings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDrawings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawingPreview)).BeginInit();
            this.pnlDrawingPreview.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewDrawing, this.bbiEditDrawing, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewDrawing),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditDrawing),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات سجل الرسومات الهندسية";

            this.bbiNewDrawing.Caption = "إضافة رسم هندسي جديد";
            this.bbiEditDrawing.Caption = "تعديل المخطط";
            this.bbiPrint.Caption = "طباعة سجل الرسومات";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdDrawings);
            this.splitContainerControlMain.Panel1.Text = "جدول الرسومات";
            this.splitContainerControlMain.Panel2.Controls.Add(this.pdfViewerDrawing);
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlDrawingPreview);
            this.splitContainerControlMain.Panel2.Text = "لوحة معاينة الرسم الهندسي";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 750;

            // grdDrawings
            this.grdDrawings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDrawings.Location = new System.Drawing.Point(0, 0);
            this.grdDrawings.MainView = this.gvDrawings;
            this.grdDrawings.Name = "grdDrawings";
            this.grdDrawings.Size = new System.Drawing.Size(750, 720);
            this.grdDrawings.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvDrawings });

            // gvDrawings
            this.gvDrawings.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colDrawingNo, this.colTitle, this.colDiscipline, this.colRevision,
                this.colIfcStatus, this.colLatestRevision, this.colIssueDate, this.colApprovalStatus
            });
            this.gvDrawings.GridControl = this.grdDrawings;
            this.gvDrawings.Name = "gvDrawings";
            this.gvDrawings.OptionsView.ShowAutoFilterRow = true;
            this.gvDrawings.OptionsView.ShowFooter = true;

            this.colDrawingNo.Caption = "رقم الرسم الهندسي";
            this.colDrawingNo.FieldName = "DrawingNo";
            this.colDrawingNo.Visible = true;
            this.colDrawingNo.VisibleIndex = 0;

            this.colTitle.Caption = "عنوان مخطط الرسم";
            this.colTitle.FieldName = "Title";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 1;

            this.colDiscipline.Caption = "التخصص الهندسي";
            this.colDiscipline.FieldName = "Discipline";
            this.colDiscipline.Visible = true;
            this.colDiscipline.VisibleIndex = 2;

            this.colRevision.Caption = "الإصدار الحالي";
            this.colRevision.FieldName = "Revision";
            this.colRevision.Visible = true;
            this.colRevision.VisibleIndex = 3;

            this.colIfcStatus.Caption = "حالة التنفيذ (IFC Status)";
            this.colIfcStatus.FieldName = "IfcStatus";
            this.colIfcStatus.Visible = true;
            this.colIfcStatus.VisibleIndex = 4;

            this.colLatestRevision.Caption = "أحدث revision";
            this.colLatestRevision.FieldName = "LatestRevision";
            this.colLatestRevision.Visible = true;
            this.colLatestRevision.VisibleIndex = 5;

            this.colIssueDate.Caption = "تاريخ الإصدار";
            this.colIssueDate.FieldName = "IssueDate";
            this.colIssueDate.Visible = true;
            this.colIssueDate.VisibleIndex = 6;

            this.colApprovalStatus.Caption = "حالة الاعتماد التعاقدي";
            this.colApprovalStatus.FieldName = "ApprovalStatus";
            this.colApprovalStatus.Visible = true;
            this.colApprovalStatus.VisibleIndex = 7;

            // pnlDrawingPreview
            this.pnlDrawingPreview.Controls.Add(this.lblPreviewHeader);
            this.pnlDrawingPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDrawingPreview.Location = new System.Drawing.Point(0, 0);
            this.pnlDrawingPreview.Name = "pnlDrawingPreview";
            this.pnlDrawingPreview.Size = new System.Drawing.Size(440, 35);

            this.lblPreviewHeader.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblPreviewHeader.Location = new System.Drawing.Point(10, 8);
            this.lblPreviewHeader.Text = "معاينة الرسم الهندسي المباشرة (Drawing Preview)";

            // pdfViewerDrawing
            this.pdfViewerDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewerDrawing.Location = new System.Drawing.Point(0, 35);
            this.pdfViewerDrawing.Name = "pdfViewerDrawing";
            this.pdfViewerDrawing.Size = new System.Drawing.Size(440, 685);

            // ucDrawingRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucDrawingRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDrawings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDrawings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawingPreview)).EndInit();
            this.pnlDrawingPreview.ResumeLayout(false);
            this.pnlDrawingPreview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewDrawing;
        private DevExpress.XtraBars.BarButtonItem bbiEditDrawing;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdDrawings;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDrawings;
        private DevExpress.XtraGrid.Columns.GridColumn colDrawingNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn colRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colIfcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colLatestRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovalStatus;
        private DevExpress.XtraEditors.PanelControl pnlDrawingPreview;
        private DevExpress.XtraEditors.LabelControl lblPreviewHeader;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewerDrawing;
    }
}
