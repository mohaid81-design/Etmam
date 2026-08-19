namespace Etmam
{
    partial class ucBudgetEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBudgetEditor));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            colTotalCost = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiAddItem = new DevExpress.XtraBars.BarButtonItem();
            bbiAddGroup = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiDuplicate = new DevExpress.XtraBars.BarButtonItem();
            bbiImportBOQ = new DevExpress.XtraBars.BarButtonItem();
            bbiImportExcel = new DevExpress.XtraBars.BarButtonItem();
            bbiValidate = new DevExpress.XtraBars.BarButtonItem();
            bbiSave = new DevExpress.XtraBars.BarButtonItem();
            bbiApprove = new DevExpress.XtraBars.BarButtonItem();
            bbiExpandAll = new DevExpress.XtraBars.BarButtonItem();
            bbiCollapseAll = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiItemCount = new DevExpress.XtraBars.BarStaticItem();
            sbiLastSaved = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            pnlStateBanner = new DevExpress.XtraEditors.PanelControl();
            lblStateBanner = new DevExpress.XtraEditors.LabelControl();
            svgStateBannerIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlBudgetHeader = new DevExpress.XtraEditors.PanelControl();
            lblBudgetCode = new DevExpress.XtraEditors.LabelControl();
            txtBudgetCode = new DevExpress.XtraEditors.TextEdit();
            lblBudgetName = new DevExpress.XtraEditors.LabelControl();
            txtBudgetName = new DevExpress.XtraEditors.TextEdit();
            lblProject = new DevExpress.XtraEditors.LabelControl();
            txtProject = new DevExpress.XtraEditors.TextEdit();
            lblRevision = new DevExpress.XtraEditors.LabelControl();
            txtRevision = new DevExpress.XtraEditors.TextEdit();
            lblBudgetType = new DevExpress.XtraEditors.LabelControl();
            cboBudgetType = new DevExpress.XtraEditors.ComboBoxEdit();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            txtStatus = new DevExpress.XtraEditors.TextEdit();
            lblApprovalLevel = new DevExpress.XtraEditors.LabelControl();
            txtApprovalLevel = new DevExpress.XtraEditors.TextEdit();
            splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            treeCBS = new DevExpress.XtraTreeList.TreeList();
            colCBSCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCBSName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCBSBudget = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            grdBudgetItems = new DevExpress.XtraGrid.GridControl();
            gvBudgetItems = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            bandIdentification = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            colCostCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colUnit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            bandQuantities = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            colBudgetQty = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colUnitCost = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            bandCostDistribution = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            colLabor = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colMaterial = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colEquipment = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colSubcontract = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colIndirectCost = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colContingency = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            bandClassification = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            colRemarks = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            pnlCalculation = new DevExpress.XtraEditors.PanelControl();
            lblTotalBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            lblTotalBudgetValue = new DevExpress.XtraEditors.LabelControl();
            lblLaborCostTitle = new DevExpress.XtraEditors.LabelControl();
            lblLaborCostValue = new DevExpress.XtraEditors.LabelControl();
            lblMaterialCostTitle = new DevExpress.XtraEditors.LabelControl();
            lblMaterialCostValue = new DevExpress.XtraEditors.LabelControl();
            lblEquipmentCostTitle = new DevExpress.XtraEditors.LabelControl();
            lblEquipmentCostValue = new DevExpress.XtraEditors.LabelControl();
            lblSubcontractCostTitle = new DevExpress.XtraEditors.LabelControl();
            lblSubcontractCostValue = new DevExpress.XtraEditors.LabelControl();
            lblOverheadTitle = new DevExpress.XtraEditors.LabelControl();
            lblOverheadValue = new DevExpress.XtraEditors.LabelControl();
            lblProfitMarginTitle = new DevExpress.XtraEditors.LabelControl();
            lblProfitMarginValue = new DevExpress.XtraEditors.LabelControl();
            pnlSummaryFooter = new DevExpress.XtraEditors.PanelControl();
            lblItemCountTitle = new DevExpress.XtraEditors.LabelControl();
            lblItemCountValue = new DevExpress.XtraEditors.LabelControl();
            lblGrandTotalTitle = new DevExpress.XtraEditors.LabelControl();
            lblGrandTotalValue = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)pnlBudgetHeader).BeginInit();
            pnlBudgetHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtBudgetCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBudgetName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRevision.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboBudgetType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtApprovalLevel.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain.Panel1).BeginInit();
            splitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain.Panel2).BeginInit();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeCBS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdBudgetItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvBudgetItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlCalculation).BeginInit();
            pnlCalculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSummaryFooter).BeginInit();
            pnlSummaryFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();
            // 
            // colTotalCost
            // 
            colTotalCost.Name = "colTotalCost";
            // 
            // barManagerMain
            // 
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAddItem, bbiAddGroup, bbiDelete, bbiDuplicate, bbiImportBOQ, bbiImportExcel, bbiValidate, bbiSave, bbiApprove, bbiExpandAll, bbiCollapseAll, sbiItemCount, sbiLastSaved });
            barManagerMain.MainMenu = barMain;
            barManagerMain.MaxItemId = 24;
            barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerMain.StatusBar = barStatus;
            // 
            // barMain
            // 
            barMain.BarName = "شريط أدوات محرر الموازنة";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAddItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAddGroup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDuplicate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiImportBOQ, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiImportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiValidate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiApprove, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExpandAll, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCollapseAll, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.MinHeight = 34;
            barMain.OptionsBar.MultiLine = true;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "شريط أدوات محرر الموازنة";
            // 
            // bbiAddItem
            // 
            bbiAddItem.Id = 13;
            bbiAddItem.Name = "bbiAddItem";
            // 
            // bbiAddGroup
            // 
            bbiAddGroup.Id = 14;
            bbiAddGroup.Name = "bbiAddGroup";
            // 
            // bbiDelete
            // 
            bbiDelete.Id = 15;
            bbiDelete.Name = "bbiDelete";
            // 
            // bbiDuplicate
            // 
            bbiDuplicate.Id = 16;
            bbiDuplicate.Name = "bbiDuplicate";
            // 
            // bbiImportBOQ
            // 
            bbiImportBOQ.Id = 17;
            bbiImportBOQ.Name = "bbiImportBOQ";
            // 
            // bbiImportExcel
            // 
            bbiImportExcel.Id = 18;
            bbiImportExcel.Name = "bbiImportExcel";
            // 
            // bbiValidate
            // 
            bbiValidate.Id = 19;
            bbiValidate.Name = "bbiValidate";
            // 
            // bbiSave
            // 
            bbiSave.Id = 20;
            bbiSave.Name = "bbiSave";
            // 
            // bbiApprove
            // 
            bbiApprove.Id = 21;
            bbiApprove.Name = "bbiApprove";
            // 
            // bbiExpandAll
            // 
            bbiExpandAll.Id = 22;
            bbiExpandAll.Name = "bbiExpandAll";
            // 
            // bbiCollapseAll
            // 
            bbiCollapseAll.Id = 23;
            bbiCollapseAll.Name = "bbiCollapseAll";
            // 
            // barStatus
            // 
            barStatus.BarName = "شريط الحالة";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(sbiItemCount), new DevExpress.XtraBars.LinkPersistInfo(sbiLastSaved) });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "شريط الحالة";
            // 
            // sbiItemCount
            // 
            sbiItemCount.Caption = "عدد البنود: 0";
            sbiItemCount.Id = 11;
            sbiItemCount.Name = "sbiItemCount";
            // 
            // sbiLastSaved
            // 
            sbiLastSaved.Caption = "آخر حفظ: —";
            sbiLastSaved.Id = 12;
            sbiLastSaved.Name = "sbiLastSaved";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerMain;
            barDockControlTop.Size = new Size(1366, 34);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 873);
            barDockControlBottom.Manager = barManagerMain;
            barDockControlBottom.Size = new Size(1366, 29);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerMain;
            barDockControlLeft.Size = new Size(0, 839);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerMain;
            barDockControlRight.Size = new Size(0, 839);
            // 
            // pnlStateBanner
            // 
            pnlStateBanner.Appearance.BackColor = Color.FromArgb(235, 236, 240);
            pnlStateBanner.Appearance.Options.UseBackColor = true;
            pnlStateBanner.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlStateBanner.Controls.Add(lblStateBanner);
            pnlStateBanner.Controls.Add(svgStateBannerIcon);
            pnlStateBanner.Dock = DockStyle.Top;
            pnlStateBanner.Location = new Point(0, 34);
            pnlStateBanner.Name = "pnlStateBanner";
            pnlStateBanner.Size = new Size(1366, 36);
            pnlStateBanner.TabIndex = 10;
            pnlStateBanner.Visible = false;
            // 
            // lblStateBanner
            // 
            lblStateBanner.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblStateBanner.Appearance.ForeColor = Color.FromArgb(90, 100, 115);
            lblStateBanner.Appearance.Options.UseFont = true;
            lblStateBanner.Appearance.Options.UseForeColor = true;
            lblStateBanner.Location = new Point(1150, 8);
            lblStateBanner.Name = "lblStateBanner";
            lblStateBanner.Size = new Size(104, 23);
            lblStateBanner.TabIndex = 0;
            lblStateBanner.Text = "محرر الموازنة مقفل";
            // 
            // svgStateBannerIcon
            // 
            svgStateBannerIcon.Location = new Point(1320, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new Size(24, 24);
            svgStateBannerIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgStateBannerIcon.SvgImage");
            svgStateBannerIcon.TabIndex = 1;
            // 
            // pnlBudgetHeader
            // 
            pnlBudgetHeader.Controls.Add(lblBudgetCode);
            pnlBudgetHeader.Controls.Add(pnlErrorState);
            pnlBudgetHeader.Controls.Add(pnlEmptyState);
            pnlBudgetHeader.Controls.Add(pnlLoadingState);
            pnlBudgetHeader.Controls.Add(txtBudgetCode);
            pnlBudgetHeader.Controls.Add(lblBudgetName);
            pnlBudgetHeader.Controls.Add(txtBudgetName);
            pnlBudgetHeader.Controls.Add(lblProject);
            pnlBudgetHeader.Controls.Add(txtProject);
            pnlBudgetHeader.Controls.Add(lblRevision);
            pnlBudgetHeader.Controls.Add(txtRevision);
            pnlBudgetHeader.Controls.Add(lblBudgetType);
            pnlBudgetHeader.Controls.Add(cboBudgetType);
            pnlBudgetHeader.Controls.Add(lblStatus);
            pnlBudgetHeader.Controls.Add(txtStatus);
            pnlBudgetHeader.Controls.Add(lblApprovalLevel);
            pnlBudgetHeader.Controls.Add(txtApprovalLevel);
            pnlBudgetHeader.Dock = DockStyle.Top;
            pnlBudgetHeader.Location = new Point(0, 70);
            pnlBudgetHeader.Name = "pnlBudgetHeader";
            pnlBudgetHeader.Size = new Size(1366, 115);
            pnlBudgetHeader.TabIndex = 9;
            // 
            // lblBudgetCode
            // 
            lblBudgetCode.Location = new Point(0, 0);
            lblBudgetCode.Name = "lblBudgetCode";
            lblBudgetCode.Size = new Size(0, 20);
            lblBudgetCode.TabIndex = 0;
            // 
            // txtBudgetCode
            // 
            txtBudgetCode.Location = new Point(150, 15);
            txtBudgetCode.Name = "txtBudgetCode";
            txtBudgetCode.Size = new Size(100, 26);
            txtBudgetCode.TabIndex = 1;
            // 
            // lblBudgetName
            // 
            lblBudgetName.Location = new Point(0, 0);
            lblBudgetName.Name = "lblBudgetName";
            lblBudgetName.Size = new Size(0, 20);
            lblBudgetName.TabIndex = 2;
            // 
            // txtBudgetName
            // 
            txtBudgetName.Location = new Point(42, 42);
            txtBudgetName.Name = "txtBudgetName";
            txtBudgetName.Size = new Size(100, 26);
            txtBudgetName.TabIndex = 3;
            // 
            // lblProject
            // 
            lblProject.Location = new Point(0, 0);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(0, 20);
            lblProject.TabIndex = 4;
            // 
            // txtProject
            // 
            txtProject.Location = new Point(42, 84);
            txtProject.Name = "txtProject";
            txtProject.Size = new Size(100, 26);
            txtProject.TabIndex = 5;
            // 
            // lblRevision
            // 
            lblRevision.Location = new Point(0, 0);
            lblRevision.Name = "lblRevision";
            lblRevision.Size = new Size(0, 20);
            lblRevision.TabIndex = 6;
            // 
            // txtRevision
            // 
            txtRevision.Location = new Point(148, 86);
            txtRevision.Name = "txtRevision";
            txtRevision.Size = new Size(100, 26);
            txtRevision.TabIndex = 7;
            // 
            // lblBudgetType
            // 
            lblBudgetType.Location = new Point(0, 0);
            lblBudgetType.Name = "lblBudgetType";
            lblBudgetType.Size = new Size(0, 20);
            lblBudgetType.TabIndex = 8;
            // 
            // cboBudgetType
            // 
            cboBudgetType.Location = new Point(499, 45);
            cboBudgetType.Name = "cboBudgetType";
            cboBudgetType.Properties.Appearance.Font = new Font("Cairo", 9F);
            cboBudgetType.Properties.Appearance.Options.UseFont = true;
            cboBudgetType.Size = new Size(190, 30);
            cboBudgetType.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 10;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(148, 47);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(100, 26);
            txtStatus.TabIndex = 11;
            // 
            // lblApprovalLevel
            // 
            lblApprovalLevel.Location = new Point(0, 0);
            lblApprovalLevel.Name = "lblApprovalLevel";
            lblApprovalLevel.Size = new Size(0, 20);
            lblApprovalLevel.TabIndex = 12;
            // 
            // txtApprovalLevel
            // 
            txtApprovalLevel.Location = new Point(44, 10);
            txtApprovalLevel.Name = "txtApprovalLevel";
            txtApprovalLevel.Size = new Size(100, 26);
            txtApprovalLevel.TabIndex = 13;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 185);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(treeCBS);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(grdBudgetItems);
            splitMain.Size = new Size(1366, 570);
            splitMain.SplitterPosition = 270;
            splitMain.TabIndex = 3;
            // 
            // treeCBS
            // 
            treeCBS.Appearance.Empty.Font = new Font("Cairo", 9F);
            treeCBS.Appearance.Empty.Options.UseFont = true;
            treeCBS.Appearance.FocusedCell.Font = new Font("Cairo", 9F, FontStyle.Bold);
            treeCBS.Appearance.FocusedCell.Options.UseFont = true;
            treeCBS.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            treeCBS.Appearance.HeaderPanel.Options.UseFont = true;
            treeCBS.Appearance.Row.Font = new Font("Cairo", 9F);
            treeCBS.Appearance.Row.Options.UseFont = true;
            treeCBS.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colCBSCode, colCBSName, colCBSBudget });
            treeCBS.Dock = DockStyle.Fill;
            treeCBS.Location = new Point(0, 0);
            treeCBS.Name = "treeCBS";
            treeCBS.OptionsBehavior.Editable = false;
            treeCBS.OptionsView.ShowIndicator = false;
            treeCBS.Size = new Size(270, 570);
            treeCBS.TabIndex = 0;
            // 
            // colCBSCode
            // 
            colCBSCode.Caption = "الكود";
            colCBSCode.FieldName = "Code";
            colCBSCode.Name = "colCBSCode";
            colCBSCode.Visible = true;
            colCBSCode.VisibleIndex = 0;
            colCBSCode.Width = 80;
            // 
            // colCBSName
            // 
            colCBSName.Caption = "الاسم";
            colCBSName.FieldName = "Name";
            colCBSName.Name = "colCBSName";
            colCBSName.Visible = true;
            colCBSName.VisibleIndex = 1;
            colCBSName.Width = 140;
            // 
            // colCBSBudget
            // 
            colCBSBudget.Caption = "الموازنة";
            colCBSBudget.FieldName = "Budget";
            colCBSBudget.Format.FormatString = "N2";
            colCBSBudget.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCBSBudget.Name = "colCBSBudget";
            colCBSBudget.Visible = true;
            colCBSBudget.VisibleIndex = 2;
            colCBSBudget.Width = 90;
            // 
            // grdBudgetItems
            // 
            grdBudgetItems.Dock = DockStyle.Fill;
            grdBudgetItems.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdBudgetItems.Location = new Point(0, 0);
            grdBudgetItems.MainView = gvBudgetItems;
            grdBudgetItems.MenuManager = barManagerMain;
            grdBudgetItems.Name = "grdBudgetItems";
            grdBudgetItems.Size = new Size(1086, 570);
            grdBudgetItems.TabIndex = 0;
            grdBudgetItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvBudgetItems });
            // 
            // gvBudgetItems
            // 
            gvBudgetItems.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvBudgetItems.Appearance.HeaderPanel.Options.UseFont = true;
            gvBudgetItems.Appearance.Row.Font = new Font("Cairo", 8F);
            gvBudgetItems.Appearance.Row.Options.UseFont = true;
            gvBudgetItems.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { bandIdentification, bandQuantities, bandCostDistribution, bandClassification });
            gvBudgetItems.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { colCostCode, colDescription, colUnit, colBudgetQty, colUnitCost, colTotalCost, colLabor, colMaterial, colEquipment, colSubcontract, colIndirectCost, colContingency, colRemarks });
            gridFormatRule1.Column = colTotalCost;
            gridFormatRule1.Name = "ruleOverBudget";
            formatConditionRuleValue1.Appearance.BackColor = Color.FromArgb(255, 220, 220);
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Greater;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gvBudgetItems.FormatRules.Add(gridFormatRule1);
            gvBudgetItems.GridControl = grdBudgetItems;
            gvBudgetItems.Name = "gvBudgetItems";
            gvBudgetItems.OptionsCustomization.AllowRowSizing = true;
            gvBudgetItems.OptionsView.ShowAutoFilterRow = true;
            gvBudgetItems.OptionsView.ShowFooter = true;
            // 
            // bandIdentification
            // 
            bandIdentification.Caption = "التعريف";
            bandIdentification.Columns.Add(colCostCode);
            bandIdentification.Columns.Add(colDescription);
            bandIdentification.Columns.Add(colUnit);
            bandIdentification.Name = "bandIdentification";
            bandIdentification.VisibleIndex = 0;
            bandIdentification.Width = 370;
            // 
            // colCostCode
            // 
            colCostCode.Name = "colCostCode";
            // 
            // colDescription
            // 
            colDescription.Name = "colDescription";
            // 
            // colUnit
            // 
            colUnit.Name = "colUnit";
            // 
            // bandQuantities
            // 
            bandQuantities.Caption = "الكميات";
            bandQuantities.Columns.Add(colBudgetQty);
            bandQuantities.Columns.Add(colUnitCost);
            bandQuantities.Columns.Add(colTotalCost);
            bandQuantities.Name = "bandQuantities";
            bandQuantities.VisibleIndex = 1;
            bandQuantities.Width = 330;
            // 
            // colBudgetQty
            // 
            colBudgetQty.Name = "colBudgetQty";
            // 
            // colUnitCost
            // 
            colUnitCost.Name = "colUnitCost";
            // 
            // bandCostDistribution
            // 
            bandCostDistribution.Caption = "توزيع التكلفة";
            bandCostDistribution.Columns.Add(colLabor);
            bandCostDistribution.Columns.Add(colMaterial);
            bandCostDistribution.Columns.Add(colEquipment);
            bandCostDistribution.Columns.Add(colSubcontract);
            bandCostDistribution.Columns.Add(colIndirectCost);
            bandCostDistribution.Columns.Add(colContingency);
            bandCostDistribution.Name = "bandCostDistribution";
            bandCostDistribution.VisibleIndex = 2;
            bandCostDistribution.Width = 600;
            // 
            // colLabor
            // 
            colLabor.Name = "colLabor";
            // 
            // colMaterial
            // 
            colMaterial.Name = "colMaterial";
            // 
            // colEquipment
            // 
            colEquipment.Name = "colEquipment";
            // 
            // colSubcontract
            // 
            colSubcontract.Name = "colSubcontract";
            // 
            // colIndirectCost
            // 
            colIndirectCost.Name = "colIndirectCost";
            // 
            // colContingency
            // 
            colContingency.Name = "colContingency";
            // 
            // bandClassification
            // 
            bandClassification.Caption = "التصنيف";
            bandClassification.Columns.Add(colRemarks);
            bandClassification.Name = "bandClassification";
            bandClassification.VisibleIndex = 3;
            bandClassification.Width = 150;
            // 
            // colRemarks
            // 
            colRemarks.Name = "colRemarks";
            // 
            // pnlCalculation
            // 
            pnlCalculation.Controls.Add(lblTotalBudgetTitle);
            pnlCalculation.Controls.Add(lblTotalBudgetValue);
            pnlCalculation.Controls.Add(lblLaborCostTitle);
            pnlCalculation.Controls.Add(lblLaborCostValue);
            pnlCalculation.Controls.Add(lblMaterialCostTitle);
            pnlCalculation.Controls.Add(lblMaterialCostValue);
            pnlCalculation.Controls.Add(lblEquipmentCostTitle);
            pnlCalculation.Controls.Add(lblEquipmentCostValue);
            pnlCalculation.Controls.Add(lblSubcontractCostTitle);
            pnlCalculation.Controls.Add(lblSubcontractCostValue);
            pnlCalculation.Controls.Add(lblOverheadTitle);
            pnlCalculation.Controls.Add(lblOverheadValue);
            pnlCalculation.Controls.Add(lblProfitMarginTitle);
            pnlCalculation.Controls.Add(lblProfitMarginValue);
            pnlCalculation.Dock = DockStyle.Bottom;
            pnlCalculation.Location = new Point(0, 755);
            pnlCalculation.Name = "pnlCalculation";
            pnlCalculation.Size = new Size(1366, 90);
            pnlCalculation.TabIndex = 7;
            // 
            // lblTotalBudgetTitle
            // 
            lblTotalBudgetTitle.Appearance.Font = new Font("Cairo", 8F);
            lblTotalBudgetTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalBudgetTitle.Appearance.Options.UseFont = true;
            lblTotalBudgetTitle.Appearance.Options.UseForeColor = true;
            lblTotalBudgetTitle.Location = new Point(1182, 12);
            lblTotalBudgetTitle.Name = "lblTotalBudgetTitle";
            lblTotalBudgetTitle.Size = new Size(66, 20);
            lblTotalBudgetTitle.TabIndex = 0;
            lblTotalBudgetTitle.Text = "إجمالي الموازنة";
            // 
            // lblTotalBudgetValue
            // 
            lblTotalBudgetValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblTotalBudgetValue.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblTotalBudgetValue.Appearance.Options.UseFont = true;
            lblTotalBudgetValue.Appearance.Options.UseForeColor = true;
            lblTotalBudgetValue.Location = new Point(1182, 40);
            lblTotalBudgetValue.Name = "lblTotalBudgetValue";
            lblTotalBudgetValue.Size = new Size(20, 34);
            lblTotalBudgetValue.TabIndex = 1;
            lblTotalBudgetValue.Text = "—";
            // 
            // lblLaborCostTitle
            // 
            lblLaborCostTitle.Appearance.Font = new Font("Cairo", 8F);
            lblLaborCostTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblLaborCostTitle.Appearance.Options.UseFont = true;
            lblLaborCostTitle.Appearance.Options.UseForeColor = true;
            lblLaborCostTitle.Location = new Point(987, 12);
            lblLaborCostTitle.Name = "lblLaborCostTitle";
            lblLaborCostTitle.Size = new Size(60, 20);
            lblLaborCostTitle.TabIndex = 2;
            lblLaborCostTitle.Text = "تكلفة العمالة";
            // 
            // lblLaborCostValue
            // 
            lblLaborCostValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblLaborCostValue.Appearance.ForeColor = Color.FromArgb(255, 127, 14);
            lblLaborCostValue.Appearance.Options.UseFont = true;
            lblLaborCostValue.Appearance.Options.UseForeColor = true;
            lblLaborCostValue.Location = new Point(987, 40);
            lblLaborCostValue.Name = "lblLaborCostValue";
            lblLaborCostValue.Size = new Size(20, 34);
            lblLaborCostValue.TabIndex = 3;
            lblLaborCostValue.Text = "—";
            // 
            // lblMaterialCostTitle
            // 
            lblMaterialCostTitle.Appearance.Font = new Font("Cairo", 8F);
            lblMaterialCostTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblMaterialCostTitle.Appearance.Options.UseFont = true;
            lblMaterialCostTitle.Appearance.Options.UseForeColor = true;
            lblMaterialCostTitle.Location = new Point(792, 12);
            lblMaterialCostTitle.Name = "lblMaterialCostTitle";
            lblMaterialCostTitle.Size = new Size(55, 20);
            lblMaterialCostTitle.TabIndex = 4;
            lblMaterialCostTitle.Text = "تكلفة المواد";
            // 
            // lblMaterialCostValue
            // 
            lblMaterialCostValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblMaterialCostValue.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblMaterialCostValue.Appearance.Options.UseFont = true;
            lblMaterialCostValue.Appearance.Options.UseForeColor = true;
            lblMaterialCostValue.Location = new Point(792, 40);
            lblMaterialCostValue.Name = "lblMaterialCostValue";
            lblMaterialCostValue.Size = new Size(20, 34);
            lblMaterialCostValue.TabIndex = 5;
            lblMaterialCostValue.Text = "—";
            // 
            // lblEquipmentCostTitle
            // 
            lblEquipmentCostTitle.Appearance.Font = new Font("Cairo", 8F);
            lblEquipmentCostTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblEquipmentCostTitle.Appearance.Options.UseFont = true;
            lblEquipmentCostTitle.Appearance.Options.UseForeColor = true;
            lblEquipmentCostTitle.Location = new Point(597, 12);
            lblEquipmentCostTitle.Name = "lblEquipmentCostTitle";
            lblEquipmentCostTitle.Size = new Size(66, 20);
            lblEquipmentCostTitle.TabIndex = 6;
            lblEquipmentCostTitle.Text = "تكلفة المعدات";
            // 
            // lblEquipmentCostValue
            // 
            lblEquipmentCostValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblEquipmentCostValue.Appearance.ForeColor = Color.FromArgb(148, 103, 189);
            lblEquipmentCostValue.Appearance.Options.UseFont = true;
            lblEquipmentCostValue.Appearance.Options.UseForeColor = true;
            lblEquipmentCostValue.Location = new Point(597, 40);
            lblEquipmentCostValue.Name = "lblEquipmentCostValue";
            lblEquipmentCostValue.Size = new Size(20, 34);
            lblEquipmentCostValue.TabIndex = 7;
            lblEquipmentCostValue.Text = "—";
            // 
            // lblSubcontractCostTitle
            // 
            lblSubcontractCostTitle.Appearance.Font = new Font("Cairo", 8F);
            lblSubcontractCostTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubcontractCostTitle.Appearance.Options.UseFont = true;
            lblSubcontractCostTitle.Appearance.Options.UseForeColor = true;
            lblSubcontractCostTitle.Location = new Point(402, 12);
            lblSubcontractCostTitle.Name = "lblSubcontractCostTitle";
            lblSubcontractCostTitle.Size = new Size(67, 20);
            lblSubcontractCostTitle.TabIndex = 8;
            lblSubcontractCostTitle.Text = "مقاولات فرعية";
            // 
            // lblSubcontractCostValue
            // 
            lblSubcontractCostValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblSubcontractCostValue.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblSubcontractCostValue.Appearance.Options.UseFont = true;
            lblSubcontractCostValue.Appearance.Options.UseForeColor = true;
            lblSubcontractCostValue.Location = new Point(402, 40);
            lblSubcontractCostValue.Name = "lblSubcontractCostValue";
            lblSubcontractCostValue.Size = new Size(20, 34);
            lblSubcontractCostValue.TabIndex = 9;
            lblSubcontractCostValue.Text = "—";
            // 
            // lblOverheadTitle
            // 
            lblOverheadTitle.Appearance.Font = new Font("Cairo", 8F);
            lblOverheadTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblOverheadTitle.Appearance.Options.UseFont = true;
            lblOverheadTitle.Appearance.Options.UseForeColor = true;
            lblOverheadTitle.Location = new Point(207, 12);
            lblOverheadTitle.Name = "lblOverheadTitle";
            lblOverheadTitle.Size = new Size(75, 20);
            lblOverheadTitle.TabIndex = 10;
            lblOverheadTitle.Text = "المصاريف العامة";
            // 
            // lblOverheadValue
            // 
            lblOverheadValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblOverheadValue.Appearance.ForeColor = Color.FromArgb(28, 140, 140);
            lblOverheadValue.Appearance.Options.UseFont = true;
            lblOverheadValue.Appearance.Options.UseForeColor = true;
            lblOverheadValue.Location = new Point(207, 40);
            lblOverheadValue.Name = "lblOverheadValue";
            lblOverheadValue.Size = new Size(20, 34);
            lblOverheadValue.TabIndex = 11;
            lblOverheadValue.Text = "—";
            // 
            // lblProfitMarginTitle
            // 
            lblProfitMarginTitle.Appearance.Font = new Font("Cairo", 8F);
            lblProfitMarginTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblProfitMarginTitle.Appearance.Options.UseFont = true;
            lblProfitMarginTitle.Appearance.Options.UseForeColor = true;
            lblProfitMarginTitle.Location = new Point(12, 12);
            lblProfitMarginTitle.Name = "lblProfitMarginTitle";
            lblProfitMarginTitle.Size = new Size(54, 20);
            lblProfitMarginTitle.TabIndex = 12;
            lblProfitMarginTitle.Text = "هامش الربح";
            // 
            // lblProfitMarginValue
            // 
            lblProfitMarginValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblProfitMarginValue.Appearance.ForeColor = Color.FromArgb(69, 80, 92);
            lblProfitMarginValue.Appearance.Options.UseFont = true;
            lblProfitMarginValue.Appearance.Options.UseForeColor = true;
            lblProfitMarginValue.Location = new Point(12, 40);
            lblProfitMarginValue.Name = "lblProfitMarginValue";
            lblProfitMarginValue.Size = new Size(20, 34);
            lblProfitMarginValue.TabIndex = 13;
            lblProfitMarginValue.Text = "—";
            // 
            // pnlSummaryFooter
            // 
            pnlSummaryFooter.Controls.Add(lblItemCountTitle);
            pnlSummaryFooter.Controls.Add(lblItemCountValue);
            pnlSummaryFooter.Controls.Add(lblGrandTotalTitle);
            pnlSummaryFooter.Controls.Add(lblGrandTotalValue);
            pnlSummaryFooter.Dock = DockStyle.Bottom;
            pnlSummaryFooter.Location = new Point(0, 845);
            pnlSummaryFooter.Name = "pnlSummaryFooter";
            pnlSummaryFooter.Size = new Size(1366, 28);
            pnlSummaryFooter.TabIndex = 8;
            // 
            // lblItemCountTitle
            // 
            lblItemCountTitle.Appearance.Font = new Font("Cairo", 9F);
            lblItemCountTitle.Appearance.Options.UseFont = true;
            lblItemCountTitle.Location = new Point(350, 5);
            lblItemCountTitle.Name = "lblItemCountTitle";
            lblItemCountTitle.Size = new Size(52, 23);
            lblItemCountTitle.TabIndex = 0;
            lblItemCountTitle.Text = "عدد البنود:";
            // 
            // lblItemCountValue
            // 
            lblItemCountValue.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblItemCountValue.Appearance.Options.UseFont = true;
            lblItemCountValue.Location = new Point(440, 5);
            lblItemCountValue.Name = "lblItemCountValue";
            lblItemCountValue.Size = new Size(7, 23);
            lblItemCountValue.TabIndex = 1;
            lblItemCountValue.Text = "0";
            // 
            // lblGrandTotalTitle
            // 
            lblGrandTotalTitle.Appearance.Font = new Font("Cairo", 9F);
            lblGrandTotalTitle.Appearance.Options.UseFont = true;
            lblGrandTotalTitle.Location = new Point(12, 5);
            lblGrandTotalTitle.Name = "lblGrandTotalTitle";
            lblGrandTotalTitle.Size = new Size(75, 23);
            lblGrandTotalTitle.TabIndex = 2;
            lblGrandTotalTitle.Text = "الإجمالي الكلي:";
            // 
            // lblGrandTotalValue
            // 
            lblGrandTotalValue.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblGrandTotalValue.Appearance.Options.UseFont = true;
            lblGrandTotalValue.Location = new Point(120, 5);
            lblGrandTotalValue.Name = "lblGrandTotalValue";
            lblGrandTotalValue.Size = new Size(13, 23);
            lblGrandTotalValue.TabIndex = 3;
            lblGrandTotalValue.Text = "—";
            // 
            // pnlLoadingState
            // 
            pnlLoadingState.Location = new Point(247, 10);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(200, 100);
            pnlLoadingState.TabIndex = 4;
            // 
            // lblLoadingText
            // 
            lblLoadingText.Location = new Point(0, 0);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(75, 14);
            lblLoadingText.TabIndex = 0;
            // 
            // svgLoadingIcon
            // 
            svgLoadingIcon.Location = new Point(0, 0);
            svgLoadingIcon.Name = "svgLoadingIcon";
            svgLoadingIcon.Size = new Size(120, 120);
            svgLoadingIcon.TabIndex = 0;
            // 
            // pnlEmptyState
            // 
            pnlEmptyState.Location = new Point(711, 12);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(200, 100);
            pnlEmptyState.TabIndex = 5;
            // 
            // lblEmptyText
            // 
            lblEmptyText.Location = new Point(0, 0);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(75, 14);
            lblEmptyText.TabIndex = 0;
            // 
            // svgEmptyIcon
            // 
            svgEmptyIcon.Location = new Point(0, 0);
            svgEmptyIcon.Name = "svgEmptyIcon";
            svgEmptyIcon.Size = new Size(120, 120);
            svgEmptyIcon.TabIndex = 0;
            // 
            // pnlErrorState
            // 
            pnlErrorState.Location = new Point(917, 12);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(200, 100);
            pnlErrorState.TabIndex = 6;
            // 
            // btnRetry
            // 
            btnRetry.Location = new Point(0, 0);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(75, 23);
            btnRetry.TabIndex = 0;
            btnRetry.Click += btnRetry_Click;
            // 
            // lblErrorText
            // 
            lblErrorText.Location = new Point(0, 0);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(75, 14);
            lblErrorText.TabIndex = 0;
            // 
            // svgErrorIcon
            // 
            svgErrorIcon.Location = new Point(0, 0);
            svgErrorIcon.Name = "svgErrorIcon";
            svgErrorIcon.Size = new Size(120, 120);
            svgErrorIcon.TabIndex = 0;
            // 
            // ucBudgetEditor
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitMain);
            Controls.Add(pnlCalculation);
            Controls.Add(pnlSummaryFooter);
            Controls.Add(pnlBudgetHeader);
            Controls.Add(pnlStateBanner);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucBudgetEditor";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 902);
            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlStateBanner).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgStateBannerIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlBudgetHeader).EndInit();
            pnlBudgetHeader.ResumeLayout(false);
            pnlBudgetHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtBudgetCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBudgetName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRevision.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboBudgetType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtApprovalLevel.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitMain.Panel1).EndInit();
            splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain.Panel2).EndInit();
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeCBS).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdBudgetItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvBudgetItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCalculation).EndInit();
            pnlCalculation.ResumeLayout(false);
            pnlCalculation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSummaryFooter).EndInit();
            pnlSummaryFooter.ResumeLayout(false);
            pnlSummaryFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // ── Helpers ───────────────────────────────────────────────────────
        private static void SetBBI(DevExpress.XtraBars.BarButtonItem btn, string name, string caption, int id,
            System.ComponentModel.ComponentResourceManager res, string resKey, DevExpress.XtraBars.ItemClickEventHandler h)
        { btn.Caption = caption; btn.Id = id; btn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)res.GetObject(resKey); btn.Name = name; btn.ItemClick += h; }

        private static void SetHdrLabel(DevExpress.XtraEditors.LabelControl lbl, string name, string text, System.Drawing.Point loc)
        { lbl.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lbl.Appearance.Options.UseFont = true; lbl.Location = loc; lbl.Name = name; lbl.Text = text; }

        private static void SetHdrEdit(DevExpress.XtraEditors.TextEdit txt, string name, System.Drawing.Point loc, int width, bool readOnly)
        {
            txt.Location = loc; txt.Name = name; txt.Size = new System.Drawing.Size(width, 30);
            txt.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); txt.Properties.Appearance.Options.UseFont = true;
            if (readOnly) { txt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(240, 241, 243); txt.Properties.Appearance.Options.UseBackColor = true; txt.Properties.ReadOnly = true; }
        }

        private static void SetBCol(DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col, string name, string caption, string field, int width, string format, bool fixedLeft)
        {
            col.Caption = caption; col.FieldName = field; col.Name = name; col.Visible = true; col.Width = width;
            if (fixedLeft) col.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            if (!string.IsNullOrEmpty(format)) { col.DisplayFormat.FormatString = format; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric; }
            if (format == "N2") col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, field, "{0:N2}") });
        }

        private static void BuildState(DevExpress.XtraEditors.PanelControl pnl, string pnlName,
            DevExpress.XtraEditors.LabelControl lbl, string lblName, string lblText,
            DevExpress.XtraEditors.SvgImageBox svg, string svgName,
            System.ComponentModel.ComponentResourceManager res, string resKey)
        {
            pnl.Controls.Add(lbl); pnl.Controls.Add(svg);
            pnl.Dock = System.Windows.Forms.DockStyle.Fill; pnl.Name = pnlName; pnl.Visible = false;
            lbl.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lbl.Appearance.Options.UseFont = true;
            lbl.Appearance.Options.UseTextOptions = true; lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lbl.Location = new System.Drawing.Point(543, 310); lbl.Name = lblName; lbl.Size = new System.Drawing.Size(280, 26); lbl.Text = lblText;
            svg.Location = new System.Drawing.Point(651, 210); svg.Name = svgName; svg.Size = new System.Drawing.Size(64, 64);
            svg.SvgImage = (DevExpress.Utils.Svg.SvgImage)res.GetObject(resKey);
        }

        private static void BuildErrorState(DevExpress.XtraEditors.PanelControl pnl, string pnlName,
            DevExpress.XtraEditors.LabelControl lbl, string lblName, string lblText,
            DevExpress.XtraEditors.SvgImageBox svg, string svgName,
            DevExpress.XtraEditors.SimpleButton btn,
            System.ComponentModel.ComponentResourceManager res)
        {
            pnl.Controls.Add(btn); pnl.Controls.Add(lbl); pnl.Controls.Add(svg);
            pnl.Dock = System.Windows.Forms.DockStyle.Fill; pnl.Name = pnlName; pnl.Visible = false;
            lbl.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lbl.Appearance.Options.UseFont = true;
            lbl.Appearance.Options.UseTextOptions = true; lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lbl.Location = new System.Drawing.Point(543, 290); lbl.Name = lblName; lbl.Size = new System.Drawing.Size(280, 26); lbl.Text = lblText;
            svg.Location = new System.Drawing.Point(651, 190); svg.Name = svgName; svg.Size = new System.Drawing.Size(64, 64);
            svg.SvgImage = (DevExpress.Utils.Svg.SvgImage)res.GetObject("svgErrorIcon.SvgImage");
            btn.Appearance.Font = new System.Drawing.Font("Cairo", 9F); btn.Appearance.Options.UseFont = true;
            btn.Location = new System.Drawing.Point(633, 330); btn.Name = "btnRetry"; btn.Size = new System.Drawing.Size(100, 34); btn.Text = "إعادة المحاولة";
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
        private DevExpress.XtraBars.BarButtonItem bbiAddItem;
        private DevExpress.XtraBars.BarButtonItem bbiAddGroup;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiDuplicate;
        private DevExpress.XtraBars.BarButtonItem bbiImportBOQ;
        private DevExpress.XtraBars.BarButtonItem bbiImportExcel;
        private DevExpress.XtraBars.BarButtonItem bbiValidate;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiApprove;
        private DevExpress.XtraBars.BarButtonItem bbiExpandAll;
        private DevExpress.XtraBars.BarButtonItem bbiCollapseAll;
        private DevExpress.XtraBars.BarStaticItem sbiItemCount;
        private DevExpress.XtraBars.BarStaticItem sbiLastSaved;
        private DevExpress.XtraEditors.PanelControl pnlStateBanner;
        private DevExpress.XtraEditors.LabelControl lblStateBanner;
        private DevExpress.XtraEditors.SvgImageBox svgStateBannerIcon;
        private DevExpress.XtraEditors.PanelControl pnlBudgetHeader;
        private DevExpress.XtraEditors.LabelControl lblBudgetCode;
        private DevExpress.XtraEditors.TextEdit txtBudgetCode;
        private DevExpress.XtraEditors.LabelControl lblBudgetName;
        private DevExpress.XtraEditors.TextEdit txtBudgetName;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.TextEdit txtProject;
        private DevExpress.XtraEditors.LabelControl lblRevision;
        private DevExpress.XtraEditors.TextEdit txtRevision;
        private DevExpress.XtraEditors.LabelControl lblBudgetType;
        private DevExpress.XtraEditors.ComboBoxEdit cboBudgetType;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.TextEdit txtStatus;
        private DevExpress.XtraEditors.LabelControl lblApprovalLevel;
        private DevExpress.XtraEditors.TextEdit txtApprovalLevel;
        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraTreeList.TreeList treeCBS;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCBSCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCBSName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCBSBudget;
        private DevExpress.XtraGrid.GridControl grdBudgetItems;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvBudgetItems;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandIdentification;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandQuantities;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandCostDistribution;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandClassification;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCostCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescription;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUnit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBudgetQty;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUnitCost;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotalCost;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLabor;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMaterial;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEquipment;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSubcontract;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIndirectCost;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colContingency;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRemarks;
        private DevExpress.XtraEditors.PanelControl pnlCalculation;
        private DevExpress.XtraEditors.LabelControl lblTotalBudgetTitle;
        private DevExpress.XtraEditors.LabelControl lblTotalBudgetValue;
        private DevExpress.XtraEditors.LabelControl lblLaborCostTitle;
        private DevExpress.XtraEditors.LabelControl lblLaborCostValue;
        private DevExpress.XtraEditors.LabelControl lblMaterialCostTitle;
        private DevExpress.XtraEditors.LabelControl lblMaterialCostValue;
        private DevExpress.XtraEditors.LabelControl lblEquipmentCostTitle;
        private DevExpress.XtraEditors.LabelControl lblEquipmentCostValue;
        private DevExpress.XtraEditors.LabelControl lblSubcontractCostTitle;
        private DevExpress.XtraEditors.LabelControl lblSubcontractCostValue;
        private DevExpress.XtraEditors.LabelControl lblOverheadTitle;
        private DevExpress.XtraEditors.LabelControl lblOverheadValue;
        private DevExpress.XtraEditors.LabelControl lblProfitMarginTitle;
        private DevExpress.XtraEditors.LabelControl lblProfitMarginValue;
        private DevExpress.XtraEditors.PanelControl pnlSummaryFooter;
        private DevExpress.XtraEditors.LabelControl lblItemCountTitle;
        private DevExpress.XtraEditors.LabelControl lblItemCountValue;
        private DevExpress.XtraEditors.LabelControl lblGrandTotalTitle;
        private DevExpress.XtraEditors.LabelControl lblGrandTotalValue;
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

