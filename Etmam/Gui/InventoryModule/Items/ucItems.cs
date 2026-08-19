using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Core;
using Data;

namespace Etmam
{
    public partial class ucItems : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _canManage;

        // ذاكرة مؤقتة للأصناف/التصنيفات الكاملة (قبل أي تصفية بالبحث) لإعادة بناء الشجرة دون إعادة
        // استعلام قاعدة البيانات في كل مرة يكتب فيها المستخدم حرفاً في مربع البحث
        private List<ItemsList> _allItems = new();
        private List<ItemCategory> _allCategories = new();
        private Dictionary<int, ItemsList> _itemsById = new();

        // لون مختلف لكل مستوى تصنيف (حسب عمق العقدة Node.Level) — يتكرر آخر لون لأي مستوى أعمق مما هو
        // معرَّف هنا. مستوى الصنف نفسه (IsCategory=false) يبقى بلا لون مطلقاً، انظر TreeList1_NodeCellStyle.
        private static readonly Color[] _categoryLevelColors =
        {
            SystemColors.GrayText,
            Color.FromArgb(165, 165, 165),
            Color.FromArgb(225, 225, 225),
            SystemColors.InactiveCaption,
        };

        public ucItems()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = PermissionService.HasPermission(PermNames.Items);
            bbiNew.Enabled = _canManage;
            btnOpen.Enabled = _canManage;
            bbiEdit.Enabled = _canManage;
            bbiDelete.Enabled = _canManage;
            bbiPrint.Enabled = _canManage;

            DesignSystem.ApplyCairoFont(this);
            DesignSystem.ApplyTreeListStyle(treeList1);

            // إبقاء صف التصنيف بمظهر مميز (وليس قابلاً للتركيز/التحديد كصنف) عبر NodeCellStyle
            treeList1.NodeCellStyle += TreeList1_NodeCellStyle;

            this.Load += (s, e) => LoadData();

            // Wire Toolbar Events
            bbiNew.ItemClick += bbiNew_ItemClick;
            btnOpen.ItemClick += btnOpen_ItemClick;
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            bbiExpandCollapse.ItemClick += bbiExpandCollapse_ItemClick;

