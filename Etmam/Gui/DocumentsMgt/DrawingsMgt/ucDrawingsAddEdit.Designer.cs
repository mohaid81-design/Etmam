namespace Etmam
{
    partial class ucDrawingsAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDrawingsAddEdit));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            gridControl = new DevExpress.XtraGrid.GridControl();
            gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colBuilding = new DevExpress.XtraGrid.Columns.GridColumn();
            colFloor = new DevExpress.XtraGrid.Columns.GridColumn();
            colNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colRev = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescrp = new DevExpress.XtraGrid.Columns.GridColumn();
            colConsultantDecision = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemComboBoxStatus = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            colReSubmittedRejectedItems = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colSigningCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            colConsultantNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBoxStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).BeginInit();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiAdd, bbiDelete });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 26;
            barManager1.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(bbiDelete) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // bbiAdd
            // 
            bbiAdd.Caption = "إضافة";
            bbiAdd.Id = 0;
            bbiAdd.ImageOptions.ImageIndex = 0;
            bbiAdd.Name = "bbiAdd";
            bbiAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiDelete
            // 
            bbiDelete.Caption = "حذف";
            bbiDelete.Id = 3;
            bbiDelete.ImageOptions.ImageIndex = 1;
            bbiDelete.Name = "bbiDelete";
            bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1349, 28);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 360);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1349, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 28);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 332);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1349, 28);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 332);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("actions_add", "image://svgimages/icon builder/actions_add.svg");
            svgImageCollection1.Add("Delete.svg", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.Delete.svg"));
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
            // gridControl
            // 
            gridControl.Dock = DockStyle.Fill;
            gridControl.Location = new Point(0, 28);
            gridControl.MainView = gridView;
            gridControl.Name = "gridControl";
            gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemComboBoxStatus, repositoryItemCheckEdit1 });
            gridControl.Size = new Size(1349, 332);
            gridControl.TabIndex = 0;
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
            // 
            // gridView
            // 
            gridView.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gridView.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gridView.Appearance.HeaderPanel.ForeColor = Color.Navy;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            gridView.Appearance.Row.Font = new Font("Cairo", 9F);
            gridView.Appearance.Row.Options.UseFont = true;
            gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colBuilding, colFloor, colNum, colRev, colDescrp, colConsultantDecision, colReSubmittedRejectedItems, colSigningCompleted, colConsultantNotes });
            gridView.DetailHeight = 349;
            gridView.GridControl = gridControl;
            gridView.Name = "gridView";
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colBuilding
            // 
            colBuilding.Caption = "المبنى";
            colBuilding.FieldName = "Building";
            colBuilding.Name = "colBuilding";
            colBuilding.Visible = true;
            colBuilding.VisibleIndex = 0;
            colBuilding.Width = 100;
            // 
            // colFloor
            // 
            colFloor.Caption = "الدور/ الطابق";
            colFloor.FieldName = "Floor";
            colFloor.Name = "colFloor";
            colFloor.Visible = true;
            colFloor.VisibleIndex = 1;
            colFloor.Width = 100;
            // 
            // colNum
            // 
            colNum.Caption = "رقم المخطط";
            colNum.FieldName = "DrawingNumber";
            colNum.Name = "colNum";
            colNum.Visible = true;
            colNum.VisibleIndex = 3;
            colNum.Width = 200;
            // 
            // colRev
            // 
            colRev.AppearanceCell.Options.UseTextOptions = true;
            colRev.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colRev.Caption = "الإصدارة";
            colRev.FieldName = "Revision";
            colRev.Name = "colRev";
            colRev.Visible = true;
            colRev.VisibleIndex = 4;
            colRev.Width = 70;
            // 
            // colDescrp
            // 
            colDescrp.Caption = "وصف المخطط";
            colDescrp.FieldName = "Description";
            colDescrp.Name = "colDescrp";
            colDescrp.Visible = true;
            colDescrp.VisibleIndex = 2;
            colDescrp.Width = 250;
            // 
            // colConsultantDecision
            // 
            colConsultantDecision.Caption = "قرار الإستشاري";
            colConsultantDecision.ColumnEdit = repositoryItemComboBoxStatus;
            colConsultantDecision.FieldName = "ConsultantDecision";
            colConsultantDecision.Name = "colConsultantDecision";
            colConsultantDecision.Visible = true;
            colConsultantDecision.VisibleIndex = 5;
            colConsultantDecision.Width = 80;
            // 
            // repositoryItemComboBoxStatus
            // 
            repositoryItemComboBoxStatus.AutoHeight = false;
            repositoryItemComboBoxStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBoxStatus.Items.AddRange(new object[] { "قيد المراجعة", "معتمد", "معتمد مع تحفظات", "مرفوض" });
            repositoryItemComboBoxStatus.Name = "repositoryItemComboBoxStatus";
            // 
            // colReSubmittedRejectedItems
            // 
            colReSubmittedRejectedItems.Caption = "هل تم أعادة التقديم للبنود المرفوضه";
            colReSubmittedRejectedItems.ColumnEdit = repositoryItemCheckEdit1;
            colReSubmittedRejectedItems.FieldName = "ReSubmittedRejectedItems";
            colReSubmittedRejectedItems.Name = "colReSubmittedRejectedItems";
            colReSubmittedRejectedItems.Visible = true;
            colReSubmittedRejectedItems.VisibleIndex = 7;
            colReSubmittedRejectedItems.Width = 100;
            // 
            // repositoryItemCheckEdit1
            // 
            repositoryItemCheckEdit1.AutoHeight = false;
            repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colSigningCompleted
            // 
            colSigningCompleted.Caption = "هل تم انهاء اجراء التوقيع على طلب الاعتماد";
            colSigningCompleted.ColumnEdit = repositoryItemCheckEdit1;
            colSigningCompleted.FieldName = "SigningCompleted";
            colSigningCompleted.Name = "colSigningCompleted";
            colSigningCompleted.Visible = true;
            colSigningCompleted.VisibleIndex = 8;
            colSigningCompleted.Width = 100;
            // 
            // colConsultantNotes
            // 
            colConsultantNotes.Caption = "ملاحظات الإستشاري";
            colConsultantNotes.FieldName = "ConsultantNotes";
            colConsultantNotes.Name = "colConsultantNotes";
            colConsultantNotes.Visible = true;
            colConsultantNotes.VisibleIndex = 6;
            colConsultantNotes.Width = 257;
            // 
            // ucDrawingsAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridControl);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new Padding(3, 5, 3, 5);
            Name = "ucDrawingsAddEdit";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1349, 360);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBoxStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colBuilding;
        private DevExpress.XtraGrid.Columns.GridColumn colFloor;
        private DevExpress.XtraGrid.Columns.GridColumn colNum;
        private DevExpress.XtraGrid.Columns.GridColumn colRev;
        private DevExpress.XtraGrid.Columns.GridColumn colDescrp;
        private DevExpress.XtraGrid.Columns.GridColumn colConsultantDecision;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colReSubmittedRejectedItems;
        private DevExpress.XtraGrid.Columns.GridColumn colSigningCompleted;
        private DevExpress.XtraGrid.Columns.GridColumn colConsultantNotes;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}
