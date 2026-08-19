namespace Etmam.Gui.ContractMgt
{
    partial class ucContractRegister
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
            this.bbiNewContract = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiView = new DevExpress.XtraBars.BarButtonItem();
            this.bbiArchive = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAmend = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.sbiRecordCount = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlSearchFilters = new DevExpress.XtraEditors.PanelControl();
            this.cboCompany = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboBranch = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboContractType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtEmployer = new DevExpress.XtraEditors.TextEdit();
            this.txtContractor = new DevExpress.XtraEditors.TextEdit();
            this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearFilters = new DevExpress.XtraEditors.SimpleButton();
            this.grdContracts = new DevExpress.XtraGrid.GridControl();
            this.gvContracts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOriginalValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsibleManager = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlLoadingState = new DevExpress.XtraEditors.PanelControl();
            this.pnlEmptyState = new DevExpress.XtraEditors.PanelControl();
            this.pnlErrorState = new DevExpress.XtraEditors.PanelControl();

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchFilters)).BeginInit();
            this.pnlSearchFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboContractType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContracts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContracts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLoadingState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmptyState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorState)).BeginInit();
            this.SuspendLayout();

            // barManagerMain
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] { this.barMain, this.barStatus });
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.bbiNewContract, this.bbiEdit, this.bbiView, this.bbiArchive,
                this.bbiAmend, this.bbiPrint, this.bbiExport, this.bbiRefresh, this.sbiRecordCount
            });

            // barMain
            this.barMain.BarName = "Main Toolbar";
            this.barMain.DockRow = 0;
            this.barMain.DockCol = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewContract),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiEdit),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiView),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiArchive),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiAmend),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiExport),
                new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh)
            });
            this.barMain.Text = "أدوات سجل العقود";

            this.bbiNewContract.Caption = "عقد جديد";
            this.bbiEdit.Caption = "تعديل العقد";
            this.bbiView.Caption = "عرض التفاصيل";
            this.bbiArchive.Caption = "أرشفة العقد";
            this.bbiAmend.Caption = "ملحق تعاقدي";
            this.bbiPrint.Caption = "طباعة السجل";
            this.bbiExport.Caption = "تصدير إلى إكسل";
            this.bbiRefresh.Caption = "تحديث";

            // barStatus
            this.barStatus.BarName = "Status Bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockRow = 0;
            this.barStatus.DockCol = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.sbiRecordCount)
            });
            this.barStatus.Text = "شريط الحالة";
            this.sbiRecordCount.Caption = "عدد العقود المسجلة: 0";

            // pnlSearchFilters
            this.pnlSearchFilters.Controls.Add(this.btnSearch);
            this.pnlSearchFilters.Controls.Add(this.btnClearFilters);
            this.pnlSearchFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchFilters.Location = new System.Drawing.Point(0, 30);
            this.pnlSearchFilters.Name = "pnlSearchFilters";
            this.pnlSearchFilters.Size = new System.Drawing.Size(1200, 60);

            this.btnSearch.Location = new System.Drawing.Point(100, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.Text = "بحث";

            this.btnClearFilters.Location = new System.Drawing.Point(5, 15);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(90, 30);
            this.btnClearFilters.Text = "مسح الفلاتر";

            // grdContracts
            this.grdContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContracts.Location = new System.Drawing.Point(0, 90);
            this.grdContracts.MainView = this.gvContracts;
            this.grdContracts.Name = "grdContracts";
            this.grdContracts.Size = new System.Drawing.Size(1200, 660);
            this.grdContracts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvContracts });

            // gvContracts
            this.gvContracts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colContractNo, this.colProject, this.colContractType, this.colContractor,
                this.colEmployer, this.colOriginalValue, this.colCurrentValue, this.colStartDate,
                this.colEndDate, this.colStatus, this.colResponsibleManager
            });
            this.gvContracts.GridControl = this.grdContracts;
            this.gvContracts.Name = "gvContracts";
            this.gvContracts.OptionsView.ShowFooter = true;
            this.gvContracts.OptionsView.ShowGroupPanel = true;

            this.colContractNo.Caption = "رقم العقد";
            this.colContractNo.FieldName = "ContractNo";
            this.colContractNo.Visible = true;
            this.colContractNo.VisibleIndex = 0;

            this.colProject.Caption = "المشروع المرتبط";
            this.colProject.FieldName = "ProjectName";
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 1;

            this.colContractType.Caption = "نوع العقد";
            this.colContractType.FieldName = "ContractType";
            this.colContractType.Visible = true;
            this.colContractType.VisibleIndex = 2;

            this.colContractor.Caption = "المقاول / الطرف الثاني";
            this.colContractor.FieldName = "ContractorName";
            this.colContractor.Visible = true;
            this.colContractor.VisibleIndex = 3;

            this.colEmployer.Caption = "المالك / صاحب العمل";
            this.colEmployer.FieldName = "EmployerName";
            this.colEmployer.Visible = true;
            this.colEmployer.VisibleIndex = 4;

            this.colOriginalValue.Caption = "القيمة الأصلية";
            this.colOriginalValue.FieldName = "OriginalValue";
            this.colOriginalValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOriginalValue.DisplayFormat.FormatString = "n2";
            this.colOriginalValue.Visible = true;
            this.colOriginalValue.VisibleIndex = 5;

            this.colCurrentValue.Caption = "القيمة الحالية المعدلة";
            this.colCurrentValue.FieldName = "CurrentValue";
            this.colCurrentValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCurrentValue.DisplayFormat.FormatString = "n2";
            this.colCurrentValue.Visible = true;
            this.colCurrentValue.VisibleIndex = 6;

            this.colStartDate.Caption = "تاريخ البداية";
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 7;

            this.colEndDate.Caption = "تاريخ النهاية";
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 8;

            this.colStatus.Caption = "حالة العقد";
            this.colStatus.FieldName = "Status";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;

            this.colResponsibleManager.Caption = "مدير العقد المسؤول";
            this.colResponsibleManager.FieldName = "ResponsibleManager";
            this.colResponsibleManager.Visible = true;
            this.colResponsibleManager.VisibleIndex = 10;

            // ucContractRegister
            this.Appearance.Font = new System.Drawing.Font("Cairo", 9F);
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.grdContracts);
            this.Controls.Add(this.pnlSearchFilters);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucContractRegister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 750);

            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchFilters)).EndInit();
            this.pnlSearchFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboContractType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContracts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContracts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLoadingState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmptyState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem bbiNewContract;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiView;
        private DevExpress.XtraBars.BarButtonItem bbiArchive;
        private DevExpress.XtraBars.BarButtonItem bbiAmend;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiExport;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem sbiRecordCount;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlSearchFilters;
        private DevExpress.XtraEditors.ComboBoxEdit cboCompany;
        private DevExpress.XtraEditors.ComboBoxEdit cboBranch;
        private DevExpress.XtraEditors.ComboBoxEdit cboProject;
        private DevExpress.XtraEditors.ComboBoxEdit cboContractType;
        private DevExpress.XtraEditors.TextEdit txtEmployer;
        private DevExpress.XtraEditors.TextEdit txtContractor;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnClearFilters;
        private DevExpress.XtraGrid.GridControl grdContracts;
        private DevExpress.XtraGrid.Views.Grid.GridView gvContracts;
        private DevExpress.XtraGrid.Columns.GridColumn colContractNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private DevExpress.XtraGrid.Columns.GridColumn colContractType;
        private DevExpress.XtraGrid.Columns.GridColumn colContractor;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployer;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginalValue;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentValue;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsibleManager;
        private DevExpress.XtraEditors.PanelControl pnlLoadingState;
        private DevExpress.XtraEditors.PanelControl pnlEmptyState;
        private DevExpress.XtraEditors.PanelControl pnlErrorState;
    }
}
