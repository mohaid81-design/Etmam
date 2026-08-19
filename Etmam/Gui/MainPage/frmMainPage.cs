using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Tables;
using DevExpress.DataAccess.Native;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using Etmam.Gui.ContractMgt;
using Etmam.Gui.EDMSMgt;
using Etmam.Gui.CorrespondenceMgt;
using Etmam.Gui.QualityMgt;
using Etmam.Gui.HSEMgt;
using Etmam.Gui.CostControlMgt;

namespace Etmam
{
    public partial class frmMainPage : BaseRibbonForm
    {
        private bool _isSyncing;

        public frmMainPage()
        {
            InitializeComponent();
            InitAccentColors();
            Data.PermissionService.Invalidate();
            SetButtonEnabled();
            LoadProjects();
            UpdateStatusInfo();
            WireEvents();
            StyleTabbedView();

            // يظهر خلف منطقة التابات عندما لا يوجد أي تاب مفتوح، بدل مساحة فارغة
            tabbedView1.DocumentAdded += (s, e) => UpdateEmptyTabsState();
            tabbedView1.DocumentRemoved += (s, e) => UpdateEmptyTabsState();
            UpdateEmptyTabsState();

            ribbonControl.Minimized = true;

            //navigationAccordion.ElementClick += navigationAccordion_ElementClick;

            //// Initial view (forced: aceMain is a group header, not an ElementStyle.Item,
            //// so it would never pass the click-driven guard in ShowModule).
            //navigationAccordion.SelectedElement = aceMain;
            //ShowModule(aceMain, force: true);
        }

        #region Initialization
        private void StyleTabbedView()
        {
            var ap = tabbedView1.AppearancePage;

            // Dedicated tab palette: the old HeaderActive/HeaderSelected gradients (Primary
            // vs Accent) were both blue and too close in tone, so the actually-open tab
            // barely stood out from a merely-focused group. This palette uses one flat deep
            // navy for "this tab is open" plus a gold underline as an unmistakable marker,
            // while inactive tabs stay muted and neutral for contrast.
            // Made noticeably darker than the first pass — a near-white gray blended into
            // "The Bezier" skin's own light panels and read as no styling at all.
            Color inactiveBack = Color.FromArgb(203, 210, 221);
            Color inactiveFore = Color.FromArgb(45, 55, 70);
            Color inactiveBorder = Color.FromArgb(150, 160, 178);

            Color hoverBack = Color.FromArgb(219, 234, 254);
            Color hoverFore = Color.FromArgb(20, 60, 120);

            Color openBack = Color.FromArgb(21, 61, 111);    // flat navy, no gradient
            Color openAccent = Color.FromArgb(242, 169, 59); // gold underline marking the open tab

            Color disabledBack = Color.FromArgb(246, 247, 249);
            Color disabledFore = Color.FromArgb(180, 186, 196);

            Color contentBack = Color.FromArgb(244, 246, 249);

            // Inactive tab
            ap.Header.BackColor = inactiveBack;
            ap.Header.ForeColor = inactiveFore;
            ap.Header.BorderColor = inactiveBorder;
            ap.Header.Font = new Font("Cairo", 8.5F);
            ap.Header.Options.UseBackColor = true;
            ap.Header.Options.UseForeColor = true;
            ap.Header.Options.UseBorderColor = true;
            ap.Header.Options.UseFont = true;

            // Hover
            ap.HeaderHotTracked.BackColor = hoverBack;
            ap.HeaderHotTracked.ForeColor = hoverFore;
            ap.HeaderHotTracked.Font = new Font("Cairo", 8.5F);
            ap.HeaderHotTracked.Options.UseBackColor = true;
            ap.HeaderHotTracked.Options.UseForeColor = true;
            ap.HeaderHotTracked.Options.UseFont = true;

            // Active tab group header (highlighted when this group has focus) — same flat
            // navy as HeaderSelected below so both read as one consistent "open" signal
            // instead of two competing shades of blue.
            ap.HeaderActive.BackColor = openBack;
            ap.HeaderActive.ForeColor = Color.White;
            ap.HeaderActive.Font = new Font("Cairo", 9F, FontStyle.Bold);
            ap.HeaderActive.Options.UseBackColor = true;
            ap.HeaderActive.Options.UseForeColor = true;
            ap.HeaderActive.Options.UseFont = true;

            // Selected (currently open) tab — flat navy plus a gold underline, unmistakable
            // against the muted inactive tabs.
            ap.HeaderSelected.BackColor = openBack;
            ap.HeaderSelected.ForeColor = Color.White;
            ap.HeaderSelected.BorderColor = openAccent;
            ap.HeaderSelected.Font = new Font("Cairo", 9.5F, FontStyle.Bold);
            ap.HeaderSelected.Options.UseBackColor = true;
            ap.HeaderSelected.Options.UseForeColor = true;
            ap.HeaderSelected.Options.UseBorderColor = true;
            ap.HeaderSelected.Options.UseFont = true;

            // Disabled
            ap.HeaderDisabled.BackColor = disabledBack;
            ap.HeaderDisabled.ForeColor = disabledFore;
            ap.HeaderDisabled.Font = new Font("Cairo", 8.5F);
            ap.HeaderDisabled.Options.UseBackColor = true;
            ap.HeaderDisabled.Options.UseForeColor = true;
            ap.HeaderDisabled.Options.UseFont = true;

            // Content area behind each open module — matches the app's shared background
            // instead of the default skin color, so it doesn't look like a mismatched panel.
            ap.PageClient.BackColor = contentBack;
            ap.PageClient.Options.UseBackColor = true;

            // Show the close (×) button only on the active tab or on hover, not on every
            // tab at once — reduces visual clutter when several modules are open.
            tabbedView1.DocumentGroupProperties.ClosePageButtonShowMode =
                DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
        }

        /// <summary>Shows the placeholder image behind the tab area when the last document tab is
        /// closed, and hides it again once a tab is open — otherwise the area is just blank.</summary>
        private void UpdateEmptyTabsState()
        {
            bool isEmpty = tabbedView1.Documents.Count == 0;
            pictureBoxEmptyTabs.Visible = isEmpty;
            if (isEmpty) pictureBoxEmptyTabs.BringToFront();
        }

        private void InitAccentColors()
        {
            SkinHelper.InitTrackWindowsAppMode(bciTrackWindowsAppMode);
            SkinHelper.InitResetToOriginalPalette(bciOriginalPalette);
            SkinHelper.InitTrackWindowsAccentColor(bciTrackWindowsAccentColor);
            SkinHelper.InitCustomAccentColor(Ribbon.Manager, bbiCustomColors);
            SkinHelper.InitCustomAccentColor2(Ribbon.Manager, bbiCustomColors2);

            bciTrackWindowsAppMode.SuperTip = CreateSuperTip("This setting is available for WXI, Basic, and Bezier skins.");
            bbiCustomColors.SuperTip = CreateSuperTip("Custom Accent Color.");
            bbiCustomColors2.SuperTip = CreateSuperTip("Custom Accent Color 2.");
        }

        private SuperToolTip CreateSuperTip(string text)
        {
            var tip = new SuperToolTip();
            tip.Items.Add(text);
            tip.Items[0].Appearance.FontStyleDelta = FontStyle.Bold;
            return tip;
        }

        private void LoadProjects()
        {
            try
            {
                var grantedProjectIds = Data.PermissionService.GrantedProjectIds(Data.DataContext.Shared);
                var projects = Data.DataContext.Shared.ProjectsList
                    .GetAll()
                    .Where(p => !p.IsDelete && grantedProjectIds.Contains(p.Id))
                    .OrderBy(p => p.Name)
                    .ToList();

                Session.IsSingleProjectUser = projects.Count == 1;

                cboProject.Properties.Items.Clear();

                // Placeholder item
                cboProject.Properties.Items.Add(new ProjectComboItem(null, "--- اختر المشروع ---"));

                foreach (var proj in projects)
                    cboProject.Properties.Items.Add(new ProjectComboItem(proj.Id, proj.Name ?? $"مشروع {proj.Id}"));

                // Wire the EditValueChanged event
                cboProject.EditValueChanged += CboProject_EditValueChanged;

                // Auto-select if only one project
                if (projects.Count == 1)
                    cboProject.EditValue = cboProject.Properties.Items[1]; // index 1 = first real project
                else
                    cboProject.SelectedIndex = 0; // placeholder
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadProjects error: {ex.Message}");
            }
        }
        #endregion

        #region Permissions
        // مقسَّمة إلى دالة مستقلة لكل وحدة (كانت سابقاً دالة واحدة بطول ~280 سطراً بأقسام #region
        // متداخلة) — كل دالة الآن تطابق تماماً محتوى قسمها القديم سطراً بسطر، فلا تغيير في أي
        // ربط عنصر↔صلاحية، فقط إعادة تنظيم لتسهيل القراءة/المراجعة لكل وحدة على حدة.
        public void SetButtonEnabled()
        {
            ApplyMainPermissions();
            ApplyProjectsMgtPermissions();
            ApplyBOQMgtPermissions();
            ApplyBudgetMgtPermissions();
            ApplyDocumentControlPermissions();
            ApplyPlanningMgtPermissions();
            ApplyCostControlPermissions();
            ApplySubcontractorsPermissions();
            ApplyPaymentRequestPermissions();
            ApplyProcurementPermissions();
            ApplyInventoryPermissions();
            ApplyWorkflowEnginePermissions();
            ApplyContractMgtPermissions();
            ApplyEDMSPermissions();
            ApplyCorrespondenceMgtPermissions();
            ApplyQualityMgtPermissions();
            ApplyHSEMgtPermissions();
            ApplySettingsPermissions();
        }

