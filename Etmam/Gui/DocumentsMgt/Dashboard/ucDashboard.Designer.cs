namespace Etmam
{
    partial class ucDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.lblDashboardTitle = new DevExpress.XtraEditors.LabelControl();
            this.gridNotifications = new DevExpress.XtraGrid.GridControl();
            this.gvNotifications = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNotifications)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.pnlTop.Appearance.Options.UseBackColor = true;
            this.pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTop.Controls.Add(this.lblDashboardTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(900, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblDashboardTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(131)))), ((int)(((byte)(135)))));
            this.lblDashboardTitle.Appearance.Options.UseFont = true;
            this.lblDashboardTitle.Appearance.Options.UseForeColor = true;
            this.lblDashboardTitle.Location = new System.Drawing.Point(20, 15);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(130, 30);
            this.lblDashboardTitle.TabIndex = 0;
            this.lblDashboardTitle.Text = "لوحة الإشعارات";
            // 
            // gridNotifications
            // 
            this.gridNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNotifications.Location = new System.Drawing.Point(0, 60);
            this.gridNotifications.MainView = this.gvNotifications;
            this.gridNotifications.Name = "gridNotifications";
            this.gridNotifications.Size = new System.Drawing.Size(900, 540);
            this.gridNotifications.TabIndex = 1;
            this.gridNotifications.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNotifications});
            // 
            // gvNotifications
            // 
            this.gvNotifications.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))));
            this.gvNotifications.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 8.5F, System.Drawing.FontStyle.Bold);
            this.gvNotifications.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.gvNotifications.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvNotifications.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvNotifications.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvNotifications.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvNotifications.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvNotifications.Appearance.Row.Font = new System.Drawing.Font("Cairo", 8.5F);
            this.gvNotifications.Appearance.Row.Options.UseFont = true;
            this.gvNotifications.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colType,
            this.colSubject,
            this.colDate,
            this.colStatus});
            this.gvNotifications.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvNotifications.GridControl = this.gridNotifications;
            this.gvNotifications.Name = "gvNotifications";
            this.gvNotifications.OptionsBehavior.Editable = false;
            this.gvNotifications.OptionsView.ShowGroupPanel = false;
            this.gvNotifications.OptionsView.ShowIndicator = false;
            this.gvNotifications.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colType
            // 
            this.colType.Caption = "النوع";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 0;
            this.colType.Width = 100;
            // 
            // colSubject
            // 
            this.colSubject.Caption = "الموضوع";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;
            this.colSubject.Width = 400;
            // 
            // colDate
            // 
            this.colDate.Caption = "التاريخ";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;
            this.colDate.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "الحالة";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            // 
            // ucDashboard
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Cairo", 8.5F);
            this.Controls.Add(this.gridNotifications);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNotifications)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.LabelControl lblDashboardTitle;
        private DevExpress.XtraGrid.GridControl gridNotifications;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNotifications;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
