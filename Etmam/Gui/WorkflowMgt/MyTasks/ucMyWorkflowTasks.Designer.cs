namespace Etmam
{
    partial class ucMyWorkflowTasks
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMyWorkflowTasks));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            btnApprove = new DevExpress.XtraBars.BarButtonItem();
            btnReject = new DevExpress.XtraBars.BarButtonItem();
            btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colProcedureName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStepName = new DevExpress.XtraGrid.Columns.GridColumn();
            colReference = new DevExpress.XtraGrid.Columns.GridColumn();
            colStartedByName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStartedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colOpen = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemButtonEditOpen = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colInstanceId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditOpen).BeginInit();
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
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { btnApprove, btnReject, btnRefresh, barEditItem1 });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 6;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemSearchControl1 });
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            // 
            // bar2
            // 
            bar2.BarAppearance.Disabled.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Disabled.Options.UseFont = true;
            bar2.BarAppearance.Hovered.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Hovered.Options.UseFont = true;
            bar2.BarAppearance.Normal.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Normal.Options.UseFont = true;
            bar2.BarAppearance.Pressed.Font = new Font("Segoe UI", 9F);
            bar2.BarAppearance.Pressed.Options.UseFont = true;
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, btnApprove, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, btnReject, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(barEditItem1) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MinHeight = 35;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // btnApprove
            // 
            btnApprove.Caption = "إعتماد";
            btnApprove.Id = 2;
            btnApprove.ImageOptions.ImageIndex = 0;
            btnApprove.Name = "btnApprove";
            // 
            // btnReject
            // 
            btnReject.Caption = "رفض";
            btnReject.Id = 3;
            btnReject.ImageOptions.ImageIndex = 1;
            btnReject.Name = "btnReject";
            // 
            // btnRefresh
            // 
            btnRefresh.Caption = "تحديث";
            btnRefresh.Id = 4;
            btnRefresh.ImageOptions.ImageIndex = 2;
            btnRefresh.Name = "btnRefresh";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "barEditItem1";
            barEditItem1.Edit = repositoryItemSearchControl1;
            barEditItem1.EditHeight = 20;
            barEditItem1.EditWidth = 200;
            barEditItem1.Id = 5;
            barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemSearchControl1
            // 
            repositoryItemSearchControl1.AutoHeight = false;
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            repositoryItemSearchControl1.NullValuePrompt = " ";
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
            barDockControlTop.Size = new Size(1286, 35);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 634);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(1286, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 35);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 599);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1286, 35);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 599);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("task_1", "image://svgimages/outlook inspired/task.svg");
            svgImageCollection1.Add("actions_delete", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("actions_refresh", "image://svgimages/icon builder/actions_refresh.svg");
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 35);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemButtonEditOpen });
            gridControl1.Size = new Size(1286, 599);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.Row.Font = new Font("Cairo", 9F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colProcedureName, colStepName, colReference, colStartedByName, colStartedDate, colOpen, colInstanceId });
            gridView1.DetailHeight = 349;
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colProcedureName
            // 
            colProcedureName.Caption = "الإجراء";
            colProcedureName.FieldName = "ProcedureName";
            colProcedureName.Name = "colProcedureName";
            colProcedureName.OptionsColumn.AllowEdit = false;
            colProcedureName.OptionsColumn.AllowFocus = false;
            colProcedureName.Visible = true;
            colProcedureName.VisibleIndex = 1;
            colProcedureName.Width = 200;
            // 
            // colStepName
            // 
            colStepName.Caption = "الخطوة الحالية";
            colStepName.FieldName = "StepName";
            colStepName.Name = "colStepName";
            colStepName.OptionsColumn.AllowEdit = false;
            colStepName.OptionsColumn.AllowFocus = false;
            colStepName.Visible = true;
            colStepName.VisibleIndex = 2;
            colStepName.Width = 200;
            // 
            // colReference
            // 
            colReference.Caption = "المرجع";
            colReference.FieldName = "Reference";
            colReference.Name = "colReference";
            colReference.OptionsColumn.AllowEdit = false;
            colReference.OptionsColumn.AllowFocus = false;
            colReference.Visible = true;
            colReference.VisibleIndex = 3;
            colReference.Width = 200;
            // 
            // colStartedByName
            // 
            colStartedByName.Caption = "بدأه";
            colStartedByName.FieldName = "StartedByName";
            colStartedByName.Name = "colStartedByName";
            colStartedByName.OptionsColumn.AllowEdit = false;
            colStartedByName.OptionsColumn.AllowFocus = false;
            colStartedByName.Visible = true;
            colStartedByName.VisibleIndex = 4;
            colStartedByName.Width = 200;
            // 
            // colStartedDate
            // 
            colStartedDate.Caption = "تاريخ البدء";
            colStartedDate.FieldName = "StartedDate";
            colStartedDate.Name = "colStartedDate";
            colStartedDate.OptionsColumn.AllowEdit = false;
            colStartedDate.OptionsColumn.AllowFocus = false;
            colStartedDate.Visible = true;
            colStartedDate.VisibleIndex = 5;
            colStartedDate.Width = 200;
            // 
            // colOpen
            // 
            colOpen.Caption = " ";
            colOpen.ColumnEdit = repositoryItemButtonEditOpen;
            colOpen.Name = "colOpen";
            colOpen.Visible = true;
            colOpen.VisibleIndex = 0;
            // 
            // repositoryItemButtonEditOpen
            // 
            repositoryItemButtonEditOpen.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("editorButtonImageOptions1.SvgImage");
            editorButtonImageOptions1.SvgImageSize = new Size(16, 16);
            repositoryItemButtonEditOpen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
            repositoryItemButtonEditOpen.Name = "repositoryItemButtonEditOpen";
            repositoryItemButtonEditOpen.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // colInstanceId
            // 
            colInstanceId.Caption = "InstanceId";
            colInstanceId.FieldName = "InstanceId";
            colInstanceId.Name = "colInstanceId";
            // 
            // ucMyWorkflowTasks
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucMyWorkflowTasks";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1286, 652);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditOpen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnApprove;
        private DevExpress.XtraBars.BarButtonItem btnReject;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colProcedureName;
        private DevExpress.XtraGrid.Columns.GridColumn colStepName;
        private DevExpress.XtraGrid.Columns.GridColumn colReference;
        private DevExpress.XtraGrid.Columns.GridColumn colStartedByName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOpen;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditOpen;
        private DevExpress.XtraGrid.Columns.GridColumn colInstanceId;
    }
}
