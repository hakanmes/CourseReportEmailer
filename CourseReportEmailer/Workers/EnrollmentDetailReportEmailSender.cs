using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CourseReportEmailer.Workers
{
    internal class EnrollmentDetailReportEmailSender
    {
        public void Send(string fileName)
        {
            //Smtp tüm email gönderim işlemlerine bakan bir makine.
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            //DeliveryMethod bzim nasıl göndereceğimize ilişkin bir method-biz burada Networku kullnarak gönderdiğimizi belirtiyoruz
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //Default kimlik bilgilerini istemediğimizi belirtiyoruz.
            client.UseDefaultCredentials = false;
            NetworkCredential creds = new NetworkCredential("hakanmess@gmail.com","kmrjames77");
            client.EnableSsl = true;
            client.Credentials = creds;

            MailMessage message = new MailMessage("hakanmess@gmail.com","hakanmess@gmail.com");
            message.Subject = "Kral Hakan";
            message.IsBodyHtml = true;
            message.Body = "Hi,<br><br>Nasılsın bro lütfen email detail reporter'ı bul<br><br>Lütfen bu konuları iyi çalış.<br><br>Best,<br><br>Hakan.";

            Attachment attachment = new Attachment(fileName);
            message.Attachments.Add(attachment);
            client.Send(message);
            Console.WriteLine("sent.");
        }
    }
}
