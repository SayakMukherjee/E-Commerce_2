using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if ((txtPassword.Text).Equals(txtConfrmPassword.Text))
        {
            UserInfoModel model = new UserInfoModel();
            UserInformation info = new UserInformation();
            Guid g = Guid.NewGuid();
            info.GUID = g.ToString();
            info.FirstName = txtFirstname.Text;
            info.LastName = txtLastName.Text;
            info.Address = txtAddress.Text;
            info.Username = txtUsername.Text;
            info.Password = txtPassword.Text;
            info.PostalCode = Convert.ToInt32(txtPostalCode.Text);
            info.IsVerified = false;
            info.Email = txtEmail.Text;
            info.Phone = Convert.ToInt64(txtPhone.Text);
            info.SecretAnswer = txtAns.Text;
            model.InsertUserInformation(info);
            litStatus.Text = "Registration Successful";
        }
        else
        {
            litStatus.Text = "Both password should be same";
        }
    }
}