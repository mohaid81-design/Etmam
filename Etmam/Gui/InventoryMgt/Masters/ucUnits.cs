using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Core;
using Data;

namespace Etmam
{
    public partial class ucUnits : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;

        public ucUnits()
        {
            InitializeComponent();
            if (DesignMode) return;

            InitializeGrid();
            DesignSystem.ApplyCairoFont(this);

            this.Load += (s, e) => LoadData();

            // Wire Toolbar Events
            bbiNew.ItemClick += bbiNew_ItemClick;
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            bbiPrint.ItemClick += bbiPrint_ItemClick;

            // Double click grid row to edit
            gridView1.DoubleClick += (s, e) =>
            {
                var row = gridView1.GetFocusedRow() as Units;
                if (row != null)
                {
                    OpenAddEdit(row.Id);
                }
            };
        }

        private void InitializeGrid()
        {
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();

            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            gridControl1.Dock = DockStyle.Fill;
            this.Controls.Add(gridControl1);
            gridControl1.BringToFront();

            // Setup columns
            var colId = gridView1.Columns.AddVisible("Id", "م");
            colId.Visible = false;

            var colDesc = gridView1.Columns.AddVisible("Description", "اسم الوحدة");
            colDesc.Width = 200;

            var colAbbr = gridView1.Columns.AddVisible("Abbreviation", "الاختصار");
            colAbbr.Width = 100;
            DesignSystem.SetColumnCentered(colAbbr);

            var colCat = gridView1.Columns.AddVisible("Category", "الفئة");
            colCat.Width = 150;

            DesignSystem.ApplyGridStyle(gridControl1, gridView1);
            gridView1.OptionsBehavior.Editable = false;
        }

        public void LoadData()
        {
            try
            {
                var dc = Data.DataContext.Shared;
                var data = dc.Units.GetBy("IsDelete = 0");
                gridControl1.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل الوحدات:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAddEdit(int id)
        {
            using (var frm = new frmUnitAddEdit(id))
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenAddEdit(0);
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as Units;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد وحدة قياس لتعديلها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as Units;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد وحدة قياس لحذفها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف وحدة القياس هذه؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    row.IsDelete = true;
                    row.DeletionDate = DateTime.Now;
                    row.DeletionMachine = Session.Machine;
                    row.DeletionBy = Session.CurrentUser?.Id ?? 1;

                    Data.DataContext.Shared.Units.Edit(row.Id, row);
                    XtraMessageBox.Show("تم حذف وحدة القياس بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridControl1.ShowPrintPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        public void OnProjectChanged()
        {
            LoadData();
        }
    }
}
