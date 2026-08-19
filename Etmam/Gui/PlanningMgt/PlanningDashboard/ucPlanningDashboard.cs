using System;
using System.Windows.Forms;

namespace Etmam
{
    public partial class ucPlanningDashboard : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPlanningDashboard()
        {
            InitializeComponent();
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void btnApplyFilters_Click(object sender, EventArgs e) { }
        private void btnResetFilters_Click(object sender, EventArgs e) { }
        private void btnRetry_Click(object sender, EventArgs e) { }
    }
}
