using System.Windows.Forms;

namespace Etmam
{
    /// <summary>
    /// Thin modal host for ucBuildingsList — mirrors frmDisciplinesManage's own pattern.
    /// No Designer.cs: this form has no layout beyond docking the list control, so it's built in code.
    /// </summary>
    public class frmBuildingsManage : DevExpress.XtraEditors.XtraForm
    {
        public frmBuildingsManage()
        {
            Text = "إدارة المباني";
            Size = new System.Drawing.Size(760, 500);
            StartPosition = FormStartPosition.CenterScreen;
            RightToLeft = RightToLeft.Yes;
            Font = new System.Drawing.Font("Cairo", 8.25F);

            var uc = new ucBuildingsList { Dock = DockStyle.Fill };
            Controls.Add(uc);
        }
    }
}
