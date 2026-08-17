namespace Etmam
{
    partial class ucInventoryMgt
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucInventoryMgt));
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement10 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement11 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement12 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement13 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement14 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement15 = new DevExpress.XtraEditors.TileItemElement();
            tbMain = new DevExpress.XtraBars.Navigation.TileBar();
            tbgInventory = new DevExpress.XtraBars.Navigation.TileBarGroup();
            tbiStore = new DevExpress.XtraBars.Navigation.TileBarItem();
            tbiItems = new DevExpress.XtraBars.Navigation.TileBarItem();
            itbMaterialReceive = new DevExpress.XtraBars.Navigation.TileBarItem();
            tbiMaterialIssued = new DevExpress.XtraBars.Navigation.TileBarItem();
            tbiMaterialTrasfare = new DevExpress.XtraBars.Navigation.TileBarItem();
            tbiPurchaseReturn = new DevExpress.XtraBars.Navigation.TileBarItem();
            tbiMaterialIssueReturn = new DevExpress.XtraBars.Navigation.TileBarItem();
            tbiInventoryReports = new DevExpress.XtraBars.Navigation.TileBarItem();
            nfInventory = new DevExpress.XtraBars.Navigation.NavigationFrame();
            documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)nfInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)documentManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // tbMain
            // 
            tbMain.Dock = DockStyle.Top;
            tbMain.DropDownOptions.BeakColor = Color.Empty;
            tbMain.Groups.Add(tbgInventory);
            tbMain.ItemPadding = new Padding(16, 6, 16, 6);
            tbMain.Location = new Point(0, 0);
            tbMain.MaxId = 9;
            tbMain.Name = "tbMain";
            tbMain.Padding = new Padding(16, 6, 16, 6);
            tbMain.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            tbMain.Size = new Size(1404, 100);
            tbMain.TabIndex = 0;
            tbMain.Text = "tileBar1";
            // 
            // tbgInventory
            // 
            tbgInventory.Items.Add(tbiStore);
            tbgInventory.Items.Add(tbiItems);
            tbgInventory.Items.Add(itbMaterialReceive);
            tbgInventory.Items.Add(tbiMaterialIssued);
            tbgInventory.Items.Add(tbiMaterialTrasfare);
            tbgInventory.Items.Add(tbiPurchaseReturn);
            tbgInventory.Items.Add(tbiMaterialIssueReturn);
            tbgInventory.Items.Add(tbiInventoryReports);
            tbgInventory.Name = "tbgInventory";
            // 
            // tbiStore
            // 
            tbiStore.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage");
            tileItemElement1.ImageOptions.SvgImageSize = new Size(28, 28);
            tileItemElement1.Text = "المخازن";
            tileItemElement2.Appearance.Normal.Font = new Font("Cairo", 8.5F, FontStyle.Underline);
            tileItemElement2.Appearance.Normal.Options.UseFont = true;
            tileItemElement2.Text = "0";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tbiStore.Elements.Add(tileItemElement1);
            tbiStore.Elements.Add(tileItemElement2);
            tbiStore.Id = 1;
            tbiStore.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            tbiStore.Name = "tbiStore";
            // 
            // tbiItems
            // 
            tbiItems.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement3.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage1");
            tileItemElement3.ImageOptions.SvgImageSize = new Size(28, 28);
            tileItemElement3.Text = "الأصناف";
            tileItemElement4.Appearance.Normal.Font = new Font("Cairo", 8.5F, FontStyle.Underline);
            tileItemElement4.Appearance.Normal.Options.UseFont = true;
            tileItemElement4.Text = "0";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tbiItems.Elements.Add(tileItemElement3);
            tbiItems.Elements.Add(tileItemElement4);
            tbiItems.Id = 2;
            tbiItems.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            tbiItems.Name = "tbiItems";
            // 
            // itbMaterialReceive
            // 
            itbMaterialReceive.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement5.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage2");
            tileItemElement5.ImageOptions.SvgImageSize = new Size(28, 28);
            tileItemElement5.Text = "إذن إستلام";
            tileItemElement6.Appearance.Normal.Font = new Font("Cairo", 8.5F, FontStyle.Underline);
            tileItemElement6.Appearance.Normal.Options.UseFont = true;
            tileItemElement6.Text = "0";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            itbMaterialReceive.Elements.Add(tileItemElement5);
            itbMaterialReceive.Elements.Add(tileItemElement6);
            itbMaterialReceive.Id = 3;
            itbMaterialReceive.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            itbMaterialReceive.Name = "itbMaterialReceive";
            // 
            // tbiMaterialIssued
            // 
            tbiMaterialIssued.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement7.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage3");
            tileItemElement7.ImageOptions.SvgImageSize = new Size(28, 28);
            tileItemElement7.Text = "إذن صرف";
            tileItemElement8.Appearance.Normal.Font = new Font("Cairo", 8.5F, FontStyle.Underline);
            tileItemElement8.Appearance.Normal.Options.UseFont = true;
            tileItemElement8.Text = "0";
            tileItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tbiMaterialIssued.Elements.Add(tileItemElement7);
            tbiMaterialIssued.Elements.Add(tileItemElement8);
            tbiMaterialIssued.Id = 4;
            tbiMaterialIssued.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            tbiMaterialIssued.Name = "tbiMaterialIssued";
            // 
            // tbiMaterialTrasfare
            // 
            tbiMaterialTrasfare.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement9.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage4");
            tileItemElement9.ImageOptions.SvgImageSize = new Size(28, 28);
            tileItemElement9.Text = "تحويل بين المخازن";
            tileItemElement10.Appearance.Normal.Font = new Font("Cairo", 8.5F, FontStyle.Underline);
            tileItemElement10.Appearance.Normal.Options.UseFont = true;
            tileItemElement10.Text = "0";
            tileItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tbiMaterialTrasfare.Elements.Add(tileItemElement9);
            tbiMaterialTrasfare.Elements.Add(tileItemElement10);
            tbiMaterialTrasfare.Id = 5;
            tbiMaterialTrasfare.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            tbiMaterialTrasfare.Name = "tbiMaterialTrasfare";
            // 
            // tbiPurchaseReturn
            // 
            tbiPurchaseReturn.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement11.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage5");
            tileItemElement11.ImageOptions.SvgImageSize = new Size(28, 28);
            tileItemElement11.Text = "مرتجع مشتريات";
            tileItemElement12.Appearance.Normal.Font = new Font("Cairo", 8.5F, FontStyle.Underline);
            tileItemElement12.Appearance.Normal.Options.UseFont = true;
            tileItemElement12.Text = "0";
            tileItemElement12.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tbiPurchaseReturn.Elements.Add(tileItemElement11);
            tbiPurchaseReturn.Elements.Add(tileItemElement12);
            tbiPurchaseReturn.Id = 6;
            tbiPurchaseReturn.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            tbiPurchaseReturn.Name = "tbiPurchaseReturn";
            // 
            // tbiMaterialIssueReturn
            // 
            tbiMaterialIssueReturn.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement13.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage6");
            tileItemElement13.ImageOptions.SvgImageSize = new Size(28, 28);
            tileItemElement13.Text = "مرتجع صرف";
            tileItemElement14.Appearance.Normal.Font = new Font("Cairo", 8.5F, FontStyle.Underline);
            tileItemElement14.Appearance.Normal.Options.UseFont = true;
            tileItemElement14.Text = "0";
            tileItemElement14.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tbiMaterialIssueReturn.Elements.Add(tileItemElement13);
            tbiMaterialIssueReturn.Elements.Add(tileItemElement14);
            tbiMaterialIssueReturn.Id = 7;
            tbiMaterialIssueReturn.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            tbiMaterialIssueReturn.Name = "tbiMaterialIssueReturn";
            // 
            // tbiInventoryReports
            // 
            tbiInventoryReports.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement15.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage7");
            tileItemElement15.ImageOptions.SvgImageSize = new Size(28, 28);
            tileItemElement15.Text = "تقارير المخزون";
            tbiInventoryReports.Elements.Add(tileItemElement15);
            tbiInventoryReports.Id = 8;
            tbiInventoryReports.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            tbiInventoryReports.Name = "tbiInventoryReports";
            // 
            // nfInventory
            // 
            nfInventory.Dock = DockStyle.Fill;
            nfInventory.Location = new Point(0, 100);
            nfInventory.Name = "nfInventory";
            nfInventory.Size = new Size(1404, 582);
            nfInventory.TabIndex = 1;
            nfInventory.Text = "navigationFrame1";
            // 
            // documentManager1
            // 
            documentManager1.ContainerControl = this;
            documentManager1.View = tabbedView1;
            documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { tabbedView1 });
            // 
            // tabbedView1
            // 
            tabbedView1.AppearancePage.Header.BackColor = Color.FromArgb(232, 240, 252);
            tabbedView1.AppearancePage.Header.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            tabbedView1.AppearancePage.Header.ForeColor = Color.FromArgb(50, 72, 105);
            tabbedView1.AppearancePage.Header.Options.UseBackColor = true;
            tabbedView1.AppearancePage.Header.Options.UseFont = true;
            tabbedView1.AppearancePage.Header.Options.UseForeColor = true;
            tabbedView1.AppearancePage.HeaderActive.Font = new Font("Cairo", 9F, FontStyle.Bold);
            tabbedView1.AppearancePage.HeaderActive.ForeColor = Color.White;
            tabbedView1.AppearancePage.HeaderActive.Options.UseFont = true;
            tabbedView1.AppearancePage.HeaderActive.Options.UseForeColor = true;
            tabbedView1.AppearancePage.HeaderDisabled.Font = new Font("Cairo", 8.5F);
            tabbedView1.AppearancePage.HeaderDisabled.ForeColor = Color.FromArgb(145, 158, 175);
            tabbedView1.AppearancePage.HeaderDisabled.Options.UseFont = true;
            tabbedView1.AppearancePage.HeaderDisabled.Options.UseForeColor = true;
            tabbedView1.AppearancePage.HeaderHotTracked.Font = new Font("Cairo", 8.5F);
            tabbedView1.AppearancePage.HeaderHotTracked.ForeColor = Color.FromArgb(10, 50, 120);
            tabbedView1.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            tabbedView1.AppearancePage.HeaderHotTracked.Options.UseForeColor = true;
            tabbedView1.AppearancePage.HeaderSelected.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            tabbedView1.AppearancePage.HeaderSelected.ForeColor = Color.White;
            tabbedView1.AppearancePage.HeaderSelected.Options.UseFont = true;
            tabbedView1.AppearancePage.HeaderSelected.Options.UseForeColor = true;
            tabbedView1.DocumentProperties.TabWidth = 150;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("46InventoryMgt", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.46InventoryMgt"));
            svgImageCollection1.Add("47Stores", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.47Stores"));
            svgImageCollection1.Add("48Items", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.48Items"));
            svgImageCollection1.Add("49MaterialReceiveVoucher", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.49MaterialReceiveVoucher"));
            svgImageCollection1.Add("50MaterialIssuedVoucher", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.50MaterialIssuedVoucher"));
            svgImageCollection1.Add("51MaterialTransfer", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.51MaterialTransfer"));
            svgImageCollection1.Add("53PurchaseReturn", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.53PurchaseReturn"));
            svgImageCollection1.Add("54MaterialIssueReturn", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.54MaterialIssueReturn"));
            svgImageCollection1.Add("55InventoryReports", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.55InventoryReports"));
            // 
            // ucInventoryMgt
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(nfInventory);
            Controls.Add(tbMain);
            Name = "ucInventoryMgt";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1404, 682);
            ((System.ComponentModel.ISupportInitialize)nfInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)documentManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileBar tbMain;
        private DevExpress.XtraBars.Navigation.TileBarGroup tbgInventory;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiStore;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiItems;
        private DevExpress.XtraBars.Navigation.TileBarItem itbMaterialReceive;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiMaterialIssued;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiMaterialTrasfare;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiPurchaseReturn;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiMaterialIssueReturn;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiInventoryReports;
        private DevExpress.XtraBars.Navigation.NavigationFrame nfInventory;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}
