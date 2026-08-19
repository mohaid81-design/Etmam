namespace Etmam.Gui.HSEMgt
{
    partial class ucEmergencyPreparedness
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
            this.bbiNewDrill = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditPlan = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tabEmergency = new DevExpress.XtraTab.XtraTabControl();
            this.tpPlans = new DevExpress.XtraTab.XtraTabPage();
            this.tpContacts = new DevExpress.XtraTab.XtraTabPage();
            this.tpAssemblyPoints = new DevExpress.XtraTab.XtraTabPage();
            this.tpDrills = new DevExpress.XtraTab.XtraTabPage();
            this.grdDrills = new DevExpress.XtraGrid.GridControl();
            this.gvDrills = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDrill = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLessonsLearned = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpFireEquipment = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEmergency)).BeginInit();
            this.tabEmergency.SuspendLayout();
            this.tpDrills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDrills)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewDrill, this.bbiEditPlan, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewDrill),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditPlan),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات خطط الإخلاء والجاهزية للطوارئ";

            this.bbiNewDrill.Caption = "تسجيل تجربة إخلاء جديدة (Emergency Drill)";
            this.bbiEditPlan.Caption = "تحديث خطة الإخلاء والدفاع المدني";
            this.bbiExport.Caption = "تصدير دليل الطوارئ";

            // tabEmergency
            this.tabEmergency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEmergency.Location = new System.Drawing.Point(0, 30);
            this.tabEmergency.Name = "tabEmergency";
            this.tabEmergency.SelectedTabPage = this.tpDrills;
            this.tabEmergency.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpPlans,
                this.tpContacts,
                this.tpAssemblyPoints,
                this.tpDrills,
                this.tpFireEquipment
            });
            this.tabEmergency.Size = new System.Drawing.Size(1200, 720);

            this.tpPlans.Text = "خطط الإخلاء والطوارئ (Emergency Plans)";
            this.tpContacts.Text = "أرقام وتواصل فريق الطوارئ والدفاع المدني (Contacts)";
            this.tpAssemblyPoints.Text = "نقاط التجمع ومخارج الطوارئ (Assembly Points)";
            
            // tpDrills
            this.tpDrills.Controls.Add(this.grdDrills);
            this.tpDrills.Text = "تجارب وفرضيات الإخلاء الدوري (Emergency Drills)";

            // grdDrills
            this.grdDrills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDrills.Location = new System.Drawing.Point(0, 0);
            this.grdDrills.MainView = this.gvDrills;
            this.grdDrills.Name = "grdDrills";
            this.grdDrills.Size = new System.Drawing.Size(1198, 685);
            this.grdDrills.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvDrills });

            // gvDrills
            this.gvDrills.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colDrill, this.colDate, this.colArea,
                this.colResult, this.colLessonsLearned
            });
            this.gvDrills.GridControl = this.grdDrills;
            this.gvDrills.Name = "gvDrills";
            this.gvDrills.OptionsView.ShowAutoFilterRow = true;
            this.gvDrills.OptionsView.ShowFooter = true;

            this.colDrill.Caption = "عنوان وتصنيف تجربة الإخلاء";
            this.colDrill.FieldName = "Drill";
            this.colDrill.Visible = true;
            this.colDrill.VisibleIndex = 0;

            this.colDate.Caption = "تاريخ ووقت التكليف بالتجربة";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;

            this.colArea.Caption = "المنطقة / المبنى الخاضع للإخلاء";
            this.colArea.FieldName = "Area";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 2;

            this.colResult.Caption = "زمن الإخلاء ونتيجة التجربة (Result Time)";
            this.colResult.FieldName = "Result";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 3;

            this.colLessonsLearned.Caption = "الدروس المستفادة والتوصيات (Lessons Learned)";
            this.colLessonsLearned.FieldName = "LessonsLearned";
            this.colLessonsLearned.Visible = true;
            this.colLessonsLearned.VisibleIndex = 4;

            this.tpFireEquipment.Text = "سجل معدات وأجهزة المكافحة والإنذار (Fire Equipment)";

            // ucEmergencyPreparedness
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.tabEmergency);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucEmergencyPreparedness";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEmergency)).EndInit();
            this.tabEmergency.ResumeLayout(false);
            this.tpDrills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDrills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDrills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewDrill;
        private DevExpress.XtraBars.BarButtonItem bbiEditPlan;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTab.XtraTabControl tabEmergency;
        private DevExpress.XtraTab.XtraTabPage tpPlans;
        private DevExpress.XtraTab.XtraTabPage tpContacts;
        private DevExpress.XtraTab.XtraTabPage tpAssemblyPoints;
        private DevExpress.XtraTab.XtraTabPage tpDrills;
        private DevExpress.XtraGrid.GridControl grdDrills;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDrills;
        private DevExpress.XtraGrid.Columns.GridColumn colDrill;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private DevExpress.XtraGrid.Columns.GridColumn colLessonsLearned;
        private DevExpress.XtraTab.XtraTabPage tpFireEquipment;
    }
}
