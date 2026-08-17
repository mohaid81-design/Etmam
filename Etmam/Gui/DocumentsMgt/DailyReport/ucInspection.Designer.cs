using System.Drawing;
using System.Windows.Forms;

namespace Etmam
{
    partial class ucInspection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucInspection));
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
            gridInspection = new DevExpress.XtraGrid.GridControl();
            gvInspection = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colInspectionDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            colDailyReportId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colDeletionBy = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridInspection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvInspection).BeginInit();
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
            bbiCopy.Caption = "نسخ من يوم سابق";
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
            imageCollection1.InsertImage(Properties.Resources.edit_16x16, "edit_16x16", typeof(Properties.Resources), 7);
            imageCollection1.Images.SetKeyName(7, "edit_16x16");
            imageCollection1.Images.SetKeyName(8, "6_Search.png");
            imageCollection1.InsertImage(Properties.Resources.sortbyinvoice_16x16, "sortbyinvoice_16x16", typeof(Properties.Resources), 9);
            imageCollection1.Images.SetKeyName(9, "sortbyinvoice_16x16");
            // 
            // barStaticItem1
            // 
            barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barStaticItem1.Caption = "العدد: 0";
            barStaticItem1.Id = 3;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            groupControl1.AppearanceCaption.ForeColor = Color.FromArgb(30, 70, 130);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseForeColor = true;
            groupControl1.Controls.Add(gridInspection);
            groupControl1.Dock = DockStyle.Fill;
            groupControl1.Location = new Point(0, 28);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(1280, 489);
            groupControl1.TabIndex = 11;
            groupControl1.Text = "الفحص والمراجعة";
            // 
            // gridInspection
            // 
            gridInspection.Dock = DockStyle.Fill;
            gridInspection.Location = new Point(2, 27);
            gridInspection.MainView = gvInspection;
            gridInspection.MenuManager = barManager1;
            gridInspection.Name = "gridInspection";
            gridInspection.Size = new Size(1276, 460);
            gridInspection.TabIndex = 4;
            gridInspection.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvInspection });
            // 
            // gvInspection
            // 
            gvInspection.Appearance.EvenRow.BackColor = Color.FromArgb(248, 249, 250);
            gvInspection.Appearance.EvenRow.Options.UseBackColor = true;
            gvInspection.Appearance.HeaderPanel.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            gvInspection.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            gvInspection.Appearance.HeaderPanel.Options.UseFont = true;
            gvInspection.Appearance.HeaderPanel.Options.UseForeColor = true;
            gvInspection.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvInspection.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvInspection.Appearance.Row.Font = new Font("Cairo", 8.5F);
            gvInspection.Appearance.Row.Options.UseFont = true;
            gvInspection.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colInspectionDescription, colStatus, colNote, colDailyReportId, colCreatedDate, colCreatedMachine, colUpdateDate, colUpdateMachine, colIsDelete, colDeletionDate, colDeletionMachine, colCreatedBy, colUpdateBy, colDeletionBy });
            gvInspection.GridControl = gridInspection;
            gvInspection.Name = "gvInspection";
            gvInspection.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvInspection.OptionsView.ColumnAutoWidth = false;
            gvInspection.OptionsView.EnableAppearanceEvenRow = true;
            gvInspection.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gvInspection.OptionsView.ShowGroupPanel = false;
            gvInspection.ViewCaption = "الفحص والمراجعة";
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colInspectionDescription
            // 
            colInspectionDescription.Caption = "وصف الفحص";
            colInspectionDescription.FieldName = "InspectionDescription";
            colInspectionDescription.Name = "colInspectionDescription";
            colInspectionDescription.Visible = true;
            colInspectionDescription.VisibleIndex = 0;
            colInspectionDescription.Width = 400;
            // 
            // colStatus
            // 
            colStatus.Caption = "الحالة";
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 1;
            colStatus.Width = 150;
            // 
            // colNote
            // 
            colNote.Caption = "ملاحظات";
            colNote.FieldName = "Note";
            colNote.Name = "colNote";
            colNote.Visible = true;
            colNote.VisibleIndex = 2;
            colNote.Width = 300;
            // 
            // colDailyReportId
            // 
            colDailyReportId.FieldName = "DailyReportId";
            colDailyReportId.Name = "colDailyReportId";
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
            // colUpdateBy
            // 
            colUpdateBy.FieldName = "UpdateBy";
            colUpdateBy.Name = "colUpdateBy";
            // 
            // colDeletionBy
            // 
            colDeletionBy.FieldName = "DeletionBy";
            colDeletionBy.Name = "colDeletionBy";
            // 
            // ucInspection
            // 
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new Font("Cairo", 8.5F);
            Name = "ucInspection";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1280, 517);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridInspection).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvInspection).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridInspection;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInspection;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colInspectionDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyReportId;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionMachine;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDeletionBy;
    }
}
