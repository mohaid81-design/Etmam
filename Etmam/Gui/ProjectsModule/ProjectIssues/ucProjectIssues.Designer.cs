namespace Etmam
{
    partial class ucProjectIssues
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
            barManagerIssues = new DevExpress.XtraBars.BarManager(components);
            barIssues = new DevExpress.XtraBars.Bar();
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

            grdIssues = new DevExpress.XtraGrid.GridControl();
            gvIssues = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIssueNo = new DevExpress.XtraGrid.Columns.GridColumn();
            colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colResolution = new DevExpress.XtraGrid.Columns.GridColumn();
            gridFormatRulePriorityHigh = new DevExpress.XtraGrid.GridFormatRule();
            formatConditionRuleValuePriorityHigh = new DevExpress.XtraEditors.FormatConditionRuleValue();
            gridFormatRulePriorityMedium = new DevExpress.XtraGrid.GridFormatRule();
            formatConditionRuleValuePriorityMedium = new DevExpress.XtraEditors.FormatConditionRuleValue();
            gridFormatRulePriorityLow = new DevExpress.XtraGrid.GridFormatRule();
            formatConditionRuleValuePriorityLow = new DevExpress.XtraEditors.FormatConditionRuleValue();

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

            ((System.ComponentModel.ISupportInitialize)barManagerIssues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdIssues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvIssues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            SuspendLayout();
            //
            // barManagerIssues
            //
            barManagerIssues.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barIssues, barStatus });
            barManagerIssues.DockControls.Add(barDockControlTop);
            barManagerIssues.DockControls.Add(barDockControlBottom);
            barManagerIssues.DockControls.Add(barDockControlLeft);
            barManagerIssues.DockControls.Add(barDockControlRight);
            barManagerIssues.Form = this;
            barManagerIssues.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiEdit, bbiDelete, bbiPrint, bbiExportExcel, sbiRecordCount });
            barManagerIssues.MainMenu = barIssues;
            barManagerIssues.MaxItemId = 6;
            barManagerIssues.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerIssues.StatusBar = barStatus;
            //
            // barIssues
            //
            barIssues.BarName = "شريط أدوات المشكلات";
            barIssues.DockCol = 0;
            barIssues.DockRow = 0;
            barIssues.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barIssues.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barIssues.OptionsBar.AllowQuickCustomization = false;
            barIssues.OptionsBar.DrawDragBorder = false;
            barIssues.OptionsBar.MinHeight = 34;
            barIssues.OptionsBar.UseWholeRow = true;
            barIssues.Text = "شريط أدوات المشكلات";
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
            sbiRecordCount.Caption = "عدد المشكلات: 0";
            sbiRecordCount.Id = 5;
            sbiRecordCount.Name = "sbiRecordCount";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerIssues;
            barDockControlTop.Size = new Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 796);
            barDockControlBottom.Manager = barManagerIssues;
            barDockControlBottom.Size = new Size(1366, 24);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerIssues;
            barDockControlLeft.Size = new Size(0, 762);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerIssues;
            barDockControlRight.Size = new Size(0, 762);
            //
            // grdIssues
            //
            grdIssues.Dock = DockStyle.Fill;
            grdIssues.Location = new Point(0, 34);
            grdIssues.MainView = gvIssues;
            grdIssues.MenuManager = barManagerIssues;
            grdIssues.Name = "grdIssues";
            grdIssues.Size = new Size(1366, 762);
            grdIssues.TabIndex = 0;
            grdIssues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvIssues });
            //
            // gvIssues
            //
            gvIssues.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvIssues.Appearance.HeaderPanel.Options.UseFont = true;
            gvIssues.Appearance.Row.Font = new Font("Cairo", 8F);
            gvIssues.Appearance.Row.Options.UseFont = true;
            gvIssues.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIssueNo, colTitle, colPriority, colOwner, colDueDate, colStatus, colResolution });
            gvIssues.FormatRules.AddRange(new DevExpress.XtraGrid.GridFormatRule[] { gridFormatRulePriorityHigh, gridFormatRulePriorityMedium, gridFormatRulePriorityLow });
            gvIssues.GridControl = grdIssues;
            gvIssues.Name = "gvIssues";
            gvIssues.OptionsView.ColumnAutoWidth = false;
            gvIssues.OptionsView.ShowAutoFilterRow = true;
            gvIssues.OptionsView.ShowFooter = true;
            //
            // colIssueNo
            //
            colIssueNo.Caption = "رقم المشكلة";
            colIssueNo.FieldName = "IssueNo";
            colIssueNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colIssueNo.Name = "colIssueNo";
            colIssueNo.OptionsColumn.AllowEdit = false;
            colIssueNo.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "IssueNo", "العدد: {0}") });
            colIssueNo.Visible = true;
            colIssueNo.VisibleIndex = 0;
            colIssueNo.Width = 110;
            //
            // colTitle
            //
            colTitle.Caption = "العنوان";
            colTitle.FieldName = "Title";
            colTitle.Name = "colTitle";
            colTitle.OptionsColumn.AllowEdit = false;
            colTitle.Visible = true;
            colTitle.VisibleIndex = 1;
            colTitle.Width = 340;
            //
            // colPriority
            //
            colPriority.Caption = "الأولوية";
            colPriority.FieldName = "Priority";
            colPriority.Name = "colPriority";
            colPriority.OptionsColumn.AllowEdit = false;
            colPriority.Visible = true;
            colPriority.VisibleIndex = 2;
            colPriority.Width = 110;
            //
            // colOwner
            //
            colOwner.Caption = "المسؤول";
            colOwner.FieldName = "Owner";
            colOwner.Name = "colOwner";
            colOwner.OptionsColumn.AllowEdit = false;
            colOwner.Visible = true;
            colOwner.VisibleIndex = 3;
            colOwner.Width = 160;
            //
            // colDueDate
            //
            colDueDate.Caption = "تاريخ الاستحقاق";
            colDueDate.DisplayFormat.FormatString = "d";
            colDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDueDate.FieldName = "DueDate";
            colDueDate.Name = "colDueDate";
            colDueDate.OptionsColumn.AllowEdit = false;
            colDueDate.Visible = true;
            colDueDate.VisibleIndex = 4;
            colDueDate.Width = 130;
            //
            // colStatus
            //
            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.OptionsColumn.AllowEdit = false;
            colStatus.Visible = true;
            colStatus.VisibleIndex = 5;
            colStatus.Width = 120;
            //
            // colResolution
            //
            colResolution.Caption = "الحل";
            colResolution.FieldName = "Resolution";
            colResolution.Name = "colResolution";
            colResolution.OptionsColumn.AllowEdit = false;
            colResolution.Visible = true;
            colResolution.VisibleIndex = 6;
            colResolution.Width = 300;
            //
            // gridFormatRulePriorityHigh
            //
            gridFormatRulePriorityHigh.Column = colPriority;
            gridFormatRulePriorityHigh.Name = "gridFormatRulePriorityHigh";
            gridFormatRulePriorityHigh.Rule = formatConditionRuleValuePriorityHigh;
            //
            // formatConditionRuleValuePriorityHigh
            //
            formatConditionRuleValuePriorityHigh.Appearance.BackColor = Color.FromArgb(253, 237, 236);
            formatConditionRuleValuePriorityHigh.Appearance.ForeColor = Color.FromArgb(192, 80, 77);
            formatConditionRuleValuePriorityHigh.Appearance.Options.UseBackColor = true;
            formatConditionRuleValuePriorityHigh.Appearance.Options.UseForeColor = true;
            formatConditionRuleValuePriorityHigh.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValuePriorityHigh.Value1 = "عالية";
            //
            // gridFormatRulePriorityMedium
            //
            gridFormatRulePriorityMedium.Column = colPriority;
            gridFormatRulePriorityMedium.Name = "gridFormatRulePriorityMedium";
            gridFormatRulePriorityMedium.Rule = formatConditionRuleValuePriorityMedium;
            //
            // formatConditionRuleValuePriorityMedium
            //
            formatConditionRuleValuePriorityMedium.Appearance.BackColor = Color.FromArgb(255, 246, 229);
            formatConditionRuleValuePriorityMedium.Appearance.ForeColor = Color.FromArgb(201, 138, 27);
            formatConditionRuleValuePriorityMedium.Appearance.Options.UseBackColor = true;
            formatConditionRuleValuePriorityMedium.Appearance.Options.UseForeColor = true;
            formatConditionRuleValuePriorityMedium.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValuePriorityMedium.Value1 = "متوسطة";
            //
            // gridFormatRulePriorityLow
            //
            gridFormatRulePriorityLow.Column = colPriority;
            gridFormatRulePriorityLow.Name = "gridFormatRulePriorityLow";
            gridFormatRulePriorityLow.Rule = formatConditionRuleValuePriorityLow;
            //
            // formatConditionRuleValuePriorityLow
            //
            formatConditionRuleValuePriorityLow.Appearance.BackColor = Color.FromArgb(234, 247, 239);
            formatConditionRuleValuePriorityLow.Appearance.ForeColor = Color.FromArgb(46, 158, 91);
            formatConditionRuleValuePriorityLow.Appearance.Options.UseBackColor = true;
            formatConditionRuleValuePriorityLow.Appearance.Options.UseForeColor = true;
            formatConditionRuleValuePriorityLow.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValuePriorityLow.Value1 = "منخفضة";
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
            lblLoadingText.Text = "جاري تحميل المشكلات...";
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
            lblEmptyText.Text = "لا توجد مشكلات مسجلة";
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
            lblErrorText.Text = "حدث خطأ أثناء تحميل المشكلات";
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
            // ucProjectIssues
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grdIssues);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucProjectIssues";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 820);
            ((System.ComponentModel.ISupportInitialize)barManagerIssues).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdIssues).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvIssues).EndInit();
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

        private DevExpress.XtraBars.BarManager barManagerIssues;
        private DevExpress.XtraBars.Bar barIssues;
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

        private DevExpress.XtraGrid.GridControl grdIssues;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIssues;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colResolution;
        private DevExpress.XtraGrid.GridFormatRule gridFormatRulePriorityHigh;
        private DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValuePriorityHigh;
        private DevExpress.XtraGrid.GridFormatRule gridFormatRulePriorityMedium;
        private DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValuePriorityMedium;
        private DevExpress.XtraGrid.GridFormatRule gridFormatRulePriorityLow;
        private DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValuePriorityLow;

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
