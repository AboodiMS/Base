using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Helper101
{
    public static class MailService
    {
        private static readonly string From = "paradiseclinicservice@gmail.com";
        private static readonly string Pass = "Sajode42016991paradise";

        public static Task SendMail(string To, string Subject, string Body)
        {
            MailMessage Message = new MailMessage
            {
                Subject = Subject,
                Body = Body,
                From = new MailAddress(From),
                IsBodyHtml = true,
                Priority = MailPriority.High
            };

            SmtpClient smtp = new SmtpClient
            {
                Port = 587,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(From, Pass)
            };

            Message.To.Add(new MailAddress(To));
            smtp.Send(Message);
            return Task.CompletedTask;
        }
    }
}
