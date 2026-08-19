namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucCorrespondenceDetails
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
            this.bbiEditDetails = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrintDetails = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblReference = new DevExpress.XtraEditors.LabelControl();
            this.lblSubject = new DevExpress.XtraEditors.LabelControl();
            this.lblProject = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblPriority = new DevExpress.XtraEditors.LabelControl();
            this.tabDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tpGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tpLinkedRecords = new DevExpress.XtraTab.XtraTabPage();
            this.tpDistribution = new DevExpress.XtraTab.XtraTabPage();
            this.tpActions = new DevExpress.XtraTab.XtraTabPage();
            this.tpHistory = new DevExpress.XtraTab.XtraTabPage();
            this.tpAudit = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabDetails)).BeginInit();
            this.tabDetails.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiEditDetails, this.bbiPrintDetails, this.bbiExportPdf
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditDetails),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrintDetails),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportPdf)
            });
            this.barMain.Text = "أدوات تفاصيل المراسلة";

            this.bbiEditDetails.Caption = "تعديل البيانات العامة";
            this.bbiPrintDetails.Caption = "طباعة بطاقة المراسلة";
            this.bbiExportPdf.Caption = "تصدير إلى PDF";

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblReference);
            this.pnlHeader.Controls.Add(this.lblSubject);
            this.pnlHeader.Controls.Add(this.lblProject);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Controls.Add(this.lblPriority);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 55);

            this.lblReference.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblReference.Location = new System.Drawing.Point(950, 15);
            this.lblReference.Text = "المرجع: COR-2026-00892";

            this.lblSubject.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.lblSubject.Location = new System.Drawing.Point(620, 15);
            this.lblSubject.Text = "الموضوع: إشعار استلام المخططات المحدثة وتحديد موعد الفحص";

            this.lblProject.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.lblProject.Location = new System.Drawing.Point(400, 15);
            this.lblProject.Text = "المشروع: برج الرياض التجاري";

            this.lblStatus.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(220, 15);
            this.lblStatus.Text = "الحالة: معتمدة وموزعة";

            this.lblPriority.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPriority.Location = new System.Drawing.Point(60, 15);
            this.lblPriority.Text = "الأولوية: عادية";

            // tabDetails
            this.tabDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetails.Location = new System.Drawing.Point(0, 85);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.SelectedTabPage = this.tpGeneral;
            this.tabDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpGeneral,
                this.tpAttachments,
                this.tpWorkflow,
                this.tpLinkedRecords,
                this.tpDistribution,
                this.tpActions,
                this.tpHistory,
                this.tpAudit
            });
            this.tabDetails.Size = new System.Drawing.Size(1200, 665);

            this.tpGeneral.Text = "البيانات العامة (General)";
            this.tpAttachments.Text = "المرفقات والوثائق (Attachments)";
            this.tpWorkflow.Text = "مسار الاعتماد (Workflow)";
            this.tpLinkedRecords.Text = "السجلات المرتبطة (Linked Records)";
            this.tpDistribution.Text = "قائمة التوزيع (Distribution)";
            this.tpActions.Text = "التكليفات والإجراءات (Actions)";
            this.tpHistory.Text = "التاريخ والإصدارات (History)";
            this.tpAudit.Text = "سجل التدقيق (Audit Trail)";

            // ucCorrespondenceDetails
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.tabDetails);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucCorrespondenceDetails";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabDetails)).EndInit();
            this.tabDetails.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiEditDetails;
        private DevExpress.XtraBars.BarButtonItem bbiPrintDetails;
        private DevExpress.XtraBars.BarButtonItem bbiExportPdf;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblReference;
        private DevExpress.XtraEditors.LabelControl lblSubject;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl lblPriority;
        private DevExpress.XtraTab.XtraTabControl tabDetails;
        private DevExpress.XtraTab.XtraTabPage tpGeneral;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraTab.XtraTabPage tpLinkedRecords;
        private DevExpress.XtraTab.XtraTabPage tpDistribution;
        private DevExpress.XtraTab.XtraTabPage tpActions;
        private DevExpress.XtraTab.XtraTabPage tpHistory;
        private DevExpress.XtraTab.XtraTabPage tpAudit;
    }
}
