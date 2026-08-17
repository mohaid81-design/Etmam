using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;
using Etmam.Properties;

namespace Etmam
{
    public partial class frmMainPage : BaseRibbonForm
    {
        #region Fields
        private bool _isSyncing = false;
        #endregion

        #region Constructor & Load
        public frmMainPage()
        {
            InitializeComponent();
            ConfigureNavigation();
            HookEvents();
            InitAccentColors();
            LoadProjects();
            UpdateStatusInfo();

            // Initial view
            navigationAccordion.SelectedElement = aceMain;
            ShowModule(aceMain);
        }

        private void frmMainPage_Load(object sender, EventArgs e)
        {
            UpdateStatusInfo();
        }
        #endregion

        #region Initialization
        private void ConfigureNavigation()
        {
            ribbonControl.Minimized = true;
        }

        private void HookEvents()
        {
            navigationAccordion.ElementClick += navigationAccordion_ElementClick;
        }

        private void LoadProjects()
        {
            try
            {
                var projects = Data.DataContext.Shared.ProjectsList
                    .GetAll()
                    .Where(p => !p.IsDelete)
                    .OrderBy(p => p.Name)
                    .ToList();

                cboProject.Properties.Items.Clear();

                // Placeholder item
                cboProject.Properties.Items.Add(new Core.Tables.ProjectComboItem(null, "--- اختر المشروع ---"));

                foreach (var proj in projects)
                    cboProject.Properties.Items.Add(new Core.Tables.ProjectComboItem(proj.Id, proj.Name ?? $"مشروع {proj.Id}"));

                // Wire the EditValueChanged event
                cboProject.EditValueChanged += CboProject_EditValueChanged;

                // Auto-select if only one project
                if (projects.Count == 1)
                    cboProject.EditValue = cboProject.Properties.Items[1]; // index 1 = first real project
                else
                    cboProject.SelectedIndex = 0; // placeholder
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadProjects error: {ex.Message}");
            }
        }

        private void InitAccentColors()
        {
            SkinHelper.InitTrackWindowsAppMode(bciTrackWindowsAppMode);
            SkinHelper.InitResetToOriginalPalette(bciOriginalPalette);
            SkinHelper.InitTrackWindowsAccentColor(bciTrackWindowsAccentColor);
            SkinHelper.InitCustomAccentColor(Ribbon.Manager, bbiCustomColors);
            SkinHelper.InitCustomAccentColor2(Ribbon.Manager, bbiCustomColors2);

            bciTrackWindowsAppMode.SuperTip = CreateSuperTip("This setting is available for WXI, Basic, and Bezier skins.");
            bbiCustomColors.SuperTip = CreateSuperTip("Custom Accent Color.");
            bbiCustomColors2.SuperTip = CreateSuperTip("Custom Accent Color 2.");
        }

        private SuperToolTip CreateSuperTip(string text)
        {
            var tip = new SuperToolTip();
            tip.Items.Add(text);
            tip.Items[0].Appearance.FontStyleDelta = FontStyle.Bold;
            return tip;
        }
        #endregion

