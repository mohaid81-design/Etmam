using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;

namespace Etmam
{
    public partial class ucProcurementDashboard : DevExpress.XtraEditors.XtraUserControl
    {

        public ucProcurementDashboard()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadDashboardData();
        }

        public void LoadDashboardData()
        {
        }

    }

}
