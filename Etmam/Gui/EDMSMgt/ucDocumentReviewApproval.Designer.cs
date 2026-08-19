namespace Etmam.Gui.EDMSMgt
{
    partial class ucDocumentReviewApproval
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
            this.pnlWorkflowTimeline = new DevExpress.XtraEditors.PanelControl();
            this.lblStepDraft = new DevExpress.XtraEditors.LabelControl();
            this.lblStepInternalReview = new DevExpress.XtraEditors.LabelControl();
            this.lblStepPmReview = new DevExpress.XtraEditors.LabelControl();
            this.lblStepConsultantReview = new DevExpress.XtraEditors.LabelControl();
            this.lblStepClientApproval = new DevExpress.XtraEditors.LabelControl();
            this.lblStepReleased = new DevExpress.XtraEditors.LabelControl();
            this.pnlActionButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnReject = new DevExpress.XtraEditors.SimpleButton();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelegate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddComment = new DevExpress.XtraEditors.SimpleButton();
            this.grdReviewMatrix = new DevExpress.XtraGrid.GridControl();
            this.gvReviewMatrix = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReviewer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkflowTimeline)).BeginInit();
            this.pnlWorkflowTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).BeginInit();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReviewMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReviewMatrix)).BeginInit();
            this.SuspendLayout();

            // pnlWorkflowTimeline
            this.pnlWorkflowTimeline.Controls.Add(this.lblStepDraft);
            this.pnlWorkflowTimeline.Controls.Add(this.lblStepInternalReview);
            this.pnlWorkflowTimeline.Controls.Add(this.lblStepPmReview);
            this.pnlWorkflowTimeline.Controls.Add(this.lblStepConsultantReview);
            this.pnlWorkflowTimeline.Controls.Add(this.lblStepClientApproval);
            this.pnlWorkflowTimeline.Controls.Add(this.lblStepReleased);
            this.pnlWorkflowTimeline.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWorkflowTimeline.Location = new System.Drawing.Point(0, 0);
            this.pnlWorkflowTimeline.Name = "pnlWorkflowTimeline";
            this.pnlWorkflowTimeline.Size = new System.Drawing.Size(1200, 60);

            this.lblStepDraft.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepDraft.Location = new System.Drawing.Point(1050, 18);
            this.lblStepDraft.Text = "[1] مسودة (Draft)";

            this.lblStepInternalReview.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepInternalReview.Location = new System.Drawing.Point(850, 18);
            this.lblStepInternalReview.Text = "➔ [2] مراجعة داخلية";

            this.lblStepPmReview.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepPmReview.Location = new System.Drawing.Point(650, 18);
            this.lblStepPmReview.Text = "➔ [3] مراجعة مدير المشروع";

            this.lblStepConsultantReview.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepConsultantReview.Location = new System.Drawing.Point(430, 18);
            this.lblStepConsultantReview.Text = "➔ [4] مراجعة الاستشاري";

            this.lblStepClientApproval.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepClientApproval.Location = new System.Drawing.Point(230, 18);
            this.lblStepClientApproval.Text = "➔ [5] اعتماد المالك";

            this.lblStepReleased.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepReleased.Location = new System.Drawing.Point(50, 18);
            this.lblStepReleased.Text = "➔ [6] إصدار نهائي (Released)";

            // pnlActionButtons
            this.pnlActionButtons.Controls.Add(this.btnApprove);
            this.pnlActionButtons.Controls.Add(this.btnReject);
            this.pnlActionButtons.Controls.Add(this.btnReturn);
            this.pnlActionButtons.Controls.Add(this.btnDelegate);
            this.pnlActionButtons.Controls.Add(this.btnAddComment);
            this.pnlActionButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 60);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(1200, 50);

            this.btnApprove.Location = new System.Drawing.Point(1050, 10);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(120, 32);
            this.btnApprove.Text = "اعتماد (Approve)";

            this.btnReject.Location = new System.Drawing.Point(910, 10);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(120, 32);
            this.btnReject.Text = "رفض (Reject)";

            this.btnReturn.Location = new System.Drawing.Point(750, 10);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(140, 32);
            this.btnReturn.Text = "إعادة للتعديل (Return)";

            this.btnDelegate.Location = new System.Drawing.Point(590, 10);
            this.btnDelegate.Name = "btnDelegate";
            this.btnDelegate.Size = new System.Drawing.Size(140, 32);
            this.btnDelegate.Text = "تفويض مراجع (Delegate)";

            this.btnAddComment.Location = new System.Drawing.Point(420, 10);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(150, 32);
            this.btnAddComment.Text = "إضافة ملاحظة فنية";

            // grdReviewMatrix
            this.grdReviewMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReviewMatrix.Location = new System.Drawing.Point(0, 110);
            this.grdReviewMatrix.MainView = this.gvReviewMatrix;
            this.grdReviewMatrix.Name = "grdReviewMatrix";
            this.grdReviewMatrix.Size = new System.Drawing.Size(1200, 640);
            this.grdReviewMatrix.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvReviewMatrix });

            // gvReviewMatrix
            this.gvReviewMatrix.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colReviewer, this.colAction, this.colDate, this.colComment
            });
            this.gvReviewMatrix.GridControl = this.grdReviewMatrix;
            this.gvReviewMatrix.Name = "gvReviewMatrix";
            this.gvReviewMatrix.OptionsView.ShowAutoFilterRow = true;
            this.gvReviewMatrix.OptionsView.ShowFooter = true;

            this.colReviewer.Caption = "اسم المراجع والصفة الوظيفية (Reviewer)";
            this.colReviewer.FieldName = "Reviewer";
            this.colReviewer.Visible = true;
            this.colReviewer.VisibleIndex = 0;

            this.colAction.Caption = "الإجراء المأخوذ (Action Taken)";
            this.colAction.FieldName = "Action";
            this.colAction.Visible = true;
            this.colAction.VisibleIndex = 1;

            this.colDate.Caption = "تاريخ وتوقيت الإجراء";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;

            this.colComment.Caption = "الملاحظات والتعليقات المكتوبة (Comment)";
            this.colComment.FieldName = "Comment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 3;

            // ucDocumentReviewApproval
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdReviewMatrix);
            this.Controls.Add(this.pnlActionButtons);
            this.Controls.Add(this.pnlWorkflowTimeline);
            this.Name = "ucDocumentReviewApproval";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkflowTimeline)).EndInit();
            this.pnlWorkflowTimeline.ResumeLayout(false);
            this.pnlWorkflowTimeline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).EndInit();
            this.pnlActionButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReviewMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReviewMatrix)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlWorkflowTimeline;
        private DevExpress.XtraEditors.LabelControl lblStepDraft;
        private DevExpress.XtraEditors.LabelControl lblStepInternalReview;
        private DevExpress.XtraEditors.LabelControl lblStepPmReview;
        private DevExpress.XtraEditors.LabelControl lblStepConsultantReview;
        private DevExpress.XtraEditors.LabelControl lblStepClientApproval;
        private DevExpress.XtraEditors.LabelControl lblStepReleased;
        private DevExpress.XtraEditors.PanelControl pnlActionButtons;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnReject;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraEditors.SimpleButton btnDelegate;
        private DevExpress.XtraEditors.SimpleButton btnAddComment;
        private DevExpress.XtraGrid.GridControl grdReviewMatrix;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReviewMatrix;
        private DevExpress.XtraGrid.Columns.GridColumn colReviewer;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
    }
}
