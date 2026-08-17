using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Core;
using DevExpress.XtraEditors;
using Data;

namespace Etmam
{
    public partial class ucWorkDoneToday : BaseUserControl
    {
        // Activity lookup cache shared across sub-grids
        private Dictionary<int, ActivityList> _activityCache = new Dictionary<int, ActivityList>();

        public ucWorkDoneToday()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        public override void Initialize(int dailyReportId, int projectId, DateTime reportDate)
        {
            base.Initialize(dailyReportId, projectId, reportDate);

            if (!_isInitialized)
            {
                // Toolbar events
                bbiAdd.ItemClick    += (s, e) => AddActivities();
                bbiDelete.ItemClick += (s, e) => GetActiveGrid()?.ConfirmAndDeleteFocusedRow();
                bbiCopy.ItemClick   += (s, e) => HandleToolbarCopy();

                // Initialize sub-grids
                ucGridStr.Initialize("إنشائي", _activityCache, dailyReportId, projectId, reportDate);
                ucGridArc.Initialize("معماري", _activityCache, dailyReportId, projectId, reportDate);
                ucGridMec.Initialize("ميكانيكا", _activityCache, dailyReportId, projectId, reportDate);
                ucGridElc.Initialize("كهرباء", _activityCache, dailyReportId, projectId, reportDate);
                ucGridOther.Initialize("أخرى", _activityCache, dailyReportId, projectId, reportDate);

                // Bubble up data changed events
                ucGridStr.DataChanged   += () => { OnDataChanged(); UpdateRecordCount(); };
                ucGridArc.DataChanged   += () => { OnDataChanged(); UpdateRecordCount(); };
                ucGridMec.DataChanged   += () => { OnDataChanged(); UpdateRecordCount(); };
                ucGridElc.DataChanged   += () => { OnDataChanged(); UpdateRecordCount(); };
                ucGridOther.DataChanged += () => { OnDataChanged(); UpdateRecordCount(); };

                StyleTabs();
                _isInitialized = true;
            }

            LoadData();
            UpdateRecordCount();
        }


        private ucWorkDoneCategoryGrid GetActiveGrid()
        {
            return xtraTabControlWork.SelectedTabPageIndex switch
            {
                0 => ucGridStr,
                1 => ucGridArc,
                2 => ucGridMec,
                3 => ucGridElc,
                4 => ucGridOther,
                _ => ucGridStr
            };
        }

        private string GetActiveCategory()
        {
            return xtraTabControlWork.SelectedTabPageIndex switch
            {
                0 => "إنشائي",
                1 => "معماري",
                2 => "ميكانيكا",
                3 => "كهرباء",
                _ => "أخرى"
            };
        }

        private void UpdateRecordCount()
        {
            int total = ucGridStr.GetItems().Count + ucGridArc.GetItems().Count + 
                        ucGridMec.GetItems().Count + ucGridElc.GetItems().Count + 
                        ucGridOther.GetItems().Count;
            barStaticItem1.Caption = $"عدد السجلات : {total}";
        }

        public void LoadData()
        {
            ucGridStr.Clear();
            ucGridArc.Clear();
            ucGridMec.Clear();
            ucGridElc.Clear();
            ucGridOther.Clear();
            _activityCache.Clear();

            if (CurrentDailyReportId == 0) return;

            // Load Activities for cache
            var activities = DC.ActivityList.GetBy("IsDelete = 0", null);
            foreach (var act in activities) _activityCache[act.Id] = act;

            // Load WorkDone items
            var workDoneItems = DC.DailyReportWorkDone
                .GetBy("DailyReportId = @drId AND IsDelete = 0", new { drId = CurrentDailyReportId });

            foreach (var item in workDoneItems)
            {
                string cat = string.Empty;
                if (item.ActivityId.HasValue && _activityCache.TryGetValue(item.ActivityId.Value, out var act))
                    cat = act.Category ?? string.Empty;

                var grid = GetGridByRowCategory(cat);
                grid.GetItems().Add(item);
            }
        }

