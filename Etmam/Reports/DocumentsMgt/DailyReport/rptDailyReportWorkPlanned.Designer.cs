namespace Etmam
{
    partial class rptDailyReportWorkPlanned
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
            this.xrTableWorkPlannedDetail = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowD = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellDescriptionD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellLocationD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellActivityD = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrTableRowH = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellDescriptionH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellLocationH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellActivityH = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableWorkPlannedDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTableWorkPlannedDetail});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableWorkPlannedDetail
            // 
            this.xrTableWorkPlannedDetail.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableWorkPlannedDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTableWorkPlannedDetail.Name = "xrTableWorkPlannedDetail";
            this.xrTableWorkPlannedDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowD});
            this.xrTableWorkPlannedDetail.SizeF = new System.Drawing.SizeF(750F, 25F);
            this.xrTableWorkPlannedDetail.StylePriority.UseBorders = false;
            this.xrTableWorkPlannedDetail.StylePriority.UseTextAlignment = false;
            this.xrTableWorkPlannedDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRowD
            // 
            this.xrTableRowD.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellDescriptionD,
            this.xrTableCellLocationD,
            this.xrTableCellActivityD});
            this.xrTableRowD.Name = "xrTableRowD";
            this.xrTableRowD.Weight = 1D;
            // 
            // xrTableCellDescriptionD
            // 
            this.xrTableCellDescriptionD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]")});
            this.xrTableCellDescriptionD.Name = "xrTableCellDescriptionD";
            this.xrTableCellDescriptionD.Weight = 1.62D;
            // 
            // xrTableCellLocationD
            // 
            this.xrTableCellLocationD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Location]")});
            this.xrTableCellLocationD.Name = "xrTableCellLocationD";
            this.xrTableCellLocationD.Weight = 0.8D;
            // 
            // xrTableCellActivityD
            // 
            this.xrTableCellActivityD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ActivityName]")});
            this.xrTableCellActivityD.Name = "xrTableCellActivityD";
            this.xrTableCellActivityD.Weight = 1D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableRowH
            // 
            this.xrTableRowH.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellDescriptionH,
            this.xrTableCellLocationH,
            this.xrTableCellActivityH});
            this.xrTableRowH.Name = "xrTableRowH";
            this.xrTableRowH.Weight = 1D;
            // 
            // xrTableCellDescriptionH
            // 
            this.xrTableCellDescriptionH.Name = "xrTableCellDescriptionH";
            this.xrTableCellDescriptionH.Text = "الوصف / ملاحظات";
            this.xrTableCellDescriptionH.Weight = 1.62D;
            // 
            // xrTableCellLocationH
            // 
            this.xrTableCellLocationH.Name = "xrTableCellLocationH";
            this.xrTableCellLocationH.Text = "الموقع";
            this.xrTableCellLocationH.Weight = 0.8D;
            // 
            // xrTableCellActivityH
            // 
            this.xrTableCellActivityH.Name = "xrTableCellActivityH";
            this.xrTableCellActivityH.Text = "البند / النشاط";
            this.xrTableCellActivityH.Weight = 1D;
            // 
            // rptDailyReportWorkPlanned
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Font = new DevExpress.Drawing.DXFont("Cairo", 9.75F, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.Margins = new DevExpress.Drawing.DXMargins(0F, 0F, 0F, 0F);
            this.PageHeightF = 1169.291F;
            this.PageWidthF = 826.7717F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTableWorkPlannedDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowH;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellDescriptionH;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellLocationH;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellActivityH;
        private DevExpress.XtraReports.UI.XRTable xrTableWorkPlannedDetail;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellDescriptionD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellLocationD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellActivityD;
    }
}
