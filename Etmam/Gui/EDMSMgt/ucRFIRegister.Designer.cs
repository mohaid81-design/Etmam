namespace Etmam.Gui.EDMSMgt
{
    partial class ucRFIRegister
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
            this.bbiNewRFI = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditRFI = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblOpenRFI = new DevExpress.XtraEditors.LabelControl();
            this.lblAnsweredRFI = new DevExpress.XtraEditors.LabelControl();
            this.lblOverdueRFI = new DevExpress.XtraEditors.LabelControl();
            this.lblClosedRFI = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdRFI = new DevExpress.XtraGrid.GridControl();
            this.gvRFI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRfiNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRaisedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignedTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysOutstanding = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabRfiDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tpResponses = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tpLinkedDrawings = new DevExpress.XtraTab.XtraTabPage();
            this.tpLinkedNCR = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRFI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRFI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabRfiDetails)).BeginInit();
            this.tabRfiDetails.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewRFI, this.bbiEditRFI, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewRFI),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditRFI),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات سجل طلبات الاستفسارات الفنية RFI";

            this.bbiNewRFI.Caption = "تقديم طلب استفسار (RFI جديد)";
            this.bbiEditRFI.Caption = "تعديل الطلب";
            this.bbiPrint.Caption = "طباعة سجل الاستفسارات";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblOpenRFI);
            this.pnlCards.Controls.Add(this.lblAnsweredRFI);
            this.pnlCards.Controls.Add(this.lblOverdueRFI);
            this.pnlCards.Controls.Add(this.lblClosedRFI);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblOpenRFI.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOpenRFI.Location = new System.Drawing.Point(1000, 15);
            this.lblOpenRFI.Text = "استفسارات مفتوحة (Open RFIs): 12";

            this.lblAnsweredRFI.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAnsweredRFI.Location = new System.Drawing.Point(700, 15);
            this.lblAnsweredRFI.Text = "تمت الإجابة عنها (Answered): 38";

            this.lblOverdueRFI.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOverdueRFI.Location = new System.Drawing.Point(420, 15);
            this.lblOverdueRFI.Text = "استفسارات متأخرة (Overdue): 4";

            this.lblClosedRFI.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClosedRFI.Location = new System.Drawing.Point(180, 15);
            this.lblClosedRFI.Text = "مغلقة نهائياً (Closed): 85";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdRFI);
            this.splitContainerControlMain.Panel1.Text = "سجل طلبات RFI";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabRfiDetails);
            this.splitContainerControlMain.Panel2.Text = "الردود والتفاصيل";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerControlMain.SplitterPosition = 400;

            // grdRFI
            this.grdRFI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRFI.Location = new System.Drawing.Point(0, 0);
            this.grdRFI.MainView = this.gvRFI;
            this.grdRFI.Name = "grdRFI";
            this.grdRFI.Size = new System.Drawing.Size(1200, 400);
            this.grdRFI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvRFI });

            // gvRFI
            this.gvRFI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colRfiNo, this.colSubject, this.colDiscipline,
                this.colRaisedBy, this.colAssignedTo, this.colDueDate,
                this.colDaysOutstanding, this.colStatus
            });
            this.gvRFI.GridControl = this.grdRFI;
            this.gvRFI.Name = "gvRFI";
            this.gvRFI.OptionsView.ShowAutoFilterRow = true;
            this.gvRFI.OptionsView.ShowFooter = true;

            this.colRfiNo.Caption = "رقم الطلب (RFI No)";
            this.colRfiNo.FieldName = "RfiNo";
            this.colRfiNo.Visible = true;
            this.colRfiNo.VisibleIndex = 0;

            this.colSubject.Caption = "موضوع الاستفسار الفني";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;

            this.colDiscipline.Caption = "التخصص الهندسي";
            this.colDiscipline.FieldName = "Discipline";
            this.colDiscipline.Visible = true;
            this.colDiscipline.VisibleIndex = 2;

            this.colRaisedBy.Caption = "الجهة المُقدمة للطلب";
            this.colRaisedBy.FieldName = "RaisedBy";
            this.colRaisedBy.Visible = true;
            this.colRaisedBy.VisibleIndex = 3;

            this.colAssignedTo.Caption = "المسؤول عن الإجابة";
            this.colAssignedTo.FieldName = "AssignedTo";
            this.colAssignedTo.Visible = true;
            this.colAssignedTo.VisibleIndex = 4;

            this.colDueDate.Caption = "تاريخ الاستحقاق";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 5;

            this.colDaysOutstanding.Caption = "الأيام المعلقة";
            this.colDaysOutstanding.FieldName = "DaysOutstanding";
            this.colDaysOutstanding.Visible = true;
            this.colDaysOutstanding.VisibleIndex = 6;

            this.colStatus.Caption = "حالة الاستفسار";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 7;

            // tabRfiDetails
            this.tabRfiDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRfiDetails.Location = new System.Drawing.Point(0, 0);
            this.tabRfiDetails.Name = "tabRfiDetails";
            this.tabRfiDetails.SelectedTabPage = this.tpResponses;
            this.tabRfiDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpAttachments,
                this.tpResponses,
                this.tpWorkflow,
                this.tpLinkedDrawings,
                this.tpLinkedNCR
            });
            this.tabRfiDetails.Size = new System.Drawing.Size(1200, 260);

            this.tpAttachments.Text = "المرفقات (Attachments)";
            this.tpResponses.Text = "إجابات الاستشاري والردود (Responses)";
            this.tpWorkflow.Text = "دورة الاعتماد (Workflow)";
            this.tpLinkedDrawings.Text = "المخططات والرسومات المرتبطة (Linked Drawings)";
            this.tpLinkedNCR.Text = "تقارير عدم المطابقة المرتبطة (Linked NCR)";

            // ucRFIRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucRFIRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRFI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRFI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabRfiDetails)).EndInit();
            this.tabRfiDetails.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewRFI;
        private DevExpress.XtraBars.BarButtonItem bbiEditRFI;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblOpenRFI;
        private DevExpress.XtraEditors.LabelControl lblAnsweredRFI;
        private DevExpress.XtraEditors.LabelControl lblOverdueRFI;
        private DevExpress.XtraEditors.LabelControl lblClosedRFI;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdRFI;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRFI;
        private DevExpress.XtraGrid.Columns.GridColumn colRfiNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn colRaisedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignedTo;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysOutstanding;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraTab.XtraTabControl tabRfiDetails;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraTab.XtraTabPage tpResponses;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraTab.XtraTabPage tpLinkedDrawings;
        private DevExpress.XtraTab.XtraTabPage tpLinkedNCR;
    }
}
