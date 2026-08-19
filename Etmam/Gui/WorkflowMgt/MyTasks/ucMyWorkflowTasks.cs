using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class ucMyWorkflowTasks : DevExpress.XtraEditors.XtraUserControl
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private List<WorkflowTaskRow> _rows = new();

        public ucMyWorkflowTasks()
        {
            InitializeComponent();

            // الديزاينر يضع خط الشريط "Segoe UI" بينما شبكة البيانات "Cairo" — نفس الشاشة بخطين
            // مختلفين. DesignSystem.ApplyCairoFont/ApplyGridStyle حالياً بلا تأثير (المحتوى معطَّل)،
            // فالتوحيد هنا صراحةً بدل الاعتماد عليهما.
            bar2.BarAppearance.Normal.Font = DesignSystem.Fonts.Regular(9);
            bar2.BarAppearance.Hovered.Font = DesignSystem.Fonts.Regular(9);
            bar2.BarAppearance.Pressed.Font = DesignSystem.Fonts.Regular(9);
            bar2.BarAppearance.Disabled.Font = DesignSystem.Fonts.Regular(9);
            gridView1.Appearance.HeaderPanel.ForeColor = DesignSystem.Colors.Primary;
            gridView1.Appearance.Row.Font = DesignSystem.Fonts.Regular(9);

            // ملاحظة: Editable=false على مستوى الـ View بأكمله يمنع أي عمود ضمنه من دخول وضع التحرير —
            // بما في ذلك عمود الزر colOpen، فيتوقف عن العمل تماماً. لذا الـ View نفسه قابل للتحرير،
            // وكل عمود بيانات معطَّل تحريره فردياً عبر OptionsColumn.AllowEdit=false (في الـ Designer).
            gridView1.OptionsBehavior.Editable = true;
            btnApprove.ItemClick += (s, e) => Act("Approved");
            btnReject.ItemClick += (s, e) => Act("Rejected");
            btnRefresh.ItemClick += (s, e) => LoadData();

            // عمود colOpen → فتح الطلب للاطلاع واتخاذ الإجراء فقط، بلا إمكانية تعديل بياناته
            repositoryItemButtonEditOpen.ButtonClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is WorkflowTaskRow row)
                    OpenTaskForAction(row);
            };

            this.Load += (s, e) => LoadData();
        }
        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                int userId = Session.CurrentUser?.Id ?? 1;
                var pending = WorkflowEngine.GetPendingForUser(userId);

                // مهام اعتماد طلبات الشراء تُعرض فقط لمشاريع لدى المستخدم صلاحية عليها (PermissionService)
                var grantedProjectIds = PermissionService.GrantedProjectIds(dc);

                var prIds = pending.Where(i => i.EntityName == "PurchaseRequestList")
                    .Select(i => i.EntityRecordId)
                    .Distinct()
                    .ToList();
                var prRecords = prIds.Count > 0
                    ? dc.PurchaseRequestList.GetBy($"Id IN ({string.Join(",", prIds)})").ToDictionary(p => p.Id)
                    : new Dictionary<int, PurchaseRequestList>();

                var poIds = pending.Where(i => i.EntityName == "PurchaseOrderList")
                    .Select(i => i.EntityRecordId)
                    .Distinct()
                    .ToList();
                var poRecords = poIds.Count > 0
                    ? dc.PurchaseOrderList.GetBy($"Id IN ({string.Join(",", poIds)})").ToDictionary(p => p.Id)
                    : new Dictionary<int, PurchaseOrderList>();

                // ملاحظة: لا يوجد هنا فحص UserWorkflowAccess (PermissionService.CanAccessWorkflowDefinition) عمداً —
                // كونه معيَّناً كمعتمِد على الخطوة الحالية فعلياً (WorkflowStepAssigneeList، محدَّد أصلاً ضمن
                // WorkflowEngine.GetPendingForUser) هو التفويض الفعلي لرؤية المهمة والتصرف فيها. UserWorkflowAccess
                // تبويب منفصل في صلاحيات المستخدم يُنشأ افتراضياً "false" لكل مستخدم غير المدير عند إضافة أي
                // إجراء جديد (frmWorkflowDefinitionAddEdit.InitializeWorkflowAccessRows) ولا يتغيّر تلقائياً عند
                // تعيين المستخدم كمعتمِد خطوة — فاشتراطه هنا كان يُخفي مهام معتمَدة فعلياً عن أصحابها إن لم
                // يتذكّر المدير تفعيل هذا التبويب المنفصل لهم. يبقى مستخدَماً في مكانه الأصلي: فلترة صفوف
                // ucWorkflowDefinitions (من يرى تعريفات الإجراءات نفسها، لا مهامه المُسنَدة).
                pending = pending.Where(i =>
                {
                    if (i.EntityName == "PurchaseRequestList")
                        return prRecords.TryGetValue(i.EntityRecordId, out var pr) && pr.PrjId.HasValue && grantedProjectIds.Contains(pr.PrjId.Value);
                    if (i.EntityName == "PurchaseOrderList")
                        return poRecords.TryGetValue(i.EntityRecordId, out var po) && po.PrjId.HasValue && grantedProjectIds.Contains(po.PrjId.Value);
                    return true;
                }).ToList();

                var defs = dc.WorkflowDefinitionList.GetBy("IsDelete = 0").ToDictionary(d => d.Id);
                var users = dc.UsersList.GetBy("IsDelete = 0").ToDictionary(u => u.Id);

                // Step names are resolved snapshot-first (WorkflowInstanceStepList, frozen at Submit
                // time — see WorkflowEngine.StartWorkflow) so a step renamed/reordered later never
                // changes what's shown for an already-running approval; falls back to the live
                // WorkflowStepList only for a legacy instance with no snapshot rows at all.
                var pendingIds = pending.Select(i => i.Id).ToList();
                var snapshotSteps = pendingIds.Count > 0
                    ? dc.WorkflowInstanceStepList.GetBy($"WorkflowInstanceId IN ({string.Join(",", pendingIds)})")
                    : new List<WorkflowInstanceStepList>();
                var snapshotStepByInstanceAndOrder = snapshotSteps.ToDictionary(s => (s.WorkflowInstanceId, s.StepOrder));
                var liveSteps = dc.WorkflowStepList.GetBy("IsDelete = 0");

                _rows = pending.Select(i =>
                {
                    string? stepName = snapshotStepByInstanceAndOrder.TryGetValue((i.Id, i.CurrentStepOrder), out var snap)
                        ? snap.Name
                        : liveSteps.FirstOrDefault(s => s.WorkflowDefinitionId == i.WorkflowDefinitionId
                                                         && s.StepOrder == i.CurrentStepOrder)?.Name;

                    return new WorkflowTaskRow
                    {
                        InstanceId = i.Id,
                        EntityName = i.EntityName ?? "",
                        EntityRecordId = i.EntityRecordId,
                        ProcedureName = defs.TryGetValue(i.WorkflowDefinitionId, out var d) ? (d.Name ?? "—") : "—",
                        StepName = stepName ?? "—",
                        Reference = FormatReference(i.EntityName, i.EntityRecordId, prRecords, poRecords),
                        StartedByName = users.TryGetValue(i.StartedBy, out var u) ? (u.FullName ?? u.UserName ?? "—") : "—",
                        StartedDate = i.StartedDate
                    };
                }).ToList();

                gridControl1.DataSource = _rows;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل المهام:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }
        /// <summary>Builds the grid's "المرجع" text, e.g. "PR2600001 - طلب شراء مواد سباكة" for purchase
        /// requests (see PurchaseRequestPrinter.FormatPRNumber), or "PO2600001 - وصف أمر الشراء" for purchase
        /// orders (see PurchaseOrderNumberFormatter.FormatPONumber) — both formats carry the 2-digit year of
        /// the record's own date and reset their sequence every calendar year.</summary>
        private static string FormatReference(string? entityName, int entityRecordId,
            Dictionary<int, PurchaseRequestList> prRecords, Dictionary<int, PurchaseOrderList> poRecords)
        {
            if (entityName == "PurchaseRequestList" && prRecords.TryGetValue(entityRecordId, out var pr))
            {
                string number = PurchaseRequestPrinter.FormatPRNumber(pr.Num, pr.RequestDate);
                return string.IsNullOrWhiteSpace(pr.Purpose) ? number : $"{number} - {pr.Purpose}";
            }

            if (entityName == "PurchaseOrderList" && poRecords.TryGetValue(entityRecordId, out var po))
            {
                string number = PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate);
                return string.IsNullOrWhiteSpace(po.Description) ? number : $"{number} - {po.Description}";
            }

            return $"{entityName} #{entityRecordId}";
        }

        private void Act(string action)
        {
            if (gridView1.GetFocusedRow() is not WorkflowTaskRow row)
            {
                XtraMessageBox.Show("يرجى تحديد مهمة أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (row.EntityName == "PurchaseRequestList")
            {
                var pr = dc.PurchaseRequestList.Find(row.EntityRecordId);
                if (pr != null && SeparationOfDutiesHelper.BlocksSelfApproval(dc, pr.CreatedBy))
                {
                    XtraMessageBox.Show(SeparationOfDutiesHelper.SelfApprovalMessage, "غير مصرَّح",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (row.EntityName == "PurchaseOrderList")
            {
                var po = dc.PurchaseOrderList.Find(row.EntityRecordId);
                if (po != null && SeparationOfDutiesHelper.BlocksSelfApproval(dc, po.CreatedBy))
                {
                    XtraMessageBox.Show(SeparationOfDutiesHelper.SelfApprovalMessage, "غير مصرَّح",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string title = action == "Approved" ? "اعتماد" : "رفض";
            var comment = XtraInputBox.Show($"ملاحظة ({title}) - اختياري:", title, "");
            if (comment == null) return; // user cancelled

            var handle = ShowOverlay();
            try
            {
                WorkflowEngine.Act(row.InstanceId, Session.CurrentUser?.Id ?? 1, action, comment.ToString());
                XtraMessageBox.Show($"تم {title} بنجاح ✓", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        /// <summary>Opens the source record for viewing/action only (colOpen) — same read-only mode
        /// as the entity's own colAction button; no data editing is possible from here.</summary>
        private void OpenTaskForAction(WorkflowTaskRow row)
        {
            switch (row.EntityName)
            {
                case "PurchaseRequestList":
                {
                    // غير مقفلة (Show وليس ShowDialog) للسماح بالتنقل في باقي البرنامج أثناء فتحها؛
                    // الفحص هنا يحمي من تحديث قائمة تم إغلاق تابها بالفعل قبل إغلاق شاشة الطلب.
                    var handle = ShowOverlay();
                    frmPurchaseRequestAddEdit frm;
                    try
                    {
                        frm = new frmPurchaseRequestAddEdit();
                        frm.OpenForAction(row.EntityRecordId);
                    }
                    finally { CloseOverlay(handle); }
                    frm.FormClosed += (s, e) => { if (!IsDisposed) LoadData(); };
                    frm.Show(this.FindForm());
                    break;
                }

                case "PurchaseOrderList":
                {
                    // لا حاجة لوضع "قراءة فقط" منفصل هنا كما في PurchaseRequestList: أمر الشراء يقفل
                    // رأسه وشبكة بنوده تلقائياً بمجرد مغادرة حالة "مسودة" (UpdateActionButtonStates في
                    // frmPurchaseOrderAddEdit) — وأي مهمة تظهر هنا هي بالتعريف "قيد الاعتماد" بالفعل.
                    var handle = ShowOverlay();
                    frmPurchaseOrderAddEdit poFrm;
                    try { poFrm = new frmPurchaseOrderAddEdit(row.EntityRecordId); }
                    finally { CloseOverlay(handle); }
                    poFrm.FormClosed += (s, e) => { if (!IsDisposed) LoadData(); };
                    poFrm.Show(this.FindForm());
                    break;
                }

                default:
                    XtraMessageBox.Show("عرض هذا النوع من الطلبات غير مدعوم بعد.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        private class WorkflowTaskRow
        {
            public int InstanceId { get; set; }
            public string EntityName { get; set; } = "";
            public int EntityRecordId { get; set; }
            public string ProcedureName { get; set; } = "";
            public string StepName { get; set; } = "";
            public string Reference { get; set; } = "";
            public string StartedByName { get; set; } = "";
            public DateTime? StartedDate { get; set; }
        }
    }
}
