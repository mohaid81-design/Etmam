using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam
{
    partial class frmWorkflowDefinitionSelect
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
            lblHint = new LabelControl();
            lstProcedures = new ListBoxControl();
            pnlBottom = new PanelControl();
            btnSelect = new SimpleButton();
            btnCancel = new SimpleButton();
            ((System.ComponentModel.ISupportInitialize)pnlBottom).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            //
            // lblHint
            //
            lblHint.AutoSizeMode = LabelAutoSizeMode.None;
            lblHint.Dock = DockStyle.Top;
            lblHint.Height = 44;
            lblHint.Location = new Point(0, 0);
            lblHint.Name = "lblHint";
            lblHint.Padding = new Padding(10, 10, 10, 0);
            lblHint.Size = new Size(420, 44);
            lblHint.TabIndex = 0;
            lblHint.Text = "يوجد أكثر من إجراء اعتماد معرَّف لطلبات الشراء — اختر الإجراء المناسب لهذا الطلب:";
            //
            // lstProcedures
            //
            lstProcedures.Dock = DockStyle.Fill;
            lstProcedures.Location = new Point(0, 44);
            lstProcedures.Name = "lstProcedures";
            lstProcedures.Size = new Size(420, 224);
            lstProcedures.TabIndex = 1;
            //
            // pnlBottom
            //
            pnlBottom.Controls.Add(btnSelect);
            pnlBottom.Controls.Add(btnCancel);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 268);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(420, 46);
            pnlBottom.TabIndex = 2;
            //
            // btnSelect
            //
            btnSelect.Location = new Point(300, 8);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(100, 30);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "اختيار";
            //
            // btnCancel
            //
            btnCancel.Location = new Point(190, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "إلغاء";
            //
            // frmWorkflowDefinitionSelect
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 314);
            Controls.Add(lstProcedures);
            Controls.Add(lblHint);
            Controls.Add(pnlBottom);
            Font = new Font("Cairo", 9F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmWorkflowDefinitionSelect";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اختر إجراء الاعتماد";
            ((System.ComponentModel.ISupportInitialize)pnlBottom).EndInit();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private LabelControl lblHint;
        private ListBoxControl lstProcedures;
        private PanelControl pnlBottom;
        private SimpleButton btnSelect;
        private SimpleButton btnCancel;
    }
}
