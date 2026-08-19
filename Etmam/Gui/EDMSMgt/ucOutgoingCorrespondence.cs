using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.EDMSMgt
{
    public partial class ucOutgoingCorrespondence : XtraUserControl
    {
        public ucOutgoingCorrespondence()
        {
            InitializeComponent();
        }

        private void bbiNewOutgoing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditOutgoing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
