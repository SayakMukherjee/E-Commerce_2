<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Pages_Management_ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>Name :</p>
    <asp:TextBox ID="txtNameProduct" runat="server"></asp:TextBox>
    <p>Product Number :</p>
    <asp:TextBox ID="txtPNo" runat="server"></asp:TextBox>
    <p>Manufacture Date :</p>
    <asp:Calendar ID="ManDate" runat="server" BackColor="White" 
        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
        ForeColor="#003399" Height="200px" Width="220px">
        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
            Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
        <WeekendDayStyle BackColor="#CCCCFF" />
    </asp:Calendar>
    <p>Price :</p>
    <asp:TextBox ID="txtPProd" runat="server"></asp:TextBox>
    <p>Stock :</p>
    <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
    <p>Category ID :</p>
    <asp:DropDownList ID="ddCategory" runat="server" DataSourceID="SqlDataSource1" 
        DataTextField="Name" DataValueField="CategoryID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WebshopDBConnectionString %>" 
        SelectCommand="SELECT * FROM [ProductType]"></asp:SqlDataSource>
    <p>Image :</p>
    <asp:DropDownList ID="ddImage" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnProduct" runat="server" Text="SUBMIT" 
        onclick="btnProduct_Click" />
    <br />
    <br />
    <asp:Label ID="lblProduct" runat="server"></asp:Label>
</asp:Content>

