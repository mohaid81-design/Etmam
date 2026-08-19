namespace Etmam.Gui.QualityMgt
{
    partial class ucCAPAManagement
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
            this.bbiNewCapa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseCapa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblPending = new DevExpress.XtraEditors.LabelControl();
            this.lblCompleted = new DevExpress.XtraEditors.LabelControl();
            this.lblOverdue = new DevExpress.XtraEditors.LabelControl();
            this.grdCAPA = new DevExpress.XtraGrid.GridControl();
            this.gvCAPA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCAPANo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCAPA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCAPA)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewCapa, this.bbiCloseCapa, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewCapa),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCloseCapa),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات الإجراءات التصحيحية والوقائية CAPA";

            this.bbiNewCapa.Caption = "إضافة إجراء CAPA جديد";
            this.bbiCloseCapa.Caption = "تأكيد إغلاق الإجراء";
            this.bbiPrint.Caption = "طباعة سجل CAPA";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblPending);
            this.pnlCards.Controls.Add(this.lblCompleted);
            this.pnlCards.Controls.Add(this.lblOverdue);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblPending.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPending.Location = new System.Drawing.Point(950, 15);
            this.lblPending.Text = "إجراءات قيد التنفيذ: 8";

            this.lblCompleted.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCompleted.Location = new System.Drawing.Point(650, 15);
            this.lblCompleted.Text = "إجراءات مكتملة ومعتمدة: 54";

            this.lblOverdue.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOverdue.Location = new System.Drawing.Point(320, 15);
            this.lblOverdue.Text = "إجراءات متأخرة: 1";

            // grdCAPA
            this.grdCAPA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCAPA.Location = new System.Drawing.Point(0, 80);
            this.grdCAPA.MainView = this.gvCAPA;
            this.grdCAPA.Name = "grdCAPA";
            this.grdCAPA.Size = new System.Drawing.Size(1200, 670);
            this.grdCAPA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvCAPA });

            // gvCAPA
            this.gvCAPA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCAPANo, this.colNCR, this.colDescription,
                this.colOwner, this.colDueDate, this.colStatus
            });
            this.gvCAPA.GridControl = this.grdCAPA;
            this.gvCAPA.Name = "gvCAPA";
            this.gvCAPA.OptionsView.ShowAutoFilterRow = true;
            this.gvCAPA.OptionsView.ShowFooter = true;

            this.colCAPANo.Caption = "رقم الإجراء (CAPA No)";
            this.colCAPANo.FieldName = "CAPANo";
            this.colCAPANo.Visible = true;
            this.colCAPANo.VisibleIndex = 0;

            this.colNCR.Caption = "رقم تقرير عدم المطابقة المربوط";
            this.colNCR.FieldName = "NCR";
            this.colNCR.Visible = true;
            this.colNCR.VisibleIndex = 1;

            this.colDescription.Caption = "وصف الخطة والحل الوقائي/التصحيحي";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;

            this.colOwner.Caption = "المسؤول عن التنفيذ (Owner)";
            this.colOwner.FieldName = "Owner";
            this.colOwner.Visible = true;
            this.colOwner.VisibleIndex = 3;

            this.colDueDate.Caption = "تاريخ الاستحقاق";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 4;

            this.colStatus.Caption = "حالة الإجراء";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // ucCAPAManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdCAPA);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCAPAManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCAPA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCAPA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewCapa;
        private DevExpress.XtraBars.BarButtonItem bbiCloseCapa;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblPending;
        private DevExpress.XtraEditors.LabelControl lblCompleted;
        private DevExpress.XtraEditors.LabelControl lblOverdue;
        private DevExpress.XtraGrid.GridControl grdCAPA;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCAPA;
        private DevExpress.XtraGrid.Columns.GridColumn colCAPANo;
        private DevExpress.XtraGrid.Columns.GridColumn colNCR;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
