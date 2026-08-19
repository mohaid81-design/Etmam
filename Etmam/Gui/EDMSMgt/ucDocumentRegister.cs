using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.EDMSMgt
{
    public partial class ucDocumentRegister : XtraUserControl
    {
        public ucDocumentRegister()
        {
            InitializeComponent();
        }

        private void bbiNewDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiViewDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCheckOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCheckIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiArchive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
