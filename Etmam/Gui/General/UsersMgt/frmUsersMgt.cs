using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using Core;
using DevExpress.XtraEditors;
namespace Etmam
{
    public partial class frmUsersMgt : XtraForm
    {
        protected Data.DataContext dc => Data.DataContext.Shared;

        protected DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle ShowOverlay()
        {
            return DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(this);
        }

        protected void CloseOverlay(DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(handle);
        }

        protected async Task ExecuteAsync(Func<Task> task)
        {
            var handle = ShowOverlay();
            try
            {
                await task();
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        #region Initialization
        private Point _passwordLocationFull, _passwordLabelLocationFull, _rePasswordLocationFull, _rePasswordLabelLocationFull;
        private Point _passwordLocationCompact, _passwordLabelLocationCompact, _rePasswordLocationCompact, _rePasswordLabelLocationCompact;

        public frmUsersMgt()
        {
            InitializeComponent();

            // نلتقط المواضع الأصلية للحقول لإعادة ترتيب صناديق كلمة السر عند إخفاء باقي الحقول
            _passwordLocationFull = txtPassword.Location;
            _passwordLabelLocationFull = labelControl3.Location;
            _rePasswordLocationFull = txtRePassword.Location;
            _rePasswordLabelLocationFull = labelControl4.Location;
            _passwordLocationCompact = txtName.Location;
            _passwordLabelLocationCompact = labelControl1.Location;
            _rePasswordLocationCompact = txtJobTitel.Location;
            _rePasswordLabelLocationCompact = labelControl2.Location;

            // يظهر فقط عند الضغط على btnPermissions (انظر btnPermissions_Click)، ويُخفى صراحة في كل
            // نقطة دخول أخرى تُظهر navigationPage4 (إضافة/تعديل مستخدم، تعديل كلمة السر، التوقيع)
            btnExpandedCollapse.Visible = false;

            gridView1.FocusedRowChanged += (s, e) => UpdateUserStatusButtonText();

            // Tints each tree row by its depth (root/child/grandchild) instead of a single flat color —
            // fires once per cell, but setting the same BackColor on every cell of a node colors the
            // whole row. Only treeList1 (الإجراءات) actually has more than one level; the other three are
            // flat lists that always land on the level-0 color.
            treeList1.NodeCellStyle += TreeList_NodeCellStyle;
            treeList2.NodeCellStyle += TreeList_NodeCellStyle;
            treeList3.NodeCellStyle += TreeList_NodeCellStyle;
            treeList4.NodeCellStyle += TreeList_NodeCellStyle;

            InitializeCountryCodeLookup();
            txtPhoneNumber.KeyPress += TxtPhoneNumber_KeyPress;
        }

        // مفاتيح دولية شائعة لمستخدمي النظام (خليجيون بشكل أساسي، مع عدد من جنسيات العمالة الوافدة
        // الشائعة) — القيمة المخزنة هي المفتاح بدون علامة "+" (مثال: "966")، والعرض في القائمة المنسدلة
        // يجمع العلم (Unicode emoji، لا يحتاج صور) والمفتاح واسم الدولة.
        private sealed class CountryCodeItem
        {
            public string Code { get; set; } = "";
            public string Country { get; set; } = "";
            public string Flag { get; set; } = "";
            public string Display => $"{Flag} +{Code} {Country}";
        }

        private static readonly List<CountryCodeItem> _countryCodes = new()
        {
            new CountryCodeItem { Code = "966", Country = "السعودية", Flag = "🇸🇦" },
            new CountryCodeItem { Code = "971", Country = "الإمارات", Flag = "🇦🇪" },
            new CountryCodeItem { Code = "965", Country = "الكويت", Flag = "🇰🇼" },
            new CountryCodeItem { Code = "973", Country = "البحرين", Flag = "🇧🇭" },
            new CountryCodeItem { Code = "974", Country = "قطر", Flag = "🇶🇦" },
            new CountryCodeItem { Code = "968", Country = "عُمان", Flag = "🇴🇲" },
            new CountryCodeItem { Code = "20", Country = "مصر", Flag = "🇪🇬" },
            new CountryCodeItem { Code = "962", Country = "الأردن", Flag = "🇯🇴" },
            new CountryCodeItem { Code = "961", Country = "لبنان", Flag = "🇱🇧" },
            new CountryCodeItem { Code = "963", Country = "سوريا", Flag = "🇸🇾" },
            new CountryCodeItem { Code = "967", Country = "اليمن", Flag = "🇾🇪" },
            new CountryCodeItem { Code = "249", Country = "السودان", Flag = "🇸🇩" },
            new CountryCodeItem { Code = "212", Country = "المغرب", Flag = "🇲🇦" },
            new CountryCodeItem { Code = "213", Country = "الجزائر", Flag = "🇩🇿" },
            new CountryCodeItem { Code = "216", Country = "تونس", Flag = "🇹🇳" },
            new CountryCodeItem { Code = "91", Country = "الهند", Flag = "🇮🇳" },
            new CountryCodeItem { Code = "92", Country = "باكستان", Flag = "🇵🇰" },
            new CountryCodeItem { Code = "880", Country = "بنغلاديش", Flag = "🇧🇩" },
            new CountryCodeItem { Code = "63", Country = "الفلبين", Flag = "🇵🇭" },
            new CountryCodeItem { Code = "94", Country = "سريلانكا", Flag = "🇱🇰" },
            new CountryCodeItem { Code = "1", Country = "الولايات المتحدة", Flag = "🇺🇸" },
            new CountryCodeItem { Code = "44", Country = "المملكة المتحدة", Flag = "🇬🇧" },
        };

        private const string DefaultCountryCode = "966";

        private void InitializeCountryCodeLookup()
        {
            lookUpEditCountryCode.Properties.DataSource = _countryCodes;
            lookUpEditCountryCode.Properties.DisplayMember = nameof(CountryCodeItem.Display);
            lookUpEditCountryCode.Properties.ValueMember = nameof(CountryCodeItem.Code);
            lookUpEditCountryCode.Properties.Columns.Clear();
            lookUpEditCountryCode.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameof(CountryCodeItem.Display), "الدولة"));
            lookUpEditCountryCode.Properties.ShowHeader = false;
            lookUpEditCountryCode.Properties.NullText = "";
            lookUpEditCountryCode.EditValue = DefaultCountryCode;

            // TxtPhoneNumber_KeyPress يمنع أي شيء غير الأرقام؛ هذا فقط يوضّح الصيغة المتوقعة (رقم جوال
            // سعودي يبدأ بـ 5) داخل الصندوق الفارغ دون حجز مساحة فعلية من القيمة.
            txtPhoneNumber.Properties.NullValuePrompt = "5XXXXXXXX";
            txtPhoneNumber.Properties.NullValuePromptShowForEmptyValue = true;
            txtPhoneNumber.Properties.MaxLength = 15;
        }

