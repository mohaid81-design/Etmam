using System.Reflection;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// EF Core persistence boundary for the entities under Core/Tables. The DbSet list below is
    /// the mechanical, one-line-per-entity twin of Data/DataContext.cs's existing
    /// IDataHelper&lt;T&gt; list (same 95 persisted types — Core.Tables.ProjectComboItem and the
    /// orphaned Core.DrawingsSubmittalDetails were never wired into DataContext either, so they're
    /// left out here too).
    /// </summary>
    public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) =>
            Database.BeginTransactionAsync(cancellationToken);

        public DbSet<ActionLogs> ActionLogs => Set<ActionLogs>();
        public DbSet<ActivityList> ActivityList => Set<ActivityList>();
        public DbSet<ApprovalLimitList> ApprovalLimitList => Set<ApprovalLimitList>();
        public DbSet<ApprovalMatrixList> ApprovalMatrixList => Set<ApprovalMatrixList>();
        public DbSet<AttachmentList> AttachmentList => Set<AttachmentList>();
        public DbSet<AuditLog> AuditLog => Set<AuditLog>();
        public DbSet<AwardRecommendationList> AwardRecommendationList => Set<AwardRecommendationList>();
        public DbSet<BudgetList> BudgetList => Set<BudgetList>();
        public DbSet<ConstructionInspectionRequestList> ConstructionInspectionRequestList => Set<ConstructionInspectionRequestList>();
        public DbSet<CostCenterList> CostCenterList => Set<CostCenterList>();
        public DbSet<DailyReport> DailyReport => Set<DailyReport>();
        public DbSet<DailyReportDisruptedActivity> DailyReportDisruptedActivity => Set<DailyReportDisruptedActivity>();
        public DbSet<DailyReportEquipment> DailyReportEquipment => Set<DailyReportEquipment>();
        public DbSet<DailyReportInspection> DailyReportInspection => Set<DailyReportInspection>();
        public DbSet<DailyReportIssue> DailyReportIssue => Set<DailyReportIssue>();
        public DbSet<DailyReportManpower> DailyReportManpower => Set<DailyReportManpower>();
        public DbSet<DailyReportMaterial> DailyReportMaterial => Set<DailyReportMaterial>();
        public DbSet<DailyReportPhoto> DailyReportPhoto => Set<DailyReportPhoto>();
        public DbSet<DailyReportWorkDone> DailyReportWorkDone => Set<DailyReportWorkDone>();
        public DbSet<DailyReportWorkPlanned> DailyReportWorkPlanned => Set<DailyReportWorkPlanned>();
        public DbSet<DepartmentsList> DepartmentsList => Set<DepartmentsList>();
        public DbSet<DisciplinesList> DisciplinesList => Set<DisciplinesList>();
        public DbSet<DrawingAttachment> DrawingAttachment => Set<DrawingAttachment>();
        public DbSet<DrawingsCategory> DrawingsCategory => Set<DrawingsCategory>();
        public DbSet<DrawingsIssuerList> DrawingsIssuerList => Set<DrawingsIssuerList>();
        public DbSet<DrawingsRegisterDetails> DrawingsRegisterDetails => Set<DrawingsRegisterDetails>();
        public DbSet<DrawingsRegisterList> DrawingsRegisterList => Set<DrawingsRegisterList>();
        public DbSet<DrawingsStatus> DrawingsStatus => Set<DrawingsStatus>();
        public DbSet<DrawingsSubCategory> DrawingsSubCategory => Set<DrawingsSubCategory>();
        public DbSet<DrawingsSubmittalList> DrawingsSubmittalList => Set<DrawingsSubmittalList>();
        public DbSet<DrawingsType> DrawingsType => Set<DrawingsType>();
        public DbSet<EquipmentList> EquipmentList => Set<EquipmentList>();
        public DbSet<ItemCategory> ItemCategory => Set<ItemCategory>();
        public DbSet<ItemsList> ItemsList => Set<ItemsList>();
        public DbSet<ManpowerList> ManpowerList => Set<ManpowerList>();
        public DbSet<MaterialApprovalRequestDetails> MaterialApprovalRequestDetails => Set<MaterialApprovalRequestDetails>();
        public DbSet<MaterialApprovalRequestList> MaterialApprovalRequestList => Set<MaterialApprovalRequestList>();
        public DbSet<MaterialIssueReturnDetails> MaterialIssueReturnDetails => Set<MaterialIssueReturnDetails>();
        public DbSet<MaterialIssueReturnList> MaterialIssueReturnList => Set<MaterialIssueReturnList>();
        public DbSet<MaterialIssuedDetails> MaterialIssuedDetails => Set<MaterialIssuedDetails>();
        public DbSet<MaterialIssuedList> MaterialIssuedList => Set<MaterialIssuedList>();
        public DbSet<MaterialReceiveDetails> MaterialReceiveDetails => Set<MaterialReceiveDetails>();
        public DbSet<MaterialReceiveList> MaterialReceiveList => Set<MaterialReceiveList>();
        public DbSet<MaterialTransferDetails> MaterialTransferDetails => Set<MaterialTransferDetails>();
        public DbSet<MaterialTransferList> MaterialTransferList => Set<MaterialTransferList>();
        public DbSet<NegotiationList> NegotiationList => Set<NegotiationList>();
        public DbSet<NumberSeriesCounter> NumberSeriesCounter => Set<NumberSeriesCounter>();
        public DbSet<OpeningBalanceDetails> OpeningBalanceDetails => Set<OpeningBalanceDetails>();
        public DbSet<OpeningBalanceList> OpeningBalanceList => Set<OpeningBalanceList>();
        public DbSet<POAmendmentDetails> POAmendmentDetails => Set<POAmendmentDetails>();
        public DbSet<POAmendmentList> POAmendmentList => Set<POAmendmentList>();
        public DbSet<PRRFQLineLink> PRRFQLineLink => Set<PRRFQLineLink>();
        public DbSet<PermissionsList> PermissionsList => Set<PermissionsList>();
        public DbSet<PriceQuotationCompareDetails> PriceQuotationCompareDetails => Set<PriceQuotationCompareDetails>();
        public DbSet<PriceQuotationCompareList> PriceQuotationCompareList => Set<PriceQuotationCompareList>();
        public DbSet<PriceQuotationList> PriceQuotationList => Set<PriceQuotationList>();
        public DbSet<PriceQuotationRequestDetails> PriceQuotationRequestDetails => Set<PriceQuotationRequestDetails>();
        public DbSet<PriceQuotationRequestList> PriceQuotationRequestList => Set<PriceQuotationRequestList>();
        public DbSet<ProjectsList> ProjectsList => Set<ProjectsList>();
        public DbSet<PurchaseOrderDetails> PurchaseOrderDetails => Set<PurchaseOrderDetails>();
        public DbSet<PurchaseOrderList> PurchaseOrderList => Set<PurchaseOrderList>();
        public DbSet<PurchaseRequestDetails> PurchaseRequestDetails => Set<PurchaseRequestDetails>();
        public DbSet<PurchaseRequestList> PurchaseRequestList => Set<PurchaseRequestList>();
        public DbSet<PurchaseReturnDetails> PurchaseReturnDetails => Set<PurchaseReturnDetails>();
        public DbSet<PurchaseReturnList> PurchaseReturnList => Set<PurchaseReturnList>();
        public DbSet<RFQDetails> RFQDetails => Set<RFQDetails>();
        public DbSet<RFQList> RFQList => Set<RFQList>();
        public DbSet<RFQVendorList> RFQVendorList => Set<RFQVendorList>();
        public DbSet<ScheduleDetails> ScheduleDetails => Set<ScheduleDetails>();
        public DbSet<ScheduleList> ScheduleList => Set<ScheduleList>();
        public DbSet<StakeholdersCategory> StakeholdersCategory => Set<StakeholdersCategory>();
        public DbSet<StakeholdersList> StakeholdersList => Set<StakeholdersList>();
        public DbSet<StockingDetails> StockingDetails => Set<StockingDetails>();
        public DbSet<StockingList> StockingList => Set<StockingList>();
        public DbSet<StoreList> StoreList => Set<StoreList>();
        public DbSet<SubmittalCategory> SubmittalCategory => Set<SubmittalCategory>();
        public DbSet<SubmittalStatus> SubmittalStatus => Set<SubmittalStatus>();
        public DbSet<SubmittalSubCategory> SubmittalSubCategory => Set<SubmittalSubCategory>();
        public DbSet<SystemSettings> SystemSettings => Set<SystemSettings>();
        public DbSet<TechnicalEvaluationDetails> TechnicalEvaluationDetails => Set<TechnicalEvaluationDetails>();
        public DbSet<TechnicalEvaluationList> TechnicalEvaluationList => Set<TechnicalEvaluationList>();
        public DbSet<Units> Units => Set<Units>();
        public DbSet<UserPermissionStatus> UserPermissionStatus => Set<UserPermissionStatus>();
        public DbSet<UserProjectAccess> UserProjectAccess => Set<UserProjectAccess>();
        public DbSet<UserStoreAccess> UserStoreAccess => Set<UserStoreAccess>();
        public DbSet<UserWorkflowAccess> UserWorkflowAccess => Set<UserWorkflowAccess>();
        public DbSet<UsersList> UsersList => Set<UsersList>();
        public DbSet<UsersRole> UsersRole => Set<UsersRole>();
        public DbSet<WorkflowDefinitionDisciplineList> WorkflowDefinitionDisciplineList => Set<WorkflowDefinitionDisciplineList>();
        public DbSet<WorkflowDefinitionList> WorkflowDefinitionList => Set<WorkflowDefinitionList>();
        public DbSet<WorkflowInstanceHistoryList> WorkflowInstanceHistoryList => Set<WorkflowInstanceHistoryList>();
        public DbSet<WorkflowInstanceList> WorkflowInstanceList => Set<WorkflowInstanceList>();
        public DbSet<WorkflowInstanceStepAssigneeList> WorkflowInstanceStepAssigneeList => Set<WorkflowInstanceStepAssigneeList>();
        public DbSet<WorkflowInstanceStepList> WorkflowInstanceStepList => Set<WorkflowInstanceStepList>();
        public DbSet<WorkflowStepAssigneeList> WorkflowStepAssigneeList => Set<WorkflowStepAssigneeList>();
        public DbSet<WorkflowStepList> WorkflowStepList => Set<WorkflowStepList>();

        private static readonly MethodInfo SoftDeleteFilterMethod = typeof(ApplicationDbContext)
            .GetMethod(nameof(ApplySoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Derive "which CLR types are persisted entities" from the DbSet<T> properties declared
            // above, rather than scanning the whole Core assembly — that keeps this in lockstep with
            // the list above and can't accidentally pick up non-persisted classes that merely live
            // under Core/Tables (e.g. Core.Tables.ProjectComboItem, a UI-only combo-box wrapper).
            var entityClrTypes = typeof(ApplicationDbContext)
                .GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p.PropertyType.GetGenericArguments()[0]);

            foreach (var type in entityClrTypes)
            {
                var entity = modelBuilder.Entity(type);

                // Existing table names are exactly typeof(T).Name (e.g. "ProjectsList"). EF Core's
                // default pluralization convention would rename that to "ProjectsLists" and break
                // every query against the existing schema.
                entity.ToTable(type.Name);

                // Mirrors SqlDataHelper.BuildSafeQuery's automatic "WHERE IsDelete = 0" — every
                // IBaseEntity query is soft-delete-filtered without callers having to repeat it.
                // NOTE: IBaseEntity.CreatedBy/UpdateBy/DeletionBy/IsDelete are non-nullable value types
                // in Core, but the *existing* physical columns are nullable and legacy rows (e.g. the
                // very first seeded admin user, which has no "creator") really do contain NULL.
                // Data/SqlDataHelper.cs's reader silently leaves such a property at its C# default (0 /
                // false) when the column is DBNull, but EF Core has no equivalent: a property's
                // IsNullable is hard-tied to its CLR type (confirmed empirically — even
                // IMutableProperty.IsNullable rejects being set true on an int/bool property, converter
                // or not, "only properties of nullable types can be marked nullable"), so there is no
                // mapping-level fix here. Before this model is ever pointed at a database carrying that
                // legacy NULL data, those columns need a one-time backfill (NULL -> 0 / false) — see
                // docs/api-migration-checklist.md.
                if (typeof(IBaseEntity).IsAssignableFrom(type))
                {
                    SoftDeleteFilterMethod.MakeGenericMethod(type).Invoke(null, new object[] { modelBuilder });
                }

                // Opt-in optimistic-concurrency convention: a property literally named "RowVersion"
                // of type byte[] maps to SQL Server's native ROWVERSION column, matching
                // SqlDataHelper's _rowVersionProp convention.
                var rowVersionProp = type.GetProperty("RowVersion");
                if (rowVersionProp != null && rowVersionProp.PropertyType == typeof(byte[]))
                {
                    entity.Property(rowVersionProp.Name).IsRowVersion();
                }
            }

            // No cascade deletes anywhere: deletes are soft (IsDelete), and several entities have
            // multiple FKs to the same principal table (e.g. ProjectsList -> UsersList x3 via
            // Created/Update/Deletion, -> StakeholdersList x2 via Client/Consultant) which EF Core's
            // default cascade behavior rejects at model-build time as a multiple-cascade-path error.
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Every decimal column in the existing schema is DECIMAL(19,4) (see
            // Data/DatabaseInitializer.cs's GetSqlType — money and quantities both need 4 decimal
            // places). EF Core's unconfigured default is decimal(18,2), which would silently
            // truncate scale on every write if left as-is.
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(19,4)");
            }

            // Resolves the EF Core 10622 model-validation warning: UsersList carries the
            // soft-delete filter above, but these five entities have a *required* FK into it
            // (the CreatedBy/UpdateBy/DeletionBy int is non-nullable — every action always has an
            // actor, including the "unknown creator -> 0" convention from the legacy NULL-audit-
            // column backfill, see docs/api-migration-checklist.md) with no filter of their own.
            // Eager-loading one of these could silently resolve a since-soft-deleted actor's
            // navigation to null despite the relationship being modeled as required, which is
            // exactly what the warning flags. None of these five conceptually need their own
            // soft-delete filter (ScheduleList/UserPermissionStatus/UserProjectAccess/
            // UserStoreAccess/UserWorkflowAccess aren't IBaseEntity), and the FK ints must stay
            // non-nullable, so the fix is telling EF the *navigation* is optional rather than
            // adding a filter these entities don't have a concept for.
            modelBuilder.Entity<ScheduleList>().Navigation(e => e.Created).IsRequired(false);
            modelBuilder.Entity<ScheduleList>().Navigation(e => e.Update).IsRequired(false);
            modelBuilder.Entity<ScheduleList>().Navigation(e => e.Deletion).IsRequired(false);
            modelBuilder.Entity<UserPermissionStatus>().Navigation(e => e.Update).IsRequired(false);
            modelBuilder.Entity<UserProjectAccess>().Navigation(e => e.Update).IsRequired(false);
            modelBuilder.Entity<UserStoreAccess>().Navigation(e => e.Update).IsRequired(false);
            modelBuilder.Entity<UserWorkflowAccess>().Navigation(e => e.Update).IsRequired(false);
        }

        private static void ApplySoftDeleteFilter<TEntity>(ModelBuilder modelBuilder)
            where TEntity : class, IBaseEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDelete);
        }
    }
}
