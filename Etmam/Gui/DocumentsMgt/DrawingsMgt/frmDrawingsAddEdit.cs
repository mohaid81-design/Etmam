using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmDrawingsAddEdit : DevExpress.XtraEditors.XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private int _id;
        private DrawingsRegisterList? _record;
        private bool _isDirty = false;
        private bool _isLoading = false;
        private ucDrawingsAttachment? _ucAttachments;
        private ucDrawingsAddEdit? _ucAddEdit;

        // Lookup caches for the Type → Category → SubCategory cascade
        private List<DrawingsType> _drawingTypes = new();
        private List<DrawingsCategory> _categories = new();
        private List<DrawingsSubCategory> _subCategories = new();
        private List<DrawingsIssuerList> _issuers = new();

        // CST (Consultant/Owner) review vocabulary — matches the keyword sets
        // DesignSystem.ApplyStatusColoring already checks for.
        private const string StatusPending = "قيد المراجعة";
        private const string StatusApproved = "معتمد";
        private const string StatusApprovedWithComments = "معتمد مع ملاحظات";
        private const string StatusRejected = "مرفوض";
        private const string StatusReviseResubmit = "يتطلب تعديل وإعادة تقديم";

        // DrawingsStatus lookup IDs (seeded in DatabaseInitializer) — system-managed, never a free picker.
        private const int OverallStatusDraft = 1;
        private const int OverallStatusSubmitted = 2;
        private const int OverallStatusReissued = 3;
        private const int OverallStatusClosed = 4;

        // Log tab — built at runtime (xtraTabPageLog starts empty in the Designer)
        private ComboBoxEdit cboCSTStatus = null!;
        private MemoEdit memCSTComment = null!;
        private DateEdit dtSubmittedDate = null!;
        private DateEdit dtCSTReturnedDate = null!;
        private DevExpress.XtraGrid.GridControl gridControlHistory = null!;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHistory = null!;

        public frmDrawingsAddEdit(int id = 0)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _id = id;

            SetupLookUps();
            BuildLogTab();
            WireToolbarEvents();
            LoadRecord(_id);

            _ucAttachments = new ucDrawingsAttachment();
            SetupNavigationPage(_ucAttachments, navigationFrameAttach);
            _ucAttachments.SaveRequired += SaveAndReturnId;

            _ucAddEdit = new ucDrawingsAddEdit();
            SetupNavigationPage(_ucAddEdit, navigationFrameDetails);

            if (_id > 0)
            {
                _ucAttachments.LoadForDrawing(_id);
                _ucAddEdit.LoadForDrawing(_id);
            }

            this.FormClosing += FrmDrawingsAddEdit_FormClosing;
        }

        private void SetupNavigationPage(UserControl control, NavigationFrame frame)
        {
            control.Dock = DockStyle.Fill;
            var page = new DevExpress.XtraBars.Navigation.NavigationPage();
            page.Controls.Add(control);
            frame.Pages.Add(page);
            frame.SelectedPage = page;
        }

        // ── Lookups (Type → Category → SubCategory cascade, Project, Issuer) ────

        private void SetupLookUps()
        {
            ConfigureLookUpEdit(lookUpEditPrj);
            ConfigureLookUpEdit(lueDrawingType);
            ConfigureLookUpEdit(lueCategory);
            ConfigureLookUpEdit(lueSubCategory);
            ConfigureLookUpEdit(lueDrawingIssuer);

            lookUpEditPrj.Properties.DataSource = DC.ProjectsList.GetBy("IsDelete = 0").ToList();
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.ValueMember = "Id";

            _drawingTypes = DC.DrawingsType.GetAll();
            lueDrawingType.Properties.DataSource = _drawingTypes;
            lueDrawingType.Properties.DisplayMember = "Name";
            lueDrawingType.Properties.ValueMember = "Id";

            _categories = DC.DrawingsCategory.GetBy("IsDelete = 0").ToList();
            _subCategories = DC.DrawingsSubCategory.GetBy("IsDelete = 0").ToList();
            UpdateCategoryDataSource();

            _issuers = DC.DrawingsIssuerList.GetBy("IsDelete = 0").ToList();
            lueDrawingIssuer.Properties.DataSource = _issuers;
            lueDrawingIssuer.Properties.DisplayMember = "Name";
            lueDrawingIssuer.Properties.ValueMember = "Id";

            lueDrawingType.EditValueChanged += (s, e) => { MarkDirty(); UpdateCategoryDataSource(); };
            lueCategory.EditValueChanged += (s, e) => { MarkDirty(); UpdateSubCategoryDataSource(); };

            btnSelectPrj.Click += BtnPrj_Click;
            btnSelectCategory.Click += BtnCategory_Click;
            btnSelectSubCategory.Click += BtnSubCategory_Click;
            btnSelectDrawingIssuer.Click += BtnDrawingIssuer_Click;
        }

        private void BtnPrj_Click(object? sender, EventArgs e)
        {
            using var frm = new frmProjectSelect();
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedProject != null)
            {
                lookUpEditPrj.Properties.DataSource = DC.ProjectsList.GetBy("IsDelete = 0").ToList();
                lookUpEditPrj.EditValue = frm.SelectedProject.Id;
            }
        }

        private void BtnCategory_Click(object? sender, EventArgs e)
        {
            using var frm = new frmDrawingsCategorySelect();
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedCategory != null)
            {
                _categories = DC.DrawingsCategory.GetBy("IsDelete = 0").ToList();
                lueCategory.Properties.DataSource = _categories;
                lueCategory.EditValue = frm.SelectedCategory.Id;
                UpdateSubCategoryDataSource();
            }
        }

        private void BtnSubCategory_Click(object? sender, EventArgs e)
        {
            using var frm = new frmDrawingsSubCategorySelect();
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedSubCategory != null)
            {
                _subCategories = DC.DrawingsSubCategory.GetBy("IsDelete = 0").ToList();
                lueSubCategory.Properties.DataSource = _subCategories;
                lueSubCategory.EditValue = frm.SelectedSubCategory.Id;
            }
        }

        private void BtnDrawingIssuer_Click(object? sender, EventArgs e)
        {
            using var frm = new frmDrawingsIssuerSelect();
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedIssuer != null)
            {
                _issuers = DC.DrawingsIssuerList.GetBy("IsDelete = 0").ToList();
                lueDrawingIssuer.Properties.DataSource = _issuers;
                lueDrawingIssuer.EditValue = frm.SelectedIssuer.Id;
            }
        }

        private void ConfigureLookUpEdit(LookUpEdit lookUpEdit)
        {
            lookUpEdit.Properties.NullText = "";
            lookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            lookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            lookUpEdit.Properties.Buttons.Clear();
            lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            });

            lookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
                    lookUpEdit.EditValue = null;
            };
        }

        private int? GetLookUpValue(LookUpEdit lookUpEdit)
        {
            var val = lookUpEdit.EditValue;
            if (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()))
                return null;
            if (int.TryParse(val.ToString(), out int res))
                return res;
            return null;
        }

        private void UpdateCategoryDataSource()
        {
            var typeId = GetLookUpValue(lueDrawingType);
            var typeName = typeId != null ? _drawingTypes.FirstOrDefault(t => t.Id == typeId)?.Name : null;

            var categoryIds = _subCategories
                .Where(s => (typeName == null || s.Type == typeName) && s.CategoryId != null)
                .Select(s => s.CategoryId!.Value)
                .Distinct()
                .ToHashSet();

            var categories = _categories.Where(c => categoryIds.Contains(c.Id)).ToList();

            lueCategory.Properties.DataSource = categories;
            lueCategory.Properties.DisplayMember = "Name";
            lueCategory.Properties.ValueMember = "Id";

            var currentCategoryId = GetLookUpValue(lueCategory);
            if (currentCategoryId != null && !categories.Any(c => c.Id == currentCategoryId))
                lueCategory.EditValue = null;

            UpdateSubCategoryDataSource();
        }

        private void UpdateSubCategoryDataSource()
        {
            var typeId = GetLookUpValue(lueDrawingType);
            var typeName = typeId != null ? _drawingTypes.FirstOrDefault(t => t.Id == typeId)?.Name : null;
            var categoryId = GetLookUpValue(lueCategory);

            var filtered = _subCategories
                .Where(s => (typeName == null || s.Type == typeName)
                         && (categoryId == null || s.CategoryId == categoryId))
                .ToList();

            lueSubCategory.Properties.DataSource = filtered;
            lueSubCategory.Properties.DisplayMember = "Name";
            lueSubCategory.Properties.ValueMember = "Id";

            if (GetLookUpValue(lueSubCategory) is int currentSubId && !filtered.Any(x => x.Id == currentSubId))
                lueSubCategory.EditValue = null;
        }

        // ── Log tab: CST review recording + revision history ────────────────────

        private void BuildLogTab()
        {
            var panelCst = new PanelControl { Dock = DockStyle.Top, Height = 160 };
            panelCst.Appearance.BorderColor = Color.Transparent;
            panelCst.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            var lblCst = new LabelControl { Text = "حالة مراجعة الاستشاري/المالك:", Location = new Point(950, 15), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            cboCSTStatus = new ComboBoxEdit { Location = new Point(650, 12), Width = 280, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            cboCSTStatus.Properties.Items.AddRange(new object[] { StatusPending, StatusApproved, StatusApprovedWithComments, StatusRejected, StatusReviseResubmit });
            cboCSTStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            var lblSubmitted = new LabelControl { Text = "تاريخ الإرسال:", Location = new Point(950, 55), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            dtSubmittedDate = new DateEdit { Location = new Point(650, 52), Width = 280, Enabled = false, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            var lblReturned = new LabelControl { Text = "تاريخ ورود الرد:", Location = new Point(950, 92), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            dtCSTReturnedDate = new DateEdit { Location = new Point(650, 89), Width = 280, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            var lblComment = new LabelControl { Text = "ملاحظات المراجعة:", Location = new Point(950, 129), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            memCSTComment = new MemoEdit { Location = new Point(30, 12), Width = 600, Height = 130, Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left };

            panelCst.Controls.AddRange(new Control[] { lblCst, cboCSTStatus, lblSubmitted, dtSubmittedDate, lblReturned, dtCSTReturnedDate, lblComment, memCSTComment });

            var lblHistory = new LabelControl { Text = "سجل الإصدارات السابقة لهذا المخطط:", Dock = DockStyle.Top, Height = 24, Padding = new Padding(6) };

            gridControlHistory = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
            gridViewHistory = new DevExpress.XtraGrid.Views.Grid.GridView(gridControlHistory);
            gridControlHistory.MainView = gridViewHistory;
            gridControlHistory.ViewCollection.Add(gridViewHistory);
            gridViewHistory.OptionsView.ShowGroupPanel = false;
            gridViewHistory.OptionsBehavior.Editable = false;
            gridViewHistory.Columns.AddRange(new[]
            {
                new DevExpress.XtraGrid.Columns.GridColumn { FieldName = "Rev", Caption = "الإصدار", Visible = true, VisibleIndex = 0 },
                new DevExpress.XtraGrid.Columns.GridColumn { FieldName = "PreparedDate", Caption = "تاريخ الإصدار", Visible = true, VisibleIndex = 1 },
                new DevExpress.XtraGrid.Columns.GridColumn { FieldName = "CSTReviewStatus", Caption = "نتيجة المراجعة", Visible = true, VisibleIndex = 2 },
                new DevExpress.XtraGrid.Columns.GridColumn { FieldName = "CSTReviewComment", Caption = "الملاحظات", Visible = true, VisibleIndex = 3 },
            });
            DesignSystem.ApplyStatusColoring(gridViewHistory, "CSTReviewStatus");

            xtraTabPageLog.Controls.Add(gridControlHistory);
            xtraTabPageLog.Controls.Add(panelCst);
            xtraTabPageLog.Controls.Add(lblHistory);

            cboCSTStatus.EditValueChanged += (s, e) => MarkDirty();
            memCSTComment.EditValueChanged += (s, e) => MarkDirty();
            dtCSTReturnedDate.EditValueChanged += (s, e) => MarkDirty();
        }

        private void LoadRevisionHistory()
        {
            if (_record == null || _record.Num == null || _id <= 0)
            {
                gridControlHistory.DataSource = null;
                return;
            }

            var history = DC.DrawingsRegisterList.GetBy(
                "IsDelete = 0 AND Num = @num AND Id <> @id ORDER BY Rev DESC",
                new { num = _record.Num, id = _id }).ToList();

            gridControlHistory.DataSource = history;
            gridViewHistory.RefreshData();
        }

        private void UpdateStatusBadge()
        {
            int statusId = _record?.OverallStatus ?? OverallStatusDraft;
            string name = DC.DrawingsStatus.Find(statusId)?.Name ?? "مسودة";
            bsiStatus.Caption = $"الحالة: {name}";
        }

        private static DateTime? ParseDate(string? s) => DateTime.TryParse(s, out var d) ? d : null;

        // ── Toolbar wiring ─────────────────────────────────────────────────────

        private void WireToolbarEvents()
        {
            bbiNew.ItemClick += BbiNew_ItemClick;
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiPrint.ItemClick += BbiPrint_ItemClick;
            btnReIssue.ItemClick += BtnReIssue_ItemClick;
            btnSend.ItemClick += (s, e) =>
                XtraMessageBox.Show("ميزة الإرسال عبر البريد الإلكتروني قيد التطوير.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            bbiFirst.ItemClick += (s, e) => Navigate("First");
            bbiPrev.ItemClick += (s, e) => Navigate("Prev");
            bbiNext.ItemClick += (s, e) => Navigate("Next");
            bbiLast.ItemClick += (s, e) => Navigate("Last");

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return && beiSearchNum.EditValue != null)
                    FetchBySearch();
            };

            // Mark dirty on any field change
            lookUpEditPrj.EditValueChanged += (s, e) => MarkDirty();
            dtPreparedDate.EditValueChanged += (s, e) => MarkDirty();
            memDocName.EditValueChanged += (s, e) => MarkDirty();
            cboPurpose.EditValueChanged += (s, e) => MarkDirty();
            txtRegisterNo.EditValueChanged += (s, e) => MarkDirty();
            lueSubCategory.EditValueChanged += (s, e) => MarkDirty();
            lueDrawingIssuer.EditValueChanged += (s, e) => MarkDirty();
        }

        private void MarkDirty()
        {
            if (!_isLoading) _isDirty = true;
        }

        // ── Load / Refresh ────────────────────────────────────────────────────

        private void LoadRecord(int id)
        {
            _isLoading = true;
            try
            {
                if (id > 0)
                {
                    _record = DC.DrawingsRegisterList.Find(id);
                    if (_record == null)
                    {
                        XtraMessageBox.Show("لم يتم العثور على المخطط المطلوب.", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    lookUpEditPrj.EditValue = _record.PrjId;
                    txtNum.Text = _record.Num?.ToString() ?? "";
                    txtRegisterNo.Text = _record.RegisterNo ?? "";
                    txtRev.Text = _record.Rev?.ToString() ?? "0";
                    dtPreparedDate.EditValue = _record.PreparedDate;
                    lueDrawingType.EditValue = _record.Type;
                    UpdateCategoryDataSource();
                    lueCategory.EditValue = _record.CategoryId;
                    UpdateSubCategoryDataSource();
                    lueSubCategory.EditValue = _record.SubCategory;
                    memDocName.Text = _record.DocName ?? _record.Description ?? "";
                    cboPurpose.EditValue = _record.Floor ?? "للمراجعه و الاعتماد";
                    lueDrawingIssuer.EditValue = _record.DrawingIssuer;

                    cboCSTStatus.EditValue = string.IsNullOrEmpty(_record.CSTReviewStatus) ? StatusPending : _record.CSTReviewStatus;
                    memCSTComment.Text = _record.CSTReviewComment ?? "";
                    dtSubmittedDate.EditValue = ParseDate(_record.SubmittedDate);
                    dtCSTReturnedDate.EditValue = ParseDate(_record.CSTReturnedDate);

                    Text = $"طلب اعتماد مخطط - {_record.DocName ?? _record.Num?.ToString()}";
                }
                else
                {
                    _record = new DrawingsRegisterList { OverallStatus = OverallStatusDraft };
                    lookUpEditPrj.EditValue = Session.SelectedProjectId;
                    txtNum.Text = GenerateNextNum();
                    txtRegisterNo.Text = "";
                    txtRev.Text = "0";
                    dtPreparedDate.EditValue = DateTime.Today;
                    lueDrawingType.EditValue = null;
                    UpdateCategoryDataSource();
                    lueCategory.EditValue = null;
                    UpdateSubCategoryDataSource();
                    lueSubCategory.EditValue = null;
                    memDocName.Text = "";
                    cboPurpose.EditValue = "للمراجعه و الاعتماد";
                    lueDrawingIssuer.EditValue = null;

                    cboCSTStatus.EditValue = StatusPending;
                    memCSTComment.Text = "";
                    dtSubmittedDate.EditValue = null;
                    dtCSTReturnedDate.EditValue = null;

                    Text = "طلب اعتماد مخطط - جديد";
                }

                LoadRevisionHistory();
                UpdateStatusBadge();
                _isDirty = false;
            }
            finally
            {
                _isLoading = false;
            }
        }

        private string GenerateNextNum()
        {
            var all = DC.DrawingsRegisterList.GetBy("IsDelete = 0");
            int maxNum = all.Any() ? all.Max(r => r.Num ?? 0) : 0;
            return (maxNum + 1).ToString("D3");
        }

        // ── Save ───────────────────────────────────────────────────────────────

        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e) => SaveRecord();

        /// <summary>
        /// Called by ucDrawingsAddEdit.SaveRequired — silently saves and returns the new drawing ID.
        /// Returns 0 if validation fails.
        /// </summary>
        private int SaveAndReturnId() => SaveRecord(silent: true) ? _id : 0;

        private bool SaveRecord(bool silent = false)
        {
            if (GetLookUpValue(lookUpEditPrj) == null)
            {
                XtraMessageBox.Show("الرجاء تحديد اسم المشروع.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (GetLookUpValue(lueDrawingType) == null)
            {
                XtraMessageBox.Show("الرجاء تحديد نوع المخطط.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(memDocName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال وصف/اسم المخطط.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_record == null) _record = new DrawingsRegisterList();

            _record.PrjId = GetLookUpValue(lookUpEditPrj);
            _record.Num = int.TryParse(txtNum.Text, out int num) ? num : (int?)null;
            _record.RegisterNo = txtRegisterNo.Text.Trim();
            _record.Rev = int.TryParse(txtRev.Text, out int rev) ? rev : 0;
            _record.PreparedDate = dtPreparedDate.EditValue as DateTime?;
            _record.Type = GetLookUpValue(lueDrawingType);
            _record.CategoryId = GetLookUpValue(lueCategory);
            _record.SubCategory = GetLookUpValue(lueSubCategory);
            _record.DocName = memDocName.Text.Trim();
            _record.Description = memDocName.Text.Trim();
            _record.Floor = cboPurpose.EditValue?.ToString();
            _record.DrawingIssuer = GetLookUpValue(lueDrawingIssuer);

            _record.CSTReviewStatus = cboCSTStatus.EditValue?.ToString();
            _record.CSTReviewComment = memCSTComment.Text.Trim();
            if (dtSubmittedDate.EditValue == null) dtSubmittedDate.EditValue = DateTime.Now;
            _record.SubmittedDate = ((DateTime)dtSubmittedDate.EditValue).ToString("yyyy-MM-dd");
            _record.CSTReturnedDate = dtCSTReturnedDate.EditValue is DateTime returnedDate
                ? returnedDate.ToString("yyyy-MM-dd")
                : null;

            bool isReviewApproved = _record.CSTReviewStatus == StatusApproved || _record.CSTReviewStatus == StatusApprovedWithComments;
            _record.OverallStatus = isReviewApproved ? OverallStatusClosed : OverallStatusSubmitted;

            if (_id <= 0)
            {
                _record.CreatedBy = Session.CurrentUser?.Id ?? 0;
                _record.CreatedDate = DateTime.Now;
                _record.CreatedMachine = Session.Machine;
            }
            else
            {
                _record.UpdateBy = Session.CurrentUser?.Id ?? 0;
                _record.UpdateDate = DateTime.Now;
                _record.UpdateMachine = Session.Machine;
            }

            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);

                if (_id > 0)
                {
                    DC.DrawingsRegisterList.Edit(_id, _record);
                }
                else
                {
                    _id = DC.DrawingsRegisterList.Add(_record);
                    Text = $"طلب اعتماد مخطط - {_record.DocName}";
                }

                _ucAddEdit?.SaveData(_id);

                _isDirty = false;
                UpdateStatusBadge();
                LoadRevisionHistory();

                if (!silent)
                {
                    XtraMessageBox.Show("تم حفظ المخطط بنجاح.", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // After saving, refresh attachments/items with the real drawing ID
                _ucAttachments?.LoadForDrawing(_id);
                _ucAddEdit?.LoadForDrawing(_id);

                DialogResult = DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ أثناء الحفظ: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        // ── New ────────────────────────────────────────────────────────────────

        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_isDirty)
            {
                var r = XtraMessageBox.Show("هناك تغييرات غير محفوظة. هل تريد الحفظ أولاً؟",
                    "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Cancel) return;
                if (r == DialogResult.Yes && !SaveRecord()) return;
            }
            _id = 0;
            LoadRecord(0);
            _ucAttachments?.LoadForDrawing(0);
            _ucAddEdit?.LoadForDrawing(0);
        }

        // ── Re-issue (new revision) ──────────────────────────────────────────────

        private void BtnReIssue_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_id <= 0 || _record == null)
            {
                XtraMessageBox.Show("يجب حفظ المخطط أولاً قبل إعادة إصداره.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(
                    "سيتم إنشاء إصدار جديد من هذا المخطط لبدء دورة مراجعة جديدة، وسيُعتبر الإصدار الحالي إصداراً سابقاً. هل تريد المتابعة؟",
                    "تأكيد إعادة الإصدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (_isDirty && !SaveRecord(silent: true)) return;

            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);

                int maxRev = DC.DrawingsRegisterList
                    .GetBy("IsDelete = 0 AND Num = @num", new { num = _record.Num })
                    .Max(r => r.Rev ?? 0);

                var newRecord = new DrawingsRegisterList
                {
                    Num = _record.Num,
                    RegisterNo = _record.RegisterNo,
                    Rev = maxRev + 1,
                    PreparedDate = DateTime.Today,
                    Type = _record.Type,
                    CategoryId = _record.CategoryId,
                    SubCategory = _record.SubCategory,
                    DocName = _record.DocName,
                    Description = _record.Description,
                    Floor = _record.Floor,
                    DrawingIssuer = _record.DrawingIssuer,
                    PrjId = _record.PrjId,
                    OverallStatus = OverallStatusSubmitted,
                    SubmittedDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    CSTReviewStatus = StatusPending,
                    CSTReviewComment = null,
                    CSTReturnedDate = null,
                    CreatedBy = Session.CurrentUser?.Id ?? 0,
                    CreatedDate = DateTime.Now,
                    CreatedMachine = Session.Machine
                };

                int oldId = _id;
                int newId = DC.DrawingsRegisterList.Add(newRecord);

                // Carry the line items (still in memory from the old revision) forward to the new one
                _ucAddEdit?.SaveData(newId);

                // Mark the old revision as superseded
                _record.OverallStatus = OverallStatusReissued;
                DC.DrawingsRegisterList.Edit(oldId, _record);

                XtraMessageBox.Show($"تم إنشاء الإصدار رقم {newRecord.Rev} بنجاح.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _id = newId;
                LoadRecord(_id);
                _ucAttachments?.LoadForDrawing(_id);
                _ucAddEdit?.LoadForDrawing(_id);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ أثناء إعادة الإصدار: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        // ── Navigation ─────────────────────────────────────────────────────────

        private void Navigate(string direction)
        {
            if (_isDirty)
            {
                var r = XtraMessageBox.Show("هناك تغييرات غير محفوظة. هل تريد الحفظ قبل الانتقال؟",
                    "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Cancel) return;
                if (r == DialogResult.Yes && !SaveRecord()) return;
            }

            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);
                DrawingsRegisterList? target = null;

                switch (direction)
                {
                    case "First":
                        target = DC.DrawingsRegisterList.GetBy(
                            "IsDelete = 0 ORDER BY Num ASC, Rev ASC").FirstOrDefault();
                        break;
                    case "Last":
                        target = DC.DrawingsRegisterList.GetBy(
                            "IsDelete = 0 ORDER BY Num DESC, Rev DESC").FirstOrDefault();
                        break;
                    case "Next":
                        target = DC.DrawingsRegisterList.GetBy(
                            "IsDelete = 0 AND Id > @id ORDER BY Id ASC",
                            new { id = _id }).FirstOrDefault();
                        break;
                    case "Prev":
                        target = DC.DrawingsRegisterList.GetBy(
                            "IsDelete = 0 AND Id < @id ORDER BY Id DESC",
                            new { id = _id }).FirstOrDefault();
                        break;
                }

                if (target != null)
                {
                    _id = target.Id;
                    LoadRecord(_id);
                    _ucAttachments?.LoadForDrawing(_id);
                    _ucAddEdit?.LoadForDrawing(_id);
                }
                else
                {
                    string msg = direction switch
                    {
                        "First" => "هذا أول سجل.",
                        "Last" => "هذا آخر سجل.",
                        "Next" => "لا توجد سجلات تالية.",
                        _ => "لا توجد سجلات سابقة."
                    };
                    XtraMessageBox.Show(msg, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        // ── Search ─────────────────────────────────────────────────────────────

        private void FetchBySearch()
        {
            string term = beiSearchNum.EditValue?.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(term) || !int.TryParse(term, out int num)) return;

            var result = DC.DrawingsRegisterList.GetBy(
                "IsDelete = 0 AND Num = @num ORDER BY Rev DESC", new { num }).FirstOrDefault();

            if (result == null)
            {
                XtraMessageBox.Show($"لم يتم العثور على مخطط برقم ({num}).", "بحث",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _id = result.Id;
            LoadRecord(_id);
            _ucAttachments?.LoadForDrawing(_id);
            _ucAddEdit?.LoadForDrawing(_id);
        }

        // ── Print ──────────────────────────────────────────────────────────────

        private void BbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("ميزة الطباعة قيد التطوير.", "تنبيه",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Form closing guard ─────────────────────────────────────────────────

        private void FrmDrawingsAddEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                var r = XtraMessageBox.Show("هناك تغييرات غير محفوظة. هل تريد الحفظ قبل الإغلاق؟",
                    "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (!SaveRecord()) e.Cancel = true;
                }
                else if (r == DialogResult.Cancel) e.Cancel = true;
            }
        }
    }
}
