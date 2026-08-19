using System.Windows.Forms;

namespace Etmam
{
    /// <summary>
    /// Thin modal host for ucInspectionActivitiesList — mirrors frmSecondaryDisciplinesManage's own pattern.
    /// No Designer.cs: this form has no layout beyond docking the list control, so it's built in code.
    /// </summary>
    public class frmInspectionActivitiesManage : DevExpress.XtraEditors.XtraForm
    {
        public frmInspectionActivitiesManage()
        {
            Text = "إدارة أنشطة الفحص";
            Size = new System.Drawing.Size(820, 500);
            StartPosition = FormStartPosition.CenterScreen;
            RightToLeft = RightToLeft.Yes;
            Font = new System.Drawing.Font("Cairo", 8.25F);

            var uc = new ucInspectionActivitiesList { Dock = DockStyle.Fill };
            Controls.Add(uc);
        }
    }
}
