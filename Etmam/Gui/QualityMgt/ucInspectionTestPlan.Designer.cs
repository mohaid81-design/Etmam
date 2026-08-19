namespace Etmam.Gui.QualityMgt
{
    partial class ucInspectionTestPlan
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
            this.bbiNewPoint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditPoint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeITP = new DevExpress.XtraTreeList.TreeList();
            this.colNodeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.grdITP = new DevExpress.XtraGrid.GridControl();
            this.gvITP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoldPoint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWitnessPoint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrequency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsible = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeITP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdITP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvITP)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewPoint, this.bbiEditPoint, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewPoint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditPoint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات خطة الفحص والاختبار ITP";

            this.bbiNewPoint.Caption = "إضافة نقطة فحص جديدة";
            this.bbiEditPoint.Caption = "تعديل النقطة والمعايير";
            this.bbiExport.Caption = "تصدير جدول ITP الكامل";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.treeITP);
            this.splitContainerControlMain.Panel1.Text = "هيكل خطة الفحص ITP (Project/Discipline/Activity)";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdITP);
            this.splitContainerControlMain.Panel2.Text = "جدول تفاصيل نقاط Hold & Witness Points";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 300;

            // treeITP
            this.treeITP.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { this.colNodeName });
            this.treeITP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeITP.Location = new System.Drawing.Point(0, 0);
            this.treeITP.Name = "treeITP";
            this.treeITP.Size = new System.Drawing.Size(300, 720);

            this.colNodeName.Caption = "هيكل أربطة الفحص الاختباري";
            this.colNodeName.FieldName = "NodeName";
            this.colNodeName.Visible = true;
            this.colNodeName.VisibleIndex = 0;

            // grdITP
            this.grdITP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdITP.Location = new System.Drawing.Point(0, 0);
            this.grdITP.MainView = this.gvITP;
            this.grdITP.Name = "grdITP";
            this.grdITP.Size = new System.Drawing.Size(890, 720);
            this.grdITP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvITP });

            // gvITP
            this.gvITP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colActivity, this.colHoldPoint, this.colWitnessPoint,
                this.colMethod, this.colStandard, this.colFrequency, this.colResponsible
            });
            this.gvITP.GridControl = this.grdITP;
            this.gvITP.Name = "gvITP";
            this.gvITP.OptionsView.ShowAutoFilterRow = true;
            this.gvITP.OptionsView.ShowFooter = true;

            this.colActivity.Caption = "النشاط الإنشائي / الفني";
            this.colActivity.FieldName = "Activity";
            this.colActivity.Visible = true;
            this.colActivity.VisibleIndex = 0;

            this.colHoldPoint.Caption = "نقطة التوقف الحرج (Hold Point)";
            this.colHoldPoint.FieldName = "HoldPoint";
            this.colHoldPoint.Visible = true;
            this.colHoldPoint.VisibleIndex = 1;

            this.colWitnessPoint.Caption = "نقطة الحضور (Witness Point)";
            this.colWitnessPoint.FieldName = "WitnessPoint";
            this.colWitnessPoint.Visible = true;
            this.colWitnessPoint.VisibleIndex = 2;

            this.colMethod.Caption = "طريقة واسلوب الفحص (Method)";
            this.colMethod.FieldName = "Method";
            this.colMethod.Visible = true;
            this.colMethod.VisibleIndex = 3;

            this.colStandard.Caption = "المعيار / الكود المرجعي (Standard)";
            this.colStandard.FieldName = "Standard";
            this.colStandard.Visible = true;
            this.colStandard.VisibleIndex = 4;

            this.colFrequency.Caption = "معدل وتكرار الفحص (Frequency)";
            this.colFrequency.FieldName = "Frequency";
            this.colFrequency.Visible = true;
            this.colFrequency.VisibleIndex = 5;

            this.colResponsible.Caption = "الجهة والمسؤول المعتمد";
            this.colResponsible.FieldName = "Responsible";
            this.colResponsible.Visible = true;
            this.colResponsible.VisibleIndex = 6;

            // ucInspectionTestPlan
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucInspectionTestPlan";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeITP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdITP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvITP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewPoint;
        private DevExpress.XtraBars.BarButtonItem bbiEditPoint;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraTreeList.TreeList treeITP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNodeName;
        private DevExpress.XtraGrid.GridControl grdITP;
        private DevExpress.XtraGrid.Views.Grid.GridView gvITP;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colHoldPoint;
        private DevExpress.XtraGrid.Columns.GridColumn colWitnessPoint;
        private DevExpress.XtraGrid.Columns.GridColumn colMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colStandard;
        private DevExpress.XtraGrid.Columns.GridColumn colFrequency;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsible;
    }
}
