using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net;
using System.Net.Mail;
/// <summary>
/// Descrizione di riepilogo per inviaEmail
/// </summary>
public class InviaEmailAbbott
{
    public InviaEmailAbbott()
    {
        //
        // TODO: aggiungere qui la logica del costruttore
        //
    }

    public Boolean sendMail(string from, string to, string cc, string bcc, string Subject, string Body)
    {
        MailMessage message = new MailMessage(from, to);
	ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        message.Subject = Subject;
        message.Body = Body;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
        System.Net.NetworkCredential basicCredential1 = new
        System.Net.NetworkCredential("fullcro@gmail.com", "vpgwegdvymecfgwi");
        client.EnableSsl = true;
        client.UseDefaultCredentials = true;
        client.Credentials = basicCredential1;
        client.Send(message);
        return true;
    }
}
