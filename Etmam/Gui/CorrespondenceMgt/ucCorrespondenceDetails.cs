using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CorrespondenceMgt
{
    public partial class ucCorrespondenceDetails : XtraUserControl
    {
        public ucCorrespondenceDetails()
        {
            InitializeComponent();
        }

        private void bbiEditDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrintDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
