namespace Etmam
{
    partial class ucBudgetReports
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBudgetReports));
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiPreview = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            // Left: Report List
            pnlLeft = new DevExpress.XtraEditors.PanelControl();
            grpReportCategories = new DevExpress.XtraEditors.GroupControl();
            lstReports = new DevExpress.XtraEditors.ListBoxControl();
            // Right: Parameters + Preview
            pnlRight = new DevExpress.XtraEditors.PanelControl();
            grpParameters = new DevExpress.XtraEditors.GroupControl();
            lblProject = new DevExpress.XtraEditors.LabelControl(); cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            lblDateFrom = new DevExpress.XtraEditors.LabelControl(); dtDateFrom = new DevExpress.XtraEditors.DateEdit();
            lblDateTo = new DevExpress.XtraEditors.LabelControl(); dtDateTo = new DevExpress.XtraEditors.DateEdit();
            lblCostCenter = new DevExpress.XtraEditors.LabelControl(); cboCostCenter = new DevExpress.XtraEditors.ComboBoxEdit();
            lblGroupBy = new DevExpress.XtraEditors.LabelControl(); cboGroupBy = new DevExpress.XtraEditors.ComboBoxEdit();
            btnGenerateReport = new DevExpress.XtraEditors.SimpleButton();
            grpPreview = new DevExpress.XtraEditors.GroupControl();
            documentViewer = new DevExpress.XtraReports.UI.XtraReport();
            pnlPreviewPlaceholder = new DevExpress.XtraEditors.PanelControl();
            lblPreviewMsg = new DevExpress.XtraEditors.LabelControl();
            svgPreviewIcon = new DevExpress.XtraEditors.SvgImageBox();
            // States
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl(); lblLoadingText = new DevExpress.XtraEditors.LabelControl(); svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl(); btnRetry = new DevExpress.XtraEditors.SimpleButton(); lblErrorText = new DevExpress.XtraEditors.LabelControl(); svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)barManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit(); splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLeft).BeginInit(); pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpReportCategories).BeginInit(); grpReportCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lstReports).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlRight).BeginInit(); pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpParameters).BeginInit(); grpParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboCostCenter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboGroupBy.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpPreview).BeginInit(); grpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlPreviewPlaceholder).BeginInit(); pnlPreviewPlaceholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgPreviewIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit(); pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit(); pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain });
            
            barManagerMain.Form = this; barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiPreview, bbiPrint, bbiExportExcel, bbiExportPdf });
            barManagerMain.MainMenu = barMain; barManagerMain.MaxItemId = 4; barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barMain.BarName = "شريط أدوات التقارير"; barMain.DockCol = 0; barMain.DockRow = 0; barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPreview, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportPdf, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
            });
            barMain.OptionsBar.AllowQuickCustomization = false; barMain.OptionsBar.DrawDragBorder = false; barMain.OptionsBar.MinHeight = 34; barMain.OptionsBar.UseWholeRow = true; barMain.Text = "شريط أدوات التقارير";
            bbiPreview.Caption = "معاينة"; bbiPreview.Id = 0; bbiPreview.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiView.ImageOptions.SvgImage"); bbiPreview.Name = "bbiPreview"; bbiPreview.ItemClick += bbiPreview_ItemClick;
            bbiPrint.Caption = "طباعة"; bbiPrint.Id = 1; bbiPrint.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiPrint.ImageOptions.SvgImage"); bbiPrint.Name = "bbiPrint"; bbiPrint.ItemClick += bbiPrint_ItemClick;
            bbiExportExcel.Caption = "Excel"; bbiExportExcel.Id = 2; bbiExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExportExcel.ImageOptions.SvgImage"); bbiExportExcel.Name = "bbiExportExcel"; bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            bbiExportPdf.Caption = "PDF"; bbiExportPdf.Id = 3; bbiExportPdf.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiPrint.ImageOptions.SvgImage"); bbiExportPdf.Name = "bbiExportPdf"; bbiExportPdf.ItemClick += bbiExportPdf_ItemClick;
            barDockControlTop.CausesValidation = false; barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top; barDockControlTop.Location = new System.Drawing.Point(0, 0); barDockControlTop.Manager = barManagerMain; barDockControlTop.Size = new System.Drawing.Size(1366, 34);
            barDockControlBottom.CausesValidation = false; barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom; barDockControlBottom.Location = new System.Drawing.Point(0, 902); barDockControlBottom.Manager = barManagerMain; barDockControlBottom.Size = new System.Drawing.Size(1366, 0);
            barDockControlLeft.CausesValidation = false; barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left; barDockControlLeft.Location = new System.Drawing.Point(0, 34); barDockControlLeft.Manager = barManagerMain; barDockControlLeft.Size = new System.Drawing.Size(0, 868);
            barDockControlRight.CausesValidation = false; barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right; barDockControlRight.Location = new System.Drawing.Point(1366, 34); barDockControlRight.Manager = barManagerMain; barDockControlRight.Size = new System.Drawing.Size(0, 868);

            // SplitMain
            splitMain.Dock = System.Windows.Forms.DockStyle.Fill; splitMain.Location = new System.Drawing.Point(0, 34); splitMain.Name = "splitMain";
            splitMain.Panel1.Controls.Add(pnlLeft); splitMain.Panel2.Controls.Add(pnlRight);
            splitMain.Size = new System.Drawing.Size(1366, 868); splitMain.SplitterPosition = 260; splitMain.TabIndex = 0;

            // Left panel
            pnlLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlLeft.Controls.Add(grpReportCategories); pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill; pnlLeft.Name = "pnlLeft";
            grpReportCategories.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpReportCategories.AppearanceCaption.Options.UseFont = true;
            grpReportCategories.Controls.Add(lstReports); grpReportCategories.Dock = System.Windows.Forms.DockStyle.Fill; grpReportCategories.Name = "grpReportCategories"; grpReportCategories.Text = "قائمة التقارير";
            lstReports.Appearance.Font = new System.Drawing.Font("Cairo", 9F); lstReports.Appearance.Options.UseFont = true;
            lstReports.Dock = System.Windows.Forms.DockStyle.Fill; lstReports.Name = "lstReports";
            lstReports.Items.AddRange(new object[] {
                "تقرير الموازنة التفصيلي",
                "ملخص الموازنة حسب CBS",
                "مقارنة الموازنة والفعلي",
                "تقرير التدفق النقدي",
                "تقرير مؤشرات EVM",
                "تقرير انحراف التكلفة",
                "سجل مراجعات الموازنة",
                "تقرير الموازنة حسب القسم",
                "تقرير الالتزامات والفعليات",
                "تقرير ملخص المشروع"
            });
            lstReports.SelectedIndexChanged += lstReports_SelectedIndexChanged;

            // Right panel
            pnlRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlRight.Controls.Add(grpPreview); pnlRight.Controls.Add(grpParameters); pnlRight.Dock = System.Windows.Forms.DockStyle.Fill; pnlRight.Name = "pnlRight";

            // Parameters
            grpParameters.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpParameters.AppearanceCaption.Options.UseFont = true;
            grpParameters.Controls.AddRange(new System.Windows.Forms.Control[] { lblProject, cboProject, lblDateFrom, dtDateFrom, lblDateTo, dtDateTo, lblCostCenter, cboCostCenter, lblGroupBy, cboGroupBy, btnGenerateReport });
            grpParameters.Dock = System.Windows.Forms.DockStyle.Top; grpParameters.Location = new System.Drawing.Point(0, 0); grpParameters.Name = "grpParameters"; grpParameters.Size = new System.Drawing.Size(1106, 120); grpParameters.Text = "معاملات التقرير";
            lblProject.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblProject.Appearance.Options.UseFont = true; lblProject.Location = new System.Drawing.Point(940, 25); lblProject.Name = "lblProject"; lblProject.Text = "المشروع:";
            cboProject.Location = new System.Drawing.Point(720, 45); cboProject.Name = "cboProject"; cboProject.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); cboProject.Properties.Appearance.Options.UseFont = true; cboProject.Size = new System.Drawing.Size(215, 30);
            lblDateFrom.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblDateFrom.Appearance.Options.UseFont = true; lblDateFrom.Location = new System.Drawing.Point(710, 25); lblDateFrom.Name = "lblDateFrom"; lblDateFrom.Text = "من:";
            dtDateFrom.Location = new System.Drawing.Point(545, 45); dtDateFrom.Name = "dtDateFrom"; dtDateFrom.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); dtDateFrom.Properties.Appearance.Options.UseFont = true; dtDateFrom.Size = new System.Drawing.Size(160, 30);
            lblDateTo.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblDateTo.Appearance.Options.UseFont = true; lblDateTo.Location = new System.Drawing.Point(535, 25); lblDateTo.Name = "lblDateTo"; lblDateTo.Text = "إلى:";
            dtDateTo.Location = new System.Drawing.Point(375, 45); dtDateTo.Name = "dtDateTo"; dtDateTo.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); dtDateTo.Properties.Appearance.Options.UseFont = true; dtDateTo.Size = new System.Drawing.Size(155, 30);
            lblCostCenter.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblCostCenter.Appearance.Options.UseFont = true; lblCostCenter.Location = new System.Drawing.Point(365, 25); lblCostCenter.Name = "lblCostCenter"; lblCostCenter.Text = "مركز التكلفة:";
            cboCostCenter.Location = new System.Drawing.Point(195, 45); cboCostCenter.Name = "cboCostCenter"; cboCostCenter.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); cboCostCenter.Properties.Appearance.Options.UseFont = true; cboCostCenter.Size = new System.Drawing.Size(165, 30);
            lblGroupBy.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblGroupBy.Appearance.Options.UseFont = true; lblGroupBy.Location = new System.Drawing.Point(185, 25); lblGroupBy.Name = "lblGroupBy"; lblGroupBy.Text = "تجميع حسب:";
            cboGroupBy.Location = new System.Drawing.Point(25, 45); cboGroupBy.Name = "cboGroupBy"; cboGroupBy.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); cboGroupBy.Properties.Appearance.Options.UseFont = true; cboGroupBy.Size = new System.Drawing.Size(155, 30);
            cboGroupBy.Properties.Items.AddRange(new object[] { "بند التكلفة", "القسم", "المرحلة", "الشهر" });
            btnGenerateReport.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); btnGenerateReport.Appearance.Options.UseFont = true;
            btnGenerateReport.Location = new System.Drawing.Point(940, 78); btnGenerateReport.Name = "btnGenerateReport"; btnGenerateReport.Size = new System.Drawing.Size(140, 34); btnGenerateReport.Text = "توليد التقرير"; btnGenerateReport.Click += lstReports_SelectedIndexChanged;

            // Preview area
            grpPreview.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpPreview.AppearanceCaption.Options.UseFont = true;
            grpPreview.Controls.Add(pnlPreviewPlaceholder); grpPreview.Dock = System.Windows.Forms.DockStyle.Fill; grpPreview.Location = new System.Drawing.Point(0, 120); grpPreview.Name = "grpPreview"; grpPreview.Text = "معاينة التقرير";
            pnlPreviewPlaceholder.Controls.Add(svgPreviewIcon); pnlPreviewPlaceholder.Controls.Add(lblPreviewMsg);
            pnlPreviewPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill; pnlPreviewPlaceholder.Name = "pnlPreviewPlaceholder";
            svgPreviewIcon.Location = new System.Drawing.Point(511, 180); svgPreviewIcon.Name = "svgPreviewIcon"; svgPreviewIcon.Size = new System.Drawing.Size(80, 80); svgPreviewIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiView.ImageOptions.SvgImage");
            lblPreviewMsg.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblPreviewMsg.Appearance.Options.UseFont = true;
            lblPreviewMsg.Appearance.Options.UseTextOptions = true; lblPreviewMsg.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblPreviewMsg.Location = new System.Drawing.Point(390, 280); lblPreviewMsg.Name = "lblPreviewMsg"; lblPreviewMsg.Size = new System.Drawing.Size(320, 26); lblPreviewMsg.Text = "اختر تقريراً من القائمة ثم اضغط «توليد التقرير»";

            // States
            pnlLoadingState.Controls.Add(lblLoadingText); pnlLoadingState.Controls.Add(svgLoadingIcon); pnlLoadingState.Dock = System.Windows.Forms.DockStyle.Fill; pnlLoadingState.Name = "pnlLoadingState"; pnlLoadingState.Visible = false;
            lblLoadingText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblLoadingText.Appearance.Options.UseFont = true; lblLoadingText.Location = new System.Drawing.Point(543, 310); lblLoadingText.Name = "lblLoadingText"; lblLoadingText.Text = "جاري توليد التقرير...";
            svgLoadingIcon.Location = new System.Drawing.Point(651, 210); svgLoadingIcon.Name = "svgLoadingIcon"; svgLoadingIcon.Size = new System.Drawing.Size(64, 64); svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            pnlErrorState.Controls.Add(btnRetry); pnlErrorState.Controls.Add(lblErrorText); pnlErrorState.Controls.Add(svgErrorIcon); pnlErrorState.Dock = System.Windows.Forms.DockStyle.Fill; pnlErrorState.Name = "pnlErrorState"; pnlErrorState.Visible = false;
            lblErrorText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblErrorText.Appearance.Options.UseFont = true; lblErrorText.Location = new System.Drawing.Point(543, 290); lblErrorText.Name = "lblErrorText"; lblErrorText.Text = "حدث خطأ أثناء توليد التقرير";
            svgErrorIcon.Location = new System.Drawing.Point(651, 190); svgErrorIcon.Name = "svgErrorIcon"; svgErrorIcon.Size = new System.Drawing.Size(64, 64); svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            btnRetry.Appearance.Font = new System.Drawing.Font("Cairo", 9F); btnRetry.Appearance.Options.UseFont = true; btnRetry.Location = new System.Drawing.Point(633, 330); btnRetry.Name = "btnRetry"; btnRetry.Size = new System.Drawing.Size(100, 34); btnRetry.Text = "إعادة المحاولة"; btnRetry.Click += btnRetry_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F); AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(splitMain); Controls.Add(pnlLoadingState); Controls.Add(pnlErrorState);
            Controls.Add(barDockControlLeft); Controls.Add(barDockControlRight); Controls.Add(barDockControlBottom); Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5); Name = "ucBudgetReports"; RightToLeft = System.Windows.Forms.RightToLeft.Yes; Size = new System.Drawing.Size(1366, 902);

            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit(); splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlLeft).EndInit(); pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpReportCategories).EndInit(); grpReportCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lstReports).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlRight).EndInit(); pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpParameters).EndInit(); grpParameters.ResumeLayout(false); grpParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cboProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboCostCenter.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboGroupBy.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpPreview).EndInit(); grpPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlPreviewPlaceholder).EndInit(); pnlPreviewPlaceholder.ResumeLayout(false); pnlPreviewPlaceholder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgPreviewIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit(); pnlLoadingState.ResumeLayout(false); pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit(); pnlErrorState.ResumeLayout(false); pnlErrorState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarDockControl barDockControlTop, barDockControlBottom, barDockControlLeft, barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiPreview, bbiPrint, bbiExportExcel, bbiExportPdf;
        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraEditors.PanelControl pnlLeft;
        private DevExpress.XtraEditors.GroupControl grpReportCategories;
        private DevExpress.XtraEditors.ListBoxControl lstReports;
        private DevExpress.XtraEditors.PanelControl pnlRight;
        private DevExpress.XtraEditors.GroupControl grpParameters;
        private DevExpress.XtraEditors.LabelControl lblProject, lblDateFrom, lblDateTo, lblCostCenter, lblGroupBy;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject, cboCostCenter, cboGroupBy;
        private DevExpress.XtraEditors.DateEdit dtDateFrom, dtDateTo;
        private DevExpress.XtraEditors.SimpleButton btnGenerateReport;
        private DevExpress.XtraEditors.GroupControl grpPreview;
        private DevExpress.XtraReports.UI.XtraReport documentViewer;
        private DevExpress.XtraEditors.PanelControl pnlPreviewPlaceholder;
        private DevExpress.XtraEditors.LabelControl lblPreviewMsg;
        private DevExpress.XtraEditors.SvgImageBox svgPreviewIcon;
        private DevExpress.XtraEditors.PanelControl pnlLoadingState, pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon, svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText, lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}

