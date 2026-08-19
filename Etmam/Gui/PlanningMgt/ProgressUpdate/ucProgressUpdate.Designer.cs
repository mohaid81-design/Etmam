namespace Etmam
{
    partial class ucProgressUpdate
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
            pnlStateBanner = new DevExpress.XtraEditors.PanelControl();
            lblStateBanner = new DevExpress.XtraEditors.LabelControl();
            svgStateBannerIcon = new DevExpress.XtraEditors.SvgImageBox();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();

            layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();

            // KPI Cards
            cardPlannedProgress = new DevExpress.XtraEditors.PanelControl();
            lblPlannedProgressTitle = new DevExpress.XtraEditors.LabelControl();
            lblPlannedProgressValue = new DevExpress.XtraEditors.LabelControl();

            cardActualProgress = new DevExpress.XtraEditors.PanelControl();
            lblActualProgressTitle = new DevExpress.XtraEditors.LabelControl();
            lblActualProgressValue = new DevExpress.XtraEditors.LabelControl();

            cardProgressVariance = new DevExpress.XtraEditors.PanelControl();
            lblProgressVarianceTitle = new DevExpress.XtraEditors.LabelControl();
            lblProgressVarianceValue = new DevExpress.XtraEditors.LabelControl();

            cardProgressSPI = new DevExpress.XtraEditors.PanelControl();
            lblProgressSPITitle = new DevExpress.XtraEditors.LabelControl();
            lblProgressSPIValue = new DevExpress.XtraEditors.LabelControl();

            // Action Buttons Panel
            pnlActions = new DevExpress.XtraEditors.PanelControl();
            btnUpdateProgress = new DevExpress.XtraEditors.SimpleButton();
            btnImportProgress = new DevExpress.XtraEditors.SimpleButton();
            btnSaveProgress = new DevExpress.XtraEditors.SimpleButton();

            // Grid Control
            grdProgress = new DevExpress.XtraGrid.GridControl();
            gvProgress = new DevExpress.XtraGrid.Views.Grid.GridView();
            colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlannedPct = new DevExpress.XtraGrid.Columns.GridColumn();
            colActualPct = new DevExpress.XtraGrid.Columns.GridColumn();
            colRemainingDays = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cardPlannedProgress)).BeginInit();
            cardPlannedProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardActualProgress)).BeginInit();
            cardActualProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardProgressVariance)).BeginInit();
            cardProgressVariance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardProgressSPI)).BeginInit();
            cardProgressSPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pnlActions)).BeginInit();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grdProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvProgress)).BeginInit();
            SuspendLayout();

            // pnlStateBanner
            pnlStateBanner.Controls.Add(btnRetry);
            pnlStateBanner.Controls.Add(lblStateBanner);
            pnlStateBanner.Controls.Add(svgStateBannerIcon);
            pnlStateBanner.Dock = System.Windows.Forms.DockStyle.Top;
            pnlStateBanner.Location = new System.Drawing.Point(0, 0);
            pnlStateBanner.Name = "pnlStateBanner";
            pnlStateBanner.Size = new System.Drawing.Size(1200, 36);
            pnlStateBanner.TabIndex = 0;
            pnlStateBanner.Visible = false;

            lblStateBanner.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            lblStateBanner.Appearance.Options.UseFont = true;
            lblStateBanner.Location = new System.Drawing.Point(50, 8);
            lblStateBanner.Name = "lblStateBanner";
            lblStateBanner.Size = new System.Drawing.Size(200, 20);
            lblStateBanner.Text = "حالة تحديث التقدم: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Cards Setup
            SetupKpiCard(cardPlannedProgress, lblPlannedProgressTitle, lblPlannedProgressValue, "النسبة المخططة الإجمالية", "72.0%");
            SetupKpiCard(cardActualProgress, lblActualProgressTitle, lblActualProgressValue, "النسبة الفعلية الإجمالية", "68.5%");
            SetupKpiCard(cardProgressVariance, lblProgressVarianceTitle, lblProgressVarianceValue, "الانحراف (Variance)", "-3.5%");
            SetupKpiCard(cardProgressSPI, lblProgressSPITitle, lblProgressSPIValue, "مؤشر SPI الحالي", "0.95");

            // Actions Setup
            pnlActions.Controls.Add(btnUpdateProgress);
            pnlActions.Controls.Add(btnImportProgress);
            pnlActions.Controls.Add(btnSaveProgress);
            pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            pnlActions.Height = 45;

            btnUpdateProgress.Location = new System.Drawing.Point(10, 8);
            btnUpdateProgress.Size = new System.Drawing.Size(140, 30);
            btnUpdateProgress.Text = "تحديث التقدم";
            btnUpdateProgress.Click += btnUpdateProgress_Click;

            btnImportProgress.Location = new System.Drawing.Point(160, 8);
            btnImportProgress.Size = new System.Drawing.Size(140, 30);
            btnImportProgress.Text = "استيراد التقدم من ملف";
            btnImportProgress.Click += btnImportProgress_Click;

            btnSaveProgress.Location = new System.Drawing.Point(310, 8);
            btnSaveProgress.Size = new System.Drawing.Size(120, 30);
            btnSaveProgress.Text = "حفظ والتثبيت";
            btnSaveProgress.Click += btnSaveProgress_Click;

            // Grid Setup
            grdProgress.MainView = gvProgress;
            grdProgress.Name = "grdProgress";
            grdProgress.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvProgress });

            gvProgress.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colActivity, colPlannedPct, colActualPct, colRemainingDays, colStatus
            });
            gvProgress.GridControl = grdProgress;
            gvProgress.Name = "gvProgress";

            colActivity.Caption = "النشاط (Activity)";
            colActivity.FieldName = "ActivityName";
            colActivity.Visible = true;
            colActivity.VisibleIndex = 0;

            colPlannedPct.Caption = "النسبة المخططة %";
            colPlannedPct.FieldName = "PlannedPct";
            colPlannedPct.Visible = true;
            colPlannedPct.VisibleIndex = 1;

            colActualPct.Caption = "النسبة الفعلية %";
            colActualPct.FieldName = "ActualPct";
            colActualPct.Visible = true;
            colActualPct.VisibleIndex = 2;

            colRemainingDays.Caption = "الأيام المتبقية (Remaining)";
            colRemainingDays.FieldName = "RemainingDays";
            colRemainingDays.Visible = true;
            colRemainingDays.VisibleIndex = 3;

            colStatus.Caption = "حالة الإنجاز";
            colStatus.FieldName = "Status";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 4;

            // Layout Control Main
            layoutControlMain.Controls.Add(cardPlannedProgress);
            layoutControlMain.Controls.Add(cardActualProgress);
            layoutControlMain.Controls.Add(cardProgressVariance);
            layoutControlMain.Controls.Add(cardProgressSPI);
            layoutControlMain.Controls.Add(pnlActions);
            layoutControlMain.Controls.Add(grdProgress);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 36);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 730);

            // ucProgressUpdate
            Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControlMain);
            Controls.Add(pnlStateBanner);
            Name = "ucProgressUpdate";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1200, 766);

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).EndInit();
            layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cardPlannedProgress)).EndInit();
            cardPlannedProgress.ResumeLayout(false);
            cardPlannedProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardActualProgress)).EndInit();
            cardActualProgress.ResumeLayout(false);
            cardActualProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardProgressVariance)).EndInit();
            cardProgressVariance.ResumeLayout(false);
            cardProgressVariance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardProgressSPI)).EndInit();
            cardProgressSPI.ResumeLayout(false);
            cardProgressSPI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pnlActions)).EndInit();
            pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grdProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvProgress)).EndInit();
            ResumeLayout(false);
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

        private DevExpress.XtraEditors.PanelControl pnlStateBanner;
        private DevExpress.XtraEditors.LabelControl lblStateBanner;
        private DevExpress.XtraEditors.SvgImageBox svgStateBannerIcon;
        private DevExpress.XtraEditors.SimpleButton btnRetry;

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;

        private DevExpress.XtraEditors.PanelControl cardPlannedProgress;
        private DevExpress.XtraEditors.LabelControl lblPlannedProgressTitle;
        private DevExpress.XtraEditors.LabelControl lblPlannedProgressValue;

        private DevExpress.XtraEditors.PanelControl cardActualProgress;
        private DevExpress.XtraEditors.LabelControl lblActualProgressTitle;
        private DevExpress.XtraEditors.LabelControl lblActualProgressValue;

        private DevExpress.XtraEditors.PanelControl cardProgressVariance;
        private DevExpress.XtraEditors.LabelControl lblProgressVarianceTitle;
        private DevExpress.XtraEditors.LabelControl lblProgressVarianceValue;

        private DevExpress.XtraEditors.PanelControl cardProgressSPI;
        private DevExpress.XtraEditors.LabelControl lblProgressSPITitle;
        private DevExpress.XtraEditors.LabelControl lblProgressSPIValue;

        private DevExpress.XtraEditors.PanelControl pnlActions;
        private DevExpress.XtraEditors.SimpleButton btnUpdateProgress;
        private DevExpress.XtraEditors.SimpleButton btnImportProgress;
        private DevExpress.XtraEditors.SimpleButton btnSaveProgress;

        private DevExpress.XtraGrid.GridControl grdProgress;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProgress;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colPlannedPct;
        private DevExpress.XtraGrid.Columns.GridColumn colActualPct;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainingDays;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
