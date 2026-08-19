namespace Etmam
{
    partial class ucLookAheadPlanning
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
            cardActivitiesDue = new DevExpress.XtraEditors.PanelControl();
            lblActivitiesDueTitle = new DevExpress.XtraEditors.LabelControl();
            lblActivitiesDueValue = new DevExpress.XtraEditors.LabelControl();

            cardOverdue = new DevExpress.XtraEditors.PanelControl();
            lblOverdueTitle = new DevExpress.XtraEditors.LabelControl();
            lblOverdueValue = new DevExpress.XtraEditors.LabelControl();

            cardReadyToStart = new DevExpress.XtraEditors.PanelControl();
            lblReadyToStartTitle = new DevExpress.XtraEditors.LabelControl();
            lblReadyToStartValue = new DevExpress.XtraEditors.LabelControl();

            // Tabs for 2, 4, 6 Weeks Look Ahead
            tabLookAhead = new DevExpress.XtraTab.XtraTabControl();
            
            tp2Weeks = new DevExpress.XtraTab.XtraTabPage();
            grd2Weeks = new DevExpress.XtraGrid.GridControl();
            gv2Weeks = new DevExpress.XtraGrid.Views.Grid.GridView();

            tp4Weeks = new DevExpress.XtraTab.XtraTabPage();
            grd4Weeks = new DevExpress.XtraGrid.GridControl();
            gv4Weeks = new DevExpress.XtraGrid.Views.Grid.GridView();

            tp6Weeks = new DevExpress.XtraTab.XtraTabPage();
            grd6Weeks = new DevExpress.XtraGrid.GridControl();
            gv6Weeks = new DevExpress.XtraGrid.Views.Grid.GridView();

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).BeginInit();
            pnlStateBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(cardActivitiesDue)).BeginInit();
            cardActivitiesDue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardOverdue)).BeginInit();
            cardOverdue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(cardReadyToStart)).BeginInit();
            cardReadyToStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(tabLookAhead)).BeginInit();
            tabLookAhead.SuspendLayout();
            tp2Weeks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grd2Weeks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gv2Weeks)).BeginInit();
            tp4Weeks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grd4Weeks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gv4Weeks)).BeginInit();
            tp6Weeks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grd6Weeks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gv6Weeks)).BeginInit();
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
            lblStateBanner.Text = "حالة Look Ahead: جاهز";

            svgStateBannerIcon.Location = new System.Drawing.Point(10, 6);
            svgStateBannerIcon.Name = "svgStateBannerIcon";
            svgStateBannerIcon.Size = new System.Drawing.Size(24, 24);

            btnRetry.Location = new System.Drawing.Point(1100, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new System.Drawing.Size(85, 26);
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;

            // Cards Setup
            SetupKpiCard(cardActivitiesDue, lblActivitiesDueTitle, lblActivitiesDueValue, "أنشطة استحقاق للفترة (Activities Due)", "28");
            SetupKpiCard(cardOverdue, lblOverdueTitle, lblOverdueValue, "أنشطة متأخرة عن موعدها (Overdue)", "6");
            SetupKpiCard(cardReadyToStart, lblReadyToStartTitle, lblReadyToStartValue, "أنشطة جاهزة للبدء (Ready to Start)", "14");

            // Setup Grids in Tab Pages
            SetupGridColumns(grd2Weeks, gv2Weeks);
            tp2Weeks.Controls.Add(grd2Weeks);
            tp2Weeks.Text = "خطة أسبوعين (2 Weeks Look Ahead)";
            grd2Weeks.Dock = System.Windows.Forms.DockStyle.Fill;

            SetupGridColumns(grd4Weeks, gv4Weeks);
            tp4Weeks.Controls.Add(grd4Weeks);
            tp4Weeks.Text = "خطة 4 أسابيع (4 Weeks Look Ahead)";
            grd4Weeks.Dock = System.Windows.Forms.DockStyle.Fill;

            SetupGridColumns(grd6Weeks, gv6Weeks);
            tp6Weeks.Controls.Add(grd6Weeks);
            tp6Weeks.Text = "خطة 6 أسابيع (6 Weeks Look Ahead)";
            grd6Weeks.Dock = System.Windows.Forms.DockStyle.Fill;

            tabLookAhead.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tp2Weeks, tp4Weeks, tp6Weeks });

            // Layout Control Main
            layoutControlMain.Controls.Add(cardActivitiesDue);
            layoutControlMain.Controls.Add(cardOverdue);
            layoutControlMain.Controls.Add(cardReadyToStart);
            layoutControlMain.Controls.Add(tabLookAhead);
            layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlMain.Location = new System.Drawing.Point(0, 36);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.Root = layoutControlGroupRoot;
            layoutControlMain.Size = new System.Drawing.Size(1200, 730);

            // ucLookAheadPlanning
            Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControlMain);
            Controls.Add(pnlStateBanner);
            Name = "ucLookAheadPlanning";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(1200, 766);

            ((System.ComponentModel.ISupportInitialize)(pnlStateBanner)).EndInit();
            pnlStateBanner.ResumeLayout(false);
            pnlStateBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(svgStateBannerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlMain)).EndInit();
            layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(cardActivitiesDue)).EndInit();
            cardActivitiesDue.ResumeLayout(false);
            cardActivitiesDue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardOverdue)).EndInit();
            cardOverdue.ResumeLayout(false);
            cardOverdue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(cardReadyToStart)).EndInit();
            cardReadyToStart.ResumeLayout(false);
            cardReadyToStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(tabLookAhead)).EndInit();
            tabLookAhead.ResumeLayout(false);
            tp2Weeks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grd2Weeks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gv2Weeks)).EndInit();
            tp4Weeks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grd4Weeks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gv4Weeks)).EndInit();
            tp6Weeks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grd6Weeks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gv6Weeks)).EndInit();
            ResumeLayout(false);
        }

        private void SetupKpiCard(DevExpress.XtraEditors.PanelControl card, DevExpress.XtraEditors.LabelControl titleLbl, DevExpress.XtraEditors.LabelControl valLbl, string titleText, string valText)
        {
            card.Controls.Add(valLbl);
            card.Controls.Add(titleLbl);
            card.Size = new System.Drawing.Size(260, 70);

            titleLbl.Appearance.Font = new System.Drawing.Font("Cairo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            titleLbl.Appearance.Options.UseFont = true;
            titleLbl.Dock = System.Windows.Forms.DockStyle.Top;
            titleLbl.Text = titleText;

            valLbl.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            valLbl.Appearance.Options.UseFont = true;
            valLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            valLbl.Text = valText;
        }

        private void SetupGridColumns(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            grd.MainView = gv;
            grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gv });

            DevExpress.XtraGrid.Columns.GridColumn colAct = new DevExpress.XtraGrid.Columns.GridColumn { Caption = "النشاط (Activity)", FieldName = "Activity", Visible = true, VisibleIndex = 0 };
            DevExpress.XtraGrid.Columns.GridColumn colPS = new DevExpress.XtraGrid.Columns.GridColumn { Caption = "تاريخ البداية المخطط", FieldName = "PlannedStart", Visible = true, VisibleIndex = 1 };
            DevExpress.XtraGrid.Columns.GridColumn colPF = new DevExpress.XtraGrid.Columns.GridColumn { Caption = "تاريخ النهاية المخطط", FieldName = "PlannedFinish", Visible = true, VisibleIndex = 2 };
            DevExpress.XtraGrid.Columns.GridColumn colResp = new DevExpress.XtraGrid.Columns.GridColumn { Caption = "المسؤول (Responsible)", FieldName = "Responsible", Visible = true, VisibleIndex = 3 };
            DevExpress.XtraGrid.Columns.GridColumn colReq = new DevExpress.XtraGrid.Columns.GridColumn { Caption = "الإجراءات المطلوبة (Required Actions)", FieldName = "RequiredActions", Visible = true, VisibleIndex = 4 };
            DevExpress.XtraGrid.Columns.GridColumn colConst = new DevExpress.XtraGrid.Columns.GridColumn { Caption = "المعوقات والقيود (Constraints)", FieldName = "Constraints", Visible = true, VisibleIndex = 5 };
            DevExpress.XtraGrid.Columns.GridColumn colSt = new DevExpress.XtraGrid.Columns.GridColumn { Caption = "الحالة", FieldName = "Status", Visible = true, VisibleIndex = 6 };

            gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colAct, colPS, colPF, colResp, colReq, colConst, colSt });
            gv.GridControl = grd;
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlStateBanner;
        private DevExpress.XtraEditors.LabelControl lblStateBanner;
        private DevExpress.XtraEditors.SvgImageBox svgStateBannerIcon;
        private DevExpress.XtraEditors.SimpleButton btnRetry;

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;

        private DevExpress.XtraEditors.PanelControl cardActivitiesDue;
        private DevExpress.XtraEditors.LabelControl lblActivitiesDueTitle;
        private DevExpress.XtraEditors.LabelControl lblActivitiesDueValue;

        private DevExpress.XtraEditors.PanelControl cardOverdue;
        private DevExpress.XtraEditors.LabelControl lblOverdueTitle;
        private DevExpress.XtraEditors.LabelControl lblOverdueValue;

        private DevExpress.XtraEditors.PanelControl cardReadyToStart;
        private DevExpress.XtraEditors.LabelControl lblReadyToStartTitle;
        private DevExpress.XtraEditors.LabelControl lblReadyToStartValue;

        private DevExpress.XtraTab.XtraTabControl tabLookAhead;
        private DevExpress.XtraTab.XtraTabPage tp2Weeks;
        private DevExpress.XtraGrid.GridControl grd2Weeks;
        private DevExpress.XtraGrid.Views.Grid.GridView gv2Weeks;

        private DevExpress.XtraTab.XtraTabPage tp4Weeks;
        private DevExpress.XtraGrid.GridControl grd4Weeks;
        private DevExpress.XtraGrid.Views.Grid.GridView gv4Weeks;

        private DevExpress.XtraTab.XtraTabPage tp6Weeks;
        private DevExpress.XtraGrid.GridControl grd6Weeks;
        private DevExpress.XtraGrid.Views.Grid.GridView gv6Weeks;
    }
}
