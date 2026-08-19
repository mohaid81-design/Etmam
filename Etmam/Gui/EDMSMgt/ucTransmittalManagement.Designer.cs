namespace Etmam.Gui.EDMSMgt
{
    partial class ucTransmittalManagement
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
            this.bbiNewTransmittal = new DevExpress.XtraBars.BarButtonItem();
            this.bbiIssue = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRecall = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdTransmittals = new DevExpress.XtraGrid.GridControl();
            this.gvTransmittals = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTransmittalNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecipient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurpose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdDocumentsIncluded = new DevExpress.XtraGrid.GridControl();
            this.gvDocumentsIncluded = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocNoInc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocTitleInc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRevInc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCopiesInc = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransmittals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransmittals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentsIncluded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentsIncluded)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewTransmittal, this.bbiIssue, this.bbiRecall,
                this.bbiPrint, this.bbiExportPdf
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewTransmittal),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiIssue),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRecall),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportPdf)
            });
            this.barMain.Text = "أدوات Transmittals";

            this.bbiNewTransmittal.Caption = "خطاب تسليم جديد (New Transmittal)";
            this.bbiIssue.Caption = "إصدار وإرسال (Issue)";
            this.bbiRecall.Caption = "استرجاع (Recall)";
            this.bbiPrint.Caption = "طباعة الخطاب";
            this.bbiExportPdf.Caption = "تصدير إلى PDF";

            // splitContainerControlMain
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.grdTransmittals);
            this.splitContainerControlMain.Panel1.Text = "جدول Transmittals الرئيسي";
            this.splitContainerControlMain.Panel2.Controls.Add(this.grdDocumentsIncluded);
            this.splitContainerControlMain.Panel2.Text = "الوثائق والمستندات المضمنة (Documents Included)";
            this.splitContainerControlMain.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControlMain.SplitterPosition = 420;

            // grdTransmittals
            this.grdTransmittals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTransmittals.Location = new System.Drawing.Point(0, 0);
            this.grdTransmittals.MainView = this.gvTransmittals;
            this.grdTransmittals.Name = "grdTransmittals";
            this.grdTransmittals.Size = new System.Drawing.Size(1200, 420);
            this.grdTransmittals.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvTransmittals });

            // gvTransmittals
            this.gvTransmittals.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colTransmittalNo, this.colRecipient, this.colSender,
                this.colDate, this.colPurpose, this.colStatus
            });
            this.gvTransmittals.GridControl = this.grdTransmittals;
            this.gvTransmittals.Name = "gvTransmittals";
            this.gvTransmittals.OptionsView.ShowAutoFilterRow = true;
            this.gvTransmittals.OptionsView.ShowFooter = true;

            this.colTransmittalNo.Caption = "رقم الخطاب (Transmittal No)";
            this.colTransmittalNo.FieldName = "TransmittalNo";
            this.colTransmittalNo.Visible = true;
            this.colTransmittalNo.VisibleIndex = 0;

            this.colRecipient.Caption = "الجهة المستقبلة (Recipient)";
            this.colRecipient.FieldName = "Recipient";
            this.colRecipient.Visible = true;
            this.colRecipient.VisibleIndex = 1;

            this.colSender.Caption = "الجهة المرسلة (Sender)";
            this.colSender.FieldName = "Sender";
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 2;

            this.colDate.Caption = "تاريخ الإرسال";
            this.colDate.FieldName = "Date";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 3;

            this.colPurpose.Caption = "الغرض من التسليم (Purpose)";
            this.colPurpose.FieldName = "Purpose";
            this.colPurpose.Visible = true;
            this.colPurpose.VisibleIndex = 4;

            this.colStatus.Caption = "حالة التسليم";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;

            // grdDocumentsIncluded
            this.grdDocumentsIncluded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDocumentsIncluded.Location = new System.Drawing.Point(0, 0);
            this.grdDocumentsIncluded.MainView = this.gvDocumentsIncluded;
            this.grdDocumentsIncluded.Name = "grdDocumentsIncluded";
            this.grdDocumentsIncluded.Size = new System.Drawing.Size(1200, 290);
            this.grdDocumentsIncluded.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvDocumentsIncluded });

            // gvDocumentsIncluded
            this.gvDocumentsIncluded.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colDocNoInc, this.colDocTitleInc, this.colRevInc, this.colCopiesInc
            });
            this.gvDocumentsIncluded.GridControl = this.grdDocumentsIncluded;
            this.gvDocumentsIncluded.Name = "gvDocumentsIncluded";

            this.colDocNoInc.Caption = "رقم الوثيقة المضمنة";
            this.colDocNoInc.FieldName = "DocNo";
            this.colDocNoInc.Visible = true;
            this.colDocNoInc.VisibleIndex = 0;

            this.colDocTitleInc.Caption = "عنوان الوثيقة";
            this.colDocTitleInc.FieldName = "DocTitle";
            this.colDocTitleInc.Visible = true;
            this.colDocTitleInc.VisibleIndex = 1;

            this.colRevInc.Caption = "الإصدار المرفق (Rev)";
            this.colRevInc.FieldName = "Revision";
            this.colRevInc.Visible = true;
            this.colRevInc.VisibleIndex = 2;

            this.colCopiesInc.Caption = "عدد النسخ المرفقة";
            this.colCopiesInc.FieldName = "Copies";
            this.colCopiesInc.Visible = true;
            this.colCopiesInc.VisibleIndex = 3;

            // ucTransmittalManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucTransmittalManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTransmittals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransmittals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentsIncluded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentsIncluded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewTransmittal;
        private DevExpress.XtraBars.BarButtonItem bbiIssue;
        private DevExpress.XtraBars.BarButtonItem bbiRecall;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExportPdf;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl grdTransmittals;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTransmittals;
        private DevExpress.XtraGrid.Columns.GridColumn colTransmittalNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipient;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPurpose;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.GridControl grdDocumentsIncluded;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocumentsIncluded;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNoInc;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTitleInc;
        private DevExpress.XtraGrid.Columns.GridColumn colRevInc;
        private DevExpress.XtraGrid.Columns.GridColumn colCopiesInc;
    }
}
