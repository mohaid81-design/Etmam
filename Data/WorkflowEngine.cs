using Core;

namespace Data
{
    /// <summary>
    /// Generic workflow/approval engine: starts an instance of a WorkflowDefinitionList against
    /// any business record, and advances it step by step as assigned users approve or reject.
    /// Any future module (material request, etc.) drives its approval flow entirely through
    /// this class instead of hand-rolling its own status field.
    ///
    /// Step resolution is snapshot-first (see Core.WorkflowInstanceStepList/WorkflowInstanceStepAssigneeList
    /// and StartWorkflow below): once an instance starts, it always resolves its own steps/assignees from
    /// its own frozen copy, never from the live WorkflowStepList/WorkflowStepAssigneeList — so an admin
    /// editing a procedure's steps later can never retroactively change how an already-running approval
    /// behaves (per the methodology doc's Workflow Snapshot requirement). Instances started before this
    /// snapshot mechanism existed have no snapshot rows; every resolution method below falls back to the
    /// old live-lookup behavior for exactly those instances, so nothing already in progress breaks.
    /// </summary>
    public static class WorkflowEngine
    {
        private static DataContext DC => DataContext.Shared;

        /// <summary>A step, resolved from either the instance's own frozen snapshot or (for a legacy
        /// instance with no snapshot) the live WorkflowStepList — Id always means "the row whose Id
        /// WorkflowInstanceHistoryList.WorkflowStepId/the assignee tables key off of", scoped correctly
        /// for whichever source it came from.</summary>
        private readonly record struct ResolvedStep(int Id, int StepOrder, string? Name, bool IsSnapshot);

        public static int StartWorkflow(int workflowDefinitionId, string entityName, int entityRecordId, int startedByUserId)
        {
            var liveSteps = DC.WorkflowStepList
                .GetBy("WorkflowDefinitionId = @id", new { id = workflowDefinitionId })
                .OrderBy(s => s.StepOrder)
                .ToList();

            var firstStep = liveSteps.FirstOrDefault();
            if (firstStep == null)
                throw new InvalidOperationException("لا يمكن بدء الإجراء: لا توجد خطوات معرّفة له.");

            var instance = new WorkflowInstanceList
            {
                WorkflowDefinitionId = workflowDefinitionId,
                EntityName = entityName,
                EntityRecordId = entityRecordId,
                CurrentStepOrder = firstStep.StepOrder,
                Status = "InProgress",
                StartedBy = startedByUserId,
                StartedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                CreatedBy = startedByUserId,
                CreatedMachine = Session.Machine
            };

            int instanceId = 0;
            DataContext.RunInTransaction(tx =>
            {
                instanceId = DC.WorkflowInstanceList.Add(instance, tx);

                // Snapshot every step of the procedure as it stands right now, plus each step's current
                // assignees — this instance will only ever consult these frozen copies from here on.
                var stepIdRemap = new Dictionary<int, int>(); // live WorkflowStepList.Id -> new snapshot Id
                foreach (var liveStep in liveSteps)
                {
                    var snapshotStep = new WorkflowInstanceStepList
                    {
                        WorkflowInstanceId = instanceId,
                        StepOrder = liveStep.StepOrder,
                        Name = liveStep.Name,
                        Description = liveStep.Description,
                        CreatedDate = DateTime.Now,
                        CreatedBy = startedByUserId,
                        CreatedMachine = Session.Machine,
                        IsDelete = false
                    };
                    int snapshotStepId = DC.WorkflowInstanceStepList.Add(snapshotStep, tx);
                    stepIdRemap[liveStep.Id] = snapshotStepId;

                    var assignees = DC.WorkflowStepAssigneeList.GetBy("WorkflowStepId = @id", new { id = liveStep.Id });
                    var snapshotAssignees = assignees.Select(a => new WorkflowInstanceStepAssigneeList
                    {
                        WorkflowInstanceStepId = snapshotStepId,
                        UserId = a.UserId,
                        CreatedDate = DateTime.Now,
                        CreatedBy = startedByUserId,
                        CreatedMachine = Session.Machine,
                        IsDelete = false
                    }).ToList();

                    if (snapshotAssignees.Count > 0)
                        DC.WorkflowInstanceStepAssigneeList.AddRange(snapshotAssignees, tx);
                }
            });

            instance.Id = instanceId;
            var firstResolvedStep = GetCurrentStep(instance);
            if (firstResolvedStep != null)
                SendStartNotifications(instance, firstResolvedStep.Value);

            return instanceId;
        }

