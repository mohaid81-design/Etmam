namespace Etmam.Gui.EDMSMgt
{
    partial class ucDistributionMatrix
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
            this.bbiNewRule = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditRule = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCards = new DevExpress.XtraEditors.PanelControl();
            this.lblPendingDist = new DevExpress.XtraEditors.LabelControl();
            this.lblCompletedDist = new DevExpress.XtraEditors.LabelControl();
            this.lblFailedDist = new DevExpress.XtraEditors.LabelControl();
            this.grdMatrix = new DevExpress.XtraGrid.GridControl();
            this.gvMatrix = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecipient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequiredAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).BeginInit();
            this.pnlCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMatrix)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewRule, this.bbiEditRule, this.bbiPrint
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewRule),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditRule),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint)
            });
            this.barMain.Text = "أدوات مصفوفة التوزيع";

            this.bbiNewRule.Caption = "قاعدة توزيع جديدة";
            this.bbiEditRule.Caption = "تعديل النمط";
            this.bbiPrint.Caption = "طباعة مصفوفة التوزيع";

            // pnlCards
            this.pnlCards.Controls.Add(this.lblPendingDist);
            this.pnlCards.Controls.Add(this.lblCompletedDist);
            this.pnlCards.Controls.Add(this.lblFailedDist);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 30);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1200, 50);

            this.lblPendingDist.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPendingDist.Location = new System.Drawing.Point(950, 15);
            this.lblPendingDist.Text = "معاملات قيد التوزيع (Pending): 14";

            this.lblCompletedDist.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCompletedDist.Location = new System.Drawing.Point(620, 15);
            this.lblCompletedDist.Text = "تم التوزيع بنجاح (Completed): 1,240";

            this.lblFailedDist.Appearance.Font = new System.Drawing.Font("Cairo", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFailedDist.Location = new System.Drawing.Point(300, 15);
            this.lblFailedDist.Text = "تعذر التسليم (Failed): 2";

            // grdMatrix
            this.grdMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMatrix.Location = new System.Drawing.Point(0, 80);
            this.grdMatrix.MainView = this.gvMatrix;
            this.grdMatrix.Name = "grdMatrix";
            this.grdMatrix.Size = new System.Drawing.Size(1200, 670);
            this.grdMatrix.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvMatrix });

            // gvMatrix
            this.gvMatrix.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colDiscipline, this.colDocType, this.colRecipient,
                this.colMethod, this.colRequiredAction, this.colDueDate
            });
            this.gvMatrix.GridControl = this.grdMatrix;
            this.gvMatrix.Name = "gvMatrix";
            this.gvMatrix.OptionsView.ShowAutoFilterRow = true;
            this.gvMatrix.OptionsView.ShowFooter = true;

            this.colDiscipline.Caption = "التخصص الهندسي";
            this.colDiscipline.FieldName = "Discipline";
            this.colDiscipline.Visible = true;
            this.colDiscipline.VisibleIndex = 0;

            this.colDocType.Caption = "نوع الوثيقة / التصنيف";
            this.colDocType.FieldName = "DocType";
            this.colDocType.Visible = true;
            this.colDocType.VisibleIndex = 1;

            this.colRecipient.Caption = "الجهة المستقبلة والمسؤول";
            this.colRecipient.FieldName = "Recipient";
            this.colRecipient.Visible = true;
            this.colRecipient.VisibleIndex = 2;

            this.colMethod.Caption = "طريقة الإرسال والتوزيع";
            this.colMethod.FieldName = "Method";
            this.colMethod.Visible = true;
            this.colMethod.VisibleIndex = 3;

            this.colRequiredAction.Caption = "الإجراء المطلوب (Required Action)";
            this.colRequiredAction.FieldName = "RequiredAction";
            this.colRequiredAction.Visible = true;
            this.colRequiredAction.VisibleIndex = 4;

            this.colDueDate.Caption = "تاريخ الاستحقاق المعتمد";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 5;

            // ucDistributionMatrix
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdMatrix);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucDistributionMatrix";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCards)).EndInit();
            this.pnlCards.ResumeLayout(false);
            this.pnlCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewRule;
        private DevExpress.XtraBars.BarButtonItem bbiEditRule;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlCards;
        private DevExpress.XtraEditors.LabelControl lblPendingDist;
        private DevExpress.XtraEditors.LabelControl lblCompletedDist;
        private DevExpress.XtraEditors.LabelControl lblFailedDist;
        private DevExpress.XtraGrid.GridControl grdMatrix;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMatrix;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn colDocType;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipient;
        private DevExpress.XtraGrid.Columns.GridColumn colMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiredAction;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
    }
}
