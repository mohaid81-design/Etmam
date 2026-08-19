namespace Etmam
{
    partial class frmTechnicalEvaluationAddEdit
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
            tableLayoutPanel1 = new TableLayoutPanel();
            labelControlRFQ = new DevExpress.XtraEditors.LabelControl();
            lookUpEditRFQ = new DevExpress.XtraEditors.LookUpEdit();
            labelControlQuotation = new DevExpress.XtraEditors.LabelControl();
            lookUpEditQuotation = new DevExpress.XtraEditors.LookUpEdit();
            labelControlEvaluationDate = new DevExpress.XtraEditors.LabelControl();
            dateEditEvaluationDate = new DevExpress.XtraEditors.DateEdit();
            labelControlStatus = new DevExpress.XtraEditors.LabelControl();
            comboBoxEditStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControlOverallComment = new DevExpress.XtraEditors.LabelControl();
            memoEditOverallComment = new DevExpress.XtraEditors.MemoEdit();
            gridControl = new DevExpress.XtraGrid.GridControl();
            gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsCompliant = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemCheckEditCompliant = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colComment = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)lookUpEditRFQ.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditQuotation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEvaluationDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEvaluationDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEditOverallComment.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEditCompliant).BeginInit();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiFirst, bbiPrev, bbiNext, bbiLast, bbiSave });
            barManager1.MainMenu = bar1;
            barManager1.MaxItemId = 6;
            // 
            // bar1
            // 
            bar1.BarName = "Main menu";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbiNew), new DevExpress.XtraBars.LinkPersistInfo(bbiFirst), new DevExpress.XtraBars.LinkPersistInfo(bbiPrev), new DevExpress.XtraBars.LinkPersistInfo(bbiNext), new DevExpress.XtraBars.LinkPersistInfo(bbiLast), new DevExpress.XtraBars.LinkPersistInfo(bbiSave) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.MinHeight = 35;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Main menu";
            // 
            // bbiNew
            // 
            bbiNew.Caption = "جديد";
            bbiNew.Id = 0;
            bbiNew.ImageOptions.Image = Properties.Resources.add_16x161;
            bbiNew.Name = "bbiNew";
            bbiNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiFirst
            // 
            bbiFirst.Caption = "الأول";
            bbiFirst.Id = 1;
            bbiFirst.ImageOptions.Image = Properties.Resources.last_16x162;
            bbiFirst.Name = "bbiFirst";
            bbiFirst.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiPrev
            // 
            bbiPrev.Caption = "السابق";
            bbiPrev.Id = 2;
            bbiPrev.ImageOptions.Image = Properties.Resources.next_16x162;
            bbiPrev.Name = "bbiPrev";
            bbiPrev.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiNext
            // 
            bbiNext.Caption = "اللاحق";
            bbiNext.Id = 3;
            bbiNext.ImageOptions.Image = Properties.Resources.prev_16x162;
            bbiNext.Name = "bbiNext";
            bbiNext.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiLast
            // 
            bbiLast.Caption = "الأخير";
            bbiLast.Id = 4;
            bbiLast.ImageOptions.Image = Properties.Resources.first_16x162;
            bbiLast.Name = "bbiLast";
            bbiLast.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiSave
            // 
            bbiSave.Caption = "حفظ";
            bbiSave.Id = 5;
            bbiSave.ImageOptions.Image = Properties.Resources.save_16x161;
            bbiSave.Name = "bbiSave";
            bbiSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Margin = new Padding(3, 5, 3, 5);
            barDockControlTop.Size = new Size(1106, 35);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 641);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Margin = new Padding(3, 5, 3, 5);
            barDockControlBottom.Size = new Size(1106, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 35);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Margin = new Padding(3, 5, 3, 5);
            barDockControlLeft.Size = new Size(0, 606);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1106, 35);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Margin = new Padding(3, 5, 3, 5);
            barDockControlRight.Size = new Size(0, 606);
            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = DockStyle.Fill;
            splitContainerControl1.Horizontal = false;
            splitContainerControl1.Location = new Point(0, 35);
            splitContainerControl1.Margin = new Padding(3, 5, 3, 5);
            splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            splitContainerControl1.Panel1.Controls.Add(groupControl1);
            // 
            // splitContainerControl1.Panel2
            // 
            splitContainerControl1.Panel2.Controls.Add(gridControl);
            splitContainerControl1.Size = new Size(1106, 606);
            splitContainerControl1.SplitterPosition = 294;
            splitContainerControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new Font("Cairo", 9F, FontStyle.Bold);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.Controls.Add(tableLayoutPanel1);
            groupControl1.Dock = DockStyle.Fill;
            groupControl1.Location = new Point(0, 0);
            groupControl1.Margin = new Padding(3, 5, 3, 5);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(1106, 294);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "بيانات التقييم الفني";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(labelControlRFQ, 0, 0);
            tableLayoutPanel1.Controls.Add(lookUpEditRFQ, 1, 0);
            tableLayoutPanel1.Controls.Add(labelControlQuotation, 2, 0);
            tableLayoutPanel1.Controls.Add(lookUpEditQuotation, 3, 0);
            tableLayoutPanel1.Controls.Add(labelControlEvaluationDate, 0, 1);
            tableLayoutPanel1.Controls.Add(dateEditEvaluationDate, 1, 1);
            tableLayoutPanel1.Controls.Add(labelControlStatus, 2, 1);
            tableLayoutPanel1.Controls.Add(comboBoxEditStatus, 3, 1);
            tableLayoutPanel1.Controls.Add(labelControlOverallComment, 0, 2);
            tableLayoutPanel1.Controls.Add(memoEditOverallComment, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(2, 27);
            tableLayoutPanel1.Margin = new Padding(3, 5, 3, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(9, 14, 9, 14);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1102, 265);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControlRFQ
            // 
            labelControlRFQ.Dock = DockStyle.Fill;
            labelControlRFQ.Location = new Point(934, 19);
            labelControlRFQ.Margin = new Padding(3, 5, 3, 5);
            labelControlRFQ.Name = "labelControlRFQ";
            labelControlRFQ.Size = new Size(156, 35);
            labelControlRFQ.TabIndex = 0;
            labelControlRFQ.Text = "طلب عروض الأسعار (RFQ):";
            // 
            // lookUpEditRFQ
            // 
            lookUpEditRFQ.Dock = DockStyle.Fill;
            lookUpEditRFQ.Location = new Point(555, 19);
            lookUpEditRFQ.Margin = new Padding(3, 5, 3, 5);
            lookUpEditRFQ.Name = "lookUpEditRFQ";
            lookUpEditRFQ.Properties.AutoHeight = false;
            lookUpEditRFQ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEditRFQ.Properties.NullText = "";
            lookUpEditRFQ.Size = new Size(373, 35);
            lookUpEditRFQ.TabIndex = 1;
            // 
            // labelControlQuotation
            // 
            labelControlQuotation.Dock = DockStyle.Fill;
            labelControlQuotation.Location = new Point(393, 19);
            labelControlQuotation.Margin = new Padding(3, 5, 3, 5);
            labelControlQuotation.Name = "labelControlQuotation";
            labelControlQuotation.Size = new Size(156, 35);
            labelControlQuotation.TabIndex = 2;
            labelControlQuotation.Text = "عرض المورد المُقيَّم:";
            // 
            // lookUpEditQuotation
            // 
            lookUpEditQuotation.Dock = DockStyle.Fill;
            lookUpEditQuotation.Location = new Point(12, 19);
            lookUpEditQuotation.Margin = new Padding(3, 5, 3, 5);
            lookUpEditQuotation.Name = "lookUpEditQuotation";
            lookUpEditQuotation.Properties.Appearance.BackColor = Color.LightGreen;
            lookUpEditQuotation.Properties.Appearance.Options.UseBackColor = true;
            lookUpEditQuotation.Properties.AutoHeight = false;
            lookUpEditQuotation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpEditQuotation.Properties.NullText = "";
            lookUpEditQuotation.Size = new Size(375, 35);
            lookUpEditQuotation.TabIndex = 3;
            // 
            // labelControlEvaluationDate
            // 
            labelControlEvaluationDate.Dock = DockStyle.Fill;
            labelControlEvaluationDate.Location = new Point(934, 64);
            labelControlEvaluationDate.Margin = new Padding(3, 5, 3, 5);
            labelControlEvaluationDate.Name = "labelControlEvaluationDate";
            labelControlEvaluationDate.Size = new Size(156, 35);
            labelControlEvaluationDate.TabIndex = 4;
            labelControlEvaluationDate.Text = "تاريخ التقييم:";
            // 
            // dateEditEvaluationDate
            // 
            dateEditEvaluationDate.Dock = DockStyle.Fill;
            dateEditEvaluationDate.EditValue = new DateTime(2026, 7, 31, 0, 0, 0, 0);
            dateEditEvaluationDate.Location = new Point(555, 64);
            dateEditEvaluationDate.Margin = new Padding(3, 5, 3, 5);
            dateEditEvaluationDate.Name = "dateEditEvaluationDate";
            dateEditEvaluationDate.Properties.AutoHeight = false;
            dateEditEvaluationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditEvaluationDate.Size = new Size(373, 35);
            dateEditEvaluationDate.TabIndex = 5;
            // 
            // labelControlStatus
            // 
            labelControlStatus.Dock = DockStyle.Fill;
            labelControlStatus.Location = new Point(393, 64);
            labelControlStatus.Margin = new Padding(3, 5, 3, 5);
            labelControlStatus.Name = "labelControlStatus";
            labelControlStatus.Size = new Size(156, 35);
            labelControlStatus.TabIndex = 6;
            labelControlStatus.Text = "نتيجة التقييم الفني:";
            // 
            // comboBoxEditStatus
            // 
            comboBoxEditStatus.Dock = DockStyle.Fill;
            comboBoxEditStatus.Location = new Point(12, 64);
            comboBoxEditStatus.Margin = new Padding(3, 5, 3, 5);
            comboBoxEditStatus.Name = "comboBoxEditStatus";
            comboBoxEditStatus.Properties.AutoHeight = false;
            comboBoxEditStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditStatus.Properties.Items.AddRange(new object[] { "معتمد فنياً", "معتمد فنياً مع ملاحظات", "يتطلب توضيح من المورد", "مرفوض فنياً" });
            comboBoxEditStatus.Size = new Size(375, 35);
            comboBoxEditStatus.TabIndex = 7;
            // 
            // labelControlOverallComment
            // 
            labelControlOverallComment.Dock = DockStyle.Fill;
            labelControlOverallComment.Location = new Point(934, 109);
            labelControlOverallComment.Margin = new Padding(3, 5, 3, 5);
            labelControlOverallComment.Name = "labelControlOverallComment";
            labelControlOverallComment.Size = new Size(156, 137);
            labelControlOverallComment.TabIndex = 8;
            labelControlOverallComment.Text = "ملاحظة عامة:";
            // 
            // memoEditOverallComment
            // 
            tableLayoutPanel1.SetColumnSpan(memoEditOverallComment, 3);
            memoEditOverallComment.Dock = DockStyle.Fill;
            memoEditOverallComment.Location = new Point(12, 109);
            memoEditOverallComment.Margin = new Padding(3, 5, 3, 5);
            memoEditOverallComment.Name = "memoEditOverallComment";
            memoEditOverallComment.Size = new Size(916, 137);
            memoEditOverallComment.TabIndex = 9;
            // 
            // gridControl
            // 
            gridControl.Dock = DockStyle.Fill;
            gridControl.EmbeddedNavigator.Margin = new Padding(3, 5, 3, 5);
            gridControl.Location = new Point(0, 0);
            gridControl.MainView = gridView;
            gridControl.Margin = new Padding(3, 5, 3, 5);
            gridControl.Name = "gridControl";
            gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEditCompliant });
            gridControl.Size = new Size(1106, 302);
            gridControl.TabIndex = 0;
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
            // 
            // gridView
            // 
            gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colItem, colQty, colUnit, colUnitPrice, colTotalPrice, colIsCompliant, colComment });
            gridView.DetailHeight = 466;
            gridView.GridControl = gridControl;
            gridView.Name = "gridView";
            gridView.OptionsEditForm.PopupEditFormWidth = 686;
            gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colItem
            // 
            colItem.Caption = "الصنف";
            colItem.FieldName = "ItemDisplay";
            colItem.MinWidth = 17;
            colItem.Name = "colItem";
            colItem.OptionsColumn.AllowEdit = false;
            colItem.Visible = true;
            colItem.VisibleIndex = 0;
            colItem.Width = 171;
            // 
            // colQty
            // 
            colQty.Caption = "الكمية";
            colQty.DisplayFormat.FormatString = "N2";
            colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQty.FieldName = "Qty";
            colQty.MinWidth = 17;
            colQty.Name = "colQty";
            colQty.OptionsColumn.AllowEdit = false;
            colQty.Visible = true;
            colQty.VisibleIndex = 1;
            colQty.Width = 69;
            // 
            // colUnit
            // 
            colUnit.Caption = "الوحدة";
            colUnit.FieldName = "UnitDisplay";
            colUnit.MinWidth = 17;
            colUnit.Name = "colUnit";
            colUnit.OptionsColumn.AllowEdit = false;
            colUnit.Visible = true;
            colUnit.VisibleIndex = 2;
            colUnit.Width = 60;
            // 
            // colUnitPrice
            // 
            colUnitPrice.Caption = "سعر الوحدة";
            colUnitPrice.DisplayFormat.FormatString = "N2";
            colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colUnitPrice.FieldName = "UnitPrice";
            colUnitPrice.MinWidth = 17;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.OptionsColumn.AllowEdit = false;
            colUnitPrice.Visible = true;
            colUnitPrice.VisibleIndex = 3;
            colUnitPrice.Width = 77;
            // 
            // colTotalPrice
            // 
            colTotalPrice.Caption = "الإجمالي";
            colTotalPrice.DisplayFormat.FormatString = "N2";
            colTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTotalPrice.FieldName = "TotalPrice";
            colTotalPrice.MinWidth = 17;
            colTotalPrice.Name = "colTotalPrice";
            colTotalPrice.OptionsColumn.AllowEdit = false;
            colTotalPrice.Visible = true;
            colTotalPrice.VisibleIndex = 4;
            colTotalPrice.Width = 77;
            // 
            // colIsCompliant
            // 
            colIsCompliant.Caption = "مطابق فنياً؟";
            colIsCompliant.ColumnEdit = repositoryItemCheckEditCompliant;
            colIsCompliant.FieldName = "IsCompliant";
            colIsCompliant.MinWidth = 17;
            colIsCompliant.Name = "colIsCompliant";
            colIsCompliant.Visible = true;
            colIsCompliant.VisibleIndex = 5;
            colIsCompliant.Width = 77;
            // 
            // repositoryItemCheckEditCompliant
            // 
            repositoryItemCheckEditCompliant.AutoHeight = false;
            repositoryItemCheckEditCompliant.Name = "repositoryItemCheckEditCompliant";
            // 
            // colComment
            // 
            colComment.Caption = "ملاحظة البند";
            colComment.FieldName = "Comment";
            colComment.MinWidth = 17;
            colComment.Name = "colComment";
            colComment.Visible = true;
            colComment.VisibleIndex = 6;
            colComment.Width = 214;
            // 
            // frmTechnicalEvaluationAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 641);
            Controls.Add(splitContainerControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new Font("Cairo", 8.25F);
            Margin = new Padding(3, 5, 3, 5);
            Name = "frmTechnicalEvaluationAddEdit";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة / تعديل تقييم فني";
            WindowState = FormWindowState.Maximized;
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
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lookUpEditRFQ.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditQuotation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEvaluationDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEvaluationDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEditOverallComment.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEditCompliant).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DevExpress.XtraEditors.LabelControl labelControlRFQ;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditRFQ;
        private DevExpress.XtraEditors.LabelControl labelControlQuotation;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditQuotation;
        private DevExpress.XtraEditors.LabelControl labelControlEvaluationDate;
        private DevExpress.XtraEditors.DateEdit dateEditEvaluationDate;
        private DevExpress.XtraEditors.LabelControl labelControlStatus;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditStatus;
        private DevExpress.XtraEditors.LabelControl labelControlOverallComment;
        private DevExpress.XtraEditors.MemoEdit memoEditOverallComment;

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCompliant;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditCompliant;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
    }
}