        /// <summary>Notifies (via WhatsApp) the first step's assignee(s) that a new approval task awaits
        /// them, the moment the instance is started. Mirrors SendTransitionNotifications'/
        /// SendReturnNotifications' next-owner half, just for the very first step instead of a step
        /// reached via Act/ReturnToStep. Fire-and-forget: send failures never affect the start above,
        /// which has already been persisted.</summary>
        private static void SendStartNotifications(WorkflowInstanceList instance, ResolvedStep firstStep)
        {
            var definition = DC.WorkflowDefinitionList.Find(instance.WorkflowDefinitionId);
            string defName = definition?.Name ?? "إجراء";

            var (number, subject) = WorkflowEntityDescriptors.Describe(DC, instance.EntityName, instance.EntityRecordId);
            string subjectPart = string.IsNullOrWhiteSpace(subject) ? "" : $" عبارة عن {subject}";

            foreach (var userId in GetAssigneeUserIds(firstStep))
            {
                var user = DC.UsersList.Find(userId);
                if (user != null)
                    WhatsAppNotifier.SendAsync(user.PhoneNumber,
                        $"لديك مهمة اعتماد {defName} رقم {number}{subjectPart}.");
            }
        }

        public static bool CanUserAct(int instanceId, int userId)
        {
            var instance = DC.WorkflowInstanceList.Find(instanceId);
            if (instance == null || instance.Status != "InProgress") return false;

            var currentStep = GetCurrentStep(instance);
            if (currentStep == null) return false;

            return HasAssignee(currentStep.Value, userId);
        }

        public static void Act(int instanceId, int userId, string action, string? comment)
        {
            var instance = DC.WorkflowInstanceList.Find(instanceId)
                ?? throw new InvalidOperationException("لم يتم العثور على إجراء بهذا الرقم.");

            if (instance.Status != "InProgress")
                throw new InvalidOperationException("هذا الإجراء منتهٍ بالفعل.");

            var currentStep = GetCurrentStep(instance)
                ?? throw new InvalidOperationException("تعذّر تحديد الخطوة الحالية للإجراء.");

            if (!HasAssignee(currentStep, userId))
                throw new InvalidOperationException("ليس لديك صلاحية التصرف في هذه الخطوة.");

            DC.WorkflowInstanceHistoryList.Add(new WorkflowInstanceHistoryList
            {
                WorkflowInstanceId = instanceId,
                WorkflowStepId = currentStep.Id,
                ActionBy = userId,
                Action = action,
                ActionDate = DateTime.Now,
                Comment = comment,
                CreatedDate = DateTime.Now,
                CreatedBy = userId,
                CreatedMachine = Session.Machine
            });

            ResolvedStep? nextStep = null;

            if (action == "Rejected")
            {
                instance.Status = "Rejected";
                instance.CompletedDate = DateTime.Now;
            }
            else if (action == "Approved")
            {
                nextStep = GetNextStep(instance, currentStep);

                if (nextStep != null)
                {
                    instance.CurrentStepOrder = nextStep.Value.StepOrder;
                }
                else
                {
                    instance.Status = "Approved";
                    instance.CompletedDate = DateTime.Now;
                }
            }

            instance.UpdateDate = DateTime.Now;
            instance.UpdateBy = userId;
            instance.UpdateMachine = Session.Machine;
            DC.WorkflowInstanceList.Edit(instanceId, instance);

            SendTransitionNotifications(instance, currentStep, nextStep, action, comment);
        }

