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
    public partial class ucMaterialReceive : DevExpress.XtraEditors.XtraUserControl
    {
        public ucMaterialReceive()
        {
            InitializeComponent();
            if (DesignMode) return;

            DesignSystem.ApplyCairoFont(this);
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);

            this.Load += (s, e) => {
                LoadLookups();
                LoadData();
            };

            // Wire Toolbar Events
            bbiNew.ItemClick += bbiNew_ItemClick;
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            bbiRefresh.ItemClick += bbiRefresh_ItemClick;
            bbiPrint.ItemClick += bbiPrint_ItemClick;

            // Wire Store Lookup change
            lookUpEditStore.EditValueChanged += (s, e) => LoadData();

            // Double click grid row to edit
            gridView1.DoubleClick += (s, e) =>
            {
                var row = gridView1.GetFocusedRow() as MaterialReceiveList;
                if (row != null)
                {
                    OpenAddEdit(row.Id);
                }
            };
        }

        private void LoadLookups()
        {
            var dc = Data.DataContext.Shared;

            var stores = dc.StoreList.GetBy("IsDelete = 0");
            lookUpEditStore.Properties.DataSource = stores;
            lookUpEditStore.Properties.ValueMember = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText = "-- الكل --";

            riLookUpStore.DataSource = stores;
            riLookUpStore.ValueMember = "Id";
            riLookUpStore.DisplayMember = "Name";
            riLookUpStore.NullText = "";

            var suppliers = dc.StakeholdersList.GetBy("IsDelete = 0");
            riLookUpStakeholder.DataSource = suppliers;
            riLookUpStakeholder.ValueMember = "Id";
            riLookUpStakeholder.DisplayMember = "Name";
            riLookUpStakeholder.NullText = "";
        }

        public void LoadData()
        {
            try
            {
                var dc = Data.DataContext.Shared;
                int prjId = Session.SelectedProjectId ?? 0;
                var storeVal = lookUpEditStore.EditValue;

                string filter = "IsDelete = 0";
                if (prjId > 0)
                {
                    filter += " AND PrjId = @PrjId";
                }
                if (storeVal != null && storeVal != DBNull.Value)
                {
                    filter += " AND StoreId = @StoreId";
                }

                var data = dc.MaterialReceiveList.GetBy(filter, new { PrjId = prjId, StoreId = storeVal });
                gridControl1.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل أذونات الاستلام:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAddEdit(int id)
        {
            using (var frm = new frmMaterialReceiveAddEdit(id))
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
            var row = gridView1.GetFocusedRow() as MaterialReceiveList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد إذن استلام لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as MaterialReceiveList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد إذن استلام لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف إذن الاستلام هذا؟\nسيتم حذف جميع السطور المرتبطة به.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    Data.DataContext.Shared.DeleteMaterialReceive(row.Id);
                    XtraMessageBox.Show("تم حذف إذن الاستلام بنجاح.", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
