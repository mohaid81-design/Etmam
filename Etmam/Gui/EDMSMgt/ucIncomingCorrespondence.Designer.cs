namespace Etmam.Gui.EDMSMgt
{
    partial class ucIncomingCorrespondence
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
            this.bbiNewIncoming = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditIncoming = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdIncoming = new DevExpress.XtraGrid.GridControl();
            this.gvIncoming = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceivedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlPreview = new DevExpress.XtraEditors.PanelControl();
            this.lblPreviewHeader = new DevExpress.XtraEditors.LabelControl();
            this.pdfViewerIncoming = new DevExpress.XtraPdfViewer.PdfViewer();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncoming)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIncoming)).BeginInit();
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
                this.bbiNewIncoming, this.bbiEditIncoming, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewIncoming),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditIncoming),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات المراسلات الواردة";

            this.bbiNewIncoming.Caption = "تسجيل خطاب وارد جديد";
            this.bbiEditIncoming.Caption = "تعديل المعاملة";
            this.bbiPrint.Caption = "طباعة سجل الوارد";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdIncoming);
            this.splitContainerControlMain.Panel1.Text = "سجل الخطابات والمراسلات الواردة";
            this.splitContainerControlMain.Panel2.Controls.Add(this.pdfViewerIncoming);
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlPreview);
            this.splitContainerControlMain.Panel2.Text = "معاينة الخطاب المباشرة";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 750;

            // grdIncoming
            this.grdIncoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIncoming.Location = new System.Drawing.Point(0, 0);
            this.grdIncoming.MainView = this.gvIncoming;
            this.grdIncoming.Name = "grdIncoming";
            this.grdIncoming.Size = new System.Drawing.Size(750, 720);
            this.grdIncoming.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvIncoming });

            // gvIncoming
            this.gvIncoming.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colReference, this.colSubject, this.colFrom,
                this.colReceivedDate, this.colProject, this.colStatus
            });
            this.gvIncoming.GridControl = this.grdIncoming;
            this.gvIncoming.Name = "gvIncoming";
            this.gvIncoming.OptionsView.ShowAutoFilterRow = true;
            this.gvIncoming.OptionsView.ShowFooter = true;

            this.colReference.Caption = "الرقم الإشاري (Reference)";
            this.colReference.FieldName = "Reference";
            this.colReference.Visible = true;
            this.colReference.VisibleIndex = 0;

            this.colSubject.Caption = "موضوع المعاملة / الخطاب الوارد";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;

            this.colFrom.Caption = "الجهة المرسِلة (From)";
            this.colFrom.FieldName = "From";
            this.colFrom.Visible = true;
            this.colFrom.VisibleIndex = 2;

            this.colReceivedDate.Caption = "تاريخ الاستلام";
            this.colReceivedDate.FieldName = "ReceivedDate";
            this.colReceivedDate.Visible = true;
            this.colReceivedDate.VisibleIndex = 3;

            this.colProject.Caption = "المشروع التابع";
            this.colProject.FieldName = "Project";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 4;

            this.colStatus.Caption = "حالة المعالجة والتوجيه";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // pnlPreview
            this.pnlPreview.Controls.Add(this.lblPreviewHeader);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPreview.Location = new System.Drawing.Point(0, 0);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(440, 35);

            this.lblPreviewHeader.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblPreviewHeader.Location = new System.Drawing.Point(10, 8);
            this.lblPreviewHeader.Text = "معاينة الخطاب الوارد (Letter Preview)";

            // pdfViewerIncoming
            this.pdfViewerIncoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewerIncoming.Location = new System.Drawing.Point(0, 35);
            this.pdfViewerIncoming.Name = "pdfViewerIncoming";
            this.pdfViewerIncoming.Size = new System.Drawing.Size(440, 685);

            // ucIncomingCorrespondence
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucIncomingCorrespondence";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncoming)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIncoming)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreview)).EndInit();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewIncoming;
        private DevExpress.XtraBars.BarButtonItem bbiEditIncoming;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdIncoming;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIncoming;
        private DevExpress.XtraGrid.Columns.GridColumn colReference;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colReceivedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.PanelControl pnlPreview;
        private DevExpress.XtraEditors.LabelControl lblPreviewHeader;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewerIncoming;
    }
}
