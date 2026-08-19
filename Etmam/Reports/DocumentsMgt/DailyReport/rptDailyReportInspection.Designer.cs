namespace Etmam
{
    partial class rptDailyReportInspection
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
            this.xrTableInspectionDetail = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowD = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellNoteD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellStatusD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellDescriptionD = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableInspectionDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTableInspectionDetail});
            this.Detail.Dpi = 25.4F;
            this.Detail.HeightF = 6.35F;
            this.Detail.HierarchyPrintOptions.Indent = 5.08F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableInspectionDetail
            // 
            this.xrTableInspectionDetail.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableInspectionDetail.Dpi = 25.4F;
            this.xrTableInspectionDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTableInspectionDetail.Name = "xrTableInspectionDetail";
            this.xrTableInspectionDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowD});
            this.xrTableInspectionDetail.SizeF = new System.Drawing.SizeF(138F, 6.35F);
            this.xrTableInspectionDetail.StylePriority.UseBorders = false;
            this.xrTableInspectionDetail.StylePriority.UseTextAlignment = false;
            this.xrTableInspectionDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRowD
            // 
            this.xrTableRowD.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellNoteD,
            this.xrTableCellStatusD,
            this.xrTableCellDescriptionD});
            this.xrTableRowD.Dpi = 25.4F;
            this.xrTableRowD.Name = "xrTableRowD";
            this.xrTableRowD.Weight = 1D;
            // 
            // xrTableCellNoteD
            // 
            this.xrTableCellNoteD.Dpi = 25.4F;
            this.xrTableCellNoteD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Note]")});
            this.xrTableCellNoteD.Name = "xrTableCellNoteD";
            this.xrTableCellNoteD.Weight = 0.65217391304347827D;
            // 
            // xrTableCellStatusD
            // 
            this.xrTableCellStatusD.Dpi = 25.4F;
            this.xrTableCellStatusD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Status]")});
            this.xrTableCellStatusD.Name = "xrTableCellStatusD";
            this.xrTableCellStatusD.Weight = 0.65217390475065806D;
            // 
            // xrTableCellDescriptionD
            // 
            this.xrTableCellDescriptionD.Dpi = 25.4F;
            this.xrTableCellDescriptionD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InspectionDescription]")});
            this.xrTableCellDescriptionD.Name = "xrTableCellDescriptionD";
            this.xrTableCellDescriptionD.Weight = 1.6956521822058632D;
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
            // rptDailyReportInspection
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 25.4F;
            this.Font = new DevExpress.Drawing.DXFont("Cairo", 9.75F, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.Margins = new DevExpress.Drawing.DXMargins(72F, 0F, 0F, 0F);
            this.PageHeightF = 297F;
            this.PageWidthF = 210F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Millimeters;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.SnapGridSize = 2.5F;
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTableInspectionDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable xrTableInspectionDetail;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellNoteD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellStatusD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellDescriptionD;
    }
}
