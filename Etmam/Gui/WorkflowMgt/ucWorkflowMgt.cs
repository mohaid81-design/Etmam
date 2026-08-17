using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;

namespace Etmam
{
    /// <summary>Workflow module container: tile navigation + tabbed document area, mirroring ucProcurementMgt.</summary>
    public class ucWorkflowMgt : XtraUserControl
    {
        private readonly TileBar tbMain = new();
        private readonly DocumentManager documentManager1 = new();
        private readonly TabbedView tabbedView1 = new();

        public ucWorkflowMgt()
        {
            if (DesignMode) return;

            documentManager1.ContainerControl = this;
            documentManager1.View = tabbedView1;
            documentManager1.ViewCollection.Add(tabbedView1);

            BuildTileBar();
            StyleTabbedView();

            Controls.Add(tbMain);
            RightToLeft = RightToLeft.Yes;

            this.Load += (s, e) => OpenTab("مهامي", "MyWorkflowTasks", () => new ucMyWorkflowTasks());
        }

        private void BuildTileBar()
        {
            tbMain.Dock = DockStyle.Top;
            tbMain.ItemPadding = new Padding(16, 6, 16, 6);
            tbMain.Padding = new Padding(16, 6, 16, 6);

            var group = new TileBarGroup();

            var tbiMyTasks = new TileBarItem { Id = 1, ItemSize = TileBarItemSize.Wide, Name = "tbiMyTasks" };
            tbiMyTasks.Elements.Add(new DevExpress.XtraEditors.TileItemElement { Text = "مهامي" });
            tbiMyTasks.ItemClick += (s, e) => OpenTab("مهامي", "MyWorkflowTasks", () => new ucMyWorkflowTasks());

            var tbiDefinitions = new TileBarItem { Id = 2, ItemSize = TileBarItemSize.Wide, Name = "tbiDefinitions" };
            tbiDefinitions.Elements.Add(new DevExpress.XtraEditors.TileItemElement { Text = "تعريف الإجراءات" });
            tbiDefinitions.ItemClick += (s, e) => OpenTab("تعريف الإجراءات", "WorkflowDefinitions", () => new ucWorkflowDefinitions());

            group.Items.Add(tbiMyTasks);
            group.Items.Add(tbiDefinitions);
            tbMain.Groups.Add(group);
        }

        private void StyleTabbedView()
        {
            var ap = tabbedView1.AppearancePage;

            ap.Header.BackColor = DesignSystem.Colors.Surface;
            ap.Header.ForeColor = DesignSystem.Colors.Secondary;
            ap.Header.Font = new Font("Cairo", 8.5F);
            ap.Header.Options.UseBackColor = true;
            ap.Header.Options.UseForeColor = true;
            ap.Header.Options.UseFont = true;

            ap.HeaderSelected.BackColor = DesignSystem.Colors.Primary;
            ap.HeaderSelected.ForeColor = Color.White;
            ap.HeaderSelected.Font = new Font("Cairo", 9F, FontStyle.Bold);
            ap.HeaderSelected.Options.UseBackColor = true;
            ap.HeaderSelected.Options.UseForeColor = true;
            ap.HeaderSelected.Options.UseFont = true;
        }

        private void OpenTab(string caption, string key, Func<UserControl> factory)
        {
            var existing = tabbedView1.Documents.FirstOrDefault(d => d.Tag?.ToString() == key);
            if (existing != null)
            {
                tabbedView1.Controller.Activate(existing);
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
                    tabbedView1.Controller.Activate(doc);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء فتح [{caption}]:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnProjectChanged()
        {
            foreach (var doc in tabbedView1.Documents)
            {
                if (doc.Control == null) continue;
                var m = doc.Control.GetType().GetMethod("OnProjectChanged",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
                m?.Invoke(doc.Control, null);
            }
        }
    }
}
