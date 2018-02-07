using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            if (Session["role"] == "user")
            {
                lnkLogin.Visible = false;
                lnkRegister.Visible = false;
                HyperLink4.Visible = false;

                lnkLogout.Visible = true;
                lnkLogout.Visible = true;

                OrderModel model = new OrderModel();
                String g = (String)Session["id"];
                string userId = getUser(g);
                litStatus.Text = string.Format("{0} ({1})", userId, model.GetAmountOfOrders(g));
            }
            else
            {
                lnkLogin.Visible = false;
                lnkRegister.Visible = false;
                HyperLink4.Visible = true;

                lnkLogout.Visible = true;
                lnkLogout.Visible = true;
                litStatus.Text = "ADMIN";
            }
            
        }
        else
        {
            lnkLogin.Visible = true;
            lnkRegister.Visible = true;
            HyperLink4.Visible = false;

            lnkLogout.Visible = false;
            lnkLogout.Visible = false;
        }

    }
    
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Pages/Index.aspx");
    }

    protected String getUser(String id)
    {
        UserInfoModel model = new UserInfoModel();
        UserInformation info = new UserInformation();
        info=model.GetUserInfoByGUID(id);
        return info.FirstName;
    }
    protected void HyperLink4_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            //String g = (String)Session["id"];
            //string userId = getUser(g);
            if ((String)Session["role"] == "admin")
            {
                Response.Redirect("~/Pages/Management/Manage.aspx");
            }
            else
                Response.Redirect("~/Pages/Account/Login.aspx");
        }
        else
            Response.Redirect("~/Pages/Index.aspx");
    }
}
