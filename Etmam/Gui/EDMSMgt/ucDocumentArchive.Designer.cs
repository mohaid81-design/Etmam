namespace Etmam.Gui.EDMSMgt
{
    partial class ucDocumentArchive
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
            this.bbiNewFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportArchive = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeArchive = new DevExpress.XtraTreeList.TreeList();
            this.colTreeFolder = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.grdArchivedDocs = new DevExpress.XtraGrid.GridControl();
            this.gvArchivedDocs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocument = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStorage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeArchive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArchivedDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArchivedDocs)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewFolder, this.bbiExportArchive, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewFolder),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportArchive),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات أرشيف الوثائق";

            this.bbiNewFolder.Caption = "إنشاء مجلد أرشيف فرعي";
            this.bbiExportArchive.Caption = "تصدير الأرشيف المفهومي";
            this.bbiPrint.Caption = "طباعة سجل الأرشيف";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.treeArchive);
            this.splitContainerControlMain.Panel1.Text = "شجرة الأرشيف والهيكل التنظيمي";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdArchivedDocs);
            this.splitContainerControlMain.Panel2.Text = "الوثائق المؤرشفة داخل المجلد";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 350;

            // treeArchive
            this.treeArchive.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { this.colTreeFolder });
            this.treeArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeArchive.Location = new System.Drawing.Point(0, 0);
            this.treeArchive.Name = "treeArchive";
            this.treeArchive.Size = new System.Drawing.Size(350, 720);

            this.colTreeFolder.Caption = "مجلدات الأرشيف (Project / Discipline / Year)";
            this.colTreeFolder.FieldName = "Folder";
            this.colTreeFolder.Visible = true;
            this.colTreeFolder.VisibleIndex = 0;

            // grdArchivedDocs
            this.grdArchivedDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdArchivedDocs.Location = new System.Drawing.Point(0, 0);
            this.grdArchivedDocs.MainView = this.gvArchivedDocs;
            this.grdArchivedDocs.Name = "grdArchivedDocs";
            this.grdArchivedDocs.Size = new System.Drawing.Size(840, 720);
            this.grdArchivedDocs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvArchivedDocs });

            // gvArchivedDocs
            this.gvArchivedDocs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colDocument, this.colRevision, this.colArchiveDate,
                this.colStorage, this.colStatus
            });
            this.gvArchivedDocs.GridControl = this.grdArchivedDocs;
            this.gvArchivedDocs.Name = "gvArchivedDocs";
            this.gvArchivedDocs.OptionsView.ShowAutoFilterRow = true;
            this.gvArchivedDocs.OptionsView.ShowFooter = true;

            this.colDocument.Caption = "اسم الوثيقة / المستند المؤرشف";
            this.colDocument.FieldName = "Document";
            this.colDocument.Visible = true;
            this.colDocument.VisibleIndex = 0;

            this.colRevision.Caption = "الإصدار (Rev)";
            this.colRevision.FieldName = "Revision";
            this.colRevision.Visible = true;
            this.colRevision.VisibleIndex = 1;

            this.colArchiveDate.Caption = "تاريخ الأرشفة";
            this.colArchiveDate.FieldName = "ArchiveDate";
            this.colArchiveDate.Visible = true;
            this.colArchiveDate.VisibleIndex = 2;

            this.colStorage.Caption = "مكان التخزين / المسار الفيزيائي";
            this.colStorage.FieldName = "Storage";
            this.colStorage.Visible = true;
            this.colStorage.VisibleIndex = 3;

            this.colStatus.Caption = "حالة الأرشيف";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            // ucDocumentArchive
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucDocumentArchive";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeArchive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArchivedDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArchivedDocs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewFolder;
        private DevExpress.XtraBars.BarButtonItem bbiExportArchive;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraTreeList.TreeList treeArchive;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeFolder;
        private DevExpress.XtraGrid.GridControl grdArchivedDocs;
        private DevExpress.XtraGrid.Views.Grid.GridView gvArchivedDocs;
        private DevExpress.XtraGrid.Columns.GridColumn colDocument;
        private DevExpress.XtraGrid.Columns.GridColumn colRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStorage;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
