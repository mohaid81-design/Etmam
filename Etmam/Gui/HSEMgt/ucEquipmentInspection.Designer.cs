namespace Etmam.Gui.HSEMgt
{
    partial class ucEquipmentInspection
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
            this.bbiNewEquipInsp = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRenewCert = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdEquipment = new DevExpress.XtraGrid.GridControl();
            this.gvEquipment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEquipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCertificate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInspector = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chartEquipTrend = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEquipTrend)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewEquipInsp, this.bbiRenewCert, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewEquipInsp),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRenewCert),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات فحص واختبار معدات السلامة والآلات";

            this.bbiNewEquipInsp.Caption = "فحص معدة / كران جديد (Equip Inspection)";
            this.bbiRenewCert.Caption = "تجديد شهادة المعايرة والـ Third Party";
            this.bbiExport.Caption = "تصدير السجل الفني";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdEquipment);
            this.splitContainerControlMain.Panel1.Text = "سجل فحص آلات الرفع والمعدات الثقيلة";
            this.splitContainerControlMain.Panel2.Controls.Add(this.chartEquipTrend);
            this.splitContainerControlMain.Panel2.Text = "مخطط اتجاهات الفحص والصلاحيات (Inspection Trend)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 800;

            // grdEquipment
            this.grdEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEquipment.Location = new System.Drawing.Point(0, 0);
            this.grdEquipment.MainView = this.gvEquipment;
            this.grdEquipment.Name = "grdEquipment";
            this.grdEquipment.Size = new System.Drawing.Size(800, 720);
            this.grdEquipment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvEquipment });

            // gvEquipment
            this.gvEquipment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colEquipment, this.colType, this.colCertificate,
                this.colExpiry, this.colInspector, this.colStatus
            });
            this.gvEquipment.GridControl = this.grdEquipment;
            this.gvEquipment.Name = "gvEquipment";
            this.gvEquipment.OptionsView.ShowAutoFilterRow = true;
            this.gvEquipment.OptionsView.ShowFooter = true;

            this.colEquipment.Caption = "المعدة / الكرين / الآلية";
            this.colEquipment.FieldName = "Equipment";
            this.colEquipment.Visible = true;
            this.colEquipment.VisibleIndex = 0;

            this.colType.Caption = "نوع الآلية (TowerCrane/MobileCrane/Scaffolding)";
            this.colType.FieldName = "Type";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;

            this.colCertificate.Caption = "رقم شهادة الفحص التخصصي (Third Party Cert)";
            this.colCertificate.FieldName = "Certificate";
            this.colCertificate.Visible = true;
            this.colCertificate.VisibleIndex = 2;

            this.colExpiry.Caption = "تاريخ انتهاء الفحص الفني";
            this.colExpiry.FieldName = "Expiry";
            this.colExpiry.Visible = true;
            this.colExpiry.VisibleIndex = 3;

            this.colInspector.Caption = "جهة المفتش والمعتمد";
            this.colInspector.FieldName = "Inspector";
            this.colInspector.Visible = true;
            this.colInspector.VisibleIndex = 4;

            this.colStatus.Caption = "حالة التشغيل والأمان";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // chartEquipTrend
            this.chartEquipTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartEquipTrend.Location = new System.Drawing.Point(0, 0);
            this.chartEquipTrend.Name = "chartEquipTrend";
            this.chartEquipTrend.Size = new System.Drawing.Size(390, 720);

            // ucEquipmentInspection
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucEquipmentInspection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEquipTrend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewEquipInsp;
        private DevExpress.XtraBars.BarButtonItem bbiRenewCert;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdEquipment;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEquipment;
        private DevExpress.XtraGrid.Columns.GridColumn colEquipment;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colCertificate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiry;
        private DevExpress.XtraGrid.Columns.GridColumn colInspector;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraCharts.ChartControl chartEquipTrend;
    }
}
