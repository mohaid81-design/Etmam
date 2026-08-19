namespace Etmam.Gui.QualityMgt
{
    partial class ucInspectionRequestRegister
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
            this.bbiNewIR = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditIR = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSubmitIR = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSchedule = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlFilters = new DevExpress.XtraEditors.PanelControl();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboDiscipline = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grdIR = new DevExpress.XtraGrid.GridControl();
            this.gvIR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIRNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInspectionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInspector = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConsultant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilters)).BeginInit();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDiscipline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIR)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewIR, this.bbiEditIR, this.bbiSubmitIR,
                this.bbiSchedule, this.bbiPrint, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewIR),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditIR),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSubmitIR),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSchedule),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل طلبات الفحص (IR)";

            this.bbiNewIR.Caption = "طلب فحص جديد (New IR)";
            this.bbiEditIR.Caption = "تعديل الطلب";
            this.bbiSubmitIR.Caption = "تقديم للاستشاري";
            this.bbiSchedule.Caption = "جدولة موعد الفحص";
            this.bbiPrint.Caption = "طباعة النموذج";
            this.bbiExport.Caption = "تصدير إلى Excel/PDF";

            // pnlFilters
            this.pnlFilters.Controls.Add(this.cboProject);
            this.pnlFilters.Controls.Add(this.cboDiscipline);
            this.pnlFilters.Controls.Add(this.cboType);
            this.pnlFilters.Controls.Add(this.cboStatus);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 30);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1200, 45);

            // grdIR
            this.grdIR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIR.Location = new System.Drawing.Point(0, 75);
            this.grdIR.MainView = this.gvIR;
            this.grdIR.Name = "grdIR";
            this.grdIR.Size = new System.Drawing.Size(1200, 675);
            this.grdIR.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvIR });

            // gvIR
            this.gvIR.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colIRNo, this.colProject, this.colActivity,
                this.colDiscipline, this.colInspectionDate, this.colInspector,
                this.colConsultant, this.colResult, this.colStatus
            });
            this.gvIR.GridControl = this.grdIR;
            this.gvIR.Name = "gvIR";
            this.gvIR.OptionsView.ShowAutoFilterRow = true;
            this.gvIR.OptionsView.ShowFooter = true;

            this.colIRNo.Caption = "رقم طلب الفحص (IR No)";
            this.colIRNo.FieldName = "IRNo";
            this.colIRNo.Visible = true;
            this.colIRNo.VisibleIndex = 0;

            this.colProject.Caption = "المشروع التابع";
            this.colProject.FieldName = "Project";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 1;

            this.colActivity.Caption = "النشاط / البند الخاضع للفحص";
            this.colActivity.FieldName = "Activity";
            this.colActivity.Visible = true;
            this.colActivity.VisibleIndex = 2;

            this.colDiscipline.Caption = "التخصص (Civil/MEP/Arch)";
            this.colDiscipline.FieldName = "Discipline";
            this.colDiscipline.Visible = true;
            this.colDiscipline.VisibleIndex = 3;

            this.colInspectionDate.Caption = "تاريخ وموعد الفحص";
            this.colInspectionDate.FieldName = "InspectionDate";
            this.colInspectionDate.Visible = true;
            this.colInspectionDate.VisibleIndex = 4;

            this.colInspector.Caption = "مهندس الجودة بالموقع";
            this.colInspector.FieldName = "Inspector";
            this.colInspector.Visible = true;
            this.colInspector.VisibleIndex = 5;

            this.colConsultant.Caption = "مفتش الاستشاري";
            this.colConsultant.FieldName = "Consultant";
            this.colConsultant.Visible = true;
            this.colConsultant.VisibleIndex = 6;

            this.colResult.Caption = "نتيجة الفحص (Pass/Fail)";
            this.colResult.FieldName = "Result";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 7;

            this.colStatus.Caption = "حالة الطلب التشغيلية";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 8;

            // ucInspectionRequestRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdIR);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucInspectionRequestRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilters)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDiscipline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewIR;
        private DevExpress.XtraBars.BarButtonItem bbiEditIR;
        private DevExpress.XtraBars.BarButtonItem bbiSubmitIR;
        private DevExpress.XtraBars.BarButtonItem bbiSchedule;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlFilters;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.ComboBoxEdit cboDiscipline;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraGrid.GridControl grdIR;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIR;
        private DevExpress.XtraGrid.Columns.GridColumn colIRNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn colInspectionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInspector;
        private DevExpress.XtraGrid.Columns.GridColumn colConsultant;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
