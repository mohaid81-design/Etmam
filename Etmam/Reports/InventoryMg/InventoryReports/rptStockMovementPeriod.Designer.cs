namespace Etmam
{
    partial class rptStockMovementPeriod
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrFilterSummary = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPrintDate = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.hdrItemCode = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrItemName = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrUnitAbbr = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrStoreName = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrOpeningQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrReceivedQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrIssuedQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrTransferInQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrTransferOutQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrPurchaseReturnQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrIssueReturnQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrClosingQty = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrItemCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrItemName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrUnitAbbr = new DevExpress.XtraReports.UI.XRLabel();
            this.xrStoreName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrOpeningQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrReceivedQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrIssuedQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTransferInQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTransferOutQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPurchaseReturnQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrIssueReturnQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrClosingQty = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTotalLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTotalClosingQty = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // TopMargin
            //
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            //
            // BottomMargin
            //
            this.BottomMargin.HeightF = 20F;
            this.BottomMargin.Name = "BottomMargin";
            //
            // ReportHeader
            //
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.xrPrintDate, this.xrFilterSummary, this.xrTitle});
            this.ReportHeader.HeightF = 70F;
            this.ReportHeader.Name = "ReportHeader";
            //
            // xrTitle
            //
            this.xrTitle.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 16F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTitle.Name = "xrTitle";
            this.xrTitle.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTitle.SizeF = new System.Drawing.SizeF(1042F, 30F);
            this.xrTitle.StylePriority.UseFont = false;
            this.xrTitle.StylePriority.UseTextAlignment = false;
            this.xrTitle.Text = "تقرير حركة المخزون خلال فترة";
            this.xrTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrFilterSummary
            //
            this.xrFilterSummary.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 10F);
            this.xrFilterSummary.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30F);
            this.xrFilterSummary.Name = "xrFilterSummary";
            this.xrFilterSummary.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrFilterSummary.SizeF = new System.Drawing.SizeF(1042F, 20F);
            this.xrFilterSummary.StylePriority.UseFont = false;
            this.xrFilterSummary.StylePriority.UseTextAlignment = false;
            this.xrFilterSummary.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrPrintDate
            //
            this.xrPrintDate.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrPrintDate.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.xrPrintDate.Name = "xrPrintDate";
            this.xrPrintDate.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrPrintDate.SizeF = new System.Drawing.SizeF(1042F, 18F);
            this.xrPrintDate.StylePriority.UseFont = false;
            this.xrPrintDate.StylePriority.UseTextAlignment = false;
            this.xrPrintDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // PageHeader
            //
            this.PageHeader.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.hdrItemCode, this.hdrItemName, this.hdrUnitAbbr, this.hdrStoreName, this.hdrOpeningQty,
                this.hdrReceivedQty, this.hdrIssuedQty, this.hdrTransferInQty, this.hdrTransferOutQty,
                this.hdrPurchaseReturnQty, this.hdrIssueReturnQty, this.hdrClosingQty});
            this.PageHeader.HeightF = 25F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseBackColor = false;
            //
            // hdrItemCode
            //
            this.hdrItemCode.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrItemCode.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrItemCode.LocationFloat = new DevExpress.Utils.PointFloat(972F, 0F);
            this.hdrItemCode.Name = "hdrItemCode";
            this.hdrItemCode.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrItemCode.SizeF = new System.Drawing.SizeF(70F, 25F);
            this.hdrItemCode.StylePriority.UseBorders = false;
            this.hdrItemCode.StylePriority.UseFont = false;
            this.hdrItemCode.StylePriority.UseTextAlignment = false;
            this.hdrItemCode.Text = "رمز الصنف";
            this.hdrItemCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrItemName
            //
            this.hdrItemName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrItemName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrItemName.LocationFloat = new DevExpress.Utils.PointFloat(832F, 0F);
            this.hdrItemName.Name = "hdrItemName";
            this.hdrItemName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrItemName.SizeF = new System.Drawing.SizeF(140F, 25F);
            this.hdrItemName.StylePriority.UseBorders = false;
            this.hdrItemName.StylePriority.UseFont = false;
            this.hdrItemName.StylePriority.UseTextAlignment = false;
            this.hdrItemName.Text = "اسم الصنف";
            this.hdrItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrUnitAbbr
            //
            this.hdrUnitAbbr.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrUnitAbbr.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrUnitAbbr.LocationFloat = new DevExpress.Utils.PointFloat(782F, 0F);
            this.hdrUnitAbbr.Name = "hdrUnitAbbr";
            this.hdrUnitAbbr.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrUnitAbbr.SizeF = new System.Drawing.SizeF(50F, 25F);
            this.hdrUnitAbbr.StylePriority.UseBorders = false;
            this.hdrUnitAbbr.StylePriority.UseFont = false;
            this.hdrUnitAbbr.StylePriority.UseTextAlignment = false;
            this.hdrUnitAbbr.Text = "الوحدة";
            this.hdrUnitAbbr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrStoreName
            //
            this.hdrStoreName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrStoreName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrStoreName.LocationFloat = new DevExpress.Utils.PointFloat(692F, 0F);
            this.hdrStoreName.Name = "hdrStoreName";
            this.hdrStoreName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrStoreName.SizeF = new System.Drawing.SizeF(90F, 25F);
            this.hdrStoreName.StylePriority.UseBorders = false;
            this.hdrStoreName.StylePriority.UseFont = false;
            this.hdrStoreName.StylePriority.UseTextAlignment = false;
            this.hdrStoreName.Text = "المخزن";
            this.hdrStoreName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrOpeningQty
            //
            this.hdrOpeningQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrOpeningQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrOpeningQty.LocationFloat = new DevExpress.Utils.PointFloat(617F, 0F);
            this.hdrOpeningQty.Name = "hdrOpeningQty";
            this.hdrOpeningQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrOpeningQty.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.hdrOpeningQty.StylePriority.UseBorders = false;
            this.hdrOpeningQty.StylePriority.UseFont = false;
            this.hdrOpeningQty.StylePriority.UseTextAlignment = false;
            this.hdrOpeningQty.Text = "رصيد أول المدة";
            this.hdrOpeningQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrReceivedQty
            //
            this.hdrReceivedQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrReceivedQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrReceivedQty.LocationFloat = new DevExpress.Utils.PointFloat(552F, 0F);
            this.hdrReceivedQty.Name = "hdrReceivedQty";
            this.hdrReceivedQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrReceivedQty.SizeF = new System.Drawing.SizeF(65F, 25F);
            this.hdrReceivedQty.StylePriority.UseBorders = false;
            this.hdrReceivedQty.StylePriority.UseFont = false;
            this.hdrReceivedQty.StylePriority.UseTextAlignment = false;
            this.hdrReceivedQty.Text = "استلام";
            this.hdrReceivedQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrIssuedQty
            //
            this.hdrIssuedQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrIssuedQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrIssuedQty.LocationFloat = new DevExpress.Utils.PointFloat(492F, 0F);
            this.hdrIssuedQty.Name = "hdrIssuedQty";
            this.hdrIssuedQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrIssuedQty.SizeF = new System.Drawing.SizeF(60F, 25F);
            this.hdrIssuedQty.StylePriority.UseBorders = false;
            this.hdrIssuedQty.StylePriority.UseFont = false;
            this.hdrIssuedQty.StylePriority.UseTextAlignment = false;
            this.hdrIssuedQty.Text = "صرف";
            this.hdrIssuedQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrTransferInQty
            //
            this.hdrTransferInQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrTransferInQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrTransferInQty.LocationFloat = new DevExpress.Utils.PointFloat(422F, 0F);
            this.hdrTransferInQty.Name = "hdrTransferInQty";
            this.hdrTransferInQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrTransferInQty.SizeF = new System.Drawing.SizeF(70F, 25F);
            this.hdrTransferInQty.StylePriority.UseBorders = false;
            this.hdrTransferInQty.StylePriority.UseFont = false;
            this.hdrTransferInQty.StylePriority.UseTextAlignment = false;
            this.hdrTransferInQty.Text = "تحويل وارد";
            this.hdrTransferInQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrTransferOutQty
            //
            this.hdrTransferOutQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrTransferOutQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrTransferOutQty.LocationFloat = new DevExpress.Utils.PointFloat(352F, 0F);
            this.hdrTransferOutQty.Name = "hdrTransferOutQty";
            this.hdrTransferOutQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrTransferOutQty.SizeF = new System.Drawing.SizeF(70F, 25F);
            this.hdrTransferOutQty.StylePriority.UseBorders = false;
            this.hdrTransferOutQty.StylePriority.UseFont = false;
            this.hdrTransferOutQty.StylePriority.UseTextAlignment = false;
            this.hdrTransferOutQty.Text = "تحويل صادر";
            this.hdrTransferOutQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrPurchaseReturnQty
            //
            this.hdrPurchaseReturnQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrPurchaseReturnQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrPurchaseReturnQty.LocationFloat = new DevExpress.Utils.PointFloat(272F, 0F);
            this.hdrPurchaseReturnQty.Name = "hdrPurchaseReturnQty";
            this.hdrPurchaseReturnQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrPurchaseReturnQty.SizeF = new System.Drawing.SizeF(80F, 25F);
            this.hdrPurchaseReturnQty.StylePriority.UseBorders = false;
            this.hdrPurchaseReturnQty.StylePriority.UseFont = false;
            this.hdrPurchaseReturnQty.StylePriority.UseTextAlignment = false;
            this.hdrPurchaseReturnQty.Text = "مرتجع مشتريات";
            this.hdrPurchaseReturnQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrIssueReturnQty
            //
            this.hdrIssueReturnQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrIssueReturnQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrIssueReturnQty.LocationFloat = new DevExpress.Utils.PointFloat(202F, 0F);
            this.hdrIssueReturnQty.Name = "hdrIssueReturnQty";
            this.hdrIssueReturnQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrIssueReturnQty.SizeF = new System.Drawing.SizeF(70F, 25F);
            this.hdrIssueReturnQty.StylePriority.UseBorders = false;
            this.hdrIssueReturnQty.StylePriority.UseFont = false;
            this.hdrIssueReturnQty.StylePriority.UseTextAlignment = false;
            this.hdrIssueReturnQty.Text = "مرتجع صرف";
            this.hdrIssueReturnQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrClosingQty
            //
            this.hdrClosingQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrClosingQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrClosingQty.LocationFloat = new DevExpress.Utils.PointFloat(127F, 0F);
            this.hdrClosingQty.Name = "hdrClosingQty";
            this.hdrClosingQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrClosingQty.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.hdrClosingQty.StylePriority.UseBorders = false;
            this.hdrClosingQty.StylePriority.UseFont = false;
            this.hdrClosingQty.StylePriority.UseTextAlignment = false;
            this.hdrClosingQty.Text = "رصيد آخر المدة";
            this.hdrClosingQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.xrItemCode, this.xrItemName, this.xrUnitAbbr, this.xrStoreName, this.xrOpeningQty,
                this.xrReceivedQty, this.xrIssuedQty, this.xrTransferInQty, this.xrTransferOutQty,
                this.xrPurchaseReturnQty, this.xrIssueReturnQty, this.xrClosingQty});
            this.Detail.HeightF = 22F;
            this.Detail.Name = "Detail";
            //
            // xrItemCode
            //
            this.xrItemCode.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrItemCode.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrItemCode.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ItemCode]")});
            this.xrItemCode.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrItemCode.LocationFloat = new DevExpress.Utils.PointFloat(972F, 0F);
            this.xrItemCode.Name = "xrItemCode";
            this.xrItemCode.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrItemCode.SizeF = new System.Drawing.SizeF(70F, 22F);
            this.xrItemCode.StylePriority.UseBorderColor = false;
            this.xrItemCode.StylePriority.UseBorders = false;
            this.xrItemCode.StylePriority.UseFont = false;
            this.xrItemCode.StylePriority.UseTextAlignment = false;
            this.xrItemCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrItemName
            //
            this.xrItemName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrItemName.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrItemName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ItemName]")});
            this.xrItemName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrItemName.LocationFloat = new DevExpress.Utils.PointFloat(832F, 0F);
            this.xrItemName.Name = "xrItemName";
            this.xrItemName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrItemName.SizeF = new System.Drawing.SizeF(140F, 22F);
            this.xrItemName.StylePriority.UseBorderColor = false;
            this.xrItemName.StylePriority.UseBorders = false;
            this.xrItemName.StylePriority.UseFont = false;
            this.xrItemName.StylePriority.UseTextAlignment = false;
            this.xrItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrUnitAbbr
            //
            this.xrUnitAbbr.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrUnitAbbr.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrUnitAbbr.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UnitAbbr]")});
            this.xrUnitAbbr.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrUnitAbbr.LocationFloat = new DevExpress.Utils.PointFloat(782F, 0F);
            this.xrUnitAbbr.Name = "xrUnitAbbr";
            this.xrUnitAbbr.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrUnitAbbr.SizeF = new System.Drawing.SizeF(50F, 22F);
            this.xrUnitAbbr.StylePriority.UseBorderColor = false;
            this.xrUnitAbbr.StylePriority.UseBorders = false;
            this.xrUnitAbbr.StylePriority.UseFont = false;
            this.xrUnitAbbr.StylePriority.UseTextAlignment = false;
            this.xrUnitAbbr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrStoreName
            //
            this.xrStoreName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrStoreName.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrStoreName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StoreName]")});
            this.xrStoreName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrStoreName.LocationFloat = new DevExpress.Utils.PointFloat(692F, 0F);
            this.xrStoreName.Name = "xrStoreName";
            this.xrStoreName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrStoreName.SizeF = new System.Drawing.SizeF(90F, 22F);
            this.xrStoreName.StylePriority.UseBorderColor = false;
            this.xrStoreName.StylePriority.UseBorders = false;
            this.xrStoreName.StylePriority.UseFont = false;
            this.xrStoreName.StylePriority.UseTextAlignment = false;
            this.xrStoreName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrOpeningQty
            //
            this.xrOpeningQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrOpeningQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrOpeningQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OpeningQty]")});
            this.xrOpeningQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrOpeningQty.LocationFloat = new DevExpress.Utils.PointFloat(617F, 0F);
            this.xrOpeningQty.Name = "xrOpeningQty";
            this.xrOpeningQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrOpeningQty.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.xrOpeningQty.StylePriority.UseBorderColor = false;
            this.xrOpeningQty.StylePriority.UseBorders = false;
            this.xrOpeningQty.StylePriority.UseFont = false;
            this.xrOpeningQty.StylePriority.UseTextAlignment = false;
            this.xrOpeningQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrOpeningQty.TextFormatString = "{0:n2}";
            //
            // xrReceivedQty
            //
            this.xrReceivedQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrReceivedQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrReceivedQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ReceivedQty]")});
            this.xrReceivedQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrReceivedQty.LocationFloat = new DevExpress.Utils.PointFloat(552F, 0F);
            this.xrReceivedQty.Name = "xrReceivedQty";
            this.xrReceivedQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrReceivedQty.SizeF = new System.Drawing.SizeF(65F, 22F);
            this.xrReceivedQty.StylePriority.UseBorderColor = false;
            this.xrReceivedQty.StylePriority.UseBorders = false;
            this.xrReceivedQty.StylePriority.UseFont = false;
            this.xrReceivedQty.StylePriority.UseTextAlignment = false;
            this.xrReceivedQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrReceivedQty.TextFormatString = "{0:n2}";
            //
            // xrIssuedQty
            //
            this.xrIssuedQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrIssuedQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrIssuedQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[IssuedQty]")});
            this.xrIssuedQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrIssuedQty.LocationFloat = new DevExpress.Utils.PointFloat(492F, 0F);
            this.xrIssuedQty.Name = "xrIssuedQty";
            this.xrIssuedQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrIssuedQty.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.xrIssuedQty.StylePriority.UseBorderColor = false;
            this.xrIssuedQty.StylePriority.UseBorders = false;
            this.xrIssuedQty.StylePriority.UseFont = false;
            this.xrIssuedQty.StylePriority.UseTextAlignment = false;
            this.xrIssuedQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrIssuedQty.TextFormatString = "{0:n2}";
            //
            // xrTransferInQty
            //
            this.xrTransferInQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrTransferInQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrTransferInQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TransferInQty]")});
            this.xrTransferInQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrTransferInQty.LocationFloat = new DevExpress.Utils.PointFloat(422F, 0F);
            this.xrTransferInQty.Name = "xrTransferInQty";
            this.xrTransferInQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTransferInQty.SizeF = new System.Drawing.SizeF(70F, 22F);
            this.xrTransferInQty.StylePriority.UseBorderColor = false;
            this.xrTransferInQty.StylePriority.UseBorders = false;
            this.xrTransferInQty.StylePriority.UseFont = false;
            this.xrTransferInQty.StylePriority.UseTextAlignment = false;
            this.xrTransferInQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTransferInQty.TextFormatString = "{0:n2}";
            //
            // xrTransferOutQty
            //
            this.xrTransferOutQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrTransferOutQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrTransferOutQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TransferOutQty]")});
            this.xrTransferOutQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrTransferOutQty.LocationFloat = new DevExpress.Utils.PointFloat(352F, 0F);
            this.xrTransferOutQty.Name = "xrTransferOutQty";
            this.xrTransferOutQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTransferOutQty.SizeF = new System.Drawing.SizeF(70F, 22F);
            this.xrTransferOutQty.StylePriority.UseBorderColor = false;
            this.xrTransferOutQty.StylePriority.UseBorders = false;
            this.xrTransferOutQty.StylePriority.UseFont = false;
            this.xrTransferOutQty.StylePriority.UseTextAlignment = false;
            this.xrTransferOutQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTransferOutQty.TextFormatString = "{0:n2}";
            //
            // xrPurchaseReturnQty
            //
            this.xrPurchaseReturnQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrPurchaseReturnQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrPurchaseReturnQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PurchaseReturnQty]")});
            this.xrPurchaseReturnQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrPurchaseReturnQty.LocationFloat = new DevExpress.Utils.PointFloat(272F, 0F);
            this.xrPurchaseReturnQty.Name = "xrPurchaseReturnQty";
            this.xrPurchaseReturnQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrPurchaseReturnQty.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.xrPurchaseReturnQty.StylePriority.UseBorderColor = false;
            this.xrPurchaseReturnQty.StylePriority.UseBorders = false;
            this.xrPurchaseReturnQty.StylePriority.UseFont = false;
            this.xrPurchaseReturnQty.StylePriority.UseTextAlignment = false;
            this.xrPurchaseReturnQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrPurchaseReturnQty.TextFormatString = "{0:n2}";
            //
            // xrIssueReturnQty
            //
            this.xrIssueReturnQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrIssueReturnQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrIssueReturnQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[IssueReturnQty]")});
            this.xrIssueReturnQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrIssueReturnQty.LocationFloat = new DevExpress.Utils.PointFloat(202F, 0F);
            this.xrIssueReturnQty.Name = "xrIssueReturnQty";
            this.xrIssueReturnQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrIssueReturnQty.SizeF = new System.Drawing.SizeF(70F, 22F);
            this.xrIssueReturnQty.StylePriority.UseBorderColor = false;
            this.xrIssueReturnQty.StylePriority.UseBorders = false;
            this.xrIssueReturnQty.StylePriority.UseFont = false;
            this.xrIssueReturnQty.StylePriority.UseTextAlignment = false;
            this.xrIssueReturnQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrIssueReturnQty.TextFormatString = "{0:n2}";
            //
            // xrClosingQty
            //
            this.xrClosingQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrClosingQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrClosingQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ClosingQty]")});
            this.xrClosingQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrClosingQty.LocationFloat = new DevExpress.Utils.PointFloat(127F, 0F);
            this.xrClosingQty.Name = "xrClosingQty";
            this.xrClosingQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrClosingQty.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.xrClosingQty.StylePriority.UseBorderColor = false;
            this.xrClosingQty.StylePriority.UseBorders = false;
            this.xrClosingQty.StylePriority.UseFont = false;
            this.xrClosingQty.StylePriority.UseTextAlignment = false;
            this.xrClosingQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrClosingQty.TextFormatString = "{0:n2}";
            //
            // ReportFooter
            //
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.xrTotalClosingQty, this.xrTotalLabel});
            this.ReportFooter.HeightF = 30F;
            this.ReportFooter.Name = "ReportFooter";
            //
            // xrTotalLabel
            //
            this.xrTotalLabel.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTotalLabel.LocationFloat = new DevExpress.Utils.PointFloat(202F, 0F);
            this.xrTotalLabel.Name = "xrTotalLabel";
            this.xrTotalLabel.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTotalLabel.SizeF = new System.Drawing.SizeF(490F, 25F);
            this.xrTotalLabel.StylePriority.UseFont = false;
            this.xrTotalLabel.StylePriority.UseTextAlignment = false;
            this.xrTotalLabel.Text = "إجمالي رصيد آخر المدة:";
            this.xrTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrTotalClosingQty
            //
            this.xrTotalClosingQty.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTotalClosingQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ClosingQty]")});
            this.xrTotalClosingQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTotalClosingQty.LocationFloat = new DevExpress.Utils.PointFloat(127F, 0F);
            this.xrTotalClosingQty.Name = "xrTotalClosingQty";
            this.xrTotalClosingQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTotalClosingQty.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.xrTotalClosingQty.StylePriority.UseBorders = false;
            this.xrTotalClosingQty.StylePriority.UseFont = false;
            this.xrTotalClosingQty.StylePriority.UseTextAlignment = false;
            this.xrTotalClosingQty.Summary = new DevExpress.XtraReports.UI.XRSummary(DevExpress.XtraReports.UI.SummaryRunning.Report, DevExpress.XtraReports.UI.SummaryFunc.Sum, "{0:n2}");
            this.xrTotalClosingQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // rptStockMovementPeriod
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                this.TopMargin, this.BottomMargin, this.ReportHeader, this.PageHeader, this.Detail, this.ReportFooter});
            this.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.Margins = new DevExpress.Drawing.DXMargins(63.5F, 63.5F, 20F, 20F);
            this.PageHeightF = 826.7717F;
            this.PageWidthF = 1169.291F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrTitle;
        public DevExpress.XtraReports.UI.XRLabel xrFilterSummary;
        public DevExpress.XtraReports.UI.XRLabel xrPrintDate;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel hdrItemCode;
        private DevExpress.XtraReports.UI.XRLabel hdrItemName;
        private DevExpress.XtraReports.UI.XRLabel hdrUnitAbbr;
        private DevExpress.XtraReports.UI.XRLabel hdrStoreName;
        private DevExpress.XtraReports.UI.XRLabel hdrOpeningQty;
        private DevExpress.XtraReports.UI.XRLabel hdrReceivedQty;
        private DevExpress.XtraReports.UI.XRLabel hdrIssuedQty;
        private DevExpress.XtraReports.UI.XRLabel hdrTransferInQty;
        private DevExpress.XtraReports.UI.XRLabel hdrTransferOutQty;
        private DevExpress.XtraReports.UI.XRLabel hdrPurchaseReturnQty;
        private DevExpress.XtraReports.UI.XRLabel hdrIssueReturnQty;
        private DevExpress.XtraReports.UI.XRLabel hdrClosingQty;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrItemCode;
        private DevExpress.XtraReports.UI.XRLabel xrItemName;
        private DevExpress.XtraReports.UI.XRLabel xrUnitAbbr;
        private DevExpress.XtraReports.UI.XRLabel xrStoreName;
        private DevExpress.XtraReports.UI.XRLabel xrOpeningQty;
        private DevExpress.XtraReports.UI.XRLabel xrReceivedQty;
        private DevExpress.XtraReports.UI.XRLabel xrIssuedQty;
        private DevExpress.XtraReports.UI.XRLabel xrTransferInQty;
        private DevExpress.XtraReports.UI.XRLabel xrTransferOutQty;
        private DevExpress.XtraReports.UI.XRLabel xrPurchaseReturnQty;
        private DevExpress.XtraReports.UI.XRLabel xrIssueReturnQty;
        private DevExpress.XtraReports.UI.XRLabel xrClosingQty;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrTotalLabel;
        private DevExpress.XtraReports.UI.XRLabel xrTotalClosingQty;
    }
}
