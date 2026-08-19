namespace Etmam.Gui.QualityMgt
{
    partial class ucPunchListManagement
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
            this.components = new System.ComponentModel.Container();
            this.barManagerMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barMain = new DevExpress.XtraBars.Bar();
            this.bbiNewItem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAssign = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseItem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdPunch = new DevExpress.XtraGrid.GridControl();
            this.gvPunch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPhotosGallery = new DevExpress.XtraTab.XtraTabControl();
            this.tpBefore = new DevExpress.XtraTab.XtraTabPage();
            this.tpAfter = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPhotosGallery)).BeginInit();
            this.tabPhotosGallery.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewItem, this.bbiAssign, this.bbiCloseItem, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewItem),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiAssign),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCloseItem),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات قائمة النواقص Punch List";

            this.bbiNewItem.Caption = "إضافة بند نواقص (New Punch Item)";
            this.bbiAssign.Caption = "تنسيب لمقاول/مسؤول";
            this.bbiCloseItem.Caption = "إغلاق البند ومعالجته";
            this.bbiPrint.Caption = "طباعة قائمة Punch List";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdPunch);
            this.splitContainerControlMain.Panel1.Text = "سجل نواقص المشروع المعتمدة";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabPhotosGallery);
            this.splitContainerControlMain.Panel2.Text = "معرض الصور قبل وبعد المعالجة (Before / After Gallery)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 450;

            // grdPunch
            this.grdPunch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPunch.Location = new System.Drawing.Point(0, 0);
            this.grdPunch.MainView = this.gvPunch;
            this.grdPunch.Name = "grdPunch";
            this.grdPunch.Size = new System.Drawing.Size(1200, 450);
            this.grdPunch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvPunch });

            // gvPunch
            this.gvPunch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colItemNo, this.colArea, this.colDescription,
                this.colPriority, this.colResponsible, this.colDueDate, this.colStatus
            });
            this.gvPunch.GridControl = this.grdPunch;
            this.gvPunch.Name = "gvPunch";
            this.gvPunch.OptionsView.ShowAutoFilterRow = true;
            this.gvPunch.OptionsView.ShowFooter = true;

            this.colItemNo.Caption = "رقم البند (Item No)";
            this.colItemNo.FieldName = "ItemNo";
            this.colItemNo.Visible = true;
            this.colItemNo.VisibleIndex = 0;

            this.colArea.Caption = "المنطقة / الموقع / الدور / الغرفة";
            this.colArea.FieldName = "Area";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 1;

            this.colDescription.Caption = "وصف النقيصة / الملاحظة (Description)";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;

            this.colPriority.Caption = "الأولوية (Priority)";
            this.colPriority.FieldName = "Priority";
            this.colPriority.Visible = true;
            this.colPriority.VisibleIndex = 3;

            this.colResponsible.Caption = "المسؤول عن التنفيذ والإصلاح";
            this.colResponsible.FieldName = "Responsible";
            this.colResponsible.Visible = true;
            this.colResponsible.VisibleIndex = 4;

            this.colDueDate.Caption = "تاريخ الإصلاح المطلوب";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 5;

            this.colStatus.Caption = "حالة البند (Open/Closed)";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;

            // tabPhotosGallery
            this.tabPhotosGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPhotosGallery.Location = new System.Drawing.Point(0, 0);
            this.tabPhotosGallery.Name = "tabPhotosGallery";
            this.tabPhotosGallery.SelectedTabPage = this.tpBefore;
            this.tabPhotosGallery.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpBefore,
                this.tpAfter
            });
            this.tabPhotosGallery.Size = new System.Drawing.Size(1200, 260);

            this.tpBefore.Text = "صور الحالة قبل المعالجة (Before Repair)";
            this.tpAfter.Text = "صور التعديل والـ Sign-Off بعد المعالجة (After Repair)";

            // ucPunchListManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucPunchListManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPhotosGallery)).EndInit();
            this.tabPhotosGallery.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewItem;
        private DevExpress.XtraBars.BarButtonItem bbiAssign;
        private DevExpress.XtraBars.BarButtonItem bbiCloseItem;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdPunch;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPunch;
        private DevExpress.XtraGrid.Columns.GridColumn colItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsible;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraTab.XtraTabControl tabPhotosGallery;
        private DevExpress.XtraTab.XtraTabPage tpBefore;
        private DevExpress.XtraTab.XtraTabPage tpAfter;
    }
}
