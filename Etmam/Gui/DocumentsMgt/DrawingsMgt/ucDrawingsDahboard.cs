using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using Core;

namespace Etmam
{
    public partial class ucDrawingsDahboard : DevExpress.XtraEditors.XtraUserControl
    {
        // A drawing pending CST review for longer than this is flagged "متأخرة" — no SLA field
        // exists on the entity, so this is a documented assumption, easy to adjust.
        private const int OverdueDays = 7;

        private const string StatusPending = "قيد المراجعة";
        private const string StatusApproved = "معتمد";
        private const string StatusApprovedWithComments = "معتمد مع ملاحظات";
        private const string StatusRejected = "مرفوض";
        private const string StatusReviseResubmit = "يتطلب تعديل وإعادة تقديم";

        private List<DrawingsType> _drawingTypes = new();
        private RepositoryItemLookUpEdit? _repoTypePending;
        private RepositoryItemLookUpEdit? _repoTypeRecent;

        private class NotificationRow
        {
            public string Message { get; set; } = "";
        }

        public ucDrawingsDahboard()
        {
            InitializeComponent();
        }

        public void LoadDashboardData()
        {
            if (DesignMode) return;

            var handle = ShowOverlay();
            try
            {
                var dc = Data.DataContext.Shared;
                int prjId = Session.SelectedProjectId ?? 1;

                _drawingTypes = dc.DrawingsType.GetAll();
                EnsureTypeLookups();

                var all = dc.DrawingsRegisterList.GetBy("PrjId = @PrjId AND IsDelete = 0", new { PrjId = prjId });
                var latest = all
                    .GroupBy(x => x.Num)
                    .Select(g => g.OrderByDescending(x => x.Rev).First())
                    .ToList();

                var approved = latest.Where(r => r.CSTReviewStatus == StatusApproved || r.CSTReviewStatus == StatusApprovedWithComments).ToList();
                var pending = latest.Where(r => string.IsNullOrEmpty(r.CSTReviewStatus) || r.CSTReviewStatus == StatusPending).ToList();
                var rejected = latest.Where(r => r.CSTReviewStatus == StatusRejected || r.CSTReviewStatus == StatusReviseResubmit).ToList();
                var overdue = pending.Where(r => DaysWaiting(r) > OverdueDays).ToList();

                SetTileNumber(tileItem1, latest.Count.ToString());
                SetTileNumber(tileItem2, approved.Count.ToString());
                SetTileNumber(tileItem3, pending.Count.ToString());
                SetTileNumber(tileItem4, rejected.Count.ToString());
                SetTileNumber(tileItem5, overdue.Count.ToString());

                gridView1.CustomUnboundColumnData -= GridView1_CustomUnboundColumnData;
                gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
                gridControl1.DataSource = pending
                    .OrderByDescending(DaysWaiting)
                    .ToList();

                gridControl2.DataSource = latest
                    .OrderByDescending(r => ParseDate(r.SubmittedDate) ?? DateTime.MinValue)
                    .Take(50)
                    .ToList();

                LoadChart(latest);
                LoadNotifications(overdue);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private static int DaysWaiting(DrawingsRegisterList r)
        {
            var submitted = ParseDate(r.SubmittedDate);
            return submitted.HasValue ? (int)(DateTime.Today - submitted.Value.Date).TotalDays : 0;
        }

        private static DateTime? ParseDate(string? s) => DateTime.TryParse(s, out var d) ? d : null;

        private void GridView1_CustomUnboundColumnData(object? sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "WaitingDays" && e.IsGetData && e.Row is DrawingsRegisterList row)
                e.Value = DaysWaiting(row);
        }

        private void EnsureTypeLookups()
        {
            if (_repoTypePending == null)
            {
                _repoTypePending = new RepositoryItemLookUpEdit();
                gridControl1.RepositoryItems.Add(_repoTypePending);
                gridColumn1.ColumnEdit = _repoTypePending;
            }
            _repoTypePending.DataSource = _drawingTypes;
            _repoTypePending.DisplayMember = "Name";
            _repoTypePending.ValueMember = "Id";

            if (_repoTypeRecent == null)
            {
                _repoTypeRecent = new RepositoryItemLookUpEdit();
                gridControl2.RepositoryItems.Add(_repoTypeRecent);
                colType.ColumnEdit = _repoTypeRecent;
            }
            _repoTypeRecent.DataSource = _drawingTypes;
            _repoTypeRecent.DisplayMember = "Name";
            _repoTypeRecent.ValueMember = "Id";
        }

        private void LoadChart(List<DrawingsRegisterList> latest)
        {
            var buckets = new (string Label, int Count)[]
            {
                (StatusApproved, latest.Count(r => r.CSTReviewStatus == StatusApproved)),
                (StatusApprovedWithComments, latest.Count(r => r.CSTReviewStatus == StatusApprovedWithComments)),
                (StatusPending, latest.Count(r => string.IsNullOrEmpty(r.CSTReviewStatus) || r.CSTReviewStatus == StatusPending)),
                (StatusRejected, latest.Count(r => r.CSTReviewStatus == StatusRejected)),
                (StatusReviseResubmit, latest.Count(r => r.CSTReviewStatus == StatusReviseResubmit)),
            };

            var series = chartControl1.Series[0];
            series.Points.Clear();
            foreach (var b in buckets.Where(b => b.Count > 0))
                series.Points.Add(new SeriesPoint(b.Label, b.Count));
        }

        private void LoadNotifications(List<DrawingsRegisterList> overdue)
        {
            var notifications = overdue
                .OrderByDescending(DaysWaiting)
                .Select(r => new NotificationRow
                {
                    Message = $"🔔 المخطط رقم {r.Num} متأخر عن الرد منذ {DaysWaiting(r)} يوماً"
                })
                .ToList();

            if (notifications.Count == 0)
                notifications.Add(new NotificationRow { Message = "لا توجد إشعارات حالياً." });

            gridControl3.DataSource = notifications;
        }

        private static void SetTileNumber(TileItem tile, string value)
        {
            foreach (TileItemElement el in tile.Elements)
                if (el.TextAlignment == TileItemContentAlignment.TopRight)
                    el.Text = value;
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