        private void TxtPhoneNumber_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // يفصل قيمة PhoneNumber المخزّنة (مثال: "+966501234567") إلى مفتاح الدولة والرقم المحلي،
        // بمطابقة أطول مفتاح مطابق أولاً (لتفادي التباس مفاتيح بادئة مثل "1" مقابل "966").
        private static (string code, string number) SplitPhoneNumber(string? full)
        {
            if (string.IsNullOrWhiteSpace(full)) return (DefaultCountryCode, "");

            var digits = full.TrimStart('+');
            foreach (var c in _countryCodes.OrderByDescending(c => c.Code.Length))
            {
                if (digits.StartsWith(c.Code, StringComparison.Ordinal))
                    return (c.Code, digits.Substring(c.Code.Length));
            }
            return (DefaultCountryCode, digits);
        }

        // يجمع مفتاح الدولة المختار مع أرقام txtPhoneNumber في صيغة واحدة تُحفَظ في UsersList.PhoneNumber.
        private string? ComposePhoneNumber()
        {
            var digits = new string((txtPhoneNumber.Text ?? "").Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(digits)) return null;

            var code = lookUpEditCountryCode.EditValue?.ToString();
            if (string.IsNullOrEmpty(code)) code = DefaultCountryCode;
            return $"+{code}{digits}";
        }

        // "إيقاف" for an active user (click deactivates), "تفعيل" for an inactive one (click activates).
        private void UpdateUserStatusButtonText()
        {
            var user = gridView1.GetFocusedRow() as Core.UsersList;
            btnUserStatus.Text = user == null || user.IsActive ? "إيقاف" : "تفعيل";
        }

        private static readonly Color[] _treeLevelBackColors =
        {
            Color.FromArgb(222, 232, 244), // Level 0 (root)
            Color.FromArgb(238, 243, 249), // Level 1
            Color.White                    // Level 2+
        };

        private void TreeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            int level = Math.Min(e.Node.Level, _treeLevelBackColors.Length - 1);
            e.Appearance.BackColor = _treeLevelBackColors[level];
            e.Appearance.Options.UseBackColor = true;
        }

        //public void ShowPermissionsPage()
        //{
        //    nfData.SelectedPage = npPermissions;
        //    nfButton.SelectedPage = navigationPage4;
        //}

