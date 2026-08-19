namespace Etmam
{
    partial class ucCostBreakdownStructure
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCostBreakdownStructure));
            barManagerMain = new DevExpress.XtraBars.BarManager(components);
            barMain = new DevExpress.XtraBars.Bar();
            bbiAddLevel = new DevExpress.XtraBars.BarButtonItem();
            bbiAddItem = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiSave = new DevExpress.XtraBars.BarButtonItem();
            bbiExportExcel = new DevExpress.XtraBars.BarButtonItem();
            barStatus = new DevExpress.XtraBars.Bar();
            sbiNodeCount = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            treeCBS = new DevExpress.XtraTreeList.TreeList();
            colCBSCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCBSName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCBSLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCBSBudget = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colCBSDept = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            pnlDetails = new DevExpress.XtraEditors.PanelControl();
            grpDetails = new DevExpress.XtraEditors.GroupControl();
            lblCode = new DevExpress.XtraEditors.LabelControl(); txtCode = new DevExpress.XtraEditors.TextEdit();
            lblCBSName = new DevExpress.XtraEditors.LabelControl(); txtCBSName = new DevExpress.XtraEditors.TextEdit();
            lblParent = new DevExpress.XtraEditors.LabelControl(); txtParent = new DevExpress.XtraEditors.TextEdit();
            lblBudget = new DevExpress.XtraEditors.LabelControl(); txtBudget = new DevExpress.XtraEditors.TextEdit();
            lblDept = new DevExpress.XtraEditors.LabelControl(); cboDept = new DevExpress.XtraEditors.ComboBoxEdit();
            lblCostType = new DevExpress.XtraEditors.LabelControl(); cboCostType = new DevExpress.XtraEditors.ComboBoxEdit();
            lblRemarks = new DevExpress.XtraEditors.LabelControl(); memoRemarks = new DevExpress.XtraEditors.MemoEdit();
            pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            lblLoadingText = new DevExpress.XtraEditors.LabelControl(); svgLoadingIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            lblEmptyText = new DevExpress.XtraEditors.LabelControl(); svgEmptyIcon = new DevExpress.XtraEditors.SvgImageBox();
            pnlErrorState = new DevExpress.XtraEditors.PanelControl();
            btnRetry = new DevExpress.XtraEditors.SimpleButton();
            lblErrorText = new DevExpress.XtraEditors.LabelControl(); svgErrorIcon = new DevExpress.XtraEditors.SvgImageBox();

            ((System.ComponentModel.ISupportInitialize)barManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit(); splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeCBS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlDetails).BeginInit(); pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpDetails).BeginInit(); grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCBSName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtParent.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBudget.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboDept.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboCostType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoRemarks.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoadingState).BeginInit(); pnlLoadingState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgLoadingIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmptyState).BeginInit(); pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgEmptyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlErrorState).BeginInit(); pnlErrorState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgErrorIcon).BeginInit();
            SuspendLayout();

            // barManagerMain
            barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { barMain, barStatus });
            
            barManagerMain.Form = this; barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAddLevel, bbiAddItem, bbiDelete, bbiEdit, bbiSave, bbiExportExcel, sbiNodeCount });
            barManagerMain.MainMenu = barMain; barManagerMain.MaxItemId = 7; barManagerMain.RightToLeft = DevExpress.Utils.DefaultBoolean.True; barManagerMain.StatusBar = barStatus;
            barMain.BarName = "شريط أدوات هيكل تكسير التكلفة"; barMain.DockCol = 0; barMain.DockRow = 0; barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[]
            {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAddLevel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAddItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)
            });
            barMain.OptionsBar.AllowQuickCustomization = false; barMain.OptionsBar.DrawDragBorder = false; barMain.OptionsBar.MinHeight = 34; barMain.OptionsBar.UseWholeRow = true;
            barMain.Text = "شريط أدوات هيكل تكسير التكلفة";
            bbiAddLevel.Caption = "إضافة مستوى"; bbiAddLevel.Id = 0; bbiAddLevel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiNewBOQ.ImageOptions.SvgImage"); bbiAddLevel.Name = "bbiAddLevel"; bbiAddLevel.ItemClick += bbiAddLevel_ItemClick;
            bbiAddItem.Caption = "إضافة عنصر"; bbiAddItem.Id = 1; bbiAddItem.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiNewBOQ.ImageOptions.SvgImage"); bbiAddItem.Name = "bbiAddItem"; bbiAddItem.ItemClick += bbiAddItem_ItemClick;
            bbiDelete.Caption = "حذف"; bbiDelete.Id = 2; bbiDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiEdit.ImageOptions.SvgImage"); bbiDelete.Name = "bbiDelete"; bbiDelete.ItemClick += bbiDelete_ItemClick;
            bbiEdit.Caption = "تعديل"; bbiEdit.Id = 3; bbiEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiEdit.ImageOptions.SvgImage"); bbiEdit.Name = "bbiEdit"; bbiEdit.ItemClick += bbiEdit_ItemClick;
            bbiSave.Caption = "حفظ"; bbiSave.Id = 4; bbiSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiApprove.ImageOptions.SvgImage"); bbiSave.Name = "bbiSave"; bbiSave.ItemClick += bbiSave_ItemClick;
            bbiExportExcel.Caption = "تصدير Excel"; bbiExportExcel.Id = 5; bbiExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbiExportExcel.ImageOptions.SvgImage"); bbiExportExcel.Name = "bbiExportExcel"; bbiExportExcel.ItemClick += bbiExportExcel_ItemClick;
            barStatus.BarName = "شريط الحالة"; barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom; barStatus.DockCol = 0; barStatus.DockRow = 0; barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(sbiNodeCount) });
            barStatus.OptionsBar.AllowQuickCustomization = false; barStatus.OptionsBar.DrawDragBorder = false; barStatus.OptionsBar.UseWholeRow = true; barStatus.Text = "شريط الحالة";
            sbiNodeCount.Caption = "عدد العناصر: 0"; sbiNodeCount.Id = 6; sbiNodeCount.Name = "sbiNodeCount";
            barDockControlTop.CausesValidation = false; barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top; barDockControlTop.Location = new System.Drawing.Point(0, 0); barDockControlTop.Manager = barManagerMain; barDockControlTop.Size = new System.Drawing.Size(1366, 34);
            barDockControlBottom.CausesValidation = false; barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom; barDockControlBottom.Location = new System.Drawing.Point(0, 873); barDockControlBottom.Manager = barManagerMain; barDockControlBottom.Size = new System.Drawing.Size(1366, 29);
            barDockControlLeft.CausesValidation = false; barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left; barDockControlLeft.Location = new System.Drawing.Point(0, 34); barDockControlLeft.Manager = barManagerMain; barDockControlLeft.Size = new System.Drawing.Size(0, 839);
            barDockControlRight.CausesValidation = false; barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right; barDockControlRight.Location = new System.Drawing.Point(1366, 34); barDockControlRight.Manager = barManagerMain; barDockControlRight.Size = new System.Drawing.Size(0, 839);

            // splitMain
            splitMain.Dock = System.Windows.Forms.DockStyle.Fill; splitMain.Location = new System.Drawing.Point(0, 34); splitMain.Name = "splitMain";
            splitMain.Panel1.Controls.Add(treeCBS); splitMain.Panel2.Controls.Add(pnlDetails);
            splitMain.Size = new System.Drawing.Size(1366, 839); splitMain.SplitterPosition = 550; splitMain.TabIndex = 0;

            // treeCBS
            treeCBS.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 8F, System.Drawing.FontStyle.Bold); treeCBS.Appearance.HeaderPanel.Options.UseFont = true;
            treeCBS.Appearance.Row.Font = new System.Drawing.Font("Cairo", 9F); treeCBS.Appearance.Row.Options.UseFont = true;
            treeCBS.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colCBSCode, colCBSName, colCBSLevel, colCBSBudget, colCBSDept });
            treeCBS.Dock = System.Windows.Forms.DockStyle.Fill; treeCBS.Name = "treeCBS"; treeCBS.OptionsBehavior.Editable = false;
            treeCBS.OptionsView.ShowHorzLines = true; treeCBS.OptionsView.ShowIndicator = false; treeCBS.Size = new System.Drawing.Size(550, 839);
            colCBSCode.Caption = "الكود"; colCBSCode.FieldName = "Code"; colCBSCode.Name = "colCBSCode"; colCBSCode.Visible = true; colCBSCode.Width = 120;
            colCBSName.Caption = "الاسم"; colCBSName.FieldName = "Name"; colCBSName.Name = "colCBSName"; colCBSName.Visible = true; colCBSName.Width = 220;
            colCBSLevel.Caption = "المستوى"; colCBSLevel.FieldName = "Level"; colCBSLevel.Name = "colCBSLevel"; colCBSLevel.Visible = true; colCBSLevel.Width = 70;
            colCBSBudget.Caption = "الموازنة"; colCBSBudget.FieldName = "Budget"; colCBSBudget.Name = "colCBSBudget"; colCBSBudget.Visible = true; colCBSBudget.Width = 110; colCBSBudget.Format.FormatString = "N2"; colCBSBudget.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCBSDept.Caption = "القسم المسؤول"; colCBSDept.FieldName = "Department"; colCBSDept.Name = "colCBSDept"; colCBSDept.Visible = true; colCBSDept.Width = 130;

            // pnlDetails
            pnlDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlDetails.Controls.Add(grpDetails); pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill; pnlDetails.Name = "pnlDetails"; pnlDetails.Size = new System.Drawing.Size(816, 839);
            grpDetails.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold); grpDetails.AppearanceCaption.Options.UseFont = true;
            grpDetails.Controls.AddRange(new System.Windows.Forms.Control[] { lblCode, txtCode, lblCBSName, txtCBSName, lblParent, txtParent, lblBudget, txtBudget, lblDept, cboDept, lblCostType, cboCostType, lblRemarks, memoRemarks });
            grpDetails.Dock = System.Windows.Forms.DockStyle.Fill; grpDetails.Name = "grpDetails"; grpDetails.Text = "تفاصيل العنصر";
            lblCode.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblCode.Appearance.Options.UseFont = true; lblCode.Location = new System.Drawing.Point(640, 42); lblCode.Name = "lblCode"; lblCode.Text = "الكود:";
            txtCode.Location = new System.Drawing.Point(500, 62); txtCode.Name = "txtCode"; txtCode.Size = new System.Drawing.Size(135, 30); txtCode.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); txtCode.Properties.Appearance.Options.UseFont = true;
            lblCBSName.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblCBSName.Appearance.Options.UseFont = true; lblCBSName.Location = new System.Drawing.Point(360, 42); lblCBSName.Name = "lblCBSName"; lblCBSName.Text = "الاسم:";
            txtCBSName.Location = new System.Drawing.Point(12, 62); txtCBSName.Name = "txtCBSName"; txtCBSName.Size = new System.Drawing.Size(343, 30); txtCBSName.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); txtCBSName.Properties.Appearance.Options.UseFont = true;
            lblParent.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblParent.Appearance.Options.UseFont = true; lblParent.Location = new System.Drawing.Point(640, 102); lblParent.Name = "lblParent"; lblParent.Text = "العنصر الأب:";
            txtParent.Location = new System.Drawing.Point(500, 122); txtParent.Name = "txtParent"; txtParent.Size = new System.Drawing.Size(135, 30); txtParent.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); txtParent.Properties.Appearance.Options.UseFont = true; txtParent.Properties.ReadOnly = true; txtParent.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(240, 241, 243); txtParent.Properties.Appearance.Options.UseBackColor = true;
            lblBudget.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblBudget.Appearance.Options.UseFont = true; lblBudget.Location = new System.Drawing.Point(360, 102); lblBudget.Name = "lblBudget"; lblBudget.Text = "الموازنة:";
            txtBudget.Location = new System.Drawing.Point(230, 122); txtBudget.Name = "txtBudget"; txtBudget.Size = new System.Drawing.Size(125, 30); txtBudget.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); txtBudget.Properties.Appearance.Options.UseFont = true;
            lblDept.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblDept.Appearance.Options.UseFont = true; lblDept.Location = new System.Drawing.Point(160, 102); lblDept.Name = "lblDept"; lblDept.Text = "القسم المسؤول:";
            cboDept.Location = new System.Drawing.Point(12, 122); cboDept.Name = "cboDept"; cboDept.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); cboDept.Properties.Appearance.Options.UseFont = true; cboDept.Size = new System.Drawing.Size(143, 30);
            lblCostType.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblCostType.Appearance.Options.UseFont = true; lblCostType.Location = new System.Drawing.Point(640, 162); lblCostType.Name = "lblCostType"; lblCostType.Text = "نوع التكلفة:";
            cboCostType.Location = new System.Drawing.Point(490, 182); cboCostType.Name = "cboCostType"; cboCostType.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); cboCostType.Properties.Appearance.Options.UseFont = true; cboCostType.Size = new System.Drawing.Size(145, 30);
            lblRemarks.Appearance.Font = new System.Drawing.Font("Cairo", 8F); lblRemarks.Appearance.Options.UseFont = true; lblRemarks.Location = new System.Drawing.Point(640, 222); lblRemarks.Name = "lblRemarks"; lblRemarks.Text = "ملاحظات:";
            memoRemarks.Location = new System.Drawing.Point(12, 242); memoRemarks.Name = "memoRemarks"; memoRemarks.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F); memoRemarks.Properties.Appearance.Options.UseFont = true; memoRemarks.Size = new System.Drawing.Size(623, 120);

            // State panels
            pnlLoadingState.Controls.Add(lblLoadingText); pnlLoadingState.Controls.Add(svgLoadingIcon);
            pnlLoadingState.Dock = System.Windows.Forms.DockStyle.Fill; pnlLoadingState.Name = "pnlLoadingState"; pnlLoadingState.Visible = false;
            lblLoadingText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblLoadingText.Appearance.Options.UseFont = true; lblLoadingText.Location = new System.Drawing.Point(543, 310); lblLoadingText.Name = "lblLoadingText"; lblLoadingText.Text = "جاري التحميل...";
            svgLoadingIcon.Location = new System.Drawing.Point(651, 210); svgLoadingIcon.Name = "svgLoadingIcon"; svgLoadingIcon.Size = new System.Drawing.Size(64, 64); svgLoadingIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgLoadingIcon.SvgImage");
            pnlEmptyState.Controls.Add(lblEmptyText); pnlEmptyState.Controls.Add(svgEmptyIcon);
            pnlEmptyState.Dock = System.Windows.Forms.DockStyle.Fill; pnlEmptyState.Name = "pnlEmptyState"; pnlEmptyState.Visible = false;
            lblEmptyText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblEmptyText.Appearance.Options.UseFont = true; lblEmptyText.Location = new System.Drawing.Point(543, 310); lblEmptyText.Name = "lblEmptyText"; lblEmptyText.Text = "لا يوجد هيكل تكسير تكلفة";
            svgEmptyIcon.Location = new System.Drawing.Point(651, 210); svgEmptyIcon.Name = "svgEmptyIcon"; svgEmptyIcon.Size = new System.Drawing.Size(64, 64); svgEmptyIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgEmptyIcon.SvgImage");
            pnlErrorState.Controls.Add(btnRetry); pnlErrorState.Controls.Add(lblErrorText); pnlErrorState.Controls.Add(svgErrorIcon);
            pnlErrorState.Dock = System.Windows.Forms.DockStyle.Fill; pnlErrorState.Name = "pnlErrorState"; pnlErrorState.Visible = false;
            lblErrorText.Appearance.Font = new System.Drawing.Font("Cairo", 10F); lblErrorText.Appearance.Options.UseFont = true; lblErrorText.Location = new System.Drawing.Point(543, 290); lblErrorText.Name = "lblErrorText"; lblErrorText.Text = "حدث خطأ أثناء التحميل";
            svgErrorIcon.Location = new System.Drawing.Point(651, 190); svgErrorIcon.Name = "svgErrorIcon"; svgErrorIcon.Size = new System.Drawing.Size(64, 64); svgErrorIcon.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgErrorIcon.SvgImage");
            btnRetry.Appearance.Font = new System.Drawing.Font("Cairo", 9F); btnRetry.Appearance.Options.UseFont = true; btnRetry.Location = new System.Drawing.Point(633, 330); btnRetry.Name = "btnRetry"; btnRetry.Size = new System.Drawing.Size(100, 34); btnRetry.Text = "إعادة المحاولة"; btnRetry.Click += btnRetry_Click;

            // ucCostBreakdownStructure
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F); AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(splitMain); Controls.Add(pnlLoadingState); Controls.Add(pnlEmptyState); Controls.Add(pnlErrorState);
            Controls.Add(barDockControlLeft); Controls.Add(barDockControlRight); Controls.Add(barDockControlBottom); Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5); Name = "ucCostBreakdownStructure"; RightToLeft = System.Windows.Forms.RightToLeft.Yes; Size = new System.Drawing.Size(1366, 902);

            ((System.ComponentModel.ISupportInitialize)barManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit(); splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeCBS).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlDetails).EndInit(); pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpDetails).EndInit(); grpDetails.ResumeLayout(false); grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCBSName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtParent.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBudget.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboDept.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboCostType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoRemarks.Properties).EndInit();
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
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiAddLevel;
        private DevExpress.XtraBars.BarButtonItem bbiAddItem;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiExportExcel;
        private DevExpress.XtraBars.BarStaticItem sbiNodeCount;
        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraTreeList.TreeList treeCBS;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCBSCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCBSName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCBSLevel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCBSBudget;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCBSDept;
        private DevExpress.XtraEditors.PanelControl pnlDetails;
        private DevExpress.XtraEditors.GroupControl grpDetails;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl lblCBSName;
        private DevExpress.XtraEditors.TextEdit txtCBSName;
        private DevExpress.XtraEditors.LabelControl lblParent;
        private DevExpress.XtraEditors.TextEdit txtParent;
        private DevExpress.XtraEditors.LabelControl lblBudget;
        private DevExpress.XtraEditors.TextEdit txtBudget;
        private DevExpress.XtraEditors.LabelControl lblDept;
        private DevExpress.XtraEditors.ComboBoxEdit cboDept;
        private DevExpress.XtraEditors.LabelControl lblCostType;
        private DevExpress.XtraEditors.ComboBoxEdit cboCostType;
        private DevExpress.XtraEditors.LabelControl lblRemarks;
        private DevExpress.XtraEditors.MemoEdit memoRemarks;
        private DevExpress.XtraEditors.PanelControl pnlLoadingState;
        private DevExpress.XtraEditors.LabelControl lblLoadingText;
        private DevExpress.XtraEditors.SvgImageBox svgLoadingIcon;
        private DevExpress.XtraEditors.PanelControl pnlEmptyState;
        private DevExpress.XtraEditors.LabelControl lblEmptyText;
        private DevExpress.XtraEditors.SvgImageBox svgEmptyIcon;
        private DevExpress.XtraEditors.PanelControl pnlErrorState;
        private DevExpress.XtraEditors.SimpleButton btnRetry;
        private DevExpress.XtraEditors.LabelControl lblErrorText;
        private DevExpress.XtraEditors.SvgImageBox svgErrorIcon;
    }
}

