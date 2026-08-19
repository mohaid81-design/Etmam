namespace Etmam
{
    partial class ucProjectSchedule
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
            barManagerSchedule = new DevExpress.XtraBars.BarManager(components);
            barSchedule = new DevExpress.XtraBars.Bar();
            bbiImportPrimavera = new DevExpress.XtraBars.BarButtonItem();
            bbiImportMSP = new DevExpress.XtraBars.BarButtonItem();
            bbiBaseline = new DevExpress.XtraBars.BarButtonItem();
            bbiCompare = new DevExpress.XtraBars.BarButtonItem();
            bbiProgressUpdate = new DevExpress.XtraBars.BarButtonItem();
            bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiRecordCount = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();

            pnlCharts = new DevExpress.XtraEditors.PanelControl();
            lblGanttCaption = new DevExpress.XtraEditors.LabelControl();
            pnlGanttPlaceholder = new DevExpress.XtraEditors.PanelControl();
            lblGanttPlaceholderText = new DevExpress.XtraEditors.LabelControl();
            lblMilestoneChartCaption = new DevExpress.XtraEditors.LabelControl();
            chartMilestoneTimeline = new DevExpress.XtraCharts.ChartControl();
            seriesMilestones = new DevExpress.XtraCharts.Series("المعالم", DevExpress.XtraCharts.ViewType.Point);
            xyDiagramMilestones = new DevExpress.XtraCharts.XYDiagram();
            lblProgressCurveCaption = new DevExpress.XtraEditors.LabelControl();
            chartProgressCurve = new DevExpress.XtraCharts.ChartControl();
            seriesPlanned = new DevExpress.XtraCharts.Series("المخطط", DevExpress.XtraCharts.ViewType.Spline);
            seriesActual = new DevExpress.XtraCharts.Series("الفعلي", DevExpress.XtraCharts.ViewType.Spline);
            xyDiagramProgress = new DevExpress.XtraCharts.XYDiagram();

            grdActivities = new DevExpress.XtraGrid.GridControl();
            gvActivities = new DevExpress.XtraGrid.Views.Grid.GridView();
            colActivityName = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityFloat = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityCritical = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityProgress = new DevExpress.XtraGrid.Columns.GridColumn();

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

            ((System.ComponentModel.ISupportInitialize)barManagerSchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).BeginInit();
            pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlGanttPlaceholder).BeginInit();
            pnlGanttPlaceholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartMilestoneTimeline).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesMilestones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramMilestones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartProgressCurve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesPlanned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seriesActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdActivities).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvActivities).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            SuspendLayout();
            //
            // barManagerSchedule
            //
            barManagerSchedule.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barSchedule, barStatus });
            barManagerSchedule.DockControls.Add(barDockControlTop);
            barManagerSchedule.DockControls.Add(barDockControlBottom);
            barManagerSchedule.DockControls.Add(barDockControlLeft);
            barManagerSchedule.DockControls.Add(barDockControlRight);
            barManagerSchedule.Form = this;
            barManagerSchedule.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiImportPrimavera, bbiImportMSP, bbiBaseline, bbiCompare, bbiProgressUpdate, bbiExportPdf, sbiRecordCount });
            barManagerSchedule.MainMenu = barSchedule;
            barManagerSchedule.MaxItemId = 7;
            barManagerSchedule.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerSchedule.StatusBar = barStatus;
            //
            // barSchedule
            //
            barSchedule.BarName = "شريط أدوات الجدول الزمني";
            barSchedule.DockCol = 0;
            barSchedule.DockRow = 0;
            barSchedule.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barSchedule.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiImportPrimavera, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiImportMSP, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiBaseline, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCompare, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiProgressUpdate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportPdf, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barSchedule.OptionsBar.AllowQuickCustomization = false;
            barSchedule.OptionsBar.DrawDragBorder = false;
            barSchedule.OptionsBar.MinHeight = 34;
            barSchedule.OptionsBar.UseWholeRow = true;
            barSchedule.Text = "شريط أدوات الجدول الزمني";
            //
            // bbiImportPrimavera
            //
            bbiImportPrimavera.Caption = "استيراد من Primavera";
            bbiImportPrimavera.Id = 0;
            bbiImportPrimavera.ImageOptions.SvgImage = Etmam.IconLoader.Get("import.svg");
            bbiImportPrimavera.Name = "bbiImportPrimavera";
            bbiImportPrimavera.ItemClick += bbiImportPrimavera_ItemClick;
            //
            // bbiImportMSP
            //
            bbiImportMSP.Caption = "استيراد من MSP";
            bbiImportMSP.Id = 1;
            bbiImportMSP.ImageOptions.SvgImage = Etmam.IconLoader.Get("import.svg");
            bbiImportMSP.Name = "bbiImportMSP";
            bbiImportMSP.ItemClick += bbiImportMSP_ItemClick;
            //
            // bbiBaseline
            //
            bbiBaseline.Caption = "خط الأساس";
            bbiBaseline.Id = 2;
            bbiBaseline.ImageOptions.SvgImage = Etmam.IconLoader.Get("baseline.svg");
            bbiBaseline.Name = "bbiBaseline";
            bbiBaseline.ItemClick += bbiBaseline_ItemClick;
            //
            // bbiCompare
            //
            bbiCompare.Caption = "مقارنة";
            bbiCompare.Id = 3;
            bbiCompare.ImageOptions.SvgImage = Etmam.IconLoader.Get("compare.svg");
            bbiCompare.Name = "bbiCompare";
            bbiCompare.ItemClick += bbiCompare_ItemClick;
            //
            // bbiProgressUpdate
            //
            bbiProgressUpdate.Caption = "تحديث نسبة الإنجاز";
            bbiProgressUpdate.Id = 4;
            bbiProgressUpdate.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            bbiProgressUpdate.Name = "bbiProgressUpdate";
            bbiProgressUpdate.ItemClick += bbiProgressUpdate_ItemClick;
            //
            // bbiExportPdf
            //
            bbiExportPdf.Caption = "تصدير PDF";
            bbiExportPdf.Id = 5;
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
            sbiRecordCount.Caption = "عدد الأنشطة: 0";
            sbiRecordCount.Id = 6;
            sbiRecordCount.Name = "sbiRecordCount";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerSchedule;
            barDockControlTop.Size = new Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 796);
            barDockControlBottom.Manager = barManagerSchedule;
            barDockControlBottom.Size = new Size(1366, 24);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerSchedule;
            barDockControlLeft.Size = new Size(0, 762);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerSchedule;
            barDockControlRight.Size = new Size(0, 762);
            //
            // pnlCharts
            //
            pnlCharts.Controls.Add(chartProgressCurve);
            pnlCharts.Controls.Add(lblProgressCurveCaption);
            pnlCharts.Controls.Add(chartMilestoneTimeline);
            pnlCharts.Controls.Add(lblMilestoneChartCaption);
            pnlCharts.Controls.Add(pnlGanttPlaceholder);
            pnlCharts.Controls.Add(lblGanttCaption);
            pnlCharts.Dock = DockStyle.Top;
            pnlCharts.Location = new Point(0, 34);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Size = new Size(1366, 340);
            pnlCharts.TabIndex = 0;
            //
            // lblGanttCaption
            //
            lblGanttCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblGanttCaption.Appearance.Options.UseFont = true;
            lblGanttCaption.Location = new Point(12, 12);
            lblGanttCaption.Name = "lblGanttCaption";
            lblGanttCaption.Size = new Size(85, 20);
            lblGanttCaption.TabIndex = 0;
            lblGanttCaption.Text = "لوحة جانت (Gantt)";
            //
            // pnlGanttPlaceholder
            //
            pnlGanttPlaceholder.Appearance.BackColor = Color.FromArgb(238, 241, 243);
            pnlGanttPlaceholder.Appearance.Options.UseBackColor = true;
            pnlGanttPlaceholder.Controls.Add(lblGanttPlaceholderText);
            pnlGanttPlaceholder.Location = new Point(12, 36);
            pnlGanttPlaceholder.Name = "pnlGanttPlaceholder";
            pnlGanttPlaceholder.Size = new Size(436, 296);
            pnlGanttPlaceholder.TabIndex = 1;
            //
            // lblGanttPlaceholderText
            //
            lblGanttPlaceholderText.Anchor = AnchorStyles.None;
            lblGanttPlaceholderText.Appearance.Font = new Font("Cairo", 9F);
            lblGanttPlaceholderText.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblGanttPlaceholderText.Appearance.Options.UseFont = true;
            lblGanttPlaceholderText.Appearance.Options.UseForeColor = true;
            lblGanttPlaceholderText.Location = new Point(168, 138);
            lblGanttPlaceholderText.Name = "lblGanttPlaceholderText";
            lblGanttPlaceholderText.Size = new Size(100, 20);
            lblGanttPlaceholderText.TabIndex = 0;
            lblGanttPlaceholderText.Text = "مخطط جانت (Placeholder)";
            //
            // lblMilestoneChartCaption
            //
            lblMilestoneChartCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblMilestoneChartCaption.Appearance.Options.UseFont = true;
            lblMilestoneChartCaption.Location = new Point(460, 12);
            lblMilestoneChartCaption.Name = "lblMilestoneChartCaption";
            lblMilestoneChartCaption.Size = new Size(120, 20);
            lblMilestoneChartCaption.TabIndex = 2;
            lblMilestoneChartCaption.Text = "الجدول الزمني للمعالم";
            //
            // chartMilestoneTimeline
            //
            chartMilestoneTimeline.Diagram = xyDiagramMilestones;
            chartMilestoneTimeline.Location = new Point(460, 36);
            chartMilestoneTimeline.Name = "chartMilestoneTimeline";
            chartMilestoneTimeline.SeriesTemplate.View = new DevExpress.XtraCharts.PointSeriesView();
            chartMilestoneTimeline.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesMilestones });
            chartMilestoneTimeline.Size = new Size(436, 296);
            chartMilestoneTimeline.TabIndex = 3;
            //
            // seriesMilestones
            //
            seriesMilestones.Name = "المعالم";
            seriesMilestones.View = new DevExpress.XtraCharts.PointSeriesView();
            //
            // xyDiagramMilestones
            //
            //
            // lblProgressCurveCaption
            //
            lblProgressCurveCaption.Appearance.Font = new Font("Cairo", 9F, FontStyle.Bold);
            lblProgressCurveCaption.Appearance.Options.UseFont = true;
            lblProgressCurveCaption.Location = new Point(908, 12);
            lblProgressCurveCaption.Name = "lblProgressCurveCaption";
            lblProgressCurveCaption.Size = new Size(140, 20);
            lblProgressCurveCaption.TabIndex = 4;
            lblProgressCurveCaption.Text = "منحنى الإنجاز (S-Curve)";
            //
            // chartProgressCurve
            //
            chartProgressCurve.Diagram = xyDiagramProgress;
            chartProgressCurve.Location = new Point(908, 36);
            chartProgressCurve.Name = "chartProgressCurve";
            chartProgressCurve.SeriesTemplate.View = new DevExpress.XtraCharts.SplineSeriesView();
            chartProgressCurve.Series.AddRange(new DevExpress.XtraCharts.Series[] { seriesPlanned, seriesActual });
            chartProgressCurve.Size = new Size(436, 296);
            chartProgressCurve.TabIndex = 5;
            //
            // seriesPlanned
            //
            seriesPlanned.Name = "المخطط";
            seriesPlanned.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // seriesActual
            //
            seriesActual.Name = "الفعلي";
            seriesActual.View = new DevExpress.XtraCharts.SplineSeriesView();
            //
            // xyDiagramProgress
            //
            //
            // grdActivities
            //
            grdActivities.Dock = DockStyle.Fill;
            grdActivities.Location = new Point(0, 374);
            grdActivities.MainView = gvActivities;
            grdActivities.MenuManager = barManagerSchedule;
            grdActivities.Name = "grdActivities";
            grdActivities.Size = new Size(1366, 422);
            grdActivities.TabIndex = 1;
            grdActivities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvActivities });
            //
            // gvActivities
            //
            gvActivities.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvActivities.Appearance.HeaderPanel.Options.UseFont = true;
            gvActivities.Appearance.Row.Font = new Font("Cairo", 8F);
            gvActivities.Appearance.Row.Options.UseFont = true;
            gvActivities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colActivityName, colActivityStart, colActivityFinish, colActivityFloat, colActivityCritical, colActivityProgress });
            gvActivities.GridControl = grdActivities;
            gvActivities.Name = "gvActivities";
            gvActivities.OptionsView.ColumnAutoWidth = false;
            gvActivities.OptionsView.ShowAutoFilterRow = true;
            gvActivities.OptionsView.ShowFooter = true;
            //
            // colActivityName
            //
            colActivityName.Caption = "النشاط";
            colActivityName.FieldName = "ActivityName";
            colActivityName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colActivityName.Name = "colActivityName";
            colActivityName.OptionsColumn.AllowEdit = false;
            colActivityName.Visible = true;
            colActivityName.VisibleIndex = 0;
            colActivityName.Width = 300;
            //
            // colActivityStart
            //
            colActivityStart.Caption = "البداية";
            colActivityStart.DisplayFormat.FormatString = "d";
            colActivityStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colActivityStart.FieldName = "StartDate";
            colActivityStart.Name = "colActivityStart";
            colActivityStart.OptionsColumn.AllowEdit = false;
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
            colActivityFinish.OptionsColumn.AllowEdit = false;
            colActivityFinish.Visible = true;
            colActivityFinish.VisibleIndex = 2;
            colActivityFinish.Width = 120;
            //
            // colActivityFloat
            //
            colActivityFloat.Caption = "الفارق الزمني (Float)";
            colActivityFloat.FieldName = "Float";
            colActivityFloat.Name = "colActivityFloat";
            colActivityFloat.OptionsColumn.AllowEdit = false;
            colActivityFloat.Visible = true;
            colActivityFloat.VisibleIndex = 3;
            colActivityFloat.Width = 130;
            //
            // colActivityCritical
            //
            colActivityCritical.Caption = "حرج؟";
            colActivityCritical.FieldName = "IsCritical";
            colActivityCritical.Name = "colActivityCritical";
            colActivityCritical.OptionsColumn.AllowEdit = false;
            colActivityCritical.Visible = true;
            colActivityCritical.VisibleIndex = 4;
            colActivityCritical.Width = 80;
            //
            // colActivityProgress
            //
            colActivityProgress.Caption = "التقدم %";
            colActivityProgress.DisplayFormat.FormatString = "N0";
            colActivityProgress.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colActivityProgress.FieldName = "ProgressPercent";
            colActivityProgress.Name = "colActivityProgress";
            colActivityProgress.OptionsColumn.AllowEdit = false;
            colActivityProgress.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "ProgressPercent", "المتوسط: {0:N1}") });
            colActivityProgress.Visible = true;
            colActivityProgress.VisibleIndex = 5;
            colActivityProgress.Width = 110;
            //
            // pnlLoadingState
            //
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 374);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 422);
            pnlLoadingState.TabIndex = 2;
            pnlLoadingState.Visible = false;
            //
            // svgLoadingIcon
            //
            svgLoadingIcon.Location = new Point(651, 175);
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
            lblLoadingText.Location = new Point(583, 249);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(200, 20);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل الجدول الزمني...";
            //
            // pnlEmptyState
            //
            pnlEmptyState.Controls.Add(lblEmptyText);
            pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Dock = DockStyle.Fill;
            pnlEmptyState.Location = new Point(0, 374);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 422);
            pnlEmptyState.TabIndex = 3;
            pnlEmptyState.Visible = false;
            //
            // svgEmptyIcon
            //
            svgEmptyIcon.Location = new Point(651, 175);
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
            lblEmptyText.Location = new Point(583, 249);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(200, 20);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا يوجد أنشطة في الجدول الزمني";
            //
            // pnlErrorState
            //
            pnlErrorState.Controls.Add(btnRetry);
            pnlErrorState.Controls.Add(lblErrorText);
            pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Dock = DockStyle.Fill;
            pnlErrorState.Location = new Point(0, 374);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 422);
            pnlErrorState.TabIndex = 4;
            pnlErrorState.Visible = false;
            //
            // svgErrorIcon
            //
            svgErrorIcon.Location = new Point(651, 155);
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
            lblErrorText.Location = new Point(583, 229);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(200, 20);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل الجدول الزمني";
            //
            // btnRetry
            //
            btnRetry.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            btnRetry.Location = new Point(633, 259);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(100, 28);
            btnRetry.TabIndex = 2;
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;
            //
            // ucProjectSchedule
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grdActivities);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(pnlCharts);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucProjectSchedule";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 820);
            ((System.ComponentModel.ISupportInitialize)barManagerSchedule).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlGanttPlaceholder).EndInit();
            pnlGanttPlaceholder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)xyDiagramMilestones).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesMilestones).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartMilestoneTimeline).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagramProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesPlanned).EndInit();
            ((System.ComponentModel.ISupportInitialize)seriesActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartProgressCurve).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCharts).EndInit();
            pnlCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdActivities).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvActivities).EndInit();
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

        private DevExpress.XtraBars.BarManager barManagerSchedule;
        private DevExpress.XtraBars.Bar barSchedule;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarButtonItem bbiImportPrimavera;
        private DevExpress.XtraBars.BarButtonItem bbiImportMSP;
        private DevExpress.XtraBars.BarButtonItem bbiBaseline;
        private DevExpress.XtraBars.BarButtonItem bbiCompare;
        private DevExpress.XtraBars.BarButtonItem bbiProgressUpdate;
        private DevExpress.XtraBars.BarButtonItem bbiExportPdf;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraEditors.PanelControl pnlCharts;
        private DevExpress.XtraEditors.LabelControl lblGanttCaption;
        private DevExpress.XtraEditors.PanelControl pnlGanttPlaceholder;
        private DevExpress.XtraEditors.LabelControl lblGanttPlaceholderText;
        private DevExpress.XtraEditors.LabelControl lblMilestoneChartCaption;
        private DevExpress.XtraCharts.ChartControl chartMilestoneTimeline;
        private DevExpress.XtraCharts.Series seriesMilestones;
        private DevExpress.XtraCharts.XYDiagram xyDiagramMilestones;
        private DevExpress.XtraEditors.LabelControl lblProgressCurveCaption;
        private DevExpress.XtraCharts.ChartControl chartProgressCurve;
        private DevExpress.XtraCharts.Series seriesPlanned;
        private DevExpress.XtraCharts.Series seriesActual;
        private DevExpress.XtraCharts.XYDiagram xyDiagramProgress;

        private DevExpress.XtraGrid.GridControl grdActivities;
        private DevExpress.XtraGrid.Views.Grid.GridView gvActivities;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityName;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityStart;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityFloat;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityCritical;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityProgress;

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
