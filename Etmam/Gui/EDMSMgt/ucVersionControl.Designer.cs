namespace Etmam.Gui.EDMSMgt
{
    partial class ucVersionControl
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
            this.bbiCompareRevisions = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRollbackRevision = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDownloadRevision = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdRevisions = new DevExpress.XtraGrid.GridControl();
            this.gvRevisions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlComparison = new DevExpress.XtraEditors.PanelControl();
            this.lblComparisonHeader = new DevExpress.XtraEditors.LabelControl();
            this.lblPreviousRevisionInfo = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrentRevisionInfo = new DevExpress.XtraEditors.LabelControl();
            this.lblDifferenceSummary = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRevisions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRevisions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlComparison)).BeginInit();
            this.pnlComparison.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiCompareRevisions, this.bbiRollbackRevision, this.bbiDownloadRevision
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCompareRevisions),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRollbackRevision),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiDownloadRevision)
            });
            this.barMain.Text = "أدوات إدارة الإصدارات";

            this.bbiCompareRevisions.Caption = "مقارنة إصدارين (Compare)";
            this.bbiRollbackRevision.Caption = "استرجاع إصدار سابق (Rollback)";
            this.bbiDownloadRevision.Caption = "تحميل ملف الإصدار الماثل";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdRevisions);
            this.splitContainerControlMain.Panel1.Text = "جدول الإصدارات التتابعي";
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlComparison);
            this.splitContainerControlMain.Panel2.Text = "لوحة الفروقات والمقارنة المباشرة";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 420;

            // grdRevisions
            this.grdRevisions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRevisions.Location = new System.Drawing.Point(0, 0);
            this.grdRevisions.MainView = this.gvRevisions;
            this.grdRevisions.Name = "grdRevisions";
            this.grdRevisions.Size = new System.Drawing.Size(1200, 420);
            this.grdRevisions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvRevisions });

            // gvRevisions
            this.gvRevisions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colRevision, this.colDescription, this.colCreatedBy,
                this.colDate, this.colStatus
            });
            this.gvRevisions.GridControl = this.grdRevisions;
            this.gvRevisions.Name = "gvRevisions";
            this.gvRevisions.OptionsView.ShowAutoFilterRow = true;
            this.gvRevisions.OptionsView.ShowFooter = true;

            this.colRevision.Caption = "رمز الإصدار (Revision)";
            this.colRevision.FieldName = "Revision";
            this.colRevision.Visible = true;
            this.colRevision.VisibleIndex = 0;

            this.colDescription.Caption = "سبب التعديل والتغيرات الجوهرية";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;

            this.colCreatedBy.Caption = "المُنشئ / المهندس المعني";
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 2;

            this.colDate.Caption = "تاريخ ووقت التعديل";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 3;

            this.colStatus.Caption = "حالة الإصدار الحالية";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            // pnlComparison
            this.pnlComparison.Controls.Add(this.lblComparisonHeader);
            this.pnlComparison.Controls.Add(this.lblPreviousRevisionInfo);
            this.pnlComparison.Controls.Add(this.lblCurrentRevisionInfo);
            this.pnlComparison.Controls.Add(this.lblDifferenceSummary);
            this.pnlComparison.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComparison.Location = new System.Drawing.Point(0, 0);
            this.pnlComparison.Name = "pnlComparison";
            this.pnlComparison.Size = new System.Drawing.Size(1200, 290);

            this.lblComparisonHeader.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblComparisonHeader.Location = new System.Drawing.Point(900, 15);
            this.lblComparisonHeader.Text = "لوحة تحليل الفروقات وتتبع الإضافات (Comparison Panel)";

            this.lblPreviousRevisionInfo.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.lblPreviousRevisionInfo.Location = new System.Drawing.Point(900, 50);
            this.lblPreviousRevisionInfo.Text = "الإصدار السابق: Rev-02 | الحجم: 4.2 MB | الحالات الإنشائية: 120 عنصر | تاريخ الاعتماد: 2026-07-15";

            this.lblCurrentRevisionInfo.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.lblCurrentRevisionInfo.Location = new System.Drawing.Point(900, 85);
            this.lblCurrentRevisionInfo.Text = "الإصدار الحالي: Rev-03 | الحجم: 4.8 MB | الحالات الإنشائية: 128 عنصر | تاريخ الاعتماد: 2026-08-01";

            this.lblDifferenceSummary.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDifferenceSummary.Location = new System.Drawing.Point(900, 125);
            this.lblDifferenceSummary.Text = "ملخص الفروقات (Difference Summary): تم تعديل أبعاد أساسات المحور B4 وإضافة 8 قطاعات إضافية للحديد المسلح ورفع المواصفة الهيدروليكية.";

            // ucVersionControl
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucVersionControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRevisions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRevisions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlComparison)).EndInit();
            this.pnlComparison.ResumeLayout(false);
            this.pnlComparison.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiCompareRevisions;
        private DevExpress.XtraBars.BarButtonItem bbiRollbackRevision;
        private DevExpress.XtraBars.BarButtonItem bbiDownloadRevision;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdRevisions;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRevisions;
        private DevExpress.XtraGrid.Columns.GridColumn colRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.PanelControl pnlComparison;
        private DevExpress.XtraEditors.LabelControl lblComparisonHeader;
        private DevExpress.XtraEditors.LabelControl lblPreviousRevisionInfo;
        private DevExpress.XtraEditors.LabelControl lblCurrentRevisionInfo;
        private DevExpress.XtraEditors.LabelControl lblDifferenceSummary;
    }
}
