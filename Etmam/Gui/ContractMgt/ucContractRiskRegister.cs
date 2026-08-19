using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.ContractMgt
{
    public partial class ucContractRiskRegister : XtraUserControl
    {
        public ucContractRiskRegister()
        {
            InitializeComponent();
        }

        private void bbiNewRisk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiEditRisk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
