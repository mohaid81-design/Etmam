using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces
{
    /// <summary>
    /// Persistence abstraction the Application layer codes against; implemented by
    /// Infrastructure's EF Core DbContext. Only exposes the DbSets the current vertical
    /// slices (Auth, Projects) need — extend as more slices are migrated.
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<UsersList> UsersList { get; }
        DbSet<ProjectsList> ProjectsList { get; }
        DbSet<UserProjectAccess> UserProjectAccess { get; }
        DbSet<ActionLogs> ActionLogs { get; }

        // Procurement/Inventory masters (batch 1)
        DbSet<StakeholdersList> StakeholdersList { get; }
        DbSet<StakeholdersCategory> StakeholdersCategory { get; }
        DbSet<ItemCategory> ItemCategory { get; }
        DbSet<Units> Units { get; }
        DbSet<ItemsList> ItemsList { get; }
        DbSet<StoreList> StoreList { get; }

        // Purchase Request + approval workflow (batch 2)
        DbSet<PurchaseRequestList> PurchaseRequestList { get; }
        DbSet<PurchaseRequestDetails> PurchaseRequestDetails { get; }

        // Purchase Order approval workflow (mobile approvals slice)
        DbSet<PurchaseOrderList> PurchaseOrderList { get; }
        DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; }

        // Construction Inspection Request (CIR) approval workflow (mobile approvals slice)
        DbSet<ConstructionInspectionRequestList> ConstructionInspectionRequestList { get; }

        // Generic key/value settings store (WhatsApp notification config, etc.)
        DbSet<SystemSettings> SystemSettings { get; }

        DbSet<CostCenterList> CostCenterList { get; }
        DbSet<BudgetList> BudgetList { get; }
        DbSet<DisciplinesList> DisciplinesList { get; }
        DbSet<DepartmentsList> DepartmentsList { get; }
        DbSet<WorkflowDefinitionList> WorkflowDefinitionList { get; }
        DbSet<WorkflowDefinitionDisciplineList> WorkflowDefinitionDisciplineList { get; }
        DbSet<WorkflowStepList> WorkflowStepList { get; }
        DbSet<WorkflowStepAssigneeList> WorkflowStepAssigneeList { get; }
        DbSet<WorkflowInstanceList> WorkflowInstanceList { get; }
        DbSet<WorkflowInstanceStepList> WorkflowInstanceStepList { get; }
        DbSet<WorkflowInstanceStepAssigneeList> WorkflowInstanceStepAssigneeList { get; }
        DbSet<WorkflowInstanceHistoryList> WorkflowInstanceHistoryList { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Starts an explicit transaction shared by both EF Core writes and INumberingService's raw
        /// sp_getapplock calls against the same underlying connection - needed only by flows that
        /// reserve a document number (see PurchaseRequestsService.CreateAsync), so the number
        /// reservation and the row that consumes it commit or roll back together.
        /// </summary>
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