        private static bool HasPerm(string name) => Data.PermissionService.HasPermission(name);

        private void ApplyMainPermissions()
        {
            aceMain.Visible = HasPerm(PermNames.MainSection);
            aceDashboard.Enabled = HasPerm(PermNames.Dashboard);
        }

        private void ApplyProjectsMgtPermissions()
        {
            aceProjectsMgt.Visible = HasPerm(PermNames.ProjectsMgtSection);
            aceProjectType.Enabled = HasPerm(PermNames.ProjectType);
            aceProjectStatus.Enabled = HasPerm(PermNames.ProjectStatus);
            aceProjectSituation.Enabled = HasPerm(PermNames.ProjectSituation);
            aceProjectDetails.Enabled = HasPerm(PermNames.ProjectDetails);
            aceBOQ.Enabled = HasPerm(PermNames.BOQ);
            aceWBS.Enabled = HasPerm(PermNames.WBS);
            aceProjectsList.Enabled = HasPerm(PermNames.ProjectsList);
            aceProjectTeam.Enabled = HasPerm(PermNames.ProjectTeam);
            aceProjectSchedule.Enabled = HasPerm(PermNames.ProjectSchedule);
            aceProjectBudgetSummary.Enabled = HasPerm(PermNames.ProjectBudgetSummary);
            aceProjectDocuments.Enabled = HasPerm(PermNames.ProjectDocuments);
            aceProjectRisks.Enabled = HasPerm(PermNames.ProjectRisks);
            aceProjectIssues.Enabled = HasPerm(PermNames.ProjectIssues);
            aceProjectCorrespondence.Enabled = HasPerm(PermNames.ProjectCorrespondence);
            aceProjectMeetings.Enabled = HasPerm(PermNames.ProjectMeetings);
            aceProjectProgress.Enabled = HasPerm(PermNames.ProjectProgress);
            aceProjectCostControl.Enabled = HasPerm(PermNames.ProjectCostControl);
            aceProjectDashboard.Enabled = HasPerm(PermNames.ProjectDashboard);
            aceProjectCloseout.Enabled = HasPerm(PermNames.ProjectCloseout);

            // aceBOQList (BOQ Management group) is a legacy alias that opens the exact same
            // screen as aceBOQ above (both construct ucBOQList()). It had no permission gate of
            // its own, letting a user denied PermNames.BOQ reach the same screen through it.
            aceBOQList.Enabled = HasPerm(PermNames.BOQ);
        }

        private void ApplyBOQMgtPermissions()
        {
            aceBOQMgt.Visible = HasPerm(PermNames.BOQMgtSection);
            aceBOQExplorer.Enabled = HasPerm(PermNames.BOQExplorer);
            aceBOQEditor.Enabled = HasPerm(PermNames.BOQEditor);
            aceBOQComparison.Enabled = HasPerm(PermNames.BOQComparison);
            aceBOQRevisionManagement.Enabled = HasPerm(PermNames.BOQRevisionManagement);
            aceBOQAnalysis.Enabled = HasPerm(PermNames.BOQAnalysis);
            aceBOQApproval.Enabled = HasPerm(PermNames.BOQApproval);
            aceBOQReports.Enabled = HasPerm(PermNames.BOQReports);
        }

        private void ApplyBudgetMgtPermissions()
        {
            aceBudgetMgtGroup.Visible = HasPerm(PermNames.BudgetMgtSection);
            aceBudgetDashboardNav.Enabled = HasPerm(PermNames.BudgetMgtDashboard);
            aceBudgetListNav.Enabled = HasPerm(PermNames.BudgetMgtList);
            aceBudgetEditorNav.Enabled = HasPerm(PermNames.BudgetMgtEditor);
            aceCBSNav.Enabled = HasPerm(PermNames.BudgetMgtCBS);
            aceBudgetImportWizardNav.Enabled = HasPerm(PermNames.BudgetMgtImportWizard);
            aceBudgetRevisionNav.Enabled = HasPerm(PermNames.BudgetMgtRevision);
            aceCashFlowForecastNav.Enabled = HasPerm(PermNames.BudgetMgtCashFlowForecast);
            aceBudgetVsActualNav.Enabled = HasPerm(PermNames.BudgetMgtVsActual);
            aceCostForecastNav.Enabled = HasPerm(PermNames.BudgetMgtCostForecast);
            aceBudgetApprovalWorkflowNav.Enabled = HasPerm(PermNames.BudgetMgtApprovalWorkflow);
            aceBudgetReportsNav.Enabled = HasPerm(PermNames.BudgetMgtReports);
        }

        private void ApplyDocumentControlPermissions()
        {
            aceDocumentsMgt.Visible = HasPerm(PermNames.DocumentsMgtSection);
            aceInspectionRequest.Enabled = HasPerm(PermNames.InspectionRequest);
            aceMaterialInspectionRequest.Enabled = HasPerm(PermNames.MaterialInspectionRequest);
            aceMaterialApprovalRequest.Enabled = HasPerm(PermNames.MaterialApprovalRequest);
            aceDrawingsApprovalRequest.Enabled = HasPerm(PermNames.DrawingsApprovalRequest);
            aceDocumentSubmittal.Enabled = HasPerm(PermNames.DocumentSubmittal);
            aceDailyReport.Enabled = HasPerm(PermNames.DailyReport);
            aceConcretePourRequest.Enabled = HasPerm(PermNames.ConcretePourRequest);
            aceConcreteTestResult.Enabled = HasPerm(PermNames.ConcreteTestResult);
        }

        private void ApplyPlanningMgtPermissions()
        {
            acePlanningMgtGroup.Visible = HasPerm(PermNames.PlanningMgtSection);
            acePlanningDashboardNav.Enabled = HasPerm(PermNames.PlanningDashboard);
            aceScheduleListNav.Enabled = HasPerm(PermNames.ScheduleList);
            aceScheduleExplorerNav.Enabled = HasPerm(PermNames.ScheduleExplorer);
            aceActivityEditorNav.Enabled = HasPerm(PermNames.ActivityEditor);
            aceBaselineManagementNav.Enabled = HasPerm(PermNames.BaselineManagement);
            aceProgressUpdateNav.Enabled = HasPerm(PermNames.ProgressUpdate);
            aceLookAheadPlanningNav.Enabled = HasPerm(PermNames.LookAheadPlanning);
            aceMilestonesNav.Enabled = HasPerm(PermNames.Milestones);
            aceResourcePlanningNav.Enabled = HasPerm(PermNames.ResourcePlanning);
            aceDelayAnalysisNav.Enabled = HasPerm(PermNames.DelayAnalysis);
            aceScheduleComparisonNav.Enabled = HasPerm(PermNames.ScheduleComparison);
            acePlanningImportExportWizardNav.Enabled = HasPerm(PermNames.PlanningImportExportWizard);
            acePlanningReportsNav.Enabled = HasPerm(PermNames.PlanningReports);
        }

        private void ApplyCostControlPermissions()
        {
            aceCostControlMgt.Visible = HasPerm(PermNames.CostControlMgtSection);
            aceCostControlDashboardNav.Enabled = HasPerm(PermNames.CostControlDashboard);
            aceCostBreakdownStructureNav.Enabled = HasPerm(PermNames.CostBreakdownStructure);
            aceCostCommitmentsNav.Enabled = HasPerm(PermNames.CostCommitments);
            aceBudgetVsCommitmentNav.Enabled = HasPerm(PermNames.BudgetVsCommitment);
            aceCostCtrlBudgetVsActualNav.Enabled = HasPerm(PermNames.BudgetVsActual);
            aceEarnedValueManagementNav.Enabled = HasPerm(PermNames.EarnedValueManagement);
            aceCostCtrlForecastNav.Enabled = HasPerm(PermNames.CostForecast);
            aceCashFlowAnalysisNav.Enabled = HasPerm(PermNames.CashFlowAnalysis);
            aceOwnerIPCManagementNav.Enabled = HasPerm(PermNames.OwnerIPCManagement);
            aceSubcontractorIPCManagementNav.Enabled = HasPerm(PermNames.SubcontractorIPCManagement);
            aceCostVarianceAnalysisNav.Enabled = HasPerm(PermNames.CostVarianceAnalysis);
            aceCostTrendAnalysisNav.Enabled = HasPerm(PermNames.CostTrendAnalysis);
            aceCostForecastScenariosNav.Enabled = HasPerm(PermNames.CostForecastScenarios);
            aceExecutiveCostReviewNav.Enabled = HasPerm(PermNames.ExecutiveCostReview);
            aceCostReportsNav.Enabled = HasPerm(PermNames.CostReports);

            // aceBudget/aceCBS are legacy aliases that open the exact same screens as
            // aceBudgetDashboardNav/aceCostBreakdownStructureNav (ucBudgetDashboard /
            // ucCostBreakdownStructure). They were missing their own permission gate, letting a
            // user denied the specific permission reach the same screen through the alias.
            // Reusing the same PermNames as the equivalent items keeps both toggled together.
            aceBudget.Enabled = HasPerm(PermNames.Budget);
            aceCBS.Enabled = HasPerm(PermNames.CostBreakdownStructure);
        }

        private void ApplySubcontractorsPermissions()
        {
            aceSubcontractorMgt.Visible = HasPerm(PermNames.SubcontractorMgtSection);
            aceSubcontractorList.Enabled = HasPerm(PermNames.SubcontractorList);
            aceSubcontractorContract.Enabled = HasPerm(PermNames.SubcontractorContract);
            aceSubcontractorInvoice.Enabled = HasPerm(PermNames.SubcontractorInvoice);
            aceSubcontractorReport.Enabled = HasPerm(PermNames.SubcontractorReport);
        }

