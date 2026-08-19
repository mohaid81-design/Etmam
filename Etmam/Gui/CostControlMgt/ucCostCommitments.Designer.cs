namespace Etmam.Gui.CostControlMgt
{
    partial class ucCostCommitments
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
            this.bbiNewCommitment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLinkPO = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLinkContract = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseCommitment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblOpen = new DevExpress.XtraEditors.LabelControl();
            this.lblClosed = new DevExpress.XtraEditors.LabelControl();
            this.lblPendingApproval = new DevExpress.XtraEditors.LabelControl();
            this.grdCommitments = new DevExpress.XtraGrid.GridControl();
            this.gvCommitments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCommitmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVendor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApprovedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCommitments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCommitments)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewCommitment, this.bbiLinkPO, this.bbiLinkContract,
                this.bbiCloseCommitment, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewCommitment),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiLinkPO),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiLinkContract),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCloseCommitment),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات سجل التزامات التكاليف (Cost Commitments)";

            this.bbiNewCommitment.Caption = "تسجيل التزام مالي جديد (New Commitment)";
            this.bbiLinkPO.Caption = "ربط مع أمر شراء (PO)";
            this.bbiLinkContract.Caption = "ربط مع عقد مقاول باطن";
            this.bbiCloseCommitment.Caption = "إغلاق التسوية والالتزام";
            this.bbiExport.Caption = "تصدير سجل الالتزامات";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblOpen);
            this.pnlCards.Controls.Add(this.lblClosed);
            this.pnlCards.Controls.Add(this.lblPendingApproval);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblOpen.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOpen.Location = new System.Drawing.Point(950, 15);
            this.lblOpen.Text = "التزامات مفتوحة (Open): 42.5M SAR";

            this.lblClosed.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClosed.Location = new System.Drawing.Point(620, 15);
            this.lblClosed.Text = "التزامات مغلقة ومسواة (Closed): 25.5M SAR";

            this.lblPendingApproval.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPendingApproval.Location = new System.Drawing.Point(280, 15);
            this.lblPendingApproval.Text = "التزامات قيد الاعتماد (Pending): 3.2M SAR";

            // grdCommitments
            this.grdCommitments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCommitments.Location = new System.Drawing.Point(0, 80);
            this.grdCommitments.MainView = this.gvCommitments;
            this.grdCommitments.Name = "grdCommitments";
            this.grdCommitments.Size = new System.Drawing.Size(1200, 670);
            this.grdCommitments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvCommitments });

            // gvCommitments
            this.gvCommitments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCommitmentNo, this.colSource, this.colProject,
                this.colVendor, this.colCostCode, this.colAmount,
                this.colApprovedAmount, this.colStatus
            });
            this.gvCommitments.GridControl = this.grdCommitments;
            this.gvCommitments.Name = "gvCommitments";
            this.gvCommitments.OptionsView.ShowAutoFilterRow = true;
            this.gvCommitments.OptionsView.ShowFooter = true;

            this.colCommitmentNo.Caption = "رقم الالتزام (Commitment No)";
            this.colCommitmentNo.FieldName = "CommitmentNo";
            this.colCommitmentNo.Visible = true;
            this.colCommitmentNo.VisibleIndex = 0;

            this.colSource.Caption = "مصدر الالتزام (PO / Subcontract / Claim)";
            this.colSource.FieldName = "Source";
            this.colSource.Visible = true;
            this.colSource.VisibleIndex = 1;

            this.colProject.Caption = "المشروع التابع";
            this.colProject.FieldName = "Project";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 2;

            this.colVendor.Caption = "المورد / المقاول المستفيد";
            this.colVendor.FieldName = "Vendor";
            this.colVendor.Visible = true;
            this.colVendor.VisibleIndex = 3;

            this.colCostCode.Caption = "رمز التكلفة التابع (Cost Code)";
            this.colCostCode.FieldName = "CostCode";
            this.colCostCode.Visible = true;
            this.colCostCode.VisibleIndex = 4;

            this.colAmount.Caption = "قيمة الالتزام (Commitment Amount)";
            this.colAmount.FieldName = "Amount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 5;

            this.colApprovedAmount.Caption = "المبلغ المعتمد الصرف (Approved)";
            this.colApprovedAmount.FieldName = "ApprovedAmount";
            this.colApprovedAmount.Visible = true;
            this.colApprovedAmount.VisibleIndex = 6;

            this.colStatus.Caption = "حالة الالتزام المالي";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 7;

            // ucCostCommitments
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdCommitments);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCostCommitments";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCommitments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCommitments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewCommitment;
        private DevExpress.XtraBars.BarButtonItem bbiLinkPO;
        private DevExpress.XtraBars.BarButtonItem bbiLinkContract;
        private DevExpress.XtraBars.BarButtonItem bbiCloseCommitment;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblOpen;
        private DevExpress.XtraEditors.LabelControl lblClosed;
        private DevExpress.XtraEditors.LabelControl lblPendingApproval;
        private DevExpress.XtraGrid.GridControl grdCommitments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCommitments;
        private DevExpress.XtraGrid.Columns.GridColumn colCommitmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colVendor;
        private DevExpress.XtraGrid.Columns.GridColumn colCostCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
