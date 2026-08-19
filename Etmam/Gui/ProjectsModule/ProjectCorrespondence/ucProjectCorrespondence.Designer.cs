namespace Etmam
{
    partial class ucProjectCorrespondence
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
            barManagerCorrespondence = new DevExpress.XtraBars.BarManager(components);
            barCorrespondence = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiRecordCount = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();

            tabCorrespondence = new DevExpress.XtraTab.XtraTabControl();

            tabIncoming = new DevExpress.XtraTab.XtraTabPage();
            grdIncoming = new DevExpress.XtraGrid.GridControl();
            gvIncoming = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIncomingSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            colIncomingReference = new DevExpress.XtraGrid.Columns.GridColumn();
            colIncomingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colIncomingStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            tabOutgoing = new DevExpress.XtraTab.XtraTabPage();
            grdOutgoing = new DevExpress.XtraGrid.GridControl();
            gvOutgoing = new DevExpress.XtraGrid.Views.Grid.GridView();
            colOutgoingSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            colOutgoingReference = new DevExpress.XtraGrid.Columns.GridColumn();
            colOutgoingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colOutgoingStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            tabInternal = new DevExpress.XtraTab.XtraTabPage();
            grdInternal = new DevExpress.XtraGrid.GridControl();
            gvInternal = new DevExpress.XtraGrid.Views.Grid.GridView();
            colInternalSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            colInternalReference = new DevExpress.XtraGrid.Columns.GridColumn();
            colInternalDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colInternalStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            lblLoadingText = new DevExpress.XtraEditors.LabelControl();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            lblEmptyText = new DevExpress.XtraEditors.LabelControl();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl();
            svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();
            lblErrorText = new DevExpress.XtraEditors.LabelControl();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)barManagerCorrespondence).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabCorrespondence).BeginInit();
            tabCorrespondence.SuspendLayout();
            tabIncoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdIncoming).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvIncoming).BeginInit();
            tabOutgoing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdOutgoing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvOutgoing).BeginInit();
            tabInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdInternal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvInternal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            SuspendLayout();
            //
            // barManagerCorrespondence
            //
            barManagerCorrespondence.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barCorrespondence, barStatus });
            barManagerCorrespondence.DockControls.Add(barDockControlTop);
            barManagerCorrespondence.DockControls.Add(barDockControlBottom);
            barManagerCorrespondence.DockControls.Add(barDockControlLeft);
            barManagerCorrespondence.DockControls.Add(barDockControlRight);
            barManagerCorrespondence.Form = this;
            barManagerCorrespondence.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiEdit, bbiDelete, bbiPrint, bbiExportExcel, sbiRecordCount });
            barManagerCorrespondence.MainMenu = barCorrespondence;
            barManagerCorrespondence.MaxItemId = 6;
            barManagerCorrespondence.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerCorrespondence.StatusBar = barStatus;
            //
            // barCorrespondence
            //
            barCorrespondence.BarName = "شريط أدوات المراسلات";
            barCorrespondence.DockCol = 0;
            barCorrespondence.DockRow = 0;
            barCorrespondence.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barCorrespondence.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barCorrespondence.OptionsBar.AllowQuickCustomization = false;
            barCorrespondence.OptionsBar.DrawDragBorder = false;
            barCorrespondence.OptionsBar.MinHeight = 34;
            barCorrespondence.OptionsBar.UseWholeRow = true;
            barCorrespondence.Text = "شريط أدوات المراسلات";
            //
            // bbiAdd
            //
            bbiAdd.Caption = "إضافة";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.SvgImage = Etmam.IconLoader.Get("add.svg");
            bbiAdd.Name = "bbiAdd";
            bbiAdd.ItemClick += bbiAdd_ItemClick;
            //
            // bbiEdit
            //
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 1;
            bbiEdit.ImageOptions.SvgImage = Etmam.IconLoader.Get("edit.svg");
            bbiEdit.Name = "bbiEdit";
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            //
            // bbiDelete
            //
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 2;
            bbiDelete.ImageOptions.SvgImage = Etmam.IconLoader.Get("delete.svg");
            bbiDelete.Name = "bbiDelete";
            bbiDelete.ItemClick += bbiDelete_ItemClick;
            //
            // bbiPrint
            //
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 3;
            bbiPrint.ImageOptions.SvgImage = Etmam.IconLoader.Get("print.svg");
            bbiPrint.Name = "bbiPrint";
            bbiPrint.ItemClick += bbiPrint_ItemClick;
            //
            // bbiExportExcel
            //
            bbiExportExcel.Caption = "تصدير Excel";
            bbiExportExcel.Id = 4;
            bbiExportExcel.ImageOptions.SvgImage = Etmam.IconLoader.Get("export_excel.svg");
            bbiExportExcel.Name = "bbiExportExcel";
            bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            //
            // barStatus
            //
            barStatus.BarName = "شريط الحالة";
            barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            barStatus.DockCol = 0;
            barStatus.DockRow = 0;
            barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(sbiRecordCount) });
            barStatus.OptionsBar.AllowQuickCustomization = false;
            barStatus.OptionsBar.DrawDragBorder = false;
            barStatus.OptionsBar.UseWholeRow = true;
            barStatus.Text = "شريط الحالة";
            //
            // sbiRecordCount
            //
            sbiRecordCount.Caption = "عدد المراسلات: 0";
            sbiRecordCount.Id = 5;
            sbiRecordCount.Name = "sbiRecordCount";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerCorrespondence;
            barDockControlTop.Size = new Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 796);
            barDockControlBottom.Manager = barManagerCorrespondence;
            barDockControlBottom.Size = new Size(1366, 24);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerCorrespondence;
            barDockControlLeft.Size = new Size(0, 762);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerCorrespondence;
            barDockControlRight.Size = new Size(0, 762);
            //
            // tabCorrespondence
            //
            tabCorrespondence.AppearancePage.Header.Font = new Font("Cairo", 9F);
            tabCorrespondence.AppearancePage.Header.Options.UseFont = true;
            tabCorrespondence.Dock = DockStyle.Fill;
            tabCorrespondence.Location = new Point(0, 34);
            tabCorrespondence.Name = "tabCorrespondence";
            tabCorrespondence.SelectedTabPage = tabIncoming;
            tabCorrespondence.Size = new Size(1366, 762);
            tabCorrespondence.TabIndex = 0;
            tabCorrespondence.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tabIncoming, tabOutgoing, tabInternal });
            //
            // tabIncoming
            //
            tabIncoming.Controls.Add(grdIncoming);
            tabIncoming.Name = "tabIncoming";
            tabIncoming.Size = new Size(1364, 736);
            tabIncoming.Text = "وارد";
            //
            // grdIncoming
            //
            grdIncoming.Dock = DockStyle.Fill;
            grdIncoming.Location = new Point(0, 0);
            grdIncoming.MainView = gvIncoming;
            grdIncoming.MenuManager = barManagerCorrespondence;
            grdIncoming.Name = "grdIncoming";
            grdIncoming.Size = new Size(1364, 736);
            grdIncoming.TabIndex = 0;
            grdIncoming.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvIncoming });
            //
            // gvIncoming
            //
            gvIncoming.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvIncoming.Appearance.HeaderPanel.Options.UseFont = true;
            gvIncoming.Appearance.Row.Font = new Font("Cairo", 8F);
            gvIncoming.Appearance.Row.Options.UseFont = true;
            gvIncoming.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIncomingSubject, colIncomingReference, colIncomingDate, colIncomingStatus });
            gvIncoming.GridControl = grdIncoming;
            gvIncoming.Name = "gvIncoming";
            gvIncoming.OptionsView.ColumnAutoWidth = false;
            gvIncoming.OptionsView.ShowAutoFilterRow = true;
            gvIncoming.OptionsView.ShowFooter = true;
            //
            // colIncomingSubject
            //
            colIncomingSubject.Caption = "الموضوع";
            colIncomingSubject.FieldName = "Subject";
            colIncomingSubject.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colIncomingSubject.Name = "colIncomingSubject";
            colIncomingSubject.OptionsColumn.AllowEdit = false;
            colIncomingSubject.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Subject", "العدد: {0}") });
            colIncomingSubject.Visible = true;
            colIncomingSubject.VisibleIndex = 0;
            colIncomingSubject.Width = 460;
            //
            // colIncomingReference
            //
            colIncomingReference.Caption = "الرقم المرجعي";
            colIncomingReference.FieldName = "Reference";
            colIncomingReference.Name = "colIncomingReference";
            colIncomingReference.OptionsColumn.AllowEdit = false;
            colIncomingReference.Visible = true;
            colIncomingReference.VisibleIndex = 1;
            colIncomingReference.Width = 180;
            //
            // colIncomingDate
            //
            colIncomingDate.Caption = "التاريخ";
            colIncomingDate.DisplayFormat.FormatString = "d";
            colIncomingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colIncomingDate.FieldName = "Date";
            colIncomingDate.Name = "colIncomingDate";
            colIncomingDate.OptionsColumn.AllowEdit = false;
            colIncomingDate.Visible = true;
            colIncomingDate.VisibleIndex = 2;
            colIncomingDate.Width = 130;
            //
            // colIncomingStatus
            //
            colIncomingStatus.Caption = "الحالة";
            colIncomingStatus.FieldName = "Status";
            colIncomingStatus.Name = "colIncomingStatus";
            colIncomingStatus.OptionsColumn.AllowEdit = false;
            colIncomingStatus.Visible = true;
            colIncomingStatus.VisibleIndex = 3;
            colIncomingStatus.Width = 130;
            //
            // tabOutgoing
            //
            tabOutgoing.Controls.Add(grdOutgoing);
            tabOutgoing.Name = "tabOutgoing";
            tabOutgoing.Size = new Size(1364, 736);
            tabOutgoing.Text = "صادر";
            //
            // grdOutgoing
            //
            grdOutgoing.Dock = DockStyle.Fill;
            grdOutgoing.Location = new Point(0, 0);
            grdOutgoing.MainView = gvOutgoing;
            grdOutgoing.MenuManager = barManagerCorrespondence;
            grdOutgoing.Name = "grdOutgoing";
            grdOutgoing.Size = new Size(1364, 736);
            grdOutgoing.TabIndex = 0;
            grdOutgoing.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvOutgoing });
            //
            // gvOutgoing
            //
            gvOutgoing.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvOutgoing.Appearance.HeaderPanel.Options.UseFont = true;
            gvOutgoing.Appearance.Row.Font = new Font("Cairo", 8F);
            gvOutgoing.Appearance.Row.Options.UseFont = true;
            gvOutgoing.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colOutgoingSubject, colOutgoingReference, colOutgoingDate, colOutgoingStatus });
            gvOutgoing.GridControl = grdOutgoing;
            gvOutgoing.Name = "gvOutgoing";
            gvOutgoing.OptionsView.ColumnAutoWidth = false;
            gvOutgoing.OptionsView.ShowAutoFilterRow = true;
            gvOutgoing.OptionsView.ShowFooter = true;
            //
            // colOutgoingSubject
            //
            colOutgoingSubject.Caption = "الموضوع";
            colOutgoingSubject.FieldName = "Subject";
            colOutgoingSubject.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colOutgoingSubject.Name = "colOutgoingSubject";
            colOutgoingSubject.OptionsColumn.AllowEdit = false;
            colOutgoingSubject.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Subject", "العدد: {0}") });
            colOutgoingSubject.Visible = true;
            colOutgoingSubject.VisibleIndex = 0;
            colOutgoingSubject.Width = 460;
            //
            // colOutgoingReference
            //
            colOutgoingReference.Caption = "الرقم المرجعي";
            colOutgoingReference.FieldName = "Reference";
            colOutgoingReference.Name = "colOutgoingReference";
            colOutgoingReference.OptionsColumn.AllowEdit = false;
            colOutgoingReference.Visible = true;
            colOutgoingReference.VisibleIndex = 1;
            colOutgoingReference.Width = 180;
            //
            // colOutgoingDate
            //
            colOutgoingDate.Caption = "التاريخ";
            colOutgoingDate.DisplayFormat.FormatString = "d";
            colOutgoingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colOutgoingDate.FieldName = "Date";
            colOutgoingDate.Name = "colOutgoingDate";
            colOutgoingDate.OptionsColumn.AllowEdit = false;
            colOutgoingDate.Visible = true;
            colOutgoingDate.VisibleIndex = 2;
            colOutgoingDate.Width = 130;
            //
            // colOutgoingStatus
            //
            colOutgoingStatus.Caption = "الحالة";
            colOutgoingStatus.FieldName = "Status";
            colOutgoingStatus.Name = "colOutgoingStatus";
            colOutgoingStatus.OptionsColumn.AllowEdit = false;
            colOutgoingStatus.Visible = true;
            colOutgoingStatus.VisibleIndex = 3;
            colOutgoingStatus.Width = 130;
            //
            // tabInternal
            //
            tabInternal.Controls.Add(grdInternal);
            tabInternal.Name = "tabInternal";
            tabInternal.Size = new Size(1364, 736);
            tabInternal.Text = "داخلي";
            //
            // grdInternal
            //
            grdInternal.Dock = DockStyle.Fill;
            grdInternal.Location = new Point(0, 0);
            grdInternal.MainView = gvInternal;
            grdInternal.MenuManager = barManagerCorrespondence;
            grdInternal.Name = "grdInternal";
            grdInternal.Size = new Size(1364, 736);
            grdInternal.TabIndex = 0;
            grdInternal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvInternal });
            //
            // gvInternal
            //
            gvInternal.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvInternal.Appearance.HeaderPanel.Options.UseFont = true;
            gvInternal.Appearance.Row.Font = new Font("Cairo", 8F);
            gvInternal.Appearance.Row.Options.UseFont = true;
            gvInternal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colInternalSubject, colInternalReference, colInternalDate, colInternalStatus });
            gvInternal.GridControl = grdInternal;
            gvInternal.Name = "gvInternal";
            gvInternal.OptionsView.ColumnAutoWidth = false;
            gvInternal.OptionsView.ShowAutoFilterRow = true;
            gvInternal.OptionsView.ShowFooter = true;
            //
            // colInternalSubject
            //
            colInternalSubject.Caption = "الموضوع";
            colInternalSubject.FieldName = "Subject";
            colInternalSubject.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colInternalSubject.Name = "colInternalSubject";
            colInternalSubject.OptionsColumn.AllowEdit = false;
            colInternalSubject.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Subject", "العدد: {0}") });
            colInternalSubject.Visible = true;
            colInternalSubject.VisibleIndex = 0;
            colInternalSubject.Width = 460;
            //
            // colInternalReference
            //
            colInternalReference.Caption = "الرقم المرجعي";
            colInternalReference.FieldName = "Reference";
            colInternalReference.Name = "colInternalReference";
            colInternalReference.OptionsColumn.AllowEdit = false;
            colInternalReference.Visible = true;
            colInternalReference.VisibleIndex = 1;
            colInternalReference.Width = 180;
            //
            // colInternalDate
            //
            colInternalDate.Caption = "التاريخ";
            colInternalDate.DisplayFormat.FormatString = "d";
            colInternalDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colInternalDate.FieldName = "Date";
            colInternalDate.Name = "colInternalDate";
            colInternalDate.OptionsColumn.AllowEdit = false;
            colInternalDate.Visible = true;
            colInternalDate.VisibleIndex = 2;
            colInternalDate.Width = 130;
            //
            // colInternalStatus
            //
            colInternalStatus.Caption = "الحالة";
            colInternalStatus.FieldName = "Status";
            colInternalStatus.Name = "colInternalStatus";
            colInternalStatus.OptionsColumn.AllowEdit = false;
            colInternalStatus.Visible = true;
            colInternalStatus.VisibleIndex = 3;
            colInternalStatus.Width = 130;
            //
            // pnlLoadingState
            //
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 34);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 762);
            pnlLoadingState.TabIndex = 1;
            pnlLoadingState.Visible = false;
            //
            // svgLoadingIcon
            //
            svgLoadingIcon.Location = new Point(651, 320);
            svgLoadingIcon.Name = "svgLoadingIcon";
            svgLoadingIcon.Size = new Size(64, 64);
            svgLoadingIcon.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            svgLoadingIcon.TabIndex = 0;
            //
            // lblLoadingText
            //
            lblLoadingText.Appearance.Font = new Font("Cairo", 10F);
            lblLoadingText.Appearance.Options.UseFont = true;
            lblLoadingText.Appearance.Options.UseTextOptions = true;
            lblLoadingText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblLoadingText.Location = new Point(583, 394);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(200, 20);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل المراسلات...";
            //
            // pnlEmptyState
            //
            pnlEmptyState.Controls.Add(lblEmptyText);
            pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Dock = DockStyle.Fill;
            pnlEmptyState.Location = new Point(0, 34);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 762);
            pnlEmptyState.TabIndex = 2;
            pnlEmptyState.Visible = false;
            //
            // svgEmptyIcon
            //
            svgEmptyIcon.Location = new Point(651, 320);
            svgEmptyIcon.Name = "svgEmptyIcon";
            svgEmptyIcon.Size = new Size(64, 64);
            svgEmptyIcon.SvgImage = Etmam.IconLoader.Get("empty.svg");
            svgEmptyIcon.TabIndex = 0;
            //
            // lblEmptyText
            //
            lblEmptyText.Appearance.Font = new Font("Cairo", 10F);
            lblEmptyText.Appearance.Options.UseFont = true;
            lblEmptyText.Appearance.Options.UseTextOptions = true;
            lblEmptyText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyText.Location = new Point(583, 394);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(200, 20);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا توجد مراسلات لعرضها";
            //
            // pnlErrorState
            //
            pnlErrorState.Controls.Add(btnRetry);
            pnlErrorState.Controls.Add(lblErrorText);
            pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Dock = DockStyle.Fill;
            pnlErrorState.Location = new Point(0, 34);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 762);
            pnlErrorState.TabIndex = 3;
            pnlErrorState.Visible = false;
            //
            // svgErrorIcon
            //
            svgErrorIcon.Location = new Point(651, 300);
            svgErrorIcon.Name = "svgErrorIcon";
            svgErrorIcon.Size = new Size(64, 64);
            svgErrorIcon.SvgImage = Etmam.IconLoader.Get("error.svg");
            svgErrorIcon.TabIndex = 0;
            //
            // lblErrorText
            //
            lblErrorText.Appearance.Font = new Font("Cairo", 10F);
            lblErrorText.Appearance.Options.UseFont = true;
            lblErrorText.Appearance.Options.UseTextOptions = true;
            lblErrorText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblErrorText.Location = new Point(583, 374);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(200, 20);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل المراسلات";
            //
            // btnRetry
            //
            btnRetry.ImageOptions.SvgImage = Etmam.IconLoader.Get("refresh.svg");
            btnRetry.Location = new Point(633, 404);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(100, 28);
            btnRetry.TabIndex = 2;
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;
            //
            // ucProjectCorrespondence
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabCorrespondence);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucProjectCorrespondence";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 820);
            ((System.ComponentModel.ISupportInitialize)barManagerCorrespondence).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdIncoming).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvIncoming).EndInit();
            tabIncoming.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdOutgoing).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvOutgoing).EndInit();
            tabOutgoing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdInternal).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvInternal).EndInit();
            tabInternal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tabCorrespondence).EndInit();
            tabCorrespondence.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit();
            pnlLoadingState.ResumeLayout(false);
            pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit();
            pnlEmptyState.ResumeLayout(false);
            pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit();
            pnlErrorState.ResumeLayout(false);
            pnlErrorState.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerCorrespondence;
        private DevExpress.XtraBars.Bar barCorrespondence;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExportExcel;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraTab.XtraTabControl tabCorrespondence;

        private DevExpress.XtraTab.XtraTabPage tabIncoming;
        private DevExpress.XtraGrid.GridControl grdIncoming;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIncoming;
        private DevExpress.XtraGrid.Columns.GridColumn colIncomingSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colIncomingReference;
        private DevExpress.XtraGrid.Columns.GridColumn colIncomingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIncomingStatus;

        private DevExpress.XtraTab.XtraTabPage tabOutgoing;
        private DevExpress.XtraGrid.GridControl grdOutgoing;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutgoing;
        private DevExpress.XtraGrid.Columns.GridColumn colOutgoingSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colOutgoingReference;
        private DevExpress.XtraGrid.Columns.GridColumn colOutgoingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOutgoingStatus;

        private DevExpress.XtraTab.XtraTabPage tabInternal;
        private DevExpress.XtraGrid.GridControl grdInternal;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInternal;
        private DevExpress.XtraGrid.Columns.GridColumn colInternalSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colInternalReference;
        private DevExpress.XtraGrid.Columns.GridColumn colInternalDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInternalStatus;

        private DevExpress.XtraEditors.PanelControl pnlLoadingState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText;
        private DevExpress.XtraEditors.PanelControl pnlEmptyState;
        private DevExpress.XtraEditors.SvgImageBox svgEmptyIcon;
        private DevExpress.XtraEditors.LabelControl lblEmptyText;
        private DevExpress.XtraEditors.PanelControl pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}
