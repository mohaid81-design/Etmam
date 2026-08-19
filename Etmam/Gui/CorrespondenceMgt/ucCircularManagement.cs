using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CorrespondenceMgt
{
    public partial class ucCircularManagement : XtraUserControl
    {
        public ucCircularManagement()
        {
            InitializeComponent();
        }

        private void bbiNewCircular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditCircular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
