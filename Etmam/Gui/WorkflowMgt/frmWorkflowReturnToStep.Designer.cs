namespace Etmam
{
    partial class frmWorkflowReturnToStep
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
            labelControlStep = new DevExpress.XtraEditors.LabelControl();
            lookUpStep = new DevExpress.XtraEditors.LookUpEdit();
            labelControlReason = new DevExpress.XtraEditors.LabelControl();
            memReason = new DevExpress.XtraEditors.MemoEdit();
            btnOk = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)lookUpStep.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memReason.Properties).BeginInit();
            SuspendLayout();
            //
            // labelControlStep
            //
            labelControlStep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlStep.Appearance.Font = new Font("Cairo", 9F);
            labelControlStep.Appearance.Options.UseFont = true;
            labelControlStep.Location = new Point(377, 23);
            labelControlStep.Margin = new Padding(3, 5, 3, 5);
            labelControlStep.Name = "labelControlStep";
            labelControlStep.Size = new Size(110, 23);
            labelControlStep.TabIndex = 0;
            labelControlStep.Text = "الخطوة المستهدفة:";
            //
            // lookUpStep
            //
            lookUpStep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpStep.Location = new Point(20, 18);
            lookUpStep.Margin = new Padding(3, 5, 3, 5);
            lookUpStep.Name = "lookUpStep";
            lookUpStep.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpStep.Properties.Appearance.Options.UseFont = true;
            lookUpStep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpStep.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "الخطوة") });
            lookUpStep.Properties.NullText = "";
            lookUpStep.Properties.ShowHeader = false;
            lookUpStep.Size = new Size(337, 30);
            lookUpStep.TabIndex = 1;
            //
            // labelControlReason
            //
            labelControlReason.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelControlReason.Appearance.Font = new Font("Cairo", 9F);
            labelControlReason.Appearance.Options.UseFont = true;
            labelControlReason.Location = new Point(377, 62);
            labelControlReason.Margin = new Padding(3, 5, 3, 5);
            labelControlReason.Name = "labelControlReason";
            labelControlReason.Size = new Size(83, 23);
            labelControlReason.TabIndex = 2;
            labelControlReason.Text = "سبب الإعادة:";
            //
            // memReason
            //
            memReason.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            memReason.Location = new Point(20, 57);
            memReason.Margin = new Padding(3, 5, 3, 5);
            memReason.Name = "memReason";
            memReason.Properties.Appearance.Font = new Font("Cairo", 9F);
            memReason.Properties.Appearance.Options.UseFont = true;
            memReason.Size = new Size(337, 90);
            memReason.TabIndex = 3;
            //
            // btnOk
            //
            btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOk.Appearance.Font = new Font("Cairo", 9F);
            btnOk.Appearance.Options.UseFont = true;
            btnOk.Location = new Point(198, 158);
            btnOk.Margin = new Padding(3, 5, 3, 5);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(159, 35);
            btnOk.TabIndex = 4;
            btnOk.Text = "إعادة الطلب";
            //
            // btnCancel
            //
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Appearance.Font = new Font("Cairo", 9F);
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(20, 158);
            btnCancel.Margin = new Padding(3, 5, 3, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(159, 35);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "إلغاء";
            //
            // frmWorkflowReturnToStep
            //
            AutoScaleDimensions = new SizeF(6F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(487, 211);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(memReason);
            Controls.Add(labelControlReason);
            Controls.Add(lookUpStep);
            Controls.Add(labelControlStep);
            Font = new Font("Cairo", 8.25F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 5, 3, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmWorkflowReturnToStep";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إعادة إلى خطوة سابقة";
            ((System.ComponentModel.ISupportInitialize)lookUpStep.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memReason.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlStep;
        private DevExpress.XtraEditors.LookUpEdit lookUpStep;
        private DevExpress.XtraEditors.LabelControl labelControlReason;
        private DevExpress.XtraEditors.MemoEdit memReason;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
