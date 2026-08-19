using System;
using System.Windows.Forms;

namespace Etmam
{
    public partial class ucActivityEditor : DevExpress.XtraEditors.XtraUserControl
    {
        public ucActivityEditor()
        {
            InitializeComponent();
        }

        private void bbiNewActivity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiDeleteActivity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiDuplicateActivity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiLinkActivities_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiUnlinkActivities_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiSaveActivity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiValidateActivity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void btnRetry_Click(object sender, EventArgs e) { }
    }
}
