using System.Drawing;
using System.Windows.Forms;

namespace Etmam
{
    partial class ucDailyStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDailyStaff));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiCopy = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            bar2 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            gridStaff = new DevExpress.XtraGrid.GridControl();
            gvStaff = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIsDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            colManpower = new DevExpress.XtraGrid.Columns.GridColumn();
            repoManpower = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colDailyReportId = new DevExpress.XtraGrid.Columns.GridColumn();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridStaff).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvStaff).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoManpower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar2 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = imageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiDelete, bbiCopy, barStaticItem1 });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 25;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 1;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiCopy, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(bbiDelete) });
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
            bbiAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiCopy
            // 
            bbiCopy.Caption = "جلب بيانات اليوم السابق";
            bbiCopy.Id = 23;
            bbiCopy.ImageOptions.ImageIndex = 9;
            bbiCopy.Name = "bbiCopy";
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 3;
            bbiDelete.ImageOptions.ImageIndex = 3;
            bbiDelete.Name = "bbiDelete";
            bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
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
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1280, 48);
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
            barDockControlLeft.Location = new Point(0, 48);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 469);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1280, 48);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 469);
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
            barStaticItem1.Caption = "عدد السجلات : 0";
            barStaticItem1.Id = 24;
            barStaticItem1.Name = "barStaticItem1";
            // 
            // gridStaff
            // 
            gridStaff.Dock = DockStyle.Fill;
            gridStaff.Location = new Point(2, 27);
            gridStaff.MainView = gvStaff;
            gridStaff.Name = "gridStaff";
            gridStaff.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoManpower });
            gridStaff.Size = new Size(1276, 440);
            gridStaff.TabIndex = 4;
            gridStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvStaff });
            // 
            // gvStaff
            // 
            gvStaff.Appearance.EvenRow.BackColor = Color.FromArgb(248, 249, 250);
            gvStaff.Appearance.EvenRow.Options.UseBackColor = true;
            gvStaff.Appearance.GroupPanel.Font = new Font("Cairo", 8.5F);
            gvStaff.Appearance.GroupPanel.Options.UseFont = true;
            gvStaff.Appearance.HeaderPanel.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            gvStaff.Appearance.HeaderPanel.ForeColor = Color.FromArgb(30, 70, 130);
            gvStaff.Appearance.HeaderPanel.Options.UseForeColor = true;
            gvStaff.Appearance.HeaderPanel.Options.UseFont = true;
            gvStaff.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvStaff.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvStaff.Appearance.Row.Font = new Font("Cairo", 8.5F);
            gvStaff.Appearance.Row.Options.UseFont = true;
            gvStaff.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIsDelete, colManpower, colQty, colDailyReportId, colId });
            gvStaff.GridControl = gridStaff;
            gvStaff.Name = "gvStaff";
            gvStaff.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvStaff.OptionsView.ColumnAutoWidth = false;
            gvStaff.OptionsView.EnableAppearanceEvenRow = true;
            gvStaff.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gvStaff.OptionsView.RowAutoHeight = true;
            gvStaff.OptionsView.ShowFooter = true;
            gvStaff.OptionsView.ShowGroupPanel = false;
            gvStaff.ViewCaption = "الطاقم الفني";
            // 
            // colIsDelete
            // 
            colIsDelete.FieldName = "IsDelete";
            colIsDelete.Name = "colIsDelete";
            // 
            // colManpower
            // 
            colManpower.Caption = "المهنة";
            colManpower.ColumnEdit = repoManpower;
            colManpower.FieldName = "ManpowerListId";
            colManpower.Name = "colManpower";
            colManpower.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colManpower.OptionsColumn.AllowMove = false;
            colManpower.Visible = true;
            colManpower.VisibleIndex = 0;
            colManpower.Width = 150;
            // 
            // repoManpower
            // 
            repoManpower.AutoHeight = false;
            repoManpower.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoManpower.Name = "repoManpower";
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
            colQty.Width = 85;
            // 
            // colDailyReportId
            // 
            colDailyReportId.FieldName = "Id";
            colDailyReportId.Name = "colDailyReportId";
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new Font("Cairo", 8.5F, FontStyle.Bold);
            groupControl1.AppearanceCaption.ForeColor = Color.FromArgb(30, 70, 130);
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseForeColor = true;
            groupControl1.Controls.Add(gridStaff);
            groupControl1.Dock = DockStyle.Fill;
            groupControl1.Location = new Point(0, 48);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(1280, 469);
            groupControl1.TabIndex = 9;
            groupControl1.Text = "الطاقم الفني";
            // 
            // ucDailyStaff
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Font = new System.Drawing.Font("Cairo", 8.5F);
            Name = "ucDailyStaff";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1280, 517);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridStaff).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvStaff).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoManpower).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        public DevExpress.XtraBars.BarButtonItem bbiCopy;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        public DevExpress.XtraGrid.GridControl gridStaff;
        public DevExpress.XtraGrid.Views.Grid.GridView gvStaff;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colManpower;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyReportId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoManpower;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDelete;
    }
}
