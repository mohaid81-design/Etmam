using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Core;
using DevExpress.XtraReports.UI;

namespace Etmam
{
    public partial class rptDailyReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDailyReport()
        {
            InitializeComponent();
            EnsureSubreportSources();
            this.BeforePrint += RptDailyReport_BeforePrint;
            this.BeforePrint += (s, e) => ApplyRuntimeFormatting();
        }

        private void EnsureSubreportSources()
        {
            xrSubreportStaff.ReportSource ??= new rptDailyReportStaff();
            xrSubreportLabor.ReportSource ??= new rptDailyReportLabor();
            xrSubreportEquipment.ReportSource ??= new rptDailyReportEquipment();
            xrSubreportMaterial.ReportSource ??= new rptDailyReportMaterial();
            xrSubreportInspection.ReportSource ??= new rptDailyReportInspection();
            xrSubreportIssue.ReportSource ??= new rptDailyReportIssue();
            xrSubreportDisruptedActivity.ReportSource ??= new rptDailyReportDisruptedActivity();

            xrSubreportWorkDone.ReportSource ??= new rptDailyReportWorkDoneStr();
            xrSubreport1.ReportSource ??= new rptDailyReportWorkDoneArc();
            xrSubrptDailyReport.ReportSource ??= new rptDailyReportWorkDoneMec();
            xrSubreport3.ReportSource ??= new rptDailyReportWorkDoneElc();
            xrSubreport4.ReportSource ??= new rptDailyReportWorkDoneOth();

            xrSubreport10.ReportSource ??= new rptDailyReportWorkPlanned();
        }

        private void RptDailyReport_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var report = this.DataSource as DailyReport;
            if (report == null)
            {
                var list = this.DataSource as IEnumerable;
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        report = item as DailyReport;
                        break;
                    }
                }
            }

            if (report == null) return;

            var manpowers = report.Manpowers ?? new List<DailyReportManpower>();
            var workDone = report.WorkDones ?? new List<DailyReportWorkDone>();
            var planned = report.WorkPlanneds ?? new List<DailyReportWorkPlanned>();

            if (xrSubreportStaff.ReportSource != null)
                xrSubreportStaff.ReportSource.DataSource = manpowers
                    .Where(x => x.Manpower?.Category == "Staff" || x.Manpower?.Category == "موظفين" || x.Manpower?.Category == "الطاقم الفني")
                    .ToList();

            if (xrSubreportLabor.ReportSource != null)
                xrSubreportLabor.ReportSource.DataSource = manpowers
                    .Where(x => x.Manpower?.Category == "Labor" || x.Manpower?.Category == "عمال" || x.Manpower?.Category == "العمالة")
                    .ToList();

            if (xrSubreportEquipment.ReportSource != null) xrSubreportEquipment.ReportSource.DataSource = report.Equipments ?? new List<DailyReportEquipment>();
            if (xrSubreportMaterial.ReportSource != null) xrSubreportMaterial.ReportSource.DataSource = report.Materials ?? new List<DailyReportMaterial>();
            if (xrSubreportInspection.ReportSource != null) xrSubreportInspection.ReportSource.DataSource = report.Inspections ?? new List<DailyReportInspection>();
            if (xrSubreportIssue.ReportSource != null) xrSubreportIssue.ReportSource.DataSource = report.Issues ?? new List<DailyReportIssue>();
            if (xrSubreportDisruptedActivity.ReportSource != null) xrSubreportDisruptedActivity.ReportSource.DataSource = report.DisruptedActivities ?? new List<DailyReportDisruptedActivity>();

            if (xrSubreportWorkDone.ReportSource != null) xrSubreportWorkDone.ReportSource.DataSource = workDone.Where(x => x.Activity?.Category == "إنشائي").ToList();
            if (xrSubreport1.ReportSource != null) xrSubreport1.ReportSource.DataSource = workDone.Where(x => x.Activity?.Category == "معماري").ToList();
            if (xrSubrptDailyReport.ReportSource != null) xrSubrptDailyReport.ReportSource.DataSource = workDone.Where(x => x.Activity?.Category == "ميكانيكا").ToList();
            if (xrSubreport3.ReportSource != null) xrSubreport3.ReportSource.DataSource = workDone.Where(x => x.Activity?.Category == "كهرباء").ToList();
            if (xrSubreport4.ReportSource != null) xrSubreport4.ReportSource.DataSource = workDone.Where(x => string.IsNullOrEmpty(x.Activity?.Category) || x.Activity?.Category == "أخرى").ToList();

            if (xrSubreport10.ReportSource != null)
                xrSubreport10.ReportSource.DataSource = planned;
        }

        private void ApplyRuntimeFormatting()
        {
            ApplyFormattingRecursive(this.Bands);
        }

        private void ApplyFormattingRecursive(BandCollection bands)
        {
            foreach (Band band in bands)
            {
                foreach (XRControl control in band.Controls)
                {
                    ApplyControlStyle(control);
                    ApplyFormattingRecursive(control.Controls);
                }
            }
        }

        private void ApplyFormattingRecursive(XRControlCollection controls)
        {
            foreach (XRControl control in controls)
            {
                ApplyControlStyle(control);
                ApplyFormattingRecursive(control.Controls);
            }
        }

        private static void ApplyControlStyle(XRControl control)
        {
            if (control is XRLabel label && label.Name.StartsWith("xrLabel"))
            {
                label.Font = new DevExpress.Drawing.DXFont("Cairo", 9F, DevExpress.Drawing.DXFontStyle.Bold);
                label.Borders = DevExpress.XtraPrinting.BorderSide.All;
                label.BorderWidth = 0.5F;
            }

            if (control is XRTable table && table.Name.StartsWith("xrTable"))
            {
                table.BorderWidth = 0.5F;
            }
        }
    }
}
