using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Text;


namespace AETTI
{
    public class SenderMail
    {
        private int _port;
        private string _smtp;
        private string _mailFrom;
        private string _mailPassword;

        public SenderMail()
        {
            _port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"].ToString());
            _smtp = ConfigurationManager.AppSettings["SmtpHost"].ToString();
            _mailFrom = ConfigurationManager.AppSettings["Mail"].ToString();
            _mailPassword = ConfigurationManager.AppSettings["MailPassword"].ToString();
        }

        public Boolean Send(string to, string subject, string body)
        {
            try
            {
                MailMessage Mail = new MailMessage();

                Mail.From = new MailAddress(_mailFrom);
                Mail.To.Add(to);
                Mail.Subject = subject;
                Mail.Body = body;

                SmtpClient Server = new SmtpClient(_smtp);

                Server.Port = _port;
                Server.Credentials = new System.Net.NetworkCredential(_mailFrom, _mailPassword);
                Server.EnableSsl = true;
                Server.Send(Mail);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}