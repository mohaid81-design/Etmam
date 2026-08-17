using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public static class DailyReportPrinter
    {
        public static async Task PrintAsync(int reportId, Control owner)
        {
            if (reportId == 0) return;

            IOverlaySplashScreenHandle handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(owner);
                var _db = DataContext.Shared;

                // Fetch full report data including all sub-collections asynchronously
                var reportData = await _db.DailyReport.FindAsync(reportId);
                if (reportData == null) return;

                // Bulk fetch Project and Sub-collections
                string drFilter = "DailyReportId = @id";
                var param = new { id = reportId };

                // Execute all data fetching in parallel for speed
                var taskProject = _db.ProjectsList.FindAsync(reportData.PrjId);
                var taskManpowers = _db.DailyReportManpower.GetByAsync(drFilter, param);
                var taskEquipments = _db.DailyReportEquipment.GetByAsync(drFilter, param);
                var taskWorkDone = _db.DailyReportWorkDone.GetByAsync(drFilter, param);
                var taskWorkPlanned = _db.DailyReportWorkPlanned.GetByAsync(drFilter, param);
                var taskMaterials = _db.DailyReportMaterial.GetByAsync(drFilter, param);
                var taskIssues = _db.DailyReportIssue.GetByAsync(drFilter, param);
                var taskInspections = _db.DailyReportInspection.GetByAsync(drFilter, param);
                var taskDisrupted = _db.DailyReportDisruptedActivity.GetByAsync(drFilter, param);

                await Task.WhenAll(taskProject, taskManpowers, taskEquipments, taskWorkDone, taskWorkPlanned, taskMaterials, taskIssues, taskInspections, taskDisrupted);

                reportData.Project = taskProject.Result;
                reportData.Manpowers = taskManpowers.Result;
                reportData.Equipments = taskEquipments.Result;
                reportData.WorkDones = taskWorkDone.Result;
                reportData.WorkPlanneds = taskWorkPlanned.Result;
                reportData.Materials = taskMaterials.Result;
                reportData.Issues = taskIssues.Result;
                reportData.Inspections = taskInspections.Result;
                reportData.DisruptedActivities = taskDisrupted.Result;

                if (reportData.Project != null)
                {
                    var taskClient = _db.StakeholdersList.FindAsync(reportData.Project.CLId ?? 0);
                    var taskConsultant = _db.StakeholdersList.FindAsync(reportData.Project.CSTId ?? 0);
                    await Task.WhenAll(taskClient, taskConsultant);
                    reportData.Project.Client = taskClient.Result;
                    reportData.Project.Consultant = taskConsultant.Result;
                }

                // Batch Fetch Lookups for Manpower and Equipment to solve N+1 Problem
                if (reportData.Manpowers.Any())
                {
                    var mpIds = reportData.Manpowers.Select(m => m.ManpowerListId).Distinct().ToList();
                    var mpList = await _db.ManpowerList.GetBySqlAsync($"SELECT * FROM ManpowerList WHERE Id IN ({string.Join(",", mpIds)})");
                    foreach (var mp in reportData.Manpowers)
                        mp.Manpower = mpList.FirstOrDefault(l => l.Id == mp.ManpowerListId);
                }

                if (reportData.Equipments.Any())
                {
                    var eqIds = reportData.Equipments.Select(e => e.EquipmentListId).Distinct().ToList();
                    var eqList = await _db.EquipmentList.GetBySqlAsync($"SELECT * FROM EquipmentList WHERE Id IN ({string.Join(",", eqIds)})");
                    foreach (var eq in reportData.Equipments)
                        eq.Equipment = eqList.FirstOrDefault(l => l.Id == eq.EquipmentListId);
                }

                if (reportData.WorkDones.Any())
                {
                    var actIds = reportData.WorkDones
                        .Where(w => w.ActivityId.HasValue)
                        .Select(w => w.ActivityId!.Value)
                        .Distinct()
                        .ToList();

                    if (actIds.Any())
                    {
                        var activityList = await _db.ActivityList.GetBySqlAsync($"SELECT * FROM ActivityList WHERE Id IN ({string.Join(",", actIds)})");
                        foreach (var wd in reportData.WorkDones)
                        {
                            if (wd.ActivityId.HasValue)
                                wd.Activity = activityList.FirstOrDefault(a => a.Id == wd.ActivityId.Value);
                        }
                    }
                }

                // Create and show report
                var rpt = new Etmam.rptDailyReport();
                rpt.DataSource = new List<DailyReport> { reportData };

                ReportPrintTool tool = new ReportPrintTool(rpt);

                if (handle != null)
                {
                    SplashScreenManager.CloseOverlayForm(handle);
                    handle = null;
                }

                tool.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("حدث خطأ أثناء إعداد التقرير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (handle != null)
                    SplashScreenManager.CloseOverlayForm(handle);
            }
        }
    }
}
