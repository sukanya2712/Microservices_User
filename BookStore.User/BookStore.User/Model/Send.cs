﻿using System.Net.Mail;
using System.Net;
using System.Text;

namespace BookStore.User.Model
{
    public class Send
    {
        public string SendingMail(string emailTo, string token)
        {

            try
            {

                string emailFrom = "sukanyanaik511@gmail.com";

                MailMessage message = new MailMessage(emailFrom, emailTo);
                string mailbody = "Token Genrated: " + token;

                message.Subject = "Genrated Token will expire after 15 min"; message.Body = mailbody.ToString(); message.BodyEncoding = Encoding.UTF8;

                message.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); 
                NetworkCredential credential = new NetworkCredential("sukanyanaik511@gmail.com", "yewpkuewxmmrvrgr");
                smtpClient.EnableSsl = true;

                smtpClient.UseDefaultCredentials = false; smtpClient.Credentials = credential;

                smtpClient.Send(message);

                //smtpClient.Send(emailFrom, emailTo, subject, body);


                return emailTo;
            }
            catch (Exception ex)

            {

                throw ex;
            }
        }
    }
}
