using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Admin screen for configuring an Approval Matrix (see Core.ApprovalMatrixList) — which
    /// document type/project this matrix applies to, and its amount bands (ApprovalLimitList), each
    /// routing to a WorkflowDefinition procedure. Consulted by ApprovalMatrixService at Send-For-Approval
    /// time (currently only PurchaseOrderWorkflowSync.SendForApproval does — see that class) instead of a
    /// hard-coded single procedure. No matrix configured for a document type/project simply means that
    /// caller keeps its old fallback behavior — this screen is what makes the matrix real, not required
    /// for the app to keep working.</summary>
    public partial class frmApprovalMatrixAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private static readonly string[] KnownEntityNames =
        {
            "PurchaseOrderList", "PurchaseRequestList", "RFQList", "AwardRecommendationList", "POAmendmentList"
        };

        private int _id = 0;
        private bool _isDirty = false;
        private bool _anySaved = false;
        private List<ApprovalMatrixList> _list = new();
        private int _currentIndex = -1;

        private BindingList<ApprovalLimitList> _details = new();
        private List<int> _deletedDetailIds = new();

        public frmApprovalMatrixAddEdit(int id = 0)
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
            SetupLookups();
            SetupGrid();
            Loadlist();

            if (id > 0)
            {
                _currentIndex = _list.FindIndex(r => r.Id == id);
                LoadRecord(id);
            }
            else
            {
                NewRecord();
            }
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            bbiNew.ItemClick += (s, e) => SafeAction(NewRecord);
            bbiSave.ItemClick += (s, e) => SafeAction(() => SaveRecord());

            bbiFirst.ItemClick += (s, e) => NavigateFirst();
            bbiPrev.ItemClick += (s, e) => NavigatePrev();
            bbiNext.ItemClick += (s, e) => NavigateNext();
            bbiLast.ItemClick += (s, e) => NavigateLast();

            comboBoxEditEntityName.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RefreshWorkflowDefinitionLookup(); };
            lookUpEditProject.EditValueChanged += OnHeaderChanged;
            memoEditDescription.EditValueChanged += OnHeaderChanged;
            checkEditIsActive.CheckedChanged += OnHeaderChanged;

            gridView.KeyDown += GridView_KeyDown;

            this.FormClosing += FrmApprovalMatrixAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            comboBoxEditEntityName.Properties.Items.Clear();
            comboBoxEditEntityName.Properties.Items.AddRange(KnownEntityNames);

            lookUpEditProject.Properties.DataSource = dc.ProjectsList.GetBy("IsDelete = 0");
            lookUpEditProject.Properties.ValueMember = "Id";
            lookUpEditProject.Properties.DisplayMember = "Name";
            lookUpEditProject.Properties.NullText = "-- كل المشاريع --";
        }

        private void SetupGrid()
        {
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            RefreshWorkflowDefinitionLookup();
            BindDetails(new List<ApprovalLimitList>());
        }

        private void RefreshWorkflowDefinitionLookup()
        {
            var entityName = comboBoxEditEntityName.EditValue?.ToString();
            var defs = string.IsNullOrEmpty(entityName)
                ? dc.WorkflowDefinitionList.GetBy("IsDelete = 0 AND IsActive = 1")
                : dc.WorkflowDefinitionList.GetBy(
                    "IsDelete = 0 AND IsActive = 1 AND (Category = @c OR Category IS NULL)", new { c = entityName });

            repositoryItemLookUpEditWorkflow.DataSource = defs;
            repositoryItemLookUpEditWorkflow.ValueMember = "Id";
            repositoryItemLookUpEditWorkflow.DisplayMember = "Name";
            repositoryItemLookUpEditWorkflow.NullText = "";
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _list = dc.ApprovalMatrixList
                .GetBy("IsDelete = 0")
                .OrderBy(r => r.EntityName)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.ApprovalMatrixList.Find(id);
            if (rec == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _id = id;
            _isDirty = false;

            comboBoxEditEntityName.EditValue = rec.EntityName;
            RefreshWorkflowDefinitionLookup();
            lookUpEditProject.EditValue = rec.ProjectId;
            memoEditDescription.EditValue = rec.Description;
            checkEditIsActive.Checked = rec.IsActive;

            LoadDetails(id);

            UpdateNavigatorCaption();
            SetDirty(false);
        }

        private void LoadDetails(int id)
        {
            _deletedDetailIds.Clear();
            var list = dc.ApprovalLimitList
                .GetBy("MatrixId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.MinAmount ?? 0)
                .ToList();

            BindDetails(list);
        }

        private void BindDetails(List<ApprovalLimitList> source)
        {
            _details = new BindingList<ApprovalLimitList>(source);
            gridControl.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        // ── Record Operations (New / Save) ───────────────────────────────────
        private void NewRecord()
        {
            _id = 0;
            _deletedDetailIds.Clear();
            _isDirty = false;

            comboBoxEditEntityName.EditValue = KnownEntityNames[0];
            RefreshWorkflowDefinitionLookup();
            lookUpEditProject.EditValue = null;
            memoEditDescription.EditValue = string.Empty;
            checkEditIsActive.Checked = true;

            BindDetails(new List<ApprovalLimitList>());

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            comboBoxEditEntityName.Focus();
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            gridView.CloseEditor();
            gridView.UpdateCurrentRow();

            try
            {
                ApprovalMatrixList? newRec = null;

                Data.DataContext.RunInTransaction(tx =>
                {
                    if (_id == 0)
                    {
                        var rec = BuildHeaderEntity();
                        rec.CreatedDate = DateTime.Now;
                        rec.CreatedMachine = Session.Machine;
                        rec.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rec.IsDelete = false;

                        _id = dc.ApprovalMatrixList.Add(rec, tx);
                        newRec = rec;
                        AuditService.LogCreate(tx, "ApprovalMatrixList", _id, rec);
                    }
                    else
                    {
                        var rec = BuildHeaderEntity();
                        var existing = dc.ApprovalMatrixList.Find(_id);
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;

                        dc.ApprovalMatrixList.Edit(_id, rec, tx);
                        AuditService.LogUpdate(tx, "ApprovalMatrixList", _id, existing, rec);
                    }

                    SaveDetails(_id, tx);
                });

                SetDirty(false);
                _anySaved = true;

                Loadlist();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                if (!silent)
                {
                    XtraMessageBox.Show("تم حفظ مصفوفة الاعتماد بنجاح ✓", "حفظ",
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

        private void SaveDetails(int matrixId, SqlTransaction tx)
        {
            var helper = dc.ApprovalLimitList;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<ApprovalLimitList>();
            var toEdit = new List<ApprovalLimitList>();
            foreach (var item in _details)
            {
                item.MatrixId = matrixId;

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

        // ── Detail Row Operations ─────────────────────────────────────────────
        private void DeleteFocusedDetailRow()
        {
            var row = gridView.GetFocusedRow() as ApprovalLimitList;
            if (row == null) return;

            if (XtraMessageBox.Show("هل تريد حذف هذا النطاق؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (row.Id > 0) _deletedDetailIds.Add(row.Id);
            gridView.DeleteSelectedRows();
            SetDirty();
        }

        private void GridView_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteFocusedDetailRow();
                e.Handled = true;
            }
        }

        // ── Navigation ────────────────────────────────────────────────────────
        private void NavigateFirst()
        {
            if (_list.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = 0;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigatePrev()
        {
            if (_list.Count == 0 || _currentIndex <= 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex--;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateNext()
        {
            if (_list.Count == 0 || _currentIndex >= _list.Count - 1) return;
            if (!ConfirmNavigation()) return;
            _currentIndex++;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateLast()
        {
            if (_list.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = _list.Count - 1;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool ValidateHeader()
        {
            if (string.IsNullOrEmpty(comboBoxEditEntityName.EditValue?.ToString()))
            {
                XtraMessageBox.Show("يرجى اختيار نوع المستند.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxEditEntityName.Focus();
                return false;
            }
            if (_details.Any(d => d.WorkflowDefinitionId is null or 0))
            {
                XtraMessageBox.Show("يرجى اختيار إجراء الاعتماد لكل نطاق مبلغ.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private ApprovalMatrixList BuildHeaderEntity()
        {
            return new ApprovalMatrixList
            {
                EntityName = comboBoxEditEntityName.EditValue?.ToString(),
                ProjectId = lookUpEditProject.EditValue as int?,
                Description = memoEditDescription.Text?.Trim(),
                IsActive = checkEditIsActive.Checked
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"مصفوفة اعتماد  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة / تعديل مصفوفة اعتماد — سجل جديد";

            bbiFirst.Enabled = _currentIndex > 0;
            bbiPrev.Enabled = _currentIndex > 0;
            bbiNext.Enabled = _currentIndex < _list.Count - 1;
            bbiLast.Enabled = _currentIndex < _list.Count - 1;
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

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        private void FrmApprovalMatrixAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                var result = XtraMessageBox.Show(
                    "توجد تغييرات غير محفوظة. هل تريد الحفظ قبل الإغلاق؟",
                    "تغييرات غير محفوظة",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) SafeAction(() => SaveRecord());
                else if (result == DialogResult.Cancel) { e.Cancel = true; return; }
            }

            this.DialogResult = _anySaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
