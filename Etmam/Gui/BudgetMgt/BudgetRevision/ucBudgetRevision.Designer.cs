namespace Etmam
{
    partial class ucBudgetRevision
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBudgetRevision));
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiNewRevision = new DevExpress.XtraBars.BarButtonItem();
            bbiApprove = new DevExpress.XtraBars.BarButtonItem();
            bbiReject = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            pnlTimeline = new DevExpress.XtraEditors.PanelControl();
            grpTimeline = new DevExpress.XtraEditors.GroupControl();
            lblRev0 = new DevExpress.XtraEditors.LabelControl();
            lblRev1 = new DevExpress.XtraEditors.LabelControl();
            lblRev2 = new DevExpress.XtraEditors.LabelControl();
            lblRev3 = new DevExpress.XtraEditors.LabelControl();
            lblRev4 = new DevExpress.XtraEditors.LabelControl();
            grpRevisions = new DevExpress.XtraEditors.GroupControl();
            grdRevisions = new DevExpress.XtraGrid.GridControl();
            gvRevisions = new DevExpress.XtraGrid.Views.Grid.GridView();
            colRevNo = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevUser = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevReason = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevAmountBefore = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevAmountAfter = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            grpComparison = new DevExpress.XtraEditors.GroupControl();
            pnlOldBudget = new DevExpress.XtraEditors.PanelControl();
            lblOldBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            lblOldBudgetValue = new DevExpress.XtraEditors.LabelControl();
            pnlNewBudget = new DevExpress.XtraEditors.PanelControl();
            lblNewBudgetTitle = new DevExpress.XtraEditors.LabelControl();
            lblNewBudgetValue = new DevExpress.XtraEditors.LabelControl();
            pnlDiffPanel = new DevExpress.XtraEditors.PanelControl();
            lblDiffTitle = new DevExpress.XtraEditors.LabelControl();
            lblDiffValue = new DevExpress.XtraEditors.LabelControl();
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

            ((System.ComponentModel.ISupportInitialize)barManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlTimeline).BeginInit(); pnlTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpTimeline).BeginInit(); grpTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpRevisions).BeginInit(); grpRevisions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdRevisions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvRevisions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpComparison).BeginInit(); grpComparison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlOldBudget).BeginInit(); pnlOldBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlNewBudget).BeginInit(); pnlNewBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlDiffPanel).BeginInit(); pnlDiffPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit(); pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit(); pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit(); pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();

            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain });
            
            barManagerMain.Form = this; barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNewRevision, bbiApprove, bbiReject, bbiPrint });
            barManagerMain.MainMenu = barMain; barManagerMain.MaxItemId = 4; barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barMain.BarName = "شريط أدوات مراجعات الموازنة"; barMain.DockCol = 0; barMain.DockRow = 0; barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNewRevision, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiApprove, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiReject, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
            });
            barMain.OptionsBar.AllowQuickCustomization = false; barMain.OptionsBar.DrawDragBorder = false; barMain.OptionsBar.MinHeight = 34; barMain.OptionsBar.UseWholeRow = true; barMain.Text = "شريط أدوات مراجعات الموازنة";
            bbiNewRevision.Caption = "مراجعة جديدة"; bbiNewRevision.Id = 0; bbiNewRevision.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiNewBOQ.ImageOptions.SvgImage"); bbiNewRevision.Name = "bbiNewRevision"; bbiNewRevision.ItemClick += bbiNewRevision_ItemClick;
            bbiApprove.Caption = "موافقة"; bbiApprove.Id = 1; bbiApprove.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiApprove.ImageOptions.SvgImage"); bbiApprove.Name = "bbiApprove"; bbiApprove.ItemClick += bbiApprove_ItemClick;
            bbiReject.Caption = "رفض"; bbiReject.Id = 2; bbiReject.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnClearFilters.ImageOptions.SvgImage"); bbiReject.Name = "bbiReject"; bbiReject.ItemClick += bbiReject_ItemClick;
            bbiPrint.Caption = "طباعة"; bbiPrint.Id = 3; bbiPrint.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiPrint.ImageOptions.SvgImage"); bbiPrint.Name = "bbiPrint"; bbiPrint.ItemClick += bbiPrint_ItemClick;
            barDockControlTop.CausesValidation = false; barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top; barDockControlTop.Location = new System.Drawing.Point(0, 0); barDockControlTop.Manager = barManagerMain; barDockControlTop.Size = new System.Drawing.Size(1366, 34);
            barDockControlBottom.CausesValidation = false; barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom; barDockControlBottom.Location = new System.Drawing.Point(0, 902); barDockControlBottom.Manager = barManagerMain; barDockControlBottom.Size = new System.Drawing.Size(1366, 0);
            barDockControlLeft.CausesValidation = false; barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left; barDockControlLeft.Location = new System.Drawing.Point(0, 34); barDockControlLeft.Manager = barManagerMain; barDockControlLeft.Size = new System.Drawing.Size(0, 868);
            barDockControlRight.CausesValidation = false; barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right; barDockControlRight.Location = new System.Drawing.Point(1366, 34); barDockControlRight.Manager = barManagerMain; barDockControlRight.Size = new System.Drawing.Size(0, 868);

            // Timeline panel
            pnlTimeline.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlTimeline.Controls.Add(grpTimeline);
            pnlTimeline.Dock = System.Windows.Forms.DockStyle.Top; pnlTimeline.Location = new System.Drawing.Point(0, 34); pnlTimeline.Name = "pnlTimeline"; pnlTimeline.Size = new System.Drawing.Size(1366, 80);
            grpTimeline.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpTimeline.AppearanceCaption.Options.UseFont = true;
            grpTimeline.Controls.AddRange(new System.Windows.Forms.Control[] { lblRev0, lblRev1, lblRev2, lblRev3, lblRev4 });
            grpTimeline.Dock = System.Windows.Forms.DockStyle.Fill; grpTimeline.Name = "grpTimeline"; grpTimeline.Text = "مراحل المراجعة";
            lblRev0.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblRev0.Appearance.Options.UseFont = true;
            lblRev0.Location = new System.Drawing.Point(1092, 28); lblRev0.Name = "lblRev0"; lblRev0.Text = "المراجعة 0 (أصلية)";
            lblRev1.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblRev1.Appearance.Options.UseFont = true;
            lblRev1.Location = new System.Drawing.Point(822, 28); lblRev1.Name = "lblRev1"; lblRev1.Text = "المراجعة 1";
            lblRev2.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblRev2.Appearance.Options.UseFont = true;
            lblRev2.Location = new System.Drawing.Point(552, 28); lblRev2.Name = "lblRev2"; lblRev2.Text = "المراجعة 2";
            lblRev3.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblRev3.Appearance.Options.UseFont = true;
            lblRev3.Location = new System.Drawing.Point(282, 28); lblRev3.Name = "lblRev3"; lblRev3.Text = "المراجعة 3";
            lblRev4.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblRev4.Appearance.Options.UseFont = true;
            lblRev4.Location = new System.Drawing.Point(12, 28); lblRev4.Name = "lblRev4"; lblRev4.Text = "المراجعة 4";

            // Revisions grid
            grpRevisions.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpRevisions.AppearanceCaption.Options.UseFont = true;
            grpRevisions.Controls.Add(grdRevisions); grpRevisions.Dock = System.Windows.Forms.DockStyle.Top; grpRevisions.Location = new System.Drawing.Point(0, 114); grpRevisions.Name = "grpRevisions"; grpRevisions.Size = new System.Drawing.Size(1366, 340); grpRevisions.Text = "جدول المراجعات";
            grdRevisions.Dock = System.Windows.Forms.DockStyle.Fill; grdRevisions.MainView = gvRevisions; grdRevisions.Name = "grdRevisions"; grdRevisions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvRevisions });
            gvRevisions.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F); gvRevisions.Appearance.Row.Options.UseFont = true;
            gvRevisions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colRevNo, colRevDate, colRevUser, colRevReason, colRevAmountBefore, colRevAmountAfter, colRevDiff, colRevStatus });
            gvRevisions.GridControl = grdRevisions; gvRevisions.Name = "gvRevisions"; gvRevisions.OptionsBehavior.Editable = false; gvRevisions.OptionsView.ShowAutoFilterRow = true; gvRevisions.OptionsView.ShowFooter = true;
            colRevNo.Caption = "رقم المراجعة"; colRevNo.FieldName = "RevisionNo"; colRevNo.Name = "colRevNo"; colRevNo.Visible = true; colRevNo.Width = 100;
            colRevDate.Caption = "التاريخ"; colRevDate.FieldName = "RevisionDate"; colRevDate.Name = "colRevDate"; colRevDate.Visible = true; colRevDate.Width = 110;
            colRevUser.Caption = "المستخدم"; colRevUser.FieldName = "User"; colRevUser.Name = "colRevUser"; colRevUser.Visible = true; colRevUser.Width = 150;
            colRevReason.Caption = "سبب المراجعة"; colRevReason.FieldName = "Reason"; colRevReason.Name = "colRevReason"; colRevReason.Visible = true; colRevReason.Width = 280;
            colRevAmountBefore.Caption = "المبلغ قبل"; colRevAmountBefore.FieldName = "AmountBefore"; colRevAmountBefore.Name = "colRevAmountBefore"; colRevAmountBefore.Visible = true; colRevAmountBefore.Width = 130; colRevAmountBefore.DisplayFormat.FormatString = "N2"; colRevAmountBefore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colRevAmountAfter.Caption = "المبلغ بعد"; colRevAmountAfter.FieldName = "AmountAfter"; colRevAmountAfter.Name = "colRevAmountAfter"; colRevAmountAfter.Visible = true; colRevAmountAfter.Width = 130; colRevAmountAfter.DisplayFormat.FormatString = "N2"; colRevAmountAfter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colRevDiff.Caption = "الفرق"; colRevDiff.FieldName = "Difference"; colRevDiff.Name = "colRevDiff"; colRevDiff.Visible = true; colRevDiff.Width = 130; colRevDiff.DisplayFormat.FormatString = "N2"; colRevDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colRevStatus.Caption = "الحالة"; colRevStatus.FieldName = "Status"; colRevStatus.Name = "colRevStatus"; colRevStatus.Visible = true; colRevStatus.Width = 100;

            // Comparison panel
            grpComparison.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpComparison.AppearanceCaption.Options.UseFont = true;
            grpComparison.Controls.Add(pnlOldBudget); grpComparison.Controls.Add(pnlNewBudget); grpComparison.Controls.Add(pnlDiffPanel);
            grpComparison.Dock = System.Windows.Forms.DockStyle.Fill; grpComparison.Name = "grpComparison"; grpComparison.Text = "مقارنة المراجعات";

            pnlOldBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlOldBudget.Controls.Add(lblOldBudgetTitle); pnlOldBudget.Controls.Add(lblOldBudgetValue);
            pnlOldBudget.Location = new System.Drawing.Point(922, 20); pnlOldBudget.Name = "pnlOldBudget"; pnlOldBudget.Size = new System.Drawing.Size(436, 130);
            lblOldBudgetTitle.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold); lblOldBudgetTitle.Appearance.Options.UseFont = true;
            lblOldBudgetTitle.Location = new System.Drawing.Point(20, 30); lblOldBudgetTitle.Name = "lblOldBudgetTitle"; lblOldBudgetTitle.Text = "الموازنة القديمة";
            lblOldBudgetValue.Appearance.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold); lblOldBudgetValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); lblOldBudgetValue.Appearance.Options.UseFont = true; lblOldBudgetValue.Appearance.Options.UseForeColor = true;
            lblOldBudgetValue.Location = new System.Drawing.Point(20, 70); lblOldBudgetValue.Name = "lblOldBudgetValue"; lblOldBudgetValue.Text = "—";

            pnlNewBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlNewBudget.Controls.Add(lblNewBudgetTitle); pnlNewBudget.Controls.Add(lblNewBudgetValue);
            pnlNewBudget.Location = new System.Drawing.Point(465, 20); pnlNewBudget.Name = "pnlNewBudget"; pnlNewBudget.Size = new System.Drawing.Size(436, 130);
            lblNewBudgetTitle.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold); lblNewBudgetTitle.Appearance.Options.UseFont = true;
            lblNewBudgetTitle.Location = new System.Drawing.Point(20, 30); lblNewBudgetTitle.Name = "lblNewBudgetTitle"; lblNewBudgetTitle.Text = "الموازنة الجديدة";
            lblNewBudgetValue.Appearance.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold); lblNewBudgetValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 117, 182); lblNewBudgetValue.Appearance.Options.UseFont = true; lblNewBudgetValue.Appearance.Options.UseForeColor = true;
            lblNewBudgetValue.Location = new System.Drawing.Point(20, 70); lblNewBudgetValue.Name = "lblNewBudgetValue"; lblNewBudgetValue.Text = "—";

            pnlDiffPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlDiffPanel.Controls.Add(lblDiffTitle); pnlDiffPanel.Controls.Add(lblDiffValue);
            pnlDiffPanel.Location = new System.Drawing.Point(8, 20); pnlDiffPanel.Name = "pnlDiffPanel"; pnlDiffPanel.Size = new System.Drawing.Size(436, 130);
            lblDiffTitle.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold); lblDiffTitle.Appearance.Options.UseFont = true;
            lblDiffTitle.Location = new System.Drawing.Point(20, 30); lblDiffTitle.Name = "lblDiffTitle"; lblDiffTitle.Text = "الفرق";
            lblDiffValue.Appearance.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold); lblDiffValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(192, 80, 77); lblDiffValue.Appearance.Options.UseFont = true; lblDiffValue.Appearance.Options.UseForeColor = true;
            lblDiffValue.Location = new System.Drawing.Point(20, 70); lblDiffValue.Name = "lblDiffValue"; lblDiffValue.Text = "—";

            // State panels
            pnlLoadingState.Controls.Add(lblLoadingText); pnlLoadingState.Controls.Add(svgLoadingIcon); pnlLoadingState.Dock = System.Windows.Forms.DockStyle.Fill; pnlLoadingState.Name = "pnlLoadingState"; pnlLoadingState.Visible = false;
            lblLoadingText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblLoadingText.Appearance.Options.UseFont = true; lblLoadingText.Location = new System.Drawing.Point(543, 310); lblLoadingText.Name = "lblLoadingText"; lblLoadingText.Text = "جاري تحميل المراجعات...";
            svgLoadingIcon.Location = new System.Drawing.Point(651, 210); svgLoadingIcon.Name = "svgLoadingIcon"; svgLoadingIcon.Size = new System.Drawing.Size(64, 64); svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            pnlEmptyState.Controls.Add(lblEmptyText); pnlEmptyState.Controls.Add(svgEmptyIcon); pnlEmptyState.Dock = System.Windows.Forms.DockStyle.Fill; pnlEmptyState.Name = "pnlEmptyState"; pnlEmptyState.Visible = false;
            lblEmptyText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblEmptyText.Appearance.Options.UseFont = true; lblEmptyText.Location = new System.Drawing.Point(543, 310); lblEmptyText.Name = "lblEmptyText"; lblEmptyText.Text = "لا توجد مراجعات موازنة";
            svgEmptyIcon.Location = new System.Drawing.Point(651, 210); svgEmptyIcon.Name = "svgEmptyIcon"; svgEmptyIcon.Size = new System.Drawing.Size(64, 64); svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            pnlErrorState.Controls.Add(btnRetry); pnlErrorState.Controls.Add(lblErrorText); pnlErrorState.Controls.Add(svgErrorIcon); pnlErrorState.Dock = System.Windows.Forms.DockStyle.Fill; pnlErrorState.Name = "pnlErrorState"; pnlErrorState.Visible = false;
            lblErrorText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblErrorText.Appearance.Options.UseFont = true; lblErrorText.Location = new System.Drawing.Point(543, 290); lblErrorText.Name = "lblErrorText"; lblErrorText.Text = "حدث خطأ أثناء التحميل";
            svgErrorIcon.Location = new System.Drawing.Point(651, 190); svgErrorIcon.Name = "svgErrorIcon"; svgErrorIcon.Size = new System.Drawing.Size(64, 64); svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            btnRetry.Appearance.Font = new System.Drawing.Font("Cairo", 9F); btnRetry.Appearance.Options.UseFont = true; btnRetry.Location = new System.Drawing.Point(633, 330); btnRetry.Name = "btnRetry"; btnRetry.Size = new System.Drawing.Size(100, 34); btnRetry.Text = "إعادة المحاولة"; btnRetry.Click += btnRetry_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F); AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(grpComparison); Controls.Add(grpRevisions); Controls.Add(pnlLoadingState); Controls.Add(pnlEmptyState); Controls.Add(pnlErrorState);
            Controls.Add(pnlTimeline); Controls.Add(barDockControlLeft); Controls.Add(barDockControlRight); Controls.Add(barDockControlBottom); Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5); Name = "ucBudgetRevision"; RightToLeft = System.Windows.Forms.RightToLeft.Yes; Size = new System.Drawing.Size(1366, 902);

            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlTimeline).EndInit(); pnlTimeline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpTimeline).EndInit(); grpTimeline.ResumeLayout(false); grpTimeline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grpRevisions).EndInit(); grpRevisions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdRevisions).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvRevisions).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpComparison).EndInit(); grpComparison.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlOldBudget).EndInit(); pnlOldBudget.ResumeLayout(false); pnlOldBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlNewBudget).EndInit(); pnlNewBudget.ResumeLayout(false); pnlNewBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlDiffPanel).EndInit(); pnlDiffPanel.ResumeLayout(false); pnlDiffPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).EndInit(); pnlLoadingState.ResumeLayout(false); pnlLoadingState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).EndInit(); pnlEmptyState.ResumeLayout(false); pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).EndInit(); pnlErrorState.ResumeLayout(false); pnlErrorState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).EndInit();
            ResumeLayout(false);
        }
        #endregion
        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarDockControl barDockControlTop, barDockControlBottom, barDockControlLeft, barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiNewRevision, bbiApprove, bbiReject, bbiPrint;
        private DevExpress.XtraEditors.PanelControl pnlTimeline;
        private DevExpress.XtraEditors.GroupControl grpTimeline;
        private DevExpress.XtraEditors.LabelControl lblRev0, lblRev1, lblRev2, lblRev3, lblRev4;
        private DevExpress.XtraEditors.GroupControl grpRevisions;
        private DevExpress.XtraGrid.GridControl grdRevisions;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRevisions;
        private DevExpress.XtraGrid.Columns.GridColumn colRevNo, colRevDate, colRevUser, colRevReason, colRevAmountBefore, colRevAmountAfter, colRevDiff, colRevStatus;
        private DevExpress.XtraEditors.GroupControl grpComparison;
        private DevExpress.XtraEditors.PanelControl pnlOldBudget, pnlNewBudget, pnlDiffPanel;
        private DevExpress.XtraEditors.LabelControl lblOldBudgetTitle, lblOldBudgetValue, lblNewBudgetTitle, lblNewBudgetValue, lblDiffTitle, lblDiffValue;
        private DevExpress.XtraEditors.PanelControl pnlLoadingState, pnlEmptyState, pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon, svgEmptyIcon, svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText, lblEmptyText, lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}

