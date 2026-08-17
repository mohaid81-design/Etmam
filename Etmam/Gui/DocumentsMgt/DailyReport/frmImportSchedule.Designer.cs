using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Etmam
{
    public partial class frmImportSchedule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiOpenFile = new DevExpress.XtraBars.BarButtonItem();
            bbiImport = new DevExpress.XtraBars.BarButtonItem();
            bbiClose = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            lueProject = new DevExpress.XtraEditors.LookUpEdit();
            txtNewScheduleName = new DevExpress.XtraEditors.TextEdit();
            txtFilePath = new DevExpress.XtraEditors.ButtonEdit();
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            tpMapping = new DevExpress.XtraTab.XtraTabPage();
            layoutControlMapping = new DevExpress.XtraLayout.LayoutControl();
            cboItem = new DevExpress.XtraEditors.ComboBoxEdit();
            cboDescription = new DevExpress.XtraEditors.ComboBoxEdit();
            cboLocation = new DevExpress.XtraEditors.ComboBoxEdit();
            cboCategory = new DevExpress.XtraEditors.ComboBoxEdit();
            cboStartDate = new DevExpress.XtraEditors.ComboBoxEdit();
            cboEndDate = new DevExpress.XtraEditors.ComboBoxEdit();
            cboActualStartDate = new DevExpress.XtraEditors.ComboBoxEdit();
            cboActualEndDate = new DevExpress.XtraEditors.ComboBoxEdit();
            cboWBSId = new DevExpress.XtraEditors.ComboBoxEdit();
            cboWBSName = new DevExpress.XtraEditors.ComboBoxEdit();
            cboActivityId = new DevExpress.XtraEditors.ComboBoxEdit();
            layoutControlGroupMapping = new DevExpress.XtraLayout.LayoutControlGroup();
            lciActivityName = new DevExpress.XtraLayout.LayoutControlItem();
            lciActivityCode = new DevExpress.XtraLayout.LayoutControlItem();
            lciLocation = new DevExpress.XtraLayout.LayoutControlItem();
            lciCategory = new DevExpress.XtraLayout.LayoutControlItem();
            lciStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            lciEndDate = new DevExpress.XtraLayout.LayoutControlItem();
            lciActualStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            lciActualEndDate = new DevExpress.XtraLayout.LayoutControlItem();
            lciWBSId = new DevExpress.XtraLayout.LayoutControlItem();
            lciWBSName = new DevExpress.XtraLayout.LayoutControlItem();
            lciActivityId = new DevExpress.XtraLayout.LayoutControlItem();
            tpPreview = new DevExpress.XtraTab.XtraTabPage();
            treeListPreview = new DevExpress.XtraTreeList.TreeList();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lciProject = new DevExpress.XtraLayout.LayoutControlItem();
            lciSchedule = new DevExpress.XtraLayout.LayoutControlItem();
            lciFilePath = new DevExpress.XtraLayout.LayoutControlItem();
            lciTabs = new DevExpress.XtraLayout.LayoutControlItem();
            panelMain = new DevExpress.XtraEditors.RoundedSkinPanel();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((ISupportInitialize)barManager1).BeginInit();
            ((ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((ISupportInitialize)lueProject.Properties).BeginInit();
            ((ISupportInitialize)txtNewScheduleName.Properties).BeginInit();
            ((ISupportInitialize)txtFilePath.Properties).BeginInit();
            ((ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            tpMapping.SuspendLayout();
            ((ISupportInitialize)layoutControlMapping).BeginInit();
            layoutControlMapping.SuspendLayout();
            ((ISupportInitialize)cboItem.Properties).BeginInit();
            ((ISupportInitialize)cboDescription.Properties).BeginInit();
            ((ISupportInitialize)cboLocation.Properties).BeginInit();
            ((ISupportInitialize)cboCategory.Properties).BeginInit();
            ((ISupportInitialize)cboStartDate.Properties).BeginInit();
            ((ISupportInitialize)cboEndDate.Properties).BeginInit();
            ((ISupportInitialize)cboActualStartDate.Properties).BeginInit();
            ((ISupportInitialize)cboActualEndDate.Properties).BeginInit();
            ((ISupportInitialize)cboWBSId.Properties).BeginInit();
            ((ISupportInitialize)cboWBSName.Properties).BeginInit();
            ((ISupportInitialize)cboActivityId.Properties).BeginInit();
            ((ISupportInitialize)layoutControlGroupMapping).BeginInit();
            ((ISupportInitialize)lciActivityName).BeginInit();
            ((ISupportInitialize)lciActivityCode).BeginInit();
            ((ISupportInitialize)lciLocation).BeginInit();
            ((ISupportInitialize)lciCategory).BeginInit();
            ((ISupportInitialize)lciStartDate).BeginInit();
            ((ISupportInitialize)lciEndDate).BeginInit();
            ((ISupportInitialize)lciActualStartDate).BeginInit();
            ((ISupportInitialize)lciActualEndDate).BeginInit();
            ((ISupportInitialize)lciWBSId).BeginInit();
            ((ISupportInitialize)lciWBSName).BeginInit();
            ((ISupportInitialize)lciActivityId).BeginInit();
            tpPreview.SuspendLayout();
            ((ISupportInitialize)treeListPreview).BeginInit();
            ((ISupportInitialize)Root).BeginInit();
            ((ISupportInitialize)lciProject).BeginInit();
            ((ISupportInitialize)lciSchedule).BeginInit();
            ((ISupportInitialize)lciFilePath).BeginInit();
            ((ISupportInitialize)lciTabs).BeginInit();
            ((ISupportInitialize)panelMain).BeginInit();
            panelMain.SuspendLayout();
            ((ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiOpenFile, bbiImport, bbiClose });
            barManager1.MaxItemId = 3;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiOpenFile, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiImport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiOpenFile
            // 
            bbiOpenFile.Caption = "فتح الملف";
            bbiOpenFile.Id = 0;
            bbiOpenFile.Name = "bbiOpenFile";
            bbiOpenFile.ItemClick += BbiOpenFile_ItemClick;
            // 
            // bbiImport
            // 
            bbiImport.Caption = "استيراد";
            bbiImport.Id = 1;
            bbiImport.Name = "bbiImport";
            bbiImport.ItemClick += BbiImport_ItemClick;
            // 
            // bbiClose
            // 
            bbiClose.Caption = "إغلاق";
            bbiClose.Id = 2;
            bbiClose.Name = "bbiClose";
            bbiClose.ItemClick += BbiClose_ItemClick;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(802, 24);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 602);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(802, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 24);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 578);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(802, 24);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 578);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(lueProject);
            layoutControl1.Controls.Add(txtNewScheduleName);
            layoutControl1.Controls.Add(txtFilePath);
            layoutControl1.Controls.Add(xtraTabControl1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1113, 311, 650, 400);
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.RightToLeft = RightToLeft.Yes;
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(802, 578);
            layoutControl1.TabIndex = 4;
            layoutControl1.Text = "layoutControl1";
            // 
            // lueProject
            // 
            lueProject.Location = new Point(13, 0);
            lueProject.Name = "lueProject";
            lueProject.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueProject.Properties.Appearance.Options.UseFont = true;
            lueProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueProject.Size = new Size(697, 30);
            lueProject.StyleController = layoutControl1;
            lueProject.TabIndex = 4;
            lueProject.EditValueChanged += LueProject_EditValueChanged;
            // 
            // txtNewScheduleName
            // 
            txtNewScheduleName.Location = new Point(12, 44);
            txtNewScheduleName.Name = "txtNewScheduleName";
            txtNewScheduleName.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtNewScheduleName.Properties.Appearance.Options.UseFont = true;
            txtNewScheduleName.Size = new Size(698, 30);
            txtNewScheduleName.StyleController = layoutControl1;
            txtNewScheduleName.TabIndex = 5;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(12, 76);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtFilePath.Properties.Appearance.Options.UseFont = true;
            txtFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            txtFilePath.Size = new Size(698, 30);
            txtFilePath.StyleController = layoutControl1;
            txtFilePath.TabIndex = 5;
            txtFilePath.ButtonClick += TxtFilePath_ButtonClick;
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.AppearancePage.Header.Font = new Font("Cairo", 9F, FontStyle.Bold);
            xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            xtraTabControl1.Location = new Point(12, 108);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = tpMapping;
            xtraTabControl1.Size = new Size(766, 458);
            xtraTabControl1.TabIndex = 6;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tpMapping, tpPreview });
            // 
            // tpMapping
            // 
            tpMapping.Controls.Add(layoutControlMapping);
            tpMapping.Name = "tpMapping";
            tpMapping.Size = new Size(764, 419);
            tpMapping.Text = "ربط الأعمدة";
            // 
            // layoutControlMapping
            // 
            layoutControlMapping.Controls.Add(cboItem);
            layoutControlMapping.Controls.Add(cboDescription);
            layoutControlMapping.Controls.Add(cboLocation);
            layoutControlMapping.Controls.Add(cboCategory);
            layoutControlMapping.Controls.Add(cboStartDate);
            layoutControlMapping.Controls.Add(cboEndDate);
            layoutControlMapping.Controls.Add(cboActualStartDate);
            layoutControlMapping.Controls.Add(cboActualEndDate);
            layoutControlMapping.Controls.Add(cboWBSId);
            layoutControlMapping.Controls.Add(cboWBSName);
            layoutControlMapping.Controls.Add(cboActivityId);
            layoutControlMapping.Dock = DockStyle.Fill;
            layoutControlMapping.Location = new Point(0, 0);
            layoutControlMapping.Name = "layoutControlMapping";
            layoutControlMapping.OptionsView.RightToLeftMirroringApplied = true;
            layoutControlMapping.Root = layoutControlGroupMapping;
            layoutControlMapping.Size = new Size(764, 419);
            layoutControlMapping.TabIndex = 0;
            // 
            // cboItem
            // 
            cboItem.Location = new Point(12, 39);
            cboItem.Name = "cboItem";
            cboItem.Size = new Size(628, 20);
            cboItem.StyleController = layoutControlMapping;
            cboItem.TabIndex = 0;
            cboItem.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboDescription
            // 
            cboDescription.Location = new Point(12, 66);
            cboDescription.Name = "cboDescription";
            cboDescription.Size = new Size(628, 20);
            cboDescription.StyleController = layoutControlMapping;
            cboDescription.TabIndex = 1;
            cboDescription.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboLocation
            // 
            cboLocation.Location = new Point(12, 255);
            cboLocation.Name = "cboLocation";
            cboLocation.Size = new Size(628, 20);
            cboLocation.StyleController = layoutControlMapping;
            cboLocation.TabIndex = 2;
            cboLocation.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboCategory
            // 
            cboCategory.Location = new Point(12, 282);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(628, 20);
            cboCategory.StyleController = layoutControlMapping;
            cboCategory.TabIndex = 3;
            cboCategory.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboStartDate
            // 
            cboStartDate.Location = new Point(12, 147);
            cboStartDate.Name = "cboStartDate";
            cboStartDate.Size = new Size(628, 20);
            cboStartDate.StyleController = layoutControlMapping;
            cboStartDate.TabIndex = 4;
            cboStartDate.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboEndDate
            // 
            cboEndDate.Location = new Point(12, 174);
            cboEndDate.Name = "cboEndDate";
            cboEndDate.Size = new Size(628, 20);
            cboEndDate.StyleController = layoutControlMapping;
            cboEndDate.TabIndex = 5;
            cboEndDate.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboActualStartDate
            // 
            cboActualStartDate.Location = new Point(12, 201);
            cboActualStartDate.Name = "cboActualStartDate";
            cboActualStartDate.Size = new Size(628, 20);
            cboActualStartDate.StyleController = layoutControlMapping;
            cboActualStartDate.TabIndex = 6;
            cboActualStartDate.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboActualEndDate
            // 
            cboActualEndDate.Location = new Point(12, 228);
            cboActualEndDate.Name = "cboActualEndDate";
            cboActualEndDate.Size = new Size(628, 20);
            cboActualEndDate.StyleController = layoutControlMapping;
            cboActualEndDate.TabIndex = 7;
            cboActualEndDate.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboWBSId
            // 
            cboWBSId.Location = new Point(12, 93);
            cboWBSId.Name = "cboWBSId";
            cboWBSId.Size = new Size(628, 20);
            cboWBSId.StyleController = layoutControlMapping;
            cboWBSId.TabIndex = 8;
            cboWBSId.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboWBSName
            // 
            cboWBSName.Location = new Point(12, 120);
            cboWBSName.Name = "cboWBSName";
            cboWBSName.Size = new Size(628, 20);
            cboWBSName.StyleController = layoutControlMapping;
            cboWBSName.TabIndex = 9;
            cboWBSName.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // cboActivityId
            // 
            cboActivityId.Location = new Point(12, 12);
            cboActivityId.Name = "cboActivityId";
            cboActivityId.Size = new Size(628, 20);
            cboActivityId.StyleController = layoutControlMapping;
            cboActivityId.TabIndex = 10;
            cboActivityId.EditValueChanged += CboMapping_EditValueChanged;
            // 
            // layoutControlGroupMapping
            // 
            layoutControlGroupMapping.AppearanceItemCaption.Font = new Font("Cairo", 9F);
            layoutControlGroupMapping.AppearanceItemCaption.Options.UseFont = true;
            layoutControlGroupMapping.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroupMapping.GroupBordersVisible = false;
            layoutControlGroupMapping.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciActivityCode, lciCategory, lciLocation, lciActivityId, lciActivityName, lciWBSId, lciWBSName, lciStartDate, lciEndDate, lciActualStartDate, lciActualEndDate });
            layoutControlGroupMapping.Name = "layoutControlGroupMapping";
            layoutControlGroupMapping.Size = new Size(764, 419);
            // 
            // lciActivityName
            // 
            lciActivityName.Control = cboItem;
            lciActivityName.Location = new Point(0, 27);
            lciActivityName.Name = "lciActivityName";
            lciActivityName.Size = new Size(744, 27);
            lciActivityName.Text = "اسم النشاط";
            lciActivityName.TextSize = new Size(100, 23);
            // 
            // lciActivityCode
            // 
            lciActivityCode.Control = cboDescription;
            lciActivityCode.Location = new Point(0, 54);
            lciActivityCode.Name = "lciActivityCode";
            lciActivityCode.Size = new Size(744, 27);
            lciActivityCode.Text = "رمز النشاط";
            lciActivityCode.TextSize = new Size(100, 23);
            // 
            // lciLocation
            // 
            lciLocation.Control = cboLocation;
            lciLocation.Location = new Point(0, 243);
            lciLocation.Name = "lciLocation";
            lciLocation.Size = new Size(744, 27);
            lciLocation.Text = "الموقع";
            lciLocation.TextSize = new Size(100, 23);
            // 
            // lciCategory
            // 
            lciCategory.Control = cboCategory;
            lciCategory.Location = new Point(0, 270);
            lciCategory.Name = "lciCategory";
            lciCategory.Size = new Size(744, 129);
            lciCategory.Text = "التصنيف";
            lciCategory.TextSize = new Size(100, 23);
            // 
            // lciStartDate
            // 
            lciStartDate.Control = cboStartDate;
            lciStartDate.Location = new Point(0, 135);
            lciStartDate.Name = "lciStartDate";
            lciStartDate.Size = new Size(744, 27);
            lciStartDate.Text = "تاريخ البداية المخطط";
            lciStartDate.TextSize = new Size(100, 23);
            // 
            // lciEndDate
            // 
            lciEndDate.Control = cboEndDate;
            lciEndDate.Location = new Point(0, 162);
            lciEndDate.Name = "lciEndDate";
            lciEndDate.Size = new Size(744, 27);
            lciEndDate.Text = "تاريخ النهاية المخطط";
            lciEndDate.TextSize = new Size(100, 23);
            // 
            // lciActualStartDate
            // 
            lciActualStartDate.Control = cboActualStartDate;
            lciActualStartDate.Location = new Point(0, 189);
            lciActualStartDate.Name = "lciActualStartDate";
            lciActualStartDate.Size = new Size(744, 27);
            lciActualStartDate.Text = "تاريخ البداية الفعلي";
            lciActualStartDate.TextSize = new Size(100, 23);
            // 
            // lciActualEndDate
            // 
            lciActualEndDate.Control = cboActualEndDate;
            lciActualEndDate.Location = new Point(0, 216);
            lciActualEndDate.Name = "lciActualEndDate";
            lciActualEndDate.Size = new Size(744, 27);
            lciActualEndDate.Text = "تاريخ النهاية الفعلي";
            lciActualEndDate.TextSize = new Size(100, 23);
            // 
            // lciWBSId
            // 
            lciWBSId.Control = cboWBSId;
            lciWBSId.Location = new Point(0, 81);
            lciWBSId.Name = "lciWBSId";
            lciWBSId.Size = new Size(744, 27);
            lciWBSId.Text = "رقم هيكل التجزئة";
            lciWBSId.TextSize = new Size(100, 23);
            // 
            // lciWBSName
            // 
            lciWBSName.Control = cboWBSName;
            lciWBSName.Location = new Point(0, 108);
            lciWBSName.Name = "lciWBSName";
            lciWBSName.Size = new Size(744, 27);
            lciWBSName.Text = "اسم هيكل التجزئة";
            lciWBSName.TextSize = new Size(100, 23);
            // 
            // lciActivityId
            // 
            lciActivityId.Control = cboActivityId;
            lciActivityId.Location = new Point(0, 0);
            lciActivityId.Name = "lciActivityId";
            lciActivityId.Size = new Size(744, 27);
            lciActivityId.Text = "رقم النشاط";
            lciActivityId.TextSize = new Size(100, 23);
            // 
            // tpPreview
            // 
            tpPreview.Controls.Add(treeListPreview);
            tpPreview.Name = "tpPreview";
            tpPreview.Size = new Size(764, 419);
            tpPreview.Text = "معاينة البيانات الهرمية";
            // 
            // treeListPreview
            // 
            treeListPreview.Appearance.HeaderPanel.Font = new Font("Cairo", 9F, FontStyle.Bold);
            treeListPreview.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            treeListPreview.Appearance.HeaderPanel.Options.UseFont = true;
            treeListPreview.Appearance.HeaderPanel.Options.UseForeColor = true;
            treeListPreview.Appearance.HeaderPanel.Options.UseTextOptions = true;
            treeListPreview.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            treeListPreview.Appearance.Row.Font = new Font("Cairo", 9F);
            treeListPreview.Appearance.Row.Options.UseFont = true;
            treeListPreview.CustomizationFormBounds = new Rectangle(567, 339, 259, 387);
            treeListPreview.Dock = DockStyle.Fill;
            treeListPreview.Location = new Point(0, 0);
            treeListPreview.Name = "treeListPreview";
            treeListPreview.OptionsBehavior.Editable = false;
            treeListPreview.OptionsView.ShowAutoFilterRow = true;
            treeListPreview.OptionsView.ShowIndicator = false;
            treeListPreview.Size = new Size(764, 419);
            treeListPreview.TabIndex = 0;
            // 
            // Root
            // 
            Root.Name = "Root";
            Root.Size = new Size(802, 578);
            // 
            // lciProject
            // 
            lciProject.Control = lueProject;
            lciProject.Location = new Point(0, 0);
            lciProject.Name = "lciProject";
            lciProject.Size = new Size(770, 32);
            lciProject.Text = "المشروع";
            lciProject.TextSize = new Size(60, 23);
            // 
            // lciSchedule
            // 
            lciSchedule.Control = txtNewScheduleName;
            lciSchedule.Location = new Point(0, 32);
            lciSchedule.Name = "lciSchedule";
            lciSchedule.Size = new Size(770, 32);
            lciSchedule.Text = "اسم الجدول";
            lciSchedule.TextSize = new Size(60, 23);
            // 
            // lciFilePath
            // 
            lciFilePath.Control = txtFilePath;
            lciFilePath.Location = new Point(0, 64);
            lciFilePath.Name = "lciFilePath";
            lciFilePath.Size = new Size(770, 32);
            lciFilePath.Text = "مسار الملف";
            lciFilePath.TextSize = new Size(60, 23);
            // 
            // lciTabs
            // 
            lciTabs.Control = xtraTabControl1;
            lciTabs.Location = new Point(0, 96);
            lciTabs.Name = "lciTabs";
            lciTabs.Size = new Size(770, 443);
            lciTabs.TextVisible = false;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(layoutControl1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 24);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(5);
            panelMain.Size = new Size(802, 578);
            panelMain.TabIndex = 5;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 264);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(740, 121);
            // 
            // frmImportSchedule
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 602);
            Controls.Add(panelMain);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new Font("Cairo", 8.5F);
            Name = "frmImportSchedule";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "استيراد الجدول الزمني";
            ((ISupportInitialize)barManager1).EndInit();
            ((ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((ISupportInitialize)lueProject.Properties).EndInit();
            ((ISupportInitialize)txtNewScheduleName.Properties).EndInit();
            ((ISupportInitialize)txtFilePath.Properties).EndInit();
            ((ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);
            tpMapping.ResumeLayout(false);
            ((ISupportInitialize)layoutControlMapping).EndInit();
            layoutControlMapping.ResumeLayout(false);
            ((ISupportInitialize)cboItem.Properties).EndInit();
            ((ISupportInitialize)cboDescription.Properties).EndInit();
            ((ISupportInitialize)cboLocation.Properties).EndInit();
            ((ISupportInitialize)cboCategory.Properties).EndInit();
            ((ISupportInitialize)cboStartDate.Properties).EndInit();
            ((ISupportInitialize)cboEndDate.Properties).EndInit();
            ((ISupportInitialize)cboActualStartDate.Properties).EndInit();
            ((ISupportInitialize)cboActualEndDate.Properties).EndInit();
            ((ISupportInitialize)cboWBSId.Properties).EndInit();
            ((ISupportInitialize)cboWBSName.Properties).EndInit();
            ((ISupportInitialize)cboActivityId.Properties).EndInit();
            ((ISupportInitialize)layoutControlGroupMapping).EndInit();
            ((ISupportInitialize)lciActivityName).EndInit();
            ((ISupportInitialize)lciActivityCode).EndInit();
            ((ISupportInitialize)lciLocation).EndInit();
            ((ISupportInitialize)lciCategory).EndInit();
            ((ISupportInitialize)lciStartDate).EndInit();
            ((ISupportInitialize)lciEndDate).EndInit();
            ((ISupportInitialize)lciActualStartDate).EndInit();
            ((ISupportInitialize)lciActualEndDate).EndInit();
            ((ISupportInitialize)lciWBSId).EndInit();
            ((ISupportInitialize)lciWBSName).EndInit();
            ((ISupportInitialize)lciActivityId).EndInit();
            tpPreview.ResumeLayout(false);
            ((ISupportInitialize)treeListPreview).EndInit();
            ((ISupportInitialize)Root).EndInit();
            ((ISupportInitialize)lciProject).EndInit();
            ((ISupportInitialize)lciSchedule).EndInit();
            ((ISupportInitialize)lciFilePath).EndInit();
            ((ISupportInitialize)lciTabs).EndInit();
            ((ISupportInitialize)panelMain).EndInit();
            panelMain.ResumeLayout(false);
            ((ISupportInitialize)emptySpaceItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiOpenFile;
        private DevExpress.XtraBars.BarButtonItem bbiImport;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit lueProject;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lciProject;
        private DevExpress.XtraEditors.TextEdit txtNewScheduleName;
        private DevExpress.XtraLayout.LayoutControlItem lciSchedule;
        private DevExpress.XtraEditors.ButtonEdit txtFilePath;
        private DevExpress.XtraLayout.LayoutControlItem lciFilePath;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tpMapping;
        private DevExpress.XtraTab.XtraTabPage tpPreview;
        private DevExpress.XtraLayout.LayoutControlItem lciTabs;
        private DevExpress.XtraLayout.LayoutControl layoutControlMapping;
        private DevExpress.XtraEditors.ComboBoxEdit cboItem;
        private DevExpress.XtraEditors.ComboBoxEdit cboDescription;
        private DevExpress.XtraEditors.ComboBoxEdit cboLocation;
        private DevExpress.XtraEditors.ComboBoxEdit cboCategory;
        private DevExpress.XtraEditors.ComboBoxEdit cboStartDate;
        private DevExpress.XtraEditors.ComboBoxEdit cboEndDate;
        private DevExpress.XtraEditors.ComboBoxEdit cboActualStartDate;
        private DevExpress.XtraEditors.ComboBoxEdit cboActualEndDate;
        private DevExpress.XtraEditors.ComboBoxEdit cboWBSId;
        private DevExpress.XtraEditors.ComboBoxEdit cboWBSName;
        private DevExpress.XtraEditors.ComboBoxEdit cboActivityId;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMapping;
        private DevExpress.XtraLayout.LayoutControlItem lciActivityName;
        private DevExpress.XtraLayout.LayoutControlItem lciActivityCode;
        private DevExpress.XtraLayout.LayoutControlItem lciLocation;
        private DevExpress.XtraLayout.LayoutControlItem lciCategory;
        private DevExpress.XtraLayout.LayoutControlItem lciStartDate;
        private DevExpress.XtraLayout.LayoutControlItem lciEndDate;
        private DevExpress.XtraLayout.LayoutControlItem lciActualStartDate;
        private DevExpress.XtraLayout.LayoutControlItem lciActualEndDate;
        private DevExpress.XtraLayout.LayoutControlItem lciWBSId;
        private DevExpress.XtraLayout.LayoutControlItem lciWBSName;
        private DevExpress.XtraLayout.LayoutControlItem lciActivityId;
        private DevExpress.XtraTreeList.TreeList treeListPreview;
        private DevExpress.XtraEditors.RoundedSkinPanel panelMain;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
