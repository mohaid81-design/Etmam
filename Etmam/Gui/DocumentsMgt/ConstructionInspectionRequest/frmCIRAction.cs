using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Compact "consultant review action" dialog opened from ucCIR's colAction button —
    /// shows the request's reference fields read-only (mirrors frmCIRAddEdit's own fields) plus the
    /// CST review decision (status/comment/date). btnSaveClose records the decision (same
    /// status→OverallStatus mapping as frmCIRAddEdit.SaveRecord); btnCancelAction reverts a
    /// previously-recorded decision back to "قيد المراجعة". Both require PermNames.CIRConsultantAction,
    /// the same permission that gates the CST review fields on frmCIRAddEdit's own Log tab.</summary>
    public partial class frmCIRAction : DevExpress.XtraEditors.XtraForm
    {
        private static Data.DataContext DC => Data.DataContext.Shared;
        private readonly int _id;
        private ConstructionInspectionRequestList? _record;

        public frmCIRAction(int id = 0)
        {
            InitializeComponent();
            _id = id;
            SetupLookups();

            btnSaveClose.Click += BtnSaveClose_Click;
            btnCancelAction.Click += BtnCancelAction_Click;
        }

        private void SetupLookups()
        {
            lueProject.Properties.DataSource = DC.ProjectsList.GetBy("IsDelete = 0").ToList();
            lueProject.Properties.DisplayMember = "Name";
            lueProject.Properties.ValueMember = "Id";

            lueDiscipline.Properties.DataSource = DC.DisciplinesList.GetBy("IsDelete = 0").ToList();
            lueDiscipline.Properties.DisplayMember = "Name";
            lueDiscipline.Properties.ValueMember = "Id";
        }

        private void frmCIRAction_Load(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void LoadRecord()
        {
            _record = DC.ConstructionInspectionRequestList.Find(_id);
            if (_record == null)
            {
                XtraMessageBox.Show("لم يتم العثور على طلب الفحص المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lueProject.EditValue = _record.PrjId;
            txtRegisterNo.Text = _record.RegisterNo ?? "";
            lueDiscipline.EditValue = _record.DisciplineId;
            txtRev.Text = _record.Rev?.ToString() ?? "0";
            txtNum.Text = _record.Num?.ToString("D3") ?? "";
            dtPreparedDate.EditValue = _record.PreparedDate;
            dtSubmittedDate.EditValue = ParseDate(_record.SubmittedDate);

            cboCSTReviewStatus.EditValue = MapStatusToItem(_record.CSTReviewStatus);
            memCSTReviewComment.Text = _record.CSTReviewComment ?? "";
            dtCSTReviewDate.EditValue = ParseDate(_record.CSTReturnedDate);

            CIRPrinter.BuildPrintRecord(_record);
            Text = $"إجراء الإستشاري و الإعتماد - {CIRNumberFormatter.Format(_record)}";
        }

        private static string? MapStatusToItem(string? status) => status switch
        {
            CIRStatus.ReviewApproved => "يعتمد (A)",
            CIRStatus.ReviewApprovedWithComments => "يعتمد مع الملاحظات (B)",
            CIRStatus.ReviewReviseResubmit => "يراجع و يعاد تقديمه (C)",
            CIRStatus.ReviewRejected => "مرفوض (D)",
            _ => null,
        };

        private static string? MapItemToStatus(string? item) => item switch
        {
            "يعتمد (A)" => CIRStatus.ReviewApproved,
            "يعتمد مع الملاحظات (B)" => CIRStatus.ReviewApprovedWithComments,
            "يراجع و يعاد تقديمه (C)" => CIRStatus.ReviewReviseResubmit,
            "مرفوض (D)" => CIRStatus.ReviewRejected,
            _ => null,
        };

        private static DateTime? ParseDate(string? s) => DateTime.TryParse(s, out var d) ? d : null;

        private static bool HasConsultantActionPermission()
        {
            if (PermissionService.HasPermission(PermNames.CIRConsultantAction)) return true;

            XtraMessageBox.Show("ليس لديك صلاحية إجراء الاستشاري/المالك.", "غير مصرَّح",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void BtnSaveClose_Click(object sender, EventArgs e)
        {
            if (_record == null || !HasConsultantActionPermission()) return;

            string? status = MapItemToStatus(cboCSTReviewStatus.EditValue?.ToString());
            if (status == null)
            {
                XtraMessageBox.Show("الرجاء اختيار حالة المراجعة.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplyReview(status, memCSTReviewComment.Text.Trim(), dtCSTReviewDate.EditValue as DateTime?);
        }

        private void BtnCancelAction_Click(object sender, EventArgs e)
        {
            if (_record == null || !HasConsultantActionPermission()) return;

            if (XtraMessageBox.Show(
                    "هل أنت متأكد من التراجع عن إجراء المراجعة الحالي؟ ستعود حالة الطلب إلى \"قيد المراجعة\".",
                    "تأكيد التراجع", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            ApplyReview(CIRStatus.ReviewPending, "", null);
        }

        /// <summary>Records (or reverts) the CST review decision — same status→OverallStatus mapping as
        /// frmCIRAddEdit.SaveRecord (CIRStatus.MapReviewToOverallStatus), including the Pending state
        /// btnCancelAction reverts to.</summary>
        private void ApplyReview(string status, string comment, DateTime? reviewDate)
        {
            if (_record == null) return;

            _record.CSTReviewStatus = status;
            _record.CSTReviewComment = comment;
            _record.CSTReturnedDate = reviewDate?.ToString("yyyy-MM-dd");
            // تاريخ التقديم (dtSubmittedDate) قابل للتعديل من هذه الشاشة (خلافاً لبقية حقول المرجع
            // المعطَّلة أعلاه) — يُحفَظ هنا مهما كان زر الحفظ/الإلغاء المستخدَم، فيبقى متزامناً مع القيمة
            // المعروضة في كلا المسارين.
            _record.SubmittedDate = dtSubmittedDate.EditValue is DateTime submitted ? submitted.ToString("yyyy-MM-dd") : _record.SubmittedDate;

            _record.OverallStatus = CIRStatus.MapReviewToOverallStatus(status);

            _record.UpdateBy = Session.CurrentUser?.Id ?? 0;
            _record.UpdateDate = DateTime.Now;
            _record.UpdateMachine = Session.Machine;

            var handle = ShowOverlay();
            try
            {
                DC.ConstructionInspectionRequestList.Edit(_record.Id, _record);
                DialogResult = DialogResult.OK;
                Close();
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

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