        private void ApplyPaymentRequestPermissions()
        {
            acePaymentRequestMgt.Visible = HasPerm(PermNames.PaymentRequestMgtSection);
            aceFinancialRequest.Enabled = HasPerm(PermNames.FinancialRequest);
            acePettyCash.Enabled = HasPerm(PermNames.PettyCash);
            aceCasualWorkerRequest.Enabled = HasPerm(PermNames.CasualWorkerRequest);
            aceEquipmentRentRequest.Enabled = HasPerm(PermNames.EquipmentRentRequest);
            aceEquipmentRentPayment.Enabled = HasPerm(PermNames.EquipmentRentPayment);
            aceCasualWorkerPayment.Enabled = HasPerm(PermNames.CasualWorkerPayment);
        }

        private void ApplyProcurementPermissions()
        {
            acePurchaseMgt.Visible = HasPerm(PermNames.PurchaseMgtSection);
            aceProcurementDashboard.Enabled = HasPerm(PermNames.ProcurementDashboard);
            accordionControlElement2.Enabled = HasPerm(PermNames.ProcurementGuide);
            accordionControlElement3.Enabled = HasPerm(PermNames.ProcurementWorkbench);
            accordionControlElement4.Enabled = HasPerm(PermNames.TechnicalEvaluation);
            accordionControlElement5.Enabled = HasPerm(PermNames.QuotationComparison);
            accordionControlElement6.Enabled = HasPerm(PermNames.Negotiation);
            accordionControlElement7.Enabled = HasPerm(PermNames.AwardRecommendation);
            accordionControlElement8.Enabled = HasPerm(PermNames.ApprovalsInbox);
            aceStakeholder.Enabled = HasPerm(PermNames.Stakeholder);
            aceRFQ.Enabled = HasPerm(PermNames.RFQ);
            acePriceQuotation.Enabled = HasPerm(PermNames.PriceQuotation);
            acePurchaseRequest.Enabled = HasPerm(PermNames.PurchaseRequest);
            acePurchaseOrder.Enabled = HasPerm(PermNames.PurchaseOrder);
            acePOAmendment.Enabled = HasPerm(PermNames.POAmendment);
            acePurchaseReports.Enabled = HasPerm(PermNames.PurchaseReports);
            aceDepartments.Enabled = HasPerm(PermNames.Departments);
            aceDisciplines.Enabled = HasPerm(PermNames.Disciplines);
        }

        private void ApplyInventoryPermissions()
        {
            aceInventoryMgt.Visible = HasPerm(PermNames.InventoryMgtSection);
            aceStores.Enabled = HasPerm(PermNames.Stores);
            ascItems.Enabled = HasPerm(PermNames.Items);
            aceMaterialReceiveVoucher.Enabled = HasPerm(PermNames.MaterialReceiveVoucher);
            aceMaterialIssuedVoucher.Enabled = HasPerm(PermNames.MaterialIssuedVoucher);
            aceMaterialTrasfare.Enabled = HasPerm(PermNames.MaterialTrasfare);
            acePurchaseReturn.Enabled = HasPerm(PermNames.PurchaseReturn);
            aceMaterialIssueReturn.Enabled = HasPerm(PermNames.MaterialIssueReturn);
            aceOpeningBalance.Enabled = HasPerm(PermNames.OpeningBalance);
            aceMaterialStocking.Enabled = HasPerm(PermNames.MaterialStocking);
            aceInventoryReports.Enabled = HasPerm(PermNames.InventoryReports);
        }

        private void ApplyWorkflowEnginePermissions()
        {
            aceWorkflowMgt.Visible = HasPerm(PermNames.WorkflowEngineSection);
            aceMyWorkflowTasks.Enabled = HasPerm(PermNames.MyWorkflowTasks);
            aceWorkflowDefinitions.Enabled = HasPerm(PermNames.WorkflowDefinitions);
            aceApprovalMatrix.Enabled = HasPerm(PermNames.ApprovalMatrix);
        }

        private void ApplyContractMgtPermissions()
        {
            aceContractMgtGroup.Visible = HasPerm(PermNames.ContractMgtSection);
            aceContractDashboardNav.Enabled = HasPerm(PermNames.ContractDashboard);
            aceContractRegisterNav.Enabled = HasPerm(PermNames.ContractRegister);
            aceContractDetailsNav.Enabled = HasPerm(PermNames.ContractDetails);
            aceContractObligationsNav.Enabled = HasPerm(PermNames.ContractObligations);
            aceContractCorrespondenceNav.Enabled = HasPerm(PermNames.ContractCorrespondence);
            aceVariationOrdersNav.Enabled = HasPerm(PermNames.VariationOrders);
            aceContractClaimsNav.Enabled = HasPerm(PermNames.ContractClaims);
            aceExtensionOfTimeNav.Enabled = HasPerm(PermNames.ExtensionOfTime);
            aceSecuritiesGuaranteesNav.Enabled = HasPerm(PermNames.SecuritiesGuarantees);
            acePaymentCertificatesNav.Enabled = HasPerm(PermNames.PaymentCertificates);
            aceRetentionManagementNav.Enabled = HasPerm(PermNames.RetentionManagement);
            aceContractAmendmentsNav.Enabled = HasPerm(PermNames.ContractAmendments);
            aceContractRiskRegisterNav.Enabled = HasPerm(PermNames.ContractRiskRegister);
            aceContractCloseoutNav.Enabled = HasPerm(PermNames.ContractCloseout);
            aceContractReportsNav.Enabled = HasPerm(PermNames.ContractReports);
        }

        private void ApplyEDMSPermissions()
        {
            aceEDMSGroup.Visible = HasPerm(PermNames.EDMSSection);
            aceEDMSDashboardNav.Enabled = HasPerm(PermNames.EDMSDashboard);
            aceEDMSDocumentRegisterNav.Enabled = HasPerm(PermNames.EDMSDocumentRegister);
            aceEDMSDocumentDetailsNav.Enabled = HasPerm(PermNames.EDMSDocumentDetails);
            aceEDMSDrawingRegisterNav.Enabled = HasPerm(PermNames.EDMSDrawingRegister);
            aceEDMSMaterialSubmittalsNav.Enabled = HasPerm(PermNames.EDMSMaterialSubmittals);
            aceEDMSRFIRegisterNav.Enabled = HasPerm(PermNames.EDMSRFIRegister);
            aceEDMSTechnicalQueriesNav.Enabled = HasPerm(PermNames.EDMSTechnicalQueries);
            aceEDMSTransmittalMgtNav.Enabled = HasPerm(PermNames.EDMSTransmittalMgt);
            aceEDMSIncomingCorrespondenceNav.Enabled = HasPerm(PermNames.EDMSIncomingCorrespondence);
            aceEDMSOutgoingCorrespondenceNav.Enabled = HasPerm(PermNames.EDMSOutgoingCorrespondence);
            aceEDMSReviewApprovalNav.Enabled = HasPerm(PermNames.EDMSReviewApproval);
            aceEDMSVersionControlNav.Enabled = HasPerm(PermNames.EDMSVersionControl);
            aceEDMSDistributionMatrixNav.Enabled = HasPerm(PermNames.EDMSDistributionMatrix);
            aceEDMSArchiveTreeNav.Enabled = HasPerm(PermNames.EDMSArchiveTree);
            aceEDMSReportsCenterNav.Enabled = HasPerm(PermNames.EDMSReportsCenter);
        }

        private void ApplyCorrespondenceMgtPermissions()
        {
            aceCorrespondenceMgtGroup.Visible = HasPerm(PermNames.CorrespondenceMgtSection);
            aceCorrespondenceDashboardNav.Enabled = HasPerm(PermNames.CorrespondenceDashboard);
            aceCorrespondenceInboxNav.Enabled = HasPerm(PermNames.CorrespondenceInbox);
            aceCorrespondenceOutboxNav.Enabled = HasPerm(PermNames.CorrespondenceOutbox);
            aceInternalMemoRegisterNav.Enabled = HasPerm(PermNames.InternalMemoRegister);
            aceCircularManagementNav.Enabled = HasPerm(PermNames.CircularManagement);
            aceMeetingMinutesNav.Enabled = HasPerm(PermNames.MeetingMinutes);
            aceCorrespondenceDetailsNav.Enabled = HasPerm(PermNames.CorrespondenceDetails);
            aceEmailIntegrationCenterNav.Enabled = HasPerm(PermNames.EmailIntegrationCenter);
            aceDistributionListsNav.Enabled = HasPerm(PermNames.CorrespondenceDistributionLists);
            aceActionTrackingNav.Enabled = HasPerm(PermNames.CorrespondenceActionTracking);
            aceAcknowledgementTrackingNav.Enabled = HasPerm(PermNames.CorrespondenceAcknowledgement);
            aceCorrespondenceWorkflowNav.Enabled = HasPerm(PermNames.CorrespondenceWorkflow);
            aceCorrespondenceArchiveSearchNav.Enabled = HasPerm(PermNames.CorrespondenceArchiveSearch);
            aceCorrespondenceReportsNav.Enabled = HasPerm(PermNames.CorrespondenceReports);
            aceMailboxSyncMonitorNav.Enabled = HasPerm(PermNames.MailboxSyncMonitor);
        }

