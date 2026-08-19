namespace Etmam
{
    partial class rptPurchaseRequestSubReport
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
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrItemNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrUnit = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDescription = new DevExpress.XtraReports.UI.XRLabel();
            this.xrNote = new DevExpress.XtraReports.UI.XRLabel();
            this.xrAlternateRowStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrBudgetItemCode = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrBudgetItemCode,
            this.xrQty,
            this.xrItemNo,
            this.xrUnit,
            this.xrDescription,
            this.xrNote});
            this.Detail.HeightF = 30.0001F;
            this.Detail.Name = "Detail";
            // 
            // xrQty
            // 
            this.xrQty.BackColor = System.Drawing.Color.Transparent;
            this.xrQty.BorderColor = System.Drawing.Color.DimGray;
            this.xrQty.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")});
            this.xrQty.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrQty.LocationFloat = new DevExpress.Utils.PointFloat(270.9997F, 5.340576E-05F);
            this.xrQty.Multiline = true;
            this.xrQty.Name = "xrQty";
            this.xrQty.OddStyleName = "xrAlternateRowStyle";
            this.xrQty.Padding = new DevExpress.XtraPrinting.PaddingInfo(4F, 4F, 0F, 0F, 100F);
            this.xrQty.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrQty.SizeF = new System.Drawing.SizeF(66.33337F, 30F);
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
            this.xrItemNo.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber()")});
            this.xrItemNo.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrItemNo.LocationFloat = new DevExpress.Utils.PointFloat(656.6667F, 0F);
            this.xrItemNo.Multiline = true;
            this.xrItemNo.Name = "xrItemNo";
            this.xrItemNo.OddStyleName = "xrAlternateRowStyle";
            this.xrItemNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(4F, 4F, 0F, 0F, 100F);
            this.xrItemNo.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrItemNo.SizeF = new System.Drawing.SizeF(43.33F, 30F);
            this.xrItemNo.StylePriority.UseBorderColor = false;
            this.xrItemNo.StylePriority.UseBorders = false;
            this.xrItemNo.StylePriority.UseFont = false;
            this.xrItemNo.StylePriority.UsePadding = false;
            this.xrItemNo.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrItemNo.Summary = xrSummary2;
            this.xrItemNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrItemNo.TextFormatString = "{0:N0}";
            // 
            // xrUnit
            // 
            this.xrUnit.BackColor = System.Drawing.Color.Transparent;
            this.xrUnit.BorderColor = System.Drawing.Color.DimGray;
            this.xrUnit.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrUnit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UnitAbbreviation]")});
            this.xrUnit.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrUnit.LocationFloat = new DevExpress.Utils.PointFloat(337.333F, 5.340576E-05F);
            this.xrUnit.Multiline = true;
            this.xrUnit.Name = "xrUnit";
            this.xrUnit.OddStyleName = "xrAlternateRowStyle";
            this.xrUnit.Padding = new DevExpress.XtraPrinting.PaddingInfo(4F, 4F, 0F, 0F, 100F);
            this.xrUnit.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrUnit.SizeF = new System.Drawing.SizeF(47.16669F, 30F);
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
            this.xrDescription.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]")});
            this.xrDescription.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrDescription.LocationFloat = new DevExpress.Utils.PointFloat(384.4998F, 0F);
            this.xrDescription.Multiline = true;
            this.xrDescription.Name = "xrDescription";
            this.xrDescription.OddStyleName = "xrAlternateRowStyle";
            this.xrDescription.Padding = new DevExpress.XtraPrinting.PaddingInfo(4F, 4F, 0F, 0F, 100F);
            this.xrDescription.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrDescription.SizeF = new System.Drawing.SizeF(272.167F, 30F);
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
            this.xrNote.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Note]")});
            this.xrNote.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrNote.LocationFloat = new DevExpress.Utils.PointFloat(9.536743E-05F, 4.768372E-05F);
            this.xrNote.Multiline = true;
            this.xrNote.Name = "xrNote";
            this.xrNote.OddStyleName = "xrAlternateRowStyle";
            this.xrNote.Padding = new DevExpress.XtraPrinting.PaddingInfo(4F, 4F, 0F, 0F, 100F);
            this.xrNote.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrNote.SizeF = new System.Drawing.SizeF(179.1696F, 30F);
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
            this.xrAlternateRowStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 100F);
            // 
            // xrBudgetItemCode
            // 
            this.xrBudgetItemCode.BackColor = System.Drawing.Color.Transparent;
            this.xrBudgetItemCode.BorderColor = System.Drawing.Color.DimGray;
            this.xrBudgetItemCode.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrBudgetItemCode.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BdgCode]")});
            this.xrBudgetItemCode.Font = new DevExpress.Drawing.DXFont("Calibri Light", 9F);
            this.xrBudgetItemCode.LocationFloat = new DevExpress.Utils.PointFloat(179.1697F, 9.536743E-05F);
            this.xrBudgetItemCode.Multiline = true;
            this.xrBudgetItemCode.Name = "xrBudgetItemCode";
            this.xrBudgetItemCode.OddStyleName = "xrAlternateRowStyle";
            this.xrBudgetItemCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(4F, 4F, 0F, 0F, 100F);
            this.xrBudgetItemCode.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.xrBudgetItemCode.SizeF = new System.Drawing.SizeF(91.83F, 30F);
            this.xrBudgetItemCode.StylePriority.UseBorderColor = false;
            this.xrBudgetItemCode.StylePriority.UseBorders = false;
            this.xrBudgetItemCode.StylePriority.UseFont = false;
            this.xrBudgetItemCode.StylePriority.UsePadding = false;
            this.xrBudgetItemCode.StylePriority.UseTextAlignment = false;
            this.xrBudgetItemCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // rptPurchaseSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Font = new DevExpress.Drawing.DXFont("Traditional Arabic", 11F);
            this.Margins = new DevExpress.Drawing.DXMargins(63.5F, 63.5F, 0F, 0F);
            this.PageHeightF = 1169.291F;
            this.PageWidthF = 826.7717F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
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
        public DevExpress.XtraReports.UI.XRLabel xrBudgetItemCode;
    }
}
