using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CostControlMgt
{
    public partial class ucSubcontractorIPCManagement : XtraUserControl
    {
        public ucSubcontractorIPCManagement()
        {
            InitializeComponent();
        }

        private void bbiNewSubIpc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiApproveSubIpc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
