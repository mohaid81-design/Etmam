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
    /// <summary>Modal picker for choosing a secondary discipline — same list/search/select toolbar
    /// pattern as frmDrawingsSubCategorySelect. Opened from frmCIRAddEdit.btnSelectSecondaryDiscipline.
    /// When disciplineFilter is set (the parent discipline currently chosen in frmCIRAddEdit), the
    /// grid starts pre-filtered to that discipline's own sub-disciplines, matching lueSecondaryDiscipline's
    /// own cascading behavior — the user can still clear the filter to browse every discipline's list.</summary>
    public partial class frmSecondaryDisciplineSelect : XtraForm
    {
        protected DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public SecondaryDisciplinesList? SelectedSecondaryDiscipline { get; private set; }

        private readonly int? _disciplineFilter;
        private List<SecondaryDisciplinesList> _all = new();

        public frmSecondaryDisciplineSelect(int? disciplineFilter = null)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _disciplineFilter = disciplineFilter;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            repositoryItemLookUpDiscipline.DataSource = DC.DisciplinesList.GetBy("IsDelete = 0").ToList();
            repositoryItemLookUpDiscipline.DisplayMember = "Name";
            repositoryItemLookUpDiscipline.ValueMember = "Id";
            repositoryItemLookUpDiscipline.QueryPopUp += (s, e) =>
            {
                repositoryItemLookUpDiscipline.DataSource = DC.DisciplinesList.GetBy("IsDelete = 0").ToList();
            };

            gridView1.DoubleClick += (s, e) => ConfirmSelection();

            bbiSelect.ItemClick += (s, e) => ConfirmSelection();
            bbiRefresh.ItemClick += (s, e) => LoadData();
            btnAdd.ItemClick += (s, e) => AddNewSecondaryDiscipline();
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var query = _disciplineFilter != null
                    ? DC.SecondaryDisciplinesList.GetBy("IsDelete = 0 AND DisciplineId = @DisciplineId", new { DisciplineId = _disciplineFilter })
                    : DC.SecondaryDisciplinesList.GetBy("IsDelete = 0");

                _all = query.OrderBy(s => s.Name).ToList();
                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل التخصصات الثانوية: {ex.Message}", "خطأ",
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
                : _all.Where(s => s.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true).ToList();

            gridControl1.DataSource = new BindingList<SecondaryDisciplinesList>(filtered);
            barStaticItem1.Caption = $"عدد السجلات : {filtered.Count}";
        }

        private void AddNewSecondaryDiscipline()
        {
            if (!Data.PermissionService.HasPermission(PermNames.SecondaryDisciplines))
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة التخصصات الثانوية.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmSecondaryDisciplineAddEdit frm;
            try { frm = new frmSecondaryDisciplineAddEdit(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
            }

            LoadData();
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not SecondaryDisciplinesList secondaryDiscipline)
            {
                XtraMessageBox.Show("يرجى اختيار تخصص ثانوي.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedSecondaryDiscipline = secondaryDiscipline;
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
