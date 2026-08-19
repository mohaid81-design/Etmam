using System.Drawing;
using System.Windows.Forms;

namespace Etmam
{
    partial class ucInventoryReports
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
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiRun = new DevExpress.XtraBars.BarButtonItem();
            bbiClearFilter = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPageBalance = new DevExpress.XtraTab.XtraTabPage();
            gridControlSB = new DevExpress.XtraGrid.GridControl();
            gridViewSB = new DevExpress.XtraGrid.Views.Grid.GridView();
            colSBItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colSBItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            colSBCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            colSBStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            colSBUnitAbbr = new DevExpress.XtraGrid.Columns.GridColumn();
            colSBBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlFiltersSB = new DevExpress.XtraEditors.PanelControl();
            checkEditSBHideZero = new DevExpress.XtraEditors.CheckEdit();
            lookUpEditSBItem = new DevExpress.XtraEditors.LookUpEdit();
            labelControlSB3 = new DevExpress.XtraEditors.LabelControl();
            lookUpEditSBCategory = new DevExpress.XtraEditors.LookUpEdit();
            labelControlSB2 = new DevExpress.XtraEditors.LabelControl();
            lookUpEditSBStore = new DevExpress.XtraEditors.LookUpEdit();
            labelControlSB1 = new DevExpress.XtraEditors.LabelControl();
            xtraTabPageStockCard = new DevExpress.XtraTab.XtraTabPage();
            gridControlSC = new DevExpress.XtraGrid.GridControl();
            gridViewSC = new DevExpress.XtraGrid.Views.Grid.GridView();
            colSCMovementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colSCMovementType = new DevExpress.XtraGrid.Columns.GridColumn();
            colSCDocumentNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colSCCounterpartyStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            colSCQtyIn = new DevExpress.XtraGrid.Columns.GridColumn();
            colSCQtyOut = new DevExpress.XtraGrid.Columns.GridColumn();
            colSCRunningBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            colSCNote = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlFiltersSC = new DevExpress.XtraEditors.PanelControl();
            lookUpEditSCStore = new DevExpress.XtraEditors.LookUpEdit();
            labelControlSC2 = new DevExpress.XtraEditors.LabelControl();
            lookUpEditSCItem = new DevExpress.XtraEditors.LookUpEdit();
            labelControlSC1 = new DevExpress.XtraEditors.LabelControl();
            xtraTabPagePeriodMovement = new DevExpress.XtraTab.XtraTabPage();
            gridControlPM = new DevExpress.XtraGrid.GridControl();
            gridViewPM = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPMItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMUnitAbbr = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMOpeningQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMReceivedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMIssuedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMTransferInQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMTransferOutQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMPurchaseReturnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMIssueReturnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colPMClosingQty = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlFiltersPM = new DevExpress.XtraEditors.PanelControl();
            checkEditPMHideNoActivity = new DevExpress.XtraEditors.CheckEdit();
            checkEditPMPerStore = new DevExpress.XtraEditors.CheckEdit();
            lookUpEditPMItem = new DevExpress.XtraEditors.LookUpEdit();
            labelControlPM5 = new DevExpress.XtraEditors.LabelControl();
            lookUpEditPMCategory = new DevExpress.XtraEditors.LookUpEdit();
            labelControlPM4 = new DevExpress.XtraEditors.LabelControl();
            lookUpEditPMStore = new DevExpress.XtraEditors.LookUpEdit();
            labelControlPM3 = new DevExpress.XtraEditors.LabelControl();
            dateEditPMTo = new DevExpress.XtraEditors.DateEdit();
            labelControlPM2 = new DevExpress.XtraEditors.LabelControl();
            dateEditPMFrom = new DevExpress.XtraEditors.DateEdit();
            labelControlPM1 = new DevExpress.XtraEditors.LabelControl();
            xtraTabPageStockingVariance = new DevExpress.XtraTab.XtraTabPage();
            gridControlSV = new DevExpress.XtraGrid.GridControl();
            gridViewSV = new DevExpress.XtraGrid.Views.Grid.GridView();
            colSVStockingNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVStockingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVUnitAbbr = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVSystemQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVDifference = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVDifferenceValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colSVNote = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlFiltersSV = new DevExpress.XtraEditors.PanelControl();
            dateEditSVTo = new DevExpress.XtraEditors.DateEdit();
            labelControlSV3 = new DevExpress.XtraEditors.LabelControl();
            dateEditSVFrom = new DevExpress.XtraEditors.DateEdit();
            labelControlSV2 = new DevExpress.XtraEditors.LabelControl();
            lookUpEditSVStore = new DevExpress.XtraEditors.LookUpEdit();
            labelControlSV1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            xtraTabPageBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlSB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFiltersSB).BeginInit();
            pnlFiltersSB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkEditSBHideZero.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSBItem.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSBCategory.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSBStore.Properties).BeginInit();
            xtraTabPageStockCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlSC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFiltersSC).BeginInit();
            pnlFiltersSC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSCStore.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSCItem.Properties).BeginInit();
            xtraTabPagePeriodMovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlPM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFiltersPM).BeginInit();
            pnlFiltersPM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkEditPMHideNoActivity.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEditPMPerStore.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditPMItem.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditPMCategory.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditPMStore.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditPMTo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditPMTo.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditPMFrom.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditPMFrom.Properties.CalendarTimeProperties).BeginInit();
            xtraTabPageStockingVariance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlSV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFiltersSV).BeginInit();
            pnlFiltersSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dateEditSVTo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditSVTo.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditSVFrom.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditSVFrom.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSVStore.Properties).BeginInit();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiRun, bbiClearFilter, bbiPrint, bbiExportExcel });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 4;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbiRun), new DevExpress.XtraBars.LinkPersistInfo(bbiClearFilter), new DevExpress.XtraBars.LinkPersistInfo(bbiPrint), new DevExpress.XtraBars.LinkPersistInfo(bbiExportExcel) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // bbiRun
            // 
            bbiRun.Caption = "تحديث / عرض";
            bbiRun.Id = 0;
            bbiRun.Name = "bbiRun";
            //
            // bbiClearFilter
            //
            bbiClearFilter.Caption = "مسح الفلتر";
            bbiClearFilter.Id = 3;
            bbiClearFilter.Name = "bbiClearFilter";
            //
            // bbiPrint
            //
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 1;
            bbiPrint.Name = "bbiPrint";
            //
            // bbiExportExcel
            //
            bbiExportExcel.Caption = "تصدير Excel";
            bbiExportExcel.Id = 2;
            bbiExportExcel.Name = "bbiExportExcel";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Margin = new Padding(3, 5, 3, 5);
            barDockControlTop.Size = new Size(1300, 31);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 720);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(1300, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 31);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 689);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1300, 31);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 689);
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.AppearancePage.Header.Font = new Font("Cairo", 9F);
            xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            xtraTabControl1.Dock = DockStyle.Fill;
            xtraTabControl1.Location = new Point(0, 31);
            xtraTabControl1.Margin = new Padding(3, 5, 3, 5);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPageBalance;
            xtraTabControl1.Size = new Size(1300, 689);
            xtraTabControl1.TabIndex = 1;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPageBalance, xtraTabPageStockCard, xtraTabPagePeriodMovement, xtraTabPageStockingVariance });
            xtraTabControl1.TabPageWidth = 120;
            // 
            // xtraTabPageBalance
            // 
            xtraTabPageBalance.Controls.Add(gridControlSB);
            xtraTabPageBalance.Controls.Add(pnlFiltersSB);
            xtraTabPageBalance.Margin = new Padding(3, 5, 3, 5);
            xtraTabPageBalance.Name = "xtraTabPageBalance";
            xtraTabPageBalance.Size = new Size(1298, 653);
            xtraTabPageBalance.Text = "رصيد المخزون الحالي";
            // 
            // gridControlSB
            // 
            gridControlSB.Dock = DockStyle.Fill;
            gridControlSB.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            gridControlSB.Location = new Point(0, 128);
            gridControlSB.MainView = gridViewSB;
            gridControlSB.Margin = new Padding(3, 5, 3, 5);
            gridControlSB.Name = "gridControlSB";
            gridControlSB.Size = new Size(1298, 525);
            gridControlSB.TabIndex = 1;
            gridControlSB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewSB });
            // 
            // gridViewSB
            // 
            gridViewSB.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridViewSB.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gridViewSB.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridViewSB.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewSB.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewSB.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridViewSB.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridViewSB.Appearance.Row.Font = new Font("Cairo", 9F);
            gridViewSB.Appearance.Row.Options.UseFont = true;
            gridViewSB.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colSBItemCode, colSBItemName, colSBCategoryName, colSBStoreName, colSBUnitAbbr, colSBBalance });
            gridViewSB.DetailHeight = 538;
            gridViewSB.GridControl = gridControlSB;
            gridViewSB.Name = "gridViewSB";
            gridViewSB.OptionsBehavior.Editable = false;
            gridViewSB.OptionsView.ColumnAutoWidth = false;
            gridViewSB.OptionsView.ShowGroupPanel = false;
            // 
            // colSBItemCode
            // 
            colSBItemCode.AppearanceCell.Options.UseTextOptions = true;
            colSBItemCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSBItemCode.Caption = "رمز الصنف";
            colSBItemCode.FieldName = "ItemCode";
            colSBItemCode.Name = "colSBItemCode";
            colSBItemCode.Visible = true;
            colSBItemCode.VisibleIndex = 0;
            colSBItemCode.Width = 110;
            // 
            // colSBItemName
            // 
            colSBItemName.Caption = "اسم الصنف";
            colSBItemName.FieldName = "ItemName";
            colSBItemName.Name = "colSBItemName";
            colSBItemName.Visible = true;
            colSBItemName.VisibleIndex = 1;
            colSBItemName.Width = 260;
            // 
            // colSBCategoryName
            // 
            colSBCategoryName.Caption = "التصنيف";
            colSBCategoryName.FieldName = "CategoryName";
            colSBCategoryName.Name = "colSBCategoryName";
            colSBCategoryName.Visible = true;
            colSBCategoryName.VisibleIndex = 2;
            colSBCategoryName.Width = 160;
            // 
            // colSBStoreName
            // 
            colSBStoreName.Caption = "المخزن";
            colSBStoreName.FieldName = "StoreName";
            colSBStoreName.Name = "colSBStoreName";
            colSBStoreName.Visible = true;
            colSBStoreName.VisibleIndex = 3;
            colSBStoreName.Width = 160;
            // 
            // colSBUnitAbbr
            // 
            colSBUnitAbbr.AppearanceCell.Options.UseTextOptions = true;
            colSBUnitAbbr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSBUnitAbbr.Caption = "الوحدة";
            colSBUnitAbbr.FieldName = "UnitAbbr";
            colSBUnitAbbr.Name = "colSBUnitAbbr";
            colSBUnitAbbr.Visible = true;
            colSBUnitAbbr.VisibleIndex = 4;
            colSBUnitAbbr.Width = 70;
            // 
            // colSBBalance
            // 
            colSBBalance.AppearanceCell.Options.UseTextOptions = true;
            colSBBalance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSBBalance.Caption = "الرصيد";
            colSBBalance.DisplayFormat.FormatString = "n2";
            colSBBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSBBalance.FieldName = "Balance";
            colSBBalance.Name = "colSBBalance";
            colSBBalance.Visible = true;
            colSBBalance.VisibleIndex = 5;
            colSBBalance.Width = 120;
            // 
            // pnlFiltersSB
            // 
            pnlFiltersSB.Controls.Add(checkEditSBHideZero);
            pnlFiltersSB.Controls.Add(lookUpEditSBItem);
            pnlFiltersSB.Controls.Add(labelControlSB3);
            pnlFiltersSB.Controls.Add(lookUpEditSBCategory);
            pnlFiltersSB.Controls.Add(labelControlSB2);
            pnlFiltersSB.Controls.Add(lookUpEditSBStore);
            pnlFiltersSB.Controls.Add(labelControlSB1);
            pnlFiltersSB.Dock = DockStyle.Top;
            pnlFiltersSB.Location = new Point(0, 0);
            pnlFiltersSB.Margin = new Padding(3, 5, 3, 5);
            pnlFiltersSB.Name = "pnlFiltersSB";
            pnlFiltersSB.Size = new Size(1298, 128);
            pnlFiltersSB.TabIndex = 0;
            pnlFiltersSB.Paint += pnlFiltersSB_Paint;
            // 
            // checkEditSBHideZero
            // 
            checkEditSBHideZero.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkEditSBHideZero.Location = new Point(855, 18);
            checkEditSBHideZero.Margin = new Padding(3, 5, 3, 5);
            checkEditSBHideZero.Name = "checkEditSBHideZero";
            checkEditSBHideZero.Properties.Appearance.Font = new Font("Cairo", 9F);
            checkEditSBHideZero.Properties.Appearance.Options.UseFont = true;
            checkEditSBHideZero.Properties.Caption = "إخفاء الأرصدة الصفرية";
            checkEditSBHideZero.Size = new Size(160, 27);
            checkEditSBHideZero.TabIndex = 6;
            // 
            // lookUpEditSBItem
            // 
            lookUpEditSBItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditSBItem.Location = new Point(1021, 83);
            lookUpEditSBItem.Margin = new Padding(3, 5, 3, 5);
            lookUpEditSBItem.Name = "lookUpEditSBItem";
            lookUpEditSBItem.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditSBItem.Properties.Appearance.Options.UseFont = true;
            lookUpEditSBItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditSBItem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name3") });
            lookUpEditSBItem.Properties.NullText = "-- كل الأصناف --";
            lookUpEditSBItem.Size = new Size(210, 28);
            lookUpEditSBItem.TabIndex = 5;
            // 
            // labelControlSB3
            // 
            labelControlSB3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlSB3.Appearance.Font = new Font("Cairo", 9F);
            labelControlSB3.Appearance.Options.UseFont = true;
            labelControlSB3.Location = new Point(1241, 86);
            labelControlSB3.Margin = new Padding(3, 5, 3, 5);
            labelControlSB3.Name = "labelControlSB3";
            labelControlSB3.Size = new Size(36, 23);
            labelControlSB3.TabIndex = 4;
            labelControlSB3.Text = "الصنف:";
            // 
            // lookUpEditSBCategory
            // 
            lookUpEditSBCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditSBCategory.Location = new Point(1021, 49);
            lookUpEditSBCategory.Margin = new Padding(3, 5, 3, 5);
            lookUpEditSBCategory.Name = "lookUpEditSBCategory";
            lookUpEditSBCategory.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditSBCategory.Properties.Appearance.Options.UseFont = true;
            lookUpEditSBCategory.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditSBCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2") });
            lookUpEditSBCategory.Properties.NullText = "-- كل التصنيفات --";
            lookUpEditSBCategory.Size = new Size(210, 28);
            lookUpEditSBCategory.TabIndex = 3;
            // 
            // labelControlSB2
            // 
            labelControlSB2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlSB2.Appearance.Font = new Font("Cairo", 9F);
            labelControlSB2.Appearance.Options.UseFont = true;
            labelControlSB2.Location = new Point(1241, 52);
            labelControlSB2.Margin = new Padding(3, 5, 3, 5);
            labelControlSB2.Name = "labelControlSB2";
            labelControlSB2.Size = new Size(44, 23);
            labelControlSB2.TabIndex = 2;
            labelControlSB2.Text = "التصنيف:";
            // 
            // lookUpEditSBStore
            // 
            lookUpEditSBStore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditSBStore.Location = new Point(1021, 17);
            lookUpEditSBStore.Margin = new Padding(3, 5, 3, 5);
            lookUpEditSBStore.Name = "lookUpEditSBStore";
            lookUpEditSBStore.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditSBStore.Properties.Appearance.Options.UseFont = true;
            lookUpEditSBStore.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditSBStore.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1") });
            lookUpEditSBStore.Properties.NullText = "-- كل المخازن المصرَّحة --";
            lookUpEditSBStore.Size = new Size(210, 28);
            lookUpEditSBStore.TabIndex = 1;
            // 
            // labelControlSB1
            // 
            labelControlSB1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlSB1.Appearance.Font = new Font("Cairo", 9F);
            labelControlSB1.Appearance.Options.UseFont = true;
            labelControlSB1.Location = new Point(1241, 20);
            labelControlSB1.Margin = new Padding(3, 5, 3, 5);
            labelControlSB1.Name = "labelControlSB1";
            labelControlSB1.Size = new Size(36, 23);
            labelControlSB1.TabIndex = 0;
            labelControlSB1.Text = "المخزن:";
            // 
            // xtraTabPageStockCard
            // 
            xtraTabPageStockCard.Controls.Add(gridControlSC);
            xtraTabPageStockCard.Controls.Add(pnlFiltersSC);
            xtraTabPageStockCard.Margin = new Padding(3, 5, 3, 5);
            xtraTabPageStockCard.Name = "xtraTabPageStockCard";
            xtraTabPageStockCard.Size = new Size(1298, 653);
            xtraTabPageStockCard.Text = "كارت الصنف";
            // 
            // gridControlSC
            // 
            gridControlSC.Dock = DockStyle.Fill;
            gridControlSC.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            gridControlSC.Location = new Point(0, 128);
            gridControlSC.MainView = gridViewSC;
            gridControlSC.Margin = new Padding(3, 5, 3, 5);
            gridControlSC.Name = "gridControlSC";
            gridControlSC.Size = new Size(1298, 525);
            gridControlSC.TabIndex = 1;
            gridControlSC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewSC });
            // 
            // gridViewSC
            // 
            gridViewSC.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridViewSC.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gridViewSC.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridViewSC.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewSC.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewSC.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridViewSC.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridViewSC.Appearance.Row.Font = new Font("Cairo", 9F);
            gridViewSC.Appearance.Row.Options.UseFont = true;
            gridViewSC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colSCMovementDate, colSCMovementType, colSCDocumentNum, colSCCounterpartyStoreName, colSCQtyIn, colSCQtyOut, colSCRunningBalance, colSCNote });
            gridViewSC.DetailHeight = 538;
            gridViewSC.GridControl = gridControlSC;
            gridViewSC.Name = "gridViewSC";
            gridViewSC.OptionsBehavior.Editable = false;
            gridViewSC.OptionsView.ColumnAutoWidth = false;
            gridViewSC.OptionsView.ShowGroupPanel = false;
            // 
            // colSCMovementDate
            // 
            colSCMovementDate.AppearanceCell.Options.UseTextOptions = true;
            colSCMovementDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSCMovementDate.Caption = "التاريخ";
            colSCMovementDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            colSCMovementDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colSCMovementDate.FieldName = "MovementDate";
            colSCMovementDate.Name = "colSCMovementDate";
            colSCMovementDate.Visible = true;
            colSCMovementDate.VisibleIndex = 0;
            colSCMovementDate.Width = 100;
            // 
            // colSCMovementType
            // 
            colSCMovementType.Caption = "نوع الحركة";
            colSCMovementType.FieldName = "MovementType";
            colSCMovementType.Name = "colSCMovementType";
            colSCMovementType.Visible = true;
            colSCMovementType.VisibleIndex = 1;
            colSCMovementType.Width = 130;
            // 
            // colSCDocumentNum
            // 
            colSCDocumentNum.AppearanceCell.Options.UseTextOptions = true;
            colSCDocumentNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSCDocumentNum.Caption = "رقم المستند";
            colSCDocumentNum.FieldName = "DocumentNum";
            colSCDocumentNum.Name = "colSCDocumentNum";
            colSCDocumentNum.Visible = true;
            colSCDocumentNum.VisibleIndex = 2;
            colSCDocumentNum.Width = 100;
            // 
            // colSCCounterpartyStoreName
            // 
            colSCCounterpartyStoreName.Caption = "المخزن الآخر";
            colSCCounterpartyStoreName.FieldName = "CounterpartyStoreName";
            colSCCounterpartyStoreName.Name = "colSCCounterpartyStoreName";
            colSCCounterpartyStoreName.Visible = true;
            colSCCounterpartyStoreName.VisibleIndex = 3;
            colSCCounterpartyStoreName.Width = 150;
            // 
            // colSCQtyIn
            // 
            colSCQtyIn.AppearanceCell.Options.UseTextOptions = true;
            colSCQtyIn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSCQtyIn.Caption = "وارد";
            colSCQtyIn.DisplayFormat.FormatString = "n2";
            colSCQtyIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSCQtyIn.FieldName = "QtyIn";
            colSCQtyIn.Name = "colSCQtyIn";
            colSCQtyIn.Visible = true;
            colSCQtyIn.VisibleIndex = 4;
            colSCQtyIn.Width = 90;
            // 
            // colSCQtyOut
            // 
            colSCQtyOut.AppearanceCell.Options.UseTextOptions = true;
            colSCQtyOut.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSCQtyOut.Caption = "صادر";
            colSCQtyOut.DisplayFormat.FormatString = "n2";
            colSCQtyOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSCQtyOut.FieldName = "QtyOut";
            colSCQtyOut.Name = "colSCQtyOut";
            colSCQtyOut.Visible = true;
            colSCQtyOut.VisibleIndex = 5;
            colSCQtyOut.Width = 90;
            // 
            // colSCRunningBalance
            // 
            colSCRunningBalance.AppearanceCell.Options.UseTextOptions = true;
            colSCRunningBalance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSCRunningBalance.Caption = "الرصيد الجاري";
            colSCRunningBalance.DisplayFormat.FormatString = "n2";
            colSCRunningBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSCRunningBalance.FieldName = "RunningBalance";
            colSCRunningBalance.Name = "colSCRunningBalance";
            colSCRunningBalance.Visible = true;
            colSCRunningBalance.VisibleIndex = 6;
            colSCRunningBalance.Width = 110;
            // 
            // colSCNote
            // 
            colSCNote.Caption = "ملاحظات";
            colSCNote.FieldName = "Note";
            colSCNote.Name = "colSCNote";
            colSCNote.Visible = true;
            colSCNote.VisibleIndex = 7;
            colSCNote.Width = 220;
            // 
            // pnlFiltersSC
            // 
            pnlFiltersSC.Controls.Add(lookUpEditSCStore);
            pnlFiltersSC.Controls.Add(labelControlSC2);
            pnlFiltersSC.Controls.Add(lookUpEditSCItem);
            pnlFiltersSC.Controls.Add(labelControlSC1);
            pnlFiltersSC.Dock = DockStyle.Top;
            pnlFiltersSC.Location = new Point(0, 0);
            pnlFiltersSC.Margin = new Padding(3, 5, 3, 5);
            pnlFiltersSC.Name = "pnlFiltersSC";
            pnlFiltersSC.Size = new Size(1298, 128);
            pnlFiltersSC.TabIndex = 0;
            // 
            // lookUpEditSCStore
            // 
            lookUpEditSCStore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditSCStore.Location = new Point(1021, 17);
            lookUpEditSCStore.Margin = new Padding(3, 5, 3, 5);
            lookUpEditSCStore.Name = "lookUpEditSCStore";
            lookUpEditSCStore.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditSCStore.Properties.Appearance.Options.UseFont = true;
            lookUpEditSCStore.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditSCStore.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name4") });
            lookUpEditSCStore.Properties.NullText = "-- اختر المخزن --";
            lookUpEditSCStore.Size = new Size(210, 28);
            lookUpEditSCStore.TabIndex = 3;
            // 
            // labelControlSC2
            // 
            labelControlSC2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlSC2.Appearance.Font = new Font("Cairo", 9F);
            labelControlSC2.Appearance.Options.UseFont = true;
            labelControlSC2.Location = new Point(1241, 20);
            labelControlSC2.Margin = new Padding(3, 5, 3, 5);
            labelControlSC2.Name = "labelControlSC2";
            labelControlSC2.Size = new Size(36, 23);
            labelControlSC2.TabIndex = 2;
            labelControlSC2.Text = "المخزن:";
            // 
            // lookUpEditSCItem
            // 
            lookUpEditSCItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditSCItem.Location = new Point(1021, 49);
            lookUpEditSCItem.Margin = new Padding(3, 5, 3, 5);
            lookUpEditSCItem.Name = "lookUpEditSCItem";
            lookUpEditSCItem.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditSCItem.Properties.Appearance.Options.UseFont = true;
            lookUpEditSCItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditSCItem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name5") });
            lookUpEditSCItem.Properties.NullText = "-- اختر الصنف --";
            lookUpEditSCItem.Size = new Size(210, 28);
            lookUpEditSCItem.TabIndex = 1;
            // 
            // labelControlSC1
            // 
            labelControlSC1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlSC1.Appearance.Font = new Font("Cairo", 9F);
            labelControlSC1.Appearance.Options.UseFont = true;
            labelControlSC1.Location = new Point(1241, 52);
            labelControlSC1.Margin = new Padding(3, 5, 3, 5);
            labelControlSC1.Name = "labelControlSC1";
            labelControlSC1.Size = new Size(36, 23);
            labelControlSC1.TabIndex = 0;
            labelControlSC1.Text = "الصنف:";
            // 
            // xtraTabPagePeriodMovement
            // 
            xtraTabPagePeriodMovement.Controls.Add(gridControlPM);
            xtraTabPagePeriodMovement.Controls.Add(pnlFiltersPM);
            xtraTabPagePeriodMovement.Margin = new Padding(3, 5, 3, 5);
            xtraTabPagePeriodMovement.Name = "xtraTabPagePeriodMovement";
            xtraTabPagePeriodMovement.Size = new Size(1298, 653);
            xtraTabPagePeriodMovement.Text = "حركة المخزون خلال فترة";
            // 
            // gridControlPM
            // 
            gridControlPM.Dock = DockStyle.Fill;
            gridControlPM.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            gridControlPM.Location = new Point(0, 128);
            gridControlPM.MainView = gridViewPM;
            gridControlPM.Margin = new Padding(3, 5, 3, 5);
            gridControlPM.Name = "gridControlPM";
            gridControlPM.Size = new Size(1298, 525);
            gridControlPM.TabIndex = 1;
            gridControlPM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewPM });
            // 
            // gridViewPM
            // 
            gridViewPM.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridViewPM.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gridViewPM.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridViewPM.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewPM.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewPM.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridViewPM.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridViewPM.Appearance.Row.Font = new Font("Cairo", 9F);
            gridViewPM.Appearance.Row.Options.UseFont = true;
            gridViewPM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPMItemCode, colPMItemName, colPMUnitAbbr, colPMStoreName, colPMOpeningQty, colPMReceivedQty, colPMIssuedQty, colPMTransferInQty, colPMTransferOutQty, colPMPurchaseReturnQty, colPMIssueReturnQty, colPMClosingQty });
            gridViewPM.DetailHeight = 538;
            gridViewPM.GridControl = gridControlPM;
            gridViewPM.Name = "gridViewPM";
            gridViewPM.OptionsBehavior.Editable = false;
            gridViewPM.OptionsView.ColumnAutoWidth = false;
            gridViewPM.OptionsView.ShowGroupPanel = false;
            // 
            // colPMItemCode
            // 
            colPMItemCode.Caption = "رمز الصنف";
            colPMItemCode.FieldName = "ItemCode";
            colPMItemCode.Name = "colPMItemCode";
            colPMItemCode.Visible = true;
            colPMItemCode.VisibleIndex = 0;
            colPMItemCode.Width = 100;
            // 
            // colPMItemName
            // 
            colPMItemName.Caption = "اسم الصنف";
            colPMItemName.FieldName = "ItemName";
            colPMItemName.Name = "colPMItemName";
            colPMItemName.Visible = true;
            colPMItemName.VisibleIndex = 1;
            colPMItemName.Width = 200;
            // 
            // colPMUnitAbbr
            // 
            colPMUnitAbbr.AppearanceCell.Options.UseTextOptions = true;
            colPMUnitAbbr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPMUnitAbbr.Caption = "الوحدة";
            colPMUnitAbbr.FieldName = "UnitAbbr";
            colPMUnitAbbr.Name = "colPMUnitAbbr";
            colPMUnitAbbr.Visible = true;
            colPMUnitAbbr.VisibleIndex = 2;
            colPMUnitAbbr.Width = 60;
            // 
            // colPMStoreName
            // 
            colPMStoreName.Caption = "المخزن";
            colPMStoreName.FieldName = "StoreName";
            colPMStoreName.Name = "colPMStoreName";
            colPMStoreName.Visible = true;
            colPMStoreName.VisibleIndex = 3;
            colPMStoreName.Width = 130;
            // 
            // colPMOpeningQty
            // 
            colPMOpeningQty.AppearanceCell.Options.UseTextOptions = true;
            colPMOpeningQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPMOpeningQty.Caption = "رصيد أول المدة";
            colPMOpeningQty.DisplayFormat.FormatString = "n2";
            colPMOpeningQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPMOpeningQty.FieldName = "OpeningQty";
            colPMOpeningQty.Name = "colPMOpeningQty";
            colPMOpeningQty.Visible = true;
            colPMOpeningQty.VisibleIndex = 4;
            colPMOpeningQty.Width = 100;
            // 
            // colPMReceivedQty
            // 
            colPMReceivedQty.AppearanceCell.Options.UseTextOptions = true;
            colPMReceivedQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPMReceivedQty.Caption = "استلام";
            colPMReceivedQty.DisplayFormat.FormatString = "n2";
            colPMReceivedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPMReceivedQty.FieldName = "ReceivedQty";
            colPMReceivedQty.Name = "colPMReceivedQty";
            colPMReceivedQty.Visible = true;
            colPMReceivedQty.VisibleIndex = 5;
            colPMReceivedQty.Width = 90;
            // 
            // colPMIssuedQty
            // 
            colPMIssuedQty.AppearanceCell.Options.UseTextOptions = true;
            colPMIssuedQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPMIssuedQty.Caption = "صرف";
            colPMIssuedQty.DisplayFormat.FormatString = "n2";
            colPMIssuedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPMIssuedQty.FieldName = "IssuedQty";
            colPMIssuedQty.Name = "colPMIssuedQty";
            colPMIssuedQty.Visible = true;
            colPMIssuedQty.VisibleIndex = 6;
            colPMIssuedQty.Width = 90;
            // 
            // colPMTransferInQty
            // 
            colPMTransferInQty.AppearanceCell.Options.UseTextOptions = true;
            colPMTransferInQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPMTransferInQty.Caption = "تحويل وارد";
            colPMTransferInQty.DisplayFormat.FormatString = "n2";
            colPMTransferInQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPMTransferInQty.FieldName = "TransferInQty";
            colPMTransferInQty.Name = "colPMTransferInQty";
            colPMTransferInQty.Visible = true;
            colPMTransferInQty.VisibleIndex = 7;
            colPMTransferInQty.Width = 90;
            // 
            // colPMTransferOutQty
            // 
            colPMTransferOutQty.AppearanceCell.Options.UseTextOptions = true;
            colPMTransferOutQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPMTransferOutQty.Caption = "تحويل صادر";
            colPMTransferOutQty.DisplayFormat.FormatString = "n2";
            colPMTransferOutQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPMTransferOutQty.FieldName = "TransferOutQty";
            colPMTransferOutQty.Name = "colPMTransferOutQty";
            colPMTransferOutQty.Visible = true;
            colPMTransferOutQty.VisibleIndex = 8;
            colPMTransferOutQty.Width = 90;
            // 
            // colPMPurchaseReturnQty
            // 
            colPMPurchaseReturnQty.AppearanceCell.Options.UseTextOptions = true;
            colPMPurchaseReturnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPMPurchaseReturnQty.Caption = "مرتجع مشتريات";
            colPMPurchaseReturnQty.DisplayFormat.FormatString = "n2";
            colPMPurchaseReturnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPMPurchaseReturnQty.FieldName = "PurchaseReturnQty";
            colPMPurchaseReturnQty.Name = "colPMPurchaseReturnQty";
            colPMPurchaseReturnQty.Visible = true;
            colPMPurchaseReturnQty.VisibleIndex = 9;
            colPMPurchaseReturnQty.Width = 100;
            // 
            // colPMIssueReturnQty
            // 
            colPMIssueReturnQty.AppearanceCell.Options.UseTextOptions = true;
            colPMIssueReturnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPMIssueReturnQty.Caption = "مرتجع صرف";
            colPMIssueReturnQty.DisplayFormat.FormatString = "n2";
            colPMIssueReturnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPMIssueReturnQty.FieldName = "IssueReturnQty";
            colPMIssueReturnQty.Name = "colPMIssueReturnQty";
            colPMIssueReturnQty.Visible = true;
            colPMIssueReturnQty.VisibleIndex = 10;
            colPMIssueReturnQty.Width = 90;
            // 
            // colPMClosingQty
            // 
            colPMClosingQty.AppearanceCell.Options.UseTextOptions = true;
            colPMClosingQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPMClosingQty.Caption = "رصيد آخر المدة";
            colPMClosingQty.DisplayFormat.FormatString = "n2";
            colPMClosingQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPMClosingQty.FieldName = "ClosingQty";
            colPMClosingQty.Name = "colPMClosingQty";
            colPMClosingQty.Visible = true;
            colPMClosingQty.VisibleIndex = 11;
            colPMClosingQty.Width = 100;
            // 
            // pnlFiltersPM
            // 
            pnlFiltersPM.Controls.Add(checkEditPMHideNoActivity);
            pnlFiltersPM.Controls.Add(checkEditPMPerStore);
            pnlFiltersPM.Controls.Add(lookUpEditPMItem);
            pnlFiltersPM.Controls.Add(labelControlPM5);
            pnlFiltersPM.Controls.Add(lookUpEditPMCategory);
            pnlFiltersPM.Controls.Add(labelControlPM4);
            pnlFiltersPM.Controls.Add(lookUpEditPMStore);
            pnlFiltersPM.Controls.Add(labelControlPM3);
            pnlFiltersPM.Controls.Add(dateEditPMTo);
            pnlFiltersPM.Controls.Add(labelControlPM2);
            pnlFiltersPM.Controls.Add(dateEditPMFrom);
            pnlFiltersPM.Controls.Add(labelControlPM1);
            pnlFiltersPM.Dock = DockStyle.Top;
            pnlFiltersPM.Location = new Point(0, 0);
            pnlFiltersPM.Margin = new Padding(3, 5, 3, 5);
            pnlFiltersPM.Name = "pnlFiltersPM";
            pnlFiltersPM.Size = new Size(1298, 128);
            pnlFiltersPM.TabIndex = 0;
            pnlFiltersPM.Paint += pnlFiltersPM_Paint;
            // 
            // checkEditPMHideNoActivity
            // 
            checkEditPMHideNoActivity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkEditPMHideNoActivity.Location = new Point(584, 49);
            checkEditPMHideNoActivity.Margin = new Padding(3, 5, 3, 5);
            checkEditPMHideNoActivity.Name = "checkEditPMHideNoActivity";
            checkEditPMHideNoActivity.Properties.Appearance.Font = new Font("Cairo", 9F);
            checkEditPMHideNoActivity.Properties.Appearance.Options.UseFont = true;
            checkEditPMHideNoActivity.Properties.Caption = "إخفاء بلا حركة";
            checkEditPMHideNoActivity.Size = new Size(130, 27);
            checkEditPMHideNoActivity.TabIndex = 11;
            // 
            // checkEditPMPerStore
            // 
            checkEditPMPerStore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkEditPMPerStore.Location = new Point(564, 18);
            checkEditPMPerStore.Margin = new Padding(3, 5, 3, 5);
            checkEditPMPerStore.Name = "checkEditPMPerStore";
            checkEditPMPerStore.Properties.Appearance.Font = new Font("Cairo", 9F);
            checkEditPMPerStore.Properties.Appearance.Options.UseFont = true;
            checkEditPMPerStore.Properties.Caption = "تفصيل حسب المخزن";
            checkEditPMPerStore.Size = new Size(150, 27);
            checkEditPMPerStore.TabIndex = 10;
            // 
            // lookUpEditPMItem
            // 
            lookUpEditPMItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditPMItem.Location = new Point(725, 49);
            lookUpEditPMItem.Margin = new Padding(3, 5, 3, 5);
            lookUpEditPMItem.Name = "lookUpEditPMItem";
            lookUpEditPMItem.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditPMItem.Properties.Appearance.Options.UseFont = true;
            lookUpEditPMItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditPMItem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name8") });
            lookUpEditPMItem.Properties.NullText = "-- كل الأصناف --";
            lookUpEditPMItem.Size = new Size(210, 28);
            lookUpEditPMItem.TabIndex = 9;
            // 
            // labelControlPM5
            // 
            labelControlPM5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlPM5.Appearance.Font = new Font("Cairo", 9F);
            labelControlPM5.Appearance.Options.UseFont = true;
            labelControlPM5.Location = new Point(945, 52);
            labelControlPM5.Margin = new Padding(3, 5, 3, 5);
            labelControlPM5.Name = "labelControlPM5";
            labelControlPM5.Size = new Size(36, 23);
            labelControlPM5.TabIndex = 8;
            labelControlPM5.Text = "الصنف:";
            // 
            // lookUpEditPMCategory
            // 
            lookUpEditPMCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditPMCategory.Location = new Point(725, 17);
            lookUpEditPMCategory.Margin = new Padding(3, 5, 3, 5);
            lookUpEditPMCategory.Name = "lookUpEditPMCategory";
            lookUpEditPMCategory.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditPMCategory.Properties.Appearance.Options.UseFont = true;
            lookUpEditPMCategory.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditPMCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name7") });
            lookUpEditPMCategory.Properties.NullText = "-- كل التصنيفات --";
            lookUpEditPMCategory.Size = new Size(210, 28);
            lookUpEditPMCategory.TabIndex = 7;
            // 
            // labelControlPM4
            // 
            labelControlPM4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlPM4.Appearance.Font = new Font("Cairo", 9F);
            labelControlPM4.Appearance.Options.UseFont = true;
            labelControlPM4.Location = new Point(945, 20);
            labelControlPM4.Margin = new Padding(3, 5, 3, 5);
            labelControlPM4.Name = "labelControlPM4";
            labelControlPM4.Size = new Size(44, 23);
            labelControlPM4.TabIndex = 6;
            labelControlPM4.Text = "التصنيف:";
            // 
            // lookUpEditPMStore
            // 
            lookUpEditPMStore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditPMStore.Location = new Point(1021, 17);
            lookUpEditPMStore.Margin = new Padding(3, 5, 3, 5);
            lookUpEditPMStore.Name = "lookUpEditPMStore";
            lookUpEditPMStore.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditPMStore.Properties.Appearance.Options.UseFont = true;
            lookUpEditPMStore.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditPMStore.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name6") });
            lookUpEditPMStore.Properties.NullText = "-- كل المخازن المصرَّحة --";
            lookUpEditPMStore.Size = new Size(210, 28);
            lookUpEditPMStore.TabIndex = 5;
            // 
            // labelControlPM3
            // 
            labelControlPM3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlPM3.Appearance.Font = new Font("Cairo", 9F);
            labelControlPM3.Appearance.Options.UseFont = true;
            labelControlPM3.Location = new Point(1241, 20);
            labelControlPM3.Margin = new Padding(3, 5, 3, 5);
            labelControlPM3.Name = "labelControlPM3";
            labelControlPM3.Size = new Size(36, 23);
            labelControlPM3.TabIndex = 4;
            labelControlPM3.Text = "المخزن:";
            // 
            // dateEditPMTo
            // 
            dateEditPMTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateEditPMTo.EditValue = null;
            dateEditPMTo.Location = new Point(1021, 83);
            dateEditPMTo.Margin = new Padding(3, 5, 3, 5);
            dateEditPMTo.Name = "dateEditPMTo";
            dateEditPMTo.Properties.Appearance.Font = new Font("Cairo", 9F);
            dateEditPMTo.Properties.Appearance.Options.UseFont = true;
            dateEditPMTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            dateEditPMTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditPMTo.Size = new Size(210, 28);
            dateEditPMTo.TabIndex = 3;
            // 
            // labelControlPM2
            // 
            labelControlPM2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlPM2.Appearance.Font = new Font("Cairo", 9F);
            labelControlPM2.Appearance.Options.UseFont = true;
            labelControlPM2.Location = new Point(1241, 86);
            labelControlPM2.Margin = new Padding(3, 5, 3, 5);
            labelControlPM2.Name = "labelControlPM2";
            labelControlPM2.Size = new Size(43, 23);
            labelControlPM2.TabIndex = 2;
            labelControlPM2.Text = "إلى تاريخ:";
            // 
            // dateEditPMFrom
            // 
            dateEditPMFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateEditPMFrom.EditValue = null;
            dateEditPMFrom.Location = new Point(1021, 49);
            dateEditPMFrom.Margin = new Padding(3, 5, 3, 5);
            dateEditPMFrom.Name = "dateEditPMFrom";
            dateEditPMFrom.Properties.Appearance.Font = new Font("Cairo", 9F);
            dateEditPMFrom.Properties.Appearance.Options.UseFont = true;
            dateEditPMFrom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            dateEditPMFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditPMFrom.Size = new Size(210, 28);
            dateEditPMFrom.TabIndex = 1;
            // 
            // labelControlPM1
            // 
            labelControlPM1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlPM1.Appearance.Font = new Font("Cairo", 9F);
            labelControlPM1.Appearance.Options.UseFont = true;
            labelControlPM1.Location = new Point(1241, 52);
            labelControlPM1.Margin = new Padding(3, 5, 3, 5);
            labelControlPM1.Name = "labelControlPM1";
            labelControlPM1.Size = new Size(44, 23);
            labelControlPM1.TabIndex = 0;
            labelControlPM1.Text = "من تاريخ:";
            // 
            // xtraTabPageStockingVariance
            // 
            xtraTabPageStockingVariance.Controls.Add(gridControlSV);
            xtraTabPageStockingVariance.Controls.Add(pnlFiltersSV);
            xtraTabPageStockingVariance.Margin = new Padding(3, 5, 3, 5);
            xtraTabPageStockingVariance.Name = "xtraTabPageStockingVariance";
            xtraTabPageStockingVariance.Size = new Size(1298, 650);
            xtraTabPageStockingVariance.Text = "تقرير الجرد وفروقاته";
            // 
            // gridControlSV
            // 
            gridControlSV.Dock = DockStyle.Fill;
            gridControlSV.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            gridControlSV.Location = new Point(0, 128);
            gridControlSV.MainView = gridViewSV;
            gridControlSV.Margin = new Padding(3, 5, 3, 5);
            gridControlSV.Name = "gridControlSV";
            gridControlSV.Size = new Size(1298, 522);
            gridControlSV.TabIndex = 1;
            gridControlSV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewSV });
            // 
            // gridViewSV
            // 
            gridViewSV.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridViewSV.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gridViewSV.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridViewSV.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewSV.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewSV.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridViewSV.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridViewSV.Appearance.Row.Font = new Font("Cairo", 9F);
            gridViewSV.Appearance.Row.Options.UseFont = true;
            gridViewSV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colSVStockingNum, colSVStockingDate, colSVStoreName, colSVItemCode, colSVItemName, colSVUnitAbbr, colSVSystemQty, colSVQty, colSVDifference, colSVDifferenceValue, colSVNote });
            gridViewSV.DetailHeight = 538;
            gridViewSV.GridControl = gridControlSV;
            gridViewSV.Name = "gridViewSV";
            gridViewSV.OptionsBehavior.Editable = false;
            gridViewSV.OptionsView.ColumnAutoWidth = false;
            gridViewSV.OptionsView.ShowGroupPanel = false;
            // 
            // colSVStockingNum
            // 
            colSVStockingNum.AppearanceCell.Options.UseTextOptions = true;
            colSVStockingNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSVStockingNum.Caption = "رقم الجرد";
            colSVStockingNum.FieldName = "StockingNum";
            colSVStockingNum.Name = "colSVStockingNum";
            colSVStockingNum.Visible = true;
            colSVStockingNum.VisibleIndex = 0;
            colSVStockingNum.Width = 90;
            // 
            // colSVStockingDate
            // 
            colSVStockingDate.AppearanceCell.Options.UseTextOptions = true;
            colSVStockingDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSVStockingDate.Caption = "تاريخ الجرد";
            colSVStockingDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            colSVStockingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colSVStockingDate.FieldName = "StockingDate";
            colSVStockingDate.Name = "colSVStockingDate";
            colSVStockingDate.Visible = true;
            colSVStockingDate.VisibleIndex = 1;
            colSVStockingDate.Width = 100;
            // 
            // colSVStoreName
            // 
            colSVStoreName.Caption = "المخزن";
            colSVStoreName.FieldName = "StoreName";
            colSVStoreName.Name = "colSVStoreName";
            colSVStoreName.Visible = true;
            colSVStoreName.VisibleIndex = 2;
            colSVStoreName.Width = 130;
            // 
            // colSVItemCode
            // 
            colSVItemCode.AppearanceCell.Options.UseTextOptions = true;
            colSVItemCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSVItemCode.Caption = "رمز الصنف";
            colSVItemCode.FieldName = "ItemCode";
            colSVItemCode.Name = "colSVItemCode";
            colSVItemCode.Visible = true;
            colSVItemCode.VisibleIndex = 3;
            colSVItemCode.Width = 100;
            // 
            // colSVItemName
            // 
            colSVItemName.Caption = "اسم الصنف";
            colSVItemName.FieldName = "ItemName";
            colSVItemName.Name = "colSVItemName";
            colSVItemName.Visible = true;
            colSVItemName.VisibleIndex = 4;
            colSVItemName.Width = 190;
            // 
            // colSVUnitAbbr
            // 
            colSVUnitAbbr.AppearanceCell.Options.UseTextOptions = true;
            colSVUnitAbbr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSVUnitAbbr.Caption = "الوحدة";
            colSVUnitAbbr.FieldName = "UnitAbbr";
            colSVUnitAbbr.Name = "colSVUnitAbbr";
            colSVUnitAbbr.Visible = true;
            colSVUnitAbbr.VisibleIndex = 5;
            colSVUnitAbbr.Width = 60;
            // 
            // colSVSystemQty
            // 
            colSVSystemQty.AppearanceCell.Options.UseTextOptions = true;
            colSVSystemQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSVSystemQty.Caption = "الرصيد الدفتري";
            colSVSystemQty.DisplayFormat.FormatString = "n2";
            colSVSystemQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSVSystemQty.FieldName = "SystemQty";
            colSVSystemQty.Name = "colSVSystemQty";
            colSVSystemQty.Visible = true;
            colSVSystemQty.VisibleIndex = 6;
            colSVSystemQty.Width = 100;
            // 
            // colSVQty
            // 
            colSVQty.AppearanceCell.Options.UseTextOptions = true;
            colSVQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSVQty.Caption = "الكمية الفعلية";
            colSVQty.DisplayFormat.FormatString = "n2";
            colSVQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSVQty.FieldName = "Qty";
            colSVQty.Name = "colSVQty";
            colSVQty.Visible = true;
            colSVQty.VisibleIndex = 7;
            colSVQty.Width = 100;
            // 
            // colSVDifference
            // 
            colSVDifference.AppearanceCell.Options.UseTextOptions = true;
            colSVDifference.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSVDifference.Caption = "الفرق (كمية)";
            colSVDifference.DisplayFormat.FormatString = "n2";
            colSVDifference.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSVDifference.FieldName = "Difference";
            colSVDifference.Name = "colSVDifference";
            colSVDifference.Visible = true;
            colSVDifference.VisibleIndex = 8;
            colSVDifference.Width = 100;
            // 
            // colSVDifferenceValue
            // 
            colSVDifferenceValue.AppearanceCell.Options.UseTextOptions = true;
            colSVDifferenceValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSVDifferenceValue.Caption = "الفرق (قيمة)";
            colSVDifferenceValue.DisplayFormat.FormatString = "n2";
            colSVDifferenceValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSVDifferenceValue.FieldName = "DifferenceValue";
            colSVDifferenceValue.Name = "colSVDifferenceValue";
            colSVDifferenceValue.Visible = true;
            colSVDifferenceValue.VisibleIndex = 9;
            colSVDifferenceValue.Width = 100;
            // 
            // colSVNote
            // 
            colSVNote.Caption = "ملاحظات";
            colSVNote.FieldName = "Note";
            colSVNote.Name = "colSVNote";
            colSVNote.Visible = true;
            colSVNote.VisibleIndex = 10;
            colSVNote.Width = 200;
            // 
            // pnlFiltersSV
            // 
            pnlFiltersSV.Controls.Add(dateEditSVTo);
            pnlFiltersSV.Controls.Add(labelControlSV3);
            pnlFiltersSV.Controls.Add(dateEditSVFrom);
            pnlFiltersSV.Controls.Add(labelControlSV2);
            pnlFiltersSV.Controls.Add(lookUpEditSVStore);
            pnlFiltersSV.Controls.Add(labelControlSV1);
            pnlFiltersSV.Dock = DockStyle.Top;
            pnlFiltersSV.Location = new Point(0, 0);
            pnlFiltersSV.Margin = new Padding(3, 5, 3, 5);
            pnlFiltersSV.Name = "pnlFiltersSV";
            pnlFiltersSV.Size = new Size(1298, 128);
            pnlFiltersSV.TabIndex = 0;
            // 
            // dateEditSVTo
            // 
            dateEditSVTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateEditSVTo.EditValue = null;
            dateEditSVTo.Location = new Point(1021, 83);
            dateEditSVTo.Margin = new Padding(3, 5, 3, 5);
            dateEditSVTo.Name = "dateEditSVTo";
            dateEditSVTo.Properties.Appearance.Font = new Font("Cairo", 9F);
            dateEditSVTo.Properties.Appearance.Options.UseFont = true;
            dateEditSVTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            dateEditSVTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditSVTo.Size = new Size(210, 28);
            dateEditSVTo.TabIndex = 5;
            // 
            // labelControlSV3
            // 
            labelControlSV3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlSV3.Appearance.Font = new Font("Cairo", 9F);
            labelControlSV3.Appearance.Options.UseFont = true;
            labelControlSV3.Location = new Point(1241, 86);
            labelControlSV3.Margin = new Padding(3, 5, 3, 5);
            labelControlSV3.Name = "labelControlSV3";
            labelControlSV3.Size = new Size(43, 23);
            labelControlSV3.TabIndex = 4;
            labelControlSV3.Text = "إلى تاريخ:";
            // 
            // dateEditSVFrom
            // 
            dateEditSVFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateEditSVFrom.EditValue = null;
            dateEditSVFrom.Location = new Point(1021, 49);
            dateEditSVFrom.Margin = new Padding(3, 5, 3, 5);
            dateEditSVFrom.Name = "dateEditSVFrom";
            dateEditSVFrom.Properties.Appearance.Font = new Font("Cairo", 9F);
            dateEditSVFrom.Properties.Appearance.Options.UseFont = true;
            dateEditSVFrom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            dateEditSVFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditSVFrom.Size = new Size(210, 28);
            dateEditSVFrom.TabIndex = 3;
            // 
            // labelControlSV2
            // 
            labelControlSV2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlSV2.Appearance.Font = new Font("Cairo", 9F);
            labelControlSV2.Appearance.Options.UseFont = true;
            labelControlSV2.Location = new Point(1241, 52);
            labelControlSV2.Margin = new Padding(3, 5, 3, 5);
            labelControlSV2.Name = "labelControlSV2";
            labelControlSV2.Size = new Size(44, 23);
            labelControlSV2.TabIndex = 2;
            labelControlSV2.Text = "من تاريخ:";
            // 
            // lookUpEditSVStore
            // 
            lookUpEditSVStore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditSVStore.Location = new Point(1021, 17);
            lookUpEditSVStore.Margin = new Padding(3, 5, 3, 5);
            lookUpEditSVStore.Name = "lookUpEditSVStore";
            lookUpEditSVStore.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditSVStore.Properties.Appearance.Options.UseFont = true;
            lookUpEditSVStore.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditSVStore.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name9") });
            lookUpEditSVStore.Properties.NullText = "-- كل المخازن المصرَّحة --";
            lookUpEditSVStore.Size = new Size(210, 28);
            lookUpEditSVStore.TabIndex = 1;
            // 
            // labelControlSV1
            // 
            labelControlSV1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlSV1.Appearance.Font = new Font("Cairo", 9F);
            labelControlSV1.Appearance.Options.UseFont = true;
            labelControlSV1.Location = new Point(1241, 20);
            labelControlSV1.Margin = new Padding(3, 5, 3, 5);
            labelControlSV1.Name = "labelControlSV1";
            labelControlSV1.Size = new Size(36, 23);
            labelControlSV1.TabIndex = 0;
            labelControlSV1.Text = "المخزن:";
            // 
            // ucInventoryReports
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(xtraTabControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucInventoryReports";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1300, 720);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);
            xtraTabPageBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlSB).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSB).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFiltersSB).EndInit();
            pnlFiltersSB.ResumeLayout(false);
            pnlFiltersSB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)checkEditSBHideZero.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSBItem.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSBCategory.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSBStore.Properties).EndInit();
            xtraTabPageStockCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlSC).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSC).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFiltersSC).EndInit();
            pnlFiltersSC.ResumeLayout(false);
            pnlFiltersSC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSCStore.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSCItem.Properties).EndInit();
            xtraTabPagePeriodMovement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlPM).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPM).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFiltersPM).EndInit();
            pnlFiltersPM.ResumeLayout(false);
            pnlFiltersPM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)checkEditPMHideNoActivity.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEditPMPerStore.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditPMItem.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditPMCategory.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditPMStore.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditPMTo.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditPMTo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditPMFrom.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditPMFrom.Properties).EndInit();
            xtraTabPageStockingVariance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlSV).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSV).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFiltersSV).EndInit();
            pnlFiltersSV.ResumeLayout(false);
            pnlFiltersSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dateEditSVTo.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditSVTo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditSVFrom.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditSVFrom.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditSVStore.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiRun;
        private DevExpress.XtraBars.BarButtonItem bbiClearFilter;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExportExcel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageBalance;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageStockCard;
        private DevExpress.XtraTab.XtraTabPage xtraTabPagePeriodMovement;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageStockingVariance;

        // Tab 1
        private DevExpress.XtraEditors.PanelControl pnlFiltersSB;
        private DevExpress.XtraEditors.LabelControl labelControlSB1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSBStore;
        private DevExpress.XtraEditors.LabelControl labelControlSB2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSBCategory;
        private DevExpress.XtraEditors.LabelControl labelControlSB3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSBItem;
        private DevExpress.XtraEditors.CheckEdit checkEditSBHideZero;
        private DevExpress.XtraGrid.GridControl gridControlSB;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSB;
        private DevExpress.XtraGrid.Columns.GridColumn colSBItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSBItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colSBCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colSBStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn colSBUnitAbbr;
        private DevExpress.XtraGrid.Columns.GridColumn colSBBalance;

        // Tab 2
        private DevExpress.XtraEditors.PanelControl pnlFiltersSC;
        private DevExpress.XtraEditors.LabelControl labelControlSC1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSCItem;
        private DevExpress.XtraEditors.LabelControl labelControlSC2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSCStore;
        private DevExpress.XtraGrid.GridControl gridControlSC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSC;
        private DevExpress.XtraGrid.Columns.GridColumn colSCMovementDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSCMovementType;
        private DevExpress.XtraGrid.Columns.GridColumn colSCDocumentNum;
        private DevExpress.XtraGrid.Columns.GridColumn colSCCounterpartyStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn colSCQtyIn;
        private DevExpress.XtraGrid.Columns.GridColumn colSCQtyOut;
        private DevExpress.XtraGrid.Columns.GridColumn colSCRunningBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colSCNote;

        // Tab 3
        private DevExpress.XtraEditors.PanelControl pnlFiltersPM;
        private DevExpress.XtraEditors.LabelControl labelControlPM1;
        private DevExpress.XtraEditors.DateEdit dateEditPMFrom;
        private DevExpress.XtraEditors.LabelControl labelControlPM2;
        private DevExpress.XtraEditors.DateEdit dateEditPMTo;
        private DevExpress.XtraEditors.LabelControl labelControlPM3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPMStore;
        private DevExpress.XtraEditors.LabelControl labelControlPM4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPMCategory;
        private DevExpress.XtraEditors.LabelControl labelControlPM5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPMItem;
        private DevExpress.XtraEditors.CheckEdit checkEditPMPerStore;
        private DevExpress.XtraEditors.CheckEdit checkEditPMHideNoActivity;
        private DevExpress.XtraGrid.GridControl gridControlPM;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPM;
        private DevExpress.XtraGrid.Columns.GridColumn colPMItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPMItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colPMUnitAbbr;
        private DevExpress.XtraGrid.Columns.GridColumn colPMStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn colPMOpeningQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPMReceivedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPMIssuedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPMTransferInQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPMTransferOutQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPMPurchaseReturnQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPMIssueReturnQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPMClosingQty;

        // Tab 4
        private DevExpress.XtraEditors.PanelControl pnlFiltersSV;
        private DevExpress.XtraEditors.LabelControl labelControlSV1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSVStore;
        private DevExpress.XtraEditors.LabelControl labelControlSV2;
        private DevExpress.XtraEditors.DateEdit dateEditSVFrom;
        private DevExpress.XtraEditors.LabelControl labelControlSV3;
        private DevExpress.XtraEditors.DateEdit dateEditSVTo;
        private DevExpress.XtraGrid.GridControl gridControlSV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSV;
        private DevExpress.XtraGrid.Columns.GridColumn colSVStockingNum;
        private DevExpress.XtraGrid.Columns.GridColumn colSVStockingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSVStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn colSVItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSVItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colSVUnitAbbr;
        private DevExpress.XtraGrid.Columns.GridColumn colSVSystemQty;
        private DevExpress.XtraGrid.Columns.GridColumn colSVQty;
        private DevExpress.XtraGrid.Columns.GridColumn colSVDifference;
        private DevExpress.XtraGrid.Columns.GridColumn colSVDifferenceValue;
        private DevExpress.XtraGrid.Columns.GridColumn colSVNote;
    }
}
