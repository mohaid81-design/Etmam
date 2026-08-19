namespace Etmam
{
    partial class ucBaselineManagement
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
            bbiCreateBaseline = new DevExpress.XtraBars.BarButtonItem();
            bbiActivateBaseline = new DevExpress.XtraBars.BarButtonItem();
            bbiCompareBaseline = new DevExpress.XtraBars.BarButtonItem();
            bbiArchiveBaseline = new DevExpress.XtraBars.BarButtonItem();

            barStatus = new DevExpress.XtraBars.Bar();
            sbiBaselineCount = new DevExpress.XtraBars.BarStaticItem();

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

            // Upper Grid: Baselines
            grdBaselines = new DevExpress.XtraGrid.GridControl();
            gvBaselines = new DevExpress.XtraGrid.Views.Grid.GridView();
            colBaselineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();

            // Lower Group: Comparison Panel
            pnlComparison = new DevExpress.XtraEditors.GroupControl();
            lblPlannedVal = new DevExpress.XtraEditors.LabelControl();
            lblCurrentVal = new DevExpress.XtraEditors.LabelControl();
            lblVarianceVal = new DevExpress.XtraEditors.LabelControl();
            grdBaselineComparison = new DevExpress.XtraGrid.GridControl();
            gvBaselineComparison = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCompActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompBaselineStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompCurrentStart = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompStartVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompBaselineFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompCurrentFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompFinishVariance = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splitContainerMain)).BeginInit();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdBaselines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvBaselines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlComparison)).BeginInit();
            pnlComparison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdBaselineComparison)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvBaselineComparison)).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                bbiCreateBaseline, bbiActivateBaseline, bbiCompareBaseline, bbiArchiveBaseline, sbiBaselineCount
            });
            barManagerMain.MaxItemId = 5;
            barManagerMain.StatusBar = barStatus;

            // barMain
            barMain.BarName = "Main Bar";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(bbiCreateBaseline),
                new DevExpress.XtraBars.LinkPersistInfo(bbiActivateBaseline),
                new DevExpress.XtraBars.LinkPersistInfo(bbiCompareBaseline),
                new DevExpress.XtraBars.LinkPersistInfo(bbiArchiveBaseline)
            });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "Main Bar";

            bbiCreateBaseline.Caption = "إنشاء خط مرجعي جديد";
            bbiCreateBaseline.ItemClick += bbiCreateBaseline_ItemClick;

            bbiActivateBaseline.Caption = "تفعيل (Activate)";
            bbiActivateBaseline.ItemClick += bbiActivateBaseline_ItemClick;

            bbiCompareBaseline.Caption = "مقارنة الحالية بالمرجعية";
            bbiCompareBaseline.ItemClick += bbiCompareBaseline_ItemClick;

            bbiArchiveBaseline.Caption = "أرشفة (Archive)";
            bbiArchiveBaseline.ItemClick += bbiArchiveBaseline_ItemClick;

            // barStatus
            barStatus.BarName = "Status Bar";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(sbiBaselineCount)
            });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "Status Bar";

            sbiBaselineCount.Caption = "عدد الخطوط المرجعية: 0";

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
            lblStateBanner.Text = "حالة الخط المرجعي: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Grid Baselines
            grdBaselines.MainView = gvBaselines;
            grdBaselines.Name = "grdBaselines";
            grdBaselines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvBaselines });

            gvBaselines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colBaselineNo, colVersion, colCreatedBy, colDate, colStatus, colNotes
            });
            gvBaselines.GridControl = grdBaselines;
            gvBaselines.Name = "gvBaselines";

            colBaselineNo.Caption = "رقم الخط المرجعي (Baseline No)";
            colBaselineNo.FieldName = "BaselineNo";
            colBaselineNo.Visible = true;
            colBaselineNo.VisibleIndex = 0;

            colVersion.Caption = "الإصدار (Version)";
            colVersion.FieldName = "Version";
            colVersion.Visible = true;
            colVersion.VisibleIndex = 1;

            colCreatedBy.Caption = "تم الإنشاء بواسطة";
            colCreatedBy.FieldName = "CreatedBy";
            colCreatedBy.Visible = true;
            colCreatedBy.VisibleIndex = 2;

            colDate.Caption = "تاريخ الإنشاء";
            colDate.FieldName = "Date";
            colDate.Visible = true;
            colDate.VisibleIndex = 3;

            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 4;

            colNotes.Caption = "ملاحظات";
            colNotes.FieldName = "Notes";
            colNotes.Visible = true;
            colNotes.VisibleIndex = 5;

            // Comparison Panel Setup
            lblPlannedVal.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            lblPlannedVal.Location = new System.Drawing.Point(20, 30);
            lblPlannedVal.Text = "الإنجاز المخطط المرجعي: 65%";

            lblCurrentVal.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            lblCurrentVal.Location = new System.Drawing.Point(300, 30);
            lblCurrentVal.Text = "الإنجاز الحالي العملياتي: 61%";

            lblVarianceVal.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            lblVarianceVal.Location = new System.Drawing.Point(600, 30);
            lblVarianceVal.Text = "انحراف الجدول (Variance): -4%";

            grdBaselineComparison.MainView = gvBaselineComparison;
            grdBaselineComparison.Name = "grdBaselineComparison";
            grdBaselineComparison.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvBaselineComparison });
            grdBaselineComparison.Location = new System.Drawing.Point(10, 60);
            grdBaselineComparison.Size = new System.Drawing.Size(1160, 200);

            gvBaselineComparison.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colCompActivity, colCompBaselineStart, colCompCurrentStart, colCompStartVariance,
                colCompBaselineFinish, colCompCurrentFinish, colCompFinishVariance
            });
            gvBaselineComparison.GridControl = grdBaselineComparison;
            gvBaselineComparison.Name = "gvBaselineComparison";

            colCompActivity.Caption = "النشاط";
            colCompActivity.FieldName = "Activity";
            colCompActivity.Visible = true;
            colCompActivity.VisibleIndex = 0;

            colCompBaselineStart.Caption = "بداية الخط المرجعي";
            colCompBaselineStart.FieldName = "BaselineStart";
            colCompBaselineStart.Visible = true;
            colCompBaselineStart.VisibleIndex = 1;

            colCompCurrentStart.Caption = "البداية الحالية";
            colCompCurrentStart.FieldName = "CurrentStart";
            colCompCurrentStart.Visible = true;
            colCompCurrentStart.VisibleIndex = 2;

            colCompStartVariance.Caption = "انحراف البداية (أيام)";
            colCompStartVariance.FieldName = "StartVariance";
            colCompStartVariance.Visible = true;
            colCompStartVariance.VisibleIndex = 3;

            colCompBaselineFinish.Caption = "نهاية الخط المرجعي";
            colCompBaselineFinish.FieldName = "BaselineFinish";
            colCompBaselineFinish.Visible = true;
            colCompBaselineFinish.VisibleIndex = 4;

            colCompCurrentFinish.Caption = "النهاية الحالية";
            colCompCurrentFinish.FieldName = "CurrentFinish";
            colCompCurrentFinish.Visible = true;
            colCompCurrentFinish.VisibleIndex = 5;

            colCompFinishVariance.Caption = "انحراف النهاية (أيام)";
            colCompFinishVariance.FieldName = "FinishVariance";
            colCompFinishVariance.Visible = true;
            colCompFinishVariance.VisibleIndex = 6;

            pnlComparison.Controls.Add(lblPlannedVal);
            pnlComparison.Controls.Add(lblCurrentVal);
            pnlComparison.Controls.Add(lblVarianceVal);
            pnlComparison.Controls.Add(grdBaselineComparison);
            pnlComparison.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlComparison.Text = "لوحة التحليل والتطبيق المرجعي (Baseline Comparison Panel)";

            // Split Container
            splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerMain.Horizontal = false;
            splitContainerMain.Panel1.Controls.Add(grdBaselines);
            splitContainerMain.Panel2.Controls.Add(pnlComparison);
            splitContainerMain.SplitterPosition = 350;

            // Layout Control Main
            layoutControlMain.Controls.Add(splitContainerMain);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 66);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 700);

            // ucBaselineManagement
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
            Name = "ucBaselineManagement";
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
            ((System.ComponentModel.ISupportInitialize)(grdBaselines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvBaselines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pnlComparison)).EndInit();
            pnlComparison.ResumeLayout(false);
            pnlComparison.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(grdBaselineComparison)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvBaselineComparison)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiCreateBaseline;
        private DevExpress.XtraBars.BarButtonItem bbiActivateBaseline;
        private DevExpress.XtraBars.BarButtonItem bbiCompareBaseline;
        private DevExpress.XtraBars.BarButtonItem bbiArchiveBaseline;

        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem sbiBaselineCount;
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

        private DevExpress.XtraGrid.GridControl grdBaselines;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBaselines;
        private DevExpress.XtraGrid.Columns.GridColumn colBaselineNo;
        private DevExpress.XtraGrid.Columns.GridColumn colVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;

        private DevExpress.XtraEditors.GroupControl pnlComparison;
        private DevExpress.XtraEditors.LabelControl lblPlannedVal;
        private DevExpress.XtraEditors.LabelControl lblCurrentVal;
        private DevExpress.XtraEditors.LabelControl lblVarianceVal;

        private DevExpress.XtraGrid.GridControl grdBaselineComparison;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBaselineComparison;
        private DevExpress.XtraGrid.Columns.GridColumn colCompActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colCompBaselineStart;
        private DevExpress.XtraGrid.Columns.GridColumn colCompCurrentStart;
        private DevExpress.XtraGrid.Columns.GridColumn colCompStartVariance;
        private DevExpress.XtraGrid.Columns.GridColumn colCompBaselineFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colCompCurrentFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colCompFinishVariance;
    }
}
