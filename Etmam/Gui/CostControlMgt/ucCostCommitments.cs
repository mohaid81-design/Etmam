using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CostControlMgt
{
    public partial class ucCostCommitments : XtraUserControl
    {
        public ucCostCommitments()
        {
            InitializeComponent();
        }

        private void bbiNewCommitment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiLinkPO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiLinkContract_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCloseCommitment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
