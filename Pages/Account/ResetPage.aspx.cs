using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

public partial class Pages_Account_ResetPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            if (txtPass.Text.Equals(txtConfrmPass.Text))
            {
                String g = Request.QueryString["id"];
                UserInfoModel model = new UserInfoModel();
                litResult.Text = model.ResetPass(g, txtPass.Text);


                UserInformation info = new UserInformation();
                info = model.GetUserInfoByGUID(g);
                string strSubject = "24x7 Email Validation";
                string strBody = "Your password is :" + info.Password;
                SendEmail(info.Email, strSubject, strBody);
            }
            else
                litResult.Text = "Password should Match";
        }
    }

    protected String SendEmail(string toAddress, string subject, string body)
    {
        string result = "Message Sent Successfully..!!";
        string senderID = "projectsfiem24x7@gmail.com"; // use sender’s email id here..
        const string senderPassword = "fiem@2016"; // sender password here…
        try
        {
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // smtp server address here…
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                Timeout = 30000,
            };
            MailMessage message = new MailMessage(senderID, toAddress, subject, body);
            smtp.Send(message);
        }
        catch (Exception ex)
        {
            result = "Error sending email.!!!";
        }
        
        return result;
    }
}