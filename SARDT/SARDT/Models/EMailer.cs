using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SARDT.Models
{
    public class EMailer
    {

        public bool SendMessageFromSystem(SystemMessage message)
        {
            return SendMessage("sardtnoreply@gmail.com", "lanesardt", message);
        }

        private bool SendMessage(string email, string password, SystemMessage message)
        {
            bool successful = false;
            {
                MailMessage mailMessage = new MailMessage();
                try
                {
                    mailMessage.From = new MailAddress(email);
                    foreach (Member member in message.To)
                    {
                        mailMessage.To.Add(new MailAddress(member.Email));
                    }
                    mailMessage.Subject = message.Subject;
                    mailMessage.Body = message.Body;

                    var gmailClient = new System.Net.Mail.SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential(email, password)
                    };

                    gmailClient.Send(mailMessage);
                    successful = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                finally
                {
                    mailMessage = null;
                }
            }
            return successful;
        }

    }
}