        #region Navigation Logic
        private void ShowModule(AccordionControlElement element)
        {
            if (_isSyncing || element == null || element.Style != ElementStyle.Item) return;

            // Show Overlay Form on the main navigation frame for a modern look
            // We check if navigationFrame is visible to avoid InvalidOperationException during startup
            IOverlaySplashScreenHandle handle = null;
            if (navigationFrame.Visible)
                handle = SplashScreenManager.ShowOverlayForm(navigationFrame);

            _isSyncing = true;
            try
            {
                // Find existing page
                var page = navigationFrame.Pages.OfType<NavigationPage>().FirstOrDefault(p => p.Tag == element);
                if (page != null)
                {
                    navigationFrame.SelectedPage = page;
                    return;
                }

                Control userControl = GetControlForElement(element);
                if (userControl == null) return;

                // Create new page
                var newPage = new NavigationPage
                {
                    Tag = element,
                    Text = element.Text
                };
                userControl.Dock = DockStyle.Fill;
                newPage.Controls.Add(userControl);

                navigationFrame.Pages.Add(newPage);
                navigationFrame.SelectedPage = newPage;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء فتح الوحدة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isSyncing = false;
                // Close Overlay Form
                if (handle != null)
                    SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        private Control GetControlForElement(AccordionControlElement element)
        {
            if (element == aceMain) return CreateDashboardControl();
            if (element == aceDocumentsMgt) return new ucDocumentsMgt();
            if (element == acePurchaseMgt) return new ucProcurementMgt();
            if (element == aceInventoryMgt) return new ucInventoryMgt();
            if (element == aceWorkflowMgt) return new ucWorkflowMgt();

            return CreatePlaceholderControl(element.Text);
        }
        #endregion

        #region Event Handlers
        private void navigationAccordion_ElementClick(object sender, ElementClickEventArgs e)
        {
            ShowModule(e.Element);
        }

        private void XtraFormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogLogout();

            foreach (var page in navigationFrame.Pages.OfType<NavigationPage>())
            {
                foreach (Control ctrl in page.Controls)
                {
                    if (ctrl is XtraUserControl userControl)
                    {
                        var confirmMethod = userControl.GetType().GetMethod("ConfirmClose");
                        if (confirmMethod != null)
                        {
                            bool canClose = (bool)(confirmMethod.Invoke(userControl, null) ?? true);
                            if (!canClose)
                            {
                                e.Cancel = true;
                                navigationFrame.SelectedPage = page;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void CboProject_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProject.EditValue is Core.Tables.ProjectComboItem item)
            {
                Core.Session.SelectedProjectId = item.Id;
                Core.Session.SelectedProjectName = item.Id.HasValue ? item.DisplayName : null;
                UpdateStatusInfo();

                // Reload all open navigation pages that support project-aware refresh
                foreach (var page in navigationFrame.Pages.OfType<DevExpress.XtraBars.Navigation.NavigationPage>())
                {
                    foreach (Control ctrl in page.Controls)
                    {
                        var refreshMethod = ctrl.GetType().GetMethod("OnProjectChanged",
                            System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.Public |
                            System.Reflection.BindingFlags.NonPublic);
                        refreshMethod?.Invoke(ctrl, null);
                    }
                }
            }
        }

        private void bbiUsersMgt_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmUsersMgt())
            {
                frm.ShowDialog();
            }
        }

        private void bbiPermissionsMgt_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmUsersMgt())
            {
                frm.ShowPermissionsPage();
                frm.ShowDialog();
            }
        }

        private void bbiLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("هل أنت متأكد من تسجيل الخروج؟", "تأكيد تسجيل الخروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void bbiConnection_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmConnecting())
            {
                frm.ShowDialog();
            }
        }

        private void bbiBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmBackup())
            {
                frm.ShowDialog();
            }
        }

        private void bbiRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmRestore())
            {
                frm.ShowDialog();
            }
        }
        #endregion

        #region UI Helpers
        private void UpdateStatusInfo()
        {
            if (Core.Session.CurrentUser.Id > 0)
            {
                bsiUser.Caption = $"المستخدم: {Core.Session.CurrentUser.FullName}";
                bsiCompany.Caption = $"الشركة: {Core.Session.CurrentUser.Company}";
                bsiServer.Caption = $"الجهاز: {Core.Session.Machine}";
            }
        }

        private void LogLogout()
        {
            if (Core.Session.CurrentUser.Id > 0)
            {
                try
                {
                    DC.ActionLogs.Add(new Core.ActionLogs
                    {
                        UserID = Core.Session.CurrentUser.Id,
                        UserName = Core.Session.CurrentUser.UserName ?? string.Empty,
                        ActionType = "خروج",
                        ActionLocation = "الرئيسية",
                        ActionDate = DateTime.Now,
                        MachineName = Core.Session.Machine
                    });
                }
                catch { }
            }
        }

        private Control CreateDashboardControl()
        {
            var container = new XtraUserControl { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke };
            var label = new LabelControl
            {
                Text = "مرحباً بك في نظام إتمام لإدارة المشاريع",
                Dock = DockStyle.Fill,
                AutoSizeMode = LabelAutoSizeMode.None,
                Appearance = {
                    TextOptions = { HAlignment = HorzAlignment.Center, VAlignment = VertAlignment.Center },
                    Font = new Font("Cairo", 14, FontStyle.Bold)
                }
            };
            container.Controls.Add(label);
            return container;
        }

        private XtraUserControl CreatePlaceholderControl(string text)
        {
            var container = new XtraUserControl { Dock = DockStyle.Fill, Text = text };
            var label = new LabelControl
            {
                Text = $"برنامج {text} قيد التطوير حالياً",
                Dock = DockStyle.Fill,
                AutoSizeMode = LabelAutoSizeMode.None,
                Appearance = {
                    TextOptions = { HAlignment = HorzAlignment.Center, VAlignment = VertAlignment.Center },
                    Font = new Font("Cairo", 12)
                }
            };
            container.Controls.Add(label);
            return container;
        }
        #endregion

        private void bbiPermissionsMgt_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmPermissionsAddEdit frm = new frmPermissionsAddEdit();
            frm.ShowDialog();
        }
    }
}
