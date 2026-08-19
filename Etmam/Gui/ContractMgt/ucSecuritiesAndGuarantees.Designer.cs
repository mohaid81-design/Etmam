namespace Etmam.Gui.ContractMgt
{
    partial class ucSecuritiesAndGuarantees
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
            this.bbiNewGuarantee = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRenew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRelease = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            this.lblActiveGuarantees = new DevExpress.XtraEditors.LabelControl();
            this.lblExpiringSoon = new DevExpress.XtraEditors.LabelControl();
            this.lblReleasedGuarantees = new DevExpress.XtraEditors.LabelControl();
            this.grdGuarantees = new DevExpress.XtraGrid.GridControl();
            this.gvGuarantees = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGuaranteeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).BeginInit();
            this.pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGuarantees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuarantees)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewGuarantee, this.bbiRenew, this.bbiRelease, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewGuarantee),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRenew),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRelease),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات الضمانات";

            this.bbiNewGuarantee.Caption = "خطاب ضمان جديد";
            this.bbiRenew.Caption = "تمديد / تجديد الخطاب";
            this.bbiRelease.Caption = "الإفراج عن الضمان";
            this.bbiPrint.Caption = "طباعة السجل";

            // pnlKpiCards
            this.pnlKpiCards.Controls.Add(this.lblActiveGuarantees);
            this.pnlKpiCards.Controls.Add(this.lblExpiringSoon);
            this.pnlKpiCards.Controls.Add(this.lblReleasedGuarantees);
            this.pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiCards.Location = new System.Drawing.Point(0, 30);
            this.pnlKpiCards.Name = "pnlKpiCards";
            this.pnlKpiCards.Size = new System.Drawing.Size(1200, 50);

            this.lblActiveGuarantees.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblActiveGuarantees.Location = new System.Drawing.Point(1000, 15);
            this.lblActiveGuarantees.Text = "الضمانات السارية: 18 (قيمة 25,000,000 ر.س)";

            this.lblExpiringSoon.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpiringSoon.Location = new System.Drawing.Point(620, 15);
            this.lblExpiringSoon.Text = "تنتهي خلال 30 يوماً: 3 (تنبيه عالي)";

            this.lblReleasedGuarantees.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReleasedGuarantees.Location = new System.Drawing.Point(300, 15);
            this.lblReleasedGuarantees.Text = "الضمانات المفرج عنها: 10";

            // grdGuarantees
            this.grdGuarantees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGuarantees.Location = new System.Drawing.Point(0, 80);
            this.grdGuarantees.MainView = this.gvGuarantees;
            this.grdGuarantees.Name = "grdGuarantees";
            this.grdGuarantees.Size = new System.Drawing.Size(1200, 670);
            this.grdGuarantees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvGuarantees });

            // gvGuarantees
            this.gvGuarantees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colGuaranteeNo, this.colType, this.colBank,
                this.colAmount, this.colIssueDate, this.colExpiryDate, this.colStatus
            });
            this.gvGuarantees.GridControl = this.grdGuarantees;
            this.gvGuarantees.Name = "gvGuarantees";

            this.colGuaranteeNo.Caption = "رقم خطاب الضمان";
            this.colGuaranteeNo.FieldName = "GuaranteeNo";
            this.colGuaranteeNo.Visible = true;
            this.colGuaranteeNo.VisibleIndex = 0;

            this.colType.Caption = "نوع الضمان (ابتدائي/نهائي/دفعة مقدمة)";
            this.colType.FieldName = "Type";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;

            this.colBank.Caption = "البنك المصدر";
            this.colBank.FieldName = "Bank";
            this.colBank.Visible = true;
            this.colBank.VisibleIndex = 2;

            this.colAmount.Caption = "مبلغ الضمان";
            this.colAmount.FieldName = "Amount";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;

            this.colIssueDate.Caption = "تاريخ الإصدار";
            this.colIssueDate.FieldName = "IssueDate";
            this.colIssueDate.Visible = true;
            this.colIssueDate.VisibleIndex = 4;

            this.colExpiryDate.Caption = "تاريخ الانتهاء";
            this.colExpiryDate.FieldName = "ExpiryDate";
            this.colExpiryDate.Visible = true;
            this.colExpiryDate.VisibleIndex = 5;

            this.colStatus.Caption = "حالة الضمان";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;

            // ucSecuritiesAndGuarantees
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdGuarantees);
            this.Controls.Add(this.pnlKpiCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucSecuritiesAndGuarantees";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).EndInit();
            this.pnlKpiCards.ResumeLayout(false);
            this.pnlKpiCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGuarantees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuarantees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewGuarantee;
        private DevExpress.XtraBars.BarButtonItem bbiRenew;
        private DevExpress.XtraBars.BarButtonItem bbiRelease;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.LabelControl lblActiveGuarantees;
        private DevExpress.XtraEditors.LabelControl lblExpiringSoon;
        private DevExpress.XtraEditors.LabelControl lblReleasedGuarantees;
        private DevExpress.XtraGrid.GridControl grdGuarantees;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGuarantees;
        private DevExpress.XtraGrid.Columns.GridColumn colGuaranteeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colBank;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
