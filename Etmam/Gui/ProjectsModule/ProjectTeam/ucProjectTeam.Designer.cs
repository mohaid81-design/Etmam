namespace Etmam
{
    partial class ucProjectTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProjectTeam));
            barManagerTeam = new DevExpress.XtraBars.BarManager(components);
            barTeam = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiRemove = new DevExpress.XtraBars.BarButtonItem();
            bbiSendEmail = new DevExpress.XtraBars.BarButtonItem();
            bbiExport = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiRecordCount = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            grdTeam = new DevExpress.XtraGrid.GridControl();
            gvTeam = new DevExpress.XtraGrid.Views.Grid.GridView();
            colEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colFinishDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            lblLoadingText = new DevExpress.XtraEditors.LabelControl();
            svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            lblEmptyText = new DevExpress.XtraEditors.LabelControl();
            svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();
            lblErrorText = new DevExpress.XtraEditors.LabelControl();
            svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();
            ((System.ComponentModel.ISupportInitialize)barManagerTeam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdTeam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvTeam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();
            // 
            // barManagerTeam
            // 
            barManagerTeam.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barTeam, barStatus });
            barManagerTeam.DockControls.Add(barDockControlTop);
            barManagerTeam.DockControls.Add(barDockControlBottom);
            barManagerTeam.DockControls.Add(barDockControlLeft);
            barManagerTeam.DockControls.Add(barDockControlRight);
            barManagerTeam.Form = this;
            barManagerTeam.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiEdit, bbiRemove, bbiSendEmail, bbiExport, sbiRecordCount });
            barManagerTeam.MainMenu = barTeam;
            barManagerTeam.MaxItemId = 6;
            barManagerTeam.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerTeam.StatusBar = barStatus;
            // 
            // barTeam
            // 
            barTeam.BarName = "شريط أدوات فريق العمل";
            barTeam.DockCol = 0;
            barTeam.DockRow = 0;
            barTeam.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barTeam.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRemove, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSendEmail, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barTeam.OptionsBar.AllowQuickCustomization = false;
            barTeam.OptionsBar.DrawDragBorder = false;
            barTeam.OptionsBar.MinHeight = 34;
            barTeam.OptionsBar.UseWholeRow = true;
            barTeam.Text = "شريط أدوات فريق العمل";
            // 
            // bbiAdd
            // 
            bbiAdd.Caption = "إضافة";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiAdd.ImageOptions.SvgImage");
            bbiAdd.Name = "bbiAdd";
            bbiAdd.ItemClick += bbiAdd_ItemClick;
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 1;
            bbiEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiEdit.ImageOptions.SvgImage");
            bbiEdit.Name = "bbiEdit";
            bbiEdit.ItemClick += bbiEdit_ItemClick;
            // 
            // bbiRemove
            // 
            bbiRemove.Caption = "حذف";
            bbiRemove.Id = 2;
            bbiRemove.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiRemove.ImageOptions.SvgImage");
            bbiRemove.Name = "bbiRemove";
            bbiRemove.ItemClick += bbiRemove_ItemClick;
            // 
            // bbiSendEmail
            // 
            bbiSendEmail.Caption = "إرسال بريد إلكتروني";
            bbiSendEmail.Id = 3;
            bbiSendEmail.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiSendEmail.ImageOptions.SvgImage");
            bbiSendEmail.Name = "bbiSendEmail";
            bbiSendEmail.ItemClick += bbiSendEmail_ItemClick;
            // 
            // bbiExport
            // 
            bbiExport.Caption = "تصدير";
            bbiExport.Id = 4;
            bbiExport.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExport.ImageOptions.SvgImage");
            bbiExport.Name = "bbiExport";
            bbiExport.ItemClick += bbiExport_ItemClick;
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
            sbiRecordCount.Caption = "عدد أعضاء الفريق: 0";
            sbiRecordCount.Id = 5;
            sbiRecordCount.Name = "sbiRecordCount";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerTeam;
            barDockControlTop.Margin = new Padding(3, 5, 3, 5);
            barDockControlTop.Size = new Size(1366, 34);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 710);
            barDockControlBottom.Manager = barManagerTeam;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(1366, 29);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerTeam;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 676);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerTeam;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 676);
            // 
            // grdTeam
            // 
            grdTeam.Dock = DockStyle.Fill;
            grdTeam.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdTeam.Location = new Point(0, 34);
            grdTeam.MainView = gvTeam;
            grdTeam.Margin = new Padding(3, 5, 3, 5);
            grdTeam.MenuManager = barManagerTeam;
            grdTeam.Name = "grdTeam";
            grdTeam.Size = new Size(1366, 676);
            grdTeam.TabIndex = 0;
            grdTeam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvTeam });
            // 
            // gvTeam
            // 
            gvTeam.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvTeam.Appearance.HeaderPanel.Options.UseFont = true;
            gvTeam.Appearance.Row.Font = new Font("Cairo", 8F);
            gvTeam.Appearance.Row.Options.UseFont = true;
            gvTeam.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colEmployee, colRole, colDepartment, colEmail, colPhone, colStartDate, colFinishDate, colStatus });
            gvTeam.DetailHeight = 538;
            gvTeam.GridControl = grdTeam;
            gvTeam.Name = "gvTeam";
            gvTeam.OptionsView.ColumnAutoWidth = false;
            gvTeam.OptionsView.ShowAutoFilterRow = true;
            gvTeam.OptionsView.ShowFooter = true;
            // 
            // colEmployee
            // 
            colEmployee.Caption = "الموظف";
            colEmployee.FieldName = "EmployeeName";
            colEmployee.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colEmployee.Name = "colEmployee";
            colEmployee.OptionsColumn.AllowEdit = false;
            colEmployee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeName", "العدد: {0}") });
            colEmployee.Visible = true;
            colEmployee.VisibleIndex = 0;
            colEmployee.Width = 200;
            // 
            // colRole
            // 
            colRole.Caption = "الدور";
            colRole.FieldName = "Role";
            colRole.Name = "colRole";
            colRole.OptionsColumn.AllowEdit = false;
            colRole.Visible = true;
            colRole.VisibleIndex = 1;
            colRole.Width = 180;
            // 
            // colDepartment
            // 
            colDepartment.Caption = "القسم";
            colDepartment.FieldName = "Department";
            colDepartment.Name = "colDepartment";
            colDepartment.OptionsColumn.AllowEdit = false;
            colDepartment.Visible = true;
            colDepartment.VisibleIndex = 2;
            colDepartment.Width = 180;
            // 
            // colEmail
            // 
            colEmail.Caption = "البريد الإلكتروني";
            colEmail.FieldName = "Email";
            colEmail.Name = "colEmail";
            colEmail.OptionsColumn.AllowEdit = false;
            colEmail.Visible = true;
            colEmail.VisibleIndex = 3;
            colEmail.Width = 220;
            // 
            // colPhone
            // 
            colPhone.Caption = "الهاتف";
            colPhone.FieldName = "Phone";
            colPhone.Name = "colPhone";
            colPhone.OptionsColumn.AllowEdit = false;
            colPhone.Visible = true;
            colPhone.VisibleIndex = 4;
            colPhone.Width = 140;
            // 
            // colStartDate
            // 
            colStartDate.Caption = "تاريخ البدء";
            colStartDate.DisplayFormat.FormatString = "d";
            colStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colStartDate.FieldName = "StartDate";
            colStartDate.Name = "colStartDate";
            colStartDate.OptionsColumn.AllowEdit = false;
            colStartDate.Visible = true;
            colStartDate.VisibleIndex = 5;
            colStartDate.Width = 120;
            // 
            // colFinishDate
            // 
            colFinishDate.Caption = "تاريخ الانتهاء";
            colFinishDate.DisplayFormat.FormatString = "d";
            colFinishDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colFinishDate.FieldName = "FinishDate";
            colFinishDate.Name = "colFinishDate";
            colFinishDate.OptionsColumn.AllowEdit = false;
            colFinishDate.Visible = true;
            colFinishDate.VisibleIndex = 6;
            colFinishDate.Width = 120;
            // 
            // colStatus
            // 
            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.OptionsColumn.AllowEdit = false;
            colStatus.Visible = true;
            colStatus.VisibleIndex = 7;
            colStatus.Width = 110;
            // 
            // pnlLoadingState
            // 
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 34);
            pnlLoadingState.Margin = new Padding(3, 5, 3, 5);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 676);
            pnlLoadingState.TabIndex = 1;
            pnlLoadingState.Visible = false;
            // 
            // lblLoadingText
            // 
            lblLoadingText.Appearance.Font = new Font("Cairo", 10F);
            lblLoadingText.Appearance.Options.UseFont = true;
            lblLoadingText.Appearance.Options.UseTextOptions = true;
            lblLoadingText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblLoadingText.Location = new Point(583, 606);
            lblLoadingText.Margin = new Padding(3, 5, 3, 5);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(152, 26);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل بيانات الفريق...";
            // 
            // svgLoadingIcon
            // 
            svgLoadingIcon.Location = new Point(651, 492);
            svgLoadingIcon.Margin = new Padding(3, 5, 3, 5);
            svgLoadingIcon.Name = "svgLoadingIcon";
            svgLoadingIcon.Size = new Size(64, 98);
            svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            svgLoadingIcon.TabIndex = 0;
            // 
            // pnlEmptyState
            // 
            pnlEmptyState.Controls.Add(lblEmptyText);
            pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Dock = DockStyle.Fill;
            pnlEmptyState.Location = new Point(0, 34);
            pnlEmptyState.Margin = new Padding(3, 5, 3, 5);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 676);
            pnlEmptyState.TabIndex = 2;
            pnlEmptyState.Visible = false;
            // 
            // lblEmptyText
            // 
            lblEmptyText.Appearance.Font = new Font("Cairo", 10F);
            lblEmptyText.Appearance.Options.UseFont = true;
            lblEmptyText.Appearance.Options.UseTextOptions = true;
            lblEmptyText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyText.Location = new Point(583, 606);
            lblEmptyText.Margin = new Padding(3, 5, 3, 5);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(172, 26);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا يوجد أعضاء في فريق العمل";
            // 
            // svgEmptyIcon
            // 
            svgEmptyIcon.Location = new Point(651, 492);
            svgEmptyIcon.Margin = new Padding(3, 5, 3, 5);
            svgEmptyIcon.Name = "svgEmptyIcon";
            svgEmptyIcon.Size = new Size(64, 98);
            svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            svgEmptyIcon.TabIndex = 0;
            // 
            // pnlErrorState
            // 
            pnlErrorState.Controls.Add(btnRetry);
            pnlErrorState.Controls.Add(lblErrorText);
            pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Dock = DockStyle.Fill;
            pnlErrorState.Location = new Point(0, 34);
            pnlErrorState.Margin = new Padding(3, 5, 3, 5);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 676);
            pnlErrorState.TabIndex = 3;
            pnlErrorState.Visible = false;
            // 
            // btnRetry
            // 
            btnRetry.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnRetry.ImageOptions.SvgImage");
            btnRetry.Location = new Point(633, 622);
            btnRetry.Margin = new Padding(3, 5, 3, 5);
            btnRetry.Name = "btnRetry";
            btnRetry.Size = new Size(100, 43);
            btnRetry.TabIndex = 2;
            btnRetry.Text = "إعادة المحاولة";
            btnRetry.Click += btnRetry_Click;
            // 
            // lblErrorText
            // 
            lblErrorText.Appearance.Font = new Font("Cairo", 10F);
            lblErrorText.Appearance.Options.UseFont = true;
            lblErrorText.Appearance.Options.UseTextOptions = true;
            lblErrorText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblErrorText.Location = new Point(583, 575);
            lblErrorText.Margin = new Padding(3, 5, 3, 5);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(192, 26);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل بيانات الفريق";
            // 
            // svgErrorIcon
            // 
            svgErrorIcon.Location = new Point(651, 462);
            svgErrorIcon.Margin = new Padding(3, 5, 3, 5);
            svgErrorIcon.Name = "svgErrorIcon";
            svgErrorIcon.Size = new Size(64, 98);
            svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            svgErrorIcon.TabIndex = 0;
            // 
            // ucProjectTeam
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grdTeam);
            Controls.Add(pnlLoadingState);
            Controls.Add(pnlEmptyState);
            Controls.Add(pnlErrorState);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucProjectTeam";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 739);
            ((System.ComponentModel.ISupportInitialize)barManagerTeam).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdTeam).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvTeam).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit();
            pnlLoadingState.ResumeLayout(false);
            pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit();
            pnlEmptyState.ResumeLayout(false);
            pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit();
            pnlErrorState.ResumeLayout(false);
            pnlErrorState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerTeam;
        private DevExpress.XtraBars.Bar barTeam;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiRemove;
        private DevExpress.XtraBars.BarButtonItem bbiSendEmail;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraGrid.GridControl grdTeam;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTeam;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFinishDate;
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
