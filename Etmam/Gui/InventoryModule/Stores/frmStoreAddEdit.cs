using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmStoreAddEdit : XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private readonly int _id;
        private readonly bool _readOnly;
        private StoreList? _entity;

        // readOnly=true (يُستخدم من btnOpen في ucStores): عرض فقط بلا أي إمكانية حفظ — يقفل كل الحقول
        // (بما فيها التفعيل) ويعطّل زر الحفظ، بخلاف الفتح العادي للتعديل الذي يقفل الكود/الاسم فقط إذا
        // كان المخزن مستخدماً (انظر ItemStoreLock في LoadRecord).
        public frmStoreAddEdit(int id = 0, bool readOnly = false)
        {
            _id = id;
            _readOnly = readOnly;
            InitializeComponent();
            //DesignSystem.ApplyButtonStyle(btnSave, true);
            //DesignSystem.ApplyButtonStyle(btnCancel);
            //DesignSystem.ApplyCairoFont(this);
            Text = $"مخزن - {(id > 0 ? (readOnly ? "عرض" : "تعديل") : "جديد")}";
            LoadLookups();
            LoadRecord();

            if (_readOnly || !StorePermissions.CanManage(dc))
            {
                btnSave.Enabled = false;
                txtCode.Properties.ReadOnly = true;
                txtName.Properties.ReadOnly = true;
                checkActive.Properties.ReadOnly = true;
            }
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

            // مقفلان (الكود والاسم فقط) إذا ظهر هذا المخزن بالفعل في مستند محفوظ — كلاهما مطبوع على
            // مستندات سابقة، فتغييرهما لاحقاً يُغيِّر معنى تلك المستندات رجعياً (انظر ItemStoreLock).
            // التفعيل يبقى قابلاً للتعديل دائماً.
            // المستخدم المدير (Id=1) يتجاوز هذا القفل بالكامل — نفس معنى IsSuperUser في PermissionService.
            if (_id > 0 && !PermissionService.IsSuperUser && ItemStoreLock.IsStoreUsed(dc, _id))
            {
                txtCode.Properties.ReadOnly = true;
                txtName.Properties.ReadOnly = true;
            }
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

            var handle = ShowOverlay();
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
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
