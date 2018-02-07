<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Pages_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Filter: <asp:DropDownList ID="DropDownList1" runat="server" 
        
        DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="CategoryID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WebshopDBConnectionString %>" 
        SelectCommand="SELECT * FROM [ProductType]"></asp:SqlDataSource>

    <asp:Button ID="Button1" runat="server" Text="SEARCH" onclick="Button1_Click" />
   <asp:Panel ID="ProductPanel" runat="server"></asp:Panel>
    <div style="clear:both"></div>
</asp:Content>

