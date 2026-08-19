using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.EDMSMgt
{
    public partial class ucVersionControl : XtraUserControl
    {
        public ucVersionControl()
        {
            InitializeComponent();
        }

        private void bbiCompareRevisions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiRollbackRevision_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiDownloadRevision_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
