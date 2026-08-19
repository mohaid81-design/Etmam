namespace Etmam.Gui.HSEMgt
{
    partial class ucSafetyInspection
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
            this.bbiEditInspection = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdSafetyInsp = new DevExpress.XtraGrid.GridControl();
            this.gvSafetyInsp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInspectionNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInspector = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabInspDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tpChecklist = new DevExpress.XtraTab.XtraTabPage();
            this.tpPhotos = new DevExpress.XtraTab.XtraTabPage();
            this.tpActions = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSafetyInsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSafetyInsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabInspDetails)).BeginInit();
            this.tabInspDetails.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewInspection, this.bbiEditInspection, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewInspection),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditInspection),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات جولات وفحوصات السلامة الميدانية";

            this.bbiNewInspection.Caption = "جولة تفتيش سلامة جديدة";
            this.bbiEditInspection.Caption = "تعديل نتائج الجولة";
            this.bbiExport.Caption = "تصدير السجل التفتيشي";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdSafetyInsp);
            this.splitContainerControlMain.Panel1.Text = "سجل جولات التفتيش والـ Safety Audits";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabInspDetails);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل القوائم المرجعية والصور والإجراءات التصحيحية";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 420;

            // grdSafetyInsp
            this.grdSafetyInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSafetyInsp.Location = new System.Drawing.Point(0, 0);
            this.grdSafetyInsp.MainView = this.gvSafetyInsp;
            this.grdSafetyInsp.Name = "grdSafetyInsp";
            this.grdSafetyInsp.Size = new System.Drawing.Size(1200, 420);
            this.grdSafetyInsp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvSafetyInsp });

            // gvSafetyInsp
            this.gvSafetyInsp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colInspectionNo, this.colArea, this.colInspector,
                this.colDate, this.colScore, this.colStatus
            });
            this.gvSafetyInsp.GridControl = this.grdSafetyInsp;
            this.gvSafetyInsp.Name = "gvSafetyInsp";
            this.gvSafetyInsp.OptionsView.ShowAutoFilterRow = true;
            this.gvSafetyInsp.OptionsView.ShowFooter = true;

            this.colInspectionNo.Caption = "رقم الجولة / الفحص (Inspection No)";
            this.colInspectionNo.FieldName = "InspectionNo";
            this.colInspectionNo.Visible = true;
            this.colInspectionNo.VisibleIndex = 0;

            this.colArea.Caption = "المنطقة والموقع التفتيشي";
            this.colArea.FieldName = "Area";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 1;

            this.colInspector.Caption = "مفتش السلامة المسؤول";
            this.colInspector.FieldName = "Inspector";
            this.colInspector.Visible = true;
            this.colInspector.VisibleIndex = 2;

            this.colDate.Caption = "تاريخ وموعد الجولة";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 3;

            this.colScore.Caption = "درجة الالتزام بالسلامة (Safety Score %)";
            this.colScore.FieldName = "Score";
            this.colScore.Visible = true;
            this.colScore.VisibleIndex = 4;

            this.colStatus.Caption = "حالة الجولة والـ Audit";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // tabInspDetails
            this.tabInspDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInspDetails.Location = new System.Drawing.Point(0, 0);
            this.tabInspDetails.Name = "tabInspDetails";
            this.tabInspDetails.SelectedTabPage = this.tpChecklist;
            this.tabInspDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpChecklist,
                this.tpPhotos,
                this.tpActions,
                this.tpWorkflow
            });
            this.tabInspDetails.Size = new System.Drawing.Size(1200, 290);

            this.tpChecklist.Text = "قائمة التدقيق والتفتيش (Checklist)";
            this.tpPhotos.Text = "معرض الصور الموقعية (Photos)";
            this.tpActions.Text = "الإجراءات التصحيحية الميدانية (Actions)";
            this.tpWorkflow.Text = "مسار الاعتماد وملاحظات المفتش (Workflow)";

            // ucSafetyInspection
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucSafetyInspection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSafetyInsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSafetyInsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabInspDetails)).EndInit();
            this.tabInspDetails.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewInspection;
        private DevExpress.XtraBars.BarButtonItem bbiEditInspection;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdSafetyInsp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSafetyInsp;
        private DevExpress.XtraGrid.Columns.GridColumn colInspectionNo;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colInspector;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colScore;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraTab.XtraTabControl tabInspDetails;
        private DevExpress.XtraTab.XtraTabPage tpChecklist;
        private DevExpress.XtraTab.XtraTabPage tpPhotos;
        private DevExpress.XtraTab.XtraTabPage tpActions;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
    }
}
