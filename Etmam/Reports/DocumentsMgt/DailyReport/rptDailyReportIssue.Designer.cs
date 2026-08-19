namespace Etmam
{
    partial class rptDailyReportIssue
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
            this.xrTableIssueDetail = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowD = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellRecommendationD = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellDescriptionD = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrTableRowH = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellRecommendationH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellDescriptionH = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableIssueDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTableIssueDetail});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableIssueDetail
            // 
            this.xrTableIssueDetail.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableIssueDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTableIssueDetail.Name = "xrTableIssueDetail";
            this.xrTableIssueDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowD});
            this.xrTableIssueDetail.SizeF = new System.Drawing.SizeF(750F, 25F);
            this.xrTableIssueDetail.StylePriority.UseBorders = false;
            this.xrTableIssueDetail.StylePriority.UseTextAlignment = false;
            this.xrTableIssueDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRowD
            // 
            this.xrTableRowD.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellRecommendationD,
            this.xrTableCellDescriptionD});
            this.xrTableRowD.Name = "xrTableRowD";
            this.xrTableRowD.Weight = 1D;
            // 
            // xrTableCellRecommendationD
            // 
            this.xrTableCellRecommendationD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Recommendation]")});
            this.xrTableCellRecommendationD.Name = "xrTableCellRecommendationD";
            this.xrTableCellRecommendationD.Weight = 1D;
            // 
            // xrTableCellDescriptionD
            // 
            this.xrTableCellDescriptionD.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]")});
            this.xrTableCellDescriptionD.Name = "xrTableCellDescriptionD";
            this.xrTableCellDescriptionD.Weight = 2.42D;
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
            this.xrTableCellRecommendationH,
            this.xrTableCellDescriptionH});
            this.xrTableRowH.Name = "xrTableRowH";
            this.xrTableRowH.Weight = 1D;
            // 
            // xrTableCellRecommendationH
            // 
            this.xrTableCellRecommendationH.Name = "xrTableCellRecommendationH";
            this.xrTableCellRecommendationH.Text = "التوصيات / الحلول المقترحة";
            this.xrTableCellRecommendationH.Weight = 1D;
            // 
            // xrTableCellDescriptionH
            // 
            this.xrTableCellDescriptionH.Name = "xrTableCellDescriptionH";
            this.xrTableCellDescriptionH.Text = "وصف المعوق / المشكلة / الملاحظة";
            this.xrTableCellDescriptionH.Weight = 2.42D;
            // 
            // rptDailyReportIssue
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            });
            this.Font = new DevExpress.Drawing.DXFont("Cairo", 9.75F, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.Margins = new DevExpress.Drawing.DXMargins(0, 0, 0, 0);
            this.PageHeightF = 1169.291F;
            this.PageWidthF = 826.7717F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTableIssueDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowH;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellRecommendationH;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellDescriptionH;
        private DevExpress.XtraReports.UI.XRTable xrTableIssueDetail;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellRecommendationD;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellDescriptionD;
    }
}
