namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucCircularManagement
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
            this.bbiNewCircular = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditCircular = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblActiveCirculars = new DevExpress.XtraEditors.LabelControl();
            this.lblExpiredCirculars = new DevExpress.XtraEditors.LabelControl();
            this.lblPendingApprovalCirculars = new DevExpress.XtraEditors.LabelControl();
            this.grdCirculars = new DevExpress.XtraGrid.GridControl();
            this.gvCirculars = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCircularNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCirculars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCirculars)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewCircular, this.bbiEditCircular, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewCircular),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditCircular),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات التعاميم والنشرات الإدارية";

            this.bbiNewCircular.Caption = "إصدار تعميم إداري جديد";
            this.bbiEditCircular.Caption = "تعديل التعميم";
            this.bbiPrint.Caption = "طباعة التعميم";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblActiveCirculars);
            this.pnlCards.Controls.Add(this.lblExpiredCirculars);
            this.pnlCards.Controls.Add(this.lblPendingApprovalCirculars);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblActiveCirculars.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblActiveCirculars.Location = new System.Drawing.Point(950, 15);
            this.lblActiveCirculars.Text = "تعاميم سارية المفعول: 5";

            this.lblExpiredCirculars.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpiredCirculars.Location = new System.Drawing.Point(650, 15);
            this.lblExpiredCirculars.Text = "تعاميم منتهية: 18";

            this.lblPendingApprovalCirculars.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPendingApprovalCirculars.Location = new System.Drawing.Point(320, 15);
            this.lblPendingApprovalCirculars.Text = "تعاميم تنتظر الاعتماد: 2";

            // grdCirculars
            this.grdCirculars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCirculars.Location = new System.Drawing.Point(0, 80);
            this.grdCirculars.MainView = this.gvCirculars;
            this.grdCirculars.Name = "grdCirculars";
            this.grdCirculars.Size = new System.Drawing.Size(1200, 670);
            this.grdCirculars.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvCirculars });

            // gvCirculars
            this.gvCirculars.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCircularNo, this.colSubject, this.colEffectiveDate,
                this.colExpiryDate, this.colDepartment, this.colStatus
            });
            this.gvCirculars.GridControl = this.grdCirculars;
            this.gvCirculars.Name = "gvCirculars";
            this.gvCirculars.OptionsView.ShowAutoFilterRow = true;
            this.gvCirculars.OptionsView.ShowFooter = true;

            this.colCircularNo.Caption = "رقم التعميم (Circular No)";
            this.colCircularNo.FieldName = "CircularNo";
            this.colCircularNo.Visible = true;
            this.colCircularNo.VisibleIndex = 0;

            this.colSubject.Caption = "عنوان وموضوع التعميم الإداري";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;

            this.colEffectiveDate.Caption = "تاريخ السريان والنفاذ";
            this.colEffectiveDate.FieldName = "EffectiveDate";
            this.colEffectiveDate.Visible = true;
            this.colEffectiveDate.VisibleIndex = 2;

            this.colExpiryDate.Caption = "تاريخ الانتهاء";
            this.colExpiryDate.FieldName = "ExpiryDate";
            this.colExpiryDate.Visible = true;
            this.colExpiryDate.VisibleIndex = 3;

            this.colDepartment.Caption = "الإدارة المعنية والنطاق";
            this.colDepartment.FieldName = "Department";
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 4;

            this.colStatus.Caption = "حالة التعميم";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // ucCircularManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdCirculars);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCircularManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCirculars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCirculars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewCircular;
        private DevExpress.XtraBars.BarButtonItem bbiEditCircular;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblActiveCirculars;
        private DevExpress.XtraEditors.LabelControl lblExpiredCirculars;
        private DevExpress.XtraEditors.LabelControl lblPendingApprovalCirculars;
        private DevExpress.XtraGrid.GridControl grdCirculars;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCirculars;
        private DevExpress.XtraGrid.Columns.GridColumn colCircularNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
