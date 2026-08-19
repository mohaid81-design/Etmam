namespace Etmam
{
    partial class ucPlanningReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlStateBanner = new DevExpress.XtraEditors.PanelControl();
            lblStateBanner = new DevExpress.XtraEditors.LabelControl();
            svgStateBannerIcon = new DevExpress.XtraEditors.SvgImageBox();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();

            layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();

            splitContainerMain = new DevExpress.XtraEditors.SplitContainerControl();

            // Left Pane: Reports Selection & Filters
            pnlReportSelectionGroup = new DevExpress.XtraEditors.GroupControl();
            lstReports = new DevExpress.XtraEditors.ListBoxControl();

            cboProjectFilter = new DevExpress.XtraEditors.LookUpEdit();
            dtFromFilter = new DevExpress.XtraEditors.DateEdit();
            dtToFilter = new DevExpress.XtraEditors.DateEdit();

            btnPreviewReport = new DevExpress.XtraEditors.SimpleButton();
            btnPrintReport = new DevExpress.XtraEditors.SimpleButton();
            btnExportPdf = new DevExpress.XtraEditors.SimpleButton();
            btnExportExcel = new DevExpress.XtraEditors.SimpleButton();

            // Right Pane: Report Document Viewer Container
            pnlReportViewerContainer = new DevExpress.XtraEditors.GroupControl();
            lblViewerPlaceholder = new DevExpress.XtraEditors.LabelControl();
            svgReportIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splitContainerMain)).BeginInit();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pnlReportSelectionGroup)).BeginInit();
            pnlReportSelectionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(lstReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cboProjectFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtFromFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtFromFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtToFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtToFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlReportViewerContainer)).BeginInit();
            pnlReportViewerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgReportIcon)).BeginInit();
            SuspendLayout();

            // pnlStateBanner
            pnlStateBanner.Controls.Add(btnRetry);
            pnlStateBanner.Controls.Add(lblStateBanner);
            pnlStateBanner.Controls.Add(svgStateBannerIcon);
            pnlStateBanner.Dock = System.Windows.Forms.DockStyle.Top;
            pnlStateBanner.Location = new System.Drawing.Point(0, 0);
            pnlStateBanner.Name = "pnlStateBanner";
            pnlStateBanner.Size = new System.Drawing.Size(1200, 36);
            pnlStateBanner.TabIndex = 0;
            pnlStateBanner.Visible = false;

            lblStateBanner.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            lblStateBanner.Appearance.Options.UseFont = true;
            lblStateBanner.Location = new System.Drawing.Point(50, 8);
            lblStateBanner.Name = "lblStateBanner";
            lblStateBanner.Size = new System.Drawing.Size(200, 20);
            lblStateBanner.Text = "حالة مركز التقارير: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Report Selection Setup
            lstReports.Items.AddRange(new object[] {
                "الجدول الزمني الرئيسي (Master Schedule)",
                "تقرير الأنشطة والتسلسلات (Activity Report)",
                "تقرير المحطات الرئيسية (Milestone Report)",
                "تقرير نسب الإنجاز والتقدم (Progress Report)",
                "تقرير النظرة المستقبلي (Look Ahead Report)",
                "تقرير تحليل التأخيرات (Delay Analysis Report)",
                "تقرير توزيع واستخدام الموارد (Resource Report)",
                "تقرير مقارنة الخطوط المرجعية (Baseline Comparison Report)"
            });
            lstReports.Location = new System.Drawing.Point(10, 30);
            lstReports.Size = new System.Drawing.Size(320, 220);

            cboProjectFilter.Properties.NullText = "اختر المشروع للتقرير...";
            cboProjectFilter.Location = new System.Drawing.Point(10, 260);
            cboProjectFilter.Size = new System.Drawing.Size(320, 28);

            dtFromFilter.Location = new System.Drawing.Point(10, 300);
            dtFromFilter.Size = new System.Drawing.Size(155, 28);

            dtToFilter.Location = new System.Drawing.Point(175, 300);
            dtToFilter.Size = new System.Drawing.Size(155, 28);

            btnPreviewReport.Location = new System.Drawing.Point(10, 345);
            btnPreviewReport.Size = new System.Drawing.Size(155, 32);
            btnPreviewReport.Text = "معاينة التقرير";
            btnPreviewReport.Click += btnPreviewReport_Click;

            btnPrintReport.Location = new System.Drawing.Point(175, 345);
            btnPrintReport.Size = new System.Drawing.Size(155, 32);
            btnPrintReport.Text = "طباعة مباشرة";
            btnPrintReport.Click += btnPrintReport_Click;

            btnExportPdf.Location = new System.Drawing.Point(10, 385);
            btnExportPdf.Size = new System.Drawing.Size(155, 32);
            btnExportPdf.Text = "تصدير PDF";
            btnExportPdf.Click += btnExportPdf_Click;

            btnExportExcel.Location = new System.Drawing.Point(175, 385);
            btnExportExcel.Size = new System.Drawing.Size(155, 32);
            btnExportExcel.Text = "تصدير Excel";
            btnExportExcel.Click += btnExportExcel_Click;

            pnlReportSelectionGroup.Controls.Add(lstReports);
            pnlReportSelectionGroup.Controls.Add(cboProjectFilter);
            pnlReportSelectionGroup.Controls.Add(dtFromFilter);
            pnlReportSelectionGroup.Controls.Add(dtToFilter);
            pnlReportSelectionGroup.Controls.Add(btnPreviewReport);
            pnlReportSelectionGroup.Controls.Add(btnPrintReport);
            pnlReportSelectionGroup.Controls.Add(btnExportPdf);
            pnlReportSelectionGroup.Controls.Add(btnExportExcel);
            pnlReportSelectionGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlReportSelectionGroup.Text = "قائمة تقارير التخطيط والجدولة والفلترة";

            // Report Viewer Container Setup
            pnlReportViewerContainer.Controls.Add(lblViewerPlaceholder);
            pnlReportViewerContainer.Controls.Add(svgReportIcon);
            pnlReportViewerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlReportViewerContainer.Text = "لوحة استعراض التقرير المباشر (Report Print Preview Area)";

            lblViewerPlaceholder.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Italic);
            lblViewerPlaceholder.Appearance.Options.UseFont = true;
            lblViewerPlaceholder.Location = new System.Drawing.Point(60, 60);
            lblViewerPlaceholder.Text = "حدد التقرير المطلوب من القائمة وانقر على 'معاينة التقرير' لاستعراض الشاشة هنا.";

            svgReportIcon.Location = new System.Drawing.Point(20, 55);
            svgReportIcon.Size = new System.Drawing.Size(32, 32);

            // Split Container
            splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerMain.Panel1.Controls.Add(pnlReportSelectionGroup);
            splitContainerMain.Panel2.Controls.Add(pnlReportViewerContainer);
            splitContainerMain.SplitterPosition = 350;

            // Layout Control Main
            layoutControlMain.Controls.Add(splitContainerMain);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 36);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 730);

            // ucPlanningReports
            Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControlMain);
            Controls.Add(pnlStateBanner);
            Name = "ucPlanningReports";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1200, 766);

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).EndInit();
            layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splitContainerMain)).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pnlReportSelectionGroup)).EndInit();
            pnlReportSelectionGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(lstReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cboProjectFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtFromFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtFromFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtToFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtToFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pnlReportViewerContainer)).EndInit();
            pnlReportViewerContainer.ResumeLayout(false);
            pnlReportViewerContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(svgReportIcon)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlStateBanner;
        private DevExpress.XtraEditors.LabelControl lblStateBanner;
        private DevExpress.XtraEditors.SvgImageBox svgStateBannerIcon;
        private DevExpress.XtraEditors.SimpleButton btnRetry;

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;

        private DevExpress.XtraEditors.SplitContainerControl splitContainerMain;

        private DevExpress.XtraEditors.GroupControl pnlReportSelectionGroup;
        private DevExpress.XtraEditors.ListBoxControl lstReports;
        private DevExpress.XtraEditors.LookUpEdit cboProjectFilter;
        private DevExpress.XtraEditors.DateEdit dtFromFilter;
        private DevExpress.XtraEditors.DateEdit dtToFilter;
        private DevExpress.XtraEditors.SimpleButton btnPreviewReport;
        private DevExpress.XtraEditors.SimpleButton btnPrintReport;
        private DevExpress.XtraEditors.SimpleButton btnExportPdf;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;

        private DevExpress.XtraEditors.GroupControl pnlReportViewerContainer;
        private DevExpress.XtraEditors.LabelControl lblViewerPlaceholder;
        private DevExpress.XtraEditors.SvgImageBox svgReportIcon;
    }
}
