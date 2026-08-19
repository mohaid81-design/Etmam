using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    partial class frmWorkflowDefinitionAddEdit
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
            pnlHeader = new PanelControl();
            lblName = new LabelControl();
            txtName = new TextEdit();
            lblDesc = new LabelControl();
            txtDescription = new MemoEdit();
            chkActive = new CheckEdit();
            lblCategory = new LabelControl();
            cmbCategory = new ComboBoxEdit();
            lblProject = new LabelControl();
            lookUpEditProject = new LookUpEdit();
            chkGeneralDiscipline = new CheckEdit();
            lblDisciplines = new LabelControl();
            clbDisciplines = new CheckedListBoxControl();
            pnlBottom = new PanelControl();
            btnSave = new SimpleButton();
            btnCancel = new SimpleButton();
            pnlMiddle = new PanelControl();
            pnlSteps = new PanelControl();
            gridControl1 = new GridControl();
            gridView1 = new GridView();
            pnlStepsToolbar = new PanelControl();
            btnAddStep = new SimpleButton();
            btnDeleteStep = new SimpleButton();
            btnMoveUp = new SimpleButton();
            btnMoveDown = new SimpleButton();
            pnlAssignees = new PanelControl();
            clbUsers = new CheckedListBoxControl();
            lblAssignees = new LabelControl();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbCategory.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkGeneralDiscipline.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clbDisciplines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlBottom).BeginInit();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlMiddle).BeginInit();
            pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSteps).BeginInit();
            pnlSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlStepsToolbar).BeginInit();
            pnlStepsToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlAssignees).BeginInit();
            pnlAssignees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clbUsers).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblName);
            pnlHeader.Controls.Add(txtName);
            pnlHeader.Controls.Add(lblDesc);
            pnlHeader.Controls.Add(txtDescription);
            pnlHeader.Controls.Add(chkActive);
            pnlHeader.Controls.Add(lblCategory);
            pnlHeader.Controls.Add(cmbCategory);
            pnlHeader.Controls.Add(lblProject);
            pnlHeader.Controls.Add(lookUpEditProject);
            pnlHeader.Controls.Add(chkGeneralDiscipline);
            pnlHeader.Controls.Add(lblDisciplines);
            pnlHeader.Controls.Add(clbDisciplines);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(993, 182);
            pnlHeader.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblName.Appearance.Font = new Font("Cairo", 9F);
            lblName.Appearance.Options.UseFont = true;
            lblName.Location = new Point(925, 77);
            lblName.Name = "lblName";
            lblName.Size = new Size(56, 23);
            lblName.TabIndex = 0;
            lblName.Text = "اسم الإجراء";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtName.Location = new Point(623, 73);
            txtName.Name = "txtName";
            txtName.Properties.Appearance.BackColor = Color.LightGreen;
            txtName.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtName.Properties.Appearance.Options.UseBackColor = true;
            txtName.Properties.Appearance.Options.UseFont = true;
            txtName.Properties.BorderStyle = BorderStyles.NoBorder;
            txtName.Size = new Size(292, 28);
            txtName.TabIndex = 1;
            // 
            // lblDesc
            // 
            lblDesc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDesc.Appearance.Font = new Font("Cairo", 9F);
            lblDesc.Appearance.Options.UseFont = true;
            lblDesc.Location = new Point(925, 110);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(36, 23);
            lblDesc.TabIndex = 2;
            lblDesc.Text = "الوصف";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDescription.Location = new Point(607, 105);
            txtDescription.Name = "txtDescription";
            txtDescription.Properties.Appearance.BackColor = Color.LightGreen;
            txtDescription.Properties.Appearance.Font = new Font("Cairo", 9F);
            txtDescription.Properties.Appearance.Options.UseBackColor = true;
            txtDescription.Properties.Appearance.Options.UseFont = true;
            txtDescription.Properties.BorderStyle = BorderStyles.NoBorder;
            txtDescription.Size = new Size(308, 50);
            txtDescription.TabIndex = 2;
            // 
            // chkActive
            // 
            chkActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkActive.Location = new Point(840, 12);
            chkActive.Name = "chkActive";
            chkActive.Properties.Appearance.Font = new Font("Cairo", 9F);
            chkActive.Properties.Appearance.Options.UseFont = true;
            chkActive.Properties.Caption = "مفعّل";
            chkActive.Size = new Size(75, 27);
            chkActive.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCategory.Appearance.Font = new Font("Cairo", 9F);
            lblCategory.Appearance.Options.UseFont = true;
            lblCategory.Location = new Point(925, 45);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(41, 23);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "التصنيف";
            // 
            // cmbCategory
            // 
            cmbCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbCategory.Location = new Point(623, 41);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Properties.Appearance.BackColor = Color.LightGreen;
            cmbCategory.Properties.Appearance.Font = new Font("Cairo", 9F);
            cmbCategory.Properties.Appearance.Options.UseBackColor = true;
            cmbCategory.Properties.Appearance.Options.UseFont = true;
            cmbCategory.Properties.BorderStyle = BorderStyles.NoBorder;
            cmbCategory.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            cmbCategory.Size = new Size(292, 28);
            cmbCategory.TabIndex = 4;
            //
            // lblProject
            //
            lblProject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblProject.Appearance.Font = new Font("Cairo", 9F);
            lblProject.Appearance.Options.UseFont = true;
            lblProject.Location = new Point(560, 16);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(56, 23);
            lblProject.TabIndex = 5;
            lblProject.Text = "المشروع";
            //
            // lookUpEditProject
            //
            lookUpEditProject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lookUpEditProject.Location = new Point(270, 12);
            lookUpEditProject.Name = "lookUpEditProject";
            lookUpEditProject.Properties.Appearance.BackColor = Color.LightGreen;
            lookUpEditProject.Properties.Appearance.Font = new Font("Cairo", 9F);
            lookUpEditProject.Properties.Appearance.Options.UseBackColor = true;
            lookUpEditProject.Properties.Appearance.Options.UseFont = true;
            lookUpEditProject.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            lookUpEditProject.Properties.NullText = "-- كل المشاريع --";
            lookUpEditProject.Size = new Size(280, 28);
            lookUpEditProject.TabIndex = 6;
            //
            // chkGeneralDiscipline
            //
            chkGeneralDiscipline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkGeneralDiscipline.Location = new Point(270, 48);
            chkGeneralDiscipline.Name = "chkGeneralDiscipline";
            chkGeneralDiscipline.Properties.Appearance.Font = new Font("Cairo", 9F);
            chkGeneralDiscipline.Properties.Appearance.Options.UseFont = true;
            chkGeneralDiscipline.Properties.Caption = "عام (كل التخصصات)";
            chkGeneralDiscipline.Size = new Size(280, 25);
            chkGeneralDiscipline.TabIndex = 7;
            //
            // lblDisciplines
            //
            lblDisciplines.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDisciplines.Appearance.Font = new Font("Cairo", 9F);
            lblDisciplines.Appearance.Options.UseFont = true;
            lblDisciplines.Location = new Point(560, 80);
            lblDisciplines.Name = "lblDisciplines";
            lblDisciplines.Size = new Size(56, 23);
            lblDisciplines.TabIndex = 8;
            lblDisciplines.Text = "التخصصات";
            //
            // clbDisciplines
            //
            clbDisciplines.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clbDisciplines.Location = new Point(270, 80);
            clbDisciplines.Name = "clbDisciplines";
            clbDisciplines.Size = new Size(280, 90);
            clbDisciplines.TabIndex = 9;
            //
            // pnlBottom
            // 
            pnlBottom.Controls.Add(btnSave);
            pnlBottom.Controls.Add(btnCancel);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 643);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(993, 51);
            pnlBottom.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(137, 13);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(119, 28);
            btnSave.TabIndex = 0;
            btnSave.Text = "حفظ";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 13);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 28);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "إلغاء";
            // 
            // pnlMiddle
            // 
            pnlMiddle.Controls.Add(pnlSteps);
            pnlMiddle.Controls.Add(pnlAssignees);
            pnlMiddle.Dock = DockStyle.Fill;
            pnlMiddle.Location = new Point(0, 182);
            pnlMiddle.Name = "pnlMiddle";
            pnlMiddle.Size = new Size(993, 461);
            pnlMiddle.TabIndex = 1;
            // 
            // pnlSteps
            // 
            pnlSteps.Controls.Add(gridControl1);
            pnlSteps.Controls.Add(pnlStepsToolbar);
            pnlSteps.Dock = DockStyle.Fill;
            pnlSteps.Location = new Point(2, 2);
            pnlSteps.Name = "pnlSteps";
            pnlSteps.Size = new Size(729, 457);
            pnlSteps.TabIndex = 0;
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(2, 44);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(725, 411);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // pnlStepsToolbar
            // 
            pnlStepsToolbar.Controls.Add(btnAddStep);
            pnlStepsToolbar.Controls.Add(btnDeleteStep);
            pnlStepsToolbar.Controls.Add(btnMoveUp);
            pnlStepsToolbar.Controls.Add(btnMoveDown);
            pnlStepsToolbar.Dock = DockStyle.Top;
            pnlStepsToolbar.Location = new Point(2, 2);
            pnlStepsToolbar.Name = "pnlStepsToolbar";
            pnlStepsToolbar.Size = new Size(725, 42);
            pnlStepsToolbar.TabIndex = 0;
            // 
            // btnAddStep
            // 
            btnAddStep.Appearance.Font = new Font("Cairo", 9F);
            btnAddStep.Appearance.Options.UseFont = true;
            btnAddStep.Location = new Point(617, 7);
            btnAddStep.Name = "btnAddStep";
            btnAddStep.Size = new Size(90, 28);
            btnAddStep.TabIndex = 0;
            btnAddStep.Text = "إضافة خطوة";
            // 
            // btnDeleteStep
            // 
            btnDeleteStep.Appearance.Font = new Font("Cairo", 9F);
            btnDeleteStep.Appearance.Options.UseFont = true;
            btnDeleteStep.Location = new Point(521, 7);
            btnDeleteStep.Name = "btnDeleteStep";
            btnDeleteStep.Size = new Size(90, 28);
            btnDeleteStep.TabIndex = 1;
            btnDeleteStep.Text = "حذف خطوة";
            // 
            // btnMoveUp
            // 
            btnMoveUp.Appearance.Font = new Font("Cairo", 9F);
            btnMoveUp.Appearance.Options.UseFont = true;
            btnMoveUp.Location = new Point(425, 7);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(90, 28);
            btnMoveUp.TabIndex = 2;
            btnMoveUp.Text = "▲ أعلى";
            // 
            // btnMoveDown
            // 
            btnMoveDown.Appearance.Font = new Font("Cairo", 9F);
            btnMoveDown.Appearance.Options.UseFont = true;
            btnMoveDown.Location = new Point(329, 7);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(90, 28);
            btnMoveDown.TabIndex = 3;
            btnMoveDown.Text = "▼ أسفل";
            // 
            // pnlAssignees
            // 
            pnlAssignees.Controls.Add(clbUsers);
            pnlAssignees.Controls.Add(lblAssignees);
            pnlAssignees.Dock = DockStyle.Right;
            pnlAssignees.Location = new Point(731, 2);
            pnlAssignees.Name = "pnlAssignees";
            pnlAssignees.Size = new Size(260, 457);
            pnlAssignees.TabIndex = 1;
            // 
            // clbUsers
            // 
            clbUsers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clbUsers.Location = new Point(2, 31);
            clbUsers.Name = "clbUsers";
            clbUsers.Size = new Size(256, 425);
            clbUsers.TabIndex = 1;
            // 
            // lblAssignees
            // 
            lblAssignees.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAssignees.Appearance.Font = new Font("Cairo", 9F);
            lblAssignees.Appearance.Options.UseFont = true;
            lblAssignees.LineLocation = LineLocation.Center;
            lblAssignees.Location = new Point(70, 3);
            lblAssignees.Name = "lblAssignees";
            lblAssignees.Size = new Size(188, 23);
            lblAssignees.TabIndex = 0;
            lblAssignees.Text = "المستخدمون المعتمدون لهذه الخطوة";
            // 
            // frmWorkflowDefinitionAddEdit
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 694);
            Controls.Add(pnlMiddle);
            Controls.Add(pnlHeader);
            Controls.Add(pnlBottom);
            Font = new Font("Cairo", 9F);
            MaximizeBox = false;
            Name = "frmWorkflowDefinitionAddEdit";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إجراء";
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbCategory.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookUpEditProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkGeneralDiscipline.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)clbDisciplines).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlBottom).EndInit();
            pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlMiddle).EndInit();
            pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlSteps).EndInit();
            pnlSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlStepsToolbar).EndInit();
            pnlStepsToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlAssignees).EndInit();
            pnlAssignees.ResumeLayout(false);
            pnlAssignees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clbUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PanelControl pnlHeader;
        private LabelControl lblName;
        private TextEdit txtName;
        private LabelControl lblDesc;
        private MemoEdit txtDescription;
        private CheckEdit chkActive;
        private LabelControl lblCategory;
        private ComboBoxEdit cmbCategory;
        private LabelControl lblProject;
        private LookUpEdit lookUpEditProject;
        private CheckEdit chkGeneralDiscipline;
        private LabelControl lblDisciplines;
        private CheckedListBoxControl clbDisciplines;
        private PanelControl pnlBottom;
        private SimpleButton btnSave;
        private SimpleButton btnCancel;
        private PanelControl pnlMiddle;
        private PanelControl pnlSteps;
        private GridControl gridControl1;
        private GridView gridView1;
        private PanelControl pnlStepsToolbar;
        private SimpleButton btnAddStep;
        private SimpleButton btnDeleteStep;
        private SimpleButton btnMoveUp;
        private SimpleButton btnMoveDown;
        private PanelControl pnlAssignees;
        private CheckedListBoxControl clbUsers;
        private LabelControl lblAssignees;
    }
}
