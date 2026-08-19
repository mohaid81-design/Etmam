namespace Etmam
{
    partial class ucProjectCostControl
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
            barManagerCostControl = new DevExpress.XtraBars.BarManager(components);
            barCostControl = new DevExpress.XtraBars.Bar();
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
            pnlKpiBudget = new DevExpress.XtraEditors.PanelControl();
            lblKpiBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiBudgetValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiActual = new DevExpress.XtraEditors.PanelControl();
            lblKpiActualTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiActualValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiCommitment = new DevExpress.XtraEditors.PanelControl();
            lblKpiCommitmentTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiCommitmentValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiForecast = new DevExpress.XtraEditors.PanelControl();
            lblKpiForecastTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiForecastValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiEac = new DevExpress.XtraEditors.PanelControl();
            lblKpiEacTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiEacValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiEtc = new DevExpress.XtraEditors.PanelControl();
            lblKpiEtcTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiEtcValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiCpi = new DevExpress.XtraEditors.PanelControl();
            lblKpiCpiTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiCpiValue = new DevExpress.XtraEditors.LabelControl();
            pnlKpiSpi = new DevExpress.XtraEditors.PanelControl();
            lblKpiSpiTitle = new DevExpress.XtraEditors.LabelControl();
            lblKpiSpiValue = new DevExpress.XtraEditors.LabelControl();

            pnlCharts = new DevExpress.XtraEditors.PanelControl();
            lblCostTrendCaption = new DevExpress.XtraEditors.LabelControl();
            chartCostTrend = new DevExpress.XtraCharts.ChartControl();
            seriesCostTrend = new DevExpress.XtraCharts.Series("اتجاه التكلفة", DevExpress.XtraCharts.ViewType.Spline);
            xyDiagramCostTrend = new DevExpress.XtraCharts.XYDiagram();
            lblEarnedValueCaption = new DevExpress.XtraEditors.LabelControl();
            chartEarnedValue = new DevExpress.XtraCharts.ChartControl();
            seriesPlannedValue = new DevExpress.XtraCharts.Series("القيمة المخططة (PV)", DevExpress.XtraCharts.ViewType.Spline);
            seriesEarnedValue = new DevExpress.XtraCharts.Series("القيمة المكتسبة (EV)", DevExpress.XtraCharts.ViewType.Spline);
            seriesActualCostEv = new DevExpress.XtraCharts.Series("التكلفة الفعلية (AC)", DevExpress.XtraCharts.ViewType.Spline);
            xyDiagramEarnedValue = new DevExpress.XtraCharts.XYDiagram();
            lblCostForecastCaption = new DevExpress.XtraEditors.LabelControl();
            chartCostForecast = new DevExpress.XtraCharts.ChartControl();
            seriesCostForecast = new DevExpress.XtraCharts.Series("التوقع عند الإنجاز (EAC)", DevExpress.XtraCharts.ViewType.Spline);
            xyDiagramCostForecast = new DevExpress.XtraCharts.XYDiagram();

            grdCostBreakdown = new DevExpress.XtraGrid.GridControl();
            gvCostBreakdown = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCostItem = new DevExpress.XtraGrid.Columns.GridColumn();
            colCostBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            colCostActual = new DevExpress.XtraGrid.Columns.GridColumn();
            colCostCommitment = new DevExpress.XtraGrid.Columns.GridColumn();
            colCostForecast = new DevExpress.XtraGrid.Columns.GridColumn();
            colCostVariance = new DevExpress.XtraGrid.Columns.GridColumn();

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

            ((System.ComponentModel.ISupportInitialize)barManagerCostControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).BeginInit();
            pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiBudget).BeginInit();
            pnlKpiBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActual).BeginInit();
            pnlKpiActual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCommitment).BeginInit();
            pnlKpiCommitment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).BeginInit();
            pnlKpiForecast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiEac).BeginInit();
            pnlKpiEac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiEtc).BeginInit();
            pnlKpiEtc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCpi).BeginInit();
            pnlKpiCpi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiSpi).BeginInit();
            pnlKpiSpi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).BeginInit();
            pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCostTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesCostTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramCostTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartEarnedValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesPlannedValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesEarnedValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualCostEv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramEarnedValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCostForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesCostForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramCostForecast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdCostBreakdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCostBreakdown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            SuspendLayout();
            //
            // barManagerCostControl
            //
            barManagerCostControl.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barCostControl, barStatus });
            barManagerCostControl.DockControls.Add(barDockControlTop);
            barManagerCostControl.DockControls.Add(barDockControlBottom);
            barManagerCostControl.DockControls.Add(barDockControlLeft);
            barManagerCostControl.DockControls.Add(barDockControlRight);
            barManagerCostControl.Form = this;
            barManagerCostControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiRefresh, bbiPrint, bbiExportExcel, bbiExportPdf, sbiRecordCount });
            barManagerCostControl.MainMenu = barCostControl;
            barManagerCostControl.MaxItemId = 5;
            barManagerCostControl.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerCostControl.StatusBar = barStatus;
            //
            // barCostControl
            //
            barCostControl.BarName = "شريط أدوات ضبط التكلفة";
            barCostControl.DockCol = 0;
            barCostControl.DockRow = 0;
            barCostControl.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barCostControl.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportPdf, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barCostControl.OptionsBar.AllowQuickCustomization = false;
            barCostControl.OptionsBar.DrawDragBorder = false;
            barCostControl.OptionsBar.MinHeight = 34;
            barCostControl.OptionsBar.UseWholeRow = true;
            barCostControl.Text = "شريط أدوات ضبط التكلفة";
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
            barDockControlTop.Manager = barManagerCostControl;
            barDockControlTop.Size = new Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 796);
            barDockControlBottom.Manager = barManagerCostControl;
            barDockControlBottom.Size = new Size(1366, 24);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerCostControl;
            barDockControlLeft.Size = new Size(0, 762);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerCostControl;
            barDockControlRight.Size = new Size(0, 762);
            //
            // pnlKpiCards
            //
            pnlKpiCards.Controls.Add(pnlKpiSpi);
            pnlKpiCards.Controls.Add(pnlKpiCpi);
            pnlKpiCards.Controls.Add(pnlKpiEtc);
            pnlKpiCards.Controls.Add(pnlKpiEac);
            pnlKpiCards.Controls.Add(pnlKpiForecast);
            pnlKpiCards.Controls.Add(pnlKpiCommitment);
            pnlKpiCards.Controls.Add(pnlKpiActual);
            pnlKpiCards.Controls.Add(pnlKpiBudget);
            pnlKpiCards.Dock = DockStyle.Top;
            pnlKpiCards.Location = new Point(0, 34);
            pnlKpiCards.Name = "pnlKpiCards";
            pnlKpiCards.Size = new Size(1366, 236);
            pnlKpiCards.TabIndex = 0;
            //
            // pnlKpiBudget
            //
            pnlKpiBudget.Appearance.BackColor = Color.FromArgb(238, 240, 252);
            pnlKpiBudget.Appearance.Options.UseBackColor = true;
            pnlKpiBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiBudget.Controls.Add(lblKpiBudgetValue);
            pnlKpiBudget.Controls.Add(lblKpiBudgetTitle);
            pnlKpiBudget.Location = new Point(20, 20);
            pnlKpiBudget.Name = "pnlKpiBudget";
            pnlKpiBudget.Size = new Size(300, 90);
            pnlKpiBudget.TabIndex = 0;
            //
            // lblKpiBudgetTitle
            //
            lblKpiBudgetTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiBudgetTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiBudgetTitle.Appearance.Options.UseFont = true;
            lblKpiBudgetTitle.Appearance.Options.UseForeColor = true;
            lblKpiBudgetTitle.Location = new Point(12, 12);
            lblKpiBudgetTitle.Name = "lblKpiBudgetTitle";
            lblKpiBudgetTitle.Size = new Size(47, 17);
            lblKpiBudgetTitle.TabIndex = 0;
            lblKpiBudgetTitle.Text = "الموازنة";
            //
            // lblKpiBudgetValue
            //
            lblKpiBudgetValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiBudgetValue.Appearance.ForeColor = Color.FromArgb(91, 79, 207);
            lblKpiBudgetValue.Appearance.Options.UseFont = true;
            lblKpiBudgetValue.Appearance.Options.UseForeColor = true;
            lblKpiBudgetValue.Location = new Point(12, 38);
            lblKpiBudgetValue.Name = "lblKpiBudgetValue";
            lblKpiBudgetValue.Size = new Size(20, 25);
            lblKpiBudgetValue.TabIndex = 1;
            lblKpiBudgetValue.Text = "—";
            //
            // pnlKpiActual
            //
            pnlKpiActual.Appearance.BackColor = Color.FromArgb(234, 243, 252);
            pnlKpiActual.Appearance.Options.UseBackColor = true;
            pnlKpiActual.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiActual.Controls.Add(lblKpiActualValue);
            pnlKpiActual.Controls.Add(lblKpiActualTitle);
            pnlKpiActual.Location = new Point(340, 20);
            pnlKpiActual.Name = "pnlKpiActual";
            pnlKpiActual.Size = new Size(300, 90);
            pnlKpiActual.TabIndex = 1;
            //
            // lblKpiActualTitle
            //
            lblKpiActualTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiActualTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiActualTitle.Appearance.Options.UseFont = true;
            lblKpiActualTitle.Appearance.Options.UseForeColor = true;
            lblKpiActualTitle.Location = new Point(12, 12);
            lblKpiActualTitle.Name = "lblKpiActualTitle";
            lblKpiActualTitle.Size = new Size(46, 17);
            lblKpiActualTitle.TabIndex = 0;
            lblKpiActualTitle.Text = "الفعلي";
            //
            // lblKpiActualValue
            //
            lblKpiActualValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiActualValue.Appearance.ForeColor = Color.FromArgb(46, 117, 182);
            lblKpiActualValue.Appearance.Options.UseFont = true;
            lblKpiActualValue.Appearance.Options.UseForeColor = true;
            lblKpiActualValue.Location = new Point(12, 38);
            lblKpiActualValue.Name = "lblKpiActualValue";
            lblKpiActualValue.Size = new Size(20, 25);
            lblKpiActualValue.TabIndex = 1;
            lblKpiActualValue.Text = "—";
            //
            // pnlKpiCommitment
            //
            pnlKpiCommitment.Appearance.BackColor = Color.FromArgb(255, 246, 229);
            pnlKpiCommitment.Appearance.Options.UseBackColor = true;
            pnlKpiCommitment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCommitment.Controls.Add(lblKpiCommitmentValue);
            pnlKpiCommitment.Controls.Add(lblKpiCommitmentTitle);
            pnlKpiCommitment.Location = new Point(660, 20);
            pnlKpiCommitment.Name = "pnlKpiCommitment";
            pnlKpiCommitment.Size = new Size(300, 90);
            pnlKpiCommitment.TabIndex = 2;
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
            pnlKpiForecast.Location = new Point(980, 20);
            pnlKpiForecast.Name = "pnlKpiForecast";
            pnlKpiForecast.Size = new Size(300, 90);
            pnlKpiForecast.TabIndex = 3;
            //
            // lblKpiForecastTitle
            //
            lblKpiForecastTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiForecastTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiForecastTitle.Appearance.Options.UseFont = true;
            lblKpiForecastTitle.Appearance.Options.UseForeColor = true;
            lblKpiForecastTitle.Location = new Point(12, 12);
            lblKpiForecastTitle.Name = "lblKpiForecastTitle";
            lblKpiForecastTitle.Size = new Size(52, 17);
            lblKpiForecastTitle.TabIndex = 0;
            lblKpiForecastTitle.Text = "المتوقع";
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
            // pnlKpiEac
            //
            pnlKpiEac.Appearance.BackColor = Color.FromArgb(232, 246, 246);
            pnlKpiEac.Appearance.Options.UseBackColor = true;
            pnlKpiEac.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiEac.Controls.Add(lblKpiEacValue);
            pnlKpiEac.Controls.Add(lblKpiEacTitle);
            pnlKpiEac.Location = new Point(20, 126);
            pnlKpiEac.Name = "pnlKpiEac";
            pnlKpiEac.Size = new Size(300, 90);
            pnlKpiEac.TabIndex = 4;
            //
            // lblKpiEacTitle
            //
            lblKpiEacTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiEacTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiEacTitle.Appearance.Options.UseFont = true;
            lblKpiEacTitle.Appearance.Options.UseForeColor = true;
            lblKpiEacTitle.Location = new Point(12, 12);
            lblKpiEacTitle.Name = "lblKpiEacTitle";
            lblKpiEacTitle.Size = new Size(112, 17);
            lblKpiEacTitle.TabIndex = 0;
            lblKpiEacTitle.Text = "التكلفة المتوقعة عند الإنجاز (EAC)";
            //
            // lblKpiEacValue
            //
            lblKpiEacValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiEacValue.Appearance.ForeColor = Color.FromArgb(28, 140, 140);
            lblKpiEacValue.Appearance.Options.UseFont = true;
            lblKpiEacValue.Appearance.Options.UseForeColor = true;
            lblKpiEacValue.Location = new Point(12, 38);
            lblKpiEacValue.Name = "lblKpiEacValue";
            lblKpiEacValue.Size = new Size(20, 25);
            lblKpiEacValue.TabIndex = 1;
            lblKpiEacValue.Text = "—";
            //
            // pnlKpiEtc
            //
            pnlKpiEtc.Appearance.BackColor = Color.FromArgb(238, 241, 243);
            pnlKpiEtc.Appearance.Options.UseBackColor = true;
            pnlKpiEtc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiEtc.Controls.Add(lblKpiEtcValue);
            pnlKpiEtc.Controls.Add(lblKpiEtcTitle);
            pnlKpiEtc.Location = new Point(340, 126);
            pnlKpiEtc.Name = "pnlKpiEtc";
            pnlKpiEtc.Size = new Size(300, 90);
            pnlKpiEtc.TabIndex = 5;
            //
            // lblKpiEtcTitle
            //
            lblKpiEtcTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiEtcTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiEtcTitle.Appearance.Options.UseFont = true;
            lblKpiEtcTitle.Appearance.Options.UseForeColor = true;
            lblKpiEtcTitle.Location = new Point(12, 12);
            lblKpiEtcTitle.Name = "lblKpiEtcTitle";
            lblKpiEtcTitle.Size = new Size(112, 17);
            lblKpiEtcTitle.TabIndex = 0;
            lblKpiEtcTitle.Text = "التكلفة المتبقية للإنجاز (ETC)";
            //
            // lblKpiEtcValue
            //
            lblKpiEtcValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiEtcValue.Appearance.ForeColor = Color.FromArgb(69, 80, 92);
            lblKpiEtcValue.Appearance.Options.UseFont = true;
            lblKpiEtcValue.Appearance.Options.UseForeColor = true;
            lblKpiEtcValue.Location = new Point(12, 38);
            lblKpiEtcValue.Name = "lblKpiEtcValue";
            lblKpiEtcValue.Size = new Size(20, 25);
            lblKpiEtcValue.TabIndex = 1;
            lblKpiEtcValue.Text = "—";
            //
            // pnlKpiCpi
            //
            pnlKpiCpi.Appearance.BackColor = Color.FromArgb(234, 247, 239);
            pnlKpiCpi.Appearance.Options.UseBackColor = true;
            pnlKpiCpi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiCpi.Controls.Add(lblKpiCpiValue);
            pnlKpiCpi.Controls.Add(lblKpiCpiTitle);
            pnlKpiCpi.Location = new Point(660, 126);
            pnlKpiCpi.Name = "pnlKpiCpi";
            pnlKpiCpi.Size = new Size(300, 90);
            pnlKpiCpi.TabIndex = 6;
            //
            // lblKpiCpiTitle
            //
            lblKpiCpiTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiCpiTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiCpiTitle.Appearance.Options.UseFont = true;
            lblKpiCpiTitle.Appearance.Options.UseForeColor = true;
            lblKpiCpiTitle.Location = new Point(12, 12);
            lblKpiCpiTitle.Name = "lblKpiCpiTitle";
            lblKpiCpiTitle.Size = new Size(93, 17);
            lblKpiCpiTitle.TabIndex = 0;
            lblKpiCpiTitle.Text = "مؤشر أداء التكلفة (CPI)";
            //
            // lblKpiCpiValue
            //
            lblKpiCpiValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiCpiValue.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            lblKpiCpiValue.Appearance.Options.UseFont = true;
            lblKpiCpiValue.Appearance.Options.UseForeColor = true;
            lblKpiCpiValue.Location = new Point(12, 38);
            lblKpiCpiValue.Name = "lblKpiCpiValue";
            lblKpiCpiValue.Size = new Size(20, 25);
            lblKpiCpiValue.TabIndex = 1;
            lblKpiCpiValue.Text = "—";
            //
            // pnlKpiSpi
            //
            pnlKpiSpi.Appearance.BackColor = Color.FromArgb(253, 237, 236);
            pnlKpiSpi.Appearance.Options.UseBackColor = true;
            pnlKpiSpi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKpiSpi.Controls.Add(lblKpiSpiValue);
            pnlKpiSpi.Controls.Add(lblKpiSpiTitle);
            pnlKpiSpi.Location = new Point(980, 126);
            pnlKpiSpi.Name = "pnlKpiSpi";
            pnlKpiSpi.Size = new Size(300, 90);
            pnlKpiSpi.TabIndex = 7;
            //
            // lblKpiSpiTitle
            //
            lblKpiSpiTitle.Appearance.Font = new Font("Cairo", 8F);
            lblKpiSpiTitle.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblKpiSpiTitle.Appearance.Options.UseFont = true;
            lblKpiSpiTitle.Appearance.Options.UseForeColor = true;
            lblKpiSpiTitle.Location = new Point(12, 12);
            lblKpiSpiTitle.Name = "lblKpiSpiTitle";
            lblKpiSpiTitle.Size = new Size(94, 17);
            lblKpiSpiTitle.TabIndex = 0;
            lblKpiSpiTitle.Text = "مؤشر أداء الجدول (SPI)";
            //
            // lblKpiSpiValue
            //
            lblKpiSpiValue.Appearance.Font = new Font("Cairo", 15F, FontStyle.Bold);
            lblKpiSpiValue.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            lblKpiSpiValue.Appearance.Options.UseFont = true;
            lblKpiSpiValue.Appearance.Options.UseForeColor = true;
            lblKpiSpiValue.Location = new Point(12, 38);
            lblKpiSpiValue.Name = "lblKpiSpiValue";
            lblKpiSpiValue.Size = new Size(20, 25);
            lblKpiSpiValue.TabIndex = 1;
            lblKpiSpiValue.Text = "—";
            //
            // pnlCharts
            //
            pnlCharts.Controls.Add(chartCostForecast);
            pnlCharts.Controls.Add(lblCostForecastCaption);
            pnlCharts.Controls.Add(chartEarnedValue);
            pnlCharts.Controls.Add(lblEarnedValueCaption);
            pnlCharts.Controls.Add(chartCostTrend);
            pnlCharts.Controls.Add(lblCostTrendCaption);
            pnlCharts.Dock = DockStyle.Top;
            pnlCharts.Location = new Point(0, 270);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Size = new Size(1366, 340);
            pnlCharts.TabIndex = 1;
            //
            // lblCostTrendCaption
            //
            lblCostTrendCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblCostTrendCaption.Appearance.Options.UseFont = true;
            lblCostTrendCaption.Location = new Point(12, 12);
            lblCostTrendCaption.Name = "lblCostTrendCaption";
            lblCostTrendCaption.Size = new Size(75, 20);
            lblCostTrendCaption.TabIndex = 0;
            lblCostTrendCaption.Text = "اتجاه التكلفة";
            //
            // chartCostTrend
            //
            chartCostTrend.Diagram = xyDiagramCostTrend;
            chartCostTrend.Location = new Point(12, 36);
            chartCostTrend.Name = "chartCostTrend";
            chartCostTrend.SeriesTemplate.View = new DevExpress.XtraCharts.SplineSeriesView();
            chartCostTrend.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesCostTrend });
            chartCostTrend.Size = new Size(436, 296);
            chartCostTrend.TabIndex = 1;
            //
            // seriesCostTrend
            //
            seriesCostTrend.Name = "اتجاه التكلفة";
            seriesCostTrend.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // xyDiagramCostTrend
            //
            //
            // lblEarnedValueCaption
            //
            lblEarnedValueCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblEarnedValueCaption.Appearance.Options.UseFont = true;
            lblEarnedValueCaption.Location = new Point(460, 12);
            lblEarnedValueCaption.Name = "lblEarnedValueCaption";
            lblEarnedValueCaption.Size = new Size(90, 20);
            lblEarnedValueCaption.TabIndex = 2;
            lblEarnedValueCaption.Text = "القيمة المكتسبة (EVM)";
            //
            // chartEarnedValue
            //
            chartEarnedValue.Diagram = xyDiagramEarnedValue;
            chartEarnedValue.Location = new Point(460, 36);
            chartEarnedValue.Name = "chartEarnedValue";
            chartEarnedValue.SeriesTemplate.View = new DevExpress.XtraCharts.SplineSeriesView();
            chartEarnedValue.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesPlannedValue, seriesEarnedValue, seriesActualCostEv });
            chartEarnedValue.Size = new Size(436, 296);
            chartEarnedValue.TabIndex = 3;
            //
            // seriesPlannedValue
            //
            seriesPlannedValue.Name = "القيمة المخططة (PV)";
            seriesPlannedValue.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // seriesEarnedValue
            //
            seriesEarnedValue.Name = "القيمة المكتسبة (EV)";
            seriesEarnedValue.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // seriesActualCostEv
            //
            seriesActualCostEv.Name = "التكلفة الفعلية (AC)";
            seriesActualCostEv.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // xyDiagramEarnedValue
            //
            //
            // lblCostForecastCaption
            //
            lblCostForecastCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblCostForecastCaption.Appearance.Options.UseFont = true;
            lblCostForecastCaption.Location = new Point(908, 12);
            lblCostForecastCaption.Name = "lblCostForecastCaption";
            lblCostForecastCaption.Size = new Size(70, 20);
            lblCostForecastCaption.TabIndex = 4;
            lblCostForecastCaption.Text = "التوقع (Forecast)";
            //
            // chartCostForecast
            //
            chartCostForecast.Diagram = xyDiagramCostForecast;
            chartCostForecast.Location = new Point(908, 36);
            chartCostForecast.Name = "chartCostForecast";
            chartCostForecast.SeriesTemplate.View = new DevExpress.XtraCharts.SplineSeriesView();
            chartCostForecast.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesCostForecast });
            chartCostForecast.Size = new Size(436, 296);
            chartCostForecast.TabIndex = 5;
            //
            // seriesCostForecast
            //
            seriesCostForecast.Name = "التوقع عند الإنجاز (EAC)";
            seriesCostForecast.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // xyDiagramCostForecast
            //
            //
            // grdCostBreakdown
            //
            grdCostBreakdown.Dock = DockStyle.Fill;
            grdCostBreakdown.Location = new Point(0, 610);
            grdCostBreakdown.MainView = gvCostBreakdown;
            grdCostBreakdown.MenuManager = barManagerCostControl;
            grdCostBreakdown.Name = "grdCostBreakdown";
            grdCostBreakdown.Size = new Size(1366, 186);
            grdCostBreakdown.TabIndex = 2;
            grdCostBreakdown.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCostBreakdown });
            //
            // gvCostBreakdown
            //
            gvCostBreakdown.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvCostBreakdown.Appearance.HeaderPanel.Options.UseFont = true;
            gvCostBreakdown.Appearance.Row.Font = new Font("Cairo", 8F);
            gvCostBreakdown.Appearance.Row.Options.UseFont = true;
            gvCostBreakdown.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCostItem, colCostBudget, colCostActual, colCostCommitment, colCostForecast, colCostVariance });
            gvCostBreakdown.GridControl = grdCostBreakdown;
            gvCostBreakdown.Name = "gvCostBreakdown";
            gvCostBreakdown.OptionsView.ColumnAutoWidth = false;
            gvCostBreakdown.OptionsView.ShowAutoFilterRow = true;
            gvCostBreakdown.OptionsView.ShowFooter = true;
            //
            // colCostItem
            //
            colCostItem.Caption = "بند التكلفة";
            colCostItem.FieldName = "CostItem";
            colCostItem.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colCostItem.Name = "colCostItem";
            colCostItem.OptionsColumn.AllowEdit = false;
            colCostItem.Visible = true;
            colCostItem.VisibleIndex = 0;
            colCostItem.Width = 260;
            //
            // colCostBudget
            //
            colCostBudget.Caption = "الموازنة";
            colCostBudget.DisplayFormat.FormatString = "N2";
            colCostBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCostBudget.FieldName = "Budget";
            colCostBudget.Name = "colCostBudget";
            colCostBudget.OptionsColumn.AllowEdit = false;
            colCostBudget.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Budget", "الإجمالي: {0:N2}") });
            colCostBudget.Visible = true;
            colCostBudget.VisibleIndex = 1;
            colCostBudget.Width = 170;
            //
            // colCostActual
            //
            colCostActual.Caption = "الفعلي";
            colCostActual.DisplayFormat.FormatString = "N2";
            colCostActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCostActual.FieldName = "Actual";
            colCostActual.Name = "colCostActual";
            colCostActual.OptionsColumn.AllowEdit = false;
            colCostActual.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Actual", "الإجمالي: {0:N2}") });
            colCostActual.Visible = true;
            colCostActual.VisibleIndex = 2;
            colCostActual.Width = 170;
            //
            // colCostCommitment
            //
            colCostCommitment.Caption = "الالتزام";
            colCostCommitment.DisplayFormat.FormatString = "N2";
            colCostCommitment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCostCommitment.FieldName = "Commitment";
            colCostCommitment.Name = "colCostCommitment";
            colCostCommitment.OptionsColumn.AllowEdit = false;
            colCostCommitment.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Commitment", "الإجمالي: {0:N2}") });
            colCostCommitment.Visible = true;
            colCostCommitment.VisibleIndex = 3;
            colCostCommitment.Width = 170;
            //
            // colCostForecast
            //
            colCostForecast.Caption = "المتوقع";
            colCostForecast.DisplayFormat.FormatString = "N2";
            colCostForecast.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCostForecast.FieldName = "Forecast";
            colCostForecast.Name = "colCostForecast";
            colCostForecast.OptionsColumn.AllowEdit = false;
            colCostForecast.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Forecast", "الإجمالي: {0:N2}") });
            colCostForecast.Visible = true;
            colCostForecast.VisibleIndex = 4;
            colCostForecast.Width = 170;
            //
            // colCostVariance
            //
            colCostVariance.Caption = "الانحراف";
            colCostVariance.DisplayFormat.FormatString = "N2";
            colCostVariance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCostVariance.FieldName = "Variance";
            colCostVariance.Name = "colCostVariance";
            colCostVariance.OptionsColumn.AllowEdit = false;
            colCostVariance.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Variance", "الإجمالي: {0:N2}") });
            colCostVariance.Visible = true;
            colCostVariance.VisibleIndex = 5;
            colCostVariance.Width = 170;
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
            lblLoadingText.Text = "جاري تحميل بيانات التكلفة...";
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
            lblEmptyText.Text = "لا توجد بيانات تكلفة لعرضها";
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
            lblErrorText.Text = "حدث خطأ أثناء تحميل بيانات التكلفة";
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
            // ucProjectCostControl
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grdCostBreakdown);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlCharts);
            Controls.Add(pnlKpiCards);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucProjectCostControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 820);
            ((System.ComponentModel.ISupportInitialize)barManagerCostControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCards).EndInit();
            pnlKpiCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKpiBudget).EndInit();
            pnlKpiBudget.ResumeLayout(false);
            pnlKpiBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiActual).EndInit();
            pnlKpiActual.ResumeLayout(false);
            pnlKpiActual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCommitment).EndInit();
            pnlKpiCommitment.ResumeLayout(false);
            pnlKpiCommitment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiForecast).EndInit();
            pnlKpiForecast.ResumeLayout(false);
            pnlKpiForecast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiEac).EndInit();
            pnlKpiEac.ResumeLayout(false);
            pnlKpiEac.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiEtc).EndInit();
            pnlKpiEtc.ResumeLayout(false);
            pnlKpiEtc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiCpi).EndInit();
            pnlKpiCpi.ResumeLayout(false);
            pnlKpiCpi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKpiSpi).EndInit();
            pnlKpiSpi.ResumeLayout(false);
            pnlKpiSpi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)xyDiagramCostTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesCostTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCostTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramEarnedValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesPlannedValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesEarnedValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesActualCostEv).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartEarnedValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramCostForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesCostForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCostForecast).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).EndInit();
            pnlCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdCostBreakdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCostBreakdown).EndInit();
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

        private DevExpress.XtraBars.BarManager barManagerCostControl;
        private DevExpress.XtraBars.Bar barCostControl;
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
        private DevExpress.XtraEditors.PanelControl pnlKpiBudget;
        private DevExpress.XtraEditors.LabelControl lblKpiBudgetTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiBudgetValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiActual;
        private DevExpress.XtraEditors.LabelControl lblKpiActualTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiActualValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiCommitment;
        private DevExpress.XtraEditors.LabelControl lblKpiCommitmentTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiCommitmentValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiForecast;
        private DevExpress.XtraEditors.LabelControl lblKpiForecastTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiForecastValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiEac;
        private DevExpress.XtraEditors.LabelControl lblKpiEacTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiEacValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiEtc;
        private DevExpress.XtraEditors.LabelControl lblKpiEtcTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiEtcValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiCpi;
        private DevExpress.XtraEditors.LabelControl lblKpiCpiTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiCpiValue;
        private DevExpress.XtraEditors.PanelControl pnlKpiSpi;
        private DevExpress.XtraEditors.LabelControl lblKpiSpiTitle;
        private DevExpress.XtraEditors.LabelControl lblKpiSpiValue;

        private DevExpress.XtraEditors.PanelControl pnlCharts;
        private DevExpress.XtraEditors.LabelControl lblCostTrendCaption;
        private DevExpress.XtraCharts.ChartControl chartCostTrend;
        private DevExpress.XtraCharts.Series seriesCostTrend;
        private DevExpress.XtraCharts.XYDiagram xyDiagramCostTrend;
        private DevExpress.XtraEditors.LabelControl lblEarnedValueCaption;
        private DevExpress.XtraCharts.ChartControl chartEarnedValue;
        private DevExpress.XtraCharts.Series seriesPlannedValue;
        private DevExpress.XtraCharts.Series seriesEarnedValue;
        private DevExpress.XtraCharts.Series seriesActualCostEv;
        private DevExpress.XtraCharts.XYDiagram xyDiagramEarnedValue;
        private DevExpress.XtraEditors.LabelControl lblCostForecastCaption;
        private DevExpress.XtraCharts.ChartControl chartCostForecast;
        private DevExpress.XtraCharts.Series seriesCostForecast;
        private DevExpress.XtraCharts.XYDiagram xyDiagramCostForecast;

        private DevExpress.XtraGrid.GridControl grdCostBreakdown;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCostBreakdown;
        private DevExpress.XtraGrid.Columns.GridColumn colCostItem;
        private DevExpress.XtraGrid.Columns.GridColumn colCostBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colCostActual;
        private DevExpress.XtraGrid.Columns.GridColumn colCostCommitment;
        private DevExpress.XtraGrid.Columns.GridColumn colCostForecast;
        private DevExpress.XtraGrid.Columns.GridColumn colCostVariance;

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
