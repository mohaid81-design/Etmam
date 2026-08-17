using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmMARAddEdit : DevExpress.XtraEditors.XtraForm
    {
        protected Data.DataContext dc => Data.DataContext.Shared;
        private int _id;
        private MaterialApprovalRequestList? _lst;
        private bool _isDirty = false;
        private bool _isLoading = false;
        private ucMARAddEdit? _ucMARAddEdit;
        private bool _IsSubmittedFormSigned = false;
        private bool _IsSubmitted = false;


        // ── Constructor ───────────────────────────────────────────────────────

        public frmMARAddEdit(int id = 0)
        {
            InitializeComponent();
            _id = id;

            // Apply Cairo font to the whole form
            DesignSystem.ApplyCairoFont(this);

            // Setup LookUpEdit controls with clear buttons and auto-search
            ConfigureLookUpEdit(lookUpEditCategory);
            ConfigureLookUpEdit(lookUpEditSubCategory);
            ConfigureLookUpEdit(lookUpEditPrj);

            lookUpEditCategory.Properties.DataSource = dc.SubmittalCategory.GetBy("IsDelete = 0").ToList();
            lookUpEditCategory.Properties.DisplayMember = "Name";
            lookUpEditCategory.Properties.ValueMember = "Id";

            lookUpEditSubCategory.Properties.DataSource = dc.SubmittalSubCategory.GetBy("IsDelete = 0").ToList();
            lookUpEditSubCategory.Properties.DisplayMember = "Name";
            lookUpEditSubCategory.Properties.ValueMember = "Id";

            lookUpEditPrj.Properties.DataSource = dc.ProjectsList.GetBy("IsDelete = 0").ToList();
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.ValueMember = "Id";

            _ucMARAddEdit = new ucMARAddEdit();
            SetupNavigationPage(_ucMARAddEdit);

            WireToolbarEvents();
            LoadRecord(_id);

            // Load attachments if editing an existing record
            if (_id > 0)
                _ucMARAddEdit.LoadForMAR(_id);
            this.FormClosing += FrmMARAddEdit_FormClosing;
        }


        private void SetupNavigationPage(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            var page = new DevExpress.XtraBars.Navigation.NavigationPage();
            page.Controls.Add(control);
            navigationFrame1.Pages.Add(page);
            navigationFrame1.SelectedPage = page;
        }


        // ── Toolbar wiring ─────────────────────────────────────────────────────

        private void WireToolbarEvents()
        {
            bbiNew.ItemClick += BbiNew_ItemClick;
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiPrint.ItemClick += BbiPrint_ItemClick;

            bbiFirst.ItemClick += (s, e) => Navigate("First");
            bbiPrev.ItemClick += (s, e) => Navigate("Prev");
            bbiNext.ItemClick += (s, e) => Navigate("Next");
            bbiLast.ItemClick += (s, e) => Navigate("Last");
            bbiSearch.ItemClick += BbiSearch_ItemClick;

            // simpleButtonPrj – placeholder for future project quick-open
            simpleButtonPrj.Click += (s, e) =>
            {
                XtraMessageBox.Show("ميزة فتح المشروع قيد التطوير.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            // simpleButton1 / simpleButton2 – reserved action buttons
            simpleButton1.Click += (s, e) =>
            {
                XtraMessageBox.Show("ميزة قيد التطوير.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            simpleButton2.Click += (s, e) =>
            {
                XtraMessageBox.Show("ميزة قيد التطوير.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Mark dirty on any field change
            dtDate.EditValueChanged += (s, e) => MarkDirty();
            memDescription.EditValueChanged += (s, e) => MarkDirty();
            lookUpEditCategory.EditValueChanged += (s, e) =>
            {
                MarkDirty();
                UpdateSubCategoryDataSource();
            };
            lookUpEditSubCategory.EditValueChanged += (s, e) => MarkDirty();
            lookUpEditPrj.EditValueChanged += (s, e) => MarkDirty();

            // Attachment checkboxes & text
            checkEditCatalogues.CheckedChanged += (s, e) => MarkDirty();
            checkEditCalculations.CheckedChanged += (s, e) => MarkDirty();
            checkEditCertificates.CheckedChanged += (s, e) => MarkDirty();
            checkEditDrawings.CheckedChanged += (s, e) => MarkDirty();
            checkEditSample.CheckedChanged += (s, e) => MarkDirty();
            checkEditSpecifications.CheckedChanged += (s, e) => MarkDirty();
            checkEditTest.CheckedChanged += (s, e) => MarkDirty();
            checkEditOther.CheckedChanged += (s, e) => MarkDirty();
            textEditOther.EditValueChanged += (s, e) => MarkDirty();
        }

        private void MarkDirty()
        {
            if (!_isLoading) _isDirty = true;
        }

        // ── Load / Refresh ────────────────────────────────────────────────────

        private void LoadRecord(int id)
        {
            _isLoading = true;
            try
            {
                if (id > 0)
                {
                    _lst = dc.MaterialApprovalRequestList.Find(id);
                    if (_lst == null)
                    {
                        XtraMessageBox.Show("لم يتم العثور على طلب اعتماد المواد المطلوب.", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    lookUpEditPrj.EditValue = _lst.PrjId;
                    txtNum.Text = _lst.Num?.ToString() ?? "";
                    txtRev.Text = _lst.Rev?.ToString() ?? "";
                    dtDate.EditValue = _lst.PreparedDate;
                    lookUpEditCategory.EditValue = _lst.Category;
                    lookUpEditSubCategory.EditValue = _lst.SubCategory;
                    memDescription.Text = _lst.Description ?? "";

                    // Attachment checkboxes
                    checkEditCatalogues.Checked = _lst.AttachCatalogues ?? false;
                    checkEditCalculations.Checked = _lst.AttachCalculations ?? false;
                    checkEditCertificates.Checked = _lst.AttachCertificates ?? false;
                    checkEditDrawings.Checked = _lst.AttachDrawings ?? false;
                    checkEditSample.Checked = _lst.AttachSample ?? false;
                    checkEditSpecifications.Checked = _lst.AttachSpecifications ?? false;
                    checkEditTest.Checked = _lst.AttachTest ?? false;
                    checkEditOther.Checked = _lst.AttachOther ?? false;
                    textEditOther.Text = _lst.AttachOtherText ?? "";

                    // Status flags
                    _IsSubmittedFormSigned = _lst.IsSubmittedFormSigned ?? false;
                    _IsSubmitted = _lst.IsSubmitted ?? false;

                    Text = $"طلب اعتماد مواد - {_lst.Description ?? _lst.Num?.ToString()}";
                    bbiDelete.Enabled = true;
                }
                else
                {
                    _lst = new MaterialApprovalRequestList();
                    txtNum.Text = GenerateNextNum();
                    txtRev.Text = "0";
                    dtDate.EditValue = DateTime.Today;
                    memDescription.Text = "";
                    lookUpEditCategory.EditValue = null;
                    lookUpEditSubCategory.EditValue = null;
                    lookUpEditPrj.EditValue = null;

                    // Reset attachment checkboxes
                    checkEditCatalogues.Checked = false;
                    checkEditCalculations.Checked = false;
                    checkEditCertificates.Checked = false;
                    checkEditDrawings.Checked = false;
                    checkEditSample.Checked = false;
                    checkEditSpecifications.Checked = false;
                    checkEditTest.Checked = false;
                    checkEditOther.Checked = false;
                    textEditOther.Text = "";

                    _IsSubmittedFormSigned = false;
                    _IsSubmitted = false;

                    Text = "طلب اعتماد مواد - جديد";
                    bbiDelete.Enabled = false;
                }
                _isDirty = false;
            }
            finally
            {
                _isLoading = false;
            }
        }

        private string GenerateNextNum()
        {
            var all = dc.MaterialApprovalRequestList.GetBy("IsDelete = 0");
            int maxNum = all.Any() ? all.Max(r => r.Num ?? 0) : 0;
            return (maxNum + 1).ToString("D3");
        }



        // ── Save ───────────────────────────────────────────────────────────────

        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e) => SaveRecord();



        private bool SaveRecord(bool silent = false)
        {
            if (string.IsNullOrWhiteSpace(lookUpEditPrj.Text))
            { XtraMessageBox.Show("الرجاء تحديد إسم المشروع.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrWhiteSpace(lookUpEditCategory.Text))
            { XtraMessageBox.Show("الرجاء تحديد تصنيف التقديم.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrWhiteSpace(lookUpEditSubCategory.Text))
            { XtraMessageBox.Show("الرجاء تحديد التصنيف الثانوي للتقديم.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrWhiteSpace(memDescription.Text))
            { XtraMessageBox.Show("الرجاء بيان وصف المواد.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrWhiteSpace(dtDate.Text))
            { XtraMessageBox.Show("الرجاء بيان تاريخ إعداد طلب التقديم.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (_lst == null) _lst = new MaterialApprovalRequestList();

            _lst.Num = int.TryParse(txtNum.Text, out int num) ? num : (int?)null;
            _lst.Rev = int.TryParse(txtRev.Text, out int rev) ? rev : (int?)null;
            _lst.PreparedDate = dtDate.EditValue as DateTime?;
            _lst.Description = memDescription.Text.Trim();
            _lst.Category = GetLookUpValue(lookUpEditCategory);
            _lst.SubCategory = GetLookUpValue(lookUpEditSubCategory);
            _lst.PrjId = GetLookUpValue(lookUpEditPrj);

            // Preserve existing OverallStatus on edit; set to 1 (Draft) for new records
            if (_id <= 0)
                _lst.OverallStatus = 1;

            _lst.AttachCatalogues = checkEditCatalogues.Checked;
            _lst.AttachCalculations = checkEditCalculations.Checked;
            _lst.AttachCertificates = checkEditCertificates.Checked;
            _lst.AttachDrawings = checkEditDrawings.Checked;
            _lst.AttachSample = checkEditSample.Checked;
            _lst.AttachSpecifications = checkEditSpecifications.Checked;
            _lst.AttachTest = checkEditTest.Checked;
            _lst.AttachOther = checkEditOther.Checked;
            _lst.AttachOtherText = textEditOther.Text.Trim();
            _lst.IsSubmittedFormSigned = _IsSubmittedFormSigned;
            _lst.IsSubmitted = _IsSubmitted;

            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);

                if (_id > 0)
                {
                    dc.MaterialApprovalRequestList.Edit(_id, _lst);
                }
                else
                {
                    _id = dc.MaterialApprovalRequestList.Add(_lst);
                    bbiDelete.Enabled = true;
                    Text = $"طلب اعتماد مواد - {_lst.Description}";
                }

                // Save grid details first
                _ucMARAddEdit?.SaveData(_id);

                // After saving, refresh attachments with the real MAR ID
                _ucMARAddEdit?.LoadForMAR(_id);

                _isDirty = false;

                if (!silent)
                {
                    XtraMessageBox.Show("تم حفظ طلب اعتماد المواد بنجاح.", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ أثناء الحفظ: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        // ── Delete ─────────────────────────────────────────────────────────────

        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_id <= 0) return;

            if (XtraMessageBox.Show("هل أنت متأكد من حذف طلب اعتماد المواد؟", "تأكيد الحذف",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    dc.MaterialApprovalRequestList.Delete(_id);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("خطأ أثناء الحذف: " + ex.Message, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── New ────────────────────────────────────────────────────────────────

        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_isDirty)
            {
                var r = XtraMessageBox.Show("هناك تغييرات غير محفوظة. هل تريد الحفظ أولاً؟",
                    "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Cancel) return;
                if (r == DialogResult.Yes && !SaveRecord()) return;
            }
            _id = 0;
            LoadRecord(0);
            _ucMARAddEdit?.LoadForMAR(0);
        }

        // ── Navigation ─────────────────────────────────────────────────────────

        private void Navigate(string direction)
        {
            if (_isDirty)
            {
                var r = XtraMessageBox.Show("هناك تغييرات غير محفوظة. هل تريد الحفظ قبل الانتقال؟",
                    "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Cancel) return;
                if (r == DialogResult.Yes && !SaveRecord()) return;
            }

            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);
                MaterialApprovalRequestList? target = null;

                switch (direction)
                {
                    case "First":
                        target = dc.MaterialApprovalRequestList.GetBy(
                            "IsDelete = 0 ORDER BY Num ASC, Rev ASC").FirstOrDefault();
                        break;
                    case "Last":
                        target = dc.MaterialApprovalRequestList.GetBy(
                            "IsDelete = 0 ORDER BY Num DESC, Rev DESC").FirstOrDefault();
                        break;
                    case "Next":
                        target = dc.MaterialApprovalRequestList.GetBy(
                            "IsDelete = 0 AND Id > @id ORDER BY Id ASC",
                            new { id = _id }).FirstOrDefault();
                        break;
                    case "Prev":
                        target = dc.MaterialApprovalRequestList.GetBy(
                            "IsDelete = 0 AND Id < @id ORDER BY Id DESC",
                            new { id = _id }).FirstOrDefault();
                        break;
                }

                if (target != null)
                {
                    _id = target.Id;
                    LoadRecord(_id);
                    _ucMARAddEdit?.LoadForMAR(_id);
                }
                else
                {
                    string msg = direction switch
                    {
                        "First" => "هذا أول سجل.",
                        "Last" => "هذا آخر سجل.",
                        "Next" => "لا توجد سجلات تالية.",
                        _ => "لا توجد سجلات سابقة."
                    };
                    XtraMessageBox.Show(msg, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        // ── Search ─────────────────────────────────────────────────────────────

        private void BbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            string numStr = beiSearchNum.EditValue?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(numStr)) return;

            if (!int.TryParse(numStr, out int searchNum)) return;

            var result = dc.MaterialApprovalRequestList.GetBy(
                "IsDelete = 0 AND Num = @num ORDER BY Rev DESC",
                new { num = searchNum }).FirstOrDefault();

            if (result != null)
            {
                _id = result.Id;
                LoadRecord(_id);
                _ucMARAddEdit?.LoadForMAR(_id);
            }
            else
            {
                XtraMessageBox.Show($"لم يتم العثور على طلب اعتماد مواد برقم ({searchNum}).", "بحث",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ── Print ──────────────────────────────────────────────────────────────

        private void BbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("ميزة الطباعة قيد التطوير.", "تنبيه",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Form closing guard ─────────────────────────────────────────────────

        private void FrmMARAddEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                var r = XtraMessageBox.Show("هناك تغييرات غير محفوظة. هل تريد الحفظ قبل الإغلاق؟",
                    "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (!SaveRecord()) e.Cancel = true;
                }
                else if (r == DialogResult.Cancel) e.Cancel = true;
            }
        }

        private void lookUpEditSubCategory_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void ConfigureLookUpEdit(LookUpEdit lookUpEdit)
        {
            lookUpEdit.Properties.NullText = "";
            lookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            lookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            // Add a Clear button next to the dropdown combo button
            lookUpEdit.Properties.Buttons.Clear();
            lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            });

            lookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
                {
                    lookUpEdit.EditValue = null;
                }
            };
        }

        private int? GetLookUpValue(LookUpEdit lookUpEdit)
        {
            var val = lookUpEdit.EditValue;
            if (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()))
                return null;
            if (int.TryParse(val.ToString(), out int res))
                return res;
            return null;
        }

        private void UpdateSubCategoryDataSource()
        {
            var catId = GetLookUpValue(lookUpEditCategory);
            if (catId != null)
            {
                var filtered = dc.SubmittalSubCategory.GetBy("IsDelete = 0 AND CategoryId = @catId", new { catId = catId.Value }).ToList();
                lookUpEditSubCategory.Properties.DataSource = filtered;

                // If current SubCategory value is not in the filtered list, reset it.
                if (GetLookUpValue(lookUpEditSubCategory) is int currentSubId)
                {
                    if (!filtered.Any(x => x.Id == currentSubId))
                    {
                        lookUpEditSubCategory.EditValue = null;
                    }
                }
            }
            else
            {
                var allSub = dc.SubmittalSubCategory.GetBy("IsDelete = 0").ToList();
                lookUpEditSubCategory.Properties.DataSource = allSub;
            }
        }

        private void navigationFrame1_Click(object sender, EventArgs e)
        {

        }
    }
}