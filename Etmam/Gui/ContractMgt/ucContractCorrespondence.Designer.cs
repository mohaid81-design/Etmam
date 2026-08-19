namespace Etmam.Gui.ContractMgt
{
    partial class ucContractCorrespondence
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
            this.bbiNewLetter = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReply = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLinkDoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdLetters = new DevExpress.XtraGrid.GridControl();
            this.gvLetters = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLetterNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlSub = new DevExpress.XtraTab.XtraTabControl();
            this.tabAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tabWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tabHistory = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLetters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLetters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlSub)).BeginInit();
            this.tabControlSub.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewLetter, this.bbiReply, this.bbiLinkDoc, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewLetter),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiReply),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiLinkDoc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات المراسلات";

            this.bbiNewLetter.Caption = "خطاب جديد";
            this.bbiReply.Caption = "رد على خطاب";
            this.bbiLinkDoc.Caption = "ربط بالمستندات";
            this.bbiPrint.Caption = "طباعة الخطاب";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdLetters);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabControlSub);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 450;

            // grdLetters
            this.grdLetters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLetters.Location = new System.Drawing.Point(0, 0);
            this.grdLetters.MainView = this.gvLetters;
            this.grdLetters.Name = "grdLetters";
            this.grdLetters.Size = new System.Drawing.Size(1200, 450);
            this.grdLetters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvLetters });

            // gvLetters
            this.gvLetters.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colLetterNo, this.colReference, this.colSubject, this.colSender,
                this.colReceiver, this.colDate, this.colStatus
            });
            this.gvLetters.GridControl = this.grdLetters;
            this.gvLetters.Name = "gvLetters";

            this.colLetterNo.Caption = "رقم الخطاب";
            this.colLetterNo.FieldName = "LetterNo";
            this.colLetterNo.Visible = true;
            this.colLetterNo.VisibleIndex = 0;

            this.colReference.Caption = "المرجع الإشاري";
            this.colReference.FieldName = "Reference";
            this.colReference.Visible = true;
            this.colReference.VisibleIndex = 1;

            this.colSubject.Caption = "موضوع الخطاب";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 2;

            this.colSender.Caption = "الراسل";
            this.colSender.FieldName = "Sender";
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 3;

            this.colReceiver.Caption = "المرسل إليه";
            this.colReceiver.FieldName = "Receiver";
            this.colReceiver.Visible = true;
            this.colReceiver.VisibleIndex = 4;

            this.colDate.Caption = "تاريخ الإرسال / الاستلام";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 5;

            this.colStatus.Caption = "حالة المعاملة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;

            // tabControlSub
            this.tabControlSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSub.Location = new System.Drawing.Point(0, 0);
            this.tabControlSub.Name = "tabControlSub";
            this.tabControlSub.SelectedTabPage = this.tabAttachments;
            this.tabControlSub.Size = new System.Drawing.Size(1200, 260);
            this.tabControlSub.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tabAttachments, this.tabWorkflow, this.tabHistory
            });

            this.tabAttachments.Name = "tabAttachments";
            this.tabAttachments.Text = "المرفقات والملفات";

            this.tabWorkflow.Name = "tabWorkflow";
            this.tabWorkflow.Text = "مسار الاعتماد والتحويلات";

            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Text = "سجل الإجراءات";

            // ucContractCorrespondence
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucContractCorrespondence";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLetters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLetters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlSub)).EndInit();
            this.tabControlSub.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewLetter;
        private DevExpress.XtraBars.BarButtonItem bbiReply;
        private DevExpress.XtraBars.BarButtonItem bbiLinkDoc;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdLetters;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLetters;
        private DevExpress.XtraGrid.Columns.GridColumn colLetterNo;
        private DevExpress.XtraGrid.Columns.GridColumn colReference;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiver;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraTab.XtraTabControl tabControlSub;
        private DevExpress.XtraTab.XtraTabPage tabAttachments;
        private DevExpress.XtraTab.XtraTabPage tabWorkflow;
        private DevExpress.XtraTab.XtraTabPage tabHistory;
    }
}
