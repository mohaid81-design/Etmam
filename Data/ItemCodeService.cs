using System.Collections.Generic;
using System.Linq;
using Core;

namespace Data
{
    // منطق ترميز الأصناف (ItemsList.Code = كود التصنيف الحالي + تسلسل 3 أرقام ضمن نفس التصنيف) —
    // بنفس فلسفة Data.ItemCategoryCodeService: نسخة Recalculate خالصة في الذاكرة يستدعيها الطرفان
    // (RecalculateAndSave لإعادة الترحيل الشاملة عند بدء التشغيل، وPreviewNextCode لمعاينة الكود
    // التالي تفاعلياً في frmItemAddEdit) بدل تكرار نفس المنطق في كل مكان.
    public static class ItemCodeService
    {
        // يعيد بناء Code لكل صنف له تصنيف صالح: كود التصنيف الحالي + تسلسل 3 أرقام ضمن نفس التصنيف،
        // بترتيب يحافظ على الترتيب النسبي القديم بين الأصناف (استناداً للتسلسل اللاحق في الكود
        // القديم، إن وُجد) — فلا يعيد ترتيبها عشوائياً. الأصناف بلا تصنيف صالح (CategoryId فارغ أو
        // يشير لتصنيف محذوف/غير موجود) تبقى أكوادها كما هي. لا يلمس قاعدة البيانات؛ الحفظ مسؤولية
        // الطرف المستدعي.
        public static void Recalculate(IList<ItemsList> items, IReadOnlyDictionary<int, ItemCategory> categoriesById)
        {
            var groups = items.Where(i => !i.IsDelete && i.CategoryId is > 0)
                               .GroupBy(i => i.CategoryId!.Value);

            foreach (var group in groups)
            {
                if (!categoriesById.TryGetValue(group.Key, out var category) || string.IsNullOrEmpty(category.Code))
                    continue;

                int seq = 1;
                foreach (var item in group.OrderBy(i => ExtractTrailingSeq(i.Code)).ThenBy(i => i.Id))
                {
                    item.Code = category.Code + seq.ToString("000");
                    seq++;
                }
            }
        }

        // يعيد الكود المتوقع لصنف جديد/مُعاد تصنيفه دون حفظ — يُستخدم في frmItemAddEdit فور اختيار
        // التصنيف. excludeItemId يتجاهل السجل الحالي نفسه عند التعديل.
        public static string PreviewNextCode(DataContext dc, int categoryId, int excludeItemId)
        {
            var category = dc.ItemCategory.Find(categoryId);
            if (string.IsNullOrEmpty(category?.Code)) return "جديد";

            // نجلب كل أصناف هذا التصنيف (بما فيها المحذوفة) حتى لا يُعاد استخدام رقم تسلسلي سابق
            var items = dc.ItemsList.GetBySql("SELECT * FROM ItemsList WHERE CategoryId = @categoryId", new { categoryId });

            int maxSeq = 0;
            foreach (var item in items)
            {
                if (item.Id == excludeItemId) continue;
                if (string.IsNullOrEmpty(item.Code) || !item.Code.StartsWith(category.Code)) continue;

                // نعرف بالضبط طول بادئة كود التصنيف هنا (تأكدنا للتو أن الكود يبدأ بها فعلاً)، فنأخذ ما
                // يليها مباشرة — لا نستخدم ExtractTrailingSeq (أدناه) لأنها لا تعرف أين ينتهي كود
                // التصنيف نفسه وأين يبدأ تسلسل الصنف.
                var suffix = item.Code.Substring(category.Code.Length);
                if (int.TryParse(suffix, out var seq) && seq > maxSeq)
                    maxSeq = seq;
            }

            return category.Code + (maxSeq + 1).ToString("000");
        }

        // يستخرج التسلسل الرقمي من نهاية الكود بأخذ آخر 3 محارف حرفياً (عرض التسلسل ثابت دائماً —
        // seq:"000")، أو int.MaxValue إن تعذّر ذلك (فتُدفَع هذه الأصناف لنهاية الترتيب بدل كسر الفرز).
        //
        // ملاحظة مهمة: لا تأخذ "كل الأرقام اللاحقة" في الكود — أكواد التصنيفات نفسها كلها أرقام بعد
        // حرف الجذر (مثل "R0404")، فكانت "كل الأرقام اللاحقة" في كود صنف مثل "R0404001" تُقرأ خطأً
        // كـ 0404001 بدل 001 فقط، فيتضخم الكود المتولد تصاعدياً بلا توقف عند كل RecalculateAndSave
        // (السبب الفعلي وراء أكواد فاسدة رُصدت مثل R0404404002 — 404002 = 404001 القديمة + 1).
        private static int ExtractTrailingSeq(string? code)
        {
            if (string.IsNullOrEmpty(code) || code.Length < 3) return int.MaxValue;

            var last3 = code.Substring(code.Length - 3);
            return int.TryParse(last3, out var n) ? n : int.MaxValue;
        }

        // نسخة قائمة بذاتها تجلب كل الأصناف والتصنيفات من قاعدة البيانات، تعيد ترقيمها، وتحفظ فقط ما
        // تغيّر فعلياً — تُستدعى من DatabaseInitializer.Initialize() عند كل بدء تشغيل (بعد
        // ItemCategoryCodeService.RecalculateAndSave مباشرة، لضمان أن أكواد التصنيفات صحيحة أولاً)
        // حتى تنعكس البادئة الحرفية الجديدة (M/C/S/E/R) على أكواد الأصناف الموجودة فعلاً لكل من يشغّل
        // النسخة المحدَّثة، لا فقط من يفتح شاشة إضافة/تعديل صنف بنفسه.
        public static void RecalculateAndSave()
        {
            var dc = DataContext.Shared;
            var items = dc.ItemsList.GetBy("IsDelete = 0");
            var categoriesById = dc.ItemCategory.GetBy("IsDelete = 0").ToDictionary(c => c.Id);

            var before = items.ToDictionary(i => i.Id, i => i.Code);

            Recalculate(items, categoriesById);

            var changed = items.Where(i => before[i.Id] != i.Code).ToList();
            if (changed.Count > 0)
                DataContext.RunInTransaction(tx => dc.ItemsList.EditRange(changed, tx));
        }
    }
}