        /// <summary>Notifies (via WhatsApp, see WhatsAppNotifier) about this transition, then — if the
        /// instance advanced to a new step — that step's assignee(s) that a new task awaits them.
        /// A confirmation is only sent when this was a terminal action (nextStep == null — either the
        /// final step got Approved, or a Rejected at any step, both of which end the instance): every user
        /// who was ever assigned to any *prior* step across this instance's whole path gets confirmed —
        /// everyone who touched the request deserves to know it's finished, and a rejection's message
        /// includes the rejection reason (comment) so they know why. Falls back to the instance's own
        /// StartedBy (the original requester) for a one-step procedure with no prior steps. An
        /// intermediate step being approved (nextStep != null) sends no confirmation at all — only the
        /// next step's "you have a task" notification below.
        /// Both messages name the procedure and the record's own display number (e.g. the Purchase
        /// Request number), resolved via WorkflowEntityDescriptors so this stays entity-agnostic instead
        /// of the engine hardcoding per-module table lookups. Fire-and-forget: send failures never affect
        /// the transition above, which has already been persisted.</summary>
        private static void SendTransitionNotifications(WorkflowInstanceList instance,
            ResolvedStep currentStep, ResolvedStep? nextStep, string action, string? comment)
        {
            var definition = DC.WorkflowDefinitionList.Find(instance.WorkflowDefinitionId);
            string defName = definition?.Name ?? "إجراء";
            string actionVerb = action switch { "Approved" => "اعتماد", "Rejected" => "رفض", _ => action };

            var (number, subject) = WorkflowEntityDescriptors.Describe(DC, instance.EntityName, instance.EntityRecordId);

            // نهائي (لا خطوة تالية — إما اعتماد الخطوة الأخيرة أو رفض في أي خطوة): تأكيد لكل مُكلَّفي
            // الخطوات السابقة. خطوة وسيطة (nextStep != null، اعتماد دائماً — الرفض ينهي الإجراء فوراً):
            // لا تأكيد إطلاقاً هنا؛ إشعار "لديك مهمة اعتماد" أدناه لمُكلَّفي الخطوة التالية يكفي.
            if (nextStep == null)
            {
                string reasonPart = action == "Rejected" && !string.IsNullOrWhiteSpace(comment)
                    ? $" السبب: {comment}"
                    : "";
                string message = $"تم {actionVerb} {defName} رقم {number}.{reasonPart}";

                foreach (var userId in GetAllPreviousStepsAssigneeUserIds(instance, currentStep))
                {
                    var user = DC.UsersList.Find(userId);
                    if (user != null)
                        WhatsAppNotifier.SendAsync(user.PhoneNumber, message);
                }
            }

            if (nextStep != null)
            {
                string subjectPart = string.IsNullOrWhiteSpace(subject) ? "" : $" عبارة عن {subject}";
                foreach (var userId in GetAssigneeUserIds(nextStep.Value))
                {
                    var user = DC.UsersList.Find(userId);
                    if (user != null)
                        WhatsAppNotifier.SendAsync(user.PhoneNumber,
                            $"لديك مهمة اعتماد {defName} رقم {number}{subjectPart}.");
                }
            }
            else if (action == "Approved")
            {
                // اكتمل الإجراء بالكامل (لا خطوة تالية) — أتِح لهذا النوع من السجلات إشعار إضافي خاص به
                // (مثلاً: تنبيه كل من يملك صلاحية أوامر الشراء بأن طلب شراء بحاجة لإجراء) دون أن يعرف
                // المحرك العام أي شيء عن طلبات الشراء تحديداً — انظر WorkflowEntityDescriptors.
                WorkflowEntityDescriptors.NotifyFullyApproved(DC, instance.EntityName, instance.EntityRecordId);
            }
        }

