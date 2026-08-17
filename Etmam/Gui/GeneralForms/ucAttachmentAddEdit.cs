using Core;
using DevExpress.XtraEditors;
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
    /// Add / Open / Edit comment / Delete / Download.
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
        private List<AttachmentList> _attachments = new();
        private readonly Data.DataContext _dc;

        // ── Events ────────────────────────────────────────────────────────────
        /// <summary>
        /// Raised when the panel needs the parent form to save its record first (record not yet saved).
        /// The parent should save and return the new record ID, or 0/negative if save failed/cancelled.
        /// </summary>
        public event Func<int>? SaveRequired;

        // ── Constructor ───────────────────────────────────────────────────────
        public ucAttachmentAddEdit()
        {
            InitializeComponent();
            _dc = Data.DataContext.Shared;   // fully qualified to avoid implicit-using ambiguity
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
            RefreshGrid();
        }

        // ── Setup ─────────────────────────────────────────────────────────────

        private void WireEvents()
        {
            bbiAdd.ItemClick += (s, e) => OnAddAttachment();
            bbiDelete.ItemClick += (s, e) => OnDeleteAttachment();
            bbiOpen.ItemClick += (s, e) => OnOpenAttachment();
            bbiEdit.ItemClick += (s, e) => OnEditComment();
            bbiDownload.ItemClick += (s, e) => OnDownloadAttachment();

            gridView1.DoubleClick += (s, e) => OnOpenAttachment();
            gridView1.SelectionChanged += (s, e) => UpdateButtonStates();
        }

        // ── Data ──────────────────────────────────────────────────────────────

        private void RefreshGrid()
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
                _attachments = _dc.AttachmentList
                    .GetBy("EntityName = @name AND EntityRecordId = @id AND IsDelete = 0",
                        new { name = _entityName, id = _recordId })
                    .OrderByDescending(a => a.UploadDate)
                    .ToList();

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

        private void OnAddAttachment()
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

            foreach (string filePath in dlg.FileNames)
            {
                try
                {
                    string fileName = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filePath).TrimStart('.').ToLowerInvariant();
                    int sizeKB = AttachmentStorage.GetFileSizeKB(filePath);

                    // Copy to Attachments folder
                    string storedPath = AttachmentStorage.StoreFile(_entityName, _recordId, filePath);

                    var attachment = new AttachmentList
                    {
                        EntityName = _entityName,
                        EntityRecordId = _recordId,
                        FileName = fileName,
                        StoredPath = storedPath,
                        FileExtension = ext,
                        FileSizeKB = sizeKB,
                        UploadDate = DateTime.Now,
                        UploadedBy = Session.CurrentUser?.FullName ?? Session.CurrentUser?.UserName ?? "مجهول",
                        Comment = "",
                        CreatedDate = DateTime.Now,
                        CreatedBy = Session.CurrentUser?.Id ?? 1,
                        CreatedMachine = Session.Machine,
                        IsDelete = false
                    };

                    _dc.AttachmentList.Add(attachment);
                    addedCount++;
                }
                catch (Exception ex)
                {
                    errors.Add($"• {Path.GetFileName(filePath)}: {ex.Message}");
                }
            }

            RefreshGrid();

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

        private void OnEditComment()
        {
            var att = GetSelectedAttachment();
            if (att == null) return;

            var comment = XtraInputBox.Show("التعليق:", $"تعديل تعليق: {att.FileName}", att.Comment ?? "");
            if (comment == null) return; // user cancelled

            try
            {
                att.Comment = comment.ToString();
                att.UpdateDate = DateTime.Now;
                att.UpdateBy = Session.CurrentUser?.Id ?? 1;
                att.UpdateMachine = Session.Machine;
                _dc.AttachmentList.Edit(att.Id, att);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"خطأ أثناء حفظ التعليق:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteAttachment()
        {
            var att = GetSelectedAttachment();
            if (att == null) return;

            var result = XtraMessageBox.Show(
                $"هل تريد حذف المرفق:\n\"{att.FileName}\" ؟\n\nسيُحذف الملف نهائياً من القرص.",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes) return;

            try
            {
                // Soft-delete in DB
                att.IsDelete = true;
                att.DeletionDate = DateTime.Now;
                att.DeletionBy = Session.CurrentUser?.Id ?? 1;
                att.DeletionMachine = Session.Machine;
                _dc.AttachmentList.Edit(att.Id, att);

                // Delete from disk
                AttachmentStorage.DeleteFile(att.StoredPath);

                RefreshGrid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"خطأ في الحذف:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnOpenAttachment()
        {
            var att = GetSelectedAttachment();
            if (att == null) return;

            try
            {
                AttachmentStorage.OpenFile(att.StoredPath);
            }
            catch (FileNotFoundException)
            {
                XtraMessageBox.Show(
                    "لم يُعثر على الملف على القرص.\nربما تم نقله أو حذفه يدوياً.",
                    "ملف غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"لا يمكن فتح الملف:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDownloadAttachment()
        {
            var att = GetSelectedAttachment();
            if (att == null) return;

            using var dlg = new FolderBrowserDialog
            {
                Description = "اختر مجلد التنزيل",
                UseDescriptionForTitle = true
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                AttachmentStorage.DownloadFile(att.StoredPath!, att.FileName!, dlg.SelectedPath);

                XtraMessageBox.Show(
                    $"تم تنزيل الملف بنجاح إلى:\n{dlg.SelectedPath}",
                    "تنزيل ناجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FileNotFoundException)
            {
                XtraMessageBox.Show(
                    "لم يُعثر على الملف على القرص.",
                    "ملف غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"خطأ في التنزيل:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private AttachmentList? GetSelectedAttachment()
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
    }
}
