namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucCorrespondenceReports
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
            this.splitContainerControlMain.Panel1.Text = "قائمة تقارير إدارة المراسلات والبريد";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdReportPreview);
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlReportHeader);
            this.splitContainerControlMain.Panel2.Text = "معاينة التقرير الجداول المرفقة";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 750);
            this.splitContainerControlMain.SplitterPosition = 320;

            // lstReports
            this.lstReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstReports.Items.AddRange(new object[] {
                "سجل المراسلات والخطابات الواردة (Incoming Register)",
                "سجل المراسلات والخطابات الصادرة (Outgoing Register)",
                "تقرير معدل زمن الرد والسرعة (Response Time Report)",
                "تقرير التكليفات والإجراءات المعلقة (Pending Actions Report)",
                "سجل محاضر الاجتماعات الكامل (Meeting Minutes Register)",
                "تقرير التعاميم والنشرات الإدارية (Circular Register)",
                "تقرير مزامنة وسحب البريد (Email Synchronization Report)",
                "تقرير مصفوفة وقوائم التوزيع (Distribution Report)"
            });
            this.lstReports.Location = new System.Drawing.Point(0, 0);
            this.lstReports.Name = "lstReports";
            this.lstReports.Size = new System.Drawing.Size(320, 750);

            // pnlReportHeader
            this.pnlReportHeader.Controls.Add(this.lblSelectedReportTitle);
            this.pnlReportHeader.Controls.Add(this.btnPreview);
            this.pnlReportHeader.Controls.Add(this.btnPrint);
            this.pnlReportHeader.Controls.Add(this.btnExportExcel);
            this.pnlReportHeader.Controls.Add(this.btnExportPdf);
            this.pnlReportHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlReportHeader.Name = "pnlReportHeader";
            this.pnlReportHeader.Size = new System.Drawing.Size(870, 60);

            this.lblSelectedReportTitle.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedReportTitle.Location = new System.Drawing.Point(540, 18);
            this.lblSelectedReportTitle.Text = "سجل المراسلات والخطابات الواردة الشامل";

            this.btnPreview.Location = new System.Drawing.Point(390, 14);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 32);
            this.btnPreview.Text = "معاينة التقرير";

            this.btnPrint.Location = new System.Drawing.Point(280, 14);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 32);
            this.btnPrint.Text = "طباعة مباشرة";

            this.btnExportExcel.Location = new System.Drawing.Point(140, 14);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(130, 32);
            this.btnExportExcel.Text = "تصدير إلى Excel";

            this.btnExportPdf.Location = new System.Drawing.Point(10, 14);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(120, 32);
            this.btnExportPdf.Text = "تصدير إلى PDF";

            // grdReportPreview
            this.grdReportPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReportPreview.Location = new System.Drawing.Point(0, 60);
            this.grdReportPreview.MainView = this.gvReportPreview;
            this.grdReportPreview.Name = "grdReportPreview";
            this.grdReportPreview.Size = new System.Drawing.Size(870, 690);
            this.grdReportPreview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvReportPreview });

            // gvReportPreview
            this.gvReportPreview.GridControl = this.grdReportPreview;
            this.gvReportPreview.Name = "gvReportPreview";
            this.gvReportPreview.OptionsView.ShowAutoFilterRow = true;
            this.gvReportPreview.OptionsView.ShowFooter = true;

            // ucCorrespondenceReports
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "ucCorrespondenceReports";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
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