        /// <summary>
        /// Sends a workflow instance back to an earlier (or the same, in the terminal-Approved case)
        /// step — covers two distinct real-world scenarios:
        /// 1) The instance is still InProgress: the CURRENT step's assignee sends it back to a prior
        ///    step instead of approving it forward (e.g. they spot a mistake only the requester or an
        ///    earlier approver can fix). requireCurrentStepAssignee stays true here — same population
        ///    as who could Approve/Reject the current step.
        /// 2) The instance already finished as Approved: there's no "current step owner" left to check
        ///    (CanUserAct always returns false once Status != InProgress), so the caller must have
        ///    already authorized this some other way (e.g. a module-level permission for reopening a
        ///    completed instance) and pass requireCurrentStepAssignee: false.
        /// Rejected instances are out of scope — modules already have their own "return to draft" flow
        /// for those (see PurchaseRequestStatus.Draft / bbiReturnForEdit), which doesn't touch the
        /// workflow engine at all since a rejected instance has nothing left to resume.
        /// </summary>
        public static void ReturnToStep(int instanceId, int userId, int targetStepOrder, string comment, bool requireCurrentStepAssignee = true)
        {
            var instance = DC.WorkflowInstanceList.Find(instanceId)
                ?? throw new InvalidOperationException("لم يتم العثور على إجراء بهذا الرقم.");

            if (instance.Status != "InProgress" && instance.Status != "Approved")
                throw new InvalidOperationException("لا يمكن إعادة إجراء مرفوض أو غير معروف الحالة إلى خطوة سابقة.");

            var currentStep = GetCurrentStep(instance)
                ?? throw new InvalidOperationException("تعذّر تحديد الخطوة الحالية للإجراء.");

            if (requireCurrentStepAssignee && !HasAssignee(currentStep, userId))
                throw new InvalidOperationException("ليس لديك صلاحية التصرف في هذه الخطوة.");

            var targetStep = GetStepByOrder(instance, targetStepOrder, currentStep.IsSnapshot)
                ?? throw new InvalidOperationException("الخطوة المطلوبة غير موجودة ضمن هذا الإجراء.");

            if (targetStep.StepOrder > currentStep.StepOrder)
                throw new InvalidOperationException("لا يمكن الإعادة إلى خطوة لاحقة — الإعادة تكون لخطوة سابقة أو الحالية فقط.");

            if (string.IsNullOrWhiteSpace(comment))
                throw new InvalidOperationException("يرجى كتابة سبب الإعادة.");

            DC.WorkflowInstanceHistoryList.Add(new WorkflowInstanceHistoryList
            {
                WorkflowInstanceId = instanceId,
                WorkflowStepId = currentStep.Id,
                ActionBy = userId,
                Action = "ReturnedToStep",
                ActionDate = DateTime.Now,
                Comment = $"أُعيد إلى خطوة \"{targetStep.Name}\": {comment}",
                TargetStepOrder = targetStep.StepOrder,
                CreatedDate = DateTime.Now,
                CreatedBy = userId,
                CreatedMachine = Session.Machine
            });

            // يعود الإجراء "جارياً" دائماً بعد الإعادة، حتى لو كان قد انتهى فعلاً بالاعتماد الكامل —
            // فالإعادة تعني إعادة فتحه من جديد بدءاً من الخطوة المستهدفة.
            instance.Status = "InProgress";
            instance.CurrentStepOrder = targetStep.StepOrder;
            instance.CompletedDate = null;
            instance.UpdateDate = DateTime.Now;
            instance.UpdateBy = userId;
            instance.UpdateMachine = Session.Machine;
            DC.WorkflowInstanceList.Edit(instanceId, instance);

            SendReturnNotifications(instance, currentStep, targetStep, userId, comment);
        }

        /// <summary>Notifies (via WhatsApp) every user who was ever assigned to any step before
        /// currentStep (same broadcast pool as SendTransitionNotifications' terminal case — everyone who
        /// touched the request deserves to know it's being sent back) with who returned it, why, and to
        /// which step — then the target step's assignee(s) separately that it's now waiting on them again
        /// to redo their approval. Fire-and-forget: send failures never affect the return above, which
        /// has already been persisted.</summary>
        private static void SendReturnNotifications(WorkflowInstanceList instance,
            ResolvedStep currentStep, ResolvedStep targetStep, int actingUserId, string comment)
        {
            var definition = DC.WorkflowDefinitionList.Find(instance.WorkflowDefinitionId);
            string defName = definition?.Name ?? "إجراء";

            var (number, subject) = WorkflowEntityDescriptors.Describe(DC, instance.EntityName, instance.EntityRecordId);
            string subjectPart = string.IsNullOrWhiteSpace(subject) ? "" : $" عبارة عن {subject}";

            string actorName = DC.UsersList.Find(actingUserId)?.FullName ?? "مستخدم";
            string message = $"تم إرجاع {defName} رقم {number} من قبل {actorName} إلى خطوة \"{targetStep.Name}\". السبب: {comment}";

            foreach (var userId in GetAllPreviousStepsAssigneeUserIds(instance, currentStep))
            {
                var user = DC.UsersList.Find(userId);
                if (user != null)
                    WhatsAppNotifier.SendAsync(user.PhoneNumber, message);
            }

            foreach (var userId in GetAssigneeUserIds(targetStep))
            {
                var user = DC.UsersList.Find(userId);
                if (user != null)
                    WhatsAppNotifier.SendAsync(user.PhoneNumber,
                        $"أُعيد إليك {defName} رقم {number}{subjectPart} لإعادة الاعتماد.");
            }
        }

