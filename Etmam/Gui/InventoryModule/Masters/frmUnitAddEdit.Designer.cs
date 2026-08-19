namespace Etmam
{
    partial class frmUnitAddEdit
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
            txtDescription = new DevExpress.XtraEditors.TextEdit();
            txtAbbreviation = new DevExpress.XtraEditors.TextEdit();
            txtCategory = new DevExpress.XtraEditors.TextEdit();
            btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            btnSaveNew = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAbbreviation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory.Properties).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.ImageSize = new Size(20, 20);
            svgImageCollection1.Add("saveandclose2", "image://svgimages/save/saveandclose2.svg");
            svgImageCollection1.Add("saveas", "image://svgimages/save/saveas.svg");
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDescription.Location = new Point(53, 18);
            txtDescription.Margin = new Padding(3, 5, 3, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.Properties.Appearance.BackColor = Color.LightGreen;
            txtDescription.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtDescription.Properties.Appearance.Options.UseBackColor = true;
            txtDescription.Properties.Appearance.Options.UseFont = true;
            txtDescription.Size = new Size(337, 30);
            txtDescription.TabIndex = 1;
            // 
            // txtAbbreviation
            // 
            txtAbbreviation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAbbreviation.Location = new Point(53, 57);
            txtAbbreviation.Margin = new Padding(3, 5, 3, 5);
            txtAbbreviation.Name = "txtAbbreviation";
            txtAbbreviation.Properties.Appearance.BackColor = Color.LightGreen;
            txtAbbreviation.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtAbbreviation.Properties.Appearance.Options.UseBackColor = true;
            txtAbbreviation.Properties.Appearance.Options.UseFont = true;
            txtAbbreviation.Size = new Size(337, 30);
            txtAbbreviation.TabIndex = 3;
            // 
            // txtCategory
            // 
            txtCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCategory.Location = new Point(53, 95);
            txtCategory.Margin = new Padding(3, 5, 3, 5);
            txtCategory.Name = "txtCategory";
            txtCategory.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtCategory.Properties.Appearance.Options.UseFont = true;
            txtCategory.Size = new Size(337, 30);
            txtCategory.TabIndex = 5;
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
            labelControl1.Size = new Size(39, 23);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "الوصف:";
            // 
            // labelControl2
            // 
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 9F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(405, 62);
            labelControl2.Margin = new Padding(3, 5, 3, 5);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(25, 23);
            labelControl2.TabIndex = 2;
            labelControl2.Text = "الرمز:";
            // 
            // labelControl3
            // 
            labelControl3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl3.Appearance.Font = new Font("Cairo", 9F);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new Point(405, 102);
            labelControl3.Margin = new Padding(3, 5, 3, 5);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(44, 23);
            labelControl3.TabIndex = 4;
            labelControl3.Text = "التصنيف:";
            // 
            // frmUnitAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 211);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(btnSaveNew);
            Controls.Add(btnSaveClose);
            Controls.Add(txtCategory);
            Controls.Add(txtAbbreviation);
            Controls.Add(txtDescription);
            Font = new Font("Cairo", 8.25F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 5, 3, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUnitAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة / تعديل وحدة قياس";
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAbbreviation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtAbbreviation;
        private DevExpress.XtraEditors.TextEdit txtCategory;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveNew;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
