using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using System.Linq;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class ucDashboard : BaseUserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
            LoadSummaryData();
        }

        private void LoadSummaryData()
        {
            // Aconex-Style Summary: Pulling data from actual tables
            int prjId = Core.Session.SelectedProjectId ?? 1;
            var submittals = DC.DrawingsSubmittalList.GetBy("PrjId = @PrjId AND IsDelete = 0", new { PrjId = prjId });
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Type");
            dt.Columns.Add("Subject");
            dt.Columns.Add("Date");
            dt.Columns.Add("Status");

            // Add the most recent 10 items
            foreach (var item in submittals.OrderByDescending(x => x.CreatedDate).Take(10))
            {
                dt.Rows.Add(item.Type, item.Description, item.CreatedDate?.ToShortDateString(), item.CSTReviewStatus ?? "Draft");
            }

            if (dt.Rows.Count == 0)
            {
                // Fallback to a "No activities" message or dummy data if empty
                dt.Rows.Add("System", "لا توجد تقدیمات جدیدة حالياً", DateTime.Now.ToShortDateString(), "Info");
            }

            gridNotifications.DataSource = dt;
            
            // Apply status coloring to dashboard grid as well
            if (gridNotifications.MainView is DevExpress.XtraGrid.Views.Grid.GridView gv)
            {
                DesignSystem.ApplyStatusColoring(gv, "Status");
            }
        }

        public override void OnProjectChanged()
        {
            base.OnProjectChanged();
            var handle = ShowOverlay();
            try { LoadSummaryData(); }
            finally { CloseOverlay(handle); }
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
