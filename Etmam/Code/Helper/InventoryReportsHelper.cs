using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>Data-access layer for "تقارير المخزون" (ucInventoryReports): current stock balance, item stock
    /// card, period movement summary and stocking variance. Deliberately duplicates
    /// <see cref="StoreBalanceHelper"/>'s netting formula (batched across many stores at once instead of one
    /// store at a time) rather than refactoring that class — it has other callers
    /// (frmItemSelect/frmMaterialIssuedAddEdit/frmMaterialTransferAddEdit/frmStockingAddEdit) and touching it
    /// carries regression risk out of proportion to this scoped reporting feature.</summary>
    public static class InventoryReportsHelper
    {
        /// <summary>Stores the current user may see in these reports: project-scoped (a store with
        /// PrjId == null belongs to every project) intersected with view permission
        /// (InventoryStorePermissions — same "PermsStatus" flag ucStocking.cs already uses for read-only
        /// screens).</summary>
        public static List<StoreList> GetVisibleStores(DataContext dc)
        {
            int prjId = Session.SelectedProjectId ?? 0;
            var stores = (prjId > 0 && !Session.IsSingleProjectUser)
                ? dc.StoreList.GetBy("(PrjId = @PrjId OR PrjId IS NULL) AND IsDelete = 0", new { PrjId = prjId })
                : dc.StoreList.GetBy("IsDelete = 0");

            var granted = InventoryStorePermissions.GrantedStoreIds(dc, a => a.PermsStatus);
            return stores.Where(s => granted.Contains(s.Id)).ToList();
        }

        /// <summary>Nets a batch of header rows' matching detail rows into a (StoreId,ItemId) → qty
        /// dictionary. Shared plumbing behind every table pulled into <see cref="ComputeBalancesForStores"/>
        /// and <see cref="GetStockMovementForPeriod"/> — each caller supplies its own header→store map and
        /// detail (ParentId, ItemId, Qty) projection since the concrete entity types differ per table.</summary>
        private static Dictionary<(int StoreId, int ItemId), decimal> AccumulateByStoreItem(
            Dictionary<int, int> headerStoreById, IEnumerable<(int? ParentId, int? ItemId, decimal? Qty)> detailRows)
        {
            var result = new Dictionary<(int, int), decimal>();
            foreach (var (parentId, itemId, qty) in detailRows)
            {
                if (parentId is not > 0 || itemId is not > 0) continue;
                if (!headerStoreById.TryGetValue(parentId.Value, out var storeId)) continue;
                var key = (storeId, itemId.Value);
                result[key] = result.GetValueOrDefault(key) + (qty ?? 0);
            }
            return result;
        }

        /// <summary>Generalized, multi-store replacement for looping <see cref="StoreBalanceHelper.ComputeBalances"/>
        /// per store — one batched query pair (headers + details) per movement table regardless of how many
        /// stores are requested. asOfDate = null → balance right now; asOfDate = a date → balance as of the end
        /// of that day (used by <see cref="GetStockMovementForPeriod"/> for "opening balance" = the day before
        /// the period starts).</summary>
        public static Dictionary<(int StoreId, int ItemId), decimal> ComputeBalancesForStores(
            DataContext dc, List<int> storeIds, DateTime? asOfDate = null)
        {
            var balances = new Dictionary<(int, int), decimal>();
            if (storeIds.Count == 0) return balances;

            string ids = string.Join(",", storeIds);
            // Header dates now carry a real time-of-day (see DateTimeHelper.WithCurrentTime), so "as of this day"
            // must mean up to the END of asOfDate, not asOfDate's own midnight instant, or same-day entries saved
            // later than 00:00:00 would be wrongly excluded from the balance.
            object? asOf = asOfDate.HasValue ? new { asOf = asOfDate.Value.Date.AddDays(1).AddTicks(-1) } : null;

            void Merge(Dictionary<(int, int), decimal> part, int sign)
            {
                foreach (var kv in part)
                    balances[kv.Key] = balances.GetValueOrDefault(kv.Key) + sign * kv.Value;
            }

            // Opening balance (+)
            var openingHeaders = dc.OpeningBalanceList.GetBy(
                asOfDate.HasValue ? $"IsDelete = 0 AND StoreId IN ({ids}) AND BalanceDate <= @asOf" : $"IsDelete = 0 AND StoreId IN ({ids})", asOf);
            var openingStoreById = openingHeaders.ToDictionary(h => h.Id, h => h.StoreId ?? 0);
            var openingDetails = openingHeaders.Count > 0
                ? dc.OpeningBalanceDetails.GetBy($"ParentId IN ({string.Join(",", openingHeaders.Select(h => h.Id))}) AND IsDelete = 0")
                : new List<OpeningBalanceDetails>();
            Merge(AccumulateByStoreItem(openingStoreById, openingDetails.Select(d => (d.ParentId, d.ItemId, d.Qty))), +1);

            // Receive (+)
            var receiveHeaders = dc.MaterialReceiveList.GetBy(
                asOfDate.HasValue ? $"IsDelete = 0 AND StoreId IN ({ids}) AND ReceivedDate <= @asOf" : $"IsDelete = 0 AND StoreId IN ({ids})", asOf);
            var receiveStoreById = receiveHeaders.ToDictionary(h => h.Id, h => h.StoreId ?? 0);
            var receiveDetails = receiveHeaders.Count > 0
                ? dc.MaterialReceiveDetails.GetBy($"ParentId IN ({string.Join(",", receiveHeaders.Select(h => h.Id))}) AND IsDelete = 0")
                : new List<MaterialReceiveDetails>();
            Merge(AccumulateByStoreItem(receiveStoreById, receiveDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty))), +1);

            // Issued (-)
            var issuedHeaders = dc.MaterialIssuedList.GetBy(
                asOfDate.HasValue ? $"IsDelete = 0 AND StoreId IN ({ids}) AND IssuedDate <= @asOf" : $"IsDelete = 0 AND StoreId IN ({ids})", asOf);
            var issuedStoreById = issuedHeaders.ToDictionary(h => h.Id, h => h.StoreId ?? 0);
            var issuedDetails = issuedHeaders.Count > 0
                ? dc.MaterialIssuedDetails.GetBy($"ParentId IN ({string.Join(",", issuedHeaders.Select(h => h.Id))}) AND IsDelete = 0")
                : new List<MaterialIssuedDetails>();
            Merge(AccumulateByStoreItem(issuedStoreById, issuedDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty))), -1);

            // Transfer in (+)
            var transferInHeaders = dc.MaterialTransferList.GetBy(
                asOfDate.HasValue ? $"IsDelete = 0 AND ToStoreId IN ({ids}) AND TransferDate <= @asOf" : $"IsDelete = 0 AND ToStoreId IN ({ids})", asOf);
            var transferInStoreById = transferInHeaders.ToDictionary(h => h.Id, h => h.ToStoreId ?? 0);
            var transferInDetails = transferInHeaders.Count > 0
                ? dc.MaterialTransferDetails.GetBy($"ParentId IN ({string.Join(",", transferInHeaders.Select(h => h.Id))}) AND IsDelete = 0")
                : new List<MaterialTransferDetails>();
            Merge(AccumulateByStoreItem(transferInStoreById, transferInDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty))), +1);

            // Transfer out (-)
            var transferOutHeaders = dc.MaterialTransferList.GetBy(
                asOfDate.HasValue ? $"IsDelete = 0 AND FromStoreId IN ({ids}) AND TransferDate <= @asOf" : $"IsDelete = 0 AND FromStoreId IN ({ids})", asOf);
            var transferOutStoreById = transferOutHeaders.ToDictionary(h => h.Id, h => h.FromStoreId ?? 0);
            var transferOutDetails = transferOutHeaders.Count > 0
                ? dc.MaterialTransferDetails.GetBy($"ParentId IN ({string.Join(",", transferOutHeaders.Select(h => h.Id))}) AND IsDelete = 0")
                : new List<MaterialTransferDetails>();
            Merge(AccumulateByStoreItem(transferOutStoreById, transferOutDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty))), -1);

            // Purchase return (-)
            var purReturnHeaders = dc.PurchaseReturnList.GetBy(
                asOfDate.HasValue ? $"IsDelete = 0 AND StoreId IN ({ids}) AND ReturnDate <= @asOf" : $"IsDelete = 0 AND StoreId IN ({ids})", asOf);
            var purReturnStoreById = purReturnHeaders.ToDictionary(h => h.Id, h => h.StoreId ?? 0);
            var purReturnDetails = purReturnHeaders.Count > 0
                ? dc.PurchaseReturnDetails.GetBy($"ParentId IN ({string.Join(",", purReturnHeaders.Select(h => h.Id))}) AND IsDelete = 0")
                : new List<PurchaseReturnDetails>();
            Merge(AccumulateByStoreItem(purReturnStoreById, purReturnDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty))), -1);

            // Issue return (+)
            var issueReturnHeaders = dc.MaterialIssueReturnList.GetBy(
                asOfDate.HasValue ? $"IsDelete = 0 AND StoreId IN ({ids}) AND ReturnDate <= @asOf" : $"IsDelete = 0 AND StoreId IN ({ids})", asOf);
            var issueReturnStoreById = issueReturnHeaders.ToDictionary(h => h.Id, h => h.StoreId ?? 0);
            var issueReturnDetails = issueReturnHeaders.Count > 0
                ? dc.MaterialIssueReturnDetails.GetBy($"ParentId IN ({string.Join(",", issueReturnHeaders.Select(h => h.Id))}) AND IsDelete = 0")
                : new List<MaterialIssueReturnDetails>();
            Merge(AccumulateByStoreItem(issueReturnStoreById, issueReturnDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty))), +1);

            return balances;
        }

        /// <summary>تقرير "رصيد المخزون الحالي" — كل الأصناف (مصفّاة اختيارياً بتصنيف/صنف) × كل مخزن مطلوب،
        /// مع الرصيد الصافي الآن.</summary>
        public static List<StockBalanceRow> GetCurrentStockBalance(
            DataContext dc, List<int> storeIds, int? categoryId = null, int? itemId = null)
        {
            if (storeIds.Count == 0) return new List<StockBalanceRow>();

            var balances = ComputeBalancesForStores(dc, storeIds);

            string itemsFilter = "IsDelete = 0";
            if (categoryId is > 0) itemsFilter += $" AND CategoryId = {categoryId.Value}";
            if (itemId is > 0) itemsFilter += $" AND Id = {itemId.Value}";
            var items = dc.ItemsList.GetBy(itemsFilter);

            var categories = dc.ItemCategory.GetBy("IsDelete = 0").ToDictionary(c => c.Id);
            var units = dc.Units.GetBy("IsDelete = 0").ToDictionary(u => u.Id);
            var stores = dc.StoreList.GetBy("IsDelete = 0").ToDictionary(s => s.Id);

            var rows = new List<StockBalanceRow>();
            foreach (var item in items)
            {
                var category = item.CategoryId is > 0 ? categories.GetValueOrDefault(item.CategoryId.Value) : null;
                var unit = item.UnitId is > 0 ? units.GetValueOrDefault(item.UnitId.Value) : null;

                foreach (var storeId in storeIds)
                {
                    rows.Add(new StockBalanceRow
                    {
                        ItemId = item.Id,
                        ItemCode = item.Code,
                        ItemName = item.Name,
                        CategoryId = item.CategoryId,
                        CategoryName = category?.Name,
                        UnitId = item.UnitId,
                        UnitAbbr = unit?.Abbreviation,
                        StoreId = storeId,
                        StoreName = stores.GetValueOrDefault(storeId)?.Name,
                        Balance = balances.GetValueOrDefault((storeId, item.Id))
                    });
                }
            }

            return rows.OrderBy(r => r.ItemCode).ThenBy(r => r.StoreName).ToList();
        }

        /// <summary>تقرير "كارت الصنف" — كل حركة لصنف ومخزن محددين مرتبة زمنياً مع رصيد جارٍ، بدءاً من الرصيد
        /// الافتتاحي إن وُجد.</summary>
        public static List<ItemStockCardRow> GetItemStockCard(DataContext dc, int itemId, int storeId)
        {
            var stores = dc.StoreList.GetBy("IsDelete = 0").ToDictionary(s => s.Id);
            var rows = new List<ItemStockCardRow>();

            foreach (var h in dc.OpeningBalanceList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }))
                foreach (var d in dc.OpeningBalanceDetails.GetBy("ParentId = @p AND IsDelete = 0 AND ItemId = @i", new { p = h.Id, i = itemId }))
                    rows.Add(new ItemStockCardRow { MovementDate = h.BalanceDate, MovementType = "رصيد افتتاحي", DocumentId = h.Id, DocumentNum = h.Num?.ToString(), QtyIn = d.Qty ?? 0, QtyOut = 0, Note = d.Note });

            foreach (var h in dc.MaterialReceiveList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }))
                foreach (var d in dc.MaterialReceiveDetails.GetBy("ParentId = @p AND IsDelete = 0 AND ItemId = @i", new { p = h.Id, i = itemId }))
                    rows.Add(new ItemStockCardRow { MovementDate = h.ReceivedDate, MovementType = "إذن استلام", DocumentId = h.Id, DocumentNum = MaterialReceivePrinter.FormatReceiveNumber(h.Num, h.ReceivedDate), QtyIn = d.Qty ?? 0, QtyOut = 0, Note = d.Note });

            foreach (var h in dc.MaterialIssuedList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }))
                foreach (var d in dc.MaterialIssuedDetails.GetBy("ParentId = @p AND IsDelete = 0 AND ItemId = @i", new { p = h.Id, i = itemId }))
                    rows.Add(new ItemStockCardRow { MovementDate = h.IssuedDate, MovementType = "إذن صرف", DocumentId = h.Id, DocumentNum = MaterialIssuedPrinter.FormatIssuedNumber(h.Num, h.IssuedDate), QtyIn = 0, QtyOut = d.Qty ?? 0, Note = d.Note });

            foreach (var h in dc.MaterialTransferList.GetBy("IsDelete = 0 AND ToStoreId = @s", new { s = storeId }))
                foreach (var d in dc.MaterialTransferDetails.GetBy("ParentId = @p AND IsDelete = 0 AND ItemId = @i", new { p = h.Id, i = itemId }))
                    rows.Add(new ItemStockCardRow { MovementDate = h.TransferDate, MovementType = "تحويل وارد", DocumentId = h.Id, DocumentNum = MaterialTransferPrinter.FormatTransferNumber(h.Num, h.TransferDate), CounterpartyStoreName = stores.GetValueOrDefault(h.FromStoreId ?? 0)?.Name, QtyIn = d.Qty ?? 0, QtyOut = 0, Note = d.Note });

            foreach (var h in dc.MaterialTransferList.GetBy("IsDelete = 0 AND FromStoreId = @s", new { s = storeId }))
                foreach (var d in dc.MaterialTransferDetails.GetBy("ParentId = @p AND IsDelete = 0 AND ItemId = @i", new { p = h.Id, i = itemId }))
                    rows.Add(new ItemStockCardRow { MovementDate = h.TransferDate, MovementType = "تحويل صادر", DocumentId = h.Id, DocumentNum = MaterialTransferPrinter.FormatTransferNumber(h.Num, h.TransferDate), CounterpartyStoreName = stores.GetValueOrDefault(h.ToStoreId ?? 0)?.Name, QtyIn = 0, QtyOut = d.Qty ?? 0, Note = d.Note });

            foreach (var h in dc.MaterialIssueReturnList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }))
                foreach (var d in dc.MaterialIssueReturnDetails.GetBy("ParentId = @p AND IsDelete = 0 AND ItemId = @i", new { p = h.Id, i = itemId }))
                    rows.Add(new ItemStockCardRow { MovementDate = h.ReturnDate, MovementType = "مرتجع صرف", DocumentId = h.Id, DocumentNum = MaterialIssueReturnPrinter.FormatReturnNumber(h.Num, h.ReturnDate), QtyIn = d.Qty ?? 0, QtyOut = 0, Note = d.Note });

            foreach (var h in dc.PurchaseReturnList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }))
                foreach (var d in dc.PurchaseReturnDetails.GetBy("ParentId = @p AND IsDelete = 0 AND ItemId = @i", new { p = h.Id, i = itemId }))
                    rows.Add(new ItemStockCardRow { MovementDate = h.ReturnDate, MovementType = "مرتجع مشتريات", DocumentId = h.Id, DocumentNum = PurchaseReturnPrinter.FormatReturnNumber(h.Code, h.ReturnDate), QtyIn = 0, QtyOut = d.Qty ?? 0, Note = d.Note });

            rows = rows.OrderBy(r => r.MovementDate).ThenBy(r => r.DocumentId).ToList();

            decimal running = 0;
            foreach (var r in rows)
            {
                running += r.QtyIn - r.QtyOut;
                r.RunningBalance = running;
            }

            return rows;
        }

        private static bool HasActivity(StockMovementPeriodRow r) =>
            r.OpeningQty != 0 || r.ReceivedQty != 0 || r.IssuedQty != 0 || r.TransferInQty != 0 ||
            r.TransferOutQty != 0 || r.PurchaseReturnQty != 0 || r.IssueReturnQty != 0 || r.ClosingQty != 0;

        /// <summary>تقرير "حركة المخزون خلال فترة" — رصيد أول المدة (كما في نهاية اليوم السابق للفترة) +
        /// إجمالي كل نوع حركة داخل الفترة + رصيد آخر المدة، لكل صنف (مجمَّعاً عبر كل المخازن المطلوبة، أو
        /// مفصَّلاً لكل مخزن على حدة عند perStore=true).</summary>
        public static List<StockMovementPeriodRow> GetStockMovementForPeriod(
            DataContext dc, DateTime fromDate, DateTime toDate, List<int> storeIds,
            int? itemId = null, int? categoryId = null, bool perStore = false,
            bool hideNoActivity = true)
        {
            if (storeIds.Count == 0) return new List<StockMovementPeriodRow>();

            string ids = string.Join(",", storeIds);
            string itemFilter = itemId is > 0 ? $" AND ItemId = {itemId.Value}" : "";
            var dateParams = new { from = fromDate.Date, to = toDate.Date.AddDays(1).AddTicks(-1) };

            var opening = ComputeBalancesForStores(dc, storeIds, asOfDate: fromDate.Date.AddDays(-1));

            var receiveHeaders = dc.MaterialReceiveList.GetBy($"IsDelete = 0 AND StoreId IN ({ids}) AND ReceivedDate BETWEEN @from AND @to", dateParams);
            var receiveStoreById = receiveHeaders.ToDictionary(h => h.Id, h => h.StoreId ?? 0);
            var receiveDetails = receiveHeaders.Count > 0
                ? dc.MaterialReceiveDetails.GetBy($"ParentId IN ({string.Join(",", receiveHeaders.Select(h => h.Id))}) AND IsDelete = 0{itemFilter}")
                : new List<MaterialReceiveDetails>();
            var received = AccumulateByStoreItem(receiveStoreById, receiveDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty)));

            var issuedHeaders = dc.MaterialIssuedList.GetBy($"IsDelete = 0 AND StoreId IN ({ids}) AND IssuedDate BETWEEN @from AND @to", dateParams);
            var issuedStoreById = issuedHeaders.ToDictionary(h => h.Id, h => h.StoreId ?? 0);
            var issuedDetails = issuedHeaders.Count > 0
                ? dc.MaterialIssuedDetails.GetBy($"ParentId IN ({string.Join(",", issuedHeaders.Select(h => h.Id))}) AND IsDelete = 0{itemFilter}")
                : new List<MaterialIssuedDetails>();
            var issued = AccumulateByStoreItem(issuedStoreById, issuedDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty)));

            var transferInHeaders = dc.MaterialTransferList.GetBy($"IsDelete = 0 AND ToStoreId IN ({ids}) AND TransferDate BETWEEN @from AND @to", dateParams);
            var transferInStoreById = transferInHeaders.ToDictionary(h => h.Id, h => h.ToStoreId ?? 0);
            var transferInDetails = transferInHeaders.Count > 0
                ? dc.MaterialTransferDetails.GetBy($"ParentId IN ({string.Join(",", transferInHeaders.Select(h => h.Id))}) AND IsDelete = 0{itemFilter}")
                : new List<MaterialTransferDetails>();
            var transferIn = AccumulateByStoreItem(transferInStoreById, transferInDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty)));

            var transferOutHeaders = dc.MaterialTransferList.GetBy($"IsDelete = 0 AND FromStoreId IN ({ids}) AND TransferDate BETWEEN @from AND @to", dateParams);
            var transferOutStoreById = transferOutHeaders.ToDictionary(h => h.Id, h => h.FromStoreId ?? 0);
            var transferOutDetails = transferOutHeaders.Count > 0
                ? dc.MaterialTransferDetails.GetBy($"ParentId IN ({string.Join(",", transferOutHeaders.Select(h => h.Id))}) AND IsDelete = 0{itemFilter}")
                : new List<MaterialTransferDetails>();
            var transferOut = AccumulateByStoreItem(transferOutStoreById, transferOutDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty)));

            var purReturnHeaders = dc.PurchaseReturnList.GetBy($"IsDelete = 0 AND StoreId IN ({ids}) AND ReturnDate BETWEEN @from AND @to", dateParams);
            var purReturnStoreById = purReturnHeaders.ToDictionary(h => h.Id, h => h.StoreId ?? 0);
            var purReturnDetails = purReturnHeaders.Count > 0
                ? dc.PurchaseReturnDetails.GetBy($"ParentId IN ({string.Join(",", purReturnHeaders.Select(h => h.Id))}) AND IsDelete = 0{itemFilter}")
                : new List<PurchaseReturnDetails>();
            var purchaseReturn = AccumulateByStoreItem(purReturnStoreById, purReturnDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty)));

            var issueReturnHeaders = dc.MaterialIssueReturnList.GetBy($"IsDelete = 0 AND StoreId IN ({ids}) AND ReturnDate BETWEEN @from AND @to", dateParams);
            var issueReturnStoreById = issueReturnHeaders.ToDictionary(h => h.Id, h => h.StoreId ?? 0);
            var issueReturnDetails = issueReturnHeaders.Count > 0
                ? dc.MaterialIssueReturnDetails.GetBy($"ParentId IN ({string.Join(",", issueReturnHeaders.Select(h => h.Id))}) AND IsDelete = 0{itemFilter}")
                : new List<MaterialIssueReturnDetails>();
            var issueReturn = AccumulateByStoreItem(issueReturnStoreById, issueReturnDetails.Select(d => ((int?)d.ParentId, d.ItemId, d.Qty)));

            var keys = new HashSet<(int StoreId, int ItemId)>();
            foreach (var d in new[] { opening, received, issued, transferIn, transferOut, purchaseReturn, issueReturn })
                foreach (var k in d.Keys) keys.Add(k);

            string itemsFilter = "IsDelete = 0";
            if (categoryId is > 0) itemsFilter += $" AND CategoryId = {categoryId.Value}";
            if (itemId is > 0) itemsFilter += $" AND Id = {itemId.Value}";
            var items = dc.ItemsList.GetBy(itemsFilter).ToDictionary(i => i.Id);
            var units = dc.Units.GetBy("IsDelete = 0").ToDictionary(u => u.Id);
            var stores = dc.StoreList.GetBy("IsDelete = 0").ToDictionary(s => s.Id);

            StockMovementPeriodRow MakeRow(int rowItemId, int? rowStoreId)
            {
                decimal Get(Dictionary<(int, int), decimal> d) => rowStoreId.HasValue
                    ? d.GetValueOrDefault((rowStoreId.Value, rowItemId))
                    : storeIds.Sum(sid => d.GetValueOrDefault((sid, rowItemId)));

                var item = items[rowItemId];
                var row = new StockMovementPeriodRow
                {
                    ItemId = rowItemId,
                    ItemCode = item.Code,
                    ItemName = item.Name,
                    UnitAbbr = item.UnitId is > 0 ? units.GetValueOrDefault(item.UnitId.Value)?.Abbreviation : null,
                    StoreId = rowStoreId,
                    StoreName = rowStoreId.HasValue ? stores.GetValueOrDefault(rowStoreId.Value)?.Name : null,
                    OpeningQty = Get(opening),
                    ReceivedQty = Get(received),
                    IssuedQty = Get(issued),
                    TransferInQty = Get(transferIn),
                    TransferOutQty = Get(transferOut),
                    PurchaseReturnQty = Get(purchaseReturn),
                    IssueReturnQty = Get(issueReturn)
                };
                row.ClosingQty = row.OpeningQty + row.ReceivedQty + row.TransferInQty + row.IssueReturnQty
                    - row.IssuedQty - row.TransferOutQty - row.PurchaseReturnQty;
                return row;
            }

            var rows = new List<StockMovementPeriodRow>();
            if (perStore)
            {
                foreach (var key in keys)
                {
                    if (!items.ContainsKey(key.ItemId)) continue;
                    var row = MakeRow(key.ItemId, key.StoreId);
                    if (!hideNoActivity || HasActivity(row)) rows.Add(row);
                }
            }
            else
            {
                foreach (var iid in keys.Select(k => k.ItemId).Distinct())
                {
                    if (!items.ContainsKey(iid)) continue;
                    var row = MakeRow(iid, null);
                    if (!hideNoActivity || HasActivity(row)) rows.Add(row);
                }
            }

            return rows.OrderBy(r => r.ItemCode).ThenBy(r => r.StoreName).ToList();
        }

        /// <summary>تقرير "الجرد وفروقاته" — بنود جرد فعلي (StockingDetails) مصفّاة بمخزن/فترة، مع حقول عرض
        /// مُعبَّأة وإعادة حساب Difference/DifferenceValue (نفس صيغة frmStockingAddEdit.RecalculateRow، التي
        /// خاصة بذلك النموذج ولا يمكن استدعاؤها من هنا مباشرة).</summary>
        public static List<StockingDetails> GetStockingVariance(
            DataContext dc, List<int> storeIds, int? storeIdFilter = null,
            DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (storeIds.Count == 0) return new List<StockingDetails>();
            if (storeIdFilter is > 0 && !storeIds.Contains(storeIdFilter.Value)) return new List<StockingDetails>();

            var effectiveStoreIds = storeIdFilter is > 0 ? new List<int> { storeIdFilter.Value } : storeIds;
            string ids = string.Join(",", effectiveStoreIds);

            string filter = $"IsDelete = 0 AND StoreId IN ({ids})";
            object? parameters = null;
            if (fromDate.HasValue && toDate.HasValue)
            {
                filter += " AND StockingDate BETWEEN @from AND @to";
                parameters = new { from = fromDate.Value.Date, to = toDate.Value.Date.AddDays(1).AddTicks(-1) };
            }
            else if (fromDate.HasValue)
            {
                filter += " AND StockingDate >= @from";
                parameters = new { from = fromDate.Value.Date };
            }
            else if (toDate.HasValue)
            {
                filter += " AND StockingDate <= @to";
                parameters = new { to = toDate.Value.Date.AddDays(1).AddTicks(-1) };
            }

            var headers = dc.StockingList.GetBy(filter, parameters);
            if (headers.Count == 0) return new List<StockingDetails>();

            var headerById = headers.ToDictionary(h => h.Id);
            var details = dc.StockingDetails.GetBy($"ParentId IN ({string.Join(",", headers.Select(h => h.Id))}) AND IsDelete = 0");

            var stores = dc.StoreList.GetBy("IsDelete = 0").ToDictionary(s => s.Id);
            var items = dc.ItemsList.GetBy("IsDelete = 0").ToDictionary(i => i.Id);
            var units = dc.Units.GetBy("IsDelete = 0").ToDictionary(u => u.Id);

            foreach (var d in details)
            {
                var header = headerById.GetValueOrDefault(d.ParentId);
                d.StockingNum = header?.Num?.ToString();
                d.StockingDate = header?.StockingDate;
                d.StoreName = header?.StoreId is > 0 ? stores.GetValueOrDefault(header.StoreId.Value)?.Name : null;

                var item = d.ItemId is > 0 ? items.GetValueOrDefault(d.ItemId.Value) : null;
                d.ItemCode = item?.Code;
                d.ItemName = item?.Name;
                d.UnitAbbr = d.UnitId is > 0 ? units.GetValueOrDefault(d.UnitId.Value)?.Abbreviation : null;

                d.Difference = (d.Qty ?? 0) - (d.SystemQty ?? 0);
                d.DifferenceValue = d.Difference * (d.UnitPrice ?? 0);
            }

            return details.OrderByDescending(d => d.StockingDate).ThenBy(d => d.StoreName).ThenBy(d => d.ItemName).ToList();
        }
    }
}
