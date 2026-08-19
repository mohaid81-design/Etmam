namespace Etmam.Gui.ContractMgt
{
    partial class ucContractAmendments
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
            this.bbiNewAmendment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApproveAmendment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdAmendments = new DevExpress.XtraGrid.GridControl();
            this.gvAmendments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAmendmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlTimelineView = new DevExpress.XtraEditors.PanelControl();
            this.lblTimelineTitle = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAmendments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAmendments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimelineView)).BeginInit();
            this.pnlTimelineView.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewAmendment, this.bbiApproveAmendment, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewAmendment),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiApproveAmendment),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات التعديلات والملحقات";

            this.bbiNewAmendment.Caption = "ملحق جديد";
            this.bbiApproveAmendment.Caption = "اعتماد الملحق";
            this.bbiPrint.Caption = "طباعة";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdAmendments);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlTimelineView);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 450;

            // grdAmendments
            this.grdAmendments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAmendments.Location = new System.Drawing.Point(0, 0);
            this.grdAmendments.MainView = this.gvAmendments;
            this.grdAmendments.Name = "grdAmendments";
            this.grdAmendments.Size = new System.Drawing.Size(1200, 450);
            this.grdAmendments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvAmendments });

            // gvAmendments
            this.gvAmendments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colAmendmentNo, this.colDescription, this.colDate,
                this.colImpact, this.colStatus
            });
            this.gvAmendments.GridControl = this.grdAmendments;
            this.gvAmendments.Name = "gvAmendments";

            this.colAmendmentNo.Caption = "رقم التعديل / الملحق";
            this.colAmendmentNo.FieldName = "AmendmentNo";
            this.colAmendmentNo.Visible = true;
            this.colAmendmentNo.VisibleIndex = 0;

            this.colDescription.Caption = "بيان التعديل وأسباب الملحق";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;

            this.colDate.Caption = "تاريخ الإصدار";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;

            this.colImpact.Caption = "الأثر المالي والزمني";
            this.colImpact.FieldName = "Impact";
            this.colImpact.Visible = true;
            this.colImpact.VisibleIndex = 3;

            this.colStatus.Caption = "الحالة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            // pnlTimelineView
            this.pnlTimelineView.Controls.Add(this.lblTimelineTitle);
            this.pnlTimelineView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTimelineView.Location = new System.Drawing.Point(0, 0);
            this.pnlTimelineView.Name = "pnlTimelineView";
            this.pnlTimelineView.Size = new System.Drawing.Size(1200, 260);

            this.lblTimelineTitle.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTimelineTitle.Location = new System.Drawing.Point(950, 15);
            this.lblTimelineTitle.Text = "المخطط الزمني التتابعي للملحقات والتعديلات التعاقدية (Timeline)";

            // ucContractAmendments
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucContractAmendments";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAmendments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAmendments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimelineView)).EndInit();
            this.pnlTimelineView.ResumeLayout(false);
            this.pnlTimelineView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewAmendment;
        private DevExpress.XtraBars.BarButtonItem bbiApproveAmendment;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdAmendments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAmendments;
        private DevExpress.XtraGrid.Columns.GridColumn colAmendmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colImpact;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.PanelControl pnlTimelineView;
        private DevExpress.XtraEditors.LabelControl lblTimelineTitle;
    }
}
