using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
    public partial class ucItemsCategories : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private BindingList<ItemCategory> _data = new BindingList<ItemCategory>();
        private int _focusId;
        private bool _canManage;

        public ucItemsCategories()
        {
            InitializeComponent();
            if (DesignMode) return;

            // لا صلاحية شاشة مستقلة لتصنيفات الأصناف — تابعة لشاشة "الأصناف" نفسها فتشترك بصلاحيتها
            // (نفس نمط ucItems.cs). bbiNew/bbiPrint لا يعتمدان على عقدة مركَّزة فيُضبطان هنا مباشرة؛
            // بقية الأزرار (تعديل/حذف/نقل) تعتمد أيضاً على العقدة المركَّزة فتُدار من UpdateButtonStates
            // (انظر أدناه). في الحالتين يُعاد التحقق داخل كل دالة معدِّلة (BbiNew_ItemClick/
            // EditFocusedNode/BbiDelete_ItemClick/MoveSibling/Indent/Outdent) لأن treeList1.DoubleClick
            // يستدعي EditFocusedNode مباشرة بمسار منفصل لا يمر بحالة تفعيل bbiEdit.Enabled.
            _canManage = PermissionService.HasPermission(PermNames.Items);
            bbiNew.Enabled = _canManage;
            bbiPrint.Enabled = _canManage;

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

            // تدرج رمادي حسب مستوى العقدة، بنفس نمط ucItems.cs (كان معرَّفاً هنا أصلاً لكن غير مربوط
            // بالحدث فعلياً — الاسم الصحيح للحدث هو NodeCellStyle، وليس CustomNodeCellStyle كما قد يوحي
            // اسم نوع الـ EventArgs).
            treeList1.NodeCellStyle += TreeList1_NodeCellStyle;

            // يُحدِّث تفعيل أزرار التعديل/الحذف/النقل حسب العقدة المركَّزة (تُعطَّل كلها على تصنيف ثابت)
            // — بنفس نمط ucItems.cs.
            treeList1.FocusedNodeChanged += (s, e) => UpdateButtonStates();

            btnExpandCollapse.ItemClick += BtnExpandCollapse_ItemClick;

            // تحميل كسول: لا تُنفَّذ LoadData (وما تحتويه من كتابة DB عبر RecalculateAndSave) إلا عند
            // ظهور الشاشة فعلياً، لا فور إنشاء ucItemsMain — بنفس نمط ucItems.cs:55، بدل الاستدعاء
            // المباشر السابق هنا الذي كان يُنفَّذ حتى لو لم يفتح المستخدم تبويب "التصنيف" إطلاقاً.
            this.Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var list = dc.ItemCategory.GetBy("IsDelete = 0");
                _data = new BindingList<ItemCategory>(list);
                itemCategoryBindingSource.DataSource = _data;

                // تصحيح ذاتي عند كل فتح للشاشة: يعيد بناء Code/LvlId/SortId لكامل الشجرة (لا يحفظ في
                // قاعدة البيانات إلا ما تغيّر فعلياً — انظر RecalculateAndSave). هذا وحده كفيل بترحيل
                // أكواد التصنيفات القديمة إلى المخطط الجديد بالبادئة الحرفية (M/C/S/E/R) أول مرة تُفتح
                // فيها هذه الشاشة بعد الترقية، دون أي تدخل يدوي على قاعدة البيانات.
                RecalculateAndSave();

                treeList1.ExpandAll();
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

                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل تصنيفات الأصناف:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
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

        // يُحدِّث تفعيل أزرار التعديل/الحذف/النقل حسب العقدة المركَّزة حالياً — بنفس نمط
        // ucItems.cs.UpdateButtonStates. التصنيفات الثابتة الخمسة (IsFixed) تُعطَّل لها كل هذه الأزرار
        // استباقياً بدل الاعتماد فقط على رسائل الرفض داخل كل معالج (تبقى تلك الرسائل كخط دفاع ثانٍ ضد
        // مسارات لا تمر بحالة تفعيل الزر، كالنقر المزدوج). bbiNew/bbiPrint لا يعتمدان على عقدة مركَّزة
        // فليسا هنا.
        private void UpdateButtonStates()
        {
            var focused = GetFocusedCategory();
            bool hasFocus = focused != null;
            bool isFixed = focused?.IsFixed == true;

            bbiEdit.Enabled = _canManage && hasFocus && !isFixed;
            bbiDelete.Enabled = _canManage && hasFocus && !isFixed;
            btnMoveUp.Enabled = _canManage && hasFocus && !isFixed;
            btnMoveDown.Enabled = _canManage && hasFocus && !isFixed;
            btnMoveRight.Enabled = _canManage && hasFocus && !isFixed;
            btnMoveLeft.Enabled = _canManage && hasFocus && !isFixed && focused?.ParentId != null;
        }

        /// <summary>
        /// يعيد بناء الترتيب (SortId) والمستوى (LvlId) والرمز (Code) لكل عناصر الشجرة
        /// بناءً على ترتيب كل عنصر بين إخوته، ثم يحفظ النتيجة في قاعدة البيانات.
        /// </summary>
        private void RecalculateAndSave()
        {
            // نلتقط القيم الحالية قبل إعادة الحساب لمقارنتها بعده — إعادة حساب الشجرة كاملة في الذاكرة
            // عملية رخيصة (لا تلامس قاعدة البيانات)، لكن حفظ كل تصنيف في قاعدة البيانات في كل مرة (حتى
            // لو لم يتغيّر ترتيبه أو أبوه فعلياً) هو ما كان يجعل نقل عنصر واحد ثقيلاً مع عدد كبير من
            // التصنيفات. الآن يُحفظ فقط ما تغيّر فعلياً.
            var before = _data.Where(c => !c.IsDelete)
                               .ToDictionary(c => c.Id, c => (c.SortId, c.LvlId, c.Code, c.ParentId));

            // منطق الترقيم نفسه (بما فيه معاملة كل تصنيف رئيسي ثابت — المواد=M/المقاولين=C/الخدمات=S/
            // المعدات=E/الايجارات=R — كنقطة بداية مستقلة بادئتها حرف كوده) مُستخرج في
            // Data.ItemCategoryCodeService.Recalculate ليستخدمه أيضاً DatabaseInitializer عند بدء
            // التشغيل مباشرة على قاعدة البيانات، فتنعكس أي بادئة/مخطط ترميز جديد على كل المستويات لكل
            // من يشغّل النسخة المحدَّثة، لا فقط من يفتح هذه الشاشة بنفسه.
            Data.ItemCategoryCodeService.Recalculate(_data);

            // فقط التصنيفات التي تغيّر ترتيبها (SortId) أو مستواها (LvlId) أو رمزها (Code) أو أبوها
            // (ParentId) فعلياً — عادة ما تكون العقدة المنقولة وأسلافها/إخوتها المتأثرين فقط، وليس كل
            // التصنيفات — يُدفَع لها UPDATE؛ باقي الشجرة تبقى كما هي بلا أي استعلام إضافي.
            var changed = _data.Where(c => !c.IsDelete && (
                    !before.TryGetValue(c.Id, out var old) ||
                    old.SortId != c.SortId || old.LvlId != c.LvlId ||
                    old.Code != c.Code || old.ParentId != c.ParentId))
                .ToList();

            if (changed.Count > 0)
            {
                Data.DataContext.RunInTransaction(tx => dc.ItemCategory.EditRange(changed, tx));
            }

            treeList1.RefreshDataSource();
            UpdateRecordCount();
        }

        // ─── أزرار الشريط ───────────────────────────────────────────────────
        private void BbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_canManage) return;

            var focused = GetFocusedCategory();

            // المستوى الرئيسي (المواد/المقاولين/الخدمات/المعدات/الايجارات) ثابت — لا يمكن إضافة تصنيف
            // جديد بلا أب، لذا يجب أن يكون هناك عنصر مركَّز عليه (أحد الخمسة الثابتة أو أحد عناصرها
            // الفرعية) لتحديد أين يُضاف التصنيف الجديد.
            if (focused == null)
            {
                XtraMessageBox.Show(
                    "يرجى تحديد أحد التصنيفات الرئيسية الثابتة (المواد / المقاولين / الخدمات / المعدات / الايجارات) أو أحد عناصرها الفرعية أولاً، ثم أضف التصنيف الجديد تحته.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int parentId;
            if (focused.IsFixed)
            {
                // إضافة تحت أحد التصنيفات الثابتة الخمسة مباشرة — لا معنى لسؤال "فرعي/مستقل" هنا لأن
                // هذه العناصر لا يمكن أن يكون لها إخوة جدد.
                parentId = focused.Id;
            }
            else
            {
                var addAsChild = XtraMessageBox.Show(
                    $"هل تريد إضافة التصنيف الجديد كبند فرعي ضمن \"{focused.Name}\"؟\nاختر (لا) لإضافته كبند شقيق لـ \"{focused.Name}\" ضمن نفس المستوى.",
                    "إضافة تصنيف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

                // (لا) تعني الإضافة كشقيق لنفس أب العنصر المركَّز عليه — لم يعد بالإمكان إضافته كجذر
                // مستقل بعد الآن لأن الجذور الخمسة ثابتة، وهذا الأب لن يكون NULL أبداً لعنصر غير ثابت.
                parentId = addAsChild ? focused.Id : (focused.ParentId ?? focused.Id);
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

            var handle = ShowOverlay();
            try
            {
                var newId = dc.ItemCategory.Add(entity);
                entity.Id = newId;
                _data.Add(entity);

                RecalculateAndSave();

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

        // نقطة الدخول الموحّدة للتعديل (bbiEdit والنقر المزدوج على الشجرة) — الفحص هنا يمنع تجاوز
        // الصلاحية عبر النقر المزدوج الذي لا يمر بحالة تفعيل bbiEdit.Enabled.
        private void EditFocusedNode()
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة تصنيفات الأصناف.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var focused = GetFocusedCategory();
            if (focused == null)
            {
                XtraMessageBox.Show("يرجى تحديد تصنيف لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (focused.IsFixed)
            {
                XtraMessageBox.Show("لا يمكن تعديل التصنيفات الرئيسية الثابتة (المواد / المقاولين / الخدمات / المعدات / الايجارات).", "غير مسموح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var name = XtraInputBox.Show("اسم التصنيف:", "تعديل تصنيف", focused.Name ?? "");
            if (string.IsNullOrWhiteSpace(name)) return;

            var handle = ShowOverlay();
            try
            {
                focused.Name = name.Trim();
                focused.UpdateDate = DateTime.Now;
                focused.UpdateMachine = Session.Machine;
                focused.UpdateBy = Session.CurrentUser?.Id ?? 1;

                dc.ItemCategory.Edit(focused.Id, focused);
                treeList1.RefreshDataSource();

                // RefreshDataSource يعيد بناء كل عقد الشجرة، فيفقد التركيز على العقدة المعدَّلة — نُعيده
                // هنا، بنفس نمط RefocusNode المستخدم بعد الإضافة/النقل.
                RefocusNode(focused.Id);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التعديل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_canManage) return;

            var focused = GetFocusedCategory();
            if (focused == null)
            {
                XtraMessageBox.Show("يرجى تحديد تصنيف لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (focused.IsFixed)
            {
                XtraMessageBox.Show("لا يمكن حذف التصنيفات الرئيسية الثابتة (المواد / المقاولين / الخدمات / المعدات / الايجارات).", "غير مسموح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا التصنيف وكافة عناصره الفرعية؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            var handle = ShowOverlay();
            try
            {
                var toDelete = CollectWithDescendants(focused.Id);

                foreach (var item in toDelete)
                {
                    item.IsDelete = true;
                    item.DeletionDate = DateTime.Now;
                    item.DeletionMachine = Session.Machine;
                    item.DeletionBy = Session.CurrentUser?.Id ?? 1;
                }

                Data.DataContext.RunInTransaction(tx => dc.ItemCategory.EditRange(toDelete, tx));

                foreach (var item in toDelete)
                    _data.Remove(item);

                RecalculateAndSave();
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

        // يبدّل بين توسيع كل عقد التصنيف وطيّها بالكامل حسب حالتها الحالية — بنفس نمط ucItems.cs
        // (كان الزر معرَّفاً في الشريط بلا أي معالج حدث إطلاقاً).
        private void BtnExpandCollapse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        // ─── إعادة الترتيب وتغيير المستوى (الأب) ────────────────────────────
        private void MoveSibling(int direction)
        {
            if (!_canManage) return;

            var focused = GetFocusedCategory();
            if (focused == null || focused.IsFixed) return; // ترتيب التصنيفات الثابتة الخمسة لا يتغيّر

            var siblings = _data.Where(c => !c.IsDelete && c.ParentId == focused.ParentId)
                                 .OrderBy(c => c.SortId ?? c.Id)
                                 .ToList();

            var index = siblings.IndexOf(focused);
            var swapIndex = index + direction;
            if (index < 0 || swapIndex < 0 || swapIndex >= siblings.Count) return;

            var other = siblings[swapIndex];
            (focused.SortId, other.SortId) = (other.SortId, focused.SortId);

            var handle = ShowOverlay();
            try
            {
                RecalculateAndSave();
                RefocusNode(focused.Id);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void Indent()
        {
            if (!_canManage) return;

            var focused = GetFocusedCategory();
            if (focused == null || focused.IsFixed) return; // التصنيفات الثابتة لا تصبح فرعية لغيرها

            var siblings = _data.Where(c => !c.IsDelete && c.ParentId == focused.ParentId)
                                 .OrderBy(c => c.SortId ?? c.Id)
                                 .ToList();

            var index = siblings.IndexOf(focused);
            if (index <= 0) return; // لا يوجد شقيق سابق ليصبح أباً جديداً

            var newParent = siblings[index - 1];
            focused.ParentId = newParent.Id;
            focused.SortId = int.MaxValue;

            var handle = ShowOverlay();
            try
            {
                RecalculateAndSave();
                RefocusNode(focused.Id, expandParent: true);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void Outdent()
        {
            if (!_canManage) return;

            var focused = GetFocusedCategory();
            if (focused == null || focused.ParentId == null) return; // في المستوى الجذري أصلاً (أو أحد التصنيفات الثابتة نفسها)

            var parent = _data.FirstOrDefault(c => c.Id == focused.ParentId);
            if (parent == null) return;

            // أب العنصر المركَّز عليه أحد التصنيفات الثابتة الخمسة — لا يمكن الخروج فوقه لأن الجذر
            // الحقيقي (ParentId = NULL) أصبح محجوزاً للتصنيفات الثابتة فقط.
            if (parent.IsFixed)
            {
                XtraMessageBox.Show($"لا يمكن نقل هذا التصنيف خارج \"{parent.Name}\".", "غير مسموح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            focused.ParentId = parent.ParentId;
            focused.SortId = (parent.SortId ?? 0) + 1;

            var handle = ShowOverlay();
            try
            {
                RecalculateAndSave();
                RefocusNode(focused.Id);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void RefocusNode(int id, bool expandParent = false)
        {
            var node = treeList1.FindNodeByKeyID(id);
            if (node == null) return;

            treeList1.FocusedNode = node;
            if (expandParent && node.ParentNode != null)
                node.ParentNode.Expanded = true;
        }

        // تدرج رمادي من داكن (المستوى الأول) إلى فاتح كلما زاد العمق — نفس المنطق المستخدم في شجرة
        // الأصناف (ucItems)، لتمييز مستويات التصنيف الفرعية بصرياً دون الحاجة لألوان متعددة الأطياف.
        private static readonly Color[] _levelColors =
        {
            //SystemColors.ActiveCaption,
            SystemColors.GrayText,
            Color.FromArgb(165, 165, 165),
            Color.FromArgb(225, 225, 225),
            SystemColors.InactiveCaption,

            //Color.FromArgb(165, 165, 165),
            //Color.FromArgb(200, 200, 200)
        };

        private void TreeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            // العقدة المركَّز عليها تبرز بلون مميز فوق تدرّج الرمادي حسب المستوى — بدون هذا التمييز كان
            // تلوين المستويات "يبتلع" لون تظليل التركيز الافتراضي، فيبدو وكأن التركيز لا يتحرّك فعلياً بعد
            // كل عملية نقل/تغيير مستوى (RefocusNode) رغم أنه يتحرّك فعلاً — المشكلة كانت بصرية فقط.
            if (e.Node == treeList1.FocusedNode)
            {
                e.Appearance.BackColor = Color.FromArgb(0, 122, 204);
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.Options.UseForeColor = true;
                e.Appearance.Options.UseFont = true;
                return;
            }

            var color = _levelColors[Math.Min(e.Node.Level, _levelColors.Length - 1)];
            e.Appearance.BackColor = color;
            e.Appearance.ForeColor = color.R > 150 ? Color.Black : Color.White; // يبقى النص مقروءاً على الرمادي الفاتح بالمستويات العميقة
            e.Appearance.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            e.Appearance.Options.UseBackColor = true;
            e.Appearance.Options.UseForeColor = true;
            e.Appearance.Options.UseFont = true;
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

    }
}
