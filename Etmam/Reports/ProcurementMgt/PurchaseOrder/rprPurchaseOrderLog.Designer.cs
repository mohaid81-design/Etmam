namespace Etmam
{
    partial class rprPurchaseOrderLog
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprPurchaseOrderLog));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrDetailTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrDetailRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrCellStatus = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCellAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCellDeliveryDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCellOrderDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCellPriority = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCellPurchaseMethod = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCellSupplier = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCellStore = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCellProject = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCellOrderNum = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLogoPictureBox = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrTitleLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageNumberInfo = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrHeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrHeaderRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrHeaderCellStatus = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeaderCellAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeaderCellDeliveryDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeaderCellOrderDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeaderCellPriority = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeaderCellPurchaseMethod = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeaderCellSupplier = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeaderCellStore = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeaderCellProject = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeaderCellOrderNum = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrDetailsSectionLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrReportDateCaptionLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPrintDateLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.xrDetailTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrHeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrDetailTable});
            this.Detail.Dpi = 25.4F;
            this.Detail.HeightF = 7F;
            this.Detail.HierarchyPrintOptions.Indent = 5.08F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // xrDetailTable
            //
            this.xrDetailTable.BackColor = System.Drawing.Color.Transparent;
            this.xrDetailTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrDetailTable.Dpi = 25.4F;
            this.xrDetailTable.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrDetailTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrDetailTable.Name = "xrDetailTable";
            this.xrDetailTable.OddStyleName = "xrControlStyle1";
            this.xrDetailTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(0.5291666F, 0.5291666F, 0F, 0F, 25.4F);
            this.xrDetailTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrDetailRow});
            this.xrDetailTable.SizeF = new System.Drawing.SizeF(267F, 7F);
            this.xrDetailTable.StylePriority.UseBorders = false;
            this.xrDetailTable.StylePriority.UseFont = false;
            this.xrDetailTable.StylePriority.UseTextAlignment = false;
            this.xrDetailTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // xrDetailRow
            //
            this.xrDetailRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrCellStatus,
            this.xrCellAmount,
            this.xrCellDeliveryDate,
            this.xrCellOrderDate,
            this.xrCellPriority,
            this.xrCellPurchaseMethod,
            this.xrCellSupplier,
            this.xrCellStore,
            this.xrCellProject,
            this.xrCellOrderNum});
            this.xrDetailRow.Dpi = 25.4F;
            this.xrDetailRow.Name = "xrDetailRow";
            this.xrDetailRow.Weight = 1D;
            //
            // xrCellStatus
            //
            this.xrCellStatus.Dpi = 25.4F;
            this.xrCellStatus.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StatusDisplay]")});
            this.xrCellStatus.Multiline = true;
            this.xrCellStatus.Name = "xrCellStatus";
            this.xrCellStatus.Weight = 1.2D;
            //
            // xrCellAmount
            //
            this.xrCellAmount.Dpi = 25.4F;
            this.xrCellAmount.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount]")});
            this.xrCellAmount.Multiline = true;
            this.xrCellAmount.Name = "xrCellAmount";
            this.xrCellAmount.StylePriority.UseTextAlignment = false;
            this.xrCellAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrCellAmount.TextFormatString = "{0:N2}";
            this.xrCellAmount.Weight = 0.9D;
            //
            // xrCellDeliveryDate
            //
            this.xrCellDeliveryDate.Dpi = 25.4F;
            this.xrCellDeliveryDate.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DeliveryDate]")});
            this.xrCellDeliveryDate.Multiline = true;
            this.xrCellDeliveryDate.Name = "xrCellDeliveryDate";
            this.xrCellDeliveryDate.StylePriority.UseTextAlignment = false;
            this.xrCellDeliveryDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrCellDeliveryDate.TextFormatString = "{0:yyyy-MM-dd}";
            this.xrCellDeliveryDate.Weight = 0.85D;
            //
            // xrCellOrderDate
            //
            this.xrCellOrderDate.Dpi = 25.4F;
            this.xrCellOrderDate.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OrderDate]")});
            this.xrCellOrderDate.Multiline = true;
            this.xrCellOrderDate.Name = "xrCellOrderDate";
            this.xrCellOrderDate.StylePriority.UseTextAlignment = false;
            this.xrCellOrderDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrCellOrderDate.TextFormatString = "{0:yyyy-MM-dd}";
            this.xrCellOrderDate.Weight = 0.85D;
            //
            // xrCellPriority
            //
            this.xrCellPriority.Dpi = 25.4F;
            this.xrCellPriority.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PriorityLevel]")});
            this.xrCellPriority.Multiline = true;
            this.xrCellPriority.Name = "xrCellPriority";
            this.xrCellPriority.StylePriority.UseTextAlignment = false;
            this.xrCellPriority.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrCellPriority.Weight = 0.65D;
            //
            // xrCellPurchaseMethod
            //
            this.xrCellPurchaseMethod.Dpi = 25.4F;
            this.xrCellPurchaseMethod.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PurchaseMethod]")});
            this.xrCellPurchaseMethod.Multiline = true;
            this.xrCellPurchaseMethod.Name = "xrCellPurchaseMethod";
            this.xrCellPurchaseMethod.StylePriority.UseTextAlignment = false;
            this.xrCellPurchaseMethod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrCellPurchaseMethod.Weight = 0.9D;
            //
            // xrCellSupplier
            //
            this.xrCellSupplier.Dpi = 25.4F;
            this.xrCellSupplier.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SupplierName]")});
            this.xrCellSupplier.Multiline = true;
            this.xrCellSupplier.Name = "xrCellSupplier";
            this.xrCellSupplier.Weight = 1.5D;
            //
            // xrCellStore
            //
            this.xrCellStore.Dpi = 25.4F;
            this.xrCellStore.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StoreName]")});
            this.xrCellStore.Multiline = true;
            this.xrCellStore.Name = "xrCellStore";
            this.xrCellStore.Weight = 1D;
            //
            // xrCellProject
            //
            this.xrCellProject.Dpi = 25.4F;
            this.xrCellProject.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProjectName]")});
            this.xrCellProject.Multiline = true;
            this.xrCellProject.Name = "xrCellProject";
            this.xrCellProject.Weight = 1.5D;
            //
            // xrCellOrderNum
            //
            this.xrCellOrderNum.Dpi = 25.4F;
            this.xrCellOrderNum.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FormattedNum]")});
            this.xrCellOrderNum.Multiline = true;
            this.xrCellOrderNum.Name = "xrCellOrderNum";
            this.xrCellOrderNum.StylePriority.UseTextAlignment = false;
            this.xrCellOrderNum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrCellOrderNum.Weight = 0.9D;
            //
            // TopMargin
            //
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLogoPictureBox,
            this.xrTitleLabel});
            this.TopMargin.Dpi = 25.4F;
            this.TopMargin.HeightF = 40F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // xrLogoPictureBox
            //
            this.xrLogoPictureBox.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLogoPictureBox.Dpi = 25.4F;
            this.xrLogoPictureBox.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrLogoPictureBox.ImageSource"));
            this.xrLogoPictureBox.LocationFloat = new DevExpress.Utils.PointFloat(2.540002F, 7.540002F);
            this.xrLogoPictureBox.Name = "xrLogoPictureBox";
            this.xrLogoPictureBox.SizeF = new System.Drawing.SizeF(38.1F, 16.51F);
            this.xrLogoPictureBox.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.xrLogoPictureBox.StylePriority.UseBorders = false;
            //
            // xrTitleLabel
            //
            this.xrTitleLabel.BackColor = System.Drawing.Color.DarkGray;
            this.xrTitleLabel.BorderColor = System.Drawing.Color.DimGray;
            this.xrTitleLabel.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTitleLabel.BorderWidth = 1F;
            this.xrTitleLabel.Dpi = 25.4F;
            this.xrTitleLabel.Font = new DevExpress.Drawing.DXFont("PT Bold Heading", 16F);
            this.xrTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.xrTitleLabel.LocationFloat = new DevExpress.Utils.PointFloat(1.211166E-05F, 28.86633F);
            this.xrTitleLabel.Multiline = true;
            this.xrTitleLabel.Name = "xrTitleLabel";
            this.xrTitleLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(0.508F, 0.508F, 0F, 0F, 25.4F);
            this.xrTitleLabel.SizeF = new System.Drawing.SizeF(267F, 11.13367F);
            this.xrTitleLabel.StylePriority.UseBackColor = false;
            this.xrTitleLabel.StylePriority.UseBorderColor = false;
            this.xrTitleLabel.StylePriority.UseBorders = false;
            this.xrTitleLabel.StylePriority.UseBorderWidth = false;
            this.xrTitleLabel.StylePriority.UseFont = false;
            this.xrTitleLabel.StylePriority.UseForeColor = false;
            this.xrTitleLabel.StylePriority.UseTextAlignment = false;
            this.xrTitleLabel.Text = "سجل أوامر الشراء";
            this.xrTitleLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            //
            // BottomMargin
            //
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageNumberInfo});
            this.BottomMargin.Dpi = 25.4F;
            this.BottomMargin.HeightF = 15F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // xrPageNumberInfo
            //
            this.xrPageNumberInfo.BorderColor = System.Drawing.Color.Black;
            this.xrPageNumberInfo.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrPageNumberInfo.BorderWidth = 2F;
            this.xrPageNumberInfo.Dpi = 25.4F;
            this.xrPageNumberInfo.Font = new DevExpress.Drawing.DXFont("Cairo", 10F);
            this.xrPageNumberInfo.LocationFloat = new DevExpress.Utils.PointFloat(2.826055E-05F, 1.926142F);
            this.xrPageNumberInfo.Name = "xrPageNumberInfo";
            this.xrPageNumberInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0.508F, 0.508F, 0F, 0F, 25.4F);
            this.xrPageNumberInfo.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.No;
            this.xrPageNumberInfo.SizeF = new System.Drawing.SizeF(267F, 8.276166F);
            this.xrPageNumberInfo.StylePriority.UseBorderColor = false;
            this.xrPageNumberInfo.StylePriority.UseBorders = false;
            this.xrPageNumberInfo.StylePriority.UseBorderWidth = false;
            this.xrPageNumberInfo.StylePriority.UseFont = false;
            this.xrPageNumberInfo.StylePriority.UseTextAlignment = false;
            this.xrPageNumberInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // ReportHeader
            //
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrHeaderTable,
            this.xrDetailsSectionLabel,
            this.xrReportDateCaptionLabel,
            this.xrPrintDateLabel});
            this.ReportHeader.Dpi = 25.4F;
            this.ReportHeader.HeightF = 24.82292F;
            this.ReportHeader.Name = "ReportHeader";
            //
            // xrHeaderTable
            //
            this.xrHeaderTable.BackColor = System.Drawing.Color.Gainsboro;
            this.xrHeaderTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrHeaderTable.Dpi = 25.4F;
            this.xrHeaderTable.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrHeaderTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.97001F);
            this.xrHeaderTable.Name = "xrHeaderTable";
            this.xrHeaderTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(0.5291666F, 0.5291666F, 0F, 0F, 25.4F);
            this.xrHeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrHeaderRow});
            this.xrHeaderTable.SizeF = new System.Drawing.SizeF(267F, 10.85291F);
            this.xrHeaderTable.StylePriority.UseBackColor = false;
            this.xrHeaderTable.StylePriority.UseBorders = false;
            this.xrHeaderTable.StylePriority.UseFont = false;
            this.xrHeaderTable.StylePriority.UseTextAlignment = false;
            this.xrHeaderTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrHeaderRow
            //
            this.xrHeaderRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrHeaderCellStatus,
            this.xrHeaderCellAmount,
            this.xrHeaderCellDeliveryDate,
            this.xrHeaderCellOrderDate,
            this.xrHeaderCellPriority,
            this.xrHeaderCellPurchaseMethod,
            this.xrHeaderCellSupplier,
            this.xrHeaderCellStore,
            this.xrHeaderCellProject,
            this.xrHeaderCellOrderNum});
            this.xrHeaderRow.Dpi = 25.4F;
            this.xrHeaderRow.Name = "xrHeaderRow";
            this.xrHeaderRow.Weight = 1D;
            //
            // xrHeaderCellStatus
            //
            this.xrHeaderCellStatus.Dpi = 25.4F;
            this.xrHeaderCellStatus.Multiline = true;
            this.xrHeaderCellStatus.Name = "xrHeaderCellStatus";
            this.xrHeaderCellStatus.Text = "الحالة";
            this.xrHeaderCellStatus.Weight = 1.2D;
            //
            // xrHeaderCellAmount
            //
            this.xrHeaderCellAmount.Dpi = 25.4F;
            this.xrHeaderCellAmount.Multiline = true;
            this.xrHeaderCellAmount.Name = "xrHeaderCellAmount";
            this.xrHeaderCellAmount.Text = "القيمة";
            this.xrHeaderCellAmount.Weight = 0.9D;
            //
            // xrHeaderCellDeliveryDate
            //
            this.xrHeaderCellDeliveryDate.Dpi = 25.4F;
            this.xrHeaderCellDeliveryDate.Multiline = true;
            this.xrHeaderCellDeliveryDate.Name = "xrHeaderCellDeliveryDate";
            this.xrHeaderCellDeliveryDate.Text = "تاريخ التسليم";
            this.xrHeaderCellDeliveryDate.Weight = 0.85D;
            //
            // xrHeaderCellOrderDate
            //
            this.xrHeaderCellOrderDate.Dpi = 25.4F;
            this.xrHeaderCellOrderDate.Multiline = true;
            this.xrHeaderCellOrderDate.Name = "xrHeaderCellOrderDate";
            this.xrHeaderCellOrderDate.Text = "تاريخ الإعداد";
            this.xrHeaderCellOrderDate.Weight = 0.85D;
            //
            // xrHeaderCellPriority
            //
            this.xrHeaderCellPriority.Dpi = 25.4F;
            this.xrHeaderCellPriority.Multiline = true;
            this.xrHeaderCellPriority.Name = "xrHeaderCellPriority";
            this.xrHeaderCellPriority.Text = "مستوى الأهمية";
            this.xrHeaderCellPriority.Weight = 0.65D;
            //
            // xrHeaderCellPurchaseMethod
            //
            this.xrHeaderCellPurchaseMethod.Dpi = 25.4F;
            this.xrHeaderCellPurchaseMethod.Multiline = true;
            this.xrHeaderCellPurchaseMethod.Name = "xrHeaderCellPurchaseMethod";
            this.xrHeaderCellPurchaseMethod.Text = "طريقة الشراء";
            this.xrHeaderCellPurchaseMethod.Weight = 0.9D;
            //
            // xrHeaderCellSupplier
            //
            this.xrHeaderCellSupplier.Dpi = 25.4F;
            this.xrHeaderCellSupplier.Multiline = true;
            this.xrHeaderCellSupplier.Name = "xrHeaderCellSupplier";
            this.xrHeaderCellSupplier.Text = "المورد";
            this.xrHeaderCellSupplier.Weight = 1.5D;
            //
            // xrHeaderCellStore
            //
            this.xrHeaderCellStore.Dpi = 25.4F;
            this.xrHeaderCellStore.Multiline = true;
            this.xrHeaderCellStore.Name = "xrHeaderCellStore";
            this.xrHeaderCellStore.Text = "المخزن";
            this.xrHeaderCellStore.Weight = 1D;
            //
            // xrHeaderCellProject
            //
            this.xrHeaderCellProject.Dpi = 25.4F;
            this.xrHeaderCellProject.Multiline = true;
            this.xrHeaderCellProject.Name = "xrHeaderCellProject";
            this.xrHeaderCellProject.Text = "المشروع";
            this.xrHeaderCellProject.Weight = 1.5D;
            //
            // xrHeaderCellOrderNum
            //
            this.xrHeaderCellOrderNum.Dpi = 25.4F;
            this.xrHeaderCellOrderNum.Multiline = true;
            this.xrHeaderCellOrderNum.Name = "xrHeaderCellOrderNum";
            this.xrHeaderCellOrderNum.Text = "رقم أمر الشراء";
            this.xrHeaderCellOrderNum.Weight = 0.9D;
            //
            // xrDetailsSectionLabel
            //
            this.xrDetailsSectionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.xrDetailsSectionLabel.BorderColor = System.Drawing.Color.DimGray;
            this.xrDetailsSectionLabel.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrDetailsSectionLabel.Dpi = 25.4F;
            this.xrDetailsSectionLabel.Font = new DevExpress.Drawing.DXFont("Calibri Light", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrDetailsSectionLabel.ForeColor = System.Drawing.Color.Black;
            this.xrDetailsSectionLabel.LocationFloat = new DevExpress.Utils.PointFloat(2.018611E-05F, 7.620005F);
            this.xrDetailsSectionLabel.Multiline = true;
            this.xrDetailsSectionLabel.Name = "xrDetailsSectionLabel";
            this.xrDetailsSectionLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrDetailsSectionLabel.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrDetailsSectionLabel.SizeF = new System.Drawing.SizeF(267F, 6.350002F);
            this.xrDetailsSectionLabel.StylePriority.UseBackColor = false;
            this.xrDetailsSectionLabel.StylePriority.UseBorderColor = false;
            this.xrDetailsSectionLabel.StylePriority.UseBorders = false;
            this.xrDetailsSectionLabel.StylePriority.UseFont = false;
            this.xrDetailsSectionLabel.StylePriority.UseForeColor = false;
            this.xrDetailsSectionLabel.StylePriority.UsePadding = false;
            this.xrDetailsSectionLabel.StylePriority.UseTextAlignment = false;
            this.xrDetailsSectionLabel.Text = "تفاصيل السجل";
            this.xrDetailsSectionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrReportDateCaptionLabel
            //
            this.xrReportDateCaptionLabel.BorderColor = System.Drawing.Color.DimGray;
            this.xrReportDateCaptionLabel.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrReportDateCaptionLabel.Dpi = 25.4F;
            this.xrReportDateCaptionLabel.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrReportDateCaptionLabel.LocationFloat = new DevExpress.Utils.PointFloat(240.965F, 0F);
            this.xrReportDateCaptionLabel.Multiline = true;
            this.xrReportDateCaptionLabel.Name = "xrReportDateCaptionLabel";
            this.xrReportDateCaptionLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrReportDateCaptionLabel.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrReportDateCaptionLabel.SizeF = new System.Drawing.SizeF(26.03503F, 7.62F);
            this.xrReportDateCaptionLabel.StylePriority.UseBorderColor = false;
            this.xrReportDateCaptionLabel.StylePriority.UseBorders = false;
            this.xrReportDateCaptionLabel.StylePriority.UseFont = false;
            this.xrReportDateCaptionLabel.StylePriority.UsePadding = false;
            this.xrReportDateCaptionLabel.StylePriority.UseTextAlignment = false;
            this.xrReportDateCaptionLabel.Text = "تاريخ السجل";
            this.xrReportDateCaptionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrPrintDateLabel
            //
            this.xrPrintDateLabel.BorderColor = System.Drawing.Color.DimGray;
            this.xrPrintDateLabel.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPrintDateLabel.Dpi = 25.4F;
            this.xrPrintDateLabel.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrPrintDateLabel.ForeColor = System.Drawing.Color.Navy;
            this.xrPrintDateLabel.LocationFloat = new DevExpress.Utils.PointFloat(4.037221E-06F, 0F);
            this.xrPrintDateLabel.Multiline = true;
            this.xrPrintDateLabel.Name = "xrPrintDateLabel";
            this.xrPrintDateLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrPrintDateLabel.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrPrintDateLabel.SizeF = new System.Drawing.SizeF(240.965F, 7.62F);
            this.xrPrintDateLabel.StylePriority.UseBorderColor = false;
            this.xrPrintDateLabel.StylePriority.UseBorders = false;
            this.xrPrintDateLabel.StylePriority.UseFont = false;
            this.xrPrintDateLabel.StylePriority.UseForeColor = false;
            this.xrPrintDateLabel.StylePriority.UsePadding = false;
            this.xrPrintDateLabel.StylePriority.UseTextAlignment = false;
            this.xrPrintDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrPrintDateLabel.TextFormatString = "{0:yyyy-MM-dd}";
            //
            // xrControlStyle1
            //
            this.xrControlStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.xrControlStyle1.Name = "xrControlStyle1";
            this.xrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            //
            // rprPurchaseOrderLog
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.Dpi = 25.4F;
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(15F, 15F, 40F, 15F);
            this.PageHeightF = 210F;
            this.PageWidthF = 297F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Millimeters;
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.SnapGridSize = 2.5F;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrDetailTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrHeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPictureBox xrLogoPictureBox;
        private DevExpress.XtraReports.UI.XRLabel xrTitleLabel;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrReportDateCaptionLabel;
        public DevExpress.XtraReports.UI.XRLabel xrPrintDateLabel;
        private DevExpress.XtraReports.UI.XRTable xrHeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow xrHeaderRow;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellOrderNum;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellProject;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellStore;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellSupplier;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellPurchaseMethod;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellPriority;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellOrderDate;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellDeliveryDate;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellAmount;
        private DevExpress.XtraReports.UI.XRTableCell xrHeaderCellStatus;
        private DevExpress.XtraReports.UI.XRLabel xrDetailsSectionLabel;
        private DevExpress.XtraReports.UI.XRTable xrDetailTable;
        private DevExpress.XtraReports.UI.XRTableRow xrDetailRow;
        private DevExpress.XtraReports.UI.XRTableCell xrCellOrderNum;
        private DevExpress.XtraReports.UI.XRTableCell xrCellProject;
        private DevExpress.XtraReports.UI.XRTableCell xrCellStore;
        private DevExpress.XtraReports.UI.XRTableCell xrCellSupplier;
        private DevExpress.XtraReports.UI.XRTableCell xrCellPurchaseMethod;
        private DevExpress.XtraReports.UI.XRTableCell xrCellPriority;
        private DevExpress.XtraReports.UI.XRTableCell xrCellOrderDate;
        private DevExpress.XtraReports.UI.XRTableCell xrCellDeliveryDate;
        private DevExpress.XtraReports.UI.XRTableCell xrCellAmount;
        private DevExpress.XtraReports.UI.XRTableCell xrCellStatus;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageNumberInfo;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
    }
}
