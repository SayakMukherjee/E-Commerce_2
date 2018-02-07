using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

public partial class Pages_Management_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImages();

            //Check if url contains an id
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
            }

        }
    }

    private void FillPage(int id)
    {
        //Get selected product from database.
        ProductModel model = new ProductModel();
        Product product = model.GetProduct(id);

        //Fill Data
        txtNameProduct.Text = product.Name;
        txtPNo.Text = Convert.ToString(product.ProductNumber);
        ManDate.SelectedDate = product.ManufactureDate;
        txtPProd.Text = (product.Price).ToString();
        txtStock.Text = (product.Stock).ToString();
        ddCategory.SelectedValue = Convert.ToString(product.CategoryID);
        ddImage.SelectedValue = product.Image;

        
    }

    private void GetImages()
    {
        try
        {
            //Get all filepaths
            string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

            //Get all filenames and add them to arraylist
            ArrayList imageList = new ArrayList();
            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imageList.Add(imageName);
            }

            //set the arraylist as the dropdown's datasource and refresh
            ddImage.DataSource = imageList;
            ddImage.AppendDataBoundItems = true;
            ddImage.DataBind();
        }
        catch (Exception e)
        {
            lblProduct.Text = e.ToString();
        }
    }

    private Product createProduct()
    {
        Product product = new Product();

        product.Name = txtNameProduct.Text;
        product.ProductNumber = Convert.ToInt32(txtPNo.Text);
        product.ManufactureDate = ManDate.SelectedDate;
        product.Price = Convert.ToInt32(txtPProd.Text);
        product.Stock = Convert.ToInt32(txtStock.Text);
        product.CategoryID = Convert.ToInt32(ddCategory.SelectedValue);
        product.Image = ddImage.SelectedValue;

        return product;
    }
    protected void btnProduct_Click(object sender, EventArgs e)
    {
        ProductModel model = new ProductModel();
        Product p = createProduct();

        //Check if url contains an id
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblProduct.Text = model.UpdateProduct(id, p);
        }
        else
        {
            lblProduct.Text = model.insertProduct(p);
        }

        //lblProduct.Text = model.insertProduct(p);
    }
}