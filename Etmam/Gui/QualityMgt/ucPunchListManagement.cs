using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.QualityMgt
{
    public partial class ucPunchListManagement : XtraUserControl
    {
        public ucPunchListManagement()
        {
            InitializeComponent();
        }

        private void bbiNewItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiAssign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCloseItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
