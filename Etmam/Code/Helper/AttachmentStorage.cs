using System;
using System.IO;

namespace Etmam
{
    /// <summary>
    /// Manages physical storage of drawing attachment files.
    /// Root folder: %AppData%\Etmam\Attachments\Drawing_{DrawingId}\
    /// </summary>
    public static class AttachmentStorage
    {
        // ── Root folder ───────────────────────────────────────────────────────

        private static readonly string RootFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Etmam",
            "Attachments");

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
        /// Copies a stored attachment to a user-chosen location.
        /// </summary>
        public static void DownloadFile(string storedPath, string originalFileName, string targetFolder)
        {
            if (!File.Exists(storedPath))
                throw new FileNotFoundException("الملف غير موجود على القرص.", storedPath);

            string dest = Path.Combine(targetFolder, originalFileName);
            // Avoid overwriting: append index if exists
            int idx = 1;
            while (File.Exists(dest))
                dest = Path.Combine(targetFolder, $"{Path.GetFileNameWithoutExtension(originalFileName)}_{idx++}{Path.GetExtension(originalFileName)}");

            File.Copy(storedPath, dest);
        }

        /// <summary>
        /// Returns file size in KB from a source path.
        /// </summary>
        public static int GetFileSizeKB(string path)
        {
            var info = new FileInfo(path);
            return info.Exists ? (int)Math.Max(1, info.Length / 1024) : 0;
        }

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
