namespace Etmam.Gui.QualityMgt
{
    partial class ucSnagList
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
            this.bbiNewSnag = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseSnag = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdSnags = new DevExpress.XtraGrid.GridControl();
            this.gvSnags = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSnagNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chartSnags = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSnags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSnags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSnags)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewSnag, this.bbiCloseSnag, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewSnag),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCloseSnag),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل الملاحظات العاجلة (Snag List)";

            this.bbiNewSnag.Caption = "تسجيل ملاحظة عاجلة (New Snag)";
            this.bbiCloseSnag.Caption = "إغلاق المعالجة";
            this.bbiExport.Caption = "تصدير القائمة";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdSnags);
            this.splitContainerControlMain.Panel1.Text = "جدول الملاحظات العاجلة للوحدات";
            this.splitContainerControlMain.Panel2.Controls.Add(this.chartSnags);
            this.splitContainerControlMain.Panel2.Text = "مخطط الحالات المغلقة والمفتوحة (Open / Closed)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 800;

            // grdSnags
            this.grdSnags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSnags.Location = new System.Drawing.Point(0, 0);
            this.grdSnags.MainView = this.gvSnags;
            this.grdSnags.Name = "grdSnags";
            this.grdSnags.Size = new System.Drawing.Size(800, 720);
            this.grdSnags.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvSnags });

            // gvSnags
            this.gvSnags.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colSnagNo, this.colUnit, this.colArea,
                this.colDescription, this.colSeverity, this.colStatus
            });
            this.gvSnags.GridControl = this.grdSnags;
            this.gvSnags.Name = "gvSnags";
            this.gvSnags.OptionsView.ShowAutoFilterRow = true;
            this.gvSnags.OptionsView.ShowFooter = true;

            this.colSnagNo.Caption = "رقم الملاحظة (Snag No)";
            this.colSnagNo.FieldName = "SnagNo";
            this.colSnagNo.Visible = true;
            this.colSnagNo.VisibleIndex = 0;

            this.colUnit.Caption = "رقم الشقة / الوحدة / الفيلّا";
            this.colUnit.FieldName = "Unit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 1;

            this.colArea.Caption = "المكان / الغرفة / الممر";
            this.colArea.FieldName = "Area";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 2;

            this.colDescription.Caption = "وصف الملاحظة العاجلة";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;

            this.colSeverity.Caption = "درجة الأهمية (Severity)";
            this.colSeverity.FieldName = "Severity";
            this.colSeverity.Visible = true;
            this.colSeverity.VisibleIndex = 4;

            this.colStatus.Caption = "حالة المعالجة والإغلاق";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // chartSnags
            this.chartSnags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSnags.Location = new System.Drawing.Point(0, 0);
            this.chartSnags.Name = "chartSnags";
            this.chartSnags.Size = new System.Drawing.Size(390, 720);

            // ucSnagList
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucSnagList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSnags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSnags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSnags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewSnag;
        private DevExpress.XtraBars.BarButtonItem bbiCloseSnag;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdSnags;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSnags;
        private DevExpress.XtraGrid.Columns.GridColumn colSnagNo;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraCharts.ChartControl chartSnags;
    }
}
