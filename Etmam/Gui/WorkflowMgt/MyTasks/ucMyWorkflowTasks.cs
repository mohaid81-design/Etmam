using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    /// <summary>Shows workflow instances currently awaiting the logged-in user's approval/rejection, across all procedures.</summary>
    public class ucMyWorkflowTasks : BaseUserControl
    {
        private readonly GridControl gridControl1 = new();
        private readonly GridView gridView1;
        private readonly SimpleButton btnApprove;
        private readonly SimpleButton btnReject;
        private readonly SimpleButton btnRefresh;

        private List<WorkflowTaskRow> _rows = new();

        public ucMyWorkflowTasks()
        {
            gridView1 = new GridView(gridControl1);
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.Add(gridView1);
            gridControl1.Dock = DockStyle.Fill;

            var toolPanel = new PanelControl { Dock = DockStyle.Top, Height = 42 };
            btnApprove = MakeButton("✅ اعتماد", 0);
            btnReject = MakeButton("❌ رفض", 100);
            btnRefresh = MakeButton("تحديث", 200);
            toolPanel.Controls.Add(btnApprove);
            toolPanel.Controls.Add(btnReject);
            toolPanel.Controls.Add(btnRefresh);

            Controls.Add(gridControl1);
            Controls.Add(toolPanel);

            DesignSystem.ApplyCairoFont(this);
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);
            gridView1.OptionsBehavior.Editable = false;
            ConfigureColumns();

            btnApprove.Click += (s, e) => Act("Approved");
            btnReject.Click += (s, e) => Act("Rejected");
            btnRefresh.Click += (s, e) => LoadData();

            this.Load += (s, e) => LoadData();
        }

        private static SimpleButton MakeButton(string text, int left)
        {
            var b = new SimpleButton { Text = text, Left = left, Top = 6, Width = 90, Height = 28 };
            DesignSystem.ApplyButtonStyle(b);
            return b;
        }

        private void ConfigureColumns()
        {
            gridView1.OptionsBehavior.AutoPopulateColumns = false;
            gridView1.Columns.Clear();

            void AddCol(string field, string caption, int width)
            {
                var col = gridView1.Columns.AddField(field);
                col.Caption = caption;
                col.Width = width;
                col.Visible = true;
                col.VisibleIndex = gridView1.Columns.Count - 1;
            }

            AddCol(nameof(WorkflowTaskRow.ProcedureName), "الإجراء", 160);
            AddCol(nameof(WorkflowTaskRow.StepName), "الخطوة الحالية", 140);
            AddCol(nameof(WorkflowTaskRow.Reference), "المرجع", 160);
            AddCol(nameof(WorkflowTaskRow.StartedByName), "بدأه", 130);
            AddCol(nameof(WorkflowTaskRow.StartedDate), "تاريخ البدء", 120);
        }

        public override void LoadData()
        {
            try
            {
                int userId = Session.CurrentUser?.Id ?? 1;
                var pending = WorkflowEngine.GetPendingForUser(userId);

                var defs = DC.WorkflowDefinitionList.GetBy("IsDelete = 0").ToDictionary(d => d.Id);
                var steps = DC.WorkflowStepList.GetBy("IsDelete = 0");
                var users = DC.UsersList.GetBy("IsDelete = 0").ToDictionary(u => u.Id);

                _rows = pending.Select(i => new WorkflowTaskRow
                {
                    InstanceId = i.Id,
                    ProcedureName = defs.TryGetValue(i.WorkflowDefinitionId, out var d) ? (d.Name ?? "—") : "—",
                    StepName = steps.FirstOrDefault(s => s.WorkflowDefinitionId == i.WorkflowDefinitionId
                                                          && s.StepOrder == i.CurrentStepOrder)?.Name ?? "—",
                    Reference = $"{i.EntityName} #{i.EntityRecordId}",
                    StartedByName = users.TryGetValue(i.StartedBy, out var u) ? (u.FullName ?? u.UserName ?? "—") : "—",
                    StartedDate = i.StartedDate
                }).ToList();

                gridControl1.DataSource = _rows;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل المهام:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Act(string action)
        {
            if (gridView1.GetFocusedRow() is not WorkflowTaskRow row)
            {
                XtraMessageBox.Show("يرجى تحديد مهمة أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = action == "Approved" ? "اعتماد" : "رفض";
            var comment = XtraInputBox.Show($"ملاحظة ({title}) - اختياري:", title, "");
            if (comment == null) return; // user cancelled

            try
            {
                WorkflowEngine.Act(row.InstanceId, Session.CurrentUser?.Id ?? 1, action, comment.ToString());
                XtraMessageBox.Show($"تم {title} بنجاح ✓", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class WorkflowTaskRow
        {
            public int InstanceId { get; set; }
            public string ProcedureName { get; set; } = "";
            public string StepName { get; set; } = "";
            public string Reference { get; set; } = "";
            public string StartedByName { get; set; } = "";
            public DateTime? StartedDate { get; set; }
        }
    }
}
