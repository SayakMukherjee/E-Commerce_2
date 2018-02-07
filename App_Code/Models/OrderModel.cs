using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class OrderModel
{
    public string insertOrder(Order order)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            db.Orders.InsertOnSubmit(order);
            db.SubmitChanges();
            return order.OrderDate + "inserted successfully";
        }
        catch (Exception msg)
        {
            return msg.ToString();
        }
    }

    public string UpdateOrder(int id, Order order)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            var query = from p in db.Orders where p.ID == id select p;

            foreach (Order p in query)
            {
                p.ClientID = order.ClientID;
                p.ProductID = order.ProductID;
                p.OrderQuantity = order.OrderQuantity;
                p.OrderDate = order.OrderDate;
                p.IsInCart = order.IsInCart;
            }


            db.SubmitChanges();
            return order.OrderDate + " updated successfully.";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string DeleteOrder(int id)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            var order = (from p in db.Orders where p.ID == id select p).First();
            db.Orders.DeleteOnSubmit(order);

            db.SubmitChanges();

            return order.OrderDate + " deleted successfully.";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public List<Order> getItemsInOrder(String userId)
    {
        ModelDataContext db = new ModelDataContext();
        List<Order> orders = (from x in db.Orders
                                   where x.ClientID == userId
                && x.IsInCart
                                   orderby x.OrderDate
                                   select x).ToList();
        /*List<Order> orders = (from x in db.Orders
                              where x.IsInCart
                              orderby x.OrderDate
                              select x).ToList();*/

        return orders;
    }


    public int GetAmountOfOrders(String guID)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            int amount = (from x in db.Orders
                          where x.ClientID == guID
                            && x.IsInCart
                          orderby x.OrderDate
                          select x.OrderQuantity).Sum();
            /*int amount = (from x in db.Orders
                          where x.IsInCart
                          orderby x.OrderDate
                          select x.OrderQuantity).Sum();*/
            return amount;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public void UpdateQuantity(int id, int quantity)
    {
        ModelDataContext db = new ModelDataContext();
        var query = from p in db.Orders where p.ID == id select p;

        foreach (Order p in query)
        {
            p.OrderQuantity = quantity;
        }


        db.SubmitChanges();

    }

    public void MarkOrdersAsPaid(List<Order> orders,int billID)
    {
        ModelDataContext db = new ModelDataContext();
        if (orders != null)
        {
            foreach (Order order in orders)
            {
                //Cart oldcart = db.Carts.Find(cart.ID);
                var query = from p in db.Orders where p.ID == order.ID select p;
                foreach (Order p in query)
                {
                    p.OrderDate = DateTime.Now;
                    p.IsInCart = false;
                    p.BillID = billID;
                }

            }

            db.SubmitChanges();
        }
    }

    public List<Order> getItemsInBill(int billID)
    {
        ModelDataContext db = new ModelDataContext();
        List<Order> orders = (from x in db.Orders
                              where x.BillID == billID
                              orderby x.OrderDate
                              select x).ToList();
        /*List<Order> orders = (from x in db.Orders
                              where x.IsInCart
                              orderby x.OrderDate
                              select x).ToList();*/

        return orders;
    }
}