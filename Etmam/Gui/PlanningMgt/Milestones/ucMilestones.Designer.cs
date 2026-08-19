namespace Etmam
{
    partial class ucMilestones
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
            bbiAddMilestone = new DevExpress.XtraBars.BarButtonItem();
            bbiEditMilestone = new DevExpress.XtraBars.BarButtonItem();
            bbiDeleteMilestone = new DevExpress.XtraBars.BarButtonItem();
            bbiRefreshMilestones = new DevExpress.XtraBars.BarButtonItem();
            bbiExportMilestones = new DevExpress.XtraBars.BarButtonItem();

            barStatus = new DevExpress.XtraBars.Bar();
            sbiMilestonesCount = new DevExpress.XtraBars.BarStaticItem();

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

            // Cards
            cardTotalMilestones = new DevExpress.XtraEditors.PanelControl();
            lblTotalMilestonesTitle = new DevExpress.XtraEditors.LabelControl();
            lblTotalMilestonesValue = new DevExpress.XtraEditors.LabelControl();

            cardCompletedMilestones = new DevExpress.XtraEditors.PanelControl();
            lblCompletedMilestonesTitle = new DevExpress.XtraEditors.LabelControl();
            lblCompletedMilestonesValue = new DevExpress.XtraEditors.LabelControl();

            cardUpcomingMilestones = new DevExpress.XtraEditors.PanelControl();
            lblUpcomingMilestonesTitle = new DevExpress.XtraEditors.LabelControl();
            lblUpcomingMilestonesValue = new DevExpress.XtraEditors.LabelControl();

            cardDelayedMilestones = new DevExpress.XtraEditors.PanelControl();
            lblDelayedMilestonesTitle = new DevExpress.XtraEditors.LabelControl();
            lblDelayedMilestonesValue = new DevExpress.XtraEditors.LabelControl();

            // Split Container: Grid & Timeline View
            splitMain = new DevExpress.XtraEditors.SplitContainerControl();

            grdMilestones = new DevExpress.XtraGrid.GridControl();
            gvMilestones = new DevExpress.XtraGrid.Views.Grid.GridView();
            colMilestoneID = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlannedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colActualDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colOwner = new DevExpress.XtraGrid.Columns.GridColumn();

            pnlTimelineContainer = new DevExpress.XtraEditors.GroupControl();
            chartTimeline = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cardTotalMilestones)).BeginInit();
            cardTotalMilestones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardCompletedMilestones)).BeginInit();
            cardCompletedMilestones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardUpcomingMilestones)).BeginInit();
            cardUpcomingMilestones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardDelayedMilestones)).BeginInit();
            cardDelayedMilestones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(splitMain)).BeginInit();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdMilestones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvMilestones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlTimelineContainer)).BeginInit();
            pnlTimelineContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(chartTimeline)).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                bbiAddMilestone, bbiEditMilestone, bbiDeleteMilestone, bbiRefreshMilestones,
                bbiExportMilestones, sbiMilestonesCount
            });
            barManagerMain.MaxItemId = 6;
            barManagerMain.StatusBar = barStatus;

            // barMain
            barMain.BarName = "Main Bar";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(bbiAddMilestone),
                new DevExpress.XtraBars.LinkPersistInfo(bbiEditMilestone),
                new DevExpress.XtraBars.LinkPersistInfo(bbiDeleteMilestone),
                new DevExpress.XtraBars.LinkPersistInfo(bbiRefreshMilestones),
                new DevExpress.XtraBars.LinkPersistInfo(bbiExportMilestones)
            });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "Main Bar";

            bbiAddMilestone.Caption = "إضافة Milestone";
            bbiAddMilestone.ItemClick += bbiAddMilestone_ItemClick;

            bbiEditMilestone.Caption = "تعديل";
            bbiEditMilestone.ItemClick += bbiEditMilestone_ItemClick;

            bbiDeleteMilestone.Caption = "حذف";
            bbiDeleteMilestone.ItemClick += bbiDeleteMilestone_ItemClick;

            bbiRefreshMilestones.Caption = "تحديث";
            bbiRefreshMilestones.ItemClick += bbiRefreshMilestones_ItemClick;

            bbiExportMilestones.Caption = "تصدير";
            bbiExportMilestones.ItemClick += bbiExportMilestones_ItemClick;

            // barStatus
            barStatus.BarName = "Status Bar";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(sbiMilestonesCount)
            });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "Status Bar";

            sbiMilestonesCount.Caption = "إجمالي المحطات: 0";

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
            lblStateBanner.Text = "حالة Milestones: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Cards Setup
            SetupKpiCard(cardTotalMilestones, lblTotalMilestonesTitle, lblTotalMilestonesValue, "إجمالي Milestones", "48");
            SetupKpiCard(cardCompletedMilestones, lblCompletedMilestonesTitle, lblCompletedMilestonesValue, "المكتملة", "32");
            SetupKpiCard(cardUpcomingMilestones, lblUpcomingMilestonesTitle, lblUpcomingMilestonesValue, "القادمة", "12");
            SetupKpiCard(cardDelayedMilestones, lblDelayedMilestonesTitle, lblDelayedMilestonesValue, "المتأخرة", "4");

            // Grid Setup
            grdMilestones.MainView = gvMilestones;
            grdMilestones.Name = "grdMilestones";
            grdMilestones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvMilestones });

            gvMilestones.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colMilestoneID, colDescription, colPlannedDate, colActualDate,
                colVariance, colStatus, colOwner
            });
            gvMilestones.GridControl = grdMilestones;
            gvMilestones.Name = "gvMilestones";

            colMilestoneID.Caption = "رمز Milestone";
            colMilestoneID.FieldName = "MilestoneID";
            colMilestoneID.Visible = true;
            colMilestoneID.VisibleIndex = 0;

            colDescription.Caption = "الوصف";
            colDescription.FieldName = "Description";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 1;

            colPlannedDate.Caption = "التاريخ المخطط";
            colPlannedDate.FieldName = "PlannedDate";
            colPlannedDate.Visible = true;
            colPlannedDate.VisibleIndex = 2;

            colActualDate.Caption = "التاريخ الفعلي";
            colActualDate.FieldName = "ActualDate";
            colActualDate.Visible = true;
            colActualDate.VisibleIndex = 3;

            colVariance.Caption = "الانحراف (أيام)";
            colVariance.FieldName = "Variance";
            colVariance.Visible = true;
            colVariance.VisibleIndex = 4;

            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 5;

            colOwner.Caption = "المسؤول (Owner)";
            colOwner.FieldName = "Owner";
            colOwner.Visible = true;
            colOwner.VisibleIndex = 6;

            // Timeline View Group
            pnlTimelineContainer.Controls.Add(chartTimeline);
            pnlTimelineContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlTimelineContainer.Text = "عرض التسلسل الزمني للمحطات (Timeline View)";
            chartTimeline.Dock = System.Windows.Forms.DockStyle.Fill;

            // Split Container
            splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            splitMain.Horizontal = false;
            splitMain.Panel1.Controls.Add(grdMilestones);
            splitMain.Panel2.Controls.Add(pnlTimelineContainer);
            splitMain.SplitterPosition = 380;

            // Layout Control Main
            layoutControlMain.Controls.Add(cardTotalMilestones);
            layoutControlMain.Controls.Add(cardCompletedMilestones);
            layoutControlMain.Controls.Add(cardUpcomingMilestones);
            layoutControlMain.Controls.Add(cardDelayedMilestones);
            layoutControlMain.Controls.Add(splitMain);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 66);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 700);

            // ucMilestones
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
            Name = "ucMilestones";
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
            ((System.ComponentModel.ISupportInitialize)(cardTotalMilestones)).EndInit();
            cardTotalMilestones.ResumeLayout(false);
            cardTotalMilestones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardCompletedMilestones)).EndInit();
            cardCompletedMilestones.ResumeLayout(false);
            cardCompletedMilestones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardUpcomingMilestones)).EndInit();
            cardUpcomingMilestones.ResumeLayout(false);
            cardUpcomingMilestones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardDelayedMilestones)).EndInit();
            cardDelayedMilestones.ResumeLayout(false);
            cardDelayedMilestones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(splitMain)).EndInit();
            splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdMilestones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvMilestones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pnlTimelineContainer)).EndInit();
            pnlTimelineContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(chartTimeline)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void SetupKpiCard(DevExpress.XtraEditors.PanelControl card, DevExpress.XtraEditors.LabelControl titleLbl, DevExpress.XtraEditors.LabelControl valLbl, string titleText, string valText)
        {
            card.Controls.Add(valLbl);
            card.Controls.Add(titleLbl);
            card.Size = new System.Drawing.Size(200, 70);

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
        private DevExpress.XtraBars.BarButtonItem bbiAddMilestone;
        private DevExpress.XtraBars.BarButtonItem bbiEditMilestone;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteMilestone;
        private DevExpress.XtraBars.BarButtonItem bbiRefreshMilestones;
        private DevExpress.XtraBars.BarButtonItem bbiExportMilestones;

        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem sbiMilestonesCount;
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

        private DevExpress.XtraEditors.PanelControl cardTotalMilestones;
        private DevExpress.XtraEditors.LabelControl lblTotalMilestonesTitle;
        private DevExpress.XtraEditors.LabelControl lblTotalMilestonesValue;

        private DevExpress.XtraEditors.PanelControl cardCompletedMilestones;
        private DevExpress.XtraEditors.LabelControl lblCompletedMilestonesTitle;
        private DevExpress.XtraEditors.LabelControl lblCompletedMilestonesValue;

        private DevExpress.XtraEditors.PanelControl cardUpcomingMilestones;
        private DevExpress.XtraEditors.LabelControl lblUpcomingMilestonesTitle;
        private DevExpress.XtraEditors.LabelControl lblUpcomingMilestonesValue;

        private DevExpress.XtraEditors.PanelControl cardDelayedMilestones;
        private DevExpress.XtraEditors.LabelControl lblDelayedMilestonesTitle;
        private DevExpress.XtraEditors.LabelControl lblDelayedMilestonesValue;

        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraGrid.GridControl grdMilestones;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMilestones;
        private DevExpress.XtraGrid.Columns.GridColumn colMilestoneID;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPlannedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colActualDate;
        private DevExpress.XtraGrid.Columns.GridColumn colVariance;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;

        private DevExpress.XtraEditors.GroupControl pnlTimelineContainer;
        private DevExpress.XtraCharts.ChartControl chartTimeline;
    }
}
