using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using DevExpress.XtraEditors;

namespace Etmam
{
    /// <summary>Small reusable dialog: pick an earlier step of a running/finished workflow instance and
    /// give a mandatory reason, then hand both back to the caller — used by
    /// WorkflowEngine.ReturnToStep callers (currently frmPurchaseRequestAddEdit's "إعادة إلى خطوة سابقة").
    /// Deliberately module-agnostic (takes plain WorkflowStepList rows) so any future module driving its
    /// approval flow through WorkflowEngine can reuse it as-is.</summary>
    public partial class frmWorkflowReturnToStep : DevExpress.XtraEditors.XtraForm
    {
        public int SelectedStepOrder { get; private set; }
        public string Reason { get; private set; } = "";

        /// <param name="steps">Candidate steps to return to — already filtered by the caller to whatever
        /// is legal for the calling context (e.g. steps before the current one only).</param>
        /// <param name="currentStepName">Shown in the title for context; purely informational.</param>
        public frmWorkflowReturnToStep(List<WorkflowStepList> steps, string currentStepName)
        {
            InitializeComponent();

            Text = $"إعادة إلى خطوة سابقة — الخطوة الحالية: {currentStepName}";

            lookUpStep.Properties.DataSource = steps.OrderBy(s => s.StepOrder).ToList();
            lookUpStep.Properties.ValueMember = "StepOrder";
            lookUpStep.Properties.DisplayMember = "Name";
            lookUpStep.Properties.NullText = "-- اختر الخطوة --";

            btnOk.Click += BtnOk_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            if (lookUpStep.EditValue is not int stepOrder)
            {
                XtraMessageBox.Show("يرجى اختيار الخطوة المطلوب الإعادة إليها.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(memReason.Text))
            {
                XtraMessageBox.Show("يرجى كتابة سبب الإعادة.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedStepOrder = stepOrder;
            Reason = memReason.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
