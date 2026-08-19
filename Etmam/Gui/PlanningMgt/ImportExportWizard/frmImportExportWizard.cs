using System;
using System.Windows.Forms;

namespace Etmam
{
    public partial class frmImportExportWizard : DevExpress.XtraEditors.XtraForm
    {
        public frmImportExportWizard()
        {
            InitializeComponent();
        }

        private void wizardControlMain_FinishClick(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void wizardControlMain_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e) { }
        private void wizardControlMain_CancelClick(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void btnBrowseFile_Click(object sender, EventArgs e) { }
    }
}
