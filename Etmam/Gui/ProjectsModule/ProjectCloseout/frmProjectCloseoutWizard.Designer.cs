namespace Etmam
{
    partial class frmProjectCloseoutWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            wizCloseout = new DevExpress.XtraWizard.WizardControl();

            wizPageDocuments = new DevExpress.XtraWizard.WizardPage();
            lblCloseoutDocuments = new DevExpress.XtraEditors.LabelControl();
            grdCloseoutDocuments = new DevExpress.XtraGrid.GridControl();
            gvCloseoutDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            colDocumentName = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentType = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            wizPagePunchList = new DevExpress.XtraWizard.WizardPage();
            lblPunchList = new DevExpress.XtraEditors.LabelControl();
            grdPunchList = new DevExpress.XtraGrid.GridControl();
            gvPunchList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPunchItem = new DevExpress.XtraGrid.Columns.GridColumn();
            colPunchLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            colPunchResponsible = new DevExpress.XtraGrid.Columns.GridColumn();
            colPunchStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            wizPageHandover = new DevExpress.XtraWizard.WizardPage();
            lblHandoverDate = new DevExpress.XtraEditors.LabelControl();
            dtHandoverDate = new DevExpress.XtraEditors.DateEdit();
            lblHandoverTo = new DevExpress.XtraEditors.LabelControl();
            txtHandoverTo = new DevExpress.XtraEditors.TextEdit();
            lblHandoverNotes = new DevExpress.XtraEditors.LabelControl();
            memoHandoverNotes = new DevExpress.XtraEditors.MemoEdit();

            wizPageFinalAccount = new DevExpress.XtraWizard.WizardPage();
            lblFinalContractValue = new DevExpress.XtraEditors.LabelControl();
            calcFinalContractValue = new DevExpress.XtraEditors.CalcEdit();
            lblTotalVariations = new DevExpress.XtraEditors.LabelControl();
            calcTotalVariations = new DevExpress.XtraEditors.CalcEdit();
            lblFinalAccountValue = new DevExpress.XtraEditors.LabelControl();
            calcFinalAccountValue = new DevExpress.XtraEditors.CalcEdit();

            wizPageRetention = new DevExpress.XtraWizard.WizardPage();
            lblRetentionAmount = new DevExpress.XtraEditors.LabelControl();
            calcRetentionAmount = new DevExpress.XtraEditors.CalcEdit();
            lblRetentionPercent = new DevExpress.XtraEditors.LabelControl();
            spinRetentionPercent = new DevExpress.XtraEditors.SpinEdit();
            lblRetentionReleaseDate = new DevExpress.XtraEditors.LabelControl();
            dtRetentionReleaseDate = new DevExpress.XtraEditors.DateEdit();

            wizPageLessonsLearned = new DevExpress.XtraWizard.WizardPage();
            lblLessonsLearned = new DevExpress.XtraEditors.LabelControl();
            memoLessonsLearned = new DevExpress.XtraEditors.MemoEdit();

            wizPageArchive = new DevExpress.XtraWizard.WizardPage();
            lblArchiveLocation = new DevExpress.XtraEditors.LabelControl();
            txtArchiveLocation = new DevExpress.XtraEditors.TextEdit();
            lblArchiveDate = new DevExpress.XtraEditors.LabelControl();
            dtArchiveDate = new DevExpress.XtraEditors.DateEdit();
            lblArchivedBy = new DevExpress.XtraEditors.LabelControl();
            txtArchivedBy = new DevExpress.XtraEditors.TextEdit();

            ((System.ComponentModel.ISupportInitialize)wizCloseout).BeginInit();
            wizCloseout.SuspendLayout();

            wizPageDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdCloseoutDocuments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCloseoutDocuments).BeginInit();

            wizPagePunchList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdPunchList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvPunchList).BeginInit();

            wizPageHandover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtHandoverDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtHandoverDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHandoverTo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoHandoverNotes.Properties).BeginInit();

            wizPageFinalAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)calcFinalContractValue.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcTotalVariations.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcFinalAccountValue.Properties).BeginInit();

            wizPageRetention.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)calcRetentionAmount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinRetentionPercent.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtRetentionReleaseDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtRetentionReleaseDate.Properties.CalendarTimeProperties).BeginInit();

            wizPageLessonsLearned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)memoLessonsLearned.Properties).BeginInit();

            wizPageArchive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtArchiveLocation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtArchiveDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtArchiveDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtArchivedBy.Properties).BeginInit();

            SuspendLayout();
            //
            // wizPageDocuments
            //
            wizPageDocuments.Controls.Add(grdCloseoutDocuments);
            wizPageDocuments.Controls.Add(lblCloseoutDocuments);
            wizPageDocuments.DescriptionText = "التأكد من اكتمال المستندات المطلوبة لإغلاق المشروع";
            wizPageDocuments.Name = "wizPageDocuments";
            wizPageDocuments.Size = new Size(860, 380);
            wizPageDocuments.Text = "المستندات";
            //
            // lblCloseoutDocuments
            //
            lblCloseoutDocuments.Appearance.Font = new Font("Cairo", 8F);
            lblCloseoutDocuments.Appearance.Options.UseFont = true;
            lblCloseoutDocuments.Location = new Point(20, 20);
            lblCloseoutDocuments.Name = "lblCloseoutDocuments";
            lblCloseoutDocuments.Size = new Size(102, 17);
            lblCloseoutDocuments.TabIndex = 0;
            lblCloseoutDocuments.Text = "مستندات إغلاق المشروع";
            //
            // grdCloseoutDocuments
            //
            grdCloseoutDocuments.Location = new Point(20, 40);
            grdCloseoutDocuments.MainView = gvCloseoutDocuments;
            grdCloseoutDocuments.Name = "grdCloseoutDocuments";
            grdCloseoutDocuments.Size = new Size(800, 320);
            grdCloseoutDocuments.TabIndex = 1;
            grdCloseoutDocuments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCloseoutDocuments });
            //
            // gvCloseoutDocuments
            //
            gvCloseoutDocuments.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvCloseoutDocuments.Appearance.HeaderPanel.Options.UseFont = true;
            gvCloseoutDocuments.Appearance.Row.Font = new Font("Cairo", 8F);
            gvCloseoutDocuments.Appearance.Row.Options.UseFont = true;
            gvCloseoutDocuments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDocumentName, colDocumentType, colDocumentStatus });
            gvCloseoutDocuments.GridControl = grdCloseoutDocuments;
            gvCloseoutDocuments.Name = "gvCloseoutDocuments";
            gvCloseoutDocuments.OptionsView.ShowGroupPanel = false;
            //
            // colDocumentName
            //
            colDocumentName.Caption = "اسم المستند";
            colDocumentName.FieldName = "DocumentName";
            colDocumentName.Name = "colDocumentName";
            colDocumentName.Visible = true;
            colDocumentName.VisibleIndex = 0;
            colDocumentName.Width = 400;
            //
            // colDocumentType
            //
            colDocumentType.Caption = "النوع";
            colDocumentType.FieldName = "DocumentType";
            colDocumentType.Name = "colDocumentType";
            colDocumentType.Visible = true;
            colDocumentType.VisibleIndex = 1;
            colDocumentType.Width = 220;
            //
            // colDocumentStatus
            //
            colDocumentStatus.Caption = "الحالة";
            colDocumentStatus.FieldName = "Status";
            colDocumentStatus.Name = "colDocumentStatus";
            colDocumentStatus.Visible = true;
            colDocumentStatus.VisibleIndex = 2;
            colDocumentStatus.Width = 160;
            //
            // wizPagePunchList
            //
            wizPagePunchList.Controls.Add(grdPunchList);
            wizPagePunchList.Controls.Add(lblPunchList);
            wizPagePunchList.DescriptionText = "قائمة الملاحظات الختامية قبل التسليم";
            wizPagePunchList.Name = "wizPagePunchList";
            wizPagePunchList.Size = new Size(860, 380);
            wizPagePunchList.Text = "قائمة الملاحظات (Punch List)";
            //
            // lblPunchList
            //
            lblPunchList.Appearance.Font = new Font("Cairo", 8F);
            lblPunchList.Appearance.Options.UseFont = true;
            lblPunchList.Location = new Point(20, 20);
            lblPunchList.Name = "lblPunchList";
            lblPunchList.Size = new Size(90, 17);
            lblPunchList.TabIndex = 0;
            lblPunchList.Text = "قائمة الملاحظات الختامية";
            //
            // grdPunchList
            //
            grdPunchList.Location = new Point(20, 40);
            grdPunchList.MainView = gvPunchList;
            grdPunchList.Name = "grdPunchList";
            grdPunchList.Size = new Size(800, 320);
            grdPunchList.TabIndex = 1;
            grdPunchList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvPunchList });
            //
            // gvPunchList
            //
            gvPunchList.Appearance.HeaderPanel.Font = new Font("Cairo", 8F, FontStyle.Bold);
            gvPunchList.Appearance.HeaderPanel.Options.UseFont = true;
            gvPunchList.Appearance.Row.Font = new Font("Cairo", 8F);
            gvPunchList.Appearance.Row.Options.UseFont = true;
            gvPunchList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPunchItem, colPunchLocation, colPunchResponsible, colPunchStatus });
            gvPunchList.GridControl = grdPunchList;
            gvPunchList.Name = "gvPunchList";
            gvPunchList.OptionsView.ShowGroupPanel = false;
            //
            // colPunchItem
            //
            colPunchItem.Caption = "الملاحظة";
            colPunchItem.FieldName = "PunchItem";
            colPunchItem.Name = "colPunchItem";
            colPunchItem.Visible = true;
            colPunchItem.VisibleIndex = 0;
            colPunchItem.Width = 320;
            //
            // colPunchLocation
            //
            colPunchLocation.Caption = "الموقع";
            colPunchLocation.FieldName = "Location";
            colPunchLocation.Name = "colPunchLocation";
            colPunchLocation.Visible = true;
            colPunchLocation.VisibleIndex = 1;
            colPunchLocation.Width = 180;
            //
            // colPunchResponsible
            //
            colPunchResponsible.Caption = "المسؤول";
            colPunchResponsible.FieldName = "Responsible";
            colPunchResponsible.Name = "colPunchResponsible";
            colPunchResponsible.Visible = true;
            colPunchResponsible.VisibleIndex = 2;
            colPunchResponsible.Width = 160;
            //
            // colPunchStatus
            //
            colPunchStatus.Caption = "الحالة";
            colPunchStatus.FieldName = "Status";
            colPunchStatus.Name = "colPunchStatus";
            colPunchStatus.Visible = true;
            colPunchStatus.VisibleIndex = 3;
            colPunchStatus.Width = 130;
            //
            // wizPageHandover
            //
            wizPageHandover.Controls.Add(memoHandoverNotes);
            wizPageHandover.Controls.Add(lblHandoverNotes);
            wizPageHandover.Controls.Add(txtHandoverTo);
            wizPageHandover.Controls.Add(lblHandoverTo);
            wizPageHandover.Controls.Add(dtHandoverDate);
            wizPageHandover.Controls.Add(lblHandoverDate);
            wizPageHandover.DescriptionText = "بيانات تسليم المشروع للمالك";
            wizPageHandover.Name = "wizPageHandover";
            wizPageHandover.Size = new Size(860, 380);
            wizPageHandover.Text = "التسليم";
            //
            // lblHandoverDate
            //
            lblHandoverDate.Appearance.Font = new Font("Cairo", 8F);
            lblHandoverDate.Appearance.Options.UseFont = true;
            lblHandoverDate.Location = new Point(20, 20);
            lblHandoverDate.Name = "lblHandoverDate";
            lblHandoverDate.Size = new Size(64, 17);
            lblHandoverDate.TabIndex = 0;
            lblHandoverDate.Text = "تاريخ التسليم";
            //
            // dtHandoverDate
            //
            dtHandoverDate.EditValue = null;
            dtHandoverDate.Location = new Point(20, 38);
            dtHandoverDate.Name = "dtHandoverDate";
            dtHandoverDate.Properties.Appearance.Font = new Font("Cairo", 9F);
            dtHandoverDate.Properties.Appearance.Options.UseFont = true;
            dtHandoverDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtHandoverDate.Size = new Size(380, 28);
            dtHandoverDate.TabIndex = 1;
            //
            // lblHandoverTo
            //
            lblHandoverTo.Appearance.Font = new Font("Cairo", 8F);
            lblHandoverTo.Appearance.Options.UseFont = true;
            lblHandoverTo.Location = new Point(440, 20);
            lblHandoverTo.Name = "lblHandoverTo";
            lblHandoverTo.Size = new Size(63, 17);
            lblHandoverTo.TabIndex = 2;
            lblHandoverTo.Text = "التسليم إلى";
            //
            // txtHandoverTo
            //
            txtHandoverTo.Location = new Point(440, 38);
            txtHandoverTo.Name = "txtHandoverTo";
            txtHandoverTo.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtHandoverTo.Properties.Appearance.Options.UseFont = true;
            txtHandoverTo.Size = new Size(380, 28);
            txtHandoverTo.TabIndex = 3;
            //
            // lblHandoverNotes
            //
            lblHandoverNotes.Appearance.Font = new Font("Cairo", 8F);
            lblHandoverNotes.Appearance.Options.UseFont = true;
            lblHandoverNotes.Location = new Point(20, 74);
            lblHandoverNotes.Name = "lblHandoverNotes";
            lblHandoverNotes.Size = new Size(72, 17);
            lblHandoverNotes.TabIndex = 4;
            lblHandoverNotes.Text = "ملاحظات التسليم";
            //
            // memoHandoverNotes
            //
            memoHandoverNotes.Location = new Point(20, 92);
            memoHandoverNotes.Name = "memoHandoverNotes";
            memoHandoverNotes.Properties.Appearance.Font = new Font("Cairo", 9F);
            memoHandoverNotes.Properties.Appearance.Options.UseFont = true;
            memoHandoverNotes.Size = new Size(800, 200);
            memoHandoverNotes.TabIndex = 5;
            //
            // wizPageFinalAccount
            //
            wizPageFinalAccount.Controls.Add(calcFinalAccountValue);
            wizPageFinalAccount.Controls.Add(lblFinalAccountValue);
            wizPageFinalAccount.Controls.Add(calcTotalVariations);
            wizPageFinalAccount.Controls.Add(lblTotalVariations);
            wizPageFinalAccount.Controls.Add(calcFinalContractValue);
            wizPageFinalAccount.Controls.Add(lblFinalContractValue);
            wizPageFinalAccount.DescriptionText = "الحساب الختامي للعقد";
            wizPageFinalAccount.Name = "wizPageFinalAccount";
            wizPageFinalAccount.Size = new Size(860, 380);
            wizPageFinalAccount.Text = "الحساب الختامي";
            //
            // lblFinalContractValue
            //
            lblFinalContractValue.Appearance.Font = new Font("Cairo", 8F);
            lblFinalContractValue.Appearance.Options.UseFont = true;
            lblFinalContractValue.Location = new Point(20, 20);
            lblFinalContractValue.Name = "lblFinalContractValue";
            lblFinalContractValue.Size = new Size(84, 17);
            lblFinalContractValue.TabIndex = 0;
            lblFinalContractValue.Text = "القيمة النهائية للعقد";
            //
            // calcFinalContractValue
            //
            calcFinalContractValue.EditValue = null;
            calcFinalContractValue.Location = new Point(20, 38);
            calcFinalContractValue.Name = "calcFinalContractValue";
            calcFinalContractValue.Properties.Appearance.Font = new Font("Cairo", 9F);
            calcFinalContractValue.Properties.Appearance.Options.UseFont = true;
            calcFinalContractValue.Properties.DisplayFormat.FormatString = "N2";
            calcFinalContractValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcFinalContractValue.Properties.EditFormat.FormatString = "N2";
            calcFinalContractValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcFinalContractValue.Size = new Size(380, 28);
            calcFinalContractValue.TabIndex = 1;
            //
            // lblTotalVariations
            //
            lblTotalVariations.Appearance.Font = new Font("Cairo", 8F);
            lblTotalVariations.Appearance.Options.UseFont = true;
            lblTotalVariations.Location = new Point(440, 20);
            lblTotalVariations.Name = "lblTotalVariations";
            lblTotalVariations.Size = new Size(90, 17);
            lblTotalVariations.TabIndex = 2;
            lblTotalVariations.Text = "إجمالي أوامر التغيير";
            //
            // calcTotalVariations
            //
            calcTotalVariations.EditValue = null;
            calcTotalVariations.Location = new Point(440, 38);
            calcTotalVariations.Name = "calcTotalVariations";
            calcTotalVariations.Properties.Appearance.Font = new Font("Cairo", 9F);
            calcTotalVariations.Properties.Appearance.Options.UseFont = true;
            calcTotalVariations.Properties.DisplayFormat.FormatString = "N2";
            calcTotalVariations.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcTotalVariations.Properties.EditFormat.FormatString = "N2";
            calcTotalVariations.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcTotalVariations.Size = new Size(380, 28);
            calcTotalVariations.TabIndex = 3;
            //
            // lblFinalAccountValue
            //
            lblFinalAccountValue.Appearance.Font = new Font("Cairo", 8F);
            lblFinalAccountValue.Appearance.Options.UseFont = true;
            lblFinalAccountValue.Location = new Point(20, 74);
            lblFinalAccountValue.Name = "lblFinalAccountValue";
            lblFinalAccountValue.Size = new Size(76, 17);
            lblFinalAccountValue.TabIndex = 4;
            lblFinalAccountValue.Text = "قيمة الحساب الختامي";
            //
            // calcFinalAccountValue
            //
            calcFinalAccountValue.EditValue = null;
            calcFinalAccountValue.Location = new Point(20, 92);
            calcFinalAccountValue.Name = "calcFinalAccountValue";
            calcFinalAccountValue.Properties.Appearance.Font = new Font("Cairo", 9F);
            calcFinalAccountValue.Properties.Appearance.Options.UseFont = true;
            calcFinalAccountValue.Properties.DisplayFormat.FormatString = "N2";
            calcFinalAccountValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcFinalAccountValue.Properties.EditFormat.FormatString = "N2";
            calcFinalAccountValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcFinalAccountValue.Size = new Size(380, 28);
            calcFinalAccountValue.TabIndex = 5;
            //
            // wizPageRetention
            //
            wizPageRetention.Controls.Add(dtRetentionReleaseDate);
            wizPageRetention.Controls.Add(lblRetentionReleaseDate);
            wizPageRetention.Controls.Add(spinRetentionPercent);
            wizPageRetention.Controls.Add(lblRetentionPercent);
            wizPageRetention.Controls.Add(calcRetentionAmount);
            wizPageRetention.Controls.Add(lblRetentionAmount);
            wizPageRetention.DescriptionText = "بيانات الضمان المحتجز وموعد الإفراج عنه";
            wizPageRetention.Name = "wizPageRetention";
            wizPageRetention.Size = new Size(860, 380);
            wizPageRetention.Text = "الضمان المحتجز";
            //
            // lblRetentionAmount
            //
            lblRetentionAmount.Appearance.Font = new Font("Cairo", 8F);
            lblRetentionAmount.Appearance.Options.UseFont = true;
            lblRetentionAmount.Location = new Point(20, 20);
            lblRetentionAmount.Name = "lblRetentionAmount";
            lblRetentionAmount.Size = new Size(93, 17);
            lblRetentionAmount.TabIndex = 0;
            lblRetentionAmount.Text = "قيمة الضمان المحتجز";
            //
            // calcRetentionAmount
            //
            calcRetentionAmount.EditValue = null;
            calcRetentionAmount.Location = new Point(20, 38);
            calcRetentionAmount.Name = "calcRetentionAmount";
            calcRetentionAmount.Properties.Appearance.Font = new Font("Cairo", 9F);
            calcRetentionAmount.Properties.Appearance.Options.UseFont = true;
            calcRetentionAmount.Properties.DisplayFormat.FormatString = "N2";
            calcRetentionAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcRetentionAmount.Properties.EditFormat.FormatString = "N2";
            calcRetentionAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            calcRetentionAmount.Size = new Size(380, 28);
            calcRetentionAmount.TabIndex = 1;
            //
            // lblRetentionPercent
            //
            lblRetentionPercent.Appearance.Font = new Font("Cairo", 8F);
            lblRetentionPercent.Appearance.Options.UseFont = true;
            lblRetentionPercent.Location = new Point(440, 20);
            lblRetentionPercent.Name = "lblRetentionPercent";
            lblRetentionPercent.Size = new Size(89, 17);
            lblRetentionPercent.TabIndex = 2;
            lblRetentionPercent.Text = "نسبة الضمان المحتجز %";
            //
            // spinRetentionPercent
            //
            spinRetentionPercent.EditValue = 0.0;
            spinRetentionPercent.Location = new Point(440, 38);
            spinRetentionPercent.Name = "spinRetentionPercent";
            spinRetentionPercent.Properties.Appearance.Font = new Font("Cairo", 9F);
            spinRetentionPercent.Properties.Appearance.Options.UseFont = true;
            spinRetentionPercent.Properties.DisplayFormat.FormatString = "N2";
            spinRetentionPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            spinRetentionPercent.Properties.EditFormat.FormatString = "N2";
            spinRetentionPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            spinRetentionPercent.Properties.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            spinRetentionPercent.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            spinRetentionPercent.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            spinRetentionPercent.Size = new Size(380, 28);
            spinRetentionPercent.TabIndex = 3;
            //
            // lblRetentionReleaseDate
            //
            lblRetentionReleaseDate.Appearance.Font = new Font("Cairo", 8F);
            lblRetentionReleaseDate.Appearance.Options.UseFont = true;
            lblRetentionReleaseDate.Location = new Point(20, 74);
            lblRetentionReleaseDate.Name = "lblRetentionReleaseDate";
            lblRetentionReleaseDate.Size = new Size(103, 17);
            lblRetentionReleaseDate.TabIndex = 4;
            lblRetentionReleaseDate.Text = "تاريخ الإفراج عن الضمان";
            //
            // dtRetentionReleaseDate
            //
            dtRetentionReleaseDate.EditValue = null;
            dtRetentionReleaseDate.Location = new Point(20, 92);
            dtRetentionReleaseDate.Name = "dtRetentionReleaseDate";
            dtRetentionReleaseDate.Properties.Appearance.Font = new Font("Cairo", 9F);
            dtRetentionReleaseDate.Properties.Appearance.Options.UseFont = true;
            dtRetentionReleaseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtRetentionReleaseDate.Size = new Size(380, 28);
            dtRetentionReleaseDate.TabIndex = 5;
            //
            // wizPageLessonsLearned
            //
            wizPageLessonsLearned.Controls.Add(memoLessonsLearned);
            wizPageLessonsLearned.Controls.Add(lblLessonsLearned);
            wizPageLessonsLearned.DescriptionText = "توثيق الدروس المستفادة من تنفيذ المشروع";
            wizPageLessonsLearned.Name = "wizPageLessonsLearned";
            wizPageLessonsLearned.Size = new Size(860, 380);
            wizPageLessonsLearned.Text = "الدروس المستفادة";
            //
            // lblLessonsLearned
            //
            lblLessonsLearned.Appearance.Font = new Font("Cairo", 8F);
            lblLessonsLearned.Appearance.Options.UseFont = true;
            lblLessonsLearned.Location = new Point(20, 20);
            lblLessonsLearned.Name = "lblLessonsLearned";
            lblLessonsLearned.Size = new Size(80, 17);
            lblLessonsLearned.TabIndex = 0;
            lblLessonsLearned.Text = "الدروس المستفادة";
            //
            // memoLessonsLearned
            //
            memoLessonsLearned.Location = new Point(20, 40);
            memoLessonsLearned.Name = "memoLessonsLearned";
            memoLessonsLearned.Properties.Appearance.Font = new Font("Cairo", 9F);
            memoLessonsLearned.Properties.Appearance.Options.UseFont = true;
            memoLessonsLearned.Size = new Size(800, 320);
            memoLessonsLearned.TabIndex = 1;
            //
            // wizPageArchive
            //
            wizPageArchive.AllowFinish = true;
            wizPageArchive.Controls.Add(txtArchivedBy);
            wizPageArchive.Controls.Add(lblArchivedBy);
            wizPageArchive.Controls.Add(dtArchiveDate);
            wizPageArchive.Controls.Add(lblArchiveDate);
            wizPageArchive.Controls.Add(txtArchiveLocation);
            wizPageArchive.Controls.Add(lblArchiveLocation);
            wizPageArchive.DescriptionText = "أرشفة ملفات المشروع بعد اكتمال الإغلاق";
            wizPageArchive.Name = "wizPageArchive";
            wizPageArchive.Size = new Size(860, 380);
            wizPageArchive.Text = "الأرشفة";
            //
            // lblArchiveLocation
            //
            lblArchiveLocation.Appearance.Font = new Font("Cairo", 8F);
            lblArchiveLocation.Appearance.Options.UseFont = true;
            lblArchiveLocation.Location = new Point(20, 20);
            lblArchiveLocation.Name = "lblArchiveLocation";
            lblArchiveLocation.Size = new Size(66, 17);
            lblArchiveLocation.TabIndex = 0;
            lblArchiveLocation.Text = "موقع الأرشفة";
            //
            // txtArchiveLocation
            //
            txtArchiveLocation.Location = new Point(20, 38);
            txtArchiveLocation.Name = "txtArchiveLocation";
            txtArchiveLocation.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtArchiveLocation.Properties.Appearance.Options.UseFont = true;
            txtArchiveLocation.Size = new Size(380, 28);
            txtArchiveLocation.TabIndex = 1;
            //
            // lblArchiveDate
            //
            lblArchiveDate.Appearance.Font = new Font("Cairo", 8F);
            lblArchiveDate.Appearance.Options.UseFont = true;
            lblArchiveDate.Location = new Point(440, 20);
            lblArchiveDate.Name = "lblArchiveDate";
            lblArchiveDate.Size = new Size(69, 17);
            lblArchiveDate.TabIndex = 2;
            lblArchiveDate.Text = "تاريخ الأرشفة";
            //
            // dtArchiveDate
            //
            dtArchiveDate.EditValue = null;
            dtArchiveDate.Location = new Point(440, 38);
            dtArchiveDate.Name = "dtArchiveDate";
            dtArchiveDate.Properties.Appearance.Font = new Font("Cairo", 9F);
            dtArchiveDate.Properties.Appearance.Options.UseFont = true;
            dtArchiveDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtArchiveDate.Size = new Size(380, 28);
            dtArchiveDate.TabIndex = 3;
            //
            // lblArchivedBy
            //
            lblArchivedBy.Appearance.Font = new Font("Cairo", 8F);
            lblArchivedBy.Appearance.Options.UseFont = true;
            lblArchivedBy.Location = new Point(20, 74);
            lblArchivedBy.Name = "lblArchivedBy";
            lblArchivedBy.Size = new Size(52, 17);
            lblArchivedBy.TabIndex = 4;
            lblArchivedBy.Text = "أرشفه بواسطة";
            //
            // txtArchivedBy
            //
            txtArchivedBy.Location = new Point(20, 92);
            txtArchivedBy.Name = "txtArchivedBy";
            txtArchivedBy.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtArchivedBy.Properties.Appearance.Options.UseFont = true;
            txtArchivedBy.Size = new Size(380, 28);
            txtArchivedBy.TabIndex = 5;
            //
            // wizCloseout
            //
            wizCloseout.Dock = DockStyle.Fill;
            wizCloseout.Location = new Point(0, 0);
            wizCloseout.Name = "wizCloseout";
            wizCloseout.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] { wizPageDocuments, wizPagePunchList, wizPageHandover, wizPageFinalAccount, wizPageRetention, wizPageLessonsLearned, wizPageArchive });
            wizCloseout.Size = new Size(900, 640);
            wizCloseout.TabIndex = 0;
            wizCloseout.Text = "معالج إغلاق المشروع";
            wizCloseout.FinishClick += wizCloseout_FinishClick;
            wizCloseout.CancelClick += wizCloseout_CancelClick;
            //
            // frmProjectCloseoutWizard
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 640);
            Controls.Add(wizCloseout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProjectCloseoutWizard";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "معالج إغلاق المشروع";

            wizPageDocuments.ResumeLayout(false);
            wizPageDocuments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdCloseoutDocuments).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCloseoutDocuments).EndInit();

            wizPagePunchList.ResumeLayout(false);
            wizPagePunchList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdPunchList).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvPunchList).EndInit();

            wizPageHandover.ResumeLayout(false);
            wizPageHandover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtHandoverDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtHandoverDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHandoverTo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoHandoverNotes.Properties).EndInit();

            wizPageFinalAccount.ResumeLayout(false);
            wizPageFinalAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)calcFinalContractValue.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcTotalVariations.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcFinalAccountValue.Properties).EndInit();

            wizPageRetention.ResumeLayout(false);
            wizPageRetention.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)calcRetentionAmount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinRetentionPercent.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtRetentionReleaseDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtRetentionReleaseDate.Properties).EndInit();

            wizPageLessonsLearned.ResumeLayout(false);
            wizPageLessonsLearned.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)memoLessonsLearned.Properties).EndInit();

            wizPageArchive.ResumeLayout(false);
            wizPageArchive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtArchiveLocation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtArchiveDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtArchiveDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtArchivedBy.Properties).EndInit();

            ((System.ComponentModel.ISupportInitialize)wizCloseout).EndInit();
            wizCloseout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizCloseout;

        private DevExpress.XtraWizard.WizardPage wizPageDocuments;
        private DevExpress.XtraEditors.LabelControl lblCloseoutDocuments;
        private DevExpress.XtraGrid.GridControl grdCloseoutDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCloseoutDocuments;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentName;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentType;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentStatus;

        private DevExpress.XtraWizard.WizardPage wizPagePunchList;
        private DevExpress.XtraEditors.LabelControl lblPunchList;
        private DevExpress.XtraGrid.GridControl grdPunchList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPunchList;
        private DevExpress.XtraGrid.Columns.GridColumn colPunchItem;
        private DevExpress.XtraGrid.Columns.GridColumn colPunchLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colPunchResponsible;
        private DevExpress.XtraGrid.Columns.GridColumn colPunchStatus;

        private DevExpress.XtraWizard.WizardPage wizPageHandover;
        private DevExpress.XtraEditors.LabelControl lblHandoverDate;
        private DevExpress.XtraEditors.DateEdit dtHandoverDate;
        private DevExpress.XtraEditors.LabelControl lblHandoverTo;
        private DevExpress.XtraEditors.TextEdit txtHandoverTo;
        private DevExpress.XtraEditors.LabelControl lblHandoverNotes;
        private DevExpress.XtraEditors.MemoEdit memoHandoverNotes;

        private DevExpress.XtraWizard.WizardPage wizPageFinalAccount;
        private DevExpress.XtraEditors.LabelControl lblFinalContractValue;
        private DevExpress.XtraEditors.CalcEdit calcFinalContractValue;
        private DevExpress.XtraEditors.LabelControl lblTotalVariations;
        private DevExpress.XtraEditors.CalcEdit calcTotalVariations;
        private DevExpress.XtraEditors.LabelControl lblFinalAccountValue;
        private DevExpress.XtraEditors.CalcEdit calcFinalAccountValue;

        private DevExpress.XtraWizard.WizardPage wizPageRetention;
        private DevExpress.XtraEditors.LabelControl lblRetentionAmount;
        private DevExpress.XtraEditors.CalcEdit calcRetentionAmount;
        private DevExpress.XtraEditors.LabelControl lblRetentionPercent;
        private DevExpress.XtraEditors.SpinEdit spinRetentionPercent;
        private DevExpress.XtraEditors.LabelControl lblRetentionReleaseDate;
        private DevExpress.XtraEditors.DateEdit dtRetentionReleaseDate;

        private DevExpress.XtraWizard.WizardPage wizPageLessonsLearned;
        private DevExpress.XtraEditors.LabelControl lblLessonsLearned;
        private DevExpress.XtraEditors.MemoEdit memoLessonsLearned;

        private DevExpress.XtraWizard.WizardPage wizPageArchive;
        private DevExpress.XtraEditors.LabelControl lblArchiveLocation;
        private DevExpress.XtraEditors.TextEdit txtArchiveLocation;
        private DevExpress.XtraEditors.LabelControl lblArchiveDate;
        private DevExpress.XtraEditors.DateEdit dtArchiveDate;
        private DevExpress.XtraEditors.LabelControl lblArchivedBy;
        private DevExpress.XtraEditors.TextEdit txtArchivedBy;
    }
}
