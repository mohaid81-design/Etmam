using DevExpress.XtraEditors;

namespace Etmam
{
    public class frmProjectsMgt : XtraForm
    {
        public frmProjectsMgt()
        {
            Text = "إدارة المشاريع";
            Width = 1100;
            Height = 700;
            StartPosition = FormStartPosition.CenterParent;
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            var uc = new ucProjectsMgt { Dock = System.Windows.Forms.DockStyle.Fill };
            Controls.Add(uc);

            DesignSystem.ApplyCairoFont(this);
        }
    }
}
