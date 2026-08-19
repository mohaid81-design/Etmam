namespace Etmam
{
    partial class ucProjectDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProjectDetails));
            barManagerDetails = new DevExpress.XtraBars.BarManager(components);
            barHeader = new DevExpress.XtraBars.Bar();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiSave = new DevExpress.XtraBars.BarButtonItem();
            bbiCancelEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            pnlProjectHeader = new DevExpress.XtraEditors.PanelControl();
            peProjectPhoto = new DevExpress.XtraEditors.PictureEdit();
            lblProjectNameValue = new DevExpress.XtraEditors.LabelControl();
            lblProjectCodeValue = new DevExpress.XtraEditors.LabelControl();
            lblProjectStatusBadge = new DevExpress.XtraEditors.LabelControl();
            lblEditModeIndicator = new DevExpress.XtraEditors.LabelControl();
            lblHeaderStartLabel = new DevExpress.XtraEditors.LabelControl();
            lblHeaderStartValue = new DevExpress.XtraEditors.LabelControl();
            lblHeaderEndLabel = new DevExpress.XtraEditors.LabelControl();
            lblHeaderEndValue = new DevExpress.XtraEditors.LabelControl();
            lblHeaderProgressLabel = new DevExpress.XtraEditors.LabelControl();
            lblHeaderProgressValue = new DevExpress.XtraEditors.LabelControl();
            pnlApprovalBanner = new DevExpress.XtraEditors.PanelControl();
            btnReject = new DevExpress.XtraEditors.SimpleButton();
            btnApprove = new DevExpress.XtraEditors.SimpleButton();
            lblApprovalText = new DevExpress.XtraEditors.LabelControl();
            tabProjectDetails = new DevExpress.XtraTab.XtraTabControl();
            tabGeneral = new DevExpress.XtraTab.XtraTabPage();
            peProjectImageLarge = new DevExpress.XtraEditors.PictureEdit();
            picCompanyLogo = new DevExpress.XtraEditors.PictureEdit();
            lblGenSectionInfo = new DevExpress.XtraEditors.LabelControl();
            lblGenType = new DevExpress.XtraEditors.LabelControl();
            cbeGenType = new DevExpress.XtraEditors.ComboBoxEdit();
            lblGenLocation = new DevExpress.XtraEditors.LabelControl();
            teGenLocation = new DevExpress.XtraEditors.TextEdit();
            lblGenStartDate = new DevExpress.XtraEditors.LabelControl();
            deGenStartDate = new DevExpress.XtraEditors.DateEdit();
            lblGenEndDate = new DevExpress.XtraEditors.LabelControl();
            deGenEndDate = new DevExpress.XtraEditors.DateEdit();
            lblGenDuration = new DevExpress.XtraEditors.LabelControl();
            teGenDuration = new DevExpress.XtraEditors.TextEdit();
            lblGenValue = new DevExpress.XtraEditors.LabelControl();
            teGenValue = new DevExpress.XtraEditors.TextEdit();
            lblGenDescription = new DevExpress.XtraEditors.LabelControl();
            meGenDescription = new DevExpress.XtraEditors.MemoEdit();
            lblGenSectionParties = new DevExpress.XtraEditors.LabelControl();
            lblOwnerTitle = new DevExpress.XtraEditors.LabelControl();
            lueOwnerGeneral = new DevExpress.XtraEditors.LookUpEdit();
            lblConsultantTitle = new DevExpress.XtraEditors.LabelControl();
            lueConsultantGeneral = new DevExpress.XtraEditors.LookUpEdit();
            lblContractorTitle = new DevExpress.XtraEditors.LabelControl();
            lueContractorGeneral = new DevExpress.XtraEditors.LookUpEdit();
            pnlLocationMap = new DevExpress.XtraEditors.PanelControl();
            lblLocationMapPlaceholder = new DevExpress.XtraEditors.LabelControl();
            tabFinancial = new DevExpress.XtraTab.XtraTabPage();
            pnlFinContract = new DevExpress.XtraEditors.PanelControl();
            pnlFinBudget = new DevExpress.XtraEditors.PanelControl();
            pnlFinActual = new DevExpress.XtraEditors.PanelControl();
            pnlFinForecast = new DevExpress.XtraEditors.PanelControl();
            pnlFinRetention = new DevExpress.XtraEditors.PanelControl();
            pnlFinCashFlow = new DevExpress.XtraEditors.PanelControl();
            tabSchedule = new DevExpress.XtraTab.XtraTabPage();
            pnlSchedBaseline = new DevExpress.XtraEditors.PanelControl();
            lblSchedBaselineTitle = new DevExpress.XtraEditors.LabelControl();
            lblSchedBaselineValue = new DevExpress.XtraEditors.LabelControl();
            pnlSchedProgress = new DevExpress.XtraEditors.PanelControl();
            lblSchedProgressTitle = new DevExpress.XtraEditors.LabelControl();
            lblSchedProgressValue = new DevExpress.XtraEditors.LabelControl();
            lblSchedMilestonesHeader = new DevExpress.XtraEditors.LabelControl();
            lblSchedActivitiesHeader = new DevExpress.XtraEditors.LabelControl();
            grdMilestones = new DevExpress.XtraGrid.GridControl();
            gvMilestones = new DevExpress.XtraGrid.Views.Grid.GridView();
            colMilestoneName = new DevExpress.XtraGrid.Columns.GridColumn();
            colMilestonePlanned = new DevExpress.XtraGrid.Columns.GridColumn();
            colMilestoneActual = new DevExpress.XtraGrid.Columns.GridColumn();
            colMilestoneStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            grdActivities = new DevExpress.XtraGrid.GridControl();
            gvActivities = new DevExpress.XtraGrid.Views.Grid.GridView();
            colActivityName = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            tabOrganization = new DevExpress.XtraTab.XtraTabPage();
            lblDepartments = new DevExpress.XtraEditors.LabelControl();
            grdDepartments = new DevExpress.XtraGrid.GridControl();
            gvDepartments = new DevExpress.XtraGrid.Views.Grid.GridView();
            colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            lblCostCenters = new DevExpress.XtraEditors.LabelControl();
            grdCostCenters = new DevExpress.XtraGrid.GridControl();
            gvCostCenters = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCostCenterName = new DevExpress.XtraGrid.Columns.GridColumn();
            lblWbs = new DevExpress.XtraEditors.LabelControl();
            grdWbs = new DevExpress.XtraGrid.GridControl();
            gvWbs = new DevExpress.XtraGrid.Views.Grid.GridView();
            colWbsName = new DevExpress.XtraGrid.Columns.GridColumn();
            lblCbs = new DevExpress.XtraEditors.LabelControl();
            grdCbs = new DevExpress.XtraGrid.GridControl();
            gvCbs = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCbsName = new DevExpress.XtraGrid.Columns.GridColumn();
            tabDocuments = new DevExpress.XtraTab.XtraTabPage();
            grdDetailDocuments = new DevExpress.XtraGrid.GridControl();
            gvDetailDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            colDocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            tabContacts = new DevExpress.XtraTab.XtraTabPage();
            grdContacts = new DevExpress.XtraGrid.GridControl();
            gvContacts = new DevExpress.XtraGrid.Views.Grid.GridView();
            colContactName = new DevExpress.XtraGrid.Columns.GridColumn();
            colContactCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            colContactRole = new DevExpress.XtraGrid.Columns.GridColumn();
            colContactPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            colContactEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            tabKPIs = new DevExpress.XtraTab.XtraTabPage();
            pnlKpiSpi = new DevExpress.XtraEditors.PanelControl();
            pnlKpiCpi = new DevExpress.XtraEditors.PanelControl();
            pnlKpiProgressDetail = new DevExpress.XtraEditors.PanelControl();
            pnlKpiQuality = new DevExpress.XtraEditors.PanelControl();
            pnlKpiSafety = new DevExpress.XtraEditors.PanelControl();
            pnlKpiCash = new DevExpress.XtraEditors.PanelControl();
            pnlKpiForecastDetail = new DevExpress.XtraEditors.PanelControl();
            tabAttachments = new DevExpress.XtraTab.XtraTabPage();
            btnUploadAttachment = new DevExpress.XtraEditors.SimpleButton();
            grdAttachments = new DevExpress.XtraGrid.GridControl();
            gvAttachments = new DevExpress.XtraGrid.Views.Grid.GridView();
            colAttachmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            colAttachmentType = new DevExpress.XtraGrid.Columns.GridColumn();
            colAttachmentSize = new DevExpress.XtraGrid.Columns.GridColumn();
            colAttachmentUploadedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colAttachmentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            tabHistory = new DevExpress.XtraTab.XtraTabPage();
            grdHistory = new DevExpress.XtraGrid.GridControl();
            gvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            colHistoryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colHistoryUser = new DevExpress.XtraGrid.Columns.GridColumn();
            colHistoryAction = new DevExpress.XtraGrid.Columns.GridColumn();
            colHistoryDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            tabAudit = new DevExpress.XtraTab.XtraTabPage();
            grdAudit = new DevExpress.XtraGrid.GridControl();
            gvAudit = new DevExpress.XtraGrid.Views.Grid.GridView();
            colAuditDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colAuditUser = new DevExpress.XtraGrid.Columns.GridColumn();
            colAuditField = new DevExpress.XtraGrid.Columns.GridColumn();
            colAuditOldValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colAuditNewValue = new DevExpress.XtraGrid.Columns.GridColumn();
            lblFinContractTitle = new DevExpress.XtraEditors.LabelControl();
            lblFinContractValue = new DevExpress.XtraEditors.LabelControl();
            lblFinBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            lblFinBudgetValue = new DevExpress.XtraEditors.LabelControl();
            lblFinActualTitle = new DevExpress.XtraEditors.LabelControl();
            lblFinActualValue = new DevExpress.XtraEditors.LabelControl();
            lblFinForecastTitle = new DevExpress.XtraEditors.LabelControl();
            lblFinForecastValue = new DevExpress.XtraEditors.LabelControl();
            lblFinRetentionTitle = new DevExpress.XtraEditors.LabelControl();
            lblFinRetentionValue = new DevExpress.XtraEditors.LabelControl();
            lblFinCashFlowTitle = new DevExpress.XtraEditors.LabelControl();
            lblFinCashFlowValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiSpiTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiSpiValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiCpiTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiCpiValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiProgressDetailTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiProgressDetailValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiQualityTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiQualityValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiSafetyTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiSafetyValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiCashTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiCashValue = new DevExpress.XtraEditors.LabelControl();
            lblKpiForecastDetailTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiForecastDetailValue = new DevExpress.XtraEditors.LabelControl();
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            lblLoadingText = new DevExpress.XtraEditors.LabelControl();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            lblEmptyText = new DevExpress.XtraEditors.LabelControl();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl();
            svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();
            lblErrorText = new DevExpress.XtraEditors.LabelControl();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)barManagerDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlProjectHeader).BeginInit();
            pnlProjectHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)peProjectPhoto.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlApprovalBanner).BeginInit();
            pnlApprovalBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabProjectDetails).BeginInit();
            tabProjectDetails.SuspendLayout();
            tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)peProjectImageLarge.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCompanyLogo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbeGenType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teGenLocation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deGenStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deGenStartDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deGenEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deGenEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teGenDuration.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teGenValue.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)meGenDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueOwnerGeneral.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueConsultantGeneral.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueContractorGeneral.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLocationMap).BeginInit();
            pnlLocationMap.SuspendLayout();
            tabFinancial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFinContract).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinRetention).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinCashFlow).BeginInit();
            tabSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSchedBaseline).BeginInit();
            pnlSchedBaseline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSchedProgress).BeginInit();
            pnlSchedProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdMilestones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvMilestones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdActivities).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvActivities).BeginInit();
            tabOrganization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdDepartments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvDepartments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdCostCenters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCostCenters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdWbs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvWbs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdCbs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCbs).BeginInit();
            tabDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdDetailDocuments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvDetailDocuments).BeginInit();
            tabContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdContacts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvContacts).BeginInit();
            tabKPIs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiSpi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCpi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiProgressDetail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiQuality).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiSafety).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCash).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecastDetail).BeginInit();
            tabAttachments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdAttachments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvAttachments).BeginInit();
            tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvHistory).BeginInit();
            tabAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdAudit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvAudit).BeginInit();
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
            // 
            // barManagerDetails
            // 
            barManagerDetails.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barHeader });
            barManagerDetails.DockControls.Add(barDockControlTop);
            barManagerDetails.DockControls.Add(barDockControlBottom);
            barManagerDetails.DockControls.Add(barDockControlLeft);
            barManagerDetails.DockControls.Add(barDockControlRight);
            barManagerDetails.Form = this;
            barManagerDetails.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiEdit, bbiSave, bbiCancelEdit, bbiPrint, bbiExportPdf });
            barManagerDetails.MainMenu = barHeader;
            barManagerDetails.MaxItemId = 5;
            barManagerDetails.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // barHeader
            // 
            barHeader.BarName = "شريط أدوات تفاصيل المشروع";
            barHeader.DockCol = 0;
            barHeader.DockRow = 0;
            barHeader.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barHeader.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCancelEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportPdf, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barHeader.OptionsBar.AllowQuickCustomization = false;
            barHeader.OptionsBar.DrawDragBorder = false;
            barHeader.OptionsBar.MinHeight = 38;
            barHeader.OptionsBar.UseWholeRow = true;
            barHeader.Text = "شريط أدوات تفاصيل المشروع";
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 0;
            bbiEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiEdit.ImageOptions.SvgImage");
            bbiEdit.Name = "bbiEdit";
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            // 
            // bbiSave
            // 
            bbiSave.Caption = "حفظ";
            bbiSave.Id = 1;
            bbiSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiSave.ImageOptions.SvgImage");
            bbiSave.Name = "bbiSave";
            bbiSave.ItemClick += bbiSave_ItemClick;
            // 
            // bbiCancelEdit
            // 
            bbiCancelEdit.Caption = "إلغاء";
            bbiCancelEdit.Id = 2;
            bbiCancelEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiCancelEdit.ImageOptions.SvgImage");
            bbiCancelEdit.Name = "bbiCancelEdit";
            bbiCancelEdit.ItemClick += bbiCancelEdit_ItemClick;
            // 
            // bbiPrint
            // 
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 3;
            bbiPrint.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiPrint.ImageOptions.SvgImage");
            bbiPrint.Name = "bbiPrint";
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            // 
            // bbiExportPdf
            // 
            bbiExportPdf.Caption = "تصدير PDF";
            bbiExportPdf.Id = 4;
            bbiExportPdf.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExportPdf.ImageOptions.SvgImage");
            bbiExportPdf.Name = "bbiExportPdf";
            bbiExportPdf.ItemClick += bbiExportPdf_ItemClick;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerDetails;
            barDockControlTop.Size = new Size(1366, 38);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 800);
            barDockControlBottom.Manager = barManagerDetails;
            barDockControlBottom.Size = new Size(1366, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 38);
            barDockControlLeft.Manager = barManagerDetails;
            barDockControlLeft.Size = new Size(0, 762);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 38);
            barDockControlRight.Manager = barManagerDetails;
            barDockControlRight.Size = new Size(0, 762);
            // 
            // pnlProjectHeader
            // 
            pnlProjectHeader.Appearance.BackColor = Color.FromArgb(13, 31, 70);
            pnlProjectHeader.Appearance.Options.UseBackColor = true;
            pnlProjectHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlProjectHeader.Controls.Add(peProjectPhoto);
            pnlProjectHeader.Controls.Add(lblProjectNameValue);
            pnlProjectHeader.Controls.Add(lblProjectCodeValue);
            pnlProjectHeader.Controls.Add(lblProjectStatusBadge);
            pnlProjectHeader.Controls.Add(lblEditModeIndicator);
            pnlProjectHeader.Controls.Add(lblHeaderStartLabel);
            pnlProjectHeader.Controls.Add(lblHeaderStartValue);
            pnlProjectHeader.Controls.Add(lblHeaderEndLabel);
            pnlProjectHeader.Controls.Add(lblHeaderEndValue);
            pnlProjectHeader.Controls.Add(lblHeaderProgressLabel);
            pnlProjectHeader.Controls.Add(lblHeaderProgressValue);
            pnlProjectHeader.Dock = DockStyle.Top;
            pnlProjectHeader.Location = new Point(0, 38);
            pnlProjectHeader.Name = "pnlProjectHeader";
            pnlProjectHeader.Size = new Size(1366, 180);
            pnlProjectHeader.TabIndex = 0;
            // 
            // peProjectPhoto
            // 
            peProjectPhoto.Location = new Point(16, 15);
            peProjectPhoto.Name = "peProjectPhoto";
            peProjectPhoto.Properties.NullText = "صورة";
            peProjectPhoto.Properties.ShowMenu = false;
            peProjectPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            peProjectPhoto.Size = new Size(100, 148);
            peProjectPhoto.TabIndex = 0;
            // 
            // lblProjectNameValue
            // 
            lblProjectNameValue.Appearance.Font = new Font("Cairo", 16F, FontStyle.Bold);
            lblProjectNameValue.Appearance.ForeColor = Color.White;
            lblProjectNameValue.Appearance.Options.UseFont = true;
            lblProjectNameValue.Appearance.Options.UseForeColor = true;
            lblProjectNameValue.Location = new Point(132, 18);
            lblProjectNameValue.Name = "lblProjectNameValue";
            lblProjectNameValue.Size = new Size(24, 42);
            lblProjectNameValue.TabIndex = 1;
            lblProjectNameValue.Text = "—";
            // 
            // lblProjectCodeValue
            // 
            lblProjectCodeValue.Appearance.Font = new Font("Cairo", 10F);
            lblProjectCodeValue.Appearance.ForeColor = Color.FromArgb(160, 185, 230);
            lblProjectCodeValue.Appearance.Options.UseFont = true;
            lblProjectCodeValue.Appearance.Options.UseForeColor = true;
            lblProjectCodeValue.Location = new Point(132, 68);
            lblProjectCodeValue.Name = "lblProjectCodeValue";
            lblProjectCodeValue.Size = new Size(91, 26);
            lblProjectCodeValue.TabIndex = 2;
            lblProjectCodeValue.Text = "رمز المشروع: —";
            // 
            // lblProjectStatusBadge
            // 
            lblProjectStatusBadge.Appearance.BackColor = Color.FromArgb(245, 158, 11);
            lblProjectStatusBadge.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblProjectStatusBadge.Appearance.ForeColor = Color.White;
            lblProjectStatusBadge.Appearance.Options.UseBackColor = true;
            lblProjectStatusBadge.Appearance.Options.UseFont = true;
            lblProjectStatusBadge.Appearance.Options.UseForeColor = true;
            lblProjectStatusBadge.Appearance.Options.UseTextOptions = true;
            lblProjectStatusBadge.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblProjectStatusBadge.Location = new Point(132, 105);
            lblProjectStatusBadge.Name = "lblProjectStatusBadge";
            lblProjectStatusBadge.Padding = new Padding(12, 5, 12, 5);
            lblProjectStatusBadge.Size = new Size(49, 33);
            lblProjectStatusBadge.TabIndex = 3;
            lblProjectStatusBadge.Text = "نشط";
            // 
            // lblEditModeIndicator
            // 
            lblEditModeIndicator.Appearance.Font = new Font("Cairo", 8F);
            lblEditModeIndicator.Appearance.ForeColor = Color.FromArgb(120, 150, 200);
            lblEditModeIndicator.Appearance.Options.UseFont = true;
            lblEditModeIndicator.Appearance.Options.UseForeColor = true;
            lblEditModeIndicator.Location = new Point(132, 146);
            lblEditModeIndicator.Name = "lblEditModeIndicator";
            lblEditModeIndicator.Size = new Size(53, 20);
            lblEditModeIndicator.TabIndex = 4;
            lblEditModeIndicator.Text = "وضع العرض";
            // 
            // lblHeaderStartLabel
            // 
            lblHeaderStartLabel.Appearance.Font = new Font("Cairo", 8F);
            lblHeaderStartLabel.Appearance.ForeColor = Color.FromArgb(120, 150, 200);
            lblHeaderStartLabel.Appearance.Options.UseFont = true;
            lblHeaderStartLabel.Appearance.Options.UseForeColor = true;
            lblHeaderStartLabel.Appearance.Options.UseTextOptions = true;
            lblHeaderStartLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblHeaderStartLabel.Location = new Point(790, 35);
            lblHeaderStartLabel.Name = "lblHeaderStartLabel";
            lblHeaderStartLabel.Size = new Size(49, 20);
            lblHeaderStartLabel.TabIndex = 5;
            lblHeaderStartLabel.Text = "تاريخ البداية";
            // 
            // lblHeaderStartValue
            // 
            lblHeaderStartValue.Appearance.Font = new Font("Cairo", 11F, FontStyle.Bold);
            lblHeaderStartValue.Appearance.ForeColor = Color.White;
            lblHeaderStartValue.Appearance.Options.UseFont = true;
            lblHeaderStartValue.Appearance.Options.UseForeColor = true;
            lblHeaderStartValue.Appearance.Options.UseTextOptions = true;
            lblHeaderStartValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblHeaderStartValue.Location = new Point(790, 62);
            lblHeaderStartValue.Name = "lblHeaderStartValue";
            lblHeaderStartValue.Size = new Size(17, 29);
            lblHeaderStartValue.TabIndex = 6;
            lblHeaderStartValue.Text = "—";
            // 
            // lblHeaderEndLabel
            // 
            lblHeaderEndLabel.Appearance.Font = new Font("Cairo", 8F);
            lblHeaderEndLabel.Appearance.ForeColor = Color.FromArgb(120, 150, 200);
            lblHeaderEndLabel.Appearance.Options.UseFont = true;
            lblHeaderEndLabel.Appearance.Options.UseForeColor = true;
            lblHeaderEndLabel.Appearance.Options.UseTextOptions = true;
            lblHeaderEndLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblHeaderEndLabel.Location = new Point(952, 35);
            lblHeaderEndLabel.Name = "lblHeaderEndLabel";
            lblHeaderEndLabel.Size = new Size(54, 20);
            lblHeaderEndLabel.TabIndex = 7;
            lblHeaderEndLabel.Text = "تاريخ الانتهاء";
            // 
            // lblHeaderEndValue
            // 
            lblHeaderEndValue.Appearance.Font = new Font("Cairo", 11F, FontStyle.Bold);
            lblHeaderEndValue.Appearance.ForeColor = Color.White;
            lblHeaderEndValue.Appearance.Options.UseFont = true;
            lblHeaderEndValue.Appearance.Options.UseForeColor = true;
            lblHeaderEndValue.Appearance.Options.UseTextOptions = true;
            lblHeaderEndValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblHeaderEndValue.Location = new Point(952, 62);
            lblHeaderEndValue.Name = "lblHeaderEndValue";
            lblHeaderEndValue.Size = new Size(17, 29);
            lblHeaderEndValue.TabIndex = 8;
            lblHeaderEndValue.Text = "—";
            // 
            // lblHeaderProgressLabel
            // 
            lblHeaderProgressLabel.Appearance.Font = new Font("Cairo", 8F);
            lblHeaderProgressLabel.Appearance.ForeColor = Color.FromArgb(120, 150, 200);
            lblHeaderProgressLabel.Appearance.Options.UseFont = true;
            lblHeaderProgressLabel.Appearance.Options.UseForeColor = true;
            lblHeaderProgressLabel.Appearance.Options.UseTextOptions = true;
            lblHeaderProgressLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblHeaderProgressLabel.Location = new Point(1114, 18);
            lblHeaderProgressLabel.Name = "lblHeaderProgressLabel";
            lblHeaderProgressLabel.Size = new Size(76, 20);
            lblHeaderProgressLabel.TabIndex = 9;
            lblHeaderProgressLabel.Text = "نسبة الإنجاز الكلية";
            // 
            // lblHeaderProgressValue
            // 
            lblHeaderProgressValue.Appearance.Font = new Font("Cairo", 28F, FontStyle.Bold);
            lblHeaderProgressValue.Appearance.ForeColor = Color.FromArgb(52, 211, 153);
            lblHeaderProgressValue.Appearance.Options.UseFont = true;
            lblHeaderProgressValue.Appearance.Options.UseForeColor = true;
            lblHeaderProgressValue.Appearance.Options.UseTextOptions = true;
            lblHeaderProgressValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblHeaderProgressValue.Location = new Point(1114, 45);
            lblHeaderProgressValue.Name = "lblHeaderProgressValue";
            lblHeaderProgressValue.Size = new Size(44, 72);
            lblHeaderProgressValue.TabIndex = 10;
            lblHeaderProgressValue.Text = "0%";
            // 
            // pnlApprovalBanner
            // 
            pnlApprovalBanner.Appearance.BackColor = Color.FromArgb(255, 246, 229);
            pnlApprovalBanner.Appearance.Options.UseBackColor = true;
            pnlApprovalBanner.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlApprovalBanner.Controls.Add(btnReject);
            pnlApprovalBanner.Controls.Add(btnApprove);
            pnlApprovalBanner.Controls.Add(lblApprovalText);
            pnlApprovalBanner.Dock = DockStyle.Top;
            pnlApprovalBanner.Location = new Point(0, 218);
            pnlApprovalBanner.Name = "pnlApprovalBanner";
            pnlApprovalBanner.Size = new Size(1366, 54);
            pnlApprovalBanner.TabIndex = 1;
            pnlApprovalBanner.Visible = false;
            // 
            // btnReject
            // 
            btnReject.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnReject.ImageOptions.SvgImage");
            btnReject.Location = new Point(280, 8);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(90, 40);
            btnReject.TabIndex = 2;
            btnReject.Text = "رفض";
            btnReject.Click += btnReject_Click;
            // 
            // btnApprove
            // 
            btnApprove.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnApprove.ImageOptions.SvgImage");
            btnApprove.Location = new Point(180, 8);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(90, 40);
            btnApprove.TabIndex = 1;
            btnApprove.Text = "اعتماد";
            btnApprove.Click += btnApprove_Click;
            // 
            // lblApprovalText
            // 
            lblApprovalText.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblApprovalText.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblApprovalText.Appearance.Options.UseFont = true;
            lblApprovalText.Appearance.Options.UseForeColor = true;
            lblApprovalText.Location = new Point(12, 15);
            lblApprovalText.Name = "lblApprovalText";
            lblApprovalText.Size = new Size(154, 23);
            lblApprovalText.TabIndex = 0;
            lblApprovalText.Text = "بانتظار اعتماد بيانات المشروع";
            // 
            // tabProjectDetails
            // 
            tabProjectDetails.AppearancePage.Header.Font = new Font("Cairo", 9F, FontStyle.Bold);
            tabProjectDetails.AppearancePage.Header.Options.UseFont = true;
            tabProjectDetails.Dock = DockStyle.Fill;
            tabProjectDetails.Location = new Point(0, 272);
            tabProjectDetails.Name = "tabProjectDetails";
            tabProjectDetails.SelectedTabPage = tabGeneral;
            tabProjectDetails.Size = new Size(1366, 528);
            tabProjectDetails.TabIndex = 2;
            tabProjectDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tabGeneral, tabFinancial, tabSchedule, tabOrganization, tabDocuments, tabContacts, tabKPIs, tabAttachments, tabHistory, tabAudit });
            tabProjectDetails.RightToLeft = RightToLeft.Yes;
            tabProjectDetails.TabPageWidth = 100;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(peProjectImageLarge);
            tabGeneral.Controls.Add(picCompanyLogo);
            tabGeneral.Controls.Add(lblGenSectionInfo);
            tabGeneral.Controls.Add(lblGenType);
            tabGeneral.Controls.Add(cbeGenType);
            tabGeneral.Controls.Add(lblGenLocation);
            tabGeneral.Controls.Add(teGenLocation);
            tabGeneral.Controls.Add(lblGenStartDate);
            tabGeneral.Controls.Add(deGenStartDate);
            tabGeneral.Controls.Add(lblGenEndDate);
            tabGeneral.Controls.Add(deGenEndDate);
            tabGeneral.Controls.Add(lblGenDuration);
            tabGeneral.Controls.Add(teGenDuration);
            tabGeneral.Controls.Add(lblGenValue);
            tabGeneral.Controls.Add(teGenValue);
            tabGeneral.Controls.Add(lblGenDescription);
            tabGeneral.Controls.Add(meGenDescription);
            tabGeneral.Controls.Add(lblGenSectionParties);
            tabGeneral.Controls.Add(lblOwnerTitle);
            tabGeneral.Controls.Add(lueOwnerGeneral);
            tabGeneral.Controls.Add(lblConsultantTitle);
            tabGeneral.Controls.Add(lueConsultantGeneral);
            tabGeneral.Controls.Add(lblContractorTitle);
            tabGeneral.Controls.Add(lueContractorGeneral);
            tabGeneral.Controls.Add(pnlLocationMap);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Size = new Size(1364, 489);
            tabGeneral.Text = "عام";
            // 
            // peProjectImageLarge
            // 
            peProjectImageLarge.Location = new Point(20, 15);
            peProjectImageLarge.Name = "peProjectImageLarge";
            peProjectImageLarge.Properties.NullText = "صورة المشروع";
            peProjectImageLarge.Properties.ShowMenu = false;
            peProjectImageLarge.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            peProjectImageLarge.Size = new Size(220, 320);
            peProjectImageLarge.TabIndex = 0;
            // 
            // picCompanyLogo
            // 
            picCompanyLogo.Location = new Point(20, 349);
            picCompanyLogo.Name = "picCompanyLogo";
            picCompanyLogo.Properties.NullText = "شعار الشركة";
            picCompanyLogo.Properties.ShowMenu = false;
            picCompanyLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            picCompanyLogo.Size = new Size(220, 111);
            picCompanyLogo.TabIndex = 1;
            // 
            // lblGenSectionInfo
            // 
            lblGenSectionInfo.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblGenSectionInfo.Appearance.ForeColor = Color.FromArgb(13, 31, 70);
            lblGenSectionInfo.Appearance.Options.UseFont = true;
            lblGenSectionInfo.Appearance.Options.UseForeColor = true;
            lblGenSectionInfo.Location = new Point(260, 15);
            lblGenSectionInfo.Name = "lblGenSectionInfo";
            lblGenSectionInfo.Size = new Size(79, 23);
            lblGenSectionInfo.TabIndex = 2;
            lblGenSectionInfo.Text = "بيانات المشروع";
            // 
            // lblGenType
            // 
            lblGenType.Appearance.Font = new Font("Cairo", 8F);
            lblGenType.Appearance.Options.UseFont = true;
            lblGenType.Location = new Point(260, 46);
            lblGenType.Name = "lblGenType";
            lblGenType.Size = new Size(55, 20);
            lblGenType.TabIndex = 3;
            lblGenType.Text = "نوع المشروع";
            // 
            // cbeGenType
            // 
            cbeGenType.Location = new Point(260, 71);
            cbeGenType.Name = "cbeGenType";
            cbeGenType.Properties.Appearance.Font = new Font("Cairo", 9F);
            cbeGenType.Properties.Appearance.Options.UseFont = true;
            cbeGenType.Properties.Items.AddRange(new object[] { "إنشاءات", "بنية تحتية", "كهرباء وميكانيكا", "تقنية معلومات", "خدمات", "أخرى" });
            cbeGenType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbeGenType.Size = new Size(420, 30);
            cbeGenType.TabIndex = 4;
            // 
            // lblGenLocation
            // 
            lblGenLocation.Appearance.Font = new Font("Cairo", 8F);
            lblGenLocation.Appearance.Options.UseFont = true;
            lblGenLocation.Location = new Point(260, 112);
            lblGenLocation.Name = "lblGenLocation";
            lblGenLocation.Size = new Size(33, 20);
            lblGenLocation.TabIndex = 5;
            lblGenLocation.Text = "الموقع";
            // 
            // teGenLocation
            // 
            teGenLocation.Location = new Point(260, 135);
            teGenLocation.Name = "teGenLocation";
            teGenLocation.Properties.Appearance.Font = new Font("Cairo", 9F);
            teGenLocation.Properties.Appearance.Options.UseFont = true;
            teGenLocation.Size = new Size(420, 30);
            teGenLocation.TabIndex = 6;
            // 
            // lblGenStartDate
            // 
            lblGenStartDate.Appearance.Font = new Font("Cairo", 8F);
            lblGenStartDate.Appearance.Options.UseFont = true;
            lblGenStartDate.Location = new Point(260, 178);
            lblGenStartDate.Name = "lblGenStartDate";
            lblGenStartDate.Size = new Size(49, 20);
            lblGenStartDate.TabIndex = 7;
            lblGenStartDate.Text = "تاريخ البداية";
            // 
            // deGenStartDate
            // 
            deGenStartDate.EditValue = new DateTime(2026, 8, 6, 0, 0, 0, 0);
            deGenStartDate.Location = new Point(260, 202);
            deGenStartDate.Name = "deGenStartDate";
            deGenStartDate.Properties.Appearance.Font = new Font("Cairo", 9F);
            deGenStartDate.Properties.Appearance.Options.UseFont = true;
            deGenStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deGenStartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            deGenStartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            deGenStartDate.Size = new Size(200, 30);
            deGenStartDate.TabIndex = 8;
            // 
            // lblGenEndDate
            // 
            lblGenEndDate.Appearance.Font = new Font("Cairo", 8F);
            lblGenEndDate.Appearance.Options.UseFont = true;
            lblGenEndDate.Location = new Point(474, 178);
            lblGenEndDate.Name = "lblGenEndDate";
            lblGenEndDate.Size = new Size(54, 20);
            lblGenEndDate.TabIndex = 9;
            lblGenEndDate.Text = "تاريخ الانتهاء";
            // 
            // deGenEndDate
            // 
            deGenEndDate.EditValue = new DateTime(2026, 8, 6, 0, 0, 0, 0);
            deGenEndDate.Location = new Point(474, 202);
            deGenEndDate.Name = "deGenEndDate";
            deGenEndDate.Properties.Appearance.Font = new Font("Cairo", 9F);
            deGenEndDate.Properties.Appearance.Options.UseFont = true;
            deGenEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deGenEndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            deGenEndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            deGenEndDate.Size = new Size(206, 30);
            deGenEndDate.TabIndex = 10;
            // 
            // lblGenDuration
            // 
            lblGenDuration.Appearance.Font = new Font("Cairo", 8F);
            lblGenDuration.Appearance.Options.UseFont = true;
            lblGenDuration.Location = new Point(260, 245);
            lblGenDuration.Name = "lblGenDuration";
            lblGenDuration.Size = new Size(49, 20);
            lblGenDuration.TabIndex = 11;
            lblGenDuration.Text = "المدة (يوم)";
            // 
            // teGenDuration
            // 
            teGenDuration.Location = new Point(260, 268);
            teGenDuration.Name = "teGenDuration";
            teGenDuration.Properties.Appearance.Font = new Font("Cairo", 9F);
            teGenDuration.Properties.Appearance.Options.UseFont = true;
            teGenDuration.Properties.ReadOnly = true;
            teGenDuration.Size = new Size(200, 30);
            teGenDuration.TabIndex = 12;
            // 
            // lblGenValue
            // 
            lblGenValue.Appearance.Font = new Font("Cairo", 8F);
            lblGenValue.Appearance.Options.UseFont = true;
            lblGenValue.Location = new Point(474, 245);
            lblGenValue.Name = "lblGenValue";
            lblGenValue.Size = new Size(51, 20);
            lblGenValue.TabIndex = 13;
            lblGenValue.Text = "قيمة العقد";
            // 
            // teGenValue
            // 
            teGenValue.Location = new Point(474, 268);
            teGenValue.Name = "teGenValue";
            teGenValue.Properties.Appearance.Font = new Font("Cairo", 9F);
            teGenValue.Properties.Appearance.Options.UseFont = true;
            teGenValue.Size = new Size(206, 30);
            teGenValue.TabIndex = 14;
            // 
            // lblGenDescription
            // 
            lblGenDescription.Appearance.Font = new Font("Cairo", 8F);
            lblGenDescription.Appearance.Options.UseFont = true;
            lblGenDescription.Location = new Point(260, 312);
            lblGenDescription.Name = "lblGenDescription";
            lblGenDescription.Size = new Size(67, 20);
            lblGenDescription.TabIndex = 15;
            lblGenDescription.Text = "وصف المشروع";
            // 
            // meGenDescription
            // 
            meGenDescription.Location = new Point(260, 335);
            meGenDescription.Name = "meGenDescription";
            meGenDescription.Properties.Appearance.Font = new Font("Cairo", 9F);
            meGenDescription.Properties.Appearance.Options.UseFont = true;
            meGenDescription.Size = new Size(420, 120);
            meGenDescription.TabIndex = 16;
            // 
            // lblGenSectionParties
            // 
            lblGenSectionParties.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblGenSectionParties.Appearance.ForeColor = Color.FromArgb(13, 31, 70);
            lblGenSectionParties.Appearance.Options.UseFont = true;
            lblGenSectionParties.Appearance.Options.UseForeColor = true;
            lblGenSectionParties.Location = new Point(706, 15);
            lblGenSectionParties.Name = "lblGenSectionParties";
            lblGenSectionParties.Size = new Size(68, 23);
            lblGenSectionParties.TabIndex = 17;
            lblGenSectionParties.Text = "أطراف العقد";
            // 
            // lblOwnerTitle
            // 
            lblOwnerTitle.Appearance.Font = new Font("Cairo", 8F);
            lblOwnerTitle.Appearance.Options.UseFont = true;
            lblOwnerTitle.Location = new Point(706, 46);
            lblOwnerTitle.Name = "lblOwnerTitle";
            lblOwnerTitle.Size = new Size(28, 20);
            lblOwnerTitle.TabIndex = 18;
            lblOwnerTitle.Text = "المالك";
            // 
            // lueOwnerGeneral
            // 
            lueOwnerGeneral.Location = new Point(706, 71);
            lueOwnerGeneral.Name = "lueOwnerGeneral";
            lueOwnerGeneral.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueOwnerGeneral.Properties.Appearance.Options.UseFont = true;
            lueOwnerGeneral.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "الاسم") });
            lueOwnerGeneral.Properties.NullText = "—";
            lueOwnerGeneral.Size = new Size(628, 30);
            lueOwnerGeneral.TabIndex = 19;
            // 
            // lblConsultantTitle
            // 
            lblConsultantTitle.Appearance.Font = new Font("Cairo", 8F);
            lblConsultantTitle.Appearance.Options.UseFont = true;
            lblConsultantTitle.Location = new Point(706, 112);
            lblConsultantTitle.Name = "lblConsultantTitle";
            lblConsultantTitle.Size = new Size(47, 20);
            lblConsultantTitle.TabIndex = 20;
            lblConsultantTitle.Text = "الاستشاري";
            // 
            // lueConsultantGeneral
            // 
            lueConsultantGeneral.Location = new Point(706, 135);
            lueConsultantGeneral.Name = "lueConsultantGeneral";
            lueConsultantGeneral.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueConsultantGeneral.Properties.Appearance.Options.UseFont = true;
            lueConsultantGeneral.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "الاسم") });
            lueConsultantGeneral.Properties.NullText = "—";
            lueConsultantGeneral.Size = new Size(628, 30);
            lueConsultantGeneral.TabIndex = 21;
            // 
            // lblContractorTitle
            // 
            lblContractorTitle.Appearance.Font = new Font("Cairo", 8F);
            lblContractorTitle.Appearance.Options.UseFont = true;
            lblContractorTitle.Location = new Point(706, 178);
            lblContractorTitle.Name = "lblContractorTitle";
            lblContractorTitle.Size = new Size(36, 20);
            lblContractorTitle.TabIndex = 22;
            lblContractorTitle.Text = "المقاول";
            // 
            // lueContractorGeneral
            // 
            lueContractorGeneral.Location = new Point(706, 202);
            lueContractorGeneral.Name = "lueContractorGeneral";
            lueContractorGeneral.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueContractorGeneral.Properties.Appearance.Options.UseFont = true;
            lueContractorGeneral.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "الاسم") });
            lueContractorGeneral.Properties.NullText = "—";
            lueContractorGeneral.Size = new Size(628, 30);
            lueContractorGeneral.TabIndex = 23;
            // 
            // pnlLocationMap
            // 
            pnlLocationMap.Appearance.BackColor = Color.FromArgb(228, 234, 242);
            pnlLocationMap.Appearance.Options.UseBackColor = true;
            pnlLocationMap.Controls.Add(lblLocationMapPlaceholder);
            pnlLocationMap.Location = new Point(706, 248);
            pnlLocationMap.Name = "pnlLocationMap";
            pnlLocationMap.Size = new Size(628, 214);
            pnlLocationMap.TabIndex = 24;
            // 
            // lblLocationMapPlaceholder
            // 
            lblLocationMapPlaceholder.Anchor = AnchorStyles.None;
            lblLocationMapPlaceholder.Appearance.Font = new Font("Cairo", 9F);
            lblLocationMapPlaceholder.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblLocationMapPlaceholder.Appearance.Options.UseFont = true;
            lblLocationMapPlaceholder.Appearance.Options.UseForeColor = true;
            lblLocationMapPlaceholder.Location = new Point(268, 94);
            lblLocationMapPlaceholder.Name = "lblLocationMapPlaceholder";
            lblLocationMapPlaceholder.Size = new Size(70, 23);
            lblLocationMapPlaceholder.TabIndex = 0;
            lblLocationMapPlaceholder.Text = "خريطة الموقع";
            // 
            // tabFinancial
            // 
            tabFinancial.Controls.Add(pnlFinContract);
            tabFinancial.Controls.Add(pnlFinBudget);
            tabFinancial.Controls.Add(pnlFinActual);
            tabFinancial.Controls.Add(pnlFinForecast);
            tabFinancial.Controls.Add(pnlFinRetention);
            tabFinancial.Controls.Add(pnlFinCashFlow);
            tabFinancial.Name = "tabFinancial";
            tabFinancial.Size = new Size(1364, 489);
            tabFinancial.Text = "مالي";
            // 
            // pnlFinContract
            // 
            pnlFinContract.Appearance.BackColor = Color.FromArgb(238, 240, 252);
            pnlFinContract.Appearance.Options.UseBackColor = true;
            pnlFinContract.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFinContract.Location = new Point(20, 25);
            pnlFinContract.Name = "pnlFinContract";
            pnlFinContract.Size = new Size(310, 165);
            pnlFinContract.TabIndex = 0;
            // 
            // pnlFinBudget
            // 
            pnlFinBudget.Appearance.BackColor = Color.FromArgb(232, 246, 246);
            pnlFinBudget.Appearance.Options.UseBackColor = true;
            pnlFinBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFinBudget.Location = new Point(350, 25);
            pnlFinBudget.Name = "pnlFinBudget";
            pnlFinBudget.Size = new Size(310, 165);
            pnlFinBudget.TabIndex = 1;
            // 
            // pnlFinActual
            // 
            pnlFinActual.Appearance.BackColor = Color.FromArgb(234, 243, 252);
            pnlFinActual.Appearance.Options.UseBackColor = true;
            pnlFinActual.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFinActual.Location = new Point(680, 25);
            pnlFinActual.Name = "pnlFinActual";
            pnlFinActual.Size = new Size(310, 165);
            pnlFinActual.TabIndex = 2;
            // 
            // pnlFinForecast
            // 
            pnlFinForecast.Appearance.BackColor = Color.FromArgb(243, 236, 251);
            pnlFinForecast.Appearance.Options.UseBackColor = true;
            pnlFinForecast.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFinForecast.Location = new Point(20, 209);
            pnlFinForecast.Name = "pnlFinForecast";
            pnlFinForecast.Size = new Size(310, 165);
            pnlFinForecast.TabIndex = 3;
            // 
            // pnlFinRetention
            // 
            pnlFinRetention.Appearance.BackColor = Color.FromArgb(255, 246, 229);
            pnlFinRetention.Appearance.Options.UseBackColor = true;
            pnlFinRetention.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFinRetention.Location = new Point(350, 209);
            pnlFinRetention.Name = "pnlFinRetention";
            pnlFinRetention.Size = new Size(310, 165);
            pnlFinRetention.TabIndex = 4;
            // 
            // pnlFinCashFlow
            // 
            pnlFinCashFlow.Appearance.BackColor = Color.FromArgb(234, 247, 239);
            pnlFinCashFlow.Appearance.Options.UseBackColor = true;
            pnlFinCashFlow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFinCashFlow.Location = new Point(680, 209);
            pnlFinCashFlow.Name = "pnlFinCashFlow";
            pnlFinCashFlow.Size = new Size(310, 165);
            pnlFinCashFlow.TabIndex = 5;
            // 
            // tabSchedule
            // 
            tabSchedule.Controls.Add(pnlSchedBaseline);
            tabSchedule.Controls.Add(pnlSchedProgress);
            tabSchedule.Controls.Add(lblSchedMilestonesHeader);
            tabSchedule.Controls.Add(lblSchedActivitiesHeader);
            tabSchedule.Controls.Add(grdMilestones);
            tabSchedule.Controls.Add(grdActivities);
            tabSchedule.Name = "tabSchedule";
            tabSchedule.Size = new Size(1364, 489);
            tabSchedule.Text = "الجدول الزمني";
            // 
            // pnlSchedBaseline
            // 
            pnlSchedBaseline.Appearance.BackColor = Color.FromArgb(238, 240, 252);
            pnlSchedBaseline.Appearance.Options.UseBackColor = true;
            pnlSchedBaseline.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlSchedBaseline.Controls.Add(lblSchedBaselineTitle);
            pnlSchedBaseline.Controls.Add(lblSchedBaselineValue);
            pnlSchedBaseline.Location = new Point(20, 15);
            pnlSchedBaseline.Name = "pnlSchedBaseline";
            pnlSchedBaseline.Size = new Size(300, 120);
            pnlSchedBaseline.TabIndex = 0;
            // 
            // lblSchedBaselineTitle
            // 
            lblSchedBaselineTitle.Appearance.Font = new Font("Cairo", 9F);
            lblSchedBaselineTitle.Appearance.ForeColor = Color.FromArgb(91, 79, 207);
            lblSchedBaselineTitle.Appearance.Options.UseFont = true;
            lblSchedBaselineTitle.Appearance.Options.UseForeColor = true;
            lblSchedBaselineTitle.Location = new Point(16, 18);
            lblSchedBaselineTitle.Name = "lblSchedBaselineTitle";
            lblSchedBaselineTitle.Size = new Size(112, 23);
            lblSchedBaselineTitle.TabIndex = 0;
            lblSchedBaselineTitle.Text = "خط الأساس (Baseline)";
            // 
            // lblSchedBaselineValue
            // 
            lblSchedBaselineValue.Appearance.Font = new Font("Cairo", 14F, FontStyle.Bold);
            lblSchedBaselineValue.Appearance.ForeColor = Color.FromArgb(91, 79, 207);
            lblSchedBaselineValue.Appearance.Options.UseFont = true;
            lblSchedBaselineValue.Appearance.Options.UseForeColor = true;
            lblSchedBaselineValue.Location = new Point(16, 52);
            lblSchedBaselineValue.Name = "lblSchedBaselineValue";
            lblSchedBaselineValue.Size = new Size(21, 36);
            lblSchedBaselineValue.TabIndex = 1;
            lblSchedBaselineValue.Text = "—";
            // 
            // pnlSchedProgress
            // 
            pnlSchedProgress.Appearance.BackColor = Color.FromArgb(234, 247, 239);
            pnlSchedProgress.Appearance.Options.UseBackColor = true;
            pnlSchedProgress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlSchedProgress.Controls.Add(lblSchedProgressTitle);
            pnlSchedProgress.Controls.Add(lblSchedProgressValue);
            pnlSchedProgress.Location = new Point(336, 15);
            pnlSchedProgress.Name = "pnlSchedProgress";
            pnlSchedProgress.Size = new Size(300, 120);
            pnlSchedProgress.TabIndex = 1;
            // 
            // lblSchedProgressTitle
            // 
            lblSchedProgressTitle.Appearance.Font = new Font("Cairo", 9F);
            lblSchedProgressTitle.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblSchedProgressTitle.Appearance.Options.UseFont = true;
            lblSchedProgressTitle.Appearance.Options.UseForeColor = true;
            lblSchedProgressTitle.Location = new Point(16, 18);
            lblSchedProgressTitle.Name = "lblSchedProgressTitle";
            lblSchedProgressTitle.Size = new Size(55, 23);
            lblSchedProgressTitle.TabIndex = 0;
            lblSchedProgressTitle.Text = "نسبة الإنجاز";
            // 
            // lblSchedProgressValue
            // 
            lblSchedProgressValue.Appearance.Font = new Font("Cairo", 14F, FontStyle.Bold);
            lblSchedProgressValue.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblSchedProgressValue.Appearance.Options.UseFont = true;
            lblSchedProgressValue.Appearance.Options.UseForeColor = true;
            lblSchedProgressValue.Location = new Point(16, 52);
            lblSchedProgressValue.Name = "lblSchedProgressValue";
            lblSchedProgressValue.Size = new Size(21, 36);
            lblSchedProgressValue.TabIndex = 1;
            lblSchedProgressValue.Text = "—";
            // 
            // lblSchedMilestonesHeader
            // 
            lblSchedMilestonesHeader.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblSchedMilestonesHeader.Appearance.ForeColor = Color.FromArgb(13, 31, 70);
            lblSchedMilestonesHeader.Appearance.Options.UseFont = true;
            lblSchedMilestonesHeader.Appearance.Options.UseForeColor = true;
            lblSchedMilestonesHeader.Location = new Point(20, 152);
            lblSchedMilestonesHeader.Name = "lblSchedMilestonesHeader";
            lblSchedMilestonesHeader.Size = new Size(87, 23);
            lblSchedMilestonesHeader.TabIndex = 2;
            lblSchedMilestonesHeader.Text = "المعالم الرئيسية";
            // 
            // lblSchedActivitiesHeader
            // 
            lblSchedActivitiesHeader.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblSchedActivitiesHeader.Appearance.ForeColor = Color.FromArgb(13, 31, 70);
            lblSchedActivitiesHeader.Appearance.Options.UseFont = true;
            lblSchedActivitiesHeader.Appearance.Options.UseForeColor = true;
            lblSchedActivitiesHeader.Location = new Point(692, 149);
            lblSchedActivitiesHeader.Name = "lblSchedActivitiesHeader";
            lblSchedActivitiesHeader.Size = new Size(44, 23);
            lblSchedActivitiesHeader.TabIndex = 3;
            lblSchedActivitiesHeader.Text = "الأنشطة";
            // 
            // grdMilestones
            // 
            grdMilestones.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdMilestones.Location = new Point(20, 178);
            grdMilestones.MainView = gvMilestones;
            grdMilestones.Name = "grdMilestones";
            grdMilestones.Size = new Size(650, 294);
            grdMilestones.TabIndex = 4;
            grdMilestones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvMilestones });
            // 
            // gvMilestones
            // 
            gvMilestones.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvMilestones.Appearance.HeaderPanel.Options.UseFont = true;
            gvMilestones.Appearance.Row.Font = new Font("Cairo", 8F);
            gvMilestones.Appearance.Row.Options.UseFont = true;
            gvMilestones.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colMilestoneName, colMilestonePlanned, colMilestoneActual, colMilestoneStatus });
            gvMilestones.DetailHeight = 349;
            gvMilestones.GridControl = grdMilestones;
            gvMilestones.Name = "gvMilestones";
            gvMilestones.OptionsView.ShowGroupPanel = false;
            // 
            // colMilestoneName
            // 
            colMilestoneName.Caption = "المعلم";
            colMilestoneName.FieldName = "MilestoneName";
            colMilestoneName.Name = "colMilestoneName";
            colMilestoneName.Visible = true;
            colMilestoneName.VisibleIndex = 0;
            colMilestoneName.Width = 240;
            // 
            // colMilestonePlanned
            // 
            colMilestonePlanned.Caption = "التاريخ المخطط";
            colMilestonePlanned.DisplayFormat.FormatString = "d";
            colMilestonePlanned.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colMilestonePlanned.FieldName = "PlannedDate";
            colMilestonePlanned.Name = "colMilestonePlanned";
            colMilestonePlanned.Visible = true;
            colMilestonePlanned.VisibleIndex = 1;
            colMilestonePlanned.Width = 130;
            // 
            // colMilestoneActual
            // 
            colMilestoneActual.Caption = "التاريخ الفعلي";
            colMilestoneActual.DisplayFormat.FormatString = "d";
            colMilestoneActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colMilestoneActual.FieldName = "ActualDate";
            colMilestoneActual.Name = "colMilestoneActual";
            colMilestoneActual.Visible = true;
            colMilestoneActual.VisibleIndex = 2;
            colMilestoneActual.Width = 130;
            // 
            // colMilestoneStatus
            // 
            colMilestoneStatus.Caption = "الحالة";
            colMilestoneStatus.FieldName = "Status";
            colMilestoneStatus.Name = "colMilestoneStatus";
            colMilestoneStatus.Visible = true;
            colMilestoneStatus.VisibleIndex = 3;
            colMilestoneStatus.Width = 120;
            // 
            // grdActivities
            // 
            grdActivities.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdActivities.Location = new Point(692, 178);
            grdActivities.MainView = gvActivities;
            grdActivities.Name = "grdActivities";
            grdActivities.Size = new Size(648, 294);
            grdActivities.TabIndex = 5;
            grdActivities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvActivities });
            // 
            // gvActivities
            // 
            gvActivities.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvActivities.Appearance.HeaderPanel.Options.UseFont = true;
            gvActivities.Appearance.Row.Font = new Font("Cairo", 8F);
            gvActivities.Appearance.Row.Options.UseFont = true;
            gvActivities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colActivityName, colActivityStart, colActivityFinish, colActivityProgress });
            gvActivities.DetailHeight = 349;
            gvActivities.GridControl = grdActivities;
            gvActivities.Name = "gvActivities";
            gvActivities.OptionsView.ShowGroupPanel = false;
            // 
            // colActivityName
            // 
            colActivityName.Caption = "النشاط";
            colActivityName.FieldName = "ActivityName";
            colActivityName.Name = "colActivityName";
            colActivityName.Visible = true;
            colActivityName.VisibleIndex = 0;
            colActivityName.Width = 240;
            // 
            // colActivityStart
            // 
            colActivityStart.Caption = "البداية";
            colActivityStart.DisplayFormat.FormatString = "d";
            colActivityStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colActivityStart.FieldName = "StartDate";
            colActivityStart.Name = "colActivityStart";
            colActivityStart.Visible = true;
            colActivityStart.VisibleIndex = 1;
            colActivityStart.Width = 120;
            // 
            // colActivityFinish
            // 
            colActivityFinish.Caption = "النهاية";
            colActivityFinish.DisplayFormat.FormatString = "d";
            colActivityFinish.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colActivityFinish.FieldName = "FinishDate";
            colActivityFinish.Name = "colActivityFinish";
            colActivityFinish.Visible = true;
            colActivityFinish.VisibleIndex = 2;
            colActivityFinish.Width = 120;
            // 
            // colActivityProgress
            // 
            colActivityProgress.Caption = "التقدم %";
            colActivityProgress.DisplayFormat.FormatString = "N0";
            colActivityProgress.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colActivityProgress.FieldName = "ProgressPercent";
            colActivityProgress.Name = "colActivityProgress";
            colActivityProgress.Visible = true;
            colActivityProgress.VisibleIndex = 3;
            colActivityProgress.Width = 100;
            // 
            // tabOrganization
            // 
            tabOrganization.Controls.Add(lblDepartments);
            tabOrganization.Controls.Add(grdDepartments);
            tabOrganization.Controls.Add(lblCostCenters);
            tabOrganization.Controls.Add(grdCostCenters);
            tabOrganization.Controls.Add(lblWbs);
            tabOrganization.Controls.Add(grdWbs);
            tabOrganization.Controls.Add(lblCbs);
            tabOrganization.Controls.Add(grdCbs);
            tabOrganization.Name = "tabOrganization";
            tabOrganization.Size = new Size(1364, 489);
            tabOrganization.Text = "الهيكل التنظيمي";
            // 
            // lblDepartments
            // 
            lblDepartments.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblDepartments.Appearance.ForeColor = Color.FromArgb(13, 31, 70);
            lblDepartments.Appearance.Options.UseFont = true;
            lblDepartments.Appearance.Options.UseForeColor = true;
            lblDepartments.Location = new Point(20, 15);
            lblDepartments.Name = "lblDepartments";
            lblDepartments.Size = new Size(43, 23);
            lblDepartments.TabIndex = 0;
            lblDepartments.Text = "الأقسام";
            // 
            // grdDepartments
            // 
            grdDepartments.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdDepartments.Location = new Point(20, 45);
            grdDepartments.MainView = gvDepartments;
            grdDepartments.Name = "grdDepartments";
            grdDepartments.Size = new Size(400, 200);
            grdDepartments.TabIndex = 1;
            grdDepartments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvDepartments });
            // 
            // gvDepartments
            // 
            gvDepartments.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvDepartments.Appearance.HeaderPanel.Options.UseFont = true;
            gvDepartments.Appearance.Row.Font = new Font("Cairo", 8F);
            gvDepartments.Appearance.Row.Options.UseFont = true;
            gvDepartments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDepartmentName });
            gvDepartments.DetailHeight = 349;
            gvDepartments.GridControl = grdDepartments;
            gvDepartments.Name = "gvDepartments";
            gvDepartments.OptionsView.ShowGroupPanel = false;
            // 
            // colDepartmentName
            // 
            colDepartmentName.Caption = "اسم القسم";
            colDepartmentName.FieldName = "Name";
            colDepartmentName.Name = "colDepartmentName";
            colDepartmentName.Visible = true;
            colDepartmentName.VisibleIndex = 0;
            colDepartmentName.Width = 360;
            // 
            // lblCostCenters
            // 
            lblCostCenters.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblCostCenters.Appearance.ForeColor = Color.FromArgb(13, 31, 70);
            lblCostCenters.Appearance.Options.UseFont = true;
            lblCostCenters.Appearance.Options.UseForeColor = true;
            lblCostCenters.Location = new Point(440, 15);
            lblCostCenters.Name = "lblCostCenters";
            lblCostCenters.Size = new Size(71, 23);
            lblCostCenters.TabIndex = 2;
            lblCostCenters.Text = "مراكز التكلفة";
            // 
            // grdCostCenters
            // 
            grdCostCenters.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdCostCenters.Location = new Point(440, 45);
            grdCostCenters.MainView = gvCostCenters;
            grdCostCenters.Name = "grdCostCenters";
            grdCostCenters.Size = new Size(400, 200);
            grdCostCenters.TabIndex = 3;
            grdCostCenters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCostCenters });
            // 
            // gvCostCenters
            // 
            gvCostCenters.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvCostCenters.Appearance.HeaderPanel.Options.UseFont = true;
            gvCostCenters.Appearance.Row.Font = new Font("Cairo", 8F);
            gvCostCenters.Appearance.Row.Options.UseFont = true;
            gvCostCenters.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCostCenterName });
            gvCostCenters.DetailHeight = 349;
            gvCostCenters.GridControl = grdCostCenters;
            gvCostCenters.Name = "gvCostCenters";
            gvCostCenters.OptionsView.ShowGroupPanel = false;
            // 
            // colCostCenterName
            // 
            colCostCenterName.Caption = "اسم مركز التكلفة";
            colCostCenterName.FieldName = "Name";
            colCostCenterName.Name = "colCostCenterName";
            colCostCenterName.Visible = true;
            colCostCenterName.VisibleIndex = 0;
            colCostCenterName.Width = 360;
            // 
            // lblWbs
            // 
            lblWbs.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblWbs.Appearance.ForeColor = Color.FromArgb(13, 31, 70);
            lblWbs.Appearance.Options.UseFont = true;
            lblWbs.Appearance.Options.UseForeColor = true;
            lblWbs.Location = new Point(20, 262);
            lblWbs.Name = "lblWbs";
            lblWbs.Size = new Size(108, 23);
            lblWbs.TabIndex = 4;
            lblWbs.Text = "هيكل الأعمال (WBS)";
            // 
            // grdWbs
            // 
            grdWbs.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdWbs.Location = new Point(20, 289);
            grdWbs.MainView = gvWbs;
            grdWbs.Name = "grdWbs";
            grdWbs.Size = new Size(400, 200);
            grdWbs.TabIndex = 5;
            grdWbs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvWbs });
            // 
            // gvWbs
            // 
            gvWbs.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvWbs.Appearance.HeaderPanel.Options.UseFont = true;
            gvWbs.Appearance.Row.Font = new Font("Cairo", 8F);
            gvWbs.Appearance.Row.Options.UseFont = true;
            gvWbs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colWbsName });
            gvWbs.DetailHeight = 349;
            gvWbs.GridControl = grdWbs;
            gvWbs.Name = "gvWbs";
            gvWbs.OptionsView.ShowGroupPanel = false;
            // 
            // colWbsName
            // 
            colWbsName.Caption = "بند هيكل الأعمال";
            colWbsName.FieldName = "Name";
            colWbsName.Name = "colWbsName";
            colWbsName.Visible = true;
            colWbsName.VisibleIndex = 0;
            colWbsName.Width = 360;
            // 
            // lblCbs
            // 
            lblCbs.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblCbs.Appearance.ForeColor = Color.FromArgb(13, 31, 70);
            lblCbs.Appearance.Options.UseFont = true;
            lblCbs.Appearance.Options.UseForeColor = true;
            lblCbs.Location = new Point(440, 262);
            lblCbs.Name = "lblCbs";
            lblCbs.Size = new Size(104, 23);
            lblCbs.TabIndex = 6;
            lblCbs.Text = "هيكل التكلفة (CBS)";
            // 
            // grdCbs
            // 
            grdCbs.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdCbs.Location = new Point(440, 289);
            grdCbs.MainView = gvCbs;
            grdCbs.Name = "grdCbs";
            grdCbs.Size = new Size(400, 200);
            grdCbs.TabIndex = 7;
            grdCbs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCbs });
            // 
            // gvCbs
            // 
            gvCbs.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvCbs.Appearance.HeaderPanel.Options.UseFont = true;
            gvCbs.Appearance.Row.Font = new Font("Cairo", 8F);
            gvCbs.Appearance.Row.Options.UseFont = true;
            gvCbs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCbsName });
            gvCbs.DetailHeight = 349;
            gvCbs.GridControl = grdCbs;
            gvCbs.Name = "gvCbs";
            gvCbs.OptionsView.ShowGroupPanel = false;
            // 
            // colCbsName
            // 
            colCbsName.Caption = "بند هيكل التكلفة";
            colCbsName.FieldName = "Name";
            colCbsName.Name = "colCbsName";
            colCbsName.Visible = true;
            colCbsName.VisibleIndex = 0;
            colCbsName.Width = 360;
            // 
            // tabDocuments
            // 
            tabDocuments.Controls.Add(grdDetailDocuments);
            tabDocuments.Name = "tabDocuments";
            tabDocuments.Size = new Size(1364, 489);
            tabDocuments.Text = "المستندات";
            // 
            // grdDetailDocuments
            // 
            grdDetailDocuments.Location = new Point(20, 15);
            grdDetailDocuments.MainView = gvDetailDocuments;
            grdDetailDocuments.Name = "grdDetailDocuments";
            grdDetailDocuments.Size = new Size(1324, 458);
            grdDetailDocuments.TabIndex = 0;
            grdDetailDocuments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvDetailDocuments });
            // 
            // gvDetailDocuments
            // 
            gvDetailDocuments.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvDetailDocuments.Appearance.HeaderPanel.Options.UseFont = true;
            gvDetailDocuments.Appearance.Row.Font = new Font("Cairo", 8F);
            gvDetailDocuments.Appearance.Row.Options.UseFont = true;
            gvDetailDocuments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDocNo, colDocTitle, colDocRevision, colDocDiscipline, colDocStatus });
            gvDetailDocuments.DetailHeight = 349;
            gvDetailDocuments.GridControl = grdDetailDocuments;
            gvDetailDocuments.Name = "gvDetailDocuments";
            gvDetailDocuments.OptionsView.ShowAutoFilterRow = true;
            gvDetailDocuments.OptionsView.ShowGroupPanel = false;
            // 
            // colDocNo
            // 
            colDocNo.Caption = "رقم المستند";
            colDocNo.FieldName = "DocumentNo";
            colDocNo.Name = "colDocNo";
            colDocNo.Visible = true;
            colDocNo.VisibleIndex = 0;
            colDocNo.Width = 140;
            // 
            // colDocTitle
            // 
            colDocTitle.Caption = "العنوان";
            colDocTitle.FieldName = "Title";
            colDocTitle.Name = "colDocTitle";
            colDocTitle.Visible = true;
            colDocTitle.VisibleIndex = 1;
            colDocTitle.Width = 500;
            // 
            // colDocRevision
            // 
            colDocRevision.Caption = "المراجعة";
            colDocRevision.FieldName = "Revision";
            colDocRevision.Name = "colDocRevision";
            colDocRevision.Visible = true;
            colDocRevision.VisibleIndex = 2;
            colDocRevision.Width = 100;
            // 
            // colDocDiscipline
            // 
            colDocDiscipline.Caption = "التخصص";
            colDocDiscipline.FieldName = "Discipline";
            colDocDiscipline.Name = "colDocDiscipline";
            colDocDiscipline.Visible = true;
            colDocDiscipline.VisibleIndex = 3;
            colDocDiscipline.Width = 160;
            // 
            // colDocStatus
            // 
            colDocStatus.Caption = "الحالة";
            colDocStatus.FieldName = "Status";
            colDocStatus.Name = "colDocStatus";
            colDocStatus.Visible = true;
            colDocStatus.VisibleIndex = 4;
            colDocStatus.Width = 130;
            // 
            // tabContacts
            // 
            tabContacts.Controls.Add(grdContacts);
            tabContacts.Name = "tabContacts";
            tabContacts.Size = new Size(1364, 489);
            tabContacts.Text = "جهات الاتصال";
            // 
            // grdContacts
            // 
            grdContacts.Location = new Point(20, 15);
            grdContacts.MainView = gvContacts;
            grdContacts.Name = "grdContacts";
            grdContacts.Size = new Size(1324, 458);
            grdContacts.TabIndex = 0;
            grdContacts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvContacts });
            // 
            // gvContacts
            // 
            gvContacts.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvContacts.Appearance.HeaderPanel.Options.UseFont = true;
            gvContacts.Appearance.Row.Font = new Font("Cairo", 8F);
            gvContacts.Appearance.Row.Options.UseFont = true;
            gvContacts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colContactName, colContactCompany, colContactRole, colContactPhone, colContactEmail });
            gvContacts.DetailHeight = 349;
            gvContacts.GridControl = grdContacts;
            gvContacts.Name = "gvContacts";
            gvContacts.OptionsView.ShowAutoFilterRow = true;
            gvContacts.OptionsView.ShowGroupPanel = false;
            // 
            // colContactName
            // 
            colContactName.Caption = "الاسم";
            colContactName.FieldName = "ContactName";
            colContactName.Name = "colContactName";
            colContactName.Visible = true;
            colContactName.VisibleIndex = 0;
            colContactName.Width = 220;
            // 
            // colContactCompany
            // 
            colContactCompany.Caption = "الجهة";
            colContactCompany.FieldName = "Company";
            colContactCompany.Name = "colContactCompany";
            colContactCompany.Visible = true;
            colContactCompany.VisibleIndex = 1;
            colContactCompany.Width = 260;
            // 
            // colContactRole
            // 
            colContactRole.Caption = "الدور";
            colContactRole.FieldName = "Role";
            colContactRole.Name = "colContactRole";
            colContactRole.Visible = true;
            colContactRole.VisibleIndex = 2;
            colContactRole.Width = 180;
            // 
            // colContactPhone
            // 
            colContactPhone.Caption = "الهاتف";
            colContactPhone.FieldName = "Phone";
            colContactPhone.Name = "colContactPhone";
            colContactPhone.Visible = true;
            colContactPhone.VisibleIndex = 3;
            colContactPhone.Width = 160;
            // 
            // colContactEmail
            // 
            colContactEmail.Caption = "البريد الإلكتروني";
            colContactEmail.FieldName = "Email";
            colContactEmail.Name = "colContactEmail";
            colContactEmail.Visible = true;
            colContactEmail.VisibleIndex = 4;
            colContactEmail.Width = 260;
            // 
            // tabKPIs
            // 
            tabKPIs.Controls.Add(pnlKpiSpi);
            tabKPIs.Controls.Add(pnlKpiCpi);
            tabKPIs.Controls.Add(pnlKpiProgressDetail);
            tabKPIs.Controls.Add(pnlKpiQuality);
            tabKPIs.Controls.Add(pnlKpiSafety);
            tabKPIs.Controls.Add(pnlKpiCash);
            tabKPIs.Controls.Add(pnlKpiForecastDetail);
            tabKPIs.Name = "tabKPIs";
            tabKPIs.Size = new Size(1364, 489);
            tabKPIs.Text = "مؤشرات الأداء";
            // 
            // pnlKpiSpi
            // 
            pnlKpiSpi.Appearance.BackColor = Color.FromArgb(234, 243, 252);
            pnlKpiSpi.Appearance.Options.UseBackColor = true;
            pnlKpiSpi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiSpi.Location = new Point(20, 25);
            pnlKpiSpi.Name = "pnlKpiSpi";
            pnlKpiSpi.Size = new Size(305, 165);
            pnlKpiSpi.TabIndex = 0;
            // 
            // pnlKpiCpi
            // 
            pnlKpiCpi.Appearance.BackColor = Color.FromArgb(234, 247, 239);
            pnlKpiCpi.Appearance.Options.UseBackColor = true;
            pnlKpiCpi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCpi.Location = new Point(345, 25);
            pnlKpiCpi.Name = "pnlKpiCpi";
            pnlKpiCpi.Size = new Size(305, 165);
            pnlKpiCpi.TabIndex = 1;
            // 
            // pnlKpiProgressDetail
            // 
            pnlKpiProgressDetail.Appearance.BackColor = Color.FromArgb(238, 241, 243);
            pnlKpiProgressDetail.Appearance.Options.UseBackColor = true;
            pnlKpiProgressDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiProgressDetail.Location = new Point(670, 25);
            pnlKpiProgressDetail.Name = "pnlKpiProgressDetail";
            pnlKpiProgressDetail.Size = new Size(305, 165);
            pnlKpiProgressDetail.TabIndex = 2;
            // 
            // pnlKpiQuality
            // 
            pnlKpiQuality.Appearance.BackColor = Color.FromArgb(243, 236, 251);
            pnlKpiQuality.Appearance.Options.UseBackColor = true;
            pnlKpiQuality.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiQuality.Location = new Point(995, 25);
            pnlKpiQuality.Name = "pnlKpiQuality";
            pnlKpiQuality.Size = new Size(305, 165);
            pnlKpiQuality.TabIndex = 3;
            // 
            // pnlKpiSafety
            // 
            pnlKpiSafety.Appearance.BackColor = Color.FromArgb(253, 237, 236);
            pnlKpiSafety.Appearance.Options.UseBackColor = true;
            pnlKpiSafety.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiSafety.Location = new Point(20, 209);
            pnlKpiSafety.Name = "pnlKpiSafety";
            pnlKpiSafety.Size = new Size(305, 165);
            pnlKpiSafety.TabIndex = 4;
            // 
            // pnlKpiCash
            // 
            pnlKpiCash.Appearance.BackColor = Color.FromArgb(255, 246, 229);
            pnlKpiCash.Appearance.Options.UseBackColor = true;
            pnlKpiCash.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCash.Location = new Point(345, 209);
            pnlKpiCash.Name = "pnlKpiCash";
            pnlKpiCash.Size = new Size(305, 165);
            pnlKpiCash.TabIndex = 5;
            // 
            // pnlKpiForecastDetail
            // 
            pnlKpiForecastDetail.Appearance.BackColor = Color.FromArgb(238, 240, 252);
            pnlKpiForecastDetail.Appearance.Options.UseBackColor = true;
            pnlKpiForecastDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiForecastDetail.Location = new Point(670, 209);
            pnlKpiForecastDetail.Name = "pnlKpiForecastDetail";
            pnlKpiForecastDetail.Size = new Size(305, 165);
            pnlKpiForecastDetail.TabIndex = 6;
            // 
            // tabAttachments
            // 
            tabAttachments.Controls.Add(btnUploadAttachment);
            tabAttachments.Controls.Add(grdAttachments);
            tabAttachments.Name = "tabAttachments";
            tabAttachments.Size = new Size(1364, 489);
            tabAttachments.Text = "المرفقات";
            // 
            // btnUploadAttachment
            // 
            btnUploadAttachment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnUploadAttachment.ImageOptions.SvgImage");
            btnUploadAttachment.Location = new Point(20, 15);
            btnUploadAttachment.Name = "btnUploadAttachment";
            btnUploadAttachment.Size = new Size(150, 40);
            btnUploadAttachment.TabIndex = 0;
            btnUploadAttachment.Text = "رفع مرفق";
            btnUploadAttachment.Click += btnUploadAttachment_Click;
            // 
            // grdAttachments
            // 
            grdAttachments.Location = new Point(20, 68);
            grdAttachments.MainView = gvAttachments;
            grdAttachments.Name = "grdAttachments";
            grdAttachments.Size = new Size(1324, 406);
            grdAttachments.TabIndex = 1;
            grdAttachments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvAttachments });
            // 
            // gvAttachments
            // 
            gvAttachments.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvAttachments.Appearance.HeaderPanel.Options.UseFont = true;
            gvAttachments.Appearance.Row.Font = new Font("Cairo", 8F);
            gvAttachments.Appearance.Row.Options.UseFont = true;
            gvAttachments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colAttachmentName, colAttachmentType, colAttachmentSize, colAttachmentUploadedBy, colAttachmentDate });
            gvAttachments.DetailHeight = 349;
            gvAttachments.GridControl = grdAttachments;
            gvAttachments.Name = "gvAttachments";
            gvAttachments.OptionsView.ShowAutoFilterRow = true;
            gvAttachments.OptionsView.ShowGroupPanel = false;
            // 
            // colAttachmentName
            // 
            colAttachmentName.Caption = "اسم الملف";
            colAttachmentName.FieldName = "FileName";
            colAttachmentName.Name = "colAttachmentName";
            colAttachmentName.Visible = true;
            colAttachmentName.VisibleIndex = 0;
            colAttachmentName.Width = 420;
            // 
            // colAttachmentType
            // 
            colAttachmentType.Caption = "النوع";
            colAttachmentType.FieldName = "FileType";
            colAttachmentType.Name = "colAttachmentType";
            colAttachmentType.Visible = true;
            colAttachmentType.VisibleIndex = 1;
            colAttachmentType.Width = 120;
            // 
            // colAttachmentSize
            // 
            colAttachmentSize.Caption = "الحجم";
            colAttachmentSize.FieldName = "FileSize";
            colAttachmentSize.Name = "colAttachmentSize";
            colAttachmentSize.Visible = true;
            colAttachmentSize.VisibleIndex = 2;
            colAttachmentSize.Width = 110;
            // 
            // colAttachmentUploadedBy
            // 
            colAttachmentUploadedBy.Caption = "رفع بواسطة";
            colAttachmentUploadedBy.FieldName = "UploadedBy";
            colAttachmentUploadedBy.Name = "colAttachmentUploadedBy";
            colAttachmentUploadedBy.Visible = true;
            colAttachmentUploadedBy.VisibleIndex = 3;
            colAttachmentUploadedBy.Width = 180;
            // 
            // colAttachmentDate
            // 
            colAttachmentDate.Caption = "تاريخ الرفع";
            colAttachmentDate.DisplayFormat.FormatString = "g";
            colAttachmentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colAttachmentDate.FieldName = "UploadDate";
            colAttachmentDate.Name = "colAttachmentDate";
            colAttachmentDate.Visible = true;
            colAttachmentDate.VisibleIndex = 4;
            colAttachmentDate.Width = 160;
            // 
            // tabHistory
            // 
            tabHistory.Controls.Add(grdHistory);
            tabHistory.Name = "tabHistory";
            tabHistory.Size = new Size(1364, 489);
            tabHistory.Text = "السجل";
            // 
            // grdHistory
            // 
            grdHistory.Location = new Point(20, 15);
            grdHistory.MainView = gvHistory;
            grdHistory.Name = "grdHistory";
            grdHistory.Size = new Size(1324, 458);
            grdHistory.TabIndex = 0;
            grdHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvHistory });
            // 
            // gvHistory
            // 
            gvHistory.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvHistory.Appearance.HeaderPanel.Options.UseFont = true;
            gvHistory.Appearance.Row.Font = new Font("Cairo", 8F);
            gvHistory.Appearance.Row.Options.UseFont = true;
            gvHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colHistoryDate, colHistoryUser, colHistoryAction, colHistoryDetails });
            gvHistory.DetailHeight = 349;
            gvHistory.GridControl = grdHistory;
            gvHistory.Name = "gvHistory";
            gvHistory.OptionsView.ShowAutoFilterRow = true;
            gvHistory.OptionsView.ShowGroupPanel = false;
            // 
            // colHistoryDate
            // 
            colHistoryDate.Caption = "التاريخ";
            colHistoryDate.DisplayFormat.FormatString = "g";
            colHistoryDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colHistoryDate.FieldName = "ActionDate";
            colHistoryDate.Name = "colHistoryDate";
            colHistoryDate.Visible = true;
            colHistoryDate.VisibleIndex = 0;
            colHistoryDate.Width = 160;
            // 
            // colHistoryUser
            // 
            colHistoryUser.Caption = "المستخدم";
            colHistoryUser.FieldName = "UserName";
            colHistoryUser.Name = "colHistoryUser";
            colHistoryUser.Visible = true;
            colHistoryUser.VisibleIndex = 1;
            colHistoryUser.Width = 200;
            // 
            // colHistoryAction
            // 
            colHistoryAction.Caption = "الإجراء";
            colHistoryAction.FieldName = "Action";
            colHistoryAction.Name = "colHistoryAction";
            colHistoryAction.Visible = true;
            colHistoryAction.VisibleIndex = 2;
            colHistoryAction.Width = 200;
            // 
            // colHistoryDetails
            // 
            colHistoryDetails.Caption = "التفاصيل";
            colHistoryDetails.FieldName = "Details";
            colHistoryDetails.Name = "colHistoryDetails";
            colHistoryDetails.Visible = true;
            colHistoryDetails.VisibleIndex = 3;
            colHistoryDetails.Width = 600;
            // 
            // tabAudit
            // 
            tabAudit.Controls.Add(grdAudit);
            tabAudit.Name = "tabAudit";
            tabAudit.Size = new Size(1364, 489);
            tabAudit.Text = "التدقيق";
            // 
            // grdAudit
            // 
            grdAudit.Location = new Point(20, 15);
            grdAudit.MainView = gvAudit;
            grdAudit.Name = "grdAudit";
            grdAudit.Size = new Size(1324, 458);
            grdAudit.TabIndex = 0;
            grdAudit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvAudit });
            // 
            // gvAudit
            // 
            gvAudit.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvAudit.Appearance.HeaderPanel.Options.UseFont = true;
            gvAudit.Appearance.Row.Font = new Font("Cairo", 8F);
            gvAudit.Appearance.Row.Options.UseFont = true;
            gvAudit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colAuditDate, colAuditUser, colAuditField, colAuditOldValue, colAuditNewValue });
            gvAudit.DetailHeight = 349;
            gvAudit.GridControl = grdAudit;
            gvAudit.Name = "gvAudit";
            gvAudit.OptionsView.ShowAutoFilterRow = true;
            gvAudit.OptionsView.ShowGroupPanel = false;
            // 
            // colAuditDate
            // 
            colAuditDate.Caption = "التاريخ";
            colAuditDate.DisplayFormat.FormatString = "g";
            colAuditDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colAuditDate.FieldName = "ActionDate";
            colAuditDate.Name = "colAuditDate";
            colAuditDate.Visible = true;
            colAuditDate.VisibleIndex = 0;
            colAuditDate.Width = 160;
            // 
            // colAuditUser
            // 
            colAuditUser.Caption = "المستخدم";
            colAuditUser.FieldName = "UserName";
            colAuditUser.Name = "colAuditUser";
            colAuditUser.Visible = true;
            colAuditUser.VisibleIndex = 1;
            colAuditUser.Width = 180;
            // 
            // colAuditField
            // 
            colAuditField.Caption = "الحقل";
            colAuditField.FieldName = "FieldName";
            colAuditField.Name = "colAuditField";
            colAuditField.Visible = true;
            colAuditField.VisibleIndex = 2;
            colAuditField.Width = 200;
            // 
            // colAuditOldValue
            // 
            colAuditOldValue.Caption = "القيمة القديمة";
            colAuditOldValue.FieldName = "OldValue";
            colAuditOldValue.Name = "colAuditOldValue";
            colAuditOldValue.Visible = true;
            colAuditOldValue.VisibleIndex = 3;
            colAuditOldValue.Width = 280;
            // 
            // colAuditNewValue
            // 
            colAuditNewValue.Caption = "القيمة الجديدة";
            colAuditNewValue.FieldName = "NewValue";
            colAuditNewValue.Name = "colAuditNewValue";
            colAuditNewValue.Visible = true;
            colAuditNewValue.VisibleIndex = 4;
            colAuditNewValue.Width = 280;
            // 
            // lblFinContractTitle
            // 
            lblFinContractTitle.Appearance.Font = new Font("Cairo", 9F);
            lblFinContractTitle.Appearance.ForeColor = Color.FromArgb(91, 79, 207);
            lblFinContractTitle.Appearance.Options.UseFont = true;
            lblFinContractTitle.Appearance.Options.UseForeColor = true;
            lblFinContractTitle.Location = new Point(16, 18);
            lblFinContractTitle.Name = "lblFinContractTitle";
            lblFinContractTitle.Size = new Size(278, 23);
            lblFinContractTitle.TabIndex = 0;
            lblFinContractTitle.Text = "قيمة العقد";
            // 
            // lblFinContractValue
            // 
            lblFinContractValue.Appearance.Font = new Font("Cairo", 17F, FontStyle.Bold);
            lblFinContractValue.Appearance.ForeColor = Color.FromArgb(91, 79, 207);
            lblFinContractValue.Appearance.Options.UseFont = true;
            lblFinContractValue.Appearance.Options.UseForeColor = true;
            lblFinContractValue.Location = new Point(16, 60);
            lblFinContractValue.Name = "lblFinContractValue";
            lblFinContractValue.Size = new Size(278, 44);
            lblFinContractValue.TabIndex = 1;
            lblFinContractValue.Text = "—";
            // 
            // lblFinBudgetTitle
            // 
            lblFinBudgetTitle.Appearance.Font = new Font("Cairo", 9F);
            lblFinBudgetTitle.Appearance.ForeColor = Color.FromArgb(28, 140, 140);
            lblFinBudgetTitle.Appearance.Options.UseFont = true;
            lblFinBudgetTitle.Appearance.Options.UseForeColor = true;
            lblFinBudgetTitle.Location = new Point(16, 18);
            lblFinBudgetTitle.Name = "lblFinBudgetTitle";
            lblFinBudgetTitle.Size = new Size(278, 23);
            lblFinBudgetTitle.TabIndex = 0;
            lblFinBudgetTitle.Text = "الموازنة";
            // 
            // lblFinBudgetValue
            // 
            lblFinBudgetValue.Appearance.Font = new Font("Cairo", 17F, FontStyle.Bold);
            lblFinBudgetValue.Appearance.ForeColor = Color.FromArgb(28, 140, 140);
            lblFinBudgetValue.Appearance.Options.UseFont = true;
            lblFinBudgetValue.Appearance.Options.UseForeColor = true;
            lblFinBudgetValue.Location = new Point(16, 60);
            lblFinBudgetValue.Name = "lblFinBudgetValue";
            lblFinBudgetValue.Size = new Size(278, 44);
            lblFinBudgetValue.TabIndex = 1;
            lblFinBudgetValue.Text = "—";
            // 
            // lblFinActualTitle
            // 
            lblFinActualTitle.Appearance.Font = new Font("Cairo", 9F);
            lblFinActualTitle.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblFinActualTitle.Appearance.Options.UseFont = true;
            lblFinActualTitle.Appearance.Options.UseForeColor = true;
            lblFinActualTitle.Location = new Point(16, 18);
            lblFinActualTitle.Name = "lblFinActualTitle";
            lblFinActualTitle.Size = new Size(278, 23);
            lblFinActualTitle.TabIndex = 0;
            lblFinActualTitle.Text = "التكلفة الفعلية";
            // 
            // lblFinActualValue
            // 
            lblFinActualValue.Appearance.Font = new Font("Cairo", 17F, FontStyle.Bold);
            lblFinActualValue.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblFinActualValue.Appearance.Options.UseFont = true;
            lblFinActualValue.Appearance.Options.UseForeColor = true;
            lblFinActualValue.Location = new Point(16, 60);
            lblFinActualValue.Name = "lblFinActualValue";
            lblFinActualValue.Size = new Size(278, 44);
            lblFinActualValue.TabIndex = 1;
            lblFinActualValue.Text = "—";
            // 
            // lblFinForecastTitle
            // 
            lblFinForecastTitle.Appearance.Font = new Font("Cairo", 9F);
            lblFinForecastTitle.Appearance.ForeColor = Color.FromArgb(123, 79, 166);
            lblFinForecastTitle.Appearance.Options.UseFont = true;
            lblFinForecastTitle.Appearance.Options.UseForeColor = true;
            lblFinForecastTitle.Location = new Point(16, 18);
            lblFinForecastTitle.Name = "lblFinForecastTitle";
            lblFinForecastTitle.Size = new Size(278, 23);
            lblFinForecastTitle.TabIndex = 0;
            lblFinForecastTitle.Text = "التكلفة المتوقعة";
            // 
            // lblFinForecastValue
            // 
            lblFinForecastValue.Appearance.Font = new Font("Cairo", 17F, FontStyle.Bold);
            lblFinForecastValue.Appearance.ForeColor = Color.FromArgb(123, 79, 166);
            lblFinForecastValue.Appearance.Options.UseFont = true;
            lblFinForecastValue.Appearance.Options.UseForeColor = true;
            lblFinForecastValue.Location = new Point(16, 60);
            lblFinForecastValue.Name = "lblFinForecastValue";
            lblFinForecastValue.Size = new Size(278, 44);
            lblFinForecastValue.TabIndex = 1;
            lblFinForecastValue.Text = "—";
            // 
            // lblFinRetentionTitle
            // 
            lblFinRetentionTitle.Appearance.Font = new Font("Cairo", 9F);
            lblFinRetentionTitle.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblFinRetentionTitle.Appearance.Options.UseFont = true;
            lblFinRetentionTitle.Appearance.Options.UseForeColor = true;
            lblFinRetentionTitle.Location = new Point(16, 18);
            lblFinRetentionTitle.Name = "lblFinRetentionTitle";
            lblFinRetentionTitle.Size = new Size(278, 23);
            lblFinRetentionTitle.TabIndex = 0;
            lblFinRetentionTitle.Text = "الضمان المحتجز";
            // 
            // lblFinRetentionValue
            // 
            lblFinRetentionValue.Appearance.Font = new Font("Cairo", 17F, FontStyle.Bold);
            lblFinRetentionValue.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblFinRetentionValue.Appearance.Options.UseFont = true;
            lblFinRetentionValue.Appearance.Options.UseForeColor = true;
            lblFinRetentionValue.Location = new Point(16, 60);
            lblFinRetentionValue.Name = "lblFinRetentionValue";
            lblFinRetentionValue.Size = new Size(278, 44);
            lblFinRetentionValue.TabIndex = 1;
            lblFinRetentionValue.Text = "—";
            // 
            // lblFinCashFlowTitle
            // 
            lblFinCashFlowTitle.Appearance.Font = new Font("Cairo", 9F);
            lblFinCashFlowTitle.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblFinCashFlowTitle.Appearance.Options.UseFont = true;
            lblFinCashFlowTitle.Appearance.Options.UseForeColor = true;
            lblFinCashFlowTitle.Location = new Point(16, 18);
            lblFinCashFlowTitle.Name = "lblFinCashFlowTitle";
            lblFinCashFlowTitle.Size = new Size(278, 23);
            lblFinCashFlowTitle.TabIndex = 0;
            lblFinCashFlowTitle.Text = "التدفق النقدي";
            // 
            // lblFinCashFlowValue
            // 
            lblFinCashFlowValue.Appearance.Font = new Font("Cairo", 17F, FontStyle.Bold);
            lblFinCashFlowValue.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblFinCashFlowValue.Appearance.Options.UseFont = true;
            lblFinCashFlowValue.Appearance.Options.UseForeColor = true;
            lblFinCashFlowValue.Location = new Point(16, 60);
            lblFinCashFlowValue.Name = "lblFinCashFlowValue";
            lblFinCashFlowValue.Size = new Size(278, 44);
            lblFinCashFlowValue.TabIndex = 1;
            lblFinCashFlowValue.Text = "—";
            // 
            // lblKpiSpiTitle
            // 
            lblKpiSpiTitle.Appearance.Font = new Font("Cairo", 9F);
            lblKpiSpiTitle.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblKpiSpiTitle.Appearance.Options.UseFont = true;
            lblKpiSpiTitle.Appearance.Options.UseForeColor = true;
            lblKpiSpiTitle.Location = new Point(16, 18);
            lblKpiSpiTitle.Name = "lblKpiSpiTitle";
            lblKpiSpiTitle.Size = new Size(273, 23);
            lblKpiSpiTitle.TabIndex = 0;
            lblKpiSpiTitle.Text = "مؤشر أداء الجدول (SPI)";
            // 
            // lblKpiSpiValue
            // 
            lblKpiSpiValue.Appearance.Font = new Font("Cairo", 20F, FontStyle.Bold);
            lblKpiSpiValue.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblKpiSpiValue.Appearance.Options.UseFont = true;
            lblKpiSpiValue.Appearance.Options.UseForeColor = true;
            lblKpiSpiValue.Location = new Point(16, 58);
            lblKpiSpiValue.Name = "lblKpiSpiValue";
            lblKpiSpiValue.Size = new Size(273, 52);
            lblKpiSpiValue.TabIndex = 1;
            lblKpiSpiValue.Text = "—";
            // 
            // lblKpiCpiTitle
            // 
            lblKpiCpiTitle.Appearance.Font = new Font("Cairo", 9F);
            lblKpiCpiTitle.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblKpiCpiTitle.Appearance.Options.UseFont = true;
            lblKpiCpiTitle.Appearance.Options.UseForeColor = true;
            lblKpiCpiTitle.Location = new Point(16, 18);
            lblKpiCpiTitle.Name = "lblKpiCpiTitle";
            lblKpiCpiTitle.Size = new Size(273, 23);
            lblKpiCpiTitle.TabIndex = 0;
            lblKpiCpiTitle.Text = "مؤشر أداء التكلفة (CPI)";
            // 
            // lblKpiCpiValue
            // 
            lblKpiCpiValue.Appearance.Font = new Font("Cairo", 20F, FontStyle.Bold);
            lblKpiCpiValue.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblKpiCpiValue.Appearance.Options.UseFont = true;
            lblKpiCpiValue.Appearance.Options.UseForeColor = true;
            lblKpiCpiValue.Location = new Point(16, 58);
            lblKpiCpiValue.Name = "lblKpiCpiValue";
            lblKpiCpiValue.Size = new Size(273, 52);
            lblKpiCpiValue.TabIndex = 1;
            lblKpiCpiValue.Text = "—";
            // 
            // lblKpiProgressDetailTitle
            // 
            lblKpiProgressDetailTitle.Appearance.Font = new Font("Cairo", 9F);
            lblKpiProgressDetailTitle.Appearance.ForeColor = Color.FromArgb(69, 80, 92);
            lblKpiProgressDetailTitle.Appearance.Options.UseFont = true;
            lblKpiProgressDetailTitle.Appearance.Options.UseForeColor = true;
            lblKpiProgressDetailTitle.Location = new Point(16, 18);
            lblKpiProgressDetailTitle.Name = "lblKpiProgressDetailTitle";
            lblKpiProgressDetailTitle.Size = new Size(273, 23);
            lblKpiProgressDetailTitle.TabIndex = 0;
            lblKpiProgressDetailTitle.Text = "نسبة الإنجاز";
            // 
            // lblKpiProgressDetailValue
            // 
            lblKpiProgressDetailValue.Appearance.Font = new Font("Cairo", 20F, FontStyle.Bold);
            lblKpiProgressDetailValue.Appearance.ForeColor = Color.FromArgb(69, 80, 92);
            lblKpiProgressDetailValue.Appearance.Options.UseFont = true;
            lblKpiProgressDetailValue.Appearance.Options.UseForeColor = true;
            lblKpiProgressDetailValue.Location = new Point(16, 58);
            lblKpiProgressDetailValue.Name = "lblKpiProgressDetailValue";
            lblKpiProgressDetailValue.Size = new Size(273, 52);
            lblKpiProgressDetailValue.TabIndex = 1;
            lblKpiProgressDetailValue.Text = "—";
            // 
            // lblKpiQualityTitle
            // 
            lblKpiQualityTitle.Appearance.Font = new Font("Cairo", 9F);
            lblKpiQualityTitle.Appearance.ForeColor = Color.FromArgb(123, 79, 166);
            lblKpiQualityTitle.Appearance.Options.UseFont = true;
            lblKpiQualityTitle.Appearance.Options.UseForeColor = true;
            lblKpiQualityTitle.Location = new Point(16, 18);
            lblKpiQualityTitle.Name = "lblKpiQualityTitle";
            lblKpiQualityTitle.Size = new Size(273, 23);
            lblKpiQualityTitle.TabIndex = 0;
            lblKpiQualityTitle.Text = "الجودة";
            // 
            // lblKpiQualityValue
            // 
            lblKpiQualityValue.Appearance.Font = new Font("Cairo", 20F, FontStyle.Bold);
            lblKpiQualityValue.Appearance.ForeColor = Color.FromArgb(123, 79, 166);
            lblKpiQualityValue.Appearance.Options.UseFont = true;
            lblKpiQualityValue.Appearance.Options.UseForeColor = true;
            lblKpiQualityValue.Location = new Point(16, 58);
            lblKpiQualityValue.Name = "lblKpiQualityValue";
            lblKpiQualityValue.Size = new Size(273, 52);
            lblKpiQualityValue.TabIndex = 1;
            lblKpiQualityValue.Text = "—";
            // 
            // lblKpiSafetyTitle
            // 
            lblKpiSafetyTitle.Appearance.Font = new Font("Cairo", 9F);
            lblKpiSafetyTitle.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblKpiSafetyTitle.Appearance.Options.UseFont = true;
            lblKpiSafetyTitle.Appearance.Options.UseForeColor = true;
            lblKpiSafetyTitle.Location = new Point(16, 18);
            lblKpiSafetyTitle.Name = "lblKpiSafetyTitle";
            lblKpiSafetyTitle.Size = new Size(273, 23);
            lblKpiSafetyTitle.TabIndex = 0;
            lblKpiSafetyTitle.Text = "السلامة";
            // 
            // lblKpiSafetyValue
            // 
            lblKpiSafetyValue.Appearance.Font = new Font("Cairo", 20F, FontStyle.Bold);
            lblKpiSafetyValue.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblKpiSafetyValue.Appearance.Options.UseFont = true;
            lblKpiSafetyValue.Appearance.Options.UseForeColor = true;
            lblKpiSafetyValue.Location = new Point(16, 58);
            lblKpiSafetyValue.Name = "lblKpiSafetyValue";
            lblKpiSafetyValue.Size = new Size(273, 52);
            lblKpiSafetyValue.TabIndex = 1;
            lblKpiSafetyValue.Text = "—";
            // 
            // lblKpiCashTitle
            // 
            lblKpiCashTitle.Appearance.Font = new Font("Cairo", 9F);
            lblKpiCashTitle.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblKpiCashTitle.Appearance.Options.UseFont = true;
            lblKpiCashTitle.Appearance.Options.UseForeColor = true;
            lblKpiCashTitle.Location = new Point(16, 18);
            lblKpiCashTitle.Name = "lblKpiCashTitle";
            lblKpiCashTitle.Size = new Size(273, 23);
            lblKpiCashTitle.TabIndex = 0;
            lblKpiCashTitle.Text = "التدفق النقدي";
            // 
            // lblKpiCashValue
            // 
            lblKpiCashValue.Appearance.Font = new Font("Cairo", 20F, FontStyle.Bold);
            lblKpiCashValue.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblKpiCashValue.Appearance.Options.UseFont = true;
            lblKpiCashValue.Appearance.Options.UseForeColor = true;
            lblKpiCashValue.Location = new Point(16, 58);
            lblKpiCashValue.Name = "lblKpiCashValue";
            lblKpiCashValue.Size = new Size(273, 52);
            lblKpiCashValue.TabIndex = 1;
            lblKpiCashValue.Text = "—";
            // 
            // lblKpiForecastDetailTitle
            // 
            lblKpiForecastDetailTitle.Appearance.Font = new Font("Cairo", 9F);
            lblKpiForecastDetailTitle.Appearance.ForeColor = Color.FromArgb(91, 79, 207);
            lblKpiForecastDetailTitle.Appearance.Options.UseFont = true;
            lblKpiForecastDetailTitle.Appearance.Options.UseForeColor = true;
            lblKpiForecastDetailTitle.Location = new Point(16, 18);
            lblKpiForecastDetailTitle.Name = "lblKpiForecastDetailTitle";
            lblKpiForecastDetailTitle.Size = new Size(273, 23);
            lblKpiForecastDetailTitle.TabIndex = 0;
            lblKpiForecastDetailTitle.Text = "التكلفة المتوقعة عند الإنجاز";
            // 
            // lblKpiForecastDetailValue
            // 
            lblKpiForecastDetailValue.Appearance.Font = new Font("Cairo", 20F, FontStyle.Bold);
            lblKpiForecastDetailValue.Appearance.ForeColor = Color.FromArgb(91, 79, 207);
            lblKpiForecastDetailValue.Appearance.Options.UseFont = true;
            lblKpiForecastDetailValue.Appearance.Options.UseForeColor = true;
            lblKpiForecastDetailValue.Location = new Point(16, 58);
            lblKpiForecastDetailValue.Name = "lblKpiForecastDetailValue";
            lblKpiForecastDetailValue.Size = new Size(273, 52);
            lblKpiForecastDetailValue.TabIndex = 1;
            lblKpiForecastDetailValue.Text = "—";
            // 
            // pnlLoadingState
            // 
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 272);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 528);
            pnlLoadingState.TabIndex = 3;
            pnlLoadingState.Visible = false;
            // 
            // svgLoadingIcon
            // 
            svgLoadingIcon.Location = new Point(651, 340);
            svgLoadingIcon.Name = "svgLoadingIcon";
            svgLoadingIcon.Size = new Size(64, 98);
            svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            svgLoadingIcon.TabIndex = 0;
            // 
            // lblLoadingText
            // 
            lblLoadingText.Appearance.Font = new Font("Cairo", 10F);
            lblLoadingText.Appearance.Options.UseFont = true;
            lblLoadingText.Appearance.Options.UseTextOptions = true;
            lblLoadingText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblLoadingText.Location = new Point(583, 448);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(162, 26);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل بيانات المشروع...";
            // 
            // pnlEmptyState
            // 
            pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Controls.Add(lblEmptyText);
            pnlEmptyState.Dock = DockStyle.Fill;
            pnlEmptyState.Location = new Point(0, 272);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 528);
            pnlEmptyState.TabIndex = 4;
            pnlEmptyState.Visible = false;
            // 
            // svgEmptyIcon
            // 
            svgEmptyIcon.Location = new Point(651, 340);
            svgEmptyIcon.Name = "svgEmptyIcon";
            svgEmptyIcon.Size = new Size(64, 98);
            svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            svgEmptyIcon.TabIndex = 0;
            // 
            // lblEmptyText
            // 
            lblEmptyText.Appearance.Font = new Font("Cairo", 10F);
            lblEmptyText.Appearance.Options.UseFont = true;
            lblEmptyText.Appearance.Options.UseTextOptions = true;
            lblEmptyText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyText.Location = new Point(583, 448);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(161, 26);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا توجد بيانات مشروع لعرضها";
            // 
            // pnlErrorState
            // 
            pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Controls.Add(lblErrorText);
            pnlErrorState.Controls.Add(btnRetry);
            pnlErrorState.Dock = DockStyle.Fill;
            pnlErrorState.Location = new Point(0, 272);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 528);
            pnlErrorState.TabIndex = 5;
            pnlErrorState.Visible = false;
            // 
            // svgErrorIcon
            // 
            svgErrorIcon.Location = new Point(651, 320);
            svgErrorIcon.Name = "svgErrorIcon";
            svgErrorIcon.Size = new Size(64, 98);
            svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            svgErrorIcon.TabIndex = 0;
            // 
            // lblErrorText
            // 
            lblErrorText.Appearance.Font = new Font("Cairo", 10F);
            lblErrorText.Appearance.Options.UseFont = true;
            lblErrorText.Appearance.Options.UseTextOptions = true;
            lblErrorText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblErrorText.Location = new Point(583, 428);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(202, 26);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل بيانات المشروع";
            // 
            // btnRetry
            // 
            btnRetry.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnRetry.ImageOptions.SvgImage");
            btnRetry.Location = new Point(633, 465);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(100, 43);
            btnRetry.TabIndex = 2;
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;
            // 
            // ucProjectDetails
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabProjectDetails);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlApprovalBanner);
            Controls.Add(pnlProjectHeader);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucProjectDetails";
            RightToLeft = RightToLeft.Yes;
            //RightToLeftLayout = true;
            Size = new Size(1366, 800);
            ((System.ComponentModel.ISupportInitialize)barManagerDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlProjectHeader).EndInit();
            pnlProjectHeader.ResumeLayout(false);
            pnlProjectHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)peProjectPhoto.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlApprovalBanner).EndInit();
            pnlApprovalBanner.ResumeLayout(false);
            pnlApprovalBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tabProjectDetails).EndInit();
            tabProjectDetails.ResumeLayout(false);
            tabGeneral.ResumeLayout(false);
            tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)peProjectImageLarge.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCompanyLogo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbeGenType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)teGenLocation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)deGenStartDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)deGenStartDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)deGenEndDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)deGenEndDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)teGenDuration.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)teGenValue.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)meGenDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueOwnerGeneral.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueConsultantGeneral.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueContractorGeneral.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLocationMap).EndInit();
            pnlLocationMap.ResumeLayout(false);
            pnlLocationMap.PerformLayout();
            tabFinancial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFinContract).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinRetention).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFinCashFlow).EndInit();
            tabSchedule.ResumeLayout(false);
            tabSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSchedBaseline).EndInit();
            pnlSchedBaseline.ResumeLayout(false);
            pnlSchedBaseline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSchedProgress).EndInit();
            pnlSchedProgress.ResumeLayout(false);
            pnlSchedProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdMilestones).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvMilestones).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdActivities).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvActivities).EndInit();
            tabOrganization.ResumeLayout(false);
            tabOrganization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdDepartments).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvDepartments).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdCostCenters).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCostCenters).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdWbs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvWbs).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdCbs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCbs).EndInit();
            tabDocuments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdDetailDocuments).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvDetailDocuments).EndInit();
            tabContacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdContacts).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvContacts).EndInit();
            tabKPIs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiSpi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCpi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiProgressDetail).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiQuality).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiSafety).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCash).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecastDetail).EndInit();
            tabAttachments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdAttachments).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvAttachments).EndInit();
            tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvHistory).EndInit();
            tabAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdAudit).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvAudit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit();
            pnlLoadingState.ResumeLayout(false);
            pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit();
            pnlEmptyState.ResumeLayout(false);
            pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit();
            pnlErrorState.ResumeLayout(false);
            pnlErrorState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        // ── Financial card helper (called from code-behind, NOT from InitializeComponent) ──
        private void SetupFinCard(
            DevExpress.XtraEditors.PanelControl pnl,
            DevExpress.XtraEditors.LabelControl lTitle,
            DevExpress.XtraEditors.LabelControl lValue,
            Color bg, Color fg, string title, int x, int y, int tabIdx)
        {
            const int cW = 310, cH = 165;
            pnl.Appearance.BackColor = bg;
            pnl.Appearance.Options.UseBackColor = true;
            pnl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnl.Controls.Add(lTitle);
            pnl.Controls.Add(lValue);
            pnl.Location = new Point(x, y);
            pnl.Size = new Size(cW, cH);
            pnl.TabIndex = tabIdx;

            lTitle.Appearance.Font = new Font("Cairo", 9F);
            lTitle.Appearance.ForeColor = fg;
            lTitle.Appearance.Options.UseFont = true;
            lTitle.Appearance.Options.UseForeColor = true;
            lTitle.Location = new Point(16, 18);
            lTitle.Size = new Size(cW - 32, 23);
            lTitle.TabIndex = 0;
            lTitle.Text = title;

            lValue.Appearance.Font = new Font("Cairo", 17F, FontStyle.Bold);
            lValue.Appearance.ForeColor = fg;
            lValue.Appearance.Options.UseFont = true;
            lValue.Appearance.Options.UseForeColor = true;
            lValue.Location = new Point(16, 60);
            lValue.Size = new Size(cW - 32, 44);
            lValue.TabIndex = 1;
            lValue.Text = "\u2014";
        }

        // ── Bar ──
        private DevExpress.XtraBars.BarManager barManagerDetails;
        private DevExpress.XtraBars.Bar barHeader;
        private DevExpress.XtraBars.BarButtonItem bbiEdit, bbiSave, bbiCancelEdit, bbiPrint, bbiExportPdf;
        private DevExpress.XtraBars.BarDockControl barDockControlTop, barDockControlBottom, barDockControlLeft, barDockControlRight;
        // ── Header ──
        private DevExpress.XtraEditors.PanelControl pnlProjectHeader;
        private DevExpress.XtraEditors.PictureEdit peProjectPhoto;
        private DevExpress.XtraEditors.LabelControl lblProjectNameValue, lblProjectCodeValue, lblProjectStatusBadge, lblEditModeIndicator;
        private DevExpress.XtraEditors.LabelControl lblHeaderStartLabel, lblHeaderStartValue;
        private DevExpress.XtraEditors.LabelControl lblHeaderEndLabel, lblHeaderEndValue;
        private DevExpress.XtraEditors.LabelControl lblHeaderProgressLabel, lblHeaderProgressValue;
        // ── Approval ──
        private DevExpress.XtraEditors.PanelControl pnlApprovalBanner;
        private DevExpress.XtraEditors.LabelControl lblApprovalText;
        private DevExpress.XtraEditors.SimpleButton btnApprove, btnReject;
        // ── Tabs ──
        private DevExpress.XtraTab.XtraTabControl tabProjectDetails;
        // General
        private DevExpress.XtraTab.XtraTabPage tabGeneral;
        private DevExpress.XtraEditors.PictureEdit peProjectImageLarge, picCompanyLogo;
        private DevExpress.XtraEditors.LabelControl lblGenSectionInfo, lblGenType, lblGenLocation;
        private DevExpress.XtraEditors.LabelControl lblGenStartDate, lblGenEndDate, lblGenDuration, lblGenValue, lblGenDescription;
        private DevExpress.XtraEditors.ComboBoxEdit cbeGenType;
        private DevExpress.XtraEditors.TextEdit teGenLocation, teGenDuration, teGenValue;
        private DevExpress.XtraEditors.DateEdit deGenStartDate, deGenEndDate;
        private DevExpress.XtraEditors.MemoEdit meGenDescription;
        private DevExpress.XtraEditors.LabelControl lblGenSectionParties, lblOwnerTitle, lblConsultantTitle, lblContractorTitle;
        private DevExpress.XtraEditors.LookUpEdit lueOwnerGeneral, lueConsultantGeneral, lueContractorGeneral;
        private DevExpress.XtraEditors.PanelControl pnlLocationMap;
        private DevExpress.XtraEditors.LabelControl lblLocationMapPlaceholder;
        // Financial
        private DevExpress.XtraTab.XtraTabPage tabFinancial;
        private DevExpress.XtraEditors.PanelControl pnlFinContract, pnlFinBudget, pnlFinActual, pnlFinForecast, pnlFinRetention, pnlFinCashFlow;
        private DevExpress.XtraEditors.LabelControl lblFinContractTitle, lblFinContractValue;
        private DevExpress.XtraEditors.LabelControl lblFinBudgetTitle, lblFinBudgetValue;
        private DevExpress.XtraEditors.LabelControl lblFinActualTitle, lblFinActualValue;
        private DevExpress.XtraEditors.LabelControl lblFinForecastTitle, lblFinForecastValue;
        private DevExpress.XtraEditors.LabelControl lblFinRetentionTitle, lblFinRetentionValue;
        private DevExpress.XtraEditors.LabelControl lblFinCashFlowTitle, lblFinCashFlowValue;
        // Schedule
        private DevExpress.XtraTab.XtraTabPage tabSchedule;
        private DevExpress.XtraEditors.PanelControl pnlSchedBaseline, pnlSchedProgress;
        private DevExpress.XtraEditors.LabelControl lblSchedBaselineTitle, lblSchedBaselineValue;
        private DevExpress.XtraEditors.LabelControl lblSchedProgressTitle, lblSchedProgressValue;
        private DevExpress.XtraEditors.LabelControl lblSchedMilestonesHeader, lblSchedActivitiesHeader;
        private DevExpress.XtraGrid.GridControl grdMilestones, grdActivities;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMilestones, gvActivities;
        private DevExpress.XtraGrid.Columns.GridColumn colMilestoneName, colMilestonePlanned, colMilestoneActual, colMilestoneStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityName, colActivityStart, colActivityFinish, colActivityProgress;
        // Organization
        private DevExpress.XtraTab.XtraTabPage tabOrganization;
        private DevExpress.XtraEditors.LabelControl lblDepartments, lblCostCenters, lblWbs, lblCbs;
        private DevExpress.XtraGrid.GridControl grdDepartments, grdCostCenters, grdWbs, grdCbs;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDepartments, gvCostCenters, gvWbs, gvCbs;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName, colCostCenterName, colWbsName, colCbsName;
        // Documents
        private DevExpress.XtraTab.XtraTabPage tabDocuments;
        private DevExpress.XtraGrid.GridControl grdDetailDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetailDocuments;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNo, colDocTitle, colDocRevision, colDocDiscipline, colDocStatus;
        // Contacts
        private DevExpress.XtraTab.XtraTabPage tabContacts;
        private DevExpress.XtraGrid.GridControl grdContacts;
        private DevExpress.XtraGrid.Views.Grid.GridView gvContacts;
        private DevExpress.XtraGrid.Columns.GridColumn colContactName, colContactCompany, colContactRole, colContactPhone, colContactEmail;
        // KPIs
        private DevExpress.XtraTab.XtraTabPage tabKPIs;
        private DevExpress.XtraEditors.PanelControl pnlKpiSpi, pnlKpiCpi, pnlKpiProgressDetail, pnlKpiQuality;
        private DevExpress.XtraEditors.PanelControl pnlKpiSafety, pnlKpiCash, pnlKpiForecastDetail;
        private DevExpress.XtraEditors.LabelControl lblKpiSpiTitle, lblKpiSpiValue;
        private DevExpress.XtraEditors.LabelControl lblKpiCpiTitle, lblKpiCpiValue;
        private DevExpress.XtraEditors.LabelControl lblKpiProgressDetailTitle, lblKpiProgressDetailValue;
        private DevExpress.XtraEditors.LabelControl lblKpiQualityTitle, lblKpiQualityValue;
        private DevExpress.XtraEditors.LabelControl lblKpiSafetyTitle, lblKpiSafetyValue;
        private DevExpress.XtraEditors.LabelControl lblKpiCashTitle, lblKpiCashValue;
        private DevExpress.XtraEditors.LabelControl lblKpiForecastDetailTitle, lblKpiForecastDetailValue;
        // Attachments
        private DevExpress.XtraTab.XtraTabPage tabAttachments;
        private DevExpress.XtraEditors.SimpleButton btnUploadAttachment;
        private DevExpress.XtraGrid.GridControl grdAttachments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAttachments;
        private DevExpress.XtraGrid.Columns.GridColumn colAttachmentName, colAttachmentType, colAttachmentSize, colAttachmentUploadedBy, colAttachmentDate;
        // History
        private DevExpress.XtraTab.XtraTabPage tabHistory;
        private DevExpress.XtraGrid.GridControl grdHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHistory;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryDate, colHistoryUser, colHistoryAction, colHistoryDetails;
        // Audit
        private DevExpress.XtraTab.XtraTabPage tabAudit;
        private DevExpress.XtraGrid.GridControl grdAudit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAudit;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditDate, colAuditUser, colAuditField, colAuditOldValue, colAuditNewValue;
        // State panels
        private DevExpress.XtraEditors.PanelControl pnlLoadingState, pnlEmptyState, pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon, svgEmptyIcon, svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText, lblEmptyText, lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}
