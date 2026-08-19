namespace Etmam.Gui.QualityMgt
{
    partial class ucInspectionForm
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
            this.lblIrNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblActivity = new DevExpress.XtraEditors.LabelControl();
            this.lblWbs = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.lblConsultant = new DevExpress.XtraEditors.LabelControl();
            this.tabFormMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.tpChecklist = new DevExpress.XtraTab.XtraTabPage();
            this.tpMeasurements = new DevExpress.XtraTab.XtraTabPage();
            this.tpPhotos = new DevExpress.XtraTab.XtraTabPage();
            this.tpDocuments = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tpHistory = new DevExpress.XtraTab.XtraTabPage();
            this.pnlBottomResult = new DevExpress.XtraEditors.PanelControl();
            this.lblResultTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnPass = new DevExpress.XtraEditors.SimpleButton();
            this.btnConditionalPass = new DevExpress.XtraEditors.SimpleButton();
            this.btnFail = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormMain)).BeginInit();
            this.tabFormMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottomResult)).BeginInit();
            this.pnlBottomResult.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblIrNumber);
            this.pnlHeader.Controls.Add(this.lblActivity);
            this.pnlHeader.Controls.Add(this.lblWbs);
            this.pnlHeader.Controls.Add(this.lblLocation);
            this.pnlHeader.Controls.Add(this.lblConsultant);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 55);

            this.lblIrNumber.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblIrNumber.Location = new System.Drawing.Point(960, 15);
            this.lblIrNumber.Text = "رقم الفحص: IR-CIV-2026-049";

            this.lblActivity.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.lblActivity.Location = new System.Drawing.Point(680, 15);
            this.lblActivity.Text = "النشاط: تسليح ونجارة سقف الدور الأرضي";

            this.lblWbs.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.lblWbs.Location = new System.Drawing.Point(480, 15);
            this.lblWbs.Text = "WBS: 1.2.4.1";

            this.lblLocation.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.lblLocation.Location = new System.Drawing.Point(280, 15);
            this.lblLocation.Text = "الموقع: برج A - الدور 01 - محاور C4-C8";

            this.lblConsultant.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblConsultant.Location = new System.Drawing.Point(60, 15);
            this.lblConsultant.Text = "الاستشاري: Khatib & Alami";

            // tabFormMain
            this.tabFormMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormMain.Location = new System.Drawing.Point(0, 55);
            this.tabFormMain.Name = "tabFormMain";
            this.tabFormMain.SelectedTabPage = this.tpChecklist;
            this.tabFormMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpGeneral,
                this.tpChecklist,
                this.tpMeasurements,
                this.tpPhotos,
                this.tpDocuments,
                this.tpWorkflow,
                this.tpHistory
            });
            this.tabFormMain.Size = new System.Drawing.Size(1200, 635);

            this.tpGeneral.Text = "البيانات العامة (General)";
            this.tpChecklist.Text = "القائمة المرجعية ومعايير القبول (Checklist)";
            this.tpMeasurements.Text = "القياسات والاختبارات الفيلد (Measurements)";
            this.tpPhotos.Text = "معرض صور الفحص والموقع (Photos)";
            this.tpDocuments.Text = "الوثائق والرسومات المرتبطة (Documents)";
            this.tpWorkflow.Text = "سير اعتماد نموذج الفحص (Workflow)";
            this.tpHistory.Text = "سجل الإرجاعات والإعادات (History)";

            // pnlBottomResult
            this.pnlBottomResult.Controls.Add(this.lblResultTitle);
            this.pnlBottomResult.Controls.Add(this.btnPass);
            this.pnlBottomResult.Controls.Add(this.btnConditionalPass);
            this.pnlBottomResult.Controls.Add(this.btnFail);
            this.pnlBottomResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomResult.Location = new System.Drawing.Point(0, 690);
            this.pnlBottomResult.Name = "pnlBottomResult";
            this.pnlBottomResult.Size = new System.Drawing.Size(1200, 60);

            this.lblResultTitle.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblResultTitle.Location = new System.Drawing.Point(1000, 18);
            this.lblResultTitle.Text = "قرار الفحص النهائي (Inspection Result):";

            this.btnPass.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPass.Location = new System.Drawing.Point(820, 12);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(150, 36);
            this.btnPass.Text = "مقبول معتمد (Pass) ✔";

            this.btnConditionalPass.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConditionalPass.Location = new System.Drawing.Point(620, 12);
            this.btnConditionalPass.Name = "btnConditionalPass";
            this.btnConditionalPass.Size = new System.Drawing.Size(180, 36);
            this.btnConditionalPass.Text = "مقبول بملاحظات (Conditional)";

            this.btnFail.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnFail.Location = new System.Drawing.Point(440, 12);
            this.btnFail.Name = "btnFail";
            this.btnFail.Size = new System.Drawing.Size(160, 36);
            this.btnFail.Text = "مرفوض (Fail) ✖";

            // ucInspectionForm
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.tabFormMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBottomResult);
            this.Name = "ucInspectionForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormMain)).EndInit();
            this.tabFormMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottomResult)).EndInit();
            this.pnlBottomResult.ResumeLayout(false);
            this.pnlBottomResult.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblIrNumber;
        private DevExpress.XtraEditors.LabelControl lblActivity;
        private DevExpress.XtraEditors.LabelControl lblWbs;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.LabelControl lblConsultant;
        private DevExpress.XtraTab.XtraTabControl tabFormMain;
        private DevExpress.XtraTab.XtraTabPage tpGeneral;
        private DevExpress.XtraTab.XtraTabPage tpChecklist;
        private DevExpress.XtraTab.XtraTabPage tpMeasurements;
        private DevExpress.XtraTab.XtraTabPage tpPhotos;
        private DevExpress.XtraTab.XtraTabPage tpDocuments;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraTab.XtraTabPage tpHistory;
        private DevExpress.XtraEditors.PanelControl pnlBottomResult;
        private DevExpress.XtraEditors.LabelControl lblResultTitle;
        private DevExpress.XtraEditors.SimpleButton btnPass;
        private DevExpress.XtraEditors.SimpleButton btnConditionalPass;
        private DevExpress.XtraEditors.SimpleButton btnFail;
    }
}
