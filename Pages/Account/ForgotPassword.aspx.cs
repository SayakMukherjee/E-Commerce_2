using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // initialize the Captcha validation error label
            CaptchaErrorLabel.Text = "Incorrect CAPTCHA code!";
            CaptchaErrorLabel.Visible = false;
        }

        // setup client-side input processing
        ExampleCaptcha.UserInputID = CaptchaCode.ClientID;

        if (IsPostBack)
        {
            // validate the Captcha to check we're not dealing with a bot
            string userInput = CaptchaCode.Text;
            bool isHuman = ExampleCaptcha.Validate(userInput);
            CaptchaCode.Text = null; // clear previous user input

            if (isHuman)
            {
                CaptchaErrorLabel.Visible = false;
                // TODO: proceed with protected action
                UserInfoModel model = new UserInfoModel();
                UserInformation info = new UserInformation();
                info = model.GetUserInfoByEmail(TextBox1.Text);
                if (info != null)
                {
                    if (info.SecretAnswer.Equals(TextBox2.Text))
                    {
                        Response.Redirect("~/Pages/Account/ResetPage.aspx?id=" + info.GUID);
                    }
                    else
                        Literal1.Text = "Wrong Answer";
                }
                else
                    Literal1.Text = "Email not Registered";
            }
            else
            {
                CaptchaErrorLabel.Visible = true;
            }
        }
        
    }
}