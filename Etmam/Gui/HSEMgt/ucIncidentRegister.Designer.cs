namespace Etmam.Gui.HSEMgt
{
    partial class ucIncidentRegister
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
            this.bbiNewIncident = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditIncident = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInvestigate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseIncident = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdIncidents = new DevExpress.XtraGrid.GridControl();
            this.gvIncidents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIncidentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInjuredPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLostTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabBottomDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tpPhotos = new DevExpress.XtraTab.XtraTabPage();
            this.tpWitnesses = new DevExpress.XtraTab.XtraTabPage();
            this.tpDocuments = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tpTimeline = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncidents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIncidents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabBottomDetails)).BeginInit();
            this.tabBottomDetails.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewIncident, this.bbiEditIncident, this.bbiInvestigate,
                this.bbiCloseIncident, this.bbiPrint, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewIncident),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditIncident),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiInvestigate),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCloseIncident),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل الحوادث والإصابات";

            this.bbiNewIncident.Caption = "بلاغ حادث جديد (New Incident)";
            this.bbiEditIncident.Caption = "تعديل التقرير";
            this.bbiInvestigate.Caption = "بدء تحقيق الحادث";
            this.bbiCloseIncident.Caption = "إغلاق ملف الحادث";
            this.bbiPrint.Caption = "طباعة بلاغ الحادث";
            this.bbiExport.Caption = "تصدير إلى Excel/PDF";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdIncidents);
            this.splitContainerControlMain.Panel1.Text = "سجل الحوادث والإنذارات الميدانية";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabBottomDetails);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل الحادث والشهود والمرفقات والـ Timeline";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 450;

            // grdIncidents
            this.grdIncidents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIncidents.Location = new System.Drawing.Point(0, 0);
            this.grdIncidents.MainView = this.gvIncidents;
            this.grdIncidents.Name = "grdIncidents";
            this.grdIncidents.Size = new System.Drawing.Size(1200, 450);
            this.grdIncidents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvIncidents });

            // gvIncidents
            this.gvIncidents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colIncidentNo, this.colProject, this.colDate,
                this.colTime, this.colLocation, this.colCategory,
                this.colSeverity, this.colInjuredPerson, this.colLostTime, this.colStatus
            });
            this.gvIncidents.GridControl = this.grdIncidents;
            this.gvIncidents.Name = "gvIncidents";
            this.gvIncidents.OptionsView.ShowAutoFilterRow = true;
            this.gvIncidents.OptionsView.ShowFooter = true;

            this.colIncidentNo.Caption = "رقم البلاغ (Incident No)";
            this.colIncidentNo.FieldName = "IncidentNo";
            this.colIncidentNo.Visible = true;
            this.colIncidentNo.VisibleIndex = 0;

            this.colProject.Caption = "المشروع التابع";
            this.colProject.FieldName = "Project";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 1;

            this.colDate.Caption = "تاريخ وقوع الحادث";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;

            this.colTime.Caption = "وقت الوقوع";
            this.colTime.FieldName = "Time";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 3;

            this.colLocation.Caption = "الموقع الدقيق بالمنشأة";
            this.colLocation.FieldName = "Location";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 4;

            this.colCategory.Caption = "تصنيف الحادث (Fatality/LTI/FirstAid)";
            this.colCategory.FieldName = "Category";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 5;

            this.colSeverity.Caption = "درجة الخطورة (Severity)";
            this.colSeverity.FieldName = "Severity";
            this.colSeverity.Visible = true;
            this.colSeverity.VisibleIndex = 6;

            this.colInjuredPerson.Caption = "الشخص المصاب / المتأثر";
            this.colInjuredPerson.FieldName = "InjuredPerson";
            this.colInjuredPerson.Visible = true;
            this.colInjuredPerson.VisibleIndex = 7;

            this.colLostTime.Caption = "الأيام المفقودة (Lost Hours/Days)";
            this.colLostTime.FieldName = "LostTime";
            this.colLostTime.Visible = true;
            this.colLostTime.VisibleIndex = 8;

            this.colStatus.Caption = "حالة البلاغ والتحقيق";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;

            // tabBottomDetails
            this.tabBottomDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBottomDetails.Location = new System.Drawing.Point(0, 0);
            this.tabBottomDetails.Name = "tabBottomDetails";
            this.tabBottomDetails.SelectedTabPage = this.tpPhotos;
            this.tabBottomDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpPhotos,
                this.tpWitnesses,
                this.tpDocuments,
                this.tpWorkflow,
                this.tpTimeline
            });
            this.tabBottomDetails.Size = new System.Drawing.Size(1200, 260);

            this.tpPhotos.Text = "صور الأدلة والموقع (Photos)";
            this.tpWitnesses.Text = "أقوال الشهود والتقارير الميدانية (Witnesses)";
            this.tpDocuments.Text = "المستندات والتقارير الطبية (Documents)";
            this.tpWorkflow.Text = "مسار الاعتماد وإشعار الجهات الرسمية (Workflow)";
            this.tpTimeline.Text = "الجدول الزمني للحادث والإجلاء (Timeline)";

            // ucIncidentRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucIncidentRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncidents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIncidents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabBottomDetails)).EndInit();
            this.tabBottomDetails.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewIncident;
        private DevExpress.XtraBars.BarButtonItem bbiEditIncident;
        private DevExpress.XtraBars.BarButtonItem bbiInvestigate;
        private DevExpress.XtraBars.BarButtonItem bbiCloseIncident;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdIncidents;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIncidents;
        private DevExpress.XtraGrid.Columns.GridColumn colIncidentNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colInjuredPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colLostTime;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraTab.XtraTabControl tabBottomDetails;
        private DevExpress.XtraTab.XtraTabPage tpPhotos;
        private DevExpress.XtraTab.XtraTabPage tpWitnesses;
        private DevExpress.XtraTab.XtraTabPage tpDocuments;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraTab.XtraTabPage tpTimeline;
    }
}
