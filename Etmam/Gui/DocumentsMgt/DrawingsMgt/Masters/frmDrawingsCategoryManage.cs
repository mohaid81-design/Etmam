using System.Windows.Forms;

namespace Etmam
{
    /// <summary>
    /// Thin modal host for ucDrawingsCategory — opened from frmDrawingsAddEdit's lueCategory "manage" button.
    /// No Designer.cs: this form has no layout beyond docking the list control, so it's built in code.
    /// </summary>
    public class frmDrawingsCategoryManage : DevExpress.XtraEditors.XtraForm
    {
        public frmDrawingsCategoryManage()
        {
            Text = "إدارة تصنيفات المخططات";
            Size = new System.Drawing.Size(700, 500);
            StartPosition = FormStartPosition.CenterScreen;
            RightToLeft = RightToLeft.Yes;
            Font = new System.Drawing.Font("Cairo", 8.25F);

            var uc = new ucDrawingsCategory { Dock = DockStyle.Fill };
            Controls.Add(uc);
        }
    }
}
