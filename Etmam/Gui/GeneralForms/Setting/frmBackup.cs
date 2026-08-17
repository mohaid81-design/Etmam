using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using Data;

namespace Etmam
{
    public partial class frmBackup : XtraForm
    {
        public frmBackup()
        {
            InitializeComponent();
            DesignSystem.ApplyFormBranding(this);
        }

        protected DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle ShowOverlay()
        {
            return DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(this);
        }

        protected void CloseOverlay(DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(handle);
        }

        protected async Task ExecuteAsync(Func<Task> task)
        {
            var handle = ShowOverlay();
            try
            {
                await task();
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            if (xtraFolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            { txtFileName.Text = xtraFolderBrowserDialog1.SelectedPath; }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            await ExecuteAsync(async () => {
                string _db = Properties.Settings.Default.DataBase;
                string fileName = txtFileName.Text + "\\" + _db + "-" + DateTime.Now.ToShortDateString().Replace('/', '-') + "-" + DateTime.Now.ToLongTimeString().Replace(':', '-');
                
                await Task.Run(() => DatabaseInitializer.ExecuteNonQuery("BACKUP DATABASE " + _db + " to DISK = '" + fileName + ".bak'"));

                this.Invoke(new Action(() => {
                    MessageBox.Show("تم إنشاء النسخة الإحتياطية بنجاح", "إنشاء النسخة الإحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            });
        }
    }
}