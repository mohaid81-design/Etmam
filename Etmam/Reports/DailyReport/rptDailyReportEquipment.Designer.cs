namespace Etmam
{
    partial class rptDailyReportEquipment
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
            this.xrTableEquipmentDetail = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowD = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellStatusD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellQtyD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellEquipmentD = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableEquipmentDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTableEquipmentDetail});
            this.Detail.Dpi = 25.4F;
            this.Detail.HeightF = 6F;
            this.Detail.HierarchyPrintOptions.Indent = 5.08F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableEquipmentDetail
            // 
            this.xrTableEquipmentDetail.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableEquipmentDetail.Dpi = 25.4F;
            this.xrTableEquipmentDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTableEquipmentDetail.Name = "xrTableEquipmentDetail";
            this.xrTableEquipmentDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowD});
            this.xrTableEquipmentDetail.SizeF = new System.Drawing.SizeF(92F, 6F);
            this.xrTableEquipmentDetail.StylePriority.UseBorders = false;
            this.xrTableEquipmentDetail.StylePriority.UseTextAlignment = false;
            this.xrTableEquipmentDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRowD
            // 
            this.xrTableRowD.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellStatusD,
            this.xrTableCellQtyD,
            this.xrTableCellEquipmentD});
            this.xrTableRowD.Dpi = 25.4F;
            this.xrTableRowD.Name = "xrTableRowD";
            this.xrTableRowD.Weight = 1D;
            // 
            // xrTableCellStatusD
            // 
            this.xrTableCellStatusD.Dpi = 25.4F;
            this.xrTableCellStatusD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Status]")});
            this.xrTableCellStatusD.Name = "xrTableCellStatusD";
            this.xrTableCellStatusD.Weight = 0.483018528416999D;
            // 
            // xrTableCellQtyD
            // 
            this.xrTableCellQtyD.Dpi = 25.4F;
            this.xrTableCellQtyD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")});
            this.xrTableCellQtyD.Name = "xrTableCellQtyD";
            this.xrTableCellQtyD.Weight = 0.24141739855837707D;
            // 
            // xrTableCellEquipmentD
            // 
            this.xrTableCellEquipmentD.Dpi = 25.4F;
            this.xrTableCellEquipmentD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EquipmentList.Name]")});
            this.xrTableCellEquipmentD.Name = "xrTableCellEquipmentD";
            this.xrTableCellEquipmentD.Weight = 0.965853347625797D;
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
            // rptDailyReportEquipment
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 25.4F;
            this.Font = new DevExpress.Drawing.DXFont("Cairo", 9.75F, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(11F, 194F, 0F, 0F);
            this.PageHeightF = 210F;
            this.PageWidthF = 297F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Millimeters;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.SnapGridSize = 2.5F;
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTableEquipmentDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable xrTableEquipmentDetail;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellStatusD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellQtyD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellEquipmentD;
    }
}
