using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public sealed class WorkflowService : IWorkflowService
    {
        private readonly IApplicationDbContext _db;
        private readonly IWhatsAppNotifier _whatsApp;
        private readonly Dictionary<string, IWorkflowEntityDescriber> _describers;

        public WorkflowService(IApplicationDbContext db, IWhatsAppNotifier whatsApp, IEnumerable<IWorkflowEntityDescriber> describers)
        {
            _db = db;
            _whatsApp = whatsApp;
            _describers = describers.ToDictionary(d => d.EntityName);
        }

        // A step, resolved from either the instance's own frozen snapshot or (for a legacy
        // instance with no snapshot, e.g. one started long ago from the desktop before
        // snapshotting existed there) the live WorkflowStepList.
        private readonly record struct ResolvedStep(int Id, int StepOrder, string? Name, bool IsSnapshot);

        public async Task<int> StartWorkflowAsync(int workflowDefinitionId, string entityName, int entityRecordId, int startedByUserId, CancellationToken ct = default)
        {
            var liveSteps = await _db.WorkflowStepList
                .Where(s => s.WorkflowDefinitionId == workflowDefinitionId)
                .OrderBy(s => s.StepOrder)
                .ToListAsync(ct);

            var firstStep = liveSteps.FirstOrDefault()
                ?? throw new InvalidOperationException("لا يمكن بدء الإجراء: لا توجد خطوات معرّفة له.");

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
                CreatedMachine = Environment.MachineName
            };

            // Wrapped in one transaction (matching the original's DataContext.RunInTransaction) so
            // the instance and its full step/assignee snapshot commit or roll back together -
            // several SaveChangesAsync calls are needed below only to obtain each generated Id
            // before it's referenced as a FK, not because these are independent operations.
            await using var tx = await _db.BeginTransactionAsync(ct);

            _db.WorkflowInstanceList.Add(instance);
            await _db.SaveChangesAsync(ct);

            // Snapshot every step of the procedure as it stands right now, plus each step's
            // current assignees - this instance only ever consults these frozen copies from here on.
            foreach (var liveStep in liveSteps)
            {
                var snapshotStep = new WorkflowInstanceStepList
                {
                    WorkflowInstanceId = instance.Id,
                    StepOrder = liveStep.StepOrder,
                    Name = liveStep.Name,
                    Description = liveStep.Description,
                    CreatedDate = DateTime.Now,
                    CreatedBy = startedByUserId,
                    CreatedMachine = Environment.MachineName,
                    IsDelete = false
                };
                _db.WorkflowInstanceStepList.Add(snapshotStep);
                await _db.SaveChangesAsync(ct);

                var assignees = await _db.WorkflowStepAssigneeList
                    .Where(a => a.WorkflowStepId == liveStep.Id)
                    .ToListAsync(ct);

                foreach (var assignee in assignees)
                {
                    _db.WorkflowInstanceStepAssigneeList.Add(new WorkflowInstanceStepAssigneeList
                    {
                        WorkflowInstanceStepId = snapshotStep.Id,
                        UserId = assignee.UserId,
                        CreatedDate = DateTime.Now,
                        CreatedBy = startedByUserId,
                        CreatedMachine = Environment.MachineName,
                        IsDelete = false
                    });
                }
            }
            await _db.SaveChangesAsync(ct);
            await tx.CommitAsync(ct);

            return instance.Id;
        }

        public async Task<bool> CanUserActAsync(int instanceId, int userId, CancellationToken ct = default)
        {
            var instance = await _db.WorkflowInstanceList.FirstOrDefaultAsync(i => i.Id == instanceId, ct);
            if (instance is null || instance.Status != "InProgress") return false;

            var currentStep = await GetCurrentStepAsync(instance, ct);
            if (currentStep is null) return false;

            return await HasAssigneeAsync(currentStep.Value, userId, ct);
        }

        public async Task ActAsync(int instanceId, int userId, string action, string? comment, CancellationToken ct = default)
        {
            var instance = await _db.WorkflowInstanceList.FirstOrDefaultAsync(i => i.Id == instanceId, ct)
                ?? throw new InvalidOperationException("لم يتم العثور على إجراء بهذا الرقم.");

            if (instance.Status != "InProgress")
                throw new InvalidOperationException("هذا الإجراء منتهٍ بالفعل.");

            var currentStep = await GetCurrentStepAsync(instance, ct)
                ?? throw new InvalidOperationException("تعذّر تحديد الخطوة الحالية للإجراء.");

            if (!await HasAssigneeAsync(currentStep, userId, ct))
                throw new InvalidOperationException("ليس لديك صلاحية التصرف في هذه الخطوة.");

            _db.WorkflowInstanceHistoryList.Add(new WorkflowInstanceHistoryList
            {
                WorkflowInstanceId = instanceId,
                WorkflowStepId = currentStep.Id,
                ActionBy = userId,
                Action = action,
                ActionDate = DateTime.Now,
                Comment = comment,
                CreatedDate = DateTime.Now,
                CreatedBy = userId,
                CreatedMachine = Environment.MachineName
            });

            ResolvedStep? nextStep = null;

            if (action == "Rejected")
            {
                instance.Status = "Rejected";
                instance.CompletedDate = DateTime.Now;
            }
            else if (action == "Approved")
            {
                nextStep = await GetNextStepAsync(instance, currentStep, ct);
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
            instance.UpdateMachine = Environment.MachineName;

            await _db.SaveChangesAsync(ct);

            // Notifications happen after the transition is already committed - a WhatsApp failure
            // must never roll back or fail the action that triggered it (see IWhatsAppNotifier).
            await SendTransitionNotificationsAsync(instance, currentStep, nextStep, action, comment, ct);
        }

        /// <summary>Web-side port of Data/WorkflowEngine.SendTransitionNotifications - see that
        /// method's own summary for the exact broadcast rules (terminal → confirm everyone who ever
        /// held a prior step, falling back to the original requester for a one-step procedure;
        /// advancing → notify only the next step's assignees). Not ported: the PurchaseRequestList
        /// "fully approved → ping whoever can raise a PO" extra hook
        /// (WorkflowEntityDescriptors.NotifyFullyApproved on desktop) - a documented gap, not
        /// something this pass needed to close.</summary>
        private async Task SendTransitionNotificationsAsync(WorkflowInstanceList instance, ResolvedStep currentStep,
            ResolvedStep? nextStep, string action, string? comment, CancellationToken ct)
        {
            var definition = await _db.WorkflowDefinitionList.FirstOrDefaultAsync(d => d.Id == instance.WorkflowDefinitionId, ct);
            var defName = definition?.Name ?? "إجراء";
            var actionVerb = action switch { "Approved" => "اعتماد", "Rejected" => "رفض", _ => action };

            var (number, subject) = _describers.TryGetValue(instance.EntityName, out var describer)
                ? await describer.DescribeAsync(instance.EntityRecordId, ct)
                : (instance.EntityRecordId.ToString(), "");

            if (nextStep is null)
            {
                var reasonPart = action == "Rejected" && !string.IsNullOrWhiteSpace(comment) ? $" السبب: {comment}" : "";
                var message = $"تم {actionVerb} {defName} رقم {number}.{reasonPart}";

                foreach (var uid in await GetAllPreviousStepsAssigneeUserIdsAsync(instance, currentStep, ct))
                {
                    var user = await _db.UsersList.FirstOrDefaultAsync(u => u.Id == uid, ct);
                    if (user != null) await _whatsApp.SendAsync(user.PhoneNumber, message, ct);
                }
            }
            else
            {
                var subjectPart = string.IsNullOrWhiteSpace(subject) ? "" : $" عبارة عن {subject}";
                foreach (var uid in await GetAssigneeUserIdsAsync(nextStep.Value, ct))
                {
                    var user = await _db.UsersList.FirstOrDefaultAsync(u => u.Id == uid, ct);
                    if (user != null)
                        await _whatsApp.SendAsync(user.PhoneNumber, $"لديك مهمة اعتماد {defName} رقم {number}{subjectPart}.", ct);
                }
            }
        }

        /// <summary>Every user ever assigned to a step before currentStep (StepOrder strictly less
        /// than), falling back to the instance's own StartedBy if currentStep was the first step (no
        /// prior steps exist to have assignees) - matches
        /// WorkflowEngine.GetAllPreviousStepsAssigneeUserIds exactly.</summary>
        private async Task<List<int>> GetAllPreviousStepsAssigneeUserIdsAsync(WorkflowInstanceList instance, ResolvedStep currentStep, CancellationToken ct)
        {
            List<ResolvedStep> priorSteps = currentStep.IsSnapshot
                ? (await _db.WorkflowInstanceStepList
                    .Where(s => s.WorkflowInstanceId == instance.Id && s.StepOrder < currentStep.StepOrder && !s.IsDelete)
                    .ToListAsync(ct))
                    .Select(s => new ResolvedStep(s.Id, s.StepOrder, s.Name, true)).ToList()
                : (await _db.WorkflowStepList
                    .Where(s => s.WorkflowDefinitionId == instance.WorkflowDefinitionId && s.StepOrder < currentStep.StepOrder)
                    .ToListAsync(ct))
                    .Select(s => new ResolvedStep(s.Id, s.StepOrder, s.Name, false)).ToList();

            if (priorSteps.Count == 0) return [instance.StartedBy];

            var result = new List<int>();
            foreach (var step in priorSteps)
                result.AddRange(await GetAssigneeUserIdsAsync(step, ct));
            return result.Distinct().ToList();
        }

        private Task<List<int>> GetAssigneeUserIdsAsync(ResolvedStep step, CancellationToken ct) => step.IsSnapshot
            ? _db.WorkflowInstanceStepAssigneeList.Where(a => a.WorkflowInstanceStepId == step.Id).Select(a => a.UserId).ToListAsync(ct)
            : _db.WorkflowStepAssigneeList.Where(a => a.WorkflowStepId == step.Id).Select(a => a.UserId).ToListAsync(ct);

        public async Task ReturnToStepAsync(int instanceId, int userId, int targetStepOrder, string comment, bool requireCurrentStepAssignee, CancellationToken ct = default)
        {
            var instance = await _db.WorkflowInstanceList.FirstOrDefaultAsync(i => i.Id == instanceId, ct)
                ?? throw new InvalidOperationException("لم يتم العثور على إجراء بهذا الرقم.");

            if (instance.Status != "InProgress" && instance.Status != "Approved")
                throw new InvalidOperationException("لا يمكن إعادة إجراء مرفوض أو غير معروف الحالة إلى خطوة سابقة.");

            var currentStep = await GetCurrentStepAsync(instance, ct)
                ?? throw new InvalidOperationException("تعذّر تحديد الخطوة الحالية للإجراء.");

            if (requireCurrentStepAssignee && !await HasAssigneeAsync(currentStep, userId, ct))
                throw new InvalidOperationException("ليس لديك صلاحية التصرف في هذه الخطوة.");

            var targetStep = await GetStepByOrderAsync(instance, targetStepOrder, currentStep.IsSnapshot, ct)
                ?? throw new InvalidOperationException("الخطوة المطلوبة غير موجودة ضمن هذا الإجراء.");

            if (targetStep.StepOrder > currentStep.StepOrder)
                throw new InvalidOperationException("لا يمكن الإعادة إلى خطوة لاحقة — الإعادة تكون لخطوة سابقة أو الحالية فقط.");

            if (string.IsNullOrWhiteSpace(comment))
                throw new InvalidOperationException("يرجى كتابة سبب الإعادة.");

            _db.WorkflowInstanceHistoryList.Add(new WorkflowInstanceHistoryList
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
                CreatedMachine = Environment.MachineName
            });

            // The instance always comes back "InProgress" after a return, even if it had already
            // finished as Approved - a return means reopening it from the target step onward.
            instance.Status = "InProgress";
            instance.CurrentStepOrder = targetStep.StepOrder;
            instance.CompletedDate = null;
            instance.UpdateDate = DateTime.Now;
            instance.UpdateBy = userId;
            instance.UpdateMachine = Environment.MachineName;

            await _db.SaveChangesAsync(ct);
        }

        public Task<WorkflowInstanceList?> GetActiveInstanceAsync(string entityName, int entityRecordId, CancellationToken ct = default) =>
            _db.WorkflowInstanceList
                .FirstOrDefaultAsync(i => i.EntityName == entityName && i.EntityRecordId == entityRecordId && i.Status == "InProgress", ct);

        public Task<WorkflowInstanceList?> GetLatestInstanceAsync(string entityName, int entityRecordId, CancellationToken ct = default) =>
            _db.WorkflowInstanceList
                .Where(i => i.EntityName == entityName && i.EntityRecordId == entityRecordId)
                .OrderByDescending(i => i.Id)
                .FirstOrDefaultAsync(ct);

        public async Task<string?> GetCurrentStepNameAsync(WorkflowInstanceList instance, CancellationToken ct = default)
        {
            var step = await GetCurrentStepAsync(instance, ct);
            return step?.Name;
        }

        private async Task<ResolvedStep?> GetCurrentStepAsync(WorkflowInstanceList instance, CancellationToken ct)
        {
            var snapshot = await _db.WorkflowInstanceStepList
                .FirstOrDefaultAsync(s => s.WorkflowInstanceId == instance.Id && s.StepOrder == instance.CurrentStepOrder && !s.IsDelete, ct);
            if (snapshot != null) return new ResolvedStep(snapshot.Id, snapshot.StepOrder, snapshot.Name, true);

            var live = await _db.WorkflowStepList
                .FirstOrDefaultAsync(s => s.WorkflowDefinitionId == instance.WorkflowDefinitionId && s.StepOrder == instance.CurrentStepOrder, ct);
            return live != null ? new ResolvedStep(live.Id, live.StepOrder, live.Name, false) : null;
        }

        private async Task<ResolvedStep?> GetStepByOrderAsync(WorkflowInstanceList instance, int stepOrder, bool isSnapshot, CancellationToken ct)
        {
            if (isSnapshot)
            {
                var snapshot = await _db.WorkflowInstanceStepList
                    .FirstOrDefaultAsync(s => s.WorkflowInstanceId == instance.Id && s.StepOrder == stepOrder && !s.IsDelete, ct);
                return snapshot != null ? new ResolvedStep(snapshot.Id, snapshot.StepOrder, snapshot.Name, true) : null;
            }

            var live = await _db.WorkflowStepList
                .FirstOrDefaultAsync(s => s.WorkflowDefinitionId == instance.WorkflowDefinitionId && s.StepOrder == stepOrder, ct);
            return live != null ? new ResolvedStep(live.Id, live.StepOrder, live.Name, false) : null;
        }

        private async Task<ResolvedStep?> GetNextStepAsync(WorkflowInstanceList instance, ResolvedStep current, CancellationToken ct)
        {
            if (current.IsSnapshot)
            {
                var next = await _db.WorkflowInstanceStepList
                    .Where(s => s.WorkflowInstanceId == instance.Id && s.StepOrder > current.StepOrder && !s.IsDelete)
                    .OrderBy(s => s.StepOrder)
                    .FirstOrDefaultAsync(ct);
                return next != null ? new ResolvedStep(next.Id, next.StepOrder, next.Name, true) : null;
            }

            var liveNext = await _db.WorkflowStepList
                .Where(s => s.WorkflowDefinitionId == instance.WorkflowDefinitionId && s.StepOrder > current.StepOrder)
                .OrderBy(s => s.StepOrder)
                .FirstOrDefaultAsync(ct);
            return liveNext != null ? new ResolvedStep(liveNext.Id, liveNext.StepOrder, liveNext.Name, false) : null;
        }

        private Task<bool> HasAssigneeAsync(ResolvedStep step, int userId, CancellationToken ct) => step.IsSnapshot
            ? _db.WorkflowInstanceStepAssigneeList.AnyAsync(a => a.WorkflowInstanceStepId == step.Id && a.UserId == userId, ct)
            : _db.WorkflowStepAssigneeList.AnyAsync(a => a.WorkflowStepId == step.Id && a.UserId == userId, ct);
    }
}
