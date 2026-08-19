using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    /// <summary>List/grid screen for Purchase Order amendments ("تعديلات أوامر الشراء") — mirrors
    /// ucRFQ's structure/conventions.</summary>
    public partial class ucPOAmendment : DevExpress.XtraEditors.XtraUserControl
    {
        private static DataContext DB => Data.DataContext.Shared;

        private List<POAmendmentList> _allRecords = new();
        private HashSet<int> _grantedProjectIds = new();
        private bool _canManage;

        public ucPOAmendment()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = PermissionService.HasPermission(PermNames.POAmendment);
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
            _grantedProjectIds = PermissionService.GrantedProjectIds(DB);

            var pos = DB.PurchaseOrderList.GetBy("IsDelete = 0");
            foreach (var po in pos)
                po.FormattedNum = PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate);

            var repositoryItemLookUpEditPO = new RepositoryItemLookUpEdit
            {
                DataSource = pos,
                ValueMember = "Id",
                DisplayMember = "FormattedNum"
            };
            gridControl1.RepositoryItems.Add(repositoryItemLookUpEditPO);
            colPOId.ColumnEdit = repositoryItemLookUpEditPO;
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
                if (gridView1.GetFocusedRow() is POAmendmentList rec) OpenAddEdit(rec.Id);
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
            try
            {
                // تعديلات أوامر الشراء تُصفَّى حسب مشروع أمر الشراء نفسه، لا حقل مشروع خاص بها.
                var poIdsInGrantedProjects = _grantedProjectIds.Count > 0
                    ? DB.PurchaseOrderList
                        .GetBy($"IsDelete = 0 AND PrjId IN ({string.Join(",", _grantedProjectIds)})")
                        .Select(po => po.Id).ToHashSet()
                    : new HashSet<int>();

                _allRecords = DB.POAmendmentList
                    .GetBy("IsDelete = 0")
                    .Where(a => a.POId.HasValue && poIdsInGrantedProjects.Contains(a.POId.Value))
                    .OrderByDescending(r => r.Id)
                    .ToList();

                foreach (var r in _allRecords)
                    r.StatusDisplay = POAmendmentStatus.ToDisplay(r.Status);

                gridControl1.DataSource = _allRecords;
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل تعديلات أوامر الشراء:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Record Operations ─────────────────────────────────────────────────
        private void OpenAddEdit(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة تعديلات أوامر الشراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new frmPOAmendmentAddEdit(id);
            if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                LoadData();
        }

        private int GetFocusedId()
        {
            var row = gridView1.GetFocusedRow() as POAmendmentList;
            return row?.Id ?? 0;
        }

        private List<int> GetSelectedIds()
        {
            var ids = new List<int>();
            var handles = gridView1.GetSelectedRows();
            if (handles != null && handles.Length > 0)
            {
                foreach (int h in handles)
                    if (gridView1.GetRow(h) is POAmendmentList rec) ids.Add(rec.Id);
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
                XtraMessageBox.Show("يرجى تحديد تعديل أمر شراء أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(id);
        }

        private void DeleteSelected()
        {
            var ids = GetSelectedIds();
            if (ids.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد تعديل أمر شراء واحد على الأقل للحذف.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg = ids.Count == 1
                ? "هل أنت متأكد من حذف تعديل أمر الشراء المحدد؟"
                : $"هل أنت متأكد من حذف {ids.Count} تعديلات أوامر شراء؟";
            if (XtraMessageBox.Show(msg, "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int done = 0;
            foreach (var id in ids)
            {
                try { DB.DeletePOAmendment(id); done++; }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ عند حذف تعديل #{id}:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (done > 0)
            {
                XtraMessageBox.Show($"تم حذف {done} تعديلات بنجاح ✓", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void OnProjectChanged() => LoadData();
    }
}
