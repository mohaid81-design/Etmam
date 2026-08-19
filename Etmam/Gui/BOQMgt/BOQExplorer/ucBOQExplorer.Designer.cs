namespace Etmam
{
    partial class ucBOQExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBOQExplorer));
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiExpandAll = new DevExpress.XtraBars.BarButtonItem();
            bbiCollapseAll = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiSelectedNode = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            pnlStateBanner = new DevExpress.XtraEditors.PanelControl();
            lblStateBanner = new DevExpress.XtraEditors.LabelControl();
            svgStateBannerIcon = new DevExpress.XtraEditors.SvgImageBox();
            splitBOQExplorer = new DevExpress.XtraEditors.SplitContainerControl();
            tlBOQTree = new DevExpress.XtraTreeList.TreeList();
            tlcCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            tlcDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            tlcQuantity = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            tlcUnit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            tlcTotal = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            pnlDetails = new DevExpress.XtraEditors.PanelControl();
            lblDetailTotalValue = new DevExpress.XtraEditors.LabelControl();
            lblDetailTotalTitle = new DevExpress.XtraEditors.LabelControl();
            lblDetailUnitRateValue = new DevExpress.XtraEditors.LabelControl();
            lblDetailUnitRateTitle = new DevExpress.XtraEditors.LabelControl();
            lblDetailQuantityValue = new DevExpress.XtraEditors.LabelControl();
            lblDetailQuantityTitle = new DevExpress.XtraEditors.LabelControl();
            lblDetailUnitValue = new DevExpress.XtraEditors.LabelControl();
            lblDetailUnitTitle = new DevExpress.XtraEditors.LabelControl();
            lblDetailDescriptionValue = new DevExpress.XtraEditors.LabelControl();
            lblDetailDescriptionTitle = new DevExpress.XtraEditors.LabelControl();
            lblDetailCodeValue = new DevExpress.XtraEditors.LabelControl();
            lblDetailCodeTitle = new DevExpress.XtraEditors.LabelControl();
            lblDetailsHeader = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlStateBanner).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgStateBannerIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitBOQExplorer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitBOQExplorer.Panel1).BeginInit();
            splitBOQExplorer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitBOQExplorer.Panel2).BeginInit();
            splitBOQExplorer.Panel2.SuspendLayout();
            splitBOQExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tlBOQTree).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlDetails).BeginInit();
            pnlDetails.SuspendLayout();
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
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiExpandAll, bbiCollapseAll, bbiRefresh, bbiExportExcel, bbiPrint, sbiSelectedNode });
            barManagerMain.MainMenu = barMain;
            barManagerMain.MaxItemId = 6;
            barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerMain.StatusBar = barStatus;
            //
            // barMain
            //
            barMain.BarName = "شريط أدوات مستكشف جدول الكميات";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExpandAll, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCollapseAll, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.MinHeight = 34;
            barMain.OptionsBar.MultiLine = true;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "شريط أدوات مستكشف جدول الكميات";
            //
            // bbiExpandAll
            //
            bbiExpandAll.Caption = "توسيع الكل";
            bbiExpandAll.Id = 0;
            bbiExpandAll.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExpandAll.ImageOptions.SvgImage");
            bbiExpandAll.Name = "bbiExpandAll";
            bbiExpandAll.ItemClick += bbiExpandAll_ItemClick;
            //
            // bbiCollapseAll
            //
            bbiCollapseAll.Caption = "طي الكل";
            bbiCollapseAll.Id = 1;
            bbiCollapseAll.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiCollapseAll.ImageOptions.SvgImage");
            bbiCollapseAll.Name = "bbiCollapseAll";
            bbiCollapseAll.ItemClick += bbiCollapseAll_ItemClick;
            //
            // bbiRefresh
            //
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 2;
            bbiRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiRefresh.ImageOptions.SvgImage");
            bbiRefresh.Name = "bbiRefresh";
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            //
            // bbiExportExcel
            //
            bbiExportExcel.Caption = "تصدير Excel";
            bbiExportExcel.Id = 3;
            bbiExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExportExcel.ImageOptions.SvgImage");
            bbiExportExcel.Name = "bbiExportExcel";
            bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            //
            // bbiPrint
            //
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 4;
            bbiPrint.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiPrint.ImageOptions.SvgImage");
            bbiPrint.Name = "bbiPrint";
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            //
            // barStatus
            //
            barStatus.BarName = "شريط الحالة";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(sbiSelectedNode) });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "شريط الحالة";
            //
            // sbiSelectedNode
            //
            sbiSelectedNode.Caption = "العنصر المحدد: —";
            sbiSelectedNode.Id = 5;
            sbiSelectedNode.Name = "sbiSelectedNode";
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
            // svgImageCollection1
            //
            svgImageCollection1.ImageSize = new Size(20, 20);
            svgImageCollection1.Add("project", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.project"));
            svgImageCollection1.Add("building", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.building"));
            svgImageCollection1.Add("zone", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.zone"));
            svgImageCollection1.Add("floor", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.floor"));
            svgImageCollection1.Add("discipline", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.discipline"));
            svgImageCollection1.Add("section", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.section"));
            svgImageCollection1.Add("work_package", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.work_package"));
            svgImageCollection1.Add("item", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.item"));
            //
            // pnlStateBanner
            //
            pnlStateBanner.Appearance.BackColor = Color.FromArgb(238, 241, 243);
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
            lblStateBanner.Appearance.ForeColor = Color.FromArgb(69, 80, 92);
            lblStateBanner.Appearance.Options.UseFont = true;
            lblStateBanner.Appearance.Options.UseForeColor = true;
            lblStateBanner.Location = new Point(42, 9);
            lblStateBanner.Margin = new Padding(3, 5, 3, 5);
            lblStateBanner.Name = "lblStateBanner";
            lblStateBanner.Size = new Size(190, 21);
            lblStateBanner.TabIndex = 1;
            lblStateBanner.Text = "شجرة جدول الكميات مقفلة للتعديل";
            //
            // svgStateBannerIcon
            //
            svgStateBannerIcon.Location = new Point(12, 6);
            svgStateBannerIcon.Margin = new Padding(3, 5, 3, 5);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new Size(24, 24);
            svgStateBannerIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgStateBannerIcon.SvgImage");
            svgStateBannerIcon.TabIndex = 0;
            //
            // splitBOQExplorer
            //
            splitBOQExplorer.Dock = DockStyle.Fill;
            splitBOQExplorer.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
            splitBOQExplorer.Location = new Point(0, 70);
            splitBOQExplorer.Margin = new Padding(3, 5, 3, 5);
            splitBOQExplorer.Name = "splitBOQExplorer";
            //
            // splitBOQExplorer.Panel1
            //
            splitBOQExplorer.Panel1.Controls.Add(tlBOQTree);
            splitBOQExplorer.Panel1.Text = "Panel1";
            //
            // splitBOQExplorer.Panel2
            //
            splitBOQExplorer.Panel2.Controls.Add(pnlDetails);
            splitBOQExplorer.Panel2.Text = "Panel2";
            splitBOQExplorer.Size = new Size(1366, 803);
            splitBOQExplorer.SplitterPosition = 420;
            splitBOQExplorer.TabIndex = 1;
            //
            // tlBOQTree
            //
            tlBOQTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { tlcCode, tlcDescription, tlcQuantity, tlcUnit, tlcTotal });
            tlBOQTree.Dock = DockStyle.Fill;
            tlBOQTree.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            tlBOQTree.Appearance.HeaderPanel.Options.UseFont = true;
            tlBOQTree.Appearance.Row.Font = new Font("Cairo", 8F);
            tlBOQTree.Appearance.Row.Options.UseFont = true;
            tlBOQTree.KeyFieldName = "Id";
            tlBOQTree.Location = new Point(0, 0);
            tlBOQTree.Margin = new Padding(3, 5, 3, 5);
            tlBOQTree.MenuManager = barManagerMain;
            tlBOQTree.Name = "tlBOQTree";
            tlBOQTree.OptionsView.ShowIndicator = false;
            tlBOQTree.ParentFieldName = "ParentId";
            tlBOQTree.SelectImageList = svgImageCollection1;
            tlBOQTree.Size = new Size(420, 803);
            tlBOQTree.TabIndex = 0;
            //
            // tlcCode
            //
            tlcCode.Caption = "الرمز";
            tlcCode.FieldName = "Code";
            tlcCode.Name = "tlcCode";
            tlcCode.Visible = true;
            tlcCode.VisibleIndex = 0;
            tlcCode.Width = 110;
            //
            // tlcDescription
            //
            tlcDescription.Caption = "الوصف";
            tlcDescription.FieldName = "Description";
            tlcDescription.Name = "tlcDescription";
            tlcDescription.Visible = true;
            tlcDescription.VisibleIndex = 1;
            tlcDescription.Width = 220;
            //
            // tlcQuantity
            //
            tlcQuantity.Caption = "الكمية";
            tlcQuantity.Format.FormatString = "N2";
            tlcQuantity.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            tlcQuantity.FieldName = "Quantity";
            tlcQuantity.Name = "tlcQuantity";
            tlcQuantity.Visible = true;
            tlcQuantity.VisibleIndex = 2;
            tlcQuantity.Width = 90;
            //
            // tlcUnit
            //
            tlcUnit.Caption = "الوحدة";
            tlcUnit.FieldName = "Unit";
            tlcUnit.Name = "tlcUnit";
            tlcUnit.Visible = true;
            tlcUnit.VisibleIndex = 3;
            tlcUnit.Width = 70;
            //
            // tlcTotal
            //
            tlcTotal.Caption = "الإجمالي";
            tlcTotal.Format.FormatString = "N2";
            tlcTotal.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            tlcTotal.FieldName = "Total";
            tlcTotal.Name = "tlcTotal";
            tlcTotal.Visible = true;
            tlcTotal.VisibleIndex = 4;
            tlcTotal.Width = 110;
            //
            // pnlDetails
            //
            pnlDetails.Controls.Add(lblDetailTotalValue);
            pnlDetails.Controls.Add(lblDetailTotalTitle);
            pnlDetails.Controls.Add(lblDetailUnitRateValue);
            pnlDetails.Controls.Add(lblDetailUnitRateTitle);
            pnlDetails.Controls.Add(lblDetailQuantityValue);
            pnlDetails.Controls.Add(lblDetailQuantityTitle);
            pnlDetails.Controls.Add(lblDetailUnitValue);
            pnlDetails.Controls.Add(lblDetailUnitTitle);
            pnlDetails.Controls.Add(lblDetailDescriptionValue);
            pnlDetails.Controls.Add(lblDetailDescriptionTitle);
            pnlDetails.Controls.Add(lblDetailCodeValue);
            pnlDetails.Controls.Add(lblDetailCodeTitle);
            pnlDetails.Controls.Add(lblDetailsHeader);
            pnlDetails.Dock = DockStyle.Fill;
            pnlDetails.Location = new Point(0, 0);
            pnlDetails.Margin = new Padding(3, 5, 3, 5);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(936, 803);
            pnlDetails.TabIndex = 0;
            //
            // lblDetailsHeader
            //
            lblDetailsHeader.Appearance.Font = new Font("Cairo", 11F, FontStyle.Bold);
            lblDetailsHeader.Appearance.ForeColor = Color.FromArgb(30, 70, 130);
            lblDetailsHeader.Appearance.Options.UseFont = true;
            lblDetailsHeader.Appearance.Options.UseForeColor = true;
            lblDetailsHeader.Location = new Point(20, 20);
            lblDetailsHeader.Margin = new Padding(3, 5, 3, 5);
            lblDetailsHeader.Name = "lblDetailsHeader";
            lblDetailsHeader.Size = new Size(120, 26);
            lblDetailsHeader.TabIndex = 0;
            lblDetailsHeader.Text = "تفاصيل البند المحدد";
            //
            // lblDetailCodeTitle
            //
            lblDetailCodeTitle.Appearance.Font = new Font("Cairo", 8F);
            lblDetailCodeTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetailCodeTitle.Appearance.Options.UseFont = true;
            lblDetailCodeTitle.Appearance.Options.UseForeColor = true;
            lblDetailCodeTitle.Location = new Point(20, 70);
            lblDetailCodeTitle.Margin = new Padding(3, 5, 3, 5);
            lblDetailCodeTitle.Name = "lblDetailCodeTitle";
            lblDetailCodeTitle.Size = new Size(30, 20);
            lblDetailCodeTitle.TabIndex = 1;
            lblDetailCodeTitle.Text = "الرمز";
            //
            // lblDetailCodeValue
            //
            lblDetailCodeValue.Appearance.Font = new Font("Cairo", 9.5F, FontStyle.Bold);
            lblDetailCodeValue.Appearance.Options.UseFont = true;
            lblDetailCodeValue.Location = new Point(20, 92);
            lblDetailCodeValue.Margin = new Padding(3, 5, 3, 5);
            lblDetailCodeValue.Name = "lblDetailCodeValue";
            lblDetailCodeValue.Size = new Size(14, 23);
            lblDetailCodeValue.TabIndex = 2;
            lblDetailCodeValue.Text = "—";
            //
            // lblDetailDescriptionTitle
            //
            lblDetailDescriptionTitle.Appearance.Font = new Font("Cairo", 8F);
            lblDetailDescriptionTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetailDescriptionTitle.Appearance.Options.UseFont = true;
            lblDetailDescriptionTitle.Appearance.Options.UseForeColor = true;
            lblDetailDescriptionTitle.Location = new Point(20, 130);
            lblDetailDescriptionTitle.Margin = new Padding(3, 5, 3, 5);
            lblDetailDescriptionTitle.Name = "lblDetailDescriptionTitle";
            lblDetailDescriptionTitle.Size = new Size(31, 20);
            lblDetailDescriptionTitle.TabIndex = 3;
            lblDetailDescriptionTitle.Text = "الوصف";
            //
            // lblDetailDescriptionValue
            //
            lblDetailDescriptionValue.Appearance.Font = new Font("Cairo", 9.5F, FontStyle.Bold);
            lblDetailDescriptionValue.Appearance.Options.UseFont = true;
            lblDetailDescriptionValue.Location = new Point(20, 152);
            lblDetailDescriptionValue.Margin = new Padding(3, 5, 3, 5);
            lblDetailDescriptionValue.Name = "lblDetailDescriptionValue";
            lblDetailDescriptionValue.Size = new Size(14, 23);
            lblDetailDescriptionValue.TabIndex = 4;
            lblDetailDescriptionValue.Text = "—";
            //
            // lblDetailUnitTitle
            //
            lblDetailUnitTitle.Appearance.Font = new Font("Cairo", 8F);
            lblDetailUnitTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetailUnitTitle.Appearance.Options.UseFont = true;
            lblDetailUnitTitle.Appearance.Options.UseForeColor = true;
            lblDetailUnitTitle.Location = new Point(20, 190);
            lblDetailUnitTitle.Margin = new Padding(3, 5, 3, 5);
            lblDetailUnitTitle.Name = "lblDetailUnitTitle";
            lblDetailUnitTitle.Size = new Size(37, 20);
            lblDetailUnitTitle.TabIndex = 5;
            lblDetailUnitTitle.Text = "الوحدة";
            //
            // lblDetailUnitValue
            //
            lblDetailUnitValue.Appearance.Font = new Font("Cairo", 9.5F, FontStyle.Bold);
            lblDetailUnitValue.Appearance.Options.UseFont = true;
            lblDetailUnitValue.Location = new Point(20, 212);
            lblDetailUnitValue.Margin = new Padding(3, 5, 3, 5);
            lblDetailUnitValue.Name = "lblDetailUnitValue";
            lblDetailUnitValue.Size = new Size(14, 23);
            lblDetailUnitValue.TabIndex = 6;
            lblDetailUnitValue.Text = "—";
            //
            // lblDetailQuantityTitle
            //
            lblDetailQuantityTitle.Appearance.Font = new Font("Cairo", 8F);
            lblDetailQuantityTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetailQuantityTitle.Appearance.Options.UseFont = true;
            lblDetailQuantityTitle.Appearance.Options.UseForeColor = true;
            lblDetailQuantityTitle.Location = new Point(20, 250);
            lblDetailQuantityTitle.Margin = new Padding(3, 5, 3, 5);
            lblDetailQuantityTitle.Name = "lblDetailQuantityTitle";
            lblDetailQuantityTitle.Size = new Size(34, 20);
            lblDetailQuantityTitle.TabIndex = 7;
            lblDetailQuantityTitle.Text = "الكمية";
            //
            // lblDetailQuantityValue
            //
            lblDetailQuantityValue.Appearance.Font = new Font("Cairo", 9.5F, FontStyle.Bold);
            lblDetailQuantityValue.Appearance.Options.UseFont = true;
            lblDetailQuantityValue.Location = new Point(20, 272);
            lblDetailQuantityValue.Margin = new Padding(3, 5, 3, 5);
            lblDetailQuantityValue.Name = "lblDetailQuantityValue";
            lblDetailQuantityValue.Size = new Size(14, 23);
            lblDetailQuantityValue.TabIndex = 8;
            lblDetailQuantityValue.Text = "—";
            //
            // lblDetailUnitRateTitle
            //
            lblDetailUnitRateTitle.Appearance.Font = new Font("Cairo", 8F);
            lblDetailUnitRateTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetailUnitRateTitle.Appearance.Options.UseFont = true;
            lblDetailUnitRateTitle.Appearance.Options.UseForeColor = true;
            lblDetailUnitRateTitle.Location = new Point(20, 310);
            lblDetailUnitRateTitle.Margin = new Padding(3, 5, 3, 5);
            lblDetailUnitRateTitle.Name = "lblDetailUnitRateTitle";
            lblDetailUnitRateTitle.Size = new Size(48, 20);
            lblDetailUnitRateTitle.TabIndex = 9;
            lblDetailUnitRateTitle.Text = "سعر الوحدة";
            //
            // lblDetailUnitRateValue
            //
            lblDetailUnitRateValue.Appearance.Font = new Font("Cairo", 9.5F, FontStyle.Bold);
            lblDetailUnitRateValue.Appearance.Options.UseFont = true;
            lblDetailUnitRateValue.Location = new Point(20, 332);
            lblDetailUnitRateValue.Margin = new Padding(3, 5, 3, 5);
            lblDetailUnitRateValue.Name = "lblDetailUnitRateValue";
            lblDetailUnitRateValue.Size = new Size(14, 23);
            lblDetailUnitRateValue.TabIndex = 10;
            lblDetailUnitRateValue.Text = "—";
            //
            // lblDetailTotalTitle
            //
            lblDetailTotalTitle.Appearance.Font = new Font("Cairo", 8F);
            lblDetailTotalTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetailTotalTitle.Appearance.Options.UseFont = true;
            lblDetailTotalTitle.Appearance.Options.UseForeColor = true;
            lblDetailTotalTitle.Location = new Point(20, 370);
            lblDetailTotalTitle.Margin = new Padding(3, 5, 3, 5);
            lblDetailTotalTitle.Name = "lblDetailTotalTitle";
            lblDetailTotalTitle.Size = new Size(40, 20);
            lblDetailTotalTitle.TabIndex = 11;
            lblDetailTotalTitle.Text = "الإجمالي";
            //
            // lblDetailTotalValue
            //
            lblDetailTotalValue.Appearance.Font = new Font("Cairo", 13F, FontStyle.Bold);
            lblDetailTotalValue.Appearance.ForeColor = Color.FromArgb(28, 140, 140);
            lblDetailTotalValue.Appearance.Options.UseFont = true;
            lblDetailTotalValue.Appearance.Options.UseForeColor = true;
            lblDetailTotalValue.Location = new Point(20, 392);
            lblDetailTotalValue.Margin = new Padding(3, 5, 3, 5);
            lblDetailTotalValue.Name = "lblDetailTotalValue";
            lblDetailTotalValue.Size = new Size(18, 30);
            lblDetailTotalValue.TabIndex = 12;
            lblDetailTotalValue.Text = "—";
            //
            // pnlLoadingState
            //
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 70);
            pnlLoadingState.Margin = new Padding(3, 5, 3, 5);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 803);
            pnlLoadingState.TabIndex = 2;
            pnlLoadingState.Visible = false;
            //
            // lblLoadingText
            //
            lblLoadingText.Appearance.Font = new Font("Cairo", 10F);
            lblLoadingText.Appearance.Options.UseFont = true;
            lblLoadingText.Appearance.Options.UseTextOptions = true;
            lblLoadingText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblLoadingText.Location = new Point(583, 380);
            lblLoadingText.Margin = new Padding(3, 5, 3, 5);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(180, 26);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل شجرة البنود...";
            //
            // svgLoadingIcon
            //
            svgLoadingIcon.Location = new Point(651, 280);
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
            pnlEmptyState.Location = new Point(0, 70);
            pnlEmptyState.Margin = new Padding(3, 5, 3, 5);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 803);
            pnlEmptyState.TabIndex = 3;
            pnlEmptyState.Visible = false;
            //
            // lblEmptyText
            //
            lblEmptyText.Appearance.Font = new Font("Cairo", 10F);
            lblEmptyText.Appearance.Options.UseFont = true;
            lblEmptyText.Appearance.Options.UseTextOptions = true;
            lblEmptyText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyText.Location = new Point(583, 380);
            lblEmptyText.Margin = new Padding(3, 5, 3, 5);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(150, 26);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا توجد بنود لعرضها";
            //
            // svgEmptyIcon
            //
            svgEmptyIcon.Location = new Point(651, 280);
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
            pnlErrorState.Location = new Point(0, 70);
            pnlErrorState.Margin = new Padding(3, 5, 3, 5);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 803);
            pnlErrorState.TabIndex = 4;
            pnlErrorState.Visible = false;
            //
            // btnRetry
            //
            btnRetry.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnRetry.ImageOptions.SvgImage");
            btnRetry.Location = new Point(633, 409);
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
            lblErrorText.Location = new Point(583, 363);
            lblErrorText.Margin = new Padding(3, 5, 3, 5);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(180, 26);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل شجرة البنود";
            //
            // svgErrorIcon
            //
            svgErrorIcon.Location = new Point(651, 249);
            svgErrorIcon.Margin = new Padding(3, 5, 3, 5);
            svgErrorIcon.Name = "svgErrorIcon";
            svgErrorIcon.Size = new Size(64, 98);
            svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            svgErrorIcon.TabIndex = 0;
            //
            // ucBOQExplorer
            //
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitBOQExplorer);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlStateBanner);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucBOQExplorer";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 902);
            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlStateBanner).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgStateBannerIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitBOQExplorer.Panel1).EndInit();
            splitBOQExplorer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitBOQExplorer.Panel2).EndInit();
            splitBOQExplorer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitBOQExplorer).EndInit();
            splitBOQExplorer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tlBOQTree).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlDetails).EndInit();
            pnlDetails.ResumeLayout(false);
            pnlDetails.PerformLayout();
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
        private DevExpress.XtraBars.BarButtonItem bbiExpandAll;
        private DevExpress.XtraBars.BarButtonItem bbiCollapseAll;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiExportExcel;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarStaticItem sbiSelectedNode;

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;

        private DevExpress.XtraEditors.PanelControl pnlStateBanner;
        private DevExpress.XtraEditors.LabelControl lblStateBanner;
        private DevExpress.XtraEditors.SvgImageBox svgStateBannerIcon;

        private DevExpress.XtraEditors.SplitContainerControl splitBOQExplorer;
        private DevExpress.XtraTreeList.TreeList tlBOQTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcQuantity;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcUnit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcTotal;

        private DevExpress.XtraEditors.PanelControl pnlDetails;
        private DevExpress.XtraEditors.LabelControl lblDetailsHeader;
        private DevExpress.XtraEditors.LabelControl lblDetailCodeTitle;
        private DevExpress.XtraEditors.LabelControl lblDetailCodeValue;
        private DevExpress.XtraEditors.LabelControl lblDetailDescriptionTitle;
        private DevExpress.XtraEditors.LabelControl lblDetailDescriptionValue;
        private DevExpress.XtraEditors.LabelControl lblDetailUnitTitle;
        private DevExpress.XtraEditors.LabelControl lblDetailUnitValue;
        private DevExpress.XtraEditors.LabelControl lblDetailQuantityTitle;
        private DevExpress.XtraEditors.LabelControl lblDetailQuantityValue;
        private DevExpress.XtraEditors.LabelControl lblDetailUnitRateTitle;
        private DevExpress.XtraEditors.LabelControl lblDetailUnitRateValue;
        private DevExpress.XtraEditors.LabelControl lblDetailTotalTitle;
        private DevExpress.XtraEditors.LabelControl lblDetailTotalValue;

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
