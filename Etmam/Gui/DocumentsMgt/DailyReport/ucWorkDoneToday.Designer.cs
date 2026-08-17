using System.Drawing;
using System.Windows.Forms;

namespace Etmam
{
    partial class ucWorkDoneToday
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucWorkDoneToday));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiCopy = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            xtraTabControlWork = new DevExpress.XtraTab.XtraTabControl();
            tabStr = new DevExpress.XtraTab.XtraTabPage();
            ucGridStr = new ucWorkDoneCategoryGrid();
            tabArc = new DevExpress.XtraTab.XtraTabPage();
            ucGridArc = new ucWorkDoneCategoryGrid();
            tabMec = new DevExpress.XtraTab.XtraTabPage();
            ucGridMec = new ucWorkDoneCategoryGrid();
            tabElc = new DevExpress.XtraTab.XtraTabPage();
            ucGridElc = new ucWorkDoneCategoryGrid();
            tabOther = new DevExpress.XtraTab.XtraTabPage();
            ucGridOther = new ucWorkDoneCategoryGrid();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControlWork).BeginInit();
            xtraTabControlWork.SuspendLayout();
            tabStr.SuspendLayout();
            tabArc.SuspendLayout();
            tabMec.SuspendLayout();
            tabElc.SuspendLayout();
            tabOther.SuspendLayout();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = imageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiDelete, bbiCopy, barStaticItem1 });
            barManager1.MaxItemId = 4;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCopy, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiAdd
            // 
            bbiAdd.Caption = "إضافة";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.ImageIndex = 0;
            bbiAdd.Name = "bbiAdd";
            // 
            // bbiCopy
            // 
            bbiCopy.Caption = "نسخ من اليوم السابق";
            bbiCopy.Id = 2;
            bbiCopy.ImageOptions.ImageIndex = 9;
            bbiCopy.Name = "bbiCopy";
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 1;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.Name = "bbiDelete";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1280, 28);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 517);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1280, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 28);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 489);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1280, 28);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 489);
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "1_New.png");
            imageCollection1.Images.SetKeyName(1, "2_ReIssue.png");
            imageCollection1.Images.SetKeyName(2, "3_Save.png");
            imageCollection1.Images.SetKeyName(3, "4_Delete.png");
            imageCollection1.Images.SetKeyName(4, "5_Print.png");
            imageCollection1.Images.SetKeyName(5, "6_Search.png");
            imageCollection1.Images.SetKeyName(6, "refresh.png");
            imageCollection1.InsertImage(Properties.Resources.edit_16x16, "edit_16x16", typeof(Properties.Resources), 7);
            imageCollection1.Images.SetKeyName(7, "edit_16x16");
            imageCollection1.Images.SetKeyName(8, "6_Search.png");
            imageCollection1.InsertImage(Properties.Resources.sortbyinvoice_16x16, "sortbyinvoice_16x16", typeof(Properties.Resources), 9);
            imageCollection1.Images.SetKeyName(9, "sortbyinvoice_16x16");
            // 
            // barStaticItem1
            // 
            barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barStaticItem1.Caption = "العدد: 0";
            barStaticItem1.Id = 3;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // xtraTabControlWork
            // 
            xtraTabControlWork.AppearancePage.Header.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            xtraTabControlWork.AppearancePage.Header.Options.UseFont = true;
            xtraTabControlWork.AppearancePage.Header.Options.UseTextOptions = true;
            xtraTabControlWork.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            xtraTabControlWork.Dock = DockStyle.Fill;
            xtraTabControlWork.Location = new Point(0, 28);
            xtraTabControlWork.Name = "xtraTabControlWork";
            xtraTabControlWork.SelectedTabPage = tabStr;
            xtraTabControlWork.Size = new Size(1280, 489);
            xtraTabControlWork.TabIndex = 0;
            xtraTabControlWork.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tabStr, tabArc, tabMec, tabElc, tabOther });
            // 
            // tabStr
            // 
            tabStr.Controls.Add(ucGridStr);
            tabStr.Name = "tabStr";
            tabStr.Padding = new Padding(5);
            tabStr.Size = new Size(1278, 450);
            tabStr.TabPageWidth = 90;
            tabStr.Text = "إنشائي";
            // 
            // ucGridStr
            // 
            ucGridStr.Dock = DockStyle.Fill;
            ucGridStr.Location = new Point(5, 5);
            ucGridStr.Name = "ucGridStr";
            ucGridStr.Size = new Size(1268, 440);
            ucGridStr.TabIndex = 0;
            // 
            // tabArc
            // 
            tabArc.Controls.Add(ucGridArc);
            tabArc.Name = "tabArc";
            tabArc.Padding = new Padding(5);
            tabArc.Size = new Size(1278, 450);
            tabArc.TabPageWidth = 90;
            tabArc.Text = "معماري";
            // 
            // ucGridArc
            // 
            ucGridArc.Dock = DockStyle.Fill;
            ucGridArc.Location = new Point(5, 5);
            ucGridArc.Name = "ucGridArc";
            ucGridArc.Size = new Size(1268, 440);
            ucGridArc.TabIndex = 0;
            // 
            // tabMec
            // 
            tabMec.Controls.Add(ucGridMec);
            tabMec.Name = "tabMec";
            tabMec.Padding = new Padding(5);
            tabMec.Size = new Size(1278, 450);
            tabMec.TabPageWidth = 90;
            tabMec.Text = "ميكانيكا";
            // 
            // ucGridMec
            // 
            ucGridMec.Dock = DockStyle.Fill;
            ucGridMec.Location = new Point(5, 5);
            ucGridMec.Name = "ucGridMec";
            ucGridMec.Size = new Size(1268, 440);
            ucGridMec.TabIndex = 0;
            // 
            // tabElc
            // 
            tabElc.Controls.Add(ucGridElc);
            tabElc.Name = "tabElc";
            tabElc.Padding = new Padding(5);
            tabElc.Size = new Size(1278, 450);
            tabElc.TabPageWidth = 90;
            tabElc.Text = "كهرباء";
            // 
            // ucGridElc
            // 
            ucGridElc.Dock = DockStyle.Fill;
            ucGridElc.Location = new Point(5, 5);
            ucGridElc.Name = "ucGridElc";
            ucGridElc.Size = new Size(1268, 440);
            ucGridElc.TabIndex = 0;
            // 
            // tabOther
            // 
            tabOther.Controls.Add(ucGridOther);
            tabOther.Name = "tabOther";
            tabOther.Padding = new Padding(5);
            tabOther.Size = new Size(1278, 450);
            tabOther.TabPageWidth = 80;
            tabOther.Text = "أخرى";
            // 
            // ucGridOther
            // 
            ucGridOther.Dock = DockStyle.Fill;
            ucGridOther.Location = new Point(5, 5);
            ucGridOther.Name = "ucGridOther";
            ucGridOther.Size = new Size(1268, 440);
            ucGridOther.TabIndex = 0;
            // 
            // ucWorkDoneToday
            // 
            Appearance.Font = new Font("Cairo", 8.5F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(xtraTabControlWork);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucWorkDoneToday";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1280, 517);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControlWork).EndInit();
            xtraTabControlWork.ResumeLayout(false);
            tabStr.ResumeLayout(false);
            tabArc.ResumeLayout(false);
            tabMec.ResumeLayout(false);
            tabElc.ResumeLayout(false);
            tabOther.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiCopy;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;

        private DevExpress.XtraTab.XtraTabControl xtraTabControlWork;
        private DevExpress.XtraTab.XtraTabPage tabStr;
        private ucWorkDoneCategoryGrid ucGridStr;
        private DevExpress.XtraTab.XtraTabPage tabArc;
        private ucWorkDoneCategoryGrid ucGridArc;
        private DevExpress.XtraTab.XtraTabPage tabMec;
        private ucWorkDoneCategoryGrid ucGridMec;
        private DevExpress.XtraTab.XtraTabPage tabElc;
        private ucWorkDoneCategoryGrid ucGridElc;
        private DevExpress.XtraTab.XtraTabPage tabOther;
        private ucWorkDoneCategoryGrid ucGridOther;
    }
}
