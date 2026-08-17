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
    public partial class ucItems : DevExpress.XtraEditors.XtraUserControl
    {
        public ucItems()
        {
            InitializeComponent();
            if (DesignMode) return;

            DesignSystem.ApplyCairoFont(this);
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);

            // إبقاء صف التصنيف (صف التجميع) بلون خلفيته الأصلي حتى عند التركيز عليه
            gridView1.RowStyle += GridView1_RowStyle;

            // إظهار رقم السطر داخل عمود المؤشر (Indicator) بدلاً من عمود مستقل
            gridView1.OptionsView.ShowIndicator = true;
            gridView1.IndicatorWidth = 35;
            gridView1.CustomDrawRowIndicator += GridView1_CustomDrawRowIndicator;

            this.Load += (s, e) => LoadData();

            // Wire Toolbar Events
            bbiNew.ItemClick += bbiNew_ItemClick;
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            bbiPrint.ItemClick += bbiPrint_ItemClick;

            // Double click grid row to edit (باستثناء صف التصنيف)
            gridView1.DoubleClick += (s, e) =>
            {
                var row = GetFocusedItem();
                if (row != null)
                {
                    OpenAddEdit(row.Id);
                }
            };
        }

        private void GridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) return;

            e.Appearance.BackColor = gridView1.Appearance.GroupRow.BackColor;
            e.Appearance.ForeColor = gridView1.Appearance.GroupRow.ForeColor;
            e.Appearance.Font = gridView1.Appearance.GroupRow.Font;
            e.HighPriority = true;
        }

        private void GridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0) return;
            e.Info.DisplayText = (gridView1.GetVisibleIndex(e.RowHandle) + 1).ToString();
        }

        // يُعيد الصنف المُركَّز عليه، أو null إن كان التركيز على صف التصنيف (صف التجميع)
        private ItemsList? GetFocusedItem()
        {
            if (gridView1.IsGroupRow(gridView1.FocusedRowHandle)) return null;
            return gridView1.GetFocusedRow() as ItemsList;
        }

        public void LoadData()
        {
            try
            {
                var dc = Data.DataContext.Shared;

                // Load Lookups
                var categories = dc.ItemCategory.GetBy("IsDelete = 0").ToList();
                lookUpCategory.DataSource = categories;
                lookUpUnit.DataSource = dc.Units.GetBy("IsDelete = 0").ToList();

                var categoriesById = categories.ToDictionary(c => c.Id);

                var items = dc.ItemsList.GetBy("IsDelete = 0").ToList();

                int prjId = Session.SelectedProjectId ?? 0;
                
                // Fetch transactions for calculation
                string receiveFilter = "IsDelete = 0";
                string issueFilter = "IsDelete = 0";
                string transferFilter = "IsDelete = 0";
                string purReturnFilter = "IsDelete = 0";
                string issueReturnFilter = "IsDelete = 0";

                if (prjId > 0)
                {
                    receiveFilter += " AND PrjId = @PrjId";
                    issueFilter += " AND PrjId = @PrjId";
                    transferFilter += " AND PrjId = @PrjId";
                    purReturnFilter += " AND PrjId = @PrjId";
                    issueReturnFilter += " AND PrjId = @PrjId";
                }

                var prjIdParam = new { PrjId = prjId };
                var receives = dc.MaterialReceiveList.GetBy(receiveFilter, prjIdParam).Select(r => r.Id).ToList();
                var issues = dc.MaterialIssuedList.GetBy(issueFilter, prjIdParam).Select(i => i.Id).ToList();
                var transfers = dc.MaterialTransferList.GetBy(transferFilter, prjIdParam).Select(t => t.Id).ToList();
                var purReturns = dc.PurchaseReturnList.GetBy(purReturnFilter, prjIdParam).Select(r => r.Id).ToList();
                var issueReturns = dc.MaterialIssueReturnList.GetBy(issueReturnFilter, prjIdParam).Select(r => r.Id).ToList();

                // Fetch details
                var receiveDetails = receives.Any() 
                    ? dc.MaterialReceiveDetails.GetBy($"ParentId IN ({string.Join(",", receives)}) AND IsDelete = 0") 
                    : new List<MaterialReceiveDetails>();

                var issueDetails = issues.Any() 
                    ? dc.MaterialIssuedDetails.GetBy($"ParentId IN ({string.Join(",", issues)}) AND IsDelete = 0") 
                    : new List<MaterialIssuedDetails>();

                var transferDetails = transfers.Any() 
                    ? dc.MaterialTransferDetails.GetBy($"ParentId IN ({string.Join(",", transfers)}) AND IsDelete = 0") 
                    : new List<MaterialTransferDetails>();

                var purReturnDetails = purReturns.Any() 
                    ? dc.PurchaseReturnDetails.GetBy($"ParentId IN ({string.Join(",", purReturns)}) AND IsDelete = 0") 
                    : new List<PurchaseReturnDetails>();

                var issueReturnDetails = issueReturns.Any() 
                    ? dc.MaterialIssueReturnDetails.GetBy($"ParentId IN ({string.Join(",", issueReturns)}) AND IsDelete = 0") 
                    : new List<MaterialIssueReturnDetails>();

                // Group transactions by ItemId
                var rxGroup = receiveDetails.GroupBy(d => d.ItemId).ToDictionary(g => g.Key ?? 0, g => new { Qty = g.Sum(x => x.Qty ?? 0), Amount = g.Sum(x => x.TotalPrice ?? 0) });
                var txGroup = issueDetails.GroupBy(d => d.ItemId).ToDictionary(g => g.Key ?? 0, g => new { Qty = g.Sum(x => x.Qty ?? 0), Amount = g.Sum(x => x.TotalPrice ?? 0) });
                var tfGroup = transferDetails.GroupBy(d => d.ItemId).ToDictionary(g => g.Key ?? 0, g => new { Qty = g.Sum(x => x.Qty ?? 0), Amount = g.Sum(x => x.TotalPrice ?? 0) });
                var prGroup = purReturnDetails.GroupBy(d => d.ItemId).ToDictionary(g => g.Key ?? 0, g => new { Qty = g.Sum(x => x.Qty ?? 0), Amount = g.Sum(x => x.TotalPrice ?? 0) });
                var irGroup = issueReturnDetails.GroupBy(d => d.ItemId).ToDictionary(g => g.Key ?? 0, g => new { Qty = g.Sum(x => x.Qty ?? 0), Amount = g.Sum(x => x.TotalPrice ?? 0) });

                // Map to items
                int index = 1;
                foreach (var item in items)
                {
                    item.IdSort = index++;
                    item.CategoryCode = categoriesById.TryGetValue(item.CategoryId ?? 0, out var cat) ? cat.Code : null;

                    rxGroup.TryGetValue(item.Id, out var rx);
                    txGroup.TryGetValue(item.Id, out var tx);
                    tfGroup.TryGetValue(item.Id, out var tf);
                    prGroup.TryGetValue(item.Id, out var pr);
                    irGroup.TryGetValue(item.Id, out var ir);

                    item.PurchasedQty = rx?.Qty ?? 0;
                    item.PurchasedAmount = rx?.Amount ?? 0;
                    item.TotalReceivedAmount = rx?.Amount ?? 0;

                    item.IssuedQty = tx?.Qty ?? 0;
                    item.IssuedAmount = tx?.Amount ?? 0;

                    item.TransfareFromOtherStoreQty = tf?.Qty ?? 0; 
                    item.TransfareFromOtherStoreAmount = tf?.Amount ?? 0;

                    item.PurchaseReturnsQty = pr?.Qty ?? 0;
                    item.TransfareToOtherStoreQty = 0; 

                    item.IssuedReturnsQty = ir?.Qty ?? 0;
                    
                    item.BeginningQty = 0;

                    var lastRxDetail = receiveDetails.Where(d => d.ItemId == item.Id).OrderByDescending(d => d.Id).FirstOrDefault();
                    item.LastPrice = lastRxDetail?.UnitPrice ?? 0;
                }

                gridControl1.DataSource = items;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل الأصناف:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAddEdit(int id)
        {
            using (var frm = new frmItemAddEdit(id))
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
            var row = GetFocusedItem();
            if (row == null)
            {
                if (!gridView1.IsGroupRow(gridView1.FocusedRowHandle))
                    XtraMessageBox.Show("يرجى تحديد صنف لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        // يتحقق مما إذا كان الصنف مستخدمًا في أي عملية مخزنية أو طلب شراء
        private bool ItemHasTransactions(int itemId)
        {
            var dc = Data.DataContext.Shared;
            var p = new { itemId };

            return dc.MaterialReceiveDetails.Exists("ItemId = @itemId AND IsDelete = 0", p)
                || dc.MaterialIssuedDetails.Exists("ItemId = @itemId AND IsDelete = 0", p)
                || dc.MaterialTransferDetails.Exists("ItemId = @itemId AND IsDelete = 0", p)
                || dc.PurchaseReturnDetails.Exists("ItemId = @itemId AND IsDelete = 0", p)
                || dc.MaterialIssueReturnDetails.Exists("ItemId = @itemId AND IsDelete = 0", p)
                || dc.PurchaseRequestDetails.Exists("ItemId = @itemId AND IsDelete = 0", p);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = GetFocusedItem();
            if (row == null)
            {
                if (!gridView1.IsGroupRow(gridView1.FocusedRowHandle))
                    XtraMessageBox.Show("يرجى تحديد صنف لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ItemHasTransactions(row.Id))
            {
                XtraMessageBox.Show("لا يمكن حذف هذا الصنف لأنه مستخدم في عمليات مخزنية أو طلبات شراء.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا الصنف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    row.IsDelete = true;
                    row.DeletionDate = DateTime.Now;
                    row.DeletionMachine = Session.Machine;
                    row.DeletionBy = Session.CurrentUser?.Id ?? 1;

                    Data.DataContext.Shared.ItemsList.Edit(row.Id, row);
                    XtraMessageBox.Show("تم حذف الصنف بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
