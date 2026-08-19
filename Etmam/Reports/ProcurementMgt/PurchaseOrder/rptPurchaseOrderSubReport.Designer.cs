namespace Etmam
{
    partial class rptPurchaseOrderSubReport
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
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrUnitPrice = new DevExpress.XtraReports.UI.XRLabel();
            this.xrQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrItemNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrUnit = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDescription = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNote = new DevExpress.XtraReports.UI.XRLabel();
            this.xrAlternateRowStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrTotal = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 25.4F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 25.4F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTotal,
            this.xrUnitPrice,
            this.xrQty,
            this.xrItemNo,
            this.xrUnit,
            this.xrDescription,
            this.xrNote});
            this.Detail.Dpi = 25.4F;
            this.Detail.HeightF = 6.000024F;
            this.Detail.HierarchyPrintOptions.Indent = 5.08F;
            this.Detail.Name = "Detail";
            // 
            // xrUnitPrice
            // 
            this.xrUnitPrice.BackColor = System.Drawing.Color.Transparent;
            this.xrUnitPrice.BorderColor = System.Drawing.Color.DimGray;
            this.xrUnitPrice.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrUnitPrice.Dpi = 25.4F;
            this.xrUnitPrice.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UnitPrice]")});
            this.xrUnitPrice.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrUnitPrice.LocationFloat = new DevExpress.Utils.PointFloat(60.00001F, 2.422333E-05F);
            this.xrUnitPrice.Multiline = true;
            this.xrUnitPrice.Name = "xrUnitPrice";
            this.xrUnitPrice.OddStyleName = "xrAlternateRowStyle";
            this.xrUnitPrice.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrUnitPrice.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrUnitPrice.SizeF = new System.Drawing.SizeF(18F, 6F);
            this.xrUnitPrice.StylePriority.UseBorderColor = false;
            this.xrUnitPrice.StylePriority.UseBorders = false;
            this.xrUnitPrice.StylePriority.UseFont = false;
            this.xrUnitPrice.StylePriority.UsePadding = false;
            this.xrUnitPrice.StylePriority.UseTextAlignment = false;
            this.xrUnitPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrUnitPrice.TextFormatString = "{0:N2}";
            // 
            // xrQty
            // 
            this.xrQty.BackColor = System.Drawing.Color.Transparent;
            this.xrQty.BorderColor = System.Drawing.Color.DimGray;
            this.xrQty.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrQty.Dpi = 25.4F;
            this.xrQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")});
            this.xrQty.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrQty.LocationFloat = new DevExpress.Utils.PointFloat(78.00001F, 1.356506E-05F);
            this.xrQty.Multiline = true;
            this.xrQty.Name = "xrQty";
            this.xrQty.OddStyleName = "xrAlternateRowStyle";
            this.xrQty.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrQty.SizeF = new System.Drawing.SizeF(15F, 6F);
            this.xrQty.StylePriority.UseBorderColor = false;
            this.xrQty.StylePriority.UseBorders = false;
            this.xrQty.StylePriority.UseFont = false;
            this.xrQty.StylePriority.UsePadding = false;
            this.xrQty.StylePriority.UseTextAlignment = false;
            this.xrQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrQty.TextFormatString = "{0:N2}";
            // 
            // xrItemNo
            // 
            this.xrItemNo.BackColor = System.Drawing.Color.Transparent;
            this.xrItemNo.BorderColor = System.Drawing.Color.DimGray;
            this.xrItemNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrItemNo.Dpi = 25.4F;
            this.xrItemNo.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber()")});
            this.xrItemNo.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrItemNo.LocationFloat = new DevExpress.Utils.PointFloat(170F, 0F);
            this.xrItemNo.Multiline = true;
            this.xrItemNo.Name = "xrItemNo";
            this.xrItemNo.OddStyleName = "xrAlternateRowStyle";
            this.xrItemNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrItemNo.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrItemNo.SizeF = new System.Drawing.SizeF(10F, 6F);
            this.xrItemNo.StylePriority.UseBorderColor = false;
            this.xrItemNo.StylePriority.UseBorders = false;
            this.xrItemNo.StylePriority.UseFont = false;
            this.xrItemNo.StylePriority.UsePadding = false;
            this.xrItemNo.StylePriority.UseTextAlignment = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrItemNo.Summary = xrSummary4;
            this.xrItemNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrItemNo.TextFormatString = "{0:N0}";
            // 
            // xrUnit
            // 
            this.xrUnit.BackColor = System.Drawing.Color.Transparent;
            this.xrUnit.BorderColor = System.Drawing.Color.DimGray;
            this.xrUnit.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrUnit.Dpi = 25.4F;
            this.xrUnit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UnitAbbreviation]")});
            this.xrUnit.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrUnit.LocationFloat = new DevExpress.Utils.PointFloat(93.00001F, 1.356506E-05F);
            this.xrUnit.Multiline = true;
            this.xrUnit.Name = "xrUnit";
            this.xrUnit.OddStyleName = "xrAlternateRowStyle";
            this.xrUnit.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrUnit.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrUnit.SizeF = new System.Drawing.SizeF(12F, 6F);
            this.xrUnit.StylePriority.UseBorderColor = false;
            this.xrUnit.StylePriority.UseBorders = false;
            this.xrUnit.StylePriority.UseFont = false;
            this.xrUnit.StylePriority.UsePadding = false;
            this.xrUnit.StylePriority.UseTextAlignment = false;
            this.xrUnit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrDescription
            // 
            this.xrDescription.BackColor = System.Drawing.Color.Transparent;
            this.xrDescription.BorderColor = System.Drawing.Color.DimGray;
            this.xrDescription.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrDescription.Dpi = 25.4F;
            this.xrDescription.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]")});
            this.xrDescription.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrDescription.LocationFloat = new DevExpress.Utils.PointFloat(105F, 0F);
            this.xrDescription.Multiline = true;
            this.xrDescription.Name = "xrDescription";
            this.xrDescription.OddStyleName = "xrAlternateRowStyle";
            this.xrDescription.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrDescription.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrDescription.SizeF = new System.Drawing.SizeF(65F, 6F);
            this.xrDescription.StylePriority.UseBorderColor = false;
            this.xrDescription.StylePriority.UseBorders = false;
            this.xrDescription.StylePriority.UseFont = false;
            this.xrDescription.StylePriority.UsePadding = false;
            this.xrDescription.StylePriority.UseTextAlignment = false;
            this.xrDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrNote
            // 
            this.xrNote.BackColor = System.Drawing.Color.Transparent;
            this.xrNote.BorderColor = System.Drawing.Color.DimGray;
            this.xrNote.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrNote.Dpi = 25.4F;
            this.xrNote.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Note]")});
            this.xrNote.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrNote.LocationFloat = new DevExpress.Utils.PointFloat(2.422333E-05F, 1.211166E-05F);
            this.xrNote.Multiline = true;
            this.xrNote.Name = "xrNote";
            this.xrNote.OddStyleName = "xrAlternateRowStyle";
            this.xrNote.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrNote.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrNote.SizeF = new System.Drawing.SizeF(39.99998F, 6F);
            this.xrNote.StylePriority.UseBorderColor = false;
            this.xrNote.StylePriority.UseBorders = false;
            this.xrNote.StylePriority.UseFont = false;
            this.xrNote.StylePriority.UsePadding = false;
            this.xrNote.StylePriority.UseTextAlignment = false;
            this.xrNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrAlternateRowStyle
            // 
            this.xrAlternateRowStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xrAlternateRowStyle.Name = "xrAlternateRowStyle";
            this.xrAlternateRowStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            // 
            // xrTotal
            // 
            this.xrTotal.BackColor = System.Drawing.Color.Transparent;
            this.xrTotal.BorderColor = System.Drawing.Color.DimGray;
            this.xrTotal.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTotal.Dpi = 25.4F;
            this.xrTotal.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalPrice]")});
            this.xrTotal.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrTotal.LocationFloat = new DevExpress.Utils.PointFloat(40.00001F, 2.374649E-05F);
            this.xrTotal.Multiline = true;
            this.xrTotal.Name = "xrTotal";
            this.xrTotal.OddStyleName = "xrAlternateRowStyle";
            this.xrTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(1.016F, 1.016F, 0F, 0F, 25.4F);
            this.xrTotal.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrTotal.SizeF = new System.Drawing.SizeF(20F, 6F);
            this.xrTotal.StylePriority.UseBorderColor = false;
            this.xrTotal.StylePriority.UseBorders = false;
            this.xrTotal.StylePriority.UseFont = false;
            this.xrTotal.StylePriority.UsePadding = false;
            this.xrTotal.StylePriority.UseTextAlignment = false;
            this.xrTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTotal.TextFormatString = "{0:N2}";
            // 
            // rptPurchaseOrderSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Dpi = 25.4F;
            this.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 11F);
            this.Margins = new DevExpress.Drawing.DXMargins(15F, 15F, 0F, 0F);
            this.PageHeightF = 297F;
            this.PageWidthF = 210F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Millimeters;
            this.SnapGridSize = 2.5F;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrAlternateRowStyle});
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrItemNo;
        public DevExpress.XtraReports.UI.XRLabel xrQty;
        public DevExpress.XtraReports.UI.XRLabel xrUnit;
        public DevExpress.XtraReports.UI.XRLabel xrDescription;
        public DevExpress.XtraReports.UI.XRLabel xrNote;
        private DevExpress.XtraReports.UI.XRControlStyle xrAlternateRowStyle;
        public DevExpress.XtraReports.UI.XRLabel xrUnitPrice;
        public DevExpress.XtraReports.UI.XRLabel xrTotal;
    }
}
