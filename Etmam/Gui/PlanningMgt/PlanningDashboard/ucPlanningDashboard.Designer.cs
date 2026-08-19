namespace Etmam
{
    partial class ucPlanningDashboard
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
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
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
            btnRetry = new DevExpress.XtraEditors.SimpleButton();
            
            layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            
            // KPI Cards
            cardTotalActivities = new DevExpress.XtraEditors.PanelControl();
            lblTotalActivitiesValue = new DevExpress.XtraEditors.LabelControl();
            lblTotalActivitiesTitle = new DevExpress.XtraEditors.LabelControl();
            
            cardCompletedActivities = new DevExpress.XtraEditors.PanelControl();
            lblCompletedActivitiesValue = new DevExpress.XtraEditors.LabelControl();
            lblCompletedActivitiesTitle = new DevExpress.XtraEditors.LabelControl();
            
            cardDelayedActivities = new DevExpress.XtraEditors.PanelControl();
            lblDelayedActivitiesValue = new DevExpress.XtraEditors.LabelControl();
            lblDelayedActivitiesTitle = new DevExpress.XtraEditors.LabelControl();
            
            cardCriticalActivities = new DevExpress.XtraEditors.PanelControl();
            lblCriticalActivitiesValue = new DevExpress.XtraEditors.LabelControl();
            lblCriticalActivitiesTitle = new DevExpress.XtraEditors.LabelControl();
            
            cardProgressPct = new DevExpress.XtraEditors.PanelControl();
            lblProgressPctValue = new DevExpress.XtraEditors.LabelControl();
            lblProgressPctTitle = new DevExpress.XtraEditors.LabelControl();
            
            cardSPI = new DevExpress.XtraEditors.PanelControl();
            lblSPIValue = new DevExpress.XtraEditors.LabelControl();
            lblSPITitle = new DevExpress.XtraEditors.LabelControl();
            
            cardUpcomingMilestones = new DevExpress.XtraEditors.PanelControl();
            lblUpcomingMilestonesValue = new DevExpress.XtraEditors.LabelControl();
            lblUpcomingMilestonesTitle = new DevExpress.XtraEditors.LabelControl();
            
            cardStrugglingActivities = new DevExpress.XtraEditors.PanelControl();
            lblStrugglingActivitiesValue = new DevExpress.XtraEditors.LabelControl();
            lblStrugglingActivitiesTitle = new DevExpress.XtraEditors.LabelControl();
            
            // Filters
            cboProjectFilter = new DevExpress.XtraEditors.LookUpEdit();
            cboScheduleVersionFilter = new DevExpress.XtraEditors.LookUpEdit();
            dtFromFilter = new DevExpress.XtraEditors.DateEdit();
            dtToFilter = new DevExpress.XtraEditors.DateEdit();
            btnApplyFilters = new DevExpress.XtraEditors.SimpleButton();
            btnResetFilters = new DevExpress.XtraEditors.SimpleButton();
            
            // Charts
            chartSCurve = new DevExpress.XtraCharts.ChartControl();
            chartPlannedVsActual = new DevExpress.XtraCharts.ChartControl();
            chartCriticalActivities = new DevExpress.XtraCharts.ChartControl();
            chartWeeklyProgress = new DevExpress.XtraCharts.ChartControl();
            chartMilestoneStatus = new DevExpress.XtraCharts.ChartControl();
            
            // Grids / Panels
            grdDelayedActivities = new DevExpress.XtraGrid.GridControl();
            gvDelayedActivities = new DevExpress.XtraGrid.Views.Grid.GridView();
            
            grdCriticalActivities = new DevExpress.XtraGrid.GridControl();
            gvCriticalActivities = new DevExpress.XtraGrid.Views.Grid.GridView();
            
            lstScheduleUpdates = new DevExpress.XtraEditors.ListBoxControl();
            
            grdUpcomingMilestones = new DevExpress.XtraGrid.GridControl();
            gvUpcomingMilestones = new DevExpress.XtraGrid.Views.Grid.GridView();
            
            tabOperationalPanels = new DevExpress.XtraTab.XtraTabControl();
            tpDelayed = new DevExpress.XtraTab.XtraTabPage();
            tpCritical = new DevExpress.XtraTab.XtraTabPage();
            tpUpdates = new DevExpress.XtraTab.XtraTabPage();
            tpMilestones = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cardTotalActivities)).BeginInit();
            cardTotalActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardCompletedActivities)).BeginInit();
            cardCompletedActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardDelayedActivities)).BeginInit();
            cardDelayedActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardCriticalActivities)).BeginInit();
            cardCriticalActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardProgressPct)).BeginInit();
            cardProgressPct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardSPI)).BeginInit();
            cardSPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardUpcomingMilestones)).BeginInit();
            cardUpcomingMilestones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardStrugglingActivities)).BeginInit();
            cardStrugglingActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cboProjectFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cboScheduleVersionFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtFromFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtFromFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtToFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtToFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartSCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartPlannedVsActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartCriticalActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartWeeklyProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartMilestoneStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grdDelayedActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvDelayedActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grdCriticalActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvCriticalActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lstScheduleUpdates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grdUpcomingMilestones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvUpcomingMilestones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(tabOperationalPanels)).BeginInit();
            tabOperationalPanels.SuspendLayout();
            tpDelayed.SuspendLayout();
            tpCritical.SuspendLayout();
            tpUpdates.SuspendLayout();
            tpMilestones.SuspendLayout();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiRefresh, bbiExportPdf, bbiPrint, sbiRecordCount, sbiLastRefresh });
            barManagerMain.MaxItemId = 5;
            barManagerMain.StatusBar = barStatus;

            // barMain
            barMain.BarName = "Main Bar";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(bbiRefresh),
                new DevExpress.XtraBars.LinkPersistInfo(bbiExportPdf),
                new DevExpress.XtraBars.LinkPersistInfo(bbiPrint)
            });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "Main Bar";

            bbiRefresh.Caption = "تحديث البيانات";
            bbiRefresh.Id = 0;
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;

            bbiExportPdf.Caption = "تصدير PDF";
            bbiExportPdf.Id = 1;
            bbiExportPdf.ItemClick += bbiExportPdf_ItemClick;

            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 2;
            bbiPrint.ItemClick += bbiPrint_ItemClick;

            // barStatus
            barStatus.BarName = "Status Bar";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(sbiRecordCount),
                new DevExpress.XtraBars.LinkPersistInfo(sbiLastRefresh)
            });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "Status Bar";

            sbiRecordCount.Caption = "السجلات: 0";
            sbiRecordCount.Id = 3;

            sbiLastRefresh.Caption = "آخر تحديث: -";
            sbiLastRefresh.Id = 4;

            // pnlStateBanner
            pnlStateBanner.Controls.Add(btnRetry);
            pnlStateBanner.Controls.Add(lblStateBanner);
            pnlStateBanner.Controls.Add(svgStateBannerIcon);
            pnlStateBanner.Dock = System.Windows.Forms.DockStyle.Top;
            pnlStateBanner.Location = new System.Drawing.Point(0, 30);
            pnlStateBanner.Name = "pnlStateBanner";
            pnlStateBanner.Size = new System.Drawing.Size(1200, 36);
            pnlStateBanner.TabIndex = 0;
            pnlStateBanner.Visible = false;

            lblStateBanner.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            lblStateBanner.Appearance.Options.UseFont = true;
            lblStateBanner.Location = new System.Drawing.Point(50, 8);
            lblStateBanner.Name = "lblStateBanner";
            lblStateBanner.Size = new System.Drawing.Size(200, 20);
            lblStateBanner.Text = "حالة الواجهة: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // KPI Setup
            SetupKpiCard(cardTotalActivities, lblTotalActivitiesTitle, lblTotalActivitiesValue, "إجمالي الأنشطة", "1,240");
            SetupKpiCard(cardCompletedActivities, lblCompletedActivitiesTitle, lblCompletedActivitiesValue, "الأنشطة المكتملة", "850");
            SetupKpiCard(cardDelayedActivities, lblDelayedActivitiesTitle, lblDelayedActivitiesValue, "الأنشطة المتأخرة", "42");
            SetupKpiCard(cardCriticalActivities, lblCriticalActivitiesTitle, lblCriticalActivitiesValue, "الأنشطة الحرجة (Critical)", "118");
            SetupKpiCard(cardProgressPct, lblProgressPctTitle, lblProgressPctValue, "نسبة الإنجاز الإجمالية", "68.5%");
            SetupKpiCard(cardSPI, lblSPITitle, lblSPIValue, "مؤشر أداء الجدول (SPI)", "0.96");
            SetupKpiCard(cardUpcomingMilestones, lblUpcomingMilestonesTitle, lblUpcomingMilestonesValue, "Milestones القادمة", "14");
            SetupKpiCard(cardStrugglingActivities, lblStrugglingActivitiesTitle, lblStrugglingActivitiesValue, "الأنشطة المتعثرة", "9");

            // Filter Control Setup
            cboProjectFilter.Properties.NullText = "اختر المشروع...";
            cboScheduleVersionFilter.Properties.NullText = "اصدار الجدول...";
            btnApplyFilters.Text = "تطبيق التصفية";
            btnApplyFilters.Click += btnApplyFilters_Click;
            btnResetFilters.Text = "إعادة ضبط";
            btnResetFilters.Click += btnResetFilters_Click;

            // Operational Tabs
            tpDelayed.Controls.Add(grdDelayedActivities);
            tpDelayed.Text = "الأنشطة المتأخرة";
            grdDelayedActivities.Dock = System.Windows.Forms.DockStyle.Fill;

            tpCritical.Controls.Add(grdCriticalActivities);
            tpCritical.Text = "الأنشطة الحرجة";
            grdCriticalActivities.Dock = System.Windows.Forms.DockStyle.Fill;

            tpUpdates.Controls.Add(lstScheduleUpdates);
            tpUpdates.Text = "آخر تحديثات الجدول";
            lstScheduleUpdates.Dock = System.Windows.Forms.DockStyle.Fill;

            tpMilestones.Controls.Add(grdUpcomingMilestones);
            tpMilestones.Text = "Upcoming Milestones";
            grdUpcomingMilestones.Dock = System.Windows.Forms.DockStyle.Fill;

            tabOperationalPanels.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tpDelayed, tpCritical, tpUpdates, tpMilestones });

            // Layout Control Main
            layoutControlMain.Controls.Add(cardTotalActivities);
            layoutControlMain.Controls.Add(cardCompletedActivities);
            layoutControlMain.Controls.Add(cardDelayedActivities);
            layoutControlMain.Controls.Add(cardCriticalActivities);
            layoutControlMain.Controls.Add(cardProgressPct);
            layoutControlMain.Controls.Add(cardSPI);
            layoutControlMain.Controls.Add(cardUpcomingMilestones);
            layoutControlMain.Controls.Add(cardStrugglingActivities);
            layoutControlMain.Controls.Add(cboProjectFilter);
            layoutControlMain.Controls.Add(cboScheduleVersionFilter);
            layoutControlMain.Controls.Add(dtFromFilter);
            layoutControlMain.Controls.Add(dtToFilter);
            layoutControlMain.Controls.Add(btnApplyFilters);
            layoutControlMain.Controls.Add(btnResetFilters);
            layoutControlMain.Controls.Add(chartSCurve);
            layoutControlMain.Controls.Add(chartPlannedVsActual);
            layoutControlMain.Controls.Add(chartCriticalActivities);
            layoutControlMain.Controls.Add(chartWeeklyProgress);
            layoutControlMain.Controls.Add(chartMilestoneStatus);
            layoutControlMain.Controls.Add(tabOperationalPanels);
            
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 66);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 700);

            // ucPlanningDashboard
            Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControlMain);
            Controls.Add(pnlStateBanner);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucPlanningDashboard";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1200, 796);

            ((System.ComponentModel.ISupportInitialize)(barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).EndInit();
            layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cardTotalActivities)).EndInit();
            cardTotalActivities.ResumeLayout(false);
            cardTotalActivities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardCompletedActivities)).EndInit();
            cardCompletedActivities.ResumeLayout(false);
            cardCompletedActivities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardDelayedActivities)).EndInit();
            cardDelayedActivities.ResumeLayout(false);
            cardDelayedActivities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardCriticalActivities)).EndInit();
            cardCriticalActivities.ResumeLayout(false);
            cardCriticalActivities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardProgressPct)).EndInit();
            cardProgressPct.ResumeLayout(false);
            cardProgressPct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardSPI)).EndInit();
            cardSPI.ResumeLayout(false);
            cardSPI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardUpcomingMilestones)).EndInit();
            cardUpcomingMilestones.ResumeLayout(false);
            cardUpcomingMilestones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardStrugglingActivities)).EndInit();
            cardStrugglingActivities.ResumeLayout(false);
            cardStrugglingActivities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cboProjectFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cboScheduleVersionFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtFromFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtFromFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtToFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtToFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartSCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartPlannedVsActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartCriticalActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartWeeklyProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartMilestoneStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(grdDelayedActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvDelayedActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(grdCriticalActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvCriticalActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lstScheduleUpdates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(grdUpcomingMilestones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvUpcomingMilestones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(tabOperationalPanels)).EndInit();
            tabOperationalPanels.ResumeLayout(false);
            tpDelayed.ResumeLayout(false);
            tpCritical.ResumeLayout(false);
            tpUpdates.ResumeLayout(false);
            tpMilestones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void SetupKpiCard(DevExpress.XtraEditors.PanelControl card, DevExpress.XtraEditors.LabelControl titleLbl, DevExpress.XtraEditors.LabelControl valLbl, string titleText, string valText)
        {
            card.Controls.Add(valLbl);
            card.Controls.Add(titleLbl);
            card.Size = new System.Drawing.Size(135, 70);

            titleLbl.Appearance.Font = new System.Drawing.Font("Cairo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            titleLbl.Appearance.Options.UseFont = true;
            titleLbl.Dock = System.Windows.Forms.DockStyle.Top;
            titleLbl.Text = titleText;

            valLbl.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            valLbl.Appearance.Options.UseFont = true;
            valLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            valLbl.Text = valText;
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiExportPdf;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarStaticItem sbiLastRefresh;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraEditors.PanelControl pnlStateBanner;
        private DevExpress.XtraEditors.LabelControl lblStateBanner;
        private DevExpress.XtraEditors.SvgImageBox svgStateBannerIcon;
        private DevExpress.XtraEditors.SimpleButton btnRetry;

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;

        private DevExpress.XtraEditors.PanelControl cardTotalActivities;
        private DevExpress.XtraEditors.LabelControl lblTotalActivitiesValue;
        private DevExpress.XtraEditors.LabelControl lblTotalActivitiesTitle;

        private DevExpress.XtraEditors.PanelControl cardCompletedActivities;
        private DevExpress.XtraEditors.LabelControl lblCompletedActivitiesValue;
        private DevExpress.XtraEditors.LabelControl lblCompletedActivitiesTitle;

        private DevExpress.XtraEditors.PanelControl cardDelayedActivities;
        private DevExpress.XtraEditors.LabelControl lblDelayedActivitiesValue;
        private DevExpress.XtraEditors.LabelControl lblDelayedActivitiesTitle;

        private DevExpress.XtraEditors.PanelControl cardCriticalActivities;
        private DevExpress.XtraEditors.LabelControl lblCriticalActivitiesValue;
        private DevExpress.XtraEditors.LabelControl lblCriticalActivitiesTitle;

        private DevExpress.XtraEditors.PanelControl cardProgressPct;
        private DevExpress.XtraEditors.LabelControl lblProgressPctValue;
        private DevExpress.XtraEditors.LabelControl lblProgressPctTitle;

        private DevExpress.XtraEditors.PanelControl cardSPI;
        private DevExpress.XtraEditors.LabelControl lblSPIValue;
        private DevExpress.XtraEditors.LabelControl lblSPITitle;

        private DevExpress.XtraEditors.PanelControl cardUpcomingMilestones;
        private DevExpress.XtraEditors.LabelControl lblUpcomingMilestonesValue;
        private DevExpress.XtraEditors.LabelControl lblUpcomingMilestonesTitle;

        private DevExpress.XtraEditors.PanelControl cardStrugglingActivities;
        private DevExpress.XtraEditors.LabelControl lblStrugglingActivitiesValue;
        private DevExpress.XtraEditors.LabelControl lblStrugglingActivitiesTitle;

        private DevExpress.XtraEditors.LookUpEdit cboProjectFilter;
        private DevExpress.XtraEditors.LookUpEdit cboScheduleVersionFilter;
        private DevExpress.XtraEditors.DateEdit dtFromFilter;
        private DevExpress.XtraEditors.DateEdit dtToFilter;
        private DevExpress.XtraEditors.SimpleButton btnApplyFilters;
        private DevExpress.XtraEditors.SimpleButton btnResetFilters;

        private DevExpress.XtraCharts.ChartControl chartSCurve;
        private DevExpress.XtraCharts.ChartControl chartPlannedVsActual;
        private DevExpress.XtraCharts.ChartControl chartCriticalActivities;
        private DevExpress.XtraCharts.ChartControl chartWeeklyProgress;
        private DevExpress.XtraCharts.ChartControl chartMilestoneStatus;

        private DevExpress.XtraTab.XtraTabControl tabOperationalPanels;
        private DevExpress.XtraTab.XtraTabPage tpDelayed;
        private DevExpress.XtraTab.XtraTabPage tpCritical;
        private DevExpress.XtraTab.XtraTabPage tpUpdates;
        private DevExpress.XtraTab.XtraTabPage tpMilestones;

        private DevExpress.XtraGrid.GridControl grdDelayedActivities;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDelayedActivities;

        private DevExpress.XtraGrid.GridControl grdCriticalActivities;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCriticalActivities;

        private DevExpress.XtraEditors.ListBoxControl lstScheduleUpdates;

        private DevExpress.XtraGrid.GridControl grdUpcomingMilestones;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUpcomingMilestones;
    }
}
