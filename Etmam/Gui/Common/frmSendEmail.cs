using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam.Gui.Common
{
    /// <summary>Generic "send this document by email" dialog, reusable across document AddEdit
    /// forms (first consumer: frmCIRAddEdit's btnSend). Sends via System.Net.Mail.SmtpClient using
    /// Data.EmailSettings (SystemSettings-backed, configured in SettingsForm's "البريد الإلكتروني"
    /// section) — mirrors the synchronous try/catch send pattern already used for the WhatsApp
    /// test-send button in SettingsForm.</summary>
    public class frmSendEmail : XtraForm
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private readonly byte[]? _attachmentBytes;
        private readonly string _attachmentFileName;

        private TextEdit txtTo = null!;
        private TextEdit txtCc = null!;
        private TextEdit txtSubject = null!;
        private MemoEdit memoBody = null!;
        private SimpleButton btnSend = null!;
        private SimpleButton btnCancel = null!;

        public frmSendEmail(string defaultTo, string subject, string body, byte[]? attachmentBytes, string attachmentFileName)
        {
            _attachmentBytes = attachmentBytes;
            _attachmentFileName = attachmentFileName;

            BuildUI(defaultTo, subject, body);
        }

        private void BuildUI(string defaultTo, string subject, string body)
        {
            Text = "إرسال عبر البريد الإلكتروني";
            Size = new Size(560, 480);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;

            var lblTo = new LabelControl { Text = "إلى:", Location = new Point(460, 16), AutoSize = true };
            txtTo = new TextEdit { Text = defaultTo, Location = new Point(16, 14), Size = new Size(430, 24) };

            var lblCc = new LabelControl { Text = "نسخة (CC):", Location = new Point(460, 48), AutoSize = true };
            txtCc = new TextEdit { Location = new Point(16, 46), Size = new Size(430, 24) };

            var lblSubject = new LabelControl { Text = "الموضوع:", Location = new Point(460, 80), AutoSize = true };
            txtSubject = new TextEdit { Text = subject, Location = new Point(16, 78), Size = new Size(430, 24) };

            var lblBody = new LabelControl { Text = "نص الرسالة:", Location = new Point(460, 112), AutoSize = true };
            memoBody = new MemoEdit { Text = body, Location = new Point(16, 132), Size = new Size(510, 220) };

            var lblAttachment = new LabelControl
            {
                Text = _attachmentBytes != null
                    ? $"سيتم إرفاق الملف تلقائياً: {_attachmentFileName}"
                    : "لا يوجد مرفق.",
                Location = new Point(16, 360),
                AutoSize = true,
                ForeColor = DesignSystem.Colors.TextSecondary,
            };

            btnSend = new SimpleButton { Text = "إرسال", Width = 100, Height = 30, Location = new Point(16, 400) };
            DesignSystem.StylePrimaryButton(btnSend);
            btnSend.Click += BtnSend_Click;

            btnCancel = new SimpleButton { Text = "إلغاء", Width = 100, Height = 30, Location = new Point(124, 400) };
            DesignSystem.StyleOutlineButton(btnCancel);
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            Controls.AddRange(new Control[]
            {
                lblTo, txtTo, lblCc, txtCc, lblSubject, txtSubject, lblBody, memoBody,
                lblAttachment, btnSend, btnCancel,
            });
        }

        private void BtnSend_Click(object? sender, EventArgs e)
        {
            if (!EmailSettings.IsConfigured(dc))
            {
                XtraMessageBox.Show(
                    "لم يتم إعداد بيانات خادم البريد الإلكتروني (SMTP) بعد.\nالرجاء إعدادها أولاً من: الإعدادات ← البريد الإلكتروني (SMTP).",
                    "الإعدادات غير مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTo.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال عنوان بريد المستلم على الأقل.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IOverlaySplashScreenHandle? handle = null;
            try
            {
                handle = SplashScreenManager.ShowOverlayForm(this);

                string fromAddress = EmailSettings.GetFromAddress(dc) ?? EmailSettings.GetSmtpUser(dc) ?? "";
                string fromName = EmailSettings.GetFromName(dc) ?? fromAddress;

                using var client = new SmtpClient(EmailSettings.GetSmtpHost(dc), EmailSettings.GetSmtpPort(dc))
                {
                    EnableSsl = EmailSettings.GetUseSsl(dc),
                    Credentials = new NetworkCredential(EmailSettings.GetSmtpUser(dc), EmailSettings.GetSmtpPassword(dc)),
                };

                using var msg = new MailMessage
                {
                    From = new MailAddress(fromAddress, fromName),
                    Subject = txtSubject.Text,
                    Body = memoBody.Text,
                };

                foreach (var addr in SplitAddresses(txtTo.Text)) msg.To.Add(addr);
                foreach (var addr in SplitAddresses(txtCc.Text)) msg.CC.Add(addr);

                using var attachmentStream = _attachmentBytes != null ? new MemoryStream(_attachmentBytes) : null;
                if (attachmentStream != null)
                    msg.Attachments.Add(new Attachment(attachmentStream, _attachmentFileName, "application/pdf"));

                client.Send(msg);

                XtraMessageBox.Show("تم إرسال البريد الإلكتروني بنجاح ✓", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                string details = ex.InnerException != null ? $"{ex.Message}\n\n{ex.InnerException.Message}" : ex.Message;
                XtraMessageBox.Show("فشل إرسال البريد الإلكتروني:\n" + details, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
            }
        }

        private static string[] SplitAddresses(string? text) =>
            string.IsNullOrWhiteSpace(text)
                ? Array.Empty<string>()
                : text.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }
}
