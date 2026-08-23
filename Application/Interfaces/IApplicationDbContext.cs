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

        // Inventory transactional documents - referenced only to check store/item usage before
        // delete (see StoresService.DeleteAsync), mirroring the desktop client's ItemStoreLock.
        DbSet<StockingList> StockingList { get; }
        DbSet<OpeningBalanceList> OpeningBalanceList { get; }
        DbSet<MaterialReceiveList> MaterialReceiveList { get; }
        DbSet<MaterialIssuedList> MaterialIssuedList { get; }
        DbSet<MaterialTransferList> MaterialTransferList { get; }
        DbSet<MaterialIssueReturnList> MaterialIssueReturnList { get; }
        DbSet<PurchaseReturnList> PurchaseReturnList { get; }
        DbSet<PriceQuotationRequestList> PriceQuotationRequestList { get; }

        // Inventory/procurement detail lines - referenced only to check unit usage before delete
        // (see UnitsService.DeleteAsync), mirroring the desktop client's ItemStoreLock.IsItemUsed shape.
        DbSet<MaterialIssueReturnDetails> MaterialIssueReturnDetails { get; }
        DbSet<MaterialIssuedDetails> MaterialIssuedDetails { get; }
        DbSet<MaterialReceiveDetails> MaterialReceiveDetails { get; }
        DbSet<MaterialTransferDetails> MaterialTransferDetails { get; }
        DbSet<OpeningBalanceDetails> OpeningBalanceDetails { get; }
        DbSet<PriceQuotationRequestDetails> PriceQuotationRequestDetails { get; }
        DbSet<PurchaseReturnDetails> PurchaseReturnDetails { get; }
        DbSet<RFQDetails> RFQDetails { get; }
        DbSet<StockingDetails> StockingDetails { get; }

        // Supplier/client/consultant references outside the procurement documents already exposed
        // above (see SuppliersService.DeleteAsync).
        DbSet<RFQVendorList> RFQVendorList { get; }
        DbSet<PriceQuotationList> PriceQuotationList { get; }

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

        // General/Masters simple lookups (see Application/Services/DisciplinesService.cs and
        // siblings) plus the cross-referenced tables their "used elsewhere" delete guards check
        // that weren't already exposed above (mirrors Etmam/Code/Helper/ItemStoreLock.cs's
        // IsBuildingUsed/IsFloorUsed/IsDisciplineUsed/IsSecondaryDisciplineUsed/IsInspectionActivityUsed).
        // DisciplinesList itself was already exposed above.
        DbSet<BuildingsList> BuildingsList { get; }
        DbSet<FloorsList> FloorsList { get; }
        DbSet<SecondaryDisciplinesList> SecondaryDisciplinesList { get; }
        DbSet<InspectionActivityList> InspectionActivityList { get; }

        // Referenced only to check project usage before delete (see ProjectsService.DeleteAsync),
        // mirroring the desktop client's Etmam/Code/ProjectValidationHelper.cs HasTransactions.
        DbSet<MaterialApprovalRequestList> MaterialApprovalRequestList { get; }
        DbSet<DrawingsSubmittalList> DrawingsSubmittalList { get; }
        DbSet<DrawingsRegisterList> DrawingsRegisterList { get; }
        DbSet<ScheduleList> ScheduleList { get; }
        DbSet<DailyReport> DailyReport { get; }
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

        // Generic file attachments (see Application/Services/AttachmentsService.cs) — keyed by
        // (EntityName, EntityRecordId), used by the reusable ucAttachmentAddEdit control across
        // many screens rather than a per-module attachment table.
        DbSet<AttachmentList> AttachmentList { get; }

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
