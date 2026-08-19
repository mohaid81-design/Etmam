namespace Etmam.Gui.HSEMgt
{
    partial class ucIncidentInvestigation
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
            this.wizardInvestigation = new DevExpress.XtraWizard.WizardControl();
            this.wpDetails = new DevExpress.XtraWizard.WizardPage();
            this.lblStep1 = new DevExpress.XtraEditors.LabelControl();
            this.wpRootCause = new DevExpress.XtraWizard.WizardPage();
            this.tabAnalysisTools = new DevExpress.XtraTab.XtraTabControl();
            this.tp5Why = new DevExpress.XtraTab.XtraTabPage();
            this.tpFishbone = new DevExpress.XtraTab.XtraTabPage();
            this.tpTimeline = new DevExpress.XtraTab.XtraTabPage();
            this.wpEvidence = new DevExpress.XtraWizard.WizardPage();
            this.lblStep3 = new DevExpress.XtraEditors.LabelControl();
            this.wpCapa = new DevExpress.XtraWizard.WizardPage();
            this.lblStep4 = new DevExpress.XtraEditors.LabelControl();
            this.wpApproval = new DevExpress.XtraWizard.CompletionWizardPage();
            this.lblStep5 = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.wizardInvestigation)).BeginInit();
            this.wizardInvestigation.SuspendLayout();
            this.wpDetails.SuspendLayout();
            this.wpRootCause.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabAnalysisTools)).BeginInit();
            this.tabAnalysisTools.SuspendLayout();
            this.wpEvidence.SuspendLayout();
            this.wpCapa.SuspendLayout();
            this.wpApproval.SuspendLayout();
            this.SuspendLayout();

            // wizardInvestigation
            this.wizardInvestigation.Controls.Add(this.wpDetails);
            this.wizardInvestigation.Controls.Add(this.wpRootCause);
            this.wizardInvestigation.Controls.Add(this.wpEvidence);
            this.wizardInvestigation.Controls.Add(this.wpCapa);
            this.wizardInvestigation.Controls.Add(this.wpApproval);
            this.wizardInvestigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardInvestigation.Location = new System.Drawing.Point(0, 0);
            this.wizardInvestigation.Name = "wizardInvestigation";
            this.wizardInvestigation.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
                this.wpDetails,
                this.wpRootCause,
                this.wpEvidence,
                this.wpCapa,
                this.wpApproval
            });
            this.wizardInvestigation.Size = new System.Drawing.Size(1200, 750);
            this.wizardInvestigation.Text = "معالج وبوابات تحقيق أسباب الحوادث (Incident Investigation Wizard)";

            // wpDetails
            this.wpDetails.Controls.Add(this.lblStep1);
            this.wpDetails.Name = "wpDetails";
            this.wpDetails.Size = new System.Drawing.Size(1168, 605);
            this.wpDetails.Text = "الخطوة 1: مراجعة تفاصيل ومعطيات وقوع الحادث (Incident Details)";

            this.lblStep1.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep1.Location = new System.Drawing.Point(400, 200);
            this.lblStep1.Text = "تأكيد مكان وزمان وظروف الوقوع والأشخاص والمتأثرين بالحادث";

            // wpRootCause
            this.wpRootCause.Controls.Add(this.tabAnalysisTools);
            this.wpRootCause.Name = "wpRootCause";
            this.wpRootCause.Size = new System.Drawing.Size(1168, 605);
            this.wpRootCause.Text = "الخطوة 2: تحليل السبب الجذر (Root Cause Analysis - 5-Why & Fishbone)";

            // tabAnalysisTools
            this.tabAnalysisTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAnalysisTools.Location = new System.Drawing.Point(0, 0);
            this.tabAnalysisTools.Name = "tabAnalysisTools";
            this.tabAnalysisTools.SelectedTabPage = this.tp5Why;
            this.tabAnalysisTools.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tp5Why,
                this.tpFishbone,
                this.tpTimeline
            });
            this.tabAnalysisTools.Size = new System.Drawing.Size(1168, 605);

            this.tp5Why.Text = "تحليل الأسئلة الخمسة (5-Why Analysis)";
            this.tpFishbone.Text = "مخطط هيكل السمكة (Ishikawa Fishbone Diagram)";
            this.tpTimeline.Text = "تكتيك وتسلسل الوقائع (Chronological Timeline)";

            // wpEvidence
            this.wpEvidence.Controls.Add(this.lblStep3);
            this.wpEvidence.Name = "wpEvidence";
            this.wpEvidence.Size = new System.Drawing.Size(1168, 605);
            this.wpEvidence.Text = "الخطوة 3: توثيق الأدلة الميدانية والمرفقات والشهود (Evidence Collection)";

            this.lblStep3.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep3.Location = new System.Drawing.Point(420, 200);
            this.lblStep3.Text = "إرفاق صور المعاينة الميدانية وأقوال الشهود والتقارير الطبية الرسمية";

            // wpCapa
            this.wpCapa.Controls.Add(this.lblStep4);
            this.wpCapa.Name = "wpCapa";
            this.wpCapa.Size = new System.Drawing.Size(1168, 605);
            this.wpCapa.Text = "الخطوة 4: تحديد وتعيين الإجراءات التصحيحية والوقائية (Corrective Actions CAPA)";

            this.lblStep4.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep4.Location = new System.Drawing.Point(410, 200);
            this.lblStep4.Text = "إسناد مهام المعالجة ومنع التكرار للمسؤولين مع تحديد تواريخ الاستحقاق";

            // wpApproval
            this.wpApproval.Controls.Add(this.lblStep5);
            this.wpApproval.Name = "wpApproval";
            this.wpApproval.Size = new System.Drawing.Size(1168, 605);
            this.wpApproval.Text = "الخطوة 5: الاعتماد والتوقيع النهائي للجنة التحقيق (Investigation Approval)";

            this.lblStep5.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep5.Location = new System.Drawing.Point(390, 200);
            this.lblStep5.Text = "اعتماد التقرير النهائي من مدير السلامة ومدير المشروع وإرساله للجهات المختصة";

            // ucIncidentInvestigation
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.wizardInvestigation);
            this.Name = "ucIncidentInvestigation";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.wizardInvestigation)).EndInit();
            this.wizardInvestigation.ResumeLayout(false);
            this.wpDetails.ResumeLayout(false);
            this.wpDetails.PerformLayout();
            this.wpRootCause.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabAnalysisTools)).EndInit();
            this.tabAnalysisTools.ResumeLayout(false);
            this.wpEvidence.ResumeLayout(false);
            this.wpEvidence.PerformLayout();
            this.wpCapa.ResumeLayout(false);
            this.wpCapa.PerformLayout();
            this.wpApproval.ResumeLayout(false);
            this.wpApproval.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardInvestigation;
        private DevExpress.XtraWizard.WizardPage wpDetails;
        private DevExpress.XtraEditors.LabelControl lblStep1;
        private DevExpress.XtraWizard.WizardPage wpRootCause;
        private DevExpress.XtraTab.XtraTabControl tabAnalysisTools;
        private DevExpress.XtraTab.XtraTabPage tp5Why;
        private DevExpress.XtraTab.XtraTabPage tpFishbone;
        private DevExpress.XtraTab.XtraTabPage tpTimeline;
        private DevExpress.XtraWizard.WizardPage wpEvidence;
        private DevExpress.XtraEditors.LabelControl lblStep3;
        private DevExpress.XtraWizard.WizardPage wpCapa;
        private DevExpress.XtraEditors.LabelControl lblStep4;
        private DevExpress.XtraWizard.CompletionWizardPage wpApproval;
        private DevExpress.XtraEditors.LabelControl lblStep5;
    }
}
