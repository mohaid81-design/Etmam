namespace Etmam
{
    partial class frmDrawingsSubCategoryAddEdit
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
            lueType = new DevExpress.XtraEditors.LookUpEdit();
            lueCategory = new DevExpress.XtraEditors.LookUpEdit();
            txtName = new DevExpress.XtraEditors.TextEdit();
            btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            btnSaveNew = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueCategory.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            SuspendLayout();
            //
            // svgImageCollection1
            //
            svgImageCollection1.ImageSize = new Size(20, 20);
            svgImageCollection1.Add("saveandclose2", "image://svgimages/save/saveandclose2.svg");
            svgImageCollection1.Add("saveas", "image://svgimages/save/saveas.svg");
            //
            // lueType
            //
            lueType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lueType.Location = new Point(53, 18);
            lueType.Margin = new Padding(3, 5, 3, 5);
            lueType.Name = "lueType";
            lueType.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueType.Properties.Appearance.Options.UseFont = true;
            lueType.Properties.NullText = "";
            lueType.Size = new Size(337, 30);
            lueType.TabIndex = 1;
            //
            // lueCategory
            //
            lueCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lueCategory.Location = new Point(53, 57);
            lueCategory.Margin = new Padding(3, 5, 3, 5);
            lueCategory.Name = "lueCategory";
            lueCategory.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueCategory.Properties.Appearance.Options.UseFont = true;
            lueCategory.Properties.NullText = "";
            lueCategory.Size = new Size(337, 30);
            lueCategory.TabIndex = 3;
            //
            // txtName
            //
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtName.Location = new Point(53, 95);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.BackColor = Color.LightGreen;
            txtName.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtName.Properties.Appearance.Options.UseBackColor = true;
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Size = new Size(337, 30);
            txtName.TabIndex = 5;
            //
            // btnSaveClose
            //
            btnSaveClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveClose.Appearance.Font = new Font("Cairo", 9F);
            btnSaveClose.Appearance.Options.UseFont = true;
            btnSaveClose.ImageOptions.ImageIndex = 0;
            btnSaveClose.ImageOptions.ImageList = svgImageCollection1;
            btnSaveClose.Location = new Point(52, 151);
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
            btnSaveNew.Location = new Point(197, 151);
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
            labelControl1.Location = new Point(405, 23);
            labelControl1.Margin = new Padding(3, 5, 3, 5);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(58, 23);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "نوع المخطط:";
            //
            // labelControl2
            //
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 9F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(405, 62);
            labelControl2.Margin = new Padding(3, 5, 3, 5);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(44, 23);
            labelControl2.TabIndex = 2;
            labelControl2.Text = "التصنيف:";
            //
            // labelControl3
            //
            labelControl3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl3.Appearance.Font = new Font("Cairo", 9F);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new Point(405, 102);
            labelControl3.Margin = new Padding(3, 5, 3, 5);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(84, 23);
            labelControl3.TabIndex = 4;
            labelControl3.Text = "التصنيف الفرعي:";
            //
            // frmDrawingsSubCategoryAddEdit
            //
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 211);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(btnSaveNew);
            Controls.Add(btnSaveClose);
            Controls.Add(txtName);
            Controls.Add(lueCategory);
            Controls.Add(lueType);
            Font = new Font("Cairo", 8.25F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 5, 3, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDrawingsSubCategoryAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة / تعديل تصنيف فرعي";
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueCategory.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.LookUpEdit lueType;
        private DevExpress.XtraEditors.LookUpEdit lueCategory;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveNew;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
