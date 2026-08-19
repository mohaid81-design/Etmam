using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Etmam
{
    public partial class frmItemSelect : XtraForm
    {
        protected DataContext dc => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<ItemsList> SelectedItems { get; private set; } = new List<ItemsList>();

        // يُقيَّد الاختيار على تصنيف واحد فقط عند الحاجة (اختياري — لا يوجد مستدعٍ حالياً يستخدمه)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int? CategoryId { get; set; }

        // يُقيَّد الاختيار على جذر تصنيف واحد من الجذور الخمسة الثابتة (M/C/S/E/R — انظر
        // ItemCategory.IsFixed) بدل تصنيف فرعي واحد بعينه كما في CategoryId أعلاه — تستخدمه
        // frmPurchaseRequestAddEdit لتقييد قائمة الأصناف حسب "نوع طلب الشراء" المختار في الترويسة.
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string? RootCategoryCode { get; set; }

        // عند تحديدها، يُقيَّد الاختيار على أصناف لها رصيد لا يساوي صفراً في هذا المخزن فقط، ويُعرض
        // عمود "الرصيد" — تستخدمه frmMaterialIssuedAddEdit كي لا يُصرف صنف غير موجود أصلاً بالمخزن
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int? StoreId { get; set; }

        // أصناف تُستبعَد من القائمة المعروضة (مثلاً الأصناف الموجودة أصلاً بجدول التفاصيل في المستند
        // المفتوح) لمنع إضافتها مكررة — تستخدمه frmMaterialIssuedAddEdit
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public HashSet<int>? ExcludeItemIds { get; set; }

        private List<ItemsList> _allItems = new();
        private Dictionary<int, ItemCategory> _categoriesById = new();
        private Dictionary<int, string> _unitAbbrById = new();
        private Dictionary<int, decimal> _balanceByItemId = new();

        public frmItemSelect()
        {
            InitializeComponent();
            //DesignSystem.ApplyCairoFont(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupTree();
            LoadData();
        }

        private void SetupTree()
        {
            treeList1.OptionsBehavior.Editable = false;
            treeList1.OptionsBehavior.AllowRecursiveNodeChecking = false;
            treeList1.OptionsView.ShowCheckBoxes = true;
            treeList1.KeyFieldName = "NodeKey";
            treeList1.ParentFieldName = "ParentKey";

            if (StoreId is > 0)
            {
                colBalance.Visible = true;
                var storeName = dc.StoreList.Find(StoreId.Value)?.Name;
                Text = $"اختيار الأصناف — أرصدة مخزن: {storeName}";
            }

            treeList1.BeforeCheckNode += TreeList1_BeforeCheckNode;
            treeList1.NodeCellStyle += TreeList1_NodeCellStyle;
            treeList1.DoubleClick += (s, e) => ConfirmSelection();

            bbiSelect.ItemClick += (s, e) => ConfirmSelection();
            bbiRefresh.ItemClick += (s, e) => LoadData();
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        // يمنع تحديد/تفعيل صناديق الاختيار على صفوف التصنيف (الأصناف فقط قابلة للاختيار)
        private void TreeList1_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (treeList1.GetDataRecordByNode(e.Node) is ItemPickerNode { IsCategory: true })
                e.CanCheck = false;
        }

        private void TreeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (treeList1.GetDataRecordByNode(e.Node) is ItemPickerNode { IsCategory: true })
            {
                e.Appearance.Font = DesignSystem.Fonts.Bold(8.5f);
                e.Appearance.BackColor = System.Drawing.Color.FromArgb(235, 240, 248);
                e.Appearance.ForeColor = System.Drawing.Color.FromArgb(30, 70, 130);
            }
        }

        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var categories = dc.ItemCategory.GetBy("IsDelete = 0");
                _categoriesById = categories.ToDictionary(c => c.Id);
                _unitAbbrById = dc.Units.GetBy("IsDelete = 0").ToDictionary(u => u.Id, u => u.Abbreviation ?? "");

                _allItems = dc.ItemsList.GetBy("IsDelete = 0").ToList();
                if (CategoryId is > 0)
                    _allItems = _allItems.Where(i => i.CategoryId == CategoryId).ToList();

                if (!string.IsNullOrEmpty(RootCategoryCode))
                    _allItems = _allItems.Where(i =>
                        i.CategoryId is > 0 &&
                        _categoriesById.TryGetValue(i.CategoryId.Value, out var cat) &&
                        !string.IsNullOrEmpty(cat.Code) &&
                        cat.Code[..1] == RootCategoryCode).ToList();

                if (ExcludeItemIds is { Count: > 0 })
                    _allItems = _allItems.Where(i => !ExcludeItemIds.Contains(i.Id)).ToList();

                if (StoreId is > 0)
                {
                    _balanceByItemId = StoreBalanceHelper.ComputeBalances(dc, StoreId.Value);
                    _allItems = _allItems.Where(i => _balanceByItemId.GetValueOrDefault(i.Id) > 0).ToList();
                }

                BuildTree(_allItems, categories);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الأصناف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void ApplyFilter(string? term)
        {
            term = term?.Trim();
            var items = string.IsNullOrEmpty(term)
                ? _allItems
                : _allItems.Where(i =>
                    (i.Code?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (i.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            BuildTree(items, _categoriesById.Values);
            if (!string.IsNullOrEmpty(term))
                treeList1.ExpandAll();
        }

        private void BuildTree(List<ItemsList> items, IEnumerable<ItemCategory> allCategories)
        {
            // نضيف فقط التصنيفات المرتبطة بأصناف ظاهرة (بعد الفلترة)، مع سلسلة آبائها كاملة،
            // لتفادي أغصان تصنيف فارغة دون فقدان شكل الشجرة الهرمي
            var neededCategoryIds = new HashSet<int>();
            foreach (var item in items)
            {
                var catId = item.CategoryId;
                while (catId is > 0 && neededCategoryIds.Add(catId.Value))
                    catId = _categoriesById.TryGetValue(catId.Value, out var cat) ? cat.ParentId : null;
            }

            var nodes = new List<ItemPickerNode>();

            foreach (var cat in allCategories.Where(c => neededCategoryIds.Contains(c.Id)))
            {
                nodes.Add(new ItemPickerNode
                {
                    NodeKey = "C" + cat.Id,
                    ParentKey = cat.ParentId is > 0 ? "C" + cat.ParentId : null,
                    IsCategory = true,
                    Name = cat.Name,
                    // يُملأ هنا أيضاً (وليس فقط لصفوف الأصناف) حتى يرتّب colCode.SortOrder التصنيفات
                    // المتجاورة حسب رمزها الهرمي (M, M01, M0101, ...) تماماً كما يرتّب الأصناف تحتها —
                    // عمود واحد يكفي لتحقيق "ترتيب حسب التصنيف ثم حسب رمز الصنف" لأن كودي التصنيف والصنف
                    // كلاهما يتبعان نفس مخطط الترقيم المتسلسل.
                    Code = cat.Code
                });
            }

            foreach (var item in items)
            {
                nodes.Add(new ItemPickerNode
                {
                    NodeKey = "I" + item.Id,
                    ParentKey = item.CategoryId is > 0 ? "C" + item.CategoryId : null,
                    IsCategory = false,
                    ItemId = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Unit = item.UnitId is > 0 && _unitAbbrById.TryGetValue(item.UnitId.Value, out var abbr) ? abbr : null,
                    Description = item.Description,
                    Balance = _balanceByItemId.GetValueOrDefault(item.Id)
                });
            }

            treeList1.DataSource = nodes;
            treeList1.ExpandAll();
            barStaticItem1.Caption = $"عدد الأصناف : {items.Count}";
        }

        private void ConfirmSelection()
        {
            var checkedItemIds = new List<int>();
            CollectChecked(treeList1.Nodes, checkedItemIds);

            // إن لم يُحدَّد أي صندوق اختيار، اعتبر الصف الذي تم الضغط عليه (المُركَّز) هو الاختيار
            // (يدعم النقر المزدوج المباشر على صنف دون المرور بصندوق الاختيار)
            if (checkedItemIds.Count == 0 &&
                treeList1.GetDataRecordByNode(treeList1.FocusedNode) is ItemPickerNode { IsCategory: false } focused)
            {
                checkedItemIds.Add(focused.ItemId!.Value);
            }

            if (checkedItemIds.Count == 0)
            {
                XtraMessageBox.Show("يرجى اختيار صنف واحد على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedItems = checkedItemIds
                .Select(id => _allItems.FirstOrDefault(i => i.Id == id))
                .Where(i => i != null)
                .Select(i => i!)
                .ToList();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CollectChecked(TreeListNodes nodes, List<int> result)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.CheckState == CheckState.Checked &&
                    treeList1.GetDataRecordByNode(node) is ItemPickerNode { IsCategory: false } picked)
                {
                    result.Add(picked.ItemId!.Value);
                }
                CollectChecked(node.Nodes, result);
            }
        }

        // نموذج عرض موحّد لصفوف الشجرة: صفوف تصنيف (غير قابلة للاختيار) وصفوف أصناف (قابلة للاختيار)
        public class ItemPickerNode
        {
            public string NodeKey { get; set; } = "";
            public string? ParentKey { get; set; }
            public bool IsCategory { get; set; }
            public int? ItemId { get; set; }
            public string? Code { get; set; }
            public string? Name { get; set; }
            public string? Unit { get; set; }
            public string? Description { get; set; }
            public decimal? Balance { get; set; }
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
