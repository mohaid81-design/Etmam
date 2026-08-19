namespace Etmam.Gui.ContractMgt
{
    partial class ucContractReports
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
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstReports = new DevExpress.XtraEditors.ListBoxControl();
            this.pnlReportHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblSelectedReportTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportPdf = new DevExpress.XtraEditors.SimpleButton();
            this.grdReportPreview = new DevExpress.XtraGrid.GridControl();
            this.gvReportPreview = new DevExpress.XtraGrid.Views.Grid.GridView();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlReportHeader)).BeginInit();
            this.pnlReportHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportPreview)).BeginInit();
            this.SuspendLayout();

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.lstReports);
            this.splitContainerControlMain.Panel1.Text = "قائمة التقارير";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdReportPreview);
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlReportHeader);
            this.splitContainerControlMain.Panel2.Text = "معاينة التقرير";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 750);
            this.splitContainerControlMain.SplitterPosition = 300;

            // lstReports
            this.lstReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstReports.Items.AddRange(new object[] {
                "سجل العقود الشامل (Contract Register)",
                "تقرير الالتزامات التعاقدية (Obligations Report)",
                "تقرير أوامر التغيير (Variation Report)",
                "تقرير المطالبات والنزاعات (Claims Report)",
                "تقرير تمديد الوقت (EOT Report)",
                "تقرير المستخلصات والدفعات (Payment Certificate Report)",
                "تقرير المحتجزات النقدية (Retention Report)",
                "تقرير الخطابات والضمانات البنكية (Guarantee Report)",
                "تقرير الإغلاق النهائي لعقود المشاريع (Contract Closeout Report)"
            });
            this.lstReports.Location = new System.Drawing.Point(0, 0);
            this.lstReports.Name = "lstReports";
            this.lstReports.Size = new System.Drawing.Size(300, 750);

            // pnlReportHeader
            this.pnlReportHeader.Controls.Add(this.lblSelectedReportTitle);
            this.pnlReportHeader.Controls.Add(this.btnPreview);
            this.pnlReportHeader.Controls.Add(this.btnPrint);
            this.pnlReportHeader.Controls.Add(this.btnExportExcel);
            this.pnlReportHeader.Controls.Add(this.btnExportPdf);
            this.pnlReportHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlReportHeader.Name = "pnlReportHeader";
            this.pnlReportHeader.Size = new System.Drawing.Size(890, 60);

            this.lblSelectedReportTitle.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedReportTitle.Location = new System.Drawing.Point(550, 18);
            this.lblSelectedReportTitle.Text = "تقرير سجل العقود الشامل";

            this.btnPreview.Location = new System.Drawing.Point(400, 14);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 32);
            this.btnPreview.Text = "معاينة التقرير";

            this.btnPrint.Location = new System.Drawing.Point(290, 14);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 32);
            this.btnPrint.Text = "طباعة مباشرة";

            this.btnExportExcel.Location = new System.Drawing.Point(150, 14);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(130, 32);
            this.btnExportExcel.Text = "تصدير إلى Excel";

            this.btnExportPdf.Location = new System.Drawing.Point(20, 14);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(120, 32);
            this.btnExportPdf.Text = "تصدير إلى PDF";

            // grdReportPreview
            this.grdReportPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReportPreview.Location = new System.Drawing.Point(0, 60);
            this.grdReportPreview.MainView = this.gvReportPreview;
            this.grdReportPreview.Name = "grdReportPreview";
            this.grdReportPreview.Size = new System.Drawing.Size(890, 690);
            this.grdReportPreview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvReportPreview });

            // gvReportPreview
            this.gvReportPreview.GridControl = this.grdReportPreview;
            this.gvReportPreview.Name = "gvReportPreview";
            this.gvReportPreview.OptionsView.ShowAutoFilterRow = true;
            this.gvReportPreview.OptionsView.ShowFooter = true;

            // ucContractReports
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "ucContractReports";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlReportHeader)).EndInit();
            this.pnlReportHeader.ResumeLayout(false);
            this.pnlReportHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportPreview)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraEditors.ListBoxControl lstReports;
        private DevExpress.XtraEditors.PanelControl pnlReportHeader;
        private DevExpress.XtraEditors.LabelControl lblSelectedReportTitle;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnExportPdf;
        private DevExpress.XtraGrid.GridControl grdReportPreview;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReportPreview;
    }
}
