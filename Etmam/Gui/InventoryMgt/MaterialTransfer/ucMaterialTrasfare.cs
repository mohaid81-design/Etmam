using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Core;
using Data;

namespace Etmam
{
    public partial class ucMaterialTrasfare : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLookUpFromStore = null!;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLookUpToStore = null!;

        public ucMaterialTrasfare()
        {
            InitializeComponent();
            if (DesignMode) return;

            InitializeGrid();
            DesignSystem.ApplyCairoFont(this);

            this.Load += (s, e) => {
                LoadLookups();
                LoadData();
            };

            // Wire Toolbar Events
            bbiNew.ItemClick += bbiNew_ItemClick;
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            bbiPrint.ItemClick += bbiPrint_ItemClick;

            // Wire Store Lookup change
            lookUpEditStore.EditValueChanged += (s, e) => LoadData();

            // Double click grid row to edit
            gridView1.DoubleClick += (s, e) =>
            {
                var row = gridView1.GetFocusedRow() as MaterialTransferList;
                if (row != null)
                {
                    OpenAddEdit(row.Id);
                }
            };
        }

        private void InitializeGrid()
        {
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            riLookUpFromStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            riLookUpToStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { riLookUpFromStore, riLookUpToStore });
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            gridControl1.Dock = DockStyle.Fill;
            splitContainerControl1.Panel2.Controls.Add(gridControl1);

            // Add columns to GridView
            var colId = gridView1.Columns.AddVisible("Id", "م");
            colId.Visible = false;

            var colCode = gridView1.Columns.AddVisible("Code", "رقم التحويل");
            colCode.Width = 100;
            DesignSystem.SetColumnCentered(colCode);

            var colDate = gridView1.Columns.AddVisible("TransferDate", "تاريخ التحويل");
            colDate.Width = 120;
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            DesignSystem.SetColumnCentered(colDate);

            var colFromStore = gridView1.Columns.AddVisible("FromStoreId", "من مخزن");
            colFromStore.ColumnEdit = riLookUpFromStore;
            colFromStore.Width = 200;

            var colToStore = gridView1.Columns.AddVisible("ToStoreId", "إلى مخزن");
            colToStore.ColumnEdit = riLookUpToStore;
            colToStore.Width = 200;

            var colAmount = gridView1.Columns.AddVisible("Amount", "القيمة الإجمالية");
            colAmount.Width = 130;
            colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmount.DisplayFormat.FormatString = "n2";
            DesignSystem.SetColumnCentered(colAmount);

            var colNote = gridView1.Columns.AddVisible("Note", "ملاحظات");
            colNote.Width = 250;

            DesignSystem.ApplyGridStyle(gridControl1, gridView1);
            gridView1.OptionsBehavior.Editable = false;
        }

        private void LoadLookups()
        {
            var dc = Data.DataContext.Shared;
            var stores = dc.StoreList.GetBy("IsDelete = 0").ToList();

            lookUpEditStore.Properties.DataSource = stores;
            lookUpEditStore.Properties.ValueMember = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText = "-- الكل --";

            riLookUpFromStore.DataSource = stores;
            riLookUpFromStore.ValueMember = "Id";
            riLookUpFromStore.DisplayMember = "Name";
            riLookUpFromStore.NullText = "";

            riLookUpToStore.DataSource = stores;
            riLookUpToStore.ValueMember = "Id";
            riLookUpToStore.DisplayMember = "Name";
            riLookUpToStore.NullText = "";
        }

        public void LoadData()
        {
            try
            {
                var dc = Data.DataContext.Shared;
                int prjId = Session.SelectedProjectId ?? 0;
                var storeVal = lookUpEditStore.EditValue;

                string filter = "IsDelete = 0";
                if (prjId > 0)
                {
                    filter += " AND PrjId = @PrjId";
                }
                if (storeVal != null && storeVal != DBNull.Value)
                {
                    filter += " AND (FromStoreId = @StoreId OR ToStoreId = @StoreId)";
                }

                var data = dc.MaterialTransferList.GetBy(filter, new { PrjId = prjId, StoreId = storeVal });
                gridControl1.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل مستندات التحويل:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAddEdit(int id)
        {
            using (var frm = new frmMaterialTransferAddEdit(id))
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenAddEdit(0);
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as MaterialTransferList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مستند تحويل لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as MaterialTransferList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مستند تحويل لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف مستند التحويل هذا؟\nسيتم حذف جميع السطور المرتبطة به وتعديل الأرصدة تلقائياً.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    Data.DataContext.Shared.DeleteMaterialTransfer(row.Id);
                    XtraMessageBox.Show("تم حذف مستند التحويل بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridControl1.ShowPrintPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        public void OnProjectChanged()
        {
            LoadData();
        }
    }
}
