using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Pages_ProductDisp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductModel model = new ProductModel();
            Product product = model.GetProduct(id);

            //Fill page with data
            lblPrice.Text = "Price per unit: <br/>Rs " + product.Price;
            lblTitle.Text = product.Name;
            lblManufac.Text = product.ManufactureDate.ToShortDateString();
            lblItemNr.Text = id.ToString();
            imgProduct.ImageUrl = "~/Images/Products/" + product.Image;

            //Fill amount dropdown list with numbers 1-20
            int[] amount = Enumerable.Range(1, 20).ToArray();
            ddlAmount.DataSource = amount;
            ddlAmount.AppendDataBoundItems = true;
            ddlAmount.DataBind();

            int s = product.Stock;
            if (s > 0)
            {
                Label1.BackColor = Color.Green;
                Label1.Text = "Available";
            }
            else {
                Label1.BackColor = Color.Red;
                Label1.Text = "Out Of Stock";
                btnAdd.Enabled = false;
            }
            
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            if (Session["id"] != null)
            {
                if (Session["role"] == "user")
                {
                    ProductModel pro = new ProductModel();

                    UserInformation info = new UserInformation();
                    UserInfoModel model = new UserInfoModel();
                    Order cart = new Order();

                    String g = (String)Session["id"];
                    info = model.GetUserInfoByGUID(g);

                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    int amount = Convert.ToInt32(ddlAmount.SelectedValue);

                    if (amount <= pro.GetProduct(id).Stock)
                    {
                        cart.OrderQuantity = amount;
                        Random r = new Random();
                        cart.ClientID = info.GUID;
                        cart.OrderDate = DateTime.Now;
                        cart.IsInCart = true;
                        cart.ProductID = id;

                        OrderModel order = new OrderModel();
                        lblResult.Text = order.insertOrder(cart);
                    }
                    else
                        lblResult.Text = "Required Amount not present";
                }
                else
                    Response.Redirect("~/Pages/Index.aspx");
            }
            else
                lblResult.Text = "Login to Order Products.";
        }
    }
}