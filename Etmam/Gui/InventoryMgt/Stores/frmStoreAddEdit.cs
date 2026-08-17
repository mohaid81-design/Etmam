using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmStoreAddEdit : XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private readonly int _id;
        private StoreList? _entity;

        public frmStoreAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();
            //DesignSystem.ApplyButtonStyle(btnSave, true);
            //DesignSystem.ApplyButtonStyle(btnCancel);
            //DesignSystem.ApplyCairoFont(this);
            Text = $"مخزن - {(id > 0 ? "تعديل" : "جديد")}";
            LoadLookups();
            LoadRecord();
        }

        private void LoadLookups()
        {
          
        }

        private void LoadRecord()
        {
            _entity = _id > 0 ? dc.StoreList.Find(_id) : new StoreList();
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                _entity = new StoreList();
            }
            
            if (_id > 0)
            {
                txtCode.Text = _entity.Code?.ToString() ?? "";
            }
            else
            {
                txtCode.Text = GenerateNextCode();
            }

            txtName.Text = _entity.Name ?? "";
            checkActive.Checked = _entity.IsActive ?? true;
        }

        private string GenerateNextCode()
        {
            try
            {
                var all = dc.StoreList.GetBy("IsDelete = 0");
                int maxCode = 0;
                foreach (var store in all)
                {
                    if (store.Code.HasValue && store.Code.Value > maxCode)
                    {
                        maxCode = store.Code.Value;
                    }
                }
                return (maxCode + 1).ToString();
            }
            catch
            {
                return "1";
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم المخزن.", "بيانات ناقصة",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _entity ??= new StoreList();
                _entity.Code = int.TryParse(txtCode.Text.Trim(), out int code) ? code : (int?)null;
                _entity.Name = txtName.Text.Trim();
                _entity.IsActive = checkActive.Checked;

                if (_id > 0)
                    dc.StoreList.Edit(_id, _entity);
                else
                    dc.StoreList.Add(_entity);

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
