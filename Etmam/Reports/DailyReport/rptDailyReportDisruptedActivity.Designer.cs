namespace Etmam
{
    partial class rptDailyReportDisruptedActivity
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTableDisruptedDetail = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowD = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellImpactD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellReasonD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellActivityD = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableDisruptedDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTableDisruptedDetail});
            this.Detail.Dpi = 25.4F;
            this.Detail.HeightF = 6.35F;
            this.Detail.HierarchyPrintOptions.Indent = 5.08F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableDisruptedDetail
            // 
            this.xrTableDisruptedDetail.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableDisruptedDetail.Dpi = 25.4F;
            this.xrTableDisruptedDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTableDisruptedDetail.Name = "xrTableDisruptedDetail";
            this.xrTableDisruptedDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowD});
            this.xrTableDisruptedDetail.SizeF = new System.Drawing.SizeF(138F, 6.35F);
            this.xrTableDisruptedDetail.StylePriority.UseBorders = false;
            this.xrTableDisruptedDetail.StylePriority.UseTextAlignment = false;
            this.xrTableDisruptedDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRowD
            // 
            this.xrTableRowD.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellImpactD,
            this.xrTableCellReasonD,
            this.xrTableCellActivityD});
            this.xrTableRowD.Dpi = 25.4F;
            this.xrTableRowD.Name = "xrTableRowD";
            this.xrTableRowD.Weight = 1D;
            // 
            // xrTableCellImpactD
            // 
            this.xrTableCellImpactD.Dpi = 25.4F;
            this.xrTableCellImpactD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Impact]")});
            this.xrTableCellImpactD.Name = "xrTableCellImpactD";
            this.xrTableCellImpactD.Weight = 0.8D;
            // 
            // xrTableCellReasonD
            // 
            this.xrTableCellReasonD.Dpi = 25.4F;
            this.xrTableCellReasonD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DisruptionReason]")});
            this.xrTableCellReasonD.Name = "xrTableCellReasonD";
            this.xrTableCellReasonD.Weight = 1.2D;
            // 
            // xrTableCellActivityD
            // 
            this.xrTableCellActivityD.Dpi = 25.4F;
            this.xrTableCellActivityD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ActivityName]")});
            this.xrTableCellActivityD.Name = "xrTableCellActivityD";
            this.xrTableCellActivityD.Weight = 1D;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 25.4F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 25.4F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // rptDailyReportDisruptedActivity
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 25.4F;
            this.Font = new DevExpress.Drawing.DXFont("Cairo", 9.75F, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.Margins = new DevExpress.Drawing.DXMargins(0, 72, 0, 0);
            this.PageHeightF = 297F;
            this.PageWidthF = 210F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Millimeters;
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.SnapGridSize = 2.5F;
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTableDisruptedDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable xrTableDisruptedDetail;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellImpactD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellReasonD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellActivityD;
    }
}
