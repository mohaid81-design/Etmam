namespace Etmam.Gui.QualityMgt
{
    partial class ucHandoverInspection
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
            this.wizardHandover = new DevExpress.XtraWizard.WizardControl();
            this.wpArea = new DevExpress.XtraWizard.WizardPage();
            this.lblStep1 = new DevExpress.XtraEditors.LabelControl();
            this.wpChecklist = new DevExpress.XtraWizard.WizardPage();
            this.lblStep2 = new DevExpress.XtraEditors.LabelControl();
            this.wpPhotos = new DevExpress.XtraWizard.WizardPage();
            this.lblStep3 = new DevExpress.XtraEditors.LabelControl();
            this.wpPunchItems = new DevExpress.XtraWizard.WizardPage();
            this.lblStep4 = new DevExpress.XtraEditors.LabelControl();
            this.wpApproval = new DevExpress.XtraWizard.CompletionWizardPage();
            this.lblStep5 = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.wizardHandover)).BeginInit();
            this.wizardHandover.SuspendLayout();
            this.wpArea.SuspendLayout();
            this.wpChecklist.SuspendLayout();
            this.wpPhotos.SuspendLayout();
            this.wpPunchItems.SuspendLayout();
            this.wpApproval.SuspendLayout();
            this.SuspendLayout();

            // wizardHandover
            this.wizardHandover.Controls.Add(this.wpArea);
            this.wizardHandover.Controls.Add(this.wpChecklist);
            this.wizardHandover.Controls.Add(this.wpPhotos);
            this.wizardHandover.Controls.Add(this.wpPunchItems);
            this.wizardHandover.Controls.Add(this.wpApproval);
            this.wizardHandover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardHandover.Location = new System.Drawing.Point(0, 0);
            this.wizardHandover.Name = "wizardHandover";
            this.wizardHandover.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
                this.wpArea,
                this.wpChecklist,
                this.wpPhotos,
                this.wpPunchItems,
                this.wpApproval
            });
            this.wizardHandover.Size = new System.Drawing.Size(1200, 750);
            this.wizardHandover.Text = "معالج التسليم والتسلم النهائي (Handover Inspection Wizard)";

            // wpArea
            this.wpArea.Controls.Add(this.lblStep1);
            this.wpArea.Name = "wpArea";
            this.wpArea.Size = new System.Drawing.Size(1168, 605);
            this.wpArea.Text = "الخطوة 1: تحديد المنطقة والموقع والوحدة المُراد تسليمها (Area & Location)";

            this.lblStep1.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep1.Location = new System.Drawing.Point(400, 200);
            this.lblStep1.Text = "اختر المبنى / الدور / الشقة / النطاق الخاضع لفحص التسليم الابتدائي أو النهائي";

            // wpChecklist
            this.wpChecklist.Controls.Add(this.lblStep2);
            this.wpChecklist.Name = "wpChecklist";
            this.wpChecklist.Size = new System.Drawing.Size(1168, 605);
            this.wpChecklist.Text = "الخطوة 2: فحص بنود القائمة المرجعية المعتمدة (Handover Checklist)";

            this.lblStep2.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep2.Location = new System.Drawing.Point(420, 200);
            this.lblStep2.Text = "تحقق من معايير القبول والتشطيبات والأعمال المعمارية والكهروميكانيكية";

            // wpPhotos
            this.wpPhotos.Controls.Add(this.lblStep3);
            this.wpPhotos.Name = "wpPhotos";
            this.wpPhotos.Size = new System.Drawing.Size(1168, 605);
            this.wpPhotos.Text = "الخطوة 3: التوثيق البصري وإرفاق صور الاستلام (Site Photos)";

            this.lblStep3.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep3.Location = new System.Drawing.Point(450, 200);
            this.lblStep3.Text = "إرفاق صور الموقع وحالة التشطيب والتسليم الميداني";

            // wpPunchItems
            this.wpPunchItems.Controls.Add(this.lblStep4);
            this.wpPunchItems.Name = "wpPunchItems";
            this.wpPunchItems.Size = new System.Drawing.Size(1168, 605);
            this.wpPunchItems.Text = "الخطوة 4: تسجيل وقصر ملاحظات ونواقص التسليم (Punch Items)";

            this.lblStep4.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep4.Location = new System.Drawing.Point(430, 200);
            this.lblStep4.Text = "تحديد قائمة الملاحظات العاجلة المطلوب استكمالها من المقاول قبل التسليم";

            // wpApproval
            this.wpApproval.Controls.Add(this.lblStep5);
            this.wpApproval.Name = "wpApproval";
            this.wpApproval.Size = new System.Drawing.Size(1168, 605);
            this.wpApproval.Text = "الخطوة 5: التوقيع والاعتماد النهائي لشهادة الاستلام (Handover Approval)";

            this.lblStep5.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep5.Location = new System.Drawing.Point(410, 200);
            this.lblStep5.Text = "اعتماد شهادة التسليم واستصدار المحضر النهائي المعتمد من المالك والاستشاري";

            // ucHandoverInspection
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.wizardHandover);
            this.Name = "ucHandoverInspection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.wizardHandover)).EndInit();
            this.wizardHandover.ResumeLayout(false);
            this.wpArea.ResumeLayout(false);
            this.wpArea.PerformLayout();
            this.wpChecklist.ResumeLayout(false);
            this.wpChecklist.PerformLayout();
            this.wpPhotos.ResumeLayout(false);
            this.wpPhotos.PerformLayout();
            this.wpPunchItems.ResumeLayout(false);
            this.wpPunchItems.PerformLayout();
            this.wpApproval.ResumeLayout(false);
            this.wpApproval.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardHandover;
        private DevExpress.XtraWizard.WizardPage wpArea;
        private DevExpress.XtraEditors.LabelControl lblStep1;
        private DevExpress.XtraWizard.WizardPage wpChecklist;
        private DevExpress.XtraEditors.LabelControl lblStep2;
        private DevExpress.XtraWizard.WizardPage wpPhotos;
        private DevExpress.XtraEditors.LabelControl lblStep3;
        private DevExpress.XtraWizard.WizardPage wpPunchItems;
        private DevExpress.XtraEditors.LabelControl lblStep4;
        private DevExpress.XtraWizard.CompletionWizardPage wpApproval;
        private DevExpress.XtraEditors.LabelControl lblStep5;
    }
}
