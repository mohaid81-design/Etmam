using DevExpress.XtraBars.Docking2010.Views.Tabbed;

namespace Etmam
{
    public partial class ucProcurementMgt : DevExpress.XtraEditors.XtraUserControl
    {
        // ── Constructor ───────────────────────────────────────────────────────
        public ucProcurementMgt()
        {
            InitializeComponent();

            if (DesignMode) return;
           
            StyleTabbedView();
            StyleTileBar();
            WireEvents();

            // افتح طلبات الشراء تلقائياً عند التحميل
            this.Load += (s, e) => OpenTab("طلبات الشراء", "PurchaseRequest", "PurchaseRequest", () => new ucPurchaseRequests());
        }

        // ──────────────────────────────────────────────────────────
        //  Style TabbedView
        //  Aligned with the app's shared DesignSystem palette instead of
        //  one-off blues, with a subtle gradient on the active/selected tab.
        // ──────────────────────────────────────────────────────────
        private void StyleTabbedView()
        {
            var ap = tabbedView1.AppearancePage;

            // Inactive tab
            ap.Header.BackColor   = DesignSystem.Colors.Surface;
            ap.Header.ForeColor   = DesignSystem.Colors.Secondary;
            ap.Header.BorderColor = DesignSystem.Colors.Border;
            ap.Header.Font        = new Font("Cairo", 8.5F);
            ap.Header.Options.UseBackColor   = true;
            ap.Header.Options.UseForeColor   = true;
            ap.Header.Options.UseBorderColor = true;
            ap.Header.Options.UseFont        = true;

            // Hover
            ap.HeaderHotTracked.BackColor = Color.FromArgb(222, 233, 248);
            ap.HeaderHotTracked.ForeColor = DesignSystem.Colors.Primary;
            ap.HeaderHotTracked.Font      = new Font("Cairo", 8.5F);
            ap.HeaderHotTracked.Options.UseBackColor = true;
            ap.HeaderHotTracked.Options.UseForeColor = true;
            ap.HeaderHotTracked.Options.UseFont      = true;

            // Active tab group header (highlighted when this group has focus)
            ap.HeaderActive.BackColor    = DesignSystem.Colors.Primary;
            ap.HeaderActive.BackColor2   = Color.FromArgb(18, 48, 95);
            ap.HeaderActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            ap.HeaderActive.ForeColor    = Color.White;
            ap.HeaderActive.Font         = new Font("Cairo", 9F, FontStyle.Bold);
            ap.HeaderActive.Options.UseBackColor = true;
            ap.HeaderActive.Options.UseForeColor = true;
            ap.HeaderActive.Options.UseFont      = true;

            // Selected (currently open) tab
            ap.HeaderSelected.BackColor    = DesignSystem.Colors.Accent;
            ap.HeaderSelected.BackColor2   = DesignSystem.Colors.Primary;
            ap.HeaderSelected.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            ap.HeaderSelected.ForeColor    = Color.White;
            ap.HeaderSelected.BorderColor  = DesignSystem.Colors.Primary;
            ap.HeaderSelected.Font         = new Font("Cairo", 9F, FontStyle.Bold);
            ap.HeaderSelected.Options.UseBackColor   = true;
            ap.HeaderSelected.Options.UseForeColor   = true;
            ap.HeaderSelected.Options.UseBorderColor = true;
            ap.HeaderSelected.Options.UseFont        = true;

            // Disabled
            ap.HeaderDisabled.BackColor = DesignSystem.Colors.Background;
            ap.HeaderDisabled.ForeColor = Color.FromArgb(160, 168, 180);
            ap.HeaderDisabled.Font      = new Font("Cairo", 8.5F);
            ap.HeaderDisabled.Options.UseBackColor = true;
            ap.HeaderDisabled.Options.UseForeColor = true;
            ap.HeaderDisabled.Options.UseFont      = true;

            // Content area behind each open module — matches the app's shared background
            // instead of the default skin color, so it doesn't look like a mismatched panel.
            ap.PageClient.BackColor = DesignSystem.Colors.Background;
            ap.PageClient.Options.UseBackColor = true;

            // Show the close (×) button only on the active tab or on hover, not on every
            // tab at once — reduces visual clutter when several modules are open.
            tabbedView1.DocumentGroupProperties.ClosePageButtonShowMode =
                DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
        }

