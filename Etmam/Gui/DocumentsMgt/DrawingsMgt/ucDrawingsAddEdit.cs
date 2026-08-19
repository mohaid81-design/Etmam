using System.ComponentModel;
using System.Linq;
using Core;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>
    /// Line-items grid inside a drawing approval request (frmDrawingsAddEdit): a single
    /// submission may bundle several physical drawing sheets, each with its own independent
    /// consultant review decision.
    /// </summary>
    public partial class ucDrawingsAddEdit : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly BindingList<DrawingsRegisterDetails> _items = new();

        public ucDrawingsAddEdit()
        {
            InitializeComponent();
            if (DesignMode) return;

            gridControl.DataSource = _items;
            bbiAdd.ItemClick += (s, e) => _items.Add(new DrawingsRegisterDetails());
            bbiDelete.ItemClick += (s, e) =>
            {
                if (gridView.GetFocusedRow() is DrawingsRegisterDetails row)
                    _items.Remove(row);
            };
        }

        /// <summary>Loads the line items belonging to the given drawing approval request.</summary>
        public void LoadForDrawing(int parentId)
        {
            _items.Clear();
            if (parentId <= 0) return;

            var rows = Data.DataContext.Shared.DrawingsRegisterDetails
                .GetBy("ParentId = @id", new { id = parentId });
            foreach (var row in rows)
                _items.Add(row);
        }

        /// <summary>
        /// Persists the current line items for <paramref name="parentId"/> — replaces all
        /// existing rows for this parent with what's currently in the grid (same pattern as
        /// PriceQuotationCompareDetails: no per-row diffing needed for a simple detail grid).
        /// </summary>
        public void SaveData(int parentId, SqlTransaction? transaction = null)
        {
            var dc = Data.DataContext.Shared;
            dc.DrawingsRegisterDetails.DeleteBy("ParentId = @id", new { id = parentId }, transaction);

            foreach (var item in _items)
            {
                item.ParentId = parentId;
                dc.DrawingsRegisterDetails.Add(item, transaction);
            }
        }
    }
}
