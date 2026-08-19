using System.Windows.Forms;

namespace Etmam
{
    /// <summary>
    /// Thin modal host for ucDisciplinesList — opened from the main menu's "التخصصات" item.
    /// No Designer.cs: this form has no layout beyond docking the list control, so it's built in code.
    /// </summary>
    public class frmDisciplinesManage : DevExpress.XtraEditors.XtraForm
    {
        public frmDisciplinesManage()
        {
            Text = "إدارة التخصصات";
            Size = new System.Drawing.Size(700, 500);
            StartPosition = FormStartPosition.CenterScreen;
            RightToLeft = RightToLeft.Yes;
            Font = new System.Drawing.Font("Cairo", 8.25F);

            var uc = new ucDisciplinesList { Dock = DockStyle.Fill };
            Controls.Add(uc);
        }
    }
}
