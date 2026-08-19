using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using ExcelDataReader;

namespace Etmam
{
    public partial class frmBOQImportWizard : DevExpress.XtraEditors.XtraForm
    {
        private const string IgnoreOption = "(تجاهل)";
        private static readonly string[] TargetFields =
        {
            IgnoreOption, "ItemNo", "DescriptionAr", "DescriptionEn", "Unit", "Quantity", "UnitRate",
            "CostCode", "WBS", "CBS", "ResourceCode", "Remarks",
        };

        private DataSet? _rawWorkbook;
        private DataTable? _rawSheet;
        private readonly List<string> _excelColumns = new();

        private readonly BindingList<ColumnMappingRow> _mappingRows = new();
        private readonly BindingList<ValidationRow> _validationRows = new();
        private readonly List<MappedRow> _mappedRows = new();
        private readonly BindingList<BOQItemDetails> _previewItems = new();

        /// <summary>Populated when the wizard finishes; the caller (ucBOQEditor) reads this after
        /// ShowDialog() returns DialogResult.OK.</summary>
        public List<BOQItemDetails> ImportedItems { get; private set; } = new();

        public frmBOQImportWizard()
        {
            InitializeComponent();

            grdColumnMapping.DataSource = _mappingRows;
            grdValidation.DataSource = _validationRows;
            grdPreview.DataSource = _previewItems;

            var repo = new RepositoryItemComboBox { TextEditStyle = TextEditStyles.DisableTextEditor };
            repo.Items.AddRange(TargetFields);
            grdColumnMapping.RepositoryItems.Add(repo);
            colMapsTo.ColumnEdit = repo;

            cboSheetName.EditValueChanged += CboSheetName_EditValueChanged;
            wizImport.SelectedPageChanging += WizImport_SelectedPageChanging;
        }

        // ── File & sheet selection ───────────────────────────────────────────
        private void btnBrowseFile_Click(object sender, System.EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                _rawWorkbook = ReadWorkbook(ofd.FileName);
                txtFilePath.Text = ofd.FileName;

                cboSheetName.Properties.Items.Clear();
                foreach (DataTable t in _rawWorkbook.Tables)
                    cboSheetName.Properties.Items.Add(t.TableName);

                if (_rawWorkbook.Tables.Count > 0)
                    cboSheetName.EditValue = _rawWorkbook.Tables[0].TableName;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في قراءة ملف الإكسل:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static DataSet ReadWorkbook(string path)
        {
            // مطلوب لقراءة ملفات Excel بترميزات غير Unicode (خصوصاً xls القديمة) — نفس أسلوب
            // Etmam/Gui/General/ImportFromExcel/ImportDataFromExcel.cs. UseHeaderRow=false دائماً هنا؛
            // قرار اعتبار الصف الأول عناوين (chkFirstRowHeaders) يُطبَّق يدوياً لاحقاً بدل إعادة قراءة الملف.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            return reader.AsDataSet(new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = false },
            });
        }

        private void CboSheetName_EditValueChanged(object? sender, System.EventArgs e)
        {
            var name = cboSheetName.EditValue?.ToString();
            _rawSheet = (_rawWorkbook != null && !string.IsNullOrEmpty(name) && _rawWorkbook.Tables.Contains(name))
                ? _rawWorkbook.Tables[name]
                : null;
        }

        // ── Wizard page transitions ──────────────────────────────────────────
        private void WizImport_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (e.Direction != DevExpress.XtraWizard.Direction.Forward) return;

