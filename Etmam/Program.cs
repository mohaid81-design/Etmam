using System;
using System.Linq;
using System.Windows.Forms;

namespace Etmam
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
            AppFonts.RegisterEmbeddedFonts();
            AppLookAndFeel.Apply();
            ApplicationConfiguration.Initialize();

            // Launch the Api project locally if nothing is already listening on ApiBaseUrl -
            // login and every migrated screen need it reachable (see docs/api-migration-checklist.md).
            ApiProcessManager.EnsureStarted();
            Application.ApplicationExit += (_, _) => ApiProcessManager.Shutdown();
            AppDomain.CurrentDomain.ProcessExit += (_, _) => ApiProcessManager.Shutdown();

            // Ensure database and tables are created/updated ONCE at startup
            Data.DatabaseInitializer.Initialize();

            RegisterWorkflowEntityDescriptors();

            using (var start = new frmStart())
            {
                if (start.ShowDialog() == DialogResult.OK)
                {
                    using (var login = new frmLogin())
                    {
                        if (login.ShowDialog() == DialogResult.OK)
                        {
                            Application.Run(new frmMainPage());
                        }
                    }
                }
            }
        }

        /// <summary>Registers how WorkflowEngine's WhatsApp notifications should describe each entity
        /// type that plugs into it — a display number and subject line — without the (entity-agnostic)
        /// engine itself needing to know about Purchase Request/Order specifically. See
        /// Data.WorkflowEntityDescriptors and Data.WorkflowEngine.SendTransitionNotifications.</summary>
        private static void RegisterWorkflowEntityDescriptors()
        {
            Data.WorkflowEntityDescriptors.Register("PurchaseRequestList", (dc, id) =>
            {
                var pr = dc.PurchaseRequestList.Find(id);
                string number = pr != null ? PurchaseRequestPrinter.FormatPRNumber(pr.Num, pr.RequestDate) : id.ToString();
                return (number, pr?.Purpose ?? "");
            });

            Data.WorkflowEntityDescriptors.Register("PurchaseOrderList", (dc, id) =>
            {
                var po = dc.PurchaseOrderList.Find(id);
                string number = po != null ? PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate) : id.ToString();
                return (number, po?.Description ?? "");
            });

            Data.WorkflowEntityDescriptors.Register("ConstructionInspectionRequestList", (dc, id) =>
            {
                var cir = dc.ConstructionInspectionRequestList.Find(id);
                if (cir == null) return (id.ToString(), "");

                cir.DisciplineCode = cir.DisciplineId != null ? dc.DisciplinesList.Find(cir.DisciplineId.Value)?.Code : null;
                cir.SecondaryDisciplineCode = cir.SecondaryDisciplineId != null ? dc.SecondaryDisciplinesList.Find(cir.SecondaryDisciplineId.Value)?.Code : null;
                return (CIRNumberFormatter.Format(cir), cir.Description ?? "");
            });

            // بمجرد اكتمال اعتماد طلب شراء بالكامل (لا خطوة تالية)، يُبلَّغ من كان مُكلَّفاً بالخطوة
            // الأولى في إجراء "أمر الشراء" نفسه (PurchaseOrderWorkflowSync.ProcedureName) — لا يوجد أمر
            // شراء بعد في هذه اللحظة (وبالتالي لا مبلغ لتحديد أي إجراء يُطابقه ApprovalMatrixService)،
            // فيُستخدم نفس الإجراء الافتراضي الذي يعتمد عليه PurchaseOrderWorkflowSync.SendForApproval
            // كاحتياطي عند عدم وجود قاعدة مطابقة في مصفوفة الاعتماد. لا علاقة لهذا بمُكلَّفي خطوات
            // اعتماد طلب الشراء نفسه — أولئك يُبلَّغون بالفعل عبر WorkflowEngine.SendTransitionNotifications.
            Data.WorkflowEntityDescriptors.RegisterOnFullyApproved("PurchaseRequestList", (dc, id) =>
            {
                var pr = dc.PurchaseRequestList.Find(id);
                if (pr == null) return;

                var poDefinition = dc.WorkflowDefinitionList
                    .GetBy("Name = @n AND IsDelete = 0", new { n = PurchaseOrderWorkflowSync.ProcedureName })
                    .FirstOrDefault();
                if (poDefinition == null) return; // لم يُعرَّف إجراء أوامر الشراء بعد — لا أحد لإبلاغه

                var firstStep = dc.WorkflowStepList
                    .GetBy("WorkflowDefinitionId = @id", new { id = poDefinition.Id })
                    .OrderBy(s => s.StepOrder)
                    .FirstOrDefault();
                if (firstStep == null) return;

                string number = PurchaseRequestPrinter.FormatPRNumber(pr.Num, pr.RequestDate);
                var assigneeUserIds = dc.WorkflowStepAssigneeList
                    .GetBy("WorkflowStepId = @id", new { id = firstStep.Id })
                    .Select(a => a.UserId);

                foreach (var userId in assigneeUserIds)
                {
                    var user = dc.UsersList.Find(userId);
                    if (user != null)
                        Data.WhatsAppNotifier.SendAsync(user.PhoneNumber,
                            $"تم اعتماد طلب الشراء رقم {number} بالكامل، وهو الآن بحاجة إلى إجراء من قسم المشتريات.");
                }
            });
        }
    }
}