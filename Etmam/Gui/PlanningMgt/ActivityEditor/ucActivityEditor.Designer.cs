namespace Etmam
{
    partial class ucActivityEditor
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
            bbiNewActivity = new DevExpress.XtraBars.BarButtonItem();
            bbiDeleteActivity = new DevExpress.XtraBars.BarButtonItem();
            bbiDuplicateActivity = new DevExpress.XtraBars.BarButtonItem();
            bbiLinkActivities = new DevExpress.XtraBars.BarButtonItem();
            bbiUnlinkActivities = new DevExpress.XtraBars.BarButtonItem();
            bbiSaveActivity = new DevExpress.XtraBars.BarButtonItem();
            bbiValidateActivity = new DevExpress.XtraBars.BarButtonItem();

            barStatus = new DevExpress.XtraBars.Bar();
            sbiActivityCount = new DevExpress.XtraBars.BarStaticItem();
            sbiValidationStatus = new DevExpress.XtraBars.BarStaticItem();

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

            splitContainerMain = new DevExpress.XtraEditors.SplitContainerControl();

            // Upper Grid: Activities
            grdActivities = new DevExpress.XtraGrid.GridControl();
            gvActivities = new DevExpress.XtraGrid.Views.Grid.GridView();
            colActivityID = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colWBS = new DevExpress.XtraGrid.Columns.GridColumn();
            colCalendar = new DevExpress.XtraGrid.Columns.GridColumn();
            colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            colOriginalDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            colRemainingDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlannedStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlannedFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colActualStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colActualFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colProgressPct = new DevExpress.XtraGrid.Columns.GridColumn();
            colFloat = new DevExpress.XtraGrid.Columns.GridColumn();
            colCritical = new DevExpress.XtraGrid.Columns.GridColumn();
            colConstraint = new DevExpress.XtraGrid.Columns.GridColumn();
            colResponsible = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            // Lower Tabs: Relationships, Resources, Documents, Issues, Risks, History
            tabDetails = new DevExpress.XtraTab.XtraTabControl();
            tpRelationships = new DevExpress.XtraTab.XtraTabPage();
            grdRelationships = new DevExpress.XtraGrid.GridControl();
            gvRelationships = new DevExpress.XtraGrid.Views.Grid.GridView();

            tpResources = new DevExpress.XtraTab.XtraTabPage();
            grdResources = new DevExpress.XtraGrid.GridControl();
            gvResources = new DevExpress.XtraGrid.Views.Grid.GridView();

            tpDocuments = new DevExpress.XtraTab.XtraTabPage();
            grdDocuments = new DevExpress.XtraGrid.GridControl();
            gvDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();

            tpIssues = new DevExpress.XtraTab.XtraTabPage();
            grdIssues = new DevExpress.XtraGrid.GridControl();
            gvIssues = new DevExpress.XtraGrid.Views.Grid.GridView();

            tpRisks = new DevExpress.XtraTab.XtraTabPage();
            grdRisks = new DevExpress.XtraGrid.GridControl();
            gvRisks = new DevExpress.XtraGrid.Views.Grid.GridView();

            tpHistory = new DevExpress.XtraTab.XtraTabPage();
            grdHistory = new DevExpress.XtraGrid.GridControl();
            gvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();

            ((System.ComponentModel.ISupportInitialize)(barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splitContainerMain)).BeginInit();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(tabDetails)).BeginInit();
            tabDetails.SuspendLayout();
            tpRelationships.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdRelationships)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvRelationships)).BeginInit();
            tpResources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdResources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvResources)).BeginInit();
            tpDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvDocuments)).BeginInit();
            tpIssues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdIssues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvIssues)).BeginInit();
            tpRisks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdRisks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvRisks)).BeginInit();
            tpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvHistory)).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                bbiNewActivity, bbiDeleteActivity, bbiDuplicateActivity, bbiLinkActivities,
                bbiUnlinkActivities, bbiSaveActivity, bbiValidateActivity, sbiActivityCount, sbiValidationStatus
            });
            barManagerMain.MaxItemId = 9;
            barManagerMain.StatusBar = barStatus;

            // barMain
            barMain.BarName = "Main Bar";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(bbiNewActivity),
                new DevExpress.XtraBars.LinkPersistInfo(bbiDeleteActivity),
                new DevExpress.XtraBars.LinkPersistInfo(bbiDuplicateActivity),
                new DevExpress.XtraBars.LinkPersistInfo(bbiLinkActivities),
                new DevExpress.XtraBars.LinkPersistInfo(bbiUnlinkActivities),
                new DevExpress.XtraBars.LinkPersistInfo(bbiSaveActivity),
                new DevExpress.XtraBars.LinkPersistInfo(bbiValidateActivity)
            });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "Main Bar";

            bbiNewActivity.Caption = "نشاط جديد";
            bbiNewActivity.ItemClick += bbiNewActivity_ItemClick;

            bbiDeleteActivity.Caption = "حذف";
            bbiDeleteActivity.ItemClick += bbiDeleteActivity_ItemClick;

            bbiDuplicateActivity.Caption = "نسخ متكرر";
            bbiDuplicateActivity.ItemClick += bbiDuplicateActivity_ItemClick;

            bbiLinkActivities.Caption = "ربط الأنشطة";
            bbiLinkActivities.ItemClick += bbiLinkActivities_ItemClick;

            bbiUnlinkActivities.Caption = "إلغاء الربط";
            bbiUnlinkActivities.ItemClick += bbiUnlinkActivities_ItemClick;

            bbiSaveActivity.Caption = "حفظ";
            bbiSaveActivity.ItemClick += bbiSaveActivity_ItemClick;

            bbiValidateActivity.Caption = "التحقق من صحة المخطط";
            bbiValidateActivity.ItemClick += bbiValidateActivity_ItemClick;

            // barStatus
            barStatus.BarName = "Status Bar";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(sbiActivityCount),
                new DevExpress.XtraBars.LinkPersistInfo(sbiValidationStatus)
            });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "Status Bar";

            sbiActivityCount.Caption = "عدد الأنشطة: 0";
            sbiValidationStatus.Caption = "حالة التحقق: سليم";

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
            lblStateBanner.Text = "حالة المحرر: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Activity Grid Setup
            grdActivities.MainView = gvActivities;
            grdActivities.Name = "grdActivities";
            grdActivities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvActivities });

            gvActivities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colActivityID, colDescription, colWBS, colCalendar, colDuration,
                colOriginalDuration, colRemainingDuration, colPlannedStart, colPlannedFinish,
                colActualStart, colActualFinish, colProgressPct, colFloat, colCritical,
                colConstraint, colResponsible, colStatus
            });
            gvActivities.GridControl = grdActivities;
            gvActivities.Name = "gvActivities";

            colActivityID.Caption = "رمز النشاط (Activity ID)";
            colActivityID.FieldName = "ActivityID";
            colActivityID.Visible = true;
            colActivityID.VisibleIndex = 0;

            colDescription.Caption = "الوصف";
            colDescription.FieldName = "Description";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 1;

            colWBS.Caption = "رمز WBS";
            colWBS.FieldName = "WBS";
            colWBS.Visible = true;
            colWBS.VisibleIndex = 2;

            colCalendar.Caption = "التقويم (Calendar)";
            colCalendar.FieldName = "Calendar";
            colCalendar.Visible = true;
            colCalendar.VisibleIndex = 3;

            colDuration.Caption = "المدة الحالية";
            colDuration.FieldName = "Duration";
            colDuration.Visible = true;
            colDuration.VisibleIndex = 4;

            colOriginalDuration.Caption = "المدة الأصلية";
            colOriginalDuration.FieldName = "OriginalDuration";
            colOriginalDuration.Visible = true;
            colOriginalDuration.VisibleIndex = 5;

            colRemainingDuration.Caption = "المدة المتبقية";
            colRemainingDuration.FieldName = "RemainingDuration";
            colRemainingDuration.Visible = true;
            colRemainingDuration.VisibleIndex = 6;

            colPlannedStart.Caption = "تاريخ البداية المخطط";
            colPlannedStart.FieldName = "PlannedStart";
            colPlannedStart.Visible = true;
            colPlannedStart.VisibleIndex = 7;

            colPlannedFinish.Caption = "تاريخ النهاية المخطط";
            colPlannedFinish.FieldName = "PlannedFinish";
            colPlannedFinish.Visible = true;
            colPlannedFinish.VisibleIndex = 8;

            colActualStart.Caption = "تاريخ البداية الفعلي";
            colActualStart.FieldName = "ActualStart";
            colActualStart.Visible = true;
            colActualStart.VisibleIndex = 9;

            colActualFinish.Caption = "تاريخ النهاية الفعلي";
            colActualFinish.FieldName = "ActualFinish";
            colActualFinish.Visible = true;
            colActualFinish.VisibleIndex = 10;

            colProgressPct.Caption = "نسبة الإنجاز %";
            colProgressPct.FieldName = "ProgressPct";
            colProgressPct.Visible = true;
            colProgressPct.VisibleIndex = 11;

            colFloat.Caption = "المسافة الحرة (Float)";
            colFloat.FieldName = "Float";
            colFloat.Visible = true;
            colFloat.VisibleIndex = 12;

            colCritical.Caption = "حرج (Critical)";
            colCritical.FieldName = "Critical";
            colCritical.Visible = true;
            colCritical.VisibleIndex = 13;

            colConstraint.Caption = "القيد الزمني (Constraint)";
            colConstraint.FieldName = "Constraint";
            colConstraint.Visible = true;
            colConstraint.VisibleIndex = 14;

            colResponsible.Caption = "المسؤول";
            colResponsible.FieldName = "Responsible";
            colResponsible.Visible = true;
            colResponsible.VisibleIndex = 15;

            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 16;

            // Setup Tab Pages Grids
            tpRelationships.Controls.Add(grdRelationships);
            tpRelationships.Text = "العلاقات (Relationships)";
            grdRelationships.Dock = System.Windows.Forms.DockStyle.Fill;

            tpResources.Controls.Add(grdResources);
            tpResources.Text = "الموارد (Resources)";
            grdResources.Dock = System.Windows.Forms.DockStyle.Fill;

            tpDocuments.Controls.Add(grdDocuments);
            tpDocuments.Text = "المستندات (Documents)";
            grdDocuments.Dock = System.Windows.Forms.DockStyle.Fill;

            tpIssues.Controls.Add(grdIssues);
            tpIssues.Text = "المشاكل (Issues)";
            grdIssues.Dock = System.Windows.Forms.DockStyle.Fill;

            tpRisks.Controls.Add(grdRisks);
            tpRisks.Text = "المخاطر (Risks)";
            grdRisks.Dock = System.Windows.Forms.DockStyle.Fill;

            tpHistory.Controls.Add(grdHistory);
            tpHistory.Text = "سجل التعديلات (History)";
            grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;

            tabDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                tpRelationships, tpResources, tpDocuments, tpIssues, tpRisks, tpHistory
            });

            // Split Container
            splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerMain.Horizontal = false;
            splitContainerMain.Panel1.Controls.Add(grdActivities);
            splitContainerMain.Panel2.Controls.Add(tabDetails);
            splitContainerMain.SplitterPosition = 420;

            // Layout Control Main
            layoutControlMain.Controls.Add(splitContainerMain);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 66);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 700);

            // ucActivityEditor
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
            Name = "ucActivityEditor";
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
            ((System.ComponentModel.ISupportInitialize)(splitContainerMain)).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(tabDetails)).EndInit();
            tabDetails.ResumeLayout(false);
            tpRelationships.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdRelationships)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvRelationships)).EndInit();
            tpResources.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdResources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvResources)).EndInit();
            tpDocuments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvDocuments)).EndInit();
            tpIssues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdIssues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvIssues)).EndInit();
            tpRisks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdRisks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvRisks)).EndInit();
            tpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvHistory)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewActivity;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteActivity;
        private DevExpress.XtraBars.BarButtonItem bbiDuplicateActivity;
        private DevExpress.XtraBars.BarButtonItem bbiLinkActivities;
        private DevExpress.XtraBars.BarButtonItem bbiUnlinkActivities;
        private DevExpress.XtraBars.BarButtonItem bbiSaveActivity;
        private DevExpress.XtraBars.BarButtonItem bbiValidateActivity;

        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem sbiActivityCount;
        private DevExpress.XtraBars.BarStaticItem sbiValidationStatus;
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

        private DevExpress.XtraEditors.SplitContainerControl splitContainerMain;

        private DevExpress.XtraGrid.GridControl grdActivities;
        private DevExpress.XtraGrid.Views.Grid.GridView gvActivities;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityID;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colWBS;
        private DevExpress.XtraGrid.Columns.GridColumn colCalendar;
        private DevExpress.XtraGrid.Columns.GridColumn colDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginalDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainingDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colPlannedStart;
        private DevExpress.XtraGrid.Columns.GridColumn colPlannedFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colActualStart;
        private DevExpress.XtraGrid.Columns.GridColumn colActualFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colProgressPct;
        private DevExpress.XtraGrid.Columns.GridColumn colFloat;
        private DevExpress.XtraGrid.Columns.GridColumn colCritical;
        private DevExpress.XtraGrid.Columns.GridColumn colConstraint;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsible;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;

        private DevExpress.XtraTab.XtraTabControl tabDetails;
        private DevExpress.XtraTab.XtraTabPage tpRelationships;
        private DevExpress.XtraGrid.GridControl grdRelationships;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRelationships;

        private DevExpress.XtraTab.XtraTabPage tpResources;
        private DevExpress.XtraGrid.GridControl grdResources;
        private DevExpress.XtraGrid.Views.Grid.GridView gvResources;

        private DevExpress.XtraTab.XtraTabPage tpDocuments;
        private DevExpress.XtraGrid.GridControl grdDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocuments;

        private DevExpress.XtraTab.XtraTabPage tpIssues;
        private DevExpress.XtraGrid.GridControl grdIssues;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIssues;

        private DevExpress.XtraTab.XtraTabPage tpRisks;
        private DevExpress.XtraGrid.GridControl grdRisks;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRisks;

        private DevExpress.XtraTab.XtraTabPage tpHistory;
        private DevExpress.XtraGrid.GridControl grdHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHistory;
    }
}