            if (e.Page == wizPageMapping)
            {
                if (_rawSheet == null)
                {
                    XtraMessageBox.Show("اختر ملف إكسل وورقة عمل أولاً.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                BuildColumnMapping();
            }
            else if (e.Page == wizPageValidation)
            {
                RunValidation();
            }
            else if (e.Page == wizPagePreview)
            {
                BuildPreview();
            }
            else if (e.Page == wizPageSummary)
            {
                BuildSummary();
            }
        }

        // ── Mapping page ──────────────────────────────────────────────────────
        private void BuildColumnMapping()
        {
            _mappingRows.Clear();
            _excelColumns.Clear();
            if (_rawSheet == null || _rawSheet.Rows.Count == 0) return;

            bool hasHeaders = chkFirstRowHeaders.Checked;
            for (int c = 0; c < _rawSheet.Columns.Count; c++)
            {
                string label = hasHeaders
                    ? (_rawSheet.Rows[0][c]?.ToString()?.Trim() is { Length: > 0 } h ? h : $"عمود {c + 1}")
                    : $"عمود {c + 1}";
                _excelColumns.Add(label);

                var mapsTo = GuessMapping(label);
                _mappingRows.Add(new ColumnMappingRow
                {
                    ExcelColumn = label,
                    MapsTo = mapsTo,
                    DataType = mapsTo is "Quantity" or "UnitRate" ? "رقم" : mapsTo == IgnoreOption ? "-" : "نص",
                });
            }
        }

        private static string GuessMapping(string header)
        {
            var h = header.Trim();
            if (h.Contains("بند")) return "ItemNo";
            if (h.Contains("وصف") || h.Contains("Description")) return "DescriptionAr";
            if (h.Contains("وحدة") || h.Contains("Unit")) return "Unit";
            if (h.Contains("كمية") || h.Contains("Qty") || h.Contains("Quantity")) return "Quantity";
            if (h.Contains("سعر") || h.Contains("Rate") || h.Contains("Price")) return "UnitRate";
            if (h.Contains("تكلفة") || h.Contains("Cost")) return "CostCode";
            if (h.Contains("WBS")) return "WBS";
            if (h.Contains("CBS")) return "CBS";
            if (h.Contains("مورد") || h.Contains("Resource")) return "ResourceCode";
            if (h.Contains("ملاحظ") || h.Contains("Remark")) return "Remarks";
            return IgnoreOption;
        }

        // ── Validation page ───────────────────────────────────────────────────
        private void RunValidation()
        {
            _validationRows.Clear();
            _mappedRows.Clear();

            if (_rawSheet != null)
            {
                int startRow = chkFirstRowHeaders.Checked ? 1 : 0;
                var mapping = _mappingRows.Where(m => m.MapsTo != IgnoreOption).ToList();

                for (int r = startRow; r < _rawSheet.Rows.Count; r++)
                {
                    int rowNumber = r + 1;
                    var values = new Dictionary<string, string>();
                    foreach (var col in mapping)
                    {
                        var colIndex = _excelColumns.IndexOf(col.ExcelColumn);
                        if (colIndex < 0 || colIndex >= _rawSheet.Columns.Count) continue;
                        values[col.MapsTo] = _rawSheet.Rows[r][colIndex]?.ToString()?.Trim() ?? "";
                    }

                    if (values.Count == 0 || values.Values.All(string.IsNullOrWhiteSpace)) continue;

                    if (!values.TryGetValue("DescriptionAr", out var desc) || string.IsNullOrWhiteSpace(desc))
                        _validationRows.Add(new ValidationRow { RowNumber = rowNumber, FieldName = "الوصف", Issue = "الوصف بالعربي مفقود", Severity = "خطأ" });

                    if (values.TryGetValue("Quantity", out var qtyStr) && !string.IsNullOrWhiteSpace(qtyStr) && !decimal.TryParse(qtyStr, out _))
                        _validationRows.Add(new ValidationRow { RowNumber = rowNumber, FieldName = "الكمية", Issue = $"قيمة غير رقمية: {qtyStr}", Severity = "خطأ" });

                    if (values.TryGetValue("UnitRate", out var rateStr) && !string.IsNullOrWhiteSpace(rateStr) && !decimal.TryParse(rateStr, out _))
                        _validationRows.Add(new ValidationRow { RowNumber = rowNumber, FieldName = "سعر الوحدة", Issue = $"قيمة غير رقمية: {rateStr}", Severity = "خطأ" });

                    _mappedRows.Add(new MappedRow { RowNumber = rowNumber, Values = values });
                }
            }

            lblTotalRowsValue.Text = _mappedRows.Count.ToString();
            lblErrorsValue.Text = _validationRows.Count(v => v.Severity == "خطأ").ToString();
            lblWarningsValue.Text = _validationRows.Count(v => v.Severity == "تحذير").ToString();
        }

        // ── Preview page ──────────────────────────────────────────────────────
        private void BuildPreview()
        {
            _previewItems.Clear();
            var errorRows = _validationRows.Where(v => v.Severity == "خطأ").Select(v => v.RowNumber).ToHashSet();

            foreach (var row in _mappedRows.Where(r => !errorRows.Contains(r.RowNumber)))
            {
                var item = new BOQItemDetails
                {
                    ItemNo = row.Values.GetValueOrDefault("ItemNo"),
                    DescriptionAr = row.Values.GetValueOrDefault("DescriptionAr"),
                    DescriptionEn = row.Values.GetValueOrDefault("DescriptionEn"),
                    Unit = row.Values.GetValueOrDefault("Unit"),
                    CostCode = row.Values.GetValueOrDefault("CostCode"),
                    WBS = row.Values.GetValueOrDefault("WBS"),
                    CBS = row.Values.GetValueOrDefault("CBS"),
                    ResourceCode = row.Values.GetValueOrDefault("ResourceCode"),
                    Remarks = row.Values.GetValueOrDefault("Remarks"),
                };

                if (row.Values.TryGetValue("Quantity", out var q) && decimal.TryParse(q, out var qty)) item.Quantity = qty;
                if (row.Values.TryGetValue("UnitRate", out var ur) && decimal.TryParse(ur, out var rate)) item.UnitRate = rate;
                item.Total = (item.Quantity ?? 0) * (item.UnitRate ?? 0);

                _previewItems.Add(item);
            }
        }

        // ── Summary page ──────────────────────────────────────────────────────
        private void BuildSummary()
        {
            ImportedItems = _previewItems.ToList();
            lblImportedRowsValue.Text = ImportedItems.Count.ToString();
            lblSkippedRowsValue.Text = (_mappedRows.Count - ImportedItems.Count).ToString();
            lblImportErrorsValue.Text = _validationRows.Count(v => v.Severity == "خطأ").ToString();
        }

        private void btnViewLog_Click(object sender, System.EventArgs e)
        {
            if (_validationRows.Count == 0)
            {
                XtraMessageBox.Show("لا توجد ملاحظات مسجّلة.", "سجل التحقق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var text = string.Join("\n", _validationRows.Select(v => $"صف {v.RowNumber} - {v.FieldName}: {v.Issue} ({v.Severity})"));
            XtraMessageBox.Show(text, "سجل التحقق", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void wizImport_FinishClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void wizImport_CancelClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private class ColumnMappingRow
        {
            public string ExcelColumn { get; set; } = "";
            public string MapsTo { get; set; } = IgnoreOption;
            public string DataType { get; set; } = "-";
        }

        private class ValidationRow
        {
            public int RowNumber { get; set; }
            public string FieldName { get; set; } = "";
            public string Issue { get; set; } = "";
            public string Severity { get; set; } = "";
        }

        private class MappedRow
        {
            public int RowNumber { get; set; }
            public Dictionary<string, string> Values { get; set; } = new();
        }
    }
}
