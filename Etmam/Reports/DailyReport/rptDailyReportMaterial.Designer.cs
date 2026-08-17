namespace Etmam
{
    partial class rptDailyReportMaterial
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
            this.xrTableMaterialDetail = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowD = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellQtyD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellUnitD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellItemD = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrTableRowH = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellQtyH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellUnitH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellItemH = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableMaterialDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTableMaterialDetail});
            this.Detail.Dpi = 25.4F;
            this.Detail.HeightF = 6.35F;
            this.Detail.HierarchyPrintOptions.Indent = 5.08F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableMaterialDetail
            // 
            this.xrTableMaterialDetail.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableMaterialDetail.Dpi = 25.4F;
            this.xrTableMaterialDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTableMaterialDetail.Name = "xrTableMaterialDetail";
            this.xrTableMaterialDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowD});
            this.xrTableMaterialDetail.SizeF = new System.Drawing.SizeF(138F, 6.35F);
            this.xrTableMaterialDetail.StylePriority.UseBorders = false;
            this.xrTableMaterialDetail.StylePriority.UseTextAlignment = false;
            this.xrTableMaterialDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRowD
            // 
            this.xrTableRowD.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellQtyD,
            this.xrTableCellUnitD,
            this.xrTableCellItemD});
            this.xrTableRowD.Dpi = 25.4F;
            this.xrTableRowD.Name = "xrTableRowD";
            this.xrTableRowD.Weight = 1D;
            // 
            // xrTableCellQtyD
            // 
            this.xrTableCellQtyD.Dpi = 25.4F;
            this.xrTableCellQtyD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")});
            this.xrTableCellQtyD.Name = "xrTableCellQtyD";
            this.xrTableCellQtyD.Weight = 0.31496065395084888D;
            // 
            // xrTableCellUnitD
            // 
            this.xrTableCellUnitD.Dpi = 25.4F;
            this.xrTableCellUnitD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Unit]")});
            this.xrTableCellUnitD.Name = "xrTableCellUnitD";
            this.xrTableCellUnitD.Weight = 0.31496065395084882D;
            // 
            // xrTableCellItemD
            // 
            this.xrTableCellItemD.Dpi = 25.4F;
            this.xrTableCellItemD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Item]")});
            this.xrTableCellItemD.Name = "xrTableCellItemD";
            this.xrTableCellItemD.Weight = 1.5433070385549952D;
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
            // xrTableRowH
            // 
            this.xrTableRowH.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellQtyH,
            this.xrTableCellUnitH,
            this.xrTableCellItemH});
            this.xrTableRowH.Name = "xrTableRowH";
            this.xrTableRowH.Weight = 1D;
            // 
            // xrTableCellQtyH
            // 
            this.xrTableCellQtyH.Name = "xrTableCellQtyH";
            this.xrTableCellQtyH.Text = "الكمية";
            this.xrTableCellQtyH.Weight = 0.6D;
            // 
            // xrTableCellUnitH
            // 
            this.xrTableCellUnitH.Name = "xrTableCellUnitH";
            this.xrTableCellUnitH.Text = "الوحدة";
            this.xrTableCellUnitH.Weight = 0.6D;
            // 
            // xrTableCellItemH
            // 
            this.xrTableCellItemH.Name = "xrTableCellItemH";
            this.xrTableCellItemH.Text = "وصف المادة الموردة";
            this.xrTableCellItemH.Weight = 1.8D;
            // 
            // rptDailyReportMaterial
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 25.4F;
            this.Font = new DevExpress.Drawing.DXFont("Cairo", 9.75F, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.Margins = new DevExpress.Drawing.DXMargins(0F, 72F, 0F, 0F);
            this.PageHeightF = 297F;
            this.PageWidthF = 210F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Millimeters;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.SnapGridSize = 2.5F;
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTableMaterialDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowH;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellQtyH;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellUnitH;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellItemH;
        private DevExpress.XtraReports.UI.XRTable xrTableMaterialDetail;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellQtyD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellUnitD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellItemD;
    }
}
