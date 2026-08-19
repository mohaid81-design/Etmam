using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.HSEMgt
{
    public partial class ucSafetyTraining : XtraUserControl
    {
        public ucSafetyTraining()
        {
            InitializeComponent();
        }

        private void bbiNewTraining_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRenewCert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
