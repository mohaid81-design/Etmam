namespace Etmam
{
    partial class frmApprovalMatrixAddEdit
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
            components = new System.ComponentModel.Container();

            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            bbiFirst = new DevExpress.XtraBars.BarButtonItem();
            bbiPrev = new DevExpress.XtraBars.BarButtonItem();
            bbiNext = new DevExpress.XtraBars.BarButtonItem();
            bbiLast = new DevExpress.XtraBars.BarButtonItem();
            bbiSave = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();

            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();

            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            labelControlEntityName = new DevExpress.XtraEditors.LabelControl();
            comboBoxEditEntityName = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControlProject = new DevExpress.XtraEditors.LabelControl();
            lookUpEditProject = new DevExpress.XtraEditors.LookUpEdit();
            labelControlIsActive = new DevExpress.XtraEditors.LabelControl();
            checkEditIsActive = new DevExpress.XtraEditors.CheckEdit();
            labelControlDescription = new DevExpress.XtraEditors.LabelControl();
            memoEditDescription = new DevExpress.XtraEditors.MemoEdit();

            gridControl = new DevExpress.XtraGrid.GridControl();
            gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colMinAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colMaxAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colWorkflowDefinition = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemLookUpEditWorkflow = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colEffectiveFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            colEffectiveTo = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemCheckEditActive = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colDeleteItem = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemButtonEditDeleteItem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();

            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditEntityName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEditIsActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEditDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEditWorkflow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEditActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditDeleteItem).BeginInit();
            SuspendLayout();
            //
            // barManager1 / bar1 / toolbar buttons
            //
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiFirst, bbiPrev, bbiNext, bbiLast, bbiSave });
            barManager1.MainMenu = bar1;
            barManager1.MaxItemId = 6;

            bar1.BarName = "Main menu";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(bbiNew),
                new DevExpress.XtraBars.LinkPersistInfo(bbiFirst),
                new DevExpress.XtraBars.LinkPersistInfo(bbiPrev),
                new DevExpress.XtraBars.LinkPersistInfo(bbiNext),
                new DevExpress.XtraBars.LinkPersistInfo(bbiLast),
                new DevExpress.XtraBars.LinkPersistInfo(bbiSave) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.MinHeight = 35;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Main menu";

            bbiNew.Caption = "جديد";
            bbiNew.Id = 0;
            bbiNew.Name = "bbiNew";
            bbiNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiNew.ImageOptions.Image = Properties.Resources.add_16x161;

            bbiFirst.Caption = "الأول";
            bbiFirst.Id = 1;
            bbiFirst.Name = "bbiFirst";
            bbiFirst.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiFirst.ImageOptions.Image = Properties.Resources.last_16x162;

            bbiPrev.Caption = "السابق";
            bbiPrev.Id = 2;
            bbiPrev.Name = "bbiPrev";
            bbiPrev.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiPrev.ImageOptions.Image = Properties.Resources.next_16x162;

            bbiNext.Caption = "اللاحق";
            bbiNext.Id = 3;
            bbiNext.Name = "bbiNext";
            bbiNext.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiNext.ImageOptions.Image = Properties.Resources.prev_16x162;

            bbiLast.Caption = "الأخير";
            bbiLast.Id = 4;
            bbiLast.Name = "bbiLast";
            bbiLast.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiLast.ImageOptions.Image = Properties.Resources.first_16x162;

            bbiSave.Caption = "حفظ";
            bbiSave.Id = 5;
            bbiSave.Name = "bbiSave";
            bbiSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiSave.ImageOptions.Image = Properties.Resources.save_16x161;

            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(1288, 35);

            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 692);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(1288, 0);

            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 35);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 657);

            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1288, 35);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 657);
            //
            // splitContainerControl1
            //
            splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerControl1.Horizontal = false;
            splitContainerControl1.Location = new System.Drawing.Point(0, 35);
            splitContainerControl1.Name = "splitContainerControl1";
            splitContainerControl1.Panel1.Controls.Add(groupControl1);
            splitContainerControl1.Panel2.Controls.Add(gridControl);
            splitContainerControl1.Size = new System.Drawing.Size(1288, 657);
            splitContainerControl1.SplitterPosition = 220;
            //
            // groupControl1 ("بيانات مصفوفة الاعتماد")
            //
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.Controls.Add(tableLayoutPanel1);
            groupControl1.Name = "groupControl1";
            groupControl1.Text = "بيانات مصفوفة الاعتماد";
            //
            // tableLayoutPanel1
            //
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";

            labelControlEntityName.Text = "نوع المستند:";
            labelControlEntityName.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlEntityName.Name = "labelControlEntityName";
            comboBoxEditEntityName.Dock = System.Windows.Forms.DockStyle.Fill;
            comboBoxEditEntityName.Name = "comboBoxEditEntityName";
            comboBoxEditEntityName.Properties.AutoHeight = false;
            comboBoxEditEntityName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditEntityName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            labelControlProject.Text = "المشروع (اختياري):";
            labelControlProject.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlProject.Name = "labelControlProject";
            lookUpEditProject.Dock = System.Windows.Forms.DockStyle.Fill;
            lookUpEditProject.Name = "lookUpEditProject";
            lookUpEditProject.Properties.AutoHeight = false;
            lookUpEditProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEditProject.Properties.NullText = "";

            labelControlIsActive.Text = "نشطة؟";
            labelControlIsActive.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlIsActive.Name = "labelControlIsActive";
            checkEditIsActive.Dock = System.Windows.Forms.DockStyle.Fill;
            checkEditIsActive.Name = "checkEditIsActive";
            checkEditIsActive.Properties.Caption = "";

            labelControlDescription.Text = "وصف:";
            labelControlDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlDescription.Name = "labelControlDescription";
            memoEditDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            memoEditDescription.Name = "memoEditDescription";

            tableLayoutPanel1.Controls.Add(labelControlEntityName, 0, 0);
            tableLayoutPanel1.Controls.Add(comboBoxEditEntityName, 1, 0);
            tableLayoutPanel1.Controls.Add(labelControlProject, 2, 0);
            tableLayoutPanel1.Controls.Add(lookUpEditProject, 3, 0);
            tableLayoutPanel1.Controls.Add(labelControlIsActive, 0, 1);
            tableLayoutPanel1.Controls.Add(checkEditIsActive, 1, 1);
            tableLayoutPanel1.Controls.Add(labelControlDescription, 0, 2);
            tableLayoutPanel1.Controls.Add(memoEditDescription, 1, 2);
            tableLayoutPanel1.SetColumnSpan(memoEditDescription, 3);
            //
            // gridControl / gridView (Panel2 — amount bands)
            //
            gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl.Location = new System.Drawing.Point(0, 0);
            gridControl.MainView = gridView;
            gridControl.Name = "gridControl";
            gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                repositoryItemLookUpEditWorkflow, repositoryItemCheckEditActive, repositoryItemButtonEditDeleteItem });
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });

            gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colMinAmount, colMaxAmount, colWorkflowDefinition, colEffectiveFrom, colEffectiveTo, colIsActive, colDeleteItem });
            gridView.GridControl = gridControl;
            gridView.Name = "gridView";
            gridView.OptionsBehavior.Editable = true;
            gridView.OptionsView.ShowGroupPanel = false;

            colMinAmount.Caption = "من مبلغ";
            colMinAmount.FieldName = "MinAmount";
            colMinAmount.Name = "colMinAmount";
            colMinAmount.Visible = true;
            colMinAmount.VisibleIndex = 0;
            colMinAmount.Width = 100;
            colMinAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colMinAmount.DisplayFormat.FormatString = "N2";

            colMaxAmount.Caption = "إلى مبلغ (فارغ = بلا حد أقصى)";
            colMaxAmount.FieldName = "MaxAmount";
            colMaxAmount.Name = "colMaxAmount";
            colMaxAmount.Visible = true;
            colMaxAmount.VisibleIndex = 1;
            colMaxAmount.Width = 160;
            colMaxAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colMaxAmount.DisplayFormat.FormatString = "N2";

            colWorkflowDefinition.Caption = "إجراء الاعتماد";
            colWorkflowDefinition.ColumnEdit = repositoryItemLookUpEditWorkflow;
            colWorkflowDefinition.FieldName = "WorkflowDefinitionId";
            colWorkflowDefinition.Name = "colWorkflowDefinition";
            colWorkflowDefinition.Visible = true;
            colWorkflowDefinition.VisibleIndex = 2;
            colWorkflowDefinition.Width = 200;

            repositoryItemLookUpEditWorkflow.AutoHeight = false;
            repositoryItemLookUpEditWorkflow.Name = "repositoryItemLookUpEditWorkflow";
            repositoryItemLookUpEditWorkflow.NullText = "";

            colEffectiveFrom.Caption = "ساري من تاريخ";
            colEffectiveFrom.FieldName = "EffectiveFrom";
            colEffectiveFrom.Name = "colEffectiveFrom";
            colEffectiveFrom.Visible = true;
            colEffectiveFrom.VisibleIndex = 3;
            colEffectiveFrom.Width = 110;
            colEffectiveFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colEffectiveFrom.DisplayFormat.FormatString = "d";

            colEffectiveTo.Caption = "ساري حتى تاريخ";
            colEffectiveTo.FieldName = "EffectiveTo";
            colEffectiveTo.Name = "colEffectiveTo";
            colEffectiveTo.Visible = true;
            colEffectiveTo.VisibleIndex = 4;
            colEffectiveTo.Width = 110;
            colEffectiveTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colEffectiveTo.DisplayFormat.FormatString = "d";

            colIsActive.Caption = "نشط؟";
            colIsActive.ColumnEdit = repositoryItemCheckEditActive;
            colIsActive.FieldName = "IsActive";
            colIsActive.Name = "colIsActive";
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 5;
            colIsActive.Width = 60;

            repositoryItemCheckEditActive.AutoHeight = false;
            repositoryItemCheckEditActive.Name = "repositoryItemCheckEditActive";

            colDeleteItem.Caption = "";
            colDeleteItem.ColumnEdit = repositoryItemButtonEditDeleteItem;
            colDeleteItem.Name = "colDeleteItem";
            colDeleteItem.Visible = true;
            colDeleteItem.VisibleIndex = 6;
            colDeleteItem.Width = 40;
            colDeleteItem.OptionsColumn.AllowEdit = false;

            repositoryItemButtonEditDeleteItem.AutoHeight = false;
            repositoryItemButtonEditDeleteItem.Name = "repositoryItemButtonEditDeleteItem";
            repositoryItemButtonEditDeleteItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repositoryItemButtonEditDeleteItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) });
            //
            // frmApprovalMatrixAddEdit
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1288, 710);
            Controls.Add(splitContainerControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "frmApprovalMatrixAddEdit";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "إضافة / تعديل مصفوفة اعتماد";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;

            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)comboBoxEditEntityName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEditIsActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEditDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEditWorkflow).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEditActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditDeleteItem).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiFirst;
        private DevExpress.XtraBars.BarButtonItem bbiPrev;
        private DevExpress.XtraBars.BarButtonItem bbiNext;
        private DevExpress.XtraBars.BarButtonItem bbiLast;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControlEntityName;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditEntityName;
        private DevExpress.XtraEditors.LabelControl labelControlProject;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditProject;
        private DevExpress.XtraEditors.LabelControl labelControlIsActive;
        private DevExpress.XtraEditors.CheckEdit checkEditIsActive;
        private DevExpress.XtraEditors.LabelControl labelControlDescription;
        private DevExpress.XtraEditors.MemoEdit memoEditDescription;

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colMinAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkflowDefinition;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditWorkflow;
        private DevExpress.XtraGrid.Columns.GridColumn colEffectiveFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colEffectiveTo;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditActive;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleteItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditDeleteItem;
    }
}
