using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.QualityMgt
{
    public partial class ucMaterialInspection : XtraUserControl
    {
        public ucMaterialInspection()
        {
            InitializeComponent();
        }

        private void bbiNewInspection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiApprove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiReject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
