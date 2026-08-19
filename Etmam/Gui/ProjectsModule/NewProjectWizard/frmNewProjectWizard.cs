using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmNewProjectWizard : DevExpress.XtraEditors.XtraForm
    {
        public frmNewProjectWizard()
        {
            InitializeComponent();
            if (DesignMode) return;

            this.Load += async (s, e) => await LoadLookupsAsync();

            wizProject.SelectedPageChanged += (s, e) =>
            {
                if (wizProject.SelectedPage == wizPageReview) PopulateReview();
            };
        }

        private async Task LoadLookupsAsync()
        {
            try
            {
                lueOwner.Properties.DataSource = await ApiClient.GetProjectClientsAsync();
                lueOwner.Properties.DisplayMember = "Name";
                lueOwner.Properties.ValueMember = "Id";

                lueConsultant.Properties.DataSource = await ApiClient.GetProjectConsultantsAsync();
                lueConsultant.Properties.DisplayMember = "Name";
                lueConsultant.Properties.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"تعذّر تحميل قوائم العملاء/الاستشاريين:\n{ex.Message}", "خطأ",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void PopulateReview()
        {
            var owner = lueOwner.Text;
            var consultant = lueConsultant.Text;

            grdReviewSummary.DataSource = new List<ReviewRow>
            {
                new("رمز المشروع", txtProjectCode.Text),
                new("اسم المشروع", txtProjectNameAr.Text),
                new("المالك/العميل", string.IsNullOrEmpty(owner) ? "—" : owner),
                new("الاستشاري", string.IsNullOrEmpty(consultant) ? "—" : consultant),
                new("تاريخ العقد", dtStart.EditValue is DateTime d ? d.ToString("yyyy-MM-dd") : "—"),
                new("قيمة العقد", calcContractValue.EditValue is decimal or double or int
                    ? Convert.ToDecimal(calcContractValue.EditValue).ToString("N2")
                    : "—"),
            };
        }

        private async void wizProject_FinishClick(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectNameAr.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم المشروع.", "بيانات ناقصة", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            var entity = new Core.ProjectsList
            {
                Num = txtProjectCode.Text.Trim(),
                Name = txtProjectNameAr.Text.Trim(),
                CLId = lueOwner.EditValue as int?,
                CSTId = lueConsultant.EditValue as int?,
                ContractDate = dtStart.EditValue as DateTime?,
                ContractAmount = calcContractValue.EditValue is decimal or double or int
                    ? Convert.ToDecimal(calcContractValue.EditValue)
                    : null,
                CreatedDate = DateTime.Now,
                CreatedMachine = Core.Session.Machine,
                CreatedBy = Core.Session.CurrentUser?.Id ?? 1
            };

            var handle = ShowOverlay();
            try
            {
                await ApiClient.CreateProjectAsync(entity);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء حفظ المشروع:\n{ex.Message}", "خطأ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void wizProject_CancelClick(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        private sealed record ReviewRow(string FieldName, string FieldValue);
    }
}
