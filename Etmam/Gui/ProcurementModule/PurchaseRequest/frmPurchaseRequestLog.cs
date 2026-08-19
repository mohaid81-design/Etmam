using System.Windows.Controls;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace Etmam
{
    public partial class frmPurchaseRequestLog : DevExpress.XtraEditors.XtraForm
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private string _formattedNum = "";
        private string _projectName = "";
        private string _purpose = "";

        public frmPurchaseRequestLog(int prId)
        {
            InitializeComponent();

            gridView1.OptionsBehavior.Editable = false;

            LoadData(prId);

            bbiPrint.ItemClick += (s, e) => PrintLog();
        }

        private void LoadData(int prId)
        {
            var pr = dc.PurchaseRequestList.Find(prId);
            _formattedNum = PurchaseRequestPrinter.FormatPRNumber(pr?.Num, pr?.RequestDate);
            _projectName = pr?.PrjId is > 0 ? (dc.ProjectsList.Find(pr.PrjId.Value)?.Name ?? "—") : "—";
            _purpose = pr?.Purpose ?? "—";

            var users = dc.UsersList.GetBy("IsDelete = 0").ToDictionary(u => u.Id);
            var steps = dc.WorkflowStepList.GetBy("IsDelete = 0").ToDictionary(s => s.Id);

            var rows = new List<LogRow>();

            // 1) إجراءات طلب الشراء نفسه
            AddWorkflowHistoryRows(rows, "طلب الشراء", "PurchaseRequestList", prId, users, steps);

            // 2) إجراءات كل أمر شراء صدر عن هذا الطلب + أذون الاستلام المرتبطة بكل أمر (لا يوجد لها
            // إجراء اعتماد رسمي — انظر MaterialReceiveList — فتُسجَّل من حقول التدقيق فقط: الإنشاء وآخر تعديل)
            var linkedPOs = dc.PurchaseOrderList.GetBy("PRId = @id AND IsDelete = 0", new { id = prId }).ToList();
            foreach (var po in linkedPOs)
            {
                var poLabel = $"أمر الشراء {PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate)}";
                AddWorkflowHistoryRows(rows, poLabel, "PurchaseOrderList", po.Id, users, steps);

                var receipts = dc.MaterialReceiveList.GetBy("POId = @id AND IsDelete = 0", new { id = po.Id }).ToList();
                foreach (var mr in receipts)
                {
                    var mrLabel = $"{poLabel} — إذن استلام رقم {MaterialReceivePrinter.FormatReceiveNumber(mr.Num, mr.ReceivedDate)}";

                    rows.Add(new LogRow
                    {
                        Source = mrLabel,
                        StepName = "—",
                        Action = "إنشاء إذن استلام",
                        ActionByName = users.TryGetValue(mr.CreatedBy, out var creator) ? (creator.FullName ?? creator.UserName ?? "—") : "—",
                        ActionDate = mr.CreatedDate,
                        Comment = ""
                    });

                    if (mr.UpdateDate.HasValue)
                    {
                        rows.Add(new LogRow
                        {
                            Source = mrLabel,
                            StepName = "—",
                            Action = "تعديل إذن استلام",
                            ActionByName = users.TryGetValue(mr.UpdateBy, out var updater) ? (updater.FullName ?? updater.UserName ?? "—") : "—",
                            ActionDate = mr.UpdateDate,
                            Comment = ""
                        });
                    }
                }
            }

            gridControl1.DataSource = rows.OrderBy(r => r.ActionDate ?? DateTime.MinValue).ToList();
        }

        /// <summary>Appends one "بدء الإجراء" row plus one row per WorkflowInstanceHistoryList entry, for
        /// every workflow instance ever run against (entityName, entityRecordId) — shared by the PR's own
        /// history and each linked Purchase Order's history, distinguished only by the "source" label.</summary>
        private void AddWorkflowHistoryRows(List<LogRow> rows, string source, string entityName, int entityRecordId,
            Dictionary<int, UsersList> users, Dictionary<int, WorkflowStepList> steps)
        {
            var instances = dc.WorkflowInstanceList
                .GetBy("EntityName = @n AND EntityRecordId = @id", new { n = entityName, id = entityRecordId })
                .OrderBy(i => i.Id)
                .ToList();

            foreach (var instance in instances)
            {
                rows.Add(new LogRow
                {
                    Source = source,
                    StepName = "بدء الإجراء",
                    Action = "—",
                    ActionByName = users.TryGetValue(instance.StartedBy, out var starter) ? (starter.FullName ?? starter.UserName ?? "—") : "—",
                    ActionDate = instance.StartedDate,
                    Comment = ""
                });

                var history = dc.WorkflowInstanceHistoryList
                    .GetBy("WorkflowInstanceId = @id", new { id = instance.Id })
                    .OrderBy(h => h.Id);

                // Post-snapshot history entries (see WorkflowEngine.StartWorkflow/Act) record
                // WorkflowStepId against this instance's own frozen WorkflowInstanceStepList row, not
                // the live WorkflowStepList — check that first, falling back to the live dictionary for
                // pre-snapshot entries.
                var snapshotSteps = dc.WorkflowInstanceStepList
                    .GetBy("WorkflowInstanceId = @id", new { id = instance.Id })
                    .ToDictionary(s => s.Id);

                foreach (var h in history)
                {
                    string stepName = snapshotSteps.TryGetValue(h.WorkflowStepId, out var snapStep) ? (snapStep.Name ?? "—")
                        : steps.TryGetValue(h.WorkflowStepId, out var step) ? (step.Name ?? "—")
                        : "—";

                    rows.Add(new LogRow
                    {
                        Source = source,
                        StepName = stepName,
                        Action = h.Action switch
                        {
                            "Approved" => "اعتماد",
                            "Rejected" => "رفض",
                            "ReturnedToStep" => "إعادة لخطوة سابقة",
                            _ => h.Action ?? "—"
                        },
                        ActionByName = users.TryGetValue(h.ActionBy, out var u) ? (u.FullName ?? u.UserName ?? "—") : "—",
                        ActionDate = h.ActionDate,
                        Comment = h.Comment ?? ""
                    });
                }
            }
        }
        private void PrintLog()
        {
            var link = new PrintableComponentLink(new PrintingSystem())
            {
                Component = gridControl1
            };
            link.PrintingSystem.Links.Clear();
            link.PrintingSystem.Links.Add(link);

            link.CreateReportHeaderArea += (s, e) =>
            {
                e.Graph.Font = new Font("Cairo", 12, FontStyle.Bold);
                e.Graph.StringFormat = new BrickStringFormat(DevExpress.Drawing.DXStringAlignment.Far, DevExpress.Drawing.DXStringAlignment.Near);
                e.Graph.DrawString("سجل إجراءات طلب الشراء", Color.Black,
                    new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 30), BorderSide.None);

                e.Graph.Font = new Font("Cairo", 9);
                e.Graph.DrawString(
                    $"رقم الطلب: {_formattedNum}      المشروع: {_projectName}      الغرض: {_purpose}",
                    Color.Black,
                    new RectangleF(0, 30, e.Graph.ClientPageSize.Width, 40), BorderSide.None);
            };

            link.ShowPreviewDialog();
        }

        private class LogRow
        {
            public string Source { get; set; } = "";
            public string StepName { get; set; } = "";
            public string Action { get; set; } = "";
            public string ActionByName { get; set; } = "";
            public DateTime? ActionDate { get; set; }
            public string Comment { get; set; } = "";
        }
    }
}
