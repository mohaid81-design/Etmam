using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Data;

namespace Etmam
{
    public partial class frmRestore : XtraForm
    {
        public frmRestore()
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
            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK) { txtFileName.Text = xtraOpenFileDialog1.FileName; }
        }

        private async void btnRestore_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text == string.Empty) { MessageBox.Show("يجب بيان مسار ملف النسخة الإحتياطية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            await ExecuteAsync(async () =>
            {
                string _db = Properties.Settings.Default.DataBase;
                string sql = $"ALTER DATABASE [{_db}] SET OFFLINE WITH ROLLBACK IMMEDIATE; " +
                             $"RESTORE DATABASE [{_db}] FROM DISK = '{txtFileName.Text}' WITH REPLACE; " +
                             $"ALTER DATABASE [{_db}] SET ONLINE;";

                await Task.Run(() => DatabaseInitializer.ExecuteNonQuery(sql));

                this.Invoke(new Action(() =>
                {
                    MessageBox.Show("تم استعادة النسخة الإحتياطية بنجاح", "استعادة النسخة الإحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            });
        }
    }
}