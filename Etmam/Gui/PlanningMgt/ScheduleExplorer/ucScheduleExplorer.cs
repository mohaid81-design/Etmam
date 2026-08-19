using System;
using System.Windows.Forms;

namespace Etmam
{
    public partial class ucScheduleExplorer : DevExpress.XtraEditors.XtraUserControl
    {
        public ucScheduleExplorer()
        {
            InitializeComponent();
        }

        private void bbiExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCollapseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRefreshTree_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiFilterCritical_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void btnRetry_Click(object sender, EventArgs e) { }
    }
}
