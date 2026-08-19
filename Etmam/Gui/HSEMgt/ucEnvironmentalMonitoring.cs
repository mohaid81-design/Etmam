using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.HSEMgt
{
    public partial class ucEnvironmentalMonitoring : XtraUserControl
    {
        public ucEnvironmentalMonitoring()
        {
            InitializeComponent();
        }

        private void bbiNewReading_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
