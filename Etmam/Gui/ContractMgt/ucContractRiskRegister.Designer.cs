namespace Etmam.Gui.ContractMgt
{
    partial class ucContractRiskRegister
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
            this.bbiNewRisk = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditRisk = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            this.lblHighRisk = new DevExpress.XtraEditors.LabelControl();
            this.lblMediumRisk = new DevExpress.XtraEditors.LabelControl();
            this.lblLowRisk = new DevExpress.XtraEditors.LabelControl();
            this.grdRisks = new DevExpress.XtraGrid.GridControl();
            this.gvRisks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRiskID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProbability = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitigation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).BeginInit();
            this.pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRisks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRisks)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewRisk, this.bbiEditRisk, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewRisk),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditRisk),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات سجل المخاطر";

            this.bbiNewRisk.Caption = "تسجيل خطر جديد";
            this.bbiEditRisk.Caption = "تعديل تقييم الخطر";
            this.bbiPrint.Caption = "طباعة سجل المخاطر";

            // pnlKpiCards
            this.pnlKpiCards.Controls.Add(this.lblHighRisk);
            this.pnlKpiCards.Controls.Add(this.lblMediumRisk);
            this.pnlKpiCards.Controls.Add(this.lblLowRisk);
            this.pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiCards.Location = new System.Drawing.Point(0, 30);
            this.pnlKpiCards.Name = "pnlKpiCards";
            this.pnlKpiCards.Size = new System.Drawing.Size(1200, 50);

            this.lblHighRisk.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHighRisk.Location = new System.Drawing.Point(1000, 15);
            this.lblHighRisk.Text = "مخاطر عالية الخطورة (High): 3";

            this.lblMediumRisk.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMediumRisk.Location = new System.Drawing.Point(680, 15);
            this.lblMediumRisk.Text = "مخاطر متوسطة (Medium): 7";

            this.lblLowRisk.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLowRisk.Location = new System.Drawing.Point(380, 15);
            this.lblLowRisk.Text = "مخاطر منخفضة (Low): 12";

            // grdRisks
            this.grdRisks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRisks.Location = new System.Drawing.Point(0, 80);
            this.grdRisks.MainView = this.gvRisks;
            this.grdRisks.Name = "grdRisks";
            this.grdRisks.Size = new System.Drawing.Size(1200, 670);
            this.grdRisks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvRisks });

            // gvRisks
            this.gvRisks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colRiskID, this.colDescription, this.colProbability,
                this.colImpact, this.colOwner, this.colMitigation, this.colStatus
            });
            this.gvRisks.GridControl = this.grdRisks;
            this.gvRisks.Name = "gvRisks";

            this.colRiskID.Caption = "رمز الخطر";
            this.colRiskID.FieldName = "RiskID";
            this.colRiskID.Visible = true;
            this.colRiskID.VisibleIndex = 0;

            this.colDescription.Caption = "وصف الخطر والتأثير التعاقدي المتوقع";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;

            this.colProbability.Caption = "احتمالية الحدوث";
            this.colProbability.FieldName = "Probability";
            this.colProbability.Visible = true;
            this.colProbability.VisibleIndex = 2;

            this.colImpact.Caption = "مستوى الأثر (مالي/زمني)";
            this.colImpact.FieldName = "Impact";
            this.colImpact.Visible = true;
            this.colImpact.VisibleIndex = 3;

            this.colOwner.Caption = "مالك الخطر والمسؤول";
            this.colOwner.FieldName = "Owner";
            this.colOwner.Visible = true;
            this.colOwner.VisibleIndex = 4;

            this.colMitigation.Caption = "إستراتيجية التخفيف والوقاية (Mitigation Plan)";
            this.colMitigation.FieldName = "Mitigation";
            this.colMitigation.Visible = true;
            this.colMitigation.VisibleIndex = 5;

            this.colStatus.Caption = "حالة الخطر";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;

            // ucContractRiskRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdRisks);
            this.Controls.Add(this.pnlKpiCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucContractRiskRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).EndInit();
            this.pnlKpiCards.ResumeLayout(false);
            this.pnlKpiCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRisks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRisks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewRisk;
        private DevExpress.XtraBars.BarButtonItem bbiEditRisk;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.LabelControl lblHighRisk;
        private DevExpress.XtraEditors.LabelControl lblMediumRisk;
        private DevExpress.XtraEditors.LabelControl lblLowRisk;
        private DevExpress.XtraGrid.GridControl grdRisks;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRisks;
        private DevExpress.XtraGrid.Columns.GridColumn colRiskID;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colProbability;
        private DevExpress.XtraGrid.Columns.GridColumn colImpact;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colMitigation;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
