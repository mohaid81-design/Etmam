using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmItemAddEdit : XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private ItemsList? _entity;
        private bool _loading;

        // true إذا ظهر هذا الصنف بالفعل في مستند محفوظ واحد على الأقل (انظر ItemStoreLock) — عندها
        // تُقفل الكود/الاسم/التصنيف/الوحدة (بيانات الهوية المطبوعة على مستندات سابقة)، بينما يبقى
        // الوصف والتفعيل قابلين للتعديل بحرية.
        private bool _locked;

        private readonly bool _readOnly;

        // معرّف آخر صنف تم حفظه بنجاح (إضافة أو تعديل) — يقرأه المستدعي (ucItems) بعد إغلاق الشاشة
        // بنتيجة DialogResult.OK ليُركِّز عليه في الشجرة بعد إعادة التحميل.
        public int SavedItemId { get; private set; }

        // readOnly=true (يُستخدم من btnOpen في ucItems): عرض فقط بلا أي إمكانية حفظ — يقفل كل الحقول
        // بما فيها الوصف والتفعيل ويعطّل كل أزرار الحفظ/الإضافة، بخلاف الفتح العادي للتعديل الذي يقفل
        // الكود/الاسم/التصنيف/الوحدة فقط إذا كان الصنف مستخدماً (انظر _locked في LoadRecord).
        public frmItemAddEdit(int id = 0, bool readOnly = false)
        {
            _id = id;
            _readOnly = readOnly;
            InitializeComponent();

            lookUpCategory.EditValueChanged += LookUpCategory_EditValueChanged;

            // عند فتح القائمة المنسدلة يبقى التركيز الفعلي على صندوق التحرير الرئيسي (وليس على صندوق
            // البحث المرسوم داخل الشجرة عبر OptionsFind.AlwaysVisible)، فلا يُكتب فيه شيء رغم ظهوره —
            // ShowFindPanel يجبر الشجرة على نقل التركيز فعلياً إلى صندوق البحث في كل مرة تُفتح القائمة.
            lookUpCategory.Popup += (s, e) => treeListLookUpEdit1TreeList.ShowFindPanel();

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            txtName.EditValueChanged += (s, e) => RevalidateField(txtName, !string.IsNullOrWhiteSpace(txtName.Text));
            lookUpUnit.EditValueChanged += (s, e) => RevalidateField(lookUpUnit, !string.IsNullOrWhiteSpace(lookUpUnit.Text));
            lookUpCategory.EditValueChanged += (s, e) => RevalidateField(lookUpCategory, !string.IsNullOrWhiteSpace(lookUpCategory.Text));

            LoadLookups();
            LoadRecord();

            if (_readOnly)
            {
                txtCode.Properties.ReadOnly = true;
                txtName.Properties.ReadOnly = true;
                memDescription.Properties.ReadOnly = true;
                lookUpCategory.Properties.ReadOnly = true;
                lookUpUnit.Properties.ReadOnly = true;
                checkActive.Properties.ReadOnly = true;
                btnSaveClose.Enabled = false;
                btnSaveNew.Enabled = false;
                btnCategory.Enabled = false;
                btnUnit.Enabled = false;
            }
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>The three fields marked with a green background in the Designer are the record's
        /// required fields. Checked together on Save; any that are empty turn salmon and the first
        /// one gets focus, instead of one message box per missing field.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (txtName as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(txtName.Text)),
            (lookUpUnit as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(lookUpUnit.Text)),
            (lookUpCategory as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(lookUpCategory.Text)),
        };

        private static void SetRequiredFieldState(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            control.Properties.Appearance.BackColor = isFilled ? Color.LightGreen : Color.Salmon;
            control.Properties.Appearance.Options.UseBackColor = true;
            control.Invalidate();
        }

        /// <summary>Live revert-to-green as the user types/selects — called from each required
        /// field's EditValueChanged, independent of the next Save attempt.</summary>
        private void RevalidateField(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            if (isFilled) SetRequiredFieldState(control, true);
        }

        private bool ValidateRequiredFields()
        {
            DevExpress.XtraEditors.BaseEdit? firstInvalid = null;
            foreach (var (control, isFilled) in RequiredFieldChecks())
            {
                SetRequiredFieldState(control, isFilled);
                if (!isFilled && firstInvalid == null) firstInvalid = control;
            }

            if (firstInvalid == null) return true;

            XtraMessageBox.Show("الرجاء تعبئة كل الحقول المطلوبة (باللون الأحمر).", "بيانات ناقصة",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firstInvalid.Focus();
            return false;
        }

        private void LoadLookups()
        {
            lookUpCategory.Properties.DataSource = dc.ItemCategory.GetBy("IsDelete = 0");
            lookUpUnit.Properties.DataSource = dc.Units.GetBy("IsDelete = 0");

            // إعادة تعيين DataSource وحدها لا تُحدِّث النص المعروض داخل lookUpCategory إن كان EditValue
            // قد سبق ضبطه (مثال: فتح btnCategory_Click لتعديل اسم تصنيف مختار بالفعل ثم العودة لهذه
            // الشاشة) — يبقى الاسم القديم معروضاً رغم تحديث مصدر البيانات. إعادة ضبط EditValue تجبر
            // العنصر على إعادة القراءة من المصدر الجديد. _loading يمنع هذا من إعادة توليد كود الصنف عبر
            // LookUpCategory_EditValueChanged كأثر جانبي غير مقصود عند تعديل صنف موجود بالفعل.
            _loading = true;
            var currentCategoryId = lookUpCategory.EditValue;
            lookUpCategory.EditValue = null;
            lookUpCategory.EditValue = currentCategoryId;
            _loading = false;
        }

        private void LoadRecord()
        {
            _loading = true;

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            _entity = _id > 0 ? dc.ItemsList.Find(_id) : new ItemsList();
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _entity = new ItemsList();
            }

            Text = $"صنف - {(_id > 0 ? (_readOnly ? "عرض" : "تعديل") : "جديد")}";
            txtCode.Text = string.IsNullOrEmpty(_entity.Code) ? "جديد" : _entity.Code;
            txtName.Text = _entity.Name ?? "";
            memDescription.Text = _entity.Description ?? "";
            lookUpCategory.EditValue = _entity.CategoryId;
            lookUpUnit.EditValue = _entity.UnitId;
            checkActive.Checked = _entity.IsActive ?? true;

            // المستخدم المدير (Id=1) يتجاوز هذا القفل بالكامل — نفس معنى IsSuperUser في PermissionService.
            _locked = _id > 0 && !PermissionService.IsSuperUser && ItemStoreLock.IsItemUsed(dc, _id);
            txtCode.Properties.ReadOnly = _locked;
            txtName.Properties.ReadOnly = _locked;
            lookUpCategory.Properties.ReadOnly = _locked;
            lookUpUnit.Properties.ReadOnly = _locked;

            _loading = false;
        }

        // ─── توليد كود الصنف تلقائياً: رمز التصنيف المُختار + تسلسل 3 أرقام (001, 002, ...) ───
        private void LookUpCategory_EditValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            var categoryId = lookUpCategory.EditValue as int?;
            var category = categoryId is > 0 ? dc.ItemCategory.Find(categoryId.Value) : null;

            // لا يجوز اختيار أحد التصنيفات الرئيسية الثابتة (المواد/المقاولين/الخدمات/المعدات/الايجارات) كتصنيف مباشر
            // لصنف — هي عناوين تنظيمية فقط، تظهر في الشجرة لتجميع فروعها وليست تصنيفات فعلية لأي صنف.
            if (category?.IsFixed == true)
            {
                XtraMessageBox.Show(
                    $"\"{category.Name}\" تصنيف رئيسي ثابت ولا يصلح كتصنيف مباشر لصنف — يرجى اختيار أحد التصنيفات الفرعية تحته.",
                    "تصنيف غير صالح", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                _loading = true;
                lookUpCategory.EditValue = null;
                _loading = false;
                txtCode.Text = "جديد";
                return;
            }

            // الكود مقفل لأن الصنف مستخدم بالفعل — لا يجوز إعادة توليده حتى لو تغيَّر التصنيف (انظر _locked).
            if (_locked) return;

            // إعادة اختيار نفس تصنيف الصنف المحفوظ حالياً (بلا تغيير فعلي — قد يحدث هذا الحدث حتى بلا
            // تغيير حقيقي في القيمة، مثل إعادة فتح القائمة واختيار نفس العنصر) يجب ألا يُعيد توليد الكود
            // — كان هذا يستبدل كوداً صحيحاً محفوظاً برقم تسلسلي جديد أكبر بلا داعٍ (مثال حقيقي: صنف كان
            // كوده 01006 فأصبح 01008 بعد تعديله رغم بقاء تصنيفه كما هو).
            if (_id > 0 && categoryId == _entity?.CategoryId)
            {
                txtCode.Text = string.IsNullOrEmpty(_entity?.Code) ? "جديد" : _entity!.Code;
                return;
            }

            txtCode.Text = categoryId is > 0 ? Data.ItemCodeService.PreviewNextCode(dc, categoryId.Value, _id) : "جديد";
        }

        private bool Save()
        {
            if (!ValidateRequiredFields()) return false;

            // حماية إضافية عند الحفظ بجانب الحماية في LookUpCategory_EditValueChanged — تحسباً لأي
            // مسار آخر يضبط EditValue برمجياً بدون المرور بحدث التغيير.
            var selectedCategoryId = lookUpCategory.EditValue as int?;
            if (selectedCategoryId is > 0 && dc.ItemCategory.Find(selectedCategoryId.Value)?.IsFixed == true)
            {
                XtraMessageBox.Show(
                    "لا يمكن اختيار تصنيف رئيسي ثابت (المواد / المقاولين / الخدمات / المعدات / الايجارات) كتصنيف مباشر لصنف — يرجى اختيار أحد التصنيفات الفرعية تحته.",
                    "بيانات غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var handle = ShowOverlay();
            try
            {
                _entity ??= new ItemsList();
                _entity.Code = txtCode.Text.Trim();
                _entity.Name = txtName.Text.Trim();
                _entity.Description = memDescription.Text.Trim();
                _entity.CategoryId = lookUpCategory.EditValue as int?;
                _entity.UnitId = lookUpUnit.EditValue as int?;
                _entity.IsActive = checkActive.Checked;

                if (_id > 0)
                {
                    _entity.UpdateDate = DateTime.Now;
                    _entity.UpdateMachine = Session.Machine;
                    _entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.ItemsList.Edit(_id, _entity);
                }
                else
                {
                    _entity.CreatedDate = DateTime.Now;
                    _entity.CreatedMachine = Session.Machine;
                    _entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    _id = dc.ItemsList.Add(_entity);
                    _entity.Id = _id;
                }

                SavedItemId = _id;
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (!Save()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (!Save()) return;

            var categoryId = lookUpCategory.EditValue as int?;

            _id = 0;
            _entity = new ItemsList();
            _locked = false; // سجل جديد بالكامل — لم يُستخدم بعد، فلا مبرر لبقاء قفل السجل السابق
            txtCode.Properties.ReadOnly = false;
            txtName.Properties.ReadOnly = false;
            lookUpCategory.Properties.ReadOnly = false;
            lookUpUnit.Properties.ReadOnly = false;
            Text = "صنف - جديد";
            txtName.Text = "";
            memDescription.Text = "";
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);
            txtName.Focus();

            // إبقاء نفس التصنيف مختاراً لتسريع إدخال عدة أصناف متتالية لنفس التصنيف
            txtCode.Text = categoryId is > 0 ? Data.ItemCodeService.PreviewNextCode(dc, categoryId.Value, _id) : "جديد";
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            var handle = ShowOverlay();
            frmItemCategoryAddEdit frm;
            try { frm = new frmItemCategoryAddEdit(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadLookups();
            }
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            var handle = ShowOverlay();
            frmUnitAddEdit frm;
            try { frm = new frmUnitAddEdit(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadLookups();
            }
        }

        private void bbiImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using var frm = new Etmam.Gui.General.ImportFromExcel.ImportDataFromExcel();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
