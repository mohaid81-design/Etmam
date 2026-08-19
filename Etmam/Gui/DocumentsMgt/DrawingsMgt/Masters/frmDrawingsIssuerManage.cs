using System.Windows.Forms;

namespace Etmam
{
    /// <summary>
    /// Thin modal host for ucDrawingsIssuer — opened from frmDrawingsAddEdit's btnDrawingIssuer.
    /// No Designer.cs: this form has no layout beyond docking the list control.
    /// </summary>
    public class frmDrawingsIssuerManage : DevExpress.XtraEditors.XtraForm
    {
        public frmDrawingsIssuerManage()
        {
            Text = "إدارة جهات إصدار المخططات";
            Size = new System.Drawing.Size(700, 500);
            StartPosition = FormStartPosition.CenterScreen;
            RightToLeft = RightToLeft.Yes;
            Font = new System.Drawing.Font("Cairo", 8.25F);

            var uc = new ucDrawingsIssuer { Dock = DockStyle.Fill };
            Controls.Add(uc);
        }
    }
}
