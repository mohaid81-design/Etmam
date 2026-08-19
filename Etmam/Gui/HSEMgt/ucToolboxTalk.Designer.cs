namespace Etmam.Gui.HSEMgt
{
    partial class ucToolboxTalk
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
            this.bbiNewTbt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSignAttendance = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdTBT = new DevExpress.XtraGrid.GridControl();
            this.gvTBT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSession = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTopic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrainer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdAttendance = new DevExpress.XtraGrid.GridControl();
            this.gvAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendance)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewTbt, this.bbiSignAttendance, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewTbt),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSignAttendance),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات اجتماع السلامة اليومي Toolbox Talks";

            this.bbiNewTbt.Caption = "جلسة توعية سلامة جديدة (New TBT)";
            this.bbiSignAttendance.Caption = "تسجيل وتوقيع الحضور";
            this.bbiExport.Caption = "تصدير محضر TBT";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdTBT);
            this.splitContainerControlMain.Panel1.Text = "جلسات التوعية ومواضيع السلامة اليومية";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdAttendance);
            this.splitContainerControlMain.Panel2.Text = "جدول حضور العمال وتوقيعات الاستلام (Attendance Grid & Signatures)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdTBT
            this.grdTBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTBT.Location = new System.Drawing.Point(0, 0);
            this.grdTBT.MainView = this.gvTBT;
            this.grdTBT.Name = "grdTBT";
            this.grdTBT.Size = new System.Drawing.Size(1200, 380);
            this.grdTBT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvTBT });

            // gvTBT
            this.gvTBT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colSession, this.colTopic, this.colDate,
                this.colTrainer, this.colAttendanceCount
            });
            this.gvTBT.GridControl = this.grdTBT;
            this.gvTBT.Name = "gvTBT";
            this.gvTBT.OptionsView.ShowAutoFilterRow = true;
            this.gvTBT.OptionsView.ShowFooter = true;

            this.colSession.Caption = "رقم الجلسة (Session ID)";
            this.colSession.FieldName = "Session";
            this.colSession.Visible = true;
            this.colSession.VisibleIndex = 0;

            this.colTopic.Caption = "موضوع محادثة السلامة (Topic)";
            this.colTopic.FieldName = "Topic";
            this.colTopic.Visible = true;
            this.colTopic.VisibleIndex = 1;

            this.colDate.Caption = "تاريخ وموعد الجلسة";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;

            this.colTrainer.Caption = "المحاضر / مهندس السلامة";
            this.colTrainer.FieldName = "Trainer";
            this.colTrainer.Visible = true;
            this.colTrainer.VisibleIndex = 3;

            this.colAttendanceCount.Caption = "عدد العمال الحاضرين";
            this.colAttendanceCount.FieldName = "AttendanceCount";
            this.colAttendanceCount.Visible = true;
            this.colAttendanceCount.VisibleIndex = 4;

            // grdAttendance
            this.grdAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAttendance.Location = new System.Drawing.Point(0, 0);
            this.grdAttendance.MainView = this.gvAttendance;
            this.grdAttendance.Name = "grdAttendance";
            this.grdAttendance.Size = new System.Drawing.Size(1200, 330);
            this.grdAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvAttendance });

            // gvAttendance
            this.gvAttendance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colEmployee, this.colCompany, this.colSignature, this.colAttendanceStatus
            });
            this.gvAttendance.GridControl = this.grdAttendance;
            this.gvAttendance.Name = "gvAttendance";
            this.gvAttendance.OptionsView.ShowAutoFilterRow = true;

            this.colEmployee.Caption = "اسم العامل / الموظف";
            this.colEmployee.FieldName = "Employee";
            this.colEmployee.Visible = true;
            this.colEmployee.VisibleIndex = 0;

            this.colCompany.Caption = "الشركة / المقاول التابع";
            this.colCompany.FieldName = "Company";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 1;

            this.colSignature.Caption = "التوقيع الإلكتروني / البصمة";
            this.colSignature.FieldName = "Signature";
            this.colSignature.Visible = true;
            this.colSignature.VisibleIndex = 2;

            this.colAttendanceStatus.Caption = "حالة الحضور والتوعية";
            this.colAttendanceStatus.FieldName = "AttendanceStatus";
            this.colAttendanceStatus.Visible = true;
            this.colAttendanceStatus.VisibleIndex = 3;

            // ucToolboxTalk
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucToolboxTalk";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTBT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendance)).BeginInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewTbt;
        private DevExpress.XtraBars.BarButtonItem bbiSignAttendance;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdTBT;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTBT;
        private DevExpress.XtraGrid.Columns.GridColumn colSession;
        private DevExpress.XtraGrid.Columns.GridColumn colTopic;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTrainer;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceCount;
        private DevExpress.XtraGrid.GridControl grdAttendance;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAttendance;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colSignature;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceStatus;
    }
}
