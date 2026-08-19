using System;
using System.Collections.Generic;
using System.IO;
using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Outcome of MigrateLocalAttachmentsToSharedFolder: how many rows fell into each bucket.
    /// </summary>
    public sealed class AttachmentMigrationResult
    {
        public int Migrated { get; set; }
        public int AlreadyShared { get; set; }
        public int NotFoundLocally { get; set; }
        public int Failed { get; set; }
        public List<string> Errors { get; } = new();
    }

    /// <summary>Outcome of MigrateFilesToDatabase: how many rows fell into each bucket.</summary>
    public sealed class AttachmentDbMigrationResult
    {
        public int Migrated { get; set; }
        public int AlreadyInDatabase { get; set; }
        public int NotFoundOnDisk { get; set; }
        public int Failed { get; set; }
        public List<string> Errors { get; } = new();
    }

    /// <summary>
    /// Manages physical storage of drawing attachment files.
    /// Root folder: the shared network path configured in SettingsForm → التقنية → مسارات التخزين
    /// (AttachmentStorageSettings), so every user/machine on the same database can reach files
    /// uploaded by anyone else. Falls back to the old per-machine %AppData%\Etmam\Attachments\
    /// when no shared folder has been configured yet, so existing installs keep working unchanged.
    /// </summary>
    public static class AttachmentStorage
    {
        // ── Root folder ───────────────────────────────────────────────────────

        private static string RootFolder
        {
            get
            {
                string? shared = AttachmentStorageSettings.GetFolderPath(DataContext.Shared);
                if (!string.IsNullOrWhiteSpace(shared))
                    return shared;

                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Etmam",
                    "Attachments");
            }
        }

        /// <summary>
        /// Returns the folder for a specific drawing ID,
        /// creating it if it does not exist.
        /// </summary>
        public static string GetDrawingFolder(int drawingId)
        {
            var folder = Path.Combine(RootFolder, $"Drawing_{drawingId}");
            Directory.CreateDirectory(folder);
            return folder;
        }

        /// <summary>
        /// Copies a source file into the drawing's attachment folder.
        /// Returns the stored path.
        /// </summary>
        public static string StoreFile(int drawingId, string sourceFilePath)
        {
            string folder   = GetDrawingFolder(drawingId);
            string original = Path.GetFileName(sourceFilePath);
            // Prefix with guid to avoid name collisions
            string stored   = Path.Combine(folder, $"{Guid.NewGuid():N}_{original}");
            File.Copy(sourceFilePath, stored, overwrite: false);
            return stored;
        }

        /// <summary>
        /// Returns the attachment folder for any entity record (e.g. "PurchaseRequestList", 12),
        /// creating it if it does not exist. Used by the generic ucAttachmentAddEdit control.
        /// </summary>
        public static string GetFolder(string entityName, int recordId)
        {
            var folder = Path.Combine(RootFolder, $"{entityName}_{recordId}");
            Directory.CreateDirectory(folder);
            return folder;
        }

        /// <summary>
        /// Copies a source file into a generic entity record's attachment folder.
        /// Returns the stored path.
        /// </summary>
        public static string StoreFile(string entityName, int recordId, string sourceFilePath)
        {
            string folder   = GetFolder(entityName, recordId);
            string original = Path.GetFileName(sourceFilePath);
            // Prefix with guid to avoid name collisions
            string stored   = Path.Combine(folder, $"{Guid.NewGuid():N}_{original}");
            File.Copy(sourceFilePath, stored, overwrite: false);
            return stored;
        }

        /// <summary>
        /// Deletes a stored attachment file from disk.
        /// Silently does nothing if the file doesn't exist.
        /// </summary>
        public static void DeleteFile(string? storedPath)
        {
            if (!string.IsNullOrWhiteSpace(storedPath) && File.Exists(storedPath))
            {
                try { File.Delete(storedPath); }
                catch { /* ignore locks */ }
            }
        }

        /// <summary>
        /// Opens the file with the system's default application.
        /// </summary>
        public static void OpenFile(string? storedPath)
        {
            if (string.IsNullOrWhiteSpace(storedPath) || !File.Exists(storedPath))
                throw new FileNotFoundException("الملف غير موجود على القرص.", storedPath ?? "");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName        = storedPath,
                UseShellExecute = true
            });
        }

        /// <summary>
        /// Opens an attachment stored as database bytes (FileData) with the system's default
        /// application — the shell needs an actual file path to pick the right app and preserve the
        /// original extension, so this writes the bytes to a per-attachment temp file first (overwritten
        /// on every open, since FileData itself never changes after upload) and opens that. Falls back to
        /// the legacy disk-path flow for attachments uploaded before FileData existed.
        /// </summary>
        public static void OpenFile(AttachmentList att)
        {
            if (att.FileData is not { Length: > 0 })
            {
                OpenFile(att.StoredPath);
                return;
            }

            OpenBytes(att.Id, att.FileData, att.FileName ?? "مرفق");
        }

        /// <summary>DrawingAttachment counterpart to OpenFile(AttachmentList) — same DB-bytes-to-temp-file
        /// approach, kept in a separate temp subfolder ("Drawing_{id}_...") since DrawingAttachment.Id
        /// and AttachmentList.Id come from different tables and can collide.</summary>
        public static void OpenFile(DrawingAttachment att)
        {
            if (att.FileData is not { Length: > 0 })
            {
                OpenFile(att.StoredPath);
                return;
            }

            OpenBytes(att.Id, att.FileData, att.FileName ?? "مرفق", "Drawing_");
        }

        private static void OpenBytes(int attachmentId, byte[] data, string fileName, string prefix = "")
        {
            string tempPath = WriteToTempFile(attachmentId, data, fileName, prefix);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName        = tempPath,
                UseShellExecute = true
            });
        }

        private static string WriteToTempFile(int attachmentId, byte[] data, string fileName, string prefix = "")
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "EtmamAttachments");
            Directory.CreateDirectory(tempDir);
            string tempPath = Path.Combine(tempDir, $"{prefix}{attachmentId}_{fileName}");
            File.WriteAllBytes(tempPath, data);
            return tempPath;
        }

        /// <summary>
        /// Copies a stored attachment to a user-chosen location.
        /// </summary>
        public static void DownloadFile(string storedPath, string originalFileName, string targetFolder)
        {
            if (!File.Exists(storedPath))
                throw new FileNotFoundException("الملف غير موجود على القرص.", storedPath);

            string dest = UniqueDestination(targetFolder, originalFileName);
            File.Copy(storedPath, dest);
        }

        /// <summary>Database-bytes counterpart to DownloadFile(string,string,string) — writes FileData
        /// directly instead of copying from disk. Falls back to the legacy disk-path flow for
        /// attachments uploaded before FileData existed.</summary>
        public static void DownloadFile(AttachmentList att, string targetFolder)
        {
            if (att.FileData is not { Length: > 0 })
            {
                DownloadFile(att.StoredPath!, att.FileName!, targetFolder);
                return;
            }

            string dest = UniqueDestination(targetFolder, att.FileName ?? "مرفق");
            File.WriteAllBytes(dest, att.FileData);
        }

        /// <summary>DrawingAttachment counterpart to DownloadFile(AttachmentList,string).</summary>
        public static void DownloadFile(DrawingAttachment att, string targetFolder)
        {
            if (att.FileData is not { Length: > 0 })
            {
                DownloadFile(att.StoredPath!, att.FileName!, targetFolder);
                return;
            }

            string dest = UniqueDestination(targetFolder, att.FileName ?? "مرفق");
            File.WriteAllBytes(dest, att.FileData);
        }

        /// <summary>Picks a non-colliding destination path in targetFolder for fileName, appending
        /// "_1", "_2", ... before the extension if a file with that name already exists there.</summary>
        private static string UniqueDestination(string targetFolder, string fileName)
        {
            string dest = Path.Combine(targetFolder, fileName);
            int idx = 1;
            while (File.Exists(dest))
                dest = Path.Combine(targetFolder, $"{Path.GetFileNameWithoutExtension(fileName)}_{idx++}{Path.GetExtension(fileName)}");
            return dest;
        }

        /// <summary>
        /// Moves attachment files that physically exist on THIS machine but whose StoredPath still
        /// points at the old local per-machine folder into the configured shared network folder,
        /// then rewrites StoredPath in the database. Rows whose file isn't found on this machine are
        /// left untouched (StoredPath unchanged) — that file lives on whichever machine originally
        /// uploaded it, and this same migration needs to run there too. Throws if no shared folder
        /// is configured yet (nothing to migrate to).
        /// </summary>
        public static AttachmentMigrationResult MigrateLocalAttachmentsToSharedFolder(DataContext dc)
        {
            string? sharedRoot = AttachmentStorageSettings.GetFolderPath(dc);
            if (string.IsNullOrWhiteSpace(sharedRoot))
                throw new InvalidOperationException("لم يتم تحديد مجلد مشترك بعد. احفظ المسار أولاً.");

            string normalizedRoot = sharedRoot.TrimEnd('\\', '/');
            var result = new AttachmentMigrationResult();

            foreach (var att in dc.AttachmentList.GetAll())
            {
                MigrateRow(
                    att.StoredPath, normalizedRoot,
                    () => GetFolder(att.EntityName ?? "Unknown", att.EntityRecordId),
                    newPath => { att.StoredPath = newPath; dc.AttachmentList.Edit(att.Id, att); },
                    att.FileName, result);
            }

            foreach (var att in dc.DrawingAttachment.GetAll())
            {
                MigrateRow(
                    att.StoredPath, normalizedRoot,
                    () => GetDrawingFolder(att.DrawingId),
                    newPath => { att.StoredPath = newPath; dc.DrawingAttachment.Edit(att.Id, att); },
                    att.FileName, result);
            }

            return result;
        }

        private static void MigrateRow(
            string? storedPath, string normalizedRoot, Func<string> getTargetFolder,
            Action<string> saveNewPath, string? displayName, AttachmentMigrationResult result)
        {
            if (string.IsNullOrWhiteSpace(storedPath))
                return;

            if (storedPath.TrimEnd('\\', '/').StartsWith(normalizedRoot, StringComparison.OrdinalIgnoreCase))
            {
                result.AlreadyShared++;
                return;
            }

            if (!File.Exists(storedPath))
            {
                result.NotFoundLocally++;
                return;
            }

            try
            {
                string targetFolder = getTargetFolder();
                string dest = Path.Combine(targetFolder, Path.GetFileName(storedPath));

                int idx = 1;
                while (File.Exists(dest))
                    dest = Path.Combine(targetFolder, $"{Path.GetFileNameWithoutExtension(storedPath)}_{idx++}{Path.GetExtension(storedPath)}");

                File.Copy(storedPath, dest);
                saveNewPath(dest);

                try { File.Delete(storedPath); }
                catch { /* best-effort cleanup; migration already succeeded regardless */ }

                result.Migrated++;
            }
            catch (Exception ex)
            {
                result.Failed++;
                result.Errors.Add($"{displayName ?? storedPath}: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads each attachment's bytes from its legacy StoredPath on disk and saves them into FileData
        /// in the database, then clears StoredPath — the reverse of the old disk-storage design, now that
        /// new uploads go straight into FileData (see AttachmentList/DrawingAttachment). Rows whose file
        /// can't be found on THIS machine are left untouched (StoredPath unchanged) — that file lives on
        /// whichever machine/share it was uploaded to (local %AppData% or the old shared network folder),
        /// and this same migration needs to run wherever that path is actually reachable. Rows that
        /// already have FileData (uploaded after the switch to database storage) are skipped.
        /// </summary>
        public static AttachmentDbMigrationResult MigrateFilesToDatabase(DataContext dc)
        {
            var result = new AttachmentDbMigrationResult();

            foreach (var att in dc.AttachmentList.GetAll())
            {
                MigrateRowToDatabase(att.StoredPath, att.FileData,
                    data => { att.FileData = data; att.StoredPath = null; dc.AttachmentList.Edit(att.Id, att); },
                    att.FileName, result);
            }

            foreach (var att in dc.DrawingAttachment.GetAll())
            {
                MigrateRowToDatabase(att.StoredPath, att.FileData,
                    data => { att.FileData = data; att.StoredPath = null; dc.DrawingAttachment.Edit(att.Id, att); },
                    att.FileName, result);
            }

            return result;
        }

        private static void MigrateRowToDatabase(
            string? storedPath, byte[]? existingData, Action<byte[]> saveData,
            string? displayName, AttachmentDbMigrationResult result)
        {
            if (existingData is { Length: > 0 })
            {
                result.AlreadyInDatabase++;
                return;
            }

            if (string.IsNullOrWhiteSpace(storedPath) || !File.Exists(storedPath))
            {
                result.NotFoundOnDisk++;
                return;
            }

            try
            {
                saveData(File.ReadAllBytes(storedPath));
                result.Migrated++;
            }
            catch (Exception ex)
            {
                result.Failed++;
                result.Errors.Add($"{displayName ?? storedPath}: {ex.Message}");
            }
        }

        /// <summary>
        /// Returns file size in KB from a source path.
        /// </summary>
        public static int GetFileSizeKB(string path)
        {
            var info = new FileInfo(path);
            return info.Exists ? (int)Math.Max(1, info.Length / 1024) : 0;
        }

        /// <summary>Same as GetFileSizeKB(string), for bytes already read into memory.</summary>
        public static int GetFileSizeKB(byte[] data) => data.Length > 0 ? (int)Math.Max(1, data.Length / 1024) : 0;

        /// <summary>
        /// Maps file extension to a friendly type label.
        /// </summary>
        public static string GetFileTypeLabel(string? ext)
        {
            return (ext?.ToLowerInvariant()) switch
            {
                "pdf"  => "PDF",
                "dwg"  => "AutoCAD DWG",
                "dxf"  => "AutoCAD DXF",
                "xlsx" => "Excel",
                "xls"  => "Excel",
                "docx" => "Word",
                "doc"  => "Word",
                "pptx" => "PowerPoint",
                "jpg" or "jpeg" => "صورة JPEG",
                "png"  => "صورة PNG",
                "zip"  => "ZIP",
                "rar"  => "RAR",
                _      => (ext?.ToUpperInvariant() ?? "ملف")
            };
        }
    }
}
