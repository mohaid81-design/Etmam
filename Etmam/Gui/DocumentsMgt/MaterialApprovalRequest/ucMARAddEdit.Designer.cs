namespace Etmam
{
    partial class ucMARAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMARAddEdit));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            materialApprovalRequestDetailsBindingSource = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colMARId = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colPurpose = new DevExpress.XtraGrid.Columns.GridColumn();
            colManufacture = new DevExpress.XtraGrid.Columns.GridColumn();
            colBOQRef = new DevExpress.XtraGrid.Columns.GridColumn();
            colDrawingRef = new DevExpress.XtraGrid.Columns.GridColumn();
            colSpecRef = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrjId = new DevExpress.XtraGrid.Columns.GridColumn();
            colReviewComment = new DevExpress.XtraGrid.Columns.GridColumn();
            colReviewStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsRejectedItemRequiredResubmitt = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsRejectedItemResubmitted = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletion = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)materialApprovalRequestDetailsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
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
            barManager1.Images = imageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiDelete, barStaticItem1 });
            barManager1.MaxItemId = 4;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiAdd
            // 
            bbiAdd.Caption = "إضافة";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.ImageIndex = 0;
            bbiAdd.Name = "bbiAdd";
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 1;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.Name = "bbiDelete";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1300, 24);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 474);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1300, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 24);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 450);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1300, 24);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 450);
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
            // barStaticItem1
            // 
            barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barStaticItem1.Caption = "عدد السجلات : 0";
            barStaticItem1.Id = 3;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // gridControl1
            // 
            gridControl1.DataSource = materialApprovalRequestDetailsBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 24);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1300, 450);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // materialApprovalRequestDetailsBindingSource
            // 
            materialApprovalRequestDetailsBindingSource.DataSource = typeof(Core.MaterialApprovalRequestDetails);
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView1.Appearance.Row.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Appearance.Row.Options.UseTextOptions = true;
            gridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colMARId, colDescription, colPurpose, colManufacture, colBOQRef, colDrawingRef, colSpecRef, colPrjId, colReviewStatus, colReviewComment, colIsRejectedItemRequiredResubmitt, colIsRejectedItemResubmitted, colCreatedDate, colCreatedMachine, colUpdateDate, colUpdateMachine, colIsDelete, colDeletionDate, colDeletionMachine, colCreatedBy, colCreated, colUpdateBy, colUpdate, colDeletionBy, colDeletion });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colMARId
            // 
            colMARId.FieldName = "MARId";
            colMARId.Name = "colMARId";
            // 
            // colDescription
            // 
            colDescription.Caption = "وصف المواد/ العينه";
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colDescription.OptionsColumn.AllowShowHide = false;
            colDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colDescription.OptionsFilter.AllowAutoFilter = false;
            colDescription.OptionsFilter.AllowFilter = false;
            colDescription.Visible = true;
            colDescription.VisibleIndex = 0;
            colDescription.Width = 250;
            // 
            // colPurpose
            // 
            colPurpose.Caption = "غرض الإستخدام";
            colPurpose.FieldName = "Purpose";
            colPurpose.Name = "colPurpose";
            colPurpose.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colPurpose.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colPurpose.OptionsFilter.AllowAutoFilter = false;
            colPurpose.OptionsFilter.AllowFilter = false;
            colPurpose.Visible = true;
            colPurpose.VisibleIndex = 1;
            colPurpose.Width = 200;
            // 
            // colManufacture
            // 
            colManufacture.Caption = "المصنع/ المورد";
            colManufacture.FieldName = "Manufacture";
            colManufacture.Name = "colManufacture";
            colManufacture.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colManufacture.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colManufacture.OptionsFilter.AllowAutoFilter = false;
            colManufacture.OptionsFilter.AllowFilter = false;
            colManufacture.Visible = true;
            colManufacture.VisibleIndex = 2;
            colManufacture.Width = 150;
            // 
            // colBOQRef
            // 
            colBOQRef.AppearanceCell.Options.UseTextOptions = true;
            colBOQRef.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colBOQRef.Caption = "مرجع جدول الكميات";
            colBOQRef.FieldName = "BOQRef";
            colBOQRef.Name = "colBOQRef";
            colBOQRef.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colBOQRef.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colBOQRef.OptionsFilter.AllowAutoFilter = false;
            colBOQRef.OptionsFilter.AllowFilter = false;
            colBOQRef.Visible = true;
            colBOQRef.VisibleIndex = 3;
            colBOQRef.Width = 80;
            // 
            // colDrawingRef
            // 
            colDrawingRef.AppearanceCell.Options.UseTextOptions = true;
            colDrawingRef.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colDrawingRef.Caption = "مرجع المخططات";
            colDrawingRef.FieldName = "DrawingRef";
            colDrawingRef.Name = "colDrawingRef";
            colDrawingRef.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colDrawingRef.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colDrawingRef.OptionsFilter.AllowAutoFilter = false;
            colDrawingRef.OptionsFilter.AllowFilter = false;
            colDrawingRef.Visible = true;
            colDrawingRef.VisibleIndex = 4;
            colDrawingRef.Width = 80;
            // 
            // colSpecRef
            // 
            colSpecRef.AppearanceCell.Options.UseTextOptions = true;
            colSpecRef.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSpecRef.Caption = "مرجع المواصفات";
            colSpecRef.FieldName = "SpecRef";
            colSpecRef.Name = "colSpecRef";
            colSpecRef.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colSpecRef.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colSpecRef.OptionsFilter.AllowAutoFilter = false;
            colSpecRef.OptionsFilter.AllowFilter = false;
            colSpecRef.Visible = true;
            colSpecRef.VisibleIndex = 5;
            colSpecRef.Width = 80;
            // 
            // colPrjId
            // 
            colPrjId.FieldName = "PrjId";
            colPrjId.Name = "colPrjId";
            // 
            // colReviewComment
            // 
            colReviewComment.Caption = "تعليق المراجعه";
            colReviewComment.FieldName = "ReviewComment";
            colReviewComment.Name = "colReviewComment";
            colReviewComment.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colReviewComment.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colReviewComment.OptionsFilter.AllowAutoFilter = false;
            colReviewComment.OptionsFilter.AllowFilter = false;
            colReviewComment.Visible = true;
            colReviewComment.VisibleIndex = 7;
            colReviewComment.Width = 120;
            // 
            // colReviewStatus
            // 
            colReviewStatus.AppearanceCell.Options.UseTextOptions = true;
            colReviewStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colReviewStatus.Caption = "قرار المراجعه";
            colReviewStatus.FieldName = "ReviewStatus";
            colReviewStatus.Name = "colReviewStatus";
            colReviewStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colReviewStatus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colReviewStatus.OptionsFilter.AllowAutoFilter = false;
            colReviewStatus.OptionsFilter.AllowFilter = false;
            colReviewStatus.Visible = true;
            colReviewStatus.VisibleIndex = 6;
            colReviewStatus.Width = 100;
            // 
            // colIsRejectedItemRequiredResubmitt
            // 
            colIsRejectedItemRequiredResubmitt.Caption = "هل قرار الاستشاري يستلزم إعادة تقديم";
            colIsRejectedItemRequiredResubmitt.FieldName = "IsRejectedItemRequiredResubmitt";
            colIsRejectedItemRequiredResubmitt.Name = "colIsRejectedItemRequiredResubmitt";
            colIsRejectedItemRequiredResubmitt.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colIsRejectedItemRequiredResubmitt.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colIsRejectedItemRequiredResubmitt.OptionsFilter.AllowAutoFilter = false;
            colIsRejectedItemRequiredResubmitt.OptionsFilter.AllowFilter = false;
            colIsRejectedItemRequiredResubmitt.Width = 80;
            // 
            // colIsRejectedItemResubmitted
            // 
            colIsRejectedItemResubmitted.Caption = "هل تم إعادة التقديم";
            colIsRejectedItemResubmitted.FieldName = "IsRejectedItemResubmitted";
            colIsRejectedItemResubmitted.Name = "colIsRejectedItemResubmitted";
            colIsRejectedItemResubmitted.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colIsRejectedItemResubmitted.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colIsRejectedItemResubmitted.OptionsFilter.AllowAutoFilter = false;
            colIsRejectedItemResubmitted.OptionsFilter.AllowFilter = false;
            colIsRejectedItemResubmitted.Width = 80;
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colCreatedMachine
            // 
            colCreatedMachine.FieldName = "CreatedMachine";
            colCreatedMachine.Name = "colCreatedMachine";
            // 
            // colUpdateDate
            // 
            colUpdateDate.FieldName = "UpdateDate";
            colUpdateDate.Name = "colUpdateDate";
            // 
            // colUpdateMachine
            // 
            colUpdateMachine.FieldName = "UpdateMachine";
            colUpdateMachine.Name = "colUpdateMachine";
            // 
            // colIsDelete
            // 
            colIsDelete.FieldName = "IsDelete";
            colIsDelete.Name = "colIsDelete";
            // 
            // colDeletionDate
            // 
            colDeletionDate.FieldName = "DeletionDate";
            colDeletionDate.Name = "colDeletionDate";
            // 
            // colDeletionMachine
            // 
            colDeletionMachine.FieldName = "DeletionMachine";
            colDeletionMachine.Name = "colDeletionMachine";
            // 
            // colCreatedBy
            // 
            colCreatedBy.FieldName = "CreatedBy";
            colCreatedBy.Name = "colCreatedBy";
            // 
            // colCreated
            // 
            colCreated.FieldName = "Created";
            colCreated.Name = "colCreated";
            // 
            // colUpdateBy
            // 
            colUpdateBy.FieldName = "UpdateBy";
            colUpdateBy.Name = "colUpdateBy";
            // 
            // colUpdate
            // 
            colUpdate.FieldName = "Update";
            colUpdate.Name = "colUpdate";
            // 
            // colDeletionBy
            // 
            colDeletionBy.FieldName = "DeletionBy";
            colDeletionBy.Name = "colDeletionBy";
            // 
            // colDeletion
            // 
            colDeletion.FieldName = "Deletion";
            colDeletion.Name = "colDeletion";
            // 
            // ucMARAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucMARAddEdit";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1300, 474);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)materialApprovalRequestDetailsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BindingSource materialApprovalRequestDetailsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colMARId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPurpose;
        private DevExpress.XtraGrid.Columns.GridColumn colManufacture;
        private DevExpress.XtraGrid.Columns.GridColumn colBOQRef;
        private DevExpress.XtraGrid.Columns.GridColumn colDrawingRef;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecRef;
        private DevExpress.XtraGrid.Columns.GridColumn colPrjId;
        private DevExpress.XtraGrid.Columns.GridColumn colReviewComment;
        private DevExpress.XtraGrid.Columns.GridColumn colReviewStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colIsRejectedItemRequiredResubmitt;
        private DevExpress.XtraGrid.Columns.GridColumn colIsRejectedItemResubmitted;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreated;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletion;
    }
}
