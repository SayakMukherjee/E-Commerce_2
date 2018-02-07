using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class BillModel
{
    public int createBill(Bill bill)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            db.Bills.InsertOnSubmit(bill);
            db.SubmitChanges();
            return bill.ID;
        }
        catch (Exception msg)
        {
            return 0;
        }
    }

    public Bill getBill(int ID)
    {
        ModelDataContext db = new ModelDataContext();
        Bill bill = (from x in db.Bills
                              where x.ID == ID
                              select x).FirstOrDefault();
        /*List<Order> orders = (from x in db.Orders
                              where x.IsInCart
                              orderby x.OrderDate
                              select x).ToList();*/

        return bill;
    }
}