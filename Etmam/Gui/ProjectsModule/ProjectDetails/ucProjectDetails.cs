using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class ucProjectDetails : DevExpress.XtraEditors.XtraUserControl
    {
        public ucProjectDetails()
        {
            InitializeComponent();
        }

        // ─── Overlay helpers ─────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);
        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
        // ─────────────────────────────────────────────────────────────────────

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCancelEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void btnApprove_Click(object sender, System.EventArgs e) { }
        private void btnReject_Click(object sender, System.EventArgs e) { }
        private void btnUploadAttachment_Click(object sender, System.EventArgs e) { }
        private void btnRetry_Click(object sender, System.EventArgs e) { }
    }
}
