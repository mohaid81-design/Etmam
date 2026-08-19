namespace Etmam.Gui.QualityMgt
{
    partial class ucNCRRegister
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
            this.bbiNewNCR = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditNCR = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblOpen = new DevExpress.XtraEditors.LabelControl();
            this.lblClosed = new DevExpress.XtraEditors.LabelControl();
            this.lblHighSeverity = new DevExpress.XtraEditors.LabelControl();
            this.lblOverdue = new DevExpress.XtraEditors.LabelControl();
            this.grdNCR = new DevExpress.XtraGrid.GridControl();
            this.gvNCR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNCRNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNCR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNCR)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewNCR, this.bbiEditNCR, this.bbiPrint, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewNCR),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditNCR),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل تقارير عدم المطابقة NCR";

            this.bbiNewNCR.Caption = "تقرير عدم مطابقة جديد (NCR)";
            this.bbiEditNCR.Caption = "تعديل تقرير NCR";
            this.bbiPrint.Caption = "طباعة NCR";
            this.bbiExport.Caption = "تصدير إلى Excel/PDF";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblOpen);
            this.pnlCards.Controls.Add(this.lblClosed);
            this.pnlCards.Controls.Add(this.lblHighSeverity);
            this.pnlCards.Controls.Add(this.lblOverdue);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblOpen.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOpen.Location = new System.Drawing.Point(960, 15);
            this.lblOpen.Text = "NCR مفتوحة: 5";

            this.lblClosed.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClosed.Location = new System.Drawing.Point(700, 15);
            this.lblClosed.Text = "NCR مغلقة ومعالجة: 42";

            this.lblHighSeverity.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHighSeverity.Location = new System.Drawing.Point(400, 15);
            this.lblHighSeverity.Text = "خطورة عالية (High Severity): 2";

            this.lblOverdue.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOverdue.Location = new System.Drawing.Point(140, 15);
            this.lblOverdue.Text = "تعدت تاريخ الاستحقاق: 1";

            // grdNCR
            this.grdNCR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNCR.Location = new System.Drawing.Point(0, 80);
            this.grdNCR.MainView = this.gvNCR;
            this.grdNCR.Name = "grdNCR";
            this.grdNCR.Size = new System.Drawing.Size(1200, 670);
            this.grdNCR.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvNCR });

            // gvNCR
            this.gvNCR.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colNCRNo, this.colDescription, this.colDiscipline,
                this.colContractor, this.colSeverity, this.colStatus, this.colDueDate
            });
            this.gvNCR.GridControl = this.grdNCR;
            this.gvNCR.Name = "gvNCR";
            this.gvNCR.OptionsView.ShowAutoFilterRow = true;
            this.gvNCR.OptionsView.ShowFooter = true;

            this.colNCRNo.Caption = "رقم تقرير عدم المطابقة (NCR No)";
            this.colNCRNo.FieldName = "NCRNo";
            this.colNCRNo.Visible = true;
            this.colNCRNo.VisibleIndex = 0;

            this.colDescription.Caption = "وصف المخالفة والسبب عدم المطابقة";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;

            this.colDiscipline.Caption = "التخصص (Discipline)";
            this.colDiscipline.FieldName = "Discipline";
            this.colDiscipline.Visible = true;
            this.colDiscipline.VisibleIndex = 2;

            this.colContractor.Caption = "المقاول المنفذ / الباطن";
            this.colContractor.FieldName = "Contractor";
            this.colContractor.Visible = true;
            this.colContractor.VisibleIndex = 3;

            this.colSeverity.Caption = "درجة الخطورة (Severity)";
            this.colSeverity.FieldName = "Severity";
            this.colSeverity.Visible = true;
            this.colSeverity.VisibleIndex = 4;

            this.colStatus.Caption = "حالة الـ NCR ومسار الإغلاق";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            this.colDueDate.Caption = "تاريخ الاستحقاق والإغلاق";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 6;

            // ucNCRRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdNCR);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucNCRRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNCR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNCR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewNCR;
        private DevExpress.XtraBars.BarButtonItem bbiEditNCR;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblOpen;
        private DevExpress.XtraEditors.LabelControl lblClosed;
        private DevExpress.XtraEditors.LabelControl lblHighSeverity;
        private DevExpress.XtraEditors.LabelControl lblOverdue;
        private DevExpress.XtraGrid.GridControl grdNCR;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNCR;
        private DevExpress.XtraGrid.Columns.GridColumn colNCRNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn colContractor;
        private DevExpress.XtraGrid.Columns.GridColumn colSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
    }
}
