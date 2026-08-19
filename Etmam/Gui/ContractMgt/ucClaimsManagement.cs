using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.ContractMgt
{
    public partial class ucClaimsManagement : XtraUserControl
    {
        public ucClaimsManagement()
        {
            InitializeComponent();
        }

        private void bbiNewClaim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiSubmitClaim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiApproveClaim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRejectClaim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
