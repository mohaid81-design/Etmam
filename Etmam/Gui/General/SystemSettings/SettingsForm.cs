using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Data;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    // ════════════════════════════════════════════════════════════════════
    //  SettingsForm — شاشة الإعدادات
    //  تنقل متعدد الأقسام عبر AccordionControl، لكن كل قسم يعرض فقط ما هو
    //  مطبَّق فعلياً في البرنامج. الأقسام بلا دعم حقيقي تعرض "قيد التطوير"
    //  بدلاً من عناصر تحكم لا تُحفظ أو لا تُقرأ من أي مكان.
    // ════════════════════════════════════════════════════════════════════
    public class SettingsForm : XtraForm
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private string _currentSection = "Approvals";

        // ── Left Panel ───────────────────────────────────────────────
        private Panel pnlLeft = null!;
        private AccordionControl accordionNav = null!;
        private TextEdit txtNavSearch = null!;

        // ── Right Panel ──────────────────────────────────────────────
        private Panel pnlRight = null!;
        private LabelControl lblSectionTitle = null!;
        private Panel pnlContent = null!;

        public SettingsForm()
        {
            BuildUI();
            LoadSection("Approvals");
        }

        // ════════════════════════════════════════════════════════════════
        //  BUILD UI
        // ════════════════════════════════════════════════════════════════
        private void BuildUI()
        {
            Text = "الإعدادات — Etmam";
            Size = new Size(980, 680);
            MinimumSize = new Size(820, 560);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = DesignSystem.Colors.BgSecondary;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;

            BuildRightContent();
            BuildLeftNav();
        }

        // ════════════════════════════════════════════════════════════════
        //  LEFT NAV
        // ════════════════════════════════════════════════════════════════
        private void BuildLeftNav()
        {
            pnlLeft = new Panel { Dock = DockStyle.Right, Width = 230, BackColor = Color.White };
            pnlLeft.Paint += DesignSystem.DrawTopBorder;

            var header = new Panel { Dock = DockStyle.Top, Height = 44, BackColor = Color.White, Padding = new Padding(14, 12, 14, 0) };
            header.Paint += DesignSystem.DrawBottomBorder;
            header.Controls.Add(new LabelControl
            {
                Text = "الإعدادات",
                Font = DesignSystem.Fonts.Bold(12),
                ForeColor = DesignSystem.Colors.TextPrimary,
                Dock = DockStyle.Top,
                AutoSizeMode = LabelAutoSizeMode.None,
                Height = 26,
            });

            var pnlNavSearch = new Panel { Dock = DockStyle.Top, Height = 44, BackColor = Color.White, Padding = new Padding(10, 7, 10, 7) };
            pnlNavSearch.Paint += DesignSystem.DrawBottomBorder;

            txtNavSearch = new TextEdit { Dock = DockStyle.Fill };
            txtNavSearch.Properties.NullValuePrompt = "بحث في الإعدادات...";
            txtNavSearch.Properties.NullValuePromptShowForEmptyValue = true;
            txtNavSearch.EditValueChanged += (s, e) => FilterNavItems(txtNavSearch.Text ?? "");
            pnlNavSearch.Controls.Add(txtNavSearch);

            accordionNav = new AccordionControl { Dock = DockStyle.Fill, BackColor = Color.White };

            AddNavGroup("الموافقات والنسخ الاحتياطي", new[]
            {
                ("Approvals", "✅", "الموافقات وفصل المهام"),
                ("Backup",    "💾", "النسخ الاحتياطي"),
            });

            AddNavGroup("عام", new[]
            {
                ("Appearance",    "🎨", "المظهر والواجهة"),
                ("Language",      "🌐", "اللغة والمنطقة"),
                ("Notifications", "🔔", "الإشعارات"),
                ("Session",       "⏱", "الجلسة والتوقيت"),
            });

            AddNavGroup("إدارة النظام", new[]
            {
                ("Users",     "👥", "المستخدمون والأدوار"),
                ("Companies", "🏢", "الشركات والمشاريع"),
                ("Workflow",  "🔀", "سير العمل الافتراضي"),
                ("Numbering", "#", "تسلسل الترقيم"),
                ("Templates", "📄", "النماذج والقوالب"),
            });

            AddNavGroup("التقنية", new[]
            {
                ("Storage",    "📁", "مسارات التخزين"),
                ("Smtp",       "📧", "إعدادات البريد (SMTP)"),
                ("Database",   "🗄", "قاعدة البيانات"),
                ("Ocr",        "🔍", "محرك OCR"),
                ("Security",   "🔒", "الأمان والصلاحيات"),
                ("AuditTrail", "📋", "سجل التدقيق"),
            });

            AddNavGroup("متقدم", new[]
            {
                ("Performance", "📊", "الأداء والذاكرة"),
                ("Updates",     "🔄", "تحديث البرنامج"),
                ("About",       "ℹ", "حول البرنامج"),
            });

            pnlLeft.Controls.AddRange(new Control[] { accordionNav, pnlNavSearch, header });
            Controls.Add(pnlLeft);
        }

        private void AddNavGroup(string groupTitle, (string key, string icon, string label)[] items)
        {
            var grp = new AccordionControlElement { Style = ElementStyle.Group, Text = groupTitle, Expanded = true };

            foreach (var (key, icon, label) in items)
            {
                var item = new AccordionControlElement
                {
                    Style = ElementStyle.Item,
                    Text = $"{icon}  {label}",
                    Tag = key,
                    Name = $"nav_{key}",
                };
                item.Click += (s, e) => LoadSection(key);
                grp.Elements.Add(item);
            }

            accordionNav.Elements.Add(grp);
        }

        private void FilterNavItems(string q)
        {
            foreach (AccordionControlElement grp in accordionNav.Elements)
            {
                bool anyVisible = false;
                foreach (AccordionControlElement item in grp.Elements)
                {
                    bool match = string.IsNullOrEmpty(q) || item.Text.Contains(q, StringComparison.OrdinalIgnoreCase);
                    item.Visible = match;
                    if (match) anyVisible = true;
                }
                grp.Visible = anyVisible || string.IsNullOrEmpty(q);
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  RIGHT CONTENT
        // ════════════════════════════════════════════════════════════════
        private void BuildRightContent()
        {
            pnlRight = new Panel { Dock = DockStyle.Fill, BackColor = DesignSystem.Colors.BgSecondary };

            var pnlTopBar = new Panel { Dock = DockStyle.Top, Height = 48, BackColor = Color.White, Padding = new Padding(16, 0, 16, 0) };
            pnlTopBar.Paint += DesignSystem.DrawBottomBorder;

            lblSectionTitle = new LabelControl
            {
                Text = "الموافقات وفصل المهام",
                Font = DesignSystem.Fonts.Bold(12),
                ForeColor = DesignSystem.Colors.TextPrimary,
                Dock = DockStyle.Fill,
                AutoSizeMode = LabelAutoSizeMode.None,
            };
            lblSectionTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            pnlTopBar.Controls.Add(lblSectionTitle);

            pnlContent = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = DesignSystem.Colors.BgSecondary, Padding = new Padding(16) };

            pnlRight.Controls.AddRange(new Control[] { pnlContent, pnlTopBar });
            Controls.Add(pnlRight);
        }

        // ════════════════════════════════════════════════════════════════
        //  SECTION LOADER
        // ════════════════════════════════════════════════════════════════
        private void LoadSection(string section)
        {
            _currentSection = section;

            foreach (Control c in pnlContent.Controls.Cast<Control>().ToList())
            {
                pnlContent.Controls.Remove(c);
                c.Dispose();
            }

            lblSectionTitle.Text = GetSectionTitle(section);

            Control sectionPanel = section switch
            {
                "Approvals" => BuildApprovalsPanel(),
                "Backup" => BuildBackupPanel(),
                "Notifications" => BuildNotificationsPanel(),
                "Smtp" => BuildSmtpPanel(),
                "Storage" => BuildStoragePanel(),
                "Database" => BuildDatabasePanel(),
                "Updates" => BuildUpdatesPanel(),
                "About" => BuildAboutPanel(),
                _ => BuildComingSoonPanel(GetSectionTitle(section)),
            };

            sectionPanel.Dock = DockStyle.Top;
            pnlContent.Controls.Add(sectionPanel);
        }

        private static string GetSectionTitle(string key) => key switch
        {
            "Approvals" => "الموافقات وفصل المهام",
            "Backup" => "النسخ الاحتياطي",
            "Appearance" => "المظهر والواجهة",
            "Language" => "اللغة والمنطقة",
            "Notifications" => "الإشعارات",
            "Session" => "الجلسة والتوقيت",
            "Users" => "المستخدمون والأدوار",
            "Companies" => "الشركات والمشاريع",
            "Workflow" => "سير العمل الافتراضي",
            "Numbering" => "تسلسل الترقيم",
            "Templates" => "النماذج والقوالب",
            "Storage" => "مسارات التخزين",
            "Smtp" => "إعدادات البريد (SMTP)",
            "Database" => "قاعدة البيانات",
            "Ocr" => "محرك OCR",
            "Security" => "الأمان والصلاحيات",
            "AuditTrail" => "سجل التدقيق",
            "Performance" => "الأداء والذاكرة",
            "Updates" => "تحديث البرنامج",
            "About" => "حول البرنامج",
            _ => key,
        };

        // ════════════════════════════════════════════════════════════════
        //  SECTION: APPROVALS (real — separation of duties + PR export path)
        // ════════════════════════════════════════════════════════════════
        private Control BuildApprovalsPanel()
        {
            bool canManage = SystemSettingsPermissions.CanManage(dc);

            // Fresh controls on every load — LoadSection disposes the previous section's
            // whole control tree when navigating away, so reusing form-level fields across
            // reloads means re-adding an already-disposed control on the next visit.
            var checkEditSeparationOfDuties = new CheckEdit
            {
                Text = "منع اعتماد/رفض المستخدم لطلب أو أمر شراء أنشأه بنفسه (فصل المهام)",
                Enabled = canManage,
                Checked = SeparationOfDutiesHelper.IsEnabled(dc),
                Location = new Point(0, 32),
                Size = new Size(520, 24),
            };

            var txtPurchaseRequestExportPath = new TextEdit
            {
                Enabled = canManage,
                Text = PurchaseRequestExportSettings.GetFolderPath(dc) ?? "",
                Location = new Point(96, 148),
                Size = new Size(334, 24),
            };
            txtPurchaseRequestExportPath.Properties.ReadOnly = true;

            var btnBrowseExportPath = new SimpleButton
            {
                Text = "استعراض...",
                Width = 90,
                Height = 26,
                Enabled = canManage,
                Location = new Point(0, 148),
            };
            DesignSystem.StyleOutlineButton(btnBrowseExportPath);
            btnBrowseExportPath.Click += (s, e) =>
            {
                using var dlg = new XtraFolderBrowserDialog { SelectedPath = txtPurchaseRequestExportPath.Text };
                if (dlg.ShowDialog() != DialogResult.OK) return;

                if (IsWebUrl(dlg.SelectedPath))
                {
                    XtraMessageBox.Show(
                        "المسار المختار رابط ويب (مثل رابط مشاركة SharePoint) وليس مجلداً فعلياً على الجهاز أو الشبكة، " +
                        "فلا يمكن حفظ الملفات فيه مباشرة.\nإن كان هذا مجلد SharePoint/OneDrive مُزامَناً على جهازك، اختر " +
                        "نسخته المحلية بدلاً من ذلك (عادةً تحت مجلد المستخدم)، أو اختر مساراً شبكياً (UNC) مثل \\\\server\\share.",
                        "مسار غير صالح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtPurchaseRequestExportPath.Text = dlg.SelectedPath;
            };

            var btnClearExportPath = new SimpleButton
            {
                Text = "مسح",
                Width = 84,
                Height = 26,
                Enabled = canManage,
                Location = new Point(436, 148),
            };
            DesignSystem.StyleOutlineButton(btnClearExportPath);
            btnClearExportPath.Click += (s, e) => txtPurchaseRequestExportPath.Text = "";

            var chkSharePointEnabled = new CheckEdit
            {
                Text = "تفعيل الرفع التلقائي إلى SharePoint Online",
                Enabled = canManage,
                Checked = SharePointExportSettings.IsEnabled(dc),
                Location = new Point(0, 264),
                Size = new Size(520, 24),
            };

            var lblTenantId = MakeLabel("Tenant ID:");
            lblTenantId.Location = new Point(300, 296);
            var txtTenantId = new TextEdit
            {
                Enabled = canManage,
                Text = SharePointExportSettings.GetTenantId(dc) ?? "",
                Location = new Point(0, 296),
                Size = new Size(290, 24),
            };

            var lblClientId = MakeLabel("Client ID:");
            lblClientId.Location = new Point(300, 326);
            var txtClientId = new TextEdit
            {
                Enabled = canManage,
                Text = SharePointExportSettings.GetClientId(dc) ?? "",
                Location = new Point(0, 326),
                Size = new Size(290, 24),
            };

            var lblClientSecret = MakeLabel("Client Secret:");
            lblClientSecret.Location = new Point(300, 356);
            var txtClientSecret = new TextEdit
            {
                Enabled = canManage,
                Text = SharePointExportSettings.GetClientSecret(dc) ?? "",
                Location = new Point(0, 356),
                Size = new Size(290, 24),
            };
            txtClientSecret.Properties.PasswordChar = '●';

            var lblSiteUrl = MakeLabel("رابط الموقع (Site URL):");
            lblSiteUrl.Location = new Point(300, 386);
            var txtSiteUrl = new TextEdit
            {
                Enabled = canManage,
                Text = SharePointExportSettings.GetSiteUrl(dc) ?? "",
                Location = new Point(0, 386),
                Size = new Size(290, 24),
            };
            txtSiteUrl.Properties.NullValuePrompt = "https://contoso.sharepoint.com/sites/Procurement";
            txtSiteUrl.Properties.NullValuePromptShowForEmptyValue = true;

            var lblSharePointFolder = MakeLabel("المجلد داخل الموقع (اختياري):");
            lblSharePointFolder.Location = new Point(300, 416);
            var txtSharePointFolder = new TextEdit
            {
                Enabled = canManage,
                Text = SharePointExportSettings.GetFolderPath(dc) ?? "",
                Location = new Point(0, 416),
                Size = new Size(290, 24),
            };

            var btnTestSharePoint = new SimpleButton
            {
                Text = "اختبار الاتصال", Width = 140, Height = 26, Enabled = canManage,
                Location = new Point(0, 448),
            };
            DesignSystem.StyleOutlineButton(btnTestSharePoint);
            btnTestSharePoint.Click += (s, e) =>
            {
                // يختبر الإعدادات المحفوظة فعلياً في قاعدة البيانات (نفس منهجية زر "اختبار الإرسال" في
                // قسم واتساب) — احفظ التغييرات أولاً بزر "حفظ" أدناه قبل الاختبار.
                var handle = ShowOverlay();
                bool ok;
                string? testError;
                try { ok = SharePointUploader.TestConnection(dc, out testError); }
                finally { CloseOverlay(handle); }

                XtraMessageBox.Show(
                    ok ? "تم الاتصال بموقع SharePoint بنجاح ✓" : $"فشل الاتصال:\n{testError}",
                    "اختبار الاتصال", MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            };

            var lblSharePointHint = new LabelControl
            {
                Text = "عند التفعيل: يُرفَع تلقائياً عند اعتماد أي طلب شراء نهائياً ملف PDF بنسخة الطلب المعتمد\nمع كافة مرفقاته، إلى المكتبة أعلاه — بديل/إضافة لمجلد الحفظ المحلي، ويعمل من أي جهاز\nمستخدم بنفس النتيجة. يتطلب تسجيل تطبيق (App Registration) في Azure AD بصلاحية\nGraph API التطبيقية Sites.ReadWrite.All مع موافقة المدير (Admin Consent). احفظ ثم اختبر.",
                Location = new Point(0, 480),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 62),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var btnSaveApprovals = new SimpleButton
            {
                Text = "حفظ",
                Width = 100,
                Height = 30,
                Enabled = canManage,
                Location = new Point(0, 552),
            };
            DesignSystem.StylePrimaryButton(btnSaveApprovals);
            btnSaveApprovals.Click += (s, e) =>
            {
                if (IsWebUrl(txtPurchaseRequestExportPath.Text))
                {
                    XtraMessageBox.Show(
                        "المسار المحدَّد لحفظ نسخ طلبات الشراء المعتمدة رابط ويب وليس مجلداً فعلياً — " +
                        "استخدم زر \"استعراض...\" لاختيار مجلد محلي/شبكي حقيقي، أو \"مسح\" لتعطيل الحفظ التلقائي.",
                        "مسار غير صالح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var handle = ShowOverlay();
                try
                {
                    SystemSettingsHelper.SetBool(
                        dc, SeparationOfDutiesHelper.SettingKey, checkEditSeparationOfDuties.Checked,
                        "منع اعتماد/رفض المستخدم لمستند (طلب/أمر شراء) أنشأه بنفسه");

                    SystemSettingsHelper.SetString(
                        dc, PurchaseRequestExportSettings.SettingKey,
                        string.IsNullOrWhiteSpace(txtPurchaseRequestExportPath.Text) ? null : txtPurchaseRequestExportPath.Text,
                        "مسار حفظ نسخة PDF + مرفقات طلبات الشراء المعتمدة تلقائياً");

                    SystemSettingsHelper.SetBool(
                        dc, SharePointExportSettings.EnabledKey, chkSharePointEnabled.Checked,
                        "تفعيل رفع نسخة طلبات الشراء المعتمدة إلى SharePoint Online");
                    SystemSettingsHelper.SetString(
                        dc, SharePointExportSettings.TenantIdKey,
                        string.IsNullOrWhiteSpace(txtTenantId.Text) ? null : txtTenantId.Text,
                        "SharePoint Export — Azure AD Tenant ID");
                    SystemSettingsHelper.SetString(
                        dc, SharePointExportSettings.ClientIdKey,
                        string.IsNullOrWhiteSpace(txtClientId.Text) ? null : txtClientId.Text,
                        "SharePoint Export — Azure AD App Client ID");
                    SystemSettingsHelper.SetString(
                        dc, SharePointExportSettings.ClientSecretKey,
                        string.IsNullOrWhiteSpace(txtClientSecret.Text) ? null : txtClientSecret.Text,
                        "SharePoint Export — Azure AD App Client Secret");
                    SystemSettingsHelper.SetString(
                        dc, SharePointExportSettings.SiteUrlKey,
                        string.IsNullOrWhiteSpace(txtSiteUrl.Text) ? null : txtSiteUrl.Text,
                        "SharePoint Export — رابط الموقع");
                    SystemSettingsHelper.SetString(
                        dc, SharePointExportSettings.FolderPathKey,
                        string.IsNullOrWhiteSpace(txtSharePointFolder.Text) ? null : txtSharePointFolder.Text,
                        "SharePoint Export — المجلد داخل الموقع");

                    XtraMessageBox.Show("تم حفظ الإعدادات بنجاح ✓", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            };

            var content = new Panel { Height = 600, BackColor = Color.White };

            var lblSection = MakeLabel("فصل المهام في الاعتماد (Separation of Duties):", bold: true);
            lblSection.Location = new Point(0, 4);

            var lblHint = new LabelControl
            {
                Text = "عند التفعيل: لا يستطيع أي مستخدم (باستثناء المدير) اعتماد أو رفض طلب/أمر شراء\nأنشأه هو نفسه، حتى لو كان يملك صلاحية الاعتماد. مُعطَّل افتراضياً.",
                Location = new Point(0, 62),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 44),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var lblExportSection = MakeLabel("حفظ نسخة طلبات الشراء المعتمدة تلقائياً:", bold: true);
            lblExportSection.Location = new Point(0, 118);

            var lblExportHint = new LabelControl
            {
                Text = "عند تحديد مسار: يُحفَظ تلقائياً عند اعتماد أي طلب شراء نهائياً ملف PDF بنسخة\nالطلب المعتمد مع كافة مرفقاته، في مجلد فرعي باسم رقم الطلب. اتركه فارغاً للتعطيل.",
                Location = new Point(0, 178),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 44),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var lblSharePointSection = MakeLabel(
                "رفع نسخة طلبات الشراء المعتمدة إلى SharePoint Online (مشترك بين عدة مستخدمين):", bold: true);
            lblSharePointSection.Location = new Point(0, 234);

            content.Controls.AddRange(new Control[]
            {
                lblSection, checkEditSeparationOfDuties, lblHint,
                lblExportSection, txtPurchaseRequestExportPath, btnBrowseExportPath, btnClearExportPath, lblExportHint,
                lblSharePointSection, chkSharePointEnabled,
                txtTenantId, lblTenantId, txtClientId, lblClientId, txtClientSecret, lblClientSecret,
                txtSiteUrl, lblSiteUrl, txtSharePointFolder, lblSharePointFolder,
                btnTestSharePoint, lblSharePointHint,
                btnSaveApprovals,
            });

            return BuildCard("✅  الموافقات وفصل المهام", "قواعد اعتماد المستندات وحفظ نسخ منها تلقائياً", content, 600);
        }

        /// <summary>True if path looks like a web URL (http/https) rather than a real filesystem path —
        /// guards PurchaseRequestExportSettings against a SharePoint/OneDrive sharing link being picked
        /// via XtraFolderBrowserDialog's shell-namespace navigation (a synced library shortcut in the
        /// dialog's sidebar can resolve to its raw https:// URL instead of the local sync-client folder),
        /// which then fails downstream in PurchaseRequestPrinter.ExportApprovedCopy with an OS "invalid
        /// path syntax" error at the moment a PR is approved — too late to be a good first warning.</summary>
        private static bool IsWebUrl(string? path) =>
            !string.IsNullOrWhiteSpace(path) &&
            (path.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
             path.StartsWith("https://", StringComparison.OrdinalIgnoreCase));

        // ════════════════════════════════════════════════════════════════
        //  SECTION: BACKUP (real — shortcuts to the existing backup/restore forms)
        // ════════════════════════════════════════════════════════════════
        private Control BuildBackupPanel()
        {
            bool canBackup = PermissionService.HasPermission(dc, PermNames.Backup);
            bool canRestore = PermissionService.HasPermission(dc, PermNames.Restore);

            var content = new Panel { Height = 130, BackColor = Color.White };

            var lblInfo = new LabelControl
            {
                Text = "إنشاء نسخة احتياطية من قاعدة البيانات أو استعادة نسخة سابقة. العملية يدوية —\nلا توجد جدولة تلقائية حالياً.",
                Location = new Point(0, 4),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 40),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var btnRunBackup = new SimpleButton { Text = "💾  إنشاء نسخة احتياطية الآن", Width = 220, Height = 34, Location = new Point(300, 56), Enabled = canBackup };
            DesignSystem.StylePrimaryButton(btnRunBackup);
            btnRunBackup.Click += (s, e) => { using var frm = new frmBackup(); frm.ShowDialog(); };

            var btnRunRestore = new SimpleButton { Text = "♻  استعادة نسخة احتياطية", Width = 220, Height = 34, Location = new Point(60, 56), Enabled = canRestore };
            DesignSystem.StyleOutlineButton(btnRunRestore);
            btnRunRestore.Click += (s, e) => { using var frm = new frmRestore(); frm.ShowDialog(); };

            content.Controls.AddRange(new Control[] { lblInfo, btnRunBackup, btnRunRestore });

            return BuildCard("💾  النسخ الاحتياطي", "نسخ واستعادة قاعدة البيانات يدوياً", content, 130);
        }

        // ════════════════════════════════════════════════════════════════
        //  SECTION: NOTIFICATIONS (real — WhatsApp via Green API)
        // ════════════════════════════════════════════════════════════════
        private Control BuildNotificationsPanel()
        {
            bool canManage = SystemSettingsPermissions.CanManage(dc);

            var chkEnabled = new CheckEdit
            {
                Text = "تفعيل إشعارات واتساب عند اعتماد/رفض خطوات سير العمل",
                Enabled = canManage,
                Checked = WhatsAppSettings.IsEnabled(dc),
                Location = new Point(0, 4),
                Size = new Size(520, 24),
            };

            var lblInstanceName = MakeLabel("اسم الجهاز (Instance Name):");
            lblInstanceName.Location = new Point(300, 40);

            var txtInstanceName = new TextEdit
            {
                Enabled = canManage,
                Text = WhatsAppSettings.GetInstanceName(dc) ?? "",
                Location = new Point(0, 40),
                Size = new Size(290, 24),
            };

            var lblApiUrl = MakeLabel("API URL (من لوحة تحكم Green API):");
            lblApiUrl.Location = new Point(300, 76);

            var txtApiUrl = new TextEdit
            {
                Enabled = canManage,
                Text = WhatsAppSettings.GetApiUrl(dc) ?? "",
                Location = new Point(0, 76),
                Size = new Size(290, 24),
            };
            txtApiUrl.Properties.NullValuePrompt = "https://XXXXXXXXXX.api.greenapi.com";
            txtApiUrl.Properties.NullValuePromptShowForEmptyValue = true;

            var lblMediaUrl = MakeLabel("Media URL (لإرسال الملفات مستقبلاً):");
            lblMediaUrl.Location = new Point(300, 112);

            var txtMediaUrl = new TextEdit
            {
                Enabled = canManage,
                Text = WhatsAppSettings.GetMediaUrl(dc) ?? "",
                Location = new Point(0, 112),
                Size = new Size(290, 24),
            };
            txtMediaUrl.Properties.NullValuePrompt = "https://XXXXXXXXXX.media.greenapi.com";
            txtMediaUrl.Properties.NullValuePromptShowForEmptyValue = true;

            var lblIdInstance = MakeLabel("Instance ID (Green API):");
            lblIdInstance.Location = new Point(300, 148);

            var txtIdInstance = new TextEdit
            {
                Enabled = canManage,
                Text = WhatsAppSettings.GetIdInstance(dc) ?? "",
                Location = new Point(0, 148),
                Size = new Size(290, 24),
            };

            var lblApiToken = MakeLabel("API Token (Green API):");
            lblApiToken.Location = new Point(300, 184);

            var txtApiToken = new TextEdit
            {
                Enabled = canManage,
                Text = WhatsAppSettings.GetApiToken(dc) ?? "",
                Location = new Point(0, 184),
                Size = new Size(290, 24),
            };
            txtApiToken.Properties.PasswordChar = '●';

            var lblTest = MakeLabel("رقم هاتف للاختبار:");
            lblTest.Location = new Point(300, 220);

            var txtTestNumber = new TextEdit
            {
                Enabled = canManage,
                Location = new Point(150, 220),
                Size = new Size(140, 24),
            };

            var btnTestSend = new SimpleButton
            {
                Text = "اختبار الإرسال", Width = 130, Height = 26, Enabled = canManage,
                Location = new Point(0, 220),
            };
            DesignSystem.StyleOutlineButton(btnTestSend);
            btnTestSend.Click += (s, e) =>
            {
                var handle = ShowOverlay();
                bool ok;
                string? sendError;
                string? state;
                try
                {
                    ok = WhatsAppNotifier.TrySend(txtTestNumber.Text,
                        "رسالة اختبار من نظام Etmam — إذا وصلتك هذه الرسالة فإعدادات واتساب صحيحة.",
                        out sendError);

                    // A "successful" send only means Green API accepted and queued the message — it does NOT
                    // mean it was delivered. Messages queue silently for up to 24h until the instance is
                    // actually linked to a phone (state = authorized), so check that too and say so plainly.
                    state = ok ? WhatsAppNotifier.GetInstanceState(out _) : null;
                }
                finally
                {
                    CloseOverlay(handle);
                }

                if (!ok)
                {
                    XtraMessageBox.Show($"فشل الإرسال:\n{sendError}", "اختبار الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (state == "authorized")
                {
                    XtraMessageBox.Show("تم إرسال رسالة الاختبار بنجاح ✓", "اختبار الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string stateDesc = DescribeInstanceState(state);
                    XtraMessageBox.Show(
                        $"تم قبول الطلب من Green API، لكن الرسالة لن تصل فعلياً لأن الجهاز غير مرتبط بعد.\n\n" +
                        $"حالة الجهاز: {stateDesc}\n\n" +
                        "الحل: افتح لوحة تحكم Green API وامسح رمز QR بواتساب على الهاتف المطلوب ربطه بهذا الحساب. " +
                        "الرسالة محفوظة في قائمة الانتظار وستصل تلقائياً خلال 24 ساعة بعد الربط.",
                        "اختبار الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            var lblHint = new LabelControl
            {
                Text = "عند التفعيل: يُرسَل تنبيه واتساب لصاحب الخطوة عند اعتماده/رفضه، ولصاحب الخطوة\nالتالية عند وصول الدور إليه. الأرقام تُقرأ من حقل الهاتف في إدارة المستخدمين.\nAPI URL و Instance ID و API Token تُنسَخ من لوحة تحكم حسابك في Green API.",
                Location = new Point(0, 254),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 50),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            // Diagnostic only — recent real (workflow-triggered) send attempts. Real sends are
            // fire-and-forget and never show anything to the approving user, and a single Act() can fire
            // several at once (one confirmation + one per next-step assignee) — so this keeps a short log
            // rather than one slot, otherwise a later-finishing success can hide an earlier failure to a
            // different number (see WhatsAppSettings.AppendAttempt).
            var lblLastAttemptCaption = new LabelControl
            {
                Text = "آخر محاولات الإرسال الحقيقية (تشخيصي):",
                Location = new Point(0, 308),
                AutoSize = true,
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var memoLastAttempt = new MemoEdit
            {
                Text = WhatsAppSettings.GetLastAttempt(dc) ?? "لا يوجد سجل بعد",
                Location = new Point(0, 328),
                Size = new Size(520, 100),
                Properties = { ReadOnly = true },
            };

            var btnSave = new SimpleButton { Text = "حفظ", Width = 100, Height = 30, Enabled = canManage, Location = new Point(0, 438) };
            DesignSystem.StylePrimaryButton(btnSave);
            btnSave.Click += (s, e) =>
            {
                var handle = ShowOverlay();
                try
                {
                    SystemSettingsHelper.SetBool(dc, WhatsAppSettings.EnabledKey, chkEnabled.Checked, "تفعيل إشعارات واتساب لسير العمل");
                    SystemSettingsHelper.SetString(dc, WhatsAppSettings.InstanceNameKey, string.IsNullOrWhiteSpace(txtInstanceName.Text) ? null : txtInstanceName.Text, "Green API Instance Name (معلوماتي)");
                    SystemSettingsHelper.SetString(dc, WhatsAppSettings.ApiUrlKey, string.IsNullOrWhiteSpace(txtApiUrl.Text) ? null : txtApiUrl.Text, "Green API apiUrl (host الخاص بالحساب)");
                    SystemSettingsHelper.SetString(dc, WhatsAppSettings.MediaUrlKey, string.IsNullOrWhiteSpace(txtMediaUrl.Text) ? null : txtMediaUrl.Text, "Green API mediaUrl (لإرسال الملفات مستقبلاً)");
                    SystemSettingsHelper.SetString(dc, WhatsAppSettings.IdInstanceKey, string.IsNullOrWhiteSpace(txtIdInstance.Text) ? null : txtIdInstance.Text, "Green API Instance ID");
                    SystemSettingsHelper.SetString(dc, WhatsAppSettings.ApiTokenKey, string.IsNullOrWhiteSpace(txtApiToken.Text) ? null : txtApiToken.Text, "Green API Token");

                    XtraMessageBox.Show("تم حفظ الإعدادات بنجاح ✓", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            };

            var content = new Panel { Height = 478, BackColor = Color.White };
            content.Controls.AddRange(new Control[]
            {
                chkEnabled,
                txtInstanceName, lblInstanceName,
                txtApiUrl, lblApiUrl,
                txtMediaUrl, lblMediaUrl,
                txtIdInstance, lblIdInstance,
                txtApiToken, lblApiToken,
                btnTestSend, txtTestNumber, lblTest,
                lblHint, lblLastAttemptCaption, memoLastAttempt, btnSave,
            });

            return BuildCard("🔔  الإشعارات (واتساب)", "تنبيهات واتساب عند اعتماد/رفض خطوات سير العمل", content, 478);
        }

        // ════════════════════════════════════════════════════════════════
        //  SECTION: SMTP (real — outgoing email for document "send" buttons, e.g. CIR)
        // ════════════════════════════════════════════════════════════════
        private Control BuildSmtpPanel()
        {
            bool canManage = SystemSettingsPermissions.CanManage(dc);

            var chkEnabled = new CheckEdit
            {
                Text = "تفعيل إرسال البريد الإلكتروني من داخل النظام",
                Enabled = canManage,
                Checked = EmailSettings.IsEnabled(dc),
                Location = new Point(0, 4),
                Size = new Size(520, 24),
            };

            var lblHost = MakeLabel("خادم SMTP (Host):");
            lblHost.Location = new Point(300, 40);

            var txtHost = new TextEdit
            {
                Enabled = canManage,
                Text = EmailSettings.GetSmtpHost(dc) ?? "",
                Location = new Point(150, 40),
                Size = new Size(140, 24),
            };
            txtHost.Properties.NullValuePrompt = "smtp.gmail.com";
            txtHost.Properties.NullValuePromptShowForEmptyValue = true;

            var lblPort = MakeLabel("المنفذ (Port):");
            lblPort.Location = new Point(300, 76);

            var spnPort = new SpinEdit
            {
                Enabled = canManage,
                Value = EmailSettings.GetSmtpPort(dc),
                Location = new Point(150, 76),
                Size = new Size(140, 24),
            };
            spnPort.Properties.MinValue = 1;
            spnPort.Properties.MaxValue = 65535;
            spnPort.Properties.Mask.EditMask = "N00";

            var chkUseSsl = new CheckEdit
            {
                Text = "استخدام SSL/TLS",
                Enabled = canManage,
                Checked = EmailSettings.GetUseSsl(dc),
                Location = new Point(0, 76),
                Size = new Size(140, 24),
            };

            var lblUser = MakeLabel("اسم المستخدم:");
            lblUser.Location = new Point(300, 112);

            var txtUser = new TextEdit
            {
                Enabled = canManage,
                Text = EmailSettings.GetSmtpUser(dc) ?? "",
                Location = new Point(150, 112),
                Size = new Size(140, 24),
            };

            var lblPassword = MakeLabel("كلمة المرور:");
            lblPassword.Location = new Point(300, 148);

            var txtPassword = new TextEdit
            {
                Enabled = canManage,
                Text = EmailSettings.GetSmtpPassword(dc) ?? "",
                Location = new Point(150, 148),
                Size = new Size(140, 24),
            };
            txtPassword.Properties.PasswordChar = '●';

            var lblFromName = MakeLabel("اسم المرسل الظاهر:");
            lblFromName.Location = new Point(300, 184);

            var txtFromName = new TextEdit
            {
                Enabled = canManage,
                Text = EmailSettings.GetFromName(dc) ?? "",
                Location = new Point(150, 184),
                Size = new Size(140, 24),
            };

            var lblFromAddress = MakeLabel("عنوان بريد المرسل:");
            lblFromAddress.Location = new Point(300, 220);

            var txtFromAddress = new TextEdit
            {
                Enabled = canManage,
                Text = EmailSettings.GetFromAddress(dc) ?? "",
                Location = new Point(150, 220),
                Size = new Size(140, 24),
            };

            var lblTest = MakeLabel("بريد إلكتروني للاختبار:");
            lblTest.Location = new Point(300, 256);

            var txtTestAddress = new TextEdit
            {
                Enabled = canManage,
                Location = new Point(150, 256),
                Size = new Size(140, 24),
            };

            var btnTestSend = new SimpleButton
            {
                Text = "اختبار الإرسال", Width = 130, Height = 26, Enabled = canManage,
                Location = new Point(0, 256),
            };
            DesignSystem.StyleOutlineButton(btnTestSend);
            btnTestSend.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTestAddress.Text))
                {
                    XtraMessageBox.Show("الرجاء إدخال بريد إلكتروني للاختبار.", "اختبار الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var handle = ShowOverlay();
                try
                {
                    using var client = new System.Net.Mail.SmtpClient(txtHost.Text, (int)spnPort.Value)
                    {
                        EnableSsl = chkUseSsl.Checked,
                        Credentials = new System.Net.NetworkCredential(txtUser.Text, txtPassword.Text),
                    };
                    using var msg = new System.Net.Mail.MailMessage
                    {
                        From = new System.Net.Mail.MailAddress(txtFromAddress.Text, string.IsNullOrWhiteSpace(txtFromName.Text) ? txtFromAddress.Text : txtFromName.Text),
                        Subject = "رسالة اختبار من نظام Etmam",
                        Body = "إذا وصلتك هذه الرسالة فإعدادات البريد الإلكتروني (SMTP) صحيحة.",
                    };
                    msg.To.Add(txtTestAddress.Text);
                    client.Send(msg);

                    XtraMessageBox.Show("تم إرسال رسالة الاختبار بنجاح ✓", "اختبار الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string details = ex.InnerException != null ? $"{ex.Message}\n\n{ex.InnerException.Message}" : ex.Message;
                    XtraMessageBox.Show($"فشل الإرسال:\n{details}", "اختبار الإرسال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            };

            var lblHint = new LabelControl
            {
                Text = "تُستخدم هذه الإعدادات لإرسال المستندات (مثل طلب فحص الأعمال CIR) عبر البريد\nالإلكتروني مباشرة من داخل النظام مع إرفاق نسخة PDF تلقائياً.",
                Location = new Point(0, 292),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 40),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var btnSave = new SimpleButton { Text = "حفظ", Width = 100, Height = 30, Enabled = canManage, Location = new Point(0, 340) };
            DesignSystem.StylePrimaryButton(btnSave);
            btnSave.Click += (s, e) =>
            {
                var handle = ShowOverlay();
                try
                {
                    EmailSettings.SetSettings(dc, chkEnabled.Checked, txtHost.Text, (int)spnPort.Value,
                        txtUser.Text, txtPassword.Text, chkUseSsl.Checked, txtFromName.Text, txtFromAddress.Text);

                    XtraMessageBox.Show("تم حفظ الإعدادات بنجاح ✓", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            };

            var content = new Panel { Height = 386, BackColor = Color.White };
            content.Controls.AddRange(new Control[]
            {
                chkEnabled,
                txtHost, lblHost, spnPort, lblPort, chkUseSsl,
                txtUser, lblUser, txtPassword, lblPassword,
                txtFromName, lblFromName, txtFromAddress, lblFromAddress,
                btnTestSend, txtTestAddress, lblTest,
                lblHint, btnSave,
            });

            return BuildCard("📧  البريد الإلكتروني (SMTP)", "إعدادات إرسال المستندات عبر البريد الإلكتروني", content, 386);
        }

        // ════════════════════════════════════════════════════════════════
        //  SECTION: STORAGE (real — shared network folder for attachments)
        // ════════════════════════════════════════════════════════════════
        private Control BuildStoragePanel()
        {
            bool canManage = SystemSettingsPermissions.CanManage(dc);

            var txtSharedFolder = new TextEdit
            {
                Enabled = canManage,
                Text = AttachmentStorageSettings.GetFolderPath(dc) ?? "",
                Location = new Point(96, 40),
                Size = new Size(424, 24),
            };
            txtSharedFolder.Properties.NullValuePrompt = @"\\server\share\Etmam\Attachments";
            txtSharedFolder.Properties.NullValuePromptShowForEmptyValue = true;

            var btnBrowseSharedFolder = new SimpleButton
            {
                Text = "استعراض...",
                Width = 90,
                Height = 26,
                Enabled = canManage,
                Location = new Point(0, 40),
            };
            DesignSystem.StyleOutlineButton(btnBrowseSharedFolder);
            btnBrowseSharedFolder.Click += (s, e) =>
            {
                using var dlg = new XtraFolderBrowserDialog { SelectedPath = txtSharedFolder.Text };
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtSharedFolder.Text = dlg.SelectedPath;
            };

            var lblSection = MakeLabel("مجلد التخزين المشترك للمرفقات:", bold: true);
            lblSection.Location = new Point(0, 4);

            var lblHint = new LabelControl
            {
                Text = "مسار شبكي (UNC) يصل إليه جميع المستخدمين، مثل \\\\server\\share\\Etmam\\Attachments.\n" +
                       "عند تحديده: كل مرفق جديد (مستندات أو مخططات) يُخزَّن هنا بدلاً من مجلد الجهاز المحلي،\n" +
                       "فيصبح بإمكان أي مستخدم آخر فتحه. اترك الحقل فارغاً للعودة للتخزين المحلي على كل جهاز.",
                Location = new Point(0, 68),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 44),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var btnSave = new SimpleButton
            {
                Text = "حفظ",
                Width = 100,
                Height = 30,
                Enabled = canManage,
                Location = new Point(0, 116),
            };
            DesignSystem.StylePrimaryButton(btnSave);

            var lblMigrateSection = MakeLabel("ترحيل المرفقات القديمة إلى المجلد المشترك:", bold: true);
            lblMigrateSection.Location = new Point(0, 164);

            var lblMigrateHint = new LabelControl
            {
                Text = "ينقل هذا الزر مرفقات هذا الجهاز فقط (الموجودة فعلياً بمسارها القديم المحلي) إلى المجلد\n" +
                       "المشترك أعلاه، ويحدّث مسارها في قاعدة البيانات. المرفقات المرفوعة من أجهزة أخرى لن\n" +
                       "تتأثر — يلزم تشغيل هذا الترحيل مرة على كل جهاز رُفعت منه مرفقات قديمة.",
                Location = new Point(0, 190),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 44),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var btnMigrate = new SimpleButton
            {
                Text = "ترحيل مرفقات هذا الجهاز الآن",
                Width = 220,
                Height = 30,
                Enabled = !string.IsNullOrWhiteSpace(AttachmentStorageSettings.GetFolderPath(dc)),
                Location = new Point(0, 238),
            };
            DesignSystem.StyleOutlineButton(btnMigrate);

            btnSave.Click += (s, e) =>
            {
                var handle = ShowOverlay();
                try
                {
                    SystemSettingsHelper.SetString(
                        dc, AttachmentStorageSettings.SettingKey,
                        string.IsNullOrWhiteSpace(txtSharedFolder.Text) ? null : txtSharedFolder.Text,
                        "المجلد المشترك على الشبكة لتخزين مرفقات المستندات والمخططات");

                    btnMigrate.Enabled = !string.IsNullOrWhiteSpace(txtSharedFolder.Text);

                    XtraMessageBox.Show("تم حفظ الإعدادات بنجاح ✓", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            };

            btnMigrate.Click += (s, e) =>
            {
                var confirm = XtraMessageBox.Show(
                    "سيتم نقل كل مرفق موجود فعلياً على هذا الجهاز (بمساره القديم المحلي) إلى المجلد المشترك،\n" +
                    "وتحديث مساره في قاعدة البيانات. المرفقات المرفوعة من أجهزة أخرى لن تتأثر.\n\nهل تريد المتابعة؟",
                    "ترحيل المرفقات", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                var handle = ShowOverlay();
                try
                {
                    var result = AttachmentStorage.MigrateLocalAttachmentsToSharedFolder(dc);
                    string msg =
                        $"تم ترحيل {result.Migrated} مرفق بنجاح.\n" +
                        $"{result.AlreadyShared} مرفق كان منقولاً مسبقاً.\n" +
                        $"{result.NotFoundLocally} مرفق غير موجود على هذا الجهاز (على جهاز آخر على الأرجح).";
                    if (result.Failed > 0)
                        msg += $"\n\nفشل ترحيل {result.Failed} مرفق:\n" + string.Join("\n", result.Errors.Take(10));

                    XtraMessageBox.Show(msg, "نتيجة الترحيل", MessageBoxButtons.OK,
                        result.Failed > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"تعذّر تنفيذ الترحيل:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            };

            var lblMigrateDbSection = MakeLabel("ترحيل المرفقات القديمة إلى قاعدة البيانات:", bold: true);
            lblMigrateDbSection.Location = new Point(0, 284);

            var lblMigrateDbHint = new LabelControl
            {
                Text = "المرفقات الجديدة تُخزَّن مباشرة في قاعدة البيانات (لا تعتمد على مسار قرص/شبكة قد يتغيّر).\n" +
                       "هذا الزر يقرأ مرفقات هذا الجهاز القديمة (المستندات والمخططات) من مسارها السابق على القرص\n" +
                       "ويحفظها في قاعدة البيانات، بغضّ النظر عن كون المجلد المشترك أعلاه مُفعَّلاً أم لا — يلزم\n" +
                       "تشغيله مرة على كل جهاز/مجلد لا يزال يحتفظ بمرفقات قديمة على القرص.",
                Location = new Point(0, 310),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 56),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var btnMigrateDb = new SimpleButton
            {
                Text = "ترحيل مرفقات هذا الجهاز إلى قاعدة البيانات",
                Width = 260,
                Height = 30,
                Enabled = canManage,
                Location = new Point(0, 370),
            };
            DesignSystem.StyleOutlineButton(btnMigrateDb);

            btnMigrateDb.Click += (s, e) =>
            {
                var confirm = XtraMessageBox.Show(
                    "سيتم قراءة كل مرفق موجود فعلياً على هذا الجهاز من مساره القديم على القرص وحفظه في قاعدة\n" +
                    "البيانات. المرفقات الموجودة فعلاً في قاعدة البيانات، أو غير الموجودة على هذا الجهاز، لن تتأثر.\n\nهل تريد المتابعة؟",
                    "ترحيل المرفقات إلى قاعدة البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                var handle = ShowOverlay();
                try
                {
                    var result = AttachmentStorage.MigrateFilesToDatabase(dc);
                    string msg =
                        $"تم ترحيل {result.Migrated} مرفق بنجاح إلى قاعدة البيانات.\n" +
                        $"{result.AlreadyInDatabase} مرفق كان مخزَّناً في قاعدة البيانات مسبقاً.\n" +
                        $"{result.NotFoundOnDisk} مرفق غير موجود على هذا الجهاز (على جهاز/مجلد آخر على الأرجح).";
                    if (result.Failed > 0)
                        msg += $"\n\nفشل ترحيل {result.Failed} مرفق:\n" + string.Join("\n", result.Errors.Take(10));

                    XtraMessageBox.Show(msg, "نتيجة الترحيل", MessageBoxButtons.OK,
                        result.Failed > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"تعذّر تنفيذ الترحيل:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            };

            var content = new Panel { Height = 424, BackColor = Color.White };
            content.Controls.AddRange(new Control[]
            {
                lblSection, txtSharedFolder, btnBrowseSharedFolder, lblHint, btnSave,
                lblMigrateSection, lblMigrateHint, btnMigrate,
                lblMigrateDbSection, lblMigrateDbHint, btnMigrateDb,
            });

            return BuildCard("📁  مسارات التخزين", "المجلد المشترك على الشبكة لتخزين مرفقات النظام", content, 424);
        }

        // ════════════════════════════════════════════════════════════════
        //  SECTION: DATABASE (one-time/occasional data-fix tools)
        // ════════════════════════════════════════════════════════════════
        private Control BuildDatabasePanel()
        {
            bool canManage = SystemSettingsPermissions.CanManage(dc);

            var lblCIRSection = MakeLabel("تحديث حالة طلبات الفحص القديمة:", bold: true);
            lblCIRSection.Location = new Point(0, 4);

            var lblCIRHint = new LabelControl
            {
                Text = "قبل هذا الإصدار، كان رفض الاستشاري أو طلبه تعديلاً وإعادة تقديم لطلب فحص يُسجَّل بشكل\n" +
                       "صحيح في رد الاستشاري، لكن حالة الطلب العامة كانت تبقى \"مُرسل للمراجعة\" كأن شيئاً لم\n" +
                       "يحدث. هذا الزر يقرأ رد الاستشاري المسجَّل فعلياً لكل طلب لا يزال ظاهراً بحالة \"مُرسل\n" +
                       "للمراجعة\" ويصحّح حالته العامة بناءً عليه. آمن للتشغيل أكثر من مرة (لا يُغيّر طلباً صحيحاً\n" +
                       "أصلاً)، ولا يمسّ طلبات المسودة أو المُغلقة أو المُعاد إصدارها.",
                Location = new Point(0, 30),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 84),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var btnFixCIRStatus = new SimpleButton
            {
                Text = "تحديث حالات طلبات الفحص",
                Width = 220,
                Height = 30,
                Enabled = canManage,
                Location = new Point(0, 122),
            };
            DesignSystem.StyleOutlineButton(btnFixCIRStatus);

            btnFixCIRStatus.Click += (s, e) =>
            {
                var confirm = XtraMessageBox.Show(
                    "سيتم فحص كل طلبات الفحص التي حالتها \"مُرسل للمراجعة\" وتصحيح حالتها إذا كان رد\n" +
                    "الاستشاري المسجَّل فعلياً مرفوضاً أو يتطلب تعديلاً وإعادة تقديم. لا تأثير على الطلبات\n" +
                    "الأخرى.\n\nهل تريد المتابعة؟",
                    "تحديث حالات طلبات الفحص", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                var handle = ShowOverlay();
                try
                {
                    var result = CIRStatusBackfill.Run(dc);
                    XtraMessageBox.Show(
                        $"تم تصحيح حالة {result.Updated} طلب فحص.\n{result.AlreadyCorrect} طلب كانت حالته صحيحة بالفعل.",
                        "نتيجة التحديث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"تعذّر تنفيذ التحديث:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    CloseOverlay(handle);
                }
            };

            var content = new Panel { Height = 170, BackColor = Color.White };
            content.Controls.AddRange(new Control[] { lblCIRSection, lblCIRHint, btnFixCIRStatus });

            return BuildCard("🗄  قاعدة البيانات", "أدوات صيانة وتصحيح بيانات لمرة واحدة", content, 170);
        }

        private static string DescribeInstanceState(string? state) => state switch
        {
            "authorized" => "مرتبط ✓ (authorized)",
            "notAuthorized" => "غير مرتبط — يلزم مسح رمز QR (notAuthorized)",
            "blocked" => "محظور من واتساب (blocked)",
            "sleepMode" => "الهاتف مغلق حالياً (sleepMode)",
            "starting" => "الجهاز قيد بدء التشغيل، حاول بعد دقائق (starting)",
            "suspended" => "موقوف مؤقتاً من Green API (suspended)",
            null => "تعذّر التحقق من الحالة",
            _ => state,
        };

        // ════════════════════════════════════════════════════════════════
        //  SECTION: UPDATES (real — mandatory-update gate checked by frmStart)
        //  Source of truth is the GitHub repo's Releases page (see
        //  Etmam.Code.Update.GitHubUpdateChecker) - nothing to configure here
        //  anymore, this card is purely informational.
        // ════════════════════════════════════════════════════════════════
        private Control BuildUpdatesPanel()
        {
            const string releasesUrl = "https://github.com/mohaid81-design/Etmam/releases";

            var lblSection = MakeLabel("مصدر التحديثات:", bold: true);
            lblSection.Location = new Point(0, 4);

            var lblBody = new LabelControl
            {
                Text = "يتحقق البرنامج تلقائياً عند كل تشغيل من آخر إصدار منشور في صفحة\n" +
                       "إصدارات GitHub أدناه. أي مستخدم يشغّل نسخة أقدم من الإصدار المنشور\n" +
                       "هناك يُمنع من الدخول حتى يحدّثها بضغطة \"تحديث الآن\".",
                Location = new Point(0, 32),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 56),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var lblLinkCaption = MakeLabel("صفحة الإصدارات:", bold: true);
            lblLinkCaption.Location = new Point(0, 100);

            var linkReleases = new HyperlinkLabelControl
            {
                Text = releasesUrl,
                Location = new Point(0, 128),
                AutoSize = true,
            };
            linkReleases.Click += (s, e) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo(releasesUrl) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"تعذّر فتح الرابط:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            var lblHint = new LabelControl
            {
                Text = "لإصدار نسخة جديدة: أنشئ Release جديداً هناك بوسم يبدأ بالحرف v ويطابق\n" +
                       "رقم <Version> في Etmam.csproj (مثل v1.3.1)، وأرفق ملف EtmamSetup.exe\n" +
                       "به - لا حاجة لأي إعداد يدوي هنا.",
                Location = new Point(0, 156),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(520, 52),
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            var content = new Panel { Height = 216, BackColor = Color.White };
            content.Controls.AddRange(new Control[] { lblSection, lblBody, lblLinkCaption, linkReleases, lblHint });

            return BuildCard("🔄  تحديث البرنامج", "الإصدار المطلوب يُقرأ تلقائياً من صفحة إصدارات GitHub", content, 216);
        }

        // ════════════════════════════════════════════════════════════════
        //  SECTION: ABOUT (real branding only — no invented data)
        // ════════════════════════════════════════════════════════════════
        private Control BuildAboutPanel()
        {
            var content = new Panel { Height = 90, BackColor = Color.White };

            void AddRow(string label, string value, int y)
            {
                content.Controls.Add(new LabelControl
                {
                    Text = label,
                    Location = new Point(0, y),
                    AutoSize = true,
                    Font = DesignSystem.Fonts.Bold(9),
                    ForeColor = DesignSystem.Colors.TextSecondary,
                });
                content.Controls.Add(new LabelControl
                {
                    Text = value,
                    Location = new Point(180, y),
                    AutoSize = true,
                    Font = DesignSystem.Fonts.Regular(9),
                    ForeColor = DesignSystem.Colors.TextPrimary,
                });
            }

            AddRow("اسم النظام:", "نظام إدارة مشاريع اعتماد (Etmam)", 4);
            AddRow("الإصدار:", Application.ProductVersion, 34);
            AddRow("حقوق الملكية:", $"© {DateTime.Now.Year} — جميع الحقوق محفوظة", 64);

            return BuildCard("ℹ  حول البرنامج", "معلومات النظام", content, 90);
        }

        // ════════════════════════════════════════════════════════════════
        //  COMING SOON placeholder — honest, no fake controls
        // ════════════════════════════════════════════════════════════════
        private Control BuildComingSoonPanel(string title)
        {
            var pnl = new Panel { Height = 160, BackColor = Color.White };
            var lbl = new LabelControl
            {
                Text = "هذا القسم قيد التطوير ولم يُفعَّل بعد.",
                Dock = DockStyle.Fill,
                Font = DesignSystem.Fonts.Regular(10),
                ForeColor = DesignSystem.Colors.TextTertiary,
            };
            lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lbl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            pnl.Controls.Add(lbl);
            return BuildCard(title, "قيد التطوير", pnl, 160);
        }

        // ════════════════════════════════════════════════════════════════
        //  CARD BUILDER
        // ════════════════════════════════════════════════════════════════
        private Panel BuildCard(string title, string desc, Control content, int contentHeight)
        {
            var card = new Panel { BackColor = Color.White, Dock = DockStyle.Top, Height = contentHeight + 56 + 12, Padding = new Padding(0, 0, 0, 12) };

            var hdr = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.White, Padding = new Padding(14, 10, 14, 6) };
            hdr.Paint += DesignSystem.DrawBottomBorder;

            var lblT = new LabelControl
            {
                Text = title,
                Font = DesignSystem.Fonts.Bold(10.5f),
                ForeColor = DesignSystem.Colors.TextPrimary,
                Dock = DockStyle.Right,
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 300,
            };
            var lblD = new LabelControl
            {
                Text = desc,
                Font = DesignSystem.Fonts.Regular(8),
                ForeColor = DesignSystem.Colors.TextTertiary,
                Dock = DockStyle.Right,
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 240,
            };
            hdr.Controls.AddRange(new Control[] { lblD, lblT });

            var wrapper = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(0, 0, 0, 10) };
            wrapper.Paint += DesignSystem.DrawCardBorder;

            content.Dock = DockStyle.Top;
            var contentWrap = new Panel { Dock = DockStyle.Fill, Padding = new Padding(14, 8, 14, 8), BackColor = Color.White, Height = contentHeight };
            contentWrap.Controls.Add(content);
            wrapper.Controls.Add(contentWrap);
            wrapper.Controls.Add(hdr);

            card.Controls.Add(wrapper);
            return card;
        }

        private void InitializeComponent()
        {

        }

        private static LabelControl MakeLabel(string text, bool bold = false) => new LabelControl
        {
            Text = text,
            Font = bold ? DesignSystem.Fonts.Bold(9) : DesignSystem.Fonts.Regular(9),
            ForeColor = DesignSystem.Colors.TextPrimary,
            AutoSize = true,
        };

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
