using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Defines a procedure: its name, its ordered steps, and which users may act at each step.</summary>
    public partial class frmWorkflowDefinitionAddEdit : XtraForm
    {
        private static Data.DataContext DC => Data.DataContext.Shared;

        private int _definitionId = 0;
        private BindingList<WorkflowStepList> _steps = new();
        private readonly Dictionary<WorkflowStepList, List<int>> _stepAssignees = new();
        private WorkflowStepList? _currentAssigneeStep;

        // Only these modules integrate with WorkflowEngine today (see
        // PurchaseRequestWorkflowSync/PurchaseOrderWorkflowSync/CIRWorkflowSync's own EntityName
        // constants) — the combo's stored value must match those exactly so GetAvailableProcedures'
        // filter matches.
        private static readonly (string Value, string Label)[] Categories =
        {
            ("PurchaseRequestList", "طلب شراء"),
            ("PurchaseOrderList", "أمر شراء"),
            ("ConstructionInspectionRequestList", "طلب فحص أعمال (CIR)"),
        };

        // Categories whose sync class (PurchaseRequestWorkflowSync/CIRWorkflowSync) actually filters
        // candidates by ProjectId/WorkflowDefinitionDisciplineList — only these show the project/
        // discipline scope controls below. "PurchaseOrderList" is excluded: it's scoped via
        // ApprovalMatrixList instead (see ApprovalMatrixService), a separate mechanism with its own
        // screen (frmApprovalMatrixAddEdit) — showing these fields for it would silently do nothing.
        private static readonly HashSet<string> ScopedCategories = new() { "PurchaseRequestList", "ConstructionInspectionRequestList" };

        public frmWorkflowDefinitionAddEdit()
        {
            InitializeComponent();

            chkActive.Checked = true;

            cmbCategory.Properties.Items.AddRange(Categories.Select(c => c.Label).ToArray());
            cmbCategory.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            lookUpEditProject.Properties.DataSource = DC.ProjectsList.GetBy("IsDelete = 0");
            lookUpEditProject.Properties.ValueMember = "Id";
            lookUpEditProject.Properties.DisplayMember = "Name";
            lookUpEditProject.Properties.Columns.AddRange(new[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name") });

            LoadDisciplines();
            chkGeneralDiscipline.Checked = true;
            chkGeneralDiscipline.CheckedChanged += (s, e) => clbDisciplines.Enabled = !chkGeneralDiscipline.Checked;
            clbDisciplines.Enabled = false;

            cmbCategory.SelectedIndexChanged += (s, e) => UpdateScopeFieldsVisibility();
            UpdateScopeFieldsVisibility();

            DesignSystem.ApplyButtonStyle(btnSave, true);
            DesignSystem.ApplyButtonStyle(btnCancel);
            DesignSystem.ApplyButtonStyle(btnAddStep);
            DesignSystem.ApplyButtonStyle(btnDeleteStep);
            DesignSystem.ApplyButtonStyle(btnMoveUp);
            DesignSystem.ApplyButtonStyle(btnMoveDown);

            WireEvents();
            LoadUsers();
            ConfigureStepColumns();

            // OpenForEdit rebinds this to a freshly-loaded list when editing an existing procedure —
            // but for a brand-new one (this constructor only, no OpenForEdit call) nothing else ever
            // binds the grid, so btnAddStep's rows were added to _steps but never actually displayed.
            gridControl1.DataSource = _steps;

            Text = "إضافة إجراء جديد";
        }

        // ── Public API ────────────────────────────────────────────────────────
        public void OpenForEdit(int id)
        {
            var def = DC.WorkflowDefinitionList.Find(id);
            if (def == null) return;

            _definitionId = id;
            txtName.Text = def.Name ?? "";
            txtDescription.Text = def.Description ?? "";
            chkActive.Checked = def.IsActive;
            cmbCategory.Text = Categories.FirstOrDefault(c => c.Value == def.Category).Label ?? "";
            UpdateScopeFieldsVisibility();

            lookUpEditProject.EditValue = def.ProjectId;

            var disciplineIds = DC.WorkflowDefinitionDisciplineList
                .GetBy("WorkflowDefinitionId = @id", new { id })
                .Select(l => l.DisciplineId)
                .ToList();
            chkGeneralDiscipline.Checked = disciplineIds.Count == 0;
            ApplyCheckedDisciplineIds(disciplineIds);

            var steps = DC.WorkflowStepList
                .GetBy("WorkflowDefinitionId = @id", new { id })
                .OrderBy(s => s.StepOrder)
                .ToList();

            // Populate assignees BEFORE binding the grid: setting gridControl1.DataSource below
            // auto-focuses row 0, which fires FocusedRowChanged -> SwitchAssigneeStep() synchronously,
            // right there, before this method returns. If _stepAssignees were still empty at that
            // moment (as it was when this ran after the DataSource assignment), the first step's
            // checklist would be built from an empty list every time, even though the real assignees
            // get loaded into _stepAssignees a moment later — just too late for that first render.
            _stepAssignees.Clear();
            _currentAssigneeStep = null;
            foreach (var step in steps)
            {
                var userIds = DC.WorkflowStepAssigneeList
                    .GetBy("WorkflowStepId = @id", new { id = step.Id })
                    .Select(a => a.UserId)
                    .ToList();
                _stepAssignees[step] = userIds;
            }

            _steps = new BindingList<WorkflowStepList>(steps);
            gridControl1.DataSource = _steps;

            Text = $"تعديل الإجراء: {def.Name}";
        }

        private void ConfigureStepColumns()
        {
            gridView1.OptionsBehavior.AutoPopulateColumns = false;
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.Columns.Clear();

            var colOrder = gridView1.Columns.AddField("StepOrder");
            colOrder.Caption = "الترتيب";
            colOrder.VisibleIndex = 0;
            colOrder.Visible = true;
            colOrder.OptionsColumn.AllowEdit = false;
            DesignSystem.SetColumnCentered(colOrder);

            var colName = gridView1.Columns.AddField("Name");
            colName.Caption = "اسم الخطوة";
            colName.VisibleIndex = 1;
            colName.Visible = true;

            var colDesc = gridView1.Columns.AddField("Description");
            colDesc.Caption = "الوصف";
            colDesc.VisibleIndex = 2;
            colDesc.Visible = true;
        }

        // ── Events ────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            btnAddStep.Click += (s, e) => AddStep();
            btnDeleteStep.Click += (s, e) => DeleteStep();
            btnMoveUp.Click += (s, e) => MoveStep(-1);
            btnMoveDown.Click += (s, e) => MoveStep(1);
            btnSave.Click += (s, e) => SaveRecord();
            btnCancel.Click += (s, e) => Close();

            gridView1.FocusedRowChanged += (s, e) => SwitchAssigneeStep();
        }

        private void SwitchAssigneeStep()
        {
            if (_currentAssigneeStep != null)
                _stepAssignees[_currentAssigneeStep] = ReadCheckedUserIds();

            _currentAssigneeStep = gridView1.GetFocusedRow() as WorkflowStepList;

            var ids = _currentAssigneeStep != null && _stepAssignees.TryGetValue(_currentAssigneeStep, out var existing)
                ? existing : new List<int>();
            ApplyCheckedUserIds(ids);
            clbUsers.Enabled = _currentAssigneeStep != null;
        }

        // ── Project / Discipline scope ───────────────────────────────────────
        // Only shown/enabled for categories in ScopedCategories — showing them for a category whose
        // sync class doesn't consult ProjectId/WorkflowDefinitionDisciplineList would silently do
        // nothing and mislead whoever sets them.
        private void UpdateScopeFieldsVisibility()
        {
            string? category = Categories.FirstOrDefault(c => c.Label == cmbCategory.Text).Value;
            bool showScope = category != null && ScopedCategories.Contains(category);
            lblProject.Visible = showScope;
            lookUpEditProject.Visible = showScope;
            chkGeneralDiscipline.Visible = showScope;
            lblDisciplines.Visible = showScope;
            clbDisciplines.Visible = showScope;
        }

        private void LoadDisciplines()
        {
            var disciplines = DC.DisciplinesList.GetBy("IsDelete = 0 AND IsActive = 1").OrderBy(d => d.Name).ToList();
            clbDisciplines.Items.Clear();
            foreach (var d in disciplines)
                clbDisciplines.Items.Add(d.Id, d.Name ?? $"تخصص #{d.Id}");
        }

        private List<int> ReadCheckedDisciplineIds()
        {
            var ids = new List<int>();
            foreach (CheckedListBoxItem item in clbDisciplines.Items)
                if (item.CheckState == CheckState.Checked)
                    ids.Add((int)item.Value);
            return ids;
        }

        private void ApplyCheckedDisciplineIds(List<int> ids)
        {
            foreach (CheckedListBoxItem item in clbDisciplines.Items)
                item.CheckState = ids.Contains((int)item.Value) ? CheckState.Checked : CheckState.Unchecked;
        }

        // ── Users list ────────────────────────────────────────────────────────
        private void LoadUsers()
        {
            var users = DC.UsersList.GetBy("IsDelete = 0 AND IsActive = 1").OrderBy(u => u.FullName).ToList();
            clbUsers.Items.Clear();
            foreach (var u in users)
                clbUsers.Items.Add(u.Id, u.FullName ?? u.UserName ?? $"مستخدم #{u.Id}");
            clbUsers.Enabled = false;
        }

        private List<int> ReadCheckedUserIds()
        {
            var ids = new List<int>();
            foreach (CheckedListBoxItem item in clbUsers.Items)
                if (item.CheckState == CheckState.Checked)
                    ids.Add((int)item.Value);
            return ids;
        }

        private void ApplyCheckedUserIds(List<int> ids)
        {
            foreach (CheckedListBoxItem item in clbUsers.Items)
                item.CheckState = ids.Contains((int)item.Value) ? CheckState.Checked : CheckState.Unchecked;
        }

        // ── Step operations ───────────────────────────────────────────────────
        private void AddStep()
        {
            var step = new WorkflowStepList { Name = "خطوة جديدة", StepOrder = _steps.Count + 1 };
            _steps.Add(step);
            _stepAssignees[step] = new List<int>();
            gridView1.FocusedRowHandle = gridView1.GetRowHandle(_steps.Count - 1);
        }

        private void DeleteStep()
        {
            if (gridView1.GetFocusedRow() is not WorkflowStepList row) return;

            if (XtraMessageBox.Show("هل تريد حذف هذه الخطوة؟", "تأكيد",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            _steps.Remove(row);
            _stepAssignees.Remove(row);
            _currentAssigneeStep = null;
            RenumberSteps();
        }

        private void MoveStep(int delta)
        {
            if (gridView1.GetFocusedRow() is not WorkflowStepList row) return;

            int idx = _steps.IndexOf(row);
            int newIdx = idx + delta;
            if (newIdx < 0 || newIdx >= _steps.Count) return;

            _steps.RemoveAt(idx);
            _steps.Insert(newIdx, row);
            RenumberSteps();
            gridView1.FocusedRowHandle = gridView1.GetRowHandle(newIdx);
        }

        private void RenumberSteps()
        {
            for (int i = 0; i < _steps.Count; i++)
                _steps[i].StepOrder = i + 1;
            gridView1.RefreshData();
        }

        // New workflow definition → explicit UserWorkflowAccess row per user (granted for the system
        // admin, denied for everyone else), mirroring frmProjectAddEdit.OnAfterInsert's default-deny
        // provisioning for UserProjectAccess so the access matrix is always complete rather than
        // "no row = implicitly denied".
        private void InitializeWorkflowAccessRows(int workflowDefinitionId)
        {
            const int systemAdminUserId = 1;

            DC.UserWorkflowAccess.Add(new UserWorkflowAccess
            {
                UserID = systemAdminUserId,
                WorkflowId = workflowDefinitionId,
                PermsStatus = true,
                UpdateDate = DateTime.Now,
                UpdateMachine = Session.Machine,
                UpdateBy = Session.CurrentUser?.Id ?? systemAdminUserId
            });

            var otherUsers = DC.UsersList.GetBy("IsDelete = 0 AND Id <> @AdminId", new { AdminId = systemAdminUserId });
            foreach (var user in otherUsers)
            {
                DC.UserWorkflowAccess.Add(new UserWorkflowAccess
                {
                    UserID = user.Id,
                    WorkflowId = workflowDefinitionId,
                    PermsStatus = false,
                    UpdateDate = DateTime.Now,
                    UpdateMachine = Session.Machine,
                    UpdateBy = Session.CurrentUser?.Id ?? systemAdminUserId
                });
            }
        }

        // ── Save ──────────────────────────────────────────────────────────────
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("يرجى إدخال اسم الإجراء.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_steps.Count == 0)
            {
                XtraMessageBox.Show("يرجى إضافة خطوة واحدة على الأقل.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_steps.Any(s => string.IsNullOrWhiteSpace(s.Name)))
            {
                XtraMessageBox.Show("يرجى تسمية جميع الخطوات.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string? validateCategory = Categories.FirstOrDefault(c => c.Label == cmbCategory.Text).Value;
            if (validateCategory != null && ScopedCategories.Contains(validateCategory)
                && !chkGeneralDiscipline.Checked && ReadCheckedDisciplineIds().Count == 0)
            {
                XtraMessageBox.Show("يرجى اختيار تخصص واحد على الأقل، أو تحديد \"عام\".", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>Blocks saving a procedure whose (project, discipline) scope overlaps an existing
        /// active procedure of the same category — a null ProjectId ("كل المشاريع") or an empty
        /// discipline set ("عام") overlaps everything, by definition. Only meaningful for categories in
        /// ScopedCategories (the ones whose sync class actually filters by project/discipline).</summary>
        private bool CheckForConflict(int? projectId, List<int> disciplineIds, string category)
        {
            var others = DC.WorkflowDefinitionList
                .GetBy("IsDelete = 0 AND IsActive = 1 AND Category = @cat AND Id <> @selfId",
                    new { cat = category, selfId = _definitionId });
            if (others.Count == 0) return true;

            var otherIds = others.Select(o => o.Id).ToList();
            var otherDisciplinesByDef = DC.WorkflowDefinitionDisciplineList
                .GetBy($"WorkflowDefinitionId IN ({string.Join(",", otherIds)})")
                .GroupBy(l => l.WorkflowDefinitionId)
                .ToDictionary(g => g.Key, g => g.Select(l => l.DisciplineId).ToHashSet());

            var thisDisciplineSet = disciplineIds.ToHashSet();

            foreach (var other in others)
            {
                bool projectOverlap = projectId == null || other.ProjectId == null || projectId == other.ProjectId;
                if (!projectOverlap) continue;

                bool otherIsGeneral = !otherDisciplinesByDef.TryGetValue(other.Id, out var otherSet) || otherSet.Count == 0;
                bool disciplineOverlap = thisDisciplineSet.Count == 0 || otherIsGeneral || thisDisciplineSet.Overlaps(otherSet!);
                if (!disciplineOverlap) continue;

                XtraMessageBox.Show(
                    $"يتعارض نطاق هذا الإجراء (المشروع/التخصص) مع الإجراء \"{other.Name}\" الموجود بالفعل.\nيرجى تضييق نطاق أحد الإجراءين حتى لا يتداخلا.",
                    "تعارض في نطاق الإجراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SaveRecord()
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();

            if (!ValidateForm()) return;

            string? category = Categories.FirstOrDefault(c => c.Label == cmbCategory.Text).Value;
            int? projectId = lookUpEditProject.EditValue as int?;
            var disciplineIds = chkGeneralDiscipline.Checked ? new List<int>() : ReadCheckedDisciplineIds();

            if (category != null && ScopedCategories.Contains(category) && !CheckForConflict(projectId, disciplineIds, category))
                return;

            var handle = ShowOverlay();
            try
            {
                var def = new WorkflowDefinitionList
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    IsActive = chkActive.Checked,
                    Category = category,
                    ProjectId = projectId
                };

                if (_definitionId == 0)
                {
                    def.CreatedDate = DateTime.Now;
                    def.CreatedMachine = Session.Machine;
                    def.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    def.IsDelete = false;
                    _definitionId = DC.WorkflowDefinitionList.Add(def);
                    InitializeWorkflowAccessRows(_definitionId);
                }
                else
                {
                    def.UpdateDate = DateTime.Now;
                    def.UpdateMachine = Session.Machine;
                    def.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    DC.WorkflowDefinitionList.Edit(_definitionId, def);
                }

                if (_currentAssigneeStep != null)
                    _stepAssignees[_currentAssigneeStep] = ReadCheckedUserIds();

                // Replace all steps/assignees for this definition (simplest correct approach
                // given the small, in-memory-edited row count — mirrors header/detail saves
                // elsewhere in the app that delete-then-reinsert child rows).
                var oldStepIds = DC.WorkflowStepList
                    .GetBy("WorkflowDefinitionId = @id", new { id = _definitionId })
                    .Select(s => s.Id).ToList();

                foreach (var oldId in oldStepIds)
                    DC.WorkflowStepAssigneeList.DeleteBy("WorkflowStepId = @id", new { id = oldId });
                DC.WorkflowStepList.DeleteBy("WorkflowDefinitionId = @id", new { id = _definitionId });

                foreach (var step in _steps)
                {
                    var newStep = new WorkflowStepList
                    {
                        WorkflowDefinitionId = _definitionId,
                        StepOrder = step.StepOrder,
                        Name = step.Name,
                        Description = step.Description,
                        CreatedDate = DateTime.Now,
                        CreatedMachine = Session.Machine,
                        CreatedBy = Session.CurrentUser?.Id ?? 1,
                        IsDelete = false
                    };
                    int newStepId = DC.WorkflowStepList.Add(newStep);

                    if (_stepAssignees.TryGetValue(step, out var userIds))
                    {
                        foreach (var userId in userIds)
                        {
                            DC.WorkflowStepAssigneeList.Add(new WorkflowStepAssigneeList
                            {
                                WorkflowStepId = newStepId,
                                UserId = userId,
                                CreatedDate = DateTime.Now,
                                CreatedMachine = Session.Machine,
                                CreatedBy = Session.CurrentUser?.Id ?? 1,
                                IsDelete = false
                            });
                        }
                    }
                }

                // Replace this definition's discipline scope the same delete-then-reinsert way as its
                // steps above — an empty disciplineIds list (either "عام" was checked, or the category
                // isn't in ScopedCategories) correctly leaves no rows, meaning "applies to every discipline".
                DC.WorkflowDefinitionDisciplineList.DeleteBy("WorkflowDefinitionId = @id", new { id = _definitionId });
                foreach (var disciplineId in disciplineIds)
                {
                    DC.WorkflowDefinitionDisciplineList.Add(new WorkflowDefinitionDisciplineList
                    {
                        WorkflowDefinitionId = _definitionId,
                        DisciplineId = disciplineId,
                        CreatedDate = DateTime.Now,
                        CreatedMachine = Session.Machine,
                        CreatedBy = Session.CurrentUser?.Id ?? 1,
                        IsDelete = false
                    });
                }

                XtraMessageBox.Show("تم حفظ الإجراء بنجاح ✓", "حفظ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ",
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
    }
}
