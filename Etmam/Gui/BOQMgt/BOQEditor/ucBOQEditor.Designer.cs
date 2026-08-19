namespace Etmam
{
    partial class ucBOQEditor
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBOQEditor));
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiAddItem = new DevExpress.XtraBars.BarButtonItem();
            bbiAddGroup = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiDuplicate = new DevExpress.XtraBars.BarButtonItem();
            bbiMoveUp = new DevExpress.XtraBars.BarButtonItem();
            bbiMoveDown = new DevExpress.XtraBars.BarButtonItem();
            bbiExpandAll = new DevExpress.XtraBars.BarButtonItem();
            bbiCollapseAll = new DevExpress.XtraBars.BarButtonItem();
            bbiImport = new DevExpress.XtraBars.BarButtonItem();
            bbiExport = new DevExpress.XtraBars.BarButtonItem();
            bbiValidate = new DevExpress.XtraBars.BarButtonItem();
            bbiSave = new DevExpress.XtraBars.BarButtonItem();
            bbiApprove = new DevExpress.XtraBars.BarButtonItem();
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
            pnlBOQHeader = new DevExpress.XtraEditors.PanelControl();
            txtStatus = new DevExpress.XtraEditors.TextEdit();
            lblStatusField = new DevExpress.XtraEditors.LabelControl();
            txtDiscipline = new DevExpress.XtraEditors.TextEdit();
            lblDiscipline = new DevExpress.XtraEditors.LabelControl();
            txtRevision = new DevExpress.XtraEditors.TextEdit();
            lblRevision = new DevExpress.XtraEditors.LabelControl();
            txtProject = new DevExpress.XtraEditors.TextEdit();
            lblProject = new DevExpress.XtraEditors.LabelControl();
            txtBOQName = new DevExpress.XtraEditors.TextEdit();
            lblBOQName = new DevExpress.XtraEditors.LabelControl();
            txtBOQCode = new DevExpress.XtraEditors.TextEdit();
            lblBOQCode = new DevExpress.XtraEditors.LabelControl();
            grdBOQItems = new DevExpress.XtraGrid.GridControl();
            gvBOQItems = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            bandIdentification = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            bandQuantitiesPricing = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            bandClassification = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            colItemNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colParent = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colDescriptionAr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colDescriptionEn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colUnit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colQuantity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colUnitRate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCostCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colWBS = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colCBS = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colResourceCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            colRemarks = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            pnlCalculation = new DevExpress.XtraEditors.PanelControl();
            lblLastSavedValue = new DevExpress.XtraEditors.LabelControl();
            lblLastSavedTitle = new DevExpress.XtraEditors.LabelControl();
            lblCostVarianceValue = new DevExpress.XtraEditors.LabelControl();
            lblCostVarianceTitle = new DevExpress.XtraEditors.LabelControl();
            lblAverageRateValue = new DevExpress.XtraEditors.LabelControl();
            lblAverageRateTitle = new DevExpress.XtraEditors.LabelControl();
            lblTotalCostValue = new DevExpress.XtraEditors.LabelControl();
            lblTotalCostTitle = new DevExpress.XtraEditors.LabelControl();
            lblTotalQuantityValue = new DevExpress.XtraEditors.LabelControl();
            lblTotalQuantityTitle = new DevExpress.XtraEditors.LabelControl();
            pnlSummaryFooter = new DevExpress.XtraEditors.PanelControl();
            lblItemCountValue = new DevExpress.XtraEditors.LabelControl();
            lblItemCountTitle = new DevExpress.XtraEditors.LabelControl();
            lblGrandTotalValue = new DevExpress.XtraEditors.LabelControl();
            lblGrandTotalTitle = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)pnlBOQHeader).BeginInit();
            pnlBOQHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDiscipline.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRevision.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBOQName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBOQCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdBOQItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvBOQItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlCalculation).BeginInit();
            pnlCalculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSummaryFooter).BeginInit();
            pnlSummaryFooter.SuspendLayout();
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
            // barManagerMain
            //
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAddItem, bbiAddGroup, bbiDelete, bbiDuplicate, bbiMoveUp, bbiMoveDown, bbiExpandAll, bbiCollapseAll, bbiImport, bbiExport, bbiValidate, bbiSave, bbiApprove, sbiItemCount, sbiLastSaved });
            barManagerMain.MainMenu = barMain;
            barManagerMain.MaxItemId = 15;
            barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerMain.StatusBar = barStatus;
            //
            // barMain
            //
            barMain.BarName = "شريط أدوات جدول الكميات";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAddItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAddGroup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDuplicate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiMoveUp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiMoveDown, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExpandAll, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCollapseAll, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiImport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiValidate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiApprove, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.MinHeight = 34;
            barMain.OptionsBar.MultiLine = true;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "شريط أدوات جدول الكميات";
            //
            // bbiAddItem
            //
            bbiAddItem.Caption = "إضافة بند";
            bbiAddItem.Id = 0;
            bbiAddItem.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiAddItem.ImageOptions.SvgImage");
            bbiAddItem.Name = "bbiAddItem";
            bbiAddItem.ItemClick += bbiAddItem_ItemClick;
            //
            // bbiAddGroup
            //
            bbiAddGroup.Caption = "إضافة مجموعة";
            bbiAddGroup.Id = 1;
            bbiAddGroup.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiAddGroup.ImageOptions.SvgImage");
            bbiAddGroup.Name = "bbiAddGroup";
            bbiAddGroup.ItemClick += bbiAddGroup_ItemClick;
            //
            // bbiDelete
            //
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 2;
            bbiDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiDelete.ImageOptions.SvgImage");
            bbiDelete.Name = "bbiDelete";
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            //
            // bbiDuplicate
            //
            bbiDuplicate.Caption = "تكرار";
            bbiDuplicate.Id = 3;
            bbiDuplicate.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiDuplicate.ImageOptions.SvgImage");
            bbiDuplicate.Name = "bbiDuplicate";
            bbiDuplicate.ItemClick += bbiDuplicate_ItemClick;
            //
            // bbiMoveUp
            //
            bbiMoveUp.Caption = "نقل لأعلى";
            bbiMoveUp.Id = 4;
            bbiMoveUp.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiMoveUp.ImageOptions.SvgImage");
            bbiMoveUp.Name = "bbiMoveUp";
            bbiMoveUp.ItemClick += bbiMoveUp_ItemClick;
            //
            // bbiMoveDown
            //
            bbiMoveDown.Caption = "نقل لأسفل";
            bbiMoveDown.Id = 5;
            bbiMoveDown.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiMoveDown.ImageOptions.SvgImage");
            bbiMoveDown.Name = "bbiMoveDown";
            bbiMoveDown.ItemClick += bbiMoveDown_ItemClick;
            //
            // bbiExpandAll
            //
            bbiExpandAll.Caption = "توسيع الكل";
            bbiExpandAll.Id = 6;
            bbiExpandAll.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExpandAll.ImageOptions.SvgImage");
            bbiExpandAll.Name = "bbiExpandAll";
            bbiExpandAll.ItemClick += bbiExpandAll_ItemClick;
            //
            // bbiCollapseAll
            //
            bbiCollapseAll.Caption = "طي الكل";
            bbiCollapseAll.Id = 7;
            bbiCollapseAll.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiCollapseAll.ImageOptions.SvgImage");
            bbiCollapseAll.Name = "bbiCollapseAll";
            bbiCollapseAll.ItemClick += bbiCollapseAll_ItemClick;
            //
            // bbiImport
            //
            bbiImport.Caption = "استيراد";
            bbiImport.Id = 8;
            bbiImport.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiImport.ImageOptions.SvgImage");
            bbiImport.Name = "bbiImport";
            bbiImport.ItemClick += bbiImport_ItemClick;
            //
            // bbiExport
            //
            bbiExport.Caption = "تصدير";
            bbiExport.Id = 9;
            bbiExport.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExport.ImageOptions.SvgImage");
            bbiExport.Name = "bbiExport";
            bbiExport.ItemClick += bbiExport_ItemClick;
            //
            // bbiValidate
            //
            bbiValidate.Caption = "التحقق";
            bbiValidate.Id = 10;
            bbiValidate.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiValidate.ImageOptions.SvgImage");
            bbiValidate.Name = "bbiValidate";
            bbiValidate.ItemClick += bbiValidate_ItemClick;
            //
            // bbiSave
            //
            bbiSave.Caption = "حفظ";
            bbiSave.Id = 11;
            bbiSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiSave.ImageOptions.SvgImage");
            bbiSave.Name = "bbiSave";
            bbiSave.ItemClick += bbiSave_ItemClick;
            //
            // bbiApprove
            //
            bbiApprove.Caption = "اعتماد";
            bbiApprove.Id = 12;
            bbiApprove.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiApprove.ImageOptions.SvgImage");
            bbiApprove.Name = "bbiApprove";
            bbiApprove.ItemClick += bbiApprove_ItemClick;
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
            sbiItemCount.Id = 13;
            sbiItemCount.Name = "sbiItemCount";
            //
            // sbiLastSaved
            //
            sbiLastSaved.Caption = "آخر حفظ: —";
            sbiLastSaved.Id = 14;
            sbiLastSaved.Name = "sbiLastSaved";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerMain;
            barDockControlTop.Margin = new Padding(3, 5, 3, 5);
            barDockControlTop.Size = new Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 873);
            barDockControlBottom.Manager = barManagerMain;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(1366, 29);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerMain;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 839);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerMain;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
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
            pnlStateBanner.Margin = new Padding(3, 5, 3, 5);
            pnlStateBanner.Name = "pnlStateBanner";
            pnlStateBanner.Size = new Size(1366, 36);
            pnlStateBanner.TabIndex = 0;
            pnlStateBanner.Visible = false;
            //
            // lblStateBanner
            //
            lblStateBanner.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblStateBanner.Appearance.ForeColor = Color.FromArgb(90, 100, 115);
            lblStateBanner.Appearance.Options.UseFont = true;
            lblStateBanner.Appearance.Options.UseForeColor = true;
            lblStateBanner.Location = new Point(1180, 9);
            lblStateBanner.Margin = new Padding(3, 5, 3, 5);
            lblStateBanner.Name = "lblStateBanner";
            lblStateBanner.Size = new Size(122, 20);
            lblStateBanner.TabIndex = 1;
            lblStateBanner.Text = "جدول الكميات مقفل";
            //
            // svgStateBannerIcon
            //
            svgStateBannerIcon.Location = new Point(1320, 6);
            svgStateBannerIcon.Margin = new Padding(3, 5, 3, 5);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new Size(24, 24);
            svgStateBannerIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgStateBannerIcon.SvgImage");
            svgStateBannerIcon.TabIndex = 0;
            //
            // pnlBOQHeader
            //
            pnlBOQHeader.Controls.Add(txtStatus);
            pnlBOQHeader.Controls.Add(lblStatusField);
            pnlBOQHeader.Controls.Add(txtDiscipline);
            pnlBOQHeader.Controls.Add(lblDiscipline);
            pnlBOQHeader.Controls.Add(txtRevision);
            pnlBOQHeader.Controls.Add(lblRevision);
            pnlBOQHeader.Controls.Add(txtProject);
            pnlBOQHeader.Controls.Add(lblProject);
            pnlBOQHeader.Controls.Add(txtBOQName);
            pnlBOQHeader.Controls.Add(lblBOQName);
            pnlBOQHeader.Controls.Add(txtBOQCode);
            pnlBOQHeader.Controls.Add(lblBOQCode);
            pnlBOQHeader.Dock = DockStyle.Top;
            pnlBOQHeader.Location = new Point(0, 70);
            pnlBOQHeader.Margin = new Padding(3, 5, 3, 5);
            pnlBOQHeader.Name = "pnlBOQHeader";
            pnlBOQHeader.Size = new Size(1366, 150);
            pnlBOQHeader.TabIndex = 1;
            //
            // txtStatus
            //
            txtStatus.Location = new Point(688, 101);
            txtStatus.Margin = new Padding(3, 5, 3, 5);
            txtStatus.Name = "txtStatus";
            txtStatus.Properties.Appearance.BackColor = Color.FromArgb(240, 241, 243);
            txtStatus.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtStatus.Properties.Appearance.Options.UseBackColor = true;
            txtStatus.Properties.Appearance.Options.UseFont = true;
            txtStatus.Properties.ReadOnly = true;
            txtStatus.Size = new Size(322, 30);
            txtStatus.TabIndex = 11;
            //
            // lblStatusField
            //
            lblStatusField.Appearance.Font = new Font("Cairo", 8F);
            lblStatusField.Appearance.Options.UseFont = true;
            lblStatusField.Location = new Point(688, 73);
            lblStatusField.Margin = new Padding(3, 5, 3, 5);
            lblStatusField.Name = "lblStatusField";
            lblStatusField.Size = new Size(31, 20);
            lblStatusField.TabIndex = 10;
            lblStatusField.Text = "الحالة:";
            //
            // txtDiscipline
            //
            txtDiscipline.Location = new Point(350, 101);
            txtDiscipline.Margin = new Padding(3, 5, 3, 5);
            txtDiscipline.Name = "txtDiscipline";
            txtDiscipline.Properties.Appearance.BackColor = Color.FromArgb(240, 241, 243);
            txtDiscipline.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtDiscipline.Properties.Appearance.Options.UseBackColor = true;
            txtDiscipline.Properties.Appearance.Options.UseFont = true;
            txtDiscipline.Properties.ReadOnly = true;
            txtDiscipline.Size = new Size(322, 30);
            txtDiscipline.TabIndex = 9;
            //
            // lblDiscipline
            //
            lblDiscipline.Appearance.Font = new Font("Cairo", 8F);
            lblDiscipline.Appearance.Options.UseFont = true;
            lblDiscipline.Location = new Point(350, 73);
            lblDiscipline.Margin = new Padding(3, 5, 3, 5);
            lblDiscipline.Name = "lblDiscipline";
            lblDiscipline.Size = new Size(45, 20);
            lblDiscipline.TabIndex = 8;
            lblDiscipline.Text = "التخصص:";
            //
            // txtRevision
            //
            txtRevision.Location = new Point(12, 101);
            txtRevision.Margin = new Padding(3, 5, 3, 5);
            txtRevision.Name = "txtRevision";
            txtRevision.Properties.Appearance.BackColor = Color.FromArgb(240, 241, 243);
            txtRevision.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtRevision.Properties.Appearance.Options.UseBackColor = true;
            txtRevision.Properties.Appearance.Options.UseFont = true;
            txtRevision.Properties.ReadOnly = true;
            txtRevision.Size = new Size(322, 30);
            txtRevision.TabIndex = 7;
            //
            // lblRevision
            //
            lblRevision.Appearance.Font = new Font("Cairo", 8F);
            lblRevision.Appearance.Options.UseFont = true;
            lblRevision.Location = new Point(12, 73);
            lblRevision.Margin = new Padding(3, 5, 3, 5);
            lblRevision.Name = "lblRevision";
            lblRevision.Size = new Size(52, 20);
            lblRevision.TabIndex = 6;
            lblRevision.Text = "المراجعة:";
            //
            // txtProject
            //
            txtProject.Location = new Point(688, 43);
            txtProject.Margin = new Padding(3, 5, 3, 5);
            txtProject.Name = "txtProject";
            txtProject.Properties.Appearance.BackColor = Color.FromArgb(240, 241, 243);
            txtProject.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtProject.Properties.Appearance.Options.UseBackColor = true;
            txtProject.Properties.Appearance.Options.UseFont = true;
            txtProject.Properties.ReadOnly = true;
            txtProject.Size = new Size(322, 30);
            txtProject.TabIndex = 5;
            //
            // lblProject
            //
            lblProject.Appearance.Font = new Font("Cairo", 8F);
            lblProject.Appearance.Options.UseFont = true;
            lblProject.Location = new Point(688, 15);
            lblProject.Margin = new Padding(3, 5, 3, 5);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(50, 20);
            lblProject.TabIndex = 4;
            lblProject.Text = "المشروع:";
            //
            // txtBOQName
            //
            txtBOQName.Location = new Point(350, 43);
            txtBOQName.Margin = new Padding(3, 5, 3, 5);
            txtBOQName.Name = "txtBOQName";
            txtBOQName.Properties.Appearance.BackColor = Color.FromArgb(240, 241, 243);
            txtBOQName.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtBOQName.Properties.Appearance.Options.UseBackColor = true;
            txtBOQName.Properties.Appearance.Options.UseFont = true;
            txtBOQName.Properties.ReadOnly = true;
            txtBOQName.Size = new Size(322, 30);
            txtBOQName.TabIndex = 3;
            //
            // lblBOQName
            //
            lblBOQName.Appearance.Font = new Font("Cairo", 8F);
            lblBOQName.Appearance.Options.UseFont = true;
            lblBOQName.Location = new Point(350, 15);
            lblBOQName.Margin = new Padding(3, 5, 3, 5);
            lblBOQName.Name = "lblBOQName";
            lblBOQName.Size = new Size(80, 20);
            lblBOQName.TabIndex = 2;
            lblBOQName.Text = "اسم جدول الكميات:";
            //
            // txtBOQCode
            //
            txtBOQCode.Location = new Point(12, 43);
            txtBOQCode.Margin = new Padding(3, 5, 3, 5);
            txtBOQCode.Name = "txtBOQCode";
            txtBOQCode.Properties.Appearance.BackColor = Color.FromArgb(240, 241, 243);
            txtBOQCode.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtBOQCode.Properties.Appearance.Options.UseBackColor = true;
            txtBOQCode.Properties.Appearance.Options.UseFont = true;
            txtBOQCode.Properties.ReadOnly = true;
            txtBOQCode.Size = new Size(322, 30);
            txtBOQCode.TabIndex = 1;
            //
            // lblBOQCode
            //
            lblBOQCode.Appearance.Font = new Font("Cairo", 8F);
            lblBOQCode.Appearance.Options.UseFont = true;
            lblBOQCode.Location = new Point(12, 15);
            lblBOQCode.Margin = new Padding(3, 5, 3, 5);
            lblBOQCode.Name = "lblBOQCode";
            lblBOQCode.Size = new Size(78, 20);
            lblBOQCode.TabIndex = 0;
            lblBOQCode.Text = "رمز جدول الكميات:";
            //
            // grdBOQItems
            //
            grdBOQItems.Dock = DockStyle.Fill;
            grdBOQItems.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdBOQItems.Location = new Point(0, 220);
            grdBOQItems.MainView = gvBOQItems;
            grdBOQItems.Margin = new Padding(3, 5, 3, 5);
            grdBOQItems.MenuManager = barManagerMain;
            grdBOQItems.Name = "grdBOQItems";
            grdBOQItems.Size = new Size(1366, 528);
            grdBOQItems.TabIndex = 2;
            grdBOQItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvBOQItems });
            //
            // gvBOQItems
            //
            gvBOQItems.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvBOQItems.Appearance.HeaderPanel.Options.UseFont = true;
            gvBOQItems.Appearance.Row.Font = new Font("Cairo", 8F);
            gvBOQItems.Appearance.Row.Options.UseFont = true;
            gvBOQItems.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { bandIdentification, bandQuantitiesPricing, bandClassification });
            gvBOQItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colItemNo, colParent, colDescriptionAr, colDescriptionEn, colUnit, colQuantity, colUnitRate, colTotal, colCostCode, colWBS, colCBS, colResourceCode, colRemarks });
            gvBOQItems.GridControl = grdBOQItems;
            gvBOQItems.Name = "gvBOQItems";
            gvBOQItems.OptionsBehavior.Editable = true;
            gvBOQItems.OptionsCustomization.AllowColumnMoving = true;
            gvBOQItems.OptionsCustomization.AllowRowSizing = true;
            gvBOQItems.OptionsView.ShowAutoFilterRow = true;
            gvBOQItems.OptionsView.ShowFooter = true;
            //
            // bandIdentification
            //
            bandIdentification.Caption = "بيانات تعريفية";
            bandIdentification.Columns.Add(colItemNo);
            bandIdentification.Columns.Add(colParent);
            bandIdentification.Columns.Add(colDescriptionAr);
            bandIdentification.Columns.Add(colDescriptionEn);
            bandIdentification.Columns.Add(colUnit);
            bandIdentification.Name = "bandIdentification";
            bandIdentification.VisibleIndex = 0;
            bandIdentification.Width = 690;
            //
            // bandQuantitiesPricing
            //
            bandQuantitiesPricing.Caption = "الكميات والأسعار";
            bandQuantitiesPricing.Columns.Add(colQuantity);
            bandQuantitiesPricing.Columns.Add(colUnitRate);
            bandQuantitiesPricing.Columns.Add(colTotal);
            bandQuantitiesPricing.Name = "bandQuantitiesPricing";
            bandQuantitiesPricing.VisibleIndex = 1;
            bandQuantitiesPricing.Width = 300;
            //
            // bandClassification
            //
            bandClassification.Caption = "التصنيف";
            bandClassification.Columns.Add(colCostCode);
            bandClassification.Columns.Add(colWBS);
            bandClassification.Columns.Add(colCBS);
            bandClassification.Columns.Add(colResourceCode);
            bandClassification.Columns.Add(colRemarks);
            bandClassification.Name = "bandClassification";
            bandClassification.VisibleIndex = 2;
            bandClassification.Width = 540;
            //
            // colItemNo
            //
            colItemNo.Caption = "رقم البند";
            colItemNo.FieldName = "ItemNo";
            colItemNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colItemNo.Name = "colItemNo";
            colItemNo.Visible = true;
            colItemNo.Width = 90;
            //
            // colParent
            //
            colParent.Caption = "البند الأب";
            colParent.FieldName = "ParentItemNo";
            colParent.Name = "colParent";
            colParent.Visible = true;
            colParent.Width = 90;
            //
            // colDescriptionAr
            //
            colDescriptionAr.Caption = "الوصف بالعربي";
            colDescriptionAr.FieldName = "DescriptionAr";
            colDescriptionAr.Name = "colDescriptionAr";
            colDescriptionAr.Visible = true;
            colDescriptionAr.Width = 220;
            //
            // colDescriptionEn
            //
            colDescriptionEn.Caption = "الوصف بالإنجليزي";
            colDescriptionEn.FieldName = "DescriptionEn";
            colDescriptionEn.Name = "colDescriptionEn";
            colDescriptionEn.Visible = true;
            colDescriptionEn.Width = 220;
            //
            // colUnit
            //
            colUnit.Caption = "الوحدة";
            colUnit.FieldName = "Unit";
            colUnit.Name = "colUnit";
            colUnit.Visible = true;
            colUnit.Width = 70;
            //
            // colQuantity
            //
            colQuantity.Caption = "الكمية";
            colQuantity.DisplayFormat.FormatString = "N2";
            colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQuantity.FieldName = "Quantity";
            colQuantity.Name = "colQuantity";
            colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "الإجمالي: {0:N2}") });
            colQuantity.Visible = true;
            colQuantity.Width = 90;
            //
            // colUnitRate
            //
            colUnitRate.Caption = "سعر الوحدة";
            colUnitRate.DisplayFormat.FormatString = "N2";
            colUnitRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colUnitRate.FieldName = "UnitRate";
            colUnitRate.Name = "colUnitRate";
            colUnitRate.Visible = true;
            colUnitRate.Width = 100;
            //
            // colTotal
            //
            colTotal.Caption = "الإجمالي";
            colTotal.DisplayFormat.FormatString = "N2";
            colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTotal.FieldName = "Total";
            colTotal.Name = "colTotal";
            colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "الإجمالي: {0:N2}") });
            colTotal.Visible = true;
            colTotal.Width = 110;
            //
            // colCostCode
            //
            colCostCode.Caption = "كود التكلفة";
            colCostCode.FieldName = "CostCode";
            colCostCode.Name = "colCostCode";
            colCostCode.Visible = true;
            colCostCode.Width = 100;
            //
            // colWBS
            //
            colWBS.Caption = "WBS";
            colWBS.FieldName = "WBS";
            colWBS.Name = "colWBS";
            colWBS.Visible = true;
            colWBS.Width = 90;
            //
            // colCBS
            //
            colCBS.Caption = "CBS";
            colCBS.FieldName = "CBS";
            colCBS.Name = "colCBS";
            colCBS.Visible = true;
            colCBS.Width = 90;
            //
            // colResourceCode
            //
            colResourceCode.Caption = "كود المورد";
            colResourceCode.FieldName = "ResourceCode";
            colResourceCode.Name = "colResourceCode";
            colResourceCode.Visible = true;
            colResourceCode.Width = 110;
            //
            // colRemarks
            //
            colRemarks.Caption = "ملاحظات";
            colRemarks.FieldName = "Remarks";
            colRemarks.Name = "colRemarks";
            colRemarks.Visible = true;
            colRemarks.Width = 150;
            //
            // pnlCalculation
            //
            pnlCalculation.Controls.Add(lblLastSavedValue);
            pnlCalculation.Controls.Add(lblLastSavedTitle);
            pnlCalculation.Controls.Add(lblCostVarianceValue);
            pnlCalculation.Controls.Add(lblCostVarianceTitle);
            pnlCalculation.Controls.Add(lblAverageRateValue);
            pnlCalculation.Controls.Add(lblAverageRateTitle);
            pnlCalculation.Controls.Add(lblTotalCostValue);
            pnlCalculation.Controls.Add(lblTotalCostTitle);
            pnlCalculation.Controls.Add(lblTotalQuantityValue);
            pnlCalculation.Controls.Add(lblTotalQuantityTitle);
            pnlCalculation.Dock = DockStyle.Bottom;
            pnlCalculation.Location = new Point(0, 748);
            pnlCalculation.Margin = new Padding(3, 5, 3, 5);
            pnlCalculation.Name = "pnlCalculation";
            pnlCalculation.Size = new Size(1366, 90);
            pnlCalculation.TabIndex = 3;
            //
            // lblLastSavedValue
            //
            lblLastSavedValue.Appearance.Font = new Font("Cairo", 12F, FontStyle.Bold);
            lblLastSavedValue.Appearance.ForeColor = Color.FromArgb(69, 80, 92);
            lblLastSavedValue.Appearance.Options.UseFont = true;
            lblLastSavedValue.Appearance.Options.UseForeColor = true;
            lblLastSavedValue.Location = new Point(1084, 40);
            lblLastSavedValue.Margin = new Padding(3, 5, 3, 5);
            lblLastSavedValue.Name = "lblLastSavedValue";
            lblLastSavedValue.Size = new Size(16, 30);
            lblLastSavedValue.TabIndex = 9;
            lblLastSavedValue.Text = "—";
            //
            // lblLastSavedTitle
            //
            lblLastSavedTitle.Appearance.Font = new Font("Cairo", 8F);
            lblLastSavedTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblLastSavedTitle.Appearance.Options.UseFont = true;
            lblLastSavedTitle.Appearance.Options.UseForeColor = true;
            lblLastSavedTitle.Location = new Point(1084, 15);
            lblLastSavedTitle.Margin = new Padding(3, 5, 3, 5);
            lblLastSavedTitle.Name = "lblLastSavedTitle";
            lblLastSavedTitle.Size = new Size(50, 20);
            lblLastSavedTitle.TabIndex = 8;
            lblLastSavedTitle.Text = "آخر حفظ";
            //
            // lblCostVarianceValue
            //
            lblCostVarianceValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblCostVarianceValue.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblCostVarianceValue.Appearance.Options.UseFont = true;
            lblCostVarianceValue.Appearance.Options.UseForeColor = true;
            lblCostVarianceValue.Location = new Point(816, 40);
            lblCostVarianceValue.Margin = new Padding(3, 5, 3, 5);
            lblCostVarianceValue.Name = "lblCostVarianceValue";
            lblCostVarianceValue.Size = new Size(16, 34);
            lblCostVarianceValue.TabIndex = 7;
            lblCostVarianceValue.Text = "—";
            //
            // lblCostVarianceTitle
            //
            lblCostVarianceTitle.Appearance.Font = new Font("Cairo", 8F);
            lblCostVarianceTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblCostVarianceTitle.Appearance.Options.UseFont = true;
            lblCostVarianceTitle.Appearance.Options.UseForeColor = true;
            lblCostVarianceTitle.Location = new Point(816, 15);
            lblCostVarianceTitle.Margin = new Padding(3, 5, 3, 5);
            lblCostVarianceTitle.Name = "lblCostVarianceTitle";
            lblCostVarianceTitle.Size = new Size(69, 20);
            lblCostVarianceTitle.TabIndex = 6;
            lblCostVarianceTitle.Text = "انحراف التكلفة";
            //
            // lblAverageRateValue
            //
            lblAverageRateValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblAverageRateValue.Appearance.ForeColor = Color.FromArgb(28, 140, 140);
            lblAverageRateValue.Appearance.Options.UseFont = true;
            lblAverageRateValue.Appearance.Options.UseForeColor = true;
            lblAverageRateValue.Location = new Point(548, 40);
            lblAverageRateValue.Margin = new Padding(3, 5, 3, 5);
            lblAverageRateValue.Name = "lblAverageRateValue";
            lblAverageRateValue.Size = new Size(16, 34);
            lblAverageRateValue.TabIndex = 5;
            lblAverageRateValue.Text = "—";
            //
            // lblAverageRateTitle
            //
            lblAverageRateTitle.Appearance.Font = new Font("Cairo", 8F);
            lblAverageRateTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblAverageRateTitle.Appearance.Options.UseFont = true;
            lblAverageRateTitle.Appearance.Options.UseForeColor = true;
            lblAverageRateTitle.Location = new Point(548, 15);
            lblAverageRateTitle.Margin = new Padding(3, 5, 3, 5);
            lblAverageRateTitle.Name = "lblAverageRateTitle";
            lblAverageRateTitle.Size = new Size(58, 20);
            lblAverageRateTitle.TabIndex = 4;
            lblAverageRateTitle.Text = "متوسط السعر";
            //
            // lblTotalCostValue
            //
            lblTotalCostValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblTotalCostValue.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblTotalCostValue.Appearance.Options.UseFont = true;
            lblTotalCostValue.Appearance.Options.UseForeColor = true;
            lblTotalCostValue.Location = new Point(280, 40);
            lblTotalCostValue.Margin = new Padding(3, 5, 3, 5);
            lblTotalCostValue.Name = "lblTotalCostValue";
            lblTotalCostValue.Size = new Size(16, 34);
            lblTotalCostValue.TabIndex = 3;
            lblTotalCostValue.Text = "—";
            //
            // lblTotalCostTitle
            //
            lblTotalCostTitle.Appearance.Font = new Font("Cairo", 8F);
            lblTotalCostTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalCostTitle.Appearance.Options.UseFont = true;
            lblTotalCostTitle.Appearance.Options.UseForeColor = true;
            lblTotalCostTitle.Location = new Point(280, 15);
            lblTotalCostTitle.Margin = new Padding(3, 5, 3, 5);
            lblTotalCostTitle.Name = "lblTotalCostTitle";
            lblTotalCostTitle.Size = new Size(60, 20);
            lblTotalCostTitle.TabIndex = 2;
            lblTotalCostTitle.Text = "إجمالي التكلفة";
            //
            // lblTotalQuantityValue
            //
            lblTotalQuantityValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblTotalQuantityValue.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblTotalQuantityValue.Appearance.Options.UseFont = true;
            lblTotalQuantityValue.Appearance.Options.UseForeColor = true;
            lblTotalQuantityValue.Location = new Point(12, 40);
            lblTotalQuantityValue.Margin = new Padding(3, 5, 3, 5);
            lblTotalQuantityValue.Name = "lblTotalQuantityValue";
            lblTotalQuantityValue.Size = new Size(16, 34);
            lblTotalQuantityValue.TabIndex = 1;
            lblTotalQuantityValue.Text = "—";
            //
            // lblTotalQuantityTitle
            //
            lblTotalQuantityTitle.Appearance.Font = new Font("Cairo", 8F);
            lblTotalQuantityTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalQuantityTitle.Appearance.Options.UseFont = true;
            lblTotalQuantityTitle.Appearance.Options.UseForeColor = true;
            lblTotalQuantityTitle.Location = new Point(12, 15);
            lblTotalQuantityTitle.Margin = new Padding(3, 5, 3, 5);
            lblTotalQuantityTitle.Name = "lblTotalQuantityTitle";
            lblTotalQuantityTitle.Size = new Size(56, 20);
            lblTotalQuantityTitle.TabIndex = 0;
            lblTotalQuantityTitle.Text = "إجمالي الكمية";
            //
            // pnlSummaryFooter
            //
            pnlSummaryFooter.Controls.Add(lblItemCountValue);
            pnlSummaryFooter.Controls.Add(lblItemCountTitle);
            pnlSummaryFooter.Controls.Add(lblGrandTotalValue);
            pnlSummaryFooter.Controls.Add(lblGrandTotalTitle);
            pnlSummaryFooter.Dock = DockStyle.Bottom;
            pnlSummaryFooter.Location = new Point(0, 838);
            pnlSummaryFooter.Margin = new Padding(3, 5, 3, 5);
            pnlSummaryFooter.Name = "pnlSummaryFooter";
            pnlSummaryFooter.Size = new Size(1366, 35);
            pnlSummaryFooter.TabIndex = 4;
            //
            // lblItemCountValue
            //
            lblItemCountValue.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblItemCountValue.Appearance.Options.UseFont = true;
            lblItemCountValue.Location = new Point(300, 8);
            lblItemCountValue.Margin = new Padding(3, 5, 3, 5);
            lblItemCountValue.Name = "lblItemCountValue";
            lblItemCountValue.Size = new Size(11, 20);
            lblItemCountValue.TabIndex = 3;
            lblItemCountValue.Text = "—";
            //
            // lblItemCountTitle
            //
            lblItemCountTitle.Appearance.Font = new Font("Cairo", 9F);
            lblItemCountTitle.Appearance.Options.UseFont = true;
            lblItemCountTitle.Location = new Point(220, 8);
            lblItemCountTitle.Margin = new Padding(3, 5, 3, 5);
            lblItemCountTitle.Name = "lblItemCountTitle";
            lblItemCountTitle.Size = new Size(62, 20);
            lblItemCountTitle.TabIndex = 2;
            lblItemCountTitle.Text = "عدد البنود:";
            //
            // lblGrandTotalValue
            //
            lblGrandTotalValue.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblGrandTotalValue.Appearance.Options.UseFont = true;
            lblGrandTotalValue.Location = new Point(110, 8);
            lblGrandTotalValue.Margin = new Padding(3, 5, 3, 5);
            lblGrandTotalValue.Name = "lblGrandTotalValue";
            lblGrandTotalValue.Size = new Size(11, 20);
            lblGrandTotalValue.TabIndex = 1;
            lblGrandTotalValue.Text = "—";
            //
            // lblGrandTotalTitle
            //
            lblGrandTotalTitle.Appearance.Font = new Font("Cairo", 9F);
            lblGrandTotalTitle.Appearance.Options.UseFont = true;
            lblGrandTotalTitle.Location = new Point(12, 8);
            lblGrandTotalTitle.Margin = new Padding(3, 5, 3, 5);
            lblGrandTotalTitle.Name = "lblGrandTotalTitle";
            lblGrandTotalTitle.Size = new Size(72, 20);
            lblGrandTotalTitle.TabIndex = 0;
            lblGrandTotalTitle.Text = "الإجمالي الكلي:";
            //
            // pnlLoadingState
            //
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 220);
            pnlLoadingState.Margin = new Padding(3, 5, 3, 5);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 528);
            pnlLoadingState.TabIndex = 5;
            pnlLoadingState.Visible = false;
            //
            // lblLoadingText
            //
            lblLoadingText.Appearance.Font = new Font("Cairo", 10F);
            lblLoadingText.Appearance.Options.UseFont = true;
            lblLoadingText.Appearance.Options.UseTextOptions = true;
            lblLoadingText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblLoadingText.Location = new Point(583, 300);
            lblLoadingText.Margin = new Padding(3, 5, 3, 5);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(180, 26);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل بيانات جدول الكميات...";
            //
            // svgLoadingIcon
            //
            svgLoadingIcon.Location = new Point(651, 186);
            svgLoadingIcon.Margin = new Padding(3, 5, 3, 5);
            svgLoadingIcon.Name = "svgLoadingIcon";
            svgLoadingIcon.Size = new Size(64, 98);
            svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            svgLoadingIcon.TabIndex = 0;
            //
            // pnlEmptyState
            //
            pnlEmptyState.Controls.Add(lblEmptyText);
            pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Dock = DockStyle.Fill;
            pnlEmptyState.Location = new Point(0, 220);
            pnlEmptyState.Margin = new Padding(3, 5, 3, 5);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 528);
            pnlEmptyState.TabIndex = 6;
            pnlEmptyState.Visible = false;
            //
            // lblEmptyText
            //
            lblEmptyText.Appearance.Font = new Font("Cairo", 10F);
            lblEmptyText.Appearance.Options.UseFont = true;
            lblEmptyText.Appearance.Options.UseTextOptions = true;
            lblEmptyText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyText.Location = new Point(583, 300);
            lblEmptyText.Margin = new Padding(3, 5, 3, 5);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(146, 26);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا توجد بنود في جدول الكميات";
            //
            // svgEmptyIcon
            //
            svgEmptyIcon.Location = new Point(651, 186);
            svgEmptyIcon.Margin = new Padding(3, 5, 3, 5);
            svgEmptyIcon.Name = "svgEmptyIcon";
            svgEmptyIcon.Size = new Size(64, 98);
            svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            svgEmptyIcon.TabIndex = 0;
            //
            // pnlErrorState
            //
            pnlErrorState.Controls.Add(btnRetry);
            pnlErrorState.Controls.Add(lblErrorText);
            pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Dock = DockStyle.Fill;
            pnlErrorState.Location = new Point(0, 220);
            pnlErrorState.Margin = new Padding(3, 5, 3, 5);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 528);
            pnlErrorState.TabIndex = 7;
            pnlErrorState.Visible = false;
            //
            // btnRetry
            //
            btnRetry.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnRetry.ImageOptions.SvgImage");
            btnRetry.Location = new Point(633, 315);
            btnRetry.Margin = new Padding(3, 5, 3, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(100, 43);
            btnRetry.TabIndex = 2;
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;
            //
            // lblErrorText
            //
            lblErrorText.Appearance.Font = new Font("Cairo", 10F);
            lblErrorText.Appearance.Options.UseFont = true;
            lblErrorText.Appearance.Options.UseTextOptions = true;
            lblErrorText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblErrorText.Location = new Point(583, 269);
            lblErrorText.Margin = new Padding(3, 5, 3, 5);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(222, 26);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل بيانات جدول الكميات";
            //
            // svgErrorIcon
            //
            svgErrorIcon.Location = new Point(651, 155);
            svgErrorIcon.Margin = new Padding(3, 5, 3, 5);
            svgErrorIcon.Name = "svgErrorIcon";
            svgErrorIcon.Size = new Size(64, 98);
            svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            svgErrorIcon.TabIndex = 0;
            //
            // ucBOQEditor
            //
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grdBOQItems);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlCalculation);
            Controls.Add(pnlSummaryFooter);
            Controls.Add(pnlBOQHeader);
            Controls.Add(pnlStateBanner);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucBOQEditor";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 902);
            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlStateBanner).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgStateBannerIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlBOQHeader).EndInit();
            pnlBOQHeader.ResumeLayout(false);
            pnlBOQHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDiscipline.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRevision.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBOQName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBOQCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdBOQItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvBOQItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCalculation).EndInit();
            pnlCalculation.ResumeLayout(false);
            pnlCalculation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSummaryFooter).EndInit();
            pnlSummaryFooter.ResumeLayout(false);
            pnlSummaryFooter.PerformLayout();
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
        }

        #endregion

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
        private DevExpress.XtraBars.BarButtonItem bbiMoveUp;
        private DevExpress.XtraBars.BarButtonItem bbiMoveDown;
        private DevExpress.XtraBars.BarButtonItem bbiExpandAll;
        private DevExpress.XtraBars.BarButtonItem bbiCollapseAll;
        private DevExpress.XtraBars.BarButtonItem bbiImport;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarButtonItem bbiValidate;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiApprove;
        private DevExpress.XtraBars.BarStaticItem sbiItemCount;
        private DevExpress.XtraBars.BarStaticItem sbiLastSaved;

        private DevExpress.XtraEditors.PanelControl pnlStateBanner;
        private DevExpress.XtraEditors.SvgImageBox svgStateBannerIcon;
        private DevExpress.XtraEditors.LabelControl lblStateBanner;

        private DevExpress.XtraEditors.PanelControl pnlBOQHeader;
        private DevExpress.XtraEditors.LabelControl lblBOQCode;
        private DevExpress.XtraEditors.TextEdit txtBOQCode;
        private DevExpress.XtraEditors.LabelControl lblBOQName;
        private DevExpress.XtraEditors.TextEdit txtBOQName;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.TextEdit txtProject;
        private DevExpress.XtraEditors.LabelControl lblRevision;
        private DevExpress.XtraEditors.TextEdit txtRevision;
        private DevExpress.XtraEditors.LabelControl lblDiscipline;
        private DevExpress.XtraEditors.TextEdit txtDiscipline;
        private DevExpress.XtraEditors.LabelControl lblStatusField;
        private DevExpress.XtraEditors.TextEdit txtStatus;

        private DevExpress.XtraGrid.GridControl grdBOQItems;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvBOQItems;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandIdentification;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandQuantitiesPricing;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandClassification;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colItemNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colParent;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescriptionAr;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescriptionEn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUnit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colQuantity;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUnitRate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCostCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colWBS;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCBS;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colResourceCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRemarks;

        private DevExpress.XtraEditors.PanelControl pnlCalculation;
        private DevExpress.XtraEditors.LabelControl lblTotalQuantityTitle;
        private DevExpress.XtraEditors.LabelControl lblTotalQuantityValue;
        private DevExpress.XtraEditors.LabelControl lblTotalCostTitle;
        private DevExpress.XtraEditors.LabelControl lblTotalCostValue;
        private DevExpress.XtraEditors.LabelControl lblAverageRateTitle;
        private DevExpress.XtraEditors.LabelControl lblAverageRateValue;
        private DevExpress.XtraEditors.LabelControl lblCostVarianceTitle;
        private DevExpress.XtraEditors.LabelControl lblCostVarianceValue;
        private DevExpress.XtraEditors.LabelControl lblLastSavedTitle;
        private DevExpress.XtraEditors.LabelControl lblLastSavedValue;

        private DevExpress.XtraEditors.PanelControl pnlSummaryFooter;
        private DevExpress.XtraEditors.LabelControl lblGrandTotalTitle;
        private DevExpress.XtraEditors.LabelControl lblGrandTotalValue;
        private DevExpress.XtraEditors.LabelControl lblItemCountTitle;
        private DevExpress.XtraEditors.LabelControl lblItemCountValue;

        private DevExpress.XtraEditors.PanelControl pnlLoadingState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText;
        private DevExpress.XtraEditors.PanelControl pnlEmptyState;
        private DevExpress.XtraEditors.SvgImageBox svgEmptyIcon;
        private DevExpress.XtraEditors.LabelControl lblEmptyText;
        private DevExpress.XtraEditors.PanelControl pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}
