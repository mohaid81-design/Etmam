using System;
using System.Windows.Forms;

namespace Etmam
{
    public partial class ucScheduleComparison : DevExpress.XtraEditors.XtraUserControl
    {
        public ucScheduleComparison()
        {
            InitializeComponent();
        }

        private void bbiExportComparison_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrintComparison_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRefreshComparison_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void btnRetry_Click(object sender, EventArgs e) { }
    }
}