        // ──────────────────────────────────────────────────────────
        //  Style TileBar
        //  Aligned with the shared DesignSystem palette (same Primary/Accent
        //  used across the app) instead of one-off navy shades, with clearer
        //  separation between Hovered/Pressed/Selected states.
        // ──────────────────────────────────────────────────────────
        private void StyleTileBar()
        {
            // نتحكم بلون الأيقونات يدوياً بالأسفل بدل الاعتماد على تلوين الـ Skin التلقائي
            tbMain.AllowGlyphSkinning = false;

            var ai = tbMain.AppearanceItem;

            // Normal — lighter mid-blue instead of the heavy navy, still readable
            // with light text but no longer dominating the bar visually
            ai.Normal.BackColor    = Color.FromArgb(64, 108, 172);
            ai.Normal.ForeColor    = Color.FromArgb(225, 235, 252);
            ai.Normal.BorderColor  = Color.FromArgb(95, 138, 195);
            ai.Normal.Font         = new Font("Cairo", 9F, FontStyle.Bold);
            ai.Normal.Options.UseBackColor   = true;
            ai.Normal.Options.UseForeColor   = true;
            ai.Normal.Options.UseBorderColor = true;
            ai.Normal.Options.UseFont        = true;

            // Hovered — jumps to the bright Accent so the hovered tile clearly pops
            ai.Hovered.BackColor   = DesignSystem.Colors.Accent;
            ai.Hovered.ForeColor   = Color.White;
            ai.Hovered.BorderColor = Color.FromArgb(120, 190, 255);
            ai.Hovered.Font        = new Font("Cairo", 9F, FontStyle.Bold);
            ai.Hovered.Options.UseBackColor   = true;
            ai.Hovered.Options.UseForeColor   = true;
            ai.Hovered.Options.UseBorderColor = true;
            ai.Hovered.Options.UseFont        = true;

            // Pressed
            ai.Pressed.BackColor   = Color.FromArgb(40, 80, 140);
            ai.Pressed.ForeColor   = Color.White;
            ai.Pressed.BorderColor = DesignSystem.Colors.Accent;
            ai.Pressed.Font        = new Font("Cairo", 9F, FontStyle.Bold);
            ai.Pressed.Options.UseBackColor   = true;
            ai.Pressed.Options.UseForeColor   = true;
            ai.Pressed.Options.UseBorderColor = true;
            ai.Pressed.Options.UseFont        = true;

            // Selected — a shade deeper than Normal with a bright Accent ring so the
            // open module stays visually distinct from a merely hovered one
            ai.Selected.BackColor   = Color.FromArgb(45, 92, 155);
            ai.Selected.ForeColor   = Color.White;
            ai.Selected.BorderColor = DesignSystem.Colors.Accent;
            ai.Selected.Font        = new Font("Cairo", 9F, FontStyle.Bold);
            ai.Selected.Options.UseBackColor   = true;
            ai.Selected.Options.UseForeColor   = true;
            ai.Selected.Options.UseBorderColor = true;
            ai.Selected.Options.UseFont        = true;

            // Disabled
            ai.Disabled.BackColor  = Color.FromArgb(210, 214, 220);
            ai.Disabled.ForeColor  = Color.FromArgb(140, 148, 160);
            ai.Disabled.Font       = new Font("Cairo", 8.5F);
            ai.Disabled.Options.UseBackColor = true;
            ai.Disabled.Options.UseForeColor = true;
            ai.Disabled.Options.UseFont      = true;

            // Bar background — matches the app's shared light background instead of
            // flat mid-grey, so the bold tile colors read as cards sitting on top of it.
            tbMain.BackColor           = DesignSystem.Colors.Background;
            tbMain.Padding             = new Padding(16, 6, 16, 6);
            tbMain.IndentBetweenItems  = 10;
            tbMain.ItemBorderVisibility = DevExpress.XtraEditors.TileItemBorderVisibility.Always;

            // Forces every tile icon to a single solid white glyph — TileBar's own
            // AllowGlyphSkinning/SvgImageColorizationMode knobs can't produce a custom
            // color (only "original" or a fixed skin color), so this rewrites the SVGs directly.
            DesignSystem.RecolorTileBarIcons(tbMain, Color.White);
        }

        // ──────────────────────────────────────────────────────────
        //  ربط الأحداث
        // ──────────────────────────────────────────────────────────
        private void WireEvents()
        {
            tbiPurchaseRequest.ItemClick += (s, e) => OpenTab("طلبات الشراء", "PurchaseRequest", "PurchaseRequest", () => new ucPurchaseRequests());
            tbiDashboard.ItemClick += (s, e) => OpenTab("لوحة التحكم", "Dashboard", "Dashboard", null);
            itbPurchaseOrder.ItemClick += (s, e) => OpenTab("أوامر الشراء", "PurchaseOrder", "PurchaseOrder", () => new ucPurchaseOrder());
            itbSuppliers.ItemClick += (s, e) => OpenTab("الموردون", "Suppliers", "Stakeholder", () => new ucSuppliers());
            itbProcurementReports.ItemClick += (s, e) => OpenTab("تقارير المشتريات", "PurchaseReports", "Reports", null);
        }

        private void OpenTab(string caption, string key, string imageKey, Func<UserControl>? factory)
        {
            // البحث عن تاب مفتوح بنفس المفتاح
            var existing = tabbedView1.Documents
                .FirstOrDefault(d => d.Tag?.ToString() == key);

            if (existing != null)
            {
                tabbedView1.Controller.Activate(existing);
                return;
            }

            // تحقق من توفر Factory
            if (factory == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"الوحدة [{caption}] قيد التطوير.",
                    "قيد التطوير",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                var uc = factory();
                uc.Dock = DockStyle.Fill;

                var doc = tabbedView1.AddDocument(uc) as Document;
                if (doc != null)
                {
                    doc.Caption = caption;
                    doc.Tag = key;

                    var svgImg = svgImageCollection1[imageKey];
                    if (svgImg != null)
                    {
                        doc.ImageOptions.SvgImageSize = new Size(20, 20);
                        doc.ImageOptions.SvgImage = svgImg;
                    }

                    tabbedView1.Controller.Activate(doc);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"خطأ أثناء فتح [{caption}]:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnProjectChanged()
        {
            foreach (var doc in tabbedView1.Documents)
            {
                if (doc.Control != null)
                {
                    var refreshMethod = doc.Control.GetType().GetMethod("OnProjectChanged",
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.Public |
                        System.Reflection.BindingFlags.NonPublic);
                    refreshMethod?.Invoke(doc.Control, null);
                }
            }
        }

    }
}
