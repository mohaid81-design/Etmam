using System;
using System.Windows.Forms;

namespace Etmam
{
    public partial class ucMilestones : DevExpress.XtraEditors.XtraUserControl
    {
        public ucMilestones()
        {
            InitializeComponent();
        }

        private void bbiAddMilestone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditMilestone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiDeleteMilestone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRefreshMilestones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportMilestones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void btnRetry_Click(object sender, EventArgs e) { }
    }
}
