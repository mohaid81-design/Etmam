namespace Etmam.Gui.HSEMgt
{
    partial class ucPermitToWork
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
            this.bbiNewPtw = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClosePtw = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSuspendPtw = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrintPtw = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblActive = new DevExpress.XtraEditors.LabelControl();
            this.lblExpired = new DevExpress.XtraEditors.LabelControl();
            this.lblSuspended = new DevExpress.XtraEditors.LabelControl();
            this.grdPTW = new DevExpress.XtraGrid.GridControl();
            this.gvPTW = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPTWNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPTW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPTW)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewPtw, this.bbiClosePtw, this.bbiSuspendPtw,
                this.bbiPrintPtw, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewPtw),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiClosePtw),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiSuspendPtw),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrintPtw),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات تصاريح العمل PTW";

            this.bbiNewPtw.Caption = "إصدار تصريح عمل جديد (New PTW)";
            this.bbiClosePtw.Caption = "إغلاق التصريح";
            this.bbiSuspendPtw.Caption = "تعليق / سحب التصريح (Suspend)";
            this.bbiPrintPtw.Caption = "طباعة التصريح";
            this.bbiExport.Caption = "تصدير إلى Excel/PDF";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblActive);
            this.pnlCards.Controls.Add(this.lblExpired);
            this.pnlCards.Controls.Add(this.lblSuspended);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblActive.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblActive.Location = new System.Drawing.Point(950, 15);
            this.lblActive.Text = "تصاريح نشطة (Active PTW): 9";

            this.lblExpired.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpired.Location = new System.Drawing.Point(650, 15);
            this.lblExpired.Text = "تصاريح منتهية (Expired): 3";

            this.lblSuspended.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSuspended.Location = new System.Drawing.Point(350, 15);
            this.lblSuspended.Text = "تصاريح معلقة (Suspended): 1";

            // grdPTW
            this.grdPTW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPTW.Location = new System.Drawing.Point(0, 80);
            this.grdPTW.MainView = this.gvPTW;
            this.grdPTW.Name = "grdPTW";
            this.grdPTW.Size = new System.Drawing.Size(1200, 670);
            this.grdPTW.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvPTW });

            // gvPTW
            this.gvPTW.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colPTWNo, this.colType, this.colArea,
                this.colContractor, this.colStart, this.colFinish, this.colStatus
            });
            this.gvPTW.GridControl = this.grdPTW;
            this.gvPTW.Name = "gvPTW";
            this.gvPTW.OptionsView.ShowAutoFilterRow = true;
            this.gvPTW.OptionsView.ShowFooter = true;

            this.colPTWNo.Caption = "رقم تصريح العمل (PTW No)";
            this.colPTWNo.FieldName = "PTWNo";
            this.colPTWNo.Visible = true;
            this.colPTWNo.VisibleIndex = 0;

            this.colType.Caption = "نوع التصريح (HotWork/ConfinedSpace/Lifting)";
            this.colType.FieldName = "Type";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;

            this.colArea.Caption = "الموقع والدور بالنطاق العالي الخطورة";
            this.colArea.FieldName = "Area";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 2;

            this.colContractor.Caption = "المقاول المنفذ ومسؤول السلامة";
            this.colContractor.FieldName = "Contractor";
            this.colContractor.Visible = true;
            this.colContractor.VisibleIndex = 3;

            this.colStart.Caption = "بداية سريان التصريح";
            this.colStart.FieldName = "Start";
            this.colStart.Visible = true;
            this.colStart.VisibleIndex = 4;

            this.colFinish.Caption = "نهاية سريان التصريح";
            this.colFinish.FieldName = "Finish";
            this.colFinish.Visible = true;
            this.colFinish.VisibleIndex = 5;

            this.colStatus.Caption = "حالة التصريح والاعتماد";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;

            // ucPermitToWork
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdPTW);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucPermitToWork";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPTW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPTW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewPtw;
        private DevExpress.XtraBars.BarButtonItem bbiClosePtw;
        private DevExpress.XtraBars.BarButtonItem bbiSuspendPtw;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPtw;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblActive;
        private DevExpress.XtraEditors.LabelControl lblExpired;
        private DevExpress.XtraEditors.LabelControl lblSuspended;
        private DevExpress.XtraGrid.GridControl grdPTW;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPTW;
        private DevExpress.XtraGrid.Columns.GridColumn colPTWNo;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colContractor;
        private DevExpress.XtraGrid.Columns.GridColumn colStart;
        private DevExpress.XtraGrid.Columns.GridColumn colFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
