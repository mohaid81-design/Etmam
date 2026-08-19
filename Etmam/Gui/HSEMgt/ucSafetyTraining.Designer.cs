namespace Etmam.Gui.HSEMgt
{
    partial class ucSafetyTraining
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
            this.bbiNewTraining = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRenewCert = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblCompleted = new DevExpress.XtraEditors.LabelControl();
            this.lblExpired = new DevExpress.XtraEditors.LabelControl();
            this.lblUpcoming = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdTraining = new DevExpress.XtraGrid.GridControl();
            this.gvTraining = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCourse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvider = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pdfViewerCert = new DevExpress.XtraPdfViewer.PdfViewer();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTraining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTraining)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewTraining, this.bbiRenewCert, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewTraining),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRenewCert),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل دورات وتراخيص السلامة";

            this.bbiNewTraining.Caption = "تسجيل دورة تدريبية جديدة";
            this.bbiRenewCert.Caption = "تجديد الرخصة / الشهادة";
            this.bbiExport.Caption = "تصدير السجل التدريبي";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblCompleted);
            this.pnlCards.Controls.Add(this.lblExpired);
            this.pnlCards.Controls.Add(this.lblUpcoming);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblCompleted.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCompleted.Location = new System.Drawing.Point(950, 15);
            this.lblCompleted.Text = "دورات وحصلوا على الشهادة: 140";

            this.lblExpired.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpired.Location = new System.Drawing.Point(650, 15);
            this.lblExpired.Text = "شهادات وتراخيص منتهية: 5";

            this.lblUpcoming.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUpcoming.Location = new System.Drawing.Point(320, 15);
            this.lblUpcoming.Text = "دورات قادمة هذا الشهر: 3";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdTraining);
            this.splitContainerControlMain.Panel1.Text = "جدول سجل تدريب وتراخيص العاملين";
            this.splitContainerControlMain.Panel2.Controls.Add(this.pdfViewerCert);
            this.splitContainerControlMain.Panel2.Text = "معاينة شهادة السلامة والترخيص (Certificates Preview)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 750;

            // grdTraining
            this.grdTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTraining.Location = new System.Drawing.Point(0, 0);
            this.grdTraining.MainView = this.gvTraining;
            this.grdTraining.Name = "grdTraining";
            this.grdTraining.Size = new System.Drawing.Size(750, 670);
            this.grdTraining.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvTraining });

            // gvTraining
            this.gvTraining.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colEmployee, this.colCourse, this.colExpiry,
                this.colProvider, this.colStatus
            });
            this.gvTraining.GridControl = this.grdTraining;
            this.gvTraining.Name = "gvTraining";
            this.gvTraining.OptionsView.ShowAutoFilterRow = true;
            this.gvTraining.OptionsView.ShowFooter = true;

            this.colEmployee.Caption = "الموظف / العامل المنفذ";
            this.colEmployee.FieldName = "Employee";
            this.colEmployee.Visible = true;
            this.colEmployee.VisibleIndex = 0;

            this.colCourse.Caption = "اسم وتصنيف دورة السلامة";
            this.colCourse.FieldName = "Course";
            this.colCourse.Visible = true;
            this.colCourse.VisibleIndex = 1;

            this.colExpiry.Caption = "تاريخ انتهاء صلاحية الترخيص";
            this.colExpiry.FieldName = "Expiry";
            this.colExpiry.Visible = true;
            this.colExpiry.VisibleIndex = 2;

            this.colProvider.Caption = "الجهة والمركز المانح (OSHA/NEBOSH)";
            this.colProvider.FieldName = "Provider";
            this.colProvider.Visible = true;
            this.colProvider.VisibleIndex = 3;

            this.colStatus.Caption = "حالة الترخيص والشهادة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            // pdfViewerCert
            this.pdfViewerCert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewerCert.Location = new System.Drawing.Point(0, 0);
            this.pdfViewerCert.Name = "pdfViewerCert";
            this.pdfViewerCert.Size = new System.Drawing.Size(440, 670);

            // ucSafetyTraining
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucSafetyTraining";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTraining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTraining)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewTraining;
        private DevExpress.XtraBars.BarButtonItem bbiRenewCert;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblCompleted;
        private DevExpress.XtraEditors.LabelControl lblExpired;
        private DevExpress.XtraEditors.LabelControl lblUpcoming;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdTraining;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTraining;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colCourse;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiry;
        private DevExpress.XtraGrid.Columns.GridColumn colProvider;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewerCert;
    }
}