        /// <summary>Every InProgress instance whose CURRENT step this user may act on — resolved
        /// snapshot-first per instance, live-fallback for any instance with no snapshot rows (started
        /// before snapshotting existed). Batched into a handful of round trips rather than per-instance
        /// queries, since a user's own pending list is usually small but instance counts across the
        /// whole system can grow.</summary>
        public static List<WorkflowInstanceList> GetPendingForUser(int userId)
        {
            var inProgress = DC.WorkflowInstanceList.GetBy("Status = 'InProgress'");
            if (inProgress.Count == 0) return new List<WorkflowInstanceList>();

            var instanceIds = inProgress.Select(i => i.Id).ToList();
            var idsCsv = string.Join(",", instanceIds);

            var snapshotSteps = DC.WorkflowInstanceStepList.GetBy($"WorkflowInstanceId IN ({idsCsv})");
            var snapshotStepByInstanceAndOrder = snapshotSteps.ToDictionary(s => (s.WorkflowInstanceId, s.StepOrder));
            var snapshottedInstanceIds = snapshotSteps.Select(s => s.WorkflowInstanceId).ToHashSet();

            var snapshotStepIds = snapshotSteps.Select(s => s.Id).ToList();
            var userAssignedSnapshotStepIds = snapshotStepIds.Count > 0
                ? DC.WorkflowInstanceStepAssigneeList
                    .GetBy($"UserId = @userId AND WorkflowInstanceStepId IN ({string.Join(",", snapshotStepIds)})", new { userId })
                    .Select(a => a.WorkflowInstanceStepId)
                    .ToHashSet()
                : new HashSet<int>();

            // Legacy instances (no snapshot rows at all) — resolve live exactly as before StartWorkflow
            // began snapshotting.
            var legacyStepIdsForUser = DC.WorkflowStepAssigneeList
                .GetBy("UserId = @userId", new { userId })
                .Select(a => a.WorkflowStepId)
                .ToHashSet();
            var legacySteps = legacyStepIdsForUser.Count > 0
                ? DC.WorkflowStepList.GetBy("Id IN (" + string.Join(",", legacyStepIdsForUser) + ")").ToList()
                : new List<WorkflowStepList>();

            var result = new List<WorkflowInstanceList>();
            foreach (var instance in inProgress)
            {
                if (snapshottedInstanceIds.Contains(instance.Id))
                {
                    if (snapshotStepByInstanceAndOrder.TryGetValue((instance.Id, instance.CurrentStepOrder), out var step)
                        && userAssignedSnapshotStepIds.Contains(step.Id))
                        result.Add(instance);
                }
                else if (legacySteps.Any(s => s.WorkflowDefinitionId == instance.WorkflowDefinitionId && s.StepOrder == instance.CurrentStepOrder))
                {
                    result.Add(instance);
                }
            }
            return result;
        }

        private static ResolvedStep? GetCurrentStep(WorkflowInstanceList instance)
        {
            var snapshot = DC.WorkflowInstanceStepList
                .GetBy("WorkflowInstanceId = @id AND StepOrder = @order AND IsDelete = 0",
                    new { id = instance.Id, order = instance.CurrentStepOrder })
                .FirstOrDefault();
            if (snapshot != null) return new ResolvedStep(snapshot.Id, snapshot.StepOrder, snapshot.Name, true);

            // Legacy instance with no snapshot rows — resolve live exactly as WorkflowEngine always did
            // before StartWorkflow began snapshotting, so it keeps working unchanged.
            var live = DC.WorkflowStepList
                .GetBy("WorkflowDefinitionId = @id AND StepOrder = @order",
                    new { id = instance.WorkflowDefinitionId, order = instance.CurrentStepOrder })
                .FirstOrDefault();
            return live != null ? new ResolvedStep(live.Id, live.StepOrder, live.Name, false) : null;
        }

