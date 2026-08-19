namespace Etmam.Gui.QualityMgt
{
    partial class ucNCRDetails
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
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlTimeline = new DevExpress.XtraEditors.PanelControl();
            this.lblIssue = new DevExpress.XtraEditors.LabelControl();
            this.lblInvestigation = new DevExpress.XtraEditors.LabelControl();
            this.lblCorrection = new DevExpress.XtraEditors.LabelControl();
            this.lblVerification = new DevExpress.XtraEditors.LabelControl();
            this.lblClosure = new DevExpress.XtraEditors.LabelControl();
            this.tabNcrDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tpGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.tpRootCause = new DevExpress.XtraTab.XtraTabPage();
            this.tpCorrectiveAction = new DevExpress.XtraTab.XtraTabPage();
            this.tpPreventiveAction = new DevExpress.XtraTab.XtraTabPage();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tpHistory = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeline)).BeginInit();
            this.pnlTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabNcrDetails)).BeginInit();
            this.tabNcrDetails.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiEditDetails, this.bbiPrintDetails
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditDetails),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrintDetails)
            });
            this.barMain.Text = "أدوات تفاصيل ومراحل NCR";

            this.bbiEditDetails.Caption = "تعديل تفاصيل التقرير";
            this.bbiPrintDetails.Caption = "طباعة بطاقة NCR ومرفقاتها";

            // pnlTimeline
            this.pnlTimeline.Controls.Add(this.lblIssue);
            this.pnlTimeline.Controls.Add(this.lblInvestigation);
            this.pnlTimeline.Controls.Add(this.lblCorrection);
            this.pnlTimeline.Controls.Add(this.lblVerification);
            this.pnlTimeline.Controls.Add(this.lblClosure);
            this.pnlTimeline.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimeline.Location = new System.Drawing.Point(0, 30);
            this.pnlTimeline.Name = "pnlTimeline";
            this.pnlTimeline.Size = new System.Drawing.Size(1200, 60);

            this.lblIssue.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblIssue.Location = new System.Drawing.Point(1000, 18);
            this.lblIssue.Text = "1. إصدار التقرير (Issue) ✔";

            this.lblInvestigation.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvestigation.Location = new System.Drawing.Point(780, 18);
            this.lblInvestigation.Text = "2. التحقيق (Investigation) ✔";

            this.lblCorrection.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblCorrection.Location = new System.Drawing.Point(560, 18);
            this.lblCorrection.Text = "3. المعالجة (Correction) ⏳";

            this.lblVerification.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.lblVerification.Location = new System.Drawing.Point(340, 18);
            this.lblVerification.Text = "4. التحقق والـ Re-Inspection";

            this.lblClosure.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.lblClosure.Location = new System.Drawing.Point(140, 18);
            this.lblClosure.Text = "5. الإغلاق (Closure)";

            // tabNcrDetails
            this.tabNcrDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabNcrDetails.Location = new System.Drawing.Point(0, 90);
            this.tabNcrDetails.Name = "tabNcrDetails";
            this.tabNcrDetails.SelectedTabPage = this.tpRootCause;
            this.tabNcrDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpGeneral,
                this.tpRootCause,
                this.tpCorrectiveAction,
                this.tpPreventiveAction,
                this.tpAttachments,
                this.tpWorkflow,
                this.tpHistory
            });
            this.tabNcrDetails.Size = new System.Drawing.Size(1200, 660);

            this.tpGeneral.Text = "البيانات العامة (General)";
            this.tpRootCause.Text = "تحليل السبب الجذر (Root Cause)";
            this.tpCorrectiveAction.Text = "الإجراء التصحيحي (Corrective Action)";
            this.tpPreventiveAction.Text = "الإجراء الوقائي (Preventive Action)";
            this.tpAttachments.Text = "المرفقات والصور (Attachments)";
            this.tpWorkflow.Text = "دورة الاعتماد والـ Sign-Off";
            this.tpHistory.Text = "تاريخ التعديلات (History)";

            // ucNCRDetails
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.tabNcrDetails);
            this.Controls.Add(this.pnlTimeline);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucNCRDetails";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeline)).EndInit();
            this.pnlTimeline.ResumeLayout(false);
            this.pnlTimeline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabNcrDetails)).EndInit();
            this.tabNcrDetails.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiEditDetails;
        private DevExpress.XtraBars.BarButtonItem bbiPrintDetails;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlTimeline;
        private DevExpress.XtraEditors.LabelControl lblIssue;
        private DevExpress.XtraEditors.LabelControl lblInvestigation;
        private DevExpress.XtraEditors.LabelControl lblCorrection;
        private DevExpress.XtraEditors.LabelControl lblVerification;
        private DevExpress.XtraEditors.LabelControl lblClosure;
        private DevExpress.XtraTab.XtraTabControl tabNcrDetails;
        private DevExpress.XtraTab.XtraTabPage tpGeneral;
        private DevExpress.XtraTab.XtraTabPage tpRootCause;
        private DevExpress.XtraTab.XtraTabPage tpCorrectiveAction;
        private DevExpress.XtraTab.XtraTabPage tpPreventiveAction;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraTab.XtraTabPage tpHistory;
    }
}
