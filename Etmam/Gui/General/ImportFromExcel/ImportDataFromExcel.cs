using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using ExcelDataReader;

namespace Etmam.Gui.General.ImportFromExcel
{
    public partial class ImportDataFromExcel : DevExpress.XtraEditors.XtraForm
    {
        protected Data.DataContext dc => Data.DataContext.Shared;

        private DataSet? _workbook;
        private DataTable? _selectedSheet;
        private readonly BindingList<ImportedItemRow> _rows = new();
        private List<Core.ItemsList> _existingItems = new();

        public ImportDataFromExcel()
        {
            InitializeComponent();

            LoadLookups();

            btnOpenFileDialog.Click += BtnOpenFileDialog_Click;
            lookUpEditSheet.EditValueChanged += LookUpEditSheet_EditValueChanged;
            btnImport.Click += BtnImport_Click;
            btnSaveToDb.Click += BtnSaveToDb_Click;
            checkEdit1.CheckedChanged += (s, e) => UpdateConditionControlsEnabled();
            radioButtonAll.CheckedChanged += (s, e) => UpdateRangeControlsEnabled();
            radioButtonRows.CheckedChanged += (s, e) => UpdateRangeControlsEnabled();

            UpdateConditionControlsEnabled();
            UpdateRangeControlsEnabled();

            gridControl1.DataSource = _rows;
        }

        // ─── Lookups & Initial State ──────────────────────────────────────────
        private void LoadLookups()
        {
            var units = dc.Units.GetBy("IsDelete = 0");
            repositoryItemLookUpEditUnit.DataSource = units;
            repositoryItemLookUpEditUnit.ValueMember = "Id";
            repositoryItemLookUpEditUnit.DisplayMember = "Abbreviation";

            var categories = dc.ItemCategory.GetBy("IsDelete = 0");
            repositoryItemLookUpEditCategory.DataSource = categories;
            repositoryItemLookUpEditCategory.ValueMember = "Id";
            repositoryItemLookUpEditCategory.DisplayMember = "Name";

            _existingItems = dc.ItemsList.GetBy("IsDelete = 0");
        }

        private void UpdateConditionControlsEnabled()
        {
            bool on = checkEdit1.Checked;
            lookUpEditCondition.Enabled = on;
            coCondtion.Enabled = on;
            txtCondition.Enabled = on;
        }

        private void UpdateRangeControlsEnabled()
        {
            bool rowsMode = radioButtonRows.Checked;
            textEditFrom.Enabled = rowsMode;
            textEditTo.Enabled = rowsMode;
        }

        // ─── File & Sheet Selection ───────────────────────────────────────────
        private void BtnOpenFileDialog_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                _workbook = ReadWorkbook(ofd.FileName);
                txtFileName.Text = ofd.FileName;

                var sheetNames = _workbook.Tables.Cast<DataTable>().Select(t => t.TableName).ToList();
                BindColumnPicker(lookUpEditSheet, sheetNames);
                if (sheetNames.Count > 0)
                    lookUpEditSheet.EditValue = sheetNames[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في قراءة ملف الإكسل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static DataSet ReadWorkbook(string path)
        {
            // مطلوب لقراءة ملفات Excel بترميزات غير Unicode (خصوصاً xls القديمة)
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            return reader.AsDataSet(new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true }
            });
        }

        private void LookUpEditSheet_EditValueChanged(object? sender, EventArgs e)
        {
            var sheetName = lookUpEditSheet.EditValue?.ToString();
            _selectedSheet = (_workbook != null && !string.IsNullOrEmpty(sheetName) && _workbook.Tables.Contains(sheetName))
                ? _workbook.Tables[sheetName]
                : null;

            PopulateColumnPickers();
        }

        private void PopulateColumnPickers()
        {
            var columns = _selectedSheet?.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList() ?? new List<string>();

            BindColumnPicker(lookUpEditItem, columns);
            BindColumnPicker(lookUpEditQty, columns);      // يُستخدم هنا لاختيار عمود "الوحدة"
            BindColumnPicker(lookUpEditRate, columns);     // يُستخدم هنا لاختيار عمود "التصنيف"
            BindColumnPicker(lookUpEditCondition, columns);
        }

