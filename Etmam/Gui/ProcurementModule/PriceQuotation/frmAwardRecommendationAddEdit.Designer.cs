namespace Etmam
{
    partial class frmAwardRecommendationAddEdit
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAwardRecommendationAddEdit));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            bbiFirst = new DevExpress.XtraBars.BarButtonItem();
            bbiPrev = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            bbiNext = new DevExpress.XtraBars.BarButtonItem();
            bbiLast = new DevExpress.XtraBars.BarButtonItem();
            bbiSave = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            btnPrintRFQ = new DevExpress.XtraBars.BarButtonItem();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            memoEditDeviationJustification = new DevExpress.XtraEditors.MemoEdit();
            memoEditRecommendationReason = new DevExpress.XtraEditors.MemoEdit();
            comboBoxEditStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            textEditTechnicalStatus = new DevExpress.XtraEditors.TextEdit();
            textEditRecommendedAmount = new DevExpress.XtraEditors.TextEdit();
            textEditNum = new DevExpress.XtraEditors.TextEdit();
            comboBoxEditBudgetStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            textEditIsLowestBid = new DevExpress.XtraEditors.TextEdit();
            lookUpEditQuotation = new DevExpress.XtraEditors.LookUpEdit();
            lookUpEditRFQ = new DevExpress.XtraEditors.LookUpEdit();
            labelControlNum = new DevExpress.XtraEditors.LabelControl();
            labelControlRecommendedAmount = new DevExpress.XtraEditors.LabelControl();
            labelControlTechnicalStatus = new DevExpress.XtraEditors.LabelControl();
            labelControlStatus = new DevExpress.XtraEditors.LabelControl();
            labelControlQuotation = new DevExpress.XtraEditors.LabelControl();
            labelControlIsLowestBid = new DevExpress.XtraEditors.LabelControl();
            labelControlBudgetStatus = new DevExpress.XtraEditors.LabelControl();
            labelControlRecommendationReason = new DevExpress.XtraEditors.LabelControl();
            labelControlDeviationJustification = new DevExpress.XtraEditors.LabelControl();
            labelControlRFQ = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)memoEditDeviationJustification.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEditRecommendationReason.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditTechnicalStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditRecommendedAmount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditNum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditBudgetStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditIsLowestBid.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditQuotation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditRFQ.Properties).BeginInit();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = imageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiSave, bbiPrint, bbiFirst, bbiPrev, bbiNext, bbiLast, barEditItem1, btnPrintRFQ });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 24;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemSearchControl1 });
            barManager1.StatusBar = bar3;
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiFirst, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrev, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(barEditItem1), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNext, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiLast, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MinHeight = 35;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // bbiNew
            // 
            bbiNew.Caption = "جديد";
            bbiNew.Id = 0;
            bbiNew.ImageOptions.ImageIndex = 0;
            bbiNew.Name = "bbiNew";
            bbiNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiFirst
            // 
            bbiFirst.Caption = "الأول";
            bbiFirst.Id = 3;
            bbiFirst.ImageOptions.ImageIndex = 1;
            bbiFirst.Name = "bbiFirst";
            bbiFirst.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiPrev
            // 
            bbiPrev.Caption = "السابق";
            bbiPrev.Id = 4;
            bbiPrev.ImageOptions.ImageIndex = 2;
            bbiPrev.Name = "bbiPrev";
            bbiPrev.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barEditItem1
            // 
            barEditItem1.Edit = repositoryItemSearchControl1;
            barEditItem1.EditHeight = 20;
            barEditItem1.EditWidth = 80;
            barEditItem1.Id = 8;
            barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemSearchControl1
            // 
            repositoryItemSearchControl1.AutoHeight = false;
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            repositoryItemSearchControl1.NullValuePrompt = " ";
            // 
            // bbiNext
            // 
            bbiNext.Caption = "اللاحق";
            bbiNext.Id = 5;
            bbiNext.ImageOptions.ImageIndex = 3;
            bbiNext.Name = "bbiNext";
            bbiNext.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiLast
            // 
            bbiLast.Caption = "الأخير";
            bbiLast.Id = 6;
            bbiLast.ImageOptions.ImageIndex = 4;
            bbiLast.Name = "bbiLast";
            bbiLast.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiSave
            // 
            bbiSave.Caption = "حفظ";
            bbiSave.Id = 1;
            bbiSave.ImageOptions.ImageIndex = 5;
            bbiSave.Name = "bbiSave";
            bbiSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            barDockControlTop.Margin = new Padding(3, 5, 3, 5);
            barDockControlTop.Size = new Size(1092, 35);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 538);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(1092, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 35);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 503);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1092, 35);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 503);
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.InsertImage(Properties.Resources.add_16x161, "Add", typeof(Properties.Resources), 0, "add_16x161");
            imageCollection1.Images.SetKeyName(0, "Add");
            imageCollection1.InsertImage(Properties.Resources.last_16x162, "First", typeof(Properties.Resources), 1, "last_16x162");
            imageCollection1.Images.SetKeyName(1, "First");
            imageCollection1.InsertImage(Properties.Resources.next_16x162, "Prev", typeof(Properties.Resources), 2, "next_16x162");
            imageCollection1.Images.SetKeyName(2, "Prev");
            imageCollection1.InsertImage(Properties.Resources.prev_16x162, "Next", typeof(Properties.Resources), 3, "prev_16x162");
            imageCollection1.Images.SetKeyName(3, "Next");
            imageCollection1.InsertImage(Properties.Resources.first_16x162, "Last", typeof(Properties.Resources), 4, "first_16x162");
            imageCollection1.Images.SetKeyName(4, "Last");
            imageCollection1.InsertImage(Properties.Resources.save_16x161, "save", typeof(Properties.Resources), 5, "save_16x161");
            imageCollection1.Images.SetKeyName(5, "save");
            imageCollection1.InsertImage(Properties.Resources.print_16x16, "print", typeof(Properties.Resources), 6, "print_16x16");
            imageCollection1.Images.SetKeyName(6, "print");
            imageCollection1.InsertImage(Properties.Resources.showtestreport_16x16, "Action", typeof(Properties.Resources), 7, "showtestreport_16x16");
            imageCollection1.Images.SetKeyName(7, "Action");
            imageCollection1.InsertImage(Properties.Resources.sortbyinvoice_16x166, "AddItems", typeof(Properties.Resources), 8, "sortbyinvoice_16x166");
            imageCollection1.Images.SetKeyName(8, "AddItems");
            imageCollection1.InsertImage(Properties.Resources.edit_16x166, "Edit", typeof(Properties.Resources), 9, "edit_16x166");
            imageCollection1.Images.SetKeyName(9, "Edit");
            imageCollection1.InsertImage(Properties.Resources.delete_16x16, "Delete", typeof(Properties.Resources), 10, "delete_16x16");
            imageCollection1.Images.SetKeyName(10, "Delete");
            imageCollection1.InsertImage(Properties.Resources.open_16x162, "open_16x162", typeof(Properties.Resources), 11);
            imageCollection1.Images.SetKeyName(11, "open_16x162");
            imageCollection1.InsertImage(Properties.Resources.apply_32x32, "apply_32x32", typeof(Properties.Resources), 12);
            imageCollection1.Images.SetKeyName(12, "apply_32x32");
            imageCollection1.InsertImage(Properties.Resources.cancel_32x324, "cancel_32x324", typeof(Properties.Resources), 13);
            imageCollection1.Images.SetKeyName(13, "cancel_32x324");
            imageCollection1.InsertImage(Properties.Resources.borules_32x32, "borules_32x32", typeof(Properties.Resources), 14);
            imageCollection1.Images.SetKeyName(14, "borules_32x32");
            // 
            // bbiPrint
            // 
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 2;
            bbiPrint.ImageOptions.ImageIndex = 6;
            bbiPrint.Name = "bbiPrint";
            bbiPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnPrintRFQ
            // 
            btnPrintRFQ.Caption = "طباعة طلب عرض السعر";
            btnPrintRFQ.Id = 23;
            btnPrintRFQ.Name = "btnPrintRFQ";
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new Font("Cairo", 9F, FontStyle.Bold);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.Controls.Add(memoEditDeviationJustification);
            groupControl1.Controls.Add(memoEditRecommendationReason);
            groupControl1.Controls.Add(comboBoxEditStatus);
            groupControl1.Controls.Add(textEditTechnicalStatus);
            groupControl1.Controls.Add(textEditRecommendedAmount);
            groupControl1.Controls.Add(textEditNum);
            groupControl1.Controls.Add(comboBoxEditBudgetStatus);
            groupControl1.Controls.Add(textEditIsLowestBid);
            groupControl1.Controls.Add(lookUpEditQuotation);
            groupControl1.Controls.Add(lookUpEditRFQ);
            groupControl1.Controls.Add(labelControlNum);
            groupControl1.Controls.Add(labelControlRecommendedAmount);
            groupControl1.Controls.Add(labelControlTechnicalStatus);
            groupControl1.Controls.Add(labelControlStatus);
            groupControl1.Controls.Add(labelControlQuotation);
            groupControl1.Controls.Add(labelControlIsLowestBid);
            groupControl1.Controls.Add(labelControlBudgetStatus);
            groupControl1.Controls.Add(labelControlRecommendationReason);
            groupControl1.Controls.Add(labelControlDeviationJustification);
            groupControl1.Controls.Add(labelControlRFQ);
            groupControl1.Dock = DockStyle.Fill;
            groupControl1.Location = new Point(0, 35);
            groupControl1.Margin = new Padding(3, 4, 3, 4);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(1092, 503);
            groupControl1.TabIndex = 4;
            groupControl1.Text = "بيانات توصية الترسية";
            // 
            // memoEditDeviationJustification
            // 
            memoEditDeviationJustification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memoEditDeviationJustification.Location = new Point(20, 278);
            memoEditDeviationJustification.Margin = new Padding(3, 4, 3, 4);
            memoEditDeviationJustification.Name = "memoEditDeviationJustification";
            memoEditDeviationJustification.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            memoEditDeviationJustification.Size = new Size(914, 204);
            memoEditDeviationJustification.TabIndex = 37;
            // 
            // memoEditRecommendationReason
            // 
            memoEditRecommendationReason.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memoEditRecommendationReason.Location = new Point(20, 185);
            memoEditRecommendationReason.Margin = new Padding(3, 4, 3, 4);
            memoEditRecommendationReason.Name = "memoEditRecommendationReason";
            memoEditRecommendationReason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            memoEditRecommendationReason.Size = new Size(914, 85);
            memoEditRecommendationReason.TabIndex = 36;
            // 
            // comboBoxEditStatus
            // 
            comboBoxEditStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxEditStatus.Location = new Point(37, 147);
            comboBoxEditStatus.Margin = new Padding(3, 4, 3, 4);
            comboBoxEditStatus.Name = "comboBoxEditStatus";
            comboBoxEditStatus.Properties.AutoHeight = false;
            comboBoxEditStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEditStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditStatus.Properties.Items.AddRange(new object[] { "مسودة", "قيد الاعتماد", "معتمد", "مرفوض" });
            comboBoxEditStatus.Size = new Size(374, 30);
            comboBoxEditStatus.TabIndex = 35;
            // 
            // textEditTechnicalStatus
            // 
            textEditTechnicalStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textEditTechnicalStatus.Enabled = false;
            textEditTechnicalStatus.Location = new Point(37, 112);
            textEditTechnicalStatus.Margin = new Padding(3, 4, 3, 4);
            textEditTechnicalStatus.Name = "textEditTechnicalStatus";
            textEditTechnicalStatus.Properties.Appearance.BackColor = SystemColors.ControlLight;
            textEditTechnicalStatus.Properties.Appearance.Options.UseBackColor = true;
            textEditTechnicalStatus.Properties.AutoHeight = false;
            textEditTechnicalStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            textEditTechnicalStatus.Size = new Size(374, 30);
            textEditTechnicalStatus.TabIndex = 34;
            // 
            // textEditRecommendedAmount
            // 
            textEditRecommendedAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textEditRecommendedAmount.Location = new Point(37, 77);
            textEditRecommendedAmount.Margin = new Padding(3, 4, 3, 4);
            textEditRecommendedAmount.Name = "textEditRecommendedAmount";
            textEditRecommendedAmount.Properties.AutoHeight = false;
            textEditRecommendedAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            textEditRecommendedAmount.Size = new Size(374, 30);
            textEditRecommendedAmount.TabIndex = 33;
            // 
            // textEditNum
            // 
            textEditNum.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textEditNum.Enabled = false;
            textEditNum.Location = new Point(37, 42);
            textEditNum.Margin = new Padding(3, 4, 3, 4);
            textEditNum.Name = "textEditNum";
            textEditNum.Properties.Appearance.BackColor = SystemColors.ControlLight;
            textEditNum.Properties.Appearance.Options.UseBackColor = true;
            textEditNum.Properties.AutoHeight = false;
            textEditNum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            textEditNum.Size = new Size(374, 30);
            textEditNum.TabIndex = 32;
            // 
            // comboBoxEditBudgetStatus
            // 
            comboBoxEditBudgetStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxEditBudgetStatus.Location = new Point(562, 147);
            comboBoxEditBudgetStatus.Margin = new Padding(3, 4, 3, 4);
            comboBoxEditBudgetStatus.Name = "comboBoxEditBudgetStatus";
            comboBoxEditBudgetStatus.Properties.AutoHeight = false;
            comboBoxEditBudgetStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            comboBoxEditBudgetStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditBudgetStatus.Properties.Items.AddRange(new object[] { "ضمن الموازنة", "يتجاوز الموازنة", "غير محدد" });
            comboBoxEditBudgetStatus.Size = new Size(372, 30);
            comboBoxEditBudgetStatus.TabIndex = 31;
            // 
            // textEditIsLowestBid
            // 
            textEditIsLowestBid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textEditIsLowestBid.Enabled = false;
            textEditIsLowestBid.Location = new Point(562, 112);
            textEditIsLowestBid.Margin = new Padding(3, 4, 3, 4);
            textEditIsLowestBid.Name = "textEditIsLowestBid";
            textEditIsLowestBid.Properties.Appearance.BackColor = SystemColors.ControlLight;
            textEditIsLowestBid.Properties.Appearance.Options.UseBackColor = true;
            textEditIsLowestBid.Properties.AutoHeight = false;
            textEditIsLowestBid.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            textEditIsLowestBid.Size = new Size(372, 30);
            textEditIsLowestBid.TabIndex = 30;
            // 
            // lookUpEditQuotation
            // 
            lookUpEditQuotation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditQuotation.Location = new Point(562, 77);
            lookUpEditQuotation.Margin = new Padding(3, 4, 3, 4);
            lookUpEditQuotation.Name = "lookUpEditQuotation";
            lookUpEditQuotation.Properties.Appearance.BackColor = Color.LightGreen;
            lookUpEditQuotation.Properties.Appearance.Options.UseBackColor = true;
            lookUpEditQuotation.Properties.AutoHeight = false;
            lookUpEditQuotation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditQuotation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEditQuotation.Properties.NullText = "";
            lookUpEditQuotation.Size = new Size(372, 30);
            lookUpEditQuotation.TabIndex = 29;
            // 
            // lookUpEditRFQ
            // 
            lookUpEditRFQ.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditRFQ.Location = new Point(562, 42);
            lookUpEditRFQ.Margin = new Padding(3, 4, 3, 4);
            lookUpEditRFQ.Name = "lookUpEditRFQ";
            lookUpEditRFQ.Properties.AutoHeight = false;
            lookUpEditRFQ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lookUpEditRFQ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEditRFQ.Properties.NullText = "";
            lookUpEditRFQ.Size = new Size(372, 30);
            lookUpEditRFQ.TabIndex = 28;
            // 
            // labelControlNum
            // 
            labelControlNum.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlNum.Appearance.Font = new Font("Cairo", 9F);
            labelControlNum.Appearance.Options.UseFont = true;
            labelControlNum.Location = new Point(424, 46);
            labelControlNum.Margin = new Padding(3, 4, 3, 4);
            labelControlNum.Name = "labelControlNum";
            labelControlNum.Size = new Size(62, 23);
            labelControlNum.TabIndex = 24;
            labelControlNum.Text = "رقم التوصية:";
            // 
            // labelControlRecommendedAmount
            // 
            labelControlRecommendedAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlRecommendedAmount.Appearance.Font = new Font("Cairo", 9F);
            labelControlRecommendedAmount.Appearance.Options.UseFont = true;
            labelControlRecommendedAmount.Location = new Point(424, 81);
            labelControlRecommendedAmount.Margin = new Padding(3, 4, 3, 4);
            labelControlRecommendedAmount.Name = "labelControlRecommendedAmount";
            labelControlRecommendedAmount.Size = new Size(122, 23);
            labelControlRecommendedAmount.TabIndex = 25;
            labelControlRecommendedAmount.Text = "القيمة الموصى بترسيتها:";
            // 
            // labelControlTechnicalStatus
            // 
            labelControlTechnicalStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlTechnicalStatus.Appearance.Font = new Font("Cairo", 9F);
            labelControlTechnicalStatus.Appearance.Options.UseFont = true;
            labelControlTechnicalStatus.Location = new Point(424, 116);
            labelControlTechnicalStatus.Margin = new Padding(3, 4, 3, 4);
            labelControlTechnicalStatus.Name = "labelControlTechnicalStatus";
            labelControlTechnicalStatus.Size = new Size(95, 23);
            labelControlTechnicalStatus.TabIndex = 26;
            labelControlTechnicalStatus.Text = "نتيجة التقييم الفني:";
            // 
            // labelControlStatus
            // 
            labelControlStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlStatus.Appearance.Font = new Font("Cairo", 9F);
            labelControlStatus.Appearance.Options.UseFont = true;
            labelControlStatus.Location = new Point(424, 151);
            labelControlStatus.Margin = new Padding(3, 4, 3, 4);
            labelControlStatus.Name = "labelControlStatus";
            labelControlStatus.Size = new Size(65, 23);
            labelControlStatus.TabIndex = 27;
            labelControlStatus.Text = "حالة التوصية:";
            // 
            // labelControlQuotation
            // 
            labelControlQuotation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlQuotation.Appearance.Font = new Font("Cairo", 9F);
            labelControlQuotation.Appearance.Options.UseFont = true;
            labelControlQuotation.Location = new Point(950, 81);
            labelControlQuotation.Margin = new Padding(3, 4, 3, 4);
            labelControlQuotation.Name = "labelControlQuotation";
            labelControlQuotation.Size = new Size(117, 23);
            labelControlQuotation.TabIndex = 19;
            labelControlQuotation.Text = "عرض المورد الموصى به:";
            // 
            // labelControlIsLowestBid
            // 
            labelControlIsLowestBid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlIsLowestBid.Appearance.Font = new Font("Cairo", 9F);
            labelControlIsLowestBid.Appearance.Options.UseFont = true;
            labelControlIsLowestBid.Location = new Point(950, 116);
            labelControlIsLowestBid.Margin = new Padding(3, 4, 3, 4);
            labelControlIsLowestBid.Name = "labelControlIsLowestBid";
            labelControlIsLowestBid.Size = new Size(51, 23);
            labelControlIsLowestBid.TabIndex = 20;
            labelControlIsLowestBid.Text = "أقل عرض؟";
            // 
            // labelControlBudgetStatus
            // 
            labelControlBudgetStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlBudgetStatus.Appearance.Font = new Font("Cairo", 9F);
            labelControlBudgetStatus.Appearance.Options.UseFont = true;
            labelControlBudgetStatus.Location = new Point(950, 151);
            labelControlBudgetStatus.Margin = new Padding(3, 4, 3, 4);
            labelControlBudgetStatus.Name = "labelControlBudgetStatus";
            labelControlBudgetStatus.Size = new Size(64, 23);
            labelControlBudgetStatus.TabIndex = 21;
            labelControlBudgetStatus.Text = "حالة الموازنة:";
            // 
            // labelControlRecommendationReason
            // 
            labelControlRecommendationReason.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlRecommendationReason.Appearance.Font = new Font("Cairo", 9F);
            labelControlRecommendationReason.Appearance.Options.UseFont = true;
            labelControlRecommendationReason.Location = new Point(950, 186);
            labelControlRecommendationReason.Margin = new Padding(3, 4, 3, 4);
            labelControlRecommendationReason.Name = "labelControlRecommendationReason";
            labelControlRecommendationReason.Size = new Size(68, 23);
            labelControlRecommendationReason.TabIndex = 22;
            labelControlRecommendationReason.Text = "سبب التوصية:";
            // 
            // labelControlDeviationJustification
            // 
            labelControlDeviationJustification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlDeviationJustification.Appearance.Font = new Font("Cairo", 9F);
            labelControlDeviationJustification.Appearance.Options.UseFont = true;
            labelControlDeviationJustification.Location = new Point(950, 289);
            labelControlDeviationJustification.Margin = new Padding(3, 4, 3, 4);
            labelControlDeviationJustification.Name = "labelControlDeviationJustification";
            labelControlDeviationJustification.Size = new Size(128, 23);
            labelControlDeviationJustification.TabIndex = 23;
            labelControlDeviationJustification.Text = "مبرر الانحراف عن أقل سعر:";
            // 
            // labelControlRFQ
            // 
            labelControlRFQ.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlRFQ.Appearance.Font = new Font("Cairo", 9F);
            labelControlRFQ.Appearance.Options.UseFont = true;
            labelControlRFQ.Location = new Point(950, 46);
            labelControlRFQ.Margin = new Padding(3, 4, 3, 4);
            labelControlRFQ.Name = "labelControlRFQ";
            labelControlRFQ.Size = new Size(130, 23);
            labelControlRFQ.TabIndex = 1;
            labelControlRFQ.Text = "طلب عروض الأسعار (RFQ):";
            // 
            // frmAwardRecommendationAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1092, 556);
            Controls.Add(groupControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "frmAwardRecommendationAddEdit";
            RightToLeft = RightToLeft.Yes;
            Text = "إضافة / تعديل توصية ترسية";
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)memoEditDeviationJustification.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEditRecommendationReason.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditTechnicalStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditRecommendedAmount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditNum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditBudgetStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditIsLowestBid.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditQuotation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditRFQ.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiFirst;
        private DevExpress.XtraBars.BarButtonItem bbiPrev;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.BarButtonItem bbiNext;
        private DevExpress.XtraBars.BarButtonItem bbiLast;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem btnPrintRFQ;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControlRFQ;
        private DevExpress.XtraEditors.LabelControl labelControlQuotation;
        private DevExpress.XtraEditors.LabelControl labelControlIsLowestBid;
        private DevExpress.XtraEditors.LabelControl labelControlBudgetStatus;
        private DevExpress.XtraEditors.LabelControl labelControlRecommendationReason;
        private DevExpress.XtraEditors.LabelControl labelControlDeviationJustification;
        private DevExpress.XtraEditors.LabelControl labelControlNum;
        private DevExpress.XtraEditors.LabelControl labelControlRecommendedAmount;
        private DevExpress.XtraEditors.LabelControl labelControlTechnicalStatus;
        private DevExpress.XtraEditors.LabelControl labelControlStatus;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditRFQ;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditQuotation;
        private DevExpress.XtraEditors.TextEdit textEditIsLowestBid;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditBudgetStatus;
        private DevExpress.XtraEditors.TextEdit textEditNum;
        private DevExpress.XtraEditors.TextEdit textEditRecommendedAmount;
        private DevExpress.XtraEditors.TextEdit textEditTechnicalStatus;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditStatus;
        private DevExpress.XtraEditors.MemoEdit memoEditRecommendationReason;
        private DevExpress.XtraEditors.MemoEdit memoEditDeviationJustification;
    }
}