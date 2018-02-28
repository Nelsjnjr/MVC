
using Emaar.Pier7.Website.Models.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Emaar.Pier7.Website.Email
{
    public class EmailHelper
    {
        public bool SendEmail(SubscribeModel subscribe)
        {
            MailMessage mail = null;

            mail = new MailMessage();
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            MailAddress fromAddress = new MailAddress(subscribe.Email);
            mail.From = fromAddress;
            mail.To.Add(ConfigurationManager.AppSettings["Toemail"].ToString());
            mail.Subject = ConfigurationManager.AppSettings["Subject"].ToString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Body = GenerateBody(subscribe);
            SmtpClient mSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpClient"].ToString());
            mSmtpClient.Send(mail);
            return true;


        }
        private string GenerateBody(SubscribeModel subscribe)
        {
            string _printHTMLTemptalate = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("Email/enquires.html"));
            string _tempReciept = _printHTMLTemptalate;
            _tempReciept = _tempReciept.Replace("[Name]", subscribe.FullName);
            _tempReciept = _tempReciept.Replace("[ContactNumber]", subscribe.ContactNumber);
            _tempReciept = _tempReciept.Replace("[EmailAddress]", subscribe.Email);
            _tempReciept = _tempReciept.Replace("[Comment]", subscribe.Comments);

            return _tempReciept.ToString();
        }
    }
}