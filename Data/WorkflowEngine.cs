using Core;

namespace Data
{
    /// <summary>
    /// Generic workflow/approval engine: starts an instance of a WorkflowDefinitionList against
    /// any business record, and advances it step by step as assigned users approve or reject.
    /// Any future module (material request, etc.) drives its approval flow entirely through
    /// this class instead of hand-rolling its own status field.
    /// </summary>
    public static class WorkflowEngine
    {
        private static DataContext DC => DataContext.Shared;

        public static int StartWorkflow(int workflowDefinitionId, string entityName, int entityRecordId, int startedByUserId)
        {
            var firstStep = DC.WorkflowStepList
                .GetBy("WorkflowDefinitionId = @id", new { id = workflowDefinitionId })
                .OrderBy(s => s.StepOrder)
                .FirstOrDefault();

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

            return DC.WorkflowInstanceList.Add(instance);
        }

        public static bool CanUserAct(int instanceId, int userId)
        {
            var instance = DC.WorkflowInstanceList.Find(instanceId);
            if (instance == null || instance.Status != "InProgress") return false;

            var currentStep = GetCurrentStep(instance);
            if (currentStep == null) return false;

            return DC.WorkflowStepAssigneeList
                .Exists("WorkflowStepId = @stepId AND UserId = @userId", new { stepId = currentStep.Id, userId });
        }

        public static void Act(int instanceId, int userId, string action, string? comment)
        {
            var instance = DC.WorkflowInstanceList.Find(instanceId)
                ?? throw new InvalidOperationException("لم يتم العثور على إجراء بهذا الرقم.");

            if (instance.Status != "InProgress")
                throw new InvalidOperationException("هذا الإجراء منتهٍ بالفعل.");

            var currentStep = GetCurrentStep(instance)
                ?? throw new InvalidOperationException("تعذّر تحديد الخطوة الحالية للإجراء.");

            if (!CanUserAct(instanceId, userId))
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

            if (action == "Rejected")
            {
                instance.Status = "Rejected";
                instance.CompletedDate = DateTime.Now;
            }
            else if (action == "Approved")
            {
                var nextStep = DC.WorkflowStepList
                    .GetBy("WorkflowDefinitionId = @id AND StepOrder > @order",
                        new { id = instance.WorkflowDefinitionId, order = currentStep.StepOrder })
                    .OrderBy(s => s.StepOrder)
                    .FirstOrDefault();

                if (nextStep != null)
                {
                    instance.CurrentStepOrder = nextStep.StepOrder;
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
        }

        public static List<WorkflowInstanceList> GetPendingForUser(int userId)
        {
            var stepIdsForUser = DC.WorkflowStepAssigneeList
                .GetBy("UserId = @userId", new { userId })
                .Select(a => a.WorkflowStepId)
                .ToHashSet();

            if (stepIdsForUser.Count == 0) return new List<WorkflowInstanceList>();

            var steps = DC.WorkflowStepList.GetBy("Id IN (" + string.Join(",", stepIdsForUser) + ")")
                .ToDictionary(s => s.Id);

            return DC.WorkflowInstanceList
                .GetBy("Status = 'InProgress'")
                .Where(i => steps.Values.Any(s => s.WorkflowDefinitionId == i.WorkflowDefinitionId && s.StepOrder == i.CurrentStepOrder))
                .ToList();
        }

        private static WorkflowStepList? GetCurrentStep(WorkflowInstanceList instance) =>
            DC.WorkflowStepList
                .GetBy("WorkflowDefinitionId = @id AND StepOrder = @order",
                    new { id = instance.WorkflowDefinitionId, order = instance.CurrentStepOrder })
                .FirstOrDefault();
    }
}
