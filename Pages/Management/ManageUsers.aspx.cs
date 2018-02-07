using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_ManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
        UserInfoModel model = new UserInfoModel();
        UserInformation user = new UserInformation();
        user = model.GetUserInfoByGUID(Request.QueryString["id"]);
        txtFirstname.Text = user.FirstName;
        txtLastName.Text = user.LastName;
        txtPassword.Text = user.Password;
        txtPhone.Text = user.Phone.ToString();
        txtAddress.Text = user.Address;
        txtEmail.Text = user.Email;
        txtUsername.Text = user.Username;
        txtPostalCode.Text = user.PostalCode.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserInfoModel model = new UserInfoModel();
        litStatus.Text=model.Verify(Request.QueryString["id"]);
    }
}