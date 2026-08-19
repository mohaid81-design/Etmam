using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Single-record print/export for Construction Inspection Requests — shared by
    /// frmCIRAddEdit's print/email buttons and ucCIR's per-row print column, so the report-hydration
    /// logic (project/client/consultant names) lives in exactly one place.</summary>
    public static class CIRPrinter
    {
        private static DataContext DC => DataContext.Shared;

        /// <summary>Populates the in-memory (NotMapped) print-only fields so the report's
        /// PrjName/SponsorName/CSTName bindings resolve — mirrors DailyReportPrinter's approach of
        /// hydrating extra data right before handing the record to the report.</summary>
        public static ConstructionInspectionRequestList BuildPrintRecord(ConstructionInspectionRequestList rec)
        {
            if (rec.DisciplineId != null)
            {
                var discipline = DC.DisciplinesList.Find(rec.DisciplineId.Value);
                rec.DisciplineCode = discipline?.Code;
                rec.DisciplineName = discipline?.Name;
            }
            if (rec.SecondaryDisciplineId != null)
            {
                var secondaryDiscipline = DC.SecondaryDisciplinesList.Find(rec.SecondaryDisciplineId.Value);
                rec.SecondaryDisciplineCode = secondaryDiscipline?.Code;
                rec.SecondaryDisciplineName = secondaryDiscipline?.Name;
            }
            if (rec.InspectionActivityId != null)
            {
                var inspectionActivity = DC.InspectionActivityList.Find(rec.InspectionActivityId.Value);
                rec.InspectionActivityCode = inspectionActivity?.Code;
                rec.InspectionActivityName = inspectionActivity?.Name;
            }

            rec.PrintNum = CIRNumberFormatter.Format(rec);

            // "بيانات طلب الإعتماد السابق" — يُملأ فقط لإصدار مُعاد (Rev > 0)، بربط الإصدار السابق عبر
            // نفس المفتاح الطبيعي (Num/PrjId/DisciplineId) الذي يستخدمه CIRReissuer نفسه لحساب maxRev،
            // إذ لا يوجد FK مباشر يربط إصداراً بسابقه (انظر CIRReissuer.Reissue).
            if (rec.Rev is > 0 && rec.Num != null)
            {
                var previous = DC.ConstructionInspectionRequestList
                    .GetBy("IsDelete = 0 AND Num = @num AND PrjId = @PrjId AND DisciplineId = @DisciplineId AND Rev = @prevRev",
                        new { num = rec.Num, rec.PrjId, rec.DisciplineId, prevRev = rec.Rev.Value - 1 })
                    .FirstOrDefault();

                if (previous != null)
                {
                    rec.PrintPreviousCIRNum = CIRNumberFormatter.Format(previous.Num, rec.DisciplineCode, rec.SecondaryDisciplineCode, previous.Rev);
                    rec.PrintPreviousCIRDate = previous.SubmittedDate;
                    rec.PrintPreviousResult = previous.CSTReviewStatus;
                }
            }

            if (rec.BuildingId != null)
                rec.BuildingName = DC.BuildingsList.Find(rec.BuildingId.Value)?.Name;
            if (!string.IsNullOrWhiteSpace(rec.FloorIds))
            {
                var floorIds = rec.FloorIds.Split(',')
                    .Select(s => int.TryParse(s.Trim(), out var id) ? id : (int?)null)
                    .Where(id => id.HasValue)
                    .Select(id => id!.Value);
                var floorNames = floorIds.Select(id => DC.FloorsList.Find(id)?.Name).Where(n => !string.IsNullOrEmpty(n));
                rec.FloorName = string.Join("، ", floorNames);
            }

            // "الموقع" المطبوع = المبنى + الطابق + الموقع مجمَّعة في سطر واحد، مع تجاهل أي جزء فارغ
            // (الحقول الثلاثة تبقى منفصلة في النموذج/الشبكة — هذا التجميع للطباعة فقط).
            rec.PrintLocation = string.Join(" - ", new[] { rec.BuildingName, rec.FloorName, rec.Location }
                .Where(s => !string.IsNullOrWhiteSpace(s)));

            if (rec.PrjId != null)
            {
                var project = DC.ProjectsList.Find(rec.PrjId.Value);
                rec.PrintPrjName = project?.Name;

                var client = project?.CLId != null ? DC.StakeholdersList.Find(project.CLId.Value) : null;
                rec.PrintSponsorName = client?.Name;
                rec.PrintClientEmail = client?.Email;
                rec.PrintSponsorLogo = client?.Logo;

                var consultant = project?.CSTId != null ? DC.StakeholdersList.Find(project.CSTId.Value) : null;
                rec.PrintCSTName = consultant?.Name;
                rec.PrintConsultantEmail = consultant?.Email;
                rec.PrintCSTLogo = consultant?.Logo;
            }
            return rec;
        }

        public static void Print(int id, Control owner)
        {
            var rec = DC.ConstructionInspectionRequestList.Find(id);
            if (rec == null)
            {
                XtraMessageBox.Show("لم يتم العثور على طلب الفحص المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Print(rec, owner);
        }

        public static void Print(ConstructionInspectionRequestList rec, Control owner)
        {
            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(owner);
                var printRecord = BuildPrintRecord(rec);
                var rpt = new rptConstructionInspectionRequest
                {
                    DataSource = new List<ConstructionInspectionRequestList> { printRecord }
                };
                new ReportPrintTool(rpt).ShowPreviewDialog();
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show("خطأ أثناء الطباعة: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        /// <summary>Prints the "سجل طلبات الفحص الإنشائي" register report for the rows currently shown in
        /// ucCIR's grid (respecting whatever project/discipline filter is applied there) — one row per
        /// construction inspection request, grouped by discipline (GroupHeader1/xrGroupBanner) nested inside
        /// an outer project group (GroupHeaderProject/xrProjectGroupBanner) that only shows itself when the
        /// printed rows span more than one project — a single project's name is already shown once in the
        /// fixed page header, so repeating it as a group banner there would be redundant. Not a per-request
        /// detail print like <see cref="Print(int, Control)"/>.
        ///
        /// projectId, when a specific project (not "-- الكل --") is selected in ucCIR, resolves the
        /// project/owner/consultant header block (name + logo — same StakeholdersList.Logo source as
        /// BuildPrintRecord's PrintSponsorLogo/PrintCSTLogo). Left null, or when the printed rows span more
        /// than one project, that block shows "متعدد" (owner/consultant left blank — no single one applies).</summary>
        public static void PrintLog(List<ConstructionInspectionRequestList> records, int? projectId = null)
        {
            // مطلوب لتجميع الشبكة (المشروع ثم التخصص) — PrintPrjName/DisciplineName حقلان غير مخزَّنين
            // (NotMapped)، فيُحسَبان هنا مرة واحدة لكل سجل قبل الطباعة كما تفعل BuildPrintRecord للطباعة
            // الفردية. PrintLocation جملة مركّبة (المبنى - الطابق - موقع الفحص) تُعرَض في عمود "موقع
            // الفحص" بدل حقل Location وحده — نفس تجميع BuildPrintRecord.PrintLocation بالضبط.
            var disciplines = DC.DisciplinesList.GetBy("IsDelete = 0").ToDictionary(d => d.Id);
            var projects = DC.ProjectsList.GetBy("IsDelete = 0").ToDictionary(p => p.Id);
            var buildings = DC.BuildingsList.GetBy("IsDelete = 0").ToDictionary(b => b.Id);
            var floors = DC.FloorsList.GetBy("IsDelete = 0").ToDictionary(f => f.Id);
            foreach (var rec in records)
            {
                rec.DisciplineName = rec.DisciplineId is > 0 && disciplines.TryGetValue(rec.DisciplineId.Value, out var disc)
                    ? disc.Name : "بدون تخصص";
                rec.PrintPrjName = rec.PrjId is > 0 && projects.TryGetValue(rec.PrjId.Value, out var prj)
                    ? prj.Name : "بدون مشروع";

                rec.BuildingName = rec.BuildingId is > 0 && buildings.TryGetValue(rec.BuildingId.Value, out var bld) ? bld.Name : null;
                if (!string.IsNullOrWhiteSpace(rec.FloorIds))
                {
                    var floorNames = rec.FloorIds.Split(',')
                        .Select(s => int.TryParse(s.Trim(), out var id) && floors.TryGetValue(id, out var fl) ? fl.Name : null)
                        .Where(n => !string.IsNullOrEmpty(n));
                    rec.FloorName = string.Join("، ", floorNames);
                }

                rec.PrintLocation = string.Join(" - ", new[] { rec.BuildingName, rec.FloorName, rec.Location }
                    .Where(s => !string.IsNullOrWhiteSpace(s)));

                rec.PrintProcessingDays = ComputeProcessingDays(rec);
            }

            // ترتيب صريح يطابق مستويي التجميع (المشروع ثم التخصص): تجميع DevExpress يكسر مجموعة جديدة
            // كل مرة تتغيّر فيها قيمة حقل التجميع بين صفّين متتاليين فقط — فإن لم تكن البيانات مرتَّبة
            // فعلياً بنفس الترتيب، تتكرر نفس لافتة المجموعة (وبالتالي "أسطر تبدو مكررة") كل ما عاد
            // التخصص/المشروع للظهور بعد صف من نوع آخر بدل مجموعة واحدة متجاورة. ضمن كل مجموعة، الصفوف
            // مرتَّبة تنازلياً برقم الفحص ثم الإصدارة (الأحدث أولاً).
            var sorted = records
                .OrderBy(r => r.PrintPrjName)
                .ThenBy(r => r.DisciplineName)
                .ThenByDescending(r => r.Num)
                .ThenByDescending(r => r.Rev)
                .ToList();

            var rpt = new rptConstructionInspectionLog { DataSource = sorted };
            rpt.xrReportDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

            bool multipleProjects = sorted.Select(r => r.PrjId).Distinct().Count() > 1;
            rpt.GroupHeaderProject.Visible = multipleProjects;

            // "-- الكل --" (projectId null/0) مع أكثر من مشروع فعلياً في الصفوف المطبوعة: لا مشروع واحد
            // يمكن عرض بياناته في هذه الترويسة الثابتة (تظهر مرة واحدة أعلى كل صفحة) بأمان، فيُكتفى بـ
            // "متعدد" بدل عرض بيانات مشروع عشوائي واحد من بينها.
            int? resolvedProjectId = multipleProjects ? null
                : projectId is > 0 ? projectId : sorted.Count > 0 ? sorted[0].PrjId : null;

            var project = resolvedProjectId is > 0 ? DC.ProjectsList.Find(resolvedProjectId.Value) : null;
            rpt.xrProjectName.Text = multipleProjects ? "متعدد" : project?.Name ?? "";

            var client = project?.CLId != null ? DC.StakeholdersList.Find(project.CLId.Value) : null;
            rpt.xrClientName.Text = client?.Name ?? "";
            rpt.xrLogo1.Image = client?.Logo is { Length: > 0 } clientLogo ? Image.FromStream(new MemoryStream(clientLogo)) : null;

            var consultant = project?.CSTId != null ? DC.StakeholdersList.Find(project.CSTId.Value) : null;
            rpt.xrConsultantName.Text = consultant?.Name ?? "";
            rpt.xrLogo3.Image = consultant?.Logo is { Length: > 0 } cstLogo ? Image.FromStream(new MemoryStream(cstLogo)) : null;

            rpt.ShowPreviewDialog();
        }

        private static DateTime? ParseDate(string? s) => DateTime.TryParse(s, out var d) ? d : null;

        /// <summary>نفس صيغة ucCIR.ComputeProcessingDays بالضبط (مصدر واحد لتعريف "عدد أيام الإجراء" على
        /// الشاشة والمطبوعة): الفرق بين تاريخ التقديم وتاريخ مراجعة الاستشاري، أو بين تاريخ التقديم واليوم
        /// الحالي إن لم تتم المراجعة بعد — بلا تقديم لا توجد قيمة.</summary>
        private static int? ComputeProcessingDays(ConstructionInspectionRequestList rec)
        {
            var submitted = ParseDate(rec.SubmittedDate);
            if (submitted == null) return null;

            var end = ParseDate(rec.CSTReturnedDate) ?? DateTime.Today;
            return (end.Date - submitted.Value.Date).Days;
        }

        /// <summary>Also hydrates rec's PrintClientEmail/PrintConsultantEmail as a side effect
        /// (same object reference), so callers can read them right after for a "send by email" flow.</summary>
        public static byte[] ExportToPdf(ConstructionInspectionRequestList rec)
        {
            var printRecord = BuildPrintRecord(rec);
            var rpt = new rptConstructionInspectionRequest
            {
                DataSource = new List<ConstructionInspectionRequestList> { printRecord }
            };
            using var ms = new MemoryStream();
            rpt.ExportToPdf(ms);
            return ms.ToArray();
        }
    }
}
