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
    /// <summary>Modal picker for choosing a Material Receive voucher that still has at least one line not
    /// yet fully returned to the supplier — same list/search/select pattern as frmPurchaseOrderSelect, one
    /// step further down the chain (Receive → Return). Opened from frmPurchaseReturnAddEdit.btnMaterialReceived.</summary>
    public class frmMaterialReceiveSelect : XtraForm
    {
        private static DataContext dc => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public MaterialReceiveList? SelectedReceive { get; private set; }

        private List<MaterialReceiveList> _allReceives = new();

        private readonly TextEdit txtSearch = new();
        private readonly GridControl gridControl1 = new();
        private readonly GridView gridView1;
        private readonly SimpleButton btnSelect;
        private readonly SimpleButton btnRefresh;
        private readonly LabelControl lblCount = new();

        public frmMaterialReceiveSelect()
        {
            gridView1 = new GridView(gridControl1);
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.Add(gridView1);

            btnSelect = MakeButton("اختيار", true);
            btnRefresh = MakeButton("تحديث");

            BuildLayout();
            ConfigureColumns();
            WireEvents();

            Text = "اختيار إذن استلام";
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
            colNum.Caption = "رقم إذن الاستلام";
            colNum.VisibleIndex = 0;
            colNum.Visible = true;
            colNum.Width = 130;
            colNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colNum.AppearanceCell.Options.UseTextOptions = true;

            var colDate = gridView1.Columns.AddField("ReceivedDate");
            colDate.Caption = "تاريخ الاستلام";
            colDate.VisibleIndex = 1;
            colDate.Visible = true;
            colDate.Width = 110;
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            colDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colDate.AppearanceCell.Options.UseTextOptions = true;

            var colVoucher = gridView1.Columns.AddField("VoucherNo");
            colVoucher.Caption = "رقم مستند الوارد";
            colVoucher.VisibleIndex = 2;
            colVoucher.Visible = true;
            colVoucher.Width = 150;

            var colDescrp = gridView1.Columns.AddField("Description");
            colDescrp.Caption = "الوصف";
            colDescrp.VisibleIndex = 3;
            colDescrp.Visible = true;
            colDescrp.Width = 250;
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
                _allReceives = dc.MaterialReceiveList
                    .GetBy("IsDelete = 0")
                    .Where(mr => MaterialReceiveReturnProgress.HasRemainingItems(dc, mr.Id))
                    .OrderByDescending(mr => mr.ReceivedDate)
                    .ToList();

                foreach (var mr in _allReceives)
                    mr.FormattedNum = MaterialReceivePrinter.FormatReceiveNumber(mr.Num, mr.ReceivedDate);

                ApplyFilter(txtSearch.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل أذونات الاستلام: {ex.Message}", "خطأ",
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
                ? _allReceives
                : _allReceives.Where(r =>
                    (r.Num?.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (r.FormattedNum?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (r.VoucherNo?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (r.Description?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            gridControl1.DataSource = new BindingList<MaterialReceiveList>(filtered);
            lblCount.Text = $"عدد السجلات : {filtered.Count}";
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not MaterialReceiveList mr)
            {
                XtraMessageBox.Show("يرجى اختيار إذن استلام.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedReceive = mr;
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
