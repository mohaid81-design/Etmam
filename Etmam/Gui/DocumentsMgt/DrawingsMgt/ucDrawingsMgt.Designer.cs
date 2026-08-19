namespace Etmam
{
    partial class ucDrawingsMgt
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
            pnlHeader = new DevExpress.XtraEditors.PanelControl();
            simpleButtonNew = new DevExpress.XtraEditors.SimpleButton();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            simpleButtonMain = new DevExpress.XtraEditors.SimpleButton();
            navigationFrameMain = new DevExpress.XtraBars.Navigation.NavigationFrame();
            navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)navigationFrameMain).BeginInit();
            navigationFrameMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(255, 128, 0);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.Controls.Add(simpleButtonNew);
            pnlHeader.Controls.Add(simpleButtonMain);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1256, 60);
            pnlHeader.TabIndex = 0;
            // 
            // simpleButtonNew
            // 
            simpleButtonNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            simpleButtonNew.Appearance.BackColor = Color.FromArgb(192, 255, 192);
            simpleButtonNew.Appearance.Options.UseBackColor = true;
            simpleButtonNew.ImageOptions.ImageIndex = 2;
            simpleButtonNew.ImageOptions.ImageList = svgImageCollection1;
            simpleButtonNew.ImageOptions.SvgImageSize = new Size(24, 24);
            simpleButtonNew.Location = new Point(1007, 12);
            simpleButtonNew.Name = "simpleButtonNew";
            simpleButtonNew.Size = new Size(232, 34);
            simpleButtonNew.TabIndex = 2;
            simpleButtonNew.Text = "طلب اعتماد مخطط جديد";
            simpleButtonNew.Click += simpleButtonNew_Click;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.ImageSize = new Size(24, 24);
            svgImageCollection1.Add("datalabels", "image://svgimages/dashboards/datalabels.svg");
            svgImageCollection1.Add("selecttable", "image://svgimages/richedit/selecttable.svg");
            svgImageCollection1.Add("addfile", "image://svgimages/outlook inspired/addfile.svg");
            svgImageCollection1.Add("new", "image://svgimages/actions/new.svg");
            svgImageCollection1.Add("actions_list", "image://svgimages/icon builder/actions_list.svg");
            // 
            // simpleButtonMain
            // 
            simpleButtonMain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            simpleButtonMain.Appearance.BackColor = Color.FromArgb(192, 255, 255);
            simpleButtonMain.Appearance.Options.UseBackColor = true;
            simpleButtonMain.ImageOptions.ImageIndex = 1;
            simpleButtonMain.ImageOptions.ImageList = svgImageCollection1;
            simpleButtonMain.ImageOptions.SvgImageSize = new Size(24, 24);
            simpleButtonMain.Location = new Point(762, 13);
            simpleButtonMain.Name = "simpleButtonMain";
            simpleButtonMain.Size = new Size(232, 34);
            simpleButtonMain.TabIndex = 1;
            simpleButtonMain.Text = "فتح سجل المخططات";
            simpleButtonMain.Click += simpleButtonMain_Click;
            // 
            // navigationFrameMain
            // 
            navigationFrameMain.Controls.Add(navigationPage1);
            navigationFrameMain.Controls.Add(navigationPage2);
            navigationFrameMain.Dock = DockStyle.Fill;
            navigationFrameMain.Location = new Point(0, 60);
            navigationFrameMain.Name = "navigationFrameMain";
            navigationFrameMain.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { navigationPage1, navigationPage2 });
            navigationFrameMain.SelectedPage = navigationPage1;
            navigationFrameMain.Size = new Size(1256, 512);
            navigationFrameMain.TabIndex = 1;
            navigationFrameMain.Text = "navigationFrameMain";
            navigationFrameMain.TransitionAnimationProperties.FrameCount = 100;
            navigationFrameMain.TransitionAnimationProperties.FrameInterval = 100;
            navigationFrameMain.TransitionType = DevExpress.Utils.Animation.Transitions.Fade;
            // 
            // navigationPage1
            // 
            navigationPage1.Caption = "navigationPage1";
            navigationPage1.ControlName = "XtraUserControl2";
            navigationPage1.Name = "navigationPage1";
            navigationPage1.Size = new Size(1256, 512);
            // 
            // navigationPage2
            // 
            navigationPage2.Caption = "navigationPage2";
            navigationPage2.Name = "navigationPage2";
            navigationPage2.Size = new Size(1256, 512);
            // 
            // ucDrawingsMgt
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(navigationFrameMain);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucDrawingsMgt";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1256, 572);
            Load += MainDrawingsControl_Load;
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)navigationFrameMain).EndInit();
            navigationFrameMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrameMain;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonMain;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNew;
    }
}
