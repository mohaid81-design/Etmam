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
    /// <summary>Modal picker for choosing one or more floors — same list/search/select toolbar
    /// pattern as frmDisciplineSelect, plus a checkbox row selector (GridMultiSelectMode.
    /// CheckBoxRowSelect) since lueFloor back in frmCIRAddEdit supports multiple floors per request.
    /// Opened from frmCIRAddEdit.btnSelectFloor, pre-filtered to the CIR's currently-selected building
    /// (a floor belongs to exactly one building — same cascading relationship as
    /// SecondaryDisciplinesList under DisciplinesList).</summary>
    public partial class frmFloorSelect : XtraForm
    {
        protected DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<FloorsList> SelectedFloors { get; private set; } = new();

        private readonly int? _buildingId;
        private List<FloorsList> _all = new();

        public frmFloorSelect(int? buildingId = null)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _buildingId = buildingId;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

            // النقر المزدوج يختار الصف الحالي وحده فوراً (تجاوزاً لصناديق الاختيار) — أسرع لمن يريد
            // طابقاً واحداً فقط. زر "اختيار" في الشريط يؤكّد كل الصفوف المُعلَّمة بصندوق الاختيار،
            // لمن يريد أكثر من طابق.
            gridView1.DoubleClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is FloorsList floor)
                    ConfirmSelection(new List<FloorsList> { floor });
            };

            bbiSelect.ItemClick += (s, e) => ConfirmSelection(GetCheckedFloors());
            bbiRefresh.ItemClick += (s, e) => LoadData();
            btnAdd.ItemClick += (s, e) => AddNewFloor();
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        private List<FloorsList> GetCheckedFloors() =>
            gridView1.GetSelectedRows()
                .Select(h => gridView1.GetRow(h))
                .OfType<FloorsList>()
                .ToList();

        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var query = _buildingId != null
                    ? DC.FloorsList.GetBy("IsDelete = 0 AND BuildingId = @BuildingId", new { BuildingId = _buildingId })
                    : DC.FloorsList.GetBy("IsDelete = 0");

                _all = query.OrderBy(f => f.Name).ToList();
                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الطوابق: {ex.Message}", "خطأ",
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
                : _all.Where(f => f.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true).ToList();

            gridControl1.DataSource = new BindingList<FloorsList>(filtered);
            barStaticItem1.Caption = $"عدد السجلات : {filtered.Count}";
        }

        private void AddNewFloor()
        {
            if (!Data.PermissionService.HasPermission(PermNames.Floors))
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة الطوابق.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmFloorAddEdit frm;
            try { frm = new frmFloorAddEdit(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
            }

            LoadData();
        }

        private void ConfirmSelection(List<FloorsList> floors)
        {
            if (floors.Count == 0)
            {
                XtraMessageBox.Show("يرجى اختيار طابق واحد أو أكثر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedFloors = floors;
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
