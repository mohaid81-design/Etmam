using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Modal picker for choosing an approved Purchase Order that still has at least one line not
    /// yet fully received (via PurchaseOrderReceiveProgress) — same list/search/select pattern as
    /// frmPurchaseRequestSelect, one step further down the procurement chain. Opened from
    /// frmMaterialReceiveAddEdit.btnPO instead of relying solely on the header's plain PO lookup.</summary>
    public class frmPurchaseOrderSelect : XtraForm
    {
        private static DataContext dc => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public PurchaseOrderList? SelectedPO { get; private set; }

        private List<PurchaseOrderList> _allPOs = new();

        private readonly TextEdit txtSearch = new();
        private readonly GridControl gridControl1 = new();
        private readonly GridView gridView1;
        private readonly SimpleButton btnSelect;
        private readonly SimpleButton btnRefresh;
        private readonly LabelControl lblCount = new();

        public frmPurchaseOrderSelect()
        {
            gridView1 = new GridView(gridControl1);
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.Add(gridView1);

            btnSelect = MakeButton("اختيار", true);
            btnRefresh = MakeButton("تحديث");

            BuildLayout();
            ConfigureColumns();
            WireEvents();

            Text = "اختيار أمر شراء";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }

        // ── Layout ────────────────────────────────────────────────────────────
        private void BuildLayout()
        {
            Size = new Size(760, 520);
            StartPosition = FormStartPosition.CenterParent;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Font = new Font("Cairo", 8.5f);

            var pnlTop = new PanelControl { Dock = DockStyle.Top, Height = 44 };
            var lblSearch = new LabelControl { Text = "بحث:", Location = new Point(700, 14) };
            txtSearch.Location = new Point(410, 10);
            txtSearch.Size = new Size(280, 26);
            btnRefresh.Location = new Point(300, 8);
            pnlTop.Controls.Add(lblSearch);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(btnRefresh);

            var pnlBottom = new PanelControl { Dock = DockStyle.Bottom, Height = 44 };
            lblCount.Location = new Point(20, 14);
            btnSelect.Location = new Point(650, 8);
            pnlBottom.Controls.Add(lblCount);
            pnlBottom.Controls.Add(btnSelect);

            gridControl1.Dock = DockStyle.Fill;
            gridControl1.MainView = gridView1;

            Controls.Add(gridControl1);
            Controls.Add(pnlTop);
            Controls.Add(pnlBottom);
        }

        private static SimpleButton MakeButton(string text, bool primary = false)
        {
            var b = new SimpleButton { Text = text, Width = 90, Height = 28, Top = 8 };
            DesignSystem.ApplyButtonStyle(b, primary);
            return b;
        }

        private void ConfigureColumns()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsBehavior.AutoPopulateColumns = false;

            var colNum = gridView1.Columns.AddField("FormattedNum");
            colNum.Caption = "رقم أمر الشراء";
            colNum.VisibleIndex = 0;
            colNum.Visible = true;
            colNum.Width = 130;
            colNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colNum.AppearanceCell.Options.UseTextOptions = true;

            var colDate = gridView1.Columns.AddField("OrderDate");
            colDate.Caption = "تاريخ الأمر";
            colDate.VisibleIndex = 1;
            colDate.Visible = true;
            colDate.Width = 110;
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            colDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colDate.AppearanceCell.Options.UseTextOptions = true;

            var colDescrp = gridView1.Columns.AddField("Description");
            colDescrp.Caption = "الوصف";
            colDescrp.VisibleIndex = 2;
            colDescrp.Visible = true;
            colDescrp.Width = 350;
        }

        private void WireEvents()
        {
            gridView1.DoubleClick += (s, e) => ConfirmSelection();
            btnSelect.Click += (s, e) => ConfirmSelection();
            btnRefresh.Click += (s, e) => LoadData();
            txtSearch.EditValueChanged += (s, e) => ApplyFilter(txtSearch.Text);
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                _allPOs = dc.PurchaseOrderList
                    .GetBy("IsDelete = 0 AND OverallStatus = @s", new { s = PurchaseOrderStatus.Approved })
                    .Where(po => PurchaseOrderReceiveProgress.HasRemainingItems(dc, po.Id))
                    .OrderByDescending(po => po.OrderDate)
                    .ToList();

                foreach (var po in _allPOs)
                    po.FormattedNum = PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate);

                ApplyFilter(txtSearch.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل أوامر الشراء: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void ApplyFilter(string? term)
        {
            term = term?.Trim();
            var filtered = string.IsNullOrEmpty(term)
                ? _allPOs
                : _allPOs.Where(p =>
                    (p.FormattedNum?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (p.Description?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            gridControl1.DataSource = new BindingList<PurchaseOrderList>(filtered);
            lblCount.Text = $"عدد السجلات : {filtered.Count}";
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not PurchaseOrderList po)
            {
                XtraMessageBox.Show("يرجى اختيار أمر شراء.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedPO = po;
            DialogResult = DialogResult.OK;
            Close();
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
