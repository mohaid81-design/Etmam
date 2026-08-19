namespace Etmam
{
    partial class frmCIRAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCIRAction));
            lueProject = new DevExpress.XtraEditors.LookUpEdit();
            lblProject = new DevExpress.XtraEditors.LabelControl();
            lblRegisterNo = new DevExpress.XtraEditors.LabelControl();
            txtRegisterNo = new DevExpress.XtraEditors.TextEdit();
            lblDiscipline = new DevExpress.XtraEditors.LabelControl();
            lueDiscipline = new DevExpress.XtraEditors.LookUpEdit();
            lblRev = new DevExpress.XtraEditors.LabelControl();
            txtRev = new DevExpress.XtraEditors.TextEdit();
            lblNum = new DevExpress.XtraEditors.LabelControl();
            txtNum = new DevExpress.XtraEditors.TextEdit();
            memCSTReviewComment = new DevExpress.XtraEditors.MemoEdit();
            lblCSTReviewComment = new DevExpress.XtraEditors.LabelControl();
            lblCSTReviewStatus = new DevExpress.XtraEditors.LabelControl();
            cboCSTReviewStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            btnCancelAction = new DevExpress.XtraEditors.SimpleButton();
            lblSubmittedDate = new DevExpress.XtraEditors.LabelControl();
            dtPreparedDate = new DevExpress.XtraEditors.DateEdit();
            lblCSTReviewDate = new DevExpress.XtraEditors.LabelControl();
            dtCSTReviewDate = new DevExpress.XtraEditors.DateEdit();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            lblPreparedDate = new DevExpress.XtraEditors.LabelControl();
            dtSubmittedDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRegisterNo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueDiscipline.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRev.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memCSTReviewComment.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboCSTReviewStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtPreparedDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtPreparedDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtCSTReviewDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtCSTReviewDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtSubmittedDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtSubmittedDate.Properties.CalendarTimeProperties).BeginInit();
            SuspendLayout();
            // 
            // lueProject
            // 
            lueProject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lueProject.Enabled = false;
            lueProject.Location = new Point(57, 45);
            lueProject.Margin = new Padding(3, 5, 3, 5);
            lueProject.Name = "lueProject";
            lueProject.Properties.Appearance.BackColor = SystemColors.ControlLight;
            lueProject.Properties.Appearance.Font = new Font("Cairo", 8F);
            lueProject.Properties.Appearance.Options.UseBackColor = true;
            lueProject.Properties.Appearance.Options.UseFont = true;
            lueProject.Properties.AutoHeight = false;
            lueProject.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lueProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueProject.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name") });
            lueProject.Properties.DisplayMember = "Name";
            lueProject.Properties.NullText = "";
            lueProject.Properties.ShowHeader = false;
            lueProject.Properties.ValueMember = "Id";
            lueProject.Size = new Size(283, 31);
            lueProject.TabIndex = 64;
            // 
            // lblProject
            // 
            lblProject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblProject.Appearance.Font = new Font("Cairo", 8.5F);
            lblProject.Appearance.Options.UseFont = true;
            lblProject.Location = new Point(348, 48);
            lblProject.Margin = new Padding(3, 5, 3, 5);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(69, 23);
            lblProject.TabIndex = 73;
            lblProject.Text = "اسم المشروع:";
            // 
            // lblRegisterNo
            // 
            lblRegisterNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRegisterNo.Appearance.Font = new Font("Cairo", 8.5F);
            lblRegisterNo.Appearance.Options.UseFont = true;
            lblRegisterNo.Location = new Point(348, 185);
            lblRegisterNo.Margin = new Padding(3, 5, 3, 5);
            lblRegisterNo.Name = "lblRegisterNo";
            lblRegisterNo.Size = new Size(68, 23);
            lblRegisterNo.TabIndex = 71;
            lblRegisterNo.Text = "الرقم الدفتري:";
            // 
            // txtRegisterNo
            // 
            txtRegisterNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRegisterNo.Enabled = false;
            txtRegisterNo.Location = new Point(57, 180);
            txtRegisterNo.Margin = new Padding(3, 5, 3, 5);
            txtRegisterNo.Name = "txtRegisterNo";
            txtRegisterNo.Properties.Appearance.BackColor = SystemColors.ControlLight;
            txtRegisterNo.Properties.Appearance.Font = new Font("Cairo", 8F);
            txtRegisterNo.Properties.Appearance.Options.UseBackColor = true;
            txtRegisterNo.Properties.Appearance.Options.UseFont = true;
            txtRegisterNo.Properties.AutoHeight = false;
            txtRegisterNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            txtRegisterNo.Size = new Size(283, 31);
            txtRegisterNo.TabIndex = 72;
            // 
            // lblDiscipline
            // 
            lblDiscipline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDiscipline.Appearance.Font = new Font("Cairo", 8.5F);
            lblDiscipline.Appearance.Options.UseFont = true;
            lblDiscipline.Appearance.Options.UseTextOptions = true;
            lblDiscipline.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lblDiscipline.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblDiscipline.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblDiscipline.Location = new Point(348, 80);
            lblDiscipline.Margin = new Padding(3, 8, 3, 8);
            lblDiscipline.Name = "lblDiscipline";
            lblDiscipline.Size = new Size(69, 28);
            lblDiscipline.TabIndex = 70;
            lblDiscipline.Text = "التخصص:";
            // 
            // lueDiscipline
            // 
            lueDiscipline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lueDiscipline.Enabled = false;
            lueDiscipline.Location = new Point(57, 78);
            lueDiscipline.Margin = new Padding(3, 8, 3, 8);
            lueDiscipline.Name = "lueDiscipline";
            lueDiscipline.Properties.Appearance.BackColor = SystemColors.ControlLight;
            lueDiscipline.Properties.Appearance.Font = new Font("Cairo", 8F);
            lueDiscipline.Properties.Appearance.Options.UseBackColor = true;
            lueDiscipline.Properties.Appearance.Options.UseFont = true;
            lueDiscipline.Properties.AutoHeight = false;
            lueDiscipline.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lueDiscipline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueDiscipline.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1") });
            lueDiscipline.Properties.NullText = "";
            lueDiscipline.Properties.PopupSizeable = false;
            lueDiscipline.Properties.ShowHeader = false;
            lueDiscipline.Size = new Size(283, 31);
            lueDiscipline.TabIndex = 65;
            // 
            // lblRev
            // 
            lblRev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRev.Appearance.Font = new Font("Cairo", 8.5F);
            lblRev.Appearance.Options.UseFont = true;
            lblRev.Location = new Point(348, 151);
            lblRev.Margin = new Padding(3, 5, 3, 5);
            lblRev.Name = "lblRev";
            lblRev.Size = new Size(43, 23);
            lblRev.TabIndex = 68;
            lblRev.Text = "الإصداره:";
            // 
            // txtRev
            // 
            txtRev.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRev.Enabled = false;
            txtRev.Location = new Point(57, 146);
            txtRev.Margin = new Padding(3, 5, 3, 5);
            txtRev.Name = "txtRev";
            txtRev.Properties.Appearance.BackColor = SystemColors.ControlLight;
            txtRev.Properties.Appearance.Font = new Font("Cairo", 8F);
            txtRev.Properties.Appearance.Options.UseBackColor = true;
            txtRev.Properties.Appearance.Options.UseFont = true;
            txtRev.Properties.AutoHeight = false;
            txtRev.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            txtRev.Size = new Size(283, 31);
            txtRev.TabIndex = 69;
            // 
            // lblNum
            // 
            lblNum.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNum.Appearance.Font = new Font("Cairo", 8.5F);
            lblNum.Appearance.Options.UseFont = true;
            lblNum.Location = new Point(348, 115);
            lblNum.Margin = new Padding(3, 5, 3, 5);
            lblNum.Name = "lblNum";
            lblNum.Size = new Size(59, 23);
            lblNum.TabIndex = 66;
            lblNum.Text = "رقم التقديم:";
            // 
            // txtNum
            // 
            txtNum.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNum.Enabled = false;
            txtNum.Location = new Point(57, 112);
            txtNum.Margin = new Padding(3, 5, 3, 5);
            txtNum.Name = "txtNum";
            txtNum.Properties.Appearance.BackColor = SystemColors.ControlLight;
            txtNum.Properties.Appearance.Font = new Font("Cairo", 8F);
            txtNum.Properties.Appearance.Options.UseBackColor = true;
            txtNum.Properties.Appearance.Options.UseFont = true;
            txtNum.Properties.AutoHeight = false;
            txtNum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            txtNum.Size = new Size(283, 31);
            txtNum.TabIndex = 67;
            // 
            // memCSTReviewComment
            // 
            memCSTReviewComment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memCSTReviewComment.Location = new Point(40, 349);
            memCSTReviewComment.Margin = new Padding(3, 5, 3, 5);
            memCSTReviewComment.Name = "memCSTReviewComment";
            memCSTReviewComment.Properties.Appearance.BackColor = Color.LightGreen;
            memCSTReviewComment.Properties.Appearance.Font = new Font("Cairo", 8F);
            memCSTReviewComment.Properties.Appearance.Options.UseBackColor = true;
            memCSTReviewComment.Properties.Appearance.Options.UseFont = true;
            memCSTReviewComment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            memCSTReviewComment.Size = new Size(300, 205);
            memCSTReviewComment.TabIndex = 74;
            // 
            // lblCSTReviewComment
            // 
            lblCSTReviewComment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCSTReviewComment.Appearance.Font = new Font("Cairo", 8.5F);
            lblCSTReviewComment.Appearance.Options.UseFont = true;
            lblCSTReviewComment.Location = new Point(348, 363);
            lblCSTReviewComment.Margin = new Padding(3, 5, 3, 5);
            lblCSTReviewComment.Name = "lblCSTReviewComment";
            lblCSTReviewComment.Size = new Size(94, 23);
            lblCSTReviewComment.TabIndex = 75;
            lblCSTReviewComment.Text = "ملاحظات المراجعه:";
            // 
            // lblCSTReviewStatus
            // 
            lblCSTReviewStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCSTReviewStatus.Appearance.Font = new Font("Cairo", 8.5F);
            lblCSTReviewStatus.Appearance.Options.UseFont = true;
            lblCSTReviewStatus.Location = new Point(348, 320);
            lblCSTReviewStatus.Margin = new Padding(3, 5, 3, 5);
            lblCSTReviewStatus.Name = "lblCSTReviewStatus";
            lblCSTReviewStatus.Size = new Size(70, 23);
            lblCSTReviewStatus.TabIndex = 77;
            lblCSTReviewStatus.Text = "حالة المراجعه:";
            // 
            // cboCSTReviewStatus
            // 
            cboCSTReviewStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboCSTReviewStatus.Location = new Point(57, 315);
            cboCSTReviewStatus.Margin = new Padding(3, 5, 3, 5);
            cboCSTReviewStatus.Name = "cboCSTReviewStatus";
            cboCSTReviewStatus.Properties.Appearance.BackColor = Color.LightGreen;
            cboCSTReviewStatus.Properties.Appearance.Font = new Font("Cairo", 8F);
            cboCSTReviewStatus.Properties.Appearance.Options.UseBackColor = true;
            cboCSTReviewStatus.Properties.Appearance.Options.UseFont = true;
            cboCSTReviewStatus.Properties.AutoHeight = false;
            cboCSTReviewStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            cboCSTReviewStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cboCSTReviewStatus.Properties.Items.AddRange(new object[] { "يعتمد (A)", "يعتمد مع الملاحظات (B)", "يراجع و يعاد تقديمه (C)", "مرفوض (D)" });
            cboCSTReviewStatus.Properties.PopupSizeable = true;
            cboCSTReviewStatus.Size = new Size(283, 31);
            cboCSTReviewStatus.TabIndex = 76;
            // 
            // btnSaveClose
            // 
            btnSaveClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveClose.Appearance.Font = new Font("Cairo", 8.5F);
            btnSaveClose.Appearance.Options.UseFont = true;
            btnSaveClose.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSaveClose.ImageOptions.SvgImage");
            btnSaveClose.ImageOptions.SvgImageSize = new Size(20, 20);
            btnSaveClose.Location = new Point(18, 598);
            btnSaveClose.Name = "btnSaveClose";
            btnSaveClose.Size = new Size(135, 31);
            btnSaveClose.TabIndex = 78;
            btnSaveClose.Text = "حفظ و إغلاق";
            // 
            // btnCancelAction
            // 
            btnCancelAction.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelAction.Appearance.Font = new Font("Cairo", 8.5F);
            btnCancelAction.Appearance.Options.UseFont = true;
            btnCancelAction.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancelAction.ImageOptions.SvgImage");
            btnCancelAction.ImageOptions.SvgImageSize = new Size(20, 20);
            btnCancelAction.Location = new Point(166, 598);
            btnCancelAction.Name = "btnCancelAction";
            btnCancelAction.Size = new Size(135, 31);
            btnCancelAction.TabIndex = 79;
            btnCancelAction.Text = "إلغاء الإجراء";
            // 
            // lblSubmittedDate
            // 
            lblSubmittedDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSubmittedDate.Appearance.Font = new Font("Cairo", 8.5F);
            lblSubmittedDate.Appearance.Options.UseFont = true;
            lblSubmittedDate.Location = new Point(348, 252);
            lblSubmittedDate.Margin = new Padding(3, 5, 3, 5);
            lblSubmittedDate.Name = "lblSubmittedDate";
            lblSubmittedDate.Size = new Size(63, 23);
            lblSubmittedDate.TabIndex = 81;
            lblSubmittedDate.Text = "تاريخ التقديم:";
            // 
            // dtPreparedDate
            // 
            dtPreparedDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtPreparedDate.EditValue = null;
            dtPreparedDate.Enabled = false;
            dtPreparedDate.Location = new Point(57, 214);
            dtPreparedDate.Margin = new Padding(3, 5, 3, 5);
            dtPreparedDate.Name = "dtPreparedDate";
            dtPreparedDate.Properties.Appearance.BackColor = SystemColors.ControlLight;
            dtPreparedDate.Properties.Appearance.Font = new Font("Cairo", 8F);
            dtPreparedDate.Properties.Appearance.Options.UseBackColor = true;
            dtPreparedDate.Properties.Appearance.Options.UseFont = true;
            dtPreparedDate.Properties.AutoHeight = false;
            dtPreparedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            dtPreparedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtPreparedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtPreparedDate.Size = new Size(283, 31);
            dtPreparedDate.TabIndex = 80;
            // 
            // lblCSTReviewDate
            // 
            lblCSTReviewDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCSTReviewDate.Appearance.Font = new Font("Cairo", 8.5F);
            lblCSTReviewDate.Appearance.Options.UseFont = true;
            lblCSTReviewDate.Location = new Point(348, 286);
            lblCSTReviewDate.Margin = new Padding(3, 5, 3, 5);
            lblCSTReviewDate.Name = "lblCSTReviewDate";
            lblCSTReviewDate.Size = new Size(71, 23);
            lblCSTReviewDate.TabIndex = 83;
            lblCSTReviewDate.Text = "تاريخ المراجعه:";
            // 
            // dtCSTReviewDate
            // 
            dtCSTReviewDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtCSTReviewDate.EditValue = null;
            dtCSTReviewDate.Location = new Point(57, 282);
            dtCSTReviewDate.Margin = new Padding(3, 5, 3, 5);
            dtCSTReviewDate.Name = "dtCSTReviewDate";
            dtCSTReviewDate.Properties.Appearance.BackColor = Color.LightGreen;
            dtCSTReviewDate.Properties.Appearance.Font = new Font("Cairo", 8F);
            dtCSTReviewDate.Properties.Appearance.Options.UseBackColor = true;
            dtCSTReviewDate.Properties.Appearance.Options.UseFont = true;
            dtCSTReviewDate.Properties.AutoHeight = false;
            dtCSTReviewDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            dtCSTReviewDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtCSTReviewDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtCSTReviewDate.Size = new Size(283, 31);
            dtCSTReviewDate.TabIndex = 82;
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new Font("Cairo", 11F, FontStyle.Bold);
            groupControl1.AppearanceCaption.FontStyleDelta = FontStyle.Bold;
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.Controls.Add(lblPreparedDate);
            groupControl1.Controls.Add(dtSubmittedDate);
            groupControl1.Controls.Add(lueProject);
            groupControl1.Controls.Add(btnCancelAction);
            groupControl1.Controls.Add(cboCSTReviewStatus);
            groupControl1.Controls.Add(btnSaveClose);
            groupControl1.Controls.Add(lblCSTReviewDate);
            groupControl1.Controls.Add(txtNum);
            groupControl1.Controls.Add(dtCSTReviewDate);
            groupControl1.Controls.Add(lblNum);
            groupControl1.Controls.Add(lblSubmittedDate);
            groupControl1.Controls.Add(txtRev);
            groupControl1.Controls.Add(dtPreparedDate);
            groupControl1.Controls.Add(lblRev);
            groupControl1.Controls.Add(lueDiscipline);
            groupControl1.Controls.Add(lblDiscipline);
            groupControl1.Controls.Add(lblCSTReviewStatus);
            groupControl1.Controls.Add(txtRegisterNo);
            groupControl1.Controls.Add(memCSTReviewComment);
            groupControl1.Controls.Add(lblRegisterNo);
            groupControl1.Controls.Add(lblCSTReviewComment);
            groupControl1.Controls.Add(lblProject);
            groupControl1.Dock = DockStyle.Fill;
            groupControl1.Location = new Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(466, 656);
            groupControl1.TabIndex = 85;
            groupControl1.Text = "إجراء فحص أعمال";
            // 
            // lblPreparedDate
            // 
            lblPreparedDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPreparedDate.Appearance.Font = new Font("Cairo", 8.5F);
            lblPreparedDate.Appearance.Options.UseFont = true;
            lblPreparedDate.Location = new Point(348, 218);
            lblPreparedDate.Margin = new Padding(3, 5, 3, 5);
            lblPreparedDate.Name = "lblPreparedDate";
            lblPreparedDate.Size = new Size(61, 23);
            lblPreparedDate.TabIndex = 85;
            lblPreparedDate.Text = "تاريخ الإعداد:";
            // 
            // dtSubmittedDate
            // 
            dtSubmittedDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtSubmittedDate.EditValue = null;
            dtSubmittedDate.Location = new Point(57, 248);
            dtSubmittedDate.Margin = new Padding(3, 5, 3, 5);
            dtSubmittedDate.Name = "dtSubmittedDate";
            dtSubmittedDate.Properties.Appearance.BackColor = Color.LightGreen;
            dtSubmittedDate.Properties.Appearance.Font = new Font("Cairo", 8F);
            dtSubmittedDate.Properties.Appearance.Options.UseBackColor = true;
            dtSubmittedDate.Properties.Appearance.Options.UseFont = true;
            dtSubmittedDate.Properties.AutoHeight = false;
            dtSubmittedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            dtSubmittedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtSubmittedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtSubmittedDate.Size = new Size(283, 31);
            dtSubmittedDate.TabIndex = 84;
            // 
            // frmCIRAction
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 656);
            Controls.Add(groupControl1);
            Font = new Font("Cairo", 8.25F);
            MaximizeBox = false;
            Name = "frmCIRAction";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إجراء الإستشاري";
            Load += frmCIRAction_Load;
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRegisterNo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueDiscipline.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRev.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memCSTReviewComment.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboCSTReviewStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtPreparedDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtPreparedDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtCSTReviewDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtCSTReviewDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtSubmittedDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtSubmittedDate.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueProject;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.LabelControl lblRegisterNo;
        private DevExpress.XtraEditors.TextEdit txtRegisterNo;
        private DevExpress.XtraEditors.LabelControl lblDiscipline;
        private DevExpress.XtraEditors.LookUpEdit lueDiscipline;
        private DevExpress.XtraEditors.LabelControl lblRev;
        private DevExpress.XtraEditors.TextEdit txtRev;
        private DevExpress.XtraEditors.LabelControl lblNum;
        private DevExpress.XtraEditors.TextEdit txtNum;
        private DevExpress.XtraEditors.MemoEdit memCSTReviewComment;
        private DevExpress.XtraEditors.LabelControl lblCSTReviewComment;
        private DevExpress.XtraEditors.LabelControl lblCSTReviewStatus;
        private DevExpress.XtraEditors.ComboBoxEdit cboCSTReviewStatus;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.SimpleButton btnCancelAction;
        private DevExpress.XtraEditors.LabelControl lblSubmittedDate;
        private DevExpress.XtraEditors.DateEdit dtPreparedDate;
        private DevExpress.XtraEditors.LabelControl lblCSTReviewDate;
        private DevExpress.XtraEditors.DateEdit dtCSTReviewDate;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblPreparedDate;
        private DevExpress.XtraEditors.DateEdit dtSubmittedDate;
    }
}