namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucCorrespondenceArchiveSearch
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
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeArchive = new DevExpress.XtraTreeList.TreeList();
            this.colNodeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.pnlSearchHeader = new DevExpress.XtraEditors.PanelControl();
            this.txtFullText = new DevExpress.XtraEditors.TextEdit();
            this.txtSubject = new DevExpress.XtraEditors.TextEdit();
            this.txtReference = new DevExpress.XtraEditors.TextEdit();
            this.txtSender = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.grdSearchResults = new DevExpress.XtraGrid.GridControl();
            this.gvSearchResults = new DevExpress.XtraGrid.Views.Grid.GridView();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeArchive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchHeader)).BeginInit();
            this.pnlSearchHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearchResults)).BeginInit();
            this.SuspendLayout();

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.treeArchive);
            this.splitContainerControlMain.Panel1.Text = "شجرة أرشيف المراسلات والبريد";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdSearchResults);
            this.splitContainerControlMain.Panel2.Controls.Add(this.pnlSearchHeader);
            this.splitContainerControlMain.Panel2.Text = "محرك البحث والنتائج";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 750);
            this.splitContainerControlMain.SplitterPosition = 300;

            // treeArchive
            this.treeArchive.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { this.colNodeName });
            this.treeArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeArchive.Location = new System.Drawing.Point(0, 0);
            this.treeArchive.Name = "treeArchive";
            this.treeArchive.Size = new System.Drawing.Size(300, 750);

            this.colNodeName.Caption = "أرشيف المراسلات (السنوات/المشاريع)";
            this.colNodeName.FieldName = "NodeName";
            this.colNodeName.Visible = true;
            this.colNodeName.VisibleIndex = 0;

            // pnlSearchHeader
            this.pnlSearchHeader.Controls.Add(this.txtFullText);
            this.pnlSearchHeader.Controls.Add(this.txtSubject);
            this.pnlSearchHeader.Controls.Add(this.txtReference);
            this.pnlSearchHeader.Controls.Add(this.txtSender);
            this.pnlSearchHeader.Controls.Add(this.btnSearch);
            this.pnlSearchHeader.Controls.Add(this.btnClear);
            this.pnlSearchHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchHeader.Name = "pnlSearchHeader";
            this.pnlSearchHeader.Size = new System.Drawing.Size(890, 70);

            this.txtFullText.Location = new System.Drawing.Point(640, 20);
            this.txtFullText.Name = "txtFullText";
            this.txtFullText.Properties.NullValuePrompt = "البحث بالحرف والنص الكامل...";
            this.txtFullText.Size = new System.Drawing.Size(230, 30);

            this.txtSubject.Location = new System.Drawing.Point(440, 20);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Properties.NullValuePrompt = "الموضوع...";
            this.txtSubject.Size = new System.Drawing.Size(190, 30);

            this.txtReference.Location = new System.Drawing.Point(260, 20);
            this.txtReference.Name = "txtReference";
            this.txtReference.Properties.NullValuePrompt = "رقم المرجع...";
            this.txtReference.Size = new System.Drawing.Size(170, 30);

            this.txtSender.Location = new System.Drawing.Point(140, 20);
            this.txtSender.Name = "txtSender";
            this.txtSender.Properties.NullValuePrompt = "المرسل/المستلم...";
            this.txtSender.Size = new System.Drawing.Size(110, 30);

            this.btnSearch.Location = new System.Drawing.Point(70, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 30);
            this.btnSearch.Text = "بحث";

            this.btnClear.Location = new System.Drawing.Point(10, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 30);
            this.btnClear.Text = "مسح";

            // grdSearchResults
            this.grdSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResults.Location = new System.Drawing.Point(0, 70);
            this.grdSearchResults.MainView = this.gvSearchResults;
            this.grdSearchResults.Name = "grdSearchResults";
            this.grdSearchResults.Size = new System.Drawing.Size(890, 680);
            this.grdSearchResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvSearchResults });

            // gvSearchResults
            this.gvSearchResults.GridControl = this.grdSearchResults;
            this.gvSearchResults.Name = "gvSearchResults";
            this.gvSearchResults.OptionsView.ShowAutoFilterRow = true;
            this.gvSearchResults.OptionsView.ShowFooter = true;

            // ucCorrespondenceArchiveSearch
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "ucCorrespondenceArchiveSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeArchive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchHeader)).EndInit();
            this.pnlSearchHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFullText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearchResults)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraTreeList.TreeList treeArchive;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNodeName;
        private DevExpress.XtraEditors.PanelControl pnlSearchHeader;
        private DevExpress.XtraEditors.TextEdit txtFullText;
        private DevExpress.XtraEditors.TextEdit txtSubject;
        private DevExpress.XtraEditors.TextEdit txtReference;
        private DevExpress.XtraEditors.TextEdit txtSender;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraGrid.GridControl grdSearchResults;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSearchResults;
    }
}
