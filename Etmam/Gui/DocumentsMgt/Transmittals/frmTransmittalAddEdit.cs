using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmTransmittalAddEdit : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private int _id;
        private DrawingsSubmittalList? _record;

        public frmTransmittalAddEdit(int id = 0)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _id = id;
            LoadRecord(_id);

            bbiSave.ItemClick   += BbiSave_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiNew.ItemClick    += (s, e) => LoadRecord(0);
            bbiEmail.ItemClick  += BbiEmail_ItemClick;
        }

        // ── Load / Save / Delete ─────────────────────────────────────────────

        private void LoadRecord(int id)
        {
            _id = id;
            if (_id > 0)
            {
                _record = DC.DrawingsSubmittalList.Find(_id);
                if (_record == null)
                {
                    XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtNum.Text             = _record.Num?.ToString() ?? "";
                txtRev.Text             = _record.Rev?.ToString() ?? "";
                memDescription.Text     = _record.Description ?? "";
                cbeType.EditValue       = _record.Type;
                cbeCategory.EditValue   = _record.Category;
                coShift.EditValue       = _record.Status; // Mapping Status to coShift
                
                memoEdit2.Text          = _record.IssuedBy ?? "";
                memoEdit3.Text          = _record.ReviewedBy ?? "";
                memoEdit1.Text          = _record.Purpose ?? "";
                
                if (_record.PreparedDate.HasValue)
                    dtDate.EditValue = _record.PreparedDate;

                Text = $"تعديل إرسالية - {_record.Num}/{_record.Rev}";
                bbiDelete.Enabled = true;
            }
            else
            {
                _record = new DrawingsSubmittalList();
                _id = 0;
                txtNum.Text = "";
                txtRev.Text = "0";
                memDescription.Text = "";
                memoEdit1.Text = "";
                memoEdit2.Text = "";
                memoEdit3.Text = "";
                dtDate.EditValue = DateTime.Today;
                
                Text = "إرسالية جديدة";
                bbiDelete.Enabled = false;
            }
        }

        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveRecord();
        }

        private void SaveRecord()
        {
            if (string.IsNullOrWhiteSpace(memDescription.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال موضوع الإرسالية.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_record == null) _record = new DrawingsSubmittalList();

            _record.Num              = int.TryParse(txtNum.Text, out int num) ? num : (int?)null;
            _record.Rev              = int.TryParse(txtRev.Text, out int rev) ? rev : (int?)null;
            _record.Description      = memDescription.Text.Trim();
            _record.Type             = cbeType.EditValue?.ToString();
            _record.Category         = cbeCategory.EditValue?.ToString();
            _record.Status           = coShift.EditValue?.ToString();
            _record.IssuedBy         = memoEdit2.Text.Trim();
            _record.ReviewedBy       = memoEdit3.Text.Trim();
            _record.Purpose          = memoEdit1.Text.Trim();
            _record.PreparedDate     = dtDate.EditValue as DateTime?;
            _record.PrjId            = Session.SelectedProjectId;

            var handle = ShowOverlay();
            try
            {
                if (_id > 0)
                {
                    DC.DrawingsSubmittalList.Edit(_id, _record);
                }
                else
                {
                    _id = DC.DrawingsSubmittalList.Add(_record);
                    bbiDelete.Enabled = true;
                    Text = $"تعديل إرسالية - {_record.Num}/{_record.Rev}";
                }

                XtraMessageBox.Show("تم الحفظ بنجاح.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ أثناء الحفظ: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_id <= 0) return;

            if (XtraMessageBox.Show("هل أنت متأكد من حذف هذه الإرسالية؟", "تأكيد الحذف",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var handle = ShowOverlay();
                try
                {
                    DC.DrawingsSubmittalList.Delete(_id);
                    DialogResult = DialogResult.Abort;
                    Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("خطأ أثناء الحذف: " + ex.Message, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            }
        }

        private void BbiEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string num = txtNum.Text;
                string rev = txtRev.Text;
                string desc = memDescription.Text;
                string date = dtDate.Text;
                string sentTo = memoEdit2.Text;
                string copyTo = memoEdit3.Text;
                string type = cbeType.Text;

                string subject = $"إرسالية مستندات ({type}) - {num}/{rev}";
                string body = $"السلام عليكم ورحمة الله وبركاته،\n\n" +
                              $"يرجى التكرم بالعلم أنه قد تم إصدار إرسالية مستندات جديدة وفق التفاصيل التالية:\n\n" +
                              $"• رقم الإرسالية: {num}\n" +
                              $"• رقم المراجعة: {rev}\n" +
                              $"• التاريخ: {date}\n" +
                              $"• نوع الإرسالية: {type}\n" +
                              $"• البيان: {desc}\n" +
                              $"• مرسل إلى: {sentTo}\n" +
                              $"• صورة إلى: {copyTo}\n\n" +
                              $"يرجى مراجعة المرفقات (إن وجدت).\n\n" +
                              $"مع خالص التحية والتقدير،\n" +
                              $"نظام إتمام لإدارة المشاريع";

                // محاولة استخراج بريد إلكتروني من حقل "مرسل إلى"
                string to = "";
                if (sentTo.Contains("@"))
                {
                    var match = System.Text.RegularExpressions.Regex.Match(sentTo, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
                    if (match.Success) to = match.Value;
                }

                string mailto = $"mailto:{to}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";
                
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(mailto) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء محاولة فتح برنامج البريد: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
