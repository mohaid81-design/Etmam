using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmCIRAddEdit : DevExpress.XtraEditors.XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private int _id;

        /// <summary>The saved record's Id — for a new request this becomes the freshly-generated Id
        /// only after SaveRecord's DC.Add call succeeds (0 beforehand). Lets callers (ucCIR.OpenForm)
        /// focus the right grid row after ShowDialog returns OK, without having to guess the Id of a
        /// record that didn't exist when the dialog was opened.</summary>
        public int SavedId => _id;
        private ConstructionInspectionRequestList? _record;
        private List<DisciplinesList> _disciplines = new();
        private List<SecondaryDisciplinesList> _secondaryDisciplines = new();
        private List<InspectionActivityList> _inspectionActivities = new();
        private List<BuildingsList> _buildings = new();
        private List<FloorsList> _floors = new();
        private bool _isDirty = false;
        private bool _isLoading = false;
        private readonly bool _viewOnly;
        private Etmam.ucAttachmentAddEdit? _ucAttachments;

        // Log tab — built at runtime (xtraTabPageLog starts empty in the Designer)
        private ComboBoxEdit cboCSTStatus = null!;
        private MemoEdit memCSTComment = null!;
        private DateEdit dtSubmittedDate = null!;
        private DateEdit dtCSTReturnedDate = null!;
        private TextEdit txtReviewedBy = null!;
        private TextEdit txtReviewedJobTitle = null!;
        private TextEdit txtApprovedBy = null!;
        private TextEdit txtApprovedJobTitle = null!;
        private DevExpress.XtraGrid.GridControl gridControlHistory = null!;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHistory = null!;

        /// <summary>viewOnly=true (ucCIR's "فتح" button) opens the record read-only — no field can be
        /// edited and New/Save/إعادة إصدار/إرسال are all disabled regardless of the current user's own
        /// grants for those, leaving only Navigate/Search/Print. Distinct from "تعديل" (viewOnly=false),
        /// which additionally requires PermNames.CIRSave — see ucCIR.OpenForm.</summary>
        public frmCIRAddEdit(int id = 0, bool viewOnly = false)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _id = id;
            _viewOnly = viewOnly;

            SetupLookUps();
            BuildLogTab();
            WireToolbarEvents();
            LoadRecord(_id);

            _ucAttachments = new Etmam.ucAttachmentAddEdit();
            SetupNavigationPage(_ucAttachments, navigationFrameAttach);
            _ucAttachments.SaveRequired += SaveAndReturnId;
            if (_id > 0) _ucAttachments.LoadFor("ConstructionInspectionRequestList", _id);

            if (_viewOnly) ApplyViewOnlyMode();
            else if (!PermissionService.HasPermission(PermNames.CIRConsultantAction)) ApplyConsultantActionReadOnly();

            this.FormClosing += FrmCIRAddEdit_FormClosing;
        }

        /// <summary>Disables every data-entry control and the modifying toolbar actions (New/Save/
        /// إعادة إصدار/إرسال), leaving Navigate/Search/Print usable — called once, after all controls
        /// exist (including the Log tab's runtime-built ones from BuildLogTab).</summary>
        private void ApplyViewOnlyMode()
        {
            Text += " - عرض فقط";

            bbiNew.Enabled = false;
            bbiSave.Enabled = false;
            btnReIssue.Enabled = false;
            btnSend.Enabled = false;
            btnApproved.Enabled = false;

            foreach (var control in new Control[]
            {
                lueProject, btnSelectPrj, lueDiscipline, btnSelectDiscipline, lueSecondaryDiscipline, btnSelectSecondaryDiscipline,
                lueInspectionActivity, btnSelectInspectionActivity,
                txtRegisterNo, dtPreparedDate, memDescription, chkDescription,
                txtBOQRef, txtDWGRef, txtMSRef, txtSpecRef, memLocation,
                lueBuilding, btnSelectBuilding, lueFloor, btnSelectFloor, dtRequestedDate, timeRequestedTime,
                cboCSTStatus, memCSTComment, dtSubmittedDate, dtCSTReturnedDate,
                txtReviewedBy, txtReviewedJobTitle, txtApprovedBy, txtApprovedJobTitle,
            })
            {
                control.Enabled = false;
            }
        }

        /// <summary>Disables just the CST/owner review fields on the Log tab (حالة المراجعة، الملاحظات،
        /// التواريخ، أسماء المراجع/المعتمد) for users lacking PermNames.CIRConsultantAction — everything
        /// else on the form (project data, discipline, building/floor, attachments, New/Save/Print/Send)
        /// stays governed by its own separate permission. Distinct from ApplyViewOnlyMode, which disables
        /// the entire form.</summary>
        private void ApplyConsultantActionReadOnly()
        {
            foreach (var control in new Control[]
            {
                cboCSTStatus, memCSTComment, dtSubmittedDate, dtCSTReturnedDate,
                txtReviewedBy, txtReviewedJobTitle, txtApprovedBy, txtApprovedJobTitle,
            })
            {
                control.Enabled = false;
            }
        }

        private void SetupNavigationPage(UserControl control, DevExpress.XtraBars.Navigation.NavigationFrame frame)
        {
            control.Dock = DockStyle.Fill;
            var page = new DevExpress.XtraBars.Navigation.NavigationPage();
            page.Controls.Add(control);
            frame.Pages.Add(page);
            frame.SelectedPage = page;
        }

        // ── Lookups (Project, Discipline) ─────────────────────────────────────

        /// <summary>lueProject's list is restricted to the projects the current user is actually
        /// granted (same PermissionService.GrantedProjectIds source ucCIR's own project filter uses)
        /// — not every project in the system. Re-fetched on every QueryPopUp (see SetupLookUps) so a
        /// grant added while this form is open takes effect without reopening it.</summary>
        private List<ProjectsList> GrantedProjects()
        {
            var grantedIds = PermissionService.GrantedProjectIds(DC);
            return DC.ProjectsList.GetBy("IsDelete = 0")
                .Where(p => grantedIds.Contains(p.Id))
                .OrderBy(p => p.Name)
                .ToList();
        }

        private void SetupLookUps()
        {
            ConfigureLookUpEdit(lueProject);
            lueProject.Properties.DataSource = GrantedProjects();
            lueProject.Properties.DisplayMember = "Name";
            lueProject.Properties.ValueMember = "Id";
            lueProject.QueryPopUp += (s, e) =>
            {
                lueProject.Properties.DataSource = GrantedProjects();
            };

            lueDiscipline.Properties.NullText = "";
            lueDiscipline.Properties.PopupSizeable = false;
            lueDiscipline.Properties.ShowHeader = false;
            _disciplines = DC.DisciplinesList.GetBy("IsDelete = 0").ToList();
            lueDiscipline.Properties.DataSource = _disciplines;
            lueDiscipline.Properties.DisplayMember = "Name";
            lueDiscipline.Properties.ValueMember = "Id";
            lueDiscipline.Properties.Columns.Clear();
            lueDiscipline.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نوع الفحص"));
            lueDiscipline.EditValueChanged += (s, e) => UpdateSecondaryDisciplineDataSource();
            lueDiscipline.QueryPopUp += (s, e) =>
            {
                _disciplines = DC.DisciplinesList.GetBy("IsDelete = 0").ToList();
                lueDiscipline.Properties.DataSource = _disciplines;
            };

            lueSecondaryDiscipline.Properties.NullText = "";
            lueSecondaryDiscipline.Properties.PopupSizeable = false;
            lueSecondaryDiscipline.Properties.ShowHeader = false;
            lueSecondaryDiscipline.Properties.DisplayMember = "Name";
            lueSecondaryDiscipline.Properties.ValueMember = "Id";
            lueSecondaryDiscipline.Properties.Columns.Clear();
            lueSecondaryDiscipline.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "التخصص الثانوي"));
            _secondaryDisciplines = DC.SecondaryDisciplinesList.GetBy("IsDelete = 0").ToList();
            UpdateSecondaryDisciplineDataSource();
            lueSecondaryDiscipline.QueryPopUp += (s, e) =>
            {
                _secondaryDisciplines = DC.SecondaryDisciplinesList.GetBy("IsDelete = 0").ToList();
                UpdateSecondaryDisciplineDataSource();
            };
            lueSecondaryDiscipline.EditValueChanged += (s, e) => UpdateInspectionActivityDataSource();

            lueInspectionActivity.Properties.NullText = "";
            lueInspectionActivity.Properties.PopupSizeable = false;
            lueInspectionActivity.Properties.ShowHeader = false;
            lueInspectionActivity.Properties.DisplayMember = "Name";
            lueInspectionActivity.Properties.ValueMember = "Id";
            lueInspectionActivity.Properties.Columns.Clear();
            lueInspectionActivity.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "نشاط الفحص"));
            _inspectionActivities = DC.InspectionActivityList.GetBy("IsDelete = 0").ToList();
            UpdateInspectionActivityDataSource();
            lueInspectionActivity.QueryPopUp += (s, e) =>
            {
                _inspectionActivities = DC.InspectionActivityList.GetBy("IsDelete = 0").ToList();
                UpdateInspectionActivityDataSource();
            };

            lueBuilding.Properties.NullText = "";
            lueBuilding.Properties.PopupSizeable = false;
            lueBuilding.Properties.ShowHeader = false;
            lueBuilding.Properties.DisplayMember = "Name";
            lueBuilding.Properties.ValueMember = "Id";
            lueBuilding.Properties.Columns.Clear();
            lueBuilding.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "المبنى"));

            lueFloor.Properties.NullText = "";
            lueFloor.Properties.DisplayMember = "Name";
            lueFloor.Properties.ValueMember = "Id";

            _buildings = DC.BuildingsList.GetBy("IsDelete = 0").ToList();
            _floors = DC.FloorsList.GetBy("IsDelete = 0").ToList();
            UpdateBuildingDataSource();
            lueProject.EditValueChanged += (s, e) =>
            {
                // المبنى/الطابق تابعان للمشروع — عند تغييره تُمسح قيمتاهما فوراً بدل ترك الاختيار
                // القديم قائماً حتى يكتشف المستخدم لاحقاً أنه لم يعد ينتمي للمشروع الجديد (UpdateBuildingDataSource
                // نفسها تمسحهما فقط إن لم يعودا موجودين ضمن القائمة المُصفّاة، وهذا يجعل المسح صريحاً ومضموناً).
                lueBuilding.EditValue = null;
                lueFloor.EditValue = null;
                UpdateBuildingDataSource();
            };
            lueBuilding.EditValueChanged += (s, e) => UpdateFloorDataSource();
            lueBuilding.QueryPopUp += (s, e) =>
            {
                _buildings = DC.BuildingsList.GetBy("IsDelete = 0").ToList();
                UpdateBuildingDataSource();
            };
            lueFloor.QueryPopUp += (s, e) =>
            {
                _floors = DC.FloorsList.GetBy("IsDelete = 0").ToList();
                UpdateFloorDataSource();
            };

            btnSelectPrj.Click += BtnPrj_Click;
            btnSelectDiscipline.Click += BtnSelectDiscipline_Click;
            btnSelectSecondaryDiscipline.Click += BtnSelectSecondaryDiscipline_Click;
            btnSelectInspectionActivity.Click += BtnSelectInspectionActivity_Click;
            btnSelectBuilding.Click += BtnSelectBuilding_Click;
            btnSelectFloor.Click += BtnSelectFloor_Click;
        }

        private void BtnSelectBuilding_Click(object? sender, EventArgs e)
        {
            int? prjId = GetLookUpValue(lueProject);
            if (prjId == null)
            {
                XtraMessageBox.Show("الرجاء اختيار المشروع أولاً.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new frmBuildingSelect(prjId);
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedBuilding != null)
            {
                _buildings = DC.BuildingsList.GetBy("IsDelete = 0").ToList();
                UpdateBuildingDataSource();
                lueBuilding.EditValue = frm.SelectedBuilding.Id;
            }
        }

        private void BtnSelectFloor_Click(object? sender, EventArgs e)
        {
            int? prjId = GetLookUpValue(lueProject);
            if (prjId == null)
            {
                XtraMessageBox.Show("الرجاء اختيار المشروع أولاً.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? buildingId = GetLookUpValue(lueBuilding);
            if (buildingId == null)
            {
                XtraMessageBox.Show("الرجاء اختيار المبنى أولاً.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new frmFloorSelect(buildingId);
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedFloors.Count > 0)
            {
                _floors = DC.FloorsList.GetBy("IsDelete = 0").ToList();
                UpdateFloorDataSource();

                // lueFloor supports selecting more than one floor — يضيف الطوابق المختارة من النافذة
                // (التي تدعم بدورها اختيار أكثر من طابق) إلى التحديد الحالي بدلاً من استبداله.
                var checkedIds = GetCheckedFloorIds(lueFloor);
                foreach (var floor in frm.SelectedFloors)
                    if (!checkedIds.Contains(floor.Id)) checkedIds.Add(floor.Id);
                lueFloor.EditValue = string.Join(",", checkedIds);
            }
        }

        /// <summary>Filters lueBuilding to the currently-selected project — same cascading pattern as
        /// UpdateSecondaryDisciplineDataSource, keyed off lueProject.</summary>
        private void UpdateBuildingDataSource()
        {
            int? prjId = GetLookUpValue(lueProject);

            var filteredBuildings = _buildings.Where(b => b.PrjId == prjId).ToList();
            lueBuilding.Properties.DataSource = filteredBuildings;
            if (GetLookUpValue(lueBuilding) is int currentBuildingId && !filteredBuildings.Any(x => x.Id == currentBuildingId))
                lueBuilding.EditValue = null;

            UpdateFloorDataSource();
        }

        /// <summary>Filters lueFloor to the currently-selected building — a floor is nested under a
        /// building the same way a secondary discipline is nested under a discipline (see
        /// UpdateSecondaryDisciplineDataSource), independent of project directly. lueFloor is a
        /// CheckedComboBoxEdit (supports selecting more than one floor per request) — its EditValue is
        /// natively a comma-separated string of the checked Ids, which is exactly the format
        /// ConstructionInspectionRequestList.FloorIds persists, so no extra translation is needed
        /// between the two.</summary>
        private void UpdateFloorDataSource()
        {
            int? buildingId = GetLookUpValue(lueBuilding);

            // زر اختيار الطابق (btnSelectFloor) يعمل فقط بعد اختيار كل من المشروع والمبنى — هذه الدالة
            // تُستدعى من كل مسار يمكن أن يُغيّر أحدهما (تغيير المشروع، تغيير المبنى، تحميل سجل)، فتحديث
            // حالة الزر هنا يضمن تزامنها دائماً دون تكرار الفحص في كل مسار على حدة.
            btnSelectFloor.Enabled = GetLookUpValue(lueProject) != null && buildingId != null;

            var filteredFloors = _floors.Where(f => f.BuildingId == buildingId).ToList();
            var previouslyChecked = GetCheckedFloorIds(lueFloor);
            lueFloor.Properties.DataSource = filteredFloors;

            var stillValid = previouslyChecked.Where(id => filteredFloors.Any(f => f.Id == id)).ToList();
            lueFloor.EditValue = stillValid.Count > 0 ? string.Join(",", stillValid) : null;
        }

        private static List<int> GetCheckedFloorIds(DevExpress.XtraEditors.CheckedComboBoxEdit editor)
        {
            var raw = editor.EditValue as string;
            if (string.IsNullOrWhiteSpace(raw)) return new List<int>();

            return raw.Split(',')
                .Select(s => int.TryParse(s.Trim(), out var v) ? v : (int?)null)
                .Where(v => v.HasValue)
                .Select(v => v!.Value)
                .ToList();
        }

        private void BtnSelectDiscipline_Click(object? sender, EventArgs e)
        {
            using var frm = new frmDisciplineSelect();
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedDiscipline != null)
            {
                _disciplines = DC.DisciplinesList.GetBy("IsDelete = 0").ToList();
                lueDiscipline.Properties.DataSource = _disciplines;
                lueDiscipline.EditValue = frm.SelectedDiscipline.Id;
            }
        }

        private void BtnSelectSecondaryDiscipline_Click(object? sender, EventArgs e)
        {
            int? disciplineId = GetLookUpValue(lueDiscipline);
            using var frm = new frmSecondaryDisciplineSelect(disciplineId);
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedSecondaryDiscipline != null)
            {
                _secondaryDisciplines = DC.SecondaryDisciplinesList.GetBy("IsDelete = 0").ToList();
                UpdateSecondaryDisciplineDataSource();
                lueSecondaryDiscipline.EditValue = frm.SelectedSecondaryDiscipline.Id;
            }
        }

        /// <summary>Filters lueSecondaryDiscipline's list to the currently-selected discipline —
        /// same cascading pattern as frmDrawingsAddEdit's Category → SubCategory.</summary>
        private void UpdateSecondaryDisciplineDataSource()
        {
            int? disciplineId = GetLookUpValue(lueDiscipline);
            var filtered = _secondaryDisciplines.Where(s => s.DisciplineId == disciplineId).ToList();
            lueSecondaryDiscipline.Properties.DataSource = filtered;

            if (GetLookUpValue(lueSecondaryDiscipline) is int currentSubId && !filtered.Any(x => x.Id == currentSubId))
                lueSecondaryDiscipline.EditValue = null;

            UpdateInspectionActivityDataSource();
        }

        private void BtnSelectInspectionActivity_Click(object? sender, EventArgs e)
        {
            int? secondaryDisciplineId = GetLookUpValue(lueSecondaryDiscipline);
            using var frm = new frmInspectionActivitySelect(secondaryDisciplineId);
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedInspectionActivity != null)
            {
                _inspectionActivities = DC.InspectionActivityList.GetBy("IsDelete = 0").ToList();
                UpdateInspectionActivityDataSource();
                lueInspectionActivity.EditValue = frm.SelectedInspectionActivity.Id;
            }
        }

        /// <summary>Filters lueInspectionActivity's list to the currently-selected secondary
        /// discipline — same cascading pattern as UpdateSecondaryDisciplineDataSource, one level
        /// deeper (Discipline → SecondaryDiscipline → InspectionActivity).</summary>
        private void UpdateInspectionActivityDataSource()
        {
            int? secondaryDisciplineId = GetLookUpValue(lueSecondaryDiscipline);
            var filtered = _inspectionActivities.Where(a => a.SecondaryDisciplineId == secondaryDisciplineId).ToList();
            lueInspectionActivity.Properties.DataSource = filtered;

            if (GetLookUpValue(lueInspectionActivity) is int currentActivityId && !filtered.Any(x => x.Id == currentActivityId))
                lueInspectionActivity.EditValue = null;
        }

        private void BtnPrj_Click(object? sender, EventArgs e)
        {
            using var frm = new frmProjectSelect();
            if (frm.ShowDialog(this) == DialogResult.OK && frm.SelectedProject != null)
            {
                lueProject.Properties.DataSource = DC.ProjectsList.GetBy("IsDelete = 0").ToList();
                lueProject.EditValue = frm.SelectedProject.Id;
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

        private static int? GetLookUpValue(LookUpEdit lookUpEdit)
        {
            var val = lookUpEdit.EditValue;
            if (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()))
                return null;
            return int.TryParse(val.ToString(), out int res) ? res : null;
        }

        // ── Log tab: CST review recording + revision history ────────────────────

        private void BuildLogTab()
        {
            var panelCst = new PanelControl { Dock = DockStyle.Top, Height = 280 };
            panelCst.Appearance.BorderColor = Color.Transparent;
            panelCst.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            var lblCst = new LabelControl { Text = "حالة مراجعة الاستشاري/المالك:", Location = new Point(950, 12), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            cboCSTStatus = new ComboBoxEdit { Location = new Point(650, 9), Width = 280, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            cboCSTStatus.Properties.Items.AddRange(new object[] { CIRStatus.ReviewPending, CIRStatus.ReviewApproved, CIRStatus.ReviewApprovedWithComments, CIRStatus.ReviewRejected, CIRStatus.ReviewReviseResubmit });
            cboCSTStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            var lblSubmitted = new LabelControl { Text = "تاريخ التقديم:", Location = new Point(950, 48), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            dtSubmittedDate = new DateEdit { Location = new Point(650, 45), Width = 280, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            var lblReturned = new LabelControl { Text = "تاريخ ورود الرد:", Location = new Point(950, 84), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            dtCSTReturnedDate = new DateEdit { Location = new Point(650, 81), Width = 280, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            var lblReviewedBy = new LabelControl { Text = "اسم المراجع:", Location = new Point(950, 120), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            txtReviewedBy = new TextEdit { Location = new Point(650, 117), Width = 280, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            var lblReviewedTitle = new LabelControl { Text = "المسمى الوظيفي للمراجع:", Location = new Point(950, 156), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            txtReviewedJobTitle = new TextEdit { Location = new Point(650, 153), Width = 280, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            var lblApprovedBy = new LabelControl { Text = "اسم المعتمد:", Location = new Point(950, 192), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            txtApprovedBy = new TextEdit { Location = new Point(650, 189), Width = 280, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            var lblApprovedTitle = new LabelControl { Text = "المسمى الوظيفي للمعتمد:", Location = new Point(950, 228), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            txtApprovedJobTitle = new TextEdit { Location = new Point(650, 225), Width = 280, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            var lblComment = new LabelControl { Text = "ملاحظات المراجعة:", Location = new Point(600, 12), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            memCSTComment = new MemoEdit { Location = new Point(30, 32), Width = 550, Height = 230, Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left };

            panelCst.Controls.AddRange(new Control[]
            {
                lblCst, cboCSTStatus, lblSubmitted, dtSubmittedDate, lblReturned, dtCSTReturnedDate,
                lblReviewedBy, txtReviewedBy, lblReviewedTitle, txtReviewedJobTitle,
                lblApprovedBy, txtApprovedBy, lblApprovedTitle, txtApprovedJobTitle,
                lblComment, memCSTComment,
            });

            var lblHistory = new LabelControl { Text = "سجل الإصدارات السابقة لهذا الطلب:", Dock = DockStyle.Top, Height = 24, Padding = new Padding(6) };

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

            // ترتيب الإضافة معكوس بصرياً في WinForms مع Dock=Top: آخر عنصر مُضاف يظهر أعلى الكل.
            // نريد panelCst (حالة المراجعة والتواريخ) في الأعلى، ثم عنوان السجل، ثم الشبكة تملأ الباقي.
            xtraTabPageLog.Controls.Add(gridControlHistory);
            xtraTabPageLog.Controls.Add(lblHistory);
            xtraTabPageLog.Controls.Add(panelCst);

            cboCSTStatus.EditValueChanged += (s, e) => MarkDirty();
            memCSTComment.EditValueChanged += (s, e) => MarkDirty();
            dtSubmittedDate.EditValueChanged += (s, e) => MarkDirty();
            dtCSTReturnedDate.EditValueChanged += (s, e) => MarkDirty();
            txtReviewedBy.EditValueChanged += (s, e) => MarkDirty();
            txtReviewedJobTitle.EditValueChanged += (s, e) => MarkDirty();
            txtApprovedBy.EditValueChanged += (s, e) => MarkDirty();
            txtApprovedJobTitle.EditValueChanged += (s, e) => MarkDirty();
        }

        private void LoadRevisionHistory()
        {
            if (_record == null || _record.Num == null || _id <= 0)
            {
                gridControlHistory.DataSource = null;
                return;
            }

            // Num مُتسلسل حسب المشروع والتخصص وليس فريداً عالمياً — لا بد من تقييد البحث عن الإصدارات
            // السابقة بنفس المشروع والتخصص أيضاً، وإلا قد يظهر سجل غير متعلق يشارك نفس الرقم صدفة
            // في مشروع/تخصص آخر (انظر GenerateNextNum).
            var history = DC.ConstructionInspectionRequestList.GetBy(
                "IsDelete = 0 AND Num = @num AND PrjId = @PrjId AND DisciplineId = @DisciplineId AND Id <> @id ORDER BY Rev DESC",
                new { num = _record.Num, PrjId = _record.PrjId, DisciplineId = _record.DisciplineId, id = _id }).ToList();

            gridControlHistory.DataSource = history;
            gridViewHistory.RefreshData();
        }

        private void UpdateStatusBadge()
        {
            bsiStatus.Caption = $"الحالة: {CIRStatus.GetName(_record?.OverallStatus)} | {GetApprovalStatusText()}";
        }

        /// <summary>مدير المشروع approval sub-status shown alongside the main OverallStatus badge — see
        /// CIRWorkflowSync/btnApproved. Distinct from CST/owner review (cboCSTStatus's own vocabulary).</summary>
        private string GetApprovalStatusText()
        {
            if (_id <= 0) return "لم يُرسل للاعتماد";

            var activeInstance = CIRWorkflowSync.GetActiveInstance(DC, _id);
            if (activeInstance != null)
            {
                string stepName = CIRWorkflowSync.GetCurrentStepName(DC, activeInstance) ?? "الاعتماد";
                return $"اعتماد م.المشروع: قيد {stepName}";
            }

            return CIRWorkflowSync.IsApproved(DC, _id)
                ? "اعتماد م.المشروع: معتمد"
                : "اعتماد م.المشروع: لم يُرسل";
        }

        private static DateTime? ParseDate(string? s) => DateTime.TryParse(s, out var d) ? d : null;

        // ── Toolbar wiring ─────────────────────────────────────────────────────

        private void WireToolbarEvents()
        {
            // صلاحيات مستقلة لكل زر (انظر PermNames.CIRAdd وما يليها) — منفصلة عن صلاحية دخول
            // الشاشة نفسها (PermNames.InspectionRequest) التي تتحكم بها ucCIR فقط.
            bbiNew.Enabled = PermissionService.HasPermission(PermNames.CIRAdd);
            bbiSave.Enabled = PermissionService.HasPermission(PermNames.CIRSave);
            bbiPrint.Enabled = PermissionService.HasPermission(PermNames.CIRPrint);
            btnSend.Enabled = PermissionService.HasPermission(PermNames.CIRSend);
            btnReIssue.Enabled = PermissionService.HasPermission(PermNames.CIRReissue);
            btnApproved.Enabled = PermissionService.HasPermission(PermNames.CIRApprove);

            bbiNew.ItemClick += BbiNew_ItemClick;
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiPrint.ItemClick += BbiPrint_ItemClick;
            btnReIssue.ItemClick += BtnReIssue_ItemClick;
            btnSend.ItemClick += BtnSend_ItemClick;
            btnApproved.ItemClick += BtnApproved_ItemClick;

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
            // الحقول المطلوبة (خلفية خضراء) — تُعاد للأخضر تلقائياً فور تعبئتها إن كانت قد تحوّلت
            // لسالمون بسبب محاولة حفظ فاشلة (انظر ValidateRequiredFields).
            lueProject.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(lueProject, GetLookUpValue(lueProject) != null); };
            lueDiscipline.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(lueDiscipline, GetLookUpValue(lueDiscipline) != null); };
            lueSecondaryDiscipline.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(lueSecondaryDiscipline, GetLookUpValue(lueSecondaryDiscipline) != null); UpdateAutoDescription(); };
            lueInspectionActivity.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(lueInspectionActivity, GetLookUpValue(lueInspectionActivity) != null); UpdateAutoDescription(); };
            chkDescription.CheckedChanged += (s, e) =>
            {
                memDescription.Properties.ReadOnly = chkDescription.Checked;
                UpdateAutoDescription();
            };
            dtPreparedDate.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(dtPreparedDate, dtPreparedDate.EditValue != null); };
            memDescription.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(memDescription, !string.IsNullOrWhiteSpace(memDescription.Text)); };
            // موقع الفحص (memLocation) اختياري — يمكن حفظه فارغاً، ولذا ليس ضمن RequiredFieldChecks
            // أدناه (ولا يحمل الخلفية الخضراء المميِّزة للحقول المطلوبة في الـ Designer).
            memLocation.EditValueChanged += (s, e) => MarkDirty();
            dtRequestedDate.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(dtRequestedDate, dtRequestedDate.EditValue != null); };
            timeRequestedTime.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(timeRequestedTime, timeRequestedTime.EditValue != null); };

            txtRegisterNo.EditValueChanged += (s, e) => MarkDirty();
            txtBOQRef.EditValueChanged += (s, e) => MarkDirty();
            txtDWGRef.EditValueChanged += (s, e) => MarkDirty();
            txtMSRef.EditValueChanged += (s, e) => MarkDirty();
            txtSpecRef.EditValueChanged += (s, e) => MarkDirty();
            lueBuilding.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(lueBuilding, GetLookUpValue(lueBuilding) != null); };
            lueFloor.EditValueChanged += (s, e) => { MarkDirty(); RevalidateField(lueFloor, GetCheckedFloorIds(lueFloor).Count > 0); };
        }

        private void MarkDirty()
        {
            if (!_isLoading) _isDirty = true;
        }

        /// <summary>When chkDescription ("تلقائي") is checked, memDescription is generated from
        /// "تسليم" + the currently-selected secondary discipline's name + the currently-selected
        /// inspection activity's name — refreshed live as either cascading lookup changes (see
        /// their EditValueChanged wiring in WireToolbarEvents). A no-op while unchecked, leaving
        /// memDescription free for manual entry.</summary>
        private void UpdateAutoDescription()
        {
            if (!chkDescription.Checked) return;

            string? secondaryDisciplineName = _secondaryDisciplines.FirstOrDefault(s => s.Id == GetLookUpValue(lueSecondaryDiscipline))?.Name;
            string? inspectionActivityName = _inspectionActivities.FirstOrDefault(a => a.Id == GetLookUpValue(lueInspectionActivity))?.Name;

            var parts = new[] { "تسليم", secondaryDisciplineName, inspectionActivityName }
                .Where(p => !string.IsNullOrWhiteSpace(p));
            memDescription.Text = string.Join(" ", parts);
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>The nine fields marked with a green background in the Designer are the record's
        /// required fields (موقع الفحص/memLocation is deliberately excluded — optional, can be saved
        /// empty). Checked together on Save; any that are empty turn salmon and the first one gets
        /// focus, instead of one message box per missing field.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lueProject as DevExpress.XtraEditors.BaseEdit, GetLookUpValue(lueProject) != null),
            (lueDiscipline as DevExpress.XtraEditors.BaseEdit, GetLookUpValue(lueDiscipline) != null),
            (lueSecondaryDiscipline as DevExpress.XtraEditors.BaseEdit, GetLookUpValue(lueSecondaryDiscipline) != null),
            (lueInspectionActivity as DevExpress.XtraEditors.BaseEdit, GetLookUpValue(lueInspectionActivity) != null),
            (memDescription as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(memDescription.Text)),
            (dtPreparedDate as DevExpress.XtraEditors.BaseEdit, dtPreparedDate.EditValue != null),
            (dtRequestedDate as DevExpress.XtraEditors.BaseEdit, dtRequestedDate.EditValue != null),
            (timeRequestedTime as DevExpress.XtraEditors.BaseEdit, timeRequestedTime.EditValue != null),
            (lueBuilding as DevExpress.XtraEditors.BaseEdit, GetLookUpValue(lueBuilding) != null),
            (lueFloor as DevExpress.XtraEditors.BaseEdit, GetCheckedFloorIds(lueFloor).Count > 0),
        };

        private static void SetRequiredFieldState(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            control.Properties.Appearance.BackColor = isFilled ? Color.LightGreen : Color.Salmon;
            control.Properties.Appearance.Options.UseBackColor = true;
            control.Invalidate();
        }

        /// <summary>Live revert-to-green as the user types/selects — called from each required
        /// field's EditValueChanged, independent of the next Save attempt.</summary>
        private void RevalidateField(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            if (isFilled) SetRequiredFieldState(control, true);
        }

        private bool ValidateRequiredFields()
        {
            DevExpress.XtraEditors.BaseEdit? firstInvalid = null;
            foreach (var (control, isFilled) in RequiredFieldChecks())
            {
                SetRequiredFieldState(control, isFilled);
                if (!isFilled && firstInvalid == null) firstInvalid = control;
            }

            if (firstInvalid == null) return true;

            XtraMessageBox.Show("الرجاء تعبئة كل الحقول المطلوبة (باللون الأحمر).", "بيانات ناقصة",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firstInvalid.Focus();
            return false;
        }

        // ── Load / Refresh ────────────────────────────────────────────────────

        private void LoadRecord(int id)
        {
            _isLoading = true;
            try
            {
                // مسح أي تلوين "سالمون" متبقٍّ من محاولة حفظ فاشلة سابقة قبل تحميل سجل مختلف/جديد.
                foreach (var (control, _) in RequiredFieldChecks())
                    SetRequiredFieldState(control, true);

                // chkDescription ("تلقائي") ليس حقلاً محفوظاً في السجل — يُعاد ضبطه غير مُفعَّل مع كل
                // تحميل حتى لا يستمر تأثيره (واستبدال الوصف المحفوظ فعلياً) عبر سجلات مختلفة.
                chkDescription.Checked = false;
                memDescription.Properties.ReadOnly = false;

                if (id > 0)
                {
                    _record = DC.ConstructionInspectionRequestList.Find(id);
                    if (_record == null)
                    {
                        XtraMessageBox.Show("لم يتم العثور على طلب الفحص المطلوب.", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    lueProject.EditValue = _record.PrjId;
                    txtNum.Text = _record.Num?.ToString("D3") ?? "";
                    txtRegisterNo.Text = _record.RegisterNo ?? "";
                    txtRev.Text = _record.Rev?.ToString() ?? "0";
                    dtPreparedDate.EditValue = _record.PreparedDate;
                    lueDiscipline.EditValue = _record.DisciplineId;
                    UpdateSecondaryDisciplineDataSource();
                    lueSecondaryDiscipline.EditValue = _record.SecondaryDisciplineId;
                    UpdateInspectionActivityDataSource();
                    lueInspectionActivity.EditValue = _record.InspectionActivityId;
                    memDescription.Text = _record.Description ?? "";
                    txtBOQRef.Text = _record.BOQRef ?? "";
                    txtDWGRef.Text = _record.DWGRef ?? "";
                    txtMSRef.Text = _record.MSRef ?? "";
                    txtSpecRef.Text = _record.SpecRef ?? "";
                    memLocation.Text = _record.Location ?? "";
                    UpdateBuildingDataSource();
                    lueBuilding.EditValue = _record.BuildingId;
                    UpdateFloorDataSource();
                    lueFloor.EditValue = _record.FloorIds;
                    dtRequestedDate.EditValue = _record.RequestedDate;
                    timeRequestedTime.EditValue = _record.RequestedTime;

                    cboCSTStatus.EditValue = string.IsNullOrEmpty(_record.CSTReviewStatus) ? CIRStatus.ReviewPending : _record.CSTReviewStatus;
                    memCSTComment.Text = _record.CSTReviewComment ?? "";
                    dtSubmittedDate.EditValue = ParseDate(_record.SubmittedDate);
                    dtCSTReturnedDate.EditValue = ParseDate(_record.CSTReturnedDate);
                    txtReviewedBy.Text = _record.ReviewedBy ?? "";
                    txtReviewedJobTitle.Text = _record.ReviewedJobTitle ?? "";
                    txtApprovedBy.Text = _record.ApprovedBy ?? "";
                    txtApprovedJobTitle.Text = _record.ApprovedJobTitle ?? "";

                    _record.DisciplineCode = _disciplines.FirstOrDefault(d => d.Id == _record.DisciplineId)?.Code;
                    _record.SecondaryDisciplineCode = _secondaryDisciplines.FirstOrDefault(d => d.Id == _record.SecondaryDisciplineId)?.Code;
                    _record.InspectionActivityCode = _inspectionActivities.FirstOrDefault(a => a.Id == _record.InspectionActivityId)?.Code;
                    Text = $"طلب فحص اعمال - {CIRNumberFormatter.Format(_record)} ({_record.Description})";
                }
                else
                {
                    _record = new ConstructionInspectionRequestList { OverallStatus = CIRStatus.Draft };
                    lueProject.EditValue = Session.SelectedProjectId;
                    txtRegisterNo.Text = "";
                    txtRev.Text = "0";
                    dtPreparedDate.EditValue = DateTime.Today;
                    lueDiscipline.EditValue = null;
                    UpdateSecondaryDisciplineDataSource();
                    lueSecondaryDiscipline.EditValue = null;
                    UpdateInspectionActivityDataSource();
                    lueInspectionActivity.EditValue = null;
                    txtNum.Text = "جديد"; // يأخذ الرقم المتسلسل الفعلي (001، 002، ...) بعد الحفظ فقط
                    memDescription.Text = "";
                    txtBOQRef.Text = "";
                    txtDWGRef.Text = "";
                    txtMSRef.Text = "";
                    txtSpecRef.Text = "";
                    memLocation.Text = "";
                    UpdateBuildingDataSource();
                    lueBuilding.EditValue = null;
                    UpdateFloorDataSource();
                    lueFloor.EditValue = null;
                    dtRequestedDate.EditValue = null;
                    timeRequestedTime.EditValue = null;

                    cboCSTStatus.EditValue = CIRStatus.ReviewPending;
                    memCSTComment.Text = "";
                    dtSubmittedDate.EditValue = null;
                    dtCSTReturnedDate.EditValue = null;
                    txtReviewedBy.Text = "";
                    txtReviewedJobTitle.Text = "";
                    txtApprovedBy.Text = "";
                    txtApprovedJobTitle.Text = "";

                    Text = "طلب فحص اعمال - جديد";
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

        /// <summary>Num is sequential per project + discipline (not globally) — e.g. project 5's
        /// structural (ST) requests number 001, 002, 003... independently of project 5's electrical
        /// (EL) requests, which also start at 001.</summary>
        private string GenerateNextNum(int? prjId, int? disciplineId)
        {
            if (prjId == null || disciplineId == null) return "";

            var existing = DC.ConstructionInspectionRequestList.GetBy(
                "IsDelete = 0 AND PrjId = @PrjId AND DisciplineId = @DisciplineId",
                new { PrjId = prjId, DisciplineId = disciplineId });
            int maxNum = existing.Any() ? existing.Max(r => r.Num ?? 0) : 0;
            return (maxNum + 1).ToString("D3");
        }

        // ── Save ───────────────────────────────────────────────────────────────

        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e) => SaveRecord();

        /// <summary>Called by ucAttachmentAddEdit.SaveRequired — silently saves and returns the new
        /// record's ID. Returns 0 if validation fails.</summary>
        private int SaveAndReturnId() => SaveRecord(silent: true) ? _id : 0;

        private bool SaveRecord(bool silent = false)
        {
            if (_viewOnly || !PermissionService.HasPermission(PermNames.CIRSave))
            {
                XtraMessageBox.Show("ليس لديك صلاحية حفظ طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidateRequiredFields()) return false;

            if (_record == null) _record = new ConstructionInspectionRequestList();

            _record.PrjId = GetLookUpValue(lueProject);
            _record.DisciplineId = GetLookUpValue(lueDiscipline);
            _record.SecondaryDisciplineId = GetLookUpValue(lueSecondaryDiscipline);
            _record.InspectionActivityId = GetLookUpValue(lueInspectionActivity);
            _record.DisciplineCode = _disciplines.FirstOrDefault(d => d.Id == _record.DisciplineId)?.Code;
            _record.SecondaryDisciplineCode = _secondaryDisciplines.FirstOrDefault(d => d.Id == _record.SecondaryDisciplineId)?.Code;
            _record.InspectionActivityCode = _inspectionActivities.FirstOrDefault(a => a.Id == _record.InspectionActivityId)?.Code;
            _record.Num = _id <= 0
                ? int.Parse(GenerateNextNum(_record.PrjId, _record.DisciplineId))
                : (int.TryParse(txtNum.Text, out int num) ? num : (int?)null);
            _record.RegisterNo = txtRegisterNo.Text.Trim();
            _record.Rev = int.TryParse(txtRev.Text, out int rev) ? rev : 0;
            _record.PreparedDate = dtPreparedDate.EditValue as DateTime?;
            _record.Description = memDescription.Text.Trim();
            _record.BOQRef = txtBOQRef.Text.Trim();
            _record.DWGRef = txtDWGRef.Text.Trim();
            _record.MSRef = txtMSRef.Text.Trim();
            _record.SpecRef = txtSpecRef.Text.Trim();
            _record.Location = memLocation.Text.Trim();
            _record.BuildingId = GetLookUpValue(lueBuilding);
            _record.FloorIds = string.IsNullOrWhiteSpace(lueFloor.EditValue as string) ? null : (string)lueFloor.EditValue;
            _record.RequestedDate = dtRequestedDate.EditValue as DateTime?;
            _record.RequestedTime = timeRequestedTime.EditValue as DateTime?;

            _record.CSTReviewStatus = cboCSTStatus.EditValue?.ToString();
            _record.CSTReviewComment = memCSTComment.Text.Trim();
            // عند أول حفظ (طلب جديد لم يُقدَّم بعد)، تاريخ التقديم الافتراضي = تاريخ إعداد الطلب نفسه،
            // لا وقت الحفظ الفعلي — يبقى قابلاً للتعديل لاحقاً من مستخدم يملك صلاحية "إجراء الاستشاري"
            // فقط (dtSubmittedDate معطَّل لغيره، انظر ApplyConsultantActionReadOnly).
            if (dtSubmittedDate.EditValue == null) dtSubmittedDate.EditValue = dtPreparedDate.EditValue as DateTime? ?? DateTime.Now;
            _record.SubmittedDate = ((DateTime)dtSubmittedDate.EditValue).ToString("yyyy-MM-dd");
            _record.CSTReturnedDate = dtCSTReturnedDate.EditValue is DateTime returnedDate
                ? returnedDate.ToString("yyyy-MM-dd")
                : null;
            _record.ReviewedBy = txtReviewedBy.Text.Trim();
            _record.ReviewedJobTitle = txtReviewedJobTitle.Text.Trim();
            _record.ApprovedBy = txtApprovedBy.Text.Trim();
            _record.ApprovedJobTitle = txtApprovedJobTitle.Text.Trim();

            _record.OverallStatus = CIRStatus.MapReviewToOverallStatus(_record.CSTReviewStatus);

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
                    DC.ConstructionInspectionRequestList.Edit(_id, _record);
                }
                else
                {
                    _id = DC.ConstructionInspectionRequestList.Add(_record);
                    txtNum.Text = _record.Num?.ToString("D3") ?? "";
                    Text = $"طلب فحص اعمال - {CIRNumberFormatter.Format(_record)} ({_record.Description})";
                }

                _isDirty = false;
                UpdateStatusBadge();
                LoadRevisionHistory();

                if (!silent)
                {
                    XtraMessageBox.Show("تم حفظ طلب الفحص بنجاح.", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _ucAttachments?.LoadFor("ConstructionInspectionRequestList", _id);

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
            if (!PermissionService.HasPermission(PermNames.CIRAdd))
            {
                XtraMessageBox.Show("ليس لديك صلاحية إضافة طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isDirty)
            {
                var r = XtraMessageBox.Show("هناك تغييرات غير محفوظة. هل تريد الحفظ أولاً؟",
                    "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Cancel) return;
                if (r == DialogResult.Yes && !SaveRecord()) return;
            }
            _id = 0;
            LoadRecord(0);
            _ucAttachments?.LoadFor("ConstructionInspectionRequestList", 0);
        }

        // ── Re-issue (new revision) ──────────────────────────────────────────────

        private void BtnReIssue_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!PermissionService.HasPermission(PermNames.CIRReissue))
            {
                XtraMessageBox.Show("ليس لديك صلاحية إعادة إصدار طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_id <= 0 || _record == null)
            {
                XtraMessageBox.Show("يجب حفظ طلب الفحص أولاً قبل إعادة إصداره.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(
                    "سيتم إنشاء إصدار جديد من طلب الفحص هذا لبدء دورة مراجعة جديدة، وسيُعتبر الإصدار الحالي إصداراً سابقاً. هل تريد المتابعة؟",
                    "تأكيد إعادة الإصدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (_isDirty && !SaveRecord(silent: true)) return;

            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);

                int newId = CIRReissuer.Reissue(_record);
                if (newId <= 0)
                {
                    XtraMessageBox.Show("تعذّرت إعادة الإصدار.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                XtraMessageBox.Show("تم إنشاء الإصدار الجديد بنجاح.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _id = newId;
                LoadRecord(_id);
                _ucAttachments?.LoadFor("ConstructionInspectionRequestList", _id);
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

        // ── Approve (مدير المشروع) — gates btnSend via CIRWorkflowSync/WorkflowEngine ────────────

        /// <summary>One button covers both halves of the procedure: if this CIR has no active
        /// approval instance yet, starts one (resolving/prompting which procedure governs it — see
        /// CIRWorkflowSync.GetAvailableProcedures); if one is already running and the current user is
        /// its current step's assignee (WorkflowEngine.CanUserAct), acts "Approved" on it — normally
        /// completing it immediately since the seeded procedure has a single step (مدير المشروع). A
        /// user who isn't the assignee just gets an informational status instead of an error, so
        /// whoever prepares the CIR can click this to send it into the approval queue without needing
        /// اعتماد rights themselves.</summary>
        private void BtnApproved_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_id <= 0 || _record == null)
            {
                XtraMessageBox.Show("يجب حفظ طلب الفحص أولاً قبل اعتماده.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isDirty && !SaveRecord(silent: true)) return;

            try
            {
                var activeInstance = CIRWorkflowSync.GetActiveInstance(DC, _id);

                if (activeInstance == null)
                {
                    if (CIRWorkflowSync.IsApproved(DC, _id))
                    {
                        XtraMessageBox.Show("تم اعتماد طلب الفحص هذا مسبقاً من قبل مدير المشروع.", "تنبيه",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var candidates = CIRWorkflowSync.GetAvailableProcedures(DC, _record);
                    if (candidates.Count == 0)
                    {
                        XtraMessageBox.Show(
                            "لم يتم تعريف إجراء اعتماد لطلبات فحص الأعمال بعد. يرجى تعريفه من شاشة \"إدارة الإجراءات\" أولاً.",
                            "تعذّر الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int workflowDefinitionId;
                    if (candidates.Count == 1)
                    {
                        workflowDefinitionId = candidates[0].Id;
                    }
                    else
                    {
                        using var picker = new frmWorkflowDefinitionSelect(candidates);
                        if (picker.ShowDialog(this) != DialogResult.OK) return;
                        workflowDefinitionId = picker.SelectedDefinitionId;
                    }

                    CIRWorkflowSync.SendForApproval(DC, _record, workflowDefinitionId);
                    activeInstance = CIRWorkflowSync.GetActiveInstance(DC, _id);
                    if (activeInstance == null) return; // لن يحدث عادةً — احتياط دفاعي فقط

                    if (!WorkflowEngine.CanUserAct(activeInstance.Id, Session.CurrentUser?.Id ?? 1))
                    {
                        XtraMessageBox.Show("تم إرسال طلب الفحص لاعتماد مدير المشروع.", "تم",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateStatusBadge();
                        return;
                    }
                }

                if (!WorkflowEngine.CanUserAct(activeInstance.Id, Session.CurrentUser?.Id ?? 1))
                {
                    string stepName = CIRWorkflowSync.GetCurrentStepName(DC, activeInstance) ?? "خطوة الاعتماد";
                    XtraMessageBox.Show($"طلب الفحص قيد إجراء الاعتماد حالياً — بانتظار: {stepName}.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var comment = XtraInputBox.Show("ملاحظة (اعتماد) - اختياري:", "اعتماد", "");
                if (comment == null) return; // المستخدم ألغى

                WorkflowEngine.Act(activeInstance.Id, Session.CurrentUser?.Id ?? 1, "Approved", comment.ToString());

                XtraMessageBox.Show("تم اعتماد طلب الفحص بنجاح ✓", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusBadge();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ConstructionInspectionRequestList? target = null;

                switch (direction)
                {
                    case "First":
                        target = DC.ConstructionInspectionRequestList.GetBy(
                            "IsDelete = 0 ORDER BY Num ASC, Rev ASC").FirstOrDefault();
                        break;
                    case "Last":
                        target = DC.ConstructionInspectionRequestList.GetBy(
                            "IsDelete = 0 ORDER BY Num DESC, Rev DESC").FirstOrDefault();
                        break;
                    case "Next":
                        target = DC.ConstructionInspectionRequestList.GetBy(
                            "IsDelete = 0 AND Id > @id ORDER BY Id ASC",
                            new { id = _id }).FirstOrDefault();
                        break;
                    case "Prev":
                        target = DC.ConstructionInspectionRequestList.GetBy(
                            "IsDelete = 0 AND Id < @id ORDER BY Id DESC",
                            new { id = _id }).FirstOrDefault();
                        break;
                }

                if (target != null)
                {
                    _id = target.Id;
                    LoadRecord(_id);
                    _ucAttachments?.LoadFor("ConstructionInspectionRequestList", _id);
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

            // Num مُتسلسل حسب المشروع والتخصص وليس فريداً عالمياً — نقيّد البحث بالمشروع الحالي المعروض
            // في النموذج لتفادي التطابق مع رقم مطابق صدفة في مشروع آخر (انظر GenerateNextNum).
            int? prjId = GetLookUpValue(lueProject);
            var result = prjId != null
                ? DC.ConstructionInspectionRequestList.GetBy(
                    "IsDelete = 0 AND Num = @num AND PrjId = @PrjId ORDER BY Rev DESC",
                    new { num, PrjId = prjId }).FirstOrDefault()
                : DC.ConstructionInspectionRequestList.GetBy(
                    "IsDelete = 0 AND Num = @num ORDER BY Rev DESC", new { num }).FirstOrDefault();

            if (result == null)
            {
                XtraMessageBox.Show($"لم يتم العثور على طلب فحص برقم ({num}).", "بحث",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _id = result.Id;
            LoadRecord(_id);
            _ucAttachments?.LoadFor("ConstructionInspectionRequestList", _id);
        }

        // ── Print ──────────────────────────────────────────────────────────────

        private void BbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!PermissionService.HasPermission(PermNames.CIRPrint))
            {
                XtraMessageBox.Show("ليس لديك صلاحية طباعة طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_id <= 0 || _record == null)
            {
                XtraMessageBox.Show("يجب حفظ طلب الفحص أولاً قبل طباعته.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CIRPrinter.Print(_record, this);
        }

        // ── Send by email ──────────────────────────────────────────────────────

        private void BtnSend_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!PermissionService.HasPermission(PermNames.CIRSend))
            {
                XtraMessageBox.Show("ليس لديك صلاحية إرسال طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_id <= 0 || _record == null)
            {
                XtraMessageBox.Show("يجب حفظ طلب الفحص أولاً قبل إرساله.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CIRWorkflowSync.IsApproved(DC, _id))
            {
                XtraMessageBox.Show("لا يمكن إرسال طلب الفحص إلى الاستشاري قبل اعتماده من قبل مدير المشروع (زر \"إعتماد\").",
                    "غير مصرَّح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Data.EmailSettings.IsConfigured(DC))
            {
                XtraMessageBox.Show(
                    "لم يتم إعداد بيانات خادم البريد الإلكتروني (SMTP) بعد.\nالرجاء إعدادها أولاً من: الإعدادات ← البريد الإلكتروني (SMTP).",
                    "الإعدادات غير مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] pdfBytes;
            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);
                pdfBytes = CIRPrinter.ExportToPdf(_record);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ أثناء تجهيز نسخة PDF: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }

            string defaultTo = "";
            if (!string.IsNullOrWhiteSpace(_record.PrintClientEmail))
                defaultTo = _record.PrintClientEmail!;
            if (!string.IsNullOrWhiteSpace(_record.PrintConsultantEmail))
                defaultTo += (defaultTo.Length > 0 ? ";" : "") + _record.PrintConsultantEmail;

            string subject = $"طلب فحص اعمال رقم {_record.Num} - {_record.Description}";
            string body = $"مرفق طلب فحص الأعمال رقم {_record.Num} (إصدار {_record.Rev}).";
            string fileName = $"CIR-{_record.Num}-Rev{_record.Rev}.pdf";

            using var frm = new Etmam.Gui.Common.frmSendEmail(defaultTo, subject, body, pdfBytes, fileName);
            frm.ShowDialog(this);
        }

        // ── Form closing guard ─────────────────────────────────────────────────

        private void FrmCIRAddEdit_FormClosing(object sender, FormClosingEventArgs e)
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

        private void lueDiscipline_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
