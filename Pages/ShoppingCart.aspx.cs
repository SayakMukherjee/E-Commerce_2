using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using System.Data;

public partial class Pages_ShoppingCart : System.Web.UI.Page
{
    double totalAmount;
    int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetPurchasesInCart();
    }
    private void GetPurchasesInCart()
    {
        OrderModel model = new OrderModel();
        double subTotal = 0;

        List<Order> purchaseList = model.getItemsInOrder((String)Session["id"]);
        CreateShopTable(purchaseList, out subTotal);

        //Add total to webpage
        double vat = subTotal * 0.21;
        totalAmount = subTotal + vat + 150;

        //Display on webpage
        litTotal.Text = "Rs " + subTotal;
        litVat.Text = "Rs " + vat;
        litTotalAmount.Text = "Rs " + totalAmount;
    }

    private void CreateShopTable(List<Order> purchaseList, out double subTotal)
    {
        subTotal = new Double();
        ProductModel model = new ProductModel();

        foreach (Order cart in purchaseList)
        {
            Product product = model.GetProduct(cart.ProductID);

            //Create Image button
            ImageButton btnImage = new ImageButton();

            btnImage.ImageUrl = string.Format("~/Images/Products/{0}", product.Image);
            btnImage.PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", product.ID);


            //Create Delete Link
            LinkButton lnkDelete = new LinkButton();

            lnkDelete.PostBackUrl = string.Format("~/Pages/ShoppingCart.aspx?id={0}", cart.ID);
            lnkDelete.Text = "Delete Item";
            lnkDelete.ID = "del" + cart.ID;

            //Add an OnClick Event
            lnkDelete.Click += Delete_Item;

            //Create the quantity dropdown list
            //Generate with numbers 1-20
            int[] amount = Enumerable.Range(1, 20).ToArray();
            DropDownList ddlAmount = new DropDownList();
            ddlAmount.DataSource = amount;
            ddlAmount.AppendDataBoundItems = true;
            ddlAmount.AutoPostBack = true;
            ddlAmount.ID = cart.ID.ToString();
            ddlAmount.DataBind();
            ddlAmount.SelectedValue = cart.OrderQuantity.ToString();
            ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

            //Create HTML table with 2 rows
            Table table = new Table { CssClass = "cartTable" };
            TableRow a = new TableRow();
            TableRow b = new TableRow();

            //Create 6 cells for row a
            TableCell a1 = new TableCell { RowSpan = 2, Width = 50 };
            TableCell a2 = new TableCell { Text = string.Format("<h4>{0}</h4></br>{1}</br>In Stock", product.Name, "Item No.: " + product.ID), HorizontalAlign = HorizontalAlign.Left, Width = 350 };
            TableCell a3 = new TableCell { Text = "Unit Price<hr/>" };
            TableCell a4 = new TableCell { Text = "Quantity<hr/>" };
            TableCell a5 = new TableCell { Text = "Item Total<hr/>" };
            TableCell a6 = new TableCell { };

            //Create 6 cells for row b
            TableCell b1 = new TableCell { };
            TableCell b2 = new TableCell { Text = "Rs " + product.Price };
            TableCell b3 = new TableCell { };
            TableCell b4 = new TableCell { Text = "Rs " + (cart.OrderQuantity * product.Price) };
            TableCell b5 = new TableCell { };
            TableCell b6 = new TableCell { };

            //Set special controls
            a1.Controls.Add(btnImage);
            a6.Controls.Add(lnkDelete);
            b3.Controls.Add(ddlAmount);

            //Add cells to rows
            a.Cells.Add(a1);
            a.Cells.Add(a2);
            a.Cells.Add(a3);
            a.Cells.Add(a4);
            a.Cells.Add(a5);
            a.Cells.Add(a6);

            b.Cells.Add(b1);
            b.Cells.Add(b2);
            b.Cells.Add(b3);
            b.Cells.Add(b4);
            b.Cells.Add(b5);
            b.Cells.Add(b6);

            //Add rows to table
            table.Rows.Add(a);
            table.Rows.Add(b);

            //Add table to pnlShoppingCart
            pnlShoppingCart.Controls.Add(table);

            //Add total amount of items in cart to subtotal
            subTotal += Convert.ToDouble(cart.OrderQuantity * product.Price);
        }
    }

    private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList selectedList = (DropDownList)sender;
        int quantity = Convert.ToInt32(selectedList.SelectedValue);
        int cartId = Convert.ToInt32(selectedList.ID);

        OrderModel model = new OrderModel();
        model.UpdateQuantity(cartId, quantity);

        Response.Redirect("~/Pages/ShoppingCart.aspx");
    }

    private void Delete_Item(object sender, EventArgs e)
    {
        LinkButton selectedLink = (LinkButton)sender;
        string link = selectedLink.ID.Replace("del", "");
        int cartId = Convert.ToInt32(link);

        OrderModel model = new OrderModel();
        model.DeleteOrder(cartId);
        Response.Redirect("~/Pages/ShoppingCart.aspx");

        if(model.GetAmountOfOrders((String)Session["id"])>0)
            Response.Redirect("~/Pages/ShoppingCart.aspx");
        else
            Response.Redirect("~/Pages/Index.aspx");
    }
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        BillModel b = new BillModel();
        i= b.createBill(create());

        OrderModel order = new OrderModel();
        List<Order> purchaseList = order.getItemsInOrder((String)Session["id"]);
        ProductModel model = new ProductModel();

        foreach (Order cart in purchaseList)
        {
            Product OldProduct = model.GetProduct(cart.ProductID);
            Product newProduct = new Product();
            newProduct.Name = OldProduct.Name;
            newProduct.ProductNumber = OldProduct.ProductNumber;
            newProduct.ManufactureDate = OldProduct.ManufactureDate;
            newProduct.Price = OldProduct.Price;
            newProduct.Stock = OldProduct.Stock - cart.OrderQuantity;
            newProduct.CategoryID = OldProduct.CategoryID;
            newProduct.Image = OldProduct.Image;

            model.UpdateProduct(cart.ProductID,newProduct);
        }
        order.MarkOrdersAsPaid(purchaseList,i);
        Response.Redirect("~/Pages/BillPage.aspx?id=" + i);
        //GenerateInvoicePDF();
        
        
    }

    protected Bill create()
    {
        OrderModel order = new OrderModel();
        UserInfoModel user = new UserInfoModel();

        Bill b = new Bill();
        b.ClientID = (String)Session["id"];
        b.Quantity = order.GetAmountOfOrders((String)Session["id"]);
        b.OrderDate = DateTime.Now;
        b.DeliveryDate = b.OrderDate.AddDays(5.0);
        b.TotalBill = (int)totalAmount;
        b.Address = user.GetUserInfoByGUID((String)Session["id"]).Address;
        b.Phone = user.GetUserInfoByGUID((String)Session["id"]).Phone;
        return b;
    }

    
}