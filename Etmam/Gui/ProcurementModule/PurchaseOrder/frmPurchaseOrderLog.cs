using Core;
using Data;
using DevExpress.XtraPrinting;

namespace Etmam
{
    /// <summary>Mirrors frmPurchaseRequestLog's structure/conventions exactly, for Purchase Orders: a
    /// structured, printable grid of every workflow step across this PO and (in the reverse direction of
    /// PR's linked-POs loop) its own originating Purchase Request, plus its linked material receipts.</summary>
    public partial class frmPurchaseOrderLog : DevExpress.XtraEditors.XtraForm
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private string _formattedNum = "";
        private string _projectName = "";
        private string _description = "";

        public frmPurchaseOrderLog(int poId)
        {
            InitializeComponent();

            gridView1.OptionsBehavior.Editable = false;

            LoadData(poId);

            bbiPrint.ItemClick += (s, e) => PrintLog();
        }

        private void LoadData(int poId)
        {
            var po = dc.PurchaseOrderList.Find(poId);
            _formattedNum = PurchaseOrderNumberFormatter.FormatPONumber(po?.Num, po?.OrderDate);
            _projectName = po?.PrjId is > 0 ? (dc.ProjectsList.Find(po.PrjId.Value)?.Name ?? "—") : "—";
            _description = po?.Description ?? "—";

            var users = dc.UsersList.GetBy("IsDelete = 0").ToDictionary(u => u.Id);
            var steps = dc.WorkflowStepList.GetBy("IsDelete = 0").ToDictionary(s => s.Id);

            var rows = new List<LogRow>();

            // 1) إجراءات أمر الشراء نفسه
            AddWorkflowHistoryRows(rows, "أمر الشراء", "PurchaseOrderList", poId, users, steps);

            // 2) إجراءات طلب الشراء المصدر لهذا الأمر إن وُجد — عكس اتجاه حلقة linkedPOs في
            // frmPurchaseRequestLog (هناك: طلب → كل أوامره؛ هنا: أمر → طلبه المصدر فقط)
            if (po?.PRId is > 0)
            {
                var sourcePr = dc.PurchaseRequestList.Find(po.PRId.Value);
                if (sourcePr != null)
                {
                    var prLabel = $"طلب الشراء المصدر {PurchaseRequestPrinter.FormatPRNumber(sourcePr.Num, sourcePr.RequestDate)}";
                    AddWorkflowHistoryRows(rows, prLabel, "PurchaseRequestList", sourcePr.Id, users, steps);
                }
            }

            // 3) أذون الاستلام المرتبطة بهذا الأمر — لا يوجد لها إجراء اعتماد رسمي (انظر
            // MaterialReceiveList) فتُسجَّل من حقول التدقيق فقط: الإنشاء وآخر تعديل، نفس أسلوب
            // frmPurchaseRequestLog لكل أمر شراء مرتبط.
            var receipts = dc.MaterialReceiveList.GetBy("POId = @id AND IsDelete = 0", new { id = poId }).ToList();
            foreach (var mr in receipts)
            {
                var mrLabel = $"إذن استلام رقم {MaterialReceivePrinter.FormatReceiveNumber(mr.Num, mr.ReceivedDate)}";

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

            gridControl1.DataSource = rows.OrderBy(r => r.ActionDate ?? DateTime.MinValue).ToList();
        }

        /// <summary>Appends one "بدء الإجراء" row plus one row per WorkflowInstanceHistoryList entry, for
        /// every workflow instance ever run against (entityName, entityRecordId) — identical to
        /// frmPurchaseRequestLog's helper of the same name/shape.</summary>
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
                e.Graph.DrawString("سجل إجراءات أمر الشراء", Color.Black,
                    new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 30), BorderSide.None);

                e.Graph.Font = new Font("Cairo", 9);
                e.Graph.DrawString(
                    $"رقم الأمر: {_formattedNum}      المشروع: {_projectName}      الوصف: {_description}",
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
