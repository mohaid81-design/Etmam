namespace Etmam
{
    partial class ucPriceQuotationMain
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
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiPriceQutation = new DevExpress.XtraBars.BarLargeButtonItem();
            bbiPriceQutationCompare = new DevExpress.XtraBars.BarLargeButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)navigationFrame1).BeginInit();
            navigationFrame1.SuspendLayout();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1, bbiPriceQutation, bbiPriceQutationCompare });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 5;
            // 
            // bar2
            // 
            bar2.BarItemVertIndent = 10;
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Right;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbiPriceQutation), new DevExpress.XtraBars.LinkPersistInfo(bbiPriceQutationCompare) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MinHeight = 80;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.RotateWhenVertical = false;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // bbiPriceQutation
            // 
            bbiPriceQutation.Caption = "عرض السعر";
            bbiPriceQutation.Id = 3;
            bbiPriceQutation.ImageOptions.Image = Properties.Resources.listbox_16x16;
            bbiPriceQutation.ImageOptions.LargeImage = Properties.Resources.listbox_32x323;
            bbiPriceQutation.Name = "bbiPriceQutation";
            // 
            // bbiPriceQutationCompare
            // 
            bbiPriceQutationCompare.Caption = "مقارنة الأسعار";
            bbiPriceQutationCompare.Id = 4;
            bbiPriceQutationCompare.ImageOptions.Image = Properties.Resources.listbox_16x161;
            bbiPriceQutationCompare.ImageOptions.LargeImage = Properties.Resources.listbox_32x324;
            bbiPriceQutationCompare.Name = "bbiPriceQutationCompare";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1320, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 602);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1320, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 602);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1236, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(84, 602);
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 0;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // navigationFrame1
            // 
            navigationFrame1.Controls.Add(navigationPage1);
            navigationFrame1.Controls.Add(navigationPage2);
            navigationFrame1.Dock = DockStyle.Fill;
            navigationFrame1.Location = new Point(0, 0);
            navigationFrame1.Name = "navigationFrame1";
            navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { navigationPage1, navigationPage2 });
            navigationFrame1.SelectedPage = navigationPage2;
            navigationFrame1.Size = new Size(1236, 602);
            navigationFrame1.TabIndex = 4;
            navigationFrame1.Text = "navigationFrame1";
            navigationFrame1.TransitionAnimationProperties.FrameCount = 100;
            navigationFrame1.TransitionAnimationProperties.FrameInterval = 1000;
            navigationFrame1.TransitionType = DevExpress.Utils.Animation.Transitions.Fade;
            // 
            // navigationPage1
            // 
            navigationPage1.Caption = "navigationPage1";
            navigationPage1.Name = "navigationPage1";
            navigationPage1.Size = new Size(1236, 602);
            // 
            // navigationPage2
            // 
            navigationPage2.Caption = "navigationPage2";
            navigationPage2.Name = "navigationPage2";
            navigationPage2.Size = new Size(1236, 602);
            // 
            // ucPriceQuotationMain
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(navigationFrame1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucPriceQuotationMain";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1320, 602);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)navigationFrame1).EndInit();
            navigationFrame1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarLargeButtonItem bbiPriceQutation;
        private DevExpress.XtraBars.BarLargeButtonItem bbiPriceQutationCompare;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
    }
}
