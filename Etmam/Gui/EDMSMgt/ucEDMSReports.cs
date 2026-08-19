using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam.Gui.EDMSMgt
{
    public partial class ucEDMSReports : XtraUserControl
    {
        public ucEDMSReports()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e) { }
        private void btnPrint_Click(object sender, EventArgs e) { }
        private void btnExportExcel_Click(object sender, EventArgs e) { }
        private void btnExportPdf_Click(object sender, EventArgs e) { }
    }
}
