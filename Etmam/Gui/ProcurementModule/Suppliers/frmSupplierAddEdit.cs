using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Add/Edit form for Suppliers (StakeholdersList): master data record with First/Prev/Next/Last
    /// navigation (same navigator pattern as frmPurchaseOrderAddEdit) — no approval workflow, since a supplier
    /// is a standalone master record. "بيانات المورد فئه فرد" group is only relevant when rgCategory = "فرد".</summary>
    public partial class frmSupplierAddEdit : XtraForm
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext dc => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private int _id = 0;                            // 0 = New, >0 = Edit
        private bool _isDirty = false;                   // Tracks unsaved changes
        private bool _anySaved = false;                  // At least one successful save (drives DialogResult on close)
        private bool _loading = false;                    // Suppresses dirty-tracking while fields are being filled
        private List<StakeholdersList> _list = new();     // Navigator cache
        private int _currentIndex = -1;                   // Current navigator position
        private ucAttachmentAddEdit? _ucAttachments;       // Embedded attachments panel ("المرفقات" تبويب)
        private DevExpress.XtraEditors.SpinEdit spinRating = null!;   // "تقييم المورد" — StakeholdersList.Rating (0 = غير مُقيَّم, 1-5 نجوم)
        private DevExpress.XtraEditors.LabelControl lblRating = null!;
        private DevExpress.XtraEditors.CheckEdit chkIsClient = null!;      // StakeholdersList.IsClient — يظهر في قائمة "المالك/العميل" عند إنشاء مشروع
        private DevExpress.XtraEditors.CheckEdit chkIsConsultant = null!;  // StakeholdersList.IsConsultant — يظهر في قائمة "الاستشاري" عند إنشاء مشروع
        private bool _clampingScore;                      // Reentrancy guard for OnEvaluationScoreChanged (setting .EditValue re-raises the same event)

        // "تقييم" tab score ceilings — match lblXxxDescription's stated weight (٪) on each field, and
        // lblFinalEvaluationFormula's "(4×التوريدات + 2×التوقيتات + 2×الكميات) / 3": at the max of every
        // field (50+25+25=100 points) the formula resolves to exactly 100, i.e. a 0-100% final score.
        private const int MaxDeliveryScore = 50;
        private const int MaxTimingScore = 25;
        private const int MaxQuantityScore = 25;

        // ── Constructor ───────────────────────────────────────────────────────
        public frmSupplierAddEdit(int id = 0)
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
            SetupLookups();
            SetupRatingControl();
            SetupStakeholderRoleControls();
            SetupEvaluationTab();
            SetupAttachments();
            Loadlist();

            if (id > 0)
            {
                _currentIndex = _list.FindIndex(r => r.Id == id);
                LoadRecordById(id);
            }
            else
            {
                NewRecord();
            }
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            bbiNew.ItemClick += (s, e) => SafeAction(() => { if (ConfirmNavigation()) NewRecord(); });
            bbiSave.ItemClick += (s, e) => SafeAction(() => SaveRecord());
            bbiPrint.ItemClick += (s, e) => PrintRecord();

            bbiFirst.ItemClick += (s, e) => NavigateFirst();
            bbiPrev.ItemClick += (s, e) => NavigatePrev();
            bbiNext.ItemClick += (s, e) => NavigateNext();
            bbiLast.ItemClick += (s, e) => NavigateLast();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return && beiSearch.EditValue != null)
                    FetchBySearch();
            };

            rgCategory.EditValueChanged += (s, e) => { if (_loading) return; UpdateIndividualGroupVisibility(); SetDirty(); };

            meSupplierName.EditValueChanged += OnFieldChanged;
            lueGroup.EditValueChanged += OnFieldChanged;
            chkActive.EditValueChanged += OnFieldChanged;

            meAddress.EditValueChanged += OnFieldChanged;
            txtNationality.EditValueChanged += OnFieldChanged;
            txtIdNumber.EditValueChanged += OnFieldChanged;
            deIssueDate.EditValueChanged += OnFieldChanged;
            deBirthDate.EditValueChanged += OnFieldChanged;
            txtPhone.EditValueChanged += OnFieldChanged;
            txtEmail.EditValueChanged += OnFieldChanged;

            txtCommercialRegNo.EditValueChanged += OnFieldChanged;
            deRegIssueDate.EditValueChanged += OnFieldChanged;
            deRegExpiryDate.EditValueChanged += OnFieldChanged;
            txtManagerName.EditValueChanged += OnFieldChanged;
            meCompanyAddress.EditValueChanged += OnFieldChanged;
            txtVatCertificateNo.EditValueChanged += OnFieldChanged;
            deVatIssueDate.EditValueChanged += OnFieldChanged;
            txtTaxRegNo.EditValueChanged += OnFieldChanged;

            txtContactName1.EditValueChanged += OnFieldChanged;
            txtContactPhone1.EditValueChanged += OnFieldChanged;
            txtContactName2.EditValueChanged += OnFieldChanged;
            txtContactPhone2.EditValueChanged += OnFieldChanged;

            picLogo.Click += PicLogo_Click;
            btnRemoveLogo.Click += BtnRemoveLogo_Click;
            btnCategory.Click += (s, e) => SafeAction(QuickAddCategory);

            this.FormClosing += FrmSupplierAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            txtSupplierCode.Properties.ReadOnly = true;

            // نفرغ عناصر الديزاينر (كانت قيمتها Value = null لكليهما، ما يمنع تمييز الاختيار) ونحدد قيمة صريحة لكل عنصر
            rgCategory.Properties.Items.Clear();
            rgCategory.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("شركة/مؤسسه", "شركة/مؤسسه"));
            rgCategory.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("فرد", "فرد"));

            lueGroup.Properties.ValueMember = "Id";
            lueGroup.Properties.DisplayMember = "MainCategory";
            lueGroup.Properties.NullText = "-- اختر المجموعة --";
            lueGroup.Properties.Columns.Clear();
            lueGroup.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MainCategory", "التصنيف الرئيسي"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubCategory", "التصنيف الفرعي")
            });
            RefreshGroupLookup();
        }

        private void RefreshGroupLookup()
        {
            lueGroup.Properties.DataSource = dc.StakeholdersCategory.GetAll();
        }

        /// <summary>btnCategory: quick-add a new supplier group/category — same pattern as
        /// frmItemAddEdit.btnCategory_Click (opens the small modal AddEdit, then just refreshes the lookup
        /// list on success; the newly added category isn't auto-selected, same as that precedent).</summary>
        private void QuickAddCategory()
        {
            using var frm = new Etmam.Gui.ProcurementMgt.Suppliers.frmSupplierCategoryAddEdit();
            if (frm.ShowDialog(this) != DialogResult.OK) return;

            RefreshGroupLookup();
        }

        /// <summary>"تقييم المورد" (StakeholdersList.Rating) has no designer control at all — added as a new row
        /// at the bottom of grpBasicInfo at runtime (grown to fit, with grpIndividualInfo shifted down by the
        /// same delta) instead of hand-editing the generated Designer.cs coordinates. tabBasicData.AutoScroll is
        /// enabled as a safety net in case that push leaves grpIndividualInfo taller than the visible tab page.</summary>
        private void SetupRatingControl()
        {
            lblRating = new DevExpress.XtraEditors.LabelControl
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Text = "تقييم المورد:"
            };
            lblRating.Appearance.Font = new Font("Cairo", 9F);
            lblRating.Appearance.Options.UseFont = true;

            spinRating = new DevExpress.XtraEditors.SpinEdit
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                MenuManager = barManager,
                Size = meSupplierName.Size with { Height = 31 }
            };
            spinRating.Properties.MinValue = 0;
            spinRating.Properties.MaxValue = 5;
            spinRating.Properties.IsFloatValue = false;
            spinRating.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            spinRating.Properties.DisplayFormat.FormatString = "n0";
            spinRating.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            spinRating.Properties.EditFormat.FormatString = "n0";

            int rowY = meSupplierName.Location.Y + meSupplierName.Height + 8;
            spinRating.Location = new Point(meSupplierName.Location.X, rowY);
            lblRating.Location = new Point(lblSupplierName.Location.X, rowY + 4);
            lblRating.Size = new Size(80, 23);

            grpBasicInfo.Controls.Add(spinRating);
            grpBasicInfo.Controls.Add(lblRating);

            int neededHeight = rowY + spinRating.Height + 12;
            int delta = neededHeight - grpBasicInfo.Height;
            if (delta > 0)
            {
                grpBasicInfo.Height = neededHeight;
                grpIndividualInfo.Location = grpIndividualInfo.Location with { Y = grpIndividualInfo.Location.Y + delta };
            }
            tabBasicData.AutoScroll = true;

            spinRating.EditValueChanged += OnFieldChanged;
        }

        /// <summary>"عميل/مالك مشروع" و"استشاري" (StakeholdersList.IsClient/IsConsultant) had no UI anywhere
        /// in the app — frmProjectAddEdit's Client/Consultant lookups filter by these flags, so without this
        /// a stakeholder could never appear there no matter how it was saved here. Added as a new row below
        /// spinRating/lblRating (same runtime-append pattern as SetupRatingControl, run right after it so
        /// rowY starts from whatever grpBasicInfo.Height already grew to).</summary>
        private void SetupStakeholderRoleControls()
        {
            chkIsClient = new DevExpress.XtraEditors.CheckEdit
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                MenuManager = barManager,
            };
            chkIsClient.Properties.Caption = "عميل/مالك مشروع";

            chkIsConsultant = new DevExpress.XtraEditors.CheckEdit
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                MenuManager = barManager,
            };
            chkIsConsultant.Properties.Caption = "استشاري";

            int rowY = spinRating.Location.Y + spinRating.Height + 10;
            chkIsClient.Location = new Point(meSupplierName.Location.X, rowY);
            chkIsClient.Size = new Size(140, 24);
            chkIsConsultant.Location = new Point(chkIsClient.Location.X + chkIsClient.Width + 12, rowY);
            chkIsConsultant.Size = new Size(110, 24);

            grpBasicInfo.Controls.Add(chkIsClient);
            grpBasicInfo.Controls.Add(chkIsConsultant);

            int neededHeight = rowY + chkIsClient.Height + 12;
            int delta = neededHeight - grpBasicInfo.Height;
            if (delta > 0)
            {
                grpBasicInfo.Height = neededHeight;
                grpIndividualInfo.Location = grpIndividualInfo.Location with { Y = grpIndividualInfo.Location.Y + delta };
            }

            chkIsClient.EditValueChanged += OnFieldChanged;
            chkIsConsultant.EditValueChanged += OnFieldChanged;
        }

        /// <summary>"التقييم" tab: three input scores (each capped per lblXxxDescription's stated weight) and a
        /// read-only "التقييم النهائي" recomputed live from lblFinalEvaluationFormula's formula. None of these
        /// have a backing column on StakeholdersList (only the simple 0-5 spinRating above is persisted), so
        /// this tab is a pure on-screen calculator — reset on every New/Load instead of round-tripped to the DB.</summary>
        private void SetupEvaluationTab()
        {
            ConfigureIntegerScoreEdit(txtDeliveryQualityScore);
            ConfigureIntegerScoreEdit(txtTimingQualityScore);
            ConfigureIntegerScoreEdit(txtQuantityQualityScore);

            txtFinalEvaluationScore.Properties.ReadOnly = true;
            txtFinalEvaluationScore.Properties.Appearance.BackColor = SystemColors.ControlLight;
            txtFinalEvaluationScore.Properties.Appearance.Options.UseBackColor = true;

            txtDeliveryQualityScore.EditValueChanged += (s, e) => OnEvaluationScoreChanged(txtDeliveryQualityScore, MaxDeliveryScore);
            txtTimingQualityScore.EditValueChanged += (s, e) => OnEvaluationScoreChanged(txtTimingQualityScore, MaxTimingScore);
            txtQuantityQualityScore.EditValueChanged += (s, e) => OnEvaluationScoreChanged(txtQuantityQualityScore, MaxQuantityScore);

            ResetEvaluationTab();
        }

        /// <summary>"d2" (0-99) keeps entry to a plain integer and rules out absurd values like 500 outright;
        /// the exact business ceiling (50/25/25) still needs OnEvaluationScoreChanged since a mask alone can't
        /// express a per-field max.</summary>
        private static void ConfigureIntegerScoreEdit(DevExpress.XtraEditors.TextEdit edit)
        {
            edit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            edit.Properties.Mask.EditMask = "d2";
            edit.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void OnEvaluationScoreChanged(DevExpress.XtraEditors.TextEdit edit, int max)
        {
            if (_loading || _clampingScore) return;

            if (int.TryParse(edit.Text?.Trim(), out int value))
            {
                int clamped = Math.Clamp(value, 0, max);
                if (clamped != value)
                {
                    _clampingScore = true;
                    edit.EditValue = clamped.ToString();
                    _clampingScore = false;
                }
            }

            SetDirty();
            RecalculateFinalEvaluation();
        }

        /// <summary>lblFinalEvaluationFormula: (4×التوريدات + 2×التوقيتات + 2×الكميات) / 3.</summary>
        private void RecalculateFinalEvaluation()
        {
            int delivery = ParseScore(txtDeliveryQualityScore);
            int timing = ParseScore(txtTimingQualityScore);
            int quantity = ParseScore(txtQuantityQualityScore);

            double final = (4.0 * delivery + 2.0 * timing + 2.0 * quantity) / 3.0;
            txtFinalEvaluationScore.Text = $"{final:0.##}%";
        }

        private static int ParseScore(DevExpress.XtraEditors.TextEdit edit) =>
            int.TryParse(edit.Text?.Trim(), out int v) ? v : 0;

        private void ResetEvaluationTab()
        {
            txtDeliveryQualityScore.Text = "";
            txtTimingQualityScore.Text = "";
            txtQuantityQualityScore.Text = "";
            RecalculateFinalEvaluation();
        }

        /// <summary>Embeds the reusable attachment control into the "المرفقات" tab — the tab shipped from the
        /// designer with an orphaned GridControl that was never parented to it (dead/no-op controls), so this
        /// replaces that with the same shared component every other Add/Edit form uses.</summary>
        private void SetupAttachments()
        {
            _ucAttachments = new ucAttachmentAddEdit { Dock = DockStyle.Fill };
            tabAttachments.Controls.Add(_ucAttachments);
            _ucAttachments.SaveRequired += SaveAndReturnId;
        }

        private int SaveAndReturnId()
        {
            if (!ValidateHeader()) return 0;
            return SaveRecord(silent: true) ? _id : 0;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _list = dc.StakeholdersList.GetBy("IsDelete = 0").OrderBy(s => s.Name).ToList();
        }

        private void LoadRecordById(int id)
        {
            var supplier = dc.StakeholdersList.Find(id);
            if (supplier == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NewRecord();
                return;
            }

            LoadRecord(supplier);
        }

        private void LoadRecord(StakeholdersList s)
        {
            _loading = true;
            _id = s.Id;

            txtSupplierCode.Text = FormatSupplierCode(s.Id);
            meSupplierName.Text = s.Name ?? "";
            chkActive.Checked = s.IsActive ?? true;
            rgCategory.EditValue = string.IsNullOrEmpty(s.Type) ? "شركة/مؤسسه" : s.Type;
            lueGroup.EditValue = s.CategoryId;
            spinRating.Value = s.Rating ?? 0;
            chkIsClient.Checked = s.IsClient ?? false;
            chkIsConsultant.Checked = s.IsConsultant ?? false;

            meAddress.Text = s.Address ?? "";
            txtNationality.Text = s.Nationality ?? "";
            txtIdNumber.Text = s.IdNumber ?? "";
            deIssueDate.EditValue = ParseDate(s.IdDate);
            deBirthDate.EditValue = ParseDate(s.DOB);
            txtPhone.Text = s.PhoneNumber ?? "";
            txtEmail.Text = s.Email ?? "";

            txtCommercialRegNo.Text = s.CommercialNumber ?? "";
            deRegIssueDate.EditValue = ParseDate(s.CommercialIssuedDate);
            deRegExpiryDate.EditValue = ParseDate(s.CommercialEndDate);
            txtManagerName.Text = s.CommercialManager ?? "";
            meCompanyAddress.Text = s.CommercialAddress ?? "";
            txtVatCertificateNo.Text = s.VATNumber ?? "";
            deVatIssueDate.EditValue = ParseDate(s.VATIssuedDate);
            txtTaxRegNo.Text = s.TaxNumber ?? "";

            txtContactName1.Text = s.ContactName1 ?? "";
            txtContactPhone1.Text = s.ContactPhone1 ?? "";
            txtContactName2.Text = s.ContactName2 ?? "";
            txtContactPhone2.Text = s.ContactPhone2 ?? "";

            LoadLogo(s.Logo);
            _ucAttachments?.LoadFor(nameof(StakeholdersList), _id);
            ResetEvaluationTab();

            UpdateIndividualGroupVisibility();
            UpdateNavigatorCaption();
            _loading = false;
            SetDirty(false);
        }

        // ── Record Operations (New / Save) ────────────────────────────────────
        private void NewRecord()
        {
            _loading = true;
            _id = 0;

            txtSupplierCode.Text = "جديد";
            meSupplierName.Text = "";
            chkActive.Checked = true;
            rgCategory.EditValue = "شركة/مؤسسه";
            lueGroup.EditValue = null;
            spinRating.Value = 0;
            chkIsClient.Checked = false;
            chkIsConsultant.Checked = false;

            meAddress.Text = "";
            txtNationality.Text = "";
            txtIdNumber.Text = "";
            deIssueDate.EditValue = null;
            deBirthDate.EditValue = null;
            txtPhone.Text = "";
            txtEmail.Text = "";

            txtCommercialRegNo.Text = "";
            deRegIssueDate.EditValue = null;
            deRegExpiryDate.EditValue = null;
            txtManagerName.Text = "";
            meCompanyAddress.Text = "";
            txtVatCertificateNo.Text = "";
            deVatIssueDate.EditValue = null;
            txtTaxRegNo.Text = "";

            txtContactName1.Text = "";
            txtContactPhone1.Text = "";
            txtContactName2.Text = "";
            txtContactPhone2.Text = "";

            LoadLogo(null);
            _ucAttachments?.LoadFor(nameof(StakeholdersList), 0);
            ResetEvaluationTab();

            _currentIndex = -1;
            UpdateIndividualGroupVisibility();
            UpdateNavigatorCaption();
            _loading = false;
            SetDirty(false);

            meSupplierName.Focus();
        }

        /// <summary>Loads the existing entity (when editing) before overwriting mapped fields, so columns this
        /// form has no UI for yet (IsVendor/PaymentTermsDays/CreditLimit/IsSponsor/IsSubcontractor/IsOther)
        /// survive the save untouched instead of being wiped to null.</summary>
        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            try
            {
                var entity = _id > 0 ? dc.StakeholdersList.Find(_id) : new StakeholdersList();
                entity ??= new StakeholdersList();

                entity.Name = meSupplierName.Text.Trim();
                entity.IsActive = chkActive.Checked;
                entity.Type = rgCategory.EditValue?.ToString();
                entity.CategoryId = lueGroup.EditValue as int?;
                entity.Rating = spinRating.Value > 0 ? (int)spinRating.Value : null;
                entity.IsClient = chkIsClient.Checked;
                entity.IsConsultant = chkIsConsultant.Checked;

                entity.Address = meAddress.Text.Trim();
                entity.Nationality = txtNationality.Text.Trim();
                entity.IdNumber = txtIdNumber.Text.Trim();
                entity.IdDate = FormatDate(deIssueDate.EditValue);
                entity.DOB = FormatDate(deBirthDate.EditValue);
                entity.PhoneNumber = txtPhone.Text.Trim();
                entity.Email = txtEmail.Text.Trim();

                entity.CommercialNumber = txtCommercialRegNo.Text.Trim();
                entity.CommercialIssuedDate = FormatDate(deRegIssueDate.EditValue);
                entity.CommercialEndDate = FormatDate(deRegExpiryDate.EditValue);
                entity.CommercialManager = txtManagerName.Text.Trim();
                entity.CommercialAddress = meCompanyAddress.Text.Trim();
                entity.VATNumber = txtVatCertificateNo.Text.Trim();
                entity.VATIssuedDate = FormatDate(deVatIssueDate.EditValue);
                entity.TaxNumber = txtTaxRegNo.Text.Trim();

                entity.ContactName1 = txtContactName1.Text.Trim();
                entity.ContactPhone1 = txtContactPhone1.Text.Trim();
                entity.ContactName2 = txtContactName2.Text.Trim();
                entity.ContactPhone2 = txtContactPhone2.Text.Trim();

                entity.Logo = GetLogoBytes();

                if (_id > 0)
                {
                    entity.UpdateDate = DateTime.Now;
                    entity.UpdateMachine = Session.Machine;
                    entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.StakeholdersList.Edit(_id, entity);
                }
                else
                {
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedMachine = Session.Machine;
                    entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    entity.IsDelete = false;
                    _id = dc.StakeholdersList.Add(entity);
                    entity.Id = _id;
                    txtSupplierCode.Text = FormatSupplierCode(_id);
                }

                _ucAttachments?.LoadFor(nameof(StakeholdersList), _id);

                Loadlist();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();
                SetDirty(false);
                _anySaved = true;

                if (!silent)
                {
                    XtraMessageBox.Show("تم الحفظ بنجاح ✓", "حفظ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ── Logo (شعار الشركة) ────────────────────────────────────────────────
        private void LoadLogo(byte[]? logo)
        {
            if (logo != null && logo.Length > 0)
            {
                using var ms = new MemoryStream(logo);
                picLogo.Image = Image.FromStream(ms);
            }
            else
            {
                picLogo.Image = null;
            }
        }

        private byte[]? GetLogoBytes()
        {
            if (picLogo.Image == null) return null;
            using var ms = new MemoryStream();
            picLogo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private void PicLogo_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "اختر شعار الشركة",
                Filter = "ملفات صور|*.bmp;*.jpg;*.jpeg;*.png;*.gif"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var img = Image.FromFile(ofd.FileName);
                picLogo.Image = new Bitmap(img);
                SetDirty();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الصورة:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoveLogo_Click(object? sender, EventArgs e)
        {
            if (picLogo.Image == null) return;
            if (XtraMessageBox.Show("هل تريد إلغاء شعار الشركة؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            picLogo.Image = null;
            SetDirty();
        }

        // ── Individual/Company Section Toggle ─────────────────────────────────
        /// <summary>"بيانات المورد فئه فرد" (grpIndividualInfo) only applies when rgCategory = "فرد"؛
        /// تبويب "الأوراق الحكومية" يبقى ظاهراً دوماً لأن بعض الأفراد (منشأة فردية) قد يملكون سجلاً تجارياً أيضاً.</summary>
        private void UpdateIndividualGroupVisibility()
        {
            grpIndividualInfo.Enabled = string.Equals(rgCategory.EditValue?.ToString(), "فرد", StringComparison.Ordinal);
        }

        // ── Navigation ────────────────────────────────────────────────────────
        private void NavigateFirst()
        {
            if (_list.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = 0;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex]); }
            finally { CloseOverlay(handle); }
        }

        private void NavigatePrev()
        {
            if (_list.Count == 0 || _currentIndex <= 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex--;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex]); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateNext()
        {
            if (_list.Count == 0 || _currentIndex >= _list.Count - 1) return;
            if (!ConfirmNavigation()) return;
            _currentIndex++;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex]); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateLast()
        {
            if (_list.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = _list.Count - 1;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex]); }
            finally { CloseOverlay(handle); }
        }

        private void FetchBySearch()
        {
            string term = beiSearch.EditValue?.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(term)) return;

            var found = _list.FirstOrDefault(s =>
                (s.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                (s.PhoneNumber?.Contains(term, StringComparison.OrdinalIgnoreCase) == true));

            if (found == null)
            {
                XtraMessageBox.Show($"لم يُعثر على نتائج للبحث: [{term}]", "بحث",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ConfirmNavigation()) return;
            _currentIndex = _list.IndexOf(found);
            var handle = ShowOverlay();
            try { LoadRecord(found); }
            finally { CloseOverlay(handle); }
        }

        // ── Print ─────────────────────────────────────────────────────────────
        private void PrintRecord()
        {
            if (_id <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ بيانات المورد قبل الطباعة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // لا يوجد بعد تقرير طباعة مخصص لبيانات المورد.
            XtraMessageBox.Show("طباعة بيانات المورد غير متاحة حالياً.", "تنبيه",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool ValidateHeader()
        {
            if (string.IsNullOrWhiteSpace(meSupplierName.Text))
            {
                XtraMessageBox.Show("يرجى إدخال اسم المورد.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                meSupplierName.Focus();
                return false;
            }
            return true;
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        /// <summary>internal so ucSuppliers' grid can render the same "كود المورد" text as this form.</summary>
        internal static string FormatSupplierCode(int id) => id > 0 ? $"SUP{id:D5}" : "جديد";

        private static DateTime? ParseDate(string? text) =>
            DateTime.TryParse(text, out var d) ? d : null;

        private static string? FormatDate(object? editValue) =>
            editValue is DateTime dt ? dt.ToString("yyyy-MM-dd") : null;

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"بيانات المورد  [{_list[_currentIndex].Name}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة / تعديل مورد — سجل جديد";

            bbiFirst.Enabled = _currentIndex > 0;
            bbiPrev.Enabled = _currentIndex > 0;
            bbiNext.Enabled = _currentIndex < _list.Count - 1;
            bbiLast.Enabled = _currentIndex < _list.Count - 1;
        }

        private void OnFieldChanged(object? sender, EventArgs e)
        {
            if (_loading) return;
            SetDirty();
        }

        private void SetDirty(bool value = true) => _isDirty = value;

        private bool ConfirmNavigation()
        {
            if (!_isDirty) return true;

            var result = XtraMessageBox.Show(
                "توجد تغييرات غير محفوظة. هل تريد الحفظ قبل الانتقال؟",
                "تغييرات غير محفوظة",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) { SaveRecord(); return true; }
            if (result == DialogResult.No) { SetDirty(false); return true; }
            return false; // Cancel
        }

        private void SafeAction(Action action)
        {
            var handle = ShowOverlay();
            try { action(); }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ غير متوقع:\n{ex.Message}", "خطأ",
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

        // ── Form Closing Guard ────────────────────────────────────────────────
        private void FrmSupplierAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                var result = XtraMessageBox.Show(
                    "توجد تغييرات غير محفوظة. هل تريد الحفظ قبل الإغلاق؟",
                    "تغييرات غير محفوظة",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) SafeAction(() => SaveRecord());
                else if (result == DialogResult.Cancel) { e.Cancel = true; return; }
            }

            this.DialogResult = _anySaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
