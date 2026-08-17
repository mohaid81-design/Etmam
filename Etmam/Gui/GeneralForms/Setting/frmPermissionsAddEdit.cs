using System.ComponentModel;
using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    /// <summary>
    /// إدارة شجرة الصلاحيات (PermissionsList): إضافة/تعديل/حذف وعرضها هرمياً، مع إمكانية
    /// إعادة الترتيب وتغيير المستوى (تحويل بند إلى فرعي/رئيسي).
    /// </summary>
    public partial class frmPermissionsAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private BindingList<PermissionsList> _data = new BindingList<PermissionsList>();
        private int _focusId;
        private bool _changed;

        public frmPermissionsAddEdit(int id = 0)
        {
            InitializeComponent();
            _focusId = id;

            bbiNew.ItemClick += (s, e) => AddPermission();
            bbiEdit.ItemClick += (s, e) => EditFocusedPermission();
            bbiDelete.ItemClick += (s, e) => DeleteFocusedPermission();
            bbiRefresh.ItemClick += (s, e) => LoadData();
            bbiPrint.ItemClick += (s, e) => PrintTree();

            btnMoveUp.ItemClick += (s, e) => MoveSibling(-1);
            btnMoveDown.ItemClick += (s, e) => MoveSibling(1);
            btnMoveRight.ItemClick += (s, e) => Indent();
            btnMoveLeft.ItemClick += (s, e) => Outdent();

            treeList1.DoubleClick += (s, e) => EditFocusedPermission();

            FormClosing += (s, e) => DialogResult = _changed ? DialogResult.OK : DialogResult.Cancel;

            LoadData();
        }

        // ─── تحميل البيانات ─────────────────────────────────────────────────
        private void LoadData()
        {
            try
            {
                var list = dc.PermissionsList.GetAll();
                _data = new BindingList<PermissionsList>(list);
                permissionsListBindingSource.DataSource = _data;

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
                XtraMessageBox.Show($"خطأ أثناء تحميل الصلاحيات:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRecordCount()
        {
            barStaticItem1.Caption = $"عدد السجلات: {_data.Count}";
        }

        private PermissionsList? GetFocusedPermission()
        {
            var node = treeList1.FocusedNode;
            if (node == null) return null;
            return treeList1.GetRow(node.Id) as PermissionsList;
        }

        // ─── أزرار الشريط ───────────────────────────────────────────────────
        private void AddPermission()
        {
            var focused = GetFocusedPermission();
            int? parentId = null;

            if (focused != null)
            {
                var addAsChild = XtraMessageBox.Show(
                    $"هل تريد إضافة الصلاحية الجديدة كبند فرعي ضمن \"{focused.Name}\"؟\nاختر (لا) لإضافتها كبند رئيسي مستقل.",
                    "إضافة صلاحية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

                if (addAsChild) parentId = focused.Id;
            }

            var name = XtraInputBox.Show("اسم الصلاحية:", "صلاحية جديدة", "");
            if (string.IsNullOrWhiteSpace(name)) return;

            var entity = new PermissionsList
            {
                Name = name.Trim(),
                ParentID = parentId,
                SortID = int.MaxValue,
            };

            try
            {
                var newId = dc.PermissionsList.Add(entity);
                entity.Id = newId;
                _data.Add(entity);

                PersistOrder();
                _changed = true;
                RefocusNode(newId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الإضافة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditFocusedPermission()
        {
            var focused = GetFocusedPermission();
            if (focused == null)
            {
                XtraMessageBox.Show("يرجى تحديد صلاحية لتعديلها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var name = XtraInputBox.Show("اسم الصلاحية:", "تعديل صلاحية", focused.Name ?? "");
            if (string.IsNullOrWhiteSpace(name)) return;

            focused.Name = name.Trim();

            try
            {
                dc.PermissionsList.Edit(focused.Id, focused);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التعديل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            treeList1.RefreshDataSource();
            _changed = true;
        }

        private void DeleteFocusedPermission()
        {
            var focused = GetFocusedPermission();
            if (focused == null)
            {
                XtraMessageBox.Show("يرجى تحديد صلاحية لحذفها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من حذف هذه الصلاحية وكافة الصلاحيات الفرعية التابعة لها؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                // نحذف من الأبناء إلى الآباء حتى لا يبقى بند فرعي يتيماً في حال فشل جزئي.
                var toDelete = CollectWithDescendants(focused.Id);
                toDelete.Reverse();

                foreach (var item in toDelete)
                {
                    dc.PermissionsList.Delete(item.Id);
                    _data.Remove(item);
                }

                _changed = true;
                XtraMessageBox.Show("تم الحذف بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<PermissionsList> CollectWithDescendants(int id)
        {
            var result = new List<PermissionsList>();
            void Collect(int nodeId)
            {
                var node = _data.FirstOrDefault(c => c.Id == nodeId);
                if (node == null) return;
                result.Add(node);
                foreach (var child in _data.Where(c => c.ParentID == nodeId).ToList())
                    Collect(child.Id);
            }
            Collect(id);
            return result;
        }

        private void PrintTree()
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
            var focused = GetFocusedPermission();
            if (focused == null) return;

            var siblings = _data.Where(c => c.ParentID == focused.ParentID)
                                 .OrderBy(c => c.SortID ?? c.Id)
                                 .ToList();

            var index = siblings.IndexOf(focused);
            var swapIndex = index + direction;
            if (index < 0 || swapIndex < 0 || swapIndex >= siblings.Count) return;

            var other = siblings[swapIndex];
            (focused.SortID, other.SortID) = (other.SortID, focused.SortID);

            PersistOrder();
            _changed = true;
            RefocusNode(focused.Id);
        }

        private void Indent()
        {
            var focused = GetFocusedPermission();
            if (focused == null) return;

            var siblings = _data.Where(c => c.ParentID == focused.ParentID)
                                 .OrderBy(c => c.SortID ?? c.Id)
                                 .ToList();

            var index = siblings.IndexOf(focused);
            if (index <= 0) return; // لا يوجد شقيق سابق ليصبح أباً جديداً

            var newParent = siblings[index - 1];
            focused.ParentID = newParent.Id;
            focused.SortID = int.MaxValue;

            PersistOrder();
            _changed = true;
            RefocusNode(focused.Id, expandParent: true);
        }

        private void Outdent()
        {
            var focused = GetFocusedPermission();
            if (focused == null || focused.ParentID == null) return; // في المستوى الجذري أصلاً

            var parent = _data.FirstOrDefault(c => c.Id == focused.ParentID);
            if (parent == null) return;

            focused.ParentID = parent.ParentID;
            focused.SortID = (parent.SortID ?? 0) + 1; // يوضع مباشرة بعد أبيه السابق ضمن إخوته الجدد

            PersistOrder();
            _changed = true;
            RefocusNode(focused.Id);
        }

        /// <summary>
        /// يعيد ترقيم SortID تسلسلياً (1، 2، 3...) ضمن كل مجموعة إخوة بناءً على ترتيبها الحالي،
        /// ثم يحفظ كل السجلات في قاعدة البيانات ويحدّث الشجرة. يُستدعى بعد أي عملية تُغيّر
        /// الأب أو الترتيب حتى لا تتراكم قيم غير متسقة (مثل int.MaxValue أو تعارض بين الإخوة).
        /// </summary>
        private void PersistOrder()
        {
            var byParent = _data.GroupBy(c => c.ParentID ?? 0)
                                 .ToDictionary(g => g.Key, g => g.OrderBy(c => c.SortID ?? c.Id).ToList());

            void Renumber(int parentKey)
            {
                if (!byParent.TryGetValue(parentKey, out var siblings)) return;

                var seq = 1;
                foreach (var node in siblings)
                {
                    node.SortID = seq++;
                    Renumber(node.Id);
                }
            }
            Renumber(0);

            try
            {
                foreach (var node in _data)
                    dc.PermissionsList.Edit(node.Id, node);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء حفظ الترتيب: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            treeList1.RefreshDataSource();
            UpdateRecordCount();
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
