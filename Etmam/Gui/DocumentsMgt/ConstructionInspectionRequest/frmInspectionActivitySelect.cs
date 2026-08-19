using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Modal picker for choosing an inspection activity — same list/search/select toolbar
    /// pattern as frmSecondaryDisciplineSelect, one level deeper. Opened from
    /// frmCIRAddEdit.btnSelectInspectionActivity. When secondaryDisciplineFilter is set (the parent
    /// secondary discipline currently chosen in frmCIRAddEdit), the grid starts pre-filtered to that
    /// secondary discipline's own activities, matching lueInspectionActivity's own cascading behavior —
    /// the user can still clear the filter to browse every secondary discipline's list.</summary>
    public partial class frmInspectionActivitySelect : XtraForm
    {
        protected DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public InspectionActivityList? SelectedInspectionActivity { get; private set; }

        private readonly int? _secondaryDisciplineFilter;
        private List<InspectionActivityList> _all = new();

        public frmInspectionActivitySelect(int? secondaryDisciplineFilter = null)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _secondaryDisciplineFilter = secondaryDisciplineFilter;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            repositoryItemLookUpSecondaryDiscipline.DataSource = DC.SecondaryDisciplinesList.GetBy("IsDelete = 0").ToList();
            repositoryItemLookUpSecondaryDiscipline.DisplayMember = "Name";
            repositoryItemLookUpSecondaryDiscipline.ValueMember = "Id";
            repositoryItemLookUpSecondaryDiscipline.QueryPopUp += (s, e) =>
            {
                repositoryItemLookUpSecondaryDiscipline.DataSource = DC.SecondaryDisciplinesList.GetBy("IsDelete = 0").ToList();
            };

            gridView1.DoubleClick += (s, e) => ConfirmSelection();

            bbiSelect.ItemClick += (s, e) => ConfirmSelection();
            bbiRefresh.ItemClick += (s, e) => LoadData();
            btnAdd.ItemClick += (s, e) => AddNewInspectionActivity();
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var query = _secondaryDisciplineFilter != null
                    ? DC.InspectionActivityList.GetBy("IsDelete = 0 AND SecondaryDisciplineId = @SecondaryDisciplineId", new { SecondaryDisciplineId = _secondaryDisciplineFilter })
                    : DC.InspectionActivityList.GetBy("IsDelete = 0");

                _all = query.OrderBy(a => a.Name).ToList();
                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل أنشطة الفحص: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void ApplyFilter(string? term)
        {
            term = term?.Trim();
            var filtered = string.IsNullOrEmpty(term)
                ? _all
                : _all.Where(a => a.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true).ToList();

            gridControl1.DataSource = new BindingList<InspectionActivityList>(filtered);
            barStaticItem1.Caption = $"عدد السجلات : {filtered.Count}";
        }

        private void AddNewInspectionActivity()
        {
            if (!Data.PermissionService.HasPermission(PermNames.InspectionActivities))
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة أنشطة الفحص.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmInspectionActivityAddEdit frm;
            try { frm = new frmInspectionActivityAddEdit(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
            }

            LoadData();
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not InspectionActivityList inspectionActivity)
            {
                XtraMessageBox.Show("يرجى اختيار نشاط فحص.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedInspectionActivity = inspectionActivity;
            DialogResult = DialogResult.OK;
            Close();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
