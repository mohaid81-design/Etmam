using System.Windows.Forms;

namespace Etmam
{
    /// <summary>
    /// Thin modal host for ucSecondaryDisciplinesList — mirrors frmDisciplinesManage's own pattern.
    /// No Designer.cs: this form has no layout beyond docking the list control, so it's built in code.
    /// </summary>
    public class frmSecondaryDisciplinesManage : DevExpress.XtraEditors.XtraForm
    {
        public frmSecondaryDisciplinesManage()
        {
            Text = "إدارة التخصصات الثانوية";
            Size = new System.Drawing.Size(760, 500);
            StartPosition = FormStartPosition.CenterScreen;
            RightToLeft = RightToLeft.Yes;
            Font = new System.Drawing.Font("Cairo", 8.25F);

            var uc = new ucSecondaryDisciplinesList { Dock = DockStyle.Fill };
            Controls.Add(uc);
        }
    }
}
