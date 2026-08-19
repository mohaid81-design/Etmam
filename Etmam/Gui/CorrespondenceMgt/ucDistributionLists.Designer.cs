namespace Etmam.Gui.CorrespondenceMgt
{
    partial class ucDistributionLists
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
            this.pnlTopAction = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestDistribution = new DevExpress.XtraEditors.SimpleButton();
            this.grdDistribution = new DevExpress.XtraGrid.GridControl();
            this.gvDistribution = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDistributionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMembers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.pnlTopAction)).BeginInit();
            this.pnlTopAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDistribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistribution)).BeginInit();
            this.SuspendLayout();

            // pnlTopAction
            this.pnlTopAction.Controls.Add(this.btnAdd);
            this.pnlTopAction.Controls.Add(this.btnEdit);
            this.pnlTopAction.Controls.Add(this.btnDelete);
            this.pnlTopAction.Controls.Add(this.btnTestDistribution);
            this.pnlTopAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopAction.Location = new System.Drawing.Point(0, 0);
            this.pnlTopAction.Name = "pnlTopAction";
            this.pnlTopAction.Size = new System.Drawing.Size(1200, 50);

            this.btnAdd.Location = new System.Drawing.Point(1070, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 30);
            this.btnAdd.Text = "إضافة قائمة توجيه";

            this.btnEdit.Location = new System.Drawing.Point(950, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 30);
            this.btnEdit.Text = "تعديل القائمة";

            this.btnDelete.Location = new System.Drawing.Point(830, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 30);
            this.btnDelete.Text = "حذف القائمة";

            this.btnTestDistribution.Location = new System.Drawing.Point(660, 10);
            this.btnTestDistribution.Name = "btnTestDistribution";
            this.btnTestDistribution.Size = new System.Drawing.Size(150, 30);
            this.btnTestDistribution.Text = "اختبار الارسال الفعلي";

            // grdDistribution
            this.grdDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDistribution.Location = new System.Drawing.Point(0, 50);
            this.grdDistribution.MainView = this.gvDistribution;
            this.grdDistribution.Name = "grdDistribution";
            this.grdDistribution.Size = new System.Drawing.Size(1200, 700);
            this.grdDistribution.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvDistribution });

            // gvDistribution
            this.gvDistribution.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colDistributionName, this.colMembers, this.colDepartment, this.colActive
            });
            this.gvDistribution.GridControl = this.grdDistribution;
            this.gvDistribution.Name = "gvDistribution";
            this.gvDistribution.OptionsView.ShowAutoFilterRow = true;
            this.gvDistribution.OptionsView.ShowFooter = true;

            this.colDistributionName.Caption = "اسم قائمة التوزيع (Distribution Name)";
            this.colDistributionName.FieldName = "DistributionName";
            this.colDistributionName.Visible = true;
            this.colDistributionName.VisibleIndex = 0;

            this.colMembers.Caption = "أعضاء القائمة والمستخدمين (Members)";
            this.colMembers.FieldName = "Members";
            this.colMembers.Visible = true;
            this.colMembers.VisibleIndex = 1;

            this.colDepartment.Caption = "الإدارة / القسم التابع";
            this.colDepartment.FieldName = "Department";
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 2;

            this.colActive.Caption = "حالة النشاط (Active)";
            this.colActive.FieldName = "Active";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 3;

            // ucDistributionLists
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdDistribution);
            this.Controls.Add(this.pnlTopAction);
            this.Name = "ucDistributionLists";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.pnlTopAction)).EndInit();
            this.pnlTopAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDistribution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistribution)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTopAction;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnTestDistribution;
        private DevExpress.XtraGrid.GridControl grdDistribution;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDistribution;
        private DevExpress.XtraGrid.Columns.GridColumn colDistributionName;
        private DevExpress.XtraGrid.Columns.GridColumn colMembers;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
    }
}
