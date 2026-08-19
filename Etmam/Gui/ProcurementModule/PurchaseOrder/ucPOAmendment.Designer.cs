namespace Etmam
{
    partial class ucPOAmendment
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
            poAmendmentListBindingSource = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemButtonEditAction = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colPOId = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmendmentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colPreviousValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmendmentValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colRevisedValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colReason = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatusDisplay = new DevExpress.XtraGrid.Columns.GridColumn();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)poAmendmentListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditAction).BeginInit();
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
            gridControl1.DataSource = poAmendmentListBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 35);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemButtonEditAction });
            gridControl1.Size = new Size(1398, 625);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // poAmendmentListBindingSource
            // 
            poAmendmentListBindingSource.DataSource = typeof(Core.POAmendmentList);
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new Font("Cairo", 8F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colAction, colNum, colPOId, colAmendmentDate, colPreviousValue, colAmendmentValue, colRevisedValue, colReason, colStatusDisplay, colId });
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
            colNum.AppearanceCell.Options.UseTextOptions = true;
            colNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colNum.Caption = "رقم التعديل";
            colNum.FieldName = "Num";
            colNum.Name = "colNum";
            colNum.Visible = true;
            colNum.VisibleIndex = 1;
            colNum.Width = 90;
            // 
            // colPOId
            // 
            colPOId.AppearanceCell.Options.UseTextOptions = true;
            colPOId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPOId.Caption = "أمر الشراء";
            colPOId.FieldName = "POId";
            colPOId.Name = "colPOId";
            colPOId.Visible = true;
            colPOId.VisibleIndex = 2;
            colPOId.Width = 130;
            // 
            // colAmendmentDate
            // 
            colAmendmentDate.AppearanceCell.Options.UseTextOptions = true;
            colAmendmentDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colAmendmentDate.Caption = "تاريخ التعديل";
            colAmendmentDate.DisplayFormat.FormatString = "d";
            colAmendmentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colAmendmentDate.FieldName = "AmendmentDate";
            colAmendmentDate.Name = "colAmendmentDate";
            colAmendmentDate.Visible = true;
            colAmendmentDate.VisibleIndex = 3;
            colAmendmentDate.Width = 100;
            // 
            // colPreviousValue
            // 
            colPreviousValue.AppearanceCell.Options.UseTextOptions = true;
            colPreviousValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colPreviousValue.Caption = "القيمة قبل التعديل";
            colPreviousValue.DisplayFormat.FormatString = "N2";
            colPreviousValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPreviousValue.FieldName = "PreviousValue";
            colPreviousValue.Name = "colPreviousValue";
            colPreviousValue.Visible = true;
            colPreviousValue.VisibleIndex = 4;
            colPreviousValue.Width = 110;
            // 
            // colAmendmentValue
            // 
            colAmendmentValue.AppearanceCell.Options.UseTextOptions = true;
            colAmendmentValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colAmendmentValue.Caption = "قيمة التعديل";
            colAmendmentValue.DisplayFormat.FormatString = "N2";
            colAmendmentValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmendmentValue.FieldName = "AmendmentValue";
            colAmendmentValue.Name = "colAmendmentValue";
            colAmendmentValue.Visible = true;
            colAmendmentValue.VisibleIndex = 5;
            colAmendmentValue.Width = 100;
            // 
            // colRevisedValue
            // 
            colRevisedValue.AppearanceCell.Options.UseTextOptions = true;
            colRevisedValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colRevisedValue.Caption = "القيمة بعد التعديل";
            colRevisedValue.DisplayFormat.FormatString = "N2";
            colRevisedValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colRevisedValue.FieldName = "RevisedValue";
            colRevisedValue.Name = "colRevisedValue";
            colRevisedValue.Visible = true;
            colRevisedValue.VisibleIndex = 6;
            colRevisedValue.Width = 110;
            // 
            // colReason
            // 
            colReason.Caption = "سبب التعديل";
            colReason.FieldName = "Reason";
            colReason.Name = "colReason";
            colReason.Visible = true;
            colReason.VisibleIndex = 7;
            colReason.Width = 220;
            // 
            // colStatusDisplay
            // 
            colStatusDisplay.Caption = "الحالة";
            colStatusDisplay.FieldName = "StatusDisplay";
            colStatusDisplay.Name = "colStatusDisplay";
            colStatusDisplay.Visible = true;
            colStatusDisplay.VisibleIndex = 8;
            colStatusDisplay.Width = 110;
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // ucPOAmendment
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucPOAmendment";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1398, 678);
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)poAmendmentListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditAction).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditAction;
        private BindingSource poAmendmentListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNum;
        private DevExpress.XtraGrid.Columns.GridColumn colPOId;
        private DevExpress.XtraGrid.Columns.GridColumn colAmendmentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviousValue;
        private DevExpress.XtraGrid.Columns.GridColumn colAmendmentValue;
        private DevExpress.XtraGrid.Columns.GridColumn colRevisedValue;
        private DevExpress.XtraGrid.Columns.GridColumn colReason;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusDisplay;
    }
}
