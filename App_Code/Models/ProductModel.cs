using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ProductModel
{
    public string insertProduct(Product product)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            db.Products.InsertOnSubmit(product);
            db.SubmitChanges();
            return product.Name + "inserted successfully";
        }
        catch (Exception msg)
        {
            return msg.ToString();
        }
    }

    public string UpdateProduct(int id, Product product)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            var query = from p in db.Products where p.ID == id select p;

            foreach (Product p in query)
            {
                p.Name = product.Name;
                p.ProductNumber = product.ProductNumber;
                p.ManufactureDate = product.ManufactureDate;
                p.Price = product.Price;
                p.Stock = product.Stock;
                p.CategoryID = product.CategoryID;
                p.Image = product.Image;
            }


            db.SubmitChanges();
            return product.Name + " updated successfully.";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string DeleteProduct(int id)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            var product = (from p in db.Products where p.ID == id select p).First();
            db.Products.DeleteOnSubmit(product);

            db.SubmitChanges();

            return product.Name + " deleted successfully.";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public Product GetProduct(int id)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            var product = (from p in db.Products where p.ID == id select p).First();
            return product;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> getAllProducts()
    {
        try
        {
            using (ModelDataContext db = new ModelDataContext())
            {
                List<Product> products = (from x in db.Products select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> getProductByCategoryID(int categoryID)
    {
        try
        {
            using (ModelDataContext db = new ModelDataContext())
            {
                List<Product> products = (from x in db.Products where x.CategoryID == categoryID select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    
}