        private void ApplyQualityMgtPermissions()
        {
            aceQualityMgtGroup.Visible = HasPerm(PermNames.QualityMgtSection);
            aceQualityDashboardNav.Enabled = HasPerm(PermNames.QualityDashboard);
            aceInspectionRequestRegisterNav.Enabled = HasPerm(PermNames.InspectionRequestRegister);
            aceInspectionFormNav.Enabled = HasPerm(PermNames.InspectionForm);
            aceInspectionTestPlanNav.Enabled = HasPerm(PermNames.InspectionTestPlan);
            aceChecklistLibraryNav.Enabled = HasPerm(PermNames.ChecklistLibrary);
            aceMaterialInspectionNav.Enabled = HasPerm(PermNames.MaterialInspection);
            aceSiteInspectionNav.Enabled = HasPerm(PermNames.SiteInspection);
            aceNCRRegisterNav.Enabled = HasPerm(PermNames.NCRRegister);
            aceNCRDetailsNav.Enabled = HasPerm(PermNames.NCRDetails);
            aceCAPAManagementNav.Enabled = HasPerm(PermNames.CAPAManagement);
            acePunchListManagementNav.Enabled = HasPerm(PermNames.PunchListManagement);
            aceSnagListNav.Enabled = HasPerm(PermNames.SnagList);
            aceHandoverInspectionNav.Enabled = HasPerm(PermNames.HandoverInspection);
            aceDefectLiabilityNav.Enabled = HasPerm(PermNames.DefectLiability);
            aceQualityReportsNav.Enabled = HasPerm(PermNames.QualityReports);
        }

        private void ApplyHSEMgtPermissions()
        {
            aceHSEMgtGroup.Visible = HasPerm(PermNames.HSEMgtSection);
            aceHSEDashboardNav.Enabled = HasPerm(PermNames.HSEDashboard);
            aceIncidentRegisterNav.Enabled = HasPerm(PermNames.IncidentRegister);
            aceIncidentInvestigationNav.Enabled = HasPerm(PermNames.IncidentInvestigation);
            aceNearMissRegisterNav.Enabled = HasPerm(PermNames.NearMissRegister);
            aceHazardRegisterNav.Enabled = HasPerm(PermNames.HazardRegister);
            aceRiskAssessmentNav.Enabled = HasPerm(PermNames.RiskAssessment);
            acePermitToWorkNav.Enabled = HasPerm(PermNames.PermitToWork);
            aceSafetyInspectionNav.Enabled = HasPerm(PermNames.SafetyInspection);
            aceToolboxTalkNav.Enabled = HasPerm(PermNames.ToolboxTalk);
            aceSafetyTrainingNav.Enabled = HasPerm(PermNames.SafetyTraining);
            acePPEManagementNav.Enabled = HasPerm(PermNames.PPEManagement);
            aceEquipmentInspectionNav.Enabled = HasPerm(PermNames.EquipmentInspection);
            aceEnvironmentalMonitoringNav.Enabled = HasPerm(PermNames.EnvironmentalMonitoring);
            aceEmergencyPreparednessNav.Enabled = HasPerm(PermNames.EmergencyPreparedness);
            aceHSEReportsNav.Enabled = HasPerm(PermNames.HSEReports);
        }

        private void ApplySettingsPermissions()
        {
            ribbonPage1.Visible = HasPerm(PermNames.SettingsSection);
            bbiUsersMgt.Enabled = HasPerm(PermNames.UsersMgt);
            bbiPermissionsMgt.Enabled = HasPerm(PermNames.PermissionsMgt);
            bbiConnection.Enabled = HasPerm(PermNames.Connection);
            bbiBackup.Enabled = HasPerm(PermNames.Backup);
            bbiRestore.Enabled = HasPerm(PermNames.Restore);
            bbiSystemSettings.Enabled = SystemSettingsPermissions.CanManage(Data.DataContext.Shared);
        }
        #endregion

        #region Navigation
        /// <param name="force">
        /// Bypasses the ElementStyle.Item guard below. Needed for the initial startup call,
        /// since aceMain is a group header (not a clickable leaf) and would otherwise never open.
        /// </param>
        //private void ShowModule(AccordionControlElement element, bool force = false)
        //{
        //    if (_isSyncing || element == null || (!force && element.Style != ElementStyle.Item)) return;

        //    // Show Overlay Form on the main navigation frame for a modern look
        //    // We check if navigationFrame is visible to avoid InvalidOperationException during startup
        //    IOverlaySplashScreenHandle handle = null;
        //    if (navigationFrame.Visible)
        //        handle = SplashScreenManager.ShowOverlayForm(navigationFrame);

        //    _isSyncing = true;
        //    try
        //    {
        //        // Find existing page
        //        var page = navigationFrame.Pages.OfType<NavigationPage>().FirstOrDefault(p => p.Tag == element);
        //        if (page != null)
        //        {
        //            navigationFrame.SelectedPage = page;
        //            return;
        //        }

        //        Control userControl = GetControlForElement(element);
        //        if (userControl == null) return;

        //        // Create new page
        //        var newPage = new NavigationPage
        //        {
        //            Tag = element,
        //            Text = element.Text
        //        };
        //        userControl.Dock = DockStyle.Fill;
        //        newPage.Controls.Add(userControl);

        //        navigationFrame.Pages.Add(newPage);
        //        navigationFrame.SelectedPage = newPage;
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show($"حدث خطأ أثناء فتح الوحدة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        _isSyncing = false;
        //        // Close Overlay Form
        //        if (handle != null)
        //            SplashScreenManager.CloseOverlayForm(handle);
        //    }
        //}

        //private Control GetControlForElement(AccordionControlElement element)
        //{
        //    // Top-level modules: each owns its own internal tab/tile navigation.
        //    if (element == aceMain) return CreateDashboardControl();
        //    if (element == aceDocumentsMgt) return new ucDocumentsMgt();
        //    if (element == acePurchaseMgt) return new ucProcurementMgt();
        //    if (element == aceInventoryMgt) return new ucInventoryMgt();
        //    if (element == aceWorkflowMgt) return new ucWorkflowMgt();

        //    // Leaf screens under aceProjectsMgt/aceCostControlMgt that are implemented, even
        //    // though their parent group's own container control (ucProjectMgt/ucCostControlMgt)
        //    // is an unfinished scaffold and is intentionally not wired in above.
        //    if (element == aceProjectDetails) return new ucProjectsMgt();
        //    if (element == aceBudget) return new ucBudgets();

        //    return CreatePlaceholderControl(element.Text);
        //}
        #endregion

        #region Event Handlers
        //private void navigationAccordion_ElementClick(object sender, ElementClickEventArgs e)
        //{
        //    ShowModule(e.Element);
        //}

        private void XtraFormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogLogout();

            foreach (var page in navigationFrame.Pages.OfType<NavigationPage>())
            {
                foreach (Control ctrl in page.Controls)
                {
                    if (ctrl is XtraUserControl userControl)
                    {
                        var confirmMethod = userControl.GetType().GetMethod("ConfirmClose");
                        if (confirmMethod != null)
                        {
                            bool canClose = (bool)(confirmMethod.Invoke(userControl, null) ?? true);
                            if (!canClose)
                            {
                                e.Cancel = true;
                                navigationFrame.SelectedPage = page;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void CboProject_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProject.EditValue is ProjectComboItem item)
            {
                Session.SelectedProjectId = item.Id;
                Session.SelectedProjectName = item.Id.HasValue ? item.DisplayName : null;
                UpdateStatusInfo();

                // Reload all open navigation pages that support project-aware refresh
                foreach (var page in navigationFrame.Pages.OfType<NavigationPage>())
                {
                    foreach (Control ctrl in page.Controls)
                    {
                        var refreshMethod = ctrl.GetType().GetMethod("OnProjectChanged",
                            System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.Public |
                            System.Reflection.BindingFlags.NonPublic);
                        refreshMethod?.Invoke(ctrl, null);
                    }
                }
            }
        }

        private void bbiUsersMgt_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmUsersMgt())
            {
                frm.ShowDialog();
            }
        }

        private void bbiPermissionsMgt_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmPermissionsAddEdit())
            {
                frm.ShowDialog();
            }
        }

        private void bbiLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            if (XtraMessageBox.Show("هل أنت متأكد من تسجيل الخروج؟", "تأكيد تسجيل الخروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void bbiConnection_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmConnecting())
            {
                frm.ShowDialog();
            }
        }

        private void bbiBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmBackup())
            {
                frm.ShowDialog();
            }
        }

