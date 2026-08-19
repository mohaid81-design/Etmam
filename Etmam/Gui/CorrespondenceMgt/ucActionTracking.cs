using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CorrespondenceMgt
{
    public partial class ucActionTracking : XtraUserControl
    {
        public ucActionTracking()
        {
            InitializeComponent();
        }

        private void bbiNewAction_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCompleteAction_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
