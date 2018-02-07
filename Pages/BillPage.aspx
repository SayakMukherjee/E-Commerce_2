<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BillPage.aspx.cs" Inherits="Pages_BillPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Name :
        <asp:Literal ID="litName" runat="server"></asp:Literal>
    </p>
    <p>
        Address :<asp:Literal ID="litAddress" runat="server"></asp:Literal>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Phone :<asp:Literal ID="litPhone" runat="server"></asp:Literal>
    </p>
    <p>
        Quantity :<asp:Literal ID="litQuantity" runat="server"></asp:Literal>
    </p>
    <p>
        Order Date :<asp:Literal ID="litODate" runat="server"></asp:Literal>
    </p>
    <p>
        Delivery Date :<asp:Literal ID="litDDate" runat="server"></asp:Literal>
    </p>
    <p>
        Total Bill :<asp:Literal ID="litBill" runat="server"></asp:Literal>
    </p>
    <p>
    <asp:Button ID="Button1" Text="Generate Invoice" OnClick="GenerateInvoicePDF" runat="server" />
    </p>
    <p>
        <asp:Button ID="btnCont" runat="server" onclick="btnCont_Click" 
            Text="Continue Shopping" />
    </p>
</asp:Content>

