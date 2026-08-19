using System.ComponentModel;
using System.Drawing;
using Core;
using Data;
using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;

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
            treeList1.NodeCellStyle += TreeList1_NodeCellStyle;

            FormClosing += (s, e) => DialogResult = _changed ? DialogResult.OK : DialogResult.Cancel;

            Load += (s, e) => LoadData();
        }

        // ─── تحميل البيانات ─────────────────────────────────────────────────
        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var list = dc.PermissionsList.GetAll();
                _data = new BindingList<PermissionsList>(list);
                permissionsListBindingSource.DataSource = _data;

                treeList1.ExpandAll();
                //treeList1.BestFitColumns();
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
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void UpdateRecordCount()
        {
            barStaticItem1.Caption = $"عدد السجلات: {_data.Count}";
        }

        // ─── تلوين الصفوف حسب المستوى (المستوى الأخير بلا لون/أبيض) ─────────
        private static readonly Color[] _levelColors =
        {
            Color.FromArgb(203, 222, 245), // المستوى الأول
            Color.FromArgb(223, 235, 250), // المستوى الثاني
            Color.FromArgb(238, 245, 253), // المستوى الثالث فأعمق
        };

        private void TreeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            //if (e.Node.HasChildren)
            //{
            //    e.Appearance.BackColor = _levelColors[Math.Min(e.Node.Level, _levelColors.Length - 1)];
            //    e.Appearance.Font = DesignSystem.Fonts.Bold(9F);
            //    e.Appearance.Options.UseBackColor = true;
            //    e.Appearance.Options.UseFont = true;
            //}
            //else
            //{
            //    e.Appearance.BackColor = Color.White;
            //    e.Appearance.Options.UseBackColor = true;
            //}


            if (e.Node.Level == 0)
            {
                e.Appearance.BackColor = SystemColors.GrayText;
                e.Appearance.ForeColor = Color.Wheat;
                e.Appearance.Font = DesignSystem.Fonts.Bold(9F);
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.Options.UseFont = true;
            }
            else if (e.Node.Level == 1)
            {
                e.Appearance.BackColor = Color.FromArgb(223, 235, 250);
                e.Appearance.Font = DesignSystem.Fonts.Bold(8F);
                e.Appearance.ForeColor= Color.Black;
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.Options.UseFont = true;

            }
            else
            {
                e.Appearance.BackColor = Color.White;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Options.UseBackColor = true;
            }

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

            var handle = ShowOverlay();
            try
            {
                var newId = dc.PermissionsList.Add(entity);
                entity.Id = newId;
                _data.Add(entity);

                PersistOrder(new[] { entity });
                _changed = true;
                RefocusNode(newId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الإضافة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
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

            var handle = ShowOverlay();
            try
            {
                dc.PermissionsList.Edit(focused.Id, focused);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التعديل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                CloseOverlay(handle);
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

            var handle = ShowOverlay();
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
            finally
            {
                CloseOverlay(handle);
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

            PersistOrder(new[] { focused, other });
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

            PersistOrder(new[] { focused });
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

            PersistOrder(new[] { focused });
            _changed = true;
            RefocusNode(focused.Id);
        }

        /// <summary>
        /// يعيد ترقيم SortID تسلسلياً (1، 2، 3...) ضمن كل مجموعة إخوة بناءً على ترتيبها الحالي،
        /// ثم يحفظ في قاعدة البيانات العقد المتأثرة فقط (وليس شجرة الصلاحيات كاملة، فقد تضم
        /// مئات البنود — حفظها جميعاً عند كل نقلة كان يجعل الضغط على أزرار النقل/الإزاحة بطيئاً
        /// جداً بسبب فتح اتصال SQL منفصل لكل بند) ثم يحدّث الشجرة.
        /// </summary>
        private void PersistOrder(IEnumerable<PermissionsList>? touched = null)
        {
            var byParent = _data.GroupBy(c => c.ParentID ?? 0)
                                 .ToDictionary(g => g.Key, g => g.OrderBy(c => c.SortID ?? c.Id).ToList());

            var changed = new HashSet<PermissionsList>(touched ?? Enumerable.Empty<PermissionsList>());

            void Renumber(int parentKey)
            {
                if (!byParent.TryGetValue(parentKey, out var siblings)) return;

                var seq = 1;
                foreach (var node in siblings)
                {
                    if (node.SortID != seq)
                    {
                        node.SortID = seq;
                        changed.Add(node);
                    }
                    seq++;
                    Renumber(node.Id);
                }
            }
            Renumber(0);

            var handle = ShowOverlay();
            try
            {
                foreach (var node in changed)
                    dc.PermissionsList.Edit(node.Id, node);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء حفظ الترتيب: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
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

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
