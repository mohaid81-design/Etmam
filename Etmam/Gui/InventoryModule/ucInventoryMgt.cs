using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using DevExpress.DataAccess.Native;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class ucInventoryMgt : DevExpress.XtraEditors.XtraUserControl
    {
        public ucInventoryMgt()
        {
            InitializeComponent();

            if (DesignMode) return;

            StyleTabbedView();
            //StyleTileBar();
            WireEvents();

            // أيقونة تايل الجرد رُسمت مباشرة بالكود (SVG مضمَّن) بدل مورد .resx ثنائي — التايلات
            // الأخرى تحمل أيقوناتها من resx (بيانات ثنائية مُسلسَلة يتعذّر كتابتها يدوياً بأمان).
            tbiStocking.Elements[0].ImageOptions.SvgImage = LoadStockingIcon();
            tbiOpeningBalance.Elements[0].ImageOptions.SvgImage = LoadOpeningBalanceIcon();

            // افتح المخازن تلقائياً عند التحميل
            this.Load += (s, e) => OpenTab("المخازن", "Store", "47Stores", () => new ucStores());
        }

        private static DevExpress.Utils.Svg.SvgImage LoadStockingIcon()
        {
            const string svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 32 32\">" +
                "<rect x=\"6\" y=\"3\" width=\"20\" height=\"27\" rx=\"2\" fill=\"#eaf1fb\" stroke=\"#1e4682\" stroke-width=\"1.6\"/>" +
                "<rect x=\"11\" y=\"1\" width=\"10\" height=\"5\" rx=\"1.5\" fill=\"#1e4682\"/>" +
                "<line x1=\"10\" y1=\"12\" x2=\"22\" y2=\"12\" stroke=\"#5f8ac3\" stroke-width=\"1.8\" stroke-linecap=\"round\"/>" +
                "<line x1=\"10\" y1=\"17\" x2=\"22\" y2=\"17\" stroke=\"#5f8ac3\" stroke-width=\"1.8\" stroke-linecap=\"round\"/>" +
                "<line x1=\"10\" y1=\"22\" x2=\"16\" y2=\"22\" stroke=\"#5f8ac3\" stroke-width=\"1.8\" stroke-linecap=\"round\"/>" +
                "<path d=\"M17 22.5l2 2 4-4.5\" fill=\"none\" stroke=\"#2f9e44\" stroke-width=\"2.2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>" +
                "</svg>";

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(svg));
            return new DevExpress.Utils.Svg.SvgImage(stream);
        }

        /// <summary>Same hand-drawn-SVG-in-code workaround as LoadStockingIcon (a coin/plus glyph for
        /// "رصيد افتتاحي") — this tile was added after the last time the resx's binary SvgImageCollection
        /// resource could be regenerated through Visual Studio's designer.</summary>
        private static DevExpress.Utils.Svg.SvgImage LoadOpeningBalanceIcon()
        {
            const string svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 32 32\">" +
                "<circle cx=\"16\" cy=\"17\" r=\"11\" fill=\"#eaf1fb\" stroke=\"#1e4682\" stroke-width=\"1.6\"/>" +
                "<line x1=\"16\" y1=\"11\" x2=\"16\" y2=\"23\" stroke=\"#5f8ac3\" stroke-width=\"1.8\" stroke-linecap=\"round\"/>" +
                "<line x1=\"11\" y1=\"17\" x2=\"21\" y2=\"17\" stroke=\"#5f8ac3\" stroke-width=\"1.8\" stroke-linecap=\"round\"/>" +
                "<path d=\"M9 5l3 3M23 5l-3 3\" stroke=\"#2f9e44\" stroke-width=\"1.8\" stroke-linecap=\"round\"/>" +
                "</svg>";

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(svg));
            return new DevExpress.Utils.Svg.SvgImage(stream);
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
            ai.Normal.BackColor    = Color.FromArgb(30, 70, 130);
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
            ai.Pressed.BackColor   = Color.FromArgb(15, 45, 90);
            ai.Pressed.ForeColor   = Color.White;
            ai.Pressed.BorderColor = DesignSystem.Colors.Accent;
            ai.Pressed.Font        = new Font("Cairo", 9F, FontStyle.Bold);
            ai.Pressed.Options.UseBackColor   = true;
            ai.Pressed.Options.UseForeColor   = true;
            ai.Pressed.Options.UseBorderColor = true;
            ai.Pressed.Options.UseFont        = true;

            // Selected — a shade deeper than Normal with a bright Accent ring so the
            // open module stays visually distinct from a merely hovered one
            ai.Selected.BackColor   = Color.FromArgb(15, 50, 100);
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
            tbMain.Padding = new Padding(16, 6, 16, 6);
            tbMain.IndentBetweenItems  = 10;
            tbMain.ItemBorderVisibility = DevExpress.XtraEditors.TileItemBorderVisibility.Always;

            // Forces every tile icon to a single solid white glyph — TileBar's own
            //AllowGlyphSkinning / SvgImageColorizationMode knobs can't produce a custom
            // color (only "original" or a fixed skin color), so this rewrites the SVGs directly.
            DesignSystem.RecolorTileBarIcons(tbMain, Color.White);
        }

        // ──────────────────────────────────────────────────────────
        //  ربط الأحداث
        // ──────────────────────────────────────────────────────────
        private void WireEvents()
        {
            tbiStore.ItemClick             += (s, e) => OpenTab("المخازن", "Store", "47Stores", () => new ucStores());
            tbiItems.ItemClick             += (s, e) => OpenTab("الأصناف", "Items", "48Items", () => new ucItems());
            itbMaterialReceive.ItemClick   += (s, e) => OpenTab("إذن إستلام", "MaterialReceive", "49MaterialReceiveVoucher", () => new ucMaterialReceive());
            tbiMaterialIssued.ItemClick    += (s, e) => OpenTab("إذن صرف", "MaterialIssued", "50MaterialIssuedVoucher", () => new ucMaterialIssued());
            tbiMaterialTrasfare.ItemClick  += (s, e) => OpenTab("تحويل بين المخازن", "MaterialTrasfare", "51MaterialTransfer", () => new ucMaterialTrasfare());
            tbiPurchaseReturn.ItemClick    += (s, e) => OpenTab("مرتجع مشتريات", "PurchaseReturn", "53PurchaseReturn", () => new ucPurchaseReturn());
            tbiMaterialIssueReturn.ItemClick += (s, e) => OpenTab("مرتجع صرف", "MaterialIssueReturn", "54MaterialIssueReturn", () => new ucMaterialIssueReturn());
            tbiInventoryReports.ItemClick  += (s, e) => OpenTab("تقارير المخزون", "InventoryReports", "55InventoryReports", () => new ucInventoryReports());
            // "48Items" مُعاد استخدامه هنا مؤقتاً لأيقونة التبويب (لا يوجد بعد مورد .resx مخصص
            // للجرد في svgImageCollection1 — أيقونة التايل نفسه مختلفة ومرسومة كوداً، انظر LoadStockingIcon)
            tbiStocking.ItemClick          += (s, e) => OpenTab("جرد المخزون", "Stocking", "48Items", () => new ucStocking());
            // نفس الحل المؤقت: لا يوجد مفتاح "OpeningBalance" مسجَّل في svgImageCollection1 (أيقونة التبويب
            // فقط — أيقونة التايل نفسها مرسومة كوداً، انظر LoadOpeningBalanceIcon)، فأُعيد استخدام مفتاح
            // "48Items" الموجود فعلاً بدل اختراع مفتاح غير مسجَّل.
            tbiOpeningBalance.ItemClick    += (s, e) => OpenTab("رصيد افتتاحي", "OpeningBalance", "48Items", () => new ucOpeningBalance());
        }

        // ──────────────────────────────────────────────────────────
        //  فتح / التنقل بين التبويبات
        // ──────────────────────────────────────────────────────────
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
                var uc  = factory();
                uc.Dock = DockStyle.Fill;

                var doc = tabbedView1.AddDocument(uc) as Document;
                if (doc != null)
                {
                    doc.Caption = caption;
                    doc.Tag     = key;

                    var svgImg = svgImageCollection1[imageKey];
                    if (svgImg != null)
                    {
                        doc.ImageOptions.SvgImageSize = new Size(20, 20);
                        doc.ImageOptions.SvgImage     = svgImg;
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
