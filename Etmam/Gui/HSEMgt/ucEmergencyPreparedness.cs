using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.HSEMgt
{
    public partial class ucEmergencyPreparedness : XtraUserControl
    {
        public ucEmergencyPreparedness()
        {
            InitializeComponent();
        }

        private void bbiNewDrill_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
