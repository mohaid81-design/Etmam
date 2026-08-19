namespace Etmam
{
    partial class frmPriceQuotationSelect
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiSelect = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            bar3 = new DevExpress.XtraBars.Bar();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuotationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            //
            // svgImageCollection1
            //
            svgImageCollection1.Add("apply", "image://svgimages/icon builder/actions_check.svg");
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            //
            // barManager1
            //
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiSelect, bbiRefresh, barEditItem1, barStaticItem1 });
            barManager1.MaxItemId = 4;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemSearchControl1 });
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            //
            // bar1
            //
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSelect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(barEditItem1)
            });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            //
            // bbiSelect
            //
            bbiSelect.Caption = "اختيار";
            bbiSelect.Id = 0;
            bbiSelect.ImageOptions.ImageIndex = 0;
            bbiSelect.Name = "bbiSelect";
            //
            // bbiRefresh
            //
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 1;
            bbiRefresh.ImageOptions.ImageIndex = 1;
            bbiRefresh.Name = "bbiRefresh";
            //
            // barEditItem1
            //
            barEditItem1.Caption = "بحث";
            barEditItem1.Edit = repositoryItemSearchControl1;
            barEditItem1.EditHeight = 20;
            barEditItem1.EditWidth = 220;
            barEditItem1.Id = 2;
            barEditItem1.Name = "barEditItem1";
            //
            // repositoryItemSearchControl1
            //
            repositoryItemSearchControl1.AutoHeight = false;
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            repositoryItemSearchControl1.NullValuePrompt = " ";
            //
            // bar3
            //
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barStaticItem1) });
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            //
            // barStaticItem1
            //
            barStaticItem1.Caption = "عدد السجلات : 0";
            barStaticItem1.Id = 3;
            barStaticItem1.Name = "barStaticItem1";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(700, 30);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 428);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(700, 22);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 398);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(700, 30);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 398);
            //
            // gridControl1
            //
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 30);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(700, 398);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            //
            // gridView1
            //
            gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(30, 70, 130);
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8.5F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNum, colSupplierName, colQuotationDate, colAmount });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            //
            // colNum
            //
            colNum.AppearanceCell.Options.UseTextOptions = true;
            colNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colNum.Caption = "رقم العرض";
            colNum.FieldName = "Num";
            colNum.MinWidth = 25;
            colNum.Name = "colNum";
            colNum.Visible = true;
            colNum.VisibleIndex = 0;
            colNum.Width = 110;
            //
            // colSupplierName
            //
            colSupplierName.Caption = "المورد";
            colSupplierName.FieldName = "SupplierName";
            colSupplierName.MinWidth = 25;
            colSupplierName.Name = "colSupplierName";
            colSupplierName.Visible = true;
            colSupplierName.VisibleIndex = 1;
            colSupplierName.Width = 250;
            //
            // colQuotationDate
            //
            colQuotationDate.AppearanceCell.Options.UseTextOptions = true;
            colQuotationDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colQuotationDate.Caption = "تاريخ العرض";
            colQuotationDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            colQuotationDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colQuotationDate.FieldName = "QuotationDate";
            colQuotationDate.MinWidth = 25;
            colQuotationDate.Name = "colQuotationDate";
            colQuotationDate.Visible = true;
            colQuotationDate.VisibleIndex = 2;
            colQuotationDate.Width = 110;
            //
            // colAmount
            //
            colAmount.AppearanceCell.Options.UseTextOptions = true;
            colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colAmount.Caption = "القيمة";
            colAmount.DisplayFormat.FormatString = "n2";
            colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmount.FieldName = "Amount";
            colAmount.MinWidth = 25;
            colAmount.Name = "colAmount";
            colAmount.Visible = true;
            colAmount.VisibleIndex = 3;
            colAmount.Width = 130;
            //
            // frmPriceQuotationSelect
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 450);
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new System.Drawing.Font("Cairo", 8.5F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPriceQuotationSelect";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "اختيار عرض السعر";
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiSelect;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNum;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn colQuotationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
    }
}
