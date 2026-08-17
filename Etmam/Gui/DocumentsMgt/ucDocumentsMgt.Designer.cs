namespace Etmam
{
    partial class ucDocumentsMgt
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
            tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            nbTitle = new DevExpress.XtraBars.Navigation.NavButton();
            navButton2 = new DevExpress.XtraBars.Navigation.NavButton();
            nvDwgAR = new DevExpress.XtraBars.Navigation.NavButton();
            nbMAR = new DevExpress.XtraBars.Navigation.NavButton();
            nbMIR = new DevExpress.XtraBars.Navigation.NavButton();
            nbCIR = new DevExpress.XtraBars.Navigation.NavButton();
            nbDailyReport = new DevExpress.XtraBars.Navigation.NavButton();
            nbTransmittals = new DevExpress.XtraBars.Navigation.NavButton();
            nbDashboard = new DevExpress.XtraBars.Navigation.NavButton();
            roundedSkinPanel1 = new DevExpress.XtraEditors.RoundedSkinPanel();
            navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            ((System.ComponentModel.ISupportInitialize)tileNavPane1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).BeginInit();
            roundedSkinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)navigationFrame1).BeginInit();
            SuspendLayout();
            // 
            // tileNavPane1
            // 
            tileNavPane1.AllowGlyphSkinning = true;
            tileNavPane1.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            tileNavPane1.Appearance.Options.UseFont = true;
            tileNavPane1.AppearanceHovered.BackColor = Color.FromArgb(225, 245, 245);
            tileNavPane1.AppearanceHovered.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            tileNavPane1.AppearanceHovered.ForeColor = Color.FromArgb(13, 131, 135);
            tileNavPane1.AppearanceHovered.Options.UseBackColor = true;
            tileNavPane1.AppearanceHovered.Options.UseFont = true;
            tileNavPane1.AppearanceHovered.Options.UseForeColor = true;
            tileNavPane1.AppearanceSelected.BackColor = Color.White;
            tileNavPane1.AppearanceSelected.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            tileNavPane1.AppearanceSelected.ForeColor = Color.FromArgb(13, 131, 135);
            tileNavPane1.AppearanceSelected.Options.UseBackColor = true;
            tileNavPane1.AppearanceSelected.Options.UseFont = true;
            tileNavPane1.AppearanceSelected.Options.UseForeColor = true;
            tileNavPane1.Buttons.Add(nbTitle);
            tileNavPane1.Buttons.Add(navButton2);
            tileNavPane1.Buttons.Add(nvDwgAR);
            tileNavPane1.Buttons.Add(nbMAR);
            tileNavPane1.Buttons.Add(nbMIR);
            tileNavPane1.Buttons.Add(nbCIR);
            tileNavPane1.Buttons.Add(nbTransmittals);
            tileNavPane1.Buttons.Add(nbDailyReport);
            tileNavPane1.Buttons.Add(nbDashboard);
            // 
            // tileNavCategory1
            // 
            tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = Color.Empty;
            tileNavPane1.Dock = DockStyle.Top;
            tileNavPane1.Location = new Point(0, 0);
            tileNavPane1.Name = "tileNavPane1";
            tileNavPane1.Size = new Size(1241, 55);
            tileNavPane1.TabIndex = 0;
            tileNavPane1.Text = "tileNavPane1";
            // 
            // nbTitle
            // 
            nbTitle.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            nbTitle.Appearance.Font = new Font("Cairo", 10F, FontStyle.Bold);
            nbTitle.Appearance.ForeColor = Color.White;
            nbTitle.Appearance.Options.UseFont = true;
            nbTitle.Appearance.Options.UseForeColor = true;
            nbTitle.AppearanceDisabled.Font = new Font("Cairo", 12F, FontStyle.Bold);
            nbTitle.AppearanceDisabled.Options.UseFont = true;
            nbTitle.AppearanceHovered.BackColor = Color.Transparent;
            nbTitle.AppearanceHovered.Font = new Font("Cairo", 12F, FontStyle.Bold);
            nbTitle.AppearanceHovered.ForeColor = Color.White;
            nbTitle.AppearanceHovered.Options.UseBackColor = true;
            nbTitle.AppearanceHovered.Options.UseFont = true;
            nbTitle.AppearanceHovered.Options.UseForeColor = true;
            nbTitle.AppearanceSelected.BackColor = Color.Transparent;
            nbTitle.AppearanceSelected.Font = new Font("Cairo", 12F, FontStyle.Bold);
            nbTitle.AppearanceSelected.ForeColor = Color.White;
            nbTitle.AppearanceSelected.Options.UseBackColor = true;
            nbTitle.AppearanceSelected.Options.UseFont = true;
            nbTitle.AppearanceSelected.Options.UseForeColor = true;
            nbTitle.Caption = "إدارة التقديمات";
            nbTitle.ImageOptions.Image = Properties.Resources.Documents;
            nbTitle.Name = "nbTitle";
            nbTitle.Padding = new Padding(20, 0, 20, 0);
            // 
            // navButton2
            // 
            navButton2.Caption = "Main Menu";
            navButton2.Name = "navButton2";
            navButton2.Visible = false;
            // 
            // nvDwgAR
            // 
            nvDwgAR.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            nvDwgAR.Caption = "إدارة المخططات";
            nvDwgAR.ImageOptions.Image = Properties.Resources.Drawings;
            nvDwgAR.Name = "nvDwgAR";
            nvDwgAR.Padding = new Padding(10, 0, 10, 0);
            // 
            // nbMAR
            // 
            nbMAR.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            nbMAR.Caption = "اعتماد المواد";
            nbMAR.ImageOptions.Image = Properties.Resources.MAR;
            nbMAR.Name = "nbMAR";
            nbMAR.Padding = new Padding(10, 0, 10, 0);
            // 
            // nbMIR
            // 
            nbMIR.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            nbMIR.Caption = "فحص المواد";
            nbMIR.ImageOptions.Image = Properties.Resources.MIR;
            nbMIR.Name = "nbMIR";
            nbMIR.Padding = new Padding(10, 0, 10, 0);
            // 
            // nbCIR
            // 
            nbCIR.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            nbCIR.Caption = "فحص الأعمال";
            nbCIR.ImageOptions.Image = Properties.Resources.CIR;
            nbCIR.Name = "nbCIR";
            nbCIR.Padding = new Padding(10, 0, 10, 0);
            // 
            // nbDailyReport
            // 
            nbDailyReport.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            nbDailyReport.Caption = "التقرير اليومي";
            nbDailyReport.ImageOptions.Image = Properties.Resources.Daily_Report;
            nbDailyReport.Name = "nbDailyReport";
            nbDailyReport.Padding = new Padding(10, 0, 10, 0);
            // 
            // nbDashboard
            // 
            nbDashboard.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            nbDashboard.Caption = "الاشعارات";
            nbDashboard.ImageOptions.Image = Properties.Resources.Dashboard;
            nbDashboard.Name = "nbDashboard";
            nbDashboard.Padding = new Padding(10, 0, 10, 0);
            // 
            // nbTransmittals
            // 
            nbTransmittals.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            nbTransmittals.Caption = "المراسلات (Transmittals)";
            //nbTransmittals.ImageOptions.Image = Properties.Resources.Correspondence; // Assuming this exists or using a generic one
            nbTransmittals.Name = "nbTransmittals";
            nbTransmittals.Padding = new Padding(10, 0, 10, 0);
            // 
            // roundedSkinPanel1
            // 
            roundedSkinPanel1.Controls.Add(navigationFrame1);
            roundedSkinPanel1.Dock = DockStyle.Fill;
            roundedSkinPanel1.Location = new Point(0, 55);
            roundedSkinPanel1.Name = "roundedSkinPanel1";
            roundedSkinPanel1.Size = new Size(1241, 619);
            roundedSkinPanel1.TabIndex = 1;
            roundedSkinPanel1.Text = "roundedSkinPanel1";
            // 
            // navigationFrame1
            // 
            navigationFrame1.Dock = DockStyle.Fill;
            navigationFrame1.Location = new Point(0, 0);
            navigationFrame1.Name = "navigationFrame1";
            navigationFrame1.Size = new Size(1241, 619);
            navigationFrame1.TabIndex = 0;
            navigationFrame1.Text = "navigationFrame1";
            navigationFrame1.TransitionAnimationProperties.FrameCount = 100;
            navigationFrame1.TransitionAnimationProperties.FrameInterval = 1000;
            navigationFrame1.TransitionType = DevExpress.Utils.Animation.Transitions.Fade;
            // 
            // ucDocumentsMgt
            // 
            Appearance.Font = new Font("Cairo", 8.5F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundedSkinPanel1);
            Controls.Add(tileNavPane1);
            Name = "ucDocumentsMgt";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1241, 674);
            ((System.ComponentModel.ISupportInitialize)tileNavPane1).EndInit();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).EndInit();
            roundedSkinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)navigationFrame1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton navButton2;
        private DevExpress.XtraBars.Navigation.NavButton nvDwgAR;
        private DevExpress.XtraBars.Navigation.NavButton nbMAR;
        private DevExpress.XtraBars.Navigation.NavButton nbMIR;
        private DevExpress.XtraBars.Navigation.NavButton nbCIR;
        private DevExpress.XtraBars.Navigation.NavButton nbDailyReport;
        private DevExpress.XtraBars.Navigation.NavButton nbTitle;
        private DevExpress.XtraEditors.RoundedSkinPanel roundedSkinPanel1;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavButton nbDashboard;
        private DevExpress.XtraBars.Navigation.NavButton nbTransmittals;
    }
}

