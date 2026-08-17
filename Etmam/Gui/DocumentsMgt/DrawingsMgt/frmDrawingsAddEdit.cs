using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmDrawingsAddEdit : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private int _id;
        private DrawingsSubmittalList? _record;
        private bool _isDirty = false;
        private bool _isLoading = false;
        private ucDrawingsAddEdit? _ucAttachments;

        // ── Constructor ───────────────────────────────────────────────────────

        public frmDrawingsAddEdit(int id = 0)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _id = id;

            WireToolbarEvents();
            LoadRecord(_id);

            _ucAttachments = new ucDrawingsAddEdit();
            SetupNavigationPage(_ucAttachments);

            // Wire auto-save: when user clicks bbiAdd before saving the drawing
            _ucAttachments.SaveRequired += SaveAndReturnId;

            // Load attachments if editing an existing record
            if (_id > 0)
                _ucAttachments.LoadForDrawing(_id);

            this.FormClosing += FrmDrawingApprovalRequest_FormClosing;
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
            bbiNew.ItemClick    += BbiNew_ItemClick;
            bbiSave.ItemClick   += BbiSave_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiPrint.ItemClick  += BbiPrint_ItemClick;

            bbiFirst.ItemClick += (s, e) => Navigate("First");
            bbiPrev.ItemClick  += (s, e) => Navigate("Prev");
            bbiNext.ItemClick  += (s, e) => Navigate("Next");
            bbiLast.ItemClick  += (s, e) => Navigate("Last");
            bbiSearch.ItemClick += BbiSearch_ItemClick;

            // Mark dirty on any field change
            dtDate.EditValueChanged   += (s, e) => MarkDirty();
            memDescription.EditValueChanged += (s, e) => MarkDirty();
            cbeType.EditValueChanged  += (s, e) => MarkDirty();
            cbeCategory.EditValueChanged += (s, e) => MarkDirty();
            coShift.EditValueChanged  += (s, e) => MarkDirty();
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
                    _record = DC.DrawingsSubmittalList.Find(id);
                    if (_record == null)
                    {
                        XtraMessageBox.Show("لم يتم العثور على المخطط المطلوب.", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtNum.Text            = _record.Num?.ToString() ?? "";
                    txtRev.Text            = _record.Rev?.ToString() ?? "";
                    dtDate.EditValue       = _record.PreparedDate;
                    memDescription.Text    = _record.Description ?? "";
                    cbeType.EditValue      = _record.Type;
                    cbeCategory.EditValue  = _record.Category;
                    //coShift.EditValue      = _record.Floor;

                    Text = $"طلب اعتماد مخطط - {_record.Description ?? _record.Num?.ToString()}";
                    bbiDelete.Enabled = true;
                }
                else
                {
                    _record = new DrawingsSubmittalList();
                    txtNum.Text           = GenerateNextNum();
                    txtRev.Text           = "0";
                    dtDate.EditValue      = DateTime.Today;
                    memDescription.Text   = "";
                    cbeType.EditValue     = null;
                    cbeCategory.EditValue = null;
                    coShift.EditValue     = "للمراجعة والاعتماد";

                    Text = "طلب اعتماد مخطط - جديد";
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
            var all = DC.DrawingsSubmittalList.GetBy("IsDelete = 0");
            int maxNum = all.Any() ? all.Max(r => r.Num ?? 0) : 0;
            return (maxNum + 1).ToString("D3");
        }



        // ── Save ───────────────────────────────────────────────────────────────

        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e) => SaveRecord();

        /// <summary>
        /// Called by ucDrawingsAddEdit.SaveRequired — silently saves and returns the new drawing ID.
        /// Returns 0 if validation fails.
        /// </summary>
        private int SaveAndReturnId()
        {
            if (string.IsNullOrWhiteSpace(memDescription.Text))
            {
                XtraMessageBox.Show(
                    "يجب إدخال وصف المخطط أولاً لحفظ السجل وإضافة المرفق.",
                    "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            return SaveRecord(silent: true) ? _id : 0;
        }

        private bool SaveRecord(bool silent = false)
        {
            if (string.IsNullOrWhiteSpace(memDescription.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال وصف المخطط.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_record == null) _record = new DrawingsSubmittalList();

            _record.Num         = int.TryParse(txtNum.Text, out int num) ? num : (int?)null;
            _record.Rev         = int.TryParse(txtRev.Text, out int rev) ? rev : (int?)null;
            _record.PreparedDate= dtDate.EditValue as DateTime?;
            _record.Description = memDescription.Text.Trim();
            _record.Purpose     = memDescription.Text.Trim(); // use description as doc name
            _record.Type        = cbeType.EditValue?.ToString();
            _record.Category    = cbeCategory.EditValue?.ToString();
            // _record.Floor      = coShift.EditValue?.ToString();
            _record.PrjId       = Session.SelectedProjectId;

            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);

                if (_id > 0)
                {
                    DC.DrawingsSubmittalList.Edit(_id, _record);
                }
                else
                {
                    _id = DC.DrawingsSubmittalList.Add(_record);
                    bbiDelete.Enabled = true;
                    Text = $"طلب اعتماد مخطط - {_record.Description}";
                }

                _isDirty = false;

                if (!silent)
                {
                    XtraMessageBox.Show("تم حفظ المخطط بنجاح.", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // After saving, refresh attachments with the real drawing ID
                _ucAttachments?.LoadForDrawing(_id);

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

            if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا المخطط؟", "تأكيد الحذف",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    DC.DrawingsSubmittalList.Delete(_id);
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
                int prjId = Session.SelectedProjectId ?? 0;
                DrawingsSubmittalList? target = null;

                switch (direction)
                {
                    case "First":
                        target = DC.DrawingsSubmittalList.GetBy(
                            "IsDelete = 0 ORDER BY Num ASC, Rev ASC").FirstOrDefault();
                        break;
                    case "Last":
                        target = DC.DrawingsSubmittalList.GetBy(
                            "IsDelete = 0 ORDER BY Num DESC, Rev DESC").FirstOrDefault();
                        break;
                    case "Next":
                        target = DC.DrawingsSubmittalList.GetBy(
                            "IsDelete = 0 AND Id > @id ORDER BY Id ASC",
                            new { id = _id }).FirstOrDefault();
                        break;
                    case "Prev":
                        target = DC.DrawingsSubmittalList.GetBy(
                            "IsDelete = 0 AND Id < @id ORDER BY Id DESC",
                            new { id = _id }).FirstOrDefault();
                        break;
                }

                if (target != null)
                {
                    _id = target.Id;
                    LoadRecord(_id);
                    _ucAttachments?.LoadForDrawing(_id);
                }
                else
                {
                    string msg = direction switch
                    {
                        "First" => "هذا أول سجل.",
                        "Last"  => "هذا آخر سجل.",
                        "Next"  => "لا توجد سجلات تالية.",
                        _       => "لا توجد سجلات سابقة."
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

            var result = DC.DrawingsSubmittalList.GetBy(
                "IsDelete = 0 AND Num = @num ORDER BY Rev DESC",
                new { num = searchNum }).FirstOrDefault();

            if (result != null)
            {
                _id = result.Id;
                LoadRecord(_id);
            }
            else
            {
                XtraMessageBox.Show($"لم يتم العثور على مخطط برقم ({searchNum}).", "بحث",
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

        private void FrmDrawingApprovalRequest_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}