namespace Etmam
{
    partial class ucBudgetList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBudgetList));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();

            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiNewBudget = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiCopy = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiImport = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bbiCompare = new DevExpress.XtraBars.BarButtonItem();
            bbiApprove = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiRecordCount = new DevExpress.XtraBars.BarStaticItem();
            sbiLastRefresh = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            pnlStateBanner = new DevExpress.XtraEditors.PanelControl();
            lblStateBanner = new DevExpress.XtraEditors.LabelControl();
            svgStateBannerIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            pnlKpiTotal = new DevExpress.XtraEditors.PanelControl();
            lblKpiTotalValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiTotalTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiApproved = new DevExpress.XtraEditors.PanelControl();
            lblKpiApprovedValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiApprovedTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiDraft = new DevExpress.XtraEditors.PanelControl();
            lblKpiDraftValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiDraftTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiActiveRevisions = new DevExpress.XtraEditors.PanelControl();
            lblKpiActiveRevisionsValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiActiveRevisionsTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKpiTotalCost = new DevExpress.XtraEditors.PanelControl();
            lblKpiTotalCostValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiTotalCostTitle = new DevExpress.XtraEditors.LabelControl();
            pnlSearchFilters = new DevExpress.XtraEditors.PanelControl();
            btnSaveFilter = new DevExpress.XtraEditors.SimpleButton();
            btnClearFilters = new DevExpress.XtraEditors.SimpleButton();
            btnSearch = new DevExpress.XtraEditors.SimpleButton();
            dtDateTo = new DevExpress.XtraEditors.DateEdit();
            lblDateRangeSep = new DevExpress.XtraEditors.LabelControl();
            dtDateFrom = new DevExpress.XtraEditors.DateEdit();
            lblDateRange = new DevExpress.XtraEditors.LabelControl();
            cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            cboBudgetType = new DevExpress.XtraEditors.ComboBoxEdit();
            lblBudgetType = new DevExpress.XtraEditors.LabelControl();
            cboRevision = new DevExpress.XtraEditors.ComboBoxEdit();
            lblRevision = new DevExpress.XtraEditors.LabelControl();
            lueProject = new DevExpress.XtraEditors.LookUpEdit();
            lblProject = new DevExpress.XtraEditors.LabelControl();
            cboBranch = new DevExpress.XtraEditors.ComboBoxEdit();
            lblBranch = new DevExpress.XtraEditors.LabelControl();
            cboCompany = new DevExpress.XtraEditors.ComboBoxEdit();
            lblCompany = new DevExpress.XtraEditors.LabelControl();
            grdBudget = new DevExpress.XtraGrid.GridControl();
            gvBudget = new DevExpress.XtraGrid.Views.Grid.GridView();
            colBudgetCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colBudgetName = new DevExpress.XtraGrid.Columns.GridColumn();
            colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            colOriginalBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrentBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            colActual = new DevExpress.XtraGrid.Columns.GridColumn();
            colForecast = new DevExpress.XtraGrid.Columns.GridColumn();
            colVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colApprovedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastModified = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlSummary = new DevExpress.XtraEditors.PanelControl();
            lblSummaryTotalBudget = new DevExpress.XtraEditors.LabelControl();
            lblSummaryActual = new DevExpress.XtraEditors.LabelControl();
            lblSummaryRecordCount = new DevExpress.XtraEditors.LabelControl();
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            lblLoadingText = new DevExpress.XtraEditors.LabelControl();
            svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            lblEmptyText = new DevExpress.XtraEditors.LabelControl();
            svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();
            lblErrorText = new DevExpress.XtraEditors.LabelControl();
            svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)barManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlStateBanner).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgStateBannerIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit();
            pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiTotal).BeginInit(); pnlKpiTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiApproved).BeginInit(); pnlKpiApproved.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiDraft).BeginInit(); pnlKpiDraft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActiveRevisions).BeginInit(); pnlKpiActiveRevisions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiTotalCost).BeginInit(); pnlKpiTotalCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSearchFilters).BeginInit();
            pnlSearchFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboBudgetType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboRevision.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboBranch.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboCompany.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlSummary).BeginInit();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();

            // ── barManagerMain ────────────────────────────────────────────
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNewBudget, bbiEdit, bbiCopy, bbiDelete, bbiImport, bbiExportExcel, bbiCompare, bbiApprove, bbiPrint, bbiRefresh, sbiRecordCount, sbiLastRefresh });
            barManagerMain.MainMenu = barMain;
            barManagerMain.MaxItemId = 12;
            barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerMain.StatusBar = barStatus;
            //
            // barMain
            //
            barMain.BarName = "شريط أدوات قائمة الموازنات";
            barMain.DockCol = 0; barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[]
            {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNewBudget, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCopy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiImport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCompare, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiApprove, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
            });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.MinHeight = 34;
            barMain.OptionsBar.MultiLine = true;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "شريط أدوات قائمة الموازنات";
            // Toolbar button items
            SetupBarButton(bbiNewBudget, "bbiNewBudget", "موازنة جديدة", 0, resources, "bbiNewBudget.ImageOptions.SvgImage", bbiNewBudget_ItemClick);
            SetupBarButton(bbiEdit, "bbiEdit", "تعديل", 1, resources, "bbiEdit.ImageOptions.SvgImage", bbiEdit_ItemClick);
            SetupBarButton(bbiCopy, "bbiCopy", "نسخ", 2, resources, "bbiCopy.ImageOptions.SvgImage", bbiCopy_ItemClick);
            SetupBarButton(bbiDelete, "bbiDelete", "حذف", 3, resources, "bbiDelete.ImageOptions.SvgImage", bbiDelete_ItemClick);
            SetupBarButton(bbiImport, "bbiImport", "استيراد", 4, resources, "bbiImport.ImageOptions.SvgImage", bbiImport_ItemClick);
            SetupBarButton(bbiExportExcel, "bbiExportExcel", "تصدير Excel", 5, resources, "bbiExportExcel.ImageOptions.SvgImage", bbiExportExcel_ItemClick);
            SetupBarButton(bbiCompare, "bbiCompare", "مقارنة", 6, resources, "bbiCompare.ImageOptions.SvgImage", bbiCompare_ItemClick);
            SetupBarButton(bbiApprove, "bbiApprove", "اعتماد", 7, resources, "bbiApprove.ImageOptions.SvgImage", bbiApprove_ItemClick);
            SetupBarButton(bbiPrint, "bbiPrint", "طباعة", 8, resources, "bbiPrint.ImageOptions.SvgImage", bbiPrint_ItemClick);
            SetupBarButton(bbiRefresh, "bbiRefresh", "تحديث", 9, resources, "bbiRefresh.ImageOptions.SvgImage", bbiRefresh_ItemClick);
            //
            // barStatus
            //
            barStatus.BarName = "شريط الحالة";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0; barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(sbiRecordCount), new DevExpress.XtraBars.LinkPersistInfo(sbiLastRefresh) });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "شريط الحالة";
            sbiRecordCount.Caption = "عدد الموازنات: 0"; sbiRecordCount.Id = 10; sbiRecordCount.Name = "sbiRecordCount";
            sbiLastRefresh.Caption = "آخر تحديث: —"; sbiLastRefresh.Id = 11; sbiLastRefresh.Name = "sbiLastRefresh";
            // BarDock controls
            SetupBarDock(barDockControlTop, System.Windows.Forms.DockStyle.Top, new System.Drawing.Point(0, 0), new System.Drawing.Size(1366, 34));
            SetupBarDock(barDockControlBottom, System.Windows.Forms.DockStyle.Bottom, new System.Drawing.Point(0, 873), new System.Drawing.Size(1366, 29));
            SetupBarDock(barDockControlLeft, System.Windows.Forms.DockStyle.Left, new System.Drawing.Point(0, 34), new System.Drawing.Size(0, 839));
            SetupBarDock(barDockControlRight, System.Windows.Forms.DockStyle.Right, new System.Drawing.Point(1366, 34), new System.Drawing.Size(0, 839));

            // ── pnlStateBanner ────────────────────────────────────────────
            pnlStateBanner.Appearance.BackColor = System.Drawing.Color.FromArgb(235, 236, 240);
            pnlStateBanner.Appearance.Options.UseBackColor = true;
            pnlStateBanner.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlStateBanner.Controls.Add(lblStateBanner);
            pnlStateBanner.Controls.Add(svgStateBannerIcon);
            pnlStateBanner.Dock = System.Windows.Forms.DockStyle.Top;
            pnlStateBanner.Location = new System.Drawing.Point(0, 34);
            pnlStateBanner.Name = "pnlStateBanner";
            pnlStateBanner.Size = new System.Drawing.Size(1366, 36);
            pnlStateBanner.Visible = false;
            lblStateBanner.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            lblStateBanner.Appearance.ForeColor = System.Drawing.Color.FromArgb(90, 100, 115);
            lblStateBanner.Appearance.Options.UseFont = true;
            lblStateBanner.Appearance.Options.UseForeColor = true;
            lblStateBanner.Location = new System.Drawing.Point(1150, 8);
            lblStateBanner.Name = "lblStateBanner";
            lblStateBanner.Size = new System.Drawing.Size(160, 20);
            lblStateBanner.Text = "قائمة الموازنات — للقراءة فقط";
            svgStateBannerIcon.Location = new System.Drawing.Point(1320, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);
            svgStateBannerIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgStateBannerIcon.SvgImage");

            // ── KPI Cards ─────────────────────────────────────────────────
            pnlKpiCards.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCards.Controls.AddRange(new System.Windows.Forms.Control[] { pnlKpiTotal, pnlKpiApproved, pnlKpiDraft, pnlKpiActiveRevisions, pnlKpiTotalCost });
            pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            pnlKpiCards.Location = new System.Drawing.Point(0, 70);
            pnlKpiCards.Name = "pnlKpiCards";
            pnlKpiCards.Size = new System.Drawing.Size(1366, 100);
            BuildKpiCard(pnlKpiTotal, "pnlKpiTotal", lblKpiTotalTitle, "lblKpiTotalTitle", "إجمالي الموازنات", lblKpiTotalValue, "lblKpiTotalValue", "—", System.Drawing.Color.FromArgb(46, 117, 182), new System.Drawing.Point(1104, 8));
            BuildKpiCard(pnlKpiApproved, "pnlKpiApproved", lblKpiApprovedTitle, "lblKpiApprovedTitle", "معتمدة", lblKpiApprovedValue, "lblKpiApprovedValue", "—", System.Drawing.Color.FromArgb(46, 158, 91), new System.Drawing.Point(830, 8));
            BuildKpiCard(pnlKpiDraft, "pnlKpiDraft", lblKpiDraftTitle, "lblKpiDraftTitle", "مسودة", lblKpiDraftValue, "lblKpiDraftValue", "—", System.Drawing.Color.FromArgb(255, 127, 14), new System.Drawing.Point(556, 8));
            BuildKpiCard(pnlKpiActiveRevisions, "pnlKpiActiveRevisions", lblKpiActiveRevisionsTitle, "lblKpiActiveRevisionsTitle", "مراجعات نشطة", lblKpiActiveRevisionsValue, "lblKpiActiveRevisionsValue", "—", System.Drawing.Color.FromArgb(148, 103, 189), new System.Drawing.Point(282, 8));
            BuildKpiCard(pnlKpiTotalCost, "pnlKpiTotalCost", lblKpiTotalCostTitle, "lblKpiTotalCostTitle", "إجمالي التكلفة", lblKpiTotalCostValue, "lblKpiTotalCostValue", "—", System.Drawing.Color.FromArgb(192, 80, 77), new System.Drawing.Point(8, 8));

            // ── pnlSearchFilters ──────────────────────────────────────────
            pnlSearchFilters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlSearchFilters.Appearance.BackColor = System.Drawing.Color.FromArgb(248, 248, 250);
            pnlSearchFilters.Appearance.Options.UseBackColor = true;
            pnlSearchFilters.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblCompany, cboCompany, lblBranch, cboBranch, lblProject, lueProject,
                lblRevision, cboRevision, lblBudgetType, cboBudgetType, lblStatus, cboStatus,
                lblDateRange, dtDateFrom, lblDateRangeSep, dtDateTo, btnSearch, btnClearFilters, btnSaveFilter
            });
            pnlSearchFilters.Dock = System.Windows.Forms.DockStyle.Top;
            pnlSearchFilters.Location = new System.Drawing.Point(0, 170);
            pnlSearchFilters.Name = "pnlSearchFilters";
            pnlSearchFilters.Size = new System.Drawing.Size(1366, 52);
            // filter controls (RTL, right→left)
            SetupLabel(lblCompany, "lblCompany", "الشركة:", new System.Drawing.Point(1290, 8));
            SetupCombo(cboCompany, "cboCompany", new System.Drawing.Point(1160, 10), 125);
            SetupLabel(lblBranch, "lblBranch", "الفرع:", new System.Drawing.Point(1100, 8));
            SetupCombo(cboBranch, "cboBranch", new System.Drawing.Point(970, 10), 125);
            SetupLabel(lblProject, "lblProject", "المشروع:", new System.Drawing.Point(905, 8));
            lueProject.Location = new System.Drawing.Point(760, 10); lueProject.Name = "lueProject";
            lueProject.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            lueProject.Properties.Appearance.Options.UseFont = true;
            lueProject.Size = new System.Drawing.Size(140, 30);
            SetupLabel(lblRevision, "lblRevision", "المراجعة:", new System.Drawing.Point(700, 8));
            SetupCombo(cboRevision, "cboRevision", new System.Drawing.Point(570, 10), 125);
            SetupLabel(lblBudgetType, "lblBudgetType", "نوع الموازنة:", new System.Drawing.Point(490, 8));
            SetupCombo(cboBudgetType, "cboBudgetType", new System.Drawing.Point(360, 10), 125);
            SetupLabel(lblStatus, "lblStatus", "الحالة:", new System.Drawing.Point(300, 8));
            SetupCombo(cboStatus, "cboStatus", new System.Drawing.Point(170, 10), 125);
            SetupLabel(lblDateRange, "lblDateRange", "التاريخ:", new System.Drawing.Point(108, 8));
            dtDateFrom.Location = new System.Drawing.Point(108, 10); dtDateFrom.Name = "dtDateFrom";
            dtDateFrom.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            dtDateFrom.Properties.Appearance.Options.UseFont = true;
            dtDateFrom.Size = new System.Drawing.Size(0, 30);
            lblDateRangeSep.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            lblDateRangeSep.Appearance.Options.UseFont = true;
            lblDateRangeSep.Location = new System.Drawing.Point(0, 14);
            lblDateRangeSep.Name = "lblDateRangeSep"; lblDateRangeSep.Text = "—";
            dtDateTo.Location = new System.Drawing.Point(0, 10); dtDateTo.Name = "dtDateTo";
            dtDateTo.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            dtDateTo.Properties.Appearance.Options.UseFont = true;
            dtDateTo.Size = new System.Drawing.Size(0, 30);
            btnSearch.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            btnSearch.Appearance.Options.UseFont = true;
            btnSearch.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSearch.ImageOptions.SvgImage");
            btnSearch.Location = new System.Drawing.Point(108, 10);
            btnSearch.Name = "btnSearch"; btnSearch.Size = new System.Drawing.Size(90, 30); btnSearch.Text = "بحث";
            btnSearch.Click += btnSearch_Click;
            btnClearFilters.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            btnClearFilters.Appearance.Options.UseFont = true;
            btnClearFilters.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnClearFilters.ImageOptions.SvgImage");
            btnClearFilters.Location = new System.Drawing.Point(8, 10);
            btnClearFilters.Name = "btnClearFilters"; btnClearFilters.Size = new System.Drawing.Size(95, 30); btnClearFilters.Text = "مسح الفلاتر";
            btnClearFilters.Click += btnClearFilters_Click;
            btnSaveFilter.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            btnSaveFilter.Appearance.Options.UseFont = true;
            btnSaveFilter.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSaveFilter.ImageOptions.SvgImage");
            btnSaveFilter.Location = new System.Drawing.Point(1340, 10);
            btnSaveFilter.Name = "btnSaveFilter"; btnSaveFilter.Size = new System.Drawing.Size(20, 30);
            btnSaveFilter.Click += btnSaveFilter_Click;

            // ── grdBudget (BandedGridView-like GridView with all columns) ──
            grdBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            grdBudget.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            grdBudget.Location = new System.Drawing.Point(0, 222);
            grdBudget.MainView = gvBudget;
            grdBudget.MenuManager = barManagerMain;
            grdBudget.Name = "grdBudget";
            grdBudget.Size = new System.Drawing.Size(1366, 594);
            grdBudget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvBudget });
            //
            // gvBudget
            //
            gvBudget.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 8F, System.Drawing.FontStyle.Bold);
            gvBudget.Appearance.HeaderPanel.Options.UseFont = true;
            gvBudget.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F);
            gvBudget.Appearance.Row.Options.UseFont = true;
            gvBudget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[]
            { colBudgetCode, colBudgetName, colProject, colRevision, colOriginalBudget, colCurrentBudget, colActual, colForecast, colVariance, colStatus, colApprovedBy, colLastModified });
            gvBudget.GridControl = grdBudget;
            gvBudget.Name = "gvBudget";
            gvBudget.OptionsBehavior.Editable = false;
            gvBudget.OptionsCustomization.AllowColumnMoving = true;
            gvBudget.OptionsCustomization.AllowRowSizing = true;
            gvBudget.OptionsView.ShowAutoFilterRow = true;
            gvBudget.OptionsView.ShowFooter = true;
            gvBudget.OptionsView.ShowGroupPanel = false;
            // Columns
            SetupCol(colBudgetCode, "colBudgetCode", "كود الموازنة", "BudgetCode", 110, true);
            SetupCol(colBudgetName, "colBudgetName", "اسم الموازنة", "BudgetName", 200, false);
            SetupCol(colProject, "colProject", "المشروع", "ProjectName", 180, false);
            SetupCol(colRevision, "colRevision", "المراجعة", "Revision", 80, false);
            SetupColNum(colOriginalBudget, "colOriginalBudget", "الموازنة الأصلية", "OriginalBudget", 130);
            SetupColNum(colCurrentBudget, "colCurrentBudget", "الموازنة الحالية", "CurrentBudget", 130);
            SetupColNum(colActual, "colActual", "الفعلي", "ActualCost", 130);
            SetupColNum(colForecast, "colForecast", "التوقع", "Forecast", 130);
            SetupColNum(colVariance, "colVariance", "الانحراف", "Variance", 130);
            SetupCol(colStatus, "colStatus", "الحالة", "StatusName", 100, false);
            SetupCol(colApprovedBy, "colApprovedBy", "معتمد بواسطة", "ApprovedBy", 140, false);
            SetupCol(colLastModified, "colLastModified", "آخر تعديل", "LastModified", 140, false);
            // Conditional format: variance < 0 → red background
            gridFormatRule1.Column = colVariance;
            gridFormatRule1.Name = "ruleOverBudget";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gvBudget.FormatRules.Add(gridFormatRule1);

            // ── pnlSummary ────────────────────────────────────────────────
            pnlSummary.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlSummary.Controls.AddRange(new System.Windows.Forms.Control[] { lblSummaryTotalBudget, lblSummaryActual, lblSummaryRecordCount });
            pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlSummary.Location = new System.Drawing.Point(0, 816);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new System.Drawing.Size(1366, 28);
            SetupSummaryLabel(lblSummaryRecordCount, "lblSummaryRecordCount", "عدد الموازنات: 0", new System.Drawing.Point(1140, 6));
            SetupSummaryLabel(lblSummaryTotalBudget, "lblSummaryTotalBudget", "إجمالي الموازنة: —", new System.Drawing.Point(800, 6));
            SetupSummaryLabel(lblSummaryActual, "lblSummaryActual", "إجمالي الفعلي: —", new System.Drawing.Point(460, 6));

            // ── State Panels ──────────────────────────────────────────────
            BuildStatePanel(pnlLoadingState, "pnlLoadingState", lblLoadingText, "lblLoadingText", "جاري تحميل قائمة الموازنات...", svgLoadingIcon, "svgLoadingIcon", resources, "svgLoadingIcon.SvgImage", null);
            BuildStatePanel(pnlEmptyState, "pnlEmptyState", lblEmptyText, "lblEmptyText", "لا توجد موازنات. أنشئ موازنة جديدة للبدء.", svgEmptyIcon, "svgEmptyIcon", resources, "svgEmptyIcon.SvgImage", null);
            BuildStatePanel(pnlErrorState, "pnlErrorState", lblErrorText, "lblErrorText", "حدث خطأ أثناء تحميل قائمة الموازنات", svgErrorIcon, "svgErrorIcon", resources, "svgErrorIcon.SvgImage", btnRetry);
            btnRetry.Click += btnRetry_Click;

            // ── ucBudgetList ──────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(grdBudget);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlSummary);
            Controls.Add(pnlSearchFilters);
            Controls.Add(pnlKpiCards);
            Controls.Add(pnlStateBanner);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            Name = "ucBudgetList";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1366, 902);

            // ── End Init ──────────────────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlStateBanner).EndInit();
            pnlStateBanner.ResumeLayout(false); pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgStateBannerIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit(); pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiTotal).EndInit(); pnlKpiTotal.ResumeLayout(false); pnlKpiTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiApproved).EndInit(); pnlKpiApproved.ResumeLayout(false); pnlKpiApproved.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiDraft).EndInit(); pnlKpiDraft.ResumeLayout(false); pnlKpiDraft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActiveRevisions).EndInit(); pnlKpiActiveRevisions.ResumeLayout(false); pnlKpiActiveRevisions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiTotalCost).EndInit(); pnlKpiTotalCost.ResumeLayout(false); pnlKpiTotalCost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSearchFilters).EndInit(); pnlSearchFilters.ResumeLayout(false); pnlSearchFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDateTo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDateFrom.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboBudgetType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboRevision.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboBranch.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboCompany.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlSummary).EndInit(); pnlSummary.ResumeLayout(false); pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit(); pnlLoadingState.ResumeLayout(false); pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit(); pnlEmptyState.ResumeLayout(false); pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit(); pnlErrorState.ResumeLayout(false); pnlErrorState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).EndInit();
            ResumeLayout(false);
        }

        // ── Helpers ────────────────────────────────────────────────────────
        private static void SetupBarButton(DevExpress.XtraBars.BarButtonItem btn, string name, string caption, int id,
            System.ComponentModel.ComponentResourceManager res, string resKey,
            DevExpress.XtraBars.ItemClickEventHandler handler)
        {
            btn.Caption = caption; btn.Id = id;
            btn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)res.GetObject(resKey);
            btn.Name = name;
            btn.ItemClick += handler;
        }
        private static void SetupBarDock(DevExpress.XtraBars.BarDockControl dock, System.Windows.Forms.DockStyle dockStyle,
            System.Drawing.Point loc, System.Drawing.Size sz)
        {
            dock.CausesValidation = false; dock.Dock = dockStyle; dock.Location = loc; dock.Size = sz;
        }
        private static void SetupLabel(DevExpress.XtraEditors.LabelControl lbl, string name, string text, System.Drawing.Point loc)
        {
            lbl.Appearance.Font = new System.Drawing.Font("Cairo", 8F);
            lbl.Appearance.Options.UseFont = true;
            lbl.Location = loc; lbl.Name = name; lbl.Text = text;
        }
        private static void SetupCombo(DevExpress.XtraEditors.ComboBoxEdit cbo, string name, System.Drawing.Point loc, int width)
        {
            cbo.Location = loc; cbo.Name = name;
            cbo.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            cbo.Properties.Appearance.Options.UseFont = true;
            cbo.Size = new System.Drawing.Size(width, 30);
        }
        private static void SetupCol(DevExpress.XtraGrid.Columns.GridColumn col, string name, string caption, string field, int width, bool fixedLeft)
        {
            col.Caption = caption; col.FieldName = field; col.Name = name;
            col.Visible = true; col.Width = width;
            if (fixedLeft) col.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
        }
        private static void SetupColNum(DevExpress.XtraGrid.Columns.GridColumn col, string name, string caption, string field, int width)
        {
            col.Caption = caption; col.FieldName = field; col.Name = name; col.Visible = true; col.Width = width;
            col.DisplayFormat.FormatString = "N2"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, field, "الإجمالي: {0:N2}") });
        }
        private static void BuildKpiCard(DevExpress.XtraEditors.PanelControl pnl, string pnlName,
            DevExpress.XtraEditors.LabelControl lblTitle, string lblTitleName, string titleText,
            DevExpress.XtraEditors.LabelControl lblVal, string lblValName, string valText,
            System.Drawing.Color valColor, System.Drawing.Point loc)
        {
            pnl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnl.Controls.Add(lblTitle); pnl.Controls.Add(lblVal);
            pnl.Location = loc; pnl.Name = pnlName; pnl.Size = new System.Drawing.Size(254, 84);
            lblTitle.Appearance.Font = new System.Drawing.Font("Cairo", 8F);
            lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblTitle.Appearance.Options.UseFont = true; lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new System.Drawing.Point(10, 12); lblTitle.Name = lblTitleName; lblTitle.Text = titleText;
            lblVal.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            lblVal.Appearance.ForeColor = valColor;
            lblVal.Appearance.Options.UseFont = true; lblVal.Appearance.Options.UseForeColor = true;
            lblVal.Location = new System.Drawing.Point(10, 38); lblVal.Name = lblValName; lblVal.Text = valText;
        }
        private static void SetupSummaryLabel(DevExpress.XtraEditors.LabelControl lbl, string name, string text, System.Drawing.Point loc)
        {
            lbl.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            lbl.Appearance.Options.UseFont = true;
            lbl.Location = loc; lbl.Name = name; lbl.Text = text;
        }
        private static void BuildStatePanel(DevExpress.XtraEditors.PanelControl pnl, string pnlName,
            DevExpress.XtraEditors.LabelControl lbl, string lblName, string lblText,
            DevExpress.XtraEditors.SvgImageBox svg, string svgName,
            System.ComponentModel.ComponentResourceManager res, string resKey,
            DevExpress.XtraEditors.SimpleButton? btn)
        {
            if (btn != null) pnl.Controls.Add(btn);
            pnl.Controls.Add(lbl); pnl.Controls.Add(svg);
            pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl.Name = pnlName; pnl.Size = new System.Drawing.Size(1366, 594); pnl.Visible = false;
            lbl.Appearance.Font = new System.Drawing.Font("Cairo", 10F);
            lbl.Appearance.Options.UseFont = true;
            lbl.Appearance.Options.UseTextOptions = true;
            lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lbl.Location = new System.Drawing.Point(543, 310); lbl.Name = lblName;
            lbl.Size = new System.Drawing.Size(280, 26); lbl.Text = lblText;
            svg.Location = new System.Drawing.Point(651, 210); svg.Name = svgName;
            svg.Size = new System.Drawing.Size(64, 64);
            svg.SvgImage = (DevExpress.Utils.Svg.SvgImage)res.GetObject(resKey);
            if (btn != null)
            {
                btn.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
                btn.Appearance.Options.UseFont = true;
                btn.Location = new System.Drawing.Point(633, 345);
                btn.Name = "btnRetry"; btn.Size = new System.Drawing.Size(100, 34); btn.Text = "إعادة المحاولة";
            }
        }

        #endregion

        // ── Fields ────────────────────────────────────────────────────────
        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiNewBudget;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiCopy;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiImport;
        private DevExpress.XtraBars.BarButtonItem bbiExportExcel;
        private DevExpress.XtraBars.BarButtonItem bbiCompare;
        private DevExpress.XtraBars.BarButtonItem bbiApprove;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarStaticItem sbiLastRefresh;
        private DevExpress.XtraEditors.PanelControl pnlStateBanner;
        private DevExpress.XtraEditors.LabelControl lblStateBanner;
        private DevExpress.XtraEditors.SvgImageBox svgStateBannerIcon;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.PanelControl pnlKpiTotal;
        private DevExpress.XtraEditors.LabelControl lblKpiTotalValue;
        private DevExpress.XtraEditors.LabelControl lblKpiTotalTitle;
        private DevExpress.XtraEditors.PanelControl pnlKpiApproved;
        private DevExpress.XtraEditors.LabelControl lblKpiApprovedValue;
        private DevExpress.XtraEditors.LabelControl lblKpiApprovedTitle;
        private DevExpress.XtraEditors.PanelControl pnlKpiDraft;
        private DevExpress.XtraEditors.LabelControl lblKpiDraftValue;
        private DevExpress.XtraEditors.LabelControl lblKpiDraftTitle;
        private DevExpress.XtraEditors.PanelControl pnlKpiActiveRevisions;
        private DevExpress.XtraEditors.LabelControl lblKpiActiveRevisionsValue;
        private DevExpress.XtraEditors.LabelControl lblKpiActiveRevisionsTitle;
        private DevExpress.XtraEditors.PanelControl pnlKpiTotalCost;
        private DevExpress.XtraEditors.LabelControl lblKpiTotalCostValue;
        private DevExpress.XtraEditors.LabelControl lblKpiTotalCostTitle;
        private DevExpress.XtraEditors.PanelControl pnlSearchFilters;
        private DevExpress.XtraEditors.SimpleButton btnSaveFilter;
        private DevExpress.XtraEditors.SimpleButton btnClearFilters;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.DateEdit dtDateTo;
        private DevExpress.XtraEditors.LabelControl lblDateRangeSep;
        private DevExpress.XtraEditors.DateEdit dtDateFrom;
        private DevExpress.XtraEditors.LabelControl lblDateRange;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.ComboBoxEdit cboBudgetType;
        private DevExpress.XtraEditors.LabelControl lblBudgetType;
        private DevExpress.XtraEditors.ComboBoxEdit cboRevision;
        private DevExpress.XtraEditors.LabelControl lblRevision;
        private DevExpress.XtraEditors.LookUpEdit lueProject;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.ComboBoxEdit cboBranch;
        private DevExpress.XtraEditors.LabelControl lblBranch;
        private DevExpress.XtraEditors.ComboBoxEdit cboCompany;
        private DevExpress.XtraEditors.LabelControl lblCompany;
        private DevExpress.XtraGrid.GridControl grdBudget;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetName;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginalBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colActual;
        private DevExpress.XtraGrid.Columns.GridColumn colForecast;
        private DevExpress.XtraGrid.Columns.GridColumn colVariance;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModified;
        private DevExpress.XtraEditors.PanelControl pnlSummary;
        private DevExpress.XtraEditors.LabelControl lblSummaryTotalBudget;
        private DevExpress.XtraEditors.LabelControl lblSummaryActual;
        private DevExpress.XtraEditors.LabelControl lblSummaryRecordCount;
        private DevExpress.XtraEditors.PanelControl pnlLoadingState;
        private DevExpress.XtraEditors.LabelControl lblLoadingText;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon;
        private DevExpress.XtraEditors.PanelControl pnlEmptyState;
        private DevExpress.XtraEditors.LabelControl lblEmptyText;
        private DevExpress.XtraEditors.SvgImageBox svgEmptyIcon;
        private DevExpress.XtraEditors.PanelControl pnlErrorState;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
        private DevExpress.XtraEditors.LabelControl lblErrorText;
        private DevExpress.XtraEditors.SvgImageBox svgErrorIcon;
    }
}

