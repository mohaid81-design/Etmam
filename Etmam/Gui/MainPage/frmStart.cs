using Data;
using System;
using System.Drawing;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmStart : XtraForm
    {
        public frmStart()
        {
            InitializeComponent();
            DesignSystem.ApplyFormBranding(this);
        }

        private void linkLabelSetServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Show Settings Form
            frmConnecting frm = new frmConnecting();
            frm.Show();
        }

        private void linkLabelExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private async void timerStart_Tick(object sender, EventArgs e)
        {
            // Check the connection
            labelState.Text = "جاري الاتصال..";
            if (await DBSetting.CanConnectAsync())
            {
                timerStart.Enabled = false;
                
                // Ensure Database is initialized (schema + seeding)
                DatabaseInitializer.Initialize();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                panelSettings.Visible = true;
                labelState.Text = "فشل الاتصال ... جاري إعاده الإتصال";
            }
        }
    }
}