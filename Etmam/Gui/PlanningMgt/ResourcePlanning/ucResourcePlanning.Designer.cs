namespace Etmam
{
    partial class ucResourcePlanning
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
            cardLabor = new DevExpress.XtraEditors.PanelControl();
            lblLaborTitle = new DevExpress.XtraEditors.LabelControl();
            lblLaborValue = new DevExpress.XtraEditors.LabelControl();

            cardEquipment = new DevExpress.XtraEditors.PanelControl();
            lblEquipmentTitle = new DevExpress.XtraEditors.LabelControl();
            lblEquipmentValue = new DevExpress.XtraEditors.LabelControl();

            cardMaterial = new DevExpress.XtraEditors.PanelControl();
            lblMaterialTitle = new DevExpress.XtraEditors.LabelControl();
            lblMaterialValue = new DevExpress.XtraEditors.LabelControl();

            cardProductivity = new DevExpress.XtraEditors.PanelControl();
            lblProductivityTitle = new DevExpress.XtraEditors.LabelControl();
            lblProductivityValue = new DevExpress.XtraEditors.LabelControl();

            // Charts
            chartResourceHistogram = new DevExpress.XtraCharts.ChartControl();
            chartLaborDistribution = new DevExpress.XtraCharts.ChartControl();
            chartEquipmentUtilization = new DevExpress.XtraCharts.ChartControl();

            // Grid
            grdResourcePlanning = new DevExpress.XtraGrid.GridControl();
            gvResourcePlanning = new DevExpress.XtraGrid.Views.Grid.GridView();
            colResource = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlannedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colActualQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colVariance = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cardLabor)).BeginInit();
            cardLabor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardEquipment)).BeginInit();
            cardEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardMaterial)).BeginInit();
            cardMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardProductivity)).BeginInit();
            cardProductivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(chartResourceHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartLaborDistribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartEquipmentUtilization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grdResourcePlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvResourcePlanning)).BeginInit();
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
            lblStateBanner.Text = "حالة تخطيط الموارد: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Cards Setup
            SetupKpiCard(cardLabor, lblLaborTitle, lblLaborValue, "العمالة المخططة (Labor Man-Hours)", "14,250 ساعة");
            SetupKpiCard(cardEquipment, lblEquipmentTitle, lblEquipmentValue, "المعدات والآليات (Equipment)", "85 معدة");
            SetupKpiCard(cardMaterial, lblMaterialTitle, lblMaterialValue, "المواد والمستلزمات (Material)", "312 بند");
            SetupKpiCard(cardProductivity, lblProductivityTitle, lblProductivityValue, "معدل الإنتاجية (Productivity)", "94.2%");

            // Grid Setup
            grdResourcePlanning.MainView = gvResourcePlanning;
            grdResourcePlanning.Name = "grdResourcePlanning";
            grdResourcePlanning.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvResourcePlanning });

            gvResourcePlanning.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colResource, colActivity, colPlannedQty, colActualQty, colVariance
            });
            gvResourcePlanning.GridControl = grdResourcePlanning;
            gvResourcePlanning.Name = "gvResourcePlanning";

            colResource.Caption = "المورد (Resource)";
            colResource.FieldName = "ResourceName";
            colResource.Visible = true;
            colResource.VisibleIndex = 0;

            colActivity.Caption = "النشاط المرتبط";
            colActivity.FieldName = "ActivityName";
            colActivity.Visible = true;
            colActivity.VisibleIndex = 1;

            colPlannedQty.Caption = "الكمية المخططة";
            colPlannedQty.FieldName = "PlannedQty";
            colPlannedQty.Visible = true;
            colPlannedQty.VisibleIndex = 2;

            colActualQty.Caption = "الكمية الفعلية";
            colActualQty.FieldName = "ActualQty";
            colActualQty.Visible = true;
            colActualQty.VisibleIndex = 3;

            colVariance.Caption = "الانحراف (Variance)";
            colVariance.FieldName = "Variance";
            colVariance.Visible = true;
            colVariance.VisibleIndex = 4;

            // Layout Control Main
            layoutControlMain.Controls.Add(cardLabor);
            layoutControlMain.Controls.Add(cardEquipment);
            layoutControlMain.Controls.Add(cardMaterial);
            layoutControlMain.Controls.Add(cardProductivity);
            layoutControlMain.Controls.Add(chartResourceHistogram);
            layoutControlMain.Controls.Add(chartLaborDistribution);
            layoutControlMain.Controls.Add(chartEquipmentUtilization);
            layoutControlMain.Controls.Add(grdResourcePlanning);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 36);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 730);

            // ucResourcePlanning
            Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControlMain);
            Controls.Add(pnlStateBanner);
            Name = "ucResourcePlanning";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1200, 766);

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).EndInit();
            layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cardLabor)).BeginInit();
            cardLabor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardEquipment)).BeginInit();
            cardEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardMaterial)).BeginInit();
            cardMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardProductivity)).BeginInit();
            cardProductivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(chartResourceHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartLaborDistribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chartEquipmentUtilization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grdResourcePlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gvResourcePlanning)).BeginInit();
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

        private DevExpress.XtraEditors.PanelControl cardLabor;
        private DevExpress.XtraEditors.LabelControl lblLaborTitle;
        private DevExpress.XtraEditors.LabelControl lblLaborValue;

        private DevExpress.XtraEditors.PanelControl cardEquipment;
        private DevExpress.XtraEditors.LabelControl lblEquipmentTitle;
        private DevExpress.XtraEditors.LabelControl lblEquipmentValue;

        private DevExpress.XtraEditors.PanelControl cardMaterial;
        private DevExpress.XtraEditors.LabelControl lblMaterialTitle;
        private DevExpress.XtraEditors.LabelControl lblMaterialValue;

        private DevExpress.XtraEditors.PanelControl cardProductivity;
        private DevExpress.XtraEditors.LabelControl lblProductivityTitle;
        private DevExpress.XtraEditors.LabelControl lblProductivityValue;

        private DevExpress.XtraCharts.ChartControl chartResourceHistogram;
        private DevExpress.XtraCharts.ChartControl chartLaborDistribution;
        private DevExpress.XtraCharts.ChartControl chartEquipmentUtilization;

        private DevExpress.XtraGrid.GridControl grdResourcePlanning;
        private DevExpress.XtraGrid.Views.Grid.GridView gvResourcePlanning;
        private DevExpress.XtraGrid.Columns.GridColumn colResource;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colPlannedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colActualQty;
        private DevExpress.XtraGrid.Columns.GridColumn colVariance;
    }
}
