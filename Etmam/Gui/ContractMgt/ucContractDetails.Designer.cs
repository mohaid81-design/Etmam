namespace Etmam.Gui.ContractMgt
{
    partial class ucContractDetails
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
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblContractNo = new DevExpress.XtraEditors.LabelControl();
            this.lblProject = new DevExpress.XtraEditors.LabelControl();
            this.lblEmployer = new DevExpress.XtraEditors.LabelControl();
            this.lblContractor = new DevExpress.XtraEditors.LabelControl();
            this.lblContractType = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrency = new DevExpress.XtraEditors.LabelControl();
            this.lblOriginalValue = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrentValue = new DevExpress.XtraEditors.LabelControl();
            this.pnlSummaryCards = new DevExpress.XtraEditors.PanelControl();
            this.tabControlDetails = new DevExpress.XtraTab.XtraTabControl();
            this.tabGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.tabParties = new DevExpress.XtraTab.XtraTabPage();
            this.tabFinancial = new DevExpress.XtraTab.XtraTabPage();
            this.tabMilestones = new DevExpress.XtraTab.XtraTabPage();
            this.tabDocuments = new DevExpress.XtraTab.XtraTabPage();
            this.tabObligations = new DevExpress.XtraTab.XtraTabPage();
            this.tabVariations = new DevExpress.XtraTab.XtraTabPage();
            this.tabClaims = new DevExpress.XtraTab.XtraTabPage();
            this.tabPayments = new DevExpress.XtraTab.XtraTabPage();
            this.tabRetention = new DevExpress.XtraTab.XtraTabPage();
            this.tabGuarantees = new DevExpress.XtraTab.XtraTabPage();
            this.tabAudit = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSummaryCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlDetails)).BeginInit();
            this.tabControlDetails.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblContractNo);
            this.pnlHeader.Controls.Add(this.lblProject);
            this.pnlHeader.Controls.Add(this.lblEmployer);
            this.pnlHeader.Controls.Add(this.lblContractor);
            this.pnlHeader.Controls.Add(this.lblContractType);
            this.pnlHeader.Controls.Add(this.lblCurrency);
            this.pnlHeader.Controls.Add(this.lblOriginalValue);
            this.pnlHeader.Controls.Add(this.lblCurrentValue);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 80);

            this.lblContractNo.Appearance.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            this.lblContractNo.Location = new System.Drawing.Point(1000, 15);
            this.lblContractNo.Text = "رقم العقد: CNT-2026-001";

            this.lblProject.Location = new System.Drawing.Point(750, 15);
            this.lblProject.Text = "المشروع: مشروع الأبراج الكبرى";

            this.lblEmployer.Location = new System.Drawing.Point(550, 15);
            this.lblEmployer.Text = "صاحب العمل: وزارة الإسكان";

            this.lblContractor.Location = new System.Drawing.Point(350, 15);
            this.lblContractor.Text = "المقاول: شركة إتمام للمقاولات";

            this.lblContractType.Location = new System.Drawing.Point(1000, 45);
            this.lblContractType.Text = "نوع العقد: عقد رئيسي (Lump Sum)";

            this.lblCurrency.Location = new System.Drawing.Point(750, 45);
            this.lblCurrency.Text = "العملة: SAR";

            this.lblOriginalValue.Location = new System.Drawing.Point(550, 45);
            this.lblOriginalValue.Text = "القيمة الأصلية: 50,000,000 ر.س";

            this.lblCurrentValue.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCurrentValue.Location = new System.Drawing.Point(300, 45);
            this.lblCurrentValue.Text = "القيمة الحالية المعدلة: 54,200,000 ر.س";

            // pnlSummaryCards
            this.pnlSummaryCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummaryCards.Location = new System.Drawing.Point(0, 80);
            this.pnlSummaryCards.Name = "pnlSummaryCards";
            this.pnlSummaryCards.Size = new System.Drawing.Size(1200, 50);

            // tabControlDetails
            this.tabControlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDetails.Location = new System.Drawing.Point(0, 130);
            this.tabControlDetails.Name = "tabControlDetails";
            this.tabControlDetails.SelectedTabPage = this.tabGeneral;
            this.tabControlDetails.Size = new System.Drawing.Size(1200, 620);
            this.tabControlDetails.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tabGeneral, this.tabParties, this.tabFinancial, this.tabMilestones,
                this.tabDocuments, this.tabObligations, this.tabVariations, this.tabClaims,
                this.tabPayments, this.tabRetention, this.tabGuarantees, this.tabAudit
            });

            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Text = "بيانات عامة";

            this.tabParties.Name = "tabParties";
            this.tabParties.Text = "أطراف العقد";

            this.tabFinancial.Name = "tabFinancial";
            this.tabFinancial.Text = "المالية والأحكام";

            this.tabMilestones.Name = "tabMilestones";
            this.tabMilestones.Text = "المراحل والتأخيرات";

            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Text = "المستندات والمرفقات";

            this.tabObligations.Name = "tabObligations";
            this.tabObligations.Text = "الالتزامات والبنود";

            this.tabVariations.Name = "tabVariations";
            this.tabVariations.Text = "أوامر التغيير";

            this.tabClaims.Name = "tabClaims";
            this.tabClaims.Text = "المطالبات والنزاعات";

            this.tabPayments.Name = "tabPayments";
            this.tabPayments.Text = "المستخلصات والدفعات";

            this.tabRetention.Name = "tabRetention";
            this.tabRetention.Text = "إدارة المحتجزات";

            this.tabGuarantees.Name = "tabGuarantees";
            this.tabGuarantees.Text = "الخطابات والضمانات";

            this.tabAudit.Name = "tabAudit";
            this.tabAudit.Text = "سجل المراجعة والتغييرات";

            // ucContractDetails
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.tabControlDetails);
            this.Controls.Add(this.pnlSummaryCards);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucContractDetails";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSummaryCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlDetails)).EndInit();
            this.tabControlDetails.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblContractNo;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.LabelControl lblEmployer;
        private DevExpress.XtraEditors.LabelControl lblContractor;
        private DevExpress.XtraEditors.LabelControl lblContractType;
        private DevExpress.XtraEditors.LabelControl lblCurrency;
        private DevExpress.XtraEditors.LabelControl lblOriginalValue;
        private DevExpress.XtraEditors.LabelControl lblCurrentValue;
        private DevExpress.XtraEditors.PanelControl pnlSummaryCards;
        private DevExpress.XtraTab.XtraTabControl tabControlDetails;
        private DevExpress.XtraTab.XtraTabPage tabGeneral;
        private DevExpress.XtraTab.XtraTabPage tabParties;
        private DevExpress.XtraTab.XtraTabPage tabFinancial;
        private DevExpress.XtraTab.XtraTabPage tabMilestones;
        private DevExpress.XtraTab.XtraTabPage tabDocuments;
        private DevExpress.XtraTab.XtraTabPage tabObligations;
        private DevExpress.XtraTab.XtraTabPage tabVariations;
        private DevExpress.XtraTab.XtraTabPage tabClaims;
        private DevExpress.XtraTab.XtraTabPage tabPayments;
        private DevExpress.XtraTab.XtraTabPage tabRetention;
        private DevExpress.XtraTab.XtraTabPage tabGuarantees;
        private DevExpress.XtraTab.XtraTabPage tabAudit;
    }
}
