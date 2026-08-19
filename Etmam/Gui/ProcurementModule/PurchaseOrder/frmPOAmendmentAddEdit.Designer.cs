namespace Etmam
{
    partial class frmPOAmendmentAddEdit
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
            labelControlPO = new DevExpress.XtraEditors.LabelControl();
            lookUpEditPO = new DevExpress.XtraEditors.LookUpEdit();
            labelControlNum = new DevExpress.XtraEditors.LabelControl();
            textEditNum = new DevExpress.XtraEditors.TextEdit();
            labelControlAmendmentDate = new DevExpress.XtraEditors.LabelControl();
            dateEditAmendmentDate = new DevExpress.XtraEditors.DateEdit();
            labelControlStatus = new DevExpress.XtraEditors.LabelControl();
            comboBoxEditStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControlPreviousValue = new DevExpress.XtraEditors.LabelControl();
            textEditPreviousValue = new DevExpress.XtraEditors.TextEdit();
            labelControlAmendmentValue = new DevExpress.XtraEditors.LabelControl();
            textEditAmendmentValue = new DevExpress.XtraEditors.TextEdit();
            labelControlRevisedValue = new DevExpress.XtraEditors.LabelControl();
            textEditRevisedValue = new DevExpress.XtraEditors.TextEdit();
            labelControlReason = new DevExpress.XtraEditors.LabelControl();
            memoEditReason = new DevExpress.XtraEditors.MemoEdit();
            labelControlLockNotice = new DevExpress.XtraEditors.LabelControl();

            gridControl = new DevExpress.XtraGrid.GridControl();
            gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPOLine = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemLookUpEditPOLine = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colOldValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colNewValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colNote = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)lookUpEditPO.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditNum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditAmendmentDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditAmendmentDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditPreviousValue.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditAmendmentValue.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditRevisedValue.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEditReason.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEditPOLine).BeginInit();
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
            splitContainerControl1.SplitterPosition = 280;
            //
            // groupControl1 ("بيانات تعديل أمر الشراء")
            //
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.Controls.Add(tableLayoutPanel1);
            groupControl1.Name = "groupControl1";
            groupControl1.Text = "بيانات تعديل أمر الشراء";
            //
            // tableLayoutPanel1
            //
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";

            labelControlPO.Text = "أمر الشراء المعتمد:";
            labelControlPO.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlPO.Name = "labelControlPO";
            lookUpEditPO.Dock = System.Windows.Forms.DockStyle.Fill;
            lookUpEditPO.Name = "lookUpEditPO";
            lookUpEditPO.Properties.AutoHeight = false;
            lookUpEditPO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEditPO.Properties.NullText = "";
            lookUpEditPO.Properties.Appearance.BackColor = System.Drawing.Color.LightGreen;
            lookUpEditPO.Properties.Appearance.Options.UseBackColor = true;

            labelControlNum.Text = "رقم التعديل:";
            labelControlNum.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlNum.Name = "labelControlNum";
            textEditNum.Dock = System.Windows.Forms.DockStyle.Fill;
            textEditNum.Enabled = false;
            textEditNum.Name = "textEditNum";
            textEditNum.Properties.AutoHeight = false;
            textEditNum.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            textEditNum.Properties.Appearance.Options.UseBackColor = true;

            labelControlAmendmentDate.Text = "تاريخ التعديل:";
            labelControlAmendmentDate.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlAmendmentDate.Name = "labelControlAmendmentDate";
            dateEditAmendmentDate.Dock = System.Windows.Forms.DockStyle.Fill;
            dateEditAmendmentDate.Name = "dateEditAmendmentDate";
            dateEditAmendmentDate.Properties.AutoHeight = false;
            dateEditAmendmentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            labelControlStatus.Text = "حالة التعديل:";
            labelControlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlStatus.Name = "labelControlStatus";
            comboBoxEditStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            comboBoxEditStatus.Name = "comboBoxEditStatus";
            comboBoxEditStatus.Properties.AutoHeight = false;
            comboBoxEditStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditStatus.Properties.Items.AddRange(new object[] {
                Core.POAmendmentStatus.Draft,
                Core.POAmendmentStatus.PendingApproval,
                Core.POAmendmentStatus.Approved,
                Core.POAmendmentStatus.Rejected });

            labelControlPreviousValue.Text = "القيمة قبل التعديل:";
            labelControlPreviousValue.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlPreviousValue.Name = "labelControlPreviousValue";
            textEditPreviousValue.Dock = System.Windows.Forms.DockStyle.Fill;
            textEditPreviousValue.Enabled = false;
            textEditPreviousValue.Name = "textEditPreviousValue";
            textEditPreviousValue.Properties.AutoHeight = false;
            textEditPreviousValue.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            textEditPreviousValue.Properties.Appearance.Options.UseBackColor = true;

            labelControlAmendmentValue.Text = "قيمة هذا التعديل (+/-):";
            labelControlAmendmentValue.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlAmendmentValue.Name = "labelControlAmendmentValue";
            textEditAmendmentValue.Dock = System.Windows.Forms.DockStyle.Fill;
            textEditAmendmentValue.Name = "textEditAmendmentValue";
            textEditAmendmentValue.Properties.AutoHeight = false;
            textEditAmendmentValue.Properties.Appearance.BackColor = System.Drawing.Color.LightGreen;
            textEditAmendmentValue.Properties.Appearance.Options.UseBackColor = true;

            labelControlRevisedValue.Text = "القيمة بعد التعديل:";
            labelControlRevisedValue.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlRevisedValue.Name = "labelControlRevisedValue";
            textEditRevisedValue.Dock = System.Windows.Forms.DockStyle.Fill;
            textEditRevisedValue.Enabled = false;
            textEditRevisedValue.Name = "textEditRevisedValue";
            textEditRevisedValue.Properties.AutoHeight = false;
            textEditRevisedValue.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            textEditRevisedValue.Properties.Appearance.Options.UseBackColor = true;

            labelControlReason.Text = "سبب التعديل:";
            labelControlReason.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlReason.Name = "labelControlReason";
            memoEditReason.Dock = System.Windows.Forms.DockStyle.Fill;
            memoEditReason.Name = "memoEditReason";

            labelControlLockNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControlLockNotice.Name = "labelControlLockNotice";
            labelControlLockNotice.Appearance.ForeColor = System.Drawing.Color.Firebrick;
            labelControlLockNotice.Appearance.Options.UseForeColor = true;
            labelControlLockNotice.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            labelControlLockNotice.Appearance.Options.UseFont = true;
            labelControlLockNotice.Visible = false;

            tableLayoutPanel1.Controls.Add(labelControlPO, 0, 0);
            tableLayoutPanel1.Controls.Add(lookUpEditPO, 1, 0);
            tableLayoutPanel1.Controls.Add(labelControlNum, 2, 0);
            tableLayoutPanel1.Controls.Add(textEditNum, 3, 0);
            tableLayoutPanel1.Controls.Add(labelControlAmendmentDate, 0, 1);
            tableLayoutPanel1.Controls.Add(dateEditAmendmentDate, 1, 1);
            tableLayoutPanel1.Controls.Add(labelControlStatus, 2, 1);
            tableLayoutPanel1.Controls.Add(comboBoxEditStatus, 3, 1);
            tableLayoutPanel1.Controls.Add(labelControlPreviousValue, 0, 2);
            tableLayoutPanel1.Controls.Add(textEditPreviousValue, 1, 2);
            tableLayoutPanel1.Controls.Add(labelControlAmendmentValue, 2, 2);
            tableLayoutPanel1.Controls.Add(textEditAmendmentValue, 3, 2);
            tableLayoutPanel1.Controls.Add(labelControlRevisedValue, 0, 3);
            tableLayoutPanel1.Controls.Add(textEditRevisedValue, 1, 3);
            tableLayoutPanel1.Controls.Add(labelControlReason, 0, 4);
            tableLayoutPanel1.Controls.Add(memoEditReason, 1, 4);
            tableLayoutPanel1.SetColumnSpan(memoEditReason, 3);
            tableLayoutPanel1.Controls.Add(labelControlLockNotice, 0, 5);
            tableLayoutPanel1.SetColumnSpan(labelControlLockNotice, 4);
            //
            // gridControl / gridView (Panel2 — amendment line details)
            //
            gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl.Location = new System.Drawing.Point(0, 0);
            gridControl.MainView = gridView;
            gridControl.Name = "gridControl";
            gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                repositoryItemLookUpEditPOLine, repositoryItemButtonEditDeleteItem });
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });

            gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colPOLine, colDescription, colOldValue, colNewValue, colNote, colDeleteItem });
            gridView.GridControl = gridControl;
            gridView.Name = "gridView";
            gridView.OptionsBehavior.Editable = true;
            gridView.OptionsView.ShowGroupPanel = false;

            colPOLine.Caption = "بند أمر الشراء (اختياري)";
            colPOLine.ColumnEdit = repositoryItemLookUpEditPOLine;
            colPOLine.FieldName = "POLineId";
            colPOLine.Name = "colPOLine";
            colPOLine.Visible = true;
            colPOLine.VisibleIndex = 0;
            colPOLine.Width = 200;

            repositoryItemLookUpEditPOLine.AutoHeight = false;
            repositoryItemLookUpEditPOLine.Name = "repositoryItemLookUpEditPOLine";
            repositoryItemLookUpEditPOLine.NullText = "";

            colDescription.Caption = "وصف التغيير";
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 1;
            colDescription.Width = 220;

            colOldValue.Caption = "القيمة السابقة";
            colOldValue.FieldName = "OldValue";
            colOldValue.Name = "colOldValue";
            colOldValue.Visible = true;
            colOldValue.VisibleIndex = 2;
            colOldValue.Width = 100;
            colOldValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colOldValue.DisplayFormat.FormatString = "N2";

            colNewValue.Caption = "القيمة الجديدة";
            colNewValue.FieldName = "NewValue";
            colNewValue.Name = "colNewValue";
            colNewValue.Visible = true;
            colNewValue.VisibleIndex = 3;
            colNewValue.Width = 100;
            colNewValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colNewValue.DisplayFormat.FormatString = "N2";

            colNote.Caption = "ملاحظات";
            colNote.FieldName = "Note";
            colNote.Name = "colNote";
            colNote.Visible = true;
            colNote.VisibleIndex = 4;
            colNote.Width = 200;

            colDeleteItem.Caption = "";
            colDeleteItem.ColumnEdit = repositoryItemButtonEditDeleteItem;
            colDeleteItem.Name = "colDeleteItem";
            colDeleteItem.Visible = true;
            colDeleteItem.VisibleIndex = 5;
            colDeleteItem.Width = 40;
            colDeleteItem.OptionsColumn.AllowEdit = false;

            repositoryItemButtonEditDeleteItem.AutoHeight = false;
            repositoryItemButtonEditDeleteItem.Name = "repositoryItemButtonEditDeleteItem";
            repositoryItemButtonEditDeleteItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repositoryItemButtonEditDeleteItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) });
            //
            // frmPOAmendmentAddEdit
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1288, 710);
            Controls.Add(splitContainerControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "frmPOAmendmentAddEdit";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "إضافة / تعديل — تعديل أمر شراء";
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
            ((System.ComponentModel.ISupportInitialize)lookUpEditPO.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditNum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditAmendmentDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditAmendmentDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditPreviousValue.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditAmendmentValue.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditRevisedValue.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEditReason.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEditPOLine).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControlPO;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPO;
        private DevExpress.XtraEditors.LabelControl labelControlNum;
        private DevExpress.XtraEditors.TextEdit textEditNum;
        private DevExpress.XtraEditors.LabelControl labelControlAmendmentDate;
        private DevExpress.XtraEditors.DateEdit dateEditAmendmentDate;
        private DevExpress.XtraEditors.LabelControl labelControlStatus;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditStatus;
        private DevExpress.XtraEditors.LabelControl labelControlPreviousValue;
        private DevExpress.XtraEditors.TextEdit textEditPreviousValue;
        private DevExpress.XtraEditors.LabelControl labelControlAmendmentValue;
        private DevExpress.XtraEditors.TextEdit textEditAmendmentValue;
        private DevExpress.XtraEditors.LabelControl labelControlRevisedValue;
        private DevExpress.XtraEditors.TextEdit textEditRevisedValue;
        private DevExpress.XtraEditors.LabelControl labelControlReason;
        private DevExpress.XtraEditors.MemoEdit memoEditReason;
        private DevExpress.XtraEditors.LabelControl labelControlLockNotice;

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colPOLine;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditPOLine;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOldValue;
        private DevExpress.XtraGrid.Columns.GridColumn colNewValue;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleteItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditDeleteItem;
    }
}
