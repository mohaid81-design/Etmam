namespace Etmam
{
    partial class ucProjectDocuments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProjectDocuments));
            barManagerDocuments = new DevExpress.XtraBars.BarManager(components);
            barDocuments = new DevExpress.XtraBars.Bar();
            bbiUpload = new DevExpress.XtraBars.BarButtonItem();
            bbiDownload = new DevExpress.XtraBars.BarButtonItem();
            bbiVersion = new DevExpress.XtraBars.BarButtonItem();
            bbiApprove = new DevExpress.XtraBars.BarButtonItem();
            bbiReject = new DevExpress.XtraBars.BarButtonItem();
            bbiWorkflow = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiRecordCount = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            splitDocuments = new DevExpress.XtraEditors.SplitContainerControl();
            lblDocPreviewPlaceholder = new DevExpress.XtraEditors.LabelControl();
            lblDocPreviewTitle = new DevExpress.XtraEditors.LabelControl();
            svgDocPreviewIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();
            lblErrorText = new DevExpress.XtraEditors.LabelControl();
            svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            lblEmptyText = new DevExpress.XtraEditors.LabelControl();
            svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            lblLoadingText = new DevExpress.XtraEditors.LabelControl();
            svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            grdDocuments = new DevExpress.XtraGrid.GridControl();
            gvDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            colDocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocWorkflow = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManagerDocuments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitDocuments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitDocuments.Panel1).BeginInit();
            splitDocuments.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitDocuments.Panel2).BeginInit();
            splitDocuments.Panel2.SuspendLayout();
            splitDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgDocPreviewIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit();
            pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit();
            pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit();
            pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdDocuments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvDocuments).BeginInit();
            SuspendLayout();
            // 
            // barManagerDocuments
            // 
            barManagerDocuments.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barDocuments, barStatus });
            barManagerDocuments.DockControls.Add(barDockControlTop);
            barManagerDocuments.DockControls.Add(barDockControlBottom);
            barManagerDocuments.DockControls.Add(barDockControlLeft);
            barManagerDocuments.DockControls.Add(barDockControlRight);
            barManagerDocuments.Form = this;
            barManagerDocuments.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiUpload, bbiDownload, bbiVersion, bbiApprove, bbiReject, bbiWorkflow, sbiRecordCount });
            barManagerDocuments.MainMenu = barDocuments;
            barManagerDocuments.MaxItemId = 7;
            barManagerDocuments.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManagerDocuments.StatusBar = barStatus;
            // 
            // barDocuments
            // 
            barDocuments.BarName = "شريط أدوات المستندات";
            barDocuments.DockCol = 0;
            barDocuments.DockRow = 0;
            barDocuments.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barDocuments.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiUpload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDownload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiVersion, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiApprove, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiReject, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiWorkflow, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            barDocuments.OptionsBar.AllowQuickCustomization = false;
            barDocuments.OptionsBar.DrawDragBorder = false;
            barDocuments.OptionsBar.MinHeight = 34;
            barDocuments.OptionsBar.UseWholeRow = true;
            barDocuments.Text = "شريط أدوات المستندات";
            // 
            // bbiUpload
            // 
            bbiUpload.Caption = "رفع";
            bbiUpload.Id = 0;
            bbiUpload.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiUpload.ImageOptions.SvgImage");
            bbiUpload.Name = "bbiUpload";
            bbiUpload.ItemClick += bbiUpload_ItemClick;
            // 
            // bbiDownload
            // 
            bbiDownload.Caption = "تنزيل";
            bbiDownload.Id = 1;
            bbiDownload.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiDownload.ImageOptions.SvgImage");
            bbiDownload.Name = "bbiDownload";
            bbiDownload.ItemClick += bbiDownload_ItemClick;
            // 
            // bbiVersion
            // 
            bbiVersion.Caption = "الإصدارات";
            bbiVersion.Id = 2;
            bbiVersion.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiVersion.ImageOptions.SvgImage");
            bbiVersion.Name = "bbiVersion";
            bbiVersion.ItemClick += bbiVersion_ItemClick;
            // 
            // bbiApprove
            // 
            bbiApprove.Caption = "اعتماد";
            bbiApprove.Id = 3;
            bbiApprove.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiApprove.ImageOptions.SvgImage");
            bbiApprove.Name = "bbiApprove";
            bbiApprove.ItemClick += bbiApprove_ItemClick;
            // 
            // bbiReject
            // 
            bbiReject.Caption = "رفض";
            bbiReject.Id = 4;
            bbiReject.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiReject.ImageOptions.SvgImage");
            bbiReject.Name = "bbiReject";
            bbiReject.ItemClick += bbiReject_ItemClick;
            // 
            // bbiWorkflow
            // 
            bbiWorkflow.Caption = "سير العمل";
            bbiWorkflow.Id = 5;
            bbiWorkflow.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiWorkflow.ImageOptions.SvgImage");
            bbiWorkflow.Name = "bbiWorkflow";
            bbiWorkflow.ItemClick += bbiWorkflow_ItemClick;
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
            sbiRecordCount.Caption = "عدد المستندات: 0";
            sbiRecordCount.Id = 6;
            sbiRecordCount.Name = "sbiRecordCount";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManagerDocuments;
            barDockControlTop.Margin = new Padding(3, 5, 3, 5);
            barDockControlTop.Size = new Size(1366, 34);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 1264);
            barDockControlBottom.Manager = barManagerDocuments;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(1366, 29);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 34);
            barDockControlLeft.Manager = barManagerDocuments;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 1230);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1366, 34);
            barDockControlRight.Manager = barManagerDocuments;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 1230);
            // 
            // splitDocuments
            // 
            splitDocuments.Dock = DockStyle.Fill;
            splitDocuments.Horizontal = false;
            splitDocuments.Location = new Point(0, 34);
            splitDocuments.Margin = new Padding(3, 5, 3, 5);
            splitDocuments.Name = "splitDocuments";
            // 
            // splitDocuments.Panel1
            // 
            splitDocuments.Panel1.Controls.Add(lblDocPreviewPlaceholder);
            splitDocuments.Panel1.Controls.Add(lblDocPreviewTitle);
            splitDocuments.Panel1.Controls.Add(svgDocPreviewIcon);
            splitDocuments.Panel1.Text = "معاينة المستند";
            // 
            // splitDocuments.Panel2
            // 
            splitDocuments.Panel2.Controls.Add(pnlErrorState);
            splitDocuments.Panel2.Controls.Add(pnlEmptyState);
            splitDocuments.Panel2.Controls.Add(pnlLoadingState);
            splitDocuments.Panel2.Controls.Add(grdDocuments);
            splitDocuments.Panel2.Text = "المستندات";
            splitDocuments.Size = new Size(1366, 1230);
            splitDocuments.SplitterPosition = 523;
            splitDocuments.TabIndex = 0;
            // 
            // lblDocPreviewPlaceholder
            // 
            lblDocPreviewPlaceholder.Anchor = AnchorStyles.None;
            lblDocPreviewPlaceholder.Appearance.Font = new Font("Cairo", 9F);
            lblDocPreviewPlaceholder.Appearance.ForeColor = Color.FromArgb(107, 114, 128);
            lblDocPreviewPlaceholder.Appearance.Options.UseFont = true;
            lblDocPreviewPlaceholder.Appearance.Options.UseForeColor = true;
            lblDocPreviewPlaceholder.Appearance.Options.UseTextOptions = true;
            lblDocPreviewPlaceholder.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblDocPreviewPlaceholder.Location = new Point(70, 311);
            lblDocPreviewPlaceholder.Margin = new Padding(3, 5, 3, 5);
            lblDocPreviewPlaceholder.Name = "lblDocPreviewPlaceholder";
            lblDocPreviewPlaceholder.Size = new Size(207, 23);
            lblDocPreviewPlaceholder.TabIndex = 2;
            lblDocPreviewPlaceholder.Text = "اختر مستنداً من القائمة لعرض معاينته هنا";
            // 
            // lblDocPreviewTitle
            // 
            lblDocPreviewTitle.Anchor = AnchorStyles.None;
            lblDocPreviewTitle.Appearance.Font = new Font("Cairo", 10F, FontStyle.Bold);
            lblDocPreviewTitle.Appearance.Options.UseFont = true;
            lblDocPreviewTitle.Location = new Point(115, 271);
            lblDocPreviewTitle.Margin = new Padding(3, 5, 3, 5);
            lblDocPreviewTitle.Name = "lblDocPreviewTitle";
            lblDocPreviewTitle.Size = new Size(95, 26);
            lblDocPreviewTitle.TabIndex = 1;
            lblDocPreviewTitle.Text = "معاينة المستند";
            // 
            // svgDocPreviewIcon
            // 
            svgDocPreviewIcon.Location = new Point(138, 154);
            svgDocPreviewIcon.Margin = new Padding(3, 5, 3, 5);
            svgDocPreviewIcon.Name = "svgDocPreviewIcon";
            svgDocPreviewIcon.Size = new Size(64, 98);
            svgDocPreviewIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgDocPreviewIcon.SvgImage");
            svgDocPreviewIcon.TabIndex = 0;
            // 
            // pnlErrorState
            // 
            pnlErrorState.Controls.Add(btnRetry);
            pnlErrorState.Controls.Add(lblErrorText);
            pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Dock = DockStyle.Fill;
            pnlErrorState.Location = new Point(0, 0);
            pnlErrorState.Margin = new Padding(3, 5, 3, 5);
            pnlErrorState.Name = "pnlErrorState";
            pnlErrorState.Size = new Size(1366, 697);
            pnlErrorState.TabIndex = 3;
            pnlErrorState.Visible = false;
            // 
            // btnRetry
            // 
            btnRetry.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnRetry.ImageOptions.SvgImage");
            btnRetry.Location = new Point(461, 645);
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
            lblErrorText.Location = new Point(411, 598);
            lblErrorText.Margin = new Padding(3, 5, 3, 5);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(178, 26);
            lblErrorText.TabIndex = 1;
            lblErrorText.Text = "حدث خطأ أثناء تحميل المستندات";
            // 
            // svgErrorIcon
            // 
            svgErrorIcon.Location = new Point(479, 485);
            svgErrorIcon.Margin = new Padding(3, 5, 3, 5);
            svgErrorIcon.Name = "svgErrorIcon";
            svgErrorIcon.Size = new Size(64, 98);
            svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            svgErrorIcon.TabIndex = 0;
            // 
            // pnlEmptyState
            // 
            pnlEmptyState.Controls.Add(lblEmptyText);
            pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Dock = DockStyle.Fill;
            pnlEmptyState.Location = new Point(0, 0);
            pnlEmptyState.Margin = new Padding(3, 5, 3, 5);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1366, 697);
            pnlEmptyState.TabIndex = 2;
            pnlEmptyState.Visible = false;
            // 
            // lblEmptyText
            // 
            lblEmptyText.Appearance.Font = new Font("Cairo", 10F);
            lblEmptyText.Appearance.Options.UseFont = true;
            lblEmptyText.Appearance.Options.UseTextOptions = true;
            lblEmptyText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyText.Location = new Point(411, 629);
            lblEmptyText.Margin = new Padding(3, 5, 3, 5);
            lblEmptyText.Name = "lblEmptyText";
            lblEmptyText.Size = new Size(137, 26);
            lblEmptyText.TabIndex = 1;
            lblEmptyText.Text = "لا توجد مستندات لعرضها";
            // 
            // svgEmptyIcon
            // 
            svgEmptyIcon.Location = new Point(479, 515);
            svgEmptyIcon.Margin = new Padding(3, 5, 3, 5);
            svgEmptyIcon.Name = "svgEmptyIcon";
            svgEmptyIcon.Size = new Size(64, 98);
            svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            svgEmptyIcon.TabIndex = 0;
            // 
            // pnlLoadingState
            // 
            pnlLoadingState.Controls.Add(lblLoadingText);
            pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = DockStyle.Fill;
            pnlLoadingState.Location = new Point(0, 0);
            pnlLoadingState.Margin = new Padding(3, 5, 3, 5);
            pnlLoadingState.Name = "pnlLoadingState";
            pnlLoadingState.Size = new Size(1366, 697);
            pnlLoadingState.TabIndex = 1;
            pnlLoadingState.Visible = false;
            // 
            // lblLoadingText
            // 
            lblLoadingText.Appearance.Font = new Font("Cairo", 10F);
            lblLoadingText.Appearance.Options.UseFont = true;
            lblLoadingText.Appearance.Options.UseTextOptions = true;
            lblLoadingText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblLoadingText.Location = new Point(411, 629);
            lblLoadingText.Margin = new Padding(3, 5, 3, 5);
            lblLoadingText.Name = "lblLoadingText";
            lblLoadingText.Size = new Size(138, 26);
            lblLoadingText.TabIndex = 1;
            lblLoadingText.Text = "جاري تحميل المستندات...";
            // 
            // svgLoadingIcon
            // 
            svgLoadingIcon.Location = new Point(479, 515);
            svgLoadingIcon.Margin = new Padding(3, 5, 3, 5);
            svgLoadingIcon.Name = "svgLoadingIcon";
            svgLoadingIcon.Size = new Size(64, 98);
            svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            svgLoadingIcon.TabIndex = 0;
            // 
            // grdDocuments
            // 
            grdDocuments.Dock = DockStyle.Fill;
            grdDocuments.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            grdDocuments.Location = new Point(0, 0);
            grdDocuments.MainView = gvDocuments;
            grdDocuments.Margin = new Padding(3, 5, 3, 5);
            grdDocuments.MenuManager = barManagerDocuments;
            grdDocuments.Name = "grdDocuments";
            grdDocuments.Size = new Size(1366, 697);
            grdDocuments.TabIndex = 0;
            grdDocuments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvDocuments });
            // 
            // gvDocuments
            // 
            gvDocuments.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvDocuments.Appearance.HeaderPanel.Options.UseFont = true;
            gvDocuments.Appearance.Row.Font = new Font("Cairo", 8F);
            gvDocuments.Appearance.Row.Options.UseFont = true;
            gvDocuments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDocNo, colDocTitle, colDocRevision, colDocDiscipline, colDocStatus, colDocWorkflow });
            gvDocuments.DetailHeight = 538;
            gvDocuments.GridControl = grdDocuments;
            gvDocuments.Name = "gvDocuments";
            gvDocuments.OptionsView.ColumnAutoWidth = false;
            gvDocuments.OptionsView.ShowAutoFilterRow = true;
            gvDocuments.OptionsView.ShowFooter = true;
            // 
            // colDocNo
            // 
            colDocNo.Caption = "رقم المستند";
            colDocNo.FieldName = "DocumentNo";
            colDocNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colDocNo.Name = "colDocNo";
            colDocNo.OptionsColumn.AllowEdit = false;
            colDocNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DocumentNo", "العدد: {0}") });
            colDocNo.Visible = true;
            colDocNo.VisibleIndex = 0;
            colDocNo.Width = 140;
            // 
            // colDocTitle
            // 
            colDocTitle.Caption = "العنوان";
            colDocTitle.FieldName = "Title";
            colDocTitle.Name = "colDocTitle";
            colDocTitle.OptionsColumn.AllowEdit = false;
            colDocTitle.Visible = true;
            colDocTitle.VisibleIndex = 1;
            colDocTitle.Width = 320;
            // 
            // colDocRevision
            // 
            colDocRevision.Caption = "المراجعة";
            colDocRevision.FieldName = "Revision";
            colDocRevision.Name = "colDocRevision";
            colDocRevision.OptionsColumn.AllowEdit = false;
            colDocRevision.Visible = true;
            colDocRevision.VisibleIndex = 2;
            colDocRevision.Width = 100;
            // 
            // colDocDiscipline
            // 
            colDocDiscipline.Caption = "التخصص";
            colDocDiscipline.FieldName = "Discipline";
            colDocDiscipline.Name = "colDocDiscipline";
            colDocDiscipline.OptionsColumn.AllowEdit = false;
            colDocDiscipline.Visible = true;
            colDocDiscipline.VisibleIndex = 3;
            colDocDiscipline.Width = 150;
            // 
            // colDocStatus
            // 
            colDocStatus.Caption = "الحالة";
            colDocStatus.FieldName = "Status";
            colDocStatus.Name = "colDocStatus";
            colDocStatus.OptionsColumn.AllowEdit = false;
            colDocStatus.Visible = true;
            colDocStatus.VisibleIndex = 4;
            colDocStatus.Width = 130;
            // 
            // colDocWorkflow
            // 
            colDocWorkflow.Caption = "سير العمل";
            colDocWorkflow.FieldName = "WorkflowStatus";
            colDocWorkflow.Name = "colDocWorkflow";
            colDocWorkflow.OptionsColumn.AllowEdit = false;
            colDocWorkflow.Visible = true;
            colDocWorkflow.VisibleIndex = 5;
            colDocWorkflow.Width = 150;
            // 
            // ucProjectDocuments
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitDocuments);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucProjectDocuments";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1366, 1293);
            ((System.ComponentModel.ISupportInitialize)barManagerDocuments).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitDocuments.Panel1).EndInit();
            splitDocuments.Panel1.ResumeLayout(false);
            splitDocuments.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitDocuments.Panel2).EndInit();
            splitDocuments.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitDocuments).EndInit();
            splitDocuments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)svgDocPreviewIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit();
            pnlErrorState.ResumeLayout(false);
            pnlErrorState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit();
            pnlEmptyState.ResumeLayout(false);
            pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit();
            pnlLoadingState.ResumeLayout(false);
            pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdDocuments).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvDocuments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerDocuments;
        private DevExpress.XtraBars.Bar barDocuments;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarButtonItem bbiUpload;
        private DevExpress.XtraBars.BarButtonItem bbiDownload;
        private DevExpress.XtraBars.BarButtonItem bbiVersion;
        private DevExpress.XtraBars.BarButtonItem bbiApprove;
        private DevExpress.XtraBars.BarButtonItem bbiReject;
        private DevExpress.XtraBars.BarButtonItem bbiWorkflow;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraEditors.SplitContainerControl splitDocuments;
        private DevExpress.XtraEditors.SvgImageBox svgDocPreviewIcon;
        private DevExpress.XtraEditors.LabelControl lblDocPreviewTitle;
        private DevExpress.XtraEditors.LabelControl lblDocPreviewPlaceholder;

        private DevExpress.XtraGrid.GridControl grdDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocuments;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colDocRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn colDocStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDocWorkflow;

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
