using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Entity
{
    public static class EmailService
    {
        public static void SendEmailWithAttachment(string senderEmail, string senderPassword, string recipientEmail, string subject, string body, string attachmentPath)
        {
            try
            {
                MailMessage mail = new MailMessage(senderEmail, recipientEmail, subject, body);
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                smtpServer.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpServer.Port = 587;
                smtpServer.EnableSsl = true;

                Attachment attachment = new Attachment(attachmentPath);
                mail.Attachments.Add(attachment);

                smtpServer.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
