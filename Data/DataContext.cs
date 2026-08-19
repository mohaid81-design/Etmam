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
        public IDataHelper<DrawingsType> DrawingsType { get; } = new SqlDataHelper<DrawingsType>();
        public IDataHelper<DrawingsCategory> DrawingsCategory { get; } = new SqlDataHelper<DrawingsCategory>();
        public IDataHelper<DrawingsSubCategory> DrawingsSubCategory { get; } = new SqlDataHelper<DrawingsSubCategory>();
        public IDataHelper<DrawingsIssuerList> DrawingsIssuerList { get; } = new SqlDataHelper<DrawingsIssuerList>();
        public IDataHelper<DrawingsStatus> DrawingsStatus { get; } = new SqlDataHelper<DrawingsStatus>();
        public IDataHelper<DrawingsRegisterDetails> DrawingsRegisterDetails { get; } = new SqlDataHelper<DrawingsRegisterDetails>();
        public IDataHelper<MaterialApprovalRequestList> MaterialApprovalRequestList { get; } = new SqlDataHelper<MaterialApprovalRequestList>();
        public IDataHelper<MaterialApprovalRequestDetails> MaterialApprovalRequestDetails { get; } = new SqlDataHelper<MaterialApprovalRequestDetails>();
        public IDataHelper<ConstructionInspectionRequestList> ConstructionInspectionRequestList { get; } = new SqlDataHelper<ConstructionInspectionRequestList>();
        public IDataHelper<SubmittalCategory> SubmittalCategory { get; } = new SqlDataHelper<SubmittalCategory>();
        public IDataHelper<SubmittalSubCategory> SubmittalSubCategory { get; } = new SqlDataHelper<SubmittalSubCategory>();
        public IDataHelper<SubmittalStatus> SubmittalStatus { get; } = new SqlDataHelper<SubmittalStatus>();

        // Procurement
        public IDataHelper<ItemCategory> ItemCategory { get; } = new SqlDataHelper<ItemCategory>();
        public IDataHelper<Units> Units { get; } = new SqlDataHelper<Units>();
        public IDataHelper<ItemsList> ItemsList { get; } = new SqlDataHelper<ItemsList>();
        public IDataHelper<StoreList> StoreList { get; } = new SqlDataHelper<StoreList>();
        public IDataHelper<DisciplinesList> DisciplinesList { get; } = new SqlDataHelper<DisciplinesList>();
        public IDataHelper<SecondaryDisciplinesList> SecondaryDisciplinesList { get; } = new SqlDataHelper<SecondaryDisciplinesList>();
        public IDataHelper<InspectionActivityList> InspectionActivityList { get; } = new SqlDataHelper<InspectionActivityList>();
        public IDataHelper<BuildingsList> BuildingsList { get; } = new SqlDataHelper<BuildingsList>();
        public IDataHelper<FloorsList> FloorsList { get; } = new SqlDataHelper<FloorsList>();
        public IDataHelper<CostCenterList> CostCenterList { get; } = new SqlDataHelper<CostCenterList>();
        public IDataHelper<DepartmentsList> DepartmentsList { get; } = new SqlDataHelper<DepartmentsList>();
        public IDataHelper<BudgetList> BudgetList { get; } = new SqlDataHelper<BudgetList>();
        public IDataHelper<PurchaseRequestList> PurchaseRequestList { get; } = new SqlDataHelper<PurchaseRequestList>();
        public IDataHelper<PurchaseRequestDetails> PurchaseRequestDetails { get; } = new SqlDataHelper<PurchaseRequestDetails>();
        public IDataHelper<PurchaseOrderList> PurchaseOrderList { get; } = new SqlDataHelper<PurchaseOrderList>();
        public IDataHelper<PurchaseOrderDetails> PurchaseOrderDetails { get; } = new SqlDataHelper<PurchaseOrderDetails>();
        public IDataHelper<PriceQuotationList> PriceQuotationList { get; } = new SqlDataHelper<PriceQuotationList>();
        public IDataHelper<PriceQuotationRequestList> PriceQuotationRequestList { get; } = new SqlDataHelper<PriceQuotationRequestList>();
        public IDataHelper<PriceQuotationRequestDetails> PriceQuotationRequestDetails { get; } = new SqlDataHelper<PriceQuotationRequestDetails>();
        public IDataHelper<PriceQuotationCompareList> PriceQuotationCompareList { get; } = new SqlDataHelper<PriceQuotationCompareList>();
        public IDataHelper<PriceQuotationCompareDetails> PriceQuotationCompareDetails { get; } = new SqlDataHelper<PriceQuotationCompareDetails>();

        // Bill of Quantities
        public IDataHelper<BOQList> BOQList { get; } = new SqlDataHelper<BOQList>();
        public IDataHelper<BOQSectionDetails> BOQSectionDetails { get; } = new SqlDataHelper<BOQSectionDetails>();
        public IDataHelper<BOQItemDetails> BOQItemDetails { get; } = new SqlDataHelper<BOQItemDetails>();

        // RFQ envelope (multi-vendor) — see RFQList
        public IDataHelper<RFQList> RFQList { get; } = new SqlDataHelper<RFQList>();
        public IDataHelper<RFQDetails> RFQDetails { get; } = new SqlDataHelper<RFQDetails>();
        public IDataHelper<RFQVendorList> RFQVendorList { get; } = new SqlDataHelper<RFQVendorList>();
        public IDataHelper<PRRFQLineLink> PRRFQLineLink { get; } = new SqlDataHelper<PRRFQLineLink>();

        // Technical Evaluation — see TechnicalEvaluationList
        public IDataHelper<TechnicalEvaluationList> TechnicalEvaluationList { get; } = new SqlDataHelper<TechnicalEvaluationList>();
        public IDataHelper<TechnicalEvaluationDetails> TechnicalEvaluationDetails { get; } = new SqlDataHelper<TechnicalEvaluationDetails>();

        // Award Recommendation — see AwardRecommendationList
        public IDataHelper<AwardRecommendationList> AwardRecommendationList { get; } = new SqlDataHelper<AwardRecommendationList>();

        // Negotiation rounds — see NegotiationList
        public IDataHelper<NegotiationList> NegotiationList { get; } = new SqlDataHelper<NegotiationList>();

        // PO Amendments — see POAmendmentList
        public IDataHelper<POAmendmentList> POAmendmentList { get; } = new SqlDataHelper<POAmendmentList>();
        public IDataHelper<POAmendmentDetails> POAmendmentDetails { get; } = new SqlDataHelper<POAmendmentDetails>();

        // Approval Matrix — see ApprovalMatrixList
        public IDataHelper<ApprovalMatrixList> ApprovalMatrixList { get; } = new SqlDataHelper<ApprovalMatrixList>();
        public IDataHelper<ApprovalLimitList> ApprovalLimitList { get; } = new SqlDataHelper<ApprovalLimitList>();

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
        public IDataHelper<StockingList> StockingList { get; } = new SqlDataHelper<StockingList>();
        public IDataHelper<StockingDetails> StockingDetails { get; } = new SqlDataHelper<StockingDetails>();
        public IDataHelper<OpeningBalanceList> OpeningBalanceList { get; } = new SqlDataHelper<OpeningBalanceList>();
        public IDataHelper<OpeningBalanceDetails> OpeningBalanceDetails { get; } = new SqlDataHelper<OpeningBalanceDetails>();

        // Workflow Engine
        public IDataHelper<WorkflowDefinitionList> WorkflowDefinitionList { get; } = new SqlDataHelper<WorkflowDefinitionList>();
        public IDataHelper<WorkflowStepList> WorkflowStepList { get; } = new SqlDataHelper<WorkflowStepList>();
        public IDataHelper<WorkflowStepAssigneeList> WorkflowStepAssigneeList { get; } = new SqlDataHelper<WorkflowStepAssigneeList>();
        public IDataHelper<WorkflowInstanceList> WorkflowInstanceList { get; } = new SqlDataHelper<WorkflowInstanceList>();
        public IDataHelper<WorkflowInstanceHistoryList> WorkflowInstanceHistoryList { get; } = new SqlDataHelper<WorkflowInstanceHistoryList>();
        public IDataHelper<WorkflowInstanceStepList> WorkflowInstanceStepList { get; } = new SqlDataHelper<WorkflowInstanceStepList>();
        public IDataHelper<WorkflowInstanceStepAssigneeList> WorkflowInstanceStepAssigneeList { get; } = new SqlDataHelper<WorkflowInstanceStepAssigneeList>();
        public IDataHelper<WorkflowDefinitionDisciplineList> WorkflowDefinitionDisciplineList { get; } = new SqlDataHelper<WorkflowDefinitionDisciplineList>();

        // Generic Attachments (used by the reusable ucAttachmentAddEdit control)
        public IDataHelper<AttachmentList> AttachmentList { get; } = new SqlDataHelper<AttachmentList>();

        // Backing table for NumberingService — see Core.NumberSeriesCounter
        public IDataHelper<NumberSeriesCounter> NumberSeriesCounter { get; } = new SqlDataHelper<NumberSeriesCounter>();

        // Generic entity-level audit trail — see AuditService
        public IDataHelper<AuditLog> AuditLog { get; } = new SqlDataHelper<AuditLog>();

        #endregion

        /// <summary>
        /// Runs <paramref name="action"/> inside a single connection/transaction so that
        /// multi-table cascading operations commit or roll back atomically. Public so
        /// Add/Edit forms can wrap a header + its detail rows the same way the cascading
        /// Delete* operations below already do, instead of saving each row independently.
        /// </summary>
        public static void RunInTransaction(Action<SqlTransaction> action)
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

        /// <summary>Deletes a Purchase Request. A PR that was never sent for approval — no
        /// WorkflowInstanceList row exists for it at all, meaning it's still exactly the untouched
        /// draft it started as — is purged outright (real DELETE) instead of the usual soft-delete,
        /// since there's no approval history worth preserving for it. Any PR that ever went through
        /// the workflow (even one later returned to Draft for edits after a rejection) keeps the
        /// normal soft-delete, preserving its audit trail.</summary>
        public void DeletePurchaseRequest(int id) => RunInTransaction(tx =>
        {
            var existing = PurchaseRequestList.Find(id);
            bool everSubmitted = WorkflowInstanceList.Exists(
                "EntityName = 'PurchaseRequestList' AND EntityRecordId = @id", new { id });

            if (everSubmitted)
            {
                PurchaseRequestDetails.DeleteBy("PRId = @id", new { id }, tx);
                PurchaseRequestList.Delete(id, tx);
            }
            else
            {
                PurchaseRequestDetails.HardDeleteBy("PRId = @id", new { id }, tx);
                PurchaseRequestList.HardDeleteBy("Id = @id", new { id }, tx);

                // Free up the number it had reserved, if nothing has been numbered after it yet —
                // otherwise a never-submitted draft leaves a permanent gap in the yearly sequence.
                if (existing?.Num is > 0 && existing.RequestDate.HasValue)
                    NumberingService.ReleaseIfLast(tx, "PurchaseRequestList", existing.RequestDate.Value.Year, existing.Num.Value);
            }

            if (existing != null) AuditService.LogDelete(tx, "PurchaseRequestList", id, existing);
        });

        public void DeletePurchaseOrder(int id) => RunInTransaction(tx =>
        {
            var existing = PurchaseOrderList.Find(id);
            PurchaseOrderDetails.DeleteBy("ParentId = @id", new { id }, tx);
            PurchaseOrderList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "PurchaseOrderList", id, existing);
        });

        public void DeletePriceQuotationRequest(int id) => RunInTransaction(tx =>
        {
            var existing = PriceQuotationRequestList.Find(id);
            PriceQuotationRequestDetails.DeleteBy("ParentId = @id", new { id }, tx);
            PriceQuotationRequestList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "PriceQuotationRequestList", id, existing);
        });

        public void DeletePriceQuotationCompare(int id) => RunInTransaction(tx =>
        {
            var existing = PriceQuotationCompareList.Find(id);
            PriceQuotationCompareDetails.DeleteBy("ParentId = @id", new { id }, tx);
            PriceQuotationCompareList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "PriceQuotationCompareList", id, existing);
        });

        public void DeleteRFQ(int id) => RunInTransaction(tx =>
        {
            var existing = RFQList.Find(id);
            var detailIds = RFQDetails.GetBy("RFQId = @id AND IsDelete = 0", new { id }).Select(d => d.Id).ToList();
            foreach (var detailId in detailIds)
                PRRFQLineLink.DeleteBy("RFQDetailId = @detailId", new { detailId }, tx);

            RFQDetails.DeleteBy("RFQId = @id", new { id }, tx);
            RFQVendorList.DeleteBy("RFQId = @id", new { id }, tx);
            RFQList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "RFQList", id, existing);
        });

        public void DeleteTechnicalEvaluation(int id) => RunInTransaction(tx =>
        {
            var existing = TechnicalEvaluationList.Find(id);
            TechnicalEvaluationDetails.DeleteBy("ParentId = @id", new { id }, tx);
            TechnicalEvaluationList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "TechnicalEvaluationList", id, existing);
        });

        public void DeleteAwardRecommendation(int id) => RunInTransaction(tx =>
        {
            var existing = AwardRecommendationList.Find(id);
            AwardRecommendationList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "AwardRecommendationList", id, existing);
        });

        public void DeleteNegotiation(int id) => RunInTransaction(tx =>
        {
            var existing = NegotiationList.Find(id);
            NegotiationList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "NegotiationList", id, existing);
        });

        public void DeletePOAmendment(int id) => RunInTransaction(tx =>
        {
            var existing = POAmendmentList.Find(id);
            POAmendmentDetails.DeleteBy("ParentId = @id", new { id }, tx);
            POAmendmentList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "POAmendmentList", id, existing);
        });

        public void DeleteApprovalMatrix(int id) => RunInTransaction(tx =>
        {
            var existing = ApprovalMatrixList.Find(id);
            ApprovalLimitList.DeleteBy("MatrixId = @id", new { id }, tx);
            ApprovalMatrixList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "ApprovalMatrixList", id, existing);
        });

        public void DeleteBOQ(int id) => RunInTransaction(tx =>
        {
            var existing = BOQList.Find(id);
            BOQItemDetails.DeleteBy("BOQId = @id", new { id }, tx);
            BOQSectionDetails.DeleteBy("BOQId = @id", new { id }, tx);
            BOQList.Delete(id, tx);
            if (existing != null) AuditService.LogDelete(tx, "BOQList", id, existing);
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

        public void DeleteStocking(int id) => RunInTransaction(tx =>
        {
            StockingDetails.DeleteBy("ParentId = @id", new { id }, tx);
            StockingList.Delete(id, tx);
        });

        public void DeleteOpeningBalance(int id) => RunInTransaction(tx =>
        {
            OpeningBalanceDetails.DeleteBy("ParentId = @id", new { id }, tx);
            OpeningBalanceList.Delete(id, tx);
        });

        public void DeleteDrawingsRegister(int id) => RunInTransaction(tx =>
        {
            DrawingsRegisterDetails.DeleteBy("ParentId = @id", new { id }, tx);
            DrawingAttachment.DeleteBy("DrawingId = @id", new { id }, tx);
            DrawingsRegisterList.Delete(id, tx);
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
    }
}
