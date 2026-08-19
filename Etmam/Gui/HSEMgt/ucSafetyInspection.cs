using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.HSEMgt
{
    public partial class ucSafetyInspection : XtraUserControl
    {
        public ucSafetyInspection()
        {
            InitializeComponent();
        }

        private void bbiNewInspection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditInspection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
