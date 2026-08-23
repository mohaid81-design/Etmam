using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Etmam
{
    /// <summary>
    /// Reusable attachment panel that any Add/Edit form can embed to let users attach files to
    /// its record. Shows files linked to (EntityName, EntityRecordId) with toolbar actions:
    /// Add / Open / Edit comment / Delete / Download. API-backed (Api/Controllers/AttachmentsController.cs)
    /// rather than a direct DB connection - see docs/api-migration-checklist.md.
    ///
    /// Usage from a parent Add/Edit form:
    ///   ucAttachments.SaveRequired += SaveAndReturnId;   // ask the parent to save first if the record is new
    ///   ucAttachments.LoadFor("PurchaseRequestList", prId);
    /// </summary>
    public partial class ucAttachmentAddEdit : BaseUserControl
    {
        // ── State ─────────────────────────────────────────────────────────────
        private string _entityName = "";
        private int _recordId = 0;
        private List<AttachmentItem> _attachments = new();

        // ── Events ────────────────────────────────────────────────────────────
        /// <summary>
        /// Raised when the panel needs the parent form to save its record first (record not yet saved).
        /// The parent should save and return the new record ID, or 0/negative if save failed/cancelled.
        /// </summary>
        public event Func<int>? SaveRequired;

        /// <summary>Raised after the attachment set actually changes (file added or deleted) — lets a
        /// parent form react, e.g. frmPurchaseRequestAddEdit re-runs PurchaseRequestPrinter.ExportApprovedCopy
        /// so a previously auto-exported approved-PR folder stays in sync with attachments added/removed
        /// after approval. Not raised for comment edits, which don't affect the exported files.</summary>
        public event Action? AttachmentsChanged;

        // ── Constructor ───────────────────────────────────────────────────────
        public ucAttachmentAddEdit()
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
        }

        // ── Public API ────────────────────────────────────────────────────────

        /// <summary>
        /// Called by the parent form after saving its record. Loads the attachments linked to it.
        /// entityName should match the Core.Tables class name of the parent record (e.g. "PurchaseRequestList").
        /// </summary>
        public void LoadFor(string entityName, int recordId)
        {
            _entityName = entityName;
            _recordId = recordId;
            // Fire-and-forget: LoadFor's callers are sync (form Load handlers etc.) and this
            // control's public signature predates the move to an async API call - RefreshGrid
            // reports its own errors via XtraMessageBox, so there's nothing more for a caller to
            // await or check here.
            _ = RefreshGrid();
        }

        // ── Setup ─────────────────────────────────────────────────────────────

        private void WireEvents()
        {
            bbiAdd.ItemClick += async (s, e) => await OnAddAttachment();
            bbiDelete.ItemClick += async (s, e) => await OnDeleteAttachment();
            bbiOpen.ItemClick += async (s, e) => await OnOpenAttachment();
            bbiEdit.ItemClick += async (s, e) => await OnEditComment();
            bbiDownload.ItemClick += async (s, e) => await OnDownloadAttachment();

            gridView1.DoubleClick += async (s, e) => await OnOpenAttachment();
            gridView1.SelectionChanged += (s, e) => UpdateButtonStates();
        }

        // ── Data ──────────────────────────────────────────────────────────────

        private async Task RefreshGrid()
        {
            if (_recordId <= 0 || string.IsNullOrEmpty(_entityName))
            {
                _attachments = new();
                gridControl1.DataSource = null;
                UpdateCount();
                return;
            }

            try
            {
                _attachments = await ApiClient.GetAttachmentsAsync(_entityName, _recordId);

                gridControl1.DataSource = _attachments;
                gridView1.RefreshData();
                UpdateCount();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"خطأ في تحميل المرفقات:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Commands ──────────────────────────────────────────────────────────

        private async Task OnAddAttachment()
        {
            // If the parent record isn't saved yet, ask the parent to save first
            if (_recordId <= 0)
            {
                if (SaveRequired == null)
                {
                    XtraMessageBox.Show(
                        "يرجى حفظ السجل أولاً قبل إضافة المرفقات.",
                        "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int newId = SaveRequired.Invoke();
                if (newId <= 0)
                    return; // Parent save failed or was cancelled

                _recordId = newId;
            }

            using var dlg = new OpenFileDialog
            {
                Title = "اختر ملف أو أكثر لإرفاقه",
                Multiselect = true,
                Filter = "ملفات مدعومة|*.pdf;*.dwg;*.dxf;*.xlsx;*.xls;*.docx;*.doc;*.pptx;*.jpg;*.jpeg;*.png;*.zip;*.rar|كل الملفات|*.*"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            int addedCount = 0;
            var errors = new List<string>();

            var handle = ShowOverlay();
            try
            {
                foreach (string filePath in dlg.FileNames)
                {
                    try
                    {
                        await ApiClient.UploadAttachmentAsync(_entityName, _recordId, filePath);
                        addedCount++;
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"• {Path.GetFileName(filePath)}: {ex.Message}");
                    }
                }

                await RefreshGrid();
                if (addedCount > 0) AttachmentsChanged?.Invoke();
            }
            finally
            {
                CloseOverlay(handle);
            }

            if (addedCount > 0)
            {
                string msg = $"تمت إضافة {addedCount} مرفق بنجاح.";
                if (errors.Count > 0)
                    msg += $"\n\nفشل رفع {errors.Count} ملف:\n{string.Join("\n", errors)}";

                XtraMessageBox.Show(msg, "إضافة مرفقات",
                    MessageBoxButtons.OK,
                    errors.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
            else if (errors.Count > 0)
            {
                XtraMessageBox.Show(
                    $"فشل رفع جميع الملفات:\n{string.Join("\n", errors)}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task OnEditComment()
        {
            var att = GetSelectedAttachment();
            if (att == null) return;

            var comment = XtraInputBox.Show("التعليق:", $"تعديل تعليق: {att.FileName}", att.Comment ?? "");
            if (comment == null) return; // user cancelled

            var handle = ShowOverlay();
            try
            {
                await ApiClient.UpdateAttachmentCommentAsync(att.Id, comment.ToString());
                await RefreshGrid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"خطأ أثناء حفظ التعليق:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private async Task OnDeleteAttachment()
        {
            var att = GetSelectedAttachment();
            if (att == null) return;

            var result = XtraMessageBox.Show(
                $"هل تريد حذف المرفق:\n\"{att.FileName}\" ؟\n\nسيُحذف المرفق نهائياً.",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes) return;

            var handle = ShowOverlay();
            try
            {
                // Soft-delete server-side. Legacy on-disk StoredPath cleanup (AttachmentStorage.DeleteFile)
                // isn't attempted here - new uploads never populate StoredPath, only very old rows
                // predating DB-blob storage would leave an orphaned file, a storage-cleanup concern
                // rather than a correctness one.
                await ApiClient.DeleteAttachmentAsync(att.Id);

                await RefreshGrid();
                AttachmentsChanged?.Invoke();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"خطأ في الحذف:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private async Task OnOpenAttachment()
        {
            var att = GetSelectedAttachment();
            if (att == null) return;

            var handle = ShowOverlay();
            try
            {
                var data = await ApiClient.DownloadAttachmentBytesAsync(att.Id);
                AttachmentStorage.OpenBytes(att.Id, data, att.FileName ?? "مرفق");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"لا يمكن فتح الملف:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private async Task OnDownloadAttachment()
        {
            var att = GetSelectedAttachment();
            if (att == null) return;

            using var dlg = new FolderBrowserDialog
            {
                Description = "اختر مجلد التنزيل",
                UseDescriptionForTitle = true
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            var handle = ShowOverlay();
            try
            {
                var data = await ApiClient.DownloadAttachmentBytesAsync(att.Id);
                AttachmentStorage.DownloadBytes(att.FileName ?? "مرفق", data, dlg.SelectedPath);

                XtraMessageBox.Show(
                    $"تم تنزيل الملف بنجاح إلى:\n{dlg.SelectedPath}",
                    "تنزيل ناجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"خطأ في التنزيل:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private AttachmentItem? GetSelectedAttachment()
        {
            int rowHandle = gridView1.FocusedRowHandle;
            if (rowHandle < 0) return null;

            int dataIndex = gridView1.GetDataSourceRowIndex(rowHandle);
            if (dataIndex < 0 || dataIndex >= _attachments.Count) return null;

            return _attachments[dataIndex];
        }

        private void UpdateCount()
        {
            barStaticItem1.Caption = $"المرفقات: {_attachments.Count}";
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = gridView1.FocusedRowHandle >= 0 && _attachments.Count > 0;
            bbiDelete.Enabled = hasSelection;
            bbiOpen.Enabled = hasSelection;
            bbiEdit.Enabled = hasSelection;
            bbiDownload.Enabled = hasSelection;
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
