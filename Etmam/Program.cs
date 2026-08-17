using System;
using System.Windows.Forms;

namespace Etmam
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Ensure database and tables are created/updated ONCE at startup
            Data.DatabaseInitializer.Initialize();

            using (var start = new frmStart())
            {
                if (start.ShowDialog() == DialogResult.OK)
                {
                    using (var login = new frmLogin())
                    {
                        if (login.ShowDialog() == DialogResult.OK)
                        {
                            Application.Run(new frmMainPage());
                        }
                    }
                }
            }
        }
    }
}