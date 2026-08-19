namespace Etmam
{
    partial class rptStockingVariance
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
            this.hdrStockingNum = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrStockingDate = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrStoreName = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrItemCode = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrItemName = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrUnitAbbr = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrSystemQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrDifference = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrDifferenceValue = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrNote = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrStockingNum = new DevExpress.XtraReports.UI.XRLabel();
            this.xrStockingDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrStoreName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrItemCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrItemName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrUnitAbbr = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSystemQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDifference = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDifferenceValue = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNote = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTotalLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTotalDifferenceValue = new DevExpress.XtraReports.UI.XRLabel();
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
            this.xrTitle.Text = "تقرير الجرد وفروقاته";
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
                this.hdrStockingNum, this.hdrStockingDate, this.hdrStoreName, this.hdrItemCode, this.hdrItemName,
                this.hdrUnitAbbr, this.hdrSystemQty, this.hdrQty, this.hdrDifference, this.hdrDifferenceValue, this.hdrNote});
            this.PageHeader.HeightF = 25F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseBackColor = false;
            //
            // hdrStockingNum
            //
            this.hdrStockingNum.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrStockingNum.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrStockingNum.LocationFloat = new DevExpress.Utils.PointFloat(982F, 0F);
            this.hdrStockingNum.Name = "hdrStockingNum";
            this.hdrStockingNum.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrStockingNum.SizeF = new System.Drawing.SizeF(60F, 25F);
            this.hdrStockingNum.StylePriority.UseBorders = false;
            this.hdrStockingNum.StylePriority.UseFont = false;
            this.hdrStockingNum.StylePriority.UseTextAlignment = false;
            this.hdrStockingNum.Text = "رقم الجرد";
            this.hdrStockingNum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrStockingDate
            //
            this.hdrStockingDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrStockingDate.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrStockingDate.LocationFloat = new DevExpress.Utils.PointFloat(907F, 0F);
            this.hdrStockingDate.Name = "hdrStockingDate";
            this.hdrStockingDate.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrStockingDate.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.hdrStockingDate.StylePriority.UseBorders = false;
            this.hdrStockingDate.StylePriority.UseFont = false;
            this.hdrStockingDate.StylePriority.UseTextAlignment = false;
            this.hdrStockingDate.Text = "تاريخ الجرد";
            this.hdrStockingDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrStoreName
            //
            this.hdrStoreName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrStoreName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrStoreName.LocationFloat = new DevExpress.Utils.PointFloat(817F, 0F);
            this.hdrStoreName.Name = "hdrStoreName";
            this.hdrStoreName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrStoreName.SizeF = new System.Drawing.SizeF(90F, 25F);
            this.hdrStoreName.StylePriority.UseBorders = false;
            this.hdrStoreName.StylePriority.UseFont = false;
            this.hdrStoreName.StylePriority.UseTextAlignment = false;
            this.hdrStoreName.Text = "المخزن";
            this.hdrStoreName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrItemCode
            //
            this.hdrItemCode.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrItemCode.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrItemCode.LocationFloat = new DevExpress.Utils.PointFloat(747F, 0F);
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
            this.hdrItemName.LocationFloat = new DevExpress.Utils.PointFloat(607F, 0F);
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
            this.hdrUnitAbbr.LocationFloat = new DevExpress.Utils.PointFloat(562F, 0F);
            this.hdrUnitAbbr.Name = "hdrUnitAbbr";
            this.hdrUnitAbbr.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrUnitAbbr.SizeF = new System.Drawing.SizeF(45F, 25F);
            this.hdrUnitAbbr.StylePriority.UseBorders = false;
            this.hdrUnitAbbr.StylePriority.UseFont = false;
            this.hdrUnitAbbr.StylePriority.UseTextAlignment = false;
            this.hdrUnitAbbr.Text = "الوحدة";
            this.hdrUnitAbbr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrSystemQty
            //
            this.hdrSystemQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrSystemQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrSystemQty.LocationFloat = new DevExpress.Utils.PointFloat(487F, 0F);
            this.hdrSystemQty.Name = "hdrSystemQty";
            this.hdrSystemQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrSystemQty.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.hdrSystemQty.StylePriority.UseBorders = false;
            this.hdrSystemQty.StylePriority.UseFont = false;
            this.hdrSystemQty.StylePriority.UseTextAlignment = false;
            this.hdrSystemQty.Text = "الرصيد الدفتري";
            this.hdrSystemQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrQty
            //
            this.hdrQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrQty.LocationFloat = new DevExpress.Utils.PointFloat(417F, 0F);
            this.hdrQty.Name = "hdrQty";
            this.hdrQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrQty.SizeF = new System.Drawing.SizeF(70F, 25F);
            this.hdrQty.StylePriority.UseBorders = false;
            this.hdrQty.StylePriority.UseFont = false;
            this.hdrQty.StylePriority.UseTextAlignment = false;
            this.hdrQty.Text = "الكمية الفعلية";
            this.hdrQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrDifference
            //
            this.hdrDifference.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrDifference.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrDifference.LocationFloat = new DevExpress.Utils.PointFloat(347F, 0F);
            this.hdrDifference.Name = "hdrDifference";
            this.hdrDifference.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrDifference.SizeF = new System.Drawing.SizeF(70F, 25F);
            this.hdrDifference.StylePriority.UseBorders = false;
            this.hdrDifference.StylePriority.UseFont = false;
            this.hdrDifference.StylePriority.UseTextAlignment = false;
            this.hdrDifference.Text = "الفرق (كمية)";
            this.hdrDifference.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrDifferenceValue
            //
            this.hdrDifferenceValue.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrDifferenceValue.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrDifferenceValue.LocationFloat = new DevExpress.Utils.PointFloat(267F, 0F);
            this.hdrDifferenceValue.Name = "hdrDifferenceValue";
            this.hdrDifferenceValue.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrDifferenceValue.SizeF = new System.Drawing.SizeF(80F, 25F);
            this.hdrDifferenceValue.StylePriority.UseBorders = false;
            this.hdrDifferenceValue.StylePriority.UseFont = false;
            this.hdrDifferenceValue.StylePriority.UseTextAlignment = false;
            this.hdrDifferenceValue.Text = "الفرق (قيمة)";
            this.hdrDifferenceValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrNote
            //
            this.hdrNote.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrNote.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrNote.LocationFloat = new DevExpress.Utils.PointFloat(147F, 0F);
            this.hdrNote.Name = "hdrNote";
            this.hdrNote.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrNote.SizeF = new System.Drawing.SizeF(120F, 25F);
            this.hdrNote.StylePriority.UseBorders = false;
            this.hdrNote.StylePriority.UseFont = false;
            this.hdrNote.StylePriority.UseTextAlignment = false;
            this.hdrNote.Text = "ملاحظات";
            this.hdrNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.xrStockingNum, this.xrStockingDate, this.xrStoreName, this.xrItemCode, this.xrItemName,
                this.xrUnitAbbr, this.xrSystemQty, this.xrQty, this.xrDifference, this.xrDifferenceValue, this.xrNote});
            this.Detail.HeightF = 22F;
            this.Detail.Name = "Detail";
            //
            // xrStockingNum
            //
            this.xrStockingNum.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrStockingNum.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrStockingNum.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StockingNum]")});
            this.xrStockingNum.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrStockingNum.LocationFloat = new DevExpress.Utils.PointFloat(982F, 0F);
            this.xrStockingNum.Name = "xrStockingNum";
            this.xrStockingNum.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrStockingNum.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.xrStockingNum.StylePriority.UseBorderColor = false;
            this.xrStockingNum.StylePriority.UseBorders = false;
            this.xrStockingNum.StylePriority.UseFont = false;
            this.xrStockingNum.StylePriority.UseTextAlignment = false;
            this.xrStockingNum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrStockingDate
            //
            this.xrStockingDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrStockingDate.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrStockingDate.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StockingDate]")});
            this.xrStockingDate.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrStockingDate.LocationFloat = new DevExpress.Utils.PointFloat(907F, 0F);
            this.xrStockingDate.Name = "xrStockingDate";
            this.xrStockingDate.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrStockingDate.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.xrStockingDate.StylePriority.UseBorderColor = false;
            this.xrStockingDate.StylePriority.UseBorders = false;
            this.xrStockingDate.StylePriority.UseFont = false;
            this.xrStockingDate.StylePriority.UseTextAlignment = false;
            this.xrStockingDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrStockingDate.TextFormatString = "{0:yyyy-MM-dd}";
            //
            // xrStoreName
            //
            this.xrStoreName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrStoreName.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrStoreName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StoreName]")});
            this.xrStoreName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrStoreName.LocationFloat = new DevExpress.Utils.PointFloat(817F, 0F);
            this.xrStoreName.Name = "xrStoreName";
            this.xrStoreName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrStoreName.SizeF = new System.Drawing.SizeF(90F, 22F);
            this.xrStoreName.StylePriority.UseBorderColor = false;
            this.xrStoreName.StylePriority.UseBorders = false;
            this.xrStoreName.StylePriority.UseFont = false;
            this.xrStoreName.StylePriority.UseTextAlignment = false;
            this.xrStoreName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrItemCode
            //
            this.xrItemCode.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrItemCode.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrItemCode.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ItemCode]")});
            this.xrItemCode.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrItemCode.LocationFloat = new DevExpress.Utils.PointFloat(747F, 0F);
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
            this.xrItemName.LocationFloat = new DevExpress.Utils.PointFloat(607F, 0F);
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
            this.xrUnitAbbr.LocationFloat = new DevExpress.Utils.PointFloat(562F, 0F);
            this.xrUnitAbbr.Name = "xrUnitAbbr";
            this.xrUnitAbbr.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrUnitAbbr.SizeF = new System.Drawing.SizeF(45F, 22F);
            this.xrUnitAbbr.StylePriority.UseBorderColor = false;
            this.xrUnitAbbr.StylePriority.UseBorders = false;
            this.xrUnitAbbr.StylePriority.UseFont = false;
            this.xrUnitAbbr.StylePriority.UseTextAlignment = false;
            this.xrUnitAbbr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrSystemQty
            //
            this.xrSystemQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrSystemQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrSystemQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SystemQty]")});
            this.xrSystemQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrSystemQty.LocationFloat = new DevExpress.Utils.PointFloat(487F, 0F);
            this.xrSystemQty.Name = "xrSystemQty";
            this.xrSystemQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrSystemQty.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.xrSystemQty.StylePriority.UseBorderColor = false;
            this.xrSystemQty.StylePriority.UseBorders = false;
            this.xrSystemQty.StylePriority.UseFont = false;
            this.xrSystemQty.StylePriority.UseTextAlignment = false;
            this.xrSystemQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrSystemQty.TextFormatString = "{0:n2}";
            //
            // xrQty
            //
            this.xrQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrQty.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")});
            this.xrQty.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrQty.LocationFloat = new DevExpress.Utils.PointFloat(417F, 0F);
            this.xrQty.Name = "xrQty";
            this.xrQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrQty.SizeF = new System.Drawing.SizeF(70F, 22F);
            this.xrQty.StylePriority.UseBorderColor = false;
            this.xrQty.StylePriority.UseBorders = false;
            this.xrQty.StylePriority.UseFont = false;
            this.xrQty.StylePriority.UseTextAlignment = false;
            this.xrQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrQty.TextFormatString = "{0:n2}";
            //
            // xrDifference
            //
            this.xrDifference.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrDifference.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrDifference.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Difference]")});
            this.xrDifference.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrDifference.LocationFloat = new DevExpress.Utils.PointFloat(347F, 0F);
            this.xrDifference.Name = "xrDifference";
            this.xrDifference.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrDifference.SizeF = new System.Drawing.SizeF(70F, 22F);
            this.xrDifference.StylePriority.UseBorderColor = false;
            this.xrDifference.StylePriority.UseBorders = false;
            this.xrDifference.StylePriority.UseFont = false;
            this.xrDifference.StylePriority.UseTextAlignment = false;
            this.xrDifference.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrDifference.TextFormatString = "{0:n2}";
            //
            // xrDifferenceValue
            //
            this.xrDifferenceValue.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrDifferenceValue.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrDifferenceValue.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DifferenceValue]")});
            this.xrDifferenceValue.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrDifferenceValue.LocationFloat = new DevExpress.Utils.PointFloat(267F, 0F);
            this.xrDifferenceValue.Name = "xrDifferenceValue";
            this.xrDifferenceValue.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrDifferenceValue.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.xrDifferenceValue.StylePriority.UseBorderColor = false;
            this.xrDifferenceValue.StylePriority.UseBorders = false;
            this.xrDifferenceValue.StylePriority.UseFont = false;
            this.xrDifferenceValue.StylePriority.UseTextAlignment = false;
            this.xrDifferenceValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrDifferenceValue.TextFormatString = "{0:n2}";
            //
            // xrNote
            //
            this.xrNote.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrNote.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrNote.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Note]")});
            this.xrNote.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 8F);
            this.xrNote.LocationFloat = new DevExpress.Utils.PointFloat(147F, 0F);
            this.xrNote.Name = "xrNote";
            this.xrNote.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrNote.SizeF = new System.Drawing.SizeF(120F, 22F);
            this.xrNote.StylePriority.UseBorderColor = false;
            this.xrNote.StylePriority.UseBorders = false;
            this.xrNote.StylePriority.UseFont = false;
            this.xrNote.StylePriority.UseTextAlignment = false;
            this.xrNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // ReportFooter
            //
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.xrTotalDifferenceValue, this.xrTotalLabel});
            this.ReportFooter.HeightF = 30F;
            this.ReportFooter.Name = "ReportFooter";
            //
            // xrTotalLabel
            //
            this.xrTotalLabel.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTotalLabel.LocationFloat = new DevExpress.Utils.PointFloat(347F, 0F);
            this.xrTotalLabel.Name = "xrTotalLabel";
            this.xrTotalLabel.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTotalLabel.SizeF = new System.Drawing.SizeF(360F, 25F);
            this.xrTotalLabel.StylePriority.UseFont = false;
            this.xrTotalLabel.StylePriority.UseTextAlignment = false;
            this.xrTotalLabel.Text = "إجمالي الفرق (قيمة):";
            this.xrTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrTotalDifferenceValue
            //
            this.xrTotalDifferenceValue.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTotalDifferenceValue.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DifferenceValue]")});
            this.xrTotalDifferenceValue.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTotalDifferenceValue.LocationFloat = new DevExpress.Utils.PointFloat(267F, 0F);
            this.xrTotalDifferenceValue.Name = "xrTotalDifferenceValue";
            this.xrTotalDifferenceValue.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTotalDifferenceValue.SizeF = new System.Drawing.SizeF(80F, 25F);
            this.xrTotalDifferenceValue.StylePriority.UseBorders = false;
            this.xrTotalDifferenceValue.StylePriority.UseFont = false;
            this.xrTotalDifferenceValue.StylePriority.UseTextAlignment = false;
            this.xrTotalDifferenceValue.Summary = new DevExpress.XtraReports.UI.XRSummary(DevExpress.XtraReports.UI.SummaryRunning.Report, DevExpress.XtraReports.UI.SummaryFunc.Sum, "{0:n2}");
            this.xrTotalDifferenceValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // rptStockingVariance
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
        private DevExpress.XtraReports.UI.XRLabel hdrStockingNum;
        private DevExpress.XtraReports.UI.XRLabel hdrStockingDate;
        private DevExpress.XtraReports.UI.XRLabel hdrStoreName;
        private DevExpress.XtraReports.UI.XRLabel hdrItemCode;
        private DevExpress.XtraReports.UI.XRLabel hdrItemName;
        private DevExpress.XtraReports.UI.XRLabel hdrUnitAbbr;
        private DevExpress.XtraReports.UI.XRLabel hdrSystemQty;
        private DevExpress.XtraReports.UI.XRLabel hdrQty;
        private DevExpress.XtraReports.UI.XRLabel hdrDifference;
        private DevExpress.XtraReports.UI.XRLabel hdrDifferenceValue;
        private DevExpress.XtraReports.UI.XRLabel hdrNote;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrStockingNum;
        private DevExpress.XtraReports.UI.XRLabel xrStockingDate;
        private DevExpress.XtraReports.UI.XRLabel xrStoreName;
        private DevExpress.XtraReports.UI.XRLabel xrItemCode;
        private DevExpress.XtraReports.UI.XRLabel xrItemName;
        private DevExpress.XtraReports.UI.XRLabel xrUnitAbbr;
        private DevExpress.XtraReports.UI.XRLabel xrSystemQty;
        private DevExpress.XtraReports.UI.XRLabel xrQty;
        private DevExpress.XtraReports.UI.XRLabel xrDifference;
        private DevExpress.XtraReports.UI.XRLabel xrDifferenceValue;
        private DevExpress.XtraReports.UI.XRLabel xrNote;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrTotalLabel;
        private DevExpress.XtraReports.UI.XRLabel xrTotalDifferenceValue;
    }
}
