<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Pages_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="pnlShoppingCart" runat="server">

    </asp:Panel>
<table>
        <tr>
            <td>
                <b>Total: </b>
            </td>
            <td>
                <asp:Literal ID="litTotal" runat="server" Text="" />
            </td>
        </tr>

        <tr>
            <td>
                <b>VAT: </b>
            </td>
            <td>
                <asp:Literal ID="litVat" runat="server" Text="" />
            </td>
        </tr>

        <tr>
            <td>
                <b>Shipping: </b>
            </td>
            <td>
                Rs: 150
            </td>
        </tr>

        <tr>
            <td>
                <b>Total Amount: </b>
            </td>
            <td>
                <asp:Literal ID="litTotalAmount" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkContinue" runat="server"  PostBackUrl="~/Pages/Index.aspx"
                    Text="Continue Shopping" />
                OR
                <asp:Button ID="btnCheckout" runat="server" PostBackUrl="#"
                     Width="250px" Text="CheckOut" onclick="btnCheckout_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

