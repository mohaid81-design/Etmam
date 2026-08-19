using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CorrespondenceMgt
{
    public partial class ucMeetingMinutes : XtraUserControl
    {
        public ucMeetingMinutes()
        {
            InitializeComponent();
        }

        private void bbiNewMeeting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiApprove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
