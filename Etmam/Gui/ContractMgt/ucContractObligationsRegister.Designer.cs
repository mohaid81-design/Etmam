namespace Etmam.Gui.ContractMgt
{
    partial class ucContractObligationsRegister
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
            this.bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiComplete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLinkDoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grdObligations = new DevExpress.XtraGrid.GridControl();
            this.gvObligations = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colObligationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClause = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsibleParty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEvidence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemarks = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdObligations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObligations)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiAdd, this.bbiEdit, this.bbiComplete, this.bbiLinkDoc, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiAdd),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEdit),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiComplete),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiLinkDoc),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات سجل الالتزامات";

            this.bbiAdd.Caption = "إضافة التزام";
            this.bbiEdit.Caption = "تعديل";
            this.bbiComplete.Caption = "إكتمال الالتزام";
            this.bbiLinkDoc.Caption = "ربط مستند/دليل";
            this.bbiPrint.Caption = "طباعة السجل";

            // grdObligations
            this.grdObligations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdObligations.Location = new System.Drawing.Point(0, 30);
            this.grdObligations.MainView = this.gvObligations;
            this.grdObligations.Name = "grdObligations";
            this.grdObligations.Size = new System.Drawing.Size(1200, 720);
            this.grdObligations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvObligations });

            // gvObligations
            this.gvObligations.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colObligationID, this.colClause, this.colDescription, this.colResponsibleParty,
                this.colDueDate, this.colStatus, this.colEvidence, this.colRemarks
            });
            this.gvObligations.GridControl = this.grdObligations;
            this.gvObligations.Name = "gvObligations";
            this.gvObligations.OptionsView.ShowAutoFilterRow = true;

            this.colObligationID.Caption = "رمز الالتزام";
            this.colObligationID.FieldName = "ObligationID";
            this.colObligationID.Visible = true;
            this.colObligationID.VisibleIndex = 0;

            this.colClause.Caption = "البند التعاقدي والمرجع";
            this.colClause.FieldName = "Clause";
            this.colClause.Visible = true;
            this.colClause.VisibleIndex = 1;

            this.colDescription.Caption = "وصف الالتزام والواجب";
            this.colDescription.FieldName = "Description";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;

            this.colResponsibleParty.Caption = "الطرف المسؤول";
            this.colResponsibleParty.FieldName = "ResponsibleParty";
            this.colResponsibleParty.Visible = true;
            this.colResponsibleParty.VisibleIndex = 3;

            this.colDueDate.Caption = "تاريخ الاستحقاق";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 4;

            this.colStatus.Caption = "الحالة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            this.colEvidence.Caption = "الدليل المستندي";
            this.colEvidence.FieldName = "Evidence";
            this.colEvidence.Visible = true;
            this.colEvidence.VisibleIndex = 6;

            this.colRemarks.Caption = "ملاحظات";
            this.colRemarks.FieldName = "Remarks";
            this.colRemarks.Visible = true;
            this.colRemarks.VisibleIndex = 7;

            // ucContractObligationsRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdObligations);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucContractObligationsRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdObligations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObligations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiComplete;
        private DevExpress.XtraBars.BarButtonItem bbiLinkDoc;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl grdObligations;
        private DevExpress.XtraGrid.Views.Grid.GridView gvObligations;
        private DevExpress.XtraGrid.Columns.GridColumn colObligationID;
        private DevExpress.XtraGrid.Columns.GridColumn colClause;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsibleParty;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colEvidence;
        private DevExpress.XtraGrid.Columns.GridColumn colRemarks;
    }
}
