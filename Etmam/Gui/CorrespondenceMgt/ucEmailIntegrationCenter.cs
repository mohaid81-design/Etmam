using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CorrespondenceMgt
{
    public partial class ucEmailIntegrationCenter : XtraUserControl
    {
        public ucEmailIntegrationCenter()
        {
            InitializeComponent();
        }

        private void bbiSyncOutlook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiLinkToProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiClassify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
