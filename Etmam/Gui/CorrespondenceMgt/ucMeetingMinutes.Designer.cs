namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucMeetingMinutes
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
            this.bbiNewMeeting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApprove = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblMeetingNo = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.lblChairperson = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabMeetingMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpAttendees = new DevExpress.XtraTab.XtraTabPage();
            this.tpAgenda = new DevExpress.XtraTab.XtraTabPage();
            this.tpDecisions = new DevExpress.XtraTab.XtraTabPage();
            this.tpActionItems = new DevExpress.XtraTab.XtraTabPage();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.grdActionItems = new DevExpress.XtraGrid.GridControl();
            this.gvActionItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMeetingMain)).BeginInit();
            this.tabMeetingMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActionItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvActionItems)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewMeeting, this.bbiEdit, this.bbiApprove,
                this.bbiPrint, this.bbiExportPdf
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewMeeting),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEdit),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiApprove),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportPdf)
            });
            this.barMain.Text = "أدوات محاضر الاجتماعات";

            this.bbiNewMeeting.Caption = "محضر اجتماع جديد (New Meeting)";
            this.bbiEdit.Caption = "تعديل المحضر";
            this.bbiApprove.Caption = "اعتماد المحضر";
            this.bbiPrint.Caption = "طباعة المحضر";
            this.bbiExportPdf.Caption = "تصدير إلى PDF";

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblMeetingNo);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Controls.Add(this.lblLocation);
            this.pnlHeader.Controls.Add(this.lblChairperson);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 50);

            this.lblMeetingNo.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblMeetingNo.Location = new System.Drawing.Point(980, 15);
            this.lblMeetingNo.Text = "رقم الاجتماع: MOM-PRJ-2026-012";

            this.lblDate.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.lblDate.Location = new System.Drawing.Point(750, 15);
            this.lblDate.Text = "التاريخ: 2026-08-06 (10:00 AM)";

            this.lblLocation.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.lblLocation.Location = new System.Drawing.Point(480, 15);
            this.lblLocation.Text = "المكان: قاعة الاجتماعات الرئيسية - بالموقع";

            this.lblChairperson.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblChairperson.Location = new System.Drawing.Point(180, 15);
            this.lblChairperson.Text = "رئيس الاجتماع: Eng. Sultan (PM)";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.tabMeetingMain);
            this.splitContainerControlMain.Panel1.Text = "تبويبات بيانات ومحاور الاجتماع";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdActionItems);
            this.splitContainerControlMain.Panel2.Text = "جدول القرارات والتكليفات (Action Items)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 380;

            // tabMeetingMain
            this.tabMeetingMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMeetingMain.Location = new System.Drawing.Point(0, 0);
            this.tabMeetingMain.Name = "tabMeetingMain";
            this.tabMeetingMain.SelectedTabPage = this.tpAgenda;
            this.tabMeetingMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpAttendees,
                this.tpAgenda,
                this.tpDecisions,
                this.tpActionItems,
                this.tpAttachments,
                this.tpWorkflow
            });
            this.tabMeetingMain.Size = new System.Drawing.Size(1200, 380);

            this.tpAttendees.Text = "قائمة الحضور والغائبين (Attendees)";
            this.tpAgenda.Text = "جدول الأعمال والمحاور (Agenda)";
            this.tpDecisions.Text = "القرارات والتوصيات (Decisions)";
            this.tpActionItems.Text = "قائمة المهام (Action Items)";
            this.tpAttachments.Text = "المرفقات (Attachments)";
            this.tpWorkflow.Text = "اعتماد المحضر (Workflow)";

            // grdActionItems
            this.grdActionItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdActionItems.Location = new System.Drawing.Point(0, 0);
            this.grdActionItems.MainView = this.gvActionItems;
            this.grdActionItems.Name = "grdActionItems";
            this.grdActionItems.Size = new System.Drawing.Size(1200, 280);
            this.grdActionItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvActionItems });

            // gvActionItems
            this.gvActionItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colDescription, this.colResponsible, this.colDueDate, this.colStatus
            });
            this.gvActionItems.GridControl = this.grdActionItems;
            this.gvActionItems.Name = "gvActionItems";
            this.gvActionItems.OptionsView.ShowAutoFilterRow = true;
            this.gvActionItems.OptionsView.ShowFooter = true;

            this.colDescription.Caption = "وصف المهمة / القرار المنبثق (Description)";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;

            this.colResponsible.Caption = "المسؤول عن التنفيذ (Responsible)";
            this.colResponsible.FieldName = "Responsible";
            this.colResponsible.Visible = true;
            this.colResponsible.VisibleIndex = 1;

            this.colDueDate.Caption = "تاريخ الإنجاز المطلوب (Due Date)";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 2;

            this.colStatus.Caption = "حالة الإنجاز المباشرة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;

            // ucMeetingMinutes
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucMeetingMinutes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMeetingMain)).EndInit();
            this.tabMeetingMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActionItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvActionItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewMeeting;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiApprove;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExportPdf;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblMeetingNo;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.LabelControl lblChairperson;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraTab.XtraTabControl tabMeetingMain;
        private DevExpress.XtraTab.XtraTabPage tpAttendees;
        private DevExpress.XtraTab.XtraTabPage tpAgenda;
        private DevExpress.XtraTab.XtraTabPage tpDecisions;
        private DevExpress.XtraTab.XtraTabPage tpActionItems;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraGrid.GridControl grdActionItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvActionItems;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsible;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