        private async void frmUsersMgt_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        #endregion

        #region Data Loading & Permissions logic
        private async Task LoadDataAsync()
        {
            await ExecuteAsync(async () =>
            {
                var rowHandle = gridView1.FocusedRowHandle;

                // Fetch all users once
                var allUsers = await Task.Run(() => dc.UsersList.GetAll());
                bool isAdmin = Session.CurrentUser.Id == 1 || Session.CurrentUser.Role == "Admin";
                var activeUsers = allUsers.Where(x => !x.IsDelete)
                    .Where(x => isAdmin || x.Id == Session.CurrentUser.Id)
                    .ToList();

                this.Invoke(new Action(() =>
                {
                    usersListBindingSource.DataSource = activeUsers;
                    colRole.Visible = isAdmin;
                    colIsActive.Visible = isAdmin;

                    if (rowHandle >= 0)
                        gridView1.FocusedRowHandle = rowHandle;

                    gridControl1.RefreshDataSource();
                    UpdateUserStatusButtonText();

                    lookUpUser.Properties.DataSource = allUsers;
                    lookUpUser.Properties.DisplayMember = nameof(Core.UsersList.UserName);
                    lookUpUser.Properties.ValueMember = nameof(Core.UsersList.Id);
                    lookUpUser.EditValue = Session.CurrentUser.Id;
                }));

                await ApplyUserPermissionsAsync();
            });
        }

        private async Task ApplyUserPermissionsAsync()
        {
            if (Session.CurrentUser.Id == 0) return;

            // Warms PermissionService's cache off the UI thread; the HasPermission calls
            // below then hit the cache instead of issuing their own DB round-trips.
            await Task.Run(() => Data.PermissionService.HasPermission(dc, PermNames.UserAdd));

            this.Invoke(new Action(() =>
            {
                bool HasPerm(string name) => Data.PermissionService.HasPermission(dc, name);
                btnNewUser.Enabled = HasPerm(PermNames.UserAdd);
                btnEditUser.Enabled = HasPerm(PermNames.UserEdit);
                btnEditPassword.Enabled = HasPerm(PermNames.UserEditPassword);
                btnUserStatus.Enabled = HasPerm(PermNames.UserToggleStatus);
                btnSign.Enabled = HasPerm(PermNames.UserSign);
                btnPermissions.Enabled = HasPerm(PermNames.UserPermissions);
                btnDeleteUser.Enabled = HasPerm(PermNames.UserDelete);
            }));
        }

        // lookUpUser.EditValue is set both explicitly (btnPermissions_Click) and during initial
        // form Load, each firing its own background LoadPermissionsAsync call. If the admin opens
        // a different user's permissions before the earlier call's DB round-trip finishes, the
        // stale call can complete last and overwrite the tree with the wrong user's data (most
        // visibly: the initial Load's call is for the logged-in admin, who has PermsStatus = true
        // for every project — so a losing race shows every project checked). This token makes a
        // call discard its result if a newer call has since started.
        private int _permissionsLoadRequestId;

