using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        
        String user = txtUsername.Text;
        String pass = txtPassword.Text;

        if (user != null && pass != null)
        {
            UserInfoModel model = new UserInfoModel();
            UserInformation info = new UserInformation();
            info = model.GetUserInfoByUserName(user);

            if (info != null)
            {

                if (info.Password == pass && info.IsVerified)
                {
                    Session["id"] = info.GUID;
                    Session["role"] = "user";
                    Response.Redirect("~/Pages/Index.aspx");
                }
                else
                    litStatus.Text = "Invalid Password";

            }
            else
                litStatus.Text = "Invalid Username";
        }
        else
            litStatus.Text = "Enter user name";
    }
}