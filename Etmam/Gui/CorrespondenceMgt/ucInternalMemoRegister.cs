using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CorrespondenceMgt
{
    public partial class ucInternalMemoRegister : XtraUserControl
    {
        public ucInternalMemoRegister()
        {
            InitializeComponent();
        }

        private void bbiNewMemo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditMemo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPublish_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiArchive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
