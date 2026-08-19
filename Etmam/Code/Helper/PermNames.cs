namespace Etmam
{
    /// <summary>
    /// Names of every <see cref="Core.Tables.PermissionsList"/> row referenced from code, used with
    /// <see cref="Data.PermissionService.HasPermission(string)"/>. Replaces the old numeric
    /// `frmMainPage.PermIds` (int constants matching hard-coded PermissionsList row Ids) — a live-database
    /// check found those Ids no longer matched the actual rows in at least one environment, so lookups
    /// are keyed by the permission's Name instead, exactly like Data/DatabaseInitializer.cs seeds them
    /// (see the idempotent `WHERE Name = N'...'` blocks there).
    ///
    /// The values below are the literal `.Text`/`.Caption` captions of the corresponding ribbon/accordion
    /// item in frmMainPage.Designer.cs, so a permission row and the menu item it gates always share the
    /// exact same display name.
    /// </summary>
    public static class PermNames
    {
        // Main
        public const string MainSection = "الرئيسية";
        public const string Dashboard = "شاشة التحكم الرئيسية";

        // Projects Management
        public const string ProjectsMgtSection = "إدارة المشروعات";
        public const string ProjectType = "نوع المشروع";
        public const string ProjectStatus = "حالة العقد";
        public const string ProjectSituation = "موقف المشروع";
        public const string ProjectDetails = "بيانات المشروع";
        public const string BOQ = "جدول الكميات والمواصفات";
        public const string WBS = "هيل تجزئة المشروع";
        public const string Buildings = "المباني";
        public const string Floors = "الطوابق";

        // Project detail tabs (opened from within a project — aceProjectsMgt's own leaf screens,
        // distinct from the BOQ/Budget Management top-level groups above)
        public const string ProjectsList = "قائمة المشاريع";
        public const string ProjectTeam = "فريق العمل";
        public const string ProjectSchedule = "الجدول الزمني";
        public const string ProjectBudgetSummary = "ملخص الموازنة";
        public const string ProjectDocuments = "مستندات المشروع";
        public const string ProjectRisks = "المخاطر";
        public const string ProjectIssues = "المشكلات";
        public const string ProjectCorrespondence = "المراسلات";
        public const string ProjectMeetings = "الاجتماعات";
        public const string ProjectProgress = "التقدم";
        public const string ProjectCostControl = "ضبط التكلفة";
        public const string ProjectDashboard = "لوحة معلومات المشروع";
        public const string ProjectCloseout = "إغلاق المشروع";

        // BOQ Management (dedicated accordion group, alongside the legacy BOQ item above)
        public const string BOQMgtSection = "إدارة جداول الكميات (المقايسة)";
        public const string BOQExplorer = "مستكشف جدول الكميات";
        public const string BOQEditor = "تحرير جدول الكميات";
        public const string BOQComparison = "مقارنة جداول الكميات";
        public const string BOQRevisionManagement = "إدارة إصدارات جدول الكميات";
        public const string BOQAnalysis = "تحليل جدول الكميات";
        public const string BOQApproval = "اعتماد جدول الكميات";
        public const string BOQReports = "تقارير جدول الكميات";

        // Budget Management (dedicated accordion group; distinct captions from the similarly-named
        // items under "إدارة وضبط التكاليف Cost Control" above, so each keeps its own permission row)
        public const string BudgetMgtSection = "إدارة الموازنة والتقدير";
        public const string BudgetMgtDashboard = "لوحة الموازنة";
        public const string BudgetMgtList = "قائمة الموازنات";
        public const string BudgetMgtEditor = "محرر الموازنة";
        public const string BudgetMgtCBS = "هيكل تجزئة التكلفة (CBS)";
        public const string BudgetMgtImportWizard = "معالج استيراد الموازنة";
        public const string BudgetMgtRevision = "مراجعات الموازنة";
        public const string BudgetMgtCashFlowForecast = "توقعات التدفق النقدي";
        public const string BudgetMgtVsActual = "الموازنة مقابل الفعلي";
        public const string BudgetMgtCostForecast = "توقع التكلفة (EVM)";
        public const string BudgetMgtApprovalWorkflow = "مسار اعتماد الموازنة";
        public const string BudgetMgtReports = "تقارير الموازنة";

        // Document Control
        public const string DocumentsMgtSection = "إدارة المستندات";
        public const string InspectionRequest = "طلب فحص اعمال (CIR)";

        // frmCIRAddEdit's own toolbar actions — nested under DocumentsMgtSection > InspectionRequest
        // in the seed tree, distinct from InspectionRequest above (which only gates whether the
        // module/list is reachable at all — see PermNames.UserAdd for the identical pattern).
        public const string CIRAdd = "إضافة طلب فحص";
        public const string CIRSave = "حفظ طلب فحص";
        public const string CIRPrint = "طباعة طلب فحص";
        public const string CIRSend = "إرسال طلب فحص";
        public const string CIRReissue = "إعادة إصدار طلب فحص";
        public const string CIRDelete = "حذف طلب فحص";
        public const string CIRConsultantAction = "إجراء الاستشاري/المالك";

        /// <summary>Gates frmCIRAddEdit's btnApproved (اعتماد) — starting/acting on the CIR's own
        /// مدير المشروع approval procedure via CIRWorkflowSync/WorkflowEngine. Whether a specific click
        /// actually *advances* a running instance is separately governed by WorkflowEngine.CanUserAct
        /// (is this user the current step's assignee) — this permission only gates whether the button
        /// is usable at all, same split as CIRSend/PRSend.</summary>
        public const string CIRApprove = "اعتماد طلب فحص";
        public const string MaterialInspectionRequest = "طلب فحص مواد (MIR)";
        public const string MaterialApprovalRequest = "طلب اعتماد مواد (MAR)";
        public const string DrawingsApprovalRequest = "طلب اعتماد مخططات";
        public const string DocumentSubmittal = "نموذج تقديم مستند (DSF)";
        public const string DailyReport = "التقرير اليومي (DR)";
        public const string ConcretePourRequest = "طلبات صب الخرسانة";
        public const string ConcreteTestResult = "نتائج إختبارات الخرسانة";

        // Cost Control
        public const string CostControlMgtSection = "إدارة وضبط التكاليف Cost Control";
        public const string CostControlDashboard = "لوحة تحكم ضبط التكاليف (Cost Dashboard)";
        public const string CostBreakdownStructure = "هيكل تجزئة التكاليف (CBS)";
        public const string CostCommitments = "التزامات التكاليف (Cost Commitments)";
        public const string BudgetVsCommitment = "الموازنة مقابل الالتزامات (Budget vs Commitment)";
        public const string BudgetVsActual = "الموازنة مقابل التكلفة الفعلية (Budget vs Actual)";
        public const string EarnedValueManagement = "إدارة القيمة المكتسبة (EVM)";
        public const string CostForecast = "توقعات التكلفة النهائية (EAC / ETC)";
        public const string CashFlowAnalysis = "تحليل التدفقات النقدية (Cash Flow)";
        public const string OwnerIPCManagement = "مستخلصات المالك (Owner IPC)";
        public const string SubcontractorIPCManagement = "مستخلصات مقاولي الباطن (Subcontractor IPC)";
        public const string CostVarianceAnalysis = "تحليل انحرافات التكاليف (Cost Variance)";
        public const string CostTrendAnalysis = "تحليل اتجاهات التكاليف (Cost Trends)";
        public const string CostForecastScenarios = "سيناريوهات توقعات التكلفة (Forecast Scenarios)";
        public const string ExecutiveCostReview = "المراجعة التنفيذية للتكاليف (Executive Review)";
        public const string CostReports = "تقارير ومؤشرات التكاليف (Cost Reports)";
        public const string Budget = "الموازنة التقديرية";
        public const string CostCenter = "مراكز التكلفة";
        public const string AccountList = "دليل الحسابات";
        public const string Activities = "بنود الأعمال";
        public const string Units = "وحدات القياس";
        public const string ClientInvoice = "مستخلص المالك";
        public const string VarianceReport = "تقرير التباين";

        // Subcontractors
        public const string SubcontractorMgtSection = "إدارة مقاولي الباطن";
        public const string SubcontractorList = "قائمة مقاولي الباطن";
        public const string SubcontractorContract = "عقد مقاول باطن";
        public const string SubcontractorInvoice = "مستخلص مقاول باطن";
        public const string SubcontractorReport = "تقارير مقاولي الباطن";

        // Payment Request
        public const string PaymentRequestMgtSection = "إدارة المطالبات";
        public const string FinancialRequest = "طلب تصديق مالي";
        public const string PettyCash = "تصفية عهدة";
        public const string CasualWorkerRequest = "طلب عمالة مؤقتة";
        public const string EquipmentRentRequest = "طلب معدات واليات";
        public const string EquipmentRentPayment = "مطالبة ايجار معدات";
        public const string CasualWorkerPayment = "مطالبة عماله مؤقتة";

        // Procurement
        public const string PurchaseMgtSection = "إدارة المشتريات";

        // These 8 were reachable from the ribbon (acePurchaseMgt.Elements — see
        // frmMainPage.Designer.cs) with no PermNames entry, no HasPerm() gate in
        // ApplyProcurementPermissions, and no seeded PermissionsList row: any user who could see the
        // "إدارة المشتريات" section at all got these unconditionally enabled, with no way for an admin
        // to grant/deny them individually in frmUsersMgt's permissions tree.
        public const string ProcurementDashboard = "لوحة التحكم";
        public const string ProcurementGuide = "دليل المشتريات";
        public const string ProcurementWorkbench = "منصة عمل المشتريات";
        public const string TechnicalEvaluation = "التقييم الفني";
        public const string QuotationComparison = "مقارنة العروض";
        public const string Negotiation = "التفاوض";
        public const string AwardRecommendation = "توصيات الترسية";
        public const string ApprovalsInbox = "صندوق الإعتمادات";

        public const string Stakeholder = "الموردين";
        public const string RFQ = "طلبات عروض الأسعار (RFQ)";

        // Was seeded/checked as N'عروض الأسعار', which no longer matches acePriceQuotation's actual
        // ribbon caption N'عروض الموردين' (frmMainPage.Designer.cs) — same class of drift as
        // PurchaseMgtSection's rename; see the merge migration in DatabaseInitializer.cs.
        public const string PriceQuotation = "عروض الموردين";
        public const string PurchaseRequest = "طلبات الشراء";

        // frmPurchaseRequestAddEdit's own toolbar actions — nested under PurchaseRequest above (which
        // only gates whether the module/list is reachable at all — same pattern as PermNames.CIRAdd
        // etc.). اعتماد/رفض/إعادة أثناء الاعتماد تبقى عمداً خارج هذه المجموعة — تحكمها WorkflowEngine.
        // CanUserAct وحدها (انظر frmPurchaseRequestAddEdit.UpdateActionButtonStates).
        public const string PRAdd = "إضافة طلب شراء";
        public const string PRSave = "حفظ طلب شراء";
        public const string PRPrint = "طباعة طلب شراء";
        public const string PRSend = "إرسال طلب شراء للاعتماد";
        public const string PRDelete = "حذف طلب شراء";
        public const string PRReturnForEdit = "إعادة طلب شراء لمسودة";
        public const string PRClose = "إغلاق طلب شراء";

        // ucPurchaseRequests (شاشة القائمة) يعيد استخدام PRAdd/PRSave/PRPrint/PRSend/PRDelete أعلاه —
        // "تعديل" في القائمة يفتح نفس نموذج frmPurchaseRequestAddEdit المحكوم بـ PRSave، و"طباعة" (سواء
        // الطباعة السريعة لعمود الشبكة أو زر طباعة سجل الطلبات المُصفّاة) تستخدم PRPrint. PRExport وحدها
        // صلاحية جديدة خاصة بهذه الشاشة (لا مقابل لها في نموذج الإضافة/التعديل).
        public const string PRExport = "تصدير طلبات الشراء";

        public const string Departments = "الإدارات الطالبة";
        public const string Disciplines = "التخصصات";
        public const string SecondaryDisciplines = "التخصصات الثانوية";
        public const string InspectionActivities = "أنشطة الفحص";
        public const string PurchaseOrder = "اوامر الشراء";

        // frmPurchaseOrderAddEdit/ucPurchaseOrder's own per-action permissions — same pattern as
        // PRAdd/PRSave/... above (PurchaseOrder itself only gates whether the module/list is reachable
        // at all — acePurchaseOrder.Enabled in frmMainPage). اعتماد/رفض أمر الشراء تبقى عمداً خارج هذه
        // المجموعة — تحكمها WorkflowEngine.CanUserAct وحدها (انظر
        // frmPurchaseOrderAddEdit.UpdateActionButtonStates). لا يوجد "إغلاق" مقابل لـ PRClose هنا؛ لا
        // مفهوم مواز له لأمر الشراء.
        public const string POAdd = "إضافة أمر شراء";
        public const string POSave = "حفظ أمر شراء";
        public const string POPrint = "طباعة أمر شراء";
        public const string POSend = "إرسال أمر شراء للاعتماد";
        public const string PODelete = "حذف أمر شراء";
        public const string POReturnForEdit = "إعادة أمر شراء لمسودة";

        public const string POAmendment = "تعديلات أوامر الشراء";
        public const string PurchaseReports = "تقارير المشتريات";

        // Gates seeing commercial figures (unit price/discount/tax/totals) while performing a
        // Technical Evaluation — see frmTechnicalEvaluationAddEdit and the methodology doc's
        // Technical/Commercial separation requirement. Independent of PriceQuotation above (that one
        // gates the quotation module itself; this one gates one specific column group within it).
        public const string ViewCommercialPrices = "رؤية الأسعار التجارية";

        // Inventory
        public const string InventoryMgtSection = "إدارة المخزون";
        public const string Stores = "المخازن";
        public const string Items = "الأصناف";
        public const string MaterialReceiveVoucher = "إذن إستلام";
        public const string MaterialIssuedVoucher = "إذن صرف";
        public const string MaterialTrasfare = "التحويل بين المخازن";
        public const string PurchaseReturn = "مرتجع مشتريات";
        public const string MaterialIssueReturn = "مرتجع صرف";
        public const string OpeningBalance = "رصيد افتتاحي";
        public const string MaterialStocking = "جرد المخزون";
        public const string InventoryReports = "تقارير المخزون";

        // Workflow Engine
        public const string WorkflowEngineSection = "إدارة الإجراءات";
        public const string MyWorkflowTasks = "مهامي";
        public const string WorkflowDefinitions = "تعريف الإجراءات";
        public const string ApprovalMatrix = "مصفوفة الاعتماد";

        // Planning Management
        public const string PlanningMgtSection = "إدارة التخطيط والجدول الزمني";
        public const string PlanningDashboard = "لوحة تحكم التخطيط";
        public const string ScheduleList = "الجداول الزمنية";
        public const string ScheduleExplorer = "مستكشف الجدول الزمني";
        public const string ActivityEditor = "محرر الأنشطة";
        public const string BaselineManagement = "إدارة الخطوط المرجعية";
        public const string ProgressUpdate = "تحديث نسب الإنجاز";
        public const string LookAheadPlanning = "التخطيط المستقبلي (Look-Ahead)";
        public const string Milestones = "المراحل الرئيسية (Milestones)";
        public const string ResourcePlanning = "تخطيط الموارد";
        public const string DelayAnalysis = "تحليل التأخيرات والمطالبات";
        public const string ScheduleComparison = "مقارنة الجداول الزمنية";
        public const string PlanningImportExportWizard = "معالج استيراد وتصدير الجداول";
        public const string PlanningReports = "تقارير التخطيط";

        // Contract Management
        public const string ContractMgtSection = "إدارة العقود";
        public const string ContractDashboard = "لوحة تحكم العقود";
        public const string ContractRegister = "سجل العقود";
        public const string ContractDetails = "تفاصيل العقد";
        public const string ContractObligations = "سجل الالتزامات التعاقدية";
        public const string ContractCorrespondence = "المراسلات والخطابات التعاقدية";
        public const string VariationOrders = "أوامر التغيير (VO)";
        public const string ContractClaims = "المطالبات والنزاعات";
        public const string ExtensionOfTime = "طلبات تمديد الوقت (EOT)";
        public const string SecuritiesGuarantees = "الخطابات والضمانات البنكية";
        public const string PaymentCertificates = "المستخلصات التعاقدية";
        public const string RetentionManagement = "إدارة المحتجزات النقدية";
        public const string ContractAmendments = "تعديلات وملحقات العقود";
        public const string ContractRiskRegister = "سجل مخاطر العقود";
        public const string ContractCloseout = "إغلاق العقود النهائي";
        public const string ContractReports = "تقارير العقود";

        // Enterprise EDMS Section
        public const string EDMSSection = "إدارة المستندات والوثائق EDMS";
        public const string EDMSDashboard = "لوحة تحكم الوثائق EDMS";
        public const string EDMSDocumentRegister = "سجل المستندات والوثائق";
        public const string EDMSDocumentDetails = "تفاصيل المستند والخصائص";
        public const string EDMSDrawingRegister = "سجل الرسومات الهندسية";
        public const string EDMSMaterialSubmittals = "طلبات اعتماد المواد (MSR)";
        public const string EDMSRFIRegister = "طلب المعلومات والطلبات الفنية (RFI)";
        public const string EDMSTechnicalQueries = "الاستفسارات الفنية (TQ)";
        public const string EDMSTransmittalMgt = "خطابات التسليم والارسال (Transmittals)";
        public const string EDMSIncomingCorrespondence = "المراسلات والخطابات الواردة";
        public const string EDMSOutgoingCorrespondence = "المراسلات والخطابات الصادرة";
        public const string EDMSReviewApproval = "اعتمادات ومراجعات المستندات";
        public const string EDMSVersionControl = "سجل وتتبع الإصدارات (Version Control)";
        public const string EDMSDistributionMatrix = "مصفوفة التوزيع والارسال";
        public const string EDMSArchiveTree = "أرشيف الوثائق والمستندات";
        public const string EDMSReportsCenter = "تقارير نظام الوثائق";

        // Enterprise Correspondence Management Section
        public const string CorrespondenceMgtSection = "إدارة المراسلات والبريد المؤسسي";
        public const string CorrespondenceDashboard = "لوحة تحكم المراسلات";
        public const string CorrespondenceInbox = "صندوق المراسلات الواردة (Inbox)";
        public const string CorrespondenceOutbox = "صندوق المراسلات الصادرة (Outbox)";
        public const string InternalMemoRegister = "سجل المذكرات الداخلية (Internal Memos)";
        public const string CircularManagement = "إدارة التعاميم والنشرات (Circulars)";
        public const string MeetingMinutes = "محاضر الاجتماعات (Meeting Minutes)";
        public const string CorrespondenceDetails = "تفاصيل المراسلة والخصائص";
        public const string EmailIntegrationCenter = "مركز تكامل البريد الإلكتروني Outlook";
        public const string CorrespondenceDistributionLists = "قوائم التوزيع والارسال";
        public const string CorrespondenceActionTracking = "تتبع الإجراءات والتكليفات";
        public const string CorrespondenceAcknowledgement = "تتبع الإقرارات والإشطارات";
        public const string CorrespondenceWorkflow = "سير اعتماد المراسلات";
        public const string CorrespondenceArchiveSearch = "أرشيف وبحث المراسلات";
        public const string CorrespondenceReports = "تقارير المراسلات والبريد";
        public const string MailboxSyncMonitor = "مراقب مزامنة صناديق البريد";

        // Enterprise Quality Management Section (QMS)
        public const string QualityMgtSection = "إدارة الجودة QMS";
        public const string QualityDashboard = "لوحة تحكم الجودة";
        public const string InspectionRequestRegister = "سجل طلبات الفحص (IR)";
        public const string InspectionForm = "نموذج وفحوصات الموقع (IR Form)";
        public const string InspectionTestPlan = "خطة الفحص والاختبار (ITP)";
        public const string ChecklistLibrary = "مكتبة القوائم المرجعية (Checklists)";
        public const string MaterialInspection = "سجل فحص المواد والموردات";
        public const string SiteInspection = "فحوصات الجودة الميدانية";
        public const string NCRRegister = "سجل تقارير عدم المطابقة (NCR)";
        public const string NCRDetails = "تفاصيل ومراحل تقرير عدم المطابقة";
        public const string CAPAManagement = "الإجراءات التصحيحية والوقائية (CAPA)";
        public const string PunchListManagement = "إدارة نواقص النواحي والـ Punch List";
        public const string SnagList = "سجل الملاحظات العاجلة (Snag List)";
        public const string HandoverInspection = "معالج وفحوصات الاستلام النهائي (Handover)";
        public const string DefectLiability = "إدارة الصيانة وفترة الضمان (Defect Liability)";
        public const string QualityReports = "تقارير ومؤشرات الجودة QMS";

        // Enterprise HSE Management Section
        public const string HSEMgtSection = "إدارة السلامة والصحة والبيئة HSE";
        public const string HSEDashboard = "لوحة تحكم السلامة والبيئة";
        public const string IncidentRegister = "سجل الحوادث والإصابات (Incidents)";
        public const string IncidentInvestigation = "تحقيق ودراسة أسباب الحوادث";
        public const string NearMissRegister = "سجل الحوادث الوشيكة (Near Miss)";
        public const string HazardRegister = "سجل المخاطر والمكاره (Hazard Register)";
        public const string RiskAssessment = "تقييم المخاطر وتحليل السلامة (JSA/JHA)";
        public const string PermitToWork = "سجل تصاريح العمل (Permit To Work - PTW)";
        public const string SafetyInspection = "جولات وفحوصات السلامة الميدانية";
        public const string ToolboxTalk = "اجتماعات ومحادثات السلامة (Toolbox Talks)";
        public const string SafetyTraining = "سجل ودورات التدريب وتراخيص السلامة";
        public const string PPEManagement = "إدارة وسجل أدوات الوقاية الشخصية (PPE)";
        public const string EquipmentInspection = "فحص واختبار معدات السلامة والآلات";
        public const string EnvironmentalMonitoring = "سجل وقراءات الرصد البيئي";
        public const string EmergencyPreparedness = "مخطط وفرضيات خطط الطوارئ";
        public const string HSEReports = "تقارير ومؤشرات السلامة والبيئة HSE";

        // Settings
        public const string SettingsSection = "الإعدادات";
        public const string UsersMgt = "إدارة المستخدمين";
        public const string PermissionsMgt = "إدارة الصلاحيات";
        public const string Connection = "اتصال بالشبكة";
        public const string Backup = "إنشاء نسخة احتياطيه";
        public const string Restore = "إستعادة نسخة احتياطية";

        // frmUsersMgt's own toolbar actions — nested under UsersMgt in the seed tree, distinct
        // from UsersMgt above (which only gates whether the module is reachable from the ribbon).
        public const string UserAdd = "إضافة مستخدم";
        public const string UserEdit = "تعديل مستخدم";
        public const string UserEditPassword = "تعديل كلمة السر";
        public const string UserToggleStatus = "تفعيل/تعطيل مستخدم";
        public const string UserSign = "التوقيع الإلكتروني";
        public const string UserPermissions = "الصلاحيات";
        public const string UserDelete = "حذف مستخدم";
    }
}
