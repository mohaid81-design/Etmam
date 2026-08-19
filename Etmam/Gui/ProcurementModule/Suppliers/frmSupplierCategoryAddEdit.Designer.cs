namespace Etmam.Gui.ProcurementMgt.Suppliers
{
    partial class frmSupplierCategoryAddEdit
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
            btnSaveNew = new DevExpress.XtraEditors.SimpleButton();
            btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            txtCategory = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.ImageSize = new Size(20, 20);
            svgImageCollection1.Add("saveandclose2", "image://svgimages/save/saveandclose2.svg");
            svgImageCollection1.Add("saveas", "image://svgimages/save/saveas.svg");
            // 
            // btnSaveNew
            // 
            btnSaveNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveNew.Appearance.Font = new Font("Cairo", 9F);
            btnSaveNew.Appearance.Options.UseFont = true;
            btnSaveNew.ImageOptions.ImageIndex = 1;
            btnSaveNew.ImageOptions.ImageList = svgImageCollection1;
            btnSaveNew.Location = new Point(172, 117);
            btnSaveNew.Margin = new Padding(3, 5, 3, 5);
            btnSaveNew.Name = "btnSaveNew";
            btnSaveNew.Size = new Size(139, 35);
            btnSaveNew.TabIndex = 9;
            btnSaveNew.Text = "حفظ وجديد";
            // 
            // btnSaveClose
            // 
            btnSaveClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveClose.Appearance.Font = new Font("Cairo", 9F);
            btnSaveClose.Appearance.Options.UseFont = true;
            btnSaveClose.ImageOptions.ImageIndex = 0;
            btnSaveClose.ImageOptions.ImageList = svgImageCollection1;
            btnSaveClose.Location = new Point(27, 117);
            btnSaveClose.Margin = new Padding(3, 5, 3, 5);
            btnSaveClose.Name = "btnSaveClose";
            btnSaveClose.Size = new Size(139, 35);
            btnSaveClose.TabIndex = 8;
            btnSaveClose.Text = "حفظ وإغلاق";
            // 
            // labelControl3
            // 
            labelControl3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl3.Appearance.Font = new Font("Cairo", 9F);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new Point(349, 58);
            labelControl3.Margin = new Padding(3, 5, 3, 5);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(83, 23);
            labelControl3.TabIndex = 10;
            labelControl3.Text = "التصنيف الفرعي:";
            // 
            // txtCategory
            // 
            txtCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCategory.Location = new Point(27, 54);
            txtCategory.Margin = new Padding(3, 5, 3, 5);
            txtCategory.Name = "txtCategory";
            txtCategory.Properties.Appearance.BackColor = Color.LightGreen;
            txtCategory.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtCategory.Properties.Appearance.Options.UseBackColor = true;
            txtCategory.Properties.Appearance.Options.UseFont = true;
            txtCategory.Size = new Size(312, 30);
            txtCategory.TabIndex = 11;
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new Font("Cairo", 9F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(349, 24);
            labelControl1.Margin = new Padding(3, 5, 3, 5);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(84, 23);
            labelControl1.TabIndex = 12;
            labelControl1.Text = "التصنيف الرئيسي:";
            // 
            // comboBoxEdit1
            // 
            comboBoxEdit1.Enabled = false;
            comboBoxEdit1.Location = new Point(27, 20);
            comboBoxEdit1.Name = "comboBoxEdit1";
            comboBoxEdit1.Properties.Appearance.BackColor = SystemColors.ControlLight;
            comboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            comboBoxEdit1.Properties.AutoHeight = false;
            comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEdit1.Properties.Items.AddRange(new object[] { "مالك", "استشاري", "مورد", "مقاول باطن" });
            comboBoxEdit1.Size = new Size(312, 30);
            comboBoxEdit1.TabIndex = 13;
            // 
            // frmSupplierCategoryAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 173);
            Controls.Add(comboBoxEdit1);
            Controls.Add(labelControl1);
            Controls.Add(labelControl3);
            Controls.Add(txtCategory);
            Controls.Add(btnSaveNew);
            Controls.Add(btnSaveClose);
            Font = new Font("Cairo", 8.25F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 5, 3, 5);
            MaximizeBox = false;
            Name = "frmSupplierCategoryAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSupplierCategoryAddEdit";
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEdit1.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnSaveNew;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCategory;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
    }
}