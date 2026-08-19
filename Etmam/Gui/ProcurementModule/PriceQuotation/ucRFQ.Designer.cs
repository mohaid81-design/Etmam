namespace Etmam
{
    partial class ucRFQ
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            bbiOpen = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            rfqListBindingSource = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemButtonEditAction = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrjId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPRId = new DevExpress.XtraGrid.Columns.GridColumn();
            colIssueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colRequiredDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colPurpose = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            colRequestType = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatusDisplay = new DevExpress.XtraGrid.Columns.GridColumn();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemLookUpEditProject = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rfqListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditAction).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEditProject).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("new", "image://svgimages/actions/new.svg");
            svgImageCollection1.Add("open", "image://svgimages/actions/open.svg");
            svgImageCollection1.Add("actions_edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("actions_delete", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("actions_refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("bo_validation", "image://svgimages/business objects/bo_validation.svg");
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiOpen, bbiEdit, bbiDelete, bbiRefresh });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 5;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiOpen, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
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
            bbiNew.Name = "bbiNew";
            // 
            // bbiOpen
            // 
            bbiOpen.Caption = "فتح";
            bbiOpen.Id = 1;
            bbiOpen.Name = "bbiOpen";
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 2;
            bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 3;
            bbiDelete.Name = "bbiDelete";
            // 
            // bbiRefresh
            // 
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 4;
            bbiRefresh.Name = "bbiRefresh";
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
            barDockControlTop.Size = new Size(1398, 35);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 660);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1398, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 35);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 625);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1398, 35);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 625);
            // 
            // gridControl1
            // 
            gridControl1.DataSource = rfqListBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 35);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemLookUpEditProject, repositoryItemButtonEditAction });
            gridControl1.Size = new Size(1398, 625);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // rfqListBindingSource
            // 
            rfqListBindingSource.DataSource = typeof(Core.RFQList);
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new Font("Cairo", 8.5F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colAction, colNum, colPrjId, colPRId, colIssueDate, colRequiredDate, colPurpose, colPriority, colRequestType, colStatusDisplay, colId });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colAction
            // 
            colAction.Caption = " ";
            colAction.ColumnEdit = repositoryItemButtonEditAction;
            colAction.Name = "colAction";
            colAction.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colAction.OptionsColumn.FixedWidth = true;
            colAction.OptionsColumn.ShowCaption = false;
            colAction.OptionsFilter.AllowAutoFilter = false;
            colAction.OptionsFilter.AllowFilter = false;
            colAction.Visible = true;
            colAction.VisibleIndex = 0;
            colAction.Width = 40;
            // 
            // repositoryItemButtonEditAction
            // 
            repositoryItemButtonEditAction.AutoHeight = false;
            editorButtonImageOptions1.ImageIndex = 5;
            editorButtonImageOptions1.ImageList = svgImageCollection1;
            editorButtonImageOptions1.SvgImageSize = new Size(16, 16);
            repositoryItemButtonEditAction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
            repositoryItemButtonEditAction.Name = "repositoryItemButtonEditAction";
            repositoryItemButtonEditAction.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // colNum
            // 
            colNum.Caption = "رقم RFQ";
            colNum.FieldName = "Num";
            colNum.Name = "colNum";
            colNum.Visible = true;
            colNum.VisibleIndex = 1;
            colNum.Width = 90;
            // 
            // colPrjId
            // 
            colPrjId.Caption = "المشروع";
            colPrjId.FieldName = "PrjId";
            colPrjId.Name = "colPrjId";
            colPrjId.Visible = true;
            colPrjId.VisibleIndex = 2;
            colPrjId.Width = 200;
            // 
            // colPRId
            // 
            colPRId.Caption = "طلب الشراء المصدر";
            colPRId.FieldName = "PRId";
            colPRId.Name = "colPRId";
            colPRId.Visible = true;
            colPRId.VisibleIndex = 3;
            colPRId.Width = 129;
            // 
            // colIssueDate
            // 
            colIssueDate.Caption = "تاريخ الإصدار";
            colIssueDate.DisplayFormat.FormatString = "d";
            colIssueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colIssueDate.FieldName = "IssueDate";
            colIssueDate.Name = "colIssueDate";
            colIssueDate.Visible = true;
            colIssueDate.VisibleIndex = 4;
            colIssueDate.Width = 100;
            // 
            // colRequiredDate
            // 
            colRequiredDate.Caption = "آخر موعد لتقديم العروض";
            colRequiredDate.DisplayFormat.FormatString = "d";
            colRequiredDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colRequiredDate.FieldName = "RequiredDate";
            colRequiredDate.Name = "colRequiredDate";
            colRequiredDate.Visible = true;
            colRequiredDate.VisibleIndex = 5;
            colRequiredDate.Width = 130;
            // 
            // colPurpose
            // 
            colPurpose.Caption = "الغرض";
            colPurpose.FieldName = "Purpose";
            colPurpose.Name = "colPurpose";
            colPurpose.Visible = true;
            colPurpose.VisibleIndex = 6;
            colPurpose.Width = 220;
            // 
            // colPriority
            // 
            colPriority.Caption = "درجة الأهمية";
            colPriority.FieldName = "Priority";
            colPriority.Name = "colPriority";
            colPriority.Visible = true;
            colPriority.VisibleIndex = 7;
            colPriority.Width = 90;
            // 
            // colRequestType
            // 
            colRequestType.Caption = "نوع الطلب";
            colRequestType.FieldName = "RequestType";
            colRequestType.Name = "colRequestType";
            colRequestType.Visible = true;
            colRequestType.VisibleIndex = 8;
            colRequestType.Width = 90;
            // 
            // colStatusDisplay
            // 
            colStatusDisplay.Caption = "الحالة";
            colStatusDisplay.FieldName = "StatusDisplay";
            colStatusDisplay.Name = "colStatusDisplay";
            colStatusDisplay.Visible = true;
            colStatusDisplay.VisibleIndex = 9;
            colStatusDisplay.Width = 130;
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // repositoryItemLookUpEditProject
            // 
            repositoryItemLookUpEditProject.AutoHeight = false;
            repositoryItemLookUpEditProject.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemLookUpEditProject.Name = "repositoryItemLookUpEditProject";
            // 
            // ucRFQ
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucRFQ";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1398, 678);
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)rfqListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditAction).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEditProject).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiOpen;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditProject;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditAction;
        private BindingSource rfqListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNum;
        private DevExpress.XtraGrid.Columns.GridColumn colPrjId;
        private DevExpress.XtraGrid.Columns.GridColumn colPRId;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiredDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPurpose;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestType;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusDisplay;
    }
}
