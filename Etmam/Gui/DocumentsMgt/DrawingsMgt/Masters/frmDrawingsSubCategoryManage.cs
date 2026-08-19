using System.Windows.Forms;

namespace Etmam
{
    /// <summary>
    /// Thin modal host for ucDrawingsSubCategory — opened from frmDrawingsAddEdit's lueSubCategory
    /// "manage" button. No Designer.cs: this form has no layout beyond docking the list control.
    /// </summary>
    public class frmDrawingsSubCategoryManage : DevExpress.XtraEditors.XtraForm
    {
        public frmDrawingsSubCategoryManage()
        {
            Text = "إدارة التصنيفات الفرعية للمخططات";
            Size = new System.Drawing.Size(820, 500);
            StartPosition = FormStartPosition.CenterScreen;
            RightToLeft = RightToLeft.Yes;
            Font = new System.Drawing.Font("Cairo", 8.25F);

            var uc = new ucDrawingsSubCategory { Dock = DockStyle.Fill };
            Controls.Add(uc);
        }
    }
}
