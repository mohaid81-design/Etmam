using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Small "create BOQ" dialog: nothing else in the app lets the user pick a project and
    /// name a new Bill of Quantities, so ucBOQList's "New" action opens this before handing off to
    /// ucBOQEditor for the actual item entry.</summary>
    public partial class frmBOQNew : DevExpress.XtraEditors.XtraForm
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        /// <summary>Id of the BOQList row created on OK. Only meaningful when ShowDialog() returns
        /// DialogResult.OK.</summary>
        public int CreatedBOQId { get; private set; }

        public frmBOQNew()
        {
            InitializeComponent();

            var projects = PermissionService.GrantedProjectIds(dc);
            var projectList = dc.ProjectsList.GetBy("IsDelete = 0")
                .Where(p => projects.Contains(p.Id))
                .OrderBy(p => p.Name)
                .ToList();

            lueProject.Properties.DataSource = projectList;
            lueProject.Properties.ValueMember = "Id";
            lueProject.Properties.DisplayMember = "Name";
            lueProject.Properties.Columns.Add(new LookUpColumnInfo("Name", "المشروع"));

            if (Session.SelectedProjectId.HasValue)
                lueProject.EditValue = Session.SelectedProjectId.Value;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (lueProject.EditValue is not int prjId)
            {
                XtraMessageBox.Show("يجب اختيار المشروع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBOQName.Text))
            {
                XtraMessageBox.Show("اسم جدول الكميات مطلوب.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            try
            {
                int newId = 0;
                Data.DataContext.RunInTransaction(tx =>
                {
                    int year = System.DateTime.Now.Year;
                    var prefix = $"BOQ-{year}-";
                    int seq = NumberingService.GetNextNumber(tx, "BOQList", year, () =>
                        dc.BOQList.GetAll()
                            .Where(b => !b.IsDelete && b.BOQCode != null && b.BOQCode.StartsWith(prefix))
                            .Select(b => int.TryParse(b.BOQCode!.Substring(prefix.Length), out var n) ? n : 0)
                            .DefaultIfEmpty(0)
                            .Max());

                    var boq = new BOQList
                    {
                        PrjId = prjId,
                        BOQCode = $"{prefix}{seq:0000}",
                        BOQName = txtBOQName.Text.Trim(),
                        Discipline = string.IsNullOrWhiteSpace(txtDiscipline.Text) ? null : txtDiscipline.Text.Trim(),
                        Revision = string.IsNullOrWhiteSpace(txtRevision.Text) ? "R0" : txtRevision.Text.Trim(),
                        Status = BOQStatus.Draft,
                        TotalAmount = 0,
                        CreatedDate = System.DateTime.Now,
                        CreatedMachine = Session.Machine,
                        CreatedBy = Session.CurrentUser?.Id ?? 1,
                        IsDelete = false,
                    };

                    newId = dc.BOQList.Add(boq, tx);
                    AuditService.LogCreate(tx, "BOQList", newId, boq);
                });

                CreatedBOQId = newId;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الإنشاء:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
