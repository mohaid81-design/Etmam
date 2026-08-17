using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ExcelDataReader;

namespace Etmam
{
    public partial class frmImportSchedule : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private DataTable? _rawTemplateData;
        private List<string> _fileColumns = new List<string>();

        public frmImportSchedule()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);

            DesignSystem.ApplyTreeListStyle(treeListPreview);
            DesignSystem.HideTreeListAuditColumns(treeListPreview);

            treeListPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            treeListPreview.OptionsView.ShowAutoFilterRow = false;
            treeListPreview.NodeCellStyle += TreeListPreview_NodeCellStyle;

            LoadProjects();

            int currentPrjId = (lueProject.EditValue is int id) ? id : 0;
            if (currentPrjId == 0)
            {
                lueProject.EditValue = Session.SelectedProjectId;
            }

            if (lueProject.EditValue != null && (int)lueProject.EditValue > 0)
            {
                lueProject.ReadOnly = true;
            }
        }


        public frmImportSchedule(int prjId) : this()
        {
            if (prjId > 0)
            {
                lueProject.EditValue = prjId;
                lueProject.ReadOnly = true;
            }
        }


        private void LoadProjects()
        {
            var projects = DC.ProjectsList.GetAll();
            lueProject.Properties.DataSource = projects;
            lueProject.Properties.DisplayMember = "Name";
            lueProject.Properties.ValueMember = "Id";
            lueProject.Properties.Columns.Clear();
            lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Num", "رقم المشروع"));
            lueProject.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "اسم المشروع"));
        }

        private void LueProject_EditValueChanged(object sender, EventArgs e)
        {
            // Logic for project change if needed
        }

        private void TxtFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Schedule Files (*.xlsx, *.xls, *.xer)|*.xlsx;*.xls;*.xer|Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|P6 XER Files (*.xer)|*.xer";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                    LoadFile(ofd.FileName);
                }
            }
        }

        private void BbiOpenFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TxtFilePath_ButtonClick(null, null);
        }

        private void LoadFile(string path)
        {
            try
            {
                string ext = Path.GetExtension(path).ToLower();
                if (ext == ".xer")
                {
                    _rawTemplateData = ParseXer(path);
                }
                else
                {
                    _rawTemplateData = ParseExcel(path);
                }

                if (_rawTemplateData != null)
                {
                    _fileColumns = _rawTemplateData.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
                    PopulateMappingCombos();

                    txtNewScheduleName.Text = Path.GetFileNameWithoutExtension(path);
                    XtraMessageBox.Show("تم تحميل الملف بنجاح. يرجى ربط الأعمدة.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("الملف لا يحتوي على بيانات صالحة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                string msg = $"خطأ في تحميل الملف: {ex.Message}";
                if (ex.InnerException != null) msg += $"\n{ex.InnerException.Message}";
                XtraMessageBox.Show(msg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateMappingCombos()
        {
            var combos = new[] {
                cboItem, cboDescription, cboLocation, cboCategory, cboStartDate, cboEndDate,
                cboActualStartDate, cboActualEndDate, cboWBSId, cboWBSName, cboActivityId
            };

            foreach (var combo in combos)
            {
                combo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                combo.Properties.Items.Clear();
                combo.Properties.Items.Add("[None]");
                if (_rawTemplateData != null)
                {
                    foreach (DataColumn col in _rawTemplateData.Columns)
                        combo.Properties.Items.Add(col.ColumnName);
                }

                // Smart Matching
                string normalizedLabel = combo.Name.Replace("cbo", "").ToLower();
                foreach (var item in combo.Properties.Items)
                {
                    string colName = item.ToString();
                    string colLower = colName.ToLower();

                    bool match = false;
                    if (normalizedLabel == "item" && (colLower.Contains("item") || colLower.Contains("بند") || colLower == "id")) match = true;
                    else if (normalizedLabel == "activityid" && (colLower.Contains("activity") && (colLower.Contains("id") || colLower.Contains("code") || colLower.Contains("رقم")))) match = true;
                    else if (normalizedLabel == "description" && (colLower.Contains("desc") || colLower.Contains("اسم") || colLower.Contains("نشاط") || colLower.Contains("activity") || colLower.Contains("name"))) match = true;
                    else if (normalizedLabel == "location" && (colLower.Contains("loc") || colLower.Contains("موقع"))) match = true;
                    else if (normalizedLabel == "category" && (colLower.Contains("cat") || colLower.Contains("نوع"))) match = true;
                    else if (normalizedLabel == "startdate" && (colLower.Contains("start") || colLower.Contains("بداية")) && !colLower.Contains("actual") && !colLower.Contains("فعلي")) match = true;
                    else if (normalizedLabel == "enddate" && (colLower.Contains("finish") || colLower.Contains("end") || colLower.Contains("نهاية")) && !colLower.Contains("actual") && !colLower.Contains("فعلي")) match = true;
                    else if (normalizedLabel == "actualstartdate" && (colLower.Contains("actual") || colLower.Contains("فعلي")) && (colLower.Contains("start") || colLower.Contains("بداية"))) match = true;
                    else if (normalizedLabel == "actualenddate" && (colLower.Contains("actual") || colLower.Contains("فعلي")) && (colLower.Contains("finish") || colLower.Contains("end") || colLower.Contains("نهاية"))) match = true;
                    else if (normalizedLabel == "wbsid" && (colLower.Contains("wbs") && (colLower.Contains("id") || colLower.Contains("code") || colLower.Contains("رقم")))) match = true;
                    else if (normalizedLabel == "wbsname" && (colLower.Contains("wbs") && (colLower.Contains("name") || colLower.Contains("اسم")))) match = true;

                    if (match)
                    {
                        combo.EditValue = item;
                        break;
                    }
                }
                if (combo.EditValue == null) combo.SelectedIndex = 0;
            }
            BuildTreeData();
        }

        private DataTable? ParseExcel(string path)
        {
            try
            {
                // Register encoding provider (required for binary Excel files)
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                // Use FileShare.ReadWrite to allow reading files open in Excel
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });

                        if (result != null && result.Tables.Count > 0)
                            return result.Tables[0];

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في محرك قراءة الاكسل: {ex.Message}", ex);
            }
        }

        private DataTable? ParseXer(string path)
        {
            DataTable dt = new DataTable("TASK");
            string[] lines = File.ReadAllLines(path);
            bool inTaskTable = false;
            string[] headers = null;

            foreach (string line in lines)
            {
                if (line.StartsWith("%T\tTASK")) { inTaskTable = true; continue; }
                if (inTaskTable && line.StartsWith("%F"))
                {
                    headers = line.Split('\t').Skip(1).ToArray();
                    foreach (var h in headers)
                    {
                        if (!dt.Columns.Contains(h)) dt.Columns.Add(h);
                        else dt.Columns.Add(h + "_" + dt.Columns.Count);
                    }
                    continue;
                }
                if (inTaskTable && line.StartsWith("%R"))
                {
                    string[] values = line.Split('\t').Skip(1).ToArray();
                    if (values.Length > dt.Columns.Count) values = values.Take(dt.Columns.Count).ToArray();
                    if (values.Length < dt.Columns.Count) values = values.Concat(new string[dt.Columns.Count - values.Length]).ToArray();
                    dt.Rows.Add(values);
                    continue;
                }
                if (inTaskTable && line.StartsWith("%T") && !line.Contains("TASK")) break;
            }
            return dt;
        }

        private void CboMapping_EditValueChanged(object sender, EventArgs e)
        {
            if (_rawTemplateData == null) return;
            BuildTreeData();
        }

        private void BuildTreeData()
        {
            if (_rawTemplateData == null) return;

            treeListPreview.BeginUpdate();
            treeListPreview.Nodes.Clear();
            treeListPreview.Columns.Clear();

            var mappings = new Dictionary<string, string>();
            if (cboWBSId.Text != "[None]") mappings["WBSId"] = cboWBSId.Text;
            if (cboWBSName.Text != "[None]") mappings["WBSName"] = cboWBSName.Text;
            if (cboActivityId.Text != "[None]") mappings["ActivityId"] = cboActivityId.Text;
            if (cboDescription.Text != "[None]") mappings["Description"] = cboDescription.Text;
            if (cboStartDate.Text != "[None]") mappings["StartDate"] = cboStartDate.Text;
            if (cboEndDate.Text != "[None]") mappings["EndDate"] = cboEndDate.Text;
            if (cboActualStartDate.Text != "[None]") mappings["ActualStartDate"] = cboActualStartDate.Text;
            if (cboActualEndDate.Text != "[None]") mappings["ActualEndDate"] = cboActualEndDate.Text;

            var columnCaptions = new Dictionary<string, string>
            {
                { "WBSId", "رقم الهيكل" },
                { "WBSName", "اسم الهيكل" },
                { "ActivityId", "رقم النشاط" },
                { "Description", "اسم النشاط" },
                { "StartDate", "بداية مخطط" },
                { "EndDate", "نهاية مخطط" },
                { "ActualStartDate", "بداية فعلي" },
                { "ActualEndDate", "نهاية فعلي" }
            };

            foreach (var mapping in mappings)
            {
                var col = treeListPreview.Columns.Add();
                col.Caption = columnCaptions.ContainsKey(mapping.Key) ? columnCaptions[mapping.Key] : mapping.Key;
                col.FieldName = mapping.Key;
                col.Visible = true;
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                col.AppearanceCell.Font = DesignSystem.Fonts.Regular(9);
            }

            treeListPreview.KeyFieldName = "Id";
            treeListPreview.ParentFieldName = "ParentId";

            DataTable treeTable = new DataTable();
            treeTable.Columns.Add("Id", typeof(int));
            treeTable.Columns.Add("ParentId", typeof(int));
            treeTable.Columns.Add("IdCategory", typeof(string));
            foreach (var mapping in mappings) treeTable.Columns.Add(mapping.Key);

            int idCounter = 1;
            Dictionary<string, int> wbsNodes = new Dictionary<string, int>();

            foreach (DataRow row in _rawTemplateData.Rows)
            {
                string wbsIdValue = GetValue(row, cboWBSId.Text)?.ToString() ?? "";
                string wbsNameValue = GetValue(row, cboWBSName.Text)?.ToString() ?? "";

                int parentId = 0;
                if (!string.IsNullOrEmpty(wbsIdValue))
                {
                    if (!wbsNodes.ContainsKey(wbsIdValue))
                    {
                        DataRow wbsRow = treeTable.NewRow();
                        int currentWbsId = idCounter++;
                        wbsRow["Id"] = currentWbsId;
                        wbsRow["ParentId"] = 0;
                        wbsRow["IdCategory"] = "wbs";
                        if (mappings.ContainsKey("WBSId")) wbsRow["WBSId"] = wbsIdValue;
                        if (mappings.ContainsKey("WBSName")) wbsRow["WBSName"] = wbsNameValue;
                        treeTable.Rows.Add(wbsRow);
                        wbsNodes[wbsIdValue] = currentWbsId;
                    }
                    parentId = wbsNodes[wbsIdValue];
                }

                DataRow activityRow = treeTable.NewRow();
                activityRow["Id"] = idCounter++;
                activityRow["ParentId"] = parentId;
                activityRow["IdCategory"] = "act";
                foreach (var mapping in mappings)
                {
                    activityRow[mapping.Key] = GetValue(row, mapping.Value);
                }
                treeTable.Rows.Add(activityRow);
            }

            treeListPreview.DataSource = treeTable;
            treeListPreview.ExpandAll();
            treeListPreview.EndUpdate();
        }

        private void TreeListPreview_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            var row = treeListPreview.GetDataRecordByNode(e.Node) as DataRowView;
            if (row == null) return;

            string category = row["IdCategory"]?.ToString();
            if (category == "wbs")
            {
                e.Appearance.Font = DesignSystem.Fonts.Bold(9f);
                e.Appearance.BackColor = Color.FromArgb(235, 245, 255);
                e.Appearance.ForeColor = DesignSystem.Colors.Primary;
            }
            else
            {
                e.Appearance.Font = DesignSystem.Fonts.Regular(8.5f);
                e.Appearance.ForeColor = DesignSystem.Colors.TextPrimary;
            }
        }

        private void BbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private object? GetValue(DataRow row, string colName)
        {
            if (string.IsNullOrEmpty(colName) || colName == "[None]") return null;
            if (!row.Table.Columns.Contains(colName)) return null;
            var val = row[colName];
            return (val == DBNull.Value) ? null : val;
        }

        private DateTime? GetDate(DataRow row, string colName)
        {
            var val = GetValue(row, colName);
            if (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString())) return null;
            if (DateTime.TryParse(val.ToString(), out DateTime d)) return d;
            return null;
        }

        private void BbiImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lueProject.EditValue == null)
            {
                XtraMessageBox.Show("يرجى اختيار المشروع أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_rawTemplateData == null || _rawTemplateData.Rows.Count == 0)
            {
                XtraMessageBox.Show("لا توجد بيانات للمعالجة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDescription.Text == "[None]" && cboActivityId.Text == "[None]")
            {
                XtraMessageBox.Show("يجب ربط عمود (وصف النشاط) أو (رقم النشاط) على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int prjId = Convert.ToInt32(lueProject.EditValue);
                var scheduleHelper = DC.ScheduleList;

                string scheduleName = string.IsNullOrEmpty(txtNewScheduleName.Text) ? "جدول جديد" : txtNewScheduleName.Text;

                var newSchedule = new ScheduleList
                {
                    Name = scheduleName,
                    PrjId = prjId,
                    CreatedDate = DateTime.Now,
                    CreatedMachine = Environment.MachineName,
                    CreatedBy = Session.CurrentUser.Id
                };

                int scheduleId = scheduleHelper.Add(newSchedule);
                if (scheduleId <= 0)
                {
                    XtraMessageBox.Show("فشل إنشاء الجدول الزمني الرئيسي في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var scheduleDetailHelper = DC.ScheduleDetails;
                int rowIdx = 0;
                int added = 0;

                // Cache to store WBS paths and their generated database IDs
                var wbsCache = new Dictionary<string, int>();

                foreach (DataRow row in _rawTemplateData.Rows)
                {
                    rowIdx++;
                    try
                    {
                        string wbsIdVal = GetValue(row, cboWBSId.Text)?.ToString();
                        string wbsNameVal = GetValue(row, cboWBSName.Text)?.ToString();
                        string activityIdVal = GetValue(row, cboActivityId.Text)?.ToString();
                        string activityNameVal = GetValue(row, cboDescription.Text)?.ToString();
                        string itemName = GetValue(row, cboItem.Text)?.ToString();

                        if (string.IsNullOrEmpty(activityIdVal) && string.IsNullOrEmpty(activityNameVal) && string.IsNullOrEmpty(wbsIdVal))
                            continue;

                        // 1. Handle WBS Creation/Retrieval (Recursive)
                        int currentParentId = 0;
                        if (!string.IsNullOrEmpty(wbsIdVal))
                        {
                            currentParentId = EnsureWbsCreated(wbsIdVal, wbsNameVal, scheduleId, prjId, wbsCache, scheduleDetailHelper);
                        }

                        // 2. Handle Activity Creation
                        if (!string.IsNullOrEmpty(activityIdVal) || !string.IsNullOrEmpty(activityNameVal))
                        {
                            var activityDetail = new ScheduleDetails
                            {
                                ScheduleId = scheduleId,
                                PrjId = prjId,
                                IdCategory = "act",
                                ActivityId = activityIdVal,
                                ActivityName = activityNameVal ?? itemName,
                                IdParent = currentParentId,
                                StartDate = GetDate(row, cboStartDate.Text),
                                EndDate = GetDate(row, cboEndDate.Text),
                                ActuaStart = GetDate(row, cboActualStartDate.Text),
                                ActualEnd = GetDate(row, cboActualEndDate.Text),
                                CreatedDate = DateTime.Now,
                                CreatedMachine = Environment.MachineName,
                                CreatedBy = Session.CurrentUser.Id
                            };

                            if (activityDetail.StartDate.HasValue && activityDetail.EndDate.HasValue)
                                activityDetail.Duration = (int)(activityDetail.EndDate.Value - activityDetail.StartDate.Value).TotalDays;

                            scheduleDetailHelper.Add(activityDetail);
                            added++;
                        }
                    }
                    catch (Exception rowEx)
                    {
                        Console.WriteLine($"Error at row {rowIdx}: {rowEx.Message}");
                    }
                }

                XtraMessageBox.Show($"تم استيراد {added} عنصر بنجاح للجدول الجديد: {scheduleName}", "تم بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string errorMsg = $"خطأ أثناء الاستيراد: {ex.Message}";
                if (ex.InnerException != null) errorMsg += $"\nInner: {ex.InnerException.Message}";
                XtraMessageBox.Show(errorMsg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int EnsureWbsCreated(string wbsCode, string wbsName, int scheduleId, int prjId, Dictionary<string, int> wbsCache, IDataHelper<ScheduleDetails> helper)
        {
            if (string.IsNullOrEmpty(wbsCode)) return 0;
            if (wbsCache.ContainsKey(wbsCode)) return wbsCache[wbsCode];

            int parentId = 0;
            int lastDot = wbsCode.LastIndexOf('.');
            if (lastDot > 0)
            {
                string parentCode = wbsCode.Substring(0, lastDot);
                parentId = EnsureWbsCreated(parentCode, parentCode, scheduleId, prjId, wbsCache, helper);
            }

            var wbsDetail = new ScheduleDetails
            {
                ScheduleId = scheduleId,
                PrjId = prjId,
                IdCategory = "wbs",
                ActivityId = wbsCode,
                ActivityName = string.IsNullOrEmpty(wbsName) ? wbsCode : wbsName,
                IdParent = parentId,
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = Session.CurrentUser.Id
            };

            int newId = helper.Add(wbsDetail);
            wbsCache[wbsCode] = newId;
            return newId;
        }
    }
}

