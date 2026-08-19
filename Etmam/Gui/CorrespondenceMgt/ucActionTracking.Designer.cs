namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucActionTracking
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
            this.bbiNewAction = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCompleteAction = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblOpenActions = new DevExpress.XtraEditors.LabelControl();
            this.lblOverdueActions = new DevExpress.XtraEditors.LabelControl();
            this.lblCompletedActions = new DevExpress.XtraEditors.LabelControl();
            this.grdActionTracking = new DevExpress.XtraGrid.GridControl();
            this.gvActionTracking = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colActionNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinkedCorrespondence = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActionTracking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvActionTracking)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewAction, this.bbiCompleteAction, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewAction),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCompleteAction),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات تتبع الإجراءات";

            this.bbiNewAction.Caption = "إضافة تكليف / إجراء جديد";
            this.bbiCompleteAction.Caption = "إغلاق واستكمال الإجراء";
            this.bbiPrint.Caption = "طباعة سجل التكليفات";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblOpenActions);
            this.pnlCards.Controls.Add(this.lblOverdueActions);
            this.pnlCards.Controls.Add(this.lblCompletedActions);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblOpenActions.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOpenActions.Location = new System.Drawing.Point(960, 15);
            this.lblOpenActions.Text = "الإجراءات المفتوحة: 18";

            this.lblOverdueActions.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOverdueActions.Location = new System.Drawing.Point(650, 15);
            this.lblOverdueActions.Text = "الإجراءات المتأخرة: 4";

            this.lblCompletedActions.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCompletedActions.Location = new System.Drawing.Point(320, 15);
            this.lblCompletedActions.Text = "الإجراءات المكتملة: 142";

            // grdActionTracking
            this.grdActionTracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdActionTracking.Location = new System.Drawing.Point(0, 80);
            this.grdActionTracking.MainView = this.gvActionTracking;
            this.grdActionTracking.Name = "grdActionTracking";
            this.grdActionTracking.Size = new System.Drawing.Size(1200, 670);
            this.grdActionTracking.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvActionTracking });

            // gvActionTracking
            this.gvActionTracking.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colActionNo, this.colDescription, this.colOwner,
                this.colDueDate, this.colStatus, this.colLinkedCorrespondence
            });
            this.gvActionTracking.GridControl = this.grdActionTracking;
            this.gvActionTracking.Name = "gvActionTracking";
            this.gvActionTracking.OptionsView.ShowAutoFilterRow = true;
            this.gvActionTracking.OptionsView.ShowFooter = true;

            this.colActionNo.Caption = "رقم التكليف (Action No)";
            this.colActionNo.FieldName = "ActionNo";
            this.colActionNo.Visible = true;
            this.colActionNo.VisibleIndex = 0;

            this.colDescription.Caption = "تفاصيل ووصف الإجراء المطلوبة";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;

            this.colOwner.Caption = "المسؤول عن التنفيذ (Owner)";
            this.colOwner.FieldName = "Owner";
            this.colOwner.Visible = true;
            this.colOwner.VisibleIndex = 2;

            this.colDueDate.Caption = "تاريخ الاستحقاق (Due Date)";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 3;

            this.colStatus.Caption = "حالة الإنجاز المباشرة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            this.colLinkedCorrespondence.Caption = "المراسلة المرتبطة (Linked Doc)";
            this.colLinkedCorrespondence.FieldName = "LinkedCorrespondence";
            this.colLinkedCorrespondence.Visible = true;
            this.colLinkedCorrespondence.VisibleIndex = 5;

            // ucActionTracking
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdActionTracking);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucActionTracking";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActionTracking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvActionTracking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewAction;
        private DevExpress.XtraBars.BarButtonItem bbiCompleteAction;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblOpenActions;
        private DevExpress.XtraEditors.LabelControl lblOverdueActions;
        private DevExpress.XtraEditors.LabelControl lblCompletedActions;
        private DevExpress.XtraGrid.GridControl grdActionTracking;
        private DevExpress.XtraGrid.Views.Grid.GridView gvActionTracking;
        private DevExpress.XtraGrid.Columns.GridColumn colActionNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colLinkedCorrespondence;
    }
}
