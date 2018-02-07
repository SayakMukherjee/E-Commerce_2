using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        String user = txtUsername.Text;
        String pass = txtPassword.Text;

        AdminModel model = new AdminModel();
        AdminTable info = new AdminTable();
        info = model.GetUserInfoByUserName(user);

        if (info != null)
        {

            if (info.Password == pass)
            {
                Session["id"] = info.GUID;
                Session["role"] = "admin";
                Response.Redirect("~/Pages/Index.aspx");
            }
            else
                litStatus.Text = "Invalid Password";

        }
        else
            litStatus.Text = "Invalid Username";
    }
}