        // يربط LookUpEdit بقائمة أسماء أعمدة الإكسل. DevExpress لا يقبل اسم عضو فارغ ("") كـ FieldName،
        // لذلك نغلّف كل اسم عمود في كائن صغير له خاصية Name بدلاً من ربط قائمة نصوص مباشرة.
        private static void BindColumnPicker(DevExpress.XtraEditors.LookUpEdit edit, List<string> columns)
        {
            var items = columns.Select(c => new ColumnPickerItem(c)).ToList();
            edit.Properties.DataSource = items;
            edit.Properties.DisplayMember = "Name";
            edit.Properties.ValueMember = "Name";
            edit.Properties.Columns.Clear();
            edit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "اسم العمود"));
            edit.EditValue = null;
        }

        private sealed class ColumnPickerItem
        {
            public ColumnPickerItem(string name) => Name = name;
            public string Name { get; }
            public override string ToString() => Name;
        }

        // ─── Import: Excel → Review Grid ──────────────────────────────────────
        private void BtnImport_Click(object? sender, EventArgs e)
        {
            if (_selectedSheet == null)
            {
                XtraMessageBox.Show("يرجى تحديد ملف الإكسل والجدول (Sheet) أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itemCol = lookUpEditItem.EditValue?.ToString();
            if (string.IsNullOrEmpty(itemCol))
            {
                XtraMessageBox.Show("يرجى تحديد عمود إسم الصنف.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var unitCol = lookUpEditQty.EditValue?.ToString();
            var categoryCol = lookUpEditRate.EditValue?.ToString();

            var sourceRows = _selectedSheet.Rows.Cast<DataRow>().ToList();

            if (radioButtonRows.Checked)
            {
                int from = Math.Max(1, ParseIntOrDefault(textEditFrom.Text, 1));
                int to = Math.Min(sourceRows.Count, ParseIntOrDefault(textEditTo.Text, sourceRows.Count));
                sourceRows = to >= from ? sourceRows.Skip(from - 1).Take(to - from + 1).ToList() : new List<DataRow>();
            }

            if (checkEdit1.Checked && lookUpEditCondition.EditValue != null && coCondtion.EditValue != null)
            {
                var condCol = lookUpEditCondition.EditValue.ToString()!;
                var op = coCondtion.EditValue.ToString()!;
                var condVal = txtCondition.Text ?? "";
                sourceRows = sourceRows.Where(r => MatchesCondition(r, condCol, op, condVal)).ToList();
            }

            var units = dc.Units.GetBy("IsDelete = 0");
            var categories = dc.ItemCategory.GetBy("IsDelete = 0");

            _rows.RaiseListChangedEvents = false;
            _rows.Clear();
            foreach (var row in sourceRows)
            {
                var name = GetString(row, itemCol);
                if (string.IsNullOrWhiteSpace(name)) continue;

                var importRow = new ImportedItemRow
                {
                    AutoCode = true,
                    ItemName = name.Trim(),
                    UnitId = FindIdByText(units, u => u.Abbreviation, GetString(row, unitCol)),
                    CategoryId = FindIdByText(categories, c => c.Name, GetString(row, categoryCol))
                };

                EvaluateDuplicate(importRow);
                _rows.Add(importRow);
            }
            _rows.RaiseListChangedEvents = true;
            _rows.ResetBindings();

            XtraMessageBox.Show($"تم استيراد {_rows.Count} صف من ملف الإكسل. يرجى مراجعة البيانات قبل الحفظ.",
                "استيراد", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static int ParseIntOrDefault(string? text, int fallback) => int.TryParse(text, out var n) ? n : fallback;

        private static string? GetString(DataRow row, string? columnName)
        {
            if (string.IsNullOrEmpty(columnName) || !row.Table.Columns.Contains(columnName)) return null;
            var val = row[columnName];
            return val == DBNull.Value ? null : val.ToString();
        }

        private static int? FindIdByText<T>(IEnumerable<T> items, Func<T, string?> nameSelector, string? text) where T : IBaseEntity
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            var normalized = text.Trim();
            var match = items.FirstOrDefault(i => string.Equals(nameSelector(i)?.Trim(), normalized, StringComparison.OrdinalIgnoreCase));
            return match?.Id;
        }

        private static bool MatchesCondition(DataRow row, string columnName, string op, string value)
        {
            if (string.IsNullOrEmpty(columnName) || !row.Table.Columns.Contains(columnName)) return true;
            var cellValue = row[columnName]?.ToString() ?? "";

            if (double.TryParse(cellValue, out var cellNum) && double.TryParse(value, out var condNum))
            {
                return op switch
                {
                    ">" => cellNum > condNum,
                    "<" => cellNum < condNum,
                    "=" => cellNum == condNum,
                    "<>" => cellNum != condNum,
                    _ => true
                };
            }

            return op switch
            {
                ">" => string.Compare(cellValue, value, StringComparison.OrdinalIgnoreCase) > 0,
                "<" => string.Compare(cellValue, value, StringComparison.OrdinalIgnoreCase) < 0,
                "=" => string.Equals(cellValue, value, StringComparison.OrdinalIgnoreCase),
                "<>" => !string.Equals(cellValue, value, StringComparison.OrdinalIgnoreCase),
                "يبدأ ب" => cellValue.StartsWith(value, StringComparison.OrdinalIgnoreCase),
                "يحتوي على" => cellValue.Contains(value, StringComparison.OrdinalIgnoreCase),
                "ينتهي ب" => cellValue.EndsWith(value, StringComparison.OrdinalIgnoreCase),
                _ => true
            };
        }

        // ─── Duplicate / Similarity Detection ─────────────────────────────────
        private void EvaluateDuplicate(ImportedItemRow row)
        {
            var normalizedName = NormalizeArabicText(row.ItemName);

            var exactMatch = _existingItems.FirstOrDefault(i => NormalizeArabicText(i.Name) == normalizedName);
            if (exactMatch != null)
            {
                row.Status = "مكرر - موجود بالفعل";
                row.SimilarItems = exactMatch.Name;
                return;
            }

            var similar = _existingItems
                .Select(i => new { i.Name, Normalized = NormalizeArabicText(i.Name) })
                .Where(x => IsSimilar(normalizedName, x.Normalized))
                .Select(x => x.Name)
                .Take(3)
                .ToList();

            if (similar.Count > 0)
            {
                row.Status = "يشبه صنف موجود";
                row.SimilarItems = string.Join(" ، ", similar);
            }
            else
            {
                row.Status = "جديد";
                row.SimilarItems = "";
            }
        }

        private static bool IsSimilar(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b)) return false;
            if (a.Length >= 3 && (a.Contains(b) || b.Contains(a))) return true;
            return SimilarityScore(a, b) >= 0.75;
        }

        private static double SimilarityScore(string a, string b)
        {
            int maxLen = Math.Max(a.Length, b.Length);
            if (maxLen == 0) return 1;
            return 1.0 - (double)LevenshteinDistance(a, b) / maxLen;
        }

        private static int LevenshteinDistance(string a, string b)
        {
            var dp = new int[a.Length + 1, b.Length + 1];
            for (int i = 0; i <= a.Length; i++) dp[i, 0] = i;
            for (int j = 0; j <= b.Length; j++) dp[0, j] = j;

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int cost = a[i - 1] == b[j - 1] ? 0 : 1;
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + cost);
                }
            }
            return dp[a.Length, b.Length];
        }

        // تطبيع بسيط للنص العربي (إزالة التشكيل، توحيد الألف والهمزات...) لتحسين دقة مطابقة التكرار
        private static string NormalizeArabicText(string? text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";

            var s = System.Text.RegularExpressions.Regex.Replace(text.Trim(), @"\s+", " ");
            s = s.Replace('أ', 'ا').Replace('إ', 'ا').Replace('آ', 'ا').Replace('ى', 'ي').Replace('ة', 'ه');
            s = System.Text.RegularExpressions.Regex.Replace(s, @"[ً-ْـ]", "");
            return s.ToLowerInvariant();
        }

        // ─── Save: Review Grid → Database ─────────────────────────────────────
        private void BtnSaveToDb_Click(object? sender, EventArgs e)
        {
            if (_rows.Count == 0)
            {
                XtraMessageBox.Show("لا توجد بيانات للحفظ. يرجى الاستيراد أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var missingDataRows = _rows.Count(r => string.IsNullOrWhiteSpace(r.ItemName) || r.CategoryId == null || r.UnitId == null);
            if (missingDataRows > 0)
            {
                XtraMessageBox.Show($"يوجد {missingDataRows} صف بدون تصنيف أو وحدة. يرجى استكمال البيانات الناقصة في الجدول قبل الحفظ.",
                    "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var duplicateCount = _rows.Count(r => r.Status == "مكرر - موجود بالفعل");
            if (duplicateCount > 0)
            {
                if (XtraMessageBox.Show($"يوجد {duplicateCount} صف مكرر (موجود مسبقاً في النظام). سيتم تجاهلهم والاستمرار في حفظ باقي الأصناف. هل تريد المتابعة؟",
                    "أصناف مكررة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            var rowsToSave = _rows.Where(r => r.Status != "مكرر - موجود بالفعل").ToList();
            if (rowsToSave.Count == 0)
            {
                XtraMessageBox.Show("لا توجد أصناف جديدة لحفظها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categorySequences = new Dictionary<int, int>();
            int savedCount = 0;

            var handle = ShowOverlay();
            try
            {
                foreach (var row in rowsToSave)
                {
                    var entity = new Core.ItemsList
                    {
                        Name = row.ItemName!.Trim(),
                        Description = string.IsNullOrWhiteSpace(row.Description) ? null : row.Description.Trim(),
                        CategoryId = row.CategoryId,
                        UnitId = row.UnitId,
                        IsActive = true,
                        Code = row.AutoCode ? GenerateNextCode(row.CategoryId!.Value, categorySequences) : row.ItemCode?.Trim(),
                        CreatedDate = DateTime.Now,
                        CreatedMachine = Session.Machine,
                        CreatedBy = Session.CurrentUser?.Id ?? 1
                    };

                    dc.ItemsList.Add(entity);
                    savedCount++;
                }

                XtraMessageBox.Show($"تم حفظ {savedCount} صنف بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}\nتم حفظ {savedCount} صنف قبل حدوث الخطأ.",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // يولّد كود الصنف (رمز التصنيف + تسلسل 3 أرقام) مع تتبع التسلسل داخل نفس دفعة الاستيراد
        // لتفادي تكرار نفس الكود لعدة أصناف جديدة من نفس التصنيف يتم استيرادها معاً
        private string GenerateNextCode(int categoryId, Dictionary<int, int> categorySequences)
        {
            var category = dc.ItemCategory.Find(categoryId);
            var categoryCode = category?.Code;
            if (string.IsNullOrEmpty(categoryCode)) return "";

            if (!categorySequences.TryGetValue(categoryId, out int seq))
            {
                var items = dc.ItemsList.GetBySql("SELECT * FROM ItemsList WHERE CategoryId = @categoryId", new { categoryId });
                seq = 0;
                foreach (var item in items)
                {
                    if (string.IsNullOrEmpty(item.Code) || !item.Code.StartsWith(categoryCode)) continue;
                    var suffix = item.Code.Substring(categoryCode.Length);
                    if (int.TryParse(suffix, out var n) && n > seq) seq = n;
                }
            }

            seq++;
            categorySequences[categoryId] = seq;
            return categoryCode + seq.ToString("000");
        }

        // ─── Overlay helpers ─────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);
        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
        // ─────────────────────────────────────────────────────────────────────
    }

    public class ImportedItemRow
    {
        public bool AutoCode { get; set; } = true;
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public int? UnitId { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? SimilarItems { get; set; }
    }
}
