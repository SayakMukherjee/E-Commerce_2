using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int id = Convert.ToInt32(row.Cells[1].Text);

        ProductModel model = new ProductModel();
        model.DeleteProduct(id);
        GridView1.DataBind();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int id = Convert.ToInt32(row.Cells[1].Text);

        //Redirect user to manageProduct page with selected rowId
        Response.Redirect("~/Pages/Management/ManageProducts.aspx?id=" + id);
        
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        GridViewRow row = GridView3.SelectedRow;
        String g = row.Cells[2].Text;

        //Redirect user to manageProduct page with selected rowId
        Response.Redirect("~/Pages/Management/ManageUsers.aspx?id=" + g);
    }

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Account/AdminRegister.aspx");
    }
}