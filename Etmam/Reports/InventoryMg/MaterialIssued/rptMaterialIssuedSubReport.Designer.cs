namespace Etmam
{
    partial class rptMaterialIssuedSubReport
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrColumnHeadersTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrColumnHeadersRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrItemNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrDescription = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrUnit = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrQty = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrBudgetItem = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrNote = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrColumnHeadersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrColumnHeadersTable});
            this.Detail.Dpi = 25.4F;
            this.Detail.HeightF = 8F;
            this.Detail.HierarchyPrintOptions.Indent = 5.08F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.BottomMargin.HeightF = 0.2020831F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0F, 0F, 0F, 0F, 25.4F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrColumnHeadersTable
            // 
            this.xrColumnHeadersTable.BackColor = System.Drawing.Color.Empty;
            this.xrColumnHeadersTable.BorderColor = System.Drawing.Color.Empty;
            this.xrColumnHeadersTable.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrColumnHeadersTable.Dpi = 25.4F;
            this.xrColumnHeadersTable.Font = new DevExpress.Drawing.DXFont("Calibri Light", 11F);
            this.xrColumnHeadersTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrColumnHeadersTable.Name = "xrColumnHeadersTable";
            this.xrColumnHeadersTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(0.5291666F, 0.5291666F, 0F, 0F, 25.4F);
            this.xrColumnHeadersTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrColumnHeadersRow});
            this.xrColumnHeadersTable.SizeF = new System.Drawing.SizeF(180F, 8F);
            this.xrColumnHeadersTable.StylePriority.UseBackColor = false;
            this.xrColumnHeadersTable.StylePriority.UseBorderColor = false;
            this.xrColumnHeadersTable.StylePriority.UseBorders = false;
            this.xrColumnHeadersTable.StylePriority.UseFont = false;
            this.xrColumnHeadersTable.StylePriority.UseTextAlignment = false;
            this.xrColumnHeadersTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrColumnHeadersRow
            // 
            this.xrColumnHeadersRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrItemNo,
            this.xrDescription,
            this.xrUnit,
            this.xrQty,
            this.xrBudgetItem,
            this.xrNote});
            this.xrColumnHeadersRow.Dpi = 25.4F;
            this.xrColumnHeadersRow.Name = "xrColumnHeadersRow";
            this.xrColumnHeadersRow.Weight = 1D;
            //
            // xrItemNo
            //
            this.xrItemNo.Dpi = 25.4F;
            this.xrItemNo.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ItemNo]")});
            this.xrItemNo.Multiline = true;
            this.xrItemNo.Name = "xrItemNo";
            this.xrItemNo.Weight = 0.43334089494403405D;
            //
            // xrDescription
            //
            this.xrDescription.Dpi = 25.4F;
            this.xrDescription.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]")});
            this.xrDescription.Multiline = true;
            this.xrDescription.Name = "xrDescription";
            this.xrDescription.Padding = new DevExpress.XtraPrinting.PaddingInfo(1F, 1F, 0F, 0F, 25.4F);
            this.xrDescription.StylePriority.UsePadding = false;
            this.xrDescription.StylePriority.UseTextAlignment = false;
            this.xrDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrDescription.Weight = 2.1667046050408025D;
            //
            // xrUnit
            //
            this.xrUnit.Dpi = 25.4F;
            this.xrUnit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UnitAbbreviation]")});
            this.xrUnit.Multiline = true;
            this.xrUnit.Name = "xrUnit";
            this.xrUnit.Weight = 0.54167615734853847D;
            //
            // xrQty
            //
            this.xrQty.Dpi = 25.4F;
            this.xrQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")});
            this.xrQty.Multiline = true;
            this.xrQty.Name = "xrQty";
            this.xrQty.TextFormatString = "{0:n2}";
            this.xrQty.Weight = 0.902793556385751D;
            //
            // xrBudgetItem
            //
            this.xrBudgetItem.Dpi = 25.4F;
            this.xrBudgetItem.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BudgetDescription]")});
            this.xrBudgetItem.Multiline = true;
            this.xrBudgetItem.Name = "xrBudgetItem";
            this.xrBudgetItem.Weight = 0.9027935654327599D;
            //
            // xrNote
            //
            this.xrNote.Dpi = 25.4F;
            this.xrNote.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Note]")});
            this.xrNote.Multiline = true;
            this.xrNote.Name = "xrNote";
            this.xrNote.Padding = new DevExpress.XtraPrinting.PaddingInfo(1F, 1F, 0F, 0F, 25.4F);
            this.xrNote.StylePriority.UsePadding = false;
            this.xrNote.StylePriority.UseTextAlignment = false;
            this.xrNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrNote.Weight = 1.5528060008308244D;
            // 
            // rptMaterialIssuedSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 25.4F;
            this.Margins = new DevExpress.Drawing.DXMargins(15F, 15F, 0F, 0.2020831F);
            this.PageHeightF = 297F;
            this.PageWidthF = 210F;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.Millimeters;
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.SnapGridSize = 2.5F;
            this.Version = "25.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrColumnHeadersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable xrColumnHeadersTable;
        private DevExpress.XtraReports.UI.XRTableRow xrColumnHeadersRow;
        private DevExpress.XtraReports.UI.XRTableCell xrItemNo;
        private DevExpress.XtraReports.UI.XRTableCell xrDescription;
        private DevExpress.XtraReports.UI.XRTableCell xrUnit;
        private DevExpress.XtraReports.UI.XRTableCell xrQty;
        private DevExpress.XtraReports.UI.XRTableCell xrBudgetItem;
        private DevExpress.XtraReports.UI.XRTableCell xrNote;
    }
}
