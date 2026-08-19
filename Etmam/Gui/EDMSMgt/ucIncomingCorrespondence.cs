using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.EDMSMgt
{
    public partial class ucIncomingCorrespondence : XtraUserControl
    {
        public ucIncomingCorrespondence()
        {
            InitializeComponent();
        }

        private void bbiNewIncoming_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditIncoming_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
