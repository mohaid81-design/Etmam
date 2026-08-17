namespace Etmam
{
    partial class frmActivityAddEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            navigationFrame2 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)navigationFrame1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)navigationFrame2).BeginInit();
            SuspendLayout();
            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = DockStyle.Fill;
            splitContainerControl1.Location = new Point(0, 0);
            splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            splitContainerControl1.Panel1.Controls.Add(navigationFrame1);
            splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            splitContainerControl1.Panel2.Controls.Add(navigationFrame2);
            splitContainerControl1.Panel2.Text = "Panel2";
            splitContainerControl1.RightToLeft = RightToLeft.Yes;
            splitContainerControl1.Size = new Size(1259, 685);
            splitContainerControl1.SplitterPosition = 530;
            splitContainerControl1.TabIndex = 0;
            // 
            // navigationFrame1
            // 
            navigationFrame1.Dock = DockStyle.Fill;
            navigationFrame1.Location = new Point(0, 0);
            navigationFrame1.Name = "navigationFrame1";
            navigationFrame1.Size = new Size(530, 685);
            navigationFrame1.TabIndex = 0;
            navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationFrame2
            // 
            navigationFrame2.Dock = DockStyle.Fill;
            navigationFrame2.Location = new Point(0, 0);
            navigationFrame2.Name = "navigationFrame2";
            navigationFrame2.RightToLeft = RightToLeft.No;
            navigationFrame2.Size = new Size(719, 685);
            navigationFrame2.TabIndex = 0;
            navigationFrame2.Text = "navigationFrame2";
            // 
            // frmActivityAddEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 685);
            Controls.Add(splitContainerControl1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmActivityAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إضافة / تعديل نشاط";
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)navigationFrame1).EndInit();
            ((System.ComponentModel.ISupportInitialize)navigationFrame2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame2;
    }
}
