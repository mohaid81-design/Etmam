namespace Etmam.Gui.HSEMgt
{
    partial class ucNearMissRegister
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
            this.bbiNewNearMiss = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseNearMiss = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblOpen = new DevExpress.XtraEditors.LabelControl();
            this.lblClosed = new DevExpress.XtraEditors.LabelControl();
            this.lblHighRisk = new DevExpress.XtraEditors.LabelControl();
            this.grdNearMiss = new DevExpress.XtraGrid.GridControl();
            this.gvNearMiss = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNearMissNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReporter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiskLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNearMiss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNearMiss)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewNearMiss, this.bbiCloseNearMiss, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewNearMiss),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCloseNearMiss),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل الحوادث الوشيكة (Near Miss)";

            this.bbiNewNearMiss.Caption = "تسجيل حادث وشيك (New Near Miss)";
            this.bbiCloseNearMiss.Caption = "إغلاق ومعالجة البلاغ";
            this.bbiExport.Caption = "تصدير إلى Excel/PDF";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblOpen);
            this.pnlCards.Controls.Add(this.lblClosed);
            this.pnlCards.Controls.Add(this.lblHighRisk);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblOpen.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOpen.Location = new System.Drawing.Point(950, 15);
            this.lblOpen.Text = "حوادث وشيكة قيد المعالجة: 4";

            this.lblClosed.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClosed.Location = new System.Drawing.Point(650, 15);
            this.lblClosed.Text = "حوادث وشيكة مغلقة: 48";

            this.lblHighRisk.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHighRisk.Location = new System.Drawing.Point(320, 15);
            this.lblHighRisk.Text = "خطورة محتملة عالية: 2";

            // grdNearMiss
            this.grdNearMiss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNearMiss.Location = new System.Drawing.Point(0, 80);
            this.grdNearMiss.MainView = this.gvNearMiss;
            this.grdNearMiss.Name = "grdNearMiss";
            this.grdNearMiss.Size = new System.Drawing.Size(1200, 670);
            this.grdNearMiss.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvNearMiss });

            // gvNearMiss
            this.gvNearMiss.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colNearMissNo, this.colArea, this.colDescription,
                this.colReporter, this.colRiskLevel, this.colStatus
            });
            this.gvNearMiss.GridControl = this.grdNearMiss;
            this.gvNearMiss.Name = "gvNearMiss";
            this.gvNearMiss.OptionsView.ShowAutoFilterRow = true;
            this.gvNearMiss.OptionsView.ShowFooter = true;

            this.colNearMissNo.Caption = "رقم البلاغ (Near Miss No)";
            this.colNearMissNo.FieldName = "NearMissNo";
            this.colNearMissNo.Visible = true;
            this.colNearMissNo.VisibleIndex = 0;

            this.colArea.Caption = "الموقع والمنطقة بالموقع الإنشائي";
            this.colArea.FieldName = "Area";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 1;

            this.colDescription.Caption = "وصف الحدث الوشيك وخطر الوقوع";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;

            this.colReporter.Caption = "المبلغ / منسق السلامة";
            this.colReporter.FieldName = "Reporter";
            this.colReporter.Visible = true;
            this.colReporter.VisibleIndex = 3;

            this.colRiskLevel.Caption = "مستوى الخطورة (High/Med/Low)";
            this.colRiskLevel.FieldName = "RiskLevel";
            this.colRiskLevel.Visible = true;
            this.colRiskLevel.VisibleIndex = 4;

            this.colStatus.Caption = "حالة البلاغ والإجراء المتخذ";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // ucNearMissRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdNearMiss);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucNearMissRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNearMiss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNearMiss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewNearMiss;
        private DevExpress.XtraBars.BarButtonItem bbiCloseNearMiss;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblOpen;
        private DevExpress.XtraEditors.LabelControl lblClosed;
        private DevExpress.XtraEditors.LabelControl lblHighRisk;
        private DevExpress.XtraGrid.GridControl grdNearMiss;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNearMiss;
        private DevExpress.XtraGrid.Columns.GridColumn colNearMissNo;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colReporter;
        private DevExpress.XtraGrid.Columns.GridColumn colRiskLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