        private static ResolvedStep? GetStepByOrder(WorkflowInstanceList instance, int stepOrder, bool isSnapshot)
        {
            if (isSnapshot)
            {
                var snapshot = DC.WorkflowInstanceStepList
                    .GetBy("WorkflowInstanceId = @id AND StepOrder = @order AND IsDelete = 0",
                        new { id = instance.Id, order = stepOrder })
                    .FirstOrDefault();
                return snapshot != null ? new ResolvedStep(snapshot.Id, snapshot.StepOrder, snapshot.Name, true) : null;
            }

            var live = DC.WorkflowStepList
                .GetBy("WorkflowDefinitionId = @id AND StepOrder = @order",
                    new { id = instance.WorkflowDefinitionId, order = stepOrder })
                .FirstOrDefault();
            return live != null ? new ResolvedStep(live.Id, live.StepOrder, live.Name, false) : null;
        }

        private static ResolvedStep? GetNextStep(WorkflowInstanceList instance, ResolvedStep current)
        {
            if (current.IsSnapshot)
            {
                var next = DC.WorkflowInstanceStepList
                    .GetBy("WorkflowInstanceId = @id AND StepOrder > @order AND IsDelete = 0",
                        new { id = instance.Id, order = current.StepOrder })
                    .OrderBy(s => s.StepOrder)
                    .FirstOrDefault();
                return next != null ? new ResolvedStep(next.Id, next.StepOrder, next.Name, true) : null;
            }

            var liveNext = DC.WorkflowStepList
                .GetBy("WorkflowDefinitionId = @id AND StepOrder > @order",
                    new { id = instance.WorkflowDefinitionId, order = current.StepOrder })
                .OrderBy(s => s.StepOrder)
                .FirstOrDefault();
            return liveNext != null ? new ResolvedStep(liveNext.Id, liveNext.StepOrder, liveNext.Name, false) : null;
        }

        /// <summary>Every configured assignee across every step before <paramref name="currentStep"/> in
        /// this instance's own step sequence (union, de-duplicated) — used only for the final-step-
        /// approved confirmation broadcast (see SendTransitionNotifications). Falls back to just the
        /// instance's own StartedBy (the original requester) if currentStep has no steps before it (a
        /// one-step procedure).</summary>
        private static List<int> GetAllPreviousStepsAssigneeUserIds(WorkflowInstanceList instance, ResolvedStep currentStep)
        {
            List<ResolvedStep> priorSteps = currentStep.IsSnapshot
                ? DC.WorkflowInstanceStepList
                    .GetBy("WorkflowInstanceId = @id AND StepOrder < @order AND IsDelete = 0",
                        new { id = instance.Id, order = currentStep.StepOrder })
                    .Select(s => new ResolvedStep(s.Id, s.StepOrder, s.Name, true))
                    .ToList()
                : DC.WorkflowStepList
                    .GetBy("WorkflowDefinitionId = @id AND StepOrder < @order",
                        new { id = instance.WorkflowDefinitionId, order = currentStep.StepOrder })
                    .Select(s => new ResolvedStep(s.Id, s.StepOrder, s.Name, false))
                    .ToList();

            if (priorSteps.Count == 0) return new List<int> { instance.StartedBy };

            return priorSteps.SelectMany(GetAssigneeUserIds).Distinct().ToList();
        }

        private static bool HasAssignee(ResolvedStep step, int userId) => step.IsSnapshot
            ? DC.WorkflowInstanceStepAssigneeList.Exists("WorkflowInstanceStepId = @stepId AND UserId = @userId", new { stepId = step.Id, userId })
            : DC.WorkflowStepAssigneeList.Exists("WorkflowStepId = @stepId AND UserId = @userId", new { stepId = step.Id, userId });

        private static List<int> GetAssigneeUserIds(ResolvedStep step) => step.IsSnapshot
            ? DC.WorkflowInstanceStepAssigneeList.GetBy("WorkflowInstanceStepId = @id", new { id = step.Id }).Select(a => a.UserId).ToList()
            : DC.WorkflowStepAssigneeList.GetBy("WorkflowStepId = @id", new { id = step.Id }).Select(a => a.UserId).ToList();
    }
}
