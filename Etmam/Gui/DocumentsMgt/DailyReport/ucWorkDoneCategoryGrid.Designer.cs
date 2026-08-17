namespace Etmam
{
    partial class ucWorkDoneCategoryGrid
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
            gridMain = new DevExpress.XtraGrid.GridControl();
            gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)gridMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvMain).BeginInit();
            SuspendLayout();
            // 
            // gridMain
            // 
            gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            gridMain.Location = new System.Drawing.Point(0, 0);
            gridMain.MainView = gvMain;
            gridMain.Name = "gridMain";
            gridMain.Size = new System.Drawing.Size(800, 400);
            gridMain.TabIndex = 0;
            gridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvMain });
            // 
            // gvMain
            // 
            gvMain.GridControl = gridMain;
            gvMain.Name = "gvMain";
            gvMain.OptionsView.ShowGroupPanel = false;
            // 
            // ucWorkDoneCategoryGrid
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(gridMain);
            Name = "ucWorkDoneCategoryGrid";
            Size = new System.Drawing.Size(800, 400);
            ((System.ComponentModel.ISupportInitialize)gridMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
    }
}
