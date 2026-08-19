using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using Core;
using Data;

namespace Etmam
{
    public partial class ucCIR : BaseUserControl
    {
        private bool _canManage;
        private HashSet<int> _grantedProjectIds = new();
        private Dictionary<int, string> _projectNames = new();
        private Dictionary<int, string> _disciplineNames = new();
        private Dictionary<int, string> _secondaryDisciplineNames = new();
        private Dictionary<int, string> _inspectionActivityNames = new();
        private Dictionary<int, string> _buildingNames = new();
        private Dictionary<int, string> _floorNames = new();
        private List<SecondaryDisciplinesList> _secondaryDisciplinesAll = new();
        private List<InspectionActivityList> _inspectionActivitiesAll = new();

        // ── tbMain (بطاقات الحالة) ───────────────────────────────────────────
        // كل السجلات المطابقة لفلتر المشروع/التخصص الحالي (كما يعيدها الاستعلام في LoadData)، بمعزل عن
        // فلتر البطاقة النشطة — تُستخدم كمصدر لعدّادات tbMain (تبقى معبِّرة عن الإجمالي الحقيقي) ولحساب
        // القائمة المعروضة فعلياً في DataSource بعد تطبيق فلتر البطاقة، إن وُجد.
        private List<ConstructionInspectionRequestList> _allRecords = new();
        private DevExpress.XtraBars.Navigation.TileBarItem? _activeTile;
        private Func<ConstructionInspectionRequestList, bool>? _activeTileFilter;

        /// <summary>Item backing lookUpEditPrj's project filter — same methodology as
        /// ucPurchaseRequests.PrjSourceOption, minus the department merge (CIR has no department
        /// concept): 0 = "-- الكل --" (كل المشاريع المصرَّح بها), positive = ProjectsList.Id.</summary>
        private class PrjFilterOption
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }

        private class DisciplineFilterOption
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }

        protected System.ComponentModel.BindingList<ConstructionInspectionRequestList> DataSource { get; set; } = new System.ComponentModel.BindingList<ConstructionInspectionRequestList>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        // عمود "إجراء" (يفتح frmCIRAction) — colAction وriButtonAction مُنشآن ومُهيّآن بالكامل
        // من الـ Designer (InitializeComponent)، لا حاجة لإنشائهما هنا؛ يبقى ربط الحدث والصلاحية فقط.
        private DevExpress.XtraGrid.Columns.GridColumn colAction = null!;

        private void RiButtonAction_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.GetFocusedRow() is not ConstructionInspectionRequestList rec) return;

            var handle = ShowOverlay();
            frmCIRAction frm;
            try { frm = new frmCIRAction(rec.Id); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadData();
                    FocusRow(rec.Id);
                }
            }
        }

        protected void InitializeBaseGrid()
        {
            if (gridView1 == null || gridControl1 == null) return;
            //DesignSystem.ApplyProfessionalStyle(gridView1);
            gridControl1.DataSource = DataSource;

            // Editable=false/ReadOnly=true على مستوى الـ View بأكمله (كما كان مضبوطاً في الـ Designer)
            // يمنع أي خلية من دخول وضع التحرير — بما في ذلك أعمدة الأزرار colPrint/colReissue، فتتوقف
            // أزرارها عن العمل تماماً (نفس الفخ الموثَّق في ucPurchaseRequests.SetupGrid). الحل: تفعيل
            // التحرير على مستوى الـ View، ثم تعطيله فردياً على كل عمود بيانات (وليس عمودي الأزرار).
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.ReadOnly = false;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            {
                if (col != colPrint && col != colReissue && col != colAction)
                    col.OptionsColumn.AllowEdit = false;
            }

            // الـ Designer كان يضبط FocusRectStyle=RowFullFocus (يرسم تظليل ملوّن فوق الصف بأكمله
            // كطبقة أخيرة، بخلاف ucPurchaseRequests التي لا تضبط هذه الخاصية إطلاقاً وتترك القيمة
            // الافتراضية) — هذا كان يتجاوز أي تلوين وضعناه على مستوى الخلية. نعيدها لتطابق نفس السلوك
            // المستخدم في ucPurchaseRequests (لا تظليل تعبئة كامل)، مع إبقاء تلوين التركيز الطبيعي
            // (EnableAppearanceFocusedRow يبقى مفعَّلاً افتراضياً) ليعمل على باقي الأعمدة كالمعتاد.
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            // ضبط حجم الخط وارتفاع الأسطر لمنع مشكلة التهميش/القطع عند العرض للمستخدم
            gridView1.Appearance.Row.Font = DesignSystem.Fonts.Regular(8.5F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Font = DesignSystem.Fonts.Bold(8F);
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.ColumnPanelRowHeight = 35;
            gridView1.OptionsView.RowAutoHeight = true;

            // ضمان حد أدنى لارتفاع الصفوف لا يقل عن 34 بكسل مع إمكانية التوسع التلقائي للنصوص المتعددة الأسطر
            gridView1.CalcRowHeight += (s, e) =>
            {
                if (e.RowHeight < 34)
                    e.RowHeight = 34;
            };

            // الحلقة المفقودة: ucPurchaseRequests يضبط ألوان صفوف صريحة أولاً ("لازمة حتى نستطيع
            // مطابقتها بدقة في RowCellStyle" — تعليقها الخاص) قبل استخدامها في RowCellStyle أدناه.
            // بدون هذا، Appearance.Row/EvenRow.BackColor يبقيان بقيمتهما الافتراضية غير المُعرَّفة
            // (وليسا لون السمة الفعلي المرسوم)، فكان RowCellStyle يعيد رسم لون خاطئ لا يطابق الصف
            // فعلياً ولا يُبطل تظليل التركيز.
            gridView1.Appearance.Row.BackColor = DesignSystem.Colors.Surface;
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.BackColor = DesignSystem.Colors.Background;
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;

            //// gridView1 already has one explicit column (colPrint, the per-row print button), which
            //// stops DevExpress's automatic column generation from ever kicking in for the rest of
            //// ConstructionInspectionRequestList's fields (auto-population only fires when a view has
            //// zero columns). Populate the missing data columns explicitly, then hide the ones that
            //// are either internal bookkeeping or print-time-only ([NotMapped] Print* fields).
            //gridView1.PopulateColumns();
            //DesignSystem.HideAuditColumns(gridView1);
            //foreach (var name in new[] { "PrjId", "OverallStatus", "Created", "Update", "Deletion",
            //    "PrintPrjName", "PrintSponsorName", "PrintCSTName", "PrintClientEmail", "PrintConsultantEmail" })
            //{
            //    var col = gridView1.Columns[name];
            //    if (col != null) col.Visible = false;
            //}

            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            gridView1.KeyDown += StandardGridView_KeyDown;
        }

        protected void UpdateRecordCount()
        {
        }

        protected void StandardGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                ConfirmAndDeleteFocusedRow();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.V && e.Control)
            {
                HandleManualPaste();
                e.Handled = true;
            }
        }

        public virtual void ConfirmAndDeleteFocusedRow()
        {
            if (gridView1 == null) return;
            var row = gridView1.GetFocusedRow() as ConstructionInspectionRequestList;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                gridView1.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (gridView1 == null) return;
                gridView1.CloseEditor();
                gridView1.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gridView1.BeginUpdate();
                int startRowHandle       = gridView1.FocusedRowHandle;
                bool startAtNewRow       = gridView1.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gridView1.FocusedColumn != null ? gridView1.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gridView1.DataRowCount || 
                        currentRowHandle < 0 || gridView1.IsNewItemRow(currentRowHandle))
                    {
                        gridView1.AddNewRow();
                        currentRowHandle = gridView1.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < gridView1.VisibleColumns.Count)
                        {
                            var col = gridView1.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                gridView1.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                gridView1.EndUpdate();
                OnDataChanged();
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("خطأ أثناء اللصق: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ucCIR()
        {
            InitializeComponent();
            if (DesignMode) return;

            // _canManage يبقى بوّابة عامة لدخول الشاشة (وما لا صلاحية مستقلة له، مثل الحذف)، بينما كل
            // زر له صلاحيته المستقلة الخاصة (نفس صلاحيات frmCIRAddEdit — PermNames.CIRAdd وما يليها)،
            // فوق واشتراط _canManage معاً — لا يكفي أحدهما وحده.
            // "فتح" = عرض فقط (بلا حاجة لصلاحية الحفظ — يفتح frmCIRAddEdit في وضع للقراءة فقط بحيث
            // لا يمكن تعديل أي حقل ولا حفظ/إضافة/إعادة إصدار/إرسال، انظر frmCIRAddEdit.ApplyViewOnlyMode)،
            // بينما "تعديل" يتطلب CIRSave فعلياً. كلاهما يبقى مشروطاً بـ_canManage.
            _canManage = PermissionService.HasPermission(PermNames.InspectionRequest);
            bbiNew.Enabled = _canManage && PermissionService.HasPermission(PermNames.CIRAdd);
            btnOpen.Enabled = _canManage;
            bbiEdit.Enabled = _canManage && PermissionService.HasPermission(PermNames.CIRSave);
            bbiDelete.Enabled = _canManage && PermissionService.HasPermission(PermNames.CIRDelete);
            bbiPrint.Enabled = _canManage && PermissionService.HasPermission(PermNames.CIRPrint);
            riButtonPrint.Buttons[0].Enabled = _canManage && PermissionService.HasPermission(PermNames.CIRPrint);
            riButtonReissue.Buttons[0].Enabled = _canManage && PermissionService.HasPermission(PermNames.CIRReissue);

            bbiNew.ItemClick += bbiNew_ItemClick;
            btnOpen.ItemClick += BtnOpen_ItemClick;
            bbiEdit.ItemClick += BbiEdit_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            riButtonPrint.ButtonClick += RiButtonPrint_ButtonClick;
            riButtonReissue.ButtonClick += RiButtonReissue_ButtonClick;
            riButtonAction.ButtonClick += RiButtonAction_ButtonClick;
            riButtonAction.Buttons[0].Enabled = _canManage;

            SetupLookups();
            InitializeBaseGrid();
            SetupAconexStyle();
            WireSearch();
            WireTileBar();
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            // نفس تقنية ucPurchaseRequests.GridView1_RowCellStyle بالضبط: إعادة رسم لون الصف الطبيعي
            // (فردي/زوجي) صراحةً على عمودي الأزرار فقط، بينما FocusRectStyle (أعلاه، ليس RowFullFocus)
            // يترك تلوين التركيز الطبيعي يعمل على باقي الأعمدة دون تدخل.
            gridView1.RowCellStyle += (s, e) =>
            {
                if (e.Column != colPrint && e.Column != colReissue && e.Column != colAction) return;
                bool isEvenRow = e.RowHandle % 2 != 0;
                e.Appearance.BackColor = isEvenRow ? gridView1.Appearance.EvenRow.BackColor : gridView1.Appearance.Row.BackColor;
                e.Appearance.Options.UseBackColor = true;
            };
            gridView1.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName != "OverallStatus") return;

                Color backColor = (e.CellValue as int?) switch
                {
                    CIRStatus.Draft => Color.FromArgb(117, 117, 117),        // رمادي
                    CIRStatus.Submitted => Color.FromArgb(251, 192, 45),     // كهرماني غامق
                    CIRStatus.Reissued => Color.FromArgb(21, 101, 192),      // أزرق
                    CIRStatus.Closed => Color.FromArgb(46, 125, 50),         // أخضر غامق
                    CIRStatus.Rejected => Color.FromArgb(198, 40, 40),       // أحمر
                    CIRStatus.NeedsRevision => Color.FromArgb(230, 81, 0),   // برتقالي غامق
                    _ => Color.Transparent,
                };

                if (backColor == Color.Transparent) return;

                e.Appearance.BackColor = backColor;
                e.Appearance.ForeColor = (e.CellValue as int?) == CIRStatus.Submitted ? Color.Black : Color.White;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.Options.UseForeColor = true;
                e.Appearance.Options.UseFont = true;
            };
            // عمود "عدد أيام الإجراء" غير مربوط بحقل حقيقي — يُحسَب مباشرةً من SubmittedDate/
            // CSTReturnedDate عبر CustomUnboundColumnData في كل مرة تحتاج الشبكة قيمته (فرز/تصفية/عرض)،
            // بدل تخزينه كحقل [NotMapped] يحتاج تعبئة يدوية بعد كل تحميل.
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            // تلوين تحذيري عندما يتجاوز عدد الأيام 3 (إجراء متأخر) — نفس أسلوب تلوين OverallStatus أعلاه،
            // كمستمع منفصل لأن ذاك المستمع يخرج مبكراً لأي عمود غير OverallStatus.
            gridView1.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName != "ProcessingDays") return;
                if (e.CellValue is not int days || days <= 3) return;

                e.Appearance.BackColor = Color.FromArgb(198, 40, 40); // أحمر — إجراء متأخر
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.Options.UseForeColor = true;
                e.Appearance.Options.UseFont = true;
            };
            // SetupLookups يضبط lookUpEditPrj.EditValue/lueDiscipline.EditValue، وهذا يُطلق LoadData
            // ضمنياً عبر EditValueChanged — لكن توقيت إطلاق DevExpress لهذا الحدث قبل إنشاء مقبض
            // النافذة (الشاشة لم تُعرض بعد) غير موثوق دائماً، خصوصاً حين تكون قائمة المشاريع المصرَّح
            // بها لأكثر من مشروع (تأخير تحميل الصلاحيات/القائمة يزيد الاحتمال). لذا نستدعيها هنا صراحةً
            // كخطوة أخيرة مضمونة التنفيذ بعد اكتمال كل الإعداد، بدل الاعتماد فقط على ذلك الإطلاق
            // الضمني أو حدث Load (الذي قد يتأخر حسب توقيت إظهار التبويب الحاوي لهذا العنصر).
            LoadData();
            this.Load += (s, e) => LoadData();
        }

        /// <summary>Shows the friendly Arabic name instead of the raw stored id for colDiscipline,
        /// colOverallStatus (1-4) and colPrjId — resolved via _disciplineNames / CIRStatus /
        /// _projectNames, without changing what's actually stored.</summary>
        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Num")
            {
                // عمود "رقم طلب الفحص" هنا يعرض الرقم التسلسلي المخزَّن فقط (مثال: "001")، لا رمز CIR
                // الكامل بحروف (CIRNumberFormatter.Format، المستخدم في عنوان frmCIRAddEdit/الطباعة) —
                // بطلب المستخدم أن يبقى هذا العمود أرقاماً فقط.
                if (e.Value is int num)
                    e.DisplayText = num.ToString("D3");
            }
            else if (e.Column.FieldName == "DisciplineId")
            {
                if (e.Value is int disciplineId && _disciplineNames.TryGetValue(disciplineId, out var dName))
                    e.DisplayText = dName;
            }
            else if (e.Column.FieldName == "SecondaryDisciplineId")
            {
                if (e.Value is int secDisciplineId && _secondaryDisciplineNames.TryGetValue(secDisciplineId, out var sdName))
                    e.DisplayText = sdName;
            }
            else if (e.Column.FieldName == "InspectionActivityId")
            {
                if (e.Value is int inspectionActivityId && _inspectionActivityNames.TryGetValue(inspectionActivityId, out var iaName))
                    e.DisplayText = iaName;
            }
            else if (e.Column.FieldName == "BuildingId")
            {
                if (e.Value is int buildingId && _buildingNames.TryGetValue(buildingId, out var bName))
                    e.DisplayText = bName;
            }
            else if (e.Column.FieldName == "FloorIds")
            {
                if (e.Value is string floorIds && !string.IsNullOrWhiteSpace(floorIds))
                {
                    var names = floorIds.Split(',')
                        .Select(s => int.TryParse(s.Trim(), out var id) && _floorNames.TryGetValue(id, out var flName) ? flName : null)
                        .Where(n => !string.IsNullOrEmpty(n));
                    e.DisplayText = string.Join("، ", names);
                }
            }
            else if (e.Column.FieldName == "OverallStatus")
            {
                e.DisplayText = CIRStatus.GetName(e.Value as int?);
            }
            else if (e.Column.FieldName == "PrjId")
            {
                if (e.Value is int prjId && _projectNames.TryGetValue(prjId, out var name))
                    e.DisplayText = name;
            }
        }


        /// <summary>Computes colProcessingDays: الفرق بين تاريخ التقديم وتاريخ مراجعة الاستشاري، أو
        /// بين تاريخ التقديم واليوم الحالي إن لم تتم المراجعة بعد (CSTReturnedDate فارغ). بلا تقديم لا
        /// توجد قيمة (يبقى الخلية فارغة).</summary>
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "ProcessingDays" || !e.IsGetData) return;
            if (e.Row is not ConstructionInspectionRequestList rec) return;

            var days = ComputeProcessingDays(rec);
            if (days != null) e.Value = days.Value;
        }

        private static DateTime? ParseDate(string? s) => DateTime.TryParse(s, out var d) ? d : null;

        /// <summary>الفرق بين تاريخ التقديم وتاريخ مراجعة الاستشاري، أو بين تاريخ التقديم واليوم الحالي
        /// إن لم تتم المراجعة بعد — null بلا تقديم. مصدر واحد يشترك فيه colProcessingDays (الشبكة) وبطاقة
        /// "متأخر" في tbMain (انظر IsLate) كي يبقى تعريف "التأخر" متطابقاً في الاثنين.</summary>
        private static int? ComputeProcessingDays(ConstructionInspectionRequestList rec)
        {
            var submitted = ParseDate(rec.SubmittedDate);
            if (submitted == null) return null;

            var end = ParseDate(rec.CSTReturnedDate) ?? DateTime.Today;
            return (end.Date - submitted.Value.Date).Days;
        }

        /// <summary>نفس عتبة التلوين التحذيري لعمود "عدد أيام الإجراء" (أكثر من 3 أيام) — انظر
        /// CustomDrawCell أعلاه.</summary>
        private static bool IsLate(ConstructionInspectionRequestList rec) => ComputeProcessingDays(rec) is int days && days > 3;

        // ── Setup ─────────────────────────────────────────────────────────────
        /// <summary>Rebuilds lookUpEditPrj's filter list from ProjectsList — called once at setup
        /// and again on every Popup so newly added/renamed projects show up without reopening the tab.</summary>
        private void RefreshPrjFilterDataSource()
        {
            var projects = DC.ProjectsList.GetBy("IsDelete = 0");
            _grantedProjectIds = PermissionService.GrantedProjectIds(DC);
            _projectNames = projects.ToDictionary(p => p.Id, p => p.Name ?? $"مشروع {p.Id}");

            var accessibleProjects = projects.Where(p => _grantedProjectIds.Contains(p.Id)).ToList();

            var prjFilterSource = new List<PrjFilterOption> { new PrjFilterOption { Id = 0, Name = "-- الكل --" } };
            prjFilterSource.AddRange(accessibleProjects.Select(p => new PrjFilterOption { Id = p.Id, Name = p.Name ?? $"مشروع {p.Id}" }));

            lookUpEditPrj.Properties.DataSource = prjFilterSource;
            lookUpEditPrj.Properties.ValueMember = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.NullText = "-- إختر المشروع --";
        }

        // نفس منهجية ucPurchaseRequests.SetupLookups لفلتر المشروع أعلى الشبكة، بدون دمج الإدارات
        // (لا مفهوم "إدارة" لطلبات فحص الأعمال — هي مرتبطة بمشروع فقط).
        private void SetupLookups()
        {
            RefreshPrjFilterDataSource();

            // عند تغيير المشروع → إعادة تحميل
            lookUpEditPrj.EditValueChanged += (s, e) => LoadData();

            // تحديث قائمة المشاريع من قاعدة البيانات عند كل فتح للقائمة المنسدلة
            lookUpEditPrj.QueryPopUp += (s, e) => RefreshPrjFilterDataSource();

            // تعيين المشروع الحالي كقيمة افتراضية
            lookUpEditPrj.EditValue = Session.SelectedProjectId;

            // فلتر التخصص: نفس منهجية فلتر المشروع أعلاه — خيار "-- الكل --" + قائمة DisciplinesList
            // الفعلية من قاعدة البيانات (بدلاً من الرموز الثابتة القديمة).
            RefreshDisciplineCaches();
            RefreshDisciplineFilterDataSource();

            lueDiscipline.Properties.ValueMember = "Id";
            lueDiscipline.Properties.DisplayMember = "Name";
            lueDiscipline.Properties.NullText = "-- إختر التخصص --";

            lueDiscipline.EditValueChanged += (s, e) => { UpdateSecondaryDisciplineFilterDataSource(); LoadData(); };
            lueDiscipline.EditValue = 0;

            // تحديث قائمة التخصصات من قاعدة البيانات عند كل فتح للقائمة المنسدلة
            lueDiscipline.QueryPopUp += (s, e) =>
            {
                RefreshDisciplineCaches();
                RefreshDisciplineFilterDataSource();
                UpdateSecondaryDisciplineFilterDataSource();
            };

            // فلتر التخصص الثانوي: يتبع فلتر التخصص أعلاه (نفس تسلسل التخصص/التخصص الثانوي في
            // frmCIRAddEdit) — عند اختيار تخصص معيّن يقتصر الخيار على تخصصاته الثانوية فقط، وعند
            // "-- الكل --" تظهر كل التخصصات الثانوية بلا استثناء.
            lueSecondaryDiscipline.Properties.ValueMember = "Id";
            lueSecondaryDiscipline.Properties.DisplayMember = "Name";
            lueSecondaryDiscipline.Properties.NullText = "-- إختر التخصص الثانوي --";
            UpdateSecondaryDisciplineFilterDataSource();
            lueSecondaryDiscipline.EditValueChanged += (s, e) => { UpdateInspectionActivityFilterDataSource(); LoadData(); };
            lueSecondaryDiscipline.EditValue = 0;

            // تحديث قائمة التخصصات الثانوية من قاعدة البيانات عند كل فتح للقائمة المنسدلة
            lueSecondaryDiscipline.QueryPopUp += (s, e) =>
            {
                RefreshDisciplineCaches();
                UpdateSecondaryDisciplineFilterDataSource();
            };

            // فلتر نشاط الفحص: يتبع فلتر التخصص الثانوي أعلاه — نفس تسلسل الفلاتر المتتالية (تخصص →
            // تخصص ثانوي → نشاط فحص)، مطابقاً ربط InspectionActivityList.SecondaryDisciplineId نفسه.
            lueInspectionActivity.Properties.ValueMember = "Id";
            lueInspectionActivity.Properties.DisplayMember = "Name";
            lueInspectionActivity.Properties.NullText = "-- إختر نشاط الفحص --";
            UpdateInspectionActivityFilterDataSource();
            lueInspectionActivity.EditValueChanged += (s, e) => LoadData();
            lueInspectionActivity.EditValue = 0;

            // تحديث قائمة أنشطة الفحص من قاعدة البيانات عند كل فتح للقائمة المنسدلة
            lueInspectionActivity.QueryPopUp += (s, e) =>
            {
                RefreshDisciplineCaches();
                UpdateInspectionActivityFilterDataSource();
            };
        }

        /// <summary>Filters lueSecondaryDiscipline's filter-combo list to the currently-selected
        /// discipline filter — same cascading pattern as frmCIRAddEdit.UpdateSecondaryDisciplineDataSource.</summary>
        private void UpdateSecondaryDisciplineFilterDataSource()
        {
            int? disciplineId = lueDiscipline.EditValue as int?;
            var filtered = disciplineId is > 0
                ? _secondaryDisciplinesAll.Where(sd => sd.DisciplineId == disciplineId).ToList()
                : _secondaryDisciplinesAll;

            var secondaryDisciplineFilterSource = new List<DisciplineFilterOption> { new DisciplineFilterOption { Id = 0, Name = "-- الكل --" } };
            secondaryDisciplineFilterSource.AddRange(filtered.Select(sd => new DisciplineFilterOption { Id = sd.Id, Name = sd.Name ?? "" }));
            lueSecondaryDiscipline.Properties.DataSource = secondaryDisciplineFilterSource;

            if (lueSecondaryDiscipline.EditValue is int currentId && currentId != 0
                && !secondaryDisciplineFilterSource.Any(x => x.Id == currentId))
                lueSecondaryDiscipline.EditValue = 0;
        }

        /// <summary>Filters lueInspectionActivity's filter-combo list to the currently-selected
        /// secondary-discipline filter — same cascading pattern as frmCIRAddEdit.UpdateInspectionActivityDataSource,
        /// one level deeper than UpdateSecondaryDisciplineFilterDataSource (تخصص ثانوي → نشاط فحص).</summary>
        private void UpdateInspectionActivityFilterDataSource()
        {
            int? secondaryDisciplineId = lueSecondaryDiscipline.EditValue as int?;
            var filtered = secondaryDisciplineId is > 0
                ? _inspectionActivitiesAll.Where(a => a.SecondaryDisciplineId == secondaryDisciplineId).ToList()
                : _inspectionActivitiesAll;

            var inspectionActivityFilterSource = new List<DisciplineFilterOption> { new DisciplineFilterOption { Id = 0, Name = "-- الكل --" } };
            inspectionActivityFilterSource.AddRange(filtered.Select(a => new DisciplineFilterOption { Id = a.Id, Name = a.Name ?? "" }));
            lueInspectionActivity.Properties.DataSource = inspectionActivityFilterSource;

            if (lueInspectionActivity.EditValue is int currentActivityId && currentActivityId != 0
                && !inspectionActivityFilterSource.Any(x => x.Id == currentActivityId))
                lueInspectionActivity.EditValue = 0;
        }

        /// <summary>Rebuilds lueDiscipline's filter list ("-- الكل --" + DisciplinesList) from the
        /// database — called once at setup and again on every Popup, same pattern as
        /// RefreshPrjFilterDataSource for lookUpEditPrj.</summary>
        private void RefreshDisciplineFilterDataSource()
        {
            var disciplines = DC.DisciplinesList.GetBy("IsDelete = 0").ToList();
            var disciplineFilterSource = new List<DisciplineFilterOption> { new DisciplineFilterOption { Id = 0, Name = "-- الكل --" } };
            disciplineFilterSource.AddRange(disciplines.Select(d => new DisciplineFilterOption { Id = d.Id, Name = d.Name ?? "" }));

            lueDiscipline.Properties.DataSource = disciplineFilterSource;

            if (lueDiscipline.EditValue is int currentId && currentId != 0
                && !disciplineFilterSource.Any(x => x.Id == currentId))
                lueDiscipline.EditValue = 0;
        }

        /// <summary>Rebuilds the Id→Name/Code lookup caches for DisciplinesList/SecondaryDisciplinesList
        /// from the database — called on every LoadData(), not just once at startup, so a discipline or
        /// secondary discipline created on the fly (e.g. via frmCIRAddEdit's "إضافة" picker button while
        /// filling out a CIR) resolves correctly in the grid as soon as the newly-saved record reloads,
        /// instead of showing blank until ucCIR itself is reopened.</summary>
        private void RefreshDisciplineCaches()
        {
            var disciplines = DC.DisciplinesList.GetBy("IsDelete = 0").ToList();
            _disciplineNames = disciplines.ToDictionary(d => d.Id, d => d.Name ?? "");

            _secondaryDisciplinesAll = DC.SecondaryDisciplinesList.GetBy("IsDelete = 0").ToList();
            _secondaryDisciplineNames = _secondaryDisciplinesAll.ToDictionary(sd => sd.Id, sd => sd.Name ?? "");

            _inspectionActivitiesAll = DC.InspectionActivityList.GetBy("IsDelete = 0").ToList();
            _inspectionActivityNames = _inspectionActivitiesAll.ToDictionary(ia => ia.Id, ia => ia.Name ?? "");

            _buildingNames = DC.BuildingsList.GetBy("IsDelete = 0").ToDictionary(b => b.Id, b => b.Name ?? "");
            _floorNames = DC.FloorsList.GetBy("IsDelete = 0").ToDictionary(f => f.Id, f => f.Name ?? "");
        }

        private void WireSearch()
        {
            barEditItem1.EditValueChanged += (s, e) =>
            {
                string filter = barEditItem1.EditValue?.ToString() ?? "";
                gridView1.ActiveFilterString = string.IsNullOrWhiteSpace(filter)
                    ? ""
                    : $"[Description] Like '%{filter}%' OR [Num] Like '%{filter}%' OR [RegisterNo] Like '%{filter}%'";
            };
        }

        /// <summary>يربط كل بطاقة في tbMain بفلترها الخاص على الشبكة: "إجمالي" بلا فلتر، خمس بطاقات
        /// OverallStatus (مسودة/مُرسل/أُعيد إصداره/مُغلق/يتطلب تعديل وإعادة تقديم — انظر CIRStatus)، بطاقة
        /// "متأخر" بعدد أيام الإجراء (انظر IsLate)، وبطاقتا "معتمد/مرفوض الاستشاري" بـ CSTReviewStatus —
        /// نفس أسلوب ucPurchaseRequests.WireTileBar.
        ///
        /// tbiNeedsRevision (يتطلب تعديل وإعادة تقديم) تُطابق CIRStatus.NeedsRevision — وهي حالة حقيقية
        /// يصل إليها الطلب فعلياً (CIRStatus.MapReviewToOverallStatus عند CSTReviewStatus =
        /// ReviewReviseResubmit)، لكن لم تكن لها بطاقة مخصَّصة من قبل فلا تظهر منفصلة عن "مرفوض" في شريط
        /// الحالات رغم اختلاف معناها (يتطلب تعديلاً وإعادة تقديم، لا رفضاً نهائياً).</summary>
        private void WireTileBar()
        {
            tbiTotal.ItemClick += (s, e) => ApplyTileFilter(tbiTotal, null);
            tbiDraft.ItemClick += (s, e) => ApplyTileFilter(tbiDraft, r => r.OverallStatus == CIRStatus.Draft);
            tbiSubmitted.ItemClick += (s, e) => ApplyTileFilter(tbiSubmitted, r => r.OverallStatus == CIRStatus.Submitted);
            tbiReissued.ItemClick += (s, e) => ApplyTileFilter(tbiReissued, r => r.OverallStatus == CIRStatus.Reissued);
            tbiClosed.ItemClick += (s, e) => ApplyTileFilter(tbiClosed, r => r.OverallStatus == CIRStatus.Closed);
            tbiLate.ItemClick += (s, e) => ApplyTileFilter(tbiLate, IsLate);
            tbiApproved.ItemClick += (s, e) => ApplyTileFilter(tbiApproved,
                r => r.CSTReviewStatus == CIRStatus.ReviewApproved || r.CSTReviewStatus == CIRStatus.ReviewApprovedWithComments);
            tbiRejected.ItemClick += (s, e) => ApplyTileFilter(tbiRejected, r => r.CSTReviewStatus == CIRStatus.ReviewRejected);
            tbiNeedsRevision.ItemClick += (s, e) => ApplyTileFilter(tbiNeedsRevision, r => r.OverallStatus == CIRStatus.NeedsRevision);
        }

        /// <summary>النقر على البطاقة المُفعَّلة بالفعل يُلغي الفلتر (يعيد الشبكة لعرض الكل) بدل تكراره —
        /// تبديل تشغيل/إيقاف بدل الاضطرار للرجوع إلى "إجمالي" في كل مرة.</summary>
        private void ApplyTileFilter(DevExpress.XtraBars.Navigation.TileBarItem tile, Func<ConstructionInspectionRequestList, bool>? predicate)
        {
            bool isTogglingOff = _activeTile == tile && predicate != null;
            _activeTile = isTogglingOff ? null : (predicate == null ? null : tile);
            _activeTileFilter = isTogglingOff ? null : predicate;
            RefreshGridFilter();
        }

        /// <summary>يُطبَّق الفلتر النشط (إن وُجد) على _allRecords ويعيد ملء DataSource به — يُستدعى من
        /// ApplyTileFilter عند نقر بطاقة، ومن LoadData بعد كل تحميل بيانات جديد كي لا يُفقد الفلتر النشط
        /// عند الضغط على "تحديث" أو تغيير المشروع/التخصص.</summary>
        private void RefreshGridFilter()
        {
            var visible = _activeTileFilter == null ? _allRecords : _allRecords.Where(_activeTileFilter).ToList();
            DataSource.Clear();
            foreach (var item in visible) DataSource.Add(item);

            // DataSource.Add(item) المتكرر أعلاه يُحرِّك تركيز الشبكة إلى الصف المُضاف للتو مع كل إضافة،
            // فينتهي التركيز على آخر عنصر أُضيف — وبما أن الترتيب تنازلي (الأحدث أولاً)، فآخر عنصر مُضاف هو
            // الأقدم زمنياً. تُعاد الكتابة الصريحة هنا لأول صف (الأحدث) بعد انتهاء الحلقة. OpenForm يستدعي
            // FocusRow بعد LoadData مباشرة عند الإضافة/التعديل فيتجاوز هذا ويُركِّز على السجل المحفوظ
            // تحديداً بدلاً منه.
            if (gridView1.RowCount > 0) gridView1.FocusedRowHandle = 0;
        }

        /// <summary>يُحدِّث عدّاد كل بطاقة في tbMain من _allRecords الحالية (بلا تأثير الفلتر النشط —
        /// الأعداد دائماً عن إجمالي الطلبات المُحمَّلة، لا عن الصفوف المعروضة فقط).</summary>
        private void UpdateTileCounts()
        {
            tbiTotal.Elements[1].Text = _allRecords.Count.ToString();
            tbiDraft.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == CIRStatus.Draft).ToString();
            tbiSubmitted.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == CIRStatus.Submitted).ToString();
            tbiReissued.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == CIRStatus.Reissued).ToString();
            tbiClosed.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == CIRStatus.Closed).ToString();
            tbiLate.Elements[1].Text = _allRecords.Count(IsLate).ToString();
            tbiApproved.Elements[1].Text = _allRecords.Count(r =>
                r.CSTReviewStatus == CIRStatus.ReviewApproved || r.CSTReviewStatus == CIRStatus.ReviewApprovedWithComments).ToString();
            tbiRejected.Elements[1].Text = _allRecords.Count(r => r.CSTReviewStatus == CIRStatus.ReviewRejected).ToString();
            tbiNeedsRevision.Elements[1].Text = _allRecords.Count(r => r.OverallStatus == CIRStatus.NeedsRevision).ToString();
        }

        private void SetupAconexStyle()
        {
            colPrjId.Caption = "المشروع";

            //if (gridView1 == null) return;

            //DesignSystem.ApplyStatusColoring(gridView1, "CSTReviewStatus");
            //gridView1.OptionsView.ShowAutoFilterRow = true;

            // These belong to the form's "سجل الموافقات" tab, not the register list — hide here to
            // keep the grid readable.
            //foreach (var name in new[] { "SubmittedDate", "CSTReturnedDate", "ReviewedBy",
            //    "ReviewedJobTitle", "ApprovedBy", "ApprovedJobTitle", "CSTReviewComment" })
            //{
            //    var hidden = gridView1.Columns[name];
            //    if (hidden != null) hidden.Visible = false;
            //}

            //SetCaption("Num",            "رقم طلب الفحص",        visibleIndex: 0);
            //SetCaption("RegisterNo",     "الرقم الدفتري",        visibleIndex: 1, centered: true);
            //SetCaption("Rev",            "الإصدار",              visibleIndex: 2, centered: true);
            //SetCaption("Discipline",     "التخصص",               visibleIndex: 3, centered: true);
            //SetCaption("Description",    "وصف العمل المطلوب فحصه", visibleIndex: 4);
            //SetCaption("CSTReviewStatus","نتيجة الفحص",          visibleIndex: 5, centered: true);
            //SetCaption("PreparedDate",   "تاريخ طلب الفحص",      visibleIndex: 6);

            //gridView1.DoubleClick += (s, e) =>
            //{
            //    if (gridView1.GetFocusedRow() is ConstructionInspectionRequestList rec)
            //        OpenForm(rec.Id);
            //};
        }

        private void SetCaption(string field, string caption, int? visibleIndex = null, bool centered = false)
        {
            //var col = gridView1.Columns[field];
            //if (col == null) return;
            //col.Caption = caption;
            //col.Visible = true;
            //if (visibleIndex != null) col.VisibleIndex = visibleIndex.Value + 1; // colPrint keeps index 0
            //if (centered) DesignSystem.SetColumnCentered(col);
        }

        public void LoadData()
        {
            var overlayHandle = ShowOverlay();
            try
            {
                RefreshDisciplineCaches();

                string filter = "IsDelete = 0";
                var raw = lookUpEditPrj.EditValue as int?;
                var disciplineId = lueDiscipline.EditValue as int?;
                var secondaryDisciplineId = lueSecondaryDiscipline.EditValue as int?;
                var inspectionActivityId = lueInspectionActivity.EditValue as int?;

                // فلتر التخصص/التخصص الثانوي/نشاط الفحص: 0 أو غير محدَّد = "-- الكل --" (انظر
                // SetupLookups)، وإلا معرّف محدَّد.
                if (disciplineId is > 0)
                    filter += " AND DisciplineId = @DisciplineId";
                if (secondaryDisciplineId is > 0)
                    filter += " AND SecondaryDisciplineId = @SecondaryDisciplineId";
                if (inspectionActivityId is > 0)
                    filter += " AND InspectionActivityId = @InspectionActivityId";

                object queryParams;

                // Id = 0 أو غير محدَّد هو رمز خيار "-- الكل --" (انظر SetupLookups): كل المشاريع
                // المصرَّح للمستخدم بالاطلاع عليها. قيمة موجبة = مشروع محدَّد.
                if (raw is > 0)
                {
                    filter += " AND PrjId = @Id";
                    queryParams = new { Id = raw, DisciplineId = disciplineId, SecondaryDisciplineId = secondaryDisciplineId, InspectionActivityId = inspectionActivityId };
                }
                else
                {
                    var ids = _grantedProjectIds.Count > 0 ? string.Join(",", _grantedProjectIds) : "-1";
                    filter += $" AND PrjId IN ({ids})";
                    queryParams = new { DisciplineId = disciplineId, SecondaryDisciplineId = secondaryDisciplineId, InspectionActivityId = inspectionActivityId };
                }

                var data = DC.ConstructionInspectionRequestList.GetBy(filter, queryParams);
                _allRecords.Clear();
                _allRecords.AddRange(data);

                // يعيد ملء DataSource بالفلتر النشط في tbMain (إن وُجد) ويحدِّث عدّادات البطاقات — كلاهما
                // يعتمد على _allRecords الذي بُني للتو أعلاه.
                RefreshGridFilter();
                UpdateTileCounts();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show($"خطأ أثناء تحميل البيانات:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(overlayHandle);
            }
        }

        public override void OnProjectChanged()
        {
            base.OnProjectChanged();
            // يزامن فلتر الشاشة المحلي مع مبدّل المشروع العام في التطبيق — تغيير EditValue يستدعي
            // LoadData تلقائياً عبر EditValueChanged (انظر SetupLookups).
            lookUpEditPrj.EditValue = Session.SelectedProjectId;
        }

        // نقطة الدخول الموحّدة (bbiNew/فتح/تعديل والنقر المزدوج) — الفحص هنا يمنع تجاوز الصلاحية عبر
        // النقر المزدوج الذي لا يمر بحالة تفعيل الأزرار. viewOnly=true (زر "فتح") لا يحتاج سوى صلاحية
        // دخول الشاشة العامة، ويفتح frmCIRAddEdit في وضع قراءة فقط حقيقي (انظر ApplyViewOnlyMode) —
        // منفصل تماماً عن "تعديل" الذي يتطلب CIRSave فعلياً.
        private void OpenForm(int id = 0, bool viewOnly = false)
        {
            bool allowed = id <= 0
                ? PermissionService.HasPermission(PermNames.CIRAdd)
                : viewOnly || PermissionService.HasPermission(PermNames.CIRSave);

            if (!_canManage || !allowed)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("ليس لديك صلاحية إدارة طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmCIRAddEdit frm;
            try { frm = new frmCIRAddEdit(id, viewOnly); }
            finally { CloseOverlay(handle); }

            using var _ = frm;
            var result = frm.ShowDialog(this.FindForm());
            if (result == DialogResult.OK)
            {
                LoadData();
                // id=0 يعني طلباً جديداً — لا نعرف رقمه إلا بعد الحفظ الفعلي (frm.SavedId، انظر
                // frmCIRAddEdit.SavedId)، بينما التعديل يعرف الرقم مسبقاً من نفس id المُمرَّر أعلاه.
                FocusRow(id > 0 ? id : frm.SavedId);
            }
        }

        /// <summary>Focuses and scrolls to the row matching the given Id — called after LoadData()
        /// following a successful add/edit so the just-saved/edited record stays selected instead of
        /// the grid resetting to its first visible row.</summary>
        private void FocusRow(int id)
        {
            if (id <= 0) return;
            int handle = gridView1.LocateByValue("Id", id);
            if (handle == DevExpress.XtraGrid.GridControl.InvalidRowHandle) return;
            gridView1.FocusedRowHandle = handle;
            gridView1.MakeRowVisible(handle);
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => OpenForm(0);

        private void BtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() is ConstructionInspectionRequestList rec)
                OpenForm(rec.Id, viewOnly: true);
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("الرجاء تحديد طلب فحص لفتحه.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() is ConstructionInspectionRequestList rec)
                OpenForm(rec.Id);
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("الرجاء تحديد طلب فحص لفتحه.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_canManage || !PermissionService.HasPermission(PermNames.CIRDelete))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("ليس لديك صلاحية حذف طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridView1.GetFocusedRow() is not ConstructionInspectionRequestList rec)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("الرجاء تحديد طلب فحص لحذفه.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"هل أنت متأكد من حذف طلب الفحص رقم {rec.Num?.ToString("D3")}؟",
                    "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            var handle = ShowOverlay();
            try
            {
                DC.ConstructionInspectionRequestList.Delete(rec.Id);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("خطأ أثناء الحذف: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally { CloseOverlay(handle); }

            LoadData();
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            => LoadData();

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => PrintGrid();

        // يطبع سجلات DataSource كما هي مفلترة حالياً (فلتر المشروع/التخصص أعلى الشبكة + بطاقة tbMain
        // النشطة إن وُجدت — انظر RefreshGridFilter)، عبر تقرير rptConstructionInspectionLog. يقرأ من
        // DataSource مباشرةً لا من gridView1.RowCount/GetVisibleRowHandle كما تفعل ucPurchaseRequests.
        // PrintGrid: gridView1 هنا لديه GroupCount = 2 بلا أي عمود مُعيَّن فعلياً لتلك المستويات (انظر
        // ucCIR.Designer.cs) — حالة معطوبة تجعل RowCount/GetVisibleRowHandle يُخرجان تعيينات صفوف غير
        // موثوقة (وهذا ما كان يُكرِّر آخر سجل عدّة مرات). القراءة من DataSource تتفادى هذا الخلل تماماً،
        // والتقرير نفسه يُعيد فرز الصفوف بحسب المشروع ثم التخصص على أي حال (انظر CIRPrinter.PrintLog).
        private void PrintGrid()
        {
            if (!PermissionService.HasPermission(PermNames.CIRPrint))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("ليس لديك صلاحية طباعة طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var rows = DataSource.ToList();

                if (rows.Count == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("لا توجد بيانات للطباعة.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var handle = ShowOverlay();
                try { CIRPrinter.PrintLog(rows, lookUpEditPrj.EditValue as int?); }
                finally { CloseOverlay(handle); }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RiButtonPrint_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!PermissionService.HasPermission(PermNames.CIRPrint))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("ليس لديك صلاحية طباعة طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gridView1.GetFocusedRow() is ConstructionInspectionRequestList rec)
            {
                var handle = ShowOverlay();
                try { CIRPrinter.Print(rec.Id, this.FindForm() ?? (Control)this); }
                finally { CloseOverlay(handle); }
            }
        }

        private void RiButtonReissue_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!_canManage || !PermissionService.HasPermission(PermNames.CIRReissue))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("ليس لديك صلاحية إعادة إصدار طلبات فحص الأعمال (CIR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridView1.GetFocusedRow() is not ConstructionInspectionRequestList rec) return;

            if (DevExpress.XtraEditors.XtraMessageBox.Show(
                    "سيتم إنشاء إصدار جديد من طلب الفحص هذا لبدء دورة مراجعة جديدة، وسيُعتبر الإصدار الحالي إصداراً سابقاً. هل تريد المتابعة؟",
                    "تأكيد إعادة الإصدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int newId;
            var handle = ShowOverlay();
            try
            {
                newId = CIRReissuer.Reissue(rec);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("خطأ أثناء إعادة الإصدار: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally { CloseOverlay(handle); }

            if (newId <= 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("تعذّرت إعادة الإصدار.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DevExpress.XtraEditors.XtraMessageBox.Show("تم إنشاء الإصدار الجديد بنجاح.", "نجاح",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            FocusRow(newId);
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        // نفس نمط ShowOverlay/CloseOverlay المعتمد في ucPurchaseOrder — يعرض مؤشراً دوّاراً فوق هذه
        // الشاشة أثناء أي عملية تلمس قاعدة البيانات، بدل ترك الأزرار بلا استجابة ظاهرة.
        // الفحص IsHandleCreated && Visible يمنع استثناء DevExpress عند استدعاء ShowOverlay
        // قبل أن يكون الـ Control مرئياً (مثلاً أثناء حدث Load).
        private IOverlaySplashScreenHandle? ShowOverlay()
        {
            if (!IsHandleCreated || !Visible) return null;
            return SplashScreenManager.ShowOverlayForm(this);
        }

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