        private async Task LoadPermissionsAsync(int userId)
        {
            int requestId = ++_permissionsLoadRequestId;

            // Overlay must be anchored to the form, not treeList1: treeList1 lives on the
            // "Permissions" navigation page, which isn't necessarily the active page yet when this
            // runs (e.g. it's triggered by setting lookUpUser.EditValue during the initial form
            // Load) — ShowOverlayForm throws if its owner control isn't visible.
            var handle = ShowOverlay();
            try
            {
                var data = await Task.Run(() =>
                {
                    var allPerms = dc.PermissionsList.GetAll();
                    var userPermsStatus = dc.UserPermissionStatus.GetBy("UserID = @UserID", new { UserID = userId });
                    var permissionsData = allPerms.Select(p => new PermissionViewModel
                    {
                        Id = p.Id,
                        IdParent = p.ParentID,
                        Description = p.Name,
                        PermsStatus = userPermsStatus.Any(ups => ups.PermsID == p.Id && ups.PermsStatus)
                    }).ToList();

                    // treeList2 is populated straight from UserProjectAccess (LEFT JOINed to ProjectsList
                    // for the name) rather than iterating ProjectsList and checking membership in-memory —
                    // the checked state shown is exactly the PermsStatus column for this UserID.
                    var projectsData = new Data.SqlDataHelper<AccessViewModel>().GetBySql(
                        @"SELECT p.Id, p.Name, upa.PermsStatus
                          FROM ProjectsList p
                          LEFT JOIN UserProjectAccess upa ON upa.PrjId = p.Id AND upa.UserID = @UserID
                          WHERE p.IsDelete = 0",
                        new { UserID = userId });

                    var allStores = dc.StoreList.GetBy("IsDelete = 0");
                    var userStoreAccess = dc.UserStoreAccess.GetBy("UserID = @UserID", new { UserID = userId });
                    var storesData = allStores.Select(s => new AccessViewModel
                    {
                        Id = s.Id,
                        Name = s.Name ?? string.Empty,
                        PermsStatus = userStoreAccess.Any(a => a.StoreId == s.Id && a.PermsStatus),
                        CanReceive = userStoreAccess.Any(a => a.StoreId == s.Id && a.CanReceive),
                        CanIssue = userStoreAccess.Any(a => a.StoreId == s.Id && a.CanIssue),
                        CanTransfer = userStoreAccess.Any(a => a.StoreId == s.Id && a.CanTransfer)
                    }).ToList();

                    var allWorkflows = dc.WorkflowDefinitionList.GetBy("IsDelete = 0");
                    var userWorkflowAccess = dc.UserWorkflowAccess.GetBy("UserID = @UserID", new { UserID = userId });
                    var workflowsData = allWorkflows.Select(w => new AccessViewModel
                    {
                        Id = w.Id,
                        Name = w.Name ?? string.Empty,
                        PermsStatus = userWorkflowAccess.Any(a => a.WorkflowId == w.Id && a.PermsStatus)
                    }).ToList();

                    return (permissionsData, projectsData, storesData, workflowsData);
                });

                if (requestId != _permissionsLoadRequestId) return; // superseded by a newer request; discard

                this.Invoke(new Action(() =>
                {
                    BindAccessTree(treeList1, data.permissionsData);
                    BindAccessTree(treeList2, data.projectsData);
                    BindAccessTree(treeList3, data.storesData);
                    BindAccessTree(treeList4, data.workflowsData);
                }));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الصلاحيات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private static void BindAccessTree(DevExpress.XtraTreeList.TreeList tree, object dataSource)
        {
            tree.DataSource = dataSource;
            tree.KeyFieldName = "Id";
            tree.ParentFieldName = "IdParent";
            tree.CollapseAll();
        }
        #endregion

        #region Form Event Handlers
        // إظهار كل صناديق الإدخال أو الاقتصار على صناديق كلمة السر فقط (لصفحة "تعديل كلمة المرور")
        private void SetDataEntryFieldsVisibility(bool showAll)
        {
            labelControl1.Visible = showAll;
            txtName.Visible = showAll;
            labelControl2.Visible = showAll;
            txtJobTitel.Visible = showAll;
            labelControl6.Visible = showAll;
            txtUserName.Visible = showAll;
            labelControl7.Visible = showAll;
            txtCompany.Visible = showAll;
            labelControl8.Visible = showAll;
            txtPhoneNumber.Visible = showAll;
            lookUpEditCountryCode.Visible = showAll;

            // عند إخفاء باقي الحقول، ننقل صناديق كلمة السر لأعلى الصفحة بدلاً من تركها معلقة وسط فراغ
            txtPassword.Location = showAll ? _passwordLocationFull : _passwordLocationCompact;
            labelControl3.Location = showAll ? _passwordLabelLocationFull : _passwordLabelLocationCompact;
            txtRePassword.Location = showAll ? _rePasswordLocationFull : _rePasswordLocationCompact;
            labelControl4.Location = showAll ? _rePasswordLabelLocationFull : _rePasswordLabelLocationCompact;
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            usersListBindingSource.AddNew();
            var user = usersListBindingSource.Current as Core.UsersList;
            if (user != null)
            {
                user.IsActive = true;
                user.Role = "User";
                user.IsFirstLogin = true;
            }
            SetDataEntryFieldsVisibility(true);
            // txtPassword يُفرَّغ تلقائيًا لأنه مرتبط بـ user.Password الفارغ (AddNew)، لكن txtRePassword
            // غير مرتبط بأي مصدر بيانات فيبقى محتفظًا بقيمته من عملية تعديل سابقة إن لم يُفرَّغ يدويًا
            txtRePassword.Text = string.Empty;
            // txtPhoneNumber/lookUpEditCountryCode غير مرتبطين بمصدر البيانات (انظر ComposePhoneNumber)،
            // فيجب تصفيرهما يدويًا هنا وإلا بقيا محتفظين بقيمة المستخدم المعروض سابقًا في الشبكة
            lookUpEditCountryCode.EditValue = DefaultCountryCode;
            txtPhoneNumber.Text = string.Empty;
            nfData.SelectedPage = npUsersDataEntry;
            nfButton.SelectedPage = navigationPage4;
            // لا يُعتمد فقط على nfData.SelectedPageChanged لإخفاء الزر: مع نوع الانتقال Fade لم يكن
            // يُطبَّق دائمًا في الوقت المناسب، فيبقى الزر ظاهرًا هنا رغم أننا لسنا في صفحة الصلاحيات
            btnExpandedCollapse.Visible = false;
            txtName.Focus();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                SetDataEntryFieldsVisibility(true);
                nfData.SelectedPage = npUsersDataEntry;
                nfButton.SelectedPage = navigationPage4;
                btnExpandedCollapse.Visible = false;
                txtRePassword.Text = txtPassword.Text; // Pre-fill re-password for editing

                // مثل الباسورد أعلاه: PhoneNumber ليس مرتبطًا مباشرة بأي من الصندوقين، فيُفكَّك يدويًا
                // إلى مفتاح الدولة والرقم المحلي عند فتح صف موجود للتعديل
                var user = gridView1.GetFocusedRow() as Core.UsersList;
                var (code, number) = SplitPhoneNumber(user?.PhoneNumber);
                lookUpEditCountryCode.EditValue = code;
                txtPhoneNumber.Text = number;
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var user = gridView1.GetFocusedRow() as Core.UsersList;
            if (user == null) return;

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا المستخدم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    user.IsDelete = true;
                    dc.UsersList.Edit(user.Id, user);
                    XtraMessageBox.Show("تم حذف المستخدم بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("حدث خطأ أثناء الحذف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnUserStatus_Click(object sender, EventArgs e)
        {
            var user = gridView1.GetFocusedRow() as Core.UsersList;
            if (user == null) return;

            user.IsActive = !user.IsActive;
            dc.UsersList.Edit(user.Id, user);
            XtraMessageBox.Show($"تم {(user.IsActive ? "تفعيل" : "تعطيل")} المستخدم بنجاح", "الحالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDataAsync();
        }

        private async void btnPermissions_Click(object sender, EventArgs e)
        {
            var user = gridView1.GetFocusedRow() as Core.UsersList;
            if (user != null)
            {
                nfData.SelectedPage = npPermissions;
                nfButton.SelectedPage = navigationPage4;
                btnExpandedCollapse.Visible = true;
                lookUpUser.EditValue = user.Id;
                await LoadPermissionsAsync(user.Id);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // Toggles whichever tree list is on the active tab page (permissions/projects/stores/workflows
        // each live on their own xtraTabPage, so the selected tab is what "focus" means here).
        private void btnExpandedCollapse_Click(object sender, EventArgs e)
        {
            var tree = xtraTabControl1.SelectedTabPage?.Name switch
            {
                nameof(xtraTabPage1) => treeList1,
                nameof(xtraTabPage2) => treeList2,
                nameof(xtraTabPage3) => treeList3,
                nameof(xtraTabPage4) => treeList4,
                _ => null
            };
            if (tree == null || tree.Nodes.Count == 0) return;

            if (tree.Nodes[0].Expanded)
                tree.CollapseAll();
            else
                tree.ExpandAll();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (nfData.SelectedPage == npUsersDataEntry)
            {
                await SaveUser();
            }
            else if (nfData.SelectedPage == npPermissions)
            {
                SavePermissions();
            }
            else if (nfData.SelectedPage == npSign)
            {
                SaveSignature();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            usersListBindingSource.CancelEdit();
            nfData.SelectedPage = npMain;
            nfButton.SelectedPage = navigationPage3;
        }

        private async void lookUpUser_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpUser.EditValue != null && int.TryParse(lookUpUser.EditValue.ToString(), out int userId))
            {
                await LoadPermissionsAsync(userId);
            }
        }
        #endregion

        #region Logic Methods
        private async Task SaveUser()
        {
            usersListBindingSource.EndEdit();
            var user = usersListBindingSource.Current as Core.UsersList;
            if (user == null) return;

            // Validation
            // نتحقق من بيانات الكائن نفسه لا من نص الصناديق مباشرة، لأن صناديق الاسم/حساب الدخول
            // قد تكون مخفية (مثلاً في شاشة "تعديل كلمة المرور") رغم أن قيمتها المرتبطة سليمة.
            if (string.IsNullOrWhiteSpace(user.FullName) || string.IsNullOrWhiteSpace(user.UserName))
            {
                XtraMessageBox.Show("يرجى إدخال البيانات الأساسية (الإسم وحساب الدخول)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                XtraMessageBox.Show("يرجى إدخال كلمة السر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtRePassword.Text)
            {
                XtraMessageBox.Show("كلمة السر غير متطابقة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.Text == "0000")
            {
                XtraMessageBox.Show("لا يمكن استخدام '0000' ككلمة سر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                // PhoneNumber ليس مرتبطًا بأي من الصندوقين (انظر ComposePhoneNumber)، فيُجمَع هنا من
                // مفتاح الدولة المختار وأرقام txtPhoneNumber قبل الحفظ.
                user.PhoneNumber = ComposePhoneNumber();

                // txtPassword is bound directly to user.Password, so on an unchanged edit it already
                // holds the stored hash — only hash it when it's still plaintext (new or changed).
                if (!string.IsNullOrEmpty(user.Password) && !Core.Security.PasswordHasher.IsHashed(user.Password))
                {
                    user.Password = Core.Security.PasswordHasher.Hash(user.Password);
                }

                if (user.Id == 0)
                {
                    user.CreatedDate = DateTime.Now;
                    user.IsFirstLogin = true;
                    user.CreatedMachine = Environment.MachineName;
                    dc.UsersList.Add(user);
                    InitializeProjectAccessRows(user.Id);
                    InitializeWorkflowAccessRows(user.Id);
                }
                else
                {
                    dc.UsersList.Edit(user.Id, user);
                }

                XtraMessageBox.Show("تم حفظ البيانات بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                btnReturn_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // مستخدم جديد لا يحصل تلقائيًا على وصول لأي مشروع؛ يُنشأ له سجل صريح بحالة false لكل مشروع نشط
        // حالياً، ليظهر بوضوح في تبويب الصلاحيات وينتظر منح الوصول يدويًا (نفس نمط "الرفض الافتراضي"
        // المتبع عند إضافة مشروع جديد لبقية المستخدمين، انظر frmProjectAddEdit.OnAfterInsert)
        private void InitializeProjectAccessRows(int userId)
        {
            var activeProjects = dc.ProjectsList.GetBy("IsDelete = 0");
            foreach (var project in activeProjects)
            {
                dc.UserProjectAccess.Add(new Core.UserProjectAccess
                {
                    UserID = userId,
                    PrjId = project.Id,
                    PermsStatus = false,
                    UpdateDate = DateTime.Now,
                    UpdateMachine = Session.Machine,
                    UpdateBy = Session.CurrentUser?.Id ?? 1
                });
            }
        }

        // Mirror of InitializeProjectAccessRows above, for workflow definitions: a new user gets an
        // explicit false row per existing WorkflowDefinitionList so the access matrix is always
        // complete and visible in treeList4, rather than "no row = implicitly denied".
        private void InitializeWorkflowAccessRows(int userId)
        {
            var activeWorkflows = dc.WorkflowDefinitionList.GetBy("IsDelete = 0");
            foreach (var workflow in activeWorkflows)
            {
                dc.UserWorkflowAccess.Add(new Core.UserWorkflowAccess
                {
                    UserID = userId,
                    WorkflowId = workflow.Id,
                    PermsStatus = false,
                    UpdateDate = DateTime.Now,
                    UpdateMachine = Session.Machine,
                    UpdateBy = Session.CurrentUser?.Id ?? 1
                });
            }
        }

        private void SavePermissions()
        {
            if (lookUpUser.EditValue == null || !int.TryParse(lookUpUser.EditValue.ToString(), out int userId)) return;

            try
            {
                // A checkbox the user just clicked stays in the in-place editor until it loses focus —
                // if "حفظ" is clicked right after toggling it (without clicking elsewhere first), reading
                // DataSource below would silently miss that last change. PostEditor() forces it into the
                // bound list before we read PermsStatus off of it.
                treeList1.PostEditor();
                treeList2.PostEditor();
                treeList3.PostEditor();
                treeList4.PostEditor();

                // Simple logic for each tab: delete old and insert new based on checked status
                var permViewModels = treeList1.DataSource as List<PermissionViewModel>;
                if (permViewModels != null)
                {
                    ReplaceCheckedRows(dc.UserPermissionStatus, userId, permViewModels,
                        vm => vm.PermsStatus,
                        (uid, vm) => new Core.UserPermissionStatus
                        {
                            UserID = uid,
                            PermsID = vm.Id,
                            PermsStatus = true
                        });
                }

                // Projects are handled differently from the other three tabs: every user/project pair
                // always keeps a row in UserProjectAccess (created inactive by InitializeProjectAccessRows /
                // frmProjectAddEdit.OnAfterInsert), so saving here updates each row's PermsStatus in place
                // instead of deleting everything and re-inserting only the checked ones — deleting would
                // erase the "row always exists, defaults inactive" invariant the rest of the app relies on.
                var projectViewModels = treeList2.DataSource as List<AccessViewModel>;
                if (projectViewModels != null)
                {
                    var existingRows = dc.UserProjectAccess.GetBy("UserID = @userId", new { userId })
                        .ToDictionary(a => a.PrjId);

                    foreach (var vm in projectViewModels)
                    {
                        if (existingRows.TryGetValue(vm.Id, out var row))
                        {
                            row.PermsStatus = vm.PermsStatus;
                            row.UpdateDate = DateTime.Now;
                            row.UpdateMachine = Session.Machine;
                            row.UpdateBy = Session.CurrentUser?.Id ?? 1;
                            dc.UserProjectAccess.Edit(row.Id, row);
                        }
                        else
                        {
                            // Shouldn't normally happen since a row is provisioned for every existing
                            // user/project pair, but guard against a missing row instead of silently
                            // dropping the change.
                            dc.UserProjectAccess.Add(new Core.UserProjectAccess
                            {
                                UserID = userId,
                                PrjId = vm.Id,
                                PermsStatus = vm.PermsStatus,
                                UpdateDate = DateTime.Now,
                                UpdateMachine = Session.Machine,
                                UpdateBy = Session.CurrentUser?.Id ?? 1
                            });
                        }
                    }
                }

                var storeViewModels = treeList3.DataSource as List<AccessViewModel>;
                if (storeViewModels != null)
                {
                    // يُحفَظ صف لأي مخزن مُنح فيه أي علم على الأقل (وليس فقط "عرض") — قد يُمنح المستخدم
                    // صلاحية استلام لمخزن دون أن يُمنح "عرض" صراحة، فيُحفَظ الصف بكل الأعلام كما هي.
                    ReplaceCheckedRows(dc.UserStoreAccess, userId, storeViewModels,
                        vm => vm.PermsStatus || vm.CanReceive || vm.CanIssue || vm.CanTransfer,
                        (uid, vm) => new Core.UserStoreAccess
                        {
                            UserID = uid,
                            StoreId = vm.Id,
                            PermsStatus = vm.PermsStatus,
                            CanReceive = vm.CanReceive,
                            CanIssue = vm.CanIssue,
                            CanTransfer = vm.CanTransfer
                        });
                }

                var workflowViewModels = treeList4.DataSource as List<AccessViewModel>;
                if (workflowViewModels != null)
                {
                    ReplaceCheckedRows(dc.UserWorkflowAccess, userId, workflowViewModels,
                        vm => vm.PermsStatus,
                        (uid, vm) => new Core.UserWorkflowAccess
                        {
                            UserID = uid,
                            WorkflowId = vm.Id,
                            PermsStatus = true
                        });
                }

                // Grants just changed on disk — drop PermissionService's cached copy so the next
                // check (including this form's own ApplyUserPermissionsAsync) re-reads them.
                Data.PermissionService.Invalidate();

                XtraMessageBox.Show("تم حفظ البيانات بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في حفظ الصلاحيات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // نمط "احذف كل صفوف المستخدم ثم أَدرِج صفاً جديداً لكل عنصر مُحدَّد" كان مكرَّراً حرفياً ثلاث
        // مرات في SavePermissions أعلاه (الصلاحيات/المخازن/الإجراءات) ولا يختلف بينها سوى نوع الكيان
        // وشرط "متى يُعتبر العنصر محدَّداً" وكيفية بناء الصف منه — فجُمعت هنا في دالة عامة واحدة.
        // UserProjectAccess وحدها مستثناة عمداً (تبقى في SavePermissions): تُحدَّث الصفوف الموجودة في
        // مكانها بدل حذفها وإعادة إدراجها، لأن كل زوج مستخدم/مشروع يجب أن يبقى له صف دائماً (انظر
        // InitializeProjectAccessRows) — مخالف تماماً لنمط "احذف ثم أَدرِج المحدَّد فقط" هنا.
        private static void ReplaceCheckedRows<TViewModel, TEntity>(
            Data.IDataHelper<TEntity> table, int userId, IEnumerable<TViewModel> viewModels,
            Func<TViewModel, bool> isChecked, Func<int, TViewModel, TEntity> makeRow)
        {
            table.DeleteBy("UserID = @userId", new { userId });
            foreach (var vm in viewModels.Where(isChecked))
            {
                table.Add(makeRow(userId, vm));
            }
        }

        private void SaveSignature()
        {
            if (pboxSignature.Tag?.ToString() == "Placeholder") return;
            if (pboxSignature.Image == null) return;

            var user = gridView1.GetFocusedRow() as Core.UsersList;
            if (user == null) return;

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pboxSignature.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    user.Signature = ms.ToArray();
                }
                dc.UsersList.Edit(user.Id, user);
                XtraMessageBox.Show("تم حفظ التوقيع بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReturn_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في حفظ التوقيع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Password & Signature Handlers
        private void btnEditPassword_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                SetDataEntryFieldsVisibility(false);
                // نفرغ الصندوقين ليضطر المستخدم لكتابة كلمة السر الجديدة بدلاً من مقارنتها بالتجزئة القديمة المعروضة
                txtPassword.Text = string.Empty;
                txtRePassword.Text = string.Empty;
                nfData.SelectedPage = npUsersDataEntry;
                nfButton.SelectedPage = navigationPage4;
                btnExpandedCollapse.Visible = false;
                txtPassword.Focus();
            }
        }

        private void btnSign_Click_1(object sender, EventArgs e)
        {
            var user = gridView1.GetFocusedRow() as Core.UsersList;
            if (user != null)
            {
                nfData.SelectedPage = npSign;
                nfButton.SelectedPage = navigationPage4;
                btnExpandedCollapse.Visible = false;
                LoadUserSignature();
            }
        }

        private void LoadUserSignature()
        {
            var user = gridView1.GetFocusedRow() as Core.UsersList;
            if (user != null && user.Signature != null && user.Signature.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(user.Signature))
                {
                    pboxSignature.Image = Image.FromStream(ms);
                    pboxSignature.Tag = "Real";
                }
            }
            else
            {
                SetSignaturePlaceholder();
            }
        }

        private void SetSignaturePlaceholder()
        {
            Bitmap bmp = new Bitmap(pboxSignature.Width > 0 ? pboxSignature.Width : 400, pboxSignature.Height > 0 ? pboxSignature.Height : 200);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bmp.Width, bmp.Height), Color.FromArgb(250, 250, 252), Color.FromArgb(240, 240, 245), 45f))
                {
                    g.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
                }

                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 15;
                    Rectangle rect = new Rectangle(10, 10, bmp.Width - 20, bmp.Height - 20);
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    using (Pen dashedPen = new Pen(Color.FromArgb(200, 200, 205), 1))
                    {
                        dashedPen.DashStyle = DashStyle.Dash;
                        dashedPen.DashPattern = new float[] { 5, 5 };
                        g.DrawPath(dashedPen, path);
                    }
                }

                string text = "اضغط هنا لتحميل التوقيع";
                using (Font font = new Font("Cairo", 14, FontStyle.Regular))
                {
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, new SolidBrush(Color.FromArgb(120, 120, 130)), (bmp.Width - textSize.Width) / 2, (bmp.Height - textSize.Height) / 2);
                }

                float iconSize = 24;
                float iconX = (bmp.Width - iconSize) / 2;
                float iconY = ((bmp.Height - 20) / 2) - 30;
                using (Pen iconPen = new Pen(Color.FromArgb(160, 160, 170), 2))
                {
                    g.DrawLine(iconPen, iconX + iconSize / 2, iconY, iconX + iconSize / 2, iconY + iconSize);
                    g.DrawLine(iconPen, iconX, iconY + iconSize / 2, iconX + iconSize / 2, iconY);
                    g.DrawLine(iconPen, iconX + iconSize, iconY + iconSize / 2, iconX + iconSize / 2, iconY);
                }
            }
            pboxSignature.Image = bmp;
            pboxSignature.Tag = "Placeholder";
        }

        private void pboxSignature_Click(object sender, EventArgs e)
        {
            using (XtraOpenFileDialog ofd = new XtraOpenFileDialog())
            {
                ofd.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";
                ofd.Title = "اختر صورة التوقيع";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Image img = Image.FromFile(ofd.FileName))
                        {
                            pboxSignature.Image = new Bitmap(img);
                            pboxSignature.Tag = "Real";
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("خطأ في تحميل الصورة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeleteSign_Click(object sender, EventArgs e)
        {
            var currentUser = gridView1.GetFocusedRow() as Core.UsersList;
            if (currentUser != null)
            {
                if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف التوقيع؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    currentUser.Signature = null;
                    dc.UsersList.Edit(currentUser.Id, currentUser);
                    SetSignaturePlaceholder();
                }
            }
        }
        #endregion
    }


}