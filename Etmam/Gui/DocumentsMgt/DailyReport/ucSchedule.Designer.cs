namespace Etmam
{
    partial class ucSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSchedule));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiSelect = new DevExpress.XtraBars.BarButtonItem();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bar2 = new DevExpress.XtraBars.Bar();
            bar3 = new DevExpress.XtraBars.Bar();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            colIdCategory = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colActivityId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colActivityCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colActivityName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colDuration = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colStartDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colEndDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colActuaStart = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colActualEnd = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colScheduleId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPrjId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            scheduleDetailsBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scheduleDetailsBindingSource).BeginInit();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiDelete, bbiEdit, barStaticItem1, bbiSelect });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 26;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 1;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbiSelect), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(bbiEdit), new DevExpress.XtraBars.LinkPersistInfo(bbiDelete) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiSelect
            // 
            bbiSelect.Caption = "اختيار";
            bbiSelect.Id = 25;
            bbiSelect.ImageOptions.ImageIndex = 2;
            bbiSelect.Name = "bbiSelect";
            bbiSelect.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiSelect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiAdd
            // 
            bbiAdd.Caption = "إضافة";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.ImageIndex = 0;
            bbiAdd.Name = "bbiAdd";
            bbiAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 23;
            bbiEdit.ImageOptions.ImageIndex = 7;
            bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 3;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.Name = "bbiDelete";
            bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
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
            bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barStaticItem1) });
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            barStaticItem1.Caption = "عدد السجلات : 0";
            barStaticItem1.Id = 24;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1086, 48);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 750);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1086, 22);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 48);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 702);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1086, 48);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 702);
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "1_New.png");
            imageCollection1.Images.SetKeyName(1, "2_ReIssue.png");
            imageCollection1.Images.SetKeyName(2, "3_Save.png");
            imageCollection1.Images.SetKeyName(3, "4_Delete.png");
            imageCollection1.Images.SetKeyName(4, "5_Print.png");
            imageCollection1.Images.SetKeyName(5, "6_Search.png");
            imageCollection1.Images.SetKeyName(6, "refresh.png");
            imageCollection1.InsertImage(Properties.Resources.edit_16x16, "edit_16x16", typeof(Properties.Resources), 7);
            imageCollection1.Images.SetKeyName(7, "edit_16x16");
            imageCollection1.Images.SetKeyName(8, "6_Search.png");
            imageCollection1.InsertImage(Properties.Resources.sortbyinvoice_16x16, "sortbyinvoice_16x16", typeof(Properties.Resources), 9);
            imageCollection1.Images.SetKeyName(9, "sortbyinvoice_16x16");
            // 
            // treeList1
            // 
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colIdCategory, colActivityId, colActivityCode, colActivityName, colDuration, colStartDate, colEndDate, colActuaStart, colActualEnd, colScheduleId, colPrjId });
            treeList1.DataSource = scheduleDetailsBindingSource;
            treeList1.Dock = DockStyle.Fill;
            treeList1.KeyFieldName = "Id";
            treeList1.Location = new Point(0, 48);
            treeList1.MenuManager = barManager1;
            treeList1.Name = "treeList1";
            treeList1.ParentFieldName = "IdParent";
            treeList1.Size = new Size(1086, 702);
            treeList1.TabIndex = 4;
            // 
            // colIdCategory
            // 
            colIdCategory.Caption = "colIdCategory";
            colIdCategory.FieldName = "IdCategory";
            colIdCategory.Name = "colIdCategory";
            // 
            // colActivityId
            // 
            colActivityId.Caption = "colActivityId";
            colActivityId.FieldName = "ActivityId";
            colActivityId.Name = "colActivityId";
            // 
            // colActivityCode
            // 
            colActivityCode.Caption = "colActivityCode";
            colActivityCode.FieldName = "ActivityCode";
            colActivityCode.Name = "colActivityCode";
            colActivityCode.Visible = true;
            colActivityCode.VisibleIndex = 0;
            // 
            // colActivityName
            // 
            colActivityName.Caption = "colActivityName";
            colActivityName.FieldName = "ActivityName";
            colActivityName.Name = "colActivityName";
            colActivityName.Visible = true;
            colActivityName.VisibleIndex = 1;
            // 
            // colDuration
            // 
            colDuration.Caption = "colDuration";
            colDuration.FieldName = "Duration";
            colDuration.Name = "colDuration";
            colDuration.Visible = true;
            colDuration.VisibleIndex = 2;
            // 
            // colStartDate
            // 
            colStartDate.Caption = "colStartDate";
            colStartDate.FieldName = "StartDate";
            colStartDate.Name = "colStartDate";
            colStartDate.Visible = true;
            colStartDate.VisibleIndex = 3;
            // 
            // colEndDate
            // 
            colEndDate.Caption = "colEndDate";
            colEndDate.FieldName = "EndDate";
            colEndDate.Name = "colEndDate";
            colEndDate.Visible = true;
            colEndDate.VisibleIndex = 4;
            // 
            // colActuaStart
            // 
            colActuaStart.Caption = "colActuaStart";
            colActuaStart.FieldName = "ActuaStart";
            colActuaStart.Name = "colActuaStart";
            // 
            // colActualEnd
            // 
            colActualEnd.Caption = "colActualEnd";
            colActualEnd.FieldName = "ActualEnd";
            colActualEnd.Name = "colActualEnd";
            // 
            // colScheduleId
            // 
            colScheduleId.Caption = "colScheduleId";
            colScheduleId.FieldName = "ScheduleId";
            colScheduleId.Name = "colScheduleId";
            // 
            // colPrjId
            // 
            colPrjId.Caption = "colPrjId";
            colPrjId.FieldName = "PrjId";
            colPrjId.Name = "colPrjId";
            // 
            // scheduleDetailsBindingSource
            // 
            scheduleDetailsBindingSource.DataSource = typeof(Core.ScheduleDetails);
            // 
            // ucSchedule
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(treeList1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucSchedule";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1086, 772);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)scheduleDetailsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiSelect;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private BindingSource scheduleDetailsBindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIdCategory;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colActivityId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colActivityCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colActivityName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDuration;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStartDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEndDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colActuaStart;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colActualEnd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colScheduleId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPrjId;
    }
}
