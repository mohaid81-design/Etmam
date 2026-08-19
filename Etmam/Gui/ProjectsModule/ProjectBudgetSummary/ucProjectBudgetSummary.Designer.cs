namespace Etmam
{
    partial class ucProjectBudgetSummary
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
            barManagerBudget = new DevExpress.XtraBars.BarManager(components);
            barBudget = new DevExpress.XtraBars.Bar();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiRecordCount = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();

            pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            pnlKpiOriginalBudget = new DevExpress.XtraEditors.PanelControl();
            lblKpiOriginalBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiOriginalBudgetValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiApprovedBudget = new DevExpress.XtraEditors.PanelControl();
            lblKpiApprovedBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiApprovedBudgetValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiActualCost = new DevExpress.XtraEditors.PanelControl();
            lblKpiActualCostTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiActualCostValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiCommitment = new DevExpress.XtraEditors.PanelControl();
            lblKpiCommitmentTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiCommitmentValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiForecast = new DevExpress.XtraEditors.PanelControl();
            lblKpiForecastTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiForecastValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiVariance = new DevExpress.XtraEditors.PanelControl();
            lblKpiVarianceTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiVarianceValue = new DevExpress.XtraEditors.LabelControl();

            pnlCharts = new DevExpress.XtraEditors.PanelControl();
            lblBudgetVsActualCaption = new DevExpress.XtraEditors.LabelControl();
            chartBudgetVsActual = new DevExpress.XtraCharts.ChartControl();
            seriesBudget = new DevExpress.XtraCharts.Series("الموازنة", DevExpress.XtraCharts.ViewType.Bar);
            seriesActualCost = new DevExpress.XtraCharts.Series("الفعلي", DevExpress.XtraCharts.ViewType.Bar);
            xyDiagramBudgetVsActual = new DevExpress.XtraCharts.XYDiagram();
            lblForecastChartCaption = new DevExpress.XtraEditors.LabelControl();
            chartForecast = new DevExpress.XtraCharts.ChartControl();
            seriesForecast = new DevExpress.XtraCharts.Series("التوقع", DevExpress.XtraCharts.ViewType.Spline);
            xyDiagramForecast = new DevExpress.XtraCharts.XYDiagram();
            lblCashFlowChartCaption = new DevExpress.XtraEditors.LabelControl();
            chartCashFlow = new DevExpress.XtraCharts.ChartControl();
            seriesCashFlow = new DevExpress.XtraCharts.Series("التدفق النقدي", DevExpress.XtraCharts.ViewType.Bar);
            xyDiagramCashFlow = new DevExpress.XtraCharts.XYDiagram();

            grdBudgetBreakdown = new DevExpress.XtraGrid.GridControl();
            gvBudgetBreakdown = new DevExpress.XtraGrid.Views.Grid.GridView();
            colBudgetItem = new DevExpress.XtraGrid.Columns.GridColumn();
            colOriginalBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            colApprovedBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            colActualCost = new DevExpress.XtraGrid.Columns.GridColumn();
            colCommitment = new DevExpress.XtraGrid.Columns.GridColumn();
            colRemaining = new DevExpress.XtraGrid.Columns.GridColumn();

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

            ((System.ComponentModel.ISupportInitialize)barManagerBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit();
            pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiOriginalBudget).BeginInit();
            pnlKpiOriginalBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiApprovedBudget).BeginInit();
            pnlKpiApprovedBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActualCost).BeginInit();
            pnlKpiActualCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCommitment).BeginInit();
            pnlKpiCommitment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).BeginInit();
            pnlKpiForecast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiVariance).BeginInit();
            pnlKpiVariance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).BeginInit();
            pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartBudgetVsActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesBudget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramBudgetVsActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCashFlow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesCashFlow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramCashFlow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdBudgetBreakdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvBudgetBreakdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            SuspendLayout();
            //
            // barManagerBudget
            //
            barManagerBudget.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barBudget, barStatus });
            barManagerBudget.DockControls.Add(barDockControlTop);
            barManagerBudget.DockControls.Add(barDockControlBottom);
            barManagerBudget.DockControls.Add(barDockControlLeft);
            barManagerBudget.DockControls.Add(barDockControlRight);
            barManagerBudget.Form = this;
            barManagerBudget.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiRefresh, bbiPrint, bbiExportExcel, bbiExportPdf, sbiRecordCount });
            barManagerBudget.MainMenu = barBudget;
            barManagerBudget.MaxItemId = 5;
            barManagerBudget.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerBudget.StatusBar = barStatus;
            //
            // barBudget
            //
            barBudget.BarName = "شريط أدوات الموازنة";
            barBudget.DockCol = 0;
            barBudget.DockRow = 0;
            barBudget.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barBudget.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportPdf, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barBudget.OptionsBar.AllowQuickCustomization = false;
            barBudget.OptionsBar.DrawDragBorder = false;
            barBudget.OptionsBar.MinHeight = 34;
            barBudget.OptionsBar.UseWholeRow = true;
            barBudget.Text = "شريط أدوات الموازنة";
            //
            // bbiRefresh
            //
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 0;
            bbiRefresh.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            bbiRefresh.Name = "bbiRefresh";
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            //
            // bbiPrint
            //
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 1;
            bbiPrint.ImageOptions.SvgImage = Etmam.IconLoader.Get("print.svg");
            bbiPrint.Name = "bbiPrint";
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            //
            // bbiExportExcel
            //
            bbiExportExcel.Caption = "تصدير Excel";
            bbiExportExcel.Id = 2;
            bbiExportExcel.ImageOptions.SvgImage = Etmam.IconLoader.Get("export_excel.svg");
            bbiExportExcel.Name = "bbiExportExcel";
            bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            //
            // bbiExportPdf
            //
            bbiExportPdf.Caption = "تصدير PDF";
            bbiExportPdf.Id = 3;
            bbiExportPdf.ImageOptions.SvgImage = Etmam.IconLoader.Get("export_pdf.svg");
            bbiExportPdf.Name = "bbiExportPdf";
            bbiExportPdf.ItemClick += bbiExportPdf_ItemClick;
            //
            // barStatus
            //
            barStatus.BarName = "شريط الحالة";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(sbiRecordCount) });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "شريط الحالة";
            //
            // sbiRecordCount
            //
            sbiRecordCount.Caption = "عدد البنود: 0";
            sbiRecordCount.Id = 4;
            sbiRecordCount.Name = "sbiRecordCount";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerBudget;
            barDockControlTop.Size = new Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 796);
            barDockControlBottom.Manager = barManagerBudget;
            barDockControlBottom.Size = new Size(1366, 24);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerBudget;
            barDockControlLeft.Size = new Size(0, 762);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerBudget;
            barDockControlRight.Size = new Size(0, 762);
            //
            // pnlKpiCards
            //
            pnlKpiCards.Controls.Add(pnlKpiVariance);
            pnlKpiCards.Controls.Add(pnlKpiForecast);
            pnlKpiCards.Controls.Add(pnlKpiCommitment);
            pnlKpiCards.Controls.Add(pnlKpiActualCost);
            pnlKpiCards.Controls.Add(pnlKpiApprovedBudget);
            pnlKpiCards.Controls.Add(pnlKpiOriginalBudget);
            pnlKpiCards.Dock = DockStyle.Top;
            pnlKpiCards.Location = new Point(0, 34);
            pnlKpiCards.Name = "pnlKpiCards";
            pnlKpiCards.Size = new Size(1366, 236);
            pnlKpiCards.TabIndex = 0;
            //
            // pnlKpiOriginalBudget
            //
            pnlKpiOriginalBudget.Appearance.BackColor = Color.FromArgb(238, 240, 252);
            pnlKpiOriginalBudget.Appearance.Options.UseBackColor = true;
            pnlKpiOriginalBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiOriginalBudget.Controls.Add(lblKpiOriginalBudgetValue);
            pnlKpiOriginalBudget.Controls.Add(lblKpiOriginalBudgetTitle);
            pnlKpiOriginalBudget.Location = new Point(20, 20);
            pnlKpiOriginalBudget.Name = "pnlKpiOriginalBudget";
            pnlKpiOriginalBudget.Size = new Size(280, 90);
            pnlKpiOriginalBudget.TabIndex = 0;
            //
            // lblKpiOriginalBudgetTitle
            //
            lblKpiOriginalBudgetTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiOriginalBudgetTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiOriginalBudgetTitle.Appearance.Options.UseFont = true;
            lblKpiOriginalBudgetTitle.Appearance.Options.UseForeColor = true;
            lblKpiOriginalBudgetTitle.Location = new Point(12, 12);
            lblKpiOriginalBudgetTitle.Name = "lblKpiOriginalBudgetTitle";
            lblKpiOriginalBudgetTitle.Size = new Size(72, 17);
            lblKpiOriginalBudgetTitle.TabIndex = 0;
            lblKpiOriginalBudgetTitle.Text = "الموازنة الأصلية";
            //
            // lblKpiOriginalBudgetValue
            //
            lblKpiOriginalBudgetValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiOriginalBudgetValue.Appearance.ForeColor = Color.FromArgb(91, 79, 207);
            lblKpiOriginalBudgetValue.Appearance.Options.UseFont = true;
            lblKpiOriginalBudgetValue.Appearance.Options.UseForeColor = true;
            lblKpiOriginalBudgetValue.Location = new Point(12, 38);
            lblKpiOriginalBudgetValue.Name = "lblKpiOriginalBudgetValue";
            lblKpiOriginalBudgetValue.Size = new Size(20, 25);
            lblKpiOriginalBudgetValue.TabIndex = 1;
            lblKpiOriginalBudgetValue.Text = "—";
            //
            // pnlKpiApprovedBudget
            //
            pnlKpiApprovedBudget.Appearance.BackColor = Color.FromArgb(232, 246, 246);
            pnlKpiApprovedBudget.Appearance.Options.UseBackColor = true;
            pnlKpiApprovedBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiApprovedBudget.Controls.Add(lblKpiApprovedBudgetValue);
            pnlKpiApprovedBudget.Controls.Add(lblKpiApprovedBudgetTitle);
            pnlKpiApprovedBudget.Location = new Point(320, 20);
            pnlKpiApprovedBudget.Name = "pnlKpiApprovedBudget";
            pnlKpiApprovedBudget.Size = new Size(280, 90);
            pnlKpiApprovedBudget.TabIndex = 1;
            //
            // lblKpiApprovedBudgetTitle
            //
            lblKpiApprovedBudgetTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiApprovedBudgetTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiApprovedBudgetTitle.Appearance.Options.UseFont = true;
            lblKpiApprovedBudgetTitle.Appearance.Options.UseForeColor = true;
            lblKpiApprovedBudgetTitle.Location = new Point(12, 12);
            lblKpiApprovedBudgetTitle.Name = "lblKpiApprovedBudgetTitle";
            lblKpiApprovedBudgetTitle.Size = new Size(78, 17);
            lblKpiApprovedBudgetTitle.TabIndex = 0;
            lblKpiApprovedBudgetTitle.Text = "الموازنة المعتمدة";
            //
            // lblKpiApprovedBudgetValue
            //
            lblKpiApprovedBudgetValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiApprovedBudgetValue.Appearance.ForeColor = Color.FromArgb(28, 140, 140);
            lblKpiApprovedBudgetValue.Appearance.Options.UseFont = true;
            lblKpiApprovedBudgetValue.Appearance.Options.UseForeColor = true;
            lblKpiApprovedBudgetValue.Location = new Point(12, 38);
            lblKpiApprovedBudgetValue.Name = "lblKpiApprovedBudgetValue";
            lblKpiApprovedBudgetValue.Size = new Size(20, 25);
            lblKpiApprovedBudgetValue.TabIndex = 1;
            lblKpiApprovedBudgetValue.Text = "—";
            //
            // pnlKpiActualCost
            //
            pnlKpiActualCost.Appearance.BackColor = Color.FromArgb(234, 243, 252);
            pnlKpiActualCost.Appearance.Options.UseBackColor = true;
            pnlKpiActualCost.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiActualCost.Controls.Add(lblKpiActualCostValue);
            pnlKpiActualCost.Controls.Add(lblKpiActualCostTitle);
            pnlKpiActualCost.Location = new Point(620, 20);
            pnlKpiActualCost.Name = "pnlKpiActualCost";
            pnlKpiActualCost.Size = new Size(280, 90);
            pnlKpiActualCost.TabIndex = 2;
            //
            // lblKpiActualCostTitle
            //
            lblKpiActualCostTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiActualCostTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiActualCostTitle.Appearance.Options.UseFont = true;
            lblKpiActualCostTitle.Appearance.Options.UseForeColor = true;
            lblKpiActualCostTitle.Location = new Point(12, 12);
            lblKpiActualCostTitle.Name = "lblKpiActualCostTitle";
            lblKpiActualCostTitle.Size = new Size(69, 17);
            lblKpiActualCostTitle.TabIndex = 0;
            lblKpiActualCostTitle.Text = "التكلفة الفعلية";
            //
            // lblKpiActualCostValue
            //
            lblKpiActualCostValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiActualCostValue.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblKpiActualCostValue.Appearance.Options.UseFont = true;
            lblKpiActualCostValue.Appearance.Options.UseForeColor = true;
            lblKpiActualCostValue.Location = new Point(12, 38);
            lblKpiActualCostValue.Name = "lblKpiActualCostValue";
            lblKpiActualCostValue.Size = new Size(20, 25);
            lblKpiActualCostValue.TabIndex = 1;
            lblKpiActualCostValue.Text = "—";
            //
            // pnlKpiCommitment
            //
            pnlKpiCommitment.Appearance.BackColor = Color.FromArgb(255, 246, 229);
            pnlKpiCommitment.Appearance.Options.UseBackColor = true;
            pnlKpiCommitment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCommitment.Controls.Add(lblKpiCommitmentValue);
            pnlKpiCommitment.Controls.Add(lblKpiCommitmentTitle);
            pnlKpiCommitment.Location = new Point(20, 126);
            pnlKpiCommitment.Name = "pnlKpiCommitment";
            pnlKpiCommitment.Size = new Size(280, 90);
            pnlKpiCommitment.TabIndex = 3;
            //
            // lblKpiCommitmentTitle
            //
            lblKpiCommitmentTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiCommitmentTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiCommitmentTitle.Appearance.Options.UseFont = true;
            lblKpiCommitmentTitle.Appearance.Options.UseForeColor = true;
            lblKpiCommitmentTitle.Location = new Point(12, 12);
            lblKpiCommitmentTitle.Name = "lblKpiCommitmentTitle";
            lblKpiCommitmentTitle.Size = new Size(49, 17);
            lblKpiCommitmentTitle.TabIndex = 0;
            lblKpiCommitmentTitle.Text = "الالتزامات";
            //
            // lblKpiCommitmentValue
            //
            lblKpiCommitmentValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiCommitmentValue.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            lblKpiCommitmentValue.Appearance.Options.UseFont = true;
            lblKpiCommitmentValue.Appearance.Options.UseForeColor = true;
            lblKpiCommitmentValue.Location = new Point(12, 38);
            lblKpiCommitmentValue.Name = "lblKpiCommitmentValue";
            lblKpiCommitmentValue.Size = new Size(20, 25);
            lblKpiCommitmentValue.TabIndex = 1;
            lblKpiCommitmentValue.Text = "—";
            //
            // pnlKpiForecast
            //
            pnlKpiForecast.Appearance.BackColor = Color.FromArgb(243, 236, 251);
            pnlKpiForecast.Appearance.Options.UseBackColor = true;
            pnlKpiForecast.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiForecast.Controls.Add(lblKpiForecastValue);
            pnlKpiForecast.Controls.Add(lblKpiForecastTitle);
            pnlKpiForecast.Location = new Point(320, 126);
            pnlKpiForecast.Name = "pnlKpiForecast";
            pnlKpiForecast.Size = new Size(280, 90);
            pnlKpiForecast.TabIndex = 4;
            //
            // lblKpiForecastTitle
            //
            lblKpiForecastTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiForecastTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiForecastTitle.Appearance.Options.UseFont = true;
            lblKpiForecastTitle.Appearance.Options.UseForeColor = true;
            lblKpiForecastTitle.Location = new Point(12, 12);
            lblKpiForecastTitle.Name = "lblKpiForecastTitle";
            lblKpiForecastTitle.Size = new Size(87, 17);
            lblKpiForecastTitle.TabIndex = 0;
            lblKpiForecastTitle.Text = "التكلفة المتوقعة";
            //
            // lblKpiForecastValue
            //
            lblKpiForecastValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiForecastValue.Appearance.ForeColor = Color.FromArgb(123, 79, 166);
            lblKpiForecastValue.Appearance.Options.UseFont = true;
            lblKpiForecastValue.Appearance.Options.UseForeColor = true;
            lblKpiForecastValue.Location = new Point(12, 38);
            lblKpiForecastValue.Name = "lblKpiForecastValue";
            lblKpiForecastValue.Size = new Size(20, 25);
            lblKpiForecastValue.TabIndex = 1;
            lblKpiForecastValue.Text = "—";
            //
            // pnlKpiVariance
            //
            pnlKpiVariance.Appearance.BackColor = Color.FromArgb(253, 237, 236);
            pnlKpiVariance.Appearance.Options.UseBackColor = true;
            pnlKpiVariance.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiVariance.Controls.Add(lblKpiVarianceValue);
            pnlKpiVariance.Controls.Add(lblKpiVarianceTitle);
            pnlKpiVariance.Location = new Point(620, 126);
            pnlKpiVariance.Name = "pnlKpiVariance";
            pnlKpiVariance.Size = new Size(280, 90);
            pnlKpiVariance.TabIndex = 5;
            //
            // lblKpiVarianceTitle
            //
            lblKpiVarianceTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiVarianceTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiVarianceTitle.Appearance.Options.UseFont = true;
            lblKpiVarianceTitle.Appearance.Options.UseForeColor = true;
            lblKpiVarianceTitle.Location = new Point(12, 12);
            lblKpiVarianceTitle.Name = "lblKpiVarianceTitle";
            lblKpiVarianceTitle.Size = new Size(45, 17);
            lblKpiVarianceTitle.TabIndex = 0;
            lblKpiVarianceTitle.Text = "الانحراف";
            //
            // lblKpiVarianceValue
            //
            lblKpiVarianceValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiVarianceValue.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblKpiVarianceValue.Appearance.Options.UseFont = true;
            lblKpiVarianceValue.Appearance.Options.UseForeColor = true;
            lblKpiVarianceValue.Location = new Point(12, 38);
            lblKpiVarianceValue.Name = "lblKpiVarianceValue";
            lblKpiVarianceValue.Size = new Size(20, 25);
            lblKpiVarianceValue.TabIndex = 1;
            lblKpiVarianceValue.Text = "—";
            //
            // pnlCharts
            //
            pnlCharts.Controls.Add(chartCashFlow);
            pnlCharts.Controls.Add(lblCashFlowChartCaption);
            pnlCharts.Controls.Add(chartForecast);
            pnlCharts.Controls.Add(lblForecastChartCaption);
            pnlCharts.Controls.Add(chartBudgetVsActual);
            pnlCharts.Controls.Add(lblBudgetVsActualCaption);
            pnlCharts.Dock = DockStyle.Top;
            pnlCharts.Location = new Point(0, 270);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Size = new Size(1366, 340);
            pnlCharts.TabIndex = 1;
            //
            // lblBudgetVsActualCaption
            //
            lblBudgetVsActualCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblBudgetVsActualCaption.Appearance.Options.UseFont = true;
            lblBudgetVsActualCaption.Location = new Point(12, 12);
            lblBudgetVsActualCaption.Name = "lblBudgetVsActualCaption";
            lblBudgetVsActualCaption.Size = new Size(100, 20);
            lblBudgetVsActualCaption.TabIndex = 0;
            lblBudgetVsActualCaption.Text = "الموازنة مقابل الفعلي";
            //
            // chartBudgetVsActual
            //
            chartBudgetVsActual.Diagram = xyDiagramBudgetVsActual;
            chartBudgetVsActual.Location = new Point(12, 36);
            chartBudgetVsActual.Name = "chartBudgetVsActual";
            chartBudgetVsActual.SeriesTemplate.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            chartBudgetVsActual.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesBudget, seriesActualCost });
            chartBudgetVsActual.Size = new Size(436, 296);
            chartBudgetVsActual.TabIndex = 1;
            //
            // seriesBudget
            //
            seriesBudget.Name = "الموازنة";
            seriesBudget.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            //
            // seriesActualCost
            //
            seriesActualCost.Name = "الفعلي";
            seriesActualCost.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            //
            // xyDiagramBudgetVsActual
            //
            //
            // lblForecastChartCaption
            //
            lblForecastChartCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblForecastChartCaption.Appearance.Options.UseFont = true;
            lblForecastChartCaption.Location = new Point(460, 12);
            lblForecastChartCaption.Name = "lblForecastChartCaption";
            lblForecastChartCaption.Size = new Size(70, 20);
            lblForecastChartCaption.TabIndex = 2;
            lblForecastChartCaption.Text = "التوقع (Forecast)";
            //
            // chartForecast
            //
            chartForecast.Diagram = xyDiagramForecast;
            chartForecast.Location = new Point(460, 36);
            chartForecast.Name = "chartForecast";
            chartForecast.SeriesTemplate.View = new DevExpress.XtraCharts.SplineSeriesView();
            chartForecast.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesForecast });
            chartForecast.Size = new Size(436, 296);
            chartForecast.TabIndex = 3;
            //
            // seriesForecast
            //
            seriesForecast.Name = "التوقع";
            seriesForecast.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // xyDiagramForecast
            //
            //
            // lblCashFlowChartCaption
            //
            lblCashFlowChartCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblCashFlowChartCaption.Appearance.Options.UseFont = true;
            lblCashFlowChartCaption.Location = new Point(908, 12);
            lblCashFlowChartCaption.Name = "lblCashFlowChartCaption";
            lblCashFlowChartCaption.Size = new Size(80, 20);
            lblCashFlowChartCaption.TabIndex = 4;
            lblCashFlowChartCaption.Text = "التدفق النقدي";
            //
            // chartCashFlow
            //
            chartCashFlow.Diagram = xyDiagramCashFlow;
            chartCashFlow.Location = new Point(908, 36);
            chartCashFlow.Name = "chartCashFlow";
            chartCashFlow.SeriesTemplate.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            chartCashFlow.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesCashFlow });
            chartCashFlow.Size = new Size(436, 296);
            chartCashFlow.TabIndex = 5;
            //
            // seriesCashFlow
            //
            seriesCashFlow.Name = "التدفق النقدي";
            seriesCashFlow.View = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            //
            // xyDiagramCashFlow
            //
            //
            // grdBudgetBreakdown
            //
            grdBudgetBreakdown.Dock = DockStyle.Fill;
            grdBudgetBreakdown.Location = new Point(0, 610);
            grdBudgetBreakdown.MainView = gvBudgetBreakdown;
            grdBudgetBreakdown.MenuManager = barManagerBudget;
            grdBudgetBreakdown.Name = "grdBudgetBreakdown";
            grdBudgetBreakdown.Size = new Size(1366, 186);
            grdBudgetBreakdown.TabIndex = 2;
            grdBudgetBreakdown.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvBudgetBreakdown });
            //
            // gvBudgetBreakdown
            //
            gvBudgetBreakdown.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvBudgetBreakdown.Appearance.HeaderPanel.Options.UseFont = true;
            gvBudgetBreakdown.Appearance.Row.Font = new Font("Cairo", 8F);
            gvBudgetBreakdown.Appearance.Row.Options.UseFont = true;
            gvBudgetBreakdown.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colBudgetItem, colOriginalBudget, colApprovedBudget, colActualCost, colCommitment, colRemaining });
            gvBudgetBreakdown.GridControl = grdBudgetBreakdown;
            gvBudgetBreakdown.Name = "gvBudgetBreakdown";
            gvBudgetBreakdown.OptionsView.ColumnAutoWidth = false;
            gvBudgetBreakdown.OptionsView.ShowAutoFilterRow = true;
            gvBudgetBreakdown.OptionsView.ShowFooter = true;
            //
            // colBudgetItem
            //
            colBudgetItem.Caption = "بند الموازنة";
            colBudgetItem.FieldName = "BudgetItem";
            colBudgetItem.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colBudgetItem.Name = "colBudgetItem";
            colBudgetItem.OptionsColumn.AllowEdit = false;
            colBudgetItem.Visible = true;
            colBudgetItem.VisibleIndex = 0;
            colBudgetItem.Width = 260;
            //
            // colOriginalBudget
            //
            colOriginalBudget.Caption = "الموازنة الأصلية";
            colOriginalBudget.DisplayFormat.FormatString = "N2";
            colOriginalBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colOriginalBudget.FieldName = "OriginalBudget";
            colOriginalBudget.Name = "colOriginalBudget";
            colOriginalBudget.OptionsColumn.AllowEdit = false;
            colOriginalBudget.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OriginalBudget", "الإجمالي: {0:N2}") });
            colOriginalBudget.Visible = true;
            colOriginalBudget.VisibleIndex = 1;
            colOriginalBudget.Width = 160;
            //
            // colApprovedBudget
            //
            colApprovedBudget.Caption = "الموازنة المعتمدة";
            colApprovedBudget.DisplayFormat.FormatString = "N2";
            colApprovedBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colApprovedBudget.FieldName = "ApprovedBudget";
            colApprovedBudget.Name = "colApprovedBudget";
            colApprovedBudget.OptionsColumn.AllowEdit = false;
            colApprovedBudget.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ApprovedBudget", "الإجمالي: {0:N2}") });
            colApprovedBudget.Visible = true;
            colApprovedBudget.VisibleIndex = 2;
            colApprovedBudget.Width = 160;
            //
            // colActualCost
            //
            colActualCost.Caption = "الفعلي";
            colActualCost.DisplayFormat.FormatString = "N2";
            colActualCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colActualCost.FieldName = "ActualCost";
            colActualCost.Name = "colActualCost";
            colActualCost.OptionsColumn.AllowEdit = false;
            colActualCost.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ActualCost", "الإجمالي: {0:N2}") });
            colActualCost.Visible = true;
            colActualCost.VisibleIndex = 3;
            colActualCost.Width = 160;
            //
            // colCommitment
            //
            colCommitment.Caption = "الالتزام";
            colCommitment.DisplayFormat.FormatString = "N2";
            colCommitment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCommitment.FieldName = "Commitment";
            colCommitment.Name = "colCommitment";
            colCommitment.OptionsColumn.AllowEdit = false;
            colCommitment.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Commitment", "الإجمالي: {0:N2}") });
            colCommitment.Visible = true;
            colCommitment.VisibleIndex = 4;
            colCommitment.Width = 160;
            //
            // colRemaining
            //
            colRemaining.Caption = "المتبقي";
            colRemaining.DisplayFormat.FormatString = "N2";
            colRemaining.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colRemaining.FieldName = "Remaining";
            colRemaining.Name = "colRemaining";
            colRemaining.OptionsColumn.AllowEdit = false;
            colRemaining.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Remaining", "الإجمالي: {0:N2}") });
            colRemaining.Visible = true;
            colRemaining.VisibleIndex = 5;
            colRemaining.Width = 160;
            //
            // pnlLoadingState
            //
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 610);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 186);
            pnlLoadingState.TabIndex = 3;
            pnlLoadingState.Visible = false;
            //
            // svgLoadingIcon
            //
            svgLoadingIcon.Location = new Point(651, 40);
            svgLoadingIcon.Name = "svgLoadingIcon";
            svgLoadingIcon.Size = new Size(64, 64);
            svgLoadingIcon.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            svgLoadingIcon.TabIndex = 0;
            //
            // lblLoadingText
            //
            lblLoadingText.Appearance.Font = new Font("Cairo", 10F);
            lblLoadingText.Appearance.Options.UseFont = true;
            lblLoadingText.Appearance.Options.UseTextOptions = true;
            lblLoadingText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblLoadingText.Location = new Point(583, 114);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(200, 20);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل بيانات الموازنة...";
            //
            // pnlEmptyState
            //
            pnlEmptyState.Controls.Add(lblEmptyText);
            pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Dock = DockStyle.Fill;
            pnlEmptyState.Location = new Point(0, 610);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 186);
            pnlEmptyState.TabIndex = 4;
            pnlEmptyState.Visible = false;
            //
            // svgEmptyIcon
            //
            svgEmptyIcon.Location = new Point(651, 40);
            svgEmptyIcon.Name = "svgEmptyIcon";
            svgEmptyIcon.Size = new Size(64, 64);
            svgEmptyIcon.SvgImage = Etmam.IconLoader.Get("empty.svg");
            svgEmptyIcon.TabIndex = 0;
            //
            // lblEmptyText
            //
            lblEmptyText.Appearance.Font = new Font("Cairo", 10F);
            lblEmptyText.Appearance.Options.UseFont = true;
            lblEmptyText.Appearance.Options.UseTextOptions = true;
            lblEmptyText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyText.Location = new Point(583, 114);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(200, 20);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا توجد بنود موازنة لعرضها";
            //
            // pnlErrorState
            //
            pnlErrorState.Controls.Add(btnRetry);
            pnlErrorState.Controls.Add(lblErrorText);
            pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Dock = DockStyle.Fill;
            pnlErrorState.Location = new Point(0, 610);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 186);
            pnlErrorState.TabIndex = 5;
            pnlErrorState.Visible = false;
            //
            // svgErrorIcon
            //
            svgErrorIcon.Location = new Point(651, 20);
            svgErrorIcon.Name = "svgErrorIcon";
            svgErrorIcon.Size = new Size(64, 64);
            svgErrorIcon.SvgImage = Etmam.IconLoader.Get("error.svg");
            svgErrorIcon.TabIndex = 0;
            //
            // lblErrorText
            //
            lblErrorText.Appearance.Font = new Font("Cairo", 10F);
            lblErrorText.Appearance.Options.UseFont = true;
            lblErrorText.Appearance.Options.UseTextOptions = true;
            lblErrorText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblErrorText.Location = new Point(583, 94);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(200, 20);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل بيانات الموازنة";
            //
            // btnRetry
            //
            btnRetry.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            btnRetry.Location = new Point(633, 124);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(100, 28);
            btnRetry.TabIndex = 2;
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;
            //
            // ucProjectBudgetSummary
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grdBudgetBreakdown);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlCharts);
            Controls.Add(pnlKpiCards);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucProjectBudgetSummary";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 820);
            ((System.ComponentModel.ISupportInitialize)barManagerBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit();
            pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiOriginalBudget).EndInit();
            pnlKpiOriginalBudget.ResumeLayout(false);
            pnlKpiOriginalBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiApprovedBudget).EndInit();
            pnlKpiApprovedBudget.ResumeLayout(false);
            pnlKpiApprovedBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActualCost).EndInit();
            pnlKpiActualCost.ResumeLayout(false);
            pnlKpiActualCost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCommitment).EndInit();
            pnlKpiCommitment.ResumeLayout(false);
            pnlKpiCommitment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).EndInit();
            pnlKpiForecast.ResumeLayout(false);
            pnlKpiForecast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiVariance).EndInit();
            pnlKpiVariance.ResumeLayout(false);
            pnlKpiVariance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)xyDiagramBudgetVsActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesBudget).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartBudgetVsActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramCashFlow).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesCashFlow).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCashFlow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).EndInit();
            pnlCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdBudgetBreakdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvBudgetBreakdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit();
            pnlLoadingState.ResumeLayout(false);
            pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit();
            pnlEmptyState.ResumeLayout(false);
            pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit();
            pnlErrorState.ResumeLayout(false);
            pnlErrorState.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerBudget;
        private DevExpress.XtraBars.Bar barBudget;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExportExcel;
        private DevExpress.XtraBars.BarButtonItem bbiExportPdf;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.PanelControl pnlKpiOriginalBudget;
        private DevExpress.XtraEditors.LabelControl lblKpiOriginalBudgetTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiOriginalBudgetValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiApprovedBudget;
        private DevExpress.XtraEditors.LabelControl lblKpiApprovedBudgetTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiApprovedBudgetValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiActualCost;
        private DevExpress.XtraEditors.LabelControl lblKpiActualCostTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiActualCostValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiCommitment;
        private DevExpress.XtraEditors.LabelControl lblKpiCommitmentTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiCommitmentValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiForecast;
        private DevExpress.XtraEditors.LabelControl lblKpiForecastTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiForecastValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiVariance;
        private DevExpress.XtraEditors.LabelControl lblKpiVarianceTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiVarianceValue;

        private DevExpress.XtraEditors.PanelControl pnlCharts;
        private DevExpress.XtraEditors.LabelControl lblBudgetVsActualCaption;
        private DevExpress.XtraCharts.ChartControl chartBudgetVsActual;
        private DevExpress.XtraCharts.Series seriesBudget;
        private DevExpress.XtraCharts.Series seriesActualCost;
        private DevExpress.XtraCharts.XYDiagram xyDiagramBudgetVsActual;
        private DevExpress.XtraEditors.LabelControl lblForecastChartCaption;
        private DevExpress.XtraCharts.ChartControl chartForecast;
        private DevExpress.XtraCharts.Series seriesForecast;
        private DevExpress.XtraCharts.XYDiagram xyDiagramForecast;
        private DevExpress.XtraEditors.LabelControl lblCashFlowChartCaption;
        private DevExpress.XtraCharts.ChartControl chartCashFlow;
        private DevExpress.XtraCharts.Series seriesCashFlow;
        private DevExpress.XtraCharts.XYDiagram xyDiagramCashFlow;

        private DevExpress.XtraGrid.GridControl grdBudgetBreakdown;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBudgetBreakdown;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetItem;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginalBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovedBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colActualCost;
        private DevExpress.XtraGrid.Columns.GridColumn colCommitment;
        private DevExpress.XtraGrid.Columns.GridColumn colRemaining;

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
