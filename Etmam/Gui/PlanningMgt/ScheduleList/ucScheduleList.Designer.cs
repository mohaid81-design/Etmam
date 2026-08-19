namespace Etmam
{
    partial class ucScheduleList
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
            bbiNewSchedule = new DevExpress.XtraBars.BarButtonItem();
            bbiEditSchedule = new DevExpress.XtraBars.BarButtonItem();
            bbiDeleteSchedule = new DevExpress.XtraBars.BarButtonItem();
            bbiImportSchedule = new DevExpress.XtraBars.BarButtonItem();
            bbiExportSchedule = new DevExpress.XtraBars.BarButtonItem();
            bbiManageBaseline = new DevExpress.XtraBars.BarButtonItem();
            bbiCompareSchedules = new DevExpress.XtraBars.BarButtonItem();
            bbiProgressUpdate = new DevExpress.XtraBars.BarButtonItem();
            bbiPrintSchedule = new DevExpress.XtraBars.BarButtonItem();
            bbiRefreshSchedule = new DevExpress.XtraBars.BarButtonItem();
            
            barStatus = new DevExpress.XtraBars.Bar();
            sbiRecordCount = new DevExpress.XtraBars.BarStaticItem();
            sbiLastUpdate = new DevExpress.XtraBars.BarStaticItem();
            
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
            
            // Filter Controls
            pnlFilters = new DevExpress.XtraEditors.GroupControl();
            cboCompanyFilter = new DevExpress.XtraEditors.LookUpEdit();
            cboBranchFilter = new DevExpress.XtraEditors.LookUpEdit();
            cboProjectFilter = new DevExpress.XtraEditors.LookUpEdit();
            txtVersionFilter = new DevExpress.XtraEditors.TextEdit();
            cboStatusFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            dtStartDateFilter = new DevExpress.XtraEditors.DateEdit();
            dtFinishDateFilter = new DevExpress.XtraEditors.DateEdit();
            btnApplyFilter = new DevExpress.XtraEditors.SimpleButton();
            btnClearFilter = new DevExpress.XtraEditors.SimpleButton();

            // Grid Control
            grdSchedules = new DevExpress.XtraGrid.GridControl();
            gvSchedules = new DevExpress.XtraGrid.Views.Grid.GridView();
            colScheduleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            colBaseline = new DevExpress.XtraGrid.Columns.GridColumn();
            colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colFinishDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colProgressPct = new DevExpress.XtraGrid.Columns.GridColumn();
            colSPI = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdate = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pnlFilters)).BeginInit();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cboCompanyFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cboBranchFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cboProjectFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(txtVersionFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cboStatusFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtStartDateFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtStartDateFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtFinishDateFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dtFinishDateFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grdSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvSchedules)).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            barManagerMain.DockControls.Add(barDockControlTop);
            barManagerMain.DockControls.Add(barDockControlBottom);
            barManagerMain.DockControls.Add(barDockControlLeft);
            barManagerMain.DockControls.Add(barDockControlRight);
            barManagerMain.Form = this;
            barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                bbiNewSchedule, bbiEditSchedule, bbiDeleteSchedule, bbiImportSchedule,
                bbiExportSchedule, bbiManageBaseline, bbiCompareSchedules, bbiProgressUpdate,
                bbiPrintSchedule, bbiRefreshSchedule, sbiRecordCount, sbiLastUpdate
            });
            barManagerMain.MaxItemId = 12;
            barManagerMain.StatusBar = barStatus;

            // barMain
            barMain.BarName = "Main Bar";
            barMain.DockCol = 0;
            barMain.DockRow = 0;
            barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(bbiNewSchedule),
                new DevExpress.XtraBars.LinkPersistInfo(bbiEditSchedule),
                new DevExpress.XtraBars.LinkPersistInfo(bbiDeleteSchedule),
                new DevExpress.XtraBars.LinkPersistInfo(bbiImportSchedule),
                new DevExpress.XtraBars.LinkPersistInfo(bbiExportSchedule),
                new DevExpress.XtraBars.LinkPersistInfo(bbiManageBaseline),
                new DevExpress.XtraBars.LinkPersistInfo(bbiCompareSchedules),
                new DevExpress.XtraBars.LinkPersistInfo(bbiProgressUpdate),
                new DevExpress.XtraBars.LinkPersistInfo(bbiPrintSchedule),
                new DevExpress.XtraBars.LinkPersistInfo(bbiRefreshSchedule)
            });
            barMain.OptionsBar.AllowQuickCustomization = false;
            barMain.OptionsBar.DrawDragBorder = false;
            barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "Main Bar";

            bbiNewSchedule.Caption = "جدول جديد";
            bbiNewSchedule.ItemClick += bbiNewSchedule_ItemClick;

            bbiEditSchedule.Caption = "تعديل";
            bbiEditSchedule.ItemClick += bbiEditSchedule_ItemClick;

            bbiDeleteSchedule.Caption = "حذف";
            bbiDeleteSchedule.ItemClick += bbiDeleteSchedule_ItemClick;

            bbiImportSchedule.Caption = "استيراد";
            bbiImportSchedule.ItemClick += bbiImportSchedule_ItemClick;

            bbiExportSchedule.Caption = "تصدير";
            bbiExportSchedule.ItemClick += bbiExportSchedule_ItemClick;

            bbiManageBaseline.Caption = "الخط المرجعي (Baseline)";
            bbiManageBaseline.ItemClick += bbiManageBaseline_ItemClick;

            bbiCompareSchedules.Caption = "مقارنة الجداول";
            bbiCompareSchedules.ItemClick += bbiCompareSchedules_ItemClick;

            bbiProgressUpdate.Caption = "تحديث نسبة الإنجاز";
            bbiProgressUpdate.ItemClick += bbiProgressUpdate_ItemClick;

            bbiPrintSchedule.Caption = "طباعة";
            bbiPrintSchedule.ItemClick += bbiPrintSchedule_ItemClick;

            bbiRefreshSchedule.Caption = "تحديث";
            bbiRefreshSchedule.ItemClick += bbiRefreshSchedule_ItemClick;

            // barStatus
            barStatus.BarName = "Status Bar";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(sbiRecordCount),
                new DevExpress.XtraBars.LinkPersistInfo(sbiLastUpdate)
            });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "Status Bar";

            sbiRecordCount.Caption = "عدد الجداول: 0";
            sbiLastUpdate.Caption = "آخر تحديث: -";

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
            lblStateBanner.Text = "حالة القائمة: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Grid setup
            grdSchedules.MainView = gvSchedules;
            grdSchedules.Name = "grdSchedules";
            grdSchedules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvSchedules });

            gvSchedules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colScheduleCode, colProjectName, colVersion, colBaseline, colStartDate,
                colFinishDate, colProgressPct, colSPI, colStatus, colLastUpdate
            });
            gvSchedules.GridControl = grdSchedules;
            gvSchedules.Name = "gvSchedules";
            gvSchedules.OptionsView.ShowAutoFilterRow = true;
            gvSchedules.OptionsView.ShowGroupPanel = false;

            colScheduleCode.Caption = "رمز الجدول";
            colScheduleCode.FieldName = "ScheduleCode";
            colScheduleCode.Visible = true;
            colScheduleCode.VisibleIndex = 0;

            colProjectName.Caption = "المشروع";
            colProjectName.FieldName = "ProjectName";
            colProjectName.Visible = true;
            colProjectName.VisibleIndex = 1;

            colVersion.Caption = "الإصدار";
            colVersion.FieldName = "Version";
            colVersion.Visible = true;
            colVersion.VisibleIndex = 2;

            colBaseline.Caption = "الخط المرجعي (Baseline)";
            colBaseline.FieldName = "BaselineName";
            colBaseline.Visible = true;
            colBaseline.VisibleIndex = 3;

            colStartDate.Caption = "تاريخ البداية";
            colStartDate.FieldName = "StartDate";
            colStartDate.Visible = true;
            colStartDate.VisibleIndex = 4;

            colFinishDate.Caption = "تاريخ النهاية";
            colFinishDate.FieldName = "FinishDate";
            colFinishDate.Visible = true;
            colFinishDate.VisibleIndex = 5;

            colProgressPct.Caption = "نسبة الإنجاز %";
            colProgressPct.FieldName = "ProgressPct";
            colProgressPct.Visible = true;
            colProgressPct.VisibleIndex = 6;

            colSPI.Caption = "مؤشر SPI";
            colSPI.FieldName = "SPI";
            colSPI.Visible = true;
            colSPI.VisibleIndex = 7;

            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 8;

            colLastUpdate.Caption = "آخر تحديث";
            colLastUpdate.FieldName = "LastUpdate";
            colLastUpdate.Visible = true;
            colLastUpdate.VisibleIndex = 9;

            // Filters Group Setup
            pnlFilters.Controls.Add(cboCompanyFilter);
            pnlFilters.Controls.Add(cboBranchFilter);
            pnlFilters.Controls.Add(cboProjectFilter);
            pnlFilters.Controls.Add(txtVersionFilter);
            pnlFilters.Controls.Add(cboStatusFilter);
            pnlFilters.Controls.Add(dtStartDateFilter);
            pnlFilters.Controls.Add(dtFinishDateFilter);
            pnlFilters.Controls.Add(btnApplyFilter);
            pnlFilters.Controls.Add(btnClearFilter);
            pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilters.Height = 80;
            pnlFilters.Text = "خيارات الفلترة والتصفية";

            cboCompanyFilter.Properties.NullText = "الشركة...";
            cboBranchFilter.Properties.NullText = "الفرع...";
            cboProjectFilter.Properties.NullText = "المشروع...";
            txtVersionFilter.Properties.NullValuePrompt = "إصدار الجدول...";
            cboStatusFilter.Properties.NullText = "الحالة...";
            btnApplyFilter.Text = "فلترة";
            btnApplyFilter.Click += btnApplyFilter_Click;
            btnClearFilter.Text = "تفريغ";
            btnClearFilter.Click += btnClearFilter_Click;

            // Layout Control Main
            layoutControlMain.Controls.Add(pnlFilters);
            layoutControlMain.Controls.Add(grdSchedules);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 66);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 700);

            // ucScheduleList
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
            Name = "ucScheduleList";
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
            ((System.ComponentModel.ISupportInitialize)(pnlFilters)).EndInit();
            pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(cboCompanyFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cboBranchFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cboProjectFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(txtVersionFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cboStatusFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtStartDateFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtStartDateFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtFinishDateFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dtFinishDateFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(grdSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvSchedules)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewSchedule;
        private DevExpress.XtraBars.BarButtonItem bbiEditSchedule;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteSchedule;
        private DevExpress.XtraBars.BarButtonItem bbiImportSchedule;
        private DevExpress.XtraBars.BarButtonItem bbiExportSchedule;
        private DevExpress.XtraBars.BarButtonItem bbiManageBaseline;
        private DevExpress.XtraBars.BarButtonItem bbiCompareSchedules;
        private DevExpress.XtraBars.BarButtonItem bbiProgressUpdate;
        private DevExpress.XtraBars.BarButtonItem bbiPrintSchedule;
        private DevExpress.XtraBars.BarButtonItem bbiRefreshSchedule;

        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarStaticItem sbiLastUpdate;
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

        private DevExpress.XtraEditors.GroupControl pnlFilters;
        private DevExpress.XtraEditors.LookUpEdit cboCompanyFilter;
        private DevExpress.XtraEditors.LookUpEdit cboBranchFilter;
        private DevExpress.XtraEditors.LookUpEdit cboProjectFilter;
        private DevExpress.XtraEditors.TextEdit txtVersionFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatusFilter;
        private DevExpress.XtraEditors.DateEdit dtStartDateFilter;
        private DevExpress.XtraEditors.DateEdit dtFinishDateFilter;
        private DevExpress.XtraEditors.SimpleButton btnApplyFilter;
        private DevExpress.XtraEditors.SimpleButton btnClearFilter;

        private DevExpress.XtraGrid.GridControl grdSchedules;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSchedules;
        private DevExpress.XtraGrid.Columns.GridColumn colScheduleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseline;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFinishDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProgressPct;
        private DevExpress.XtraGrid.Columns.GridColumn colSPI;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdate;
    }
}
