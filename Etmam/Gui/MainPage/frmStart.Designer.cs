namespace Etmam
{
    partial class frmStart
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
            panelSettings = new Panel();
            linkLabelExit = new LinkLabel();
            linkLabelSetServer = new LinkLabel();
            pictureBox1 = new PictureBox();
            labelState = new Label();
            progressBar1 = new ProgressBar();
            timerStart = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelSettings
            // 
            panelSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSettings.Controls.Add(linkLabelExit);
            panelSettings.Controls.Add(linkLabelSetServer);
            panelSettings.Location = new Point(17, 374);
            panelSettings.Margin = new Padding(2, 4, 2, 4);
            panelSettings.Name = "panelSettings";
            panelSettings.RightToLeft = RightToLeft.Yes;
            panelSettings.Size = new Size(368, 109);
            panelSettings.TabIndex = 7;
            panelSettings.Visible = false;
            // 
            // linkLabelExit
            // 
            linkLabelExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linkLabelExit.AutoSize = true;
            linkLabelExit.Font = new Font("Cairo", 8.5F);
            linkLabelExit.Location = new Point(269, 55);
            linkLabelExit.Margin = new Padding(2, 0, 2, 0);
            linkLabelExit.Name = "linkLabelExit";
            linkLabelExit.Size = new Size(77, 23);
            linkLabelExit.TabIndex = 0;
            linkLabelExit.TabStop = true;
            linkLabelExit.Text = "اغلاق البرنامج";
            linkLabelExit.LinkClicked += linkLabelExit_LinkClicked;
            // 
            // linkLabelSetServer
            // 
            linkLabelSetServer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linkLabelSetServer.AutoSize = true;
            linkLabelSetServer.Font = new Font("Cairo", 8.5F);
            linkLabelSetServer.Location = new Point(229, 12);
            linkLabelSetServer.Margin = new Padding(2, 0, 2, 0);
            linkLabelSetServer.Name = "linkLabelSetServer";
            linkLabelSetServer.Size = new Size(117, 23);
            linkLabelSetServer.TabIndex = 0;
            linkLabelSetServer.TabStop = true;
            linkLabelSetServer.Text = "تعديل اعدادات الاتصال";
            linkLabelSetServer.LinkClicked += linkLabelSetServer_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.Etmam_Logo_2;
            pictureBox1.Location = new Point(96, 45);
            pictureBox1.Margin = new Padding(2, 4, 2, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // labelState
            // 
            labelState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelState.Font = new Font("Cairo", 8.5F);
            labelState.Location = new Point(17, 293);
            labelState.Margin = new Padding(2, 0, 2, 0);
            labelState.Name = "labelState";
            labelState.RightToLeft = RightToLeft.Yes;
            labelState.Size = new Size(368, 35);
            labelState.TabIndex = 5;
            labelState.Text = "جاري الاتصال ...";
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(17, 332);
            progressBar1.Margin = new Padding(6, 5, 6, 5);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(368, 25);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 4;
            // 
            // timerStart
            // 
            timerStart.Enabled = true;
            timerStart.Interval = 5000;
            timerStart.Tick += timerStart_Tick;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Cairo", 8.5F);
            label2.Location = new Point(17, 505);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(368, 28);
            label2.TabIndex = 9;
            label2.Text = "v.25.01";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // simpleButton1
            // 
            simpleButton1.AllowFocus = false;
            simpleButton1.Appearance.Font = new Font("Cairo", 14F, FontStyle.Bold);
            simpleButton1.Appearance.ForeColor = Color.Red;
            simpleButton1.Appearance.Options.UseFont = true;
            simpleButton1.Appearance.Options.UseForeColor = true;
            simpleButton1.Enabled = false;
            simpleButton1.Location = new Point(33, 166);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            simpleButton1.Size = new Size(336, 51);
            simpleButton1.TabIndex = 12;
            simpleButton1.Text = "برنامج إداره المشروعات";
            // 
            // simpleButton2
            // 
            simpleButton2.AllowFocus = false;
            simpleButton2.Appearance.Font = new Font("Cairo", 14F, FontStyle.Bold);
            simpleButton2.Appearance.ForeColor = Color.Red;
            simpleButton2.Appearance.Options.UseFont = true;
            simpleButton2.Appearance.Options.UseForeColor = true;
            simpleButton2.Enabled = false;
            simpleButton2.Location = new Point(33, 206);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            simpleButton2.Size = new Size(336, 35);
            simpleButton2.TabIndex = 13;
            simpleButton2.Text = "MSG ™";
            simpleButton2.Visible = false;
            // 
            // frmStart
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 546);
            ControlBox = false;
            Controls.Add(simpleButton1);
            Controls.Add(label2);
            Controls.Add(panelSettings);
            Controls.Add(pictureBox1);
            Controls.Add(labelState);
            Controls.Add(progressBar1);
            Controls.Add(simpleButton2);
            Font = new Font("Cairo", 8.5F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 4, 2, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmStart";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSettings;
        private LinkLabel linkLabelExit;
        private LinkLabel linkLabelSetServer;
        private PictureBox pictureBox1;
        private Label labelState;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timerStart;
        private Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}