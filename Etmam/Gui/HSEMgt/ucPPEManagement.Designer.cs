namespace Etmam.Gui.HSEMgt
{
    partial class ucPPEManagement
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
            this.bbiIssuePpe = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReplacePpe = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblExpiredPpe = new DevExpress.XtraEditors.LabelControl();
            this.lblReplacementDue = new DevExpress.XtraEditors.LabelControl();
            this.grdPPE = new DevExpress.XtraGrid.GridControl();
            this.gvPPE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCondition = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPPE)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiIssuePpe, this.bbiReplacePpe, this.bbiExport
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiIssuePpe),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiReplacePpe),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport)
            });
            this.barMain.Text = "أدوات إدارة وتصرف أدوات الوقاية الشخصية PPE";

            this.bbiIssuePpe.Caption = "تسليم مهمات وقاية (Issue PPE)";
            this.bbiReplacePpe.Caption = "صرف بديل للتالف (Replace)";
            this.bbiExport.Caption = "تصدير سجل PPE";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblExpiredPpe);
            this.pnlCards.Controls.Add(this.lblReplacementDue);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblExpiredPpe.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExpiredPpe.Location = new System.Drawing.Point(950, 15);
            this.lblExpiredPpe.Text = "أدوات وقاية منتهية الصلاحية: 8";

            this.lblReplacementDue.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReplacementDue.Location = new System.Drawing.Point(600, 15);
            this.lblReplacementDue.Text = "مهمات تستحق الاستبدال هذا الشهر: 15";

            // grdPPE
            this.grdPPE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPPE.Location = new System.Drawing.Point(0, 80);
            this.grdPPE.MainView = this.gvPPE;
            this.grdPPE.Name = "grdPPE";
            this.grdPPE.Size = new System.Drawing.Size(1200, 670);
            this.grdPPE.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvPPE });

            // gvPPE
            this.gvPPE.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colEmployee, this.colPPE, this.colIssueDate,
                this.colExpiry, this.colCondition
            });
            this.gvPPE.GridControl = this.grdPPE;
            this.gvPPE.Name = "gvPPE";
            this.gvPPE.OptionsView.ShowAutoFilterRow = true;
            this.gvPPE.OptionsView.ShowFooter = true;

            this.colEmployee.Caption = "اسم الموظف / العامل";
            this.colEmployee.FieldName = "Employee";
            this.colEmployee.Visible = true;
            this.colEmployee.VisibleIndex = 0;

            this.colPPE.Caption = "نوع مهمة الوقاية (خوذة/سترة/حذاء/حزام امان)";
            this.colPPE.FieldName = "PPE";
            this.colPPE.Visible = true;
            this.colPPE.VisibleIndex = 1;

            this.colIssueDate.Caption = "تاريخ الصرف والتسليم";
            this.colIssueDate.FieldName = "IssueDate";
            this.colIssueDate.Visible = true;
            this.colIssueDate.VisibleIndex = 2;

            this.colExpiry.Caption = "تاريخ الاستبدال المستهدف";
            this.colExpiry.FieldName = "Expiry";
            this.colExpiry.Visible = true;
            this.colExpiry.VisibleIndex = 3;

            this.colCondition.Caption = "حالة المهمة (Good/Damaged/Replaced)";
            this.colCondition.FieldName = "Condition";
            this.colCondition.Visible = true;
            this.colCondition.VisibleIndex = 4;

            // ucPPEManagement
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdPPE);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucPPEManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPPE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiIssuePpe;
        private DevExpress.XtraBars.BarButtonItem bbiReplacePpe;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblExpiredPpe;
        private DevExpress.XtraEditors.LabelControl lblReplacementDue;
        private DevExpress.XtraGrid.GridControl grdPPE;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPPE;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colPPE;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiry;
        private DevExpress.XtraGrid.Columns.GridColumn colCondition;
    }
}
