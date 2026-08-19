using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class ucProjectsList : DevExpress.XtraEditors.XtraUserControl
    {
        private List<ProjectListItem> _allProjects = new();

        public ucProjectsList()
        {
            InitializeComponent();
            if (DesignMode) return;

            ConfigureFilters();

            gvProjects.DoubleClick += async (s, e) => await OpenEditAsync();

            this.Load += async (s, e) => await LoadDataAsync();
        }

        private void ConfigureFilters()
        {
            // Client filter has real backing data (StakeholdersList) — same pattern
            // frmProjectAddEdit.cs:48-51 uses for the same lookup.
            var dc = Data.DataContext.Shared;
            lueClient.Properties.DataSource = dc.StakeholdersList.GetBy("IsDelete = 0 AND IsClient = 1");
            lueClient.Properties.DisplayMember = "Name";
            lueClient.Properties.ValueMember = "Id";

            // Company/Branch/Sector/Project-manager/Status filters, saved filters, Archive/Activate,
            // and the Dashboard/Documents/Open-project actions have no backing data model anywhere
            // in the repo yet (no such concepts exist on Core.ProjectsList or Core.UsersList) — disabled
            // rather than left to silently do nothing when clicked. See docs/api-migration-checklist.md.
            cboCompany.Enabled = false;
            cboBranch.Enabled = false;
            cboSector.Enabled = false;
            lueProject.Enabled = false;
            luePM.Enabled = false;
            cboStatus.Enabled = false;
            btnSaveFilter.Enabled = false;

            bbiArchive.Enabled = false;
            bbiActivate.Enabled = false;
            bbiProjectDashboard.Enabled = false;
            bbiProjectDocuments.Enabled = false;
            bbiOpenProject.Enabled = false;
        }

        // ─── Data loading ───────────────────────────────────────────────────

        private async Task LoadDataAsync()
        {
            ShowState(loading: true);
            try
            {
                _allProjects = await ApiClient.GetProjectListAsync();
                ApplyFilter();
                sbiLastRefresh.Caption = $"آخر تحديث: {DateTime.Now:g}";
            }
            catch (Exception ex)
            {
                lblErrorText.Text = $"حدث خطأ أثناء تحميل بيانات المشاريع:\n{ex.Message}";
                ShowState(error: true);
            }
        }

        private void ApplyFilter()
        {
            IEnumerable<ProjectListItem> filtered = _allProjects;

            if (lueClient.EditValue is int clientId)
                filtered = filtered.Where(p => GetClientId(p) == clientId);

            if (dtDateFrom.EditValue is DateTime from)
                filtered = filtered.Where(p => p.StartDate is null || p.StartDate >= from);

            if (dtDateTo.EditValue is DateTime to)
                filtered = filtered.Where(p => p.StartDate is null || p.StartDate <= to);

            var result = filtered.ToList();
            gridControlDataSource(result);

            sbiRecordCount.Caption = $"عدد المشاريع: {result.Count}";
            lblKpiContractValueValue.Text = result.Sum(p => p.ContractValue ?? 0).ToString("N0");

            if (result.Count == 0)
                ShowState(empty: true);
            else
                ShowState();
        }

        // lueClient filters by the client's Id, but ProjectListItem only carries ClientName (the
        // grid doesn't need the raw Id) — the filter re-resolves it from the same lookup list rather
        // than adding an Id-shaped field to the DTO solely for this.
        private int? GetClientId(ProjectListItem p)
        {
            if (string.IsNullOrEmpty(p.ClientName)) return null;
            var match = (lueClient.Properties.DataSource as List<Core.StakeholdersList>)?
                .FirstOrDefault(s => s.Name == p.ClientName);
            return match?.Id;
        }

        private void gridControlDataSource(List<ProjectListItem> items) => grdProjects.DataSource = items;

        private void ShowState(bool loading = false, bool empty = false, bool error = false)
        {
            pnlLoadingState.Visible = loading;
            pnlEmptyState.Visible = empty;
            pnlErrorState.Visible = error;
            grdProjects.Visible = !(loading || empty || error);
        }

        // ─── Toolbar ────────────────────────────────────────────────────────

        private async Task OpenNewProjectAsync()
        {
            var handle = ShowOverlay();
            frmNewProjectWizard frm;
            try { frm = new frmNewProjectWizard(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(FindForm()) == DialogResult.OK)
                    await LoadDataAsync();
            }
        }

        private async Task OpenEditAsync()
        {
            var row = gvProjects.GetFocusedRow() as ProjectListItem;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مشروع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmProjectAddEdit frm;
            try { frm = new frmProjectAddEdit(row.Id); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(FindForm()) == DialogResult.OK)
                    await LoadDataAsync();
            }
        }

        private async Task DeleteAsync()
        {
            var row = gvProjects.GetFocusedRow() as ProjectListItem;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مشروع لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ProjectValidationHelper.HasTransactions(row.Id))
            {
                XtraMessageBox.Show("لا يمكن حذف هذا المشروع لأنه مستخدم في عمليات مرتبطة به.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا المشروع؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            var handle = ShowOverlay();
            try
            {
                await ApiClient.DeleteProjectAsync(row.Id);
                XtraMessageBox.Show("تم حذف المشروع بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void ExportToExcel()
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"قائمة_المشاريع_{DateTime.Today:yyyy-MM-dd}.xlsx",
                DefaultExt = "xlsx"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                grdProjects.ExportToXlsx(dlg.FileName);
                XtraMessageBox.Show("تم التصدير بنجاح ✓", "تصدير", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التصدير:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToPdf()
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                FileName = $"قائمة_المشاريع_{DateTime.Today:yyyy-MM-dd}.pdf",
                DefaultExt = "pdf"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                grdProjects.ExportToPdf(dlg.FileName);
                XtraMessageBox.Show("تم التصدير بنجاح ✓", "تصدير", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التصدير:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Designer-wired handlers ────────────────────────────────────────

        private async void bbiNewProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => await OpenNewProjectAsync();
        private async void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => await OpenEditAsync();
        private async void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => await OpenEditAsync();
        private async void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => await DeleteAsync();
        private void bbiArchive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiActivate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => ExportToExcel();
        private void bbiExportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => ExportToPdf();
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { grdProjects.ShowPrintPreview(); }
            catch (Exception ex) { XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private async void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => await LoadDataAsync();
        private void bbiProjectDashboard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiProjectDocuments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiOpenProject_ItemClick(object sender, System.EventArgs e) { }

        private void btnSearch_Click(object sender, System.EventArgs e) => ApplyFilter();
        private void btnClearFilters_Click(object sender, System.EventArgs e)
        {
            lueClient.EditValue = null;
            dtDateFrom.EditValue = null;
            dtDateTo.EditValue = null;
            ApplyFilter();
        }
        private void btnSaveFilter_Click(object sender, System.EventArgs e) { }
        private async void btnRetry_Click(object sender, System.EventArgs e) => await LoadDataAsync();

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
