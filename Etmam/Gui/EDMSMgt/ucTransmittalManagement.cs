using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.EDMSMgt
{
    public partial class ucTransmittalManagement : XtraUserControl
    {
        public ucTransmittalManagement()
        {
            InitializeComponent();
        }

        private void bbiNewTransmittal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiIssue_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRecall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
