using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>List/grid host for saved opening-balance vouchers, hosted via ucInventoryMgt's tile bar
    /// (OpenTab). Hand-built entirely in code (no paired .Designer.cs/.resx) — see frmOpeningBalanceAddEdit
    /// for why this module took that route instead of the usual Designer-built grid.</summary>
    public class ucOpeningBalance : BaseUserControl
    {
        private HashSet<int> _grantedStoreIds = new();

        // ظهور الشاشة نفسها في القائمة الرئيسية يُحكَم بصلاحية PermNames.OpeningBalance (انظر
        // frmMainPage). أما هنا فلا صلاحية مستقلة أدق من ذلك — يُكتفى بصلاحية المخزن المخصّصة
        // (UserStoreAccess.CanReceive) نفسها المستخدمة أصلاً لتصفية القائمة المنسدلة أعلاه، حيث إن
        // الرصيد الافتتاحي حركة "إدخال" رصيد مطابقة لمعنى الاستلام.
        private bool _canManage;

        private readonly LabelControl lblStore = new() { Text = "المخزن:" };
        private readonly LookUpEdit lookUpEditStore = new();
        private readonly SimpleButton btnNew = new() { Text = "جديد", Width = 80, Height = 28 };
        private readonly SimpleButton btnOpen = new() { Text = "فتح", Width = 80, Height = 28 };
        private readonly SimpleButton btnEdit = new() { Text = "تعديل", Width = 80, Height = 28 };
        private readonly SimpleButton btnDelete = new() { Text = "حذف", Width = 80, Height = 28 };
        private readonly SimpleButton btnRefresh = new() { Text = "تحديث", Width = 80, Height = 28 };
        private readonly SimpleButton btnPrint = new() { Text = "طباعة", Width = 80, Height = 28 };

        private readonly GridControl gridControl1 = new();
        private readonly GridView gridView1;
        private readonly DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLookUpStore = new();

        public ucOpeningBalance()
        {
            gridView1 = new GridView(gridControl1);
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.Add(gridView1);
            gridControl1.RepositoryItems.Add(riLookUpStore);

            var dcInit = Data.DataContext.Shared;
            _canManage = PermissionService.CanAccessAnyStore(dcInit, StoreAction.Receive);
            btnNew.Enabled = _canManage;
            btnOpen.Enabled = _canManage; // يفتح للعرض فقط بلا تعديل (EditFocused يفتح للتعديل الكامل) — نفس صلاحية btnEdit لتفادي تجاوزها
            btnEdit.Enabled = _canManage;
            btnDelete.Enabled = _canManage;
            btnPrint.Enabled = _canManage;

            BuildLayout();
            ConfigureColumns();
            DesignSystem.ApplyCairoFont(this);
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);

            Load += (s, e) =>
            {
                LoadLookups();
                LoadData();
            };

            btnNew.Click += (s, e) => OpenAddEdit(0);
            btnOpen.Click += (s, e) => OpenFocusedReadOnly();
            btnEdit.Click += (s, e) => EditFocused();
            btnDelete.Click += (s, e) => DeleteFocused();
            btnRefresh.Click += (s, e) => LoadData();
            btnPrint.Click += (s, e) =>
            {
                try { gridControl1.ShowPrintPreview(); }
                catch (Exception ex) { XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            };
            lookUpEditStore.EditValueChanged += (s, e) => LoadData();
            gridView1.DoubleClick += (s, e) => EditFocused();

            // يُعاد تقييم قابلية الفتح/التعديل/الحذف لكل صف عند تركيزه — بلا صف مركَّز، تُعطَّل الأزرار
            // المعنية (نفس تنظيم ucItems/ucStores).
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            var row = gridView1.GetFocusedRow() as OpeningBalanceList;
            btnOpen.Enabled = _canManage && row != null;
            btnEdit.Enabled = _canManage && row != null;
            btnDelete.Enabled = _canManage && row != null;
        }

        // ── Layout ────────────────────────────────────────────────────────────
        private void BuildLayout()
        {
            Dock = DockStyle.Fill;

            var pnlTop = new PanelControl { Dock = DockStyle.Top, Height = 44 };
            lblStore.Location = new Point(900, 14);
            lookUpEditStore.Location = new Point(700, 10);
            lookUpEditStore.Size = new Size(190, 24);
            btnNew.Location = new Point(600, 8);
            btnOpen.Location = new Point(512, 8);
            btnEdit.Location = new Point(424, 8);
            btnDelete.Location = new Point(336, 8);
            btnRefresh.Location = new Point(248, 8);
            btnPrint.Location = new Point(160, 8);
            foreach (var b in new[] { btnNew, btnOpen, btnEdit, btnDelete, btnRefresh, btnPrint })
                DesignSystem.ApplyButtonStyle(b);
            pnlTop.Controls.AddRange(new Control[] { lblStore, lookUpEditStore, btnNew, btnOpen, btnEdit, btnDelete, btnRefresh, btnPrint });

            gridControl1.Dock = DockStyle.Fill;

            Controls.Add(gridControl1);
            Controls.Add(pnlTop);
        }

        private void ConfigureColumns()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;

            var colNum = gridView1.Columns.AddField("Num");
            colNum.Caption = "رقم المستند";
            colNum.VisibleIndex = 0;
            colNum.Visible = true;
            colNum.Width = 100;

            var colDate = gridView1.Columns.AddField("BalanceDate");
            colDate.Caption = "تاريخ الرصيد";
            colDate.VisibleIndex = 1;
            colDate.Visible = true;
            colDate.Width = 110;
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDate.DisplayFormat.FormatString = "yyyy-MM-dd";

            var colStore = gridView1.Columns.AddField("StoreId");
            colStore.Caption = "المخزن";
            colStore.ColumnEdit = riLookUpStore;
            colStore.VisibleIndex = 2;
            colStore.Visible = true;
            colStore.Width = 160;

            var colAmount = gridView1.Columns.AddField("Amount");
            colAmount.Caption = "القيمة الإجمالية";
            colAmount.VisibleIndex = 3;
            colAmount.Visible = true;
            colAmount.Width = 120;
            colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmount.DisplayFormat.FormatString = "n2";

            var colNote = gridView1.Columns.AddField("Note");
            colNote.Caption = "ملاحظات";
            colNote.VisibleIndex = 4;
            colNote.Visible = true;
            colNote.Width = 250;
        }

        // ── Data ──────────────────────────────────────────────────────────────
        private void LoadLookups()
        {
            var stores = DC.StoreList.GetBy("IsDelete = 0");

            // فلتر المخزن يعرض فقط المخازن المصرَّح للمستخدم فيها بالاستلام (UserStoreAccess.CanReceive) —
            // الرصيد الافتتاحي حركة "إدخال" لرصيد المخزن، فيتبع نفس صلاحية الاستلام.
            _grantedStoreIds = InventoryStorePermissions.GrantedStoreIds(DC, a => a.CanReceive);
            var accessibleStores = stores.Where(s => _grantedStoreIds.Contains(s.Id)).ToList();

            lookUpEditStore.Properties.DataSource = accessibleStores;
            lookUpEditStore.Properties.ValueMember = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText = "-- الكل --";

            riLookUpStore.DataSource = stores;
            riLookUpStore.ValueMember = "Id";
            riLookUpStore.DisplayMember = "Name";
            riLookUpStore.NullText = "";
        }

        public override void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var storeVal = lookUpEditStore.EditValue;

                string filter = "IsDelete = 0";
                if (storeVal != null && storeVal != DBNull.Value)
                {
                    filter += " AND StoreId = @StoreId";
                }
                else
                {
                    var ids = _grantedStoreIds.Count > 0 ? string.Join(",", _grantedStoreIds) : "-1";
                    filter += $" AND StoreId IN ({ids})";
                }

                var data = DC.OpeningBalanceList
                    .GetBy(filter, new { StoreId = storeVal })
                    .OrderByDescending(r => r.BalanceDate)
                    .ThenByDescending(r => r.Id);
                gridControl1.DataSource = data.ToList();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل الأرصدة الافتتاحية:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // نقطة الدخول الموحّدة (btnNew/EditFocused والنقر المزدوج) — الفحص هنا يمنع تجاوز الصلاحية عبر
        // النقر المزدوج الذي لا يمر بحالة تفعيل الأزرار.
        private void OpenAddEdit(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة الأرصدة الافتتاحية.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmOpeningBalanceAddEdit frm;
            try { frm = new frmOpeningBalanceAddEdit(id); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(FindForm()) == DialogResult.OK)
                    LoadData();
            }
        }

        private void EditFocused()
        {
            if (gridView1.GetFocusedRow() is not OpeningBalanceList row)
            {
                XtraMessageBox.Show("يرجى تحديد رصيد افتتاحي لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        // فتح للعرض فقط (بلا حفظ أو إضافة/حذف أصناف) — بخلاف EditFocused الذي يفتح للتعديل الكامل.
        private void OpenFocusedReadOnly()
        {
            if (gridView1.GetFocusedRow() is not OpeningBalanceList row)
            {
                XtraMessageBox.Show("يرجى تحديد رصيد افتتاحي لفتحه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmOpeningBalanceAddEdit frm;
            try
            {
                frm = new frmOpeningBalanceAddEdit();
                frm.OpenReadOnly(row.Id);
            }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                frm.ShowDialog(FindForm());
            }
        }

        private void DeleteFocused()
        {
            if (gridView1.GetFocusedRow() is not OpeningBalanceList row)
            {
                XtraMessageBox.Show("يرجى تحديد رصيد افتتاحي لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا الرصيد الافتتاحي؟\nسيتم حذف جميع السطور المرتبطة به.",
                "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            var handle = ShowOverlay();
            try
            {
                DC.DeleteOpeningBalance(row.Id);
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

        public override void OnProjectChanged() => LoadData();

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
