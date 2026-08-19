namespace Etmam.Gui.ContractMgt
{
    partial class ucVariationOrderManagement
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
            this.bbiNewVO = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApproveVO = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRejectVO = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrintVO = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            this.lblPendingVO = new DevExpress.XtraEditors.LabelControl();
            this.lblApprovedVO = new DevExpress.XtraEditors.LabelControl();
            this.lblRejectedVO = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalVOValue = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdVO = new DevExpress.XtraGrid.GridControl();
            this.gvVO = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInitiator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApprovalDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlBottom = new DevExpress.XtraTab.XtraTabControl();
            this.tabPricing = new DevExpress.XtraTab.XtraTabPage();
            this.tabBoqImpact = new DevExpress.XtraTab.XtraTabPage();
            this.tabScheduleImpact = new DevExpress.XtraTab.XtraTabPage();
            this.tabDocuments = new DevExpress.XtraTab.XtraTabPage();
            this.tabWorkflow = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).BeginInit();
            this.pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVO)).BeginInit();
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
                this.bbiNewVO, this.bbiApproveVO, this.bbiRejectVO, this.bbiPrintVO
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewVO),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiApproveVO),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRejectVO),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrintVO)
            });
            this.barMain.Text = "أدوات أوامر التغيير";

            this.bbiNewVO.Caption = "أمر تغيير جديد";
            this.bbiApproveVO.Caption = "اعتماد الأمر";
            this.bbiRejectVO.Caption = "رفض الأمر";
            this.bbiPrintVO.Caption = "طباعة";

            // pnlKpiCards
            this.pnlKpiCards.Controls.Add(this.lblPendingVO);
            this.pnlKpiCards.Controls.Add(this.lblApprovedVO);
            this.pnlKpiCards.Controls.Add(this.lblRejectedVO);
            this.pnlKpiCards.Controls.Add(this.lblTotalVOValue);
            this.pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiCards.Location = new System.Drawing.Point(0, 30);
            this.pnlKpiCards.Name = "pnlKpiCards";
            this.pnlKpiCards.Size = new System.Drawing.Size(1200, 50);

            this.lblPendingVO.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPendingVO.Location = new System.Drawing.Point(1000, 15);
            this.lblPendingVO.Text = "الأوامر المعلقة: 4";

            this.lblApprovedVO.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApprovedVO.Location = new System.Drawing.Point(780, 15);
            this.lblApprovedVO.Text = "الأوامر المعتمدة: 12";

            this.lblRejectedVO.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRejectedVO.Location = new System.Drawing.Point(580, 15);
            this.lblRejectedVO.Text = "الأوامر المرفوضة: 2";

            this.lblTotalVOValue.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalVOValue.Location = new System.Drawing.Point(280, 15);
            this.lblTotalVOValue.Text = "إجمالي قيمة الأوامر المعتمدة: 8,450,000 ر.س";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdVO);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabControlBottom);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 400;

            // grdVO
            this.grdVO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVO.Location = new System.Drawing.Point(0, 0);
            this.grdVO.MainView = this.gvVO;
            this.grdVO.Name = "grdVO";
            this.grdVO.Size = new System.Drawing.Size(1200, 400);
            this.grdVO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvVO });

            // gvVO
            this.gvVO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colVONo, this.colDescription, this.colInitiator,
                this.colAmount, this.colStatus, this.colApprovalDate
            });
            this.gvVO.GridControl = this.grdVO;
            this.gvVO.Name = "gvVO";

            this.colVONo.Caption = "رقم أمر التغيير";
            this.colVONo.FieldName = "VONo";
            this.colVONo.Visible = true;
            this.colVONo.VisibleIndex = 0;

            this.colDescription.Caption = "بيان العمل والوصف";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;

            this.colInitiator.Caption = "الجهة الطالبة";
            this.colInitiator.FieldName = "Initiator";
            this.colInitiator.Visible = true;
            this.colInitiator.VisibleIndex = 2;

            this.colAmount.Caption = "القيمة المالية";
            this.colAmount.FieldName = "Amount";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;

            this.colStatus.Caption = "الحالة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            this.colApprovalDate.Caption = "تاريخ الاعتماد";
            this.colApprovalDate.FieldName = "ApprovalDate";
            this.colApprovalDate.Visible = true;
            this.colApprovalDate.VisibleIndex = 5;

            // tabControlBottom
            this.tabControlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBottom.Location = new System.Drawing.Point(0, 0);
            this.tabControlBottom.Name = "tabControlBottom";
            this.tabControlBottom.SelectedTabPage = this.tabPricing;
            this.tabControlBottom.Size = new System.Drawing.Size(1200, 260);
            this.tabControlBottom.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tabPricing, this.tabBoqImpact, this.tabScheduleImpact, this.tabDocuments, this.tabWorkflow
            });

            this.tabPricing.Name = "tabPricing";
            this.tabPricing.Text = "تفاصيل التسعير وتحليل التكلفة";

            this.tabBoqImpact.Name = "tabBoqImpact";
            this.tabBoqImpact.Text = "الأثر على بنود BOQ";

            this.tabScheduleImpact.Name = "tabScheduleImpact";
            this.tabScheduleImpact.Text = "الأثر على الجدول الزمني والتأخيرات";

            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Text = "المستندات والدلائل الفنية";

            this.tabWorkflow.Name = "tabWorkflow";
            this.tabWorkflow.Text = "دورة الاعتمادات والموافقات";

            // ucVariationOrderManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlKpiCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucVariationOrderManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).EndInit();
            this.pnlKpiCards.ResumeLayout(false);
            this.pnlKpiCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlBottom)).EndInit();
            this.tabControlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewVO;
        private DevExpress.XtraBars.BarButtonItem bbiApproveVO;
        private DevExpress.XtraBars.BarButtonItem bbiRejectVO;
        private DevExpress.XtraBars.BarButtonItem bbiPrintVO;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.LabelControl lblPendingVO;
        private DevExpress.XtraEditors.LabelControl lblApprovedVO;
        private DevExpress.XtraEditors.LabelControl lblRejectedVO;
        private DevExpress.XtraEditors.LabelControl lblTotalVOValue;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdVO;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVO;
        private DevExpress.XtraGrid.Columns.GridColumn colVONo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colInitiator;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovalDate;
        private DevExpress.XtraTab.XtraTabControl tabControlBottom;
        private DevExpress.XtraTab.XtraTabPage tabPricing;
        private DevExpress.XtraTab.XtraTabPage tabBoqImpact;
        private DevExpress.XtraTab.XtraTabPage tabScheduleImpact;
        private DevExpress.XtraTab.XtraTabPage tabDocuments;
        private DevExpress.XtraTab.XtraTabPage tabWorkflow;
    }
}
