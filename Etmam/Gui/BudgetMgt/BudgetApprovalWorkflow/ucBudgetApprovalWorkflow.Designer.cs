namespace Etmam
{
    partial class ucBudgetApprovalWorkflow
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBudgetApprovalWorkflow));
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiApprove = new DevExpress.XtraBars.BarButtonItem();
            bbiReject = new DevExpress.XtraBars.BarButtonItem();
            bbiReturn = new DevExpress.XtraBars.BarButtonItem();
            bbiDelegate = new DevExpress.XtraBars.BarButtonItem();
            bbiAddComment = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            // Left: Approval Queue
            grpApprovalQueue = new DevExpress.XtraEditors.GroupControl();
            grdApprovalQueue = new DevExpress.XtraGrid.GridControl();
            gvApprovalQueue = new DevExpress.XtraGrid.Views.Grid.GridView();
            colAQBudgetCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colAQBudgetName = new DevExpress.XtraGrid.Columns.GridColumn();
            colAQProject = new DevExpress.XtraGrid.Columns.GridColumn();
            colAQAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colAQSubmittedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colAQSubmitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colAQCurrentLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            colAQStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            // Right: Details + Workflow steps
            pnlRight = new DevExpress.XtraEditors.PanelControl();
            grpWorkflowSteps = new DevExpress.XtraEditors.GroupControl();
            grdWorkflowSteps = new DevExpress.XtraGrid.GridControl();
            gvWorkflowSteps = new DevExpress.XtraGrid.Views.Grid.GridView();
            colWFStep = new DevExpress.XtraGrid.Columns.GridColumn();
            colWFApprover = new DevExpress.XtraGrid.Columns.GridColumn();
            colWFStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colWFDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colWFComments = new DevExpress.XtraGrid.Columns.GridColumn();
            grpComments = new DevExpress.XtraEditors.GroupControl();
            memoComments = new DevExpress.XtraEditors.MemoEdit();
            pnlActionButtons = new DevExpress.XtraEditors.PanelControl();
            btnApprove = new DevExpress.XtraEditors.SimpleButton();
            btnReject = new DevExpress.XtraEditors.SimpleButton();
            btnReturn = new DevExpress.XtraEditors.SimpleButton();
            btnDelegate = new DevExpress.XtraEditors.SimpleButton();
            // States
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl(); lblLoadingText = new DevExpress.XtraEditors.LabelControl(); svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl(); lblEmptyText = new DevExpress.XtraEditors.LabelControl(); svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl(); btnRetry = new DevExpress.XtraEditors.SimpleButton(); lblErrorText = new DevExpress.XtraEditors.LabelControl(); svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)barManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit(); splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpApprovalQueue).BeginInit(); grpApprovalQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdApprovalQueue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvApprovalQueue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlRight).BeginInit(); pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpWorkflowSteps).BeginInit(); grpWorkflowSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdWorkflowSteps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvWorkflowSteps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpComments).BeginInit(); grpComments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)memoComments.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlActionButtons).BeginInit(); pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit(); pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit(); pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit(); pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();

            // BarManager
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain });
            
            barManagerMain.Form = this; barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiApprove, bbiReject, bbiReturn, bbiDelegate, bbiAddComment });
            barManagerMain.MainMenu = barMain; barManagerMain.MaxItemId = 5; barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barMain.BarName = "شريط أدوات الاعتماد"; barMain.DockCol = 0; barMain.DockRow = 0; barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiApprove, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiReject, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiReturn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelegate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAddComment, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
            });
            barMain.OptionsBar.AllowQuickCustomization = false; barMain.OptionsBar.DrawDragBorder = false; barMain.OptionsBar.MinHeight = 34; barMain.OptionsBar.UseWholeRow = true; barMain.Text = "شريط أدوات الاعتماد";
            bbiApprove.Caption = "موافقة"; bbiApprove.Id = 0; bbiApprove.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiApprove.ImageOptions.SvgImage"); bbiApprove.Name = "bbiApprove"; bbiApprove.ItemClick += bbiApprove_ItemClick;
            bbiReject.Caption = "رفض"; bbiReject.Id = 1; bbiReject.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnClearFilters.ImageOptions.SvgImage"); bbiReject.Name = "bbiReject"; bbiReject.ItemClick += bbiReject_ItemClick;
            bbiReturn.Caption = "إعادة للمراجعة"; bbiReturn.Id = 2; bbiReturn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiEdit.ImageOptions.SvgImage"); bbiReturn.Name = "bbiReturn"; bbiReturn.ItemClick += bbiReturn_ItemClick;
            bbiDelegate.Caption = "تفويض"; bbiDelegate.Id = 3; bbiDelegate.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiView.ImageOptions.SvgImage"); bbiDelegate.Name = "bbiDelegate"; bbiDelegate.ItemClick += bbiDelegate_ItemClick;
            bbiAddComment.Caption = "إضافة تعليق"; bbiAddComment.Id = 4; bbiAddComment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiNewBOQ.ImageOptions.SvgImage"); bbiAddComment.Name = "bbiAddComment"; bbiAddComment.ItemClick += bbiAddComment_ItemClick;
            barDockControlTop.CausesValidation = false; barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top; barDockControlTop.Location = new System.Drawing.Point(0, 0); barDockControlTop.Manager = barManagerMain; barDockControlTop.Size = new System.Drawing.Size(1366, 34);
            barDockControlBottom.CausesValidation = false; barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom; barDockControlBottom.Location = new System.Drawing.Point(0, 902); barDockControlBottom.Manager = barManagerMain; barDockControlBottom.Size = new System.Drawing.Size(1366, 0);
            barDockControlLeft.CausesValidation = false; barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left; barDockControlLeft.Location = new System.Drawing.Point(0, 34); barDockControlLeft.Manager = barManagerMain; barDockControlLeft.Size = new System.Drawing.Size(0, 868);
            barDockControlRight.CausesValidation = false; barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right; barDockControlRight.Location = new System.Drawing.Point(1366, 34); barDockControlRight.Manager = barManagerMain; barDockControlRight.Size = new System.Drawing.Size(0, 868);

            // SplitMain
            splitMain.Dock = System.Windows.Forms.DockStyle.Fill; splitMain.Location = new System.Drawing.Point(0, 34); splitMain.Name = "splitMain";
            splitMain.Panel1.Controls.Add(grpApprovalQueue); splitMain.Panel2.Controls.Add(pnlRight);
            splitMain.Size = new System.Drawing.Size(1366, 868); splitMain.SplitterPosition = 600; splitMain.TabIndex = 0;

            // Queue grid
            grpApprovalQueue.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpApprovalQueue.AppearanceCaption.Options.UseFont = true;
            grpApprovalQueue.Controls.Add(grdApprovalQueue); grpApprovalQueue.Dock = System.Windows.Forms.DockStyle.Fill; grpApprovalQueue.Name = "grpApprovalQueue"; grpApprovalQueue.Text = "قائمة انتظار الاعتماد";
            grdApprovalQueue.Dock = System.Windows.Forms.DockStyle.Fill; grdApprovalQueue.MainView = gvApprovalQueue; grdApprovalQueue.Name = "grdApprovalQueue"; grdApprovalQueue.MenuManager = barManagerMain;
            grdApprovalQueue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvApprovalQueue });
            gvApprovalQueue.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F); gvApprovalQueue.Appearance.Row.Options.UseFont = true;
            gvApprovalQueue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colAQBudgetCode, colAQBudgetName, colAQProject, colAQAmount, colAQSubmittedBy, colAQSubmitDate, colAQCurrentLevel, colAQStatus });
            gvApprovalQueue.GridControl = grdApprovalQueue; gvApprovalQueue.Name = "gvApprovalQueue"; gvApprovalQueue.OptionsBehavior.Editable = false; gvApprovalQueue.OptionsView.ShowAutoFilterRow = true;
            colAQBudgetCode.Caption = "كود الموازنة"; colAQBudgetCode.FieldName = "BudgetCode"; colAQBudgetCode.Name = "colAQBudgetCode"; colAQBudgetCode.Visible = true; colAQBudgetCode.Width = 120;
            colAQBudgetName.Caption = "الاسم"; colAQBudgetName.FieldName = "BudgetName"; colAQBudgetName.Name = "colAQBudgetName"; colAQBudgetName.Visible = true; colAQBudgetName.Width = 200;
            colAQProject.Caption = "المشروع"; colAQProject.FieldName = "Project"; colAQProject.Name = "colAQProject"; colAQProject.Visible = true; colAQProject.Width = 160;
            colAQAmount.Caption = "المبلغ"; colAQAmount.FieldName = "Amount"; colAQAmount.Name = "colAQAmount"; colAQAmount.Visible = true; colAQAmount.Width = 130; colAQAmount.DisplayFormat.FormatString = "N2"; colAQAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAQSubmittedBy.Caption = "مقدم الطلب"; colAQSubmittedBy.FieldName = "SubmittedBy"; colAQSubmittedBy.Name = "colAQSubmittedBy"; colAQSubmittedBy.Visible = true; colAQSubmittedBy.Width = 130;
            colAQSubmitDate.Caption = "تاريخ التقديم"; colAQSubmitDate.FieldName = "SubmitDate"; colAQSubmitDate.Name = "colAQSubmitDate"; colAQSubmitDate.Visible = true; colAQSubmitDate.Width = 110;
            colAQCurrentLevel.Caption = "المستوى الحالي"; colAQCurrentLevel.FieldName = "CurrentLevel"; colAQCurrentLevel.Name = "colAQCurrentLevel"; colAQCurrentLevel.Visible = true; colAQCurrentLevel.Width = 120;
            colAQStatus.Caption = "الحالة"; colAQStatus.FieldName = "Status"; colAQStatus.Name = "colAQStatus"; colAQStatus.Visible = true; colAQStatus.Width = 100;

            // Right panel
            pnlRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlRight.Controls.Add(grpWorkflowSteps); pnlRight.Controls.Add(grpComments); pnlRight.Controls.Add(pnlActionButtons);
            pnlRight.Dock = System.Windows.Forms.DockStyle.Fill; pnlRight.Name = "pnlRight"; pnlRight.Size = new System.Drawing.Size(766, 868);

            grpWorkflowSteps.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpWorkflowSteps.AppearanceCaption.Options.UseFont = true;
            grpWorkflowSteps.Controls.Add(grdWorkflowSteps); grpWorkflowSteps.Dock = System.Windows.Forms.DockStyle.Top; grpWorkflowSteps.Location = new System.Drawing.Point(0, 0); grpWorkflowSteps.Name = "grpWorkflowSteps"; grpWorkflowSteps.Size = new System.Drawing.Size(766, 380); grpWorkflowSteps.Text = "خطوات سير العمل";
            grdWorkflowSteps.Dock = System.Windows.Forms.DockStyle.Fill; grdWorkflowSteps.MainView = gvWorkflowSteps; grdWorkflowSteps.Name = "grdWorkflowSteps";
            grdWorkflowSteps.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvWorkflowSteps });
            gvWorkflowSteps.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8F); gvWorkflowSteps.Appearance.Row.Options.UseFont = true;
            gvWorkflowSteps.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colWFStep, colWFApprover, colWFStatus, colWFDate, colWFComments });
            gvWorkflowSteps.GridControl = grdWorkflowSteps; gvWorkflowSteps.Name = "gvWorkflowSteps"; gvWorkflowSteps.OptionsBehavior.Editable = false;
            colWFStep.Caption = "الخطوة"; colWFStep.FieldName = "Step"; colWFStep.Name = "colWFStep"; colWFStep.Visible = true; colWFStep.Width = 80;
            colWFApprover.Caption = "المعتمد"; colWFApprover.FieldName = "Approver"; colWFApprover.Name = "colWFApprover"; colWFApprover.Visible = true; colWFApprover.Width = 170;
            colWFStatus.Caption = "الحالة"; colWFStatus.FieldName = "Status"; colWFStatus.Name = "colWFStatus"; colWFStatus.Visible = true; colWFStatus.Width = 100;
            colWFDate.Caption = "التاريخ"; colWFDate.FieldName = "Date"; colWFDate.Name = "colWFDate"; colWFDate.Visible = true; colWFDate.Width = 110;
            colWFComments.Caption = "التعليقات"; colWFComments.FieldName = "Comments"; colWFComments.Name = "colWFComments"; colWFComments.Visible = true; colWFComments.Width = 280;

            grpComments.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); grpComments.AppearanceCaption.Options.UseFont = true;
            grpComments.Controls.Add(memoComments); grpComments.Dock = System.Windows.Forms.DockStyle.Top; grpComments.Location = new System.Drawing.Point(0, 380); grpComments.Name = "grpComments"; grpComments.Size = new System.Drawing.Size(766, 160); grpComments.Text = "التعليق / ملاحظة القرار";
            memoComments.Dock = System.Windows.Forms.DockStyle.Fill; memoComments.Name = "memoComments"; memoComments.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); memoComments.Properties.Appearance.Options.UseFont = true;

            pnlActionButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlActionButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnApprove, btnReject, btnReturn, btnDelegate });
            pnlActionButtons.Dock = System.Windows.Forms.DockStyle.Top; pnlActionButtons.Location = new System.Drawing.Point(0, 540); pnlActionButtons.Name = "pnlActionButtons"; pnlActionButtons.Size = new System.Drawing.Size(766, 54);
            btnApprove.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); btnApprove.Appearance.Options.UseFont = true; btnApprove.Appearance.ForeColor = System.Drawing.Color.White; btnApprove.Appearance.Options.UseForeColor = true; btnApprove.Location = new System.Drawing.Point(596, 7); btnApprove.Name = "btnApprove"; btnApprove.Size = new System.Drawing.Size(150, 40); btnApprove.Text = "✓ موافقة";
            btnReject.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); btnReject.Appearance.Options.UseFont = true; btnReject.Appearance.ForeColor = System.Drawing.Color.White; btnReject.Appearance.Options.UseForeColor = true; btnReject.Location = new System.Drawing.Point(440, 7); btnReject.Name = "btnReject"; btnReject.Size = new System.Drawing.Size(150, 40); btnReject.Text = "✗ رفض";
            btnReturn.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); btnReturn.Appearance.Options.UseFont = true; btnReturn.Appearance.ForeColor = System.Drawing.Color.White; btnReturn.Appearance.Options.UseForeColor = true; btnReturn.Location = new System.Drawing.Point(284, 7); btnReturn.Name = "btnReturn"; btnReturn.Size = new System.Drawing.Size(150, 40); btnReturn.Text = "↩ إعادة";
            btnDelegate.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold); btnDelegate.Appearance.Options.UseFont = true; btnDelegate.Appearance.ForeColor = System.Drawing.Color.White; btnDelegate.Appearance.Options.UseForeColor = true; btnDelegate.Location = new System.Drawing.Point(128, 7); btnDelegate.Name = "btnDelegate"; btnDelegate.Size = new System.Drawing.Size(150, 40); btnDelegate.Text = "→ تفويض";

            // States
            pnlLoadingState.Controls.Add(lblLoadingText); pnlLoadingState.Controls.Add(svgLoadingIcon); pnlLoadingState.Dock = System.Windows.Forms.DockStyle.Fill; pnlLoadingState.Name = "pnlLoadingState"; pnlLoadingState.Visible = false;
            lblLoadingText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblLoadingText.Appearance.Options.UseFont = true; lblLoadingText.Location = new System.Drawing.Point(543, 310); lblLoadingText.Name = "lblLoadingText"; lblLoadingText.Text = "جاري تحميل طلبات الاعتماد...";
            svgLoadingIcon.Location = new System.Drawing.Point(651, 210); svgLoadingIcon.Name = "svgLoadingIcon"; svgLoadingIcon.Size = new System.Drawing.Size(64, 64); svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            pnlEmptyState.Controls.Add(lblEmptyText); pnlEmptyState.Controls.Add(svgEmptyIcon); pnlEmptyState.Dock = System.Windows.Forms.DockStyle.Fill; pnlEmptyState.Name = "pnlEmptyState"; pnlEmptyState.Visible = false;
            lblEmptyText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblEmptyText.Appearance.Options.UseFont = true; lblEmptyText.Location = new System.Drawing.Point(543, 310); lblEmptyText.Name = "lblEmptyText"; lblEmptyText.Text = "لا توجد طلبات اعتماد معلقة";
            svgEmptyIcon.Location = new System.Drawing.Point(651, 210); svgEmptyIcon.Name = "svgEmptyIcon"; svgEmptyIcon.Size = new System.Drawing.Size(64, 64); svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            pnlErrorState.Controls.Add(btnRetry); pnlErrorState.Controls.Add(lblErrorText); pnlErrorState.Controls.Add(svgErrorIcon); pnlErrorState.Dock = System.Windows.Forms.DockStyle.Fill; pnlErrorState.Name = "pnlErrorState"; pnlErrorState.Visible = false;
            lblErrorText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblErrorText.Appearance.Options.UseFont = true; lblErrorText.Location = new System.Drawing.Point(543, 290); lblErrorText.Name = "lblErrorText"; lblErrorText.Text = "حدث خطأ أثناء تحميل طلبات الاعتماد";
            svgErrorIcon.Location = new System.Drawing.Point(651, 190); svgErrorIcon.Name = "svgErrorIcon"; svgErrorIcon.Size = new System.Drawing.Size(64, 64); svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            btnRetry.Appearance.Font = new System.Drawing.Font("Cairo", 9F); btnRetry.Appearance.Options.UseFont = true; btnRetry.Location = new System.Drawing.Point(633, 330); btnRetry.Name = "btnRetry"; btnRetry.Size = new System.Drawing.Size(100, 34); btnRetry.Text = "إعادة المحاولة"; btnRetry.Click += btnRetry_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F); AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(splitMain); Controls.Add(pnlLoadingState); Controls.Add(pnlEmptyState); Controls.Add(pnlErrorState);
            Controls.Add(barDockControlLeft); Controls.Add(barDockControlRight); Controls.Add(barDockControlBottom); Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5); Name = "ucBudgetApprovalWorkflow"; RightToLeft = System.Windows.Forms.RightToLeft.Yes; Size = new System.Drawing.Size(1366, 902);

            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit(); splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpApprovalQueue).EndInit(); grpApprovalQueue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdApprovalQueue).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvApprovalQueue).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlRight).EndInit(); pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpWorkflowSteps).EndInit(); grpWorkflowSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdWorkflowSteps).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvWorkflowSteps).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpComments).EndInit(); grpComments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)memoComments.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlActionButtons).EndInit(); pnlActionButtons.ResumeLayout(false);
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
        private DevExpress.XtraBars.BarButtonItem bbiApprove, bbiReject, bbiReturn, bbiDelegate, bbiAddComment;
        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraEditors.GroupControl grpApprovalQueue;
        private DevExpress.XtraGrid.GridControl grdApprovalQueue;
        private DevExpress.XtraGrid.Views.Grid.GridView gvApprovalQueue;
        private DevExpress.XtraGrid.Columns.GridColumn colAQBudgetCode, colAQBudgetName, colAQProject, colAQAmount, colAQSubmittedBy, colAQSubmitDate, colAQCurrentLevel, colAQStatus;
        private DevExpress.XtraEditors.PanelControl pnlRight;
        private DevExpress.XtraEditors.GroupControl grpWorkflowSteps;
        private DevExpress.XtraGrid.GridControl grdWorkflowSteps;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWorkflowSteps;
        private DevExpress.XtraGrid.Columns.GridColumn colWFStep, colWFApprover, colWFStatus, colWFDate, colWFComments;
        private DevExpress.XtraEditors.GroupControl grpComments;
        private DevExpress.XtraEditors.MemoEdit memoComments;
        private DevExpress.XtraEditors.PanelControl pnlActionButtons;
        private DevExpress.XtraEditors.SimpleButton btnApprove, btnReject, btnReturn, btnDelegate;
        private DevExpress.XtraEditors.PanelControl pnlLoadingState, pnlEmptyState, pnlErrorState;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon, svgEmptyIcon, svgErrorIcon;
        private DevExpress.XtraEditors.LabelControl lblLoadingText, lblEmptyText, lblErrorText;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
    }
}

