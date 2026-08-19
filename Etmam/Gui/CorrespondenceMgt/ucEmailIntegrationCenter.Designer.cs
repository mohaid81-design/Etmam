namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucEmailIntegrationCenter
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
            this.bbiSyncOutlook = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLinkToProject = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClassify = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblSyncedToday = new DevExpress.XtraEditors.LabelControl();
            this.lblFailedSync = new DevExpress.XtraEditors.LabelControl();
            this.lblPendingClassification = new DevExpress.XtraEditors.LabelControl();
            this.lblLinkedEmails = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlOuter = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeMailbox = new DevExpress.XtraTreeList.TreeList();
            this.colFolderName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainerControlInner = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdEmails = new DevExpress.XtraGrid.GridControl();
            this.gvEmails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlEmailPreview = new DevExpress.XtraEditors.PanelControl();
            this.richEditEmailText = new DevExpress.XtraRichEdit.RichEditControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlOuter)).BeginInit();
            this.splitContainerControlOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMailbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlInner)).BeginInit();
            this.splitContainerControlInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmailPreview)).BeginInit();
            this.pnlEmailPreview.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiSyncOutlook, this.bbiLinkToProject, this.bbiClassify
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSyncOutlook),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiLinkToProject),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiClassify)
            });
            this.barMain.Text = "أدوات مركز تكامل البريد Outlook";

            this.bbiSyncOutlook.Caption = "مزامنة الآن من Outlook / Exchange";
            this.bbiLinkToProject.Caption = "ربط البريد بمشروع / عقد";
            this.bbiClassify.Caption = "تصنيف البريد كـ الوارد الرسمي";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblSyncedToday);
            this.pnlCards.Controls.Add(this.lblFailedSync);
            this.pnlCards.Controls.Add(this.lblPendingClassification);
            this.pnlCards.Controls.Add(this.lblLinkedEmails);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblSyncedToday.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSyncedToday.Location = new System.Drawing.Point(960, 15);
            this.lblSyncedToday.Text = "متزامن اليوم: 120 رسالة";

            this.lblFailedSync.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFailedSync.Location = new System.Drawing.Point(700, 15);
            this.lblFailedSync.Text = "فشل المزامنة: 0";

            this.lblPendingClassification.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPendingClassification.Location = new System.Drawing.Point(400, 15);
            this.lblPendingClassification.Text = "تنتظر التصنيف: 14";

            this.lblLinkedEmails.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLinkedEmails.Location = new System.Drawing.Point(120, 15);
            this.lblLinkedEmails.Text = "إيميلات مفسرة ومربوطة: 310";

            // splitContainerControlOuter
            this.splitContainerControlOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlOuter.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlOuter.Name = "splitContainerControlOuter";
            this.splitContainerControlOuter.Panel1.Controls.Add(this.treeMailbox);
            this.splitContainerControlOuter.Panel1.Text = "شجرة صناديق البريد الإلكتروني (Mailbox Tree)";
            this.splitContainerControlOuter.Panel2.Controls.Add(this.splitContainerControlInner);
            this.splitContainerControlOuter.Panel2.Text = "عرض الرسائل والمعاينة";
            this.splitContainerControlOuter.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlOuter.SplitterPosition = 280;

            // treeMailbox
            this.treeMailbox.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { this.colFolderName });
            this.treeMailbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMailbox.Location = new System.Drawing.Point(0, 0);
            this.treeMailbox.Name = "treeMailbox";
            this.treeMailbox.Size = new System.Drawing.Size(280, 670);

            this.colFolderName.Caption = "مجلد البريد (Outlook Folders)";
            this.colFolderName.FieldName = "FolderName";
            this.colFolderName.Visible = true;
            this.colFolderName.VisibleIndex = 0;

            // splitContainerControlInner
            this.splitContainerControlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlInner.Horizontal = false;
            this.splitContainerControlInner.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlInner.Name = "splitContainerControlInner";
            this.splitContainerControlInner.Panel1.Controls.Add(this.grdEmails);
            this.splitContainerControlInner.Panel1.Text = "جدول الرسائل";
            this.splitContainerControlInner.Panel2.Controls.Add(this.pnlEmailPreview);
            this.splitContainerControlInner.Panel2.Text = "معاينة الرسالة والمرفقات";
            this.splitContainerControlInner.Size = new System.Drawing.Size(910, 670);
            this.splitContainerControlInner.SplitterPosition = 350;

            // grdEmails
            this.grdEmails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmails.Location = new System.Drawing.Point(0, 0);
            this.grdEmails.MainView = this.gvEmails;
            this.grdEmails.Name = "grdEmails";
            this.grdEmails.Size = new System.Drawing.Size(910, 350);
            this.grdEmails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvEmails });

            // gvEmails
            this.gvEmails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colSubject, this.colFrom, this.colTo,
                this.colDate, this.colProject, this.colStatus
            });
            this.gvEmails.GridControl = this.grdEmails;
            this.gvEmails.Name = "gvEmails";
            this.gvEmails.OptionsView.ShowAutoFilterRow = true;
            this.gvEmails.OptionsView.ShowFooter = true;

            this.colSubject.Caption = "عنوان الإيميل (Subject)";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 0;

            this.colFrom.Caption = "من (From)";
            this.colFrom.FieldName = "From";
            this.colFrom.Visible = true;
            this.colFrom.VisibleIndex = 1;

            this.colTo.Caption = "إلى (To)";
            this.colTo.FieldName = "To";
            this.colTo.Visible = true;
            this.colTo.VisibleIndex = 2;

            this.colDate.Caption = "تاريخ وتوقيت البريد";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 3;

            this.colProject.Caption = "المشروع المربوط";
            this.colProject.FieldName = "Project";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 4;

            this.colStatus.Caption = "حالة التصنيف والتزامن";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // pnlEmailPreview
            this.pnlEmailPreview.Controls.Add(this.richEditEmailText);
            this.pnlEmailPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmailPreview.Location = new System.Drawing.Point(0, 0);
            this.pnlEmailPreview.Name = "pnlEmailPreview";
            this.pnlEmailPreview.Size = new System.Drawing.Size(910, 310);

            this.richEditEmailText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditEmailText.Location = new System.Drawing.Point(2, 2);
            this.richEditEmailText.Name = "richEditEmailText";
            this.richEditEmailText.Size = new System.Drawing.Size(906, 306);

            // ucEmailIntegrationCenter
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlOuter);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucEmailIntegrationCenter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlOuter)).EndInit();
            this.splitContainerControlOuter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMailbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlInner)).EndInit();
            this.splitContainerControlInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmailPreview)).EndInit();
            this.pnlEmailPreview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiSyncOutlook;
        private DevExpress.XtraBars.BarButtonItem bbiLinkToProject;
        private DevExpress.XtraBars.BarButtonItem bbiClassify;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblSyncedToday;
        private DevExpress.XtraEditors.LabelControl lblFailedSync;
        private DevExpress.XtraEditors.LabelControl lblPendingClassification;
        private DevExpress.XtraEditors.LabelControl lblLinkedEmails;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlOuter;
        private DevExpress.XtraTreeList.TreeList treeMailbox;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFolderName;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlInner;
        private DevExpress.XtraGrid.GridControl grdEmails;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmails;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colTo;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.PanelControl pnlEmailPreview;
        private DevExpress.XtraRichEdit.RichEditControl richEditEmailText;
    }
}