            // مربع البحث بالشريط لا يُستخدم كـ SearchControl.Client تلقائي (TreeList الهرمي لا يتعامل جيداً
            // مع التصفية الجاهزة عبر Client) — بل تُطبَّق التصفية يدوياً هنا (انظر ApplyFilter)، بنفس نمط
            // frmItemSelect.
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());

            // يُعاد تقييم قابلية الفتح/التعديل/الحذف لكل عقدة عند تركيزها — بلا عقدة مركَّزة (أو عقدة
            // تصنيف)، أو صنف مستخدم في مستندات محفوظة (يُمنع حذفه دوماً بصرف النظر عن الصلاحية، انظر
            // ItemStoreLock).
            treeList1.FocusedNodeChanged += (s, e) => UpdateButtonStates();

            // Double click node to edit (باستثناء عقدة التصنيف)
            treeList1.DoubleClick += (s, e) =>
            {
                var row = GetFocusedItem();
                if (row != null)
                {
                    OpenAddEdit(row.Id);
                }
            };
        }

        // يُحدِّث تفعيل أزرار فتح/تعديل/حذف حسب العقدة المركَّزة حالياً (يُعامل عقدة التصنيف كأنه لا يوجد
        // صنف مركَّز). الحذف يُعطَّل أيضاً إذا كان الصنف مستخدماً فعلاً في مستند محفوظ حتى ولو توفرت الصلاحية.
        private void UpdateButtonStates()
        {
            var row = GetFocusedItem();

            btnOpen.Enabled = _canManage && row != null;
            bbiEdit.Enabled = _canManage && row != null;

            bool canDelete = _canManage && row != null
                && (PermissionService.IsSuperUser || !ItemStoreLock.IsItemUsed(Data.DataContext.Shared, row.Id));
            bbiDelete.Enabled = canDelete;
        }

        // فتح للعرض فقط (بلا حفظ) — بخلاف bbiEdit الذي يفتح للتعديل الكامل.
        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = GetFocusedItem();
            if (row == null)
            {
                if (GetFocusedNode()?.IsCategory != true)
                    XtraMessageBox.Show("يرجى تحديد صنف لفتحه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmItemAddEdit frm;
            try { frm = new frmItemAddEdit(row.Id, readOnly: true); }
            finally { CloseOverlay(handle); }
            using (frm) frm.ShowDialog(this.FindForm());
        }

        // لون مختلف لكل مستوى تصنيف (أغمق للمستويات الرئيسية، أفتح كلما نزلنا للتصنيفات الفرعية) — عقد
        // الأصناف الفعلية (IsCategory=false) تبقى بلا أي تلوين، بمظهر الشجرة الافتراضي.
        private void TreeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (treeList1.GetDataRecordByNode(e.Node) is not ItemTreeNode { IsCategory: true }) return;

            var color = _categoryLevelColors[Math.Min(e.Node.Level, _categoryLevelColors.Length - 1)];
            e.Appearance.BackColor = color;
            e.Appearance.ForeColor = color.R > 150 ? Color.Black : Color.White; // يبقى النص مقروءاً على الرمادي الفاتح بالمستويات العميقة
            e.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
        }

        // يُعيد عقدة الشجرة المُركَّز عليها حالياً (نموذج العرض الموحَّد)، أو null إن لم توجد عقدة مركَّزة
        private ItemTreeNode? GetFocusedNode()
        {
            if (treeList1.FocusedNode == null) return null;
            return treeList1.GetDataRecordByNode(treeList1.FocusedNode) as ItemTreeNode;
        }

        // يُعيد الصنف الفعلي المُركَّز عليه، أو null إن كان التركيز على عقدة تصنيف (أو بلا تركيز إطلاقاً)
        private ItemsList? GetFocusedItem()
        {
            var node = GetFocusedNode();
            if (node == null || node.IsCategory || node.ItemId is not > 0) return null;
            return _itemsById.TryGetValue(node.ItemId.Value, out var item) ? item : null;
        }

        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var dc = Data.DataContext.Shared;

                // Load Lookups
                var categories = dc.ItemCategory.GetBy("IsDelete = 0").ToList();
                lookUpUnit.DataSource = dc.Units.GetBy("IsDelete = 0").ToList();

                var categoriesById = categories.ToDictionary(c => c.Id);

                var items = dc.ItemsList.GetBy("IsDelete = 0").ToList();

                // أعمدة حصر الكميات (المشتريات/الصرف/التحويلات/المرتجعات وآخر سعر شراء) أُزيلت من هذه
                // الشاشة عمداً — كانت تتطلب استعلام كل حركات المخزون (استلام/صرف/تحويل/مرتجعات شراء
                // ومرتجعات صرف) وتجميعها لكل الأصناف في كل فتح للشاشة، وهو ما جعل فتحها بطيئاً. من احتاج
                // هذه الأرقام فمكانها تقرير/شاشة حصر مخزون منفصلة، لا شاشة إدارة الأصناف الأساسية.
                int index = 1;
                foreach (var item in items)
                {
                    item.IdSort = index++;
                    item.CategoryCode = categoriesById.TryGetValue(item.CategoryId ?? 0, out var cat) ? cat.Code : null;
                }

                _allItems = items;
                _allCategories = categories;
                _itemsById = items.ToDictionary(i => i.Id);

                BuildTree(items, categories, pruneEmptyCategories: false);
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل الأصناف:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // يبني شجرة موحَّدة (عقد تصنيف + عقد أصناف) من ItemCategory (هرمية كاملة متعددة المستويات عبر
        // ParentId) والأصناف كأوراق تحت تصنيفها المباشر. عند التصفية بالبحث (pruneEmptyCategories) تُستبعد
        // التصنيفات التي لم يعد لها أي صنف ظاهر، مع الإبقاء على كامل سلسلة آباء كل تصنيف مطلوب حتى لا
        // ينكسر شكل الشجرة الهرمي — نفس نمط frmItemSelect.BuildTree.
        private void BuildTree(List<ItemsList> items, List<ItemCategory> categories, bool pruneEmptyCategories)
        {
            var categoriesById = categories.ToDictionary(c => c.Id);

            var neededCategoryIds = new HashSet<int>();
            if (pruneEmptyCategories)
            {
                foreach (var item in items)
                {
                    var catId = item.CategoryId;
                    while (catId is > 0 && neededCategoryIds.Add(catId.Value))
                        catId = categoriesById.TryGetValue(catId.Value, out var cat) ? cat.ParentId : null;
                }
            }

            var nodes = new List<ItemTreeNode>();

            foreach (var cat in categories.OrderBy(c => c.SortId ?? int.MaxValue).ThenBy(c => c.Code))
            {
                if (pruneEmptyCategories && !neededCategoryIds.Contains(cat.Id)) continue;

                nodes.Add(new ItemTreeNode
                {
                    NodeKey = "C" + cat.Id,
                    ParentNodeKey = cat.ParentId is > 0 ? "C" + cat.ParentId : null,
                    IsCategory = true,
                    Code = cat.Code,
                    Name = cat.Name
                });
            }

            bool hasUncategorized = items.Any(i => i.CategoryId is null or 0 || !categoriesById.ContainsKey(i.CategoryId.Value));
            if (hasUncategorized)
            {
                nodes.Add(new ItemTreeNode
                {
                    NodeKey = "C0",
                    ParentNodeKey = null,
                    IsCategory = true,
                    Code = null,
                    Name = "غير مصنف"
                });
            }

            foreach (var item in items.OrderBy(i => i.IdSort))
            {
                bool hasValidCategory = item.CategoryId is > 0 && categoriesById.ContainsKey(item.CategoryId.Value);

                nodes.Add(new ItemTreeNode
                {
                    NodeKey = "I" + item.Id,
                    ParentNodeKey = hasValidCategory ? "C" + item.CategoryId : "C0",
                    IsCategory = false,
                    ItemId = item.Id,
                    IdSort = item.IdSort,
                    Code = item.Code,
                    Name = item.Name,
                    UnitId = item.UnitId,
                    CategoryCode = item.CategoryCode,
                    Description = item.Description,
                    IsActive = item.IsActive
                });
            }

            treeList1.DataSource = nodes;
            treeList1.ExpandAll();
        }

        // يصفّي الشجرة حسب كود/اسم الصنف (مربع البحث بالشريط) — التصنيفات التي لم يتبقَّ تحتها أي صنف
        // مطابق تختفي مؤقتاً أثناء البحث، وتعود عند إفراغ مربع البحث (انظر BuildTree)
        private void ApplyFilter(string? term)
        {
            term = term?.Trim();
            var items = string.IsNullOrEmpty(term)
                ? _allItems
                : _allItems.Where(i =>
                    (i.Code?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (i.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            BuildTree(items, _allCategories, pruneEmptyCategories: !string.IsNullOrEmpty(term));
        }

        // نقطة الدخول الموحّدة (bbiNew/bbiEdit والنقر المزدوج) — الفحص هنا يمنع تجاوز الصلاحية عبر
        // النقر المزدوج الذي لا يمر بحالة تفعيل الأزرار.
        private void OpenAddEdit(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة الأصناف.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmItemAddEdit frm;
            try { frm = new frmItemAddEdit(id); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadData();
                    FocusItemNode(frm.SavedItemId);
                }
            }
        }

        // يُركِّز عقدة الصنف المضاف/المعدَّل حديثاً بعد إعادة تحميل الشجرة — BuildTree يُوسِّع كل العقد
        // مسبقاً (ExpandAll) فلا حاجة لتوسيع سلسلة الآباء يدوياً، بنفس نمط frmItemCategoryAddEdit.LoadData.
        private void FocusItemNode(int itemId)
        {
            if (itemId <= 0) return;

            var node = treeList1.FindNodeByKeyID("I" + itemId);
            if (node != null)
                treeList1.FocusedNode = node;
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
                if (GetFocusedNode()?.IsCategory != true)
                    XtraMessageBox.Show("يرجى تحديد صنف لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = GetFocusedItem();
            if (row == null)
            {
                if (GetFocusedNode()?.IsCategory != true)
                    XtraMessageBox.Show("يرجى تحديد صنف لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // نفس فحص ItemStoreLock المستخدم لتعطيل الزر أصلاً (انظر UpdateButtonStates) — يبقى هنا
            // كخط دفاع ثانٍ لا كمصدر وحيد للتحقق.
            if (!PermissionService.IsSuperUser && ItemStoreLock.IsItemUsed(Data.DataContext.Shared, row.Id))
            {
                XtraMessageBox.Show("لا يمكن حذف هذا الصنف لأنه مستخدم في مستندات محفوظة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا الصنف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
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
                finally
                {
                    CloseOverlay(handle);
                }
            }
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        public void OnProjectChanged()
        {
            LoadData();
        }

        // يبدّل بين توسيع كل عقد التصنيف وطيّها بالكامل حسب حالتها الحالية
        private void bbiExpandCollapse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HasCollapsedNode(treeList1.Nodes))
                treeList1.ExpandAll();
            else
                treeList1.CollapseAll();
        }

        private static bool HasCollapsedNode(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.HasChildren && !node.Expanded) return true;
                if (HasCollapsedNode(node.Nodes)) return true;
            }
            return false;
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        // نموذج عرض موحّد لصفوف الشجرة: عقد تصنيف (Code/Name فقط) وعقد أصناف (بيانات الهوية فقط، بلا
        // أعمدة حصر كميات) — نفس نمط frmItemSelect.ItemPickerNode
        public class ItemTreeNode
        {
            public string NodeKey { get; set; } = "";
            public string? ParentNodeKey { get; set; }
            public bool IsCategory { get; set; }
            public int? ItemId { get; set; }
            public int IdSort { get; set; }
            public string? Code { get; set; }
            public string? Name { get; set; }
            public int? UnitId { get; set; }
            public string? CategoryCode { get; set; }
            public string? Description { get; set; }
            public bool? IsActive { get; set; }
        }
    }
}
