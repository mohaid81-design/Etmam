namespace Etmam
{
    partial class frmTransmittalAddEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransmittalAddEdit));
            bbiEmail = new DevExpress.XtraBars.BarButtonItem();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            bbiSave = new DevExpress.XtraBars.BarButtonItem();
            bbiImportSchedule = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiFirst = new DevExpress.XtraBars.BarButtonItem();
            bbiPrev = new DevExpress.XtraBars.BarButtonItem();
            beiSearchNum = new DevExpress.XtraBars.BarEditItem();
            repositoryItemmemDescription = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            bbiSearch = new DevExpress.XtraBars.BarButtonItem();
            bbiNext = new DevExpress.XtraBars.BarButtonItem();
            bbiLast = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            bar2 = new DevExpress.XtraBars.Bar();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            bbiCopyPrevious = new DevExpress.XtraBars.BarButtonItem();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            txtRev = new DevExpress.XtraEditors.TextEdit();
            labelControl7 = new DevExpress.XtraEditors.LabelControl();
            txtNum = new DevExpress.XtraEditors.TextEdit();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            dtDate = new DevExpress.XtraEditors.DateEdit();
            memDescription = new DevExpress.XtraEditors.MemoEdit();
            cbeType = new DevExpress.XtraEditors.ComboBoxEdit();
            cbeCategory = new DevExpress.XtraEditors.ComboBoxEdit();
            coShift = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl8 = new DevExpress.XtraEditors.LabelControl();
            memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            labelControl9 = new DevExpress.XtraEditors.LabelControl();
            labelControl10 = new DevExpress.XtraEditors.LabelControl();
            memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            memoEdit3 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemmemDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRev.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbeType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbeCategory.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coShift.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit3.Properties).BeginInit();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar2, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = imageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiFirst, bbiPrev, beiSearchNum, bbiSearch, bbiNext, bbiLast, bbiNew, bbiSave, bbiDelete, bbiPrint, bbiCopyPrevious, bbiImportSchedule, bbiEmail });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 35;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemmemDescription });
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 1;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEmail, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiImportSchedule, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(bbiFirst, true), new DevExpress.XtraBars.LinkPersistInfo(bbiPrev), new DevExpress.XtraBars.LinkPersistInfo(beiSearchNum), new DevExpress.XtraBars.LinkPersistInfo(bbiSearch), new DevExpress.XtraBars.LinkPersistInfo(bbiNext), new DevExpress.XtraBars.LinkPersistInfo(bbiLast), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiNew
            // 
            bbiNew.Caption = "جديد";
            bbiNew.Id = 0;
            bbiNew.ImageOptions.ImageIndex = 0;
            bbiNew.Name = "bbiNew";
            bbiNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiSave
            // 
            bbiSave.Caption = "حفظ";
            bbiSave.Id = 2;
            bbiSave.ImageOptions.ImageIndex = 7;
            bbiSave.Name = "bbiSave";
            bbiSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiEmail
            // 
            bbiEmail.Caption = "إرسال إيميل";
            bbiEmail.Id = 40;
            bbiEmail.ImageOptions.ImageIndex = 5;
            bbiEmail.Name = "bbiEmail";
            bbiEmail.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiImportSchedule
            // 
            bbiImportSchedule.Caption = "استيراد الجدول الزمني";
            bbiImportSchedule.Hint = "استيراد بيانات الأنشطة والتواريخ من ملف Excel أو P6 XER";
            bbiImportSchedule.Id = 36;
            bbiImportSchedule.ImageOptions.ImageIndex = 8;
            bbiImportSchedule.Name = "bbiImportSchedule";
            bbiImportSchedule.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 3;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.Name = "bbiDelete";
            bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiFirst
            // 
            bbiFirst.Caption = "الأول";
            bbiFirst.Id = 30;
            bbiFirst.ImageOptions.SvgImage = Properties.Resources.last;
            bbiFirst.Name = "bbiFirst";
            // 
            // bbiPrev
            // 
            bbiPrev.Caption = "السابق";
            bbiPrev.Id = 31;
            bbiPrev.ImageOptions.ImageIndex = 15;
            bbiPrev.ImageOptions.SvgImage = Properties.Resources.next;
            bbiPrev.Name = "bbiPrev";
            // 
            // beiSearchNum
            // 
            beiSearchNum.Caption = "بحث برقم المسلسل";
            beiSearchNum.Edit = repositoryItemmemDescription;
            beiSearchNum.EditWidth = 60;
            beiSearchNum.Hint = "اكتب آخر 3 أرقام من رقم التقرير واضغط Enter";
            beiSearchNum.Id = 34;
            beiSearchNum.Name = "beiSearchNum";
            // 
            // repositoryItemmemDescription
            // 
            repositoryItemmemDescription.Appearance.Options.UseTextOptions = true;
            repositoryItemmemDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            repositoryItemmemDescription.AutoHeight = false;
            repositoryItemmemDescription.Mask.EditMask = "d3";
            repositoryItemmemDescription.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryItemmemDescription.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemmemDescription.Name = "repositoryItemmemDescription";
            // 
            // bbiSearch
            // 
            bbiSearch.Caption = "بحث";
            bbiSearch.Hint = "البحث عن التقرير بالرقم المسلسل";
            bbiSearch.Id = 35;
            bbiSearch.ImageOptions.ImageIndex = 14;
            bbiSearch.ImageOptions.SvgImage = Properties.Resources.movedown;
            bbiSearch.Name = "bbiSearch";
            // 
            // bbiNext
            // 
            bbiNext.Caption = "التالي";
            bbiNext.Id = 32;
            bbiNext.ImageOptions.ImageIndex = 16;
            bbiNext.ImageOptions.SvgImage = Properties.Resources.prev;
            bbiNext.Name = "bbiNext";
            // 
            // bbiLast
            // 
            bbiLast.Caption = "الأخير";
            bbiLast.Id = 33;
            bbiLast.ImageOptions.ImageIndex = 10;
            bbiLast.ImageOptions.SvgImage = Properties.Resources.first;
            bbiLast.Name = "bbiLast";
            // 
            // bbiPrint
            // 
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 5;
            bbiPrint.ImageOptions.ImageIndex = 4;
            bbiPrint.Name = "bbiPrint";
            bbiPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            bar2.Visible = false;
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
            barDockControlTop.Margin = new Padding(3, 7, 3, 7);
            barDockControlTop.Size = new Size(990, 48);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 477);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 7, 3, 7);
            barDockControlBottom.Size = new Size(990, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 48);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 7, 3, 7);
            barDockControlLeft.Size = new Size(0, 429);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(990, 48);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 7, 3, 7);
            barDockControlRight.Size = new Size(0, 429);
            // 
            // imageCollection1
            // 
            //imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            //imageCollection1.Images.SetKeyName(0, "1_New.png");
            //imageCollection1.Images.SetKeyName(1, "2_ReIssue.png");
            //imageCollection1.Images.SetKeyName(2, "3_Save.png");
            //imageCollection1.Images.SetKeyName(3, "4_Delete.png");
            //imageCollection1.Images.SetKeyName(4, "5_Print.png");
            //imageCollection1.Images.SetKeyName(5, "6_Search.png");
            //imageCollection1.Images.SetKeyName(6, "refresh.png");
            //imageCollection1.Images.SetKeyName(7, "3_Save.png");
            //imageCollection1.InsertImage(Properties.Resources.edit_16x161, "edit_16x161", typeof(Properties.Resources), 8);
            //imageCollection1.Images.SetKeyName(8, "edit_16x161");
            //imageCollection1.InsertImage(Properties.Resources.sortbyinvoice_16x165, "sortbyinvoice_16x165", typeof(Properties.Resources), 9);
            //imageCollection1.Images.SetKeyName(9, "sortbyinvoice_16x165");
            // 
            // bbiCopyPrevious
            // 
            bbiCopyPrevious.Caption = "جلب بيانات اليوم السابق";
            bbiCopyPrevious.Hint = "نسخ كافة البيانات التشغيلية من آخر تقرير تم إنشاؤه";
            bbiCopyPrevious.Id = 26;
            bbiCopyPrevious.ImageOptions.ImageIndex = 9;
            bbiCopyPrevious.Name = "bbiCopyPrevious";
            bbiCopyPrevious.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // svgImageCollection1
            // 
            //svgImageCollection1.Add("weather_cloudy", "image://svgimages/icon builder/weather_cloudy.svg");
            //svgImageCollection1.Add("weather_degreecelsius", "image://svgimages/icon builder/weather_degreecelsius.svg");
            //svgImageCollection1.Add("weather_fog", "image://svgimages/icon builder/weather_fog.svg");
            //svgImageCollection1.Add("weather_hail", "image://svgimages/icon builder/weather_hail.svg");
            //svgImageCollection1.Add("weather_humidity", "image://svgimages/icon builder/weather_humidity.svg");
            //svgImageCollection1.Add("weather_lightning", "image://svgimages/icon builder/weather_lightning.svg");
            //svgImageCollection1.Add("weather_moon", "image://svgimages/icon builder/weather_moon.svg");
            //svgImageCollection1.Add("weather_partlycloudyday", "image://svgimages/icon builder/weather_partlycloudyday.svg");
            //svgImageCollection1.Add("weather_partlycloudynight", "image://svgimages/icon builder/weather_partlycloudynight.svg");
            //svgImageCollection1.Add("weather_rain", "image://svgimages/icon builder/weather_rain.svg");
            //svgImageCollection1.Add("weather_rainandhail", "image://svgimages/icon builder/weather_rainandhail.svg");
            //svgImageCollection1.Add("weather_rainheavy", "image://svgimages/icon builder/weather_rainheavy.svg");
            //svgImageCollection1.Add("weather_rainlight", "image://svgimages/icon builder/weather_rainlight.svg");
            //svgImageCollection1.Add("weather_snow", "image://svgimages/icon builder/weather_snow.svg");
            //svgImageCollection1.Add("weather_snowfall", "image://svgimages/icon builder/weather_snowfall.svg");
            //svgImageCollection1.Add("weather_snowfallheavy", "image://svgimages/icon builder/weather_snowfallheavy.svg");
            //svgImageCollection1.Add("weather_snowfalllight", "image://svgimages/icon builder/weather_snowfalllight.svg");
            //svgImageCollection1.Add("weather_storm", "image://svgimages/icon builder/weather_storm.svg");
            //svgImageCollection1.Add("weather_sunny", "image://svgimages/icon builder/weather_sunny.svg");
            //svgImageCollection1.Add("weather_temperature", "image://svgimages/icon builder/weather_temperature.svg");
            //svgImageCollection1.Add("weather_umbrella", "image://svgimages/icon builder/weather_umbrella.svg");
            //svgImageCollection1.Add("weather_water", "image://svgimages/icon builder/weather_water.svg");
            //svgImageCollection1.Add("weather_wind", "image://svgimages/icon builder/weather_wind.svg");
            // 
            // txtRev
            // 
            txtRev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRev.EditValue = "0";
            txtRev.Enabled = false;
            txtRev.Location = new Point(620, 93);
            txtRev.Margin = new Padding(3, 7, 3, 7);
            txtRev.MenuManager = barManager1;
            txtRev.Name = "txtRev";
            txtRev.Properties.Appearance.BackColor = SystemColors.ControlLight;
            txtRev.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtRev.Properties.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            txtRev.Properties.Appearance.Options.UseBackColor = true;
            txtRev.Properties.Appearance.Options.UseFont = true;
            txtRev.Properties.Appearance.Options.UseForeColor = true;
            txtRev.Properties.Appearance.Options.UseTextOptions = true;
            txtRev.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtRev.Properties.AutoHeight = false;
            txtRev.Size = new Size(266, 28);
            txtRev.TabIndex = 40;
            // 
            // labelControl7
            // 
            labelControl7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl7.Appearance.Font = new Font("Cairo", 9F);
            labelControl7.Appearance.Options.UseFont = true;
            labelControl7.Appearance.Options.UseTextOptions = true;
            labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl7.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl7.Location = new Point(898, 93);
            labelControl7.Margin = new Padding(3, 7, 3, 7);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new Size(80, 28);
            labelControl7.TabIndex = 39;
            labelControl7.Text = "رقم الإصدارة:";
            // 
            // txtNum
            // 
            txtNum.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNum.EditValue = "001";
            txtNum.Enabled = false;
            txtNum.Location = new Point(620, 62);
            txtNum.Margin = new Padding(3, 7, 3, 7);
            txtNum.MenuManager = barManager1;
            txtNum.Name = "txtNum";
            txtNum.Properties.Appearance.BackColor = SystemColors.ControlLight;
            txtNum.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtNum.Properties.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            txtNum.Properties.Appearance.Options.UseBackColor = true;
            txtNum.Properties.Appearance.Options.UseFont = true;
            txtNum.Properties.Appearance.Options.UseForeColor = true;
            txtNum.Properties.Appearance.Options.UseTextOptions = true;
            txtNum.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtNum.Properties.AutoHeight = false;
            txtNum.Size = new Size(266, 28);
            txtNum.TabIndex = 29;
            // 
            // labelControl6
            // 
            labelControl6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl6.Appearance.Font = new Font("Cairo", 9F);
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Appearance.Options.UseTextOptions = true;
            labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl6.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl6.Location = new Point(898, 159);
            labelControl6.Margin = new Padding(3, 7, 3, 7);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new Size(80, 28);
            labelControl6.TabIndex = 38;
            labelControl6.Text = "الموضوع:";
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new Font("Cairo", 9F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl1.Location = new Point(898, 62);
            labelControl1.Margin = new Padding(3, 7, 3, 7);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(80, 28);
            labelControl1.TabIndex = 28;
            labelControl1.Text = "رقم الإرسالية:";
            // 
            // labelControl2
            // 
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 9F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Appearance.Options.UseTextOptions = true;
            labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl2.Location = new Point(532, 62);
            labelControl2.Margin = new Padding(3, 7, 3, 7);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(80, 28);
            labelControl2.TabIndex = 31;
            labelControl2.Text = "النوع:";
            // 
            // labelControl5
            // 
            labelControl5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl5.Appearance.Font = new Font("Cairo", 9F);
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Appearance.Options.UseTextOptions = true;
            labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl5.Location = new Point(532, 124);
            labelControl5.Margin = new Padding(3, 7, 3, 7);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(80, 28);
            labelControl5.TabIndex = 35;
            labelControl5.Text = "الغرض:";
            // 
            // labelControl3
            // 
            labelControl3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl3.Appearance.Font = new Font("Cairo", 9F);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Appearance.Options.UseTextOptions = true;
            labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl3.Location = new Point(532, 93);
            labelControl3.Margin = new Padding(3, 7, 3, 7);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(80, 28);
            labelControl3.TabIndex = 32;
            labelControl3.Text = "التصنيف:";
            // 
            // labelControl4
            // 
            labelControl4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl4.Appearance.Font = new Font("Cairo", 9F);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Appearance.Options.UseTextOptions = true;
            labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl4.Location = new Point(898, 124);
            labelControl4.Margin = new Padding(3, 7, 3, 7);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(80, 28);
            labelControl4.TabIndex = 33;
            labelControl4.Text = "تاريخ الإرسالية:";
            // 
            // dtDate
            // 
            dtDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtDate.EditValue = null;
            dtDate.Location = new Point(620, 124);
            dtDate.Margin = new Padding(3, 7, 3, 7);
            dtDate.MenuManager = barManager1;
            dtDate.Name = "dtDate";
            dtDate.Properties.Appearance.Font = new Font("Cairo", 9F);
            dtDate.Properties.Appearance.Options.UseFont = true;
            dtDate.Properties.AutoHeight = false;
            dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtDate.Size = new Size(266, 28);
            dtDate.TabIndex = 34;
            // 
            // memDescription
            // 
            memDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memDescription.EditValue = "";
            memDescription.Location = new Point(12, 159);
            memDescription.Margin = new Padding(3, 7, 3, 7);
            memDescription.MenuManager = barManager1;
            memDescription.Name = "memDescription";
            memDescription.Properties.Appearance.Font = new Font("Cairo", 9F);
            memDescription.Properties.Appearance.Options.UseFont = true;
            memDescription.Size = new Size(874, 28);
            memDescription.TabIndex = 37;
            // 
            // cbeType
            // 
            cbeType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbeType.EditValue = "";
            cbeType.Location = new Point(12, 62);
            cbeType.Margin = new Padding(3, 7, 3, 7);
            cbeType.MenuManager = barManager1;
            cbeType.Name = "cbeType";
            cbeType.Properties.Appearance.Font = new Font("Cairo", 9F);
            cbeType.Properties.Appearance.Options.UseFont = true;
            cbeType.Properties.AutoHeight = false;
            cbeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbeType.Properties.Items.AddRange(new object[] { "انشائي", "معماري", "ميكانيكا", "كهرباء", "اخرى" });
            cbeType.Size = new Size(508, 28);
            cbeType.TabIndex = 30;
            // 
            // cbeCategory
            // 
            cbeCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbeCategory.EditValue = "";
            cbeCategory.Location = new Point(12, 93);
            cbeCategory.Margin = new Padding(3, 7, 3, 7);
            cbeCategory.MenuManager = barManager1;
            cbeCategory.Name = "cbeCategory";
            cbeCategory.Properties.Appearance.Font = new Font("Cairo", 9F);
            cbeCategory.Properties.Appearance.Options.UseFont = true;
            cbeCategory.Properties.AutoHeight = false;
            cbeCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbeCategory.Properties.Items.AddRange(new object[] { "مخطط تنفيذي", "مخطط تصمصمي", "مخطط كما البناء" });
            cbeCategory.Size = new Size(508, 28);
            cbeCategory.TabIndex = 41;
            // 
            // coShift
            // 
            coShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            coShift.EditValue = "";
            coShift.Location = new Point(12, 124);
            coShift.Margin = new Padding(3, 7, 3, 7);
            coShift.MenuManager = barManager1;
            coShift.Name = "coShift";
            coShift.Properties.Appearance.Font = new Font("Cairo", 9F);
            coShift.Properties.Appearance.Options.UseFont = true;
            coShift.Properties.AutoHeight = false;
            coShift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            coShift.Properties.Items.AddRange(new object[] { "للمراجعه و الاعتماد", "للإطلاع", "طلب معلومات" });
            coShift.Size = new Size(508, 28);
            coShift.TabIndex = 36;
            // 
            // labelControl8
            // 
            labelControl8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl8.Appearance.Font = new Font("Cairo", 9F);
            labelControl8.Appearance.Options.UseFont = true;
            labelControl8.Appearance.Options.UseTextOptions = true;
            labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl8.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl8.Location = new Point(898, 256);
            labelControl8.Margin = new Padding(3, 7, 3, 7);
            labelControl8.Name = "labelControl8";
            labelControl8.Size = new Size(80, 28);
            labelControl8.TabIndex = 43;
            labelControl8.Text = "البيان:";
            // 
            // memoEdit1
            // 
            memoEdit1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memoEdit1.EditValue = "";
            memoEdit1.Location = new Point(12, 255);
            memoEdit1.Margin = new Padding(3, 7, 3, 7);
            memoEdit1.MenuManager = barManager1;
            memoEdit1.Name = "memoEdit1";
            memoEdit1.Properties.Appearance.Font = new Font("Cairo", 9F);
            memoEdit1.Properties.Appearance.Options.UseFont = true;
            memoEdit1.Size = new Size(874, 204);
            memoEdit1.TabIndex = 42;
            // 
            // labelControl9
            // 
            labelControl9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl9.Appearance.Font = new Font("Cairo", 9F);
            labelControl9.Appearance.Options.UseFont = true;
            labelControl9.Appearance.Options.UseTextOptions = true;
            labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl9.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl9.Location = new Point(898, 190);
            labelControl9.Margin = new Padding(3, 7, 3, 7);
            labelControl9.Name = "labelControl9";
            labelControl9.Size = new Size(80, 28);
            labelControl9.TabIndex = 44;
            labelControl9.Text = "مرسل الى:";
            // 
            // labelControl10
            // 
            labelControl10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl10.Appearance.Font = new Font("Cairo", 9F);
            labelControl10.Appearance.Options.UseFont = true;
            labelControl10.Appearance.Options.UseTextOptions = true;
            labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelControl10.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl10.Location = new Point(898, 221);
            labelControl10.Margin = new Padding(3, 7, 3, 7);
            labelControl10.Name = "labelControl10";
            labelControl10.Size = new Size(80, 28);
            labelControl10.TabIndex = 45;
            labelControl10.Text = "صورة الى:";
            // 
            // memoEdit2
            // 
            memoEdit2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memoEdit2.EditValue = "";
            memoEdit2.Location = new Point(12, 190);
            memoEdit2.Margin = new Padding(3, 7, 3, 7);
            memoEdit2.MenuManager = barManager1;
            memoEdit2.Name = "memoEdit2";
            memoEdit2.Properties.Appearance.Font = new Font("Cairo", 9F);
            memoEdit2.Properties.Appearance.Options.UseFont = true;
            memoEdit2.Size = new Size(874, 28);
            memoEdit2.TabIndex = 46;
            // 
            // memoEdit3
            // 
            memoEdit3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memoEdit3.EditValue = "";
            memoEdit3.Location = new Point(12, 221);
            memoEdit3.Margin = new Padding(3, 7, 3, 7);
            memoEdit3.MenuManager = barManager1;
            memoEdit3.Name = "memoEdit3";
            memoEdit3.Properties.Appearance.Font = new Font("Cairo", 9F);
            memoEdit3.Properties.Appearance.Options.UseFont = true;
            memoEdit3.Size = new Size(874, 28);
            memoEdit3.TabIndex = 47;
            // 
            // frmTransmittalAddEdit
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 495);
            Controls.Add(memoEdit3);
            Controls.Add(memoEdit2);
            Controls.Add(labelControl10);
            Controls.Add(labelControl9);
            Controls.Add(labelControl8);
            Controls.Add(memoEdit1);
            Controls.Add(txtRev);
            Controls.Add(labelControl7);
            Controls.Add(txtNum);
            Controls.Add(labelControl6);
            Controls.Add(labelControl1);
            Controls.Add(labelControl2);
            Controls.Add(labelControl5);
            Controls.Add(labelControl3);
            Controls.Add(labelControl4);
            Controls.Add(dtDate);
            Controls.Add(memDescription);
            Controls.Add(cbeType);
            Controls.Add(cbeCategory);
            Controls.Add(coShift);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new Font("Cairo", 9F);
            Name = "frmTransmittalAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إضافة/تعديل إرسالية";
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemmemDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRev.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbeType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbeCategory.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)coShift.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit3.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiImportSchedule;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiFirst;
        private DevExpress.XtraBars.BarButtonItem bbiPrev;
        private DevExpress.XtraBars.BarEditItem beiSearchNum;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemmemDescription;
        private DevExpress.XtraBars.BarButtonItem bbiSearch;
        private DevExpress.XtraBars.BarButtonItem bbiNext;
        private DevExpress.XtraBars.BarButtonItem bbiLast;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem bbiCopyPrevious;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.TextEdit txtRev;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtNum;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtDate;
        private DevExpress.XtraEditors.MemoEdit memDescription;
        private DevExpress.XtraEditors.ComboBoxEdit cbeType;
        private DevExpress.XtraEditors.ComboBoxEdit cbeCategory;
        private DevExpress.XtraEditors.ComboBoxEdit coShift;
        private DevExpress.XtraEditors.MemoEdit memoEdit3;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraBars.BarButtonItem bbiEmail;
    }
}
