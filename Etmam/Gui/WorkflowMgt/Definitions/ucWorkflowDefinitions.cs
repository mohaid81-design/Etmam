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
    /// <summary>Standalone (no ProcurementListControlBase inheritance, by request — that base class's
    /// grid/toolbar are built at runtime in its own constructor, which meant this control showed an
    /// empty canvas in the Visual Studio Designer since none of its visible content was its own) list
    /// screen for workflow procedures. Duplicates the same grid+toolbar shape
    /// ProcurementListControlBase provides, but owns its controls directly so they're visible/editable
    /// in the Designer via its paired .Designer.cs.</summary>
    public partial class ucWorkflowDefinitions : BaseUserControl
    {
        private const string TitleSingular = "الإجراء";
        private IDataHelper<WorkflowDefinitionList> Helper => DC.WorkflowDefinitionList;

        public ucWorkflowDefinitions()
        {
            InitializeComponent();

            gridView.OptionsBehavior.Editable = false;

            bbiNew.ItemClick += (s, e) => { if (EnsurePermitted()) OpenEditForm(0); };
            bbiEdit.ItemClick += (s, e) => EditFocusedRow();
            bbiDelete.ItemClick += (s, e) => DeleteFocusedRow();
            bbiRefresh.ItemClick += (s, e) => LoadData();
            gridView.DoubleClick += (s, e) => EditFocusedRow();

            if (!DesignMode)
            {
                bool allowed = PermissionService.HasPermission(PermNames.WorkflowEngineSection);
                bbiNew.Enabled = allowed;
                bbiEdit.Enabled = allowed;
                bbiDelete.Enabled = allowed;
            }
        }

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var data = Helper.GetBy("IsDelete = 0");

                // كل مستخدم لا يرى إلا أنواع الإجراءات المصرَّح له بها صراحةً (UserWorkflowAccess) — معيار
                // إضافي إلى جانب صلاحية "إدارة الإجراءات" العامة أعلاه التي تتحكم بأزرار الإضافة/التعديل/الحذف.
                data = data.Where(w => PermissionService.CanAccessWorkflowDefinition(DC, w.Id)).ToList();

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

        private void ConfigureColumns(GridView gv)
        {
            DesignSystem.HideAuditColumns(gv);
            // Column captions/order/visibility are configured declaratively in the Designer now
            // (colName/Description/Category/IsActive/gridColumn5) instead of at runtime here.

            // Category stores the internal EntityName value (matches PurchaseRequestWorkflowSync/
            // PurchaseOrderWorkflowSync) — show the Arabic label admins actually chose instead.
            gv.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "Category" && e.Value is string cat)
                {
                    e.DisplayText = cat switch
                    {
                        "PurchaseRequestList" => "طلب شراء",
                        "PurchaseOrderList" => "أمر شراء",
                        "ConstructionInspectionRequestList" => "طلب فحص أعمال (CIR)",
                        _ => e.DisplayText
                    };
                }
            };
        }

        private bool EnsurePermitted()
        {
            if (PermissionService.HasPermission(PermNames.WorkflowEngineSection)) return true;
            XtraMessageBox.Show($"ليس لديك صلاحية إدارة {TitleSingular}.", "غير مصرَّح",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void OpenEditForm(int id)
        {
            var handle = ShowOverlay();
            frmWorkflowDefinitionAddEdit frm;
            try
            {
                frm = new frmWorkflowDefinitionAddEdit();
                if (id > 0) frm.OpenForEdit(id);
            }
            finally { CloseOverlay(handle); }

            frm.FormClosed += (s, e) => LoadData();
            frm.ShowDialog(this);
        }

        private void EditFocusedRow()
        {
            if (!EnsurePermitted()) return;
            if (gridView.GetFocusedRow() is WorkflowDefinitionList row) OpenEditForm(row.Id);
        }

        private void DeleteFocusedRow()
        {
            if (!EnsurePermitted()) return;
            if (gridView.GetFocusedRow() is not WorkflowDefinitionList row) return;

            if (XtraMessageBox.Show($"هل أنت متأكد من حذف هذا السجل ({TitleSingular})؟", "تأكيد الحذف",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            var handle = ShowOverlay();
            try
            {
                DC.DeleteWorkflowDefinition(row.Id);
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

        private void ucWorkflowDefinitions_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
