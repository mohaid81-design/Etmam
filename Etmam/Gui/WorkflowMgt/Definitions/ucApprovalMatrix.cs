using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>List/grid screen for Approval Matrices ("مصفوفة الاعتماد") — mirrors ucRFQ's
    /// structure/conventions. Not scoped by project access like most other list screens (a matrix is
    /// system-level configuration, not a project-linked business document), so every user who holds
    /// PermNames.ApprovalMatrix sees all of them.</summary>
    public partial class ucApprovalMatrix : DevExpress.XtraEditors.XtraUserControl
    {
        private static DataContext DB => Data.DataContext.Shared;

        private List<ApprovalMatrixList> _allRecords = new();
        private bool _canManage;

        public ucApprovalMatrix()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = PermissionService.HasPermission(PermNames.ApprovalMatrix);
            bbiNew.Enabled = _canManage;

            SetupLookups();
            SetupGrid();

            this.Load += (s, e) => LoadData();

            bbiNew.ItemClick += (s, e) => OpenAddEdit(0);
            bbiOpen.ItemClick += (s, e) => EditSelected();
            bbiEdit.ItemClick += (s, e) => EditSelected();
            bbiDelete.ItemClick += (s, e) => DeleteSelected();
            bbiRefresh.ItemClick += (s, e) => LoadData();
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void SetupLookups()
        {
            repositoryItemLookUpEditProject.DataSource = DB.ProjectsList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditProject.ValueMember = "Id";
            repositoryItemLookUpEditProject.DisplayMember = "Name";
            colProjectId.ColumnEdit = repositoryItemLookUpEditProject;
        }

        private void SetupGrid()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelect = true;

            gridView1.Appearance.Row.BackColor = DesignSystem.Colors.Surface;
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.BackColor = DesignSystem.Colors.Background;
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            gridView1.RowCellStyle += GridView1_RowCellStyle;

            gridView1.DoubleClick += (s, e) => EditSelected();
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();

            repositoryItemButtonEditAction.ButtonClick += (s, e) =>
            {
                if (!_canManage) return;
                if (gridView1.GetFocusedRow() is ApprovalMatrixList rec) OpenAddEdit(rec.Id);
            };
        }

        private void GridView1_RowCellStyle(object? sender, RowCellStyleEventArgs e)
        {
            if (e.Column != colAction) return;

            bool isEvenRow = e.RowHandle % 2 != 0;
            e.Appearance.BackColor = isEvenRow ? gridView1.Appearance.EvenRow.BackColor : gridView1.Appearance.Row.BackColor;
            e.Appearance.Options.UseBackColor = true;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                _allRecords = DB.ApprovalMatrixList
                    .GetBy("IsDelete = 0")
                    .OrderBy(r => r.EntityName)
                    .ToList();

                gridControl1.DataSource = _allRecords;
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل مصفوفات الاعتماد:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // ── Record Operations ─────────────────────────────────────────────────
        private void OpenAddEdit(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة مصفوفات الاعتماد.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmApprovalMatrixAddEdit frm;
            try { frm = new frmApprovalMatrixAddEdit(id); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                    LoadData();
            }
        }

        private int GetFocusedId()
        {
            var row = gridView1.GetFocusedRow() as ApprovalMatrixList;
            return row?.Id ?? 0;
        }

        private List<int> GetSelectedIds()
        {
            var ids = new List<int>();
            var handles = gridView1.GetSelectedRows();
            if (handles != null && handles.Length > 0)
            {
                foreach (int h in handles)
                    if (gridView1.GetRow(h) is ApprovalMatrixList rec) ids.Add(rec.Id);
            }
            else
            {
                int id = GetFocusedId();
                if (id > 0) ids.Add(id);
            }
            return ids;
        }

        private void EditSelected()
        {
            int id = GetFocusedId();
            if (id <= 0)
            {
                XtraMessageBox.Show("يرجى تحديد مصفوفة اعتماد أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(id);
        }

        private void DeleteSelected()
        {
            var ids = GetSelectedIds();
            if (ids.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد مصفوفة اعتماد واحدة على الأقل للحذف.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg = ids.Count == 1
                ? "هل أنت متأكد من حذف مصفوفة الاعتماد المحددة؟"
                : $"هل أنت متأكد من حذف {ids.Count} مصفوفات اعتماد؟";
            if (XtraMessageBox.Show(msg, "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int done = 0;
            var handle = ShowOverlay();
            try
            {
                foreach (var id in ids)
                {
                    try { DB.DeleteApprovalMatrix(id); done++; }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ عند حذف مصفوفة #{id}:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally { CloseOverlay(handle); }

            if (done > 0)
            {
                XtraMessageBox.Show($"تم حذف {done} مصفوفات بنجاح ✓", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = gridView1.FocusedRowHandle >= 0 && _allRecords.Count > 0;
            bbiOpen.Enabled = hasSelection && _canManage;
            bbiEdit.Enabled = hasSelection && _canManage;
            bbiDelete.Enabled = hasSelection && _canManage;
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
