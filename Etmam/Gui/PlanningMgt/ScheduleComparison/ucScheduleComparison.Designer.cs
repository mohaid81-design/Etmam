namespace Etmam
{
    partial class ucScheduleComparison
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
            bbiExportComparison = new DevExpress.XtraBars.BarButtonItem();
            bbiPrintComparison = new DevExpress.XtraBars.BarButtonItem();
            bbiRefreshComparison = new DevExpress.XtraBars.BarButtonItem();

            barStatus = new DevExpress.XtraBars.Bar();
            sbiComparisonStatus = new DevExpress.XtraBars.BarStaticItem();

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

            splitOuter = new DevExpress.XtraEditors.SplitContainerControl();
            splitTop = new DevExpress.XtraEditors.SplitContainerControl();

            // Left Panel: Baseline Schedule
            pnlBaselineGroup = new DevExpress.XtraEditors.GroupControl();
            grdBaselineSchedule = new DevExpress.XtraGrid.GridControl();
            gvBaselineSchedule = new DevExpress.XtraGrid.Views.Grid.GridView();
            colBaseActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            colBaseStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colBaseFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colBaseDuration = new DevExpress.XtraGrid.Columns.GridColumn();

            // Right Panel: Current Schedule
            pnlCurrentGroup = new DevExpress.XtraEditors.GroupControl();
            grdCurrentSchedule = new DevExpress.XtraGrid.GridControl();
            gvCurrentSchedule = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCurrActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            colChangeType = new DevExpress.XtraGrid.Columns.GridColumn();

            // Bottom Panel: Variance Summary
            pnlVarianceGroup = new DevExpress.XtraEditors.GroupControl();
            grdVarianceSummary = new DevExpress.XtraGrid.GridControl();
            gvVarianceSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            colVarActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            colVarType = new DevExpress.XtraGrid.Columns.GridColumn();
            colVarStartDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            colVarFinishDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            colVarDurationDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            colVarImpact = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splitOuter)).BeginInit();
            splitOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(splitTop)).BeginInit();
            splitTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pnlBaselineGroup)).BeginInit();
            pnlBaselineGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdBaselineSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvBaselineSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlCurrentGroup)).BeginInit();
            pnlCurrentGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdCurrentSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvCurrentSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlVarianceGroup)).BeginInit();
            pnlVarianceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdVarianceSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvVarianceSummary)).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                bbiExportComparison, bbiPrintComparison, bbiRefreshComparison, sbiComparisonStatus
            });
            barManagerMain.MaxItemId = 4;
            barManagerMain.StatusBar = barStatus;

            // barMain
            barMain.BarName = "Main Bar";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(bbiExportComparison),
                new DevExpress.XtraBars.LinkPersistInfo(bbiPrintComparison),
                new DevExpress.XtraBars.LinkPersistInfo(bbiRefreshComparison)
            });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "Main Bar";

            bbiExportComparison.Caption = "تصدير نتائج المقارنة";
            bbiExportComparison.ItemClick += bbiExportComparison_ItemClick;

            bbiPrintComparison.Caption = "طباعة تقرير الفروقات";
            bbiPrintComparison.ItemClick += bbiPrintComparison_ItemClick;

            bbiRefreshComparison.Caption = "إعادة إجراء المقارنة";
            bbiRefreshComparison.ItemClick += bbiRefreshComparison_ItemClick;

            // barStatus
            barStatus.BarName = "Status Bar";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(sbiComparisonStatus)
            });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "Status Bar";

            sbiComparisonStatus.Caption = "حالة المقارنة: متطابق جزئياً (12 تغييراً)";

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
            lblStateBanner.Text = "حالة شاشة المقارنة: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Baseline Grid
            grdBaselineSchedule.MainView = gvBaselineSchedule;
            grdBaselineSchedule.Name = "grdBaselineSchedule";
            grdBaselineSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvBaselineSchedule });

            gvBaselineSchedule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colBaseActivity, colBaseStart, colBaseFinish, colBaseDuration
            });
            gvBaselineSchedule.GridControl = grdBaselineSchedule;

            colBaseActivity.Caption = "النشاط المرجعي";
            colBaseActivity.FieldName = "ActivityName";
            colBaseActivity.Visible = true;
            colBaseActivity.VisibleIndex = 0;

            colBaseStart.Caption = "البداية المرجعية";
            colBaseStart.FieldName = "Start";
            colBaseStart.Visible = true;
            colBaseStart.VisibleIndex = 1;

            colBaseFinish.Caption = "النهاية المرجعية";
            colBaseFinish.FieldName = "Finish";
            colBaseFinish.Visible = true;
            colBaseFinish.VisibleIndex = 2;

            colBaseDuration.Caption = "المدة المرجعية";
            colBaseDuration.FieldName = "Duration";
            colBaseDuration.Visible = true;
            colBaseDuration.VisibleIndex = 3;

            pnlBaselineGroup.Controls.Add(grdBaselineSchedule);
            pnlBaselineGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBaselineGroup.Text = "الجدول المرجعي (Baseline Schedule)";
            grdBaselineSchedule.Dock = System.Windows.Forms.DockStyle.Fill;

            // Current Grid
            grdCurrentSchedule.MainView = gvCurrentSchedule;
            grdCurrentSchedule.Name = "grdCurrentSchedule";
            grdCurrentSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCurrentSchedule });

            gvCurrentSchedule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colCurrActivity, colCurrStart, colCurrFinish, colCurrDuration, colChangeType
            });
            gvCurrentSchedule.GridControl = grdCurrentSchedule;

            colCurrActivity.Caption = "النشاط الحالي";
            colCurrActivity.FieldName = "ActivityName";
            colCurrActivity.Visible = true;
            colCurrActivity.VisibleIndex = 0;

            colCurrStart.Caption = "البداية الحالية";
            colCurrStart.FieldName = "Start";
            colCurrStart.Visible = true;
            colCurrStart.VisibleIndex = 1;

            colCurrFinish.Caption = "النهاية الحالية";
            colCurrFinish.FieldName = "Finish";
            colCurrFinish.Visible = true;
            colCurrFinish.VisibleIndex = 2;

            colCurrDuration.Caption = "المدة الحالية";
            colCurrDuration.FieldName = "Duration";
            colCurrDuration.Visible = true;
            colCurrDuration.VisibleIndex = 3;

            colChangeType.Caption = "نوع التغيير (Added/Deleted/Changed/Delayed)";
            colChangeType.FieldName = "ChangeType";
            colChangeType.Visible = true;
            colChangeType.VisibleIndex = 4;

            pnlCurrentGroup.Controls.Add(grdCurrentSchedule);
            pnlCurrentGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCurrentGroup.Text = "الجدول الحالي العملياتي (Current Schedule)";
            grdCurrentSchedule.Dock = System.Windows.Forms.DockStyle.Fill;

            // Variance Summary Grid
            grdVarianceSummary.MainView = gvVarianceSummary;
            grdVarianceSummary.Name = "grdVarianceSummary";
            grdVarianceSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvVarianceSummary });

            gvVarianceSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colVarActivity, colVarType, colVarStartDiff, colVarFinishDiff, colVarDurationDiff, colVarImpact
            });
            gvVarianceSummary.GridControl = grdVarianceSummary;

            colVarActivity.Caption = "النشاط";
            colVarActivity.FieldName = "ActivityName";
            colVarActivity.Visible = true;
            colVarActivity.VisibleIndex = 0;

            colVarType.Caption = "تصنيف الاختلاف";
            colVarType.FieldName = "VarianceType";
            colVarType.Visible = true;
            colVarType.VisibleIndex = 1;

            colVarStartDiff.Caption = "فرق البداية (أيام)";
            colVarStartDiff.FieldName = "StartDiff";
            colVarStartDiff.Visible = true;
            colVarStartDiff.VisibleIndex = 2;

            colVarFinishDiff.Caption = "فرق النهاية (أيام)";
            colVarFinishDiff.FieldName = "FinishDiff";
            colVarFinishDiff.Visible = true;
            colVarFinishDiff.VisibleIndex = 3;

            colVarDurationDiff.Caption = "فرق المدة (أيام)";
            colVarDurationDiff.FieldName = "DurationDiff";
            colVarDurationDiff.Visible = true;
            colVarDurationDiff.VisibleIndex = 4;

            colVarImpact.Caption = "التأثير على المسار الحرج (Impact)";
            colVarImpact.FieldName = "Impact";
            colVarImpact.Visible = true;
            colVarImpact.VisibleIndex = 5;

            pnlVarianceGroup.Controls.Add(grdVarianceSummary);
            pnlVarianceGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlVarianceGroup.Text = "ملخص الانحراف والفروقات (Variance Summary)";
            grdVarianceSummary.Dock = System.Windows.Forms.DockStyle.Fill;

            // Split Layout Setup
            splitTop.Dock = System.Windows.Forms.DockStyle.Fill;
            splitTop.Panel1.Controls.Add(pnlBaselineGroup);
            splitTop.Panel2.Controls.Add(pnlCurrentGroup);
            splitTop.SplitterPosition = 580;

            splitOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            splitOuter.Horizontal = false;
            splitOuter.Panel1.Controls.Add(splitTop);
            splitOuter.Panel2.Controls.Add(pnlVarianceGroup);
            splitOuter.SplitterPosition = 420;

            // Layout Control Main
            layoutControlMain.Controls.Add(splitOuter);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 66);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 700);

            // ucScheduleComparison
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
            Name = "ucScheduleComparison";
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
            ((System.ComponentModel.ISupportInitialize)(splitOuter)).EndInit();
            splitOuter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitTop)).EndInit();
            splitTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pnlBaselineGroup)).EndInit();
            pnlBaselineGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdBaselineSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvBaselineSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pnlCurrentGroup)).EndInit();
            pnlCurrentGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdCurrentSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvCurrentSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pnlVarianceGroup)).EndInit();
            pnlVarianceGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdVarianceSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvVarianceSummary)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiExportComparison;
        private DevExpress.XtraBars.BarButtonItem bbiPrintComparison;
        private DevExpress.XtraBars.BarButtonItem bbiRefreshComparison;

        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem sbiComparisonStatus;
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

        private DevExpress.XtraEditors.SplitContainerControl splitOuter;
        private DevExpress.XtraEditors.SplitContainerControl splitTop;

        private DevExpress.XtraEditors.GroupControl pnlBaselineGroup;
        private DevExpress.XtraGrid.GridControl grdBaselineSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBaselineSchedule;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseStart;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseDuration;

        private DevExpress.XtraEditors.GroupControl pnlCurrentGroup;
        private DevExpress.XtraGrid.GridControl grdCurrentSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCurrentSchedule;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrStart;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeType;

        private DevExpress.XtraEditors.GroupControl pnlVarianceGroup;
        private DevExpress.XtraGrid.GridControl grdVarianceSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVarianceSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colVarActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colVarType;
        private DevExpress.XtraGrid.Columns.GridColumn colVarStartDiff;
        private DevExpress.XtraGrid.Columns.GridColumn colVarFinishDiff;
        private DevExpress.XtraGrid.Columns.GridColumn colVarDurationDiff;
        private DevExpress.XtraGrid.Columns.GridColumn colVarImpact;
    }
}
