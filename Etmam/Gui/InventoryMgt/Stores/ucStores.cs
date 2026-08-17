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
    public partial class ucStores : DevExpress.XtraEditors.XtraUserControl
    {
        public ucStores()
        {
            InitializeComponent();
            if (DesignMode) return;

            // Apply styling
            //DesignSystem.ApplyCairoFont(this);
            //DesignSystem.ApplyGridStyle(gridControl1, gridView1);

            this.Load += (s, e) => LoadData();

            // Double click grid row to edit
            gridView1.DoubleClick += (s, e) =>
            {
                var row = gridView1.GetFocusedRow() as StoreList;
                if (row != null)
                {
                    OpenAddEdit(row.Id);
                }
            };
        }

        public void LoadData()
        {
            try
            {
                var dc = Data.DataContext.Shared;
                int prjId = Session.SelectedProjectId ?? 0;
                var data = prjId > 0
                    ? dc.StoreList.GetBy("(PrjId = @PrjId OR PrjId IS NULL) AND IsDelete = 0", new { PrjId = prjId })
                    : dc.StoreList.GetBy("IsDelete = 0");

                gridControl1.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل مخازن:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAddEdit(int id)
        {
            using (var frm = new frmStoreAddEdit(id))
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
            var row = gridView1.GetFocusedRow() as StoreList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مخزن لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        // يتحقق مما إذا كان المخزن مستخدمًا في أي عملية مخزنية
        private bool StoreHasTransactions(int storeId)
        {
            var dc = Data.DataContext.Shared;
            var p = new { storeId };

            return dc.MaterialReceiveList.Exists("StoreId = @storeId AND IsDelete = 0", p)
                || dc.MaterialIssuedList.Exists("StoreId = @storeId AND IsDelete = 0", p)
                || dc.PurchaseReturnList.Exists("StoreId = @storeId AND IsDelete = 0", p)
                || dc.MaterialIssueReturnList.Exists("StoreId = @storeId AND IsDelete = 0", p)
                || dc.MaterialTransferList.Exists("(FromStoreId = @storeId OR ToStoreId = @storeId) AND IsDelete = 0", p);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as StoreList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مخزن لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (StoreHasTransactions(row.Id))
            {
                XtraMessageBox.Show("لا يمكن حذف هذا المخزن لأنه مستخدم في عمليات مخزنية.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا المخزن؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    row.IsDelete = true;
                    row.DeletionDate = DateTime.Now;
                    row.DeletionMachine = Session.Machine;
                    row.DeletionBy = Session.CurrentUser?.Id ?? 1;

                    Data.DataContext.Shared.StoreList.Edit(row.Id, row);
                    XtraMessageBox.Show("تم حذف المخزن بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
