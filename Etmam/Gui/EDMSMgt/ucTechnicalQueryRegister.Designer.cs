namespace Etmam.Gui.EDMSMgt
{
    partial class ucTechnicalQueryRegister
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
            this.bbiNewTQ = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditTQ = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdTQ = new DevExpress.XtraGrid.GridControl();
            this.gvTQ = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTqNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRaisedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConsultant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlTimeline = new DevExpress.XtraEditors.PanelControl();
            this.lblTimelineTitle = new DevExpress.XtraEditors.LabelControl();
            this.lstQueryHistory = new DevExpress.XtraEditors.ListBoxControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeline)).BeginInit();
            this.pnlTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstQueryHistory)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewTQ, this.bbiEditTQ, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewTQ),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditTQ),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات سجل الاستفسارات الهندسية TQ";

            this.bbiNewTQ.Caption = "إضافة استفسار هندسي (TQ جديد)";
            this.bbiEditTQ.Caption = "تعديل الاستفسار";
            this.bbiPrint.Caption = "طباعة سجل TQ";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdTQ);
            this.splitContainerControlMain.Panel1.Text = "سجل TQ";
            this.splitContainerControlMain.Panel2.Controls.Add(this.lstQueryHistory);
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlTimeline);
            this.splitContainerControlMain.Panel2.Text = "المخطط الزمني وسجل التغييرات";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 800;

            // grdTQ
            this.grdTQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTQ.Location = new System.Drawing.Point(0, 0);
            this.grdTQ.MainView = this.gvTQ;
            this.grdTQ.Name = "grdTQ";
            this.grdTQ.Size = new System.Drawing.Size(800, 720);
            this.grdTQ.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvTQ });

            // gvTQ
            this.gvTQ.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colTqNo, this.colSubject, this.colDiscipline,
                this.colRaisedBy, this.colConsultant, this.colStatus, this.colDueDate
            });
            this.gvTQ.GridControl = this.grdTQ;
            this.gvTQ.Name = "gvTQ";
            this.gvTQ.OptionsView.ShowAutoFilterRow = true;
            this.gvTQ.OptionsView.ShowFooter = true;

            this.colTqNo.Caption = "رقم الاستفسار (TQ No)";
            this.colTqNo.FieldName = "TqNo";
            this.colTqNo.Visible = true;
            this.colTqNo.VisibleIndex = 0;

            this.colSubject.Caption = "موضوع الاستفسار الهندسي";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;

            this.colDiscipline.Caption = "التخصص الهندسي";
            this.colDiscipline.FieldName = "Discipline";
            this.colDiscipline.Visible = true;
            this.colDiscipline.VisibleIndex = 2;

            this.colRaisedBy.Caption = "المُنشئ / المهندس";
            this.colRaisedBy.FieldName = "RaisedBy";
            this.colRaisedBy.Visible = true;
            this.colRaisedBy.VisibleIndex = 3;

            this.colConsultant.Caption = "استشاري المشروع المراجع";
            this.colConsultant.FieldName = "Consultant";
            this.colConsultant.Visible = true;
            this.colConsultant.VisibleIndex = 4;

            this.colStatus.Caption = "الحالة التشغيلية";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            this.colDueDate.Caption = "تاريخ الاستحقاق";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 6;

            // pnlTimeline
            this.pnlTimeline.Controls.Add(this.lblTimelineTitle);
            this.pnlTimeline.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimeline.Location = new System.Drawing.Point(0, 0);
            this.pnlTimeline.Name = "pnlTimeline";
            this.pnlTimeline.Size = new System.Drawing.Size(390, 35);

            this.lblTimelineTitle.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimelineTitle.Location = new System.Drawing.Point(10, 8);
            this.lblTimelineTitle.Text = "المخطط الزمني للردود (Query History Timeline)";

            // lstQueryHistory
            this.lstQueryHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstQueryHistory.Items.AddRange(new object[] {
                "2026-08-01 09:00: تقديم الاستفسار TQ-001 بواسطة Eng. Omar",
                "2026-08-02 11:30: تحويل الاستفسار إلى الاستشاري المطور",
                "2026-08-04 14:15: إرسال الرد الفني والاعتماد المبدئي",
                "2026-08-06 10:00: إغلاق الاستفسار وإضافته للأرشيف"
            });
            this.lstQueryHistory.Location = new System.Drawing.Point(0, 35);
            this.lstQueryHistory.Name = "lstQueryHistory";
            this.lstQueryHistory.Size = new System.Drawing.Size(390, 685);

            // ucTechnicalQueryRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucTechnicalQueryRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeline)).BeginInit();
            this.pnlTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstQueryHistory)).BeginInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewTQ;
        private DevExpress.XtraBars.BarButtonItem bbiEditTQ;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdTQ;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTQ;
        private DevExpress.XtraGrid.Columns.GridColumn colTqNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn colRaisedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colConsultant;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraEditors.PanelControl pnlTimeline;
        private DevExpress.XtraEditors.LabelControl lblTimelineTitle;
        private DevExpress.XtraEditors.ListBoxControl lstQueryHistory;
    }
}
