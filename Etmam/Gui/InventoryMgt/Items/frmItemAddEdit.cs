using System;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmItemAddEdit : XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private ItemsList? _entity;
        private bool _loading;

        public frmItemAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            lookUpCategory.EditValueChanged += LookUpCategory_EditValueChanged;
            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            LoadLookups();
            LoadRecord();
        }

        private void LoadLookups()
        {
            lookUpCategory.Properties.DataSource = dc.ItemCategory.GetBy("IsDelete = 0");
            lookUpUnit.Properties.DataSource = dc.Units.GetBy("IsDelete = 0");
        }

        private void LoadRecord()
        {
            _loading = true;

            _entity = _id > 0 ? dc.ItemsList.Find(_id) : new ItemsList();
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _entity = new ItemsList();
            }

            Text = $"صنف - {(_id > 0 ? "تعديل" : "جديد")}";
            txtCode.Text = string.IsNullOrEmpty(_entity.Code) ? "جديد" : _entity.Code;
            txtName.Text = _entity.Name ?? "";
            memDescription.Text = _entity.Description ?? "";
            lookUpCategory.EditValue = _entity.CategoryId;
            lookUpUnit.EditValue = _entity.UnitId;
            checkActive.Checked = _entity.IsActive ?? true;

            _loading = false;
        }

        // ─── توليد كود الصنف تلقائياً: رمز التصنيف المُختار + تسلسل 3 أرقام (001, 002, ...) ───
        private void LookUpCategory_EditValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            var categoryId = lookUpCategory.EditValue as int?;
            txtCode.Text = categoryId is > 0 ? GenerateItemCode(categoryId.Value) : "جديد";
        }

        private string GenerateItemCode(int categoryId)
        {
            var category = dc.ItemCategory.Find(categoryId);
            var categoryCode = category?.Code;
            if (string.IsNullOrEmpty(categoryCode)) return "جديد";

            // نجلب كل أصناف هذا التصنيف (بما فيها المحذوفة) حتى لا يُعاد استخدام رقم تسلسلي سابق
            var items = dc.ItemsList.GetBySql("SELECT * FROM ItemsList WHERE CategoryId = @categoryId", new { categoryId });

            int maxSeq = 0;
            foreach (var item in items)
            {
                if (item.Id == _id) continue; // تجاهل السجل الحالي نفسه عند التعديل
                if (string.IsNullOrEmpty(item.Code) || !item.Code.StartsWith(categoryCode)) continue;

                var suffix = item.Code.Substring(categoryCode.Length);
                if (int.TryParse(suffix, out var seq) && seq > maxSeq)
                    maxSeq = seq;
            }

            return categoryCode + (maxSeq + 1).ToString("000");
        }

        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(lookUpCategory.Text))
            {
                XtraMessageBox.Show("الرجاء تحديد التصنيف.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم الصنف.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(lookUpUnit.Text))
            {
                XtraMessageBox.Show("الرجاء تحديد الوحدة.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

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

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
            Text = "صنف - جديد";
            txtName.Text = "";
            memDescription.Text = "";
            txtName.Focus();

            // إبقاء نفس التصنيف مختاراً لتسريع إدخال عدة أصناف متتالية لنفس التصنيف
            txtCode.Text = categoryId is > 0 ? GenerateItemCode(categoryId.Value) : "جديد";
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            using var frm = new frmItemCategoryAddEdit();
            if (frm.ShowDialog(this) == DialogResult.OK)
                LoadLookups();
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            using var frm = new frmUnitAddEdit();
            if (frm.ShowDialog(this) == DialogResult.OK)
                LoadLookups();
        }
    }
}
