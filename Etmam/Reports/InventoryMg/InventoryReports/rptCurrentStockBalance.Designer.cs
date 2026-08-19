namespace Etmam
{
    partial class rptCurrentStockBalance
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
            this.hdrCategoryName = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrStoreName = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrUnitAbbr = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrBalance = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrItemCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrItemName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCategoryName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrStoreName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrUnitAbbr = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBalance = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTotalLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTotalBalance = new DevExpress.XtraReports.UI.XRLabel();
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
            this.xrTitle.Text = "تقرير رصيد المخزون الحالي";
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
                this.hdrItemCode, this.hdrItemName, this.hdrCategoryName, this.hdrStoreName, this.hdrUnitAbbr, this.hdrBalance});
            this.PageHeader.HeightF = 25F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseBackColor = false;
            //
            // hdrItemCode
            //
            this.hdrItemCode.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrItemCode.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrItemCode.LocationFloat = new DevExpress.Utils.PointFloat(952F, 0F);
            this.hdrItemCode.Name = "hdrItemCode";
            this.hdrItemCode.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrItemCode.SizeF = new System.Drawing.SizeF(90F, 25F);
            this.hdrItemCode.StylePriority.UseBorders = false;
            this.hdrItemCode.StylePriority.UseFont = false;
            this.hdrItemCode.StylePriority.UseTextAlignment = false;
            this.hdrItemCode.Text = "رمز الصنف";
            this.hdrItemCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrItemName
            //
            this.hdrItemName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrItemName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrItemName.LocationFloat = new DevExpress.Utils.PointFloat(732F, 0F);
            this.hdrItemName.Name = "hdrItemName";
            this.hdrItemName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrItemName.SizeF = new System.Drawing.SizeF(220F, 25F);
            this.hdrItemName.StylePriority.UseBorders = false;
            this.hdrItemName.StylePriority.UseFont = false;
            this.hdrItemName.StylePriority.UseTextAlignment = false;
            this.hdrItemName.Text = "اسم الصنف";
            this.hdrItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrCategoryName
            //
            this.hdrCategoryName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrCategoryName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrCategoryName.LocationFloat = new DevExpress.Utils.PointFloat(582F, 0F);
            this.hdrCategoryName.Name = "hdrCategoryName";
            this.hdrCategoryName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrCategoryName.SizeF = new System.Drawing.SizeF(150F, 25F);
            this.hdrCategoryName.StylePriority.UseBorders = false;
            this.hdrCategoryName.StylePriority.UseFont = false;
            this.hdrCategoryName.StylePriority.UseTextAlignment = false;
            this.hdrCategoryName.Text = "التصنيف";
            this.hdrCategoryName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrStoreName
            //
            this.hdrStoreName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrStoreName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrStoreName.LocationFloat = new DevExpress.Utils.PointFloat(432F, 0F);
            this.hdrStoreName.Name = "hdrStoreName";
            this.hdrStoreName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrStoreName.SizeF = new System.Drawing.SizeF(150F, 25F);
            this.hdrStoreName.StylePriority.UseBorders = false;
            this.hdrStoreName.StylePriority.UseFont = false;
            this.hdrStoreName.StylePriority.UseTextAlignment = false;
            this.hdrStoreName.Text = "المخزن";
            this.hdrStoreName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrUnitAbbr
            //
            this.hdrUnitAbbr.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrUnitAbbr.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrUnitAbbr.LocationFloat = new DevExpress.Utils.PointFloat(362F, 0F);
            this.hdrUnitAbbr.Name = "hdrUnitAbbr";
            this.hdrUnitAbbr.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrUnitAbbr.SizeF = new System.Drawing.SizeF(70F, 25F);
            this.hdrUnitAbbr.StylePriority.UseBorders = false;
            this.hdrUnitAbbr.StylePriority.UseFont = false;
            this.hdrUnitAbbr.StylePriority.UseTextAlignment = false;
            this.hdrUnitAbbr.Text = "الوحدة";
            this.hdrUnitAbbr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrBalance
            //
            this.hdrBalance.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrBalance.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrBalance.LocationFloat = new DevExpress.Utils.PointFloat(252F, 0F);
            this.hdrBalance.Name = "hdrBalance";
            this.hdrBalance.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrBalance.SizeF = new System.Drawing.SizeF(110F, 25F);
            this.hdrBalance.StylePriority.UseBorders = false;
            this.hdrBalance.StylePriority.UseFont = false;
            this.hdrBalance.StylePriority.UseTextAlignment = false;
            this.hdrBalance.Text = "الرصيد";
            this.hdrBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.xrItemCode, this.xrItemName, this.xrCategoryName, this.xrStoreName, this.xrUnitAbbr, this.xrBalance});
            this.Detail.HeightF = 22F;
            this.Detail.Name = "Detail";
            //
            // xrItemCode
            //
            this.xrItemCode.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrItemCode.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrItemCode.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ItemCode]")});
            this.xrItemCode.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrItemCode.LocationFloat = new DevExpress.Utils.PointFloat(952F, 0F);
            this.xrItemCode.Name = "xrItemCode";
            this.xrItemCode.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrItemCode.SizeF = new System.Drawing.SizeF(90F, 22F);
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
            this.xrItemName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrItemName.LocationFloat = new DevExpress.Utils.PointFloat(732F, 0F);
            this.xrItemName.Name = "xrItemName";
            this.xrItemName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrItemName.SizeF = new System.Drawing.SizeF(220F, 22F);
            this.xrItemName.StylePriority.UseBorderColor = false;
            this.xrItemName.StylePriority.UseBorders = false;
            this.xrItemName.StylePriority.UseFont = false;
            this.xrItemName.StylePriority.UseTextAlignment = false;
            this.xrItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // xrCategoryName
            //
            this.xrCategoryName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrCategoryName.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrCategoryName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CategoryName]")});
            this.xrCategoryName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrCategoryName.LocationFloat = new DevExpress.Utils.PointFloat(582F, 0F);
            this.xrCategoryName.Name = "xrCategoryName";
            this.xrCategoryName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrCategoryName.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.xrCategoryName.StylePriority.UseBorderColor = false;
            this.xrCategoryName.StylePriority.UseBorders = false;
            this.xrCategoryName.StylePriority.UseFont = false;
            this.xrCategoryName.StylePriority.UseTextAlignment = false;
            this.xrCategoryName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrStoreName
            //
            this.xrStoreName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrStoreName.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrStoreName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StoreName]")});
            this.xrStoreName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrStoreName.LocationFloat = new DevExpress.Utils.PointFloat(432F, 0F);
            this.xrStoreName.Name = "xrStoreName";
            this.xrStoreName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrStoreName.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.xrStoreName.StylePriority.UseBorderColor = false;
            this.xrStoreName.StylePriority.UseBorders = false;
            this.xrStoreName.StylePriority.UseFont = false;
            this.xrStoreName.StylePriority.UseTextAlignment = false;
            this.xrStoreName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrUnitAbbr
            //
            this.xrUnitAbbr.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrUnitAbbr.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrUnitAbbr.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UnitAbbr]")});
            this.xrUnitAbbr.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrUnitAbbr.LocationFloat = new DevExpress.Utils.PointFloat(362F, 0F);
            this.xrUnitAbbr.Name = "xrUnitAbbr";
            this.xrUnitAbbr.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrUnitAbbr.SizeF = new System.Drawing.SizeF(70F, 22F);
            this.xrUnitAbbr.StylePriority.UseBorderColor = false;
            this.xrUnitAbbr.StylePriority.UseBorders = false;
            this.xrUnitAbbr.StylePriority.UseFont = false;
            this.xrUnitAbbr.StylePriority.UseTextAlignment = false;
            this.xrUnitAbbr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrBalance
            //
            this.xrBalance.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrBalance.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrBalance.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Balance]")});
            this.xrBalance.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrBalance.LocationFloat = new DevExpress.Utils.PointFloat(252F, 0F);
            this.xrBalance.Name = "xrBalance";
            this.xrBalance.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrBalance.SizeF = new System.Drawing.SizeF(110F, 22F);
            this.xrBalance.StylePriority.UseBorderColor = false;
            this.xrBalance.StylePriority.UseBorders = false;
            this.xrBalance.StylePriority.UseFont = false;
            this.xrBalance.StylePriority.UseTextAlignment = false;
            this.xrBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrBalance.TextFormatString = "{0:n2}";
            //
            // ReportFooter
            //
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.xrTotalBalance, this.xrTotalLabel});
            this.ReportFooter.HeightF = 30F;
            this.ReportFooter.Name = "ReportFooter";
            //
            // xrTotalLabel
            //
            this.xrTotalLabel.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTotalLabel.LocationFloat = new DevExpress.Utils.PointFloat(432F, 0F);
            this.xrTotalLabel.Name = "xrTotalLabel";
            this.xrTotalLabel.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTotalLabel.SizeF = new System.Drawing.SizeF(300F, 25F);
            this.xrTotalLabel.StylePriority.UseFont = false;
            this.xrTotalLabel.StylePriority.UseTextAlignment = false;
            this.xrTotalLabel.Text = "الإجمالي:";
            this.xrTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrTotalBalance
            //
            this.xrTotalBalance.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTotalBalance.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Balance]")});
            this.xrTotalBalance.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTotalBalance.LocationFloat = new DevExpress.Utils.PointFloat(252F, 0F);
            this.xrTotalBalance.Name = "xrTotalBalance";
            this.xrTotalBalance.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTotalBalance.SizeF = new System.Drawing.SizeF(110F, 25F);
            this.xrTotalBalance.StylePriority.UseBorders = false;
            this.xrTotalBalance.StylePriority.UseFont = false;
            this.xrTotalBalance.StylePriority.UseTextAlignment = false;
            this.xrTotalBalance.Summary = new DevExpress.XtraReports.UI.XRSummary(DevExpress.XtraReports.UI.SummaryRunning.Report, DevExpress.XtraReports.UI.SummaryFunc.Sum, "{0:n2}");
            this.xrTotalBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // rptCurrentStockBalance
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                this.TopMargin, this.BottomMargin, this.ReportHeader, this.PageHeader, this.Detail, this.ReportFooter});
            this.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
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
        private DevExpress.XtraReports.UI.XRLabel hdrCategoryName;
        private DevExpress.XtraReports.UI.XRLabel hdrStoreName;
        private DevExpress.XtraReports.UI.XRLabel hdrUnitAbbr;
        private DevExpress.XtraReports.UI.XRLabel hdrBalance;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrItemCode;
        private DevExpress.XtraReports.UI.XRLabel xrItemName;
        private DevExpress.XtraReports.UI.XRLabel xrCategoryName;
        private DevExpress.XtraReports.UI.XRLabel xrStoreName;
        private DevExpress.XtraReports.UI.XRLabel xrUnitAbbr;
        private DevExpress.XtraReports.UI.XRLabel xrBalance;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrTotalLabel;
        private DevExpress.XtraReports.UI.XRLabel xrTotalBalance;
    }
}
