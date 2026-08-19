using System;
using System.Windows.Forms;

namespace Etmam
{
    public partial class ucScheduleList : DevExpress.XtraEditors.XtraUserControl
    {
        public ucScheduleList()
        {
            InitializeComponent();
        }

        private void bbiNewSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiDeleteSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiImportSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiManageBaseline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCompareSchedules_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiProgressUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrintSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRefreshSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }

        private void btnApplyFilter_Click(object sender, EventArgs e) { }
        private void btnClearFilter_Click(object sender, EventArgs e) { }
        private void btnRetry_Click(object sender, EventArgs e) { }
    }
}
