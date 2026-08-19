using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.QualityMgt
{
    public partial class ucChecklistLibrary : XtraUserControl
    {
        public ucChecklistLibrary()
        {
            InitializeComponent();
        }

        private void bbiNewChecklist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiVersion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiArchive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
    }
}
