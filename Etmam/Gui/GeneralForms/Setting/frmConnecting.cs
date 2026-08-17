using System;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmConnecting : XtraForm
    {
        public frmConnecting()
        {
            InitializeComponent();
            DesignSystem.ApplyFormBranding(this);
            GetSettings();
        }

        private void GetSettings()
        {
            if (Properties.Settings.Default.ConType == "local")
            {
                radioButtonLocal.Checked = true;
                lookUpServer.Text = Properties.Settings.Default.Server;
                txtDataBase.Text = Properties.Settings.Default.DataBase;
                txtUser.Text = Properties.Settings.Default.UserName;
                txtUserPassword.Text = Properties.Settings.Default.UserPassword;
            }
            else
            {
                radioButtonNetwork.Checked = true;
                lookUpServer.Text = Properties.Settings.Default.WebServer;
                txtDataBase.Text = Properties.Settings.Default.WebDataBase;
                txtUser.Text = Properties.Settings.Default.WebUserName;
                txtUserPassword.Text = Properties.Settings.Default.WebUserPassword;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (radioButtonLocal.Checked) 
            {
                Properties.Settings.Default.ConType = "local";
                Properties.Settings.Default.Server = lookUpServer.Text;
                Properties.Settings.Default.DataBase = txtDataBase.Text;
                Properties.Settings.Default.UserName = txtUser.Text;
                Properties.Settings.Default.UserPassword = txtUserPassword.Text;
            }
            else 
            { 
                Properties.Settings.Default.ConType = "network";
                Properties.Settings.Default.WebServer = lookUpServer.Text;
                Properties.Settings.Default.WebDataBase = txtDataBase.Text;
                Properties.Settings.Default.WebUserName = txtUser.Text;
                Properties.Settings.Default.WebUserPassword = txtUserPassword.Text;
            }

            Properties.Settings.Default.Save();
            MessageBox.Show("تم حفظ الاعدادات");
            Application.Restart();
        }

        private void radioButtonLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLocal.Checked)
            {
                lookUpServer.Text = Properties.Settings.Default.Server;
                txtDataBase.Text = Properties.Settings.Default.DataBase;
                txtUser.Text = Properties.Settings.Default.UserName;
                txtUserPassword.Text = Properties.Settings.Default.UserPassword;
            }
            else
            {
                lookUpServer.Text = Properties.Settings.Default.WebServer;
                txtDataBase.Text = Properties.Settings.Default.WebDataBase;
                txtUser.Text = Properties.Settings.Default.WebUserName;
                txtUserPassword.Text = Properties.Settings.Default.WebUserPassword;
            }
        }

        private void radioButtonNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNetwork.Checked)
            {
                lookUpServer.Text = Properties.Settings.Default.WebServer;
                txtDataBase.Text = Properties.Settings.Default.WebDataBase;
                txtUser.Text = Properties.Settings.Default.WebUserName;
                txtUserPassword.Text = Properties.Settings.Default.WebUserPassword;
            }
            else
            {
                lookUpServer.Text = Properties.Settings.Default.Server;
                txtDataBase.Text = Properties.Settings.Default.DataBase;
                txtUser.Text = Properties.Settings.Default.UserName;
                txtUserPassword.Text = Properties.Settings.Default.UserPassword;
            }
        }
    }
}