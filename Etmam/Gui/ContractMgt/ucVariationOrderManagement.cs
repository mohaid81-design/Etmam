using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.ContractMgt
{
    public partial class ucVariationOrderManagement : XtraUserControl
    {
        public ucVariationOrderManagement()
        {
            InitializeComponent();
        }

        private void bbiNewVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiApproveVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRejectVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrintVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
