namespace Etmam.Gui.CostControlMgt
{
    partial class ucBudgetVsCommitment
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
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlVarianceSummary = new DevExpress.XtraEditors.PanelControl();
            this.lblTotalBudget = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalCommitment = new DevExpress.XtraEditors.LabelControl();
            this.lblAvailableBudget = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdBudget = new DevExpress.XtraGrid.GridControl();
            this.gvBudget = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllocatedBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommittedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainingBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerBottom = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdCommitmentDetail = new DevExpress.XtraGrid.GridControl();
            this.gvCommitmentDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPOContractNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVendorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommitmentValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommitmentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartBudgetAllocation = new DevExpress.XtraCharts.ChartControl();
            this.chartCommitmentConsumption = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlVarianceSummary)).BeginInit();
            this.pnlVarianceSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).BeginInit();
            this.splitContainerBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCommitmentDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCommitmentDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBudgetAllocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCommitmentConsumption)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiRefresh, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات مقارنة الموازنة مقابل الالتزامات (Budget vs Commitment)";

            this.bbiRefresh.Caption = "تحديث حسابات الالتزام";
            this.bbiExport.Caption = "تصدير تقرير المقارنة";

            // pnlVarianceSummary
            this.pnlVarianceSummary.Controls.Add(this.lblTotalBudget);
            this.pnlVarianceSummary.Controls.Add(this.lblTotalCommitment);
            this.pnlVarianceSummary.Controls.Add(this.lblAvailableBudget);
            this.pnlVarianceSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVarianceSummary.Location = new System.Drawing.Point(0, 30);
            this.pnlVarianceSummary.Name = "pnlVarianceSummary";
            this.pnlVarianceSummary.Size = new System.Drawing.Size(1200, 50);

            this.lblTotalBudget.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalBudget.Location = new System.Drawing.Point(950, 15);
            this.lblTotalBudget.Text = "إجمالي الموازنة (Budget): 105,000,000 SAR";

            this.lblTotalCommitment.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalCommitment.Location = new System.Drawing.Point(580, 15);
            this.lblTotalCommitment.Text = "إجمالي الالتزامات (Commitment): 68,000,000 SAR";

            this.lblAvailableBudget.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAvailableBudget.Location = new System.Drawing.Point(220, 15);
            this.lblAvailableBudget.Text = "الموازنة المتاحة للالتزام (Available): 37,000,000 SAR";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdBudget);
            this.splitContainerControlMain.Panel1.Text = "جدول الموازنة المخصصة حسب رموز التكلفة (Budget Grid)";
            this.splitContainerControlMain.Panel2.Controls.Add(this.splitContainerBottom);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل الالتزامات الرسم البياني لاستهلاك الموازنة";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 350;

            // grdBudget
            this.grdBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBudget.Location = new System.Drawing.Point(0, 0);
            this.grdBudget.MainView = this.gvBudget;
            this.grdBudget.Name = "grdBudget";
            this.grdBudget.Size = new System.Drawing.Size(1200, 350);
            this.grdBudget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvBudget });

            // gvBudget
            this.gvBudget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCostCode, this.colDescription, this.colAllocatedBudget,
                this.colCommittedAmount, this.colRemainingBudget
            });
            this.gvBudget.GridControl = this.grdBudget;
            this.gvBudget.Name = "gvBudget";
            this.gvBudget.OptionsView.ShowAutoFilterRow = true;
            this.gvBudget.OptionsView.ShowFooter = true;

            this.colCostCode.Caption = "رمز التكلفة (Cost Code)";
            this.colCostCode.FieldName = "CostCode";
            this.colCostCode.Visible = true;
            this.colCostCode.VisibleIndex = 0;

            this.colDescription.Caption = "وصف البند التكليفي";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;

            this.colAllocatedBudget.Caption = "الموازنة المعتمدة (Allocated Budget)";
            this.colAllocatedBudget.FieldName = "AllocatedBudget";
            this.colAllocatedBudget.Visible = true;
            this.colAllocatedBudget.VisibleIndex = 2;

            this.colCommittedAmount.Caption = "إجمالي الالتزامات (Committed Amount)";
            this.colCommittedAmount.FieldName = "CommittedAmount";
            this.colCommittedAmount.Visible = true;
            this.colCommittedAmount.VisibleIndex = 3;

            this.colRemainingBudget.Caption = "المتبقي غير الملتزم به (Remaining Budget)";
            this.colRemainingBudget.FieldName = "RemainingBudget";
            this.colRemainingBudget.Visible = true;
            this.colRemainingBudget.VisibleIndex = 4;

            // splitContainerBottom
            this.splitContainerBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBottom.Name = "splitContainerBottom";
            this.splitContainerBottom.Panel1.Controls.Add(this.grdCommitmentDetail);
            this.splitContainerBottom.Panel1.Text = "تفاصيل العقود وأوامر الشراء التابعة للرمز المحدد";
            this.splitContainerBottom.Panel2.Controls.Add(this.splitContainerCharts);
            this.splitContainerBottom.Panel2.Text = "مخطط توزيع الموازنة واستهلاك الالتزام";
            this.splitContainerBottom.Size = new System.Drawing.Size(1200, 310);
            this.splitContainerBottom.SplitterPosition = 600;

            // grdCommitmentDetail
            this.grdCommitmentDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCommitmentDetail.Location = new System.Drawing.Point(0, 0);
            this.grdCommitmentDetail.MainView = this.gvCommitmentDetail;
            this.grdCommitmentDetail.Name = "grdCommitmentDetail";
            this.grdCommitmentDetail.Size = new System.Drawing.Size(600, 310);
            this.grdCommitmentDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvCommitmentDetail });

            // gvCommitmentDetail
            this.gvCommitmentDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colPOContractNo, this.colVendorName, this.colCommitmentValue, this.colCommitmentStatus
            });
            this.gvCommitmentDetail.GridControl = this.grdCommitmentDetail;
            this.gvCommitmentDetail.Name = "gvCommitmentDetail";
            this.gvCommitmentDetail.OptionsView.ShowAutoFilterRow = true;

            this.colPOContractNo.Caption = "رقم العقد / PO";
            this.colPOContractNo.FieldName = "POContractNo";
            this.colPOContractNo.Visible = true;
            this.colPOContractNo.VisibleIndex = 0;

            this.colVendorName.Caption = "اسم المورد / المقاول";
            this.colVendorName.FieldName = "VendorName";
            this.colVendorName.Visible = true;
            this.colVendorName.VisibleIndex = 1;

            this.colCommitmentValue.Caption = "قيمة الالتزام المباشر";
            this.colCommitmentValue.FieldName = "CommitmentValue";
            this.colCommitmentValue.Visible = true;
            this.colCommitmentValue.VisibleIndex = 2;

            this.colCommitmentStatus.Caption = "حالة التنفيذ والاعتماد";
            this.colCommitmentStatus.FieldName = "CommitmentStatus";
            this.colCommitmentStatus.Visible = true;
            this.colCommitmentStatus.VisibleIndex = 3;

            // splitContainerCharts
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartBudgetAllocation);
            this.splitContainerCharts.Panel1.Text = "توزيع الموازنة";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartCommitmentConsumption);
            this.splitContainerCharts.Panel2.Text = "استهلاك الالتزامات";
            this.splitContainerCharts.Size = new System.Drawing.Size(590, 310);
            this.splitContainerCharts.SplitterPosition = 290;

            this.chartBudgetAllocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBudgetAllocation.Location = new System.Drawing.Point(0, 0);
            this.chartBudgetAllocation.Name = "chartBudgetAllocation";
            this.chartBudgetAllocation.Size = new System.Drawing.Size(290, 310);

            this.chartCommitmentConsumption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCommitmentConsumption.Location = new System.Drawing.Point(0, 0);
            this.chartCommitmentConsumption.Name = "chartCommitmentConsumption";
            this.chartCommitmentConsumption.Size = new System.Drawing.Size(290, 310);

            // ucBudgetVsCommitment
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlVarianceSummary);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucBudgetVsCommitment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlVarianceSummary)).EndInit();
            this.pnlVarianceSummary.ResumeLayout(false);
            this.pnlVarianceSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).EndInit();
            this.splitContainerBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCommitmentDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCommitmentDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBudgetAllocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCommitmentConsumption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlVarianceSummary;
        private DevExpress.XtraEditors.LabelControl lblTotalBudget;
        private DevExpress.XtraEditors.LabelControl lblTotalCommitment;
        private DevExpress.XtraEditors.LabelControl lblAvailableBudget;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdBudget;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colCostCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAllocatedBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colCommittedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainingBudget;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerBottom;
        private DevExpress.XtraGrid.GridControl grdCommitmentDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCommitmentDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colPOContractNo;
        private DevExpress.XtraGrid.Columns.GridColumn colVendorName;
        private DevExpress.XtraGrid.Columns.GridColumn colCommitmentValue;
        private DevExpress.XtraGrid.Columns.GridColumn colCommitmentStatus;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartBudgetAllocation;
        private DevExpress.XtraCharts.ChartControl chartCommitmentConsumption;
    }
}
