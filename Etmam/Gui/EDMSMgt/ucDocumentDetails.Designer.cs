namespace Etmam.Gui.EDMSMgt
{
    partial class ucDocumentDetails
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
            this.lblDocNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblDiscipline = new DevExpress.XtraEditors.LabelControl();
            this.lblProject = new DevExpress.XtraEditors.LabelControl();
            this.lblRevision = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.tpMetadata = new DevExpress.XtraTab.XtraTabPage();
            this.tpRevisions = new DevExpress.XtraTab.XtraTabPage();
            this.tpWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tpDistribution = new DevExpress.XtraTab.XtraTabPage();
            this.tpAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tpLinkedRecords = new DevExpress.XtraTab.XtraTabPage();
            this.tpHistory = new DevExpress.XtraTab.XtraTabPage();
            this.tpAudit = new DevExpress.XtraTab.XtraTabPage();
            this.layoutMetadata = new DevExpress.XtraLayout.LayoutControl();
            this.txtDiscipline = new DevExpress.XtraEditors.TextEdit();
            this.txtClassification = new DevExpress.XtraEditors.TextEdit();
            this.txtOriginator = new DevExpress.XtraEditors.TextEdit();
            this.txtReviewer = new DevExpress.XtraEditors.TextEdit();
            this.txtApprover = new DevExpress.XtraEditors.TextEdit();
            this.txtKeywords = new DevExpress.XtraEditors.TextEdit();
            this.txtRetentionCategory = new DevExpress.XtraEditors.TextEdit();
            this.RootMetadata = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemDiscipline = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemClassification = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemOriginator = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemReviewer = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemApprover = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemKeywords = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemRetention = new DevExpress.XtraLayout.LayoutControlItem();

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMetadata)).BeginInit();
            this.layoutMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscipline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassification.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReviewer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApprover.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeywords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetentionCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootMetadata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDiscipline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemClassification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemOriginator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemReviewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemApprover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemKeywords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRetention)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblDocNumber);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblDiscipline);
            this.pnlHeader.Controls.Add(this.lblProject);
            this.pnlHeader.Controls.Add(this.lblRevision);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);

            this.lblDocNumber.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblDocNumber.Location = new System.Drawing.Point(1000, 15);
            this.lblDocNumber.Text = "الرقم: DWG-CIV-2026-004";

            this.lblTitle.Appearance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(700, 15);
            this.lblTitle.Text = "العنوان: مخططات الخرسانة المسلحة للأساسات";

            this.lblDiscipline.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.lblDiscipline.Location = new System.Drawing.Point(520, 15);
            this.lblDiscipline.Text = "التخصص: مدني الإنشائي";

            this.lblProject.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F);
            this.lblProject.Location = new System.Drawing.Point(320, 15);
            this.lblProject.Text = "المشروع: مشروع المجمع التجاري";

            this.lblRevision.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRevision.Location = new System.Drawing.Point(180, 15);
            this.lblRevision.Text = "الإصدار: Rev-B";

            this.lblStatus.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(40, 15);
            this.lblStatus.Text = "الحالة: Approved with Comments";

            // tabMain
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 60);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpGeneral;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tpGeneral,
                this.tpMetadata,
                this.tpRevisions,
                this.tpWorkflow,
                this.tpDistribution,
                this.tpAttachments,
                this.tpLinkedRecords,
                this.tpHistory,
                this.tpAudit
            });
            this.tabMain.Size = new System.Drawing.Size(1200, 690);

            this.tpGeneral.Text = "البيانات العامة (General)";
            this.tpMetadata.Controls.Add(this.layoutMetadata);
            this.tpMetadata.Text = "الخصائص والبيانات الوصفية (Metadata)";
            this.tpRevisions.Text = "سجل الإصدارات (Revisions)";
            this.tpWorkflow.Text = "سير الاعتماد والعمل (Workflow)";
            this.tpDistribution.Text = "مصفوفة التوزيع (Distribution)";
            this.tpAttachments.Text = "الملفات والمرفقات (Attachments)";
            this.tpLinkedRecords.Text = "السجلات المرتبطة (Linked Records)";
            this.tpHistory.Text = "التاريخ والنشاط (History)";
            this.tpAudit.Text = "سجل التدقيق (Audit Trail)";

            // layoutMetadata
            this.layoutMetadata.Controls.Add(this.txtDiscipline);
            this.layoutMetadata.Controls.Add(this.txtClassification);
            this.layoutMetadata.Controls.Add(this.txtOriginator);
            this.layoutMetadata.Controls.Add(this.txtReviewer);
            this.layoutMetadata.Controls.Add(this.txtApprover);
            this.layoutMetadata.Controls.Add(this.txtKeywords);
            this.layoutMetadata.Controls.Add(this.txtRetentionCategory);
            this.layoutMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMetadata.Location = new System.Drawing.Point(0, 0);
            this.layoutMetadata.Name = "layoutMetadata";
            this.layoutMetadata.Root = this.RootMetadata;
            this.layoutMetadata.Size = new System.Drawing.Size(1198, 655);

            this.RootMetadata.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.RootMetadata.GroupBordersVisible = false;
            this.RootMetadata.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemDiscipline,
                this.layoutItemClassification,
                this.layoutItemOriginator,
                this.layoutItemReviewer,
                this.layoutItemApprover,
                this.layoutItemKeywords,
                this.layoutItemRetention
            });

            this.layoutItemDiscipline.Control = this.txtDiscipline;
            this.layoutItemDiscipline.Name = "layoutItemDiscipline";
            this.layoutItemDiscipline.Size = new System.Drawing.Size(1178, 40);
            this.layoutItemDiscipline.Text = "التخصص الهندسي (Discipline)";

            this.layoutItemClassification.Control = this.txtClassification;
            this.layoutItemClassification.Name = "layoutItemClassification";
            this.layoutItemClassification.Size = new System.Drawing.Size(1178, 40);
            this.layoutItemClassification.Text = "التصنيف الأمني/الفني (Classification)";

            this.layoutItemOriginator.Control = this.txtOriginator;
            this.layoutItemOriginator.Name = "layoutItemOriginator";
            this.layoutItemOriginator.Size = new System.Drawing.Size(1178, 40);
            this.layoutItemOriginator.Text = "الجهة المُنشئة (Originator)";

            this.layoutItemReviewer.Control = this.txtReviewer;
            this.layoutItemReviewer.Name = "layoutItemReviewer";
            this.layoutItemReviewer.Size = new System.Drawing.Size(1178, 40);
            this.layoutItemReviewer.Text = "المُراجع الهندسي (Reviewer)";

            this.layoutItemApprover.Control = this.txtApprover;
            this.layoutItemApprover.Name = "layoutItemApprover";
            this.layoutItemApprover.Size = new System.Drawing.Size(1178, 40);
            this.layoutItemApprover.Text = "الاعتماد النهائي (Approver)";

            this.layoutItemKeywords.Control = this.txtKeywords;
            this.layoutItemKeywords.Name = "layoutItemKeywords";
            this.layoutItemKeywords.Size = new System.Drawing.Size(1178, 40);
            this.layoutItemKeywords.Text = "الكلمات المفتاحية (Keywords)";

            this.layoutItemRetention.Control = this.txtRetentionCategory;
            this.layoutItemRetention.Name = "layoutItemRetention";
            this.layoutItemRetention.Size = new System.Drawing.Size(1178, 395);
            this.layoutItemRetention.Text = "فئة الحفظ والأرشفة (Retention Category)";

            // ucDocumentDetails
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucDocumentDetails";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpMetadata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutMetadata)).EndInit();
            this.layoutMetadata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscipline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassification.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReviewer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApprover.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeywords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetentionCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RootMetadata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDiscipline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemClassification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemOriginator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemReviewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemApprover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemKeywords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemRetention)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblDocNumber;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblDiscipline;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.LabelControl lblRevision;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpGeneral;
        private DevExpress.XtraTab.XtraTabPage tpMetadata;
        private DevExpress.XtraTab.XtraTabPage tpRevisions;
        private DevExpress.XtraTab.XtraTabPage tpWorkflow;
        private DevExpress.XtraTab.XtraTabPage tpDistribution;
        private DevExpress.XtraTab.XtraTabPage tpAttachments;
        private DevExpress.XtraTab.XtraTabPage tpLinkedRecords;
        private DevExpress.XtraTab.XtraTabPage tpHistory;
        private DevExpress.XtraTab.XtraTabPage tpAudit;
        private DevExpress.XtraLayout.LayoutControl layoutMetadata;
        private DevExpress.XtraEditors.TextEdit txtDiscipline;
        private DevExpress.XtraEditors.TextEdit txtClassification;
        private DevExpress.XtraEditors.TextEdit txtOriginator;
        private DevExpress.XtraEditors.TextEdit txtReviewer;
        private DevExpress.XtraEditors.TextEdit txtApprover;
        private DevExpress.XtraEditors.TextEdit txtKeywords;
        private DevExpress.XtraEditors.TextEdit txtRetentionCategory;
        private DevExpress.XtraLayout.LayoutControlGroup RootMetadata;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDiscipline;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemClassification;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemOriginator;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemReviewer;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemApprover;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemKeywords;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemRetention;
    }
}
