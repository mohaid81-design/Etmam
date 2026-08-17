using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using DevExpress.DataAccess.Native;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class ucSubcontractorMgt : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSubcontractorMgt()
        {
            InitializeComponent();

            if (DesignMode) return;

            StyleTabbedView();
            WireEvents();

            // افتح المخازن تلقائياً عند التحميل
            this.Load += (s, e) => OpenTab("المخازن", "Store", "47Stores", () => new ucStores());
        }

        // ──────────────────────────────────────────────────────────
        //  Style TabbedView
        // ──────────────────────────────────────────────────────────
        private void StyleTabbedView()
        {
            var ap = tabbedView1.AppearancePage;

            // Hover
            ap.HeaderHotTracked.BackColor = Color.FromArgb(190, 218, 255);
            ap.HeaderHotTracked.Options.UseBackColor = true;
           
            ap.HeaderActive.BackColor = Color.FromArgb(22, 96, 190);
            ap.HeaderActive.Options.UseBackColor = true;
            
            ap.HeaderSelected.BackColor = Color.FromArgb(52, 130, 220);
            ap.HeaderSelected.Options.UseBackColor = true;
           
            ap.HeaderDisabled.BackColor = Color.FromArgb(215, 222, 232);
            ap.HeaderDisabled.Options.UseBackColor = true;
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
            tbiInventoryReports.ItemClick  += (s, e) => OpenTab("تقارير المخزون", "InventoryReports", "55InventoryReports", null);
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
    }
}
