namespace Etmam
{
    partial class ucDelayAnalysis
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

            // Cards
            cardDelayedActivitiesCount = new DevExpress.XtraEditors.PanelControl();
            lblDelayedActivitiesCountTitle = new DevExpress.XtraEditors.LabelControl();
            lblDelayedActivitiesCountValue = new DevExpress.XtraEditors.LabelControl();

            cardTotalDelayDays = new DevExpress.XtraEditors.PanelControl();
            lblTotalDelayDaysTitle = new DevExpress.XtraEditors.LabelControl();
            lblTotalDelayDaysValue = new DevExpress.XtraEditors.LabelControl();

            cardCriticalDelaysCount = new DevExpress.XtraEditors.PanelControl();
            lblCriticalDelaysCountTitle = new DevExpress.XtraEditors.LabelControl();
            lblCriticalDelaysCountValue = new DevExpress.XtraEditors.LabelControl();

            cardExtensionCandidatesCount = new DevExpress.XtraEditors.PanelControl();
            lblExtensionCandidatesCountTitle = new DevExpress.XtraEditors.LabelControl();
            lblExtensionCandidatesCountValue = new DevExpress.XtraEditors.LabelControl();

            // Charts
            chartDelayTrend = new DevExpress.XtraCharts.ChartControl();
            chartDelayByDiscipline = new DevExpress.XtraCharts.ChartControl();
            chartDelayByContractor = new DevExpress.XtraCharts.ChartControl();

