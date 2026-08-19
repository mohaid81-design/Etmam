using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.HSEMgt
{
    public partial class ucToolboxTalk : XtraUserControl
    {
        public ucToolboxTalk()
        {
            InitializeComponent();
        }

        private void bbiNewTbt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiSignAttendance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
