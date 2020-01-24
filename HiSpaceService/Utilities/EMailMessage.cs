using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HiSpaceService.Utilities
{
    public static class EMailMessage
    {
        static string Host = "smtp.gmail.com";
        static bool EnableSsl = true;
        static bool UseDefaultCredentials = false;
        static int Port = 587;
        //static int Port = 25;
        static string email = "karthick@highbrowdiligence.com";
        static string password = "Onecrore@1";
        static string ToEmail = "Hari Madhavan <hari@highbrowdiligence.com>, Saju Sasindran <saju@highbrowdiligence.com>, Tamilarasan Arjunan <tamilarasan@highbrowdiligence.com>, Karthick Kumar <karthick@highbrowdiligence.com>";
        static string Subject = "HiSpace Activation!. OTP generation";
        static string Body="";

        public static bool Send()
        {
            bool rs = true;

            using (MailMessage mm = new MailMessage(email, ToEmail))
            {               
                mm.Subject = Subject;
                mm.Body = FormatBody(Body);
                //if (fuAttachment.HasFile)
                //{
                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                //}
                mm.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = Host;
                smtp.EnableSsl = EnableSsl;
                NetworkCredential NetworkCred = new NetworkCredential(email, password);
                smtp.UseDefaultCredentials = UseDefaultCredentials;
                smtp.Credentials = NetworkCred;
                smtp.Port = Port;
                smtp.Send(mm);
            }

            return rs;
        }

        public static string FormatBody(string message)
        {
            string html = "";

            html += "Dear Customer,</br>";
            html += "Welcome to HiSpace! Your OTP is " + InternetSMS.GenerateOTP() + " for activate your login. (Ref.ID-002354623). Dated on " + DateTime.Now.ToString();
            html += "</br></br></br>";
            html += "Regards,</br>";
            html += "HiSpace";
            html += "";

            return html;
        }
    }
}