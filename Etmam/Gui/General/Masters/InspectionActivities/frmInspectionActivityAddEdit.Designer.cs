namespace Etmam
{
    partial class frmInspectionActivityAddEdit
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
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            lueDiscipline = new DevExpress.XtraEditors.LookUpEdit();
            lueSecondaryDiscipline = new DevExpress.XtraEditors.LookUpEdit();
            txtName = new DevExpress.XtraEditors.TextEdit();
            txtCode = new DevExpress.XtraEditors.TextEdit();
            chkActive = new DevExpress.XtraEditors.CheckEdit();
            btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            btnSaveNew = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueDiscipline.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueSecondaryDiscipline.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkActive.Properties).BeginInit();
            SuspendLayout();
            //
            // svgImageCollection1
            //
            svgImageCollection1.ImageSize = new Size(20, 20);
            svgImageCollection1.Add("saveandclose2", "image://svgimages/save/saveandclose2.svg");
            svgImageCollection1.Add("saveas", "image://svgimages/save/saveas.svg");
            //
            // lueDiscipline
            //
            lueDiscipline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lueDiscipline.Location = new Point(53, 18);
            lueDiscipline.Margin = new Padding(3, 5, 3, 5);
            lueDiscipline.Name = "lueDiscipline";
            lueDiscipline.Properties.Appearance.BackColor = Color.LightGreen;
            lueDiscipline.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueDiscipline.Properties.Appearance.Options.UseBackColor = true;
            lueDiscipline.Properties.Appearance.Options.UseFont = true;
            lueDiscipline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueDiscipline.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "الوصف") });
            lueDiscipline.Properties.NullText = "";
            lueDiscipline.Properties.PopupSizeable = false;
            lueDiscipline.Properties.ShowHeader = false;
            lueDiscipline.Size = new Size(319, 30);
            lueDiscipline.TabIndex = 1;
            //
            // lueSecondaryDiscipline
            //
            lueSecondaryDiscipline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lueSecondaryDiscipline.Location = new Point(53, 57);
            lueSecondaryDiscipline.Margin = new Padding(3, 5, 3, 5);
            lueSecondaryDiscipline.Name = "lueSecondaryDiscipline";
            lueSecondaryDiscipline.Properties.Appearance.BackColor = Color.LightGreen;
            lueSecondaryDiscipline.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueSecondaryDiscipline.Properties.Appearance.Options.UseBackColor = true;
            lueSecondaryDiscipline.Properties.Appearance.Options.UseFont = true;
            lueSecondaryDiscipline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueSecondaryDiscipline.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "الوصف") });
            lueSecondaryDiscipline.Properties.NullText = "";
            lueSecondaryDiscipline.Properties.PopupSizeable = false;
            lueSecondaryDiscipline.Properties.ShowHeader = false;
            lueSecondaryDiscipline.Size = new Size(319, 30);
            lueSecondaryDiscipline.TabIndex = 2;
            //
            // txtName
            //
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtName.Location = new Point(53, 96);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.BackColor = Color.LightGreen;
            txtName.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtName.Properties.Appearance.Options.UseBackColor = true;
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Size = new Size(319, 30);
            txtName.TabIndex = 3;
            //
            // txtCode
            //
            txtCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCode.Location = new Point(53, 135);
            txtCode.Margin = new Padding(3, 5, 3, 5);
            txtCode.Name = "txtCode";
            txtCode.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtCode.Properties.Appearance.Options.UseFont = true;
            txtCode.Size = new Size(319, 30);
            txtCode.TabIndex = 4;
            //
            // chkActive
            //
            chkActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkActive.Location = new Point(53, 174);
            chkActive.Margin = new Padding(3, 5, 3, 5);
            chkActive.Name = "chkActive";
            chkActive.Properties.Appearance.Font = new Font("Cairo", 9F);
            chkActive.Properties.Appearance.Options.UseFont = true;
            chkActive.Properties.Caption = "نشط";
            chkActive.Size = new Size(319, 27);
            chkActive.TabIndex = 5;
            //
            // btnSaveClose
            //
            btnSaveClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveClose.Appearance.Font = new Font("Cairo", 9F);
            btnSaveClose.Appearance.Options.UseFont = true;
            btnSaveClose.ImageOptions.ImageIndex = 0;
            btnSaveClose.ImageOptions.ImageList = svgImageCollection1;
            btnSaveClose.Location = new Point(52, 229);
            btnSaveClose.Margin = new Padding(3, 5, 3, 5);
            btnSaveClose.Name = "btnSaveClose";
            btnSaveClose.Size = new Size(139, 35);
            btnSaveClose.TabIndex = 6;
            btnSaveClose.Text = "حفظ وإغلاق";
            //
            // btnSaveNew
            //
            btnSaveNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveNew.Appearance.Font = new Font("Cairo", 9F);
            btnSaveNew.Appearance.Options.UseFont = true;
            btnSaveNew.ImageOptions.ImageIndex = 1;
            btnSaveNew.ImageOptions.ImageList = svgImageCollection1;
            btnSaveNew.Location = new Point(197, 229);
            btnSaveNew.Margin = new Padding(3, 5, 3, 5);
            btnSaveNew.Name = "btnSaveNew";
            btnSaveNew.Size = new Size(139, 35);
            btnSaveNew.TabIndex = 7;
            btnSaveNew.Text = "حفظ وجديد";
            //
            // labelControl1
            //
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new Font("Cairo", 9F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(382, 101);
            labelControl1.Margin = new Padding(3, 5, 3, 5);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(65, 23);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "نشاط الفحص:";
            //
            // labelControl2
            //
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 9F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(382, 23);
            labelControl2.Margin = new Padding(3, 5, 3, 5);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(85, 23);
            labelControl2.TabIndex = 8;
            labelControl2.Text = "التخصص الرئيسي:";
            //
            // labelControl3
            //
            labelControl3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl3.Appearance.Font = new Font("Cairo", 9F);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new Point(382, 140);
            labelControl3.Margin = new Padding(3, 5, 3, 5);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(25, 23);
            labelControl3.TabIndex = 9;
            labelControl3.Text = "الرمز:";
            //
            // labelControl4
            //
            labelControl4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl4.Appearance.Font = new Font("Cairo", 9F);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new Point(382, 62);
            labelControl4.Margin = new Padding(3, 5, 3, 5);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(83, 23);
            labelControl4.TabIndex = 10;
            labelControl4.Text = "التخصص الثانوي:";
            //
            // frmInspectionActivityAddEdit
            //
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 289);
            Controls.Add(labelControl4);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(btnSaveNew);
            Controls.Add(btnSaveClose);
            Controls.Add(chkActive);
            Controls.Add(txtCode);
            Controls.Add(txtName);
            Controls.Add(lueSecondaryDiscipline);
            Controls.Add(lueDiscipline);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 5, 3, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInspectionActivityAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة / تعديل نشاط فحص";
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueDiscipline.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueSecondaryDiscipline.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkActive.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.LookUpEdit lueDiscipline;
        private DevExpress.XtraEditors.LookUpEdit lueSecondaryDiscipline;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveNew;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
