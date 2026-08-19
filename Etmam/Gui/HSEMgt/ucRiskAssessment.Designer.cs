namespace Etmam.Gui.HSEMgt
{
    partial class ucRiskAssessment
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
            this.bbiNewJsa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditJsa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeJSA = new DevExpress.XtraTreeList.TreeList();
            this.colNodeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainerRight = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdJSA = new DevExpress.XtraGrid.GridControl();
            this.gvJSA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHazard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProbability = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiskScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResidualRisk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colControl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlRiskMatrix5x5 = new DevExpress.XtraEditors.PanelControl();
            this.lblMatrixTitle = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeJSA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJSA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJSA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRiskMatrix5x5)).BeginInit();
            this.pnlRiskMatrix5x5.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewJsa, this.bbiEditJsa, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewJsa),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditJsa),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات تقييم وتصنيف المخاطر JSA/JHA";

            this.bbiNewJsa.Caption = "نموذج JSA جديد (Job Safety Analysis)";
            this.bbiEditJsa.Caption = "تعديل تقييم المخاطر";
            this.bbiExport.Caption = "تصدير السجل الكامل";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.treeJSA);
            this.splitContainerControlMain.Panel1.Text = "هيكل السلامة للأنشطة (Activity/Hazards/Controls)";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerRight);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل JSA ومصفوفة المخاطر 5x5 Matrix";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 280;

            // treeJSA
            this.treeJSA.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { this.colNodeName });
            this.treeJSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeJSA.Location = new System.Drawing.Point(0, 0);
            this.treeJSA.Name = "treeJSA";
            this.treeJSA.Size = new System.Drawing.Size(280, 720);

            this.colNodeName.Caption = "أنشطة ومخاطر مشروع البناء";
            this.colNodeName.FieldName = "NodeName";
            this.colNodeName.Visible = true;
            this.colNodeName.VisibleIndex = 0;

            // splitContainerRight
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.Horizontal = false;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Panel1.Controls.Add(this.grdJSA);
            this.splitContainerRight.Panel1.Text = "جدول تحليل وتقييم المخاطر JSA Grid";
            this.splitContainerRight.Panel2.Controls.Add(this.pnlRiskMatrix5x5);
            this.splitContainerRight.Panel2.Text = "مصفوفة تقييم المخاطر 5x5 Risk Matrix Panel";
            this.splitContainerRight.Size = new System.Drawing.Size(910, 720);
            this.splitContainerRight.SplitterPosition = 450;

            // grdJSA
            this.grdJSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJSA.Location = new System.Drawing.Point(0, 0);
            this.grdJSA.MainView = this.gvJSA;
            this.grdJSA.Name = "grdJSA";
            this.grdJSA.Size = new System.Drawing.Size(910, 450);
            this.grdJSA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvJSA });

            // gvJSA
            this.gvJSA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colHazard, this.colProbability, this.colSeverity,
                this.colRiskScore, this.colResidualRisk, this.colControl
            });
            this.gvJSA.GridControl = this.grdJSA;
            this.gvJSA.Name = "gvJSA";
            this.gvJSA.OptionsView.ShowAutoFilterRow = true;
            this.gvJSA.OptionsView.ShowFooter = true;

            this.colHazard.Caption = "الخطر / تهديد السلامة المحتمل";
            this.colHazard.FieldName = "Hazard";
            this.colHazard.Visible = true;
            this.colHazard.VisibleIndex = 0;

            this.colProbability.Caption = "احتمالية الوقوع (Probability 1-5)";
            this.colProbability.FieldName = "Probability";
            this.colProbability.Visible = true;
            this.colProbability.VisibleIndex = 1;

            this.colSeverity.Caption = "شدة الأثر (Severity 1-5)";
            this.colSeverity.FieldName = "Severity";
            this.colSeverity.Visible = true;
            this.colSeverity.VisibleIndex = 2;

            this.colRiskScore.Caption = "درجة الخطر الأولية (Initial Score)";
            this.colRiskScore.FieldName = "RiskScore";
            this.colRiskScore.Visible = true;
            this.colRiskScore.VisibleIndex = 3;

            this.colResidualRisk.Caption = "الخطر المتبقي (Residual Risk)";
            this.colResidualRisk.FieldName = "ResidualRisk";
            this.colResidualRisk.Visible = true;
            this.colResidualRisk.VisibleIndex = 4;

            this.colControl.Caption = "وسائل الضبط الهندسية والوقائية (Controls)";
            this.colControl.FieldName = "Control";
            this.colControl.Visible = true;
            this.colControl.VisibleIndex = 5;

            // pnlRiskMatrix5x5
            this.pnlRiskMatrix5x5.Controls.Add(this.lblMatrixTitle);
            this.pnlRiskMatrix5x5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRiskMatrix5x5.Location = new System.Drawing.Point(0, 0);
            this.pnlRiskMatrix5x5.Name = "pnlRiskMatrix5x5";
            this.pnlRiskMatrix5x5.Size = new System.Drawing.Size(910, 260);

            this.lblMatrixTitle.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMatrixTitle.Location = new System.Drawing.Point(10, 10);
            this.lblMatrixTitle.Text = "مصفوفة قياس المخاطر المعيارية (5x5 Risk Matrix Representation)";

            // ucRiskAssessment
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucRiskAssessment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeJSA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJSA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJSA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRiskMatrix5x5)).EndInit();
            this.pnlRiskMatrix5x5.ResumeLayout(false);
            this.pnlRiskMatrix5x5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewJsa;
        private DevExpress.XtraBars.BarButtonItem bbiEditJsa;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraTreeList.TreeList treeJSA;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNodeName;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerRight;
        private DevExpress.XtraGrid.GridControl grdJSA;
        private DevExpress.XtraGrid.Views.Grid.GridView gvJSA;
        private DevExpress.XtraGrid.Columns.GridColumn colHazard;
        private DevExpress.XtraGrid.Columns.GridColumn colProbability;
        private DevExpress.XtraGrid.Columns.GridColumn colSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colRiskScore;
        private DevExpress.XtraGrid.Columns.GridColumn colResidualRisk;
        private DevExpress.XtraGrid.Columns.GridColumn colControl;
        private DevExpress.XtraEditors.PanelControl pnlRiskMatrix5x5;
        private DevExpress.XtraEditors.LabelControl lblMatrixTitle;
    }
}
