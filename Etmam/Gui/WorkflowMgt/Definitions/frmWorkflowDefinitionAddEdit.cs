using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    /// <summary>Defines a procedure: its name, its ordered steps, and which users may act at each step.</summary>
    public class frmWorkflowDefinitionAddEdit : XtraForm
    {
        private static Data.DataContext DC => Data.DataContext.Shared;

        private int _definitionId = 0;
        private BindingList<WorkflowStepList> _steps = new();
        private readonly Dictionary<WorkflowStepList, List<int>> _stepAssignees = new();
        private WorkflowStepList? _currentAssigneeStep;

        // ── Controls ──────────────────────────────────────────────────────────
        private readonly TextEdit txtName = new();
        private readonly MemoEdit txtDescription = new();
        private readonly CheckEdit chkActive = new();

        private readonly GridControl gridControl1 = new();
        private readonly GridView gridView1;

        private readonly CheckedListBoxControl clbUsers = new();

        private readonly SimpleButton btnAddStep;
        private readonly SimpleButton btnDeleteStep;
        private readonly SimpleButton btnMoveUp;
        private readonly SimpleButton btnMoveDown;
        private readonly SimpleButton btnSave;
        private readonly SimpleButton btnCancel;

        public frmWorkflowDefinitionAddEdit()
        {
            gridView1 = new GridView(gridControl1);
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.Add(gridView1);

            btnAddStep = MakeButton("إضافة خطوة", 0);
            btnDeleteStep = MakeButton("حذف خطوة", 100);
            btnMoveUp = MakeButton("▲ أعلى", 200);
            btnMoveDown = MakeButton("▼ أسفل", 290);
            btnSave = MakeButton("حفظ", 0, true);
            btnCancel = MakeButton("إلغاء", 100);

            BuildLayout();
            WireEvents();
            LoadUsers();

            DesignSystem.ApplyFormBranding(this);
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);
            ConfigureStepColumns();

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

            var steps = DC.WorkflowStepList
                .GetBy("WorkflowDefinitionId = @id", new { id })
                .OrderBy(s => s.StepOrder)
                .ToList();

            _steps = new BindingList<WorkflowStepList>(steps);
            gridControl1.DataSource = _steps;

            _stepAssignees.Clear();
            _currentAssigneeStep = null;
            foreach (var step in _steps)
            {
                var userIds = DC.WorkflowStepAssigneeList
                    .GetBy("WorkflowStepId = @id", new { id = step.Id })
                    .Select(a => a.UserId)
                    .ToList();
                _stepAssignees[step] = userIds;
            }

            Text = $"تعديل الإجراء: {def.Name}";
        }

        // ── Layout ────────────────────────────────────────────────────────────
        private void BuildLayout()
        {
            Text = "إجراء";
            Size = new Size(900, 620);
            StartPosition = FormStartPosition.CenterParent;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;

            // Header
            var pnlHeader = new PanelControl { Dock = DockStyle.Top, Height = 110 };

            var lblName = new LabelControl { Text = "اسم الإجراء", Location = new Point(700, 15) };
            txtName.Location = new Point(430, 12);
            txtName.Size = new Size(260, 22);

            var lblDesc = new LabelControl { Text = "الوصف", Location = new Point(700, 45) };
            txtDescription.Location = new Point(20, 45);
            txtDescription.Size = new Size(670, 50);

            chkActive.Text = "مفعّل";
            chkActive.Location = new Point(700, 80);
            chkActive.Checked = true;

            pnlHeader.Controls.Add(lblName);
            pnlHeader.Controls.Add(txtName);
            pnlHeader.Controls.Add(lblDesc);
            pnlHeader.Controls.Add(txtDescription);
            pnlHeader.Controls.Add(chkActive);

            // Bottom (save/cancel)
            var pnlBottom = new PanelControl { Dock = DockStyle.Bottom, Height = 46 };
            btnSave.Location = new Point(700, 8);
            btnCancel.Location = new Point(600, 8);
            DesignSystem.ApplyButtonStyle(btnSave, true);
            pnlBottom.Controls.Add(btnSave);
            pnlBottom.Controls.Add(btnCancel);

            // Middle: assignees (right) + steps grid (fill)
            var pnlAssignees = new PanelControl { Dock = DockStyle.Right, Width = 260 };
            var lblAssignees = new LabelControl { Text = "المستخدمون المعتمدون لهذه الخطوة", Dock = DockStyle.Top, Height = 24 };
            clbUsers.Dock = DockStyle.Fill;
            pnlAssignees.Controls.Add(clbUsers);
            pnlAssignees.Controls.Add(lblAssignees);

            var pnlStepsToolbar = new PanelControl { Dock = DockStyle.Top, Height = 42 };
            pnlStepsToolbar.Controls.Add(btnAddStep);
            pnlStepsToolbar.Controls.Add(btnDeleteStep);
            pnlStepsToolbar.Controls.Add(btnMoveUp);
            pnlStepsToolbar.Controls.Add(btnMoveDown);

            var pnlSteps = new PanelControl { Dock = DockStyle.Fill };
            gridControl1.Dock = DockStyle.Fill;
            pnlSteps.Controls.Add(gridControl1);
            pnlSteps.Controls.Add(pnlStepsToolbar);

            var pnlMiddle = new PanelControl { Dock = DockStyle.Fill };
            pnlMiddle.Controls.Add(pnlSteps);
            pnlMiddle.Controls.Add(pnlAssignees);

            Controls.Add(pnlMiddle);
            Controls.Add(pnlHeader);
            Controls.Add(pnlBottom);
        }

        private static SimpleButton MakeButton(string text, int left, bool primary = false)
        {
            var b = new SimpleButton { Text = text, Left = left, Top = 6, Width = 90, Height = 28 };
            DesignSystem.ApplyButtonStyle(b, primary);
            return b;
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
            return true;
        }

        private void SaveRecord()
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();

            if (!ValidateForm()) return;

            try
            {
                var def = new WorkflowDefinitionList
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    IsActive = chkActive.Checked
                };

                if (_definitionId == 0)
                {
                    def.CreatedDate = DateTime.Now;
                    def.CreatedMachine = Session.Machine;
                    def.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    def.IsDelete = false;
                    _definitionId = DC.WorkflowDefinitionList.Add(def);
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
        }
    }
}
