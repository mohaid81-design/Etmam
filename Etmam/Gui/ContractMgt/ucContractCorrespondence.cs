using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.ContractMgt
{
    public partial class ucContractCorrespondence : XtraUserControl
    {
        public ucContractCorrespondence()
        {
            InitializeComponent();
        }

        private void bbiNewLetter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiReply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiLinkDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
