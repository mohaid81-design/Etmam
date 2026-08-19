namespace Etmam.Gui.QualityMgt
{
    partial class ucMaterialInspection
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
            this.bbiNewInspection = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApprove = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReject = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblPending = new DevExpress.XtraEditors.LabelControl();
            this.lblApproved = new DevExpress.XtraEditors.LabelControl();
            this.lblRejected = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdMaterialInsp = new DevExpress.XtraGrid.GridControl();
            this.gvMaterialInsp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInspectionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPreview = new DevExpress.XtraTab.XtraTabControl();
            this.tpCertificates = new DevExpress.XtraTab.XtraTabPage();
            this.pdfViewerCert = new DevExpress.XtraPdfViewer.PdfViewer();
            this.tpMsr = new DevExpress.XtraTab.XtraTabPage();
            this.tpPhotos = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterialInsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterialInsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPreview)).BeginInit();
            this.tabPreview.SuspendLayout();
            this.tpCertificates.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewInspection, this.bbiApprove, this.bbiReject
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewInspection),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiApprove),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiReject)
            });
            this.barMain.Text = "أدوات فحص المواد والموردات";

            this.bbiNewInspection.Caption = "فحص شحنة جديدة (Material Inspection)";
            this.bbiApprove.Caption = "اعتماد الفحص (Pass)";
            this.bbiReject.Caption = "رفض وإرجاع (Reject)";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblPending);
            this.pnlCards.Controls.Add(this.lblApproved);
            this.pnlCards.Controls.Add(this.lblRejected);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblPending.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPending.Location = new System.Drawing.Point(950, 15);
            this.lblPending.Text = "شحنات بانتظار الفحص: 6";

            this.lblApproved.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApproved.Location = new System.Drawing.Point(650, 15);
            this.lblApproved.Text = "مواد معتمدة: 142";

            this.lblRejected.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRejected.Location = new System.Drawing.Point(350, 15);
            this.lblRejected.Text = "مواد مرفوضة: 3";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdMaterialInsp);
            this.splitContainerControlMain.Panel1.Text = "جدول فحوصات المواد والكراتين";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabPreview);
            this.splitContainerControlMain.Panel2.Text = "معاينة الشهادات والـ MSR والصور";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 750;

            // grdMaterialInsp
            this.grdMaterialInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaterialInsp.Location = new System.Drawing.Point(0, 0);
            this.grdMaterialInsp.MainView = this.gvMaterialInsp;
            this.grdMaterialInsp.Name = "grdMaterialInsp";
            this.grdMaterialInsp.Size = new System.Drawing.Size(750, 670);
            this.grdMaterialInsp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvMaterialInsp });

            // gvMaterialInsp
            this.gvMaterialInsp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colMaterial, this.colSupplier, this.colBatch,
                this.colInspectionDate, this.colStatus
            });
            this.gvMaterialInsp.GridControl = this.grdMaterialInsp;
            this.gvMaterialInsp.Name = "gvMaterialInsp";
            this.gvMaterialInsp.OptionsView.ShowAutoFilterRow = true;
            this.gvMaterialInsp.OptionsView.ShowFooter = true;

            this.colMaterial.Caption = "المادة / الخام المورد";
            this.colMaterial.FieldName = "Material";
            this.colMaterial.Visible = true;
            this.colMaterial.VisibleIndex = 0;

            this.colSupplier.Caption = "المورد / المصنع (Supplier)";
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 1;

            this.colBatch.Caption = "رقم الشحنة / الوجبة (Batch No)";
            this.colBatch.FieldName = "Batch";
            this.colBatch.Visible = true;
            this.colBatch.VisibleIndex = 2;

            this.colInspectionDate.Caption = "تاريخ الفحص والمستلم";
            this.colInspectionDate.FieldName = "InspectionDate";
            this.colInspectionDate.Visible = true;
            this.colInspectionDate.VisibleIndex = 3;

            this.colStatus.Caption = "حالة الفحص";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            // tabPreview
            this.tabPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPreview.Location = new System.Drawing.Point(0, 0);
            this.tabPreview.Name = "tabPreview";
            this.tabPreview.SelectedTabPage = this.tpCertificates;
            this.tabPreview.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpCertificates,
                this.tpMsr,
                this.tpPhotos
            });
            this.tabPreview.Size = new System.Drawing.Size(440, 670);

            this.tpCertificates.Controls.Add(this.pdfViewerCert);
            this.tpCertificates.Text = "شهادات الجودة (Mill Certs)";
            this.pdfViewerCert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewerCert.Location = new System.Drawing.Point(0, 0);
            this.pdfViewerCert.Name = "pdfViewerCert";
            this.pdfViewerCert.Size = new System.Drawing.Size(438, 635);

            this.tpMsr.Text = "طلب الاعتماد (MSR)";
            this.tpPhotos.Text = "صور العينة والشحنة";

            // ucMaterialInspection
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucMaterialInspection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterialInsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterialInsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPreview)).EndInit();
            this.tabPreview.SuspendLayout();
            this.tpCertificates.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewInspection;
        private DevExpress.XtraBars.BarButtonItem bbiApprove;
        private DevExpress.XtraBars.BarButtonItem bbiReject;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblPending;
        private DevExpress.XtraEditors.LabelControl lblApproved;
        private DevExpress.XtraEditors.LabelControl lblRejected;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdMaterialInsp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaterialInsp;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colBatch;
        private DevExpress.XtraGrid.Columns.GridColumn colInspectionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraTab.XtraTabControl tabPreview;
        private DevExpress.XtraTab.XtraTabPage tpCertificates;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewerCert;
        private DevExpress.XtraTab.XtraTabPage tpMsr;
        private DevExpress.XtraTab.XtraTabPage tpPhotos;
    }
}
