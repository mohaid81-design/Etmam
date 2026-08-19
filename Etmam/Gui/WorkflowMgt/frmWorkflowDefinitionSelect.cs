using System.Collections.Generic;
using System.Windows.Forms;
using Core;
using DevExpress.XtraEditors;

namespace Etmam
{
    /// <summary>Lets the user pick which of several candidate workflow procedures should govern a
    /// specific record being sent for approval — see PurchaseRequestWorkflowSync.GetAvailableProcedures
    /// and frmPurchaseRequestAddEdit.SendForApproval. Only shown when there's more than one candidate; a
    /// single candidate is used directly with no prompt, so this form is never seen on a simple
    /// single-procedure install.</summary>
    public partial class frmWorkflowDefinitionSelect : XtraForm
    {
        public int SelectedDefinitionId { get; private set; }

        /// <summary>Design-time only — lets the Visual Studio Designer instantiate this form (it
        /// requires a parameterless constructor). Never used at runtime; real callers always go through
        /// the constructor below with an actual candidate list.</summary>
        public frmWorkflowDefinitionSelect() : this(new List<WorkflowDefinitionList>())
        {
        }

        public frmWorkflowDefinitionSelect(List<WorkflowDefinitionList> candidates)
        {
            InitializeComponent();

            DesignSystem.ApplyButtonStyle(btnSelect, isPrimary: true);
            DesignSystem.ApplyButtonStyle(btnCancel);

            lstProcedures.DataSource = candidates;
            lstProcedures.DisplayMember = "Name";
            lstProcedures.ValueMember = "Id";
            if (candidates.Count > 0) lstProcedures.SelectedIndex = 0;

            btnSelect.Click += (s, e) =>
            {
                if (lstProcedures.SelectedItem is WorkflowDefinitionList def)
                {
                    SelectedDefinitionId = def.Id;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            };
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }
    }
}
