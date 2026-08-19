using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CostControlMgt
{
    public partial class ucOwnerIPCManagement : XtraUserControl
    {
        public ucOwnerIPCManagement()
        {
            InitializeComponent();
        }

        private void bbiNewIpc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiGenerateIpc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiSubmitIpc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiApproveIpc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrintIpc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