        private ucWorkDoneCategoryGrid GetGridByRowCategory(string category)
        {
            return category switch
            {
                "إنشائي" => ucGridStr,
                "معماري" => ucGridArc,
                "ميكانيكا" => ucGridMec,
                "كهرباء" => ucGridElc,
                _ => ucGridOther
            };
        }

        public override void SaveData(int dailyReportId)
        {
            var allGrids = new[] { ucGridStr, ucGridArc, ucGridMec, ucGridElc, ucGridOther };
            foreach (var grid in allGrids)
            {
                grid.SaveData(dailyReportId);
            }
        }

        private void AddActivities()
        {
            var allItems = ucGridStr.GetItems().Concat(ucGridArc.GetItems())
                .Concat(ucGridMec.GetItems()).Concat(ucGridElc.GetItems()).Concat(ucGridOther.GetItems());

            var excludedIds = allItems
                .Where(x => x.ActivityId != null)
                .Select(x => x.ActivityId!.Value)
                .ToList();

            using (var frm = new frmActivitySelect())
            {
                frm.IsSelectionMode = true;
                frm.ExcludedIds = excludedIds;
                frm.FilterCategory = GetActiveCategory();

                if (frm.ShowDialog() == DialogResult.OK && frm.SelectedItems.Count > 0)
                {
                    foreach (var act in frm.SelectedItems)
                    {
                        // Update cache
                        if (!_activityCache.ContainsKey(act.Id)) _activityCache[act.Id] = act;
                        
                        // Add to appropriate grid
                        GetGridByRowCategory(act.Category).AddActivities(new List<ActivityList> { act });
                    }
                }
            }
        }

        private void HandleToolbarCopy()
        {
            var lastReport = DC.DailyReport.GetBy(
                "PrjId = @pId AND ReportDate < @rDate AND IsDelete = 0 ORDER BY ReportDate DESC",
                new { pId = CurrentProjectId, rDate = CurrentReportDate }).FirstOrDefault();

            if (lastReport == null)
            {
                XtraMessageBox.Show("لا يوجد تقرير سابق لنسخ البيانات منه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CopyFromPrevious(lastReport.Id);
        }

        public override int CopyFromPrevious(int lastReportId)
        {
            if (lastReportId == 0) return 0;

            int addedCount = 0;
            addedCount += ucGridStr.CopyFromPrevious(lastReportId);
            addedCount += ucGridArc.CopyFromPrevious(lastReportId);
            addedCount += ucGridMec.CopyFromPrevious(lastReportId);
            addedCount += ucGridElc.CopyFromPrevious(lastReportId);
            addedCount += ucGridOther.CopyFromPrevious(lastReportId);

            if (addedCount > 0)
            {
                XtraMessageBox.Show($"تم نسخ {addedCount} سجل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataChanged();
                UpdateRecordCount();
            }
            return addedCount;
        }

        private void StyleTabs()
        {
            var styles = new (Color normal, Color active, Color fore)[]
            {
                (Color.FromArgb(204, 102, 0), Color.FromArgb(180, 80, 0), Color.White), // Structural
                (Color.FromArgb(23, 96, 158), Color.FromArgb(10, 75, 135), Color.White), // Architectural
                (Color.FromArgb(30, 140, 80), Color.FromArgb(15, 110, 60), Color.White), // Mechanical
                (Color.FromArgb(120, 50, 160), Color.FromArgb(90, 30, 130), Color.White), // Electrical
                (Color.FromArgb(70, 85, 100), Color.FromArgb(50, 65, 80), Color.White), // Other
            };

            var pages = new[] { tabStr, tabArc, tabMec, tabElc, tabOther };
            var font = new Font("Cairo", 9F, FontStyle.Bold);

            for (int i = 0; i < pages.Length; i++)
            {
                var pg = pages[i];
                var s = styles[i];
                pg.Appearance.Header.BackColor = s.normal;
                pg.Appearance.Header.ForeColor = s.fore;
                pg.Appearance.Header.Font = font;
                pg.Appearance.HeaderActive.BackColor = s.active;
                pg.Appearance.HeaderActive.ForeColor = s.fore;
                pg.Appearance.HeaderActive.Font = font;
            }
        }
    }
}
