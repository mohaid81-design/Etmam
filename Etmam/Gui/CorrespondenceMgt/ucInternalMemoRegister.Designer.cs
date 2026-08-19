namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucInternalMemoRegister
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
            this.bbiNewMemo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditMemo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPublish = new DevExpress.XtraBars.BarButtonItem();
            this.bbiArchive = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grdMemos = new DevExpress.XtraGrid.GridControl();
            this.gvMemos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMemoNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMemos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMemos)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewMemo, this.bbiEditMemo, this.bbiPublish, this.bbiArchive
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewMemo),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditMemo),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPublish),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiArchive)
            });
            this.barMain.Text = "أدوات المذكرات الداخلية";

            this.bbiNewMemo.Caption = "مذكرة داخلية جديدة";
            this.bbiEditMemo.Caption = "تعديل المذكرة";
            this.bbiPublish.Caption = "نشر وتوجيه المذكرة";
            this.bbiArchive.Caption = "أرشفة المذكرة";

            // grdMemos
            this.grdMemos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMemos.Location = new System.Drawing.Point(0, 30);
            this.grdMemos.MainView = this.gvMemos;
            this.grdMemos.Name = "grdMemos";
            this.grdMemos.Size = new System.Drawing.Size(1200, 720);
            this.grdMemos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvMemos });

            // gvMemos
            this.gvMemos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colMemoNo, this.colSubject, this.colDepartment,
                this.colCreatedBy, this.colDate, this.colStatus
            });
            this.gvMemos.GridControl = this.grdMemos;
            this.gvMemos.Name = "gvMemos";
            this.gvMemos.OptionsView.ShowAutoFilterRow = true;
            this.gvMemos.OptionsView.ShowFooter = true;

            this.colMemoNo.Caption = "رقم المذكرة (Memo No)";
            this.colMemoNo.FieldName = "MemoNo";
            this.colMemoNo.Visible = true;
            this.colMemoNo.VisibleIndex = 0;

            this.colSubject.Caption = "موضوع المذكرة الداخلية";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;

            this.colDepartment.Caption = "الإدارة / القسم الموجه إليه";
            this.colDepartment.FieldName = "Department";
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 2;

            this.colCreatedBy.Caption = "المُحرِر / المُنشِئ";
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 3;

            this.colDate.Caption = "تاريخ الإصدار والنشر";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 4;

            this.colStatus.Caption = "حالة المذكرة التشغيلية";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // ucInternalMemoRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdMemos);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucInternalMemoRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMemos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMemos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewMemo;
        private DevExpress.XtraBars.BarButtonItem bbiEditMemo;
        private DevExpress.XtraBars.BarButtonItem bbiPublish;
        private DevExpress.XtraBars.BarButtonItem bbiArchive;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl grdMemos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMemos;
        private DevExpress.XtraGrid.Columns.GridColumn colMemoNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
