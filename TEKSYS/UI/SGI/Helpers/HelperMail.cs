using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Helpers
{
    public static class HelperMail
    {
        #region Mail Config

        private static string smtpAddress = "smtp.gmail.com";
        private static int portNumber = 587;
        private static bool enableSSL = true;

        private static string emailFrom = "SgiSystem1@gmail.com";
        private static string password = "sistemasgi";
        private static string emailTo = "extpljm@gmail.com";
        private static string subject = "Hello";
        private static string body = "Hello, I'm just writing this to say Hi!";

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstMails"></param>
        public static void SendMail(List<string> lstMails,string subjectP,string bodyP)
        {
            try
            {
                if (lstMails.Count > 0)
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFrom);

                        foreach (var mailItem in lstMails)
                        {
                            mail.To.Add(mailItem);                            
                        }

                        //mail.To.Add(emailTo);
                        mail.Subject = subjectP;
                        mail.Body = bodyP;
                        mail.IsBodyHtml = true;
                        // Can set to false, if you are sending pure text.

                        //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                        //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential(emailFrom, password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
