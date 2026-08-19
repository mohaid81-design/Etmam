namespace Etmam.Gui.QualityMgt
{
    partial class ucChecklistLibrary
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
            this.bbiNewChecklist = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCopy = new DevExpress.XtraBars.BarButtonItem();
            this.bbiVersion = new DevExpress.XtraBars.BarButtonItem();
            this.bbiArchive = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdChecklists = new DevExpress.XtraGrid.GridControl();
            this.gvChecklists = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChecklist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcceptanceCriteria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemStandard = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChecklists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewChecklist, this.bbiCopy, this.bbiVersion, this.bbiArchive
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewChecklist),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiCopy),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiVersion),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiArchive)
            });
            this.barMain.Text = "أدوات مكتبة القوائم المرجعية";

            this.bbiNewChecklist.Caption = "قائمة مرجعية جديدة (New Checklist)";
            this.bbiCopy.Caption = "نسخ القائمة";
            this.bbiVersion.Caption = "إصدار مراجعة (Revision)";
            this.bbiArchive.Caption = "أرشفة النموذج";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdChecklists);
            this.splitContainerControlMain.Panel1.Text = "سجل القوائم المرجعية المعتمدة";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdItems);
            this.splitContainerControlMain.Panel2.Text = "بنود الفحص ومعايير القبول (Checklist Items & Acceptance Criteria)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 380;

            // grdChecklists
            this.grdChecklists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChecklists.Location = new System.Drawing.Point(0, 0);
            this.grdChecklists.MainView = this.gvChecklists;
            this.grdChecklists.Name = "grdChecklists";
            this.grdChecklists.Size = new System.Drawing.Size(1200, 380);
            this.grdChecklists.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvChecklists });

            // gvChecklists
            this.gvChecklists.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colChecklist, this.colDiscipline, this.colRevision, this.colStatus
            });
            this.gvChecklists.GridControl = this.grdChecklists;
            this.gvChecklists.Name = "gvChecklists";
            this.gvChecklists.OptionsView.ShowAutoFilterRow = true;
            this.gvChecklists.OptionsView.ShowFooter = true;

            this.colChecklist.Caption = "اسم القائمة المرجعية (Checklist Name)";
            this.colChecklist.FieldName = "Checklist";
            this.colChecklist.Visible = true;
            this.colChecklist.VisibleIndex = 0;

            this.colDiscipline.Caption = "التخصص الهندي التابع";
            this.colDiscipline.FieldName = "Discipline";
            this.colDiscipline.Visible = true;
            this.colDiscipline.VisibleIndex = 1;

            this.colRevision.Caption = "رقم الإصدار (Revision)";
            this.colRevision.FieldName = "Revision";
            this.colRevision.Visible = true;
            this.colRevision.VisibleIndex = 2;

            this.colStatus.Caption = "حالة الاعتماد";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;

            // grdItems
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.Location = new System.Drawing.Point(0, 0);
            this.grdItems.MainView = this.gvItems;
            this.grdItems.Name = "grdItems";
            this.grdItems.Size = new System.Drawing.Size(1200, 330);
            this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvItems });

            // gvItems
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colItemDescription, this.colAcceptanceCriteria, this.colItemStandard
            });
            this.gvItems.GridControl = this.grdItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsView.ShowAutoFilterRow = true;

            this.colItemDescription.Caption = "وصف بند الفحص (Item Description)";
            this.colItemDescription.FieldName = "ItemDescription";
            this.colItemDescription.Visible = true;
            this.colItemDescription.VisibleIndex = 0;

            this.colAcceptanceCriteria.Caption = "معيار القبول المطلوب (Acceptance Criteria)";
            this.colAcceptanceCriteria.FieldName = "AcceptanceCriteria";
            this.colAcceptanceCriteria.Visible = true;
            this.colAcceptanceCriteria.VisibleIndex = 1;

            this.colItemStandard.Caption = "الكود المرجعي التابع";
            this.colItemStandard.FieldName = "ItemStandard";
            this.colItemStandard.Visible = true;
            this.colItemStandard.VisibleIndex = 2;

            // ucChecklistLibrary
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucChecklistLibrary";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecklists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChecklists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewChecklist;
        private DevExpress.XtraBars.BarButtonItem bbiCopy;
        private DevExpress.XtraBars.BarButtonItem bbiVersion;
        private DevExpress.XtraBars.BarButtonItem bbiArchive;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdChecklists;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChecklists;
        private DevExpress.XtraGrid.Columns.GridColumn colChecklist;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn colRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.GridControl grdItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn colItemDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAcceptanceCriteria;
        private DevExpress.XtraGrid.Columns.GridColumn colItemStandard;
    }
}
