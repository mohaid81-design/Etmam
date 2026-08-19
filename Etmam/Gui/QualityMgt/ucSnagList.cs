using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.QualityMgt
{
    public partial class ucSnagList : XtraUserControl
    {
        public ucSnagList()
        {
            InitializeComponent();
        }

        private void bbiNewSnag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCloseSnag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
