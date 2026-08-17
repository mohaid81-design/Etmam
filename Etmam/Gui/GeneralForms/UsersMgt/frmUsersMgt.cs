using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using Core;
using DevExpress.XtraEditors;
namespace Etmam
{
    public partial class frmUsersMgt : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;

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

        #region Fields
        // Local DataContext DC is defined above
        #endregion

        #region Initialization
        public frmUsersMgt()
        {
            InitializeComponent();
            //DesignSystem.ApplyFormBranding(this);
            DesignSystem.ApplyTreeListStyle(treeList1);
        }

        public void ShowPermissionsPage()
        {
            nfData.SelectedPage = npPermissions;
            nfButton.SelectedPage = navigationPage4;
        }

        private async void frmUsersMgt_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        #endregion

        #region Data Loading & Permissions logic
        private async Task LoadDataAsync()
        {
            await ExecuteAsync(async () => {
                var rowHandle = gridView1.FocusedRowHandle;
                
                // Fetch all users once
                var allUsers = await Task.Run(() => DC.UsersList.GetAll());
                var activeUsers = allUsers.Where(x => !x.IsDelete).ToList();

                this.Invoke(new Action(() => {
                    usersListBindingSource.DataSource = activeUsers;
                    
                    if (rowHandle >= 0)
                        gridView1.FocusedRowHandle = rowHandle;

                    gridControl1.RefreshDataSource();
                    
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

            var userPerms = await Task.Run(() => 
                DC.UserPermissionStatus.GetBy("UserID = @UserID AND PermsStatus = 1", new { UserID = Session.CurrentUser.Id })
                .Select(x => x.PermsID)
                .ToHashSet()
            );

            this.Invoke(new Action(() => {
                bool HasPerm(int id) => Session.CurrentUser.Id == 1 || userPerms.Contains(id);
                btnNewUser.Enabled = HasPerm(2);
                btnEditUser.Enabled = HasPerm(3);
                btnEditPassword.Enabled = HasPerm(4);
                btnUserStatus.Enabled = HasPerm(5);
                btnPermissions.Enabled = HasPerm(6);
            }));
        }

        private async Task LoadPermissionsAsync(int userId)
        {
            // Overlay must be anchored to the form, not treeList1: treeList1 lives on the
            // "Permissions" navigation page, which isn't necessarily the active page yet when this
            // runs (e.g. it's triggered by setting lookUpUser.EditValue during the initial form
            // Load) — ShowOverlayForm throws if its owner control isn't visible.
            var handle = ShowOverlay();
            try
            {
                var data = await Task.Run(() => {
                    var allPerms = DC.PermissionsList.GetAll();
                    var userPermsStatus = DC.UserPermissionStatus.GetBy("UserID = @UserID", new { UserID = userId });
                    var permissionsData = allPerms.Select(p => new PermissionViewModel
                    {
                        Id = p.Id,
                        IdParent = p.ParentID,
                        Description = p.Name,
                        PermsStatus = userPermsStatus.Any(ups => ups.PermsID == p.Id && ups.PermsStatus)
                    }).ToList();

                    var allProjects = DC.ProjectsList.GetBy("IsDelete = 0");
                    var userProjectAccess = DC.UserProjectAccess.GetBy("UserID = @UserID", new { UserID = userId });
                    var projectsData = allProjects.Select(p => new AccessViewModel
                    {
                        Id = p.Id,
                        Name = p.Name ?? string.Empty,
                        PermsStatus = userProjectAccess.Any(a => a.PrjId == p.Id && a.PermsStatus)
                    }).ToList();

                    var allStores = DC.StoreList.GetBy("IsDelete = 0");
                    var userStoreAccess = DC.UserStoreAccess.GetBy("UserID = @UserID", new { UserID = userId });
                    var storesData = allStores.Select(s => new AccessViewModel
                    {
                        Id = s.Id,
                        Name = s.Name ?? string.Empty,
                        PermsStatus = userStoreAccess.Any(a => a.StoreId == s.Id && a.PermsStatus)
                    }).ToList();

                    var allWorkflows = DC.WorkflowDefinitionList.GetBy("IsDelete = 0");
                    var userWorkflowAccess = DC.UserWorkflowAccess.GetBy("UserID = @UserID", new { UserID = userId });
                    var workflowsData = allWorkflows.Select(w => new AccessViewModel
                    {
                        Id = w.Id,
                        Name = w.Name ?? string.Empty,
                        PermsStatus = userWorkflowAccess.Any(a => a.WorkflowId == w.Id && a.PermsStatus)
                    }).ToList();

                    return (permissionsData, projectsData, storesData, workflowsData);
                });

                this.Invoke(new Action(() => {
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
            tree.ExpandAll();
        }
        #endregion

        #region Form Event Handlers
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
            nfData.SelectedPage = npUsersDataEntry;
            nfButton.SelectedPage = navigationPage4;
            txtName.Focus();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                nfData.SelectedPage = npUsersDataEntry;
                nfButton.SelectedPage = navigationPage4;
                txtRePassword.Text = txtPassword.Text; // Pre-fill re-password for editing
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
                    DC.UsersList.Edit(user.Id, user);
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
            DC.UsersList.Edit(user.Id, user);
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
                lookUpUser.EditValue = user.Id;
                await LoadPermissionsAsync(user.Id);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
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
            // Validation
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                XtraMessageBox.Show("يرجى إدخال البيانات الأساسية (الإسم وحساب الدخول)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            usersListBindingSource.EndEdit();
            var user = usersListBindingSource.Current as Core.UsersList;
            if (user == null) return;

            try
            {
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
                    DC.UsersList.Add(user);
                }
                else
                {
                    DC.UsersList.Edit(user.Id, user);
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

        private void SavePermissions()
        {
            if (lookUpUser.EditValue == null || !int.TryParse(lookUpUser.EditValue.ToString(), out int userId)) return;

            try
            {
                // Simple logic for each tab: delete old and insert new based on checked status
                var permViewModels = treeList1.DataSource as List<PermissionViewModel>;
                if (permViewModels != null)
                {
                    DC.UserPermissionStatus.DeleteBy("UserID = @userId", new { userId });
                    foreach (var vm in permViewModels.Where(x => x.PermsStatus))
                    {
                        DC.UserPermissionStatus.Add(new Core.UserPermissionStatus
                        {
                            UserID = userId,
                            PermsID = vm.Id,
                            PermsStatus = true
                        });
                    }
                }

                var projectViewModels = treeList2.DataSource as List<AccessViewModel>;
                if (projectViewModels != null)
                {
                    DC.UserProjectAccess.DeleteBy("UserID = @userId", new { userId });
                    foreach (var vm in projectViewModels.Where(x => x.PermsStatus))
                    {
                        DC.UserProjectAccess.Add(new Core.UserProjectAccess
                        {
                            UserID = userId,
                            PrjId = vm.Id,
                            PermsStatus = true
                        });
                    }
                }

                var storeViewModels = treeList3.DataSource as List<AccessViewModel>;
                if (storeViewModels != null)
                {
                    DC.UserStoreAccess.DeleteBy("UserID = @userId", new { userId });
                    foreach (var vm in storeViewModels.Where(x => x.PermsStatus))
                    {
                        DC.UserStoreAccess.Add(new Core.UserStoreAccess
                        {
                            UserID = userId,
                            StoreId = vm.Id,
                            PermsStatus = true
                        });
                    }
                }

                var workflowViewModels = treeList4.DataSource as List<AccessViewModel>;
                if (workflowViewModels != null)
                {
                    DC.UserWorkflowAccess.DeleteBy("UserID = @userId", new { userId });
                    foreach (var vm in workflowViewModels.Where(x => x.PermsStatus))
                    {
                        DC.UserWorkflowAccess.Add(new Core.UserWorkflowAccess
                        {
                            UserID = userId,
                            WorkflowId = vm.Id,
                            PermsStatus = true
                        });
                    }
                }

                XtraMessageBox.Show("تم حفظ البيانات بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في حفظ الصلاحيات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DC.UsersList.Edit(user.Id, user);
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
                nfData.SelectedPage = npUsersDataEntry;
                nfButton.SelectedPage = navigationPage4;
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
                    DC.UsersList.Edit(currentUser.Id, currentUser);
                    SetSignaturePlaceholder();
                }
            }
        }
        #endregion
    }


}