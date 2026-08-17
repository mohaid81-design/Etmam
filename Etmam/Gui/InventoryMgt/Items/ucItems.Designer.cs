namespace Etmam
{
    partial class ucItems
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdSort = new DevExpress.XtraGrid.Columns.GridColumn();
            colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colName = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            lookUpUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ColCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            lookUpCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colBeginningQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPurchasedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPurchaseReturnsQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colTransfareFromOtherStoreQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colAddQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeficitSettlementQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colIssuedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colIssuedReturnsQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalanceQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPurchasedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colTotalReceivedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colIssuedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalanceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colAddSettlementAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colAddSettlementQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeficitSettlementAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colTotalIssuedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colTotalReceivedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colTransfareFromOtherStoreAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colTransfareToOtherStoreAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colTransfareToOtherStoreQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colTotalIssuedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpUnit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpCategory).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("new", "image://svgimages/actions/new.svg");
            svgImageCollection1.Add("actions_edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("actions_delete", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("print", "image://svgimages/print/print.svg");
            svgImageCollection1.Add("actions_refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("task_1", "image://svgimages/outlook inspired/task.svg");
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiEdit, bbiDelete, bbiPrint, bbiRefresh, barEditItem1 });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 6;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemSearchControl1 });
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            // 
            // bar2
            // 
            bar2.BarAppearance.Disabled.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Disabled.Options.UseFont = true;
            bar2.BarAppearance.Hovered.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Hovered.Options.UseFont = true;
            bar2.BarAppearance.Normal.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Normal.Options.UseFont = true;
            bar2.BarAppearance.Pressed.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Pressed.Options.UseFont = true;
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(barEditItem1) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MinHeight = 30;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // bbiNew
            // 
            bbiNew.Caption = "جديد";
            bbiNew.Id = 0;
            bbiNew.ImageOptions.ImageIndex = 0;
            bbiNew.Name = "bbiNew";
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 1;
            bbiEdit.ImageOptions.ImageIndex = 1;
            bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 2;
            bbiDelete.ImageOptions.ImageIndex = 2;
            bbiDelete.Name = "bbiDelete";
            // 
            // bbiPrint
            // 
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 3;
            bbiPrint.ImageOptions.ImageIndex = 3;
            bbiPrint.Name = "bbiPrint";
            // 
            // bbiRefresh
            // 
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 4;
            bbiRefresh.ImageOptions.ImageIndex = 4;
            bbiRefresh.Name = "bbiRefresh";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "barEditItem1";
            barEditItem1.Edit = repositoryItemSearchControl1;
            barEditItem1.EditHeight = 20;
            barEditItem1.EditWidth = 200;
            barEditItem1.Id = 5;
            barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemSearchControl1
            // 
            repositoryItemSearchControl1.AutoHeight = false;
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            repositoryItemSearchControl1.Client = gridControl1;
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            repositoryItemSearchControl1.NullValuePrompt = " ";
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.EmbeddedNavigator.Margin = new Padding(3, 4, 3, 4);
            gridControl1.Location = new Point(0, 30);
            gridControl1.MainView = gridView1;
            gridControl1.Margin = new Padding(3, 4, 3, 4);
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { lookUpCategory, lookUpUnit, repositoryItemMemoEdit1 });
            gridControl1.Size = new Size(1300, 650);
            gridControl1.TabIndex = 5;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.GroupRow.BackColor = SystemColors.ControlDarkDark;
            gridView1.Appearance.GroupRow.Font = new Font("Cairo", 9F, FontStyle.Bold);
            gridView1.Appearance.GroupRow.FontStyleDelta = FontStyle.Bold;
            gridView1.Appearance.GroupRow.ForeColor = Color.White;
            gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            gridView1.Appearance.GroupRow.Options.UseFont = true;
            gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView1.Appearance.Row.Font = new Font("Cairo", 9F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.AppearancePrint.EvenRow.Font = new Font("Cairo", 9F);
            gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdSort, colCode, colName, colUnit, ColCategory, colCategoryCode, colDescription, colLastPrice, colBeginningQty, colPurchasedQty, colPurchaseReturnsQty, colTransfareFromOtherStoreQty, colAddQty, colDeficitSettlementQty, colIssuedQty, colIssuedReturnsQty, colBalanceQty, colPurchasedAmount, colTotalReceivedAmount, colIssuedAmount, colBalanceAmount, colId, colAddSettlementAmount, colAddSettlementQty, colDeficitSettlementAmount, colTotalIssuedQty, colTotalReceivedQty, colTransfareFromOtherStoreAmount, colTransfareToOtherStoreAmount, colTransfareToOtherStoreQty, colTotalIssuedAmount });
            gridView1.DetailHeight = 507;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridView1.GridControl = gridControl1;
            gridView1.GroupCount = 1;
            gridView1.GroupFormat = "{1}{2}";
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            gridView1.OptionsHint.ShowCellHints = false;
            gridView1.OptionsHint.ShowColumnHeaderHints = false;
            gridView1.OptionsHint.ShowFooterHints = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] { new DevExpress.XtraGrid.Columns.GridColumnSortInfo(ColCategory, DevExpress.Data.ColumnSortOrder.Ascending), new DevExpress.XtraGrid.Columns.GridColumnSortInfo(colIdSort, DevExpress.Data.ColumnSortOrder.Ascending) });
            // 
            // colIdSort
            // 
            colIdSort.Caption = "IdSub";
            colIdSort.FieldName = "IdSort";
            colIdSort.MinWidth = 25;
            colIdSort.Name = "colIdSort";
            colIdSort.Width = 94;
            // 
            // colCode
            // 
            colCode.AppearanceCell.Options.UseTextOptions = true;
            colCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCode.Caption = "كود الصنف";
            colCode.FieldName = "Code";
            colCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colCode.MinWidth = 25;
            colCode.Name = "colCode";
            colCode.Visible = true;
            colCode.VisibleIndex = 0;
            colCode.Width = 120;
            // 
            // colName
            // 
            colName.Caption = "إسم الصنف";
            colName.ColumnEdit = repositoryItemMemoEdit1;
            colName.FieldName = "Name";
            colName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colName.MinWidth = 25;
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 1;
            colName.Width = 262;
            // 
            // repositoryItemMemoEdit1
            // 
            repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colUnit
            // 
            colUnit.AppearanceCell.Options.UseTextOptions = true;
            colUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colUnit.Caption = "الوحده";
            colUnit.ColumnEdit = lookUpUnit;
            colUnit.FieldName = "UnitId";
            colUnit.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colUnit.MinWidth = 25;
            colUnit.Name = "colUnit";
            colUnit.Visible = true;
            colUnit.VisibleIndex = 2;
            colUnit.Width = 100;
            // 
            // lookUpUnit
            // 
            lookUpUnit.AutoHeight = false;
            lookUpUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpUnit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbreviation", "Name1") });
            lookUpUnit.Name = "lookUpUnit";
            lookUpUnit.NullText = "";
            // 
            // ColCategory
            // 
            ColCategory.ColumnEdit = lookUpCategory;
            ColCategory.FieldName = "CategoryId";
            ColCategory.MinWidth = 25;
            ColCategory.Name = "ColCategory";
            ColCategory.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            ColCategory.Visible = true;
            ColCategory.VisibleIndex = 4;
            ColCategory.Width = 120;
            // 
            // lookUpCategory
            // 
            lookUpCategory.AutoHeight = false;
            lookUpCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpCategory.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Name1"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2") });
            lookUpCategory.DisplayMember = "DisplayText";
            lookUpCategory.Name = "lookUpCategory";
            lookUpCategory.NullText = "";
            lookUpCategory.ValueMember = "Id";
            // 
            // colCategoryCode
            // 
            colCategoryCode.AppearanceCell.Options.UseTextOptions = true;
            colCategoryCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCategoryCode.Caption = "كود التصنيف";
            colCategoryCode.FieldName = "CategoryCode";
            colCategoryCode.MinWidth = 25;
            colCategoryCode.Name = "colCategoryCode";
            colCategoryCode.Width = 110;
            // 
            // colDescription
            // 
            colDescription.Caption = "الوصف";
            colDescription.ColumnEdit = repositoryItemMemoEdit1;
            colDescription.FieldName = "Description";
            colDescription.MinWidth = 25;
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 3;
            colDescription.Width = 344;
            // 
            // colLastPrice
            // 
            colLastPrice.AppearanceCell.Options.UseTextOptions = true;
            colLastPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colLastPrice.Caption = "اخر سعر شراء";
            colLastPrice.DisplayFormat.FormatString = "n2";
            colLastPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colLastPrice.FieldName = "LastPrice";
            colLastPrice.MinWidth = 25;
            colLastPrice.Name = "colLastPrice";
            colLastPrice.Width = 100;
            // 
            // colBeginningQty
            // 
            colBeginningQty.AppearanceCell.Options.UseTextOptions = true;
            colBeginningQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colBeginningQty.Caption = "كميه اول المدة";
            colBeginningQty.DisplayFormat.FormatString = "n2";
            colBeginningQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBeginningQty.FieldName = "BeginningQty";
            colBeginningQty.MinWidth = 25;
            colBeginningQty.Name = "colBeginningQty";
            colBeginningQty.Width = 100;
            // 
            // colPurchasedQty
            // 
            colPurchasedQty.AppearanceCell.Options.UseTextOptions = true;
            colPurchasedQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPurchasedQty.Caption = "كميه المشتريات";
            colPurchasedQty.DisplayFormat.FormatString = "n2";
            colPurchasedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPurchasedQty.FieldName = "PurchasedQty";
            colPurchasedQty.MinWidth = 25;
            colPurchasedQty.Name = "colPurchasedQty";
            colPurchasedQty.Width = 100;
            // 
            // colPurchaseReturnsQty
            // 
            colPurchaseReturnsQty.AppearanceCell.Options.UseTextOptions = true;
            colPurchaseReturnsQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPurchaseReturnsQty.Caption = "مرتجع المشتريات";
            colPurchaseReturnsQty.DisplayFormat.FormatString = "n2";
            colPurchaseReturnsQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPurchaseReturnsQty.FieldName = "PurchaseReturnsQty";
            colPurchaseReturnsQty.MinWidth = 25;
            colPurchaseReturnsQty.Name = "colPurchaseReturnsQty";
            colPurchaseReturnsQty.Width = 100;
            // 
            // colTransfareFromOtherStoreQty
            // 
            colTransfareFromOtherStoreQty.AppearanceCell.Options.UseTextOptions = true;
            colTransfareFromOtherStoreQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colTransfareFromOtherStoreQty.Caption = "كميه التحويل من مخزن آخر";
            colTransfareFromOtherStoreQty.DisplayFormat.FormatString = "n2";
            colTransfareFromOtherStoreQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTransfareFromOtherStoreQty.FieldName = "TransfareFromOtherStoreQty";
            colTransfareFromOtherStoreQty.MinWidth = 25;
            colTransfareFromOtherStoreQty.Name = "colTransfareFromOtherStoreQty";
            colTransfareFromOtherStoreQty.Width = 100;
            // 
            // colAddQty
            // 
            colAddQty.AppearanceCell.Options.UseTextOptions = true;
            colAddQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colAddQty.Caption = "كميه إضافة";
            colAddQty.DisplayFormat.FormatString = "n2";
            colAddQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAddQty.FieldName = "AddQty";
            colAddQty.MinWidth = 25;
            colAddQty.Name = "colAddQty";
            colAddQty.Width = 100;
            // 
            // colDeficitSettlementQty
            // 
            colDeficitSettlementQty.AppearanceCell.Options.UseTextOptions = true;
            colDeficitSettlementQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colDeficitSettlementQty.Caption = "كميه تسويه العجز";
            colDeficitSettlementQty.DisplayFormat.FormatString = "n2";
            colDeficitSettlementQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDeficitSettlementQty.FieldName = "DeficitSettlementQty";
            colDeficitSettlementQty.MinWidth = 25;
            colDeficitSettlementQty.Name = "colDeficitSettlementQty";
            colDeficitSettlementQty.Width = 100;
            // 
            // colIssuedQty
            // 
            colIssuedQty.AppearanceCell.Options.UseTextOptions = true;
            colIssuedQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colIssuedQty.Caption = "كميه الصرف";
            colIssuedQty.DisplayFormat.FormatString = "n2";
            colIssuedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colIssuedQty.FieldName = "IssuedQty";
            colIssuedQty.MinWidth = 25;
            colIssuedQty.Name = "colIssuedQty";
            colIssuedQty.Width = 100;
            // 
            // colIssuedReturnsQty
            // 
            colIssuedReturnsQty.AppearanceCell.Options.UseTextOptions = true;
            colIssuedReturnsQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colIssuedReturnsQty.Caption = "مرتجع الصرف";
            colIssuedReturnsQty.DisplayFormat.FormatString = "n2";
            colIssuedReturnsQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colIssuedReturnsQty.FieldName = "IssuedReturnsQty";
            colIssuedReturnsQty.MinWidth = 25;
            colIssuedReturnsQty.Name = "colIssuedReturnsQty";
            colIssuedReturnsQty.Width = 100;
            // 
            // colBalanceQty
            // 
            colBalanceQty.AppearanceCell.Options.UseTextOptions = true;
            colBalanceQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colBalanceQty.Caption = "رصيد الكميات";
            colBalanceQty.DisplayFormat.FormatString = "n2";
            colBalanceQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBalanceQty.FieldName = "BalanceQty";
            colBalanceQty.MinWidth = 25;
            colBalanceQty.Name = "colBalanceQty";
            colBalanceQty.Width = 100;
            // 
            // colPurchasedAmount
            // 
            colPurchasedAmount.AppearanceCell.Options.UseTextOptions = true;
            colPurchasedAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPurchasedAmount.Caption = "إجمالي قيمة المشتريات";
            colPurchasedAmount.DisplayFormat.FormatString = "n2";
            colPurchasedAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPurchasedAmount.FieldName = "PurchasedAmount";
            colPurchasedAmount.MinWidth = 25;
            colPurchasedAmount.Name = "colPurchasedAmount";
            colPurchasedAmount.Width = 100;
            // 
            // colTotalReceivedAmount
            // 
            colTotalReceivedAmount.AppearanceCell.Options.UseTextOptions = true;
            colTotalReceivedAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colTotalReceivedAmount.Caption = "إجمالي قيمه إذونات الإضافه";
            colTotalReceivedAmount.DisplayFormat.FormatString = "n2";
            colTotalReceivedAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTotalReceivedAmount.FieldName = "TotalReceivedAmount";
            colTotalReceivedAmount.MinWidth = 25;
            colTotalReceivedAmount.Name = "colTotalReceivedAmount";
            colTotalReceivedAmount.Width = 100;
            // 
            // colIssuedAmount
            // 
            colIssuedAmount.AppearanceCell.Options.UseTextOptions = true;
            colIssuedAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colIssuedAmount.Caption = "اجمالي قيمه الصرف";
            colIssuedAmount.DisplayFormat.FormatString = "n2";
            colIssuedAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colIssuedAmount.FieldName = "IssuedAmount";
            colIssuedAmount.MinWidth = 25;
            colIssuedAmount.Name = "colIssuedAmount";
            colIssuedAmount.Width = 100;
            // 
            // colBalanceAmount
            // 
            colBalanceAmount.AppearanceCell.Options.UseTextOptions = true;
            colBalanceAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colBalanceAmount.Caption = "الرصيد";
            colBalanceAmount.DisplayFormat.FormatString = "n2";
            colBalanceAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBalanceAmount.FieldName = "BalanceAmount";
            colBalanceAmount.MinWidth = 25;
            colBalanceAmount.Name = "colBalanceAmount";
            colBalanceAmount.Width = 100;
            // 
            // colId
            // 
            colId.Caption = "Id";
            colId.FieldName = "Id";
            colId.MinWidth = 25;
            colId.Name = "colId";
            colId.Width = 94;
            // 
            // colAddSettlementAmount
            // 
            colAddSettlementAmount.Caption = "قيمة تسوية الزيادة";
            colAddSettlementAmount.FieldName = "AddSettlementAmount";
            colAddSettlementAmount.Name = "colAddSettlementAmount";
            // 
            // colAddSettlementQty
            // 
            colAddSettlementQty.Caption = "كمية تسوية الزيادة";
            colAddSettlementQty.FieldName = "AddSettlementQty";
            colAddSettlementQty.Name = "colAddSettlementQty";
            // 
            // colDeficitSettlementAmount
            // 
            colDeficitSettlementAmount.Caption = "قيمة تسوية العجز";
            colDeficitSettlementAmount.FieldName = "DeficitSettlementAmount";
            colDeficitSettlementAmount.Name = "colDeficitSettlementAmount";
            // 
            // colTotalIssuedQty
            // 
            colTotalIssuedQty.FieldName = "TotalIssuedQty";
            colTotalIssuedQty.Name = "colTotalIssuedQty";
            // 
            // colTotalReceivedQty
            // 
            colTotalReceivedQty.FieldName = "TotalReceivedQty";
            colTotalReceivedQty.Name = "colTotalReceivedQty";
            // 
            // colTransfareFromOtherStoreAmount
            // 
            colTransfareFromOtherStoreAmount.FieldName = "TransfareFromOtherStoreAmount";
            colTransfareFromOtherStoreAmount.Name = "colTransfareFromOtherStoreAmount";
            // 
            // colTransfareToOtherStoreAmount
            // 
            colTransfareToOtherStoreAmount.FieldName = "TransfareToOtherStoreAmount";
            colTransfareToOtherStoreAmount.Name = "colTransfareToOtherStoreAmount";
            // 
            // colTransfareToOtherStoreQty
            // 
            colTransfareToOtherStoreQty.FieldName = "TransfareToOtherStoreQty";
            colTransfareToOtherStoreQty.Name = "colTransfareToOtherStoreQty";
            // 
            // colTotalIssuedAmount
            // 
            colTotalIssuedAmount.FieldName = "TotalIssuedAmount";
            colTotalIssuedAmount.Name = "colTotalIssuedAmount";
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1300, 30);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 680);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1300, 20);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 30);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 650);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1300, 30);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 650);
            // 
            // ucItems
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucItems";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpUnit).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpUnit;
        private DevExpress.XtraGrid.Columns.GridColumn ColCategory;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colBeginningQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchasedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseReturnsQty;
        private DevExpress.XtraGrid.Columns.GridColumn colTransfareFromOtherStoreQty;
        private DevExpress.XtraGrid.Columns.GridColumn colAddQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDeficitSettlementQty;
        private DevExpress.XtraGrid.Columns.GridColumn colIssuedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colIssuedReturnsQty;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchasedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalReceivedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colIssuedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colIdSort;
        private DevExpress.XtraGrid.Columns.GridColumn colAddSettlementAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colAddSettlementQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDeficitSettlementAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalIssuedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalReceivedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colTransfareFromOtherStoreAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTransfareToOtherStoreAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTransfareToOtherStoreQty;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalIssuedAmount;
    }
}
