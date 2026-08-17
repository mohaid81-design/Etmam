using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using Data;
using Core;

namespace Etmam
{
    /// <summary>
    /// A generic base class for any TreeList-based user control, handling professional styling and standard patterns.
    /// </summary>
    /// <typeparam name="T">The entity type for the tree.</typeparam>
    public abstract class BaseTreeListUserControl<T> : BaseUserControl where T : class, IBaseEntity, new()
    {
        protected BindingList<T> DataSource { get; set; } = new BindingList<T>();

        // ─── UI References (Must be implemented by subclasses) ────────────────
        protected abstract TreeList MainTree { get; }
        protected virtual BarStaticItem? StatusItem => null;

        /// <summary>
        /// Applies centralized design and hooks standard events.
        /// </summary>
        protected virtual void InitializeBaseTree()
        {
            if (MainTree == null) return;

            DesignSystem.ApplyTreeListStyle(MainTree);
            DesignSystem.HideTreeListAuditColumns(MainTree);
            
            MainTree.DataSource = DataSource;
            
            // Default hierarchical settings
            MainTree.KeyFieldName = "Id";
            MainTree.ParentFieldName = "IdParent";

            // Auto-track changes and record count
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            
            UpdateRecordCount();
        }

        protected virtual void UpdateRecordCount()
        {
            if (StatusItem != null)
                StatusItem.Caption = $"عدد السجلات : {MainTree.AllNodesCount}";
        }

        public virtual void ConfirmAndDeleteFocusedNode()
        {
            var node = MainTree.FocusedNode;
            if (node == null) return;

            var row = MainTree.GetRow(node.Id) as T;
            if (row == null) return;

            if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل (وكافة العناصر الفرعية إن وجدت)؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MainTree.DeleteNode(node);
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        /// <summary>
        /// Global shortcut handler for the tree.
        /// </summary>
        protected virtual void StandardTreeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                ConfirmAndDeleteFocusedNode();
                e.Handled = true;
            }
        }
    }
}
