using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using Core;
using Data;

namespace Etmam
{
    public partial class frmItemCategoryAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private BindingList<ItemCategory> _data = new BindingList<ItemCategory>();
        private int _focusId;
        private bool _changed;

        public frmItemCategoryAddEdit(int id = 0)
        {
            InitializeComponent();
            _focusId = id;

            //DesignSystem.ApplyCairoFont(this);
            //DesignSystem.ApplyTreeListStyle(treeList1);
            //DesignSystem.HideTreeListAuditColumns(treeList1);

            bbiNew.ItemClick += BbiNew_ItemClick;
            bbiEdit.ItemClick += (s, e) => EditFocusedNode();
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiRefresh.ItemClick += (s, e) => LoadData();
            bbiPrint.ItemClick += BbiPrint_ItemClick;

            btnMoveUp.ItemClick += (s, e) => MoveSibling(-1);
            btnMoveDown.ItemClick += (s, e) => MoveSibling(1);
            btnMoveRight.ItemClick += (s, e) => Indent();
            btnMoveLeft.ItemClick += (s, e) => Outdent();

            treeList1.DoubleClick += (s, e) => EditFocusedNode();

            FormClosing += (s, e) => DialogResult = _changed ? DialogResult.OK : DialogResult.Cancel;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = dc.ItemCategory.GetBy("IsDelete = 0");
                _data = new BindingList<ItemCategory>(list);
                itemCategoryBindingSource.DataSource = _data;

                treeList1.ExpandAll();
                treeList1.BestFitColumns();
                UpdateRecordCount();

                if (_focusId > 0)
                {
                    var node = treeList1.FindNodeByKeyID(_focusId);
                    if (node != null)
                    {
                        treeList1.FocusedNode = node;
                        node.Expanded = true;
                    }
                    _focusId = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل تصنيفات الأصناف:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRecordCount()
        {
            barStaticItem1.Caption = $"عدد السجلات: {_data.Count(c => !c.IsDelete)}";
        }

        private ItemCategory? GetFocusedCategory()
        {
            var node = treeList1.FocusedNode;
            if (node == null) return null;
            return treeList1.GetRow(node.Id) as ItemCategory;
        }

        // ─── توليد الرمز الشجري ─────────────────────────────────────────────
        // المستوى الأول: 01 | الثاني: 001-01 | الثالث: 01-001-01 | الرابع فأعمق: 01-001-01-01...
        private static string BuildCode(int level, int seq, string? parentCode)
        {
            switch (level)
            {
                case 1: return seq.ToString("00");
                default: return parentCode + seq.ToString("00");
            }
        }

        /// <summary>
        /// يعيد بناء الترتيب (SortId) والمستوى (LvlId) والرمز (Code) لكل عناصر الشجرة
        /// بناءً على ترتيب كل عنصر بين إخوته، ثم يحفظ النتيجة في قاعدة البيانات.
        /// </summary>
        private void RecalculateAndSave()
        {
            var byParent = _data.Where(c => !c.IsDelete)
                                 .GroupBy(c => c.ParentId ?? 0)
                                 .ToDictionary(g => g.Key, g => g.OrderBy(c => c.SortId ?? c.Id).ToList());

            void Walk(int parentKey, int level, string? parentCode)
            {
                if (!byParent.TryGetValue(parentKey, out var siblings)) return;

                int seq = 1;
                foreach (var node in siblings)
                {
                    node.SortId = seq;
                    node.LvlId = level;
                    node.Code = BuildCode(level, seq, parentCode);
                    Walk(node.Id, level + 1, node.Code);
                    seq++;
                }
            }

            Walk(0, 1, null);

            foreach (var node in _data.Where(c => !c.IsDelete))
                dc.ItemCategory.Edit(node.Id, node);

            treeList1.RefreshDataSource();
            UpdateRecordCount();
        }

        // ─── أزرار الشريط ───────────────────────────────────────────────────
        private void BbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var focused = GetFocusedCategory();
            int? parentId = null;

            if (focused != null)
            {
                var addAsChild = XtraMessageBox.Show(
                    $"هل تريد إضافة التصنيف الجديد كبند فرعي ضمن \"{focused.Name}\"؟\nاختر (لا) لإضافته كبند رئيسي مستقل.",
                    "إضافة تصنيف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

                if (addAsChild) parentId = focused.Id;
            }

            var name = XtraInputBox.Show("اسم التصنيف:", "تصنيف جديد", "");
            if (string.IsNullOrWhiteSpace(name)) return;

            var entity = new ItemCategory
            {
                Name = name.Trim(),
                ParentId = parentId,
                SortId = int.MaxValue,
                CreatedDate = DateTime.Now,
                CreatedMachine = Session.Machine,
                CreatedBy = Session.CurrentUser?.Id ?? 1
            };

            try
            {
                var newId = dc.ItemCategory.Add(entity);
                entity.Id = newId;
                _data.Add(entity);

                RecalculateAndSave();
                _changed = true;

                RefocusNode(newId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الإضافة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditFocusedNode()
        {
            var focused = GetFocusedCategory();
            if (focused == null)
            {
                XtraMessageBox.Show("يرجى تحديد تصنيف لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var name = XtraInputBox.Show("اسم التصنيف:", "تعديل تصنيف", focused.Name ?? "");
            if (string.IsNullOrWhiteSpace(name)) return;

            try
            {
                focused.Name = name.Trim();
                focused.UpdateDate = DateTime.Now;
                focused.UpdateMachine = Session.Machine;
                focused.UpdateBy = Session.CurrentUser?.Id ?? 1;

                dc.ItemCategory.Edit(focused.Id, focused);
                treeList1.RefreshDataSource();
                _changed = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التعديل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var focused = GetFocusedCategory();
            if (focused == null)
            {
                XtraMessageBox.Show("يرجى تحديد تصنيف لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا التصنيف وكافة عناصره الفرعية؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                var toDelete = CollectWithDescendants(focused.Id);
                foreach (var item in toDelete)
                {
                    item.IsDelete = true;
                    item.DeletionDate = DateTime.Now;
                    item.DeletionMachine = Session.Machine;
                    item.DeletionBy = Session.CurrentUser?.Id ?? 1;
                    dc.ItemCategory.Edit(item.Id, item);
                    _data.Remove(item);
                }

                RecalculateAndSave();
                _changed = true;
                XtraMessageBox.Show("تم الحذف بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ItemCategory> CollectWithDescendants(int id)
        {
            var result = new List<ItemCategory>();
            void Collect(int nodeId)
            {
                var node = _data.FirstOrDefault(c => c.Id == nodeId);
                if (node == null) return;
                result.Add(node);
                foreach (var child in _data.Where(c => c.ParentId == nodeId).ToList())
                    Collect(child.Id);
            }
            Collect(id);
            return result;
        }

        private void BbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                treeList1.ShowPrintPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── إعادة الترتيب وتغيير المستوى (الأب) ────────────────────────────
        private void MoveSibling(int direction)
        {
            var focused = GetFocusedCategory();
            if (focused == null) return;

            var siblings = _data.Where(c => !c.IsDelete && c.ParentId == focused.ParentId)
                                 .OrderBy(c => c.SortId ?? c.Id)
                                 .ToList();

            var index = siblings.IndexOf(focused);
            var swapIndex = index + direction;
            if (index < 0 || swapIndex < 0 || swapIndex >= siblings.Count) return;

            var other = siblings[swapIndex];
            (focused.SortId, other.SortId) = (other.SortId, focused.SortId);

            RecalculateAndSave();
            _changed = true;
            RefocusNode(focused.Id);
        }

        private void Indent()
        {
            var focused = GetFocusedCategory();
            if (focused == null) return;

            var siblings = _data.Where(c => !c.IsDelete && c.ParentId == focused.ParentId)
                                 .OrderBy(c => c.SortId ?? c.Id)
                                 .ToList();

            var index = siblings.IndexOf(focused);
            if (index <= 0) return; // لا يوجد شقيق سابق ليصبح أباً جديداً

            var newParent = siblings[index - 1];
            focused.ParentId = newParent.Id;
            focused.SortId = int.MaxValue;

            RecalculateAndSave();
            _changed = true;
            RefocusNode(focused.Id, expandParent: true);
        }

        private void Outdent()
        {
            var focused = GetFocusedCategory();
            if (focused == null || focused.ParentId == null) return; // في المستوى الجذري أصلاً

            var parent = _data.FirstOrDefault(c => c.Id == focused.ParentId);
            if (parent == null) return;

            focused.ParentId = parent.ParentId;
            focused.SortId = (parent.SortId ?? 0) + 1;

            RecalculateAndSave();
            _changed = true;
            RefocusNode(focused.Id);
        }

        private void RefocusNode(int id, bool expandParent = false)
        {
            var node = treeList1.FindNodeByKeyID(id);
            if (node == null) return;

            treeList1.FocusedNode = node;
            if (expandParent && node.ParentNode != null)
                node.ParentNode.Expanded = true;
        }
    }
}
