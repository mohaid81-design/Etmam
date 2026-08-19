namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucCorrespondenceWorkflow
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
            this.pnlTimelineSteps = new DevExpress.XtraEditors.PanelControl();
            this.lblStepDraft = new DevExpress.XtraEditors.LabelControl();
            this.lblStepReview = new DevExpress.XtraEditors.LabelControl();
            this.lblStepApproval = new DevExpress.XtraEditors.LabelControl();
            this.lblStepDispatch = new DevExpress.XtraEditors.LabelControl();
            this.lblStepDelivered = new DevExpress.XtraEditors.LabelControl();
            this.lblStepClosed = new DevExpress.XtraEditors.LabelControl();
            this.pnlActionButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnReject = new DevExpress.XtraEditors.SimpleButton();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelegate = new DevExpress.XtraEditors.SimpleButton();
            this.grdWorkflowMatrix = new DevExpress.XtraGrid.GridControl();
            this.gvWorkflowMatrix = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.pnlTimelineSteps)).BeginInit();
            this.pnlTimelineSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).BeginInit();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkflowMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWorkflowMatrix)).BeginInit();
            this.SuspendLayout();

            // pnlTimelineSteps
            this.pnlTimelineSteps.Controls.Add(this.lblStepDraft);
            this.pnlTimelineSteps.Controls.Add(this.lblStepReview);
            this.pnlTimelineSteps.Controls.Add(this.lblStepApproval);
            this.pnlTimelineSteps.Controls.Add(this.lblStepDispatch);
            this.pnlTimelineSteps.Controls.Add(this.lblStepDelivered);
            this.pnlTimelineSteps.Controls.Add(this.lblStepClosed);
            this.pnlTimelineSteps.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimelineSteps.Location = new System.Drawing.Point(0, 0);
            this.pnlTimelineSteps.Name = "pnlTimelineSteps";
            this.pnlTimelineSteps.Size = new System.Drawing.Size(1200, 70);

            this.lblStepDraft.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepDraft.Location = new System.Drawing.Point(1050, 22);
            this.lblStepDraft.Text = "1. المسودة (Draft) ✔";

            this.lblStepReview.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepReview.Location = new System.Drawing.Point(860, 22);
            this.lblStepReview.Text = "2. المراجعة التدقيق ✔";

            this.lblStepApproval.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepApproval.Location = new System.Drawing.Point(670, 22);
            this.lblStepApproval.Text = "3. الاعتماد النهائي ✔";

            this.lblStepDispatch.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepDispatch.Location = new System.Drawing.Point(490, 22);
            this.lblStepDispatch.Text = "4. الإرسال (Dispatch) ⏳";

            this.lblStepDelivered.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.lblStepDelivered.Location = new System.Drawing.Point(310, 22);
            this.lblStepDelivered.Text = "5. مؤكد الاستلام";

            this.lblStepClosed.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.lblStepClosed.Location = new System.Drawing.Point(140, 22);
            this.lblStepClosed.Text = "6. الإغلاق النهائي";

            // pnlActionButtons
            this.pnlActionButtons.Controls.Add(this.btnApprove);
            this.pnlActionButtons.Controls.Add(this.btnReject);
            this.pnlActionButtons.Controls.Add(this.btnReturn);
            this.pnlActionButtons.Controls.Add(this.btnDelegate);
            this.pnlActionButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 70);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(1200, 50);

            this.btnApprove.Location = new System.Drawing.Point(1070, 10);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(110, 32);
            this.btnApprove.Text = "اعتماد المراسلة";

            this.btnReject.Location = new System.Drawing.Point(950, 10);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(110, 32);
            this.btnReject.Text = "رفض المراسلة";

            this.btnReturn.Location = new System.Drawing.Point(820, 10);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(120, 32);
            this.btnReturn.Text = "إعادة للتعديل";

            this.btnDelegate.Location = new System.Drawing.Point(680, 10);
            this.btnDelegate.Name = "btnDelegate";
            this.btnDelegate.Size = new System.Drawing.Size(130, 32);
            this.btnDelegate.Text = "تفويض لشخص آخر";

            // grdWorkflowMatrix
            this.grdWorkflowMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkflowMatrix.Location = new System.Drawing.Point(0, 120);
            this.grdWorkflowMatrix.MainView = this.gvWorkflowMatrix;
            this.grdWorkflowMatrix.Name = "grdWorkflowMatrix";
            this.grdWorkflowMatrix.Size = new System.Drawing.Size(1200, 630);
            this.grdWorkflowMatrix.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvWorkflowMatrix });

            // gvWorkflowMatrix
            this.gvWorkflowMatrix.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colUser, this.colAction, this.colDate, this.colComment
            });
            this.gvWorkflowMatrix.GridControl = this.grdWorkflowMatrix;
            this.gvWorkflowMatrix.Name = "gvWorkflowMatrix";
            this.gvWorkflowMatrix.OptionsView.ShowAutoFilterRow = true;
            this.gvWorkflowMatrix.OptionsView.ShowFooter = true;

            this.colUser.Caption = "المستخدم / المراجع (User)";
            this.colUser.FieldName = "User";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;

            this.colAction.Caption = "الإجراء المتخذ (Action)";
            this.colAction.FieldName = "Action";
            this.colAction.Visible = true;
            this.colAction.VisibleIndex = 1;

            this.colDate.Caption = "تاريخ وتوقيت الإجراء";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;

            this.colComment.Caption = "الملاحظات والتوجيهات (Comment)";
            this.colComment.FieldName = "Comment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 3;

            // ucCorrespondenceWorkflow
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdWorkflowMatrix);
            this.Controls.Add(this.pnlActionButtons);
            this.Controls.Add(this.pnlTimelineSteps);
            this.Name = "ucCorrespondenceWorkflow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.pnlTimelineSteps)).EndInit();
            this.pnlTimelineSteps.ResumeLayout(false);
            this.pnlTimelineSteps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).EndInit();
            this.pnlActionButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkflowMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWorkflowMatrix)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTimelineSteps;
        private DevExpress.XtraEditors.LabelControl lblStepDraft;
        private DevExpress.XtraEditors.LabelControl lblStepReview;
        private DevExpress.XtraEditors.LabelControl lblStepApproval;
        private DevExpress.XtraEditors.LabelControl lblStepDispatch;
        private DevExpress.XtraEditors.LabelControl lblStepDelivered;
        private DevExpress.XtraEditors.LabelControl lblStepClosed;
        private DevExpress.XtraEditors.PanelControl pnlActionButtons;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnReject;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraEditors.SimpleButton btnDelegate;
        private DevExpress.XtraGrid.GridControl grdWorkflowMatrix;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWorkflowMatrix;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
    }
}
