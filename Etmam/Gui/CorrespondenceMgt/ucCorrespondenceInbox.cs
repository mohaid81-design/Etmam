using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CorrespondenceMgt
{
    public partial class ucCorrespondenceInbox : XtraUserControl
    {
        public ucCorrespondenceInbox()
        {
            InitializeComponent();
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiReply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiForward_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiAssign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiLinkProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiLinkContract_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiArchive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
