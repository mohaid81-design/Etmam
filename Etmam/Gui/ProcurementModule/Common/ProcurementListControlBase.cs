using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>
    /// Shared list-screen skeleton for simple Procurement masters (grid + New/Edit/Delete/Refresh toolbar).
    /// Subclasses supply the data helper, grid column captions and the Add/Edit form to open.
    /// </summary>
    public abstract class ProcurementListControlBase<T> : BaseUserControl where T : class, IBaseEntity, new()
    {
        protected readonly GridControl gridControl = new GridControl();
        protected readonly GridView gridView;
        protected readonly SimpleButton btnNew;
        protected readonly SimpleButton btnEdit;
        protected readonly SimpleButton btnDelete;
        protected readonly SimpleButton btnRefresh;

        protected abstract IDataHelper<T> Helper { get; }
        protected abstract string TitleSingular { get; }

        /// <summary>When true, the list is filtered by Session.SelectedProjectId (column "PrjId").</summary>
        protected virtual bool IsProjectScoped => false;

        /// <summary>Extra SQL condition (without leading AND) appended to every query, e.g. "IsVendor = 1".</summary>
        protected virtual string? AdditionalFilter => null;

        /// <summary>When set, gates New/Edit/Delete on this permission (see PermNames) — checked once
        /// per instantiation, matching the pattern every other list screen in the app uses.</summary>
        protected virtual string? RequiredPermissionName => null;

        /// <summary>Optional post-load, per-row filter (e.g. UserWorkflowAccess) applied after the
        /// SQL query but before binding to the grid. No-op by default.</summary>
        protected virtual List<T> FilterForCurrentUser(List<T> data) => data;

        protected ProcurementListControlBase()
        {
            gridView = new GridView(gridControl);
            gridControl.MainView = gridView;
            gridControl.ViewCollection.Add(gridView);
            gridControl.Dock = DockStyle.Fill;

            var toolPanel = new PanelControl { Dock = DockStyle.Top, Height = 42 };
            btnNew = MakeButton("جديد", 0);
            btnEdit = MakeButton("تعديل", 100);
            btnDelete = MakeButton("حذف", 200);
            btnRefresh = MakeButton("تحديث", 300);
            toolPanel.Controls.Add(btnNew);
            toolPanel.Controls.Add(btnEdit);
            toolPanel.Controls.Add(btnDelete);
            toolPanel.Controls.Add(btnRefresh);

            Controls.Add(gridControl);
            Controls.Add(toolPanel);

            // DesignSystem.ApplyCairoFont/ApplyGridStyle are currently no-ops (their bodies are
            // commented out), so styling is applied explicitly here instead of relying on them.
            Font = DesignSystem.Fonts.Regular(9);
            gridView.Appearance.HeaderPanel.Font = DesignSystem.Fonts.Bold(9);
            gridView.Appearance.HeaderPanel.ForeColor = DesignSystem.Colors.Primary;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.Row.Font = DesignSystem.Fonts.Regular(9);
            gridView.Appearance.Row.Options.UseFont = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsBehavior.Editable = false;

            btnNew.Click += (s, e) => { if (EnsurePermitted()) OpenEditForm(0); };
            btnEdit.Click += (s, e) => EditFocusedRow();
            btnDelete.Click += (s, e) => DeleteFocusedRow();
            btnRefresh.Click += (s, e) => LoadData();
            // النقر المزدوج على الشبكة يستدعي EditFocusedRow() مباشرة، بلا مرور عبر حالة تفعيل btnEdit —
            // EnsurePermitted() داخل EditFocusedRow()/DeleteFocusedRow() هو ما يمنع فعلياً تجاوز الصلاحية.
            gridView.DoubleClick += (s, e) => EditFocusedRow();

            this.Load += (s, e) => LoadData();

            if (!DesignMode && RequiredPermissionName != null)
            {
                bool allowed = PermissionService.HasPermission(RequiredPermissionName);
                btnNew.Enabled = allowed;
                btnEdit.Enabled = allowed;
                btnDelete.Enabled = allowed;
            }
        }

        /// <summary>Re-checked at the point of action (not just via the buttons' Enabled state) so
        /// entry points that bypass the toolbar — double-click, or a future row-level button — can't
        /// circumvent RequiredPermissionName.</summary>
        private bool EnsurePermitted()
        {
            if (RequiredPermissionName == null || PermissionService.HasPermission(RequiredPermissionName)) return true;
            XtraMessageBox.Show($"ليس لديك صلاحية إدارة {TitleSingular}.", "غير مصرَّح",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private static SimpleButton MakeButton(string text, int left)
        {
            var b = new SimpleButton { Text = text, Left = left, Top = 6, Width = 90, Height = 28 };
            DesignSystem.ApplyButtonStyle(b);
            return b;
        }

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                string where = "IsDelete = 0";
                if (!string.IsNullOrEmpty(AdditionalFilter)) where += " AND " + AdditionalFilter;

                List<T> data;
                if (IsProjectScoped)
                {
                    int prjId = Session.SelectedProjectId ?? 0;
                    data = (prjId > 0 && !Session.IsSingleProjectUser)
                        ? Helper.GetBy(where + " AND PrjId = @PrjId", new { PrjId = prjId })
                        : Helper.GetBy(where);
                }
                else
                {
                    data = Helper.GetBy(where);
                }

                data = FilterForCurrentUser(data);
                gridControl.DataSource = data;
                ConfigureColumns(gridView);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل بيانات {TitleSingular}:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        protected void SetCaption(string field, string caption, bool centered = false)
        {
            var col = gridView.Columns[field];
            if (col == null) return;
            col.Caption = caption;
            if (centered) DesignSystem.SetColumnCentered(col);
        }

        protected abstract void ConfigureColumns(GridView gv);

        /// <summary>Opens the Add/Edit dialog for the given id (0 = new record). Must call LoadData() on OK.</summary>
        protected abstract void OpenEditForm(int id);

        /// <summary>Deletes the given record. Override when deletion must cascade to child tables (e.g. via a DataContext "special operation").</summary>
        protected virtual void DeleteRecord(int id) => Helper.Delete(id);

        private void EditFocusedRow()
        {
            if (!EnsurePermitted()) return;
            if (gridView.GetFocusedRow() is T row) OpenEditForm(row.Id);
        }

        private void DeleteFocusedRow()
        {
            if (!EnsurePermitted()) return;
            if (gridView.GetFocusedRow() is not T row) return;

            if (XtraMessageBox.Show($"هل أنت متأكد من حذف هذا السجل ({TitleSingular})؟", "تأكيد الحذف",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            var handle = ShowOverlay();
            try
            {
                DeleteRecord(row.Id);
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحذف: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        public override void OnProjectChanged()
        {
            base.OnProjectChanged();
            if (IsProjectScoped) LoadData();
        }

        /// <summary>Shared overlay/spinner helpers (SplashScreenManager pattern) — available to subclasses
        /// so per-screen OpenEditForm overrides can wrap the `new frmXyzAddEdit(...)` construction line.</summary>
        protected IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        protected void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
