namespace Etmam
{
    public partial class ucBOQReports : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBOQReports()
        {
            InitializeComponent();
        }

        private void bbiPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }

        private void pnlReportDetailedBoq_Click(object sender, System.EventArgs e) { }
        private void pnlReportSummaryBoq_Click(object sender, System.EventArgs e) { }
        private void pnlReportQuantity_Click(object sender, System.EventArgs e) { }
        private void pnlReportCost_Click(object sender, System.EventArgs e) { }
        private void pnlReportRevision_Click(object sender, System.EventArgs e) { }
        private void pnlReportComparison_Click(object sender, System.EventArgs e) { }

        private void btnRetry_Click(object sender, System.EventArgs e) { }
    }
}
