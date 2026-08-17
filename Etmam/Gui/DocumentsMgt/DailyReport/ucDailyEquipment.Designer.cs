
namespace Etmam
{
    partial class ucDailyEquipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDailyEquipment));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiCopy = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            gridEquipment = new DevExpress.XtraGrid.GridControl();
            gvEquipment = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colEquipmentListId = new DevExpress.XtraGrid.Columns.GridColumn();
            repoEquipment = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colDailyReportId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colDailyReport = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridEquipment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvEquipment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoEquipment).BeginInit();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiDelete, bbiCopy, barStaticItem1 });
            barManager1.MaxItemId = 4;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCopy, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
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
            // bbiCopy
            // 
            bbiCopy.Caption = "جلب بيانات اليوم السابق";
            bbiCopy.Id = 2;
            bbiCopy.ImageOptions.ImageIndex = 9;
            bbiCopy.Name = "bbiCopy";
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
            barDockControlTop.Size = new Size(1280, 28);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 517);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1280, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 28);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 489);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1280, 28);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 489);
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
            imageCollection1.InsertImage(Properties.Resources.edit_16x163, "edit_16x163", typeof(Properties.Resources), 8);
            imageCollection1.Images.SetKeyName(8, "edit_16x163");
            imageCollection1.InsertImage(Properties.Resources.sortbyinvoice_16x162, "sortbyinvoice_16x162", typeof(Properties.Resources), 9);
            imageCollection1.Images.SetKeyName(9, "sortbyinvoice_16x162");
            // 
            // barStaticItem1
            // 
            barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barStaticItem1.Caption = "عدد السجلات : 0";
            barStaticItem1.Id = 3;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            groupControl1.AppearanceCaption.ForeColor = Color.FromArgb(30, 70, 130);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseForeColor = true;
            groupControl1.Controls.Add(gridEquipment);
            groupControl1.Dock = DockStyle.Fill;
            groupControl1.Location = new Point(0, 28);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(1280, 489);
            groupControl1.TabIndex = 11;
            groupControl1.Text = "المعدات والآليات";
            // 
            // gridEquipment
            // 
            gridEquipment.Dock = DockStyle.Fill;
            gridEquipment.Location = new Point(2, 27);
            gridEquipment.MainView = gvEquipment;
            gridEquipment.MenuManager = barManager1;
            gridEquipment.Name = "gridEquipment";
            gridEquipment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoEquipment });
            gridEquipment.Size = new Size(1276, 460);
            gridEquipment.TabIndex = 4;
            gridEquipment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvEquipment });
            // 
            // gvEquipment
            // 
            gvEquipment.Appearance.EvenRow.BackColor = Color.FromArgb(248, 249, 250);
            gvEquipment.Appearance.EvenRow.Options.UseBackColor = true;
            gvEquipment.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            gvEquipment.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(30, 70, 130);
            gvEquipment.Appearance.HeaderPanel.Options.UseFont = true;
            gvEquipment.Appearance.HeaderPanel.Options.UseForeColor = true;
            gvEquipment.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvEquipment.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvEquipment.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8.5F);
            gvEquipment.Appearance.Row.Options.UseFont = true;
            gvEquipment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colEquipmentListId, colQty, colStatus, colDailyReportId, colCreatedBy, colCreatedDate, colCreatedMachine, colUpdateBy, colUpdateDate, colUpdateMachine, colIsDelete, colDeletionBy, colDeletionDate, colDeletionMachine, colDailyReport });
            gvEquipment.GridControl = gridEquipment;
            gvEquipment.Name = "gvEquipment";
            gvEquipment.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvEquipment.OptionsView.ColumnAutoWidth = false;
            gvEquipment.OptionsView.EnableAppearanceEvenRow = true;
            gvEquipment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gvEquipment.OptionsView.ShowGroupPanel = false;
            gvEquipment.ViewCaption = "المعدات";
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colEquipmentListId
            // 
            colEquipmentListId.Caption = "المعدة";
            colEquipmentListId.ColumnEdit = repoEquipment;
            colEquipmentListId.FieldName = "EquipmentListId";
            colEquipmentListId.Name = "colEquipmentListId";
            colEquipmentListId.Visible = true;
            colEquipmentListId.VisibleIndex = 0;
            colEquipmentListId.Width = 300;
            // 
            // repoEquipment
            // 
            repoEquipment.AutoHeight = false;
            repoEquipment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoEquipment.Name = "repoEquipment";
            // 
            // colQty
            // 
            colQty.AppearanceCell.Options.UseTextOptions = true;
            colQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colQty.Caption = "العدد";
            colQty.FieldName = "Qty";
            colQty.Name = "colQty";
            colQty.Visible = true;
            colQty.VisibleIndex = 1;
            colQty.Width = 100;
            // 
            // colStatus
            // 
            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 2;
            colStatus.Width = 200;
            // 
            // colDailyReportId
            // 
            colDailyReportId.FieldName = "DailyReportId";
            colDailyReportId.Name = "colDailyReportId";
            // 
            // colCreatedBy
            // 
            colCreatedBy.FieldName = "CreatedBy";
            colCreatedBy.Name = "colCreatedBy";
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
            // colUpdateBy
            // 
            colUpdateBy.FieldName = "UpdateBy";
            colUpdateBy.Name = "colUpdateBy";
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
            // colDeletionBy
            // 
            colDeletionBy.FieldName = "DeletionBy";
            colDeletionBy.Name = "colDeletionBy";
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
            // colDailyReport
            // 
            colDailyReport.FieldName = "DailyReport";
            colDailyReport.Name = "colDailyReport";
            // 
            // ucDailyEquipment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new System.Drawing.Font("Cairo", 8.5F);
            Name = "ucDailyEquipment";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1280, 517);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridEquipment).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvEquipment).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoEquipment).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        public DevExpress.XtraBars.BarButtonItem bbiCopy;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridEquipment;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEquipment;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyReportId;
        private DevExpress.XtraGrid.Columns.GridColumn colEquipmentListId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoEquipment;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyReport;
    }
}
