namespace Etmam
{
    partial class frmNegotiationAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNegotiationAddEdit));
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
            labelControlLockNotice = new DevExpress.XtraEditors.LabelControl();
            labelControlRFQ = new DevExpress.XtraEditors.LabelControl();
            lookUpEditRFQ = new DevExpress.XtraEditors.LookUpEdit();
            labelControlQuotation = new DevExpress.XtraEditors.LabelControl();
            lookUpEditQuotation = new DevExpress.XtraEditors.LookUpEdit();
            labelControlRound = new DevExpress.XtraEditors.LabelControl();
            textEditRound = new DevExpress.XtraEditors.TextEdit();
            labelControlNegotiationDate = new DevExpress.XtraEditors.LabelControl();
            dateEditNegotiationDate = new DevExpress.XtraEditors.DateEdit();
            labelControlPreviousAmount = new DevExpress.XtraEditors.LabelControl();
            textEditPreviousAmount = new DevExpress.XtraEditors.TextEdit();
            labelControlNewAmount = new DevExpress.XtraEditors.LabelControl();
            textEditNewAmount = new DevExpress.XtraEditors.TextEdit();
            labelControlIsBAFO = new DevExpress.XtraEditors.LabelControl();
            checkEditIsBAFO = new DevExpress.XtraEditors.CheckEdit();
            labelControlNotes = new DevExpress.XtraEditors.LabelControl();
            memoEditNotes = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lookUpEditRFQ.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditQuotation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditRound.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditNegotiationDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditNegotiationDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditPreviousAmount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditNewAmount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEditIsBAFO.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEditNotes.Properties).BeginInit();
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
            barDockControlTop.Size = new Size(583, 35);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 764);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(583, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 35);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 729);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(583, 35);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 729);
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
            groupControl1.Controls.Add(labelControlLockNotice);
            groupControl1.Controls.Add(labelControlRFQ);
            groupControl1.Controls.Add(lookUpEditRFQ);
            groupControl1.Controls.Add(labelControlQuotation);
            groupControl1.Controls.Add(lookUpEditQuotation);
            groupControl1.Controls.Add(labelControlRound);
            groupControl1.Controls.Add(textEditRound);
            groupControl1.Controls.Add(labelControlNegotiationDate);
            groupControl1.Controls.Add(dateEditNegotiationDate);
            groupControl1.Controls.Add(labelControlPreviousAmount);
            groupControl1.Controls.Add(textEditPreviousAmount);
            groupControl1.Controls.Add(labelControlNewAmount);
            groupControl1.Controls.Add(textEditNewAmount);
            groupControl1.Controls.Add(labelControlIsBAFO);
            groupControl1.Controls.Add(checkEditIsBAFO);
            groupControl1.Controls.Add(labelControlNotes);
            groupControl1.Controls.Add(memoEditNotes);
            groupControl1.Dock = DockStyle.Fill;
            groupControl1.Location = new Point(0, 35);
            groupControl1.Margin = new Padding(3, 4, 3, 4);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(583, 729);
            groupControl1.TabIndex = 4;
            groupControl1.Text = "بيانات جولة التفاوض";
            // 
            // labelControlLockNotice
            // 
            labelControlLockNotice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlLockNotice.Appearance.Font = new Font("Cairo", 8.5F);
            labelControlLockNotice.Appearance.ForeColor = Color.FromArgb(128, 64, 64);
            labelControlLockNotice.Appearance.Options.UseFont = true;
            labelControlLockNotice.Appearance.Options.UseForeColor = true;
            labelControlLockNotice.Location = new Point(30, 626);
            labelControlLockNotice.Margin = new Padding(3, 4, 3, 4);
            labelControlLockNotice.Name = "labelControlLockNotice";
            labelControlLockNotice.Size = new Size(0, 20);
            labelControlLockNotice.TabIndex = 32;
            // 
            // labelControlRFQ
            // 
            labelControlRFQ.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlRFQ.Appearance.Font = new Font("Cairo", 8.5F);
            labelControlRFQ.Appearance.Options.UseFont = true;
            labelControlRFQ.Location = new Point(431, 41);
            labelControlRFQ.Margin = new Padding(3, 4, 3, 4);
            labelControlRFQ.Name = "labelControlRFQ";
            labelControlRFQ.Size = new Size(130, 23);
            labelControlRFQ.TabIndex = 16;
            labelControlRFQ.Text = "طلب عروض الأسعار (RFQ):";
            // 
            // lookUpEditRFQ
            // 
            lookUpEditRFQ.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditRFQ.Location = new Point(53, 37);
            lookUpEditRFQ.Margin = new Padding(3, 4, 3, 4);
            lookUpEditRFQ.Name = "lookUpEditRFQ";
            lookUpEditRFQ.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            lookUpEditRFQ.Properties.Appearance.Options.UseFont = true;
            lookUpEditRFQ.Properties.AutoHeight = false;
            lookUpEditRFQ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEditRFQ.Properties.NullText = "";
            lookUpEditRFQ.Size = new Size(372, 30);
            lookUpEditRFQ.TabIndex = 17;
            // 
            // labelControlQuotation
            // 
            labelControlQuotation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlQuotation.Appearance.Font = new Font("Cairo", 8.5F);
            labelControlQuotation.Appearance.Options.UseFont = true;
            labelControlQuotation.Location = new Point(431, 171);
            labelControlQuotation.Margin = new Padding(3, 4, 3, 4);
            labelControlQuotation.Name = "labelControlQuotation";
            labelControlQuotation.Size = new Size(61, 23);
            labelControlQuotation.TabIndex = 18;
            labelControlQuotation.Text = "عرض المورد:";
            // 
            // lookUpEditQuotation
            // 
            lookUpEditQuotation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditQuotation.Location = new Point(51, 167);
            lookUpEditQuotation.Margin = new Padding(3, 4, 3, 4);
            lookUpEditQuotation.Name = "lookUpEditQuotation";
            lookUpEditQuotation.Properties.Appearance.BackColor = Color.LightGreen;
            lookUpEditQuotation.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            lookUpEditQuotation.Properties.Appearance.Options.UseBackColor = true;
            lookUpEditQuotation.Properties.Appearance.Options.UseFont = true;
            lookUpEditQuotation.Properties.AutoHeight = false;
            lookUpEditQuotation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEditQuotation.Properties.NullText = "";
            lookUpEditQuotation.Size = new Size(374, 30);
            lookUpEditQuotation.TabIndex = 19;
            // 
            // labelControlRound
            // 
            labelControlRound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlRound.Appearance.Font = new Font("Cairo", 8.5F);
            labelControlRound.Appearance.Options.UseFont = true;
            labelControlRound.Location = new Point(431, 76);
            labelControlRound.Margin = new Padding(3, 4, 3, 4);
            labelControlRound.Name = "labelControlRound";
            labelControlRound.Size = new Size(33, 23);
            labelControlRound.TabIndex = 20;
            labelControlRound.Text = "الجولة:";
            // 
            // textEditRound
            // 
            textEditRound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textEditRound.Enabled = false;
            textEditRound.Location = new Point(53, 72);
            textEditRound.Margin = new Padding(3, 4, 3, 4);
            textEditRound.Name = "textEditRound";
            textEditRound.Properties.Appearance.BackColor = SystemColors.ControlLight;
            textEditRound.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            textEditRound.Properties.Appearance.Options.UseBackColor = true;
            textEditRound.Properties.Appearance.Options.UseFont = true;
            textEditRound.Properties.AutoHeight = false;
            textEditRound.Size = new Size(372, 30);
            textEditRound.TabIndex = 21;
            // 
            // labelControlNegotiationDate
            // 
            labelControlNegotiationDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlNegotiationDate.Appearance.Font = new Font("Cairo", 8.5F);
            labelControlNegotiationDate.Appearance.Options.UseFont = true;
            labelControlNegotiationDate.Location = new Point(431, 206);
            labelControlNegotiationDate.Margin = new Padding(3, 4, 3, 4);
            labelControlNegotiationDate.Name = "labelControlNegotiationDate";
            labelControlNegotiationDate.Size = new Size(58, 23);
            labelControlNegotiationDate.TabIndex = 22;
            labelControlNegotiationDate.Text = "تاريخ الجولة:";
            // 
            // dateEditNegotiationDate
            // 
            dateEditNegotiationDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateEditNegotiationDate.EditValue = new DateTime(2026, 7, 31, 0, 0, 0, 0);
            dateEditNegotiationDate.Location = new Point(51, 202);
            dateEditNegotiationDate.Margin = new Padding(3, 4, 3, 4);
            dateEditNegotiationDate.Name = "dateEditNegotiationDate";
            dateEditNegotiationDate.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            dateEditNegotiationDate.Properties.Appearance.Options.UseFont = true;
            dateEditNegotiationDate.Properties.AutoHeight = false;
            dateEditNegotiationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditNegotiationDate.Size = new Size(374, 30);
            dateEditNegotiationDate.TabIndex = 23;
            // 
            // labelControlPreviousAmount
            // 
            labelControlPreviousAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlPreviousAmount.Appearance.Font = new Font("Cairo", 8.5F);
            labelControlPreviousAmount.Appearance.Options.UseFont = true;
            labelControlPreviousAmount.Location = new Point(431, 111);
            labelControlPreviousAmount.Margin = new Padding(3, 4, 3, 4);
            labelControlPreviousAmount.Name = "labelControlPreviousAmount";
            labelControlPreviousAmount.Size = new Size(77, 23);
            labelControlPreviousAmount.TabIndex = 24;
            labelControlPreviousAmount.Text = "القيمة السابقة:";
            // 
            // textEditPreviousAmount
            // 
            textEditPreviousAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textEditPreviousAmount.Enabled = false;
            textEditPreviousAmount.Location = new Point(53, 107);
            textEditPreviousAmount.Margin = new Padding(3, 4, 3, 4);
            textEditPreviousAmount.Name = "textEditPreviousAmount";
            textEditPreviousAmount.Properties.Appearance.BackColor = SystemColors.ControlLight;
            textEditPreviousAmount.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            textEditPreviousAmount.Properties.Appearance.Options.UseBackColor = true;
            textEditPreviousAmount.Properties.Appearance.Options.UseFont = true;
            textEditPreviousAmount.Properties.AutoHeight = false;
            textEditPreviousAmount.Size = new Size(372, 30);
            textEditPreviousAmount.TabIndex = 25;
            // 
            // labelControlNewAmount
            // 
            labelControlNewAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlNewAmount.Appearance.Font = new Font("Cairo", 8.5F);
            labelControlNewAmount.Appearance.Options.UseFont = true;
            labelControlNewAmount.Location = new Point(431, 241);
            labelControlNewAmount.Margin = new Padding(3, 4, 3, 4);
            labelControlNewAmount.Name = "labelControlNewAmount";
            labelControlNewAmount.Size = new Size(140, 23);
            labelControlNewAmount.TabIndex = 26;
            labelControlNewAmount.Text = "القيمة الجديدة بعد التفاوض:";
            // 
            // textEditNewAmount
            // 
            textEditNewAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textEditNewAmount.Location = new Point(51, 237);
            textEditNewAmount.Margin = new Padding(3, 4, 3, 4);
            textEditNewAmount.Name = "textEditNewAmount";
            textEditNewAmount.Properties.Appearance.BackColor = Color.LightGreen;
            textEditNewAmount.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            textEditNewAmount.Properties.Appearance.Options.UseBackColor = true;
            textEditNewAmount.Properties.Appearance.Options.UseFont = true;
            textEditNewAmount.Properties.AutoHeight = false;
            textEditNewAmount.Size = new Size(374, 30);
            textEditNewAmount.TabIndex = 27;
            // 
            // labelControlIsBAFO
            // 
            labelControlIsBAFO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlIsBAFO.Appearance.Font = new Font("Cairo", 8.5F);
            labelControlIsBAFO.Appearance.Options.UseFont = true;
            labelControlIsBAFO.Location = new Point(431, 141);
            labelControlIsBAFO.Margin = new Padding(3, 4, 3, 4);
            labelControlIsBAFO.Name = "labelControlIsBAFO";
            labelControlIsBAFO.Size = new Size(62, 23);
            labelControlIsBAFO.TabIndex = 28;
            labelControlIsBAFO.Text = "عرض نهائي؟";
            // 
            // checkEditIsBAFO
            // 
            checkEditIsBAFO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkEditIsBAFO.Location = new Point(53, 142);
            checkEditIsBAFO.Margin = new Padding(3, 4, 3, 4);
            checkEditIsBAFO.Name = "checkEditIsBAFO";
            checkEditIsBAFO.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            checkEditIsBAFO.Properties.Appearance.Options.UseFont = true;
            checkEditIsBAFO.Properties.Caption = "";
            checkEditIsBAFO.Size = new Size(372, 20);
            checkEditIsBAFO.TabIndex = 29;
            // 
            // labelControlNotes
            // 
            labelControlNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlNotes.Appearance.Font = new Font("Cairo", 8.5F);
            labelControlNotes.Appearance.Options.UseFont = true;
            labelControlNotes.Location = new Point(431, 281);
            labelControlNotes.Margin = new Padding(3, 4, 3, 4);
            labelControlNotes.Name = "labelControlNotes";
            labelControlNotes.Size = new Size(48, 23);
            labelControlNotes.TabIndex = 30;
            labelControlNotes.Text = "ملاحظات:";
            // 
            // memoEditNotes
            // 
            memoEditNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memoEditNotes.Location = new Point(51, 272);
            memoEditNotes.Margin = new Padding(3, 4, 3, 4);
            memoEditNotes.Name = "memoEditNotes";
            memoEditNotes.Properties.Appearance.Font = new Font("Cairo", 8.5F);
            memoEditNotes.Properties.Appearance.Options.UseFont = true;
            memoEditNotes.Size = new Size(374, 334);
            memoEditNotes.TabIndex = 31;
            // 
            // frmNegotiationAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 782);
            Controls.Add(groupControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNegotiationAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إضافة / تعديل جولة تفاوض";
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lookUpEditRFQ.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditQuotation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditRound.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditNegotiationDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditNegotiationDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditPreviousAmount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditNewAmount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEditIsBAFO.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEditNotes.Properties).EndInit();
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
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem btnPrintRFQ;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControlRFQ;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditRFQ;
        private DevExpress.XtraEditors.LabelControl labelControlQuotation;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditQuotation;
        private DevExpress.XtraEditors.LabelControl labelControlRound;
        private DevExpress.XtraEditors.TextEdit textEditRound;
        private DevExpress.XtraEditors.LabelControl labelControlNegotiationDate;
        private DevExpress.XtraEditors.DateEdit dateEditNegotiationDate;
        private DevExpress.XtraEditors.LabelControl labelControlPreviousAmount;
        private DevExpress.XtraEditors.TextEdit textEditPreviousAmount;
        private DevExpress.XtraEditors.LabelControl labelControlNewAmount;
        private DevExpress.XtraEditors.TextEdit textEditNewAmount;
        private DevExpress.XtraEditors.LabelControl labelControlIsBAFO;
        private DevExpress.XtraEditors.CheckEdit checkEditIsBAFO;
        private DevExpress.XtraEditors.LabelControl labelControlNotes;
        private DevExpress.XtraEditors.MemoEdit memoEditNotes;
        private DevExpress.XtraEditors.LabelControl labelControlLockNotice;
    }
}