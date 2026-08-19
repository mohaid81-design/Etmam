namespace Etmam.Gui.CostControlMgt
{
    partial class ucCostBreakdownStructure
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
            this.bbiAddNode = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditNode = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeCBS = new DevExpress.XtraTreeList.TreeList();
            this.colCbsNode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCostCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.grdCbsDetails = new DevExpress.XtraGrid.GridControl();
            this.gvCbsDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPackage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommitment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForecast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariance = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeCBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCbsDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCbsDetails)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiAddNode, this.bbiEditNode, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiAddNode),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditNode),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات هيكل تجزئة التكاليف CBS";

            this.bbiAddNode.Caption = "إضافة بند / رمز تكلفة جديد";
            this.bbiEditNode.Caption = "تعديل تفاصيل CBS";
            this.bbiExport.Caption = "تصدير شجرة CBS كاملة";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.treeCBS);
            this.splitContainerControlMain.Panel1.Text = "شجرة CBS (Project -> Phase -> Building -> Zone -> Work Package -> Cost Code)";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdCbsDetails);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل وميزانية البند التكليفي (Budget, Commitments, Actual, Forecast, Variance)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 350;

            // treeCBS
            this.treeCBS.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
                this.colCbsNode, this.colCostCode
            });
            this.treeCBS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCBS.Location = new System.Drawing.Point(0, 0);
            this.treeCBS.Name = "treeCBS";
            this.treeCBS.Size = new System.Drawing.Size(350, 720);

            this.colCbsNode.Caption = "هيكل التكلفة (CBS Hierarchy)";
            this.colCbsNode.FieldName = "CbsNode";
            this.colCbsNode.Visible = true;
            this.colCbsNode.VisibleIndex = 0;

            this.colCostCode.Caption = "رمز التكلفة (Cost Code)";
            this.colCostCode.FieldName = "CostCode";
            this.colCostCode.Visible = true;
            this.colCostCode.VisibleIndex = 1;

            // grdCbsDetails
            this.grdCbsDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCbsDetails.Location = new System.Drawing.Point(0, 0);
            this.grdCbsDetails.MainView = this.gvCbsDetails;
            this.grdCbsDetails.Name = "grdCbsDetails";
            this.grdCbsDetails.Size = new System.Drawing.Size(840, 720);
            this.grdCbsDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvCbsDetails });

            // gvCbsDetails
            this.gvCbsDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colPackage, this.colBudget, this.colCommitment,
                this.colActual, this.colForecast, this.colVariance
            });
            this.gvCbsDetails.GridControl = this.grdCbsDetails;
            this.gvCbsDetails.Name = "gvCbsDetails";
            this.gvCbsDetails.OptionsView.ShowAutoFilterRow = true;
            this.gvCbsDetails.OptionsView.ShowFooter = true;

            this.colPackage.Caption = "حزمة العمل والموقع";
            this.colPackage.FieldName = "Package";
            this.colPackage.Visible = true;
            this.colPackage.VisibleIndex = 0;

            this.colBudget.Caption = "الموازنة المعتمدة (Budget)";
            this.colBudget.FieldName = "Budget";
            this.colBudget.Visible = true;
            this.colBudget.VisibleIndex = 1;

            this.colCommitment.Caption = "الالتزامات (Commitment)";
            this.colCommitment.FieldName = "Commitment";
            this.colCommitment.Visible = true;
            this.colCommitment.VisibleIndex = 2;

            this.colActual.Caption = "التكلفة الفعلية (Actual)";
            this.colActual.FieldName = "Actual";
            this.colActual.Visible = true;
            this.colActual.VisibleIndex = 3;

            this.colForecast.Caption = "التكلفة التقديرية لإكمال المشروع (EAC Forecast)";
            this.colForecast.FieldName = "Forecast";
            this.colForecast.Visible = true;
            this.colForecast.VisibleIndex = 4;

            this.colVariance.Caption = "الانحراف المالي (Variance)";
            this.colVariance.FieldName = "Variance";
            this.colVariance.Visible = true;
            this.colVariance.VisibleIndex = 5;

            // ucCostBreakdownStructure
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCostBreakdownStructure";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeCBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCbsDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCbsDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiAddNode;
        private DevExpress.XtraBars.BarButtonItem bbiEditNode;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraTreeList.TreeList treeCBS;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCbsNode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCostCode;
        private DevExpress.XtraGrid.GridControl grdCbsDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCbsDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colPackage;
        private DevExpress.XtraGrid.Columns.GridColumn colBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colCommitment;
        private DevExpress.XtraGrid.Columns.GridColumn colActual;
        private DevExpress.XtraGrid.Columns.GridColumn colForecast;
        private DevExpress.XtraGrid.Columns.GridColumn colVariance;
    }
}
