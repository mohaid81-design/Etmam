namespace Etmam.Gui.QualityMgt
{
    partial class ucSiteInspection
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
            this.bbiNewSiteInsp = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdSiteInsp = new DevExpress.XtraGrid.GridControl();
            this.gvSiteInsp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInspector = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhotos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlLocationMap = new DevExpress.XtraEditors.PanelControl();
            this.lblMapTitle = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSiteInsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSiteInsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLocationMap)).BeginInit();
            this.pnlLocationMap.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewSiteInsp, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewSiteInsp),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات الفحص الميداني للموقع";

            this.bbiNewSiteInsp.Caption = "تسجيل جولـة جودة ميدانية (Site Inspection)";
            this.bbiExport.Caption = "تصدير التقرير الميداني";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdSiteInsp);
            this.splitContainerControlMain.Panel1.Text = "سجل الملاحظات والجولات الميدانية";
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlLocationMap);
            this.splitContainerControlMain.Panel2.Text = "خريطة الموقع والمحاور (Location Map Picker)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 800;

            // grdSiteInsp
            this.grdSiteInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSiteInsp.Location = new System.Drawing.Point(0, 0);
            this.grdSiteInsp.MainView = this.gvSiteInsp;
            this.grdSiteInsp.Name = "grdSiteInsp";
            this.grdSiteInsp.Size = new System.Drawing.Size(800, 720);
            this.grdSiteInsp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvSiteInsp });

            // gvSiteInsp
            this.gvSiteInsp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colArea, this.colActivity, this.colInspector,
                this.colResult, this.colRemarks, this.colPhotos
            });
            this.gvSiteInsp.GridControl = this.grdSiteInsp;
            this.gvSiteInsp.Name = "gvSiteInsp";
            this.gvSiteInsp.OptionsView.ShowAutoFilterRow = true;
            this.gvSiteInsp.OptionsView.ShowFooter = true;

            this.colArea.Caption = "المنطقة / المبنى / الدور / العنصر";
            this.colArea.FieldName = "Area";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 0;

            this.colActivity.Caption = "النشاط المعاين (Activity)";
            this.colActivity.FieldName = "Activity";
            this.colActivity.Visible = true;
            this.colActivity.VisibleIndex = 1;

            this.colInspector.Caption = "المفتش / مهندس الموقع";
            this.colInspector.FieldName = "Inspector";
            this.colInspector.Visible = true;
            this.colInspector.VisibleIndex = 2;

            this.colResult.Caption = "نتيجة المعاينة";
            this.colResult.FieldName = "Result";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 3;

            this.colRemarks.Caption = "الملاحظات والتوجيهات الميدانية";
            this.colRemarks.FieldName = "Remarks";
            this.colRemarks.Visible = true;
            this.colRemarks.VisibleIndex = 4;

            this.colPhotos.Caption = "عدد الصور المرفقة";
            this.colPhotos.FieldName = "Photos";
            this.colPhotos.Visible = true;
            this.colPhotos.VisibleIndex = 5;

            // pnlLocationMap
            this.pnlLocationMap.Controls.Add(this.lblMapTitle);
            this.pnlLocationMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLocationMap.Location = new System.Drawing.Point(0, 0);
            this.pnlLocationMap.Name = "pnlLocationMap";
            this.pnlLocationMap.Size = new System.Drawing.Size(390, 720);

            this.lblMapTitle.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMapTitle.Location = new System.Drawing.Point(10, 15);
            this.lblMapTitle.Text = "مخطط خريطة الموقع والتركيز البصري (Heat Map)";

            // ucSiteInspection
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucSiteInspection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSiteInsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSiteInsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLocationMap)).EndInit();
            this.pnlLocationMap.ResumeLayout(false);
            this.pnlLocationMap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewSiteInsp;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdSiteInsp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSiteInsp;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colInspector;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private DevExpress.XtraGrid.Columns.GridColumn colRemarks;
        private DevExpress.XtraGrid.Columns.GridColumn colPhotos;
        private DevExpress.XtraEditors.PanelControl pnlLocationMap;
        private DevExpress.XtraEditors.LabelControl lblMapTitle;
    }
}
