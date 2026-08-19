using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.CostControlMgt
{
    public partial class ucCostForecastScenarios : XtraUserControl
    {
        public ucCostForecastScenarios()
        {
            InitializeComponent();
        }

        private void bbiNewScenario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiSimulate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
