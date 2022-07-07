using System.Net;
using System.Net.Mail;
using System.Text;

namespace T.Application.Services.Account;

public class EmailService
{
    public Task Execute(string userEmail, string body, string subject)
    {
        var smtp = new SmtpClient();
        smtp.Port = 587;//سرور جیمیل
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;
        smtp.Timeout = 1000000;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = false;
        //ایمیلی که ارسال کننده ایمیل است رو بهش معرفی کنیم.
        smtp.Credentials = new NetworkCredential("keshtmand.vvv@gmail.com", "vahid13799");
        var message = new MailMessage("keshtmand.vvv@gmail.com", userEmail, subject, body);
        message.IsBodyHtml = true;
        message.BodyEncoding = UTF8Encoding.UTF8;
        message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
        smtp.Send(message);
        return Task.CompletedTask;

    }
}
