namespace Etmam 
{ 
    partial class ucProcurementMgt
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
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProcurementMgt));
            tbMain = new DevExpress.XtraBars.Navigation.TileBar();
            tbgMain = new DevExpress.XtraBars.Navigation.TileBarGroup();
            tbiDashboard = new DevExpress.XtraBars.Navigation.TileBarItem();
            tbiPurchaseRequest = new DevExpress.XtraBars.Navigation.TileBarItem();
            itbPurchaseOrder = new DevExpress.XtraBars.Navigation.TileBarItem();
            itbSuppliers = new DevExpress.XtraBars.Navigation.TileBarItem();
            itbProcurementReports = new DevExpress.XtraBars.Navigation.TileBarItem();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            nfMain = new DevExpress.XtraBars.Navigation.NavigationFrame();
            documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nfMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)documentManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).BeginInit();
            SuspendLayout();
            // 
            // tbMain
            // 
            tbMain.Dock = DockStyle.Top;
            tbMain.DropDownOptions.BeakColor = Color.Empty;
            tbMain.Groups.Add(tbgMain);
            tbMain.Images = svgImageCollection1;
            tbMain.ItemPadding = new Padding(16, 6, 16, 6);
            tbMain.Location = new Point(0, 0);
            tbMain.MaxId = 10;
            tbMain.Name = "tbMain";
            tbMain.Padding = new Padding(16, 6, 16, 6);
            tbMain.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            tbMain.Size = new Size(1413, 104);
            tbMain.TabIndex = 2;
            tbMain.Text = "tileBar1";
            // 
            // tbgMain
            // 
            tbgMain.Items.Add(tbiDashboard);
            tbgMain.Items.Add(tbiPurchaseRequest);
            tbgMain.Items.Add(itbPurchaseOrder);
            tbgMain.Items.Add(itbSuppliers);
            tbgMain.Items.Add(itbProcurementReports);
            tbgMain.Name = "tbgMain";
            // 
            // tbiDashboard
            // 
            tbiDashboard.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement1.ImageOptions.ImageIndex = 5;
            tileItemElement1.ImageOptions.SvgImageSize = new Size(24, 24);
            tileItemElement1.Text = "لوحة التحكم";
            tileItemElement2.Text = "0";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tbiDashboard.Elements.Add(tileItemElement1);
            tbiDashboard.Elements.Add(tileItemElement2);
            tbiDashboard.Id = 1;
            tbiDashboard.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            tbiDashboard.Name = "tbiDashboard";
            // 
            // tbiPurchaseRequest
            // 
            tbiPurchaseRequest.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement3.ImageOptions.ImageIndex = 2;
            tileItemElement3.ImageOptions.SvgImageSize = new Size(24, 24);
            tileItemElement3.Text = "طلبات الشراء";
            tileItemElement4.Text = "0";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tbiPurchaseRequest.Elements.Add(tileItemElement3);
            tbiPurchaseRequest.Elements.Add(tileItemElement4);
            tbiPurchaseRequest.Id = 2;
            tbiPurchaseRequest.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            tbiPurchaseRequest.Name = "tbiPurchaseRequest";
            // 
            // itbPurchaseOrder
            // 
            itbPurchaseOrder.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement5.ImageOptions.ImageIndex = 3;
            tileItemElement5.ImageOptions.SvgImageSize = new Size(24, 24);
            tileItemElement5.Text = "أوامر الشراء";
            tileItemElement6.Text = "0";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            itbPurchaseOrder.Elements.Add(tileItemElement5);
            itbPurchaseOrder.Elements.Add(tileItemElement6);
            itbPurchaseOrder.Id = 3;
            itbPurchaseOrder.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            itbPurchaseOrder.Name = "itbPurchaseOrder";
            // 
            // itbSuppliers
            // 
            itbSuppliers.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement7.ImageOptions.ImageIndex = 1;
            tileItemElement7.ImageOptions.SvgImageSize = new Size(24, 24);
            tileItemElement7.Text = "الموردين";
            tileItemElement8.Text = "0";
            tileItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            itbSuppliers.Elements.Add(tileItemElement7);
            itbSuppliers.Elements.Add(tileItemElement8);
            itbSuppliers.Id = 9;
            itbSuppliers.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            itbSuppliers.Name = "itbSuppliers";
            // 
            // itbProcurementReports
            // 
            itbProcurementReports.DropDownOptions.BeakColor = Color.Empty;
            tileItemElement9.ImageOptions.ImageIndex = 4;
            tileItemElement9.ImageOptions.SvgImageSize = new Size(24, 24);
            tileItemElement9.Text = "تقارير المشتريات";
            itbProcurementReports.Elements.Add(tileItemElement9);
            itbProcurementReports.Id = 8;
            itbProcurementReports.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            itbProcurementReports.Name = "itbProcurementReports";
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("PurchaseMgt", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.PurchaseMgt"));
            svgImageCollection1.Add("Stakeholder", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.Stakeholder"));
            svgImageCollection1.Add("PurchaseRequest", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.PurchaseRequest"));
            svgImageCollection1.Add("PurchaseOrder", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.PurchaseOrder"));
            svgImageCollection1.Add("PurchaseReports", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.PurchaseReports"));
            svgImageCollection1.Add("Dashboard", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.Dashboard"));
            // 
            // nfMain
            // 
            nfMain.Dock = DockStyle.Fill;
            nfMain.Location = new Point(0, 104);
            nfMain.Name = "nfMain";
            nfMain.Size = new Size(1413, 564);
            nfMain.TabIndex = 3;
            nfMain.Text = "navigationFrame1";
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
            // ucProcurementMgt
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(nfMain);
            Controls.Add(tbMain);
            Name = "ucProcurementMgt";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1413, 668);
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nfMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)documentManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileBar tbMain;
        private DevExpress.XtraBars.Navigation.TileBarGroup tbgMain;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiDashboard;
        private DevExpress.XtraBars.Navigation.TileBarItem tbiPurchaseRequest;
        private DevExpress.XtraBars.Navigation.TileBarItem itbPurchaseOrder;
        private DevExpress.XtraBars.Navigation.TileBarItem itbSuppliers;
        private DevExpress.XtraBars.Navigation.TileBarItem itbProcurementReports;
        private DevExpress.XtraBars.Navigation.NavigationFrame nfMain;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}
