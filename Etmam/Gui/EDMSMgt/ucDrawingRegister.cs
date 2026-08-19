using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.EDMSMgt
{
    public partial class ucDrawingRegister : XtraUserControl
    {
        public ucDrawingRegister()
        {
            InitializeComponent();
        }

        private void bbiNewDrawing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditDrawing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
