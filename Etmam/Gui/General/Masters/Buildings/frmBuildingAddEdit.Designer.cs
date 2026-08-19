namespace Etmam
{
    partial class frmBuildingAddEdit
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            lueProject = new DevExpress.XtraEditors.LookUpEdit();
            txtName = new DevExpress.XtraEditors.TextEdit();
            chkActive = new DevExpress.XtraEditors.CheckEdit();
            btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            btnSaveNew = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkActive.Properties).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.ImageSize = new Size(20, 20);
            svgImageCollection1.Add("saveandclose2", "image://svgimages/save/saveandclose2.svg");
            svgImageCollection1.Add("saveas", "image://svgimages/save/saveas.svg");
            // 
            // lueProject
            // 
            lueProject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lueProject.Location = new Point(55, 18);
            lueProject.Margin = new Padding(3, 5, 3, 5);
            lueProject.Name = "lueProject";
            lueProject.Properties.Appearance.BackColor = Color.LightGreen;
            lueProject.Properties.Appearance.Font = new Font("Cairo", 9F);
            lueProject.Properties.Appearance.Options.UseBackColor = true;
            lueProject.Properties.Appearance.Options.UseFont = true;
            lueProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueProject.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "إسم المشروع") });
            lueProject.Properties.NullText = "";
            lueProject.Properties.PopupSizeable = false;
            lueProject.Properties.ShowHeader = false;
            lueProject.Size = new Size(337, 30);
            lueProject.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtName.Location = new Point(55, 57);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.BackColor = Color.LightGreen;
            txtName.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtName.Properties.Appearance.Options.UseBackColor = true;
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Size = new Size(337, 30);
            txtName.TabIndex = 2;
            // 
            // chkActive
            // 
            chkActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkActive.Location = new Point(55, 96);
            chkActive.Margin = new Padding(3, 5, 3, 5);
            chkActive.Name = "chkActive";
            chkActive.Properties.Appearance.Font = new Font("Cairo", 9F);
            chkActive.Properties.Appearance.Options.UseFont = true;
            chkActive.Properties.Caption = "نشط";
            chkActive.Size = new Size(337, 27);
            chkActive.TabIndex = 3;
            // 
            // btnSaveClose
            // 
            btnSaveClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveClose.Appearance.Font = new Font("Cairo", 9F);
            btnSaveClose.Appearance.Options.UseFont = true;
            btnSaveClose.ImageOptions.ImageIndex = 0;
            btnSaveClose.ImageOptions.ImageList = svgImageCollection1;
            btnSaveClose.Location = new Point(54, 151);
            btnSaveClose.Margin = new Padding(3, 5, 3, 5);
            btnSaveClose.Name = "btnSaveClose";
            btnSaveClose.Size = new Size(139, 35);
            btnSaveClose.TabIndex = 4;
            btnSaveClose.Text = "حفظ وإغلاق";
            // 
            // btnSaveNew
            // 
            btnSaveNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveNew.Appearance.Font = new Font("Cairo", 9F);
            btnSaveNew.Appearance.Options.UseFont = true;
            btnSaveNew.ImageOptions.ImageIndex = 1;
            btnSaveNew.ImageOptions.ImageList = svgImageCollection1;
            btnSaveNew.Location = new Point(199, 151);
            btnSaveNew.Margin = new Padding(3, 5, 3, 5);
            btnSaveNew.Name = "btnSaveNew";
            btnSaveNew.Size = new Size(139, 35);
            btnSaveNew.TabIndex = 5;
            btnSaveNew.Text = "حفظ وجديد";
            // 
            // labelControl1
            // 
            labelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl1.Appearance.Font = new Font("Cairo", 9F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(407, 62);
            labelControl1.Margin = new Padding(3, 5, 3, 5);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(34, 23);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "المبنى:";
            // 
            // labelControl2
            // 
            labelControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControl2.Appearance.Font = new Font("Cairo", 9F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(407, 23);
            labelControl2.Margin = new Padding(3, 5, 3, 5);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(45, 23);
            labelControl2.TabIndex = 6;
            labelControl2.Text = "المشروع:";
            // 
            // frmBuildingAddEdit
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 213);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(btnSaveNew);
            Controls.Add(btnSaveClose);
            Controls.Add(chkActive);
            Controls.Add(txtName);
            Controls.Add(lueProject);
            Font = new Font("Cairo", 8.25F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 5, 3, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBuildingAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إضافة / تعديل مبنى";
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkActive.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.LookUpEdit lueProject;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveNew;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
