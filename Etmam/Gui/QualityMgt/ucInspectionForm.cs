using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.QualityMgt
{
    public partial class ucInspectionForm : XtraUserControl
    {
        public ucInspectionForm()
        {
            InitializeComponent();
        }

        private void btnPass_Click(object sender, EventArgs e) { }
        private void btnFail_Click(object sender, EventArgs e) { }
        private void btnConditionalPass_Click(object sender, EventArgs e) { }
    }
}
