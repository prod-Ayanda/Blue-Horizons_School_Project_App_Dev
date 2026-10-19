using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using PROJECTT.Models;

namespace PROJECTT.Services
{
    public static class EmailService
    {
        // Sender email and Gmail App Password from Tourist repo EmailService.cs
        public static string Host = "smtp.gmail.com";
        public static int Port = 587;
        public static string User = "lungelobhengu987@gmail.com";
        public static string Password = "qctaezfdlyfplxli";
        public static string FromName = "Blue Horizon Tours";

        public static async Task SendTicketsAsync(
            string toEmail,
            string guestName,
            Activity ev,
            List<string> ticketNumbers,
            List<byte[]> pdfs)
        {
            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(User, FromName);
                msg.To.Add(new MailAddress(toEmail));
                msg.Subject = "Your tickets for " + ev.Name;
                msg.Body = "Hi " + guestName + ",\r\n\r\n" +
                           "Thank you for booking with Blue Horizon.\r\n\r\n" +
                           "Event: " + ev.Name + "\r\n" +
                           "Category & Venue: " + ev.Category + " (Cape Town, South Africa)\r\n" +
                           "Date & time: " + ev.Date.ToString("dddd, d MMMM yyyy") + "\r\n" +
                           "Tickets attached: " + pdfs.Count + "\r\n" +
                           "Ticket numbers: " + string.Join(", ", ticketNumbers) + "\r\n\r\n" +
                           "Please bring your tickets to the event.\r\n\r\nBlue Horizon | Explore South Africa";

                var streams = new List<MemoryStream>();
                try
                {
                    for (int i = 0; i < pdfs.Count; i++)
                    {
                        var ms = new MemoryStream(pdfs[i]);
                        streams.Add(ms);
                        msg.Attachments.Add(new Attachment(ms, "Ticket-" + ticketNumbers[i] + ".pdf", "application/pdf"));
                    }

                    using (var smtp = new SmtpClient(Host, Port))
                    {
                        smtp.EnableSsl = true;
                        smtp.Timeout = 12000;
                        smtp.Credentials = new NetworkCredential(User, Password);
                        await smtp.SendMailAsync(msg);
                    }
                }
                finally
                {
                    foreach (var s in streams) s.Dispose();
                }
            }
        }

        public static async Task SendContactConfirmationAsync(
            string toEmail,
            string guestName,
            string subject,
            string messageText)
        {
            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(User, FromName);
                msg.To.Add(new MailAddress(toEmail));
                msg.Subject = "We received your inquiry: " + subject;
                msg.Body = "Hi " + guestName + ",\r\n\r\n" +
                           "Thank you for contacting Blue Horizon Tours. Our ranger concierge team has received your message and will respond shortly.\r\n\r\n" +
                           "Subject: " + subject + "\r\n" +
                           "Your Message:\r\n" + messageText + "\r\n\r\n" +
                           "Warm regards,\r\nBlue Horizon | Explore South Africa";

                using (var smtp = new SmtpClient(Host, Port))
                {
                    smtp.EnableSsl = true;
                    smtp.Timeout = 10000;
                    smtp.Credentials = new NetworkCredential(User, Password);
                    await smtp.SendMailAsync(msg);
                }
            }
        }
    }
}
