using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.HSEMgt
{
    public partial class ucPermitToWork : XtraUserControl
    {
        public ucPermitToWork()
        {
            InitializeComponent();
        }

        private void bbiNewPtw_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiClosePtw_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiSuspendPtw_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrintPtw_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
