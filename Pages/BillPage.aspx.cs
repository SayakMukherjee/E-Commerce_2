using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;

public partial class Pages_BillPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BillModel model = new BillModel();
        Bill b = new Bill();
        UserInfoModel user = new UserInfoModel();

        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            b = model.getBill(id);
            litName.Text = user.GetUserInfoByGUID(b.ClientID).FirstName + " " + user.GetUserInfoByGUID(b.ClientID).LastName;
            litPhone.Text = b.Phone.ToString();
            litQuantity.Text = b.Quantity.ToString();
            litODate.Text = b.OrderDate.ToShortDateString();
            litDDate.Text = b.DeliveryDate.ToShortDateString();
            litAddress.Text = b.Address;
            litBill.Text = "Rs " + b.TotalBill.ToString();
        }
    }
    protected void btnCont_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Index.aspx");
    }

    protected void GenerateInvoicePDF(object sender, EventArgs e)
    {

        //Data for Invoice (Bill).
        OrderModel order = new OrderModel();
        UserInfoModel user = new UserInfoModel();
        ProductModel pm = new ProductModel();
        //UserInformation u = new UserInformation();
        BillModel bill = new BillModel();
        Bill b = new Bill();
       
        b = bill.getBill(Convert.ToInt32(Request.QueryString["id"]));
        List<Order> purchaseList = order.getItemsInBill(Convert.ToInt32(Request.QueryString["id"]));

        string companyName = "24 x 7";
        int orderNo = b.ID;
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] {
                            new DataColumn("ProductId", typeof(string)),
                            new DataColumn("Product", typeof(string)),
                            new DataColumn("Price", typeof(int)),
                            new DataColumn("Quantity", typeof(int)),
                            new DataColumn("Total", typeof(int))});
        foreach (Order cart in purchaseList)
        {
            
            Product pro = pm.GetProduct(cart.ProductID);
            dt.Rows.Add(pro.ProductNumber.ToString(), pro.Name, pro.Price, cart.OrderQuantity, (cart.OrderQuantity * pro.Price));
        }


        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                StringBuilder sb = new StringBuilder();

                //Generate Invoice (Bill) Header.

                sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
                sb.Append("<tr><td colspan = '2'></td></tr>");
                sb.Append("<tr><td><b>Order No: </b>");
                sb.Append(orderNo);
                sb.Append("</td><td align = 'right'><b>Date: </b>");
                sb.Append(DateTime.Now);
                sb.Append(" </td></tr>");
                sb.Append("<tr><td colspan = '2'><b>Company Name: </b>");
                sb.Append(companyName);
                sb.Append("</td></tr>");
                sb.Append("</table>");
                sb.Append("<br />");

                //Generate Invoice (Bill) Items Grid.
                sb.Append("<table border = '1'>");
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(column.ColumnName);
                    sb.Append("</th>");
                }
                sb.Append("</tr>");
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<td>");
                        sb.Append(row[column]);
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("<tr><td align = 'right' colspan = '");
                sb.Append(dt.Columns.Count - 1);
                sb.Append("'>VAT</td>");
                sb.Append("<td>");
                sb.Append(dt.Compute("sum(Total)*0.21",""));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td align = 'right' colspan = '");
                sb.Append(dt.Columns.Count - 1);
                sb.Append("'>Delivery Charges</td>");
                sb.Append("<td>");
                sb.Append("150");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td align = 'right' colspan = '");
                sb.Append(dt.Columns.Count - 1);
                sb.Append("'>Total</td>");
                sb.Append("<td>");
                sb.Append(b.TotalBill.ToString());
                sb.Append("</td>");
                sb.Append("</tr></table>");

                //Export HTML String as PDF.
                StringReader sr = new StringReader(sb.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + orderNo + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    }
}