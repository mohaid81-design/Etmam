using Core;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class DataContext
    {
        // ─── Shared Instance ───────────────────────────────────────────────
        private static DataContext? _shared;
        public static DataContext Shared => _shared ??= new DataContext();

        // Each entity gets a single self-initializing line instead of a separate property
        // declaration plus a matching constructor assignment (previously two places to touch,
        // and easy to update one while forgetting the other).
        #region Helpers
        public IDataHelper<EquipmentList> EquipmentList { get; } = new SqlDataHelper<EquipmentList>();
        public IDataHelper<ManpowerList> ManpowerList { get; } = new SqlDataHelper<ManpowerList>();
        public IDataHelper<PermissionsList> PermissionsList { get; } = new SqlDataHelper<PermissionsList>();
        public IDataHelper<ProjectsList> ProjectsList { get; } = new SqlDataHelper<ProjectsList>();
        public IDataHelper<UsersRole> UsersRole { get; } = new SqlDataHelper<UsersRole>();
        public IDataHelper<UsersList> UsersList { get; } = new SqlDataHelper<UsersList>();
        public IDataHelper<UserPermissionStatus> UserPermissionStatus { get; } = new SqlDataHelper<UserPermissionStatus>();
        public IDataHelper<UserProjectAccess> UserProjectAccess { get; } = new SqlDataHelper<UserProjectAccess>();
        public IDataHelper<UserStoreAccess> UserStoreAccess { get; } = new SqlDataHelper<UserStoreAccess>();
        public IDataHelper<UserWorkflowAccess> UserWorkflowAccess { get; } = new SqlDataHelper<UserWorkflowAccess>();
        public IDataHelper<ActionLogs> ActionLogs { get; } = new SqlDataHelper<ActionLogs>();
        public IDataHelper<DailyReport> DailyReport { get; } = new SqlDataHelper<DailyReport>();
        public IDataHelper<DailyReportManpower> DailyReportManpower { get; } = new SqlDataHelper<DailyReportManpower>();
        public IDataHelper<DailyReportEquipment> DailyReportEquipment { get; } = new SqlDataHelper<DailyReportEquipment>();
        public IDataHelper<DailyReportMaterial> DailyReportMaterial { get; } = new SqlDataHelper<DailyReportMaterial>();
        public IDataHelper<DailyReportIssue> DailyReportIssue { get; } = new SqlDataHelper<DailyReportIssue>();
        public IDataHelper<DailyReportWorkDone> DailyReportWorkDone { get; } = new SqlDataHelper<DailyReportWorkDone>();
        public IDataHelper<DailyReportWorkPlanned> DailyReportWorkPlanned { get; } = new SqlDataHelper<DailyReportWorkPlanned>();
        public IDataHelper<DailyReportInspection> DailyReportInspection { get; } = new SqlDataHelper<DailyReportInspection>();
        public IDataHelper<DailyReportDisruptedActivity> DailyReportDisruptedActivity { get; } = new SqlDataHelper<DailyReportDisruptedActivity>();
        public IDataHelper<DailyReportPhoto> DailyReportPhoto { get; } = new SqlDataHelper<DailyReportPhoto>();
        public IDataHelper<SystemSettings> SystemSettings { get; } = new SqlDataHelper<SystemSettings>();
        public IDataHelper<ActivityList> ActivityList { get; } = new SqlDataHelper<ActivityList>();
        public IDataHelper<ScheduleList> ScheduleList { get; } = new SqlDataHelper<ScheduleList>();
        public IDataHelper<ScheduleDetails> ScheduleDetails { get; } = new SqlDataHelper<ScheduleDetails>();
        public IDataHelper<StakeholdersList> StakeholdersList { get; } = new SqlDataHelper<StakeholdersList>();
        public IDataHelper<StakeholdersCategory> StakeholdersCategory { get; } = new SqlDataHelper<StakeholdersCategory>();
        public IDataHelper<DrawingsRegisterList> DrawingsRegisterList { get; } = new SqlDataHelper<DrawingsRegisterList>();
        public IDataHelper<DrawingsSubmittalList> DrawingsSubmittalList { get; } = new SqlDataHelper<DrawingsSubmittalList>();
        public IDataHelper<DrawingAttachment> DrawingAttachment { get; } = new SqlDataHelper<DrawingAttachment>();
        public IDataHelper<MaterialApprovalRequestList> MaterialApprovalRequestList { get; } = new SqlDataHelper<MaterialApprovalRequestList>();
        public IDataHelper<MaterialApprovalRequestDetails> MaterialApprovalRequestDetails { get; } = new SqlDataHelper<MaterialApprovalRequestDetails>();
        public IDataHelper<SubmittalCategory> SubmittalCategory { get; } = new SqlDataHelper<SubmittalCategory>();
        public IDataHelper<SubmittalSubCategory> SubmittalSubCategory { get; } = new SqlDataHelper<SubmittalSubCategory>();
        public IDataHelper<SubmittalStatus> SubmittalStatus { get; } = new SqlDataHelper<SubmittalStatus>();

        // Procurement
        public IDataHelper<ItemCategory> ItemCategory { get; } = new SqlDataHelper<ItemCategory>();
        public IDataHelper<Units> Units { get; } = new SqlDataHelper<Units>();
        public IDataHelper<ItemsList> ItemsList { get; } = new SqlDataHelper<ItemsList>();
        public IDataHelper<StoreList> StoreList { get; } = new SqlDataHelper<StoreList>();
        public IDataHelper<CostCenterList> CostCenterList { get; } = new SqlDataHelper<CostCenterList>();
        public IDataHelper<BudgetList> BudgetList { get; } = new SqlDataHelper<BudgetList>();
        public IDataHelper<PurchaseRequestList> PurchaseRequestList { get; } = new SqlDataHelper<PurchaseRequestList>();
        public IDataHelper<PurchaseRequestDetails> PurchaseRequestDetails { get; } = new SqlDataHelper<PurchaseRequestDetails>();

        // Inventory Transactions
        public IDataHelper<MaterialReceiveList> MaterialReceiveList { get; } = new SqlDataHelper<MaterialReceiveList>();
        public IDataHelper<MaterialReceiveDetails> MaterialReceiveDetails { get; } = new SqlDataHelper<MaterialReceiveDetails>();
        public IDataHelper<MaterialIssuedList> MaterialIssuedList { get; } = new SqlDataHelper<MaterialIssuedList>();
        public IDataHelper<MaterialIssuedDetails> MaterialIssuedDetails { get; } = new SqlDataHelper<MaterialIssuedDetails>();
        public IDataHelper<MaterialTransferList> MaterialTransferList { get; } = new SqlDataHelper<MaterialTransferList>();
        public IDataHelper<MaterialTransferDetails> MaterialTransferDetails { get; } = new SqlDataHelper<MaterialTransferDetails>();
        public IDataHelper<PurchaseReturnList> PurchaseReturnList { get; } = new SqlDataHelper<PurchaseReturnList>();
        public IDataHelper<PurchaseReturnDetails> PurchaseReturnDetails { get; } = new SqlDataHelper<PurchaseReturnDetails>();
        public IDataHelper<MaterialIssueReturnList> MaterialIssueReturnList { get; } = new SqlDataHelper<MaterialIssueReturnList>();
        public IDataHelper<MaterialIssueReturnDetails> MaterialIssueReturnDetails { get; } = new SqlDataHelper<MaterialIssueReturnDetails>();

        // Workflow Engine
        public IDataHelper<WorkflowDefinitionList> WorkflowDefinitionList { get; } = new SqlDataHelper<WorkflowDefinitionList>();
        public IDataHelper<WorkflowStepList> WorkflowStepList { get; } = new SqlDataHelper<WorkflowStepList>();
        public IDataHelper<WorkflowStepAssigneeList> WorkflowStepAssigneeList { get; } = new SqlDataHelper<WorkflowStepAssigneeList>();
        public IDataHelper<WorkflowInstanceList> WorkflowInstanceList { get; } = new SqlDataHelper<WorkflowInstanceList>();
        public IDataHelper<WorkflowInstanceHistoryList> WorkflowInstanceHistoryList { get; } = new SqlDataHelper<WorkflowInstanceHistoryList>();

        // Generic Attachments (used by the reusable ucAttachmentAddEdit control)
        public IDataHelper<AttachmentList> AttachmentList { get; } = new SqlDataHelper<AttachmentList>();

        #endregion

        /// <summary>
        /// Runs <paramref name="action"/> inside a single connection/transaction so that
        /// multi-table cascading operations commit or roll back atomically.
        /// </summary>
        private static void RunInTransaction(Action<SqlTransaction> action)
        {
            using (var con = new SqlConnection(DBSetting.GetConString()))
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    try
                    {
                        action(tx);
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        #region Procurement Special Operations
        public void DeletePurchaseRequest(int id) => RunInTransaction(tx =>
        {
            PurchaseRequestDetails.DeleteBy("PRId = @id", new { id }, tx);
            PurchaseRequestList.Delete(id, tx);
        });
        #endregion

        #region Inventory Special Operations
        public void DeleteMaterialReceive(int id) => RunInTransaction(tx =>
        {
            MaterialReceiveDetails.DeleteBy("ParentId = @id", new { id }, tx);
            MaterialReceiveList.Delete(id, tx);
        });

        public void DeleteMaterialIssued(int id) => RunInTransaction(tx =>
        {
            MaterialIssuedDetails.DeleteBy("ParentId = @id", new { id }, tx);
            MaterialIssuedList.Delete(id, tx);
        });

        public void DeleteMaterialTransfer(int id) => RunInTransaction(tx =>
        {
            MaterialTransferDetails.DeleteBy("ParentId = @id", new { id }, tx);
            MaterialTransferList.Delete(id, tx);
        });

        public void DeletePurchaseReturn(int id) => RunInTransaction(tx =>
        {
            PurchaseReturnDetails.DeleteBy("ParentId = @id", new { id }, tx);
            PurchaseReturnList.Delete(id, tx);
        });

        public void DeleteMaterialIssueReturn(int id) => RunInTransaction(tx =>
        {
            MaterialIssueReturnDetails.DeleteBy("ParentId = @id", new { id }, tx);
            MaterialIssueReturnList.Delete(id, tx);
        });
        #endregion

        #region Workflow Special Operations
        public void DeleteWorkflowDefinition(int id) => RunInTransaction(tx =>
        {
            var stepIds = WorkflowStepList.GetBy("WorkflowDefinitionId = @id", new { id }).Select(s => s.Id).ToList();
            foreach (var stepId in stepIds)
                WorkflowStepAssigneeList.DeleteBy("WorkflowStepId = @stepId", new { stepId }, tx);

            WorkflowStepList.DeleteBy("WorkflowDefinitionId = @id", new { id }, tx);
            WorkflowDefinitionList.Delete(id, tx);
        });
        #endregion

        #region Daily Report Special Operations
        public void DeleteDailyReport(int id) => RunInTransaction(tx =>
        {
            // Cascading soft-delete for all related tables
            DailyReportManpower.DeleteBy("DailyReportId = @id", new { id }, tx);
            DailyReportEquipment.DeleteBy("DailyReportId = @id", new { id }, tx);
            DailyReportMaterial.DeleteBy("DailyReportId = @id", new { id }, tx);
            DailyReportIssue.DeleteBy("DailyReportId = @id", new { id }, tx);
            DailyReportWorkDone.DeleteBy("DailyReportId = @id", new { id }, tx);
            DailyReportWorkPlanned.DeleteBy("DailyReportId = @id", new { id }, tx);
            DailyReportInspection.DeleteBy("DailyReportId = @id", new { id }, tx);
            DailyReportDisruptedActivity.DeleteBy("DailyReportId = @id", new { id }, tx);
            DailyReportPhoto.DeleteBy("DailyReportId = @id", new { id }, tx);

            // Delete the main report header
            DailyReport.Delete(id, tx);
        });
        #endregion

        /// <summary>
        /// Retrieves the registered data helper for a specific entity type from the shared context.
        /// </summary>
        public IDataHelper<T> GetHelper<T>() where T : class, IBaseEntity, new()
        {
            var prop = this.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(IDataHelper<T>));

            if (prop != null)
            {
                return (IDataHelper<T>)prop.GetValue(this)!;
            }

            // Fallback for types not explicitly registered as properties
            return new SqlDataHelper<T>();
        }

        #region Settings
        public void UseLocal() => DBSetting.IsLocal = true;
        public void UseCloud() => DBSetting.IsLocal = false;
        #endregion
    }
}