            // Grid
            grdDelayAnalysis = new DevExpress.XtraGrid.GridControl();
            gvDelayAnalysis = new DevExpress.XtraGrid.Views.Grid.GridView();
            colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            colDelayReason = new DevExpress.XtraGrid.Columns.GridColumn();
            colDelayDays = new DevExpress.XtraGrid.Columns.GridColumn();
            colResponsible = new DevExpress.XtraGrid.Columns.GridColumn();
            colRecommendedAction = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cardDelayedActivitiesCount)).BeginInit();
            cardDelayedActivitiesCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardTotalDelayDays)).BeginInit();
            cardTotalDelayDays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardCriticalDelaysCount)).BeginInit();
            cardCriticalDelaysCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardExtensionCandidatesCount)).BeginInit();
            cardExtensionCandidatesCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(chartDelayTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartDelayByDiscipline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartDelayByContractor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grdDelayAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvDelayAnalysis)).BeginInit();
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
            lblStateBanner.Text = "حالة تحليل التأخيرات: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Cards Setup
            SetupKpiCard(cardDelayedActivitiesCount, lblDelayedActivitiesCountTitle, lblDelayedActivitiesCountValue, "الأنشطة المتأخرة (Delayed)", "42");
            SetupKpiCard(cardTotalDelayDays, lblTotalDelayDaysTitle, lblTotalDelayDaysValue, "إجمالي أيام التأخير", "154 يوم");
            SetupKpiCard(cardCriticalDelaysCount, lblCriticalDelaysCountTitle, lblCriticalDelaysCountValue, "تأخيرات الأنشطة الحرجة", "18");
            SetupKpiCard(cardExtensionCandidatesCount, lblExtensionCandidatesCountTitle, lblExtensionCandidatesCountValue, "مرشحات تمديد الوقت (EOT)", "5");

            // Grid Setup
            grdDelayAnalysis.MainView = gvDelayAnalysis;
            grdDelayAnalysis.Name = "grdDelayAnalysis";
            grdDelayAnalysis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvDelayAnalysis });

            gvDelayAnalysis.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colActivity, colDelayReason, colDelayDays, colResponsible, colRecommendedAction
            });
            gvDelayAnalysis.GridControl = grdDelayAnalysis;
            gvDelayAnalysis.Name = "gvDelayAnalysis";

            colActivity.Caption = "النشاط (Activity)";
            colActivity.FieldName = "ActivityName";
            colActivity.Visible = true;
            colActivity.VisibleIndex = 0;

            colDelayReason.Caption = "سبب التأخير (Delay Reason)";
            colDelayReason.FieldName = "DelayReason";
            colDelayReason.Visible = true;
            colDelayReason.VisibleIndex = 1;

            colDelayDays.Caption = "أيام التأخير";
            colDelayDays.FieldName = "DelayDays";
            colDelayDays.Visible = true;
            colDelayDays.VisibleIndex = 2;

            colResponsible.Caption = "الجهة المسؤولة عن التأخير";
            colResponsible.FieldName = "Responsible";
            colResponsible.Visible = true;
            colResponsible.VisibleIndex = 3;

            colRecommendedAction.Caption = "الإجراء الموصى به (Action)";
            colRecommendedAction.FieldName = "RecommendedAction";
            colRecommendedAction.Visible = true;
            colRecommendedAction.VisibleIndex = 4;

            // Layout Control Main
            layoutControlMain.Controls.Add(cardDelayedActivitiesCount);
            layoutControlMain.Controls.Add(cardTotalDelayDays);
            layoutControlMain.Controls.Add(cardCriticalDelaysCount);
            layoutControlMain.Controls.Add(cardExtensionCandidatesCount);
            layoutControlMain.Controls.Add(chartDelayTrend);
            layoutControlMain.Controls.Add(chartDelayByDiscipline);
            layoutControlMain.Controls.Add(chartDelayByContractor);
            layoutControlMain.Controls.Add(grdDelayAnalysis);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 36);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 730);

            // ucDelayAnalysis
            Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControlMain);
            Controls.Add(pnlStateBanner);
            Name = "ucDelayAnalysis";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1200, 766);

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).EndInit();
            layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cardDelayedActivitiesCount)).EndInit();
            cardDelayedActivitiesCount.ResumeLayout(false);
            cardDelayedActivitiesCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardTotalDelayDays)).EndInit();
            cardTotalDelayDays.ResumeLayout(false);
            cardTotalDelayDays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardCriticalDelaysCount)).EndInit();
            cardCriticalDelaysCount.ResumeLayout(false);
            cardCriticalDelaysCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardExtensionCandidatesCount)).EndInit();
            cardExtensionCandidatesCount.ResumeLayout(false);
            cardExtensionCandidatesCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(chartDelayTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartDelayByDiscipline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartDelayByContractor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(grdDelayAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gvDelayAnalysis)).EndInit();
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

        private DevExpress.XtraEditors.PanelControl cardDelayedActivitiesCount;
        private DevExpress.XtraEditors.LabelControl lblDelayedActivitiesCountTitle;
        private DevExpress.XtraEditors.LabelControl lblDelayedActivitiesCountValue;

        private DevExpress.XtraEditors.PanelControl cardTotalDelayDays;
        private DevExpress.XtraEditors.LabelControl lblTotalDelayDaysTitle;
        private DevExpress.XtraEditors.LabelControl lblTotalDelayDaysValue;

        private DevExpress.XtraEditors.PanelControl cardCriticalDelaysCount;
        private DevExpress.XtraEditors.LabelControl lblCriticalDelaysCountTitle;
        private DevExpress.XtraEditors.LabelControl lblCriticalDelaysCountValue;

        private DevExpress.XtraEditors.PanelControl cardExtensionCandidatesCount;
        private DevExpress.XtraEditors.LabelControl lblExtensionCandidatesCountTitle;
        private DevExpress.XtraEditors.LabelControl lblExtensionCandidatesCountValue;

        private DevExpress.XtraCharts.ChartControl chartDelayTrend;
        private DevExpress.XtraCharts.ChartControl chartDelayByDiscipline;
        private DevExpress.XtraCharts.ChartControl chartDelayByContractor;

        private DevExpress.XtraGrid.GridControl grdDelayAnalysis;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDelayAnalysis;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colDelayReason;
        private DevExpress.XtraGrid.Columns.GridColumn colDelayDays;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsible;
        private DevExpress.XtraGrid.Columns.GridColumn colRecommendedAction;
    }
}
