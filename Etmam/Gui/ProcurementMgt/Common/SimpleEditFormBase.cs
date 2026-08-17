using System;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    /// <summary>
    /// Shared Add/Edit dialog skeleton for simple Procurement masters (label/editor rows + Save/Cancel).
    /// Subclasses build their own fields, then populate/validate/collect them.
    /// </summary>
    public abstract class SimpleEditFormBase<T> : XtraForm where T : class, IBaseEntity, new()
    {
        protected DataContext dc => Data.DataContext.Shared;
        protected int Id { get; private set; }
        protected T? Entity { get; private set; }
        protected readonly TableLayoutPanel fieldsPanel = new TableLayoutPanel();
        private readonly SimpleButton btnSave;
        private readonly SimpleButton btnCancel;

        protected abstract IDataHelper<T> Helper { get; }
        protected abstract string TitleSingular { get; }

        protected SimpleEditFormBase(int id)
        {
            Id = id;
            Text = $"{TitleSingular} - {(id > 0 ? "تعديل" : "جديد")}";
            Width = 480;
            Height = 420;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            fieldsPanel.Dock = DockStyle.Fill;
            fieldsPanel.ColumnCount = 2;
            fieldsPanel.Padding = new Padding(14);
            fieldsPanel.AutoSize = true;
            fieldsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
            fieldsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            var buttonPanel = new PanelControl { Dock = DockStyle.Bottom, Height = 50 };
            btnSave = new SimpleButton { Text = "حفظ", Width = 100, Height = 30, Left = 12, Top = 10 };
            btnCancel = new SimpleButton { Text = "إلغاء", Width = 100, Height = 30, Left = 122, Top = 10 };
            DesignSystem.ApplyButtonStyle(btnSave, true);
            DesignSystem.ApplyButtonStyle(btnCancel);
            buttonPanel.Controls.Add(btnSave);
            buttonPanel.Controls.Add(btnCancel);

            Controls.Add(fieldsPanel);
            Controls.Add(buttonPanel);

            BuildFields();
            DesignSystem.ApplyCairoFont(this);

            btnSave.Click += (s, e) => DoSave();
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            LoadRecord();
        }

        /// <summary>Adds a label/editor row. Call once per field from BuildFields().</summary>
        protected void AddField(string label, Control editor)
        {
            int row = fieldsPanel.RowCount;
            fieldsPanel.RowCount = row + 1;
            fieldsPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var lbl = new LabelControl
            {
                Text = label,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 8, 8, 0)
            };
            editor.Dock = DockStyle.Fill;
            editor.Margin = new Padding(3, 6, 3, 6);

            fieldsPanel.Controls.Add(lbl, 0, row);
            fieldsPanel.Controls.Add(editor, 1, row);
        }

        protected abstract void BuildFields();
        protected abstract void PopulateFields(T entity);
        protected abstract bool ValidateFields(out string error);
        protected abstract void CollectFields(T entity);

        private void LoadRecord()
        {
            Entity = Id > 0 ? Helper.Find(Id) : new T();
            if (Entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Entity = new T();
            }
            PopulateFields(Entity);
        }

        private void DoSave()
        {
            if (!ValidateFields(out string error))
            {
                XtraMessageBox.Show(error, "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Entity ??= new T();
                CollectFields(Entity);

                if (Id > 0)
                    Helper.Edit(Id, Entity);
                else
                    Id = Helper.Add(Entity);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
