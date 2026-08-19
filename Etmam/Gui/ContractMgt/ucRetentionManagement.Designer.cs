namespace Etmam.Gui.ContractMgt
{
    partial class ucRetentionManagement
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
            this.bbiReleaseRetention = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlKpiCards = new DevExpress.XtraEditors.PanelControl();
            this.lblTotalRetention = new DevExpress.XtraEditors.LabelControl();
            this.lblReleasedRetention = new DevExpress.XtraEditors.LabelControl();
            this.lblOutstandingRetention = new DevExpress.XtraEditors.LabelControl();
            this.grdRetention = new DevExpress.XtraGrid.GridControl();
            this.gvRetention = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContract = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCertificate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReleaseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).BeginInit();
            this.pnlKpiCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRetention)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRetention)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiReleaseRetention, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiReleaseRetention),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات المحتجزات";

            this.bbiReleaseRetention.Caption = "الإفراج عن المحتجز";
            this.bbiPrint.Caption = "طباعة تقرير المحتجزات";

            // pnlKpiCards
            this.pnlKpiCards.Controls.Add(this.lblTotalRetention);
            this.pnlKpiCards.Controls.Add(this.lblReleasedRetention);
            this.pnlKpiCards.Controls.Add(this.lblOutstandingRetention);
            this.pnlKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiCards.Location = new System.Drawing.Point(0, 30);
            this.pnlKpiCards.Name = "pnlKpiCards";
            this.pnlKpiCards.Size = new System.Drawing.Size(1200, 50);

            this.lblTotalRetention.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalRetention.Location = new System.Drawing.Point(1000, 15);
            this.lblTotalRetention.Text = "إجمالي المحتجزات: 7,500,000 ر.س";

            this.lblReleasedRetention.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReleasedRetention.Location = new System.Drawing.Point(650, 15);
            this.lblReleasedRetention.Text = "المحتجزات المفرج عنها: 3,000,000 ر.س";

            this.lblOutstandingRetention.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOutstandingRetention.Location = new System.Drawing.Point(300, 15);
            this.lblOutstandingRetention.Text = "المحتجزات المتبقية (المستحقة مستقبلاً): 4,500,000 ر.س";

            // grdRetention
            this.grdRetention.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRetention.Location = new System.Drawing.Point(0, 80);
            this.grdRetention.MainView = this.gvRetention;
            this.grdRetention.Name = "grdRetention";
            this.grdRetention.Size = new System.Drawing.Size(1200, 670);
            this.grdRetention.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvRetention });

            // gvRetention
            this.gvRetention.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colContract, this.colCertificate, this.colAmount,
                this.colReleaseDate, this.colStatus
            });
            this.gvRetention.GridControl = this.grdRetention;
            this.gvRetention.Name = "gvRetention";

            this.colContract.Caption = "العقد والمرجع";
            this.colContract.FieldName = "ContractNo";
            this.colContract.Visible = true;
            this.colContract.VisibleIndex = 0;

            this.colCertificate.Caption = "المستخلص المرتبط";
            this.colCertificate.FieldName = "CertificateNo";
            this.colCertificate.Visible = true;
            this.colCertificate.VisibleIndex = 1;

            this.colAmount.Caption = "مبلغ المحتجز";
            this.colAmount.FieldName = "Amount";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 2;

            this.colReleaseDate.Caption = "تاريخ الإفراج المتوقع";
            this.colReleaseDate.FieldName = "ReleaseDate";
            this.colReleaseDate.Visible = true;
            this.colReleaseDate.VisibleIndex = 3;

            this.colStatus.Caption = "حالة المحتجز";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;

            // ucRetentionManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdRetention);
            this.Controls.Add(this.pnlKpiCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucRetentionManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKpiCards)).EndInit();
            this.pnlKpiCards.ResumeLayout(false);
            this.pnlKpiCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRetention)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRetention)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiReleaseRetention;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlKpiCards;
        private DevExpress.XtraEditors.LabelControl lblTotalRetention;
        private DevExpress.XtraEditors.LabelControl lblReleasedRetention;
        private DevExpress.XtraEditors.LabelControl lblOutstandingRetention;
        private DevExpress.XtraGrid.GridControl grdRetention;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRetention;
        private DevExpress.XtraGrid.Columns.GridColumn colContract;
        private DevExpress.XtraGrid.Columns.GridColumn colCertificate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colReleaseDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
