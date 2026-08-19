namespace Etmam.Gui.HSEMgt
{
    partial class ucHazardRegister
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
            this.bbiNewHazard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseHazard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblHigh = new DevExpress.XtraEditors.LabelControl();
            this.lblMedium = new DevExpress.XtraEditors.LabelControl();
            this.lblLow = new DevExpress.XtraEditors.LabelControl();
            this.grdHazards = new DevExpress.XtraGrid.GridControl();
            this.gvHazards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHazardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiskLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colControlMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHazards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHazards)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewHazard, this.bbiCloseHazard, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewHazard),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCloseHazard),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل المخاطر والمكاره Hazard Register";

            this.bbiNewHazard.Caption = "تسجيل خطر جديد (New Hazard)";
            this.bbiCloseHazard.Caption = "تأكيد إحكام الإجراء الوقائي";
            this.bbiExport.Caption = "تصدير إلى Excel/PDF";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblHigh);
            this.pnlCards.Controls.Add(this.lblMedium);
            this.pnlCards.Controls.Add(this.lblLow);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblHigh.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHigh.Location = new System.Drawing.Point(950, 15);
            this.lblHigh.Text = "مخاطر عالية (High Risk): 4";

            this.lblMedium.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMedium.Location = new System.Drawing.Point(650, 15);
            this.lblMedium.Text = "مخاطر متوسطة (Medium Risk): 12";

            this.lblLow.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLow.Location = new System.Drawing.Point(320, 15);
            this.lblLow.Text = "مخاطر منخفضة (Low Risk): 25";

            // grdHazards
            this.grdHazards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHazards.Location = new System.Drawing.Point(0, 80);
            this.grdHazards.MainView = this.gvHazards;
            this.grdHazards.Name = "grdHazards";
            this.grdHazards.Size = new System.Drawing.Size(1200, 670);
            this.grdHazards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvHazards });

            // gvHazards
            this.gvHazards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colHazardNo, this.colDescription, this.colLocation,
                this.colRiskLevel, this.colControlMeasure, this.colOwner, this.colStatus
            });
            this.gvHazards.GridControl = this.grdHazards;
            this.gvHazards.Name = "gvHazards";
            this.gvHazards.OptionsView.ShowAutoFilterRow = true;
            this.gvHazards.OptionsView.ShowFooter = true;

            this.colHazardNo.Caption = "رقم الخطر (Hazard No)";
            this.colHazardNo.FieldName = "HazardNo";
            this.colHazardNo.Visible = true;
            this.colHazardNo.VisibleIndex = 0;

            this.colDescription.Caption = "وصف مصدر الخطر والتهديد";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;

            this.colLocation.Caption = "موقع الخطر الميداني";
            this.colLocation.FieldName = "Location";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 2;

            this.colRiskLevel.Caption = "درجة الخطورة المحسوبة";
            this.colRiskLevel.FieldName = "RiskLevel";
            this.colRiskLevel.Visible = true;
            this.colRiskLevel.VisibleIndex = 3;

            this.colControlMeasure.Caption = "وسيلة التحكم والوقاية (Control Measure)";
            this.colControlMeasure.FieldName = "ControlMeasure";
            this.colControlMeasure.Visible = true;
            this.colControlMeasure.VisibleIndex = 4;

            this.colOwner.Caption = "المسؤول عن التنفيذ (Owner)";
            this.colOwner.FieldName = "Owner";
            this.colOwner.Visible = true;
            this.colOwner.VisibleIndex = 5;

            this.colStatus.Caption = "حالة التحكم والتحييد";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;

            // ucHazardRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdHazards);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucHazardRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHazards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHazards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewHazard;
        private DevExpress.XtraBars.BarButtonItem bbiCloseHazard;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblHigh;
        private DevExpress.XtraEditors.LabelControl lblMedium;
        private DevExpress.XtraEditors.LabelControl lblLow;
        private DevExpress.XtraGrid.GridControl grdHazards;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHazards;
        private DevExpress.XtraGrid.Columns.GridColumn colHazardNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colRiskLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colControlMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
