using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.ContractMgt
{
    public partial class ucContractAmendments : XtraUserControl
    {
        public ucContractAmendments()
        {
            InitializeComponent();
        }

        private void bbiNewAmendment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiApproveAmendment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
