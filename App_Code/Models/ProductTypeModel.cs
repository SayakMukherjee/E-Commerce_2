using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ProductTypeModel
{
    public string insertProductType(ProductType productType)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            db.ProductTypes.InsertOnSubmit(productType);
            db.SubmitChanges();
            return productType.Name + "inserted successfully";
        }
        catch (Exception msg)
        {
            return msg.ToString();
        }
    }

    public string UpdateProductType(int id, ProductType productType)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            var query = from p in db.ProductTypes where p.CategoryID == id select p;

            foreach (ProductType p in query)
            {
                p.Name = productType.Name;
            }


            db.SubmitChanges();
            return productType.Name + " updated successfully.";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string DeleteProductType(int id)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            var productType = (from p in db.ProductTypes where p.CategoryID == id select p).First();
            db.ProductTypes.DeleteOnSubmit(productType);

            db.SubmitChanges();

            return productType.Name + " deleted successfully.";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }
}