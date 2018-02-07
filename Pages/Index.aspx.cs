using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            FillPage(0);
    }

    private void FillPage(int catID)
    {
        //get a list of all products in db
        ProductModel model = new ProductModel();
        List<Product> products;
        if (catID == 0)
            products = model.getAllProducts();
        else
            products = model.getProductByCategoryID(catID);

        //Make sure products exist in database
        if(products != null)
        {
            //create a new panel with imagebutton and two labels for each product
            foreach(Product product in products)
            {
                Panel pnlProduct = new Panel();
                ImageButton imagebutton = new ImageButton();
                Label lblName = new Label();
                Label lblPrice = new Label();

                //set childControls' property
                imagebutton.ImageUrl = "~/Images/Products/" + product.Image;
                imagebutton.CssClass = "productImage";
                imagebutton.PostBackUrl = "~/Pages/ProductDisp.aspx?id=" + product.ID;

                lblName.Text = product.Name;
                lblName.CssClass = "productName";

                lblPrice.Text = "Rs " + product.Price;
                lblName.CssClass = "productPrice";

                //Add child controls to panel
                pnlProduct.Controls.Add(imagebutton);
                pnlProduct.Controls.Add(new Literal { Text = "<br />" });
                pnlProduct.Controls.Add(lblName);
                pnlProduct.Controls.Add(new Literal { Text = "<br />" });
                pnlProduct.Controls.Add(lblPrice);

                //Add Dynamic panels to static parent panel
                ProductPanel.Controls.Add(pnlProduct);
            }
        }
        else
        {
           ProductPanel.Controls.Add(new Literal { Text = "No products found!" });
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(DropDownList1.SelectedValue);
        FillPage(id);
    }
}
