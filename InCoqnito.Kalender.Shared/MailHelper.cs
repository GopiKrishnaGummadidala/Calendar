using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Shared
{
    public static class MailHelper
    {
        public static bool SendMail(string body, string subject, List<string> toEmails)
        {
            bool emailResponse = false;
            try
            {
                //instantiate a new MimeMessage
                var message = new MimeMessage();
                //Setting the To e-mail address
                foreach(var email in toEmails)
                {
                    message.To.Add(new MailboxAddress(email));
                }
                
                //Setting the From e-mail address
                message.From.Add(new MailboxAddress("Gopi Krishna", "gummadidala.gummadidalatechyguy@gmail.com"));
                //E-mail subject 
                message.Subject = subject;
                //E-mail message body
                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = body
                };

                //Configure the e-mail
                using (var emailClient = new SmtpClient())
                {
                    emailClient.Connect("smtp.gmail.com", 587, false);
                    emailClient.Authenticate("gummadidala.gummadidalatechyguy@gmail.com", "******");
                    emailClient.Send(message);
                    emailClient.Disconnect(true);
                }
                emailResponse = true;
            }
            catch (Exception ex)
            {
                // To Exception Logging
                emailResponse = false;
            }

            return emailResponse;
        }
    }
}
