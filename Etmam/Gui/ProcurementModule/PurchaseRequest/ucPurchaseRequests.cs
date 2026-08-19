using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>List/grid screen for Purchase Requests: filter by project, bulk status actions, export.</summary>
    public partial class ucPurchaseRequests : DevExpress.XtraEditors.XtraUserControl
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext dc => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private List<PurchaseRequestList> _allRecords = new();
        // ما تعرضه الشبكة فعلياً الآن (كل _allRecords، أو الجزء المُطابق لفلتر بطاقة نشطة في tbMain —
        // انظر RefreshGridFilter) — ReloadAndFocus يبحث فيها لا في _allRecords، وإلا كان رقم الصف
        // (index) المحسوب من القائمة الكاملة يشير لصف خاطئ بعد أي تصفية تُصغِّر عدد الصفوف المعروضة.
        private List<PurchaseRequestList> _visibleRecords = new();
        private HashSet<int> _grantedProjectIds = new();

        // صلاحيات مستقلة لكل زر — نفس صلاحيات frmPurchaseRequestAddEdit (PermNames.PRAdd/PRSave/PRPrint/
        // PRSend/PRDelete) يُعاد استخدامها هنا حرفياً لأن "تعديل" في هذه الشاشة يفتح ذاك النموذج نفسه
        // (محكوماً بـ PRSave داخله أصلاً)، و"طباعة" هنا (سريعة لعمود الشبكة أو لسجل الطلبات المُصفّاة) هي
        // نفس فعل الطباعة هناك. PRExport صلاحية إضافية خاصة بهذه الشاشة فقط (تصدير Excel). اعتماد/رفض
        // الطلب، وفتح "بطاقة الطلب" للعرض/الاعتماد فقط (bbiOpen/colAction/colLog)، تبقى خارج هذه المجموعة
        // عمداً — الأول محكوم بـ WorkflowEngine.CanUserAct وحده (انظر frmPurchaseRequestAddEdit)، والثاني
        // عرض/تصفح لا يغيّر بيانات فيُترك متاحاً لأي مستخدم يصل الشاشة.
        private bool _canAdd;
        private bool _canSave;
        private bool _canPrint;
        private bool _canSend;
        private bool _canDelete;
        private bool _canExport;

        // البطاقات الخمس الوسطى في tbMain (تحت إجراء ...) تُصفِّي وتُعد اعتماداً على النص الأول
        // (Elements[0].Text) المكتوب في الـ Designer نفسه — لا على نسخة مكرَّرة من النص هنا، وإلا
        // كان أي تعديل لصياغة البطاقة في الـ Designer (كما حدث بالفعل: إضافة "مراجعه"/"اعتماد" لثلاث
        // بطاقات لتطابق أسماء خطوات سير العمل الحقيقية في WorkflowStepList) يُسبِّب عدم تطابق صامت هنا.
        // الشرط الوحيد: يجب أن يطابق Elements[0].Text حرفياً نص الخطوة كما ينتجه
        // PurchaseRequestWorkflowSync.GetStatusDisplay/ReconcileAndGetStatusDisplayBulk
        // ("تحت إجراء {اسم الخطوة}") — أي اسم الخطوة المُهيَّأ فعلاً في WorkflowStepList لكل تعريف سير عمل.

        // البطاقة المُفعَّلة حالياً كفلتر على الشبكة (null = بلا فلتر / إجمالي)، مع محدِّدها كي يُعاد
        // تطبيقه بعد كل LoadData (تحديث/فتح نافذة) بدل أن يُفقد الفلتر عند إعادة تحميل البيانات.
        private DevExpress.XtraBars.Navigation.TileBarItem? _activeTile;
        private Func<PurchaseRequestList, bool>? _activeTileFilter;

        // صفّا "حالة أمر الشراء" و"حالة التوريد" وكل بطاقاتهما مُعرَّفة بالكامل في
        // ucPurchaseRequests.Designer.cs الآن — لا في كود C# — بطلب المستخدم أن يبقى تصميمها قابلاً
        // للتعديل اليدوي من نافذة Designer في Visual Studio (مقاسات/ألوان/تخطيط) بدل الاعتماد على كود
        // StyleTileBar/BuildStatusRows (المحاولة السابقة، أُزيلت). الصفّان مدموجان في عنصر TileBar واحد
        // (tbPoStatus) بمجموعتين متجاورتين (tbgPoStatus/tbgDeliveryStatus) — TileBar يعرض كل مجموعاته
        // في سطر واحد مهما تعددت (جرَّبنا 3 عناصر TileBar منفصلة، فكانت النتيجة أرفع مما يحتاجه المستخدم
        // فطلب دمج الصفّين). لهذا لا توجد حقول لها هنا — هي حقول عادية في الجزء الآخر (Designer.cs) من
        // نفس partial class، وكل ما تحتاجه هذه الملف هو قراءتها (WireTileBar/UpdateTileCounts أدناه).

        // ── Constructor ───────────────────────────────────────────────────────
        public ucPurchaseRequests()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canAdd = PermissionService.HasPermission(PermNames.PRAdd);
            _canSave = PermissionService.HasPermission(PermNames.PRSave);
            _canPrint = PermissionService.HasPermission(PermNames.PRPrint);
            _canSend = PermissionService.HasPermission(PermNames.PRSend);
            _canDelete = PermissionService.HasPermission(PermNames.PRDelete);
            _canExport = PermissionService.HasPermission(PermNames.PRExport);

            bbiNew.Enabled = _canAdd;

            //DesignSystem.ApplyCairoFont(this);
            SetupLookups();
            SetupGrid();
            WireTileBar();

            this.Load += (s, e) => LoadData();
        }

        /// <summary>Item backing lookUpEditPrj's merged project/department filter — same encoding as
        /// frmPurchaseRequestAddEdit.PrjSourceOption: positive = ProjectsList.Id, negative = -DepartmentsList.Id,
        /// 0 = "-- الكل --".</summary>
        private class PrjSourceOption
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void SetupLookups()
        {
            // فلتر المشروع/الإدارة: المشاريع مقيَّدة بصلاحية المستخدم (PermissionService.GrantedProjectIds)،
            // بينما الإدارات بيانات أساسية بلا صلاحيات تفصيلية فتظهر كاملة لأي مستخدم يملك صلاحية "طلبات الشراء"
            // (نفس منطق CostCenterList/BudgetList) — انظر LoadData لتطبيق هذا الفارق على الاستعلام.
            var projects = dc.ProjectsList.GetBy("IsDelete = 0");
            var departments = dc.DepartmentsList.GetBy("IsDelete = 0");
            _grantedProjectIds = PermissionService.GrantedProjectIds(dc);

            var accessibleProjects = projects.Where(p => _grantedProjectIds.Contains(p.Id)).ToList();

            var prjFilterSource = new List<PrjSourceOption> { new PrjSourceOption { Id = 0, Name = "-- الكل --" } };
            prjFilterSource.AddRange(accessibleProjects.Select(p => new PrjSourceOption { Id = p.Id, Name = p.Name ?? $"مشروع {p.Id}" }));
            prjFilterSource.AddRange(departments.Select(d => new PrjSourceOption { Id = -d.Id, Name = $"(إدارة) {d.Name ?? $"إدارة {d.Id}"}" }));

            lookUpEditPrj.Properties.DataSource    = prjFilterSource;
            lookUpEditPrj.Properties.ValueMember   = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.NullText      = "-- إختر المشروع / الإدارة --";

            // عند تغيير المشروع → إعادة تحميل
            lookUpEditPrj.EditValueChanged += (s, e) => LoadData();

            // تعيين المشروع الحالي كقيمة افتراضية
            lookUpEditPrj.EditValue = Session.SelectedProjectId;

            // عمود المخزن في الشبكة (Lookup)
            repositoryItemLookUpEditStore.DataSource    =dc.StoreList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditStore.ValueMember   = "Id";
            repositoryItemLookUpEditStore.DisplayMember = "Name";

            // عمود مركز التكلفة في الشبكة (Lookup)
            repositoryItemLookUpEditCC.DataSource    =dc.CostCenterList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditCC.ValueMember   = "Id";
            repositoryItemLookUpEditCC.DisplayMember = "Name";

            // عمود التخصص في الشبكة (Lookup)
            repositoryItemLookUpEditDiscipline.DataSource    = dc.DisciplinesList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditDiscipline.ValueMember   = "Id";
            repositoryItemLookUpEditDiscipline.DisplayMember = "Name";
        }

        private void SetupGrid()
        {
            //DesignSystem.ApplyGridStyle(gridControl1, gridView1);
            //DesignSystem.ApplyStatusColoring(gridView1, "Status");

            gridView1.OptionsView.ShowAutoFilterRow = false;
            // ملاحظة: Editable=false على مستوى الـ View بأكمله يمنع أي عمود ضمنه من دخول وضع التحرير —
            // بما في ذلك أعمدة الأزرار (colPrint/colAction)، فتتوقف أزرارها عن العمل تماماً. لذا الـ View
            // نفسه قابل للتحرير، وكل عمود بيانات معطَّل تحريره فردياً عبر OptionsColumn.AllowEdit=false
            // (مضبوطة مسبقاً في الـ Designer)، بينما colPrint/colAction فقط AllowEdit=true ليعمل الزرّان.
            gridView1.OptionsBehavior.Editable = true;
            //gridView1.OptionsSelection.MultiSelect = true;

            //// ضبط حجم الخط وارتفاع الأسطر لمنع مشكلة التهميش/القطع عند العرض للمستخدم
            //gridView1.Appearance.Row.Font = DesignSystem.Fonts.Regular(8.5F);
            //gridView1.Appearance.Row.Options.UseFont = true;
            //gridView1.Appearance.HeaderPanel.Font = DesignSystem.Fonts.Bold(8F);
            //gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            //gridView1.ColumnPanelRowHeight = 35;
            //gridView1.OptionsView.RowAutoHeight = true;

            // ضمان حد أدنى لارتفاع الصفوف لا يقل عن 34 بكسل مع إمكانية التوسع التلقائي للنصوص المتعددة الأسطر
            gridView1.CalcRowHeight += (s, e) =>
            {
                if (e.RowHeight < 30)
                    e.RowHeight = 30;
            };

            // ألوان صفوف متناوبة صريحة (بدلاً من ترك EnableAppearanceEvenRow يعتمد على لون السمة
            // الافتراضي غير المعروف) — لازمة حتى نستطيع مطابقتها بدقة في GridView1_RowCellStyle أدناه.
            gridView1.Appearance.Row.BackColor = DesignSystem.Colors.Surface;
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.BackColor = DesignSystem.Colors.Background;
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;

            // خلفية أعمدة الأزرار (طباعة/إجراء/سجل) تتغيّر تلقائياً عند تركيز/تحديد الصف (سلوك DevExpress
            // الافتراضي للخلية المركَّزة، وله أولوية أعلى من AppearanceCell العادي) — نعيدها دائماً للون
            // الصف الطبيعي (فردي/زوجي) عبر RowCellStyle الذي يُستدعى مع كل رسم للخلية ويتجاوز مظهر
            // التركيز/التحديد، بدل استخدام لون ثابت واحد لا يطابق تناوب الصفوف.
            gridView1.RowCellStyle += GridView1_RowCellStyle;

            // عند النقر المزدوج → فتح السجل للعرض/الاعتماد فقط (نفس bbiOpen)، لا فتح نموذج التعديل الكامل
            gridView1.DoubleClick += (s, e) => OpenFocusedForAction();

            // تحديث حالة الأزرار عند تغيير الصف
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();

            // عمود colPrint → طباعة الطلب المُركَّز عليه مباشرة بدون فتح النموذج
            repositoryItemButtonEditPrint.ButtonClick += (s, e) =>
            {
                if (!_canPrint)
                {
                    XtraMessageBox.Show("ليس لديك صلاحية طباعة طلب الشراء.", "غير مصرَّح",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (gridView1.GetFocusedRow() is PurchaseRequestList pr)
                {
                    var handle = ShowOverlay();
                    try { PurchaseRequestPrinter.Print(pr.Id); }
                    finally { CloseOverlay(handle); }
                }
            };

            // عمود colAction → فتح النموذج على هذا الطلب للاعتماد/الرفض فقط، بلا إمكانية تعديل البيانات
            repositoryItemButtonEditAction.ButtonClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is PurchaseRequestList pr)
                    OpenForAction(pr.Id);
            };

            // عمود colLog → عرض سجل إجراءات الاعتماد/الرفض لهذا الطلب. مؤشر الانتظار يلف الإنشاء تحديداً
            // (LoadData داخل الـ constructor تُنفِّذ عدة استعلامات قبل ظهور النافذة)، لا ShowDialog نفسها
            // التي تحجب الخيط أصلاً وتُظهر نافذة مرئية فور اكتمالها.
            repositoryItemButtonEditLog.ButtonClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is not PurchaseRequestList pr) return;

                var handle = ShowOverlay();
                frmPurchaseRequestLog frm;
                try { frm = new frmPurchaseRequestLog(pr.Id); }
                finally { CloseOverlay(handle); }

                frm.ShowDialog(this);
            };
        }

        // ── tbMain (بطاقات الحالة) ───────────────────────────────────────────
        // مطابقة "حالة أمر الشراء" (PurchaseRequestOrderProgress.GetPurchaseOrderStatusDisplay) — دوال
        // بدل تكرار نفس الشرط في مكانين (الفلتر والعدّاد) كما وقع سابقاً مع بطاقات خطوات الاعتماد.
        // "قيد اعتماد" مطابقة بالبداية فقط (StartsWith) لأنها تحمل اسم خطوة سير عمل أمر الشراء الفعلي
        // بعدها ("تحت إجراء {اسم الخطوة}")، و"جزئي"/"كلي" مطابقة بالاحتواء (Contains) لتجاوز أي علامة
        // ✓ أو تنسيق إضافي يُضاف للنص.
        // "لم يبدأ" وحدها (بخلاف قيد اعتماد/جزئي/كلي، التي تستلزم أمر شراء فعلي قائم أصلاً ولا يمكن إصداره
        // إلا لطلب معتمد) هي الحالة الافتراضية لأي طلب بلا أمر شراء بعد — بما فيها المسودة/قيد الاعتماد/
        // المرفوض (انظر PurchaseRequestOrderProgress.GetPurchaseOrderStatusDisplay، عمداً مستقلة عن حالة
        // الاعتماد). بطاقة "لم يبدأ" في الشاشة تعني تحديداً الطلبات المعتمدة التي لم يُصدر لها أمر شراء
        // بعد (وهي الفعل المطلوب من المستخدم)، لا كل طلب لم يُعتمد أصلاً بعد.
        private static bool IsPoNotStarted(PurchaseRequestList r)      => r.OverallStatus == PurchaseRequestStatus.Approved && r.PurchaseOrderStatusDisplay == "لم يبدأ";
        private static bool IsPoPendingApproval(PurchaseRequestList r) => r.PurchaseOrderStatusDisplay?.StartsWith("تحت إجراء") == true;
        private static bool IsPoPartial(PurchaseRequestList r)         => r.PurchaseOrderStatusDisplay?.Contains("جزئي") == true;
        private static bool IsPoFull(PurchaseRequestList r)            => r.PurchaseOrderStatusDisplay?.Contains("كلي") == true;
        private static bool IsPoRejected(PurchaseRequestList r)        => r.PurchaseOrderStatusDisplay?.Contains("مرفوض") == true;

        // نفس المشكلة/المنطق أعلاه لبطاقة "لم يبدأ" في صفّ حالة أمر الشراء تتكرر هنا: DeliveryStatus =
        // "لم يبدأ" هي القيمة الافتراضية لأي طلب بلا استلام بعد (انظر PurchaseRequestDeliveryStatus.
        // Recompute — نفس القيمة سواء لم يُصدر أمر شراء أصلاً أو صدر ولم يُستلم منه شيء بعد). بطاقة "توريد
        // لم يبدأ" تعني تحديداً الطلبات التي صدر لها أمر شراء (جزئي أو كلي) لكن لم يبدأ استلامها فعلياً —
        // لا كل طلب بلا أمر شراء من الأساس (تلك تخصّ بطاقات صفّ "أمر الشراء" لا صفّ "التوريد").
        private static bool IsDeliveryNotStarted(PurchaseRequestList r) =>
            (IsPoPartial(r) || IsPoFull(r)) && r.DeliveryStatus == PurchaseRequestDeliveryStatus.NotStarted;

        /// <summary>يربط كل بطاقة في tbMain بفلترها الخاص على الشبكة: "إجمالي" بلا فلتر، الخمس
        /// بطاقات الوسطى بخطوة سير العمل الحالية للطلب (نص StatusDisplay كما ينتجه
        /// PurchaseRequestWorkflowSync)، و"معتمد"/"مرفوض" بـ OverallStatus النهائي مباشرة (لا يعتمدان
        /// على وجود سير عمل نشط أصلاً).</summary>
        private void WireTileBar()
        {
            tbiTotal.ItemClick += (s, e) => ApplyTileFilter(tbiTotal, null);
            tbiDraft.ItemClick += (s, e) =>
                ApplyTileFilter(tbiDraft, r => r.OverallStatus == PurchaseRequestStatus.Draft);
            WireStepTile(tbiUnderStoreOfficer);
            WireStepTile(tbiUnderDisciplineEngineer);
            WireStepTile(tbiUnderProjectManager);
            WireStepTile(tbiUnderCostDept);
            WireStepTile(tbiUnderProjectsDirector);
            tbiApproved.ItemClick += (s, e) =>
                ApplyTileFilter(tbiApproved, r => r.OverallStatus == PurchaseRequestStatus.Approved);
            tbiRejected.ItemClick += (s, e) =>
                ApplyTileFilter(tbiRejected, r => r.OverallStatus == PurchaseRequestStatus.Rejected);

            tbiPoNotStarted.ItemClick      += (s, e) => ApplyTileFilter(tbiPoNotStarted, IsPoNotStarted);
            tbiPoPendingApproval.ItemClick += (s, e) => ApplyTileFilter(tbiPoPendingApproval, IsPoPendingApproval);
            tbiPoPartial.ItemClick         += (s, e) => ApplyTileFilter(tbiPoPartial, IsPoPartial);
            tbiPoFull.ItemClick            += (s, e) => ApplyTileFilter(tbiPoFull, IsPoFull);
            tbiPoRejected.ItemClick        += (s, e) => ApplyTileFilter(tbiPoRejected, IsPoRejected);

            tbiDeliveryNotStarted.ItemClick += (s, e) =>
                ApplyTileFilter(tbiDeliveryNotStarted, IsDeliveryNotStarted);
            tbiDeliveryPartial.ItemClick += (s, e) =>
                ApplyTileFilter(tbiDeliveryPartial, r => r.DeliveryStatus == PurchaseRequestDeliveryStatus.Partial);
            tbiDeliveryComplete.ItemClick += (s, e) =>
                ApplyTileFilter(tbiDeliveryComplete, r => r.DeliveryStatus == PurchaseRequestDeliveryStatus.Complete);
        }

        /// <summary>يربط إحدى البطاقات الخمس الوسطى (تحت إجراء ...) بفلتر يطابق StatusDisplay مع
        /// عنوانها هي نفسها (Elements[0].Text) — يُقرأ العنوان مرة عند الربط (لا يتغيّر بعدها في حياة
        /// الشاشة)، فلا حاجة لتكراره في كود منفصل يُمكن أن يخرج عن التزامن مع الـ Designer.</summary>
        private void WireStepTile(DevExpress.XtraBars.Navigation.TileBarItem tile)
        {
            string stepCaption = tile.Elements[0].Text;
            tile.ItemClick += (s, e) => ApplyTileFilter(tile, r => r.StatusDisplay == stepCaption);
        }

        /// <summary>النقر على البطاقة المُفعَّلة بالفعل يُلغي الفلتر (يعيد الشبكة لعرض الكل) بدل تكراره —
        /// تبديل تشغيل/إيقاف بدل الاضطرار للرجوع إلى "إجمالي" في كل مرة.</summary>
        private void ApplyTileFilter(DevExpress.XtraBars.Navigation.TileBarItem tile, Func<PurchaseRequestList, bool>? predicate)
        {
            bool isTogglingOff = _activeTile == tile && predicate != null;
            _activeTile = isTogglingOff ? null : (predicate == null ? null : tile);
            _activeTileFilter = isTogglingOff ? null : predicate;
            RefreshGridFilter();
        }

        /// <summary>يُطبَّق الفلتر النشط (إن وُجد) على _allRecords ويعيد ربط الشبكة به — يُستدعى من
        /// ApplyTileFilter عند نقر بطاقة، ومن LoadData بعد كل تحميل بيانات جديد كي لا يُفقد الفلتر
        /// النشط عند الضغط على "تحديث" أو إغلاق نافذة إضافة/تعديل.</summary>
        private void RefreshGridFilter()
        {
            _visibleRecords = _activeTileFilter == null
                ? _allRecords
                : _allRecords.Where(_activeTileFilter).ToList();
            gridControl1.DataSource = _visibleRecords;
        }

        /// <summary>يُحدِّث عدّاد كل بطاقة في tbMain من _allRecords الحالية (بلا تأثير الفلتر النشط —
        /// الأعداد دائماً عن إجمالي الطلبات المُحمَّلة، لا عن الصفوف المعروضة فقط).</summary>
        private void UpdateTileCounts()
        {
            tbiTotal.Elements[1].Text = _allRecords.Count.ToString();
            tbiDraft.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == PurchaseRequestStatus.Draft).ToString();
            UpdateStepTileCount(tbiUnderStoreOfficer);
            UpdateStepTileCount(tbiUnderDisciplineEngineer);
            UpdateStepTileCount(tbiUnderProjectManager);
            UpdateStepTileCount(tbiUnderCostDept);
            UpdateStepTileCount(tbiUnderProjectsDirector);
            tbiApproved.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == PurchaseRequestStatus.Approved).ToString();
            tbiRejected.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == PurchaseRequestStatus.Rejected).ToString();

            tbiPoNotStarted.Elements[1].Text      = _allRecords.Count(IsPoNotStarted).ToString();
            tbiPoPendingApproval.Elements[1].Text = _allRecords.Count(IsPoPendingApproval).ToString();
            tbiPoPartial.Elements[1].Text         = _allRecords.Count(IsPoPartial).ToString();
            tbiPoFull.Elements[1].Text            = _allRecords.Count(IsPoFull).ToString();
            tbiPoRejected.Elements[1].Text         = _allRecords.Count(IsPoRejected).ToString();

            tbiDeliveryNotStarted.Elements[1].Text = _allRecords.Count(IsDeliveryNotStarted).ToString();
            tbiDeliveryPartial.Elements[1].Text    = _allRecords.Count(r => r.DeliveryStatus == PurchaseRequestDeliveryStatus.Partial).ToString();
            tbiDeliveryComplete.Elements[1].Text   = _allRecords.Count(r => r.DeliveryStatus == PurchaseRequestDeliveryStatus.Complete).ToString();
        }

        /// <summary>يحسب عدّاد إحدى البطاقات الخمس الوسطى مطابقاً StatusDisplay مع عنوانها هي نفسها
        /// (Elements[0].Text) — نفس منطق WireStepTile، لضمان أن الفلتر والعدّاد يطابقان دائماً نفس
        /// النص بلا احتمال اختلاف بينهما.</summary>
        private void UpdateStepTileCount(DevExpress.XtraBars.Navigation.TileBarItem tile)
        {
            string stepCaption = tile.Elements[0].Text;
            tile.Elements[1].Text = _allRecords.Count(r => r.StatusDisplay == stepCaption).ToString();
        }

        private void GridView1_RowCellStyle(object? sender, RowCellStyleEventArgs e)
        {
            if (e.Column != colPrint && e.Column != colAction && e.Column != colLog) return;

            // نفس قاعدة التناوب التي يعتمدها EnableAppearanceEvenRow داخلياً (حسب RowHandle)، لضمان
            // تطابق لون هذه الأعمدة تماماً مع بقية خلايا نفس الصف في حالته الطبيعية غير المركَّز عليها.
            bool isEvenRow = e.RowHandle % 2 != 0;
            e.Appearance.BackColor = isEvenRow ? gridView1.Appearance.EvenRow.BackColor : gridView1.Appearance.Row.BackColor;
            e.Appearance.Options.UseBackColor = true;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                string filter = "IsDelete = 0";
                var raw = lookUpEditPrj.EditValue as int?;

                // Id = 0 أو غير محدَّد هو رمز خيار "-- الكل --" (انظر SetupLookups): يعني كل المشاريع
                // المصرَّح للمستخدم بالاطلاع عليها + كل طلبات الإدارات (بلا تقييد صلاحيات، انظر SetupLookups).
                // قيمة موجبة = مشروع محدَّد، قيمة سالبة = إدارة محدَّدة (نفس ترميز PrjSourceOption).
                object queryParams;
                if (raw is > 0)
                {
                    filter += " AND PrjId = @Id";
                    queryParams = new { Id = raw };
                }
                else if (raw is < 0)
                {
                    filter += " AND DeptId = @Id";
                    queryParams = new { Id = -raw };
                }
                else
                {
                    var ids = _grantedProjectIds.Count > 0 ? string.Join(",", _grantedProjectIds) : "-1";
                    filter += $" AND (PrjId IN ({ids}) OR DeptId IS NOT NULL)";
                    queryParams = new { };
                }

                _allRecords =dc.PurchaseRequestList.GetBy(filter, queryParams)
                                .OrderByDescending(r => r.RequestDate)
                                .ThenByDescending(r => r.Id)
                                .ToList();

                var projects = dc.ProjectsList.GetBy("IsDelete = 0").ToDictionary(p => p.Id);
                var departments = dc.DepartmentsList.GetBy("IsDelete = 0").ToDictionary(d => d.Id);

                // يزامن كل الطلبات "قيد الاعتماد" مع نتيجة إجراء الاعتماد إن انتهى منذ آخر تحميل، ويحسب
                // نص الحالتين (اعتماد/أمر شراء) لكل الصفوف دفعة واحدة بدل استعلام منفصل لكل صف (كانت تكلف
                // ما يصل إلى 8 رحلات قاعدة بيانات لكل طلب — أبطأت الشاشة بشكل ملحوظ مع كبر عدد الطلبات).
                var statusDisplayById = PurchaseRequestWorkflowSync.ReconcileAndGetStatusDisplayBulk(dc, _allRecords);
                var poStatusDisplayById = PurchaseRequestOrderProgress.GetPurchaseOrderStatusDisplayBulk(dc, _allRecords);

                foreach (var pr in _allRecords)
                {
                    pr.StatusDisplay = statusDisplayById.GetValueOrDefault(pr.Id);
                    pr.PurchaseOrderStatusDisplay = poStatusDisplayById.GetValueOrDefault(pr.Id);
                    pr.FormattedNum = PurchaseRequestPrinter.FormatPRNumber(pr.Num, pr.RequestDate);
                    pr.ProjectName = pr.DeptId is > 0 && departments.TryGetValue(pr.DeptId.Value, out var dept) ? dept.Name
                        : pr.PrjId is > 0 && projects.TryGetValue(pr.PrjId.Value, out var prj) ? prj.Name : null;
                }

                RefreshGridFilter();

                UpdateTileCounts();
                UpdateStatusBar();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل البيانات:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // ── Toolbar Button Handlers ───────────────────────────────────────────
        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenAddEdit(0);

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => EditSelectedRecord();

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => DeleteSelectedRecords();

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => PrintGrid();

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => LoadData();

        private void bbiAction_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => ShowBulkActionMenu();

        private void bbiOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenFocusedForAction();

        /// <summary>"فتح" — يفتح السجل المُركَّز عليه للعرض فقط بلا تعديل (نفس آلية colAction: طباعة/اعتماد
        /// إن وُجدت صلاحية، لكن بلا تعديل بيانات) — البديل المتاح دائماً بغض النظر عن حالة القفل. مستخدَم من
        /// bbiOpen وأيضاً من النقر المزدوج على الشبكة (بدل فتح نموذج التعديل الكامل).</summary>
        private void OpenFocusedForAction()
        {
            int id = GetFocusedId();
            if (id <= 0)
            {
                XtraMessageBox.Show("يرجى تحديد سجل أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenForAction(id);
        }

        // ── Record Operations ─────────────────────────────────────────────────
        // ملاحظة: هذه هي نقطة الدخول الموحّدة للإضافة/التعديل (من bbiNew وEditSelectedRecord، ومن
        // النقر المزدوج على الشبكة الذي لا يمر عبر حالة تفعيل bbiEdit) — الفحص هنا (وليس فقط عبر
        // bbiNew/bbiEdit.Enabled) يمنع تجاوز الصلاحية عبر النقر المزدوج.
        private void OpenAddEdit(int prId)
        {
            bool allowed = prId == 0 ? _canAdd : _canSave;
            if (!allowed)
            {
                XtraMessageBox.Show(prId == 0
                    ? "ليس لديك صلاحية إضافة طلب شراء جديد."
                    : "ليس لديك صلاحية تعديل طلب الشراء.",
                    "غير مصرَّح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // منشئ frmPurchaseRequestAddEdit ثم OpenForEdit يحمّلان بيانات السجل من قاعدة البيانات مباشرةً
            // قبل ظهور النافذة — مؤشر الانتظار هنا يغطي تلك اللحظة، لا بعد ظهور النافذة.
            var loadHandle = ShowOverlay();
            frmPurchaseRequestAddEdit frm;
            try
            {
                frm = new frmPurchaseRequestAddEdit();
                if (prId > 0) frm.OpenForEdit(prId);
            }
            finally { CloseOverlay(loadHandle); }
            // غير مقفلة (Show وليس ShowDialog) للسماح بالتنقل في باقي البرنامج أثناء فتحها؛ الفحص هنا
            // يحمي من تحديث قائمة تم إغلاق تابها بالفعل قبل إغلاق شاشة الطلب.
            frm.FormClosed += (s, e) => { if (!IsDisposed) ReloadAndFocus(frm.CurrentPrId); };
            frm.Show(this.FindForm());
        }

        /// <summary>Opens the AddEdit form on a specific PR for approval action only (colAction column) —
        /// header/detail data is locked read-only; only viewing, printing, and approve/reject remain usable.</summary>
        private void OpenForAction(int prId)
        {
            var loadHandle = ShowOverlay();
            frmPurchaseRequestAddEdit frm;
            try
            {
                frm = new frmPurchaseRequestAddEdit();
                frm.OpenForAction(prId);
            }
            finally { CloseOverlay(loadHandle); }
            frm.FormClosed += (s, e) => { if (!IsDisposed) ReloadAndFocus(frm.CurrentPrId); };
            frm.Show(this.FindForm());
        }

        /// <summary>Reloads the grid then refocuses/scrolls to the record that was just added/edited/acted
        /// on (see frmPurchaseRequestAddEdit.CurrentPrId) instead of leaving the grid on whatever row
        /// happened to be focused before — LoadData() rebinds gridControl1.DataSource entirely, which
        /// otherwise loses the user's place every time an AddEdit/action window closes. No-op (silently
        /// keeps whatever the grid defaults to) if the id is 0 (a new record that was never actually
        /// saved) or no longer present (e.g. deleted from another session).</summary>
        private void ReloadAndFocus(int prId)
        {
            LoadData();
            if (prId <= 0) return;

            // قد يكون السجل غير موجود ضمن _visibleRecords إن أخرجه الإجراء (اعتماد/رفض) من نطاق فلتر
            // بطاقة نشطة في tbMain (مثلاً: طلب اعتُمِد بينما بطاقة "تحت إجراء مسئول المخازن" مفعَّلة) —
            // لا نغيّر الفلتر لأجله، فقط لا نُحرِّك التركيز (نفس سلوك "لم يُعثر عليه" الأصلي).
            int rowIndex = _visibleRecords.FindIndex(r => r.Id == prId);
            if (rowIndex < 0) return;

            int handle = gridView1.GetRowHandle(rowIndex);
            gridView1.FocusedRowHandle = handle;
            gridView1.MakeRowVisible(handle);
        }

        private void EditSelectedRecord()
        {
            int id = GetFocusedId();
            if (id <= 0)
            {
                XtraMessageBox.Show("يرجى تحديد سجل أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(id);
        }

        private void DeleteSelectedRecords()
        {
            if (!_canDelete)
            {
                XtraMessageBox.Show("ليس لديك صلاحية حذف طلبات الشراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedIds = GetSelectedIds();
            if (selectedIds.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد سجل واحد على الأقل للحذف.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // منع حذف الطلبات المعتمدة أو المحوّلة لأمر شراء
            var locked = _allRecords
                .Where(r => selectedIds.Contains(r.Id) && r.OverallStatus == PurchaseRequestStatus.Approved)
                .Select(r => PurchaseRequestPrinter.FormatPRNumber(r.Num, r.RequestDate))
                .ToList();

            if (locked.Any())
            {
                XtraMessageBox.Show(
                    $"لا يمكن حذف الطلبات التالية (معتمدة أو محوّلة لأمر شراء):\n{string.Join(", ", locked)}",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg = selectedIds.Count == 1
                ? "هل أنت متأكد من حذف طلب الشراء المحدد؟"
                : $"هل أنت متأكد من حذف {selectedIds.Count} طلبات شراء؟";

            if (XtraMessageBox.Show(msg, "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int successCount = 0;
            var handle = ShowOverlay();
            try
            {
                foreach (var id in selectedIds)
                {
                    try
                    {
                       dc.DeletePurchaseRequest(id);
                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ عند حذف طلب #{id}:\n{ex.Message}", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally { CloseOverlay(handle); }

            if (successCount > 0)
            {
                XtraMessageBox.Show($"تم حذف {successCount} طلبات بنجاح ✓", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void PrintGrid()
        {
            if (!_canPrint)
            {
                XtraMessageBox.Show("ليس لديك صلاحية طباعة طلبات الشراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // يطبع صفوف الشبكة كما هي معروضة حالياً (بعد أي فرز/تصفية على مستوى الشبكة)، لا كل
                // _allRecords المُحمَّلة، عبر تقرير rprPurchaseRequestLog بدلاً من طباعة الشبكة مباشرة.
                var rows = new List<PurchaseRequestList>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRow(gridView1.GetVisibleRowHandle(i)) is PurchaseRequestList pr)
                        rows.Add(pr);
                }

                if (rows.Count == 0)
                {
                    XtraMessageBox.Show("لا توجد بيانات للطباعة.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var handle = ShowOverlay();
                try { PurchaseRequestPrinter.PrintLog(rows); }
                finally { CloseOverlay(handle); }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Bulk Actions ──────────────────────────────────────────────────────
        private void ShowBulkActionMenu()
        {
            var selectedIds = GetSelectedIds();
            if (selectedIds.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد سجل واحد على الأقل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // لا نتخلّص من القائمة (لا "using" ولا Dispose يدوي عبر Closed) — القائمة تُعرض بشكل غير
            // متزامن، وأي تخلّص منها في توقيت غير مضمون بالنسبة لمعالج نقر العنصر يسبب
            // ObjectDisposedException. كائن صغير قصير العمر، تركه لجامع المهملات هو الخيار الآمن.
            var menu = new ContextMenuStrip();
            menu.RightToLeft = RightToLeft.Yes;
            menu.Font = DesignSystem.Fonts.Regular(9);

            // اعتماد/رفض لم يعودا إجراءً جماعياً — كل طلب يمر بسلسلة خطوات معتمدين مُسمّين، فيقرر كل
            // خطوة معتمدها بنفسه من نافذة الطلب أو من تبويب "مهامي" (انظر PurchaseRequestWorkflowSync).
            // كل عنصر يظهر فقط إن ملك المستخدم صلاحيته (بدل إظهاره دائماً ثم رفضه عند الضغط).
            if (_canSend)
                menu.Items.Add($"📤 إرسال {selectedIds.Count} طلبات للاعتماد", null,
                    (s, e) => BulkSendForApproval(selectedIds));

            if (_canSend && _canExport)
                menu.Items.Add(new ToolStripSeparator());

            if (_canExport)
                menu.Items.Add("📊 تصدير إلى Excel", null,
                    (s, e) => ExportToExcel());

            if (menu.Items.Count == 0)
            {
                XtraMessageBox.Show("ليس لديك صلاحية أي إجراء متاح هنا.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            menu.Show(Cursor.Position);
        }

        private void BulkSendForApproval(List<int> ids)
        {
            if (!_canSend)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إرسال طلبات الشراء للاعتماد.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(
                $"هل تريد إرسال {ids.Count} طلبات للاعتماد؟",
                "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            // مُحلَّل لكل طلب على حدة (وليس مرة واحدة قبل الحلقة) — منذ إضافة محددي المشروع/التخصص على
            // تعريف الإجراء، قد يختلف الإجراء المطابق من طلب لآخر ضمن نفس الدفعة (مشاريع/تخصصات مختلفة)،
            // فلم يعد صحيحاً افتراض إجراء واحد يصلح للجميع. انظر PurchaseRequestWorkflowSync.GetAvailableProcedures.
            int done = 0;
            var handle = ShowOverlay();
            try
            {
                foreach (var id in ids)
                {
                    try
                    {
                        var pr = dc.PurchaseRequestList.Find(id);
                        if (pr == null) continue;

                        var candidates = PurchaseRequestWorkflowSync.GetAvailableProcedures(dc, pr);
                        if (candidates.Count == 0)
                        {
                            XtraMessageBox.Show(
                                $"لا يوجد إجراء اعتماد معرَّف مطابق لطلب #{id} (المشروع/التخصص). تم تخطيه.",
                                "تعذّر الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        int workflowDefinitionId;
                        if (candidates.Count == 1)
                        {
                            workflowDefinitionId = candidates[0].Id;
                        }
                        else
                        {
                            using var picker = new frmWorkflowDefinitionSelect(candidates);
                            if (picker.ShowDialog(this) != DialogResult.OK) continue;
                            workflowDefinitionId = picker.SelectedDefinitionId;
                        }

                        PurchaseRequestWorkflowSync.SendForApproval(dc, pr, workflowDefinitionId);

                        pr.OverallStatus = PurchaseRequestStatus.PendingApproval;
                        pr.UpdateDate    = DateTime.Now;
                        pr.UpdateMachine = Session.Machine;
                        pr.UpdateBy      = Session.CurrentUser?.Id ?? 1;

                        dc.PurchaseRequestList.Edit(id, pr);
                        done++;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ عند إرسال طلب #{id}:\n{ex.Message}", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally { CloseOverlay(handle); }

            if (done > 0)
            {
                XtraMessageBox.Show($"✓ تم إرسال {done} طلبات للاعتماد", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void ExportToExcel()
        {
            if (!_canExport)
            {
                XtraMessageBox.Show("ليس لديك صلاحية تصدير طلبات الشراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new SaveFileDialog
            {
                Filter      = "Excel Files|*.xlsx",
                FileName    = $"طلبات_الشراء_{DateTime.Today:yyyy-MM-dd}.xlsx",
                DefaultExt  = "xlsx"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                gridControl1.ExportToXlsx(dlg.FileName);
                XtraMessageBox.Show("تم التصدير بنجاح ✓", "تصدير",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التصدير:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private int GetFocusedId()
        {
            var row = gridView1.GetFocusedRow() as PurchaseRequestList;
            return row?.Id ?? 0;
        }

        private List<int> GetSelectedIds()
        {
            var ids = new List<int>();

            var selectedHandles = gridView1.GetSelectedRows();
            if (selectedHandles != null && selectedHandles.Length > 0)
            {
                foreach (int h in selectedHandles)
                {
                    if (gridView1.GetRow(h) is PurchaseRequestList pr)
                        ids.Add(pr.Id);
                }
            }
            else
            {
                // Fall back to the focused row when nothing is multi-selected
                int id = GetFocusedId();
                if (id > 0) ids.Add(id);
            }

            return ids;
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = gridView1.FocusedRowHandle >= 0 && _allRecords.Count > 0;

            // بمجرد إنشاء أمر شراء من الطلب، يُقفل التعديل والحذف (انظر PurchaseRequestLock) — يبقى
            // "فتح" متاحاً دائماً للعرض فقط بدلاً منهما.
            var focused = gridView1.GetFocusedRow() as PurchaseRequestList;
            bool locked = focused != null && PurchaseRequestLock.IsLocked(dc, focused);

            bbiEdit.Enabled   = hasSelection && !locked && _canSave;
            bbiDelete.Enabled = hasSelection && !locked && _canDelete;
            bbiOpen.Enabled   = hasSelection;
            bbiPrint.Enabled  = _allRecords.Count > 0 && _canPrint;
        }

        private void UpdateStatusBar()
        {
            bar3.Text = $"إجمالي الطلبات: {_allRecords.Count}  |  " +
                        $"قيد الاعتماد: {_allRecords.Count(r => r.OverallStatus == PurchaseRequestStatus.PendingApproval)}  |  " +
                        $"معتمد: {_allRecords.Count(r => r.OverallStatus == PurchaseRequestStatus.Approved)}";
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        // نفس نمط ShowOverlay/CloseOverlay المعتمد في frmMARAddEdit/frmCIRAddEdit وأُضيف حديثاً إلى
        // منظومة أوامر الشراء — يعرض مؤشراً دوّاراً فوق هذه الشاشة أثناء أي عملية تلمس قاعدة البيانات.
        //
        // أول استدعاء يأتي من this.Load (LoadData في المُنشئ) قبل أن يصبح هذا التبويب هو التبويب
        // النشط فعلياً: OpenTab في frmMainPage يستدعي tabbedView1.AddDocument(uc) أولاً (فيُنشأ الـ Handle
        // وتُطلَق Load) ثم Controller.Activate(doc) بعدها — فإن كان هناك تبويب آخر مفتوح مسبقاً يبقى uc
        // غير Visible خلال تلك اللحظة، ويرمي SplashScreenManager.ShowOverlayForm استثناءً صريحاً بهذه
        // الحالة. لا داعي لعرض المؤشر أصلاً إن كانت الشاشة غير ظاهرة بعد، فنتجاوزه بدل رميه.
        private IOverlaySplashScreenHandle? ShowOverlay() =>
            IsHandleCreated && Visible ? SplashScreenManager.ShowOverlayForm(this) : null;

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