        private void bbiRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmRestore())
            {
                frm.ShowDialog();
            }
        }

        private void bbiSystemSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new SettingsForm())
            {
                frm.ShowDialog();
            }
        }
        #endregion

        #region UI Helpers
        private void UpdateStatusInfo()
        {
            if (Session.CurrentUser.Id > 0)
            {
                bsiUser.Caption = $":  {Session.CurrentUser.FullName}";
                bsiCompany.Caption = $":  {Session.CurrentUser.Company}";
                bsiServer.Caption = $":  {Data.DBSetting.ActiveProfile?.Server}";
            }
        }

        private void LogLogout()
        {
            if (Session.CurrentUser.Id > 0)
            {
                try
                {
                    DC.ActionLogs.Add(new ActionLogs
                    {
                        UserID = Session.CurrentUser.Id,
                        UserName = Session.CurrentUser.UserName ?? string.Empty,
                        ActionType = "خروج",
                        ActionLocation = "الرئيسية",
                        ActionDate = DateTime.Now,
                        MachineName = Session.Machine
                    });
                }
                catch { }
            }
        }

            //private Control CreateDashboardControl()
        //{
        //    var container = new XtraUserControl { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke };
        //    var label = new LabelControl
        //    {
        //        Text = "مرحباً بك في نظام إتمام لإدارة المشاريع",
        //        Dock = DockStyle.Fill,
        //        AutoSizeMode = LabelAutoSizeMode.None,
        //        Appearance = {
        //            TextOptions = { HAlignment = HorzAlignment.Center, VAlignment = VertAlignment.Center },
        //            Font = new Font("Cairo", 14, FontStyle.Bold)
        //        }
        //    };
        //    container.Controls.Add(label);
        //    return container;
        //}

        //private XtraUserControl CreatePlaceholderControl(string text)
        //{
        //    var container = new XtraUserControl { Dock = DockStyle.Fill, Text = text };
        //    var label = new LabelControl
        //    {
        //        Text = $"برنامج {text} قيد التطوير حالياً",
        //        Dock = DockStyle.Fill,
        //        AutoSizeMode = LabelAutoSizeMode.None,
        //        Appearance = {
        //            TextOptions = { HAlignment = HorzAlignment.Center, VAlignment = VertAlignment.Center },
        //            Font = new Font("Cairo", 12)
        //        }
        //    };
        //    container.Controls.Add(label);
        //    return container;
        //}
        #endregion

        private void WireEvents()
        {
            aceDashboard.Click += (s, e) => OpenTab(aceDashboard.Text, "Dashboard", "Dashboard", () => new ucDashboard());

            #region Projects Management
            //aceProjectType.Click += (s, e) => OpenTab(aceProjectType.Text, "ProjectType", "ProjectType", () => new ucProjectType());
            //aceProjectStatus.Click += (s, e) => OpenTab(aceProjectStatus.Text, "ProjectStatus", "ProjectStatus", () => new ucProjectStatus());
            //aceProjectSituation.Click += (s, e) => OpenTab(aceProjectSituation.Text, "ProjectSituation", "ProjectSituation", () => new ucProjectSituation ());
            aceProjectsList.Click += (s, e) => OpenTab(aceProjectsList.Text, "ProjectsList", "ProjectsMgt", () => new ucProjectsList());
            aceProjectDetails.Click += (s, e) => OpenTab(aceProjectDetails.Text, "ProjectDetails", "ProjectDetails", () => new ucProjectDetails());
            aceBOQ.Click += (s, e) => OpenTab(aceBOQ.Text, "BOQ", "BOQ", () => new ucBOQList());
            //aceWBS.Click += (s, e) => OpenTab(aceWBS.Text, "WBS", "WBS", () => new ucWBS());
            aceProjectTeam.Click += (s, e) => OpenTab(aceProjectTeam.Text, "ProjectTeam", "Stakeholder", () => new ucProjectTeam());
            aceProjectSchedule.Click += (s, e) => OpenTab(aceProjectSchedule.Text, "ProjectSchedule", "Activities", () => new ucProjectSchedule());
            aceProjectBudgetSummary.Click += (s, e) => OpenTab(aceProjectBudgetSummary.Text, "ProjectBudgetSummary", "Budget", () => new ucProjectBudgetSummary());
            aceProjectDocuments.Click += (s, e) => OpenTab(aceProjectDocuments.Text, "ProjectDocuments", "DocumentsMgt", () => new ucProjectDocuments());
            aceProjectRisks.Click += (s, e) => OpenTab(aceProjectRisks.Text, "ProjectRisks", "ProjectsMgt", () => new ucProjectRisks());
            aceProjectIssues.Click += (s, e) => OpenTab(aceProjectIssues.Text, "ProjectIssues", "ProjectsMgt", () => new ucProjectIssues());
            aceProjectCorrespondence.Click += (s, e) => OpenTab(aceProjectCorrespondence.Text, "ProjectCorrespondence", "ProjectsMgt", () => new ucProjectCorrespondence());
            aceProjectMeetings.Click += (s, e) => OpenTab(aceProjectMeetings.Text, "ProjectMeetings", "ProjectsMgt", () => new ucProjectMeetings());
            aceProjectProgress.Click += (s, e) => OpenTab(aceProjectProgress.Text, "ProjectProgress", "ProjectsMgt", () => new ucProjectProgress());
            aceProjectCostControl.Click += (s, e) => OpenTab(aceProjectCostControl.Text, "ProjectCostControl", "ProjectsMgt", () => new ucProjectCostControl());
            aceProjectDashboard.Click += (s, e) => OpenTab(aceProjectDashboard.Text, "ProjectDashboard", "ProjectsMgt", () => new ucProjectDashboard());
            #endregion

            #region BOQ Management
            aceBOQList.Click += (s, e) => OpenTab(aceBOQList.Text, "BOQList", "BOQList", () => new ucBOQList());
            aceBOQExplorer.Click += (s, e) => OpenTab(aceBOQExplorer.Text, "BOQExplorer", "BOQExplorer", () => new ucBOQExplorer());
            aceBOQEditor.Click += (s, e) => OpenTab(aceBOQEditor.Text, "BOQEditor", "BOQEditor", () => new ucBOQEditor());
            aceBOQComparison.Click += (s, e) => OpenTab(aceBOQComparison.Text, "BOQComparison", "BOQComparison", () => new ucBOQComparison());
            aceBOQRevisionManagement.Click += (s, e) => OpenTab(aceBOQRevisionManagement.Text, "BOQRevisionManagement", "BOQRevisionManagement", () => new ucBOQRevisionManagement());
            aceBOQAnalysis.Click += (s, e) => OpenTab(aceBOQAnalysis.Text, "BOQAnalysis", "BOQAnalysis", () => new ucBOQAnalysis());
            aceBOQApproval.Click += (s, e) => OpenTab(aceBOQApproval.Text, "BOQApproval", "BOQApproval", () => new ucBOQApproval());
            aceBOQReports.Click += (s, e) => OpenTab(aceBOQReports.Text, "BOQReports", "BOQReports", () => new ucBOQReports());
            aceProjectCloseout.Click += (s, e) =>
            {
                using var frm = new frmProjectCloseoutWizard();
                frm.ShowDialog(this);
            };
            #endregion

            #region Document Control
            aceInspectionRequest.Click += (s, e) => OpenTab(aceInspectionRequest.Text, "InspectionRequest", "InspectionRequest", () => new ucCIR());
            aceMaterialInspectionRequest.Click += (s, e) => OpenTab(aceMaterialInspectionRequest.Text, "MaterialInspectionRequest", "MaterialInspectionRequest", () => new ucMIR());
            aceMaterialApprovalRequest.Click += (s, e) => OpenTab(aceMaterialApprovalRequest.Text, "MaterialApprovalRequest", "MaterialApprovalRequest", () => new ucMIR());
            aceDrawingsApprovalRequest.Click += (s, e) => OpenTab(aceDrawingsApprovalRequest.Text, "DrawingsApprovalRequest", "DrawingsApprovalRequest", () => new ucDrawingsMgt());
            //aceDocumentSubmittal.Click += (s, e) => OpenTab(aceDocumentSubmittal.Text, "DocumentSubmittal", "DocumentSubmittal", () => new ucDocumentSubmittal());
            aceDailyReport.Click += (s, e) => OpenTab(aceDailyReport.Text, "DailyReport", "DailyReport", () => new ucDailyReports());
            //aceConcretePourRequest.Click += (s, e) => OpenTab(aceConcretePourRequest.Text, "ConcretePourRequest", "ConcretePourRequest", () => new ucConcretePourRequest());
            //aceConcreteTestResult.Click += (s, e) => OpenTab(aceConcreteTestResult.Text, "ConcreteTestResult", "ConcreteTestResult", () => new ucConcreteTestResult());
            #endregion

            #region Budget & Estimation Module
            aceBudgetDashboardNav.Click += (s, e) => OpenTab(aceBudgetDashboardNav.Text, "BudgetDashboard", "Budget", () => new ucBudgetDashboard());
            aceBudgetListNav.Click += (s, e) => OpenTab(aceBudgetListNav.Text, "BudgetList", "Budget", () => new ucBudgetList());
            aceBudgetEditorNav.Click += (s, e) => OpenTab(aceBudgetEditorNav.Text, "BudgetEditor", "Budget", () => new ucBudgetEditor());
            aceCBSNav.Click += (s, e) => OpenTab(aceCBSNav.Text, "CostBreakdownStructure", "Budget", () => new ucCostBreakdownStructure());
            aceBudgetImportWizardNav.Click += (s, e) =>
            {
                using var frm = new frmBudgetImportWizard();
                frm.ShowDialog(this);
            };
            aceBudgetRevisionNav.Click += (s, e) => OpenTab(aceBudgetRevisionNav.Text, "BudgetRevision", "Budget", () => new ucBudgetRevision());
            aceCashFlowForecastNav.Click += (s, e) => OpenTab(aceCashFlowForecastNav.Text, "CashFlowForecast", "Budget", () => new ucCashFlowForecast());
            aceBudgetVsActualNav.Click += (s, e) => OpenTab(aceBudgetVsActualNav.Text, "BudgetVsActual", "Budget", () => new ucBudgetVsActual());
            aceCostForecastNav.Click += (s, e) => OpenTab(aceCostForecastNav.Text, "CostForecast", "Budget", () => new ucCostForecast());
            aceBudgetApprovalWorkflowNav.Click += (s, e) => OpenTab(aceBudgetApprovalWorkflowNav.Text, "BudgetApprovalWorkflow", "Budget", () => new ucBudgetApprovalWorkflow());
            aceBudgetReportsNav.Click += (s, e) => OpenTab(aceBudgetReportsNav.Text, "BudgetReports", "Budget", () => new ucBudgetReports());

            // Legacy Cost Control items link to Budget & Estimation
            aceBudget.Click += (s, e) => OpenTab(aceBudget.Text, "BudgetDashboard", "Budget", () => new ucBudgetDashboard());
            aceCBS.Click += (s, e) => OpenTab(aceCBS.Text, "CostBreakdownStructure", "Budget", () => new ucCostBreakdownStructure());
            #endregion

            #region Planning Management
            acePlanningDashboardNav.Click += (s, e) => OpenTab(acePlanningDashboardNav.Text, "PlanningDashboard", "Activities", () => new ucPlanningDashboard());
            aceScheduleListNav.Click += (s, e) => OpenTab(aceScheduleListNav.Text, "ScheduleList", "Activities", () => new ucScheduleList());
            aceScheduleExplorerNav.Click += (s, e) => OpenTab(aceScheduleExplorerNav.Text, "ScheduleExplorer", "Activities", () => new ucScheduleExplorer());
            aceActivityEditorNav.Click += (s, e) => OpenTab(aceActivityEditorNav.Text, "ActivityEditor", "Activities", () => new ucActivityEditor());
            aceBaselineManagementNav.Click += (s, e) => OpenTab(aceBaselineManagementNav.Text, "BaselineManagement", "Activities", () => new ucBaselineManagement());
            aceProgressUpdateNav.Click += (s, e) => OpenTab(aceProgressUpdateNav.Text, "ProgressUpdate", "Activities", () => new ucProgressUpdate());
            aceLookAheadPlanningNav.Click += (s, e) => OpenTab(aceLookAheadPlanningNav.Text, "LookAheadPlanning", "Activities", () => new ucLookAheadPlanning());
            aceMilestonesNav.Click += (s, e) => OpenTab(aceMilestonesNav.Text, "Milestones", "Activities", () => new ucMilestones());
            aceResourcePlanningNav.Click += (s, e) => OpenTab(aceResourcePlanningNav.Text, "ResourcePlanning", "Activities", () => new ucResourcePlanning());
            aceDelayAnalysisNav.Click += (s, e) => OpenTab(aceDelayAnalysisNav.Text, "DelayAnalysis", "Activities", () => new ucDelayAnalysis());
            aceScheduleComparisonNav.Click += (s, e) => OpenTab(aceScheduleComparisonNav.Text, "ScheduleComparison", "Activities", () => new ucScheduleComparison());
            acePlanningImportExportWizardNav.Click += (s, e) =>
            {
                using var frm = new frmImportExportWizard();
                frm.ShowDialog(this);
            };
            acePlanningReportsNav.Click += (s, e) => OpenTab(acePlanningReportsNav.Text, "PlanningReports", "Activities", () => new ucPlanningReports());
            #endregion

            #region Contract Management
            aceContractDashboardNav.Click += (s, e) => OpenTab(aceContractDashboardNav.Text, "ContractDashboard", "ProjectsMgt", () => new ucContractDashboard());
            aceContractRegisterNav.Click += (s, e) => OpenTab(aceContractRegisterNav.Text, "ContractRegister", "ProjectsMgt", () => new ucContractRegister());
            aceContractDetailsNav.Click += (s, e) => OpenTab(aceContractDetailsNav.Text, "ContractDetails", "ProjectDetails", () => new ucContractDetails());
            aceContractObligationsNav.Click += (s, e) => OpenTab(aceContractObligationsNav.Text, "ContractObligations", "ProjectsMgt", () => new ucContractObligationsRegister());
            aceContractCorrespondenceNav.Click += (s, e) => OpenTab(aceContractCorrespondenceNav.Text, "ContractCorrespondence", "ProjectsMgt", () => new ucContractCorrespondence());
            aceVariationOrdersNav.Click += (s, e) => OpenTab(aceVariationOrdersNav.Text, "VariationOrders", "ProjectsMgt", () => new ucVariationOrderManagement());
            aceContractClaimsNav.Click += (s, e) => OpenTab(aceContractClaimsNav.Text, "ContractClaims", "ProjectsMgt", () => new ucClaimsManagement());
            aceExtensionOfTimeNav.Click += (s, e) => OpenTab(aceExtensionOfTimeNav.Text, "ExtensionOfTime", "Activities", () => new ucExtensionOfTime());
            aceSecuritiesGuaranteesNav.Click += (s, e) => OpenTab(aceSecuritiesGuaranteesNav.Text, "SecuritiesGuarantees", "ProjectsMgt", () => new ucSecuritiesAndGuarantees());
            acePaymentCertificatesNav.Click += (s, e) => OpenTab(acePaymentCertificatesNav.Text, "PaymentCertificates", "Budget", () => new ucPaymentCertificates());
            aceRetentionManagementNav.Click += (s, e) => OpenTab(aceRetentionManagementNav.Text, "RetentionManagement", "Budget", () => new ucRetentionManagement());
            aceContractAmendmentsNav.Click += (s, e) => OpenTab(aceContractAmendmentsNav.Text, "ContractAmendments", "ProjectsMgt", () => new ucContractAmendments());
            aceContractRiskRegisterNav.Click += (s, e) => OpenTab(aceContractRiskRegisterNav.Text, "ContractRiskRegister", "ProjectsMgt", () => new ucContractRiskRegister());
            aceContractCloseoutNav.Click += (s, e) =>
            {
                using var frm = new frmContractCloseoutWizard();
                frm.ShowDialog(this);
            };
            aceContractReportsNav.Click += (s, e) => OpenTab(aceContractReportsNav.Text, "ContractReports", "ProjectsMgt", () => new ucContractReports());
            #endregion

            #region Enterprise EDMS
            aceEDMSDashboardNav.Click += (s, e) => OpenTab(aceEDMSDashboardNav.Text, "EDMSDashboard", "DocumentsMgt", () => new ucEDMSDashboard());
            aceEDMSDocumentRegisterNav.Click += (s, e) => OpenTab(aceEDMSDocumentRegisterNav.Text, "EDMSDocumentRegister", "DocumentsMgt", () => new ucDocumentRegister());
            aceEDMSDocumentDetailsNav.Click += (s, e) => OpenTab(aceEDMSDocumentDetailsNav.Text, "EDMSDocumentDetails", "DocumentsMgt", () => new ucDocumentDetails());
            aceEDMSDrawingRegisterNav.Click += (s, e) => OpenTab(aceEDMSDrawingRegisterNav.Text, "EDMSDrawingRegister", "DocumentsMgt", () => new ucDrawingRegister());
            aceEDMSMaterialSubmittalsNav.Click += (s, e) => OpenTab(aceEDMSMaterialSubmittalsNav.Text, "EDMSMaterialSubmittals", "DocumentsMgt", () => new ucMaterialSubmittalRegister());
            aceEDMSRFIRegisterNav.Click += (s, e) => OpenTab(aceEDMSRFIRegisterNav.Text, "EDMSRFIRegister", "DocumentsMgt", () => new ucRFIRegister());
            aceEDMSTechnicalQueriesNav.Click += (s, e) => OpenTab(aceEDMSTechnicalQueriesNav.Text, "EDMSTechnicalQueries", "DocumentsMgt", () => new ucTechnicalQueryRegister());
            aceEDMSTransmittalMgtNav.Click += (s, e) => OpenTab(aceEDMSTransmittalMgtNav.Text, "EDMSTransmittalMgt", "DocumentsMgt", () => new ucTransmittalManagement());
            aceEDMSIncomingCorrespondenceNav.Click += (s, e) => OpenTab(aceEDMSIncomingCorrespondenceNav.Text, "EDMSIncomingCorrespondence", "DocumentsMgt", () => new ucIncomingCorrespondence());
            aceEDMSOutgoingCorrespondenceNav.Click += (s, e) => OpenTab(aceEDMSOutgoingCorrespondenceNav.Text, "EDMSOutgoingCorrespondence", "DocumentsMgt", () => new ucOutgoingCorrespondence());
            aceEDMSReviewApprovalNav.Click += (s, e) => OpenTab(aceEDMSReviewApprovalNav.Text, "EDMSReviewApproval", "DocumentsMgt", () => new ucDocumentReviewApproval());
            aceEDMSVersionControlNav.Click += (s, e) => OpenTab(aceEDMSVersionControlNav.Text, "EDMSVersionControl", "DocumentsMgt", () => new ucVersionControl());
            aceEDMSDistributionMatrixNav.Click += (s, e) => OpenTab(aceEDMSDistributionMatrixNav.Text, "EDMSDistributionMatrix", "DocumentsMgt", () => new ucDistributionMatrix());
            aceEDMSArchiveTreeNav.Click += (s, e) => OpenTab(aceEDMSArchiveTreeNav.Text, "EDMSArchiveTree", "DocumentsMgt", () => new ucDocumentArchive());
            aceEDMSReportsCenterNav.Click += (s, e) => OpenTab(aceEDMSReportsCenterNav.Text, "EDMSReportsCenter", "DocumentsMgt", () => new ucEDMSReports());
            #endregion

            #region Enterprise Correspondence Management
            aceCorrespondenceDashboardNav.Click += (s, e) => OpenTab(aceCorrespondenceDashboardNav.Text, "CorrespondenceDashboard", "DocumentsMgt", () => new ucCorrespondenceDashboard());
            aceCorrespondenceInboxNav.Click += (s, e) => OpenTab(aceCorrespondenceInboxNav.Text, "CorrespondenceInbox", "DocumentsMgt", () => new ucCorrespondenceInbox());
            aceCorrespondenceOutboxNav.Click += (s, e) => OpenTab(aceCorrespondenceOutboxNav.Text, "CorrespondenceOutbox", "DocumentsMgt", () => new ucCorrespondenceOutbox());
            aceInternalMemoRegisterNav.Click += (s, e) => OpenTab(aceInternalMemoRegisterNav.Text, "InternalMemoRegister", "DocumentsMgt", () => new ucInternalMemoRegister());
            aceCircularManagementNav.Click += (s, e) => OpenTab(aceCircularManagementNav.Text, "CircularManagement", "DocumentsMgt", () => new ucCircularManagement());
            aceMeetingMinutesNav.Click += (s, e) => OpenTab(aceMeetingMinutesNav.Text, "MeetingMinutes", "DocumentsMgt", () => new ucMeetingMinutes());
            aceCorrespondenceDetailsNav.Click += (s, e) => OpenTab(aceCorrespondenceDetailsNav.Text, "CorrespondenceDetails", "DocumentsMgt", () => new ucCorrespondenceDetails());
            aceEmailIntegrationCenterNav.Click += (s, e) => OpenTab(aceEmailIntegrationCenterNav.Text, "EmailIntegrationCenter", "DocumentsMgt", () => new ucEmailIntegrationCenter());
            aceDistributionListsNav.Click += (s, e) => OpenTab(aceDistributionListsNav.Text, "DistributionLists", "DocumentsMgt", () => new ucDistributionLists());
            aceActionTrackingNav.Click += (s, e) => OpenTab(aceActionTrackingNav.Text, "ActionTracking", "DocumentsMgt", () => new ucActionTracking());
            aceAcknowledgementTrackingNav.Click += (s, e) => OpenTab(aceAcknowledgementTrackingNav.Text, "AcknowledgementTracking", "DocumentsMgt", () => new ucAcknowledgementTracking());
            aceCorrespondenceWorkflowNav.Click += (s, e) => OpenTab(aceCorrespondenceWorkflowNav.Text, "CorrespondenceWorkflow", "DocumentsMgt", () => new ucCorrespondenceWorkflow());
            aceCorrespondenceArchiveSearchNav.Click += (s, e) => OpenTab(aceCorrespondenceArchiveSearchNav.Text, "CorrespondenceArchiveSearch", "DocumentsMgt", () => new ucCorrespondenceArchiveSearch());
            aceCorrespondenceReportsNav.Click += (s, e) => OpenTab(aceCorrespondenceReportsNav.Text, "CorrespondenceReports", "DocumentsMgt", () => new ucCorrespondenceReports());
            aceMailboxSyncMonitorNav.Click += (s, e) => OpenTab(aceMailboxSyncMonitorNav.Text, "MailboxSyncMonitor", "DocumentsMgt", () => new ucMailboxSyncMonitor());
            #endregion

            #region Enterprise Quality Management (QMS)
            aceQualityDashboardNav.Click += (s, e) => OpenTab(aceQualityDashboardNav.Text, "QualityDashboard", "InspectionRequest", () => new ucQualityDashboard());
            aceInspectionRequestRegisterNav.Click += (s, e) => OpenTab(aceInspectionRequestRegisterNav.Text, "InspectionRequestRegister", "InspectionRequest", () => new ucInspectionRequestRegister());
            aceInspectionFormNav.Click += (s, e) => OpenTab(aceInspectionFormNav.Text, "InspectionForm", "InspectionRequest", () => new ucInspectionForm());
            aceInspectionTestPlanNav.Click += (s, e) => OpenTab(aceInspectionTestPlanNav.Text, "InspectionTestPlan", "InspectionRequest", () => new ucInspectionTestPlan());
            aceChecklistLibraryNav.Click += (s, e) => OpenTab(aceChecklistLibraryNav.Text, "ChecklistLibrary", "InspectionRequest", () => new ucChecklistLibrary());
            aceMaterialInspectionNav.Click += (s, e) => OpenTab(aceMaterialInspectionNav.Text, "MaterialInspection", "MaterialInspectionRequest", () => new ucMaterialInspection());
            aceSiteInspectionNav.Click += (s, e) => OpenTab(aceSiteInspectionNav.Text, "SiteInspection", "InspectionRequest", () => new ucSiteInspection());
            aceNCRRegisterNav.Click += (s, e) => OpenTab(aceNCRRegisterNav.Text, "NCRRegister", "InspectionRequest", () => new ucNCRRegister());
            aceNCRDetailsNav.Click += (s, e) => OpenTab(aceNCRDetailsNav.Text, "NCRDetails", "InspectionRequest", () => new ucNCRDetails());
            aceCAPAManagementNav.Click += (s, e) => OpenTab(aceCAPAManagementNav.Text, "CAPAManagement", "InspectionRequest", () => new ucCAPAManagement());
            acePunchListManagementNav.Click += (s, e) => OpenTab(acePunchListManagementNav.Text, "PunchListManagement", "InspectionRequest", () => new ucPunchListManagement());
            aceSnagListNav.Click += (s, e) => OpenTab(aceSnagListNav.Text, "SnagList", "InspectionRequest", () => new ucSnagList());
            aceHandoverInspectionNav.Click += (s, e) => OpenTab(aceHandoverInspectionNav.Text, "HandoverInspection", "InspectionRequest", () => new ucHandoverInspection());
            aceDefectLiabilityNav.Click += (s, e) => OpenTab(aceDefectLiabilityNav.Text, "DefectLiability", "InspectionRequest", () => new ucDefectLiability());
            aceQualityReportsNav.Click += (s, e) => OpenTab(aceQualityReportsNav.Text, "QualityReports", "InspectionRequest", () => new ucQualityReports());
            #endregion

            #region Enterprise HSE Management
            aceHSEDashboardNav.Click += (s, e) => OpenTab(aceHSEDashboardNav.Text, "HSEDashboard", "InspectionRequest", () => new ucHSEDashboard());
            aceIncidentRegisterNav.Click += (s, e) => OpenTab(aceIncidentRegisterNav.Text, "IncidentRegister", "InspectionRequest", () => new ucIncidentRegister());
            aceIncidentInvestigationNav.Click += (s, e) => OpenTab(aceIncidentInvestigationNav.Text, "IncidentInvestigation", "InspectionRequest", () => new ucIncidentInvestigation());
            aceNearMissRegisterNav.Click += (s, e) => OpenTab(aceNearMissRegisterNav.Text, "NearMissRegister", "InspectionRequest", () => new ucNearMissRegister());
            aceHazardRegisterNav.Click += (s, e) => OpenTab(aceHazardRegisterNav.Text, "HazardRegister", "InspectionRequest", () => new ucHazardRegister());
            aceRiskAssessmentNav.Click += (s, e) => OpenTab(aceRiskAssessmentNav.Text, "RiskAssessment", "InspectionRequest", () => new ucRiskAssessment());
            acePermitToWorkNav.Click += (s, e) => OpenTab(acePermitToWorkNav.Text, "PermitToWork", "InspectionRequest", () => new ucPermitToWork());
            aceSafetyInspectionNav.Click += (s, e) => OpenTab(aceSafetyInspectionNav.Text, "SafetyInspection", "InspectionRequest", () => new ucSafetyInspection());
            aceToolboxTalkNav.Click += (s, e) => OpenTab(aceToolboxTalkNav.Text, "ToolboxTalk", "InspectionRequest", () => new ucToolboxTalk());
            aceSafetyTrainingNav.Click += (s, e) => OpenTab(aceSafetyTrainingNav.Text, "SafetyTraining", "InspectionRequest", () => new ucSafetyTraining());
            acePPEManagementNav.Click += (s, e) => OpenTab(acePPEManagementNav.Text, "PPEManagement", "InspectionRequest", () => new ucPPEManagement());
            aceEquipmentInspectionNav.Click += (s, e) => OpenTab(aceEquipmentInspectionNav.Text, "EquipmentInspection", "InspectionRequest", () => new ucEquipmentInspection());
            aceEnvironmentalMonitoringNav.Click += (s, e) => OpenTab(aceEnvironmentalMonitoringNav.Text, "EnvironmentalMonitoring", "InspectionRequest", () => new ucEnvironmentalMonitoring());
            aceEmergencyPreparednessNav.Click += (s, e) => OpenTab(aceEmergencyPreparednessNav.Text, "EmergencyPreparedness", "InspectionRequest", () => new ucEmergencyPreparedness());
            aceHSEReportsNav.Click += (s, e) => OpenTab(aceHSEReportsNav.Text, "HSEReports", "InspectionRequest", () => new ucHSEReports());
            #endregion

            #region Cost Control
            aceCostControlDashboardNav.Click += (s, e) => OpenTab(aceCostControlDashboardNav.Text, "CostControlDashboard", "InspectionRequest", () => new ucCostControlDashboard());
            aceCostBreakdownStructureNav.Click += (s, e) => OpenTab(aceCostBreakdownStructureNav.Text, "CostBreakdownStructure", "InspectionRequest", () => new ucCostBreakdownStructure());
            aceCostCommitmentsNav.Click += (s, e) => OpenTab(aceCostCommitmentsNav.Text, "CostCommitments", "InspectionRequest", () => new ucCostCommitments());
            aceBudgetVsCommitmentNav.Click += (s, e) => OpenTab(aceBudgetVsCommitmentNav.Text, "BudgetVsCommitment", "InspectionRequest", () => new ucBudgetVsCommitment());
            aceCostCtrlBudgetVsActualNav.Click += (s, e) => OpenTab(aceCostCtrlBudgetVsActualNav.Text, "BudgetVsActual", "InspectionRequest", () => new ucBudgetVsActual());
            aceEarnedValueManagementNav.Click += (s, e) => OpenTab(aceEarnedValueManagementNav.Text, "EarnedValueManagement", "InspectionRequest", () => new ucEarnedValueManagement());
            aceCostCtrlForecastNav.Click += (s, e) => OpenTab(aceCostCtrlForecastNav.Text, "CostForecast", "InspectionRequest", () => new ucCostForecast());
            aceCashFlowAnalysisNav.Click += (s, e) => OpenTab(aceCashFlowAnalysisNav.Text, "CashFlowAnalysis", "InspectionRequest", () => new ucCashFlowAnalysis());
            aceOwnerIPCManagementNav.Click += (s, e) => OpenTab(aceOwnerIPCManagementNav.Text, "OwnerIPCManagement", "InspectionRequest", () => new ucOwnerIPCManagement());
            aceSubcontractorIPCManagementNav.Click += (s, e) => OpenTab(aceSubcontractorIPCManagementNav.Text, "SubcontractorIPCManagement", "InspectionRequest", () => new ucSubcontractorIPCManagement());
            aceCostVarianceAnalysisNav.Click += (s, e) => OpenTab(aceCostVarianceAnalysisNav.Text, "CostVarianceAnalysis", "InspectionRequest", () => new ucCostVarianceAnalysis());
            aceCostTrendAnalysisNav.Click += (s, e) => OpenTab(aceCostTrendAnalysisNav.Text, "CostTrendAnalysis", "InspectionRequest", () => new ucCostTrendAnalysis());
            aceCostForecastScenariosNav.Click += (s, e) => OpenTab(aceCostForecastScenariosNav.Text, "CostForecastScenarios", "InspectionRequest", () => new ucCostForecastScenarios());
            aceExecutiveCostReviewNav.Click += (s, e) => OpenTab(aceExecutiveCostReviewNav.Text, "ExecutiveCostReview", "InspectionRequest", () => new ucExecutiveCostReview());
            aceCostReportsNav.Click += (s, e) => OpenTab(aceCostReportsNav.Text, "CostReports", "InspectionRequest", () => new ucCostReports());
            #endregion

            #region Subcontractors
            //aceSubcontractorList.Click += (s, e) => OpenTab(aceSubcontractorList.Text, "SubcontractorList", "SubcontractorList", () => new ucSubcontractorList());
            //aceSubcontractorContract.Click += (s, e) => OpenTab(aceSubcontractorContract.Text, "SubcontractorContract", "SubcontractorContract", () => new ucSubcontractorContract());
            //aceSubcontractorInvoice.Click += (s, e) => OpenTab(aceSubcontractorInvoice.Text, "SubcontractorInvoice", "SubcontractorInvoice", () => new ucSubcontractorInvoice());
            //aceSubcontractorReport.Click += (s, e) => OpenTab(aceSubcontractorReport.Text, "SubcontractorReport", "SubcontractorReport", () => new ucSubcontractorReport());
            #endregion

            #region Payment Request
            //aceFinancialRequest.Click += (s, e) => OpenTab(aceFinancialRequest.Text, "FinancialRequest", "FinancialRequest", () => new ucFinancialRequest());
            //acePettyCash.Click += (s, e) => OpenTab(acePettyCash.Text, "PettyCash", "PettyCash", () => new ucPettyCash());
            //aceCasualWorkerRequest.Click += (s, e) => OpenTab(aceCasualWorkerRequest.Text, "CasualWorkerRequest", "CasualWorkerRequest", () => new ucCasualWorkerRequest());
            //aceEquipmentRentRequest.Click += (s, e) => OpenTab(aceEquipmentRentRequest.Text, "EquipmentRentRequest", "EquipmentRentRequest", () => new ucEquipmentRentRequest());
            //aceEquipmentRentPayment.Click += (s, e) => OpenTab(aceEquipmentRentPayment.Text, "EquipmentRentPayment", "EquipmentRentPayment", () => new ucEquipmentRentPayment());
            //aceCasualWorkerPayment.Click += (s, e) => OpenTab(aceCasualWorkerPayment.Text, "CasualWorkerPayment", "CasualWorkerPayment", () => new ucCasualWorkerPayment());
            #endregion

            #region Procurement
            aceStakeholder.Click += (s, e) => OpenTab(aceStakeholder.Text, "Stakeholder", "Stakeholder", () => new ucSuppliers());
            aceRFQ.Click += (s, e) => OpenTab(aceRFQ.Text, "RFQ", "RFQ", () => new ucRFQ());
            acePriceQuotation.Click += (s, e) => OpenTab(acePriceQuotation.Text, "PriceQuotation", "PriceQuotation", () => new ucPriceQuotationMain());
            acePurchaseRequest.Click += (s, e) => OpenTab(acePurchaseRequest.Text, "PurchaseRequest", "PurchaseRequest", () => new ucPurchaseRequests());
            acePurchaseOrder.Click += (s, e) => OpenTab(acePurchaseOrder.Text, "PurchaseOrder", "PurchaseOrder", () => new ucPurchaseOrder());
            acePOAmendment.Click += (s, e) => OpenTab(acePOAmendment.Text, "POAmendment", "POAmendment", () => new ucPOAmendment());
            //acePurchaseReports.Click += (s, e) => OpenTab(acePurchaseReports.Text, "PurchaseReports", "PurchaseReports", () => new ucPurchaseReports());
            aceDepartments.Click += (s, e) => OpenTab(aceDepartments.Text, "Departments", "Departments", () => new ucDepartments());
            aceDisciplines.Click += (s, e) => OpenTab(aceDisciplines.Text, "Disciplines", "Disciplines", () => new ucDisciplinesList());
            #endregion

            #region Inventory
            aceStores.Click += (s, e) => OpenTab(aceStores.Text, "Stores", "Stores", () => new ucStores());
            ascItems.Click += (s, e) => OpenTab(ascItems.Text, "Items", "Items", () => new ucItemsMain());
            aceMaterialReceiveVoucher.Click += (s, e) => OpenTab(aceMaterialReceiveVoucher.Text, "MaterialReceiveVoucher", "MaterialReceiveVoucher", () => new ucMaterialReceive());
            aceMaterialIssuedVoucher.Click += (s, e) => OpenTab(aceMaterialIssuedVoucher.Text, "MaterialIssuedVoucher", "MaterialIssuedVoucher", () => new ucMaterialIssued());
            aceMaterialTrasfare.Click += (s, e) => OpenTab(aceMaterialTrasfare.Text, "MaterialTrasfare", "MaterialTrasfare", () => new ucMaterialTrasfare());
            acePurchaseReturn.Click += (s, e) => OpenTab(acePurchaseReturn.Text, "PurchaseReturn", "PurchaseReturn", () => new ucPurchaseReturn());
            aceMaterialIssueReturn.Click += (s, e) => OpenTab(aceMaterialIssueReturn.Text, "MaterialIssueReturn", "MaterialIssueReturn", () => new ucMaterialIssueReturn());
            aceOpeningBalance.Click += (s, e) => OpenTab(aceOpeningBalance.Text, "OpeningBalance", "OpeningBalance", () => new ucOpeningBalance());
            aceMaterialStocking.Click += (s, e) => OpenTab(aceMaterialStocking.Text, "MaterialStocking", "MaterialStocking", () => new ucStocking());
            aceInventoryReports.Click += (s, e) => OpenTab(aceInventoryReports.Text, "InventoryReports", "InventoryReports", () => new ucInventoryReports());
            #endregion

            #region Workflow Engine
            //aceWorkflowMgt.Click += (s, e) => OpenTab(aceWorkflowMgt.Text, "WorkflowMgt", "WorkflowMgt", () => new ucWorkflowMgt());
            aceMyWorkflowTasks.Click += (s, e) => OpenTab(aceMyWorkflowTasks.Text, "MyWorkflowTasks", "MyWorkflowTasks", () => new ucMyWorkflowTasks());
            aceWorkflowDefinitions.Click += (s, e) => OpenTab(aceWorkflowDefinitions.Text, "WorkflowDefinitions", "WorkflowDefinitions", () => new ucWorkflowDefinitions());
            aceApprovalMatrix.Click += (s, e) => OpenTab(aceApprovalMatrix.Text, "ApprovalMatrix", "ApprovalMatrix", () => new ucApprovalMatrix());
            #endregion
        }
        // internal (not private): ucBOQList opens a specific BOQ's editor tab (one tab per record,
        // keyed "BOQEditor:{id}") from its Edit/View/Copy/New actions via (this.FindForm() as
        // frmMainPage)?.OpenTab(...) — the generic aceBOQEditor menu entry above only opens a single
        // blank/shared tab keyed "BOQEditor" with no id.
        internal void OpenTab(string caption, string key, string imageKey, Func<UserControl>? factory)
        {
            // البحث عن تاب مفتوح بنفس المفتاح
            var existing = tabbedView1.Documents
                .FirstOrDefault(d => d.Tag?.ToString() == key);

            if (existing != null)
            {
                tabbedView1.Controller.Activate(existing);
                return;
            }

            // تحقق من توفر Factory
            if (factory == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"الوحدة [{caption}] قيد التطوير.",
                    "قيد التطوير",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                var uc = factory();
                uc.Dock = DockStyle.Fill;

                var doc = tabbedView1.AddDocument(uc) as Document;
                if (doc != null)
                {
                    doc.Caption = caption;
                    doc.Tag = key;

                    var svgImg = svgImageCollection1[imageKey];
                    if (svgImg != null)
                    {
                        doc.ImageOptions.SvgImageSize = new Size(20, 20);
                        doc.ImageOptions.SvgImage = svgImg;
                    }

                    tabbedView1.Controller.Activate(doc);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"خطأ أثناء فتح [{caption}]:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
