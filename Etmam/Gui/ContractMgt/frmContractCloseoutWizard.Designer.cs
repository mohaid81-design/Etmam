namespace Etmam.Gui.ContractMgt
{
    partial class frmContractCloseoutWizard
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.wizardControlCloseout = new DevExpress.XtraWizard.WizardControl();
            this.wpFinancialCloseout = new DevExpress.XtraWizard.WizardPage();
            this.wpFinalAccount = new DevExpress.XtraWizard.WizardPage();
            this.wpRetentionRelease = new DevExpress.XtraWizard.WizardPage();
            this.wpGuaranteesRelease = new DevExpress.XtraWizard.WizardPage();
            this.wpDocumentsArchive = new DevExpress.XtraWizard.WizardPage();
            this.wpLessonsLearned = new DevExpress.XtraWizard.WizardPage();
            this.wpFinalApproval = new DevExpress.XtraWizard.WizardPage();

            ((System.ComponentModel.ISupportInitialize)(this.wizardControlCloseout)).BeginInit();
            this.wizardControlCloseout.SuspendLayout();
            this.SuspendLayout();

            // wizardControlCloseout
            this.wizardControlCloseout.Controls.Add(this.wpFinancialCloseout);
            this.wizardControlCloseout.Controls.Add(this.wpFinalAccount);
            this.wizardControlCloseout.Controls.Add(this.wpRetentionRelease);
            this.wizardControlCloseout.Controls.Add(this.wpGuaranteesRelease);
            this.wizardControlCloseout.Controls.Add(this.wpDocumentsArchive);
            this.wizardControlCloseout.Controls.Add(this.wpLessonsLearned);
            this.wizardControlCloseout.Controls.Add(this.wpFinalApproval);
            this.wizardControlCloseout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControlCloseout.Location = new System.Drawing.Point(0, 0);
            this.wizardControlCloseout.Name = "wizardControlCloseout";
            this.wizardControlCloseout.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
                this.wpFinancialCloseout,
                this.wpFinalAccount,
                this.wpRetentionRelease,
                this.wpGuaranteesRelease,
                this.wpDocumentsArchive,
                this.wpLessonsLearned,
                this.wpFinalApproval
            });
            this.wizardControlCloseout.Size = new System.Drawing.Size(900, 600);

            // wpFinancialCloseout
            this.wpFinancialCloseout.DescriptionText = "مراجعة وتصفية المستخلصات والدفعات والمعاملات المالية النهائية";
            this.wpFinancialCloseout.Name = "wpFinancialCloseout";
            this.wpFinancialCloseout.Size = new System.Drawing.Size(868, 435);
            this.wpFinancialCloseout.Text = "الخطوة 1: التسوية المالية (Financial Closeout)";

            // wpFinalAccount
            this.wpFinalAccount.DescriptionText = "تطبيق الحساب النهائي وإقفال الفروقات والتسويات الشاملة";
            this.wpFinalAccount.Name = "wpFinalAccount";
            this.wpFinalAccount.Size = new System.Drawing.Size(868, 435);
            this.wpFinalAccount.Text = "الخطوة 2: الحساب النهائي للعقد (Final Account)";

            // wpRetentionRelease
            this.wpRetentionRelease.DescriptionText = "تسوية وموافقة الإفراج عن المبالغ المحتجزة لضمان الأعمال";
            this.wpRetentionRelease.Name = "wpRetentionRelease";
            this.wpRetentionRelease.Size = new System.Drawing.Size(868, 435);
            this.wpRetentionRelease.Text = "الخطوة 3: الإفراج عن المحتجزات (Retention Release)";

            // wpGuaranteesRelease
            this.wpGuaranteesRelease.DescriptionText = "إنهاء وتصفية الخطابات والضمانات البنكية وإعادتها للبنوك المصدرة";
            this.wpGuaranteesRelease.Name = "wpGuaranteesRelease";
            this.wpGuaranteesRelease.Size = new System.Drawing.Size(868, 435);
            this.wpGuaranteesRelease.Text = "الخطوة 4: تسوية الضمانات (Guarantees Release)";

            // wpDocumentsArchive
            this.wpDocumentsArchive.DescriptionText = "أرشفة كافة المخططات المنفذة وأدلة التشغيل والمخططات الصافية (As-Built)";
            this.wpDocumentsArchive.Name = "wpDocumentsArchive";
            this.wpDocumentsArchive.Size = new System.Drawing.Size(868, 435);
            this.wpDocumentsArchive.Text = "الخطوة 5: أرشفة المستندات (Documents Archive)";

            // wpLessonsLearned
            this.wpLessonsLearned.DescriptionText = "توثيق الدروس المستفادة وتقييم الأداء التعاقدي والتنفيذي للمشروع";
            this.wpLessonsLearned.Name = "wpLessonsLearned";
            this.wpLessonsLearned.Size = new System.Drawing.Size(868, 435);
            this.wpLessonsLearned.Text = "الخطوة 6: الدروس المستفادة (Lessons Learned)";

            // wpFinalApproval
            this.wpFinalApproval.DescriptionText = "توقيع شهادة الإغلاق النهائي للعقد وإصدار الاعتماد من الإدارة العامة";
            this.wpFinalApproval.Name = "wpFinalApproval";
            this.wpFinalApproval.Size = new System.Drawing.Size(868, 435);
            this.wpFinalApproval.Text = "الخطوة 7: الاعتماد النهائي وتوقيع الإغلاق (Final Approval)";

            // frmContractCloseoutWizard
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.wizardControlCloseout);
            this.Name = "frmContractCloseoutWizard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "معالج الإغلاق النهائي للعقد - Contract Closeout Wizard";

            ((System.ComponentModel.ISupportInitialize)(this.wizardControlCloseout)).EndInit();
            this.wizardControlCloseout.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControlCloseout;
        private DevExpress.XtraWizard.WizardPage wpFinancialCloseout;
        private DevExpress.XtraWizard.WizardPage wpFinalAccount;
        private DevExpress.XtraWizard.WizardPage wpRetentionRelease;
        private DevExpress.XtraWizard.WizardPage wpGuaranteesRelease;
        private DevExpress.XtraWizard.WizardPage wpDocumentsArchive;
        private DevExpress.XtraWizard.WizardPage wpLessonsLearned;
        private DevExpress.XtraWizard.WizardPage wpFinalApproval;
    }
}
