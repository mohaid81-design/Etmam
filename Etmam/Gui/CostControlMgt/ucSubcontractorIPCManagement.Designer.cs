namespace Etmam.Gui.CostControlMgt
{
    partial class ucSubcontractorIPCManagement
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
            this.bbiNewSubIpc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApproveSubIpc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblHeaderInfo = new DevExpress.XtraEditors.LabelControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblCurrent = new DevExpress.XtraEditors.LabelControl();
            this.lblPrevious = new DevExpress.XtraEditors.LabelControl();
            this.lblRetention = new DevExpress.XtraEditors.LabelControl();
            this.lblNet = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdSubcontractIPC = new DevExpress.XtraGrid.GridControl();
            this.gvSubcontractIPC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabSubDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tpDeductions = new DevExpress.XtraTab.XtraTabPage();
            this.tpRetention = new DevExpress.XtraTab.XtraTabPage();
            this.tpVariations = new DevExpress.XtraTab.XtraTabPage();
            this.tpBackCharges = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontractIPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubcontractIPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSubDetails)).BeginInit();
            this.tabSubDetails.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewSubIpc, this.bbiApproveSubIpc, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewSubIpc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiApproveSubIpc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات مستخلصات مقاولي الباطن Subcontractor IPC Management";

            this.bbiNewSubIpc.Caption = "مستخلص مقاول باطن جديد";
            this.bbiApproveSubIpc.Caption = "اعتماد المستخلص المالي";
            this.bbiExport.Caption = "تصدير مستخلصات مقاولي الباطن";

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblHeaderInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 35);

            this.lblHeaderInfo.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderInfo.Location = new System.Drawing.Point(10, 8);
            this.lblHeaderInfo.Text = "المقاول: شركة الأساسات الوطنية | رقم العقد: SUB-2026-012 | الفترة: أغسطس 2026";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblCurrent);
            this.pnlCards.Controls.Add(this.lblPrevious);
            this.pnlCards.Controls.Add(this.lblRetention);
            this.pnlCards.Controls.Add(this.lblNet);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 65);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblCurrent.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCurrent.Location = new System.Drawing.Point(1000, 15);
            this.lblCurrent.Text = "الجاري (Current): 850,000 SAR";

            this.lblPrevious.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPrevious.Location = new System.Drawing.Point(720, 15);
            this.lblPrevious.Text = "السابق (Previous): 3,200,000 SAR";

            this.lblRetention.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRetention.Location = new System.Drawing.Point(460, 15);
            this.lblRetention.Text = "الاستقطاعات والاحتجازات: -112,000 SAR";

            this.lblNet.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNet.Location = new System.Drawing.Point(150, 15);
            this.lblNet.Text = "الصافي المعتمد للصرف: 738,000 SAR";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 115);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdSubcontractIPC);
            this.splitContainerControlMain.Panel1.Text = "بنود الأنشطة والكميات المسجلة بالمستخلص";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabSubDetails);
            this.splitContainerControlMain.Panel2.Text = "تفاصيل خصومات المواد والـ Back Charges والـ Workflow";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 635);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdSubcontractIPC
            this.grdSubcontractIPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSubcontractIPC.Location = new System.Drawing.Point(0, 0);
            this.grdSubcontractIPC.MainView = this.gvSubcontractIPC;
            this.grdSubcontractIPC.Name = "grdSubcontractIPC";
            this.grdSubcontractIPC.Size = new System.Drawing.Size(1200, 380);
            this.grdSubcontractIPC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvSubcontractIPC });

            // gvSubcontractIPC
            this.gvSubcontractIPC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colActivity, this.colQty, this.colRate, this.colAmount
            });
            this.gvSubcontractIPC.GridControl = this.grdSubcontractIPC;
            this.gvSubcontractIPC.Name = "gvSubcontractIPC";
            this.gvSubcontractIPC.OptionsView.ShowAutoFilterRow = true;
            this.gvSubcontractIPC.OptionsView.ShowFooter = true;

            this.colActivity.Caption = "النشاط / بند العقد الفرعي (Activity)";
            this.colActivity.FieldName = "Activity";
            this.colActivity.Visible = true;
            this.colActivity.VisibleIndex = 0;

            this.colQty.Caption = "الكمية المنفذة المعتمدة";
            this.colQty.FieldName = "Qty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 1;

            this.colRate.Caption = "فئة السعر (Rate)";
            this.colRate.FieldName = "Rate";
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 2;

            this.colAmount.Caption = "المبلغ الإجمالي (Amount)";
            this.colAmount.FieldName = "Amount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;

            // tabSubDetails
            this.tabSubDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSubDetails.Location = new System.Drawing.Point(0, 0);
            this.tabSubDetails.Name = "tabSubDetails";
            this.tabSubDetails.SelectedTabPage = this.tpDeductions;
            this.tabSubDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpDeductions,
                this.tpRetention,
                this.tpVariations,
                this.tpBackCharges,
                this.tpWorkflow
            });
            this.tabSubDetails.Size = new System.Drawing.Size(1200, 245);

            this.tpDeductions.Text = "خصومات الدفعات المقدمة والمعدات (Deductions)";
            this.tpRetention.Text = "نسبة الضمان المحتجزة (Retention)";
            this.tpVariations.Text = "أوامر التغيير والزيادات (Variations)";
            this.tpBackCharges.Text = "تكاليف ومخالفات مسجلة عليه (Back Charges)";
            this.tpWorkflow.Text = "مسار التوقيعات والاعتماد (Workflow)";

            // ucSubcontractorIPCManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucSubcontractorIPCManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontractIPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubcontractIPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSubDetails)).EndInit();
            this.tabSubDetails.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewSubIpc;
        private DevExpress.XtraBars.BarButtonItem bbiApproveSubIpc;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblHeaderInfo;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblCurrent;
        private DevExpress.XtraEditors.LabelControl lblPrevious;
        private DevExpress.XtraEditors.LabelControl lblRetention;
        private DevExpress.XtraEditors.LabelControl lblNet;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdSubcontractIPC;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSubcontractIPC;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraTab.XtraTabControl tabSubDetails;
        private DevExpress.XtraTab.XtraTabPage tpDeductions;
        private DevExpress.XtraTab.XtraTabPage tpRetention;
        private DevExpress.XtraTab.XtraTabPage tpVariations;
        private DevExpress.XtraTab.XtraTabPage tpBackCharges;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
    }
}
