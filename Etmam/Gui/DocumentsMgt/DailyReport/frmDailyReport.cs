using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmDailyReport : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private int _dailyReportId;
        private DailyReport? _report;
        private ucDailyStaff? _ucDailyStaff;
        private ucDailyLabor? _ucDailyLabor;
        private ucDailyEquipment? _ucEquipment;
        private ucDailyMaterial? _ucMaterial;
        private ucWorkDoneToday? _ucWorkDone;
        private ucWorkPlannedTowmorrow? _ucWorkPlanned;
        private ucDisruptedActivity? _ucDisrupted;
        private ucIssue? _ucIssue;
        private ucInspection? _ucInspection;
        private ucDailyPhoto? _ucPhoto;
        private HashSet<UserControl> _initializedControls = new HashSet<UserControl>();
        private bool _isDirty = false;
        private bool _isLoadingReport = false;

        public frmDailyReport(int id = 0)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _dailyReportId = id;

            // Controls are now lazy-loaded in InitializeActiveTab
            
            InitializeData();
            LoadReport(_dailyReportId);

            this.FormClosing += FrmDailyReport_FormClosing;
        }

        private void MarkDirty()
        {
            if (!_isLoadingReport)
                _isDirty = true;
        }

        private void InitializeData()
        {
            xtraTabControl1.SelectedPageChanged += XtraTabControl1_SelectedPageChanged;

            dtReportDate.EditValueChanged += (s, e) =>
            {
                if (_isLoadingReport) return;
                MarkDirty();
                dtReportDate_EditValueChanged(s, e);
            };
            icbeWeather.EditValueChanged += (s, e) => MarkDirty();
            txtTemp.EditValueChanged += (s, e) => MarkDirty();
            coShift.EditValueChanged += (s, e) => MarkDirty();

            dtReportDate.KeyDown += (s, e) =>
            {
                var editor = s as DateEdit;
                if (editor == null) return;

                bool isForward = e.KeyCode == Keys.Tab || e.KeyCode == Keys.Right;
                bool isBackward = e.KeyCode == Keys.Left;
                if (e.KeyCode == Keys.Tab && e.Shift) { isForward = false; isBackward = true; }

                if (isForward || isBackward)
                {
                    int selStart = editor.SelectionStart;
                    if (isForward)
                    {
                        if (selStart < 5) { editor.SelectionStart = 5; editor.SelectionLength = 2; }
                        else if (selStart < 8) { editor.SelectionStart = 8; editor.SelectionLength = 2; }
                        else { editor.SelectionStart = 0; editor.SelectionLength = 4; }
                    }
                    else if (isBackward)
                    {
                        if (selStart >= 8) { editor.SelectionStart = 5; editor.SelectionLength = 2; }
                        else if (selStart >= 5) { editor.SelectionStart = 0; editor.SelectionLength = 4; }
                        else { editor.SelectionStart = 8; editor.SelectionLength = 2; }
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };

            // Wire up toolbar buttons (Note: bbiNew, bbiSave, bbiDelete, and bbiCopyPrevious are already bound in Designer.cs)
            // bbiNew.ItemClick += bbiNew_ItemClick;
            // bbiSave.ItemClick += bbiSave_ItemClick;
            // bbiDelete.ItemClick += bbiDelete_ItemClick;
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            // bbiCopyPrevious.ItemClick += bbiCopyPrevious_ItemClick;

            // Navigation
            bbiFirst.ItemClick += (s, e) => Navigate("First");
            bbiPrev.ItemClick += (s, e) => Navigate("Prev");
            bbiNext.ItemClick += (s, e) => Navigate("Next");
            bbiLast.ItemClick += (s, e) => Navigate("Last");
            bbiSearch.ItemClick += (s, e) => SearchBySerial();
            repositoryItemTextEdit1.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { barManager1.ActiveEditItemLink?.PostEditor(); SearchBySerial(); } };
        }

        private void SetupNavigationPage(DevExpress.XtraBars.Navigation.NavigationFrame frame, UserControl control)
        {
            control.Dock = DockStyle.Fill;
            var page = new DevExpress.XtraBars.Navigation.NavigationPage();
            page.Controls.Add(control);
            frame.Pages.Add(page);
            frame.SelectedPage = page;
        }

        private void XtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            InitializeActiveTab();
        }

        private void InitializeActiveTab()
        {
            InitializePage(xtraTabControl1.SelectedTabPage);
        }

        private void InitializePage(DevExpress.XtraTab.XtraTabPage page)
        {
            if (page == null) return;

            int prjId = (_report?.PrjId > 0) ? _report.PrjId : (Session.SelectedProjectId ?? 1);
            DateTime reportDate = (DateTime?)dtReportDate.EditValue ?? DateTime.Now;

            if (page == tbManpower)
            {
                if (_ucDailyStaff == null)
                {
                    _ucDailyStaff = new ucDailyStaff { Category = "Staff" };
                    _ucDailyStaff.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfStaff, _ucDailyStaff);
                }
                if (_ucDailyLabor == null)
                {
                    _ucDailyLabor = new ucDailyLabor { Category = "Labor" };
                    _ucDailyLabor.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfLabor, _ucDailyLabor);
                }
                
                if (!_initializedControls.Contains(_ucDailyStaff))
                {
                    _ucDailyStaff.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucDailyStaff);
                }

                if (!_initializedControls.Contains(_ucDailyLabor))
                {
                    _ucDailyLabor.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucDailyLabor);
                }
            }
            else if (page == tbEquipment) 
            {
                if (_ucEquipment == null) 
                {
                    _ucEquipment = new ucDailyEquipment();
                    _ucEquipment.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfEquipment, _ucEquipment); 
                }
                if (!_initializedControls.Contains(_ucEquipment))
                {
                    _ucEquipment.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucEquipment);
                }
            }
            else if (page == tbMaterial) 
            {
                if (_ucMaterial == null) 
                {
                    _ucMaterial = new ucDailyMaterial();
                    _ucMaterial.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfMaterial, _ucMaterial); 
                }
                if (!_initializedControls.Contains(_ucMaterial))
                {
                    _ucMaterial.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucMaterial);
                }
            }
            else if (page == tbWorkDoneToday) 
            {
                if (_ucWorkDone == null) 
                { 
                    _ucWorkDone = new ucWorkDoneToday();
                    _ucWorkDone.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfWorkDone, _ucWorkDone); 
                }
                if (!_initializedControls.Contains(_ucWorkDone))
                {
                    _ucWorkDone.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucWorkDone);
                }
            }
            else if (page == tbWorkPlannedTomorrow) 
            {
                if (_ucWorkPlanned == null) 
                {
                    _ucWorkPlanned = new ucWorkPlannedTowmorrow();
                    _ucWorkPlanned.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfWorkPlanned, _ucWorkPlanned); 
                }
                if (!_initializedControls.Contains(_ucWorkPlanned))
                {
                    _ucWorkPlanned.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucWorkPlanned);
                }
            }
            else if (page == tbIssue) 
            {
                if (_ucIssue == null) 
                {
                    _ucIssue = new ucIssue();
                    _ucIssue.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfIssue, _ucIssue); 
                }
                if (!_initializedControls.Contains(_ucIssue))
                {
                    _ucIssue.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucIssue);
                }
            }
            else if (page == tbInspection) 
            {
                if (_ucInspection == null) 
                {
                    _ucInspection = new ucInspection();
                    _ucInspection.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfInspection, _ucInspection); 
                }
                if (!_initializedControls.Contains(_ucInspection))
                {
                    _ucInspection.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucInspection);
                }
            }
            else if (page == tbDisruptedActivity) 
            {
                if (_ucDisrupted == null) 
                {
                    _ucDisrupted = new ucDisruptedActivity();
                    _ucDisrupted.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfDisrupted, _ucDisrupted); 
                }
                if (!_initializedControls.Contains(_ucDisrupted))
                {
                    _ucDisrupted.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucDisrupted);
                }
            }
            else if (page == tbPhoto) 
            {
                if (_ucPhoto == null) 
                {
                    _ucPhoto = new ucDailyPhoto();
                    _ucPhoto.DataChanged += () => MarkDirty();
                    SetupNavigationPage(nfPhoto, _ucPhoto); 
                }
                if (!_initializedControls.Contains(_ucPhoto))
                {
                    _ucPhoto.Initialize(_dailyReportId, prjId, reportDate);
                    _initializedControls.Add(_ucPhoto);
                }
            }

        }


        private void UpdateSearchNumFromReportNum(string reportNum)
        {
            if (!string.IsNullOrEmpty(reportNum))
            {
                var parts = reportNum.Split('-');
                if (parts.Length >= 3 && int.TryParse(parts[parts.Length - 1], out int num))
                {
                    beiSearchNum.EditValue = num;
                    return;
                }
            }
            beiSearchNum.EditValue = null;
        }

        private void LoadReport(int id)
        {
            _isLoadingReport = true;
            try
            {
                _initializedControls.Clear();
                int prjId = Session.SelectedProjectId ?? 1;

                if (id > 0)
                {
                    _report = DC.DailyReport.Find(id);
                    if (_report != null)
                    {
                        txtReportNum.Text = _report.ReportNumber;
                        UpdateSearchNumFromReportNum(_report.ReportNumber);

                        dtReportDate.EditValue = _report.ReportDate;
                        icbeWeather.EditValue = _report.Weather;
                        txtTemp.Text = _report.Temperature?.ToString();
                        coShift.EditValue = _report.Shift;
                        prjId = _report.PrjId;
                    }
                }
                else
                {
                    _report = new DailyReport();
                    dtReportDate.EditValue = DateTime.Now;
                    txtReportNum.Text = GenerateNextReportNumber(prjId, (DateTime)dtReportDate.EditValue);
                    UpdateSearchNumFromReportNum(txtReportNum.Text);

                    icbeWeather.EditValue = null;
                    txtTemp.Text = string.Empty;
                    coShift.EditValue = "صباح";

                    //_ = FetchWeatherAsync();
                }

                InitializeActiveTab();
                _isDirty = false;
            }
            finally
            {
                _isLoadingReport = false;
            }
        }

        private void dtReportDate_EditValueChanged(object sender, EventArgs e)
        {
            if (_dailyReportId == 0 && dtReportDate.EditValue is DateTime reportDate)
            {
                int prjId = Session.SelectedProjectId ?? 1;
                txtReportNum.Text = GenerateNextReportNumber(prjId, reportDate);
                UpdateSearchNumFromReportNum(txtReportNum.Text);

                // Do not reinitialize sub-controls here.
                // Reinitialization clears in-memory rows entered by user before first save.
            }
        }

        private void FrmDailyReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                var result = XtraMessageBox.Show("هناك تغييرات غير محفوظة، هل تريد الحفظ قبل الإغلاق؟", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) 
                {
                    if (!SaveReport()) e.Cancel = true;
                }
                else if (result == DialogResult.Cancel) e.Cancel = true;
            }
        }

        private async void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await SaveReportAsync();
        }

        private bool SaveReport()
        {
            return SaveReportCore(isAsync: false).GetAwaiter().GetResult();
        }

        private async Task<bool> SaveReportAsync(bool silent = false)
        {
            return await SaveReportCore(isAsync: true, silent: silent);
        }

        private async Task<bool> SaveReportCore(bool isAsync, bool silent = false)
        {
            if (_report == null) _report = new DailyReport();

            // 1. Gather Data (Must be on UI Thread)
            _report.ReportNumber = txtReportNum.Text;
            _report.ReportDate = (DateTime?)dtReportDate.EditValue;
            _report.Weather = icbeWeather.EditValue?.ToString();
            _report.Temperature = int.TryParse(txtTemp.Text, out int temp) ? temp : (int?)null;
            _report.PrjId = Session.SelectedProjectId ?? 1;
            _report.Shift = coShift.EditValue?.ToString();

            // 2. Duplicate Check
            if (_report.ReportDate.HasValue)
            {
                var query = "PrjId = @prjId AND CAST(ReportDate AS DATE) = @date AND Shift = @shift AND Id <> @id";
                var queryParams = new { prjId = _report.PrjId, date = _report.ReportDate.Value.Date, shift = _report.Shift ?? "", id = _dailyReportId };
                
                DailyReport? duplicate;
                if (isAsync) duplicate = (await DC.DailyReport.GetByAsync(query, queryParams)).FirstOrDefault();
                else duplicate = DC.DailyReport.GetBy(query, queryParams).FirstOrDefault();

                if (duplicate != null)
                {
                    XtraMessageBox.Show($"يوجد تقرير مسجل مسبقاً لهذا المشروع بنفس التاريخ ({_report.ReportDate.Value.ToShortDateString()}) والمناوبة ({_report.Shift}).", "تنبيه: تقرير مكرر", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // 2.1 Check for duplicate Report Number
            if (!string.IsNullOrEmpty(_report.ReportNumber))
            {
                var numQuery = "PrjId = @prjId AND ReportNumber = @num AND Id <> @id";
                var numParams = new { prjId = _report.PrjId, num = _report.ReportNumber, id = _dailyReportId };
                DailyReport? numDuplicate;
                
                if (isAsync) numDuplicate = (await DC.DailyReport.GetByAsync(numQuery, numParams)).FirstOrDefault();
                else numDuplicate = DC.DailyReport.GetBy(numQuery, numParams).FirstOrDefault();

                if (numDuplicate != null)
                {
                    XtraMessageBox.Show($"رقم التقرير ({_report.ReportNumber}) مستخدم مسبقاً في هذا المشروع، ولا يمكن تكراره.", "تنبيه: رقم مكرر", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            IOverlaySplashScreenHandle handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);

                // 3. Persist Header
                if (_dailyReportId > 0)
                {
                    if (isAsync) await DC.DailyReport.EditAsync(_dailyReportId, _report);
                    else DC.DailyReport.Edit(_dailyReportId, _report);
                }
                else
                {
                    if (isAsync) _dailyReportId = await DC.DailyReport.AddAsync(_report);
                    else _dailyReportId = DC.DailyReport.Add(_report);
                }

                // 4. Save Sub-modules
                foreach (var ctrl in _initializedControls.OfType<BaseUserControl>())
                {
                    ctrl.SaveData(_dailyReportId);
                }

                // Keep local header context fresh for navigation/search without reloading tabs.
                _report = DC.DailyReport.Find(_dailyReportId) ?? _report;
                UpdateSearchNumFromReportNum(_report?.ReportNumber ?? txtReportNum.Text);

                _isDirty = false;

                if (!silent)
                {
                    XtraMessageBox.Show("تم حفظ التقرير اليومي بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ أثناء الحفظ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (handle != null)
                    SplashScreenManager.CloseOverlayForm(handle);
            }
        }


        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isDirty)
            {
                var result = XtraMessageBox.Show("هناك تغييرات غير محفوظة، هل تريد الحفظ قبل البدء بتقرير جديد؟", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) 
                {
                    if (!SaveReport()) return;
                }
                else if (result == DialogResult.Cancel) return;
            }
            _dailyReportId = 0;
            LoadReport(0);
        }


        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_dailyReportId > 0)
            {
                if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا التقرير وكافة البيانات المرتبطة به؟", "تأكيد الحذف الكامل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    IOverlaySplashScreenHandle handle = null;
                    try
                    {
                        handle = SplashScreenManager.ShowOverlayForm(this);
                        
                        // Use centralized cascading delete
                        DC.DeleteDailyReport(_dailyReportId);

                        _dailyReportId = 0;
                        LoadReport(0);
                        XtraMessageBox.Show("تم حذف التقرير والبيانات المرتبطة به بنجاح.", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
                    }
                }
            }
        }
        private async void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_dailyReportId == 0)
            {
                if (XtraMessageBox.Show("يجب حفظ التقرير أولاً قبل الطباعة. هل تريد الحفظ الآن؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!await SaveReportAsync()) return;
                }
                else return;
            }

            if (_isDirty)
            {
                if (XtraMessageBox.Show("هناك تغييرات غير محفوظة، هل تريد الحفظ قبل الطباعة لضمان ظهور البيانات المحدثة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!await SaveReportAsync()) return;
                }
            }

            await DailyReportPrinter.PrintAsync(_dailyReportId, this);
        }

        private async void btnWeather_Click(object sender, EventArgs e)
        {
            await FetchWeatherAsync(showError: true);
        }
     
        private async Task FetchWeatherAsync(bool showError = false)
        {
            try
            {
                btnWeather.Enabled = false;
                DateTime reportDate = (DateTime?)dtReportDate.EditValue ?? DateTime.Now;
                string dateStr = reportDate.ToString("yyyy-MM-dd");

                using (var client = new HttpClient())
                {
                    // Use start_date and end_date for a specific report date
                    string url = $"https://api.open-meteo.com/v1/forecast?latitude=24.7136&longitude=46.6753&start_date={dateStr}&end_date={dateStr}&daily=temperature_2m_max,weather_code&timezone=auto";
                    var response = await client.GetStringAsync(url);

                    // Temperature: Use daily max for the selected date
                    var tempMatch = Regex.Match(response, "\"temperature_2m_max\":\\[([\\d.-]+)\\]");
                    if (tempMatch.Success)
                    {
                        txtTemp.Text = Math.Round(double.Parse(tempMatch.Groups[1].Value)).ToString();
                    }

                    // Weather Code: Use daily code
                    var codeMatch = Regex.Match(response, "\"weather_code\":\\[(\\d+)\\]");
                    if (codeMatch.Success)
                    {
                        int code = int.Parse(codeMatch.Groups[1].Value);
                        if (code == 0) icbeWeather.EditValue = "مشمس";
                        else if (code <= 3) icbeWeather.EditValue = "غائم جزئيا";
                        else if (code >= 51 && code <= 67) icbeWeather.EditValue = "ممطر";
                        else if (code >= 71 && code <= 86) icbeWeather.EditValue = "غائم";
                        else if (code >= 95) icbeWeather.EditValue = "عاصف";
                        else icbeWeather.EditValue = "غائم";
                    }
                }
            }
            catch
            {
                if (showError)
                {
                    XtraMessageBox.Show("حدث خطأ أثناء الاتصال بالإنترنت لجلب حالة الطقس، الرجاء المحاولة لاحقاً.", "فشل الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Silently fail if automatic, or allow user to click button again
            }
            finally
            {
                btnWeather.Enabled = true;
            }
        }
      
        private void bbiCopyPrevious_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_report == null) return;
            int prjId = _report.PrjId > 0 ? _report.PrjId : (Session.SelectedProjectId ?? 1);
            DateTime reportDate = (DateTime?)dtReportDate.EditValue ?? DateTime.Now;

            var lastReport = DC.DailyReport.GetBy("PrjId = @pId AND ReportDate < @rDate AND IsDelete = 0 ORDER BY ReportDate DESC",
                new { pId = prjId, rDate = reportDate }).FirstOrDefault();

            if (lastReport == null)
            {
                XtraMessageBox.Show("لا يوجد تقرير سابق لنسخ البيانات منه لهذا المشروع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (XtraMessageBox.Show($"هل تريد نسخ كافة البيانات التشغيلية من التقرير السابق بتاريخ {lastReport.ReportDate:yyyy/MM/dd}؟\nسيتم تخطي السجلات الموجودة مسبقاً لمنع التكرار.\n\n(ملاحظة: لا يتم نسخ الصور وحالة الطقس)",
                "تأكيد النسخ الشامل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int totalAdded = 0;
            string summary = "ملخص السجلات المنسوخة:\n";
            IOverlaySplashScreenHandle handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);
                
                var controlsToCopy = new (string Name, Func<BaseUserControl?> GetCtrl, DevExpress.XtraTab.XtraTabPage Page)[]
                {
                    ("الكادر الفني", () => _ucDailyStaff, tbManpower),
                    ("العمالة", () => _ucDailyLabor, tbManpower),
                    ("المعدات", () => _ucEquipment, tbEquipment),
                    ("المواد", () => _ucMaterial, tbMaterial),
                    ("العمل المنجز", () => _ucWorkDone, tbWorkDoneToday),
                    ("العمل المستهدف", () => _ucWorkPlanned, tbWorkPlannedTomorrow),
                    ("التحديات", () => _ucIssue, tbIssue),
                    ("فحص الاعمال", () => _ucInspection, tbInspection),
                    ("الانشطة المتعثرة", () => _ucDisrupted, tbDisruptedActivity)
                };

                foreach (var item in controlsToCopy)
                {
                    var ctrl = item.GetCtrl();
                    if (ctrl == null) { InitializePage(item.Page); ctrl = item.GetCtrl(); }
                    
                    if (ctrl != null)
                    {
                        int count = ctrl.CopyFromPrevious(lastReport.Id);
                        if (count > 0)
                        {
                            summary += $"- {item.Name}: {count}\n";
                            totalAdded += count;
                        }
                    }
                }

                if (totalAdded > 0)
                {
                    _isDirty = true;
                }
            }
            finally
            {
                if (handle != null)
                    SplashScreenManager.CloseOverlayForm(handle);
            }

            // Show result after wait form is closed
            if (totalAdded > 0)
            {
                XtraMessageBox.Show(summary, "تم النسخ بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("تم فحص التقرير السابق ولكن لم يتم العثور على بيانات جديدة لنسخها (ربما السجلات موجودة بالفعل).", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GenerateNextReportNumber(int prjId, DateTime reportDate)
        {
            string datePart = reportDate.ToString("yyyyMMdd");
            
            // Find ALL reports for this project to determine the next overall sequence number
            var projectReports = DC.DailyReport.GetBy("PrjId = @prjId", new { prjId = prjId });

            int nextNum = 1;
            if (projectReports != null && projectReports.Any())
            {
                // Get the maximum sequence number from existing reports for this project
                var maxNum = projectReports
                    .Where(r => !string.IsNullOrEmpty(r.ReportNumber) && r.ReportNumber.StartsWith("DR-") && r.ReportNumber.Contains("-"))
                    .Select(r => 
                    {
                        var parts = r.ReportNumber!.Split('-');
                        if (parts.Length >= 3 && int.TryParse(parts[parts.Length - 1], out int num))
                            return num;
                        return 0;
                    })
                    .DefaultIfEmpty(0)
                    .Max();

                nextNum = maxNum + 1;
            }
            return $"DR-{datePart}-{nextNum:D3}";
        }

        private void Navigate(string direction)
        {
            int prjId = (_report?.PrjId > 0) ? _report.PrjId : (Session.SelectedProjectId ?? 1);
            DateTime currentDate = (_report?.ReportDate) ?? ((DateTime?)dtReportDate.EditValue ?? DateTime.Now);
            int currentId = _dailyReportId;

            if (_isDirty)
            {
                var res = XtraMessageBox.Show("هناك تغييرات غير محفوظة، هل تريد الحفظ قبل الانتقال؟", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel) return;
                if (res == DialogResult.Yes) { if (!SaveReport()) return; }

                prjId = (_report?.PrjId > 0) ? _report.PrjId : (Session.SelectedProjectId ?? 1);
                currentDate = (_report?.ReportDate) ?? ((DateTime?)dtReportDate.EditValue ?? DateTime.Now);
                currentId = _dailyReportId;
            }

            IOverlaySplashScreenHandle handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);

                DailyReport? target = null;

                switch (direction)
                {
                    case "First":
                        target = DC.DailyReport.GetBy("PrjId = @prjId AND IsDelete = 0 ORDER BY ReportDate ASC, Id ASC", new { prjId }).FirstOrDefault();
                        break;
                    case "Last":
                        target = DC.DailyReport.GetBy("PrjId = @prjId AND IsDelete = 0 ORDER BY ReportDate DESC, Id DESC", new { prjId }).FirstOrDefault();
                        break;
                    case "Next":
                        target = DC.DailyReport.GetBy("PrjId = @prjId AND IsDelete = 0 AND (ReportDate > @d OR (ReportDate = @d AND Id > @id)) ORDER BY ReportDate ASC, Id ASC",
                            new { prjId, d = currentDate, id = currentId }).FirstOrDefault();
                        break;
                    case "Prev":
                        target = DC.DailyReport.GetBy("PrjId = @prjId AND IsDelete = 0 AND (ReportDate < @d OR (ReportDate = @d AND Id < @id)) ORDER BY ReportDate DESC, Id DESC",
                            new { prjId, d = currentDate, id = currentId }).FirstOrDefault();
                        break;
                }

                if (target != null && target.Id > 0)
                {
                    _dailyReportId = target.Id;
                    LoadReport(_dailyReportId);
                }
                else
                {
                    string msg = direction switch { "First" => "هذا هو أول تقرير.", "Last" => "هذا هو آخر تقرير.", "Next" => "لا توجد تقارير تالية.", "Prev" => "لا توجد تقارير سابقة.", _ => "" };
                    XtraMessageBox.Show(msg, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        private void SearchBySerial()
        {
            if (barManager1.ActiveEditItemLink != null)
                barManager1.ActiveEditItemLink.PostEditor();

            string serialStr = beiSearchNum.EditValue?.ToString() ?? "";
            if (string.IsNullOrEmpty(serialStr)) return;

            // Ensure 3 digits for consistent searching
            if (int.TryParse(serialStr, out int serialVal))
            {
                serialStr = serialVal.ToString("D3");
            }
            else return;

            if (_isDirty)
            {
                var res = XtraMessageBox.Show("هناك تغييرات غير محفوظة، هل تريد الحفظ قبل البحث؟", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel) return;
                if (res == DialogResult.Yes) { if (!SaveReport()) return; }
            }

            IOverlaySplashScreenHandle handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);
                
                int prjId = (_report?.PrjId > 0) ? _report.PrjId : (Session.SelectedProjectId ?? 1);
                
                // Search for reports ending with this serial for the same project
                var results = DC.DailyReport.GetBy("PrjId = @prjId AND IsDelete = 0 AND ReportNumber LIKE @search ORDER BY ReportDate DESC", 
                    new { prjId, search = $"%-{serialStr}" });

                if (results != null && results.Any())
                {
                    var target = results.First(); // Pick the most recent one if multiple exist (e.g., from different dates but same sequence - which shouldn't happen but safe to handle)
                    _dailyReportId = target.Id;
                    LoadReport(_dailyReportId);
                }
                else
                {
                    XtraMessageBox.Show($"لم يتم العثور على تقرير يحمل المسلسل ({serialStr}) لهذا المشروع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        private void bbiImportSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int prjId = (_report?.PrjId > 0) ? _report.PrjId : (Session.SelectedProjectId ?? 1);

            using (var frm = new frmImportSchedule(prjId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // If we are on Work Done or Planned Work tabs, we might want to refresh them 
                    // since the imported activities might now be available in the dropdowns.
                    if (xtraTabControl1.SelectedTabPage == tbWorkDoneToday || xtraTabControl1.SelectedTabPage == tbWorkPlannedTomorrow)
                    {
                        _initializedControls.Remove(xtraTabControl1.SelectedTabPage.Controls.OfType<NavigationFrame>().FirstOrDefault()?.SelectedPage?.Controls[0] as UserControl);
                        InitializeActiveTab();
                    }
                }
            }
        }

    }
}