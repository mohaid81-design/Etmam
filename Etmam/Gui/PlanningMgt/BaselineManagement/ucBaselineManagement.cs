using System;
using System.Windows.Forms;

namespace Etmam
{
    public partial class ucBaselineManagement : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaselineManagement()
        {
            InitializeComponent();
        }

        private void bbiCreateBaseline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiActivateBaseline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCompareBaseline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiArchiveBaseline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void btnRetry_Click(object sender, EventArgs e) { }
    }
}
