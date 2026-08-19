using System.Drawing;
using System.Windows.Forms;

namespace Etmam
{
    partial class ucDrawingsLog
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDrawingsLog));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiNew = new DevExpress.XtraBars.BarButtonItem();
            bbiReIssue = new DevExpress.XtraBars.BarButtonItem();
            bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            bar2 = new DevExpress.XtraBars.Bar();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colType = new DevExpress.XtraGrid.Columns.GridColumn();
            colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            colSubCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            colNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colRev = new DevExpress.XtraGrid.Columns.GridColumn();
            colBuilding = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            colFloor = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescrp = new DevExpress.XtraGrid.Columns.GridColumn();
            colDrawingNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colApprovalStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colSubmissionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colActionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colActionDays = new DevExpress.XtraGrid.Columns.GridColumn();
            colConsultantDecision = new DevExpress.XtraGrid.Columns.GridColumn();
            colConsultantNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colReSubmittedRejectedItems = new DevExpress.XtraGrid.Columns.GridColumn();
            colSigningCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).BeginInit();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiNew, bbiReIssue, bbiEdit, bbiDelete, bbiRefresh, bbiPrint, barEditItem1, barButtonItem1 });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 23;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 1;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(bbiNew), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiReIssue, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(bbiEdit), new DevExpress.XtraBars.LinkPersistInfo(bbiDelete), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barEditItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu) });
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.OptionsBar.DrawDragBorder = false;
            bar1.OptionsBar.UseWholeRow = true;
            bar1.Text = "Tools";
            // 
            // bbiNew
            // 
            bbiNew.Caption = "جديد";
            bbiNew.Id = 0;
            bbiNew.ImageOptions.ImageIndex = 0;
            bbiNew.Name = "bbiNew";
            bbiNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiNew.ItemClick += bbiNew_ItemClick;
            // 
            // bbiReIssue
            // 
            bbiReIssue.Caption = "إعادة إصدار";
            bbiReIssue.Id = 1;
            bbiReIssue.ImageOptions.ImageIndex = 1;
            bbiReIssue.Name = "bbiReIssue";
            bbiReIssue.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // bbiEdit
            // 
            bbiEdit.Caption = "تعديل";
            bbiEdit.Id = 2;
            bbiEdit.ImageOptions.ImageIndex = 7;
            bbiEdit.Name = "bbiEdit";
            bbiEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 3;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.Name = "bbiDelete";
            bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // bbiRefresh
            // 
            bbiRefresh.Caption = "تحديث";
            bbiRefresh.Id = 4;
            bbiRefresh.ImageOptions.ImageIndex = 6;
            bbiRefresh.Name = "bbiRefresh";
            bbiRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // bbiPrint
            // 
            bbiPrint.Caption = "طباعة";
            bbiPrint.Id = 5;
            bbiPrint.ImageOptions.ImageIndex = 4;
            bbiPrint.Name = "bbiPrint";
            bbiPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "بحث";
            barButtonItem1.Id = 22;
            barButtonItem1.ImageOptions.ImageIndex = 8;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "بحث";
            barEditItem1.Edit = repositoryItemSearchControl1;
            barEditItem1.EditHeight = 25;
            barEditItem1.EditWidth = 250;
            barEditItem1.Id = 6;
            barEditItem1.Name = "barEditItem1";
            barEditItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemSearchControl1
            // 
            repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Repository.ClearButton(), new DevExpress.XtraEditors.Repository.SearchButton() });
            repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
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
            barDockControlTop.Size = new Size(1309, 51);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 649);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1309, 18);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 51);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 598);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1309, 51);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 598);
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
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 51);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemMemoEdit1 });
            gridControl1.Size = new Size(1309, 598);
            gridControl1.TabIndex = 9;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.Font = new Font("Cairo", 7.5F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colType, colCategory, colSubCategory, colNum, colRev, colBuilding, colFloor, colDescrp, colDrawingNum, colApprovalStatus, colSubmissionDate, colActionDate, colActionDays, colConsultantDecision, colConsultantNotes, colReSubmittedRejectedItems, colSigningCompleted });
            gridView1.DetailHeight = 349;
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colType
            // 
            colType.Caption = "نوع المخطط";
            colType.Name = "colType";
            colType.Visible = true;
            colType.VisibleIndex = 0;
            // 
            // colCategory
            // 
            colCategory.AppearanceCell.Options.UseTextOptions = true;
            colCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCategory.Caption = "تصنيف المخطط";
            colCategory.FieldName = "Category";
            colCategory.Name = "colCategory";
            colCategory.Visible = true;
            colCategory.VisibleIndex = 1;
            // 
            // colSubCategory
            // 
            colSubCategory.AppearanceCell.Options.UseTextOptions = true;
            colSubCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSubCategory.Caption = "التصنيف الثانوي";
            colSubCategory.FieldName = "SubCategory";
            colSubCategory.Name = "colSubCategory";
            colSubCategory.Visible = true;
            colSubCategory.VisibleIndex = 2;
            // 
            // colNum
            // 
            colNum.AppearanceCell.Options.UseTextOptions = true;
            colNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colNum.Caption = "رقم التقديم";
            colNum.FieldName = "Number";
            colNum.Name = "colNum";
            colNum.Visible = true;
            colNum.VisibleIndex = 3;
            // 
            // colRev
            // 
            colRev.AppearanceCell.Options.UseTextOptions = true;
            colRev.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colRev.Caption = "رقم الإصدارة";
            colRev.FieldName = "Revision";
            colRev.Name = "colRev";
            colRev.Visible = true;
            colRev.VisibleIndex = 4;
            // 
            // colBuilding
            // 
            colBuilding.Caption = "المبنى";
            colBuilding.ColumnEdit = repositoryItemMemoEdit1;
            colBuilding.FieldName = "MaterialName";
            colBuilding.Name = "colBuilding";
            colBuilding.Visible = true;
            colBuilding.VisibleIndex = 5;
            // 
            // repositoryItemMemoEdit1
            // 
            repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colFloor
            // 
            colFloor.Caption = "الطابق/الدور";
            colFloor.ColumnEdit = repositoryItemMemoEdit1;
            colFloor.FieldName = "Purpose";
            colFloor.Name = "colFloor";
            colFloor.Visible = true;
            colFloor.VisibleIndex = 6;
            // 
            // colDescrp
            // 
            colDescrp.Caption = "وصف المخطط";
            colDescrp.ColumnEdit = repositoryItemMemoEdit1;
            colDescrp.FieldName = "Manufacturer";
            colDescrp.Name = "colDescrp";
            colDescrp.Visible = true;
            colDescrp.VisibleIndex = 7;
            // 
            // colDrawingNum
            // 
            colDrawingNum.Caption = "رقم المخطط";
            colDrawingNum.Name = "colDrawingNum";
            colDrawingNum.Visible = true;
            colDrawingNum.VisibleIndex = 8;
            // 
            // colApprovalStatus
            // 
            colApprovalStatus.AppearanceCell.Options.UseTextOptions = true;
            colApprovalStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colApprovalStatus.Caption = "حالة الإعتماد";
            colApprovalStatus.FieldName = "ApprovalStatus";
            colApprovalStatus.Name = "colApprovalStatus";
            colApprovalStatus.Visible = true;
            colApprovalStatus.VisibleIndex = 9;
            // 
            // colSubmissionDate
            // 
            colSubmissionDate.AppearanceCell.Options.UseTextOptions = true;
            colSubmissionDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSubmissionDate.Caption = "تاريخ التقديم";
            colSubmissionDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            colSubmissionDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colSubmissionDate.FieldName = "SubmissionDate";
            colSubmissionDate.Name = "colSubmissionDate";
            colSubmissionDate.Visible = true;
            colSubmissionDate.VisibleIndex = 10;
            // 
            // colActionDate
            // 
            colActionDate.AppearanceCell.Options.UseTextOptions = true;
            colActionDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colActionDate.Caption = "تاريخ الإجراء";
            colActionDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            colActionDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colActionDate.FieldName = "ActionDate";
            colActionDate.Name = "colActionDate";
            colActionDate.Visible = true;
            colActionDate.VisibleIndex = 11;
            // 
            // colActionDays
            // 
            colActionDays.AppearanceCell.Options.UseTextOptions = true;
            colActionDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colActionDays.Caption = "عدد ايام الإجراء";
            colActionDays.FieldName = "ActionDays";
            colActionDays.Name = "colActionDays";
            colActionDays.Visible = true;
            colActionDays.VisibleIndex = 12;
            // 
            // colConsultantDecision
            // 
            colConsultantDecision.AppearanceCell.Options.UseTextOptions = true;
            colConsultantDecision.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colConsultantDecision.Caption = "قرار الإستشاري";
            colConsultantDecision.FieldName = "ConsultantDecision";
            colConsultantDecision.Name = "colConsultantDecision";
            colConsultantDecision.Visible = true;
            colConsultantDecision.VisibleIndex = 13;
            // 
            // colConsultantNotes
            // 
            colConsultantNotes.Caption = "ملاحظات الإستشاري";
            colConsultantNotes.ColumnEdit = repositoryItemMemoEdit1;
            colConsultantNotes.FieldName = "ConsultantNotes";
            colConsultantNotes.Name = "colConsultantNotes";
            colConsultantNotes.Visible = true;
            colConsultantNotes.VisibleIndex = 14;
            // 
            // colReSubmittedRejectedItems
            // 
            colReSubmittedRejectedItems.AppearanceCell.Options.UseTextOptions = true;
            colReSubmittedRejectedItems.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colReSubmittedRejectedItems.Caption = "هل تم أعادة التقديم للبنود المرفوضه";
            colReSubmittedRejectedItems.FieldName = "ReSubmittedRejectedItems";
            colReSubmittedRejectedItems.Name = "colReSubmittedRejectedItems";
            colReSubmittedRejectedItems.Visible = true;
            colReSubmittedRejectedItems.VisibleIndex = 15;
            // 
            // colSigningCompleted
            // 
            colSigningCompleted.AppearanceCell.Options.UseTextOptions = true;
            colSigningCompleted.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colSigningCompleted.Caption = "هل تم انهاء اجراء التوقيع على طلب الاعتماد";
            colSigningCompleted.FieldName = "SigningCompleted";
            colSigningCompleted.Name = "colSigningCompleted";
            colSigningCompleted.Visible = true;
            colSigningCompleted.VisibleIndex = 16;
            // 
            // ucDrawingsLog
            // 
            Appearance.Font = new Font("Cairo", 8.5F);
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ucDrawingsLog";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1309, 667);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiReIssue;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colNum;
        private DevExpress.XtraGrid.Columns.GridColumn colRev;
        private DevExpress.XtraGrid.Columns.GridColumn colBuilding;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colFloor;
        private DevExpress.XtraGrid.Columns.GridColumn colDescrp;
        private DevExpress.XtraGrid.Columns.GridColumn colDrawingNum;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovalStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSubmissionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDays;
        private DevExpress.XtraGrid.Columns.GridColumn colConsultantDecision;
        private DevExpress.XtraGrid.Columns.GridColumn colConsultantNotes;
        private DevExpress.XtraGrid.Columns.GridColumn colReSubmittedRejectedItems;
        private DevExpress.XtraGrid.Columns.GridColumn colSigningCompleted;
    }
}

