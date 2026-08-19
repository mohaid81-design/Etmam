using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CostControlMgt
{
    public partial class ucCostForecast : XtraUserControl
    {
        public ucCostForecast()
        {
            InitializeComponent();
        }

        private void bbiUpdateForecast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
