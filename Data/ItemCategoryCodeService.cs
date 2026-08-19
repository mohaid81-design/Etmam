using System.Collections.Generic;
using System.Linq;
using Core;

namespace Data
{
    // منطق ترقيم شجرة تصنيفات الأصناف (Code/LvlId/SortId) — مستخرج هنا (بدل تكراره) لأن
    // frmItemCategoryAddEdit.RecalculateAndSave يشغّله تفاعلياً على نسخة الشاشة من البيانات
    // (BindingList) عند كل إضافة/نقل، بينما DatabaseInitializer يحتاج تشغيله مرة واحدة عند بدء
    // تشغيل البرنامج مباشرة على قاعدة البيانات — بدون هذا الاستدعاء المباشر من DatabaseInitializer،
    // كانت البادئة الحرفية الجديدة (M/C/S/E/R) لا تنعكس إلا على من يفتح شاشة "تصنيفات الأصناف"
    // بنفسه؛ التصنيفات الرئيسية الثابتة وحدها (المزروعة مباشرة بكودها الصحيح) كانت تظهر مُحدَّثة.
    public static class ItemCategoryCodeService
    {
        // يعيد بناء LvlId/SortId/Code لكامل الشجرة في الذاكرة اعتماداً على ParentId/SortId الحاليين —
        // لا يلمس قاعدة البيانات؛ الحفظ مسؤولية الطرف المستدعي. كل تصنيف رئيسي ثابت (IsFixed) نقطة
        // بداية مستقلة لترقيم أبنائه بادئتها كود ذلك التصنيف نفسه (مثلاً M لتصنيف المواد).
        public static void Recalculate(IList<ItemCategory> data)
        {
            var byParent = data.Where(c => !c.IsDelete)
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
                    node.Code = $"{parentCode}{seq:00}";
                    Walk(node.Id, level + 1, node.Code);
                    seq++;
                }
            }

            var fixedRoots = data.Where(c => !c.IsDelete && c.IsFixed)
                                  .OrderBy(c => c.SortId ?? c.Id)
                                  .ToList();
            int fixedSeq = 1;
            foreach (var root in fixedRoots)
            {
                root.SortId = fixedSeq++;
                root.LvlId = 0;
                Walk(root.Id, 1, root.Code);
            }
        }

        // نسخة قائمة بذاتها تجلب الشجرة من قاعدة البيانات، تعيد ترقيمها، وتحفظ فقط ما تغيّر فعلياً —
        // تُستدعى من DatabaseInitializer.Initialize() عند كل بدء تشغيل (بعد SeedData مباشرة، لضمان أن
        // التصنيفات الثابتة الخمسة تحمل أكوادها الصحيحة أولاً) حتى تنعكس البادئة الحرفية على كل
        // المستويات فوراً لكل من يشغّل النسخة المحدَّثة، لا فقط من يفتح شاشة إدارة التصنيفات بنفسه.
        public static void RecalculateAndSave()
        {
            var dc = DataContext.Shared;
            var data = dc.ItemCategory.GetBy("IsDelete = 0");

            var before = data.ToDictionary(c => c.Id, c => (c.SortId, c.LvlId, c.Code, c.ParentId));

            Recalculate(data);

            var changed = data.Where(c =>
                    !before.TryGetValue(c.Id, out var old) ||
                    old.SortId != c.SortId || old.LvlId != c.LvlId ||
                    old.Code != c.Code || old.ParentId != c.ParentId)
                .ToList();

            if (changed.Count > 0)
                DataContext.RunInTransaction(tx => dc.ItemCategory.EditRange(changed, tx));
        }
    }
}
