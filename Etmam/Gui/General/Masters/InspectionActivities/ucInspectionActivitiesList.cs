using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;

namespace Etmam
{
    public partial class ucInspectionActivitiesList : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _canManage;
        private System.Collections.Generic.Dictionary<int, string> _secondaryDisciplineNames = new();
        private System.Collections.Generic.Dictionary<int, string> _disciplineNamesBySecondaryId = new();

        public ucInspectionActivitiesList()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = Data.PermissionService.HasPermission(PermNames.InspectionActivities);
            bbiNew.Enabled = _canManage;
            bbiEdit.Enabled = _canManage;
            bbiDelete.Enabled = _canManage;

            DesignSystem.ApplyCairoFont(this);

            this.Load += (s, e) => LoadData();

            bbiNew.ItemClick += (s, e) => OpenAddEdit(0);
            bbiEdit.ItemClick += (s, e) => EditSelected();
            bbiDelete.ItemClick += (s, e) => DeleteSelected();
            bbiRefresh.ItemClick += (s, e) => LoadData();

            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;

            gridView1.DoubleClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is InspectionActivityList row)
                    OpenAddEdit(row.Id);
            };
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value is not int secondaryDisciplineId) return;

            if (e.Column.Name == "colSecondaryDiscipline" && _secondaryDisciplineNames.TryGetValue(secondaryDisciplineId, out var subName))
                e.DisplayText = subName;
            else if (e.Column.Name == "colDiscipline" && _disciplineNamesBySecondaryId.TryGetValue(secondaryDisciplineId, out var name))
                e.DisplayText = name;
        }

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var disciplineNames = Data.DataContext.Shared.DisciplinesList.GetBy("IsDelete = 0")
                    .ToDictionary(d => d.Id, d => d.Name ?? "");

                var secondaryDisciplines = Data.DataContext.Shared.SecondaryDisciplinesList.GetBy("IsDelete = 0").ToList();
                _secondaryDisciplineNames = secondaryDisciplines.ToDictionary(s => s.Id, s => s.Name ?? "");
                _disciplineNamesBySecondaryId = secondaryDisciplines
                    .Where(s => s.DisciplineId != null && disciplineNames.ContainsKey(s.DisciplineId.Value))
                    .ToDictionary(s => s.Id, s => disciplineNames[s.DisciplineId!.Value]);

                var data = Data.DataContext.Shared.InspectionActivityList.GetBy("IsDelete = 0");
                gridControl1.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل أنشطة الفحص:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void OpenAddEdit(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة أنشطة الفحص.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openHandle = ShowOverlay();
            frmInspectionActivityAddEdit frm;
            try { frm = new frmInspectionActivityAddEdit(id); }
            finally { CloseOverlay(openHandle); }

            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void EditSelected()
        {
            var row = gridView1.GetFocusedRow() as InspectionActivityList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد نشاط فحص لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void DeleteSelected()
        {
            var row = gridView1.GetFocusedRow() as InspectionActivityList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد نشاط فحص لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف نشاط الفحص هذا؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    row.IsDelete = true;
                    row.DeletionDate = DateTime.Now;
                    row.DeletionMachine = Session.Machine;
                    row.DeletionBy = Session.CurrentUser?.Id ?? 1;

                    Data.DataContext.Shared.InspectionActivityList.Edit(row.Id, row);
                    XtraMessageBox.Show("تم حذف نشاط الفحص بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
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
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
