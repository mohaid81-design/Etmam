using System;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmWorkDoneAddEdit : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private DailyReportWorkDone _workDone;

        public frmWorkDoneAddEdit(DailyReportWorkDone workDone)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _workDone = workDone;
            InitializeData();
        }

        private void InitializeData()
        {
            this.KeyPreview = true;
            this.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Escape) Close();
                if (e.KeyCode == Keys.Enter && !e.Control) btnSave_Click(null, null);
            };

            if (_workDone.Activity != null)
            {
                txtActivityItem.Text = _workDone.Activity.Item;
                txtLocation.Text = _workDone.Activity.Location;
                txtDescription.Text = _workDone.Activity.Description;
            }
            else if (_workDone.ActivityId.HasValue)
            {
                var act = DC.ActivityList.Find(_workDone.ActivityId.Value);
                if (act != null)
                {
                    txtActivityItem.Text = act.Item;
                    txtLocation.Text = act.Location;
                    txtDescription.Text = act.Description;
                }
            }

            txtQty.EditValue = _workDone.Qty ?? 0;
            
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _workDone.Qty = Convert.ToDecimal(txtQty.EditValue);
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
