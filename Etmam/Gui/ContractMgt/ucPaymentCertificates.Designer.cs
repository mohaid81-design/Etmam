namespace Etmam.Gui.ContractMgt
{
    partial class ucPaymentCertificates
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
            this.bbiNewCertificate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApprove = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdCertificates = new DevExpress.XtraGrid.GridControl();
            this.gvCertificates = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCertificateNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContract = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrossValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetention = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlBottom = new DevExpress.XtraTab.XtraTabControl();
            this.tabDeductions = new DevExpress.XtraTab.XtraTabPage();
            this.tabAttachments = new DevExpress.XtraTab.XtraTabPage();
            this.tabWorkflow = new DevExpress.XtraTab.XtraTabPage();
            this.tabHistory = new DevExpress.XtraTab.XtraTabPage();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCertificates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCertificates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlBottom)).BeginInit();
            this.tabControlBottom.SuspendLayout();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewCertificate, this.bbiApprove, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewCertificate),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiApprove),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات المستخلصات";

            this.bbiNewCertificate.Caption = "مستخلص جديد";
            this.bbiApprove.Caption = "اعتماد الصرف";
            this.bbiPrint.Caption = "طباعة المستخلص";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdCertificates);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.tabControlBottom);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 450;

            // grdCertificates
            this.grdCertificates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCertificates.Location = new System.Drawing.Point(0, 0);
            this.grdCertificates.MainView = this.gvCertificates;
            this.grdCertificates.Name = "grdCertificates";
            this.grdCertificates.Size = new System.Drawing.Size(1200, 450);
            this.grdCertificates.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvCertificates });

            // gvCertificates
            this.gvCertificates.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCertificateNo, this.colContract, this.colPeriod,
                this.colGrossValue, this.colRetention, this.colVAT, this.colNetAmount, this.colStatus
            });
            this.gvCertificates.GridControl = this.grdCertificates;
            this.gvCertificates.Name = "gvCertificates";

            this.colCertificateNo.Caption = "رقم المستخلص";
            this.colCertificateNo.FieldName = "CertificateNo";
            this.colCertificateNo.Visible = true;
            this.colCertificateNo.VisibleIndex = 0;

            this.colContract.Caption = "العقد المرتبط";
            this.colContract.FieldName = "ContractNo";
            this.colContract.Visible = true;
            this.colContract.VisibleIndex = 1;

            this.colPeriod.Caption = "الفترة المالية";
            this.colPeriod.FieldName = "Period";
            this.colPeriod.Visible = true;
            this.colPeriod.VisibleIndex = 2;

            this.colGrossValue.Caption = "القيمة الإجمالية قبل الاستقطاع";
            this.colGrossValue.FieldName = "GrossValue";
            this.colGrossValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGrossValue.DisplayFormat.FormatString = "n2";
            this.colGrossValue.Visible = true;
            this.colGrossValue.VisibleIndex = 3;

            this.colRetention.Caption = "محتجزات ضمان الأعمال";
            this.colRetention.FieldName = "Retention";
            this.colRetention.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRetention.DisplayFormat.FormatString = "n2";
            this.colRetention.Visible = true;
            this.colRetention.VisibleIndex = 4;

            this.colVAT.Caption = "ضريبة القيمة المضافة VAT";
            this.colVAT.FieldName = "VAT";
            this.colVAT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVAT.DisplayFormat.FormatString = "n2";
            this.colVAT.Visible = true;
            this.colVAT.VisibleIndex = 5;

            this.colNetAmount.Caption = "الصافي المستحق للصرف";
            this.colNetAmount.FieldName = "NetAmount";
            this.colNetAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNetAmount.DisplayFormat.FormatString = "n2";
            this.colNetAmount.Visible = true;
            this.colNetAmount.VisibleIndex = 6;

            this.colStatus.Caption = "حالة المستخلص";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 7;

            // tabControlBottom
            this.tabControlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBottom.Location = new System.Drawing.Point(0, 0);
            this.tabControlBottom.Name = "tabControlBottom";
            this.tabControlBottom.SelectedTabPage = this.tabDeductions;
            this.tabControlBottom.Size = new System.Drawing.Size(1200, 260);
            this.tabControlBottom.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tabDeductions, this.tabAttachments, this.tabWorkflow, this.tabHistory
            });

            this.tabDeductions.Name = "tabDeductions";
            this.tabDeductions.Text = "الاستقطاعات والتأخيرات والعهد";

            this.tabAttachments.Name = "tabAttachments";
            this.tabAttachments.Text = "المرفقات وحسابة الكميات المعتمدة";

            this.tabWorkflow.Name = "tabWorkflow";
            this.tabWorkflow.Text = "مسار موافقات الاعتماد المالي";

            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Text = "سجل الإجراءات والدفعات السابقة";

            // ucPaymentCertificates
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucPaymentCertificates";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCertificates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCertificates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlBottom)).EndInit();
            this.tabControlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewCertificate;
        private DevExpress.XtraBars.BarButtonItem bbiApprove;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdCertificates;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCertificates;
        private DevExpress.XtraGrid.Columns.GridColumn colCertificateNo;
        private DevExpress.XtraGrid.Columns.GridColumn colContract;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colGrossValue;
        private DevExpress.XtraGrid.Columns.GridColumn colRetention;
        private DevExpress.XtraGrid.Columns.GridColumn colVAT;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraTab.XtraTabControl tabControlBottom;
        private DevExpress.XtraTab.XtraTabPage tabDeductions;
        private DevExpress.XtraTab.XtraTabPage tabAttachments;
        private DevExpress.XtraTab.XtraTabPage tabWorkflow;
        private DevExpress.XtraTab.XtraTabPage tabHistory;
    }
}
