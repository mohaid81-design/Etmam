using System.Collections.Generic;
using System.Linq;
using Data;

namespace Etmam
{
    /// <summary>Computes each item's real quantity balance within a single store, netting every inventory
    /// movement that touches it. Shared by <see cref="frmItemSelect"/> (filters/labels the picker tree with
    /// per-store balances), <see cref="frmMaterialIssuedAddEdit"/>/<c>frmMaterialTransferAddEdit</c> (show the
    /// balance in the grid and block moving more than what's available), and
    /// <c>Etmam.Gui.InventoryMgt.Stocking.frmStockingAddEdit</c> (shows the book balance next to the physically
    /// counted quantity, with no over-limit check since a stock count is a reconciliation, not a movement) —
    /// previously each had its own copy of this exact calculation, which is the kind of thing that quietly
    /// drifts apart when only one copy gets a fix. <c>frmOpeningBalanceAddEdit</c> is the one document type that
    /// feeds this calculation as an "in" movement without being a receive/transfer/return — see ComputeBalances.</summary>
    public static class StoreBalanceHelper
    {
        /// <summary>Balance = OpeningBalance in + Receive in + Transfer in + IssueReturn in − Issued out − Transfer out − PurchaseReturn out.</summary>
        public static Dictionary<int, decimal> ComputeBalances(DataContext dc, int storeId)
        {
            var balances = new Dictionary<int, decimal>();
            void Add(int? itemId, decimal qty)
            {
                if (itemId is not > 0) return;
                balances[itemId.Value] = balances.GetValueOrDefault(itemId.Value) + qty;
            }

            var openingIds = dc.OpeningBalanceList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }).Select(r => r.Id).ToList();
            if (openingIds.Count > 0)
                foreach (var d in dc.OpeningBalanceDetails.GetBy($"ParentId IN ({string.Join(",", openingIds)}) AND IsDelete = 0"))
                    Add(d.ItemId, d.Qty ?? 0);

            var receiveIds = dc.MaterialReceiveList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }).Select(r => r.Id).ToList();
            if (receiveIds.Count > 0)
                foreach (var d in dc.MaterialReceiveDetails.GetBy($"ParentId IN ({string.Join(",", receiveIds)}) AND IsDelete = 0"))
                    Add(d.ItemId, d.Qty ?? 0);

            var issueIds = dc.MaterialIssuedList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }).Select(r => r.Id).ToList();
            if (issueIds.Count > 0)
                foreach (var d in dc.MaterialIssuedDetails.GetBy($"ParentId IN ({string.Join(",", issueIds)}) AND IsDelete = 0"))
                    Add(d.ItemId, -(d.Qty ?? 0));

            var transferInIds = dc.MaterialTransferList.GetBy("IsDelete = 0 AND ToStoreId = @s", new { s = storeId }).Select(r => r.Id).ToList();
            if (transferInIds.Count > 0)
                foreach (var d in dc.MaterialTransferDetails.GetBy($"ParentId IN ({string.Join(",", transferInIds)}) AND IsDelete = 0"))
                    Add(d.ItemId, d.Qty ?? 0);

            var transferOutIds = dc.MaterialTransferList.GetBy("IsDelete = 0 AND FromStoreId = @s", new { s = storeId }).Select(r => r.Id).ToList();
            if (transferOutIds.Count > 0)
                foreach (var d in dc.MaterialTransferDetails.GetBy($"ParentId IN ({string.Join(",", transferOutIds)}) AND IsDelete = 0"))
                    Add(d.ItemId, -(d.Qty ?? 0));

            var purReturnIds = dc.PurchaseReturnList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }).Select(r => r.Id).ToList();
            if (purReturnIds.Count > 0)
                foreach (var d in dc.PurchaseReturnDetails.GetBy($"ParentId IN ({string.Join(",", purReturnIds)}) AND IsDelete = 0"))
                    Add(d.ItemId, -(d.Qty ?? 0));

            var issueReturnIds = dc.MaterialIssueReturnList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }).Select(r => r.Id).ToList();
            if (issueReturnIds.Count > 0)
                foreach (var d in dc.MaterialIssueReturnDetails.GetBy($"ParentId IN ({string.Join(",", issueReturnIds)}) AND IsDelete = 0"))
                    Add(d.ItemId, d.Qty ?? 0);

            return balances;
        }

        /// <summary>Net quantity of each item issued out of a store that hasn't been returned back to it yet
        /// (Issued out − IssueReturn in). Used by <see cref="frmMaterialIssueReturnAddEdit"/> to cap how much
        /// of an item can be returned — the mirror-image check of <see cref="ComputeBalances"/> preventing
        /// over-issuing: here it prevents "returning" more than was ever actually taken out.</summary>
        public static Dictionary<int, decimal> ComputeIssuedNotReturnedBalances(DataContext dc, int storeId)
        {
            var balances = new Dictionary<int, decimal>();
            void Add(int? itemId, decimal qty)
            {
                if (itemId is not > 0) return;
                balances[itemId.Value] = balances.GetValueOrDefault(itemId.Value) + qty;
            }

            var issueIds = dc.MaterialIssuedList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }).Select(r => r.Id).ToList();
            if (issueIds.Count > 0)
                foreach (var d in dc.MaterialIssuedDetails.GetBy($"ParentId IN ({string.Join(",", issueIds)}) AND IsDelete = 0"))
                    Add(d.ItemId, d.Qty ?? 0);

            var issueReturnIds = dc.MaterialIssueReturnList.GetBy("IsDelete = 0 AND StoreId = @s", new { s = storeId }).Select(r => r.Id).ToList();
            if (issueReturnIds.Count > 0)
                foreach (var d in dc.MaterialIssueReturnDetails.GetBy($"ParentId IN ({string.Join(",", issueReturnIds)}) AND IsDelete = 0"))
                    Add(d.ItemId, -(d.Qty ?? 0));

            return balances;
        }
    }
}
