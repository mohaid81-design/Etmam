using System.Data;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>List/grid screen for Purchase Orders: filter by project, inline print/action/log buttons,
    /// bulk status actions — mirrors ucPurchaseRequests' structure/conventions.</summary>
    public partial class ucPurchaseOrder : DevExpress.XtraEditors.XtraUserControl
    {
        private static DataContext DB => Data.DataContext.Shared;

        private List<PurchaseOrderList> _allRecords = new();
        // ما تعرضه الشبكة فعلياً الآن (كل _allRecords، أو الجزء المُطابق لفلتر بطاقة نشطة في tbMain) —
        // نفس نمط ucPurchaseRequests._visibleRecords.
        private List<PurchaseOrderList> _visibleRecords = new();
        private HashSet<int> _grantedProjectIds = new();

        // صلاحيات مستقلة لكل زر — نفس صلاحيات frmPurchaseOrderAddEdit (PermNames.POAdd/POSave/POPrint/
        // POSend/PODelete) يُعاد استخدامها هنا حرفياً لأن "تعديل" في هذه الشاشة يفتح نفس نموذج
        // frmPurchaseOrderAddEdit نفسه (محكوماً بـ POSave داخله أصلاً)، و"طباعة" هنا (سواء الطباعة
        // السريعة لعمود الشبكة أو زر طباعة سجل الأوامر) هي نفس فعل الطباعة هناك — نفس نمط
        // ucPurchaseRequests. فحص الاعتماد/الرفض الفعلي يبقى منفصلاً عبر WorkflowEngine.CanUserAct لكل
        // خطوة (انظر PurchaseOrderWorkflowSync).
        private bool _canAdd;
        private bool _canSave;
        private bool _canPrint;
        private bool _canSend;
        private bool _canDelete;

        private RepositoryItemLookUpEdit repositoryItemLookUpEditSupplier = null!;

        // البطاقة المُفعَّلة حالياً كفلتر على الشبكة (null = بلا فلتر / إجمالي) — نفس نمط
        // ucPurchaseRequests._activeTile/_activeTileFilter.
        private DevExpress.XtraBars.Navigation.TileBarItem? _activeTile;
        private Func<PurchaseOrderList, bool>? _activeTileFilter;

        public ucPurchaseOrder()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canAdd = PermissionService.HasPermission(PermNames.POAdd);
            _canSave = PermissionService.HasPermission(PermNames.POSave);
            _canPrint = PermissionService.HasPermission(PermNames.POPrint);
            _canSend = PermissionService.HasPermission(PermNames.POSend);
            _canDelete = PermissionService.HasPermission(PermNames.PODelete);
            bbiNew.Enabled = _canAdd;

            SetupLookups();
            SetupGrid();
            WireTileBar();

            this.Load += (s, e) => LoadData();

            bbiNew.ItemClick += (s, e) => OpenAddEdit(0);
            bbiEdit.ItemClick += (s, e) => EditSelected();
            bbiDelete.ItemClick += (s, e) => DeleteSelected();
            bbiPrint.ItemClick += (s, e) => PrintGrid();
            bbiRefresh.ItemClick += (s, e) => LoadData();
            bbiOpen.ItemClick += (s, e) => OpenFocusedForAction();

            lookUpEditPrj.EditValueChanged += (s, e) => LoadData();
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void SetupLookups()
        {
            // فلتر المشروع — يعرض فقط المشاريع المصرَّح للمستخدم بالاطلاع عليها (نفس منطق ucPurchaseRequests)
            var projects = DB.ProjectsList.GetBy("IsDelete = 0");

            _grantedProjectIds = PermissionService.GrantedProjectIds(DB);

            var accessibleProjects = projects.Where(p => _grantedProjectIds.Contains(p.Id)).ToList();

            var prjFilterSource = new List<ProjectsList>();
            if (accessibleProjects.Count > 1)
                prjFilterSource.Add(new ProjectsList { Id = 0, Name = "-- الكل --" });
            prjFilterSource.AddRange(accessibleProjects);

            lookUpEditPrj.Properties.DataSource = prjFilterSource;
            lookUpEditPrj.Properties.ValueMember = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.NullText = "-- إختر المشروع --";

            // أعمدة الشبكة ذات النوع Lookup
            repositoryItemLookUpEditProject.DataSource = projects;
            repositoryItemLookUpEditProject.ValueMember = "Id";
            repositoryItemLookUpEditProject.DisplayMember = "Name";

            repositoryItemLookUpEditStore.DataSource = DB.StoreList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditStore.ValueMember = "Id";
            repositoryItemLookUpEditStore.DisplayMember = "Name";

            repositoryItemLookUpEditSupplier = new RepositoryItemLookUpEdit
            {
                DataSource = DB.StakeholdersList.GetBy("IsDelete = 0"),
                ValueMember = "Id",
                DisplayMember = "Name"
            };
            gridControl1.RepositoryItems.Add(repositoryItemLookUpEditSupplier);
            colStakeholderId.ColumnEdit = repositoryItemLookUpEditSupplier;

            var repositoryItemMemoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            gridControl1.RepositoryItems.Add(repositoryItemMemoEdit);
            colOverallStatus.ColumnEdit = repositoryItemMemoEdit;
            colDescription.ColumnEdit = repositoryItemMemoEdit;
        }

        private void SetupGrid()
        {
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsSelection.MultiSelect = true;

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

            // خلفية أعمدة الأزرار (طباعة/إجراء/سجل) تتغيّر تلقائياً عند تركيز/تحديد الصف (سلوك DevExpress
            // الافتراضي)، فنفرض لون الصف الطبيعي (فردي/زوجي) عليها دائماً — نفس إصلاح ucPurchaseRequests.
            gridView1.Appearance.Row.BackColor = DesignSystem.Colors.Surface;
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.BackColor = DesignSystem.Colors.Background;
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            gridView1.RowCellStyle += GridView1_RowCellStyle;

            gridView1.DoubleClick += (s, e) => OpenFocusedForAction();
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();

            // فتح قائمة الإجراءات الجماعية بالنقر بزر الفأرة الأيمن (لا يوجد زر مخصص لها في الشريط حالياً)
            gridControl1.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Right) ShowBulkActionMenu();
            };

            repositoryItemButtonEditPrint.ButtonClick += (s, e) =>
            {
                if (!_canPrint)
                {
                    XtraMessageBox.Show("ليس لديك صلاحية طباعة أمر الشراء.", "غير مصرَّح",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (gridView1.GetFocusedRow() is PurchaseOrderList) PrintFocused();
            };

            repositoryItemButtonEditAction.ButtonClick += (s, e) =>
            {
                // زر عمود الشبكة يفتح نفس نموذج التعديل الكامل (لا يوجد وضع عرض فقط منفصل) — يُمنع بنفس
                // صلاحية bbiEdit في الشريط تفادياً لتجاوزها عبر هذا العمود.
                if (!_canSave) return;
                if (gridView1.GetFocusedRow() is PurchaseOrderList po) OpenAddEdit(po.Id);
            };

            // عمود colLog → نفس أسلوب ucPurchaseRequests بالضبط: نافذة سجل إجراءات مخصَّصة (شبكة
            // خطوات سير عمل قابلة للطباعة) بدل صندوق رسالة نصي بسيط. مؤشر الانتظار يلف الإنشاء تحديداً
            // (LoadData داخل الـ constructor تُنفِّذ عدة استعلامات قبل ظهور النافذة) — نفس نمط
            // ucCIR.RiButtonAction_ButtonClick، لا ShowDialog نفسها التي تحجب الخيط أصلاً وتُظهر نافذة
            // مرئية فور اكتمالها.
            repositoryItemButtonEditLog.ButtonClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is not PurchaseOrderList po) return;

                var handle = ShowOverlay();
                frmPurchaseOrderLog frm;
                try { frm = new frmPurchaseOrderLog(po.Id); }
                finally { CloseOverlay(handle); }

                frm.ShowDialog(this);
            };
        }

        // ── tbMain (بطاقات الحالة) ───────────────────────────────────────────
        // نفس تنظيم وتنسيق tbMain في ucPurchaseRequests — بطاقة "إجمالي"، بطاقة "مسودة"، بطاقة لكل خطوة
        // من خطوات إجراء "أمر الشراء" الفعلية (4 خطوات فقط هنا، لا 5 كما في "طلب الشراء" — انظر
        // DatabaseInitializer)، ثم "معتمد"/"مرفوض". لا يوجد صفّ "حالة أمر الشراء/حالة التوريد" المقابل
        // (tbPoStatus عند ucPurchaseRequests) لأن ذاك المفهوم خاص بطلب الشراء (هل صدر له أمر شراء بعد؟) ولا
        // معنى مواز له من منظور أمر الشراء نفسه.

        /// <summary>يربط كل بطاقة في tbMain بفلترها الخاص على الشبكة: "إجمالي" بلا فلتر، الأربع بطاقات
        /// الوسطى بخطوة سير العمل الحالية للأمر (نص StatusDisplay كما ينتجه PurchaseOrderWorkflowSync)،
        /// و"معتمد"/"مرفوض" بـ OverallStatus النهائي مباشرة.</summary>
        private void WireTileBar()
        {
            tbiTotal.ItemClick += (s, e) => ApplyTileFilter(tbiTotal, null);
            tbiDraft.ItemClick += (s, e) =>
                ApplyTileFilter(tbiDraft, r => r.OverallStatus == PurchaseOrderStatus.Draft);
            WireStepTile(tbiUnderPurchasingManager);
            WireStepTile(tbiUnderCostEngineer);
            WireStepTile(tbiUnderProjectsManager);
            WireStepTile(tbiUnderOperationsExecutive);
            tbiApproved.ItemClick += (s, e) =>
                ApplyTileFilter(tbiApproved, r => r.OverallStatus == PurchaseOrderStatus.Approved);
            tbiRejected.ItemClick += (s, e) =>
                ApplyTileFilter(tbiRejected, r => r.OverallStatus == PurchaseOrderStatus.Rejected);
        }

        /// <summary>يربط إحدى البطاقات الأربع الوسطى (تحت إجراء ...) بفلتر يطابق StatusDisplay مع عنوانها
        /// هي نفسها (Elements[0].Text) — يُقرأ العنوان مرة عند الربط، فلا حاجة لتكراره في كود منفصل يُمكن
        /// أن يخرج عن التزامن مع الـ Designer (نفس منطق ucPurchaseRequests.WireStepTile).</summary>
        private void WireStepTile(DevExpress.XtraBars.Navigation.TileBarItem tile)
        {
            string stepCaption = tile.Elements[0].Text;
            tile.ItemClick += (s, e) => ApplyTileFilter(tile, r => r.StatusDisplay == stepCaption);
        }

        /// <summary>النقر على البطاقة المُفعَّلة بالفعل يُلغي الفلتر (يعيد الشبكة لعرض الكل) بدل تكراره.</summary>
        private void ApplyTileFilter(DevExpress.XtraBars.Navigation.TileBarItem tile, Func<PurchaseOrderList, bool>? predicate)
        {
            bool isTogglingOff = _activeTile == tile && predicate != null;
            _activeTile = isTogglingOff ? null : (predicate == null ? null : tile);
            _activeTileFilter = isTogglingOff ? null : predicate;
            RefreshGridFilter();
        }

        /// <summary>يُطبَّق الفلتر النشط (إن وُجد) على _allRecords ويعيد ربط الشبكة به — يُستدعى من
        /// ApplyTileFilter عند نقر بطاقة، ومن LoadData بعد كل تحميل بيانات جديد كي لا يُفقد الفلتر النشط
        /// عند الضغط على "تحديث".</summary>
        private void RefreshGridFilter()
        {
            _visibleRecords = _activeTileFilter == null
                ? _allRecords
                : _allRecords.Where(_activeTileFilter).ToList();
            gridControl1.DataSource = _visibleRecords;
        }

        /// <summary>يُحدِّث عدّاد كل بطاقة في tbMain من _allRecords الحالية (بلا تأثير الفلتر النشط —
        /// الأعداد دائماً عن إجمالي الأوامر المُحمَّلة، لا عن الصفوف المعروضة فقط).</summary>
        private void UpdateTileCounts()
        {
            tbiTotal.Elements[1].Text = _allRecords.Count.ToString();
            tbiDraft.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == PurchaseOrderStatus.Draft).ToString();
            UpdateStepTileCount(tbiUnderPurchasingManager);
            UpdateStepTileCount(tbiUnderCostEngineer);
            UpdateStepTileCount(tbiUnderProjectsManager);
            UpdateStepTileCount(tbiUnderOperationsExecutive);
            tbiApproved.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == PurchaseOrderStatus.Approved).ToString();
            tbiRejected.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == PurchaseOrderStatus.Rejected).ToString();
        }

        /// <summary>يحسب عدّاد إحدى البطاقات الأربع الوسطى مطابقاً StatusDisplay مع عنوانها هي نفسها
        /// (Elements[0].Text) — نفس منطق WireStepTile.</summary>
        private void UpdateStepTileCount(DevExpress.XtraBars.Navigation.TileBarItem tile)
        {
            string stepCaption = tile.Elements[0].Text;
            tile.Elements[1].Text = _allRecords.Count(r => r.StatusDisplay == stepCaption).ToString();
        }

        private void GridView1_RowCellStyle(object? sender, RowCellStyleEventArgs e)
        {
            if (e.Column != colPrint && e.Column != colAction && e.Column != colLog) return;

            bool isEvenRow = e.RowHandle % 2 != 0;
            e.Appearance.BackColor = isEvenRow ? gridView1.Appearance.EvenRow.BackColor : gridView1.Appearance.Row.BackColor;
            e.Appearance.Options.UseBackColor = true;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                string filter = "IsDelete = 0";
                var prjId = lookUpEditPrj.EditValue;

                bool isAllOption = prjId != null && prjId != DBNull.Value && (int)prjId == 0;
                bool filterBySpecificProject = prjId != null && prjId != DBNull.Value && !isAllOption;

                if (filterBySpecificProject)
                {
                    filter += " AND PrjId = @PrjId";
                }
                else
                {
                    // خيار "الكل" أو عدم اختيار أي مشروع بعد — كلاهما يجب أن يقتصر على المشاريع المصرَّح
                    // للمستخدم بها، لا كل أوامر الشراء في قاعدة البيانات دون تمييز (نفس إصلاح ucPurchaseRequests).
                    var ids = _grantedProjectIds.Count > 0 ? string.Join(",", _grantedProjectIds) : "-1";
                    filter += $" AND PrjId IN ({ids})";
                }

                _allRecords = DB.PurchaseOrderList.GetBy(filter, new { PrjId = prjId })
                    .OrderByDescending(r => r.OrderDate)
                    .ThenByDescending(r => r.Id)
                    .ToList();

                // دُفعة واحدة لكل من طلب الشراء وعرض السعر المرتبطين (بدل استعلام Find منفرد لكل صف داخل
                // الحلقة أدناه) — نفس اعتبار الأداء الذي دفع ucPurchaseRequests.LoadData لتجميع حالتَي
                // الاعتماد/أمر الشراء دفعة واحدة بدل استعلام لكل صف.
                var prIds = _allRecords.Where(r => r.PRId is > 0).Select(r => r.PRId!.Value).Distinct().ToList();
                var quotationIds = _allRecords.Where(r => r.QuotationId is > 0).Select(r => r.QuotationId!.Value).Distinct().ToList();

                var prById = prIds.Count > 0
                    ? DB.PurchaseRequestList.GetBy($"Id IN ({string.Join(",", prIds)})").ToDictionary(p => p.Id)
                    : new Dictionary<int, PurchaseRequestList>();
                var quotationById = quotationIds.Count > 0
                    ? DB.PriceQuotationList.GetBy($"Id IN ({string.Join(",", quotationIds)})").ToDictionary(q => q.Id)
                    : new Dictionary<int, PriceQuotationList>();

                // يزامن أي أمر "قيد الاعتماد" مع نتيجة إجراء الاعتماد إن انتهى منذ آخر تحميل، ويعرض اسم
                // الخطوة الحالية بدل النص العام أثناء الاعتماد — نفس نمط ucPurchaseRequests.LoadData.
                foreach (var po in _allRecords)
                {
                    PurchaseOrderWorkflowSync.Reconcile(DB, po);
                    po.StatusDisplay = PurchaseOrderWorkflowSync.GetStatusDisplay(DB, po);
                    po.FormattedNum = PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate);

                    po.PRNumber = po.PRId is > 0 && prById.TryGetValue(po.PRId.Value, out var pr)
                        ? PurchaseRequestPrinter.FormatPRNumber(pr.Num, pr.RequestDate)
                        : null;
                    po.QuotationNumber = po.QuotationId is > 0 && quotationById.TryGetValue(po.QuotationId.Value, out var quotation)
                        ? quotation.Num?.ToString()
                        : null;
                }

                RefreshGridFilter();
                UpdateTileCounts();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل أوامر الشراء:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // ── Record Operations ─────────────────────────────────────────────────
        // نقطة الدخول الموحّدة للإضافة/التعديل (bbiNew، EditSelected، النقر المزدوج، وزر colAction في
        // الشبكة) — الفحص هنا يمنع تجاوز الصلاحية عبر أي من هذه المسارات التي لا تمر جميعها بحالة
        // تفعيل bbiEdit.
        private void OpenAddEdit(int id)
        {
            bool allowed = id == 0 ? _canAdd : _canSave;
            if (!allowed)
            {
                XtraMessageBox.Show(id == 0
                    ? "ليس لديك صلاحية إضافة أمر شراء جديد."
                    : "ليس لديك صلاحية تعديل أمر الشراء.",
                    "غير مصرَّح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // منشئ frmPurchaseOrderAddEdit يحمّل بيانات السجل من قاعدة البيانات مباشرةً (LoadRecord/
            // Loadlist) قبل ظهور النافذة — مؤشر الانتظار هنا يغطي تلك اللحظة، لا بعد ظهور النافذة.
            var handle = ShowOverlay();
            frmPurchaseOrderAddEdit frm;
            try { frm = new frmPurchaseOrderAddEdit(id); }
            finally { CloseOverlay(handle); }
            // غير مقفلة (Show وليس ShowDialog) للسماح بالتنقل في باقي البرنامج أثناء فتحها؛ الفحص هنا
            // يحمي من تحديث قائمة تم إغلاق تابها بالفعل قبل إغلاق شاشة الأمر.
            frm.FormClosed += (s, e) =>
            {
                if (!IsDisposed && frm.DialogResult == DialogResult.OK)
                    LoadData();
            };
            frm.Show(this.FindForm());
        }

        private int GetFocusedId()
        {
            var row = gridView1.GetFocusedRow() as PurchaseOrderList;
            return row?.Id ?? 0;
        }

        private List<int> GetSelectedIds()
        {
            var ids = new List<int>();
            var handles = gridView1.GetSelectedRows();
            if (handles != null && handles.Length > 0)
            {
                foreach (int h in handles)
                    if (gridView1.GetRow(h) is PurchaseOrderList po) ids.Add(po.Id);
            }
            else
            {
                int id = GetFocusedId();
                if (id > 0) ids.Add(id);
            }
            return ids;
        }

        private void EditSelected()
        {
            int id = GetFocusedId();
            if (id <= 0)
            {
                XtraMessageBox.Show("يرجى تحديد أمر شراء أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(id);
        }

        private void OpenFocusedForAction()
        {
            int id = GetFocusedId();
            if (id <= 0)
            {
                XtraMessageBox.Show("يرجى تحديد أمر شراء أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenForAction(id);
        }

        /// <summary>"فتح" — يفتح السجل المُركَّز عليه للعرض فقط بلا تعديل (اعتماد/رفض إن وُجدت صلاحية، لكن
        /// بلا تعديل بيانات) — متاح لأي مستخدم يصل الشاشة بخلاف OpenAddEdit المحكوم بـ _canAdd/_canSave، إذ العرض
        /// وحده لا يغيّر بيانات (نفس منطق ucPurchaseRequests.bbiOpen). يُعيد تحميل الشبكة دوماً عند الإغلاق
        /// (لا يعتمد على DialogResult كما في OpenAddEdit) لأن اعتماد/رفض يُكتب مباشرة في قاعدة البيانات
        /// دون أن يُحدِّث DialogResult الخاص بالنموذج.</summary>
        private void OpenForAction(int id)
        {
            var handle = ShowOverlay();
            frmPurchaseOrderAddEdit frm;
            try
            {
                frm = new frmPurchaseOrderAddEdit();
                frm.OpenForAction(id);
            }
            finally { CloseOverlay(handle); }

            frm.FormClosed += (s, e) =>
            {
                if (!IsDisposed) LoadData();
            };
            frm.Show(this.FindForm());
        }

        private void DeleteSelected()
        {
            if (!_canDelete)
            {
                XtraMessageBox.Show("ليس لديك صلاحية حذف أوامر الشراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ids = GetSelectedIds();
            if (ids.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد أمر شراء واحد على الأقل للحذف.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var locked = _allRecords
                .Where(r => ids.Contains(r.Id) && r.OverallStatus == PurchaseOrderStatus.Approved)
                .Select(r => PurchaseOrderNumberFormatter.FormatPONumber(r.Num, r.OrderDate))
                .ToList();
            if (locked.Any())
            {
                XtraMessageBox.Show(
                    $"لا يمكن حذف أوامر الشراء المعتمدة التالية:\n{string.Join(", ", locked)}",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg = ids.Count == 1 ? "هل أنت متأكد من حذف أمر الشراء المحدد؟" : $"هل أنت متأكد من حذف {ids.Count} أوامر شراء؟";
            if (XtraMessageBox.Show(msg, "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int done = 0;
            var handle = ShowOverlay();
            try
            {
                foreach (var id in ids)
                {
                    try { DB.DeletePurchaseOrder(id); done++; }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ عند حذف أمر #{id}:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally { CloseOverlay(handle); }

            if (done > 0)
            {
                XtraMessageBox.Show($"تم حذف {done} أوامر شراء بنجاح ✓", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        // نفس منهجية ucPurchaseRequests.PrintGrid بالضبط: يطبع صفوف الشبكة كما هي معروضة حالياً (بعد أي
        // فرز/تصفية على مستوى الشبكة)، عبر تقرير rprPurchaseOrderLog بدلاً من طباعة الشبكة مباشرة
        // (gridControl1.ShowPrintPreview القديمة).
        private void PrintGrid()
        {
            if (!_canPrint)
            {
                XtraMessageBox.Show("ليس لديك صلاحية طباعة أوامر الشراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var rows = new List<PurchaseOrderList>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRow(gridView1.GetVisibleRowHandle(i)) is PurchaseOrderList po)
                        rows.Add(po);
                }

                if (rows.Count == 0)
                {
                    XtraMessageBox.Show("لا توجد بيانات للطباعة.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var handle = ShowOverlay();
                try { PurchaseOrderPrinter.PrintLog(rows); }
                finally { CloseOverlay(handle); }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintFocused()
        {
            if (gridView1.GetFocusedRow() is not PurchaseOrderList po) return;

            var handle = ShowOverlay();
            try { PurchaseOrderPrinter.Print(po.Id); }
            finally { CloseOverlay(handle); }
        }

        // ── Bulk Actions ──────────────────────────────────────────────────────
        private void ShowBulkActionMenu()
        {
            var ids = GetSelectedIds();
            if (ids.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد سجل واحد على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // لا نتخلّص من القائمة (لا "using" ولا Dispose يدوي عبر Closed) — القائمة تُعرض بشكل غير
            // متزامن، وأي تخلّص منها في توقيت غير مضمون بالنسبة لمعالج نقر العنصر يسبب
            // ObjectDisposedException. كائن صغير قصير العمر، تركه لجامع المهملات هو الخيار الآمن.
            var menu = new ContextMenuStrip();
            menu.RightToLeft = RightToLeft.Yes;
            menu.Font = DesignSystem.Fonts.Regular(9);

            // اعتماد/رفض لم يعودا إجراءً جماعياً — كل أمر يمر بسلسلة خطوات معتمدين مُسمّين، فيقرر كل
            // خطوة معتمدها بنفسه من نافذة الأمر أو من تبويب "مهامي" (انظر PurchaseOrderWorkflowSync)،
            // تماماً كما هو الحال في ucPurchaseRequests.ShowBulkActionMenu.
            menu.Items.Add($"📤 إرسال {ids.Count} أوامر للاعتماد", null,
                (s, e) => BulkSendForApproval(ids));

            menu.Show(Cursor.Position);
        }

        private void BulkSendForApproval(List<int> ids)
        {
            if (!_canSend)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إرسال أوامر الشراء للاعتماد.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show($"هل تريد إرسال {ids.Count} أوامر للاعتماد؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int done = 0;
            var handle = ShowOverlay();
            try
            {
                foreach (var id in ids)
                {
                    try
                    {
                        var po = DB.PurchaseOrderList.Find(id);
                        if (po == null) continue;

                        PurchaseOrderWorkflowSync.SendForApproval(DB, po);

                        po.OverallStatus = PurchaseOrderStatus.PendingApproval;
                        po.UpdateDate = DateTime.Now;
                        po.UpdateMachine = Session.Machine;
                        po.UpdateBy = Session.CurrentUser?.Id ?? 1;

                        DB.PurchaseOrderList.Edit(id, po);
                        done++;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ عند إرسال أمر #{id}:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally { CloseOverlay(handle); }

            if (done > 0)
            {
                XtraMessageBox.Show($"✓ تم إرسال {done} أوامر للاعتماد", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = gridView1.FocusedRowHandle >= 0 && _allRecords.Count > 0;
            bbiEdit.Enabled = hasSelection && _canSave;
            bbiDelete.Enabled = hasSelection && _canDelete;
            bbiPrint.Enabled = _allRecords.Count > 0 && _canPrint;
            bbiOpen.Enabled = hasSelection; // عرض/تصفح لا يغيّر بيانات — متاح لأي مستخدم يصل الشاشة
        }

        public void OnProjectChanged() => LoadData();

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        // نفس نمط ShowOverlay/CloseOverlay المعتمد في frmMARAddEdit/frmCIRAddEdit — يعرض مؤشراً دوّاراً
        // فوق هذه الشاشة أثناء أي عملية تلمس قاعدة البيانات، بدل ترك الأزرار بلا استجابة ظاهرة.
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
