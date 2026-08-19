using System.ComponentModel;
using System.IO;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Add/Edit form for Purchase Requests: header + item details grid + attachments panel.</summary>
    public partial class frmPurchaseRequestAddEdit : DevExpress.XtraEditors.XtraForm
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext dc => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private int _prId = 0;                                        // 0 = New, >0 = Edit
        private byte[]? _rowVersion;                                  // concurrency token captured on load, see SqlDataHelper<T>
        private bool _isDirty = false;                                // Tracks unsaved changes
        private List<PurchaseRequestList> _purchaseList = new();        // Navigator cache
        private int _currentIndex = -1;                               // Current navigator position

        private BindingList<PurchaseRequestDetails> _details = new(); // Detail grid in-memory list
        private List<int> _deletedDetailIds = new();                 // Detail rows pending deletion on save
        private List<ItemsList> _itemsCache = new();                  // Items lookup cache for the detail grid
        private Dictionary<int, ItemCategory> _categoriesById = new(); // للتصفية حسب جذر التصنيف (انظر ApplyItemTypeFilter)

        // نوع طلب الشراء (comboBoxEdit1) الآن مطابق تماماً لأسماء الجذور الخمسة الثابتة في تصنيفات الأصناف
        // (انظر ItemCategory.IsFixed / DatabaseInitializer.SeedData) — يُستخدم لتقييد قائمة الأصناف في
        // جدول البنود على جذر واحد فقط بدل عرض كل الأصناف بغض النظر عن نوع الطلب.
        private static readonly Dictionary<string, string> TypeToRootCode = new()
        {
            { "المواد", "M" },
            { "المقاولين", "C" },
            { "الخدمات", "S" },
            { "المعدات", "E" },
            { "الايجارات", "R" },
        };
        private ucAttachmentAddEdit? _ucAttachments;                  // Embedded attachments panel ("المرفقات" تبويب)
        private bool _readOnly = false;                               // true عند الفتح من colAction: عرض + اعتماد/رفض فقط، بلا تعديل بيانات

        // صلاحيات مستقلة لكل زر (انظر PermNames.PRAdd وما يليها) — منفصلة عن صلاحية دخول الشاشة نفسها
        // (PermNames.PurchaseRequest، التي تحكم فقط ظهور شاشة/قائمة طلبات الشراء من الشريط الرئيسي —
        // انظر frmMainPage)، بحيث يمكن منح مستخدم حق العرض فقط بلا أي زر من هذه، أو حق زر واحد دون
        // بقيتها. اعتماد/رفض/إعادة أثناء الاعتماد (bbiApproved/bbiReject وحالة "إرجاع أثناء الاعتماد" من
        // bbiReturnToStep) تبقى خارج هذه المجموعة عمداً — تحكمها WorkflowEngine.CanUserAct وحدها.
        private bool _canAdd;
        private bool _canSave;
        private bool _canPrint;
        private bool _canSend;
        private bool _canDelete;
        private bool _canReturnForEdit;
        private bool _canClose;

        // بوابة "إعادة طلب معتمد بالكامل إلى خطوة سابقة" (bbiReturnToStep بعد الاعتماد) — منفصلة عمداً عن
        // الصلاحيات أعلاه: بعد الاعتماد الكامل لا يوجد "صاحب خطوة حالية" ليُفتح الإجراء مجدداً، فتُستخدم
        // صلاحية أوامر الشراء كبديل (من يملك حق إصدار أمر شراء هو من يقرر أن الطلب يحتاج إعادة قبل إصداره).
        private bool _canManagePO;

        // ── Constructor ───────────────────────────────────────────────────────
        public frmPurchaseRequestAddEdit()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManagePO = PermissionService.HasPermission(PermNames.PurchaseOrder);

            _canAdd = PermissionService.HasPermission(PermNames.PRAdd);
            _canSave = PermissionService.HasPermission(PermNames.PRSave);
            _canPrint = PermissionService.HasPermission(PermNames.PRPrint);
            _canSend = PermissionService.HasPermission(PermNames.PRSend);
            _canDelete = PermissionService.HasPermission(PermNames.PRDelete);
            _canReturnForEdit = PermissionService.HasPermission(PermNames.PRReturnForEdit);
            _canClose = PermissionService.HasPermission(PermNames.PRClose);

            bbiNew.Enabled = _canAdd;
            bbiPrint.Enabled = _canPrint;

            WireEvents();
            SetupLookups();
            SetupGrid();
            SetupAttachments();
            Loadlist();
            NewRecord();
        }

        // ── Public API ────────────────────────────────────────────────────────
        /// <summary>The PR currently shown (0 for an abandoned/never-saved new record) — read by the
        /// caller's FormClosed handler (see ucPurchaseRequests.OpenAddEdit/OpenForAction) to refocus the
        /// list grid on whichever record was just added/edited/acted on, instead of losing the user's
        /// place after every reload.</summary>
        public int CurrentPrId => _prId;

        /// <summary>Opens the form and navigates directly to an existing PR.</summary>
        public void OpenForEdit(int prId)
        {
            _currentIndex = _purchaseList.FindIndex(r => r.Id == prId);
            if (_currentIndex >= 0)
                LoadRecord(prId);
        }

        /// <summary>Opens the form on an existing PR for approval action only (colAction) — header/detail
        /// data is locked read-only; only viewing, printing, and the approval action menu remain usable.</summary>
        public void OpenForAction(int prId)
        {
            _readOnly = true;
            OpenForEdit(prId);
            ApplyReadOnlyMode();
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            // Main toolbar
            bbiNew.ItemClick += (s, e) =>
            {
                if (!_canAdd)
                {
                    XtraMessageBox.Show("ليس لديك صلاحية إضافة طلب شراء جديد.", "غير مصرَّح",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SafeAction(NewRecord);
            };
            bbiSave.ItemClick += (s, e) => SafeAction(() => SaveRecord());
            bbiPrint.ItemClick += (s, e) => PrintRecord();

            // bbiReAction/barSubItem1 كانا زر القائمة المنسدلة القديم (ShowActionMenu) — استُبدلا بأزرار
            // منفصلة لكل إجراء (أدناه)، فيُخفيان بدل حذف تعريفهما من الديزاينر.

            // كل إجراء أصبح زراً مستقلاً دائم الظهور، يُفعَّل/يُعطَّل حسب حالة الطلب — انظر
            // UpdateActionButtonStates (تحل محل ShowActionMenu وقائمتها المنسدلة السابقة).
            bbiSendForApproval.ItemClick += (s, e) => SafeAction(SendForApproval);
            bbiCloseRequest.ItemClick += (s, e) => SafeAction(() => ChangeStatus(PurchaseRequestStatus.Closed));
            bbiReturnForEdit.ItemClick += (s, e) => SafeAction(() => ChangeStatus(PurchaseRequestStatus.Draft));
            bbiDeleteRequest.ItemClick += (s, e) => SafeAction(DeleteCurrentRecord);

            // اعتماد/رفض سريعان لخطوة الإجراء الحالية — مفعّلان فقط عندما يملك المستخدم صلاحية
            // التصرف في الخطوة الحالية (انظر UpdateActionButtonStates)
            bbiApproved.ItemClick += (s, e) => SafeAction(() => ActOnCurrentStep("Approved"));
            bbiReject.ItemClick += (s, e) => SafeAction(() => ActOnCurrentStep("Rejected"));

            // إعادة الطلب إلى خطوة سابقة — أثناء الاعتماد (صاحب الخطوة الحالية) أو بعد الاعتماد الكامل
            // وقبل إصدار أمر شراء (صلاحية أوامر الشراء) — انظر ReturnToStep
            bbiReturnToStep.ItemClick += (s, e) => SafeAction(ReturnToStep);

            // Navigation
            bbiFirst.ItemClick += (s, e) => NavigateFirst();
            bbiPrev.ItemClick += (s, e) => NavigatePrev();
            bbiNext.ItemClick += (s, e) => NavigateNext();
            bbiLast.ItemClick += (s, e) => NavigateLast();

            // Search bar — press Enter in the embedded editor to fetch a record
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return && barEditItem1.EditValue != null)
                    FetchBySearch();
            };

            // Header dirty tracking
            // الحقول المطلوبة (خلفية خضراء) — تُعاد للأخضر تلقائياً فور تعبئتها إن كانت قد تحوّلت
            // لسالمون بسبب محاولة حفظ فاشلة (انظر ValidateRequiredFields).
            lookUpEditPrj.EditValueChanged += OnHeaderChanged;
            lookUpEditPrj.EditValueChanged += (s, e) => RevalidateField(lookUpEditPrj, IsFilled(lookUpEditPrj));
            lookUpEditDiscipline.EditValueChanged += OnHeaderChanged;
            lookUpEditDiscipline.EditValueChanged += (s, e) => RevalidateField(lookUpEditDiscipline, IsFilled(lookUpEditDiscipline));
            lookUpEditStore.EditValueChanged += (s, e) => RevalidateField(lookUpEditStore, IsFilled(lookUpEditStore));
            dateEditRequestDate.EditValueChanged += OnHeaderChanged;
            dateEditRequestDate.EditValueChanged += (s, e) => RevalidateField(dateEditRequestDate, dateEditRequestDate.EditValue != null);
            dateEditRequiredDate.EditValueChanged += OnHeaderChanged;
            memoEditPurpose.EditValueChanged += OnHeaderChanged;
            memoEditPurpose.EditValueChanged += (s, e) => RevalidateField(memoEditPurpose, !string.IsNullOrWhiteSpace(memoEditPurpose.Text));
            comboBoxEditPriority.EditValueChanged += OnHeaderChanged;
            comboBoxEdit1.EditValueChanged += OnHeaderChanged;
            comboBoxEdit1.EditValueChanged += (s, e) => ApplyItemTypeFilter();
            comboBoxEdit1.EditValueChanged += (s, e) => RevalidateField(comboBoxEdit1, IsFilled(comboBoxEdit1));

            // Detail grid shortcuts
            gridView.KeyDown += GridView_KeyDown;
            gridView.FocusedRowChanged += (s, e) => UpdateDetailButtonStates();
            gridView.SelectionChanged += (s, e) => UpdateDetailButtonStates();

            // Form closing guard
            this.FormClosing += FrmPurchaseRequestAddEdit_FormClosing;
        }

        /// <summary>Item backing lookUpEditPrj's merged project/department list — Id is encoded so a single
        /// LookUpEdit can offer both sources: positive = ProjectsList.Id, negative = -DepartmentsList.Id.
        /// See RefreshPrjSourceOptions/DecodePrjSource/EncodePrjSource.</summary>
        private class PrjSourceOption
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }

        private void SetupLookups()
        {
            // lookUpEditPrj → مصدر الطلب: مشروع أو إدارة طالبة، معاً في نفس القائمة (انظر PrjSourceOption)
            RefreshPrjSourceOptions();
            lookUpEditPrj.Properties.ValueMember = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.NullText = "-- اختر المشروع / الإدارة --";

            // lookUpEditStore → Stores (المخزن)
            lookUpEditStore.Properties.DataSource = dc.StoreList.GetBy("IsDelete = 0");
            lookUpEditStore.Properties.ValueMember = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText = "-- اختر المخزن --";

            // lookUpEditDiscipline → DisciplinesList — optional; used by
            // PurchaseRequestWorkflowSync.GetAvailableProcedures to route to a discipline-scoped procedure.
            lookUpEditDiscipline.Properties.DataSource = dc.DisciplinesList.GetBy("IsDelete = 0 AND IsActive = 1");
            lookUpEditDiscipline.Properties.ValueMember = "Id";
            lookUpEditDiscipline.Properties.DisplayMember = "Name";
            lookUpEditDiscipline.Properties.NullText = "-- اختر التخصص --";
        }

        /// <summary>(Re)builds lookUpEditPrj's merged data source from the current ProjectsList/DepartmentsList
        /// rows — called once at startup; department rows are simple master data with no per-user access
        /// control (unlike projects, which stay scoped elsewhere via Session.SelectedProjectId/UserProjectAccess).</summary>
        private void RefreshPrjSourceOptions()
        {
            var options = dc.ProjectsList.GetBy("IsDelete = 0")
                .Select(p => new PrjSourceOption { Id = p.Id, Name = p.Name ?? $"مشروع {p.Id}" })
                .Concat(dc.DepartmentsList.GetBy("IsDelete = 0")
                    .Select(d => new PrjSourceOption { Id = -d.Id, Name = $"(إدارة) {d.Name ?? $"إدارة {d.Id}"}" }))
                .ToList();

            lookUpEditPrj.Properties.DataSource = options;
        }

        /// <summary>Decodes lookUpEditPrj's current EditValue into (PrjId, DeptId) — exactly one is non-null,
        /// matching the encoding built by RefreshPrjSourceOptions (positive = project, negative = department).</summary>
        private (int? PrjId, int? DeptId) DecodePrjSource()
        {
            var raw = lookUpEditPrj.EditValue as int?;
            return raw switch
            {
                > 0 => (raw, null),
                < 0 => (null, -raw),
                _ => (null, null)
            };
        }

        // متتبع صف بداية السحب — تُبنى إعادة الترتيب هنا يدوياً عبر Drag&Drop القياسي لـ WinForms
        // لأن GridView الكلاسيكي في هذا الإصدار لا يوفر خاصية AllowRowDragDrop/RowDragDrop جاهزة.
        private int _dragRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle;

        private void SetupGrid()
        {
            DesignSystem.ApplyGridStyle(gridControl, gridView);
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            // إعادة ترتيب البنود بالسحب والإفلات — الترتيب الناتج يُحفظ في SortId عند الحفظ (انظر SaveDetails)
            gridControl.AllowDrop = true;
            gridControl.MouseDown += GcPR_MouseDown;
            gridControl.MouseMove += GcPR_MouseMove;
            gridControl.DragOver += GcPR_DragOver;
            gridControl.DragDrop += GcPR_DragDrop;

            SetupDetailColumnEditors();
            BindDetails(new List<PurchaseRequestDetails>());
        }

        private void GcPR_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = gridView.CalcHitInfo(new Point(e.X, e.Y));
            _dragRowHandle = (hit.InDataRow && hit.RowHandle >= 0)
                ? hit.RowHandle
                : DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        }

        private void GcPR_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (_dragRowHandle == DevExpress.XtraGrid.GridControl.InvalidRowHandle) return;

            var handle = _dragRowHandle;
            _dragRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
            gridControl.DoDragDrop(handle, DragDropEffects.Move);
        }

        private void GcPR_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data != null && e.Data.GetDataPresent(typeof(int)) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void GcPR_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetData(typeof(int)) is not int sourceHandle) return;
            var point = gridControl.PointToClient(new Point(e.X, e.Y));
            var hit = gridView.CalcHitInfo(point);
            if (!hit.InDataRow || hit.RowHandle < 0) return;

            int targetHandle = hit.RowHandle;
            if (sourceHandle == targetHandle) return;

            if (gridView.GetRow(sourceHandle) is not PurchaseRequestDetails draggedRow) return;
            if (gridView.GetRow(targetHandle) is not PurchaseRequestDetails targetRow) return;

            _details.Remove(draggedRow);
            int targetIndex = _details.IndexOf(targetRow);
            _details.Insert(targetIndex, draggedRow);

            gridView.FocusedRowHandle = gridView.GetRowHandle(_details.IndexOf(draggedRow));
            SetDirty();
        }

        private void SetupDetailColumnEditors()
        {
            _itemsCache = dc.ItemsList.GetBy("IsDelete = 0").OrderBy(i => i.Code).ToList();
            _categoriesById = dc.ItemCategory.GetBy("IsDelete = 0").ToDictionary(c => c.Id);

            // colItem → LookUp on ItemsList (اختيار الصنف) — القائمة تُصفّى حسب نوع طلب الشراء المختار
            // في الترويسة (انظر ApplyItemTypeFilter)، فلا نعيّن DataSource هنا مباشرة على _itemsCache كاملة.
            repositoryItemLookUpEditItem.ValueMember = "Id";
            repositoryItemLookUpEditItem.DisplayMember = "Code";
            repositoryItemLookUpEditItem.NullText = "";
            // يسمح بكتابة رمز/اسم الصنف يدوياً للبحث والتصفية داخل القائمة المنسدلة بدل الاقتصار على
            // التمرير فيها فقط — نفس الإعداد المستخدم في lookUpEdit بـ frmMARAddEdit/frmDrawingsAddEdit.
            repositoryItemLookUpEditItem.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            repositoryItemLookUpEditItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // لصق رمز صنف منسوخ من ملف خارجي (Ctrl+V) لا يطابقه محرك البحث الداخلي لـ DevExpress عند أول
            // خروج من الخلية (لا يُقرأ إلا بعد الخروج والعودة إليها مرة ثانية). GetNotInListValue يحل هذا
            // نهائياً: يُستدعى تحديداً عندما لا يطابق النص المكتوب/الملصوق أي عنصر ظاهر في القائمة، فنطابقه
            // صراحة مع رمز الصنف (بحث كامل في _itemsCache وليس فقط القائمة المصفّاة/المرئية) ونُرجع Id
            // الصنف مباشرة كقيمة الخلية.
            repositoryItemLookUpEditItem.GetNotInListValue += (s, e) =>
            {
                var text = e.Value?.ToString()?.Trim();
                if (string.IsNullOrEmpty(text)) return;

                var match = _itemsCache.FirstOrDefault(i => string.Equals(i.Code, text, StringComparison.OrdinalIgnoreCase));
                if (match != null) e.Value = match.Id;
            };
            colItem.ColumnEdit = repositoryItemLookUpEditItem;
            ApplyItemTypeFilter();

            // colUnit → LookUp على الوحدات (تُملأ تلقائياً من الصنف، غير قابلة للتعديل اليدوي)
            repositoryItemLookUpEditUnit.DataSource = dc.Units.GetBy("IsDelete = 0");
            repositoryItemLookUpEditUnit.ValueMember = "Id";
            repositoryItemLookUpEditUnit.DisplayMember = "Abbreviation";
            repositoryItemLookUpEditUnit.NullText = "";
            colUnit.ColumnEdit = repositoryItemLookUpEditUnit;

            // colCC → LookUp على مراكز التكلفة
            repositoryItemLookUpEditCC.DataSource = dc.CostCenterList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditCC.ValueMember = "Id";
            repositoryItemLookUpEditCC.DisplayMember = "Name";
            repositoryItemLookUpEditCC.NullText = "";
            colCC.ColumnEdit = repositoryItemLookUpEditCC;

            // colBudget → LookUp على بنود الموازنة
            repositoryItemLookUpEditBDG.DataSource = dc.BudgetList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditBDG.ValueMember = "Id";
            repositoryItemLookUpEditBDG.DisplayMember = "Description";
            repositoryItemLookUpEditBDG.NullText = "";

            // colAddItem → فتح قائمة الأصناف لاختيار عدة أصناف دفعة واحدة
            repositoryItemButtonEditAddItem.ButtonClick += RepositoryItemButtonEditAddItem_ButtonClick;

            // colDeleteItem → حذف البند المُركَّز عليه
            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            // عند اختيار الصنف: إكمال الوحدة والوصف تلقائياً لنفس الصف
            gridView.CellValueChanged += GvPR_CellValueChanged;
        }

        /// <summary>Restricts colItem's lookup to items whose category falls under the ItemCategory root
        /// matching the currently-selected "نوع طلب الشراء" (comboBoxEdit1) — e.g. "المواد" only shows
        /// items under the المواد(M) root, not المعدات/الايجارات/etc. Re-run whenever the type changes
        /// (see the EditValueChanged wiring in WireEvents) so the picker always reflects the current header
        /// value, including on initial load/new-record.</summary>
        private void ApplyItemTypeFilter()
        {
            var rootCode = TypeToRootCode.GetValueOrDefault(comboBoxEdit1.EditValue?.ToString() ?? "");
            repositoryItemLookUpEditItem.DataSource = string.IsNullOrEmpty(rootCode)
                ? _itemsCache
                : _itemsCache.Where(i => GetItemRootCode(i.CategoryId) == rootCode).ToList();
        }

        /// <summary>The single-letter root code (M/C/S/E/R) an item's category ultimately belongs to, read
        /// from the category's own Code — every non-root category's Code is prefixed with its root's letter
        /// by ItemCategoryCodeService, so no ParentId walk is needed. Null if the item has no category or
        /// the category's Code hasn't been (re)synced yet.</summary>
        private string? GetItemRootCode(int? categoryId) =>
            categoryId is > 0 && _categoriesById.TryGetValue(categoryId.Value, out var cat) && !string.IsNullOrEmpty(cat.Code)
                ? cat.Code[..1]
                : null;

        /// <summary>Embeds the reusable attachment control into the "المرفقات" tab's navigation frame.</summary>
        private void SetupAttachments()
        {
            _ucAttachments = new ucAttachmentAddEdit();
            SetupNavigationPage(_ucAttachments);
            _ucAttachments.SaveRequired += SaveAndReturnId;
            _ucAttachments.AttachmentsChanged += OnAttachmentsChanged;
        }

        /// <summary>Keeps a previously auto-exported approved-PR folder in sync when attachments are
        /// added/removed afterward — copies any not-yet-captured attachment revision (see
        /// PurchaseRequestPrinter.SyncAttachments) without bumping the PR's own PDF revision, since the
        /// PR's content itself didn't change. No-op if this PR isn't (yet) Approved or no export path is
        /// configured.</summary>
        private void OnAttachmentsChanged()
        {
            if (_prId <= 0) return;
            var pr = dc.PurchaseRequestList.Find(_prId);
            if (pr == null || pr.OverallStatus != PurchaseRequestStatus.Approved) return;

            var rootPath = Data.PurchaseRequestExportSettings.GetFolderPath(dc);
            if (!string.IsNullOrWhiteSpace(rootPath))
            {
                try
                {
                    PurchaseRequestPrinter.SyncAttachments(_prId, rootPath);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        $"تم تحديث المرفقات، لكن تعذر مزامنتها مع المسار المحدد بالإعدادات:\n{ex.Message}",
                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (Data.SharePointExportSettings.IsEnabled(dc))
            {
                try
                {
                    PurchaseRequestPrinter.SyncAttachmentsToSharePoint(_prId);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        $"تم تحديث المرفقات، لكن تعذر مزامنتها مع SharePoint:\n{ex.Message}",
                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SetupNavigationPage(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            var page = new DevExpress.XtraBars.Navigation.NavigationPage();
            page.Controls.Add(control);
            navigationFrame1.Pages.Add(page);
            navigationFrame1.SelectedPage = page;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _purchaseList = dc.PurchaseRequestList
                            .GetBy("IsDelete = 0")
                            .OrderByDescending(r => r.RequestDate)
                            .ThenByDescending(r => r.Id)
                            .ToList();
        }

        private void LoadRecord(int prId)
        {
            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // يزامن حالة الطلب مع نتيجة آخر إجراء اعتماد منتهٍ (إن لم تُكتب بعد) قبل عرضها
            PurchaseRequestWorkflowSync.Reconcile(dc, pr);

            _prId = prId;
            _rowVersion = pr.RowVersion;
            _isDirty = false; // pause dirty tracking while filling fields

            // مسح أي تلوين "سالمون" متبقٍّ من محاولة حفظ فاشلة سابقة قبل تحميل سجل مختلف.
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            // Header fields
            textEditNum.Text = PurchaseRequestPrinter.FormatPRNumber(pr.Num, pr.RequestDate);
            lookUpEditPrj.EditValue = pr.DeptId.HasValue ? -pr.DeptId.Value : pr.PrjId;
            lookUpEditStore.EditValue = pr.StoreId;
            lookUpEditDiscipline.EditValue = pr.DisciplineId;
            dateEditRequestDate.EditValue = pr.RequestDate;
            dateEditRequiredDate.EditValue = pr.RequiredDate;
            memoEditPurpose.EditValue = pr.Purpose;
            comboBoxEditPriority.EditValue = pr.Priority ?? "عادي";
            comboBoxEdit1.EditValue = pr.Type ?? "المواد";

            LoadDetails(prId);
            _ucAttachments?.LoadFor("PurchaseRequestList", _prId);

            SetEditLock(_readOnly || PurchaseRequestLock.IsLocked(dc, pr));

            UpdateNavigatorCaption();
            UpdateActionButtonStates();
            SetDirty(false);
        }

        /// <summary>Locks/unlocks header fields, the item-details grid, and Save. Used both for the permanent
        /// "view + act only" mode (OpenForAction) and dynamically per-record once a Purchase Order has been
        /// created from it (see LoadRecord) — always called with an explicit value so switching between a
        /// locked and an editable record via New/navigation doesn't leave a stale lock state behind.</summary>
        private void SetEditLock(bool locked)
        {
            lookUpEditPrj.Properties.ReadOnly = locked;
            lookUpEditStore.Properties.ReadOnly = locked;
            lookUpEditDiscipline.Properties.ReadOnly = locked;
            dateEditRequestDate.Properties.ReadOnly = locked;
            dateEditRequiredDate.Properties.ReadOnly = locked;
            memoEditPurpose.Properties.ReadOnly = locked;
            comboBoxEditPriority.Properties.ReadOnly = locked;
            comboBoxEdit1.Properties.ReadOnly = locked;

            gridView.OptionsBehavior.Editable = !locked;
            gridView.OptionsView.NewItemRowPosition = locked ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
            colAddItem.Visible = !locked;
            colDeleteItem.Visible = !locked;

            bbiSave.Enabled = !locked && _canSave;
        }

        /// <summary>Locks header fields, the item-details grid, and New/Save so the record can only be viewed
        /// and acted on (approve/reject/print) — used when opened via OpenForAction (grid's colAction button).</summary>
        private void ApplyReadOnlyMode()
        {
            SetEditLock(true);
            bbiNew.Enabled = false;
        }

        private void LoadDetails(int prId)
        {
            _deletedDetailIds.Clear();
            var list = dc.PurchaseRequestDetails
                         .GetBy("PRId = @id AND IsDelete = 0", new { id = prId })
                         .OrderBy(d => d.SortId ?? int.MaxValue)
                         .ThenBy(d => d.Id)
                         .ToList();

            BindDetails(list);
            UpdateDetailButtonStates();
        }

        /// <summary>Rebinds the detail grid to a fresh in-memory list and re-wires dirty tracking.</summary>
        private void BindDetails(List<PurchaseRequestDetails> source)
        {
            _details = new BindingList<PurchaseRequestDetails>(source);
            RenumberDetails();
            gridControl.DataSource = _details;
            _details.ListChanged += Details_ListChanged;
        }

        private void Details_ListChanged(object? sender, ListChangedEventArgs e)
        {
            SetDirty();

            // إعادة ترقيم عمود "م" تلقائياً عند أي إضافة أو حذف لبند (يشمل السحب والإفلات، الذي يُنفَّذ
            // كـ Remove ثم Insert — انظر GcPR_DragDrop)، بحيث يبقى الترقيم تسلسلياً من 1 دائماً.
            if (e.ListChangedType is ListChangedType.ItemAdded or ListChangedType.ItemDeleted)
                RenumberDetails();
        }

        /// <summary>Resets PurchaseRequestDetails.Num to a fresh 1..n sequence matching the grid's current
        /// display order for this request. Called on load and after every structural change to the detail
        /// list (add/delete/reorder) so item numbers always restart at 1 per Purchase Request.</summary>
        private void RenumberDetails()
        {
            for (int i = 0; i < _details.Count; i++)
                _details[i].Num = i + 1;

            gridView.RefreshData();
        }

        // ── Record Operations (New / Save / Delete) ──────────────────────────
        private void NewRecord()
        {
            _prId = 0;
            _rowVersion = null;
            _deletedDetailIds.Clear();
            _isDirty = false; // pause dirty tracking while filling defaults

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditNum.Text = "جديد";
            lookUpEditPrj.EditValue = Session.SelectedProjectId;
            dateEditRequestDate.EditValue = DateTime.Today;
            dateEditRequiredDate.EditValue = null;
            memoEditPurpose.EditValue = string.Empty;
            comboBoxEditPriority.EditValue = "عادي";
            comboBoxEdit1.EditValue = "المواد";

            BindDetails(new List<PurchaseRequestDetails>());
            _ucAttachments?.LoadFor("PurchaseRequestList", 0);
            SetEditLock(false); // سجل جديد دائماً قابل للتعديل، حتى لو كان آخر سجل مُعروض مقفلاً

            _currentIndex = -1;
            UpdateNavigatorCaption();
            UpdateActionButtonStates();
            SetDirty(false);

            lookUpEditPrj.Focus();
        }

        /// <summary>
        /// Called by ucAttachmentAddEdit.SaveRequired — silently saves and returns the PR ID.
        /// Returns 0 if validation fails or the save is cancelled.
        /// </summary>
        private int SaveAndReturnId()
        {
            if (!ValidateHeader()) return 0;
            return SaveRecord(silent: true) ? _prId : 0;
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!_canSave)
            {
                if (!silent)
                    XtraMessageBox.Show("ليس لديك صلاحية حفظ طلب الشراء.", "غير مصرَّح",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidateHeader()) return false;

            gridView.CloseEditor();
            gridView.UpdateCurrentRow();

            try
            {
                PurchaseRequestList? newPr = null;
                PurchaseRequestList? savedPr = null;

                // Header + detail lines commit or roll back together instead of each detail row
                // being saved independently (previous swallow-and-continue try/catch per row could
                // leave a header committed with only some of its lines saved).
                Data.DataContext.RunInTransaction(tx =>
                {
                    if (_prId == 0)
                    {
                        // ─── New PR ──────────────────────────────────────────────
                        var pr = BuildHeaderEntity();
                        pr.Num = GetNextNumber(tx, pr.RequestDate ?? DateTime.Today);
                        pr.CreatedDate = DateTime.Now;
                        pr.CreatedMachine = Session.Machine;
                        pr.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        pr.IsDelete = false;
                        pr.OverallStatus = PurchaseRequestStatus.Draft;
                        pr.DeliveryStatus = PurchaseRequestDeliveryStatus.NotStarted;

                        _prId = dc.PurchaseRequestList.Add(pr, tx);
                        newPr = pr;
                        savedPr = pr;
                        AuditService.LogCreate(tx, "PurchaseRequestList", _prId, pr);
                    }
                    else
                    {
                        // ─── Edit PR ─────────────────────────────────────────────
                        // Numbering/DeliveryStatus/OverallStatus/الاعتماد كلها مملوكة من مسارات أخرى (الإنشاء،
                        // تجميع الاستلام، محرك الاعتماد WorkflowEngine عبر PurchaseRequestWorkflowSync) ويجب أن
                        // تبقى كما هي عند أي تعديل غير متعلق بها على الترويسة — BuildHeaderEntity يُرجع دائماً
                        // OverallStatus=Draft بشكل ثابت، فبقيت المصادفة يومياً تُعيد الطلب لمسودة عند أي حفظ بعد
                        // إرساله للاعتماد إن لم تُستعَد هذه الحقول صراحة من existing.
                        var pr = BuildHeaderEntity();
                        var existing = dc.PurchaseRequestList.Find(_prId);
                        pr.Num = existing?.Num;
                        pr.DeliveryStatus = existing?.DeliveryStatus;
                        pr.OverallStatus = existing?.OverallStatus;
                        pr.ApprovedBy = existing?.ApprovedBy;
                        pr.ApprovedDate = existing?.ApprovedDate;
                        pr.RejectReason = existing?.RejectReason;
                        pr.UpdateDate = DateTime.Now;
                        pr.UpdateMachine = Session.Machine;
                        pr.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        pr.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync

                        dc.PurchaseRequestList.Edit(_prId, pr, tx);
                        savedPr = pr;
                        AuditService.LogUpdate(tx, "PurchaseRequestList", _prId, existing, pr);
                    }

                    SaveDetails(_prId, tx);
                });

                if (newPr != null) textEditNum.Text = PurchaseRequestPrinter.FormatPRNumber(newPr.Num, newPr.RequestDate);
                _rowVersion = savedPr?.RowVersion;
                SetDirty(false);

                Loadlist();
                _currentIndex = _purchaseList.FindIndex(r => r.Id == _prId);
                UpdateNavigatorCaption();
                UpdateActionButtonStates(); // كان مفقوداً — يترك أزرار الإجراءات ونص barStaticItemstepName عالقين على حالة ما قبل الحفظ

                // Refresh attachments with the real PR id (relevant on first save, when it was 0)
                _ucAttachments?.LoadFor("PurchaseRequestList", _prId);

                // A save can only land here already Approved if this was an edit to an existing
                // Approved PR (new records are always forced to Draft in BuildHeaderEntity above) —
                // that's a real content change, so it earns a new export revision (see
                // PurchaseRequestPrinter.ExportApprovedCopy's R0/R1/... scheme).
                if (newPr == null && savedPr?.OverallStatus == PurchaseRequestStatus.Approved)
                    ExportApprovedCopyIfConfigured(_prId);

                if (!silent)
                {
                    XtraMessageBox.Show("تم الحفظ بنجاح ✓", "حفظ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return true;
            }
            catch (Data.ConcurrencyConflictException ex)
            {
                XtraMessageBox.Show(ex.Message, "تعارض في الحفظ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveDetails(int prId, SqlTransaction tx)
        {
            var helper = dc.PurchaseRequestDetails;

            // 1. Delete removed rows
            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            // 2. Insert or update — SortId يعكس ترتيب العرض الحالي في الشبكة (بعد أي سحب وإفلات)
            var toAdd = new List<PurchaseRequestDetails>();
            var toEdit = new List<PurchaseRequestDetails>();
            for (int i = 0; i < _details.Count; i++)
            {
                var item = _details[i];
                item.PRId = prId;
                item.PrjId = DecodePrjSource().PrjId;
                item.SortId = i + 1;
                item.Num = i + 1;

                if (item.Id == 0)
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedMachine = Session.Machine;
                    item.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    item.IsDelete = false;
                    toAdd.Add(item);
                }
                else
                {
                    item.UpdateDate = DateTime.Now;
                    item.UpdateMachine = Session.Machine;
                    item.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    toEdit.Add(item);
                }
            }
            if (toAdd.Count > 0) helper.AddRange(toAdd, tx);
            if (toEdit.Count > 0) helper.EditRange(toEdit, tx);
        }

        private void DeleteCurrentRecord()
        {
            if (!_canDelete)
            {
                XtraMessageBox.Show("ليس لديك صلاحية حذف طلب الشراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_prId <= 0)
            {
                XtraMessageBox.Show("لا يوجد سجل محفوظ لحذفه.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pr = dc.PurchaseRequestList.Find(_prId);
            if (pr?.OverallStatus == PurchaseRequestStatus.Approved)
            {
                XtraMessageBox.Show("لا يمكن حذف طلب معتمد أو محوّل لأمر شراء.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (XtraMessageBox.Show(
                $"هل أنت متأكد من حذف طلب الشراء رقم [{textEditNum.Text}]؟\nسيتم حذف جميع البنود المرتبطة.",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                dc.DeletePurchaseRequest(_prId);
                Loadlist();

                if (_purchaseList.Count > 0)
                {
                    _currentIndex = Math.Min(_currentIndex, _purchaseList.Count - 1);
                    if (_currentIndex < 0) _currentIndex = 0;
                    LoadRecord(_purchaseList[_currentIndex].Id);
                }
                else
                {
                    NewRecord();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحذف:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Detail Row Operations ─────────────────────────────────────────────
        private void AddDetailRow()
        {
            gridView.AddNewRow();
        }

        private void DeleteFocusedDetailRow()
        {
            var row = gridView.GetFocusedRow() as PurchaseRequestDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل تريد حذف هذا البند؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (row.Id > 0) _deletedDetailIds.Add(row.Id);
            gridView.DeleteSelectedRows();
            SetDirty();
            UpdateDetailButtonStates();
        }

        private void GridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteFocusedDetailRow();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Insert)
            {
                AddDetailRow();
                e.Handled = true;
            }
        }

        /// <summary>When the user picks an item in colItem, auto-fills its unit and description on the same row.</summary>
        private void GvPR_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colItem) return;

            var itemId = e.Value as int?;
            var item = itemId.HasValue ? _itemsCache.FirstOrDefault(i => i.Id == itemId.Value) : null;

            if (gridView.GetRow(e.RowHandle) is PurchaseRequestDetails row)
            {
                row.UnitId = item?.UnitId;
                row.Description = item?.Name;
            }

            gridView.RefreshRow(e.RowHandle);
        }

        private void RepositoryItemButtonEditAddItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using var frm = new frmItemSelect
            {
                RootCategoryCode = TypeToRootCode.GetValueOrDefault(comboBoxEdit1.EditValue?.ToString() ?? "")
            };

            if (frm.ShowDialog(this) != DialogResult.OK) return;

            foreach (var item in frm.SelectedItems)
            {
                _details.Add(new PurchaseRequestDetails
                {
                    ItemId = item.Id,
                    UnitId = item.UnitId,
                    Description = item.Name
                });
            }

            gridView.MoveLast();
        }

        // ── Status Actions ────────────────────────────────────────────────────
        // كل ما كان بندًا في ShowActionMenu (القائمة المنسدلة القديمة) أصبح الآن زراً مستقلاً في الشريط،
        // مفعّلاً/معطَّلاً حسب الحالة عبر UpdateActionButtonStates — انظرها لمنطق التفعيل والنص المعروض
        // في barStaticItemstepName.
        private void ChangeStatus(string newStatus)
        {
            bool allowed = newStatus == PurchaseRequestStatus.Closed ? _canClose
                : newStatus == PurchaseRequestStatus.Draft ? _canReturnForEdit
                : true;
            if (!allowed)
            {
                XtraMessageBox.Show("ليس لديك صلاحية تنفيذ هذا الإجراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var pr = dc.PurchaseRequestList.Find(_prId);
                if (pr == null) return;

                pr.OverallStatus = newStatus;
                pr.UpdateDate = DateTime.Now;
                pr.UpdateMachine = Session.Machine;
                pr.UpdateBy = Session.CurrentUser?.Id ?? 1;

                dc.PurchaseRequestList.Edit(_prId, pr);
                SetDirty(false);

                XtraMessageBox.Show(
                    $"✓ تم تغيير الحالة إلى: {PurchaseRequestStatus.ToDisplay(newStatus)}",
                    "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRecord(_prId); // يُحدِّث تفعيل الأزرار ونص barStaticItemstepName بعد تغيّر الحالة
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Starts an approval workflow procedure and flips the PR into the approval chain. If
        /// more than one procedure is defined for Purchase Requests, prompts the user to pick which one
        /// governs this specific request — see PurchaseRequestWorkflowSync.GetAvailableProcedures.</summary>
        private void SendForApproval()
        {
            if (!_canSend)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إرسال طلب الشراء للاعتماد.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var pr = dc.PurchaseRequestList.Find(_prId);
                if (pr == null) return;

                var candidates = PurchaseRequestWorkflowSync.GetAvailableProcedures(dc, pr);
                if (candidates.Count == 0)
                {
                    XtraMessageBox.Show(
                        "لم يتم تعريف أي إجراء اعتماد لطلبات الشراء بعد. يرجى تعريفه من شاشة \"إدارة الإجراءات\" أولاً.",
                        "تعذّر الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int workflowDefinitionId;
                if (candidates.Count == 1)
                {
                    workflowDefinitionId = candidates[0].Id;
                }
                else
                {
                    using var picker = new frmWorkflowDefinitionSelect(candidates);
                    if (picker.ShowDialog(this) != DialogResult.OK) return;
                    workflowDefinitionId = picker.SelectedDefinitionId;
                }

                PurchaseRequestWorkflowSync.SendForApproval(dc, pr, workflowDefinitionId);

                pr.OverallStatus = PurchaseRequestStatus.PendingApproval;
                pr.UpdateDate = DateTime.Now;
                pr.UpdateMachine = Session.Machine;
                pr.UpdateBy = Session.CurrentUser?.Id ?? 1;
                dc.PurchaseRequestList.Edit(_prId, pr);
                SetDirty(false);

                XtraMessageBox.Show("✓ تم إرسال الطلب للاعتماد", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecord(_prId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Approves/rejects the current step of this PR's active workflow instance, then reconciles the PR's own status.</summary>
        private void ActOnWorkflowStep(int instanceId, string action)
        {
            // فحص دفاعي إضافي (بالإضافة إلى إخفاء عناصر القائمة/تعطيل الأزرار أعلاه) — يمنع الاعتماد
            // الذاتي حتى لو وصل الاستدعاء لهذه الدالة من مسار آخر مستقبلاً.
            var prForCheck = dc.PurchaseRequestList.Find(_prId);
            if (prForCheck != null && SeparationOfDutiesHelper.BlocksSelfApproval(dc, prForCheck.CreatedBy))
            {
                XtraMessageBox.Show(SeparationOfDutiesHelper.SelfApprovalMessage, "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = action == "Approved" ? "اعتماد" : "رفض";
            var comment = XtraInputBox.Show($"ملاحظة ({title}) - اختياري:", title, "");
            if (comment == null) return; // user cancelled

            try
            {
                WorkflowEngine.Act(instanceId, Session.CurrentUser?.Id ?? 1, action, comment.ToString());

                var pr = dc.PurchaseRequestList.Find(_prId);
                if (pr != null) PurchaseRequestWorkflowSync.Reconcile(dc, pr);

                if (pr != null && pr.OverallStatus == PurchaseRequestStatus.Approved)
                    ExportApprovedCopyIfConfigured(pr.Id);

                XtraMessageBox.Show($"تم {title} بنجاح ✓", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecord(_prId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Silently saves a PDF + attachments copy of this now-fully-approved PR to whichever
        /// export destination(s) are configured in SettingsForm — a local/network folder
        /// (Data.PurchaseRequestExportSettings) and/or a shared SharePoint Online library
        /// (Data.SharePointExportSettings), independently of each other so one being unreachable never
        /// skips the other. Does nothing for a destination that isn't configured. Export failure (e.g. an
        /// unreachable network path, or a SharePoint/Graph error) must not block or roll back the approval
        /// that already succeeded — it only warns the user, once per destination that actually failed.</summary>
        private void ExportApprovedCopyIfConfigured(int prId)
        {
            var rootPath = Data.PurchaseRequestExportSettings.GetFolderPath(dc);
            if (!string.IsNullOrWhiteSpace(rootPath))
            {
                try
                {
                    PurchaseRequestPrinter.ExportApprovedCopy(prId, rootPath);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        $"تم اعتماد الطلب بنجاح، لكن تعذر حفظ نسخة PDF/المرفقات في المسار المحدد بالإعدادات:\n{ex.Message}",
                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (Data.SharePointExportSettings.IsEnabled(dc))
            {
                try
                {
                    PurchaseRequestPrinter.ExportApprovedCopyToSharePoint(prId);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        $"تم اعتماد الطلب بنجاح، لكن تعذر رفع نسخة PDF/المرفقات إلى SharePoint المحدد بالإعدادات:\n{ex.Message}",
                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>Used by bbiApproved/bbiReject: resolves this PR's active workflow instance and acts on its current step.</summary>
        private void ActOnCurrentStep(string action)
        {
            if (_prId <= 0) return;

            var instance = PurchaseRequestWorkflowSync.GetActiveInstance(dc, _prId);
            if (instance == null)
            {
                XtraMessageBox.Show("لا يوجد إجراء اعتماد جارٍ لهذا الطلب.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActOnWorkflowStep(instance.Id, action);
        }

        /// <summary>Used by bbiReturnToStep — covers both "still pending approval, current step holder
        /// sends it back" and "already fully approved, procurement re-opens it before raising a PO"
        /// (see PurchaseRequestWorkflowSync.ReturnToStep / WorkflowEngine.ReturnToStep for the split).</summary>
        private void ReturnToStep()
        {
            if (_prId <= 0) return;

            var pr = dc.PurchaseRequestList.Find(_prId);
            if (pr == null) return;

            if (pr.OverallStatus == PurchaseRequestStatus.PendingApproval)
            {
                var instance = PurchaseRequestWorkflowSync.GetActiveInstance(dc, _prId);
                if (instance == null)
                {
                    XtraMessageBox.Show("لا يوجد إجراء اعتماد جارٍ لهذا الطلب.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!WorkflowEngine.CanUserAct(instance.Id, Session.CurrentUser?.Id ?? 1))
                {
                    XtraMessageBox.Show("ليس لديك صلاحية التصرف في هذه الخطوة.", "غير مصرَّح",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DoReturnToStep(pr, instance, requireCurrentStepAssignee: true);
            }
            else if (pr.OverallStatus == PurchaseRequestStatus.Approved)
            {
                if (!_canManagePO)
                {
                    XtraMessageBox.Show("ليس لديك صلاحية إعادة طلب معتمد إلى خطوة سابقة.", "غير مصرَّح",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (PurchaseRequestWorkflowSync.HasIssuedPurchaseOrder(dc, _prId))
                {
                    XtraMessageBox.Show("لا يمكن إعادة هذا الطلب — تم إصدار أمر شراء له بالفعل.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var instance = PurchaseRequestWorkflowSync.GetLatestInstance(dc, _prId);
                if (instance == null)
                {
                    XtraMessageBox.Show("تعذّر تحديد إجراء الاعتماد الخاص بهذا الطلب.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DoReturnToStep(pr, instance, requireCurrentStepAssignee: false);
            }
            else
            {
                XtraMessageBox.Show("لا يمكن إعادة هذا الطلب في حالته الحالية.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>Shared tail of ReturnToStep: builds the candidate step list (steps before the current
        /// one when a current-step holder is sending it back; steps up to and including the current/last
        /// one when re-opening an already-finished instance), shows the picker dialog, and applies the
        /// result.</summary>
        private void DoReturnToStep(PurchaseRequestList pr, WorkflowInstanceList instance, bool requireCurrentStepAssignee)
        {
            var steps = dc.WorkflowStepList
                .GetBy("WorkflowDefinitionId = @id", new { id = instance.WorkflowDefinitionId })
                .Where(s => s.StepOrder <= instance.CurrentStepOrder)
                .ToList();

            if (requireCurrentStepAssignee)
                steps = steps.Where(s => s.StepOrder < instance.CurrentStepOrder).ToList();

            if (steps.Count == 0)
            {
                XtraMessageBox.Show("لا توجد خطوة سابقة يمكن الإعادة إليها.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var currentStepName = PurchaseRequestWorkflowSync.GetCurrentStepName(dc, instance) ?? "—";

            using var frm = new frmWorkflowReturnToStep(steps, currentStepName);
            if (frm.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                PurchaseRequestWorkflowSync.ReturnToStep(dc, pr, instance, frm.SelectedStepOrder, frm.Reason, requireCurrentStepAssignee);

                XtraMessageBox.Show("✓ تم إعادة الطلب إلى الخطوة المحددة", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecord(_prId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Keeps every status-dependent action button (send/approve/reject/convert/compare/close/revert/
        /// delete) and the step-name static label (barStaticItemstepName) in sync with the PR's current
        /// OverallStatus / active workflow step. Replaces the old single "الإجراءات" dropdown
        /// (bbiReAction → ShowActionMenu) — each action is now its own always-visible, conditionally-
        /// enabled toolbar button instead of a context menu built on demand.
        /// </summary>
        private void UpdateActionButtonStates()
        {
            var pr = _prId > 0 ? dc.PurchaseRequestList.Find(_prId) : null;
            string? status = pr?.OverallStatus;

            bool canAct = false;
            string stepText;

            if (pr == null)
            {
                stepText = "سجل جديد غير محفوظ";
            }
            else if (status == PurchaseRequestStatus.PendingApproval)
            {
                var instance = PurchaseRequestWorkflowSync.GetActiveInstance(dc, _prId);
                if (instance == null)
                {
                    stepText = "تعذّر تحديد إجراء الاعتماد الجاري لهذا الطلب";
                }
                else
                {
                    var name = PurchaseRequestWorkflowSync.GetCurrentStepName(dc, instance) ?? "—";
                    canAct = WorkflowEngine.CanUserAct(instance.Id, Session.CurrentUser?.Id ?? 1)
                        && !SeparationOfDutiesHelper.BlocksSelfApproval(dc, pr.CreatedBy);
                    stepText = canAct
                        ? $"الخطوة الحالية: {name}"
                        : SeparationOfDutiesHelper.BlocksSelfApproval(dc, pr.CreatedBy)
                            ? $"الخطوة الحالية: {name} — لا يمكنك الاعتماد الذاتي"
                            : $"الخطوة الحالية: {name}";
                }
            }
            else
            {
                stepText = $"الحالة: {PurchaseRequestStatus.ToDisplay(status)}";
            }

            barStaticItemstepName.Caption = stepText;

            bbiApproved.Enabled = canAct;
            bbiReject.Enabled = canAct;

            bbiSendForApproval.Enabled = status == PurchaseRequestStatus.Draft && _prId > 0 && _canSend;
            bbiDeleteRequest.Enabled = (status == PurchaseRequestStatus.Draft || status == PurchaseRequestStatus.Rejected) && _prId > 0 && _canDelete;
            bbiReturnForEdit.Enabled = status == PurchaseRequestStatus.Rejected && _prId > 0 && _canReturnForEdit;
            bbiCloseRequest.Enabled = status == PurchaseRequestStatus.Approved && _prId > 0 && _canClose;

            // إعادة لخطوة سابقة: إما أثناء الاعتماد (صاحب الخطوة الحالية، canAct نفسها)، أو بعد الاعتماد
            // الكامل وقبل صدور أمر شراء (صلاحية أوامر الشراء + عدم وجود أمر شراء صادر بالفعل — الفحص هنا
            // فقط لتفعيل الزر، والفحص القاطع يتكرر عند الضغط الفعلي في ReturnToStep).
            bool canReopenApproved = status == PurchaseRequestStatus.Approved && _prId > 0 && _canManagePO
                && !PurchaseRequestWorkflowSync.HasIssuedPurchaseOrder(dc, _prId);
            bbiReturnToStep.Enabled = canAct || canReopenApproved;
        }

        // ── Navigation ────────────────────────────────────────────────────────
        private void NavigateFirst()
        {
            if (_purchaseList.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = 0;
            var handle = ShowOverlay();
            try { LoadRecord(_purchaseList[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigatePrev()
        {
            if (_purchaseList.Count == 0 || _currentIndex <= 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex--;
            var handle = ShowOverlay();
            try { LoadRecord(_purchaseList[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateNext()
        {
            if (_purchaseList.Count == 0 || _currentIndex >= _purchaseList.Count - 1) return;
            if (!ConfirmNavigation()) return;
            _currentIndex++;
            var handle = ShowOverlay();
            try { LoadRecord(_purchaseList[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateLast()
        {
            if (_purchaseList.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = _purchaseList.Count - 1;
            var handle = ShowOverlay();
            try { LoadRecord(_purchaseList[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void FetchBySearch()
        {
            string searchTerm = barEditItem1.EditValue?.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(searchTerm)) return;

            var found = _purchaseList.FirstOrDefault(r =>
                (r.Num?.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true) ||
                PurchaseRequestPrinter.FormatPRNumber(r.Num, r.RequestDate).Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                (r.Purpose?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true));

            if (found == null)
            {
                XtraMessageBox.Show($"لم يُعثر على نتائج للبحث: [{searchTerm}]", "بحث",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ConfirmNavigation()) return;
            _currentIndex = _purchaseList.IndexOf(found);
            var handle = ShowOverlay();
            try { LoadRecord(found.Id); }
            finally { CloseOverlay(handle); }
        }

        // ── Print ─────────────────────────────────────────────────────────────
        private void PrintRecord()
        {
            if (!_canPrint)
            {
                XtraMessageBox.Show("ليس لديك صلاحية طباعة طلب الشراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_prId <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ الطلب قبل الطباعة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            try { PurchaseRequestPrinter.Print(_prId); }
            finally { CloseOverlay(handle); }
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        private static bool IsFilled(DevExpress.XtraEditors.BaseEdit control) =>
            control.EditValue != null && control.EditValue != DBNull.Value;

        /// <summary>The six fields marked with a green background in the Designer are the header's
        /// required fields (lookUpEditDiscipline and comboBoxEdit1 previously had no check at all here —
        /// green but unenforced, same class of gap fixed on frmCIRAddEdit). Checked together on Save;
        /// any that are empty turn salmon and the first one gets focus, instead of one message box per
        /// missing field.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditPrj as DevExpress.XtraEditors.BaseEdit, IsFilled(lookUpEditPrj)),
            (dateEditRequestDate as DevExpress.XtraEditors.BaseEdit, dateEditRequestDate.EditValue != null),
            (lookUpEditStore as DevExpress.XtraEditors.BaseEdit, IsFilled(lookUpEditStore)),
            (lookUpEditDiscipline as DevExpress.XtraEditors.BaseEdit, IsFilled(lookUpEditDiscipline)),
            (memoEditPurpose as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(memoEditPurpose.Text)),
            (comboBoxEdit1 as DevExpress.XtraEditors.BaseEdit, IsFilled(comboBoxEdit1)),
        };

        private static void SetRequiredFieldState(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            control.Properties.Appearance.BackColor = isFilled ? Color.LightGreen : Color.Salmon;
            control.Properties.Appearance.Options.UseBackColor = true;
            control.Invalidate();
        }

        /// <summary>Live revert-to-green as the user types/selects — called from each required
        /// field's EditValueChanged, independent of the next Save attempt.</summary>
        private void RevalidateField(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            if (isFilled) SetRequiredFieldState(control, true);
        }

        private bool ValidateRequiredFields()
        {
            DevExpress.XtraEditors.BaseEdit? firstInvalid = null;
            foreach (var (control, isFilled) in RequiredFieldChecks())
            {
                SetRequiredFieldState(control, isFilled);
                if (!isFilled && firstInvalid == null) firstInvalid = control;
            }

            if (firstInvalid == null) return true;

            XtraMessageBox.Show("الرجاء تعبئة كل الحقول المطلوبة (باللون الأحمر).", "بيانات ناقصة",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firstInvalid.Focus();
            return false;
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool ValidateHeader()
        {
            if (!ValidateRequiredFields()) return false;
            if (_details.Count == 0)
            {
                XtraMessageBox.Show("يرجى إضافة بند واحد على الأقل في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl.Focus();
                return false;
            }
            if (_details.Any(d => d.ItemId is null or 0))
            {
                XtraMessageBox.Show("يرجى اختيار الصنف لكل بند في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl.Focus();
                return false;
            }
            if (_details.Any(d => d.Qty is null or <= 0))
            {
                XtraMessageBox.Show("يرجى تحديد الكمية لكل بند في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        /// <summary>Builds the header from the editable form fields. Num is assigned separately in SaveRecord.</summary>
        private PurchaseRequestList BuildHeaderEntity()
        {
            var (prjId, deptId) = DecodePrjSource();
            return new PurchaseRequestList
            {
                PrjId = prjId,
                DeptId = deptId,
                StoreId = lookUpEditStore.EditValue as int?,
                DisciplineId = lookUpEditDiscipline.EditValue as int?,
                RequestDate = dateEditRequestDate.EditValue as DateTime?,
                RequiredDate = dateEditRequiredDate.EditValue as DateTime?,
                Purpose = memoEditPurpose.Text.Trim(),
                Priority = comboBoxEditPriority.EditValue?.ToString() ?? "عادي",
                Type = comboBoxEdit1.EditValue?.ToString() ?? "المواد",
                OverallStatus = PurchaseRequestStatus.Draft
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        /// <summary>Next sequential number within the calendar year of the PR's own RequestDate — the series
        /// resets to 1 every year (see PurchaseRequestPrinter.FormatPRNumber for the "PR{yy}{seq}" display format).
        /// Delegates to NumberingService (concurrency-safe via sp_getapplock on the save transaction)
        /// instead of computing MAX(Num)+1 here, which two users saving at the same instant could race.</summary>
        private int GetNextNumber(SqlTransaction tx, DateTime requestDate) =>
            NumberingService.GetNextNumber(tx, "PurchaseRequestList", requestDate.Year, () =>
                dc.PurchaseRequestList
                    // ملاحظة: نبحث في كل السجلات (بما فيها المحذوفة IsDelete=1) لإيجاد أعلى رقم
                    // مُعيَّن فعلياً في قاعدة البيانات — هذا يضمن عدم إعادة إصدار رقم سبق استخدامه
                    // حتى لو كان السجل الحامل له قد حُذف لاحقاً.
                    .GetBy("YEAR(RequestDate) = @year", new { year = requestDate.Year })
                    .Select(r => r.Num ?? 0)
                    .DefaultIfEmpty(0)
                    .Max());

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _purchaseList.Count > 0
                ? $"طلب شراء  [{PurchaseRequestPrinter.FormatPRNumber(_purchaseList[_currentIndex].Num, _purchaseList[_currentIndex].RequestDate)}]  |  {_currentIndex + 1} / {_purchaseList.Count}"
                : "إضافة / تعديل طلب شراء — سجل جديد";

            bbiFirst.Enabled = _currentIndex > 0;
            bbiPrev.Enabled = _currentIndex > 0;
            bbiNext.Enabled = _currentIndex < _purchaseList.Count - 1;
            bbiLast.Enabled = _currentIndex < _purchaseList.Count - 1;
        }

        private void UpdateDetailButtonStates()
        {
            // Detail-grid toolbar buttons live in the Designer bar (bar1) — wire enable/disable here if needed.
        }

        private void OnHeaderChanged(object? sender, EventArgs e) => SetDirty();

        private void SetDirty(bool value = true) => _isDirty = value;

        private bool ConfirmNavigation()
        {
            if (!_isDirty) return true;

            var result = XtraMessageBox.Show(
                "توجد تغييرات غير محفوظة. هل تريد الحفظ قبل الانتقال؟",
                "تغييرات غير محفوظة",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) { SaveRecord(); return true; }
            if (result == DialogResult.No) { SetDirty(false); return true; }
            return false; // Cancel
        }

        /// <summary>يعرض مؤشر انتظار (overlay) فوق النافذة أثناء تنفيذ action — نفس نمط ShowOverlay/
        /// CloseOverlay المعتمد في frmMARAddEdit/frmCIRAddEdit وأُضيف حديثاً إلى frmPurchaseOrderAddEdit،
        /// إذ لا تصل أزرار هذه الشاشة (XtraForm عادية) إلى BaseRibbonForm.ExecuteAsync (خاص بنماذج Ribbon).
        /// يُغلَّف SafeAction نفسه بدل كل زر على حدة — يغطي كل الأزرار التي تمر عبره أصلاً.</summary>
        private void SafeAction(Action action)
        {
            var handle = ShowOverlay();
            try { action(); }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ غير متوقع:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        /// <summary>نفس مؤشر الانتظار أعلاه، لعمليات لا تمر عبر SafeAction (الطباعة/التنقل/البحث) — إذ
        /// معالجة الأخطاء فيها مختلفة (رسائل خاصة أو لا شيء) فلا تلائم غلاف SafeAction العام.</summary>
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        // ── Form Closing Guard ────────────────────────────────────────────────
        private void FrmPurchaseRequestAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_isDirty) return;

            var result = XtraMessageBox.Show(
                "توجد تغييرات غير محفوظة. هل تريد الحفظ قبل الإغلاق؟",
                "تغييرات غير محفوظة",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) SafeAction(() => SaveRecord());
            else if (result == DialogResult.Cancel) e.Cancel = true;
        }

    }
}
