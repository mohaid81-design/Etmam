namespace Etmam
{
    partial class ucScheduleExplorer
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
            bbiExpandAll = new DevExpress.XtraBars.BarButtonItem();
            bbiCollapseAll = new DevExpress.XtraBars.BarButtonItem();
            bbiRefreshTree = new DevExpress.XtraBars.BarButtonItem();
            bbiFilterCritical = new DevExpress.XtraBars.BarButtonItem();

            barStatus = new DevExpress.XtraBars.Bar();
            sbiWbsCount = new DevExpress.XtraBars.BarStaticItem();
            sbiActivityCount = new DevExpress.XtraBars.BarStaticItem();

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

            splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            
            // TreeList (WBS)
            treeWBS = new DevExpress.XtraTreeList.TreeList();
            colWBSCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colWBSName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colWBSType = new DevExpress.XtraTreeList.Columns.TreeListColumn();

            // Right Pane: Activity Grid & Gantt Container
            splitRightPane = new DevExpress.XtraEditors.SplitContainerControl();
            
            grdActivities = new DevExpress.XtraGrid.GridControl();
            gvActivities = new DevExpress.XtraGrid.Views.Grid.GridView();
            colActivityCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityName = new DevExpress.XtraGrid.Columns.GridColumn();
            colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            colCalendar = new DevExpress.XtraGrid.Columns.GridColumn();
            colStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colFloat = new DevExpress.XtraGrid.Columns.GridColumn();
            colCritical = new DevExpress.XtraGrid.Columns.GridColumn();
            colProgress = new DevExpress.XtraGrid.Columns.GridColumn();

            pnlGanttContainer = new DevExpress.XtraEditors.GroupControl();
            lblGanttPlaceholder = new DevExpress.XtraEditors.LabelControl();
            svgGanttIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)(barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splitMain)).BeginInit();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(treeWBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splitRightPane)).BeginInit();
            splitRightPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlGanttContainer)).BeginInit();
            pnlGanttContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgGanttIcon)).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                bbiExpandAll, bbiCollapseAll, bbiRefreshTree, bbiFilterCritical, sbiWbsCount, sbiActivityCount
            });
            barManagerMain.MaxItemId = 6;
            barManagerMain.StatusBar = barStatus;

            // barMain
            barMain.BarName = "Main Bar";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(bbiExpandAll),
                new DevExpress.XtraBars.LinkPersistInfo(bbiCollapseAll),
                new DevExpress.XtraBars.LinkPersistInfo(bbiRefreshTree),
                new DevExpress.XtraBars.LinkPersistInfo(bbiFilterCritical)
            });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "Main Bar";

            bbiExpandAll.Caption = "توسع الكل";
            bbiExpandAll.ItemClick += bbiExpandAll_ItemClick;

            bbiCollapseAll.Caption = "طي الكل";
            bbiCollapseAll.ItemClick += bbiCollapseAll_ItemClick;

            bbiRefreshTree.Caption = "تحديث الهيكل";
            bbiRefreshTree.ItemClick += bbiRefreshTree_ItemClick;

            bbiFilterCritical.Caption = "الأنشطة الحرجة فقط";
            bbiFilterCritical.ItemClick += bbiFilterCritical_ItemClick;

            // barStatus
            barStatus.BarName = "Status Bar";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(sbiWbsCount),
                new DevExpress.XtraBars.LinkPersistInfo(sbiActivityCount)
            });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "Status Bar";

            sbiWbsCount.Caption = "عناصر WBS: 0";
            sbiActivityCount.Caption = "عدد الأنشطة: 0";

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
            lblStateBanner.Text = "حالة الاستكشاف: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // WBS TreeList
            treeWBS.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
                colWBSCode, colWBSName, colWBSType
            });
            treeWBS.Dock = System.Windows.Forms.DockStyle.Fill;
            treeWBS.Name = "treeWBS";

            colWBSCode.Caption = "كود WBS";
            colWBSCode.FieldName = "WBSCode";
            colWBSCode.Visible = true;
            colWBSCode.VisibleIndex = 0;

            colWBSName.Caption = "اسم المكون";
            colWBSName.FieldName = "WBSName";
            colWBSName.Visible = true;
            colWBSName.VisibleIndex = 1;

            colWBSType.Caption = "المستوى / النوع";
            colWBSType.FieldName = "WBSType";
            colWBSType.Visible = true;
            colWBSType.VisibleIndex = 2;

            // Activity Grid
            grdActivities.MainView = gvActivities;
            grdActivities.Name = "grdActivities";
            grdActivities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvActivities });

            gvActivities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colActivityCode, colActivityName, colDuration, colCalendar, colStart,
                colFinish, colFloat, colCritical, colProgress
            });
            gvActivities.GridControl = grdActivities;
            gvActivities.Name = "gvActivities";

            colActivityCode.Caption = "رمز النشاط";
            colActivityCode.FieldName = "ActivityCode";
            colActivityCode.Visible = true;
            colActivityCode.VisibleIndex = 0;

            colActivityName.Caption = "اسم النشاط";
            colActivityName.FieldName = "ActivityName";
            colActivityName.Visible = true;
            colActivityName.VisibleIndex = 1;

            colDuration.Caption = "المدة";
            colDuration.FieldName = "Duration";
            colDuration.Visible = true;
            colDuration.VisibleIndex = 2;

            colCalendar.Caption = "التقويم";
            colCalendar.FieldName = "Calendar";
            colCalendar.Visible = true;
            colCalendar.VisibleIndex = 3;

            colStart.Caption = "البداية";
            colStart.FieldName = "Start";
            colStart.Visible = true;
            colStart.VisibleIndex = 4;

            colFinish.Caption = "النهاية";
            colFinish.FieldName = "Finish";
            colFinish.Visible = true;
            colFinish.VisibleIndex = 5;

            colFloat.Caption = "المسافة الحرة (Float)";
            colFloat.FieldName = "Float";
            colFloat.Visible = true;
            colFloat.VisibleIndex = 6;

            colCritical.Caption = "حرج (Critical)";
            colCritical.FieldName = "Critical";
            colCritical.Visible = true;
            colCritical.VisibleIndex = 7;

            colProgress.Caption = "نسبة الإنجاز";
            colProgress.FieldName = "Progress";
            colProgress.Visible = true;
            colProgress.VisibleIndex = 8;

            // Gantt Placeholder Group
            pnlGanttContainer.Controls.Add(lblGanttPlaceholder);
            pnlGanttContainer.Controls.Add(svgGanttIcon);
            pnlGanttContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlGanttContainer.Text = "منطقة عرض المخطط الزمني المستقبلي (Gantt Chart View Area)";

            lblGanttPlaceholder.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Italic);
            lblGanttPlaceholder.Appearance.Options.UseFont = true;
            lblGanttPlaceholder.Location = new System.Drawing.Point(50, 40);
            lblGanttPlaceholder.Text = "منطقة مخصصة لربط واستعراض Gantt Chart View لاحقاً بدون تعديل تصميم الواجهة.";

            svgGanttIcon.Location = new System.Drawing.Point(15, 35);
            svgGanttIcon.Size = new System.Drawing.Size(32, 32);

            // Right Split
            splitRightPane.Dock = System.Windows.Forms.DockStyle.Fill;
            splitRightPane.Horizontal = false;
            splitRightPane.Panel1.Controls.Add(grdActivities);
            splitRightPane.Panel2.Controls.Add(pnlGanttContainer);
            splitRightPane.SplitterPosition = 350;

            // SplitMain
            splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            splitMain.Panel1.Controls.Add(treeWBS);
            splitMain.Panel2.Controls.Add(splitRightPane);
            splitMain.SplitterPosition = 320;

            // Layout Control Main
            layoutControlMain.Controls.Add(splitMain);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 66);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 700);

            // ucScheduleExplorer
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
            Name = "ucScheduleExplorer";
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
            ((System.ComponentModel.ISupportInitialize)(splitMain)).EndInit();
            splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(treeWBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splitRightPane)).EndInit();
            splitRightPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pnlGanttContainer)).EndInit();
            pnlGanttContainer.ResumeLayout(false);
            pnlGanttContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(svgGanttIcon)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiExpandAll;
        private DevExpress.XtraBars.BarButtonItem bbiCollapseAll;
        private DevExpress.XtraBars.BarButtonItem bbiRefreshTree;
        private DevExpress.XtraBars.BarButtonItem bbiFilterCritical;

        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem sbiWbsCount;
        private DevExpress.XtraBars.BarStaticItem sbiActivityCount;
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

        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraTreeList.TreeList treeWBS;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colWBSCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colWBSName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colWBSType;

        private DevExpress.XtraEditors.SplitContainerControl splitRightPane;
        private DevExpress.XtraGrid.GridControl grdActivities;
        private DevExpress.XtraGrid.Views.Grid.GridView gvActivities;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityCode;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityName;
        private DevExpress.XtraGrid.Columns.GridColumn colDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colCalendar;
        private DevExpress.XtraGrid.Columns.GridColumn colStart;
        private DevExpress.XtraGrid.Columns.GridColumn colFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colFloat;
        private DevExpress.XtraGrid.Columns.GridColumn colCritical;
        private DevExpress.XtraGrid.Columns.GridColumn colProgress;

        private DevExpress.XtraEditors.GroupControl pnlGanttContainer;
        private DevExpress.XtraEditors.LabelControl lblGanttPlaceholder;
        private DevExpress.XtraEditors.SvgImageBox svgGanttIcon;
    }
}
