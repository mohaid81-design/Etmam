using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CorrespondenceMgt
{
    public partial class ucCorrespondenceOutbox : XtraUserControl
    {
        public ucCorrespondenceOutbox()
        {
            InitializeComponent();
        }

        private void bbiNewOutbox_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditOutbox_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
