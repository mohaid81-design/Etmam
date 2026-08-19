namespace Etmam
{
    partial class ucProjectMeetings
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
            barManagerMeetings = new DevExpress.XtraBars.BarManager(components);
            barMeetings = new DevExpress.XtraBars.Bar();
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

            grdMeetings = new DevExpress.XtraGrid.GridControl();
            gvMeetings = new DevExpress.XtraGrid.Views.Grid.GridView();
            colMeetingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            colMeetingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colChairperson = new DevExpress.XtraGrid.Columns.GridColumn();
            colAttendees = new DevExpress.XtraGrid.Columns.GridColumn();
            colActions = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

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

            ((System.ComponentModel.ISupportInitialize)barManagerMeetings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdMeetings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvMeetings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            SuspendLayout();
            //
            // barManagerMeetings
            //
            barManagerMeetings.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMeetings, barStatus });
            barManagerMeetings.DockControls.Add(barDockControlTop);
            barManagerMeetings.DockControls.Add(barDockControlBottom);
            barManagerMeetings.DockControls.Add(barDockControlLeft);
            barManagerMeetings.DockControls.Add(barDockControlRight);
            barManagerMeetings.Form = this;
            barManagerMeetings.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiEdit, bbiDelete, bbiPrint, bbiExportExcel, sbiRecordCount });
            barManagerMeetings.MainMenu = barMeetings;
            barManagerMeetings.MaxItemId = 6;
            barManagerMeetings.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerMeetings.StatusBar = barStatus;
            //
            // barMeetings
            //
            barMeetings.BarName = "شريط أدوات الاجتماعات";
            barMeetings.DockCol = 0;
            barMeetings.DockRow = 0;
            barMeetings.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMeetings.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barMeetings.OptionsBar.AllowQuickCustomization = false;
            barMeetings.OptionsBar.DrawDragBorder = false;
            barMeetings.OptionsBar.MinHeight = 34;
            barMeetings.OptionsBar.UseWholeRow = true;
            barMeetings.Text = "شريط أدوات الاجتماعات";
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
            sbiRecordCount.Caption = "عدد الاجتماعات: 0";
            sbiRecordCount.Id = 5;
            sbiRecordCount.Name = "sbiRecordCount";
            //
            // barDockControlTop
            //
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerMeetings;
            barDockControlTop.Size = new Size(1366, 34);
            //
            // barDockControlBottom
            //
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 796);
            barDockControlBottom.Manager = barManagerMeetings;
            barDockControlBottom.Size = new Size(1366, 24);
            //
            // barDockControlLeft
            //
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerMeetings;
            barDockControlLeft.Size = new Size(0, 762);
            //
            // barDockControlRight
            //
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerMeetings;
            barDockControlRight.Size = new Size(0, 762);
            //
            // grdMeetings
            //
            grdMeetings.Dock = DockStyle.Fill;
            grdMeetings.Location = new Point(0, 34);
            grdMeetings.MainView = gvMeetings;
            grdMeetings.MenuManager = barManagerMeetings;
            grdMeetings.Name = "grdMeetings";
            grdMeetings.Size = new Size(1366, 762);
            grdMeetings.TabIndex = 0;
            grdMeetings.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvMeetings });
            //
            // gvMeetings
            //
            gvMeetings.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvMeetings.Appearance.HeaderPanel.Options.UseFont = true;
            gvMeetings.Appearance.Row.Font = new Font("Cairo", 8F);
            gvMeetings.Appearance.Row.Options.UseFont = true;
            gvMeetings.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colMeetingNo, colMeetingDate, colChairperson, colAttendees, colActions, colStatus });
            gvMeetings.GridControl = grdMeetings;
            gvMeetings.Name = "gvMeetings";
            gvMeetings.OptionsView.ColumnAutoWidth = false;
            gvMeetings.OptionsView.ShowAutoFilterRow = true;
            gvMeetings.OptionsView.ShowFooter = true;
            //
            // colMeetingNo
            //
            colMeetingNo.Caption = "رقم الاجتماع";
            colMeetingNo.FieldName = "MeetingNo";
            colMeetingNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colMeetingNo.Name = "colMeetingNo";
            colMeetingNo.OptionsColumn.AllowEdit = false;
            colMeetingNo.Summary.AddRange(new DevExpress.XtraGrid.GridColumnSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MeetingNo", "العدد: {0}") });
            colMeetingNo.Visible = true;
            colMeetingNo.VisibleIndex = 0;
            colMeetingNo.Width = 120;
            //
            // colMeetingDate
            //
            colMeetingDate.Caption = "التاريخ";
            colMeetingDate.DisplayFormat.FormatString = "d";
            colMeetingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colMeetingDate.FieldName = "MeetingDate";
            colMeetingDate.Name = "colMeetingDate";
            colMeetingDate.OptionsColumn.AllowEdit = false;
            colMeetingDate.Visible = true;
            colMeetingDate.VisibleIndex = 1;
            colMeetingDate.Width = 130;
            //
            // colChairperson
            //
            colChairperson.Caption = "رئيس الاجتماع";
            colChairperson.FieldName = "Chairperson";
            colChairperson.Name = "colChairperson";
            colChairperson.OptionsColumn.AllowEdit = false;
            colChairperson.Visible = true;
            colChairperson.VisibleIndex = 2;
            colChairperson.Width = 180;
            //
            // colAttendees
            //
            colAttendees.Caption = "الحضور";
            colAttendees.FieldName = "Attendees";
            colAttendees.Name = "colAttendees";
            colAttendees.OptionsColumn.AllowEdit = false;
            colAttendees.Visible = true;
            colAttendees.VisibleIndex = 3;
            colAttendees.Width = 300;
            //
            // colActions
            //
            colActions.Caption = "الإجراءات";
            colActions.FieldName = "Actions";
            colActions.Name = "colActions";
            colActions.OptionsColumn.AllowEdit = false;
            colActions.Visible = true;
            colActions.VisibleIndex = 4;
            colActions.Width = 300;
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
            lblLoadingText.Text = "جاري تحميل الاجتماعات...";
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
            lblEmptyText.Text = "لا توجد اجتماعات مسجلة";
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
            lblErrorText.Text = "حدث خطأ أثناء تحميل الاجتماعات";
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
            // ucProjectMeetings
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grdMeetings);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucProjectMeetings";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 820);
            ((System.ComponentModel.ISupportInitialize)barManagerMeetings).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdMeetings).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvMeetings).EndInit();
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

        private DevExpress.XtraBars.BarManager barManagerMeetings;
        private DevExpress.XtraBars.Bar barMeetings;
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

        private DevExpress.XtraGrid.GridControl grdMeetings;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMeetings;
        private DevExpress.XtraGrid.Columns.GridColumn colMeetingNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMeetingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colChairperson;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendees;
        private DevExpress.XtraGrid.Columns.GridColumn colActions;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;

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
