namespace Etmam.Gui.QualityMgt
{
    partial class ucDefectLiability
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
            this.bbiNewDefect = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseDefect = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblOpen = new DevExpress.XtraEditors.LabelControl();
            this.lblClosed = new DevExpress.XtraEditors.LabelControl();
            this.lblExpired = new DevExpress.XtraEditors.LabelControl();
            this.grdDefects = new DevExpress.XtraGrid.GridControl();
            this.gvDefects = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDefect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReported = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDefects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDefects)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewDefect, this.bbiCloseDefect, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewDefect),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCloseDefect),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات سجل الضمان وفترة الصيانة";

            this.bbiNewDefect.Caption = "تسجيل عيب / بلاغ صيانة جديد";
            this.bbiCloseDefect.Caption = "إغلاق ومعالجة البلاغ";
            this.bbiPrint.Caption = "طباعة سجل الضمان";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblOpen);
            this.pnlCards.Controls.Add(this.lblClosed);
            this.pnlCards.Controls.Add(this.lblExpired);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblOpen.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOpen.Location = new System.Drawing.Point(950, 15);
            this.lblOpen.Text = "بلاغات مفتوحة: 4";

            this.lblClosed.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClosed.Location = new System.Drawing.Point(650, 15);
            this.lblClosed.Text = "بلاغات معالجة ومغلقة: 28";

            this.lblExpired.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpired.Location = new System.Drawing.Point(320, 15);
            this.lblExpired.Text = "ضمانات منتهية: 2 مشاريع";

            // grdDefects
            this.grdDefects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDefects.Location = new System.Drawing.Point(0, 80);
            this.grdDefects.MainView = this.gvDefects;
            this.grdDefects.Name = "grdDefects";
            this.grdDefects.Size = new System.Drawing.Size(1200, 670);
            this.grdDefects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvDefects });

            // gvDefects
            this.gvDefects.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colDefect, this.colReported, this.colContractor,
                this.colDueDate, this.colStatus
            });
            this.gvDefects.GridControl = this.grdDefects;
            this.gvDefects.Name = "gvDefects";
            this.gvDefects.OptionsView.ShowAutoFilterRow = true;
            this.gvDefects.OptionsView.ShowFooter = true;

            this.colDefect.Caption = "العيب المصنعي / البلاغ (Defect)";
            this.colDefect.FieldName = "Defect";
            this.colDefect.Visible = true;
            this.colDefect.VisibleIndex = 0;

            this.colReported.Caption = "تاريخ الإبلاغ والاستلام";
            this.colReported.FieldName = "Reported";
            this.colReported.Visible = true;
            this.colReported.VisibleIndex = 1;

            this.colContractor.Caption = "المقاول الضامن / المسؤول";
            this.colContractor.FieldName = "Contractor";
            this.colContractor.Visible = true;
            this.colContractor.VisibleIndex = 2;

            this.colDueDate.Caption = "آخر موعد للإصلاح الضماني";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 3;

            this.colStatus.Caption = "حالة البلاغ والضمان";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            // ucDefectLiability
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdDefects);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucDefectLiability";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDefects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDefects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewDefect;
        private DevExpress.XtraBars.BarButtonItem bbiCloseDefect;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblOpen;
        private DevExpress.XtraEditors.LabelControl lblClosed;
        private DevExpress.XtraEditors.LabelControl lblExpired;
        private DevExpress.XtraGrid.GridControl grdDefects;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDefects;
        private DevExpress.XtraGrid.Columns.GridColumn colDefect;
        private DevExpress.XtraGrid.Columns.GridColumn colReported;
        private DevExpress.XtraGrid.Columns.GridColumn colContractor;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
