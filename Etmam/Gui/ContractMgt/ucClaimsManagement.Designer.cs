namespace Etmam.Gui.ContractMgt
{
    partial class ucClaimsManagement
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
            this.bbiNewClaim = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSubmitClaim = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApproveClaim = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRejectClaim = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            this.lblOpenClaims = new DevExpress.XtraEditors.LabelControl();
            this.lblSubmittedClaims = new DevExpress.XtraEditors.LabelControl();
            this.lblApprovedClaims = new DevExpress.XtraEditors.LabelControl();
            this.lblRejectedClaims = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdClaims = new DevExpress.XtraGrid.GridControl();
            this.gvClaims = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colClaimNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCause = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysClaimed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlBottom = new DevExpress.XtraTab.XtraTabControl();
            this.tabDocuments = new DevExpress.XtraTab.XtraTabPage();
            this.tabEvidence = new DevExpress.XtraTab.XtraTabPage();
            this.tabCorrespondence = new DevExpress.XtraTab.XtraTabPage();
            this.tabTimeline = new DevExpress.XtraTab.XtraTabPage();
            this.tabAudit = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).BeginInit();
            this.pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClaims)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClaims)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlBottom)).BeginInit();
            this.tabControlBottom.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewClaim, this.bbiSubmitClaim, this.bbiApproveClaim, this.bbiRejectClaim
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewClaim),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSubmitClaim),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiApproveClaim),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRejectClaim)
            });
            this.barMain.Text = "أدوات المطالبات والنزاعات";

            this.bbiNewClaim.Caption = "مطالبة جديدة";
            this.bbiSubmitClaim.Caption = "تقديم المطالبة رسمياً";
            this.bbiApproveClaim.Caption = "قبول / اعتماد";
            this.bbiRejectClaim.Caption = "رفض المطالبة";

            // pnlKpiCards
            this.pnlKpiCards.Controls.Add(this.lblOpenClaims);
            this.pnlKpiCards.Controls.Add(this.lblSubmittedClaims);
            this.pnlKpiCards.Controls.Add(this.lblApprovedClaims);
            this.pnlKpiCards.Controls.Add(this.lblRejectedClaims);
            this.pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiCards.Location = new System.Drawing.Point(0, 30);
            this.pnlKpiCards.Name = "pnlKpiCards";
            this.pnlKpiCards.Size = new System.Drawing.Size(1200, 50);

            this.lblOpenClaims.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOpenClaims.Location = new System.Drawing.Point(1000, 15);
            this.lblOpenClaims.Text = "المطالبات المفتوحة: 5";

            this.lblSubmittedClaims.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubmittedClaims.Location = new System.Drawing.Point(780, 15);
            this.lblSubmittedClaims.Text = "المرفوعة للاستشاري: 3";

            this.lblApprovedClaims.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApprovedClaims.Location = new System.Drawing.Point(560, 15);
            this.lblApprovedClaims.Text = "المعتمدة: 2 (قيمة 3.5 مليون ر.س)";

            this.lblRejectedClaims.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRejectedClaims.Location = new System.Drawing.Point(280, 15);
            this.lblRejectedClaims.Text = "المرفوضة: 1";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdClaims);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabControlBottom);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 400;

            // grdClaims
            this.grdClaims.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdClaims.Location = new System.Drawing.Point(0, 0);
            this.grdClaims.MainView = this.gvClaims;
            this.grdClaims.Name = "grdClaims";
            this.grdClaims.Size = new System.Drawing.Size(1200, 400);
            this.grdClaims.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvClaims });

            // gvClaims
            this.gvClaims.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colClaimNo, this.colType, this.colCause,
                this.colAmount, this.colDaysClaimed, this.colStatus, this.colOwner
            });
            this.gvClaims.GridControl = this.grdClaims;
            this.gvClaims.Name = "gvClaims";

            this.colClaimNo.Caption = "رقم المطالبة";
            this.colClaimNo.FieldName = "ClaimNo";
            this.colClaimNo.Visible = true;
            this.colClaimNo.VisibleIndex = 0;

            this.colType.Caption = "نوع المطالبة";
            this.colType.FieldName = "Type";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;

            this.colCause.Caption = "سبب المطالبة والأساس التعاقدي";
            this.colCause.FieldName = "Cause";
            this.colCause.Visible = true;
            this.colCause.VisibleIndex = 2;

            this.colAmount.Caption = "المبلغ المالي المطالب به";
            this.colAmount.FieldName = "Amount";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;

            this.colDaysClaimed.Caption = "الأيام المطلوبة (EOT)";
            this.colDaysClaimed.FieldName = "DaysClaimed";
            this.colDaysClaimed.Visible = true;
            this.colDaysClaimed.VisibleIndex = 4;

            this.colStatus.Caption = "الحالة الراهنة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            this.colOwner.Caption = "مسؤول المطالبة";
            this.colOwner.FieldName = "Owner";
            this.colOwner.Visible = true;
            this.colOwner.VisibleIndex = 6;

            // tabControlBottom
            this.tabControlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBottom.Location = new System.Drawing.Point(0, 0);
            this.tabControlBottom.Name = "tabControlBottom";
            this.tabControlBottom.SelectedTabPage = this.tabDocuments;
            this.tabControlBottom.Size = new System.Drawing.Size(1200, 260);
            this.tabControlBottom.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tabDocuments, this.tabEvidence, this.tabCorrespondence, this.tabTimeline, this.tabAudit
            });

            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Text = "المستندات والدلائل الثبوتية";

            this.tabEvidence.Name = "tabEvidence";
            this.tabEvidence.Text = "الأدلة والتحليلات الفنية والزمنية";

            this.tabCorrespondence.Name = "tabCorrespondence";
            this.tabCorrespondence.Text = "المراسلات والخطابات المرتبطة";

            this.tabTimeline.Name = "tabTimeline";
            this.tabTimeline.Text = "المخطط الزمني للنزاع وتطور الإجراءات";

            this.tabAudit.Name = "tabAudit";
            this.tabAudit.Text = "سجل التتبع والمراجعة";

            // ucClaimsManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlKpiCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucClaimsManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).EndInit();
            this.pnlKpiCards.ResumeLayout(false);
            this.pnlKpiCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdClaims)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClaims)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlBottom)).EndInit();
            this.tabControlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewClaim;
        private DevExpress.XtraBars.BarButtonItem bbiSubmitClaim;
        private DevExpress.XtraBars.BarButtonItem bbiApproveClaim;
        private DevExpress.XtraBars.BarButtonItem bbiRejectClaim;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.LabelControl lblOpenClaims;
        private DevExpress.XtraEditors.LabelControl lblSubmittedClaims;
        private DevExpress.XtraEditors.LabelControl lblApprovedClaims;
        private DevExpress.XtraEditors.LabelControl lblRejectedClaims;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdClaims;
        private DevExpress.XtraGrid.Views.Grid.GridView gvClaims;
        private DevExpress.XtraGrid.Columns.GridColumn colClaimNo;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colCause;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysClaimed;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraTab.XtraTabControl tabControlBottom;
        private DevExpress.XtraTab.XtraTabPage tabDocuments;
        private DevExpress.XtraTab.XtraTabPage tabEvidence;
        private DevExpress.XtraTab.XtraTabPage tabCorrespondence;
        private DevExpress.XtraTab.XtraTabPage tabTimeline;
        private DevExpress.XtraTab.XtraTabPage tabAudit;
    }
}
