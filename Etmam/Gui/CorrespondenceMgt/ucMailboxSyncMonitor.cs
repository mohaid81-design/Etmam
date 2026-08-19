using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CorrespondenceMgt
{
    public partial class ucMailboxSyncMonitor : XtraUserControl
    {
        public ucMailboxSyncMonitor()
        {
            InitializeComponent();
        }

        private void bbiSyncNow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRetryFailed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
