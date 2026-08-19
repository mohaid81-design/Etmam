using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.HSEMgt
{
    public partial class ucPPEManagement : XtraUserControl
    {
        public ucPPEManagement()
        {
            InitializeComponent();
        }

        private void bbiIssuePpe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiReplacePpe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
