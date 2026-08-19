namespace Etmam
{
    public partial class frmProjectCloseoutWizard : DevExpress.XtraEditors.XtraForm
    {
        public frmProjectCloseoutWizard()
        {
            InitializeComponent();
        }

        private void wizCloseout_FinishClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void wizCloseout_CancelClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
