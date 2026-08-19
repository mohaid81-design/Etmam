using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.ContractMgt
{
    public partial class ucContractObligationsRegister : XtraUserControl
    {
        public ucContractObligationsRegister()
        {
            InitializeComponent();
        }

        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiComplete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiLinkDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
