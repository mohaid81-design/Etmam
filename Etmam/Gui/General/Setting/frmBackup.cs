using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using Data;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    public partial class frmBackup : XtraForm
    {
        public frmBackup()
        {
            InitializeComponent();
            //DesignSystem.ApplyFormBranding(this);
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
            var server = DBSetting.ActiveProfile?.Server ?? "";
            if (server.IndexOf("database.windows.net", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                MessageBox.Show(
                    "الاتصال الحالي هو قاعدة البيانات السحابية (Azure SQL)، وهذه الخدمة لا تدعم أمر النسخ الاحتياطي اليدوي إلى ملف.\n\n" +
                    "لا داعي للقلق: Azure SQL يقوم تلقائياً بعمل نسخ احتياطية دورية (Point-in-Time Restore) يمكن استرجاعها من خلال بوابة Azure دون أي إجراء إضافي.\n\n" +
                    "لإنشاء نسخة احتياطية محلية بصيغة ملف، الرجاء التبديل إلى الاتصال المحلي من إعدادات الاتصال.",
                    "غير مدعوم على القاعدة السحابية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await ExecuteAsync(async () => {
                string _db = new SqlConnectionStringBuilder(DBSetting.GetConString()).InitialCatalog;
                string fileName = txtFileName.Text + "\\" + _db + "-" + DateTime.Now.ToShortDateString().Replace('/', '-') + "-" + DateTime.Now.ToLongTimeString().Replace(':', '-');

                await Task.Run(() => DatabaseInitializer.ExecuteNonQuery("BACKUP DATABASE " + _db + " to DISK = '" + fileName + ".bak'"));

                this.Invoke(new Action(() => {
                    MessageBox.Show("تم إنشاء النسخة الإحتياطية بنجاح", "إنشاء النسخة الإحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            });
        }
    }
}