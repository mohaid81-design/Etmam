namespace Etmam
{
    partial class rptItemStockCard
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
            this.hdrMovementDate = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrMovementType = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrDocumentNum = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrCounterpartyStoreName = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrQtyIn = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrQtyOut = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrRunningBalance = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrNote = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrMovementDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrMovementType = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDocumentNum = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCounterpartyStoreName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrQtyIn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrQtyOut = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRunningBalance = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNote = new DevExpress.XtraReports.UI.XRLabel();
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
            this.xrTitle.Text = "كارت الصنف (كشف حركة صنف)";
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
                this.hdrMovementDate, this.hdrMovementType, this.hdrDocumentNum, this.hdrCounterpartyStoreName,
                this.hdrQtyIn, this.hdrQtyOut, this.hdrRunningBalance, this.hdrNote});
            this.PageHeader.HeightF = 25F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseBackColor = false;
            //
            // hdrMovementDate
            //
            this.hdrMovementDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrMovementDate.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrMovementDate.LocationFloat = new DevExpress.Utils.PointFloat(967F, 0F);
            this.hdrMovementDate.Name = "hdrMovementDate";
            this.hdrMovementDate.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrMovementDate.SizeF = new System.Drawing.SizeF(75F, 25F);
            this.hdrMovementDate.StylePriority.UseBorders = false;
            this.hdrMovementDate.StylePriority.UseFont = false;
            this.hdrMovementDate.StylePriority.UseTextAlignment = false;
            this.hdrMovementDate.Text = "التاريخ";
            this.hdrMovementDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrMovementType
            //
            this.hdrMovementType.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrMovementType.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrMovementType.LocationFloat = new DevExpress.Utils.PointFloat(877F, 0F);
            this.hdrMovementType.Name = "hdrMovementType";
            this.hdrMovementType.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrMovementType.SizeF = new System.Drawing.SizeF(90F, 25F);
            this.hdrMovementType.StylePriority.UseBorders = false;
            this.hdrMovementType.StylePriority.UseFont = false;
            this.hdrMovementType.StylePriority.UseTextAlignment = false;
            this.hdrMovementType.Text = "نوع الحركة";
            this.hdrMovementType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrDocumentNum
            //
            this.hdrDocumentNum.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrDocumentNum.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrDocumentNum.LocationFloat = new DevExpress.Utils.PointFloat(797F, 0F);
            this.hdrDocumentNum.Name = "hdrDocumentNum";
            this.hdrDocumentNum.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrDocumentNum.SizeF = new System.Drawing.SizeF(80F, 25F);
            this.hdrDocumentNum.StylePriority.UseBorders = false;
            this.hdrDocumentNum.StylePriority.UseFont = false;
            this.hdrDocumentNum.StylePriority.UseTextAlignment = false;
            this.hdrDocumentNum.Text = "رقم المستند";
            this.hdrDocumentNum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrCounterpartyStoreName
            //
            this.hdrCounterpartyStoreName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrCounterpartyStoreName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrCounterpartyStoreName.LocationFloat = new DevExpress.Utils.PointFloat(687F, 0F);
            this.hdrCounterpartyStoreName.Name = "hdrCounterpartyStoreName";
            this.hdrCounterpartyStoreName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrCounterpartyStoreName.SizeF = new System.Drawing.SizeF(110F, 25F);
            this.hdrCounterpartyStoreName.StylePriority.UseBorders = false;
            this.hdrCounterpartyStoreName.StylePriority.UseFont = false;
            this.hdrCounterpartyStoreName.StylePriority.UseTextAlignment = false;
            this.hdrCounterpartyStoreName.Text = "المخزن الآخر";
            this.hdrCounterpartyStoreName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrQtyIn
            //
            this.hdrQtyIn.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrQtyIn.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrQtyIn.LocationFloat = new DevExpress.Utils.PointFloat(617F, 0F);
            this.hdrQtyIn.Name = "hdrQtyIn";
            this.hdrQtyIn.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrQtyIn.SizeF = new System.Drawing.SizeF(70F, 25F);
            this.hdrQtyIn.StylePriority.UseBorders = false;
            this.hdrQtyIn.StylePriority.UseFont = false;
            this.hdrQtyIn.StylePriority.UseTextAlignment = false;
            this.hdrQtyIn.Text = "وارد";
            this.hdrQtyIn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrQtyOut
            //
            this.hdrQtyOut.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrQtyOut.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrQtyOut.LocationFloat = new DevExpress.Utils.PointFloat(547F, 0F);
            this.hdrQtyOut.Name = "hdrQtyOut";
            this.hdrQtyOut.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrQtyOut.SizeF = new System.Drawing.SizeF(70F, 25F);
            this.hdrQtyOut.StylePriority.UseBorders = false;
            this.hdrQtyOut.StylePriority.UseFont = false;
            this.hdrQtyOut.StylePriority.UseTextAlignment = false;
            this.hdrQtyOut.Text = "صادر";
            this.hdrQtyOut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrRunningBalance
            //
            this.hdrRunningBalance.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrRunningBalance.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrRunningBalance.LocationFloat = new DevExpress.Utils.PointFloat(457F, 0F);
            this.hdrRunningBalance.Name = "hdrRunningBalance";
            this.hdrRunningBalance.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrRunningBalance.SizeF = new System.Drawing.SizeF(90F, 25F);
            this.hdrRunningBalance.StylePriority.UseBorders = false;
            this.hdrRunningBalance.StylePriority.UseFont = false;
            this.hdrRunningBalance.StylePriority.UseTextAlignment = false;
            this.hdrRunningBalance.Text = "الرصيد الجاري";
            this.hdrRunningBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // hdrNote
            //
            this.hdrNote.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.hdrNote.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.hdrNote.LocationFloat = new DevExpress.Utils.PointFloat(307F, 0F);
            this.hdrNote.Name = "hdrNote";
            this.hdrNote.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.hdrNote.SizeF = new System.Drawing.SizeF(150F, 25F);
            this.hdrNote.StylePriority.UseBorders = false;
            this.hdrNote.StylePriority.UseFont = false;
            this.hdrNote.StylePriority.UseTextAlignment = false;
            this.hdrNote.Text = "ملاحظات";
            this.hdrNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.xrMovementDate, this.xrMovementType, this.xrDocumentNum, this.xrCounterpartyStoreName,
                this.xrQtyIn, this.xrQtyOut, this.xrRunningBalance, this.xrNote});
            this.Detail.HeightF = 22F;
            this.Detail.Name = "Detail";
            //
            // xrMovementDate
            //
            this.xrMovementDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrMovementDate.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrMovementDate.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MovementDate]")});
            this.xrMovementDate.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrMovementDate.LocationFloat = new DevExpress.Utils.PointFloat(967F, 0F);
            this.xrMovementDate.Name = "xrMovementDate";
            this.xrMovementDate.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrMovementDate.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.xrMovementDate.StylePriority.UseBorderColor = false;
            this.xrMovementDate.StylePriority.UseBorders = false;
            this.xrMovementDate.StylePriority.UseFont = false;
            this.xrMovementDate.StylePriority.UseTextAlignment = false;
            this.xrMovementDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrMovementDate.TextFormatString = "{0:yyyy-MM-dd}";
            //
            // xrMovementType
            //
            this.xrMovementType.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrMovementType.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrMovementType.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MovementType]")});
            this.xrMovementType.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrMovementType.LocationFloat = new DevExpress.Utils.PointFloat(877F, 0F);
            this.xrMovementType.Name = "xrMovementType";
            this.xrMovementType.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrMovementType.SizeF = new System.Drawing.SizeF(90F, 22F);
            this.xrMovementType.StylePriority.UseBorderColor = false;
            this.xrMovementType.StylePriority.UseBorders = false;
            this.xrMovementType.StylePriority.UseFont = false;
            this.xrMovementType.StylePriority.UseTextAlignment = false;
            this.xrMovementType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrDocumentNum
            //
            this.xrDocumentNum.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrDocumentNum.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrDocumentNum.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DocumentNum]")});
            this.xrDocumentNum.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrDocumentNum.LocationFloat = new DevExpress.Utils.PointFloat(797F, 0F);
            this.xrDocumentNum.Name = "xrDocumentNum";
            this.xrDocumentNum.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrDocumentNum.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.xrDocumentNum.StylePriority.UseBorderColor = false;
            this.xrDocumentNum.StylePriority.UseBorders = false;
            this.xrDocumentNum.StylePriority.UseFont = false;
            this.xrDocumentNum.StylePriority.UseTextAlignment = false;
            this.xrDocumentNum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrCounterpartyStoreName
            //
            this.xrCounterpartyStoreName.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrCounterpartyStoreName.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrCounterpartyStoreName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CounterpartyStoreName]")});
            this.xrCounterpartyStoreName.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrCounterpartyStoreName.LocationFloat = new DevExpress.Utils.PointFloat(687F, 0F);
            this.xrCounterpartyStoreName.Name = "xrCounterpartyStoreName";
            this.xrCounterpartyStoreName.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrCounterpartyStoreName.SizeF = new System.Drawing.SizeF(110F, 22F);
            this.xrCounterpartyStoreName.StylePriority.UseBorderColor = false;
            this.xrCounterpartyStoreName.StylePriority.UseBorders = false;
            this.xrCounterpartyStoreName.StylePriority.UseFont = false;
            this.xrCounterpartyStoreName.StylePriority.UseTextAlignment = false;
            this.xrCounterpartyStoreName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // xrQtyIn
            //
            this.xrQtyIn.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrQtyIn.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrQtyIn.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[QtyIn]")});
            this.xrQtyIn.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrQtyIn.LocationFloat = new DevExpress.Utils.PointFloat(617F, 0F);
            this.xrQtyIn.Name = "xrQtyIn";
            this.xrQtyIn.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrQtyIn.SizeF = new System.Drawing.SizeF(70F, 22F);
            this.xrQtyIn.StylePriority.UseBorderColor = false;
            this.xrQtyIn.StylePriority.UseBorders = false;
            this.xrQtyIn.StylePriority.UseFont = false;
            this.xrQtyIn.StylePriority.UseTextAlignment = false;
            this.xrQtyIn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrQtyIn.TextFormatString = "{0:n2}";
            //
            // xrQtyOut
            //
            this.xrQtyOut.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrQtyOut.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrQtyOut.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[QtyOut]")});
            this.xrQtyOut.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrQtyOut.LocationFloat = new DevExpress.Utils.PointFloat(547F, 0F);
            this.xrQtyOut.Name = "xrQtyOut";
            this.xrQtyOut.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrQtyOut.SizeF = new System.Drawing.SizeF(70F, 22F);
            this.xrQtyOut.StylePriority.UseBorderColor = false;
            this.xrQtyOut.StylePriority.UseBorders = false;
            this.xrQtyOut.StylePriority.UseFont = false;
            this.xrQtyOut.StylePriority.UseTextAlignment = false;
            this.xrQtyOut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrQtyOut.TextFormatString = "{0:n2}";
            //
            // xrRunningBalance
            //
            this.xrRunningBalance.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrRunningBalance.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrRunningBalance.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RunningBalance]")});
            this.xrRunningBalance.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrRunningBalance.LocationFloat = new DevExpress.Utils.PointFloat(457F, 0F);
            this.xrRunningBalance.Name = "xrRunningBalance";
            this.xrRunningBalance.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrRunningBalance.SizeF = new System.Drawing.SizeF(90F, 22F);
            this.xrRunningBalance.StylePriority.UseBorderColor = false;
            this.xrRunningBalance.StylePriority.UseBorders = false;
            this.xrRunningBalance.StylePriority.UseFont = false;
            this.xrRunningBalance.StylePriority.UseTextAlignment = false;
            this.xrRunningBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrRunningBalance.TextFormatString = "{0:n2}";
            //
            // xrNote
            //
            this.xrNote.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrNote.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrNote.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Note]")});
            this.xrNote.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 9F);
            this.xrNote.LocationFloat = new DevExpress.Utils.PointFloat(307F, 0F);
            this.xrNote.Name = "xrNote";
            this.xrNote.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrNote.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.xrNote.StylePriority.UseBorderColor = false;
            this.xrNote.StylePriority.UseBorders = false;
            this.xrNote.StylePriority.UseFont = false;
            this.xrNote.StylePriority.UseTextAlignment = false;
            this.xrNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // rptItemStockCard
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                this.TopMargin, this.BottomMargin, this.ReportHeader, this.PageHeader, this.Detail});
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
        private DevExpress.XtraReports.UI.XRLabel hdrMovementDate;
        private DevExpress.XtraReports.UI.XRLabel hdrMovementType;
        private DevExpress.XtraReports.UI.XRLabel hdrDocumentNum;
        private DevExpress.XtraReports.UI.XRLabel hdrCounterpartyStoreName;
        private DevExpress.XtraReports.UI.XRLabel hdrQtyIn;
        private DevExpress.XtraReports.UI.XRLabel hdrQtyOut;
        private DevExpress.XtraReports.UI.XRLabel hdrRunningBalance;
        private DevExpress.XtraReports.UI.XRLabel hdrNote;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrMovementDate;
        private DevExpress.XtraReports.UI.XRLabel xrMovementType;
        private DevExpress.XtraReports.UI.XRLabel xrDocumentNum;
        private DevExpress.XtraReports.UI.XRLabel xrCounterpartyStoreName;
        private DevExpress.XtraReports.UI.XRLabel xrQtyIn;
        private DevExpress.XtraReports.UI.XRLabel xrQtyOut;
        private DevExpress.XtraReports.UI.XRLabel xrRunningBalance;
        private DevExpress.XtraReports.UI.XRLabel xrNote;
    }
}
