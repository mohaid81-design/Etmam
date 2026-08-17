using System.ComponentModel;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    /// <summary>Add/Edit form for Purchase Requests: header + item details grid + attachments panel.</summary>
    public partial class frmPurchaseRequestAddEdit : DevExpress.XtraEditors.XtraForm
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext dc => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private int _prId = 0;                                        // 0 = New, >0 = Edit
        private bool _isDirty = false;                                // Tracks unsaved changes
        private List<PurchaseRequestList> _purchaseList = new();        // Navigator cache
        private int _currentIndex = -1;                               // Current navigator position

        private BindingList<PurchaseRequestDetails> _details = new(); // Detail grid in-memory list
        private List<int> _deletedDetailIds = new();                 // Detail rows pending deletion on save
        private List<ItemsList> _itemsCache = new();                  // Items lookup cache for the detail grid
        private ucAttachmentAddEdit? _ucAttachments;                  // Embedded attachments panel ("المرفقات" tab)

        // ── Constructor ───────────────────────────────────────────────────────
        public frmPurchaseRequestAddEdit()
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
            SetupLookups();
            SetupGrid();
            SetupAttachments();
            Loadlist();
            NewRecord();
        }

        // ── Public API ────────────────────────────────────────────────────────
        /// <summary>Opens the form and navigates directly to an existing PR.</summary>
        public void OpenForEdit(int prId)
        {
            _currentIndex = _purchaseList.FindIndex(r => r.Id == prId);
            if (_currentIndex >= 0)
                LoadRecord(prId);
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            // Main toolbar
            bbiNew.ItemClick    += (s, e) => SafeAction(NewRecord);
            bbiSave.ItemClick   += (s, e) => SafeAction(() => SaveRecord());
            bbiPrint.ItemClick  += (s, e) => PrintRecord();
            bbiAction.ItemClick += (s, e) => ShowActionMenu();

            // Navigation
            bbiFirst.ItemClick  += (s, e) => NavigateFirst();
            bbiPrev.ItemClick   += (s, e) => NavigatePrev();
            bbiNext.ItemClick   += (s, e) => NavigateNext();
            bbiLast.ItemClick   += (s, e) => NavigateLast();

            // Search bar — press Enter in the embedded editor to fetch a record
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return && barEditItem1.EditValue != null)
                    FetchBySearch();
            };

            // Header dirty tracking
            lookUpEditPrj.EditValueChanged       += OnHeaderChanged;
            dateEditRequestDate.EditValueChanged  += OnHeaderChanged;
            dateEditRequiredDate.EditValueChanged += OnHeaderChanged;
            memoEditPurpose.EditValueChanged      += OnHeaderChanged;
            comboBoxEditSupplyStatus.EditValueChanged += OnHeaderChanged;
            comboBoxEditPriority.EditValueChanged     += OnHeaderChanged;

            // Detail grid shortcuts
            gvPR.KeyDown           += GridView_KeyDown;
            gvPR.FocusedRowChanged += (s, e) => UpdateDetailButtonStates();
            gvPR.SelectionChanged  += (s, e) => UpdateDetailButtonStates();

            // Form closing guard
            this.FormClosing += FrmPurchaseRequestAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            // lookUpEditPrj → Projects (المشروع/الإدارة الطالبة)
            lookUpEditPrj.Properties.DataSource    = dc.ProjectsList.GetBy("IsDelete = 0");
            lookUpEditPrj.Properties.ValueMember   = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.NullText      = "-- اختر المشروع --";

            // lookUpEditStore → Stores (المخزن)
            lookUpEditStore.Properties.DataSource    = dc.StoreList.GetBy("IsDelete = 0");
            lookUpEditStore.Properties.ValueMember   = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText      = "-- اختر المخزن --";
        }

        private void SetupGrid()
        {
            DesignSystem.ApplyGridStyle(gcPR, gvPR);
            gvPR.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            SetupDetailColumnEditors();
            BindDetails(new List<PurchaseRequestDetails>());
        }

        private void SetupDetailColumnEditors()
        {
            _itemsCache = dc.ItemsList.GetBy("IsDelete = 0").ToList();

            // colItem → LookUp on ItemsList (اختيار الصنف)
            repositoryItemLookUpEditItem.DataSource    = _itemsCache;
            repositoryItemLookUpEditItem.ValueMember   = "Id";
            repositoryItemLookUpEditItem.DisplayMember = "Code";
            repositoryItemLookUpEditItem.NullText      = "";
            colItem.ColumnEdit = repositoryItemLookUpEditItem;

            // colUnit → LookUp على الوحدات (تُملأ تلقائياً من الصنف، غير قابلة للتعديل اليدوي)
            repositoryItemLookUpEditUnit.DataSource    = dc.Units.GetBy("IsDelete = 0");
            repositoryItemLookUpEditUnit.ValueMember   = "Id";
            repositoryItemLookUpEditUnit.DisplayMember = "Abbreviation";
            repositoryItemLookUpEditUnit.NullText      = "";
            colUnit.ColumnEdit = repositoryItemLookUpEditUnit;

            // colCC → LookUp على مراكز التكلفة
            repositoryItemLookUpEditCC.DataSource    = dc.CostCenterList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditCC.ValueMember   = "Id";
            repositoryItemLookUpEditCC.DisplayMember = "Name";
            repositoryItemLookUpEditCC.NullText      = "";
            colCC.ColumnEdit = repositoryItemLookUpEditCC;

            // colBudget → LookUp على بنود الموازنة
            repositoryItemLookUpEditBDG.DataSource    = dc.BudgetList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditBDG.ValueMember   = "Id";
            repositoryItemLookUpEditBDG.DisplayMember = "Description";
            repositoryItemLookUpEditBDG.NullText      = "";

            // colAddItem → فتح قائمة الأصناف لاختيار عدة أصناف دفعة واحدة
            repositoryItemButtonEditAddItem.ButtonClick += RepositoryItemButtonEditAddItem_ButtonClick;

            // colDeleteItem → حذف البند المُركَّز عليه
            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            // عند اختيار الصنف: إكمال الوحدة والوصف تلقائياً لنفس الصف
            gvPR.CellValueChanged += GvPR_CellValueChanged;
        }

        /// <summary>Embeds the reusable attachment control into the "المرفقات" tab's navigation frame.</summary>
        private void SetupAttachments()
        {
            _ucAttachments = new ucAttachmentAddEdit();
            SetupNavigationPage(_ucAttachments);
            _ucAttachments.SaveRequired += SaveAndReturnId;
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

            _prId = prId;
            _isDirty = false; // pause dirty tracking while filling fields

            // Header fields
            textEditNum.Text               = FormatPRNumber(pr.Num);
            lookUpEditPrj.EditValue        = pr.PrjId;
            lookUpEditStore.EditValue      = pr.StoreId;
            dateEditRequestDate.EditValue  = pr.RequestDate;
            dateEditRequiredDate.EditValue = pr.RequiredDate;
            memoEditPurpose.EditValue      = pr.Purpose;
            comboBoxEditPriority.EditValue = "عادي"; // default

            LoadDetails(prId);
            _ucAttachments?.LoadFor("PurchaseRequestList", _prId);

            UpdateNavigatorCaption();
            SetDirty(false);
        }

        private void LoadDetails(int prId)
        {
            _deletedDetailIds.Clear();
            var list = dc.PurchaseRequestDetails
                         .GetBy("PRId = @id AND IsDelete = 0", new { id = prId });

            BindDetails(list);
            UpdateDetailButtonStates();
        }

        /// <summary>Rebinds the detail grid to a fresh in-memory list and re-wires dirty tracking.</summary>
        private void BindDetails(List<PurchaseRequestDetails> source)
        {
            _details = new BindingList<PurchaseRequestDetails>(source);
            gcPR.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        // ── Record Operations (New / Save / Delete) ──────────────────────────
        private void NewRecord()
        {
            _prId = 0;
            _deletedDetailIds.Clear();
            _isDirty = false; // pause dirty tracking while filling defaults

            textEditNum.Text                    = "جديد";
            lookUpEditPrj.EditValue             = Session.SelectedProjectId;
            dateEditRequestDate.EditValue        = DateTime.Today;
            dateEditRequiredDate.EditValue       = null;
            memoEditPurpose.EditValue            = string.Empty;
            comboBoxEditSupplyStatus.EditValue   = "لم يبدأ";
            comboBoxEditPriority.EditValue       = "عادي";

            BindDetails(new List<PurchaseRequestDetails>());
            _ucAttachments?.LoadFor("PurchaseRequestList", 0);

            _currentIndex = -1;
            UpdateNavigatorCaption();
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
            if (!ValidateHeader()) return false;

            gvPR.CloseEditor();
            gvPR.UpdateCurrentRow();

            try
            {
                if (_prId == 0)
                {
                    // ─── New PR ──────────────────────────────────────────────
                    var pr = BuildHeaderEntity();
                    pr.Num            = GetNextNumberForProject(pr.PrjId);
                    pr.CreatedDate    = DateTime.Now;
                    pr.CreatedMachine = Session.Machine;
                    pr.CreatedBy      = Session.CurrentUser?.Id ?? 1;
                    pr.IsDelete       = false;
                    pr.OverallStatus         = PurchaseRequestStatus.Draft;

                    _prId = dc.PurchaseRequestList.Add(pr);
                    textEditNum.Text = FormatPRNumber(pr.Num);
                }
                else
                {
                    // ─── Edit PR ─────────────────────────────────────────────
                    // Numbering is assigned once at creation and never changes on edit.
                    var pr = BuildHeaderEntity();
                    pr.Num           = dc.PurchaseRequestList.Find(_prId)?.Num;
                    pr.UpdateDate    = DateTime.Now;
                    pr.UpdateMachine = Session.Machine;
                    pr.UpdateBy      = Session.CurrentUser?.Id ?? 1;

                    dc.PurchaseRequestList.Edit(_prId, pr);
                }

                SaveDetails(_prId);
                SetDirty(false);

                Loadlist();
                _currentIndex = _purchaseList.FindIndex(r => r.Id == _prId);
                UpdateNavigatorCaption();

                // Refresh attachments with the real PR id (relevant on first save, when it was 0)
                _ucAttachments?.LoadFor("PurchaseRequestList", _prId);

                if (!silent)
                {
                    XtraMessageBox.Show("تم الحفظ بنجاح ✓", "حفظ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveDetails(int prId)
        {
            var helper = dc.PurchaseRequestDetails;

            // 1. Delete removed rows
            foreach (var id in _deletedDetailIds)
            {
                try { helper.Delete(id); }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ حذف بند #{id}:\n{ex.Message}", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _deletedDetailIds.Clear();

            // 2. Insert or update
            foreach (var item in _details)
            {
                item.PRId  = prId;
                item.PrjId = lookUpEditPrj.EditValue as int?;

                if (item.Id == 0)
                {
                    item.CreatedDate    = DateTime.Now;
                    item.CreatedMachine = Session.Machine;
                    item.CreatedBy      = Session.CurrentUser?.Id ?? 1;
                    item.IsDelete       = false;
                    try { helper.Add(item); }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ إضافة بند:\n{ex.Message}", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    item.UpdateDate    = DateTime.Now;
                    item.UpdateMachine = Session.Machine;
                    item.UpdateBy      = Session.CurrentUser?.Id ?? 1;
                    try { helper.Edit(item.Id, item); }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ تعديل بند #{item.Id}:\n{ex.Message}", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteCurrentRecord()
        {
            if (_prId <= 0)
            {
                XtraMessageBox.Show("لا يوجد سجل محفوظ لحذفه.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pr = dc.PurchaseRequestList.Find(_prId);
            if (pr?.OverallStatus == PurchaseRequestStatus.Approved || pr?.OverallStatus == PurchaseRequestStatus.ConvertedToPO)
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
            gvPR.AddNewRow();
        }

        private void DeleteFocusedDetailRow()
        {
            var row = gvPR.GetFocusedRow() as PurchaseRequestDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل تريد حذف هذا البند؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (row.Id > 0) _deletedDetailIds.Add(row.Id);
            gvPR.DeleteSelectedRows();
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

            if (gvPR.GetRow(e.RowHandle) is PurchaseRequestDetails row)
            {
                row.UnitId      = item?.UnitId;
                row.Description = item?.Name;
            }

            gvPR.RefreshRow(e.RowHandle);
        }

        private void RepositoryItemButtonEditAddItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using var frm = new frmItemSelect();
            frm.ExcludedIds = _details.Where(d => d.ItemId.HasValue).Select(d => d.ItemId!.Value).ToList();

            if (frm.ShowDialog(this) != DialogResult.OK) return;

            foreach (var item in frm.SelectedItems)
            {
                _details.Add(new PurchaseRequestDetails
                {
                    ItemId      = item.Id,
                    UnitId      = item.UnitId,
                    Description = item.Description
                });
            }

            gvPR.MoveLast();
        }

        // ── Status / Action Menu ──────────────────────────────────────────────
        private void ShowActionMenu()
        {
            if (_prId <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ الطلب أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pr = dc.PurchaseRequestList.Find(_prId);
            if (pr == null) return;

            using var menu = new ContextMenuStrip();
            menu.RightToLeft = RightToLeft.Yes;
            menu.Font = DesignSystem.Fonts.Regular(9);

            switch (pr.OverallStatus)
            {
                case PurchaseRequestStatus.Draft:
                    menu.Items.Add("📤 إرسال للاعتماد", null, (s, e) => ChangeStatus(PurchaseRequestStatus.PendingApproval));
                    menu.Items.Add(new ToolStripSeparator());
                    menu.Items.Add("🗑️ حذف الطلب",      null, (s, e) => DeleteCurrentRecord());
                    break;
                case PurchaseRequestStatus.PendingApproval:
                    if (PurchaseRequestPermissions.CanApprove(dc))
                    {
                        menu.Items.Add("✅ اعتماد الطلب", null, (s, e) => ChangeStatus(PurchaseRequestStatus.Approved));
                        menu.Items.Add("❌ رفض الطلب",    null, (s, e) => RejectRecord());
                        menu.Items.Add(new ToolStripSeparator());
                    }
                    menu.Items.Add("↩️ إعادة لمسودة", null, (s, e) => ChangeStatus(PurchaseRequestStatus.Draft));
                    break;
                case PurchaseRequestStatus.Approved:
                    menu.Items.Add("🛒 تحويل لأمر شراء", null, (s, e) => ConvertToPO());
                    menu.Items.Add("🔒 إغلاق الطلب",      null, (s, e) => ChangeStatus(PurchaseRequestStatus.Closed));
                    break;
                case PurchaseRequestStatus.Rejected:
                    menu.Items.Add("↩️ إعادة لمسودة", null, (s, e) => ChangeStatus(PurchaseRequestStatus.Draft));
                    menu.Items.Add(new ToolStripSeparator());
                    menu.Items.Add("🗑️ حذف الطلب",     null, (s, e) => DeleteCurrentRecord());
                    break;
                case PurchaseRequestStatus.Closed:
                    menu.Items.Add("(الطلب مغلق ولا تتوفر إجراءات)");
                    break;
                default:
                    menu.Items.Add("(لا توجد إجراءات متاحة)");
                    break;
            }

            // Show near the bbiAction button area
            var pt = PointToClient(Cursor.Position);
            menu.Show(this, pt);
        }

        private void ChangeStatus(string newStatus)
        {
            if (newStatus == PurchaseRequestStatus.Approved && !PurchaseRequestPermissions.CanApprove(dc))
            {
                XtraMessageBox.Show("ليس لديك صلاحية اعتماد طلبات الشراء.", "غير مصرّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var pr = dc.PurchaseRequestList.Find(_prId);
                if (pr == null) return;

                pr.OverallStatus        = newStatus;
                pr.UpdateDate    = DateTime.Now;
                pr.UpdateMachine = Session.Machine;
                pr.UpdateBy      = Session.CurrentUser?.Id ?? 1;

                if (newStatus == PurchaseRequestStatus.Approved)
                {
                    pr.ApprovedBy   = Session.CurrentUser?.Id ?? 1;
                    pr.ApprovedDate = DateTime.Now;
                }

                dc.PurchaseRequestList.Edit(_prId, pr);
                SetDirty(false);

                XtraMessageBox.Show(
                    $"✓ تم تغيير الحالة إلى: {PurchaseRequestStatus.ToDisplay(newStatus)}",
                    "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RejectRecord()
        {
            if (!PurchaseRequestPermissions.CanApprove(dc))
            {
                XtraMessageBox.Show("ليس لديك صلاحية رفض طلبات الشراء.", "غير مصرّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var reason = XtraInputBox.Show("سبب الرفض:", "رفض الطلب", "");
            if (reason == null) return;

            try
            {
                var pr = dc.PurchaseRequestList.Find(_prId);
                if (pr == null) return;

                pr.OverallStatus        = PurchaseRequestStatus.Rejected;
                pr.RejectReason  = reason.ToString();
                pr.UpdateDate    = DateTime.Now;
                pr.UpdateMachine = Session.Machine;
                pr.UpdateBy      = Session.CurrentUser?.Id ?? 1;
                dc.PurchaseRequestList.Edit(_prId, pr);
                SetDirty(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConvertToPO()
        {
            XtraMessageBox.Show(
                "ميزة تحويل إلى أمر شراء ستكون متاحة عند تطوير وحدة أوامر الشراء.",
                "قيد التطوير", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Navigation ────────────────────────────────────────────────────────
        private void NavigateFirst()
        {
            if (_purchaseList.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = 0;
            LoadRecord(_purchaseList[_currentIndex].Id);
        }

        private void NavigatePrev()
        {
            if (_purchaseList.Count == 0 || _currentIndex <= 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex--;
            LoadRecord(_purchaseList[_currentIndex].Id);
        }

        private void NavigateNext()
        {
            if (_purchaseList.Count == 0 || _currentIndex >= _purchaseList.Count - 1) return;
            if (!ConfirmNavigation()) return;
            _currentIndex++;
            LoadRecord(_purchaseList[_currentIndex].Id);
        }

        private void NavigateLast()
        {
            if (_purchaseList.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = _purchaseList.Count - 1;
            LoadRecord(_purchaseList[_currentIndex].Id);
        }

        private void FetchBySearch()
        {
            string searchTerm = barEditItem1.EditValue?.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(searchTerm)) return;

            var found = _purchaseList.FirstOrDefault(r =>
                (r.Num?.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true) ||
                (r.Purpose?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true));

            if (found == null)
            {
                XtraMessageBox.Show($"لم يُعثر على نتائج للبحث: [{searchTerm}]", "بحث",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ConfirmNavigation()) return;
            _currentIndex = _purchaseList.IndexOf(found);
            LoadRecord(found.Id);
        }

        // ── Print ─────────────────────────────────────────────────────────────
        private void PrintRecord()
        {
            if (_prId <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ الطلب قبل الطباعة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XtraMessageBox.Show("وحدة الطباعة ستكون متاحة قريباً.",
                "قيد التطوير", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool ValidateHeader()
        {
            if (lookUpEditPrj.EditValue == null || lookUpEditPrj.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى اختيار المشروع / الإدارة الطالبة.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEditPrj.Focus();
                return false;
            }
            if (dateEditRequestDate.EditValue == null || dateEditRequestDate.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى تحديد تاريخ الإعداد.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEditRequestDate.Focus();
                return false;
            }
            if (_details.Count == 0)
            {
                XtraMessageBox.Show("يرجى إضافة بند واحد على الأقل في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gcPR.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        /// <summary>Builds the header from the editable form fields. Num is assigned separately in SaveRecord.</summary>
        private PurchaseRequestList BuildHeaderEntity()
        {
            return new PurchaseRequestList
            {
                PrjId        = lookUpEditPrj.EditValue as int?,
                StoreId      = lookUpEditStore.EditValue as int?,
                RequestDate  = dateEditRequestDate.EditValue as DateTime?,
                RequiredDate = dateEditRequiredDate.EditValue as DateTime?,
                Purpose      = memoEditPurpose.Text.Trim(),
                OverallStatus       = PurchaseRequestStatus.Draft
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        /// <summary>Next sequential number for a project: one ascending series per project, starting at 1.</summary>
        private int GetNextNumberForProject(int? prjId)
        {
            int maxNum = dc.PurchaseRequestList
                .GetBy("PrjId = @prjId AND IsDelete = 0", new { prjId })
                .Select(r => r.Num ?? 0)
                .DefaultIfEmpty(0)
                .Max();

            return maxNum + 1;
        }

        private static string FormatPRNumber(int? num) => num.HasValue ? $"PR{num.Value:D5}" : "جديد";

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _purchaseList.Count > 0
                ? $"طلب شراء  [{FormatPRNumber(_purchaseList[_currentIndex].Num)}]  |  {_currentIndex + 1} / {_purchaseList.Count}"
                : "إضافة / تعديل طلب شراء — سجل جديد";

            bbiFirst.Enabled = _currentIndex > 0;
            bbiPrev.Enabled  = _currentIndex > 0;
            bbiNext.Enabled  = _currentIndex < _purchaseList.Count - 1;
            bbiLast.Enabled  = _currentIndex < _purchaseList.Count - 1;
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
            if (result == DialogResult.No)  { SetDirty(false); return true; }
            return false; // Cancel
        }

        private void SafeAction(Action action)
        {
            try { action(); }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ غير متوقع:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Form Closing Guard ────────────────────────────────────────────────
        private void FrmPurchaseRequestAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_isDirty) return;

            var result = XtraMessageBox.Show(
                "توجد تغييرات غير محفوظة. هل تريد الحفظ قبل الإغلاق؟",
                "تغييرات غير محفوظة",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)         SafeAction(() => SaveRecord());
            else if (result == DialogResult.Cancel) e.Cancel = true;
        }
    }
}
